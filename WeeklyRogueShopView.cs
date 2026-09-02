using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D53 RID: 11603
[NullableContext(1)]
[Nullable(0)]
public class WeeklyRogueShopView : UiViewBase
{
	// Token: 0x06017698 RID: 95896 RVA: 0x0067DFB7 File Offset: 0x0067C1B7
	public WeeklyRogueShopView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06017699 RID: 95897 RVA: 0x0067DFC0 File Offset: 0x0067C1C0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(5, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action(this.OnBtnInfo))
		};
	}

	// Token: 0x0601769A RID: 95898 RVA: 0x0067E0DC File Offset: 0x0067C2DC
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WeeklyRogueShopSelect, new Action<int, RogueWeeklyEntry>(this.OnSelectItem));
		Singleton<EventSystem>.Instance.Add(EEventName.WeeklyRogueSelectOption, new Action(this.OnBuyItem));
		Singleton<EventSystem>.Instance.Add(EEventName.PayShopGoodsBuy, new Action(this.OnCurrencyUpdate));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnPlayerCurrencyChange));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.OnRemoveCommonItem, new Action<IReadOnlyList<int>>(this.OnRemoveCommonItem));
		Singleton<EventSystem>.Instance.Add<IProto_NormalItem, int, int>(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.OnCommonItemCountRefresh));
	}

	// Token: 0x0601769B RID: 95899 RVA: 0x0067E1B0 File Offset: 0x0067C3B0
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyRogueShopSelect, new Action<int, RogueWeeklyEntry>(this.OnSelectItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyRogueSelectOption, new Action(this.OnBuyItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.PayShopGoodsBuy, new Action(this.OnCurrencyUpdate));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnPlayerCurrencyChange));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<int>>(EEventName.OnRemoveCommonItem, new Action<IReadOnlyList<int>>(this.OnRemoveCommonItem));
		Singleton<EventSystem>.Instance.Remove<IProto_NormalItem, int, int>(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.OnCommonItemCountRefresh));
	}

	// Token: 0x0601769C RID: 95900 RVA: 0x0067E284 File Offset: 0x0067C484
	protected override UniTask OnBeforeStartAsync()
	{
		WeeklyRogueShopView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeeklyRogueShopView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601769D RID: 95901 RVA: 0x0067E2C8 File Offset: 0x0067C4C8
	protected override void OnAfterShow()
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("Show", false, null, false);
	}

	// Token: 0x0601769E RID: 95902 RVA: 0x0067E2F0 File Offset: 0x0067C4F0
	private void RefreshCanBuyText()
	{
		LoopScrollView<WeeklyRogueTokenGrid, RogueWeeklyEntry> goodsLayout = this.GoodsLayout;
		if (goodsLayout == null)
		{
			return;
		}
		goodsLayout.RefreshAllGridProxies();
	}

	// Token: 0x0601769F RID: 95903 RVA: 0x0067E302 File Offset: 0x0067C502
	private void OnSelectItem(int gridIndex, RogueWeeklyEntry data)
	{
		this.DetailPanel.Refresh(data);
		LoopScrollView<WeeklyRogueTokenGrid, RogueWeeklyEntry> goodsLayout = this.GoodsLayout;
		if (goodsLayout == null)
		{
			return;
		}
		goodsLayout.SelectGridProxy(gridIndex, false);
	}

	// Token: 0x060176A0 RID: 95904 RVA: 0x0067E324 File Offset: 0x0067C524
	private void OnBuyItem()
	{
		UiAsyncTask task = new UiAsyncTask("RefreshWeeklyRogueShop", delegate()
		{
			WeeklyRogueShopView.<<OnBuyItem>b__13_0>d <<OnBuyItem>b__13_0>d;
			<<OnBuyItem>b__13_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnBuyItem>b__13_0>d.<>4__this = this;
			<<OnBuyItem>b__13_0>d.<>1__state = -1;
			<<OnBuyItem>b__13_0>d.<>t__builder.Start<WeeklyRogueShopView.<<OnBuyItem>b__13_0>d>(ref <<OnBuyItem>b__13_0>d);
			return <<OnBuyItem>b__13_0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x060176A1 RID: 95905 RVA: 0x0067E351 File Offset: 0x0067C551
	private void OnPlayerCurrencyChange(int _)
	{
		this.OnCurrencyUpdate();
	}

	// Token: 0x060176A2 RID: 95906 RVA: 0x0067E359 File Offset: 0x0067C559
	private void OnAddCommonItemList(IReadOnlyList<IProto_NormalItem> protoNormalItems)
	{
		this.OnCurrencyUpdate();
	}

	// Token: 0x060176A3 RID: 95907 RVA: 0x0067E361 File Offset: 0x0067C561
	private void OnRemoveCommonItem(IReadOnlyList<int> readOnlyList)
	{
		this.OnCurrencyUpdate();
	}

	// Token: 0x060176A4 RID: 95908 RVA: 0x0067E369 File Offset: 0x0067C569
	private void OnCommonItemCountRefresh(IProto_NormalItem protoNormalItem, int i, int arg3)
	{
		this.OnCurrencyUpdate();
	}

	// Token: 0x060176A5 RID: 95909 RVA: 0x0067E371 File Offset: 0x0067C571
	private void OnCurrencyUpdate()
	{
		this.RefreshCanBuyText();
	}

	// Token: 0x060176A6 RID: 95910 RVA: 0x0067E379 File Offset: 0x0067C579
	private void OnBtnInfo()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRogueInfo, null, null);
	}

	// Token: 0x060176A7 RID: 95911 RVA: 0x0067E38C File Offset: 0x0067C58C
	private WeeklyRogueTokenGrid CreateGoodsItem()
	{
		return new WeeklyRogueTokenGrid();
	}

	// Token: 0x060176A8 RID: 95912 RVA: 0x0067E394 File Offset: 0x0067C594
	public UniTask RefreshItemList()
	{
		WeeklyRogueShopView.<RefreshItemList>d__21 <RefreshItemList>d__;
		<RefreshItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshItemList>d__.<>4__this = this;
		<RefreshItemList>d__.<>1__state = -1;
		<RefreshItemList>d__.<>t__builder.Start<WeeklyRogueShopView.<RefreshItemList>d__21>(ref <RefreshItemList>d__);
		return <RefreshItemList>d__.<>t__builder.Task;
	}

	// Token: 0x0400B3A5 RID: 45989
	[Nullable(2)]
	public LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400B3A6 RID: 45990
	[Nullable(2)]
	public PopupCaptionItem CaptionItem;

	// Token: 0x0400B3A7 RID: 45991
	[Nullable(2)]
	public WeeklyRogueShopDetail DetailPanel;

	// Token: 0x0400B3A8 RID: 45992
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public LoopScrollView<WeeklyRogueTokenGrid, RogueWeeklyEntry> GoodsLayout;

	// Token: 0x0200902A RID: 36906
	[NullableContext(0)]
	private enum EWeeklyRogueShopDefine
	{
		// Token: 0x040305D8 RID: 198104
		CaptionItem,
		// Token: 0x040305D9 RID: 198105
		PanelInfo,
		// Token: 0x040305DA RID: 198106
		ElementPanel,
		// Token: 0x040305DB RID: 198107
		BtnRefresh,
		// Token: 0x040305DC RID: 198108
		TxtRefresh,
		// Token: 0x040305DD RID: 198109
		LoopView,
		// Token: 0x040305DE RID: 198110
		LoopViewItem,
		// Token: 0x040305DF RID: 198111
		RefreshItemIcon,
		// Token: 0x040305E0 RID: 198112
		RefreshText,
		// Token: 0x040305E1 RID: 198113
		BtnInfo
	}
}
