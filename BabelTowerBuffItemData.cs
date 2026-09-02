using System;

// Token: 0x020011F3 RID: 4595
public class BabelTowerBuffItemData : IBabelTowerBuffItemData
{
	// Token: 0x17000A65 RID: 2661
	// (get) Token: 0x060079A4 RID: 31140 RVA: 0x001FCF13 File Offset: 0x001FB113
	// (set) Token: 0x060079A5 RID: 31141 RVA: 0x001FCF1B File Offset: 0x001FB11B
	public int Id { get; set; }

	// Token: 0x17000A66 RID: 2662
	// (get) Token: 0x060079A6 RID: 31142 RVA: 0x001FCF24 File Offset: 0x001FB124
	// (set) Token: 0x060079A7 RID: 31143 RVA: 0x001FCF2C File Offset: 0x001FB12C
	public bool IsDeTerm { get; set; }

	// Token: 0x17000A67 RID: 2663
	// (get) Token: 0x060079A8 RID: 31144 RVA: 0x001FCF35 File Offset: 0x001FB135
	// (set) Token: 0x060079A9 RID: 31145 RVA: 0x001FCF3D File Offset: 0x001FB13D
	public bool CanClick { get; set; }

	// Token: 0x17000A68 RID: 2664
	// (get) Token: 0x060079AA RID: 31146 RVA: 0x001FCF46 File Offset: 0x001FB146
	// (set) Token: 0x060079AB RID: 31147 RVA: 0x001FCF4E File Offset: 0x001FB14E
	public bool? ShowStar { get; set; }

	// Token: 0x17000A69 RID: 2665
	// (get) Token: 0x060079AC RID: 31148 RVA: 0x001FCF57 File Offset: 0x001FB157
	// (set) Token: 0x060079AD RID: 31149 RVA: 0x001FCF5F File Offset: 0x001FB15F
	public bool? IsNecessary { get; set; }

	// Token: 0x17000A6A RID: 2666
	// (get) Token: 0x060079AE RID: 31150 RVA: 0x001FCF68 File Offset: 0x001FB168
	// (set) Token: 0x060079AF RID: 31151 RVA: 0x001FCF70 File Offset: 0x001FB170
	public bool? IsLock { get; set; }

	// Token: 0x17000A6B RID: 2667
	// (get) Token: 0x060079B0 RID: 31152 RVA: 0x001FCF79 File Offset: 0x001FB179
	// (set) Token: 0x060079B1 RID: 31153 RVA: 0x001FCF81 File Offset: 0x001FB181
	public bool? IsSelect { get; set; }

	// Token: 0x17000A6C RID: 2668
	// (get) Token: 0x060079B2 RID: 31154 RVA: 0x001FCF8A File Offset: 0x001FB18A
	// (set) Token: 0x060079B3 RID: 31155 RVA: 0x001FCF92 File Offset: 0x001FB192
	public int? GroupId { get; set; }
}
