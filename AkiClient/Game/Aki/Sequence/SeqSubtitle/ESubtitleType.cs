using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Sequence.SeqSubtitle
{
	// Token: 0x0200439F RID: 17311
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Sequence/SeqSubtitle/ESubtitleType.ESubtitleType")]
	public enum ESubtitleType : byte
	{
		// Token: 0x04019FB0 RID: 106416
		Normal,
		// Token: 0x04019FB1 RID: 106417
		Dialog,
		// Token: 0x04019FB2 RID: 106418
		Option,
		// Token: 0x04019FB3 RID: 106419
		Reply,
		// Token: 0x04019FB4 RID: 106420
		ESubtitleType_MAX
	}
}
