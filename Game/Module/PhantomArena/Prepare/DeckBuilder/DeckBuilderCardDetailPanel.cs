using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardDetail;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054ED RID: 21741
	[NullableContext(2)]
	[Nullable(0)]
	public class DeckBuilderCardDetailPanel : UiPanelBase, IDeckBuilderCardInfoViewPanelSequencePlayer
	{
		// Token: 0x06037669 RID: 226921 RVA: 0x00E0E6B4 File Offset: 0x00E0C8B4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText))
			};
		}

		// Token: 0x0603766A RID: 226922 RVA: 0x00E0E77C File Offset: 0x00E0C97C
		protected override UniTask OnBeforeStartAsync()
		{
			DeckBuilderCardDetailPanel.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DeckBuilderCardDetailPanel.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603766B RID: 226923 RVA: 0x00E0E7C0 File Offset: 0x00E0C9C0
		[NullableContext(1)]
		public void Refresh(IDeckBuilderCardDetailPanelData data)
		{
			this.Data = data;
			this.RefreshDetailLockState();
			this.CardItem.Refresh(data.CardItemData);
			this.DetailItem.Refresh(this.Data.DetailItemData);
			this.EntryDescLayoutItem.Refresh(this.Data.EntryIdList.ToList<int>());
		}

		// Token: 0x0603766C RID: 226924 RVA: 0x00E0E81C File Offset: 0x00E0CA1C
		protected void RefreshDetailLockState()
		{
			IDeckBuilderCardDetailPanelData data = this.Data;
			if (((data != null) ? data.DeckInfo : null) == null)
			{
				this.LeftBtnItem.SetActive(false);
				this.RightBtnItem.SetActive(false);
				base.GetText(5).SetUIActive(false);
				base.GetItem(6).SetUIActive(false);
				return;
			}
			if (this.Data.IsCardUnlocked)
			{
				this.LeftBtnItem.SetActive(true);
				this.LeftBtnItem.SetFunction(new Action<int>(this.OnRemoveCardBtnClick));
				this.LeftBtnItem.SetLocalTextNew("PhantomBattle_1007", Array.Empty<object>());
				this.RightBtnItem.SetActive(true);
				this.RightBtnItem.SetFunction(new Action<int>(this.OnAddCardBtnClick));
				this.RightBtnItem.SetLocalTextNew("PhantomBattle_1008", Array.Empty<object>());
				base.GetText(5).SetUIActive(true);
				base.GetItem(6).SetUIActive(false);
				DeckInfo deckInfo = this.Data.DeckInfo;
				int cardId = this.GetCardId();
				int cardCount = deckInfo.GetCardCount(cardId);
				int num = this.Data.CardLimit.Value - cardCount;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "PhantomBattle_1009", new <>z__ReadOnlySingleElementList<object>(num));
				bool enableClick = cardCount > 0;
				this.LeftBtnItem.SetEnableClick(enableClick);
				bool enableClick2 = num > 0;
				this.RightBtnItem.SetEnableClick(enableClick2);
				return;
			}
			this.RightBtnItem.SetFunction(new Action<int>(this.OnUnlockCardBtnClick));
			this.LeftBtnItem.SetActive(false);
			UpdateCardDetailLockStateContext context = new UpdateCardDetailLockStateContext
			{
				CardId = this.GetCardId(),
				LockTipItem = base.GetItem(6),
				LockTipText = base.GetText(7),
				TipText = base.GetText(5),
				UnlockBtnItem = this.RightBtnItem,
				IsUnLocked = ModelBase<PhantomArenaModel>.Instance.IsCardUnlock(this.GetCardId()),
				ShowUnlockRedDotWhenCanUnlock = false
			};
			ControllerBase<PhantomArenaController>.Instance.UpdateCardDetailLockState(context);
		}

		// Token: 0x0603766D RID: 226925 RVA: 0x00E0EA12 File Offset: 0x00E0CC12
		protected void RefreshCardItemLockState()
		{
			this.CardItem.RefreshIsLocked();
		}

		// Token: 0x0603766E RID: 226926 RVA: 0x00E0EA1F File Offset: 0x00E0CC1F
		public void RefreshLockState()
		{
			this.RefreshDetailLockState();
			this.RefreshCardItemLockState();
		}

		// Token: 0x0603766F RID: 226927 RVA: 0x00E0EA2D File Offset: 0x00E0CC2D
		private void OnAddCardBtnClick(int _)
		{
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.AddCardToDeck == null)
			{
				return;
			}
			this.Data.AddCardToDeck();
			this.RefreshDetailLockState();
		}

		// Token: 0x06037670 RID: 226928 RVA: 0x00E0EA5C File Offset: 0x00E0CC5C
		private void OnRemoveCardBtnClick(int _)
		{
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.RemoveCardFromDeck == null)
			{
				return;
			}
			Action removeCardFromDeck = this.Data.RemoveCardFromDeck;
			if (removeCardFromDeck != null)
			{
				removeCardFromDeck();
			}
			this.RefreshDetailLockState();
		}

		// Token: 0x06037671 RID: 226929 RVA: 0x00E0EA91 File Offset: 0x00E0CC91
		private void OnUnlockCardBtnClick(int _)
		{
			ControllerBase<PhantomArenaController>.Instance.CardUnlockRequest(this.GetCardId(), null);
		}

		// Token: 0x06037672 RID: 226930 RVA: 0x00E0EAA4 File Offset: 0x00E0CCA4
		public void PlaySwitchSequence()
		{
			this.SequencePlayer.PlayOrReplaySequenceByName("Switch", false, null);
		}

		// Token: 0x06037673 RID: 226931 RVA: 0x00E0EACC File Offset: 0x00E0CCCC
		public void PlayShowSequence()
		{
			this.SequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
		}

		// Token: 0x06037674 RID: 226932 RVA: 0x00E0EAF3 File Offset: 0x00E0CCF3
		public int GetCardId()
		{
			return this.Data.CardItemData.CardId;
		}

		// Token: 0x06037675 RID: 226933 RVA: 0x00E0EB08 File Offset: 0x00E0CD08
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
			UUIItem guideUiItem = base.GetGuideUiItem("0");
			if (guideUiItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				guideUiItem,
				guideUiItem
			};
		}

		// Token: 0x0401FCE2 RID: 130274
		private IDeckBuilderCardDetailPanelData Data;

		// Token: 0x0401FCE3 RID: 130275
		public bool IsNewPhantomArenaActivity;

		// Token: 0x0401FCE4 RID: 130276
		private DetailViewCardItem CardItem;

		// Token: 0x0401FCE5 RID: 130277
		private CardDetailItem DetailItem;

		// Token: 0x0401FCE6 RID: 130278
		private CardDetailEntryDescLayoutItem EntryDescLayoutItem;

		// Token: 0x0401FCE7 RID: 130279
		private ButtonItem LeftBtnItem;

		// Token: 0x0401FCE8 RID: 130280
		private ButtonItem RightBtnItem;

		// Token: 0x0401FCE9 RID: 130281
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0200B467 RID: 46183
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037D85 RID: 228741
			public const int CardItem = 0;

			// Token: 0x04037D86 RID: 228742
			public const int DetailItem = 1;

			// Token: 0x04037D87 RID: 228743
			public const int EntryDescLayout = 2;

			// Token: 0x04037D88 RID: 228744
			public const int LeftBtnItem = 3;

			// Token: 0x04037D89 RID: 228745
			public const int RightBtnItem = 4;

			// Token: 0x04037D8A RID: 228746
			public const int TipText = 5;

			// Token: 0x04037D8B RID: 228747
			public const int LockTipItem = 6;

			// Token: 0x04037D8C RID: 228748
			public const int LockTipText = 7;
		}
	}
}
