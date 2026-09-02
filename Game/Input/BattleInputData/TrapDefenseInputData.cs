using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Input.BattleInputData
{
	// Token: 0x02006FE6 RID: 28646
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseInputData : BattleInputData
	{
		// Token: 0x060454A4 RID: 283812 RVA: 0x01219270 File Offset: 0x01217470
		public TrapDefenseInputData()
		{
			Dictionary<string, EInputAction> dictionary = new Dictionary<string, EInputAction>();
			dictionary["塔防跳跃"] = EInputAction.跳跃;
			dictionary["塔防走跑切换"] = EInputAction.走跑切换;
			dictionary["塔防射击"] = EInputAction.攻击;
			dictionary["塔防冲刺"] = EInputAction.闪避;
			dictionary["塔防道具"] = EInputAction.幻象1;
			this.ActionMap = dictionary;
			Dictionary<string, EInputAxis> dictionary2 = new Dictionary<string, EInputAxis>();
			dictionary2["LookUp"] = EInputAxis.LookUp;
			dictionary2["Turn"] = EInputAxis.Turn;
			dictionary2["TrapDefenseMoveForward"] = EInputAxis.MoveForward;
			dictionary2["TrapDefenseMoveRight"] = EInputAxis.MoveRight;
			dictionary2["TrapDefenseZoom"] = EInputAxis.Zoom;
			dictionary2["WheelAxis"] = EInputAxis.WheelAxis;
			this.AxisMap = dictionary2;
			this.AllowActionNameList = new string[]
			{
				"塔防轮盘",
				"塔防道具",
				"塔防旋转",
				"塔防回收机关"
			};
			this.MatchInputDistributeTag = new string[]
			{
				"FightInputRoot.FightInput.ActionInput",
				"FightInputRoot.FightInput.AxisInput",
				"UiInputRoot.ShortcutKeyTag"
			};
			base..ctor(EInputDataType.TrapDefense, EInputBindingType.Original);
		}

		// Token: 0x060454A5 RID: 283813 RVA: 0x0121939B File Offset: 0x0121759B
		protected override Dictionary<string, EInputAction> OnGetActionMap()
		{
			return this.ActionMap;
		}

		// Token: 0x060454A6 RID: 283814 RVA: 0x012193A3 File Offset: 0x012175A3
		protected override Dictionary<string, EInputAxis> OnGetAxisMap()
		{
			return this.AxisMap;
		}

		// Token: 0x060454A7 RID: 283815 RVA: 0x012193AC File Offset: 0x012175AC
		protected override bool OnCheckActionInAllowFightActionNameList(string actionName, InputActionHandle inputActionHandle)
		{
			if (this.ActionMap.ContainsKey(actionName))
			{
				return true;
			}
			string inputDistributeTag = inputActionHandle.GetInputDistributeTag();
			return string.IsNullOrEmpty(inputDistributeTag) || !ModelBase<InputDistributeModel>.Instance.IsTagMatchInputDistributeTags(inputDistributeTag, this.MatchInputDistributeTag, true) || Array.IndexOf<string>(this.AllowActionNameList, actionName) >= 0;
		}

		// Token: 0x060454A8 RID: 283816 RVA: 0x01219400 File Offset: 0x01217600
		protected override bool OnCheckAxisInAllowFightAxisNameList(string axisName, InputAxisHandle inputAxisHandle)
		{
			if (this.AxisMap.ContainsKey(axisName))
			{
				return true;
			}
			string inputDistributeTag = inputAxisHandle.GetInputDistributeTag();
			return string.IsNullOrEmpty(inputDistributeTag) || !ModelBase<InputDistributeModel>.Instance.IsTagMatchInputDistributeTags(inputDistributeTag, this.MatchInputDistributeTag, true);
		}

		// Token: 0x04026A97 RID: 158359
		private readonly Dictionary<string, EInputAction> ActionMap;

		// Token: 0x04026A98 RID: 158360
		private readonly Dictionary<string, EInputAxis> AxisMap;

		// Token: 0x04026A99 RID: 158361
		private readonly string[] AllowActionNameList;

		// Token: 0x04026A9A RID: 158362
		private readonly string[] MatchInputDistributeTag;
	}
}
