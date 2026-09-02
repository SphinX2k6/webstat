using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.KeySetting;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FEC RID: 28652
	[NullableContext(1)]
	[Nullable(0)]
	public class InputCombinationAxisBinding
	{
		// Token: 0x06045546 RID: 283974 RVA: 0x0121C33C File Offset: 0x0121A53C
		public void Initialize(CombinationAxis config)
		{
			this.ConfigId = config.Id;
			this.AxisName = config.AxisName;
			this.Config = new CombinationAxis?(config);
			this.AxisMappingType = (ECombinationAxisMappingType)this.Config.Value.AxisType;
			this.CurrentBindingType = (EInputBindingType)this.Config.Value.ExclusiveType;
			Dictionary<string, string> orCreateKeyMap = this.GetOrCreateKeyMap((EInputBindingType)this.Config.Value.ExclusiveType);
			Dictionary<string, string> orCreatePcKeyMap = this.GetOrCreatePcKeyMap((EInputBindingType)this.Config.Value.ExclusiveType);
			Dictionary<string, string> orCreateGamepadKeyMap = this.GetOrCreateGamepadKeyMap((EInputBindingType)this.Config.Value.ExclusiveType);
			Dictionary<string, float> orCreateSecondaryKeyScaleMap = this.GetOrCreateSecondaryKeyScaleMap((EInputBindingType)this.Config.Value.ExclusiveType);
			for (int i = 0; i < config.PcKeyMapLength; i++)
			{
				DicStringString? dicStringString = config.PcKeyMap(i);
				orCreatePcKeyMap[dicStringString.Value.Key] = dicStringString.Value.Value;
				orCreateKeyMap[dicStringString.Value.Key] = dicStringString.Value.Value;
			}
			for (int j = 0; j < config.GamepadKeyMapLength; j++)
			{
				DicStringString? dicStringString2 = config.GamepadKeyMap(j);
				orCreateGamepadKeyMap[dicStringString2.Value.Key] = dicStringString2.Value.Value;
				orCreateKeyMap[dicStringString2.Value.Key] = dicStringString2.Value.Value;
			}
			for (int k = 0; k < config.SecondaryKeyScaleMapLength; k++)
			{
				DicStringFloat? dicStringFloat = config.SecondaryKeyScaleMap(k);
				orCreateSecondaryKeyScaleMap[dicStringFloat.Value.Key] = dicStringFloat.Value.Value;
			}
			this.KeyMap = orCreateKeyMap;
			this.SecondaryKeyScaleMap = orCreateSecondaryKeyScaleMap;
			for (int l = 0; l < config.KeyboardVersionMapLength; l++)
			{
				DicIntInt? dicIntInt = config.KeyboardVersionMap(l);
				this.KeyboardVersionMap[(EKeySettingExclusiveType)dicIntInt.Value.Key] = dicIntInt.Value.Value;
			}
			for (int m = 0; m < config.GamepadVersionMapLength; m++)
			{
				DicIntInt? dicIntInt2 = config.GamepadVersionMap(m);
				this.GamepadVersionMap[(EKeySettingExclusiveType)dicIntInt2.Value.Key] = dicIntInt2.Value.Value;
			}
			for (int n = 0; n < config.BlockInputLength; n++)
			{
				this.BlockInputKeySet.Add(config.BlockInput(n));
			}
			this.RefreshKeyMap();
		}

		// Token: 0x06045547 RID: 283975 RVA: 0x0121C608 File Offset: 0x0121A808
		public void Clear()
		{
			this.PcKeyMap.Clear();
			this.GamepadKeyMap.Clear();
			this.KeyMap.Clear();
			this.AxisName = null;
			this.AxisMappingType = ECombinationAxisMappingType.None;
			this.Config = null;
			this.KeyboardVersionMap.Clear();
			this.GamepadVersionMap.Clear();
			this.KeyMapToBindingTypeMap.Clear();
			this.PcKeysMapToBindingTypeMap.Clear();
			this.GamepadKeysMapToBindingTypeMap.Clear();
			this.SecondaryKeyScaleMapToBindingTypeMap.Clear();
			this.BlockInputKeySet.Clear();
		}

		// Token: 0x06045548 RID: 283976 RVA: 0x0121C69D File Offset: 0x0121A89D
		public IReadOnlySet<string> GetBlockInputKeySet()
		{
			return this.BlockInputKeySet;
		}

		// Token: 0x06045549 RID: 283977 RVA: 0x0121C6A8 File Offset: 0x0121A8A8
		private void RefreshKeyMap()
		{
			this.PcKeyMap.Clear();
			this.GamepadKeyMap.Clear();
			foreach (KeyValuePair<string, string> keyValuePair in this.KeyMap)
			{
				string key = keyValuePair.Key;
				string value = keyValuePair.Value;
				InputKey key2 = Singleton<InputSettings>.Instance.GetKey(value);
				if (key2 != null)
				{
					if (key2.IsKeyboardKey || key2.IsMouseButton)
					{
						this.PcKeyMap[key] = value;
					}
					if (key2.IsGamepadKey)
					{
						this.GamepadKeyMap[key] = value;
					}
				}
			}
		}

		// Token: 0x0604554A RID: 283978 RVA: 0x0121C760 File Offset: 0x0121A960
		public void SwitchKeysByBindingType(EInputBindingType bindingType)
		{
			Dictionary<string, string> dictionary = null;
			Dictionary<string, string> dictionary2;
			if (!this.PcKeysMapToBindingTypeMap.TryGetValue(bindingType, out dictionary) && this.PcKeysMapToBindingTypeMap.TryGetValue(EInputBindingType.Original, out dictionary2))
			{
				dictionary = dictionary2;
			}
			Dictionary<string, string> dictionary3 = null;
			Dictionary<string, string> dictionary4;
			if (!this.GamepadKeysMapToBindingTypeMap.TryGetValue(bindingType, out dictionary3) && this.GamepadKeysMapToBindingTypeMap.TryGetValue(EInputBindingType.Original, out dictionary4))
			{
				dictionary3 = dictionary4;
			}
			Dictionary<string, float> dictionary5 = null;
			Dictionary<string, float> dictionary6;
			if (!this.SecondaryKeyScaleMapToBindingTypeMap.TryGetValue(bindingType, out dictionary5) && this.SecondaryKeyScaleMapToBindingTypeMap.TryGetValue(EInputBindingType.Original, out dictionary6))
			{
				dictionary5 = dictionary6;
			}
			Dictionary<string, string> dictionary7 = new Dictionary<string, string>();
			if (dictionary != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in dictionary)
				{
					dictionary7[keyValuePair.Key] = keyValuePair.Value;
				}
			}
			if (dictionary3 != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair2 in dictionary3)
				{
					dictionary7[keyValuePair2.Key] = keyValuePair2.Value;
				}
			}
			if (dictionary5 != null)
			{
				this.SecondaryKeyScaleMapToBindingTypeMap[bindingType] = dictionary5;
			}
			this.CurrentBindingType = bindingType;
			this.KeyMap.Clear();
			this.PcKeyMap.Clear();
			this.GamepadKeyMap.Clear();
			foreach (KeyValuePair<string, string> keyValuePair3 in dictionary7)
			{
				this.AddKey(keyValuePair3.Key, keyValuePair3.Value, bindingType);
			}
		}

		// Token: 0x0604554B RID: 283979 RVA: 0x0121C90C File Offset: 0x0121AB0C
		public void AddKey(string secondaryKeyName, string mainKeyName, EInputBindingType bindingType)
		{
			this.GetOrCreateKeyMap(bindingType)[secondaryKeyName] = mainKeyName;
			if (this.CurrentBindingType == bindingType)
			{
				this.KeyMap[secondaryKeyName] = mainKeyName;
			}
			InputKey key = Singleton<InputSettings>.Instance.GetKey(mainKeyName);
			if (key == null)
			{
				return;
			}
			if (key.IsKeyboardKey || key.IsMouseButton)
			{
				this.GetOrCreatePcKeyMap(bindingType)[secondaryKeyName] = mainKeyName;
				if (this.CurrentBindingType == bindingType)
				{
					this.PcKeyMap[secondaryKeyName] = mainKeyName;
				}
			}
			if (key.IsGamepadKey)
			{
				this.GetOrCreateGamepadKeyMap(bindingType)[secondaryKeyName] = mainKeyName;
				if (this.CurrentBindingType == bindingType)
				{
					this.GamepadKeyMap[secondaryKeyName] = mainKeyName;
				}
			}
		}

		// Token: 0x0604554C RID: 283980 RVA: 0x0121C9B0 File Offset: 0x0121ABB0
		public void RemoveKey(string secondaryKeyName, EInputBindingType bindingType)
		{
			this.GetOrCreateKeyMap(bindingType).Remove(secondaryKeyName);
			this.GetOrCreatePcKeyMap(bindingType).Remove(secondaryKeyName);
			this.GetOrCreateGamepadKeyMap(bindingType).Remove(secondaryKeyName);
			if (this.CurrentBindingType == bindingType)
			{
				this.KeyMap.Remove(secondaryKeyName);
				this.PcKeyMap.Remove(secondaryKeyName);
				this.GamepadKeyMap.Remove(secondaryKeyName);
			}
		}

		// Token: 0x0604554D RID: 283981 RVA: 0x0121CA17 File Offset: 0x0121AC17
		[NullableContext(2)]
		public string GetAxisName()
		{
			return this.AxisName;
		}

		// Token: 0x0604554E RID: 283982 RVA: 0x0121CA1F File Offset: 0x0121AC1F
		public void SetKeyboardVersion(int version, EKeySettingExclusiveType type)
		{
			this.KeyboardVersionMap[type] = version;
		}

		// Token: 0x0604554F RID: 283983 RVA: 0x0121CA30 File Offset: 0x0121AC30
		public int GetKeyboardVersion(EKeySettingExclusiveType type)
		{
			int result;
			if (this.KeyboardVersionMap.TryGetValue(type, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x06045550 RID: 283984 RVA: 0x0121CA50 File Offset: 0x0121AC50
		public void SetGamepadVersion(int version, EKeySettingExclusiveType type)
		{
			this.GamepadVersionMap[type] = version;
		}

		// Token: 0x06045551 RID: 283985 RVA: 0x0121CA60 File Offset: 0x0121AC60
		public int GetGamepadVersion(EKeySettingExclusiveType type)
		{
			int result;
			if (this.GamepadVersionMap.TryGetValue(type, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x06045552 RID: 283986 RVA: 0x0121CA80 File Offset: 0x0121AC80
		[return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public Dictionary<string, IList<InputCombinationAxisKey>> GetCombinationAxisKeyMap()
		{
			return Singleton<InputSettings>.Instance.GetCombinationAxisKeyMap(this.AxisName);
		}

		// Token: 0x06045553 RID: 283987 RVA: 0x0121CA92 File Offset: 0x0121AC92
		public bool HasKeyboardCombinationAxis(EInputBindingType bindingType)
		{
			return this.GetOrCreatePcKeyMap(bindingType).Count > 0;
		}

		// Token: 0x06045554 RID: 283988 RVA: 0x0121CAA3 File Offset: 0x0121ACA3
		public bool HasGamepadCombinationAxis(EInputBindingType bindingType)
		{
			return this.GetOrCreateGamepadKeyMap(bindingType).Count > 0;
		}

		// Token: 0x06045555 RID: 283989 RVA: 0x0121CAB4 File Offset: 0x0121ACB4
		public ECombinationAxisMappingType GetAxisMappingType()
		{
			return this.AxisMappingType;
		}

		// Token: 0x06045556 RID: 283990 RVA: 0x0121CABC File Offset: 0x0121ACBC
		public float? GetSourceAxisValue(string secondaryKeyName)
		{
			Dictionary<string, float> dictionary = null;
			Dictionary<string, float> dictionary2;
			if (!this.SecondaryKeyScaleMapToBindingTypeMap.TryGetValue(this.CurrentBindingType, out dictionary) && this.SecondaryKeyScaleMapToBindingTypeMap.TryGetValue(EInputBindingType.Original, out dictionary2))
			{
				dictionary = dictionary2;
			}
			if (dictionary == null)
			{
				return null;
			}
			float value;
			if (dictionary.TryGetValue(secondaryKeyName, out value))
			{
				return new float?(value);
			}
			return null;
		}

		// Token: 0x06045557 RID: 283991 RVA: 0x0121CB1A File Offset: 0x0121AD1A
		public int GetConfigId()
		{
			return this.ConfigId;
		}

		// Token: 0x06045558 RID: 283992 RVA: 0x0121CB24 File Offset: 0x0121AD24
		public void GetAllPcKeyNameMap(Dictionary<EInputBindingType, Dictionary<string, string>> keyMapRef)
		{
			foreach (KeyValuePair<EInputBindingType, Dictionary<string, string>> keyValuePair in this.PcKeysMapToBindingTypeMap)
			{
				keyMapRef[keyValuePair.Key] = keyValuePair.Value;
			}
		}

		// Token: 0x06045559 RID: 283993 RVA: 0x0121CB84 File Offset: 0x0121AD84
		public void GetPcKeyNameMap(Dictionary<string, string> keyMapRef, EInputBindingType bindingType)
		{
			foreach (KeyValuePair<string, string> keyValuePair in this.GetOrCreatePcKeyMap(bindingType))
			{
				keyMapRef[keyValuePair.Key] = keyValuePair.Value;
			}
		}

		// Token: 0x0604555A RID: 283994 RVA: 0x0121CBE8 File Offset: 0x0121ADE8
		public void GetAllGamepadKeyNameMap(Dictionary<EInputBindingType, Dictionary<string, string>> keyMapRef)
		{
			foreach (KeyValuePair<EInputBindingType, Dictionary<string, string>> keyValuePair in this.GamepadKeysMapToBindingTypeMap)
			{
				keyMapRef[keyValuePair.Key] = keyValuePair.Value;
			}
		}

		// Token: 0x0604555B RID: 283995 RVA: 0x0121CC48 File Offset: 0x0121AE48
		public void GetGamepadKeyNameMap(Dictionary<string, string> keyMapRef, EInputBindingType bindingType)
		{
			foreach (KeyValuePair<string, string> keyValuePair in this.GetOrCreateGamepadKeyMap(bindingType))
			{
				keyMapRef[keyValuePair.Key] = keyValuePair.Value;
			}
		}

		// Token: 0x0604555C RID: 283996 RVA: 0x0121CCAC File Offset: 0x0121AEAC
		public void GetKeyMap(Dictionary<string, string> keyMapRef, EInputBindingType bindingType)
		{
			foreach (KeyValuePair<string, string> keyValuePair in this.GetOrCreateKeyMap(bindingType))
			{
				keyMapRef[keyValuePair.Key] = keyValuePair.Value;
			}
		}

		// Token: 0x0604555D RID: 283997 RVA: 0x0121CD10 File Offset: 0x0121AF10
		public Dictionary<EInputBindingType, Dictionary<string, string>> GetCopyKeyMapToBindingTypeMap()
		{
			Dictionary<EInputBindingType, Dictionary<string, string>> dictionary = new Dictionary<EInputBindingType, Dictionary<string, string>>();
			foreach (KeyValuePair<EInputBindingType, Dictionary<string, string>> keyValuePair in this.KeyMapToBindingTypeMap)
			{
				Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
				foreach (KeyValuePair<string, string> keyValuePair2 in keyValuePair.Value)
				{
					dictionary2[keyValuePair2.Key] = keyValuePair2.Value;
				}
				dictionary[keyValuePair.Key] = dictionary2;
			}
			return dictionary;
		}

		// Token: 0x0604555E RID: 283998 RVA: 0x0121CDCC File Offset: 0x0121AFCC
		public void GetCurrentPlatformKeyNameMap(Dictionary<string, string> keyMapRef)
		{
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				this.GetPcKeyNameMap(keyMapRef, this.CurrentBindingType);
				return;
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.GetGamepadKeyNameMap(keyMapRef, this.CurrentBindingType);
			}
		}

		// Token: 0x0604555F RID: 283999 RVA: 0x0121CE04 File Offset: 0x0121B004
		public bool HasKey(string secondaryKeyName, string mainKeyName, EInputBindingType bindingType)
		{
			string a;
			return this.GetOrCreateKeyMap(bindingType).TryGetValue(secondaryKeyName, out a) && a == mainKeyName;
		}

		// Token: 0x06045560 RID: 284000 RVA: 0x0121CE2C File Offset: 0x0121B02C
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

		// Token: 0x06045561 RID: 284001 RVA: 0x0121CE60 File Offset: 0x0121B060
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

		// Token: 0x06045562 RID: 284002 RVA: 0x0121CE94 File Offset: 0x0121B094
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

		// Token: 0x06045563 RID: 284003 RVA: 0x0121CEC8 File Offset: 0x0121B0C8
		private Dictionary<string, float> GetOrCreateSecondaryKeyScaleMap(EInputBindingType bindingType)
		{
			Dictionary<string, float> dictionary;
			if (!this.SecondaryKeyScaleMapToBindingTypeMap.TryGetValue(bindingType, out dictionary))
			{
				dictionary = new Dictionary<string, float>();
				this.SecondaryKeyScaleMapToBindingTypeMap[bindingType] = dictionary;
			}
			return dictionary;
		}

		// Token: 0x04026AC7 RID: 158407
		private int ConfigId;

		// Token: 0x04026AC8 RID: 158408
		private readonly Dictionary<string, string> PcKeyMap = new Dictionary<string, string>();

		// Token: 0x04026AC9 RID: 158409
		private readonly Dictionary<string, string> GamepadKeyMap = new Dictionary<string, string>();

		// Token: 0x04026ACA RID: 158410
		private Dictionary<string, string> KeyMap = new Dictionary<string, string>();

		// Token: 0x04026ACB RID: 158411
		[Nullable(2)]
		private string AxisName;

		// Token: 0x04026ACC RID: 158412
		private CombinationAxis? Config;

		// Token: 0x04026ACD RID: 158413
		private ECombinationAxisMappingType AxisMappingType;

		// Token: 0x04026ACE RID: 158414
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Dictionary<string, float> SecondaryKeyScaleMap;

		// Token: 0x04026ACF RID: 158415
		private readonly Dictionary<EKeySettingExclusiveType, int> KeyboardVersionMap = new Dictionary<EKeySettingExclusiveType, int>();

		// Token: 0x04026AD0 RID: 158416
		private readonly Dictionary<EKeySettingExclusiveType, int> GamepadVersionMap = new Dictionary<EKeySettingExclusiveType, int>();

		// Token: 0x04026AD1 RID: 158417
		private readonly HashSet<string> BlockInputKeySet = new HashSet<string>();

		// Token: 0x04026AD2 RID: 158418
		private readonly Dictionary<EInputBindingType, Dictionary<string, string>> KeyMapToBindingTypeMap = new Dictionary<EInputBindingType, Dictionary<string, string>>();

		// Token: 0x04026AD3 RID: 158419
		private readonly Dictionary<EInputBindingType, Dictionary<string, string>> PcKeysMapToBindingTypeMap = new Dictionary<EInputBindingType, Dictionary<string, string>>();

		// Token: 0x04026AD4 RID: 158420
		private readonly Dictionary<EInputBindingType, Dictionary<string, string>> GamepadKeysMapToBindingTypeMap = new Dictionary<EInputBindingType, Dictionary<string, string>>();

		// Token: 0x04026AD5 RID: 158421
		private readonly Dictionary<EInputBindingType, Dictionary<string, float>> SecondaryKeyScaleMapToBindingTypeMap = new Dictionary<EInputBindingType, Dictionary<string, float>>();

		// Token: 0x04026AD6 RID: 158422
		public EInputBindingType CurrentBindingType;
	}
}
