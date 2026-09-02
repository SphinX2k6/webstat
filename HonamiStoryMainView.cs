using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Functional;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F3E RID: 7998
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryMainView : UiViewBase, IUiCameraBehavior
{
	// Token: 0x0600EF2A RID: 61226 RVA: 0x00415929 File Offset: 0x00413B29
	public HonamiStoryMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EF2B RID: 61227 RVA: 0x00415954 File Offset: 0x00413B54
	protected unsafe override void OnRegisterComponent()
	{
		int num = 19;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnBtnTalk));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(14, new Action<EToggleState>(this.OnHideToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600EF2C RID: 61228 RVA: 0x00415C5C File Offset: 0x00413E5C
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryMainView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryMainView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EF2D RID: 61229 RVA: 0x00415CA0 File Offset: 0x00413EA0
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnUiBlendInTimeCameraFinished, new Action<UiCameraHandleData>(this.OnCameraFinish));
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnHonamiStorySetVisible, new Action<bool>(this.OnHonamiStorySetVisible));
	}

	// Token: 0x0600EF2E RID: 61230 RVA: 0x00415D04 File Offset: 0x00413F04
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUiBlendInTimeCameraFinished, new Action<UiCameraHandleData>(this.OnCameraFinish));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStorySetVisible, new Action<bool>(this.OnHonamiStorySetVisible));
	}

	// Token: 0x0600EF2F RID: 61231 RVA: 0x00415D68 File Offset: 0x00413F68
	protected override void OnBeforeShow()
	{
		Singleton<UiCameraAnimationManager>.Instance.DisablePlayerActor();
		if (!HonamiStoryUtil.CheckInMainQuest())
		{
			this.RefreshTimeText();
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				this.RefreshTimeText();
			}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		}
		bool flag = this.CheckIsShowPanel();
		if (flag)
		{
			this.QuestPanel.Refresh(false);
			this.ProfitPanel.Refresh(true);
		}
		this.QuestPanel.SetActive(flag);
		this.ProfitPanel.SetActive(flag);
		this.RefreshNormalButtonStates();
		this.ButtonGoItem.RefreshButtonState();
		this.RefreshTalkButton(false);
		this.RefreshPermanentScore();
		this.IsHideAllUi = false;
		this.RefreshAllUiState(!this.IsHideAllUi);
	}

	// Token: 0x0600EF30 RID: 61232 RVA: 0x00415E29 File Offset: 0x00414029
	protected override void OnStart()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.AddSequenceFinishEvent("ShowView", new Action<string>(this.OnShowUiSequenceFinish), false);
	}

	// Token: 0x0600EF31 RID: 61233 RVA: 0x00415E4D File Offset: 0x0041404D
	protected override void OnBeforeHide()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
		this.ResetHasClickedAnyButton();
	}

	// Token: 0x0600EF32 RID: 61234 RVA: 0x00415E78 File Offset: 0x00414078
	protected override void OnBeforeDestroy()
	{
		foreach (HonamiStoryMainButtonItem honamiStoryMainButtonItem in this.ButtonItems.Values)
		{
			honamiStoryMainButtonItem.Clear();
		}
		this.ButtonItems.Clear();
		this.ButtonConfigs = new List<IHonamiStoryMainButtonConfig>();
	}

	// Token: 0x0600EF33 RID: 61235 RVA: 0x00415EE4 File Offset: 0x004140E4
	protected override void OnAfterDestroy()
	{
		Singleton<UiCameraAnimationManager>.Instance.EnablePlayerActor();
	}

	// Token: 0x0600EF34 RID: 61236 RVA: 0x00415EF0 File Offset: 0x004140F0
	private void OnActivitySequenceEmitEvent(string param)
	{
		foreach (HonamiStoryMainButtonItem honamiStoryMainButtonItem in this.ButtonItems.Values)
		{
			if (honamiStoryMainButtonItem.SpecialParamName == param)
			{
				honamiStoryMainButtonItem.SetText();
				honamiStoryMainButtonItem.SetRedDot();
			}
		}
	}

	// Token: 0x0600EF35 RID: 61237 RVA: 0x00415F5C File Offset: 0x0041415C
	private void OnHonamiStorySetVisible(bool _)
	{
		this.RefreshAllUiState(true);
	}

	// Token: 0x0600EF36 RID: 61238 RVA: 0x00415F65 File Offset: 0x00414165
	private void OnCameraFinish(UiCameraHandleData handleData)
	{
		if (handleData.ViewName == EUiViewName.HonamiStoryMainView)
		{
			this.RefreshTalkButton(false);
		}
	}

	// Token: 0x0600EF37 RID: 61239 RVA: 0x00415F85 File Offset: 0x00414185
	private void OnShowUiSequenceFinish(string _)
	{
		this.RefreshSpecialButtonsStates();
	}

	// Token: 0x0600EF38 RID: 61240 RVA: 0x00415F90 File Offset: 0x00414190
	public void RefreshSpecialButtonsStates()
	{
		foreach (HonamiStoryMainButtonItem honamiStoryMainButtonItem in this.ButtonItems.Values)
		{
			if (honamiStoryMainButtonItem.CheckIsSpecialSet())
			{
				honamiStoryMainButtonItem.SetButtonState();
				this.UiViewSequence.PlaySequence(honamiStoryMainButtonItem.SpecialSequenceName, false, null);
			}
		}
		int lastRecordRevenue = ModelBase<HonamiStoryModel>.Instance.LastRecordRevenue;
		int totalRevenue = ModelBase<HonamiStoryModel>.Instance.TotalRevenue;
		if (lastRecordRevenue != totalRevenue)
		{
			this.ProfitPanel.PlayChangeSequence();
		}
	}

	// Token: 0x0600EF39 RID: 61241 RVA: 0x00416034 File Offset: 0x00414234
	private void RefreshNormalButtonStates()
	{
		foreach (HonamiStoryMainButtonItem honamiStoryMainButtonItem in this.ButtonItems.Values)
		{
			honamiStoryMainButtonItem.SetButtonState();
			honamiStoryMainButtonItem.SetText();
			honamiStoryMainButtonItem.SetRedDot();
		}
	}

	// Token: 0x0600EF3A RID: 61242 RVA: 0x00416098 File Offset: 0x00414298
	private void RefreshTimeText()
	{
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		if (activityData == null)
		{
			return;
		}
		bool flag = activityData.CheckIfInLimitTime();
		base.GetItem(11).SetUIActive(flag && !this.IsHideAllUi);
		if (!flag && this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
			return;
		}
		HonamiStoryMainButtonItem honamiStoryMainButtonItem;
		if (this.ButtonItems.TryGetValue(EHonamiStoryMainButtonFunctionType.LimitTask, out honamiStoryMainButtonItem))
		{
			honamiStoryMainButtonItem.SetText();
			honamiStoryMainButtonItem.SetRedDot();
		}
	}

	// Token: 0x0600EF3B RID: 61243 RVA: 0x00416118 File Offset: 0x00414318
	private void RefreshTalkButton(bool isActive)
	{
		UUIButtonComponent button = base.GetButton(12);
		button.RootUIComp.Get().SetUIActive(false);
		if (isActive)
		{
			WorldEntity worldEntity = null;
			List<EntityHandle> list = new List<EntityHandle>();
			ModelBase<CreatureModel>.Instance.GetEntitiesWithPbDataId(this.TalkEntityId, ref list);
			if (list.Count > 0)
			{
				worldEntity = list[0].Entity;
			}
			if (worldEntity == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.LRC, "RefreshTalkButton: entity is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			BaseActorComponent component = worldEntity.GetComponent<BaseActorComponent>();
			if (component == null)
			{
				return;
			}
			FVectorDouble actorLocation = component.ActorLocation;
			Vector2D vector2D = new Vector2D();
			if (HudUnitUtils.PositionUtil.ProjectWorldToScreen(actorLocation, vector2D))
			{
				button.RootUIComp.Get().SetAnchorOffset(vector2D.ToUeVector2D(false));
			}
		}
	}

	// Token: 0x0600EF3C RID: 61244 RVA: 0x004161E4 File Offset: 0x004143E4
	private void RefreshPermanentScore()
	{
		HonamiStoryMainButtonItem honamiStoryMainButtonItem;
		if (this.ButtonItems.TryGetValue(EHonamiStoryMainButtonFunctionType.ScoreReward, out honamiStoryMainButtonItem))
		{
			honamiStoryMainButtonItem.SetButtonState();
			honamiStoryMainButtonItem.SetText();
			honamiStoryMainButtonItem.SetRedDot();
		}
	}

	// Token: 0x0600EF3D RID: 61245 RVA: 0x00416213 File Offset: 0x00414413
	public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
	{
		if (this.UiCameraName.Length > 0)
		{
			ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle((EUiViewName)this.UiCameraName, new int?(viewId), isBlend);
		}
	}

	// Token: 0x0600EF3E RID: 61246 RVA: 0x0041623F File Offset: 0x0041443F
	[NullableContext(2)]
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
	{
		if (this.UiCameraName.Length > 0)
		{
			ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle((EUiViewName)this.UiCameraName, stackTopInfo, closeViewId, popOrDelete);
		}
	}

	// Token: 0x0600EF3F RID: 61247 RVA: 0x00416268 File Offset: 0x00414468
	private bool CheckCanButtonClick()
	{
		return !this.HasClickedAnyButton;
	}

	// Token: 0x0600EF40 RID: 61248 RVA: 0x00416275 File Offset: 0x00414475
	private void SetHasClickedAnyButton()
	{
		this.HasClickedAnyButton = true;
	}

	// Token: 0x0600EF41 RID: 61249 RVA: 0x0041627E File Offset: 0x0041447E
	private void ResetHasClickedAnyButton()
	{
		this.HasClickedAnyButton = false;
	}

	// Token: 0x0600EF42 RID: 61250 RVA: 0x00416287 File Offset: 0x00414487
	private void ExecuteButtonAction(Action action)
	{
		if (!this.CheckCanButtonClick())
		{
			return;
		}
		this.SetHasClickedAnyButton();
		action();
		this.ResetHasClickedAnyButton();
	}

	// Token: 0x0600EF43 RID: 61251 RVA: 0x004162A4 File Offset: 0x004144A4
	private UniTask ExecuteButtonActionAsync(Func<UniTask> action)
	{
		HonamiStoryMainView.<ExecuteButtonActionAsync>d__37 <ExecuteButtonActionAsync>d__;
		<ExecuteButtonActionAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExecuteButtonActionAsync>d__.<>4__this = this;
		<ExecuteButtonActionAsync>d__.action = action;
		<ExecuteButtonActionAsync>d__.<>1__state = -1;
		<ExecuteButtonActionAsync>d__.<>t__builder.Start<HonamiStoryMainView.<ExecuteButtonActionAsync>d__37>(ref <ExecuteButtonActionAsync>d__);
		return <ExecuteButtonActionAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EF44 RID: 61252 RVA: 0x004162F0 File Offset: 0x004144F0
	private void RefreshAllUiState(bool isShow)
	{
		base.GetExtendToggle(14).SetToggleState(isShow ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked, false, false, false);
		base.GetItem(15).SetUIActive(isShow);
		base.GetButton(16).RootUIComp.Get().SetUIActive(isShow);
		bool flag = HonamiStoryUtil.CheckInMainQuest();
		base.GetButton(18).RootUIComp.Get().SetUIActive(!flag && isShow);
		this.QuestPanel.SetActive(this.CheckIsShowPanel() && isShow);
		this.ProfitPanel.SetActive(this.CheckIsShowPanel() && isShow);
		foreach (HonamiStoryMainButtonItem honamiStoryMainButtonItem in this.ButtonItems.Values)
		{
			if (isShow)
			{
				honamiStoryMainButtonItem.SetButtonState();
			}
			else
			{
				honamiStoryMainButtonItem.SetUiActive(isShow);
			}
		}
		this.ButtonGoItem.SetUiActive(isShow);
	}

	// Token: 0x0600EF45 RID: 61253 RVA: 0x004163EC File Offset: 0x004145EC
	private bool CheckIsShowPanel()
	{
		return !HonamiStoryUtil.CheckInMainQuest();
	}

	// Token: 0x0600EF46 RID: 61254 RVA: 0x004163F6 File Offset: 0x004145F6
	private void OnBtnTalk()
	{
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText("剧情对话");
	}

	// Token: 0x0600EF47 RID: 61255 RVA: 0x00416407 File Offset: 0x00414607
	private void OnHideToggle(EToggleState toggleState)
	{
		this.IsHideAllUi = !this.IsHideAllUi;
		this.RefreshAllUiState(!this.IsHideAllUi);
	}

	// Token: 0x0600EF48 RID: 61256 RVA: 0x00416427 File Offset: 0x00414627
	private void OnBtnTechnology()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryTechnologyView, null, null);
	}

	// Token: 0x0600EF49 RID: 61257 RVA: 0x0041643A File Offset: 0x0041463A
	private void OnBtnPrepare()
	{
		ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.HonamiStoryBackpack);
	}

	// Token: 0x0600EF4A RID: 61258 RVA: 0x0041644B File Offset: 0x0041464B
	private void OnBtnShop()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryShopView, null, null);
	}

	// Token: 0x0600EF4B RID: 61259 RVA: 0x0041645E File Offset: 0x0041465E
	private void OnBtnMascotCollect()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryMascotCollectBookView, null, null);
	}

	// Token: 0x0600EF4C RID: 61260 RVA: 0x00416471 File Offset: 0x00414671
	private void OnBtnItemCollect()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryItemCollectView, null, null);
	}

	// Token: 0x0600EF4D RID: 61261 RVA: 0x00416484 File Offset: 0x00414684
	private void OnBtnScoreReward()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryPermanentTaskView, null, null);
	}

	// Token: 0x0600EF4E RID: 61262 RVA: 0x00416497 File Offset: 0x00414697
	private void OnBtnLimitTask()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryLimitTaskView, null, null);
	}

	// Token: 0x0600EF4F RID: 61263 RVA: 0x004164AC File Offset: 0x004146AC
	private bool OnBtnLimitTaskCheckShow()
	{
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		return activityData != null && activityData.CheckIfInLimitTime();
	}

	// Token: 0x0600EF50 RID: 61264 RVA: 0x004164D0 File Offset: 0x004146D0
	private UniTask OnBtnEnter()
	{
		HonamiStoryMainView.<OnBtnEnter>d__50 <OnBtnEnter>d__;
		<OnBtnEnter>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBtnEnter>d__.<>1__state = -1;
		<OnBtnEnter>d__.<>t__builder.Start<HonamiStoryMainView.<OnBtnEnter>d__50>(ref <OnBtnEnter>d__);
		return <OnBtnEnter>d__.<>t__builder.Task;
	}

	// Token: 0x0600EF51 RID: 61265 RVA: 0x0041650B File Offset: 0x0041470B
	private void OnBtnClose()
	{
		base.CloseMe(null);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStorySmallLoadingView, null, null);
	}

	// Token: 0x0600EF52 RID: 61266 RVA: 0x00416528 File Offset: 0x00414728
	private bool OnBtnMascotCollectRedDot()
	{
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		return activityData != null && (activityData.CanMascotCollectGetReward() || activityData.CanAreaCollectGetReward());
	}

	// Token: 0x0600EF53 RID: 61267 RVA: 0x00416558 File Offset: 0x00414758
	private bool OnBtnScoreRewardRedDot()
	{
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		return activityData != null && activityData.IsPermanentTaskHasRedDot();
	}

	// Token: 0x0600EF54 RID: 61268 RVA: 0x0041657C File Offset: 0x0041477C
	private bool OnBtnLimitTaskRedDot()
	{
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		return activityData != null && activityData.IsLimitTaskHasRedDot();
	}

	// Token: 0x0600EF55 RID: 61269 RVA: 0x004165A0 File Offset: 0x004147A0
	private bool OnBtnCollectRedDot()
	{
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		return activityData != null && activityData.IsItemCollectionHasRedDot();
	}

	// Token: 0x0600EF56 RID: 61270 RVA: 0x004165C4 File Offset: 0x004147C4
	private bool OnBtnPrepareRedDot()
	{
		return ModelBase<HonamiStoryModel>.Instance.CheckIsNewInInventory();
	}

	// Token: 0x0600EF57 RID: 61271 RVA: 0x004165D0 File Offset: 0x004147D0
	private bool OnBtnShopRedDot()
	{
		return ModelBase<HonamiStoryModel>.Instance.IsShopHasRedDot();
	}

	// Token: 0x0600EF58 RID: 61272 RVA: 0x004165DC File Offset: 0x004147DC
	private bool OnBtnTechRedDot()
	{
		return ModelBase<HonamiStoryModel>.Instance.IsTechHasRedDot();
	}

	// Token: 0x0600EF59 RID: 61273 RVA: 0x004165E8 File Offset: 0x004147E8
	[NullableContext(2)]
	private void OnLimitTaskTextCallBack(UUIText item)
	{
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		if (activityData == null)
		{
			return;
		}
		string newText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(activityData.EndRewardTime, "{0}") ?? string.Empty;
		if (item != null)
		{
			item.SetText(newText, true);
		}
	}

	// Token: 0x0600EF5A RID: 61274 RVA: 0x00416630 File Offset: 0x00414830
	[NullableContext(2)]
	private void OnScoreRewardTextCallBack(UUIText item)
	{
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		if (activityData == null)
		{
			return;
		}
		int count = activityData.GetPermanentTaskIdsByState(EActivityTaskState.FinishedAndClaimed).Count;
		int permanentTaskTotalNum = activityData.GetPermanentTaskTotalNum();
		if (item != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(count);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(permanentTaskTotalNum);
			item.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
	}

	// Token: 0x0600EF5B RID: 61275 RVA: 0x00416698 File Offset: 0x00414898
	[NullableContext(2)]
	private void OnPrepareTextCallBack(UUIText item)
	{
		HonamiStoryBackpackData backPackData = ModelBase<HonamiStoryModel>.Instance.GetBackPackData(1, false);
		if (backPackData == null)
		{
			return;
		}
		int capacity = backPackData.GetCapacity();
		int occupy = backPackData.GetOccupy();
		if (backPackData.GetOverflowCapacity() > 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(item, "HonamiStory_OverflowCapacity", new <>z__ReadOnlyArray<object>(new object[]
			{
				occupy,
				capacity
			}));
			return;
		}
		if (item != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(occupy);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(capacity);
			item.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
	}

	// Token: 0x0600EF5C RID: 61276 RVA: 0x00416734 File Offset: 0x00414934
	private void InitButtonShow()
	{
		int num = 5;
		int num2 = 11;
		for (int i = num; i <= num2; i++)
		{
			UUIItem item = base.GetItem(i);
			if (item != null)
			{
				item.SetUIActive(false);
			}
		}
	}

	// Token: 0x0600EF5D RID: 61277 RVA: 0x00416764 File Offset: 0x00414964
	private void InitButtonConfigs()
	{
		if (this.ButtonConfigs.Count > 0)
		{
			return;
		}
		this.ButtonConfigs = new List<IHonamiStoryMainButtonConfig>
		{
			new HonamiStoryMainButtonConfig
			{
				Type = EHonamiStoryMainButtonFunctionType.Technology,
				ComponentId = EHonamiStoryMainComponent.TechnologyButton,
				FunctionId = new EFunctionType?(EFunctionType.HonamiStoryTechFuncId),
				OnClickCallback = new Action(this.OnBtnTechnology),
				ShowRedDot = new Func<bool>(this.OnBtnTechRedDot)
			},
			new HonamiStoryMainButtonConfig
			{
				Type = EHonamiStoryMainButtonFunctionType.Prepare,
				ComponentId = EHonamiStoryMainComponent.PrepareButton,
				OnClickCallback = new Action(this.OnBtnPrepare),
				SetTextCallback = new Action<UUIText>(this.OnPrepareTextCallBack),
				ShowRedDot = new Func<bool>(this.OnBtnPrepareRedDot),
				SpecialParamName = "Enter",
				SpecialSequenceName = "Acquire"
			},
			new HonamiStoryMainButtonConfig
			{
				Type = EHonamiStoryMainButtonFunctionType.Shop,
				ComponentId = EHonamiStoryMainComponent.ShopButton,
				FunctionId = new EFunctionType?(EFunctionType.HonamiStoryShopFuncId),
				OnClickCallback = new Action(this.OnBtnShop),
				ShowRedDot = new Func<bool>(this.OnBtnShopRedDot)
			},
			new HonamiStoryMainButtonConfig
			{
				Type = EHonamiStoryMainButtonFunctionType.MascotCollect,
				ComponentId = EHonamiStoryMainComponent.MascotCollectButton,
				FunctionId = new EFunctionType?(EFunctionType.HonamiStoryMascotFuncId),
				OnClickCallback = new Action(this.OnBtnMascotCollect),
				ShowRedDot = new Func<bool>(this.OnBtnMascotCollectRedDot)
			},
			new HonamiStoryMainButtonConfig
			{
				Type = EHonamiStoryMainButtonFunctionType.ItemCollect,
				ComponentId = EHonamiStoryMainComponent.ItemCollectButton,
				FunctionId = new EFunctionType?(EFunctionType.HonamiStoryItemCollectFuncId),
				OnClickCallback = new Action(this.OnBtnItemCollect),
				ShowRedDot = new Func<bool>(this.OnBtnCollectRedDot)
			},
			new HonamiStoryMainButtonConfig
			{
				Type = EHonamiStoryMainButtonFunctionType.ScoreReward,
				ComponentId = EHonamiStoryMainComponent.ScoreRewardButton,
				OnClickCallback = new Action(this.OnBtnScoreReward),
				SetTextCallback = new Action<UUIText>(this.OnScoreRewardTextCallBack),
				ShowRedDot = new Func<bool>(this.OnBtnScoreRewardRedDot)
			},
			new HonamiStoryMainButtonConfig
			{
				Type = EHonamiStoryMainButtonFunctionType.LimitTask,
				ComponentId = EHonamiStoryMainComponent.LimitTaskButton,
				OnClickCallback = new Action(this.OnBtnLimitTask),
				ShowCallback = new Func<bool>(this.OnBtnLimitTaskCheckShow),
				SetTextCallback = new Action<UUIText>(this.OnLimitTaskTextCallBack),
				ShowRedDot = new Func<bool>(this.OnBtnLimitTaskRedDot)
			}
		};
	}

	// Token: 0x0600EF5E RID: 61278 RVA: 0x004169D8 File Offset: 0x00414BD8
	private UniTask CreateButtons()
	{
		HonamiStoryMainView.<CreateButtons>d__64 <CreateButtons>d__;
		<CreateButtons>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateButtons>d__.<>4__this = this;
		<CreateButtons>d__.<>1__state = -1;
		<CreateButtons>d__.<>t__builder.Start<HonamiStoryMainView.<CreateButtons>d__64>(ref <CreateButtons>d__);
		return <CreateButtons>d__.<>t__builder.Task;
	}

	// Token: 0x0600EF5F RID: 61279 RVA: 0x00416A1C File Offset: 0x00414C1C
	private bool CheckButtonShow(EHonamiStoryMainButtonFunctionType buttonType)
	{
		bool flag = HonamiStoryUtil.CheckInMainQuest();
		return !flag || (flag && HonamiStoryMainView.showWhenMainTask.Contains(buttonType));
	}

	// Token: 0x04007311 RID: 29457
	[StaticVariableRuleIgnore]
	private static readonly List<EHonamiStoryMainButtonFunctionType> showWhenMainTask = new List<EHonamiStoryMainButtonFunctionType>
	{
		EHonamiStoryMainButtonFunctionType.Technology,
		EHonamiStoryMainButtonFunctionType.Prepare
	};

	// Token: 0x04007312 RID: 29458
	private PopupCaptionItem PopupCaption;

	// Token: 0x04007313 RID: 29459
	private HonamiStoryQuestPanel QuestPanel;

	// Token: 0x04007314 RID: 29460
	private HonamiStoryProfitPanel ProfitPanel;

	// Token: 0x04007315 RID: 29461
	private HonamiStoryMainButtonGoItem ButtonGoItem;

	// Token: 0x04007316 RID: 29462
	private readonly Dictionary<EHonamiStoryMainButtonFunctionType, HonamiStoryMainButtonItem> ButtonItems = new Dictionary<EHonamiStoryMainButtonFunctionType, HonamiStoryMainButtonItem>();

	// Token: 0x04007317 RID: 29463
	private List<IHonamiStoryMainButtonConfig> ButtonConfigs = new List<IHonamiStoryMainButtonConfig>();

	// Token: 0x04007318 RID: 29464
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x04007319 RID: 29465
	private string UiCameraName = string.Empty;

	// Token: 0x0400731A RID: 29466
	private int TalkEntityId;

	// Token: 0x0400731B RID: 29467
	private bool HasClickedAnyButton;

	// Token: 0x0400731C RID: 29468
	private bool IsHideAllUi;
}
