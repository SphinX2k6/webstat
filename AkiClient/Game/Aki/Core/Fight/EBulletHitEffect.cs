using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F5B RID: 16219
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EBulletHitEffect.EBulletHitEffect")]
	public enum EBulletHitEffect : byte
	{
		// Token: 0x04015571 RID: 87409
		时间销毁触发,
		// Token: 0x04015572 RID: 87410
		子弹打断销毁触发,
		// Token: 0x04015573 RID: 87411
		碰撞障碍物触发,
		// Token: 0x04015574 RID: 87412
		碰撞水体触发,
		// Token: 0x04015575 RID: 87413
		碰撞单位触发,
		// Token: 0x04015576 RID: 87414
		碰撞障碍物销毁触发,
		// Token: 0x04015577 RID: 87415
		碰撞单位销毁触发,
		// Token: 0x04015578 RID: 87416
		触发弱点打击特效,
		// Token: 0x04015579 RID: 87417
		次数不足时触发,
		// Token: 0x0401557A RID: 87418
		碰撞无敌单位触发,
		// Token: 0x0401557B RID: 87419
		触发极限闪避,
		// Token: 0x0401557C RID: 87420
		命中处插箭,
		// Token: 0x0401557D RID: 87421
		特殊命中特效,
		// Token: 0x0401557E RID: 87422
		EBulletHitEffect_MAX
	}
}
