using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Interaction.Enum
{
	// Token: 0x02003E8C RID: 16012
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Interaction/Enum/EInteractionType.EInteractionType")]
	public enum EInteractionType : byte
	{
		// Token: 0x04014CD3 RID: 85203
		剧情交互,
		// Token: 0x04014CD4 RID: 85204
		直接交互,
		// Token: 0x04014CD5 RID: 85205
		EInteractionType_MAX
	}
}
