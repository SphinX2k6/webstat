using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;

// Token: 0x02000E2B RID: 3627
public class ResetFinalArmLengthToDynamicValueData
{
	// Token: 0x060055B0 RID: 21936 RVA: 0x000E1A33 File Offset: 0x000DFC33
	[NullableContext(1)]
	public ResetFinalArmLengthToDynamicValueData(SCameraModifier_Settings_ArmLengthDynamicValue data)
	{
	}

	// Token: 0x04001B1C RID: 6940
	public ECameraModifier_Settings_ArmLengthDynamicValueType ArmLengthDynamicValueType = data.ArmLengthDynamicValueType;

	// Token: 0x04001B1D RID: 6941
	public int SkillId = data.SkillId;

	// Token: 0x04001B1E RID: 6942
	public float ArmLength = (float)data.ArmLength;
}
