using System;
using System.Runtime.CompilerServices;

// Token: 0x02001165 RID: 4453
[NullableContext(2)]
[Nullable(0)]
public class ActivityRewardData : IActivityRewardData
{
	// Token: 0x170009B7 RID: 2487
	// (get) Token: 0x0600752C RID: 29996 RVA: 0x001ECCA3 File Offset: 0x001EAEA3
	// (set) Token: 0x0600752D RID: 29997 RVA: 0x001ECCAB File Offset: 0x001EAEAB
	public int? Id { get; set; }

	// Token: 0x170009B8 RID: 2488
	// (get) Token: 0x0600752E RID: 29998 RVA: 0x001ECCB4 File Offset: 0x001EAEB4
	// (set) Token: 0x0600752F RID: 29999 RVA: 0x001ECCBC File Offset: 0x001EAEBC
	[Nullable(1)]
	public string NameText { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170009B9 RID: 2489
	// (get) Token: 0x06007530 RID: 30000 RVA: 0x001ECCC5 File Offset: 0x001EAEC5
	// (set) Token: 0x06007531 RID: 30001 RVA: 0x001ECCCD File Offset: 0x001EAECD
	public string NameTextId { get; set; }

	// Token: 0x170009BA RID: 2490
	// (get) Token: 0x06007532 RID: 30002 RVA: 0x001ECCD6 File Offset: 0x001EAED6
	// (set) Token: 0x06007533 RID: 30003 RVA: 0x001ECCDE File Offset: 0x001EAEDE
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] NameTextArgs { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170009BB RID: 2491
	// (get) Token: 0x06007534 RID: 30004 RVA: 0x001ECCE7 File Offset: 0x001EAEE7
	// (set) Token: 0x06007535 RID: 30005 RVA: 0x001ECCEF File Offset: 0x001EAEEF
	public TItem[] RewardList { get; set; }

	// Token: 0x170009BC RID: 2492
	// (get) Token: 0x06007536 RID: 30006 RVA: 0x001ECCF8 File Offset: 0x001EAEF8
	// (set) Token: 0x06007537 RID: 30007 RVA: 0x001ECD00 File Offset: 0x001EAF00
	public EActivityRewardState RewardState { get; set; }

	// Token: 0x170009BD RID: 2493
	// (get) Token: 0x06007538 RID: 30008 RVA: 0x001ECD09 File Offset: 0x001EAF09
	// (set) Token: 0x06007539 RID: 30009 RVA: 0x001ECD11 File Offset: 0x001EAF11
	public string RewardButtonTextId { get; set; }

	// Token: 0x170009BE RID: 2494
	// (get) Token: 0x0600753A RID: 30010 RVA: 0x001ECD1A File Offset: 0x001EAF1A
	// (set) Token: 0x0600753B RID: 30011 RVA: 0x001ECD22 File Offset: 0x001EAF22
	public string RewardButtonText { get; set; }

	// Token: 0x170009BF RID: 2495
	// (get) Token: 0x0600753C RID: 30012 RVA: 0x001ECD2B File Offset: 0x001EAF2B
	// (set) Token: 0x0600753D RID: 30013 RVA: 0x001ECD33 File Offset: 0x001EAF33
	public bool? RewardButtonRedDot { get; set; }

	// Token: 0x170009C0 RID: 2496
	// (get) Token: 0x0600753E RID: 30014 RVA: 0x001ECD3C File Offset: 0x001EAF3C
	// (set) Token: 0x0600753F RID: 30015 RVA: 0x001ECD44 File Offset: 0x001EAF44
	public Action ClickFunction { get; set; }

	// Token: 0x170009C1 RID: 2497
	// (get) Token: 0x06007540 RID: 30016 RVA: 0x001ECD4D File Offset: 0x001EAF4D
	// (set) Token: 0x06007541 RID: 30017 RVA: 0x001ECD55 File Offset: 0x001EAF55
	public bool? ClickFunctionAndCloseSelf { get; set; }

	// Token: 0x170009C2 RID: 2498
	// (get) Token: 0x06007542 RID: 30018 RVA: 0x001ECD5E File Offset: 0x001EAF5E
	// (set) Token: 0x06007543 RID: 30019 RVA: 0x001ECD66 File Offset: 0x001EAF66
	public string ProgressText { get; set; }
}
