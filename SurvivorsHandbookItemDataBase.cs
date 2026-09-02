using System;

// Token: 0x02002BA1 RID: 11169
public class SurvivorsHandbookItemDataBase : ISurvivorsHandbookItemDataBase
{
	// Token: 0x17001D41 RID: 7489
	// (get) Token: 0x060163E8 RID: 91112 RVA: 0x00629921 File Offset: 0x00627B21
	// (set) Token: 0x060163E9 RID: 91113 RVA: 0x00629929 File Offset: 0x00627B29
	public int Id { get; set; }

	// Token: 0x17001D42 RID: 7490
	// (get) Token: 0x060163EA RID: 91114 RVA: 0x00629932 File Offset: 0x00627B32
	// (set) Token: 0x060163EB RID: 91115 RVA: 0x0062993A File Offset: 0x00627B3A
	public bool? LockState { get; set; }

	// Token: 0x17001D43 RID: 7491
	// (get) Token: 0x060163EC RID: 91116 RVA: 0x00629943 File Offset: 0x00627B43
	// (set) Token: 0x060163ED RID: 91117 RVA: 0x0062994B File Offset: 0x00627B4B
	public bool? IsNew { get; set; }
}
