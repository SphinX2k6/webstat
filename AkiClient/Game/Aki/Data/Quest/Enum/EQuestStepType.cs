using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Quest.Enum
{
	// Token: 0x02003E34 RID: 15924
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Quest/Enum/EQuestStepType.EQuestStepType")]
	public enum EQuestStepType : byte
	{
		// Token: 0x04014874 RID: 84084
		Sequence,
		// Token: 0x04014875 RID: 84085
		战斗,
		// Token: 0x04014876 RID: 84086
		收集,
		// Token: 0x04014877 RID: 84087
		EQuestStepType_MAX
	}
}
