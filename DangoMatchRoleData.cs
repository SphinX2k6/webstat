using System;

// Token: 0x02002708 RID: 9992
public class DangoMatchRoleData : IDangoMatchRoleData
{
	// Token: 0x1700193D RID: 6461
	// (get) Token: 0x06013B80 RID: 80768 RVA: 0x0057D4F8 File Offset: 0x0057B6F8
	// (set) Token: 0x06013B81 RID: 80769 RVA: 0x0057D500 File Offset: 0x0057B700
	public int GroupMatchId { get; set; }

	// Token: 0x1700193E RID: 6462
	// (get) Token: 0x06013B82 RID: 80770 RVA: 0x0057D509 File Offset: 0x0057B709
	// (set) Token: 0x06013B83 RID: 80771 RVA: 0x0057D511 File Offset: 0x0057B711
	public int DangoId { get; set; }

	// Token: 0x1700193F RID: 6463
	// (get) Token: 0x06013B84 RID: 80772 RVA: 0x0057D51A File Offset: 0x0057B71A
	// (set) Token: 0x06013B85 RID: 80773 RVA: 0x0057D522 File Offset: 0x0057B722
	public bool IsMatchFinished { get; set; }

	// Token: 0x17001940 RID: 6464
	// (get) Token: 0x06013B86 RID: 80774 RVA: 0x0057D52B File Offset: 0x0057B72B
	// (set) Token: 0x06013B87 RID: 80775 RVA: 0x0057D533 File Offset: 0x0057B733
	public bool IsPromote { get; set; }

	// Token: 0x17001941 RID: 6465
	// (get) Token: 0x06013B88 RID: 80776 RVA: 0x0057D53C File Offset: 0x0057B73C
	// (set) Token: 0x06013B89 RID: 80777 RVA: 0x0057D544 File Offset: 0x0057B744
	public bool IsBasicGroupMatch { get; set; }
}
