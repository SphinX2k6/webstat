using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.UiNavigation;
using CSharpScript.Game.Module.UiNavigation.UIComponent;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AA8 RID: 6824
[NullableContext(1)]
[Nullable(0)]
public class DailyActivityView : UiTabViewBase
{
	// Token: 0x0600C373 RID: 50035 RVA: 0x00338204 File Offset: 0x00336404
	protected unsafe override void OnRegisterComponent()
	{
		int num = 17;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C374 RID: 50036 RVA: 0x00338468 File Offset: 0x00336668
	protected override UniTask OnBeforeStartAsync()
	{
		DailyActivityView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DailyActivityView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C375 RID: 50037 RVA: 0x003384AC File Offset: 0x003366AC
	protected override void OnStart()
	{
		this.TaskLoopView = new LoopScrollView<DailyActivityTaskItem, DailyActiveTaskData>(base.GetLoopScrollViewComponent(0), (AUIBaseActor)base.GetItem(1).GetOwner(), new Func<DailyActivityTaskItem>(this.CreateDailyTaskItem), false);
		this.MainTabLayout = new GenericLayout<DailyActivityMainTabItem, DailyActivityDefine.IDailyActivityMainTabData>(base.GetHorizontalLayout(5), new Func<DailyActivityMainTabItem>(this.CreateMainTabItem), (AUIBaseActor)base.GetItem(6).GetOwner(), false, true);
		this.WeeklyChallengeLoopView = new LoopScrollView<WeeklyChallengeItem, WeeklyChallengeTaskData>(base.GetLoopScrollViewComponent(7), (AUIBaseActor)base.GetItem(8).GetOwner(), new Func<WeeklyChallengeItem>(this.CreateWeeklyChallengeItem), true);
		this.StartLevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.RewardPopup = new CommonRewardPopup(this.RootItem);
	}

	// Token: 0x0600C376 RID: 50038 RVA: 0x0033856C File Offset: 0x0033676C
	protected override void OnBeforeDestroy()
	{
		DailyActivityRewardPanel dailyPanelProgress = this.DailyPanelProgress;
		if (dailyPanelProgress != null)
		{
			dailyPanelProgress.Destroy(null);
		}
		this.DailyPanelProgress = null;
		DailyActivityRewardPanel weeklyPanelProgress = this.WeeklyPanelProgress;
		if (weeklyPanelProgress != null)
		{
			weeklyPanelProgress.Destroy(null);
		}
		this.WeeklyPanelProgress = null;
		LevelSequencePlayer startLevelSequencePlayer = this.StartLevelSequencePlayer;
		if (startLevelSequencePlayer != null)
		{
			startLevelSequencePlayer.Clear();
		}
		this.StartLevelSequencePlayer = null;
		this.RewardPopup = null;
		this.TaskDataList = new List<DailyActiveTaskData>();
		this.WeeklyTaskDataList = new List<WeeklyChallengeTaskData>();
	}

	// Token: 0x0600C377 RID: 50039 RVA: 0x003385E0 File Offset: 0x003367E0
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.DailyActivityRefresh, new Action(this.OnDailyActivityRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.DailyActivityTaskUpdate, new Action(this.OnDailyTaskChangeRefresh));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.DailyActivityValueChange, new Action<int>(this.OnDailyValueChange));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.DailyActivityRewardTake, new Action<IReadOnlyList<int>>(this.OnDailyRewardTake));
		Singleton<EventSystem>.Instance.Add(EEventName.DailyUpdateNotify, new Action(this.OnDailyUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.WeeklyChallengeRefresh, new Action(this.OnWeeklyChallengeRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.WeeklyChallengeScoreChanged, new Action(this.OnWeeklyScoreChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.WeeklyChallengeRewardStateChanged, new Action(this.OnWeeklyRewardStateChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshActivityRewardPopUp, new Action(this.OnRewardPopUpChange));
	}

	// Token: 0x0600C378 RID: 50040 RVA: 0x003386EC File Offset: 0x003368EC
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.DailyActivityRefresh, new Action(this.OnDailyActivityRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.DailyActivityTaskUpdate, new Action(this.OnDailyTaskChangeRefresh));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.DailyActivityValueChange, new Action<int>(this.OnDailyValueChange));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<int>>(EEventName.DailyActivityRewardTake, new Action<IReadOnlyList<int>>(this.OnDailyRewardTake));
		Singleton<EventSystem>.Instance.Remove(EEventName.DailyUpdateNotify, new Action(this.OnDailyUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyChallengeRefresh, new Action(this.OnWeeklyChallengeRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyChallengeScoreChanged, new Action(this.OnWeeklyScoreChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyChallengeRewardStateChanged, new Action(this.OnWeeklyRewardStateChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshActivityRewardPopUp, new Action(this.OnRewardPopUpChange));
	}

	// Token: 0x0600C379 RID: 50041 RVA: 0x003387F8 File Offset: 0x003369F8
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.AdventureHelpBtn, 27);
		this.InitDailyActivityPanel();
		this.RefreshDoubleExpPanel();
		this.RefreshDailyCountDown(true);
		LevelSequencePlayer startLevelSequencePlayer = this.StartLevelSequencePlayer;
		if (startLevelSequencePlayer != null)
		{
			startLevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
		HotKeyComponentUtil.SetupComponents<RewardTakeComponent>(this.RootItem, EHotKeyCacheKey.RewardTakeDataCallback, delegate
		{
			if (this.CurrentMainTab == DailyActivityDefine.EDailyActivityMainTab.Weekly)
			{
				return ModelBase<WeeklyChallengeModel>.Instance.GetLastNotTaken();
			}
			return ModelBase<DailyActivityModel>.Instance.GetLastNotTaken();
		});
	}

	// Token: 0x0600C37A RID: 50042 RVA: 0x00338864 File Offset: 0x00336A64
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		DailyActivityView.<OnBeforeShowAsyncImplement>d__21 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<DailyActivityView.<OnBeforeShowAsyncImplement>d__21>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x0600C37B RID: 50043 RVA: 0x003388A7 File Offset: 0x00336AA7
	protected override void OnBeforeHide()
	{
		this.RewardPopup.SetActive(false);
	}

	// Token: 0x0600C37C RID: 50044 RVA: 0x003388B5 File Offset: 0x00336AB5
	protected override void OnTickUiTabViewBase(float deltaTime)
	{
		this.DailyPanelProgress.OnTickRefresh(deltaTime);
		this.WeeklyPanelProgress.OnTickRefresh(deltaTime);
		this.RefreshDailyCountDown(false);
		this.RefreshDoubleExpPanel();
	}

	// Token: 0x0600C37D RID: 50045 RVA: 0x003388DC File Offset: 0x00336ADC
	private void RefreshDoubleExpPanel()
	{
		UUIItem item = base.GetItem(16);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.CurrentMainTab == DailyActivityDefine.EDailyActivityMainTab.Daily && ModelBase<DailyActivityModel>.Instance.IsUnionExpDoubleBonusActive());
	}

	// Token: 0x0600C37E RID: 50046 RVA: 0x00338908 File Offset: 0x00336B08
	private void RefreshDailyCountDown(bool forceRefresh = false)
	{
		long num = (this.CurrentMainTab == DailyActivityDefine.EDailyActivityMainTab.Weekly) ? ModelBase<WeeklyChallengeModel>.Instance.WeeklyEndTime : ModelBase<DailyActivityModel>.Instance.DayEndTime;
		if (num == 0L && this.CountDownString != "")
		{
			this.CountDownString = "";
			return;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double num2 = Math.Max((double)num - serverTime, 0.0);
		string text = "";
		string text2;
		if (num2 <= Singleton<TimeUtil>.Instance.Minute)
		{
			text2 = "Text_RefreshText_Text01";
		}
		else
		{
			CommonDefine.ETimeType value = (num2 >= 86400.0) ? CommonDefine.ETimeType.Day : ((num2 >= 3600.0) ? CommonDefine.ETimeType.Hour : CommonDefine.ETimeType.Minute);
			CommonDefine.ETimeType value2 = (num2 >= 86400.0) ? CommonDefine.ETimeType.Hour : ((num2 >= 3600.0) ? CommonDefine.ETimeType.Minute : CommonDefine.ETimeType.Second);
			text = (Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num2, new CommonDefine.ETimeType?(value), new CommonDefine.ETimeType?(value2)).CountDownText ?? "");
			text2 = "Text_RefreshText_Text";
		}
		string text3 = text2 + "_" + text;
		if (this.CountDownString != text3 || forceRefresh)
		{
			this.CountDownString = text3;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), text2, new <>z__ReadOnlySingleElementList<object>(text));
	}

	// Token: 0x0600C37F RID: 50047 RVA: 0x00338A4C File Offset: 0x00336C4C
	private void OnDailyUpdate()
	{
		UiViewBase topView = Singleton<UiModel>.Instance.GetTopView(ELayerType.Normal);
		EUiViewName? euiViewName;
		if (topView == null)
		{
			euiViewName = null;
		}
		else
		{
			UiViewInfo viewInfo = topView.ViewInfo;
			euiViewName = ((viewInfo != null) ? new EUiViewName?(viewInfo.Name) : null);
		}
		if (euiViewName != EUiViewName.AdventureGuideView)
		{
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DailyActivityRefresh);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600C380 RID: 50048 RVA: 0x00338AC8 File Offset: 0x00336CC8
	private List<DailyActivityDefine.IDailyActivityMainTabData> BuildTabDataList()
	{
		List<DailyActivityDefine.IDailyActivityMainTabData> list = new List<DailyActivityDefine.IDailyActivityMainTabData>();
		if (ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.DailyActivity))
		{
			Dictionary<int, DailyActivityDefine.IActivityGoalData> dailyActivityGoalMap = ModelBase<DailyActivityModel>.Instance.DailyActivityGoalMap;
			bool flag = dailyActivityGoalMap.Count > 0;
			if (flag)
			{
				using (Dictionary<int, DailyActivityDefine.IActivityGoalData>.ValueCollection.Enumerator enumerator = dailyActivityGoalMap.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.State != EDailyActiveState.FinishedAndTaken)
						{
							flag = false;
							break;
						}
					}
				}
			}
			list.Add(new DailyActivityDefine.DailyActivityMainTabData
			{
				TabType = DailyActivityDefine.EDailyActivityMainTab.Daily,
				IsFinished = flag
			});
		}
		if (ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.WeeklyChallenge) && ModelBase<WeeklyChallengeModel>.Instance.WeeklyConfigId != 0)
		{
			IReadOnlyDictionary<int, DailyActivityDefine.IActivityGoalData> weeklyGoalMap = ModelBase<WeeklyChallengeModel>.Instance.WeeklyGoalMap;
			bool flag2 = weeklyGoalMap.Count > 0;
			if (flag2)
			{
				using (IEnumerator<DailyActivityDefine.IActivityGoalData> enumerator2 = weeklyGoalMap.Values.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.State != EDailyActiveState.FinishedAndTaken)
						{
							flag2 = false;
							break;
						}
					}
				}
			}
			list.Add(new DailyActivityDefine.DailyActivityMainTabData
			{
				TabType = DailyActivityDefine.EDailyActivityMainTab.Weekly,
				IsFinished = flag2
			});
		}
		return list;
	}

	// Token: 0x0600C381 RID: 50049 RVA: 0x00338C04 File Offset: 0x00336E04
	private void RefreshMainTabData()
	{
		this.MainTabLayout.RefreshByDataDirectlySync(this.BuildTabDataList());
	}

	// Token: 0x0600C382 RID: 50050 RVA: 0x00338C18 File Offset: 0x00336E18
	private UniTask InitTabViewAsync()
	{
		DailyActivityView.<InitTabViewAsync>d__29 <InitTabViewAsync>d__;
		<InitTabViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTabViewAsync>d__.<>4__this = this;
		<InitTabViewAsync>d__.<>1__state = -1;
		<InitTabViewAsync>d__.<>t__builder.Start<DailyActivityView.<InitTabViewAsync>d__29>(ref <InitTabViewAsync>d__);
		return <InitTabViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C383 RID: 50051 RVA: 0x00338C5C File Offset: 0x00336E5C
	private void ApplyMainTabPanels(DailyActivityDefine.EDailyActivityMainTab tab)
	{
		this.CurrentMainTab = tab;
		if (tab == DailyActivityDefine.EDailyActivityMainTab.Daily)
		{
			this.MarkTabOpened(tab);
		}
		bool flag = tab == DailyActivityDefine.EDailyActivityMainTab.Daily;
		UUIItem item = base.GetItem(12);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIItem item2 = base.GetItem(13);
		if (item2 != null)
		{
			item2.SetUIActive(!flag);
		}
		if (!flag)
		{
			this.InitWeeklyActivityPanel();
			this.RefreshWeeklyLoopView();
		}
		else if (this.TaskDataList != null)
		{
			this.PlayTaskLoopAnim();
		}
		this.RefreshDailyCountDown(true);
		this.RefreshDoubleExpPanel();
	}

	// Token: 0x0600C384 RID: 50052 RVA: 0x00338CD8 File Offset: 0x00336ED8
	private void MarkTabOpened(DailyActivityDefine.EDailyActivityMainTab tab)
	{
		long num = (tab == DailyActivityDefine.EDailyActivityMainTab.Daily) ? ModelBase<DailyActivityModel>.Instance.DayEndTime : ModelBase<WeeklyChallengeModel>.Instance.WeeklyEndTime;
		if (num <= 0L)
		{
			return;
		}
		if ((long)ModelBase<DailyActivityModel>.Instance.GetFirstOpenTabTime(tab).GetValueOrDefault() == num)
		{
			return;
		}
		ModelBase<DailyActivityModel>.Instance.SetFirstOpenTabTime(tab, (int)num);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.DailyActivityMainTabOpened, (int)tab);
	}

	// Token: 0x0600C385 RID: 50053 RVA: 0x00338D3C File Offset: 0x00336F3C
	private void OnMainTabClick(DailyActivityDefine.EDailyActivityMainTab tab)
	{
		if (tab == this.CurrentMainTab)
		{
			return;
		}
		GenericLayout<DailyActivityMainTabItem, DailyActivityDefine.IDailyActivityMainTabData> mainTabLayout = this.MainTabLayout;
		if (mainTabLayout != null)
		{
			mainTabLayout.SelectGridProxyByKey(tab, false);
		}
		this.ApplyMainTabPanels(tab);
	}

	// Token: 0x0600C386 RID: 50054 RVA: 0x00338D67 File Offset: 0x00336F67
	private DailyActivityMainTabItem CreateMainTabItem()
	{
		return new DailyActivityMainTabItem
		{
			OnToggleCallBack = new Action<DailyActivityDefine.EDailyActivityMainTab>(this.OnMainTabClick)
		};
	}

	// Token: 0x0600C387 RID: 50055 RVA: 0x00338D80 File Offset: 0x00336F80
	private void PlayTaskLoopAnim()
	{
		UUIInturnAnimController uuiinturnAnimController = base.GetLoopScrollViewComponent(0).Content.Get().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController;
		if (uuiinturnAnimController == null)
		{
			return;
		}
		uuiinturnAnimController.Play("", -1, false);
	}

	// Token: 0x0600C388 RID: 50056 RVA: 0x00338DC8 File Offset: 0x00336FC8
	private void RefreshDailyTaskView()
	{
		UiAsyncTask task = new UiAsyncTask("Refresh", delegate()
		{
			DailyActivityView.<<RefreshDailyTaskView>b__35_0>d <<RefreshDailyTaskView>b__35_0>d;
			<<RefreshDailyTaskView>b__35_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<RefreshDailyTaskView>b__35_0>d.<>4__this = this;
			<<RefreshDailyTaskView>b__35_0>d.<>1__state = -1;
			<<RefreshDailyTaskView>b__35_0>d.<>t__builder.Start<DailyActivityView.<<RefreshDailyTaskView>b__35_0>d>(ref <<RefreshDailyTaskView>b__35_0>d);
			return <<RefreshDailyTaskView>b__35_0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x0600C389 RID: 50057 RVA: 0x00338DF8 File Offset: 0x00336FF8
	private UniTask RefreshDailyTaskViewAsync()
	{
		DailyActivityView.<RefreshDailyTaskViewAsync>d__36 <RefreshDailyTaskViewAsync>d__;
		<RefreshDailyTaskViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshDailyTaskViewAsync>d__.<>4__this = this;
		<RefreshDailyTaskViewAsync>d__.<>1__state = -1;
		<RefreshDailyTaskViewAsync>d__.<>t__builder.Start<DailyActivityView.<RefreshDailyTaskViewAsync>d__36>(ref <RefreshDailyTaskViewAsync>d__);
		return <RefreshDailyTaskViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C38A RID: 50058 RVA: 0x00338E3C File Offset: 0x0033703C
	private void DailyTaskReward()
	{
		UiAsyncTask task = new UiAsyncTask("Refresh", delegate()
		{
			DailyActivityView.<<DailyTaskReward>b__37_0>d <<DailyTaskReward>b__37_0>d;
			<<DailyTaskReward>b__37_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<DailyTaskReward>b__37_0>d.<>4__this = this;
			<<DailyTaskReward>b__37_0>d.<>1__state = -1;
			<<DailyTaskReward>b__37_0>d.<>t__builder.Start<DailyActivityView.<<DailyTaskReward>b__37_0>d>(ref <<DailyTaskReward>b__37_0>d);
			return <<DailyTaskReward>b__37_0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x0600C38B RID: 50059 RVA: 0x00338E6C File Offset: 0x0033706C
	private UniTask DailyTaskRewardImplAsync()
	{
		DailyActivityView.<DailyTaskRewardImplAsync>d__38 <DailyTaskRewardImplAsync>d__;
		<DailyTaskRewardImplAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<DailyTaskRewardImplAsync>d__.<>4__this = this;
		<DailyTaskRewardImplAsync>d__.<>1__state = -1;
		<DailyTaskRewardImplAsync>d__.<>t__builder.Start<DailyActivityView.<DailyTaskRewardImplAsync>d__38>(ref <DailyTaskRewardImplAsync>d__);
		return <DailyTaskRewardImplAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C38C RID: 50060 RVA: 0x00338EB0 File Offset: 0x003370B0
	private void InitDailyActivityPanel()
	{
		base.GetText(3).SetText("0", true);
		this.CurrentActivityValue = (float)ModelBase<DailyActivityModel>.Instance.ActivityValue;
		base.GetText(2).SetText(this.CurrentActivityValue.ToString(), true);
		this.DailyPanelProgress.Init();
	}

	// Token: 0x0600C38D RID: 50061 RVA: 0x00338F04 File Offset: 0x00337104
	private float SetDailyActivityValue()
	{
		int activityValue = ModelBase<DailyActivityModel>.Instance.ActivityValue;
		base.GetText(2).SetText(activityValue.ToString(), true);
		if ((float)activityValue > this.CurrentActivityValue)
		{
			if (this.UiViewSequence.HasSequenceNameInPlaying("Refresh"))
			{
				this.UiViewSequence.ReplaySequence("Refresh");
			}
			else
			{
				this.UiViewSequence.PlaySequence("Refresh", false, null);
			}
		}
		this.CurrentActivityValue = (float)activityValue;
		return (float)activityValue;
	}

	// Token: 0x0600C38E RID: 50062 RVA: 0x00338F84 File Offset: 0x00337184
	private void RefreshDailyActivityPanel()
	{
		float value = this.SetDailyActivityValue();
		this.DailyPanelProgress.RefreshProgressBarDynamic(value);
	}

	// Token: 0x0600C38F RID: 50063 RVA: 0x00338FA4 File Offset: 0x003371A4
	private void OnDailyActivityRefresh()
	{
		this.RefreshDailyTaskView();
		this.SetDailyActivityValue();
		this.DailyPanelProgress.Init();
		if (this.CurrentMainTab == DailyActivityDefine.EDailyActivityMainTab.Daily)
		{
			this.MarkTabOpened(DailyActivityDefine.EDailyActivityMainTab.Daily);
		}
		this.RefreshMainTabData();
	}

	// Token: 0x0600C390 RID: 50064 RVA: 0x00338FD4 File Offset: 0x003371D4
	private void OnDailyTaskChangeRefresh()
	{
		this.RefreshDailyTaskView();
	}

	// Token: 0x0600C391 RID: 50065 RVA: 0x00338FDC File Offset: 0x003371DC
	private void OnDailyValueChange(int value)
	{
		this.RefreshDailyActivityPanel();
		this.RefreshMainTabData();
	}

	// Token: 0x0600C392 RID: 50066 RVA: 0x00338FEA File Offset: 0x003371EA
	private void OnDailyRewardTake(IReadOnlyList<int> _)
	{
		this.RefreshMainTabData();
	}

	// Token: 0x0600C393 RID: 50067 RVA: 0x00338FF2 File Offset: 0x003371F2
	private DailyActivityTaskItem CreateDailyTaskItem()
	{
		DailyActivityTaskItem dailyActivityTaskItem = new DailyActivityTaskItem();
		dailyActivityTaskItem.SetClickReceiveCb(new Action(this.DailyTaskReward));
		return dailyActivityTaskItem;
	}

	// Token: 0x0600C394 RID: 50068 RVA: 0x0033900C File Offset: 0x0033720C
	private void OnRewardPopUpChange()
	{
		RewardPopupData rewardData = ModelBase<DailyActivityModel>.Instance.RewardData;
		this.RewardPopup.Refresh(rewardData);
	}

	// Token: 0x0600C395 RID: 50069 RVA: 0x00339030 File Offset: 0x00337230
	private void InitWeeklyActivityPanel()
	{
		base.GetText(10).SetText("0", true);
		int weeklyCurrentScore = ModelBase<WeeklyChallengeModel>.Instance.WeeklyCurrentScore;
		base.GetText(9).SetText(weeklyCurrentScore.ToString(), true);
		this.WeeklyPanelProgress.Init();
	}

	// Token: 0x0600C396 RID: 50070 RVA: 0x0033907B File Offset: 0x0033727B
	private WeeklyChallengeItem CreateWeeklyChallengeItem()
	{
		return new WeeklyChallengeItem();
	}

	// Token: 0x0600C397 RID: 50071 RVA: 0x00339084 File Offset: 0x00337284
	private List<WeeklyChallengeTaskData> BuildWeeklyChallengeTaskDataList()
	{
		List<int> list = ModelBase<WeeklyChallengeModel>.Instance.WeeklyPlayIds ?? new List<int>();
		List<WeeklyChallengeTaskData> list2 = new List<WeeklyChallengeTaskData>();
		foreach (int num in list)
		{
			WeeklyFrameHelp? playConfigById = ConfigBase<WeeklyChallengeConfig>.Instance.GetPlayConfigById(num);
			if (playConfigById != null)
			{
				int unlockCondition = playConfigById.Value.UnlockCondition;
				bool isUnlocked = unlockCondition <= 0 || ControllerBase<LevelGeneralController>.Instance.CheckCondition(unlockCondition.ToString(), null, true, Array.Empty<object>());
				list2.Add(new WeeklyChallengeTaskData
				{
					ConfigId = num,
					IsUnlocked = isUnlocked
				});
			}
		}
		list2.Sort(delegate(WeeklyChallengeTaskData a, WeeklyChallengeTaskData b)
		{
			WeeklyFrameHelp? playConfigById2 = ConfigBase<WeeklyChallengeConfig>.Instance.GetPlayConfigById(a.ConfigId);
			WeeklyFrameHelp? playConfigById3 = ConfigBase<WeeklyChallengeConfig>.Instance.GetPlayConfigById(b.ConfigId);
			int num2 = ((playConfigById3 != null) ? playConfigById3.GetValueOrDefault().Sort : 0) - ((playConfigById2 != null) ? playConfigById2.GetValueOrDefault().Sort : 0);
			if (num2 != 0)
			{
				return num2;
			}
			return b.ConfigId - a.ConfigId;
		});
		if (list2.Count < 3)
		{
			for (int i = list2.Count; i < 3; i++)
			{
				list2.Add(new WeeklyChallengeTaskData
				{
					ConfigId = 0,
					IsUnlocked = false
				});
			}
		}
		return list2;
	}

	// Token: 0x0600C398 RID: 50072 RVA: 0x003391A4 File Offset: 0x003373A4
	private void RefreshWeeklyLoopView()
	{
		UiAsyncTask task = new UiAsyncTask("RefreshWeekly", delegate()
		{
			DailyActivityView.<<RefreshWeeklyLoopView>b__51_0>d <<RefreshWeeklyLoopView>b__51_0>d;
			<<RefreshWeeklyLoopView>b__51_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<RefreshWeeklyLoopView>b__51_0>d.<>4__this = this;
			<<RefreshWeeklyLoopView>b__51_0>d.<>1__state = -1;
			<<RefreshWeeklyLoopView>b__51_0>d.<>t__builder.Start<DailyActivityView.<<RefreshWeeklyLoopView>b__51_0>d>(ref <<RefreshWeeklyLoopView>b__51_0>d);
			return <<RefreshWeeklyLoopView>b__51_0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x0600C399 RID: 50073 RVA: 0x003391D4 File Offset: 0x003373D4
	private UniTask RefreshWeeklyLoopViewAsync()
	{
		DailyActivityView.<RefreshWeeklyLoopViewAsync>d__52 <RefreshWeeklyLoopViewAsync>d__;
		<RefreshWeeklyLoopViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshWeeklyLoopViewAsync>d__.<>4__this = this;
		<RefreshWeeklyLoopViewAsync>d__.<>1__state = -1;
		<RefreshWeeklyLoopViewAsync>d__.<>t__builder.Start<DailyActivityView.<RefreshWeeklyLoopViewAsync>d__52>(ref <RefreshWeeklyLoopViewAsync>d__);
		return <RefreshWeeklyLoopViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C39A RID: 50074 RVA: 0x00339217 File Offset: 0x00337417
	private void OnWeeklyChallengeRefresh()
	{
		this.RefreshWeeklyLoopView();
		if (this.CurrentMainTab == DailyActivityDefine.EDailyActivityMainTab.Weekly)
		{
			this.WeeklyPanelProgress.Init();
		}
		this.RefreshMainTabData();
	}

	// Token: 0x0600C39B RID: 50075 RVA: 0x0033923C File Offset: 0x0033743C
	private void OnWeeklyScoreChanged()
	{
		if (this.CurrentMainTab != DailyActivityDefine.EDailyActivityMainTab.Weekly)
		{
			return;
		}
		int weeklyCurrentScore = ModelBase<WeeklyChallengeModel>.Instance.WeeklyCurrentScore;
		base.GetText(9).SetText(weeklyCurrentScore.ToString(), true);
		this.WeeklyPanelProgress.RefreshProgressBarDynamic((float)weeklyCurrentScore);
	}

	// Token: 0x0600C39C RID: 50076 RVA: 0x00339280 File Offset: 0x00337480
	private void OnWeeklyRewardStateChanged()
	{
		this.RefreshMainTabData();
		if (this.CurrentMainTab != DailyActivityDefine.EDailyActivityMainTab.Weekly)
		{
			return;
		}
		this.WeeklyPanelProgress.Init();
	}

	// Token: 0x0600C39D RID: 50077 RVA: 0x003392A0 File Offset: 0x003374A0
	[NullableContext(2)]
	private UUIItem GetActivityMainTabByIndex(int index)
	{
		if (this.MainTabLayout == null)
		{
			return null;
		}
		DailyActivityMainTabItem layoutItemByIndex = this.MainTabLayout.GetLayoutItemByIndex(index);
		if (layoutItemByIndex == null)
		{
			return null;
		}
		return layoutItemByIndex.GetRootItem();
	}

	// Token: 0x0600C39E RID: 50078 RVA: 0x003392D0 File Offset: 0x003374D0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length >= 2)
		{
			string a = configParams[0].ToString();
			int num = int.Parse(configParams[1]);
			if (a == "Task")
			{
				UUIItem gridByDisplayIndex = this.TaskLoopView.GetGridByDisplayIndex(num);
				if (gridByDisplayIndex != null)
				{
					return new UUIItem[]
					{
						gridByDisplayIndex,
						gridByDisplayIndex
					};
				}
			}
			else if (a == "Gift")
			{
				UUIItem rewardItemByIndex = this.DailyPanelProgress.GetRewardItemByIndex(num);
				if (rewardItemByIndex != null)
				{
					return new UUIItem[]
					{
						rewardItemByIndex,
						rewardItemByIndex
					};
				}
			}
			else if (a == "ActivityMainTab")
			{
				UUIItem activityMainTabByIndex = this.GetActivityMainTabByIndex(num);
				if (activityMainTabByIndex == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					activityMainTabByIndex,
					activityMainTabByIndex
				};
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Guide;
		ELogAuthor author = ELogAuthor.JT;
		string message = "聚焦引导extraParam项配置有误";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x04005DC6 RID: 24006
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<DailyActivityTaskItem, DailyActiveTaskData> TaskLoopView;

	// Token: 0x04005DC7 RID: 24007
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<DailyActiveTaskData> TaskDataList;

	// Token: 0x04005DC8 RID: 24008
	[Nullable(2)]
	private DailyActivityRewardPanel DailyPanelProgress;

	// Token: 0x04005DC9 RID: 24009
	[Nullable(2)]
	private DailyActivityRewardPanel WeeklyPanelProgress;

	// Token: 0x04005DCA RID: 24010
	[Nullable(2)]
	private CommonRewardPopup RewardPopup;

	// Token: 0x04005DCB RID: 24011
	[Nullable(2)]
	private string CountDownString;

	// Token: 0x04005DCC RID: 24012
	[Nullable(2)]
	private LevelSequencePlayer StartLevelSequencePlayer;

	// Token: 0x04005DCD RID: 24013
	private float CurrentActivityValue;

	// Token: 0x04005DCE RID: 24014
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<DailyActivityMainTabItem, DailyActivityDefine.IDailyActivityMainTabData> MainTabLayout;

	// Token: 0x04005DCF RID: 24015
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<WeeklyChallengeItem, WeeklyChallengeTaskData> WeeklyChallengeLoopView;

	// Token: 0x04005DD0 RID: 24016
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<WeeklyChallengeTaskData> WeeklyTaskDataList;

	// Token: 0x04005DD1 RID: 24017
	private DailyActivityDefine.EDailyActivityMainTab CurrentMainTab = DailyActivityDefine.EDailyActivityMainTab.Daily;

	// Token: 0x04005DD2 RID: 24018
	private readonly DailyActivityRewardAdapter DailyRewardAdapter = new DailyActivityRewardAdapter();

	// Token: 0x04005DD3 RID: 24019
	private readonly WeeklyActivityRewardAdapter WeeklyRewardAdapter = new WeeklyActivityRewardAdapter();
}
