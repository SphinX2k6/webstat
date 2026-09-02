using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.UiCameraAnimation.Enum
{
	// Token: 0x02003E00 RID: 15872
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/UiCameraAnimation/Enum/EUiCameraAnimationLocationType.EUiCameraAnimationLocationType")]
	public enum EUiCameraAnimationLocationType : byte
	{
		// Token: 0x040146A6 RID: 83622
		WorldLocation,
		// Token: 0x040146A7 RID: 83623
		TargetLocation,
		// Token: 0x040146A8 RID: 83624
		SocketLocation,
		// Token: 0x040146A9 RID: 83625
		EUiCameraAnimationLocationType_MAX
	}
}
