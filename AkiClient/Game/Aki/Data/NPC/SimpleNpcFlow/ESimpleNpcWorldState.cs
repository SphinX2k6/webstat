using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.NPC.SimpleNpcFlow
{
	// Token: 0x02003E5C RID: 15964
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/NPC/SimpleNpcFlow/ESimpleNpcWorldState.ESimpleNpcWorldState")]
	public enum ESimpleNpcWorldState : byte
	{
		// Token: 0x04014A31 RID: 84529
		DefaultState,
		// Token: 0x04014A32 RID: 84530
		FirstState,
		// Token: 0x04014A33 RID: 84531
		State,
		// Token: 0x04014A34 RID: 84532
		ESimpleNpcWorldState_MAX
	}
}
