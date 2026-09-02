using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.TypeScript.Game.NewWorld.Character.SimpleNpc.Blueprint
{
	// Token: 0x020039BD RID: 14781
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/EHolographicState.EHolographicState")]
	public enum EHolographicState : byte
	{
		// Token: 0x0400EA24 RID: 59940
		Start,
		// Token: 0x0400EA25 RID: 59941
		Loop,
		// Token: 0x0400EA26 RID: 59942
		End,
		// Token: 0x0400EA27 RID: 59943
		Over,
		// Token: 0x0400EA28 RID: 59944
		EHolographicState_MAX
	}
}
