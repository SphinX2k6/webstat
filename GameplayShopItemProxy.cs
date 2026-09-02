using System;
using System.Runtime.CompilerServices;

// Token: 0x0200239D RID: 9117
[NullableContext(1)]
[Nullable(0)]
public class GameplayShopItemProxy : IGameplayShopItemProxy, IGameplayShopItemBaseProxy
{
	// Token: 0x17001626 RID: 5670
	// (get) Token: 0x0601189A RID: 71834 RVA: 0x004D0D5E File Offset: 0x004CEF5E
	// (set) Token: 0x0601189B RID: 71835 RVA: 0x004D0D66 File Offset: 0x004CEF66
	public int CurrencyId { get; set; }

	// Token: 0x17001627 RID: 5671
	// (get) Token: 0x0601189C RID: 71836 RVA: 0x004D0D6F File Offset: 0x004CEF6F
	// (set) Token: 0x0601189D RID: 71837 RVA: 0x004D0D77 File Offset: 0x004CEF77
	public int ItemId { get; set; }

	// Token: 0x17001628 RID: 5672
	// (get) Token: 0x0601189E RID: 71838 RVA: 0x004D0D80 File Offset: 0x004CEF80
	// (set) Token: 0x0601189F RID: 71839 RVA: 0x004D0D88 File Offset: 0x004CEF88
	public string QualitySpritePath { get; set; } = "";

	// Token: 0x17001629 RID: 5673
	// (get) Token: 0x060118A0 RID: 71840 RVA: 0x004D0D91 File Offset: 0x004CEF91
	// (set) Token: 0x060118A1 RID: 71841 RVA: 0x004D0D99 File Offset: 0x004CEF99
	public string ItemTexturePath { get; set; } = "";

	// Token: 0x1700162A RID: 5674
	// (get) Token: 0x060118A2 RID: 71842 RVA: 0x004D0DA2 File Offset: 0x004CEFA2
	// (set) Token: 0x060118A3 RID: 71843 RVA: 0x004D0DAA File Offset: 0x004CEFAA
	public bool ItemTextureVisible { get; set; }

	// Token: 0x1700162B RID: 5675
	// (get) Token: 0x060118A4 RID: 71844 RVA: 0x004D0DB3 File Offset: 0x004CEFB3
	// (set) Token: 0x060118A5 RID: 71845 RVA: 0x004D0DBB File Offset: 0x004CEFBB
	public string BigItemIconTexturePath { get; set; } = "";

	// Token: 0x1700162C RID: 5676
	// (get) Token: 0x060118A6 RID: 71846 RVA: 0x004D0DC4 File Offset: 0x004CEFC4
	// (set) Token: 0x060118A7 RID: 71847 RVA: 0x004D0DCC File Offset: 0x004CEFCC
	public bool BigItemIconVisible { get; set; }

	// Token: 0x1700162D RID: 5677
	// (get) Token: 0x060118A8 RID: 71848 RVA: 0x004D0DD5 File Offset: 0x004CEFD5
	// (set) Token: 0x060118A9 RID: 71849 RVA: 0x004D0DDD File Offset: 0x004CEFDD
	public GameplayShopTextData ItemNameTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x1700162E RID: 5678
	// (get) Token: 0x060118AA RID: 71850 RVA: 0x004D0DE6 File Offset: 0x004CEFE6
	// (set) Token: 0x060118AB RID: 71851 RVA: 0x004D0DEE File Offset: 0x004CEFEE
	public bool TipsButtonVisible { get; set; }

	// Token: 0x1700162F RID: 5679
	// (get) Token: 0x060118AC RID: 71852 RVA: 0x004D0DF7 File Offset: 0x004CEFF7
	// (set) Token: 0x060118AD RID: 71853 RVA: 0x004D0DFF File Offset: 0x004CEFFF
	public bool BottomBgVisible { get; set; }

	// Token: 0x17001630 RID: 5680
	// (get) Token: 0x060118AE RID: 71854 RVA: 0x004D0E08 File Offset: 0x004CF008
	// (set) Token: 0x060118AF RID: 71855 RVA: 0x004D0E10 File Offset: 0x004CF010
	public GameplayShopTextData BuyLimitCountTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001631 RID: 5681
	// (get) Token: 0x060118B0 RID: 71856 RVA: 0x004D0E19 File Offset: 0x004CF019
	// (set) Token: 0x060118B1 RID: 71857 RVA: 0x004D0E21 File Offset: 0x004CF021
	public bool BuyLimitCountTextVisible { get; set; }

