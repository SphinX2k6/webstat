using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002136 RID: 8502
[NullableContext(1)]
[Nullable(0)]
public class ExploreToolSwitchLogData : PlayerCommonLogData
{
	// Token: 0x17001390 RID: 5008
	// (get) Token: 0x060103A3 RID: 66467 RVA: 0x0047583E File Offset: 0x00473A3E
	// (set) Token: 0x060103A4 RID: 66468 RVA: 0x00475846 File Offset: 0x00473A46
	public override string event_id { get; set; } = "1011";

	// Token: 0x04007DFD RID: 32253
	public int i_explore_tool_id;

	// Token: 0x04007DFE RID: 32254
	public List<List<int>> o_authorization = new List<List<int>>();

	// Token: 0x04007DFF RID: 32255
	public List<ExploreToolAuthorizationLogData> o_new_authorization = new List<ExploreToolAuthorizationLogData>();
}
