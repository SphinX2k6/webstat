using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Quest.Enum
{
	// Token: 0x02003E32 RID: 15922
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Quest/Enum/EQuestStepOrder.EQuestStepOrder")]
	public enum EQuestStepOrder : byte
	{
		// Token: 0x04014868 RID: 84072
		起始步骤,
		// Token: 0x04014869 RID: 84073
		过程步骤,
		// Token: 0x0401486A RID: 84074
		结束步骤,
		// Token: 0x0401486B RID: 84075
		EQuestStepOrder_MAX
	}
}
