using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Quest.Enum
{
	// Token: 0x02003E35 RID: 15925
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Quest/Enum/EQuestType.EQuestType")]
	public enum EQuestType : byte
	{
		// Token: 0x04014879 RID: 84089
		主线任务,
		// Token: 0x0401487A RID: 84090
		支线任务,
		// Token: 0x0401487B RID: 84091
		EQuestType_MAX
	}
}
