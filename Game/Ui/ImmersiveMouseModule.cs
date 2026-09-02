using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A1C RID: 18972
	[NullableContext(1)]
	[Nullable(0)]
	public class ImmersiveMouseModule
	{
		// Token: 0x06031918 RID: 203032 RVA: 0x00C5A7A4 File Offset: 0x00C589A4
		public void Initialize()
		{
			if (this.IsInitialized)
			{
				return;
			}
			this.IsInitialized = true;
			this.Reset();
			foreach (ImmersiveMouse immersiveMouse in ConfigBase<ImmersiveMouseConfig>.Instance.GetAllImmersiveMouseViewConfig())
			{
				this.ImmersiveMouseViewSet.Add((EUiViewName)immersiveMouse.ViewName);
			}
			this.InitGamepadIgnoreKeys();
			Singleton<EventSystem>.Instance.Add<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
			this.CurrentInputMainType = Singleton<Info>.Instance.InputControllerMainType;
			this.UpdateInputBindings();
		}

		// Token: 0x06031919 RID: 203033 RVA: 0x00C5A854 File Offset: 0x00C58A54
		private void InitGamepadIgnoreKeys()
		{
			this.GamepadIgnoreKeySet.Clear();
			foreach (string actionName in new string[]
			{
				"UI键盘F手柄A",
				"UI返回"
			})
			{
				foreach (string item in ModelBase<UiNavigationModel>.Instance.GetGamepadKeyNameListByActionName(actionName))
				{
					this.GamepadIgnoreKeySet.Add(item);
				}
			}
		}

		// Token: 0x0603191A RID: 203034 RVA: 0x00C5A8E4 File Offset: 0x00C58AE4
		public void EnableImmersiveMode()
		{
			if (this.ImmersiveModeEnabled || !this.FunctionEnabled)
			{
				return;
			}
			this.ImmersiveModeEnabled = true;
			Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.Tick), "ImmersiveMouseModule", ETickingGroup.TG_PrePhysics, true, 0, true);
			this.TickId = ticker.Id;
			ControllerBase<InputDistributeController>.Instance.BindActions(this.MouseInputActionList, new TInputHandle<InputDistributeDefine.EActionType>(this.OnClickedMouse));
			this.IsMouseInViewport = this.CheckMouseInViewport();
			this.BindInputListeners();
			Singleton<InputManager>.Instance.SetImmersiveInputWakeState(this.CurrentInputMainType, true);
		}

		// Token: 0x0603191B RID: 203035 RVA: 0x00C5A974 File Offset: 0x00C58B74
		public void DisableImmersiveMode()
		{
			if (!this.ImmersiveModeEnabled)
			{
				return;
			}
			this.ImmersiveModeEnabled = false;
			this.Reset();
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickId);
				this.TickId = -1;
			}
			ControllerBase<InputDistributeController>.Instance.UnBindActions(this.MouseInputActionList, new TInputHandle<InputDistributeDefine.EActionType>(this.OnClickedMouse));
			this.UnbindAllInputListeners();
			Singleton<InputManager>.Instance.SetImmersiveInputWakeState(this.CurrentInputMainType, false);
		}

		// Token: 0x0603191C RID: 203036 RVA: 0x00C5A9EB File Offset: 0x00C58BEB
		public bool IsImmersiveModeEnabled()
		{
			return this.ImmersiveModeEnabled;
		}

		// Token: 0x0603191D RID: 203037 RVA: 0x00C5A9F3 File Offset: 0x00C58BF3
		public bool IsImmersiveInputPaused()
		{
			return this.PauseReasonSet.Count > 0;
		}

		// Token: 0x0603191E RID: 203038 RVA: 0x00C5AA03 File Offset: 0x00C58C03
		public void PauseImmersiveMode(EImmersiveMouseModeReason reason, bool bReset = true, bool bShowCursor = true)
		{
			this.PauseReasonSet.Add(reason);
			if (!this.ImmersiveModeEnabled)
			{
				return;
			}
			if (bReset)
			{
				this.Reset();
			}
			if (bShowCursor)
			{
				Singleton<InputManager>.Instance.SetShowCursor(true, true);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshCursor);
		}

		// Token: 0x0603191F RID: 203039 RVA: 0x00C5AA43 File Offset: 0x00C58C43
		public void ResumeImmersiveMode(EImmersiveMouseModeReason reason)
		{
			this.PauseReasonSet.Remove(reason);
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshCursor);
		}

		// Token: 0x06031920 RID: 203040 RVA: 0x00C5AA64 File Offset: 0x00C58C64
		public void Tick(float deltaTime)
		{
			if (!this.ImmersiveModeEnabled)
			{
				return;
			}
			if (this.PauseReasonSet.Count > 0)
			{
				return;
			}
			if (this.CurrentInputMainType == EInputControllerMainType.Keyboard)
			{
				bool isMouseInViewport = this.IsMouseInViewport;
				this.IsMouseInViewport = this.CheckMouseInViewport();
				if (!this.IsMouseInViewport)
				{
					this.MouseIdleTime = 0f;
					if (isMouseInViewport && !Global.PlayerController.bShowMouseCursor)
					{
						Singleton<InputManager>.Instance.SetShowCursor(true, true);
					}
					return;
				}
			}
			bool flag = this.HasAnyInput();
			if (Singleton<InputManager>.Instance.GetImmersiveInputWakeState())
			{
				if (flag)
				{
					this.MouseIdleTime = 0f;
					if (!Global.PlayerController.bShowMouseCursor)
					{
						Singleton<InputManager>.Instance.SetShowCursor(true, true);
						return;
					}
				}
				else
				{
					this.MouseIdleTime += deltaTime;
					if (this.MouseIdleTime >= (float)this.AutoHideMouseDelay)
					{
						Singleton<InputManager>.Instance.SetShowCursor(false, true);
						this.MouseIdleTime = 0f;
						Singleton<InputManager>.Instance.SetImmersiveInputWakeState(this.CurrentInputMainType, false);
						return;
					}
				}
			}
			else if (flag)
			{
				Singleton<InputManager>.Instance.SetShowCursor(true, true);
				this.MouseIdleTime = 0f;
				Singleton<InputManager>.Instance.SetImmersiveInputWakeState(this.CurrentInputMainType, true);
			}
		}

		// Token: 0x06031921 RID: 203041 RVA: 0x00C5AB7F File Offset: 0x00C58D7F
		public void Reset()
		{
			this.MouseIdleTime = 0f;
		}

		// Token: 0x06031922 RID: 203042 RVA: 0x00C5AB8C File Offset: 0x00C58D8C
		private void OnClickedMouse(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (this.ImmersiveModeEnabled && this.CurrentInputMainType == EInputControllerMainType.Keyboard && !Singleton<InputManager>.Instance.GetImmersiveInputWakeState())
			{
				Singleton<InputManager>.Instance.SetShowCursor(true, true);
				this.MouseIdleTime = 0f;
				Singleton<InputManager>.Instance.SetImmersiveInputWakeState(this.CurrentInputMainType, true);
			}
		}

		// Token: 0x06031923 RID: 203043 RVA: 0x00C5ABE0 File Offset: 0x00C58DE0
		private bool CheckMousePress()
		{
			foreach (string actionName in this.MouseInputActionList)
			{
				if (ModelBase<InputDistributeModel>.Instance.IsActionInPress(actionName))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06031924 RID: 203044 RVA: 0x00C5AC18 File Offset: 0x00C58E18
		private bool CheckMouseInViewport()
		{
			float num = 0f;
			float num2 = 0f;
			return Global.PlayerController.GetMousePosition(ref num, ref num2);
		}

		// Token: 0x06031925 RID: 203045 RVA: 0x00C5AC40 File Offset: 0x00C58E40
		public void RefreshMouseImmersiveMode()
		{
			UiViewBase uiViewBase = null;
			foreach (ELayerType layer in this.ImmersiveMouseViewLayerList)
			{
				uiViewBase = Singleton<UiModel>.Instance.GetTopView(layer);
				if (uiViewBase != null)
				{
					break;
				}
			}
			if (uiViewBase == null)
			{
				return;
			}
			EUiViewName name = uiViewBase.ViewInfo.Name;
			if (name == this.TopView)
			{
				return;
			}
			this.TopView = new EUiViewName?(name);
			if (this.ImmersiveMouseViewSet.Contains(name))
			{
				this.ApplyImmersiveMouseConfig(name);
				if (!this.ImmersiveModeEnabled)
				{
					this.EnableImmersiveMode();
					return;
				}
			}
			else if (this.ImmersiveModeEnabled)
			{
				this.DisableImmersiveMode();
			}
		}

		// Token: 0x06031926 RID: 203046 RVA: 0x00C5ACF0 File Offset: 0x00C58EF0
		private void ApplyImmersiveMouseConfig(EUiViewName viewName)
		{
			ImmersiveMouse immersiveMouseViewConfigByViewName = ConfigBase<ImmersiveMouseConfig>.Instance.GetImmersiveMouseViewConfigByViewName(viewName);
			this.AutoHideMouseDelay = immersiveMouseViewConfigByViewName.AutoHideTime;
			this.DeadZone = immersiveMouseViewConfigByViewName.DeadZone;
		}

		// Token: 0x06031927 RID: 203047 RVA: 0x00C5AD23 File Offset: 0x00C58F23
		public void SetFunctionEnabled(bool bEnabled, bool bReset = true, bool bShowCursor = true)
		{
			this.FunctionEnabled = bEnabled;
			if (!this.FunctionEnabled)
			{
				this.DisableImmersiveMode();
				return;
			}
			if (bReset)
			{
				this.Reset();
			}
			if (bShowCursor)
			{
				Singleton<InputManager>.Instance.SetShowCursor(true, true);
			}
		}

		// Token: 0x06031928 RID: 203048 RVA: 0x00C5AD53 File Offset: 0x00C58F53
		public bool IsFunctionEnabled()
		{
			return this.FunctionEnabled;
		}

		// Token: 0x06031929 RID: 203049 RVA: 0x00C5AD5B File Offset: 0x00C58F5B
		private void OnInputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
		{
			if (this.CurrentInputMainType == now)
			{
				return;
			}
			this.CurrentInputMainType = now;
			this.UpdateInputBindings();
		}

		// Token: 0x0603192A RID: 203050 RVA: 0x00C5AD74 File Offset: 0x00C58F74
		private void UpdateInputBindings()
		{
			if (!this.ImmersiveModeEnabled)
			{
				return;
			}
			this.UnbindAllInputListeners();
			this.BindInputListeners();
		}

		// Token: 0x0603192B RID: 203051 RVA: 0x00C5AD8C File Offset: 0x00C58F8C
		private void BindInputListeners()
		{
			if (this.CurrentInputMainType == EInputControllerMainType.Gamepad)
			{
				Singleton<EventSystem>.Instance.Add(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnGamepadAnyKey));
				this.IsGamepadInputBound = true;
				return;
			}
			if (this.CurrentInputMainType == EInputControllerMainType.Touch)
			{
				ControllerBase<InputDistributeController>.Instance.BindTouch(0, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouchInput));
				this.IsTouchInputBound = true;
			}
		}

		// Token: 0x0603192C RID: 203052 RVA: 0x00C5ADF0 File Offset: 0x00C58FF0
		private void UnbindAllInputListeners()
		{
			if (this.IsGamepadInputBound)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnGamepadAnyKey));
				this.IsGamepadInputBound = false;
			}
			if (this.IsTouchInputBound)
			{
				ControllerBase<InputDistributeController>.Instance.UnBindTouch(0, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouchInput));
				this.IsTouchInputBound = false;
			}
		}

		// Token: 0x0603192D RID: 203053 RVA: 0x00C5AE50 File Offset: 0x00C59050
		private void OnGamepadAnyKey(bool bPress, FKey key)
		{
			if (!bPress)
			{
				return;
			}
			if (!UKismetInputLibrary.Key_IsGamepadKey(key))
			{
				return;
			}
			string text = key.KeyName.ToString();
			if (!string.IsNullOrEmpty(text) && this.GamepadIgnoreKeySet.Contains(text))
			{
				return;
			}
			this.OnAnyInput();
		}

		// Token: 0x0603192E RID: 203054 RVA: 0x00C5AE9D File Offset: 0x00C5909D
		private void OnTouchInput(string arg1, InputDistributeDefine.ITouchData arg2, InputIdentification arg3)
		{
			this.OnAnyInput();
		}

		// Token: 0x0603192F RID: 203055 RVA: 0x00C5AEA8 File Offset: 0x00C590A8
		private void OnAnyInput()
		{
			if (!this.ImmersiveModeEnabled || this.PauseReasonSet.Count > 0)
			{
				return;
			}
			if (!Singleton<InputManager>.Instance.GetImmersiveInputWakeState())
			{
				Singleton<InputManager>.Instance.SetShowCursor(true, true);
				this.MouseIdleTime = 0f;
				Singleton<InputManager>.Instance.SetImmersiveInputWakeState(this.CurrentInputMainType, true);
				return;
			}
			this.MouseIdleTime = 0f;
		}

		// Token: 0x06031930 RID: 203056 RVA: 0x00C5AF0C File Offset: 0x00C5910C
		private bool HasAnyInput()
		{
			return this.CurrentInputMainType == EInputControllerMainType.Keyboard && (this.CheckMousePress() || this.CheckMouseMove());
		}

		// Token: 0x06031931 RID: 203057 RVA: 0x00C5AF2C File Offset: 0x00C5912C
		private bool CheckMouseMove()
		{
			float value = 0f;
			float value2 = 0f;
			Global.PlayerController.GetInputMouseDelta(ref value, ref value2);
			return Math.Abs(value) + Math.Abs(value2) > this.DeadZone;
		}

		// Token: 0x0401CDD9 RID: 118233
		private bool ImmersiveModeEnabled;

		// Token: 0x0401CDDA RID: 118234
		private float DeadZone = 0.1f;

		// Token: 0x0401CDDB RID: 118235
		private int AutoHideMouseDelay = 3000;

		// Token: 0x0401CDDC RID: 118236
		private float MouseIdleTime;

		// Token: 0x0401CDDD RID: 118237
		private int TickId = -1;

		// Token: 0x0401CDDE RID: 118238
		private readonly string[] MouseInputActionList = new string[]
		{
			"UI左键点击",
			"UI右键点击"
		};

		// Token: 0x0401CDDF RID: 118239
		private readonly ELayerType[] ImmersiveMouseViewLayerList = new ELayerType[]
		{
			ELayerType.Pop,
			ELayerType.Loading,
			ELayerType.Plot,
			ELayerType.Normal
		};

		// Token: 0x0401CDE0 RID: 118240
		private readonly HashSet<EUiViewName> ImmersiveMouseViewSet = new HashSet<EUiViewName>();

		// Token: 0x0401CDE1 RID: 118241
		private bool IsInitialized;

		// Token: 0x0401CDE2 RID: 118242
		private EUiViewName? TopView;

		// Token: 0x0401CDE3 RID: 118243
		private readonly HashSet<EImmersiveMouseModeReason> PauseReasonSet = new HashSet<EImmersiveMouseModeReason>();

		// Token: 0x0401CDE4 RID: 118244
		private bool FunctionEnabled = true;

		// Token: 0x0401CDE5 RID: 118245
		private bool IsMouseInViewport;

		// Token: 0x0401CDE6 RID: 118246
		private EInputControllerMainType CurrentInputMainType;

		// Token: 0x0401CDE7 RID: 118247
		private bool IsGamepadInputBound;

		// Token: 0x0401CDE8 RID: 118248
		private bool IsTouchInputBound;

		// Token: 0x0401CDE9 RID: 118249
		private readonly HashSet<string> GamepadIgnoreKeySet = new HashSet<string>();
	}
}
