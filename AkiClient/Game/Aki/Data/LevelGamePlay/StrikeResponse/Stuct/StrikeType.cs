using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.LevelGamePlay.StrikeResponse.Stuct
{
	// Token: 0x02003E84 RID: 16004
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/LevelGamePlay/StrikeResponse/Stuct/StrikeType.StrikeType")]
	public enum StrikeType : byte
	{
		// Token: 0x04014C90 RID: 85136
		GeneralAttack,
		// Token: 0x04014C91 RID: 85137
		StorageAttack,
		// Token: 0x04014C92 RID: 85138
		ULT,
		// Token: 0x04014C93 RID: 85139
		QTE,
		// Token: 0x04014C94 RID: 85140
		StrikeType_MAX
	}
}
