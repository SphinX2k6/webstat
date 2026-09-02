using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.AnimNotifyInteraction.BP
{
	// Token: 0x02003D4D RID: 15693
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/AnimNotifyInteraction/BP/EEffectAction.EEffectAction")]
	public enum EEffectAction : byte
	{
		// Token: 0x04013BB5 RID: 80821
		GroundPound,
		// Token: 0x04013BB6 RID: 80822
		Shockwave,
		// Token: 0x04013BB7 RID: 80823
		Diagonal,
		// Token: 0x04013BB8 RID: 80824
		EEffectAction_MAX
	}
}
