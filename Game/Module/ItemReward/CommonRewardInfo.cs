using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B0B RID: 23307
	[NullableContext(2)]
	[Nullable(0)]
	public class CommonRewardInfo : RewardInfo, ICommonRewardInfo, IRewardInfo
	{
		// Token: 0x1700965E RID: 38494
		// (get) Token: 0x0603AF76 RID: 241526 RVA: 0x00EF22BA File Offset: 0x00EF04BA
		// (set) Token: 0x0603AF77 RID: 241527 RVA: 0x00EF22C2 File Offset: 0x00EF04C2
		public new ERewardInfoType Type { get; set; } = ERewardInfoType.Common;

		// Token: 0x1700965F RID: 38495
		// (get) Token: 0x0603AF78 RID: 241528 RVA: 0x00EF22CB File Offset: 0x00EF04CB
		// (set) Token: 0x0603AF79 RID: 241529 RVA: 0x00EF22D3 File Offset: 0x00EF04D3
		public string Title { get; set; }

		// Token: 0x17009660 RID: 38496
		// (get) Token: 0x0603AF7A RID: 241530 RVA: 0x00EF22DC File Offset: 0x00EF04DC
		// (set) Token: 0x0603AF7B RID: 241531 RVA: 0x00EF22E4 File Offset: 0x00EF04E4
		public string ContinueText { get; set; }

		// Token: 0x17009661 RID: 38497
		// (get) Token: 0x0603AF7C RID: 241532 RVA: 0x00EF22ED File Offset: 0x00EF04ED
		// (set) Token: 0x0603AF7D RID: 241533 RVA: 0x00EF22F5 File Offset: 0x00EF04F5
		public bool IsItemVisible { get; set; }

		// Token: 0x17009662 RID: 38498
		// (get) Token: 0x0603AF7E RID: 241534 RVA: 0x00EF22FE File Offset: 0x00EF04FE
		// (set) Token: 0x0603AF7F RID: 241535 RVA: 0x00EF2306 File Offset: 0x00EF0506
		public Action OnCloseCallback { get; set; }

		// Token: 0x17009663 RID: 38499
		// (get) Token: 0x0603AF80 RID: 241536 RVA: 0x00EF230F File Offset: 0x00EF050F
		// (set) Token: 0x0603AF81 RID: 241537 RVA: 0x00EF2317 File Offset: 0x00EF0517
		public string LeftBtnTextId { get; set; }

		// Token: 0x17009664 RID: 38500
		// (get) Token: 0x0603AF82 RID: 241538 RVA: 0x00EF2320 File Offset: 0x00EF0520
		// (set) Token: 0x0603AF83 RID: 241539 RVA: 0x00EF2328 File Offset: 0x00EF0528
		public string RightBtnTextId { get; set; }

		// Token: 0x17009665 RID: 38501
		// (get) Token: 0x0603AF84 RID: 241540 RVA: 0x00EF2331 File Offset: 0x00EF0531
		// (set) Token: 0x0603AF85 RID: 241541 RVA: 0x00EF2339 File Offset: 0x00EF0539
		public Action LeftAction { get; set; }

		// Token: 0x17009666 RID: 38502
		// (get) Token: 0x0603AF86 RID: 241542 RVA: 0x00EF2342 File Offset: 0x00EF0542
		// (set) Token: 0x0603AF87 RID: 241543 RVA: 0x00EF234A File Offset: 0x00EF054A
		public Action RightAction { get; set; }

		// Token: 0x17009667 RID: 38503
		// (get) Token: 0x0603AF88 RID: 241544 RVA: 0x00EF2353 File Offset: 0x00EF0553
		// (set) Token: 0x0603AF89 RID: 241545 RVA: 0x00EF235B File Offset: 0x00EF055B
		public bool? DisableMaskClose { get; set; }

		// Token: 0x17009668 RID: 38504
		// (get) Token: 0x0603AF8A RID: 241546 RVA: 0x00EF2364 File Offset: 0x00EF0564
		// (set) Token: 0x0603AF8B RID: 241547 RVA: 0x00EF236C File Offset: 0x00EF056C
		public bool? TipsCanSkip { get; set; }
	}
}
