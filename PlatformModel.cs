using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform;
using UnrealEngine;

// Token: 0x020025F3 RID: 9715
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class PlatformModel : ModelBase<PlatformModel>
{
	// Token: 0x06013091 RID: 77969 RVA: 0x00546F40 File Offset: 0x00545140
	protected override bool OnInit()
	{
		Singleton<Info>.Instance.SetInputTypeChangeFunc(new TInputTypeChange(this.InputTypeChangeFunc));
		Singleton<Info>.Instance.SetShowTypeChangeFunc(new TShowTypeChange(this.ShowTypeChangeFunc));
		Singleton<Info>.Instance.SetInputMainTypeChangeFunc(new TInputMainTypeChange(this.InputMainTypeChangeFunc));
		this.NotifyAudioStateChange();
		this.NotifyCppInputControllerChange();
		Singleton<EventSystem>.Instance.Add(EEventName.InitializeLguiEventSystemActor, new Action(this.OnNotifyCppInputControllerChange));
		return true;
	}

	// Token: 0x06013092 RID: 77970 RVA: 0x00546FB8 File Offset: 0x005451B8
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.InitializeLguiEventSystemActor, new Action(this.OnNotifyCppInputControllerChange));
		Singleton<Info>.Instance.ClearInputTypeChangeFunc();
		Singleton<Info>.Instance.ClearShowTypeChangeFunc();
		Singleton<Info>.Instance.ClearInputMainTypeChangeFunc();
		return true;
	}

	// Token: 0x06013093 RID: 77971 RVA: 0x00546FF8 File Offset: 0x005451F8
	private void InputTypeChangeFunc(EInputControllerType last, EInputControllerType now)
	{
		this.NotifyAudioStateChange();
		this.NotifyCppInputControllerChange();
		TsCharacterController characterController = Global.CharacterController;
		if (characterController != null && (now == EInputControllerType.PS4 || now == EInputControllerType.PS5))
		{
			UTriggerEffectBPLibrary.SetPadColor(characterController, FColor.FromHex("#0000FF"));
		}
		else
		{
			UTriggerEffectBPLibrary.ResetPadColor(Global.CharacterController);
		}
		Singleton<EventSystem>.Instance.Emit<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, last, now);
	}

	// Token: 0x06013094 RID: 77972 RVA: 0x00547050 File Offset: 0x00545250
	private void ShowTypeChangeFunc(EOperationType last, EOperationType now)
	{
		Singleton<EventSystem>.Instance.Emit<EOperationType, EOperationType>(EEventName.ShowTypeChange, last, now);
	}

	// Token: 0x06013095 RID: 77973 RVA: 0x00547064 File Offset: 0x00545264
	private void InputMainTypeChangeFunc(EInputControllerMainType last, EInputControllerMainType now)
	{
		Singleton<EventSystem>.Instance.Emit<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, last, now);
	}

	// Token: 0x06013096 RID: 77974 RVA: 0x00547078 File Offset: 0x00545278
	private void OnNotifyCppInputControllerChange()
	{
		this.NotifyCppInputControllerChange();
	}

	// Token: 0x06013097 RID: 77975 RVA: 0x00547080 File Offset: 0x00545280
	private void NotifyAudioStateChange()
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			Singleton<AudioSystem>.Instance.SetState("input_controller_type", "gamepad", true);
			return;
		}
		if (Singleton<Info>.Instance.IsInKeyBoard())
		{
			Singleton<AudioSystem>.Instance.SetState("input_controller_type", "Keyboard", true);
			return;
		}
		Singleton<AudioSystem>.Instance.SetState("input_controller_type", "touch", true);
	}

	// Token: 0x06013098 RID: 77976 RVA: 0x005470E8 File Offset: 0x005452E8
	private void NotifyCppInputControllerChange()
	{
		EInputKeyType currentInputKeyType = EInputKeyType.None;
		if (Singleton<Info>.Instance.IsInKeyBoard())
		{
			currentInputKeyType = EInputKeyType.KeyboardOrMouse;
		}
		else if (Singleton<Info>.Instance.IsInGamepad())
		{
			currentInputKeyType = EInputKeyType.Gamepad;
		}
		else if (Singleton<Info>.Instance.IsInTouch())
		{
			currentInputKeyType = EInputKeyType.Touch;
		}
		TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
		if (lguiEventSystemActor != null && lguiEventSystemActor.IsValid())
		{
			lguiEventSystemActor.SetCurrentInputKeyType(currentInputKeyType);
		}
		ABasePlayerController.SetUseSonyGamepadState(Singleton<Info>.Instance.IsPsGamepad());
		ABasePlayerController.SetUseGamepadState(Singleton<Info>.Instance.IsInGamepad());
	}

	// Token: 0x06013099 RID: 77977 RVA: 0x00547160 File Offset: 0x00545360
	private EInputControllerType GetCurrentPcDeviceInputController()
	{
		Singleton<Log>.Instance.Info(ELogModule.Platform, ELogAuthor.CWC, "RegisteredDevices为空", default(ReadOnlySpan<ValueTuple<string, object>>));
		return EInputControllerType.None;
	}

	// Token: 0x0601309A RID: 77978 RVA: 0x00547190 File Offset: 0x00545390
	private EInputControllerType GetCurrentMacDeviceInputController()
	{
		string currentActiveGamepadName = UKismetSystemLibrary.GetCurrentActiveGamepadName();
		if (currentActiveGamepadName.Contains("xbox"))
		{
			return EInputControllerType.XboxOne;
		}
		if (currentActiveGamepadName.Contains("ps4"))
		{
			return EInputControllerType.PS4;
		}
		if (currentActiveGamepadName.Contains("ps5"))
		{
			return EInputControllerType.PS5;
		}
		if (currentActiveGamepadName.Contains("nspro"))
		{
			return EInputControllerType.NsPro;
		}
		return EInputControllerType.XboxOne;
	}

	// Token: 0x0601309B RID: 77979 RVA: 0x005471E0 File Offset: 0x005453E0
	private EInputControllerType GetCurrentCloudGamePadInputType()
	{
		ICloudGamePadInfo cloudGamePadInfo = Singleton<CloudGameManager>.Instance.CloudGamePadInfo;
		if (cloudGamePadInfo == null)
		{
			return EInputControllerType.None;
		}
		int vendorId = cloudGamePadInfo.VendorId;
		int productId = cloudGamePadInfo.ProductId;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(vendorId);
		defaultInterpolatedStringHandler.AppendLiteral("_");
		defaultInterpolatedStringHandler.AppendFormatted<int>(productId);
		string key = defaultInterpolatedStringHandler.ToStringAndClear();
		EInputControllerType result;
		if (PlatformDefine.DeviceIdMap.TryGetValue(key, out result))
		{
			return result;
		}
		return EInputControllerType.XboxOne;
	}

	// Token: 0x0601309C RID: 77980 RVA: 0x0054724C File Offset: 0x0054544C
	private void HandlePressAnyKeyInMobile(FKey key)
	{
		if (this.IsKeyFromGamepadKey(key.KeyName.ToString()))
		{
			EInputControllerType currentDeviceInputController = this.GetCurrentDeviceInputController();
			if (currentDeviceInputController != EInputControllerType.None)
			{
				Singleton<MobileSwitchInputController>.Instance.SwitchToGamepad(new EInputControllerType?(currentDeviceInputController), "PressAnyKey");
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.MobileInputSwitch, ELogAuthor.XXJ, "有手柄按钮输入但是识别不到对应的手柄设备", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x0601309D RID: 77981 RVA: 0x005472B4 File Offset: 0x005454B4
	private void HandlePressAnyKeyInNotMobile(FKey key)
	{
		if (UKismetInputLibrary.Key_IsGamepadKey(key))
		{
			if (!this.RefreshPlatformByDevice("PressAnyKey"))
			{
				Singleton<Info>.Instance.SwitchInputControllerType(EInputControllerType.XboxOne, "PressAnyKey");
				return;
			}
		}
		else
		{
			if (UKismetInputLibrary.Key_IsKeyboardKey(key) || UKismetInputLibrary.Key_IsMouseButton(key))
			{
				Singleton<Info>.Instance.SwitchInputControllerType(EInputControllerType.Keyboard, "PressAnyKey");
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Platform;
			ELogAuthor author = ELogAuthor.CB;
			string message = "HandlePressAnyKeyInNotMobile:Touch";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key.KeyName.ToString());
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<Info>.Instance.SwitchInputControllerType(EInputControllerType.Touch, "PressAnyKey");
		}
	}

	// Token: 0x0601309E RID: 77982 RVA: 0x0054735B File Offset: 0x0054555B
	public void OnPressAnyKey(FKey key)
	{
		if (Singleton<Info>.Instance.IsMobileInputModel())
		{
			this.HandlePressAnyKeyInMobile(key);
			return;
		}
		this.HandlePressAnyKeyInNotMobile(key);
	}

	// Token: 0x0601309F RID: 77983 RVA: 0x00547378 File Offset: 0x00545578
	public bool RefreshPlatformByDevice(string reason)
	{
		if (Singleton<Info>.Instance.IsPs5Platform())
		{
			Singleton<Info>.Instance.SwitchInputControllerType(EInputControllerType.PS5, reason);
			return true;
		}
		if (!Singleton<CloudGameManager>.Instance.IsCloudGame)
		{
			if (Singleton<Info>.Instance.IsWindowsPlatform())
			{
				EInputControllerType currentPcDeviceInputController = this.GetCurrentPcDeviceInputController();
				if (currentPcDeviceInputController != EInputControllerType.None)
				{
					Singleton<Info>.Instance.SwitchInputControllerType(currentPcDeviceInputController, reason);
					return true;
				}
			}
			if (Singleton<Info>.Instance.IsMacPlatform())
			{
				EInputControllerType currentMacDeviceInputController = this.GetCurrentMacDeviceInputController();
				if (currentMacDeviceInputController != EInputControllerType.None)
				{
					Singleton<Info>.Instance.SwitchInputControllerType(currentMacDeviceInputController, reason);
					return true;
				}
			}
			return false;
		}
		EInputControllerType currentCloudGamePadInputType = this.GetCurrentCloudGamePadInputType();
		if (currentCloudGamePadInputType != EInputControllerType.None)
		{
			Singleton<Info>.Instance.SwitchInputControllerType(currentCloudGamePadInputType, reason);
			return true;
		}
		return false;
	}

	// Token: 0x060130A0 RID: 77984 RVA: 0x0054740E File Offset: 0x0054560E
	public NetStatusType GetNetStatus()
	{
		if (Singleton<Info>.Instance.IsMobilePlatform())
		{
			if (UMobilePatchingLibrary.HasActiveWiFiConnection())
			{
				return NetStatusType.Wifi;
			}
			if (UKuroLauncherLibrary.GetNetworkConnectionType() == 3)
			{
				return NetStatusType.Stream;
			}
			return NetStatusType.Other;
		}
		else
		{
			if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
			{
				return NetStatusType.Wired;
			}
			return NetStatusType.Other;
		}
	}

	// Token: 0x060130A1 RID: 77985 RVA: 0x00547440 File Offset: 0x00545640
	public bool IsKeyFromGamepadKey(string keyName)
	{
		return !keyName.Contains("Android") && !keyName.Contains("OpenHarmony") && Singleton<InputSettings>.Instance.IsGamepadKey(keyName);
	}

	// Token: 0x060130A2 RID: 77986 RVA: 0x0054746C File Offset: 0x0054566C
	public EInputControllerType GetCurrentDeviceInputController()
	{
		if (Singleton<Platform>.Instance.IsPcPlatform())
		{
			if (Singleton<CloudGameManager>.Instance.IsCloudGame)
			{
				return this.GetCloudGameInputController();
			}
			return this.GetCurrentPcDeviceInputController();
		}
		else
		{
			string currentActiveGamepadName = UKismetSystemLibrary.GetCurrentActiveGamepadName();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MobileInputSwitch;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "当前激活的手柄";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("设备名", currentActiveGamepadName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (Singleton<Platform>.Instance.IsAndroidPlatform())
			{
				if (currentActiveGamepadName == "None")
				{
					return EInputControllerType.None;
				}
				EInputControllerType result;
				if (PlatformDefine.DeviceIdMap.TryGetValue(currentActiveGamepadName, out result))
				{
					return result;
				}
				foreach (KeyValuePair<string, EInputControllerType> keyValuePair in PlatformDefine.DeviceIdMap)
				{
					int num = keyValuePair.Key.IndexOfAny(new char[]
					{
						'*',
						'_'
					});
					if (num > 0)
					{
						string value = keyValuePair.Key.Substring(0, num);
						if (currentActiveGamepadName.StartsWith(value))
						{
							return keyValuePair.Value;
						}
					}
				}
				return EInputControllerType.XboxOne;
			}
			else if (Singleton<Platform>.Instance.IsIOSPlatform())
			{
				if (currentActiveGamepadName == "None")
				{
					return EInputControllerType.None;
				}
				if (currentActiveGamepadName.Contains("Xbox"))
				{
					return EInputControllerType.XboxOne;
				}
				if (currentActiveGamepadName.Contains("DualShock"))
				{
					return EInputControllerType.PS5;
				}
				if (currentActiveGamepadName.Contains("BackBoneOne"))
				{
					return EInputControllerType.BackBone;
				}
				if (currentActiveGamepadName.Contains("nspro"))
				{
					return EInputControllerType.NsPro;
				}
				return EInputControllerType.XboxOne;
			}
			else
			{
				if (Singleton<Platform>.Instance.IsOpenHarmonyPlatform())
				{
					return this.GetOpenHarmonyDeviceInputController(currentActiveGamepadName);
				}
				return EInputControllerType.None;
			}
		}
	}

	// Token: 0x060130A3 RID: 77987 RVA: 0x005475F8 File Offset: 0x005457F8
	private EInputControllerType GetOpenHarmonyDeviceInputController(string deviceName)
	{
		if (deviceName == "None" || deviceName == "")
		{
			return EInputControllerType.None;
		}
		if (deviceName.Contains("Pro Controller"))
		{
			return EInputControllerType.NsPro;
		}
		if (deviceName.Contains("Backbone"))
		{
			return EInputControllerType.BackBone;
		}
		if (deviceName.Contains("PS5") || deviceName.Contains("DualSense"))
		{
			return EInputControllerType.PS5;
		}
		if (deviceName.Contains("PS4"))
		{
			return EInputControllerType.PS4;
		}
		return EInputControllerType.XboxOne;
	}

	// Token: 0x060130A4 RID: 77988 RVA: 0x0054766B File Offset: 0x0054586B
	public bool IsGamepadAttached()
	{
		if (!Singleton<Platform>.Instance.IsPcPlatform())
		{
			return UKismetSystemLibrary.IsGamepadAttached();
		}
		if (!string.IsNullOrEmpty(Singleton<Platform>.Instance.CloudGamePlatform))
		{
			return this.GetCurrentCloudGamePadInputType() > EInputControllerType.None;
		}
		return this.GetCurrentPcDeviceInputController() > EInputControllerType.None;
	}

	// Token: 0x060130A5 RID: 77989 RVA: 0x005476A4 File Offset: 0x005458A4
	public EInputControllerType GetCloudGameInputController()
	{
		EInputControllerType currentCloudGamePadInputType = this.GetCurrentCloudGamePadInputType();
		if (currentCloudGamePadInputType != EInputControllerType.None)
		{
			return currentCloudGamePadInputType;
		}
		if (Singleton<Platform>.Instance.CloudGamePlatform == ECloudGamePlatform.Mac.ToEnumString() || Singleton<Platform>.Instance.CloudGamePlatform == ECloudGamePlatform.Windows.ToEnumString())
		{
			return EInputControllerType.Keyboard;
		}
		return EInputControllerType.Touch;
	}

	// Token: 0x0400948A RID: 38026
	public bool LastGamepadAttachedState;
}
