using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Fight.Enum
{
	// Token: 0x02003EE2 RID: 16098
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Enum/BPEDetachmentRule.BPEDetachmentRule")]
	public enum BPEDetachmentRule : byte
	{
		// Token: 0x040150CD RID: 86221
		KeepRelative,
		// Token: 0x040150CE RID: 86222
		KeepWorld,
		// Token: 0x040150CF RID: 86223
		BPEDetachmentRule_MAX
	}
}
