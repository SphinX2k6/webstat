using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.KeySetting;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FE8 RID: 28648
	[NullableContext(1)]
	[Nullable(0)]
	public class InputAxisBinding
	{
		// Token: 0x060454DD RID: 283869 RVA: 0x0121A174 File Offset: 0x01218374
		public void Initialize(AxisMapping config)
		{
			this.AxisName = config.AxisName;
			this.Config = new AxisMapping?(config);
			this.AxisMappingType = (EAxisMappingType)this.Config.Value.AxisType;
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

		// Token: 0x060454DE RID: 283870 RVA: 0x0121A25B File Offset: 0x0121845B
		public void Clear()
		{
			this.AxisName = null;
			this.AxisMappingType = EAxisMappingType.None;
			this.Config = null;
			this.PcKeysToBindingTypeMap.Clear();
			this.GamepadKeysToBindingTypeMap.Clear();
		}

		// Token: 0x060454DF RID: 283871 RVA: 0x0121A28D File Offset: 0x0121848D
		[NullableContext(2)]
		public string GetAxisName()
		{
			return this.AxisName;
		}

		// Token: 0x060454E0 RID: 283872 RVA: 0x0121A295 File Offset: 0x01218495
		public void SetKeyboardVersion(int version, EKeySettingExclusiveType type)
		{
			this.KeyboardVersionMap[type] = version;
		}

		// Token: 0x060454E1 RID: 283873 RVA: 0x0121A2A4 File Offset: 0x012184A4
		public int GetKeyboardVersion(EKeySettingExclusiveType type)
		{
			int result;
			if (this.KeyboardVersionMap.TryGetValue(type, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x060454E2 RID: 283874 RVA: 0x0121A2C4 File Offset: 0x012184C4
		public void SetGamepadVersion(int version, EKeySettingExclusiveType type)
		{
			this.GamepadVersionMap[type] = version;
		}

		// Token: 0x060454E3 RID: 283875 RVA: 0x0121A2D4 File Offset: 0x012184D4
		public int GetGamepadVersion(EKeySettingExclusiveType type)
		{
			int result;
			if (this.GamepadVersionMap.TryGetValue(type, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x060454E4 RID: 283876 RVA: 0x0121A2F4 File Offset: 0x012184F4
		[return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public Dictionary<EInputBindingType, Dictionary<string, InputAxisKey>> GetAllInputAxisKeyMap()
		{
			return Singleton<InputSettings>.Instance.GetInputAxisKeyMapByBindingType(this.AxisName);
		}

		// Token: 0x060454E5 RID: 283877 RVA: 0x0121A306 File Offset: 0x01218506
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, InputAxisKey> GetInputAxisKeyMap(EInputBindingType bindingType)
		{
			return Singleton<InputSettings>.Instance.GetInputAxisKeyMap(this.AxisName, bindingType);
		}

		// Token: 0x060454E6 RID: 283878 RVA: 0x0121A319 File Offset: 0x01218519
		[NullableContext(2)]
		public InputAxisKey GetCurrentPlatformKey()
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

		// Token: 0x060454E7 RID: 283879 RVA: 0x0121A342 File Offset: 0x01218542
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

		// Token: 0x060454E8 RID: 283880 RVA: 0x0121A36B File Offset: 0x0121856B
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

		// Token: 0x060454E9 RID: 283881 RVA: 0x0121A398 File Offset: 0x01218598
		[NullableContext(2)]
		public InputAxisKey GetCurrentPlatformKeyByIndex(int index)
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

		// Token: 0x060454EA RID: 283882 RVA: 0x0121A3C3 File Offset: 0x012185C3
		[NullableContext(2)]
		public InputAxisKey GetPcKeyByIndex(int index)
		{
			if (index >= this.PcKeys.Count)
			{
				return null;
			}
			return Singleton<InputSettings>.Instance.GetInputAxisKey(this.AxisName, this.PcKeys[index], this.CurrentBindingType);
		}

		// Token: 0x060454EB RID: 283883 RVA: 0x0121A3F8 File Offset: 0x012185F8
		[NullableContext(2)]
		public InputAxisKey GetPcKey()
		{
			int num = 0;
			if (num >= this.PcKeys.Count)
			{
				return null;
			}
			string keyName = this.PcKeys[num];
			return Singleton<InputSettings>.Instance.GetInputAxisKey(this.AxisName, keyName, this.CurrentBindingType);
		}

		// Token: 0x060454EC RID: 283884 RVA: 0x0121A43D File Offset: 0x0121863D
		[NullableContext(2)]
		public InputAxisKey GetGamepadKeyByIndex(int index)
		{
			if (index >= this.GamepadKeys.Count)
			{
				return null;
			}
			return Singleton<InputSettings>.Instance.GetInputAxisKey(this.AxisName, this.GamepadKeys[index], this.CurrentBindingType);
		}

		// Token: 0x060454ED RID: 283885 RVA: 0x0121A474 File Offset: 0x01218674
		[NullableContext(2)]
		public InputAxisKey GetGamepadKey()
		{
			int num = 0;
			if (num >= this.GamepadKeys.Count)
			{
				return null;
			}
			string keyName = this.GamepadKeys[num];
			return Singleton<InputSettings>.Instance.GetInputAxisKey(this.AxisName, keyName, this.CurrentBindingType);
		}

		// Token: 0x060454EE RID: 283886 RVA: 0x0121A4BC File Offset: 0x012186BC
		public void GetPcKeyNameList(List<string> keyListRef)
		{
			foreach (string item in this.PcKeys)
			{
				keyListRef.Add(item);
			}
		}

		// Token: 0x060454EF RID: 283887 RVA: 0x0121A510 File Offset: 0x01218710
		public IReadOnlyList<string> GetPcKeyNameList()
		{
			return this.PcKeys;
		}

		// Token: 0x060454F0 RID: 283888 RVA: 0x0121A518 File Offset: 0x01218718
		public void GetPcKeyNameMapByBindingType(Dictionary<string, float> keyMapRef, EInputBindingType bindingType)
		{
			Dictionary<string, float> dictionary = null;
			if (!this.PcKeysToBindingTypeMap.TryGetValue(bindingType, out dictionary))
			{
				dictionary = new Dictionary<string, float>();
			}
			foreach (KeyValuePair<string, float> keyValuePair in dictionary)
			{
				keyMapRef[keyValuePair.Key] = keyValuePair.Value;
			}
		}

		// Token: 0x060454F1 RID: 283889 RVA: 0x0121A58C File Offset: 0x0121878C
		public void GetGamepadKeyNameList(List<string> keyListRef)
		{
			foreach (string item in this.GamepadKeys)
			{
				keyListRef.Add(item);
			}
		}

		// Token: 0x060454F2 RID: 283890 RVA: 0x0121A5E0 File Offset: 0x012187E0
		public IReadOnlyList<string> GetGamepadKeyNameList()
		{
			return this.GamepadKeys;
		}

		// Token: 0x060454F3 RID: 283891 RVA: 0x0121A5E8 File Offset: 0x012187E8
		public void GetGamepadKeyNameMapByBindingType(Dictionary<string, float> keyMapRef, EInputBindingType bindingType)
		{
			Dictionary<string, float> items;
			if (this.GamepadKeysToBindingTypeMap.TryGetValue(bindingType, out items))
			{
				keyMapRef.AddRange(items);
			}
		}

		// Token: 0x060454F4 RID: 283892 RVA: 0x0121A60C File Offset: 0x0121880C
		public void GetAllPcKeyScaleMap(Dictionary<EInputBindingType, Dictionary<string, float>> keyMapRef)
		{
			keyMapRef.AddRange(this.PcKeysToBindingTypeMap);
		}

		// Token: 0x060454F5 RID: 283893 RVA: 0x0121A61A File Offset: 0x0121881A
		public IReadOnlyDictionary<EInputBindingType, Dictionary<string, float>> GetAllPcKeyScaleMap()
		{
			return this.PcKeysToBindingTypeMap;
		}

		// Token: 0x060454F6 RID: 283894 RVA: 0x0121A624 File Offset: 0x01218824
		public Dictionary<string, float> GetPcKeyScaleMap(Dictionary<string, float> keyScaleMapRef, EInputBindingType bindingType)
		{
			Dictionary<string, float> dictionary = null;
			if (!this.PcKeysToBindingTypeMap.TryGetValue(bindingType, out dictionary))
			{
				dictionary = new Dictionary<string, float>();
			}
			foreach (KeyValuePair<string, float> keyValuePair in dictionary)
			{
				keyScaleMapRef[keyValuePair.Key] = keyValuePair.Value;
			}
			return keyScaleMapRef;
		}

		// Token: 0x060454F7 RID: 283895 RVA: 0x0121A698 File Offset: 0x01218898
		public void GetAllGamepadKeyScaleMap(Dictionary<EInputBindingType, Dictionary<string, float>> keyMapRef)
		{
			foreach (KeyValuePair<EInputBindingType, Dictionary<string, float>> keyValuePair in this.GamepadKeysToBindingTypeMap)
			{
				keyMapRef[keyValuePair.Key] = keyValuePair.Value;
			}
		}

		// Token: 0x060454F8 RID: 283896 RVA: 0x0121A6F8 File Offset: 0x012188F8
		public IReadOnlyDictionary<EInputBindingType, Dictionary<string, float>> GetAllGamepadKeyScaleMap()
		{
			return this.GamepadKeysToBindingTypeMap;
		}

		// Token: 0x060454F9 RID: 283897 RVA: 0x0121A700 File Offset: 0x01218900
		public Dictionary<string, float> GetGamepadKeyScaleMap(Dictionary<string, float> keyScaleMapRef, EInputBindingType bindingType)
		{
			Dictionary<string, float> dictionary = null;
			if (!this.GamepadKeysToBindingTypeMap.TryGetValue(bindingType, out dictionary))
			{
				dictionary = new Dictionary<string, float>();
			}
			foreach (KeyValuePair<string, float> keyValuePair in dictionary)
			{
				keyScaleMapRef[keyValuePair.Key] = keyValuePair.Value;
			}
			return keyScaleMapRef;
		}

		// Token: 0x060454FA RID: 283898 RVA: 0x0121A774 File Offset: 0x01218974
		public void GetKeyNameList(List<string> keyListRef)
		{
			foreach (string item in this.KeyNameList)
			{
				keyListRef.Add(item);
			}
		}

		// Token: 0x060454FB RID: 283899 RVA: 0x0121A7C8 File Offset: 0x012189C8
		public void GetKeyNameListByBindingType(List<string> keyListRef, EInputBindingType bindingType)
		{
			Dictionary<string, float> dictionary = null;
			if (!this.KeyNameListToBindingTypeMap.TryGetValue(bindingType, out dictionary))
			{
				dictionary = new Dictionary<string, float>();
			}
			foreach (string item in dictionary.Keys)
			{
				keyListRef.Add(item);
			}
		}

		// Token: 0x060454FC RID: 283900 RVA: 0x0121A834 File Offset: 0x01218A34
		public bool HasKey(string keyName)
		{
			Dictionary<string, InputAxisKey> inputAxisKeyMap = Singleton<InputSettings>.Instance.GetInputAxisKeyMap(this.AxisName, this.CurrentBindingType);
			return inputAxisKeyMap != null && inputAxisKeyMap.ContainsKey(keyName);
		}

		// Token: 0x060454FD RID: 283901 RVA: 0x0121A864 File Offset: 0x01218A64
		public bool HasAnyKey()
		{
			return this.KeyNameList.Count > 0;
		}

		// Token: 0x060454FE RID: 283902 RVA: 0x0121A874 File Offset: 0x01218A74
		public InputAxisKey[] GetKey(float axisValue, EInputBindingType bindingType)
		{
			List<InputAxisKey> list = new List<InputAxisKey>();
			Dictionary<string, InputAxisKey> inputAxisKeyMap = Singleton<InputSettings>.Instance.GetInputAxisKeyMap(this.AxisName, bindingType);
			if (inputAxisKeyMap == null)
			{
				return new InputAxisKey[0];
			}
			foreach (InputAxisKey inputAxisKey in inputAxisKeyMap.Values)
			{
				if (inputAxisKey.Scale == axisValue)
				{
					list.Add(inputAxisKey);
				}
			}
			InputAxisKey[] array = new InputAxisKey[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = list[i];
			}
			return array;
		}

		// Token: 0x060454FF RID: 283903 RVA: 0x0121A924 File Offset: 0x01218B24
		public void SwitchKeysByBindingType(EInputBindingType bindingType)
		{
			Dictionary<string, float> dictionary = null;
			if (!this.PcKeysToBindingTypeMap.TryGetValue(bindingType, out dictionary))
			{
				this.PcKeysToBindingTypeMap.TryGetValue(EInputBindingType.Original, out dictionary);
			}
			Dictionary<string, float> dictionary2 = null;
			if (!this.GamepadKeysToBindingTypeMap.TryGetValue(bindingType, out dictionary2))
			{
				this.GamepadKeysToBindingTypeMap.TryGetValue(EInputBindingType.Original, out dictionary2);
			}
			Dictionary<string, float> dictionary3 = new Dictionary<string, float>();
			if (dictionary != null)
			{
				foreach (KeyValuePair<string, float> keyValuePair in dictionary)
				{
					dictionary3[keyValuePair.Key] = keyValuePair.Value;
				}
			}
			if (dictionary2 != null)
			{
				foreach (KeyValuePair<string, float> keyValuePair2 in dictionary2)
				{
					dictionary3[keyValuePair2.Key] = keyValuePair2.Value;
				}
			}
			if (dictionary3.Count > 0)
			{
				this.CurrentBindingType = bindingType;
				this.SetKeys(dictionary3, bindingType);
				this.LastBindingType = this.CurrentBindingType;
			}
		}

		// Token: 0x06045500 RID: 283904 RVA: 0x0121AA40 File Offset: 0x01218C40
		public void SetKeys(Dictionary<string, float> keyScaleMap, EInputBindingType bindingType)
		{
			this.KeyNameListToBindingTypeMap[bindingType] = keyScaleMap;
			if (this.CurrentBindingType == bindingType)
			{
				Singleton<InputSettings>.Instance.SetAxisMapping(this.AxisName, keyScaleMap, this.LastBindingType, bindingType);
				List<string> list = new List<string>();
				foreach (string item in keyScaleMap.Keys)
				{
					list.Add(item);
				}
				this.KeyNameList = list;
				this.RefreshKeyList();
				return;
			}
			Singleton<InputSettings>.Instance.SetAxisMappingWithoutInputSettings(this.AxisName, keyScaleMap, bindingType);
			this.RefreshKeyListByBindingType(bindingType);
		}

		// Token: 0x06045501 RID: 283905 RVA: 0x0121AAF0 File Offset: 0x01218CF0
		public void SetAllKeys(Dictionary<string, float> keyScaleMap)
		{
			foreach (EInputBindingType bindingType in this.KeyNameListToBindingTypeMap.Keys)
			{
				this.SetKeys(keyScaleMap, bindingType);
			}
		}

		// Token: 0x06045502 RID: 283906 RVA: 0x0121AB4C File Offset: 0x01218D4C
		public void SetKeyboardKeys(Dictionary<string, float> keyboardScaleMap, EInputBindingType bindingType)
		{
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			foreach (KeyValuePair<string, float> keyValuePair in keyboardScaleMap)
			{
				dictionary[keyValuePair.Key] = keyValuePair.Value;
			}
			this.GetGamepadKeyScaleMap(dictionary, bindingType);
			this.SetKeys(dictionary, bindingType);
		}

		// Token: 0x06045503 RID: 283907 RVA: 0x0121ABC0 File Offset: 0x01218DC0
		public void SetKeyboardKeysWithoutOriginal(Dictionary<string, float> keyboardScaleMap)
		{
			for (int i = 0; i < InputBindingDefine.inputBindingTypesArray.Length; i++)
			{
				EInputBindingType einputBindingType = InputBindingDefine.inputBindingTypesArray[i];
				if (einputBindingType != EInputBindingType.Original)
				{
					this.SetKeyboardKeys(keyboardScaleMap, einputBindingType);
				}
			}
		}

		// Token: 0x06045504 RID: 283908 RVA: 0x0121ABF4 File Offset: 0x01218DF4
		public void SetGamepadKeys(Dictionary<string, float> gamepadScaleMap, EInputBindingType bindingType)
		{
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			foreach (KeyValuePair<string, float> keyValuePair in gamepadScaleMap)
			{
				dictionary[keyValuePair.Key] = keyValuePair.Value;
			}
			this.GetPcKeyScaleMap(dictionary, bindingType);
			this.SetKeys(dictionary, bindingType);
		}

		// Token: 0x06045505 RID: 283909 RVA: 0x0121AC68 File Offset: 0x01218E68
		public void SetGamepadKeysWithoutOriginal(Dictionary<string, float> gamepadScaleMap)
		{
			foreach (EInputBindingType einputBindingType in this.PcKeysToBindingTypeMap.Keys)
			{
				if (einputBindingType != EInputBindingType.Original)
				{
					this.SetGamepadKeys(gamepadScaleMap, einputBindingType);
				}
			}
		}

		// Token: 0x06045506 RID: 283910 RVA: 0x0121ACC4 File Offset: 0x01218EC4
		public void RefreshKeys(TArray<FInputAxisKeyMapping> axisMappings, EInputBindingType bindingType)
		{
			Dictionary<string, float> orCreateKeyNameMap = this.GetOrCreateKeyNameMap(bindingType);
			orCreateKeyNameMap.Clear();
			for (int i = axisMappings.Num() - 1; i >= 0; i--)
			{
				FInputAxisKeyMapping finputAxisKeyMapping = axisMappings.Get(i);
				string key = finputAxisKeyMapping.Key.KeyName.ToString();
				orCreateKeyNameMap[key] = finputAxisKeyMapping.Scale;
			}
			if (this.CurrentBindingType == bindingType)
			{
				List<string> list = new List<string>();
				foreach (string item in orCreateKeyNameMap.Keys)
				{
					list.Add(item);
				}
				this.KeyNameList = list;
				this.RefreshKeyList();
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnAxisKeyChanged, this.AxisName);
				return;
			}
			this.RefreshKeyListByBindingType(bindingType);
		}

		// Token: 0x06045507 RID: 283911 RVA: 0x0121ADA8 File Offset: 0x01218FA8
		public void ClearAllKeys()
		{
			if (this.PcKeys != null)
			{
				this.PcKeys.Clear();
			}
			if (this.GamepadKeys != null)
			{
				this.GamepadKeys.Clear();
			}
			if (this.KeyNameList != null)
			{
				this.KeyNameList.Clear();
			}
			Singleton<InputSettings>.Instance.ClearAxisMapping(this.AxisName);
		}

		// Token: 0x06045508 RID: 283912 RVA: 0x0121ADFE File Offset: 0x01218FFE
		public AxisMapping? GetAxisMappingConfig()
		{
			return this.Config;
		}

		// Token: 0x06045509 RID: 283913 RVA: 0x0121AE06 File Offset: 0x01219006
		public EAxisMappingType GetAxisMappingType()
		{
			return this.AxisMappingType;
		}

		// Token: 0x0604550A RID: 283914 RVA: 0x0121AE0E File Offset: 0x0121900E
		public Dictionary<EInputBindingType, Dictionary<string, float>> GetKeyNameListToBindingTypeMap()
		{
			return this.KeyNameListToBindingTypeMap;
		}

		// Token: 0x0604550B RID: 283915 RVA: 0x0121AE18 File Offset: 0x01219018
		public Dictionary<EInputBindingType, Dictionary<string, float>> GetCopyKeyNameListToBindingTypeMap()
		{
			Dictionary<EInputBindingType, Dictionary<string, float>> dictionary = new Dictionary<EInputBindingType, Dictionary<string, float>>();
			foreach (KeyValuePair<EInputBindingType, Dictionary<string, float>> keyValuePair in this.KeyNameListToBindingTypeMap)
			{
				Dictionary<string, float> dictionary2 = new Dictionary<string, float>();
				foreach (KeyValuePair<string, float> keyValuePair2 in keyValuePair.Value)
				{
					dictionary2[keyValuePair2.Key] = keyValuePair2.Value;
				}
				dictionary[keyValuePair.Key] = dictionary2;
			}
			return dictionary;
		}

		// Token: 0x0604550C RID: 283916 RVA: 0x0121AED4 File Offset: 0x012190D4
		private void RefreshKeyListByBindingType(EInputBindingType bindingType)
		{
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			Dictionary<string, float> dictionary2 = new Dictionary<string, float>();
			Dictionary<string, float> dictionary3 = null;
			if (!this.KeyNameListToBindingTypeMap.TryGetValue(bindingType, out dictionary3))
			{
				return;
			}
			foreach (KeyValuePair<string, float> keyValuePair in dictionary3)
			{
				string key = keyValuePair.Key;
				float value = keyValuePair.Value;
				InputKey key2 = Singleton<InputSettings>.Instance.GetKey(key);
				if (key2 != null)
				{
					if (key2.IsKeyboardKey || key2.IsMouseButton)
					{
						dictionary[key] = value;
					}
					else if (key2.IsGamepadKey)
					{
						dictionary2[key] = value;
					}
					else if (key2.IsPcPsTouchPadKey)
					{
						dictionary2[key] = value;
					}
				}
			}
			Dictionary<string, float> dictionary4;
			if (!this.PcKeysToBindingTypeMap.ContainsKey(bindingType) && dictionary.Count == 0 && this.PcKeysToBindingTypeMap.TryGetValue(EInputBindingType.Original, out dictionary4))
			{
				dictionary = new Dictionary<string, float>(dictionary4);
			}
			Dictionary<string, float> dictionary5;
			if (!this.GamepadKeysToBindingTypeMap.ContainsKey(bindingType) && dictionary2.Count == 0 && this.GamepadKeysToBindingTypeMap.TryGetValue(EInputBindingType.Original, out dictionary5))
			{
				dictionary2 = new Dictionary<string, float>(dictionary5);
			}
			if (this.CurrentBindingType == bindingType)
			{
				this.PcKeys.Clear();
				foreach (string item in dictionary.Keys)
				{
					this.PcKeys.Add(item);
				}
				this.GamepadKeys.Clear();
				foreach (string item2 in dictionary2.Keys)
				{
					this.GamepadKeys.Add(item2);
				}
			}
			this.PcKeysToBindingTypeMap[bindingType] = dictionary;
			this.GamepadKeysToBindingTypeMap[bindingType] = dictionary2;
		}

		// Token: 0x0604550D RID: 283917 RVA: 0x0121B0D4 File Offset: 0x012192D4
		private void RefreshKeyList()
		{
			this.RefreshKeyListByBindingType(this.CurrentBindingType);
		}

		// Token: 0x0604550E RID: 283918 RVA: 0x0121B0E4 File Offset: 0x012192E4
		private Dictionary<string, float> GetOrCreateKeyNameMap(EInputBindingType bindingType)
		{
			Dictionary<string, float> dictionary;
			if (!this.KeyNameListToBindingTypeMap.TryGetValue(bindingType, out dictionary))
			{
				dictionary = new Dictionary<string, float>();
				this.KeyNameListToBindingTypeMap[bindingType] = dictionary;
			}
			return dictionary;
		}

		// Token: 0x04026AA9 RID: 158377
		[Nullable(2)]
		private string AxisName;

		// Token: 0x04026AAA RID: 158378
		private AxisMapping? Config;

		// Token: 0x04026AAB RID: 158379
		private EAxisMappingType AxisMappingType;

		// Token: 0x04026AAC RID: 158380
		private readonly List<string> PcKeys = new List<string>();

		// Token: 0x04026AAD RID: 158381
		private readonly List<string> GamepadKeys = new List<string>();

		// Token: 0x04026AAE RID: 158382
		private List<string> KeyNameList = new List<string>();

		// Token: 0x04026AAF RID: 158383
		private readonly Dictionary<EKeySettingExclusiveType, int> KeyboardVersionMap = new Dictionary<EKeySettingExclusiveType, int>();

		// Token: 0x04026AB0 RID: 158384
		private readonly Dictionary<EKeySettingExclusiveType, int> GamepadVersionMap = new Dictionary<EKeySettingExclusiveType, int>();

		// Token: 0x04026AB1 RID: 158385
		private readonly Dictionary<EInputBindingType, Dictionary<string, float>> KeyNameListToBindingTypeMap = new Dictionary<EInputBindingType, Dictionary<string, float>>();

		// Token: 0x04026AB2 RID: 158386
		private readonly Dictionary<EInputBindingType, Dictionary<string, float>> PcKeysToBindingTypeMap = new Dictionary<EInputBindingType, Dictionary<string, float>>();

		// Token: 0x04026AB3 RID: 158387
		private readonly Dictionary<EInputBindingType, Dictionary<string, float>> GamepadKeysToBindingTypeMap = new Dictionary<EInputBindingType, Dictionary<string, float>>();

		// Token: 0x04026AB4 RID: 158388
		private EInputBindingType LastBindingType;

		// Token: 0x04026AB5 RID: 158389
		private EInputBindingType CurrentBindingType;
	}
}
