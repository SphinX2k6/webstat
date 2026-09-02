using System;
using System.Runtime.CompilerServices;

// Token: 0x02002391 RID: 9105
[NullableContext(1)]
[Nullable(0)]
public abstract class AbstractGameplayShopBaseItemProxy : IGameplayShopItemBaseProxy
{
	// Token: 0x1700159F RID: 5535
	// (get) Token: 0x0601172D RID: 71469 RVA: 0x004CF1BA File Offset: 0x004CD3BA
	// (set) Token: 0x0601172E RID: 71470 RVA: 0x004CF1C2 File Offset: 0x004CD3C2
	public int CurrencyId { get; set; }

	// Token: 0x170015A0 RID: 5536
	// (get) Token: 0x0601172F RID: 71471 RVA: 0x004CF1CB File Offset: 0x004CD3CB
	// (set) Token: 0x06011730 RID: 71472 RVA: 0x004CF1D3 File Offset: 0x004CD3D3
	public int ItemId { get; set; }

	// Token: 0x170015A1 RID: 5537
	// (get) Token: 0x06011731 RID: 71473 RVA: 0x004CF1DC File Offset: 0x004CD3DC
	// (set) Token: 0x06011732 RID: 71474 RVA: 0x004CF1E4 File Offset: 0x004CD3E4
	public string QualitySpritePath { get; set; } = "";

	// Token: 0x170015A2 RID: 5538
	// (get) Token: 0x06011733 RID: 71475 RVA: 0x004CF1ED File Offset: 0x004CD3ED
	// (set) Token: 0x06011734 RID: 71476 RVA: 0x004CF1F5 File Offset: 0x004CD3F5
	public string ItemTexturePath { get; set; } = "";

	// Token: 0x170015A3 RID: 5539
	// (get) Token: 0x06011735 RID: 71477 RVA: 0x004CF1FE File Offset: 0x004CD3FE
	// (set) Token: 0x06011736 RID: 71478 RVA: 0x004CF206 File Offset: 0x004CD406
	public bool ItemTextureVisible { get; set; } = true;

	// Token: 0x170015A4 RID: 5540
	// (get) Token: 0x06011737 RID: 71479 RVA: 0x004CF20F File Offset: 0x004CD40F
	// (set) Token: 0x06011738 RID: 71480 RVA: 0x004CF217 File Offset: 0x004CD417
	public virtual string BigItemIconTexturePath { get; set; } = "";

	// Token: 0x170015A5 RID: 5541
	// (get) Token: 0x06011739 RID: 71481 RVA: 0x004CF220 File Offset: 0x004CD420
	// (set) Token: 0x0601173A RID: 71482 RVA: 0x004CF228 File Offset: 0x004CD428
	public virtual bool BigItemIconVisible { get; set; }

	// Token: 0x170015A6 RID: 5542
	// (get) Token: 0x0601173B RID: 71483 RVA: 0x004CF231 File Offset: 0x004CD431
	// (set) Token: 0x0601173C RID: 71484 RVA: 0x004CF239 File Offset: 0x004CD439
	public GameplayShopTextData ItemNameTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015A7 RID: 5543
	// (get) Token: 0x0601173D RID: 71485 RVA: 0x004CF242 File Offset: 0x004CD442
	// (set) Token: 0x0601173E RID: 71486 RVA: 0x004CF24A File Offset: 0x004CD44A
	public bool TipsButtonVisible { get; set; }

	// Token: 0x170015A8 RID: 5544
	// (get) Token: 0x0601173F RID: 71487 RVA: 0x004CF253 File Offset: 0x004CD453
	// (set) Token: 0x06011740 RID: 71488 RVA: 0x004CF25B File Offset: 0x004CD45B
	public bool BottomBgVisible { get; set; } = true;

	// Token: 0x170015A9 RID: 5545
	// (get) Token: 0x06011741 RID: 71489 RVA: 0x004CF264 File Offset: 0x004CD464
	// (set) Token: 0x06011742 RID: 71490 RVA: 0x004CF26C File Offset: 0x004CD46C
	public GameplayShopTextData BuyLimitCountTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015AA RID: 5546
	// (get) Token: 0x06011743 RID: 71491 RVA: 0x004CF275 File Offset: 0x004CD475
	// (set) Token: 0x06011744 RID: 71492 RVA: 0x004CF27D File Offset: 0x004CD47D
	public bool BuyLimitCountTextVisible { get; set; }

