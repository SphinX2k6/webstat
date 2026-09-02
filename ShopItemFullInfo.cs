using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02002A00 RID: 10752
[NullableContext(1)]
[Nullable(0)]
public class ShopItemFullInfo
{
	// Token: 0x06015730 RID: 87856 RVA: 0x005F18FC File Offset: 0x005EFAFC
	public ShopItemFullInfo(ItemConfig itemInfo, ShopItemInfoNew boughtInfo, int shopId)
	{
		this.ItemInfo = itemInfo;
		this.BoughtCount = boughtInfo.BoughtCount;
		this.IsLocked = boughtInfo.Lock;
		this.BuyLimit = boughtInfo.LimitNum;
		this.StackSize = boughtInfo.ItemNum;
		for (int i = 0; i < boughtInfo.MoneyList.Count; i++)
		{
			ShoppMoneyInfo shoppMoneyInfo = boughtInfo.MoneyList[i];
			ShoppMoneyInfo shoppMoneyInfo2 = null;
			foreach (ShoppMoneyInfo shoppMoneyInfo3 in boughtInfo.OriginalMoneyList)
			{
				if (shoppMoneyInfo3.MoneyId == shoppMoneyInfo.MoneyId)
				{
					shoppMoneyInfo2 = shoppMoneyInfo3;
					break;
				}
			}
			ItemPrice itemPrice = new ItemPrice(shoppMoneyInfo.MoneyId, shoppMoneyInfo.MoneyNum, (shoppMoneyInfo2 != null) ? shoppMoneyInfo2.MoneyNum : -1);
			this.Price[shoppMoneyInfo.MoneyId] = itemPrice;
			if (i == 0)
			{
				this.DefaultPrice = itemPrice;
			}
		}
		this.Id = boughtInfo.Id;
		this.Label = boughtInfo.Label;
		this.BeginTime = boughtInfo.BeginTime;
		this.EndTime = boughtInfo.EndTime;
		if (boughtInfo.UnlockConditionId != 0)
		{
			ConditionGroup? conditionGroupConfig = ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(boughtInfo.UnlockConditionId);
			this.ConditionText = (((conditionGroupConfig != null) ? conditionGroupConfig.GetValueOrDefault().HintText : null) ?? "");
		}
		this.SwitchText = boughtInfo.SwitchText;
		this.PurchaseText = boughtInfo.PurchaseText;
		this.ItemId = boughtInfo.ItemId;
		this.ShopId = shopId;
		this.SortIndex = boughtInfo.SortIndex;
	}

