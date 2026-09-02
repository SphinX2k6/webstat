using System;

// Token: 0x02002203 RID: 8707
public class LordGymDifficultySelectViewParam : ILordGymDifficultySelectViewParam
{
	// Token: 0x17001450 RID: 5200
	// (get) Token: 0x060106E8 RID: 67304 RVA: 0x0047D491 File Offset: 0x0047B691
	// (set) Token: 0x060106E9 RID: 67305 RVA: 0x0047D499 File Offset: 0x0047B699
	public int LordEntranceSetId { get; set; }

	// Token: 0x17001451 RID: 5201
	// (get) Token: 0x060106EA RID: 67306 RVA: 0x0047D4A2 File Offset: 0x0047B6A2
	// (set) Token: 0x060106EB RID: 67307 RVA: 0x0047D4AA File Offset: 0x0047B6AA
	public int LordEntranceId { get; set; }

	// Token: 0x17001452 RID: 5202
	// (get) Token: 0x060106EC RID: 67308 RVA: 0x0047D4B3 File Offset: 0x0047B6B3
	// (set) Token: 0x060106ED RID: 67309 RVA: 0x0047D4BB File Offset: 0x0047B6BB
	public bool IsPlaySpecialSequence { get; set; }

	// Token: 0x17001453 RID: 5203
	// (get) Token: 0x060106EE RID: 67310 RVA: 0x0047D4C4 File Offset: 0x0047B6C4
	// (set) Token: 0x060106EF RID: 67311 RVA: 0x0047D4CC File Offset: 0x0047B6CC
	public int DefaultLordId { get; set; }
}
