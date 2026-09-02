using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Quest.Enum
{
	// Token: 0x02003E33 RID: 15923
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Quest/Enum/EQuestStepState.EQuestStepState")]
	public enum EQuestStepState : byte
	{
		// Token: 0x0401486D RID: 84077
		未激活,
		// Token: 0x0401486E RID: 84078
		可接取,
		// Token: 0x0401486F RID: 84079
		进行中,
		// Token: 0x04014870 RID: 84080
		已完成,
		// Token: 0x04014871 RID: 84081
		已删除,
		// Token: 0x04014872 RID: 84082
		EQuestStepState_MAX
	}
}
