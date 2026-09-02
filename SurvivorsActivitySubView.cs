using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002AC9 RID: 10953
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsActivitySubView : ActivitySubViewBase
{
	// Token: 0x06015E8F RID: 89743 RVA: 0x00616398 File Offset: 0x00614598
	protected override void OnSetData()
	{
		this.ActivityData = (SurvivorsActivityData)this.ActivityBaseData;
	}

	// Token: 0x06015E90 RID: 89744 RVA: 0x006163AC File Offset: 0x006145AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnBtnScore))
		};
	}

	// Token: 0x06015E91 RID: 89745 RVA: 0x00616484 File Offset: 0x00614684
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsActivitySubView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsActivitySubView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015E92 RID: 89746 RVA: 0x006164C8 File Offset: 0x006146C8
	protected override void OnStart()
	{
		Activity? localConfig = this.ActivityData.LocalConfig;
		if (localConfig == null)
		{
			return;
		}
		string descTheme = localConfig.Value.DescTheme;
		bool flag = !StringUtils.IsEmpty(descTheme);
		this.TitleComponent.SetSubTitleVisible(flag);
		if (flag)
		{
			this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
		}
		this.TitleComponent.SetActivityBaseData(this.ActivityData);
		this.TitleComponent.SetTitleByText(this.ActivityData.GetTitle());
		string desc = localConfig.Value.Desc;
		this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
		List<TItem> previewReward = this.ActivityData.GetPreviewReward(null);
		this.RewardListComponent.SetCommonTitle();
		this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
		this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.FunctionExecute));
		this.OnRefreshView();
	}

	// Token: 0x06015E93 RID: 89747 RVA: 0x006165DD File Offset: 0x006147DD
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
	}

	// Token: 0x06015E94 RID: 89748 RVA: 0x006165FB File Offset: 0x006147FB
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
	}

	// Token: 0x06015E95 RID: 89749 RVA: 0x00616619 File Offset: 0x00614819
	private void OnRefreshRedDot(int activityId)
	{
		if (this.ActivityData.Id != activityId)
		{
			return;
		}
		this.RefreshRewardInfo();
		this.RefreshRedDot();
	}

	// Token: 0x06015E96 RID: 89750 RVA: 0x00616636 File Offset: 0x00614836
	protected override void OnRefreshView()
	{
		this.RefreshTimerText();
		this.RefreshRedDot();
		this.RefreshCondition();
	}

	// Token: 0x06015E97 RID: 89751 RVA: 0x0061664A File Offset: 0x0061484A
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x06015E98 RID: 89752 RVA: 0x00616652 File Offset: 0x00614852
	private void RefreshRedDot()
	{
		base.GetItem(6).SetUIActive(this.ActivityData.GetRewardRedDotState());
		this.FunctionalComponent.SetFunctionRedDotVisible(this.ActivityData.GetActivityRedDotState());
	}

	// Token: 0x06015E99 RID: 89753 RVA: 0x00616684 File Offset: 0x00614884
	private void RefreshTimerText()
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.TitleComponent.SetTimeTextVisible(item);
		if (item)
		{
			this.TitleComponent.SetTimeTextByText(item2);
		}
	}

	// Token: 0x06015E9A RID: 89754 RVA: 0x006166C0 File Offset: 0x006148C0
	private void RefreshCondition()
	{
		this.RefreshRewardInfo();
		ActivityFunctionAreaParams parameters = new ActivityFunctionAreaParams
		{
			UnlockBtnFunction = new Action(this.FunctionExecute)
		};
		this.FunctionalComponent.RefreshGeneralPerformance(parameters);
		bool levelUnlockRedDotState = this.ActivityData.GetLevelUnlockRedDotState();
		if (levelUnlockRedDotState)
		{
			this.FunctionalComponent.SetPanelTipByTextId("SurvivorsNewLevelUnlock", Array.Empty<string>());
		}
		this.FunctionalComponent.SetPanelTipVisible(levelUnlockRedDotState);
	}

	// Token: 0x06015E9B RID: 89755 RVA: 0x00616728 File Offset: 0x00614928
	private void RefreshRewardInfo()
	{
		int finishedRewardTaskCount = this.ActivityData.GetFinishedRewardTaskCount();
		int count = this.ActivityData.RewardTaskMap.Count;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "SurvivorsReward", new <>z__ReadOnlyArray<object>(new object[]
		{
			finishedRewardTaskCount,
			count
		}));
	}

	// Token: 0x06015E9C RID: 89756 RVA: 0x00616785 File Offset: 0x00614985
	private void OnBtnScore()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsRogueRewardView, null, delegate(bool success, int viewId)
		{
			if (success && Singleton<UiManager>.Instance.IsViewShow(EUiViewName.CommonActivityView))
			{
				UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CommonActivityView);
				if (viewByName == null)
				{
					return;
				}
				viewByName.AddChildViewById(viewId);
			}
		});
	}

	// Token: 0x06015E9D RID: 89757 RVA: 0x006167B8 File Offset: 0x006149B8
	private void FunctionExecute()
	{
		if (!this.ActivityData.SaveCacheState(ESurvivorsActivitySaveFlags.ActivityOpen, 0, 0, 1))
		{
			this.ActivityData.RefreshActivityRedDot();
		}
		SurvivorsActivityData activityData = this.ActivityData;
		bool? flag = (activityData != null) ? new bool?(activityData.GetPreGuideQuestFinishState()) : null;
		if (flag == null || !flag.Value)
		{
			int unFinishPreGuideQuestId = this.ActivityData.GetUnFinishPreGuideQuestId();
			if (unFinishPreGuideQuestId > 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			}
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsRogueMainView, null, null);
	}

	// Token: 0x0400A858 RID: 43096
	[Nullable(1)]
	private SurvivorsActivityData ActivityData;

	// Token: 0x0400A859 RID: 43097
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x0400A85A RID: 43098
	private ActivityDescriptionTypeA DescriptionComponent;

	// Token: 0x0400A85B RID: 43099
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x0400A85C RID: 43100
	private ActivityFunctionalTypeA FunctionalComponent;

	// Token: 0x02008E34 RID: 36404
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x0402FD51 RID: 195921
		public const int TitleItem = 0;

		// Token: 0x0402FD52 RID: 195922
		public const int DescriptionItem = 1;

		// Token: 0x0402FD53 RID: 195923
		public const int RewardListItem = 2;

		// Token: 0x0402FD54 RID: 195924
		public const int FunctionArea = 3;

		// Token: 0x0402FD55 RID: 195925
		public const int BtnReward = 4;

		// Token: 0x0402FD56 RID: 195926
		public const int TxtReward = 5;

		// Token: 0x0402FD57 RID: 195927
		public const int BtnRewardRedDot = 6;
	}
}
