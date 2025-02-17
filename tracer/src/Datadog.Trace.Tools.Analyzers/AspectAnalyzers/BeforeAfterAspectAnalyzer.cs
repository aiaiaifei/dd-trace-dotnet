﻿// <copyright file="BeforeAfterAspectAnalyzer.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Datadog.Trace.Tools.Analyzers.AspectAnalyzers;

/// <summary>
/// An analyzer that analyzers aspects that use [AspectMethodInsertAfter] and [AspectMethodInsertBefore]
/// for example, and checks that they are all wrapped in a try-catch block. These methods should never throw
/// so they should always have a try-catch block around them.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class BeforeAfterAspectAnalyzer : DiagnosticAnalyzer
{
    /// <summary>
    /// The diagnostic ID displayed in error messages
    /// </summary>
    public const string DiagnosticId = "DD0004";

    /// <summary>
    /// The severity of the diagnostic
    /// </summary>
    public const DiagnosticSeverity Severity = DiagnosticSeverity.Info;

#pragma warning disable RS2008 // Enable analyzer release tracking for the analyzer project
    private static readonly DiagnosticDescriptor MissingTryCatchRule = new(
        DiagnosticId,
        title: "Aspect is missing try-catch block",
        messageFormat: "Aspect method bodies should contain a try-catch block at the top level",
        category: "Reliability",
        defaultSeverity: Severity,
        isEnabledByDefault: true,
        description: "[AspectMethodInsertBefore] and [AspectMethodInsertAfter] Aspects should guarantee safety if possible. Please wrap the aspect in a try-catch block.");
#pragma warning restore RS2008

    /// <inheritdoc />
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(MissingTryCatchRule);

    /// <inheritdoc />
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        // Consider registering other actions that act on syntax instead of or in addition to symbols
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
        context.RegisterSyntaxNodeAction(AnalyseMethod, SyntaxKind.MethodDeclaration);
    }

    private void AnalyseMethod(SyntaxNodeAnalysisContext context)
    {
        // assume that generated code is safe, so bail out for perf reasons
        if (context.IsGeneratedCode || context.Node is not MethodDeclarationSyntax methodDeclaration)
        {
            return;
        }

        var attributes = methodDeclaration.AttributeLists;
        if (!attributes.Any())
        {
            // no attributes, let's just bail
            return;
        }

        var hasAspectAttribute = false;
        foreach (var attributeList in attributes)
        {
            foreach (var attribute in attributeList.Attributes)
            {
                var name = attribute.Name.ToString();
                if (name is "AspectMethodInsertBefore" or "AspectMethodInsertAfter"
                    or "AspectMethodInsertBeforeAttribute" or "AspectMethodInsertAfterAttribute")
                {
                    hasAspectAttribute = true;
                    break;
                }
            }
        }

        if (!hasAspectAttribute)
        {
            // not an aspect
            return;
        }

        var bodyBlock = methodDeclaration.Body;
        if (bodyBlock is null)
        {
            // If we don't have a bodyBlock, it's probably a lambda or expression bodied member
            // These can't have try catch blocks, so we should bail out
            var location = methodDeclaration.ExpressionBody?.GetLocation() ?? methodDeclaration.GetLocation();
            context.ReportDiagnostic(Diagnostic.Create(MissingTryCatchRule, location));
            return;
        }

        // first statement should be a try-catch block
        if (!bodyBlock.Statements.Any())
        {
            // ignore this case, for now, if there's nothing in there, it's safe, and we don't want to hassle users too soon
            return;
        }

        if (bodyBlock.Statements.Count != 1)
        {
            // oops, you should have a try block here, and it should be the only child
            context.ReportDiagnostic(Diagnostic.Create(MissingTryCatchRule, bodyBlock.GetLocation()));
            return;
        }

        if (bodyBlock.Statements[0] is not TryStatementSyntax tryCatchStatement)
        {
            // oops, you should have a try block here
            context.ReportDiagnostic(Diagnostic.Create(MissingTryCatchRule, bodyBlock.GetLocation()));
            return;
        }

        CatchClauseSyntax? catchClause = null;
        var hasFilter = false;
        var isSystemException = false;
        var isRethrowing = false;

        foreach (var catchSyntax in tryCatchStatement.Catches)
        {
            catchClause = catchSyntax;
            isSystemException = false;
            isRethrowing = false;

            // check that it's catching _everything_
            hasFilter = catchClause.Filter is not null;
            if (hasFilter)
            {
                // Skipping because we shouldn't be letting anything through
                continue;
            }

            var exceptionTypeName = catchSyntax.Declaration?.Type is { } exceptionType
                                        ? context.SemanticModel.GetSymbolInfo(exceptionType).Symbol?.ToString()
                                        : null;
            isSystemException = exceptionTypeName is null or "System.Exception";
            if (!isSystemException)
            {
                // skipping because it's not broad enough
                continue;
            }

            // final requirement, must not be rethrowing
            foreach (var statement in catchSyntax.Block.Statements)
            {
                if (statement is ThrowStatementSyntax)
                {
                    isRethrowing = true;
                    break;
                }
            }

            // if we get here, we know one of the loops is all good, so we can break
            break;
        }

        if (catchClause is null || hasFilter || !isSystemException || isRethrowing)
        {
            // oops, no good
            var location = catchClause?.GetLocation() ?? tryCatchStatement.GetLocation();
            context.ReportDiagnostic(Diagnostic.Create(MissingTryCatchRule, location));
        }
    }
}
