using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Launcher.Platform.PlatformSdk;

// Token: 0x02002371 RID: 9073
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PayItemData : PayShopUnionData<PayItemData>
{
	// Token: 0x060115C5 RID: 71109 RVA: 0x004C851C File Offset: 0x004C671C
	public PayItemData()
	{
		this.CachePayShopItemBaseSt = null;
		this.PayId = 0;
		this.Amount = "";
		this.ProductId = "";
		this.PayItemId = 0;
		this.ItemId = 0;
		this.ItemCount = 0;
		this.BonusItemCount = 0;
		this.SpecialBonusItemCount = 0;
		this.CanSpecialBonus = false;
		this.StageImage = "";
		this.DisclaimerText = "";
	}

	// Token: 0x060115C6 RID: 71110 RVA: 0x004C8594 File Offset: 0x004C6794
	public void Phrase(PayItemInfo payItem)
	{
		this.PayId = payItem.PayId;
		this.Amount = payItem.Amount;
		this.ProductId = payItem.ProductId;
		this.PayItemId = payItem.Id;
		this.ItemId = payItem.ItemId;
		this.ItemCount = payItem.ItemCount;
		this.ShopItemQuality = payItem.Quality;
		this.BonusItemCount = payItem.BonusItemCount;
		this.SpecialBonusItemCount = payItem.SpecialBonusItemCount;
		this.StageImage = payItem.StageImage;
		ModelBase<RechargeModel>.Instance.SetRechargeInfo(this.PayId, this.Amount.ToString(), this.ProductId);
		this.CanSpecialBonus = payItem.CanSpecialBonus;
		this.DisclaimerText = payItem.ComplianceDetail;
		this.CachePayShopItemBaseSt = new PayShopItemBaseSt();
		this.CachePayShopItemBaseSt.PhrasePromPayItemData(this);
	}

	// Token: 0x060115C7 RID: 71111 RVA: 0x004C8669 File Offset: 0x004C6869
	[NullableContext(2)]
	public PayShopItemBaseSt ConvertPayItemDataToPayShopItemBaseSt()
	{
		PayShopItemBaseSt cachePayShopItemBaseSt = this.CachePayShopItemBaseSt;
		if (cachePayShopItemBaseSt != null)
		{
			cachePayShopItemBaseSt.Refresh(this);
		}
		return this.CachePayShopItemBaseSt;
	}

	// Token: 0x060115C8 RID: 71112 RVA: 0x004C8684 File Offset: 0x004C6884
	public string GetPayItemShowName()
	{
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ItemId).Name, null);
		return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("GoodsName"), null), new string[]
		{
			localTextNew,
			this.ItemCount.ToString()
		});
	}

	// Token: 0x060115C9 RID: 71113 RVA: 0x004C86E0 File Offset: 0x004C68E0
	public string GetDirectPriceText()
	{
		KuroSdkModel instance = ModelBase<KuroSdkModel>.Instance;
		string text = (instance != null) ? instance.GetQueryProductShowPrice(this.PayId.ToString()) : null;
		if (text != null)
		{
			return text;
		}
		return ConfigBase<PayItemConfig>.Instance.GetPayShow(this.PayId);
	}

	// Token: 0x060115CA RID: 71114 RVA: 0x004C8720 File Offset: 0x004C6920
	public bool GetIfCanShow()
	{
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		return !((platformSdk != null) ? new bool?(platformSdk.NeedConfirmSdkProductInfo()) : null).GetValueOrDefault() || ModelBase<PayItemModel>.Instance.GetProductInfoByGoodsId(this.ProductId) != null;
	}

	// Token: 0x060115CB RID: 71115 RVA: 0x004C8770 File Offset: 0x004C6970
	public double GetGachaAverageCount()
	{
		int rechargeItemRate = ConfigBase<PayItemConfig>.Instance.GetRechargeItemRate();
		if (rechargeItemRate <= 0)
		{
			return 0.0;
		}
		return Math.Floor((double)(this.GetRewardItemCount() / (float)rechargeItemRate * 10f)) / 10.0;
	}

	// Token: 0x060115CC RID: 71116 RVA: 0x004C87B8 File Offset: 0x004C69B8
	public string GetGachaAveragePriceText()
	{
		double num = Math.Floor((double)(ConfigBase<PayItemConfig>.Instance.GetPayConf(this.PayId).Value.Amount * 10000f)) / 10000.0;
		int rechargeItemRate = ConfigBase<PayItemConfig>.Instance.GetRechargeItemRate();
		double value = Math.Ceiling(num / (double)(this.GetRewardItemCount() / (float)rechargeItemRate) * 100.0) / 100.0;
		string regionMainCurrency = ConfigBase<PayItemConfig>.Instance.GetRegionMainCurrency();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
		defaultInterpolatedStringHandler.AppendFormatted<double>(value);
		defaultInterpolatedStringHandler.AppendFormatted(regionMainCurrency);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060115CD RID: 71117 RVA: 0x004C8857 File Offset: 0x004C6A57
	private float GetRewardItemCount()
	{
		if (this.CanSpecialBonus)
		{
			return (float)(this.ItemCount + this.SpecialBonusItemCount);
		}
		return (float)(this.ItemCount + this.BonusItemCount);
	}

	// Token: 0x060115CE RID: 71118 RVA: 0x004C887E File Offset: 0x004C6A7E
	public bool GetIfShowTotalTopUpScore()
	{
		return ControllerBase<TotalTopUpController>.Instance.GetRechargeItemScore(this.PayItemId) > 0;
	}

	// Token: 0x060115CF RID: 71119 RVA: 0x004C8894 File Offset: 0x004C6A94
	public int GetQuality()
	{
		if (this.ShopItemQuality > 0)
		{
			return this.ShopItemQuality;
		}
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ItemId);
		if (itemConfigData != null)
		{
			return itemConfigData.QualityId;
		}
		return 0;
	}

	// Token: 0x060115D0 RID: 71120 RVA: 0x004C88CD File Offset: 0x004C6ACD
	public EItemQualityType GetQualityType()
	{
		if (this.ShopItemQuality > 0)
		{
			return EItemQualityType.PayShop;
		}
		return EItemQualityType.Item;
	}

	// Token: 0x04008868 RID: 34920
	[Nullable(2)]
	private PayShopItemBaseSt CachePayShopItemBaseSt;

	// Token: 0x04008869 RID: 34921
	private int PayId;

	// Token: 0x0400886A RID: 34922
	public string Amount;

	// Token: 0x0400886B RID: 34923
	public string ProductId;

	// Token: 0x0400886C RID: 34924
	public int PayItemId;

	// Token: 0x0400886D RID: 34925
	public int ItemId;

	// Token: 0x0400886E RID: 34926
	public int ItemCount;

	// Token: 0x0400886F RID: 34927
	public int ShopItemQuality;

	// Token: 0x04008870 RID: 34928
	public int BonusItemCount;

	// Token: 0x04008871 RID: 34929
	public int SpecialBonusItemCount;

	// Token: 0x04008872 RID: 34930
	public bool CanSpecialBonus;

	// Token: 0x04008873 RID: 34931
	public string StageImage;

	// Token: 0x04008874 RID: 34932
	public string DisclaimerText;
}
