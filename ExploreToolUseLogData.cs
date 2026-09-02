using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002134 RID: 8500
[NullableContext(1)]
[Nullable(0)]
public class ExploreToolUseLogData : PlayerCommonLogData
{
	// Token: 0x1700138F RID: 5007
	// (get) Token: 0x0601039F RID: 66463 RVA: 0x004757EE File Offset: 0x004739EE
	// (set) Token: 0x060103A0 RID: 66464 RVA: 0x004757F6 File Offset: 0x004739F6
	public override string event_id { get; set; } = "1026";

	// Token: 0x04007DF8 RID: 32248
	public string i_tool_id = "";

	// Token: 0x04007DF9 RID: 32249
	public List<IUnitLogData> o_report = new List<IUnitLogData>();
}
