using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F60 RID: 16224
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EBulletTarget.EBulletTarget")]
	public enum EBulletTarget : byte
	{
		// Token: 0x04015593 RID: 87443
		空,
		// Token: 0x04015594 RID: 87444
		队伍角色,
		// Token: 0x04015595 RID: 87445
		技能目标,
		// Token: 0x04015596 RID: 87446
		攻击者锁定目标动态,
		// Token: 0x04015597 RID: 87447
		攻击者锁定目标静态,
		// Token: 0x04015598 RID: 87448
		自定义目标,
		// Token: 0x04015599 RID: 87449
		子弹发射者,
		// Token: 0x0401559A RID: 87450
		父子弹受击者,
		// Token: 0x0401559B RID: 87451
		父子弹目标,
		// Token: 0x0401559C RID: 87452
		前台角色锁定目标,
		// Token: 0x0401559D RID: 87453
		外部传入坐标,
		// Token: 0x0401559E RID: 87454
		技能目标前台,
		// Token: 0x0401559F RID: 87455
		EBulletTarget_MAX
	}
}
