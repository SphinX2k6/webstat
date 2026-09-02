using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Sequence.Manager
{
	// Token: 0x020043AA RID: 17322
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/ESeqSwtichType.ESeqSwtichType")]
	public enum ESeqSwtichType : byte
	{
		// Token: 0x0401A0B8 RID: 106680
		Auto,
		// Token: 0x0401A0B9 RID: 106681
		Condition,
		// Token: 0x0401A0BA RID: 106682
		Manual,
		// Token: 0x0401A0BB RID: 106683
		ESeqSwtichType_MAX
	}
}
