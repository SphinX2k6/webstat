using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200139D RID: 5021
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewMoonChasing : ActivitySubViewBase
{
	// Token: 0x17000BC1 RID: 3009
	// (get) Token: 0x06008A2F RID: 35375 RVA: 0x0024629E File Offset: 0x0024449E
	protected new ActivityMoonChasingData ActivityBaseData
	{
		get
		{
			return this.ActivityBaseData as ActivityMoonChasingData;
		}
	}

	// Token: 0x06008A30 RID: 35376 RVA: 0x002462AC File Offset: 0x002444AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
	}

	// Token: 0x06008A31 RID: 35377 RVA: 0x002463A1 File Offset: 0x002445A1
	protected override void OnSetData()
	{
	}

	// Token: 0x06008A32 RID: 35378 RVA: 0x002463A4 File Offset: 0x002445A4
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewMoonChasing.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewMoonChasing.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008A33 RID: 35379 RVA: 0x002463E8 File Offset: 0x002445E8
	protected override void OnStart()
	{
		Activity? localConfig = this.ActivityBaseData.LocalConfig;
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
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		string desc = localConfig.Value.Desc;
		this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
		List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
		this.RewardListComponent.SetActive(previewReward.Count > 0);
		this.RewardListComponent.SetTitleByTextId("CollectActivity_reward");
		this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
		base.GetItem(4).SetUIActive(false);
		this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.JumpFunction));
		this.QuestPanelTips.SetActive(false);
		this.QuestPanelTips.SetRewardButtonFunction(new Action(this.PreStageQuestJump));
	}

	// Token: 0x06008A34 RID: 35380 RVA: 0x00246541 File Offset: 0x00244741
	protected override void OnRefreshView()
	{
		this.RefreshFunctionalComponent();
		this.RefreshQuestTips();
		this.RefreshButton();
		this.RefreshRedDot();
	}

	// Token: 0x06008A35 RID: 35381 RVA: 0x0024655B File Offset: 0x0024475B
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x06008A36 RID: 35382 RVA: 0x00246563 File Offset: 0x00244763
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x06008A37 RID: 35383 RVA: 0x00246581 File Offset: 0x00244781
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x06008A38 RID: 35384 RVA: 0x002465A0 File Offset: 0x002447A0
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		UUIItem guideUiItem = base.GetGuideUiItem("0");
		if (guideUiItem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			guideUiItem,
			guideUiItem
		};
	}

	// Token: 0x06008A39 RID: 35385 RVA: 0x002465CC File Offset: 0x002447CC
	private void OnRefreshCommonActivityRedDot(int id)
	{
		if (id == this.ActivityBaseData.Id)
		{
			this.RefreshRedDot();
		}
	}

	// Token: 0x06008A3A RID: 35386 RVA: 0x002465E4 File Offset: 0x002447E4
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

	// Token: 0x06008A3B RID: 35387 RVA: 0x00246620 File Offset: 0x00244820
	private void RefreshQuestTips()
	{
		bool flag = this.ActivityBaseData.IsPreStageQuestFinished();
		bool preGuideQuestFinishState = this.ActivityBaseData.GetPreGuideQuestFinishState();
		this.QuestPanelTips.SetActive(!flag && !preGuideQuestFinishState);
		if (flag)
		{
			return;
		}
		TrackMoonActivity? activityMoonChasingConfig = ConfigBase<ActivityMoonChasingConfig>.Instance.GetActivityMoonChasingConfig(this.ActivityBaseData.Id);
		this.QuestPanelTips.SetContentByTextId(activityMoonChasingConfig.Value.StageQuestTips, Array.Empty<string>());
	}

	// Token: 0x06008A3C RID: 35388 RVA: 0x00246694 File Offset: 0x00244894
	private void RefreshButton()
	{
		int handbookUnlockCount = ModelBase<MoonChasingModel>.Instance.GetHandbookUnlockCount();
		int count = ModelBase<MoonChasingBuildingModel>.Instance.GetAllBuildingData().Count;
		this.HandbookBtn.SetText(handbookUnlockCount.ToString() + "/" + count.ToString());
		int targetTotalCount = ModelBase<MoonChasingRewardModel>.Instance.TargetTotalCount;
		int num = Math.Min(targetTotalCount, ModelBase<MoonChasingRewardModel>.Instance.TargetGetCount);
		this.RewardBtn.SetText(num.ToString() + "/" + targetTotalCount.ToString());
	}

	// Token: 0x06008A3D RID: 35389 RVA: 0x0024671E File Offset: 0x0024491E
	private void PreStageQuestJump()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.ActivityBaseData.GetPreStageQuestId(), null);
	}

	// Token: 0x06008A3E RID: 35390 RVA: 0x00246740 File Offset: 0x00244940
	private void RefreshFunctionalComponent()
	{
		bool flag = this.ActivityBaseData.IsUnLock();
		bool preGuideQuestFinishState = this.ActivityBaseData.GetPreGuideQuestFinishState();
		EMoonChasingActivityFlow activityFlowState = this.ActivityBaseData.ActivityFlowState;
		this.FunctionalComponent.SetPanelConditionVisible(!flag);
		if (!flag)
		{
			this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
		}
		this.FunctionalComponent.SetRewardButtonVisible(false);
		base.GetItem(6).SetUIActive(false);
		this.RewardBtn.SetActive(this.ActivityBaseData.PermanentTargetOn && flag && preGuideQuestFinishState);
		this.HandbookBtn.SetActive(flag && preGuideQuestFinishState && activityFlowState == EMoonChasingActivityFlow.Activity);
		this.FunctionalComponent.FunctionButton.SetUiActive(flag);
		string showText = "Moonfiesta_Skip";
		if (activityFlowState == EMoonChasingActivityFlow.Close)
		{
			showText = "Moonfiesta_Memory";
		}
		else if (!preGuideQuestFinishState)
		{
			showText = "JumpToQuestText";
		}
		this.FunctionalComponent.FunctionButton.SetShowText(showText);
	}

	// Token: 0x06008A3F RID: 35391 RVA: 0x0024682B File Offset: 0x00244A2B
	private void RefreshRedDot()
	{
		this.FunctionalComponent.FunctionButton.SetRedDotVisible(this.ActivityBaseData.IsHasMoonChasingRedDot());
		this.HandbookBtn.BindRedDot(ERedDotName.MoonChasingHandbook, 0);
		this.RewardBtn.BindRedDot(ERedDotName.MoonChasingRewardAndShop, 0);
	}

	// Token: 0x06008A40 RID: 35392 RVA: 0x0024686C File Offset: 0x00244A6C
	private void SkipToReward()
	{
		if (this.ActivityBaseData.PermanentTargetOn)
		{
			bool canAccomplishTask = this.ActivityBaseData.ActivityFlowState == EMoonChasingActivityFlow.Activity;
			ControllerBase<MoonChasingController>.Instance.OpenRewardView(canAccomplishTask);
		}
	}

	// Token: 0x06008A41 RID: 35393 RVA: 0x002468A0 File Offset: 0x00244AA0
	private void SkipToHandbook()
	{
		ControllerBase<MoonChasingController>.Instance.OpenHandbookView();
	}

	// Token: 0x06008A42 RID: 35394 RVA: 0x002468AC File Offset: 0x00244AAC
	protected void OpenRewardPopUp()
	{
		if (!this.ActivityBaseData.LimitTimeRewardOn)
		{
			return;
		}
		IActivityRewardViewData allRewardData = this.ActivityBaseData.GetAllRewardData();
		if (allRewardData == null)
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRewardPopUpView, allRewardData, null);
	}

	// Token: 0x06008A43 RID: 35395 RVA: 0x002468E8 File Offset: 0x00244AE8
	private void JumpFunction()
	{
		if (this.ActivityBaseData.ActivityFlowState == EMoonChasingActivityFlow.Close)
		{
			ControllerBase<MoonChasingController>.Instance.OpenMemoryEntranceView();
			return;
		}
		if (this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			TrackMoonActivity? activityMoonChasingConfig = ConfigBase<ActivityMoonChasingConfig>.Instance.GetActivityMoonChasingConfig(this.ActivityBaseData.Id);
			WorldMapViewOpenParams data = new WorldMapViewOpenParams
			{
				MarkId = new int?(activityMoonChasingConfig.Value.FocusMarkId),
				MarkType = EMarkType.SmallTeleport
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
			return;
		}
		if (!this.ActivityBaseData.IsPreStageQuestFinished())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MoonChasingJumpPreQuest);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.ActivityBaseData.GetUnFinishPreGuideQuestId(), null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.ActivityBaseData.GetUnFinishPreGuideQuestId(), null);
	}

	// Token: 0x040040C7 RID: 16583
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x040040C8 RID: 16584
	private ActivityDescriptionTypeA DescriptionComponent;

	// Token: 0x040040C9 RID: 16585
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x040040CA RID: 16586
	private ActivityFunctionalArea FunctionalComponent;

	// Token: 0x040040CB RID: 16587
	private ActivityQuestTipsItem QuestPanelTips;

	// Token: 0x040040CC RID: 16588
	private ButtonItem HandbookBtn;

	// Token: 0x040040CD RID: 16589
	private ButtonItem RewardBtn;

	// Token: 0x0200774A RID: 30538
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029134 RID: 168244
		public const int TitleItem = 0;

		// Token: 0x04029135 RID: 168245
		public const int DescriptionItem = 1;

		// Token: 0x04029136 RID: 168246
		public const int RewardListItem = 2;

		// Token: 0x04029137 RID: 168247
		public const int FunctionArea = 3;

		// Token: 0x04029138 RID: 168248
		public const int PermanentTargetItem = 4;

		// Token: 0x04029139 RID: 168249
		public const int PermanentButton = 5;

		// Token: 0x0402913A RID: 168250
		public const int PermanentButtonRedDot = 6;

		// Token: 0x0402913B RID: 168251
		public const int QuestPanelTips = 7;

		// Token: 0x0402913C RID: 168252
		public const int ButtonReward = 8;

		// Token: 0x0402913D RID: 168253
		public const int ButtonHandbook = 9;
	}
}
