using System;

// Token: 0x0200172C RID: 5932
public class ActivityLogReportInfo
{
	// Token: 0x17000DBF RID: 3519
	// (get) Token: 0x0600A539 RID: 42297 RVA: 0x002BA0AD File Offset: 0x002B82AD
	// (set) Token: 0x0600A53A RID: 42298 RVA: 0x002BA0B5 File Offset: 0x002B82B5
	public int Id { get; set; }

	// Token: 0x17000DC0 RID: 3520
	// (get) Token: 0x0600A53B RID: 42299 RVA: 0x002BA0BE File Offset: 0x002B82BE
	// (set) Token: 0x0600A53C RID: 42300 RVA: 0x002BA0C6 File Offset: 0x002B82C6
	public int Type { get; set; }

	// Token: 0x0600A53D RID: 42301 RVA: 0x002BA0CF File Offset: 0x002B82CF
	public ActivityLogReportInfo(int id, int type)
	{
		this.Id = id;
		this.Type = type;
	}
}
