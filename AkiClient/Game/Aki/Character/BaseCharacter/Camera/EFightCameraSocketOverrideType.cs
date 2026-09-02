using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004301 RID: 17153
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraSocketOverrideType.EFightCameraSocketOverrideType")]
	public enum EFightCameraSocketOverrideType : byte
	{
		// Token: 0x04019993 RID: 104851
		骨骼有效才覆盖,
		// Token: 0x04019994 RID: 104852
		骨骼无条件覆盖,
		// Token: 0x04019995 RID: 104853
		EFightCameraSocketOverrideType_MAX
	}
}
