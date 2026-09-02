using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Area.Hand
{
	// Token: 0x0200562F RID: 22063
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaHandCardProxy : IPhantomCardDragProxy, IPhantomCardProxyBase, IPhantomCardProxy
	{
		// Token: 0x060383D8 RID: 230360 RVA: 0x00E3DBBB File Offset: 0x00E3BDBB
		public void Init(PhantomArenaCard card, PhantomArenaHandAreaItem areaItem, PhantomArenaOwnArea area)
		{
			this.Card = card;
			this.AreaItem = areaItem;
			this.Card.SetCardProxy(this);
			this.Area = area;
			this.IsInit = true;
		}

		// Token: 0x060383D9 RID: 230361 RVA: 0x00E3DBE8 File Offset: 0x00E3BDE8
		public void PointerClickCard(int id, EToggleState state)
		{
			Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "点击手牌", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.Area.CardClick(id);
		}

		// Token: 0x060383DA RID: 230362 RVA: 0x00E3DC20 File Offset: 0x00E3BE20
		public void PointerEnterCard(int id)
		{
		}

		// Token: 0x060383DB RID: 230363 RVA: 0x00E3DC24 File Offset: 0x00E3BE24
		public void PointerDownCard(int id, ULGUIPointerEventData eventData)
		{
			this.IsCanDrag = this.IsCanDragCard(id);
			if (!this.IsCanDrag)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "按下手牌", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.Card.RecordLastDragPos(eventData.pointerPosition);
		}

		// Token: 0x060383DC RID: 230364 RVA: 0x00E3DC78 File Offset: 0x00E3BE78
		private bool IsCanDragCard(int id)
		{
			if (this.IsInCardTween)
			{
				return false;
			}
			if (ModelBase<PhantomArenaBattleModel>.Instance.OwnData.HasBattleCardByCardId(id))
			{
				Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "场上存在相同卡牌id时不允许操作", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			return this.Area.IsCanDragCard(id);
		}

		// Token: 0x060383DD RID: 230365 RVA: 0x00E3DCD0 File Offset: 0x00E3BED0
		public void PointerBeginDrag(int id, ULGUIPointerEventData eventData)
		{
			if (!this.IsCanDrag)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "开始拖动手牌", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.Area.CardBeginDragByHand(this.Card);
			this.Card.PlaySequence("DragUpHandtoTable", false);
			this.PlayInToOutHandSequence();
		}

		// Token: 0x060383DE RID: 230366 RVA: 0x00E3DD30 File Offset: 0x00E3BF30
		public void PointerDragCard(int id, ULGUIPointerEventData eventData)
		{
			if (!this.IsCanDrag)
			{
				return;
			}
			FVector pointerPosition = eventData.pointerPosition;
			this.Card.MoveCard(pointerPosition);
			this.Area.CardDraggingByHand(this.Card);
		}

		// Token: 0x060383DF RID: 230367 RVA: 0x00E3DD6C File Offset: 0x00E3BF6C
		public void PointerEndDrag(int id, ULGUIPointerEventData eventData)
		{
			if (!this.IsCanDrag)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "结束拖动手牌", default(ReadOnlySpan<ValueTuple<string, object>>));
			FVector pointerPosition = eventData.pointerPosition;
			this.Card.RecordLastDragPos(pointerPosition);
			this.Area.CardEndDragByHand(this.Card).Forget<bool>();
		}

		// Token: 0x060383E0 RID: 230368 RVA: 0x00E3DDCC File Offset: 0x00E3BFCC
		public UniTask Remove()
		{
			PhantomArenaHandCardProxy.<Remove>d__15 <Remove>d__;
			<Remove>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Remove>d__.<>4__this = this;
			<Remove>d__.<>1__state = -1;
			<Remove>d__.<>t__builder.Start<PhantomArenaHandCardProxy.<Remove>d__15>(ref <Remove>d__);
			return <Remove>d__.<>t__builder.Task;
		}

		// Token: 0x060383E1 RID: 230369 RVA: 0x00E3DE10 File Offset: 0x00E3C010
		public UniTask Clear()
		{
			PhantomArenaHandCardProxy.<Clear>d__16 <Clear>d__;
			<Clear>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Clear>d__.<>4__this = this;
			<Clear>d__.<>1__state = -1;
			<Clear>d__.<>t__builder.Start<PhantomArenaHandCardProxy.<Clear>d__16>(ref <Clear>d__);
			return <Clear>d__.<>t__builder.Task;
		}

		// Token: 0x060383E2 RID: 230370 RVA: 0x00E3DE54 File Offset: 0x00E3C054
		public UniTask RemoveBySequence()
		{
			PhantomArenaHandCardProxy.<RemoveBySequence>d__17 <RemoveBySequence>d__;
			<RemoveBySequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RemoveBySequence>d__.<>4__this = this;
			<RemoveBySequence>d__.<>1__state = -1;
			<RemoveBySequence>d__.<>t__builder.Start<PhantomArenaHandCardProxy.<RemoveBySequence>d__17>(ref <RemoveBySequence>d__);
			return <RemoveBySequence>d__.<>t__builder.Task;
		}

		// Token: 0x060383E3 RID: 230371 RVA: 0x00E3DE98 File Offset: 0x00E3C098
		public UniTask DissolveByLibrary()
		{
			PhantomArenaHandCardProxy.<DissolveByLibrary>d__18 <DissolveByLibrary>d__;
			<DissolveByLibrary>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DissolveByLibrary>d__.<>4__this = this;
			<DissolveByLibrary>d__.<>1__state = -1;
			<DissolveByLibrary>d__.<>t__builder.Start<PhantomArenaHandCardProxy.<DissolveByLibrary>d__18>(ref <DissolveByLibrary>d__);
			return <DissolveByLibrary>d__.<>t__builder.Task;
		}

		// Token: 0x060383E4 RID: 230372 RVA: 0x00E3DEDB File Offset: 0x00E3C0DB
		public void PlayInHandSequence()
		{
			if (this.Area.FunctionalArea.CheckSettingCardPosition(this.Card))
			{
				this.Card.PlayStateSequence("UseStart");
				return;
			}
			this.Card.PlayStateSequence("UseClose");
		}

		// Token: 0x060383E5 RID: 230373 RVA: 0x00E3DF16 File Offset: 0x00E3C116
		private void PlayOutToInHandSequence()
		{
			if (this.Area.FunctionalArea.CheckSettingCardPosition(this.Card))
			{
				this.Card.PlayStateSequence("SeleToUse");
				return;
			}
			this.Card.PlayStateSequence("SeleClose");
		}

		// Token: 0x060383E6 RID: 230374 RVA: 0x00E3DF51 File Offset: 0x00E3C151
		private void PlayInToOutHandSequence()
		{
			if (this.Area.FunctionalArea.CheckSettingCardPosition(this.Card))
			{
				this.Card.PlayStateSequence("UseToSele");
			}
		}

		// Token: 0x060383E7 RID: 230375 RVA: 0x00E3DF7B File Offset: 0x00E3C17B
		private void PlayUseCloseSequence()
		{
			this.Card.PlayStateSequence("UseClose");
		}

		// Token: 0x060383E8 RID: 230376 RVA: 0x00E3DF8D File Offset: 0x00E3C18D
		public bool CheckCardOutHandArea()
		{
			return this.Area.FunctionalArea.GetNearlyAreaItemProxyByCard(this.Card) != null || this.Area.ViewProxy.CardRecycle.CheckCardInRecycleArea(this.Card);
		}

		// Token: 0x060383E9 RID: 230377 RVA: 0x00E3DFCC File Offset: 0x00E3C1CC
		public UniTask PlayStartTimeLocationTween(UUIItem fromItem, int delayTime)
		{
			PhantomArenaHandCardProxy.<PlayStartTimeLocationTween>d__24 <PlayStartTimeLocationTween>d__;
			<PlayStartTimeLocationTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartTimeLocationTween>d__.<>4__this = this;
			<PlayStartTimeLocationTween>d__.fromItem = fromItem;
			<PlayStartTimeLocationTween>d__.delayTime = delayTime;
			<PlayStartTimeLocationTween>d__.<>1__state = -1;
			<PlayStartTimeLocationTween>d__.<>t__builder.Start<PhantomArenaHandCardProxy.<PlayStartTimeLocationTween>d__24>(ref <PlayStartTimeLocationTween>d__);
			return <PlayStartTimeLocationTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383EA RID: 230378 RVA: 0x00E3E020 File Offset: 0x00E3C220
		public UniTask PlayEndTimeLocationTween(UUIItem toItem, int delayTime)
		{
			PhantomArenaHandCardProxy.<PlayEndTimeLocationTween>d__25 <PlayEndTimeLocationTween>d__;
			<PlayEndTimeLocationTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayEndTimeLocationTween>d__.<>4__this = this;
			<PlayEndTimeLocationTween>d__.toItem = toItem;
			<PlayEndTimeLocationTween>d__.delayTime = delayTime;
			<PlayEndTimeLocationTween>d__.<>1__state = -1;
			<PlayEndTimeLocationTween>d__.<>t__builder.Start<PhantomArenaHandCardProxy.<PlayEndTimeLocationTween>d__25>(ref <PlayEndTimeLocationTween>d__);
			return <PlayEndTimeLocationTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383EB RID: 230379 RVA: 0x00E3E074 File Offset: 0x00E3C274
		public UniTask PlayDiscardCardTween(UUIItem toItem, int delayTime)
		{
			PhantomArenaHandCardProxy.<PlayDiscardCardTween>d__26 <PlayDiscardCardTween>d__;
			<PlayDiscardCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayDiscardCardTween>d__.<>4__this = this;
			<PlayDiscardCardTween>d__.toItem = toItem;
			<PlayDiscardCardTween>d__.delayTime = delayTime;
			<PlayDiscardCardTween>d__.<>1__state = -1;
			<PlayDiscardCardTween>d__.<>t__builder.Start<PhantomArenaHandCardProxy.<PlayDiscardCardTween>d__26>(ref <PlayDiscardCardTween>d__);
			return <PlayDiscardCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383EC RID: 230380 RVA: 0x00E3E0C8 File Offset: 0x00E3C2C8
		public UniTask PlayHandRecycleCardTween(int delayTime)
		{
			PhantomArenaHandCardProxy.<PlayHandRecycleCardTween>d__27 <PlayHandRecycleCardTween>d__;
			<PlayHandRecycleCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayHandRecycleCardTween>d__.<>4__this = this;
			<PlayHandRecycleCardTween>d__.delayTime = delayTime;
			<PlayHandRecycleCardTween>d__.<>1__state = -1;
			<PlayHandRecycleCardTween>d__.<>t__builder.Start<PhantomArenaHandCardProxy.<PlayHandRecycleCardTween>d__27>(ref <PlayHandRecycleCardTween>d__);
			return <PlayHandRecycleCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383ED RID: 230381 RVA: 0x00E3E114 File Offset: 0x00E3C314
		public UniTask PlayResetPositionTween()
		{
			PhantomArenaHandCardProxy.<PlayResetPositionTween>d__28 <PlayResetPositionTween>d__;
			<PlayResetPositionTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayResetPositionTween>d__.<>4__this = this;
			<PlayResetPositionTween>d__.<>1__state = -1;
			<PlayResetPositionTween>d__.<>t__builder.Start<PhantomArenaHandCardProxy.<PlayResetPositionTween>d__28>(ref <PlayResetPositionTween>d__);
			return <PlayResetPositionTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383EE RID: 230382 RVA: 0x00E3E158 File Offset: 0x00E3C358
		public UniTask PlayHandToFunctionalTopTween(UUIItem toItem, bool needDragUpTween)
		{
			PhantomArenaHandCardProxy.<PlayHandToFunctionalTopTween>d__29 <PlayHandToFunctionalTopTween>d__;
			<PlayHandToFunctionalTopTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayHandToFunctionalTopTween>d__.<>4__this = this;
			<PlayHandToFunctionalTopTween>d__.toItem = toItem;
			<PlayHandToFunctionalTopTween>d__.needDragUpTween = needDragUpTween;
			<PlayHandToFunctionalTopTween>d__.<>1__state = -1;
			<PlayHandToFunctionalTopTween>d__.<>t__builder.Start<PhantomArenaHandCardProxy.<PlayHandToFunctionalTopTween>d__29>(ref <PlayHandToFunctionalTopTween>d__);
			return <PlayHandToFunctionalTopTween>d__.<>t__builder.Task;
		}

		// Token: 0x060383EF RID: 230383 RVA: 0x00E3E1AC File Offset: 0x00E3C3AC
		public UniTask CallHandCardToFight(UUIItem toItem)
		{
			PhantomArenaHandCardProxy.<CallHandCardToFight>d__30 <CallHandCardToFight>d__;
			<CallHandCardToFight>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CallHandCardToFight>d__.<>4__this = this;
			<CallHandCardToFight>d__.toItem = toItem;
			<CallHandCardToFight>d__.<>1__state = -1;
			<CallHandCardToFight>d__.<>t__builder.Start<PhantomArenaHandCardProxy.<CallHandCardToFight>d__30>(ref <CallHandCardToFight>d__);
			return <CallHandCardToFight>d__.<>t__builder.Task;
		}

		// Token: 0x060383F0 RID: 230384 RVA: 0x00E3E1F8 File Offset: 0x00E3C3F8
		public void SetCardSelectedState(bool value)
		{
			if (value)
			{
				this.LayoutIndex = this.AreaItem.GetOriginalItem().GetHierarchyIndex();
				this.AreaItem.GetOriginalItem().SetAsLastHierarchy();
				this.Card.SetSelectedState(true);
				return;
			}
			if (this.LayoutIndex != -1)
			{
				this.AreaItem.GetOriginalItem().SetHierarchyIndex(this.LayoutIndex);
				this.LayoutIndex = -1;
			}
			this.Card.SetSelectedState(false);
		}

		// Token: 0x060383F1 RID: 230385 RVA: 0x00E3E26D File Offset: 0x00E3C46D
		public bool IsNoAllowDiscard()
		{
			return this.Card.Data.IsNoAllowDiscard;
		}

		// Token: 0x060383F2 RID: 230386 RVA: 0x00E3E27F File Offset: 0x00E3C47F
		public PhantomArenaCard GetCard()
		{
			return this.Card;
		}

		// Token: 0x060383F3 RID: 230387 RVA: 0x00E3E288 File Offset: 0x00E3C488
		public UniTask RefreshCardData(PhantomCardData data)
		{
			PhantomArenaHandCardProxy.<RefreshCardData>d__34 <RefreshCardData>d__;
			<RefreshCardData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCardData>d__.<>4__this = this;
			<RefreshCardData>d__.data = data;
			<RefreshCardData>d__.<>1__state = -1;
			<RefreshCardData>d__.<>t__builder.Start<PhantomArenaHandCardProxy.<RefreshCardData>d__34>(ref <RefreshCardData>d__);
			return <RefreshCardData>d__.<>t__builder.Task;
		}

		// Token: 0x060383F4 RID: 230388 RVA: 0x00E3E2D3 File Offset: 0x00E3C4D3
		public void SetHierarchyIndex(int index)
		{
			UUIItem originalItem = this.AreaItem.GetOriginalItem();
			if (originalItem == null)
			{
				return;
			}
			originalItem.SetHierarchyIndex(index);
		}

		// Token: 0x060383F5 RID: 230389 RVA: 0x00E3E2EC File Offset: 0x00E3C4EC
		public UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (!(a == "HandCard") && !(a == "HandArea"))
			{
				return null;
			}
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return this.Card.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			UUIItem guideUiItem = this.AreaItem.GetGuideUiItem("0");
			if (guideUiItem != null)
			{
				return new UUIItem[]
				{
					guideUiItem,
					guideUiItem
				};
			}
			return null;
		}

		// Token: 0x040201BB RID: 131515
		private PhantomArenaCard Card;

		// Token: 0x040201BC RID: 131516
		protected PhantomArenaHandAreaItem AreaItem;

		// Token: 0x040201BD RID: 131517
		protected PhantomArenaOwnArea Area;

		// Token: 0x040201BE RID: 131518
		private bool IsCanDrag;

		// Token: 0x040201BF RID: 131519
		private int LayoutIndex = -1;

		// Token: 0x040201C0 RID: 131520
		public bool IsInit;

		// Token: 0x040201C1 RID: 131521
		protected bool IsInCardTween;
	}
}
