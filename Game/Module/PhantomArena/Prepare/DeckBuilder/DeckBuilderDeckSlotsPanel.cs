using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Common.CardDetail;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054FE RID: 21758
	[NullableContext(1)]
	[Nullable(0)]
	public class DeckBuilderDeckSlotsPanel : UiPanelBase
	{
		// Token: 0x06037746 RID: 227142 RVA: 0x00E100B0 File Offset: 0x00E0E2B0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(8, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(16, typeof(UUIItem))
			};
		}

		// Token: 0x06037747 RID: 227143 RVA: 0x00E10248 File Offset: 0x00E0E448
		protected override UniTask OnBeforeStartAsync()
		{
			DeckBuilderDeckSlotsPanel.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DeckBuilderDeckSlotsPanel.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037748 RID: 227144 RVA: 0x00E1028C File Offset: 0x00E0E48C
		public void RefreshByData(IDeckBuilderDeckSlotsPanelData data)
		{
			this.Data = data;
			if (this.FieldCardItem != null)
			{
				this.FieldCardItem.OnEffectBtnClickCallback = this.Data.OnFieldCardItemEffectBtnClick;
				DeckBuilderCardSlotItem fieldSlotItem = this.FieldCardItem.FieldSlotItem;
				IDeckBuilderDeckSlotsPanelData data2 = this.Data;
				fieldSlotItem.LongPressStartTime = ((data2 != null) ? data2.SlotLongPressStartTime : null).GetValueOrDefault();
				DeckBuilderCardSlotItem fieldSlotItem2 = this.FieldCardItem.FieldSlotItem;
				IDeckBuilderDeckSlotsPanelData data3 = this.Data;
				fieldSlotItem2.LongPressEndTime = ((data3 != null) ? data3.SlotLongPressEndTime : null).GetValueOrDefault();
			}
			if (this.CoreSlotItem != null)
			{
				DeckBuilderCardSlotItem coreSlotItem = this.CoreSlotItem;
				IDeckBuilderDeckSlotsPanelData data4 = this.Data;
				coreSlotItem.LongPressStartTime = ((data4 != null) ? data4.SlotLongPressStartTime : null).GetValueOrDefault();
				DeckBuilderCardSlotItem coreSlotItem2 = this.CoreSlotItem;
				IDeckBuilderDeckSlotsPanelData data5 = this.Data;
				coreSlotItem2.LongPressEndTime = ((data5 != null) ? data5.SlotLongPressEndTime : null).GetValueOrDefault();
			}
			if (data.IsNeedRequestCheckCardSkillUnlock)
			{
				ControllerBase<PhantomArenaController>.Instance.RequestCheckCardSkillUnlock(data.DeckInfo, new Action<PhantomBattleCheckCardSkillUnlockResponse>(this.OnRefreshFieldCardEffectUnlock));
			}
			this.RefreshCardSlot(null, false);
			this.RefreshCardSlotElements();
			this.RefreshNameText();
		}

		// Token: 0x06037749 RID: 227145 RVA: 0x00E103C4 File Offset: 0x00E0E5C4
		public void RefreshCardSlot(int? needPlayAddAnimCard = null, bool keepContentPosition = false)
		{
			this.RefreshCoreCardSlot(needPlayAddAnimCard);
			this.RefreshFieldCardSlot(needPlayAddAnimCard);
			this.RefreshNormalCardSlot(needPlayAddAnimCard, keepContentPosition, 0);
		}

		// Token: 0x0603774A RID: 227146 RVA: 0x00E103E0 File Offset: 0x00E0E5E0
		private IDeckBuilderCardSlotItemData CreateSlotItemData(DeckCardSlotInfo slotInfo)
		{
			int cardId = slotInfo.CardId;
			bool flag = this.Data.ShowLocked && !ModelBase<PhantomArenaModel>.Instance.IsCardUnlock(cardId);
			bool redDotState = flag && ModelBase<PhantomArenaModel>.Instance.CanCardUnlock(cardId);
			bool outlookUnlocked = this.Data.ShowOutlook && ModelBase<PhantomArenaModel>.Instance.IsCardOutlookUnlock(cardId);
			return new DeckBuilderCardSlotItemData
			{
				SlotInfo = slotInfo,
				Locked = flag,
				RedDotState = redDotState,
				OutlookUnlocked = outlookUnlocked,
				NeedPlayAddAnim = false
			};
		}

		// Token: 0x0603774B RID: 227147 RVA: 0x00E1046C File Offset: 0x00E0E66C
		public void RefreshCoreCardSlot(int? needPlayAddAnimCard = null)
		{
			DeckInfo deckInfo = this.Data.DeckInfo;
			DeckCardSlotInfo coreCardSlot = deckInfo.GetCoreCardSlot();
			bool flag = deckInfo.IsCoreCardSlotLocked();
			bool flag2 = coreCardSlot != null;
			this.CoreSlotItem.SetActive(!flag && flag2);
			base.GetItem(5).SetUIActive(!flag && !flag2);
			base.GetItem(6).SetUIActive(flag);
			int value = (coreCardSlot != null) ? coreCardSlot.Count : 0;
			int coreCardCountLimit = deckInfo.GetCoreCardCountLimit();
			UUIText text = base.GetText(3);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(coreCardCountLimit);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			if (coreCardSlot != null)
			{
				this.CurCoreSlotData = this.CreateSlotItemData(coreCardSlot);
				if (needPlayAddAnimCard != null && needPlayAddAnimCard.Value == this.CurCoreSlotData.SlotInfo.CardId)
				{
					this.CurCoreSlotData.NeedPlayAddAnim = true;
				}
				this.CoreSlotItem.Refresh(this.CurCoreSlotData, false, 0);
			}
		}

		// Token: 0x0603774C RID: 227148 RVA: 0x00E1056C File Offset: 0x00E0E76C
		public void RefreshFieldCardSlot(int? needPlayAddAnimCard = null)
		{
			if (this.Data.IsNeedFieldCard)
			{
				DeckBuilderFieldCardItem fieldCardItem = this.FieldCardItem;
				if (fieldCardItem != null)
				{
					fieldCardItem.SetUiActive(true);
				}
				DeckInfo deckInfo = this.Data.DeckInfo;
				DeckBuilderFieldCardItem fieldCardItem2 = this.FieldCardItem;
				if (fieldCardItem2 != null)
				{
					fieldCardItem2.RefreshItem(deckInfo, needPlayAddAnimCard);
				}
				DeckCardSlotInfo fieldCardSlot = deckInfo.GetFieldCardSlot();
				if (fieldCardSlot != null)
				{
					IDeckBuilderCardSlotItemData deckBuilderCardSlotItemData = this.CreateSlotItemData(fieldCardSlot);
					if (needPlayAddAnimCard != null && needPlayAddAnimCard.Value == deckBuilderCardSlotItemData.SlotInfo.CardId)
					{
						deckBuilderCardSlotItemData.NeedPlayAddAnim = true;
					}
					DeckBuilderFieldCardItem fieldCardItem3 = this.FieldCardItem;
					if (fieldCardItem3 == null)
					{
						return;
					}
					fieldCardItem3.RefreshSlotItem(deckBuilderCardSlotItemData);
				}
				return;
			}
			DeckBuilderFieldCardItem fieldCardItem4 = this.FieldCardItem;
			if (fieldCardItem4 == null)
			{
				return;
			}
			fieldCardItem4.SetUiActive(false);
		}

		// Token: 0x0603774D RID: 227149 RVA: 0x00E10610 File Offset: 0x00E0E810
		public void RefreshNormalCardSlot(int? needPlayAddAnimCard = null, bool keepContentPosition = false, int scrollToSlotId = 0)
		{
			DeckInfo deckInfo = this.Data.DeckInfo;
			List<DeckCardSlotInfo> list = deckInfo.GetNormalCardSlotList().ToList<DeckCardSlotInfo>();
			ModelBase<PhantomArenaModel>.Instance.SortCardSlotList<DeckCardSlotInfo>(list, this.Data.SortContext);
			this.CurNormalSlotDataList.Clear();
			foreach (DeckCardSlotInfo slotInfo in list)
			{
				IDeckBuilderCardSlotItemData deckBuilderCardSlotItemData = this.CreateSlotItemData(slotInfo);
				deckBuilderCardSlotItemData.NeedPlayAddAnim = (needPlayAddAnimCard != null && needPlayAddAnimCard.Value == deckBuilderCardSlotItemData.SlotInfo.CardId);
				this.CurNormalSlotDataList.Add(deckBuilderCardSlotItemData);
			}
			GenericScrollViewNew<DeckBuilderCardSlotItem, IDeckBuilderCardSlotItemData> normalSlotScrollLayout = this.NormalSlotScrollLayout;
			if (normalSlotScrollLayout != null)
			{
				Predicate<IDeckBuilderCardSlotItemData> <>9__1;
				normalSlotScrollLayout.RefreshByData(this.CurNormalSlotDataList, delegate
				{
					if (scrollToSlotId != 0)
					{
						List<IDeckBuilderCardSlotItemData> curNormalSlotDataList = this.CurNormalSlotDataList;
						Predicate<IDeckBuilderCardSlotItemData> match;
						if ((match = <>9__1) == null)
						{
							match = (<>9__1 = ((IDeckBuilderCardSlotItemData slot) => slot.SlotInfo.CardId == scrollToSlotId));
						}
						int num = curNormalSlotDataList.FindIndex(match);
						if (num < 0)
						{
							return;
						}
						UUIItem itemByIndex = this.NormalSlotScrollLayout.GetItemByIndex(num);
						if (itemByIndex == null)
						{
							return;
						}
						if (this.NormalSlotScrollLayout.IsItemInViewport(itemByIndex, 0.1f) != EOutOfBoundsType.NotOut)
						{
							this.NormalSlotScrollLayout.ScrollTo(itemByIndex, false);
						}
					}
				}, false);
			}
			bool flag = this.CurNormalSlotDataList.Count > 0;
			base.GetVerticalLayout(14).RootUIComp.Get().SetUIActive(flag);
			base.GetItem(12).SetUIActive(!flag);
			int normalCardCount = deckInfo.GetNormalCardCount();
			int normalCardCountLimit = deckInfo.GetNormalCardCountLimit();
			UUIText text = base.GetText(10);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(normalCardCount);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(normalCardCountLimit);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603774E RID: 227150 RVA: 0x00E10794 File Offset: 0x00E0E994
		private void OnRefreshFieldCardEffectUnlock(PhantomBattleCheckCardSkillUnlockResponse info)
		{
			this.RefreshFieldCardEffectUnlock(info);
		}

		// Token: 0x0603774F RID: 227151 RVA: 0x00E107A0 File Offset: 0x00E0E9A0
		public void RefreshFieldCardEffectUnlock(PhantomBattleCheckCardSkillUnlockResponse info)
		{
			DeckCardSlotInfo fieldCardSlot = this.Data.DeckInfo.GetFieldCardSlot();
			if (fieldCardSlot == null || this.FieldCardItem == null)
			{
				return;
			}
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(fieldCardSlot.CardId);
			string conditionDesc = (info.CurNum >= info.TargetNum) ? phantomBattleCardConfig.FieldConditionDesc : phantomBattleCardConfig.FieldUnlockConditionDesc;
			CardDetailConditionOutData data = new CardDetailConditionOutData
			{
				CurrentProgress = info.CurNum,
				MaxProgress = info.TargetNum,
				Icon = phantomBattleCardConfig.FieldConditionIcon,
				ConditionDesc = conditionDesc
			};
			DeckBuilderFieldCardItem fieldCardItem = this.FieldCardItem;
			if (fieldCardItem == null)
			{
				return;
			}
			fieldCardItem.RefreshEffectUnlock(data);
		}

		// Token: 0x06037750 RID: 227152 RVA: 0x00E10842 File Offset: 0x00E0EA42
		public void RefreshCardSlotElements()
		{
			this.RefreshCoreCardSlotElement();
			this.RefreshNormalCardSlotElement();
		}

		// Token: 0x06037751 RID: 227153 RVA: 0x00E10850 File Offset: 0x00E0EA50
		private void RefreshCoreCardSlotElement()
		{
			DeckCardSlotInfo coreCardSlot = this.Data.DeckInfo.GetCoreCardSlot();
			List<int> list = new List<int>();
			if (coreCardSlot != null)
			{
				list.Add(coreCardSlot.Element);
			}
			GenericLayout<CardElementItem, ECardElement> coreElementLayout = this.CoreElementLayout;
			if (coreElementLayout == null)
			{
				return;
			}
			coreElementLayout.RefreshByData(list.Cast<ECardElement>().ToList<ECardElement>(), null, false);
		}

		// Token: 0x06037752 RID: 227154 RVA: 0x00E108A0 File Offset: 0x00E0EAA0
		private void RefreshNormalCardSlotElement()
		{
			GenericLayout<CardElementItem, ECardElement> normalElementLayout = this.NormalElementLayout;
			if (normalElementLayout == null)
			{
				return;
			}
			normalElementLayout.RefreshByData(this.Data.DeckInfo.GetElementList(), null, false);
		}

		// Token: 0x06037753 RID: 227155 RVA: 0x00E108C4 File Offset: 0x00E0EAC4
		public void RefreshNameText()
		{
			base.GetText(0).SetText(this.Data.DeckInfo.GetDeckName(), true);
		}

		// Token: 0x06037754 RID: 227156 RVA: 0x00E108E4 File Offset: 0x00E0EAE4
		public void RefreshBySortContext(CardSlotSortContext sortContext)
		{
			this.Data.SortContext = sortContext;
			this.RefreshNormalCardSlot(null, false, 0);
		}

		// Token: 0x06037755 RID: 227157 RVA: 0x00E10910 File Offset: 0x00E0EB10
		public bool SelectFieldCardSlot()
		{
			DeckCardSlotInfo fieldCardSlot = this.Data.DeckInfo.GetFieldCardSlot();
			if (fieldCardSlot == null)
			{
				return false;
			}
			GenericScrollViewNew<DeckBuilderCardSlotItem, IDeckBuilderCardSlotItemData> normalSlotScrollLayout = this.NormalSlotScrollLayout;
			if (normalSlotScrollLayout != null)
			{
				normalSlotScrollLayout.SelectGridProxy(-1, false);
			}
			this.CoreSlotItem.OnDeselected(false);
			this.SelectedCardId = fieldCardSlot.CardId;
			return true;
		}

		// Token: 0x06037756 RID: 227158 RVA: 0x00E10960 File Offset: 0x00E0EB60
		public bool SelectCoreCardSlot()
		{
			DeckCardSlotInfo coreCardSlot = this.Data.DeckInfo.GetCoreCardSlot();
			if (coreCardSlot == null)
			{
				return false;
			}
			GenericScrollViewNew<DeckBuilderCardSlotItem, IDeckBuilderCardSlotItemData> normalSlotScrollLayout = this.NormalSlotScrollLayout;
			if (normalSlotScrollLayout != null)
			{
				normalSlotScrollLayout.SelectGridProxy(-1, false);
			}
			DeckBuilderFieldCardItem fieldCardItem = this.FieldCardItem;
			if (fieldCardItem != null)
			{
				DeckBuilderCardSlotItem fieldSlotItem = fieldCardItem.FieldSlotItem;
				if (fieldSlotItem != null)
				{
					fieldSlotItem.OnDeselected(false);
				}
			}
			this.CoreSlotItem.OnSelected(false);
			this.SelectedCardId = coreCardSlot.CardId;
			return true;
		}

		// Token: 0x06037757 RID: 227159 RVA: 0x00E109CC File Offset: 0x00E0EBCC
		public bool SelectNormalCardSlotByIndex(int index)
		{
			this.CoreSlotItem.OnDeselected(false);
			DeckBuilderFieldCardItem fieldCardItem = this.FieldCardItem;
			if (fieldCardItem != null)
			{
				DeckBuilderCardSlotItem fieldSlotItem = fieldCardItem.FieldSlotItem;
				if (fieldSlotItem != null)
				{
					fieldSlotItem.OnDeselected(false);
				}
			}
			this.NormalSlotScrollLayout.SelectGridProxy(index, false);
			if (index < 0 || index >= this.CurNormalSlotDataList.Count)
			{
				Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.LZK, "SelectNormalCardSlotByIndex Error, index out of range", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.SelectedCardId = this.CurNormalSlotDataList[index].SlotInfo.CardId;
			return true;
		}

		// Token: 0x06037758 RID: 227160 RVA: 0x00E10A60 File Offset: 0x00E0EC60
		public void RefreshOutlookByCardId(int cardId)
		{
			bool outlookUnlocked = this.Data.ShowOutlook && ModelBase<PhantomArenaModel>.Instance.IsCardOutlookUnlock(cardId);
			IDeckBuilderCardSlotItemData curCoreSlotData = this.CurCoreSlotData;
			if (curCoreSlotData != null && cardId == curCoreSlotData.SlotInfo.CardId)
			{
				curCoreSlotData.OutlookUnlocked = outlookUnlocked;
				this.CoreSlotItem.RefreshOutlookState();
				return;
			}
			int num = this.CurNormalSlotDataList.FindIndex((IDeckBuilderCardSlotItemData slot) => slot.SlotInfo.CardId == cardId);
			if (num < 0)
			{
				return;
			}
			this.CurNormalSlotDataList[num].OutlookUnlocked = outlookUnlocked;
			DeckBuilderCardSlotItem scrollItemByIndex = this.NormalSlotScrollLayout.GetScrollItemByIndex(num);
			if (scrollItemByIndex == null)
			{
				return;
			}
			scrollItemByIndex.RefreshOutlookState();
		}

		// Token: 0x06037759 RID: 227161 RVA: 0x00E10B10 File Offset: 0x00E0ED10
		private DeckBuilderCardSlotItem CreateNormalSlotItem()
		{
			DeckBuilderCardSlotItem deckBuilderCardSlotItem = new DeckBuilderCardSlotItem();
			IDeckBuilderDeckSlotsPanelData data = this.Data;
			deckBuilderCardSlotItem.LongPressStartTime = ((data != null) ? data.SlotLongPressStartTime : null).GetValueOrDefault();
			IDeckBuilderDeckSlotsPanelData data2 = this.Data;
			deckBuilderCardSlotItem.LongPressEndTime = ((data2 != null) ? data2.SlotLongPressEndTime : null).GetValueOrDefault();
			deckBuilderCardSlotItem.CanToggleChange = new Func<DeckBuilderCardSlotItem, bool>(this.CanNormalSlotItemToggleChange);
			deckBuilderCardSlotItem.ShortClickCallback = delegate(DeckBuilderCardSlotItem item)
			{
				IDeckBuilderDeckSlotsPanelData data4 = this.Data;
				if (data4 == null)
				{
					return;
				}
				Action<DeckBuilderCardSlotItem> onNormalSlotItemSortClick = data4.OnNormalSlotItemSortClick;
				if (onNormalSlotItemSortClick == null)
				{
					return;
				}
				onNormalSlotItemSortClick(item);
			};
			deckBuilderCardSlotItem.LongPressCallback = delegate(DeckBuilderCardSlotItem item, float progress)
			{
				IDeckBuilderDeckSlotsPanelData data4 = this.Data;
				if (data4 == null)
				{
					return;
				}
				Action<DeckBuilderCardSlotItem, float> onNormalSlotItemLongPress = data4.OnNormalSlotItemLongPress;
				if (onNormalSlotItemLongPress == null)
				{
					return;
				}
				onNormalSlotItemLongPress(item, progress);
			};
			IDeckBuilderDeckSlotsPanelData data3 = this.Data;
			deckBuilderCardSlotItem.LongPressEndCallback = ((data3 != null) ? data3.OnSlotItemLongPressEnd : null);
			deckBuilderCardSlotItem.OnToggleStateChange = delegate(DeckBuilderCardSlotItem item, EToggleState state)
			{
				IDeckBuilderDeckSlotsPanelData data4 = this.Data;
				if (data4 == null)
				{
					return;
				}
				Action<DeckBuilderCardSlotItem, EToggleState> onNormalSlotItemToggleStateChange = data4.OnNormalSlotItemToggleStateChange;
				if (onNormalSlotItemToggleStateChange == null)
				{
					return;
				}
				onNormalSlotItemToggleStateChange(item, state);
			};
			deckBuilderCardSlotItem.OnPointEnterCallback = delegate(int cardId)
			{
				IDeckBuilderDeckSlotsPanelData data4 = this.Data;
				if (data4 == null)
				{
					return;
				}
				Action<int> onSlotCardPointEnterCallback = data4.OnSlotCardPointEnterCallback;
				if (onSlotCardPointEnterCallback == null)
				{
					return;
				}
				onSlotCardPointEnterCallback(cardId);
			};
			deckBuilderCardSlotItem.OnPointExitCallback = delegate()
			{
				IDeckBuilderDeckSlotsPanelData data4 = this.Data;
				if (data4 == null)
				{
					return;
				}
				Action onSlotCardPointExitCallback = data4.OnSlotCardPointExitCallback;
				if (onSlotCardPointExitCallback == null)
				{
					return;
				}
				onSlotCardPointExitCallback();
			};
			return deckBuilderCardSlotItem;
		}

		// Token: 0x0603775A RID: 227162 RVA: 0x00E10BF6 File Offset: 0x00E0EDF6
		private bool CanNormalSlotItemToggleChange(DeckBuilderCardSlotItem item)
		{
			return this.Data.CanNormalSlotItemToggleChange(item);
		}

		// Token: 0x0603775B RID: 227163 RVA: 0x00E10C0C File Offset: 0x00E0EE0C
		private DeckBuilderCardSlotItem CreateCoreSlotItem()
		{
			return new DeckBuilderCardSlotItem
			{
				CanToggleChange = new Func<DeckBuilderCardSlotItem, bool>(this.CanCoreSlotItemToggleChange),
				ShortClickCallback = delegate(DeckBuilderCardSlotItem item)
				{
					IDeckBuilderDeckSlotsPanelData data = this.Data;
					if (data == null)
					{
						return;
					}
					Action<DeckBuilderCardSlotItem> onCoreSlotItemSortClick = data.OnCoreSlotItemSortClick;
					if (onCoreSlotItemSortClick == null)
					{
						return;
					}
					onCoreSlotItemSortClick(item);
				},
				LongPressCallback = delegate(DeckBuilderCardSlotItem item, float progress)
				{
					IDeckBuilderDeckSlotsPanelData data = this.Data;
					if (data == null)
					{
						return;
					}
					Action<DeckBuilderCardSlotItem, float> onCoreSlotItemLongPress = data.OnCoreSlotItemLongPress;
					if (onCoreSlotItemLongPress == null)
					{
						return;
					}
					onCoreSlotItemLongPress(item, progress);
				},
				LongPressEndCallback = delegate()
				{
					IDeckBuilderDeckSlotsPanelData data = this.Data;
					if (data == null)
					{
						return;
					}
					Action onSlotItemLongPressEnd = data.OnSlotItemLongPressEnd;
					if (onSlotItemLongPressEnd == null)
					{
						return;
					}
					onSlotItemLongPressEnd();
				},
				OnToggleStateChange = delegate(DeckBuilderCardSlotItem item, EToggleState state)
				{
					IDeckBuilderDeckSlotsPanelData data = this.Data;
					if (data == null)
					{
						return;
					}
					Action<DeckBuilderCardSlotItem, EToggleState> onCoreSlotItemToggleStateChange = data.OnCoreSlotItemToggleStateChange;
					if (onCoreSlotItemToggleStateChange == null)
					{
						return;
					}
					onCoreSlotItemToggleStateChange(item, state);
				},
				OnPointEnterCallback = delegate(int cardId)
				{
					IDeckBuilderDeckSlotsPanelData data = this.Data;
					if (data == null)
					{
						return;
					}
					Action<int> onSlotCardPointEnterCallback = data.OnSlotCardPointEnterCallback;
					if (onSlotCardPointEnterCallback == null)
					{
						return;
					}
					onSlotCardPointEnterCallback(cardId);
				},
				OnPointExitCallback = delegate()
				{
					IDeckBuilderDeckSlotsPanelData data = this.Data;
					if (data == null)
					{
						return;
					}
					Action onSlotCardPointExitCallback = data.OnSlotCardPointExitCallback;
					if (onSlotCardPointExitCallback == null)
					{
						return;
					}
					onSlotCardPointExitCallback();
				}
			};
		}

		// Token: 0x0603775C RID: 227164 RVA: 0x00E10C9C File Offset: 0x00E0EE9C
		private bool CanCoreSlotItemToggleChange(DeckBuilderCardSlotItem item)
		{
			return this.Data.CanCoreSlotItemToggleChange(item);
		}

		// Token: 0x0603775D RID: 227165 RVA: 0x00E10CB0 File Offset: 0x00E0EEB0
		private DeckBuilderCardSlotItem CreateFieldSlotItem()
		{
			return new DeckBuilderCardSlotItem
			{
				CanToggleChange = new Func<DeckBuilderCardSlotItem, bool>(this.CanFieldSlotItemToggleChange),
				ShortClickCallback = delegate(DeckBuilderCardSlotItem item)
				{
					IDeckBuilderDeckSlotsPanelData data = this.Data;
					if (data == null)
					{
						return;
					}
					Action<DeckBuilderCardSlotItem> onCoreSlotItemSortClick = data.OnCoreSlotItemSortClick;
					if (onCoreSlotItemSortClick == null)
					{
						return;
					}
					onCoreSlotItemSortClick(item);
				},
				LongPressCallback = delegate(DeckBuilderCardSlotItem item, float progress)
				{
					IDeckBuilderDeckSlotsPanelData data = this.Data;
					if (data == null)
					{
						return;
					}
					Action<DeckBuilderCardSlotItem, float> onCoreSlotItemLongPress = data.OnCoreSlotItemLongPress;
					if (onCoreSlotItemLongPress == null)
					{
						return;
					}
					onCoreSlotItemLongPress(item, progress);
				},
				LongPressEndCallback = delegate()
				{
					IDeckBuilderDeckSlotsPanelData data = this.Data;
					if (data == null)
					{
						return;
					}
					Action onSlotItemLongPressEnd = data.OnSlotItemLongPressEnd;
					if (onSlotItemLongPressEnd == null)
					{
						return;
					}
					onSlotItemLongPressEnd();
				},
				OnToggleStateChange = delegate(DeckBuilderCardSlotItem item, EToggleState state)
				{
					IDeckBuilderDeckSlotsPanelData data = this.Data;
					if (data == null)
					{
						return;
					}
					Action<DeckBuilderCardSlotItem, EToggleState> onFieldSlotItemToggleStateChange = data.OnFieldSlotItemToggleStateChange;
					if (onFieldSlotItemToggleStateChange == null)
					{
						return;
					}
					onFieldSlotItemToggleStateChange(item, state);
				},
				OnPointEnterCallback = delegate(int cardId)
				{
					IDeckBuilderDeckSlotsPanelData data = this.Data;
					if (data == null)
					{
						return;
					}
					Action<int> onSlotCardPointEnterCallback = data.OnSlotCardPointEnterCallback;
					if (onSlotCardPointEnterCallback == null)
					{
						return;
					}
					onSlotCardPointEnterCallback(cardId);
				},
				OnPointExitCallback = delegate()
				{
					IDeckBuilderDeckSlotsPanelData data = this.Data;
					if (data == null)
					{
						return;
					}
					Action onSlotCardPointExitCallback = data.OnSlotCardPointExitCallback;
					if (onSlotCardPointExitCallback == null)
					{
						return;
					}
					onSlotCardPointExitCallback();
				}
			};
		}

		// Token: 0x0603775E RID: 227166 RVA: 0x00E10D40 File Offset: 0x00E0EF40
		private bool CanFieldSlotItemToggleChange(DeckBuilderCardSlotItem item)
		{
			return this.Data.CanFieldSlotItemToggleChange(item);
		}

		// Token: 0x0603775F RID: 227167 RVA: 0x00E10D53 File Offset: 0x00E0EF53
		private CardElementItem CreateElementItem()
		{
			return new CardElementItem();
		}

		// Token: 0x06037760 RID: 227168 RVA: 0x00E10D5A File Offset: 0x00E0EF5A
		public int GetSelectedCardId()
		{
			return this.SelectedCardId;
		}

		// Token: 0x06037761 RID: 227169 RVA: 0x00E10D62 File Offset: 0x00E0EF62
		private void OnNormalMaskToggleChange(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.SwitchMaskState(EPhantomArenaDeckSlotType.Normal);
			}
		}

		// Token: 0x06037762 RID: 227170 RVA: 0x00E10D6F File Offset: 0x00E0EF6F
		private void OnCoreMaskToggleChange(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.SwitchMaskState(EPhantomArenaDeckSlotType.Core);
			}
		}

		// Token: 0x06037763 RID: 227171 RVA: 0x00E10D7C File Offset: 0x00E0EF7C
		public void SetMaskAreaEnabled(EPhantomArenaDeckSlotType area, bool enabled)
		{
			SlotAreaInfo slotAreaInfo;
			if (!this.SlotAreaInfoMap.TryGetValue(area, out slotAreaInfo))
			{
				return;
			}
			if (slotAreaInfo.Enabled == enabled)
			{
				return;
			}
			slotAreaInfo.Enabled = enabled;
			UUIExtendToggle toggle = slotAreaInfo.Toggle;
			if (!enabled)
			{
				toggle.SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
				if (this.ActiveSlotArea == area)
				{
					this.ActiveSlotArea = EPhantomArenaDeckSlotType.None;
					return;
				}
			}
			else
			{
				if (this.ActiveSlotArea == area)
				{
					slotAreaInfo.MaskItem.SetUIActive(false);
					toggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
					return;
				}
				slotAreaInfo.MaskItem.SetUIActive(true);
				toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
		}

		// Token: 0x06037764 RID: 227172 RVA: 0x00E10E0C File Offset: 0x00E0F00C
		public void SwitchMaskState(EPhantomArenaDeckSlotType activeSlotArea)
		{
			if (this.ActiveSlotArea == activeSlotArea)
			{
				return;
			}
			SlotAreaInfo slotAreaInfo;
			if (!this.SlotAreaInfoMap.TryGetValue(activeSlotArea, out slotAreaInfo))
			{
				return;
			}
			if (!slotAreaInfo.Enabled)
			{
				return;
			}
			SlotAreaInfo slotAreaInfo2;
			this.SlotAreaInfoMap.TryGetValue(this.ActiveSlotArea, out slotAreaInfo2);
			SlotAreaInfo slotAreaInfo3 = this.SlotAreaInfoMap[activeSlotArea];
			this.ActiveSlotArea = activeSlotArea;
			if (slotAreaInfo2 != null && slotAreaInfo2.Enabled)
			{
				slotAreaInfo2.MaskItem.SetUIActive(true);
				slotAreaInfo2.Toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			if (slotAreaInfo3 != null && slotAreaInfo3.Enabled)
			{
				slotAreaInfo3.MaskItem.SetUIActive(false);
				slotAreaInfo3.Toggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
		}

		// Token: 0x06037765 RID: 227173 RVA: 0x00E10EB4 File Offset: 0x00E0F0B4
		public void GamepadTriggerDeckBuilderCardInfoView(UUIItem uiItem)
		{
			if (uiItem == this.CoreSlotItem.GetRootItem())
			{
				this.CoreSlotItem.TriggerLongPress();
				return;
			}
			for (int i = 0; i < this.CurNormalSlotDataList.Count; i++)
			{
				DeckBuilderCardSlotItem scrollItemByIndex = this.NormalSlotScrollLayout.GetScrollItemByIndex(i);
				if (((scrollItemByIndex != null) ? scrollItemByIndex.GetRootItem() : null) == uiItem)
				{
					scrollItemByIndex.TriggerLongPress();
					return;
				}
			}
		}

		// Token: 0x06037766 RID: 227174 RVA: 0x00E10F14 File Offset: 0x00E0F114
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
			if (!(configParams[0] == "CardInGroup"))
			{
				return null;
			}
			int index = int.Parse(configParams[1]);
			GenericScrollViewNew<DeckBuilderCardSlotItem, IDeckBuilderCardSlotItemData> normalSlotScrollLayout = this.NormalSlotScrollLayout;
			UUIItem uuiitem = (normalSlotScrollLayout != null) ? normalSlotScrollLayout.GetItemByIndex(index) : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x0401FD3D RID: 130365
		private const float ITEM_LOCATION_TOLERANCE = 0.1f;

		// Token: 0x0401FD3E RID: 130366
		[Nullable(2)]
		protected IDeckBuilderDeckSlotsPanelData Data;

		// Token: 0x0401FD3F RID: 130367
		[Nullable(2)]
		protected IDeckBuilderCardSlotItemData CurCoreSlotData;

		// Token: 0x0401FD40 RID: 130368
		[Nullable(2)]
		protected IDeckBuilderCardSlotItemData CurFieldSlotData;

		// Token: 0x0401FD41 RID: 130369
		protected List<IDeckBuilderCardSlotItemData> CurNormalSlotDataList = new List<IDeckBuilderCardSlotItemData>();

		// Token: 0x0401FD42 RID: 130370
		[Nullable(2)]
		private DeckBuilderCardSlotItem CoreSlotItem;

		// Token: 0x0401FD43 RID: 130371
		[Nullable(2)]
		private DeckBuilderFieldCardItem FieldCardItem;

		// Token: 0x0401FD44 RID: 130372
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericScrollViewNew<DeckBuilderCardSlotItem, IDeckBuilderCardSlotItemData> NormalSlotScrollLayout;

		// Token: 0x0401FD45 RID: 130373
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected GenericLayout<CardElementItem, ECardElement> CoreElementLayout;

		// Token: 0x0401FD46 RID: 130374
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected GenericLayout<CardElementItem, ECardElement> NormalElementLayout;

		// Token: 0x0401FD47 RID: 130375
		private int SelectedCardId;

		// Token: 0x0401FD48 RID: 130376
		private EPhantomArenaDeckSlotType ActiveSlotArea;

		// Token: 0x0401FD49 RID: 130377
		private readonly Dictionary<EPhantomArenaDeckSlotType, SlotAreaInfo> SlotAreaInfoMap = new Dictionary<EPhantomArenaDeckSlotType, SlotAreaInfo>();

		// Token: 0x0200B474 RID: 46196
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037DC5 RID: 228805
			public const int NameText = 0;

			// Token: 0x04037DC6 RID: 228806
			public const int CoreMaskToggle = 1;

			// Token: 0x04037DC7 RID: 228807
			public const int CoreMaskItem = 2;

			// Token: 0x04037DC8 RID: 228808
			public const int CoreCardSlotCountText = 3;

			// Token: 0x04037DC9 RID: 228809
			public const int CoreElementLayout = 4;

			// Token: 0x04037DCA RID: 228810
			public const int CoreCardSlotEmptyItem = 5;

			// Token: 0x04037DCB RID: 228811
			public const int CoreCardSlotLockedItem = 6;

			// Token: 0x04037DCC RID: 228812
			public const int CoreCardSlotItem = 7;

			// Token: 0x04037DCD RID: 228813
			public const int NormalMaskToggle = 8;

			// Token: 0x04037DCE RID: 228814
			public const int NormalMaskItem = 9;

			// Token: 0x04037DCF RID: 228815
			public const int NormalCardSlotCountText = 10;

			// Token: 0x04037DD0 RID: 228816
			public const int NormalElementLayout = 11;

			// Token: 0x04037DD1 RID: 228817
			public const int NormalCardSlotEmptyItem = 12;

			// Token: 0x04037DD2 RID: 228818
			public const int NormalCardSlotScrollView = 13;

			// Token: 0x04037DD3 RID: 228819
			public const int NormalCardSlotLayout = 14;

			// Token: 0x04037DD4 RID: 228820
			public const int NormalCardSlotItem = 15;

			// Token: 0x04037DD5 RID: 228821
			public const int FieldCardItem = 16;
		}
	}
}
