using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x0200204B RID: 8267
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ItemExchangeModel : ModelBase<ItemExchangeModel>
{
	// Token: 0x0600FBD0 RID: 64464 RVA: 0x004524CE File Offset: 0x004506CE
	protected override bool OnInit()
	{
		this.ItemExchangeTimeInfo = new Dictionary<int, ItemExchangeInfo>();
		return true;
	}

	// Token: 0x0600FBD1 RID: 64465 RVA: 0x004524DC File Offset: 0x004506DC
	protected override bool OnClear()
	{
		this.ItemExchangeTimeInfo = null;
		return true;
	}

	// Token: 0x0600FBD2 RID: 64466 RVA: 0x004524E8 File Offset: 0x004506E8
	public void InitItemExchangeTimeInfo(List<ItemExchangeInfo> info)
	{
		foreach (ItemExchangeInfo itemExchangeInfo in info)
		{
			this.ItemExchangeTimeInfo[itemExchangeInfo.ItemId] = itemExchangeInfo;
		}
	}

	// Token: 0x0600FBD3 RID: 64467 RVA: 0x00452544 File Offset: 0x00450744
	[NullableContext(2)]
	public ItemExchangeInfo GetExchangeInfo(int itemId)
	{
		ItemExchangeInfo itemExchangeInfo;
		this.ItemExchangeTimeInfo.TryGetValue(itemId, out itemExchangeInfo);
		if (itemExchangeInfo == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ItemExchange;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "前后端版本可能不一致, 当前兑换的道具并没有后端配置!";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		ItemExchangeInfo result;
		this.ItemExchangeTimeInfo.TryGetValue(itemId, out result);
		return result;
	}

	// Token: 0x0600FBD4 RID: 64468 RVA: 0x004525A4 File Offset: 0x004507A4
	public int GetExChangeTime(int itemId)
	{
		ItemExchangeInfo itemExchangeInfo;
		this.ItemExchangeTimeInfo.TryGetValue(itemId, out itemExchangeInfo);
		if (itemExchangeInfo == null)
		{
			return 0;
		}
		return itemExchangeInfo.TodayTimes;
	}

	// Token: 0x0600FBD5 RID: 64469 RVA: 0x004525CC File Offset: 0x004507CC
	public void AddExchangeTime(int itemId, int exChangeTimes)
	{
		ItemExchangeInfo itemExchangeInfo;
		this.ItemExchangeTimeInfo.TryGetValue(itemId, out itemExchangeInfo);
		if (itemExchangeInfo != null)
		{
			itemExchangeInfo.TotalTimes += exChangeTimes;
			itemExchangeInfo.TodayTimes += exChangeTimes;
		}
	}

	// Token: 0x0600FBD6 RID: 64470 RVA: 0x00452608 File Offset: 0x00450808
	[NullableContext(2)]
	public ExchangeSimulation CalculateConsume(int itemId, int needCount = 0, int exChangeTime = 0, bool ignore = false)
	{
		int num = needCount;
		if (exChangeTime > 0)
		{
			num = 999999999;
		}
		IReadOnlyList<ItemExchangeContent> exChangeConfigList = ConfigBase<ItemExchangeConfig>.Instance.GetExChangeConfigList(itemId);
		if (exChangeConfigList == null || exChangeConfigList.Count <= 0)
		{
			return null;
		}
		int i = 0;
		int num2 = exChangeConfigList.Count - 1;
		int num3 = this.GetExChangeTime(itemId) + 1;
		int num4 = 0;
		for (int j = num2; j >= 0; j--)
		{
			ItemExchangeContent itemExchangeContent = exChangeConfigList[j];
			if (num3 >= itemExchangeContent.Times)
			{
				i = j;
				int? num5 = null;
				using (Dictionary<int, int>.Enumerator enumerator = itemExchangeContent.Consume().GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						KeyValuePair<int, int> keyValuePair = enumerator.Current;
						num5 = new int?(keyValuePair.Key);
					}
				}
				num4 = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(num5.Value, 0);
				break;
			}
		}
		int restExChangeTime = this.GetRestExChangeTime(itemId);
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		while (i <= num2)
		{
			ItemExchangeContent itemExchangeContent2 = exChangeConfigList[i];
			ItemExchangeContent? itemExchangeContent3 = (i < num2) ? new ItemExchangeContent?(exChangeConfigList[i + 1]) : null;
			int num9 = (int)Math.Ceiling((double)(num - num7) / (double)itemExchangeContent2.GainCount);
			if (itemExchangeContent3 != null)
			{
				int val = itemExchangeContent3.Value.Times - itemExchangeContent2.Times;
				num9 = Math.Min(num9, val);
			}
			if (exChangeTime > 0 && num9 + num6 > exChangeTime)
			{
				num9 = exChangeTime - num6;
			}
			if (num9 + num6 > restExChangeTime)
			{
				num9 = restExChangeTime - num6;
			}
			int? num10 = null;
			using (Dictionary<int, int>.Enumerator enumerator = itemExchangeContent2.Consume().GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<int, int> keyValuePair2 = enumerator.Current;
					num10 = new int?(keyValuePair2.Value);
				}
			}
			if (!ignore && num8 + num9 * num10.Value > num4)
			{
				num9 = (int)Math.Floor((double)(num4 - num8) / (double)num10.Value);
			}
			num8 += num9 * num10.Value;
			num6 += num9;
			num7 += num9 * itemExchangeContent2.GainCount;
			if (num7 >= num || (exChangeTime > 0 && num6 >= exChangeTime) || num6 >= restExChangeTime || num8 >= num4)
			{
				break;
			}
			i++;
		}
		return new ExchangeSimulation
		{
			ExChangeTime = num6,
			ExChangeCount = num7,
			ConsumeCount = num8
		};
	}

	// Token: 0x0600FBD7 RID: 64471 RVA: 0x00452880 File Offset: 0x00450A80
	private int GetRestExChangeTime(int itemId)
	{
		ItemExchangeInfo exchangeInfo = this.GetExchangeInfo(itemId);
		int val = (exchangeInfo.TotalLimit > 0) ? (exchangeInfo.TotalLimit - exchangeInfo.TotalTimes) : 999999999;
		int val2 = (exchangeInfo.DailyLimit > 0) ? (exchangeInfo.DailyLimit - exchangeInfo.TodayTimes) : 999999999;
		return Math.Min(val, val2);
	}

	// Token: 0x0600FBD8 RID: 64472 RVA: 0x004528D8 File Offset: 0x00450AD8
	public ExchangeInfo GetCurExchangeInfo(int itemId, int addTime = 0)
	{
		ExchangeInfo exchangeInfo = new ExchangeInfo();
		IReadOnlyList<ItemExchangeContent> exChangeConfigList = ConfigBase<ItemExchangeConfig>.Instance.GetExChangeConfigList(itemId);
		if (exChangeConfigList == null)
		{
			return exchangeInfo;
		}
		int num = this.GetExChangeTime(itemId) + addTime + 1;
		foreach (ItemExchangeContent itemExchangeContent in exChangeConfigList)
		{
			if (num < itemExchangeContent.Times)
			{
				break;
			}
			foreach (KeyValuePair<int, int> keyValuePair in itemExchangeContent.Consume())
			{
				exchangeInfo.ConsumeCount = keyValuePair.Value;
				exchangeInfo.GainCount = itemExchangeContent.GainCount;
			}
		}
		return exchangeInfo;
	}

	// Token: 0x0600FBD9 RID: 64473 RVA: 0x004529A4 File Offset: 0x00450BA4
	public bool CheckIsMaxExChangeTime(int itemId, int addTime = 0)
	{
		ItemExchangeInfo exchangeInfo = this.GetExchangeInfo(itemId);
		return (exchangeInfo.TotalLimit > 0 && exchangeInfo.TotalTimes + addTime >= exchangeInfo.TotalLimit) || (exchangeInfo.DailyLimit > 0 && exchangeInfo.TodayTimes + addTime >= exchangeInfo.DailyLimit);
	}

	// Token: 0x0600FBDA RID: 64474 RVA: 0x004529F0 File Offset: 0x00450BF0
	public int GetMaxExChangeTime(int itemId)
	{
		int restExChangeTime = this.GetRestExChangeTime(itemId);
		ExchangeSimulation exchangeSimulation = this.CalculateConsume(itemId, 0, restExChangeTime, false);
		if (exchangeSimulation == null)
		{
			return 0;
		}
		return exchangeSimulation.ExChangeTime;
	}

	// Token: 0x040078E2 RID: 30946
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, ItemExchangeInfo> ItemExchangeTimeInfo;
}
