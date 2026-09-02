using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.KeySetting;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002089 RID: 8329
[NullableContext(1)]
[Nullable(0)]
[StaticVariableRuleIgnore]
public class KeySettingViewModel
{
	// Token: 0x170012E0 RID: 4832
	// (get) Token: 0x0600FDD5 RID: 64981 RVA: 0x00459C53 File Offset: 0x00457E53
	public static bool IsEditing
	{
		get
		{
			return KeySettingViewModel.IsEditingInternal;
		}
	}

	// Token: 0x170012E1 RID: 4833
	// (get) Token: 0x0600FDD6 RID: 64982 RVA: 0x00459C5A File Offset: 0x00457E5A
	// (set) Token: 0x0600FDD7 RID: 64983 RVA: 0x00459C61 File Offset: 0x00457E61
	public static CSharpScript.Game.Module.Menu.EInputControllerType InputControllerType
	{
		get
		{
			return KeySettingViewModel.InputControllerTypeInternal;
		}
		set
		{
			KeySettingViewModel.InputControllerTypeInternal = value;
		}
	}

	// Token: 0x170012E2 RID: 4834
	// (get) Token: 0x0600FDD8 RID: 64984 RVA: 0x00459C6C File Offset: 0x00457E6C
	public static EKeySettingDeviceType CurrentDeviceType
	{
		get
		{
			CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType = KeySettingViewModel.InputControllerType;
			if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
			{
				return EKeySettingDeviceType.Keyboard;
			}
			if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
			{
				return EKeySettingDeviceType.None;
			}
			return EKeySettingDeviceType.Gamepad;
		}
	}

