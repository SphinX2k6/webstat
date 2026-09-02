using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.UiCameraAnimation.Enum
{
	// Token: 0x02003E01 RID: 15873
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/UiCameraAnimation/Enum/EUiCameraAnimationRotationType.EUiCameraAnimationRotationType")]
	public enum EUiCameraAnimationRotationType : byte
	{
		// Token: 0x040146AB RID: 83627
		WorldRotation,
		// Token: 0x040146AC RID: 83628
		CurrentCameraRotation,
		// Token: 0x040146AD RID: 83629
		TargetRotation,
		// Token: 0x040146AE RID: 83630
		TargetForwardRotation,
		// Token: 0x040146AF RID: 83631
		EUiCameraAnimationRotationType_MAX
	}
}
