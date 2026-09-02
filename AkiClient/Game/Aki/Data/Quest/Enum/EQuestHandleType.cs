using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Quest.Enum
{
	// Token: 0x02003E31 RID: 15921
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Quest/Enum/EQuestHandleType.EQuestHandleType")]
	public enum EQuestHandleType : byte
	{
		// Token: 0x04014864 RID: 84068
		TriggerQuestStep,
		// Token: 0x04014865 RID: 84069
		FinishQuestStep,
		// Token: 0x04014866 RID: 84070
		EQuestHandleType_MAX
	}
}
