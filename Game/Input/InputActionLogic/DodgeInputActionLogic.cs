using System;

namespace CSharpScript.Game.Input.InputActionLogic
{
	// Token: 0x02006FDC RID: 28636
	public class DodgeInputActionLogic : InputActionLogicBase
	{
		// Token: 0x06045475 RID: 283765 RVA: 0x012186C3 File Offset: 0x012168C3
		public override bool IsAllowReleaseInput(EInputDataType inputDataType)
		{
			return inputDataType != EInputDataType.NormalWorldMotor;
		}
	}
}
