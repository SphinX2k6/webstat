using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Area.Hand
{
	// Token: 0x0200562D RID: 22061
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaHandArea : UiPanelBase
	{
		// Token: 0x060383AB RID: 230315 RVA: 0x00E3CDD2 File Offset: 0x00E3AFD2
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout))
			};
		}

		// Token: 0x060383AC RID: 230316 RVA: 0x00E3CDF8 File Offset: 0x00E3AFF8
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Layout = base.GetHorizontalLayout(0);
			this.Layout.bUseOriginalChildrenOrder = true;
			this.OriginalSpace = this.Layout.GetSpacing();
			Transform itemWorldTrans = this.ItemWorldTrans;
			FTransform ftransform = this.RootItem.K2_GetComponentToWorld();
			itemWorldTrans.FromUeTransform(ftransform);
			this.OriginalOffset = this.RootItem.GetAnchorOffsetY();
			this.TotalWidth = this.Layout.RootUIComp.Get().GetWidth();
			this.TotalHeight = this.Layout.RootUIComp.Get().GetHeight();
		}

		// Token: 0x060383AD RID: 230317 RVA: 0x00E3CEA6 File Offset: 0x00E3B0A6
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x060383AE RID: 230318 RVA: 0x00E3CEB4 File Offset: 0x00E3B0B4
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<PhantomArenaHandAreaItem> CreateAreaItem()
		{
			PhantomArenaHandArea.<CreateAreaItem>d__17 <CreateAreaItem>d__;
			<CreateAreaItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<PhantomArenaHandAreaItem>.Create();
			<CreateAreaItem>d__.<>4__this = this;
			<CreateAreaItem>d__.<>1__state = -1;
			<CreateAreaItem>d__.<>t__builder.Start<PhantomArenaHandArea.<CreateAreaItem>d__17>(ref <CreateAreaItem>d__);
			return <CreateAreaItem>d__.<>t__builder.Task;
		}

		// Token: 0x060383AF RID: 230319 RVA: 0x00E3CEF8 File Offset: 0x00E3B0F8
		private void CalculateLayoutSpace()
		{
			float num = this.OriginalSpace;
			float num2 = 6f * this.GridWidth + 5f * this.OriginalSpace;
			if (this.CardMap.Count > 6)
			{
				num = (num2 - (float)this.CardMap.Count * this.GridWidth) / (float)(this.CardMap.Count - 1);
			}
			this.Layout.SetSpacing(num);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[CalculateLayoutSpace]";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Space", num);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x060383B0 RID: 230320 RVA: 0x00E3CF94 File Offset: 0x00E3B194
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<PhantomArenaCard> AddCardById(int cardId)
		{
			PhantomArenaHandArea.<AddCardById>d__19 <AddCardById>d__;
			<AddCardById>d__.<>t__builder = AsyncUniTaskMethodBuilder<PhantomArenaCard>.Create();
			<AddCardById>d__.<>4__this = this;
			<AddCardById>d__.cardId = cardId;
			<AddCardById>d__.<>1__state = -1;
			<AddCardById>d__.<>t__builder.Start<PhantomArenaHandArea.<AddCardById>d__19>(ref <AddCardById>d__);
			return <AddCardById>d__.<>t__builder.Task;
		}

		// Token: 0x060383B1 RID: 230321 RVA: 0x00E3CFE0 File Offset: 0x00E3B1E0
		private UniTask AddCardByCard(PhantomArenaCard card)
		{
			PhantomArenaHandArea.<AddCardByCard>d__20 <AddCardByCard>d__;
			<AddCardByCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AddCardByCard>d__.<>4__this = this;
			<AddCardByCard>d__.card = card;
			<AddCardByCard>d__.<>1__state = -1;
			<AddCardByCard>d__.<>t__builder.Start<PhantomArenaHandArea.<AddCardByCard>d__20>(ref <AddCardByCard>d__);
			return <AddCardByCard>d__.<>t__builder.Task;
		}

		// Token: 0x060383B2 RID: 230322 RVA: 0x00E3D02C File Offset: 0x00E3B22C
		private UniTask InitCardList()
		{
			PhantomArenaHandArea.<InitCardList>d__21 <InitCardList>d__;
			<InitCardList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCardList>d__.<>4__this = this;
			<InitCardList>d__.<>1__state = -1;
			<InitCardList>d__.<>t__builder.Start<PhantomArenaHandArea.<InitCardList>d__21>(ref <InitCardList>d__);
			return <InitCardList>d__.<>t__builder.Task;
		}

		// Token: 0x060383B3 RID: 230323 RVA: 0x00E3D070 File Offset: 0x00E3B270
		private UniTask AddCardList(List<int> cardIdList)
		{
			PhantomArenaHandArea.<AddCardList>d__22 <AddCardList>d__;
			<AddCardList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AddCardList>d__.<>4__this = this;
			<AddCardList>d__.cardIdList = cardIdList;
			<AddCardList>d__.<>1__state = -1;
			<AddCardList>d__.<>t__builder.Start<PhantomArenaHandArea.<AddCardList>d__22>(ref <AddCardList>d__);
			return <AddCardList>d__.<>t__builder.Task;
		}

		// Token: 0x060383B4 RID: 230324 RVA: 0x00E3D0BC File Offset: 0x00E3B2BC
		private UniTask PlayFirstTimeDrawCardTween(UUIItem fromItem)
		{
			PhantomArenaHandArea.<PlayFirstTimeDrawCardTween>d__23 <PlayFirstTimeDrawCardTween>d__;
			<PlayFirstTimeDrawCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayFirstTimeDrawCardTween>d__.<>4__this = this;
			<PlayFirstTimeDrawCardTween>d__.fromItem = fromItem;
			<PlayFirstTimeDrawCardTween>d__.<>1__state = -1;
			<PlayFirstTimeDrawCardTween>d__.<>t__builder.Start<PhantomArenaHandArea.<PlayFirstTimeDrawCardTween>d__23>(ref <PlayFirstTimeDrawCardTween>d__);
			return <PlayFirstTimeDrawCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383B5 RID: 230325 RVA: 0x00E3D108 File Offset: 0x00E3B308
		private UniTask PlayOtherTimeDrawCardTween(UUIItem fromItem)
		{
			PhantomArenaHandArea.<PlayOtherTimeDrawCardTween>d__24 <PlayOtherTimeDrawCardTween>d__;
			<PlayOtherTimeDrawCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayOtherTimeDrawCardTween>d__.<>4__this = this;
			<PlayOtherTimeDrawCardTween>d__.fromItem = fromItem;
			<PlayOtherTimeDrawCardTween>d__.<>1__state = -1;
			<PlayOtherTimeDrawCardTween>d__.<>t__builder.Start<PhantomArenaHandArea.<PlayOtherTimeDrawCardTween>d__24>(ref <PlayOtherTimeDrawCardTween>d__);
			return <PlayOtherTimeDrawCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383B6 RID: 230326 RVA: 0x00E3D154 File Offset: 0x00E3B354
		private UniTask PlayStartTimeDrawCardTween(UUIItem fromItem)
		{
			PhantomArenaHandArea.<PlayStartTimeDrawCardTween>d__25 <PlayStartTimeDrawCardTween>d__;
			<PlayStartTimeDrawCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartTimeDrawCardTween>d__.<>4__this = this;
			<PlayStartTimeDrawCardTween>d__.fromItem = fromItem;
			<PlayStartTimeDrawCardTween>d__.<>1__state = -1;
			<PlayStartTimeDrawCardTween>d__.<>t__builder.Start<PhantomArenaHandArea.<PlayStartTimeDrawCardTween>d__25>(ref <PlayStartTimeDrawCardTween>d__);
			return <PlayStartTimeDrawCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383B7 RID: 230327 RVA: 0x00E3D1A0 File Offset: 0x00E3B3A0
		private UniTask PlayEndTimeDiscardCardTween(UUIItem toItem)
		{
			PhantomArenaHandArea.<PlayEndTimeDiscardCardTween>d__26 <PlayEndTimeDiscardCardTween>d__;
			<PlayEndTimeDiscardCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayEndTimeDiscardCardTween>d__.<>4__this = this;
			<PlayEndTimeDiscardCardTween>d__.toItem = toItem;
			<PlayEndTimeDiscardCardTween>d__.<>1__state = -1;
			<PlayEndTimeDiscardCardTween>d__.<>t__builder.Start<PhantomArenaHandArea.<PlayEndTimeDiscardCardTween>d__26>(ref <PlayEndTimeDiscardCardTween>d__);
			return <PlayEndTimeDiscardCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383B8 RID: 230328 RVA: 0x00E3D1EC File Offset: 0x00E3B3EC
		private UniTask PlayDiscardCardTween(UUIItem toItem, List<int> discardIdList)
		{
			PhantomArenaHandArea.<PlayDiscardCardTween>d__27 <PlayDiscardCardTween>d__;
			<PlayDiscardCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayDiscardCardTween>d__.<>4__this = this;
			<PlayDiscardCardTween>d__.toItem = toItem;
			<PlayDiscardCardTween>d__.discardIdList = discardIdList;
			<PlayDiscardCardTween>d__.<>1__state = -1;
			<PlayDiscardCardTween>d__.<>t__builder.Start<PhantomArenaHandArea.<PlayDiscardCardTween>d__27>(ref <PlayDiscardCardTween>d__);
			return <PlayDiscardCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383B9 RID: 230329 RVA: 0x00E3D240 File Offset: 0x00E3B440
		private UniTask PlayAddCardTween(UUIItem fromItem, List<int> cardIdList)
		{
			PhantomArenaHandArea.<PlayAddCardTween>d__28 <PlayAddCardTween>d__;
			<PlayAddCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAddCardTween>d__.<>4__this = this;
			<PlayAddCardTween>d__.fromItem = fromItem;
			<PlayAddCardTween>d__.cardIdList = cardIdList;
			<PlayAddCardTween>d__.<>1__state = -1;
			<PlayAddCardTween>d__.<>t__builder.Start<PhantomArenaHandArea.<PlayAddCardTween>d__28>(ref <PlayAddCardTween>d__);
			return <PlayAddCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383BA RID: 230330 RVA: 0x00E3D294 File Offset: 0x00E3B494
		private UniTask PlayRecycleCardTween(List<int> cardIdList)
		{
			PhantomArenaHandArea.<PlayRecycleCardTween>d__29 <PlayRecycleCardTween>d__;
			<PlayRecycleCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayRecycleCardTween>d__.<>4__this = this;
			<PlayRecycleCardTween>d__.cardIdList = cardIdList;
			<PlayRecycleCardTween>d__.<>1__state = -1;
			<PlayRecycleCardTween>d__.<>t__builder.Start<PhantomArenaHandArea.<PlayRecycleCardTween>d__29>(ref <PlayRecycleCardTween>d__);
			return <PlayRecycleCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383BB RID: 230331 RVA: 0x00E3D2E0 File Offset: 0x00E3B4E0
		private UniTask PlayResetCardTween(int cardId)
		{
			PhantomArenaHandArea.<PlayResetCardTween>d__30 <PlayResetCardTween>d__;
			<PlayResetCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayResetCardTween>d__.<>4__this = this;
			<PlayResetCardTween>d__.cardId = cardId;
			<PlayResetCardTween>d__.<>1__state = -1;
			<PlayResetCardTween>d__.<>t__builder.Start<PhantomArenaHandArea.<PlayResetCardTween>d__30>(ref <PlayResetCardTween>d__);
			return <PlayResetCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383BC RID: 230332 RVA: 0x00E3D32C File Offset: 0x00E3B52C
		private UniTask PlayHandCardToFunctionalTopTween(int cardId, UUIItem toItem, bool needDragUpTween)
		{
			PhantomArenaHandArea.<PlayHandCardToFunctionalTopTween>d__31 <PlayHandCardToFunctionalTopTween>d__;
			<PlayHandCardToFunctionalTopTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayHandCardToFunctionalTopTween>d__.<>4__this = this;
			<PlayHandCardToFunctionalTopTween>d__.cardId = cardId;
			<PlayHandCardToFunctionalTopTween>d__.toItem = toItem;
			<PlayHandCardToFunctionalTopTween>d__.needDragUpTween = needDragUpTween;
			<PlayHandCardToFunctionalTopTween>d__.<>1__state = -1;
			<PlayHandCardToFunctionalTopTween>d__.<>t__builder.Start<PhantomArenaHandArea.<PlayHandCardToFunctionalTopTween>d__31>(ref <PlayHandCardToFunctionalTopTween>d__);
			return <PlayHandCardToFunctionalTopTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383BD RID: 230333 RVA: 0x00E3D388 File Offset: 0x00E3B588
		public bool CheckCardOutHandArea(PhantomArenaCard card)
		{
			this.TempCardPos.FromUeVector(card.GetWorldLocation());
			this.ItemWorldTrans.InverseTransformPosition(this.TempCardPos, this.TempCardPos);
			return this.TempCardPos.Y - (double)card.HalfHeight > (double)this.TotalHeight || this.TempCardPos.Y + (double)card.HalfHeight < 0.0 || this.TempCardPos.X + (double)card.HalfWidth < (double)(-(double)this.TotalWidth / 2f) || this.TempCardPos.X - (double)card.HalfWidth > (double)(this.TotalWidth / 2f);
		}

		// Token: 0x060383BE RID: 230334 RVA: 0x00E3D445 File Offset: 0x00E3B645
		public void RegisterBattleArea(PhantomArenaOwnArea area)
		{
			this.Area = area;
		}

		// Token: 0x060383BF RID: 230335 RVA: 0x00E3D450 File Offset: 0x00E3B650
		public UniTask DestroyCardByLibrary(int cardId)
		{
			PhantomArenaHandArea.<DestroyCardByLibrary>d__34 <DestroyCardByLibrary>d__;
			<DestroyCardByLibrary>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DestroyCardByLibrary>d__.<>4__this = this;
			<DestroyCardByLibrary>d__.cardId = cardId;
			<DestroyCardByLibrary>d__.<>1__state = -1;
			<DestroyCardByLibrary>d__.<>t__builder.Start<PhantomArenaHandArea.<DestroyCardByLibrary>d__34>(ref <DestroyCardByLibrary>d__);
			return <DestroyCardByLibrary>d__.<>t__builder.Task;
		}

		// Token: 0x060383C0 RID: 230336 RVA: 0x00E3D49C File Offset: 0x00E3B69C
		public void HoistLayout()
		{
			if (this.IsLayoutHoist)
			{
				return;
			}
			this.IsLayoutHoist = true;
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequencePurely("Up", false, false);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPhantomArenaHandCardsShowHideChange, true);
		}

		// Token: 0x060383C1 RID: 230337 RVA: 0x00E3D4EC File Offset: 0x00E3B6EC
		public void LowerLayout()
		{
			if (!this.IsLayoutHoist)
			{
				return;
			}
			this.IsLayoutHoist = false;
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequencePurely("Down", false, false);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPhantomArenaHandCardsShowHideChange, false);
		}

		// Token: 0x060383C2 RID: 230338 RVA: 0x00E3D539 File Offset: 0x00E3B739
		public void SwitchLayoutHoist()
		{
			if (this.IsLayoutHoist)
			{
				this.LowerLayout();
				return;
			}
			this.HoistLayout();
		}

		// Token: 0x060383C3 RID: 230339 RVA: 0x00E3D550 File Offset: 0x00E3B750
		public PhantomArenaHandCardProxy GetCardProxy(int cardId)
		{
			if (!this.CardMap.ContainsKey(cardId))
			{
				return null;
			}
			return this.CardMap[cardId];
		}

		// Token: 0x060383C4 RID: 230340 RVA: 0x00E3D570 File Offset: 0x00E3B770
		public PhantomArenaHandCardProxy GetCardProxyByIndex(int index)
		{
			if (index < 0 || index >= this.CardMap.Count)
			{
				return null;
			}
			int num = 0;
			foreach (PhantomArenaHandCardProxy result in this.CardMap.Values)
			{
				if (num == index)
				{
					return result;
				}
				num++;
			}
			return null;
		}

		// Token: 0x060383C5 RID: 230341 RVA: 0x00E3D5E8 File Offset: 0x00E3B7E8
		public void RefreshHandCardSequence()
		{
			foreach (PhantomArenaHandCardProxy phantomArenaHandCardProxy in this.CardMap.Values)
			{
				if (phantomArenaHandCardProxy.IsInit && !phantomArenaHandCardProxy.CheckCardOutHandArea())
				{
					phantomArenaHandCardProxy.PlayInHandSequence();
				}
			}
		}

		// Token: 0x060383C6 RID: 230342 RVA: 0x00E3D650 File Offset: 0x00E3B850
		public UniTask StartTimeDrawCard(UUIItem fromItem)
		{
			PhantomArenaHandArea.<StartTimeDrawCard>d__41 <StartTimeDrawCard>d__;
			<StartTimeDrawCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartTimeDrawCard>d__.<>4__this = this;
			<StartTimeDrawCard>d__.fromItem = fromItem;
			<StartTimeDrawCard>d__.<>1__state = -1;
			<StartTimeDrawCard>d__.<>t__builder.Start<PhantomArenaHandArea.<StartTimeDrawCard>d__41>(ref <StartTimeDrawCard>d__);
			return <StartTimeDrawCard>d__.<>t__builder.Task;
		}

		// Token: 0x060383C7 RID: 230343 RVA: 0x00E3D69C File Offset: 0x00E3B89C
		public UniTask EndTimeDiscardCard(UUIItem toItem)
		{
			PhantomArenaHandArea.<EndTimeDiscardCard>d__42 <EndTimeDiscardCard>d__;
			<EndTimeDiscardCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EndTimeDiscardCard>d__.<>4__this = this;
			<EndTimeDiscardCard>d__.toItem = toItem;
			<EndTimeDiscardCard>d__.<>1__state = -1;
			<EndTimeDiscardCard>d__.<>t__builder.Start<PhantomArenaHandArea.<EndTimeDiscardCard>d__42>(ref <EndTimeDiscardCard>d__);
			return <EndTimeDiscardCard>d__.<>t__builder.Task;
		}

		// Token: 0x060383C8 RID: 230344 RVA: 0x00E3D6E8 File Offset: 0x00E3B8E8
		public UniTask DiscardCard(UUIItem toItem, List<int> discardIdList)
		{
			PhantomArenaHandArea.<DiscardCard>d__43 <DiscardCard>d__;
			<DiscardCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DiscardCard>d__.<>4__this = this;
			<DiscardCard>d__.toItem = toItem;
			<DiscardCard>d__.discardIdList = discardIdList;
			<DiscardCard>d__.<>1__state = -1;
			<DiscardCard>d__.<>t__builder.Start<PhantomArenaHandArea.<DiscardCard>d__43>(ref <DiscardCard>d__);
			return <DiscardCard>d__.<>t__builder.Task;
		}

		// Token: 0x060383C9 RID: 230345 RVA: 0x00E3D73C File Offset: 0x00E3B93C
		public UniTask AddCard(List<int> cardIdList)
		{
			PhantomArenaHandArea.<AddCard>d__44 <AddCard>d__;
			<AddCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AddCard>d__.<>4__this = this;
			<AddCard>d__.cardIdList = cardIdList;
			<AddCard>d__.<>1__state = -1;
			<AddCard>d__.<>t__builder.Start<PhantomArenaHandArea.<AddCard>d__44>(ref <AddCard>d__);
			return <AddCard>d__.<>t__builder.Task;
		}

		// Token: 0x060383CA RID: 230346 RVA: 0x00E3D788 File Offset: 0x00E3B988
		public UniTask RecycleCard(List<int> cardIdList)
		{
			PhantomArenaHandArea.<RecycleCard>d__45 <RecycleCard>d__;
			<RecycleCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RecycleCard>d__.<>4__this = this;
			<RecycleCard>d__.cardIdList = cardIdList;
			<RecycleCard>d__.<>1__state = -1;
			<RecycleCard>d__.<>t__builder.Start<PhantomArenaHandArea.<RecycleCard>d__45>(ref <RecycleCard>d__);
			return <RecycleCard>d__.<>t__builder.Task;
		}

		// Token: 0x060383CB RID: 230347 RVA: 0x00E3D7D4 File Offset: 0x00E3B9D4
		public UniTask ResetCardPosition(PhantomArenaCard card)
		{
			PhantomArenaHandArea.<ResetCardPosition>d__46 <ResetCardPosition>d__;
			<ResetCardPosition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResetCardPosition>d__.<>4__this = this;
			<ResetCardPosition>d__.card = card;
			<ResetCardPosition>d__.<>1__state = -1;
			<ResetCardPosition>d__.<>t__builder.Start<PhantomArenaHandArea.<ResetCardPosition>d__46>(ref <ResetCardPosition>d__);
			return <ResetCardPosition>d__.<>t__builder.Task;
		}

		// Token: 0x060383CC RID: 230348 RVA: 0x00E3D820 File Offset: 0x00E3BA20
		public UniTask RemoveCard(PhantomArenaCard card)
		{
			PhantomArenaHandArea.<RemoveCard>d__47 <RemoveCard>d__;
			<RemoveCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RemoveCard>d__.<>4__this = this;
			<RemoveCard>d__.card = card;
			<RemoveCard>d__.<>1__state = -1;
			<RemoveCard>d__.<>t__builder.Start<PhantomArenaHandArea.<RemoveCard>d__47>(ref <RemoveCard>d__);
			return <RemoveCard>d__.<>t__builder.Task;
		}

		// Token: 0x060383CD RID: 230349 RVA: 0x00E3D86C File Offset: 0x00E3BA6C
		public UniTask FunctionalToHand(PhantomArenaCard card)
		{
			PhantomArenaHandArea.<FunctionalToHand>d__48 <FunctionalToHand>d__;
			<FunctionalToHand>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<FunctionalToHand>d__.<>4__this = this;
			<FunctionalToHand>d__.card = card;
			<FunctionalToHand>d__.<>1__state = -1;
			<FunctionalToHand>d__.<>t__builder.Start<PhantomArenaHandArea.<FunctionalToHand>d__48>(ref <FunctionalToHand>d__);
			return <FunctionalToHand>d__.<>t__builder.Task;
		}

		// Token: 0x060383CE RID: 230350 RVA: 0x00E3D8B8 File Offset: 0x00E3BAB8
		public UniTask HandToRecycle(PhantomArenaCard card)
		{
			PhantomArenaHandArea.<HandToRecycle>d__49 <HandToRecycle>d__;
			<HandToRecycle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandToRecycle>d__.<>4__this = this;
			<HandToRecycle>d__.card = card;
			<HandToRecycle>d__.<>1__state = -1;
			<HandToRecycle>d__.<>t__builder.Start<PhantomArenaHandArea.<HandToRecycle>d__49>(ref <HandToRecycle>d__);
			return <HandToRecycle>d__.<>t__builder.Task;
		}

		// Token: 0x060383CF RID: 230351 RVA: 0x00E3D904 File Offset: 0x00E3BB04
		public UniTask HandCardToFunctionalTop(PhantomArenaCard card, UUIItem toItem, bool needDragUpTween)
		{
			PhantomArenaHandArea.<HandCardToFunctionalTop>d__50 <HandCardToFunctionalTop>d__;
			<HandCardToFunctionalTop>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandCardToFunctionalTop>d__.<>4__this = this;
			<HandCardToFunctionalTop>d__.card = card;
			<HandCardToFunctionalTop>d__.toItem = toItem;
			<HandCardToFunctionalTop>d__.needDragUpTween = needDragUpTween;
			<HandCardToFunctionalTop>d__.<>1__state = -1;
			<HandCardToFunctionalTop>d__.<>t__builder.Start<PhantomArenaHandArea.<HandCardToFunctionalTop>d__50>(ref <HandCardToFunctionalTop>d__);
			return <HandCardToFunctionalTop>d__.<>t__builder.Task;
		}

		// Token: 0x060383D0 RID: 230352 RVA: 0x00E3D960 File Offset: 0x00E3BB60
		public UniTask ReconstructHandCardToRecycle(List<int> cardIdList)
		{
			PhantomArenaHandArea.<ReconstructHandCardToRecycle>d__51 <ReconstructHandCardToRecycle>d__;
			<ReconstructHandCardToRecycle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ReconstructHandCardToRecycle>d__.<>4__this = this;
			<ReconstructHandCardToRecycle>d__.cardIdList = cardIdList;
			<ReconstructHandCardToRecycle>d__.<>1__state = -1;
			<ReconstructHandCardToRecycle>d__.<>t__builder.Start<PhantomArenaHandArea.<ReconstructHandCardToRecycle>d__51>(ref <ReconstructHandCardToRecycle>d__);
			return <ReconstructHandCardToRecycle>d__.<>t__builder.Task;
		}

		// Token: 0x060383D1 RID: 230353 RVA: 0x00E3D9AC File Offset: 0x00E3BBAC
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length < 1)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "HandCard")
			{
				if (configParams.Length < 2)
				{
					return null;
				}
				string a2 = configParams[1];
				List<PhantomArenaHandCardProxy> list = this.CardMap.Values.ToList<PhantomArenaHandCardProxy>();
				if (a2 == "ConfigId")
				{
					int num = int.Parse(configParams[2]);
					foreach (PhantomArenaHandCardProxy phantomArenaHandCardProxy in list)
					{
						if (phantomArenaHandCardProxy.GetCard().Data.ConfigId == num)
						{
							return phantomArenaHandCardProxy.GetGuideUiItemAndUiItemForShowEx(configParams);
						}
					}
					return null;
				}
				int num2 = int.Parse(configParams[1]);
				if (num2 < 0 || num2 >= list.Count)
				{
					return null;
				}
				PhantomArenaHandCardProxy phantomArenaHandCardProxy2 = list[num2];
				if (phantomArenaHandCardProxy2 == null)
				{
					return null;
				}
				return phantomArenaHandCardProxy2.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			else
			{
				if (!(a == "HandArea"))
				{
					return null;
				}
				List<PhantomArenaHandCardProxy> list2 = this.CardMap.Values.ToList<PhantomArenaHandCardProxy>();
				if (list2.Count <= 0)
				{
					return null;
				}
				PhantomArenaHandCardProxy phantomArenaHandCardProxy3 = list2[0];
				if (phantomArenaHandCardProxy3 == null)
				{
					return null;
				}
				return phantomArenaHandCardProxy3.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
		}

		// Token: 0x040201AD RID: 131501
		protected OrderedDictionary<int, PhantomArenaHandCardProxy> CardMap = new OrderedDictionary<int, PhantomArenaHandCardProxy>();

		// Token: 0x040201AE RID: 131502
		protected PhantomArenaOwnArea Area;

		// Token: 0x040201AF RID: 131503
		protected UUIHorizontalLayout Layout;

		// Token: 0x040201B0 RID: 131504
		protected readonly Transform ItemWorldTrans = Transform.Create();

		// Token: 0x040201B1 RID: 131505
		protected readonly Vector TempCardPos = Vector.Create();

		// Token: 0x040201B2 RID: 131506
		protected float TotalWidth;

		// Token: 0x040201B3 RID: 131507
		protected float TotalHeight;

		// Token: 0x040201B4 RID: 131508
		protected float GridWidth;

		// Token: 0x040201B5 RID: 131509
		protected float OriginalSpace;

		// Token: 0x040201B6 RID: 131510
		protected float OriginalOffset;

		// Token: 0x040201B7 RID: 131511
		protected UiSequencePlayer Sequence;

		// Token: 0x040201B8 RID: 131512
		public bool IsLayoutHoist;

		// Token: 0x040201B9 RID: 131513
		protected bool IsFirstTimeDrawCard = true;

		// Token: 0x0200B68C RID: 46732
		[NullableContext(0)]
		private static class EComponentDefine
		{
			// Token: 0x040387B2 RID: 231346
			public const int Layout = 0;
		}
	}
}
