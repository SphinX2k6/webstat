using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001415 RID: 5141
public class RewardShopTabView : UiTabViewBase
{
	// Token: 0x06008E7A RID: 36474 RVA: 0x00256C36 File Offset: 0x00254E36
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06008E7B RID: 36475 RVA: 0x00256C6F File Offset: 0x00254E6F
	protected override void OnStart()
	{
		this.LoopScrollView = new LoopScrollView<RewardShopGridItem, IPayShopUnionData>(base.GetLoopScrollViewComponent(0), (AUIBaseActor)base.GetItem(1).GetOwner(), new Func<RewardShopGridItem>(this.InitItem), false);
	}

	// Token: 0x06008E7C RID: 36476 RVA: 0x00256CA4 File Offset: 0x00254EA4
	protected override UniTask OnShowAsyncImplementImplement()
	{
		RewardShopTabView.<OnShowAsyncImplementImplement>d__3 <OnShowAsyncImplementImplement>d__;
		<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnShowAsyncImplementImplement>d__.<>4__this = this;
		<OnShowAsyncImplementImplement>d__.<>1__state = -1;
		<OnShowAsyncImplementImplement>d__.<>t__builder.Start<RewardShopTabView.<OnShowAsyncImplementImplement>d__3>(ref <OnShowAsyncImplementImplement>d__);
		return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06008E7D RID: 36477 RVA: 0x00256CE8 File Offset: 0x00254EE8
	protected override void OnBeforeShow()
	{
		UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
		LevelSequencePlayer levelSequencePlayer = (tabBehavior != null) ? tabBehavior.GetLevelSequencePlayer() : null;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
	}

	// Token: 0x06008E7E RID: 36478 RVA: 0x00256D22 File Offset: 0x00254F22
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Add(EEventName.ShopVersionCodeChange, new Action(this.OnShopVersionCodeChange));
	}

	// Token: 0x06008E7F RID: 36479 RVA: 0x00256D5C File Offset: 0x00254F5C
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShopVersionCodeChange, new Action(this.OnShopVersionCodeChange));
	}

	// Token: 0x06008E80 RID: 36480 RVA: 0x00256D96 File Offset: 0x00254F96
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
	{
		this.LoopScrollView.RefreshAllGridProxies();
	}

	// Token: 0x06008E81 RID: 36481 RVA: 0x00256DA4 File Offset: 0x00254FA4
	private void OnShopVersionCodeChange()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PayShopRefresh);
		Action value = delegate()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.RewardMainView, null);
		};
		confirmBoxDataNew.FunctionMap[1] = value;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		Singleton<Log>.Instance.Info(ELogModule.Shop, ELogAuthor.XXJ, "PayShop:RewardShopTabView 商品VersionCode不同步,打开弹窗", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06008E82 RID: 36482 RVA: 0x00256E11 File Offset: 0x00255011
	[NullableContext(1)]
	private RewardShopGridItem InitItem()
	{
		return new RewardShopGridItem();
	}

	// Token: 0x04004263 RID: 16995
	[Nullable(1)]
	protected LoopScrollView<RewardShopGridItem, IPayShopUnionData> LoopScrollView;

	// Token: 0x02007806 RID: 30726
	private class EComponentDefine
	{
		// Token: 0x0402949E RID: 169118
		public const int Scroll = 0;

		// Token: 0x0402949F RID: 169119
		public const int RewardItem = 1;
	}
}
