using System;
using System.Runtime.CompilerServices;

// Token: 0x0200239C RID: 9116
[NullableContext(1)]
[Nullable(0)]
public class GameplayShopItemBaseProxy : IGameplayShopItemBaseProxy
{
	// Token: 0x1700160F RID: 5647
	// (get) Token: 0x0601186A RID: 71786 RVA: 0x004D0B5F File Offset: 0x004CED5F
	// (set) Token: 0x0601186B RID: 71787 RVA: 0x004D0B67 File Offset: 0x004CED67
	public int CurrencyId { get; set; }

	// Token: 0x17001610 RID: 5648
	// (get) Token: 0x0601186C RID: 71788 RVA: 0x004D0B70 File Offset: 0x004CED70
	// (set) Token: 0x0601186D RID: 71789 RVA: 0x004D0B78 File Offset: 0x004CED78
	public int ItemId { get; set; }

	// Token: 0x17001611 RID: 5649
	// (get) Token: 0x0601186E RID: 71790 RVA: 0x004D0B81 File Offset: 0x004CED81
	// (set) Token: 0x0601186F RID: 71791 RVA: 0x004D0B89 File Offset: 0x004CED89
	public string QualitySpritePath { get; set; } = "";

	// Token: 0x17001612 RID: 5650
	// (get) Token: 0x06011870 RID: 71792 RVA: 0x004D0B92 File Offset: 0x004CED92
	// (set) Token: 0x06011871 RID: 71793 RVA: 0x004D0B9A File Offset: 0x004CED9A
	public string ItemTexturePath { get; set; } = "";

	// Token: 0x17001613 RID: 5651
	// (get) Token: 0x06011872 RID: 71794 RVA: 0x004D0BA3 File Offset: 0x004CEDA3
	// (set) Token: 0x06011873 RID: 71795 RVA: 0x004D0BAB File Offset: 0x004CEDAB
	public bool ItemTextureVisible { get; set; }

	// Token: 0x17001614 RID: 5652
	// (get) Token: 0x06011874 RID: 71796 RVA: 0x004D0BB4 File Offset: 0x004CEDB4
	// (set) Token: 0x06011875 RID: 71797 RVA: 0x004D0BBC File Offset: 0x004CEDBC
	public string BigItemIconTexturePath { get; set; } = "";

	// Token: 0x17001615 RID: 5653
	// (get) Token: 0x06011876 RID: 71798 RVA: 0x004D0BC5 File Offset: 0x004CEDC5
	// (set) Token: 0x06011877 RID: 71799 RVA: 0x004D0BCD File Offset: 0x004CEDCD
	public bool BigItemIconVisible { get; set; }

	// Token: 0x17001616 RID: 5654
	// (get) Token: 0x06011878 RID: 71800 RVA: 0x004D0BD6 File Offset: 0x004CEDD6
	// (set) Token: 0x06011879 RID: 71801 RVA: 0x004D0BDE File Offset: 0x004CEDDE
	public GameplayShopTextData ItemNameTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001617 RID: 5655
	// (get) Token: 0x0601187A RID: 71802 RVA: 0x004D0BE7 File Offset: 0x004CEDE7
	// (set) Token: 0x0601187B RID: 71803 RVA: 0x004D0BEF File Offset: 0x004CEDEF
	public bool TipsButtonVisible { get; set; }

	// Token: 0x17001618 RID: 5656
	// (get) Token: 0x0601187C RID: 71804 RVA: 0x004D0BF8 File Offset: 0x004CEDF8
	// (set) Token: 0x0601187D RID: 71805 RVA: 0x004D0C00 File Offset: 0x004CEE00
	public bool BottomBgVisible { get; set; }

	// Token: 0x17001619 RID: 5657
	// (get) Token: 0x0601187E RID: 71806 RVA: 0x004D0C09 File Offset: 0x004CEE09
	// (set) Token: 0x0601187F RID: 71807 RVA: 0x004D0C11 File Offset: 0x004CEE11
	public GameplayShopTextData BuyLimitCountTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x1700161A RID: 5658
	// (get) Token: 0x06011880 RID: 71808 RVA: 0x004D0C1A File Offset: 0x004CEE1A
	// (set) Token: 0x06011881 RID: 71809 RVA: 0x004D0C22 File Offset: 0x004CEE22
	public bool BuyLimitCountTextVisible { get; set; }

