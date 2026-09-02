using System;

// Token: 0x02002BB6 RID: 11190
public class TTodTimeSpan
{
	// Token: 0x17001D62 RID: 7522
	// (get) Token: 0x060164A5 RID: 91301 RVA: 0x0062C8C7 File Offset: 0x0062AAC7
	// (set) Token: 0x060164A6 RID: 91302 RVA: 0x0062C8CF File Offset: 0x0062AACF
	public int StartTime { get; set; }

	// Token: 0x17001D63 RID: 7523
	// (get) Token: 0x060164A7 RID: 91303 RVA: 0x0062C8D8 File Offset: 0x0062AAD8
	// (set) Token: 0x060164A8 RID: 91304 RVA: 0x0062C8E0 File Offset: 0x0062AAE0
	public int EndTime { get; set; }

	// Token: 0x060164A9 RID: 91305 RVA: 0x0062C8E9 File Offset: 0x0062AAE9
	public TTodTimeSpan(int startTime, int endTime)
	{
		this.StartTime = startTime;
		this.EndTime = endTime;
	}
}
