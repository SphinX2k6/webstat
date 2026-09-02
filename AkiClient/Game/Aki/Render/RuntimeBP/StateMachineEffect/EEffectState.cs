using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.StateMachineEffect
{
	// Token: 0x02003A47 RID: 14919
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/StateMachineEffect/EEffectState.EEffectState")]
	public enum EEffectState : byte
	{
		// Token: 0x0400F46F RID: 62575
		State1,
		// Token: 0x0400F470 RID: 62576
		State2,
		// Token: 0x0400F471 RID: 62577
		State3,
		// Token: 0x0400F472 RID: 62578
		State4,
		// Token: 0x0400F473 RID: 62579
		State5,
		// Token: 0x0400F474 RID: 62580
		EEffectState_MAX
	}
}
