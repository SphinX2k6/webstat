using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;

// Token: 0x020023AB RID: 9131
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class PayGiftModel : ModelBase<PayGiftModel>
{
	// Token: 0x0601198F RID: 72079 RVA: 0x004D37DC File Offset: 0x004D19DC
	public void InitDataByServer(List<PayGiftInfo> infos, bool needRefreshEvent = false)
	{
		if (infos.Count == 0)
		{
			return;
		}
		this.PayShopGoodsList = new List<PayShopGoods>();
		this.PayGiftDataList = new List<PayPackageData>();
		this.TabList = new List<int>();
		this.PayShopGoodsMap.Clear();
		this.PayGiftMap.Clear();
		List<string> list = new List<string>();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		foreach (PayGiftInfo payGiftInfo in infos)
		{
			PayPackageData payPackageData = new PayPackageData();
			payPackageData.Phrase(payGiftInfo);
			list.Add(payGiftInfo.ProductId);
			this.PayGiftDataList.Add(payPackageData);
			this.PayShopGoodsList.Add(payPackageData.GetPayShopGoods());
			this.PayShopGoodsMap.Add(payPackageData.Id, payPackageData.GetPayShopGoods());
			this.PayGiftMap.Add(payPackageData.Id, payPackageData);
			if (!this.TabList.Contains(payPackageData.TabId) && payPackageData.ShowInShop())
			{
				this.TabList.Add(payPackageData.TabId);
			}
			if (payPackageData.ShopId == PayShopDefine.EPayShopTabType.GiftBag)
			{
				num++;
			}
			else if (payPackageData.ShopId == PayShopDefine.EPayShopTabType.NewPlayerShop)
			{
				num2++;
			}
			else
			{
				num3++;
			}
		}
		if (needRefreshEvent)
		{
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int item in this.TabList)
			{
				hashSet.Add(item);
			}
			Singleton<EventSystem>.Instance.Emit<IReadOnlySet<int>>(EEventName.RefreshGoodsList, hashSet);
		}
	}

	// Token: 0x06011990 RID: 72080 RVA: 0x004D3998 File Offset: 0x004D1B98
	public bool IfHaveFreeGift()
	{
		using (List<PayPackageData>.Enumerator enumerator = this.PayGiftDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Amount == "0")
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06011991 RID: 72081 RVA: 0x004D39FC File Offset: 0x004D1BFC
	public List<int> GetTabList()
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (PayShopGoods payShopGoods in this.GetPayShopGoodsList())
		{
			if (payShopGoods.GetGetPayGiftData().ShowInShop() && payShopGoods.GetGetPayGiftData().CanShowInShopTab() && payShopGoods.CheckGoodIfShow())
			{
				hashSet.Add(payShopGoods.GetTabId());
			}
		}
		return hashSet.ToList<int>();
	}

	// Token: 0x06011992 RID: 72082 RVA: 0x004D3A84 File Offset: 0x004D1C84
	public List<int> GetSkinTabList()
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (PayPackageData payPackageData in this.GetDataList())
		{
			if (payPackageData.ShowInSkinTab() && payPackageData.CanShowInShopTab())
			{
				hashSet.Add(payPackageData.TabId);
			}
		}
		return hashSet.ToList<int>();
	}

	// Token: 0x06011993 RID: 72083 RVA: 0x004D3AFC File Offset: 0x004D1CFC
	[NullableContext(2)]
	public PayShopGoods GetPayShopGoodsById(int id)
	{
		PayShopGoods result;
		if (this.PayShopGoodsMap.TryGetValue(id, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Pay;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "找不到对应的商品，检查配置或者协议顺序";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x06011994 RID: 72084 RVA: 0x004D3B4B File Offset: 0x004D1D4B
	public List<PayPackageData> GetPayGiftDataList()
	{
		return this.PayGiftDataList;
	}

	// Token: 0x06011995 RID: 72085 RVA: 0x004D3B54 File Offset: 0x004D1D54
	[NullableContext(2)]
	public PayPackageData GetPayGiftDataById(int id)
	{
		PayPackageData result;
		if (this.PayGiftMap.TryGetValue(id, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06011996 RID: 72086 RVA: 0x004D3B74 File Offset: 0x004D1D74
	public List<PayPackageData> GetPayGiftDataByType(EPayGiftType type)
	{
		return this.PayGiftDataList.FindAll((PayPackageData item) => item.Type == type);
	}

	// Token: 0x06011997 RID: 72087 RVA: 0x004D3BA5 File Offset: 0x004D1DA5
	public List<PayShopGoods> GetPayShopGoodsList()
	{
		return this.PayShopGoodsList;
	}

	// Token: 0x06011998 RID: 72088 RVA: 0x004D3BAD File Offset: 0x004D1DAD
	public List<PayPackageData> GetDataList()
	{
		return this.PayGiftDataList;
	}

	// Token: 0x040089A7 RID: 35239
	public string Version = "";

	// Token: 0x040089A8 RID: 35240
	private List<PayPackageData> PayGiftDataList = new List<PayPackageData>();

	// Token: 0x040089A9 RID: 35241
	private List<PayShopGoods> PayShopGoodsList = new List<PayShopGoods>();

	// Token: 0x040089AA RID: 35242
	private readonly Dictionary<int, PayShopGoods> PayShopGoodsMap = new Dictionary<int, PayShopGoods>();

	// Token: 0x040089AB RID: 35243
	private readonly Dictionary<int, PayPackageData> PayGiftMap = new Dictionary<int, PayPackageData>();

	// Token: 0x040089AC RID: 35244
	private List<int> TabList = new List<int>();
}
