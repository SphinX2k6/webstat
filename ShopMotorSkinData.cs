using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A2C RID: 10796
[NullableContext(1)]
[Nullable(0)]
public class ShopMotorSkinData
{
	// Token: 0x06015916 RID: 88342 RVA: 0x005F9D58 File Offset: 0x005F7F58
	public static ShopMotorSkinData Create(PayShopGoods data)
	{
		ShopMotorSkinData shopMotorSkinData = new ShopMotorSkinData();
		shopMotorSkinData.InitData(data);
		return shopMotorSkinData;
	}

	// Token: 0x06015917 RID: 88343 RVA: 0x005F9D68 File Offset: 0x005F7F68
	public void InitData(PayShopGoods data)
	{
		this.PayShopGoods = data;
		this.MainRewardMap.Clear();
		GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(data.GetPackageRewardId());
		if (giftPackageConfig != null)
		{
			this.GiftPackageId = data.GetPackageRewardId();
			MotorSkinShow? motorSkinShowConfig = ConfigBase<SkinConfig>.Instance.GetMotorSkinShowConfig(this.GiftPackageId);
			if (motorSkinShowConfig != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in giftPackageConfig.Value.Content())
				{
					int key = keyValuePair.Key;
					if (key == motorSkinShowConfig.Value.FreeItem)
					{
						this.OtherReward = new global::ItemData
						{
							ItemId = key,
							Count = keyValuePair.Value
						};
					}
					else
					{
						this.MainRewardMap[key] = keyValuePair.Value;
					}
				}
			}
		}
	}

	// Token: 0x06015918 RID: 88344 RVA: 0x005F9E6C File Offset: 0x005F806C
	public bool GetIfCanBuy()
	{
		if (!this.GetPayShopGoods().IfCanBuy())
		{
			return false;
		}
		PayShopGoodsData goodsData = this.GetPayShopGoods().GetGoodsData();
		if (goodsData != null && goodsData.HasBuyLimit())
		{
			PayShopGoodsData goodsData2 = this.GetPayShopGoods().GetGoodsData();
			if (goodsData2 != null && goodsData2.GetRemainingCount() == 0)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06015919 RID: 88345 RVA: 0x005F9EC0 File Offset: 0x005F80C0
	public PayShopGoods GetCurrentGoodsData()
	{
		return this.PayShopGoods;
	}

	// Token: 0x0601591A RID: 88346 RVA: 0x005F9EC8 File Offset: 0x005F80C8
	public int GetItemId()
	{
		return this.PayShopGoods.GetPackageRewardId();
	}

	// Token: 0x0601591B RID: 88347 RVA: 0x005F9ED8 File Offset: 0x005F80D8
	public List<TItem> GetAllReward()
	{
		List<TItem> list = new List<TItem>();
		list.AddRange(this.GetMainReward());
		if (this.OtherReward != null)
		{
			list.Add(new TItem(new InventoryDefine.GetItemData(this.OtherReward.ItemId, 0), this.OtherReward.Count));
		}
		return list;
	}

	// Token: 0x0601591C RID: 88348 RVA: 0x005F9F28 File Offset: 0x005F8128
	public List<TItem> GetMainReward()
	{
		List<TItem> list = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in this.MainRewardMap)
		{
			InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(keyValuePair.Key, 0);
			TItem item = new TItem(itemData, keyValuePair.Value);
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0601591D RID: 88349 RVA: 0x005F9FA0 File Offset: 0x005F81A0
	public TItem? GetOtherReward()
	{
		if (this.OtherReward == null)
		{
			return null;
		}
		return new TItem?(new TItem(new InventoryDefine.GetItemData(this.OtherReward.ItemId, 0), this.OtherReward.Count));
	}

	// Token: 0x0601591E RID: 88350 RVA: 0x005F9FE5 File Offset: 0x005F81E5
	public PayShopGoods GetPayShopGoods()
	{
		return this.PayShopGoods;
	}

	// Token: 0x0601591F RID: 88351 RVA: 0x005F9FF0 File Offset: 0x005F81F0
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

	// Token: 0x06015920 RID: 88352 RVA: 0x005FA040 File Offset: 0x005F8240
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

	// Token: 0x06015921 RID: 88353 RVA: 0x005FA076 File Offset: 0x005F8276
	public IPriceData GetPriceData()
	{
		return this.GetCurrentGoodsData().GetPriceData();
	}

	// Token: 0x06015922 RID: 88354 RVA: 0x005FA083 File Offset: 0x005F8283
	public bool GetIfDirect()
	{
		return this.GetCurrentGoodsData().IsDirect();
	}

	// Token: 0x06015923 RID: 88355 RVA: 0x005FA090 File Offset: 0x005F8290
	public string GetDirectPriceText()
	{
		return this.GetCurrentGoodsData().GetDirectPriceText();
	}

	// Token: 0x06015924 RID: 88356 RVA: 0x005FA09D File Offset: 0x005F829D
	public MotorSkinData GetMotorSkinData()
	{
		return new MotorSkinData(this.GiftPackageId);
	}

	// Token: 0x0400A5F8 RID: 42488
	[Nullable(2)]
	private PayShopGoods PayShopGoods;

	// Token: 0x0400A5F9 RID: 42489
	private readonly Dictionary<int, int> MainRewardMap = new Dictionary<int, int>();

	// Token: 0x0400A5FA RID: 42490
	private int GiftPackageId;

	// Token: 0x0400A5FB RID: 42491
	[Nullable(2)]
	private global::IItemData OtherReward;
}
