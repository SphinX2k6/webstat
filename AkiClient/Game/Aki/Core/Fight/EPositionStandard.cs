using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F67 RID: 16231
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EPositionStandard.EPositionStandard")]
	public enum EPositionStandard : byte
	{
		// Token: 0x040155E5 RID: 87525
		发射者位置,
		// Token: 0x040155E6 RID: 87526
		技能目标位置,
		// Token: 0x040155E7 RID: 87527
		世界位置,
		// Token: 0x040155E8 RID: 87528
		父子弹或外部位置,
		// Token: 0x040155E9 RID: 87529
		攻击者锁定目标位置,
		// Token: 0x040155EA RID: 87530
		自定义目标,
		// Token: 0x040155EB RID: 87531
		队伍角色,
		// Token: 0x040155EC RID: 87532
		父子弹受击者,
		// Token: 0x040155ED RID: 87533
		父子弹目标,
		// Token: 0x040155EE RID: 87534
		前台角色锁定目标,
		// Token: 0x040155EF RID: 87535
		伴生物,
		// Token: 0x040155F0 RID: 87536
		伴生物位置和朝向,
		// Token: 0x040155F1 RID: 87537
		技能目标位置和朝向,
		// Token: 0x040155F2 RID: 87538
		EPositionStandard_MAX
	}
}
