using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.GamePlay.DollGrab;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006EEA RID: 28394
	[NullableContext(2)]
	[Nullable(0)]
	public class DollGrabMachineView : UiTickViewBase
	{
		// Token: 0x06044D21 RID: 281889 RVA: 0x011E7B30 File Offset: 0x011E5D30
		[NullableContext(1)]
		public DollGrabMachineView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044D22 RID: 281890 RVA: 0x011E7B50 File Offset: 0x011E5D50
		protected unsafe override void OnRegisterComponent()
		{
			int num = 19;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClawButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06044D23 RID: 281891 RVA: 0x011E7E34 File Offset: 0x011E6034
		protected override UniTask OnBeforeStartAsync()
		{
			DollGrabMachineView.<OnBeforeStartAsync>d__28 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DollGrabMachineView.<OnBeforeStartAsync>d__28>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044D24 RID: 281892 RVA: 0x011E7E78 File Offset: 0x011E6078
		protected override UniTask OnBeforeShowAsyncImplementImplement()
		{
			DollGrabMachineView.<OnBeforeShowAsyncImplementImplement>d__29 <OnBeforeShowAsyncImplementImplement>d__;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<DollGrabMachineView.<OnBeforeShowAsyncImplementImplement>d__29>(ref <OnBeforeShowAsyncImplementImplement>d__);
			return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06044D25 RID: 281893 RVA: 0x011E7EBC File Offset: 0x011E60BC
		private void InitTimeBar()
		{
			this.SldBar = base.GetSlider(7);
			this.SldBarAdd = base.GetSlider(8);
			UUISliderComponent sldBar = this.SldBar;
			if (sldBar != null)
			{
				sldBar.SetValue(1f, true);
			}
			UUISliderComponent sldBarAdd = this.SldBarAdd;
			if (sldBarAdd != null)
			{
				sldBarAdd.SetValue(0f, true);
			}
			this.PnlBar = base.GetItem(14);
			UUIItem pnlBar = this.PnlBar;
			if (pnlBar != null)
			{
				pnlBar.SetUIActive(false);
			}
			UUIItem pnlAddTimeTxt = this.PnlAddTimeTxt;
			if (pnlAddTimeTxt != null)
			{
				pnlAddTimeTxt.SetUIActive(false);
			}
			this.SprPoint = base.GetSprite(17);
			this.SprFill = base.GetSprite(16);
			this.SprPointOriginalColor = new FColor?(this.SprPoint.Color);
			this.SprPointChangeColor = new FColor?(this.SprPoint.changeColor);
		}

		// Token: 0x06044D26 RID: 281894 RVA: 0x011E7F8C File Offset: 0x011E618C
		protected override void OnBeforeHide()
		{
			this.RemoveEventListener();
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DollGrabFloatCountDownView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.DollGrabFloatCountDownView, null);
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DollGrabMachineSeltView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.DollGrabMachineSeltView, null);
			}
			this.UnbindAllInput();
			if (this.MobileJoystick != null)
			{
				this.MobileJoystick.Reset();
				this.MobileJoystick.HideBattleVisibleChildView();
				this.MobileJoystick = null;
			}
		}

		// Token: 0x06044D27 RID: 281895 RVA: 0x011E800C File Offset: 0x011E620C
		[NullableContext(1)]
		private void OpenViewCamera(Action finishCallback)
		{
			Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
			FVector 相机位置 = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig.相机位置;
			commonTempVector.FromUeVector(相机位置);
			Rotator commonTempRotator = Singleton<MathUtils>.Instance.CommonTempRotator;
			FRotator 相机旋转 = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig.相机旋转;
			commonTempRotator.FromUeRotator(相机旋转);
			DollGrabCameraConfig cameraInfo = new DollGrabCameraConfig(Singleton<MathUtils>.Instance.CommonTempVector, Singleton<MathUtils>.Instance.CommonTempRotator, ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig.淡入时间, ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig.淡出时间, ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig.关闭镜头碰撞, ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig.关闭镜头虚化, ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig.Fov);
			SceneItemActorComponent component = ControllerBase<DollGrabMachineController>.Instance.CurrentDollGrabMachineComponent.Entity.GetComponent<SceneItemActorComponent>();
			ModelBase<DollGrabModel>.Instance.ExecuteAdjustPlayerCamera(component, cameraInfo, "DollGrabMachineFixCamera", delegate(ELevelEventState result)
			{
				if (result == ELevelEventState.Success)
				{
					finishCallback();
				}
			});
		}

		// Token: 0x06044D28 RID: 281896 RVA: 0x011E8100 File Offset: 0x011E6300
		private UniTask InitMobileJoystick()
		{
			DollGrabMachineView.<InitMobileJoystick>d__33 <InitMobileJoystick>d__;
			<InitMobileJoystick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMobileJoystick>d__.<>4__this = this;
			<InitMobileJoystick>d__.<>1__state = -1;
			<InitMobileJoystick>d__.<>t__builder.Start<DollGrabMachineView.<InitMobileJoystick>d__33>(ref <InitMobileJoystick>d__);
			return <InitMobileJoystick>d__.<>t__builder.Task;
		}

		// Token: 0x06044D29 RID: 281897 RVA: 0x011E8143 File Offset: 0x011E6343
		private void OnShowTypeChange(EOperationType last, EOperationType now)
		{
			if (now == EOperationType.Pad)
			{
				this.BindTouchInput();
				return;
			}
			this.UnbindTouchInput();
		}

		// Token: 0x06044D2A RID: 281898 RVA: 0x011E8158 File Offset: 0x011E6358
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			EBoundInputMode eboundInputMode = EBoundInputMode.None;
			if (Singleton<Info>.Instance.IsInTouch())
			{
				eboundInputMode = EBoundInputMode.Touch;
			}
			else if (Singleton<Info>.Instance.IsInGamepad())
			{
				eboundInputMode = EBoundInputMode.Gamepad;
			}
			else if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				eboundInputMode = EBoundInputMode.MouseKeyboard;
			}
			if (eboundInputMode == this.CurrentInputMode)
			{
				return;
			}
			this.UnbindAllInput();
			this.CurrentInputMode = eboundInputMode;
			switch (eboundInputMode)
			{
			case EBoundInputMode.MouseKeyboard:
				this.BindKeyBoardInput();
				return;
			case EBoundInputMode.Touch:
				this.BindTouchInput();
				return;
			case EBoundInputMode.Gamepad:
				this.BindGamepadInput();
				return;
			default:
				return;
			}
		}

		// Token: 0x06044D2B RID: 281899 RVA: 0x011E81D8 File Offset: 0x011E63D8
		private void BindKeyBoardInput()
		{
			ControllerBase<InputDistributeController>.Instance.BindAction("UI方向上", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI方向下", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI方向左", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI方向右", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
		}

		// Token: 0x06044D2C RID: 281900 RVA: 0x011E8254 File Offset: 0x011E6454
		private void UnbindKeyBoardInput()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI方向上", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI方向下", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI方向左", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI方向右", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
		}

		// Token: 0x06044D2D RID: 281901 RVA: 0x011E82CD File Offset: 0x011E64CD
		private void BindTouchInput()
		{
			if (this.MobileJoystick == null)
			{
				this.InitMobileJoystick();
				return;
			}
			this.MobileJoystick.ShowBattleVisibleChildView();
		}

		// Token: 0x06044D2E RID: 281902 RVA: 0x011E82EA File Offset: 0x011E64EA
		private void UnbindTouchInput()
		{
			if (this.MobileJoystick != null)
			{
				this.MobileJoystick.HideBattleVisibleChildView();
				return;
			}
			UUIItem item = base.GetItem(6);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06044D2F RID: 281903 RVA: 0x011E8312 File Offset: 0x011E6512
		private void BindGamepadInput()
		{
			ControllerBase<InputDistributeController>.Instance.BindAxis("NavigationTopDown", new TInputHandle<float>(this.OnAxis));
			ControllerBase<InputDistributeController>.Instance.BindAxis("NavigationLeftRight", new TInputHandle<float>(this.OnAxis));
		}

		// Token: 0x06044D30 RID: 281904 RVA: 0x011E834A File Offset: 0x011E654A
		private void UnbindGamepadInput()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("NavigationTopDown", new TInputHandle<float>(this.OnAxis));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("NavigationLeftRight", new TInputHandle<float>(this.OnAxis));
		}

		// Token: 0x06044D31 RID: 281905 RVA: 0x011E8384 File Offset: 0x011E6584
		private void UnbindAllInput()
		{
			switch (this.CurrentInputMode)
			{
			case EBoundInputMode.MouseKeyboard:
				this.UnbindKeyBoardInput();
				return;
			case EBoundInputMode.Touch:
				this.UnbindTouchInput();
				return;
			case EBoundInputMode.Gamepad:
				this.UnbindGamepadInput();
				return;
			default:
				return;
			}
		}

		// Token: 0x06044D32 RID: 281906 RVA: 0x011E83C4 File Offset: 0x011E65C4
		protected override void OnTick(float delta)
		{
			if (Singleton<TickSystem>.Instance.IsPaused || this.SldBar == null || this.SldBarAdd == null || !ControllerBase<DollGrabMachineController>.Instance.IsGameplayReady)
			{
				return;
			}
			DollGrabMachineJoystick mobileJoystick = this.MobileJoystick;
			if (mobileJoystick != null)
			{
				mobileJoystick.Tick(delta);
			}
			float num = ControllerBase<DollGrabMachineController>.Instance.RemainingTime / ControllerBase<DollGrabMachineController>.Instance.RemainingTimeLimit;
			UUISliderComponent sldBar = this.SldBar;
			if (sldBar != null)
			{
				sldBar.SetValue(num, true);
			}
			UUISliderComponent sldBarAdd = this.SldBarAdd;
			if (sldBarAdd == null)
			{
				return;
			}
			sldBarAdd.SetValue(num - ControllerBase<DollGrabMachineController>.Instance.AddRemainingTime / ControllerBase<DollGrabMachineController>.Instance.RemainingTimeLimit, true);
		}

		// Token: 0x06044D33 RID: 281907 RVA: 0x011E8460 File Offset: 0x011E6660
		protected void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<Action>(EEventName.OnDollGrabMachineStartCoolDown, new Action<Action>(this.OnDollGrabMachineStartCoolDown));
			Singleton<EventSystem>.Instance.Add<EDollGrabMachineEndReason>(EEventName.OnDollGrabMachineEnd, new Action<EDollGrabMachineEndReason>(this.OnDollGrabMachineEnd));
			Singleton<EventSystem>.Instance.Add(EEventName.OnDollGrabMachineRestart, new Action(this.OnDollGrabMachineRestart));
			Singleton<EventSystem>.Instance.Add<EDollGrabMachineClawState>(EEventName.OnDollGrabMachineClawStateStart, new Action<EDollGrabMachineClawState>(this.OnDollGrabMachineClawStateStart));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnDollGrabMachineGrabbingActorChanged, new Action<bool>(this.OnDollGrabMachineGrabbingActorChanged));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.OnDollGrabMachineRemainingTimeAdd, new Action<float>(this.OnDollGrabMachineRemainingTimeAdd));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnDollGrabMachineDangerousCountdown, new Action<bool>(this.OnDollGrabMachineDangerousCountdown));
			Singleton<EventSystem>.Instance.Add<EOperationType, EOperationType>(EEventName.ShowTypeChange, new Action<EOperationType, EOperationType>(this.OnShowTypeChange));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			if (ControllerBase<DollGrabMachineController>.Instance.IsEndlessMode)
			{
				Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnDollGrabMachineEndlessScoreChanged, new Action<int, int>(this.OnDollGrabMachineEndlessScoreChanged));
				return;
			}
			Singleton<EventSystem>.Instance.Add<int, List<IGrabItemData>>(EEventName.OnDollGrabMachineGrabDoll, new Action<int, List<IGrabItemData>>(this.OnDollGrabMachineGrabDoll));
		}

		// Token: 0x06044D34 RID: 281908 RVA: 0x011E85B0 File Offset: 0x011E67B0
		protected void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<Action>(EEventName.OnDollGrabMachineStartCoolDown, new Action<Action>(this.OnDollGrabMachineStartCoolDown));
			Singleton<EventSystem>.Instance.Remove<EDollGrabMachineEndReason>(EEventName.OnDollGrabMachineEnd, new Action<EDollGrabMachineEndReason>(this.OnDollGrabMachineEnd));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnDollGrabMachineRestart, new Action(this.OnDollGrabMachineRestart));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnDollGrabMachineGrabbingActorChanged, new Action<bool>(this.OnDollGrabMachineGrabbingActorChanged));
			Singleton<EventSystem>.Instance.Remove<float>(EEventName.OnDollGrabMachineRemainingTimeAdd, new Action<float>(this.OnDollGrabMachineRemainingTimeAdd));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnDollGrabMachineDangerousCountdown, new Action<bool>(this.OnDollGrabMachineDangerousCountdown));
			Singleton<EventSystem>.Instance.Remove<EOperationType, EOperationType>(EEventName.ShowTypeChange, new Action<EOperationType, EOperationType>(this.OnShowTypeChange));
			Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			if (ControllerBase<DollGrabMachineController>.Instance.IsEndlessMode)
			{
				Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnDollGrabMachineEndlessScoreChanged, new Action<int, int>(this.OnDollGrabMachineEndlessScoreChanged));
			}
			else
			{
				Singleton<EventSystem>.Instance.Remove<int, List<IGrabItemData>>(EEventName.OnDollGrabMachineGrabDoll, new Action<int, List<IGrabItemData>>(this.OnDollGrabMachineGrabDoll));
			}
			if (Singleton<EventSystem>.Instance.Has<EDollGrabMachineClawState>(EEventName.OnDollGrabMachineClawStateStart, new Action<EDollGrabMachineClawState>(this.OnDollGrabMachineClawStateStart)))
			{
				Singleton<EventSystem>.Instance.Remove<EDollGrabMachineClawState>(EEventName.OnDollGrabMachineClawStateStart, new Action<EDollGrabMachineClawState>(this.OnDollGrabMachineClawStateStart));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnDollGrabMachineEndCoolDown, new Action(this.OnDollGrabMachineCountDownEnd)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnDollGrabMachineEndCoolDown, new Action(this.OnDollGrabMachineCountDownEnd));
			}
		}

		// Token: 0x06044D35 RID: 281909 RVA: 0x011E8758 File Offset: 0x011E6958
		private void OnDollGrabMachineStartCoolDown(Action callback)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DollGrabMachineSeltView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.DollGrabMachineSeltView, null);
			}
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Btn_GrabDoll_Text");
			UUIText clawBtnText = this.ClawBtnText;
			if (clawBtnText != null)
			{
				clawBtnText.SetText(multiTextByKey ?? "抓取", true);
			}
			UUIText clawBtnText2 = this.ClawBtnText;
			if (clawBtnText2 != null)
			{
				clawBtnText2.SetUIActive(true);
			}
			this.SwitchClawButtonState(EClawButtonState.Grab);
			UUIButtonComponent clawBtn = this.ClawBtn;
			if (clawBtn != null)
			{
				clawBtn.SetSelfInteractive(false);
			}
			UUIItem pnlCost = this.PnlCost;
			if (pnlCost != null)
			{
				pnlCost.SetUIActive(false);
			}
			TsInteractionUtils.RegisterOpenViewName(EUiViewName.DollGrabMachineCountDownView);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DollGrabMachineCountDownView, null, null);
			this.CountDownCallback = callback;
			Singleton<EventSystem>.Instance.Once(EEventName.OnDollGrabMachineEndCoolDown, new Action(this.OnDollGrabMachineCountDownEnd));
		}

		// Token: 0x06044D36 RID: 281910 RVA: 0x011E8830 File Offset: 0x011E6A30
		private void OnDollGrabMachineCountDownEnd()
		{
			Action countDownCallback = this.CountDownCallback;
			if (countDownCallback != null)
			{
				countDownCallback();
			}
			this.CountDownCallback = null;
			UUIButtonComponent clawBtn = this.ClawBtn;
			if (clawBtn != null)
			{
				clawBtn.SetSelfInteractive(true);
			}
			UUISliderComponent sldBar = this.SldBar;
			if (sldBar != null)
			{
				sldBar.SetValue(1f, true);
			}
			UUISliderComponent sldBarAdd = this.SldBarAdd;
			if (sldBarAdd != null)
			{
				sldBarAdd.SetValue(0f, true);
			}
			UUIItem pnlBar = this.PnlBar;
			if (pnlBar != null)
			{
				pnlBar.SetUIActive(true);
			}
			if (!Singleton<EventSystem>.Instance.Has<EDollGrabMachineClawState>(EEventName.OnDollGrabMachineClawStateStart, new Action<EDollGrabMachineClawState>(this.OnDollGrabMachineClawStateStart)))
			{
				Singleton<EventSystem>.Instance.Add<EDollGrabMachineClawState>(EEventName.OnDollGrabMachineClawStateStart, new Action<EDollGrabMachineClawState>(this.OnDollGrabMachineClawStateStart));
			}
			if (this.CurrentInputMode == EBoundInputMode.Touch)
			{
				DollGrabMachineJoystick mobileJoystick = this.MobileJoystick;
				if (mobileJoystick == null)
				{
					return;
				}
				mobileJoystick.ShowBattleVisibleChildView();
			}
		}

		// Token: 0x06044D37 RID: 281911 RVA: 0x011E88F9 File Offset: 0x011E6AF9
		[NullableContext(1)]
		private void OnAxis(string axisName, float value)
		{
			ControllerBase<DollGrabMachineController>.Instance.OnAxisMoveInput(axisName, value);
		}

		// Token: 0x06044D38 RID: 281912 RVA: 0x011E8907 File Offset: 0x011E6B07
		[NullableContext(1)]
		private void OnAxis(string axisName, float value, InputIdentification inputIdentification)
		{
			this.OnAxis(axisName, value);
		}

		// Token: 0x06044D39 RID: 281913 RVA: 0x011E8914 File Offset: 0x011E6B14
		[NullableContext(1)]
		private unsafe void OnInput(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionName == "UI方向上")
			{
				ControllerBase<DollGrabMachineController>.Instance.OnClickMoveInput("向前移动", actionType);
			}
			else if (actionName == "UI方向下")
			{
				ControllerBase<DollGrabMachineController>.Instance.OnClickMoveInput("向后移动", actionType);
			}
			else if (actionName == "UI方向左")
			{
				ControllerBase<DollGrabMachineController>.Instance.OnClickMoveInput("向左移动", actionType);
			}
			else if (actionName == "UI方向右")
			{
				ControllerBase<DollGrabMachineController>.Instance.OnClickMoveInput("向右移动", actionType);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.DollGrabMachine;
			ELogAuthor author = ELogAuthor.FJH;
			string message = "[input] OnInput";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionName", actionName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionType", actionType.ToString());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06044D3A RID: 281914 RVA: 0x011E89FD File Offset: 0x011E6BFD
		private void OnClawButtonClick()
		{
			if (!ControllerBase<DollGrabMachineController>.Instance.IsGameplayReady)
			{
				ControllerBase<DollGrabMachineController>.Instance.OnClickStart();
				return;
			}
			ControllerBase<DollGrabMachineController>.Instance.OnClickGrab();
		}

		// Token: 0x06044D3B RID: 281915 RVA: 0x011E8A20 File Offset: 0x011E6C20
		private void OnDollGrabMachineEnd(EDollGrabMachineEndReason endReason)
		{
			switch (endReason)
			{
			case EDollGrabMachineEndReason.TimeUp:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.DollGrabMachineTimeUpView, null, null);
				break;
			case EDollGrabMachineEndReason.GetAll:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.DollGrabMachineGetAllView, null, null);
				break;
			case EDollGrabMachineEndReason.Exit:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.DollGrabMachineSeltView, null, null);
				break;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DollGrabFloatCountDownView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.DollGrabFloatCountDownView, null);
			}
			UUIItem pnlBar = this.PnlBar;
			if (pnlBar != null)
			{
				pnlBar.SetUIActive(false);
			}
			UUIButtonComponent clawBtn = this.ClawBtn;
			if (clawBtn != null)
			{
				clawBtn.SetSelfInteractive(false);
			}
			if (this.CurrentInputMode == EBoundInputMode.Touch)
			{
				DollGrabMachineJoystick mobileJoystick = this.MobileJoystick;
				if (mobileJoystick != null)
				{
					mobileJoystick.HideBattleVisibleChildView();
				}
			}
			if (ControllerBase<DollGrabMachineController>.Instance.IsEndlessMode)
			{
				this.RefreshEndlessView();
			}
		}

		// Token: 0x06044D3C RID: 281916 RVA: 0x011E8AEC File Offset: 0x011E6CEC
		private void OnDollGrabMachineRestart()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DollGrabMachineSeltView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.DollGrabMachineSeltView, null);
			}
			if (ControllerBase<DollGrabMachineController>.Instance.IsEndlessMode)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(this.ClawBtnText, "Btn_GrabDoll_Text", Array.Empty<object>());
				UUIText clawBtnText = this.ClawBtnText;
				if (clawBtnText != null)
				{
					clawBtnText.SetUIActive(true);
				}
				this.SwitchClawButtonState(EClawButtonState.Grab);
				UUIButtonComponent clawBtn = this.ClawBtn;
				if (clawBtn != null)
				{
					clawBtn.SetSelfInteractive(false);
				}
				Singleton<UiManager>.Instance.OpenView(EUiViewName.DollGrabEndlessStartView, null, null);
			}
			else
			{
				UUIText clawBtnText2 = this.ClawBtnText;
				if (clawBtnText2 != null)
				{
					clawBtnText2.SetUIActive(false);
				}
				this.SwitchClawButtonState(EClawButtonState.InsertCoin);
				UUIItem pnlCost = this.PnlCost;
				if (pnlCost != null)
				{
					pnlCost.SetUIActive(true);
				}
				UUIButtonComponent clawBtn2 = this.ClawBtn;
				if (clawBtn2 != null)
				{
					clawBtn2.SetSelfInteractive(true);
				}
			}
			this.OnDollGrabMachineDangerousCountdown(false);
		}

		// Token: 0x06044D3D RID: 281917 RVA: 0x011E8BC4 File Offset: 0x011E6DC4
		private void OnDollGrabMachineClawStateStart(EDollGrabMachineClawState state)
		{
			if (!ControllerBase<DollGrabMachineController>.Instance.IsGameplayReady)
			{
				return;
			}
			switch (state)
			{
			case EDollGrabMachineClawState.Idle:
			{
				UUIButtonComponent clawBtn = this.ClawBtn;
				if (clawBtn != null)
				{
					clawBtn.SetSelfInteractive(true);
				}
				if (ControllerBase<DollGrabMachineController>.Instance.HasGrabbingActor)
				{
					string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Btn_ReleaseClaw_Text");
					UUIText clawBtnText = this.ClawBtnText;
					if (clawBtnText != null)
					{
						clawBtnText.SetText(multiTextByKey ?? "松开", true);
					}
					this.SwitchClawButtonState(EClawButtonState.Release);
					return;
				}
				string multiTextByKey2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Btn_GrabDoll_Text");
				UUIText clawBtnText2 = this.ClawBtnText;
				if (clawBtnText2 != null)
				{
					clawBtnText2.SetText(multiTextByKey2 ?? "抓取", true);
				}
				this.SwitchClawButtonState(EClawButtonState.Grab);
				break;
			}
			case EDollGrabMachineClawState.MovingDown:
			case EDollGrabMachineClawState.Release:
			{
				UUIButtonComponent clawBtn2 = this.ClawBtn;
				if (clawBtn2 == null)
				{
					return;
				}
				clawBtn2.SetSelfInteractive(false);
				return;
			}
			case EDollGrabMachineClawState.MovingUp:
			case EDollGrabMachineClawState.Grabbing:
				break;
			default:
				return;
			}
		}

		// Token: 0x06044D3E RID: 281918 RVA: 0x011E8C90 File Offset: 0x011E6E90
		private void OnDollGrabMachineGrabbingActorChanged(bool hasGrabbingActor)
		{
			if (hasGrabbingActor)
			{
				EDollGrabMachineClawState? clawState = ControllerBase<DollGrabMachineController>.Instance.ClawState;
				EDollGrabMachineClawState edollGrabMachineClawState = EDollGrabMachineClawState.Idle;
				if (clawState.GetValueOrDefault() == edollGrabMachineClawState & clawState != null)
				{
					string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Btn_ReleaseClaw_Text");
					UUIText clawBtnText = this.ClawBtnText;
					if (clawBtnText != null)
					{
						clawBtnText.SetText(multiTextByKey ?? "松开", true);
					}
					this.SwitchClawButtonState(EClawButtonState.Release);
					return;
				}
			}
			if (!hasGrabbingActor)
			{
				EDollGrabMachineClawState? clawState = ControllerBase<DollGrabMachineController>.Instance.ClawState;
				EDollGrabMachineClawState edollGrabMachineClawState = EDollGrabMachineClawState.Idle;
				if (clawState.GetValueOrDefault() == edollGrabMachineClawState & clawState != null)
				{
					string multiTextByKey2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Btn_GrabDoll_Text");
					UUIText clawBtnText2 = this.ClawBtnText;
					if (clawBtnText2 != null)
					{
						clawBtnText2.SetText(multiTextByKey2 ?? "抓取", true);
					}
					this.SwitchClawButtonState(EClawButtonState.Grab);
				}
			}
		}

		// Token: 0x06044D3F RID: 281919 RVA: 0x011E8D4C File Offset: 0x011E6F4C
		private void OnDollGrabMachineRemainingTimeAdd(float remainingTime)
		{
			UUIItem pnlAddTimeTxt = this.PnlAddTimeTxt;
			if (pnlAddTimeTxt != null)
			{
				pnlAddTimeTxt.SetUIActive(true);
			}
			UUIArtText addTimeTxt = this.AddTimeTxt;
			if (addTimeTxt != null)
			{
				addTimeTxt.SetText("+" + (remainingTime / 1000f).ToString() + "s");
			}
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayLevelSequenceByName("Time_Up", false, null, false);
		}

		// Token: 0x06044D40 RID: 281920 RVA: 0x011E8DBC File Offset: 0x011E6FBC
		[NullableContext(1)]
		private void OnDollGrabMachineGrabDoll(int leaveDollCount, List<IGrabItemData> grabItemDataList)
		{
			ItemHintViewNewData itemHintViewNewData = new ItemHintViewNewData();
			this.ReceiveItemList.AddRange(grabItemDataList);
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ItemHintViewNew))
			{
				return;
			}
			itemHintViewNewData.CheckPriorNext = (() => this.ReceiveItemList.Count > 0);
			itemHintViewNewData.ShiftPriorItem = delegate()
			{
				IGrabItemData grabItemData = this.ReceiveItemList[0];
				this.ReceiveItemList.RemoveAt(0);
				ItemRewardInfo itemRewardInfo = new ItemRewardInfo();
				itemRewardInfo.ItemId = new int?(grabItemData.ItemId);
				itemRewardInfo.ItemCount = new int?(grabItemData.Count);
				ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(grabItemData.ItemId);
				itemRewardInfo.Quality = itemConfigData.QualityId;
				return itemRewardInfo;
			};
			Singleton<UiManager>.Instance.OpenViewAsync(EUiViewName.ItemHintViewNew, itemHintViewNewData, null).ContinueWith(delegate(int? viewId)
			{
				bool flag = viewId != null;
			}).Forget();
		}

		// Token: 0x06044D41 RID: 281921 RVA: 0x011E8E54 File Offset: 0x011E7054
		private void OnDollGrabMachineEndlessScoreChanged(int newScore, int addScore)
		{
			UUIArtText endlessScoreText = this.EndlessScoreText;
			if (endlessScoreText != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(newScore);
				endlessScoreText.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			UUIArtText endlessScoreAddText = this.EndlessScoreAddText;
			if (endlessScoreAddText != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<int>(addScore);
				endlessScoreAddText.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			UUIItem endlessScoreAddItem = this.EndlessScoreAddItem;
			if (endlessScoreAddItem != null)
			{
				endlessScoreAddItem.SetUIActive(true);
			}
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayLevelSequenceByName("Score_Up", false, null, false);
		}

		// Token: 0x06044D42 RID: 281922 RVA: 0x011E8EF1 File Offset: 0x011E70F1
		private void RefreshEndlessView()
		{
			UUIArtText endlessScoreText = this.EndlessScoreText;
			if (endlessScoreText != null)
			{
				endlessScoreText.SetText("0");
			}
			UUIItem endlessScoreAddItem = this.EndlessScoreAddItem;
			if (endlessScoreAddItem == null)
			{
				return;
			}
			endlessScoreAddItem.SetUIActive(false);
		}

		// Token: 0x06044D43 RID: 281923 RVA: 0x011E8F1C File Offset: 0x011E711C
		private void SwitchClawButtonState(EClawButtonState state)
		{
			if (this.TexClaw == null)
			{
				return;
			}
			if (!this.ClawIconTextureMap.ContainsKey(state))
			{
				return;
			}
			UTexture utexture = this.ClawIconTextureMap[state];
			this.TexClaw.SetTexture(utexture);
			this.ClawTextureTransitionComp.SetAllStateTexture(utexture);
		}

		// Token: 0x06044D44 RID: 281924 RVA: 0x011E8F68 File Offset: 0x011E7168
		[NullableContext(1)]
		private UniTask LoadTexture([Nullable(2)] string path, Dictionary<EClawButtonState, UTexture> container, EClawButtonState key)
		{
			DollGrabMachineView.<LoadTexture>d__61 <LoadTexture>d__;
			<LoadTexture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadTexture>d__.<>4__this = this;
			<LoadTexture>d__.path = path;
			<LoadTexture>d__.container = container;
			<LoadTexture>d__.key = key;
			<LoadTexture>d__.<>1__state = -1;
			<LoadTexture>d__.<>t__builder.Start<DollGrabMachineView.<LoadTexture>d__61>(ref <LoadTexture>d__);
			return <LoadTexture>d__.<>t__builder.Task;
		}

		// Token: 0x06044D45 RID: 281925 RVA: 0x011E8FC4 File Offset: 0x011E71C4
		private void OnDollGrabMachineDangerousCountdown(bool isEnterDangerous)
		{
			if (isEnterDangerous)
			{
				this.SprPoint.SetColor(this.SprPointChangeColor.Value);
				BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
				this.SetSpriteByPath(((dollGrabMachineGlobalConfig != null) ? dollGrabMachineGlobalConfig.进度条危险.ToAssetPathName() : null) ?? "", this.SprFill, false, null, null);
				return;
			}
			this.SprPoint.SetColor(this.SprPointOriginalColor.Value);
			BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig2 = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
			this.SetSpriteByPath(((dollGrabMachineGlobalConfig2 != null) ? dollGrabMachineGlobalConfig2.进度条安全.ToAssetPathName() : null) ?? "", this.SprFill, false, null, null);
		}

		// Token: 0x06044D46 RID: 281926 RVA: 0x011E9077 File Offset: 0x011E7277
		[NullableContext(1)]
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Score_Up")
			{
				UUIItem endlessScoreAddItem = this.EndlessScoreAddItem;
				if (endlessScoreAddItem != null)
				{
					endlessScoreAddItem.SetUIActive(false);
				}
			}
			if (sequenceName == "Time_Up")
			{
				UUIItem pnlAddTimeTxt = this.PnlAddTimeTxt;
				if (pnlAddTimeTxt == null)
				{
					return;
				}
				pnlAddTimeTxt.SetUIActive(false);
			}
		}

		// Token: 0x0402655B RID: 157019
		private UUIButtonComponent ClawBtn;

		// Token: 0x0402655C RID: 157020
		private UUIText ClawBtnText;

		// Token: 0x0402655D RID: 157021
		private DollGrabMachineCaptionPanel CaptionPanel;

		// Token: 0x0402655E RID: 157022
		private DollGrabMachineMissionPanel MissionPanel;

		// Token: 0x0402655F RID: 157023
		private UUIArtText EndlessScoreText;

		// Token: 0x04026560 RID: 157024
		private UUIArtText EndlessScoreAddText;

		// Token: 0x04026561 RID: 157025
		private UUIItem EndlessScoreAddItem;

		// Token: 0x04026562 RID: 157026
		private UUISliderComponent SldBar;

		// Token: 0x04026563 RID: 157027
		private UUISliderComponent SldBarAdd;

		// Token: 0x04026564 RID: 157028
		private UUIItem PnlBar;

		// Token: 0x04026565 RID: 157029
		private UUIText CostText;

		// Token: 0x04026566 RID: 157030
		private UUIItem PnlCost;

		// Token: 0x04026567 RID: 157031
		private UUIItem PnlAddTimeTxt;

		// Token: 0x04026568 RID: 157032
		private UUIArtText AddTimeTxt;

		// Token: 0x04026569 RID: 157033
		private UUITexture TexClaw;

		// Token: 0x0402656A RID: 157034
		private Action CountDownCallback;

		// Token: 0x0402656B RID: 157035
		[Nullable(1)]
		private readonly List<IGrabItemData> ReceiveItemList = new List<IGrabItemData>();

		// Token: 0x0402656C RID: 157036
		[Nullable(1)]
		private readonly Dictionary<EClawButtonState, UTexture> ClawIconTextureMap = new Dictionary<EClawButtonState, UTexture>();

		// Token: 0x0402656D RID: 157037
		private UUISprite SprPoint;

		// Token: 0x0402656E RID: 157038
		private UUISprite SprFill;

		// Token: 0x0402656F RID: 157039
		private UUITextureTransitionComponent ClawTextureTransitionComp;

		// Token: 0x04026570 RID: 157040
		private FColor? SprPointOriginalColor;

		// Token: 0x04026571 RID: 157041
		private FColor? SprPointChangeColor;

		// Token: 0x04026572 RID: 157042
		private DollGrabMachineJoystick MobileJoystick;

		// Token: 0x04026573 RID: 157043
		private EBoundInputMode CurrentInputMode;

		// Token: 0x04026574 RID: 157044
		private LevelSequencePlayer SequencePlayer;
	}
}
