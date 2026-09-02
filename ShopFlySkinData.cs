using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A2B RID: 10795
[NullableContext(1)]
[Nullable(0)]
public class ShopFlySkinData
{
	// Token: 0x06015903 RID: 88323 RVA: 0x005F99EB File Offset: 0x005F7BEB
	public static ShopFlySkinData Create(PayShopGoods data)
	{
		ShopFlySkinData shopFlySkinData = new ShopFlySkinData();
		shopFlySkinData.InitData(data);
		return shopFlySkinData;
	}

	// Token: 0x06015904 RID: 88324 RVA: 0x005F99FC File Offset: 0x005F7BFC
	public void InitData(PayShopGoods data)
	{
		this.PayShopGoods = data;
		this.OtherRewardMap.Clear();
		GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(data.GetPackageRewardId());
		if (giftPackageConfig != null)
		{
			Dictionary<int, int> dictionary = giftPackageConfig.Value.Content();
			int count = dictionary.Count;
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int key = keyValuePair.Key;
				if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(key)) == InventoryDefine.EItemDataType.FlySkinItem)
				{
					FlySkinConfig? flySkinConfig = ConfigBase<SkinConfig>.Instance.GetFlySkinConfig(key);
					if (flySkinConfig != null)
					{
						if (flySkinConfig.Value.SkinType == 0)
						{
							this.SoarWingSkinId = new int?(key);
						}
						else
						{
							this.ParaglidingSkinId = new int?(key);
						}
					}
				}
				else
				{
					this.OtherRewardMap.Add(key, keyValuePair.Value);
				}
			}
		}
	}

	// Token: 0x06015905 RID: 88325 RVA: 0x005F9B08 File Offset: 0x005F7D08
	public bool GetIfCanBuy()
	{
		if (!this.GetPayShopGoods().IfCanBuy())
		{
			return false;
		}
		if (this.GetPayShopGoods().GetGoodsData() != null && this.GetPayShopGoods().GetGoodsData().HasBuyLimit())
		{
			PayShopGoodsData goodsData = this.GetPayShopGoods().GetGoodsData();
			if (goodsData != null && goodsData.GetRemainingCount() == 0)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06015906 RID: 88326 RVA: 0x005F9B62 File Offset: 0x005F7D62
	public PayShopGoods GetCurrentGoodsData()
	{
		return this.PayShopGoods;
	}

	// Token: 0x06015907 RID: 88327 RVA: 0x005F9B6A File Offset: 0x005F7D6A
	public int GetItemId()
	{
		return this.SoarWingSkinId.Value;
	}

	// Token: 0x06015908 RID: 88328 RVA: 0x005F9B77 File Offset: 0x005F7D77
	public int GetSoarWingSkinId()
	{
		return this.SoarWingSkinId.Value;
	}

	// Token: 0x06015909 RID: 88329 RVA: 0x005F9B84 File Offset: 0x005F7D84
	public int GetParaglidingSkinId()
	{
		return this.ParaglidingSkinId.Value;
	}

	// Token: 0x0601590A RID: 88330 RVA: 0x005F9B94 File Offset: 0x005F7D94
	public List<TItem> GetAllReward()
	{
		List<TItem> list = new List<TItem>();
		InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(this.GetSoarWingSkinId(), 0);
		TItem item = new TItem(itemData, 1);
		list.Add(item);
		itemData = new InventoryDefine.GetItemData(this.GetParaglidingSkinId(), 0);
		item = new TItem(itemData, 1);
		list.Add(item);
		list.AddRange(this.GetOtherReward());
		return list;
	}

	// Token: 0x0601590B RID: 88331 RVA: 0x005F9BEC File Offset: 0x005F7DEC
	public List<TItem> GetOtherReward()
	{
		List<TItem> list = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in this.OtherRewardMap)
		{
			InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(keyValuePair.Key, 0);
			TItem item = new TItem(itemData, keyValuePair.Value);
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0601590C RID: 88332 RVA: 0x005F9C64 File Offset: 0x005F7E64
	public PayShopGoods GetPayShopGoods()
	{
		return this.PayShopGoods;
	}

	// Token: 0x0601590D RID: 88333 RVA: 0x005F9C6C File Offset: 0x005F7E6C
	public string GetDiscountText()
	{
		PayShopGoods currentGoodsData = this.GetCurrentGoodsData();
		if (!currentGoodsData.HasDiscount())
		{
			return "";
		}
		int discount = currentGoodsData.GetDiscount();
		if (discount > 0)
		{
			return StringUtils.Format("-{0}%", new string[]
			{
				discount.ToString()
			});
		}
		return "";
	}

	// Token: 0x0601590E RID: 88334 RVA: 0x005F9CBC File Offset: 0x005F7EBC
	[NullableContext(2)]
	public object GetDiscountTimeData()
	{
		PayShopGoods currentGoodsData = this.GetCurrentGoodsData();
		if (!currentGoodsData.HasDiscount())
		{
			return null;
		}
		ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double> countDownData = currentGoodsData.GetCountDownData();
		if (countDownData.Item1 == EPayCountTimeType.Discount)
		{
			return countDownData.Item2;
		}
		return null;
	}

	// Token: 0x0601590F RID: 88335 RVA: 0x005F9CF2 File Offset: 0x005F7EF2
	public IPriceData GetPriceData()
	{
		return this.GetCurrentGoodsData().GetPriceData();
	}

	// Token: 0x06015910 RID: 88336 RVA: 0x005F9CFF File Offset: 0x005F7EFF
	public bool GetIfDirect()
	{
		return this.GetCurrentGoodsData().IsDirect();
	}

	// Token: 0x06015911 RID: 88337 RVA: 0x005F9D0C File Offset: 0x005F7F0C
	public string GetDirectPriceText()
	{
		return this.GetCurrentGoodsData().GetDirectPriceText();
	}

	// Token: 0x06015912 RID: 88338 RVA: 0x005F9D19 File Offset: 0x005F7F19
	public FlySkinData GetFlySkinData()
	{
		return ModelBase<FlySkinModel>.Instance.GetFlySkinData(this.GetItemId());
	}

	// Token: 0x06015913 RID: 88339 RVA: 0x005F9D2B File Offset: 0x005F7F2B
	public string GetPreviewTextureInPayShop()
	{
		return this.GetFlySkinData().GetPreviewTextureInPayShop();
	}

	// Token: 0x06015914 RID: 88340 RVA: 0x005F9D38 File Offset: 0x005F7F38
	public string GetPreviewTextureInPop()
	{
		return this.GetFlySkinData().GetPreviewTextureInPop();
	}

	// Token: 0x0400A5F4 RID: 42484
	[Nullable(2)]
	private PayShopGoods PayShopGoods;

	// Token: 0x0400A5F5 RID: 42485
	private int? SoarWingSkinId;

	// Token: 0x0400A5F6 RID: 42486
	private int? ParaglidingSkinId;

	// Token: 0x0400A5F7 RID: 42487
	private readonly Dictionary<int, int> OtherRewardMap = new Dictionary<int, int>();
}
