using System;

// Token: 0x02002B9F RID: 11167
public class SurvivorsHandbookViewOpenParams : ISurvivorsHandbookViewOpenParams
{
	// Token: 0x17001D3C RID: 7484
	// (get) Token: 0x060163DF RID: 91103 RVA: 0x006298F7 File Offset: 0x00627AF7
	// (set) Token: 0x060163E0 RID: 91104 RVA: 0x006298FF File Offset: 0x00627AFF
	public ESurvivorsRogueItemType SelectTabType { get; set; }

	// Token: 0x17001D3D RID: 7485
	// (get) Token: 0x060163E1 RID: 91105 RVA: 0x00629908 File Offset: 0x00627B08
	// (set) Token: 0x060163E2 RID: 91106 RVA: 0x00629910 File Offset: 0x00627B10
	public int? SelectCfgId { get; set; }
}
