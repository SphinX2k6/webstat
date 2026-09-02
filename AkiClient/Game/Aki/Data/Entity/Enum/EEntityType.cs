using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Entity.Enum
{
	// Token: 0x02003EFB RID: 16123
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Entity/Enum/EEntityType.EEntityType")]
	public enum EEntityType : byte
	{
		// Token: 0x040151BA RID: 86458
		Player,
		// Token: 0x040151BB RID: 86459
		Npc,
		// Token: 0x040151BC RID: 86460
		Monster,
		// Token: 0x040151BD RID: 86461
		Spawner,
		// Token: 0x040151BE RID: 86462
		Building,
		// Token: 0x040151BF RID: 86463
		Gather,
		// Token: 0x040151C0 RID: 86464
		Treasure,
		// Token: 0x040151C1 RID: 86465
		Vision,
		// Token: 0x040151C2 RID: 86466
		Animal,
		// Token: 0x040151C3 RID: 86467
		ClientOnly,
		// Token: 0x040151C4 RID: 86468
		Vehicle,
		// Token: 0x040151C5 RID: 86469
		PlayerEntity,
		// Token: 0x040151C6 RID: 86470
		SceneEntity,
		// Token: 0x040151C7 RID: 86471
		EEntityType_MAX
	}
}
