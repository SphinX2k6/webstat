using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02002075 RID: 8309
public struct TItem : IEquatable<TItem>
{
	// Token: 0x0600FD3E RID: 64830 RVA: 0x004578A6 File Offset: 0x00455AA6
	[NullableContext(1)]
	public TItem(InventoryDefine.IGetItemData itemData, int count)
	{
		this.ItemData = itemData;
		this.Count = count;
	}

	// Token: 0x0600FD3F RID: 64831 RVA: 0x004578B8 File Offset: 0x00455AB8
	public readonly bool Equals(TItem other)
	{
		return this.ItemData.ItemId == other.ItemData.ItemId && this.ItemData.IncId == other.ItemData.IncId && this.Count == other.Count;
	}

	// Token: 0x0600FD40 RID: 64832 RVA: 0x00457905 File Offset: 0x00455B05
	public override readonly int GetHashCode()
	{
		return HashCode.Combine<int, int, int>(this.ItemData.ItemId, this.ItemData.IncId, this.Count);
	}

	// Token: 0x0600FD41 RID: 64833 RVA: 0x00457928 File Offset: 0x00455B28
	[NullableContext(2)]
	public override readonly bool Equals(object obj)
	{
		if (obj is TItem)
		{
			TItem other = (TItem)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x0600FD42 RID: 64834 RVA: 0x0045794D File Offset: 0x00455B4D
	public static bool operator ==(TItem left, TItem right)
	{
		return left.Equals(right);
	}

	// Token: 0x0600FD43 RID: 64835 RVA: 0x00457957 File Offset: 0x00455B57
	public static bool operator !=(TItem left, TItem right)
	{
		return !left.Equals(right);
	}

	// Token: 0x04007994 RID: 31124
	[Nullable(1)]
	public InventoryDefine.IGetItemData ItemData;

	// Token: 0x04007995 RID: 31125
	public int Count;
}
