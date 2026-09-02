using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x0200239E RID: 9118
[NullableContext(1)]
[Nullable(0)]
public class GameplayShopExchangePopViewProxy : IGameplayShopExchangePopViewProxy
{
	// Token: 0x1700164A RID: 5706
	// (get) Token: 0x060118E5 RID: 71909 RVA: 0x004D1080 File Offset: 0x004CF280
	// (set) Token: 0x060118E6 RID: 71910 RVA: 0x004D1088 File Offset: 0x004CF288
	[Nullable(2)]
	public object ShopItemProxy { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x1700164B RID: 5707
	// (get) Token: 0x060118E7 RID: 71911 RVA: 0x004D1091 File Offset: 0x004CF291
	// (set) Token: 0x060118E8 RID: 71912 RVA: 0x004D1099 File Offset: 0x004CF299
	public int CurrencyId { get; set; }

	// Token: 0x1700164C RID: 5708
	// (get) Token: 0x060118E9 RID: 71913 RVA: 0x004D10A2 File Offset: 0x004CF2A2
	// (set) Token: 0x060118EA RID: 71914 RVA: 0x004D10AA File Offset: 0x004CF2AA
	public List<int> CurrencyIdList { get; set; } = new List<int>();

	// Token: 0x1700164D RID: 5709
	// (get) Token: 0x060118EB RID: 71915 RVA: 0x004D10B3 File Offset: 0x004CF2B3
	// (set) Token: 0x060118EC RID: 71916 RVA: 0x004D10BB File Offset: 0x004CF2BB
	public int Price { get; set; }

	// Token: 0x1700164E RID: 5710
	// (get) Token: 0x060118ED RID: 71917 RVA: 0x004D10C4 File Offset: 0x004CF2C4
	// (set) Token: 0x060118EE RID: 71918 RVA: 0x004D10CC File Offset: 0x004CF2CC
	public GameplayShopTextData DescribeTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x1700164F RID: 5711
	// (get) Token: 0x060118EF RID: 71919 RVA: 0x004D10D5 File Offset: 0x004CF2D5
	// (set) Token: 0x060118F0 RID: 71920 RVA: 0x004D10DD File Offset: 0x004CF2DD
	public bool TipTitleItemVisible { get; set; }

	// Token: 0x17001650 RID: 5712
	// (get) Token: 0x060118F1 RID: 71921 RVA: 0x004D10E6 File Offset: 0x004CF2E6
	// (set) Token: 0x060118F2 RID: 71922 RVA: 0x004D10EE File Offset: 0x004CF2EE
	public bool LeftTimeItemVisible { get; set; }

	// Token: 0x17001651 RID: 5713
	// (get) Token: 0x060118F3 RID: 71923 RVA: 0x004D10F7 File Offset: 0x004CF2F7
	// (set) Token: 0x060118F4 RID: 71924 RVA: 0x004D10FF File Offset: 0x004CF2FF
	public bool LeftTimeTextVisible { get; set; }

	// Token: 0x17001652 RID: 5714
	// (get) Token: 0x060118F5 RID: 71925 RVA: 0x004D1108 File Offset: 0x004CF308
	// (set) Token: 0x060118F6 RID: 71926 RVA: 0x004D1110 File Offset: 0x004CF310
	public GameplayShopTextData LeftTimeDescTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001653 RID: 5715
	// (get) Token: 0x060118F7 RID: 71927 RVA: 0x004D1119 File Offset: 0x004CF319
	// (set) Token: 0x060118F8 RID: 71928 RVA: 0x004D1121 File Offset: 0x004CF321
	public GameplayShopTextData LeftTimeTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001654 RID: 5716
	// (get) Token: 0x060118F9 RID: 71929 RVA: 0x004D112A File Offset: 0x004CF32A
	// (set) Token: 0x060118FA RID: 71930 RVA: 0x004D1132 File Offset: 0x004CF332
	public bool LimitTextItemVisible { get; set; }

