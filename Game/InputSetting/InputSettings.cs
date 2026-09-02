using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FF0 RID: 28656
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InputSettings : Singleton<InputSettings>
	{
		// Token: 0x06045576 RID: 284022 RVA: 0x0121D378 File Offset: 0x0121B578
		private InputActionKey PopInputActionKey(string actionName, bool bShift, bool bCtrl, bool bAlt, bool bCmd, string keyName)
		{
			InputActionKey inputActionKey = null;
			if (this.InputActionKeyPool.Count > 0)
			{
				int index = this.InputActionKeyPool.Count - 1;
				inputActionKey = this.InputActionKeyPool[index];
				this.InputActionKeyPool.RemoveAt(index);
			}
			if (inputActionKey != null)
			{
				InputActionKey.Refresh(inputActionKey, actionName, bShift, bCtrl, bAlt, bCmd, keyName);
			}
			else
			{
				inputActionKey = InputActionKey.New(actionName, bShift, bCtrl, bAlt, bCmd, keyName);
			}
			return inputActionKey;
		}

		// Token: 0x06045577 RID: 284023 RVA: 0x0121D3E0 File Offset: 0x0121B5E0
		private void RecycleInputActionKey(InputActionKey inputActionKey)
		{
			this.InputActionKeyPool.Add(inputActionKey);
		}

		// Token: 0x06045578 RID: 284024 RVA: 0x0121D3F0 File Offset: 0x0121B5F0
		private InputAxisKey PopInputAxisKey(string axisName, float scale, string keyName)
		{
			InputAxisKey inputAxisKey = null;
			if (this.InputAxisKeyPool.Count > 0)
			{
				int index = this.InputAxisKeyPool.Count - 1;
				inputAxisKey = this.InputAxisKeyPool[index];
				this.InputAxisKeyPool.RemoveAt(index);
			}
			if (inputAxisKey != null)
			{
				InputAxisKey.Refresh(inputAxisKey, axisName, scale, keyName);
			}
			else
			{
				inputAxisKey = InputAxisKey.New(axisName, scale, keyName);
			}
			return inputAxisKey;
		}

		// Token: 0x06045579 RID: 284025 RVA: 0x0121D44C File Offset: 0x0121B64C
		private void RecycleInputAxisKey(InputAxisKey inputAxisKey)
		{
			this.InputAxisKeyPool.Add(inputAxisKey);
		}

		// Token: 0x0604557A RID: 284026 RVA: 0x0121D45A File Offset: 0x0121B65A
		public void Initialize()
		{
			LanguageKeyTransUtils.Initialize();
			this.InputSettingsInstance = UInputSettings.GetInputSettings();
			this.Refresh();
		}

		// Token: 0x0604557B RID: 284027 RVA: 0x0121D472 File Offset: 0x0121B672
		public void Clear()
		{
			this.InputSettingsInstance = null;
			this.InputActionKeyMappings.Clear();
			this.InputAxisKeyMappings.Clear();
			this.InputCombinationActionKeyMappings.Clear();
			this.InputCombinationAxisKeyMappings.Clear();
			this.ClearKey();
		}

		// Token: 0x0604557C RID: 284028 RVA: 0x0121D4AD File Offset: 0x0121B6AD
		public void Refresh()
		{
			this.RefreshActionKeyMappings();
			this.RefreshAxisKeyMappings();
			this.RefreshCombinationAxis();
		}

		// Token: 0x0604557D RID: 284029 RVA: 0x0121D4C4 File Offset: 0x0121B6C4
		private void RefreshActionKeyMappings()
		{
			TArray<FName> actionNames = this.GetActionNames();
			for (int i = 0; i < actionNames.Num(); i++)
			{
				FName inActionName = actionNames.Get(i);
				TArray<FInputActionKeyMapping> tarray = new TArray<FInputActionKeyMapping>();
				this.InputSettingsInstance.GetActionMappingByName(inActionName, ref tarray);
				TArray<FInputActionKeyMapping> tarray2 = tarray;
				string text = inActionName.ToString();
				if (Singleton<Info>.Instance.IsPlayInEditor && ConfigBase<InputSettingsConfig>.Instance.GetActionMappingConfigByActionName(text) == null)
				{
					this.InputSettingsInstance.RemoveActionMappings(tarray2, true);
				}
				else
				{
					Dictionary<EInputBindingType, Dictionary<string, InputActionKey>> dictionary;
					if (!this.InputActionKeyMappings.TryGetValue(text, out dictionary) || dictionary == null)
					{
						dictionary = new Dictionary<EInputBindingType, Dictionary<string, InputActionKey>>();
						this.InputActionKeyMappings[text] = dictionary;
					}
					for (int j = 0; j < tarray2.Num(); j++)
					{
						FInputActionKeyMapping finputActionKeyMapping = tarray2.Get(j);
						string text2 = finputActionKeyMapping.Key.KeyName.ToString();
						this.TryAddKey(text2);
						foreach (EInputBindingType key in InputBindingDefine.inputBindingTypesArray)
						{
							Dictionary<string, InputActionKey> dictionary2;
							if (!dictionary.TryGetValue(key, out dictionary2) || dictionary2 == null)
							{
								dictionary2 = new Dictionary<string, InputActionKey>();
								dictionary[key] = dictionary2;
							}
							InputActionKey inputActionKey;
							dictionary2.TryGetValue(text2, out inputActionKey);
							if (inputActionKey == null || !inputActionKey.IsEqual(finputActionKeyMapping))
							{
								InputActionKey inputActionKey2 = InputActionKey.NewByInputActionKeyMapping(finputActionKeyMapping);
								if (inputActionKey2 != null)
								{
									dictionary2[text2] = inputActionKey2;
								}
							}
						}
					}
					tarray2.Empty(true);
				}
			}
		}

		// Token: 0x0604557E RID: 284030 RVA: 0x0121D64C File Offset: 0x0121B84C
		private void RefreshAxisKeyMappings()
		{
			TArray<FName> axisNames = this.GetAxisNames();
			for (int i = 0; i < axisNames.Num(); i++)
			{
				FName inAxisName = axisNames.Get(i);
				TArray<FInputAxisKeyMapping> tarray = new TArray<FInputAxisKeyMapping>();
				this.InputSettingsInstance.GetAxisMappingByName(inAxisName, ref tarray);
				TArray<FInputAxisKeyMapping> tarray2 = tarray;
				string text = inAxisName.ToString();
				if (Singleton<Info>.Instance.IsPlayInEditor && ConfigBase<InputSettingsConfig>.Instance.GetAxisMappingConfigByAxisName(text) == null)
				{
					this.InputSettingsInstance.RemoveAxisMappings(tarray2, true);
				}
				else
				{
					Dictionary<EInputBindingType, Dictionary<string, InputAxisKey>> dictionary;
					if (!this.InputAxisKeyMappings.TryGetValue(text, out dictionary) || dictionary == null)
					{
						dictionary = new Dictionary<EInputBindingType, Dictionary<string, InputAxisKey>>();
						this.InputAxisKeyMappings[text] = dictionary;
					}
					for (int j = 0; j < tarray2.Num(); j++)
					{
						FInputAxisKeyMapping finputAxisKeyMapping = tarray2.Get(j);
						string text2 = finputAxisKeyMapping.Key.KeyName.ToString();
						this.TryAddKey(text2);
						foreach (EInputBindingType key in InputBindingDefine.inputBindingTypesArray)
						{
							Dictionary<string, InputAxisKey> dictionary2;
							if (!dictionary.TryGetValue(key, out dictionary2) || dictionary2 == null)
							{
								dictionary2 = new Dictionary<string, InputAxisKey>();
								dictionary[key] = dictionary2;
							}
							InputAxisKey inputAxisKey;
							dictionary2.TryGetValue(text2, out inputAxisKey);
							if (inputAxisKey == null || !inputAxisKey.IsEqual(finputAxisKeyMapping))
							{
								InputAxisKey value = InputAxisKey.NewByInputAxisKeyMapping(finputAxisKeyMapping);
								dictionary2[text2] = value;
							}
						}
					}
					tarray2.Empty(true);
				}
			}
		}

		// Token: 0x0604557F RID: 284031 RVA: 0x0121D7D0 File Offset: 0x0121B9D0
		public void RemoveCombinationActionMapping(string actionName, string mainKeyName, string secondaryKeyName)
		{
			Dictionary<string, List<InputCombinationActionKey>> dictionary;
			if (!this.InputCombinationActionKeyMappings.TryGetValue(actionName, out dictionary) || dictionary == null)
			{
				return;
			}
			List<InputCombinationActionKey> list;
			if (!dictionary.TryGetValue(mainKeyName, out list) || list == null)
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < list.Count; i++)
			{
				InputKey secondaryKey = list[i].GetSecondaryKey();
				if (((secondaryKey != null) ? secondaryKey.GetKeyName() : null) == secondaryKeyName)
				{
					num = i;
					break;
				}
			}
			if (num >= 0)
			{
				list.RemoveAt(num);
			}
			if (list.Count <= 0)
			{
				dictionary.Remove(mainKeyName);
			}
		}

		// Token: 0x06045580 RID: 284032 RVA: 0x0121D854 File Offset: 0x0121BA54
		public void NewInputCombinationActionKey(string actionName, string mainKeyName, string secondaryKeyName)
		{
			this.TryAddKey(mainKeyName);
			this.TryAddKey(secondaryKeyName);
			InputCombinationActionKey item = InputCombinationActionKey.New(actionName, mainKeyName, secondaryKeyName);
			Dictionary<string, List<InputCombinationActionKey>> dictionary;
			if (!this.InputCombinationActionKeyMappings.TryGetValue(actionName, out dictionary) || dictionary == null)
			{
				Dictionary<string, List<InputCombinationActionKey>> dictionary2 = new Dictionary<string, List<InputCombinationActionKey>>();
				dictionary2[mainKeyName] = new List<InputCombinationActionKey>
				{
					item
				};
				this.InputCombinationActionKeyMappings[actionName] = dictionary2;
				return;
			}
			List<InputCombinationActionKey> list;
			if (dictionary.TryGetValue(mainKeyName, out list) && list != null)
			{
				list.Add(item);
				return;
			}
			dictionary[mainKeyName] = new List<InputCombinationActionKey>
			{
				item
			};
		}

		// Token: 0x06045581 RID: 284033 RVA: 0x0121D8DC File Offset: 0x0121BADC
		private void RefreshCombinationAxis()
		{
			this.InputCombinationAxisKeyMappings.Clear();
			IReadOnlyList<CombinationAxis> allCombinationAxisConfig = ConfigBase<InputSettingsConfig>.Instance.GetAllCombinationAxisConfig();
			if (allCombinationAxisConfig == null)
			{
				return;
			}
			foreach (CombinationAxis combinationAxis in allCombinationAxisConfig)
			{
				string axisName = combinationAxis.AxisName;
				for (int i = 0; i < combinationAxis.PcKeyMapLength; i++)
				{
					DicStringString? dicStringString = combinationAxis.PcKeyMap(i);
					string key = dicStringString.Value.Key;
					string value = dicStringString.Value.Value;
					this.NewCombinationAxisKey(axisName, value, key, combinationAxis.GetSecondaryKeyScaleMap(key).GetValueOrDefault());
				}
				for (int j = 0; j < combinationAxis.GamepadKeyMapLength; j++)
				{
					DicStringString? dicStringString2 = combinationAxis.GamepadKeyMap(j);
					string key2 = dicStringString2.Value.Key;
					string value2 = dicStringString2.Value.Value;
					this.NewCombinationAxisKey(axisName, value2, key2, combinationAxis.GetSecondaryKeyScaleMap(key2).GetValueOrDefault());
				}
			}
		}

		// Token: 0x06045582 RID: 284034 RVA: 0x0121DA0C File Offset: 0x0121BC0C
		[Conditional("DEBUG")]
		public void RefreshDebugKey()
		{
		}

		// Token: 0x06045583 RID: 284035 RVA: 0x0121DA10 File Offset: 0x0121BC10
		public void RemoveCombinationAxisMapping(string axisName, string mainKeyName, string secondaryKeyName)
		{
			Dictionary<string, IList<InputCombinationAxisKey>> dictionary;
			if (!this.InputCombinationAxisKeyMappings.TryGetValue(axisName, out dictionary) || dictionary == null)
			{
				return;
			}
			IList<InputCombinationAxisKey> list;
			if (!dictionary.TryGetValue(mainKeyName, out list) || list == null)
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < list.Count; i++)
			{
				InputKey secondaryKey = list[i].GetSecondaryKey();
				if (((secondaryKey != null) ? secondaryKey.GetKeyName() : null) == secondaryKeyName)
				{
					num = i;
					break;
				}
			}
			if (num >= 0)
			{
				list.RemoveAt(num);
			}
			if (list.Count <= 0)
			{
				dictionary.Remove(mainKeyName);
			}
		}

		// Token: 0x06045584 RID: 284036 RVA: 0x0121DA94 File Offset: 0x0121BC94
		private void NewCombinationAxisKey(string axisName, string mainKeyName, string secondaryKeyName, float scale)
		{
			this.TryAddKey(mainKeyName);
			this.TryAddKey(secondaryKeyName);
			Dictionary<string, IList<InputCombinationAxisKey>> dictionary;
			if (!this.InputCombinationAxisKeyMappings.TryGetValue(axisName, out dictionary) || dictionary == null)
			{
				dictionary = new Dictionary<string, IList<InputCombinationAxisKey>>();
				this.InputCombinationAxisKeyMappings[axisName] = dictionary;
			}
			IList<InputCombinationAxisKey> list;
			if (!dictionary.TryGetValue(mainKeyName, out list) || list == null)
			{
				list = new List<InputCombinationAxisKey>();
				dictionary[mainKeyName] = list;
			}
			InputCombinationAxisKey item = InputCombinationAxisKey.New(axisName, mainKeyName, secondaryKeyName, scale);
			list.Add(item);
		}

		// Token: 0x06045585 RID: 284037 RVA: 0x0121DB03 File Offset: 0x0121BD03
		public void SaveKeyMappings()
		{
			UInputSettings inputSettingsInstance = this.InputSettingsInstance;
			if (inputSettingsInstance == null)
			{
				return;
			}
			inputSettingsInstance.SaveKeyMappingsNotSort();
		}

		// Token: 0x06045586 RID: 284038 RVA: 0x0121DB15 File Offset: 0x0121BD15
		private void TryAddKey(string keyName)
		{
			if (this.InputKeyMap.ContainsKey(keyName))
			{
				return;
			}
			this.AddKey(keyName);
		}

		// Token: 0x06045587 RID: 284039 RVA: 0x0121DB30 File Offset: 0x0121BD30
		private void AddKey(string keyName)
		{
			InputKey value = new InputKey(keyName);
			this.InputKeyMap[keyName] = value;
		}

		// Token: 0x06045588 RID: 284040 RVA: 0x0121DB51 File Offset: 0x0121BD51
		private void ClearKey()
		{
			this.InputKeyMap.Clear();
		}

		// Token: 0x06045589 RID: 284041 RVA: 0x0121DB5E File Offset: 0x0121BD5E
		[NullableContext(2)]
		public InputKey GetKey(EKey key)
		{
			return this.GetKey(key.ToString());
		}

		// Token: 0x0604558A RID: 284042 RVA: 0x0121DB74 File Offset: 0x0121BD74
		[return: Nullable(2)]
		public InputKey GetKey(string key)
		{
			InputKey result;
			if (this.InputKeyMap.TryGetValue(key, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0604558B RID: 284043 RVA: 0x0121DB94 File Offset: 0x0121BD94
		[return: Nullable(2)]
		public FKey GetUeKey(string keyName)
		{
			InputKey key = this.GetKey(keyName);
			if (key == null)
			{
				return null;
			}
			return key.ToUeKey();
		}

		// Token: 0x0604558C RID: 284044 RVA: 0x0121DBA8 File Offset: 0x0121BDA8
		public float? GetInputAnalogKeyState(string keyName)
		{
			InputKey key = this.GetKey(keyName);
			if (key == null)
			{
				return null;
			}
			return new float?(key.GetInputAnalogKeyState());
		}

		// Token: 0x0604558D RID: 284045 RVA: 0x0121DBD4 File Offset: 0x0121BDD4
		public bool IsInputKeyDown(string keyName)
		{
			InputKey key = this.GetKey(keyName);
			return key != null && key.IsInputKeyDown();
		}

		// Token: 0x0604558E RID: 284046 RVA: 0x0121DBF4 File Offset: 0x0121BDF4
		public bool IsKeyboardKey(string keyName)
		{
			InputKey key = this.GetKey(keyName);
			if (key == null)
			{
				FKey fkey = new FKey(new FName(keyName));
				return UKismetInputLibrary.Key_IsKeyboardKey(fkey);
			}
			return key.IsKeyboardKey;
		}

		// Token: 0x0604558F RID: 284047 RVA: 0x0121DC28 File Offset: 0x0121BE28
		public bool IsGamepadKey(string keyName)
		{
			InputKey key = this.GetKey(keyName);
			if (key == null)
			{
				FKey fkey = new FKey(new FName(keyName));
				return UKismetInputLibrary.Key_IsGamepadKey(fkey);
			}
			return key.IsGamepadKey;
		}

		// Token: 0x06045590 RID: 284048 RVA: 0x0121DC5C File Offset: 0x0121BE5C
		public bool IsMouseButton(string keyName)
		{
			InputKey key = this.GetKey(keyName);
			if (key == null)
			{
				FKey fkey = new FKey(new FName(keyName));
				return UKismetInputLibrary.Key_IsMouseButton(fkey);
			}
			return key.IsMouseButton;
		}

		// Token: 0x06045591 RID: 284049 RVA: 0x0121DC8E File Offset: 0x0121BE8E
		public bool IsValidKey(string keyName)
		{
			return keyName != EKey.Keyboard_Invalid && keyName != EKey.Gamepad_Invalid && keyName != EKey.GenericUSBController_ButtonInvalid;
		}

		// Token: 0x06045592 RID: 284050 RVA: 0x0121DCC8 File Offset: 0x0121BEC8
		[return: Nullable(2)]
		public string GetKeyIconPath(string keyName)
		{
			InputKey key = this.GetKey(keyName);
			if (key == null)
			{
				return null;
			}
			return key.GetKeyIconPath();
		}

		// Token: 0x06045593 RID: 284051 RVA: 0x0121DCE8 File Offset: 0x0121BEE8
		public void SetActionMappingApplyInputSettings(string actionName, IList<string> keys, EInputBindingType bindingType, bool applyRemoveInputSettings, bool applyAddInputSettings)
		{
			this.ClearActionMappingInternalByBindingType(actionName, bindingType, applyRemoveInputSettings);
			this.SetAllActionMappingInternalByBindingType(actionName, keys, bindingType, applyAddInputSettings);
		}

		// Token: 0x06045594 RID: 284052 RVA: 0x0121DD00 File Offset: 0x0121BF00
		public void SetActionMapping(string actionName, IList<string> keys, EInputBindingType lastBindingType, EInputBindingType bindingType)
		{
			UInputSettings inputSettingsInstance = this.InputSettingsInstance;
			if (inputSettingsInstance == null || !inputSettingsInstance.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "设置Action按键映射时，InputSetting不可用";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", actionName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (lastBindingType != bindingType)
			{
				Dictionary<string, InputActionKey> inputActionKeyMapByBindingType = this.GetInputActionKeyMapByBindingType(actionName, lastBindingType);
				if (inputActionKeyMapByBindingType != null && inputActionKeyMapByBindingType.Count > 0)
				{
					TArray<FInputActionKeyMapping> tarray = new TArray<FInputActionKeyMapping>();
					foreach (InputActionKey inputActionKey in inputActionKeyMapByBindingType.Values)
					{
						tarray.Add(inputActionKey.ToUeInputActionKeyMapping());
					}
					this.InputSettingsInstance.RemoveActionMappings(tarray, true);
				}
			}
			this.SetActionMappingApplyInputSettings(actionName, keys, bindingType, true, true);
		}

		// Token: 0x06045595 RID: 284053 RVA: 0x0121DDD4 File Offset: 0x0121BFD4
		public void AddActionMapping(string actionName, string keyName, EInputBindingType bindingType, bool needApply)
		{
			UInputSettings inputSettingsInstance = this.InputSettingsInstance;
			if (inputSettingsInstance == null || !inputSettingsInstance.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "添加Action按键映射时，InputSetting不可用";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", actionName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.AddActionMappingInternal(actionName, keyName, bindingType, needApply);
		}

		// Token: 0x06045596 RID: 284054 RVA: 0x0121DE2C File Offset: 0x0121C02C
		private void SetAllActionMappingInternalByBindingType(string actionName, IList<string> keys, EInputBindingType bindingType, bool applyAddInputSettings)
		{
			if (keys.Count > 0)
			{
				if (applyAddInputSettings)
				{
					TArray<FInputActionKeyMapping> tarray = new TArray<FInputActionKeyMapping>();
					foreach (string keyName in keys)
					{
						InputActionKey inputActionKey = this.AddActionMappingInternal(actionName, keyName, bindingType, false);
						tarray.Add(inputActionKey.ToUeInputActionKeyMapping());
					}
					this.InputSettingsInstance.AddActionMappings(tarray, true);
					return;
				}
				foreach (string keyName2 in keys)
				{
					this.AddActionMappingInternal(actionName, keyName2, bindingType, false);
				}
			}
		}

		// Token: 0x06045597 RID: 284055 RVA: 0x0121DEE8 File Offset: 0x0121C0E8
		private InputActionKey AddActionMappingInternal(string actionName, string keyName, EInputBindingType bindingType, bool needApply)
		{
			this.TryAddKey(keyName);
			Dictionary<EInputBindingType, Dictionary<string, InputActionKey>> dictionary = this.GetInputActionKeyMap(actionName);
			if (dictionary == null)
			{
				dictionary = new Dictionary<EInputBindingType, Dictionary<string, InputActionKey>>();
				this.InputActionKeyMappings[actionName] = dictionary;
			}
			Dictionary<string, InputActionKey> dictionary2;
			if (!dictionary.TryGetValue(bindingType, out dictionary2) || dictionary2 == null)
			{
				dictionary2 = new Dictionary<string, InputActionKey>();
				dictionary[bindingType] = dictionary2;
			}
			InputActionKey inputActionKey = this.PopInputActionKey(actionName, false, false, false, false, keyName);
			if (needApply)
			{
				UInputSettings inputSettingsInstance = this.InputSettingsInstance;
				FInputActionKeyMapping finputActionKeyMapping = inputActionKey.ToUeInputActionKeyMapping();
				inputSettingsInstance.AddActionMapping(finputActionKeyMapping, true);
			}
			dictionary2[keyName] = inputActionKey;
			return inputActionKey;
		}

		// Token: 0x06045598 RID: 284056 RVA: 0x0121DF68 File Offset: 0x0121C168
		public unsafe void RemoveActionMapping(string actionName, string keyName, EInputBindingType bindingType, bool applyInputSettings, bool rebuildKeyMaps)
		{
			UInputSettings inputSettingsInstance = this.InputSettingsInstance;
			if (inputSettingsInstance == null || !inputSettingsInstance.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "删除Action按键映射时，InputSetting不可用";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", actionName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Dictionary<string, InputActionKey> inputActionKeyMapByBindingType = this.GetInputActionKeyMapByBindingType(actionName, bindingType);
			if (inputActionKeyMapByBindingType == null)
			{
				return;
			}
			InputActionKey inputActionKey;
			if (!inputActionKeyMapByBindingType.TryGetValue(keyName, out inputActionKey) || inputActionKey == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.InputSettings;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "删除Action按键映射时,找不到对应按键";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("actionName", actionName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("key", keyName);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.RemoveActionMappingInternal(inputActionKey, inputActionKeyMapByBindingType, applyInputSettings, rebuildKeyMaps);
		}

		// Token: 0x06045599 RID: 284057 RVA: 0x0121E030 File Offset: 0x0121C230
		private void RemoveActionMappingInternal(InputActionKey inputActionKey, Dictionary<string, InputActionKey> inputActionKeyMap, bool applyInputSettings, bool rebuildKeyMaps)
		{
			string keyName = inputActionKey.KeyName;
			if (applyInputSettings)
			{
				UInputSettings inputSettingsInstance = this.InputSettingsInstance;
				FInputActionKeyMapping finputActionKeyMapping = inputActionKey.ToUeInputActionKeyMapping();
				inputSettingsInstance.RemoveActionMapping(finputActionKeyMapping, rebuildKeyMaps);
			}
			inputActionKeyMap.Remove(keyName);
		}

		// Token: 0x0604559A RID: 284058 RVA: 0x0121E068 File Offset: 0x0121C268
		public void ClearActionMapping(string actionName)
		{
			UInputSettings inputSettingsInstance = this.InputSettingsInstance;
			if (inputSettingsInstance == null || !inputSettingsInstance.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "删除Action所有按键映射时，InputSetting不可用";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", actionName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.ClearActionMappingInternal(actionName);
		}

		// Token: 0x0604559B RID: 284059 RVA: 0x0121E0BC File Offset: 0x0121C2BC
		private void ClearActionMappingInternal(string actionName)
		{
			Dictionary<EInputBindingType, Dictionary<string, InputActionKey>> inputActionKeyMap = this.GetInputActionKeyMap(actionName);
			if (inputActionKeyMap == null)
			{
				return;
			}
			if (inputActionKeyMap.Count > 0)
			{
				TArray<FInputActionKeyMapping> tarray = new TArray<FInputActionKeyMapping>();
				foreach (Dictionary<string, InputActionKey> dictionary in inputActionKeyMap.Values)
				{
					foreach (InputActionKey inputActionKey in dictionary.Values)
					{
						tarray.Add(inputActionKey.ToUeInputActionKeyMapping());
						this.RecycleInputActionKey(inputActionKey);
					}
					dictionary.Clear();
				}
				this.InputSettingsInstance.RemoveActionMappings(tarray, true);
			}
		}

		// Token: 0x0604559C RID: 284060 RVA: 0x0121E18C File Offset: 0x0121C38C
		private void ClearActionMappingInternalByBindingType(string actionName, EInputBindingType bindingType, bool applyInputSettings)
		{
			Dictionary<EInputBindingType, Dictionary<string, InputActionKey>> inputActionKeyMap = this.GetInputActionKeyMap(actionName);
			if (inputActionKeyMap == null)
			{
				return;
			}
			Dictionary<string, InputActionKey> dictionary;
			if (!inputActionKeyMap.TryGetValue(bindingType, out dictionary) || dictionary == null)
			{
				return;
			}
			if (applyInputSettings && dictionary.Count > 0)
			{
				TArray<FInputActionKeyMapping> tarray = new TArray<FInputActionKeyMapping>();
				foreach (InputActionKey inputActionKey in dictionary.Values)
				{
					tarray.Add(inputActionKey.ToUeInputActionKeyMapping());
					this.RecycleInputActionKey(inputActionKey);
				}
				this.InputSettingsInstance.RemoveActionMappings(tarray, true);
			}
			else
			{
				foreach (InputActionKey inputActionKey2 in dictionary.Values)
				{
					this.RecycleInputActionKey(inputActionKey2);
				}
			}
			dictionary.Clear();
		}

		// Token: 0x0604559D RID: 284061 RVA: 0x0121E278 File Offset: 0x0121C478
		[return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public Dictionary<EInputBindingType, Dictionary<string, InputActionKey>> GetInputActionKeyMap(string actionName)
		{
			Dictionary<EInputBindingType, Dictionary<string, InputActionKey>> result;
			if (this.InputActionKeyMappings.TryGetValue(actionName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0604559E RID: 284062 RVA: 0x0121E298 File Offset: 0x0121C498
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, InputActionKey> GetInputActionKeyMapByBindingType(string actionName, EInputBindingType bindingType)
		{
			Dictionary<EInputBindingType, Dictionary<string, InputActionKey>> dictionary;
			if (!this.InputActionKeyMappings.TryGetValue(actionName, out dictionary) || dictionary == null)
			{
				return null;
			}
			Dictionary<string, InputActionKey> result;
			if (dictionary.TryGetValue(bindingType, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0604559F RID: 284063 RVA: 0x0121E2C8 File Offset: 0x0121C4C8
		[return: Nullable(2)]
		public InputActionKey GetInputActionKey(string actionName, string keyName, EInputBindingType bindingType)
		{
			Dictionary<EInputBindingType, Dictionary<string, InputActionKey>> inputActionKeyMap = this.GetInputActionKeyMap(actionName);
			if (inputActionKeyMap == null)
			{
				return null;
			}
			Dictionary<string, InputActionKey> dictionary;
			if (!inputActionKeyMap.TryGetValue(bindingType, out dictionary) || dictionary == null)
			{
				return null;
			}
			InputActionKey result;
			if (dictionary.TryGetValue(keyName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060455A0 RID: 284064 RVA: 0x0121E300 File Offset: 0x0121C500
		public TArray<FName> GetActionNames()
		{
			TArray<FName> result = new TArray<FName>();
			this.InputSettingsInstance.GetActionNames(ref result);
			return result;
		}

		// Token: 0x060455A1 RID: 284065 RVA: 0x0121E324 File Offset: 0x0121C524
		public TArray<FInputActionKeyMapping> GetActionMappings(string actionName)
		{
			TArray<FInputActionKeyMapping> result = new TArray<FInputActionKeyMapping>();
			this.InputSettingsInstance.GetActionMappingByName(FNameUtil.GetDynamicFName(actionName).Value, ref result);
			return result;
		}

		// Token: 0x060455A2 RID: 284066 RVA: 0x0121E354 File Offset: 0x0121C554
		private void SetAxisMappingWithAddInputSettings(string axisName, Dictionary<string, float> keyScaleMap, EInputBindingType bindingType)
		{
			Dictionary<string, InputAxisKey> inputAxisKeyMap = this.GetInputAxisKeyMap(axisName, bindingType);
			if (inputAxisKeyMap != null)
			{
				foreach (InputAxisKey inputAxisKey in inputAxisKeyMap.Values)
				{
					this.RemoveAxisMappingInternal(inputAxisKey, inputAxisKeyMap, false);
				}
			}
			List<ValueTuple<string, float>> list = new List<ValueTuple<string, float>>();
			foreach (KeyValuePair<string, float> keyValuePair in keyScaleMap)
			{
				list.Add(new ValueTuple<string, float>(keyValuePair.Key, keyValuePair.Value));
			}
			if (list.Count > 0)
			{
				TArray<FInputAxisKeyMapping> tarray = new TArray<FInputAxisKeyMapping>();
				foreach (ValueTuple<string, float> valueTuple in list)
				{
					InputAxisKey inputAxisKey2 = this.AddAxisMappingInternal(axisName, valueTuple.Item2, valueTuple.Item1, bindingType, false);
					tarray.Add(inputAxisKey2.ToUeInputAxisKeyMapping());
				}
				this.InputSettingsInstance.AddAxisMappings(tarray, true);
			}
		}

		// Token: 0x060455A3 RID: 284067 RVA: 0x0121E48C File Offset: 0x0121C68C
		private void SetAxisMappingApplyInputSettings(string axisName, Dictionary<string, float> keyScaleMap, EInputBindingType bindingType)
		{
			Dictionary<string, InputAxisKey> inputAxisKeyMap = this.GetInputAxisKeyMap(axisName, bindingType);
			if (inputAxisKeyMap != null)
			{
				List<InputAxisKey> list = new List<InputAxisKey>();
				foreach (InputAxisKey inputAxisKey in inputAxisKeyMap.Values)
				{
					string keyName = inputAxisKey.KeyName;
					if (!keyScaleMap.ContainsKey(keyName) || inputAxisKey.Scale != keyScaleMap[keyName])
					{
						list.Add(inputAxisKey);
					}
				}
				if (list.Count > 0)
				{
					TArray<FInputAxisKeyMapping> tarray = new TArray<FInputAxisKeyMapping>();
					foreach (InputAxisKey inputAxisKey2 in list)
					{
						tarray.Add(inputAxisKey2.ToUeInputAxisKeyMapping());
						this.RemoveAxisMappingInternal(inputAxisKey2, inputAxisKeyMap, false);
					}
					this.InputSettingsInstance.RemoveAxisMappings(tarray, true);
				}
			}
			List<ValueTuple<string, float>> list2 = new List<ValueTuple<string, float>>();
			foreach (KeyValuePair<string, float> keyValuePair in keyScaleMap)
			{
				string key = keyValuePair.Key;
				float value = keyValuePair.Value;
				InputAxisKey inputAxisKey3 = this.GetInputAxisKey(axisName, key, bindingType);
				if (inputAxisKey3 == null || inputAxisKey3.Scale != keyScaleMap[key])
				{
					list2.Add(new ValueTuple<string, float>(key, value));
				}
			}
			if (list2.Count > 0)
			{
				TArray<FInputAxisKeyMapping> tarray2 = new TArray<FInputAxisKeyMapping>();
				foreach (ValueTuple<string, float> valueTuple in list2)
				{
					InputAxisKey inputAxisKey4 = this.AddAxisMappingInternal(axisName, valueTuple.Item2, valueTuple.Item1, bindingType, false);
					tarray2.Add(inputAxisKey4.ToUeInputAxisKeyMapping());
				}
				this.InputSettingsInstance.AddAxisMappings(tarray2, true);
			}
		}

		// Token: 0x060455A4 RID: 284068 RVA: 0x0121E688 File Offset: 0x0121C888
		public void SetAxisMappingWithoutInputSettings(string axisName, Dictionary<string, float> keyScaleMap, EInputBindingType bindingType)
		{
			Dictionary<string, InputAxisKey> inputAxisKeyMap = this.GetInputAxisKeyMap(axisName, bindingType);
			if (inputAxisKeyMap != null)
			{
				foreach (InputAxisKey inputAxisKey in inputAxisKeyMap.Values)
				{
					this.RemoveAxisMappingInternal(inputAxisKey, inputAxisKeyMap, false);
				}
			}
			foreach (KeyValuePair<string, float> keyValuePair in keyScaleMap)
			{
				string key = keyValuePair.Key;
				float value = keyValuePair.Value;
				this.AddAxisMappingInternal(axisName, value, key, bindingType, false);
			}
		}

		// Token: 0x060455A5 RID: 284069 RVA: 0x0121E740 File Offset: 0x0121C940
		public void SetAxisMapping(string axisName, Dictionary<string, float> keyScaleMap, EInputBindingType lastBindingType, EInputBindingType bindingType)
		{
			UInputSettings inputSettingsInstance = this.InputSettingsInstance;
			if (inputSettingsInstance == null || !inputSettingsInstance.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "设置Axis按键映射时，InputSetting不可用";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", axisName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (lastBindingType != bindingType)
			{
				Dictionary<string, InputAxisKey> inputAxisKeyMap = this.GetInputAxisKeyMap(axisName, lastBindingType);
				if (inputAxisKeyMap != null && inputAxisKeyMap.Count > 0)
				{
					TArray<FInputAxisKeyMapping> tarray = new TArray<FInputAxisKeyMapping>();
					foreach (InputAxisKey inputAxisKey in inputAxisKeyMap.Values)
					{
						tarray.Add(inputAxisKey.ToUeInputAxisKeyMapping());
					}
					this.InputSettingsInstance.RemoveAxisMappings(tarray, true);
				}
				this.SetAxisMappingWithAddInputSettings(axisName, keyScaleMap, bindingType);
				return;
			}
			this.SetAxisMappingApplyInputSettings(axisName, keyScaleMap, bindingType);
		}

		// Token: 0x060455A6 RID: 284070 RVA: 0x0121E81C File Offset: 0x0121CA1C
		private InputAxisKey AddAxisMappingInternal(string axisName, float scale, string keyName, EInputBindingType bindingType, bool needApply)
		{
			this.TryAddKey(keyName);
			Dictionary<EInputBindingType, Dictionary<string, InputAxisKey>> dictionary = this.GetInputAxisKeyMapByBindingType(axisName);
			if (dictionary == null)
			{
				dictionary = new Dictionary<EInputBindingType, Dictionary<string, InputAxisKey>>();
				this.InputAxisKeyMappings[axisName] = dictionary;
			}
			Dictionary<string, InputAxisKey> dictionary2;
			if (!dictionary.TryGetValue(bindingType, out dictionary2) || dictionary2 == null)
			{
				dictionary2 = new Dictionary<string, InputAxisKey>();
				dictionary[bindingType] = dictionary2;
			}
			InputAxisKey inputAxisKey = this.PopInputAxisKey(axisName, scale, keyName);
			if (needApply)
			{
				UInputSettings inputSettingsInstance = this.InputSettingsInstance;
				FInputAxisKeyMapping finputAxisKeyMapping = inputAxisKey.ToUeInputAxisKeyMapping();
				inputSettingsInstance.AddAxisMapping(finputAxisKeyMapping, true);
			}
			dictionary2[keyName] = inputAxisKey;
			return inputAxisKey;
		}

		// Token: 0x060455A7 RID: 284071 RVA: 0x0121E898 File Offset: 0x0121CA98
		private void RemoveAxisMappingInternal(InputAxisKey inputAxisKey, Dictionary<string, InputAxisKey> inputAxisMap, bool needApply)
		{
			string keyName = inputAxisKey.KeyName;
			if (needApply)
			{
				UInputSettings inputSettingsInstance = this.InputSettingsInstance;
				FInputAxisKeyMapping finputAxisKeyMapping = inputAxisKey.ToUeInputAxisKeyMapping();
				inputSettingsInstance.RemoveAxisMapping(finputAxisKeyMapping, true);
			}
			this.RecycleInputAxisKey(inputAxisKey);
			inputAxisMap.Remove(keyName);
		}

		// Token: 0x060455A8 RID: 284072 RVA: 0x0121E8D4 File Offset: 0x0121CAD4
		public void ClearAxisMapping(string axisName)
		{
			UInputSettings inputSettingsInstance = this.InputSettingsInstance;
			if (inputSettingsInstance == null || !inputSettingsInstance.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "删除Axis所有按键映射时，InputSetting不可用";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("axisName", axisName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Dictionary<EInputBindingType, Dictionary<string, InputAxisKey>> inputAxisKeyMapByBindingType = this.GetInputAxisKeyMapByBindingType(axisName);
			if (inputAxisKeyMapByBindingType == null)
			{
				return;
			}
			if (inputAxisKeyMapByBindingType.Count > 0)
			{
				TArray<FInputAxisKeyMapping> tarray = new TArray<FInputAxisKeyMapping>();
				foreach (Dictionary<string, InputAxisKey> dictionary in inputAxisKeyMapByBindingType.Values)
				{
					foreach (InputAxisKey inputAxisKey in dictionary.Values)
					{
						tarray.Add(inputAxisKey.ToUeInputAxisKeyMapping());
						this.RecycleInputAxisKey(inputAxisKey);
					}
					dictionary.Clear();
				}
				this.InputSettingsInstance.RemoveAxisMappings(tarray, true);
			}
		}

		// Token: 0x060455A9 RID: 284073 RVA: 0x0121E9E8 File Offset: 0x0121CBE8
		[return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public Dictionary<EInputBindingType, Dictionary<string, InputAxisKey>> GetInputAxisKeyMapByBindingType(string axisName)
		{
			Dictionary<EInputBindingType, Dictionary<string, InputAxisKey>> result;
			if (this.InputAxisKeyMappings.TryGetValue(axisName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060455AA RID: 284074 RVA: 0x0121EA08 File Offset: 0x0121CC08
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, InputAxisKey> GetInputAxisKeyMap(string axisName, EInputBindingType bindingType)
		{
			Dictionary<EInputBindingType, Dictionary<string, InputAxisKey>> dictionary;
			if (!this.InputAxisKeyMappings.TryGetValue(axisName, out dictionary) || dictionary == null)
			{
				return null;
			}
			Dictionary<string, InputAxisKey> result;
			if (dictionary.TryGetValue(bindingType, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060455AB RID: 284075 RVA: 0x0121EA38 File Offset: 0x0121CC38
		[return: Nullable(2)]
		public InputAxisKey GetInputAxisKey(string axisName, string keyName, EInputBindingType bindingType)
		{
			Dictionary<EInputBindingType, Dictionary<string, InputAxisKey>> dictionary;
			if (!this.InputAxisKeyMappings.TryGetValue(axisName, out dictionary) || dictionary == null)
			{
				return null;
			}
			Dictionary<string, InputAxisKey> dictionary2;
			if (!dictionary.TryGetValue(bindingType, out dictionary2) || dictionary2 == null)
			{
				return null;
			}
			InputAxisKey result;
			if (dictionary2.TryGetValue(keyName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060455AC RID: 284076 RVA: 0x0121EA78 File Offset: 0x0121CC78
		public TArray<FName> GetAxisNames()
		{
			TArray<FName> result = new TArray<FName>();
			this.InputSettingsInstance.GetAxisNames(ref result);
			return result;
		}

		// Token: 0x060455AD RID: 284077 RVA: 0x0121EA9C File Offset: 0x0121CC9C
		public TArray<FInputAxisKeyMapping> GetAxisMappings(string actionName)
		{
			TArray<FInputAxisKeyMapping> result = new TArray<FInputAxisKeyMapping>();
			this.InputSettingsInstance.GetAxisMappingByName(FNameUtil.GetDynamicFName(actionName).Value, ref result);
			return result;
		}

		// Token: 0x060455AE RID: 284078 RVA: 0x0121EACC File Offset: 0x0121CCCC
		[return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public Dictionary<string, List<InputCombinationActionKey>> GetCombinationActionKeyMap(string actionName)
		{
			Dictionary<string, List<InputCombinationActionKey>> result;
			if (this.InputCombinationActionKeyMappings.TryGetValue(actionName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060455AF RID: 284079 RVA: 0x0121EAEC File Offset: 0x0121CCEC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<InputCombinationActionKey> GetCombinationActionKey(string actionName, string mainKeyName)
		{
			Dictionary<string, List<InputCombinationActionKey>> dictionary;
			if (!this.InputCombinationActionKeyMappings.TryGetValue(actionName, out dictionary) || dictionary == null)
			{
				return null;
			}
			List<InputCombinationActionKey> result;
			if (dictionary.TryGetValue(mainKeyName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060455B0 RID: 284080 RVA: 0x0121EB1C File Offset: 0x0121CD1C
		[return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public Dictionary<string, IList<InputCombinationAxisKey>> GetCombinationAxisKeyMap(string axisName)
		{
			Dictionary<string, IList<InputCombinationAxisKey>> result;
			if (this.InputCombinationAxisKeyMappings.TryGetValue(axisName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060455B1 RID: 284081 RVA: 0x0121EB3C File Offset: 0x0121CD3C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public IList<InputCombinationAxisKey> GetCombinationAxisKey(string axisName, string mainKeyName)
		{
			Dictionary<string, IList<InputCombinationAxisKey>> dictionary;
			if (!this.InputCombinationAxisKeyMappings.TryGetValue(axisName, out dictionary) || dictionary == null)
			{
				return null;
			}
			IList<InputCombinationAxisKey> result;
			if (dictionary.TryGetValue(mainKeyName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060455B2 RID: 284082 RVA: 0x0121EB6C File Offset: 0x0121CD6C
		public void SetUseMouseForTouch(bool value)
		{
			if (this.InputSettingsInstance == null)
			{
				return;
			}
			this.InputSettingsInstance.bUseMouseForTouch = value;
		}

		// Token: 0x060455B3 RID: 284083 RVA: 0x0121EB84 File Offset: 0x0121CD84
		public EKeyboardPrimaryLangId GetKeyboardPrimaryLangId()
		{
			if (this.InputSettingsInstance != null)
			{
				EKeyboardPrimaryLangId ekeyboardPrimaryLangId = (EKeyboardPrimaryLangId)this.InputSettingsInstance.GetKeyboardPrimaryLangId().ToString();
				if (ekeyboardPrimaryLangId == EKeyboardPrimaryLangId.French || ekeyboardPrimaryLangId == EKeyboardPrimaryLangId.Thai)
				{
					return ekeyboardPrimaryLangId;
				}
			}
			return EKeyboardPrimaryLangId.Default;
		}

		// Token: 0x04026ADB RID: 158427
		[Nullable(2)]
		private UInputSettings InputSettingsInstance;

		// Token: 0x04026ADC RID: 158428
		private readonly Dictionary<string, InputKey> InputKeyMap = new Dictionary<string, InputKey>();

		// Token: 0x04026ADD RID: 158429
		private readonly Dictionary<string, Dictionary<EInputBindingType, Dictionary<string, InputActionKey>>> InputActionKeyMappings = new Dictionary<string, Dictionary<EInputBindingType, Dictionary<string, InputActionKey>>>();

		// Token: 0x04026ADE RID: 158430
		private readonly Dictionary<string, Dictionary<EInputBindingType, Dictionary<string, InputAxisKey>>> InputAxisKeyMappings = new Dictionary<string, Dictionary<EInputBindingType, Dictionary<string, InputAxisKey>>>();

		// Token: 0x04026ADF RID: 158431
		private readonly Dictionary<string, Dictionary<string, List<InputCombinationActionKey>>> InputCombinationActionKeyMappings = new Dictionary<string, Dictionary<string, List<InputCombinationActionKey>>>();

		// Token: 0x04026AE0 RID: 158432
		private readonly Dictionary<string, Dictionary<string, IList<InputCombinationAxisKey>>> InputCombinationAxisKeyMappings = new Dictionary<string, Dictionary<string, IList<InputCombinationAxisKey>>>();

		// Token: 0x04026AE1 RID: 158433
		private readonly List<InputActionKey> InputActionKeyPool = new List<InputActionKey>();

		// Token: 0x04026AE2 RID: 158434
		private readonly List<InputAxisKey> InputAxisKeyPool = new List<InputAxisKey>();
	}
}
