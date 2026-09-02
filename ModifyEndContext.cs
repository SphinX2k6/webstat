using System;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;

// Token: 0x02000E2C RID: 3628
public class ModifyEndContext
{
	// Token: 0x060055B1 RID: 21937 RVA: 0x000E1A65 File Offset: 0x000DFC65
	public void Clear()
	{
		this.SkillId = 0;
	}

	// Token: 0x04001B1F RID: 6943
	public ECameraModifier_Settings_ArmLengthDynamicValueType ArmLengthDynamicValueType;

	// Token: 0x04001B20 RID: 6944
	public int SkillId;
}
