using System;
using System.Runtime.CompilerServices;

// Token: 0x0200239A RID: 9114
[NullableContext(1)]
public interface IGameplayShopItemProxy : IGameplayShopItemBaseProxy
{
	// Token: 0x170015EE RID: 5614
	// (get) Token: 0x06011821 RID: 71713
	// (set) Token: 0x06011822 RID: 71714
	GameplayShopTextData DiscountTextData { get; set; }

	// Token: 0x170015EF RID: 5615
	// (get) Token: 0x06011823 RID: 71715
	// (set) Token: 0x06011824 RID: 71716
	bool DiscountItemVisible { get; set; }

	// Token: 0x170015F0 RID: 5616
	// (get) Token: 0x06011825 RID: 71717
	// (set) Token: 0x06011826 RID: 71718
	GameplayShopTextData LabelTextData { get; set; }

	// Token: 0x170015F1 RID: 5617
	// (get) Token: 0x06011827 RID: 71719
	// (set) Token: 0x06011828 RID: 71720
	bool LabelVisible { get; set; }

	// Token: 0x170015F2 RID: 5618
	// (get) Token: 0x06011829 RID: 71721
	// (set) Token: 0x0601182A RID: 71722
	GameplayShopTextData LeftTimeTextData { get; set; }

	// Token: 0x170015F3 RID: 5619
	// (get) Token: 0x0601182B RID: 71723
	// (set) Token: 0x0601182C RID: 71724
	bool LeftTimeItemVisible { get; set; }

	// Token: 0x170015F4 RID: 5620
	// (get) Token: 0x0601182D RID: 71725
	// (set) Token: 0x0601182E RID: 71726
	GameplayShopTextData ReSellTextData { get; set; }

	// Token: 0x170015F5 RID: 5621
	// (get) Token: 0x0601182F RID: 71727
	// (set) Token: 0x06011830 RID: 71728
	bool ReSellItemVisible { get; set; }

	// Token: 0x170015F6 RID: 5622
	// (get) Token: 0x06011831 RID: 71729
	// (set) Token: 0x06011832 RID: 71730
	GameplayShopTextData SoldOutTextData { get; set; }

	// Token: 0x170015F7 RID: 5623
	// (get) Token: 0x06011833 RID: 71731
	// (set) Token: 0x06011834 RID: 71732
	bool SoldOutItemVisible { get; set; }

	// Token: 0x170015F8 RID: 5624
	// (get) Token: 0x06011835 RID: 71733
	// (set) Token: 0x06011836 RID: 71734
	GameplayShopTextData LockTextData { get; set; }

	// Token: 0x170015F9 RID: 5625
	// (get) Token: 0x06011837 RID: 71735
	// (set) Token: 0x06011838 RID: 71736
	bool LockItemVisible { get; set; }

	// Token: 0x170015FA RID: 5626
	// (get) Token: 0x06011839 RID: 71737
	// (set) Token: 0x0601183A RID: 71738
	bool TagNewItemVisible { get; set; }

	// Token: 0x0601183B RID: 71739
	void OnBuyButtonClick();
}
