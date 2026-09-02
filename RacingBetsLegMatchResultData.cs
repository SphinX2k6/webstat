using System;
using System.Runtime.CompilerServices;

// Token: 0x020026FD RID: 9981
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsLegMatchResultData : IRacingBetsLegMatchResultData
{
	// Token: 0x17001904 RID: 6404
	// (get) Token: 0x06013B09 RID: 80649 RVA: 0x0057D2D2 File Offset: 0x0057B4D2
	// (set) Token: 0x06013B0A RID: 80650 RVA: 0x0057D2DA File Offset: 0x0057B4DA
	public int DangoId { get; set; }

	// Token: 0x17001905 RID: 6405
	// (get) Token: 0x06013B0B RID: 80651 RVA: 0x0057D2E3 File Offset: 0x0057B4E3
	// (set) Token: 0x06013B0C RID: 80652 RVA: 0x0057D2EB File Offset: 0x0057B4EB
	public int Rank { get; set; }

	// Token: 0x17001906 RID: 6406
	// (get) Token: 0x06013B0D RID: 80653 RVA: 0x0057D2F4 File Offset: 0x0057B4F4
	// (set) Token: 0x06013B0E RID: 80654 RVA: 0x0057D2FC File Offset: 0x0057B4FC
	public bool HasAdvanced { get; set; }

	// Token: 0x17001907 RID: 6407
	// (get) Token: 0x06013B0F RID: 80655 RVA: 0x0057D305 File Offset: 0x0057B505
	// (set) Token: 0x06013B10 RID: 80656 RVA: 0x0057D30D File Offset: 0x0057B50D
	public ERacingBetsLegMatchType LegMatchType { get; set; }

	// Token: 0x17001908 RID: 6408
	// (get) Token: 0x06013B11 RID: 80657 RVA: 0x0057D316 File Offset: 0x0057B516
	// (set) Token: 0x06013B12 RID: 80658 RVA: 0x0057D31E File Offset: 0x0057B51E
	public bool IsChampion { get; set; }

	// Token: 0x17001909 RID: 6409
	// (get) Token: 0x06013B13 RID: 80659 RVA: 0x0057D327 File Offset: 0x0057B527
	// (set) Token: 0x06013B14 RID: 80660 RVA: 0x0057D32F File Offset: 0x0057B52F
	public ERacingBetsLegMatchResultType ResultShowType { get; set; }

	// Token: 0x1700190A RID: 6410
	// (get) Token: 0x06013B15 RID: 80661 RVA: 0x0057D338 File Offset: 0x0057B538
	// (set) Token: 0x06013B16 RID: 80662 RVA: 0x0057D340 File Offset: 0x0057B540
	public string AdvancedNextMatchName { get; set; }

	// Token: 0x1700190B RID: 6411
	// (get) Token: 0x06013B17 RID: 80663 RVA: 0x0057D349 File Offset: 0x0057B549
	// (set) Token: 0x06013B18 RID: 80664 RVA: 0x0057D351 File Offset: 0x0057B551
	public string LoserNextMatchName { get; set; }
}
