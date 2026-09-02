using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.PayShop;
using Google.Protobuf.Collections;

// Token: 0x020023B9 RID: 9145
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class PayShopModel : ModelBase<PayShopModel>
{
	// Token: 0x06011A16 RID: 72214 RVA: 0x004D6614 File Offset: 0x004D4814
	public PayShopModel()
	{
		Dictionary<PayShopDefine.EPayShopTabType, Func<bool>> dictionary = new Dictionary<PayShopDefine.EPayShopTabType, Func<bool>>();
		dictionary[PayShopDefine.EPayShopTabType.NewPlayerShop] = (() => this.GetPayShopTabIdList(PayShopDefine.EPayShopTabType.NewPlayerShop, false).Count > 0);
		this.VisibilityPredicates = dictionary;
	}

	// Token: 0x06011A17 RID: 72215 RVA: 0x004D66A0 File Offset: 0x004D48A0
	public bool IsPayShopVisible(PayShopDefine.EPayShopTabType payShopId)
	{
		Func<bool> func;
		return !this.VisibilityPredicates.TryGetValue(payShopId, out func) || func();
	}

	// Token: 0x17001666 RID: 5734
	// (get) Token: 0x06011A18 RID: 72216 RVA: 0x004D66C5 File Offset: 0x004D48C5
	// (set) Token: 0x06011A19 RID: 72217 RVA: 0x004D66CD File Offset: 0x004D48CD
	public string Version
	{
		get
		{
			return this.DataVersionInternal;
		}
		set
		{
			this.DataVersionInternal = value;
		}
	}

	// Token: 0x06011A1A RID: 72218 RVA: 0x004D66D6 File Offset: 0x004D48D6
	public int GetCurrentPayShopId()
	{
		return this.CurrentPayShopId;
	}

	// Token: 0x06011A1B RID: 72219 RVA: 0x004D66E0 File Offset: 0x004D48E0
	public UiDynamicTab? GetTabInfoByPayShopIdId(int payShopId)
	{
		foreach (PayShopDefine.EPayShopTabType epayShopTabType in this.GetPayShopIdList())
		{
			if (epayShopTabType == (PayShopDefine.EPayShopTabType)payShopId)
			{
				int payShopInfoDynamicTabId = this.GetPayShopInfoDynamicTabId(epayShopTabType);
				return new UiDynamicTab?(ConfigBase<DynamicTabConfig>.Instance.GetTabViewConfById(payShopInfoDynamicTabId));
			}
		}
		return null;
	}

	// Token: 0x06011A1C RID: 72220 RVA: 0x004D6758 File Offset: 0x004D4958
	public void SetPayShopInfoList(List<PayShopInfo> infoList)
	{
		foreach (PayShopInfo info in infoList)
		{
			this.RefreshPayShopInfo(info);
		}
		Singleton<EventSystem>.Instance.Emit<IEnumerable<PayShopDefine.EPayShopTabType>>(EEventName.RefreshAllPayShop, this.PayShopMap.Keys);
	}

	// Token: 0x06011A1D RID: 72221 RVA: 0x004D67C4 File Offset: 0x004D49C4
	public void SetPayShopRecommendData(List<PayShopRecommendConfigInfo> info)
	{
		foreach (PayShopRecommendConfigInfo payShopRecommendConfigInfo in info)
		{
			int id = payShopRecommendConfigInfo.Id;
			PayShopRecommendData payShopRecommendData;
			if (this.PayShopRecommendData.TryGetValue(id, out payShopRecommendData))
			{
				payShopRecommendData.Phrase(payShopRecommendConfigInfo);
			}
			else
			{
				PayShopRecommendData payShopRecommendData2 = new PayShopRecommendData();
				payShopRecommendData2.Phrase(payShopRecommendConfigInfo);
				this.PayShopRecommendData[id] = payShopRecommendData2;
			}
		}
	}

	// Token: 0x06011A1E RID: 72222 RVA: 0x004D6848 File Offset: 0x004D4A48
	public bool CheckRecommendHasBought(int type, int boughtParam)
	{
		if (type == 1)
		{
			return false;
		}
		if (type == 3)
		{
			return false;
		}
		if (type == 4)
		{
			if (boughtParam < 0)
			{
				return false;
			}
			PayShopGoods payShopGoodsById = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(boughtParam);
			return payShopGoodsById != null && payShopGoodsById.IsSoldOut();
		}
		else
		{
			if (type != 2)
			{
				return false;
			}
			if (boughtParam < 0)
			{
				return false;
			}
			PayShopGoods payShopGoods = ModelBase<PayShopModel>.Instance.GetPayShopGoods(boughtParam);
			return payShopGoods != null && payShopGoods.IsSoldOut();
		}
	}

	// Token: 0x06011A1F RID: 72223 RVA: 0x004D68A4 File Offset: 0x004D4AA4
	public void SetPayShopTabData(List<PayShopTabConfigInfo> info)
	{
		if (info.Count == 0)
		{
			return;
		}
		this.PayShopTabArray.Clear();
		foreach (PayShopTabConfigInfo info2 in info)
		{
			PayShopTabData payShopTabData = new PayShopTabData();
			payShopTabData.Phrase(info2);
			this.PayShopTabArray.Add(payShopTabData);
		}
	}

	// Token: 0x06011A20 RID: 72224 RVA: 0x004D6918 File Offset: 0x004D4B18
	public void SetPayShopInfo(PayShopInfo info)
	{
		this.RefreshPayShopInfo(info);
		this.CurrentPayShopId = info.Id;
	}

	// Token: 0x06011A21 RID: 72225 RVA: 0x004D6930 File Offset: 0x004D4B30
	public void SetPayShopGoodsList(List<Aki.Protocol.PayShopItem> goodsInfoList)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (Aki.Protocol.PayShopItem payShopItem in goodsInfoList)
		{
			PayShopGoods payShopGoods;
			if (this.PayShopGoodsMap.TryGetValue(payShopItem.Id, out payShopGoods))
			{
				this.RefreshPayShopGoods(payShopItem);
			}
			else
			{
				PayShopDefine.EPayShopTabType shopId = (PayShopDefine.EPayShopTabType)payShopItem.ShopId;
				HashSet<int> hashSet2;
				if (!this.PayShopMap.TryGetValue(shopId, out hashSet2))
				{
					hashSet2 = new HashSet<int>();
				}
				hashSet2.Add(payShopItem.Id);
				this.PayShopMap[shopId] = hashSet2;
				payShopGoods = this.CreatePayShopGoods(payShopItem, shopId);
			}
			hashSet.Add(payShopGoods.GetTabId());
		}
		Singleton<EventSystem>.Instance.Emit<IReadOnlySet<int>>(EEventName.RefreshGoodsList, hashSet);
	}

	// Token: 0x06011A22 RID: 72226 RVA: 0x004D6A04 File Offset: 0x004D4C04
	public PayShopInfoData GetPayShopInfoById(PayShopDefine.EPayShopTabType payShopId)
	{
		PayShopInfoData result;
		if (this.PayShopInfoMap.TryGetValue(payShopId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06011A23 RID: 72227 RVA: 0x004D6A24 File Offset: 0x004D4C24
	private unsafe void RefreshPayShopInfo(PayShopInfo info)
	{
		PayShopDefine.EPayShopTabType id = (PayShopDefine.EPayShopTabType)info.Id;
		RepeatedField<Aki.Protocol.PayShopItem> items = info.Items;
		HashSet<int> hashSet = new HashSet<int>();
		foreach (Aki.Protocol.PayShopItem payShopItem in items)
		{
			hashSet.Add(payShopItem.Id);
			this.CreatePayShopGoods(payShopItem, id);
		}
		this.PayShopMap[id] = hashSet;
		PayShopInfoData payShopInfoData;
		if (!this.PayShopInfoMap.TryGetValue(id, out payShopInfoData))
		{
			payShopInfoData = new PayShopInfoData();
		}
		payShopInfoData.Phrase(info);
		this.PayShopInfoMap[id] = payShopInfoData;
		this.ShopChangeDirty = true;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:Root 刷新商城数据";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ShopId", id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("goodsLength", hashSet.Count);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06011A24 RID: 72228 RVA: 0x004D6B38 File Offset: 0x004D4D38
	protected void RefreshPayShopGoods(Aki.Protocol.PayShopItem goodsInfo)
	{
		PayShopGoodsData payShopGoodsData = new PayShopGoodsData();
		payShopGoodsData.Phrase(goodsInfo);
		PayShopGoods payShopGoods;
		if (this.PayShopGoodsMap.TryGetValue(goodsInfo.Id, out payShopGoods))
		{
			payShopGoods.SetGoodsData(payShopGoodsData);
		}
	}

	// Token: 0x06011A25 RID: 72229 RVA: 0x004D6B70 File Offset: 0x004D4D70
	private PayShopGoods CreatePayShopGoods(Aki.Protocol.PayShopItem goodsInfo, PayShopDefine.EPayShopTabType payShopId)
	{
		PayShopGoodsData payShopGoodsData = new PayShopGoodsData();
		payShopGoodsData.Phrase(goodsInfo);
		PayShopGoods payShopGoods = new PayShopGoods(payShopId);
		payShopGoods.SetGoodsData(payShopGoodsData);
		this.PayShopGoodsMap[payShopGoodsData.Id] = payShopGoods;
		return payShopGoods;
	}

	// Token: 0x06011A26 RID: 72230 RVA: 0x004D6BAC File Offset: 0x004D4DAC
	public void UnLockPayShopGoods(List<int> idList)
	{
		Dictionary<int, HashSet<int>> dictionary = new Dictionary<int, HashSet<int>>();
		foreach (int key in idList)
		{
			PayShopGoods payShopGoods;
			if (this.PayShopGoodsMap.TryGetValue(key, out payShopGoods))
			{
				payShopGoods.SetUnLock();
				HashSet<int> hashSet;
				if (!dictionary.TryGetValue((int)payShopGoods.PayShopId, out hashSet))
				{
					hashSet = new HashSet<int>();
				}
				hashSet.Add(payShopGoods.GetTabId());
				dictionary[(int)payShopGoods.PayShopId] = hashSet;
			}
		}
		this.ShopChangeDirty = true;
		Singleton<EventSystem>.Instance.Emit<IReadOnlyDictionary<int, HashSet<int>>>(EEventName.UnLockGoods, dictionary);
	}

	// Token: 0x06011A27 RID: 72231 RVA: 0x004D6C5C File Offset: 0x004D4E5C
	public List<PayShopDefine.EPayShopTabType> GetPayShopIdList()
	{
		if (!this.ShopChangeDirty)
		{
			return this.CurrentPayShopTabTypeList;
		}
		this.ShopChangeDirty = false;
		this.CurrentPayShopTabTypeList.Clear();
		foreach (PayShopDefine.EPayShopTabType item in this.PayShopMap.Keys)
		{
			this.CurrentPayShopTabTypeList.Add(item);
		}
		this.CurrentPayShopTabTypeList.Sort(delegate(PayShopDefine.EPayShopTabType aPayShopId, PayShopDefine.EPayShopTabType bPayShopId)
		{
			int payShopInfoSort = this.GetPayShopInfoSort(aPayShopId);
			int payShopInfoSort2 = this.GetPayShopInfoSort(bPayShopId);
			if (payShopInfoSort != payShopInfoSort2)
			{
				return payShopInfoSort - payShopInfoSort2;
			}
			return aPayShopId - bPayShopId;
		});
		return this.CurrentPayShopTabTypeList;
	}

	// Token: 0x06011A28 RID: 72232 RVA: 0x004D6CF8 File Offset: 0x004D4EF8
	public List<int> GetPayShopTabIdList(PayShopDefine.EPayShopTabType payShopId, bool sort = true)
	{
		HashSet<int> hashSet = new HashSet<int>();
		if (payShopId == PayShopDefine.EPayShopTabType.Recommend)
		{
			using (List<PayShopRecommendData>.Enumerator enumerator = this.GetNeedShowRecommendData().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PayShopRecommendData payShopRecommendData = enumerator.Current;
					if (!hashSet.Contains(payShopRecommendData.Id))
					{
						hashSet.Add(payShopRecommendData.Id);
					}
				}
				goto IL_C5;
			}
		}
		foreach (PayShopGoods payShopGoods in this.CollectTabSourceGoods(payShopId))
		{
			if (this.IfGoodsContributeTab(payShopId, payShopGoods))
			{
				hashSet.Add(payShopGoods.GetTabId());
			}
		}
		IL_C5:
		if (payShopId == PayShopDefine.EPayShopTabType.SkinShop)
		{
			foreach (int item in ModelBase<PayGiftModel>.Instance.GetSkinTabList())
			{
				hashSet.Add(item);
			}
		}
		if (payShopId == PayShopDefine.EPayShopTabType.NewPlayerShop && ModelBase<WeekCardModel>.Instance.GetViewModel(EWeekCardKind.NewPlayer).IsKindOpen())
		{
			hashSet.Add(1);
		}
		List<int> list = new List<int>(hashSet);
		if (sort)
		{
			list.Sort(delegate(int aTabId, int bTabId)
			{
				PayShopTabData payShopTabDataByPayShopIdAndTabId = this.GetPayShopTabDataByPayShopIdAndTabId(payShopId, aTabId);
				PayShopTabData payShopTabDataByPayShopIdAndTabId2 = this.GetPayShopTabDataByPayShopIdAndTabId(payShopId, bTabId);
				int num = (payShopTabDataByPayShopIdAndTabId != null) ? payShopTabDataByPayShopIdAndTabId.Sort : 0;
				int num2 = (payShopTabDataByPayShopIdAndTabId2 != null) ? payShopTabDataByPayShopIdAndTabId2.Sort : 0;
				if (num != num2)
				{
					return num - num2;
				}
				return aTabId - bTabId;
			});
		}
		return list;
	}

	// Token: 0x06011A29 RID: 72233 RVA: 0x004D6E7C File Offset: 0x004D507C
	private List<PayShopGoods> CollectTabSourceGoods(PayShopDefine.EPayShopTabType payShopId)
	{
		List<PayShopGoods> list = new List<PayShopGoods>();
		HashSet<int> hashSet;
		if (this.PayShopMap.TryGetValue(payShopId, out hashSet))
		{
			foreach (int key in hashSet)
			{
				PayShopGoods item;
				if (this.PayShopGoodsMap.TryGetValue(key, out item))
				{
					list.Add(item);
				}
			}
		}
		if (this.IfPayGiftRoutedShop(payShopId))
		{
			foreach (PayShopGoods payShopGoods in ModelBase<PayGiftModel>.Instance.GetPayShopGoodsList())
			{
				if (payShopGoods.PayShopId == payShopId)
				{
					PayPackageData getPayGiftData = payShopGoods.GetGetPayGiftData();
					if (getPayGiftData != null && getPayGiftData.ShowInShop() && getPayGiftData.CanShowInShopTab())
					{
						list.Add(payShopGoods);
					}
				}
			}
		}
		return list;
	}

	// Token: 0x06011A2A RID: 72234 RVA: 0x004D6F70 File Offset: 0x004D5170
	private bool IfGoodsContributeTab(PayShopDefine.EPayShopTabType payShopId, PayShopGoods goods)
	{
		int tabId = goods.GetTabId();
		if ((payShopId == PayShopDefine.EPayShopTabType.NewPlayerShop || (payShopId == PayShopDefine.EPayShopTabType.GiftBag && PayShopDefine.GiftBagShopSpecialTabList.Contains(tabId))) && !goods.CheckGoodIfShow())
		{
			return false;
		}
		PayShopTabData payShopTabDataByPayShopIdAndTabId = this.GetPayShopTabDataByPayShopIdAndTabId(payShopId, tabId);
		if (payShopTabDataByPayShopIdAndTabId != null && payShopTabDataByPayShopIdAndTabId.BeginTime > 0L && payShopTabDataByPayShopIdAndTabId.EndTime > 0L)
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			if (serverTime < (double)payShopTabDataByPayShopIdAndTabId.BeginTime || serverTime > (double)payShopTabDataByPayShopIdAndTabId.EndTime)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06011A2B RID: 72235 RVA: 0x004D6FEC File Offset: 0x004D51EC
	public int GetPayShopFirstTabId(PayShopDefine.EPayShopTabType payShopId)
	{
		HashSet<int> hashSet;
		if (!this.PayShopMap.TryGetValue(payShopId, out hashSet))
		{
			return 0;
		}
		int num = 0;
		int num2 = 0;
		foreach (int key in hashSet)
		{
			PayShopGoods payShopGoods;
			if (this.PayShopGoodsMap.TryGetValue(key, out payShopGoods))
			{
				int tabId = payShopGoods.GetTabId();
				if (num == 0 && num2 == 0)
				{
					num = tabId;
					PayShopTabData payShopTabDataByPayShopIdAndTabId = this.GetPayShopTabDataByPayShopIdAndTabId(payShopId, num);
					num2 = ((payShopTabDataByPayShopIdAndTabId != null) ? payShopTabDataByPayShopIdAndTabId.Sort : 0);
				}
				else
				{
					PayShopTabData payShopTabDataByPayShopIdAndTabId2 = this.GetPayShopTabDataByPayShopIdAndTabId(payShopId, num);
					int num3 = (payShopTabDataByPayShopIdAndTabId2 != null) ? payShopTabDataByPayShopIdAndTabId2.Sort : 0;
					if (num2 > num3 || (num2 == num3 && num > tabId))
					{
						num = tabId;
						num2 = num3;
					}
				}
			}
		}
		return num;
	}

	// Token: 0x06011A2C RID: 72236 RVA: 0x004D70B8 File Offset: 0x004D52B8
	private bool IfPayGiftRoutedShop(PayShopDefine.EPayShopTabType payShopId)
	{
		return PayShopDefine.payGiftRoutedShopSet.Contains(payShopId);
	}

	// Token: 0x06011A2D RID: 72237 RVA: 0x004D70C5 File Offset: 0x004D52C5
	private bool IfSkinShopGoods(PayShopDefine.EPayShopTabType payShopId)
	{
		return payShopId == PayShopDefine.EPayShopTabType.SkinShop;
	}

	// Token: 0x06011A2E RID: 72238 RVA: 0x004D70CC File Offset: 0x004D52CC
	public List<PayShopGoods> GetPayShopGoodsByTabType(PayShopDefine.EPayShopTabType payShopId, int tabId = 1)
	{
		List<PayShopGoods> list = new List<PayShopGoods>();
		if (this.IfPayGiftRoutedShop(payShopId))
		{
			using (List<PayShopGoods>.Enumerator enumerator = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsList().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PayShopGoods payShopGoods = enumerator.Current;
					if (payShopGoods.PayShopId == payShopId && payShopGoods.GetGetPayGiftData().ShowInShop() && payShopGoods.GetGetPayGiftData().CanShowInShopTab())
					{
						list.Add(payShopGoods);
					}
				}
				goto IL_D7;
			}
		}
		if (this.IfSkinShopGoods(payShopId))
		{
			foreach (PayShopGoods payShopGoods2 in ModelBase<PayGiftModel>.Instance.GetPayShopGoodsList())
			{
				if (payShopGoods2.GetTabId() == tabId && payShopGoods2.GetGetPayGiftData().ShowInSkinTab() && payShopGoods2.GetGetPayGiftData().CanShowInShopTab())
				{
					list.Add(payShopGoods2);
				}
			}
		}
		IL_D7:
		HashSet<int> hashSet;
		if (this.PayShopMap.TryGetValue(payShopId, out hashSet))
		{
			foreach (int key in hashSet)
			{
				PayShopGoods item;
				if (this.PayShopGoodsMap.TryGetValue(key, out item))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	// Token: 0x06011A2F RID: 72239 RVA: 0x004D7230 File Offset: 0x004D5430
	public PayShopGoods GetGoodsInTab(PayShopDefine.EPayShopTabType payShopId, int itemConfigId)
	{
		List<PayShopGoods> list = new List<PayShopGoods>();
		HashSet<int> hashSet;
		if (this.PayShopMap.TryGetValue(payShopId, out hashSet))
		{
			foreach (int key in hashSet)
			{
				PayShopGoods item;
				if (this.PayShopGoodsMap.TryGetValue(key, out item))
				{
					list.Add(item);
				}
			}
		}
		foreach (PayShopGoods payShopGoods in list)
		{
			if (payShopGoods.GetItemData().ItemId == itemConfigId && payShopGoods.CheckGoodIfShow())
			{
				return payShopGoods;
			}
		}
		return null;
	}

	// Token: 0x06011A30 RID: 72240 RVA: 0x004D7300 File Offset: 0x004D5500
	public List<PayShopGoods> GetPayShopTabData(PayShopDefine.EPayShopTabType payShopId, int tabId = 1, bool isSort = true)
	{
		if (payShopId == PayShopDefine.EPayShopTabType.None || payShopId == PayShopDefine.EPayShopTabType.Default)
		{
			return new List<PayShopGoods>();
		}
		List<PayShopGoods> payShopGoodsByTabType = this.GetPayShopGoodsByTabType(payShopId, tabId);
		List<PayShopGoods> list = new List<PayShopGoods>();
		foreach (PayShopGoods payShopGoods in payShopGoodsByTabType)
		{
			if (payShopGoods.GetTabId() == tabId && payShopGoods.CheckGoodIfShow())
			{
				list.Add(payShopGoods);
			}
		}
		if (isSort)
		{
			return this.SortPayShopGoods(payShopId, list);
		}
		return list;
	}

	// Token: 0x06011A31 RID: 72241 RVA: 0x004D7388 File Offset: 0x004D5588
	private List<PayShopGoods> SortPayShopGoods(PayShopDefine.EPayShopTabType payShopId, List<PayShopGoods> goods)
	{
		if (this.GetPayShopInfoSortRule(payShopId) == 1)
		{
			List<PayShopGoods> list = new List<PayShopGoods>();
			List<PayShopGoods> list2 = new List<PayShopGoods>();
			List<PayShopGoods> list3 = new List<PayShopGoods>();
			foreach (PayShopGoods payShopGoods in goods)
			{
				if (payShopGoods.IsSoldOut())
				{
					list3.Add(payShopGoods);
				}
				else if (payShopGoods.IfCanBuy())
				{
					list.Add(payShopGoods);
				}
				else
				{
					list2.Add(payShopGoods);
				}
			}
			list.Sort(new Comparison<PayShopGoods>(this.SortByQualityThenSortValueThenId));
			list2.Sort(new Comparison<PayShopGoods>(this.SortBySortValueThenId));
			list3.Sort(new Comparison<PayShopGoods>(this.SortByQualityThenSortValueThenId));
			List<PayShopGoods> list4 = new List<PayShopGoods>();
			list4.AddRange(list);
			list4.AddRange(list2);
			list4.AddRange(list3);
			return list4;
		}
		Comparison<PayShopGoods> sortFunctionByPayShopId = this.GetSortFunctionByPayShopId(payShopId);
		goods.Sort(sortFunctionByPayShopId);
		return goods;
	}

	// Token: 0x06011A32 RID: 72242 RVA: 0x004D7480 File Offset: 0x004D5680
	private Comparison<PayShopGoods> GetSortFunctionByPayShopId(PayShopDefine.EPayShopTabType payShopId)
	{
		if (this.GetPayShopInfoSortRule(payShopId) == 1)
		{
			return new Comparison<PayShopGoods>(this.RougeLikeSort);
		}
		return new Comparison<PayShopGoods>(this.GoodsSort);
	}

	// Token: 0x06011A33 RID: 72243 RVA: 0x004D74A5 File Offset: 0x004D56A5
	private int SortBySortValueThenId(PayShopGoods aGoods, PayShopGoods bGoods)
	{
		if (aGoods.GetGoodsData().GetSortValue() != bGoods.GetGoodsData().GetSortValue())
		{
			return aGoods.GetGoodsData().GetSortValue() - bGoods.GetGoodsData().GetSortValue();
		}
		return aGoods.GetGoodsId() - bGoods.GetGoodsId();
	}

	// Token: 0x06011A34 RID: 72244 RVA: 0x004D74E4 File Offset: 0x004D56E4
	private int SortByQualityThenSortValueThenId(PayShopGoods aGoods, PayShopGoods bGoods)
	{
		if (aGoods.GetItemData().Quality != bGoods.GetItemData().Quality)
		{
			return bGoods.GetItemData().Quality - aGoods.GetItemData().Quality;
		}
		if (aGoods.GetGoodsData().GetSortValue() != bGoods.GetGoodsData().GetSortValue())
		{
			return aGoods.GetGoodsData().GetSortValue() - bGoods.GetGoodsData().GetSortValue();
		}
		return aGoods.GetGoodsId() - bGoods.GetGoodsId();
	}

	// Token: 0x06011A35 RID: 72245 RVA: 0x004D7560 File Offset: 0x004D5760
	private int RougeLikeSort(PayShopGoods aGoods, PayShopGoods bGoods)
	{
		if (aGoods.IsSoldOut() != bGoods.IsSoldOut())
		{
			if (!aGoods.IsSoldOut())
			{
				return -1;
			}
			return 1;
		}
		else if (aGoods.IfCanBuy() != bGoods.IfCanBuy())
		{
			if (!aGoods.IfCanBuy())
			{
				return 1;
			}
			return -1;
		}
		else
		{
			CSharpScript.Game.Module.PayShop.IItemData itemData = aGoods.GetItemData();
			CSharpScript.Game.Module.PayShop.IItemData itemData2 = bGoods.GetItemData();
			if (itemData.Quality != itemData2.Quality)
			{
				return itemData2.Quality - itemData.Quality;
			}
			if (aGoods.GetGoodsData().GetSortValue() != bGoods.GetGoodsData().GetSortValue())
			{
				return aGoods.GetGoodsData().GetSortValue() - bGoods.GetGoodsData().GetSortValue();
			}
			return aGoods.GetGoodsId() - bGoods.GetGoodsId();
		}
	}

	// Token: 0x06011A36 RID: 72246 RVA: 0x004D7608 File Offset: 0x004D5808
	private int GoodsSort(PayShopGoods aGoods, PayShopGoods bGoods)
	{
		if (aGoods.IsSoldOut() != bGoods.IsSoldOut())
		{
			if (!aGoods.IsSoldOut())
			{
				return -1;
			}
			return 1;
		}
		else if (aGoods.IsLocked() != bGoods.IsLocked())
		{
			if (!aGoods.IsLocked())
			{
				return -1;
			}
			return 1;
		}
		else if (aGoods.IfCanBuy() != bGoods.IfCanBuy())
		{
			if (!aGoods.IfCanBuy())
			{
				return 1;
			}
			return -1;
		}
		else
		{
			if (aGoods.GetGoodsData().GetSortValue() != bGoods.GetGoodsData().GetSortValue())
			{
				return aGoods.GetGoodsData().GetSortValue() - bGoods.GetGoodsData().GetSortValue();
			}
			CSharpScript.Game.Module.PayShop.IItemData itemData = aGoods.GetItemData();
			CSharpScript.Game.Module.PayShop.IItemData itemData2 = bGoods.GetItemData();
			if (itemData.Quality != itemData2.Quality)
			{
				return itemData2.Quality - itemData.Quality;
			}
			return aGoods.GetGoodsId() - bGoods.GetGoodsId();
		}
	}

	// Token: 0x06011A37 RID: 72247 RVA: 0x004D76CA File Offset: 0x004D58CA
	[NullableContext(2)]
	public PayShopGoods GetPayShopGoods(int goodsId)
	{
		return this.PayShopGoodsMap.GetValueOrDefault(goodsId);
	}

	// Token: 0x06011A38 RID: 72248 RVA: 0x004D76D8 File Offset: 0x004D58D8
	public CommonDefine.ICountDown GetPayShopCountDownData(PayShopDefine.EPayShopTabType payShopId)
	{
		long payShopUpdateTime = this.GetPayShopUpdateTime(payShopId);
		if (payShopUpdateTime <= 0L)
		{
			return null;
		}
		long num = payShopUpdateTime;
		ValueTuple<int, int> timeTypeData = PayShopGoods.GetTimeTypeData(num);
		double num2 = (double)num - Math.Ceiling(Singleton<TimeUtil>.Instance.GetServerTime());
		if (timeTypeData.Item1 == 0)
		{
			return new CommonDefine.CountDown
			{
				CountDownText = ConfigBase<TextConfig>.Instance.GetTextById("NotEnoughOneHour"),
				RemainingTime = num2
			};
		}
		return Singleton<TimeUtil>.Instance.GetCountDownData(num2, null, null);
	}

	// Token: 0x06011A39 RID: 72249 RVA: 0x004D7758 File Offset: 0x004D5958
	public long GetPayShopUpdateTime(PayShopDefine.EPayShopTabType payShopId)
	{
		PayShopInfoData payShopInfoById = this.GetPayShopInfoById(payShopId);
		if (payShopInfoById == null)
		{
			return 0L;
		}
		return payShopInfoById.UpdateTime;
	}

	// Token: 0x06011A3A RID: 72250 RVA: 0x004D777C File Offset: 0x004D597C
	public void UpdatePayShopGoodsCount(int goodsId, int count)
	{
		PayShopGoods payShopGoods;
		if (this.PayShopGoodsMap.TryGetValue(goodsId, out payShopGoods))
		{
			if (payShopGoods.IsLimitGoods())
			{
				payShopGoods.AddBoughtCount(count);
				if (payShopGoods.IsSoldOut())
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.GoodsSoldOut, goodsId);
				}
			}
			Singleton<EventSystem>.Instance.Emit<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, goodsId, payShopGoods.PayShopId, payShopGoods.GetTabId());
		}
	}

	// Token: 0x06011A3B RID: 72251 RVA: 0x004D77E0 File Offset: 0x004D59E0
	public void UpdateActivityPayShopGoodsCount(int goodsId, int count)
	{
		PayShopGoods payShopGoods;
		if (this.PayShopGoodsMap.TryGetValue(goodsId, out payShopGoods) && payShopGoods.IsLimitGoods())
		{
			payShopGoods.AddBoughtCount(count);
		}
	}

	// Token: 0x06011A3C RID: 72252 RVA: 0x004D780C File Offset: 0x004D5A0C
	public List<PayShopGoods> GetNeedCheckGoods(PayShopDefine.EPayShopTabType payShopId)
	{
		List<PayShopGoods> list = new List<PayShopGoods>();
		foreach (PayShopGoods payShopGoods in this.GetPayShopGoodsByTabType(payShopId, 1))
		{
			if (payShopGoods.IsShowInShop() && (payShopGoods.InUpdateTime() || payShopGoods.InUnPermanentSellTime() || payShopGoods.WillSell()))
			{
				list.Add(payShopGoods);
			}
		}
		return list;
	}

	// Token: 0x06011A3D RID: 72253 RVA: 0x004D7888 File Offset: 0x004D5A88
	public bool CheckPayShopEntranceHasRedDot()
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10010))
		{
			return false;
		}
		foreach (PayShopDefine.EPayShopTabType payShopId in this.GetPayShopIdList())
		{
			if (this.CheckPayShopHasRedDot(payShopId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06011A3E RID: 72254 RVA: 0x004D78F8 File Offset: 0x004D5AF8
	public bool CheckPayShopHasRedDot(PayShopDefine.EPayShopTabType payShopId)
	{
		if (payShopId == PayShopDefine.EPayShopTabType.Recommend)
		{
			return ModelBase<MonthCardModel>.Instance.GetPayButtonRedDotState() || ModelBase<WeekCardModel>.Instance.GetViewModel(EWeekCardKind.Normal).GetRedDotState();
		}
		if (payShopId == PayShopDefine.EPayShopTabType.Recharge)
		{
			return !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.PayShopRechargeRedDot, false) && ModelBase<PayItemModel>.Instance.HasBonusData();
		}
		PayShopDefine.EShopTabViewType payShopInfoTabViewType = (PayShopDefine.EShopTabViewType)this.GetPayShopInfoTabViewType(payShopId);
		if (!PayShopDefine.payShopViewTabType.Contains(payShopInfoTabViewType))
		{
			return false;
		}
		foreach (int tabId in this.GetPayShopTabIdList(payShopId, false))
		{
			if (this.CheckPayShopTabHasRedDot(payShopId, tabId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06011A3F RID: 72255 RVA: 0x004D79B0 File Offset: 0x004D5BB0
	public bool CheckPayShopTabHasRedDot(PayShopDefine.EPayShopTabType payShopId, int tabId = 1)
	{
		if (payShopId == PayShopDefine.EPayShopTabType.Recommend)
		{
			return this.CheckRecommendPayShopTabRedDot(payShopId, tabId);
		}
		if (payShopId == PayShopDefine.EPayShopTabType.NewPlayerShop && tabId == 1)
		{
			return ModelBase<WeekCardModel>.Instance.GetViewModel(EWeekCardKind.NewPlayer).GetRedDotState();
		}
		if (payShopId == PayShopDefine.EPayShopTabType.SkinShop && tabId != 1)
		{
			foreach (PayShopGoods payShopGoods in ModelBase<PayGiftModel>.Instance.GetPayShopGoodsList())
			{
				if (payShopGoods.GetTabId() == tabId)
				{
					PayPackageData getPayGiftData = payShopGoods.GetGetPayGiftData();
					if (getPayGiftData.ShowInSkinTab() && getPayGiftData.CanShowInShopTab() && payShopGoods.GetIfNeedRemind())
					{
						return true;
					}
				}
			}
		}
		using (List<PayShopGoods>.Enumerator enumerator = this.GetPayShopTabData(payShopId, tabId, false).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetIfNeedRemind())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06011A40 RID: 72256 RVA: 0x004D7AA8 File Offset: 0x004D5CA8
	private bool CheckRecommendPayShopTabRedDot(PayShopDefine.EPayShopTabType payShopId, int tabId = 1)
	{
		if (!this.GetPayShopTabIdList(payShopId, false).Contains(tabId))
		{
			return false;
		}
		PayShopRecommendData recommendDataById = this.GetRecommendDataById(tabId);
		if (recommendDataById != null && recommendDataById.RecommendType == 1)
		{
			return ModelBase<MonthCardModel>.Instance.GetPayButtonRedDotState();
		}
		return recommendDataById != null && recommendDataById.RecommendType == 3 && ModelBase<WeekCardModel>.Instance.GetViewModel(EWeekCardKind.Normal).GetRedDotState();
	}

	// Token: 0x06011A41 RID: 72257 RVA: 0x004D7B04 File Offset: 0x004D5D04
	public bool ReadShopItemCheckFlag(PayShopDefine.EPayShopTabType payShopId, int tabId = 1)
	{
		List<PayShopGoods> list;
		if (this.IfPayGiftRoutedShop(payShopId))
		{
			list = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsList().FindAll((PayShopGoods g) => g.PayShopId == payShopId);
		}
		else
		{
			list = this.GetPayShopTabData(payShopId, tabId, false);
		}
		bool flag = false;
		foreach (PayShopGoods payShopGoods in list)
		{
			if (!payShopGoods.IsSoldOut() && !payShopGoods.IsLocked() && payShopGoods.IfCanBuy() && !ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.PayShopTabItemChecked, payShopGoods.GetGoodsId()))
			{
				ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.PayShopTabItemChecked, payShopGoods.GetGoodsId());
				flag = true;
			}
		}
		if (flag)
		{
			ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.PayShopTabItemChecked);
		}
		return flag;
	}

	// Token: 0x06011A42 RID: 72258 RVA: 0x004D7BF0 File Offset: 0x004D5DF0
	public bool CheckShopItemCheckFlag(PayShopDefine.EPayShopTabType payShopId, int tabId = 1)
	{
		List<PayShopGoods> list;
		if (this.IfPayGiftRoutedShop(payShopId))
		{
			list = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsList().FindAll((PayShopGoods g) => g.PayShopId == payShopId);
		}
		else
		{
			list = this.GetPayShopTabData(payShopId, tabId, false);
		}
		foreach (PayShopGoods payShopGoods in list)
		{
			if (!payShopGoods.IsSoldOut() && !payShopGoods.IsLocked() && payShopGoods.IfCanBuy() && !ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.PayShopTabItemChecked, payShopGoods.GetGoodsId()))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06011A43 RID: 72259 RVA: 0x004D7CB4 File Offset: 0x004D5EB4
	public string GetPayShopItemQualitySpriteByItemIdAndQuality(int itemId, int quality)
	{
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemId));
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.DangoAbyssItem)
		{
			return ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityById(quality).Value.PayShopQualitySprite;
		}
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.HonamiStoryItem || HonamiStoryUtil.CheckIsPluginBoxItem(itemId))
		{
			return ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryQuality(quality).Value.PayShopQualitySprite;
		}
		return ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetQualityConfig(quality).Value.PayShopQualitySprite;
	}

	// Token: 0x06011A44 RID: 72260 RVA: 0x004D7D3C File Offset: 0x004D5F3C
	public int GetPayShopInfoTabViewType(PayShopDefine.EPayShopTabType payShopId)
	{
		PayShopInfoData payShopInfoById = this.GetPayShopInfoById(payShopId);
		if (payShopInfoById == null)
		{
			return 0;
		}
		return payShopInfoById.ShopTabViewType;
	}

	// Token: 0x06011A45 RID: 72261 RVA: 0x004D7D5C File Offset: 0x004D5F5C
	public int GetPayShopInfoDynamicTabId(PayShopDefine.EPayShopTabType payShopId)
	{
		PayShopInfoData payShopInfoById = this.GetPayShopInfoById(payShopId);
		if (payShopInfoById == null)
		{
			return 0;
		}
		return payShopInfoById.DynamicTabId;
	}

	// Token: 0x06011A46 RID: 72262 RVA: 0x004D7D7C File Offset: 0x004D5F7C
	public int GetPayShopInfoSortRule(PayShopDefine.EPayShopTabType payShopId)
	{
		PayShopInfoData payShopInfoById = this.GetPayShopInfoById(payShopId);
		if (payShopInfoById == null)
		{
			return 0;
		}
		return payShopInfoById.SortRule;
	}

	// Token: 0x06011A47 RID: 72263 RVA: 0x004D7D9C File Offset: 0x004D5F9C
	public int GetPayShopInfoSort(PayShopDefine.EPayShopTabType payShopId)
	{
		PayShopInfoData payShopInfoById = this.GetPayShopInfoById(payShopId);
		if (payShopInfoById == null)
		{
			return 0;
		}
		return payShopInfoById.Sort;
	}

	// Token: 0x06011A48 RID: 72264 RVA: 0x004D7DBC File Offset: 0x004D5FBC
	public void AddPreviewPayGiftEntry(int configId, IPreviewPayGiftEntry entry)
	{
		if (configId <= 0)
		{
			return;
		}
		this.PreviewPayGiftEntryMap[configId] = entry;
	}

	// Token: 0x06011A49 RID: 72265 RVA: 0x004D7DD0 File Offset: 0x004D5FD0
	[NullableContext(2)]
	public IPreviewPayGiftEntry TryGetPreviewPayGiftEntry(int configId)
	{
		return this.PreviewPayGiftEntryMap.GetValueOrDefault(configId);
	}

	// Token: 0x06011A4A RID: 72266 RVA: 0x004D7DDE File Offset: 0x004D5FDE
	public void ClearPreviewPayGiftEntries()
	{
		if (this.PreviewPayGiftEntryMap.Count == 0)
		{
			return;
		}
		this.PreviewPayGiftEntryMap.Clear();
	}

	// Token: 0x06011A4B RID: 72267 RVA: 0x004D7DFC File Offset: 0x004D5FFC
	[NullableContext(2)]
	public PayGiftPreviewBuildResult TryBuildConsoleExtraPayGiftPreview(int reasonId)
	{
		if (reasonId != 8001)
		{
			return null;
		}
		int consoleExtraPerformancePayGiftId = this.ConsoleExtraPerformancePayGiftId;
		if (consoleExtraPerformancePayGiftId <= 0)
		{
			return null;
		}
		this.ConsoleExtraPerformancePayGiftId = 0;
		PayPackageData payGiftDataById = ModelBase<PayGiftModel>.Instance.GetPayGiftDataById(consoleExtraPerformancePayGiftId);
		if (payGiftDataById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Shop;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "[ConsoleExtraPayGift] payGiftData missing, fallback to normal flow";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("payGiftId", consoleExtraPerformancePayGiftId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		List<RewardItemData> list = this.BuildPayGiftPreviewItemList(payGiftDataById);
		if (list.Count == 0)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Shop;
			ELogAuthor author2 = ELogAuthor.YZY;
			string message2 = "[ConsoleExtraPayGift] preview items empty, fallback";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("payGiftId", consoleExtraPerformancePayGiftId);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		int configId = list[0].ConfigId;
		PreviewPayGiftEntry entry = new PreviewPayGiftEntry
		{
			EndStampSec = (long)Math.Floor(Singleton<TimeUtil>.Instance.GetServerTime()) + 2592000L,
			Title = this.BuildPayGiftRewardTitleText(payGiftDataById),
			RewardListDesc = this.BuildPayGiftRewardDescText(payGiftDataById)
		};
		this.AddPreviewPayGiftEntry(configId, entry);
		return new PayGiftPreviewBuildResult
		{
			PreviewItems = list
		};
	}

	// Token: 0x06011A4C RID: 72268 RVA: 0x004D7F04 File Offset: 0x004D6104
	private unsafe List<RewardItemData> BuildPayGiftPreviewItemList(PayPackageData payGiftData)
	{
		if (payGiftData.ItemId <= 0 || payGiftData.ItemCount <= 0)
		{
			return new List<RewardItemData>();
		}
		int previewPayGiftItemTemplateId = ConfigBase<PayShopConfig>.Instance.GetPreviewPayGiftItemTemplateId();
		RewardItemData rewardItemData = new RewardItemData((previewPayGiftItemTemplateId > 0) ? previewPayGiftItemTemplateId : payGiftData.ItemId, payGiftData.ItemCount, null, EDropItemType.Normal);
		rewardItemData.SetShowTimeFlag(true);
		int num = 1;
		List<RewardItemData> list = new List<RewardItemData>(num);
		CollectionsMarshal.SetCount<RewardItemData>(list, num);
		Span<RewardItemData> span = CollectionsMarshal.AsSpan<RewardItemData>(list);
		int index = 0;
		*span[index] = rewardItemData;
		return list;
	}

	// Token: 0x06011A4D RID: 72269 RVA: 0x004D7F84 File Offset: 0x004D6184
	private string BuildPayGiftRewardTitleText(PayPackageData payGiftData)
	{
		int itemId = payGiftData.ItemId;
		if (itemId <= 0)
		{
			return "";
		}
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
		string text = (itemConfigData != null) ? itemConfigData.Name : null;
		if (text == null || StringUtils.IsEmpty(text))
		{
			return "";
		}
		return text;
	}

	// Token: 0x06011A4E RID: 72270 RVA: 0x004D7FCC File Offset: 0x004D61CC
	private string BuildPayGiftRewardDescText(PayPackageData payGiftData)
	{
		int itemId = payGiftData.ItemId;
		if (itemId <= 0)
		{
			return "";
		}
		string name = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId).Name;
		return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Common_Get_PayGift", null), new string[]
		{
			ConfigMultiTextLang.GetLocalTextNew(name, null)
		});
	}

	// Token: 0x06011A4F RID: 72271 RVA: 0x004D801C File Offset: 0x004D621C
	public List<int> GetPayShopInfoMoney(PayShopDefine.EPayShopTabType payShopId)
	{
		PayShopInfoData payShopInfoById = this.GetPayShopInfoById(payShopId);
		if (payShopInfoById == null)
		{
			return new List<int>();
		}
		return payShopInfoById.Money;
	}

	// Token: 0x06011A50 RID: 72272 RVA: 0x004D8040 File Offset: 0x004D6240
	public List<int> GetPayShopTableList(int shopId)
	{
		List<PayShopTabData> list = new List<PayShopTabData>();
		foreach (PayShopTabData payShopTabData in this.PayShopTabArray)
		{
			if (payShopTabData.ShopId == shopId)
			{
				list.Add(payShopTabData);
			}
		}
		List<int> list2 = new List<int>();
		list.Sort((PayShopTabData a, PayShopTabData b) => a.Sort - b.Sort);
		foreach (PayShopTabData payShopTabData2 in list)
		{
			if (payShopTabData2.Enable)
			{
				list2.Add(payShopTabData2.TabId);
			}
		}
		return list2;
	}

	// Token: 0x06011A51 RID: 72273 RVA: 0x004D811C File Offset: 0x004D631C
	public PayShopTabData GetPayShopTabDataByPayShopIdAndTabId(PayShopDefine.EPayShopTabType payShopId, int tabId)
	{
		foreach (PayShopTabData payShopTabData in this.PayShopTabArray)
		{
			if (payShopTabData.ShopId == (int)payShopId && payShopTabData.TabId == tabId)
			{
				return payShopTabData;
			}
		}
		return null;
	}

	// Token: 0x06011A52 RID: 72274 RVA: 0x004D8184 File Offset: 0x004D6384
	public List<PayShopRecommendData> GetRecommendData()
	{
		List<PayShopRecommendData> list = new List<PayShopRecommendData>();
		foreach (PayShopRecommendData item in this.PayShopRecommendData.Values)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06011A53 RID: 72275 RVA: 0x004D81E4 File Offset: 0x004D63E4
	public List<PayShopRecommendData> GetNeedShowRecommendData()
	{
		List<PayShopRecommendData> list = new List<PayShopRecommendData>();
		foreach (PayShopRecommendData payShopRecommendData in this.PayShopRecommendData.Values)
		{
			if (payShopRecommendData.Show)
			{
				list.Add(payShopRecommendData);
			}
		}
		return list;
	}

	// Token: 0x06011A54 RID: 72276 RVA: 0x004D824C File Offset: 0x004D644C
	public PayShopRecommendData GetRecommendDataById(int id)
	{
		PayShopRecommendData result;
		if (this.PayShopRecommendData.TryGetValue(id, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06011A55 RID: 72277 RVA: 0x004D826C File Offset: 0x004D646C
	public void ClearData()
	{
		this.PayShopInfoMap.Clear();
		this.PayShopMap.Clear();
		this.PayShopGoodsMap.Clear();
		this.PreviewPayGiftEntryMap.Clear();
		this.ConsoleExtraPerformancePayGiftId = 0;
	}

	// Token: 0x04008A51 RID: 35409
	private readonly Dictionary<PayShopDefine.EPayShopTabType, PayShopInfoData> PayShopInfoMap = new Dictionary<PayShopDefine.EPayShopTabType, PayShopInfoData>();

	// Token: 0x04008A52 RID: 35410
	private readonly Dictionary<PayShopDefine.EPayShopTabType, HashSet<int>> PayShopMap = new Dictionary<PayShopDefine.EPayShopTabType, HashSet<int>>();

	// Token: 0x04008A53 RID: 35411
	private readonly Dictionary<int, PayShopGoods> PayShopGoodsMap = new Dictionary<int, PayShopGoods>();

	// Token: 0x04008A54 RID: 35412
	private List<PayShopTabData> PayShopTabArray = new List<PayShopTabData>();

	// Token: 0x04008A55 RID: 35413
	private readonly Dictionary<int, PayShopRecommendData> PayShopRecommendData = new Dictionary<int, PayShopRecommendData>();

	// Token: 0x04008A56 RID: 35414
	private string DataVersionInternal = "";

	// Token: 0x04008A57 RID: 35415
	private int CurrentPayShopId;

	// Token: 0x04008A58 RID: 35416
	private bool ShopChangeDirty;

	// Token: 0x04008A59 RID: 35417
	private List<PayShopDefine.EPayShopTabType> CurrentPayShopTabTypeList = new List<PayShopDefine.EPayShopTabType>();

	// Token: 0x04008A5A RID: 35418
	public bool BusinessCompliance;

	// Token: 0x04008A5B RID: 35419
	public int ConsoleExtraPerformancePayGiftId;

	// Token: 0x04008A5C RID: 35420
	private readonly Dictionary<int, IPreviewPayGiftEntry> PreviewPayGiftEntryMap = new Dictionary<int, IPreviewPayGiftEntry>();

	// Token: 0x04008A5D RID: 35421
	private readonly Dictionary<PayShopDefine.EPayShopTabType, Func<bool>> VisibilityPredicates;
}
