using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Enum
{
	// Token: 0x02003D42 RID: 15682
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Enum/EAnimNotifyEffectLocationType.EAnimNotifyEffectLocationType")]
	public enum EAnimNotifyEffectLocationType : byte
	{
		// Token: 0x04013B43 RID: 80707
		Normal,
		// Token: 0x04013B44 RID: 80708
		FloorPassBy,
		// Token: 0x04013B45 RID: 80709
		Raytrace,
		// Token: 0x04013B46 RID: 80710
		EAnimNotifyEffectLocationType_MAX
	}
}
