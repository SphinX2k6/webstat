using System;
using System.Runtime.CompilerServices;

// Token: 0x020021D8 RID: 8664
[NullableContext(1)]
[Nullable(0)]
public class ActivityFinishSinkLogData : PlayerCommonLogData
{
	// Token: 0x17001429 RID: 5161
	// (get) Token: 0x06010577 RID: 66935 RVA: 0x00477275 File Offset: 0x00475475
	// (set) Token: 0x06010578 RID: 66936 RVA: 0x0047727D File Offset: 0x0047547D
	public override string event_id { get; set; } = "1937";

	// Token: 0x040080D1 RID: 32977
	public int i_activity_id;
}
