using System;
using System.Runtime.CompilerServices;

// Token: 0x020021C7 RID: 8647
[NullableContext(1)]
[Nullable(0)]
public class SheriffQuestLogEvent : PlayerCommonLogData
{
	// Token: 0x1700141B RID: 5147
	// (get) Token: 0x0601054A RID: 66890 RVA: 0x00476FE5 File Offset: 0x004751E5
	// (set) Token: 0x0601054B RID: 66891 RVA: 0x00476FED File Offset: 0x004751ED
	public override string event_id { get; set; } = "1930";

	// Token: 0x04008088 RID: 32904
	public int i_area_id;

	// Token: 0x04008089 RID: 32905
	public int i_quest_id;

	// Token: 0x0400808A RID: 32906
	public int i_quest_status;
}
