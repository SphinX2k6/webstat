using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Common.CardDetail;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckDetail
{
	// Token: 0x020054E5 RID: 21733
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaDeckDetailView : UiViewBase
	{
		// Token: 0x0603761E RID: 226846 RVA: 0x00E0D849 File Offset: 0x00E0BA49
		public PhantomArenaDeckDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603761F RID: 226847 RVA: 0x00E0D854 File Offset: 0x00E0BA54
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIText)),
				new ValueTuple<int, Type>(16, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(12, new Action(this.OnCardDescBtnClick)),
				new ValueTuple<int, Delegate>(16, new Action(this.OnMaskBtnClick))
			};
		}

		// Token: 0x06037620 RID: 226848 RVA: 0x00E0DA28 File Offset: 0x00E0BC28
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaDeckDetailView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaDeckDetailView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037621 RID: 226849 RVA: 0x00E0DA6B File Offset: 0x00E0BC6B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnPhantomArenaCardUnlock));
		}

		// Token: 0x06037622 RID: 226850 RVA: 0x00E0DA89 File Offset: 0x00E0BC89
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnPhantomArenaCardUnlock));
		}

		// Token: 0x06037623 RID: 226851 RVA: 0x00E0DAA8 File Offset: 0x00E0BCA8
		public void RefreshDeckSlotsPanel()
		{
			bool isNeedFieldCard = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(this.Data.ActivityId);
			DeckBuilderDeckSlotsPanelData data = new DeckBuilderDeckSlotsPanelData
			{
				DeckInfo = this.Data.DeckInfo,
				OnCoreSlotItemToggleStateChange = new Action<DeckBuilderCardSlotItem, EToggleState>(this.OnCoreSlotItemToggleStateChange),
				CanCoreSlotItemToggleChange = new Func<DeckBuilderCardSlotItem, bool>(this.CanCoreSlotItemToggleChange),
				OnNormalSlotItemToggleStateChange = new Action<DeckBuilderCardSlotItem, EToggleState>(this.OnNormalSlotItemToggleStateChange),
				CanNormalSlotItemToggleChange = new Func<DeckBuilderCardSlotItem, bool>(this.CanNormalSlotItemToggleChange),
				OnFieldSlotItemToggleStateChange = new Action<DeckBuilderCardSlotItem, EToggleState>(this.OnFieldSlotItemToggleStateChange),
				CanFieldSlotItemToggleChange = new Func<DeckBuilderCardSlotItem, bool>(this.CanFieldSlotItemToggleChange),
				SortContext = new CardSlotSortContext
				{
					SortType = ECardSlotSortType.Cost,
					IsAscending = true
				},
				ShowLocked = this.Data.ShowLocked,
				ShowOutlook = this.Data.ShowLocked,
				IsNeedFieldCard = isNeedFieldCard,
				IsNeedRequestCheckCardSkillUnlock = true
			};
			DeckBuilderDeckSlotsPanel deckSlotsPanel = this.DeckSlotsPanel;
			if (deckSlotsPanel == null)
			{
				return;
			}
			deckSlotsPanel.RefreshByData(data);
		}

		// Token: 0x06037624 RID: 226852 RVA: 0x00E0DBA8 File Offset: 0x00E0BDA8
		public void SelectFirstCardSlot()
		{
			if (this.SelectCoreCardSlot())
			{
				return;
			}
			this.SelectNormalCardSlotByIndex(0);
		}

		// Token: 0x06037625 RID: 226853 RVA: 0x00E0DBBA File Offset: 0x00E0BDBA
		public bool SelectFieldCardSlot()
		{
			if (!this.DeckSlotsPanel.SelectFieldCardSlot())
			{
				return false;
			}
			this.Data.CurCardId = new int?(this.DeckSlotsPanel.GetSelectedCardId());
			this.RefreshCardDetail();
			return true;
		}

		// Token: 0x06037626 RID: 226854 RVA: 0x00E0DBED File Offset: 0x00E0BDED
		public bool SelectCoreCardSlot()
		{
			if (!this.DeckSlotsPanel.SelectCoreCardSlot())
			{
				return false;
			}
			this.Data.CurCardId = new int?(this.DeckSlotsPanel.GetSelectedCardId());
			this.RefreshCardDetail();
			return true;
		}

		// Token: 0x06037627 RID: 226855 RVA: 0x00E0DC20 File Offset: 0x00E0BE20
		public void SelectNormalCardSlotByIndex(int index)
		{
			this.DeckSlotsPanel.SelectNormalCardSlotByIndex(index);
			this.Data.CurCardId = new int?(this.DeckSlotsPanel.GetSelectedCardId());
			this.RefreshCardDetail();
		}

		// Token: 0x06037628 RID: 226856 RVA: 0x00E0DC50 File Offset: 0x00E0BE50
		public void RefreshCardDetail()
		{
			int value = this.Data.CurCardId.Value;
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(value);
			Dictionary<int, int> dictionary = phantomBattleCardConfig.InitAttack();
			int attack = dictionary.ContainsKey(0) ? dictionary[0] : 0;
			int life = dictionary.ContainsKey(1) ? dictionary[1] : 0;
			int cost = phantomBattleCardConfig.Cost;
			this.Data.IsUnlock = new bool?(this.IsCardUnlock(value));
			this.RefreshDetailLockState();
			bool flag = this.Data.ShowLocked && ModelBase<PhantomArenaModel>.Instance.IsCardOutlookUnlock(value);
			ECardFaceType cardFaceType = (flag && ModelBase<PhantomArenaModel>.Instance.CheckCardSpineConfigValid(value)) ? ECardFaceType.Spine : ECardFaceType.Texture;
			DetailViewCardItemData detailViewCardItemData = new DetailViewCardItemData
			{
				IsLock = !this.Data.IsUnlock.Value,
				CardId = value,
				Cost = cost,
				Attack = attack,
				Life = life,
				Element = phantomBattleCardConfig.Element,
				CardFaceTexturePath = phantomBattleCardConfig.CardFaceTexture,
				CardSpineData = ModelBase<PhantomArenaModel>.Instance.CreateCardSpineData(value),
				OutlookUnlocked = flag,
				CardFaceType = cardFaceType,
				CardType = (ECardType)phantomBattleCardConfig.Type
			};
			this.Data.CardItemData = detailViewCardItemData;
			this.CardItem.Refresh(detailViewCardItemData);
			int[] array = phantomBattleCardConfig.CardFactorId();
			CardDetailItemData detailViewDetailItemData = ModelBase<PhantomArenaModel>.Instance.GetDetailViewDetailItemData(value, this.Data.DeckInfo);
			this.Data.DetailItemData = detailViewDetailItemData;
			this.DetailItem.Refresh(detailViewDetailItemData);
			List<int> list = new List<int>();
			list.AddRange(phantomBattleCardConfig.GetEntryIdListBytes());
			foreach (int factorConfigId in array)
			{
				int entryId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleFactorConfig(factorConfigId).EntryId;
				if (entryId > 0 && !list.Contains(entryId))
				{
					list.Add(entryId);
				}
			}
			this.Data.EntryList = list;
			this.EntryDescLayoutItem.Refresh(list);
		}

		// Token: 0x06037629 RID: 226857 RVA: 0x00E0DE66 File Offset: 0x00E0C066
		protected bool IsCardUnlock(int cardId)
		{
			return !this.Data.ShowLocked || ModelBase<PhantomArenaModel>.Instance.IsCardUnlock(cardId);
		}

		// Token: 0x0603762A RID: 226858 RVA: 0x00E0DE84 File Offset: 0x00E0C084
		protected void RefreshDetailLockState()
		{
			UpdateCardDetailLockStateContext context = new UpdateCardDetailLockStateContext
			{
				CardId = this.Data.CurCardId.Value,
				LockTipItem = base.GetItem(14),
				LockTipText = base.GetText(15),
				TipText = base.GetText(9),
				UnlockBtnItem = this.UnlockBtnItem,
				IsUnLocked = this.IsCardUnlock(this.Data.CurCardId.Value),
				ShowUnlockRedDotWhenCanUnlock = true
			};
			ControllerBase<PhantomArenaController>.Instance.UpdateCardDetailLockState(context);
		}

		// Token: 0x0603762B RID: 226859 RVA: 0x00E0DF17 File Offset: 0x00E0C117
		protected void RefreshCardItemLockState()
		{
			this.CardItem.RefreshIsLocked();
		}

		// Token: 0x0603762C RID: 226860 RVA: 0x00E0DF24 File Offset: 0x00E0C124
		public void RefreshLockState()
		{
			int? curCardId = this.Data.CurCardId;
			if (curCardId == null)
			{
				return;
			}
			this.Data.IsUnlock = new bool?(this.IsCardUnlock(curCardId.Value));
			this.Data.CardItemData.IsLock = !this.Data.IsUnlock.Value;
			this.RefreshDetailLockState();
			this.RefreshCardItemLockState();
			this.RefreshDeckSlotsPanel();
		}

		// Token: 0x0603762D RID: 226861 RVA: 0x00E0DF9C File Offset: 0x00E0C19C
		private void OnUnlockCardBtnClick(int _)
		{
			ControllerBase<PhantomArenaController>.Instance.CardUnlockRequest(this.Data.CurCardId.Value, null);
		}

		// Token: 0x0603762E RID: 226862 RVA: 0x00E0DFC7 File Offset: 0x00E0C1C7
		private void OnCoreSlotItemToggleStateChange(DeckBuilderCardSlotItem item, EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.SelectCoreCardSlot();
			}
		}

		// Token: 0x0603762F RID: 226863 RVA: 0x00E0DFD4 File Offset: 0x00E0C1D4
		private bool CanCoreSlotItemToggleChange(DeckBuilderCardSlotItem item)
		{
			return true;
		}

		// Token: 0x06037630 RID: 226864 RVA: 0x00E0DFD7 File Offset: 0x00E0C1D7
		private void OnFieldSlotItemToggleStateChange(DeckBuilderCardSlotItem item, EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.SelectFieldCardSlot();
			}
		}

		// Token: 0x06037631 RID: 226865 RVA: 0x00E0DFE4 File Offset: 0x00E0C1E4
		private bool CanFieldSlotItemToggleChange(DeckBuilderCardSlotItem item)
		{
			return true;
		}

		// Token: 0x06037632 RID: 226866 RVA: 0x00E0DFE7 File Offset: 0x00E0C1E7
		private void OnNormalSlotItemToggleStateChange(DeckBuilderCardSlotItem item, EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.SelectNormalCardSlotByIndex(item.GridIndex);
			}
		}

		// Token: 0x06037633 RID: 226867 RVA: 0x00E0DFF9 File Offset: 0x00E0C1F9
		private bool CanNormalSlotItemToggleChange(DeckBuilderCardSlotItem item)
		{
			return true;
		}

		// Token: 0x06037634 RID: 226868 RVA: 0x00E0DFFC File Offset: 0x00E0C1FC
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06037635 RID: 226869 RVA: 0x00E0E008 File Offset: 0x00E0C208
		private void OnConfirmBtnClick(int _)
		{
			bool flag = false;
			DeckInfo deckInfo = this.Data.DeckInfo.DeepCopy();
			deckInfo.RemoveAllCard();
			foreach (DeckCardSlotInfo deckCardSlotInfo in this.Data.DeckInfo.GetCardSlotList())
			{
				if (!ModelBase<PhantomArenaModel>.Instance.IsCardUnlock(deckCardSlotInfo.CardId))
				{
					flag = true;
				}
				else
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
					deckInfo.AddCard(context);
				}
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(flag ? EConfirmBoxConfigId.PhantomArenaRecommendDeckCardInsufficientConfirm : EConfirmBoxConfigId.PhantomArenaApplyRecommendDeckConfirm);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.Data.SaveRecommendDeckCallback(deckInfo);
				this.CloseMe(null);
			};
			bool isNew = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(this.Data.ActivityId);
			ControllerBase<PhantomArenaController>.Instance.OpenPhantomArenaConfirmBoxView(confirmBoxDataNew, isNew);
		}

		// Token: 0x06037636 RID: 226870 RVA: 0x00E0E160 File Offset: 0x00E0C360
		private void OnPhantomArenaCardUnlock(int cardId)
		{
			this.RefreshLockState();
		}

		// Token: 0x06037637 RID: 226871 RVA: 0x00E0E168 File Offset: 0x00E0C368
		public void ShowEntry()
		{
			if (this.IsEntryShow)
			{
				return;
			}
			this.IsEntryShow = true;
			LevelSequencePlayer tipLevelSequencePlayer = this.TipLevelSequencePlayer;
			if (tipLevelSequencePlayer != null)
			{
				tipLevelSequencePlayer.PlayOrReplaySequenceByName("TipsShow", false, null);
			}
			this.RefreshEntryShowState();
		}

		// Token: 0x06037638 RID: 226872 RVA: 0x00E0E1AC File Offset: 0x00E0C3AC
		public void HideEntry()
		{
			if (!this.IsEntryShow)
			{
				return;
			}
			this.IsEntryShow = false;
			LevelSequencePlayer tipLevelSequencePlayer = this.TipLevelSequencePlayer;
			if (tipLevelSequencePlayer == null)
			{
				return;
			}
			tipLevelSequencePlayer.PlayOrReplaySequenceByName("TipsHide", false, null);
		}

		// Token: 0x06037639 RID: 226873 RVA: 0x00E0E1E8 File Offset: 0x00E0C3E8
		public void RefreshEntryShowState()
		{
			base.GetItem(4).SetUIActive(this.IsEntryShow);
			base.GetItem(10).SetUIActive(this.IsEntryShow);
			base.GetItem(11).SetUIActive(this.IsEntryShow);
		}

		// Token: 0x0603763A RID: 226874 RVA: 0x00E0E222 File Offset: 0x00E0C422
		private void OnSeqEnd(string seqName)
		{
			if (seqName == "TipsHide".ToString())
			{
				this.RefreshEntryShowState();
			}
		}

		// Token: 0x0603763B RID: 226875 RVA: 0x00E0E23C File Offset: 0x00E0C43C
		private void ShowMaskButton()
		{
			base.GetButton(16).RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x0603763C RID: 226876 RVA: 0x00E0E264 File Offset: 0x00E0C464
		private void HideMaskButton()
		{
			base.GetButton(16).RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x0603763D RID: 226877 RVA: 0x00E0E28C File Offset: 0x00E0C48C
		private void OnCardDescBtnClick()
		{
			this.ShowEntry();
			this.ShowMaskButton();
		}

		// Token: 0x0603763E RID: 226878 RVA: 0x00E0E29A File Offset: 0x00E0C49A
		private void OnMaskBtnClick()
		{
			this.HideEntry();
			this.HideMaskButton();
		}

		// Token: 0x0401FCCD RID: 130253
		private IPhantomArenaDeckDetailViewData Data;

		// Token: 0x0401FCCE RID: 130254
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401FCCF RID: 130255
		private DetailViewCardItem CardItem;

		// Token: 0x0401FCD0 RID: 130256
		private CardDetailItem DetailItem;

		// Token: 0x0401FCD1 RID: 130257
		private CardDetailEntryDescLayoutItem EntryDescLayoutItem;

		// Token: 0x0401FCD2 RID: 130258
		private DeckBuilderDeckSlotsPanel DeckSlotsPanel;

		// Token: 0x0401FCD3 RID: 130259
		private ButtonItem UnlockBtnItem;

		// Token: 0x0401FCD4 RID: 130260
		private ButtonItem ConfirmBtnItem;

		// Token: 0x0401FCD5 RID: 130261
		private LevelSequencePlayer TipLevelSequencePlayer;

		// Token: 0x0401FCD6 RID: 130262
		private bool IsEntryShow;

		// Token: 0x0200B460 RID: 46176
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037D5E RID: 228702
			public const int CaptionItem = 0;

			// Token: 0x04037D5F RID: 228703
			public const int DeckSlotsPanelItem = 1;

			// Token: 0x04037D60 RID: 228704
			public const int CardItem = 2;

			// Token: 0x04037D61 RID: 228705
			public const int DetailItem = 3;

			// Token: 0x04037D62 RID: 228706
			public const int EntryRootItem = 4;

			// Token: 0x04037D63 RID: 228707
			public const int EntryDescLayout = 5;

			// Token: 0x04037D64 RID: 228708
			public const int EntryDescLayoutItem = 6;

			// Token: 0x04037D65 RID: 228709
			public const int UnlockBtnItem = 7;

			// Token: 0x04037D66 RID: 228710
			public const int ConfirmBtnItem = 8;

			// Token: 0x04037D67 RID: 228711
			public const int TipText = 9;

			// Token: 0x04037D68 RID: 228712
			public const int EntryBgItem = 10;

			// Token: 0x04037D69 RID: 228713
			public const int EntryLineItem = 11;

			// Token: 0x04037D6A RID: 228714
			public const int CardDescBtn = 12;

			// Token: 0x04037D6B RID: 228715
			public const int CardAndDetailRootItem = 13;

			// Token: 0x04037D6C RID: 228716
			public const int LockTipItem = 14;

			// Token: 0x04037D6D RID: 228717
			public const int LockTipText = 15;

			// Token: 0x04037D6E RID: 228718
			public const int MaskButton = 16;
		}
	}
}
