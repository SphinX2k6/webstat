using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon
{
	// Token: 0x0200438B RID: 17291
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/EMonsterType.EMonsterType")]
	public enum EMonsterType : byte
	{
		// Token: 0x04019E56 RID: 106070
		地面单位,
		// Token: 0x04019E57 RID: 106071
		飞行单位,
		// Token: 0x04019E58 RID: 106072
		EMonsterType_MAX
	}
}
