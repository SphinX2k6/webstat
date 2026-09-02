using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.KeySetting;
using CSharpScript.Game.Module.Menu;

// Token: 0x0200225E RID: 8798
[NullableContext(1)]
[Nullable(0)]
public class KeySettingRowData
{
	// Token: 0x17001482 RID: 5250
	// (get) Token: 0x06010995 RID: 67989 RVA: 0x0048A258 File Offset: 0x00488458
	private List<string> AllowKeys
	{
		get
		{
			if (this.AllowKeysPool == "")
			{
				return new List<string>();
			}
			KeyPool? config = ConfigKeyPoolById.GetConfig(this.AllowKeysPool, true);
			if (config != null && config.Value.ValidKeys() != null)
			{
				return config.Value.ValidKeys().ToList<string>();
			}
			return new List<string>();
		}
	}

	// Token: 0x17001483 RID: 5251
	// (get) Token: 0x06010996 RID: 67990 RVA: 0x0048A2C0 File Offset: 0x004884C0
	private List<string> AllowMainKeys
	{
		get
		{
			if (this.AllowMainKeysPool == "")
			{
				return new List<string>();
			}
			KeyPool? config = ConfigKeyPoolById.GetConfig(this.AllowMainKeysPool, true);
			if (config != null && config.Value.ValidKeys() != null)
			{
				return config.Value.ValidKeys().ToList<string>();
			}
			return new List<string>();
		}
	}

	// Token: 0x17001484 RID: 5252
	// (get) Token: 0x06010997 RID: 67991 RVA: 0x0048A328 File Offset: 0x00488528
	private List<string> AllowSecondKeys
	{
		get
		{
			if (this.AllowSecondKeysPool == "")
			{
				return new List<string>();
			}
			KeyPool? config = ConfigKeyPoolById.GetConfig(this.AllowSecondKeysPool, true);
			if (config != null && config.Value.ValidKeys() != null)
			{
				return config.Value.ValidKeys().ToList<string>();
			}
			return new List<string>();
		}
	}

	// Token: 0x06010998 RID: 67992 RVA: 0x0048A38E File Offset: 0x0048858E
	public void InitializeKeyType(KeyType keyType)
	{
		this.ConfigId = keyType.TypeId;
		this.KeyTypeConfig = new KeyType?(keyType);
		this.KeySettingRowType = EKeySettingRowType.KeyType;
		this.KeyTypeName = keyType.Name;
		this.KeyTypeIconSpritePath = keyType.IconSpritePath;
	}

	// Token: 0x06010999 RID: 67993 RVA: 0x0048A3CC File Offset: 0x004885CC
	public void InitializeKeySetting(KeySetting keySettingConfig)
	{
		this.ConfigId = keySettingConfig.Id;
		this.SortId = keySettingConfig.SortId;
		this.KeySettingConfig = new KeySetting?(keySettingConfig);
		this.KeySettingRowType = EKeySettingRowType.KeySetting;
		this.SettingName = keySettingConfig.Name;
		this.ActionOrAxisName = keySettingConfig.ActionOrAxisName;
		this.IsActionOrAxis = (keySettingConfig.ActionOrAxis == 1);
		this.PcKeyIndex = keySettingConfig.PcKeyIndex;
		this.GamepadKeyIndex = keySettingConfig.XBoxKeyIndex;
		this.PcAxisValue = keySettingConfig.PcAxisValue;
		this.GamepadAxisValue = keySettingConfig.XBoxAxisValue;
		this.IsLock = keySettingConfig.IsLock;
		this.DetailTextId = keySettingConfig.DetailTextId;
		this.BothActionName = keySettingConfig.BothActionName().ToList<string>();
		this.BothActionSyncAllExclusive = keySettingConfig.BothActionSyncAllExclusive;
		this.CanCombination = keySettingConfig.CanCombination;
		this.OpenViewType = (EKeySettingOpenViewType)keySettingConfig.OpenViewType;
		this.IsCheckSameKey = keySettingConfig.IsCheckSameKey;
		this.ButtonTextId = keySettingConfig.ButtonTextId;
		this.ConnectedKeySettingIdList = keySettingConfig.ConnectedKeySettingIdList().ToList<int>();
		this.CanDisable = keySettingConfig.CanDisable;
		this.AllowKeysPool = keySettingConfig.AllowKeysPool;
		this.AllowMainKeysPool = keySettingConfig.AllowMainKeysPool;
		this.AllowSecondKeysPool = keySettingConfig.AllowSecondKeysPool;
		this.BindingType = Singleton<InputSettingsManager>.Instance.GetBindTypeByExclusiveType((EKeySettingExclusiveType)keySettingConfig.ExclusiveType);
		if (this.BothActionName != null && this.BothActionName.Count == 2)
		{
			string actionName = this.BothActionName[0];
			string actionName2 = this.BothActionName[1];
			this.OneActionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding(actionName);
			this.TwoActionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding(actionName2);
		}
		else if (this.IsActionOrAxis)
		{
			this.ActionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding(this.ActionOrAxisName);
		}
		else
		{
			this.CombinationAxisBinding = Singleton<InputSettingsManager>.Instance.GetCombinationAxisBindingByAxisName(this.ActionOrAxisName);
			this.AxisBinding = Singleton<InputSettingsManager>.Instance.GetAxisBinding(this.ActionOrAxisName);
		}
		this.InitIsOriginalCombinationActionSet();
	}

