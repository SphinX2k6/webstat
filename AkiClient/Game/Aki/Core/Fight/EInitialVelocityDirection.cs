using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F65 RID: 16229
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EInitialVelocityDirection.EInitialVelocityDirection")]
	public enum EInitialVelocityDirection : byte
	{
		// Token: 0x040155CB RID: 87499
		默认,
		// Token: 0x040155CC RID: 87500
		面向目标,
		// Token: 0x040155CD RID: 87501
		面向发射者,
		// Token: 0x040155CE RID: 87502
		父子弹方向,
		// Token: 0x040155CF RID: 87503
		跟随骨骼默认朝向,
		// Token: 0x040155D0 RID: 87504
		面向发射者锁定目标,
		// Token: 0x040155D1 RID: 87505
		面向自定义目标,
		// Token: 0x040155D2 RID: 87506
		队伍角色,
		// Token: 0x040155D3 RID: 87507
		父子弹受击者,
		// Token: 0x040155D4 RID: 87508
		父子弹目标,
		// Token: 0x040155D5 RID: 87509
		前台角色锁定目标,
		// Token: 0x040155D6 RID: 87510
		伴生物,
		// Token: 0x040155D7 RID: 87511
		伴生物朝向,
		// Token: 0x040155D8 RID: 87512
		世界旋转,
		// Token: 0x040155D9 RID: 87513
		跟随技能目标旋转,
		// Token: 0x040155DA RID: 87514
		EInitialVelocityDirection_MAX
	}
}
