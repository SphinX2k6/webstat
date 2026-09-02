using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F96 RID: 20374
	[NullableContext(1)]
	[Nullable(0)]
	public class SkillButtonUiMotorcycleGamepadData : SkillButtonUiGamepadDataBase
	{
		// Token: 0x0603496F RID: 215407 RVA: 0x00D2FA14 File Offset: 0x00D2DC14
		public override void Init()
		{
			this.GamepadDataType = ESkillButtonGamepadDataType.Motorcycle;
			this.IsPressCombineButton = false;
			this.InitAllActionNameList();
			this.InitGamepadIcon();
			this.SwitchInteractData.Init(ESkillButtonGamepadDataType.Motorcycle, "载具探索工具");
			this.RefreshBaseConfigByUserSetting();
			this.RefreshSwitchInteractOpen(true);
			this.RefreshButtonData();
		}

		// Token: 0x06034970 RID: 215408 RVA: 0x00D2FA60 File Offset: 0x00D2DC60
		public override void Clear()
		{
			this.ControlCameraByMoveAxis = false;
			this.ClearInputAxis();
		}

		// Token: 0x06034971 RID: 215409 RVA: 0x00D2FA70 File Offset: 0x00D2DC70
		private void InitAllActionNameList()
		{
			foreach (string item in SkillButtonUiMotorcycleGamepadData.actionNameToButtonTypeMap.Keys)
			{
				this.AllActionNameList.Add(item);
			}
		}

		// Token: 0x06034972 RID: 215410 RVA: 0x00D2FACC File Offset: 0x00D2DCCC
		public override IReadOnlyList<string> GetAllActionNameList()
		{
			return this.AllActionNameList;
		}

		// Token: 0x06034973 RID: 215411 RVA: 0x00D2FAD4 File Offset: 0x00D2DCD4
		public override IReadOnlyList<string> GetAllAxisNameList()
		{
			return SkillButtonUiMotorcycleGamepadData.initAxisNames;
		}

		// Token: 0x06034974 RID: 215412 RVA: 0x00D2FADB File Offset: 0x00D2DCDB
		private void InitGamepadIcon()
		{
			this.NoneIcon = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconXboxNoneIcon");
		}

		// Token: 0x06034975 RID: 215413 RVA: 0x00D2FAF4 File Offset: 0x00D2DCF4
		public override void RefreshBaseConfigByUserSetting()
		{
			this.CombineButtonKey = EKey.Gamepad_LeftShoulder;
			this.ButtonKeyList.Clear();
			foreach (string item in SkillButtonUiMotorcycleGamepadData.mainKeys)
			{
				this.ButtonKeyList.Add(item);
			}
			foreach (string item2 in SkillButtonUiMotorcycleGamepadData.dPadKeys)
			{
				this.ButtonKeyList.Add(item2);
			}
			foreach (string text in SkillButtonUiMotorcycleGamepadData.subKeys)
			{
				if (!(text == this.CombineButtonKey))
				{
					this.ButtonKeyList.Add(text);
				}
			}
			this.ButtonKeyList.Add(EKey.Gamepad_RightThumbstick);
			this.ButtonKeyToActionNameMap.Clear();
			foreach (string text2 in SkillButtonUiMotorcycleGamepadData.initActionNames)
			{
				InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding(text2);
				if (actionBinding != null)
				{
					List<string> list = new List<string>();
					actionBinding.GetKeyNameList(list);
					if (list != null && list.Count != 0)
					{
						foreach (string text3 in list)
						{
							if (this.ButtonKeyList.Contains(text3))
							{
								this.ButtonKeyToActionNameMap[text3] = text2;
							}
						}
					}
				}
			}
			this.CombinationKeyToActionNameMap.Clear();
			foreach (string text4 in SkillButtonUiMotorcycleGamepadData.initActionNames)
			{
				InputCombinationActionBinding combinationActionBindingByActionName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName(text4);
				if (combinationActionBindingByActionName != null)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					combinationActionBindingByActionName.GetKeyMap(dictionary);
					foreach (KeyValuePair<string, string> keyValuePair in dictionary)
					{
						string key = keyValuePair.Key;
						string value = keyValuePair.Value;
						if (!(key != this.CombineButtonKey) && this.ButtonKeyList.Contains(value))
						{
							this.CombinationKeyToActionNameMap[value] = text4;
						}
					}
				}
			}
			this.ButtonKeyToAxisKeyMap.Clear();
			foreach (string axisName in SkillButtonUiMotorcycleGamepadData.initAxisNames)
			{
				InputAxisBinding axisBinding = Singleton<InputSettingsManager>.Instance.GetAxisBinding(axisName);
				if (axisBinding != null)
				{
					for (int j = 0; j < 2; j++)
					{
						InputAxisKey gamepadKeyByIndex = axisBinding.GetGamepadKeyByIndex(j);
						if (gamepadKeyByIndex != null)
						{
							string valueOrDefault = SkillButtonUiMotorcycleGamepadData.axisToActionKey.GetValueOrDefault(gamepadKeyByIndex.KeyName, gamepadKeyByIndex.KeyName);
							if (!string.IsNullOrEmpty(valueOrDefault) && this.ButtonKeyList.Contains(valueOrDefault))
							{
								this.ButtonKeyToAxisKeyMap[valueOrDefault] = new SkillButtonAxisKey
								{
									AxisName = axisName,
									KeyName = valueOrDefault,
									Scale = gamepadKeyByIndex.Scale
								};
							}
						}
					}
				}
			}
			this.RefreshRouletteKey();
			this.RefreshMusicKey();
			this.RefreshSkillButtonTypeList();
			this.RefreshCombineButtonVisible();
		}

		// Token: 0x06034976 RID: 215414 RVA: 0x00D2FE3C File Offset: 0x00D2E03C
		private void RefreshRouletteKey()
		{
			this.RouletteKey = null;
			this.RouletteMainKey = null;
			this.RouletteSecondKey = null;
			string actionName = "幻象探索选择界面";
			InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding(actionName);
			IReadOnlyList<string> readOnlyList = (actionBinding != null) ? actionBinding.GetGamepadKeyNameListReadonly() : null;
			if (readOnlyList != null && readOnlyList.Count > 0 && readOnlyList[0] != EKey.Gamepad_Invalid)
			{
				this.RouletteKey = readOnlyList[0];
				return;
			}
			InputCombinationActionBinding combinationActionBindingByActionName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName(actionName);
			if (combinationActionBindingByActionName != null && combinationActionBindingByActionName.HasGamepadCombinationAction())
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				combinationActionBindingByActionName.GetGamepadKeyNameMap(dictionary);
				using (Dictionary<string, string>.Enumerator enumerator = dictionary.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						KeyValuePair<string, string> keyValuePair = enumerator.Current;
						this.RouletteMainKey = keyValuePair.Key;
						this.RouletteSecondKey = keyValuePair.Value;
					}
				}
			}
		}

		// Token: 0x06034977 RID: 215415 RVA: 0x00D2FF2C File Offset: 0x00D2E12C
		private void RefreshMusicKey()
		{
			this.MusicSubKeyList.Clear();
			foreach (string text in SkillButtonUiMotorcycleGamepadData.musicActionNames)
			{
				InputCombinationActionBinding combinationActionBindingByActionName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName(text);
				if (combinationActionBindingByActionName != null)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					combinationActionBindingByActionName.GetKeyMap(dictionary);
					foreach (KeyValuePair<string, string> keyValuePair in dictionary)
					{
						string key = keyValuePair.Key;
						string value = keyValuePair.Value;
						if (!(key != this.CombineButtonKey))
						{
							this.MusicSubKeyList.Add(value);
							if (this.ButtonKeyList.Contains(value))
							{
								this.CombinationKeyToActionNameMap[value] = text;
							}
						}
					}
				}
			}
		}

		// Token: 0x06034978 RID: 215416 RVA: 0x00D30020 File Offset: 0x00D2E220
		private void RefreshSkillButtonTypeList()
		{
			Array.Resize<int>(ref this.MainSkillButtonTypeList, 4);
			Array.Resize<int>(ref this.MainSkillCombineButtonTypeList, 4);
			for (int i = 0; i < 4; i++)
			{
				this.MainSkillButtonTypeList[i] = (int)this.GetNormalSkillButtonTypeByIndex(i, false);
				this.MainSkillCombineButtonTypeList[i] = (int)this.GetNormalSkillButtonTypeByIndex(i, true);
			}
			Array.Resize<int>(ref this.DpadSkillButtonTypeList, 4);
			Array.Resize<int>(ref this.DpadSkillCombineButtonTypeList, 4);
			for (int j = 0; j < 4; j++)
			{
				this.DpadSkillButtonTypeList[j] = (int)this.GetNormalSkillButtonTypeByIndex(4 + j, false);
				this.DpadSkillCombineButtonTypeList[j] = (int)this.GetNormalSkillButtonTypeByIndex(4 + j, true);
			}
			Array.Resize<int>(ref this.SubSkillButtonTypeList, 3);
			Array.Resize<int>(ref this.SubSkillCombineButtonTypeList, 3);
			for (int k = 0; k < 3; k++)
			{
				this.SubSkillButtonTypeList[k] = (int)this.GetNormalSkillButtonTypeByIndex(8 + k, false);
				this.SubSkillCombineButtonTypeList[k] = (int)this.GetNormalSkillButtonTypeByIndex(8 + k, true);
			}
		}

		// Token: 0x06034979 RID: 215417 RVA: 0x00D30104 File Offset: 0x00D2E304
		private void RefreshCombineButtonVisible()
		{
			int[] array = this.MainSkillCombineButtonTypeList;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != 0)
				{
					this.IsShowCombineButton = true;
					return;
				}
			}
			array = this.SubSkillCombineButtonTypeList;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != 0)
				{
					this.IsShowCombineButton = true;
					return;
				}
			}
			this.IsShowCombineButton = false;
		}

		// Token: 0x0603497A RID: 215418 RVA: 0x00D3015C File Offset: 0x00D2E35C
		private ESkillButtonType GetNormalSkillButtonTypeByIndex(int index, bool isPressCombineButton)
		{
			string text = null;
			string key = this.ButtonKeyList[index];
			if (isPressCombineButton)
			{
				this.CombinationKeyToActionNameMap.TryGetValue(key, out text);
			}
			else
			{
				this.ButtonKeyToActionNameMap.TryGetValue(key, out text);
			}
			if (!string.IsNullOrEmpty(text))
			{
				int result;
				if (SkillButtonUiMotorcycleGamepadData.actionNameToButtonTypeMap.TryGetValue(text, out result))
				{
					return (ESkillButtonType)result;
				}
				return ESkillButtonType.None;
			}
			else
			{
				SkillButtonAxisKey skillButtonAxisKey;
				int[] array;
				if (isPressCombineButton || !this.ButtonKeyToAxisKeyMap.TryGetValue(key, out skillButtonAxisKey) || skillButtonAxisKey == null || !SkillButtonUiMotorcycleGamepadData.axisNameToButtonTypeMap.TryGetValue(skillButtonAxisKey.AxisName, out array) || array == null)
				{
					return ESkillButtonType.None;
				}
				if (skillButtonAxisKey.Scale != 1f)
				{
					return (ESkillButtonType)array[1];
				}
				return (ESkillButtonType)array[0];
			}
		}

		// Token: 0x0603497B RID: 215419 RVA: 0x00D301FC File Offset: 0x00D2E3FC
		public override void RefreshSwitchInteractOpen(bool isInit = false)
		{
			this.SwitchInteractData.RefreshSwitchInteractOpen(isInit);
		}

		// Token: 0x0603497C RID: 215420 RVA: 0x00D3020C File Offset: 0x00D2E40C
		public override bool RefreshButtonData()
		{
			this.RefreshStateByTag();
			List<int?> curButtonTypeList = this.CurButtonTypeList;
			this.CurButtonTypeList = this.LastButtonTypeList;
			this.LastButtonTypeList = curButtonTypeList;
			this.CurButtonTypeList.Clear();
			if (!this.IsPressCombineButton)
			{
				for (int i = 0; i < 4; i++)
				{
					this.CurButtonTypeList.Add(this.GetButtonTypeByIndex(this.MainSkillButtonTypeList, i, false));
				}
				for (int j = 0; j < 4; j++)
				{
					this.CurButtonTypeList.Add(this.GetButtonTypeByIndex(this.MainSkillCombineButtonTypeList, j, true));
				}
				for (int k = 0; k < 4; k++)
				{
					this.CurButtonTypeList.Add(this.GetButtonTypeByIndex(this.DpadSkillButtonTypeList, k, false));
				}
				for (int l = 0; l < 3; l++)
				{
					this.PushSubSkillButton(this.SubSkillButtonTypeList[l]);
				}
				this.CurButtonTypeList.Add(null);
			}
			else
			{
				for (int m = 0; m < 4; m++)
				{
					int? buttonTypeByIndex = this.GetButtonTypeByIndex(this.MainSkillCombineButtonTypeList, m, false);
					if (this.MainSkillCombineButtonTypeList[m] != 0)
					{
						this.CurButtonTypeList.Add(buttonTypeByIndex);
					}
					else
					{
						this.CurButtonTypeList.Add(this.GetButtonTypeByIndex(this.MainSkillButtonTypeList, m, false));
					}
				}
				for (int n = 0; n < 4; n++)
				{
					this.CurButtonTypeList.Add(this.GetButtonTypeByIndex(this.MainSkillCombineButtonTypeList, n, true));
				}
				for (int num = 0; num < 4; num++)
				{
					int? buttonTypeByIndex2 = this.GetButtonTypeByIndex(this.DpadSkillCombineButtonTypeList, num, false);
					if (this.DpadSkillCombineButtonTypeList[num] != 0)
					{
						this.CurButtonTypeList.Add(buttonTypeByIndex2);
					}
					else
					{
						this.CurButtonTypeList.Add(this.GetButtonTypeByIndex(this.DpadSkillButtonTypeList, num, false));
					}
				}
				for (int num2 = 0; num2 < 3; num2++)
				{
					this.PushSubSkillButton(this.SubSkillCombineButtonTypeList[num2]);
				}
			}
			if (this.ShootEnable)
			{
				int num3 = this.CurButtonTypeList.IndexOf(new int?(1));
				if (num3 != -1)
				{
					this.CurButtonTypeList[num3] = new int?(4);
				}
			}
			int count = this.CurButtonTypeList.Count;
			if (count != this.LastButtonTypeList.Count)
			{
				return true;
			}
			for (int num4 = 0; num4 < count; num4++)
			{
				int? num5 = this.CurButtonTypeList[num4];
				int? num6 = this.LastButtonTypeList[num4];
				if (!(num5.GetValueOrDefault() == num6.GetValueOrDefault() & num5 != null == (num6 != null)))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603497D RID: 215421 RVA: 0x00D30494 File Offset: 0x00D2E694
		private int? GetButtonTypeByIndex(int[] buttonTypeList, int index, bool isSecondButton = false)
		{
			int num = buttonTypeList[index];
			if ((num == 101 || this.CheckSkillButtonVisibleByButtonType(num).GetValueOrDefault()) && this.CheckSkillButtonVisibleByState(num, isSecondButton))
			{
				return new int?(num);
			}
			return new int?(0);
		}

		// Token: 0x0603497E RID: 215422 RVA: 0x00D304D2 File Offset: 0x00D2E6D2
		private bool CheckSkillButtonVisibleByState(int buttonType, bool isSecondButton = false)
		{
			return (this.CurStateTagId == 0 || this.StateButtonTypeList == null || this.StateButtonTypeList.Contains(buttonType)) && (!isSecondButton || SkillButtonUiMotorcycleGamepadData.mainSecondButtonTypeSet.Contains(buttonType));
		}

		// Token: 0x0603497F RID: 215423 RVA: 0x00D30508 File Offset: 0x00D2E708
		private bool? CheckSkillButtonVisibleByButtonType(int buttonType)
		{
			if (buttonType == 0)
			{
				return new bool?(false);
			}
			SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
			SkillButtonData skillButtonData = (instance != null) ? instance.GetSkillButtonDataByButton((ESkillButtonType)buttonType) : null;
			if (skillButtonData != null)
			{
				return new bool?(skillButtonData.IsVisible());
			}
			BehaviorButtonData behaviorButtonData = (instance != null) ? instance.GetBehaviorButtonDataByButton((EBehaviorType)buttonType) : null;
			if (behaviorButtonData == null)
			{
				return null;
			}
			return new bool?(behaviorButtonData.IsVisible());
		}

		// Token: 0x06034980 RID: 215424 RVA: 0x00D30568 File Offset: 0x00D2E768
		private void PushSubSkillButton(int buttonType)
		{
			if (this.CurStateTagId != 0)
			{
				if (!this.CheckSkillButtonVisibleByState(buttonType, false))
				{
					this.CurButtonTypeList.Add(null);
					return;
				}
				this.CurButtonTypeList.Add(new int?(buttonType));
				return;
			}
			else
			{
				if (!SkillButtonUiMotorcycleGamepadData.subButtonTypeSet.Contains(buttonType))
				{
					this.CurButtonTypeList.Add(null);
					return;
				}
				this.CurButtonTypeList.Add(new int?(buttonType));
				return;
			}
		}

		// Token: 0x06034981 RID: 215425 RVA: 0x00D305E4 File Offset: 0x00D2E7E4
		private void RefreshStateByTag()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null || !getCurrentEntity.Valid)
			{
				return;
			}
			BaseTagComponent baseTagComponent = getCurrentEntity.Entity.CheckGetComponent<BaseTagComponent>();
			this.ShootEnable = baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.功能开关.移动端浮游炮攻击按钮"]);
			this.CurStateTagId = 0;
			this.StateButtonTypeList = null;
			SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
			Dictionary<int, IntArray> dictionary;
			if (instance == null)
			{
				dictionary = null;
			}
			else
			{
				SkillButtonIndexData curSkillButtonIndexData = instance.CurSkillButtonIndexData;
				dictionary = ((curSkillButtonIndexData != null) ? ((curSkillButtonIndexData.ButtonIndexConfig != null) ? curSkillButtonIndexData.ButtonIndexConfig.GetValueOrDefault().GamepadButtonTypeMap() : null) : null);
			}
			Dictionary<int, IntArray> dictionary2 = dictionary;
			if (dictionary2 == null)
			{
				return;
			}
			foreach (KeyValuePair<int, IntArray> keyValuePair in dictionary2)
			{
				int key = keyValuePair.Key;
				IntArray value = keyValuePair.Value;
				if (baseTagComponent.HasTag(key))
				{
					this.CurStateTagId = key;
					List<int> list = new List<int>();
					for (int i = 0; i < value.ArrayIntLength; i++)
					{
						list.Add(value.ArrayInt(i));
					}
					this.StateButtonTypeList = list;
					break;
				}
			}
		}

		// Token: 0x06034982 RID: 215426 RVA: 0x00D30710 File Offset: 0x00D2E910
		public override int GetButtonTypeByActionName(string actionName)
		{
			int result;
			if (!SkillButtonUiMotorcycleGamepadData.actionNameToButtonTypeMap.TryGetValue(actionName, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x06034983 RID: 215427 RVA: 0x00D30730 File Offset: 0x00D2E930
		public override int GetButtonTypeByAxisName(string axisName, float value)
		{
			int[] array;
			if (!SkillButtonUiMotorcycleGamepadData.axisNameToButtonTypeMap.TryGetValue(axisName, out array) || array == null)
			{
				return 0;
			}
			if (value <= 0f)
			{
				return array[1];
			}
			return array[0];
		}

		// Token: 0x06034984 RID: 215428 RVA: 0x00D30760 File Offset: 0x00D2E960
		public override void SetIsPressCombineButton(bool value)
		{
			if (this.IsPressCombineButton == value)
			{
				return;
			}
			this.IsPressCombineButton = value;
			this.RefreshButtonData();
		}

		// Token: 0x06034985 RID: 215429 RVA: 0x00D3077A File Offset: 0x00D2E97A
		public override bool GetIsPressCombineButton()
		{
			return this.IsPressCombineButton;
		}

		// Token: 0x06034986 RID: 215430 RVA: 0x00D30782 File Offset: 0x00D2E982
		[NullableContext(2)]
		public BehaviorButtonData GetBehaviorButtonDataByButtonType(EBehaviorType buttonType)
		{
			return ModelBase<SkillButtonUiModel>.Instance.GetBehaviorButtonDataByButton(buttonType);
		}

		// Token: 0x06034987 RID: 215431 RVA: 0x00D3078F File Offset: 0x00D2E98F
		public override void RefreshSkillButtonData(ESkillButtonRefreshReason refreshReason)
		{
			if (refreshReason == ESkillButtonRefreshReason.ChangeRole)
			{
				this.RefreshButtonData();
			}
		}

		// Token: 0x06034988 RID: 215432 RVA: 0x00D3079C File Offset: 0x00D2E99C
		public override void RefreshInteractBehaviorData()
		{
			BehaviorButtonData behaviorButtonDataByButtonType = this.GetBehaviorButtonDataByButtonType(EBehaviorType.Interact);
			if (behaviorButtonDataByButtonType == null)
			{
				return;
			}
			bool flag = Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InteractionHintView);
			behaviorButtonDataByButtonType.SetEnable(flag);
			this.SwitchInteractData.SetInteractExist(flag, EGamepadInteractExistReason.InteractView);
		}

		// Token: 0x06034989 RID: 215433 RVA: 0x00D307DC File Offset: 0x00D2E9DC
		public override void OnActionKeyChanged(string actionName)
		{
			if (actionName == "幻象探索选择界面")
			{
				this.RefreshRouletteKey();
				Singleton<EventSystem>.Instance.Emit(EEventName.BattleUiRouletteKeyChanged);
				return;
			}
			if (this.AllowChangeKeyReasonSet.Count > 0)
			{
				return;
			}
			if (this.ChangeKeyReasonSet.Count > 0)
			{
				if (this.ChangeKeyActionInMenuView)
				{
					return;
				}
				if (SkillButtonUiMotorcycleGamepadData.initActionNames.Contains(actionName))
				{
					this.ChangeKeyActionInMenuView = true;
				}
				return;
			}
			else
			{
				if (this.LockRefresh)
				{
					return;
				}
				if (SkillButtonUiMotorcycleGamepadData.initActionNames.Contains(actionName))
				{
					Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "在未知情况下触发了改键", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				return;
			}
		}

		// Token: 0x0603498A RID: 215434 RVA: 0x00D3087A File Offset: 0x00D2EA7A
		public override void AddChangeKeyReason(EGamepadChangeKeyReason reason)
		{
			this.ChangeKeyReasonSet.Add(reason);
		}

		// Token: 0x0603498B RID: 215435 RVA: 0x00D3088C File Offset: 0x00D2EA8C
		public override void RemoveChangeKeyReason(EGamepadChangeKeyReason reason)
		{
			this.ChangeKeyReasonSet.Remove(reason);
			if (this.ChangeKeyReasonSet.Count != 0)
			{
				return;
			}
			if (this.ChangeKeyActionInMenuView)
			{
				this.ChangeKeyActionInMenuView = false;
				this.RefreshBaseConfigByUserSetting();
			}
			this.RefreshButtonData();
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
				if (instance == null)
				{
					return;
				}
				SkillButtonEntityData curSkillButtonEntityData = instance.GetCurSkillButtonEntityData();
				if (curSkillButtonEntityData == null)
				{
					return;
				}
				curSkillButtonEntityData.RefreshSkillButtonData(ESkillButtonRefreshReason.GamepadRefreshKeyAction);
			}
		}

		// Token: 0x0603498C RID: 215436 RVA: 0x00D308F6 File Offset: 0x00D2EAF6
		public override void AddAllowChangeKeyReason(string reason)
		{
			this.AllowChangeKeyReasonSet.Add(reason);
		}

		// Token: 0x0603498D RID: 215437 RVA: 0x00D30905 File Offset: 0x00D2EB05
		public override void RemoveAllowChangeKeyReason(string reason)
		{
			this.AllowChangeKeyReasonSet.Remove(reason);
		}

		// Token: 0x0603498E RID: 215438 RVA: 0x00D30914 File Offset: 0x00D2EB14
		public override void CacheInputAxis(in EInputAxis axis, float value)
		{
			this.InputAxisMap[axis] = value;
		}

		// Token: 0x0603498F RID: 215439 RVA: 0x00D30928 File Offset: 0x00D2EB28
		public override float GetInputAxis(in EInputAxis axis)
		{
			return this.InputAxisMap.GetValueOrDefault(axis, 0f);
		}

		// Token: 0x06034990 RID: 215440 RVA: 0x00D30940 File Offset: 0x00D2EB40
		public override void ClearInputAxis()
		{
			this.InputAxisMap.Clear();
		}

		// Token: 0x06034992 RID: 215442 RVA: 0x00D309BC File Offset: 0x00D2EBBC
		// Note: this type is marked as 'beforefieldinit'.
		static SkillButtonUiMotorcycleGamepadData()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string key = EKey.Gamepad_LeftTriggerAxis;
			dictionary[key] = EKey.Gamepad_LeftTrigger;
			string key2 = EKey.Gamepad_RightTriggerAxis;
			dictionary[key2] = EKey.Gamepad_RightTrigger;
			SkillButtonUiMotorcycleGamepadData.axisToActionKey = dictionary;
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
			dictionary2["载具漂移"] = 1;
			dictionary2["载具氮气"] = 5;
			dictionary2["载具子弹跳"] = 6;
			dictionary2["载具辅助机攻击"] = 4;
			dictionary2["载具探索工具"] = 7;
			dictionary2["载具退场技和下车"] = 8;
			dictionary2["通用交互"] = 104;
			dictionary2["载具视角切换"] = 101;
			SkillButtonUiMotorcycleGamepadData.actionNameToButtonTypeMap = dictionary2;
			Dictionary<string, int[]> dictionary3 = new Dictionary<string, int[]>();
			dictionary3["MotorMoveForward"] = new int[]
			{
				201,
				202
			};
			SkillButtonUiMotorcycleGamepadData.axisNameToButtonTypeMap = dictionary3;
			SkillButtonUiMotorcycleGamepadData.initActionNames = new <>z__ReadOnlyArray<string>(new string[]
			{
				"载具漂移",
				"载具氮气",
				"载具子弹跳",
				"载具探索工具",
				"载具退场技和下车",
				"通用交互",
				"载具视角切换"
			});
			SkillButtonUiMotorcycleGamepadData.initAxisNames = new string[]
			{
				"MotorMoveForward"
			};
			SkillButtonUiMotorcycleGamepadData.mainSecondButtonTypeSet = new HashSet<int>
			{
				1,
				5,
				6,
				8,
				7,
				104,
				101,
				201,
				202
			};
			SkillButtonUiMotorcycleGamepadData.subButtonTypeSet = new HashSet<int>
			{
				1,
				5,
				6,
				8,
				7,
				104,
				101,
				201,
				202
			};
			SkillButtonUiMotorcycleGamepadData.musicActionNames = new <>z__ReadOnlyArray<string>(new string[]
			{
				"载具音乐上一首",
				"载具音乐下一首",
				"载具音乐播放暂停"
			});
		}

		// Token: 0x0401E506 RID: 124166
		[StaticVariableRuleIgnore]
		private static readonly string[] mainKeys = new string[]
		{
			EKey.Gamepad_FaceButton_Top,
			EKey.Gamepad_FaceButton_Left,
			EKey.Gamepad_FaceButton_Bottom,
			EKey.Gamepad_FaceButton_Right
		};

		// Token: 0x0401E507 RID: 124167
		private const int MAIN_HALF_NUM = 4;

		// Token: 0x0401E508 RID: 124168
		[StaticVariableRuleIgnore]
		private static readonly string[] dPadKeys = new string[]
		{
			EKey.Gamepad_DPad_Up,
			EKey.Gamepad_DPad_Left,
			EKey.Gamepad_DPad_Down,
			EKey.Gamepad_DPad_Right
		};

		// Token: 0x0401E509 RID: 124169
		private const int DPAD_KEY_NUM = 4;

		// Token: 0x0401E50A RID: 124170
		[StaticVariableRuleIgnore]
		private static readonly string[] subKeys = new string[]
		{
			EKey.Gamepad_LeftTrigger,
			EKey.Gamepad_RightTrigger,
			EKey.Gamepad_LeftShoulder,
			EKey.Gamepad_RightShoulder
		};

		// Token: 0x0401E50B RID: 124171
		private const int SUB_KEY_NUM = 3;

		// Token: 0x0401E50C RID: 124172
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<string, string> axisToActionKey;

		// Token: 0x0401E50D RID: 124173
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<string, int> actionNameToButtonTypeMap;

		// Token: 0x0401E50E RID: 124174
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<string, int[]> axisNameToButtonTypeMap;

		// Token: 0x0401E50F RID: 124175
		private static readonly IReadOnlyList<string> initActionNames;

		// Token: 0x0401E510 RID: 124176
		[StaticVariableRuleIgnore]
		private static readonly string[] initAxisNames;

		// Token: 0x0401E511 RID: 124177
		[StaticVariableRuleIgnore]
		private static readonly HashSet<int> mainSecondButtonTypeSet;

		// Token: 0x0401E512 RID: 124178
		[StaticVariableRuleIgnore]
		private static readonly HashSet<int> subButtonTypeSet;

		// Token: 0x0401E513 RID: 124179
		private static readonly IReadOnlyList<string> musicActionNames;

		// Token: 0x0401E514 RID: 124180
		private readonly List<string> AllActionNameList = new List<string>();

		// Token: 0x0401E515 RID: 124181
		public readonly HashSet<string> AllowChangeKeyReasonSet = new HashSet<string>();

		// Token: 0x0401E516 RID: 124182
		private readonly HashSet<EGamepadChangeKeyReason> ChangeKeyReasonSet = new HashSet<EGamepadChangeKeyReason>();

		// Token: 0x0401E517 RID: 124183
		private readonly Dictionary<string, string> ButtonKeyToActionNameMap = new Dictionary<string, string>();

		// Token: 0x0401E518 RID: 124184
		private readonly Dictionary<string, string> CombinationKeyToActionNameMap = new Dictionary<string, string>();

		// Token: 0x0401E519 RID: 124185
		private readonly Dictionary<string, SkillButtonAxisKey> ButtonKeyToAxisKeyMap = new Dictionary<string, SkillButtonAxisKey>();

		// Token: 0x0401E51A RID: 124186
		private bool IsPressCombineButton;

		// Token: 0x0401E51B RID: 124187
		public bool IsShowCombineButton;

		// Token: 0x0401E51C RID: 124188
		private bool ChangeKeyActionInMenuView;

		// Token: 0x0401E51D RID: 124189
		private readonly bool LockRefresh;

		// Token: 0x0401E51E RID: 124190
		public bool ShootEnable;

		// Token: 0x0401E51F RID: 124191
		public int CurStateTagId;

		// Token: 0x0401E520 RID: 124192
		[Nullable(2)]
		public List<int> StateButtonTypeList;

		// Token: 0x0401E521 RID: 124193
		private readonly Dictionary<EInputAxis, float> InputAxisMap = new Dictionary<EInputAxis, float>();

		// Token: 0x0401E522 RID: 124194
		public List<string> MusicSubKeyList = new List<string>();
	}
}
