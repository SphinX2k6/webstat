using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004218 RID: 16920
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ERotationMode.ERotationMode")]
	public enum ERotationMode : byte
	{
		// Token: 0x04019194 RID: 102804
		VelocityDirection,
		// Token: 0x04019195 RID: 102805
		LookingDirection,
		// Token: 0x04019196 RID: 102806
		Aiming,
		// Token: 0x04019197 RID: 102807
		ERotationMode_MAX
	}
}
