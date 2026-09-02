using System;
using System.Runtime.CompilerServices;

// Token: 0x02002164 RID: 8548
[NullableContext(1)]
[Nullable(0)]
public class PreDownloadDownloadNoSpaceBeforeStartRecord : PlayerCommonLogData
{
	// Token: 0x170013BC RID: 5052
	// (get) Token: 0x06010429 RID: 66601 RVA: 0x00475F29 File Offset: 0x00474129
	// (set) Token: 0x0601042A RID: 66602 RVA: 0x00475F31 File Offset: 0x00474131
	public override string event_id { get; set; } = "1708";

	// Token: 0x0601042B RID: 66603 RVA: 0x00475F3A File Offset: 0x0047413A
	public PreDownloadDownloadNoSpaceBeforeStartRecord(long space)
	{
		this.i_required_space = (int)space;
	}

	// Token: 0x04007EB0 RID: 32432
	public int i_required_space;
}
