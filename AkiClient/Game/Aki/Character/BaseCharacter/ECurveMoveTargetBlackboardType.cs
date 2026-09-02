using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041F3 RID: 16883
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECurveMoveTargetBlackboardType.ECurveMoveTargetBlackboardType")]
	public enum ECurveMoveTargetBlackboardType : byte
	{
		// Token: 0x0401909C RID: 102556
		Entity,
		// Token: 0x0401909D RID: 102557
		EntityId,
		// Token: 0x0401909E RID: 102558
		CreatureDataId,
		// Token: 0x0401909F RID: 102559
		LocationVector,
		// Token: 0x040190A0 RID: 102560
		ECurveMoveTargetBlackboardType_MAX
	}
}
