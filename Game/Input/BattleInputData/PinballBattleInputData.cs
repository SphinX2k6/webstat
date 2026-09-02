using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Input.BattleInputData
{
	// Token: 0x02006FE3 RID: 28643
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballBattleInputData : BattleInputData
	{
		// Token: 0x06045495 RID: 283797 RVA: 0x01218E0D File Offset: 0x0121700D
		public PinballBattleInputData() : base(EInputDataType.PinballBattle, EInputBindingType.Original)
		{
		}

		// Token: 0x06045496 RID: 283798 RVA: 0x01218E49 File Offset: 0x01217049
		protected override Dictionary<string, EInputAction> OnGetActionMap()
		{
			return this.ActionMap;
		}

		// Token: 0x06045497 RID: 283799 RVA: 0x01218E51 File Offset: 0x01217051
		protected override Dictionary<string, EInputAxis> OnGetAxisMap()
		{
			return this.AxisMap;
		}

		// Token: 0x06045498 RID: 283800 RVA: 0x01218E5C File Offset: 0x0121705C
		protected override bool OnCheckActionInAllowFightActionNameList(string actionName, InputActionHandle inputActionHandle)
		{
			if (this.ActionMap.ContainsKey(actionName))
			{
				return true;
			}
			string inputDistributeTag = inputActionHandle.GetInputDistributeTag();
			return string.IsNullOrEmpty(inputDistributeTag) || !ModelBase<InputDistributeModel>.Instance.IsTagMatchInputDistributeTags(inputDistributeTag, this.MatchInputDistributeTag, true);
		}

		// Token: 0x06045499 RID: 283801 RVA: 0x01218EA0 File Offset: 0x012170A0
		protected override bool OnCheckAxisInAllowFightAxisNameList(string axisName, InputAxisHandle inputAxisHandle)
		{
			if (this.AxisMap.ContainsKey(axisName))
			{
				return true;
			}
			string inputDistributeTag = inputAxisHandle.GetInputDistributeTag();
			return string.IsNullOrEmpty(inputDistributeTag) || !ModelBase<InputDistributeModel>.Instance.IsTagMatchInputDistributeTags(inputDistributeTag, this.MatchInputDistributeTag, true);
		}

		// Token: 0x04026A8C RID: 158348
		private readonly Dictionary<string, EInputAction> ActionMap = new Dictionary<string, EInputAction>();

		// Token: 0x04026A8D RID: 158349
		private readonly Dictionary<string, EInputAxis> AxisMap = new Dictionary<string, EInputAxis>();

		// Token: 0x04026A8E RID: 158350
		private readonly string[] MatchInputDistributeTag = new string[]
		{
			"FightInputRoot.FightInput.ActionInput",
			"FightInputRoot.FightInput.AxisInput"
		};
	}
}
