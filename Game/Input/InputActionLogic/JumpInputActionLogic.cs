using System;

namespace CSharpScript.Game.Input.InputActionLogic
{
	// Token: 0x02006FDF RID: 28639
	public class JumpInputActionLogic : InputActionLogicBase
	{
		// Token: 0x0604547D RID: 283773 RVA: 0x01218743 File Offset: 0x01216943
		public override bool IsAllowReleaseInput(EInputDataType inputDataType)
		{
			return inputDataType != EInputDataType.NormalWorldMotor;
		}
	}
}
