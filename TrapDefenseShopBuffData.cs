using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x02002C14 RID: 11284
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseShopBuffData : ITrapDefenseShopGoods
{
	// Token: 0x17001DB2 RID: 7602
	// (get) Token: 0x06016880 RID: 92288 RVA: 0x006422C1 File Offset: 0x006404C1
	// (set) Token: 0x06016881 RID: 92289 RVA: 0x006422C9 File Offset: 0x006404C9
	public int Id { get; set; }

	// Token: 0x17001DB3 RID: 7603
	// (get) Token: 0x06016882 RID: 92290 RVA: 0x006422D2 File Offset: 0x006404D2
	// (set) Token: 0x06016883 RID: 92291 RVA: 0x006422DA File Offset: 0x006404DA
	public int? OriginalPrice { get; set; }

	// Token: 0x17001DB4 RID: 7604
	// (get) Token: 0x06016884 RID: 92292 RVA: 0x006422E3 File Offset: 0x006404E3
	// (set) Token: 0x06016885 RID: 92293 RVA: 0x006422EB File Offset: 0x006404EB
	public int CurrentPrice { get; set; }

	// Token: 0x17001DB5 RID: 7605
	// (get) Token: 0x06016886 RID: 92294 RVA: 0x006422F4 File Offset: 0x006404F4
	// (set) Token: 0x06016887 RID: 92295 RVA: 0x006422FC File Offset: 0x006404FC
	public ETrapDefenseShopGoodsType Type { get; set; } = ETrapDefenseShopGoodsType.Buff;

	// Token: 0x17001DB6 RID: 7606
	// (get) Token: 0x06016888 RID: 92296 RVA: 0x00642305 File Offset: 0x00640505
	// (set) Token: 0x06016889 RID: 92297 RVA: 0x0064230D File Offset: 0x0064050D
	public int QualityId { get; set; } = 1;

	// Token: 0x17001DB7 RID: 7607
	// (get) Token: 0x0601688A RID: 92298 RVA: 0x00642316 File Offset: 0x00640516
	// (set) Token: 0x0601688B RID: 92299 RVA: 0x0064231E File Offset: 0x0064051E
	public string Name { get; set; }

	// Token: 0x17001DB8 RID: 7608
	// (get) Token: 0x0601688C RID: 92300 RVA: 0x00642327 File Offset: 0x00640527
	// (set) Token: 0x0601688D RID: 92301 RVA: 0x0064232F File Offset: 0x0064052F
	public string Desc { get; set; }

	// Token: 0x17001DB9 RID: 7609
	// (get) Token: 0x0601688E RID: 92302 RVA: 0x00642338 File Offset: 0x00640538
	// (set) Token: 0x0601688F RID: 92303 RVA: 0x00642340 File Offset: 0x00640540
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

	// Token: 0x17001DBA RID: 7610
	// (get) Token: 0x06016890 RID: 92304 RVA: 0x00642349 File Offset: 0x00640549
	// (set) Token: 0x06016891 RID: 92305 RVA: 0x00642351 File Offset: 0x00640551
	public string Icon { get; set; }

	// Token: 0x17001DBB RID: 7611
	// (get) Token: 0x06016892 RID: 92306 RVA: 0x0064235A File Offset: 0x0064055A
	// (set) Token: 0x06016893 RID: 92307 RVA: 0x00642362 File Offset: 0x00640562
	public int CanPurchaseNum { get; set; }

	// Token: 0x17001DBC RID: 7612
	// (get) Token: 0x06016894 RID: 92308 RVA: 0x0064236B File Offset: 0x0064056B
	public bool Disable
	{
		get
		{
			return this.IsSold;
		}
	}

	// Token: 0x17001DBD RID: 7613
	// (get) Token: 0x06016895 RID: 92309 RVA: 0x00642373 File Offset: 0x00640573
	public ETrapDefenseShopGoodsUnavailableReason DisableReason
	{
		get
		{
			if (this.IsSold)
			{
				return ETrapDefenseShopGoodsUnavailableReason.SoldOut;
			}
			return ETrapDefenseShopGoodsUnavailableReason.None;
		}
	}

	// Token: 0x17001DBE RID: 7614
	// (get) Token: 0x06016896 RID: 92310 RVA: 0x00642380 File Offset: 0x00640580
	// (set) Token: 0x06016897 RID: 92311 RVA: 0x00642388 File Offset: 0x00640588
	public Func<PropMediumItemGrid> GetItemGridParam { get; set; }

	// Token: 0x06016898 RID: 92312 RVA: 0x00642391 File Offset: 0x00640591
	public static TrapDefenseShopBuffData Create(TrapDefenseShopProductPbInfo serverData)
	{
		TrapDefenseShopBuffData trapDefenseShopBuffData = new TrapDefenseShopBuffData();
		trapDefenseShopBuffData.Init(serverData);
		return trapDefenseShopBuffData;
	}

	// Token: 0x06016899 RID: 92313 RVA: 0x006423A0 File Offset: 0x006405A0
	public void Update(TrapDefenseShopProductPbInfo serverData)
	{
		TrapDefenseShopBdGroupPbInfo bdGroupPbInfo = serverData.BdGroupPbInfo;
		this.Id = ((bdGroupPbInfo != null) ? bdGroupPbInfo.BdGrougConfigId : 0);
		TrapDefenseRougeModeData rougeModeData = ModelBase<TrapDefenseModel>.Instance.RougeModeData;
		TrapDefenseBdBuffData bdBuffData;
		if (rougeModeData != null && rougeModeData.BdBuffDataMap.TryGetValue(this.Id, out bdBuffData))
		{
			this.BdBuffData = bdBuffData;
		}
		else
		{
			this.BdBuffData = null;
		}
		if (this.BdBuffData == null)
		{
			return;
		}
		if (this.BdBuffData.IsActive && this.BdBuffData.Level < this.BdBuffData.MaxLevel)
		{
			this.Config = (ConfigBase<TrapDefenseConfig>.Instance.GetBdBuffByLevelAndGroup(this.BdBuffData.Level + 1, this.BdBuffData.Config.Id) ?? this.BdBuffData.BdBuffConfig);
		}
		else
		{
			this.Config = this.BdBuffData.BdBuffConfig;
		}
		this.Name = this.Config.Name;
		this.Desc = this.Config.Desc;
		this.DescArgs = this.Config.DescArgs();
		this.Icon = this.Config.Icon;
		this.QualityId = this.BdBuffData.Config.Quality;
		this.OriginalPrice = new int?(serverData.OriginalPrice);
		this.CurrentPrice = serverData.DiscountPrice;
		TrapDefenseShopBdGroupPbInfo bdGroupPbInfo2 = serverData.BdGroupPbInfo;
		this.IsSold = (bdGroupPbInfo2 != null && bdGroupPbInfo2.IsSold);
	}

	// Token: 0x0601689A RID: 92314 RVA: 0x00642514 File Offset: 0x00640714
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
			IsDisable = new bool?(this.Disable),
			SubIconPath = this.Config.SubIcon
		};
	}

	// Token: 0x0601689B RID: 92315 RVA: 0x00642588 File Offset: 0x00640788
	private void Init(TrapDefenseShopProductPbInfo serverData)
	{
		this.GetItemGridParam = new Func<PropMediumItemGrid>(this.BuildItemGridParam);
		this.Update(serverData);
	}

	// Token: 0x0400AE44 RID: 44612
	public TrapDefenseBdBuff Config;

	// Token: 0x0400AE4D RID: 44621
	public int PurchaseLimit;

	// Token: 0x0400AE4F RID: 44623
	[Nullable(2)]
	public TrapDefenseBdBuffData BdBuffData;

	// Token: 0x0400AE50 RID: 44624
	public bool IsSold;
}
