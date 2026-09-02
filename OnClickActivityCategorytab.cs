using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020021A7 RID: 8615
[NullableContext(1)]
[Nullable(0)]
public class OnClickActivityCategorytab : PlayerCommonLogData
{
	// Token: 0x170013FE RID: 5118
	// (get) Token: 0x060104F0 RID: 66800 RVA: 0x00476AF4 File Offset: 0x00474CF4
	// (set) Token: 0x060104F1 RID: 66801 RVA: 0x00476AFC File Offset: 0x00474CFC
	public override string event_id { get; set; } = "1818";

	// Token: 0x04007FDF RID: 32735
	public int i_type;

	// Token: 0x04007FE0 RID: 32736
	public List<ActivityLogReportInfo> o_content = new List<ActivityLogReportInfo>();
}
