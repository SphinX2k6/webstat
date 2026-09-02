using System;

// Token: 0x02002B01 RID: 11009
public class SurvivorsAttributeUiData : ISurvivorsAttributeUiData
{
	// Token: 0x17001CB2 RID: 7346
	// (get) Token: 0x06016021 RID: 90145 RVA: 0x0061B43A File Offset: 0x0061963A
	// (set) Token: 0x06016022 RID: 90146 RVA: 0x0061B442 File Offset: 0x00619642
	public int AttrId { get; set; }

	// Token: 0x17001CB3 RID: 7347
	// (get) Token: 0x06016023 RID: 90147 RVA: 0x0061B44B File Offset: 0x0061964B
	// (set) Token: 0x06016024 RID: 90148 RVA: 0x0061B453 File Offset: 0x00619653
	public double Value { get; set; }

	// Token: 0x17001CB4 RID: 7348
	// (get) Token: 0x06016025 RID: 90149 RVA: 0x0061B45C File Offset: 0x0061965C
	// (set) Token: 0x06016026 RID: 90150 RVA: 0x0061B464 File Offset: 0x00619664
	public bool IsRecommend { get; set; }

	// Token: 0x17001CB5 RID: 7349
	// (get) Token: 0x06016027 RID: 90151 RVA: 0x0061B46D File Offset: 0x0061966D
	// (set) Token: 0x06016028 RID: 90152 RVA: 0x0061B475 File Offset: 0x00619675
	public bool? IsAddition { get; set; }
}
