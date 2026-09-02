using System;

// Token: 0x02001384 RID: 4996
public class MapTravelLevelData : IMapTravelLevelData
{
	// Token: 0x17000B9B RID: 2971
	// (get) Token: 0x06008948 RID: 35144 RVA: 0x00242D77 File Offset: 0x00240F77
	// (set) Token: 0x06008949 RID: 35145 RVA: 0x00242D7F File Offset: 0x00240F7F
	public int Id { get; set; }

	// Token: 0x17000B9C RID: 2972
	// (get) Token: 0x0600894A RID: 35146 RVA: 0x00242D88 File Offset: 0x00240F88
	// (set) Token: 0x0600894B RID: 35147 RVA: 0x00242D90 File Offset: 0x00240F90
	public int Level { get; set; }

	// Token: 0x17000B9D RID: 2973
	// (get) Token: 0x0600894C RID: 35148 RVA: 0x00242D99 File Offset: 0x00240F99
	// (set) Token: 0x0600894D RID: 35149 RVA: 0x00242DA1 File Offset: 0x00240FA1
	public int AccumulateExp { get; set; }

	// Token: 0x17000B9E RID: 2974
	// (get) Token: 0x0600894E RID: 35150 RVA: 0x00242DAA File Offset: 0x00240FAA
	// (set) Token: 0x0600894F RID: 35151 RVA: 0x00242DB2 File Offset: 0x00240FB2
	public int TargetExp { get; set; }
}
