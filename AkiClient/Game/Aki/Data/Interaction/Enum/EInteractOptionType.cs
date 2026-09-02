using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Interaction.Enum
{
	// Token: 0x02003E8E RID: 16014
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Interaction/Enum/EInteractOptionType.EInteractOptionType")]
	public enum EInteractOptionType : byte
	{
		// Token: 0x04014CDC RID: 85212
		任务,
		// Token: 0x04014CDD RID: 85213
		剧情,
		// Token: 0x04014CDE RID: 85214
		事件,
		// Token: 0x04014CDF RID: 85215
		EInteractOptionType_MAX
	}
}
