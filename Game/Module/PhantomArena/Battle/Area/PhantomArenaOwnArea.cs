using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.Area.Functional;
using CSharpScript.Game.Module.PhantomArena.Battle.Area.Hand;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Field;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Panel;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Area
{
	// Token: 0x0200562C RID: 22060
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaOwnArea
	{
		// Token: 0x0603837A RID: 230266 RVA: 0x00E3C100 File Offset: 0x00E3A300
		private UniTask InitHandArea(UUIItem handAreaItem)
		{
			PhantomArenaOwnArea.<InitHandArea>d__11 <InitHandArea>d__;
			<InitHandArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitHandArea>d__.<>4__this = this;
			<InitHandArea>d__.handAreaItem = handAreaItem;
			<InitHandArea>d__.<>1__state = -1;
			<InitHandArea>d__.<>t__builder.Start<PhantomArenaOwnArea.<InitHandArea>d__11>(ref <InitHandArea>d__);
			return <InitHandArea>d__.<>t__builder.Task;
		}

		// Token: 0x0603837B RID: 230267 RVA: 0x00E3C14C File Offset: 0x00E3A34C
		private UniTask InitFunctionalArea(UUIItem functionalAreaItem)
		{
			PhantomArenaOwnArea.<InitFunctionalArea>d__12 <InitFunctionalArea>d__;
			<InitFunctionalArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitFunctionalArea>d__.<>4__this = this;
			<InitFunctionalArea>d__.functionalAreaItem = functionalAreaItem;
			<InitFunctionalArea>d__.<>1__state = -1;
			<InitFunctionalArea>d__.<>t__builder.Start<PhantomArenaOwnArea.<InitFunctionalArea>d__12>(ref <InitFunctionalArea>d__);
			return <InitFunctionalArea>d__.<>t__builder.Task;
		}

		// Token: 0x0603837C RID: 230268 RVA: 0x00E3C198 File Offset: 0x00E3A398
		private UniTask InitRoleItem(UUIItem roleItem)
		{
			PhantomArenaOwnArea.<InitRoleItem>d__13 <InitRoleItem>d__;
			<InitRoleItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleItem>d__.<>4__this = this;
			<InitRoleItem>d__.roleItem = roleItem;
			<InitRoleItem>d__.<>1__state = -1;
			<InitRoleItem>d__.<>t__builder.Start<PhantomArenaOwnArea.<InitRoleItem>d__13>(ref <InitRoleItem>d__);
			return <InitRoleItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603837D RID: 230269 RVA: 0x00E3C1E4 File Offset: 0x00E3A3E4
		private UniTask InitDrawCardCurveX()
		{
			PhantomArenaOwnArea.<InitDrawCardCurveX>d__14 <InitDrawCardCurveX>d__;
			<InitDrawCardCurveX>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDrawCardCurveX>d__.<>4__this = this;
			<InitDrawCardCurveX>d__.<>1__state = -1;
			<InitDrawCardCurveX>d__.<>t__builder.Start<PhantomArenaOwnArea.<InitDrawCardCurveX>d__14>(ref <InitDrawCardCurveX>d__);
			return <InitDrawCardCurveX>d__.<>t__builder.Task;
		}

		// Token: 0x0603837E RID: 230270 RVA: 0x00E3C228 File Offset: 0x00E3A428
		private UniTask InitDrawCardCurveY()
		{
			PhantomArenaOwnArea.<InitDrawCardCurveY>d__15 <InitDrawCardCurveY>d__;
			<InitDrawCardCurveY>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDrawCardCurveY>d__.<>4__this = this;
			<InitDrawCardCurveY>d__.<>1__state = -1;
			<InitDrawCardCurveY>d__.<>t__builder.Start<PhantomArenaOwnArea.<InitDrawCardCurveY>d__15>(ref <InitDrawCardCurveY>d__);
			return <InitDrawCardCurveY>d__.<>t__builder.Task;
		}

		// Token: 0x0603837F RID: 230271 RVA: 0x00E3C26C File Offset: 0x00E3A46C
		private UniTask InitDiscardCardCurveX()
		{
			PhantomArenaOwnArea.<InitDiscardCardCurveX>d__16 <InitDiscardCardCurveX>d__;
			<InitDiscardCardCurveX>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDiscardCardCurveX>d__.<>4__this = this;
			<InitDiscardCardCurveX>d__.<>1__state = -1;
			<InitDiscardCardCurveX>d__.<>t__builder.Start<PhantomArenaOwnArea.<InitDiscardCardCurveX>d__16>(ref <InitDiscardCardCurveX>d__);
			return <InitDiscardCardCurveX>d__.<>t__builder.Task;
		}

		// Token: 0x06038380 RID: 230272 RVA: 0x00E3C2B0 File Offset: 0x00E3A4B0
		private UniTask InitDiscardCardCurveY()
		{
			PhantomArenaOwnArea.<InitDiscardCardCurveY>d__17 <InitDiscardCardCurveY>d__;
			<InitDiscardCardCurveY>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDiscardCardCurveY>d__.<>4__this = this;
			<InitDiscardCardCurveY>d__.<>1__state = -1;
			<InitDiscardCardCurveY>d__.<>t__builder.Start<PhantomArenaOwnArea.<InitDiscardCardCurveY>d__17>(ref <InitDiscardCardCurveY>d__);
			return <InitDiscardCardCurveY>d__.<>t__builder.Task;
		}

		// Token: 0x06038381 RID: 230273 RVA: 0x00E3C2F4 File Offset: 0x00E3A4F4
		private UniTask InitMoveLocationCurve()
		{
			PhantomArenaOwnArea.<InitMoveLocationCurve>d__18 <InitMoveLocationCurve>d__;
			<InitMoveLocationCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMoveLocationCurve>d__.<>4__this = this;
			<InitMoveLocationCurve>d__.<>1__state = -1;
			<InitMoveLocationCurve>d__.<>t__builder.Start<PhantomArenaOwnArea.<InitMoveLocationCurve>d__18>(ref <InitMoveLocationCurve>d__);
			return <InitMoveLocationCurve>d__.<>t__builder.Task;
		}

		// Token: 0x06038382 RID: 230274 RVA: 0x00E3C338 File Offset: 0x00E3A538
		private UniTask InitRecycleCurve()
		{
			PhantomArenaOwnArea.<InitRecycleCurve>d__19 <InitRecycleCurve>d__;
			<InitRecycleCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRecycleCurve>d__.<>4__this = this;
			<InitRecycleCurve>d__.<>1__state = -1;
			<InitRecycleCurve>d__.<>t__builder.Start<PhantomArenaOwnArea.<InitRecycleCurve>d__19>(ref <InitRecycleCurve>d__);
			return <InitRecycleCurve>d__.<>t__builder.Task;
		}

		// Token: 0x06038383 RID: 230275 RVA: 0x00E3C37C File Offset: 0x00E3A57C
		private UniTask InitCardCurve()
		{
			PhantomArenaOwnArea.<InitCardCurve>d__20 <InitCardCurve>d__;
			<InitCardCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCardCurve>d__.<>4__this = this;
			<InitCardCurve>d__.<>1__state = -1;
			<InitCardCurve>d__.<>t__builder.Start<PhantomArenaOwnArea.<InitCardCurve>d__20>(ref <InitCardCurve>d__);
			return <InitCardCurve>d__.<>t__builder.Task;
		}

		// Token: 0x06038384 RID: 230276 RVA: 0x00E3C3BF File Offset: 0x00E3A5BF
		private void RefreshTipsActiveByHandDrag(PhantomArenaCard card)
		{
			if (this.HandArea.CheckCardOutHandArea(card))
			{
				this.ViewProxy.HideCardTips();
				this.ViewProxy.CancelSelectedCard();
			}
		}

		// Token: 0x06038385 RID: 230277 RVA: 0x00E3C3E5 File Offset: 0x00E3A5E5
		private void RefreshTipsActiveByFunctionalDrag(PhantomArenaAreaProxyBase cardProxy)
		{
			if (cardProxy.Distance > 100.0)
			{
				this.ViewProxy.HideCardTips();
				this.ViewProxy.CancelSelectedCard();
			}
		}

		// Token: 0x06038386 RID: 230278 RVA: 0x00E3C410 File Offset: 0x00E3A610
		public UniTask InitArea(UUIItem handAreaItem, UUIItem functionalAreaItem, UUIItem roleItem, UUIItem filedAreaItem)
		{
			PhantomArenaOwnArea.<InitArea>d__23 <InitArea>d__;
			<InitArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitArea>d__.<>4__this = this;
			<InitArea>d__.handAreaItem = handAreaItem;
			<InitArea>d__.functionalAreaItem = functionalAreaItem;
			<InitArea>d__.roleItem = roleItem;
			<InitArea>d__.filedAreaItem = filedAreaItem;
			<InitArea>d__.<>1__state = -1;
			<InitArea>d__.<>t__builder.Start<PhantomArenaOwnArea.<InitArea>d__23>(ref <InitArea>d__);
			return <InitArea>d__.<>t__builder.Task;
		}

		// Token: 0x06038387 RID: 230279 RVA: 0x00E3C474 File Offset: 0x00E3A674
		public void RegisterViewProxy(PhantomArenaBattleProxy proxy)
		{
			this.ViewProxy = proxy;
		}

		// Token: 0x06038388 RID: 230280 RVA: 0x00E3C47D File Offset: 0x00E3A67D
		public void RefreshAll(bool isFromWorldDone)
		{
			this.RolePanel.RefreshAll(isFromWorldDone);
			this.FunctionalArea.RefreshAllBattleCard();
			this.RefreshFiledArea().Forget();
		}

		// Token: 0x06038389 RID: 230281 RVA: 0x00E3C4A1 File Offset: 0x00E3A6A1
		public bool IsCanDragCard(int id)
		{
			return !ModelBase<PhantomArenaBattleModel>.Instance.InWaitCallCardIdList(id) && !this.ViewProxy.InCantDragState();
		}

		// Token: 0x0603838A RID: 230282 RVA: 0x00E3C4C4 File Offset: 0x00E3A6C4
		public void CardClick(int id)
		{
			if (this.HandArea.IsLayoutHoist)
			{
				PhantomCardData handCardDataByCardId = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetHandCardDataByCardId(id);
				this.ViewProxy.ShowCardTips(handCardDataByCardId, true);
				this.ViewProxy.SetSelectedCardId(id, EPhantomArenaCardClickFromType.OwnHand);
				return;
			}
			this.HandArea.HoistLayout();
		}

		// Token: 0x0603838B RID: 230283 RVA: 0x00E3C515 File Offset: 0x00E3A715
		public void HideCardList()
		{
			this.ViewProxy.HideCardTips();
			this.ViewProxy.CancelSelectedCard();
			if (this.HandArea.IsLayoutHoist)
			{
				this.HandArea.LowerLayout();
			}
		}

		// Token: 0x0603838C RID: 230284 RVA: 0x00E3C545 File Offset: 0x00E3A745
		private void HandleLayoutHoistByBeginDrag()
		{
			this.LastLayoutHoistState = this.HandArea.IsLayoutHoist;
			if (this.LastLayoutHoistState)
			{
				this.HandArea.LowerLayout();
			}
		}

		// Token: 0x0603838D RID: 230285 RVA: 0x00E3C56B File Offset: 0x00E3A76B
		private void HandleLayoutHoistByFinishDrag()
		{
			if (this.LastLayoutHoistState)
			{
				this.HandArea.HoistLayout();
			}
		}

		// Token: 0x0603838E RID: 230286 RVA: 0x00E3C580 File Offset: 0x00E3A780
		private void HandleLayoutHoistByFailDrag()
		{
			if (this.LastLayoutHoistState)
			{
				this.HandArea.HoistLayout();
			}
		}

		// Token: 0x0603838F RID: 230287 RVA: 0x00E3C595 File Offset: 0x00E3A795
		private void CommonBeginDragLogic(PhantomArenaCard card)
		{
			this.ViewProxy.CardRecycle.RefreshCardRecycleArea(card);
			this.ViewProxy.CardRecycle.SetEffectActive(ERecycleSequenceType.Active);
			this.ViewProxy.BanButtonClickModule.BanButtonList("Drag");
		}

		// Token: 0x06038390 RID: 230288 RVA: 0x00E3C5D0 File Offset: 0x00E3A7D0
		public void CardBeginDragByHand(PhantomArenaCard card)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "从手上拖动卡牌";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", card.Data.CardId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			card.SetUiParent(this.ViewProxy.GetDragRootItem(), false);
			this.FunctionalArea.RefreshStateByDragCard(card);
			this.CommonBeginDragLogic(card);
			this.HandleLayoutHoistByBeginDrag();
		}

		// Token: 0x06038391 RID: 230289 RVA: 0x00E3C644 File Offset: 0x00E3A844
		public unsafe void CardBeginDragByFunctional(PhantomArenaCard card)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "从场上拖动卡牌";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", card.Data.CardId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Index", card.Data.Index);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			card.SetUiParent(this.ViewProxy.GetDragRootItem(), false);
			this.FunctionalArea.RefreshStateByDragCard(card);
			this.CommonBeginDragLogic(card);
		}

		// Token: 0x06038392 RID: 230290 RVA: 0x00E3C6EC File Offset: 0x00E3A8EC
		public UniTask HandCardBeginDragByGamepad(PhantomArenaCard card, int slotIndex, bool needDragUpTween)
		{
			PhantomArenaOwnArea.<HandCardBeginDragByGamepad>d__35 <HandCardBeginDragByGamepad>d__;
			<HandCardBeginDragByGamepad>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandCardBeginDragByGamepad>d__.<>4__this = this;
			<HandCardBeginDragByGamepad>d__.card = card;
			<HandCardBeginDragByGamepad>d__.slotIndex = slotIndex;
			<HandCardBeginDragByGamepad>d__.needDragUpTween = needDragUpTween;
			<HandCardBeginDragByGamepad>d__.<>1__state = -1;
			<HandCardBeginDragByGamepad>d__.<>t__builder.Start<PhantomArenaOwnArea.<HandCardBeginDragByGamepad>d__35>(ref <HandCardBeginDragByGamepad>d__);
			return <HandCardBeginDragByGamepad>d__.<>t__builder.Task;
		}

		// Token: 0x06038393 RID: 230291 RVA: 0x00E3C748 File Offset: 0x00E3A948
		public UniTask BattleCardBeginDragByGamepad(PhantomArenaCard card, int slotIndex, bool needDragUpTween)
		{
			PhantomArenaOwnArea.<BattleCardBeginDragByGamepad>d__36 <BattleCardBeginDragByGamepad>d__;
			<BattleCardBeginDragByGamepad>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<BattleCardBeginDragByGamepad>d__.<>4__this = this;
			<BattleCardBeginDragByGamepad>d__.card = card;
			<BattleCardBeginDragByGamepad>d__.slotIndex = slotIndex;
			<BattleCardBeginDragByGamepad>d__.needDragUpTween = needDragUpTween;
			<BattleCardBeginDragByGamepad>d__.<>1__state = -1;
			<BattleCardBeginDragByGamepad>d__.<>t__builder.Start<PhantomArenaOwnArea.<BattleCardBeginDragByGamepad>d__36>(ref <BattleCardBeginDragByGamepad>d__);
			return <BattleCardBeginDragByGamepad>d__.<>t__builder.Task;
		}

		// Token: 0x06038394 RID: 230292 RVA: 0x00E3C7A3 File Offset: 0x00E3A9A3
		public void CardDraggingByHand(PhantomArenaCard card)
		{
			this.FunctionalArea.RefreshStateByDragCard(card);
			this.ViewProxy.CardRecycle.RefreshCardRecycleArea(card);
			this.RefreshTipsActiveByHandDrag(card);
		}

		// Token: 0x06038395 RID: 230293 RVA: 0x00E3C7C9 File Offset: 0x00E3A9C9
		public void CardDraggingByFunctional(PhantomArenaAreaProxyBase cardProxy)
		{
			this.FunctionalArea.RefreshStateByDragCard(cardProxy.Card);
			this.ViewProxy.CardRecycle.RefreshCardRecycleArea(cardProxy.Card);
			this.RefreshTipsActiveByFunctionalDrag(cardProxy);
		}

		// Token: 0x06038396 RID: 230294 RVA: 0x00E3C7FC File Offset: 0x00E3A9FC
		[NullableContext(0)]
		public UniTask<bool> CardEndDragByHand([Nullable(1)] PhantomArenaCard card)
		{
			PhantomArenaOwnArea.<CardEndDragByHand>d__39 <CardEndDragByHand>d__;
			<CardEndDragByHand>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CardEndDragByHand>d__.<>4__this = this;
			<CardEndDragByHand>d__.card = card;
			<CardEndDragByHand>d__.<>1__state = -1;
			<CardEndDragByHand>d__.<>t__builder.Start<PhantomArenaOwnArea.<CardEndDragByHand>d__39>(ref <CardEndDragByHand>d__);
			return <CardEndDragByHand>d__.<>t__builder.Task;
		}

		// Token: 0x06038397 RID: 230295 RVA: 0x00E3C848 File Offset: 0x00E3AA48
		[NullableContext(0)]
		public UniTask<bool> CardEndDragByFunctional([Nullable(1)] PhantomArenaCard card, int index)
		{
			PhantomArenaOwnArea.<CardEndDragByFunctional>d__40 <CardEndDragByFunctional>d__;
			<CardEndDragByFunctional>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CardEndDragByFunctional>d__.<>4__this = this;
			<CardEndDragByFunctional>d__.card = card;
			<CardEndDragByFunctional>d__.index = index;
			<CardEndDragByFunctional>d__.<>1__state = -1;
			<CardEndDragByFunctional>d__.<>t__builder.Start<PhantomArenaOwnArea.<CardEndDragByFunctional>d__40>(ref <CardEndDragByFunctional>d__);
			return <CardEndDragByFunctional>d__.<>t__builder.Task;
		}

		// Token: 0x06038398 RID: 230296 RVA: 0x00E3C89C File Offset: 0x00E3AA9C
		public UniTask MoveHandCardToRecycle(PhantomArenaCard card, int slotIndex)
		{
			PhantomArenaOwnArea.<MoveHandCardToRecycle>d__41 <MoveHandCardToRecycle>d__;
			<MoveHandCardToRecycle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<MoveHandCardToRecycle>d__.<>4__this = this;
			<MoveHandCardToRecycle>d__.card = card;
			<MoveHandCardToRecycle>d__.slotIndex = slotIndex;
			<MoveHandCardToRecycle>d__.<>1__state = -1;
			<MoveHandCardToRecycle>d__.<>t__builder.Start<PhantomArenaOwnArea.<MoveHandCardToRecycle>d__41>(ref <MoveHandCardToRecycle>d__);
			return <MoveHandCardToRecycle>d__.<>t__builder.Task;
		}

		// Token: 0x06038399 RID: 230297 RVA: 0x00E3C8F0 File Offset: 0x00E3AAF0
		public UniTask MoveFunctionalCardToRecycle(PhantomArenaCard card, int index, int slotIndex)
		{
			PhantomArenaOwnArea.<MoveFunctionalCardToRecycle>d__42 <MoveFunctionalCardToRecycle>d__;
			<MoveFunctionalCardToRecycle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<MoveFunctionalCardToRecycle>d__.<>4__this = this;
			<MoveFunctionalCardToRecycle>d__.card = card;
			<MoveFunctionalCardToRecycle>d__.index = index;
			<MoveFunctionalCardToRecycle>d__.slotIndex = slotIndex;
			<MoveFunctionalCardToRecycle>d__.<>1__state = -1;
			<MoveFunctionalCardToRecycle>d__.<>t__builder.Start<PhantomArenaOwnArea.<MoveFunctionalCardToRecycle>d__42>(ref <MoveFunctionalCardToRecycle>d__);
			return <MoveFunctionalCardToRecycle>d__.<>t__builder.Task;
		}

		// Token: 0x0603839A RID: 230298 RVA: 0x00E3C94C File Offset: 0x00E3AB4C
		private void CommonGamepadResetSelectCardLogic(PhantomArenaCard card, int slotIndex)
		{
			PhantomArenaAreaProxyBase cardProxyByIndex = this.FunctionalArea.GetCardProxyByIndex(slotIndex);
			if (cardProxyByIndex != null)
			{
				cardProxyByIndex.SetHoverStateActive(false);
			}
			this.FunctionalArea.SetAllCardProxyUseActiveState(false, card);
			this.ViewProxy.CardRecycle.SetEffectActive(ERecycleSequenceType.DisActive);
			this.ViewProxy.BanButtonClickModule.ResumeButtonList("Drag");
		}

		// Token: 0x0603839B RID: 230299 RVA: 0x00E3C9A4 File Offset: 0x00E3ABA4
		public UniTask ResetSelectCardToHand(PhantomArenaCard card, int slotIndex)
		{
			PhantomArenaOwnArea.<ResetSelectCardToHand>d__44 <ResetSelectCardToHand>d__;
			<ResetSelectCardToHand>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResetSelectCardToHand>d__.<>4__this = this;
			<ResetSelectCardToHand>d__.card = card;
			<ResetSelectCardToHand>d__.slotIndex = slotIndex;
			<ResetSelectCardToHand>d__.<>1__state = -1;
			<ResetSelectCardToHand>d__.<>t__builder.Start<PhantomArenaOwnArea.<ResetSelectCardToHand>d__44>(ref <ResetSelectCardToHand>d__);
			return <ResetSelectCardToHand>d__.<>t__builder.Task;
		}

		// Token: 0x0603839C RID: 230300 RVA: 0x00E3C9F8 File Offset: 0x00E3ABF8
		public UniTask ResetSelectCardToFunctional(PhantomArenaCard card, int slotIndex)
		{
			PhantomArenaOwnArea.<ResetSelectCardToFunctional>d__45 <ResetSelectCardToFunctional>d__;
			<ResetSelectCardToFunctional>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResetSelectCardToFunctional>d__.<>4__this = this;
			<ResetSelectCardToFunctional>d__.card = card;
			<ResetSelectCardToFunctional>d__.slotIndex = slotIndex;
			<ResetSelectCardToFunctional>d__.<>1__state = -1;
			<ResetSelectCardToFunctional>d__.<>t__builder.Start<PhantomArenaOwnArea.<ResetSelectCardToFunctional>d__45>(ref <ResetSelectCardToFunctional>d__);
			return <ResetSelectCardToFunctional>d__.<>t__builder.Task;
		}

		// Token: 0x0603839D RID: 230301 RVA: 0x00E3CA4B File Offset: 0x00E3AC4B
		public void ResetFunctionalToHand(PhantomArenaCard card, int index)
		{
			this.FunctionalArea.RemoveCard(index);
			this.HandArea.FunctionalToHand(card).Forget();
		}

		// Token: 0x0603839E RID: 230302 RVA: 0x00E3CA6C File Offset: 0x00E3AC6C
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<PhantomArenaCard> CreatePhantomArenaCard(PhantomCardData cardData, UUIItem rootItem)
		{
			PhantomArenaOwnArea.<CreatePhantomArenaCard>d__47 <CreatePhantomArenaCard>d__;
			<CreatePhantomArenaCard>d__.<>t__builder = AsyncUniTaskMethodBuilder<PhantomArenaCard>.Create();
			<CreatePhantomArenaCard>d__.<>4__this = this;
			<CreatePhantomArenaCard>d__.cardData = cardData;
			<CreatePhantomArenaCard>d__.rootItem = rootItem;
			<CreatePhantomArenaCard>d__.<>1__state = -1;
			<CreatePhantomArenaCard>d__.<>t__builder.Start<PhantomArenaOwnArea.<CreatePhantomArenaCard>d__47>(ref <CreatePhantomArenaCard>d__);
			return <CreatePhantomArenaCard>d__.<>t__builder.Task;
		}

		// Token: 0x0603839F RID: 230303 RVA: 0x00E3CAC0 File Offset: 0x00E3ACC0
		private UniTask CallLibraryCardToFight(PhantomCardData cardData, UUIItem fromItem, PhantomArenaAreaProxyBase proxy)
		{
			PhantomArenaOwnArea.<CallLibraryCardToFight>d__48 <CallLibraryCardToFight>d__;
			<CallLibraryCardToFight>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CallLibraryCardToFight>d__.<>4__this = this;
			<CallLibraryCardToFight>d__.cardData = cardData;
			<CallLibraryCardToFight>d__.fromItem = fromItem;
			<CallLibraryCardToFight>d__.proxy = proxy;
			<CallLibraryCardToFight>d__.<>1__state = -1;
			<CallLibraryCardToFight>d__.<>t__builder.Start<PhantomArenaOwnArea.<CallLibraryCardToFight>d__48>(ref <CallLibraryCardToFight>d__);
			return <CallLibraryCardToFight>d__.<>t__builder.Task;
		}

		// Token: 0x060383A0 RID: 230304 RVA: 0x00E3CB1C File Offset: 0x00E3AD1C
		private UniTask CallHandCardToFight(PhantomCardData cardData, PhantomArenaAreaProxyBase proxy)
		{
			PhantomArenaOwnArea.<CallHandCardToFight>d__49 <CallHandCardToFight>d__;
			<CallHandCardToFight>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CallHandCardToFight>d__.<>4__this = this;
			<CallHandCardToFight>d__.cardData = cardData;
			<CallHandCardToFight>d__.proxy = proxy;
			<CallHandCardToFight>d__.<>1__state = -1;
			<CallHandCardToFight>d__.<>t__builder.Start<PhantomArenaOwnArea.<CallHandCardToFight>d__49>(ref <CallHandCardToFight>d__);
			return <CallHandCardToFight>d__.<>t__builder.Task;
		}

		// Token: 0x060383A1 RID: 230305 RVA: 0x00E3CB70 File Offset: 0x00E3AD70
		public UniTask CallHandCardListToFight(PhantomBattleFighterInfo[] cardInfoList)
		{
			PhantomArenaOwnArea.<CallHandCardListToFight>d__50 <CallHandCardListToFight>d__;
			<CallHandCardListToFight>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CallHandCardListToFight>d__.<>4__this = this;
			<CallHandCardListToFight>d__.cardInfoList = cardInfoList;
			<CallHandCardListToFight>d__.<>1__state = -1;
			<CallHandCardListToFight>d__.<>t__builder.Start<PhantomArenaOwnArea.<CallHandCardListToFight>d__50>(ref <CallHandCardListToFight>d__);
			return <CallHandCardListToFight>d__.<>t__builder.Task;
		}

		// Token: 0x060383A2 RID: 230306 RVA: 0x00E3CBBC File Offset: 0x00E3ADBC
		public UniTask CallLibraryCardListToFight(PhantomBattleFighterInfo[] cardInfoList)
		{
			PhantomArenaOwnArea.<CallLibraryCardListToFight>d__51 <CallLibraryCardListToFight>d__;
			<CallLibraryCardListToFight>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CallLibraryCardListToFight>d__.<>4__this = this;
			<CallLibraryCardListToFight>d__.cardInfoList = cardInfoList;
			<CallLibraryCardListToFight>d__.<>1__state = -1;
			<CallLibraryCardListToFight>d__.<>t__builder.Start<PhantomArenaOwnArea.<CallLibraryCardListToFight>d__51>(ref <CallLibraryCardListToFight>d__);
			return <CallLibraryCardListToFight>d__.<>t__builder.Task;
		}

		// Token: 0x060383A3 RID: 230307 RVA: 0x00E3CC08 File Offset: 0x00E3AE08
		private UniTask InitFiledArea(UUIItem filedAreaItem)
		{
			PhantomArenaOwnArea.<InitFiledArea>d__54 <InitFiledArea>d__;
			<InitFiledArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitFiledArea>d__.<>4__this = this;
			<InitFiledArea>d__.filedAreaItem = filedAreaItem;
			<InitFiledArea>d__.<>1__state = -1;
			<InitFiledArea>d__.<>t__builder.Start<PhantomArenaOwnArea.<InitFiledArea>d__54>(ref <InitFiledArea>d__);
			return <InitFiledArea>d__.<>t__builder.Task;
		}

		// Token: 0x060383A4 RID: 230308 RVA: 0x00E3CC54 File Offset: 0x00E3AE54
		private UniTask ShowFieldEffect()
		{
			PhantomArenaOwnArea.<ShowFieldEffect>d__55 <ShowFieldEffect>d__;
			<ShowFieldEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowFieldEffect>d__.<>4__this = this;
			<ShowFieldEffect>d__.<>1__state = -1;
			<ShowFieldEffect>d__.<>t__builder.Start<PhantomArenaOwnArea.<ShowFieldEffect>d__55>(ref <ShowFieldEffect>d__);
			return <ShowFieldEffect>d__.<>t__builder.Task;
		}

		// Token: 0x060383A5 RID: 230309 RVA: 0x00E3CC98 File Offset: 0x00E3AE98
		public UniTask RefreshFiledArea()
		{
			PhantomArenaOwnArea.<RefreshFiledArea>d__56 <RefreshFiledArea>d__;
			<RefreshFiledArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshFiledArea>d__.<>4__this = this;
			<RefreshFiledArea>d__.<>1__state = -1;
			<RefreshFiledArea>d__.<>t__builder.Start<PhantomArenaOwnArea.<RefreshFiledArea>d__56>(ref <RefreshFiledArea>d__);
			return <RefreshFiledArea>d__.<>t__builder.Task;
		}

		// Token: 0x060383A6 RID: 230310 RVA: 0x00E3CCDC File Offset: 0x00E3AEDC
		public UniTask ShowField()
		{
			PhantomArenaOwnArea.<ShowField>d__57 <ShowField>d__;
			<ShowField>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowField>d__.<>4__this = this;
			<ShowField>d__.<>1__state = -1;
			<ShowField>d__.<>t__builder.Start<PhantomArenaOwnArea.<ShowField>d__57>(ref <ShowField>d__);
			return <ShowField>d__.<>t__builder.Task;
		}

		// Token: 0x060383A7 RID: 230311 RVA: 0x00E3CD20 File Offset: 0x00E3AF20
		public UniTask ShowFiledArea()
		{
			PhantomArenaOwnArea.<ShowFiledArea>d__58 <ShowFiledArea>d__;
			<ShowFiledArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowFiledArea>d__.<>4__this = this;
			<ShowFiledArea>d__.<>1__state = -1;
			<ShowFiledArea>d__.<>t__builder.Start<PhantomArenaOwnArea.<ShowFiledArea>d__58>(ref <ShowFiledArea>d__);
			return <ShowFiledArea>d__.<>t__builder.Task;
		}

		// Token: 0x060383A8 RID: 230312 RVA: 0x00E3CD64 File Offset: 0x00E3AF64
		public UniTask UnlockFiledArea()
		{
			PhantomArenaOwnArea.<UnlockFiledArea>d__59 <UnlockFiledArea>d__;
			<UnlockFiledArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UnlockFiledArea>d__.<>4__this = this;
			<UnlockFiledArea>d__.<>1__state = -1;
			<UnlockFiledArea>d__.<>t__builder.Start<PhantomArenaOwnArea.<UnlockFiledArea>d__59>(ref <UnlockFiledArea>d__);
			return <UnlockFiledArea>d__.<>t__builder.Task;
		}

		// Token: 0x060383A9 RID: 230313 RVA: 0x00E3CDA7 File Offset: 0x00E3AFA7
		public void SwitchFieldState(bool isGamepad)
		{
			PhantomArenaFieldArea filedArea = this.FiledArea;
			if (filedArea != null)
			{
				filedArea.SwitchFieldState(!isGamepad);
			}
			this.RolePanel.SwitchFieldState(isGamepad);
		}

		// Token: 0x040201A0 RID: 131488
		public PhantomArenaBattleProxy ViewProxy;

		// Token: 0x040201A1 RID: 131489
		public PhantomArenaHandArea HandArea;

		// Token: 0x040201A2 RID: 131490
		public PhantomArenaFunctionalArea FunctionalArea;

		// Token: 0x040201A3 RID: 131491
		public PhantomArenaOwnRolePanel RolePanel;

		// Token: 0x040201A4 RID: 131492
		public UCurveFloat DrawCardCurveX;

		// Token: 0x040201A5 RID: 131493
		public UCurveFloat DrawCardCurveY;

		// Token: 0x040201A6 RID: 131494
		public UCurveFloat DiscardCardCurveX;

		// Token: 0x040201A7 RID: 131495
		public UCurveFloat DiscardCardCurveY;

		// Token: 0x040201A8 RID: 131496
		public UCurveFloat MoveLocationCurve;

		// Token: 0x040201A9 RID: 131497
		public UCurveFloat RecycleCurve;

		// Token: 0x040201AA RID: 131498
		private bool LastLayoutHoistState;

		// Token: 0x040201AB RID: 131499
		public PhantomArenaFieldArea FiledArea;

		// Token: 0x040201AC RID: 131500
		public PhantomArenaFieldEffectItem FieldEffect;
	}
}