	// Token: 0x1700161B RID: 5659
	// (get) Token: 0x06011882 RID: 71810 RVA: 0x004D0C2B File Offset: 0x004CEE2B
	// (set) Token: 0x06011883 RID: 71811 RVA: 0x004D0C33 File Offset: 0x004CEE33
	public bool PriceItemVisible { get; set; }

	// Token: 0x1700161C RID: 5660
	// (get) Token: 0x06011884 RID: 71812 RVA: 0x004D0C3C File Offset: 0x004CEE3C
	// (set) Token: 0x06011885 RID: 71813 RVA: 0x004D0C44 File Offset: 0x004CEE44
	public bool CurrencyIconVisible { get; set; }

	// Token: 0x1700161D RID: 5661
	// (get) Token: 0x06011886 RID: 71814 RVA: 0x004D0C4D File Offset: 0x004CEE4D
	// (set) Token: 0x06011887 RID: 71815 RVA: 0x004D0C55 File Offset: 0x004CEE55
	public GameplayShopTextData NowPriceTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x1700161E RID: 5662
	// (get) Token: 0x06011888 RID: 71816 RVA: 0x004D0C5E File Offset: 0x004CEE5E
	// (set) Token: 0x06011889 RID: 71817 RVA: 0x004D0C66 File Offset: 0x004CEE66
	public string NowPriceTextColor { get; set; } = "";

	// Token: 0x1700161F RID: 5663
	// (get) Token: 0x0601188A RID: 71818 RVA: 0x004D0C6F File Offset: 0x004CEE6F
	// (set) Token: 0x0601188B RID: 71819 RVA: 0x004D0C77 File Offset: 0x004CEE77
	public GameplayShopTextData OriginalPriceTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001620 RID: 5664
	// (get) Token: 0x0601188C RID: 71820 RVA: 0x004D0C80 File Offset: 0x004CEE80
	// (set) Token: 0x0601188D RID: 71821 RVA: 0x004D0C88 File Offset: 0x004CEE88
	public bool OriginalPriceVisible { get; set; }

	// Token: 0x17001621 RID: 5665
	// (get) Token: 0x0601188E RID: 71822 RVA: 0x004D0C91 File Offset: 0x004CEE91
	// (set) Token: 0x0601188F RID: 71823 RVA: 0x004D0C99 File Offset: 0x004CEE99
	public GameplayShopTextData PriceTipsTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001622 RID: 5666
	// (get) Token: 0x06011890 RID: 71824 RVA: 0x004D0CA2 File Offset: 0x004CEEA2
	// (set) Token: 0x06011891 RID: 71825 RVA: 0x004D0CAA File Offset: 0x004CEEAA
	public bool PriceTipsTextVisible { get; set; }

	// Token: 0x17001623 RID: 5667
	// (get) Token: 0x06011892 RID: 71826 RVA: 0x004D0CB3 File Offset: 0x004CEEB3
	// (set) Token: 0x06011893 RID: 71827 RVA: 0x004D0CBB File Offset: 0x004CEEBB
	public bool RedDotVisible { get; set; }

	// Token: 0x17001624 RID: 5668
	// (get) Token: 0x06011894 RID: 71828 RVA: 0x004D0CC4 File Offset: 0x004CEEC4
	// (set) Token: 0x06011895 RID: 71829 RVA: 0x004D0CCC File Offset: 0x004CEECC
	public bool ItemBgItemVisible { get; set; }

	// Token: 0x17001625 RID: 5669
	// (get) Token: 0x06011896 RID: 71830 RVA: 0x004D0CD5 File Offset: 0x004CEED5
	// (set) Token: 0x06011897 RID: 71831 RVA: 0x004D0CDD File Offset: 0x004CEEDD
	public bool RaycastTarget { get; set; }

	// Token: 0x06011898 RID: 71832 RVA: 0x004D0CE6 File Offset: 0x004CEEE6
	public virtual void OnTipsButtonClick()
	{
	}
}
