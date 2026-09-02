using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;

namespace CSharpScript.Game.Module.Ornament
{
	// Token: 0x020056C1 RID: 22209
	[NullableContext(1)]
	[Nullable(0)]
	public class ShopRoleOrnamentData
	{
		// Token: 0x0603886C RID: 231532 RVA: 0x00E522C2 File Offset: 0x00E504C2
		public static ShopRoleOrnamentData Create(PayShopGoods data)
		{
			ShopRoleOrnamentData shopRoleOrnamentData = new ShopRoleOrnamentData();
			shopRoleOrnamentData.InitData(data);
			return shopRoleOrnamentData;
		}

		// Token: 0x0603886D RID: 231533 RVA: 0x00E522D0 File Offset: 0x00E504D0
		public void InitData(PayShopGoods data)
		{
			this.PayShopGoods = data;
			this.OtherRewardMap.Clear();
			this.OrnamentId = data.GetRewardOrnamentId();
			if (this.OrnamentId == 0)
			{
				return;
			}
			if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(data.GetGoodsData().ItemId)) == InventoryDefine.EItemDataType.OrnamentItem)
			{
				return;
			}
			int packageRewardId = data.GetPackageRewardId();
			if (packageRewardId == 0)
			{
				return;
			}
			GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(packageRewardId);
			if (giftPackageConfig == null)
			{
				return;
			}
			foreach (KeyValuePair<int, int> keyValuePair in giftPackageConfig.Value.Content())
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(key)) != InventoryDefine.EItemDataType.OrnamentItem)
				{
					this.OtherRewardMap[key] = value;
				}
			}
		}

		// Token: 0x0603886E RID: 231534 RVA: 0x00E523C4 File Offset: 0x00E505C4
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

		// Token: 0x0603886F RID: 231535 RVA: 0x00E52418 File Offset: 0x00E50618
		public PayShopGoods GetCurrentGoodsData()
		{
			return this.PayShopGoods;
		}

		// Token: 0x06038870 RID: 231536 RVA: 0x00E52420 File Offset: 0x00E50620
		public PayShopGoods GetPayShopGoods()
		{
			return this.PayShopGoods;
		}

		// Token: 0x06038871 RID: 231537 RVA: 0x00E52428 File Offset: 0x00E50628
		public int GetItemId()
		{
			return this.OrnamentId;
		}

		// Token: 0x06038872 RID: 231538 RVA: 0x00E52430 File Offset: 0x00E50630
		[return: TupleElementNames(new string[]
		{
			"ItemId",
			"Count"
		})]
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		public List<ValueTuple<int, int>> GetOtherRewardSimple()
		{
			List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
			foreach (KeyValuePair<int, int> keyValuePair in this.OtherRewardMap)
			{
				list.Add(new ValueTuple<int, int>(keyValuePair.Key, keyValuePair.Value));
			}
			return list;
		}

		// Token: 0x06038873 RID: 231539 RVA: 0x00E5249C File Offset: 0x00E5069C
		public List<TItem> GetAllReward()
		{
			List<TItem> list = new List<TItem>();
			list.Add(new TItem(new InventoryDefine.GetItemData(this.GetItemId(), 0), 1));
			list.AddRange(this.GetOtherReward());
			return list;
		}

		// Token: 0x06038874 RID: 231540 RVA: 0x00E524C8 File Offset: 0x00E506C8
		public List<TItem> GetOtherReward()
		{
			List<TItem> list = new List<TItem>();
			foreach (KeyValuePair<int, int> keyValuePair in this.OtherRewardMap)
			{
				list.Add(new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value));
			}
			return list;
		}

		// Token: 0x06038875 RID: 231541 RVA: 0x00E5253C File Offset: 0x00E5073C
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

		// Token: 0x06038876 RID: 231542 RVA: 0x00E5258C File Offset: 0x00E5078C
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

		// Token: 0x06038877 RID: 231543 RVA: 0x00E525C2 File Offset: 0x00E507C2
		public IPriceData GetPriceData()
		{
			return this.GetCurrentGoodsData().GetPriceData();
		}

		// Token: 0x06038878 RID: 231544 RVA: 0x00E525CF File Offset: 0x00E507CF
		public bool GetIfDirect()
		{
			return this.GetCurrentGoodsData().IsDirect();
		}

		// Token: 0x06038879 RID: 231545 RVA: 0x00E525DC File Offset: 0x00E507DC
		public string GetDirectPriceText()
		{
			return this.GetCurrentGoodsData().GetDirectPriceText();
		}

		// Token: 0x0603887A RID: 231546 RVA: 0x00E525E9 File Offset: 0x00E507E9
		public string GetTitleName()
		{
			return this.GetRoleOrnamentData().GetTitleName();
		}

		// Token: 0x0603887B RID: 231547 RVA: 0x00E525F6 File Offset: 0x00E507F6
		public string GetPreviewTextureInPayShop()
		{
			return this.GetRoleOrnamentData().GetPreviewTextureInPayShop();
		}

		// Token: 0x0603887C RID: 231548 RVA: 0x00E52603 File Offset: 0x00E50803
		public RoleOrnamentData GetRoleOrnamentData()
		{
			return ModelBase<RoleOrnamentModel>.Instance.GetRoleOrnamentData(this.GetItemId());
		}

		// Token: 0x0402043D RID: 132157
		[Nullable(2)]
		private PayShopGoods PayShopGoods;

		// Token: 0x0402043E RID: 132158
		private int OrnamentId;

		// Token: 0x0402043F RID: 132159
		private readonly Dictionary<int, int> OtherRewardMap = new Dictionary<int, int>();
	}
}
