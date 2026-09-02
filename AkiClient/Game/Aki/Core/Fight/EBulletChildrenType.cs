using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F56 RID: 16214
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EBulletChildrenType.EBulletChildrenType")]
	public enum EBulletChildrenType : byte
	{
		// Token: 0x04015554 RID: 87380
		无特殊触发,
		// Token: 0x04015555 RID: 87381
		碰撞单位时触发,
		// Token: 0x04015556 RID: 87382
		碰撞障碍物时触发,
		// Token: 0x04015557 RID: 87383
		次数不足时销毁触发,
		// Token: 0x04015558 RID: 87384
		时间销毁时触发,
		// Token: 0x04015559 RID: 87385
		受击对象进入子弹范围触发,
		// Token: 0x0401555A RID: 87386
		EBulletChildrenType_MAX
	}
}
