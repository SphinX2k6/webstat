using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F93 RID: 20371
	[NullableContext(1)]
	[Nullable(0)]
	public class SkillButtonUiGamepadData : SkillButtonUiGamepadDataBase
	{
		// Token: 0x060348FD RID: 215293 RVA: 0x00D2CE84 File Offset: 0x00D2B084
		public override void Init()
		{
			this.GamepadDataType = ESkillButtonGamepadDataType.Normal;
			this.IsPressCombineButton = false;
			this.InitAllActionNameList();
			this.InitGamepadIcon();
			this.SwitchInteractData.Init(ESkillButtonGamepadDataType.Normal, "幻象1");
			this.RefreshBaseConfigByUserSetting();
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity != null && getCurrentEntity.Valid)
			{
				this.RefreshIsPhantomRole();
				this.RefreshFollowerAiming();
				this.ChangeSkillOnAimStateChange();
			}
			this.RefreshSwitchInteractOpen(true);
			this.RefreshButtonData();
		}

		// Token: 0x060348FE RID: 215294 RVA: 0x00D2CEFC File Offset: 0x00D2B0FC
		public override void Clear()
		{
			this.ControlCameraByMoveAxis = false;
			this.ClearInputAxis();
		}

		// Token: 0x060348FF RID: 215295 RVA: 0x00D2CF0C File Offset: 0x00D2B10C
		private void InitAllActionNameList()
		{
			this.AllActionNameList.Clear();
			foreach (string item in SkillButtonUiGamepadData.actionNameToButtonTypeMap.Keys)
			{
				this.AllActionNameList.Add(item);
			}
			this.AllActionNameList.Add("手柄主攻击");
			this.AllActionNameList.Add("手柄副攻击");
		}

		// Token: 0x06034900 RID: 215296 RVA: 0x00D2CF94 File Offset: 0x00D2B194
		public override IReadOnlyList<string> GetAllActionNameList()
		{
			return this.AllActionNameList;
		}

		// Token: 0x06034901 RID: 215297 RVA: 0x00D2CF9C File Offset: 0x00D2B19C
		private void InitGamepadIcon()
		{
			this.NoneIcon = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconXboxNoneIcon");
		}

		// Token: 0x06034902 RID: 215298 RVA: 0x00D2CFB4 File Offset: 0x00D2B1B4
		public unsafe override void RefreshBaseConfigByUserSetting()
		{
			this.CombineButtonKey = EKey.Gamepad_LeftShoulder;
			this.ButtonKeyList.Clear();
			foreach (string item in SkillButtonUiGamepadData.mainKeys)
			{
				this.ButtonKeyList.Add(item);
			}
			foreach (string item2 in SkillButtonUiGamepadData.dPadKeys)
			{
				this.ButtonKeyList.Add(item2);
			}
			foreach (string text in SkillButtonUiGamepadData.subKeys)
			{
				if (!(text == this.CombineButtonKey))
				{
					if (text == EKey.Gamepad_RightTrigger)
					{
						this.KeyRightTriggerIndex = this.ButtonKeyList.Count - 4 - 4;
					}
					this.ButtonKeyList.Add(text);
				}
			}
			this.ButtonKeyList.Add(EKey.Gamepad_RightThumbstick);
			this.ChangeSkillActionName = null;
			this.ChangeSkillAimKeys = null;
			this.AttackActionNormalKeys = null;
			this.AttackActionAimKeys = null;
			this.ButtonKeyToActionNameMap.Clear();
			foreach (string text2 in SkillButtonUiGamepadData.initActionNames)
			{
				InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding(text2);
				if (actionBinding != null)
				{
					List<string> list = new List<string>();
					actionBinding.GetKeyNameList(list);
					if (list.Count != 0)
					{
						foreach (string text3 in list)
						{
							if (this.ButtonKeyList.Contains(text3))
							{
								this.ButtonKeyToActionNameMap[text3] = text2;
								if (text3 == EKey.Gamepad_RightTrigger)
								{
									this.ChangeSkillActionName = text2;
									this.ChangeSkillAimKeys = list;
									List<string> list2 = new List<string>(this.ChangeSkillAimKeys);
									list2.RemoveAt(list2.IndexOf(text3));
									list2.Add(EKey.Gamepad_RightThumbstick);
									this.ChangeSkillAimKeys = list2;
								}
							}
						}
						if (text2 == "攻击")
						{
							this.AttackActionNormalKeys = list;
							this.AttackActionAimKeys = this.AttackActionNormalKeys;
							List<string> attackActionAimKeys = this.AttackActionAimKeys;
							int num = 1 + attackActionAimKeys.Count;
							List<string> list3 = new List<string>(num);
							CollectionsMarshal.SetCount<string>(list3, num);
							Span<string> span = CollectionsMarshal.AsSpan<string>(list3);
							int num2 = 0;
							Span<string> span2 = CollectionsMarshal.AsSpan<string>(attackActionAimKeys);
							span2.CopyTo(span.Slice(num2, span2.Length));
							num2 += span2.Length;
							*span[num2] = EKey.Gamepad_RightTrigger;
							List<string> attackActionAimKeys2 = list3;
							this.AttackActionAimKeys = attackActionAimKeys2;
						}
					}
				}
			}
			if (this.ChangeSkillActionName == "攻击")
			{
				InputActionBinding actionBinding2 = Singleton<InputSettingsManager>.Instance.GetActionBinding("攀爬");
				List<string> list4 = new List<string>();
				if (actionBinding2 != null)
				{
					actionBinding2.GetKeyNameList(list4);
				}
				this.ClimbActionNormalKeys = list4;
			}
			else
			{
				this.ClimbActionNormalKeys = null;
			}
			this.CombinationKeyToActionNameMap.Clear();
			foreach (string text4 in SkillButtonUiGamepadData.initActionNames)
			{
				InputCombinationActionBinding combinationActionBindingByActionName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName(text4);
				if (combinationActionBindingByActionName != null)
				{
					IReadOnlyDictionary<string, string> keyMap = combinationActionBindingByActionName.GetKeyMap();
					if (keyMap != null)
					{
						foreach (KeyValuePair<string, string> keyValuePair in keyMap)
						{
							string text5;
							string text6;
							keyValuePair.Deconstruct(out text5, out text6);
							string a = text5;
							string text7 = text6;
							if (!(a != this.CombineButtonKey) && this.ButtonKeyList.Contains(text7))
							{
								this.CombinationKeyToActionNameMap[text7] = text4;
							}
						}
					}
				}
			}
			this.RefreshGamepadMainAttackKey();
			this.RefreshRouletteKey();
			this.RefreshSkillButtonTypeList();
			this.RefreshCombineButtonVisible();
		}

		// Token: 0x06034903 RID: 215299 RVA: 0x00D2D380 File Offset: 0x00D2B580
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
						string text;
						string text2;
						keyValuePair.Deconstruct(out text, out text2);
						string rouletteMainKey = text;
						string rouletteSecondKey = text2;
						this.RouletteMainKey = rouletteMainKey;
						this.RouletteSecondKey = rouletteSecondKey;
					}
				}
			}
		}

		// Token: 0x06034904 RID: 215300 RVA: 0x00D2D478 File Offset: 0x00D2B678
		private void RefreshGamepadMainAttackKey()
		{
			InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding("手柄主攻击");
			InputActionBinding actionBinding2 = Singleton<InputSettingsManager>.Instance.GetActionBinding("攻击");
			IReadOnlyList<string> keyNameListA = (actionBinding != null) ? actionBinding.GetGamepadKeyNameList() : null;
			IReadOnlyList<string> readOnlyList = (actionBinding2 != null) ? actionBinding2.GetGamepadKeyNameList() : null;
			if (!this.CheckKeyNameListEqual(keyNameListA, readOnlyList))
			{
				List<string> list = new List<string>();
				if (readOnlyList != null)
				{
					list.AddRange(readOnlyList);
				}
				Singleton<InputSettingsManager>.Instance.SetActionKeys("手柄主攻击", list);
			}
			InputCombinationActionBinding combinationActionBindingByActionName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName("手柄主攻击");
			InputCombinationActionBinding combinationActionBindingByActionName2 = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName("攻击");
			IReadOnlyDictionary<string, string> readOnlyDictionary = (combinationActionBindingByActionName != null) ? combinationActionBindingByActionName.GetGamepadKeyNameMap() : null;
			IReadOnlyDictionary<string, string> readOnlyDictionary2 = (combinationActionBindingByActionName2 != null) ? combinationActionBindingByActionName2.GetGamepadKeyNameMap() : null;
			if (!this.CheckKeyNameMapEqual(readOnlyDictionary, readOnlyDictionary2))
			{
				if (readOnlyDictionary != null)
				{
					foreach (KeyValuePair<string, string> keyValuePair in readOnlyDictionary)
					{
						string text;
						string text2;
						keyValuePair.Deconstruct(out text, out text2);
						string mainKeyName = text;
						string secondaryKeyName = text2;
						EInputBindingType currentBindingType = combinationActionBindingByActionName.CurrentBindingType;
						Singleton<InputSettingsManager>.Instance.RemoveCombinationActionKeyMap("手柄主攻击", mainKeyName, secondaryKeyName, currentBindingType);
					}
				}
				if (readOnlyDictionary2 != null)
				{
					foreach (KeyValuePair<string, string> keyValuePair in readOnlyDictionary2)
					{
						string text;
						string text2;
						keyValuePair.Deconstruct(out text2, out text);
						string mainKeyName2 = text2;
						string secondaryKeyName2 = text;
						EInputBindingType currentBindingType2 = combinationActionBindingByActionName2.CurrentBindingType;
						Singleton<InputSettingsManager>.Instance.AddCombinationActionKeyMap("手柄主攻击", mainKeyName2, secondaryKeyName2, currentBindingType2);
					}
				}
			}
		}

		// Token: 0x06034905 RID: 215301 RVA: 0x00D2D618 File Offset: 0x00D2B818
		private bool CheckKeyNameListEqual([Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<string> keyNameListA, [Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<string> keyNameListB)
		{
			if (keyNameListA == keyNameListB)
			{
				return true;
			}
			if (keyNameListA == null || keyNameListB == null)
			{
				return false;
			}
			if (keyNameListA.Count != keyNameListB.Count)
			{
				return false;
			}
			for (int i = 0; i < keyNameListA.Count; i++)
			{
				if (keyNameListA[i] != keyNameListB[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06034906 RID: 215302 RVA: 0x00D2D66C File Offset: 0x00D2B86C
		private bool CheckKeyNameMapEqual([Nullable(new byte[]
		{
			2,
			1,
			1
		})] IReadOnlyDictionary<string, string> keyNameMapA, [Nullable(new byte[]
		{
			2,
			1,
			1
		})] IReadOnlyDictionary<string, string> keyNameMapB)
		{
			if (keyNameMapA == keyNameMapB)
			{
				return true;
			}
			if (keyNameMapA == null || keyNameMapB == null)
			{
				return false;
			}
			if (keyNameMapA.Count != keyNameMapB.Count)
			{
				return false;
			}
			foreach (KeyValuePair<string, string> keyValuePair in keyNameMapA)
			{
				string key = keyValuePair.Key;
				string value = keyValuePair.Value;
				string a;
				if (!keyNameMapB.TryGetValue(key, out a) || a != value)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06034907 RID: 215303 RVA: 0x00D2D6FC File Offset: 0x00D2B8FC
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
			Array.Resize<int>(ref this.SubAimSkillButtonTypeList, 4);
			for (int l = 0; l < 3; l++)
			{
				this.SubAimSkillButtonTypeList[l] = this.SubSkillButtonTypeList[l];
			}
			this.SubAimSkillButtonTypeList[this.KeyRightTriggerIndex] = 11;
			this.SubAimSkillButtonTypeList[3] = this.SubSkillButtonTypeList[this.KeyRightTriggerIndex];
		}

		// Token: 0x06034908 RID: 215304 RVA: 0x00D2D82C File Offset: 0x00D2BA2C
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

		// Token: 0x06034909 RID: 215305 RVA: 0x00D2D884 File Offset: 0x00D2BA84
		private ESkillButtonType GetNormalSkillButtonTypeByIndex(int index, bool isPressCombineButton)
		{
			string key = this.ButtonKeyList[index];
			string text;
			if (isPressCombineButton)
			{
				this.CombinationKeyToActionNameMap.TryGetValue(key, out text);
			}
			else
			{
				this.ButtonKeyToActionNameMap.TryGetValue(key, out text);
			}
			if (string.IsNullOrEmpty(text))
			{
				return ESkillButtonType.None;
			}
			int result;
			if (!SkillButtonUiGamepadData.actionNameToButtonTypeMap.TryGetValue(text, out result))
			{
				return ESkillButtonType.None;
			}
			return (ESkillButtonType)result;
		}

		// Token: 0x0603490A RID: 215306 RVA: 0x00D2D8DD File Offset: 0x00D2BADD
		public override void RefreshSwitchInteractOpen(bool isInit = false)
		{
			this.SwitchInteractData.RefreshSwitchInteractOpen(isInit);
		}

		// Token: 0x0603490B RID: 215307 RVA: 0x00D2D8EC File Offset: 0x00D2BAEC
		public override bool RefreshButtonData()
		{
			this.RefreshStateByTag();
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
				if (!this.IsAimActionKeys)
				{
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
						if (!this.IsPressCombineButton || this.SubAimSkillButtonTypeList[m] != 11)
						{
							this.PushSubSkillButton(this.SubAimSkillButtonTypeList[m]);
						}
					}
				}
			}
			else
			{
				for (int n = 0; n < 4; n++)
				{
					int? buttonTypeByIndex = this.GetButtonTypeByIndex(this.MainSkillCombineButtonTypeList, n, false);
					if (this.MainSkillCombineButtonTypeList[n] != 0)
					{
						this.CurButtonTypeList.Add(buttonTypeByIndex);
					}
					else
					{
						this.CurButtonTypeList.Add(this.GetButtonTypeByIndex(this.MainSkillButtonTypeList, n, false));
					}
				}
				for (int num = 0; num < 4; num++)
				{
					this.CurButtonTypeList.Add(this.GetButtonTypeByIndex(this.MainSkillCombineButtonTypeList, num, true));
				}
				for (int num2 = 0; num2 < 4; num2++)
				{
					int? buttonTypeByIndex2 = this.GetButtonTypeByIndex(this.DpadSkillCombineButtonTypeList, num2, false);
					if (this.DpadSkillCombineButtonTypeList[num2] != 0)
					{
						this.CurButtonTypeList.Add(buttonTypeByIndex2);
					}
					else
					{
						this.CurButtonTypeList.Add(this.GetButtonTypeByIndex(this.DpadSkillButtonTypeList, num2, false));
					}
				}
				for (int num3 = 0; num3 < 3; num3++)
				{
					this.PushSubSkillButton(this.SubSkillCombineButtonTypeList[num3]);
				}
			}
			if (this.Climbing)
			{
				int num4 = this.CurButtonTypeList.IndexOf(new int?(4));
				if (num4 != -1)
				{
					this.CurButtonTypeList[num4] = new int?(2);
				}
			}
			if (ModelBase<SkillButtonUiModel>.Instance.GetButtonTypeList().Contains(12))
			{
				int num5 = this.CurButtonTypeList.IndexOf(new int?(101));
				if (num5 >= 0)
				{
					this.CurButtonTypeList[num5] = new int?(12);
				}
			}
			return true;
		}

		// Token: 0x0603490C RID: 215308 RVA: 0x00D2DB60 File Offset: 0x00D2BD60
		private int? GetButtonTypeByIndex(int[] buttonTypeList, int index, bool isSecondButton = false)
		{
			int num = buttonTypeList[index];
			if ((num == 101 || this.CheckSkillButtonVisibleByButtonType(num).GetValueOrDefault()) && this.CheckSkillButtonVisibleByState(num, isSecondButton))
			{
				return new int?(num);
			}
			return new int?(0);
		}

		// Token: 0x0603490D RID: 215309 RVA: 0x00D2DBA0 File Offset: 0x00D2BDA0
		private bool CheckSkillButtonVisibleByState(int buttonType, bool isSecondButton = false)
		{
			if (this.IsPhantomRole)
			{
				return SkillButtonUiGamepadData.phantomRoleButtonTypeSet.Contains(buttonType) || (this.PhantomRoleButtonTypeList != null && this.PhantomRoleButtonTypeList.Contains(buttonType));
			}
			return (this.CurStateTagId == 0 || this.StateButtonTypeList == null || this.StateButtonTypeList.Contains(buttonType)) && (!isSecondButton || SkillButtonUiGamepadData.mainSecondButtonTypeSet.Contains(buttonType));
		}

		// Token: 0x0603490E RID: 215310 RVA: 0x00D2DC10 File Offset: 0x00D2BE10
		private bool? CheckSkillButtonVisibleByButtonType(int buttonType)
		{
			if (buttonType == 0)
			{
				return new bool?(false);
			}
			SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
			SkillButtonData skillButtonDataByButton = instance.GetSkillButtonDataByButton((ESkillButtonType)buttonType);
			if (skillButtonDataByButton != null)
			{
				return new bool?(skillButtonDataByButton.IsVisible());
			}
			BehaviorButtonData behaviorButtonDataByButton = instance.GetBehaviorButtonDataByButton((EBehaviorType)buttonType);
			if (behaviorButtonDataByButton == null)
			{
				return null;
			}
			return new bool?(behaviorButtonDataByButton.IsVisible());
		}

		// Token: 0x0603490F RID: 215311 RVA: 0x00D2DC64 File Offset: 0x00D2BE64
		private void PushSubSkillButton(int buttonType)
		{
			if (this.IsPhantomRole || this.CurStateTagId != 0)
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
				if (!SkillButtonUiGamepadData.subButtonTypeSet.Contains(buttonType))
				{
					this.CurButtonTypeList.Add(null);
					return;
				}
				this.CurButtonTypeList.Add(new int?(buttonType));
				return;
			}
		}

		// Token: 0x06034910 RID: 215312 RVA: 0x00D2DCE8 File Offset: 0x00D2BEE8
		private void RefreshStateByTag()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null || !getCurrentEntity.Valid)
			{
				return;
			}
			BaseTagComponent baseTagComponent = getCurrentEntity.Entity.CheckGetComponent<BaseTagComponent>();
			this.Climbing = baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"]);
			this.CurStateTagId = 0;
			this.StateButtonTypeList = null;
			SkillButtonIndexData curSkillButtonIndexData = ModelBase<SkillButtonUiModel>.Instance.CurSkillButtonIndexData;
			IEnumerable<DicIntIntArray> enumerable = (curSkillButtonIndexData != null) ? ((curSkillButtonIndexData.ButtonIndexConfig != null) ? curSkillButtonIndexData.ButtonIndexConfig.GetValueOrDefault().GamepadButtonTypeMapIter() : null) : null;
			if (enumerable == null)
			{
				return;
			}
			foreach (DicIntIntArray dicIntIntArray in enumerable)
			{
				int key = dicIntIntArray.Key;
				IntArray value = dicIntIntArray.Value.Value;
				if (baseTagComponent.HasTag(key))
				{
					this.CurStateTagId = key;
					this.StateButtonTypeList = new List<int>();
					for (int i = 0; i < value.ArrayIntLength; i++)
					{
						this.StateButtonTypeList.Add(value.ArrayInt(i));
					}
					break;
				}
			}
		}

		// Token: 0x06034911 RID: 215313 RVA: 0x00D2DE1C File Offset: 0x00D2C01C
		public override int GetButtonTypeByActionName(string actionName)
		{
			int result;
			if (!SkillButtonUiGamepadData.actionNameToButtonTypeMap.TryGetValue(actionName, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x06034912 RID: 215314 RVA: 0x00D2DE3B File Offset: 0x00D2C03B
		public override bool IsAim()
		{
			BehaviorButtonData behaviorButtonDataByButtonType = this.GetBehaviorButtonDataByButtonType(EBehaviorType.Aim);
			return (behaviorButtonDataByButtonType != null && behaviorButtonDataByButtonType.State == 1) || this.IsFollowerAiming;
		}

		// Token: 0x06034913 RID: 215315 RVA: 0x00D2DE5E File Offset: 0x00D2C05E
		public override void SetIsPressCombineButton(bool value)
		{
			if (this.IsPressCombineButton == value)
			{
				return;
			}
			this.IsPressCombineButton = value;
			this.RefreshButtonData();
		}

		// Token: 0x06034914 RID: 215316 RVA: 0x00D2DE78 File Offset: 0x00D2C078
		public override bool GetIsPressCombineButton()
		{
			return this.IsPressCombineButton;
		}

		// Token: 0x06034915 RID: 215317 RVA: 0x00D2DE80 File Offset: 0x00D2C080
		[NullableContext(2)]
		public BehaviorButtonData GetBehaviorButtonDataByButtonType(EBehaviorType buttonType)
		{
			return ModelBase<SkillButtonUiModel>.Instance.GetBehaviorButtonDataByButton(buttonType);
		}

		// Token: 0x06034916 RID: 215318 RVA: 0x00D2DE8D File Offset: 0x00D2C08D
		public override void RefreshSkillButtonData(ESkillButtonRefreshReason refreshReason)
		{
			if (refreshReason == ESkillButtonRefreshReason.ChangeRole)
			{
				this.RefreshIsPhantomRole();
				this.RefreshFollowerAiming();
				this.ChangeSkillOnAimStateChange();
				this.RefreshButtonData();
			}
		}

		// Token: 0x06034917 RID: 215319 RVA: 0x00D2DEB0 File Offset: 0x00D2C0B0
		private void RefreshIsPhantomRole()
		{
			this.IsPhantomRole = false;
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null || !getCurrentEntity.Valid)
			{
				return;
			}
			CreatureDataComponent component = getCurrentEntity.Entity.GetComponent<CreatureDataComponent>();
			if (component == null)
			{
				return;
			}
			this.IsPhantomRole = (component.GetRoleConfig().Value.RoleType == 2);
			if (this.IsPhantomRole)
			{
				SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
				SkillButtonEntityData curSkillButtonEntityData = instance.GetCurSkillButtonEntityData();
				this.PhantomRoleButtonTypeList = ((curSkillButtonEntityData != null) ? ((curSkillButtonEntityData.SkillButtonIndexConfig != null) ? curSkillButtonEntityData.SkillButtonIndexConfig.GetValueOrDefault().DesktopButtonTypeList() : null) : null);
			}
		}

		// Token: 0x06034918 RID: 215320 RVA: 0x00D2DF52 File Offset: 0x00D2C152
		public override bool RefreshAimState()
		{
			if (this.ChangeSkillOnAimStateChange())
			{
				this.RefreshButtonData();
				return true;
			}
			return false;
		}

		// Token: 0x06034919 RID: 215321 RVA: 0x00D2DF68 File Offset: 0x00D2C168
		private bool RefreshFollowerAiming()
		{
			bool followerAiming = ModelBase<BattleUiModel>.Instance.FormationData.GetFollowerAiming();
			if (this.IsFollowerAiming != followerAiming)
			{
				this.IsFollowerAiming = followerAiming;
				return true;
			}
			return false;
		}

		// Token: 0x0603491A RID: 215322 RVA: 0x00D2DF98 File Offset: 0x00D2C198
		public bool ChangeSkillOnAimStateChange()
		{
			if (this.IsAim() == this.IsAimActionKeys)
			{
				return false;
			}
			this.ChangeAimActionKeys();
			return true;
		}

		// Token: 0x0603491B RID: 215323 RVA: 0x00D2DFB4 File Offset: 0x00D2C1B4
		private void ChangeAimActionKeys()
		{
			if (this.LockRefresh)
			{
				return;
			}
			this.LockRefresh = true;
			this.IsAimActionKeys = !this.IsAimActionKeys;
			TsCharacterController characterController = Global.CharacterController;
			if (this.IsAimActionKeys)
			{
				if (this.ChangeSkillActionName == "攻击")
				{
					if (this.AttackActionAimKeys != null)
					{
						characterController.SetActionEnable("攻击", false);
						foreach (string keyName in this.AttackActionAimKeys)
						{
							characterController.SetCustomAction(keyName, "攻击");
						}
						characterController.SetCustomAction(EKey.Gamepad_RightThumbstick, "攻击");
						characterController.SetActionEnable("攀爬", false);
						if (this.ClimbActionNormalKeys != null)
						{
							foreach (string text in this.ClimbActionNormalKeys)
							{
								if (text != EKey.Gamepad_RightTrigger)
								{
									characterController.SetCustomAction(text, "攀爬");
								}
							}
						}
						characterController.SetCustomAction(EKey.Gamepad_RightThumbstick, "攀爬");
					}
					else
					{
						Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "攻击输入没有绑定任何按键，瞄准时使RT键生效", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
				}
				else
				{
					if (!string.IsNullOrEmpty(this.ChangeSkillActionName))
					{
						characterController.SetActionEnable(this.ChangeSkillActionName, false);
						foreach (string keyName2 in this.ChangeSkillAimKeys)
						{
							characterController.SetCustomAction(keyName2, this.ChangeSkillActionName);
						}
					}
					if (this.AttackActionAimKeys != null)
					{
						characterController.SetActionEnable("攻击", false);
						using (List<string>.Enumerator enumerator = this.AttackActionAimKeys.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								string keyName3 = enumerator.Current;
								characterController.SetCustomAction(keyName3, "攻击");
							}
							goto IL_37A;
						}
					}
					Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "攻击输入没有绑定任何按键，瞄准时使RT键生效", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
			else if (this.ChangeSkillActionName == "攻击")
			{
				characterController.SetActionEnable("攀爬", true);
				characterController.SetActionEnable("攻击", true);
				foreach (string keyName4 in this.AttackActionAimKeys)
				{
					characterController.ResetAllCustomAction(keyName4);
				}
				if (this.ClimbActionNormalKeys != null)
				{
					foreach (string text2 in this.ClimbActionNormalKeys)
					{
						if (text2 != EKey.Gamepad_RightTrigger)
						{
							characterController.ResetAllCustomAction(text2);
						}
					}
				}
				characterController.ResetAllCustomAction(EKey.Gamepad_RightThumbstick);
			}
			else
			{
				if (!string.IsNullOrEmpty(this.ChangeSkillActionName))
				{
					characterController.SetActionEnable(this.ChangeSkillActionName, true);
					foreach (string keyName5 in this.ChangeSkillAimKeys)
					{
						characterController.ResetAllCustomAction(keyName5);
					}
				}
				characterController.SetActionEnable("攻击", true);
				foreach (string keyName6 in this.AttackActionAimKeys)
				{
					characterController.ResetAllCustomAction(keyName6);
				}
			}
			IL_37A:
			this.LockRefresh = false;
		}

		// Token: 0x0603491C RID: 215324 RVA: 0x00D2E3A8 File Offset: 0x00D2C5A8
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

		// Token: 0x0603491D RID: 215325 RVA: 0x00D2E3E8 File Offset: 0x00D2C5E8
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
				if (SkillButtonUiGamepadData.initActionNames.Contains(actionName))
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
				if (SkillButtonUiGamepadData.initActionNames.Contains(actionName))
				{
					Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "在未知情况下触发了改键", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				return;
			}
		}

		// Token: 0x0603491E RID: 215326 RVA: 0x00D2E486 File Offset: 0x00D2C686
		public override void AddChangeKeyReason(EGamepadChangeKeyReason reason)
		{
			if (this.ChangeKeyReasonSet.Count == 0 && this.IsAimActionKeys)
			{
				this.ChangeAimActionKeys();
			}
			this.ChangeKeyReasonSet.Add(reason);
		}

		// Token: 0x0603491F RID: 215327 RVA: 0x00D2E4B0 File Offset: 0x00D2C6B0
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
			if (this.IsAim() != this.IsAimActionKeys)
			{
				this.ChangeAimActionKeys();
			}
			this.RefreshButtonData();
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				SkillButtonEntityData curSkillButtonEntityData = ModelBase<SkillButtonUiModel>.Instance.GetCurSkillButtonEntityData();
				if (curSkillButtonEntityData == null)
				{
					return;
				}
				curSkillButtonEntityData.RefreshSkillButtonData(ESkillButtonRefreshReason.GamepadRefreshKeyAction);
			}
		}

		// Token: 0x06034920 RID: 215328 RVA: 0x00D2E529 File Offset: 0x00D2C729
		public override void AddAllowChangeKeyReason(string reason)
		{
			this.AllowChangeKeyReasonSet.Add(reason);
		}

		// Token: 0x06034921 RID: 215329 RVA: 0x00D2E538 File Offset: 0x00D2C738
		public override void RemoveAllowChangeKeyReason(string reason)
		{
			this.AllowChangeKeyReasonSet.Remove(reason);
		}

		// Token: 0x06034922 RID: 215330 RVA: 0x00D2E547 File Offset: 0x00D2C747
		public override void CacheInputAxis(in EInputAxis axis, float value)
		{
			this.InputAxisMap[axis] = value;
		}

		// Token: 0x06034923 RID: 215331 RVA: 0x00D2E55B File Offset: 0x00D2C75B
		public override float GetInputAxis(in EInputAxis axis)
		{
			return this.InputAxisMap.GetValueOrDefault(axis, 0f);
		}

		// Token: 0x06034924 RID: 215332 RVA: 0x00D2E573 File Offset: 0x00D2C773
		public override void ClearInputAxis()
		{
			this.InputAxisMap.Clear();
		}

		// Token: 0x06034926 RID: 215334 RVA: 0x00D2E5DC File Offset: 0x00D2C7DC
		// Note: this type is marked as 'beforefieldinit'.
		static SkillButtonUiGamepadData()
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			dictionary["跳跃"] = 1;
			dictionary["攀爬"] = 2;
			dictionary["攻击"] = 4;
			dictionary["闪避"] = 5;
			dictionary["技能1"] = 6;
			dictionary["幻象1"] = 7;
			dictionary["大招"] = 8;
			dictionary["幻象2"] = 9;
			dictionary["瞄准"] = 101;
			dictionary["通用交互"] = 104;
			dictionary["任务追踪"] = 105;
			SkillButtonUiGamepadData.actionNameToButtonTypeMap = dictionary;
			SkillButtonUiGamepadData.initActionNames = new string[]
			{
				"跳跃",
				"攻击",
				"闪避",
				"技能1",
				"幻象1",
				"大招",
				"幻象2",
				"瞄准",
				"通用交互"
			};
			SkillButtonUiGamepadData.mainSecondButtonTypeSet = new HashSet<int>
			{
				1,
				2,
				4,
				5,
				6,
				8,
				7,
				9,
				101,
				104
			};
			SkillButtonUiGamepadData.subButtonTypeSet = new HashSet<int>
			{
				1,
				2,
				4,
				6,
				8,
				7,
				9,
				11,
				101,
				104
			};
			SkillButtonUiGamepadData.phantomRoleButtonTypeSet = new HashSet<int>
			{
				101,
				104
			};
		}

		// Token: 0x0401E4C4 RID: 124100
		[StaticVariableRuleIgnore]
		private static readonly string[] mainKeys = new string[]
		{
			EKey.Gamepad_FaceButton_Top,
			EKey.Gamepad_FaceButton_Left,
			EKey.Gamepad_FaceButton_Bottom,
			EKey.Gamepad_FaceButton_Right
		};

		// Token: 0x0401E4C5 RID: 124101
		private const int MAIN_HALF_NUM = 4;

		// Token: 0x0401E4C6 RID: 124102
		[StaticVariableRuleIgnore]
		private static readonly string[] dPadKeys = new string[]
		{
			EKey.Gamepad_DPad_Up,
			EKey.Gamepad_DPad_Left,
			EKey.Gamepad_DPad_Down,
			EKey.Gamepad_DPad_Right
		};

		// Token: 0x0401E4C7 RID: 124103
		private const int DPAD_KEY_NUM = 4;

		// Token: 0x0401E4C8 RID: 124104
		[StaticVariableRuleIgnore]
		private static readonly string[] subKeys = new string[]
		{
			EKey.Gamepad_LeftTrigger,
			EKey.Gamepad_RightTrigger,
			EKey.Gamepad_LeftShoulder,
			EKey.Gamepad_RightShoulder
		};

		// Token: 0x0401E4C9 RID: 124105
		private const int SUB_KEY_NUM = 3;

		// Token: 0x0401E4CA RID: 124106
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<string, int> actionNameToButtonTypeMap;

		// Token: 0x0401E4CB RID: 124107
		[StaticVariableRuleIgnore]
		private static readonly string[] initActionNames;

		// Token: 0x0401E4CC RID: 124108
		[StaticVariableRuleIgnore]
		private static readonly HashSet<int> mainSecondButtonTypeSet;

		// Token: 0x0401E4CD RID: 124109
		[StaticVariableRuleIgnore]
		private static readonly HashSet<int> subButtonTypeSet;

		// Token: 0x0401E4CE RID: 124110
		[StaticVariableRuleIgnore]
		private static readonly HashSet<int> phantomRoleButtonTypeSet;

		// Token: 0x0401E4CF RID: 124111
		private readonly List<string> AllActionNameList = new List<string>();

		// Token: 0x0401E4D0 RID: 124112
		public readonly HashSet<string> AllowChangeKeyReasonSet = new HashSet<string>();

		// Token: 0x0401E4D1 RID: 124113
		private readonly HashSet<EGamepadChangeKeyReason> ChangeKeyReasonSet = new HashSet<EGamepadChangeKeyReason>();

		// Token: 0x0401E4D2 RID: 124114
		private readonly Dictionary<string, string> ButtonKeyToActionNameMap = new Dictionary<string, string>();

		// Token: 0x0401E4D3 RID: 124115
		private readonly Dictionary<string, string> CombinationKeyToActionNameMap = new Dictionary<string, string>();

		// Token: 0x0401E4D4 RID: 124116
		private int KeyRightTriggerIndex = 1;

		// Token: 0x0401E4D5 RID: 124117
		[Nullable(2)]
		private string ChangeSkillActionName;

		// Token: 0x0401E4D6 RID: 124118
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<string> ChangeSkillAimKeys;

		// Token: 0x0401E4D7 RID: 124119
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<string> AttackActionNormalKeys;

		// Token: 0x0401E4D8 RID: 124120
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<string> AttackActionAimKeys;

		// Token: 0x0401E4D9 RID: 124121
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<string> ClimbActionNormalKeys;

		// Token: 0x0401E4DA RID: 124122
		private bool IsPressCombineButton;

		// Token: 0x0401E4DB RID: 124123
		public bool IsShowCombineButton;

		// Token: 0x0401E4DC RID: 124124
		private bool IsFollowerAiming;

		// Token: 0x0401E4DD RID: 124125
		private bool IsAimActionKeys;

		// Token: 0x0401E4DE RID: 124126
		private bool ChangeKeyActionInMenuView;

		// Token: 0x0401E4DF RID: 124127
		private bool LockRefresh;

		// Token: 0x0401E4E0 RID: 124128
		public bool Climbing;

		// Token: 0x0401E4E1 RID: 124129
		public int CurStateTagId;

		// Token: 0x0401E4E2 RID: 124130
		[Nullable(2)]
		public List<int> StateButtonTypeList;

		// Token: 0x0401E4E3 RID: 124131
		public bool IsPhantomRole;

		// Token: 0x0401E4E4 RID: 124132
		[Nullable(2)]
		public int[] PhantomRoleButtonTypeList;

		// Token: 0x0401E4E5 RID: 124133
		private readonly Dictionary<EInputAxis, float> InputAxisMap = new Dictionary<EInputAxis, float>();
	}
}
