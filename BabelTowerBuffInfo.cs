using System;

// Token: 0x020011EB RID: 4587
public class BabelTowerBuffInfo : IBabelTowerBuffInfo
{
	// Token: 0x17000A3F RID: 2623
	// (get) Token: 0x06007954 RID: 31060 RVA: 0x001FCDD2 File Offset: 0x001FAFD2
	// (set) Token: 0x06007955 RID: 31061 RVA: 0x001FCDDA File Offset: 0x001FAFDA
	public int Id { get; set; }

	// Token: 0x17000A40 RID: 2624
	// (get) Token: 0x06007956 RID: 31062 RVA: 0x001FCDE3 File Offset: 0x001FAFE3
	// (set) Token: 0x06007957 RID: 31063 RVA: 0x001FCDEB File Offset: 0x001FAFEB
	public EBabelTowerBuffState State { get; set; }

	// Token: 0x17000A41 RID: 2625
	// (get) Token: 0x06007958 RID: 31064 RVA: 0x001FCDF4 File Offset: 0x001FAFF4
	// (set) Token: 0x06007959 RID: 31065 RVA: 0x001FCDFC File Offset: 0x001FAFFC
	public int? LevelId { get; set; }

	// Token: 0x17000A42 RID: 2626
	// (get) Token: 0x0600795A RID: 31066 RVA: 0x001FCE05 File Offset: 0x001FB005
	// (set) Token: 0x0600795B RID: 31067 RVA: 0x001FCE0D File Offset: 0x001FB00D
	public bool IsRecommend { get; set; }
}