	// Token: 0x0601099A RID: 67994 RVA: 0x0048A5D4 File Offset: 0x004887D4
	private void InitIsOriginalCombinationActionSet()
	{
		this.IsOriginalCombinationActionSet.Clear();
		if (Singleton<InputSettingsManager>.Instance.IsOriginalCombinationActionName(this.ActionOrAxisName, CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard))
		{
			this.IsOriginalCombinationActionSet.Add(CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard);
		}
		if (Singleton<InputSettingsManager>.Instance.IsOriginalCombinationActionName(this.ActionOrAxisName, CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad))
		{
			this.IsOriginalCombinationActionSet.Add(CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad);
		}
	}

	// Token: 0x0601099B RID: 67995 RVA: 0x0048A62C File Offset: 0x0048882C
	[NullableContext(2)]
	public InputCombinationActionBinding FindCombinationActionBinding()
	{
		return Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName(this.ActionOrAxisName);
	}

	// Token: 0x0601099C RID: 67996 RVA: 0x0048A63E File Offset: 0x0048883E
	public void Clear()
	{
		this.ActionBinding = null;
		this.AxisBinding = null;
		this.CombinationAxisBinding = null;
		this.OneActionBinding = null;
		this.TwoActionBinding = null;
	}

	// Token: 0x0601099D RID: 67997 RVA: 0x0048A663 File Offset: 0x00488863
	public EKeySettingRowType GetRowType()
	{
		return this.KeySettingRowType;
	}

	// Token: 0x0601099E RID: 67998 RVA: 0x0048A66B File Offset: 0x0048886B
	public KeyType? GetKeyTypeConfig()
	{
		return this.KeyTypeConfig;
	}

	// Token: 0x0601099F RID: 67999 RVA: 0x0048A673 File Offset: 0x00488873
	public KeySetting? GetKeySettingConfig()
	{
		return this.KeySettingConfig;
	}

	// Token: 0x060109A0 RID: 68000 RVA: 0x0048A67B File Offset: 0x0048887B
	public string GetSettingName()
	{
		return this.SettingName;
	}

	// Token: 0x060109A1 RID: 68001 RVA: 0x0048A683 File Offset: 0x00488883
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> GetDisplayKeyName(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (this.OneActionBinding != null && this.TwoActionBinding != null)
		{
			return this.GetBothActionKeyName(this.OneActionBinding, this.TwoActionBinding, inputControllerType);
		}
		return this.GetCurrentKeyName(inputControllerType);
	}

