using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Input.BattleInputData
{
	// Token: 0x02006FE4 RID: 28644
	[NullableContext(1)]
	[Nullable(0)]
	public class SpringManorInputData : BattleInputData
	{
		// Token: 0x0604549A RID: 283802 RVA: 0x01218EE4 File Offset: 0x012170E4
		public SpringManorInputData()
		{
			Dictionary<string, EInputAction> dictionary = new Dictionary<string, EInputAction>();
			dictionary["跳跃"] = EInputAction.跳跃;
			dictionary["走跑切换"] = EInputAction.走跑切换;
			dictionary["闪避"] = EInputAction.闪避;
			dictionary["通用交互"] = EInputAction.通用交互;
			dictionary["下降"] = EInputAction.下降;
			this.ActionMap = dictionary;
			Dictionary<string, EInputAxis> dictionary2 = new Dictionary<string, EInputAxis>();
			dictionary2["LookUp"] = EInputAxis.LookUp;
			dictionary2["Turn"] = EInputAxis.Turn;
			dictionary2["MoveForward"] = EInputAxis.MoveForward;
			dictionary2["MoveRight"] = EInputAxis.MoveRight;
			dictionary2["Zoom"] = EInputAxis.Zoom;
			dictionary2["WheelAxis"] = EInputAxis.WheelAxis;
			this.AxisMap = dictionary2;
			this.AllowActionNameSet = new HashSet<string>
			{
				"任务追踪",
				"切换交互",
				"任务",
				"玩法放弃",
				"幻象探索选择界面",
				"轮盘2",
				"切换角色1",
				"切换角色2",
				"切换角色3"
			};
			this.MatchInputDistributeTag = new string[]
			{
				"FightInputRoot.FightInput.ActionInput",
				"FightInputRoot.FightInput.AxisInput",
				"UiInputRoot.ShortcutKeyTag"
			};
			base..ctor(EInputDataType.SpringManor, EInputBindingType.Original);
		}

		// Token: 0x0604549B RID: 283803 RVA: 0x0121905A File Offset: 0x0121725A
		protected override Dictionary<string, EInputAction> OnGetActionMap()
		{
			return this.ActionMap;
		}

		// Token: 0x0604549C RID: 283804 RVA: 0x01219062 File Offset: 0x01217262
		protected override Dictionary<string, EInputAxis> OnGetAxisMap()
		{
			return this.AxisMap;
		}

		// Token: 0x0604549D RID: 283805 RVA: 0x0121906C File Offset: 0x0121726C
		protected override bool OnCheckActionInAllowFightActionNameList(string actionName, InputActionHandle inputActionHandle)
		{
			if (this.ActionMap.ContainsKey(actionName))
			{
				return true;
			}
			string inputDistributeTag = inputActionHandle.GetInputDistributeTag();
			return string.IsNullOrEmpty(inputDistributeTag) || !ModelBase<InputDistributeModel>.Instance.IsTagMatchInputDistributeTags(inputDistributeTag, this.MatchInputDistributeTag, true) || this.AllowActionNameSet.Contains(actionName);
		}

		// Token: 0x0604549E RID: 283806 RVA: 0x012190C0 File Offset: 0x012172C0
		protected override bool OnCheckAxisInAllowFightAxisNameList(string axisName, InputAxisHandle inputAxisHandle)
		{
			if (this.AxisMap.ContainsKey(axisName))
			{
				return true;
			}
			string inputDistributeTag = inputAxisHandle.GetInputDistributeTag();
			return string.IsNullOrEmpty(inputDistributeTag) || !ModelBase<InputDistributeModel>.Instance.IsTagMatchInputDistributeTags(inputDistributeTag, this.MatchInputDistributeTag, true);
		}

		// Token: 0x04026A8F RID: 158351
		private readonly Dictionary<string, EInputAction> ActionMap;

		// Token: 0x04026A90 RID: 158352
		private readonly Dictionary<string, EInputAxis> AxisMap;

		// Token: 0x04026A91 RID: 158353
		private readonly HashSet<string> AllowActionNameSet;

		// Token: 0x04026A92 RID: 158354
		private readonly string[] MatchInputDistributeTag;
	}
}
