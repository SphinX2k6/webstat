using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.GameplayABP
{
	// Token: 0x020042E4 RID: 17124
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/GameplayABP/EGameplayABPType.EGameplayABPType")]
	public enum EGameplayABPType : byte
	{
		// Token: 0x040197A5 RID: 104357
		None,
		// Token: 0x040197A6 RID: 104358
		Motor,
		// Token: 0x040197A7 RID: 104359
		Poker,
		// Token: 0x040197A8 RID: 104360
		ThunderBird,
		// Token: 0x040197A9 RID: 104361
		SlopeSlide,
		// Token: 0x040197AA RID: 104362
		SwordRiding,
		// Token: 0x040197AB RID: 104363
		AssistedWalk,
		// Token: 0x040197AC RID: 104364
		RideHorse,
		// Token: 0x040197AD RID: 104365
		EGameplayABPType_MAX
	}
}
