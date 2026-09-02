using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon
{
	// Token: 0x0200438A RID: 17290
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/EMonsterAttackType.EMonsterAttackType")]
	public enum EMonsterAttackType : byte
	{
		// Token: 0x04019E51 RID: 106065
		近远都行,
		// Token: 0x04019E52 RID: 106066
		近战攻击,
		// Token: 0x04019E53 RID: 106067
		远程攻击,
		// Token: 0x04019E54 RID: 106068
		EMonsterAttackType_MAX
	}
}
