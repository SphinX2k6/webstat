using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scalability
{
	// Token: 0x02003D38 RID: 15672
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Scalability/EEffectScalabilityType.EEffectScalabilityType")]
	public enum EEffectScalabilityType : byte
	{
		// Token: 0x04013A8E RID: 80526
		None,
		// Token: 0x04013A8F RID: 80527
		Pad,
		// Token: 0x04013A90 RID: 80528
		Desktop,
		// Token: 0x04013A91 RID: 80529
		EEffectScalabilityType_MAX
	}
}
