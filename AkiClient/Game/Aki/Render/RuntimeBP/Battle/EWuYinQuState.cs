using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Battle
{
	// Token: 0x02003D9F RID: 15775
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Battle/EWuYinQuState.EWuYinQuState")]
	public enum EWuYinQuState : byte
	{
		// Token: 0x04014153 RID: 82259
		StateIdle,
		// Token: 0x04014154 RID: 82260
		StateFighting1,
		// Token: 0x04014155 RID: 82261
		StateFighting2,
		// Token: 0x04014156 RID: 82262
		StateFighting3,
		// Token: 0x04014157 RID: 82263
		Nothing,
		// Token: 0x04014158 RID: 82264
		EWuYinQuState_MAX
	}
}