	// Token: 0x17001BFA RID: 7162
	// (get) Token: 0x06015731 RID: 87857 RVA: 0x005F1AC0 File Offset: 0x005EFCC0
	public string LockInfo
	{
		get
		{
			if (this.BeginTime > 0U && this.BeginTime > Singleton<TimeUtil>.Instance.GetServerTime())
			{
				int num = (int)Math.Truncate(this.BeginTime - Singleton<TimeUtil>.Instance.GetServerTime());
				int num2 = num / 86400;
				int num3 = num % 86400 / 3600;
				int num4 = num % 3600 / 60;
				int num5 = num % 60;
				if (num2 > 0)
				{
					return StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("ShopLockTime1"), new string[]
					{
						num2.ToString()
					});
				}
				if (num3 > 0)
				{
					return StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("ShopLockTime2"), new string[]
					{
						num3.ToString()
					});
				}
				if (num4 > 0)
				{
					return StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("ShopLockTime3"), new string[]
					{
						num4.ToString()
					});
				}
				return StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("ShopLockTime4"), new string[]
				{
					num5.ToString()
				});
			}
			else
			{
				if (this.IsLocked)
				{
					return this.ConditionText;
				}
				return "";
			}
		}
	}

	// Token: 0x06015732 RID: 87858 RVA: 0x005F1BE2 File Offset: 0x005EFDE2
	public bool IsUnlocked()
	{
		return (this.BeginTime <= 0U || this.BeginTime <= Singleton<TimeUtil>.Instance.GetServerTime()) && !this.IsLocked;
	}

	// Token: 0x06015733 RID: 87859 RVA: 0x005F1C0C File Offset: 0x005EFE0C
	public bool InSellTime()
	{
		return this.EndTime <= 0U || (Singleton<TimeUtil>.Instance.GetServerTime() >= this.BeginTime && this.EndTime > Singleton<TimeUtil>.Instance.GetServerTime());
	}

	// Token: 0x06015734 RID: 87860 RVA: 0x005F1C43 File Offset: 0x005EFE43
	public bool IsAffordable(int count = 1)
	{
		return this.DefaultPrice != null && ShopUtils.GetResource(this.DefaultPrice.CoinId) >= this.DefaultPrice.CoinPrice * count;
	}

	// Token: 0x06015735 RID: 87861 RVA: 0x005F1C74 File Offset: 0x005EFE74
	public int GetMaxBuyCount()
	{
		if (this.DefaultPrice == null)
		{
			return -1;
		}
		int num = (int)Math.Truncate((double)(ShopUtils.GetResource(this.DefaultPrice.CoinId) / this.DefaultPrice.CoinPrice));
		if (this.BuyLimit > 0)
		{
			return Math.Min(this.BuyLimit - this.BoughtCount, num);
		}
		return num;
	}

	// Token: 0x06015736 RID: 87862 RVA: 0x005F1CCD File Offset: 0x005EFECD
	public bool IsOutOfDate()
	{
		return this.EndTime > 0U && this.EndTime < Singleton<TimeUtil>.Instance.GetServerTime();
	}

	// Token: 0x06015737 RID: 87863 RVA: 0x005F1CEF File Offset: 0x005EFEEF
	public bool IsSoldOut()
	{
		return this.BuyLimit > 0 && this.BoughtCount == this.BuyLimit;
	}

	// Token: 0x06015738 RID: 87864 RVA: 0x005F1D0C File Offset: 0x005EFF0C
	public bool InSaleTime()
	{
		if (this.BeginTime > 0U && this.EndTime > 0U)
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return this.BeginTime < serverTime && serverTime < this.EndTime;
		}
		return false;
	}

	// Token: 0x06015739 RID: 87865 RVA: 0x005F1D50 File Offset: 0x005EFF50
	public bool IsOutOfStock()
	{
		return (this.BuyLimit > 0 && this.BoughtCount == this.BuyLimit) || (this.EndTime > 0U && this.EndTime < Singleton<TimeUtil>.Instance.GetServerTime());
	}

	// Token: 0x0601573A RID: 87866 RVA: 0x005F1D8B File Offset: 0x005EFF8B
	public bool IsInteractive()
	{
		return this.IsUnlocked() && !this.IsOutOfStock();
	}

	// Token: 0x0601573B RID: 87867 RVA: 0x005F1DA0 File Offset: 0x005EFFA0
	public int GetMoneyId()
	{
		if (this.DefaultPrice == null)
		{
			return -1;
		}
		return this.DefaultPrice.CoinId;
	}

	// Token: 0x0601573C RID: 87868 RVA: 0x005F1DB7 File Offset: 0x005EFFB7
	public int GetDefaultPrice()
	{
		if (this.DefaultPrice == null)
		{
			return -1;
		}
		return this.DefaultPrice.CoinPrice;
	}

	// Token: 0x0601573D RID: 87869 RVA: 0x005F1DD0 File Offset: 0x005EFFD0
	public int GetPrice(int moneyId)
	{
		if (this.Price == null || this.Price.Count == 0)
		{
			return -1;
		}
		ItemPrice itemPrice;
		if (this.Price.TryGetValue(moneyId, out itemPrice))
		{
			return itemPrice.CoinPrice;
		}
		return 0;
	}

	// Token: 0x0601573E RID: 87870 RVA: 0x005F1E0C File Offset: 0x005F000C
	public int GetOriginalPrice()
	{
		if (this.DefaultPrice == null)
		{
			return -1;
		}
		return this.DefaultPrice.OriginalPrice;
	}

	// Token: 0x0400A50A RID: 42250
	public ItemConfig ItemInfo;

	// Token: 0x0400A50B RID: 42251
	public readonly int ItemId;

	// Token: 0x0400A50C RID: 42252
	public int BoughtCount;

	// Token: 0x0400A50D RID: 42253
	public int BuyLimit;

	// Token: 0x0400A50E RID: 42254
	public int StackSize;

	// Token: 0x0400A50F RID: 42255
	[Nullable(2)]
	public ItemPrice DefaultPrice;

	// Token: 0x0400A510 RID: 42256
	public Dictionary<int, ItemPrice> Price = new Dictionary<int, ItemPrice>();

	// Token: 0x0400A511 RID: 42257
	public uint BeginTime;

	// Token: 0x0400A512 RID: 42258
	public uint EndTime;

	// Token: 0x0400A513 RID: 42259
	public bool IsLocked;

	// Token: 0x0400A514 RID: 42260
	public string ConditionText = "";

	// Token: 0x0400A515 RID: 42261
	public int Id;

	// Token: 0x0400A516 RID: 42262
	public int ShopId;

	// Token: 0x0400A517 RID: 42263
	public string Label;

	// Token: 0x0400A518 RID: 42264
	public string SwitchText;

	// Token: 0x0400A519 RID: 42265
	public string PurchaseText;

	// Token: 0x0400A51A RID: 42266
	public int SortIndex;
}
