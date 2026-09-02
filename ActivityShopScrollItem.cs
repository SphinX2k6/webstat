using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012A2 RID: 4770
[NullableContext(1)]
[Nullable(0)]
public class ActivityShopScrollItem<[Nullable(0)] TGrid> : UiPanelBase where TGrid : IActivityGrid
{
	// Token: 0x06007FE4 RID: 32740 RVA: 0x0021CA23 File Offset: 0x0021AC23
	public ActivityShopScrollItem(UUILoopScrollViewComponent scroller, UUIItem item, int sourceViewId, Func<TGrid> gridConstructor)
	{
		this.Scroller = scroller;
		this.Item = item;
		this.SourceViewId = sourceViewId;
		this.GridConstructor = gridConstructor;
	}

	// Token: 0x06007FE5 RID: 32741 RVA: 0x0021CA48 File Offset: 0x0021AC48
	public void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Add(EEventName.ShopVersionCodeChange, new Action(this.OnShopVersionCodeChange));
	}

	// Token: 0x06007FE6 RID: 32742 RVA: 0x0021CA82 File Offset: 0x0021AC82
	public void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShopVersionCodeChange, new Action(this.OnShopVersionCodeChange));
	}

	// Token: 0x06007FE7 RID: 32743 RVA: 0x0021CABC File Offset: 0x0021ACBC
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
	{
		List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData(shopId, 1, true);
		this.LoopScrollView.RefreshByDataAsync(payShopTabData.Cast<IPayShopUnionData>().ToList<IPayShopUnionData>(), false, true).Forget();
	}

	// Token: 0x06007FE8 RID: 32744 RVA: 0x0021CAF4 File Offset: 0x0021ACF4
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

	// Token: 0x06007FE9 RID: 32745 RVA: 0x0021CB51 File Offset: 0x0021AD51
	protected override void OnStart()
	{
		this.LoopScrollView = new LoopScrollView<ActivityGrid, IPayShopUnionData>(this.Scroller, this.Item.GetOwner() as AUIBaseActor, new Func<ActivityGrid>(this.InitItem), false);
		this.AddEventListener();
	}

	// Token: 0x06007FEA RID: 32746 RVA: 0x0021CB87 File Offset: 0x0021AD87
	private ActivityGrid InitItem()
	{
		return this.GridConstructor() as ActivityGrid;
	}

	// Token: 0x06007FEB RID: 32747 RVA: 0x0021CBA0 File Offset: 0x0021ADA0
	public UniTask Refresh(int shopId)
	{
		ActivityShopScrollItem<TGrid>.<Refresh>d__12 <Refresh>d__;
		<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Refresh>d__.<>4__this = this;
		<Refresh>d__.shopId = shopId;
		<Refresh>d__.<>1__state = -1;
		<Refresh>d__.<>t__builder.Start<ActivityShopScrollItem<TGrid>.<Refresh>d__12>(ref <Refresh>d__);
		return <Refresh>d__.<>t__builder.Task;
	}

	// Token: 0x06007FEC RID: 32748 RVA: 0x0021CBEB File Offset: 0x0021ADEB
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
	}

	// Token: 0x04003D15 RID: 15637
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<ActivityGrid, IPayShopUnionData> LoopScrollView;

	// Token: 0x04003D16 RID: 15638
	private readonly UUILoopScrollViewComponent Scroller;

	// Token: 0x04003D17 RID: 15639
	private readonly UUIItem Item;

	// Token: 0x04003D18 RID: 15640
	private readonly int SourceViewId;

	// Token: 0x04003D19 RID: 15641
	private readonly Func<TGrid> GridConstructor;
}
