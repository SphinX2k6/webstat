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

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200527D RID: 21117
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleShopView : UiViewBase
	{
		// Token: 0x06036031 RID: 221233 RVA: 0x00D980FF File Offset: 0x00D962FF
		public RogueBattleShopView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036032 RID: 221234 RVA: 0x00D98108 File Offset: 0x00D96308
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

		// Token: 0x06036033 RID: 221235 RVA: 0x00D98221 File Offset: 0x00D96421
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RogueBattleSelectOption, new Action(this.OnBuyItem));
		}

		// Token: 0x06036034 RID: 221236 RVA: 0x00D9823F File Offset: 0x00D9643F
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueBattleSelectOption, new Action(this.OnBuyItem));
		}

		// Token: 0x06036035 RID: 221237 RVA: 0x00D98260 File Offset: 0x00D96460
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleShopView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleShopView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036036 RID: 221238 RVA: 0x00D982A4 File Offset: 0x00D964A4
		protected override void OnAfterShow()
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Show", false, null, false);
		}

		// Token: 0x06036037 RID: 221239 RVA: 0x00D982CC File Offset: 0x00D964CC
		private void OnSelectItem(int gridIndex, RogueResGainData data)
		{
			this.DetailPanel.Refresh(data);
			LoopScrollView<RogueBattleShopGrid, RogueResGainData> goodsLayout = this.GoodsLayout;
			if (goodsLayout == null)
			{
				return;
			}
			goodsLayout.SelectGridProxy(gridIndex, false);
		}

		// Token: 0x06036038 RID: 221240 RVA: 0x00D982EC File Offset: 0x00D964EC
		private void OnBuyItem()
		{
			UiAsyncTask task = new UiAsyncTask("RefreshWeeklyRogueShop", delegate()
			{
				RogueBattleShopView.<<OnBuyItem>b__11_0>d <<OnBuyItem>b__11_0>d;
				<<OnBuyItem>b__11_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<OnBuyItem>b__11_0>d.<>4__this = this;
				<<OnBuyItem>b__11_0>d.<>1__state = -1;
				<<OnBuyItem>b__11_0>d.<>t__builder.Start<RogueBattleShopView.<<OnBuyItem>b__11_0>d>(ref <<OnBuyItem>b__11_0>d);
				return <<OnBuyItem>b__11_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x06036039 RID: 221241 RVA: 0x00D98319 File Offset: 0x00D96519
		private void OnBtnInfo()
		{
		}

		// Token: 0x0603603A RID: 221242 RVA: 0x00D9831B File Offset: 0x00D9651B
		private RogueBattleShopGrid CreateGoodsItem()
		{
			return new RogueBattleShopGrid
			{
				SelectCallback = new Action<int, RogueResGainData>(this.OnSelectItem)
			};
		}

		// Token: 0x0603603B RID: 221243 RVA: 0x00D98334 File Offset: 0x00D96534
		public UniTask RefreshItemList()
		{
			RogueBattleShopView.<RefreshItemList>d__14 <RefreshItemList>d__;
			<RefreshItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshItemList>d__.<>4__this = this;
			<RefreshItemList>d__.<>1__state = -1;
			<RefreshItemList>d__.<>t__builder.Start<RogueBattleShopView.<RefreshItemList>d__14>(ref <RefreshItemList>d__);
			return <RefreshItemList>d__.<>t__builder.Task;
		}

		// Token: 0x0401F0B5 RID: 127157
		[Nullable(2)]
		public LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401F0B6 RID: 127158
		[Nullable(2)]
		public PopupCaptionItem CaptionItem;

		// Token: 0x0401F0B7 RID: 127159
		[Nullable(2)]
		public RogueBattleShopDetail DetailPanel;

		// Token: 0x0401F0B8 RID: 127160
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public LoopScrollView<RogueBattleShopGrid, RogueResGainData> GoodsLayout;
	}
}
