using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x02006517 RID: 25879
	[NullableContext(1)]
	[Nullable(0)]
	public class RhythmShipSettlementViewData : IRhythmShipSettlementViewData
	{
		// Token: 0x17009E89 RID: 40585
		// (get) Token: 0x06040BB8 RID: 265144 RVA: 0x01099426 File Offset: 0x01097626
		// (set) Token: 0x06040BB9 RID: 265145 RVA: 0x0109942E File Offset: 0x0109762E
		public int SubLevelId { get; set; }

		// Token: 0x17009E8A RID: 40586
		// (get) Token: 0x06040BBA RID: 265146 RVA: 0x01099437 File Offset: 0x01097637
		// (set) Token: 0x06040BBB RID: 265147 RVA: 0x0109943F File Offset: 0x0109763F
		public RhythmSettleReasonPb Reason { get; set; }

		// Token: 0x17009E8B RID: 40587
		// (get) Token: 0x06040BBC RID: 265148 RVA: 0x01099448 File Offset: 0x01097648
		// (set) Token: 0x06040BBD RID: 265149 RVA: 0x01099450 File Offset: 0x01097650
		public RhythmResultPayload Payload { get; set; }

		// Token: 0x17009E8C RID: 40588
		// (get) Token: 0x06040BBE RID: 265150 RVA: 0x01099459 File Offset: 0x01097659
		// (set) Token: 0x06040BBF RID: 265151 RVA: 0x01099461 File Offset: 0x01097661
		public Dictionary<ERhythmShipSettlementType, int> SettlementItemMap { get; set; }
	}
}
