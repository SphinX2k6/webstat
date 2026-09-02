using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Interaction.Enum
{
	// Token: 0x02003E8D RID: 16013
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Interaction/Enum/EInteractOptionLimit.EInteractOptionLimit")]
	public enum EInteractOptionLimit : byte
	{
		// Token: 0x04014CD7 RID: 85207
		None,
		// Token: 0x04014CD8 RID: 85208
		Multiple,
		// Token: 0x04014CD9 RID: 85209
		DurationMultiple,
		// Token: 0x04014CDA RID: 85210
		EInteractOptionLimit_MAX
	}
}
