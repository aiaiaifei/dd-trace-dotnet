//------------------------------------------------------------------------------
// <auto-generated />
// This file was automatically generated by the UpdateVendors tool.
//------------------------------------------------------------------------------
#pragma warning disable CS0618, CS0649, CS1574, CS1580, CS1581, CS1584, CS1591, CS1573, CS8018, SYSLIB0011, SYSLIB0032
#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620, CS8714, CS8762, CS8765, CS8766, CS8767, CS8768, CS8769, CS8612, CS8629, CS8774
// Decompiled with JetBrains decompiler
// Type: System.Reflection.Metadata.LocalScope
// Assembly: System.Reflection.Metadata, Version=7.0.0.2, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: 2EB35F4B-CF50-496F-AFB8-CC6F6F79CB72


#nullable enable
namespace Datadog.Trace.VendoredMicrosoftCode.System.Reflection.Metadata
{
  /// <summary>
  /// Scope of local variables and constants. Stored in debug metadata.
  /// </summary>
  /// <remarks>
  /// See https://github.com/dotnet/runtime/blob/main/src/libraries/System.Reflection.Metadata/specs/PortablePdb-Metadata.md#localscope-table-0x32.
  /// </remarks>
  internal readonly struct LocalScope
  {

    #nullable disable
    private readonly MetadataReader _reader;
    private readonly int _rowId;


    #nullable enable
    internal LocalScope(MetadataReader reader, LocalScopeHandle handle)
    {
      this._reader = reader;
      this._rowId = handle.RowId;
    }

    private LocalScopeHandle Handle => LocalScopeHandle.FromRowId(this._rowId);

    public MethodDefinitionHandle Method => this._reader.LocalScopeTable.GetMethod(this._rowId);

    public ImportScopeHandle ImportScope => this._reader.LocalScopeTable.GetImportScope(this.Handle);

    public int StartOffset => this._reader.LocalScopeTable.GetStartOffset(this._rowId);

    public int Length => this._reader.LocalScopeTable.GetLength(this._rowId);

    public int EndOffset => this._reader.LocalScopeTable.GetEndOffset(this._rowId);

    public LocalVariableHandleCollection GetLocalVariables() => new LocalVariableHandleCollection(this._reader, this.Handle);

    public LocalConstantHandleCollection GetLocalConstants() => new LocalConstantHandleCollection(this._reader, this.Handle);

    public LocalScopeHandleCollection.ChildrenEnumerator GetChildren() => new LocalScopeHandleCollection.ChildrenEnumerator(this._reader, this._rowId);
  }
}