using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002137 RID: 8503
[NullableContext(1)]
[Nullable(0)]
public class ExploreToolEquipLogData : PlayerCommonLogData
{
	// Token: 0x17001391 RID: 5009
	// (get) Token: 0x060103A6 RID: 66470 RVA: 0x00475878 File Offset: 0x00473A78
	// (set) Token: 0x060103A7 RID: 66471 RVA: 0x00475880 File Offset: 0x00473A80
	public override string event_id { get; set; } = "1018";

	// Token: 0x04007E01 RID: 32257
	public int i_explore_tool_id;

	// Token: 0x04007E02 RID: 32258
	public List<List<int>> o_authorization = new List<List<int>>();

	// Token: 0x04007E03 RID: 32259
	public List<ExploreToolAuthorizationLogData> o_new_authorization = new List<ExploreToolAuthorizationLogData>();

	// Token: 0x04007E04 RID: 32260
	public int i_item_id;

	// Token: 0x04007E05 RID: 32261
	public int i_operation;

	// Token: 0x04007E06 RID: 32262
	public int i_roulette_id;
}
