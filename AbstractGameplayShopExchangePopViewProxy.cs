using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02002392 RID: 9106
[NullableContext(1)]
[Nullable(0)]
public abstract class AbstractGameplayShopExchangePopViewProxy : IGameplayShopExchangePopViewProxy
{
	// Token: 0x170015B6 RID: 5558
	// (get) Token: 0x0601175D RID: 71517 RVA: 0x004CF3E4 File Offset: 0x004CD5E4
	// (set) Token: 0x0601175E RID: 71518 RVA: 0x004CF3EC File Offset: 0x004CD5EC
	[Nullable(2)]
	public object ShopItemProxy { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170015B7 RID: 5559
	// (get) Token: 0x0601175F RID: 71519 RVA: 0x004CF3F5 File Offset: 0x004CD5F5
	// (set) Token: 0x06011760 RID: 71520 RVA: 0x004CF3FD File Offset: 0x004CD5FD
	public int CurrencyId { get; set; }

	// Token: 0x170015B8 RID: 5560
	// (get) Token: 0x06011761 RID: 71521 RVA: 0x004CF406 File Offset: 0x004CD606
	// (set) Token: 0x06011762 RID: 71522 RVA: 0x004CF40E File Offset: 0x004CD60E
	public List<int> CurrencyIdList { get; set; } = new List<int>();

	// Token: 0x170015B9 RID: 5561
	// (get) Token: 0x06011763 RID: 71523 RVA: 0x004CF417 File Offset: 0x004CD617
	// (set) Token: 0x06011764 RID: 71524 RVA: 0x004CF41F File Offset: 0x004CD61F
	public int Price { get; set; }

	// Token: 0x170015BA RID: 5562
	// (get) Token: 0x06011765 RID: 71525 RVA: 0x004CF428 File Offset: 0x004CD628
	// (set) Token: 0x06011766 RID: 71526 RVA: 0x004CF430 File Offset: 0x004CD630
	public GameplayShopTextData DescribeTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015BB RID: 5563
	// (get) Token: 0x06011767 RID: 71527 RVA: 0x004CF439 File Offset: 0x004CD639
	// (set) Token: 0x06011768 RID: 71528 RVA: 0x004CF441 File Offset: 0x004CD641
	public bool TipTitleItemVisible { get; set; }

	// Token: 0x170015BC RID: 5564
	// (get) Token: 0x06011769 RID: 71529 RVA: 0x004CF44A File Offset: 0x004CD64A
	// (set) Token: 0x0601176A RID: 71530 RVA: 0x004CF452 File Offset: 0x004CD652
	public bool LeftTimeItemVisible { get; set; }

	// Token: 0x170015BD RID: 5565
	// (get) Token: 0x0601176B RID: 71531 RVA: 0x004CF45B File Offset: 0x004CD65B
	// (set) Token: 0x0601176C RID: 71532 RVA: 0x004CF463 File Offset: 0x004CD663
	public bool LeftTimeTextVisible { get; set; }

	// Token: 0x170015BE RID: 5566
	// (get) Token: 0x0601176D RID: 71533 RVA: 0x004CF46C File Offset: 0x004CD66C
	// (set) Token: 0x0601176E RID: 71534 RVA: 0x004CF474 File Offset: 0x004CD674
	public GameplayShopTextData LeftTimeDescTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015BF RID: 5567
	// (get) Token: 0x0601176F RID: 71535 RVA: 0x004CF47D File Offset: 0x004CD67D
	// (set) Token: 0x06011770 RID: 71536 RVA: 0x004CF485 File Offset: 0x004CD685
	public GameplayShopTextData LeftTimeTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015C0 RID: 5568
	// (get) Token: 0x06011771 RID: 71537 RVA: 0x004CF48E File Offset: 0x004CD68E
	// (set) Token: 0x06011772 RID: 71538 RVA: 0x004CF496 File Offset: 0x004CD696
	public bool LimitTextItemVisible { get; set; }

	// Token: 0x170015C1 RID: 5569
	// (get) Token: 0x06011773 RID: 71539 RVA: 0x004CF49F File Offset: 0x004CD69F
	// (set) Token: 0x06011774 RID: 71540 RVA: 0x004CF4A7 File Offset: 0x004CD6A7
	public GameplayShopTextData LimitTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015C2 RID: 5570
	// (get) Token: 0x06011775 RID: 71541 RVA: 0x004CF4B0 File Offset: 0x004CD6B0
	// (set) Token: 0x06011776 RID: 71542 RVA: 0x004CF4B8 File Offset: 0x004CD6B8
	public bool LockItemVisible { get; set; }

	// Token: 0x170015C3 RID: 5571
	// (get) Token: 0x06011777 RID: 71543 RVA: 0x004CF4C1 File Offset: 0x004CD6C1
	// (set) Token: 0x06011778 RID: 71544 RVA: 0x004CF4C9 File Offset: 0x004CD6C9
	public GameplayShopTextData LockTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015C4 RID: 5572
	// (get) Token: 0x06011779 RID: 71545 RVA: 0x004CF4D2 File Offset: 0x004CD6D2
	// (set) Token: 0x0601177A RID: 71546 RVA: 0x004CF4DA File Offset: 0x004CD6DA
	public int ReSellTime { get; set; }

	// Token: 0x170015C5 RID: 5573
	// (get) Token: 0x0601177B RID: 71547 RVA: 0x004CF4E3 File Offset: 0x004CD6E3
	// (set) Token: 0x0601177C RID: 71548 RVA: 0x004CF4EB File Offset: 0x004CD6EB
	public int BuyCount { get; set; } = 1;

	// Token: 0x170015C6 RID: 5574
	// (get) Token: 0x0601177D RID: 71549 RVA: 0x004CF4F4 File Offset: 0x004CD6F4
	// (set) Token: 0x0601177E RID: 71550 RVA: 0x004CF4FC File Offset: 0x004CD6FC
	public int MaxBuyCount { get; set; }

	// Token: 0x170015C7 RID: 5575
	// (get) Token: 0x0601177F RID: 71551 RVA: 0x004CF505 File Offset: 0x004CD705
	// (set) Token: 0x06011780 RID: 71552 RVA: 0x004CF50D File Offset: 0x004CD70D
	public string ExchangeTableTextId { get; set; } = "";

	// Token: 0x170015C8 RID: 5576
	// (get) Token: 0x06011781 RID: 71553 RVA: 0x004CF516 File Offset: 0x004CD716
	// (set) Token: 0x06011782 RID: 71554 RVA: 0x004CF51E File Offset: 0x004CD71E
	public string ShopItemResource { get; set; } = "";

	// Token: 0x170015C9 RID: 5577
	// (get) Token: 0x06011783 RID: 71555 RVA: 0x004CF527 File Offset: 0x004CD727
	// (set) Token: 0x06011784 RID: 71556 RVA: 0x004CF52F File Offset: 0x004CD72F
	[Nullable(2)]
	public string CurrencyItemResourceId { [NullableContext(2)] get; [NullableContext(2)] set; } = "";

	// Token: 0x06011785 RID: 71557
	public abstract void OnConfirmButtonClick(int viewId);

	// Token: 0x06011786 RID: 71558
	public abstract bool CheckConfirmButtonCanInteract();

	// Token: 0x06011787 RID: 71559
	public abstract UiPanelBase ShopItemCreate();

	// Token: 0x06011788 RID: 71560
	public abstract void ShopItemRefresh();

	// Token: 0x06011789 RID: 71561
	public abstract bool CheckMoneyEnough();

	// Token: 0x0601178A RID: 71562
	public abstract void OnResellTimeRefresh();
}
