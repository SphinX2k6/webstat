using System;
using System.Runtime.CompilerServices;

// Token: 0x020021C2 RID: 8642
[NullableContext(1)]
[Nullable(0)]
public class TetrisGameFinishLogEvent : PlayerCommonLogData
{
	// Token: 0x17001416 RID: 5142
	// (get) Token: 0x0601053B RID: 66875 RVA: 0x00476F1B File Offset: 0x0047511B
	// (set) Token: 0x0601053C RID: 66876 RVA: 0x00476F23 File Offset: 0x00475123
	public override string event_id { get; set; } = "1853";

	// Token: 0x0400806E RID: 32878
	public int i_config_id;

	// Token: 0x0400806F RID: 32879
	public int i_result_type;

	// Token: 0x04008070 RID: 32880
	public int i_score;
}
