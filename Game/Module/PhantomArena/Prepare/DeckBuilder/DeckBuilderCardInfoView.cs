using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054F3 RID: 21747
	[NullableContext(2)]
	[Nullable(0)]
	public class DeckBuilderCardInfoView : UiViewBase
	{
		// Token: 0x0603768E RID: 226958 RVA: 0x00E0EF66 File Offset: 0x00E0D166
		[NullableContext(1)]
		public DeckBuilderCardInfoView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603768F RID: 226959 RVA: 0x00E0EF70 File Offset: 0x00E0D170
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnLeftArrowButtonClick)),
				new ValueTuple<int, Delegate>(3, new Action(this.OnRightArrowButtonClick))
			};
		}

		// Token: 0x06037690 RID: 226960 RVA: 0x00E0F048 File Offset: 0x00E0D248
		protected override UniTask OnBeforeStartAsync()
		{
			DeckBuilderCardInfoView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DeckBuilderCardInfoView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037691 RID: 226961 RVA: 0x00E0F08B File Offset: 0x00E0D28B
		protected override void OnStart()
		{
			this.RefreshView();
			this.SelectToggleByIndex(0, false);
		}

		// Token: 0x06037692 RID: 226962 RVA: 0x00E0F09B File Offset: 0x00E0D29B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnPhantomArenaCardUnlock));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaCardOutlookUnlock, new Action<int>(this.OnPhantomArenaCardOutlookUnlock));
		}

		// Token: 0x06037693 RID: 226963 RVA: 0x00E0F0D5 File Offset: 0x00E0D2D5
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnPhantomArenaCardUnlock));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardOutlookUnlock, new Action<int>(this.OnPhantomArenaCardOutlookUnlock));
		}

		// Token: 0x06037694 RID: 226964 RVA: 0x00E0F110 File Offset: 0x00E0D310
		protected override void OnBeforeShow()
		{
			int? selectedTabIndex = this.Data.SelectedTabIndex;
			if (selectedTabIndex != null && selectedTabIndex.Value >= 0)
			{
				IDeckBuilderCardInfoViewPanelSequencePlayer sequencePlayer = this.TabDataList[selectedTabIndex.Value].SequencePlayer;
				if (sequencePlayer == null)
				{
					return;
				}
				sequencePlayer.PlayShowSequence();
			}
		}

		// Token: 0x06037695 RID: 226965 RVA: 0x00E0F160 File Offset: 0x00E0D360
		public void RefreshView()
		{
			if (this.Data == null)
			{
				return;
			}
			int curCardId = 0;
			if (this.Data.CardList != null && this.Data.CurCardIndex != null)
			{
				DeckBuilderCardItemData deckBuilderCardItemData = this.Data.CardList[this.Data.CurCardIndex.Value];
				curCardId = deckBuilderCardItemData.CardId;
				this.Data.CurCardId = curCardId;
			}
			else
			{
				curCardId = this.Data.CurCardId;
			}
			DeckBuilderCardDetailPanelData deckBuilderCardDetailPanelData = new DeckBuilderCardDetailPanelData
			{
				DeckInfo = this.Data.DeckInfo,
				CardItemData = ModelBase<PhantomArenaModel>.Instance.GetDetailViewCardData(curCardId),
				EntryIdList = ModelBase<PhantomArenaModel>.Instance.GetDetailViewEntryData(curCardId).ToArray(),
				DetailItemData = ModelBase<PhantomArenaModel>.Instance.GetDetailViewDetailItemData(curCardId, this.Data.DeckInfo),
				IsCardUnlocked = ModelBase<PhantomArenaModel>.Instance.IsCardUnlock(curCardId)
			};
			if (this.Data.DeckInfo != null)
			{
				PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(curCardId);
				deckBuilderCardDetailPanelData.CurrencyId = new int?(phantomBattleCardConfig.UnlockConsumeItems()[0].ItemId);
				deckBuilderCardDetailPanelData.UnlockCost = new int?(phantomBattleCardConfig.UnlockConsumeItems()[0].Count);
				deckBuilderCardDetailPanelData.CardLimit = new int?(phantomBattleCardConfig.CardGroupNum);
			}
			if (this.Data.AddCardToDeck != null)
			{
				deckBuilderCardDetailPanelData.AddCardToDeck = delegate()
				{
					DeckBuilderCardInfoViewData data = this.Data;
					if (data == null)
					{
						return;
					}
					Action<int, int> addCardToDeck = data.AddCardToDeck;
					if (addCardToDeck == null)
					{
						return;
					}
					addCardToDeck(curCardId, 1);
				};
			}
			if (this.Data.RemoveCardFromDeck != null)
			{
				deckBuilderCardDetailPanelData.RemoveCardFromDeck = delegate()
				{
					DeckBuilderCardInfoViewData data = this.Data;
					if (data == null)
					{
						return;
					}
					Action<int, int> removeCardFromDeck = data.RemoveCardFromDeck;
					if (removeCardFromDeck == null)
					{
						return;
					}
					removeCardFromDeck(curCardId, 1);
				};
			}
			this.DetailPanelData = deckBuilderCardDetailPanelData;
			DeckBuilderCardDetailPanel detailPanel = this.DetailPanel;
			if (detailPanel != null)
			{
				detailPanel.Refresh(deckBuilderCardDetailPanelData);
			}
			if (this.Data.NeedOutlookTab)
			{
				DeckBuilderCardOutlookUnlockPanelData deckBuilderCardOutlookUnlockPanelData = new DeckBuilderCardOutlookUnlockPanelData
				{
					CardId = curCardId
				};
				this.OutlookUnlockPanelData = deckBuilderCardOutlookUnlockPanelData;
				DeckBuilderCardOutlookUnlockPanel outlookUnlockPanel = this.OutlookUnlockPanel;
				if (outlookUnlockPanel == null)
				{
					return;
				}
				outlookUnlockPanel.Refresh(deckBuilderCardOutlookUnlockPanelData);
			}
		}

		// Token: 0x06037696 RID: 226966 RVA: 0x00E0F372 File Offset: 0x00E0D572
		[NullableContext(1)]
		private DeckBuilderCardInfoTabItem CreateTabItem()
		{
			return new DeckBuilderCardInfoTabItem();
		}

		// Token: 0x06037697 RID: 226967 RVA: 0x00E0F379 File Offset: 0x00E0D579
		private void OnToggleSelect(int newTabIndex)
		{
			this.SelectToggleByIndex(newTabIndex, true);
		}

		// Token: 0x06037698 RID: 226968 RVA: 0x00E0F384 File Offset: 0x00E0D584
		private void SelectToggleByIndex(int newTabIndex, bool bPlayAnim)
		{
			int? selectedTabIndex = this.Data.SelectedTabIndex;
			if (selectedTabIndex != null && selectedTabIndex.Value >= 0)
			{
				UiPanelBase panel = this.TabDataList[selectedTabIndex.Value].Panel;
				if (panel != null)
				{
					panel.SetActive(false);
				}
			}
			this.Data.SelectedTabIndex = new int?(newTabIndex);
			GenericLayout<DeckBuilderCardInfoTabItem, DeckBuilderCardInfoTabItemData> tabLayout = this.TabLayout;
			if (tabLayout != null)
			{
				tabLayout.SelectGridProxy(newTabIndex, false);
			}
			TabData tabData = this.TabDataList[newTabIndex];
			tabData.Panel.SetActive(true);
			Action onShow = tabData.OnShow;
			if (onShow != null)
			{
				onShow();
			}
			if (bPlayAnim)
			{
				IDeckBuilderCardInfoViewPanelSequencePlayer sequencePlayer = tabData.SequencePlayer;
				if (sequencePlayer == null)
				{
					return;
				}
				sequencePlayer.PlayShowSequence();
			}
		}

		// Token: 0x06037699 RID: 226969 RVA: 0x00E0F434 File Offset: 0x00E0D634
		private void PlaySwitchSequence()
		{
			if (this.Data.SelectedTabIndex == null)
			{
				return;
			}
			IDeckBuilderCardInfoViewPanelSequencePlayer sequencePlayer = this.TabDataList[this.Data.SelectedTabIndex.Value].SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlaySwitchSequence();
		}

		// Token: 0x0603769A RID: 226970 RVA: 0x00E0F473 File Offset: 0x00E0D673
		private void OnDetailPanelShow()
		{
		}

		// Token: 0x0603769B RID: 226971 RVA: 0x00E0F475 File Offset: 0x00E0D675
		private void OnOutLookPanelShow()
		{
		}

		// Token: 0x0603769C RID: 226972 RVA: 0x00E0F478 File Offset: 0x00E0D678
		private void OnLeftArrowButtonClick()
		{
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.CardList == null)
			{
				return;
			}
			if (this.Data.CurCardIndex == null)
			{
				return;
			}
			int value = (this.Data.CurCardIndex.Value == 0) ? (this.Data.CardList.Length - 1) : (this.Data.CurCardIndex.Value - 1);
			this.Data.CurCardIndex = new int?(value);
			this.RefreshView();
			this.PlaySwitchSequence();
		}

		// Token: 0x0603769D RID: 226973 RVA: 0x00E0F504 File Offset: 0x00E0D704
		private void OnRightArrowButtonClick()
		{
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.CardList == null)
			{
				return;
			}
			if (this.Data.CurCardIndex == null)
			{
				return;
			}
			int value = (this.Data.CurCardIndex.Value == this.Data.CardList.Length - 1) ? 0 : (this.Data.CurCardIndex.Value + 1);
			this.Data.CurCardIndex = new int?(value);
			this.RefreshView();
			this.PlaySwitchSequence();
		}

		// Token: 0x0603769E RID: 226974 RVA: 0x00E0F58F File Offset: 0x00E0D78F
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603769F RID: 226975 RVA: 0x00E0F598 File Offset: 0x00E0D798
		private void OnPhantomArenaCardUnlock(int cardId)
		{
			if (cardId == this.Data.CurCardId)
			{
				this.RefreshView();
			}
		}

		// Token: 0x060376A0 RID: 226976 RVA: 0x00E0F5AE File Offset: 0x00E0D7AE
		private void OnPhantomArenaCardOutlookUnlock(int cardId)
		{
			if (cardId == this.Data.CurCardId)
			{
				this.RefreshView();
			}
		}

		// Token: 0x060376A1 RID: 226977 RVA: 0x00E0F5C4 File Offset: 0x00E0D7C4
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "UnlockCard"))
			{
				return null;
			}
			DeckBuilderCardDetailPanel detailPanel = this.DetailPanel;
			if (detailPanel == null)
			{
				return null;
			}
			return detailPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0401FCF8 RID: 130296
		protected DeckBuilderCardInfoViewData Data;

		// Token: 0x0401FCF9 RID: 130297
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected DeckBuilderCardInfoTabItemData[] TabItemDataList;

		// Token: 0x0401FCFA RID: 130298
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected List<TabData> TabDataList;

		// Token: 0x0401FCFB RID: 130299
		protected IDeckBuilderCardDetailPanelData DetailPanelData;

		// Token: 0x0401FCFC RID: 130300
		protected IDeckBuilderCardOutlookUnlockPanelData OutlookUnlockPanelData;

		// Token: 0x0401FCFD RID: 130301
		private DeckBuilderCardDetailPanel DetailPanel;

		// Token: 0x0401FCFE RID: 130302
		private DeckBuilderCardOutlookUnlockPanel OutlookUnlockPanel;

		// Token: 0x0401FCFF RID: 130303
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DeckBuilderCardInfoTabItem, DeckBuilderCardInfoTabItemData> TabLayout;

		// Token: 0x0401FD00 RID: 130304
		private PopupCaptionItem CaptionItem;

		// Token: 0x0200B46D RID: 46189
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037DA2 RID: 228770
			public const int TabLayout = 0;

			// Token: 0x04037DA3 RID: 228771
			public const int CaptionItem = 1;

			// Token: 0x04037DA4 RID: 228772
			public const int LeftArrowButton = 2;

			// Token: 0x04037DA5 RID: 228773
			public const int RightArrowButton = 3;

			// Token: 0x04037DA6 RID: 228774
			public const int ContentItem = 4;

			// Token: 0x04037DA7 RID: 228775
			public const int ItemTabPanel = 5;
		}
	}
}
