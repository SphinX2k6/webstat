using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x0200239B RID: 9115
[NullableContext(1)]
public interface IGameplayShopExchangePopViewProxy
{
	// Token: 0x170015FB RID: 5627
	// (get) Token: 0x0601183C RID: 71740
	// (set) Token: 0x0601183D RID: 71741
	[Nullable(2)]
	object ShopItemProxy { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170015FC RID: 5628
	// (get) Token: 0x0601183E RID: 71742
	// (set) Token: 0x0601183F RID: 71743
	int CurrencyId { get; set; }

	// Token: 0x170015FD RID: 5629
	// (get) Token: 0x06011840 RID: 71744
	// (set) Token: 0x06011841 RID: 71745
	List<int> CurrencyIdList { get; set; }

	// Token: 0x170015FE RID: 5630
	// (get) Token: 0x06011842 RID: 71746
	// (set) Token: 0x06011843 RID: 71747
	int Price { get; set; }

	// Token: 0x170015FF RID: 5631
	// (get) Token: 0x06011844 RID: 71748
	// (set) Token: 0x06011845 RID: 71749
	GameplayShopTextData DescribeTextData { get; set; }

	// Token: 0x17001600 RID: 5632
	// (get) Token: 0x06011846 RID: 71750
	// (set) Token: 0x06011847 RID: 71751
	bool TipTitleItemVisible { get; set; }

	// Token: 0x17001601 RID: 5633
	// (get) Token: 0x06011848 RID: 71752
	// (set) Token: 0x06011849 RID: 71753
	bool LeftTimeItemVisible { get; set; }

	// Token: 0x17001602 RID: 5634
	// (get) Token: 0x0601184A RID: 71754
	// (set) Token: 0x0601184B RID: 71755
	bool LeftTimeTextVisible { get; set; }

	// Token: 0x17001603 RID: 5635
	// (get) Token: 0x0601184C RID: 71756
	// (set) Token: 0x0601184D RID: 71757
	GameplayShopTextData LeftTimeDescTextData { get; set; }

	// Token: 0x17001604 RID: 5636
	// (get) Token: 0x0601184E RID: 71758
	// (set) Token: 0x0601184F RID: 71759
	GameplayShopTextData LeftTimeTextData { get; set; }

	// Token: 0x17001605 RID: 5637
	// (get) Token: 0x06011850 RID: 71760
	// (set) Token: 0x06011851 RID: 71761
	bool LimitTextItemVisible { get; set; }

	// Token: 0x17001606 RID: 5638
	// (get) Token: 0x06011852 RID: 71762
	// (set) Token: 0x06011853 RID: 71763
	GameplayShopTextData LimitTextData { get; set; }

	// Token: 0x17001607 RID: 5639
	// (get) Token: 0x06011854 RID: 71764
	// (set) Token: 0x06011855 RID: 71765
	bool LockItemVisible { get; set; }

	// Token: 0x17001608 RID: 5640
	// (get) Token: 0x06011856 RID: 71766
	// (set) Token: 0x06011857 RID: 71767
	GameplayShopTextData LockTextData { get; set; }

	// Token: 0x17001609 RID: 5641
	// (get) Token: 0x06011858 RID: 71768
	// (set) Token: 0x06011859 RID: 71769
	int ReSellTime { get; set; }

	// Token: 0x1700160A RID: 5642
	// (get) Token: 0x0601185A RID: 71770
	// (set) Token: 0x0601185B RID: 71771
	int BuyCount { get; set; }

	// Token: 0x1700160B RID: 5643
	// (get) Token: 0x0601185C RID: 71772
	// (set) Token: 0x0601185D RID: 71773
	int MaxBuyCount { get; set; }

	// Token: 0x1700160C RID: 5644
	// (get) Token: 0x0601185E RID: 71774
	// (set) Token: 0x0601185F RID: 71775
	string ExchangeTableTextId { get; set; }

	// Token: 0x1700160D RID: 5645
	// (get) Token: 0x06011860 RID: 71776
	// (set) Token: 0x06011861 RID: 71777
	[Nullable(2)]
	string CurrencyItemResourceId { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x1700160E RID: 5646
	// (get) Token: 0x06011862 RID: 71778
	// (set) Token: 0x06011863 RID: 71779
	string ShopItemResource { get; set; }

	// Token: 0x06011864 RID: 71780
	void OnConfirmButtonClick(int viewId);

	// Token: 0x06011865 RID: 71781
	bool CheckConfirmButtonCanInteract();

	// Token: 0x06011866 RID: 71782
	UiPanelBase ShopItemCreate();

	// Token: 0x06011867 RID: 71783
	void ShopItemRefresh();

	// Token: 0x06011868 RID: 71784
	bool CheckMoneyEnough();

	// Token: 0x06011869 RID: 71785
	void OnResellTimeRefresh();
}
