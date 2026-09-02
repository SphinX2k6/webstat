using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B0F RID: 23311
	[NullableContext(2)]
	[Nullable(0)]
	public class ExploreRewardInfo : RewardInfo, IExploreRewardInfo, IRewardInfo
	{
		// Token: 0x1700968E RID: 38542
		// (get) Token: 0x0603AFD8 RID: 241624 RVA: 0x00EF243D File Offset: 0x00EF063D
		// (set) Token: 0x0603AFD9 RID: 241625 RVA: 0x00EF2445 File Offset: 0x00EF0645
		public new ERewardInfoType Type { get; set; } = ERewardInfoType.Explore;

		// Token: 0x1700968F RID: 38543
		// (get) Token: 0x0603AFDA RID: 241626 RVA: 0x00EF244E File Offset: 0x00EF064E
		// (set) Token: 0x0603AFDB RID: 241627 RVA: 0x00EF2456 File Offset: 0x00EF0656
		public bool IsSuccess { get; set; }

		// Token: 0x17009690 RID: 38544
		// (get) Token: 0x0603AFDC RID: 241628 RVA: 0x00EF245F File Offset: 0x00EF065F
		// (set) Token: 0x0603AFDD RID: 241629 RVA: 0x00EF2467 File Offset: 0x00EF0667
		public string Title { get; set; }

		// Token: 0x17009691 RID: 38545
		// (get) Token: 0x0603AFDE RID: 241630 RVA: 0x00EF2470 File Offset: 0x00EF0670
		// (set) Token: 0x0603AFDF RID: 241631 RVA: 0x00EF2478 File Offset: 0x00EF0678
		public string TitleHexColor { get; set; }

		// Token: 0x17009692 RID: 38546
		// (get) Token: 0x0603AFE0 RID: 241632 RVA: 0x00EF2481 File Offset: 0x00EF0681
		// (set) Token: 0x0603AFE1 RID: 241633 RVA: 0x00EF2489 File Offset: 0x00EF0689
		public string TitleIconPath { get; set; }

		// Token: 0x17009693 RID: 38547
		// (get) Token: 0x0603AFE2 RID: 241634 RVA: 0x00EF2492 File Offset: 0x00EF0692
		// (set) Token: 0x0603AFE3 RID: 241635 RVA: 0x00EF249A File Offset: 0x00EF069A
		public string TitleIconHexColor { get; set; }

		// Token: 0x17009694 RID: 38548
		// (get) Token: 0x0603AFE4 RID: 241636 RVA: 0x00EF24A3 File Offset: 0x00EF06A3
		// (set) Token: 0x0603AFE5 RID: 241637 RVA: 0x00EF24AB File Offset: 0x00EF06AB
		public bool IsRecordVisible { get; set; }

		// Token: 0x17009695 RID: 38549
		// (get) Token: 0x0603AFE6 RID: 241638 RVA: 0x00EF24B4 File Offset: 0x00EF06B4
		// (set) Token: 0x0603AFE7 RID: 241639 RVA: 0x00EF24BC File Offset: 0x00EF06BC
		public bool IsItemVisible { get; set; }

		// Token: 0x17009696 RID: 38550
		// (get) Token: 0x0603AFE8 RID: 241640 RVA: 0x00EF24C5 File Offset: 0x00EF06C5
		// (set) Token: 0x0603AFE9 RID: 241641 RVA: 0x00EF24CD File Offset: 0x00EF06CD
		public bool IsExploreProgressVisible { get; set; }

		// Token: 0x17009697 RID: 38551
		// (get) Token: 0x0603AFEA RID: 241642 RVA: 0x00EF24D6 File Offset: 0x00EF06D6
		// (set) Token: 0x0603AFEB RID: 241643 RVA: 0x00EF24DE File Offset: 0x00EF06DE
		public string ExploreBarTipsTextId { get; set; }

		// Token: 0x17009698 RID: 38552
		// (get) Token: 0x0603AFEC RID: 241644 RVA: 0x00EF24E7 File Offset: 0x00EF06E7
		// (set) Token: 0x0603AFED RID: 241645 RVA: 0x00EF24EF File Offset: 0x00EF06EF
		public bool IsDescription { get; set; }

		// Token: 0x17009699 RID: 38553
		// (get) Token: 0x0603AFEE RID: 241646 RVA: 0x00EF24F8 File Offset: 0x00EF06F8
		// (set) Token: 0x0603AFEF RID: 241647 RVA: 0x00EF2500 File Offset: 0x00EF0700
		public string Description { get; set; }

		// Token: 0x1700969A RID: 38554
		// (get) Token: 0x0603AFF0 RID: 241648 RVA: 0x00EF2509 File Offset: 0x00EF0709
		// (set) Token: 0x0603AFF1 RID: 241649 RVA: 0x00EF2511 File Offset: 0x00EF0711
		public bool? IsShowOnlineChallengePlayer { get; set; }

		// Token: 0x1700969B RID: 38555
		// (get) Token: 0x0603AFF2 RID: 241650 RVA: 0x00EF251A File Offset: 0x00EF071A
		// (set) Token: 0x0603AFF3 RID: 241651 RVA: 0x00EF2522 File Offset: 0x00EF0722
		public string Tip { get; set; }

		// Token: 0x1700969C RID: 38556
		// (get) Token: 0x0603AFF4 RID: 241652 RVA: 0x00EF252B File Offset: 0x00EF072B
		// (set) Token: 0x0603AFF5 RID: 241653 RVA: 0x00EF2533 File Offset: 0x00EF0733
		public bool? IsRewardMultiLine { get; set; }

		// Token: 0x1700969D RID: 38557
		// (get) Token: 0x0603AFF6 RID: 241654 RVA: 0x00EF253C File Offset: 0x00EF073C
		// (set) Token: 0x0603AFF7 RID: 241655 RVA: 0x00EF2544 File Offset: 0x00EF0744
		public Action OnCloseCallback { get; set; }

		// Token: 0x1700969E RID: 38558
		// (get) Token: 0x0603AFF8 RID: 241656 RVA: 0x00EF254D File Offset: 0x00EF074D
		// (set) Token: 0x0603AFF9 RID: 241657 RVA: 0x00EF2555 File Offset: 0x00EF0755
		public bool? IsBagFull { get; set; }
	}
}
