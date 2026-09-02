using System;
using System.Runtime.CompilerServices;

// Token: 0x020021BE RID: 8638
[NullableContext(1)]
[Nullable(0)]
public class PhantomDiscardPlanShareReport : PlayerCommonLogData
{
	// Token: 0x17001412 RID: 5138
	// (get) Token: 0x0601052F RID: 66863 RVA: 0x00476E5F File Offset: 0x0047505F
	// (set) Token: 0x06010530 RID: 66864 RVA: 0x00476E67 File Offset: 0x00475067
	public override string event_id { get; set; } = "1847";

	// Token: 0x04008057 RID: 32855
	public int i_type;

	// Token: 0x04008058 RID: 32856
	public string s_my_code = "";

	// Token: 0x04008059 RID: 32857
	public string s_others_code = "";
}
