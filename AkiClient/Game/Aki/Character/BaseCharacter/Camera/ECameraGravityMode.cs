using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042F0 RID: 17136
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/ECameraGravityMode.ECameraGravityMode")]
	public enum ECameraGravityMode : byte
	{
		// Token: 0x04019823 RID: 104483
		None,
		// Token: 0x04019824 RID: 104484
		FixedGravityDirect,
		// Token: 0x04019825 RID: 104485
		CameraTargetGravityDirect,
		// Token: 0x04019826 RID: 104486
		ECameraGravityMode_MAX
	}
}
