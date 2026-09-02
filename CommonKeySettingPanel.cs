using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.KeySetting;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Module.Menu.KeySettingsView;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200208A RID: 8330
[NullableContext(2)]
[Nullable(0)]
public class CommonKeySettingPanel : KeySettingPanelBase
{
	// Token: 0x0600FE0D RID: 65037 RVA: 0x0045B053 File Offset: 0x00459253
	public CommonKeySettingPanel(EKeySettingExclusiveType exclusiveType = EKeySettingExclusiveType.None) : base(exclusiveType)
	{
	}

	// Token: 0x0600FE0E RID: 65038 RVA: 0x0045B05C File Offset: 0x0045925C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(15, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(16, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(17, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnLeftButtonClicked)),
			new ValueTuple<int, Delegate>(1, new Action(this.OnRightButtonClicked)),
			new ValueTuple<int, Delegate>(9, new Action(this.OnResetButtonClicked)),
			new ValueTuple<int, Delegate>(14, new Action(this.OnResetButtonClicked)),
			new ValueTuple<int, Delegate>(15, new Action(this.OnGamepadOperationButtonClicked)),
			new ValueTuple<int, Delegate>(16, new Action(this.OnGamepadOperationButtonClicked))
		};
	}

	// Token: 0x0600FE0F RID: 65039 RVA: 0x0045B2A8 File Offset: 0x004594A8
	protected override UniTask OnBeforeStartAsync()
	{
		CommonKeySettingPanel.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonKeySettingPanel.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FE10 RID: 65040 RVA: 0x0045B2EC File Offset: 0x004594EC
	protected override void OnStart()
	{
		this.Refresh();
		this.RefreshEditKeyTips(null);
		this.InitializePlatformInfo();
		Singleton<EventSystem>.Instance.Add(EEventName.OnDeviceLangChange, new Action(this.OnDeviceLangChange));
		UUIItem item = base.GetItem(17);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600FE11 RID: 65041 RVA: 0x0045B33B File Offset: 0x0045953B
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnDeviceLangChange, new Action(this.OnDeviceLangChange));
	}

	// Token: 0x0600FE12 RID: 65042 RVA: 0x0045B359 File Offset: 0x00459559
	protected override void OnWaitKeySetting()
	{
	}

	// Token: 0x0600FE13 RID: 65043 RVA: 0x0045B35B File Offset: 0x0045955B
	protected override void OnBeforeBeginEditKey()
	{
		CommonKeySettingRowsPanel pcPanel = this.PcPanel;
		if (pcPanel != null)
		{
			pcPanel.StopScroll();
		}
		CommonKeySettingRowsPanel gamepadPanel = this.GamepadPanel;
		if (gamepadPanel == null)
		{
			return;
		}
		gamepadPanel.StopScroll();
	}

	// Token: 0x0600FE14 RID: 65044 RVA: 0x0045B37E File Offset: 0x0045957E
	protected override void OnBeginEditKey()
	{
		GamepadItemBase gamepadItem = this.GamepadItem;
		if (gamepadItem != null)
		{
			gamepadItem.SetAllKeyDisable();
		}
		this.RefreshEditKeyTips("EditKey_Text");
	}

	// Token: 0x0600FE15 RID: 65045 RVA: 0x0045B39C File Offset: 0x0045959C
	protected override void OnFinishEditKey()
	{
		this.RefreshEditKeyTips(null);
	}

	// Token: 0x0600FE16 RID: 65046 RVA: 0x0045B3A5 File Offset: 0x004595A5
	[NullableContext(1)]
	protected override void OnKeyChange(KeySettingRowData data, CSharpScript.Game.Module.Menu.EInputControllerType type)
	{
	}

	// Token: 0x0600FE17 RID: 65047 RVA: 0x0045B3A7 File Offset: 0x004595A7
	protected override void OnKeySelected(KeySettingRowData data)
	{
	}

	// Token: 0x0600FE18 RID: 65048 RVA: 0x0045B3AC File Offset: 0x004595AC
	protected override void OnKeyHover(KeySettingRowData data)
	{
		if (KeySettingViewModel.InputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
		{
			GamepadItemBase gamepadItem = this.GamepadItem;
			if (gamepadItem == null)
			{
				return;
			}
			gamepadItem.SetAllKeyDisable();
			return;
		}
		else
		{
			this.HoverKeySettingRowData = data;
			if (data == null)
			{
				GamepadItemBase gamepadItem2 = this.GamepadItem;
				if (gamepadItem2 == null)
				{
					return;
				}
				gamepadItem2.SetAllKeyDisable();
				return;
			}
			else
			{
				List<string> displayKeyName = data.GetDisplayKeyName(KeySettingViewModel.InputControllerType);
				if (displayKeyName == null)
				{
					GamepadItemBase gamepadItem3 = this.GamepadItem;
					if (gamepadItem3 == null)
					{
						return;
					}
					gamepadItem3.SetAllKeyDisable();
					return;
				}
				else
				{
					GamepadItemBase gamepadItem4 = this.GamepadItem;
					if (gamepadItem4 == null)
					{
						return;
					}
					gamepadItem4.SetKeysEnable(displayKeyName.ToArray());
					return;
				}
			}
		}
	}

	// Token: 0x0600FE19 RID: 65049 RVA: 0x0045B424 File Offset: 0x00459624
	protected override void OnKeyUnHover(KeySettingRowData data)
	{
		if (KeySettingViewModel.InputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
		{
			GamepadItemBase gamepadItem = this.GamepadItem;
			if (gamepadItem == null)
			{
				return;
			}
			gamepadItem.SetAllKeyDisable();
			return;
		}
		else
		{
			if (this.HoverKeySettingRowData != null)
			{
				int configId = this.HoverKeySettingRowData.ConfigId;
				int? num = (data != null) ? new int?(data.ConfigId) : null;
				if (configId == num.GetValueOrDefault() & num != null)
				{
					GamepadItemBase gamepadItem2 = this.GamepadItem;
					if (gamepadItem2 == null)
					{
						return;
					}
					gamepadItem2.SetAllKeyDisable();
				}
				return;
			}
			GamepadItemBase gamepadItem3 = this.GamepadItem;
			if (gamepadItem3 == null)
			{
				return;
			}
			gamepadItem3.SetAllKeyDisable();
			return;
		}
	}

	// Token: 0x0600FE1A RID: 65050 RVA: 0x0045B4AB File Offset: 0x004596AB
	private void Refresh()
	{
		this.RefreshDeviceSwitcher();
		this.RefreshKeySettingPanel();
		this.RefreshGamepadPanel();
	}

	// Token: 0x0600FE1B RID: 65051 RVA: 0x0045B4C0 File Offset: 0x004596C0
	private void RefreshDeviceSwitcher()
	{
		IKeySettingDeviceInfo keySettingDeviceInfo;
		if (!KeySettingDefine.keySettingDeviceInfoRecord.TryGetValue(KeySettingViewModel.CurrentDeviceType, out keySettingDeviceInfo))
		{
			return;
		}
		string nameTextId = keySettingDeviceInfo.NameTextId;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), nameTextId, Array.Empty<object>());
		if (KeySettingViewModel.CurrentDeviceType == EKeySettingDeviceType.Keyboard)
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.SetSelfInteractive(false);
			}
			UUIButtonComponent button2 = base.GetButton(1);
			if (button2 == null)
			{
				return;
			}
			button2.SetSelfInteractive(true);
			return;
		}
		else
		{
			UUIButtonComponent button3 = base.GetButton(0);
			if (button3 != null)
			{
				button3.SetSelfInteractive(true);
			}
			UUIButtonComponent button4 = base.GetButton(1);
			if (button4 == null)
			{
				return;
			}
			button4.SetSelfInteractive(false);
			return;
		}
	}

	// Token: 0x0600FE1C RID: 65052 RVA: 0x0045B554 File Offset: 0x00459754
	private void RefreshKeySettingPanel()
	{
		CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType = KeySettingViewModel.InputControllerType;
		if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
		{
			this.RefreshKeyBoardTab();
			return;
		}
		if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
		{
			return;
		}
		this.RefreshGamepadTab();
	}

	// Token: 0x0600FE1D RID: 65053 RVA: 0x0045B580 File Offset: 0x00459780
	private void RefreshGamepadPanel()
	{
		if (KeySettingViewModel.InputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
		{
			global::EInputControllerType lastGamepadEnum = InputKeyUtils.GetLastGamepadEnum();
			if (Singleton<Info>.Instance.CheckIsPsGamepad(lastGamepadEnum))
			{
				this.GamepadItem = this.PsGamepadItem;
				PsGamepadItem psGamepadItem = this.PsGamepadItem;
				if (psGamepadItem != null)
				{
					psGamepadItem.SetActive(true);
				}
				XboxGamepadItem xboxGamepadItem = this.XboxGamepadItem;
				if (xboxGamepadItem == null)
				{
					return;
				}
				xboxGamepadItem.SetActive(false);
				return;
			}
			else
			{
				this.GamepadItem = this.XboxGamepadItem;
				XboxGamepadItem xboxGamepadItem2 = this.XboxGamepadItem;
				if (xboxGamepadItem2 != null)
				{
					xboxGamepadItem2.SetActive(true);
				}
				PsGamepadItem psGamepadItem2 = this.PsGamepadItem;
				if (psGamepadItem2 == null)
				{
					return;
				}
				psGamepadItem2.SetActive(false);
				return;
			}
		}
		else
		{
			this.GamepadItem = null;
			PsGamepadItem psGamepadItem3 = this.PsGamepadItem;
			if (psGamepadItem3 != null)
			{
				psGamepadItem3.SetActive(false);
			}
			XboxGamepadItem xboxGamepadItem3 = this.XboxGamepadItem;
			if (xboxGamepadItem3 == null)
			{
				return;
			}
			xboxGamepadItem3.SetActive(false);
			return;
		}
	}

	// Token: 0x0600FE1E RID: 65054 RVA: 0x0045B634 File Offset: 0x00459834
	private void RefreshKeyBoardTab()
	{
		CommonKeySettingRowsPanel pcPanel = this.PcPanel;
		if (pcPanel != null)
		{
			pcPanel.Refresh(KeySettingViewModel.GetKeySettingDataList(), KeySettingViewModel.InputControllerType);
		}
		CommonKeySettingRowsPanel pcPanel2 = this.PcPanel;
		if (pcPanel2 != null)
		{
			pcPanel2.SetActive(true);
		}
		CommonKeySettingRowsPanel gamepadPanel = this.GamepadPanel;
		if (gamepadPanel != null)
		{
			gamepadPanel.SetActive(false);
		}
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIButtonComponent button = base.GetButton(9);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(true);
			}
		}
		UUIButtonComponent button2 = base.GetButton(15);
		if (button2 != null)
		{
			UUIItem uuiitem2 = button2.RootUIComp.Get();
			if (uuiitem2 != null)
			{
				uuiitem2.SetUIActive(false);
			}
		}
		UUIButtonComponent button3 = base.GetButton(16);
		if (button3 != null)
		{
			UUIItem uuiitem3 = button3.RootUIComp.Get();
			if (uuiitem3 != null)
			{
				uuiitem3.SetUIActive(false);
			}
		}
		UUIItem item3 = base.GetItem(13);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(false);
	}

	// Token: 0x0600FE1F RID: 65055 RVA: 0x0045B730 File Offset: 0x00459930
	private void RefreshGamepadTab()
	{
		CommonKeySettingRowsPanel gamepadPanel = this.GamepadPanel;
		if (gamepadPanel != null)
		{
			gamepadPanel.Refresh(KeySettingViewModel.GetKeySettingDataList(), KeySettingViewModel.InputControllerType);
		}
		CommonKeySettingRowsPanel gamepadPanel2 = this.GamepadPanel;
		if (gamepadPanel2 != null)
		{
			gamepadPanel2.SetActive(true);
		}
		CommonKeySettingRowsPanel pcPanel = this.PcPanel;
		if (pcPanel != null)
		{
			pcPanel.SetActive(false);
		}
		bool flag = Singleton<Info>.Instance.IsHomeConsolePlatform();
		global::EInputControllerType lastGamepadEnum = InputKeyUtils.GetLastGamepadEnum();
		bool flag2 = Singleton<Info>.Instance.CheckIsBackBoneGamepad(lastGamepadEnum);
		bool flag3 = flag || flag2;
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 != null)
		{
			item2.SetUIActive(true);
		}
		UUIButtonComponent button = base.GetButton(9);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(!flag3);
			}
		}
		UUIButtonComponent button2 = base.GetButton(15);
		if (button2 != null)
		{
			UUIItem uuiitem2 = button2.RootUIComp.Get();
			if (uuiitem2 != null)
			{
				uuiitem2.SetUIActive(false);
			}
		}
		UUIButtonComponent button3 = base.GetButton(16);
		if (button3 != null)
		{
			UUIItem uuiitem3 = button3.RootUIComp.Get();
			if (uuiitem3 != null)
			{
				uuiitem3.SetUIActive(false);
			}
		}
		UUIItem item3 = base.GetItem(13);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(flag3);
	}

	// Token: 0x0600FE20 RID: 65056 RVA: 0x0045B84C File Offset: 0x00459A4C
	private void RefreshEditKeyTips(string textId = null)
	{
		if (StringUtils.IsEmpty(textId))
		{
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(11);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			this.TipsSequencePlayer.StopCurrentSequence(false, false);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), textId, Array.Empty<object>());
		UUIItem item3 = base.GetItem(7);
		if (item3 != null)
		{
			item3.SetUIActive(true);
		}
		UUIItem item4 = base.GetItem(11);
		if (item4 != null)
		{
			item4.SetUIActive(false);
		}
		this.TipsSequencePlayer.PlayLevelSequenceByName("Start".ToString(), false, null, false);
	}

	// Token: 0x0600FE21 RID: 65057 RVA: 0x0045B8F4 File Offset: 0x00459AF4
	private void InitializePlatformInfo()
	{
		bool flag = Singleton<Info>.Instance.IsHomeConsolePlatform();
		bool flag2 = Singleton<Info>.Instance.IsMobileInputModel() && Singleton<Info>.Instance.IsInGamepad();
		UUIButtonComponent button = base.GetButton(0);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(!flag && !flag2);
			}
		}
		UUIButtonComponent button2 = base.GetButton(1);
		if (button2 != null)
		{
			UUIItem uuiitem2 = button2.RootUIComp.Get();
			if (uuiitem2 != null)
			{
				uuiitem2.SetUIActive(!flag && !flag2);
			}
		}
		global::EInputControllerType lastGamepadEnum = InputKeyUtils.GetLastGamepadEnum();
		bool flag3 = Singleton<Info>.Instance.IsInGamepad() && Singleton<Info>.Instance.CheckIsBackBoneGamepad(lastGamepadEnum);
		bool flag4 = flag || flag3;
		UUIItem item = base.GetItem(12);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(!flag4);
	}

	// Token: 0x0600FE22 RID: 65058 RVA: 0x0045B9C3 File Offset: 0x00459BC3
	private void OnLeftButtonClicked()
	{
		if (KeySettingViewModel.InputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
		{
			KeySettingViewModel.InputControllerType = CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad;
		}
		else if (KeySettingViewModel.InputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
		{
			KeySettingViewModel.InputControllerType = CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard;
		}
		this.Refresh();
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.FinishGuideStepByEvent, "MenuView");
	}

	// Token: 0x0600FE23 RID: 65059 RVA: 0x0045B9FE File Offset: 0x00459BFE
	private void OnRightButtonClicked()
	{
		if (KeySettingViewModel.InputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
		{
			KeySettingViewModel.InputControllerType = CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad;
		}
		else if (KeySettingViewModel.InputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
		{
			KeySettingViewModel.InputControllerType = CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard;
		}
		this.Refresh();
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.FinishGuideStepByEvent, "MenuView");
	}

	// Token: 0x0600FE24 RID: 65060 RVA: 0x0045BA3C File Offset: 0x00459C3C
	private void OnResetButtonClicked()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ResetAllInput);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			KeySettingViewModel.ResetSettings();
			ControllerBase<InputSettingsController>.Instance.InputSettingUpdateRequest(false);
			this.Refresh();
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600FE25 RID: 65061 RVA: 0x0045BA78 File Offset: 0x00459C78
	private void OnGamepadOperationButtonClicked()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.OperationPreferencesView, null, null);
	}

	// Token: 0x0600FE26 RID: 65062 RVA: 0x0045BA8B File Offset: 0x00459C8B
	private void OnDeviceLangChange()
	{
		if (KeySettingViewModel.CurrentDeviceType != EKeySettingDeviceType.Keyboard)
		{
			return;
		}
		if (KeySettingViewModel.IsEditing)
		{
			KeySettingViewModel.ExternalFinishEditKey();
		}
		this.Refresh();
	}

	// Token: 0x040079D1 RID: 31185
	private GamepadItemBase GamepadItem;

	// Token: 0x040079D2 RID: 31186
	private PsGamepadItem PsGamepadItem;

	// Token: 0x040079D3 RID: 31187
	private XboxGamepadItem XboxGamepadItem;

	// Token: 0x040079D4 RID: 31188
	private KeySettingRowData HoverKeySettingRowData;

	// Token: 0x040079D5 RID: 31189
	private CommonKeySettingRowsPanel PcPanel;

	// Token: 0x040079D6 RID: 31190
	private CommonKeySettingRowsPanel GamepadPanel;

	// Token: 0x040079D7 RID: 31191
	private LevelSequencePlayer TipsSequencePlayer;

	// Token: 0x02008415 RID: 33813
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402CC32 RID: 183346
		public const int LeftButton = 0;

		// Token: 0x0402CC33 RID: 183347
		public const int RightButton = 1;

		// Token: 0x0402CC34 RID: 183348
		public const int DeviceNameText = 2;

		// Token: 0x0402CC35 RID: 183349
		public const int GamepadItem = 3;

		// Token: 0x0402CC36 RID: 183350
		public const int KeyboardItem = 4;

		// Token: 0x0402CC37 RID: 183351
		public const int GamepadKeySettingItem = 5;

		// Token: 0x0402CC38 RID: 183352
		public const int PcKeySettingItem = 6;

		// Token: 0x0402CC39 RID: 183353
		public const int TipsItem = 7;

		// Token: 0x0402CC3A RID: 183354
		public const int TipsText = 8;

		// Token: 0x0402CC3B RID: 183355
		public const int ResetButton = 9;

		// Token: 0x0402CC3C RID: 183356
		public const int GamepadPanelItem = 10;

		// Token: 0x0402CC3D RID: 183357
		public const int SwitcherItem = 11;

		// Token: 0x0402CC3E RID: 183358
		public const int GamepadLogoItem = 12;

		// Token: 0x0402CC3F RID: 183359
		public const int PsAndBackBoneButtonsItem = 13;

		// Token: 0x0402CC40 RID: 183360
		public const int PsAndBackBoneResetButton = 14;

		// Token: 0x0402CC41 RID: 183361
		public const int GamepadOperationButton = 15;

		// Token: 0x0402CC42 RID: 183362
		public const int PsAndBackBoneGamepadOperationButton = 16;

		// Token: 0x0402CC43 RID: 183363
		public const int ExclusiveTypeTabRootItem = 17;
	}
}
