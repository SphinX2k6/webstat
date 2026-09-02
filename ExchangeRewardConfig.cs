using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;

// Token: 0x020018AF RID: 6319
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ExchangeRewardConfig : ConfigBase<ExchangeRewardConfig>
{
	// Token: 0x0600B5A5 RID: 46501 RVA: 0x003056AC File Offset: 0x003038AC
	public ExchangeReward? GetExchangeRewardConfig(int? id)
	{
		if (id == null || id.Value == 0)
		{
			return null;
		}
		return ConfigExchangeRewardById.GetConfig(id.Value, true);
	}

	// Token: 0x0600B5A6 RID: 46502 RVA: 0x003056E4 File Offset: 0x003038E4
	public ExchangeShared? GetExchangeShareConfig(int? id)
	{
		if (id == null || id.Value == 0)
		{
			return null;
		}
		return ConfigExchangeSharedById.GetConfig(id.Value, true);
	}

	// Token: 0x0600B5A7 RID: 46503 RVA: 0x0030571C File Offset: 0x0030391C
	public List<TItem> GetExchangeRewardPreviewRewardList(int exchangeId, int? worldLevel = null)
	{
		if (exchangeId == 0)
		{
			return new List<TItem>();
		}
		ExchangeReward? exchangeRewardConfig = this.GetExchangeRewardConfig(new int?(exchangeId));
		List<TItem> list = new List<TItem>();
		if (exchangeRewardConfig == null)
		{
			return list;
		}
		Dictionary<int, IntIntMap> dictionary = exchangeRewardConfig.Value.PreviewReward();
		int num = (worldLevel.GetValueOrDefault() != 0) ? worldLevel.Value : ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
		Dictionary<int, int> dictionary2 = null;
		if (dictionary.ContainsKey(num))
		{
			int mapIntIntLength = dictionary[num].MapIntIntLength;
			for (int i = 0; i < mapIntIntLength; i++)
			{
				DicIntInt value = dictionary[num].MapIntInt(i).Value;
				if (dictionary2 == null)
				{
					dictionary2 = new Dictionary<int, int>();
				}
				dictionary2.Add(value.Key, value.Value);
			}
		}
		else
		{
			for (int j = num - 1; j >= 0; j--)
			{
				if (dictionary.ContainsKey(j))
				{
					int mapIntIntLength2 = dictionary[j].MapIntIntLength;
					for (int k = 0; k < mapIntIntLength2; k++)
					{
						DicIntInt value2 = dictionary[j].MapIntInt(k).Value;
						if (dictionary2 == null)
						{
							dictionary2 = new Dictionary<int, int>();
						}
						dictionary2.Add(value2.Key, value2.Value);
					}
					break;
				}
			}
		}
		if (dictionary2 == null)
		{
			Dictionary<int, int> dictionary3 = exchangeRewardConfig.Value.RewardId();
			int num2 = 0;
			if (dictionary3.ContainsKey(num))
			{
				num2 = dictionary3[num];
			}
			else
			{
				for (int l = num - 1; l >= 0; l--)
				{
					if (dictionary3.ContainsKey(l))
					{
						num2 = dictionary3[l];
						break;
					}
				}
			}
			if (num2 > 0)
			{
				DropPackage? config = ConfigDropPackageById.GetConfig(num2, true);
				if (config != null)
				{
					dictionary2 = config.Value.DropPreview();
				}
			}
		}
		if (dictionary2 != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in dictionary2)
			{
				int key = keyValuePair.Key;
				int value3 = keyValuePair.Value;
				TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), value3);
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x0600B5A8 RID: 46504 RVA: 0x00305960 File Offset: 0x00303B60
	public int GetExchangeRewardMaxCount(int id)
	{
		if (this.GetExchangeRewardConfig(new int?(id)) == null)
		{
			return 0;
		}
		ExchangeReward? exchangeReward;
		return exchangeReward.GetValueOrDefault().MaxCount;
	}

	// Token: 0x0600B5A9 RID: 46505 RVA: 0x00305994 File Offset: 0x00303B94
	public int GetShareMaxCount(int id)
	{
		if (this.GetExchangeShareConfig(new int?(id)) == null)
		{
			return 0;
		}
		ExchangeShared? exchangeShared;
		return exchangeShared.GetValueOrDefault().MaxCount;
	}

	// Token: 0x0600B5AA RID: 46506 RVA: 0x003059C8 File Offset: 0x00303BC8
	public Dictionary<int, int> GetShareCost(int id)
	{
		ExchangeShared? exchangeShared;
		return ((this.GetExchangeShareConfig(new int?(id)) != null) ? exchangeShared.GetValueOrDefault().Cost() : null) ?? new Dictionary<int, int>();
	}

	// Token: 0x0600B5AB RID: 46507 RVA: 0x00305A08 File Offset: 0x00303C08
	[NullableContext(2)]
	public Dictionary<int, int> GetExchangeCost(int id)
	{
		ExchangeReward? exchangeRewardConfig = this.GetExchangeRewardConfig(new int?(id));
		if (exchangeRewardConfig == null)
		{
			return null;
		}
		return exchangeRewardConfig.Value.Cost();
	}

	// Token: 0x0600B5AC RID: 46508 RVA: 0x00305A3C File Offset: 0x00303C3C
	public int? GetExchangeShareId(int id)
	{
		ExchangeReward? exchangeRewardConfig = this.GetExchangeRewardConfig(new int?(id));
		if (exchangeRewardConfig == null)
		{
			return null;
		}
		return new int?(exchangeRewardConfig.Value.SharedId);
	}
}
