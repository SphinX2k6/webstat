using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F66 RID: 16230
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EMoveTrajectory.EMoveTrajectory")]
	public enum EMoveTrajectory : byte
	{
		// Token: 0x040155DC RID: 87516
		默认,
		// Token: 0x040155DD RID: 87517
		追踪子弹,
		// Token: 0x040155DE RID: 87518
		限时命中子弹,
		// Token: 0x040155DF RID: 87519
		围绕中心旋转,
		// Token: 0x040155E0 RID: 87520
		时间限制抛物线子弹,
		// Token: 0x040155E1 RID: 87521
		角度限制抛物线子弹,
		// Token: 0x040155E2 RID: 87522
		跟随目标,
		// Token: 0x040155E3 RID: 87523
		EMoveTrajectory_MAX
	}
}
