using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.GameSettings;
using CSharpScript.Game.Module.KeySetting;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Launcher.Platform;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FF2 RID: 28658
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class InputSettingsController : ControllerBase<InputSettingsController>
	{
		// Token: 0x060455C8 RID: 284104 RVA: 0x0121ED4B File Offset: 0x0121CF4B
		protected override bool OnInit()
		{
			Singleton<Net>.Instance.Register<InputSettingUpdateNotify>(ENotifyMessageId.InputSettingUpdateNotify, new Action<InputSettingUpdateNotify, Net.CallbackStatus>(this.InputSettingUpdateNotify));
			Singleton<EventSystem>.Instance.Add(EEventName.OnGetPlayerBasicInfo, new Action(this.OnGetPlayerBasicInfo));
			return true;
		}

		// Token: 0x060455C9 RID: 284105 RVA: 0x0121ED86 File Offset: 0x0121CF86
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InputSettingUpdateNotify);
			Singleton<EventSystem>.Instance.Remove(EEventName.OnGetPlayerBasicInfo, new Action(this.OnGetPlayerBasicInfo));
			return true;
		}

		// Token: 0x060455CA RID: 284106 RVA: 0x0121EDB8 File Offset: 0x0121CFB8
		private void OnGetPlayerBasicInfo()
		{
			Singleton<Log>.Instance.Info(ELogModule.InputSettings, ELogAuthor.XXJ, "登录直接请求服务端输入数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.InputSettingRequest();
		}

		// Token: 0x060455CB RID: 284107 RVA: 0x0121EDE8 File Offset: 0x0121CFE8
		private void ResetDefaultInputKey()
		{
			SkillButtonUiGamepadDataBase gamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData != null)
			{
				gamepadData.AddChangeKeyReason(EGamepadChangeKeyReason.ProtoInputSetting);
			}
			if (ModelBase<LoginModel>.Instance.IsNewAccount)
			{
				Singleton<Log>.Instance.Info(ELogModule.InputSettings, ELogAuthor.XXJ, "新号没有输入数据，还原至配置表配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				Singleton<InputSettingsManager>.Instance.ResetDefaultInputKey();
			}
			else
			{
				Singleton<Log>.Instance.Info(ELogModule.InputSettings, ELogAuthor.XXJ, "老号没有输入数据，默认本地存储按键", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			SkillButtonUiGamepadDataBase gamepadData2 = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData2 == null)
			{
				return;
			}
			gamepadData2.RemoveChangeKeyReason(EGamepadChangeKeyReason.ProtoInputSetting);
		}

		// Token: 0x060455CC RID: 284108 RVA: 0x0121EE70 File Offset: 0x0121D070
		private void InputSettingUpdateNotify(InputSettingUpdateNotify notify, [Nullable(2)] Net.CallbackStatus Status)
		{
			this.RefreshInputSettingsFromProtoData(notify.InputSettingData);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnInputSettingUpdateNotify);
		}

		// Token: 0x060455CD RID: 284109 RVA: 0x0121EE90 File Offset: 0x0121D090
		public void InputSettingRequest()
		{
			InputSettingRequest message = Aki.Protocol.InputSettingRequest.Create();
			Singleton<Net>.Instance.Call<InputSettingResponse>(ERequestMessageId.InputSettingRequest, message, new Action<InputSettingResponse, Net.CallbackStatus>(this.InputSettingResponse), 0);
		}

		// Token: 0x060455CE RID: 284110 RVA: 0x0121EEC0 File Offset: 0x0121D0C0
		[NullableContext(2)]
		private void InputSettingResponse(InputSettingResponse response, Net.CallbackStatus Status)
		{
			if (response == null || response.InputSettingData == null || response.InputSettingData.InputSettings.Count <= 0)
			{
				Singleton<Log>.Instance.Info(ELogModule.InputSettings, ELogAuthor.XXJ, "服务端没有数据，使用本地配置并同步给服务端", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ResetDefaultInputKey();
				if (!Singleton<Platform>.Instance.IsMobilePlatform())
				{
					this.InputSettingUpdateRequest(!ModelBase<LoginModel>.Instance.IsNewAccount);
				}
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.InputSettings, ELogAuthor.XXJ, "服务端有对应数据,使用服务端数据刷新本地输入数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.RefreshInputSettingsFromProtoData(response.InputSettingData);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnInputSettingResponse);
		}

		// Token: 0x060455CF RID: 284111 RVA: 0x0121EF68 File Offset: 0x0121D168
		public void InputSettingUpdateRequest(bool isOldVersionData)
		{
			InputSettingUpdateRequest inputSettingUpdateRequest = Aki.Protocol.InputSettingUpdateRequest.Create();
			inputSettingUpdateRequest.InputSettingData = this.BuildInputSettingsToProtoData(isOldVersionData);
			Singleton<Net>.Instance.Call<InputSettingUpdateResponse>(ERequestMessageId.InputSettingUpdateRequest, inputSettingUpdateRequest, new Action<InputSettingUpdateResponse, Net.CallbackStatus>(this.InputSettingUpdateResponse), 0);
		}

		// Token: 0x060455D0 RID: 284112 RVA: 0x0121EFA5 File Offset: 0x0121D1A5
		[NullableContext(2)]
		private void InputSettingUpdateResponse(InputSettingUpdateResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16181, null, true, true);
		}

		// Token: 0x060455D1 RID: 284113 RVA: 0x0121EFCC File Offset: 0x0121D1CC
		private EInputBindingType GetInputBindType(SettingInputType inputType)
		{
			foreach (KeyValuePair<EInputBindingType, SettingInputType> keyValuePair in this.InputBindTypeMap)
			{
				EInputBindingType einputBindingType;
				SettingInputType settingInputType;
				keyValuePair.Deconstruct(out einputBindingType, out settingInputType);
				EInputBindingType result = einputBindingType;
				if (settingInputType == inputType)
				{
					return result;
				}
			}
			return EInputBindingType.Original;
		}

		// Token: 0x060455D2 RID: 284114 RVA: 0x0121F034 File Offset: 0x0121D234
		private unsafe void ProcessConnectedKeySetting(int connectedKeySettingId, KeySetting keySettingConfig)
		{
			KeySetting? config = ConfigKeySettingById.GetConfig(connectedKeySettingId, true);
			if (config == null)
			{
				return;
			}
			KeySetting? keySetting = config;
			string actionOrAxisName = keySettingConfig.ActionOrAxisName;
			bool flag = keySettingConfig.ActionOrAxis == 1;
			string actionOrAxisName2 = keySetting.Value.ActionOrAxisName;
			InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding(actionOrAxisName2);
			List<string> list = new List<string>();
			IReadOnlyDictionary<string, string> keyNameMap = null;
			EInputBindingType bindTypeByExclusiveType = Singleton<InputSettingsManager>.Instance.GetBindTypeByExclusiveType((EKeySettingExclusiveType)keySettingConfig.ExclusiveType);
			CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType;
			if (flag)
			{
				InputActionBinding actionBinding2 = Singleton<InputSettingsManager>.Instance.GetActionBinding(actionOrAxisName);
				InputCombinationActionBinding inputCombinationActionBinding = Singleton<InputSettingsManager>.Instance.TryGetCombinationActionBinding(actionOrAxisName);
				inputControllerType = (CSharpScript.Game.Module.Menu.EInputControllerType)keySettingConfig.InputControllerType;
				if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
				{
					if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
					{
						actionBinding2.GetKeyNameList(list);
					}
					else
					{
						actionBinding2.GetGamepadKeyNameList(list);
						keyNameMap = inputCombinationActionBinding.GetGamepadKeyNameMapByBindingType(bindTypeByExclusiveType);
					}
				}
				else
				{
					actionBinding2.GetPcKeyNameList(list);
					keyNameMap = inputCombinationActionBinding.GetPcKeyNameMap(bindTypeByExclusiveType);
				}
			}
			else
			{
				InputAxisBinding axisBinding = Singleton<InputSettingsManager>.Instance.GetAxisBinding(actionOrAxisName);
				if (axisBinding == null)
				{
					return;
				}
				float pcAxisValue = keySettingConfig.PcAxisValue;
				float xboxAxisValue = keySettingConfig.XBoxAxisValue;
				Dictionary<string, float> dictionary = new Dictionary<string, float>();
				inputControllerType = (CSharpScript.Game.Module.Menu.EInputControllerType)keySettingConfig.InputControllerType;
				if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
				{
					if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
					{
						goto IL_215;
					}
				}
				else
				{
					axisBinding.GetPcKeyScaleMap(dictionary, bindTypeByExclusiveType);
					using (Dictionary<string, float>.Enumerator enumerator = dictionary.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							KeyValuePair<string, float> keyValuePair = enumerator.Current;
							string text;
							float num;
							keyValuePair.Deconstruct(out text, out num);
							string keyName = text;
							float num2 = num;
							if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)num2, (double)pcAxisValue, null))
							{
								string item = InputKeyUtils.ConvertKeyToActionOrAxis(keyName, true);
								list.Add(item);
							}
						}
						goto IL_215;
					}
				}
				axisBinding.GetGamepadKeyScaleMap(dictionary, bindTypeByExclusiveType);
				foreach (KeyValuePair<string, float> keyValuePair in dictionary)
				{
					KeyValuePair<string, float> keyValuePair;
					string text;
					float num;
					keyValuePair.Deconstruct(out text, out num);
					string keyName2 = text;
					float num3 = num;
					if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)num3, (double)xboxAxisValue, null))
					{
						string item2 = InputKeyUtils.ConvertKeyToActionOrAxis(keyName2, true);
						list.Add(item2);
					}
				}
			}
			IL_215:
			inputControllerType = (CSharpScript.Game.Module.Menu.EInputControllerType)keySettingConfig.InputControllerType;
			if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard)
			{
				if (inputControllerType != CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
				{
					if (actionBinding != null)
					{
						actionBinding.SetKeys(list, bindTypeByExclusiveType);
					}
				}
				else
				{
					if (actionBinding != null)
					{
						actionBinding.SetGamepadKeys(list, bindTypeByExclusiveType);
					}
					Singleton<InputSettingsManager>.Instance.SetOrAddCombinationActionGamepadKeys(actionOrAxisName2, keyNameMap, bindTypeByExclusiveType);
				}
			}
			else
			{
				if (actionBinding != null)
				{
					actionBinding.SetKeyboardKeys(list, bindTypeByExclusiveType);
				}
				Singleton<InputSettingsManager>.Instance.SetOrAddCombinationActionKeyboardKeys(actionOrAxisName2, keyNameMap, bindTypeByExclusiveType);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "处理键位联动问题";
			<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionOrAxisName", actionOrAxisName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsAction", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Type", keySettingConfig.InputControllerType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("LinkActionName", actionOrAxisName2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("KeyNames", list);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("after", (actionBinding != null) ? actionBinding.GetKeyNameList() : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
		}

		// Token: 0x060455D3 RID: 284115 RVA: 0x0121F3AC File Offset: 0x0121D5AC
		private unsafe void HandleLinkActionKey()
		{
			IReadOnlyList<KeySetting> configList = ConfigKeySettingAll.GetConfigList(true);
			if (configList == null)
			{
				return;
			}
			foreach (KeySetting keySettingConfig in configList)
			{
				Span<int> connectedKeySettingIdListBytes = keySettingConfig.GetConnectedKeySettingIdListBytes();
				if (connectedKeySettingIdListBytes.Length > 0)
				{
					Span<int> span = connectedKeySettingIdListBytes;
					for (int i = 0; i < span.Length; i++)
					{
						int connectedKeySettingId = *span[i];
						this.ProcessConnectedKeySetting(connectedKeySettingId, keySettingConfig);
					}
				}
			}
		}

		// Token: 0x060455D4 RID: 284116 RVA: 0x0121F438 File Offset: 0x0121D638
		public void HandleBothActionSyncAllExclusiveKey()
		{
			IReadOnlyList<KeySetting> configList = ConfigKeySettingAll.GetConfigList(true);
			if (configList == null)
			{
				return;
			}
			foreach (KeySetting keySetting in configList)
			{
				if (keySetting.BothActionNameLength == 2 && keySetting.BothActionSyncAllExclusive)
				{
					for (int i = 0; i < keySetting.BothActionNameLength; i++)
					{
						string text = keySetting.BothActionName(i);
						if (!string.IsNullOrEmpty(text))
						{
							InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding(text);
							if (actionBinding != null)
							{
								List<string> list = new List<string>();
								actionBinding.GetKeyNameListByBindingType(list, EInputBindingType.Original);
								foreach (EInputBindingType einputBindingType in InputBindingDefine.inputBindingTypesArray)
								{
									if (einputBindingType != EInputBindingType.Original)
									{
										actionBinding.SetKeys(list, einputBindingType);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060455D5 RID: 284117 RVA: 0x0121F518 File Offset: 0x0121D718
		[NullableContext(2)]
		public void RefreshInputSettingsFromProtoData(InputSettingData inputSettingsData)
		{
			if (inputSettingsData == null || inputSettingsData.InputSettings == null || inputSettingsData.InputSettings.Count <= 0)
			{
				Singleton<Log>.Instance.Info(ELogModule.InputSettings, ELogAuthor.XXJ, "[RefreshInputSettingsFromProtoData]服务端没有数据，使用本地配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ResetDefaultInputKey();
				GameSettingsUtils.RefreshViewRevertState(Singleton<Info>.Instance.InputControllerMainType);
				return;
			}
			Singleton<InputSettingsManager>.Instance.ClearServerExistingData();
			SkillButtonUiGamepadDataBase gamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData != null)
			{
				gamepadData.AddChangeKeyReason(EGamepadChangeKeyReason.ProtoInputSetting);
			}
			string deviceLang = "";
			IEnumerable<OneDeviceInputSetting> inputSettings = inputSettingsData.InputSettings;
			bool flag = false;
			foreach (OneDeviceInputSetting oneDeviceInputSetting in inputSettings)
			{
				InputSettingDevice device = oneDeviceInputSetting.Device;
				if (device == InputSettingDevice.Mouse)
				{
					deviceLang = Singleton<InputSettingsManager>.Instance.DeviceLang;
					Singleton<InputSettingsManager>.Instance.DeviceLang = oneDeviceInputSetting.DeviceSubType;
				}
				bool flag2 = this.RefreshCombinationActionFromProtoData(oneDeviceInputSetting.InputCombinationAction, device, oneDeviceInputSetting.DeviceSubType);
				flag = (flag || flag2);
				bool flag3 = this.RefreshActionFromProtoData(oneDeviceInputSetting.InputAction, device, oneDeviceInputSetting.DeviceSubType);
				flag = (flag || flag3);
				bool flag4 = this.RefreshAxisFromProtoData(oneDeviceInputSetting.InputAxis, device, oneDeviceInputSetting.DeviceSubType);
				flag = (flag || flag4);
			}
			this.HandleLinkActionKey();
			this.HandleBothActionSyncAllExclusiveKey();
			if (Singleton<Platform>.Instance.IsPcPlatform())
			{
				Singleton<InputSettingsManager>.Instance.ChangeActionAndAxisPcKeys(deviceLang, true);
			}
			SkillButtonUiGamepadDataBase gamepadData2 = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData2 != null)
			{
				gamepadData2.RemoveChangeKeyReason(EGamepadChangeKeyReason.ProtoInputSetting);
			}
			if (flag)
			{
				this.InputSettingUpdateRequest(false);
				return;
			}
			GameSettingsUtils.RefreshViewRevertState(Singleton<Info>.Instance.InputControllerMainType);
		}

		// Token: 0x060455D6 RID: 284118 RVA: 0x0121F6AC File Offset: 0x0121D8AC
		private bool RefreshActionFromProtoData([Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<InputAction> actionList, InputSettingDevice inputDeviceType, string deviceLang)
		{
			if (actionList == null || actionList.Count == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "从InputSettingData刷新Action输入时，没有输入数据，还原至默认输入按键";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionData", actionList);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Singleton<InputSettingsManager>.Instance.RefreshAllActionKeys();
				return false;
			}
			InputSettingsConfig instance2 = ConfigBase<InputSettingsConfig>.Instance;
			bool flag = false;
			foreach (InputAction inputAction in actionList)
			{
				string actionName = inputAction.ActionName;
				InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding(actionName);
				if (actionBinding != null)
				{
					Singleton<InputSettingsManager>.Instance.AddServerExistingAction(actionName);
					int version = inputAction.Version;
					EKeySettingExclusiveType exclusiveTypeByBindingType = Singleton<InputSettingsManager>.Instance.GetExclusiveTypeByBindingType(this.GetInputBindType(inputAction.InputType));
					if (inputDeviceType != InputSettingDevice.Mouse)
					{
						if (inputDeviceType == InputSettingDevice.Handle)
						{
							int gamepadVersion = actionBinding.GetGamepadVersion(exclusiveTypeByBindingType);
							flag = (flag || gamepadVersion > version);
							if (gamepadVersion > version)
							{
								ActionMapping? actionMapping = (instance2 != null) ? instance2.GetActionMappingConfigByActionName(actionName) : null;
								if (actionMapping == null)
								{
									continue;
								}
								List<string> list = new List<string>();
								for (int i = 0; i < actionMapping.Value.GamepadKeysLength; i++)
								{
									string text = actionMapping.Value.GamepadKeys(i);
									if (!string.IsNullOrEmpty(text))
									{
										list.Add(text);
									}
								}
								EInputBindingType inputBindType = this.GetInputBindType(inputAction.InputType);
								actionBinding.SetGamepadKeys(list, inputBindType);
								InputCombinationActionBinding combinationActionBindingByActionName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName(actionName);
								if (combinationActionBindingByActionName == null)
								{
									continue;
								}
								Dictionary<string, string> dictionary = new Dictionary<string, string>();
								combinationActionBindingByActionName.GetGamepadKeyNameMapByBindingType(dictionary, inputBindType);
								using (Dictionary<string, string>.Enumerator enumerator2 = dictionary.GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										KeyValuePair<string, string> keyValuePair = enumerator2.Current;
										string text2;
										string text3;
										keyValuePair.Deconstruct(out text2, out text3);
										string mainKeyName = text2;
										string secondaryKeyName = text3;
										Singleton<InputSettingsManager>.Instance.RemoveCombinationActionKeyMap(actionName, mainKeyName, secondaryKeyName, inputBindType);
									}
									continue;
								}
							}
							string[] array = inputAction.KeyNameList.ToArray<string>();
							EInputBindingType inputBindType2 = this.GetInputBindType(inputAction.InputType);
							actionBinding.SetGamepadKeys(array, inputBindType2);
							actionBinding.SetGamepadVersion(version, exclusiveTypeByBindingType);
							if (array.Length != 0 && array[0] != EKey.Gamepad_Invalid)
							{
								InputCombinationActionBinding combinationActionBindingByActionName2 = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName(actionName);
								if (combinationActionBindingByActionName2 != null)
								{
									Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
									combinationActionBindingByActionName2.GetGamepadKeyNameMapByBindingType(dictionary2, inputBindType2);
									foreach (KeyValuePair<string, string> keyValuePair in dictionary2)
									{
										string text2;
										string text3;
										keyValuePair.Deconstruct(out text3, out text2);
										string mainKeyName2 = text3;
										string secondaryKeyName2 = text2;
										Singleton<InputSettingsManager>.Instance.RemoveCombinationActionKeyMap(actionName, mainKeyName2, secondaryKeyName2, inputBindType2);
									}
								}
							}
						}
					}
					else
					{
						int keyboardVersion = actionBinding.GetKeyboardVersion(exclusiveTypeByBindingType);
						flag = (flag || keyboardVersion > version);
						if (keyboardVersion > version)
						{
							ActionMapping? actionMapping2 = (instance2 != null) ? instance2.GetActionMappingConfigByActionName(actionName) : null;
							if (actionMapping2 == null)
							{
								continue;
							}
							List<string> keyboardKeys = LanguageKeyTransUtils.GetKeyTrans(Singleton<InputSettingsManager>.Instance.CurrentDeviceLang).GetActionPcKeys(actionMapping2.Value).ToList<string>();
							EInputBindingType inputBindType3 = this.GetInputBindType(inputAction.InputType);
							actionBinding.SetKeyboardKeys(keyboardKeys, inputBindType3);
							InputCombinationActionBinding combinationActionBindingByActionName3 = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName(actionName);
							if (combinationActionBindingByActionName3 == null)
							{
								continue;
							}
							Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
							combinationActionBindingByActionName3.GetPcKeyNameMap(dictionary3, inputBindType3);
							using (Dictionary<string, string>.Enumerator enumerator2 = dictionary3.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									KeyValuePair<string, string> keyValuePair = enumerator2.Current;
									string text2;
									string text3;
									keyValuePair.Deconstruct(out text3, out text2);
									string mainKeyName3 = text3;
									string secondaryKeyName3 = text2;
									Singleton<InputSettingsManager>.Instance.RemoveCombinationActionKeyMap(actionName, mainKeyName3, secondaryKeyName3, inputBindType3);
								}
								continue;
							}
						}
						RepeatedField<string> keyNameList = inputAction.KeyNameList;
						EInputBindingType inputBindType4 = this.GetInputBindType(inputAction.InputType);
						actionBinding.SetKeyboardKeys(keyNameList, inputBindType4);
						actionBinding.SetKeyboardVersion(version, exclusiveTypeByBindingType);
					}
				}
			}
			return flag;
		}

		// Token: 0x060455D7 RID: 284119 RVA: 0x0121FB0C File Offset: 0x0121DD0C
		private bool RefreshAxisFromProtoData([Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<InputAxis> axisList, InputSettingDevice inputDeviceType, string deviceLang)
		{
			if (axisList == null || axisList.Count == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "从InputSettingData刷新Action输入时，没有输入数据，还原至默认输入按键";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("axisMap", axisList);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Singleton<InputSettingsManager>.Instance.RefreshAllAxisKeys();
				return false;
			}
			InputSettingsConfig instance2 = ConfigBase<InputSettingsConfig>.Instance;
			bool flag = false;
			foreach (InputAxis inputAxis in axisList)
			{
				string axisName = inputAxis.AxisName;
				InputAxisBinding axisBinding = Singleton<InputSettingsManager>.Instance.GetAxisBinding(axisName);
				if (axisBinding != null)
				{
					Singleton<InputSettingsManager>.Instance.AddServerExistingAxisName(axisName);
					int version = inputAxis.Version;
					EKeySettingExclusiveType exclusiveTypeByBindingType = Singleton<InputSettingsManager>.Instance.GetExclusiveTypeByBindingType(this.GetInputBindType(inputAxis.InputType));
					if (inputDeviceType != InputSettingDevice.Mouse)
					{
						if (inputDeviceType == InputSettingDevice.Handle)
						{
							int gamepadVersion = axisBinding.GetGamepadVersion(exclusiveTypeByBindingType);
							flag = (flag || gamepadVersion > version);
							if (gamepadVersion > version)
							{
								AxisMapping? axisMapping = (instance2 != null) ? instance2.GetAxisMappingConfigByAxisName(axisName) : null;
								if (axisMapping != null)
								{
									Dictionary<string, float> dictionary = new Dictionary<string, float>();
									for (int i = 0; i < axisMapping.Value.GamepadKeysLength; i++)
									{
										DicStringFloat? dicStringFloat = axisMapping.Value.GamepadKeys(i);
										dictionary[dicStringFloat.Value.Key] = dicStringFloat.Value.Value;
									}
									EInputBindingType inputBindType = this.GetInputBindType(inputAxis.InputType);
									axisBinding.SetGamepadKeys(dictionary, inputBindType);
								}
							}
							else
							{
								Dictionary<string, float> dictionary2 = new Dictionary<string, float>();
								MapField<string, int> keyScaleMap = inputAxis.KeyScaleMap;
								foreach (string key in keyScaleMap.Keys)
								{
									float value = (float)keyScaleMap[key] / 1000f;
									dictionary2[key] = value;
								}
								EInputBindingType inputBindType2 = this.GetInputBindType(inputAxis.InputType);
								axisBinding.SetGamepadKeys(dictionary2, inputBindType2);
								axisBinding.SetGamepadVersion(version, exclusiveTypeByBindingType);
							}
						}
					}
					else
					{
						int keyboardVersion = axisBinding.GetKeyboardVersion(exclusiveTypeByBindingType);
						flag = (flag || keyboardVersion > version);
						if (keyboardVersion > version)
						{
							AxisMapping? axisMapping2 = (instance2 != null) ? instance2.GetAxisMappingConfigByAxisName(axisName) : null;
							if (axisMapping2 != null)
							{
								LanguageKeyTransBase keyTrans = LanguageKeyTransUtils.GetKeyTrans(Singleton<InputSettingsManager>.Instance.CurrentDeviceLang);
								Dictionary<string, float> keyboardScaleMap = ((keyTrans != null) ? keyTrans.GetAxisPcKeys(axisMapping2.Value) : null) ?? new Dictionary<string, float>();
								EInputBindingType inputBindType3 = this.GetInputBindType(inputAxis.InputType);
								axisBinding.SetKeyboardKeys(keyboardScaleMap, inputBindType3);
							}
						}
						else
						{
							Dictionary<string, float> dictionary3 = new Dictionary<string, float>();
							MapField<string, int> keyScaleMap2 = inputAxis.KeyScaleMap;
							foreach (string key2 in keyScaleMap2.Keys)
							{
								float value2 = (float)keyScaleMap2[key2] / 1000f;
								dictionary3[key2] = value2;
							}
							EInputBindingType inputBindType4 = this.GetInputBindType(inputAxis.InputType);
							axisBinding.SetKeyboardKeys(dictionary3, inputBindType4);
							axisBinding.SetKeyboardVersion(version, exclusiveTypeByBindingType);
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x060455D8 RID: 284120 RVA: 0x0121FE90 File Offset: 0x0121E090
		private bool RefreshCombinationActionFromProtoData([Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<Aki.Protocol.CombinationAction> combinationActionList, InputSettingDevice inputDeviceType, string deviceLang)
		{
			if (combinationActionList == null || combinationActionList.Count == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "从InputSettingData刷新Action输入时，没有输入数据，还原至默认输入按键";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionData", combinationActionList);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Singleton<InputSettingsManager>.Instance.RefreshCombinationActionKeys();
				return false;
			}
			bool flag = false;
			InputSettingsConfig instance2 = ConfigBase<InputSettingsConfig>.Instance;
			foreach (Aki.Protocol.CombinationAction combinationAction in combinationActionList)
			{
				string actionName = combinationAction.ActionName;
				InputCombinationActionBinding inputCombinationActionBinding = Singleton<InputSettingsManager>.Instance.TryGetCombinationActionBinding(actionName);
				if (inputCombinationActionBinding != null)
				{
					Singleton<InputSettingsManager>.Instance.AddServerExistingCombinationActionName(actionName);
					int version = combinationAction.Version;
					EKeySettingExclusiveType exclusiveTypeByBindingType = Singleton<InputSettingsManager>.Instance.GetExclusiveTypeByBindingType(this.GetInputBindType(combinationAction.InputType));
					if (inputDeviceType != InputSettingDevice.Mouse)
					{
						if (inputDeviceType == InputSettingDevice.Handle)
						{
							int gamepadVersion = inputCombinationActionBinding.GetGamepadVersion(exclusiveTypeByBindingType);
							flag = (flag || gamepadVersion > version);
							if (gamepadVersion > version)
							{
								Aki.Config.CombinationAction? combinationAction2 = (instance2 != null) ? instance2.GetCombinationActionConfigByActionName(actionName) : null;
								if (combinationAction2 != null)
								{
									Dictionary<string, string> dictionary = new Dictionary<string, string>();
									for (int i = 0; i < combinationAction2.Value.GamepadKeysLength; i++)
									{
										DicStringString? dicStringString = combinationAction2.Value.GamepadKeys(i);
										dictionary[dicStringString.Value.Key] = dicStringString.Value.Value;
									}
									EInputBindingType inputBindType = this.GetInputBindType(combinationAction.InputType);
									Singleton<InputSettingsManager>.Instance.SetCombinationActionGamepadKeys(actionName, dictionary, inputBindType);
								}
							}
							else if (Singleton<InputSettingsManager>.Instance.IsNotInSettingsCombinationAction(actionName, exclusiveTypeByBindingType, CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad))
							{
								Aki.Config.CombinationAction? combinationAction3 = (instance2 != null) ? instance2.GetCombinationActionConfigByActionName(actionName) : null;
								if (combinationAction3 != null)
								{
									Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
									for (int j = 0; j < combinationAction3.Value.GamepadKeysLength; j++)
									{
										DicStringString? dicStringString2 = combinationAction3.Value.GamepadKeys(j);
										dictionary2[dicStringString2.Value.Key] = dicStringString2.Value.Value;
									}
									EInputBindingType inputBindType2 = this.GetInputBindType(combinationAction.InputType);
									Singleton<InputSettingsManager>.Instance.SetCombinationActionGamepadKeys(actionName, dictionary2, inputBindType2);
								}
							}
							else
							{
								Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
								foreach (CombinationKey combinationKey in combinationAction.CombinationKeyList)
								{
									dictionary3[combinationKey.KeyNameList[0]] = combinationKey.KeyNameList[1];
								}
								EInputBindingType inputBindType3 = this.GetInputBindType(combinationAction.InputType);
								Singleton<InputSettingsManager>.Instance.SetCombinationActionGamepadKeys(actionName, dictionary3, inputBindType3);
								inputCombinationActionBinding.SetGamepadVersion(version, exclusiveTypeByBindingType);
							}
						}
					}
					else
					{
						int keyboardVersion = inputCombinationActionBinding.GetKeyboardVersion(exclusiveTypeByBindingType);
						flag = (flag || keyboardVersion > version);
						if (keyboardVersion > version)
						{
							Aki.Config.CombinationAction? combinationAction4 = (instance2 != null) ? instance2.GetCombinationActionConfigByActionName(actionName) : null;
							if (combinationAction4 != null)
							{
								LanguageKeyTransBase keyTrans = LanguageKeyTransUtils.GetKeyTrans(Singleton<InputSettingsManager>.Instance.CurrentDeviceLang);
								Dictionary<string, string> keyNameMap = ((keyTrans != null) ? keyTrans.GetCombinationActionPcKeys(combinationAction4.Value) : null) ?? new Dictionary<string, string>();
								EInputBindingType inputBindType4 = this.GetInputBindType(combinationAction.InputType);
								Singleton<InputSettingsManager>.Instance.SetCombinationActionKeyboardKeys(actionName, keyNameMap, inputBindType4);
							}
						}
						else if (Singleton<InputSettingsManager>.Instance.IsNotInSettingsCombinationAction(actionName, exclusiveTypeByBindingType, CSharpScript.Game.Module.Menu.EInputControllerType.Keyboard))
						{
							Aki.Config.CombinationAction? combinationAction5 = (instance2 != null) ? instance2.GetCombinationActionConfigByActionName(actionName) : null;
							if (combinationAction5 != null)
							{
								LanguageKeyTransBase keyTrans2 = LanguageKeyTransUtils.GetKeyTrans(Singleton<InputSettingsManager>.Instance.CurrentDeviceLang);
								Dictionary<string, string> keyNameMap2 = ((keyTrans2 != null) ? keyTrans2.GetCombinationActionPcKeys(combinationAction5.Value) : null) ?? new Dictionary<string, string>();
								EInputBindingType inputBindType5 = this.GetInputBindType(combinationAction.InputType);
								Singleton<InputSettingsManager>.Instance.SetCombinationActionKeyboardKeys(actionName, keyNameMap2, inputBindType5);
							}
						}
						else
						{
							Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
							foreach (CombinationKey combinationKey2 in combinationAction.CombinationKeyList)
							{
								dictionary4[combinationKey2.KeyNameList[0]] = combinationKey2.KeyNameList[1];
							}
							EInputBindingType inputBindType6 = this.GetInputBindType(combinationAction.InputType);
							Singleton<InputSettingsManager>.Instance.SetCombinationActionKeyboardKeys(actionName, dictionary4, inputBindType6);
							inputCombinationActionBinding.SetKeyboardVersion(version, exclusiveTypeByBindingType);
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x060455D9 RID: 284121 RVA: 0x0122036C File Offset: 0x0121E56C
		[NullableContext(2)]
		private InputSettingData BuildInputSettingsToProtoData(bool isOldVersionData)
		{
			InputSettingData inputSettingData = InputSettingData.Create();
			OneDeviceInputSetting oneDeviceInputSetting = OneDeviceInputSetting.Create();
			OneDeviceInputSetting oneDeviceInputSetting2 = OneDeviceInputSetting.Create();
			oneDeviceInputSetting.Device = InputSettingDevice.Mouse;
			oneDeviceInputSetting.DeviceSubType = Singleton<InputSettingsManager>.Instance.DeviceLang;
			oneDeviceInputSetting2.Device = InputSettingDevice.Handle;
			this.BuildActionBindingToProtoData(isOldVersionData, oneDeviceInputSetting, oneDeviceInputSetting2);
			this.BuildAxisBindingToProtoData(isOldVersionData, oneDeviceInputSetting, oneDeviceInputSetting2);
			this.BuildCombinationActionBindingToProtoData(isOldVersionData, oneDeviceInputSetting, oneDeviceInputSetting2);
			this.BuildCombinationAxisBindingToProtoData(isOldVersionData, oneDeviceInputSetting, oneDeviceInputSetting2);
			inputSettingData.InputSettings.AddRange(new <>z__ReadOnlyArray<OneDeviceInputSetting>(new OneDeviceInputSetting[]
			{
				oneDeviceInputSetting,
				oneDeviceInputSetting2
			}));
			return inputSettingData;
		}

		// Token: 0x060455DA RID: 284122 RVA: 0x012203EC File Offset: 0x0121E5EC
		private void BuildActionBindingToProtoData(bool isOldVersionData, OneDeviceInputSetting keyboardInputSettings, OneDeviceInputSetting gamepadInputSettings)
		{
			foreach (KeyValuePair<string, InputActionBinding> keyValuePair in Singleton<InputSettingsManager>.Instance.GetActionBindingMap())
			{
				string text;
				InputActionBinding inputActionBinding;
				keyValuePair.Deconstruct(out text, out inputActionBinding);
				string actionName = text;
				InputActionBinding inputActionBinding2 = inputActionBinding;
				Dictionary<EInputBindingType, List<string>> dictionary = new Dictionary<EInputBindingType, List<string>>();
				inputActionBinding2.GetAllPcKeyNameMap(dictionary);
				foreach (KeyValuePair<EInputBindingType, List<string>> keyValuePair2 in dictionary)
				{
					EInputBindingType einputBindingType;
					List<string> list;
					keyValuePair2.Deconstruct(out einputBindingType, out list);
					EInputBindingType bindingType = einputBindingType;
					List<string> list2 = list;
					EKeySettingExclusiveType exclusiveTypeByBindingType = Singleton<InputSettingsManager>.Instance.GetExclusiveTypeByBindingType(bindingType);
					int version = isOldVersionData ? 0 : inputActionBinding2.GetKeyboardVersion(exclusiveTypeByBindingType);
					this.BuildActionKey(actionName, keyboardInputSettings, list2.ToArray(), version, bindingType);
				}
				Dictionary<EInputBindingType, List<string>> dictionary2 = new Dictionary<EInputBindingType, List<string>>();
				inputActionBinding2.GetAllGamepadKeyNameMap(dictionary2);
				foreach (KeyValuePair<EInputBindingType, List<string>> keyValuePair2 in dictionary2)
				{
					EInputBindingType einputBindingType;
					List<string> list;
					keyValuePair2.Deconstruct(out einputBindingType, out list);
					EInputBindingType bindingType2 = einputBindingType;
					List<string> list3 = list;
					EKeySettingExclusiveType exclusiveTypeByBindingType2 = Singleton<InputSettingsManager>.Instance.GetExclusiveTypeByBindingType(bindingType2);
					int version2 = isOldVersionData ? 0 : inputActionBinding2.GetGamepadVersion(exclusiveTypeByBindingType2);
					this.BuildActionKey(actionName, gamepadInputSettings, list3.ToArray(), version2, bindingType2);
				}
			}
		}

		// Token: 0x060455DB RID: 284123 RVA: 0x0122058C File Offset: 0x0121E78C
		private void BuildAxisBindingToProtoData(bool isOldVersionData, OneDeviceInputSetting keyboardInputSettings, OneDeviceInputSetting gamepadInputSettings)
		{
			foreach (KeyValuePair<string, InputAxisBinding> keyValuePair in Singleton<InputSettingsManager>.Instance.GetAxisBindingMap())
			{
				string text;
				InputAxisBinding inputAxisBinding;
				keyValuePair.Deconstruct(out text, out inputAxisBinding);
				string axisName = text;
				InputAxisBinding inputAxisBinding2 = inputAxisBinding;
				foreach (KeyValuePair<EInputBindingType, Dictionary<string, float>> keyValuePair2 in inputAxisBinding2.GetAllPcKeyScaleMap())
				{
					EInputBindingType einputBindingType;
					Dictionary<string, float> dictionary;
					keyValuePair2.Deconstruct(out einputBindingType, out dictionary);
					EInputBindingType bindingType = einputBindingType;
					Dictionary<string, float> keyScaleMap = dictionary;
					EKeySettingExclusiveType exclusiveTypeByBindingType = Singleton<InputSettingsManager>.Instance.GetExclusiveTypeByBindingType(bindingType);
					int version = isOldVersionData ? 0 : inputAxisBinding2.GetKeyboardVersion(exclusiveTypeByBindingType);
					this.BuildAxisKey(axisName, keyboardInputSettings, keyScaleMap, version, bindingType);
				}
				foreach (KeyValuePair<EInputBindingType, Dictionary<string, float>> keyValuePair2 in inputAxisBinding2.GetAllGamepadKeyScaleMap())
				{
					EInputBindingType einputBindingType;
					Dictionary<string, float> dictionary;
					keyValuePair2.Deconstruct(out einputBindingType, out dictionary);
					EInputBindingType bindingType2 = einputBindingType;
					Dictionary<string, float> keyScaleMap2 = dictionary;
					EKeySettingExclusiveType exclusiveTypeByBindingType2 = Singleton<InputSettingsManager>.Instance.GetExclusiveTypeByBindingType(bindingType2);
					int version2 = isOldVersionData ? 0 : inputAxisBinding2.GetGamepadVersion(exclusiveTypeByBindingType2);
					this.BuildAxisKey(axisName, gamepadInputSettings, keyScaleMap2, version2, bindingType2);
				}
			}
		}

		// Token: 0x060455DC RID: 284124 RVA: 0x01220708 File Offset: 0x0121E908
		private void BuildCombinationActionBindingToProtoData(bool isOldVersionData, OneDeviceInputSetting keyboardInputSettings, OneDeviceInputSetting gamepadInputSettings)
		{
			foreach (KeyValuePair<string, InputCombinationActionBinding> keyValuePair in Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingMap())
			{
				string text;
				InputCombinationActionBinding inputCombinationActionBinding;
				keyValuePair.Deconstruct(out text, out inputCombinationActionBinding);
				string actionName = text;
				InputCombinationActionBinding inputCombinationActionBinding2 = inputCombinationActionBinding;
				Dictionary<EInputBindingType, Dictionary<string, string>> dictionary = new Dictionary<EInputBindingType, Dictionary<string, string>>();
				inputCombinationActionBinding2.GetAllPcKeyNameMap(dictionary);
				foreach (KeyValuePair<EInputBindingType, Dictionary<string, string>> keyValuePair2 in dictionary)
				{
					EInputBindingType einputBindingType;
					Dictionary<string, string> dictionary2;
					keyValuePair2.Deconstruct(out einputBindingType, out dictionary2);
					EInputBindingType bindingType = einputBindingType;
					Dictionary<string, string> keyMap = dictionary2;
					EKeySettingExclusiveType exclusiveTypeByBindingType = Singleton<InputSettingsManager>.Instance.GetExclusiveTypeByBindingType(bindingType);
					int version = isOldVersionData ? 0 : inputCombinationActionBinding2.GetKeyboardVersion(exclusiveTypeByBindingType);
					this.BuildCombinationActionKey(actionName, keyboardInputSettings, keyMap, version, bindingType);
				}
				Dictionary<EInputBindingType, Dictionary<string, string>> dictionary3 = new Dictionary<EInputBindingType, Dictionary<string, string>>();
				inputCombinationActionBinding2.GetAllGamepadKeyNameMap(dictionary3);
				foreach (KeyValuePair<EInputBindingType, Dictionary<string, string>> keyValuePair2 in dictionary3)
				{
					EInputBindingType einputBindingType;
					Dictionary<string, string> dictionary2;
					keyValuePair2.Deconstruct(out einputBindingType, out dictionary2);
					EInputBindingType bindingType2 = einputBindingType;
					Dictionary<string, string> keyMap2 = dictionary2;
					EKeySettingExclusiveType exclusiveTypeByBindingType2 = Singleton<InputSettingsManager>.Instance.GetExclusiveTypeByBindingType(bindingType2);
					int version2 = isOldVersionData ? 0 : inputCombinationActionBinding2.GetGamepadVersion(exclusiveTypeByBindingType2);
					this.BuildCombinationActionKey(actionName, gamepadInputSettings, keyMap2, version2, bindingType2);
				}
			}
		}

		// Token: 0x060455DD RID: 284125 RVA: 0x0122089C File Offset: 0x0121EA9C
		private void BuildCombinationAxisBindingToProtoData(bool isOldVersionData, OneDeviceInputSetting keyboardInputSettings, OneDeviceInputSetting gamepadInputSettings)
		{
			foreach (KeyValuePair<string, InputCombinationAxisBinding> keyValuePair in Singleton<InputSettingsManager>.Instance.GetCombinationAxisBindingMap())
			{
				string text;
				InputCombinationAxisBinding inputCombinationAxisBinding;
				keyValuePair.Deconstruct(out text, out inputCombinationAxisBinding);
				string axisName = text;
				InputCombinationAxisBinding inputCombinationAxisBinding2 = inputCombinationAxisBinding;
				Dictionary<EInputBindingType, Dictionary<string, string>> dictionary = new Dictionary<EInputBindingType, Dictionary<string, string>>();
				inputCombinationAxisBinding2.GetAllPcKeyNameMap(dictionary);
				foreach (KeyValuePair<EInputBindingType, Dictionary<string, string>> keyValuePair2 in dictionary)
				{
					EInputBindingType einputBindingType;
					Dictionary<string, string> dictionary2;
					keyValuePair2.Deconstruct(out einputBindingType, out dictionary2);
					EInputBindingType bindingType = einputBindingType;
					Dictionary<string, string> keyMap = dictionary2;
					EKeySettingExclusiveType exclusiveTypeByBindingType = Singleton<InputSettingsManager>.Instance.GetExclusiveTypeByBindingType(bindingType);
					int version = isOldVersionData ? 0 : inputCombinationAxisBinding2.GetKeyboardVersion(exclusiveTypeByBindingType);
					this.BuildCombinationAxisKey(axisName, keyboardInputSettings, keyMap, version, bindingType);
				}
				Dictionary<EInputBindingType, Dictionary<string, string>> dictionary3 = new Dictionary<EInputBindingType, Dictionary<string, string>>();
				inputCombinationAxisBinding2.GetAllGamepadKeyNameMap(dictionary3);
				foreach (KeyValuePair<EInputBindingType, Dictionary<string, string>> keyValuePair2 in dictionary3)
				{
					EInputBindingType einputBindingType;
					Dictionary<string, string> dictionary2;
					keyValuePair2.Deconstruct(out einputBindingType, out dictionary2);
					EInputBindingType bindingType2 = einputBindingType;
					Dictionary<string, string> keyMap2 = dictionary2;
					EKeySettingExclusiveType exclusiveTypeByBindingType2 = Singleton<InputSettingsManager>.Instance.GetExclusiveTypeByBindingType(bindingType2);
					int version2 = isOldVersionData ? 0 : inputCombinationAxisBinding2.GetGamepadVersion(exclusiveTypeByBindingType2);
					this.BuildCombinationAxisKey(axisName, gamepadInputSettings, keyMap2, version2, bindingType2);
				}
			}
		}

		// Token: 0x060455DE RID: 284126 RVA: 0x01220A30 File Offset: 0x0121EC30
		private void BuildActionKey(string actionName, OneDeviceInputSetting inputSettings, string[] keyNameList, int version, EInputBindingType bindingType)
		{
			SettingInputType inputType = this.InputBindTypeMap[bindingType];
			InputAction inputAction = InputAction.Create();
			inputAction.ActionName = actionName;
			inputAction.Version = version;
			inputAction.InputType = inputType;
			inputAction.KeyNameList.AddRange(keyNameList);
			inputSettings.InputAction.Add(inputAction);
		}

		// Token: 0x060455DF RID: 284127 RVA: 0x01220A80 File Offset: 0x0121EC80
		private void BuildAxisKey(string axisName, OneDeviceInputSetting inputSettings, IReadOnlyDictionary<string, float> keyScaleMap, int version, EInputBindingType bindingType)
		{
			SettingInputType inputType = this.InputBindTypeMap[bindingType];
			InputAxis inputAxis = InputAxis.Create();
			inputAxis.AxisName = axisName;
			inputAxis.Version = version;
			inputAxis.InputType = inputType;
			foreach (KeyValuePair<string, float> keyValuePair in keyScaleMap)
			{
				string text;
				float num;
				keyValuePair.Deconstruct(out text, out num);
				string key = text;
				int value = (int)Math.Round((double)(num * 1000f));
				inputAxis.KeyScaleMap[key] = value;
			}
			inputSettings.InputAxis.Add(inputAxis);
		}

		// Token: 0x060455E0 RID: 284128 RVA: 0x01220B28 File Offset: 0x0121ED28
		private void BuildCombinationActionKey(string actionName, OneDeviceInputSetting inputSettings, Dictionary<string, string> keyMap, int version, EInputBindingType bindingType)
		{
			SettingInputType inputType = this.InputBindTypeMap[bindingType];
			Aki.Protocol.CombinationAction combinationAction = Aki.Protocol.CombinationAction.Create();
			combinationAction.ActionName = actionName;
			combinationAction.Version = version;
			combinationAction.InputType = inputType;
			foreach (KeyValuePair<string, string> keyValuePair in keyMap)
			{
				string text;
				string text2;
				keyValuePair.Deconstruct(out text, out text2);
				string text3 = text;
				string text4 = text2;
				CombinationKey combinationKey = CombinationKey.Create();
				combinationKey.KeyNameList.AddRange(new <>z__ReadOnlyArray<string>(new string[]
				{
					text3,
					text4
				}));
				combinationAction.CombinationKeyList.Add(combinationKey);
			}
			inputSettings.InputCombinationAction.Add(combinationAction);
		}

		// Token: 0x060455E1 RID: 284129 RVA: 0x01220BEC File Offset: 0x0121EDEC
		private void BuildCombinationAxisKey(string axisName, OneDeviceInputSetting inputSettings, Dictionary<string, string> keyMap, int version, EInputBindingType bindingType)
		{
			SettingInputType inputType = this.InputBindTypeMap[bindingType];
			Aki.Protocol.CombinationAxis combinationAxis = Aki.Protocol.CombinationAxis.Create();
			combinationAxis.AxisName = axisName;
			combinationAxis.Version = version;
			combinationAxis.InputType = inputType;
			foreach (KeyValuePair<string, string> keyValuePair in keyMap)
			{
				string text;
				string text2;
				keyValuePair.Deconstruct(out text, out text2);
				string text3 = text;
				string text4 = text2;
				CombinationKey combinationKey = CombinationKey.Create();
				combinationKey.KeyNameList.AddRange(new <>z__ReadOnlyArray<string>(new string[]
				{
					text3,
					text4
				}));
				combinationAxis.CombinationKeyList.Add(combinationKey);
			}
			inputSettings.InputCombinationAxis.Add(combinationAxis);
		}

		// Token: 0x04026AE3 RID: 158435
		private readonly Dictionary<EInputBindingType, SettingInputType> InputBindTypeMap = new Dictionary<EInputBindingType, SettingInputType>
		{
			{
				EInputBindingType.Original,
				SettingInputType.Normal
			},
			{
				EInputBindingType.Motor,
				SettingInputType.Motorcycle
			}
		};
	}
}
