using System;
using System.Runtime.CompilerServices;

// Token: 0x02002187 RID: 8583
[NullableContext(1)]
[Nullable(0)]
public class UiInteractRouletteLogEvent : PlayerCommonLogData
{
	// Token: 0x170013DF RID: 5087
	// (get) Token: 0x06010492 RID: 66706 RVA: 0x004765E0 File Offset: 0x004747E0
	// (set) Token: 0x06010493 RID: 66707 RVA: 0x004765E8 File Offset: 0x004747E8
	public override string event_id { get; set; } = "1808";

	// Token: 0x04007F51 RID: 32593
	public int i_old_count;

	// Token: 0x04007F52 RID: 32594
	public int i_new_count;

	// Token: 0x04007F53 RID: 32595
	public int i_inst_id;

	// Token: 0x04007F54 RID: 32596
	public double i_cost_time;

	// Token: 0x04007F55 RID: 32597
	public long i_skill_id;
}
