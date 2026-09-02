using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004309 RID: 17161
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/ELockOnCameraStates.ELockOnCameraStates")]
	public enum ELockOnCameraStates : byte
	{
		// Token: 0x040199C5 RID: 104901
		None,
		// Token: 0x040199C6 RID: 104902
		EnableRotation,
		// Token: 0x040199C7 RID: 104903
		DisableRotation,
		// Token: 0x040199C8 RID: 104904
		ELockOnCameraStates_MAX
	}
}
