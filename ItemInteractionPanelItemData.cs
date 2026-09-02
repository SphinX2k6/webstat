using System;
using System.Runtime.CompilerServices;

// Token: 0x02001976 RID: 6518
public class ItemInteractionPanelItemData
{
	// Token: 0x0600BB56 RID: 47958 RVA: 0x0031C394 File Offset: 0x0031A594
	[NullableContext(1)]
	public ItemInteractionPanelItemData(IItemInteractionPanelItemInfo itemInfo, int quality)
	{
		this.ItemConfigId = itemInfo.ItemConfigId;
		this.CurrentCount = itemInfo.CurrentCount;
		int? needCount = itemInfo.NeedCount;
		if (needCount != null)
		{
			this.NeedCount = needCount.Value;
		}
		this.QualityId = quality;
		this.ItemCount = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ItemConfigId, 0);
	}

	// Token: 0x0600BB57 RID: 47959 RVA: 0x0031C3FA File Offset: 0x0031A5FA
	public void SetCurrentCount(int count)
	{
		this.CurrentCount = count;
	}

	// Token: 0x0600BB58 RID: 47960 RVA: 0x0031C403 File Offset: 0x0031A603
	public int GetCurrentCount()
	{
		return this.CurrentCount;
	}

	// Token: 0x0600BB59 RID: 47961 RVA: 0x0031C40B File Offset: 0x0031A60B
	public int GetItemCount()
	{
		return this.ItemCount;
	}

	// Token: 0x0600BB5A RID: 47962 RVA: 0x0031C413 File Offset: 0x0031A613
	public bool IsEnable()
	{
		return this.ItemCount >= this.NeedCount;
	}

	// Token: 0x0600BB5B RID: 47963 RVA: 0x0031C426 File Offset: 0x0031A626
	public int GetQualityId()
	{
		return this.QualityId;
	}

	// Token: 0x04005878 RID: 22648
	public readonly int ItemConfigId;

	// Token: 0x04005879 RID: 22649
	private int CurrentCount;

	// Token: 0x0400587A RID: 22650
	private readonly int ItemCount;

	// Token: 0x0400587B RID: 22651
	private readonly int QualityId;

	// Token: 0x0400587C RID: 22652
	public int NeedCount;

	// Token: 0x0400587D RID: 22653
	public bool IsSelected;
}
