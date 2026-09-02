using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;

// Token: 0x020015E0 RID: 5600
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ActivityTowerGuideRewardGrid : LoopScrollSmallItemGrid<ITowerGuideRewardItem>
{
	// Token: 0x06009D90 RID: 40336 RVA: 0x00293D7C File Offset: 0x00291F7C
	protected override void OnRefresh(ITowerGuideRewardItem data, bool isSelected, int gridIndex)
	{
		this.ItemConfigId = data.Item.ItemData.ItemId;
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = data,
			IsLockVisible = new bool?(data.IsLock),
			BottomText = data.Item.Count.ToString(),
			ItemConfigId = new int?(data.Item.ItemData.ItemId),
			IsDisable = new bool?(data.IsLock),
			IsReceivableVisible = new bool?(data.IsReceivableVisible)
		};
		base.Apply<PropSmallItemGrid>(parameters);
		base.SetDisableComponentColor("365988", data.IsLock);
		this.SetSelected(false, false);
	}

	// Token: 0x06009D91 RID: 40337 RVA: 0x00293E33 File Offset: 0x00292033
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x06009D92 RID: 40338 RVA: 0x00293E3D File Offset: 0x0029203D
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, false);
	}

	// Token: 0x06009D93 RID: 40339 RVA: 0x00293E47 File Offset: 0x00292047
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x06009D94 RID: 40340 RVA: 0x00293E4A File Offset: 0x0029204A
	protected override void OnExtendToggleClicked()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemConfigId, true, null);
	}

	// Token: 0x04004894 RID: 18580
	private int ItemConfigId;
}
