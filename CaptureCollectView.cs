using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Role;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.LevelEvents;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Module.Menu.SubViews.EyeProtect;
using CSharpScript.Game.Module.QuickTimeAction;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020025A0 RID: 9632
[NullableContext(2)]
[Nullable(0)]
public class CaptureCollectView : UiViewBase, IQtaView, IUiProhibitRefreshData
{
	// Token: 0x06012C51 RID: 76881 RVA: 0x0052D928 File Offset: 0x0052BB28
	[NullableContext(1)]
	public CaptureCollectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012C52 RID: 76882 RVA: 0x0052D994 File Offset: 0x0052BB94
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnPhotographButtonClicked)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnFilterButtonClicked)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnAddButtonButtonClicked)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnReduceButtonClicked))
		};
	}

	// Token: 0x06012C53 RID: 76883 RVA: 0x0052DB3C File Offset: 0x0052BD3C
	protected override UniTask OnBeforeStartAsync()
	{
		CaptureCollectView.<OnBeforeStartAsync>d__24 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CaptureCollectView.<OnBeforeStartAsync>d__24>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012C54 RID: 76884 RVA: 0x0052DB7F File Offset: 0x0052BD7F
	protected override void OnStart()
	{
		this.SetLodBias(-7);
		if (Singleton<Info>.Instance.IsXSXPlatform())
		{
			this.ShouldSavePhoto = false;
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}
	}

	// Token: 0x06012C55 RID: 76885 RVA: 0x0052DBAE File Offset: 0x0052BDAE
	protected override void OnBeforeDestroy()
	{
		this.RemoveChangeFovTimer();
		this.RemoveDelayTimer();
		ControllerBase<PhotographQuickController>.Instance.Reset();
		ModelBase<LoadingModel>.Instance.IsShowUidView = true;
		UKuroSequencePerformanceManager.CloseKuroPerformanceMode();
	}

	// Token: 0x06012C56 RID: 76886 RVA: 0x0052DBD8 File Offset: 0x0052BDD8
	protected override void OnAfterDestroy()
	{
		this.SetLodBias(0);
		BP_PhotoCutFilterPostProcess_C bpFilterFx = this.BpFilterFx;
		if (bpFilterFx != null && bpFilterFx.IsValid())
		{
			CaptureCollectView.WeakRefLastBpFilterFx = new WeakReference<BP_PhotoCutFilterPostProcess_C>(this.BpFilterFx);
		}
		if (this.QtaViewHandler != null)
		{
			this.QtaViewHandler.Finish();
			this.QtaViewHandler = null;
		}
	}

	// Token: 0x06012C57 RID: 76887 RVA: 0x0052DC2C File Offset: 0x0052BE2C
	protected override UniTask OnPlayingStartSequenceAsync()
	{
		CaptureCollectView.<OnPlayingStartSequenceAsync>d__28 <OnPlayingStartSequenceAsync>d__;
		<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingStartSequenceAsync>d__.<>4__this = this;
		<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
		<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<CaptureCollectView.<OnPlayingStartSequenceAsync>d__28>(ref <OnPlayingStartSequenceAsync>d__);
		return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012C58 RID: 76888 RVA: 0x0052DC70 File Offset: 0x0052BE70
	protected override UniTask OnPlayingHideSequenceAsync()
	{
		CaptureCollectView.<OnPlayingHideSequenceAsync>d__29 <OnPlayingHideSequenceAsync>d__;
		<OnPlayingHideSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingHideSequenceAsync>d__.<>4__this = this;
		<OnPlayingHideSequenceAsync>d__.<>1__state = -1;
		<OnPlayingHideSequenceAsync>d__.<>t__builder.Start<CaptureCollectView.<OnPlayingHideSequenceAsync>d__29>(ref <OnPlayingHideSequenceAsync>d__);
		return <OnPlayingHideSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012C59 RID: 76889 RVA: 0x0052DCB4 File Offset: 0x0052BEB4
	protected override UniTask OnPlayingCloseSequenceAsync()
	{
		CaptureCollectView.<OnPlayingCloseSequenceAsync>d__30 <OnPlayingCloseSequenceAsync>d__;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
		<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<CaptureCollectView.<OnPlayingCloseSequenceAsync>d__30>(ref <OnPlayingCloseSequenceAsync>d__);
		return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012C5A RID: 76890 RVA: 0x0052DCF8 File Offset: 0x0052BEF8
	private void SetLodBias(int lodBias)
	{
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		WorldEntity worldEntity;
		if (instance == null)
		{
			worldEntity = null;
		}
		else
		{
			EntityHandle getCurrentEntity = instance.GetCurrentEntity;
			worldEntity = ((getCurrentEntity != null) ? getCurrentEntity.Entity : null);
		}
		WorldEntity worldEntity2 = worldEntity;
		if (worldEntity2 != null && worldEntity2.Valid)
		{
			UeSkeletalTickManageComponent component = worldEntity2.GetComponent<UeSkeletalTickManageComponent>();
			if (component == null)
			{
				return;
			}
			component.SetLodBias(lodBias);
		}
	}

	// Token: 0x06012C5B RID: 76891 RVA: 0x0052DD40 File Offset: 0x0052BF40
	protected override void OnAddEventListener()
	{
		UUIButtonComponent button = base.GetButton(4);
		UUIButtonComponent button2 = base.GetButton(6);
		UUISliderComponent slider = base.GetSlider(5);
		UUIDraggableComponent draggable = base.GetDraggable(7);
		button.OnPointDownCallBack.Bind(new Action(this.OnPressAddButton));
		button.OnPointUpCallBack.Bind(new Action(this.OnReleaseAddButton));
		button.OnPointCancelCallBack.Bind(new Action(this.OnReleaseAddButton));
		button2.OnPointDownCallBack.Bind(new Action(this.OnPressReduceButton));
		button2.OnPointUpCallBack.Bind(new Action(this.OnReleaseReduceButton));
		button2.OnPointCancelCallBack.Bind(new Action(this.OnReleaseReduceButton));
		slider.OnValueChangeCb.Bind(new Action<float>(this.OnSetFov));
		if (Singleton<Info>.Instance.IsMobileInputModel())
		{
			draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragMoved));
			draggable.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragBegin));
			draggable.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragEnded));
		}
		draggable.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragBegin));
		draggable.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragEnded));
		if (Singleton<Info>.Instance.IsPcInputModel())
		{
			ControllerBase<InputDistributeController>.Instance.BindAxis("WheelAxis", new TInputHandle<float>(this.OnInputWheelAxis));
		}
		ControllerBase<InputDistributeController>.Instance.BindAxis("UiIncrease", new TInputHandle<float>(this.OnInputUiIncrease));
		ControllerBase<InputDistributeController>.Instance.BindAxis("UiReduce", new TInputHandle<float>(this.OnInputUiReduce));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhotographSetVisible, new Action(this.OnPhotographSetVisible));
		Singleton<EventSystem>.Instance.Add(EEventName.OnScreenShotDone, new Action(this.OnScreenShotDone));
	}

	// Token: 0x06012C5C RID: 76892 RVA: 0x0052DF20 File Offset: 0x0052C120
	protected override void OnRemoveEventListener()
	{
		UUIButtonComponent button = base.GetButton(4);
		UUIButtonComponent button2 = base.GetButton(6);
		UUISliderComponent slider = base.GetSlider(5);
		UUIDraggableComponent draggable = base.GetDraggable(7);
		button.OnPointDownCallBack.Unbind();
		button.OnPointUpCallBack.Unbind();
		button.OnPointCancelCallBack.Unbind();
		button2.OnPointDownCallBack.Unbind();
		button2.OnPointUpCallBack.Unbind();
		button2.OnPointCancelCallBack.Unbind();
		slider.OnValueChangeCb.Unbind();
		if (Singleton<Info>.Instance.IsMobileInputModel())
		{
			draggable.OnPointerDragCallBack.Unbind();
			draggable.OnPointerBeginDragCallBack.Unbind();
			draggable.OnPointerEndDragCallBack.Unbind();
		}
		draggable.OnPointerDownCallBack.Unbind();
		draggable.OnPointerUpCallBack.Unbind();
		if (Singleton<Info>.Instance.IsPcInputModel())
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("WheelAxis", new TInputHandle<float>(this.OnInputWheelAxis));
		}
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiIncrease", new TInputHandle<float>(this.OnInputUiIncrease));
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiReduce", new TInputHandle<float>(this.OnInputUiReduce));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhotographSetVisible, new Action(this.OnPhotographSetVisible));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnScreenShotDone, new Action(this.OnScreenShotDone));
	}

	// Token: 0x06012C5D RID: 76893 RVA: 0x0052E070 File Offset: 0x0052C270
	[NullableContext(1)]
	private void OnInputWheelAxis(string name, float value, InputIdentification inputIdentification)
	{
		if (value != 0f)
		{
			UUISliderComponent slider = base.GetSlider(5);
			slider.SetValue(slider.Value + value * this.CameraZoomSpeed, true);
		}
	}

	// Token: 0x06012C5E RID: 76894 RVA: 0x0052E096 File Offset: 0x0052C296
	[NullableContext(1)]
	private void OnInputUiIncrease(string axisName, float value, InputIdentification _)
	{
		if (value == 0f || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.ChangeFov(-value * this.CameraZoomSpeed);
	}

	// Token: 0x06012C5F RID: 76895 RVA: 0x0052E0BC File Offset: 0x0052C2BC
	[NullableContext(1)]
	private void OnInputUiReduce(string axisName, float value, InputIdentification _)
	{
		if (value == 0f || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.ChangeFov(-value * this.CameraZoomSpeed);
	}

	// Token: 0x06012C60 RID: 76896 RVA: 0x0052E0E2 File Offset: 0x0052C2E2
	protected override void OnBeforeCreate()
	{
		ControllerBase<PhotographQuickController>.Instance.InitHandlerForCaptureCollect();
	}

	// Token: 0x06012C61 RID: 76897 RVA: 0x0052E0F0 File Offset: 0x0052C2F0
	protected override void OnBeforeShow()
	{
		base.GetItem(10).SetUIActive(this.IsFilterEnabled);
		base.GetItem(11).SetUIActive(!this.IsFilterEnabled);
		if (ControllerBase<PhotographQuickController>.Instance.Model.GetHandler() == null)
		{
			return;
		}
		this.SetUiProhibitRefresh(true);
		ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		if (Singleton<Info>.Instance.IsMobileInputModel())
		{
			ControllerBase<InputDistributeController>.Instance.BindTouches(new int[]
			{
				0,
				1
			}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		}
		ControllerBase<EyeProtectController>.Instance.SwitchFilter(false);
		this.RefreshFov();
		this.EnableTipsItem(true);
	}

	// Token: 0x06012C62 RID: 76898 RVA: 0x0052E190 File Offset: 0x0052C390
	protected override void OnAfterHide()
	{
		this.SetUiProhibitRefresh(false);
		ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		if (Singleton<Info>.Instance.IsMobileInputModel())
		{
			ControllerBase<InputDistributeController>.Instance.UnBindTouches(new int[]
			{
				0,
				1
			}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		}
		ControllerBase<MenuController>.Instance.OpenAllFilter();
		ControllerBase<PhotographQuickController>.Instance.Reset();
		this.EnableTipsItem(false);
		if (this.IsFilterEnabled)
		{
			this.EnableFilterFx(false);
		}
	}

	// Token: 0x06012C63 RID: 76899 RVA: 0x0052E204 File Offset: 0x0052C404
	private void SetUiProhibitRefresh(bool reg)
	{
		if (reg)
		{
			Singleton<UiProhibitFightInputCenter>.Instance.RegisterExtraRefreshData(this.ViewInfo.Name, this);
			return;
		}
		Singleton<UiProhibitFightInputCenter>.Instance.UnRegisterExtraRefreshData(this.ViewInfo.Name);
	}

	// Token: 0x06012C64 RID: 76900 RVA: 0x0052E23F File Offset: 0x0052C43F
	public bool CheckCondition()
	{
		return true;
	}

	// Token: 0x06012C65 RID: 76901 RVA: 0x0052E242 File Offset: 0x0052C442
	[NullableContext(1)]
	public string[] GetDistributeTags()
	{
		return new string[]
		{
			"FightInputRoot.FightInput.AxisInput",
			"FightInputRoot.FightInput.ActionInput.CharacterSkillInput",
			"FightInputRoot.FightInput.ActionInput",
			"UiInputRoot.ShortcutKeyTag",
			"UiInputRoot.MouseInputTag",
			"UiInputRoot.Navigation",
			"InteractionRoot"
		};
	}

	// Token: 0x06012C66 RID: 76902 RVA: 0x0052E282 File Offset: 0x0052C482
	[NullableContext(1)]
	private void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification _)
	{
		if (touchData.TouchType == InputDistributeDefine.ETouchType.TouchMove)
		{
			this.TouchMoved(int.Parse(touchIdName));
		}
	}

	// Token: 0x06012C67 RID: 76903 RVA: 0x0052E29C File Offset: 0x0052C49C
	private void TouchMoved(int touchId)
	{
		if (ControllerBase<PhotographQuickController>.Instance.Model.GetHandler() == null)
		{
			return;
		}
		if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() <= 1)
		{
			return;
		}
		TouchFingerData touchFingerData = Singleton<TouchFingerManager>.Instance.GetTouchFingerData(EFingerIndex.One);
		if (touchFingerData != null && !touchFingerData.IsTouchEmpty() && !touchFingerData.IsTouchComponentContainTag(PhotographDefine.ignoreTouchTag))
		{
			return;
		}
		touchFingerData = Singleton<TouchFingerManager>.Instance.GetTouchFingerData(EFingerIndex.Two);
		if (touchFingerData != null && !touchFingerData.IsTouchEmpty() && !touchFingerData.IsTouchComponentContainTag(PhotographDefine.ignoreTouchTag))
		{
			return;
		}
		float fingerExpandCloseValue = Singleton<TouchFingerManager>.Instance.GetFingerExpandCloseValue(EFingerIndex.One, EFingerIndex.Two);
		float changeValue = Singleton<MathUtils>.Instance.RangeClamp(fingerExpandCloseValue, -50000f, 50000f, -1f, 1f);
		this.ChangeFov(changeValue);
	}

	// Token: 0x06012C68 RID: 76904 RVA: 0x0052E347 File Offset: 0x0052C547
	private void SetVisibleMode(bool bVisible)
	{
		if (this.VisibleMode == bVisible)
		{
			return;
		}
		this.VisibleMode = bVisible;
		ModelBase<LoadingModel>.Instance.IsShowUidView = this.VisibleMode;
	}

	// Token: 0x06012C69 RID: 76905 RVA: 0x0052E36A File Offset: 0x0052C56A
	private void OnPhotographSetVisible()
	{
		this.SetVisibleMode(true);
	}

	// Token: 0x06012C6A RID: 76906 RVA: 0x0052E374 File Offset: 0x0052C574
	private void OnSetFov(float value)
	{
		float fov = Singleton<MathUtils>.Instance.RangeClamp(value, this.MinFov, this.MaxFov, this.MaxFov, this.MinFov);
		ControllerBase<PhotographQuickController>.Instance.SetFov(fov);
	}

	// Token: 0x06012C6B RID: 76907 RVA: 0x0052E3B0 File Offset: 0x0052C5B0
	private void OnDragMoved(ULGUIPointerEventData eventData)
	{
		if (eventData == null)
		{
			return;
		}
		this.InDragMove = true;
		if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1)
		{
			return;
		}
		FVector pointerPosition = eventData.pointerPosition;
		if (this.LastMoveVector != null)
		{
			PhotoCameraHandler handler = ControllerBase<PhotographQuickController>.Instance.Model.GetHandler();
			if (handler == null)
			{
				return;
			}
			float num = (pointerPosition.Y - this.LastMoveVector.Value.Y) * this.ControlCameraRate;
			float num2 = (this.LastMoveVector.Value.X - pointerPosition.X) * this.ControlCameraRate;
			handler.AddPitchInput(-num);
			handler.AddYawInput(-num2);
		}
		this.LastMoveVector = new FVector?(pointerPosition);
	}

	// Token: 0x06012C6C RID: 76908 RVA: 0x0052E458 File Offset: 0x0052C658
	private void OnDragBegin(ULGUIPointerEventData _)
	{
		this.InDragMove = false;
		PhotoCameraHandler handler = ControllerBase<PhotographQuickController>.Instance.Model.GetHandler();
		if (handler == null)
		{
			return;
		}
		handler.ClearInput();
	}

	// Token: 0x06012C6D RID: 76909 RVA: 0x0052E47A File Offset: 0x0052C67A
	private void OnDragEnded(ULGUIPointerEventData _)
	{
		this.LastMoveVector = null;
		if (!this.InDragMove)
		{
			this.SetVisibleMode(true);
		}
		PhotoCameraHandler handler = ControllerBase<PhotographQuickController>.Instance.Model.GetHandler();
		if (handler == null)
		{
			return;
		}
		handler.ClearInput();
	}

	// Token: 0x06012C6E RID: 76910 RVA: 0x0052E4B0 File Offset: 0x0052C6B0
	private void OnPressAddButton()
	{
		this.RemoveChangeFovTimer();
		this.ChangeFovTimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnAddFov), 100f, 1f, null, null, true);
	}

	// Token: 0x06012C6F RID: 76911 RVA: 0x0052E4E1 File Offset: 0x0052C6E1
	private void OnReleaseAddButton()
	{
		this.RemoveChangeFovTimer();
	}

	// Token: 0x06012C70 RID: 76912 RVA: 0x0052E4E9 File Offset: 0x0052C6E9
	private void OnPressReduceButton()
	{
		this.RemoveChangeFovTimer();
		this.ChangeFovTimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnReduceFov), 100f, 1f, null, null, true);
	}

	// Token: 0x06012C71 RID: 76913 RVA: 0x0052E51A File Offset: 0x0052C71A
	private void OnReleaseReduceButton()
	{
		this.RemoveChangeFovTimer();
	}

	// Token: 0x06012C72 RID: 76914 RVA: 0x0052E522 File Offset: 0x0052C722
	private void RemoveChangeFovTimer()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.ChangeFovTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.ChangeFovTimerId);
			this.ChangeFovTimerId = null;
		}
	}

	// Token: 0x06012C73 RID: 76915 RVA: 0x0052E54E File Offset: 0x0052C74E
	private void OnAddFov(float _)
	{
		this.ChangeFov(1f);
	}

	// Token: 0x06012C74 RID: 76916 RVA: 0x0052E55B File Offset: 0x0052C75B
	private void OnReduceFov(float _)
	{
		this.ChangeFov(-1f);
	}

	// Token: 0x06012C75 RID: 76917 RVA: 0x0052E568 File Offset: 0x0052C768
	private void OnAddButtonButtonClicked()
	{
		this.ChangeFov(1f);
	}

	// Token: 0x06012C76 RID: 76918 RVA: 0x0052E575 File Offset: 0x0052C775
	private void OnReduceButtonClicked()
	{
		this.ChangeFov(-1f);
	}

	// Token: 0x06012C77 RID: 76919 RVA: 0x0052E584 File Offset: 0x0052C784
	private void RefreshFov()
	{
		UUISliderComponent slider = base.GetSlider(5);
		slider.SetMinValue(this.MinFov, false, false);
		slider.SetMaxValue(this.MaxFov, false, false);
		PhotoCameraHandler handler = ControllerBase<PhotographQuickController>.Instance.Model.GetHandler();
		if (handler == null)
		{
			return;
		}
		float cameraInitializeFov = handler.GetCameraInitializeFov();
		float inValue = Singleton<MathUtils>.Instance.RangeClamp(cameraInitializeFov, this.MinFov, this.MaxFov, this.MaxFov, this.MinFov);
		slider.SetValue(inValue, true);
		handler.SetFov(cameraInitializeFov);
	}

	// Token: 0x06012C78 RID: 76920 RVA: 0x0052E604 File Offset: 0x0052C804
	private void ChangeFov(float changeValue)
	{
		UUISliderComponent slider = base.GetSlider(5);
		float inValue = slider.GetValue() + changeValue;
		slider.SetValue(inValue, true);
	}

	// Token: 0x06012C79 RID: 76921 RVA: 0x0052E628 File Offset: 0x0052C828
	private void OnCloseButtonClick()
	{
		if (this.PhotographStart)
		{
			return;
		}
		QtaViewHandler qtaViewHandler = this.QtaViewHandler;
		if (qtaViewHandler != null)
		{
			qtaViewHandler.SetResult(EQtaResult.Fail);
		}
		if (this.IsFilterEnabled && this.BpFilterFx != null && this.BpFilterFx.IsValid())
		{
			this.BpFilterFx.K2_DestroyActor();
			this.BpFilterFx = null;
		}
		base.CloseMe(null);
	}

	// Token: 0x06012C7A RID: 76922 RVA: 0x0052E686 File Offset: 0x0052C886
	private void UpdateSaveToggle(bool state)
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ShouldSaveCaptureCollectFlag, state);
		this.ShouldSavePhoto = state;
	}

	// Token: 0x06012C7B RID: 76923 RVA: 0x0052E69C File Offset: 0x0052C89C
	private void OnPhotographButtonClicked()
	{
		if (this.PhotographStart || !base.IsShowOrShowing)
		{
			return;
		}
		this.PhotographStart = true;
		QtaViewHandler qtaViewHandler = this.QtaViewHandler;
		if (qtaViewHandler != null)
		{
			qtaViewHandler.SetResult(EQtaResult.Success);
		}
		if (this.ShouldSavePhoto && !Singleton<Info>.Instance.IsXSXPlatform())
		{
			base.SetUiActive(false);
			ControllerBase<PhotographController>.Instance.ScreenShot(new PhotoSaveViewParam
			{
				ScreenShot = true,
				PrepareFullScreenShot = true,
				IsHiddenBattleView = false,
				ShareId = 1
			});
			return;
		}
		this.QuickShotDone();
	}

	// Token: 0x06012C7C RID: 76924 RVA: 0x0052E724 File Offset: 0x0052C924
	private UniTask QuickShotDone()
	{
		CaptureCollectView.<QuickShotDone>d__65 <QuickShotDone>d__;
		<QuickShotDone>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<QuickShotDone>d__.<>4__this = this;
		<QuickShotDone>d__.<>1__state = -1;
		<QuickShotDone>d__.<>t__builder.Start<CaptureCollectView.<QuickShotDone>d__65>(ref <QuickShotDone>d__);
		return <QuickShotDone>d__.<>t__builder.Task;
	}

	// Token: 0x06012C7D RID: 76925 RVA: 0x0052E767 File Offset: 0x0052C967
	private void OnScreenShotDone()
	{
		this.DelayTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.DelayTimer = null;
			this.EndView();
		}, 50f, null, null, true, 1f);
	}

	// Token: 0x06012C7E RID: 76926 RVA: 0x0052E792 File Offset: 0x0052C992
	private void EndView()
	{
		ControllerBase<SceneItemCaptureController>.Instance.CollectItemsInViewport();
		LevelEventCaptureRequest.CollectInViewport();
		if (this.IsFilterEnabled)
		{
			this.EnableFilterFx(false);
			this.SetupRangeFilterFx();
		}
		base.CloseMe(null);
	}

	// Token: 0x06012C7F RID: 76927 RVA: 0x0052E7BF File Offset: 0x0052C9BF
	private void RemoveDelayTimer()
	{
		if (this.DelayTimer == null)
		{
			return;
		}
		TimerSystem.Instance.Remove(this.DelayTimer);
		this.DelayTimer = null;
	}

	// Token: 0x06012C80 RID: 76928 RVA: 0x0052E7E2 File Offset: 0x0052C9E2
	public void SetQtaParam(QtaViewParam qtaParam)
	{
		this.QtaViewHandler = new QtaViewHandler(qtaParam);
	}

	// Token: 0x06012C81 RID: 76929 RVA: 0x0052E7F0 File Offset: 0x0052C9F0
	private void EnableTipsItem(bool b)
	{
		ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildVisible(EBattleUiVisibleReason.SpecialSkill, EBattleUiChild.InteractionHint, !b, true, 0);
		if (b)
		{
			Singleton<EventSystem>.Instance.Emit<bool, string>(EEventName.ShowItemTips, true, string.Empty);
			Singleton<EventSystem>.Instance.Emit(EEventName.HideInteractView);
			return;
		}
		Singleton<EventSystem>.Instance.Emit<bool, string>(EEventName.ShowItemTips, false, string.Empty);
		Singleton<EventSystem>.Instance.Emit(EEventName.InteractionViewUpdate);
	}

	// Token: 0x06012C82 RID: 76930 RVA: 0x0052E868 File Offset: 0x0052CA68
	private void OnFilterButtonClicked()
	{
		if (!base.IsShowOrShowing)
		{
			return;
		}
		if (Singleton<Time>.Instance.Now - this.LastTime < 500.0)
		{
			return;
		}
		this.LastTime = Singleton<Time>.Instance.Now;
		this.EnableFilterFx(!this.IsFilterEnabled);
		if (this.BpFilterFx == null)
		{
			Singleton<ResourceSystem>.Instance.LoadTypeAsync("BP_PhotoCutFilterPostProcess_C", new Action(this.InitFilterFx), "js_undefined");
		}
	}

	// Token: 0x06012C83 RID: 76931 RVA: 0x0052E8E4 File Offset: 0x0052CAE4
	private void InitFilterFx()
	{
		this.BpFilterFx = Singleton<ActorSystem>.Instance.Get<BP_PhotoCutFilterPostProcess_C>(BP_PhotoCutFilterPostProcess_C.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true);
		if (this.BpFilterFx == null)
		{
			return;
		}
		this.CameraClipMaskIntOrg = (int)this.BpFilterFx.CameraClipMaskInt;
		this.BpFilterFx.SetUpPostProcess();
		if (this.IsFilterEnabled && !this.PhotographStart)
		{
			this.EnableFilterFx(this.IsFilterEnabled);
		}
	}

	// Token: 0x06012C84 RID: 76932 RVA: 0x0052E954 File Offset: 0x0052CB54
	private void EnableFilterFx(bool b)
	{
		this.IsFilterEnabled = b;
		if (this.BpFilterFx == null)
		{
			return;
		}
		base.GetItem(10).SetUIActive(this.IsFilterEnabled);
		base.GetItem(11).SetUIActive(!this.IsFilterEnabled);
		UMaterialInstanceDynamic postProcessMI = this.BpFilterFx.PostProcessMI;
		if (postProcessMI != null)
		{
			postProcessMI.SetScalarParameterValue(this.MatParam1, (float)(b ? this.CameraClipMaskIntOrg : 0));
		}
		this.BpFilterFx.IsTickEnd = false;
		this.BpFilterFx.UseScreenUV = b;
		this.BpFilterFx.SwitchScreenUV();
	}

	// Token: 0x06012C85 RID: 76933 RVA: 0x0052E9E8 File Offset: 0x0052CBE8
	private void SetupRangeFilterFx()
	{
		if (this.BpFilterFx == null)
		{
			return;
		}
		APlayerCameraManager characterCameraManager = Global.CharacterCameraManager;
		AActor target = characterCameraManager.ViewTarget.Target;
		UCameraComponent ucameraComponent = ((target != null) ? target.GetComponentByClass(UCameraComponent.StaticClass()) : null) as UCameraComponent;
		if (ucameraComponent == null)
		{
			return;
		}
		this.BpFilterFx.UseScreenUV = false;
		this.BpFilterFx.SwitchScreenUV();
		this.BpFilterFx.UpdateFxParams(characterCameraManager.D_GetCameraLocation(), characterCameraManager.GetCameraRotation(), ucameraComponent.AspectRatio, ucameraComponent.FieldOfView);
		this.BpFilterFx.SetUpPostProcess();
		this.BpFilterFx.DelayToFadeOut();
	}

	// Token: 0x04009286 RID: 37510
	private const int CHANGE_FOV_INTERVAL = 100;

	// Token: 0x04009287 RID: 37511
	private TimerHandle ChangeFovTimerId;

	// Token: 0x04009288 RID: 37512
	private FVector? LastMoveVector;

	// Token: 0x04009289 RID: 37513
	private float ControlCameraRate;

	// Token: 0x0400928A RID: 37514
	private bool InDragMove;

	// Token: 0x0400928B RID: 37515
	private bool VisibleMode = true;

	// Token: 0x0400928C RID: 37516
	private float MinFov = 30f;

	// Token: 0x0400928D RID: 37517
	private float MaxFov = 90f;

	// Token: 0x0400928E RID: 37518
	private float CameraZoomSpeed = 1f;

	// Token: 0x0400928F RID: 37519
	private PopupCaptionItem CaptionItem;

	// Token: 0x04009290 RID: 37520
	[Nullable(1)]
	private readonly PopupCaptionToggleItem ToggleTabItem = new PopupCaptionToggleItem();

	// Token: 0x04009291 RID: 37521
	private bool PhotographStart;

	// Token: 0x04009292 RID: 37522
	private BP_PhotoCutFilterPostProcess_C BpFilterFx;

	// Token: 0x04009293 RID: 37523
	[Nullable(new byte[]
	{
		2,
		1
	})]
	[StaticVariableRuleIgnore]
	private static WeakReference<BP_PhotoCutFilterPostProcess_C> WeakRefLastBpFilterFx;

	// Token: 0x04009294 RID: 37524
	private bool ShouldSavePhoto;

	// Token: 0x04009295 RID: 37525
	private QtaViewHandler QtaViewHandler;

	// Token: 0x04009296 RID: 37526
	[Nullable(1)]
	protected BattleUiTweenAnimPlayer TweenAnimPlayer = new BattleUiTweenAnimPlayer();

	// Token: 0x04009297 RID: 37527
	private bool IsFilterEnabled;

	// Token: 0x04009298 RID: 37528
	private double LastTime;

	// Token: 0x04009299 RID: 37529
	private readonly FName MatParam1 = new FName("CameraClipMaskInt");

	// Token: 0x0400929A RID: 37530
	private int CameraClipMaskIntOrg = -1;

	// Token: 0x0400929B RID: 37531
	private TimerHandle DelayTimer;

	// Token: 0x020088EE RID: 35054
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402E39B RID: 189339
		public const int CaptionItem = 0;

		// Token: 0x0402E39C RID: 189340
		public const int ToggleSaveItem = 1;

		// Token: 0x0402E39D RID: 189341
		public const int PhotographButton = 2;

		// Token: 0x0402E39E RID: 189342
		public const int FilterButton = 3;

		// Token: 0x0402E39F RID: 189343
		public const int AddButton = 4;

		// Token: 0x0402E3A0 RID: 189344
		public const int CameraFovSlider = 5;

		// Token: 0x0402E3A1 RID: 189345
		public const int ReduceButton = 6;

		// Token: 0x0402E3A2 RID: 189346
		public const int ControlScreenDraggable = 7;

		// Token: 0x0402E3A3 RID: 189347
		public const int AniIn = 8;

		// Token: 0x0402E3A4 RID: 189348
		public const int AniOut = 9;

		// Token: 0x0402E3A5 RID: 189349
		public const int FilterIcon1 = 10;

		// Token: 0x0402E3A6 RID: 189350
		public const int FilterIcon2 = 11;

		// Token: 0x0402E3A7 RID: 189351
		public const int AniPhotoTake = 12;
	}
}
