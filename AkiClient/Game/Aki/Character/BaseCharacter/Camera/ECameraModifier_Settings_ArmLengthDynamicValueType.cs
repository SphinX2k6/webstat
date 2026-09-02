using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042F1 RID: 17137
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/ECameraModifier_Settings_ArmLengthDynamicValueType.ECameraModifier_Settings_ArmLengthDynamicValueType")]
	public enum ECameraModifier_Settings_ArmLengthDynamicValueType : byte
	{
		// Token: 0x04019828 RID: 104488
		None,
		// Token: 0x04019829 RID: 104489
		技能Id,
		// Token: 0x0401982A RID: 104490
		ECameraModifier_Settings_MAX
	}
}
