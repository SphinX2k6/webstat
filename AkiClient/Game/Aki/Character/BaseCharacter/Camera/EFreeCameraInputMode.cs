using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004307 RID: 17159
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFreeCameraInputMode.EFreeCameraInputMode")]
	public enum EFreeCameraInputMode : byte
	{
		// Token: 0x040199B2 RID: 104882
		禁止,
		// Token: 0x040199B3 RID: 104883
		拖动,
		// Token: 0x040199B4 RID: 104884
		EFreeCameraInputMode_MAX
	}
}
