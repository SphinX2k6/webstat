using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02002604 RID: 9732
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class PowerModel : ModelBase<PowerModel>
{
	// Token: 0x170017D3 RID: 6099
	// (get) Token: 0x06013118 RID: 78104 RVA: 0x005490B0 File Offset: 0x005472B0
	public unsafe List<PowerItemInfo> PowerItemInfoList
	{
		get
		{
			if (this.PowerItemInfos == null)
			{
				Dictionary<int, int> confSortRule = ConfigBase<PowerConfig>.Instance.GetConfSortRule();
				ItemInfo?[] array = ArrayPool<ItemInfo?>.Shared.Rent(confSortRule.Keys.Count);
				try
				{
					int num = 0;
					foreach (int p0Id in confSortRule.Keys)
					{
						ItemInfo? config = ConfigItemInfoById.GetConfig(p0Id, true);
						array[num++] = config;
					}
					this.PowerItemInfos = new List<PowerItemInfo>(confSortRule.Keys.Count);
					Span<ItemInfo?> span = array.AsSpan(0, confSortRule.Keys.Count);
					for (int i = 0; i < span.Length; i++)
					{
						ItemInfo? itemInfo = *span[i];
						if (itemInfo != null)
						{
							PowerItemInfo powerItemInfo = new PowerItemInfo(itemInfo.Value.Id)
							{
								ItemName = itemInfo.Value.Name
							};
							int num2;
							if (confSortRule.TryGetValue(powerItemInfo.ItemId, out num2))
							{
								powerItemInfo.IsHideWhenZero = (num2 != 0);
							}
							this.PowerItemInfos.Add(powerItemInfo);
						}
					}
				}
				finally
				{
					ArrayPool<ItemInfo?>.Shared.Return(array, false);
				}
				List<int> confSortList = confSortRule.Keys.ToList<int>();
				this.PowerItemInfos.Sort(delegate(PowerItemInfo info1, PowerItemInfo info2)
				{
					int num5 = confSortList.IndexOf(info1.ItemId);
					int num6 = confSortList.IndexOf(info2.ItemId);
					return num5 - num6;
				});
			}
			foreach (PowerItemInfo powerItemInfo2 in this.PowerItemInfos)
			{
				int? num3 = new int?(0);
				num3 = new int?(ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(powerItemInfo2.ItemId, 0));
				powerItemInfo2.StackValue = num3.GetValueOrDefault();
				List<ShopItemFullInfo> shopItemInfoByShopId = this.GetShopItemInfoByShopId(powerItemInfo2.ShopId);
				int num4 = -1;
				for (int j = 0; j < shopItemInfoByShopId.Count; j++)
				{
					ShopItemFullInfo shopItemFullInfo = shopItemInfoByShopId[j];
					if (!shopItemFullInfo.IsSoldOut() && shopItemFullInfo.Price.ContainsKey(powerItemInfo2.ItemId))
					{
						num4 = j;
						break;
					}
				}
				if (num4 == -1)
				{
					List<ShopItemFullInfo> list = shopItemInfoByShopId;
					ShopItemFullInfo shopItemFullInfo2 = list[list.Count - 1];
					powerItemInfo2.RenewValue = ((powerItemInfo2.ItemId == 6) ? 0 : shopItemFullInfo2.StackSize);
					powerItemInfo2.CostValue = shopItemFullInfo2.GetPrice(powerItemInfo2.ItemId);
					powerItemInfo2.GoodsId = shopItemFullInfo2.Id;
					powerItemInfo2.RemainCount = ((powerItemInfo2.ItemId == 6) ? powerItemInfo2.StackValue : 0);
				}
				num4 = -1;
				for (int k = 0; k < shopItemInfoByShopId.Count; k++)
				{
					ShopItemFullInfo shopItemFullInfo3 = shopItemInfoByShopId[k];
					if (shopItemFullInfo3.IsUnlocked() && !shopItemFullInfo3.IsSoldOut() && shopItemFullInfo3.Price.ContainsKey(powerItemInfo2.ItemId))
					{
						num4 = k;
						break;
					}
				}
				if (num4 >= 0)
				{
					ShopItemFullInfo shopItemFullInfo4 = shopItemInfoByShopId[num4];
					powerItemInfo2.RenewValue = ((powerItemInfo2.ItemId == 6) ? 0 : shopItemFullInfo4.StackSize);
					powerItemInfo2.CostValue = shopItemFullInfo4.GetPrice(powerItemInfo2.ItemId);
					powerItemInfo2.GoodsId = shopItemFullInfo4.Id;
					int remainCount = (shopItemFullInfo4.BuyLimit < 0) ? shopItemFullInfo4.BuyLimit : (shopItemInfoByShopId.Count - num4);
					powerItemInfo2.RemainCount = remainCount;
				}
			}
			return this.PowerItemInfos;
		}
	}

	// Token: 0x06013119 RID: 78105 RVA: 0x00549464 File Offset: 0x00547664
	[NullableContext(2)]
	public PowerItemInfo GetPowerItemInfos(int itemId)
	{
		foreach (PowerItemInfo powerItemInfo in this.PowerItemInfoList)
		{
			if (powerItemInfo.ItemId == itemId)
			{
				return powerItemInfo;
			}
		}
		return null;
	}

	// Token: 0x170017D4 RID: 6100
	// (get) Token: 0x0601311A RID: 78106 RVA: 0x005494C0 File Offset: 0x005476C0
	public bool NeedUpdateCountDown
	{
		get
		{
			return this.GetPowerDataById(5).GetNeedUpdateFlag();
		}
	}

	// Token: 0x170017D5 RID: 6101
	// (get) Token: 0x0601311B RID: 78107 RVA: 0x005494CE File Offset: 0x005476CE
	public int PowerCount
	{
		get
		{
			return this.GetPowerDataById(5).GetCurrentPower();
		}
	}

	// Token: 0x170017D6 RID: 6102
	// (get) Token: 0x0601311C RID: 78108 RVA: 0x005494DC File Offset: 0x005476DC
	public int PowerWithConvertedCount
	{
		get
		{
			PowerData powerDataById = this.GetPowerDataById(5);
			PowerData powerDataById2 = this.GetPowerDataById(6);
			return powerDataById.GetCurrentPower() + powerDataById2.GetCurrentPower();
		}
	}

	// Token: 0x0601311D RID: 78109 RVA: 0x00549504 File Offset: 0x00547704
	protected override bool OnInit()
	{
		this.PowerItemMap[10800] = 5;
		this.PowerItemMap[6] = 6;
		this.CanShowPowerTip = true;
		return true;
	}

	// Token: 0x0601311E RID: 78110 RVA: 0x0054952C File Offset: 0x0054772C
	protected override bool OnClear()
	{
		this.CanShowPowerTip = false;
		return true;
	}

	// Token: 0x0601311F RID: 78111 RVA: 0x00549538 File Offset: 0x00547738
	public void UpdatePowerRenewTimer()
	{
		foreach (KeyValuePair<int, PowerData> keyValuePair in this.PowerMap)
		{
			keyValuePair.Value.CheckPowerUpdate();
		}
	}

	// Token: 0x06013120 RID: 78112 RVA: 0x00549590 File Offset: 0x00547790
	public void UpdatePowerData([Nullable(new byte[]
	{
		2,
		1
	})] EnergyInfo[] data)
	{
		if (data == null)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.PowerModule;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "当前体力数据";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("data", data);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		foreach (EnergyInfo data2 in data)
		{
			this.RefreshPowerInfos(data2);
		}
	}

	// Token: 0x06013121 RID: 78113 RVA: 0x005495E4 File Offset: 0x005477E4
	[NullableContext(2)]
	public void RefreshPowerInfos(EnergyInfo data)
	{
		if (data == null)
		{
			return;
		}
		int id = data.Id;
		this.GetPowerDataById(id).Phrase(id, data.EnergyCount, (double)data.LastRenewEnergyTime);
	}

	// Token: 0x06013122 RID: 78114 RVA: 0x00549616 File Offset: 0x00547816
	public bool CheckItemIfPowerItem(int itemId)
	{
		return this.PowerItemKeyArray.Contains(itemId);
	}

	// Token: 0x06013123 RID: 78115 RVA: 0x00549624 File Offset: 0x00547824
	public PowerData GetPowerDataById(int itemId)
	{
		int key = itemId;
		int num;
		if (this.PowerItemMap.TryGetValue(itemId, out num))
		{
			key = num;
		}
		PowerData powerData;
		if (!this.PowerMap.TryGetValue(key, out powerData))
		{
			if (itemId == 6)
			{
				powerData = new OverPowerData();
			}
			else
			{
				powerData = new PowerData();
			}
			this.PowerMap.Add(key, powerData);
		}
		return powerData;
	}

	// Token: 0x06013124 RID: 78116 RVA: 0x00549678 File Offset: 0x00547878
	private List<ShopItemFullInfo> GetShopItemInfoByShopId(int shopId)
	{
		List<ShopItemFullInfo> shopItemList = ModelBase<ShopModel>.Instance.GetShopItemList(shopId);
		if (shopItemList.Count == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.PowerModule, ELogAuthor.LK, "体力系统获取商店数据失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return shopItemList;
		}
		shopItemList.Sort((ShopItemFullInfo info1, ShopItemFullInfo info2) => info1.Id - info2.Id);
		return shopItemList;
	}

	// Token: 0x06013125 RID: 78117 RVA: 0x005496E0 File Offset: 0x005478E0
	public bool IsPowerEnough(int? neededPower)
	{
		bool flag = (neededPower ?? 0) == 0;
		return flag || this.PowerCount >= neededPower.Value;
	}

	// Token: 0x06013126 RID: 78118 RVA: 0x0054971C File Offset: 0x0054791C
	public bool IsPowerWithConvertedEnough(int? neededPower)
	{
		bool flag = (neededPower ?? 0) == 0;
		return flag || this.PowerWithConvertedCount >= neededPower.Value;
	}

	// Token: 0x06013127 RID: 78119 RVA: 0x00549758 File Offset: 0x00547958
	public int GetCurrentNeedPower(int? neededPower)
	{
		if (this.IsPowerEnough(neededPower))
		{
			return 0;
		}
		if (neededPower == null)
		{
			return 0;
		}
		return neededPower.Value - this.PowerCount;
	}

	// Token: 0x06013128 RID: 78120 RVA: 0x0054977E File Offset: 0x0054797E
	public ShopFixed? GetOverPowerShopConfig()
	{
		return ConfigBase<ShopConfig>.Instance.GetShopFixedInfoByItemId(7, 17);
	}

	// Token: 0x06013129 RID: 78121 RVA: 0x0054978D File Offset: 0x0054798D
	public bool GetCanShowPowerTip()
	{
		return this.CanShowPowerTip;
	}

	// Token: 0x0601312A RID: 78122 RVA: 0x00549795 File Offset: 0x00547995
	public void SetCanShowPowerTip(bool state)
	{
		this.CanShowPowerTip = state;
	}

	// Token: 0x040094D6 RID: 38102
	private const int OVERPOWERSHOPID = 17;

	// Token: 0x040094D7 RID: 38103
	private readonly Dictionary<int, int> PowerItemMap = new Dictionary<int, int>();

	// Token: 0x040094D8 RID: 38104
	public int CurrentNeedPower;

	// Token: 0x040094D9 RID: 38105
	public int[] PowerItemKeyArray = new int[]
	{
		5,
		6
	};

	// Token: 0x040094DA RID: 38106
	private readonly Dictionary<int, PowerData> PowerMap = new Dictionary<int, PowerData>();

	// Token: 0x040094DB RID: 38107
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<PowerItemInfo> PowerItemInfos;

	// Token: 0x040094DC RID: 38108
	private bool CanShowPowerTip = true;

	// Token: 0x0200898D RID: 35213
	[NullableContext(0)]
	public enum EOverPowerRecoveryMode
	{
		// Token: 0x0402E68C RID: 190092
		Update,
		// Token: 0x0402E68D RID: 190093
		Stop,
		// Token: 0x0402E68E RID: 190094
		Full
	}
}
