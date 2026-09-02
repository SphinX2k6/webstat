using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200155D RID: 5469
[NullableContext(1)]
[Nullable(0)]
public class ActivityRegressTaskMainView : UiViewBase
{
	// Token: 0x06009961 RID: 39265 RVA: 0x00282402 File Offset: 0x00280602
	public ActivityRegressTaskMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06009962 RID: 39266 RVA: 0x00282418 File Offset: 0x00280618
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
	}

	// Token: 0x06009963 RID: 39267 RVA: 0x002824A0 File Offset: 0x002806A0
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressTaskMainView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressTaskMainView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009964 RID: 39268 RVA: 0x002824E3 File Offset: 0x002806E3
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnInventoryUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(this.RefreshCurrentView));
	}

	// Token: 0x06009965 RID: 39269 RVA: 0x0028251D File Offset: 0x0028071D
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnInventoryUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(this.RefreshCurrentView));
	}

	// Token: 0x06009966 RID: 39270 RVA: 0x00282558 File Offset: 0x00280758
	private void OnInventoryUpdate(int configId, int count)
	{
		if (this.CurrentViewType == null)
		{
			return;
		}
		ActivityRegressTaskSubViewBase activityRegressTaskSubViewBase;
		if (this.ChildViewMap.TryGetValue(this.CurrentViewType.Value, out activityRegressTaskSubViewBase))
		{
			EActivityRegressTaskSubViewType? currentViewType = this.CurrentViewType;
			EActivityRegressTaskSubViewType eactivityRegressTaskSubViewType = EActivityRegressTaskSubViewType.MainTask;
			if ((currentViewType.GetValueOrDefault() == eactivityRegressTaskSubViewType & currentViewType != null) && configId == 20)
			{
				activityRegressTaskSubViewBase.Update();
			}
		}
	}

	// Token: 0x06009967 RID: 39271 RVA: 0x002825B8 File Offset: 0x002807B8
	private void RefreshCurrentView()
	{
		if (this.CurrentViewType == null)
		{
			return;
		}
		ActivityRegressTaskSubViewBase activityRegressTaskSubViewBase;
		if (this.ChildViewMap.TryGetValue(this.CurrentViewType.Value, out activityRegressTaskSubViewBase))
		{
			activityRegressTaskSubViewBase.Update();
		}
	}

	// Token: 0x06009968 RID: 39272 RVA: 0x002825F3 File Offset: 0x002807F3
	protected override void OnBeforeShow()
	{
		this.RefreshTitle();
		this.RefreshCurrentView();
		this.RefreshTimerHandle = TimerSystem.RealTimeInstance.Forever(new TTimerAction(this.OnTimerRefresh), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
	}

	// Token: 0x06009969 RID: 39273 RVA: 0x00282630 File Offset: 0x00280830
	protected override void OnAfterHide()
	{
		this.ClearTimer();
	}

	// Token: 0x0600996A RID: 39274 RVA: 0x00282638 File Offset: 0x00280838
	protected override void OnBeforeDestroy()
	{
		this.CloseAllSubUi();
	}

	// Token: 0x0600996B RID: 39275 RVA: 0x00282640 File Offset: 0x00280840
	private UniTask CreateTabs()
	{
		ActivityRegressTaskMainView.<CreateTabs>d__15 <CreateTabs>d__;
		<CreateTabs>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateTabs>d__.<>4__this = this;
		<CreateTabs>d__.<>1__state = -1;
		<CreateTabs>d__.<>t__builder.Start<ActivityRegressTaskMainView.<CreateTabs>d__15>(ref <CreateTabs>d__);
		return <CreateTabs>d__.<>t__builder.Task;
	}

	// Token: 0x0600996C RID: 39276 RVA: 0x00282684 File Offset: 0x00280884
	private CommonTabData GetCommonData(int index)
	{
		ITaskSubViewTabData taskSubViewTabData = ActivityRegressTaskDefineData.taskSubViewTabDataMap[(EActivityRegressTaskSubViewType)index];
		return new CommonTabData(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(taskSubViewTabData.IconName), null, null);
	}

	// Token: 0x0600996D RID: 39277 RVA: 0x002826B5 File Offset: 0x002808B5
	private ActivityRegressTabItemPanel ProxyCreateTabItem([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new ActivityRegressTabItemPanel();
	}

	// Token: 0x0600996E RID: 39278 RVA: 0x002826BC File Offset: 0x002808BC
	private void OnTabSelected(int index)
	{
		ActivityRegressTaskMainView.<>c__DisplayClass18_0 CS$<>8__locals1 = new ActivityRegressTaskMainView.<>c__DisplayClass18_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.index = index;
		UiAsyncTask task = new UiAsyncTask("ActivityRegressTaskSubViewBase.OnTabSelected", delegate()
		{
			ActivityRegressTaskMainView.<>c__DisplayClass18_0.<<OnTabSelected>b__0>d <<OnTabSelected>b__0>d;
			<<OnTabSelected>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnTabSelected>b__0>d.<>4__this = CS$<>8__locals1;
			<<OnTabSelected>b__0>d.<>1__state = -1;
			<<OnTabSelected>b__0>d.<>t__builder.Start<ActivityRegressTaskMainView.<>c__DisplayClass18_0.<<OnTabSelected>b__0>d>(ref <<OnTabSelected>b__0>d);
			return <<OnTabSelected>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task).Forget();
	}

	// Token: 0x0600996F RID: 39279 RVA: 0x00282704 File Offset: 0x00280904
	private UniTask RefreshTabs()
	{
		ActivityRegressTaskMainView.<RefreshTabs>d__19 <RefreshTabs>d__;
		<RefreshTabs>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabs>d__.<>4__this = this;
		<RefreshTabs>d__.<>1__state = -1;
		<RefreshTabs>d__.<>t__builder.Start<ActivityRegressTaskMainView.<RefreshTabs>d__19>(ref <RefreshTabs>d__);
		return <RefreshTabs>d__.<>t__builder.Task;
	}

	// Token: 0x06009970 RID: 39280 RVA: 0x00282748 File Offset: 0x00280948
	private UniTask ChangeSubUi(EActivityRegressTaskSubViewType viewType)
	{
		ActivityRegressTaskMainView.<ChangeSubUi>d__20 <ChangeSubUi>d__;
		<ChangeSubUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ChangeSubUi>d__.<>4__this = this;
		<ChangeSubUi>d__.viewType = viewType;
		<ChangeSubUi>d__.<>1__state = -1;
		<ChangeSubUi>d__.<>t__builder.Start<ActivityRegressTaskMainView.<ChangeSubUi>d__20>(ref <ChangeSubUi>d__);
		return <ChangeSubUi>d__.<>t__builder.Task;
	}

	// Token: 0x06009971 RID: 39281 RVA: 0x00282794 File Offset: 0x00280994
	private void UpdateTitle()
	{
		ITaskSubViewTabData taskSubViewTabData = ActivityRegressTaskDefineData.taskSubViewTabDataMap[this.CurrentViewType.Value];
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(taskSubViewTabData.IconName);
		this.CaptionTabComponent.UpdateTitle(resourcePath, new CommonTabTitleData(taskSubViewTabData.TitleKey, Array.Empty<object>()));
	}

	// Token: 0x06009972 RID: 39282 RVA: 0x002827E8 File Offset: 0x002809E8
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<ActivityRegressTaskSubViewBase> CreateSubUi(EActivityRegressTaskSubViewType viewType)
	{
		ActivityRegressTaskMainView.<CreateSubUi>d__22 <CreateSubUi>d__;
		<CreateSubUi>d__.<>t__builder = AsyncUniTaskMethodBuilder<ActivityRegressTaskSubViewBase>.Create();
		<CreateSubUi>d__.<>4__this = this;
		<CreateSubUi>d__.viewType = viewType;
		<CreateSubUi>d__.<>1__state = -1;
		<CreateSubUi>d__.<>t__builder.Start<ActivityRegressTaskMainView.<CreateSubUi>d__22>(ref <CreateSubUi>d__);
		return <CreateSubUi>d__.<>t__builder.Task;
	}

	// Token: 0x06009973 RID: 39283 RVA: 0x00282834 File Offset: 0x00280A34
	private UniTask OpenSubUi(EActivityRegressTaskSubViewType viewType)
	{
		ActivityRegressTaskMainView.<OpenSubUi>d__23 <OpenSubUi>d__;
		<OpenSubUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenSubUi>d__.<>4__this = this;
		<OpenSubUi>d__.viewType = viewType;
		<OpenSubUi>d__.<>1__state = -1;
		<OpenSubUi>d__.<>t__builder.Start<ActivityRegressTaskMainView.<OpenSubUi>d__23>(ref <OpenSubUi>d__);
		return <OpenSubUi>d__.<>t__builder.Task;
	}

	// Token: 0x06009974 RID: 39284 RVA: 0x00282880 File Offset: 0x00280A80
	private UniTask HideSubUi(EActivityRegressTaskSubViewType viewType)
	{
		ActivityRegressTaskMainView.<HideSubUi>d__24 <HideSubUi>d__;
		<HideSubUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HideSubUi>d__.<>4__this = this;
		<HideSubUi>d__.viewType = viewType;
		<HideSubUi>d__.<>1__state = -1;
		<HideSubUi>d__.<>t__builder.Start<ActivityRegressTaskMainView.<HideSubUi>d__24>(ref <HideSubUi>d__);
		return <HideSubUi>d__.<>t__builder.Task;
	}

	// Token: 0x06009975 RID: 39285 RVA: 0x002828CC File Offset: 0x00280ACC
	private void CloseAllSubUi()
	{
		foreach (KeyValuePair<EActivityRegressTaskSubViewType, ActivityRegressTaskSubViewBase> keyValuePair in this.ChildViewMap)
		{
			keyValuePair.Value.CloseMeAsync().Forget<bool>();
		}
		this.ChildViewMap.Clear();
	}

	// Token: 0x06009976 RID: 39286 RVA: 0x00282934 File Offset: 0x00280B34
	private void RefreshTitle()
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(activityData, null);
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		base.GetText(4).SetUIActive(item);
		if (item)
		{
			base.GetText(4).SetText(item2, true);
		}
	}

	// Token: 0x06009977 RID: 39287 RVA: 0x00282983 File Offset: 0x00280B83
	private void OnTimerRefresh(float gap)
	{
		this.RefreshTitle();
	}

	// Token: 0x06009978 RID: 39288 RVA: 0x0028298B File Offset: 0x00280B8B
	private void ClearTimer()
	{
		if (this.RefreshTimerHandle != null && TimerSystem.RealTimeInstance.Has(this.RefreshTimerHandle))
		{
			TimerSystem.RealTimeInstance.Remove(this.RefreshTimerHandle);
			this.RefreshTimerHandle = null;
		}
	}

	// Token: 0x040046E1 RID: 18145
	[Nullable(2)]
	private ActivityRegressMainCaptionListPanel CaptionTabComponent;

	// Token: 0x040046E2 RID: 18146
	private EActivityRegressTaskSubViewType? CurrentViewType;

	// Token: 0x040046E3 RID: 18147
	private readonly Dictionary<EActivityRegressTaskSubViewType, ActivityRegressTaskSubViewBase> ChildViewMap = new Dictionary<EActivityRegressTaskSubViewType, ActivityRegressTaskSubViewBase>();

	// Token: 0x040046E4 RID: 18148
	[Nullable(2)]
	private TimerHandle RefreshTimerHandle;

	// Token: 0x02007914 RID: 30996
	[NullableContext(0)]
	private class EActivityRegressTaskSubViewComponents
	{
		// Token: 0x040299BA RID: 170426
		public const int CaptionNameList = 0;

		// Token: 0x040299BB RID: 170427
		public const int TexBg = 1;

		// Token: 0x040299BC RID: 170428
		public const int Content = 2;

		// Token: 0x040299BD RID: 170429
		public const int TexBg2 = 3;

		// Token: 0x040299BE RID: 170430
		public const int TxtTime = 4;
	}
}
