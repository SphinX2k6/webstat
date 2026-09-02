using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Input.BattleInputData;
using CSharpScript.Game.Module.KeySetting;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Launcher.Platform;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FF9 RID: 28665
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InputSettingsManager : Singleton<InputSettingsManager>
	{
		// Token: 0x1700A4BE RID: 42174
		// (get) Token: 0x060455F7 RID: 284151 RVA: 0x0122259C File Offset: 0x0122079C
		// (set) Token: 0x060455F8 RID: 284152 RVA: 0x012225A4 File Offset: 0x012207A4
		public string DeviceLang
		{
			get
			{
				return this.DeviceLangInternal;
			}
			set
			{
				if (StringUtils.IsBlank(value))
				{
					this.DeviceLangInternal = EKeyboardPrimaryLangId.Default;
					return;
				}
				this.DeviceLangInternal = value;
			}
		}

		// Token: 0x060455F9 RID: 284153 RVA: 0x012225C8 File Offset: 0x012207C8
		public void Initialize()
		{
			this.ActionMapping = new InputActionMapping();
			this.ActionMapping.Initialize();
			this.AxisMapping = new InputAxisMapping();
			this.AxisMapping.Initialize();
			this.CombinationActionMapping = new InputCombinationActionMapping();
			this.CombinationAxisMapping = new InputCombinationAxisMapping();
			this.RefreshAllActionKeys();
			this.RefreshAllAxisKeys();
			this.InitDeviceLangChangeDelegate();
			this.RefreshCombinationActionKeys();
			this.RefreshCombinationAxisKeys();
			this.InitKeySettingKeys();
			this.ConvertInputActionSort();
			this.ConvertPhantomInput();
			this.TryFirstSaveKeyMappings();
		}

		// Token: 0x060455FA RID: 284154 RVA: 0x01222650 File Offset: 0x01220850
		public void Clear()
		{
			this.StopCheckCombinationActionKeyMapSave();
			this.SaveCombinationActionKeyMapIfDirty();
			this.ClearDeviceLangChangeDelegate();
			this.ActionMapping.Clear();
			this.ActionMapping = null;
			this.AxisMapping.Clear();
			this.AxisMapping = null;
			this.CombinationActionMapping.Clear();
			this.CombinationActionMapping = null;
			this.CombinationAxisMapping.Clear();
			this.CombinationAxisMapping = null;
		}

		// Token: 0x1700A4BF RID: 42175
		// (get) Token: 0x060455FB RID: 284155 RVA: 0x012226B8 File Offset: 0x012208B8
		public bool CheckUseFrenchKeyboard
		{
			get
			{
				return Singleton<InputSettings>.Instance.GetKeyboardPrimaryLangId() == EKeyboardPrimaryLangId.French;
			}
		}

		// Token: 0x060455FC RID: 284156 RVA: 0x012226CE File Offset: 0x012208CE
		public bool CheckUseFrenchKeyboardLang(string deviceLang)
		{
			return deviceLang == EKeyboardPrimaryLangId.French;
		}

		// Token: 0x060455FD RID: 284157 RVA: 0x012226E0 File Offset: 0x012208E0
		private void InitPcKeysMap()
		{
			this.NormalToFrenchPcKeysMap.Clear();
			this.FrenchToNormalPcKeysMap.Clear();
			IReadOnlyList<PcKey> pcKeyConfigList = ConfigBase<InputSettingsConfig>.Instance.GetPcKeyConfigList();
			if (pcKeyConfigList != null)
			{
				foreach (PcKey pcKey in pcKeyConfigList)
				{
					if (!StringUtils.IsBlank(pcKey.FrenchKeyName))
					{
						this.NormalToFrenchPcKeysMap[pcKey.KeyName] = pcKey.FrenchKeyName;
						this.FrenchToNormalPcKeysMap[pcKey.FrenchKeyName] = pcKey.KeyName;
					}
				}
			}
		}

		// Token: 0x060455FE RID: 284158 RVA: 0x01222788 File Offset: 0x01220988
		private void InitDeviceLangChangeDelegate()
		{
			if (Singleton<Platform>.Instance.IsPcPlatform())
			{
				this.CurrentDeviceLang = Singleton<InputSettings>.Instance.GetKeyboardPrimaryLangId();
				this.DeviceLangInternal = this.CurrentDeviceLang;
				this.InitPcKeysMap();
				FDeviceLangChange fdeviceLangChange = global::DelegateUtils.ToManualReleaseDelegate<FDeviceLangChange>(new Action(this.OnDeviceLangChangeDelegate));
				UKuroStaticLibrary.BindDeviceLangChangeDelegate(fdeviceLangChange);
				return;
			}
			this.CurrentDeviceLang = EKeyboardPrimaryLangId.Default;
			this.DeviceLangInternal = EKeyboardPrimaryLangId.Default;
		}

		// Token: 0x060455FF RID: 284159 RVA: 0x012227FD File Offset: 0x012209FD
		private void ClearDeviceLangChangeDelegate()
		{
			if (Singleton<Platform>.Instance.IsPcPlatform())
			{
				UKuroStaticLibrary.UnBindDeviceLangChangeDelegate();
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnDeviceLangChangeDelegate));
			}
		}

		// Token: 0x06045600 RID: 284160 RVA: 0x01222824 File Offset: 0x01220A24
		private void OnDeviceLangChangeDelegate()
		{
			EKeyboardPrimaryLangId keyboardPrimaryLangId = Singleton<InputSettings>.Instance.GetKeyboardPrimaryLangId();
			this.CurrentDeviceLang = keyboardPrimaryLangId;
			this.ChangeActionAndAxisPcKeys(keyboardPrimaryLangId, false);
		}

		// Token: 0x06045601 RID: 284161 RVA: 0x01222850 File Offset: 0x01220A50
		private string GetKeyNameByKeyboardLang(string lastDeviceLang, string deviceLang, string originalKeyName)
		{
			if (lastDeviceLang == EKeyboardPrimaryLangId.Default && deviceLang == EKeyboardPrimaryLangId.French)
			{
				string text;
				if (this.NormalToFrenchPcKeysMap.TryGetValue(originalKeyName, out text) && !string.IsNullOrEmpty(text))
				{
					return text;
				}
				return originalKeyName;
			}
			else
			{
				if (!(lastDeviceLang == EKeyboardPrimaryLangId.French) || !(deviceLang == EKeyboardPrimaryLangId.Default))
				{
					string text2 = originalKeyName;
					if (lastDeviceLang != EKeyboardPrimaryLangId.Default)
					{
						LanguageKeyTransBase keyTrans = LanguageKeyTransUtils.GetKeyTrans((EKeyboardPrimaryLangId)lastDeviceLang);
						if (keyTrans != null)
						{
							text2 = keyTrans.GetOtherToNormalPcKeysMap(originalKeyName);
						}
					}
					if (deviceLang != EKeyboardPrimaryLangId.Default)
					{
						LanguageKeyTransBase keyTrans2 = LanguageKeyTransUtils.GetKeyTrans((EKeyboardPrimaryLangId)deviceLang);
						if (keyTrans2 != null)
						{
							text2 = keyTrans2.GetNormalToOtherPcKeysMap(text2);
						}
					}
					return text2;
				}
				string text3;
				if (this.FrenchToNormalPcKeysMap.TryGetValue(originalKeyName, out text3) && !string.IsNullOrEmpty(text3))
				{
					return text3;
				}
				return originalKeyName;
			}
		}

		// Token: 0x06045602 RID: 284162 RVA: 0x01222938 File Offset: 0x01220B38
		private void ChangeActionPcKeys(string lastDeviceLang, string deviceLang, bool checkServerData)
		{
			IReadOnlyList<ActionMapping> allActionMappingConfig = ConfigBase<InputSettingsConfig>.Instance.GetAllActionMappingConfig();
			if (allActionMappingConfig != null)
			{
				foreach (ActionMapping actionMapping in allActionMappingConfig)
				{
					string actionName = actionMapping.ActionName;
					InputActionBinding actionBinding = this.GetActionBinding(actionName);
					if (actionBinding != null)
					{
						if (checkServerData && !this.ServerExistingActions.Contains(actionName))
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.InputSettings;
							ELogAuthor author = ELogAuthor.XXJ;
							string message = "服务器数据不存在Action, 不进行键位切换";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActionName", actionName);
							instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						}
						else
						{
							foreach (KeyValuePair<EInputBindingType, List<string>> keyValuePair in actionBinding.GetCopyKeyNameListToBindingTypeMap())
							{
								EInputBindingType einputBindingType;
								List<string> list;
								keyValuePair.Deconstruct(out einputBindingType, out list);
								EInputBindingType bindingType = einputBindingType;
								List<string> list2 = list;
								List<string> list3 = new List<string>(list2.Count);
								bool flag = false;
								foreach (string text in list2)
								{
									InputKey key = Singleton<InputSettings>.Instance.GetKey(text);
									if (key != null && key.IsKeyboardKey)
									{
										flag = true;
										list3.Add(this.GetKeyNameByKeyboardLang(lastDeviceLang, deviceLang, text));
									}
									else
									{
										list3.Add(text);
									}
								}
								if (flag)
								{
									this.SetActionKeysByBindingType(actionName, list3, bindingType);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06045603 RID: 284163 RVA: 0x01222AF4 File Offset: 0x01220CF4
		private void ChangeAxisPcKeys(string lastDeviceLang, string deviceLang, bool checkServerData)
		{
			IReadOnlyList<AxisMapping> allAxisMappingConfig = ConfigBase<InputSettingsConfig>.Instance.GetAllAxisMappingConfig();
			if (allAxisMappingConfig != null)
			{
				foreach (AxisMapping axisMapping in allAxisMappingConfig)
				{
					string axisName = axisMapping.AxisName;
					InputAxisBinding axisBinding = this.GetAxisBinding(axisName);
					if (axisBinding != null)
					{
						if (checkServerData && !this.ServerExistingAxisNames.Contains(axisName))
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.InputSettings;
							ELogAuthor author = ELogAuthor.XXJ;
							string message = "服务器数据不存在Axis, 不进行键位切换";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AxisName", axisName);
							instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						}
						else
						{
							foreach (KeyValuePair<EInputBindingType, Dictionary<string, float>> keyValuePair in axisBinding.GetCopyKeyNameListToBindingTypeMap())
							{
								EInputBindingType key = keyValuePair.Key;
								Dictionary<string, float> value = keyValuePair.Value;
								Dictionary<string, float> dictionary = new Dictionary<string, float>();
								bool flag = false;
								foreach (KeyValuePair<string, float> keyValuePair2 in value)
								{
									string key2 = keyValuePair2.Key;
									float value2 = keyValuePair2.Value;
									InputKey key3 = Singleton<InputSettings>.Instance.GetKey(key2);
									if (key3 != null && key3.IsKeyboardKey)
									{
										flag = true;
										dictionary[this.GetKeyNameByKeyboardLang(lastDeviceLang, deviceLang, key2)] = value2;
									}
									else
									{
										dictionary[key2] = value2;
									}
								}
								if (flag)
								{
									this.SetAxisKeys(axisName, dictionary, key);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06045604 RID: 284164 RVA: 0x01222CC0 File Offset: 0x01220EC0
		private void ChangeCombinationActionPcKeys(string lastDeviceLang, string deviceLang, bool checkServerData)
		{
			IReadOnlyList<CombinationAction> allCombinationActionConfig = ConfigBase<InputSettingsConfig>.Instance.GetAllCombinationActionConfig();
			if (allCombinationActionConfig == null)
			{
				return;
			}
			foreach (CombinationAction combinationAction in allCombinationActionConfig)
			{
				string actionName = combinationAction.ActionName;
				InputCombinationActionBinding combinationActionBindingByActionName = this.GetCombinationActionBindingByActionName(actionName);
				if (combinationActionBindingByActionName != null)
				{
					if (checkServerData && !this.ServerExistingCombinationActionNames.Contains(actionName))
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.InputSettings;
						ELogAuthor author = ELogAuthor.XXJ;
						string message = "服务器数据不存在组合Action, 不进行键位切换";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActionName", actionName);
						instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
					else
					{
						foreach (KeyValuePair<EInputBindingType, Dictionary<string, string>> keyValuePair in combinationActionBindingByActionName.GetCopyKeyMapToBindingTypeMap())
						{
							EInputBindingType key = keyValuePair.Key;
							foreach (KeyValuePair<string, string> keyValuePair2 in keyValuePair.Value)
							{
								string key2 = keyValuePair2.Key;
								string value = keyValuePair2.Value;
								InputKey key3 = Singleton<InputSettings>.Instance.GetKey(key2);
								InputKey key4 = Singleton<InputSettings>.Instance.GetKey(value);
								if ((key3 != null && key3.IsKeyboardKey) || (key4 != null && key4.IsKeyboardKey))
								{
									string keyNameByKeyboardLang = this.GetKeyNameByKeyboardLang(lastDeviceLang, deviceLang, key2);
									string keyNameByKeyboardLang2 = this.GetKeyNameByKeyboardLang(lastDeviceLang, deviceLang, value);
									if (!(keyNameByKeyboardLang == key2) || !(keyNameByKeyboardLang2 == value))
									{
										this.RemoveCombinationActionKeyMap(actionName, key2, value, key);
										this.AddCombinationActionKeyMap(actionName, keyNameByKeyboardLang, keyNameByKeyboardLang2, key);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06045605 RID: 284165 RVA: 0x01222EB8 File Offset: 0x012210B8
		public unsafe void ChangeActionAndAxisPcKeys(string deviceLang, bool checkServerData = false)
		{
			if (this.DeviceLangInternal == deviceLang)
			{
				return;
			}
			string deviceLangInternal = this.DeviceLangInternal;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "识别到键盘设备切换";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("上次键盘设备语种", deviceLangInternal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("当前键盘设备语种", deviceLang);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			SkillButtonUiGamepadDataBase gamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData != null)
			{
				gamepadData.AddAllowChangeKeyReason("OnDeviceLangChange");
			}
			this.DeviceLangInternal = deviceLang;
			this.ChangeActionPcKeys(deviceLangInternal, deviceLang, checkServerData);
			this.ChangeAxisPcKeys(deviceLangInternal, deviceLang, checkServerData);
			this.ChangeCombinationActionPcKeys(deviceLangInternal, deviceLang, checkServerData);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnDeviceLangChange);
			SkillButtonUiGamepadDataBase gamepadData2 = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData2 != null)
			{
				gamepadData2.RemoveAllowChangeKeyReason("OnDeviceLangChange");
			}
			if (Singleton<Net>.Instance.IsServerConnected())
			{
				ControllerBase<InputSettingsController>.Instance.InputSettingUpdateRequest(false);
			}
		}

		// Token: 0x06045606 RID: 284166 RVA: 0x01222FAB File Offset: 0x012211AB
		public void ResetDefaultInputKey()
		{
			this.ClearAllKeys();
			this.RefreshAllActionKeys();
			this.RefreshAllAxisKeys();
			this.RefreshCombinationActionKeys();
			this.RefreshCombinationAxisKeys();
			Singleton<InputSettings>.Instance.SaveKeyMappings();
		}

		// Token: 0x06045607 RID: 284167 RVA: 0x01222FD5 File Offset: 0x012211D5
		public void ClearAllKeys()
		{
			InputActionMapping actionMapping = this.ActionMapping;
			if (actionMapping != null)
			{
				actionMapping.ClearAllActionKeys();
			}
			InputAxisMapping axisMapping = this.AxisMapping;
			if (axisMapping != null)
			{
				axisMapping.ClearAllAxisKeys();
			}
			this.ClearCombinationActionKeyMap();
			this.ClearCombinationAxisKeyMap();
		}

		// Token: 0x06045608 RID: 284168 RVA: 0x01223008 File Offset: 0x01221208
		public void RefreshAllActionKeys()
		{
			IReadOnlyList<ActionMapping> allActionMappingConfig = ConfigBase<InputSettingsConfig>.Instance.GetAllActionMappingConfig();
			if (allActionMappingConfig != null)
			{
				foreach (ActionMapping actionMappingConfig in allActionMappingConfig)
				{
					string actionName = actionMappingConfig.ActionName;
					this.OriginalActionNameSet.Add(actionName);
					this.SetDefaultConfigActionKeys(actionName, actionMappingConfig, (EInputBindingType)actionMappingConfig.ExclusiveType);
				}
			}
		}

		// Token: 0x06045609 RID: 284169 RVA: 0x0122307C File Offset: 0x0122127C
		private void SetDefaultConfigActionKeys(string actionName, ActionMapping actionMappingConfig, EInputBindingType bindingType)
		{
			List<string> list = new List<string>();
			if (this.CheckUseFrenchKeyboard)
			{
				for (int i = 0; i < actionMappingConfig.FrancePcKeysLength; i++)
				{
					list.Add(actionMappingConfig.FrancePcKeys(i));
				}
			}
			else
			{
				LanguageKeyTransBase keyTrans = LanguageKeyTransUtils.GetKeyTrans(this.CurrentDeviceLang);
				if (keyTrans != null)
				{
					string[] actionPcKeys = keyTrans.GetActionPcKeys(actionMappingConfig);
					list.AddRange(actionPcKeys);
				}
			}
			List<string> list2 = new List<string>();
			for (int j = 0; j < actionMappingConfig.GamepadKeysLength; j++)
			{
				string text = actionMappingConfig.GamepadKeys(j);
				if (!string.IsNullOrEmpty(text))
				{
					list2.Add(text);
				}
			}
			List<string> list3 = new List<string>(list);
			list3.AddRange(list2);
			this.SetActionKeysByBindingType(actionName, list3, bindingType);
		}

		// Token: 0x0604560A RID: 284170 RVA: 0x0122312C File Offset: 0x0122132C
		public void RefreshAllAxisKeys()
		{
			IReadOnlyList<AxisMapping> allAxisMappingConfig = ConfigBase<InputSettingsConfig>.Instance.GetAllAxisMappingConfig();
			if (allAxisMappingConfig != null)
			{
				foreach (AxisMapping axisMappingConfig in allAxisMappingConfig)
				{
					string axisName = axisMappingConfig.AxisName;
					this.SetDefaultConfigAxisKeys(axisName, axisMappingConfig, (EInputBindingType)axisMappingConfig.ExclusiveType);
				}
			}
		}

		// Token: 0x0604560B RID: 284171 RVA: 0x01223194 File Offset: 0x01221394
		private void SetDefaultConfigAxisKeys(string axisName, AxisMapping axisMappingConfig, EInputBindingType bindingType)
		{
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			if (this.CheckUseFrenchKeyboard)
			{
				for (int i = 0; i < axisMappingConfig.FrancePcKeysLength; i++)
				{
					DicStringFloat? dicStringFloat = axisMappingConfig.FrancePcKeys(i);
					dictionary[dicStringFloat.Value.Key] = dicStringFloat.Value.Value;
				}
			}
			else
			{
				LanguageKeyTransBase keyTrans = LanguageKeyTransUtils.GetKeyTrans(this.CurrentDeviceLang);
				if (keyTrans != null)
				{
					dictionary = keyTrans.GetAxisPcKeys(axisMappingConfig);
				}
			}
			Dictionary<string, float> dictionary2 = new Dictionary<string, float>();
			for (int j = 0; j < axisMappingConfig.GamepadKeysLength; j++)
			{
				DicStringFloat? dicStringFloat2 = axisMappingConfig.GamepadKeys(j);
				dictionary2[dicStringFloat2.Value.Key] = dicStringFloat2.Value.Value;
			}
			Dictionary<string, float> dictionary3 = new Dictionary<string, float>();
			dictionary3.AddRange(dictionary);
			dictionary3.AddRange(dictionary2);
			this.SetAxisKeys(axisName, dictionary3, bindingType);
		}

		// Token: 0x0604560C RID: 284172 RVA: 0x01223278 File Offset: 0x01221478
		public void ResetActionKeyByName(string actionName, EInputBindingType bindingType)
		{
			ActionMapping? actionMappingConfigByActionName = ConfigBase<InputSettingsConfig>.Instance.GetActionMappingConfigByActionName(actionName);
			if (actionMappingConfigByActionName == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "Action按键配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActionName", actionName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.SetDefaultConfigActionKeys(actionName, actionMappingConfigByActionName.Value, bindingType);
		}

		// Token: 0x0604560D RID: 284173 RVA: 0x012232D4 File Offset: 0x012214D4
		public void ResetAxisKeyByName(string axisName, EInputBindingType bindingType)
		{
			AxisMapping? axisMappingConfigByAxisName = ConfigBase<InputSettingsConfig>.Instance.GetAxisMappingConfigByAxisName(axisName);
			if (axisMappingConfigByAxisName == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "Axis按键配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AxisName", axisName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.SetDefaultConfigAxisKeys(axisName, axisMappingConfigByAxisName.Value, bindingType);
		}

		// Token: 0x0604560E RID: 284174 RVA: 0x01223330 File Offset: 0x01221530
		public unsafe void ResetCombinationActionKeyByName(string actionName, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType, EInputBindingType bindingType)
		{
			List<List<string>> list = new List<List<string>>();
			IList<IList<string>> list2;
			if (this.CombinationActionKeyMap.TryGetValue(actionName, out list2) && list2 != null)
			{
				foreach (IList<string> list3 in list2)
				{
					List<List<string>> list4 = list;
					int num = 2;
					List<string> list5 = new List<string>(num);
					CollectionsMarshal.SetCount<string>(list5, num);
					Span<string> span = CollectionsMarshal.AsSpan<string>(list5);
					int num2 = 0;
					*span[num2] = list3[0];
					num2++;
					*span[num2] = list3[1];
					List<string> list6 = list5;
					list4.AddRange(new ReadOnlySpan<List<string>>(ref list6));
				}
			}
			foreach (List<string> list7 in list)
			{
				string mainKeyName = list7[0];
				string secondaryKeyName = list7[1];
				this.RemoveCombinationActionKeyMap(actionName, mainKeyName, secondaryKeyName, bindingType);
			}
			if (!this.IsOriginalCombinationActionName(actionName, inputControllerType))
			{
				return;
			}
			CombinationAction? combinationActionConfigByActionName = ConfigBase<InputSettingsConfig>.Instance.GetCombinationActionConfigByActionName(actionName);
			if (combinationActionConfigByActionName == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "组合Action按键配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActionName", actionName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			HashSet<string> keyboardOriginalCombinationActionNameSet;
			this.OriginalCombinationActionNameMap.TryGetValue(CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard, out keyboardOriginalCombinationActionNameSet);
			HashSet<string> gamepadOriginalCombinationActionNameSet;
			this.OriginalCombinationActionNameMap.TryGetValue(CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad, out gamepadOriginalCombinationActionNameSet);
			this.SetDefaultConfigCombinationActionKeys(combinationActionConfigByActionName.Value, keyboardOriginalCombinationActionNameSet, gamepadOriginalCombinationActionNameSet, bindingType);
		}

		// Token: 0x0604560F RID: 284175 RVA: 0x012234B8 File Offset: 0x012216B8
		public EInputBindingType GetBindTypeByExclusiveType(EKeySettingExclusiveType exclusiveType)
		{
			EInputBindingType result;
			if (!this.ExclusiveTypeToBindingTypeMap.TryGetValue(exclusiveType, out result))
			{
				return EInputBindingType.Original;
			}
			return result;
		}

		// Token: 0x06045610 RID: 284176 RVA: 0x012234D8 File Offset: 0x012216D8
		public EKeySettingExclusiveType GetExclusiveTypeByBindingType(EInputBindingType bindingType)
		{
			foreach (KeyValuePair<EKeySettingExclusiveType, EInputBindingType> keyValuePair in this.ExclusiveTypeToBindingTypeMap)
			{
				if (keyValuePair.Value == bindingType)
				{
					return keyValuePair.Key;
				}
			}
			return EKeySettingExclusiveType.None;
		}

		// Token: 0x06045611 RID: 284177 RVA: 0x0122353C File Offset: 0x0122173C
		[return: Nullable(2)]
		public InputActionBinding GetActionBinding(string actionName)
		{
			return this.ActionMapping.GetActionBinding(actionName);
		}

		// Token: 0x06045612 RID: 284178 RVA: 0x0122354A File Offset: 0x0122174A
		public IReadOnlyDictionary<string, InputActionBinding> GetActionBindingMap()
		{
			return this.ActionMapping.GetActionBindingMap();
		}

		// Token: 0x06045613 RID: 284179 RVA: 0x01223557 File Offset: 0x01221757
		[NullableContext(2)]
		public InputActionBinding GetActionBindingByConfigId(int configId)
		{
			return this.ActionMapping.GetActionBindingByConfigId(configId);
		}

		// Token: 0x06045614 RID: 284180 RVA: 0x01223568 File Offset: 0x01221768
		[return: Nullable(2)]
		public unsafe string CheckGetActionKeyIconPath(InputActionBinding actionBinding)
		{
			InputKey currentPlatformKey = actionBinding.GetCurrentPlatformKey();
			if (currentPlatformKey == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "Action找不到对应按键";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionName", actionBinding.GetActionName());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("KeyName", null);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return null;
			}
			string keyIconPath = currentPlatformKey.GetKeyIconPath();
			if (string.IsNullOrEmpty(keyIconPath))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.InputSettings;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "此按键配置了空的图标路径";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("KeyName", currentPlatformKey.GetKeyName());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return keyIconPath;
		}

		// Token: 0x06045615 RID: 284181 RVA: 0x01223617 File Offset: 0x01221817
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public IReadOnlySet<InputActionBinding> GetActionBindingByActionMappingType(EActionMappingType actionMappingType)
		{
			return this.ActionMapping.GetActionBindingByActionMappingType(actionMappingType);
		}

		// Token: 0x06045616 RID: 284182 RVA: 0x01223628 File Offset: 0x01221828
		public void SetActionKeysByBindingType(string actionName, List<string> keys, EInputBindingType bindingType)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "设置Action按键";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", actionName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.ActionMapping.SetKeys(actionName, keys, bindingType);
		}

		// Token: 0x06045617 RID: 284183 RVA: 0x0122366C File Offset: 0x0122186C
		public void SetActionKeys(string actionName, List<string> keys)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "设置Action按键";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", actionName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			InputActionBinding actionBinding = this.ActionMapping.GetActionBinding(actionName);
			if (actionBinding == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.InputSettings;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "设置Action按键时，找不到对应Action";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("actionName", actionName);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			this.ActionMapping.SetKeys(actionName, keys, actionBinding.CurrentBindingType);
		}

		// Token: 0x06045618 RID: 284184 RVA: 0x012236EC File Offset: 0x012218EC
		public void RefreshActionKeys(string actionName, TArray<FInputActionKeyMapping> actionMappings, EInputBindingType bindingType)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "刷新Action按键";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", actionName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.ActionMapping.RefreshKeysByActionMappings(actionName, actionMappings, bindingType);
		}

		// Token: 0x06045619 RID: 284185 RVA: 0x0122372E File Offset: 0x0122192E
		[return: Nullable(2)]
		public InputAxisBinding GetAxisBinding(string axisName)
		{
			return this.AxisMapping.GetAxisBinding(axisName);
		}

		// Token: 0x0604561A RID: 284186 RVA: 0x0122373C File Offset: 0x0122193C
		public IReadOnlyDictionary<string, InputAxisBinding> GetAxisBindingMap()
		{
			return this.AxisMapping.GetAxisBindingMap();
		}

		// Token: 0x0604561B RID: 284187 RVA: 0x01223749 File Offset: 0x01221949
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public IReadOnlySet<InputAxisBinding> GetAxisBindingByAxisMappingType(EAxisMappingType axisMappingType)
		{
			return this.AxisMapping.GetAxisBindingByAxisMappingType(axisMappingType);
		}

		// Token: 0x0604561C RID: 284188 RVA: 0x01223758 File Offset: 0x01221958
		[return: Nullable(2)]
		public unsafe string CheckGetAxisKeyIconPath(InputAxisBinding axisBinding)
		{
			InputAxisKey currentPlatformKey = axisBinding.GetCurrentPlatformKey();
			if (currentPlatformKey == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "Axis找不到对应按键";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AxisName", axisBinding.GetAxisName());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("KeyName", null);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return null;
			}
			string keyIconPath = currentPlatformKey.GetKeyIconPath();
			if (string.IsNullOrEmpty(keyIconPath))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.InputSettings;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "此按键配置了空的图标路径";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("KeyName", currentPlatformKey.KeyName);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return keyIconPath;
		}

		// Token: 0x0604561D RID: 284189 RVA: 0x01223808 File Offset: 0x01221A08
		[return: TupleElementNames(new string[]
		{
			"IsContain",
			"ContainAxisBinding"
		})]
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public ValueTuple<bool, InputAxisBinding> ContainAxisKeyByType(EAxisMappingType axisMappingType, string keyName)
		{
			IReadOnlySet<InputAxisBinding> axisBindingByAxisMappingType = this.AxisMapping.GetAxisBindingByAxisMappingType(axisMappingType);
			if (axisBindingByAxisMappingType != null)
			{
				foreach (InputAxisBinding inputAxisBinding in axisBindingByAxisMappingType)
				{
					if (inputAxisBinding.HasKey(keyName))
					{
						return new ValueTuple<bool, InputAxisBinding>(true, inputAxisBinding);
					}
				}
			}
			return new ValueTuple<bool, InputAxisBinding>(false, null);
		}

		// Token: 0x0604561E RID: 284190 RVA: 0x01223878 File Offset: 0x01221A78
		public void SetAxisKeys(string axisName, Dictionary<string, float> keyScaleMap, EInputBindingType bindingType)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "设置Axis按键";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("axisName", axisName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.AxisMapping.SetKeys(axisName, keyScaleMap, bindingType);
		}

		// Token: 0x0604561F RID: 284191 RVA: 0x012238BC File Offset: 0x01221ABC
		public void RefreshAxisKeys(string axisName, TArray<FInputAxisKeyMapping> axisMappings, EInputBindingType bindingType)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "刷新Axis按键";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("axisName", axisName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.AxisMapping.RefreshKeys(axisName, axisMappings, bindingType);
		}

		// Token: 0x06045620 RID: 284192 RVA: 0x012238FE File Offset: 0x01221AFE
		public void RefreshCombinationActionKeys()
		{
			this.ClearCombinationActionKeyMap();
			this.CombinationActionKeyMap.Clear();
			this.SetCombinationActionKeyMapDirty();
			this.RefreshCombinationActionFromConfig();
		}

		// Token: 0x06045621 RID: 284193 RVA: 0x01223920 File Offset: 0x01221B20
		private void RefreshCombinationActionFromConfig()
		{
			this.OriginalCombinationActionNameMap.Clear();
			IReadOnlyList<CombinationAction> allCombinationActionConfig = ConfigBase<InputSettingsConfig>.Instance.GetAllCombinationActionConfig();
			if (allCombinationActionConfig == null)
			{
				return;
			}
			this.OriginalCombinationActionNameSet.Clear();
			foreach (CombinationAction combinationAction in allCombinationActionConfig)
			{
				this.OriginalCombinationActionNameSet.Add(combinationAction.ActionName);
			}
			HashSet<string> hashSet = new HashSet<string>();
			HashSet<string> hashSet2 = new HashSet<string>();
			foreach (CombinationAction combinationActionConfig in allCombinationActionConfig)
			{
				int exclusiveType = combinationActionConfig.ExclusiveType;
				this.SetDefaultConfigCombinationActionKeys(combinationActionConfig, hashSet, hashSet2, (EInputBindingType)exclusiveType);
			}
			this.OriginalCombinationActionNameMap[CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard] = hashSet;
			this.OriginalCombinationActionNameMap[CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad] = hashSet2;
		}

		// Token: 0x06045622 RID: 284194 RVA: 0x01223A08 File Offset: 0x01221C08
		private void SetDefaultConfigCombinationActionKeys(CombinationAction combinationActionConfig, HashSet<string> keyboardOriginalCombinationActionNameSet, HashSet<string> gamepadOriginalCombinationActionNameSet, EInputBindingType bindingType)
		{
			string actionName = combinationActionConfig.ActionName;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.CheckUseFrenchKeyboard)
			{
				dictionary = combinationActionConfig.FrancePcKeys();
			}
			else
			{
				LanguageKeyTransBase keyTrans = LanguageKeyTransUtils.GetKeyTrans(this.CurrentDeviceLang);
				if (keyTrans != null)
				{
					dictionary = keyTrans.GetCombinationActionPcKeys(combinationActionConfig);
				}
			}
			foreach (KeyValuePair<string, string> keyValuePair in dictionary)
			{
				string text;
				string text2;
				keyValuePair.Deconstruct(out text, out text2);
				string mainKeyName = text;
				string secondaryKeyName = text2;
				InputCombinationActionBinding inputCombinationActionBinding = this.AddCombinationActionKeyMap(actionName, mainKeyName, secondaryKeyName, bindingType);
				Dictionary<EKeySettingExclusiveType, int> dictionary2 = new Dictionary<EKeySettingExclusiveType, int>();
				for (int i = 0; i < combinationActionConfig.KeyboardVersionMapLength; i++)
				{
					DicIntInt? dicIntInt = combinationActionConfig.KeyboardVersionMap(i);
					EKeySettingExclusiveType key = (EKeySettingExclusiveType)dicIntInt.Value.Key;
					dictionary2.Add(key, dicIntInt.Value.Value);
				}
				if (inputCombinationActionBinding != null)
				{
					inputCombinationActionBinding.SetKeyboardVersionMap(dictionary2);
				}
				keyboardOriginalCombinationActionNameSet.Add(actionName);
			}
			if (combinationActionConfig.GamepadKeysLength > 0)
			{
				for (int j = 0; j < combinationActionConfig.GamepadKeysLength; j++)
				{
					DicStringString? dicStringString = combinationActionConfig.GamepadKeys(j);
					string key2 = dicStringString.Value.Key;
					string value = dicStringString.Value.Value;
					InputCombinationActionBinding inputCombinationActionBinding2 = this.AddCombinationActionKeyMap(actionName, key2, value, bindingType);
					Dictionary<EKeySettingExclusiveType, int> dictionary3 = new Dictionary<EKeySettingExclusiveType, int>();
					for (int k = 0; k < combinationActionConfig.GamepadVersionMapLength; k++)
					{
						DicIntInt? dicIntInt2 = combinationActionConfig.GamepadVersionMap(k);
						EKeySettingExclusiveType key3 = (EKeySettingExclusiveType)dicIntInt2.Value.Key;
						dictionary3.Add(key3, dicIntInt2.Value.Value);
					}
					if (inputCombinationActionBinding2 != null)
					{
						inputCombinationActionBinding2.SetGamepadVersionMap(dictionary3);
					}
					gamepadOriginalCombinationActionNameSet.Add(actionName);
				}
			}
		}

		// Token: 0x06045623 RID: 284195 RVA: 0x01223BE8 File Offset: 0x01221DE8
		[return: Nullable(2)]
		public InputCombinationActionBinding SetCombinationActionKeyboardKeys(string actionName, Dictionary<string, string> keyNameMap, EInputBindingType bindingType)
		{
			InputCombinationActionBinding combinationActionBindingByActionName = this.GetCombinationActionBindingByActionName(actionName);
			if (combinationActionBindingByActionName == null)
			{
				return null;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			combinationActionBindingByActionName.GetPcKeyNameMap(dictionary, bindingType);
			foreach (KeyValuePair<string, string> keyValuePair in dictionary)
			{
				string key = keyValuePair.Key;
				string value = keyValuePair.Value;
				this.RemoveCombinationActionKeyMap(actionName, key, value, bindingType);
			}
			foreach (KeyValuePair<string, string> keyValuePair2 in keyNameMap)
			{
				string key2 = keyValuePair2.Key;
				string value2 = keyValuePair2.Value;
				this.AddCombinationActionKeyMap(actionName, key2, value2, bindingType);
			}
			return combinationActionBindingByActionName;
		}

		// Token: 0x06045624 RID: 284196 RVA: 0x01223CC0 File Offset: 0x01221EC0
		[return: Nullable(2)]
		public InputCombinationActionBinding SetOrAddCombinationActionKeyboardKeys(string actionName, [Nullable(new byte[]
		{
			2,
			1,
			1
		})] IReadOnlyDictionary<string, string> keyNameMap, EInputBindingType bindingType)
		{
			InputCombinationActionBinding combinationActionBindingByActionName = this.GetCombinationActionBindingByActionName(actionName);
			if (combinationActionBindingByActionName != null)
			{
				IReadOnlyDictionary<string, string> pcKeyNameMap = combinationActionBindingByActionName.GetPcKeyNameMap(bindingType);
				if (pcKeyNameMap != null)
				{
					foreach (KeyValuePair<string, string> keyValuePair in pcKeyNameMap)
					{
						string text;
						string text2;
						keyValuePair.Deconstruct(out text, out text2);
						string mainKeyName = text;
						string secondaryKeyName = text2;
						this.RemoveCombinationActionKeyMap(actionName, mainKeyName, secondaryKeyName, bindingType);
					}
				}
			}
			if (keyNameMap != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair2 in keyNameMap)
				{
					string key = keyValuePair2.Key;
					string value = keyValuePair2.Value;
					this.AddCombinationActionKeyMap(actionName, key, value, bindingType);
				}
			}
			return combinationActionBindingByActionName;
		}

		// Token: 0x06045625 RID: 284197 RVA: 0x01223D8C File Offset: 0x01221F8C
		[return: Nullable(2)]
		public InputCombinationActionBinding SetCombinationActionGamepadKeys(string actionName, Dictionary<string, string> keyNameMap, EInputBindingType bindingType)
		{
			InputCombinationActionBinding combinationActionBindingByActionName = this.GetCombinationActionBindingByActionName(actionName);
			if (combinationActionBindingByActionName == null)
			{
				return null;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			combinationActionBindingByActionName.GetGamepadKeyNameMapByBindingType(dictionary, bindingType);
			foreach (KeyValuePair<string, string> keyValuePair in dictionary)
			{
				string key = keyValuePair.Key;
				string value = keyValuePair.Value;
				this.RemoveCombinationActionKeyMap(actionName, key, value, bindingType);
			}
			if (keyNameMap.Count > 0)
			{
				using (Dictionary<string, string>.Enumerator enumerator = keyNameMap.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<string, string> keyValuePair2 = enumerator.Current;
						string key2 = keyValuePair2.Key;
						string value2 = keyValuePair2.Value;
						this.AddCombinationActionKeyMap(actionName, key2, value2, bindingType);
					}
					return combinationActionBindingByActionName;
				}
			}
			this.AddCombinationActionKeyMapEmptyData(actionName, bindingType);
			return combinationActionBindingByActionName;
		}

		// Token: 0x06045626 RID: 284198 RVA: 0x01223E74 File Offset: 0x01222074
		[return: Nullable(2)]
		public InputCombinationActionBinding SetOrAddCombinationActionGamepadKeys(string actionName, [Nullable(new byte[]
		{
			2,
			1,
			1
		})] IReadOnlyDictionary<string, string> keyNameMap, EInputBindingType bindingType)
		{
			InputCombinationActionBinding combinationActionBindingByActionName = this.GetCombinationActionBindingByActionName(actionName);
			if (combinationActionBindingByActionName != null)
			{
				IReadOnlyDictionary<string, string> gamepadKeyNameMapByBindingType = combinationActionBindingByActionName.GetGamepadKeyNameMapByBindingType(bindingType);
				if (gamepadKeyNameMapByBindingType != null)
				{
					foreach (KeyValuePair<string, string> keyValuePair in gamepadKeyNameMapByBindingType)
					{
						string text;
						string text2;
						keyValuePair.Deconstruct(out text, out text2);
						string mainKeyName = text;
						string secondaryKeyName = text2;
						this.RemoveCombinationActionKeyMap(actionName, mainKeyName, secondaryKeyName, bindingType);
					}
				}
			}
			if (keyNameMap != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in keyNameMap)
				{
					string text;
					string text2;
					keyValuePair.Deconstruct(out text2, out text);
					string mainKeyName2 = text2;
					string secondaryKeyName2 = text;
					this.AddCombinationActionKeyMap(actionName, mainKeyName2, secondaryKeyName2, bindingType);
				}
			}
			return combinationActionBindingByActionName;
		}

		// Token: 0x06045627 RID: 284199 RVA: 0x01223F40 File Offset: 0x01222140
		public void ConvertInputActionSort()
		{
			bool? flag = new bool?(LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.IsConvertInputActionSort, false));
			if (flag.GetValueOrDefault())
			{
				return;
			}
			if (this.ActionMapping == null)
			{
				return;
			}
			foreach (InputActionBinding inputActionBinding in ((IReadOnlyDictionary<string, InputActionBinding>)this.ActionMapping.GetActionBindingMap()).Values)
			{
				inputActionBinding.ConvertSort();
			}
			Singleton<InputSettings>.Instance.SaveKeyMappings();
			LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.IsConvertInputActionSort, true);
		}

		// Token: 0x06045628 RID: 284200 RVA: 0x01223FCC File Offset: 0x012221CC
		private void ConvertPhantomInput()
		{
			bool? flag = new bool?(LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.IsConvertInput, false));
			if (!flag.GetValueOrDefault())
			{
				this.ConvertPhantomInputInternal();
				LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.IsConvertInput, true);
			}
		}

		// Token: 0x06045629 RID: 284201 RVA: 0x01224000 File Offset: 0x01222200
		private void TryFirstSaveKeyMappings()
		{
			bool? flag = new bool?(LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.IsSavedKeyMappings, false));
			if (flag.GetValueOrDefault())
			{
				return;
			}
			Singleton<InputSettings>.Instance.SaveKeyMappings();
			LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.IsSavedKeyMappings, true);
		}

		// Token: 0x0604562A RID: 284202 RVA: 0x0122403C File Offset: 0x0122223C
		private void ConvertPhantomInputInternal()
		{
			InputActionBinding actionBinding = this.GetActionBinding("幻象2");
			if (actionBinding == null)
			{
				return;
			}
			if (actionBinding.HasKey(EKey.Gamepad_LeftTrigger))
			{
				InputCombinationActionBinding combinationActionBindingByActionName = this.GetCombinationActionBindingByActionName("幻象2");
				if (combinationActionBindingByActionName == null)
				{
					return;
				}
				if (combinationActionBindingByActionName.HasKey(EKey.Gamepad_LeftShoulder, EKey.Gamepad_FaceButton_Left, EInputBindingType.Original))
				{
					InputActionBinding inputActionBinding = actionBinding;
					string text = EKey.Gamepad_LeftTrigger;
					inputActionBinding.RemoveKeys(new Span<string>(ref text), EInputBindingType.Original);
					InputActionBinding actionBinding2 = this.GetActionBinding("瞄准");
					if (actionBinding2 != null && !actionBinding2.HasKey(EKey.Gamepad_LeftTrigger))
					{
						InputActionBinding inputActionBinding2 = actionBinding2;
						string text2 = EKey.Gamepad_LeftTrigger;
						inputActionBinding2.AddKeys(new Span<string>(ref text2), EInputBindingType.Original);
					}
					InputCombinationActionBinding combinationActionBindingByActionName2 = this.GetCombinationActionBindingByActionName("瞄准");
					if (combinationActionBindingByActionName2 != null)
					{
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						combinationActionBindingByActionName2.GetGamepadKeyNameMapByBindingType(dictionary, EInputBindingType.Original);
						string a;
						if (dictionary.TryGetValue(EKey.Gamepad_LeftShoulder, out a) && a == EKey.Gamepad_FaceButton_Left)
						{
							combinationActionBindingByActionName2.RemoveKey(EKey.Gamepad_LeftShoulder, EInputBindingType.Original);
						}
					}
				}
			}
		}

		// Token: 0x0604562B RID: 284203 RVA: 0x01224154 File Offset: 0x01222354
		public void ClearCombinationActionKeyMap()
		{
			foreach (KeyValuePair<string, IList<IList<string>>> keyValuePair in new Dictionary<string, IList<IList<string>>>(this.CombinationActionKeyMap))
			{
				string key = keyValuePair.Key;
				List<IList<string>> list = new List<IList<string>>(keyValuePair.Value);
				InputCombinationActionBinding combinationActionBindingByActionName = this.GetCombinationActionBindingByActionName(key);
				if (combinationActionBindingByActionName != null)
				{
					foreach (IList<string> list2 in list)
					{
						this.RemoveCombinationActionKeyMap(key, list2[0], list2[1], combinationActionBindingByActionName.CurrentBindingType);
					}
				}
			}
			InputCombinationActionMapping combinationActionMapping = this.CombinationActionMapping;
			if (combinationActionMapping != null)
			{
				combinationActionMapping.Clear();
			}
			this.CombinationActionKeyMap.Clear();
		}

		// Token: 0x0604562C RID: 284204 RVA: 0x0122423C File Offset: 0x0122243C
		[return: Nullable(2)]
		public InputCombinationActionBinding AddCombinationActionKeyMap(string actionName, string mainKeyName, string secondaryKeyName, EInputBindingType bindingType)
		{
			InputCombinationActionBinding result = this.AddCombinationActionKeyMapInternal(actionName, mainKeyName, secondaryKeyName, bindingType);
			IList<IList<string>> list;
			if (this.CombinationActionKeyMap.TryGetValue(actionName, out list) && list != null)
			{
				string[] item = new string[]
				{
					mainKeyName,
					secondaryKeyName
				};
				bool flag = false;
				foreach (IList<string> list2 in list)
				{
					if (list2[0] == mainKeyName && list2[1] == secondaryKeyName)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(item);
				}
			}
			else
			{
				string[] item2 = new string[]
				{
					mainKeyName,
					secondaryKeyName
				};
				this.CombinationActionKeyMap[actionName] = new List<IList<string>>
				{
					item2
				};
			}
			this.SetCombinationActionKeyMapDirty();
			return result;
		}

		// Token: 0x0604562D RID: 284205 RVA: 0x01224314 File Offset: 0x01222514
		public unsafe void AddCombinationActionKeyMapEmptyData(string actionName, EInputBindingType bindingType)
		{
			InputCombinationActionBinding inputCombinationActionBinding = this.TryGetCombinationActionBinding(actionName);
			if (inputCombinationActionBinding == null)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "添加组合键按键空数据";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionName", actionName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("bindingType", bindingType);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			inputCombinationActionBinding.AddKeyEmptyData(bindingType);
			this.SetCombinationActionKeyMapDirty();
		}

		// Token: 0x0604562E RID: 284206 RVA: 0x01224394 File Offset: 0x01222594
		[return: Nullable(2)]
		private unsafe InputCombinationActionBinding ReplaceCombinationActionKeyMapInternal(string actionName, string mainKeyName, string secondaryKeyName, EInputBindingType bindingType)
		{
			InputCombinationActionBinding inputCombinationActionBinding = this.TryGetCombinationActionBinding(actionName);
			if (inputCombinationActionBinding == null)
			{
				return null;
			}
			string secondaryKeyNameByMainKey = inputCombinationActionBinding.GetSecondaryKeyNameByMainKey(mainKeyName, bindingType);
			if (!string.IsNullOrEmpty(secondaryKeyNameByMainKey) && secondaryKeyNameByMainKey != secondaryKeyName)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "组合键主键已存在,更换旧的组合键数据";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionName", inputCombinationActionBinding.GetActionName());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("mainKeyName", mainKeyName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("secondaryKeyName", secondaryKeyNameByMainKey);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				this.RemoveCombinationActionKeyMap(actionName, mainKeyName, secondaryKeyNameByMainKey, bindingType);
			}
			return this.AddCombinationActionKeyMapInternal(actionName, mainKeyName, secondaryKeyName, bindingType);
		}

		// Token: 0x0604562F RID: 284207 RVA: 0x01224454 File Offset: 0x01222654
		[return: Nullable(2)]
		private unsafe InputCombinationActionBinding AddCombinationActionKeyMapInternal(string actionName, string mainKeyName, string secondaryKeyName, EInputBindingType bindingType)
		{
			InputCombinationActionBinding inputCombinationActionBinding = this.TryGetCombinationActionBinding(actionName);
			if (inputCombinationActionBinding == null)
			{
				return null;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "添加组合键按键";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionName", inputCombinationActionBinding.GetActionName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("mainKeyName", mainKeyName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("secondaryKeyName", secondaryKeyName);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			InputCombinationActionMapping combinationActionMapping = this.CombinationActionMapping;
			if (combinationActionMapping != null)
			{
				combinationActionMapping.AddKey(inputCombinationActionBinding, mainKeyName, secondaryKeyName, bindingType);
			}
			Singleton<InputSettings>.Instance.NewInputCombinationActionKey(inputCombinationActionBinding.GetActionName(), mainKeyName, secondaryKeyName);
			return inputCombinationActionBinding;
		}

		// Token: 0x06045630 RID: 284208 RVA: 0x01224508 File Offset: 0x01222708
		public InputCombinationActionBinding TryGetCombinationActionBinding(string actionName)
		{
			InputCombinationActionBinding inputCombinationActionBinding = this.GetCombinationActionBindingByActionName(actionName);
			if (inputCombinationActionBinding == null)
			{
				bool flag = this.OriginalCombinationActionNameSet.Contains(actionName);
				bool flag2 = this.OriginalActionNameSet.Contains(actionName);
				inputCombinationActionBinding = this.CombinationActionMapping.NewCombinationActionBinding(actionName, 0, flag || !flag2);
				inputCombinationActionBinding.InitializeBindingType(this.CurrentBindingType);
			}
			return inputCombinationActionBinding;
		}

		// Token: 0x06045631 RID: 284209 RVA: 0x01224560 File Offset: 0x01222760
		public void RemoveCombinationActionKeyMap(string actionName, string mainKeyName, string secondaryKeyName, EInputBindingType bindingType)
		{
			this.RemoveCombinationActionKeyInternal(actionName, mainKeyName, secondaryKeyName, bindingType);
			IList<IList<string>> list;
			if (this.CombinationActionKeyMap.TryGetValue(actionName, out list) && list != null)
			{
				List<int> list2 = new List<int>();
				for (int i = 0; i < list.Count; i++)
				{
					IList<string> list3 = list[i];
					if (list3[0] == mainKeyName && list3[1] == secondaryKeyName)
					{
						list2.Add(i);
					}
				}
				for (int j = list2.Count - 1; j >= 0; j--)
				{
					int index = list2[j];
					list.RemoveAt(index);
				}
				if (list.Count <= 0)
				{
					this.CombinationActionKeyMap.Remove(actionName);
				}
			}
			else
			{
				this.CombinationActionKeyMap.Remove(actionName);
			}
			this.SetCombinationActionKeyMapDirty();
		}

		// Token: 0x06045632 RID: 284210 RVA: 0x0122462C File Offset: 0x0122282C
		private unsafe void RemoveCombinationActionKeyInternal(string actionName, string mainKeyName, string secondaryKeyName, EInputBindingType bindingType)
		{
			InputCombinationActionBinding combinationActionBindingByActionName = this.GetCombinationActionBindingByActionName(actionName);
			if (combinationActionBindingByActionName == null)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "删除组合键按键";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionName", combinationActionBindingByActionName.GetActionName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RemoveMainKey", mainKeyName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("RemoveSecondaryKeyName", secondaryKeyName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("bindingType", bindingType);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			InputCombinationActionMapping combinationActionMapping = this.CombinationActionMapping;
			if (combinationActionMapping != null)
			{
				combinationActionMapping.RemoveKey(combinationActionBindingByActionName, mainKeyName, secondaryKeyName, bindingType);
			}
			Singleton<InputSettings>.Instance.RemoveCombinationActionMapping(combinationActionBindingByActionName.GetActionName(), mainKeyName, secondaryKeyName);
		}

		// Token: 0x06045633 RID: 284211 RVA: 0x012246FB File Offset: 0x012228FB
		[return: Nullable(2)]
		public InputCombinationAxisBinding AddCombinationAxisKeyMap(string axisName, string secondaryKeyName, string mainKeyName, EInputBindingType bindingType)
		{
			return this.AddCombinationAxisKeyMapInternal(axisName, secondaryKeyName, mainKeyName, bindingType);
		}

		// Token: 0x06045634 RID: 284212 RVA: 0x01224708 File Offset: 0x01222908
		[return: Nullable(2)]
		private unsafe InputCombinationAxisBinding AddCombinationAxisKeyMapInternal(string axisName, string secondaryKeyName, string mainKeyName, EInputBindingType bindingType)
		{
			InputCombinationAxisBinding combinationAxisBindingByAxisName = this.GetCombinationAxisBindingByAxisName(axisName);
			if (combinationAxisBindingByAxisName == null)
			{
				return null;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "添加组合键按键";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AxisName", axisName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("mainKeyName", mainKeyName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("secondaryKeyName", secondaryKeyName);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			InputCombinationAxisMapping combinationAxisMapping = this.CombinationAxisMapping;
			if (combinationAxisMapping != null)
			{
				combinationAxisMapping.AddKeyMap(combinationAxisBindingByAxisName, secondaryKeyName, mainKeyName, bindingType);
			}
			Singleton<InputSettings>.Instance.NewInputCombinationActionKey(axisName, mainKeyName, secondaryKeyName);
			return combinationAxisBindingByAxisName;
		}

		// Token: 0x06045635 RID: 284213 RVA: 0x012247B1 File Offset: 0x012229B1
		public void RemoveCombinationAxisKeyMap(string axisName, string secondaryKeyName, string mainKeyName, EInputBindingType bindingType)
		{
			this.RemoveCombinationAxisKeyInternal(axisName, secondaryKeyName, mainKeyName, bindingType);
		}

		// Token: 0x06045636 RID: 284214 RVA: 0x012247C0 File Offset: 0x012229C0
		private unsafe void RemoveCombinationAxisKeyInternal(string axisName, string secondaryKeyName, string mainKeyName, EInputBindingType bindingType)
		{
			InputCombinationAxisBinding combinationAxisBindingByAxisName = this.GetCombinationAxisBindingByAxisName(axisName);
			if (combinationAxisBindingByAxisName == null)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "删除组合键按键";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AxisName", axisName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RemoveMainKey", mainKeyName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("RemoveSecondaryKeyName", secondaryKeyName);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			InputCombinationAxisMapping combinationAxisMapping = this.CombinationAxisMapping;
			if (combinationAxisMapping != null)
			{
				combinationAxisMapping.RemoveKeyMap(combinationAxisBindingByAxisName, secondaryKeyName, mainKeyName, bindingType);
			}
			Singleton<InputSettings>.Instance.RemoveCombinationAxisMapping(axisName, mainKeyName, secondaryKeyName);
		}

		// Token: 0x06045637 RID: 284215 RVA: 0x01224868 File Offset: 0x01222A68
		private void InitKeySettingActionKey(InputActionBinding actionBinding, KeySetting config)
		{
			string actionName = actionBinding.GetActionName();
			ActionMapping? actionMappingConfigByActionName = ConfigBase<InputSettingsConfig>.Instance.GetActionMappingConfigByActionName(actionName);
			if (actionMappingConfigByActionName == null)
			{
				return;
			}
			EInputBindingType bindTypeByExclusiveType = this.GetBindTypeByExclusiveType((EKeySettingExclusiveType)config.ExclusiveType);
			CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType = (CSharpScript.Game.Module.Menu.EInputControllerType)config.InputControllerType;
			if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard || inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.None)
			{
				string[] actionPcKeys = LanguageKeyTransUtils.GetKeyTrans(this.CurrentDeviceLang).GetActionPcKeys(actionMappingConfigByActionName.Value);
				if (bindTypeByExclusiveType == EInputBindingType.Original)
				{
					actionBinding.SetKeyboardKeysWithoutOriginal(actionPcKeys);
				}
				else
				{
					actionBinding.SetKeyboardKeys(actionPcKeys, bindTypeByExclusiveType);
				}
			}
			if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad || inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.None)
			{
				List<string> list = new List<string>();
				for (int i = 0; i < actionMappingConfigByActionName.Value.GamepadKeysLength; i++)
				{
					string text = actionMappingConfigByActionName.Value.GamepadKeys(i);
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(text);
					}
				}
				if (list.Count > 0)
				{
					if (bindTypeByExclusiveType == EInputBindingType.Original)
					{
						actionBinding.SetGamepadKeysWithoutOriginal(list);
						return;
					}
					actionBinding.SetGamepadKeys(list, bindTypeByExclusiveType);
				}
			}
		}

		// Token: 0x06045638 RID: 284216 RVA: 0x01224950 File Offset: 0x01222B50
		private void InitKeySettingAxisKey(InputAxisBinding axisBinding, KeySetting config)
		{
			string axisName = axisBinding.GetAxisName();
			AxisMapping? axisMappingConfigByAxisName = ConfigBase<InputSettingsConfig>.Instance.GetAxisMappingConfigByAxisName(axisName);
			if (axisMappingConfigByAxisName == null)
			{
				return;
			}
			EInputBindingType bindTypeByExclusiveType = this.GetBindTypeByExclusiveType((EKeySettingExclusiveType)config.ExclusiveType);
			CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType = (CSharpScript.Game.Module.Menu.EInputControllerType)config.InputControllerType;
			if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard || inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.None)
			{
				Dictionary<string, float> axisPcKeys = LanguageKeyTransUtils.GetKeyTrans(this.CurrentDeviceLang).GetAxisPcKeys(axisMappingConfigByAxisName.Value);
				if (bindTypeByExclusiveType == EInputBindingType.Original)
				{
					axisBinding.SetKeyboardKeysWithoutOriginal(axisPcKeys);
				}
				else
				{
					axisBinding.SetKeyboardKeys(axisPcKeys, bindTypeByExclusiveType);
				}
			}
			if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad || inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.None)
			{
				Dictionary<string, float> dictionary = axisMappingConfigByAxisName.Value.GamepadKeys();
				if (dictionary != null)
				{
					if (bindTypeByExclusiveType == EInputBindingType.Original)
					{
						axisBinding.SetGamepadKeysWithoutOriginal(dictionary);
						return;
					}
					axisBinding.SetGamepadKeys(dictionary, bindTypeByExclusiveType);
				}
			}
		}

		// Token: 0x06045639 RID: 284217 RVA: 0x012249F8 File Offset: 0x01222BF8
		private void InitCombinationActionKeysWithBindingType(InputCombinationActionBinding combinationActionBinding, EInputBindingType bindingType, Dictionary<string, string> keyNameMap, bool isGamepad)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string actionName = combinationActionBinding.GetActionName();
			if (isGamepad)
			{
				combinationActionBinding.GetGamepadKeyNameMapByBindingType(dictionary, bindingType);
			}
			else
			{
				combinationActionBinding.GetPcKeyNameMap(dictionary, bindingType);
			}
			foreach (KeyValuePair<string, string> keyValuePair in dictionary)
			{
				string key = keyValuePair.Key;
				string value = keyValuePair.Value;
				this.RemoveCombinationActionKeyMap(actionName, key, value, bindingType);
			}
			foreach (KeyValuePair<string, string> keyValuePair2 in keyNameMap)
			{
				string key2 = keyValuePair2.Key;
				string value2 = keyValuePair2.Value;
				this.AddCombinationActionKeyMap(actionName, key2, value2, bindingType);
			}
		}

		// Token: 0x0604563A RID: 284218 RVA: 0x01224AD8 File Offset: 0x01222CD8
		private void InitKeySettingCombinationActionKey(InputCombinationActionBinding combinationActionBinding, KeySetting config)
		{
			string actionName = combinationActionBinding.GetActionName();
			CombinationAction? combinationActionConfigByActionName = ConfigBase<InputSettingsConfig>.Instance.GetCombinationActionConfigByActionName(actionName);
			if (combinationActionConfigByActionName == null)
			{
				return;
			}
			EInputBindingType bindTypeByExclusiveType = this.GetBindTypeByExclusiveType((EKeySettingExclusiveType)config.ExclusiveType);
			CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType = (CSharpScript.Game.Module.Menu.EInputControllerType)config.InputControllerType;
			if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard || inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.None)
			{
				Dictionary<string, string> combinationActionPcKeys = LanguageKeyTransUtils.GetKeyTrans(this.CurrentDeviceLang).GetCombinationActionPcKeys(combinationActionConfigByActionName.Value);
				if (bindTypeByExclusiveType == EInputBindingType.Original)
				{
					foreach (EInputBindingType einputBindingType in InputBindingDefine.inputBindingTypesArray)
					{
						if (einputBindingType != EInputBindingType.Original)
						{
							this.InitCombinationActionKeysWithBindingType(combinationActionBinding, einputBindingType, combinationActionPcKeys, false);
						}
					}
				}
				else
				{
					this.InitCombinationActionKeysWithBindingType(combinationActionBinding, bindTypeByExclusiveType, combinationActionPcKeys, false);
				}
			}
			if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad || inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.None)
			{
				CombinationAction? combinationActionConfigByActionName2 = ConfigBase<InputSettingsConfig>.Instance.GetCombinationActionConfigByActionName(actionName);
				if (combinationActionConfigByActionName2 != null)
				{
					Dictionary<string, string> dictionary = combinationActionConfigByActionName2.Value.GamepadKeys();
					if (dictionary != null)
					{
						if (bindTypeByExclusiveType == EInputBindingType.Original)
						{
							foreach (EInputBindingType einputBindingType2 in InputBindingDefine.inputBindingTypesArray)
							{
								if (einputBindingType2 != EInputBindingType.Original)
								{
									this.InitCombinationActionKeysWithBindingType(combinationActionBinding, einputBindingType2, dictionary, true);
								}
							}
							return;
						}
						this.InitCombinationActionKeysWithBindingType(combinationActionBinding, bindTypeByExclusiveType, dictionary, true);
					}
				}
			}
		}

		// Token: 0x0604563B RID: 284219 RVA: 0x01224BEC File Offset: 0x01222DEC
		private void InitCombinationAxisKeysWithBindingType(InputCombinationAxisBinding combinationAxisBinding, EInputBindingType bindingType, Dictionary<string, string> keyNameMap, bool isGamepad)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string axisName = combinationAxisBinding.GetAxisName();
			if (isGamepad)
			{
				combinationAxisBinding.GetGamepadKeyNameMap(dictionary, bindingType);
			}
			else
			{
				combinationAxisBinding.GetPcKeyNameMap(dictionary, bindingType);
			}
			foreach (KeyValuePair<string, string> keyValuePair in dictionary)
			{
				string key = keyValuePair.Key;
				string value = keyValuePair.Value;
				this.RemoveCombinationAxisKeyMap(axisName, key, value, bindingType);
			}
			foreach (KeyValuePair<string, string> keyValuePair2 in keyNameMap)
			{
				string key2 = keyValuePair2.Key;
				string value2 = keyValuePair2.Value;
				this.AddCombinationAxisKeyMap(axisName, key2, value2, bindingType);
			}
		}

		// Token: 0x0604563C RID: 284220 RVA: 0x01224CCC File Offset: 0x01222ECC
		private void InitKeySettingCombinationAxisKey(InputCombinationAxisBinding combinationAxisBinding, KeySetting config)
		{
			string axisName = combinationAxisBinding.GetAxisName();
			CombinationAxis? combinationAxisConfigByAxisName = ConfigBase<InputSettingsConfig>.Instance.GetCombinationAxisConfigByAxisName(axisName);
			if (combinationAxisConfigByAxisName == null)
			{
				return;
			}
			EInputBindingType bindTypeByExclusiveType = this.GetBindTypeByExclusiveType((EKeySettingExclusiveType)config.ExclusiveType);
			CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType = (CSharpScript.Game.Module.Menu.EInputControllerType)config.InputControllerType;
			if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard || inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.None)
			{
				Dictionary<string, string> dictionary = combinationAxisConfigByAxisName.Value.PcKeyMap();
				if (dictionary != null)
				{
					if (bindTypeByExclusiveType == EInputBindingType.Original)
					{
						foreach (EInputBindingType einputBindingType in InputBindingDefine.inputBindingTypesArray)
						{
							if (einputBindingType != EInputBindingType.Original)
							{
								this.InitCombinationAxisKeysWithBindingType(combinationAxisBinding, einputBindingType, dictionary, false);
							}
						}
					}
					else
					{
						this.InitCombinationAxisKeysWithBindingType(combinationAxisBinding, bindTypeByExclusiveType, dictionary, false);
					}
				}
			}
			if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad || inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.None)
			{
				CombinationAxis? combinationAxisConfigByAxisName2 = ConfigBase<InputSettingsConfig>.Instance.GetCombinationAxisConfigByAxisName(axisName);
				if (combinationAxisConfigByAxisName2 != null)
				{
					Dictionary<string, string> dictionary2 = combinationAxisConfigByAxisName2.Value.GamepadKeyMap();
					if (dictionary2 != null)
					{
						if (bindTypeByExclusiveType == EInputBindingType.Original)
						{
							foreach (EInputBindingType einputBindingType2 in InputBindingDefine.inputBindingTypesArray)
							{
								if (einputBindingType2 != EInputBindingType.Original)
								{
									this.InitCombinationAxisKeysWithBindingType(combinationAxisBinding, einputBindingType2, dictionary2, true);
								}
							}
							return;
						}
						this.InitCombinationAxisKeysWithBindingType(combinationAxisBinding, bindTypeByExclusiveType, dictionary2, true);
					}
				}
			}
		}

		// Token: 0x0604563D RID: 284221 RVA: 0x01224DE0 File Offset: 0x01222FE0
		private void AddActionNameToInputControllerMap(Dictionary<CSharpScript.Game.Module.Menu.EInputControllerType, HashSet<string>> inputControllerMap, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType, string actionName)
		{
			HashSet<string> hashSet;
			inputControllerMap.TryGetValue(inputControllerType, out hashSet);
			if (hashSet == null)
			{
				hashSet = new HashSet<string>();
				inputControllerMap.Add(inputControllerType, hashSet);
			}
			hashSet.Add(actionName);
		}

		// Token: 0x0604563E RID: 284222 RVA: 0x01224E10 File Offset: 0x01223010
		private void AddInSettingActionName(KeySetting inSettingConfig)
		{
			Dictionary<CSharpScript.Game.Module.Menu.EInputControllerType, HashSet<string>> dictionary;
			this.InSettingActionNameMap.TryGetValue((EKeySettingExclusiveType)inSettingConfig.ExclusiveType, out dictionary);
			if (dictionary == null)
			{
				dictionary = new Dictionary<CSharpScript.Game.Module.Menu.EInputControllerType, HashSet<string>>();
				this.InSettingActionNameMap.Add((EKeySettingExclusiveType)inSettingConfig.ExclusiveType, dictionary);
			}
			if (inSettingConfig.InputControllerType != 0)
			{
				this.AddActionNameToInputControllerMap(dictionary, (CSharpScript.Game.Module.Menu.EInputControllerType)inSettingConfig.InputControllerType, inSettingConfig.ActionOrAxisName);
				return;
			}
			this.AddActionNameToInputControllerMap(dictionary, CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard, inSettingConfig.ActionOrAxisName);
			this.AddActionNameToInputControllerMap(dictionary, CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad, inSettingConfig.ActionOrAxisName);
		}

		// Token: 0x0604563F RID: 284223 RVA: 0x01224E8C File Offset: 0x0122308C
		private void InitKeySettingKeys()
		{
			this.InSettingActionNameMap.Clear();
			IReadOnlyList<KeySetting> configList = ConfigKeySettingAll.GetConfigList(true);
			if (configList != null)
			{
				foreach (KeySetting keySetting in configList)
				{
					string actionOrAxisName = keySetting.ActionOrAxisName;
					if (!StringUtils.IsBlank(actionOrAxisName))
					{
						if (keySetting.ActionOrAxis == 1)
						{
							InputCombinationActionBinding combinationActionBindingByActionName = this.GetCombinationActionBindingByActionName(actionOrAxisName);
							if (combinationActionBindingByActionName != null)
							{
								this.InitKeySettingCombinationActionKey(combinationActionBindingByActionName, keySetting);
							}
							InputActionBinding actionBinding = this.GetActionBinding(actionOrAxisName);
							if (actionBinding != null)
							{
								this.InitKeySettingActionKey(actionBinding, keySetting);
							}
							this.AddInSettingActionName(keySetting);
						}
						else
						{
							InputCombinationAxisBinding combinationAxisBindingByAxisName = this.GetCombinationAxisBindingByAxisName(actionOrAxisName);
							if (combinationAxisBindingByAxisName != null)
							{
								this.InitKeySettingCombinationAxisKey(combinationAxisBindingByAxisName, keySetting);
							}
							InputAxisBinding axisBinding = this.GetAxisBinding(actionOrAxisName);
							if (axisBinding != null)
							{
								this.InitKeySettingAxisKey(axisBinding, keySetting);
							}
						}
					}
				}
			}
		}

		// Token: 0x06045640 RID: 284224 RVA: 0x01224F68 File Offset: 0x01223168
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public IReadOnlyDictionary<string, InputCombinationActionBinding> GetCombinationActionBindingByKeyName(string mainKeyName, string secondaryKeyName)
		{
			return this.CombinationActionMapping.GetCombinationActionBindingByKeyName(mainKeyName, secondaryKeyName);
		}

		// Token: 0x06045641 RID: 284225 RVA: 0x01224F77 File Offset: 0x01223177
		[return: Nullable(2)]
		public InputCombinationActionBinding GetCombinationActionBindingByActionName(string actionName)
		{
			return this.CombinationActionMapping.GetCombinationActionBindingByActionName(actionName);
		}

		// Token: 0x06045642 RID: 284226 RVA: 0x01224F85 File Offset: 0x01223185
		public IReadOnlyDictionary<string, InputCombinationActionBinding> GetCombinationActionBindingMap()
		{
			return this.CombinationActionMapping.GetCombinationActionBindingMap();
		}

		// Token: 0x06045643 RID: 284227 RVA: 0x01224F92 File Offset: 0x01223192
		public bool IsCombinationActionMainKey(string keyName)
		{
			return this.CombinationActionMapping.IsMainKey(keyName);
		}

		// Token: 0x06045644 RID: 284228 RVA: 0x01224FA0 File Offset: 0x012231A0
		public bool IsCombinationAction(string mainKeyName, string secondaryKeyName)
		{
			IReadOnlyDictionary<string, InputCombinationActionBinding> combinationActionBindingByKeyName = this.GetCombinationActionBindingByKeyName(mainKeyName, secondaryKeyName);
			InputModel instance = ModelBase<InputModel>.Instance;
			BattleInputData battleInputData = (instance != null) ? instance.GetCurrentInputData() : null;
			EInputBindingType bindingType = (battleInputData != null) ? battleInputData.KeyBindingType : EInputBindingType.Original;
			if (combinationActionBindingByKeyName == null || combinationActionBindingByKeyName.Count <= 0)
			{
				return false;
			}
			using (IEnumerator<InputCombinationActionBinding> enumerator = combinationActionBindingByKeyName.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HasKey(mainKeyName, secondaryKeyName, bindingType))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06045645 RID: 284229 RVA: 0x01225030 File Offset: 0x01223230
		public void RefreshCombinationAxisKeys()
		{
			IReadOnlyList<CombinationAxis> allCombinationAxisConfig = ConfigBase<InputSettingsConfig>.Instance.GetAllCombinationAxisConfig();
			if (allCombinationAxisConfig == null)
			{
				return;
			}
			foreach (CombinationAxis config in allCombinationAxisConfig)
			{
				InputCombinationAxisMapping combinationAxisMapping = this.CombinationAxisMapping;
				if (combinationAxisMapping != null)
				{
					combinationAxisMapping.NewCombinationAxisBinding(config);
				}
			}
		}

		// Token: 0x06045646 RID: 284230 RVA: 0x01225094 File Offset: 0x01223294
		private void ClearCombinationAxisKeyMap()
		{
			InputCombinationAxisMapping combinationAxisMapping = this.CombinationAxisMapping;
			if (combinationAxisMapping == null)
			{
				return;
			}
			combinationAxisMapping.Clear();
		}

		// Token: 0x06045647 RID: 284231 RVA: 0x012250A6 File Offset: 0x012232A6
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public IReadOnlyList<InputCombinationAxisBinding> GetCombinationAxisBindingByKeyName(string mainKeyName, string secondaryKeyName)
		{
			return this.CombinationAxisMapping.GetCombinationAxisBindingByKeyName(mainKeyName, secondaryKeyName);
		}

		// Token: 0x06045648 RID: 284232 RVA: 0x012250B5 File Offset: 0x012232B5
		[return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public IReadOnlyDictionary<string, List<InputCombinationAxisBinding>> GetCombinationAxisBindingMapByMainKeyName(string mainKeyName)
		{
			return this.CombinationAxisMapping.GetCombinationAxisBindingMapByMainKeyName(mainKeyName);
		}

		// Token: 0x06045649 RID: 284233 RVA: 0x012250C3 File Offset: 0x012232C3
		[return: Nullable(2)]
		public InputCombinationAxisBinding GetCombinationAxisBindingByAxisName(string axisName)
		{
			return this.CombinationAxisMapping.GetCombinationAxisBindingByAxisName(axisName);
		}

		// Token: 0x0604564A RID: 284234 RVA: 0x012250D1 File Offset: 0x012232D1
		public IReadOnlyDictionary<string, InputCombinationAxisBinding> GetCombinationAxisBindingMap()
		{
			return this.CombinationAxisMapping.GetCombinationAxisBindingMap();
		}

		// Token: 0x0604564B RID: 284235 RVA: 0x012250DE File Offset: 0x012232DE
		public bool IsCombinationAxisMainKey(string keyName)
		{
			return this.CombinationAxisMapping.IsMainKey(keyName);
		}

		// Token: 0x0604564C RID: 284236 RVA: 0x012250EC File Offset: 0x012232EC
		public bool IsCombinationAxis(string mainKeyName, string secondaryKeyName)
		{
			IReadOnlyList<InputCombinationAxisBinding> combinationAxisBindingByKeyName = this.GetCombinationAxisBindingByKeyName(mainKeyName, secondaryKeyName);
			return combinationAxisBindingByKeyName != null && combinationAxisBindingByKeyName.Count > 0;
		}

		// Token: 0x0604564D RID: 284237 RVA: 0x01225114 File Offset: 0x01223314
		public bool GetActionKeyDisplayData(InputKeyDisplayData actionKeyDisplayDataRef, string actionName)
		{
			List<string> currentPlatformCustomActionKeyNameList = (Global.PlayerController as TsBasePlayerController).GetCurrentPlatformCustomActionKeyNameList(actionName);
			if (currentPlatformCustomActionKeyNameList != null)
			{
				actionKeyDisplayDataRef.RefreshInput(actionName, currentPlatformCustomActionKeyNameList);
				return true;
			}
			InputCombinationActionBinding combinationActionBindingByActionName = this.GetCombinationActionBindingByActionName(actionName);
			if (combinationActionBindingByActionName != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				combinationActionBindingByActionName.GetCurrentPlatformKeyNameMap(dictionary);
				if (dictionary.Count > 0)
				{
					actionKeyDisplayDataRef.RefreshCombinationInput(actionName, dictionary);
					return true;
				}
			}
			InputActionBinding actionBinding = this.GetActionBinding(actionName);
			if (actionBinding != null)
			{
				IReadOnlyList<string> currentPlatformKeyNameList = actionBinding.GetCurrentPlatformKeyNameList();
				if (currentPlatformKeyNameList.Count > 0)
				{
					actionKeyDisplayDataRef.RefreshInput(actionName, currentPlatformKeyNameList);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0604564E RID: 284238 RVA: 0x01225194 File Offset: 0x01223394
		public bool GetAxisKeyDisplayData(InputKeyDisplayData axisKeyDisplayDataRef, string axisName)
		{
			InputCombinationAxisBinding combinationAxisBindingByAxisName = this.GetCombinationAxisBindingByAxisName(axisName);
			if (combinationAxisBindingByAxisName != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				combinationAxisBindingByAxisName.GetCurrentPlatformKeyNameMap(dictionary);
				if (dictionary != null && dictionary.Count > 0)
				{
					axisKeyDisplayDataRef.RefreshCombinationInput(axisName, dictionary);
					return true;
				}
			}
			InputAxisBinding axisBinding = this.GetAxisBinding(axisName);
			if (axisBinding != null)
			{
				IReadOnlyList<string> currentPlatformKeyNameList = axisBinding.GetCurrentPlatformKeyNameList();
				if (currentPlatformKeyNameList.Count > 0)
				{
					axisKeyDisplayDataRef.RefreshInput(axisName, currentPlatformKeyNameList);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0604564F RID: 284239 RVA: 0x012251F8 File Offset: 0x012233F8
		public void SwitchKeysByBindingType(EInputBindingType bindingType)
		{
			this.CurrentBindingType = bindingType;
			SkillButtonUiGamepadDataBase gamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData != null)
			{
				gamepadData.AddChangeKeyReason(EGamepadChangeKeyReason.SwitchBattleInputData);
			}
			this.CombinationActionMapping.SwitchKeysByBindingType(bindingType);
			this.CombinationAxisMapping.SwitchKeysByBindingType(bindingType);
			this.ActionMapping.SwitchKeysByBindingType(bindingType);
			this.AxisMapping.SwitchKeysByBindingType(bindingType);
			SkillButtonUiGamepadDataBase gamepadData2 = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData2 == null)
			{
				return;
			}
			gamepadData2.RemoveChangeKeyReason(EGamepadChangeKeyReason.SwitchBattleInputData);
		}

		// Token: 0x06045650 RID: 284240 RVA: 0x01225268 File Offset: 0x01223468
		public bool IsOriginalCombinationActionName(string actionName, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
		{
			HashSet<string> hashSet;
			return this.OriginalCombinationActionNameMap.TryGetValue(inputControllerType, out hashSet) && hashSet.Contains(actionName);
		}

		// Token: 0x06045651 RID: 284241 RVA: 0x01225290 File Offset: 0x01223490
		public bool IsNotInSettingsCombinationAction(string actionName, EKeySettingExclusiveType exclusiveType, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
		{
			if (!this.IsOriginalCombinationActionName(actionName, inputControllerType))
			{
				return false;
			}
			Dictionary<CSharpScript.Game.Module.Menu.EInputControllerType, HashSet<string>> dictionary;
			this.InSettingActionNameMap.TryGetValue(exclusiveType, out dictionary);
			if (dictionary == null)
			{
				return true;
			}
			HashSet<string> hashSet;
			dictionary.TryGetValue(inputControllerType, out hashSet);
			return hashSet == null || !hashSet.Contains(actionName);
		}

		// Token: 0x06045652 RID: 284242 RVA: 0x012252D6 File Offset: 0x012234D6
		private void SetCombinationActionKeyMapDirty()
		{
			this.CombinationActionKeyMapDirty = new bool?(true);
			this.StartCheckCombinationActionKeyMapSave();
		}

		// Token: 0x06045653 RID: 284243 RVA: 0x012252EA File Offset: 0x012234EA
		private void StartCheckCombinationActionKeyMapSave()
		{
			if (this.IsCheckingCombinationActionKeyMapSave())
			{
				return;
			}
			this.CheckCombinationActionKeyMapSaveTimerId = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				if (this.SaveCombinationActionKeyMapIfDirty())
				{
					this.StopCheckCombinationActionKeyMapSave();
				}
			}, 10000f, null, null, true, 1f);
		}

		// Token: 0x06045654 RID: 284244 RVA: 0x0122531E File Offset: 0x0122351E
		private void StopCheckCombinationActionKeyMapSave()
		{
			if (this.CheckCombinationActionKeyMapSaveTimerId != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.CheckCombinationActionKeyMapSaveTimerId);
				this.CheckCombinationActionKeyMapSaveTimerId = null;
			}
		}

		// Token: 0x06045655 RID: 284245 RVA: 0x01225340 File Offset: 0x01223540
		private bool IsCheckingCombinationActionKeyMapSave()
		{
			return this.CheckCombinationActionKeyMapSaveTimerId != null;
		}

		// Token: 0x06045656 RID: 284246 RVA: 0x0122534B File Offset: 0x0122354B
		private bool SaveCombinationActionKeyMapIfDirty()
		{
			if (this.CombinationActionKeyMapDirty.GetValueOrDefault())
			{
				LocalStorage.SetGlobal<Dictionary<string, IList<IList<string>>>>(ELocalStorageGlobalKey.CombineAction, this.CombinationActionKeyMap);
				this.CombinationActionKeyMapDirty = new bool?(false);
				return true;
			}
			return false;
		}

		// Token: 0x06045657 RID: 284247 RVA: 0x01225377 File Offset: 0x01223577
		public void AddServerExistingAction(string actionName)
		{
			this.ServerExistingActions.Add(actionName);
		}

		// Token: 0x06045658 RID: 284248 RVA: 0x01225386 File Offset: 0x01223586
		public void AddServerExistingAxisName(string axisName)
		{
			this.ServerExistingAxisNames.Add(axisName);
		}

		// Token: 0x06045659 RID: 284249 RVA: 0x01225395 File Offset: 0x01223595
		public void AddServerExistingCombinationActionName(string actionName)
		{
			this.ServerExistingCombinationActionNames.Add(actionName);
		}

		// Token: 0x0604565A RID: 284250 RVA: 0x012253A4 File Offset: 0x012235A4
		public void ClearServerExistingData()
		{
			this.ServerExistingActions.Clear();
			this.ServerExistingAxisNames.Clear();
			this.ServerExistingCombinationActionNames.Clear();
		}

		// Token: 0x0604565B RID: 284251 RVA: 0x012253C8 File Offset: 0x012235C8
		public InputSettingsManager()
		{
			Dictionary<EKeySettingExclusiveType, EInputBindingType> dictionary = new Dictionary<EKeySettingExclusiveType, EInputBindingType>();
			dictionary[EKeySettingExclusiveType.None] = EInputBindingType.Original;
			dictionary[EKeySettingExclusiveType.Motor] = EInputBindingType.Motor;
			this.ExclusiveTypeToBindingTypeMap = dictionary;
			this.DeviceLangInternal = "";
			this.CurrentDeviceLang = EKeyboardPrimaryLangId.Default;
			this.ActionSwitchKeysStat = Stat.Create("InputSettingsManager.ActionSwitchKeys", "", "");
			this.AxisSwitchKeysStat = Stat.Create("InputSettingsManager.AxisSwitchKeys", "", "");
			this.CombinationActionSwitchKeysStat = Stat.Create("InputSettingsManager.CombinationActionSwitchKeys", "", "");
			this.CombinationAxisSwitchKeysStat = Stat.Create("InputSettingsManager.CombinationAxisSwitchKeys", "", "");
			this.OriginalActionNameSet = new HashSet<string>();
			this.OriginalCombinationActionNameSet = new HashSet<string>();
			this.InSettingActionNameMap = new Dictionary<EKeySettingExclusiveType, Dictionary<CSharpScript.Game.Module.Menu.EInputControllerType, HashSet<string>>>();
			this.ServerExistingActions = new HashSet<string>();
			this.ServerExistingAxisNames = new HashSet<string>();
			this.ServerExistingCombinationActionNames = new HashSet<string>();
			base..ctor();
		}

		// Token: 0x04026C90 RID: 158864
		private const int CHECK_COMBINATIONACTIONKEYMAP_SAVE_INTERVAL = 10000;

		// Token: 0x04026C91 RID: 158865
		[Nullable(2)]
		private InputActionMapping ActionMapping;

		// Token: 0x04026C92 RID: 158866
		[Nullable(2)]
		private InputAxisMapping AxisMapping;

		// Token: 0x04026C93 RID: 158867
		[Nullable(2)]
		private InputCombinationActionMapping CombinationActionMapping;

		// Token: 0x04026C94 RID: 158868
		[Nullable(2)]
		private InputCombinationAxisMapping CombinationAxisMapping;

		// Token: 0x04026C95 RID: 158869
		private Dictionary<string, IList<IList<string>>> CombinationActionKeyMap = new Dictionary<string, IList<IList<string>>>();

		// Token: 0x04026C96 RID: 158870
		private bool? CombinationActionKeyMapDirty;

		// Token: 0x04026C97 RID: 158871
		[Nullable(2)]
		private TimerHandle CheckCombinationActionKeyMapSaveTimerId;

		// Token: 0x04026C98 RID: 158872
		private readonly Dictionary<CSharpScript.Game.Module.Menu.EInputControllerType, HashSet<string>> OriginalCombinationActionNameMap = new Dictionary<CSharpScript.Game.Module.Menu.EInputControllerType, HashSet<string>>();

		// Token: 0x04026C99 RID: 158873
		private readonly Dictionary<string, string> NormalToFrenchPcKeysMap = new Dictionary<string, string>();

		// Token: 0x04026C9A RID: 158874
		private readonly Dictionary<string, string> FrenchToNormalPcKeysMap = new Dictionary<string, string>();

		// Token: 0x04026C9B RID: 158875
		private readonly Dictionary<EKeySettingExclusiveType, EInputBindingType> ExclusiveTypeToBindingTypeMap;

		// Token: 0x04026C9C RID: 158876
		private string DeviceLangInternal;

		// Token: 0x04026C9D RID: 158877
		public EKeyboardPrimaryLangId CurrentDeviceLang;

		// Token: 0x04026C9E RID: 158878
		public EInputBindingType CurrentBindingType;

		// Token: 0x04026C9F RID: 158879
		private readonly Stat ActionSwitchKeysStat;

		// Token: 0x04026CA0 RID: 158880
		private readonly Stat AxisSwitchKeysStat;

		// Token: 0x04026CA1 RID: 158881
		private readonly Stat CombinationActionSwitchKeysStat;

		// Token: 0x04026CA2 RID: 158882
		private readonly Stat CombinationAxisSwitchKeysStat;

		// Token: 0x04026CA3 RID: 158883
		private readonly HashSet<string> OriginalActionNameSet;

		// Token: 0x04026CA4 RID: 158884
		private readonly HashSet<string> OriginalCombinationActionNameSet;

		// Token: 0x04026CA5 RID: 158885
		private readonly Dictionary<EKeySettingExclusiveType, Dictionary<CSharpScript.Game.Module.Menu.EInputControllerType, HashSet<string>>> InSettingActionNameMap;

		// Token: 0x04026CA6 RID: 158886
		private readonly HashSet<string> ServerExistingActions;

		// Token: 0x04026CA7 RID: 158887
		private readonly HashSet<string> ServerExistingAxisNames;

		// Token: 0x04026CA8 RID: 158888
		private readonly HashSet<string> ServerExistingCombinationActionNames;
	}
}
