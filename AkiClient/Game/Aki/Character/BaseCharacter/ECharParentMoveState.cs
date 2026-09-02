using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041ED RID: 16877
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECharParentMoveState.ECharParentMoveState")]
	public enum ECharParentMoveState : byte
	{
		// Token: 0x0401905E RID: 102494
		地面状态,
		// Token: 0x0401905F RID: 102495
		攀爬状态,
		// Token: 0x04019060 RID: 102496
		空中状态,
		// Token: 0x04019061 RID: 102497
		水中状态,
		// Token: 0x04019062 RID: 102498
		滑雪状态,
		// Token: 0x04019063 RID: 102499
		载具状态,
		// Token: 0x04019064 RID: 102500
		ECharParentMoveState_MAX
	}
}
