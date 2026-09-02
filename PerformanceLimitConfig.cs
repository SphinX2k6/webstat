using System;

// Token: 0x02000E86 RID: 3718
public class PerformanceLimitConfig : IPerformanceLimitConfig
{
	// Token: 0x17000680 RID: 1664
	// (get) Token: 0x06005ACA RID: 23242 RVA: 0x00164753 File Offset: 0x00162953
	// (set) Token: 0x06005ACB RID: 23243 RVA: 0x0016475B File Offset: 0x0016295B
	public bool FrameLimit { get; set; }

	// Token: 0x17000681 RID: 1665
	// (get) Token: 0x06005ACC RID: 23244 RVA: 0x00164764 File Offset: 0x00162964
	// (set) Token: 0x06005ACD RID: 23245 RVA: 0x0016476C File Offset: 0x0016296C
	public bool CacheWorldFrame { get; set; }
}
