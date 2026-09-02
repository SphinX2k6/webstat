using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardDetail;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Collect
{
	// Token: 0x02005513 RID: 21779
	[NullableContext(1)]
	[Nullable(0)]
	public class CollectCardDetailPanel : UiPanelBase
	{
		// Token: 0x060378E8 RID: 227560 RVA: 0x00E183B4 File Offset: 0x00E165B4
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

		// Token: 0x060378E9 RID: 227561 RVA: 0x00E1847C File Offset: 0x00E1667C
		protected override UniTask OnBeforeStartAsync()
		{
			CollectCardDetailPanel.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CollectCardDetailPanel.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060378EA RID: 227562 RVA: 0x00E184BF File Offset: 0x00E166BF
		protected override void OnStart()
		{
			this.BtnUnlock.SetFunction(new Action<int>(this.OnClickUnlock));
		}

		// Token: 0x060378EB RID: 227563 RVA: 0x00E184D8 File Offset: 0x00E166D8
		public void Refresh(int cardId)
		{
			this.CardId = cardId;
			this.RefreshCard();
			this.RefreshDetail();
			this.RefreshEntry();
			this.RefreshBtn();
		}

		// Token: 0x060378EC RID: 227564 RVA: 0x00E184FC File Offset: 0x00E166FC
		private void RefreshCard()
		{
			DetailViewCardItemData detailViewCardData = ModelBase<PhantomArenaModel>.Instance.GetDetailViewCardData(this.CardId);
			this.CardItem.Refresh(detailViewCardData);
		}

		// Token: 0x060378ED RID: 227565 RVA: 0x00E18528 File Offset: 0x00E16728
		private void RefreshDetail()
		{
			CardDetailItemData detailViewDetailItemData = ModelBase<PhantomArenaModel>.Instance.GetDetailViewDetailItemData(this.CardId, null);
			this.DetailItem.Refresh(detailViewDetailItemData);
		}

		// Token: 0x060378EE RID: 227566 RVA: 0x00E18554 File Offset: 0x00E16754
		private void RefreshEntry()
		{
			List<int> detailViewEntryData = ModelBase<PhantomArenaModel>.Instance.GetDetailViewEntryData(this.CardId);
			this.EntryItem.Refresh(detailViewEntryData);
		}

		// Token: 0x060378EF RID: 227567 RVA: 0x00E18580 File Offset: 0x00E16780
		private void RefreshBtn()
		{
			UpdateCardDetailLockStateContext context = new UpdateCardDetailLockStateContext
			{
				CardId = this.CardId,
				LockTipItem = base.GetItem(6),
				LockTipText = base.GetText(7),
				TipText = base.GetText(5),
				UnlockBtnItem = this.BtnUnlock,
				IsUnLocked = ModelBase<PhantomArenaModel>.Instance.IsCardUnlock(this.CardId),
				ShowUnlockRedDotWhenCanUnlock = false
			};
			ControllerBase<PhantomArenaController>.Instance.UpdateCardDetailLockState(context);
			this.BtnConfirm.SetActive(false);
		}

		// Token: 0x060378F0 RID: 227568 RVA: 0x00E18606 File Offset: 0x00E16806
		private void OnClickUnlock(int _)
		{
			ControllerBase<PhantomArenaController>.Instance.CardUnlockRequest(this.CardId, null);
		}

		// Token: 0x060378F1 RID: 227569 RVA: 0x00E1861C File Offset: 0x00E1681C
		public void PlaySwitchSequence()
		{
			this.SequencePlayer.PlayOrReplaySequenceByName("Switch", false, null);
		}

		// Token: 0x060378F2 RID: 227570 RVA: 0x00E18644 File Offset: 0x00E16844
		public void PlayShowSequence()
		{
			this.SequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
		}

		// Token: 0x0401FDBF RID: 130495
		private int CardId = -1;

		// Token: 0x0401FDC0 RID: 130496
		public bool IsNewPhantomArenaActivity;

		// Token: 0x0401FDC1 RID: 130497
		private ButtonItem BtnConfirm;

		// Token: 0x0401FDC2 RID: 130498
		private ButtonItem BtnUnlock;

		// Token: 0x0401FDC3 RID: 130499
		private DetailViewCardItem CardItem;

		// Token: 0x0401FDC4 RID: 130500
		private CardDetailItem DetailItem;

		// Token: 0x0401FDC5 RID: 130501
		private CardDetailEntryDescLayoutItem EntryItem;

		// Token: 0x0401FDC6 RID: 130502
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0200B4A2 RID: 46242
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037EA7 RID: 229031
			public const int CardItem = 0;

			// Token: 0x04037EA8 RID: 229032
			public const int DetailItem = 1;

			// Token: 0x04037EA9 RID: 229033
			public const int EntryDescLayout = 2;

			// Token: 0x04037EAA RID: 229034
			public const int LeftBtnItem = 3;

			// Token: 0x04037EAB RID: 229035
			public const int RightBtnItem = 4;

			// Token: 0x04037EAC RID: 229036
			public const int TipText = 5;

			// Token: 0x04037EAD RID: 229037
			public const int LockTipItem = 6;

			// Token: 0x04037EAE RID: 229038
			public const int LockTipText = 7;
		}
	}
}
