using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;

// Token: 0x02002A2D RID: 10797
[NullableContext(1)]
[Nullable(0)]
public class ShopSkinData
{
	// Token: 0x06015926 RID: 88358 RVA: 0x005FA0BD File Offset: 0x005F82BD
	public static ShopSkinData Create(PayShopGoods data)
	{
		ShopSkinData shopSkinData = new ShopSkinData();
		shopSkinData.InitData(data);
		return shopSkinData;
	}

	// Token: 0x06015927 RID: 88359 RVA: 0x005FA0CC File Offset: 0x005F82CC
	public void InitData(PayShopGoods data)
	{
		this.PayShopGoods = data;
		this.OtherRewardMap.Clear();
		GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(data.GetPackageRewardId());
		if (giftPackageConfig != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in giftPackageConfig.Value.Content())
			{
				int key = keyValuePair.Key;
				if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(key)) == InventoryDefine.EItemDataType.RoleSkinItem)
				{
					this.RewardSkinId = new int?(key);
				}
				else
				{
					this.OtherRewardMap.Add(key, keyValuePair.Value);
				}
			}
		}
	}

	// Token: 0x06015928 RID: 88360 RVA: 0x005FA190 File Offset: 0x005F8390
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

	// Token: 0x06015929 RID: 88361 RVA: 0x005FA1E4 File Offset: 0x005F83E4
	public PayShopGoods GetCurrentGoodsData()
	{
		return this.PayShopGoods;
	}

	// Token: 0x0601592A RID: 88362 RVA: 0x005FA1EC File Offset: 0x005F83EC
	public int GetItemId()
	{
		return this.RewardSkinId.Value;
	}

	// Token: 0x0601592B RID: 88363 RVA: 0x005FA1FC File Offset: 0x005F83FC
	public TItem[] GetAllReward()
	{
		List<TItem> list = new List<TItem>();
		InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(this.GetItemId(), 0);
		TItem item = new TItem(itemData, 1);
		list.Add(item);
		list.AddRange(this.GetOtherReward());
		return list.ToArray();
	}

	// Token: 0x0601592C RID: 88364 RVA: 0x005FA23C File Offset: 0x005F843C
	public TItem[] GetOtherReward()
	{
		List<TItem> list = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in this.OtherRewardMap)
		{
			InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(keyValuePair.Key, 0);
			TItem item = new TItem(itemData, keyValuePair.Value);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0601592D RID: 88365 RVA: 0x005FA2BC File Offset: 0x005F84BC
	public PayShopGoods GetPayShopGoods()
	{
		return this.PayShopGoods;
	}

	// Token: 0x0601592E RID: 88366 RVA: 0x005FA2C4 File Offset: 0x005F84C4
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

	// Token: 0x0601592F RID: 88367 RVA: 0x005FA314 File Offset: 0x005F8514
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

	// Token: 0x06015930 RID: 88368 RVA: 0x005FA34A File Offset: 0x005F854A
	public IPriceData GetPriceData()
	{
		return this.GetCurrentGoodsData().GetPriceData();
	}

	// Token: 0x06015931 RID: 88369 RVA: 0x005FA357 File Offset: 0x005F8557
	public bool GetIfDirect()
	{
		return this.GetCurrentGoodsData().IsDirect();
	}

	// Token: 0x06015932 RID: 88370 RVA: 0x005FA364 File Offset: 0x005F8564
	public string GetDirectPriceText()
	{
		return this.GetCurrentGoodsData().GetDirectPriceText();
	}

	// Token: 0x06015933 RID: 88371 RVA: 0x005FA371 File Offset: 0x005F8571
	public RoleSkinData GetRoleSkinData()
	{
		return ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(this.GetItemId());
	}

	// Token: 0x06015934 RID: 88372 RVA: 0x005FA383 File Offset: 0x005F8583
	public string GetPayShopPreviewRoleTexturePath()
	{
		return this.GetRoleSkinData().GetPayShopPreviewRoleTexturePath();
	}

	// Token: 0x06015935 RID: 88373 RVA: 0x005FA390 File Offset: 0x005F8590
	public string GetPayShopPreviewRoleTextureBgPath()
	{
		return this.GetRoleSkinData().GetPayShopPreviewRoleTextureBgPath();
	}

	// Token: 0x06015936 RID: 88374 RVA: 0x005FA39D File Offset: 0x005F859D
	public string GetPayShopPreviewWeaponTexturePath()
	{
		return this.GetRoleSkinData().GetPayShopPreviewWeaponTexturePath();
	}

	// Token: 0x06015937 RID: 88375 RVA: 0x005FA3AA File Offset: 0x005F85AA
	public string GetPayShopPreviewBuyRoleTexturePath()
	{
		return this.GetRoleSkinData().GetPayShopPreviewBuyRoleTexturePath();
	}

	// Token: 0x06015938 RID: 88376 RVA: 0x005FA3B7 File Offset: 0x005F85B7
	public string GetPayShopPreviewBuyRoleSuitWeaponTexturePath()
	{
		return this.GetRoleSkinData().GetPayShopPreviewBuyRoleSuitWeaponTexturePath();
	}

	// Token: 0x0400A5FC RID: 42492
	[Nullable(2)]
	private PayShopGoods PayShopGoods;

	// Token: 0x0400A5FD RID: 42493
	private int? RewardSkinId;

	// Token: 0x0400A5FE RID: 42494
	private readonly Dictionary<int, int> OtherRewardMap = new Dictionary<int, int>();
}
