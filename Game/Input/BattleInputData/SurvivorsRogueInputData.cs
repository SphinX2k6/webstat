using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Input.BattleInputData
{
	// Token: 0x02006FE5 RID: 28645
	[NullableContext(1)]
	[Nullable(0)]
	public class SurvivorsRogueInputData : BattleInputData
	{
		// Token: 0x0604549F RID: 283807 RVA: 0x01219104 File Offset: 0x01217304
		public SurvivorsRogueInputData()
		{
			Dictionary<string, EInputAction> dictionary = new Dictionary<string, EInputAction>();
			dictionary["技能1"] = EInputAction.技能1;
			dictionary["闪避"] = EInputAction.闪避;
			dictionary["走跑切换"] = EInputAction.走跑切换;
			this.ActionMap = dictionary;
			Dictionary<string, EInputAxis> dictionary2 = new Dictionary<string, EInputAxis>();
			dictionary2["MoveForward"] = EInputAxis.MoveForward;
			dictionary2["MoveRight"] = EInputAxis.MoveRight;
			this.AxisMap = dictionary2;
			this.AllowActionNameList = new string[]
			{
				"轮盘2",
				"幻象探索选择界面",
				"角色选择界面"
			};
			this.MatchInputDistributeTag = new string[]
			{
				"FightInputRoot.FightInput.ActionInput",
				"FightInputRoot.FightInput.AxisInput",
				"UiInputRoot.ShortcutKeyTag"
			};
			base..ctor(EInputDataType.SurvivorsRogue, EInputBindingType.Original);
		}

		// Token: 0x060454A0 RID: 283808 RVA: 0x012191C7 File Offset: 0x012173C7
		protected override Dictionary<string, EInputAction> OnGetActionMap()
		{
			return this.ActionMap;
		}

		// Token: 0x060454A1 RID: 283809 RVA: 0x012191CF File Offset: 0x012173CF
		protected override Dictionary<string, EInputAxis> OnGetAxisMap()
		{
			return this.AxisMap;
		}

		// Token: 0x060454A2 RID: 283810 RVA: 0x012191D8 File Offset: 0x012173D8
		protected override bool OnCheckActionInAllowFightActionNameList(string actionName, InputActionHandle inputActionHandle)
		{
			if (this.ActionMap.ContainsKey(actionName))
			{
				return true;
			}
			string inputDistributeTag = inputActionHandle.GetInputDistributeTag();
			return string.IsNullOrEmpty(inputDistributeTag) || !ModelBase<InputDistributeModel>.Instance.IsTagMatchInputDistributeTags(inputDistributeTag, this.MatchInputDistributeTag, true) || Array.IndexOf<string>(this.AllowActionNameList, actionName) >= 0;
		}

		// Token: 0x060454A3 RID: 283811 RVA: 0x0121922C File Offset: 0x0121742C
		protected override bool OnCheckAxisInAllowFightAxisNameList(string axisName, InputAxisHandle inputAxisHandle)
		{
			if (this.AxisMap.ContainsKey(axisName))
			{
				return true;
			}
			string inputDistributeTag = inputAxisHandle.GetInputDistributeTag();
			return string.IsNullOrEmpty(inputDistributeTag) || !ModelBase<InputDistributeModel>.Instance.IsTagMatchInputDistributeTags(inputDistributeTag, this.MatchInputDistributeTag, true);
		}

		// Token: 0x04026A93 RID: 158355
		private readonly Dictionary<string, EInputAction> ActionMap;

		// Token: 0x04026A94 RID: 158356
		private readonly Dictionary<string, EInputAxis> AxisMap;

		// Token: 0x04026A95 RID: 158357
		private readonly string[] AllowActionNameList;

		// Token: 0x04026A96 RID: 158358
		private readonly string[] MatchInputDistributeTag;
	}
}
