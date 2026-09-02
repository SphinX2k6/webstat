using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Controller
{
	// Token: 0x02007055 RID: 28757
	[NullableContext(1)]
	[Nullable(0)]
	public class CombinationActionHandle
	{
		// Token: 0x06045A0C RID: 285196 RVA: 0x01231633 File Offset: 0x0122F833
		public void Clear()
		{
			this.PressCombinationActionBindingList = null;
			this.BlockInputKeySet.Clear();
		}

		// Token: 0x06045A0D RID: 285197 RVA: 0x01231647 File Offset: 0x0122F847
		public IReadOnlySet<string> GetBlockInputKeySet()
		{
			return this.BlockInputKeySet;
		}

		// Token: 0x06045A0E RID: 285198 RVA: 0x01231650 File Offset: 0x0122F850
		public void PressAnyKey(string keyName)
		{
			if (this.PressMainKeyName == null)
			{
				if (Singleton<InputSettingsManager>.Instance.IsCombinationActionMainKey(keyName))
				{
					this.PressMainKey(keyName);
				}
				return;
			}
			IReadOnlyDictionary<string, InputCombinationActionBinding> combinationActionBindingByKeyName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByKeyName(this.PressMainKeyName, keyName);
			if (combinationActionBindingByKeyName == null || combinationActionBindingByKeyName.Count <= 0)
			{
				return;
			}
			List<InputCombinationActionBinding> list = new List<InputCombinationActionBinding>();
			foreach (InputCombinationActionBinding inputCombinationActionBinding in combinationActionBindingByKeyName.Values)
			{
				if (inputCombinationActionBinding.HasCombinationAction(this.PressMainKeyName, keyName))
				{
					list.Add(inputCombinationActionBinding);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			if (this.PressSecondaryKeyName != null && this.PressSecondaryKeyName != keyName)
			{
				this.ReleaseAnyKey(this.PressSecondaryKeyName);
			}
			this.PressSecondaryKeyName = keyName;
			this.TriggerPressCombinationAction(list);
		}

		// Token: 0x06045A0F RID: 285199 RVA: 0x0123172C File Offset: 0x0122F92C
		public void ReleaseAnyKey(string keyName)
		{
			if (this.PressSecondaryKeyName == keyName && this.PressCombinationActionBindingList != null)
			{
				this.TriggerReleaseCombinationAction();
				this.PressSecondaryKeyName = null;
				return;
			}
			if (this.PressMainKeyName == keyName)
			{
				this.ReleaseMainKey();
			}
		}

		// Token: 0x06045A10 RID: 285200 RVA: 0x01231768 File Offset: 0x0122F968
		private void PressMainKey(string pressKeyName)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[Input]按下组合Action主键";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MainKeyName", pressKeyName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.PressMainKeyName = pressKeyName;
			this.PressMainKeyTimeStamp = (long)Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		}

		// Token: 0x06045A11 RID: 285201 RVA: 0x012317B4 File Offset: 0x0122F9B4
		private void ReleaseMainKey()
		{
			if (this.PressSecondaryKeyName != null && this.PressCombinationActionBindingList != null)
			{
				this.TriggerReleaseCombinationAction();
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[Input]抬起组合Action主键";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MainKeyName", this.PressMainKeyName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.PressCombinationActionBindingList = null;
			this.PressMainKeyName = null;
			this.PressMainKeyTimeStamp = 0L;
			this.PressSecondaryKeyName = null;
			this.BlockInputKeySet.Clear();
		}

		// Token: 0x06045A12 RID: 285202 RVA: 0x0123182C File Offset: 0x0122FA2C
		private void TriggerPressCombinationAction(IReadOnlyList<InputCombinationActionBinding> combinationActionBindingList)
		{
			this.PressCombinationActionBindingList = combinationActionBindingList;
			foreach (InputCombinationActionBinding inputCombinationActionBinding in combinationActionBindingList)
			{
				string actionName = inputCombinationActionBinding.GetActionName();
				double num = (double)inputCombinationActionBinding.GetSecondaryKeyValidTime();
				if (num <= 0.0 || Singleton<TimeUtil>.Instance.GetServerTimeStamp() - (double)this.PressMainKeyTimeStamp <= num)
				{
					foreach (string item in inputCombinationActionBinding.GetBlockInputKeySet())
					{
						this.BlockInputKeySet.Add(item);
					}
					if (actionName != null)
					{
						ControllerBase<InputDistributeController>.Instance.InputAction(actionName, true);
					}
				}
			}
		}

		// Token: 0x06045A13 RID: 285203 RVA: 0x01231904 File Offset: 0x0122FB04
		private void TriggerReleaseCombinationAction()
		{
			if (this.PressCombinationActionBindingList == null)
			{
				return;
			}
			this.BlockInputKeySet.Clear();
			foreach (InputCombinationActionBinding inputCombinationActionBinding in this.PressCombinationActionBindingList)
			{
				string actionName = inputCombinationActionBinding.GetActionName();
				if (!string.IsNullOrEmpty(actionName))
				{
					try
					{
						ControllerBase<InputDistributeController>.Instance.InputAction(actionName, false);
					}
					catch (Exception)
					{
						Singleton<Log>.Instance.Error(ELogModule.InputSettings, ELogAuthor.XXJ, "抬起组合Action时出现异常", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
				}
			}
		}

		// Token: 0x06045A14 RID: 285204 RVA: 0x012319A8 File Offset: 0x0122FBA8
		public bool CheckCombinationAction(string actionName)
		{
			if (this.PressMainKeyName == null)
			{
				return true;
			}
			InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding(actionName);
			if (actionBinding != null)
			{
				ActionMapping? actionMappingConfig = actionBinding.GetActionMappingConfig();
				if (actionMappingConfig != null && actionMappingConfig.Value.IsIdleAction)
				{
					return true;
				}
				IEnumerable<string> keyNameList = actionBinding.GetKeyNameList();
				bool flag = Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ChineseZitherView);
				foreach (string secondaryKeyName in keyNameList)
				{
					if (Singleton<InputSettingsManager>.Instance.IsCombinationAction(this.PressMainKeyName, secondaryKeyName) && (!flag || this.IsCombinationActionOutputRespondable(this.PressMainKeyName, secondaryKeyName)))
					{
						return false;
					}
				}
				return true;
			}
			return true;
		}

		// Token: 0x06045A15 RID: 285205 RVA: 0x01231A74 File Offset: 0x0122FC74
		private bool IsCombinationActionOutputRespondable(string mainKeyName, string secondaryKeyName)
		{
			IReadOnlyDictionary<string, InputCombinationActionBinding> combinationActionBindingByKeyName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByKeyName(mainKeyName, secondaryKeyName);
			if (combinationActionBindingByKeyName == null)
			{
				return false;
			}
			foreach (InputCombinationActionBinding inputCombinationActionBinding in combinationActionBindingByKeyName.Values)
			{
				if (inputCombinationActionBinding.HasCombinationAction(mainKeyName, secondaryKeyName))
				{
					string actionName = inputCombinationActionBinding.GetActionName();
					if (!string.IsNullOrEmpty(actionName) && ControllerBase<InputDistributeController>.Instance.IsActionRespondable(actionName))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06045A16 RID: 285206 RVA: 0x01231AFC File Offset: 0x0122FCFC
		public bool CheckCombinationActionByAxisName(string axisName)
		{
			if (this.PressMainKeyName == null)
			{
				return true;
			}
			InputAxisBinding axisBinding = Singleton<InputSettingsManager>.Instance.GetAxisBinding(axisName);
			if (axisBinding == null)
			{
				return true;
			}
			List<string> list = new List<string>();
			axisBinding.GetKeyNameList(list);
			foreach (string secondaryKeyName in list)
			{
				if (Singleton<InputSettingsManager>.Instance.IsCombinationAction(this.PressMainKeyName, secondaryKeyName) && this.IsCombinationActionOutputBound(this.PressMainKeyName, secondaryKeyName))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06045A17 RID: 285207 RVA: 0x01231B98 File Offset: 0x0122FD98
		private bool IsCombinationActionOutputBound(string mainKeyName, string secondaryKeyName)
		{
			IReadOnlyDictionary<string, InputCombinationActionBinding> combinationActionBindingByKeyName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByKeyName(mainKeyName, secondaryKeyName);
			if (combinationActionBindingByKeyName == null)
			{
				return false;
			}
			foreach (InputCombinationActionBinding inputCombinationActionBinding in combinationActionBindingByKeyName.Values)
			{
				string actionName = inputCombinationActionBinding.GetActionName();
				if (!string.IsNullOrEmpty(actionName) && ControllerBase<InputDistributeController>.Instance.HasActionBind(actionName))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04026DF0 RID: 159216
		[Nullable(2)]
		private string PressMainKeyName;

		// Token: 0x04026DF1 RID: 159217
		[Nullable(2)]
		private string PressSecondaryKeyName;

		// Token: 0x04026DF2 RID: 159218
		private long PressMainKeyTimeStamp;

		// Token: 0x04026DF3 RID: 159219
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private IReadOnlyList<InputCombinationActionBinding> PressCombinationActionBindingList;

		// Token: 0x04026DF4 RID: 159220
		private readonly HashSet<string> BlockInputKeySet = new HashSet<string>();
	}
}
