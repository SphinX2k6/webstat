using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02001742 RID: 5954
[NullableContext(2)]
[Nullable(0)]
public class AdventureTargetRewardItem : LoopScrollMediumItemGrid<TItem>
{
	// Token: 0x0600A75B RID: 42843 RVA: 0x002C7ACA File Offset: 0x002C5CCA
	protected override void OnStart()
	{
		base.SetUseFixedAsync(true);
	}

	// Token: 0x0600A75C RID: 42844 RVA: 0x002C7AD4 File Offset: 0x002C5CD4
	protected override void OnRefresh(TItem data, bool isSelected, int gridIndex)
	{
		this.SetSelected(isSelected, false);
		int itemId = data.ItemData.ItemId;
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
		if (itemConfigData == null)
		{
			return;
		}
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = data,
			IsOmitBottomText = new bool?(true),
			BottomText = data.Count.ToString(),
			ItemConfigId = new int?(itemId),
			StarLevel = new int?(itemConfigData.QualityId)
		};
		base.Apply<PropMediumItemGrid>(parameters);
	}

	// Token: 0x0600A75D RID: 42845 RVA: 0x002C7B59 File Offset: 0x002C5D59
	public void OnForceSelected()
	{
		this.SetSelected(true, true);
	}

	// Token: 0x0600A75E RID: 42846 RVA: 0x002C7B63 File Offset: 0x002C5D63
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x0600A75F RID: 42847 RVA: 0x002C7B6D File Offset: 0x002C5D6D
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x04004EFF RID: 20223
	public Func<int, int> GetRolePositionFunc;

	// Token: 0x04004F00 RID: 20224
	public Func<int, bool> IsHighlightIndex;
}
