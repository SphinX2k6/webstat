using System;
using System.Runtime.CompilerServices;

// Token: 0x020021A1 RID: 8609
[NullableContext(1)]
[Nullable(0)]
public class MobileResCleanUpFinishLogEvent : CommonLogData
{
	// Token: 0x170013F8 RID: 5112
	// (get) Token: 0x060104DE RID: 66782 RVA: 0x004769FB File Offset: 0x00474BFB
	// (set) Token: 0x060104DF RID: 66783 RVA: 0x00476A03 File Offset: 0x00474C03
	public override string event_id { get; set; } = "1714";

	// Token: 0x04007FC3 RID: 32707
	public string s_trace_id = "";

	// Token: 0x04007FC4 RID: 32708
	public string unique_id = "";

	// Token: 0x04007FC5 RID: 32709
	public string player_id = "";
}
