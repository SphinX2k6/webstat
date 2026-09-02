using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x02006516 RID: 25878
	[NullableContext(1)]
	public interface IRhythmShipSettlementViewData
	{
		// Token: 0x17009E85 RID: 40581
		// (get) Token: 0x06040BB0 RID: 265136
		// (set) Token: 0x06040BB1 RID: 265137
		int SubLevelId { get; set; }

		// Token: 0x17009E86 RID: 40582
		// (get) Token: 0x06040BB2 RID: 265138
		// (set) Token: 0x06040BB3 RID: 265139
		RhythmSettleReasonPb Reason { get; set; }

		// Token: 0x17009E87 RID: 40583
		// (get) Token: 0x06040BB4 RID: 265140
		// (set) Token: 0x06040BB5 RID: 265141
		RhythmResultPayload Payload { get; set; }

		// Token: 0x17009E88 RID: 40584
		// (get) Token: 0x06040BB6 RID: 265142
		// (set) Token: 0x06040BB7 RID: 265143
		Dictionary<ERhythmShipSettlementType, int> SettlementItemMap { get; set; }
	}
}
