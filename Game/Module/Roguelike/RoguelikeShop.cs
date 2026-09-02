using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051A1 RID: 20897
	[NullableContext(2)]
	[Nullable(0)]
	public class RoguelikeShop : UiViewBase
	{
		// Token: 0x06035BDC RID: 220124 RVA: 0x00D82D93 File Offset: 0x00D80F93
		[NullableContext(1)]
		public RoguelikeShop(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035BDD RID: 220125 RVA: 0x00D82D9C File Offset: 0x00D80F9C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBtnRefresh));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnBtnInfo));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035BDE RID: 220126 RVA: 0x00D82F70 File Offset: 0x00D81170
		protected override void OnAfterShow()
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Show", false, null, false);
			this.UpdateData(this.ShopIndex);
		}

		// Token: 0x06035BDF RID: 220127 RVA: 0x00D82FA4 File Offset: 0x00D811A4
		private void OnBtnRefresh()
		{
			IReadOnlyList<NumItem> costCurrency = this.Data.CostCurrency;
			if (costCurrency.Count > 0)
			{
				NumItem numItem = costCurrency[0];
				if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(numItem.Id, 0) < numItem.Count)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RogueSpecialRefreshCost_NotEnough", Array.Empty<object>());
					return;
				}
			}
			ControllerBase<RoguelikeController>.Instance.RoguelikeRefreshGainRequest(-1);
		}

		// Token: 0x06035BE0 RID: 220128 RVA: 0x00D8300C File Offset: 0x00D8120C
		private void OnBtnInfo()
		{
			ControllerBase<RoguelikeController>.Instance.OpenRogueInfoView(null, true, true, ERogueInfoViewPage.Overview);
		}

		// Token: 0x06035BE1 RID: 220129 RVA: 0x00D8301C File Offset: 0x00D8121C
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeShop.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeShop.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035BE2 RID: 220130 RVA: 0x00D83060 File Offset: 0x00D81260
		protected override void OnStart()
		{
			this.ElementPanel.Refresh(null);
			this.LoopScrollView = new LoopScrollView<RogueInfoViewTokenDetailGrid, RogueGainEntry>(base.GetLoopScrollViewComponent(5), (AUIBaseActor)base.GetItem(6).GetOwner(), new Func<RogueInfoViewTokenDetailGrid>(this.OnCreateGrid), false);
			this.Data = (RoguelikeChooseData)this.OpenParam;
			this.ShopIndex = this.Data.Index;
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
			this.UpdateItemList();
			this.UpdateRefreshButton();
		}

		// Token: 0x06035BE3 RID: 220131 RVA: 0x00D830E8 File Offset: 0x00D812E8
		public void UpdateItemList()
		{
			List<RogueGainEntry> rogueGainEntryList = this.Data.RogueGainEntryList;
			rogueGainEntryList.Sort(delegate(RogueGainEntry a, RogueGainEntry b)
			{
				bool? isSell = a.IsSell;
				bool? isSell2 = b.IsSell;
				if (!(isSell.GetValueOrDefault() == isSell2.GetValueOrDefault() & isSell != null == (isSell2 != null)))
				{
					if (!a.IsSell.GetValueOrDefault())
					{
						return -1;
					}
					return 1;
				}
				else if (a.IsDiscounted() != b.IsDiscounted())
				{
					if (!a.IsDiscounted())
					{
						return 1;
					}
					return -1;
				}
				else
				{
					if (a.IsDiscounted() && b.IsDiscounted())
					{
						return a.CurrentPrice.Value - b.CurrentPrice.Value;
					}
					if (!a.IsDiscounted() && !b.IsDiscounted())
					{
						return a.OriginalPrice - b.OriginalPrice;
					}
					return a.Index.Value - b.Index.Value;
				}
			});
			this.LoopScrollView.RefreshByData(rogueGainEntryList, false, null, false);
			if (this.Data.RogueGainEntryList.Count > 0)
			{
				RogueGainEntry rogueGainEntry = this.Data.RogueGainEntryList[0];
				ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = rogueGainEntry;
				this.LoopScrollView.SelectGridProxy(0, false);
				this.ShopDetailPanel.Refresh(rogueGainEntry);
				bool flag = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(rogueGainEntry.ShopItemCoinId, 0) >= rogueGainEntry.CurrentPrice.Value;
				if (!rogueGainEntry.IsSell.GetValueOrDefault() && flag)
				{
					this.ElementPanel.Refresh(rogueGainEntry);
					return;
				}
				this.ElementPanel.Refresh(null);
			}
		}

		// Token: 0x06035BE4 RID: 220132 RVA: 0x00D831D0 File Offset: 0x00D813D0
		private void UpdateRefreshButton()
		{
			int value = this.Data.UseTime.Value;
			int value2 = this.Data.MaxTime.Value;
			base.GetButton(3).RootUIComp.Get().SetUIActive(value2 > 0);
			int num = value2 - value;
			UUIText text = base.GetText(4);
			if (num <= 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoguelikeView_29_Text", new <>z__ReadOnlyArray<object>(new object[]
				{
					num,
					value2
				}));
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoguelikeView_28_Text", new <>z__ReadOnlyArray<object>(new object[]
				{
					num,
					value2
				}));
			}
			IReadOnlyList<NumItem> costCurrency = this.Data.CostCurrency;
			if (costCurrency.Count > 0)
			{
				NumItem numItem = costCurrency[0];
				string textStringId = (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(numItem.Id, 0) >= numItem.Count) ? "RogueSpecialRefreshCost" : "RogueSpecialRefreshCost_Not";
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), textStringId, new <>z__ReadOnlySingleElementList<object>(numItem.Count));
				base.SetTextureByPath(ConfigBase<RoguelikeConfig>.Instance.GetRogueCurrencyConfig(numItem.Id).Value.IconSmall, base.GetTexture(7), null, null);
			}
		}

		// Token: 0x06035BE5 RID: 220133 RVA: 0x00D8333C File Offset: 0x00D8153C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<RogueGainEntry, int>(EEventName.RoguelikeInfoSelectedToken, new Action<RogueGainEntry, int>(this.OnSelectedToken));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RoguelikeRefreshGain, new Action<int>(this.UpdateData));
			Singleton<EventSystem>.Instance.Add<RogueGainEntry, RogueGainEntry, bool, int, RoguelikeChooseDataResultResponse>(EEventName.RoguelikeChooseDataResult, new Action<RogueGainEntry, RogueGainEntry, bool, int, RoguelikeChooseDataResultResponse>(this.OnChooseData));
		}

		// Token: 0x06035BE6 RID: 220134 RVA: 0x00D833A0 File Offset: 0x00D815A0
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeInfoSelectedToken, new Action<RogueGainEntry, int>(this.OnSelectedToken));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeRefreshGain, new Action<int>(this.UpdateData));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeChooseDataResult, new Action<RogueGainEntry, RogueGainEntry, bool, int, RoguelikeChooseDataResultResponse>(this.OnChooseData));
		}

		// Token: 0x06035BE7 RID: 220135 RVA: 0x00D83404 File Offset: 0x00D81604
		[NullableContext(1)]
		private void OnChooseData(RogueGainEntry buyToken, RogueGainEntry oldData, bool isSuccess, int index, RoguelikeChooseDataResultResponse response)
		{
			this.UpdateData(this.ShopIndex);
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.SetCurrencyItemList(new int[]
				{
					80100000
				});
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonSelectResultView, new RogueSelectResult(ModelBase<RoguelikeModel>.Instance.RogueInfo.PhantomEntry, oldData, buyToken, true), null);
		}

		// Token: 0x06035BE8 RID: 220136 RVA: 0x00D83464 File Offset: 0x00D81664
		[NullableContext(1)]
		private void OnSelectedToken(RogueGainEntry token, int index)
		{
			ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = token;
			this.LoopScrollView.SelectGridProxy(index, false);
			this.ShopDetailPanel.Refresh(token);
			bool flag = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(token.ShopItemCoinId, 0) >= token.CurrentPrice.Value;
			if (!token.IsSell.GetValueOrDefault() && flag)
			{
				this.ElementPanel.Refresh(token);
				return;
			}
			this.ElementPanel.Refresh(null);
		}

		// Token: 0x06035BE9 RID: 220137 RVA: 0x00D834E4 File Offset: 0x00D816E4
		protected override void OnBeforeHide()
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Hide", false, null, false);
		}

		// Token: 0x06035BEA RID: 220138 RVA: 0x00D8350C File Offset: 0x00D8170C
		private void UpdateData(int index)
		{
			this.ShopIndex = index;
			this.Data = ModelBase<RoguelikeModel>.Instance.GetRoguelikeChooseDataById(index);
			this.UpdateItemList();
			this.UpdateRefreshButton();
		}

		// Token: 0x06035BEB RID: 220139 RVA: 0x00D83532 File Offset: 0x00D81732
		[NullableContext(1)]
		private RogueInfoViewTokenDetailGrid OnCreateGrid()
		{
			return new RogueInfoViewTokenDetailGrid();
		}

		// Token: 0x0401ED76 RID: 126326
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public LoopScrollView<RogueInfoViewTokenDetailGrid, RogueGainEntry> LoopScrollView;

		// Token: 0x0401ED77 RID: 126327
		public ElementPanel ElementPanel;

		// Token: 0x0401ED78 RID: 126328
		public RoguelikeShopDetail ShopDetailPanel;

		// Token: 0x0401ED79 RID: 126329
		public RoguelikeChooseData Data;

		// Token: 0x0401ED7A RID: 126330
		public int ShopIndex;

		// Token: 0x0401ED7B RID: 126331
		public LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401ED7C RID: 126332
		public PopupCaptionItem CaptionItem;

		// Token: 0x0200B172 RID: 45426
		[NullableContext(0)]
		public class ERoguelikeShopDefine
		{
			// Token: 0x04037072 RID: 225394
			public const int CaptionItem = 0;

			// Token: 0x04037073 RID: 225395
			public const int PanelInfo = 1;

			// Token: 0x04037074 RID: 225396
			public const int ElementPanel = 2;

			// Token: 0x04037075 RID: 225397
			public const int BtnRefresh = 3;

			// Token: 0x04037076 RID: 225398
			public const int TxtRefresh = 4;

			// Token: 0x04037077 RID: 225399
			public const int LoopView = 5;

			// Token: 0x04037078 RID: 225400
			public const int LoopViewItem = 6;

			// Token: 0x04037079 RID: 225401
			public const int RefreshItemIcon = 7;

			// Token: 0x0403707A RID: 225402
			public const int RefreshText = 8;

			// Token: 0x0403707B RID: 225403
			public const int BtnInfo = 9;
		}
	}
}
