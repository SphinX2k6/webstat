using System;
using System.Runtime.CompilerServices;

// Token: 0x020021AF RID: 8623
[NullableContext(1)]
[Nullable(0)]
public class FurnitureDesignLogEvent : PlayerCommonLogData
{
	// Token: 0x17001406 RID: 5126
	// (get) Token: 0x06010508 RID: 66824 RVA: 0x00476C6B File Offset: 0x00474E6B
	// (set) Token: 0x06010509 RID: 66825 RVA: 0x00476C73 File Offset: 0x00474E73
	public override string event_id { get; set; } = "1835";

	// Token: 0x04008015 RID: 32789
	public int i_area_id;

	// Token: 0x04008016 RID: 32790
	public int i_slot_id;

	// Token: 0x04008017 RID: 32791
	public int i_sub_slot_index;

	// Token: 0x04008018 RID: 32792
	public int i_new_furniture_id;

	// Token: 0x04008019 RID: 32793
	public int i_old_furniture_id;

	// Token: 0x0400801A RID: 32794
	public int i_type;

	// Token: 0x0400801B RID: 32795
	public int i_if_finish;

	// Token: 0x0400801C RID: 32796
	public string s_trace_id = "";
}
