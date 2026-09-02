using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.InputView.Controller;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x0200550F RID: 21775
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaNewDeckBuilderTabView : PhantomArenaChildViewBase
	{
		// Token: 0x17008F23 RID: 36643
		// (get) Token: 0x06037884 RID: 227460 RVA: 0x00E15EDE File Offset: 0x00E140DE
		// (set) Token: 0x06037885 RID: 227461 RVA: 0x00E15EEB File Offset: 0x00E140EB
		public new IPhantomArenaDeckBuilderTabViewModel ViewModel
		{
			get
			{
				return this.ViewModel as IPhantomArenaDeckBuilderTabViewModel;
			}
			set
			{
				this.ViewModel = value;
			}
		}

		// Token: 0x06037886 RID: 227462 RVA: 0x00E15EF4 File Offset: 0x00E140F4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIText)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUISprite)),
				new ValueTuple<int, Type>(18, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnPrePageBtnClick)),
				new ValueTuple<int, Delegate>(8, new Action(this.OnNextPageBtnClick)),
				new ValueTuple<int, Delegate>(9, new Action(this.OnQuicklyBuildBtnClick)),
				new ValueTuple<int, Delegate>(10, new Action(this.OnSaveBtnClick)),
				new ValueTuple<int, Delegate>(12, new Action(this.OnChangeNameBtnClick)),
				new ValueTuple<int, Delegate>(13, new Action(this.OnDeckDeleteBtnClick))
			};
		}

		// Token: 0x06037887 RID: 227463 RVA: 0x00E16158 File Offset: 0x00E14358
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaNewDeckBuilderTabView.<OnBeforeStartAsync>d__27 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaNewDeckBuilderTabView.<OnBeforeStartAsync>d__27>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037888 RID: 227464 RVA: 0x00E1619C File Offset: 0x00E1439C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnPhantomArenaCardUnlock));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaCardOutlookUnlock, new Action<int>(this.OnPhantomArenaCardOutlookUnlock));
			Singleton<EventSystem>.Instance.Add(EEventName.GamepadTriggerCardInfo, new Action<UUIItem>(this.OnGamepadTriggerCardInfo));
		}

		// Token: 0x06037889 RID: 227465 RVA: 0x00E16200 File Offset: 0x00E14400
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnPhantomArenaCardUnlock));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardOutlookUnlock, new Action<int>(this.OnPhantomArenaCardOutlookUnlock));
			Singleton<EventSystem>.Instance.Remove(EEventName.GamepadTriggerCardInfo, new Action<UUIItem>(this.OnGamepadTriggerCardInfo));
		}

		// Token: 0x0603788A RID: 227466 RVA: 0x00E16264 File Offset: 0x00E14464
		protected override UniTask OnBeforeShowAsyncImplement()
		{
			PhantomArenaNewDeckBuilderTabView.<OnBeforeShowAsyncImplement>d__30 <OnBeforeShowAsyncImplement>d__;
			<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<PhantomArenaNewDeckBuilderTabView.<OnBeforeShowAsyncImplement>d__30>(ref <OnBeforeShowAsyncImplement>d__);
			return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603788B RID: 227467 RVA: 0x00E162A8 File Offset: 0x00E144A8
		protected override UniTask OnPlayingShowSequenceAsync()
		{
			PhantomArenaNewDeckBuilderTabView.<OnPlayingShowSequenceAsync>d__31 <OnPlayingShowSequenceAsync>d__;
			<OnPlayingShowSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingShowSequenceAsync>d__.<>4__this = this;
			<OnPlayingShowSequenceAsync>d__.<>1__state = -1;
			<OnPlayingShowSequenceAsync>d__.<>t__builder.Start<PhantomArenaNewDeckBuilderTabView.<OnPlayingShowSequenceAsync>d__31>(ref <OnPlayingShowSequenceAsync>d__);
			return <OnPlayingShowSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603788C RID: 227468 RVA: 0x00E162EC File Offset: 0x00E144EC
		protected override UniTask OnPlayingStartSequenceAsync()
		{
			PhantomArenaNewDeckBuilderTabView.<OnPlayingStartSequenceAsync>d__32 <OnPlayingStartSequenceAsync>d__;
			<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingStartSequenceAsync>d__.<>4__this = this;
			<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
			<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<PhantomArenaNewDeckBuilderTabView.<OnPlayingStartSequenceAsync>d__32>(ref <OnPlayingStartSequenceAsync>d__);
			return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603788D RID: 227469 RVA: 0x00E1632F File Offset: 0x00E1452F
		protected override void OnBeforeHide()
		{
			this.ResetMainViewOverrideCloseFunc();
			PhantomArenaMainViewSwitchItem showLockedSwitchItem = this.ShowLockedSwitchItem;
			if (showLockedSwitchItem != null)
			{
				showLockedSwitchItem.SetActive(false);
			}
			PhantomArenaMainViewSwitchItem showLockedSwitchItem2 = this.ShowLockedSwitchItem;
			if (showLockedSwitchItem2 == null)
			{
				return;
			}
			showLockedSwitchItem2.SetOnStateChangedCallback(null);
		}

		// Token: 0x0603788E RID: 227470 RVA: 0x00E1635C File Offset: 0x00E1455C
		private List<ICardTabItemData> CreateElementTabItemDataList()
		{
			List<ECardTabType> list = new List<ECardTabType>();
			list.Add(ECardTabType.All);
			list.Add(ECardTabType.Ice);
			list.Add(ECardTabType.Fire);
			list.Add(ECardTabType.Thunder);
			list.Add(ECardTabType.Wind);
			list.Add(ECardTabType.Light);
			list.Add(ECardTabType.Dark);
			List<ICardTabItemData> list2 = new List<ICardTabItemData>();
			foreach (ECardTabType tabType in list)
			{
				ICardTabItemData item = this.CreateElementTabItemData(tabType);
				list2.Add(item);
			}
			return list2;
		}

		// Token: 0x0603788F RID: 227471 RVA: 0x00E163F0 File Offset: 0x00E145F0
		private ICardTabItemData CreateElementTabItemData(ECardTabType tabType)
		{
			ICardTabItemData result;
			if (tabType == ECardTabType.All)
			{
				result = new CardTabItemData
				{
					TabType = ECardTabType.All,
					ElementConfigId = null,
					TabTexturePath = "/Game/Aki/UI/UIResources/Common/Image/IconElementRound/T_IconElementAll.T_IconElementAll",
					TabElementColor = "FFFFFFFF",
					ShowRedDot = false,
					IsDisable = false,
					IsArrivedMax = false
				};
			}
			else
			{
				ECardElement ecardElement = PhantomArenaDefine.cardTabTypeToElementConfigId[tabType];
				PhantomBattleCardElement phantomBattleElementConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleElementConfig((int)ecardElement);
				result = new CardTabItemData
				{
					TabType = tabType,
					ElementConfigId = new ECardElement?(ecardElement),
					TabTexturePath = phantomBattleElementConfig.TabIcon,
					TabElementColor = phantomBattleElementConfig.TabElementColor,
					ShowRedDot = false,
					IsDisable = false,
					IsArrivedMax = false
				};
			}
			return result;
		}

		// Token: 0x06037890 RID: 227472 RVA: 0x00E164AC File Offset: 0x00E146AC
		private void UpdateLibraryCardDataList()
		{
			this.LibraryCardDataList.Clear();
			this.LibraryCardDataMap.Clear();
			foreach (PhantomBattleCard phantomBattleCard in ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardByActivityId(base.ActivityId))
			{
				if (!phantomBattleCard.IsNpcCard)
				{
					int id = phantomBattleCard.Id;
					int element = phantomBattleCard.Element;
					Dictionary<int, int> dictionary = phantomBattleCard.InitAttack();
					int cardGroupNum = phantomBattleCard.CardGroupNum;
					int leftCount = cardGroupNum - this.DeckInfo.GetCardCount(id);
					DeckBuilderCardItemData deckBuilderCardItemData = new DeckBuilderCardItemData
					{
						CardId = id,
						CardFaceTexturePath = phantomBattleCard.CardFaceTexture,
						Cost = phantomBattleCard.Cost,
						Element = element,
						Attack = dictionary.GetValueOrDefault(0, 0),
						Life = dictionary.GetValueOrDefault(1, 0),
						IsLocked = !ModelBase<PhantomArenaModel>.Instance.IsCardUnlock(id),
						LeftCount = leftCount,
						MaxCount = cardGroupNum,
						AddCardToDeck = new Action<int, int>(this.AddCardToDeck),
						DeckInfo = this.DeckInfo,
						OpenCardInfoView = new Action<int>(this.OpenCardInfoView),
						CardSpineData = ModelBase<PhantomArenaModel>.Instance.CreateCardSpineData(id),
						OutlookUnlocked = ModelBase<PhantomArenaModel>.Instance.IsCardOutlookUnlock(id),
						CardFaceType = ModelBase<PhantomArenaModel>.Instance.GetCardFaceType(id),
						Disabled = false,
						IsAllInDeck = false,
						CardType = (ECardType)phantomBattleCard.Type
					};
					this.UpdateStateContextInCardData(deckBuilderCardItemData);
					this.LibraryCardDataList.Add(deckBuilderCardItemData);
					this.LibraryCardDataMap[id] = deckBuilderCardItemData;
				}
			}
			this.LibraryCardDataList.Sort((DeckBuilderCardItemData a, DeckBuilderCardItemData b) => PhantomArenaDefine.deckBuilderCardItemDataSortFunc(a, b));
		}

		// Token: 0x06037891 RID: 227473 RVA: 0x00E166A0 File Offset: 0x00E148A0
		private void UpdateAllPageCardDataList()
		{
			CardFilterContext filterContext = new CardFilterContext
			{
				CostFilter = (ECardCostFilter)this.CurCostFilter,
				ElementFilter = this.TabDataList[this.CurSelectedElementTabIndex].TabType,
				IncludeLocked = this.IncludeLockedCard
			};
			this.AllPageCardDataList = ModelBase<PhantomArenaModel>.Instance.FilterCardList<DeckBuilderCardItemData>(this.LibraryCardDataList, filterContext);
			int maxPage = (int)Math.Ceiling((double)this.AllPageCardDataList.Count / (double)this.MaxCardCountPerPage);
			this.MaxPage = maxPage;
			this.MinPage = Math.Min(this.MaxPage, 1);
			this.CurPage = this.MinPage;
		}

		// Token: 0x06037892 RID: 227474 RVA: 0x00E16740 File Offset: 0x00E14940
		private void UpdateCurPageCardDataList()
		{
			int num = (this.CurPage - 1) * this.MaxCardCountPerPage;
			int num2 = this.CurPage * this.MaxCardCountPerPage;
			this.CurPageCardDataList = this.AllPageCardDataList.Skip(num).Take(num2 - num).ToList<DeckBuilderCardItemData>();
		}

		// Token: 0x06037893 RID: 227475 RVA: 0x00E1678C File Offset: 0x00E1498C
		private void RefreshPageText()
		{
			UUIText text = base.GetText(6);
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurPage);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.MaxPage);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06037894 RID: 227476 RVA: 0x00E167E4 File Offset: 0x00E149E4
		private void RefreshCardLayout()
		{
			bool uiactive = this.CurPageCardDataList.Count == 0;
			GenericLayout<DeckBuilderCardItem, DeckBuilderCardItemData> cardLayout = this.CardLayout;
			if (cardLayout != null)
			{
				cardLayout.RefreshByData(this.CurPageCardDataList, null, true);
			}
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x06037895 RID: 227477 RVA: 0x00E1682C File Offset: 0x00E14A2C
		private UniTask RefreshCardLayoutAsync(bool playGridAnim)
		{
			PhantomArenaNewDeckBuilderTabView.<RefreshCardLayoutAsync>d__41 <RefreshCardLayoutAsync>d__;
			<RefreshCardLayoutAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCardLayoutAsync>d__.<>4__this = this;
			<RefreshCardLayoutAsync>d__.playGridAnim = playGridAnim;
			<RefreshCardLayoutAsync>d__.<>1__state = -1;
			<RefreshCardLayoutAsync>d__.<>t__builder.Start<PhantomArenaNewDeckBuilderTabView.<RefreshCardLayoutAsync>d__41>(ref <RefreshCardLayoutAsync>d__);
			return <RefreshCardLayoutAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037896 RID: 227478 RVA: 0x00E16878 File Offset: 0x00E14A78
		private void RefreshAllCardLeftCount()
		{
			foreach (DeckBuilderCardItemData deckBuilderCardItemData in this.LibraryCardDataList)
			{
				deckBuilderCardItemData.LeftCount = deckBuilderCardItemData.MaxCount - this.DeckInfo.GetCardCount(deckBuilderCardItemData.CardId);
				GenericLayout<DeckBuilderCardItem, DeckBuilderCardItemData> cardLayout = this.CardLayout;
				if (cardLayout != null)
				{
					DeckBuilderCardItem layoutItemByKey = cardLayout.GetLayoutItemByKey(deckBuilderCardItemData.CardId);
					if (layoutItemByKey != null)
					{
						layoutItemByKey.RefreshLeftCount();
					}
				}
			}
		}

		// Token: 0x06037897 RID: 227479 RVA: 0x00E1690C File Offset: 0x00E14B0C
		private void UpdateStateContextInCardData(DeckBuilderCardItemData data)
		{
			data.IsAllInDeck = (data.LeftCount == 0);
			AddCardContext context = new AddCardContext
			{
				CardId = data.CardId,
				Cost = data.Cost,
				Element = data.Element,
				MaxCount = data.MaxCount,
				AddCount = 1,
				CardType = data.CardType
			};
			data.Disabled = (this.DeckInfo.CheckCanAddCard(context) > EAddCardResult.Success);
		}

		// Token: 0x06037898 RID: 227480 RVA: 0x00E16988 File Offset: 0x00E14B88
		private void RefreshAllCardAvailable()
		{
			foreach (DeckBuilderCardItemData deckBuilderCardItemData in this.LibraryCardDataList)
			{
				this.UpdateStateContextInCardData(deckBuilderCardItemData);
				GenericLayout<DeckBuilderCardItem, DeckBuilderCardItemData> cardLayout = this.CardLayout;
				DeckBuilderCardItem deckBuilderCardItem = (cardLayout != null) ? cardLayout.GetLayoutItemByKey(deckBuilderCardItemData.CardId) : null;
				if (deckBuilderCardItem != null)
				{
					deckBuilderCardItem.RefreshAllInDeckComponent();
					deckBuilderCardItem.RefreshDisabledComponent();
				}
			}
		}

		// Token: 0x06037899 RID: 227481 RVA: 0x00E16A08 File Offset: 0x00E14C08
		private void RefreshDeckSlotsPanel(bool needRequestCheckCardSkillUnlock = true)
		{
			DeckBuilderDeckSlotsPanelData data = new DeckBuilderDeckSlotsPanelData
			{
				DeckInfo = this.DeckInfo,
				SlotLongPressStartTime = new float?((float)ConfigBase<PhantomArenaConfig>.Instance.GetSlotLongPressStartTime(base.ActivityId)),
				SlotLongPressEndTime = new float?((float)ConfigBase<PhantomArenaConfig>.Instance.GetSlotLongPressEndTime(base.ActivityId)),
				OnCoreSlotItemSortClick = new Action<DeckBuilderCardSlotItem>(this.OnCoreSlotItemClick),
				OnCoreSlotItemLongPress = new Action<DeckBuilderCardSlotItem, float>(this.OnSlotItemLongPress),
				CanCoreSlotItemToggleChange = new Func<DeckBuilderCardSlotItem, bool>(this.CanCoreSlotItemToggleChange),
				OnNormalSlotItemSortClick = new Action<DeckBuilderCardSlotItem>(this.OnNormalSlotItemClick),
				OnNormalSlotItemLongPress = new Action<DeckBuilderCardSlotItem, float>(this.OnSlotItemLongPress),
				CanNormalSlotItemToggleChange = new Func<DeckBuilderCardSlotItem, bool>(this.CanNormalSlotItemToggleChange),
				CanFieldSlotItemToggleChange = new Func<DeckBuilderCardSlotItem, bool>(this.CanFieldSlotItemToggleChange),
				OnFieldCardItemEffectBtnClick = new Action<DeckBuilderCardSlotItem>(this.OnFieldCardItemEffectBtnClick),
				OnSlotItemLongPressEnd = new Action(this.OnSlotItemLongPressEnd),
				OnSlotCardPointEnterCallback = new Action<int>(this.OnSlotCardPointEnterCallback),
				OnSlotCardPointExitCallback = new Action(this.OnSlotCardPointExitCallback),
				SortContext = new CardSlotSortContext
				{
					SortType = (ECardSlotSortType)this.CurSlotSortType,
					IsAscending = this.IsAscending
				},
				ShowLocked = false,
				ShowOutlook = true,
				IsNeedFieldCard = true,
				IsNeedRequestCheckCardSkillUnlock = needRequestCheckCardSkillUnlock
			};
			DeckBuilderDeckSlotsPanel deckSlotsPanel = this.DeckSlotsPanel;
			if (deckSlotsPanel == null)
			{
				return;
			}
			deckSlotsPanel.RefreshByData(data);
		}

		// Token: 0x0603789A RID: 227482 RVA: 0x00E16B78 File Offset: 0x00E14D78
		public void RefreshElementTab()
		{
			List<ECardElement> elementList = this.DeckInfo.GetElementList();
			foreach (ICardTabItemData cardTabItemData in this.TabDataList)
			{
				if (cardTabItemData.TabType == ECardTabType.All)
				{
					cardTabItemData.IsArrivedMax = this.DeckInfo.IsDeckFull();
				}
				else
				{
					ECardElement tabElement = PhantomArenaDefine.cardTabTypeToElementConfigId[cardTabItemData.TabType];
					bool flag = this.DeckInfo.CheckCanAddElement(tabElement);
					cardTabItemData.IsDisable = !flag;
					cardTabItemData.ShowRedDot = (elementList.FindIndex((ECardElement element) => element == tabElement) != -1);
				}
			}
			LoopScrollView<DeckBuilderElementTabItem, ICardTabItemData> elementTabScrollView = this.ElementTabScrollView;
			if (elementTabScrollView == null)
			{
				return;
			}
			elementTabScrollView.RefreshAllGridProxies();
		}

		// Token: 0x0603789B RID: 227483 RVA: 0x00E16C58 File Offset: 0x00E14E58
		public void RefreshFullTip()
		{
			ECardTabType tabType = this.TabDataList[this.CurSelectedElementTabIndex].TabType;
			ECardElement element;
			PhantomArenaDefine.cardTabTypeToElementConfigId.TryGetValue(tabType, out element);
			bool flag = this.DeckInfo.IsDeckFull();
			bool flag2 = !this.DeckInfo.CheckCanAddElement(element);
			UUIItem item = base.GetItem(15);
			if (item != null)
			{
				item.SetUIActive(flag || flag2);
			}
			string textStringId = flag2 ? "PrefabTextItem_3954833905_Text" : "PrefabTextItem_3799404500_Text";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), textStringId, Array.Empty<object>());
		}

		// Token: 0x0603789C RID: 227484 RVA: 0x00E16CE8 File Offset: 0x00E14EE8
		private void OpenCardInfoView(int cardId)
		{
			DeckBuilderCardInfoViewData param = new DeckBuilderCardInfoViewData
			{
				CurCardId = cardId,
				CardList = this.AllPageCardDataList.ToArray(),
				DeckInfo = this.DeckInfo,
				AddCardToDeck = new Action<int, int>(this.AddCardToDeck),
				RemoveCardFromDeck = new Action<int, int>(this.RemoveCardSlotByCardId),
				CurCardIndex = new int?(this.AllPageCardDataList.FindIndex((DeckBuilderCardItemData data) => data.CardId == cardId)),
				CurrencyId = new int?(ModelBase<PhantomArenaModel>.Instance.GetDustItemId(base.ActivityId)),
				SelectedTabIndex = new int?(0),
				NeedOutlookTab = false
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DeckBuilderCardInfoView, param, null);
		}

		// Token: 0x0603789D RID: 227485 RVA: 0x00E16DB8 File Offset: 0x00E14FB8
		protected void AddCardToDeck(int cardId, int addCount = 1)
		{
			if (this.DeckInfo == null)
			{
				return;
			}
			DeckBuilderCardItemData deckBuilderCardItemData = this.AllPageCardDataList.Find((DeckBuilderCardItemData cardData) => cardData.CardId == cardId);
			if (deckBuilderCardItemData == null)
			{
				return;
			}
			if (deckBuilderCardItemData.IsLocked)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_1071", Array.Empty<object>());
				return;
			}
			int cardCount = this.DeckInfo.GetCardCount(deckBuilderCardItemData.CardId);
			AddCardContext context = new AddCardContext
			{
				CardId = deckBuilderCardItemData.CardId,
				Cost = deckBuilderCardItemData.Cost,
				Element = deckBuilderCardItemData.Element,
				MaxCount = deckBuilderCardItemData.MaxCount,
				AddCount = addCount,
				CardType = deckBuilderCardItemData.CardType
			};
			EAddCardResult eaddCardResult = this.DeckInfo.AddCard(context);
			if (eaddCardResult == EAddCardResult.Success)
			{
				ControllerBase<PhantomArenaController>.Instance.RequestCheckCardSkillUnlock(this.DeckInfo, new Action<PhantomBattleCheckCardSkillUnlockResponse>(this.RefreshFieldCardEffectUnlock));
				DeckBuilderCardItemData deckBuilderCardItemData2 = this.LibraryCardDataMap[deckBuilderCardItemData.CardId];
				int cardCount2 = this.DeckInfo.GetCardCount(deckBuilderCardItemData.CardId);
				deckBuilderCardItemData2.LeftCount = deckBuilderCardItemData2.MaxCount - cardCount2;
				GenericLayout<DeckBuilderCardItem, DeckBuilderCardItemData> cardLayout = this.CardLayout;
				if (cardLayout != null)
				{
					DeckBuilderCardItem layoutItemByKey = cardLayout.GetLayoutItemByKey(deckBuilderCardItemData2.CardId);
					if (layoutItemByKey != null)
					{
						layoutItemByKey.RefreshLeftCount();
					}
				}
				int? needPlayAddAnimCard = (cardCount == 0) ? new int?(deckBuilderCardItemData.CardId) : null;
				if (deckBuilderCardItemData2.Cost == ConfigBase<PhantomArenaConfig>.Instance.GetPhantomArenaCardCoreCost())
				{
					DeckBuilderDeckSlotsPanel deckSlotsPanel = this.DeckSlotsPanel;
					if (deckSlotsPanel != null)
					{
						deckSlotsPanel.RefreshCoreCardSlot(needPlayAddAnimCard);
					}
					DeckBuilderDeckSlotsPanel deckSlotsPanel2 = this.DeckSlotsPanel;
					if (deckSlotsPanel2 != null)
					{
						deckSlotsPanel2.SwitchMaskState(EPhantomArenaDeckSlotType.Core);
					}
				}
				else if (deckBuilderCardItemData2.CardType == ECardType.Field)
				{
					DeckBuilderDeckSlotsPanel deckSlotsPanel3 = this.DeckSlotsPanel;
					if (deckSlotsPanel3 != null)
					{
						deckSlotsPanel3.RefreshFieldCardSlot(needPlayAddAnimCard);
					}
				}
				else
				{
					DeckBuilderDeckSlotsPanel deckSlotsPanel4 = this.DeckSlotsPanel;
					if (deckSlotsPanel4 != null)
					{
						deckSlotsPanel4.RefreshNormalCardSlot(needPlayAddAnimCard, true, deckBuilderCardItemData.CardId);
					}
					DeckBuilderDeckSlotsPanel deckSlotsPanel5 = this.DeckSlotsPanel;
					if (deckSlotsPanel5 != null)
					{
						deckSlotsPanel5.SwitchMaskState(EPhantomArenaDeckSlotType.Normal);
					}
				}
				DeckBuilderDeckSlotsPanel deckSlotsPanel6 = this.DeckSlotsPanel;
				if (deckSlotsPanel6 != null)
				{
					deckSlotsPanel6.RefreshCardSlotElements();
				}
				this.RefreshAllCardAvailable();
				this.RefreshElementTab();
				this.RefreshFullTip();
				return;
			}
			string text = PhantomArenaDefine.addCardFailedResultToTipTextId.ContainsKey(eaddCardResult) ? PhantomArenaDefine.addCardFailedResultToTipTextId[eaddCardResult] : null;
			if (text != null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(text, Array.Empty<object>());
			}
		}

		// Token: 0x0603789E RID: 227486 RVA: 0x00E16FF8 File Offset: 0x00E151F8
		protected void RemoveCardSlotByCardId(int cardId, int removeCount = 1)
		{
			if (this.DeckInfo == null)
			{
				return;
			}
			RemoveCardContext context = new RemoveCardContext
			{
				CardId = cardId,
				RemoveCount = removeCount
			};
			if (this.DeckInfo.RemoveCard(context))
			{
				ControllerBase<PhantomArenaController>.Instance.RequestCheckCardSkillUnlock(this.DeckInfo, new Action<PhantomBattleCheckCardSkillUnlockResponse>(this.RefreshFieldCardEffectUnlock));
				DeckBuilderCardItemData deckBuilderCardItemData = this.LibraryCardDataMap[cardId];
				int cardCount = this.DeckInfo.GetCardCount(cardId);
				deckBuilderCardItemData.LeftCount = deckBuilderCardItemData.MaxCount - cardCount;
				GenericLayout<DeckBuilderCardItem, DeckBuilderCardItemData> cardLayout = this.CardLayout;
				if (cardLayout != null)
				{
					DeckBuilderCardItem layoutItemByKey = cardLayout.GetLayoutItemByKey(deckBuilderCardItemData.CardId);
					if (layoutItemByKey != null)
					{
						layoutItemByKey.RefreshLeftCount();
					}
				}
				if (deckBuilderCardItemData.Cost == ConfigBase<PhantomArenaConfig>.Instance.GetPhantomArenaCardCoreCost())
				{
					DeckBuilderDeckSlotsPanel deckSlotsPanel = this.DeckSlotsPanel;
					if (deckSlotsPanel != null)
					{
						deckSlotsPanel.RefreshCoreCardSlot(null);
					}
				}
				else if (deckBuilderCardItemData.CardType == ECardType.Field)
				{
					DeckBuilderDeckSlotsPanel deckSlotsPanel2 = this.DeckSlotsPanel;
					if (deckSlotsPanel2 != null)
					{
						deckSlotsPanel2.RefreshFieldCardSlot(null);
					}
				}
				else
				{
					DeckBuilderDeckSlotsPanel deckSlotsPanel3 = this.DeckSlotsPanel;
					if (deckSlotsPanel3 != null)
					{
						deckSlotsPanel3.RefreshNormalCardSlot(null, true, 0);
					}
				}
				DeckBuilderDeckSlotsPanel deckSlotsPanel4 = this.DeckSlotsPanel;
				if (deckSlotsPanel4 != null)
				{
					deckSlotsPanel4.RefreshCardSlotElements();
				}
				this.RefreshElementTab();
				this.RefreshAllCardAvailable();
				this.RefreshFullTip();
				return;
			}
			Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.LZK, "移除卡牌异常", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0603789F RID: 227487 RVA: 0x00E17154 File Offset: 0x00E15354
		protected void RemoveCardSlotByElements(HashSet<ECardElement> elements)
		{
			if (this.DeckInfo == null)
			{
				return;
			}
			if (this.DeckInfo.RemoveCardByElements(elements))
			{
				this.RefreshAllCardLeftCount();
				this.RefreshAllCardAvailable();
				DeckBuilderDeckSlotsPanel deckSlotsPanel = this.DeckSlotsPanel;
				if (deckSlotsPanel != null)
				{
					deckSlotsPanel.RefreshCardSlot(null, false);
				}
				DeckBuilderDeckSlotsPanel deckSlotsPanel2 = this.DeckSlotsPanel;
				if (deckSlotsPanel2 != null)
				{
					deckSlotsPanel2.RefreshCardSlotElements();
				}
				this.RefreshElementTab();
				this.RefreshFullTip();
				return;
			}
			Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.LZK, "移除卡牌异常", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x060378A0 RID: 227488 RVA: 0x00E171DC File Offset: 0x00E153DC
		protected void RemoveAllCardSlot()
		{
			if (this.DeckInfo == null)
			{
				return;
			}
			if (this.DeckInfo.RemoveAllCard())
			{
				this.RefreshAllCardLeftCount();
				this.RefreshAllCardAvailable();
				DeckBuilderDeckSlotsPanel deckSlotsPanel = this.DeckSlotsPanel;
				if (deckSlotsPanel != null)
				{
					deckSlotsPanel.RefreshCardSlot(null, false);
				}
				DeckBuilderDeckSlotsPanel deckSlotsPanel2 = this.DeckSlotsPanel;
				if (deckSlotsPanel2 != null)
				{
					deckSlotsPanel2.RefreshCardSlotElements();
				}
				this.RefreshElementTab();
				this.RefreshFullTip();
				return;
			}
			Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.LZK, "移除卡牌异常", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x060378A1 RID: 227489 RVA: 0x00E17263 File Offset: 0x00E15463
		private void OnElementTabSelect(int gridIndex)
		{
			this.SelectElementTabByIndex(gridIndex);
			this.UpdateAllPageCardDataList();
			this.UpdateCurPageCardDataList();
			this.RefreshPageText();
			this.RefreshCardLayout();
			this.RefreshFullTip();
		}

		// Token: 0x060378A2 RID: 227490 RVA: 0x00E1728A File Offset: 0x00E1548A
		private void RefreshFieldCardEffectUnlock(PhantomBattleCheckCardSkillUnlockResponse info)
		{
			DeckBuilderDeckSlotsPanel deckSlotsPanel = this.DeckSlotsPanel;
			if (deckSlotsPanel == null)
			{
				return;
			}
			deckSlotsPanel.RefreshFieldCardEffectUnlock(info);
		}

		// Token: 0x060378A3 RID: 227491 RVA: 0x00E1729D File Offset: 0x00E1549D
		private void SelectElementTabByIndex(int tabIndex)
		{
			this.CurSelectedElementTabIndex = tabIndex;
			LoopScrollView<DeckBuilderElementTabItem, ICardTabItemData> elementTabScrollView = this.ElementTabScrollView;
			if (elementTabScrollView == null)
			{
				return;
			}
			elementTabScrollView.SelectGridProxy(tabIndex, false);
		}

		// Token: 0x060378A4 RID: 227492 RVA: 0x00E172B8 File Offset: 0x00E154B8
		private DeckBuilderElementTabItem CreateElementTabItem()
		{
			return new DeckBuilderElementTabItem
			{
				OnToggleSelect = new Action<int>(this.OnElementTabSelect)
			};
		}

		// Token: 0x060378A5 RID: 227493 RVA: 0x00E172D1 File Offset: 0x00E154D1
		private DeckBuilderCardItem CreateCardItem()
		{
			return new DeckBuilderCardItem
			{
				IsNewPhantomArenaActivity = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(base.ActivityId)
			};
		}

		// Token: 0x060378A6 RID: 227494 RVA: 0x00E172F0 File Offset: 0x00E154F0
		private void OnNormalSlotItemClick(DeckBuilderCardSlotItem item)
		{
			DeckCardSlotInfo data = item.GetData();
			if (data == null)
			{
				return;
			}
			this.RemoveCardSlotByCardId(data.CardId, 1);
		}

		// Token: 0x060378A7 RID: 227495 RVA: 0x00E17318 File Offset: 0x00E15518
		private void OnFieldCardItemEffectBtnClick(DeckBuilderCardSlotItem item)
		{
			DeckCardSlotInfo data = item.GetData();
			if (data == null)
			{
				return;
			}
			ControllerBase<PhantomArenaController>.Instance.OpenDeckBuilderCardInfoViewWithoutOutlookTab(data.CardId);
		}

		// Token: 0x060378A8 RID: 227496 RVA: 0x00E17340 File Offset: 0x00E15540
		private bool CanNormalSlotItemToggleChange(DeckBuilderCardSlotItem item)
		{
			return false;
		}

		// Token: 0x060378A9 RID: 227497 RVA: 0x00E17343 File Offset: 0x00E15543
		private bool CanFieldSlotItemToggleChange(DeckBuilderCardSlotItem item)
		{
			return false;
		}

		// Token: 0x060378AA RID: 227498 RVA: 0x00E17348 File Offset: 0x00E15548
		private void OnCoreSlotItemClick(DeckBuilderCardSlotItem item)
		{
			DeckCardSlotInfo data = item.GetData();
			if (data == null)
			{
				return;
			}
			this.RemoveCardSlotByCardId(data.CardId, 1);
		}

		// Token: 0x060378AB RID: 227499 RVA: 0x00E17370 File Offset: 0x00E15570
		private void OnSlotItemLongPressComplete(DeckBuilderCardSlotItem item)
		{
			DeckCardSlotInfo data = item.GetData();
			if (data == null)
			{
				return;
			}
			DeckBuilderCardInfoViewData param = new DeckBuilderCardInfoViewData
			{
				CurCardId = data.CardId,
				DeckInfo = this.DeckInfo,
				AddCardToDeck = new Action<int, int>(this.AddCardToDeck),
				RemoveCardFromDeck = new Action<int, int>(this.RemoveCardSlotByCardId),
				CurrencyId = new int?(ModelBase<PhantomArenaModel>.Instance.GetDustItemId(base.ActivityId)),
				NeedOutlookTab = false
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DeckBuilderCardInfoView, param, null);
		}

		// Token: 0x060378AC RID: 227500 RVA: 0x00E17400 File Offset: 0x00E15600
		private void OnSlotItemLongPress(DeckBuilderCardSlotItem item, float progress)
		{
			if (progress == -1f)
			{
				this.OnSlotItemLongPressComplete(item);
				return;
			}
			UUIItem item2 = base.GetItem(16);
			if (item2 != null && !item2.bIsUIActive)
			{
				this.RefreshLongPressItemPosition();
				item2.SetUIActive(true);
			}
			UUISprite sprite = base.GetSprite(17);
			if (sprite != null)
			{
				sprite.SetFillAmount(progress);
			}
			if (progress >= 1f)
			{
				this.OnSlotItemLongPressComplete(item);
			}
		}

		// Token: 0x060378AD RID: 227501 RVA: 0x00E17464 File Offset: 0x00E15664
		private void RefreshLongPressItemPosition()
		{
			FVector? pointerEventDataPosition = Singleton<LguiEventSystemManager>.Instance.GetPointerEventDataPosition(0);
			Vector2D vector2D = Vector2D.Create((double)pointerEventDataPosition.Value.X, (double)pointerEventDataPosition.Value.Y);
			Vector2D vector2D2 = vector2D;
			ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
			FVector2D fvector2D = vector2D.ToUeVector2D(false);
			vector2D2.FromUeVector2D(canvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D));
			float cardSlotItemLongPressOffsetX = ConfigBase<PhantomArenaConfig>.Instance.GetCardSlotItemLongPressOffsetX();
			float cardSlotItemLongPressOffsetY = ConfigBase<PhantomArenaConfig>.Instance.GetCardSlotItemLongPressOffsetY();
			float inX = (float)vector2D.X + cardSlotItemLongPressOffsetX;
			float inY = (float)vector2D.Y + cardSlotItemLongPressOffsetY;
			UUIItem item = base.GetItem(16);
			if (item == null)
			{
				return;
			}
			FVector fvector = new FVector(inX, inY, 0f);
			item.SetLGUISpaceAbsolutePosition(fvector);
		}

		// Token: 0x060378AE RID: 227502 RVA: 0x00E17517 File Offset: 0x00E15717
		private void OnSlotItemLongPressEnd()
		{
			UUIItem item = base.GetItem(16);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x060378AF RID: 227503 RVA: 0x00E1752C File Offset: 0x00E1572C
		private bool CanCoreSlotItemToggleChange(DeckBuilderCardSlotItem item)
		{
			return false;
		}

		// Token: 0x060378B0 RID: 227504 RVA: 0x00E17530 File Offset: 0x00E15730
		private void OnPrePageBtnClick()
		{
			if (this.MaxPage == 0)
			{
				return;
			}
			if (this.CurPage == this.MinPage)
			{
				this.CurPage = this.MaxPage;
			}
			else
			{
				this.CurPage--;
			}
			this.UpdateCurPageCardDataList();
			this.RefreshPageText();
			this.RefreshCardLayout();
		}

		// Token: 0x060378B1 RID: 227505 RVA: 0x00E17584 File Offset: 0x00E15784
		private void OnNextPageBtnClick()
		{
			if (this.MaxPage == 0)
			{
				return;
			}
			if (this.CurPage == this.MaxPage)
			{
				this.CurPage = this.MinPage;
			}
			else
			{
				this.CurPage++;
			}
			this.UpdateCurPageCardDataList();
			this.RefreshPageText();
			this.RefreshCardLayout();
		}

		// Token: 0x060378B2 RID: 227506 RVA: 0x00E175D8 File Offset: 0x00E157D8
		private void OnDeckDeleteBtnClick()
		{
			if (this.DeckInfo == null || this.DeckInfo.GetTotalCardCount() == 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_Delect_Empty", Array.Empty<object>());
				return;
			}
			HashSet<ECardElement> enabledElementSet = new HashSet<ECardElement>(this.DeckInfo.GetElementSetWithPhysical());
			DeckBuilderCardDeleteViewData param = new DeckBuilderCardDeleteViewData
			{
				EnabledElementSet = enabledElementSet,
				DeleteFunc = new Action<HashSet<ECardElement>>(this.RemoveCardSlotByElements)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DeckBuilderCardDeleteView, param, null);
		}

		// Token: 0x060378B3 RID: 227507 RVA: 0x00E17650 File Offset: 0x00E15850
		private void OnShowLockedToggleChange(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.IncludeLockedCard = true;
			}
			else
			{
				this.IncludeLockedCard = false;
			}
			this.UpdateAllPageCardDataList();
			this.UpdateCurPageCardDataList();
			this.RefreshPageText();
			this.RefreshCardLayout();
		}

		// Token: 0x060378B4 RID: 227508 RVA: 0x00E1767E File Offset: 0x00E1587E
		private void OnCostFilterResult(int configId, bool _)
		{
			this.CurCostFilter = configId;
			this.UpdateAllPageCardDataList();
			this.UpdateCurPageCardDataList();
			this.RefreshPageText();
			this.RefreshCardLayout();
		}

		// Token: 0x060378B5 RID: 227509 RVA: 0x00E176A0 File Offset: 0x00E158A0
		private void RefreshCardFilterEntrance()
		{
			IReadOnlyList<PhantomBattleCardFilter> allPhantomBattleCardFilter = ConfigBase<PhantomArenaConfig>.Instance.GetAllPhantomBattleCardFilter();
			List<IDeckBuilderSortFilterItemData> list = new List<IDeckBuilderSortFilterItemData>();
			foreach (PhantomBattleCardFilter phantomBattleCardFilter in allPhantomBattleCardFilter)
			{
				DeckBuilderSortFilterItemData item = new DeckBuilderSortFilterItemData
				{
					ConfigId = phantomBattleCardFilter.Id,
					Name = phantomBattleCardFilter.Name
				};
				list.Add(item);
			}
			DeckBuilderSortFilterEntrance cardFilterEntrance = this.CardFilterEntrance;
			if (cardFilterEntrance != null)
			{
				cardFilterEntrance.UpdateDataList(list.ToArray());
			}
			int gridIndex = allPhantomBattleCardFilter.IndexOf((PhantomBattleCardFilter config) => config.Id == this.CurCostFilter);
			DeckBuilderSortFilterEntrance cardFilterEntrance2 = this.CardFilterEntrance;
			if (cardFilterEntrance2 == null)
			{
				return;
			}
			cardFilterEntrance2.SelectItemByIndex(gridIndex, false);
		}

		// Token: 0x060378B6 RID: 227510 RVA: 0x00E17758 File Offset: 0x00E15958
		private void OnPhantomArenaCardUnlock(int cardId)
		{
			DeckBuilderCardItemData deckBuilderCardItemData;
			if (this.LibraryCardDataMap.TryGetValue(cardId, out deckBuilderCardItemData))
			{
				deckBuilderCardItemData.IsLocked = false;
				this.UpdateStateContextInCardData(deckBuilderCardItemData);
				GenericLayout<DeckBuilderCardItem, DeckBuilderCardItemData> cardLayout = this.CardLayout;
				if (cardLayout == null)
				{
					return;
				}
				DeckBuilderCardItem layoutItemByKey = cardLayout.GetLayoutItemByKey(cardId);
				if (layoutItemByKey == null)
				{
					return;
				}
				layoutItemByKey.Refresh(deckBuilderCardItemData);
			}
		}

		// Token: 0x060378B7 RID: 227511 RVA: 0x00E177A4 File Offset: 0x00E159A4
		private void OnPhantomArenaCardOutlookUnlock(int cardId)
		{
			DeckBuilderCardItemData deckBuilderCardItemData;
			if (this.LibraryCardDataMap.TryGetValue(cardId, out deckBuilderCardItemData))
			{
				deckBuilderCardItemData.OutlookUnlocked = true;
				this.UpdateStateContextInCardData(deckBuilderCardItemData);
				GenericLayout<DeckBuilderCardItem, DeckBuilderCardItemData> cardLayout = this.CardLayout;
				if (cardLayout != null)
				{
					DeckBuilderCardItem layoutItemByKey = cardLayout.GetLayoutItemByKey(cardId);
					if (layoutItemByKey != null)
					{
						layoutItemByKey.Refresh(deckBuilderCardItemData);
					}
				}
				DeckBuilderDeckSlotsPanel deckSlotsPanel = this.DeckSlotsPanel;
				if (deckSlotsPanel == null)
				{
					return;
				}
				deckSlotsPanel.RefreshOutlookByCardId(cardId);
			}
		}

		// Token: 0x060378B8 RID: 227512 RVA: 0x00E17803 File Offset: 0x00E15A03
		private void OnGamepadTriggerCardInfo(UUIItem uiItem)
		{
			DeckBuilderDeckSlotsPanel deckSlotsPanel = this.DeckSlotsPanel;
			if (deckSlotsPanel == null)
			{
				return;
			}
			deckSlotsPanel.GamepadTriggerDeckBuilderCardInfoView(uiItem);
		}

		// Token: 0x060378B9 RID: 227513 RVA: 0x00E17816 File Offset: 0x00E15A16
		private void OnSaveBtnClick()
		{
			if (this.DeckInfo == null)
			{
				return;
			}
			this.SaveDeckInternal();
		}

		// Token: 0x060378BA RID: 227514 RVA: 0x00E17828 File Offset: 0x00E15A28
		private void SaveDeckInternal()
		{
			if (this.DeckInfo == null)
			{
				return;
			}
			if (this.DeckInfo.GetDeckServerId() < 0)
			{
				ControllerBase<PhantomArenaController>.Instance.CardGroupAddRequest(this.DeckInfo.GetName(), this.DeckInfo.CoverToCardIdList().ToArray(), base.ActivityId, delegate(int _)
				{
					IPhantomArenaDeckBuilderTabViewModel viewModel = this.ViewModel;
					if (viewModel != null)
					{
						viewModel.UpdateEditableDeckList();
					}
					if (this.DeckInfo != null)
					{
						IPhantomArenaDeckBuilderTabViewModel viewModel2 = this.ViewModel;
						if (viewModel2 != null)
						{
							viewModel2.ReportDeckCreate(this.DeckInfo);
						}
					}
					base.CloseMe();
				});
				return;
			}
			int deckServerId = this.DeckInfo.GetDeckServerId();
			List<int> list = this.DeckInfo.CoverToCardIdList();
			ControllerBase<PhantomArenaController>.Instance.CardGroupUpdateRequest(deckServerId, list.ToArray(), base.ActivityId, delegate(int _)
			{
				IPhantomArenaDeckBuilderTabViewModel viewModel = this.ViewModel;
				if (viewModel != null)
				{
					viewModel.UpdateEditableDeckList();
				}
				if (this.DeckInfo != null)
				{
					IPhantomArenaDeckBuilderTabViewModel viewModel2 = this.ViewModel;
					if (viewModel2 != null)
					{
						viewModel2.ReportDeckCover(this.DeckInfo);
					}
				}
				base.CloseMe();
			});
		}

		// Token: 0x060378BB RID: 227515 RVA: 0x00E178C0 File Offset: 0x00E15AC0
		private void OnCloseBtnClick()
		{
			if (this.ViewModel == null)
			{
				return;
			}
			IPhantomArenaDeckBuilderTabViewModel viewModel = this.ViewModel;
			if (((viewModel != null) ? new bool?(viewModel.CheckCurEditDeckHasChange()) : null).GetValueOrDefault())
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomArenaExitDeckBuilderViewConfirm);
				confirmBoxDataNew.FunctionMap[1] = new Action(base.CloseMe);
				confirmBoxDataNew.FunctionMap[2] = new Action(this.OnSaveBtnClick);
				confirmBoxDataNew.IsEscViewTriggerCallBack = false;
				bool isNew = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(base.ActivityId);
				ControllerBase<PhantomArenaController>.Instance.OpenPhantomArenaConfirmBoxView(confirmBoxDataNew, isNew);
				return;
			}
			base.CloseMe();
		}

		// Token: 0x060378BC RID: 227516 RVA: 0x00E17965 File Offset: 0x00E15B65
		private void SetMainViewOverrideCloseFunc()
		{
			if (this.ViewModel != null)
			{
				this.ViewModel.SetOverrideCloseFunc(new Action(this.OnCloseBtnClick));
			}
		}

		// Token: 0x060378BD RID: 227517 RVA: 0x00E17986 File Offset: 0x00E15B86
		private void ResetMainViewOverrideCloseFunc()
		{
			if (this.ViewModel != null)
			{
				this.ViewModel.ResetOverrideCloseFunc();
			}
		}

		// Token: 0x060378BE RID: 227518 RVA: 0x00E1799C File Offset: 0x00E15B9C
		private void OnChangeNameBtnClick()
		{
			string text = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("PhantomBattle_1077", null), Array.Empty<string>());
			CommonInputViewController instance = ControllerBase<CommonInputViewController>.Instance;
			string bottomText = text;
			Func<string, UniTask<Aki.Protocol.ErrorCode>> callBack = new Func<string, UniTask<Aki.Protocol.ErrorCode>>(this.<OnChangeNameBtnClick>g__inputCallBack|82_0);
			DeckInfo deckInfo = this.DeckInfo;
			instance.OpenSetPhantomArenaDeckName(bottomText, callBack, ((deckInfo != null) ? deckInfo.GetName() : null) ?? "");
		}

		// Token: 0x060378BF RID: 227519 RVA: 0x00E179F1 File Offset: 0x00E15BF1
		private void OnSlotCardPointEnterCallback(int cardId)
		{
			if (this.CardDetailTip == null)
			{
				return;
			}
			this.CardDetailTip.IsMouseInSlotItem = true;
			this.CardDetailTip.RefreshCard(cardId, this.DeckInfo);
			this.CardDetailTip.SetUiActive(true);
		}

		// Token: 0x060378C0 RID: 227520 RVA: 0x00E17A26 File Offset: 0x00E15C26
		private void OnSlotCardPointExitCallback()
		{
			if (this.CardDetailTip == null)
			{
				return;
			}
			this.CardDetailTip.IsMouseInSlotItem = false;
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				if (this.CardDetailTip == null)
				{
					return;
				}
				this.CardDetailTip.AddTimer();
			}, 500f, null, null, true, 1f);
		}

		// Token: 0x060378C1 RID: 227521 RVA: 0x00E17A64 File Offset: 0x00E15C64
		private void OnQuicklyBuildBtnClick()
		{
			DeckBuilderQuicklyBuildViewData param = new DeckBuilderQuicklyBuildViewData
			{
				ActivityId = base.ActivityId,
				ConfirmCallback = delegate(DeckInfo deckInfo)
				{
					bool flag = false;
					foreach (DeckCardSlotInfo deckCardSlotInfo in deckInfo.GetCardSlotList())
					{
						if (!ModelBase<PhantomArenaModel>.Instance.IsCardUnlock(deckCardSlotInfo.CardId))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_1080", Array.Empty<object>());
					}
					this.ReplaceDeck(deckInfo);
					IPhantomArenaDeckBuilderTabViewModel viewModel = this.ViewModel;
					if (viewModel == null)
					{
						return;
					}
					viewModel.RecordQuicklyBuildClick(deckInfo.GetDeckConfigId());
				}
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DeckBuilderQuicklyBuildView, param, null);
		}

		// Token: 0x060378C2 RID: 227522 RVA: 0x00E17AA8 File Offset: 0x00E15CA8
		private void ReplaceDeck(DeckInfo newDeckInfo)
		{
			DeckInfo deckInfo = this.DeckInfo;
			if (deckInfo != null)
			{
				deckInfo.RemoveAllCard();
			}
			foreach (DeckCardSlotInfo deckCardSlotInfo in newDeckInfo.GetCardSlotList())
			{
				if (ModelBase<PhantomArenaModel>.Instance.IsCardUnlock(deckCardSlotInfo.CardId))
				{
					AddCardContext context = new AddCardContext
					{
						CardId = deckCardSlotInfo.CardId,
						Cost = deckCardSlotInfo.Cost,
						Element = deckCardSlotInfo.Element,
						MaxCount = deckCardSlotInfo.Count,
						AddCount = deckCardSlotInfo.Count,
						CardType = deckCardSlotInfo.CardType
					};
					DeckInfo deckInfo2 = this.DeckInfo;
					if (deckInfo2 != null)
					{
						deckInfo2.AddCard(context);
					}
				}
			}
			if (this.DeckInfo != null)
			{
				ControllerBase<PhantomArenaController>.Instance.RequestCheckCardSkillUnlock(this.DeckInfo, new Action<PhantomBattleCheckCardSkillUnlockResponse>(this.RefreshFieldCardEffectUnlock));
			}
			this.RefreshAllCardLeftCount();
			this.RefreshAllCardAvailable();
			this.RefreshDeckSlotsPanel(false);
			this.RefreshElementTab();
			this.RefreshFullTip();
		}

		// Token: 0x060378C3 RID: 227523 RVA: 0x00E17BC0 File Offset: 0x00E15DC0
		protected override void OnBeforeDestroy()
		{
			IPhantomArenaDeckBuilderTabViewModel viewModel = this.ViewModel;
			if (viewModel == null)
			{
				return;
			}
			viewModel.EndEditDeck();
		}

		// Token: 0x060378C4 RID: 227524 RVA: 0x00E17BD4 File Offset: 0x00E15DD4
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "Card")
			{
				int index = int.Parse(configParams[1]);
				GenericLayout<DeckBuilderCardItem, DeckBuilderCardItemData> cardLayout = this.CardLayout;
				UUIItem uuiitem;
				if (cardLayout == null)
				{
					uuiitem = null;
				}
				else
				{
					DeckBuilderCardItem layoutItemByIndex = cardLayout.GetLayoutItemByIndex(index);
					uuiitem = ((layoutItemByIndex != null) ? layoutItemByIndex.GetRootItem() : null);
				}
				UUIItem uuiitem2 = uuiitem;
				if (uuiitem2 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem2,
					uuiitem2
				};
			}
			else if (a == "CardDetail" || a == "New:CardDetail")
			{
				int index2 = int.Parse(configParams[1]);
				GenericLayout<DeckBuilderCardItem, DeckBuilderCardItemData> cardLayout2 = this.CardLayout;
				if (cardLayout2 == null)
				{
					return null;
				}
				DeckBuilderCardItem layoutItemByIndex2 = cardLayout2.GetLayoutItemByIndex(index2);
				if (layoutItemByIndex2 == null)
				{
					return null;
				}
				return layoutItemByIndex2.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			else
			{
				if (!(a == "CardInGroup"))
				{
					return null;
				}
				DeckBuilderDeckSlotsPanel deckSlotsPanel = this.DeckSlotsPanel;
				if (deckSlotsPanel == null)
				{
					return null;
				}
				return deckSlotsPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
		}

		// Token: 0x060378C9 RID: 227529 RVA: 0x00E17D94 File Offset: 0x00E15F94
		[NullableContext(0)]
		[CompilerGenerated]
		private UniTask<Aki.Protocol.ErrorCode> <OnChangeNameBtnClick>g__inputCallBack|82_0([Nullable(1)] string input)
		{
			PhantomArenaNewDeckBuilderTabView.<<OnChangeNameBtnClick>g__inputCallBack|82_0>d <<OnChangeNameBtnClick>g__inputCallBack|82_0>d;
			<<OnChangeNameBtnClick>g__inputCallBack|82_0>d.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
			<<OnChangeNameBtnClick>g__inputCallBack|82_0>d.<>4__this = this;
			<<OnChangeNameBtnClick>g__inputCallBack|82_0>d.input = input;
			<<OnChangeNameBtnClick>g__inputCallBack|82_0>d.<>1__state = -1;
			<<OnChangeNameBtnClick>g__inputCallBack|82_0>d.<>t__builder.Start<PhantomArenaNewDeckBuilderTabView.<<OnChangeNameBtnClick>g__inputCallBack|82_0>d>(ref <<OnChangeNameBtnClick>g__inputCallBack|82_0>d);
			return <<OnChangeNameBtnClick>g__inputCallBack|82_0>d.<>t__builder.Task;
		}

		// Token: 0x0401FDA2 RID: 130466
		protected Dictionary<int, DeckBuilderCardItemData> LibraryCardDataMap = new Dictionary<int, DeckBuilderCardItemData>();

		// Token: 0x0401FDA3 RID: 130467
		protected List<DeckBuilderCardItemData> LibraryCardDataList = new List<DeckBuilderCardItemData>();

		// Token: 0x0401FDA4 RID: 130468
		protected List<DeckBuilderCardItemData> AllPageCardDataList = new List<DeckBuilderCardItemData>();

		// Token: 0x0401FDA5 RID: 130469
		protected List<DeckBuilderCardItemData> CurPageCardDataList = new List<DeckBuilderCardItemData>();

		// Token: 0x0401FDA6 RID: 130470
		protected int CurSelectedCardIndex = -1;

		// Token: 0x0401FDA7 RID: 130471
		protected int CurPage;

		// Token: 0x0401FDA8 RID: 130472
		protected int MinPage;

		// Token: 0x0401FDA9 RID: 130473
		protected int MaxPage;

		// Token: 0x0401FDAA RID: 130474
		protected readonly int MaxCardCountPerPage = 8;

		// Token: 0x0401FDAB RID: 130475
		protected List<ICardTabItemData> TabDataList = new List<ICardTabItemData>();

		// Token: 0x0401FDAC RID: 130476
		protected int CurSelectedElementTabIndex = -1;

		// Token: 0x0401FDAD RID: 130477
		protected int CurCostFilter = 1;

		// Token: 0x0401FDAE RID: 130478
		protected bool IncludeLockedCard;

		// Token: 0x0401FDAF RID: 130479
		protected int CurSlotSortType = 1;

		// Token: 0x0401FDB0 RID: 130480
		protected bool IsAscending = true;

		// Token: 0x0401FDB1 RID: 130481
		protected DeckInfo DeckInfo;

		// Token: 0x0401FDB2 RID: 130482
		private LoopScrollView<DeckBuilderElementTabItem, ICardTabItemData> ElementTabScrollView;

		// Token: 0x0401FDB3 RID: 130483
		protected GenericLayout<DeckBuilderCardItem, DeckBuilderCardItemData> CardLayout;

		// Token: 0x0401FDB4 RID: 130484
		protected PhantomArenaMainViewSwitchItem ShowLockedSwitchItem;

		// Token: 0x0401FDB5 RID: 130485
		protected DeckBuilderSortFilterEntrance CardFilterEntrance;

		// Token: 0x0401FDB6 RID: 130486
		protected DeckBuilderDeckSlotsPanel DeckSlotsPanel;

		// Token: 0x0401FDB7 RID: 130487
		private DeckBuilderCardDetailTip CardDetailTip;

		// Token: 0x0200B494 RID: 46228
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x04037E68 RID: 228968
			public const int ElementTabLoopScrollView = 0;

			// Token: 0x04037E69 RID: 228969
			public const int ElementTabItem = 1;

			// Token: 0x04037E6A RID: 228970
			public const int CardLayout = 2;

			// Token: 0x04037E6B RID: 228971
			public const int CardItem = 3;

			// Token: 0x04037E6C RID: 228972
			public const int FilterItem = 4;

			// Token: 0x04037E6D RID: 228973
			public const int CardEmptyItem = 5;

			// Token: 0x04037E6E RID: 228974
			public const int PageText = 6;

			// Token: 0x04037E6F RID: 228975
			public const int PrePageBtn = 7;

			// Token: 0x04037E70 RID: 228976
			public const int NextPageBtn = 8;

			// Token: 0x04037E71 RID: 228977
			public const int QuicklyBuildBtn = 9;

			// Token: 0x04037E72 RID: 228978
			public const int SaveBtn = 10;

			// Token: 0x04037E73 RID: 228979
			public const int DeckSlotsPanelItem = 11;

			// Token: 0x04037E74 RID: 228980
			public const int RenameBtn = 12;

			// Token: 0x04037E75 RID: 228981
			public const int DeleteBtn = 13;

			// Token: 0x04037E76 RID: 228982
			public const int TextFullTip = 14;

			// Token: 0x04037E77 RID: 228983
			public const int ItemFullTip = 15;

			// Token: 0x04037E78 RID: 228984
			public const int LongPressItem = 16;

			// Token: 0x04037E79 RID: 228985
			public const int SpriteLongPressBar = 17;

			// Token: 0x04037E7A RID: 228986
			public const int ItemDetailTipPanel = 18;
		}
	}
}