	// Token: 0x17001655 RID: 5717
	// (get) Token: 0x060118FB RID: 71931 RVA: 0x004D113B File Offset: 0x004CF33B
	// (set) Token: 0x060118FC RID: 71932 RVA: 0x004D1143 File Offset: 0x004CF343
	public GameplayShopTextData LimitTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001656 RID: 5718
	// (get) Token: 0x060118FD RID: 71933 RVA: 0x004D114C File Offset: 0x004CF34C
	// (set) Token: 0x060118FE RID: 71934 RVA: 0x004D1154 File Offset: 0x004CF354
	public bool LockItemVisible { get; set; }

	// Token: 0x17001657 RID: 5719
	// (get) Token: 0x060118FF RID: 71935 RVA: 0x004D115D File Offset: 0x004CF35D
	// (set) Token: 0x06011900 RID: 71936 RVA: 0x004D1165 File Offset: 0x004CF365
	public GameplayShopTextData LockTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x17001658 RID: 5720
	// (get) Token: 0x06011901 RID: 71937 RVA: 0x004D116E File Offset: 0x004CF36E
	// (set) Token: 0x06011902 RID: 71938 RVA: 0x004D1176 File Offset: 0x004CF376
	public int ReSellTime { get; set; }

	// Token: 0x17001659 RID: 5721
	// (get) Token: 0x06011903 RID: 71939 RVA: 0x004D117F File Offset: 0x004CF37F
	// (set) Token: 0x06011904 RID: 71940 RVA: 0x004D1187 File Offset: 0x004CF387
	public int BuyCount { get; set; }

	// Token: 0x1700165A RID: 5722
	// (get) Token: 0x06011905 RID: 71941 RVA: 0x004D1190 File Offset: 0x004CF390
	// (set) Token: 0x06011906 RID: 71942 RVA: 0x004D1198 File Offset: 0x004CF398
	public int MaxBuyCount { get; set; }

	// Token: 0x1700165B RID: 5723
	// (get) Token: 0x06011907 RID: 71943 RVA: 0x004D11A1 File Offset: 0x004CF3A1
	// (set) Token: 0x06011908 RID: 71944 RVA: 0x004D11A9 File Offset: 0x004CF3A9
	public string ExchangeTableTextId { get; set; } = "";

	// Token: 0x1700165C RID: 5724
	// (get) Token: 0x06011909 RID: 71945 RVA: 0x004D11B2 File Offset: 0x004CF3B2
	// (set) Token: 0x0601190A RID: 71946 RVA: 0x004D11BA File Offset: 0x004CF3BA
	[Nullable(2)]
	public string CurrencyItemResourceId { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x1700165D RID: 5725
	// (get) Token: 0x0601190B RID: 71947 RVA: 0x004D11C3 File Offset: 0x004CF3C3
	// (set) Token: 0x0601190C RID: 71948 RVA: 0x004D11CB File Offset: 0x004CF3CB
	public string ShopItemResource { get; set; } = "";

	// Token: 0x0601190D RID: 71949 RVA: 0x004D11D4 File Offset: 0x004CF3D4
	public virtual void OnConfirmButtonClick(int viewId)
	{
	}

	// Token: 0x0601190E RID: 71950 RVA: 0x004D11D6 File Offset: 0x004CF3D6
	public virtual bool CheckConfirmButtonCanInteract()
	{
		return false;
	}

	// Token: 0x0601190F RID: 71951 RVA: 0x004D11D9 File Offset: 0x004CF3D9
	public virtual UiPanelBase ShopItemCreate()
	{
		return null;
	}

	// Token: 0x06011910 RID: 71952 RVA: 0x004D11DC File Offset: 0x004CF3DC
	public virtual void ShopItemRefresh()
	{
	}

	// Token: 0x06011911 RID: 71953 RVA: 0x004D11DE File Offset: 0x004CF3DE
	public virtual bool CheckMoneyEnough()
	{
		return false;
	}

	// Token: 0x06011912 RID: 71954 RVA: 0x004D11E1 File Offset: 0x004CF3E1
	public virtual void OnResellTimeRefresh()
	{
	}
}
