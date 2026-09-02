using System;
using System.Runtime.CompilerServices;

// Token: 0x0200218E RID: 8590
[NullableContext(1)]
[Nullable(0)]
public class FightPhotoTimeDilationLogEvent : PlayerCommonLogData
{
	// Token: 0x170013E6 RID: 5094
	// (get) Token: 0x060104A7 RID: 66727 RVA: 0x004766E7 File Offset: 0x004748E7
	// (set) Token: 0x060104A8 RID: 66728 RVA: 0x004766EF File Offset: 0x004748EF
	public override string event_id { get; set; } = "1804";

	// Token: 0x04007F6F RID: 32623
	public int inst_id;

	// Token: 0x04007F70 RID: 32624
	public int inst_diff;

	// Token: 0x04007F71 RID: 32625
	public string trace_id = "";
}