	// Token: 0x17001632 RID: 5682
	// (get) Token: 0x060118B2 RID: 71858 RVA: 0x004D0E2A File Offset: 0x004CF02A
	// (set) Token: 0x060118B3 RID: 71859 RVA: 0x004D0E32 File Offset: 0x004CF032
	public bool PriceItemVisible { get; set; }

	// Token: 0x17001633 RID: 5683
	// (get) Token: 0x060118B4 RID: 71860 RVA: 0x004D0E3B File Offset: 0x004CF03B
	// (set) Token: 0x060118B5 RID: 71861 RVA: 0x004D0E43 File Offset: 0x004CF043
	public bool CurrencyIconVisible { get; set; }

	// Token: 0x17001634 RID: 5684
	// (get) Token: 0x060118B6 RID: 71862 RVA: 0x004D0E4C File Offset: 0x004CF04C
	// (set) Token: 0x060118B7 RID: 71863 RVA: 0x004D0E54 File Offset: 0x004CF054
	public GameplayShopTextData NowPriceTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001635 RID: 5685
	// (get) Token: 0x060118B8 RID: 71864 RVA: 0x004D0E5D File Offset: 0x004CF05D
	// (set) Token: 0x060118B9 RID: 71865 RVA: 0x004D0E65 File Offset: 0x004CF065
	public string NowPriceTextColor { get; set; } = "";

	// Token: 0x17001636 RID: 5686
	// (get) Token: 0x060118BA RID: 71866 RVA: 0x004D0E6E File Offset: 0x004CF06E
	// (set) Token: 0x060118BB RID: 71867 RVA: 0x004D0E76 File Offset: 0x004CF076
	public GameplayShopTextData OriginalPriceTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001637 RID: 5687
	// (get) Token: 0x060118BC RID: 71868 RVA: 0x004D0E7F File Offset: 0x004CF07F
	// (set) Token: 0x060118BD RID: 71869 RVA: 0x004D0E87 File Offset: 0x004CF087
	public bool OriginalPriceVisible { get; set; }

	// Token: 0x17001638 RID: 5688
	// (get) Token: 0x060118BE RID: 71870 RVA: 0x004D0E90 File Offset: 0x004CF090
	// (set) Token: 0x060118BF RID: 71871 RVA: 0x004D0E98 File Offset: 0x004CF098
	public GameplayShopTextData PriceTipsTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001639 RID: 5689
	// (get) Token: 0x060118C0 RID: 71872 RVA: 0x004D0EA1 File Offset: 0x004CF0A1
	// (set) Token: 0x060118C1 RID: 71873 RVA: 0x004D0EA9 File Offset: 0x004CF0A9
	public bool PriceTipsTextVisible { get; set; }

	// Token: 0x1700163A RID: 5690
	// (get) Token: 0x060118C2 RID: 71874 RVA: 0x004D0EB2 File Offset: 0x004CF0B2
	// (set) Token: 0x060118C3 RID: 71875 RVA: 0x004D0EBA File Offset: 0x004CF0BA
	public bool RedDotVisible { get; set; }

	// Token: 0x1700163B RID: 5691
	// (get) Token: 0x060118C4 RID: 71876 RVA: 0x004D0EC3 File Offset: 0x004CF0C3
	// (set) Token: 0x060118C5 RID: 71877 RVA: 0x004D0ECB File Offset: 0x004CF0CB
	public bool ItemBgItemVisible { get; set; }

	// Token: 0x1700163C RID: 5692
	// (get) Token: 0x060118C6 RID: 71878 RVA: 0x004D0ED4 File Offset: 0x004CF0D4
	// (set) Token: 0x060118C7 RID: 71879 RVA: 0x004D0EDC File Offset: 0x004CF0DC
	public bool RaycastTarget { get; set; }

	// Token: 0x1700163D RID: 5693
	// (get) Token: 0x060118C8 RID: 71880 RVA: 0x004D0EE5 File Offset: 0x004CF0E5
	// (set) Token: 0x060118C9 RID: 71881 RVA: 0x004D0EED File Offset: 0x004CF0ED
	public GameplayShopTextData DiscountTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x1700163E RID: 5694
	// (get) Token: 0x060118CA RID: 71882 RVA: 0x004D0EF6 File Offset: 0x004CF0F6
	// (set) Token: 0x060118CB RID: 71883 RVA: 0x004D0EFE File Offset: 0x004CF0FE
	public bool DiscountItemVisible { get; set; }

