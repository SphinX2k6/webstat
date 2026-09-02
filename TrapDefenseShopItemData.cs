using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x02002C13 RID: 11283
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseShopItemData : ITrapDefenseShopGoods
{
	// Token: 0x17001DA4 RID: 7588
	// (get) Token: 0x06016863 RID: 92259 RVA: 0x00641FEA File Offset: 0x006401EA
	// (set) Token: 0x06016864 RID: 92260 RVA: 0x00641FF2 File Offset: 0x006401F2
	public int Id { get; set; }

	// Token: 0x17001DA5 RID: 7589
	// (get) Token: 0x06016865 RID: 92261 RVA: 0x00641FFB File Offset: 0x006401FB
	// (set) Token: 0x06016866 RID: 92262 RVA: 0x00642003 File Offset: 0x00640203
	public int? OriginalPrice { get; set; }

	// Token: 0x17001DA6 RID: 7590
	// (get) Token: 0x06016867 RID: 92263 RVA: 0x0064200C File Offset: 0x0064020C
	// (set) Token: 0x06016868 RID: 92264 RVA: 0x00642014 File Offset: 0x00640214
	public int CurrentPrice { get; set; }

	// Token: 0x17001DA7 RID: 7591
	// (get) Token: 0x06016869 RID: 92265 RVA: 0x0064201D File Offset: 0x0064021D
	// (set) Token: 0x0601686A RID: 92266 RVA: 0x00642025 File Offset: 0x00640225
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] DescArgs { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17001DA8 RID: 7592
	// (get) Token: 0x0601686B RID: 92267 RVA: 0x0064202E File Offset: 0x0064022E
	// (set) Token: 0x0601686C RID: 92268 RVA: 0x00642036 File Offset: 0x00640236
	public ETrapDefenseShopGoodsType Type { get; set; }

	// Token: 0x17001DA9 RID: 7593
	// (get) Token: 0x0601686D RID: 92269 RVA: 0x0064203F File Offset: 0x0064023F
	// (set) Token: 0x0601686E RID: 92270 RVA: 0x00642047 File Offset: 0x00640247
	public int QualityId { get; set; } = 1;

	// Token: 0x17001DAA RID: 7594
	// (get) Token: 0x0601686F RID: 92271 RVA: 0x00642050 File Offset: 0x00640250
	// (set) Token: 0x06016870 RID: 92272 RVA: 0x00642058 File Offset: 0x00640258
	public string Name { get; set; }

	// Token: 0x17001DAB RID: 7595
	// (get) Token: 0x06016871 RID: 92273 RVA: 0x00642061 File Offset: 0x00640261
	// (set) Token: 0x06016872 RID: 92274 RVA: 0x00642069 File Offset: 0x00640269
	public string Desc { get; set; }

	// Token: 0x17001DAC RID: 7596
	// (get) Token: 0x06016873 RID: 92275 RVA: 0x00642072 File Offset: 0x00640272
	// (set) Token: 0x06016874 RID: 92276 RVA: 0x0064207A File Offset: 0x0064027A
	public string Icon { get; set; }

	// Token: 0x17001DAD RID: 7597
	// (get) Token: 0x06016875 RID: 92277 RVA: 0x00642084 File Offset: 0x00640284
	public int CanPurchaseNum
	{
		get
		{
			int val = (int)Math.Floor((double)((float)ModelBase<TrapDefenseModel>.Instance.BattleData.GetGoldNum() / (float)((this.CurrentPrice != 0) ? this.CurrentPrice : 1)));
			int val2 = this.BattleItemData.LimitCount - this.BattleItemData.InventoryCount;
			return Math.Min(Math.Min(val, val2), this.Stock);
		}
	}

	// Token: 0x17001DAE RID: 7598
	// (get) Token: 0x06016876 RID: 92278 RVA: 0x006420E4 File Offset: 0x006402E4
	public bool InventoryCountReachLimit
	{
		get
		{
			return this.BattleItemData.InventoryCount >= this.BattleItemData.LimitCount;
		}
	}

	// Token: 0x17001DAF RID: 7599
	// (get) Token: 0x06016877 RID: 92279 RVA: 0x00642101 File Offset: 0x00640301
	public bool Disable
	{
		get
		{
			return this.InventoryCountReachLimit || this.Stock <= 0;
		}
	}

	// Token: 0x17001DB0 RID: 7600
	// (get) Token: 0x06016878 RID: 92280 RVA: 0x00642119 File Offset: 0x00640319
	public ETrapDefenseShopGoodsUnavailableReason DisableReason
	{
		get
		{
			if (this.InventoryCountReachLimit)
			{
				return ETrapDefenseShopGoodsUnavailableReason.InventoryCountReachLimit;
			}
			if (this.Stock <= 0)
			{
				return ETrapDefenseShopGoodsUnavailableReason.SoldOut;
			}
			return ETrapDefenseShopGoodsUnavailableReason.None;
		}
	}

	// Token: 0x17001DB1 RID: 7601
	// (get) Token: 0x06016879 RID: 92281 RVA: 0x00642131 File Offset: 0x00640331
	// (set) Token: 0x0601687A RID: 92282 RVA: 0x00642139 File Offset: 0x00640339
	public Func<PropMediumItemGrid> GetItemGridParam { get; set; }

	// Token: 0x0601687B RID: 92283 RVA: 0x00642142 File Offset: 0x00640342
	public static TrapDefenseShopItemData Create(TrapDefenseShopProductPbInfo serverData)
	{
		TrapDefenseShopItemData trapDefenseShopItemData = new TrapDefenseShopItemData();
		trapDefenseShopItemData.Init(serverData);
		return trapDefenseShopItemData;
	}

	// Token: 0x0601687C RID: 92284 RVA: 0x00642150 File Offset: 0x00640350
	public void Update(TrapDefenseShopProductPbInfo serverData)
	{
		Dictionary<int, TrapDefenseBattleItemData> itemMap = ModelBase<TrapDefenseModel>.Instance.BattleInventoryData.ItemMap;
		TrapDefenseShopItemPbInfo itemPbInfo = serverData.ItemPbInfo;
		TrapDefenseBattleItemData battleItemData;
		if (!itemMap.TryGetValue((itemPbInfo != null) ? itemPbInfo.ItemConfigId : 0, out battleItemData))
		{
			this.BattleItemData = null;
			return;
		}
		this.BattleItemData = battleItemData;
		this.Config = this.BattleItemData.Config;
		this.Id = this.Config.Id;
		this.Name = this.Config.Name;
		this.Desc = this.Config.Desc;
		this.Icon = this.Config.Icon;
		this.QualityId = this.Config.Quality;
		this.OriginalPrice = new int?(serverData.OriginalPrice);
		this.CurrentPrice = serverData.DiscountPrice;
		TrapDefenseShopItemPbInfo itemPbInfo2 = serverData.ItemPbInfo;
		this.Stock = ((itemPbInfo2 != null) ? itemPbInfo2.StockCount : 0);
	}

	// Token: 0x0601687D RID: 92285 RVA: 0x00642234 File Offset: 0x00640434
	private PropMediumItemGrid BuildItemGridParam()
	{
		return new PropMediumItemGrid
		{
			ItemPrice = new MediumItemPrice
			{
				CurPrice = this.CurrentPrice,
				OriginalPrice = this.OriginalPrice
			},
			IconPath = this.Icon,
			QualityId = new int?(this.QualityId),
			IsDisable = new bool?(this.Disable)
		};
	}

	// Token: 0x0601687E RID: 92286 RVA: 0x00642297 File Offset: 0x00640497
	private void Init(TrapDefenseShopProductPbInfo serverData)
	{
		this.GetItemGridParam = new Func<PropMediumItemGrid>(this.BuildItemGridParam);
		this.Update(serverData);
	}

	// Token: 0x0400AE36 RID: 44598
	public TrapDefenseItem Config;

	// Token: 0x0400AE3F RID: 44607
	public int PurchaseLimit;

	// Token: 0x0400AE40 RID: 44608
	public int Stock;

	// Token: 0x0400AE41 RID: 44609
	[Nullable(2)]
	public TrapDefenseBattleItemData BattleItemData;
}
