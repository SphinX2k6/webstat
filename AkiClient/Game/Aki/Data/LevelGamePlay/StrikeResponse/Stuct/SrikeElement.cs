using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.LevelGamePlay.StrikeResponse.Stuct
{
	// Token: 0x02003E82 RID: 16002
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/LevelGamePlay/StrikeResponse/Stuct/SrikeElement.SrikeElement")]
	public enum SrikeElement : byte
	{
		// Token: 0x04014C7F RID: 85119
		AD,
		// Token: 0x04014C80 RID: 85120
		Ice,
		// Token: 0x04014C81 RID: 85121
		Fire,
		// Token: 0x04014C82 RID: 85122
		Thunder,
		// Token: 0x04014C83 RID: 85123
		Wind,
		// Token: 0x04014C84 RID: 85124
		Light,
		// Token: 0x04014C85 RID: 85125
		Dark,
		// Token: 0x04014C86 RID: 85126
		AddBlood,
		// Token: 0x04014C87 RID: 85127
		Immune,
		// Token: 0x04014C88 RID: 85128
		SrikeElement_MAX
	}
}