	// Token: 0x170015AB RID: 5547
	// (get) Token: 0x06011745 RID: 71493 RVA: 0x004CF286 File Offset: 0x004CD486
	// (set) Token: 0x06011746 RID: 71494 RVA: 0x004CF28E File Offset: 0x004CD48E
	public bool PriceItemVisible { get; set; } = true;

	// Token: 0x170015AC RID: 5548
	// (get) Token: 0x06011747 RID: 71495 RVA: 0x004CF297 File Offset: 0x004CD497
	// (set) Token: 0x06011748 RID: 71496 RVA: 0x004CF29F File Offset: 0x004CD49F
	public bool CurrencyIconVisible { get; set; } = true;

	// Token: 0x170015AD RID: 5549
	// (get) Token: 0x06011749 RID: 71497 RVA: 0x004CF2A8 File Offset: 0x004CD4A8
	// (set) Token: 0x0601174A RID: 71498 RVA: 0x004CF2B0 File Offset: 0x004CD4B0
	public GameplayShopTextData NowPriceTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015AE RID: 5550
	// (get) Token: 0x0601174B RID: 71499 RVA: 0x004CF2B9 File Offset: 0x004CD4B9
	// (set) Token: 0x0601174C RID: 71500 RVA: 0x004CF2C1 File Offset: 0x004CD4C1
	public string NowPriceTextColor { get; set; } = "000000FF";

	// Token: 0x170015AF RID: 5551
	// (get) Token: 0x0601174D RID: 71501 RVA: 0x004CF2CA File Offset: 0x004CD4CA
	// (set) Token: 0x0601174E RID: 71502 RVA: 0x004CF2D2 File Offset: 0x004CD4D2
	public GameplayShopTextData OriginalPriceTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015B0 RID: 5552
	// (get) Token: 0x0601174F RID: 71503 RVA: 0x004CF2DB File Offset: 0x004CD4DB
	// (set) Token: 0x06011750 RID: 71504 RVA: 0x004CF2E3 File Offset: 0x004CD4E3
	public bool OriginalPriceVisible { get; set; }

	// Token: 0x170015B1 RID: 5553
	// (get) Token: 0x06011751 RID: 71505 RVA: 0x004CF2EC File Offset: 0x004CD4EC
	// (set) Token: 0x06011752 RID: 71506 RVA: 0x004CF2F4 File Offset: 0x004CD4F4
	public GameplayShopTextData PriceTipsTextData { get; set; } = new GameplayShopTextData();

	// Token: 0x170015B2 RID: 5554
	// (get) Token: 0x06011753 RID: 71507 RVA: 0x004CF2FD File Offset: 0x004CD4FD
	// (set) Token: 0x06011754 RID: 71508 RVA: 0x004CF305 File Offset: 0x004CD505
	public bool PriceTipsTextVisible { get; set; }

	// Token: 0x170015B3 RID: 5555
	// (get) Token: 0x06011755 RID: 71509 RVA: 0x004CF30E File Offset: 0x004CD50E
	// (set) Token: 0x06011756 RID: 71510 RVA: 0x004CF316 File Offset: 0x004CD516
	public bool RedDotVisible { get; set; }

	// Token: 0x170015B4 RID: 5556
	// (get) Token: 0x06011757 RID: 71511 RVA: 0x004CF31F File Offset: 0x004CD51F
	// (set) Token: 0x06011758 RID: 71512 RVA: 0x004CF327 File Offset: 0x004CD527
	public virtual bool ItemBgItemVisible { get; set; } = true;

	// Token: 0x170015B5 RID: 5557
	// (get) Token: 0x06011759 RID: 71513 RVA: 0x004CF330 File Offset: 0x004CD530
	// (set) Token: 0x0601175A RID: 71514 RVA: 0x004CF338 File Offset: 0x004CD538
	public bool RaycastTarget { get; set; } = true;

	// Token: 0x0601175B RID: 71515 RVA: 0x004CF341 File Offset: 0x004CD541
	public virtual void OnTipsButtonClick()
	{
	}
}
