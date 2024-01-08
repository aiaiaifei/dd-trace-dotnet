//------------------------------------------------------------------------------
// <auto-generated />
// This file was automatically generated by the UpdateVendors tool.
//------------------------------------------------------------------------------
#pragma warning disable CS0618, CS0649, CS1574, CS1580, CS1581, CS1584, CS1591, CS1573, CS8018, SYSLIB0011, SYSLIB0032
#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620, CS8714, CS8762, CS8765, CS8766, CS8767, CS8768, CS8769, CS8612, CS8629, CS8774
#nullable enable
// Decompiled with JetBrains decompiler
// Type: System.Reflection.Metadata.Ecma335.FieldMarshalTableReader
// Assembly: System.Reflection.Metadata, Version=7.0.0.2, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: 2EB35F4B-CF50-496F-AFB8-CC6F6F79CB72

using Datadog.Trace.VendoredMicrosoftCode.System.Reflection.Internal;

namespace Datadog.Trace.VendoredMicrosoftCode.System.Reflection.Metadata.Ecma335
{
  internal readonly struct FieldMarshalTableReader
  {
    internal readonly int NumberOfRows;
    private readonly bool _IsHasFieldMarshalRefSizeSmall;
    private readonly bool _IsBlobHeapRefSizeSmall;
    private readonly int _ParentOffset;
    private readonly int _NativeTypeOffset;
    internal readonly int RowSize;
    internal readonly MemoryBlock Block;

    internal FieldMarshalTableReader(
      int numberOfRows,
      bool declaredSorted,
      int hasFieldMarshalRefSize,
      int blobHeapRefSize,
      MemoryBlock containingBlock,
      int containingBlockOffset)
    {
      this.NumberOfRows = numberOfRows;
      this._IsHasFieldMarshalRefSizeSmall = hasFieldMarshalRefSize == 2;
      this._IsBlobHeapRefSizeSmall = blobHeapRefSize == 2;
      this._ParentOffset = 0;
      this._NativeTypeOffset = this._ParentOffset + hasFieldMarshalRefSize;
      this.RowSize = this._NativeTypeOffset + blobHeapRefSize;
      this.Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, this.RowSize * numberOfRows);
      if (declaredSorted || this.CheckSorted())
        return;
      Throw.TableNotSorted(TableIndex.FieldMarshal);
    }

    internal EntityHandle GetParent(int rowId) => HasFieldMarshalTag.ConvertToHandle(this.Block.PeekTaggedReference((rowId - 1) * this.RowSize + this._ParentOffset, this._IsHasFieldMarshalRefSizeSmall));

    internal BlobHandle GetNativeType(int rowId) => BlobHandle.FromOffset(this.Block.PeekHeapReference((rowId - 1) * this.RowSize + this._NativeTypeOffset, this._IsBlobHeapRefSizeSmall));

    internal int FindFieldMarshalRowId(EntityHandle handle) => this.Block.BinarySearchReference(this.NumberOfRows, this.RowSize, this._ParentOffset, HasFieldMarshalTag.ConvertToTag(handle), this._IsHasFieldMarshalRefSizeSmall) + 1;

    private bool CheckSorted() => this.Block.IsOrderedByReferenceAscending(this.RowSize, this._ParentOffset, this._IsHasFieldMarshalRefSizeSmall);
  }
}