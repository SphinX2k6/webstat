using System;
using System.Runtime.CompilerServices;

// Token: 0x02002704 RID: 9988
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsRankData : IRacingBetsRankData
{
	// Token: 0x17001926 RID: 6438
	// (get) Token: 0x06013B50 RID: 80720 RVA: 0x0057D41C File Offset: 0x0057B61C
	// (set) Token: 0x06013B51 RID: 80721 RVA: 0x0057D424 File Offset: 0x0057B624
	public int PlayerId { get; set; }

	// Token: 0x17001927 RID: 6439
	// (get) Token: 0x06013B52 RID: 80722 RVA: 0x0057D42D File Offset: 0x0057B62D
	// (set) Token: 0x06013B53 RID: 80723 RVA: 0x0057D435 File Offset: 0x0057B635
	public int PlayerHeadPhoto { get; set; }

	// Token: 0x17001928 RID: 6440
	// (get) Token: 0x06013B54 RID: 80724 RVA: 0x0057D43E File Offset: 0x0057B63E
	// (set) Token: 0x06013B55 RID: 80725 RVA: 0x0057D446 File Offset: 0x0057B646
	public int RankNum { get; set; }

	// Token: 0x17001929 RID: 6441
	// (get) Token: 0x06013B56 RID: 80726 RVA: 0x0057D44F File Offset: 0x0057B64F
	// (set) Token: 0x06013B57 RID: 80727 RVA: 0x0057D457 File Offset: 0x0057B657
	public string Name { get; set; }

	// Token: 0x1700192A RID: 6442
	// (get) Token: 0x06013B58 RID: 80728 RVA: 0x0057D460 File Offset: 0x0057B660
	// (set) Token: 0x06013B59 RID: 80729 RVA: 0x0057D468 File Offset: 0x0057B668
	public int HitNum { get; set; }

	// Token: 0x1700192B RID: 6443
	// (get) Token: 0x06013B5A RID: 80730 RVA: 0x0057D471 File Offset: 0x0057B671
	// (set) Token: 0x06013B5B RID: 80731 RVA: 0x0057D479 File Offset: 0x0057B679
	public int CashNum { get; set; }
}
