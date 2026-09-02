using System;
using System.Runtime.CompilerServices;

// Token: 0x02002399 RID: 9113
[NullableContext(1)]
public interface IGameplayShopItemBaseProxy
{
	// Token: 0x170015D7 RID: 5591
	// (get) Token: 0x060117F2 RID: 71666
	// (set) Token: 0x060117F3 RID: 71667
	int CurrencyId { get; set; }

	// Token: 0x170015D8 RID: 5592
	// (get) Token: 0x060117F4 RID: 71668
	// (set) Token: 0x060117F5 RID: 71669
	int ItemId { get; set; }

	// Token: 0x170015D9 RID: 5593
	// (get) Token: 0x060117F6 RID: 71670
	// (set) Token: 0x060117F7 RID: 71671
	string QualitySpritePath { get; set; }

	// Token: 0x170015DA RID: 5594
	// (get) Token: 0x060117F8 RID: 71672
	// (set) Token: 0x060117F9 RID: 71673
	string ItemTexturePath { get; set; }

	// Token: 0x170015DB RID: 5595
	// (get) Token: 0x060117FA RID: 71674
	// (set) Token: 0x060117FB RID: 71675
	bool ItemTextureVisible { get; set; }

	// Token: 0x170015DC RID: 5596
	// (get) Token: 0x060117FC RID: 71676
	// (set) Token: 0x060117FD RID: 71677
	string BigItemIconTexturePath { get; set; }

	// Token: 0x170015DD RID: 5597
	// (get) Token: 0x060117FE RID: 71678
	// (set) Token: 0x060117FF RID: 71679
	bool BigItemIconVisible { get; set; }

	// Token: 0x170015DE RID: 5598
	// (get) Token: 0x06011800 RID: 71680
	// (set) Token: 0x06011801 RID: 71681
	GameplayShopTextData ItemNameTextData { get; set; }

	// Token: 0x170015DF RID: 5599
	// (get) Token: 0x06011802 RID: 71682
	// (set) Token: 0x06011803 RID: 71683
	bool TipsButtonVisible { get; set; }

	// Token: 0x170015E0 RID: 5600
	// (get) Token: 0x06011804 RID: 71684
	// (set) Token: 0x06011805 RID: 71685
	bool BottomBgVisible { get; set; }

	// Token: 0x170015E1 RID: 5601
	// (get) Token: 0x06011806 RID: 71686
	// (set) Token: 0x06011807 RID: 71687
	GameplayShopTextData BuyLimitCountTextData { get; set; }

	// Token: 0x170015E2 RID: 5602
	// (get) Token: 0x06011808 RID: 71688
	// (set) Token: 0x06011809 RID: 71689
	bool BuyLimitCountTextVisible { get; set; }

	// Token: 0x170015E3 RID: 5603
	// (get) Token: 0x0601180A RID: 71690
	// (set) Token: 0x0601180B RID: 71691
	bool PriceItemVisible { get; set; }

	// Token: 0x170015E4 RID: 5604
	// (get) Token: 0x0601180C RID: 71692
	// (set) Token: 0x0601180D RID: 71693
	bool CurrencyIconVisible { get; set; }

	// Token: 0x170015E5 RID: 5605
	// (get) Token: 0x0601180E RID: 71694
	// (set) Token: 0x0601180F RID: 71695
	GameplayShopTextData NowPriceTextData { get; set; }

	// Token: 0x170015E6 RID: 5606
	// (get) Token: 0x06011810 RID: 71696
	// (set) Token: 0x06011811 RID: 71697
	string NowPriceTextColor { get; set; }

	// Token: 0x170015E7 RID: 5607
	// (get) Token: 0x06011812 RID: 71698
	// (set) Token: 0x06011813 RID: 71699
	GameplayShopTextData OriginalPriceTextData { get; set; }

	// Token: 0x170015E8 RID: 5608
	// (get) Token: 0x06011814 RID: 71700
	// (set) Token: 0x06011815 RID: 71701
	bool OriginalPriceVisible { get; set; }

	// Token: 0x170015E9 RID: 5609
	// (get) Token: 0x06011816 RID: 71702
	// (set) Token: 0x06011817 RID: 71703
	GameplayShopTextData PriceTipsTextData { get; set; }

	// Token: 0x170015EA RID: 5610
	// (get) Token: 0x06011818 RID: 71704
	// (set) Token: 0x06011819 RID: 71705
	bool PriceTipsTextVisible { get; set; }

	// Token: 0x170015EB RID: 5611
	// (get) Token: 0x0601181A RID: 71706
	// (set) Token: 0x0601181B RID: 71707
	bool RedDotVisible { get; set; }

	// Token: 0x170015EC RID: 5612
	// (get) Token: 0x0601181C RID: 71708
	// (set) Token: 0x0601181D RID: 71709
	bool ItemBgItemVisible { get; set; }

	// Token: 0x170015ED RID: 5613
	// (get) Token: 0x0601181E RID: 71710
	// (set) Token: 0x0601181F RID: 71711
	bool RaycastTarget { get; set; }

	// Token: 0x06011820 RID: 71712
	void OnTipsButtonClick();
}
