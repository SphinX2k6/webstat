using System;
using CSharpScript.Game.Module.BattleUi;

namespace CSharpScript.Game.Input.InputDataTypeCreator
{
	// Token: 0x02006FD7 RID: 28631
	public class NormalWorldInputDataTypeCreator : InputDataTypeCreator
	{
		// Token: 0x0604546B RID: 283755 RVA: 0x01218672 File Offset: 0x01216872
		public override EInputDataType GetInputDataType()
		{
			BattleUiMotorcycleData motorcycleData = ModelBase<BattleUiModel>.Instance.MotorcycleData;
			if (motorcycleData != null && motorcycleData.LastDriving)
			{
				return EInputDataType.NormalWorldMotor;
			}
			return EInputDataType.NormalWorld;
		}
	}
}
