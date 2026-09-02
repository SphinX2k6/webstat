using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Fight.Enum
{
	// Token: 0x02003EE1 RID: 16097
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Enum/BPEAttachmentRule.BPEAttachmentRule")]
	public enum BPEAttachmentRule : byte
	{
		// Token: 0x040150C8 RID: 86216
		KeepRelative,
		// Token: 0x040150C9 RID: 86217
		KeepWorld,
		// Token: 0x040150CA RID: 86218
		SnapToTarget,
		// Token: 0x040150CB RID: 86219
		BPEAttachmentRule_MAX
	}
}