	// Token: 0x060109A2 RID: 68002 RVA: 0x0048A6B0 File Offset: 0x004888B0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> GetBothActionKeyName(InputActionBinding oneActionBinding, InputActionBinding twoActionBinding, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (oneActionBinding == null || twoActionBinding == null)
		{
			return null;
		}
		List<string> actionSegmentKeys = this.GetActionSegmentKeys(oneActionBinding, inputControllerType, this.BindingType);
		List<string> actionSegmentKeys2 = this.GetActionSegmentKeys(twoActionBinding, inputControllerType, this.BindingType);
		return new List<string>
		{
			actionSegmentKeys[0],
			actionSegmentKeys2[0]
		};
	}

	// Token: 0x060109A3 RID: 68003 RVA: 0x0048A704 File Offset: 0x00488904
	private List<string> GetActionSegmentKeys(InputActionBinding actionBinding, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType, EInputBindingType bindingType)
	{
		List<string> list = new List<string>();
		if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
		{
			if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
			{
				actionBinding.GetGamepadKeyNameListByBindingType(list, bindingType);
			}
		}
		else
		{
			actionBinding.GetPcKeyNameListByBindingType(list, bindingType);
		}
		return list;
	}

	// Token: 0x060109A4 RID: 68004 RVA: 0x0048A734 File Offset: 0x00488934
	private void SetActionSegmentKeys(InputActionBinding actionBinding, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType, List<string> segmentKeys, EInputBindingType bindingType)
	{
		if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
		{
			actionBinding.SetKeyboardKeys(segmentKeys, bindingType);
			return;
		}
		if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
		{
			return;
		}
		actionBinding.SetGamepadKeys(segmentKeys, bindingType);
	}

	// Token: 0x060109A5 RID: 68005 RVA: 0x0048A752 File Offset: 0x00488952
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> GetCurrentKeyName(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (this.IsActionOrAxis)
		{
			return this.GetCurrentActionName(inputControllerType);
		}
		return this.GetCurrentAxisName(inputControllerType);
	}

	// Token: 0x060109A6 RID: 68006 RVA: 0x0048A76C File Offset: 0x0048896C
	public string GetCurrentKeyNameRichText(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType, string linkString = "+")
	{
		List<string> displayKeyName = this.GetDisplayKeyName(inputControllerType);
		if (displayKeyName == null)
		{
			return "";
		}
		return this.GetKeyNameRichTextByKeyNameList(inputControllerType, displayKeyName, linkString);
	}

	// Token: 0x060109A7 RID: 68007 RVA: 0x0048A794 File Offset: 0x00488994
	public string GetKeyNameRichTextByKeyNameList(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType, List<string> keyNameList, string linkString = "+")
	{
		if (keyNameList == null)
		{
			return "";
		}
		string text = "";
		for (int i = 0; i < keyNameList.Count; i++)
		{
			string keyName = keyNameList[i];
			string keyIconPath = this.GetKeyIconPath(keyName, inputControllerType);
			if (!string.IsNullOrEmpty(keyIconPath))
			{
				text = text + "<texture=" + keyIconPath + ">";
			}
			if (i < keyNameList.Count - 1)
			{
				text += linkString;
			}
		}
		return text;
	}

	// Token: 0x060109A8 RID: 68008 RVA: 0x0048A800 File Offset: 0x00488A00
	[return: Nullable(2)]
	public string GetKeyIconPath(string keyName, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		InputSettingsConfig instance = ConfigBase<InputSettingsConfig>.Instance;
		if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
		{
			if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
			{
				return null;
			}
			GamepadKey? gamepadKey = (instance != null) ? instance.GetGamepadKeyConfig(keyName) : null;
			if (gamepadKey != null)
			{
				global::EInputControllerType lastGamepadEnum = InputKeyUtils.GetLastGamepadEnum();
				string gamepadKeyIconPathByType = InputKeyUtils.GetGamepadKeyIconPathByType(keyName, lastGamepadEnum);
				if (StringUtils.IsBlank(gamepadKeyIconPathByType))
				{
					return null;
				}
				return gamepadKeyIconPathByType;
			}
		}
		else
		{
			string pcKeyIconPathByCurrentPlatform = InputKeyUtils.GetPcKeyIconPathByCurrentPlatform(keyName);
			if (pcKeyIconPathByCurrentPlatform != null)
			{
				return pcKeyIconPathByCurrentPlatform;
			}
		}
		return null;
	}

	// Token: 0x060109A9 RID: 68009 RVA: 0x0048A86C File Offset: 0x00488A6C
	private bool IsValidActionKey(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (this.ActionBinding == null)
		{
			return false;
		}
		int keyIndex = this.GetKeyIndex(inputControllerType);
		List<string> list = new List<string>();
		this.ActionBinding.GetKeyNameListByBindingType(list, this.BindingType);
		string text = (list.Count > keyIndex) ? list[keyIndex] : null;
		return !string.IsNullOrEmpty(text) && Singleton<InputSettings>.Instance.IsValidKey(text);
	}

	// Token: 0x060109AA RID: 68010 RVA: 0x0048A8CC File Offset: 0x00488ACC
	public bool IsCombination(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (!this.IsActionOrAxis)
		{
			if (this.CombinationAxisBinding != null)
			{
				if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
				{
					return this.CombinationAxisBinding.HasKeyboardCombinationAxis(this.BindingType);
				}
				if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
				{
					return this.CombinationAxisBinding.HasGamepadCombinationAxis(this.BindingType);
				}
			}
			return false;
		}
		InputCombinationActionBinding inputCombinationActionBinding = this.FindCombinationActionBinding();
		if (inputCombinationActionBinding == null && !this.IsValidActionKey(inputControllerType))
		{
			return false;
		}
		if (inputCombinationActionBinding != null)
		{
			if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
			{
				return inputCombinationActionBinding.HasKeyboardCombinationAction(this.BindingType);
			}
			if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
			{
				return inputCombinationActionBinding.HasGamepadCombinationActionByBindingType(this.BindingType);
			}
		}
		return false;
	}

	// Token: 0x060109AB RID: 68011 RVA: 0x0048A958 File Offset: 0x00488B58
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private List<string> GetCurrentActionName(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (this.IsCombination(inputControllerType))
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
			{
				if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
				{
					return null;
				}
				InputCombinationActionBinding inputCombinationActionBinding = this.FindCombinationActionBinding();
				if (inputCombinationActionBinding != null)
				{
					inputCombinationActionBinding.GetGamepadKeyNameMapByBindingType(dictionary, this.BindingType);
				}
			}
			else
			{
				InputCombinationActionBinding inputCombinationActionBinding2 = this.FindCombinationActionBinding();
				if (inputCombinationActionBinding2 != null)
				{
					inputCombinationActionBinding2.GetPcKeyNameMap(dictionary, this.BindingType);
				}
			}
			if (dictionary == null || dictionary.Count == 0)
			{
				return null;
			}
			using (Dictionary<string, string>.Enumerator enumerator = dictionary.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<string, string> keyValuePair = enumerator.Current;
					return new List<string>
					{
						keyValuePair.Key,
						keyValuePair.Value
					};
				}
			}
			return null;
		}
		else
		{
			if (this.ActionBinding == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			InputActionBinding actionBinding = this.ActionBinding;
			if (actionBinding != null)
			{
				actionBinding.GetKeyNameListByBindingType(list, this.BindingType);
			}
			if (list == null || list.Count <= 0)
			{
				return null;
			}
			if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
			{
				if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
				{
					return null;
				}
				if (list.Count <= this.GamepadKeyIndex)
				{
					return null;
				}
				return new List<string>
				{
					list[this.GamepadKeyIndex]
				};
			}
			else
			{
				if (list.Count <= this.PcKeyIndex)
				{
					return null;
				}
				return new List<string>
				{
					list[this.PcKeyIndex]
				};
			}
		}
	}

	// Token: 0x060109AC RID: 68012 RVA: 0x0048AABC File Offset: 0x00488CBC
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private List<string> GetCurrentAxisName(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (this.IsCombination(inputControllerType))
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
			{
				if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
				{
					return null;
				}
				InputCombinationAxisBinding combinationAxisBinding = this.CombinationAxisBinding;
				if (combinationAxisBinding != null)
				{
					combinationAxisBinding.GetGamepadKeyNameMap(dictionary, this.BindingType);
				}
			}
			else
			{
				InputCombinationAxisBinding combinationAxisBinding2 = this.CombinationAxisBinding;
				if (combinationAxisBinding2 != null)
				{
					combinationAxisBinding2.GetPcKeyNameMap(dictionary, this.BindingType);
				}
			}
			if (dictionary == null || dictionary.Count == 0)
			{
				return null;
			}
			using (Dictionary<string, string>.Enumerator enumerator = dictionary.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<string, string> keyValuePair = enumerator.Current;
					return new List<string>
					{
						keyValuePair.Key,
						keyValuePair.Value
					};
				}
			}
			return null;
		}
		else
		{
			string inputAxisKeyName = this.GetInputAxisKeyName(inputControllerType);
			if (string.IsNullOrEmpty(inputAxisKeyName))
			{
				return null;
			}
			return new List<string>
			{
				inputAxisKeyName
			};
		}
	}

	// Token: 0x060109AD RID: 68013 RVA: 0x0048ABA8 File Offset: 0x00488DA8
	[NullableContext(2)]
	private string GetInputAxisKeyName(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		InputAxisBinding axisBinding = this.AxisBinding;
		Dictionary<string, InputAxisKey> dictionary = (axisBinding != null) ? axisBinding.GetInputAxisKeyMap(this.BindingType) : null;
		if (dictionary == null)
		{
			return null;
		}
		foreach (KeyValuePair<string, InputAxisKey> keyValuePair in dictionary)
		{
			string key = keyValuePair.Key;
			InputAxisKey value = keyValuePair.Value;
			InputKey key2 = value.GetKey();
			if (key2 != null)
			{
				if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
				{
					if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
					{
						return null;
					}
					if (key2.IsGamepadKey && value.Scale == this.GamepadAxisValue)
					{
						return key;
					}
				}
				else if ((key2.IsKeyboardKey || key2.IsMouseButton) && value.Scale == this.PcAxisValue)
				{
					return key;
				}
			}
		}
		return null;
	}

	// Token: 0x060109AE RID: 68014 RVA: 0x0048AC84 File Offset: 0x00488E84
	public void ChangeBothAction(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (this.OneActionBinding == null || this.TwoActionBinding == null)
		{
			return;
		}
		List<string> actionSegmentKeys = this.GetActionSegmentKeys(this.OneActionBinding, inputControllerType, this.BindingType);
		List<string> actionSegmentKeys2 = this.GetActionSegmentKeys(this.TwoActionBinding, inputControllerType, this.BindingType);
		if (actionSegmentKeys.Count <= 0 || actionSegmentKeys2.Count <= 0)
		{
			return;
		}
		string value = actionSegmentKeys[0];
		actionSegmentKeys[0] = actionSegmentKeys2[0];
		actionSegmentKeys2[0] = value;
		if (!this.BothActionSyncAllExclusive)
		{
			this.SetActionSegmentKeys(this.OneActionBinding, inputControllerType, actionSegmentKeys, this.BindingType);
			this.SetActionSegmentKeys(this.TwoActionBinding, inputControllerType, actionSegmentKeys2, this.BindingType);
			return;
		}
		foreach (EInputBindingType bindingType in InputBindingDefine.inputBindingTypesArray)
		{
			this.SetActionSegmentKeys(this.OneActionBinding, inputControllerType, actionSegmentKeys, bindingType);
			this.SetActionSegmentKeys(this.TwoActionBinding, inputControllerType, actionSegmentKeys2, bindingType);
		}
	}

	// Token: 0x060109AF RID: 68015 RVA: 0x0048AD6A File Offset: 0x00488F6A
	public bool IsBothAction()
	{
		return this.OneActionBinding != null && this.TwoActionBinding != null;
	}

	// Token: 0x060109B0 RID: 68016 RVA: 0x0048AD80 File Offset: 0x00488F80
	private void DisableActionBindingKey(int keyIndex, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (this.ActionBinding == null)
		{
			return;
		}
		List<string> list = new List<string>();
		this.ActionBinding.GetKeyNameListByBindingType(list, this.BindingType);
		if (keyIndex < 0)
		{
			return;
		}
		while (list.Count <= keyIndex)
		{
			list.Add(string.Empty);
		}
		list[keyIndex] = this.GetInvalidKey(inputControllerType);
		this.ActionBinding.SetKeys(list, this.BindingType);
	}

	// Token: 0x060109B1 RID: 68017 RVA: 0x0048ADEC File Offset: 0x00488FEC
	private EKey GetInvalidKey(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
		{
			return EKey.Keyboard_Invalid;
		}
		if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
		{
			return EKey.Keyboard_Invalid;
		}
		return EKey.Gamepad_Invalid;
	}

	// Token: 0x060109B2 RID: 68018 RVA: 0x0048AE0C File Offset: 0x0048900C
	private void DisableAxisBindingKey(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (this.AxisBinding == null)
		{
			return;
		}
		if (this.AxisBinding.GetInputAxisKeyMap(this.BindingType) == null)
		{
			return;
		}
		string inputAxisKeyName = this.GetInputAxisKeyName(inputControllerType);
		if (string.IsNullOrEmpty(inputAxisKeyName))
		{
			return;
		}
		Dictionary<string, float> axisKeyScaleMap = this.GetAxisKeyScaleMap();
		float value;
		if (axisKeyScaleMap.TryGetValue(inputAxisKeyName, out value))
		{
			axisKeyScaleMap.Remove(inputAxisKeyName);
			string key = this.GetInvalidKey(inputControllerType);
			axisKeyScaleMap.Add(key, value);
		}
		this.AxisBinding.SetKeys(axisKeyScaleMap, this.BindingType);
	}

	// Token: 0x060109B3 RID: 68019 RVA: 0x0048AE88 File Offset: 0x00489088
	private void InsertDisableKeyName(List<string> keyNameList, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		for (int i = 0; i < keyNameList.Count; i++)
		{
			if (string.IsNullOrEmpty((keyNameList.Count > i) ? keyNameList[i] : null))
			{
				keyNameList[i] = this.GetInvalidKey(inputControllerType);
			}
		}
	}

	// Token: 0x060109B4 RID: 68020 RVA: 0x0048AED3 File Offset: 0x004890D3
	public bool SetKey(List<string> keyNameList, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (this.IsActionOrAxis)
		{
			return this.SetActionKey(keyNameList, inputControllerType);
		}
		return !this.IsCombination(inputControllerType) && (keyNameList != null && keyNameList.Count > 0) && this.SetAxisKey(keyNameList[0], inputControllerType);
	}

	// Token: 0x060109B5 RID: 68021 RVA: 0x0048AF0D File Offset: 0x0048910D
	public void DisableKey(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (this.OneActionBinding != null && this.TwoActionBinding != null)
		{
			return;
		}
		if (this.IsActionOrAxis)
		{
			this.DisableActionKey(inputControllerType);
			return;
		}
		this.DisableAxisKey(inputControllerType);
	}

	// Token: 0x060109B6 RID: 68022 RVA: 0x0048AF37 File Offset: 0x00489137
	public string ConvertKeyToActionOrAxis(string keyName)
	{
		return InputKeyUtils.ConvertKeyToActionOrAxis(keyName, this.IsActionOrAxis);
	}

	// Token: 0x060109B7 RID: 68023 RVA: 0x0048AF48 File Offset: 0x00489148
	private bool SetActionKey([Nullable(new byte[]
	{
		2,
		1
	})] List<string> keyNameList, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (keyNameList == null || keyNameList.Count <= 0)
		{
			if (this.ActionBinding != null)
			{
				int keyIndex = this.GetKeyIndex(inputControllerType);
				this.DisableActionBindingKey(keyIndex, inputControllerType);
			}
			Singleton<InputSettingsManager>.Instance.ClearCombinationActionKeyMap();
			return true;
		}
		List<string> currentKeyName = this.GetCurrentKeyName(inputControllerType);
		if (currentKeyName != null && currentKeyName.Count > 0 && currentKeyName[0] == keyNameList[0] && ((currentKeyName.Count > 1) ? currentKeyName[1] : null) == ((keyNameList.Count > 1) ? keyNameList[1] : null))
		{
			return true;
		}
		if (currentKeyName != null && currentKeyName.Count > 1)
		{
			Singleton<InputSettingsManager>.Instance.RemoveCombinationActionKeyMap(this.ActionOrAxisName, currentKeyName[0], (currentKeyName.Count > 1) ? currentKeyName[1] : "", this.BindingType);
		}
		if (keyNameList.Count == 1 || !this.CanCombination)
		{
			string value = this.ConvertKeyToActionOrAxis(keyNameList[0]);
			int keyIndex2 = this.GetKeyIndex(inputControllerType);
			if (keyIndex2 < 0)
			{
				return false;
			}
			if (this.ActionBinding != null)
			{
				List<string> list = new List<string>();
				this.ActionBinding.GetKeyNameListByBindingType(list, this.BindingType);
				if (list == null)
				{
					return false;
				}
				while (list.Count <= keyIndex2)
				{
					list.Add(string.Empty);
				}
				list[keyIndex2] = value;
				this.InsertDisableKeyName(list, inputControllerType);
				this.ActionBinding.SetKeys(list, this.BindingType);
				return true;
			}
		}
		else if (keyNameList.Count > 1)
		{
			Singleton<InputSettingsManager>.Instance.AddCombinationActionKeyMap(this.ActionOrAxisName, this.ConvertKeyToActionOrAxis(keyNameList[0]), (keyNameList.Count > 1) ? keyNameList[1] : "", this.BindingType);
			int keyIndex3 = this.GetKeyIndex(inputControllerType);
			this.DisableActionBindingKey(keyIndex3, inputControllerType);
		}
		return true;
	}

	// Token: 0x060109B8 RID: 68024 RVA: 0x0048B10C File Offset: 0x0048930C
	private void DisableActionKey(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (this.IsCombination(inputControllerType))
		{
			List<string> currentKeyName = this.GetCurrentKeyName(inputControllerType);
			if (currentKeyName != null && currentKeyName.Count > 1)
			{
				Singleton<InputSettingsManager>.Instance.RemoveCombinationActionKeyMap(this.ActionOrAxisName, currentKeyName[0], (currentKeyName.Count > 1) ? currentKeyName[1] : "", this.BindingType);
			}
			return;
		}
		if (this.ActionBinding != null)
		{
			int keyIndex = this.GetKeyIndex(inputControllerType);
			this.DisableActionBindingKey(keyIndex, inputControllerType);
		}
	}

	// Token: 0x060109B9 RID: 68025 RVA: 0x0048B184 File Offset: 0x00489384
	[NullableContext(2)]
	private bool SetAxisKey(string newKeyName, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (this.AxisBinding == null)
		{
			return false;
		}
		if (string.IsNullOrEmpty(newKeyName) && this.AxisBinding != null)
		{
			Dictionary<string, float> keyScaleMap = new Dictionary<string, float>();
			this.AxisBinding.SetKeys(keyScaleMap, this.BindingType);
			return true;
		}
		string text = null;
		float? num = null;
		Dictionary<string, float> axisKeyScaleMap = this.GetAxisKeyScaleMap();
		foreach (KeyValuePair<string, float> keyValuePair in axisKeyScaleMap)
		{
			string key = keyValuePair.Key;
			float value = keyValuePair.Value;
			InputKey key2 = Singleton<InputSettings>.Instance.GetKey(key);
			if (key2 != null)
			{
				if ((key2.IsKeyboardKey || key2.IsMouseButton) && inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard && value == this.PcAxisValue)
				{
					text = key;
					num = new float?(value);
					break;
				}
				if (key2.IsGamepadKey && inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad && value == this.GamepadAxisValue)
				{
					text = key;
					num = new float?(value);
					break;
				}
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			axisKeyScaleMap.Remove(text);
		}
		if (num != null && num.GetValueOrDefault() != 0f && !string.IsNullOrEmpty(newKeyName))
		{
			axisKeyScaleMap.Add(this.ConvertKeyToActionOrAxis(newKeyName), num.Value);
		}
		this.AxisBinding.SetKeys(axisKeyScaleMap, this.BindingType);
		return true;
	}

	// Token: 0x060109BA RID: 68026 RVA: 0x0048B2E0 File Offset: 0x004894E0
	private void DisableAxisKey(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (this.IsCombination(inputControllerType))
		{
			return;
		}
		this.DisableAxisBindingKey(inputControllerType);
	}

	// Token: 0x060109BB RID: 68027 RVA: 0x0048B2F3 File Offset: 0x004894F3
	public void SetAxisBindingKeys(Dictionary<string, float> keyScaleMap, EInputBindingType bindingType)
	{
		InputAxisBinding axisBinding = this.AxisBinding;
		if (axisBinding == null)
		{
			return;
		}
		axisBinding.SetKeys(keyScaleMap, bindingType);
	}

	// Token: 0x060109BC RID: 68028 RVA: 0x0048B308 File Offset: 0x00489508
	public Dictionary<string, float> GetAxisKeyScaleMap()
	{
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		if (this.AxisBinding == null)
		{
			return dictionary;
		}
		Dictionary<string, InputAxisKey> inputAxisKeyMap = this.AxisBinding.GetInputAxisKeyMap(this.BindingType);
		if (inputAxisKeyMap == null)
		{
			return dictionary;
		}
		foreach (KeyValuePair<string, InputAxisKey> keyValuePair in inputAxisKeyMap)
		{
			string key = keyValuePair.Key;
			InputAxisKey value = keyValuePair.Value;
			dictionary.Add(key, value.Scale);
		}
		return dictionary;
	}

	// Token: 0x060109BD RID: 68029 RVA: 0x0048B398 File Offset: 0x00489598
	public int GetKeyIndex(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
		{
			return this.PcKeyIndex;
		}
		if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
		{
			return -1;
		}
		return this.GamepadKeyIndex;
	}

	// Token: 0x060109BE RID: 68030 RVA: 0x0048B3B3 File Offset: 0x004895B3
	public float GetKeyScale(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
		{
			return this.PcAxisValue;
		}
		if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
		{
			return 0f;
		}
		return this.GamepadAxisValue;
	}

	// Token: 0x060109BF RID: 68031 RVA: 0x0048B3D2 File Offset: 0x004895D2
	public bool IsAllowKey(string keyName)
	{
		return this.AllowKeys == null || this.AllowKeys.Count <= 0 || this.AllowKeys.Contains(keyName);
	}

	// Token: 0x060109C0 RID: 68032 RVA: 0x0048B3F8 File Offset: 0x004895F8
	public bool IsAllowCombinationKey(string mainKeyName, string secondKeyName)
	{
		return (this.AllowMainKeys == null || this.AllowMainKeys.Count <= 0 || this.AllowMainKeys.Contains(mainKeyName)) && (this.AllowSecondKeys == null || this.AllowSecondKeys.Count <= 0 || this.AllowSecondKeys.Contains(secondKeyName));
	}

	// Token: 0x060109C1 RID: 68033 RVA: 0x0048B460 File Offset: 0x00489660
	[NullableContext(2)]
	private bool IsSameKey(string keyName1, string keyName2)
	{
		return keyName1 != null && keyName2 != null && (keyName1 == keyName2 || ((keyName1.Contains(EKey.Gamepad_LeftTrigger) && keyName2.Contains(EKey.Gamepad_LeftTrigger)) || (keyName1.Contains(EKey.Gamepad_RightTrigger) && keyName2.Contains(EKey.Gamepad_RightTrigger))));
	}

	// Token: 0x060109C2 RID: 68034 RVA: 0x0048B4CC File Offset: 0x004896CC
	public bool HasKey(List<string> keyNameList, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (keyNameList.Count > 1)
		{
			if (this.IsCombination(inputControllerType))
			{
				InputCombinationActionBinding inputCombinationActionBinding = this.FindCombinationActionBinding();
				if (inputCombinationActionBinding != null)
				{
					return inputCombinationActionBinding.HasKey(keyNameList[0], (keyNameList.Count > 1) ? keyNameList[1] : "", this.BindingType);
				}
				if (this.CombinationAxisBinding != null)
				{
					return this.CombinationAxisBinding.HasKey(keyNameList[0], (keyNameList.Count > 1) ? keyNameList[1] : "", this.BindingType);
				}
			}
			return false;
		}
		string keyName = keyNameList[0];
		if (this.ActionBinding == null)
		{
			if (this.AxisBinding != null)
			{
				float keyScale = this.GetKeyScale(inputControllerType);
				foreach (InputAxisKey inputAxisKey in this.AxisBinding.GetKey(keyScale, this.BindingType))
				{
					if (this.IsSameKey(inputAxisKey.KeyName, keyName))
					{
						return true;
					}
				}
			}
			return false;
		}
		int keyIndex = this.GetKeyIndex(inputControllerType);
		List<string> list = new List<string>();
		this.ActionBinding.GetKeyNameListByBindingType(list, this.BindingType);
		if (list == null || list.Count == 0)
		{
			return false;
		}
		string keyName2 = (list.Count > keyIndex) ? list[keyIndex] : null;
		return this.IsSameKey(keyName2, keyName);
	}

	// Token: 0x060109C3 RID: 68035 RVA: 0x0048B609 File Offset: 0x00489809
	public string GetActionOrAxisName()
	{
		return this.ActionOrAxisName;
	}

	// Token: 0x060109C4 RID: 68036 RVA: 0x0048B614 File Offset: 0x00489814
	public void ResetKey(CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		if (this.ActionOrAxisName == null || this.ActionOrAxisName == "")
		{
			return;
		}
		if (this.BothActionName != null && this.BothActionName.Count == 2)
		{
			Singleton<InputSettingsManager>.Instance.ResetActionKeyByName(this.BothActionName[0], this.BindingType);
			Singleton<InputSettingsManager>.Instance.ResetActionKeyByName(this.BothActionName[1], this.BindingType);
			return;
		}
		bool flag = this.IsCombination(inputControllerType);
		bool flag2 = this.IsOriginalCombinationActionSet.Contains(inputControllerType);
		if (flag || flag2)
		{
			if (this.IsActionOrAxis)
			{
				Singleton<InputSettingsManager>.Instance.ResetCombinationActionKeyByName(this.ActionOrAxisName, inputControllerType, this.BindingType);
			}
			if (flag != flag2)
			{
				if (this.IsActionOrAxis)
				{
					Singleton<InputSettingsManager>.Instance.ResetActionKeyByName(this.ActionOrAxisName, this.BindingType);
					return;
				}
				Singleton<InputSettingsManager>.Instance.ResetAxisKeyByName(this.ActionOrAxisName, this.BindingType);
				return;
			}
		}
		else
		{
			if (this.IsActionOrAxis)
			{
				Singleton<InputSettingsManager>.Instance.ResetActionKeyByName(this.ActionOrAxisName, this.BindingType);
				return;
			}
			Singleton<InputSettingsManager>.Instance.ResetAxisKeyByName(this.ActionOrAxisName, this.BindingType);
		}
	}

	// Token: 0x040082AC RID: 33452
	private KeyType? KeyTypeConfig;

	// Token: 0x040082AD RID: 33453
	private KeySetting? KeySettingConfig;

	// Token: 0x040082AE RID: 33454
	private EKeySettingRowType KeySettingRowType;

	// Token: 0x040082AF RID: 33455
	public bool IsExpandDetail;

	// Token: 0x040082B0 RID: 33456
	private string SettingName = "";

	// Token: 0x040082B1 RID: 33457
	private string ActionOrAxisName = "";

	// Token: 0x040082B2 RID: 33458
	private readonly HashSet<CSharpScript.Game.Module.Menu.EInputControllerType> IsOriginalCombinationActionSet = new HashSet<CSharpScript.Game.Module.Menu.EInputControllerType>();

	// Token: 0x040082B3 RID: 33459
	public bool IsActionOrAxis = true;

	// Token: 0x040082B4 RID: 33460
	[Nullable(2)]
	public InputActionBinding ActionBinding;

	// Token: 0x040082B5 RID: 33461
	[Nullable(2)]
	public InputAxisBinding AxisBinding;

	// Token: 0x040082B6 RID: 33462
	[Nullable(2)]
	public InputCombinationAxisBinding CombinationAxisBinding;

	// Token: 0x040082B7 RID: 33463
	[Nullable(2)]
	public InputActionBinding OneActionBinding;

	// Token: 0x040082B8 RID: 33464
	[Nullable(2)]
	public InputActionBinding TwoActionBinding;

	// Token: 0x040082B9 RID: 33465
	private int PcKeyIndex;

	// Token: 0x040082BA RID: 33466
	private int GamepadKeyIndex;

	// Token: 0x040082BB RID: 33467
	private float PcAxisValue;

	// Token: 0x040082BC RID: 33468
	private float GamepadAxisValue;

	// Token: 0x040082BD RID: 33469
	public bool IsLock;

	// Token: 0x040082BE RID: 33470
	private string AllowKeysPool = "";

	// Token: 0x040082BF RID: 33471
	private string AllowMainKeysPool = "";

	// Token: 0x040082C0 RID: 33472
	private string AllowSecondKeysPool = "";

	// Token: 0x040082C1 RID: 33473
	public List<int> ConnectedKeySettingIdList = new List<int>();

	// Token: 0x040082C2 RID: 33474
	public string KeyTypeName = "";

	// Token: 0x040082C3 RID: 33475
	public string KeyTypeIconSpritePath = "";

	// Token: 0x040082C4 RID: 33476
	public string DetailTextId = "";

	// Token: 0x040082C5 RID: 33477
	public int ConfigId;

	// Token: 0x040082C6 RID: 33478
	public int SortId;

	// Token: 0x040082C7 RID: 33479
	public List<string> BothActionName = new List<string>();

	// Token: 0x040082C8 RID: 33480
	public bool BothActionSyncAllExclusive;

	// Token: 0x040082C9 RID: 33481
	public bool CanCombination;

	// Token: 0x040082CA RID: 33482
	public EKeySettingOpenViewType OpenViewType;

	// Token: 0x040082CB RID: 33483
	public bool IsCheckSameKey = true;

	// Token: 0x040082CC RID: 33484
	[Nullable(2)]
	public string ButtonTextId;

	// Token: 0x040082CD RID: 33485
	public bool CanDisable;

	// Token: 0x040082CE RID: 33486
	public EInputBindingType BindingType;

	// Token: 0x040082CF RID: 33487
	[Nullable(2)]
	public Action HelpBtnCallBack;
}