	// Token: 0x0600FDD9 RID: 64985 RVA: 0x00459C8E File Offset: 0x00457E8E
	public static void OnViewStart()
	{
		KeySettingViewModel.AddEvents();
		if (Singleton<Info>.Instance.IsInKeyBoard())
		{
			KeySettingViewModel.InputControllerType = CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard;
			return;
		}
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			KeySettingViewModel.InputControllerType = CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad;
		}
	}

	// Token: 0x0600FDDA RID: 64986 RVA: 0x00459CBC File Offset: 0x00457EBC
	public static void InitData(EKeySettingExclusiveType type = EKeySettingExclusiveType.None)
	{
		IReadOnlyList<KeyType> allKeyTypeConfig = ConfigBase<MenuBaseConfig>.Instance.GetAllKeyTypeConfig();
		if (allKeyTypeConfig == null)
		{
			return;
		}
		KeySettingViewModel.KeySettingRowDataMap.Clear();
		KeySettingViewModel.HiddenKeySettingRowDataMap.Clear();
		KeySettingViewModel.InitializeKeyBoardSettingRowData(allKeyTypeConfig, type);
		KeySettingViewModel.InitializeXboxKeySettingRowData(allKeyTypeConfig, type);
	}

	// Token: 0x0600FDDB RID: 64987 RVA: 0x00459CFA File Offset: 0x00457EFA
	public static List<KeySettingRowData> GetKeySettingDataList()
	{
		if (KeySettingViewModel.InputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
		{
			return KeySettingViewModel.KeyBoardSettingRowDataList;
		}
		if (KeySettingViewModel.InputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
		{
			return KeySettingViewModel.GamepadKeySettingRowDataList;
		}
		return new List<KeySettingRowData>();
	}

	// Token: 0x0600FDDC RID: 64988 RVA: 0x00459D1D File Offset: 0x00457F1D
	public static void OnViewDestroy()
	{
		KeySettingViewModel.Clear();
	}

	// Token: 0x0600FDDD RID: 64989 RVA: 0x00459D24 File Offset: 0x00457F24
	public static void ResetSettings()
	{
		foreach (KeySettingRowData keySettingRowData in KeySettingViewModel.KeyBoardSettingRowDataList)
		{
			keySettingRowData.ResetKey(CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard);
		}
		foreach (KeySettingRowData keySettingRowData2 in KeySettingViewModel.HiddenKeyBoardSettingRowDataList)
		{
			keySettingRowData2.ResetKey(CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard);
		}
		foreach (KeySettingRowData keySettingRowData3 in KeySettingViewModel.GamepadKeySettingRowDataList)
		{
			keySettingRowData3.ResetKey(CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad);
		}
		foreach (KeySettingRowData keySettingRowData4 in KeySettingViewModel.HiddenGamepadKeySettingRowDataList)
		{
			keySettingRowData4.ResetKey(CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad);
		}
	}

	// Token: 0x0600FDDE RID: 64990 RVA: 0x00459E34 File Offset: 0x00458034
	public static void ExternalFinishEditKey()
	{
		KeySettingViewModel.FinishEditKey();
	}

	// Token: 0x0600FDDF RID: 64991 RVA: 0x00459E3C File Offset: 0x0045803C
	public static void WaitKeySetting(KeySettingRowData data, IKeySettingItem item)
	{
		KeySettingViewModel.WaitKeySettingRowData = data;
		KeySettingViewModel.SelectKey(data);
		KeySettingViewModel.NotifyOnWaitKeySetting(data, item);
		EKeySettingOpenViewType openViewType = data.OpenViewType;
		if (openViewType != EKeySettingOpenViewType.None)
		{
			if (openViewType != EKeySettingOpenViewType.OpenAssemblyView)
			{
				if (openViewType == EKeySettingOpenViewType.OpenChangeLockView)
				{
					ControllerBase<MenuController>.Instance.OpenChangeLockView();
				}
			}
			else
			{
				ControllerBase<RouletteController>.Instance.OpenAssemblyView(ERouletteType.Function, null, null, null);
			}
			KeySettingViewModel.FinishEditKey();
			return;
		}
		if (data.IsLock)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("KeyLock", Array.Empty<object>());
			KeySettingViewModel.FinishEditKey();
			return;
		}
		KeySettingViewModel.WaitKeySettingRowData = data;
		if (data.BothActionName != null && data.BothActionName.Count == 2)
		{
			ChangeActionInfo changeActionInfo = new ChangeActionInfo();
			changeActionInfo.InputControllerType = KeySettingViewModel.InputControllerType;
			changeActionInfo.KeySettingRowData = data;
			Action<bool> onConfirmCallback;
			if ((onConfirmCallback = KeySettingViewModel.<>O.<0>__OnConfirmChangeBothAction) == null)
			{
				onConfirmCallback = (KeySettingViewModel.<>O.<0>__OnConfirmChangeBothAction = new Action<bool>(KeySettingViewModel.OnConfirmChangeBothAction));
			}
			changeActionInfo.OnConfirmCallback = onConfirmCallback;
			ChangeActionInfo param = changeActionInfo;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ChangeActionTipsView, param, null);
			KeySettingViewModel.FinishEditKey();
			return;
		}
		KeySettingViewModel.BeginEditKey();
	}

	// Token: 0x0600FDE0 RID: 64992 RVA: 0x00459F3C File Offset: 0x0045813C
	[NullableContext(2)]
	public static void SelectKey(KeySettingRowData data)
	{
		KeySettingViewModel.NotifyOnKeySelected(data);
	}

	// Token: 0x0600FDE1 RID: 64993 RVA: 0x00459F44 File Offset: 0x00458144
	public static void HoverKey(KeySettingRowData data)
	{
		KeySettingViewModel.NotifyOnKeyHover(data);
	}

	// Token: 0x0600FDE2 RID: 64994 RVA: 0x00459F4C File Offset: 0x0045814C
	public static void UnHoverKey(KeySettingRowData data)
	{
		KeySettingViewModel.NotifyOnKeyUnHover(data);
	}

	// Token: 0x0600FDE3 RID: 64995 RVA: 0x00459F54 File Offset: 0x00458154
	public static void AddOnWaitKeySettingDelegate(Action<KeySettingRowData, IKeySettingItem> d)
	{
		if (!KeySettingViewModel.DelegatesOnWaitKeySetting.Contains(d))
		{
			KeySettingViewModel.DelegatesOnWaitKeySetting.Add(d);
		}
	}

	// Token: 0x0600FDE4 RID: 64996 RVA: 0x00459F70 File Offset: 0x00458170
	public static void RemoveOnWaitKeySettingDelegate(Action<KeySettingRowData, IKeySettingItem> d)
	{
		int num = KeySettingViewModel.DelegatesOnWaitKeySetting.IndexOf(d);
		if (num != -1)
		{
			KeySettingViewModel.DelegatesOnWaitKeySetting.RemoveAt(num);
		}
	}

	// Token: 0x0600FDE5 RID: 64997 RVA: 0x00459F98 File Offset: 0x00458198
	public static void AddOnKeyChangeDelegate(Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType> d)
	{
		if (!KeySettingViewModel.DelegatesOnKeyChange.Contains(d))
		{
			KeySettingViewModel.DelegatesOnKeyChange.Add(d);
		}
	}

	// Token: 0x0600FDE6 RID: 64998 RVA: 0x00459FB4 File Offset: 0x004581B4
	public static void RemoveOnKeyChangeDelegate(Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType> d)
	{
		int num = KeySettingViewModel.DelegatesOnKeyChange.IndexOf(d);
		if (num != -1)
		{
			KeySettingViewModel.DelegatesOnKeyChange.RemoveAt(num);
		}
	}

	// Token: 0x0600FDE7 RID: 64999 RVA: 0x00459FDC File Offset: 0x004581DC
	public static void AddOnKeySelectedDelegate([Nullable(new byte[]
	{
		1,
		2
	})] Action<KeySettingRowData> d)
	{
		if (!KeySettingViewModel.DelegatesOnKeySelected.Contains(d))
		{
			KeySettingViewModel.DelegatesOnKeySelected.Add(d);
		}
	}

	// Token: 0x0600FDE8 RID: 65000 RVA: 0x00459FF8 File Offset: 0x004581F8
	public static void RemoveOnKeySelectedDelegate([Nullable(new byte[]
	{
		1,
		2
	})] Action<KeySettingRowData> d)
	{
		int num = KeySettingViewModel.DelegatesOnKeySelected.IndexOf(d);
		if (num != -1)
		{
			KeySettingViewModel.DelegatesOnKeySelected.RemoveAt(num);
		}
	}

	// Token: 0x0600FDE9 RID: 65001 RVA: 0x0045A020 File Offset: 0x00458220
	public static void AddOnBeforeBeginEditKeyDelegate(Action d)
	{
		if (!KeySettingViewModel.DelegatesOnBeforeBeginEditKey.Contains(d))
		{
			KeySettingViewModel.DelegatesOnBeforeBeginEditKey.Add(d);
		}
	}

	// Token: 0x0600FDEA RID: 65002 RVA: 0x0045A03C File Offset: 0x0045823C
	public static void RemoveOnBeforeBeginEditKeyDelegate(Action d)
	{
		int num = KeySettingViewModel.DelegatesOnBeforeBeginEditKey.IndexOf(d);
		if (num != -1)
		{
			KeySettingViewModel.DelegatesOnBeforeBeginEditKey.RemoveAt(num);
		}
	}

	// Token: 0x0600FDEB RID: 65003 RVA: 0x0045A064 File Offset: 0x00458264
	public static void AddOnBeginEditKeyDelegate(Action d)
	{
		if (!KeySettingViewModel.DelegatesOnBeginEditKey.Contains(d))
		{
			KeySettingViewModel.DelegatesOnBeginEditKey.Add(d);
		}
	}

	// Token: 0x0600FDEC RID: 65004 RVA: 0x0045A080 File Offset: 0x00458280
	public static void RemoveOnBeginEditKeyDelegate(Action d)
	{
		int num = KeySettingViewModel.DelegatesOnBeginEditKey.IndexOf(d);
		if (num != -1)
		{
			KeySettingViewModel.DelegatesOnBeginEditKey.RemoveAt(num);
		}
	}

	// Token: 0x0600FDED RID: 65005 RVA: 0x0045A0A8 File Offset: 0x004582A8
	public static void AddOnFinishEditKeyDelegate(Action d)
	{
		if (!KeySettingViewModel.DelegatesOnFinishEditKey.Contains(d))
		{
			KeySettingViewModel.DelegatesOnFinishEditKey.Add(d);
		}
	}

	// Token: 0x0600FDEE RID: 65006 RVA: 0x0045A0C4 File Offset: 0x004582C4
	public static void RemoveOnFinishEditKeyDelegate(Action d)
	{
		int num = KeySettingViewModel.DelegatesOnFinishEditKey.IndexOf(d);
		if (num != -1)
		{
			KeySettingViewModel.DelegatesOnFinishEditKey.RemoveAt(num);
		}
	}

	// Token: 0x0600FDEF RID: 65007 RVA: 0x0045A0EC File Offset: 0x004582EC
	public static void AddOnKeyHoverDelegate(Action<KeySettingRowData> d)
	{
		if (!KeySettingViewModel.DelegatesOnKeyHover.Contains(d))
		{
			KeySettingViewModel.DelegatesOnKeyHover.Add(d);
		}
	}

	// Token: 0x0600FDF0 RID: 65008 RVA: 0x0045A108 File Offset: 0x00458308
	public static void RemoveOnKeyHoverDelegate(Action<KeySettingRowData> d)
	{
		int num = KeySettingViewModel.DelegatesOnKeyHover.IndexOf(d);
		if (num != -1)
		{
			KeySettingViewModel.DelegatesOnKeyHover.RemoveAt(num);
		}
	}

	// Token: 0x0600FDF1 RID: 65009 RVA: 0x0045A130 File Offset: 0x00458330
	public static void AddOnKeyUnHoverDelegate(Action<KeySettingRowData> d)
	{
		if (!KeySettingViewModel.DelegatesOnKeyUnHover.Contains(d))
		{
			KeySettingViewModel.DelegatesOnKeyUnHover.Add(d);
		}
	}

	// Token: 0x0600FDF2 RID: 65010 RVA: 0x0045A14C File Offset: 0x0045834C
	public static void RemoveOnKeyUnHoverDelegate(Action<KeySettingRowData> d)
	{
		int num = KeySettingViewModel.DelegatesOnKeyUnHover.IndexOf(d);
		if (num != -1)
		{
			KeySettingViewModel.DelegatesOnKeyUnHover.RemoveAt(num);
		}
	}

	// Token: 0x0600FDF3 RID: 65011 RVA: 0x0045A174 File Offset: 0x00458374
	private static void NotifyOnWaitKeySetting(KeySettingRowData data, IKeySettingItem item)
	{
		foreach (Action<KeySettingRowData, IKeySettingItem> action in KeySettingViewModel.DelegatesOnWaitKeySetting)
		{
			action(data, item);
		}
	}

	// Token: 0x0600FDF4 RID: 65012 RVA: 0x0045A1C8 File Offset: 0x004583C8
	private static void NotifyOnKeyChange(KeySettingRowData data, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		foreach (Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType> action in KeySettingViewModel.DelegatesOnKeyChange)
		{
			action(data, inputControllerType);
		}
		Singleton<EventSystem>.Instance.Emit<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>(EEventName.OnCommonKeySettingKeyChange, data, inputControllerType);
	}

	// Token: 0x0600FDF5 RID: 65013 RVA: 0x0045A22C File Offset: 0x0045842C
	[NullableContext(2)]
	private static void NotifyOnKeySelected(KeySettingRowData data)
	{
		foreach (Action<KeySettingRowData> action in KeySettingViewModel.DelegatesOnKeySelected)
		{
			action(data);
		}
	}

	// Token: 0x0600FDF6 RID: 65014 RVA: 0x0045A27C File Offset: 0x0045847C
	private static void NotifyOnBeforeBeginEditKey()
	{
		foreach (Action action in KeySettingViewModel.DelegatesOnBeforeBeginEditKey)
		{
			action();
		}
	}

	// Token: 0x0600FDF7 RID: 65015 RVA: 0x0045A2CC File Offset: 0x004584CC
	private static void NotifyOnBeginEditKey()
	{
		foreach (Action action in KeySettingViewModel.DelegatesOnBeginEditKey)
		{
			action();
		}
	}

	// Token: 0x0600FDF8 RID: 65016 RVA: 0x0045A31C File Offset: 0x0045851C
	private static void NotifyOnFinishEditKey()
	{
		foreach (Action action in KeySettingViewModel.DelegatesOnFinishEditKey)
		{
			action();
		}
	}

	// Token: 0x0600FDF9 RID: 65017 RVA: 0x0045A36C File Offset: 0x0045856C
	private static void NotifyOnKeyHover(KeySettingRowData data)
	{
		foreach (Action<KeySettingRowData> action in KeySettingViewModel.DelegatesOnKeyHover)
		{
			action(data);
		}
	}

	// Token: 0x0600FDFA RID: 65018 RVA: 0x0045A3BC File Offset: 0x004585BC
	private static void NotifyOnKeyUnHover(KeySettingRowData data)
	{
		foreach (Action<KeySettingRowData> action in KeySettingViewModel.DelegatesOnKeyUnHover)
		{
			action(data);
		}
	}

	// Token: 0x0600FDFB RID: 65019 RVA: 0x0045A40C File Offset: 0x0045860C
	private static void AddEvents()
	{
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.OnInputAnyKey;
		Action<bool, FKey> handle;
		if ((handle = KeySettingViewModel.<>O.<1>__OnInputAnyKey) == null)
		{
			handle = (KeySettingViewModel.<>O.<1>__OnInputAnyKey = new Action<bool, FKey>(KeySettingViewModel.OnInputAnyKey));
		}
		instance.Add(name, handle);
	}

	// Token: 0x0600FDFC RID: 65020 RVA: 0x0045A439 File Offset: 0x00458639
	private static void RemoveEvents()
	{
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.OnInputAnyKey;
		Action<bool, FKey> handle;
		if ((handle = KeySettingViewModel.<>O.<1>__OnInputAnyKey) == null)
		{
			handle = (KeySettingViewModel.<>O.<1>__OnInputAnyKey = new Action<bool, FKey>(KeySettingViewModel.OnInputAnyKey));
		}
		instance.Remove(name, handle);
	}

	// Token: 0x0600FDFD RID: 65021 RVA: 0x0045A468 File Offset: 0x00458668
	private static void Clear()
	{
		KeySettingViewModel.DelegatesOnWaitKeySetting.Clear();
		KeySettingViewModel.DelegatesOnKeyChange.Clear();
		KeySettingViewModel.DelegatesOnKeySelected.Clear();
		KeySettingViewModel.DelegatesOnBeforeBeginEditKey.Clear();
		KeySettingViewModel.DelegatesOnBeginEditKey.Clear();
		KeySettingViewModel.DelegatesOnFinishEditKey.Clear();
		KeySettingViewModel.DelegatesOnKeyHover.Clear();
		KeySettingViewModel.DelegatesOnKeyUnHover.Clear();
		KeySettingViewModel.WaitKeySettingRowData = null;
		KeySettingViewModel.EditKeyNameList.Clear();
		KeySettingViewModel.GamepadKeySettingRowDataList.Clear();
		KeySettingViewModel.KeyBoardSettingRowDataList.Clear();
		KeySettingViewModel.KeySettingRowDataMap.Clear();
		KeySettingViewModel.HiddenKeySettingRowDataMap.Clear();
		KeySettingViewModel.InputControllerType = CSharpScript.Game.Module.Menu.EInputControllerType.None;
		KeySettingViewModel.RemoveEditKeyTimerHandle();
		KeySettingViewModel.RemoveEvents();
	}

	// Token: 0x0600FDFE RID: 65022 RVA: 0x0045A510 File Offset: 0x00458710
	private static void InitializeKeyBoardSettingRowData(IReadOnlyList<KeyType> keyTypeConfigList, EKeySettingExclusiveType exclusiveType)
	{
		KeySettingViewModel.KeyBoardSettingRowDataList.Clear();
		MenuBaseConfig instance = ConfigBase<MenuBaseConfig>.Instance;
		foreach (KeyType keyType in keyTypeConfigList)
		{
			int typeId = keyType.TypeId;
			IReadOnlyList<KeySetting> collection = instance.GetExclusiveKeySettingConfigByTypeIdAndInputControllerType(typeId, 1, exclusiveType) ?? new List<KeySetting>();
			IReadOnlyList<KeySetting> collection2 = instance.GetExclusiveKeySettingConfigByTypeIdAndInputControllerType(typeId, 0, exclusiveType) ?? new List<KeySetting>();
			List<KeySetting> list = new List<KeySetting>();
			list.AddRange(collection);
			list.AddRange(collection2);
			if (list.Count > 0)
			{
				KeySettingRowData keySettingRowData = new KeySettingRowData();
				keySettingRowData.InitializeKeyType(keyType);
				if (exclusiveType == EKeySettingExclusiveType.RhythmShip)
				{
					keySettingRowData.HelpBtnCallBack = ModelBase<RhythmShipModel>.Instance.OpenKeyHelpView;
				}
				KeySettingViewModel.KeyBoardSettingRowDataList.Add(keySettingRowData);
				list.Sort(delegate(KeySetting aConfig, KeySetting bConfig)
				{
					if (aConfig.SortId == bConfig.SortId)
					{
						return aConfig.Id - bConfig.Id;
					}
					return aConfig.SortId - bConfig.SortId;
				});
				foreach (KeySetting keySettingConfig in list)
				{
					KeySettingRowData keySettingRowData2 = new KeySettingRowData();
					keySettingRowData2.InitializeKeySetting(keySettingConfig);
					if (keySettingConfig.OnlyWorkNotShow)
					{
						KeySettingViewModel.HiddenKeySettingRowDataMap[keySettingConfig.Id] = keySettingRowData2;
					}
					else
					{
						KeySettingViewModel.KeyBoardSettingRowDataList.Add(keySettingRowData2);
						KeySettingViewModel.KeySettingRowDataMap[keySettingConfig.Id] = keySettingRowData2;
					}
				}
			}
		}
	}

	// Token: 0x0600FDFF RID: 65023 RVA: 0x0045A6B4 File Offset: 0x004588B4
	private static void InitializeXboxKeySettingRowData(IReadOnlyList<KeyType> keyTypeConfigList, EKeySettingExclusiveType exclusiveType)
	{
		KeySettingViewModel.GamepadKeySettingRowDataList.Clear();
		MenuBaseConfig instance = ConfigBase<MenuBaseConfig>.Instance;
		foreach (KeyType keyType in keyTypeConfigList)
		{
			int typeId = keyType.TypeId;
			IReadOnlyList<KeySetting> collection = instance.GetExclusiveKeySettingConfigByTypeIdAndInputControllerType(typeId, 2, exclusiveType) ?? new List<KeySetting>();
			IReadOnlyList<KeySetting> collection2 = instance.GetExclusiveKeySettingConfigByTypeIdAndInputControllerType(typeId, 0, exclusiveType) ?? new List<KeySetting>();
			List<KeySetting> list = new List<KeySetting>();
			list.AddRange(collection);
			list.AddRange(collection2);
			if (list.Count > 0)
			{
				KeySettingRowData keySettingRowData = new KeySettingRowData();
				keySettingRowData.InitializeKeyType(keyType);
				if (exclusiveType == EKeySettingExclusiveType.RhythmShip)
				{
					keySettingRowData.HelpBtnCallBack = ModelBase<RhythmShipModel>.Instance.OpenKeyHelpView;
				}
				KeySettingViewModel.GamepadKeySettingRowDataList.Add(keySettingRowData);
				list.Sort(delegate(KeySetting aConfig, KeySetting bConfig)
				{
					if (aConfig.SortId == bConfig.SortId)
					{
						return aConfig.Id - bConfig.Id;
					}
					return aConfig.SortId - bConfig.SortId;
				});
				foreach (KeySetting keySettingConfig in list)
				{
					KeySettingRowData keySettingRowData2 = new KeySettingRowData();
					keySettingRowData2.InitializeKeySetting(keySettingConfig);
					if (keySettingConfig.OnlyWorkNotShow)
					{
						KeySettingViewModel.HiddenKeySettingRowDataMap[keySettingConfig.Id] = keySettingRowData2;
					}
					else
					{
						KeySettingViewModel.GamepadKeySettingRowDataList.Add(keySettingRowData2);
						KeySettingViewModel.KeySettingRowDataMap[keySettingConfig.Id] = keySettingRowData2;
					}
				}
			}
		}
	}

	// Token: 0x0600FE00 RID: 65024 RVA: 0x0045A858 File Offset: 0x00458A58
	private static void RecordEditKey(string keyName)
	{
		KeySettingViewModel.EditKeyNameList.Add(keyName);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.InputSettings;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "[KeySetting]记录要设置的按键";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EditKeyNameList", new List<string>(KeySettingViewModel.EditKeyNameList));
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600FE01 RID: 65025 RVA: 0x0045A8A0 File Offset: 0x00458AA0
	private static void ClearEditKeyNameList()
	{
		KeySettingViewModel.EditKeyNameList.Clear();
	}

	// Token: 0x0600FE02 RID: 65026 RVA: 0x0045A8AC File Offset: 0x00458AAC
	private static void BeginEditKey()
	{
		KeySettingViewModel.NotifyOnBeforeBeginEditKey();
		KeySettingViewModel.EditKeyTimerHandle = TimerSystem.GameplayTimeInstance.Next(delegate(float _)
		{
			Singleton<Log>.Instance.Info(ELogModule.InputSettings, ELogAuthor.XXJ, "[KeySetting]当等待键盘输入改键时25", default(ReadOnlySpan<ValueTuple<string, object>>));
			KeySettingViewModel.RemoveEditKeyTimerHandle();
			KeySettingViewModel.SetInputDisable(true);
			KeySettingViewModel.NotifyOnBeginEditKey();
			KeySettingViewModel.IsEditingInternal = true;
		}, null, null);
	}

	// Token: 0x0600FE03 RID: 65027 RVA: 0x0045A8E4 File Offset: 0x00458AE4
	private static void FinishEditKey()
	{
		Singleton<Log>.Instance.Info(ELogModule.InputSettings, ELogAuthor.XXJ, "[KeySetting]当输入改键结束时", default(ReadOnlySpan<ValueTuple<string, object>>));
		KeySettingViewModel.SetInputDisable(false);
		KeySettingViewModel.RemoveEditKeyTimerHandle();
		KeySettingViewModel.SelectKey(null);
		Singleton<UiLayer>.Instance.SetShowMaskLayer("KeySettingMask", false);
		KeySettingViewModel.NotifyOnFinishEditKey();
		KeySettingViewModel.IsEditingInternal = false;
	}

	// Token: 0x0600FE04 RID: 65028 RVA: 0x0045A93C File Offset: 0x00458B3C
	private static void SetInputDisable(bool isDisable)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.InputSettings;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "[KeySetting]设置是否允许输入";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("isWait", isDisable);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		KeySettingViewModel.ClearEditKeyNameList();
		ModelBase<MenuModel>.Instance.IsWaitForKeyInput = isDisable;
		ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		Singleton<UiLayer>.Instance.SetShowMaskLayer("KeySettingMask", isDisable);
	}

	// Token: 0x0600FE05 RID: 65029 RVA: 0x0045A99F File Offset: 0x00458B9F
	private static void RemoveEditKeyTimerHandle()
	{
		if (KeySettingViewModel.EditKeyTimerHandle != null && TimerSystem.GameplayTimeInstance.Has(KeySettingViewModel.EditKeyTimerHandle))
		{
			TimerSystem.GameplayTimeInstance.Remove(KeySettingViewModel.EditKeyTimerHandle);
			KeySettingViewModel.EditKeyTimerHandle = null;
		}
	}

	// Token: 0x0600FE06 RID: 65030 RVA: 0x0045A9D0 File Offset: 0x00458BD0
	[return: Nullable(2)]
	private static KeySettingRowData GetSameKeySettingRowData(List<KeySettingRowData> keySettingRowDataList, List<string> checkKeyNameList, [Nullable(2)] KeySettingRowData filterKeyRowData)
	{
		if (checkKeyNameList == null || checkKeyNameList.Count <= 0)
		{
			return null;
		}
		foreach (KeySettingRowData keySettingRowData in keySettingRowDataList)
		{
			if (keySettingRowData != filterKeyRowData && keySettingRowData.HasKey(checkKeyNameList, KeySettingViewModel.InputControllerType))
			{
				return keySettingRowData;
			}
		}
		return null;
	}

	// Token: 0x0600FE07 RID: 65031 RVA: 0x0045AA40 File Offset: 0x00458C40
	private static List<KeySettingRowData> SetConnectedKey(KeySettingRowData keySettingRawData, List<string> keyNameList)
	{
		List<KeySettingRowData> list = new List<KeySettingRowData>();
		foreach (int num in keySettingRawData.ConnectedKeySettingIdList)
		{
			KeySettingRowData keySettingRowData = null;
			KeySetting? config = ConfigKeySettingById.GetConfig(num, true);
			if (config != null && config.Value.OnlyWorkNotShow)
			{
				KeySettingViewModel.HiddenKeySettingRowDataMap.TryGetValue(num, out keySettingRowData);
			}
			else
			{
				KeySettingViewModel.KeySettingRowDataMap.TryGetValue(num, out keySettingRowData);
			}
			if (keySettingRowData != null)
			{
				keySettingRowData.SetKey(keyNameList, KeySettingViewModel.InputControllerType);
				list.Add(keySettingRowData);
			}
		}
		return list;
	}

	// Token: 0x0600FE08 RID: 65032 RVA: 0x0045AAF0 File Offset: 0x00458CF0
	private static void SetAndRefreshConnectedKey(KeySettingRowData keySettingRawData, List<string> keyNameList)
	{
		foreach (KeySettingRowData data in KeySettingViewModel.SetConnectedKey(keySettingRawData, keyNameList))
		{
			KeySettingViewModel.NotifyOnKeyChange(data, KeySettingViewModel.InputControllerType);
		}
	}

	// Token: 0x0600FE09 RID: 65033 RVA: 0x0045AB48 File Offset: 0x00458D48
	private unsafe static void OnInputAnyKey(bool bPress, FKey key)
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RepeatKeyTipsView))
		{
			return;
		}
		if (ModelBase<MenuModel>.Instance == null || !ModelBase<MenuModel>.Instance.IsWaitForKeyInput)
		{
			return;
		}
		string keyName = key.KeyName.ToString();
		InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding("放弃改键");
		if (actionBinding != null && actionBinding.HasKey(keyName))
		{
			KeySettingViewModel.FinishEditKey();
			return;
		}
		if (KeySettingViewModel.WaitKeySettingRowData == null)
		{
			KeySettingViewModel.FinishEditKey();
			return;
		}
		if (KeySettingViewModel.WaitKeySettingRowData.IsLock)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("KeyLock", Array.Empty<object>());
			KeySettingViewModel.FinishEditKey();
			return;
		}
		if (bPress)
		{
			KeySettingViewModel.RecordEditKey(keyName);
			return;
		}
		if (KeySettingViewModel.EditKeyNameList.Count > 1)
		{
			if (!KeySettingViewModel.WaitKeySettingRowData.CanCombination)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[KeySetting]改键失败，原因：该输入在配置上不允许修改成组合键";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActionOrAxisName", KeySettingViewModel.WaitKeySettingRowData.GetActionOrAxisName());
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ErrorKey", Array.Empty<object>());
				KeySettingViewModel.ClearEditKeyNameList();
				return;
			}
			if (!KeySettingViewModel.WaitKeySettingRowData.IsAllowCombinationKey(KeySettingViewModel.EditKeyNameList[0], KeySettingViewModel.EditKeyNameList[1]))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.InputSettings;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "[KeySetting]改键失败，原因：尝试修改为组合输入，但不在允许设置的组合按键范围配置里内";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionOrAxisName", KeySettingViewModel.WaitKeySettingRowData.GetActionOrAxisName());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MainKey", KeySettingViewModel.EditKeyNameList[0]);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SecondKey", KeySettingViewModel.EditKeyNameList[1]);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ErrorKey", Array.Empty<object>());
				KeySettingViewModel.ClearEditKeyNameList();
				return;
			}
		}
		else
		{
			if (!KeySettingViewModel.WaitKeySettingRowData.IsAllowKey(KeySettingViewModel.EditKeyNameList[0]))
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.InputSettings;
				ELogAuthor author3 = ELogAuthor.XXJ;
				string message3 = "[KeySetting]改键失败，原因：不在允许设置的组合按键范围配置里内";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("ActionOrAxisName", KeySettingViewModel.WaitKeySettingRowData.GetActionOrAxisName());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("this.EditKeyNameList[0]", KeySettingViewModel.EditKeyNameList[0]);
				instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ErrorKey", Array.Empty<object>());
				KeySettingViewModel.ClearEditKeyNameList();
				return;
			}
			if (!ControllerBase<MenuController>.Instance.IsInputControllerTypeIncludeKey(KeySettingViewModel.InputControllerType, KeySettingViewModel.EditKeyNameList[0]))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ErrorKey", Array.Empty<object>());
				KeySettingViewModel.ClearEditKeyNameList();
				return;
			}
		}
		List<KeySettingRowData> keySettingRowDataList = KeySettingViewModel.GamepadKeySettingRowDataList;
		if (Singleton<InputSettings>.Instance.IsKeyboardKey(keyName) || Singleton<InputSettings>.Instance.IsMouseButton(keyName))
		{
			keySettingRowDataList = KeySettingViewModel.KeyBoardSettingRowDataList;
		}
		KeySettingRowData sameKeySettingRowData = KeySettingViewModel.GetSameKeySettingRowData(keySettingRowDataList, KeySettingViewModel.EditKeyNameList, KeySettingViewModel.WaitKeySettingRowData);
		if (sameKeySettingRowData != null && sameKeySettingRowData.IsCheckSameKey)
		{
			List<string> editKeyNameList = new List<string>
			{
				KeySettingViewModel.EditKeyNameList[0]
			};
			if (KeySettingViewModel.EditKeyNameList.Count > 1 && KeySettingViewModel.EditKeyNameList[1] != null)
			{
				editKeyNameList.Add(KeySettingViewModel.EditKeyNameList[1]);
			}
			RepeatKeyInfo param = new RepeatKeyInfo
			{
				InputControllerType = KeySettingViewModel.InputControllerType,
				CurrentKeySettingRowData = KeySettingViewModel.WaitKeySettingRowData,
				RepeatKeySettingRowData = sameKeySettingRowData,
				OnCloseCallback = delegate(bool bConfirm)
				{
					if (!bConfirm)
					{
						KeySettingViewModel.SetInputDisable(true);
						return;
					}
					KeySettingViewModel.FinishEditKey();
					List<string> currentKeyName = KeySettingViewModel.WaitKeySettingRowData.GetCurrentKeyName(KeySettingViewModel.InputControllerType);
					if (currentKeyName == null)
					{
						return;
					}
					if (!sameKeySettingRowData.IsActionOrAxis && !KeySettingViewModel.WaitKeySettingRowData.IsActionOrAxis && sameKeySettingRowData.GetActionOrAxisName() == KeySettingViewModel.WaitKeySettingRowData.GetActionOrAxisName() && !sameKeySettingRowData.IsCombination(KeySettingViewModel.InputControllerType) && !KeySettingViewModel.WaitKeySettingRowData.IsCombination(KeySettingViewModel.InputControllerType))
					{
						Dictionary<string, float> axisKeyScaleMap = KeySettingViewModel.WaitKeySettingRowData.GetAxisKeyScaleMap();
						string key2 = editKeyNameList[0];
						string key3 = currentKeyName[0];
						float num;
						axisKeyScaleMap.TryGetValue(key2, out num);
						float num2;
						axisKeyScaleMap.TryGetValue(key3, out num2);
						if (num2 != 0f)
						{
							axisKeyScaleMap[key2] = num2;
						}
						if (num != 0f)
						{
							axisKeyScaleMap[key3] = num;
						}
						KeySettingViewModel.WaitKeySettingRowData.SetAxisBindingKeys(axisKeyScaleMap, KeySettingViewModel.WaitKeySettingRowData.BindingType);
					}
					else
					{
						sameKeySettingRowData.SetKey(currentKeyName, KeySettingViewModel.InputControllerType);
						KeySettingViewModel.WaitKeySettingRowData.SetKey(editKeyNameList, KeySettingViewModel.InputControllerType);
					}
					KeySettingViewModel.NotifyOnKeyChange(KeySettingViewModel.WaitKeySettingRowData, KeySettingViewModel.InputControllerType);
					KeySettingViewModel.NotifyOnKeyChange(sameKeySettingRowData, KeySettingViewModel.InputControllerType);
					KeySettingViewModel.SetAndRefreshConnectedKey(KeySettingViewModel.WaitKeySettingRowData, editKeyNameList);
					KeySettingViewModel.SetAndRefreshConnectedKey(sameKeySettingRowData, currentKeyName);
					ControllerBase<InputSettingsController>.Instance.InputSettingUpdateRequest(false);
					Singleton<InputSettings>.Instance.SaveKeyMappings();
				}
			};
			KeySettingViewModel.SetInputDisable(false);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RepeatKeyTipsView, param, null);
			return;
		}
		if (KeySettingViewModel.EditKeyNameList.Count > 0)
		{
			KeySettingViewModel.WaitKeySettingRowData.SetKey(KeySettingViewModel.EditKeyNameList, KeySettingViewModel.InputControllerType);
			KeySettingViewModel.NotifyOnKeyChange(KeySettingViewModel.WaitKeySettingRowData, KeySettingViewModel.InputControllerType);
			KeySettingViewModel.SetAndRefreshConnectedKey(KeySettingViewModel.WaitKeySettingRowData, KeySettingViewModel.EditKeyNameList);
			ControllerBase<InputSettingsController>.Instance.InputSettingUpdateRequest(false);
			Singleton<InputSettings>.Instance.SaveKeyMappings();
			KeySettingViewModel.FinishEditKey();
		}
	}

	// Token: 0x0600FE0A RID: 65034 RVA: 0x0045AF44 File Offset: 0x00459144
	private static void OnConfirmChangeBothAction(bool bRevert)
	{
		if (KeySettingViewModel.WaitKeySettingRowData == null)
		{
			KeySettingViewModel.FinishEditKey();
			return;
		}
		if (bRevert)
		{
			KeySettingViewModel.WaitKeySettingRowData.ChangeBothAction(KeySettingViewModel.InputControllerType);
			KeySettingViewModel.NotifyOnKeyChange(KeySettingViewModel.WaitKeySettingRowData, KeySettingViewModel.InputControllerType);
			ControllerBase<InputSettingsController>.Instance.InputSettingUpdateRequest(false);
			Singleton<InputSettings>.Instance.SaveKeyMappings();
		}
		KeySettingViewModel.FinishEditKey();
	}

	// Token: 0x040079BE RID: 31166
	private static readonly List<Action<KeySettingRowData, IKeySettingItem>> DelegatesOnWaitKeySetting = new List<Action<KeySettingRowData, IKeySettingItem>>();

	// Token: 0x040079BF RID: 31167
	private static readonly List<Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>> DelegatesOnKeyChange = new List<Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>>();

	// Token: 0x040079C0 RID: 31168
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	private static readonly List<Action<KeySettingRowData>> DelegatesOnKeySelected = new List<Action<KeySettingRowData>>();

	// Token: 0x040079C1 RID: 31169
	private static readonly List<Action> DelegatesOnBeforeBeginEditKey = new List<Action>();

	// Token: 0x040079C2 RID: 31170
	private static readonly List<Action> DelegatesOnBeginEditKey = new List<Action>();

	// Token: 0x040079C3 RID: 31171
	private static readonly List<Action> DelegatesOnFinishEditKey = new List<Action>();

	// Token: 0x040079C4 RID: 31172
	private static readonly List<Action<KeySettingRowData>> DelegatesOnKeyHover = new List<Action<KeySettingRowData>>();

	// Token: 0x040079C5 RID: 31173
	private static readonly List<Action<KeySettingRowData>> DelegatesOnKeyUnHover = new List<Action<KeySettingRowData>>();

	// Token: 0x040079C6 RID: 31174
	[Nullable(2)]
	private static KeySettingRowData WaitKeySettingRowData;

	// Token: 0x040079C7 RID: 31175
	private static readonly List<string> EditKeyNameList = new List<string>();

	// Token: 0x040079C8 RID: 31176
	private static readonly List<KeySettingRowData> GamepadKeySettingRowDataList = new List<KeySettingRowData>();

	// Token: 0x040079C9 RID: 31177
	private static readonly List<KeySettingRowData> HiddenGamepadKeySettingRowDataList = new List<KeySettingRowData>();

	// Token: 0x040079CA RID: 31178
	private static readonly List<KeySettingRowData> KeyBoardSettingRowDataList = new List<KeySettingRowData>();

	// Token: 0x040079CB RID: 31179
	private static readonly List<KeySettingRowData> HiddenKeyBoardSettingRowDataList = new List<KeySettingRowData>();

	// Token: 0x040079CC RID: 31180
	private static readonly Dictionary<int, KeySettingRowData> KeySettingRowDataMap = new Dictionary<int, KeySettingRowData>();

	// Token: 0x040079CD RID: 31181
	private static readonly Dictionary<int, KeySettingRowData> HiddenKeySettingRowDataMap = new Dictionary<int, KeySettingRowData>();

	// Token: 0x040079CE RID: 31182
	private static CSharpScript.Game.Module.Menu.EInputControllerType InputControllerTypeInternal = CSharpScript.Game.Module.Menu.EInputControllerType.None;

	// Token: 0x040079CF RID: 31183
	private static bool IsEditingInternal = false;

	// Token: 0x040079D0 RID: 31184
	[Nullable(2)]
	private static TimerHandle EditKeyTimerHandle;

	// Token: 0x02008412 RID: 33810
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402CC2A RID: 183338
		[Nullable(0)]
		public static Action<bool> <0>__OnConfirmChangeBothAction;

		// Token: 0x0402CC2B RID: 183339
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Action<bool, FKey> <1>__OnInputAnyKey;
	}
}
