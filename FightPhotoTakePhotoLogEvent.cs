using System;
using System.Runtime.CompilerServices;

// Token: 0x0200218D RID: 8589
[NullableContext(1)]
[Nullable(0)]
public class FightPhotoTakePhotoLogEvent : PlayerCommonLogData
{
	// Token: 0x170013E5 RID: 5093
	// (get) Token: 0x060104A4 RID: 66724 RVA: 0x004766B8 File Offset: 0x004748B8
	// (set) Token: 0x060104A5 RID: 66725 RVA: 0x004766C0 File Offset: 0x004748C0
	public override string event_id { get; set; } = "1803";

	// Token: 0x04007F68 RID: 32616
	public int inst_id;

	// Token: 0x04007F69 RID: 32617
	public int inst_diff;

	// Token: 0x04007F6A RID: 32618
	public string trace_id = "";

	// Token: 0x04007F6B RID: 32619
	public int filter_id;

	// Token: 0x04007F6C RID: 32620
	public int photo_num;

	// Token: 0x04007F6D RID: 32621
	public int photo_status;
}
