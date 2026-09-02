using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Interaction.Enum
{
	// Token: 0x02003E8B RID: 16011
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Interaction/Enum/EinteractionIconType.EInteractionIconType")]
	public enum EInteractionIconType : byte
	{
		// Token: 0x04014CCE RID: 85198
		Dialogue,
		// Token: 0x04014CCF RID: 85199
		Shop,
		// Token: 0x04014CD0 RID: 85200
		Other,
		// Token: 0x04014CD1 RID: 85201
		EInteractionIconType_MAX
	}
}
