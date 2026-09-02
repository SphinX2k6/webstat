using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012A0 RID: 4768
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewCollection : ActivitySubViewBase
{
	// Token: 0x17000AD7 RID: 2775
	// (get) Token: 0x06007FB8 RID: 32696 RVA: 0x0021C044 File Offset: 0x0021A244
	// (set) Token: 0x06007FB9 RID: 32697 RVA: 0x0021C04C File Offset: 0x0021A24C
	protected ActivityCollectionData ActivityData { get; set; }

	// Token: 0x17000AD8 RID: 2776
	// (get) Token: 0x06007FBA RID: 32698 RVA: 0x0021C055 File Offset: 0x0021A255
	// (set) Token: 0x06007FBB RID: 32699 RVA: 0x0021C05D File Offset: 0x0021A25D
	private ActivityTitleTypeA TitleComponent { get; set; }

	// Token: 0x17000AD9 RID: 2777
	// (get) Token: 0x06007FBC RID: 32700 RVA: 0x0021C066 File Offset: 0x0021A266
	// (set) Token: 0x06007FBD RID: 32701 RVA: 0x0021C06E File Offset: 0x0021A26E
	private ActivityDescriptionTypeA DescriptionComponent { get; set; }

	// Token: 0x17000ADA RID: 2778
	// (get) Token: 0x06007FBE RID: 32702 RVA: 0x0021C077 File Offset: 0x0021A277
	// (set) Token: 0x06007FBF RID: 32703 RVA: 0x0021C07F File Offset: 0x0021A27F
	private ActivityProgressComponents ProgressComponent { get; set; }

	// Token: 0x17000ADB RID: 2779
	// (get) Token: 0x06007FC0 RID: 32704 RVA: 0x0021C088 File Offset: 0x0021A288
	// (set) Token: 0x06007FC1 RID: 32705 RVA: 0x0021C090 File Offset: 0x0021A290
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17000ADC RID: 2780
	// (get) Token: 0x06007FC2 RID: 32706 RVA: 0x0021C099 File Offset: 0x0021A299
	// (set) Token: 0x06007FC3 RID: 32707 RVA: 0x0021C0A1 File Offset: 0x0021A2A1
	private ActivityFunctionalArea FunctionalComponent { get; set; }

	// Token: 0x17000ADD RID: 2781
	// (get) Token: 0x06007FC4 RID: 32708 RVA: 0x0021C0AA File Offset: 0x0021A2AA
	// (set) Token: 0x06007FC5 RID: 32709 RVA: 0x0021C0B2 File Offset: 0x0021A2B2
	private bool IsQuestLockTimeShow { get; set; }

	// Token: 0x17000ADE RID: 2782
	// (get) Token: 0x06007FC6 RID: 32710 RVA: 0x0021C0BB File Offset: 0x0021A2BB
	// (set) Token: 0x06007FC7 RID: 32711 RVA: 0x0021C0C3 File Offset: 0x0021A2C3
	private long QuestLockTime { get; set; }

	// Token: 0x06007FC8 RID: 32712 RVA: 0x0021C0CC File Offset: 0x0021A2CC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007FC9 RID: 32713 RVA: 0x0021C1B9 File Offset: 0x0021A3B9
	protected override void OnSetData()
	{
		this.ActivityData = (ActivityCollectionData)this.ActivityBaseData;
	}

	// Token: 0x06007FCA RID: 32714 RVA: 0x0021C1CC File Offset: 0x0021A3CC
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewCollection.<OnBeforeStartAsync>d__35 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewCollection.<OnBeforeStartAsync>d__35>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007FCB RID: 32715 RVA: 0x0021C210 File Offset: 0x0021A410
	protected override void OnStart()
	{
		this.TitleComponent.SetActivityBaseData(this.ActivityData);
		this.TitleComponent.SetTitleByText(this.ActivityData.GetTitle());
		this.DescriptionComponent.SetUiActive(false);
		this.RefreshRewardComponent();
		this.OnRefreshView();
	}

	// Token: 0x06007FCC RID: 32716 RVA: 0x0021C25C File Offset: 0x0021A45C
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x06007FCD RID: 32717 RVA: 0x0021C296 File Offset: 0x0021A496
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x06007FCE RID: 32718 RVA: 0x0021C2D0 File Offset: 0x0021A4D0
	private void OnRefreshCommonActivityRedDot(int id)
	{
		if (id == this.ActivityData.Id)
		{
			this.RefreshRedDot();
		}
	}

	// Token: 0x06007FCF RID: 32719 RVA: 0x0021C2E8 File Offset: 0x0021A4E8
	private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason reason)
	{
		ICollectionQuestState collectionQuestState;
		if (this.ActivityData.QuestStateMap.TryGetValue(questId, out collectionQuestState))
		{
			this.RefreshData();
			this.RefreshProgressComponent();
			this.NewQuestCheck();
		}
	}

	// Token: 0x06007FD0 RID: 32720 RVA: 0x0021C31C File Offset: 0x0021A51C
	protected override void OnRefreshView()
	{
		this.RefreshData();
		this.RefreshTimerText();
		this.RefreshProgressComponent();
		this.RefreshFunctionalComponent();
		this.RefreshRedDot();
		this.NewQuestCheck();
	}

	// Token: 0x06007FD1 RID: 32721 RVA: 0x0021C344 File Offset: 0x0021A544
	private void NewQuestCheck()
	{
		if (this.ActivityData.IsHasNewQuestRedDot())
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("CollectionAtivity_NewQuest", null);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(localTextNew);
		}
	}

	// Token: 0x06007FD2 RID: 32722 RVA: 0x0021C375 File Offset: 0x0021A575
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x06007FD3 RID: 32723 RVA: 0x0021C37D File Offset: 0x0021A57D
	private void RefreshData()
	{
		this.ActivityData.RefreshRewardData();
	}

	// Token: 0x06007FD4 RID: 32724 RVA: 0x0021C38C File Offset: 0x0021A58C
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
		if (this.IsQuestLockTimeShow)
		{
			ActivityProgressComponents progressComponent = this.ProgressComponent;
			if (progressComponent == null)
			{
				return;
			}
			progressComponent.SetDescriptionByTextId("CollectionAtivity_AcceptQuestTime", new string[]
			{
				this.GetRemainQuestUnlockTime(this.QuestLockTime)
			});
		}
	}

	// Token: 0x06007FD5 RID: 32725 RVA: 0x0021C3FC File Offset: 0x0021A5FC
	private void RefreshProgressComponent()
	{
		int item = this.ActivityData.GetCurrentProgress().Item1;
		int totalProgress = this.ActivityData.GetTotalProgress();
		int currentProgressQuestId = this.ActivityData.GetCurrentProgressQuestId();
		IQuest questConfig = ModelBase<QuestNewModel>.Instance.GetQuestConfig(currentProgressQuestId);
		string text = (questConfig != null) ? questConfig.TidName : null;
		string descriptionByText = (text != null) ? Singleton<PublicUtil>.Instance.GetConfigTextByKey(text) : "";
		ActivityProgressComponents progressComponent = this.ProgressComponent;
		if (progressComponent != null)
		{
			progressComponent.SetProgressPercent((float)item / ((float)totalProgress * 1f));
		}
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Text_ItemShow_Text", null);
		ActivityProgressComponents progressComponent2 = this.ProgressComponent;
		if (progressComponent2 != null)
		{
			progressComponent2.SetProgressTextByText(StringUtils.Format(localTextNew, new string[]
			{
				item.ToString(),
				totalProgress.ToString()
			}));
		}
		ActivityProgressComponents progressComponent3 = this.ProgressComponent;
		if (progressComponent3 != null)
		{
			progressComponent3.SetTitleByTextId("CollectActivity_schedule", Array.Empty<string>());
		}
		switch (this.ActivityData.GetProgressState())
		{
		case ECollectionState.PreQuest:
		{
			string preShowGuideQuestName = this.ActivityData.GetPreShowGuideQuestName();
			ActivityProgressComponents progressComponent4 = this.ProgressComponent;
			if (progressComponent4 == null)
			{
				return;
			}
			progressComponent4.SetDescriptionByText(preShowGuideQuestName);
			return;
		}
		case ECollectionState.InQuest:
		{
			ICollectionQuestState collectionQuestState;
			this.ActivityData.QuestStateMap.TryGetValue(currentProgressQuestId, out collectionQuestState);
			if (collectionQuestState != null)
			{
				bool flag = (double)collectionQuestState.QuestUnlockStamp - Singleton<TimeUtil>.Instance.GetServerTime() < 0.0;
				if (collectionQuestState.QuestState == 2 || flag)
				{
					ActivityProgressComponents progressComponent5 = this.ProgressComponent;
					if (progressComponent5 != null)
					{
						progressComponent5.SetDescriptionByText(descriptionByText);
					}
					this.IsQuestLockTimeShow = false;
					return;
				}
				this.QuestLockTime = collectionQuestState.QuestUnlockStamp;
				ActivityProgressComponents progressComponent6 = this.ProgressComponent;
				if (progressComponent6 != null)
				{
					progressComponent6.SetDescriptionByTextId("CollectionAtivity_AcceptQuestTime", new string[]
					{
						this.GetRemainQuestUnlockTime(this.QuestLockTime)
					});
				}
				this.IsQuestLockTimeShow = true;
				return;
			}
			break;
		}
		case ECollectionState.Finished:
		{
			ActivityProgressComponents progressComponent7 = this.ProgressComponent;
			if (progressComponent7 == null)
			{
				return;
			}
			progressComponent7.SetDescriptionByTextId("CollectActivity_state_finish", Array.Empty<string>());
			break;
		}
		default:
			return;
		}
	}

	// Token: 0x06007FD6 RID: 32726 RVA: 0x0021C5D8 File Offset: 0x0021A7D8
	[NullableContext(1)]
	private string GetRemainQuestUnlockTime(long endTime)
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double num = Math.Max((double)endTime - serverTime, Singleton<TimeUtil>.Instance.Minute);
		ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> questLockTimeTypeData = this.GetQuestLockTimeTypeData(num);
		CommonDefine.ICountDown countDownDataFormat = Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(questLockTimeTypeData.Item1), new CommonDefine.ETimeType?(questLockTimeTypeData.Item2));
		return ((countDownDataFormat != null) ? countDownDataFormat.CountDownText : null) ?? "";
	}

	// Token: 0x06007FD7 RID: 32727 RVA: 0x0021C642 File Offset: 0x0021A842
	[NullableContext(0)]
	private ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> GetQuestLockTimeTypeData(double remainTime)
	{
		if (remainTime > 86400.0)
		{
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Day, CommonDefine.ETimeType.Hour);
		}
		if (remainTime > 3600.0)
		{
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Hour, CommonDefine.ETimeType.Hour);
		}
		return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Minute, CommonDefine.ETimeType.Minute);
	}

	// Token: 0x06007FD8 RID: 32728 RVA: 0x0021C674 File Offset: 0x0021A874
	private void RefreshRewardComponent()
	{
		List<TItem> previewReward = this.ActivityData.GetPreviewReward(null);
		this.RewardListComponent.SetTitleByTextId("CollectActivity_reward");
		this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
	}

	// Token: 0x06007FD9 RID: 32729 RVA: 0x0021C6D0 File Offset: 0x0021A8D0
	private void RefreshFunctionalComponent()
	{
		bool flag = this.ActivityData.IsUnLock();
		this.FunctionalComponent.SetPanelConditionVisible(!flag);
		if (!flag)
		{
			this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityData.ConditionGroupId, this.ActivityData.Id);
		}
		this.FunctionalComponent.SetRewardButtonVisible(flag);
		if (flag)
		{
			this.FunctionalComponent.SetRewardButtonFunction(new Action(this.OpenRewardPopUp));
		}
		this.FunctionalComponent.FunctionButton.SetUiActive(flag);
		if (flag)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("CollectActivity_Button_ahead", null);
			this.FunctionalComponent.FunctionButton.SetText(localTextNew);
			this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.JumpFunction));
		}
	}

	// Token: 0x06007FDA RID: 32730 RVA: 0x0021C790 File Offset: 0x0021A990
	private void RefreshRedDot()
	{
		bool rewardRedDotVisible = this.ActivityData.IsHasRewardRedPoint();
		this.FunctionalComponent.SetRewardRedDotVisible(rewardRedDotVisible);
		bool redDotVisible = this.ActivityData.IsHasNewQuestRedDot();
		this.FunctionalComponent.FunctionButton.SetRedDotVisible(redDotVisible);
	}

	// Token: 0x06007FDB RID: 32731 RVA: 0x0021C7D2 File Offset: 0x0021A9D2
	[NullableContext(1)]
	public override void PlaySubViewSequence(string name, bool blockClick = false)
	{
		this.RefreshBg();
	}

	// Token: 0x06007FDC RID: 32732 RVA: 0x0021C7DC File Offset: 0x0021A9DC
	private void RefreshBg()
	{
		int item = this.ActivityData.GetCurrentProgress().Item1;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
		defaultInterpolatedStringHandler.AppendLiteral("Shape0");
		defaultInterpolatedStringHandler.AppendFormatted<int>(item);
		string text = defaultInterpolatedStringHandler.ToStringAndClear();
		if (this.LevelSequencePlayer.GetCurrentSequence() == text)
		{
			this.LevelSequencePlayer.ReplaySequenceByKey(text);
			return;
		}
		this.LevelSequencePlayer.PlayLevelSequenceByName(text, false, null, false);
	}

	// Token: 0x06007FDD RID: 32733 RVA: 0x0021C858 File Offset: 0x0021AA58
	private void OpenRewardPopUp()
	{
		IActivityRewardViewData allRewardQuestDataList = this.ActivityData.GetAllRewardQuestDataList();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRewardPopUpView, allRewardQuestDataList, null);
	}

	// Token: 0x06007FDE RID: 32734 RVA: 0x0021C884 File Offset: 0x0021AA84
	private void JumpFunction()
	{
		switch (this.ActivityData.GetProgressState())
		{
		case ECollectionState.PreQuest:
		{
			ActivitySubViewCollection.<>c__DisplayClass55_0 CS$<>8__locals1 = new ActivitySubViewCollection.<>c__DisplayClass55_0();
			CS$<>8__locals1.preGuideQuestId = this.ActivityData.GetUnFinishPreGuideQuestId();
			if (!ModelBase<QuestNewModel>.Instance.IsTrackingQuest(CS$<>8__locals1.preGuideQuestId))
			{
				ControllerBase<QuestNewController>.Instance.RequestTrackQuest(CS$<>8__locals1.preGuideQuestId, true, ERequestTrackOperate.Auto, ESetTrackReason.None, new Action(CS$<>8__locals1.<JumpFunction>g__JumpToQuest|0));
				return;
			}
			CS$<>8__locals1.<JumpFunction>g__JumpToQuest|0();
			return;
		}
		case ECollectionState.InQuest:
		{
			int item = this.ActivityData.GetCurrentProgress().Item1;
			GatherActivity activityCollectionConfig = ConfigBase<ActivityCollectionConfig>.Instance.GetActivityCollectionConfig(item + 1);
			WorldMapViewOpenParams data = new WorldMapViewOpenParams
			{
				MarkId = new int?(activityCollectionConfig.MarkId),
				MarkType = EMarkType.None,
				OpenFogId = new int?(0)
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
			int currentProgressQuestId = this.ActivityData.GetCurrentProgressQuestId();
			ModelBase<ActivityModel>.Instance.SaveActivityData(this.ActivityData.Id, currentProgressQuestId, 0, 0, 0);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityData.Id);
			return;
		}
		case ECollectionState.Finished:
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("CollectActivity_prompt_finish", null);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(localTextNew);
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x0200761A RID: 30234
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028B6F RID: 166767
		public const int TitleItem = 0;

		// Token: 0x04028B70 RID: 166768
		public const int DescriptionItem = 1;

		// Token: 0x04028B71 RID: 166769
		public const int ProgressItem = 2;

		// Token: 0x04028B72 RID: 166770
		public const int RewardListItem = 3;

		// Token: 0x04028B73 RID: 166771
		public const int FunctionArea = 4;

		// Token: 0x04028B74 RID: 166772
		public const int BgView = 5;
	}
}
