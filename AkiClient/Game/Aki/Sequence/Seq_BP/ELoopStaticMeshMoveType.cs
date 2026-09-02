using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Sequence.Seq_BP
{
	// Token: 0x02004399 RID: 17305
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Sequence/Seq_BP/ELoopStaticMeshMoveType.ELoopStaticMeshMoveType")]
	public enum ELoopStaticMeshMoveType : byte
	{
		// Token: 0x04019F07 RID: 106247
		None,
		// Token: 0x04019F08 RID: 106248
		MoveLoop,
		// Token: 0x04019F09 RID: 106249
		MoveAtMoment,
		// Token: 0x04019F0A RID: 106250
		MoveForever,
		// Token: 0x04019F0B RID: 106251
		ELoopStaticMeshMoveType_MAX
	}
}
