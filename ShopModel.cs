using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;

// Token: 0x020029F9 RID: 10745
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ShopModel : ModelBase<ShopModel>
{
	// Token: 0x17001BF6 RID: 7158
	// (get) Token: 0x060156F1 RID: 87793 RVA: 0x005F035C File Offset: 0x005EE55C
	// (set) Token: 0x060156F2 RID: 87794 RVA: 0x005F0364 File Offset: 0x005EE564
	public string VersionId
	{
		get
		{
			return this.Version;
		}
		set
		{
			this.Version = value;
		}
	}

	// Token: 0x060156F3 RID: 87795 RVA: 0x005F036D File Offset: 0x005EE56D
	protected override bool OnInit()
	{
		this.ShopList = new Dictionary<int, Shop>();
		return true;
	}

	// Token: 0x060156F4 RID: 87796 RVA: 0x005F037C File Offset: 0x005EE57C
	[NullableContext(2)]
	public Shop GetShopInfo(int shopId)
	{
		if (this.ShopList == null)
		{
			return null;
		}
		Shop result;
		if (this.ShopList.TryGetValue(shopId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x060156F5 RID: 87797 RVA: 0x005F03A8 File Offset: 0x005EE5A8
	[NullableContext(2)]
	public ShopItemInfoNew GetShopItem(int shopId, int id)
	{
		Shop shopInfo = this.GetShopInfo(shopId);
		if (shopInfo == null)
		{
			return null;
		}
		return shopInfo.GetItemInfo(id);
	}

	// Token: 0x060156F6 RID: 87798 RVA: 0x005F03C9 File Offset: 0x005EE5C9
	public Aki.Config.ShopInfo? GetShopConfig(int shopId)
	{
		return new Aki.Config.ShopInfo?(ConfigBase<ShopConfig>.Instance.GetShopInfoConfig(shopId));
	}

	// Token: 0x060156F7 RID: 87799 RVA: 0x005F03DC File Offset: 0x005EE5DC
	public void UpdateShopListData(List<Aki.Protocol.ShopInfo> shopInfoList)
	{
		foreach (Aki.Protocol.ShopInfo shopInfo in shopInfoList)
		{
			this.UpdateShopData(shopInfo);
		}
	}

	// Token: 0x060156F8 RID: 87800 RVA: 0x005F042C File Offset: 0x005EE62C
	public void UpdateShopData(Aki.Protocol.ShopInfo shopInfo)
	{
		Shop shop = this.GetShopInfo(shopInfo.ShopId);
		if (shop == null)
		{
			shop = new Shop(shopInfo);
			this.ShopList.Add(shopInfo.ShopId, shop);
		}
		else
		{
			shop.UpdateRefreshTime(shopInfo.UpdateTime);
			shop.UpdateShopItemList(shopInfo.ItemInfoList.ToList<ShopItemInfoNew>());
		}
		Singleton<EventSystem>.Instance.Emit<int?>(EEventName.ShopUpdate, new int?(shopInfo.ShopId));
	}

	// Token: 0x060156F9 RID: 87801 RVA: 0x005F049C File Offset: 0x005EE69C
	public void UpdateItemData(ShopBuyResponse shopBuyResponse)
	{
		ShopItemInfoNew shopItem = this.GetShopItem(shopBuyResponse.ShopId, shopBuyResponse.Id);
		if (shopItem == null)
		{
			return;
		}
		shopItem.BoughtCount = shopBuyResponse.BoughtCount;
	}

	// Token: 0x060156FA RID: 87802 RVA: 0x005F04CC File Offset: 0x005EE6CC
	public bool IsOpen(int shopId)
	{
		Aki.Config.ShopInfo? shopConfig = this.GetShopConfig(shopId);
		return shopConfig != null && ModelBase<FunctionModel>.Instance.IsOpen(shopConfig.Value.OpenId);
	}

	// Token: 0x060156FB RID: 87803 RVA: 0x005F0508 File Offset: 0x005EE708
	public List<ShopItemFullInfo> GetShopItemList(int shopId)
	{
		this.GetShopInfo(shopId);
		Shop shopInfo = this.GetShopInfo(shopId);
		List<ShopItemFullInfo> list = new List<ShopItemFullInfo>();
		if (shopInfo == null)
		{
			return list;
		}
		foreach (KeyValuePair<int, ShopItemInfoNew> keyValuePair in shopInfo.GetItemList())
		{
			ShopItemInfoNew value = keyValuePair.Value;
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(value.ItemId);
			if (itemConfigData != null)
			{
				ShopItemFullInfo item = new ShopItemFullInfo(itemConfigData, value, shopId);
				list.Add(item);
			}
		}
		list.Sort(delegate(ShopItemFullInfo a, ShopItemFullInfo b)
		{
			if (a.IsOutOfStock() != b.IsOutOfStock())
			{
				if (!a.IsOutOfStock())
				{
					return -1;
				}
				return 1;
			}
			else if (a.IsInteractive() != b.IsInteractive())
			{
				if (!a.IsInteractive())
				{
					return 1;
				}
				return -1;
			}
			else if (a.IsUnlocked() != b.IsUnlocked())
			{
				if (!a.IsUnlocked())
				{
					return -1;
				}
				return 1;
			}
			else
			{
				if (a.SortIndex != b.SortIndex)
				{
					return a.SortIndex - b.SortIndex;
				}
				return a.Id.CompareTo(b.Id);
			}
		});
		return list;
	}

	// Token: 0x060156FC RID: 87804 RVA: 0x005F05CC File Offset: 0x005EE7CC
	[NullableContext(2)]
	public ShopItemFullInfo GetShopItemFullInfoByShopIdAndItemId(int shopId, int itemId)
	{
		foreach (ShopItemFullInfo shopItemFullInfo in this.GetShopItemList(shopId))
		{
			if (shopItemFullInfo.Id == itemId)
			{
				return shopItemFullInfo;
			}
		}
		return null;
	}

	// Token: 0x0400A4E8 RID: 42216
	[Nullable(2)]
	public ShopItemFullInfo OpenItemInfo;

	// Token: 0x0400A4E9 RID: 42217
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, Shop> ShopList;

	// Token: 0x0400A4EA RID: 42218
	private string Version = "";

	// Token: 0x0400A4EB RID: 42219
	public int InteractTarget;

	// Token: 0x0400A4EC RID: 42220
	public long? CurrentInteractCreatureDataLongId;
}
