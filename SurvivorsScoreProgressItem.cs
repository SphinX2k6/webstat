using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002B28 RID: 11048
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsScoreProgressItem : GridProxyAbstract<SurvivorsMilestoneData>
{
	// Token: 0x060160DE RID: 90334 RVA: 0x0061EC18 File Offset: 0x0061CE18
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x060160DF RID: 90335 RVA: 0x0061EC74 File Offset: 0x0061CE74
	protected override void OnStart()
	{
		this.RewardItemGrid = new SmallItemGrid();
		this.RewardItemGrid.Initialize(base.GetItem(2).GetOwner());
		this.RewardItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		this.RewardItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedGrid));
	}

	// Token: 0x060160E0 RID: 90336 RVA: 0x0061ECE4 File Offset: 0x0061CEE4
	public override void Refresh(SurvivorsMilestoneData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
		int num = (activityData != null) ? activityData.GetMilestoneItemCount() : 0;
		base.GetText(1).SetText(data.Goal.ToString(), true);
		base.GetSprite(0).SetUIActive(data.IsAchieved(num));
		List<TItem> dropPackagePreviewItemList = ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(data.DropId);
		this.RewardItem = new TItem?(dropPackagePreviewItemList[0]);
		this.RefreshGrid(num);
	}

	// Token: 0x060160E1 RID: 90337 RVA: 0x0061ED64 File Offset: 0x0061CF64
	private void RefreshGrid(int currentCount)
	{
		bool lockBlackVisible = !this.Data.IsAchieved(currentCount);
		bool value = this.Data.IsReceivable(currentCount);
		bool isGot = this.Data.IsGot;
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = this.Data,
			ItemConfigId = new int?(this.RewardItem.Value.ItemData.ItemId),
			BottomText = this.RewardItem.Value.Count.ToString(),
			IsReceivableVisible = new bool?(value),
			IsReceivedVisible = new bool?(isGot),
			IsRedDotVisible = new bool?(value)
		};
		this.RewardItemGrid.Apply<PropSmallItemGrid>(parameters);
		this.RewardItemGrid.SetLockBlackVisible(lockBlackVisible);
	}

	// Token: 0x060160E2 RID: 90338 RVA: 0x0061EE28 File Offset: 0x0061D028
	private void OnClickedGrid(MediumItemGridExtendCallback _)
	{
		SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
		int currentPoint = (activityData != null) ? activityData.GetMilestoneItemCount() : 0;
		if (!this.Data.IsReceivable(currentPoint))
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.RewardItem.Value.ItemData.ItemId, true, null);
			return;
		}
		Action onClickToGet = this.OnClickToGet;
		if (onClickToGet == null)
		{
			return;
		}
		onClickToGet();
	}

	// Token: 0x060160E3 RID: 90339 RVA: 0x0061EE8C File Offset: 0x0061D08C
	public override object GetKey(SurvivorsMilestoneData data, int displayIndex)
	{
		return data.DropId;
	}

	// Token: 0x0400A9B4 RID: 43444
	private SurvivorsMilestoneData Data;

	// Token: 0x0400A9B5 RID: 43445
	[Nullable(2)]
	private SmallItemGrid RewardItemGrid;

	// Token: 0x0400A9B6 RID: 43446
	private TItem? RewardItem;

	// Token: 0x0400A9B7 RID: 43447
	[Nullable(2)]
	public Action OnClickToGet;
}
