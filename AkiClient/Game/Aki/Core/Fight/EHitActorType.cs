using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F63 RID: 16227
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EHitActorType.EHitActorType")]
	public enum EHitActorType : byte
	{
		// Token: 0x040155BD RID: 87485
		全部,
		// Token: 0x040155BE RID: 87486
		Character,
		// Token: 0x040155BF RID: 87487
		子弹,
		// Token: 0x040155C0 RID: 87488
		场景物件,
		// Token: 0x040155C1 RID: 87489
		障碍物,
		// Token: 0x040155C2 RID: 87490
		EHitActorType_MAX
	}
}
