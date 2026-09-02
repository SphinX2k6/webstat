using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Input.BattleInputData
{
	// Token: 0x02006FE2 RID: 28642
	[NullableContext(1)]
	[Nullable(0)]
	public class NormalWorldMotorInputData : BattleInputData
	{
		// Token: 0x06045490 RID: 283792 RVA: 0x01218C10 File Offset: 0x01216E10
		public NormalWorldMotorInputData()
		{
			Dictionary<string, EInputAction> dictionary = new Dictionary<string, EInputAction>();
			dictionary["载具漂移"] = EInputAction.跳跃;
			dictionary["载具氮气"] = EInputAction.闪避;
			dictionary["载具子弹跳"] = EInputAction.技能1;
			dictionary["载具子弹跳1"] = EInputAction.攻击;
			dictionary["载具退场技和下车"] = EInputAction.大招;
			dictionary["通用交互"] = EInputAction.通用交互;
			dictionary["载具探索工具"] = EInputAction.幻象1;
			dictionary["载具锁定目标"] = EInputAction.锁定目标;
			dictionary["载具视角切换"] = EInputAction.瞄准;
			dictionary["载具空中抬升"] = EInputAction.走跑切换;
			dictionary["载具辅助机攻击"] = EInputAction.攻击;
			this.ActionMap = dictionary;
			Dictionary<string, EInputAxis> dictionary2 = new Dictionary<string, EInputAxis>();
			dictionary2["LookUp"] = EInputAxis.LookUp;
			dictionary2["Turn"] = EInputAxis.Turn;
			dictionary2["MotorMoveForward"] = EInputAxis.MoveForward;
			dictionary2["MotorMoveRight"] = EInputAxis.MoveRight;
			dictionary2["MotorSoarMoveForward"] = EInputAxis.MoveForward;
			dictionary2["Zoom"] = EInputAxis.Zoom;
			dictionary2["WheelAxis"] = EInputAxis.WheelAxis;
			this.AxisMap = dictionary2;
			base..ctor(EInputDataType.NormalWorldMotor, EInputBindingType.Motor);
		}

		// Token: 0x06045491 RID: 283793 RVA: 0x01218D5B File Offset: 0x01216F5B
		protected override Dictionary<string, EInputAction> OnGetActionMap()
		{
			return this.ActionMap;
		}

		// Token: 0x06045492 RID: 283794 RVA: 0x01218D63 File Offset: 0x01216F63
		protected override Dictionary<string, EInputAxis> OnGetAxisMap()
		{
			return this.AxisMap;
		}

		// Token: 0x06045493 RID: 283795 RVA: 0x01218D6B File Offset: 0x01216F6B
		protected override bool OnCheckActionInAllowFightActionNameList(string actionName, InputActionHandle inputActionHandle)
		{
			if (actionName == "载具辅助机攻击")
			{
				SkillButtonUiMotorcycleGamepadData skillButtonUiMotorcycleGamepadData = ModelBase<SkillButtonUiModel>.Instance.GetGamepadDataByType(ESkillButtonGamepadDataType.Motorcycle) as SkillButtonUiMotorcycleGamepadData;
				return skillButtonUiMotorcycleGamepadData != null && skillButtonUiMotorcycleGamepadData.ShootEnable;
			}
			return base.OnCheckActionInAllowFightActionNameList(actionName, inputActionHandle);
		}

		// Token: 0x06045494 RID: 283796 RVA: 0x01218DA0 File Offset: 0x01216FA0
		protected override bool OnCheckAxisInAllowFightAxisNameList(string axisName, InputAxisHandle inputAxisHandle)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				if (axisName == "MotorMoveForward")
				{
					return !ModelBase<BattleUiModel>.Instance.MotorcycleData.IsMotorSoaring;
				}
				if (axisName == "MotorSoarMoveForward")
				{
					return ModelBase<BattleUiModel>.Instance.MotorcycleData.IsMotorSoaring;
				}
			}
			else if (axisName == "MotorSoarMoveForward")
			{
				return false;
			}
			return base.OnCheckAxisInAllowFightAxisNameList(axisName, inputAxisHandle);
		}

		// Token: 0x04026A8A RID: 158346
		private readonly Dictionary<string, EInputAction> ActionMap;

		// Token: 0x04026A8B RID: 158347
		private readonly Dictionary<string, EInputAxis> AxisMap;
	}
}
