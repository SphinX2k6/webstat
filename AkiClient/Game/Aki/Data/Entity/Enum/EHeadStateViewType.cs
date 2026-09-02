using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Entity.Enum
{
	// Token: 0x02003EFC RID: 16124
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Entity/Enum/EHeadStateViewType.EHeadStateViewType")]
	public enum EHeadStateViewType : byte
	{
		// Token: 0x040151C9 RID: 86473
		None,
		// Token: 0x040151CA RID: 86474
		Common,
		// Token: 0x040151CB RID: 86475
		Elite,
		// Token: 0x040151CC RID: 86476
		NPC,
		// Token: 0x040151CD RID: 86477
		MingSuTi,
		// Token: 0x040151CE RID: 86478
		Guardian,
		// Token: 0x040151CF RID: 86479
		Durability,
		// Token: 0x040151D0 RID: 86480
		DurabilityDamageBreakable,
		// Token: 0x040151D1 RID: 86481
		DurabilityDamageUnbreakable,
		// Token: 0x040151D2 RID: 86482
		EHeadStateViewType_MAX
	}
}
