using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020021A0 RID: 8608
[NullableContext(1)]
[Nullable(0)]
public class MobileResCleanUpLogEvent : CommonLogData
{
	// Token: 0x170013F7 RID: 5111
	// (get) Token: 0x060104DB RID: 66779 RVA: 0x004769AB File Offset: 0x00474BAB
	// (set) Token: 0x060104DC RID: 66780 RVA: 0x004769B3 File Offset: 0x00474BB3
	public override string event_id { get; set; } = "1713";

	// Token: 0x04007FBC RID: 32700
	public int i_required_space;

	// Token: 0x04007FBD RID: 32701
	public List<MobileResCleanUpLogEventContentData> o_content = new List<MobileResCleanUpLogEventContentData>();

	// Token: 0x04007FBE RID: 32702
	public int i_type;

	// Token: 0x04007FBF RID: 32703
	public string s_trace_id = "";

	// Token: 0x04007FC0 RID: 32704
	public string unique_id = "";

	// Token: 0x04007FC1 RID: 32705
	public string player_id = "";
}
