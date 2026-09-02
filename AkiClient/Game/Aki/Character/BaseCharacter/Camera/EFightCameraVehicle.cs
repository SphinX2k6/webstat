using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004305 RID: 17157
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraVehicle.EFightCameraVehicle")]
	public enum EFightCameraVehicle : byte
	{
		// Token: 0x040199A6 RID: 104870
		None,
		// Token: 0x040199A7 RID: 104871
		相机目标以载具为中心,
		// Token: 0x040199A8 RID: 104872
		相机挂载到载具上,
		// Token: 0x040199A9 RID: 104873
		EFightCameraVehicle_MAX
	}
}
