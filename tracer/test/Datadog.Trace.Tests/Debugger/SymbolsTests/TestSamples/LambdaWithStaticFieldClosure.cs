// <copyright file="LambdaWithStaticFieldClosure.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;

namespace Datadog.Trace.Tests.Debugger.SymbolsTests.TestSamples
{
    internal class LambdaWithStaticFieldClosure
    {
        private static int i;

        public LambdaWithStaticFieldClosure()
        {
            i = new Random().Next();
        }

        private void Foo()
        {
            int rand = new Random().Next();

            Action action = () =>
            {
                var s = new Random().Next();
                Console.WriteLine(s + i);
            };

            action();
        }
    }
}
