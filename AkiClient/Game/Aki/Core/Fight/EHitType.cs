using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F64 RID: 16228
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EHitType.EHitType")]
	public enum EHitType : byte
	{
		// Token: 0x040155C4 RID: 87492
		对自己,
		// Token: 0x040155C5 RID: 87493
		对友方,
		// Token: 0x040155C6 RID: 87494
		对敌方,
		// Token: 0x040155C7 RID: 87495
		对队伍,
		// Token: 0x040155C8 RID: 87496
		对小队,
		// Token: 0x040155C9 RID: 87497
		EHitType_MAX
	}
}
