using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Sequence.Manager
{
	// Token: 0x020043A9 RID: 17321
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/EPlotState.EPlotState")]
	public enum EPlotState : byte
	{
		// Token: 0x0401A0B4 RID: 106676
		Start,
		// Token: 0x0401A0B5 RID: 106677
		End,
		// Token: 0x0401A0B6 RID: 106678
		EPlotState_MAX
	}
}
