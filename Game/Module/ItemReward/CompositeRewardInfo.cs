using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B0D RID: 23309
	[NullableContext(2)]
	[Nullable(0)]
	public class CompositeRewardInfo : RewardInfo, ICompositeRewardInfo, IRewardInfo
	{
		// Token: 0x17009673 RID: 38515
		// (get) Token: 0x0603AFA1 RID: 241569 RVA: 0x00EF2384 File Offset: 0x00EF0584
		// (set) Token: 0x0603AFA2 RID: 241570 RVA: 0x00EF238C File Offset: 0x00EF058C
		public new ERewardInfoType Type { get; set; } = ERewardInfoType.Composite;

		// Token: 0x17009674 RID: 38516
		// (get) Token: 0x0603AFA3 RID: 241571 RVA: 0x00EF2395 File Offset: 0x00EF0595
		// (set) Token: 0x0603AFA4 RID: 241572 RVA: 0x00EF239D File Offset: 0x00EF059D
		public int Id { get; set; }

		// Token: 0x17009675 RID: 38517
		// (get) Token: 0x0603AFA5 RID: 241573 RVA: 0x00EF23A6 File Offset: 0x00EF05A6
		// (set) Token: 0x0603AFA6 RID: 241574 RVA: 0x00EF23AE File Offset: 0x00EF05AE
		public bool IsSuccess { get; set; }

		// Token: 0x17009676 RID: 38518
		// (get) Token: 0x0603AFA7 RID: 241575 RVA: 0x00EF23B7 File Offset: 0x00EF05B7
		// (set) Token: 0x0603AFA8 RID: 241576 RVA: 0x00EF23BF File Offset: 0x00EF05BF
		public string Title { get; set; }

		// Token: 0x17009677 RID: 38519
		// (get) Token: 0x0603AFA9 RID: 241577 RVA: 0x00EF23C8 File Offset: 0x00EF05C8
		// (set) Token: 0x0603AFAA RID: 241578 RVA: 0x00EF23D0 File Offset: 0x00EF05D0
		public string ContinueText { get; set; }

		// Token: 0x17009678 RID: 38520
		// (get) Token: 0x0603AFAB RID: 241579 RVA: 0x00EF23D9 File Offset: 0x00EF05D9
		// (set) Token: 0x0603AFAC RID: 241580 RVA: 0x00EF23E1 File Offset: 0x00EF05E1
		public string TitleIconPath { get; set; }

		// Token: 0x17009679 RID: 38521
		// (get) Token: 0x0603AFAD RID: 241581 RVA: 0x00EF23EA File Offset: 0x00EF05EA
		// (set) Token: 0x0603AFAE RID: 241582 RVA: 0x00EF23F2 File Offset: 0x00EF05F2
		public bool IsProgressVisible { get; set; }

		// Token: 0x1700967A RID: 38522
		// (get) Token: 0x0603AFAF RID: 241583 RVA: 0x00EF23FB File Offset: 0x00EF05FB
		// (set) Token: 0x0603AFB0 RID: 241584 RVA: 0x00EF2403 File Offset: 0x00EF0603
		[Nullable(1)]
		public string ProgressBarTitle { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x1700967B RID: 38523
		// (get) Token: 0x0603AFB1 RID: 241585 RVA: 0x00EF240C File Offset: 0x00EF060C
		// (set) Token: 0x0603AFB2 RID: 241586 RVA: 0x00EF2414 File Offset: 0x00EF0614
		public int ProgressBarAnimationTime { get; set; }

		// Token: 0x1700967C RID: 38524
		// (get) Token: 0x0603AFB3 RID: 241587 RVA: 0x00EF241D File Offset: 0x00EF061D
		// (set) Token: 0x0603AFB4 RID: 241588 RVA: 0x00EF2425 File Offset: 0x00EF0625
		public bool IsItemVisible { get; set; }
	}
}
