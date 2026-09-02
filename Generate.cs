using System;

// Token: 0x02000F53 RID: 3923
public class Generate : IGenerate
{
	// Token: 0x17000758 RID: 1880
	// (get) Token: 0x0600628E RID: 25230 RVA: 0x00189ADF File Offset: 0x00187CDF
	// (set) Token: 0x0600628F RID: 25231 RVA: 0x00189AE7 File Offset: 0x00187CE7
	public int BornTrack { get; set; }

	// Token: 0x17000759 RID: 1881
	// (get) Token: 0x06006290 RID: 25232 RVA: 0x00189AF0 File Offset: 0x00187CF0
	// (set) Token: 0x06006291 RID: 25233 RVA: 0x00189AF8 File Offset: 0x00187CF8
	public float BornDistance { get; set; }

	// Token: 0x1700075A RID: 1882
	// (get) Token: 0x06006292 RID: 25234 RVA: 0x00189B01 File Offset: 0x00187D01
	// (set) Token: 0x06006293 RID: 25235 RVA: 0x00189B09 File Offset: 0x00187D09
	public EGenerateType GenerateType { get; set; }

	// Token: 0x1700075B RID: 1883
	// (get) Token: 0x06006294 RID: 25236 RVA: 0x00189B12 File Offset: 0x00187D12
	// (set) Token: 0x06006295 RID: 25237 RVA: 0x00189B1A File Offset: 0x00187D1A
	public int RefreshId { get; set; }

	// Token: 0x1700075C RID: 1884
	// (get) Token: 0x06006296 RID: 25238 RVA: 0x00189B23 File Offset: 0x00187D23
	// (set) Token: 0x06006297 RID: 25239 RVA: 0x00189B2B File Offset: 0x00187D2B
	public int BuffGateBornGroup { get; set; }
}
