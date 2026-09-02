using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004D99 RID: 19865
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseShopData
	{
		// Token: 0x17008803 RID: 34819
		// (get) Token: 0x06033722 RID: 210722 RVA: 0x00CDDD31 File Offset: 0x00CDBF31
		public List<TrapDefenseShopItemData> ItemGoodsList
		{
			get
			{
				return new List<TrapDefenseShopItemData>(this.ItemGoodsMap.Values);
			}
		}

		// Token: 0x17008804 RID: 34820
		// (get) Token: 0x06033723 RID: 210723 RVA: 0x00CDDD43 File Offset: 0x00CDBF43
		public List<TrapDefenseShopBuffData> BuffGoodsList
		{
			get
			{
				return new List<TrapDefenseShopBuffData>(this.BuffGoodsMap.Values);
			}
		}

		// Token: 0x06033724 RID: 210724 RVA: 0x00CDDD55 File Offset: 0x00CDBF55
		public static TrapDefenseShopData Create()
		{
			TrapDefenseShopData trapDefenseShopData = new TrapDefenseShopData();
			trapDefenseShopData.Init();
			return trapDefenseShopData;
		}

		// Token: 0x06033725 RID: 210725 RVA: 0x00CDDD62 File Offset: 0x00CDBF62
		public void UpdateByServerData(TrapDefenseShopPanelInfo serverData)
		{
			this.ServerDataCache = serverData;
			this.TryUpdateData();
		}

		// Token: 0x06033726 RID: 210726 RVA: 0x00CDDD74 File Offset: 0x00CDBF74
		public void TryUpdateData()
		{
			if (this.ServerDataCache == null)
			{
				return;
			}
			TrapDefenseShopPanelInfo serverDataCache = this.ServerDataCache;
			this.TotalRefreshCount = serverDataCache.TotalRefreshTimes;
			this.RemainingRefreshCount = serverDataCache.RemainRefreshTimes;
			this.RefreshCost = serverDataCache.RefreshCost;
			Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
			Dictionary<int, bool> dictionary2 = new Dictionary<int, bool>();
			foreach (TrapDefenseShopProductPbInfo trapDefenseShopProductPbInfo in serverDataCache.ShopProductPbInfos)
			{
				if (trapDefenseShopProductPbInfo.ItemPbInfo != null)
				{
					if (this.ItemGoodsMap.ContainsKey(trapDefenseShopProductPbInfo.ItemPbInfo.ItemConfigId))
					{
						this.ItemGoodsMap[trapDefenseShopProductPbInfo.ItemPbInfo.ItemConfigId].Update(trapDefenseShopProductPbInfo);
					}
					else
					{
						TrapDefenseShopItemData trapDefenseShopItemData = TrapDefenseShopItemData.Create(trapDefenseShopProductPbInfo);
						this.ItemGoodsMap.Add(trapDefenseShopItemData.Id, trapDefenseShopItemData);
					}
					dictionary[trapDefenseShopProductPbInfo.ItemPbInfo.ItemConfigId] = true;
				}
				else if (trapDefenseShopProductPbInfo.BdGroupPbInfo != null)
				{
					if (this.BuffGoodsMap.ContainsKey(trapDefenseShopProductPbInfo.BdGroupPbInfo.BdGrougConfigId))
					{
						this.BuffGoodsMap[trapDefenseShopProductPbInfo.BdGroupPbInfo.BdGrougConfigId].Update(trapDefenseShopProductPbInfo);
					}
					else
					{
						TrapDefenseShopBuffData trapDefenseShopBuffData = TrapDefenseShopBuffData.Create(trapDefenseShopProductPbInfo);
						this.BuffGoodsMap.Add(trapDefenseShopBuffData.Id, trapDefenseShopBuffData);
					}
					dictionary2[trapDefenseShopProductPbInfo.BdGroupPbInfo.BdGrougConfigId] = true;
				}
			}
			foreach (int key in new List<int>(this.ItemGoodsMap.Keys))
			{
				if (!dictionary.ContainsKey(key))
				{
					this.ItemGoodsMap.Remove(key);
				}
			}
			foreach (int key2 in new List<int>(this.BuffGoodsMap.Keys))
			{
				if (!dictionary2.ContainsKey(key2))
				{
					this.BuffGoodsMap.Remove(key2);
				}
			}
			this.ServerDataCache = null;
		}

		// Token: 0x06033727 RID: 210727 RVA: 0x00CDDFD0 File Offset: 0x00CDC1D0
		public int SortGoods(ITrapDefenseShopGoods a, ITrapDefenseShopGoods b)
		{
			if (a.Disable != b.Disable)
			{
				if (!a.Disable)
				{
					return -1;
				}
				return 1;
			}
			else
			{
				float num = (float)((a.CurrentPrice != 0) ? a.CurrentPrice : 1) / (float)((a.OriginalPrice.GetValueOrDefault() != 0) ? a.OriginalPrice.Value : 1);
				float num2 = (float)((b.CurrentPrice != 0) ? b.CurrentPrice : 1) / (float)((b.OriginalPrice.GetValueOrDefault() != 0) ? b.OriginalPrice.Value : 1);
				if (num != num2)
				{
					if (num - num2 <= 0f)
					{
						return -1;
					}
					return 1;
				}
				else
				{
					if (a.QualityId != b.QualityId)
					{
						return b.QualityId.CompareTo(a.QualityId);
					}
					return a.Id.CompareTo(b.Id);
				}
			}
		}

		// Token: 0x06033728 RID: 210728 RVA: 0x00CDE0AC File Offset: 0x00CDC2AC
		private void Init()
		{
		}

		// Token: 0x0401DCE1 RID: 122081
		public Dictionary<int, TrapDefenseShopItemData> ItemGoodsMap = new Dictionary<int, TrapDefenseShopItemData>();

		// Token: 0x0401DCE2 RID: 122082
		public Dictionary<int, TrapDefenseShopBuffData> BuffGoodsMap = new Dictionary<int, TrapDefenseShopBuffData>();

		// Token: 0x0401DCE3 RID: 122083
		[Nullable(2)]
		public TrapDefenseShopPanelInfo ServerDataCache;

		// Token: 0x0401DCE4 RID: 122084
		public int TotalRefreshCount;

		// Token: 0x0401DCE5 RID: 122085
		public int RemainingRefreshCount;

		// Token: 0x0401DCE6 RID: 122086
		public int RefreshCost;
	}
}
