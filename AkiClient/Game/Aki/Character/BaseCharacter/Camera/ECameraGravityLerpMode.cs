using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042EF RID: 17135
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/ECameraGravityLerpMode.ECameraGravityLerpMode")]
	public enum ECameraGravityLerpMode : byte
	{
		// Token: 0x0401981E RID: 104478
		None,
		// Token: 0x0401981F RID: 104479
		Time,
		// Token: 0x04019820 RID: 104480
		AngleVelocity,
		// Token: 0x04019821 RID: 104481
		ECameraGravityLerpMode_MAX
	}
}
