using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001536 RID: 5430
public class RegressBpRewardTabView : UiTabViewBase, IRegressBpTabView
{
	// Token: 0x06009840 RID: 38976 RVA: 0x0027DB10 File Offset: 0x0027BD10
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnPay))
		};
	}

	// Token: 0x06009841 RID: 38977 RVA: 0x0027DBBC File Offset: 0x0027BDBC
	protected override UniTask OnBeforeStartAsync()
	{
		RegressBpRewardTabView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RegressBpRewardTabView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009842 RID: 38978 RVA: 0x0027DBFF File Offset: 0x0027BDFF
	protected override void OnBeforeShow()
	{
		this.RefreshView(true);
	}

	// Token: 0x06009843 RID: 38979 RVA: 0x0027DC08 File Offset: 0x0027BE08
	[NullableContext(1)]
	public void RefreshBtnClaimVisible(UUIItem uiItem)
	{
		uiItem.SetUIActive(ModelBase<ActivityRegressModel>.Instance.ActivityData.CheckRegressScoreRewardReached());
	}

	// Token: 0x06009844 RID: 38980 RVA: 0x0027DC1F File Offset: 0x0027BE1F
	public void OnClickBtnClaimAll()
	{
		ControllerBase<ActivityRegressController>.Instance.RequestAllTaskScoreRewards();
	}

	// Token: 0x06009845 RID: 38981 RVA: 0x0027DC2B File Offset: 0x0027BE2B
	[NullableContext(1)]
	private RegressBpRewardItem OnCreateRewardItem()
	{
		return new RegressBpRewardItem();
	}

	// Token: 0x06009846 RID: 38982 RVA: 0x0027DC34 File Offset: 0x0027BE34
	public void RefreshView(bool playAnim = false)
	{
		if (this.LoopScrollView == null)
		{
			return;
		}
		List<ActivityRegressTaskScoreRewardGridData> regressMainTaskScoreRewardGridDataArr = ModelBase<ActivityRegressModel>.Instance.GetRegressMainTaskScoreRewardGridDataArr();
		regressMainTaskScoreRewardGridDataArr.Sort((ActivityRegressTaskScoreRewardGridData a, ActivityRegressTaskScoreRewardGridData b) => a.Config.Value.NeedScore - b.Config.Value.NeedScore);
		this.LoopScrollView.RefreshByData(regressMainTaskScoreRewardGridDataArr, false, null, playAnim);
		this.RefreshStageReward(true);
		base.GetSprite(0).SetUIActive(!ModelBase<ActivityRegressModel>.Instance.ActivityData.IsPayRewardUnlock());
		base.GetButton(4).SetSelfInteractive(!ModelBase<ActivityRegressModel>.Instance.ActivityData.IsPayRewardUnlock());
	}

	// Token: 0x06009847 RID: 38983 RVA: 0x0027DCCC File Offset: 0x0027BECC
	private void OnScrollViewScrollValueChanged()
	{
		this.RefreshStageReward(false);
	}

	// Token: 0x06009848 RID: 38984 RVA: 0x0027DCD8 File Offset: 0x0027BED8
	private void RefreshStageReward(bool forceRefresh = false)
	{
		int endGridIndex = this.LoopScrollView.EndGridIndex;
		int num = (int)(Math.Ceiling((double)endGridIndex / 10.0) * 10.0 - 1.0);
		ActivityRegressTaskScoreRewardGridData activityRegressTaskScoreRewardGridData = this.LoopScrollView.TryGetCachedData(num);
		if (activityRegressTaskScoreRewardGridData == null)
		{
			num = endGridIndex;
			activityRegressTaskScoreRewardGridData = this.LoopScrollView.TryGetCachedData(num);
		}
		if (this.StageRewardView.GridIndex == num && !forceRefresh)
		{
			return;
		}
		this.StageRewardView.GridIndex = num;
		this.StageRewardView.Refresh(activityRegressTaskScoreRewardGridData, false, this.StageRewardView.GridIndex);
	}

	// Token: 0x06009849 RID: 38985 RVA: 0x0027DD6D File Offset: 0x0027BF6D
	private void OnClickBtnPay()
	{
		ModelBase<ActivityRegressModel>.Instance.ActivityData.SetBpPayButtonRedDotChecked();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RegressBpPayView, null, delegate(bool success, int viewId)
		{
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.ActivityRegressMainView);
			if (viewByName == null)
			{
				return;
			}
			viewByName.AddChildViewById(viewId);
		});
	}

	// Token: 0x04004682 RID: 18050
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<RegressBpRewardItem, ActivityRegressTaskScoreRewardGridData> LoopScrollView;

	// Token: 0x04004683 RID: 18051
	[Nullable(2)]
	private RegressBpRewardItem StageRewardView;

	// Token: 0x020078E9 RID: 30953
	private class EComponents
	{
		// Token: 0x040298F1 RID: 170225
		public const int SpriteLock = 0;

		// Token: 0x040298F2 RID: 170226
		public const int RewardScroll = 1;

		// Token: 0x040298F3 RID: 170227
		public const int Item = 2;

		// Token: 0x040298F4 RID: 170228
		public const int StageRewardItem = 3;

		// Token: 0x040298F5 RID: 170229
		public const int BtnPay = 4;
	}
}
