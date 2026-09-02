using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F68 RID: 8040
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryShopScrollItem<[Nullable(0)] TGrid> : UiPanelBase where TGrid : ActivityGrid
{
	// Token: 0x0600F0C5 RID: 61637 RVA: 0x0041CCAA File Offset: 0x0041AEAA
	public HonamiStoryShopScrollItem(UUILoopScrollViewComponent scroller, UUIItem item, int sourceViewId, Func<TGrid> gridConstructor)
	{
		this.Scroller = scroller;
		this.Item = item;
		this.SourceViewId = sourceViewId;
		this.GridConstructor = gridConstructor;
	}

	// Token: 0x0600F0C6 RID: 61638 RVA: 0x0041CCCF File Offset: 0x0041AECF
	public void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Add(EEventName.ShopVersionCodeChange, new Action(this.OnShopVersionCodeChange));
	}

	// Token: 0x0600F0C7 RID: 61639 RVA: 0x0041CD09 File Offset: 0x0041AF09
	public void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShopVersionCodeChange, new Action(this.OnShopVersionCodeChange));
	}

	// Token: 0x0600F0C8 RID: 61640 RVA: 0x0041CD44 File Offset: 0x0041AF44
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
	{
		List<IPayShopUnionData> canBuyDataList = this.GetCanBuyDataList(shopId);
		this.LoopScrollView.RefreshByDataAsync(canBuyDataList, false, true).Forget();
	}

	// Token: 0x0600F0C9 RID: 61641 RVA: 0x0041CD6C File Offset: 0x0041AF6C
	private void OnShopVersionCodeChange()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PayShopRefresh);
		Action value = delegate()
		{
			Singleton<UiManager>.Instance.CloseViewById(this.SourceViewId, null);
		};
		confirmBoxDataNew.FunctionMap.Add(1, value);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "PayShop:DockyardBuyTabView 商品VersionCode不同步,打开弹窗", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600F0CA RID: 61642 RVA: 0x0041CDC9 File Offset: 0x0041AFC9
	protected override void OnStart()
	{
		this.LoopScrollView = new LoopScrollView<TGrid, IPayShopUnionData>(this.Scroller, this.Item.GetOwner() as AUIBaseActor, new Func<TGrid>(this.InitItem), false);
		this.AddEventListener();
	}

	// Token: 0x0600F0CB RID: 61643 RVA: 0x0041CDFF File Offset: 0x0041AFFF
	private TGrid InitItem()
	{
		return this.GridConstructor();
	}

	// Token: 0x0600F0CC RID: 61644 RVA: 0x0041CE0C File Offset: 0x0041B00C
	private List<IPayShopUnionData> GetCanBuyDataList(PayShopDefine.EPayShopTabType shopId)
	{
		List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData(shopId, 1, true);
		List<IPayShopUnionData> list = new List<IPayShopUnionData>();
		foreach (PayShopGoods payShopGoods in payShopTabData)
		{
			if (payShopGoods.IfCanBuy())
			{
				list.Add(payShopGoods);
			}
		}
		return list;
	}

	// Token: 0x0600F0CD RID: 61645 RVA: 0x0041CE78 File Offset: 0x0041B078
	public UniTask Refresh(int shopId)
	{
		HonamiStoryShopScrollItem<TGrid>.<Refresh>d__13 <Refresh>d__;
		<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Refresh>d__.<>4__this = this;
		<Refresh>d__.shopId = shopId;
		<Refresh>d__.<>1__state = -1;
		<Refresh>d__.<>t__builder.Start<HonamiStoryShopScrollItem<TGrid>.<Refresh>d__13>(ref <Refresh>d__);
		return <Refresh>d__.<>t__builder.Task;
	}

	// Token: 0x0600F0CE RID: 61646 RVA: 0x0041CEC3 File Offset: 0x0041B0C3
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
	}

	// Token: 0x040073A9 RID: 29609
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<TGrid, IPayShopUnionData> LoopScrollView;

	// Token: 0x040073AA RID: 29610
	private readonly UUILoopScrollViewComponent Scroller;

	// Token: 0x040073AB RID: 29611
	private readonly UUIItem Item;

	// Token: 0x040073AC RID: 29612
	private readonly int SourceViewId;

	// Token: 0x040073AD RID: 29613
	private readonly Func<TGrid> GridConstructor;
}
