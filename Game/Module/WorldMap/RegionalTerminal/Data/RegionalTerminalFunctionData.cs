using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Functional;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.WorldMap.RegionalTerminal.Data
{
	// Token: 0x02004BF5 RID: 19445
	public class RegionalTerminalFunctionData : RegionalTerminalGameplayData
	{
		// Token: 0x06032BE1 RID: 207841 RVA: 0x00CB658E File Offset: 0x00CB478E
		[NullableContext(2)]
		public override void TerminalFunction(Action<bool> callback = null)
		{
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView((EFunctionType)this.GameplayId);
			if (callback != null)
			{
				callback(true);
			}
		}

		// Token: 0x06032BE2 RID: 207842 RVA: 0x00CB65AA File Offset: 0x00CB47AA
		public override void BarFunction()
		{
			if (this.GetLockState())
			{
				ControllerBase<RegionalTerminalController>.Instance.OpenTerminalOverviewView(this.Id);
				return;
			}
			this.TerminalFunction(null);
		}

		// Token: 0x06032BE3 RID: 207843 RVA: 0x00CB65CC File Offset: 0x00CB47CC
		public override bool GetShowState()
		{
			return ModelBase<FunctionModel>.Instance.IsShow(this.GameplayId);
		}

		// Token: 0x06032BE4 RID: 207844 RVA: 0x00CB65E0 File Offset: 0x00CB47E0
		public override ERedDotName? GetRedDotName()
		{
			if (this.GetLockState())
			{
				return null;
			}
			return ModelBase<FunctionModel>.Instance.GetFunctionItemRedDotName(this.GameplayId);
		}

		// Token: 0x06032BE5 RID: 207845 RVA: 0x00CB660F File Offset: 0x00CB480F
		public override int GetRedDotId()
		{
			return 0;
		}

		// Token: 0x06032BE6 RID: 207846 RVA: 0x00CB6614 File Offset: 0x00CB4814
		public override bool GetRedDotState()
		{
			if (this.GetLockState())
			{
				return false;
			}
			ERedDotName? redDotName = this.GetRedDotName();
			if (redDotName == null)
			{
				return false;
			}
			RedDotBase redDot = ModelBase<RedDotModel>.Instance.GetRedDot(redDotName.Value);
			return redDot != null && redDot.IsRedDotActive();
		}

		// Token: 0x06032BE7 RID: 207847 RVA: 0x00CB665F File Offset: 0x00CB485F
		public override bool GetLockState()
		{
			return !ModelBase<FunctionModel>.Instance.IsOpen(this.GameplayId);
		}

		// Token: 0x06032BE8 RID: 207848 RVA: 0x00CB6674 File Offset: 0x00CB4874
		[NullableContext(1)]
		public override IRegionalTerminalViewParams GetViewParams()
		{
			FunctionCondition? functionCondition = ConfigBase<FunctionConfig>.Instance.GetFunctionCondition(this.GameplayId);
			bool lockState = this.GetLockState();
			return new RegionalTerminalViewParams
			{
				ShowLockPanel = lockState,
				ShowButton = !lockState,
				LockClickFunc = new Action(this.OpenFunctionConditionView),
				LockTxtId = ((functionCondition.Value.OpenConditionId > 0) ? (LevelGeneralCommons.GetConditionGroupHintText(functionCondition.Value.OpenConditionId) ?? "") : ""),
				ButtonTxtId = base.GetGameplayConfig().UnlockButtonText
			};
		}

		// Token: 0x06032BE9 RID: 207849 RVA: 0x00CB6714 File Offset: 0x00CB4914
		private void OpenFunctionConditionView()
		{
			List<IActivityConditionData> list = new List<IActivityConditionData>();
			int openConditionId = ConfigBase<FunctionConfig>.Instance.GetFunctionCondition(this.GameplayId).Value.OpenConditionId;
			foreach (int conditionId in ConfigBase<ConditionConfig>.Instance.GetGroupConditionIds(openConditionId))
			{
				Condition? conditionConfig = ConfigBase<ConditionConfig>.Instance.GetConditionConfig(conditionId);
				if (conditionConfig != null)
				{
					int accessType = -1;
					if (!string.IsNullOrEmpty(conditionConfig.Value.Description))
					{
						if (conditionConfig.Value.AccessId > 0)
						{
							AccessPath? configById = ConfigBase<GetWayConfig>.Instance.GetConfigById(conditionConfig.Value.AccessId);
							accessType = ((configById != null) ? configById.GetValueOrDefault().SkipName : -1);
						}
						ActivityConditionData item = new ActivityConditionData
						{
							ConditionId = conditionId,
							ConditionTextId = conditionConfig.Value.Description,
							IsFinished = ModelBase<RegionalTerminalModel>.Instance.GetFuncIdConditionFinishedState(this.GameplayId, conditionId),
							AccessId = conditionConfig.Value.AccessId,
							AccessType = accessType
						};
						list.Add(item);
					}
				}
			}
			ConditionGroupData param = new ConditionGroupData(openConditionId, list, "", false);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonConditionView, param, null);
		}
	}
}
