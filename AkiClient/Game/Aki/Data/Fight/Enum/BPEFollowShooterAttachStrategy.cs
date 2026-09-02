using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Fight.Enum
{
	// Token: 0x02003EE4 RID: 16100
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Enum/BPEFollowShooterAttachStrategy.BPEFollowShooterAttachStrategy")]
	public enum BPEFollowShooterAttachStrategy : byte
	{
		// Token: 0x040150D6 RID: 86230
		DirectAttach,
		// Token: 0x040150D7 RID: 86231
		SocketTracking,
		// Token: 0x040150D8 RID: 86232
		BPEFollowShooterAttachStrategy_MAX
	}
}
