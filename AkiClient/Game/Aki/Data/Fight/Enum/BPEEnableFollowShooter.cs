using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Fight.Enum
{
	// Token: 0x02003EE3 RID: 16099
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Enum/BPEEnableFollowShooter.BPEEnableFollowShooter")]
	public enum BPEEnableFollowShooter : byte
	{
		// Token: 0x040150D1 RID: 86225
		AutoDetectedFreezeWater,
		// Token: 0x040150D2 RID: 86226
		GameAbility,
		// Token: 0x040150D3 RID: 86227
		AutoDetectedGamePartitionObject,
		// Token: 0x040150D4 RID: 86228
		BPEEnableFollowShooter_MAX
	}
}
