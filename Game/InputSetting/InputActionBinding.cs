using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.KeySetting;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FE7 RID: 28647
	[NullableContext(1)]
	[Nullable(0)]
	public class InputActionBinding
	{
		// Token: 0x060454A9 RID: 283817 RVA: 0x01219444 File Offset: 0x01217644
		public void Initialize(ActionMapping config)
		{
			this.ActionName = config.ActionName;
			this.Config = new ActionMapping?(config);
			this.ConfigId = this.Config.Value.Id;
			this.ActionMappingType = (EActionMappingType)this.Config.Value.ActionType;
			this.CurrentBindingType = (EInputBindingType)config.ExclusiveType;
			this.LastBindingType = (EInputBindingType)config.ExclusiveType;
			for (int i = 0; i < config.KeyboardVersionMapLength; i++)
			{
				DicIntInt? dicIntInt = config.KeyboardVersionMap(i);
				this.KeyboardVersionMap[(EKeySettingExclusiveType)dicIntInt.Value.Key] = dicIntInt.Value.Value;
			}
			for (int j = 0; j < config.GamepadVersionMapLength; j++)
			{
				DicIntInt? dicIntInt2 = config.GamepadVersionMap(j);
				this.GamepadVersionMap[(EKeySettingExclusiveType)dicIntInt2.Value.Key] = dicIntInt2.Value.Value;
			}
		}

		// Token: 0x060454AA RID: 283818 RVA: 0x01219544 File Offset: 0x01217744
		public void Clear()
		{
			this.ActionName = null;
			this.ActionMappingType = EActionMappingType.None;
			this.Config = null;
			this.PcKeys.Clear();
			this.GamepadKeys.Clear();
			this.KeyNameList.Clear();
			this.KeyNameListToBindingTypeMap.Clear();
			this.PcKeysToBindingTypeMap.Clear();
			this.GamepadKeysToBindingTypeMap.Clear();
		}

		// Token: 0x060454AB RID: 283819 RVA: 0x012195AD File Offset: 0x012177AD
		[NullableContext(2)]
		public string GetActionName()
		{
			return this.ActionName;
		}

		// Token: 0x060454AC RID: 283820 RVA: 0x012195B5 File Offset: 0x012177B5
		public void SetKeyboardVersion(int version, EKeySettingExclusiveType type)
		{
			this.KeyboardVersionMap[type] = version;
		}

		// Token: 0x060454AD RID: 283821 RVA: 0x012195C4 File Offset: 0x012177C4
		public int GetKeyboardVersion(EKeySettingExclusiveType type)
		{
			return this.KeyboardVersionMap.GetValueOrDefault(type, 0);
		}

		// Token: 0x060454AE RID: 283822 RVA: 0x012195D3 File Offset: 0x012177D3
		public void SetGamepadVersion(int version, EKeySettingExclusiveType type)
		{
			this.GamepadVersionMap[type] = version;
		}

		// Token: 0x060454AF RID: 283823 RVA: 0x012195E4 File Offset: 0x012177E4
		public int GetGamepadVersion(EKeySettingExclusiveType type)
		{
			int result;
			if (this.GamepadVersionMap.TryGetValue(type, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x060454B0 RID: 283824 RVA: 0x01219604 File Offset: 0x01217804
		[NullableContext(2)]
		public InputActionKey GetCurrentPlatformKeyByIndex(int index)
		{
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				return this.GetPcKeyByIndex(index);
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return this.GetGamepadKeyByIndex(index);
			}
			return null;
		}

		// Token: 0x060454B1 RID: 283825 RVA: 0x0121962F File Offset: 0x0121782F
		[NullableContext(2)]
		public InputKey GetCurrentPlatformKey()
		{
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				return this.GetPcKey();
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return this.GetGamepadKey();
			}
			return null;
		}

		// Token: 0x060454B2 RID: 283826 RVA: 0x01219658 File Offset: 0x01217858
		[NullableContext(2)]
		public InputActionKey GetPcKeyByIndex(int index)
		{
			if (index < 0 || index >= this.PcKeys.Count)
			{
				return null;
			}
			return Singleton<InputSettings>.Instance.GetInputActionKey(this.ActionName, this.PcKeys[index], this.CurrentBindingType);
		}

		// Token: 0x060454B3 RID: 283827 RVA: 0x01219690 File Offset: 0x01217890
		[NullableContext(2)]
		public InputKey GetPcKey()
		{
			if (this.PcKeys.Count == 0)
			{
				return null;
			}
			string key = this.PcKeys[0];
			return Singleton<InputSettings>.Instance.GetKey(key);
		}

		// Token: 0x060454B4 RID: 283828 RVA: 0x012196C4 File Offset: 0x012178C4
		[NullableContext(2)]
		public InputActionKey GetGamepadKeyByIndex(int index)
		{
			if (index < 0 || index >= this.GamepadKeys.Count)
			{
				return null;
			}
			return Singleton<InputSettings>.Instance.GetInputActionKey(this.ActionName, this.GamepadKeys[index], this.CurrentBindingType);
		}

		// Token: 0x060454B5 RID: 283829 RVA: 0x012196FC File Offset: 0x012178FC
		[NullableContext(2)]
		public InputKey GetGamepadKey()
		{
			if (this.GamepadKeys.Count == 0)
			{
				return null;
			}
			string key = this.GamepadKeys[0];
			return Singleton<InputSettings>.Instance.GetKey(key);
		}

		// Token: 0x060454B6 RID: 283830 RVA: 0x01219730 File Offset: 0x01217930
		public void GetAllPcKeyNameMap(Dictionary<EInputBindingType, List<string>> keyMapRef)
		{
			foreach (KeyValuePair<EInputBindingType, List<string>> keyValuePair in this.PcKeysToBindingTypeMap)
			{
				keyMapRef[keyValuePair.Key] = keyValuePair.Value;
			}
		}

		// Token: 0x060454B7 RID: 283831 RVA: 0x01219790 File Offset: 0x01217990
		public void GetPcKeyNameList(List<string> keyListRef)
		{
			foreach (string item in this.PcKeys)
			{
				keyListRef.Add(item);
			}
		}

		// Token: 0x060454B8 RID: 283832 RVA: 0x012197E4 File Offset: 0x012179E4
		public IReadOnlyList<string> GetPcKeyNameList()
		{
			return this.PcKeys;
		}

		// Token: 0x060454B9 RID: 283833 RVA: 0x012197EC File Offset: 0x012179EC
		public void GetPcKeyNameListByBindingType(List<string> keyListRef, EInputBindingType bindingType)
		{
			List<string> list;
			if (this.PcKeysToBindingTypeMap.TryGetValue(bindingType, out list))
			{
				foreach (string item in list)
				{
					keyListRef.Add(item);
				}
			}
		}

		// Token: 0x060454BA RID: 283834 RVA: 0x0121984C File Offset: 0x01217A4C
		public IReadOnlyList<string> GetPcKeyNameListReadonly()
		{
			return this.PcKeys;
		}

		// Token: 0x060454BB RID: 283835 RVA: 0x01219854 File Offset: 0x01217A54
		public void GetAllGamepadKeyNameMap(Dictionary<EInputBindingType, List<string>> keyMapRef)
		{
			foreach (KeyValuePair<EInputBindingType, List<string>> keyValuePair in this.GamepadKeysToBindingTypeMap)
			{
				keyMapRef[keyValuePair.Key] = keyValuePair.Value;
			}
		}

		// Token: 0x060454BC RID: 283836 RVA: 0x012198B4 File Offset: 0x01217AB4
		public void GetGamepadKeyNameList(List<string> keyListRef)
		{
			foreach (string item in this.GamepadKeys)
			{
				keyListRef.Add(item);
			}
		}

		// Token: 0x060454BD RID: 283837 RVA: 0x01219908 File Offset: 0x01217B08
		public IReadOnlyList<string> GetGamepadKeyNameList()
		{
			return this.GamepadKeys;
		}

		// Token: 0x060454BE RID: 283838 RVA: 0x01219910 File Offset: 0x01217B10
		public void GetGamepadKeyNameListByBindingType(List<string> keyListRef, EInputBindingType bindingType)
		{
			List<string> list;
			if (this.GamepadKeysToBindingTypeMap.TryGetValue(bindingType, out list))
			{
				foreach (string item in list)
				{
					keyListRef.Add(item);
				}
			}
		}

		// Token: 0x060454BF RID: 283839 RVA: 0x01219970 File Offset: 0x01217B70
		public IReadOnlyList<string> GetGamepadKeyNameListReadonly()
		{
			return this.GamepadKeys;
		}

		// Token: 0x060454C0 RID: 283840 RVA: 0x01219978 File Offset: 0x01217B78
		public void GetKeyNameList(List<string> keyListRef)
		{
			foreach (string item in this.KeyNameList)
			{
				keyListRef.Add(item);
			}
		}

		// Token: 0x060454C1 RID: 283841 RVA: 0x012199CC File Offset: 0x01217BCC
		public IReadOnlyList<string> GetKeyNameList()
		{
			return this.KeyNameList;
		}

		// Token: 0x060454C2 RID: 283842 RVA: 0x012199D4 File Offset: 0x01217BD4
		public void GetKeyNameListByBindingType(List<string> keyListRef, EInputBindingType bindingType)
		{
			List<string> collection;
			if (this.KeyNameListToBindingTypeMap.TryGetValue(bindingType, out collection))
			{
				keyListRef.AddRange(collection);
			}
		}

		// Token: 0x060454C3 RID: 283843 RVA: 0x012199F8 File Offset: 0x01217BF8
		public void GetCurrentPlatformKeyNameList(List<string> keyListRef)
		{
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				this.GetPcKeyNameList(keyListRef);
				return;
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.GetGamepadKeyNameList(keyListRef);
			}
		}

		// Token: 0x060454C4 RID: 283844 RVA: 0x01219A21 File Offset: 0x01217C21
		public IReadOnlyList<string> GetCurrentPlatformKeyNameList()
		{
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				return this.GetPcKeyNameList();
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return this.GetGamepadKeyNameList();
			}
			return Array.Empty<string>();
		}

		// Token: 0x060454C5 RID: 283845 RVA: 0x01219A4E File Offset: 0x01217C4E
		public void GetCurrentGamepadKeyNameList(List<string> keyListRef)
		{
			this.GetGamepadKeyNameList(keyListRef);
		}

		// Token: 0x060454C6 RID: 283846 RVA: 0x01219A57 File Offset: 0x01217C57
		public IReadOnlyList<string> GetCurrentGamepadKeyNameList()
		{
			return this.GetGamepadKeyNameList();
		}

		// Token: 0x060454C7 RID: 283847 RVA: 0x01219A60 File Offset: 0x01217C60
		public bool HasKey(string keyName)
		{
			Dictionary<string, InputActionKey> inputActionKeyMapByBindingType = Singleton<InputSettings>.Instance.GetInputActionKeyMapByBindingType(this.ActionName, this.CurrentBindingType);
			return inputActionKeyMapByBindingType != null && inputActionKeyMapByBindingType.ContainsKey(keyName);
		}

		// Token: 0x060454C8 RID: 283848 RVA: 0x01219A90 File Offset: 0x01217C90
		public bool HasAnyKey()
		{
			return this.KeyNameList.Count > 0;
		}

		// Token: 0x060454C9 RID: 283849 RVA: 0x01219AA0 File Offset: 0x01217CA0
		public void SwitchKeysByBindingType(EInputBindingType bindingType)
		{
			List<string> list = this.PcKeysToBindingTypeMap.GetValueOrDefault(bindingType) ?? this.PcKeysToBindingTypeMap.GetValueOrDefault(EInputBindingType.Original);
			List<string> list2 = this.GamepadKeysToBindingTypeMap.GetValueOrDefault(bindingType) ?? this.GamepadKeysToBindingTypeMap.GetValueOrDefault(EInputBindingType.Original);
			List<string> list3 = new List<string>();
			if (list != null)
			{
				list3.AddRange(list);
			}
			if (list2 != null)
			{
				list3.AddRange(list2);
			}
			if (list3.Count > 0)
			{
				this.CurrentBindingType = bindingType;
				this.SetKeys(list3, bindingType);
				this.LastBindingType = this.CurrentBindingType;
			}
		}

		// Token: 0x060454CA RID: 283850 RVA: 0x01219B28 File Offset: 0x01217D28
		public void SetKeys(List<string> keys, EInputBindingType bindingType)
		{
			this.KeyNameListToBindingTypeMap[bindingType] = keys;
			if (this.CurrentBindingType == bindingType)
			{
				Singleton<InputSettings>.Instance.SetActionMapping(this.ActionName, keys, this.LastBindingType, bindingType);
				this.KeyNameList = keys;
				this.RefreshKeyList();
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnActionKeyChanged, this.ActionName);
				return;
			}
			Singleton<InputSettings>.Instance.SetActionMappingApplyInputSettings(this.ActionName, keys, bindingType, false, false);
			this.RefreshKeyListByBindingType(bindingType);
		}

		// Token: 0x060454CB RID: 283851 RVA: 0x01219BA4 File Offset: 0x01217DA4
		public void SetKeyboardKeys(IReadOnlyList<string> keyboardKeys, EInputBindingType bindingType)
		{
			List<string> list = new List<string>(keyboardKeys);
			List<string> collection;
			if (this.GamepadKeysToBindingTypeMap.TryGetValue(bindingType, out collection))
			{
				list.AddRange(collection);
			}
			this.SetKeys(list, bindingType);
		}

		// Token: 0x060454CC RID: 283852 RVA: 0x01219BD8 File Offset: 0x01217DD8
		public void SetKeyboardKeysWithoutOriginal(IReadOnlyList<string> keyboardKeys)
		{
			foreach (EInputBindingType einputBindingType in InputBindingDefine.inputBindingTypesArray)
			{
				if (einputBindingType != EInputBindingType.Original)
				{
					this.SetKeyboardKeys(keyboardKeys, einputBindingType);
				}
			}
		}

		// Token: 0x060454CD RID: 283853 RVA: 0x01219C08 File Offset: 0x01217E08
		public void SetGamepadKeys(IReadOnlyList<string> gamepadKeys, EInputBindingType bindingType)
		{
			List<string> list = new List<string>();
			List<string> collection;
			if (this.PcKeysToBindingTypeMap.TryGetValue(bindingType, out collection))
			{
				list.AddRange(collection);
			}
			list.AddRange(gamepadKeys);
			this.SetKeys(list, bindingType);
		}

		// Token: 0x060454CE RID: 283854 RVA: 0x01219C44 File Offset: 0x01217E44
		public void SetGamepadKeysWithoutOriginal(IReadOnlyList<string> gamepadKeys)
		{
			foreach (EInputBindingType einputBindingType in this.PcKeysToBindingTypeMap.Keys)
			{
				if (einputBindingType != EInputBindingType.Original)
				{
					this.SetGamepadKeys(gamepadKeys, einputBindingType);
				}
			}
		}

		// Token: 0x060454CF RID: 283855 RVA: 0x01219CA0 File Offset: 0x01217EA0
		public void RefreshKeysByActionMappings(TArray<FInputActionKeyMapping> actionMappings, EInputBindingType bindingType)
		{
			List<string> orCreateKeyNameList = this.GetOrCreateKeyNameList(bindingType);
			orCreateKeyNameList.Clear();
			for (int i = actionMappings.Num() - 1; i >= 0; i--)
			{
				string item = actionMappings.Get(i).Key.KeyName.ToString();
				orCreateKeyNameList.Add(item);
			}
			if (this.CurrentBindingType == bindingType)
			{
				this.KeyNameList = orCreateKeyNameList;
				this.RefreshKeyList();
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnActionKeyChanged, this.ActionName);
				return;
			}
			this.RefreshKeyListByBindingType(bindingType);
		}

		// Token: 0x060454D0 RID: 283856 RVA: 0x01219D2C File Offset: 0x01217F2C
		public unsafe void AddKeys([Nullable(new byte[]
		{
			0,
			1
		})] Span<string> keys, EInputBindingType bindingType)
		{
			List<string> orCreateKeyNameList = this.GetOrCreateKeyNameList(bindingType);
			Span<string> span = keys;
			for (int i = 0; i < span.Length; i++)
			{
				string text = *span[i];
				if (!keys.Contains(text))
				{
					orCreateKeyNameList.Add(text);
				}
			}
			if (this.CurrentBindingType == bindingType)
			{
				span = keys;
				for (int i = 0; i < span.Length; i++)
				{
					string keyName = *span[i];
					Singleton<InputSettings>.Instance.AddActionMapping(this.ActionName, keyName, bindingType, true);
				}
				this.KeyNameList = orCreateKeyNameList;
				this.RefreshKeyList();
				return;
			}
			this.RefreshKeyListByBindingType(bindingType);
		}

		// Token: 0x060454D1 RID: 283857 RVA: 0x01219DC0 File Offset: 0x01217FC0
		public unsafe void RemoveKeys([Nullable(new byte[]
		{
			0,
			1
		})] Span<string> keys, EInputBindingType bindingType)
		{
			List<string> orCreateKeyNameList = this.GetOrCreateKeyNameList(bindingType);
			Span<string> span = keys;
			for (int i = 0; i < span.Length; i++)
			{
				string item = *span[i];
				orCreateKeyNameList.Remove(item);
			}
			if (this.CurrentBindingType == bindingType)
			{
				span = keys;
				for (int i = 0; i < span.Length; i++)
				{
					string keyName = *span[i];
					Singleton<InputSettings>.Instance.RemoveActionMapping(this.ActionName, keyName, bindingType, true, true);
				}
				this.KeyNameList = orCreateKeyNameList;
				this.RefreshKeyList();
				return;
			}
			this.RefreshKeyListByBindingType(bindingType);
		}

		// Token: 0x060454D2 RID: 283858 RVA: 0x01219E4D File Offset: 0x0121804D
		public void ClearAllKeys()
		{
			this.PcKeys.Clear();
			this.GamepadKeys.Clear();
			this.KeyNameList.Clear();
			Singleton<InputSettings>.Instance.ClearActionMapping(this.ActionName);
		}

		// Token: 0x060454D3 RID: 283859 RVA: 0x01219E80 File Offset: 0x01218080
		public ActionMapping? GetActionMappingConfig()
		{
			return this.Config;
		}

		// Token: 0x060454D4 RID: 283860 RVA: 0x01219E88 File Offset: 0x01218088
		public int GetConfigId()
		{
			return this.ConfigId;
		}

		// Token: 0x060454D5 RID: 283861 RVA: 0x01219E90 File Offset: 0x01218090
		public EActionMappingType GetActionMappingType()
		{
			return this.ActionMappingType;
		}

		// Token: 0x060454D6 RID: 283862 RVA: 0x01219E98 File Offset: 0x01218098
		private void RefreshKeyListByBindingType(EInputBindingType bindingType)
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			List<string> list3;
			if (this.KeyNameListToBindingTypeMap.TryGetValue(bindingType, out list3))
			{
				foreach (string text in list3)
				{
					InputKey key = Singleton<InputSettings>.Instance.GetKey(text);
					if (key != null)
					{
						if (key.IsKeyboardKey || key.IsMouseButton)
						{
							list.Add(text);
						}
						else if (key.IsGamepadKey)
						{
							list2.Add(text);
						}
						else if (key.IsPcPsTouchPadKey)
						{
							list2.Add(text);
						}
					}
				}
			}
			List<string> list4;
			if (list.Count == 0 && !this.PcKeysToBindingTypeMap.ContainsKey(bindingType) && this.PcKeysToBindingTypeMap.TryGetValue(EInputBindingType.Original, out list4))
			{
				list = list4;
			}
			List<string> list5;
			if (list2.Count == 0 && !this.GamepadKeysToBindingTypeMap.ContainsKey(bindingType) && this.GamepadKeysToBindingTypeMap.TryGetValue(EInputBindingType.Original, out list5))
			{
				list2 = list5;
			}
			if (this.CurrentBindingType == bindingType)
			{
				this.PcKeys = list;
				this.GamepadKeys = list2;
			}
			this.PcKeysToBindingTypeMap[bindingType] = list;
			this.GamepadKeysToBindingTypeMap[bindingType] = list2;
		}

		// Token: 0x060454D7 RID: 283863 RVA: 0x01219FD4 File Offset: 0x012181D4
		private void RefreshKeyList()
		{
			this.RefreshKeyListByBindingType(this.CurrentBindingType);
		}

		// Token: 0x060454D8 RID: 283864 RVA: 0x01219FE4 File Offset: 0x012181E4
		public void ConvertSort()
		{
			ActionMapping? actionMappingConfigByActionName = ConfigBase<InputSettingsConfig>.Instance.GetActionMappingConfigByActionName(this.ActionName);
			List<string> configPcKeys = new List<string>();
			if (Singleton<InputSettingsManager>.Instance.CheckUseFrenchKeyboard)
			{
				int francePcKeysLength = actionMappingConfigByActionName.Value.FrancePcKeysLength;
				configPcKeys.EnsureCapacity(francePcKeysLength);
				for (int i = 0; i < francePcKeysLength; i++)
				{
					configPcKeys.Add(actionMappingConfigByActionName.Value.FrancePcKeys(i));
				}
			}
			else
			{
				string[] actionPcKeys = LanguageKeyTransUtils.GetKeyTrans(Singleton<InputSettingsManager>.Instance.CurrentDeviceLang).GetActionPcKeys(actionMappingConfigByActionName.Value);
				configPcKeys.AddRange(actionPcKeys);
			}
			this.KeyNameList.Sort(delegate(string aKeyName, string bKeyName)
			{
				bool flag = Singleton<InputSettings>.Instance.IsKeyboardKey(aKeyName) || Singleton<InputSettings>.Instance.IsMouseButton(aKeyName);
				bool flag2 = Singleton<InputSettings>.Instance.IsKeyboardKey(bKeyName) || Singleton<InputSettings>.Instance.IsMouseButton(bKeyName);
				if (flag != flag2)
				{
					if (!flag)
					{
						return 1;
					}
					return -1;
				}
				else
				{
					if (flag == flag2)
					{
						int num = configPcKeys.IndexOf(aKeyName);
						int num2 = configPcKeys.IndexOf(bKeyName);
						if (num != -1 && num2 != -1)
						{
							if (num >= num2)
							{
								return 1;
							}
							return -1;
						}
					}
					bool flag3 = Singleton<InputSettings>.Instance.IsGamepadKey(aKeyName);
					bool flag4 = Singleton<InputSettings>.Instance.IsGamepadKey(bKeyName);
					if (flag3 == flag4)
					{
						return 0;
					}
					if (!flag3)
					{
						return 1;
					}
					return -1;
				}
			});
			this.SetKeys(this.KeyNameList, this.CurrentBindingType);
		}

		// Token: 0x060454D9 RID: 283865 RVA: 0x0121A0BD File Offset: 0x012182BD
		public Dictionary<EInputBindingType, List<string>> GetKeyNameListToBindingTypeMap()
		{
			return this.KeyNameListToBindingTypeMap;
		}

		// Token: 0x060454DA RID: 283866 RVA: 0x0121A0C5 File Offset: 0x012182C5
		public Dictionary<EInputBindingType, List<string>> GetCopyKeyNameListToBindingTypeMap()
		{
			return new Dictionary<EInputBindingType, List<string>>(this.KeyNameListToBindingTypeMap);
		}

		// Token: 0x060454DB RID: 283867 RVA: 0x0121A0D4 File Offset: 0x012182D4
		private List<string> GetOrCreateKeyNameList(EInputBindingType bindingType)
		{
			List<string> result;
			if (!this.KeyNameListToBindingTypeMap.TryGetValue(bindingType, out result))
			{
				result = (this.KeyNameListToBindingTypeMap[bindingType] = new List<string>());
			}
			return result;
		}

		// Token: 0x04026A9B RID: 158363
		[Nullable(2)]
		private string ActionName;

		// Token: 0x04026A9C RID: 158364
		private int ConfigId;

		// Token: 0x04026A9D RID: 158365
		private ActionMapping? Config;

		// Token: 0x04026A9E RID: 158366
		private EActionMappingType ActionMappingType;

		// Token: 0x04026A9F RID: 158367
		private List<string> PcKeys = new List<string>();

		// Token: 0x04026AA0 RID: 158368
		private List<string> GamepadKeys = new List<string>();

		// Token: 0x04026AA1 RID: 158369
		private List<string> KeyNameList = new List<string>();

		// Token: 0x04026AA2 RID: 158370
		private readonly Dictionary<EKeySettingExclusiveType, int> KeyboardVersionMap = new Dictionary<EKeySettingExclusiveType, int>();

		// Token: 0x04026AA3 RID: 158371
		private readonly Dictionary<EKeySettingExclusiveType, int> GamepadVersionMap = new Dictionary<EKeySettingExclusiveType, int>();

		// Token: 0x04026AA4 RID: 158372
		private readonly Dictionary<EInputBindingType, List<string>> KeyNameListToBindingTypeMap = new Dictionary<EInputBindingType, List<string>>();

		// Token: 0x04026AA5 RID: 158373
		private readonly Dictionary<EInputBindingType, List<string>> PcKeysToBindingTypeMap = new Dictionary<EInputBindingType, List<string>>();

		// Token: 0x04026AA6 RID: 158374
		private readonly Dictionary<EInputBindingType, List<string>> GamepadKeysToBindingTypeMap = new Dictionary<EInputBindingType, List<string>>();

		// Token: 0x04026AA7 RID: 158375
		private EInputBindingType LastBindingType;

		// Token: 0x04026AA8 RID: 158376
		public EInputBindingType CurrentBindingType;
	}
}
