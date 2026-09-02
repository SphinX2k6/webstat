using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

namespace CSharpScript.Game.Module.PayShop
{
	// Token: 0x020056B9 RID: 22201
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PayShopGoods : PayShopUnionData<PayShopGoodsData>
	{
		// Token: 0x060387F7 RID: 231415 RVA: 0x00E4FE88 File Offset: 0x00E4E088
		public PayShopGoods(PayShopDefine.EPayShopTabType payShopId)
		{
			this.PayShopId = payShopId;
		}

		// Token: 0x060387F8 RID: 231416 RVA: 0x00E4FE9E File Offset: 0x00E4E09E
		public void SetPayShopId(PayShopDefine.EPayShopTabType payShopId)
		{
			this.PayShopId = payShopId;
		}

		// Token: 0x060387F9 RID: 231417 RVA: 0x00E4FEA7 File Offset: 0x00E4E0A7
		public void SetGoodsData(PayShopGoodsData data)
		{
			this.Data = data;
			this.IsOnSell = this.InSellTime();
			this.CachePayShopItemBaseSt = new PayShopItemBaseSt();
			this.CachePayShopItemBaseSt.PhraseFromPayItemData(this);
		}

		// Token: 0x060387FA RID: 231418 RVA: 0x00E4FED3 File Offset: 0x00E4E0D3
		public void SetPayGiftId(int id)
		{
			this.PayGiftId = id;
		}

		// Token: 0x060387FB RID: 231419 RVA: 0x00E4FEDC File Offset: 0x00E4E0DC
		[NullableContext(2)]
		public PayPackageData GetGetPayGiftData()
		{
			return ModelBase<PayGiftModel>.Instance.GetPayGiftDataById(this.PayGiftId);
		}

		// Token: 0x060387FC RID: 231420 RVA: 0x00E4FEEE File Offset: 0x00E4E0EE
		[NullableContext(2)]
		public PayShopGoodsData GetGoodsData()
		{
			return this.Data;
		}

		// Token: 0x060387FD RID: 231421 RVA: 0x00E4FEF6 File Offset: 0x00E4E0F6
		public bool IsLocked()
		{
			return this.Data.Locked;
		}

		// Token: 0x060387FE RID: 231422 RVA: 0x00E4FF04 File Offset: 0x00E4E104
		public string GetConditionTextId()
		{
			int buyConditionId = this.Data.GetBuyConditionId();
			if (buyConditionId != 0)
			{
				return LevelGeneralCommons.GetConditionGroupHintText(buyConditionId) ?? "";
			}
			return "";
		}

		// Token: 0x060387FF RID: 231423 RVA: 0x00E4FF35 File Offset: 0x00E4E135
		public int GetDiscountLabel()
		{
			return this.Data.LabelId;
		}

		// Token: 0x06038800 RID: 231424 RVA: 0x00E4FF44 File Offset: 0x00E4E144
		public IItemData GetItemData()
		{
			InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
			int itemId = this.Data.ItemId;
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = instance.GetItemConfigData(itemId);
			int quality = (this.Data.ShopItemQuality > 0) ? this.Data.ShopItemQuality : itemConfigData.QualityId;
			EItemQualityType qualityType = (this.Data.ShopItemQuality > 0) ? EItemQualityType.PayShop : EItemQualityType.Item;
			return new ItemData
			{
				Quality = quality,
				ItemId = itemId,
				Name = itemConfigData.Name,
				QualityType = qualityType
			};
		}

		// Token: 0x06038801 RID: 231425 RVA: 0x00E4FFC4 File Offset: 0x00E4E1C4
		public bool IfPayGift()
		{
			return this.Data.IfPayGift();
		}

		// Token: 0x06038802 RID: 231426 RVA: 0x00E4FFD4 File Offset: 0x00E4E1D4
		public IPriceData GetPriceData()
		{
			int availableCouponDiscount = this.GetAvailableCouponDiscount();
			int num = Math.Max(this.Data.GetNowPrice() - availableCouponDiscount, 0);
			int? originalPrice = this.Data.GetOriginalPrice();
			if (originalPrice == null && availableCouponDiscount > 0)
			{
				originalPrice = new int?(num + availableCouponDiscount);
			}
			int currencyId = this.Data.Price.Id;
			int num2 = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(currencyId, 0) - num;
			return new PriceData
			{
				OwnNumber = (() => ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(currencyId, 0)),
				NowPrice = num,
				OriginalPrice = originalPrice,
				CurrencyId = currencyId,
				Enough = (num2 >= 0),
				InDiscountTime = this.Data.HasDiscount()
			};
		}

		// Token: 0x06038803 RID: 231427 RVA: 0x00E500A0 File Offset: 0x00E4E2A0
		public string GetDirectPriceText()
		{
			KuroSdkModel instance = ModelBase<KuroSdkModel>.Instance;
			string text = (instance != null) ? instance.GetQueryProductShowPrice(this.Data.Price.Id.ToString()) : null;
			if (text != null)
			{
				return text;
			}
			int id = this.Data.Price.Id;
			return ConfigBase<PayItemConfig>.Instance.GetPayShow(id);
		}

		// Token: 0x06038804 RID: 231428 RVA: 0x00E500F8 File Offset: 0x00E4E2F8
		[NullableContext(2)]
		public IRemainingData GetRemainingData()
		{
			if (!this.Data.HasBuyLimit())
			{
				return null;
			}
			int remainingCount = this.Data.GetRemainingCount();
			return new RemainingData(this.Data.GetRemainingTextId(), remainingCount);
		}

		// Token: 0x06038805 RID: 231429 RVA: 0x00E50131 File Offset: 0x00E4E331
		public void SetUnLock()
		{
			this.Data.SetUnLock();
		}

		// Token: 0x06038806 RID: 231430 RVA: 0x00E5013E File Offset: 0x00E4E33E
		public int GetDiscount()
		{
			return this.Data.GetDiscount();
		}

		// Token: 0x06038807 RID: 231431 RVA: 0x00E5014C File Offset: 0x00E4E34C
		public int GetDiscountNew()
		{
			PayPackageData getPayGiftData = this.GetGetPayGiftData();
			if (getPayGiftData != null)
			{
				return getPayGiftData.GetDiscount() / 100;
			}
			return this.Data.GetDiscountNew();
		}

		// Token: 0x06038808 RID: 231432 RVA: 0x00E50178 File Offset: 0x00E4E378
		public bool HasDiscount()
		{
			PayPackageData getPayGiftData = this.GetGetPayGiftData();
			if (getPayGiftData != null)
			{
				return getPayGiftData.HasDiscount();
			}
			return this.Data.HasDiscount();
		}

		// Token: 0x06038809 RID: 231433 RVA: 0x00E501A4 File Offset: 0x00E4E3A4
		public bool IsPermanentDiscount()
		{
			return (this.Data.EndPromotionTime == 0L && this.Data.BeginPromotionTime == 0L) || (this.Data.EndPromotionTime == 0L && Singleton<TimeUtil>.Instance.GetServerTime() >= (double)this.Data.BeginTime);
		}

		// Token: 0x0603880A RID: 231434 RVA: 0x00E501F8 File Offset: 0x00E4E3F8
		public bool IsPermanentSell()
		{
			return (this.Data.BeginTime == 0L && this.Data.EndTime == 0L) || (Singleton<TimeUtil>.Instance.GetServerTime() >= (double)this.Data.BeginTime && this.Data.EndTime == 0L);
		}

		// Token: 0x0603880B RID: 231435 RVA: 0x00E5024C File Offset: 0x00E4E44C
		public bool InSellTime()
		{
			return this.IsPermanentSell() || ((double)this.Data.EndTime > Singleton<TimeUtil>.Instance.GetServerTime() && Singleton<TimeUtil>.Instance.GetServerTime() >= (double)this.Data.BeginTime);
		}

		// Token: 0x0603880C RID: 231436 RVA: 0x00E50298 File Offset: 0x00E4E498
		public bool InLabelShowTime()
		{
			return this.Data.InLabelShowTime();
		}

		// Token: 0x0603880D RID: 231437 RVA: 0x00E502A8 File Offset: 0x00E4E4A8
		public bool InUnPermanentSellTime()
		{
			return !this.IsPermanentSell() && (double)this.Data.EndTime > Singleton<TimeUtil>.Instance.GetServerTime() && Singleton<TimeUtil>.Instance.GetServerTime() >= (double)this.Data.BeginTime;
		}

		// Token: 0x0603880E RID: 231438 RVA: 0x00E502F4 File Offset: 0x00E4E4F4
		public bool WillSell()
		{
			return !this.IsOnSell && Singleton<TimeUtil>.Instance.GetServerTime() < (double)this.Data.BeginTime;
		}

		// Token: 0x0603880F RID: 231439 RVA: 0x00E5031C File Offset: 0x00E4E51C
		public CommonDefine.IPayShowCountDownRemainTime GetDiscountTimeData()
		{
			long endPromotionTime = this.Data.EndPromotionTime;
			return new CommonDefine.PayShowCountDownRemainTime<string>
			{
				Value = PayShopGoods.GetEndTimeShowText(endPromotionTime)
			};
		}

		// Token: 0x06038810 RID: 231440 RVA: 0x00E50348 File Offset: 0x00E4E548
		public CommonDefine.IRemainTime GetDiscountRemainTime()
		{
			double time = (double)this.Data.EndPromotionTime - Singleton<TimeUtil>.Instance.GetServerTime();
			CommonDefine.IRemainTime remainTime = Singleton<TimeUtil>.Instance.CalculateRemainingTime(time, CommonDefine.ETimeType.Minute);
			if (remainTime == null)
			{
				remainTime = new CommonDefine.RemainTime
				{
					TimeValue = 0,
					RemainingTime = 0.0 + Singleton<TimeUtil>.Instance.TimeDeviation,
					TextId = CommonDefine.remainTimeTextId[CommonDefine.ETimeType.Minute]
				};
			}
			return remainTime;
		}

		// Token: 0x06038811 RID: 231441 RVA: 0x00E503B8 File Offset: 0x00E4E5B8
		public CommonDefine.ICountDown GetDiscountCountDown()
		{
			double time = (double)this.Data.EndPromotionTime - Singleton<TimeUtil>.Instance.GetServerTime();
			return Singleton<TimeUtil>.Instance.GetCountDownData(time, null, null);
		}

		// Token: 0x06038812 RID: 231442 RVA: 0x00E503FC File Offset: 0x00E4E5FC
		public CommonDefine.IPayShowCountDownRemainTime GetUpdateTimeRemainData()
		{
			long updateTime = this.Data.UpdateTime;
			return new CommonDefine.PayShowCountDownRemainTime<string>
			{
				Value = PayShopGoods.GetEndTimeShowText(updateTime)
			};
		}

		// Token: 0x06038813 RID: 231443 RVA: 0x00E50426 File Offset: 0x00E4E626
		public long GetUpdateRemainTime()
		{
			return (long)((double)this.Data.UpdateTime - Singleton<TimeUtil>.Instance.GetServerTime() + Singleton<TimeUtil>.Instance.TimeDeviation);
		}

		// Token: 0x06038814 RID: 231444 RVA: 0x00E5044B File Offset: 0x00E4E64B
		public bool InUpdateTime()
		{
			return this.Data.HasBuyLimit() && this.Data.UpdateTime != 0L && (double)this.Data.UpdateTime > Singleton<TimeUtil>.Instance.GetServerTime();
		}

		// Token: 0x06038815 RID: 231445 RVA: 0x00E50483 File Offset: 0x00E4E683
		public bool NeedDown()
		{
			if (this.IsOnSell && !this.IsPermanentSell() && !this.InUnPermanentSellTime())
			{
				this.IsOnSell = false;
				return true;
			}
			return false;
		}

		// Token: 0x06038816 RID: 231446 RVA: 0x00E504A8 File Offset: 0x00E4E6A8
		public bool NeedUpdate()
		{
			if (this.InSellTime() && !this.IsOnSell)
			{
				this.IsOnSell = true;
				return true;
			}
			return this.Data.HasBuyLimit() && this.Data.UpdateTime != 0L && (double)this.Data.UpdateTime <= Singleton<TimeUtil>.Instance.GetServerTime() && this.InSellTime();
		}

		// Token: 0x06038817 RID: 231447 RVA: 0x00E5050C File Offset: 0x00E4E70C
		[NullableContext(2)]
		public static string GetEndTimeShowText(long endTime)
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			double num = Math.Max((double)endTime - serverTime, 0.0);
			ValueTuple<int, int> timeTypeData = PayShopGoods.GetTimeTypeData((long)num);
			if (timeTypeData.Item1 == 0)
			{
				return ConfigBase<TextConfig>.Instance.GetTextById("NotEnoughOneHour");
			}
			return Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?((CommonDefine.ETimeType)timeTypeData.Item1), new CommonDefine.ETimeType?((CommonDefine.ETimeType)timeTypeData.Item2)).CountDownText;
		}

		// Token: 0x06038818 RID: 231448 RVA: 0x00E5057D File Offset: 0x00E4E77D
		[NullableContext(0)]
		public static ValueTuple<int, int> GetTimeTypeData(long remainTime)
		{
			if (remainTime > 86400L)
			{
				return new ValueTuple<int, int>(3, 2);
			}
			if (remainTime > 3600L)
			{
				return new ValueTuple<int, int>(2, 2);
			}
			return new ValueTuple<int, int>(0, 0);
		}

		// Token: 0x06038819 RID: 231449 RVA: 0x00E505A8 File Offset: 0x00E4E7A8
		public CommonDefine.IRemainTime GetTimeRemainData(long time)
		{
			double time2 = (double)time - Singleton<TimeUtil>.Instance.GetServerTime();
			CommonDefine.IRemainTime remainTime = Singleton<TimeUtil>.Instance.CalculateRemainingTime(time2, CommonDefine.ETimeType.Minute);
			if (remainTime == null)
			{
				remainTime = new CommonDefine.RemainTime
				{
					TimeValue = 0,
					RemainingTime = 0.0,
					TextId = CommonDefine.remainTimeTextId[CommonDefine.ETimeType.Minute]
				};
			}
			return remainTime;
		}

		// Token: 0x0603881A RID: 231450 RVA: 0x00E50604 File Offset: 0x00E4E804
		public CommonDefine.IPayShowCountDownRemainTime GetEndTimeRemainData()
		{
			long endTime = this.Data.EndTime;
			return new CommonDefine.PayShowCountDownRemainTime<string>
			{
				Value = PayShopGoods.GetEndTimeShowText(endTime)
			};
		}

		// Token: 0x0603881B RID: 231451 RVA: 0x00E50630 File Offset: 0x00E4E830
		[NullableContext(2)]
		public string GetDownTipsText()
		{
			if (this.CheckIfMonthCardItem())
			{
				return ConfigBase<TextConfig>.Instance.GetTextById("MonthlyCardMax");
			}
			if (this.IsLimitGoods() && this.IsSoldOut())
			{
				return ConfigBase<TextConfig>.Instance.GetTextById("SoldOut");
			}
			if (!this.IfCanBuy())
			{
				InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(this.GetGoodsData().ItemId));
				if (this.GetGoodsData().GetItemConfig().ShowTypes.Contains(30) || itemDataTypeByConfigId == InventoryDefine.EItemDataType.RoleItem)
				{
					return ConfigBase<TextConfig>.Instance.GetTextById("Text_Shop_Role_Text");
				}
				string conditionTextId = this.GetConditionTextId();
				if (!StringUtils.IsEmpty(conditionTextId))
				{
					return ConfigMultiTextLang.GetLocalTextNew(conditionTextId, null);
				}
			}
			return "";
		}

		// Token: 0x0603881C RID: 231452 RVA: 0x00E506E1 File Offset: 0x00E4E8E1
		[NullableContext(2)]
		public string GetConditionLimitText()
		{
			if (!this.Data.GetIfCanBuy())
			{
				return this.Data.GetUnFinishConditionText();
			}
			return "";
		}

		// Token: 0x0603881D RID: 231453 RVA: 0x00E50704 File Offset: 0x00E4E904
		[NullableContext(2)]
		public string GetExtraLimitText()
		{
			if (this.CheckIfMonthCardItem())
			{
				return "Text_MonthlyCardMax_Text";
			}
			if (this.IfCanBuy())
			{
				return null;
			}
			InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(this.GetGoodsData().ItemId));
			if (!this.GetGoodsData().GetItemConfig().ShowTypes.Contains(30) && itemDataTypeByConfigId != InventoryDefine.EItemDataType.RoleItem)
			{
				return this.GetConditionTextId();
			}
			int id;
			if (this.GetGoodsData().GetItemConfig().ShowTypes.Contains(30))
			{
				id = ModelBase<RoleModel>.Instance.GetResonantItemRoleId(this.GetGoodsData().ItemId)[0];
			}
			else
			{
				id = this.GetGoodsData().ItemId;
			}
			if (ModelBase<RoleModel>.Instance.GetRoleInstanceById(id) == null)
			{
				return "DontHaveRole";
			}
			return "RoleBrenchItemMax";
		}

		// Token: 0x0603881E RID: 231454 RVA: 0x00E507C4 File Offset: 0x00E4E9C4
		public bool GetIfNeedExtraLimitText()
		{
			if (this.CheckIfMonthCardItem())
			{
				return !ModelBase<MonthCardModel>.Instance.IsRemainDayInMaxLimit();
			}
			return !this.IfCanBuy();
		}

		// Token: 0x0603881F RID: 231455 RVA: 0x00E507E8 File Offset: 0x00E4E9E8
		public bool GetIfNeedShowDownTipsText()
		{
			return (this.CheckIfMonthCardItem() && ModelBase<MonthCardModel>.Instance.GetRemainDays() > ConfigCommonParamById.GetIntConfig("MonthCardMaxDays").Value) || (this.IsLimitGoods() && this.IsSoldOut()) || !this.IfCanBuy();
		}

		// Token: 0x06038820 RID: 231456 RVA: 0x00E5083C File Offset: 0x00E4EA3C
		public string GetSpriteTextBgColor()
		{
			if (this.CheckIfMonthCardItem() && ModelBase<MonthCardModel>.Instance.GetRemainDays() > ConfigCommonParamById.GetIntConfig("MonthCardMaxDays").Value)
			{
				return "3E3E3BFF";
			}
			if (this.IsLimitGoods() && this.IsSoldOut())
			{
				return "6C6C6CFF";
			}
			return "F9F9F9FF";
		}

		// Token: 0x06038821 RID: 231457 RVA: 0x00E50890 File Offset: 0x00E4EA90
		public string GetTextTipsColor()
		{
			if (this.CheckIfMonthCardItem() && ModelBase<MonthCardModel>.Instance.GetRemainDays() > ConfigCommonParamById.GetIntConfig("MonthCardMaxDays").Value)
			{
				return "F9F9F9FF";
			}
			if (this.IsLimitGoods() && this.IsSoldOut())
			{
				return "F9F9F9FF";
			}
			return "181818FF";
		}

		// Token: 0x06038822 RID: 231458 RVA: 0x00E508E4 File Offset: 0x00E4EAE4
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double> GetCountDownData()
		{
			CommonDefine.IPayShowCountDownRemainTime payShowCountDownRemainTime = null;
			EPayCountTimeType item = EPayCountTimeType.Default;
			double num = 0.0;
			if (payShowCountDownRemainTime == null && this.IsLimitGoods() && this.GetGoodsData().IsWeeklyRefresh() && this.GetRemainingData().Count == 0 && this.GetGoodsData().IfMayReSell())
			{
				payShowCountDownRemainTime = this.GetUpdateTimeRemainData();
				item = EPayCountTimeType.Resell;
				CommonDefine.IRemainTime timeRemainData = this.GetTimeRemainData(this.Data.UpdateTime);
				num = ((timeRemainData != null) ? timeRemainData.RemainingTime : 0.0);
			}
			if (payShowCountDownRemainTime != null)
			{
				return new ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double>(item, payShowCountDownRemainTime, num);
			}
			if (this.HasDiscount())
			{
				num = this.GetTimeRemainData(this.Data.EndPromotionTime).RemainingTime;
				if (num > 0.0)
				{
					payShowCountDownRemainTime = this.GetDiscountTimeData();
					item = EPayCountTimeType.Discount;
				}
			}
			if (payShowCountDownRemainTime != null)
			{
				return new ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double>(item, payShowCountDownRemainTime, num);
			}
			payShowCountDownRemainTime = this.GetEndTimeRemainData();
			item = EPayCountTimeType.NeverResell;
			CommonDefine.IRemainTime timeRemainData2 = this.GetTimeRemainData(this.Data.EndTime);
			num = ((timeRemainData2 != null) ? timeRemainData2.RemainingTime : 0.0);
			return new ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double>(item, payShowCountDownRemainTime, num);
		}

		// Token: 0x06038823 RID: 231459 RVA: 0x00E509E4 File Offset: 0x00E4EBE4
		public string GetResellText()
		{
			string result = "";
			if (this.IsLimitGoods() && this.GetGoodsData().IsWeeklyRefresh())
			{
				if (this.GetRemainingData().Count == 0 && !this.GetGoodsData().IfMayReSell())
				{
					result = "DistanceToDown";
				}
				else if (this.GetRemainingData().Count == 0 && this.GetGoodsData().IfMayReSell())
				{
					result = "ReSell";
				}
			}
			return result;
		}

		// Token: 0x06038824 RID: 231460 RVA: 0x00E50A50 File Offset: 0x00E4EC50
		public string GetExchangePopViewResellText()
		{
			string result = "";
			if (this.IsLimitGoods() && this.GetGoodsData().IsWeeklyRefresh() && this.GetRemainingData().Count == 0 && this.GetGoodsData().IfMayReSell())
			{
				result = "SoldOut";
			}
			return result;
		}

		// Token: 0x06038825 RID: 231461 RVA: 0x00E50A9C File Offset: 0x00E4EC9C
		public string GetBuyLimitText()
		{
			if (!this.IsLimitGoods())
			{
				return "";
			}
			string text;
			if (this.Data.UpdateType == PayShopDefine.EPayShopUpdateType.None)
			{
				text = "LimitBuy";
			}
			else if (this.Data.UpdateType == PayShopDefine.EPayShopUpdateType.Daily)
			{
				text = "DailyLeftTime";
			}
			else if (this.Data.UpdateType == PayShopDefine.EPayShopUpdateType.Weekly)
			{
				text = "WeekLeftTime";
			}
			else if (this.Data.UpdateType == PayShopDefine.EPayShopUpdateType.Monthly)
			{
				text = "MonthLeftTime";
			}
			else
			{
				text = "LimitBuy";
			}
			if (text == "LimitBuy")
			{
				int num = this.Data.BuyLimit - this.Data.BoughtCount;
				return StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById(text), new string[]
				{
					num.ToString(),
					this.Data.BuyLimit.ToString()
				});
			}
			return StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById(text), new string[]
			{
				(this.Data.BuyLimit - this.Data.BoughtCount).ToString()
			});
		}

		// Token: 0x06038826 RID: 231462 RVA: 0x00E50BB0 File Offset: 0x00E4EDB0
		public string GetExchangeViewShopTipsText()
		{
			if (this.CheckIfMonthCardItem())
			{
				return ModelBase<MonthCardModel>.Instance.GetRemainDayText(null);
			}
			if (this.IsLimitGoods())
			{
				string id;
				if (this.Data.UpdateType == PayShopDefine.EPayShopUpdateType.None)
				{
					id = "LimitBuy_B";
				}
				else if (this.Data.UpdateType == PayShopDefine.EPayShopUpdateType.Daily)
				{
					id = "DayLimitBuy_B";
				}
				else if (this.Data.UpdateType == PayShopDefine.EPayShopUpdateType.Weekly)
				{
					id = "WeekLimitBuy_B";
				}
				else if (this.Data.UpdateType == PayShopDefine.EPayShopUpdateType.Monthly)
				{
					id = "MonthLimitBuy_B";
				}
				else
				{
					id = "LimitBuy_B";
				}
				int num = this.Data.BuyLimit - this.Data.BoughtCount;
				string text;
				if (this.GetGoodsData().GetRemainingCount() > 0)
				{
					text = StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("BuyTextEnough"), new string[]
					{
						num.ToString(),
						this.Data.BuyLimit.ToString()
					});
				}
				else
				{
					text = StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("BuyTextNotEnough"), new string[]
					{
						num.ToString(),
						this.Data.BuyLimit.ToString()
					});
				}
				return StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById(id), new string[]
				{
					text
				});
			}
			return "";
		}

		// Token: 0x06038827 RID: 231463 RVA: 0x00E50D00 File Offset: 0x00E4EF00
		public string GetShopTipsText()
		{
			if (this.CheckIfMonthCardItem())
			{
				return ModelBase<MonthCardModel>.Instance.GetRemainDayText(null);
			}
			if (this.IsLimitGoods())
			{
				string id;
				if (this.Data.UpdateType == PayShopDefine.EPayShopUpdateType.None)
				{
					id = "LimitBuy";
				}
				else if (this.Data.UpdateType == PayShopDefine.EPayShopUpdateType.Daily)
				{
					id = "DayLimitBuy";
				}
				else if (this.Data.UpdateType == PayShopDefine.EPayShopUpdateType.Weekly)
				{
					id = "WeekLimitBuy";
				}
				else if (this.Data.UpdateType == PayShopDefine.EPayShopUpdateType.Monthly)
				{
					id = "MonthLimitBuy";
				}
				else
				{
					id = "LimitBuy";
				}
				int num = this.Data.BuyLimit - this.Data.BoughtCount;
				return StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById(id), new string[]
				{
					num.ToString(),
					this.Data.BuyLimit.ToString()
				});
			}
			return "";
		}

		// Token: 0x06038828 RID: 231464 RVA: 0x00E50DE0 File Offset: 0x00E4EFE0
		public int GetTabId()
		{
			return this.Data.TabId;
		}

		// Token: 0x06038829 RID: 231465 RVA: 0x00E50DED File Offset: 0x00E4EFED
		public bool IsLimitGoods()
		{
			return this.Data.HasBuyLimit();
		}

		// Token: 0x0603882A RID: 231466 RVA: 0x00E50DFC File Offset: 0x00E4EFFC
		public bool IfCanBuy()
		{
			if (this.CheckIfMonthCardItem())
			{
				ItemInfo? config = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(this.GetGoodsData().ItemId);
				int value;
				int? num;
				if (!config.Value.Parameters().TryGetValue(13, out value))
				{
					num = null;
				}
				else
				{
					num = new int?(value);
				}
				if (num == null)
				{
					int value2;
					if (!config.Value.Parameters().TryGetValue(14, out value2))
					{
						num = null;
					}
					else
					{
						num = new int?(value2);
					}
				}
				if (num == null)
				{
					return true;
				}
				if (!ModelBase<MonthCardModel>.Instance.CheckMonthCardIfCanBuy())
				{
					return false;
				}
			}
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfig = this.GetGoodsData().GetItemConfig();
			if (itemConfig != null)
			{
				int[] showTypes = itemConfig.ShowTypes;
				if (showTypes != null && showTypes.Contains(30))
				{
					int[] resonantItemRoleId = ModelBase<RoleModel>.Instance.GetResonantItemRoleId(this.GetGoodsData().ItemId);
					if (resonantItemRoleId != null && resonantItemRoleId.Length != 0)
					{
						int num2 = resonantItemRoleId[0];
						return ModelBase<RoleModel>.Instance.GetRoleInstanceById(num2) != null && ModelBase<RoleModel>.Instance.GetRoleLeftResonantCountWithInventoryItem(num2) > 0;
					}
				}
			}
			return this.Data.GetIfCanBuy();
		}

		// Token: 0x0603882B RID: 231467 RVA: 0x00E50F20 File Offset: 0x00E4F120
		public bool IsSoldOut()
		{
			if (this.Data.HasBuyLimit())
			{
				return this.Data.BoughtCount == this.Data.BuyLimit;
			}
			int rewardRoleSkinId = this.GetRewardRoleSkinId();
			return rewardRoleSkinId > 0 && !ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(rewardRoleSkinId).IsLocked();
		}

		// Token: 0x0603882C RID: 231468 RVA: 0x00E50F73 File Offset: 0x00E4F173
		public int GetGoodsId()
		{
			return this.Data.Id;
		}

		// Token: 0x0603882D RID: 231469 RVA: 0x00E50F80 File Offset: 0x00E4F180
		public bool IsDirect()
		{
			return this.Data.IsDirect();
		}

		// Token: 0x0603882E RID: 231470 RVA: 0x00E50F8D File Offset: 0x00E4F18D
		public void AddBoughtCount(int addCount)
		{
			this.Data.BoughtCount += addCount;
		}

		// Token: 0x0603882F RID: 231471 RVA: 0x00E50FA2 File Offset: 0x00E4F1A2
		public bool IsShowInShop()
		{
			return this.Data.IsShowInShop();
		}

		// Token: 0x06038830 RID: 231472 RVA: 0x00E50FAF File Offset: 0x00E4F1AF
		public PayShopItemBaseSt ConvertToPayShopBaseSt()
		{
			this.CachePayShopItemBaseSt.Refresh(this);
			return this.CachePayShopItemBaseSt;
		}

		// Token: 0x06038831 RID: 231473 RVA: 0x00E50FC3 File Offset: 0x00E4F1C3
		public bool CheckIfMonthCardItem()
		{
			return this.GetGoodsData().CheckIfMonthCardItem();
		}

		// Token: 0x06038832 RID: 231474 RVA: 0x00E50FD0 File Offset: 0x00E4F1D0
		public bool GetIfNeedRemind()
		{
			return this.IsGoodsFree() || this.IfNeedRemind();
		}

		// Token: 0x06038833 RID: 231475 RVA: 0x00E50FE5 File Offset: 0x00E4F1E5
		private bool IsGoodsFree()
		{
			return !this.IsLocked() && this.IfCanBuy() && !this.IsSoldOut() && this.CheckGoodIfShow() && !this.IsDirect() && this.GetPriceData().NowPrice == 0;
		}

		// Token: 0x06038834 RID: 231476 RVA: 0x00E5101F File Offset: 0x00E4F21F
		private bool IfNeedRemind()
		{
			return this.IfCanBuy() && !this.IsSoldOut() && this.CheckGoodIfShow() && this.Data.GetIfNeedRemind();
		}

		// Token: 0x06038835 RID: 231477 RVA: 0x00E51046 File Offset: 0x00E4F246
		public bool GetIfShowRecommendTag()
		{
			return this.Data.ShowRecommendTag;
		}

		// Token: 0x06038836 RID: 231478 RVA: 0x00E51054 File Offset: 0x00E4F254
		public bool CheckGoodIfShow()
		{
			return this.IsShowInShop() && this.InSellTime() && this.GetGoodsData().Show && (!this.GetGoodsData().HasBuyLimit() || this.GetGoodsData().GetRemainingCount() != 0 || this.GetGoodsData().IsWeeklyRefresh() || this.GetGoodsData().IfShowAfterSoldOut()) && (!this.GetGoodsData().HasBuyLimit() || this.GetGoodsData().GetRemainingCount() != 0 || !this.GetGoodsData().IsWeeklyRefresh() || this.GetGoodsData().UpdateTime < this.GetGoodsData().EndTime || this.IsPermanentSell());
		}

		// Token: 0x06038837 RID: 231479 RVA: 0x00E51104 File Offset: 0x00E4F304
		public void SaveRemindState(long timestamp)
		{
			if (this.Data.SaveRemindState(timestamp) == 0)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.RefreshPayShopEntranceRedDot);
				Singleton<EventSystem>.Instance.Emit<PayShopDefine.EPayShopTabType>(EEventName.RefreshPayShopInstanceRedDot, this.PayShopId);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshPayShopTabRedDot, this.GetTabId());
			}
		}

		// Token: 0x06038838 RID: 231480 RVA: 0x00E5115C File Offset: 0x00E4F35C
		public bool CheckIfGiftPackage()
		{
			int itemId = this.GetGoodsData().ItemId;
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemId);
			if (itemConfig != null && itemConfig.Value.Parameters() != null)
			{
				int value;
				int? num;
				if (!itemConfig.Value.Parameters().TryGetValue(2, out value))
				{
					num = null;
				}
				else
				{
					num = new int?(value);
				}
				if (num == null)
				{
					int value2;
					if (!itemConfig.Value.Parameters().TryGetValue(4, out value2))
					{
						num = null;
					}
					else
					{
						num = new int?(value2);
					}
				}
				return num != null;
			}
			return false;
		}

		// Token: 0x06038839 RID: 231481 RVA: 0x00E5120C File Offset: 0x00E4F40C
		public int GetPackageRewardId()
		{
			int itemId = this.GetGoodsData().ItemId;
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemId);
			if (itemConfig == null || itemConfig.Value.Parameters() == null)
			{
				return 0;
			}
			int value;
			int? num;
			if (!itemConfig.Value.Parameters().TryGetValue(2, out value))
			{
				num = null;
			}
			else
			{
				num = new int?(value);
			}
			if (num == null)
			{
				int value2;
				if (!itemConfig.Value.Parameters().TryGetValue(4, out value2))
				{
					num = null;
				}
				else
				{
					num = new int?(value2);
				}
			}
			if (num == null)
			{
				return 0;
			}
			return num.Value;
		}

		// Token: 0x0603883A RID: 231482 RVA: 0x00E512C4 File Offset: 0x00E4F4C4
		public int GetRewardRoleSkinId()
		{
			int itemId = this.GetGoodsData().ItemId;
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemId);
			if (itemConfig != null && itemConfig.Value.Parameters() != null)
			{
				if (!this.CheckIfGiftPackage())
				{
					return 0;
				}
				GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(this.GetPackageRewardId());
				if (giftPackageConfig == null)
				{
					return 0;
				}
				foreach (KeyValuePair<int, int> keyValuePair in giftPackageConfig.Value.Content())
				{
					int key = keyValuePair.Key;
					if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(key)) == InventoryDefine.EItemDataType.RoleSkinItem)
					{
						return key;
					}
				}
				return 0;
			}
			return 0;
		}

		// Token: 0x0603883B RID: 231483 RVA: 0x00E513A4 File Offset: 0x00E4F5A4
		public int GetRewardFlySkinId()
		{
			int itemId = this.GetGoodsData().ItemId;
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemId);
			if (itemConfig != null && itemConfig.Value.Parameters() != null)
			{
				if (!this.CheckIfGiftPackage())
				{
					return 0;
				}
				GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(this.GetPackageRewardId());
				if (giftPackageConfig == null)
				{
					return 0;
				}
				foreach (KeyValuePair<int, int> keyValuePair in giftPackageConfig.Value.Content())
				{
					int key = keyValuePair.Key;
					if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(key)) == InventoryDefine.EItemDataType.FlySkinItem)
					{
						return key;
					}
				}
				return 0;
			}
			return 0;
		}

		// Token: 0x0603883C RID: 231484 RVA: 0x00E51484 File Offset: 0x00E4F684
		public int GetRewardOrnamentId()
		{
			int itemId = this.GetGoodsData().ItemId;
			if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemId)) == InventoryDefine.EItemDataType.OrnamentItem)
			{
				return itemId;
			}
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemId);
			if (itemConfig != null && itemConfig.Value.Parameters() != null)
			{
				if (!this.CheckIfGiftPackage())
				{
					return 0;
				}
				GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(this.GetPackageRewardId());
				if (giftPackageConfig == null)
				{
					return 0;
				}
				if (giftPackageConfig.Value.CheckGoodsMethod == 1)
				{
					return 0;
				}
				foreach (KeyValuePair<int, int> keyValuePair in giftPackageConfig.Value.Content())
				{
					int key = keyValuePair.Key;
					if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(key)) == InventoryDefine.EItemDataType.OrnamentItem)
					{
						return key;
					}
				}
				return 0;
			}
			return 0;
		}

		// Token: 0x0603883D RID: 231485 RVA: 0x00E51590 File Offset: 0x00E4F790
		public bool CheckIfOrnamentGoods()
		{
			return this.GetRewardOrnamentId() != 0;
		}

		// Token: 0x0603883E RID: 231486 RVA: 0x00E5159B File Offset: 0x00E4F79B
		public bool CheckIfRoleSkinGoods()
		{
			return this.GetRewardRoleSkinId() != 0;
		}

		// Token: 0x0603883F RID: 231487 RVA: 0x00E515A8 File Offset: 0x00E4F7A8
		public bool CheckIfFlySkinGoods()
		{
			int itemId = this.GetGoodsData().ItemId;
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemId);
			if (itemConfig != null && itemConfig.Value.Parameters() != null)
			{
				if (!this.CheckIfGiftPackage())
				{
					return false;
				}
				GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(this.GetPackageRewardId());
				if (giftPackageConfig == null)
				{
					return false;
				}
				if (giftPackageConfig.Value.CheckGoodsMethod == 1)
				{
					return false;
				}
				foreach (KeyValuePair<int, int> keyValuePair in giftPackageConfig.Value.Content())
				{
					int key = keyValuePair.Key;
					if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(key)) == InventoryDefine.EItemDataType.FlySkinItem)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x06038840 RID: 231488 RVA: 0x00E5169C File Offset: 0x00E4F89C
		[NullableContext(2)]
		public CommonItemData GetAvailableCouponItem()
		{
			foreach (int configId in this.Data.GetCouponList())
			{
				CommonItemData commonItemData = ModelBase<InventoryModel>.Instance.GetCommonItemData(configId, 0);
				if (commonItemData != null)
				{
					return commonItemData;
				}
			}
			return null;
		}

		// Token: 0x06038841 RID: 231489 RVA: 0x00E51704 File Offset: 0x00E4F904
		public int GetAvailableCouponDiscount()
		{
			CommonItemData availableCouponItem = this.GetAvailableCouponItem();
			if (availableCouponItem == null)
			{
				return 0;
			}
			Coupon? config = ConfigCouponById.GetConfig(availableCouponItem.GetConfigId(), true);
			if (config == null)
			{
				return 0;
			}
			return config.Value.Param;
		}

		// Token: 0x06038842 RID: 231490 RVA: 0x00E51744 File Offset: 0x00E4F944
		public int GetRewardMotorSkinId()
		{
			int itemId = this.GetGoodsData().ItemId;
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemId);
			if (itemConfig != null && itemConfig.Value.Parameters() != null)
			{
				if (!this.CheckIfGiftPackage())
				{
					return 0;
				}
				GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(this.GetPackageRewardId());
				if (giftPackageConfig == null)
				{
					return 0;
				}
				Dictionary<int, int> dictionary = giftPackageConfig.Value.Content();
				List<InventoryDefine.EItemDataType> list = new List<InventoryDefine.EItemDataType>
				{
					InventoryDefine.EItemDataType.MotorStickerItem,
					InventoryDefine.EItemDataType.MotorDecorationItem,
					InventoryDefine.EItemDataType.MotorFrameItem,
					InventoryDefine.EItemDataType.MotorSkinItem
				};
				foreach (KeyValuePair<int, int> keyValuePair in dictionary)
				{
					int key = keyValuePair.Key;
					InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(key));
					if (list.Contains(itemDataTypeByConfigId))
					{
						return key;
					}
				}
				return 0;
			}
			return 0;
		}

		// Token: 0x06038843 RID: 231491 RVA: 0x00E51854 File Offset: 0x00E4FA54
		public bool CheckIfMotorSkinGoods()
		{
			return this.GetRewardMotorSkinId() != 0;
		}

		// Token: 0x06038844 RID: 231492 RVA: 0x00E5185F File Offset: 0x00E4FA5F
		public bool HasCloudGameInfo()
		{
			return this.Data.CloudGameTime > 0;
		}

		// Token: 0x06038845 RID: 231493 RVA: 0x00E5186F File Offset: 0x00E4FA6F
		public string GetCloudGameDesc()
		{
			if (!this.HasCloudGameInfo())
			{
				return "";
			}
			return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(this.Data.CloudGameDesc, null), new string[]
			{
				this.Data.CloudGameTime.ToString()
			});
		}

		// Token: 0x06038846 RID: 231494 RVA: 0x00E518AE File Offset: 0x00E4FAAE
		public string GetCloudGameIcon()
		{
			return this.Data.CloudGameIcon;
		}

		// Token: 0x06038847 RID: 231495 RVA: 0x00E518BB File Offset: 0x00E4FABB
		public bool GetIfShowTotalTopUpScore()
		{
			return ControllerBase<TotalTopUpController>.Instance.GetGoodsScore(this.GetGoodsId()) > 0;
		}

		// Token: 0x0402042D RID: 132141
		private bool IsOnSell;

		// Token: 0x0402042E RID: 132142
		public PayShopDefine.EPayShopTabType PayShopId = PayShopDefine.EPayShopTabType.Recommend;

		// Token: 0x0402042F RID: 132143
		[Nullable(2)]
		private PayShopItemBaseSt CachePayShopItemBaseSt;

		// Token: 0x04020430 RID: 132144
		private int PayGiftId;
	}
}
