using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Gameplay.Vision
{
	// Token: 0x02003E9A RID: 16026
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/Vision/EVisionMarkType.EVisionMarkType")]
	public enum EVisionMarkType : byte
	{
		// Token: 0x04014D84 RID: 85380
		机械麋鹿_普通矿石,
		// Token: 0x04014D85 RID: 85381
		机械麋鹿_日灵矿石,
		// Token: 0x04014D86 RID: 85382
		岩蛛,
		// Token: 0x04014D87 RID: 85383
		噼啪啪,
		// Token: 0x04014D88 RID: 85384
		猛犸象冲撞,
		// Token: 0x04014D89 RID: 85385
		猛犸象滑梯,
		// Token: 0x04014D8A RID: 85386
		猛犸象下砸,
		// Token: 0x04014D8B RID: 85387
		飞蛾,
		// Token: 0x04014D8C RID: 85388
		EVisionMarkType_MAX
	}
}
