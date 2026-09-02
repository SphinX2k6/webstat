using System;
using System.Runtime.CompilerServices;

// Token: 0x020016DE RID: 5854
[NullableContext(1)]
[Nullable(0)]
internal class WheelTowerRecordPopupScoreItemData
{
	// Token: 0x17000D8A RID: 3466
	// (get) Token: 0x0600A27C RID: 41596 RVA: 0x002ADC3C File Offset: 0x002ABE3C
	// (set) Token: 0x0600A27D RID: 41597 RVA: 0x002ADC44 File Offset: 0x002ABE44
	public string Title { get; set; } = string.Empty;

	// Token: 0x17000D8B RID: 3467
	// (get) Token: 0x0600A27E RID: 41598 RVA: 0x002ADC4D File Offset: 0x002ABE4D
	// (set) Token: 0x0600A27F RID: 41599 RVA: 0x002ADC55 File Offset: 0x002ABE55
	public int ScoreOld { get; set; }

	// Token: 0x17000D8C RID: 3468
	// (get) Token: 0x0600A280 RID: 41600 RVA: 0x002ADC5E File Offset: 0x002ABE5E
	// (set) Token: 0x0600A281 RID: 41601 RVA: 0x002ADC66 File Offset: 0x002ABE66
	public int ScoreNew { get; set; }

	// Token: 0x17000D8D RID: 3469
	// (get) Token: 0x0600A282 RID: 41602 RVA: 0x002ADC6F File Offset: 0x002ABE6F
	// (set) Token: 0x0600A283 RID: 41603 RVA: 0x002ADC77 File Offset: 0x002ABE77
	public bool NeedScoreIcon { get; set; }
}
