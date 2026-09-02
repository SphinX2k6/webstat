using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001566 RID: 5478
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ActivityRegressCultivateTaskSubViewLoopItem : GridProxyAbstract<IActivityRegressRoleCultivateSubViewLoopData>
{
	// Token: 0x060099C2 RID: 39362 RVA: 0x002840B0 File Offset: 0x002822B0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x060099C3 RID: 39363 RVA: 0x00284170 File Offset: 0x00282370
	protected override void OnStart()
	{
		this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(2), new Func<CommonItemSmallItemGrid>(this.CreatePropItem), null, false, null);
		UUIItem item = base.GetItem(4);
		this.ButtonItemE = new ButtonItem(item);
		this.ButtonItemE.SetFunction(new Action<int>(this.OnConfirmBtnClick));
		this.ButtonItemE.SetShowText("RecallActivity_Go");
		UUIItem item2 = base.GetItem(6);
		this.ButtonItemB = new ButtonItem(item2);
		this.ButtonItemB.SetShowText("CollectActivity_state_CanRecive");
		this.ButtonItemB.SetFunction(new Action<int>(this.OnConfirmBtnClick));
	}

	// Token: 0x060099C4 RID: 39364 RVA: 0x00284214 File Offset: 0x00282414
	[NullableContext(1)]
	public override void Refresh(IActivityRegressRoleCultivateSubViewLoopData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RefreshName();
		this.RefreshProgress();
		this.RefreshState();
		this.RefreshRewardLayout();
	}

	// Token: 0x060099C5 RID: 39365 RVA: 0x00284238 File Offset: 0x00282438
	private void RefreshName()
	{
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.Data.Config.TargetName, Array.Empty<object>());
	}

	// Token: 0x060099C6 RID: 39366 RVA: 0x00284270 File Offset: 0x00282470
	private void RefreshProgress()
	{
		int id = this.Data.Config.Id;
		ValueTuple<int, int> taskProgressTuple = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTaskProgressTuple(id);
		int item = taskProgressTuple.Item1;
		int item2 = taskProgressTuple.Item2;
		UUIText text = base.GetText(1);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(item);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x060099C7 RID: 39367 RVA: 0x002842E8 File Offset: 0x002824E8
	private void RefreshState()
	{
		int id = this.Data.Config.Id;
		ERegressRewardState taskRewardState = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTaskRewardState(id);
		base.GetItem(7).SetUIActive(false);
		base.GetItem(5).SetUIActive(taskRewardState == ERegressRewardState.Claim);
		this.ButtonItemE.SetUiActive(taskRewardState == ERegressRewardState.UnReach);
		this.ButtonItemB.SetUiActive(taskRewardState == ERegressRewardState.Reached);
	}

	// Token: 0x060099C8 RID: 39368 RVA: 0x00284358 File Offset: 0x00282558
	private void RefreshRewardLayout()
	{
		List<TItem> dropPreviewRewardItemListForPreview = ModelBase<ActivityRegressModel>.Instance.GetDropPreviewRewardItemListForPreview(this.Data.Config.TargetReward);
		this.RewardScrollView.RefreshByData(dropPreviewRewardItemListForPreview, null, false);
	}

	// Token: 0x060099C9 RID: 39369 RVA: 0x00284391 File Offset: 0x00282591
	[NullableContext(1)]
	private CommonItemSmallItemGrid CreatePropItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x060099CA RID: 39370 RVA: 0x00284398 File Offset: 0x00282598
	private void OnConfirmBtnClick(int _)
	{
		RegressQuest config = this.Data.Config;
		ERegressRewardState taskRewardState = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTaskRewardState(config.Id);
		if (taskRewardState == ERegressRewardState.UnReach)
		{
			SkipTaskManager.RunByConfigId(config.AccessPathId, null);
			return;
		}
		if (taskRewardState == ERegressRewardState.Reached)
		{
			ControllerBase<ActivityRegressController>.Instance.RequestClaimTaskReward(config.Id);
		}
	}

	// Token: 0x040046F8 RID: 18168
	private IActivityRegressRoleCultivateSubViewLoopData Data;

	// Token: 0x040046F9 RID: 18169
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x040046FA RID: 18170
	private ButtonItem ButtonItemE;

	// Token: 0x040046FB RID: 18171
	private ButtonItem ButtonItemB;

	// Token: 0x0200792C RID: 31020
	[NullableContext(0)]
	private class EActivityRegressCultivateTaskSubViewLoopItemComponents
	{
		// Token: 0x04029A29 RID: 170537
		public const int TxtName = 0;

		// Token: 0x04029A2A RID: 170538
		public const int TxtNum = 1;

		// Token: 0x04029A2B RID: 170539
		public const int SVRoot = 2;

		// Token: 0x04029A2C RID: 170540
		public const int SVItem = 3;

		// Token: 0x04029A2D RID: 170541
		public const int BtnSecConfirmE2 = 4;

		// Token: 0x04029A2E RID: 170542
		public const int DoneRoot = 5;

		// Token: 0x04029A2F RID: 170543
		public const int BtnSecConfirmB2 = 6;

		// Token: 0x04029A30 RID: 170544
		public const int DoingRoot = 7;
	}
}
