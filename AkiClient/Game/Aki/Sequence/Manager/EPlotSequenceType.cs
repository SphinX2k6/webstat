using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Sequence.Manager
{
	// Token: 0x020043A8 RID: 17320
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/EPlotSequenceType.EPlotSequenceType")]
	public enum EPlotSequenceType : byte
	{
		// Token: 0x0401A0AF RID: 106671
		过场,
		// Token: 0x0401A0B0 RID: 106672
		站桩,
		// Token: 0x0401A0B1 RID: 106673
		其他,
		// Token: 0x0401A0B2 RID: 106674
		EPlotSequenceType_MAX
	}
}
