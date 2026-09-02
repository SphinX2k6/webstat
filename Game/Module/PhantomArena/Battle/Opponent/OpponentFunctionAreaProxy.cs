using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Area.Functional;
using CSharpScript.Game.Module.PhantomArena.Battle.Canvas;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Opponent
{
	// Token: 0x020055F4 RID: 22004
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class OpponentFunctionAreaProxy : IPhantomCardProxy, IPhantomCardProxyBase, IAreaCanvas
	{
		// Token: 0x17008FFF RID: 36863
		// (get) Token: 0x060380E8 RID: 229608 RVA: 0x00E33883 File Offset: 0x00E31A83
		// (set) Token: 0x060380E9 RID: 229609 RVA: 0x00E3388B File Offset: 0x00E31A8B
		public PhantomArenaAreaItemBase AreaItem { get; set; }

		// Token: 0x17009000 RID: 36864
		// (get) Token: 0x060380EA RID: 229610
		public abstract bool IsMonster { get; }

		// Token: 0x17009001 RID: 36865
		// (get) Token: 0x060380EB RID: 229611
		public abstract bool IsNeedPreload { get; }

		// Token: 0x060380EC RID: 229612 RVA: 0x00E33894 File Offset: 0x00E31A94
		public OpponentFunctionAreaProxy(int index, OpponentFunctionArea area)
		{
			this.Index = index;
			this.ParentArea = area;
		}

		// Token: 0x060380ED RID: 229613 RVA: 0x00E338B1 File Offset: 0x00E31AB1
		public void SetAreaItem(PhantomArenaAreaItemBase areaItem)
		{
			this.AreaItem = areaItem;
		}

		// Token: 0x060380EE RID: 229614 RVA: 0x00E338BC File Offset: 0x00E31ABC
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected UniTask<PhantomArenaCard> AddCardById(int cardId)
		{
			OpponentFunctionAreaProxy.<AddCardById>d__16 <AddCardById>d__;
			<AddCardById>d__.<>t__builder = AsyncUniTaskMethodBuilder<PhantomArenaCard>.Create();
			<AddCardById>d__.<>4__this = this;
			<AddCardById>d__.cardId = cardId;
			<AddCardById>d__.<>1__state = -1;
			<AddCardById>d__.<>t__builder.Start<OpponentFunctionAreaProxy.<AddCardById>d__16>(ref <AddCardById>d__);
			return <AddCardById>d__.<>t__builder.Task;
		}

		// Token: 0x060380EF RID: 229615 RVA: 0x00E33908 File Offset: 0x00E31B08
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected UniTask<PhantomArenaCard> AddFightCardById(int cardId)
		{
			OpponentFunctionAreaProxy.<AddFightCardById>d__17 <AddFightCardById>d__;
			<AddFightCardById>d__.<>t__builder = AsyncUniTaskMethodBuilder<PhantomArenaCard>.Create();
			<AddFightCardById>d__.<>4__this = this;
			<AddFightCardById>d__.cardId = cardId;
			<AddFightCardById>d__.<>1__state = -1;
			<AddFightCardById>d__.<>t__builder.Start<OpponentFunctionAreaProxy.<AddFightCardById>d__17>(ref <AddFightCardById>d__);
			return <AddFightCardById>d__.<>t__builder.Task;
		}

		// Token: 0x060380F0 RID: 229616 RVA: 0x00E33954 File Offset: 0x00E31B54
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected UniTask<PhantomArenaCard> AddCardByCardData(PhantomCardData cardData)
		{
			OpponentFunctionAreaProxy.<AddCardByCardData>d__18 <AddCardByCardData>d__;
			<AddCardByCardData>d__.<>t__builder = AsyncUniTaskMethodBuilder<PhantomArenaCard>.Create();
			<AddCardByCardData>d__.<>4__this = this;
			<AddCardByCardData>d__.cardData = cardData;
			<AddCardByCardData>d__.<>1__state = -1;
			<AddCardByCardData>d__.<>t__builder.Start<OpponentFunctionAreaProxy.<AddCardByCardData>d__18>(ref <AddCardByCardData>d__);
			return <AddCardByCardData>d__.<>t__builder.Task;
		}

		// Token: 0x060380F1 RID: 229617 RVA: 0x00E339A0 File Offset: 0x00E31BA0
		public UniTask SetCard(int cardId, UUIItem fromItem)
		{
			OpponentFunctionAreaProxy.<SetCard>d__19 <SetCard>d__;
			<SetCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetCard>d__.<>4__this = this;
			<SetCard>d__.cardId = cardId;
			<SetCard>d__.fromItem = fromItem;
			<SetCard>d__.<>1__state = -1;
			<SetCard>d__.<>t__builder.Start<OpponentFunctionAreaProxy.<SetCard>d__19>(ref <SetCard>d__);
			return <SetCard>d__.<>t__builder.Task;
		}

		// Token: 0x060380F2 RID: 229618 RVA: 0x00E339F4 File Offset: 0x00E31BF4
		public UniTask ChangeCard(PhantomArenaCard card)
		{
			OpponentFunctionAreaProxy.<ChangeCard>d__20 <ChangeCard>d__;
			<ChangeCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChangeCard>d__.<>4__this = this;
			<ChangeCard>d__.card = card;
			<ChangeCard>d__.<>1__state = -1;
			<ChangeCard>d__.<>t__builder.Start<OpponentFunctionAreaProxy.<ChangeCard>d__20>(ref <ChangeCard>d__);
			return <ChangeCard>d__.<>t__builder.Task;
		}

		// Token: 0x060380F3 RID: 229619 RVA: 0x00E33A40 File Offset: 0x00E31C40
		public UniTask DestroyCard()
		{
			OpponentFunctionAreaProxy.<DestroyCard>d__21 <DestroyCard>d__;
			<DestroyCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DestroyCard>d__.<>4__this = this;
			<DestroyCard>d__.<>1__state = -1;
			<DestroyCard>d__.<>t__builder.Start<OpponentFunctionAreaProxy.<DestroyCard>d__21>(ref <DestroyCard>d__);
			return <DestroyCard>d__.<>t__builder.Task;
		}

		// Token: 0x060380F4 RID: 229620 RVA: 0x00E33A84 File Offset: 0x00E31C84
		public UniTask DissolveCard()
		{
			OpponentFunctionAreaProxy.<DissolveCard>d__22 <DissolveCard>d__;
			<DissolveCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DissolveCard>d__.<>4__this = this;
			<DissolveCard>d__.<>1__state = -1;
			<DissolveCard>d__.<>t__builder.Start<OpponentFunctionAreaProxy.<DissolveCard>d__22>(ref <DissolveCard>d__);
			return <DissolveCard>d__.<>t__builder.Task;
		}

		// Token: 0x060380F5 RID: 229621 RVA: 0x00E33AC7 File Offset: 0x00E31CC7
		public void SetCardSelectedState(bool value)
		{
			if (this.Card != null)
			{
				this.Card.SetSelectedState(value);
			}
		}

		// Token: 0x060380F6 RID: 229622 RVA: 0x00E33AE0 File Offset: 0x00E31CE0
		public UniTask PlaySetBattleTween(UUIItem fromItem)
		{
			OpponentFunctionAreaProxy.<PlaySetBattleTween>d__24 <PlaySetBattleTween>d__;
			<PlaySetBattleTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySetBattleTween>d__.<>4__this = this;
			<PlaySetBattleTween>d__.fromItem = fromItem;
			<PlaySetBattleTween>d__.<>1__state = -1;
			<PlaySetBattleTween>d__.<>t__builder.Start<OpponentFunctionAreaProxy.<PlaySetBattleTween>d__24>(ref <PlaySetBattleTween>d__);
			return <PlaySetBattleTween>d__.<>t__builder.Task;
		}

		// Token: 0x060380F7 RID: 229623 RVA: 0x00E33B2C File Offset: 0x00E31D2C
		public UniTask PlayChangeCardTween(UUIItem fromItem)
		{
			OpponentFunctionAreaProxy.<PlayChangeCardTween>d__25 <PlayChangeCardTween>d__;
			<PlayChangeCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayChangeCardTween>d__.<>4__this = this;
			<PlayChangeCardTween>d__.fromItem = fromItem;
			<PlayChangeCardTween>d__.<>1__state = -1;
			<PlayChangeCardTween>d__.<>t__builder.Start<OpponentFunctionAreaProxy.<PlayChangeCardTween>d__25>(ref <PlayChangeCardTween>d__);
			return <PlayChangeCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x060380F8 RID: 229624 RVA: 0x00E33B78 File Offset: 0x00E31D78
		public UniTask PlayBackToRecycleTween()
		{
			OpponentFunctionAreaProxy.<PlayBackToRecycleTween>d__26 <PlayBackToRecycleTween>d__;
			<PlayBackToRecycleTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayBackToRecycleTween>d__.<>4__this = this;
			<PlayBackToRecycleTween>d__.<>1__state = -1;
			<PlayBackToRecycleTween>d__.<>t__builder.Start<OpponentFunctionAreaProxy.<PlayBackToRecycleTween>d__26>(ref <PlayBackToRecycleTween>d__);
			return <PlayBackToRecycleTween>d__.<>t__builder.Task;
		}

		// Token: 0x060380F9 RID: 229625
		protected abstract UUIItem GetCardAttachItem();

		// Token: 0x060380FA RID: 229626 RVA: 0x00E33BBC File Offset: 0x00E31DBC
		public void PointerClickCard(int id, EToggleState state)
		{
			if (this.UiInteract == null)
			{
				if (this.Card != null)
				{
					this.ParentArea.ParentArea.ViewProxy.ShowCardTips(this.Card.Data, true);
					this.ParentArea.ParentArea.ViewProxy.SetSelectedCardId(id, EPhantomArenaCardClickFromType.OpponentFunctional);
				}
				return;
			}
			bool flag = !this.IsInSkillPoint;
			if (!this.UiInteract.ReceiveClickData(ESkillInteractMainUiInteractType.MonsterBattleCard, new object[]
			{
				id,
				this.Index,
				flag
			}))
			{
				PhantomArenaCard card = this.Card;
				if (card == null)
				{
					return;
				}
				card.SetToggleState(EToggleState.ETT_UnChecked, false);
				return;
			}
			else if (flag)
			{
				this.IsInSkillPoint = true;
				PhantomArenaCard card2 = this.Card;
				if (card2 == null)
				{
					return;
				}
				card2.PlaySequence("Point", false);
				return;
			}
			else
			{
				this.IsInSkillPoint = false;
				PhantomArenaCard card3 = this.Card;
				if (card3 == null)
				{
					return;
				}
				card3.PlaySequence("PointClose", false);
				return;
			}
		}

		// Token: 0x060380FB RID: 229627 RVA: 0x00E33CA4 File Offset: 0x00E31EA4
		public void PointerEnterCard(int id)
		{
		}

		// Token: 0x060380FC RID: 229628 RVA: 0x00E33CA6 File Offset: 0x00E31EA6
		public void PointerDownCard(int id, ULGUIPointerEventData eventData)
		{
		}

		// Token: 0x060380FD RID: 229629 RVA: 0x00E33CA8 File Offset: 0x00E31EA8
		public bool CheckCanvasSortOrder(List<EPhantomArenaInteractTag> tagList, ISkillTriggerInfo skillTriggerInfo)
		{
			return this.Card != null && skillTriggerInfo.SelectFightIdList.Contains(this.Card.Data.FightId) && tagList.Contains(EPhantomArenaInteractTag.OpponentAreaMonster) && this.IsMonster;
		}

		// Token: 0x060380FE RID: 229630 RVA: 0x00E33CE7 File Offset: 0x00E31EE7
		public void HandleSortOrder()
		{
			if (this.Card != null)
			{
				this.Card.OverrideCanvasSortOrder(true);
				this.Card.PlayStateSequence("PointStart");
				this.IsInSkillInteract = true;
			}
		}

		// Token: 0x060380FF RID: 229631 RVA: 0x00E33D14 File Offset: 0x00E31F14
		public void CancelSortOrder()
		{
			if (this.Card != null)
			{
				this.Card.OverrideCanvasSortOrder(false);
				this.Card.PlayStateSequence("PointClose");
				if (this.Card.GetToggleState() == EToggleState.ETT_Checked)
				{
					this.Card.SetToggleState(EToggleState.ETT_UnChecked, false);
				}
				if (this.IsInSkillPoint)
				{
					this.Card.PlaySequence("PointClose", false);
				}
				this.IsInSkillPoint = false;
				this.IsInSkillInteract = false;
			}
		}

		// Token: 0x06038100 RID: 229632 RVA: 0x00E33D87 File Offset: 0x00E31F87
		[NullableContext(2)]
		public void ReceiveUiInteract(ISkillInteractMainUiInteract uiInteract)
		{
			this.UiInteract = uiInteract;
		}

		// Token: 0x040200D2 RID: 131282
		protected OpponentFunctionArea ParentArea;

		// Token: 0x040200D4 RID: 131284
		public PhantomArenaCard Card;

		// Token: 0x040200D5 RID: 131285
		public int Index = -1;

		// Token: 0x040200D6 RID: 131286
		[Nullable(2)]
		private ISkillInteractMainUiInteract UiInteract;

		// Token: 0x040200D7 RID: 131287
		private bool IsInSkillPoint;

		// Token: 0x040200D8 RID: 131288
		public bool IsInSkillInteract;
	}
}
