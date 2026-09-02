using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042EE RID: 17134
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/ECameraAnsEffectiveClientType.ECameraAnsEffectiveClientType")]
	public enum ECameraAnsEffectiveClientType : byte
	{
		// Token: 0x0401980E RID: 104462
		单客户端_角色为中心_,
		// Token: 0x0401980F RID: 104463
		全客户端_角色为中心_,
		// Token: 0x04019810 RID: 104464
		锁定目标客户端_怪物为中心_,
		// Token: 0x04019811 RID: 104465
		仇恨目标客户端_怪物为中心_,
		// Token: 0x04019812 RID: 104466
		技能目标客户端_怪物为中心_,
		// Token: 0x04019813 RID: 104467
		全客户端_怪物为中心_,
		// Token: 0x04019814 RID: 104468
		锁定目标客户端_角色为中心_,
		// Token: 0x04019815 RID: 104469
		单客户端_声骸为中心_,
		// Token: 0x04019816 RID: 104470
		全客户端_声骸为中心_,
		// Token: 0x04019817 RID: 104471
		单客户端_载具为中心_,
		// Token: 0x04019818 RID: 104472
		全客户端_载具为中心_,
		// Token: 0x04019819 RID: 104473
		单客户端_伴生物为中心_,
		// Token: 0x0401981A RID: 104474
		全客户端_伴生物为中心_,
		// Token: 0x0401981B RID: 104475
		仇恨目标客户端_角色为中心_,
		// Token: 0x0401981C RID: 104476
		ECameraAnsEffectiveClientType_MAX
	}
}
