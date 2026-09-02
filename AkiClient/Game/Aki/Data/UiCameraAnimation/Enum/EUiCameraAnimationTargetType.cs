using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.UiCameraAnimation.Enum
{
	// Token: 0x02003E02 RID: 15874
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/UiCameraAnimation/Enum/EUiCameraAnimationTargetType.EUiCameraAnimationTargetType")]
	public enum EUiCameraAnimationTargetType : byte
	{
		// Token: 0x040146B1 RID: 83633
		None,
		// Token: 0x040146B2 RID: 83634
		Player,
		// Token: 0x040146B3 RID: 83635
		Npc,
		// Token: 0x040146B4 RID: 83636
		UiSceneRole,
		// Token: 0x040146B5 RID: 83637
		UiSceneSkeletal,
		// Token: 0x040146B6 RID: 83638
		UiVisionHandBook,
		// Token: 0x040146B7 RID: 83639
		UiGlider,
		// Token: 0x040146B8 RID: 83640
		SailDock,
		// Token: 0x040146B9 RID: 83641
		UiSceneHulu,
		// Token: 0x040146BA RID: 83642
		UiInfrastructure,
		// Token: 0x040146BB RID: 83643
		UiSceneActor,
		// Token: 0x040146BC RID: 83644
		UiSceneFormationRole,
		// Token: 0x040146BD RID: 83645
		EUiCameraAnimationTargetType_MAX
	}
}
