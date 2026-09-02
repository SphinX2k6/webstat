using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Module.KeySetting;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FEB RID: 28651
	[NullableContext(1)]
	[Nullable(0)]
	public class InputCombinationActionBinding
	{
		// Token: 0x06045511 RID: 283921 RVA: 0x0121B194 File Offset: 0x01219394
		private void InitBindingTypeDataByCombinationAction(string actionName)
		{
			CombinationAction? combinationActionConfigByActionName = ConfigBase<InputSettingsConfig>.Instance.GetCombinationActionConfigByActionName(actionName);
			if (combinationActionConfigByActionName == null)
			{
				return;
			}
			this.ConfigBindingType = (EInputBindingType)combinationActionConfigByActionName.Value.ExclusiveType;
			this.CurrentBindingType = (EInputBindingType)combinationActionConfigByActionName.Value.ExclusiveType;
			for (int i = 0; i < combinationActionConfigByActionName.Value.BlockInputLength; i++)
			{
				this.BlockInputKeySet.Add(combinationActionConfigByActionName.Value.BlockInput(i));
			}
			if (this.ConfigBindingType == EInputBindingType.Original)
			{
				for (int j = 0; j < InputBindingDefine.inputBindingTypesArray.Length; j++)
				{
					EInputBindingType key = InputBindingDefine.inputBindingTypesArray[j];
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
					Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
					for (int k = 0; k < combinationActionConfigByActionName.Value.PcKeysLength; k++)
					{
						DicStringString? dicStringString = combinationActionConfigByActionName.Value.PcKeys(k);
						string key2 = dicStringString.Value.Key;
						string value = dicStringString.Value.Value;
						dictionary[key2] = value;
						dictionary3[key2] = value;
					}
					this.PcKeysMapToBindingTypeMap[key] = dictionary;
					for (int l = 0; l < combinationActionConfigByActionName.Value.GamepadKeysLength; l++)
					{
						DicStringString? dicStringString2 = combinationActionConfigByActionName.Value.GamepadKeys(l);
						string key3 = dicStringString2.Value.Key;
						string value2 = dicStringString2.Value.Value;
						dictionary2[key3] = value2;
						dictionary3[key3] = value2;
					}
					this.GamepadKeysMapToBindingTypeMap[key] = dictionary2;
					this.KeyMapToBindingTypeMap[key] = dictionary3;
				}
				return;
			}
			Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
			Dictionary<string, string> dictionary5 = new Dictionary<string, string>();
			Dictionary<string, string> dictionary6 = new Dictionary<string, string>();
			for (int m = 0; m < combinationActionConfigByActionName.Value.PcKeysLength; m++)
			{
				DicStringString? dicStringString3 = combinationActionConfigByActionName.Value.PcKeys(m);
				string key4 = dicStringString3.Value.Key;
				string value3 = dicStringString3.Value.Value;
				dictionary4[key4] = value3;
				dictionary6[key4] = value3;
			}
			this.PcKeysMapToBindingTypeMap[this.ConfigBindingType] = dictionary4;
			for (int n = 0; n < combinationActionConfigByActionName.Value.GamepadKeysLength; n++)
			{
				DicStringString? dicStringString4 = combinationActionConfigByActionName.Value.GamepadKeys(n);
				string key5 = dicStringString4.Value.Key;
				string value4 = dicStringString4.Value.Value;
				dictionary5[key5] = value4;
				dictionary6[key5] = value4;
			}
			this.GamepadKeysMapToBindingTypeMap[this.ConfigBindingType] = dictionary5;
			this.KeyMapToBindingTypeMap[this.ConfigBindingType] = dictionary6;
		}

		// Token: 0x06045512 RID: 283922 RVA: 0x0121B480 File Offset: 0x01219680
		private void InitBindingTypeDataByAction(string actionName)
		{
			ActionMapping? actionMappingConfigByActionName = ConfigBase<InputSettingsConfig>.Instance.GetActionMappingConfigByActionName(actionName);
			this.ConfigBindingType = (EInputBindingType)((actionMappingConfigByActionName != null) ? actionMappingConfigByActionName.Value.ExclusiveType : 0);
			this.CurrentBindingType = (EInputBindingType)((actionMappingConfigByActionName != null) ? actionMappingConfigByActionName.Value.ExclusiveType : 0);
			if (this.ConfigBindingType == EInputBindingType.Original)
			{
				for (int i = 0; i < InputBindingDefine.inputBindingTypesArray.Length; i++)
				{
					EInputBindingType key = InputBindingDefine.inputBindingTypesArray[i];
					this.PcKeysMapToBindingTypeMap[key] = new Dictionary<string, string>();
					this.GamepadKeysMapToBindingTypeMap[key] = new Dictionary<string, string>();
					this.KeyMapToBindingTypeMap[key] = new Dictionary<string, string>();
				}
				return;
			}
			this.PcKeysMapToBindingTypeMap[this.ConfigBindingType] = new Dictionary<string, string>();
			this.GamepadKeysMapToBindingTypeMap[this.ConfigBindingType] = new Dictionary<string, string>();
			this.KeyMapToBindingTypeMap[this.ConfigBindingType] = new Dictionary<string, string>();
		}

		// Token: 0x06045513 RID: 283923 RVA: 0x0121B573 File Offset: 0x01219773
		public void Initialize(string actionName, int secondaryKeyValidTime, bool isOriginalCombinationAction)
		{
			this.ActionName = actionName;
			this.SecondaryKeyValidTime = (float)secondaryKeyValidTime;
			if (isOriginalCombinationAction)
			{
				this.InitBindingTypeDataByCombinationAction(actionName);
				return;
			}
			this.InitBindingTypeDataByAction(actionName);
		}

		// Token: 0x06045514 RID: 283924 RVA: 0x0121B596 File Offset: 0x01219796
		public void InitializeBindingType(EInputBindingType bindingType)
		{
			this.CurrentBindingType = bindingType;
		}

		// Token: 0x06045515 RID: 283925 RVA: 0x0121B5A0 File Offset: 0x012197A0
		public void Clear()
		{
			this.PcKeyMap.Clear();
			this.GamepadKeyMap.Clear();
			this.KeyMap.Clear();
			this.ActionName = null;
			this.KeyMapToBindingTypeMap.Clear();
			this.PcKeysMapToBindingTypeMap.Clear();
			this.GamepadKeysMapToBindingTypeMap.Clear();
			this.BlockInputKeySet.Clear();
		}

		// Token: 0x06045516 RID: 283926 RVA: 0x0121B601 File Offset: 0x01219801
		public IReadOnlySet<string> GetBlockInputKeySet()
		{
			return this.BlockInputKeySet;
		}

		// Token: 0x06045517 RID: 283927 RVA: 0x0121B60C File Offset: 0x0121980C
		public void SwitchKeysByBindingType(EInputBindingType bindingType)
		{
			Dictionary<string, string> dictionary = null;
			Dictionary<string, string> dictionary2;
			if (this.PcKeysMapToBindingTypeMap.TryGetValue(bindingType, out dictionary2))
			{
				dictionary = dictionary2;
			}
			Dictionary<string, string> dictionary3;
			if (dictionary == null && this.PcKeysMapToBindingTypeMap.TryGetValue(EInputBindingType.Original, out dictionary3))
			{
				dictionary = dictionary3;
			}
			Dictionary<string, string> dictionary4 = null;
			Dictionary<string, string> dictionary5;
			if (this.GamepadKeysMapToBindingTypeMap.TryGetValue(bindingType, out dictionary5))
			{
				dictionary4 = dictionary5;
			}
			Dictionary<string, string> dictionary6;
			if (dictionary4 == null && this.GamepadKeysMapToBindingTypeMap.TryGetValue(EInputBindingType.Original, out dictionary6))
			{
				dictionary4 = dictionary6;
			}
			Dictionary<string, string> dictionary7 = new Dictionary<string, string>();
			if (dictionary != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in dictionary)
				{
					string key = keyValuePair.Key;
					string value = keyValuePair.Value;
					dictionary7[key] = value;
				}
			}
			if (dictionary4 != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair2 in dictionary4)
				{
					string key2 = keyValuePair2.Key;
					string value2 = keyValuePair2.Value;
					dictionary7[key2] = value2;
				}
			}
			if (dictionary7 != null)
			{
				this.CurrentBindingType = bindingType;
				this.KeyMap.Clear();
				this.PcKeyMap.Clear();
				this.GamepadKeyMap.Clear();
				foreach (KeyValuePair<string, string> keyValuePair3 in dictionary7)
				{
					string key3 = keyValuePair3.Key;
					string value3 = keyValuePair3.Value;
					this.AddKey(key3, value3, bindingType);
				}
			}
		}

		// Token: 0x06045518 RID: 283928 RVA: 0x0121B7AC File Offset: 0x012199AC
		public void AddKey(string mainKeyName, string secondaryKeyName, EInputBindingType bindingType)
		{
			this.GetOrCreateKeyMap(bindingType)[mainKeyName] = secondaryKeyName;
			if (this.CurrentBindingType == bindingType)
			{
				this.KeyMap[mainKeyName] = secondaryKeyName;
			}
			InputKey key = Singleton<InputSettings>.Instance.GetKey(mainKeyName);
			if (key == null)
			{
				return;
			}
			if (key.IsKeyboardKey || key.IsMouseButton)
			{
				this.GetOrCreatePcKeyMap(bindingType)[mainKeyName] = secondaryKeyName;
				if (this.CurrentBindingType == bindingType)
				{
					this.PcKeyMap[mainKeyName] = secondaryKeyName;
				}
			}
			if (key.IsGamepadKey)
			{
				this.GetOrCreateGamepadKeyMap(bindingType)[mainKeyName] = secondaryKeyName;
				if (this.CurrentBindingType == bindingType)
				{
					this.GamepadKeyMap[mainKeyName] = secondaryKeyName;
				}
			}
		}

		// Token: 0x06045519 RID: 283929 RVA: 0x0121B850 File Offset: 0x01219A50
		public void AddKeyEmptyData(EInputBindingType bindingType)
		{
			this.GetOrCreateKeyMap(bindingType).Clear();
			if (this.CurrentBindingType == bindingType)
			{
				this.KeyMap.Clear();
			}
			this.GetOrCreatePcKeyMap(bindingType).Clear();
			if (this.CurrentBindingType == bindingType)
			{
				this.PcKeyMap.Clear();
			}
			this.GetOrCreateGamepadKeyMap(bindingType).Clear();
			if (this.CurrentBindingType == bindingType)
			{
				this.GamepadKeyMap.Clear();
			}
		}

		// Token: 0x0604551A RID: 283930 RVA: 0x0121B8C0 File Offset: 0x01219AC0
		public bool RemoveKey(string mainKeyName, EInputBindingType bindingType)
		{
			Dictionary<string, string> dictionary;
			if (this.KeyMapToBindingTypeMap.TryGetValue(bindingType, out dictionary) && dictionary != null)
			{
				dictionary.Remove(mainKeyName);
			}
			Dictionary<string, string> dictionary2;
			if (this.PcKeysMapToBindingTypeMap.TryGetValue(bindingType, out dictionary2) && dictionary2 != null)
			{
				dictionary2.Remove(mainKeyName);
			}
			Dictionary<string, string> dictionary3;
			if (this.GamepadKeysMapToBindingTypeMap.TryGetValue(bindingType, out dictionary3) && dictionary3 != null)
			{
				dictionary3.Remove(mainKeyName);
			}
			if (this.CurrentBindingType == bindingType)
			{
				this.KeyMap.Remove(mainKeyName);
				this.PcKeyMap.Remove(mainKeyName);
				this.GamepadKeyMap.Remove(mainKeyName);
				return true;
			}
			return false;
		}

		// Token: 0x0604551B RID: 283931 RVA: 0x0121B954 File Offset: 0x01219B54
		public void GetKeyMapByBindingType(Dictionary<string, string> keyMapRef, EInputBindingType bindingType)
		{
			Dictionary<string, string> suitableKeyMap = this.GetSuitableKeyMap(bindingType);
			if (suitableKeyMap == null)
			{
				return;
			}
			foreach (KeyValuePair<string, string> keyValuePair in suitableKeyMap)
			{
				string key = keyValuePair.Key;
				string value = keyValuePair.Value;
				keyMapRef[key] = value;
			}
		}

		// Token: 0x0604551C RID: 283932 RVA: 0x0121B9C4 File Offset: 0x01219BC4
		public bool HasAnyKey()
		{
			foreach (Dictionary<string, string> dictionary in this.KeyMapToBindingTypeMap.Values)
			{
				foreach (KeyValuePair<string, string> keyValuePair in dictionary)
				{
					string key = keyValuePair.Key;
					string value = keyValuePair.Value;
					if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0604551D RID: 283933 RVA: 0x0121BA70 File Offset: 0x01219C70
		public void GetKeyMap(Dictionary<string, string> keyMapRef)
		{
			Dictionary<string, string> suitableKeyMap = this.GetSuitableKeyMap(this.CurrentBindingType);
			if (suitableKeyMap == null)
			{
				return;
			}
			keyMapRef.AddRange(suitableKeyMap);
		}

		// Token: 0x0604551E RID: 283934 RVA: 0x0121BA95 File Offset: 0x01219C95
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public IReadOnlyDictionary<string, string> GetKeyMap()
		{
			return this.GetSuitableKeyMap(this.CurrentBindingType);
		}

		// Token: 0x0604551F RID: 283935 RVA: 0x0121BAA3 File Offset: 0x01219CA3
		public bool IsValid()
		{
			return this.KeyMap != null && this.KeyMap.Count > 0;
		}

		// Token: 0x06045520 RID: 283936 RVA: 0x0121BABD File Offset: 0x01219CBD
		[NullableContext(2)]
		public string GetActionName()
		{
			return this.ActionName;
		}

		// Token: 0x06045521 RID: 283937 RVA: 0x0121BAC5 File Offset: 0x01219CC5
		public void SetKeyboardVersion(int version, EKeySettingExclusiveType type)
		{
			this.KeyboardVersionMap[type] = version;
		}

		// Token: 0x06045522 RID: 283938 RVA: 0x0121BAD4 File Offset: 0x01219CD4
		public void SetKeyboardVersionMap(Dictionary<EKeySettingExclusiveType, int> versionMap)
		{
			foreach (KeyValuePair<EKeySettingExclusiveType, int> keyValuePair in versionMap)
			{
				EKeySettingExclusiveType key = keyValuePair.Key;
				int value = keyValuePair.Value;
				this.KeyboardVersionMap[key] = value;
			}
		}

		// Token: 0x06045523 RID: 283939 RVA: 0x0121BB38 File Offset: 0x01219D38
		public int GetKeyboardVersion(EKeySettingExclusiveType type)
		{
			int result;
			if (this.KeyboardVersionMap.TryGetValue(type, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x06045524 RID: 283940 RVA: 0x0121BB58 File Offset: 0x01219D58
		public void SetGamepadVersion(int version, EKeySettingExclusiveType type)
		{
			this.GamepadVersionMap[type] = version;
		}

		// Token: 0x06045525 RID: 283941 RVA: 0x0121BB68 File Offset: 0x01219D68
		public void SetGamepadVersionMap(Dictionary<EKeySettingExclusiveType, int> versionMap)
		{
			foreach (KeyValuePair<EKeySettingExclusiveType, int> keyValuePair in versionMap)
			{
				EKeySettingExclusiveType key = keyValuePair.Key;
				int value = keyValuePair.Value;
				this.GamepadVersionMap[key] = value;
			}
		}

		// Token: 0x06045526 RID: 283942 RVA: 0x0121BBCC File Offset: 0x01219DCC
		public int GetGamepadVersion(EKeySettingExclusiveType type)
		{
			int result;
			if (this.GamepadVersionMap.TryGetValue(type, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x06045527 RID: 283943 RVA: 0x0121BBEC File Offset: 0x01219DEC
		public bool HasKeyboardCombinationAction(EInputBindingType bindingType)
		{
			Dictionary<string, string> suitablePcKeyMap = this.GetSuitablePcKeyMap(bindingType);
			return suitablePcKeyMap != null && suitablePcKeyMap.Count > 0;
		}

		// Token: 0x06045528 RID: 283944 RVA: 0x0121BC10 File Offset: 0x01219E10
		public bool HasGamepadCombinationActionByBindingType(EInputBindingType bindingType)
		{
			Dictionary<string, string> suitableGamepadKeyMap = this.GetSuitableGamepadKeyMap(bindingType);
			return suitableGamepadKeyMap != null && suitableGamepadKeyMap.Count > 0;
		}

		// Token: 0x06045529 RID: 283945 RVA: 0x0121BC34 File Offset: 0x01219E34
		public bool HasGamepadCombinationAction()
		{
			Dictionary<string, string> suitableGamepadKeyMap = this.GetSuitableGamepadKeyMap(this.CurrentBindingType);
			return suitableGamepadKeyMap != null && suitableGamepadKeyMap.Count > 0;
		}

		// Token: 0x0604552A RID: 283946 RVA: 0x0121BC5C File Offset: 0x01219E5C
		public bool HasCombinationAction(string mainKeyName, string secondaryKeyName)
		{
			return this.HasKey(mainKeyName, secondaryKeyName, this.CurrentBindingType);
		}

		// Token: 0x0604552B RID: 283947 RVA: 0x0121BC6C File Offset: 0x01219E6C
		public float GetSecondaryKeyValidTime()
		{
			return this.SecondaryKeyValidTime;
		}

		// Token: 0x0604552C RID: 283948 RVA: 0x0121BC74 File Offset: 0x01219E74
		public void GetAllPcKeyNameMap(Dictionary<EInputBindingType, Dictionary<string, string>> keyMapRef)
		{
			foreach (KeyValuePair<EInputBindingType, Dictionary<string, string>> keyValuePair in this.PcKeysMapToBindingTypeMap)
			{
				EInputBindingType einputBindingType;
				Dictionary<string, string> dictionary;
				keyValuePair.Deconstruct(out einputBindingType, out dictionary);
				EInputBindingType key = einputBindingType;
				Dictionary<string, string> dictionary2 = dictionary;
				keyMapRef[key] = new Dictionary<string, string>(dictionary2);
			}
		}

		// Token: 0x0604552D RID: 283949 RVA: 0x0121BCE0 File Offset: 0x01219EE0
		public void GetPcKeyNameMap(Dictionary<string, string> keyMapRef, EInputBindingType bindingType)
		{
			Dictionary<string, string> suitablePcKeyMap = this.GetSuitablePcKeyMap(bindingType);
			if (suitablePcKeyMap == null)
			{
				return;
			}
			keyMapRef.AddRange(suitablePcKeyMap);
		}

		// Token: 0x0604552E RID: 283950 RVA: 0x0121BD00 File Offset: 0x01219F00
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public IReadOnlyDictionary<string, string> GetPcKeyNameMap(EInputBindingType bindingType)
		{
			return this.GetSuitablePcKeyMap(bindingType);
		}

		// Token: 0x0604552F RID: 283951 RVA: 0x0121BD0C File Offset: 0x01219F0C
		public void GetPcKeyNameList(List<string> keyListRef, EInputBindingType bindingType)
		{
			Dictionary<string, string> suitablePcKeyMap = this.GetSuitablePcKeyMap(bindingType);
			if (suitablePcKeyMap == null)
			{
				return;
			}
			keyListRef.EnsureCapacity(suitablePcKeyMap.Count * 2);
			foreach (KeyValuePair<string, string> keyValuePair in suitablePcKeyMap)
			{
				string text;
				string text2;
				keyValuePair.Deconstruct(out text, out text2);
				string item = text;
				string item2 = text2;
				keyListRef.Add(item);
				keyListRef.Add(item2);
			}
		}

		// Token: 0x06045530 RID: 283952 RVA: 0x0121BD90 File Offset: 0x01219F90
		public void GetAllGamepadKeyNameMap(Dictionary<EInputBindingType, Dictionary<string, string>> keyMapRef)
		{
			foreach (KeyValuePair<EInputBindingType, Dictionary<string, string>> keyValuePair in this.GamepadKeysMapToBindingTypeMap)
			{
				EInputBindingType einputBindingType;
				Dictionary<string, string> dictionary;
				keyValuePair.Deconstruct(out einputBindingType, out dictionary);
				EInputBindingType key = einputBindingType;
				Dictionary<string, string> dictionary2 = dictionary;
				keyMapRef[key] = new Dictionary<string, string>(dictionary2);
			}
		}

		// Token: 0x06045531 RID: 283953 RVA: 0x0121BDFC File Offset: 0x01219FFC
		public void GetGamepadKeyNameMapByBindingType(Dictionary<string, string> keyMapRef, EInputBindingType bindingType)
		{
			Dictionary<string, string> suitableGamepadKeyMap = this.GetSuitableGamepadKeyMap(bindingType);
			if (suitableGamepadKeyMap == null)
			{
				return;
			}
			keyMapRef.AddRange(suitableGamepadKeyMap);
		}

		// Token: 0x06045532 RID: 283954 RVA: 0x0121BE1C File Offset: 0x0121A01C
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public IReadOnlyDictionary<string, string> GetGamepadKeyNameMapByBindingType(EInputBindingType bindingType)
		{
			return this.GetSuitableGamepadKeyMap(bindingType);
		}

		// Token: 0x06045533 RID: 283955 RVA: 0x0121BE28 File Offset: 0x0121A028
		public void GetGamepadKeyNameMap(Dictionary<string, string> keyMapRef)
		{
			Dictionary<string, string> suitableGamepadKeyMap = this.GetSuitableGamepadKeyMap(this.CurrentBindingType);
			if (suitableGamepadKeyMap == null)
			{
				return;
			}
			keyMapRef.AddRange(suitableGamepadKeyMap);
		}

		// Token: 0x06045534 RID: 283956 RVA: 0x0121BE4D File Offset: 0x0121A04D
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public IReadOnlyDictionary<string, string> GetGamepadKeyNameMap()
		{
			return this.GetSuitableGamepadKeyMap(this.CurrentBindingType);
		}

		// Token: 0x06045535 RID: 283957 RVA: 0x0121BE5C File Offset: 0x0121A05C
		public void GetGamepadKeyNameList(List<string> keyListRef, EInputBindingType bindingType)
		{
			Dictionary<string, string> suitableGamepadKeyMap = this.GetSuitableGamepadKeyMap(bindingType);
			if (suitableGamepadKeyMap == null)
			{
				return;
			}
			keyListRef.EnsureCapacity(suitableGamepadKeyMap.Count * 2);
			foreach (KeyValuePair<string, string> keyValuePair in suitableGamepadKeyMap)
			{
				string key = keyValuePair.Key;
				string value = keyValuePair.Value;
				keyListRef.Add(key);
				keyListRef.Add(value);
			}
		}

		// Token: 0x06045536 RID: 283958 RVA: 0x0121BEE0 File Offset: 0x0121A0E0
		public void GetCurrentPlatformKeyNameMap(Dictionary<string, string> keyMapRef)
		{
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				this.GetPcKeyNameMap(keyMapRef, this.CurrentBindingType);
				return;
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.GetGamepadKeyNameMapByBindingType(keyMapRef, this.CurrentBindingType);
			}
		}

		// Token: 0x06045537 RID: 283959 RVA: 0x0121BF15 File Offset: 0x0121A115
		public void GetCurrentPlatformKeyNameList(List<string> keyListRef)
		{
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				this.GetPcKeyNameList(keyListRef, this.CurrentBindingType);
				return;
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.GetGamepadKeyNameList(keyListRef, this.CurrentBindingType);
			}
		}

		// Token: 0x06045538 RID: 283960 RVA: 0x0121BF4A File Offset: 0x0121A14A
		public void GetCurrentGamepadKeyNameList(List<string> keyListRef)
		{
			this.GetGamepadKeyNameList(keyListRef, this.CurrentBindingType);
		}

		// Token: 0x06045539 RID: 283961 RVA: 0x0121BF5C File Offset: 0x0121A15C
		public bool HasKey(string mainKeyName, string secondaryKeyName, EInputBindingType bindingType)
		{
			Dictionary<string, string> suitableKeyMap = this.GetSuitableKeyMap(bindingType);
			string a;
			return suitableKeyMap != null && suitableKeyMap.TryGetValue(mainKeyName, out a) && a == secondaryKeyName;
		}

		// Token: 0x0604553A RID: 283962 RVA: 0x0121BF8C File Offset: 0x0121A18C
		public bool HasKeyByAll(string mainKeyName, string secondaryKeyName)
		{
			using (Dictionary<EInputBindingType, Dictionary<string, string>>.ValueCollection.Enumerator enumerator = this.KeyMapToBindingTypeMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string a;
					if (enumerator.Current.TryGetValue(mainKeyName, out a) && a == secondaryKeyName)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0604553B RID: 283963 RVA: 0x0121BFF8 File Offset: 0x0121A1F8
		[return: Nullable(2)]
		public string GetSecondaryKeyNameByMainKey(string mainKeyName, EInputBindingType bindingType)
		{
			Dictionary<string, string> suitableKeyMap = this.GetSuitableKeyMap(bindingType);
			if (suitableKeyMap == null)
			{
				return null;
			}
			string result;
			if (suitableKeyMap.TryGetValue(mainKeyName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0604553C RID: 283964 RVA: 0x0121C020 File Offset: 0x0121A220
		public Dictionary<EInputBindingType, Dictionary<string, string>> GetKeyMapToBindingTypeMap()
		{
			return this.KeyMapToBindingTypeMap;
		}

		// Token: 0x0604553D RID: 283965 RVA: 0x0121C028 File Offset: 0x0121A228
		public Dictionary<string, string> GetCopyKeyMap()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			Dictionary<string, string> dictionary2;
			if (this.KeyMapToBindingTypeMap.TryGetValue(this.CurrentBindingType, out dictionary2))
			{
				foreach (KeyValuePair<string, string> keyValuePair in dictionary2)
				{
					string key = keyValuePair.Key;
					string value = keyValuePair.Value;
					dictionary[key] = value;
				}
			}
			return dictionary;
		}

		// Token: 0x0604553E RID: 283966 RVA: 0x0121C0A8 File Offset: 0x0121A2A8
		public Dictionary<EInputBindingType, Dictionary<string, string>> GetCopyKeyMapToBindingTypeMap()
		{
			Dictionary<EInputBindingType, Dictionary<string, string>> dictionary = new Dictionary<EInputBindingType, Dictionary<string, string>>();
			foreach (KeyValuePair<EInputBindingType, Dictionary<string, string>> keyValuePair in this.KeyMapToBindingTypeMap)
			{
				EInputBindingType key = keyValuePair.Key;
				Dictionary<string, string> value = keyValuePair.Value;
				Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
				foreach (KeyValuePair<string, string> keyValuePair2 in value)
				{
					string key2 = keyValuePair2.Key;
					string value2 = keyValuePair2.Value;
					dictionary2[key2] = value2;
				}
				dictionary[key] = dictionary2;
			}
			return dictionary;
		}

		// Token: 0x0604553F RID: 283967 RVA: 0x0121C170 File Offset: 0x0121A370
		private Dictionary<string, string> GetOrCreateKeyMap(EInputBindingType bindingType)
		{
			Dictionary<string, string> dictionary;
			if (!this.KeyMapToBindingTypeMap.TryGetValue(bindingType, out dictionary))
			{
				dictionary = new Dictionary<string, string>();
				this.KeyMapToBindingTypeMap[bindingType] = dictionary;
			}
			return dictionary;
		}

		// Token: 0x06045540 RID: 283968 RVA: 0x0121C1A4 File Offset: 0x0121A3A4
		private Dictionary<string, string> GetOrCreatePcKeyMap(EInputBindingType bindingType)
		{
			Dictionary<string, string> dictionary;
			if (!this.PcKeysMapToBindingTypeMap.TryGetValue(bindingType, out dictionary))
			{
				dictionary = new Dictionary<string, string>();
				this.PcKeysMapToBindingTypeMap[bindingType] = dictionary;
			}
			return dictionary;
		}

		// Token: 0x06045541 RID: 283969 RVA: 0x0121C1D8 File Offset: 0x0121A3D8
		private Dictionary<string, string> GetOrCreateGamepadKeyMap(EInputBindingType bindingType)
		{
			Dictionary<string, string> dictionary;
			if (!this.GamepadKeysMapToBindingTypeMap.TryGetValue(bindingType, out dictionary))
			{
				dictionary = new Dictionary<string, string>();
				this.GamepadKeysMapToBindingTypeMap[bindingType] = dictionary;
			}
			return dictionary;
		}

		// Token: 0x06045542 RID: 283970 RVA: 0x0121C20C File Offset: 0x0121A40C
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<string, string> GetSuitableKeyMap(EInputBindingType bindingType)
		{
			Dictionary<string, string> dictionary = null;
			Dictionary<string, string> dictionary2;
			if (this.KeyMapToBindingTypeMap.TryGetValue(bindingType, out dictionary2))
			{
				dictionary = dictionary2;
			}
			Dictionary<string, string> dictionary3;
			if (dictionary == null && this.ConfigBindingType == EInputBindingType.Original && this.KeyMapToBindingTypeMap.TryGetValue(this.ConfigBindingType, out dictionary3))
			{
				dictionary = dictionary3;
			}
			return dictionary;
		}

		// Token: 0x06045543 RID: 283971 RVA: 0x0121C250 File Offset: 0x0121A450
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<string, string> GetSuitablePcKeyMap(EInputBindingType bindingType)
		{
			Dictionary<string, string> dictionary;
			this.PcKeysMapToBindingTypeMap.TryGetValue(bindingType, out dictionary);
			if (dictionary == null && this.ConfigBindingType == EInputBindingType.Original)
			{
				this.PcKeysMapToBindingTypeMap.TryGetValue(this.ConfigBindingType, out dictionary);
			}
			return dictionary;
		}

		// Token: 0x06045544 RID: 283972 RVA: 0x0121C28C File Offset: 0x0121A48C
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<string, string> GetSuitableGamepadKeyMap(EInputBindingType bindingType)
		{
			Dictionary<string, string> dictionary;
			this.GamepadKeysMapToBindingTypeMap.TryGetValue(bindingType, out dictionary);
			if (dictionary == null && this.ConfigBindingType == EInputBindingType.Original)
			{
				this.GamepadKeysMapToBindingTypeMap.TryGetValue(EInputBindingType.Original, out dictionary);
			}
			return dictionary;
		}

		// Token: 0x04026ABA RID: 158394
		private readonly Dictionary<string, string> PcKeyMap = new Dictionary<string, string>();

		// Token: 0x04026ABB RID: 158395
		private readonly Dictionary<string, string> GamepadKeyMap = new Dictionary<string, string>();

		// Token: 0x04026ABC RID: 158396
		private readonly Dictionary<string, string> KeyMap = new Dictionary<string, string>();

		// Token: 0x04026ABD RID: 158397
		private float SecondaryKeyValidTime;

		// Token: 0x04026ABE RID: 158398
		[Nullable(2)]
		private string ActionName;

		// Token: 0x04026ABF RID: 158399
		private readonly Dictionary<EKeySettingExclusiveType, int> KeyboardVersionMap = new Dictionary<EKeySettingExclusiveType, int>();

		// Token: 0x04026AC0 RID: 158400
		private readonly Dictionary<EKeySettingExclusiveType, int> GamepadVersionMap = new Dictionary<EKeySettingExclusiveType, int>();

		// Token: 0x04026AC1 RID: 158401
		private readonly Dictionary<EInputBindingType, Dictionary<string, string>> KeyMapToBindingTypeMap = new Dictionary<EInputBindingType, Dictionary<string, string>>();

		// Token: 0x04026AC2 RID: 158402
		private readonly Dictionary<EInputBindingType, Dictionary<string, string>> PcKeysMapToBindingTypeMap = new Dictionary<EInputBindingType, Dictionary<string, string>>();

		// Token: 0x04026AC3 RID: 158403
		private readonly Dictionary<EInputBindingType, Dictionary<string, string>> GamepadKeysMapToBindingTypeMap = new Dictionary<EInputBindingType, Dictionary<string, string>>();

		// Token: 0x04026AC4 RID: 158404
		private readonly HashSet<string> BlockInputKeySet = new HashSet<string>();

		// Token: 0x04026AC5 RID: 158405
		public EInputBindingType ConfigBindingType;

		// Token: 0x04026AC6 RID: 158406
		public EInputBindingType CurrentBindingType;
	}
}
