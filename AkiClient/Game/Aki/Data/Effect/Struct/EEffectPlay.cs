using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Effect.Struct
{
	// Token: 0x02003EFF RID: 16127
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Effect/Struct/EEffectPlay.EEffectPlay")]
	public enum EEffectPlay : byte
	{
		// Token: 0x040151DE RID: 86494
		Default,
		// Token: 0x040151DF RID: 86495
		Play,
		// Token: 0x040151E0 RID: 86496
		DoNotPlay,
		// Token: 0x040151E1 RID: 86497
		EEffectPlay_MAX
	}
}
