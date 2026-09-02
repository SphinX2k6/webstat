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
	// Token: 0x0200550C RID: 21772
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaDeckBuilderTabView : PhantomArenaChildViewBase
	{
		// Token: 0x17008F21 RID: 36641
		// (get) Token: 0x06037820 RID: 227360 RVA: 0x00E13062 File Offset: 0x00E11262
		// (set) Token: 0x06037821 RID: 227361 RVA: 0x00E1306F File Offset: 0x00E1126F
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

		// Token: 0x06037822 RID: 227362 RVA: 0x00E13078 File Offset: 0x00E11278
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
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(15, typeof(UUIText)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUISprite)),
				new ValueTuple<int, Type>(19, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnPrePageBtnClick)),
				new ValueTuple<int, Delegate>(8, new Action(this.OnNextPageBtnClick)),
				new ValueTuple<int, Delegate>(10, new Action(this.OnQuicklyBuildBtnClick)),
				new ValueTuple<int, Delegate>(11, new Action(this.OnSaveBtnClick)),
				new ValueTuple<int, Delegate>(13, new Action(this.OnChangeNameBtnClick)),
				new ValueTuple<int, Delegate>(14, new Action(this.OnDeckDeleteBtnClick))
			};
		}

		// Token: 0x06037823 RID: 227363 RVA: 0x00E132F4 File Offset: 0x00E114F4
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaDeckBuilderTabView.<OnBeforeStartAsync>d__28 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaDeckBuilderTabView.<OnBeforeStartAsync>d__28>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037824 RID: 227364 RVA: 0x00E13338 File Offset: 0x00E11538
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnPhantomArenaCardUnlock));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaCardOutlookUnlock, new Action<int>(this.OnPhantomArenaCardOutlookUnlock));
			Singleton<EventSystem>.Instance.Add(EEventName.GamepadTriggerCardInfo, new Action<UUIItem>(this.OnGamepadTriggerCardInfo));
		}

		// Token: 0x06037825 RID: 227365 RVA: 0x00E1339C File Offset: 0x00E1159C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnPhantomArenaCardUnlock));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardOutlookUnlock, new Action<int>(this.OnPhantomArenaCardOutlookUnlock));
			Singleton<EventSystem>.Instance.Remove(EEventName.GamepadTriggerCardInfo, new Action<UUIItem>(this.OnGamepadTriggerCardInfo));
		}

		// Token: 0x06037826 RID: 227366 RVA: 0x00E13400 File Offset: 0x00E11600
		protected override UniTask OnBeforeShowAsyncImplement()
		{
			PhantomArenaDeckBuilderTabView.<OnBeforeShowAsyncImplement>d__31 <OnBeforeShowAsyncImplement>d__;
			<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<PhantomArenaDeckBuilderTabView.<OnBeforeShowAsyncImplement>d__31>(ref <OnBeforeShowAsyncImplement>d__);
			return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06037827 RID: 227367 RVA: 0x00E13444 File Offset: 0x00E11644
		protected override UniTask OnPlayingShowSequenceAsync()
		{
			PhantomArenaDeckBuilderTabView.<OnPlayingShowSequenceAsync>d__32 <OnPlayingShowSequenceAsync>d__;
			<OnPlayingShowSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingShowSequenceAsync>d__.<>4__this = this;
			<OnPlayingShowSequenceAsync>d__.<>1__state = -1;
			<OnPlayingShowSequenceAsync>d__.<>t__builder.Start<PhantomArenaDeckBuilderTabView.<OnPlayingShowSequenceAsync>d__32>(ref <OnPlayingShowSequenceAsync>d__);
			return <OnPlayingShowSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037828 RID: 227368 RVA: 0x00E13488 File Offset: 0x00E11688
		protected override UniTask OnPlayingStartSequenceAsync()
		{
			PhantomArenaDeckBuilderTabView.<OnPlayingStartSequenceAsync>d__33 <OnPlayingStartSequenceAsync>d__;
			<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingStartSequenceAsync>d__.<>4__this = this;
			<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
			<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<PhantomArenaDeckBuilderTabView.<OnPlayingStartSequenceAsync>d__33>(ref <OnPlayingStartSequenceAsync>d__);
			return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037829 RID: 227369 RVA: 0x00E134CB File Offset: 0x00E116CB
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

		// Token: 0x0603782A RID: 227370 RVA: 0x00E134F8 File Offset: 0x00E116F8
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

		// Token: 0x0603782B RID: 227371 RVA: 0x00E1358C File Offset: 0x00E1178C
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

		// Token: 0x0603782C RID: 227372 RVA: 0x00E13648 File Offset: 0x00E11848
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
						Attack = (dictionary.ContainsKey(0) ? dictionary[0] : 0),
						Life = (dictionary.ContainsKey(1) ? dictionary[1] : 0),
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

		// Token: 0x0603782D RID: 227373 RVA: 0x00E13854 File Offset: 0x00E11A54
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

		// Token: 0x0603782E RID: 227374 RVA: 0x00E138F4 File Offset: 0x00E11AF4
		private void UpdateCurPageCardDataList()
		{
			int num = (this.CurPage - 1) * this.MaxCardCountPerPage;
			int num2 = this.CurPage * this.MaxCardCountPerPage;
			this.CurPageCardDataList = this.AllPageCardDataList.Skip(num).Take(num2 - num).ToList<DeckBuilderCardItemData>();
		}

		// Token: 0x0603782F RID: 227375 RVA: 0x00E13940 File Offset: 0x00E11B40
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

		// Token: 0x06037830 RID: 227376 RVA: 0x00E13998 File Offset: 0x00E11B98
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

		// Token: 0x06037831 RID: 227377 RVA: 0x00E139E0 File Offset: 0x00E11BE0
		private UniTask RefreshCardLayoutAsync(bool playGridAnim)
		{
			PhantomArenaDeckBuilderTabView.<RefreshCardLayoutAsync>d__42 <RefreshCardLayoutAsync>d__;
			<RefreshCardLayoutAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCardLayoutAsync>d__.<>4__this = this;
			<RefreshCardLayoutAsync>d__.playGridAnim = playGridAnim;
			<RefreshCardLayoutAsync>d__.<>1__state = -1;
			<RefreshCardLayoutAsync>d__.<>t__builder.Start<PhantomArenaDeckBuilderTabView.<RefreshCardLayoutAsync>d__42>(ref <RefreshCardLayoutAsync>d__);
			return <RefreshCardLayoutAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037832 RID: 227378 RVA: 0x00E13A2C File Offset: 0x00E11C2C
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

		// Token: 0x06037833 RID: 227379 RVA: 0x00E13AC0 File Offset: 0x00E11CC0
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

		// Token: 0x06037834 RID: 227380 RVA: 0x00E13B3C File Offset: 0x00E11D3C
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

		// Token: 0x06037835 RID: 227381 RVA: 0x00E13BBC File Offset: 0x00E11DBC
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
				IsNeedFieldCard = false,
				IsNeedRequestCheckCardSkillUnlock = needRequestCheckCardSkillUnlock
			};
			DeckBuilderDeckSlotsPanel deckSlotsPanel = this.DeckSlotsPanel;
			if (deckSlotsPanel == null)
			{
				return;
			}
			deckSlotsPanel.RefreshByData(data);
		}

		// Token: 0x06037836 RID: 227382 RVA: 0x00E13D18 File Offset: 0x00E11F18
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

		// Token: 0x06037837 RID: 227383 RVA: 0x00E13DF8 File Offset: 0x00E11FF8
		public void RefreshFullTip()
		{
			ECardTabType tabType = this.TabDataList[this.CurSelectedElementTabIndex].TabType;
			ECardElement? ecardElement = PhantomArenaDefine.cardTabTypeToElementConfigId.ContainsKey(tabType) ? new ECardElement?(PhantomArenaDefine.cardTabTypeToElementConfigId[tabType]) : null;
			bool flag = this.DeckInfo.IsDeckFull();
			bool flag2 = ecardElement != null && !this.DeckInfo.CheckCanAddElement(ecardElement.Value);
			UUIItem item = base.GetItem(16);
			if (item != null)
			{
				item.SetUIActive(flag || flag2);
			}
			string textStringId = flag2 ? "PrefabTextItem_3954833905_Text" : "PrefabTextItem_3799404500_Text";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), textStringId, Array.Empty<object>());
		}

		// Token: 0x06037838 RID: 227384 RVA: 0x00E13EB4 File Offset: 0x00E120B4
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
				NeedOutlookTab = true
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DeckBuilderCardInfoView, param, null);
		}

		// Token: 0x06037839 RID: 227385 RVA: 0x00E13F84 File Offset: 0x00E12184
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
				else
				{
					DeckBuilderDeckSlotsPanel deckSlotsPanel3 = this.DeckSlotsPanel;
					if (deckSlotsPanel3 != null)
					{
						deckSlotsPanel3.RefreshNormalCardSlot(needPlayAddAnimCard, true, deckBuilderCardItemData.CardId);
					}
					DeckBuilderDeckSlotsPanel deckSlotsPanel4 = this.DeckSlotsPanel;
					if (deckSlotsPanel4 != null)
					{
						deckSlotsPanel4.SwitchMaskState(EPhantomArenaDeckSlotType.Normal);
					}
				}
				DeckBuilderDeckSlotsPanel deckSlotsPanel5 = this.DeckSlotsPanel;
				if (deckSlotsPanel5 != null)
				{
					deckSlotsPanel5.RefreshCardSlotElements();
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

		// Token: 0x0603783A RID: 227386 RVA: 0x00E141A8 File Offset: 0x00E123A8
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

		// Token: 0x0603783B RID: 227387 RVA: 0x00E14304 File Offset: 0x00E12504
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

		// Token: 0x0603783C RID: 227388 RVA: 0x00E1438C File Offset: 0x00E1258C
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

		// Token: 0x0603783D RID: 227389 RVA: 0x00E14413 File Offset: 0x00E12613
		private void OnElementTabSelect(int gridIndex)
		{
			this.SelectElementTabByIndex(gridIndex);
			this.UpdateAllPageCardDataList();
			this.UpdateCurPageCardDataList();
			this.RefreshPageText();
			this.RefreshCardLayout();
			this.RefreshFullTip();
		}

		// Token: 0x0603783E RID: 227390 RVA: 0x00E1443A File Offset: 0x00E1263A
		private void RefreshFieldCardEffectUnlock(PhantomBattleCheckCardSkillUnlockResponse info)
		{
			DeckBuilderDeckSlotsPanel deckSlotsPanel = this.DeckSlotsPanel;
			if (deckSlotsPanel == null)
			{
				return;
			}
			deckSlotsPanel.RefreshFieldCardEffectUnlock(info);
		}

		// Token: 0x0603783F RID: 227391 RVA: 0x00E1444D File Offset: 0x00E1264D
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

		// Token: 0x06037840 RID: 227392 RVA: 0x00E14468 File Offset: 0x00E12668
		private DeckBuilderElementTabItem CreateElementTabItem()
		{
			return new DeckBuilderElementTabItem
			{
				OnToggleSelect = new Action<int>(this.OnElementTabSelect)
			};
		}

		// Token: 0x06037841 RID: 227393 RVA: 0x00E14481 File Offset: 0x00E12681
		private DeckBuilderCardItem CreateCardItem()
		{
			return new DeckBuilderCardItem
			{
				IsNewPhantomArenaActivity = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(base.ActivityId)
			};
		}

		// Token: 0x06037842 RID: 227394 RVA: 0x00E144A0 File Offset: 0x00E126A0
		private void OnNormalSlotItemClick(DeckBuilderCardSlotItem item)
		{
			DeckCardSlotInfo data = item.GetData();
			if (data == null)
			{
				return;
			}
			this.RemoveCardSlotByCardId(data.CardId, 1);
		}

		// Token: 0x06037843 RID: 227395 RVA: 0x00E144C8 File Offset: 0x00E126C8
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
				NeedOutlookTab = true
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DeckBuilderCardInfoView, param, null);
		}

		// Token: 0x06037844 RID: 227396 RVA: 0x00E14558 File Offset: 0x00E12758
		private void OnSlotItemLongPress(DeckBuilderCardSlotItem item, float progress)
		{
			if (progress == -1f)
			{
				this.OnSlotItemLongPressComplete(item);
				return;
			}
			UUIItem item2 = base.GetItem(17);
			if (item2 != null && !item2.bIsUIActive)
			{
				this.RefreshLongPressItemPosition();
				item2.SetUIActive(true);
			}
			UUISprite sprite = base.GetSprite(18);
			if (sprite != null)
			{
				sprite.SetFillAmount(progress);
			}
			if (progress >= 1f)
			{
				this.OnSlotItemLongPressComplete(item);
			}
		}

		// Token: 0x06037845 RID: 227397 RVA: 0x00E145BC File Offset: 0x00E127BC
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
			UUIItem item = base.GetItem(17);
			if (item == null)
			{
				return;
			}
			FVector fvector = new FVector(inX, inY, 0f);
			item.SetLGUISpaceAbsolutePosition(fvector);
		}

		// Token: 0x06037846 RID: 227398 RVA: 0x00E1466F File Offset: 0x00E1286F
		private void OnSlotItemLongPressEnd()
		{
			UUIItem item = base.GetItem(17);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06037847 RID: 227399 RVA: 0x00E14684 File Offset: 0x00E12884
		private bool CanNormalSlotItemToggleChange(DeckBuilderCardSlotItem item)
		{
			return false;
		}

		// Token: 0x06037848 RID: 227400 RVA: 0x00E14687 File Offset: 0x00E12887
		private bool CanFieldSlotItemToggleChange(DeckBuilderCardSlotItem item)
		{
			return false;
		}

		// Token: 0x06037849 RID: 227401 RVA: 0x00E1468C File Offset: 0x00E1288C
		private void OnCoreSlotItemClick(DeckBuilderCardSlotItem item)
		{
			DeckCardSlotInfo data = item.GetData();
			if (data == null)
			{
				return;
			}
			this.RemoveCardSlotByCardId(data.CardId, 1);
		}

		// Token: 0x0603784A RID: 227402 RVA: 0x00E146B1 File Offset: 0x00E128B1
		private bool CanCoreSlotItemToggleChange(DeckBuilderCardSlotItem item)
		{
			return false;
		}

		// Token: 0x0603784B RID: 227403 RVA: 0x00E146B4 File Offset: 0x00E128B4
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

		// Token: 0x0603784C RID: 227404 RVA: 0x00E14708 File Offset: 0x00E12908
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

		// Token: 0x0603784D RID: 227405 RVA: 0x00E1475C File Offset: 0x00E1295C
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

		// Token: 0x0603784E RID: 227406 RVA: 0x00E147D4 File Offset: 0x00E129D4
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

		// Token: 0x0603784F RID: 227407 RVA: 0x00E14802 File Offset: 0x00E12A02
		private void OnCostFilterResult(int configId, bool _)
		{
			this.CurCostFilter = configId;
			this.UpdateAllPageCardDataList();
			this.UpdateCurPageCardDataList();
			this.RefreshPageText();
			this.RefreshCardLayout();
		}

		// Token: 0x06037850 RID: 227408 RVA: 0x00E14823 File Offset: 0x00E12A23
		private void OnSlotSortResult(int configId, bool isAscending)
		{
			this.CurSlotSortType = configId;
			this.IsAscending = isAscending;
			DeckBuilderDeckSlotsPanel deckSlotsPanel = this.DeckSlotsPanel;
			if (deckSlotsPanel == null)
			{
				return;
			}
			deckSlotsPanel.RefreshBySortContext(new CardSlotSortContext
			{
				SortType = (ECardSlotSortType)configId,
				IsAscending = isAscending
			});
		}

		// Token: 0x06037851 RID: 227409 RVA: 0x00E14858 File Offset: 0x00E12A58
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

		// Token: 0x06037852 RID: 227410 RVA: 0x00E14910 File Offset: 0x00E12B10
		private void RefreshSlotSortEntrance()
		{
			IReadOnlyList<PhantomBattleCardSlotSort> allPhantomBattleCardSlotSort = ConfigBase<PhantomArenaConfig>.Instance.GetAllPhantomBattleCardSlotSort();
			List<IDeckBuilderSortFilterItemData> list = new List<IDeckBuilderSortFilterItemData>();
			foreach (PhantomBattleCardSlotSort phantomBattleCardSlotSort in allPhantomBattleCardSlotSort)
			{
				DeckBuilderSortFilterItemData item = new DeckBuilderSortFilterItemData
				{
					ConfigId = phantomBattleCardSlotSort.Id,
					Name = phantomBattleCardSlotSort.Name
				};
				list.Add(item);
			}
			DeckBuilderSortFilterEntrance slotSortEntrance = this.SlotSortEntrance;
			if (slotSortEntrance != null)
			{
				slotSortEntrance.UpdateDataList(list.ToArray());
			}
			int gridIndex = allPhantomBattleCardSlotSort.IndexOf((PhantomBattleCardSlotSort config) => config.Id == this.CurSlotSortType);
			DeckBuilderSortFilterEntrance slotSortEntrance2 = this.SlotSortEntrance;
			if (slotSortEntrance2 != null)
			{
				slotSortEntrance2.SelectItemByIndex(gridIndex, false);
			}
			DeckBuilderSortFilterEntrance slotSortEntrance3 = this.SlotSortEntrance;
			if (slotSortEntrance3 == null)
			{
				return;
			}
			slotSortEntrance3.ChangeSortAscending(this.IsAscending, true, false);
		}

		// Token: 0x06037853 RID: 227411 RVA: 0x00E149E4 File Offset: 0x00E12BE4
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

		// Token: 0x06037854 RID: 227412 RVA: 0x00E14A30 File Offset: 0x00E12C30
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

		// Token: 0x06037855 RID: 227413 RVA: 0x00E14A8F File Offset: 0x00E12C8F
		private void OnGamepadTriggerCardInfo(UUIItem uiItem)
		{
			DeckBuilderDeckSlotsPanel deckSlotsPanel = this.DeckSlotsPanel;
			if (deckSlotsPanel == null)
			{
				return;
			}
			deckSlotsPanel.GamepadTriggerDeckBuilderCardInfoView(uiItem);
		}

		// Token: 0x06037856 RID: 227414 RVA: 0x00E14AA2 File Offset: 0x00E12CA2
		private void OnSaveBtnClick()
		{
			if (this.DeckInfo == null)
			{
				return;
			}
			this.SaveDeckInternal();
		}

		// Token: 0x06037857 RID: 227415 RVA: 0x00E14AB4 File Offset: 0x00E12CB4
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

		// Token: 0x06037858 RID: 227416 RVA: 0x00E14B4C File Offset: 0x00E12D4C
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

		// Token: 0x06037859 RID: 227417 RVA: 0x00E14BF1 File Offset: 0x00E12DF1
		private void SetMainViewOverrideCloseFunc()
		{
			if (this.ViewModel != null)
			{
				this.ViewModel.SetOverrideCloseFunc(new Action(this.OnCloseBtnClick));
			}
		}

		// Token: 0x0603785A RID: 227418 RVA: 0x00E14C12 File Offset: 0x00E12E12
		private void ResetMainViewOverrideCloseFunc()
		{
			if (this.ViewModel != null)
			{
				this.ViewModel.ResetOverrideCloseFunc();
			}
		}

		// Token: 0x0603785B RID: 227419 RVA: 0x00E14C28 File Offset: 0x00E12E28
		private void OnChangeNameBtnClick()
		{
			string text = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("PhantomBattle_1077", null), Array.Empty<string>());
			CommonInputViewController instance = ControllerBase<CommonInputViewController>.Instance;
			string bottomText = text;
			Func<string, UniTask<Aki.Protocol.ErrorCode>> callBack = new Func<string, UniTask<Aki.Protocol.ErrorCode>>(this.<OnChangeNameBtnClick>g__inputCallBack|84_0);
			DeckInfo deckInfo = this.DeckInfo;
			instance.OpenSetPhantomArenaDeckName(bottomText, callBack, ((deckInfo != null) ? deckInfo.GetName() : null) ?? "");
		}

		// Token: 0x0603785C RID: 227420 RVA: 0x00E14C7D File Offset: 0x00E12E7D
		private void OnSlotCardPointEnterCallback(int cardId)
		{
			if (this.CardDetailTip == null)
			{
				return;
			}
			this.CardDetailTip.IsMouseInSlotItem = true;
			this.CardDetailTip.RefreshCard(cardId, null);
			this.CardDetailTip.SetUiActive(true);
		}

		// Token: 0x0603785D RID: 227421 RVA: 0x00E14CAD File Offset: 0x00E12EAD
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

		// Token: 0x0603785E RID: 227422 RVA: 0x00E14CE8 File Offset: 0x00E12EE8
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

		// Token: 0x0603785F RID: 227423 RVA: 0x00E14D2C File Offset: 0x00E12F2C
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

		// Token: 0x06037860 RID: 227424 RVA: 0x00E14E44 File Offset: 0x00E13044
		protected override void OnBeforeDestroy()
		{
			IPhantomArenaDeckBuilderTabViewModel viewModel = this.ViewModel;
			if (viewModel == null)
			{
				return;
			}
			viewModel.EndEditDeck();
		}

		// Token: 0x06037861 RID: 227425 RVA: 0x00E14E58 File Offset: 0x00E13058
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

		// Token: 0x06037867 RID: 227431 RVA: 0x00E15028 File Offset: 0x00E13228
		[NullableContext(0)]
		[CompilerGenerated]
		private UniTask<Aki.Protocol.ErrorCode> <OnChangeNameBtnClick>g__inputCallBack|84_0([Nullable(1)] string input)
		{
			PhantomArenaDeckBuilderTabView.<<OnChangeNameBtnClick>g__inputCallBack|84_0>d <<OnChangeNameBtnClick>g__inputCallBack|84_0>d;
			<<OnChangeNameBtnClick>g__inputCallBack|84_0>d.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
			<<OnChangeNameBtnClick>g__inputCallBack|84_0>d.<>4__this = this;
			<<OnChangeNameBtnClick>g__inputCallBack|84_0>d.input = input;
			<<OnChangeNameBtnClick>g__inputCallBack|84_0>d.<>1__state = -1;
			<<OnChangeNameBtnClick>g__inputCallBack|84_0>d.<>t__builder.Start<PhantomArenaDeckBuilderTabView.<<OnChangeNameBtnClick>g__inputCallBack|84_0>d>(ref <<OnChangeNameBtnClick>g__inputCallBack|84_0>d);
			return <<OnChangeNameBtnClick>g__inputCallBack|84_0>d.<>t__builder.Task;
		}

		// Token: 0x0401FD86 RID: 130438
		protected Dictionary<int, DeckBuilderCardItemData> LibraryCardDataMap = new Dictionary<int, DeckBuilderCardItemData>();

		// Token: 0x0401FD87 RID: 130439
		protected List<DeckBuilderCardItemData> LibraryCardDataList = new List<DeckBuilderCardItemData>();

		// Token: 0x0401FD88 RID: 130440
		protected List<DeckBuilderCardItemData> AllPageCardDataList = new List<DeckBuilderCardItemData>();

		// Token: 0x0401FD89 RID: 130441
		protected List<DeckBuilderCardItemData> CurPageCardDataList = new List<DeckBuilderCardItemData>();

		// Token: 0x0401FD8A RID: 130442
		protected int CurSelectedCardIndex = -1;

		// Token: 0x0401FD8B RID: 130443
		protected int CurPage;

		// Token: 0x0401FD8C RID: 130444
		protected int MinPage;

		// Token: 0x0401FD8D RID: 130445
		protected int MaxPage;

		// Token: 0x0401FD8E RID: 130446
		protected readonly int MaxCardCountPerPage = 8;

		// Token: 0x0401FD8F RID: 130447
		protected List<ICardTabItemData> TabDataList = new List<ICardTabItemData>();

		// Token: 0x0401FD90 RID: 130448
		protected int CurSelectedElementTabIndex = -1;

		// Token: 0x0401FD91 RID: 130449
		protected int CurCostFilter = 1;

		// Token: 0x0401FD92 RID: 130450
		protected bool IncludeLockedCard;

		// Token: 0x0401FD93 RID: 130451
		protected int CurSlotSortType = 1;

		// Token: 0x0401FD94 RID: 130452
		protected bool IsAscending = true;

		// Token: 0x0401FD95 RID: 130453
		protected DeckInfo DeckInfo;

		// Token: 0x0401FD96 RID: 130454
		private LoopScrollView<DeckBuilderElementTabItem, ICardTabItemData> ElementTabScrollView;

		// Token: 0x0401FD97 RID: 130455
		protected GenericLayout<DeckBuilderCardItem, DeckBuilderCardItemData> CardLayout;

		// Token: 0x0401FD98 RID: 130456
		protected PhantomArenaMainViewSwitchItem ShowLockedSwitchItem;

		// Token: 0x0401FD99 RID: 130457
		protected DeckBuilderSortFilterEntrance SlotSortEntrance;

		// Token: 0x0401FD9A RID: 130458
		protected DeckBuilderSortFilterEntrance CardFilterEntrance;

		// Token: 0x0401FD9B RID: 130459
		protected DeckBuilderDeckSlotsPanel DeckSlotsPanel;

		// Token: 0x0401FD9C RID: 130460
		private DeckBuilderCardDetailTip CardDetailTip;

		// Token: 0x0200B483 RID: 46211
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x04037E10 RID: 228880
			public const int ElementTabLoopScrollView = 0;

			// Token: 0x04037E11 RID: 228881
			public const int ElementTabItem = 1;

			// Token: 0x04037E12 RID: 228882
			public const int CardLayout = 2;

			// Token: 0x04037E13 RID: 228883
			public const int CardItem = 3;

			// Token: 0x04037E14 RID: 228884
			public const int FilterItem = 4;

			// Token: 0x04037E15 RID: 228885
			public const int CardEmptyItem = 5;

			// Token: 0x04037E16 RID: 228886
			public const int PageText = 6;

			// Token: 0x04037E17 RID: 228887
			public const int PrePageBtn = 7;

			// Token: 0x04037E18 RID: 228888
			public const int NextPageBtn = 8;

			// Token: 0x04037E19 RID: 228889
			public const int SortItem = 9;

			// Token: 0x04037E1A RID: 228890
			public const int QuicklyBuildBtn = 10;

			// Token: 0x04037E1B RID: 228891
			public const int SaveBtn = 11;

			// Token: 0x04037E1C RID: 228892
			public const int DeckSlotsPanelItem = 12;

			// Token: 0x04037E1D RID: 228893
			public const int RenameBtn = 13;

			// Token: 0x04037E1E RID: 228894
			public const int DeleteBtn = 14;

			// Token: 0x04037E1F RID: 228895
			public const int TextFullTip = 15;

			// Token: 0x04037E20 RID: 228896
			public const int ItemFullTip = 16;

			// Token: 0x04037E21 RID: 228897
			public const int LongPressItem = 17;

			// Token: 0x04037E22 RID: 228898
			public const int SpriteLongPressBar = 18;

			// Token: 0x04037E23 RID: 228899
			public const int ItemDetailTipPanel = 19;
		}
	}
}
