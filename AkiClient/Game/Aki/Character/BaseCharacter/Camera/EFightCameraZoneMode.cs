using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004306 RID: 17158
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraZoneMode.EFightCameraZoneMode")]
	public enum EFightCameraZoneMode : byte
	{
		// Token: 0x040199AB RID: 104875
		None,
		// Token: 0x040199AC RID: 104876
		Soar,
		// Token: 0x040199AD RID: 104877
		Vehicle,
		// Token: 0x040199AE RID: 104878
		Motor,
		// Token: 0x040199AF RID: 104879
		Horizontal,
		// Token: 0x040199B0 RID: 104880
		EFightCameraZoneMode_MAX
	}
}
