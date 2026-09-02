using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Statistics
{
	// Token: 0x02003D28 RID: 15656
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Statistics/EEffectStatisticsSortType.EEffectStatisticsSortType")]
	public enum EEffectStatisticsSortType : byte
	{
		// Token: 0x0401393B RID: 80187
		ExistTime,
		// Token: 0x0401393C RID: 80188
		Distance,
		// Token: 0x0401393D RID: 80189
		TickCount,
		// Token: 0x0401393E RID: 80190
		EEffectStatisticsSortType_MAX
	}
}
