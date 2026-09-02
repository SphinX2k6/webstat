using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.UiCameraAnimation.Enum
{
	// Token: 0x02003DFF RID: 15871
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/UiCameraAnimation/Enum/EUiCameraAnimationAttributeType.EUiCameraAnimationAttributeType")]
	public enum EUiCameraAnimationAttributeType : byte
	{
		// Token: 0x0401469A RID: 83610
		None,
		// Token: 0x0401469B RID: 83611
		Location,
		// Token: 0x0401469C RID: 83612
		Rotation,
		// Token: 0x0401469D RID: 83613
		ArmLength,
		// Token: 0x0401469E RID: 83614
		ArmOffsetLocation,
		// Token: 0x0401469F RID: 83615
		ArmOffsetRotation,
		// Token: 0x040146A0 RID: 83616
		CameraFieldOfView,
		// Token: 0x040146A1 RID: 83617
		FocalDistance,
		// Token: 0x040146A2 RID: 83618
		PostProcessBlendWeight,
		// Token: 0x040146A3 RID: 83619
		Aperture,
		// Token: 0x040146A4 RID: 83620
		EUiCameraAnimationAttributeType_MAX
	}
}
