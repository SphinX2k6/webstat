using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Input.BattleInputData;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.LevelGamePlay.Common;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049F7 RID: 18935
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class InputDistributeModel : ModelBase<InputDistributeModel>
	{
		// Token: 0x06031848 RID: 202824 RVA: 0x00C56DC5 File Offset: 0x00C54FC5
		protected override bool OnInit()
		{
			this.InitializeInputDistributeTags();
			this.InitializeActionHandles();
			this.InitializeAxisHandles();
			this.InitializeTouchHandles();
			this.InitializeKeyHandles();
			this.InitializeInputDistributeSetup();
			this.SetInputDistributeTag("FightInputRoot");
			return true;
		}

		// Token: 0x06031849 RID: 202825 RVA: 0x00C56DF8 File Offset: 0x00C54FF8
		protected override bool OnClear()
		{
			this.ClearAllNotAllowFightInputViewNames();
			this.InputDistributeTagMap.Clear();
			this.InputDistributeSetups.Clear();
			foreach (InputActionHandle inputActionHandle in this.InputActionHandleMap.Values)
			{
				inputActionHandle.Reset();
			}
			this.InputActionHandleMap.Clear();
			foreach (InputAxisHandle inputAxisHandle in this.InputAxisHandleMap.Values)
			{
				inputAxisHandle.Reset();
			}
			this.InputAxisHandleMap.Clear();
			foreach (InputKeyHandle inputKeyHandle in this.InputKeyHandleMap.Values)
			{
				inputKeyHandle.Reset();
			}
			this.InputKeyHandleMap.Clear();
			this.TagChangedCallbacks.Clear();
			return true;
		}

		// Token: 0x0603184A RID: 202826 RVA: 0x00C56F20 File Offset: 0x00C55120
		private void InitializeInputDistributeSetup()
		{
			Type[] inputDistributeSetups = InputDistributeSetupDefine.inputDistributeSetups;
			for (int i = 0; i < inputDistributeSetups.Length; i++)
			{
				object obj = Activator.CreateInstance(inputDistributeSetups[i]);
				this.InputDistributeSetups.Add((InputDistributeSetup)obj);
			}
		}

		// Token: 0x0603184B RID: 202827 RVA: 0x00C56F5C File Offset: 0x00C5515C
		public void RefreshInputDistributeTag()
		{
			using (List<InputDistributeSetup>.Enumerator enumerator = this.InputDistributeSetups.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.OnRefresh())
					{
						break;
					}
				}
			}
		}

		// Token: 0x0603184C RID: 202828 RVA: 0x00C56FB0 File Offset: 0x00C551B0
		private void InitializeActionHandles()
		{
			IReadOnlyList<ActionMapping> allActionMappingConfig = ConfigBase<InputSettingsConfig>.Instance.GetAllActionMappingConfig();
			if (allActionMappingConfig != null)
			{
				foreach (ActionMapping actionMapping in allActionMappingConfig)
				{
					this.NewInputActionHandle(actionMapping.ActionName, actionMapping.InputTag);
				}
			}
			IReadOnlyList<CombinationAction> allCombinationActionConfig = ConfigBase<InputSettingsConfig>.Instance.GetAllCombinationActionConfig();
			if (allCombinationActionConfig != null)
			{
				foreach (CombinationAction combinationAction in allCombinationActionConfig)
				{
					this.NewInputActionHandle(combinationAction.ActionName, combinationAction.InputTag);
				}
			}
		}

		// Token: 0x0603184D RID: 202829 RVA: 0x00C57070 File Offset: 0x00C55270
		private void InitializeAxisHandles()
		{
			IReadOnlyList<AxisMapping> allAxisMappingConfig = ConfigBase<InputSettingsConfig>.Instance.GetAllAxisMappingConfig();
			if (allAxisMappingConfig != null)
			{
				foreach (AxisMapping axisMapping in allAxisMappingConfig)
				{
					this.NewInputAxisHandle(axisMapping.AxisName, axisMapping.InputTag);
				}
			}
			IReadOnlyList<CombinationAxis> allCombinationAxisConfig = ConfigBase<InputSettingsConfig>.Instance.GetAllCombinationAxisConfig();
			if (allCombinationAxisConfig != null)
			{
				foreach (CombinationAxis combinationAxis in allCombinationAxisConfig)
				{
					this.NewInputAxisHandle(combinationAxis.AxisName, combinationAxis.InputTag);
				}
			}
		}

		// Token: 0x0603184E RID: 202830 RVA: 0x00C57130 File Offset: 0x00C55330
		private void InitializeTouchHandles()
		{
			foreach (KeyValuePair<int, string> keyValuePair in InputDistributeDefine.touchTagMap)
			{
				int key = keyValuePair.Key;
				string value = keyValuePair.Value;
				this.NewInputTouchHandle(key, value);
			}
		}

		// Token: 0x0603184F RID: 202831 RVA: 0x00C57194 File Offset: 0x00C55394
		private void InitializeKeyHandles()
		{
			foreach (KeyValuePair<string, string> keyValuePair in InputDistributeDefine.keyTagMap)
			{
				string key = keyValuePair.Key;
				string value = keyValuePair.Value;
				this.NewInputKeyHandle(key, value);
			}
		}

		// Token: 0x06031850 RID: 202832 RVA: 0x00C571F8 File Offset: 0x00C553F8
		public bool IsActionInPress(string actionName)
		{
			InputActionHandle inputActionHandle = this.GetInputActionHandle(actionName);
			return inputActionHandle != null && inputActionHandle.GetIsPress();
		}

		// Token: 0x06031851 RID: 202833 RVA: 0x00C57218 File Offset: 0x00C55418
		public bool IsAxisInPress(string axisName)
		{
			InputAxisHandle inputAxisHandle = this.GetInputAxisHandle(axisName);
			return inputAxisHandle != null && inputAxisHandle.GetCacheAxisValue() != 0f;
		}

		// Token: 0x06031852 RID: 202834 RVA: 0x00C57242 File Offset: 0x00C55442
		public bool HasAxisBind(string axisName)
		{
			InputAxisHandle inputAxisHandle = this.GetInputAxisHandle(axisName);
			return inputAxisHandle != null && inputAxisHandle.HasCallback();
		}

		// Token: 0x06031853 RID: 202835 RVA: 0x00C57256 File Offset: 0x00C55456
		public bool HasActionBind(string actionName)
		{
			InputActionHandle inputActionHandle = this.GetInputActionHandle(actionName);
			return inputActionHandle != null && inputActionHandle.HasCallback();
		}

		// Token: 0x06031854 RID: 202836 RVA: 0x00C5726C File Offset: 0x00C5546C
		public bool IsActionRespondable(string actionName)
		{
			InputActionHandle inputActionHandle = this.GetInputActionHandle(actionName);
			if (inputActionHandle == null)
			{
				return false;
			}
			InputModel instance = ModelBase<InputModel>.Instance;
			BattleInputData battleInputData = (instance != null) ? instance.GetCurrentInputData() : null;
			if (battleInputData != null && !battleInputData.CheckActionInAllowFightActionNameList(actionName, inputActionHandle))
			{
				return false;
			}
			string inputDistributeTag = inputActionHandle.GetInputDistributeTag();
			if (!string.IsNullOrEmpty(inputDistributeTag) && !this.IsTagMatchAnyCurrentInputTag(inputDistributeTag, false))
			{
				return inputActionHandle.HasIgnoreLimit();
			}
			return this.CheckFightActionInputAllow(actionName, inputDistributeTag);
		}

		// Token: 0x06031855 RID: 202837 RVA: 0x00C572D4 File Offset: 0x00C554D4
		public bool InputAction(string actionName, bool bPress)
		{
			InputActionHandle inputActionHandle = this.GetInputActionHandle(actionName);
			if (inputActionHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "输入Action时，没有对应的ActionHandle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", actionName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			InputModel instance2 = ModelBase<InputModel>.Instance;
			BattleInputData battleInputData = (instance2 != null) ? instance2.GetCurrentInputData() : null;
			if (battleInputData != null && !battleInputData.CheckActionInAllowFightActionNameList(actionName, inputActionHandle))
			{
				return false;
			}
			inputActionHandle.SetIsPress(bPress);
			if (Array.IndexOf<string>(InputDistributeDelay.delayInput, actionName) >= 0)
			{
				InputDistributeDelay inputDistributeDelay = null;
				if (!this.InputDistributeDelayMap.ContainsKey(actionName))
				{
					inputDistributeDelay = new InputDistributeDelay();
					this.InputDistributeDelayMap[actionName] = inputDistributeDelay;
				}
				else
				{
					this.InputDistributeDelayMap.TryGetValue(actionName, out inputDistributeDelay);
				}
				if (inputDistributeDelay.CheckCondition(actionName, bPress))
				{
					inputDistributeDelay.StartDelay((float)ConfigBase<LevelGamePlayConfig>.Instance.InteractInputCacheTime, bPress);
				}
			}
			if (this.HasActionLimitSet())
			{
				if (!this.IsActionInLimitSet(actionName))
				{
					Singleton<EventSystem>.Instance.Emit<string, bool>(EEventName.GuideLimitActionInput, actionName, bPress);
					return false;
				}
			}
			else
			{
				string inputDistributeTag = inputActionHandle.GetInputDistributeTag();
				if (!string.IsNullOrEmpty(inputDistributeTag) && !this.IsTagMatchAnyCurrentInputTag(inputDistributeTag, false))
				{
					if (!bPress)
					{
						inputActionHandle.TryReleaseActionIfLimitInputDistributeTag();
					}
					inputActionHandle.InputActionIgnoreLimit(bPress);
					return false;
				}
				if (!this.CheckFightActionInputAllow(actionName, inputDistributeTag))
				{
					return false;
				}
			}
			inputActionHandle.InputAction(bPress);
			inputActionHandle.InputActionIgnoreLimit(bPress);
			if (bPress)
			{
				this.CurrentActionName = actionName;
			}
			else if (this.CurrentActionName != null)
			{
				this.CurrentActionName = null;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnInputChangeForCond);
			return true;
		}

		// Token: 0x06031856 RID: 202838 RVA: 0x00C57438 File Offset: 0x00C55638
		private bool CheckFightActionInputAllow(string actionName, [Nullable(2)] string tag)
		{
			InputDistributeTag inputDistributeTag = this.GetInputDistributeTag(tag);
			if (inputDistributeTag == null)
			{
				return true;
			}
			if (inputDistributeTag.MatchTag("UiInputRoot.MouseInputTag", false) || inputDistributeTag.MatchTag("UiInputRoot.Navigation", false))
			{
				return true;
			}
			UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
			return instance == null || !instance.CheckActionNameListInNavigation(actionName);
		}

		// Token: 0x06031857 RID: 202839 RVA: 0x00C57488 File Offset: 0x00C55688
		private bool CheckFightAxisInputAllow(string axisName, [Nullable(2)] string tag)
		{
			InputDistributeTag inputDistributeTag = this.GetInputDistributeTag(tag);
			if (inputDistributeTag == null)
			{
				return true;
			}
			if (inputDistributeTag.MatchTag("UiInputRoot.MouseInputTag", false) || inputDistributeTag.MatchTag("UiInputRoot.Navigation", false))
			{
				return true;
			}
			UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
			return instance == null || !instance.CheckAxisNameListInNavigation(axisName);
		}

		// Token: 0x06031858 RID: 202840 RVA: 0x00C574D5 File Offset: 0x00C556D5
		[NullableContext(2)]
		public string GetCurrentActionName()
		{
			return this.CurrentActionName;
		}

		// Token: 0x06031859 RID: 202841 RVA: 0x00C574E0 File Offset: 0x00C556E0
		public void InputCacheAxisValue(string axisName, float value)
		{
			InputAxisHandle inputAxisHandle = this.GetInputAxisHandle(axisName);
			if (inputAxisHandle == null)
			{
				return;
			}
			inputAxisHandle.InputCacheAxisValue(value);
		}

		// Token: 0x0603185A RID: 202842 RVA: 0x00C57500 File Offset: 0x00C55700
		public void InputAxis(string axisName, float value, bool force = false)
		{
			InputAxisHandle inputAxisHandle = this.GetInputAxisHandle(axisName);
			if (inputAxisHandle == null)
			{
				return;
			}
			InputModel instance = ModelBase<InputModel>.Instance;
			BattleInputData battleInputData = (instance != null) ? instance.GetCurrentInputData() : null;
			if (battleInputData != null && !battleInputData.CheckAxisInAllowFightAxisNameList(axisName, inputAxisHandle))
			{
				return;
			}
			if (this.HasActionLimitSet())
			{
				if (!this.IsActionInLimitSet(axisName))
				{
					if (Singleton<Info>.Instance.AxisInputOptimize && (inputAxisHandle.GetCacheAxisValue() != 0f || force))
					{
						inputAxisHandle.InputAxis(0f);
						inputAxisHandle.InputAxisIgnoreLimit(0f);
						return;
					}
					inputAxisHandle.InputAxisIgnoreLimit(value);
					return;
				}
			}
			else
			{
				string inputDistributeTag = inputAxisHandle.GetInputDistributeTag();
				if (inputDistributeTag != null && !this.IsTagMatchAnyCurrentInputTag(inputDistributeTag, false))
				{
					if (Singleton<Info>.Instance.AxisInputOptimize && (inputAxisHandle.GetCacheAxisValue() != 0f || force))
					{
						inputAxisHandle.InputAxis(0f);
						inputAxisHandle.InputAxisIgnoreLimit(0f);
						return;
					}
					inputAxisHandle.InputAxisIgnoreLimit(value);
					return;
				}
				else if (!this.CheckFightAxisInputAllow(axisName, inputDistributeTag))
				{
					if (Singleton<Info>.Instance.AxisInputOptimize && (inputAxisHandle.GetCacheAxisValue() != 0f || force))
					{
						inputAxisHandle.InputAxis(0f);
						inputAxisHandle.InputAxisIgnoreLimit(0f);
						return;
					}
					inputAxisHandle.InputAxisIgnoreLimit(value);
					return;
				}
			}
			inputAxisHandle.InputAxis(value);
			inputAxisHandle.InputAxisIgnoreLimit(value);
			this.EmitAxisEventForCond(axisName, value);
			if (Math.Abs(value) > 0f)
			{
				this.CurrentAxisName = axisName;
				return;
			}
			if (this.CurrentAxisName != null)
			{
				this.CurrentAxisName = null;
			}
		}

		// Token: 0x0603185B RID: 202843 RVA: 0x00C57664 File Offset: 0x00C55864
		private void EmitAxisEventForCond(string axisName, float value)
		{
			if (this.CurrentActionName != axisName)
			{
				this.LastAxisValue = 0f;
			}
			if (Math.Abs(value) == 0f)
			{
				return;
			}
			if (Math.Abs(value - this.LastAxisValue) > 0.05f)
			{
				this.CurrentActionName = axisName;
				Singleton<EventSystem>.Instance.Emit(EEventName.OnInputChangeForCond);
				this.LastAxisValue = value;
			}
		}

		// Token: 0x0603185C RID: 202844 RVA: 0x00C576CA File Offset: 0x00C558CA
		[NullableContext(2)]
		public string GetCurrentAxisName()
		{
			return this.CurrentAxisName;
		}

		// Token: 0x0603185D RID: 202845 RVA: 0x00C576D4 File Offset: 0x00C558D4
		public void InputTouch(int touchId, InputDistributeDefine.ITouchData touchData)
		{
			InputTouchHandle inputTouchHandle = this.GetInputTouchHandle(touchId);
			if (inputTouchHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "输入Action时，没有对应的ActionHandle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("touchId", touchId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			string inputDistributeTag = inputTouchHandle.GetInputDistributeTag();
			if (inputDistributeTag != null && !this.IsTagMatchAnyCurrentInputTag(inputDistributeTag, false))
			{
				return;
			}
			inputTouchHandle.InputTouch(touchData);
		}

		// Token: 0x0603185E RID: 202846 RVA: 0x00C57738 File Offset: 0x00C55938
		public void BindAction(string actionName, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			InputActionHandle inputActionHandle = this.GetInputActionHandle(actionName);
			if (inputActionHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "绑定Action回调时，没有对应的ActionHandle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", actionName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputActionHandle.BindAction(actionCallback);
		}

		// Token: 0x0603185F RID: 202847 RVA: 0x00C57780 File Offset: 0x00C55980
		public void ExecuteDelayInputAction(string actionName)
		{
			InputActionHandle inputActionHandle = this.GetInputActionHandle(actionName);
			if (inputActionHandle != null && this.InputDistributeDelayMap.ContainsKey(actionName))
			{
				InputDistributeDelay inputDistributeDelay;
				this.InputDistributeDelayMap.TryGetValue(actionName, out inputDistributeDelay);
				if (inputDistributeDelay.IsInputActive(false))
				{
					inputActionHandle.InputAction(false);
				}
			}
		}

		// Token: 0x06031860 RID: 202848 RVA: 0x00C577C8 File Offset: 0x00C559C8
		public void BindActions(IReadOnlyList<string> actionNames, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			foreach (string actionName in actionNames)
			{
				this.BindAction(actionName, actionCallback);
			}
		}

		// Token: 0x06031861 RID: 202849 RVA: 0x00C57814 File Offset: 0x00C55A14
		public void UnBindAction(string actionName, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			InputActionHandle inputActionHandle = this.GetInputActionHandle(actionName);
			if (inputActionHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "取消绑定Action回调时，没有对应的ActionHandle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", actionName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputActionHandle.UnBindAction(actionCallback);
		}

		// Token: 0x06031862 RID: 202850 RVA: 0x00C5785C File Offset: 0x00C55A5C
		public void UnBindActions(IReadOnlyList<string> actionNames, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			foreach (string actionName in actionNames)
			{
				this.UnBindAction(actionName, actionCallback);
			}
		}

		// Token: 0x06031863 RID: 202851 RVA: 0x00C578A8 File Offset: 0x00C55AA8
		public void BindActionIgnoreLimit(string actionName, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			InputActionHandle inputActionHandle = this.GetInputActionHandle(actionName);
			if (inputActionHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "绑定Action回调时，没有对应的ActionHandle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", actionName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputActionHandle.BindActionIgnoreLimit(actionCallback);
		}

		// Token: 0x06031864 RID: 202852 RVA: 0x00C578F0 File Offset: 0x00C55AF0
		public void UnBindActionIgnoreLimit(string actionName, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			InputActionHandle inputActionHandle = this.GetInputActionHandle(actionName);
			if (inputActionHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "取消绑定Action回调时，没有对应的ActionHandle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", actionName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputActionHandle.UnBindActionIgnoreLimit(actionCallback);
		}

		// Token: 0x06031865 RID: 202853 RVA: 0x00C57937 File Offset: 0x00C55B37
		public void PreventIgnoredActionRelease(bool enable, string key)
		{
			if (enable)
			{
				this.PreventIgnoredActionSet.Add(key);
			}
			else
			{
				this.PreventIgnoredActionSet.Remove(key);
			}
			this.PreventIgnoredActionEnabled = (this.PreventIgnoredActionSet.Count > 0);
		}

		// Token: 0x06031866 RID: 202854 RVA: 0x00C5796C File Offset: 0x00C55B6C
		public bool IsPreventIgnoredAction(string actionName)
		{
			if (!this.PreventIgnoredActionEnabled)
			{
				return false;
			}
			InputActionHandle inputActionHandle = this.GetInputActionHandle(actionName);
			return inputActionHandle != null && inputActionHandle.HasIgnoreLimit();
		}

		// Token: 0x06031867 RID: 202855 RVA: 0x00C57998 File Offset: 0x00C55B98
		private InputActionHandle NewInputActionHandle(string actionName, string inputDistributeTag)
		{
			InputActionHandle inputActionHandle;
			this.InputActionHandleMap.TryGetValue(actionName, out inputActionHandle);
			if (inputActionHandle != null)
			{
				return inputActionHandle;
			}
			inputActionHandle = new InputActionHandle(inputDistributeTag, actionName);
			this.InputActionHandleMap[actionName] = inputActionHandle;
			return inputActionHandle;
		}

		// Token: 0x06031868 RID: 202856 RVA: 0x00C579D0 File Offset: 0x00C55BD0
		[return: Nullable(2)]
		private InputActionHandle GetInputActionHandle(string actionName)
		{
			InputActionHandle result;
			this.InputActionHandleMap.TryGetValue(actionName, out result);
			return result;
		}

		// Token: 0x06031869 RID: 202857 RVA: 0x00C579F0 File Offset: 0x00C55BF0
		public void BindAxis(string axisName, TInputHandle<float> axisCallback)
		{
			InputAxisHandle inputAxisHandle = this.GetInputAxisHandle(axisName);
			if (inputAxisHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "绑定Axis回调时，没有对应的ActionHandle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("axisName", axisName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputAxisHandle.BindAxis(axisCallback);
		}

		// Token: 0x0603186A RID: 202858 RVA: 0x00C57A38 File Offset: 0x00C55C38
		public void BindAxes(IReadOnlyList<string> axisNames, TInputHandle<float> axisCallback)
		{
			foreach (string axisName in axisNames)
			{
				this.BindAxis(axisName, axisCallback);
			}
		}

		// Token: 0x0603186B RID: 202859 RVA: 0x00C57A84 File Offset: 0x00C55C84
		public float GetAxisValue(string axisName)
		{
			InputAxisHandle inputAxisHandle = this.GetInputAxisHandle(axisName);
			if (inputAxisHandle == null)
			{
				return 0f;
			}
			return inputAxisHandle.GetCacheAxisValue();
		}

		// Token: 0x0603186C RID: 202860 RVA: 0x00C57AA8 File Offset: 0x00C55CA8
		public void UnBindAxis(string axisName, TInputHandle<float> axisCallback)
		{
			InputAxisHandle inputAxisHandle = this.GetInputAxisHandle(axisName);
			if (inputAxisHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "取消绑定Action回调时，没有对应的ActionHandle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("axisName", axisName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputAxisHandle.UnBindAxis(axisCallback);
		}

		// Token: 0x0603186D RID: 202861 RVA: 0x00C57AF0 File Offset: 0x00C55CF0
		public void UnBindAxes(IReadOnlyList<string> axisNames, TInputHandle<float> axisCallback)
		{
			foreach (string axisName in axisNames)
			{
				this.UnBindAxis(axisName, axisCallback);
			}
		}

		// Token: 0x0603186E RID: 202862 RVA: 0x00C57B3C File Offset: 0x00C55D3C
		public void BindAxisIgnoreLimit(string axisName, TInputHandle<float> axisCallback)
		{
			InputAxisHandle inputAxisHandle = this.GetInputAxisHandle(axisName);
			if (inputAxisHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "绑定Axis回调时，没有对应的ActionHandle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("axisName", axisName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputAxisHandle.BindAxisIgnoreLimit(axisCallback);
		}

		// Token: 0x0603186F RID: 202863 RVA: 0x00C57B84 File Offset: 0x00C55D84
		public void UnBindAxisIgnoreLimit(string axisName, TInputHandle<float> axisCallback)
		{
			InputAxisHandle inputAxisHandle = this.GetInputAxisHandle(axisName);
			if (inputAxisHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "取消绑定Axis回调时，没有对应的ActionHandle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("axisName", axisName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputAxisHandle.UnBindAxisIgnoreLimit(axisCallback);
		}

		// Token: 0x06031870 RID: 202864 RVA: 0x00C57BCC File Offset: 0x00C55DCC
		public bool IsAxisRespondable(string axisName)
		{
			InputAxisHandle inputAxisHandle = this.GetInputAxisHandle(axisName);
			if (inputAxisHandle == null || !inputAxisHandle.HasCallback())
			{
				return false;
			}
			string inputDistributeTag = inputAxisHandle.GetInputDistributeTag();
			return string.IsNullOrEmpty(inputDistributeTag) || this.IsTagMatchAnyCurrentInputTag(inputDistributeTag, false);
		}

		// Token: 0x06031871 RID: 202865 RVA: 0x00C57C08 File Offset: 0x00C55E08
		public void BindTouch(int touchId, TInputHandle<InputDistributeDefine.ITouchData> touchCallback)
		{
			InputTouchHandle inputTouchHandle = this.GetInputTouchHandle(touchId);
			if (inputTouchHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "绑定Touch回调时，没有对应的ActionHandle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("axisName", touchId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputTouchHandle.BindTouch(touchCallback);
		}

		// Token: 0x06031872 RID: 202866 RVA: 0x00C57C54 File Offset: 0x00C55E54
		public void BindTouches(int[] touchIdList, TInputHandle<InputDistributeDefine.ITouchData> touchCallback)
		{
			foreach (int touchId in touchIdList)
			{
				this.BindTouch(touchId, touchCallback);
			}
		}

		// Token: 0x06031873 RID: 202867 RVA: 0x00C57C80 File Offset: 0x00C55E80
		public void UnBindTouch(int touchId, TInputHandle<InputDistributeDefine.ITouchData> touchCallback)
		{
			InputTouchHandle inputTouchHandle = this.GetInputTouchHandle(touchId);
			if (inputTouchHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "取消绑定Touch回调时，没有对应的ActionHandle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("axisName", touchId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputTouchHandle.UnBindTouch(touchCallback);
		}

		// Token: 0x06031874 RID: 202868 RVA: 0x00C57CCC File Offset: 0x00C55ECC
		public void UnBindTouches(IReadOnlyList<int> touchIdList, TInputHandle<InputDistributeDefine.ITouchData> touchCallback)
		{
			foreach (int touchId in touchIdList)
			{
				this.UnBindTouch(touchId, touchCallback);
			}
		}

		// Token: 0x06031875 RID: 202869 RVA: 0x00C57D18 File Offset: 0x00C55F18
		private InputAxisHandle NewInputAxisHandle(string actionName, string inputDistributeTag)
		{
			InputAxisHandle inputAxisHandle;
			this.InputAxisHandleMap.TryGetValue(actionName, out inputAxisHandle);
			if (inputAxisHandle != null)
			{
				return inputAxisHandle;
			}
			inputAxisHandle = new InputAxisHandle(inputDistributeTag, actionName);
			this.InputAxisHandleMap[actionName] = inputAxisHandle;
			return inputAxisHandle;
		}

		// Token: 0x06031876 RID: 202870 RVA: 0x00C57D50 File Offset: 0x00C55F50
		[return: Nullable(2)]
		private InputAxisHandle GetInputAxisHandle(string actionName)
		{
			InputAxisHandle result;
			this.InputAxisHandleMap.TryGetValue(actionName, out result);
			return result;
		}

		// Token: 0x06031877 RID: 202871 RVA: 0x00C57D70 File Offset: 0x00C55F70
		private InputTouchHandle NewInputTouchHandle(int touchId, string inputDistributeTag)
		{
			InputTouchHandle inputTouchHandle = new InputTouchHandle(inputDistributeTag, touchId.ToString());
			this.InputTouchHandleMap[touchId] = inputTouchHandle;
			return inputTouchHandle;
		}

		// Token: 0x06031878 RID: 202872 RVA: 0x00C57D9C File Offset: 0x00C55F9C
		[NullableContext(2)]
		private InputTouchHandle GetInputTouchHandle(int touchId)
		{
			InputTouchHandle result;
			this.InputTouchHandleMap.TryGetValue(touchId, out result);
			return result;
		}

		// Token: 0x06031879 RID: 202873 RVA: 0x00C57DBC File Offset: 0x00C55FBC
		private InputKeyHandle NewInputKeyHandle(string keyName, string inputDistributeTag)
		{
			InputKeyHandle inputKeyHandle = new InputKeyHandle(inputDistributeTag, keyName);
			this.InputKeyHandleMap[keyName] = inputKeyHandle;
			return inputKeyHandle;
		}

		// Token: 0x0603187A RID: 202874 RVA: 0x00C57DE0 File Offset: 0x00C55FE0
		[return: Nullable(2)]
		private InputKeyHandle GetInputKeyHandle(string keyName)
		{
			InputKeyHandle result;
			this.InputKeyHandleMap.TryGetValue(keyName, out result);
			return result;
		}

		// Token: 0x0603187B RID: 202875 RVA: 0x00C57E00 File Offset: 0x00C56000
		public void BindKey(string keyName, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			InputKeyHandle inputKeyHandle = this.GetInputKeyHandle(keyName);
			if (inputKeyHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "绑定Key回调时，没有对应的KeyHandle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("keyName", keyName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputKeyHandle.BindAction(actionCallback);
		}

		// Token: 0x0603187C RID: 202876 RVA: 0x00C57E48 File Offset: 0x00C56048
		public void UnBindKey(string keyName, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			InputKeyHandle inputKeyHandle = this.GetInputKeyHandle(keyName);
			if (inputKeyHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "取消绑定Key回调时，没有对应的KeyHandle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("keyName", keyName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputKeyHandle.UnBindAction(actionCallback);
		}

		// Token: 0x0603187D RID: 202877 RVA: 0x00C57E90 File Offset: 0x00C56090
		public void InputKey(string keyName, bool bPress)
		{
			InputKeyHandle inputKeyHandle = this.GetInputKeyHandle(keyName);
			if (inputKeyHandle == null)
			{
				return;
			}
			string inputDistributeTag = inputKeyHandle.GetInputDistributeTag();
			if (inputDistributeTag != null && !this.IsTagMatchAnyCurrentInputTag(inputDistributeTag, false))
			{
				return;
			}
			inputKeyHandle.InputKey(bPress);
		}

		// Token: 0x0603187E RID: 202878 RVA: 0x00C57EC5 File Offset: 0x00C560C5
		public bool HasAnyNotAllowFightInputViewIsOpen()
		{
			return this.NotAllowFightInputViewNameSet.Count > 0;
		}

		// Token: 0x0603187F RID: 202879 RVA: 0x00C57ED5 File Offset: 0x00C560D5
		public bool HasNotAllowFightInputViewIsOpen(EUiViewName uiViewName)
		{
			return this.NotAllowFightInputViewNameSet.Contains(uiViewName);
		}

		// Token: 0x06031880 RID: 202880 RVA: 0x00C57EE3 File Offset: 0x00C560E3
		public void AddNotAllowFightInputViewName(EUiViewName uiViewName)
		{
			this.NotAllowFightInputViewNameSet.Add(uiViewName);
		}

		// Token: 0x06031881 RID: 202881 RVA: 0x00C57EF2 File Offset: 0x00C560F2
		public void RemoveNotAllowFightInputViewName(EUiViewName uiViewName)
		{
			this.NotAllowFightInputViewNameSet.Remove(uiViewName);
		}

		// Token: 0x06031882 RID: 202882 RVA: 0x00C57F01 File Offset: 0x00C56101
		public void ClearAllNotAllowFightInputViewNames()
		{
			this.NotAllowFightInputViewNameSet.Clear();
		}

		// Token: 0x06031883 RID: 202883 RVA: 0x00C57F0E File Offset: 0x00C5610E
		public HashSet<EUiViewName> GetNotAllowFightInputViewNameSet()
		{
			return this.NotAllowFightInputViewNameSet;
		}

		// Token: 0x06031884 RID: 202884 RVA: 0x00C57F18 File Offset: 0x00C56118
		private void InitializeInputDistributeTags()
		{
			foreach (ValueTuple<string, string> valueTuple in InputDistributeDefine.InitializeInputDistributeTagDefine)
			{
				string item = valueTuple.Item1;
				string item2 = valueTuple.Item2;
				InputDistributeTag inputDistributeTag = this.GetInputDistributeTag(item2);
				this.NewInputDistributeTag(item, inputDistributeTag);
			}
		}

		// Token: 0x06031885 RID: 202885 RVA: 0x00C57F80 File Offset: 0x00C56180
		private InputDistributeTag NewInputDistributeTag(string tag, [Nullable(2)] InputDistributeTag parentTag = null)
		{
			InputDistributeTag inputDistributeTag = new InputDistributeTag(tag, parentTag);
			this.InputDistributeTagMap[tag] = inputDistributeTag;
			return inputDistributeTag;
		}

		// Token: 0x06031886 RID: 202886 RVA: 0x00C57FA4 File Offset: 0x00C561A4
		[NullableContext(2)]
		public InputDistributeTag GetInputDistributeTag(string tag)
		{
			if (tag == null)
			{
				return null;
			}
			InputDistributeTag result;
			this.InputDistributeTagMap.TryGetValue(tag, out result);
			return result;
		}

		// Token: 0x06031887 RID: 202887 RVA: 0x00C57FC8 File Offset: 0x00C561C8
		public bool MatchTag(string tag, InputDistributeTag inputDistributeTag, bool bExactMatch = false)
		{
			InputDistributeTag inputDistributeTag2 = this.GetInputDistributeTag(tag);
			return inputDistributeTag != null && inputDistributeTag2.MatchTag(inputDistributeTag.TagName, bExactMatch);
		}

		// Token: 0x06031888 RID: 202888 RVA: 0x00C57FEF File Offset: 0x00C561EF
		public bool IsTagMatchAnyCurrentInputTag(string tag, bool bExactMatch = false)
		{
			return this.IsTagMatchAnyInputDistributeTags(tag, this.InputDistributeTags, bExactMatch);
		}

		// Token: 0x06031889 RID: 202889 RVA: 0x00C58000 File Offset: 0x00C56200
		public bool IsAnyInputDistributeTagsMatchTag(List<InputDistributeTag> inputDistributeTags, string tag, bool bExactMatch = false)
		{
			using (List<InputDistributeTag>.Enumerator enumerator = inputDistributeTags.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.MatchTag(tag, bExactMatch))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603188A RID: 202890 RVA: 0x00C58058 File Offset: 0x00C56258
		public bool IsTagMatchAnyInputDistributeTags(string tag, List<InputDistributeTag> inputDistributeTags, bool bExactMatch = false)
		{
			InputDistributeTag inputDistributeTag = this.GetInputDistributeTag(tag);
			if (inputDistributeTag != null)
			{
				foreach (InputDistributeTag inputDistributeTag2 in inputDistributeTags)
				{
					if (inputDistributeTag.MatchTag(inputDistributeTag2.TagName, bExactMatch))
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x0603188B RID: 202891 RVA: 0x00C580C0 File Offset: 0x00C562C0
		public bool IsTagMatchInputDistributeTags(string tag, string[] inputDistributeTags, bool bExactMatch = false)
		{
			InputDistributeTag inputDistributeTag = this.GetInputDistributeTag(tag);
			if (inputDistributeTag == null)
			{
				return false;
			}
			foreach (string tag2 in inputDistributeTags)
			{
				if (inputDistributeTag.MatchTag(tag2, bExactMatch))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603188C RID: 202892 RVA: 0x00C580FC File Offset: 0x00C562FC
		public void AddToLimitInputDistributeActions(string actionName)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[InputDistribute]设置输入分发限制Action";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", actionName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.LimitInputDistributeActionSet.Add(actionName);
		}

		// Token: 0x0603188D RID: 202893 RVA: 0x00C58140 File Offset: 0x00C56340
		public void ClearLimitInputDistributeActions()
		{
			Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]清除输入分发限制Action", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.LimitInputDistributeActionSet.Clear();
		}

		// Token: 0x0603188E RID: 202894 RVA: 0x00C58174 File Offset: 0x00C56374
		public bool HasActionLimitSet()
		{
			return this.LimitInputDistributeActionSet.Count > 0;
		}

		// Token: 0x0603188F RID: 202895 RVA: 0x00C58184 File Offset: 0x00C56384
		public bool IsActionInLimitSet(string actionName)
		{
			return this.LimitInputDistributeActionSet.Contains(actionName);
		}

		// Token: 0x06031890 RID: 202896 RVA: 0x00C58194 File Offset: 0x00C56394
		public void AddInputDistributeTag(string tagName)
		{
			if (!this.AddInputDistributeTagInternal(tagName))
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[InputDistribute]添加输入分发Tag";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tagName", tagName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<InputDistributeTag>>(EEventName.OnInputDistributeTagChanged, this.InputDistributeTags);
			this.OnInputDistributeTagChanged();
		}

		// Token: 0x06031891 RID: 202897 RVA: 0x00C581F0 File Offset: 0x00C563F0
		private bool AddInputDistributeTagInternal(string tagName)
		{
			InputDistributeTag inputDistributeTag = this.GetInputDistributeTag(tagName);
			if (inputDistributeTag == null)
			{
				return false;
			}
			this.InputDistributeTags.Add(inputDistributeTag);
			return true;
		}

		// Token: 0x06031892 RID: 202898 RVA: 0x00C58218 File Offset: 0x00C56418
		public void SetInputDistributeTag(string tagName)
		{
			InputDistributeTag inputDistributeTag = this.GetInputDistributeTag(tagName);
			if (inputDistributeTag == null)
			{
				return;
			}
			this.InputDistributeTags = new List<InputDistributeTag>
			{
				inputDistributeTag
			};
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[InputDistribute]设置输入分发Tag";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tagName", tagName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<InputDistributeTag>>(EEventName.OnInputDistributeTagChanged, this.InputDistributeTags);
			this.OnInputDistributeTagChanged();
		}

		// Token: 0x06031893 RID: 202899 RVA: 0x00C58288 File Offset: 0x00C56488
		public void SetInputDistributeTags(IList<string> tagNames)
		{
			this.ClearInputDistributeTag();
			foreach (string tagName in tagNames)
			{
				this.AddInputDistributeTagInternal(tagName);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[InputDistribute]设置输入分发Tag";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tagNames", tagNames);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<InputDistributeTag>>(EEventName.OnInputDistributeTagChanged, this.InputDistributeTags);
			this.OnInputDistributeTagChanged();
		}

		// Token: 0x06031894 RID: 202900 RVA: 0x00C5831C File Offset: 0x00C5651C
		public void RemoveInputDistributeTag(string tagName, bool bRemoveChild = false)
		{
			InputDistributeTag inputDistributeTag = this.GetInputDistributeTag(tagName);
			if (inputDistributeTag == null)
			{
				return;
			}
			if (bRemoveChild)
			{
				List<InputDistributeTag> list = new List<InputDistributeTag>();
				foreach (InputDistributeTag inputDistributeTag2 in this.InputDistributeTags)
				{
					if (inputDistributeTag2.MatchTag(inputDistributeTag.TagName, false))
					{
						list.Add(inputDistributeTag2);
					}
				}
				using (List<InputDistributeTag>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						InputDistributeTag item = enumerator.Current;
						int num = this.InputDistributeTags.IndexOf(item);
						if (num >= 0)
						{
							this.InputDistributeTags.RemoveAt(num);
						}
					}
					return;
				}
			}
			int num2 = this.InputDistributeTags.IndexOf(inputDistributeTag);
			if (num2 < 0)
			{
				return;
			}
			this.InputDistributeTags.RemoveAt(num2);
		}

		// Token: 0x06031895 RID: 202901 RVA: 0x00C58410 File Offset: 0x00C56610
		public void ClearInputDistributeTag()
		{
			this.InputDistributeTags.Clear();
		}

		// Token: 0x06031896 RID: 202902 RVA: 0x00C58420 File Offset: 0x00C56620
		private void OnInputDistributeTagChanged()
		{
			foreach (string text in this.TagChangedCallbacks.Keys)
			{
				HashSet<TInputTagChangedCallback> hashSet;
				this.TagChangedCallbacks.TryGetValue(text, out hashSet);
				if (hashSet == null || hashSet.Count == 0)
				{
					return;
				}
				bool flag = this.IsTagMatchAnyInputDistributeTags(text, this.LastInputDistributeTags, false);
				bool flag2 = this.IsTagMatchAnyInputDistributeTags(text, this.InputDistributeTags, false);
				if (flag != flag2)
				{
					this.EmitInputDistributeTagChanged(hashSet, text, flag2);
				}
			}
			this.LastInputDistributeTags = new List<InputDistributeTag>(this.InputDistributeTags);
		}

		// Token: 0x06031897 RID: 202903 RVA: 0x00C584CC File Offset: 0x00C566CC
		private unsafe void EmitInputDistributeTagChanged(HashSet<TInputTagChangedCallback> callbackSet, string tagName, bool isExist)
		{
			foreach (TInputTagChangedCallback tinputTagChangedCallback in callbackSet)
			{
				try
				{
					tinputTagChangedCallback(tagName, isExist);
				}
				catch (Exception ex)
				{
					if (ex != null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Input;
						ELogAuthor author = ELogAuthor.YYZ;
						string message = "[InputDistribute]Tag事件回调执行异常";
						Exception error = ex;
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("tag", tagName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
						instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					}
					else
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Input;
						ELogAuthor author2 = ELogAuthor.YYZ;
						string message2 = "[InputDistribute]Tag事件回调执行异常";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("tag", tagName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("error", ex);
						instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					}
				}
			}
		}

		// Token: 0x06031898 RID: 202904 RVA: 0x00C585EC File Offset: 0x00C567EC
		public void AddInputDistributeTagChangedListener(string tagName, TInputTagChangedCallback callback)
		{
			if (tagName == null || callback == null)
			{
				return;
			}
			HashSet<TInputTagChangedCallback> hashSet = null;
			this.TagChangedCallbacks.TryGetValue(tagName, out hashSet);
			if (hashSet == null)
			{
				hashSet = new HashSet<TInputTagChangedCallback>();
				this.TagChangedCallbacks[tagName] = hashSet;
			}
			if (hashSet.Contains(callback))
			{
				return;
			}
			hashSet.Add(callback);
		}

		// Token: 0x06031899 RID: 202905 RVA: 0x00C5863C File Offset: 0x00C5683C
		public void RemoveInputDistributeTagChangedListener(string tagName, TInputTagChangedCallback callback)
		{
			HashSet<TInputTagChangedCallback> hashSet;
			this.TagChangedCallbacks.TryGetValue(tagName, out hashSet);
			if (hashSet == null)
			{
				return;
			}
			hashSet.Remove(callback);
			if (hashSet.Count == 0)
			{
				this.TagChangedCallbacks.Remove(tagName);
			}
		}

		// Token: 0x0603189A RID: 202906 RVA: 0x00C58679 File Offset: 0x00C56879
		public bool IsAllowFightInput()
		{
			return this.IsAnyInputDistributeTagsMatchTag(this.InputDistributeTags, "FightInputRoot", false);
		}

		// Token: 0x0603189B RID: 202907 RVA: 0x00C5868D File Offset: 0x00C5688D
		public bool IsAllowFightMoveInput()
		{
			return this.IsTagMatchAnyInputDistributeTags("FightInputRoot.FightInput.AxisInput.MoveInput", this.InputDistributeTags, false);
		}

		// Token: 0x0603189C RID: 202908 RVA: 0x00C586A1 File Offset: 0x00C568A1
		public bool IsAllowFightActionInput()
		{
			return this.IsTagMatchAnyInputDistributeTags("FightInputRoot.FightInput.ActionInput", this.InputDistributeTags, false);
		}

		// Token: 0x0603189D RID: 202909 RVA: 0x00C586B5 File Offset: 0x00C568B5
		public bool IsAllowFightCameraRotationInput()
		{
			return this.IsTagMatchAnyInputDistributeTags("FightInputRoot.FightInput.AxisInput.CameraInput.CameraRotation", this.InputDistributeTags, false);
		}

		// Token: 0x0603189E RID: 202910 RVA: 0x00C586C9 File Offset: 0x00C568C9
		public bool IsAllowFightCameraZoomInput()
		{
			return this.IsTagMatchAnyInputDistributeTags("FightInputRoot.FightInput.AxisInput.CameraInput.CameraZoom", this.InputDistributeTags, false);
		}

		// Token: 0x0603189F RID: 202911 RVA: 0x00C586DD File Offset: 0x00C568DD
		public bool IsAllowHeadRotation()
		{
			return this.IsAllowFightInput() || this.IsTagMatchAnyInputDistributeTags("UiInputRoot.MouseInputTag", this.InputDistributeTags, false);
		}

		// Token: 0x060318A0 RID: 202912 RVA: 0x00C586FB File Offset: 0x00C568FB
		public bool IsAllowUiInput()
		{
			return this.IsTagMatchAnyInputDistributeTags("UiInputRoot", this.InputDistributeTags, false);
		}

		// Token: 0x060318A1 RID: 202913 RVA: 0x00C58710 File Offset: 0x00C56910
		[return: Nullable(2)]
		public string GetActionInputDistributeTagName(string actionName)
		{
			InputActionHandle inputActionHandle;
			this.InputActionHandleMap.TryGetValue(actionName, out inputActionHandle);
			if (inputActionHandle == null)
			{
				return null;
			}
			return inputActionHandle.GetInputDistributeTag();
		}

		// Token: 0x060318A2 RID: 202914 RVA: 0x00C58738 File Offset: 0x00C56938
		[return: Nullable(2)]
		public string GetAxisInputDistributeTagName(string axisName)
		{
			InputAxisHandle inputAxisHandle;
			this.InputAxisHandleMap.TryGetValue(axisName, out inputAxisHandle);
			if (inputAxisHandle == null)
			{
				return null;
			}
			return inputAxisHandle.GetInputDistributeTag();
		}

		// Token: 0x0401CCC2 RID: 117954
		private const float EMIT_EVENT_AXIS_DELTA = 0.05f;

		// Token: 0x0401CCC3 RID: 117955
		private List<InputDistributeTag> InputDistributeTags = new List<InputDistributeTag>();

		// Token: 0x0401CCC4 RID: 117956
		private List<InputDistributeTag> LastInputDistributeTags = new List<InputDistributeTag>();

		// Token: 0x0401CCC5 RID: 117957
		private readonly HashSet<string> LimitInputDistributeActionSet = new HashSet<string>();

		// Token: 0x0401CCC6 RID: 117958
		private readonly List<InputDistributeSetup> InputDistributeSetups = new List<InputDistributeSetup>();

		// Token: 0x0401CCC7 RID: 117959
		private readonly Dictionary<string, InputDistributeTag> InputDistributeTagMap = new Dictionary<string, InputDistributeTag>();

		// Token: 0x0401CCC8 RID: 117960
		private readonly Dictionary<string, InputDistributeDelay> InputDistributeDelayMap = new Dictionary<string, InputDistributeDelay>();

		// Token: 0x0401CCC9 RID: 117961
		private readonly Dictionary<string, InputKeyHandle> InputKeyHandleMap = new Dictionary<string, InputKeyHandle>();

		// Token: 0x0401CCCA RID: 117962
		private readonly Dictionary<string, InputActionHandle> InputActionHandleMap = new Dictionary<string, InputActionHandle>();

		// Token: 0x0401CCCB RID: 117963
		private readonly Dictionary<string, InputAxisHandle> InputAxisHandleMap = new Dictionary<string, InputAxisHandle>();

		// Token: 0x0401CCCC RID: 117964
		private readonly Dictionary<int, InputTouchHandle> InputTouchHandleMap = new Dictionary<int, InputTouchHandle>();

		// Token: 0x0401CCCD RID: 117965
		private readonly HashSet<EUiViewName> NotAllowFightInputViewNameSet = new HashSet<EUiViewName>();

		// Token: 0x0401CCCE RID: 117966
		[Nullable(2)]
		private string CurrentActionName;

		// Token: 0x0401CCCF RID: 117967
		[Nullable(2)]
		private string CurrentAxisName;

		// Token: 0x0401CCD0 RID: 117968
		private readonly Dictionary<string, HashSet<TInputTagChangedCallback>> TagChangedCallbacks = new Dictionary<string, HashSet<TInputTagChangedCallback>>();

		// Token: 0x0401CCD1 RID: 117969
		private float LastAxisValue;

		// Token: 0x0401CCD2 RID: 117970
		private bool PreventIgnoredActionEnabled;

		// Token: 0x0401CCD3 RID: 117971
		private readonly HashSet<string> PreventIgnoredActionSet = new HashSet<string>();
	}
}