	// Token: 0x1700163F RID: 5695
	// (get) Token: 0x060118CC RID: 71884 RVA: 0x004D0F07 File Offset: 0x004CF107
	// (set) Token: 0x060118CD RID: 71885 RVA: 0x004D0F0F File Offset: 0x004CF10F
	public GameplayShopTextData LabelTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001640 RID: 5696
	// (get) Token: 0x060118CE RID: 71886 RVA: 0x004D0F18 File Offset: 0x004CF118
	// (set) Token: 0x060118CF RID: 71887 RVA: 0x004D0F20 File Offset: 0x004CF120
	public bool LabelVisible { get; set; }

	// Token: 0x17001641 RID: 5697
	// (get) Token: 0x060118D0 RID: 71888 RVA: 0x004D0F29 File Offset: 0x004CF129
	// (set) Token: 0x060118D1 RID: 71889 RVA: 0x004D0F31 File Offset: 0x004CF131
	public GameplayShopTextData LeftTimeTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001642 RID: 5698
	// (get) Token: 0x060118D2 RID: 71890 RVA: 0x004D0F3A File Offset: 0x004CF13A
	// (set) Token: 0x060118D3 RID: 71891 RVA: 0x004D0F42 File Offset: 0x004CF142
	public bool LeftTimeItemVisible { get; set; }

	// Token: 0x17001643 RID: 5699
	// (get) Token: 0x060118D4 RID: 71892 RVA: 0x004D0F4B File Offset: 0x004CF14B
	// (set) Token: 0x060118D5 RID: 71893 RVA: 0x004D0F53 File Offset: 0x004CF153
	public GameplayShopTextData ReSellTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001644 RID: 5700
	// (get) Token: 0x060118D6 RID: 71894 RVA: 0x004D0F5C File Offset: 0x004CF15C
	// (set) Token: 0x060118D7 RID: 71895 RVA: 0x004D0F64 File Offset: 0x004CF164
	public bool ReSellItemVisible { get; set; }

	// Token: 0x17001645 RID: 5701
	// (get) Token: 0x060118D8 RID: 71896 RVA: 0x004D0F6D File Offset: 0x004CF16D
	// (set) Token: 0x060118D9 RID: 71897 RVA: 0x004D0F75 File Offset: 0x004CF175
	public GameplayShopTextData SoldOutTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001646 RID: 5702
	// (get) Token: 0x060118DA RID: 71898 RVA: 0x004D0F7E File Offset: 0x004CF17E
	// (set) Token: 0x060118DB RID: 71899 RVA: 0x004D0F86 File Offset: 0x004CF186
	public bool SoldOutItemVisible { get; set; }

	// Token: 0x17001647 RID: 5703
	// (get) Token: 0x060118DC RID: 71900 RVA: 0x004D0F8F File Offset: 0x004CF18F
	// (set) Token: 0x060118DD RID: 71901 RVA: 0x004D0F97 File Offset: 0x004CF197
	public GameplayShopTextData LockTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001648 RID: 5704
	// (get) Token: 0x060118DE RID: 71902 RVA: 0x004D0FA0 File Offset: 0x004CF1A0
	// (set) Token: 0x060118DF RID: 71903 RVA: 0x004D0FA8 File Offset: 0x004CF1A8
	public bool LockItemVisible { get; set; }

	// Token: 0x17001649 RID: 5705
	// (get) Token: 0x060118E0 RID: 71904 RVA: 0x004D0FB1 File Offset: 0x004CF1B1
	// (set) Token: 0x060118E1 RID: 71905 RVA: 0x004D0FB9 File Offset: 0x004CF1B9
	public bool TagNewItemVisible { get; set; }

	// Token: 0x060118E2 RID: 71906 RVA: 0x004D0FC2 File Offset: 0x004CF1C2
	public virtual void OnTipsButtonClick()
	{
	}

	// Token: 0x060118E3 RID: 71907 RVA: 0x004D0FC4 File Offset: 0x004CF1C4
	public virtual void OnBuyButtonClick()
	{
	}
}
