using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F5D RID: 16221
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EBulletObject.EBulletObject")]
	public enum EBulletObject : byte
	{
		// Token: 0x04015584 RID: 87428
		空,
		// Token: 0x04015585 RID: 87429
		攻击者,
		// Token: 0x04015586 RID: 87430
		受击者,
		// Token: 0x04015587 RID: 87431
		执行GB的子弹,
		// Token: 0x04015588 RID: 87432
		EBulletObject_MAX
	}
}
