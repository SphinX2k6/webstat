using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;

// Token: 0x0200159E RID: 5534
public class ScratchTicketCellData
{
	// Token: 0x06009BAB RID: 39851 RVA: 0x0028BBEF File Offset: 0x00289DEF
	public ScratchTicketCellData(int index)
	{
		this.Index = index;
	}

	// Token: 0x06009BAC RID: 39852 RVA: 0x0028BBFE File Offset: 0x00289DFE
	[NullableContext(1)]
	public void SetRewardItem(ScratchCardRewardData reward)
	{
		this.ItemBase = new TItem?(new TItem(new InventoryDefine.GetItemData(reward.ItemId, 0), reward.Num));
	}

	// Token: 0x06009BAD RID: 39853 RVA: 0x0028BC22 File Offset: 0x00289E22
	public bool IsLock()
	{
		return this.ItemBase == null;
	}

	// Token: 0x06009BAE RID: 39854 RVA: 0x0028BC32 File Offset: 0x00289E32
	public TItem? GetItemData()
	{
		return this.ItemBase;
	}

	// Token: 0x040047B8 RID: 18360
	public readonly int Index;

	// Token: 0x040047B9 RID: 18361
	private TItem? ItemBase;
}
