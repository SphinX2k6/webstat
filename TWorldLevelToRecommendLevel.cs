using System;

// Token: 0x02002006 RID: 8198
public class TWorldLevelToRecommendLevel
{
	// Token: 0x17001285 RID: 4741
	// (get) Token: 0x0600F7B7 RID: 63415 RVA: 0x0043D7AB File Offset: 0x0043B9AB
	// (set) Token: 0x0600F7B8 RID: 63416 RVA: 0x0043D7B3 File Offset: 0x0043B9B3
	public int Item1 { get; set; }

	// Token: 0x17001286 RID: 4742
	// (get) Token: 0x0600F7B9 RID: 63417 RVA: 0x0043D7BC File Offset: 0x0043B9BC
	// (set) Token: 0x0600F7BA RID: 63418 RVA: 0x0043D7C4 File Offset: 0x0043B9C4
	public int Item2 { get; set; }

	// Token: 0x0600F7BB RID: 63419 RVA: 0x0043D7CD File Offset: 0x0043B9CD
	public TWorldLevelToRecommendLevel(int item1, int item2)
	{
		this.Item1 = item1;
		this.Item2 = item2;
	}
}
