using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon
{
	// Token: 0x0200438E RID: 17294
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/EWalkingPosture.EWalkingPosture")]
	public enum EWalkingPosture : byte
	{
		// Token: 0x04019E6C RID: 106092
		走,
		// Token: 0x04019E6D RID: 106093
		跑,
		// Token: 0x04019E6E RID: 106094
		EWalkingPosture_MAX
	}
}
