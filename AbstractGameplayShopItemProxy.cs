using System;
using System.Runtime.CompilerServices;

// Token: 0x02002393 RID: 9107
[NullableContext(1)]
[Nullable(0)]
public abstract class AbstractGameplayShopItemProxy : AbstractGameplayShopBaseItemProxy, IGameplayShopItemProxy, IGameplayShopItemBaseProxy
{
	// Token: 0x170015CA RID: 5578
	// (get) Token: 0x0601178C RID: 71564 RVA: 0x004CF5B5 File Offset: 0x004CD7B5
	// (set) Token: 0x0601178D RID: 71565 RVA: 0x004CF5BD File Offset: 0x004CD7BD
	public GameplayShopTextData DiscountTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015CB RID: 5579
	// (get) Token: 0x0601178E RID: 71566 RVA: 0x004CF5C6 File Offset: 0x004CD7C6
	// (set) Token: 0x0601178F RID: 71567 RVA: 0x004CF5CE File Offset: 0x004CD7CE
	public bool DiscountItemVisible { get; set; }

	// Token: 0x170015CC RID: 5580
	// (get) Token: 0x06011790 RID: 71568 RVA: 0x004CF5D7 File Offset: 0x004CD7D7
	// (set) Token: 0x06011791 RID: 71569 RVA: 0x004CF5DF File Offset: 0x004CD7DF
	public GameplayShopTextData LabelTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015CD RID: 5581
	// (get) Token: 0x06011792 RID: 71570 RVA: 0x004CF5E8 File Offset: 0x004CD7E8
	// (set) Token: 0x06011793 RID: 71571 RVA: 0x004CF5F0 File Offset: 0x004CD7F0
	public bool LabelVisible { get; set; }

	// Token: 0x170015CE RID: 5582
	// (get) Token: 0x06011794 RID: 71572 RVA: 0x004CF5F9 File Offset: 0x004CD7F9
	// (set) Token: 0x06011795 RID: 71573 RVA: 0x004CF601 File Offset: 0x004CD801
	public GameplayShopTextData LeftTimeTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015CF RID: 5583
	// (get) Token: 0x06011796 RID: 71574 RVA: 0x004CF60A File Offset: 0x004CD80A
	// (set) Token: 0x06011797 RID: 71575 RVA: 0x004CF612 File Offset: 0x004CD812
	public bool LeftTimeItemVisible { get; set; }

	// Token: 0x170015D0 RID: 5584
	// (get) Token: 0x06011798 RID: 71576 RVA: 0x004CF61B File Offset: 0x004CD81B
	// (set) Token: 0x06011799 RID: 71577 RVA: 0x004CF623 File Offset: 0x004CD823
	public GameplayShopTextData ReSellTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015D1 RID: 5585
	// (get) Token: 0x0601179A RID: 71578 RVA: 0x004CF62C File Offset: 0x004CD82C
	// (set) Token: 0x0601179B RID: 71579 RVA: 0x004CF634 File Offset: 0x004CD834
	public bool ReSellItemVisible { get; set; }

	// Token: 0x170015D2 RID: 5586
	// (get) Token: 0x0601179C RID: 71580 RVA: 0x004CF63D File Offset: 0x004CD83D
	// (set) Token: 0x0601179D RID: 71581 RVA: 0x004CF645 File Offset: 0x004CD845
	public GameplayShopTextData SoldOutTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015D3 RID: 5587
	// (get) Token: 0x0601179E RID: 71582 RVA: 0x004CF64E File Offset: 0x004CD84E
	// (set) Token: 0x0601179F RID: 71583 RVA: 0x004CF656 File Offset: 0x004CD856
	public bool SoldOutItemVisible { get; set; }

	// Token: 0x170015D4 RID: 5588
	// (get) Token: 0x060117A0 RID: 71584 RVA: 0x004CF65F File Offset: 0x004CD85F
	// (set) Token: 0x060117A1 RID: 71585 RVA: 0x004CF667 File Offset: 0x004CD867
	public GameplayShopTextData LockTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015D5 RID: 5589
	// (get) Token: 0x060117A2 RID: 71586 RVA: 0x004CF670 File Offset: 0x004CD870
	// (set) Token: 0x060117A3 RID: 71587 RVA: 0x004CF678 File Offset: 0x004CD878
	public bool LockItemVisible { get; set; }

	// Token: 0x170015D6 RID: 5590
	// (get) Token: 0x060117A4 RID: 71588 RVA: 0x004CF681 File Offset: 0x004CD881
	// (set) Token: 0x060117A5 RID: 71589 RVA: 0x004CF689 File Offset: 0x004CD889
	public bool TagNewItemVisible { get; set; }

	// Token: 0x060117A6 RID: 71590
	public abstract void OnBuyButtonClick();
}
