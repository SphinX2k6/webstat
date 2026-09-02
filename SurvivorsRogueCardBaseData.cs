using System;
using System.Runtime.CompilerServices;

// Token: 0x02002B95 RID: 11157
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsRogueCardBaseData : ISurvivorsRogueCardBase
{
	// Token: 0x17001D10 RID: 7440
	// (get) Token: 0x06016393 RID: 91027 RVA: 0x006296E4 File Offset: 0x006278E4
	// (set) Token: 0x06016394 RID: 91028 RVA: 0x006296EC File Offset: 0x006278EC
	public ESurvivorsRogueItemType Type { get; set; }

	// Token: 0x17001D11 RID: 7441
	// (get) Token: 0x06016395 RID: 91029 RVA: 0x006296F5 File Offset: 0x006278F5
	// (set) Token: 0x06016396 RID: 91030 RVA: 0x006296FD File Offset: 0x006278FD
	public int Id { get; set; }

	// Token: 0x17001D12 RID: 7442
	// (get) Token: 0x06016397 RID: 91031 RVA: 0x00629706 File Offset: 0x00627906
	// (set) Token: 0x06016398 RID: 91032 RVA: 0x0062970E File Offset: 0x0062790E
	public int? IncId { get; set; }

	// Token: 0x17001D13 RID: 7443
	// (get) Token: 0x06016399 RID: 91033 RVA: 0x00629717 File Offset: 0x00627917
	// (set) Token: 0x0601639A RID: 91034 RVA: 0x0062971F File Offset: 0x0062791F
	public int Index { get; set; }

	// Token: 0x17001D14 RID: 7444
	// (get) Token: 0x0601639B RID: 91035 RVA: 0x00629728 File Offset: 0x00627928
	// (set) Token: 0x0601639C RID: 91036 RVA: 0x00629730 File Offset: 0x00627930
	public int QualityId { get; set; }

	// Token: 0x17001D15 RID: 7445
	// (get) Token: 0x0601639D RID: 91037 RVA: 0x00629739 File Offset: 0x00627939
	// (set) Token: 0x0601639E RID: 91038 RVA: 0x00629741 File Offset: 0x00627941
	public string TitleId { get; set; }

	// Token: 0x17001D16 RID: 7446
	// (get) Token: 0x0601639F RID: 91039 RVA: 0x0062974A File Offset: 0x0062794A
	// (set) Token: 0x060163A0 RID: 91040 RVA: 0x00629752 File Offset: 0x00627952
	public string TitleText { get; set; }

	// Token: 0x17001D17 RID: 7447
	// (get) Token: 0x060163A1 RID: 91041 RVA: 0x0062975B File Offset: 0x0062795B
	// (set) Token: 0x060163A2 RID: 91042 RVA: 0x00629763 File Offset: 0x00627963
	[Nullable(1)]
	public string DescId { [NullableContext(1)] get; [NullableContext(1)] set; } = "";

	// Token: 0x17001D18 RID: 7448
	// (get) Token: 0x060163A3 RID: 91043 RVA: 0x0062976C File Offset: 0x0062796C
	// (set) Token: 0x060163A4 RID: 91044 RVA: 0x00629774 File Offset: 0x00627974
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] DescParams { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17001D19 RID: 7449
	// (get) Token: 0x060163A5 RID: 91045 RVA: 0x0062977D File Offset: 0x0062797D
	// (set) Token: 0x060163A6 RID: 91046 RVA: 0x00629785 File Offset: 0x00627985
	public bool? TagVisible { get; set; }

	// Token: 0x17001D1A RID: 7450
	// (get) Token: 0x060163A7 RID: 91047 RVA: 0x0062978E File Offset: 0x0062798E
	// (set) Token: 0x060163A8 RID: 91048 RVA: 0x00629796 File Offset: 0x00627996
	public string TagId { get; set; }

	// Token: 0x17001D1B RID: 7451
	// (get) Token: 0x060163A9 RID: 91049 RVA: 0x0062979F File Offset: 0x0062799F
	// (set) Token: 0x060163AA RID: 91050 RVA: 0x006297A7 File Offset: 0x006279A7
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] TagParams { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17001D1C RID: 7452
	// (get) Token: 0x060163AB RID: 91051 RVA: 0x006297B0 File Offset: 0x006279B0
	// (set) Token: 0x060163AC RID: 91052 RVA: 0x006297B8 File Offset: 0x006279B8
	public bool? UseToggle { get; set; }

	// Token: 0x17001D1D RID: 7453
	// (get) Token: 0x060163AD RID: 91053 RVA: 0x006297C1 File Offset: 0x006279C1
	// (set) Token: 0x060163AE RID: 91054 RVA: 0x006297C9 File Offset: 0x006279C9
	public bool? IsLevelUp { get; set; }

	// Token: 0x17001D1E RID: 7454
	// (get) Token: 0x060163AF RID: 91055 RVA: 0x006297D2 File Offset: 0x006279D2
	// (set) Token: 0x060163B0 RID: 91056 RVA: 0x006297DA File Offset: 0x006279DA
	public bool? NeedLock { get; set; }

	// Token: 0x17001D1F RID: 7455
	// (get) Token: 0x060163B1 RID: 91057 RVA: 0x006297E3 File Offset: 0x006279E3
	// (set) Token: 0x060163B2 RID: 91058 RVA: 0x006297EB File Offset: 0x006279EB
	public bool? LockState { get; set; }

	// Token: 0x17001D20 RID: 7456
	// (get) Token: 0x060163B3 RID: 91059 RVA: 0x006297F4 File Offset: 0x006279F4
	// (set) Token: 0x060163B4 RID: 91060 RVA: 0x006297FC File Offset: 0x006279FC
	public int? Cost { get; set; }

	// Token: 0x17001D21 RID: 7457
	// (get) Token: 0x060163B5 RID: 91061 RVA: 0x00629805 File Offset: 0x00627A05
	// (set) Token: 0x060163B6 RID: 91062 RVA: 0x0062980D File Offset: 0x00627A0D
	public bool? CostEnoughCheck { get; set; }
}
