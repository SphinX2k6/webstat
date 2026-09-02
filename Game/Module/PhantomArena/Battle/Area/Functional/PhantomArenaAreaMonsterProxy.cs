using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena.Battle.Canvas;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Module.PhantomArena.Battle.Card.Logic;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Area.Functional
{
	// Token: 0x02005635 RID: 22069
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaAreaMonsterProxy : PhantomArenaAreaProxyBase, IPhantomCardProxy, IPhantomCardProxyBase, IPhantomCardDragProxy, IAreaCanvas, ISkillInteractMainInterface
	{
		// Token: 0x1700906F RID: 36975
		// (get) Token: 0x0603842D RID: 230445 RVA: 0x00E3EC87 File Offset: 0x00E3CE87
		// (set) Token: 0x0603842E RID: 230446 RVA: 0x00E3EC94 File Offset: 0x00E3CE94
		public new PhantomArenaAreaMonsterItem AreaItem
		{
			get
			{
				return base.AreaItem as PhantomArenaAreaMonsterItem;
			}
			set
			{
				base.AreaItem = value;
			}
		}

		// Token: 0x17009070 RID: 36976
		// (get) Token: 0x0603842F RID: 230447 RVA: 0x00E3EC9D File Offset: 0x00E3CE9D
		public override EPhantomArenaCardAreaType AreaType
		{
			get
			{
				return EPhantomArenaCardAreaType.Monster;
			}
		}

		// Token: 0x06038430 RID: 230448 RVA: 0x00E3ECA0 File Offset: 0x00E3CEA0
		public PhantomArenaAreaMonsterProxy(int index, PhantomArenaFunctionalArea area) : base(index, area)
		{
		}

		// Token: 0x06038431 RID: 230449 RVA: 0x00E3ECAC File Offset: 0x00E3CEAC
		protected bool CheckEvolveGuideCondition(int cardId, int battleIndex)
		{
			if (battleIndex == -1)
			{
				int handIndexByCardId = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetHandIndexByCardId(cardId);
				return this.ParentArea.ParentArea.ViewProxy.GuideManager.CheckCanExecuteAndShowFailTips(EBvbPlayerOperationType.BvbEvolution, new object[]
				{
					handIndexByCardId,
					this.Index
				});
			}
			return true;
		}

		// Token: 0x06038432 RID: 230450 RVA: 0x00E3ED08 File Offset: 0x00E3CF08
		protected bool CheckSettingGuideCondition(int cardId, int battleIndex)
		{
			if (battleIndex == -1)
			{
				int handIndexByCardId = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetHandIndexByCardId(cardId);
				return this.ParentArea.ParentArea.ViewProxy.GuideManager.CheckCanExecuteAndShowFailTips(EBvbPlayerOperationType.BvbDeploy, new object[]
				{
					handIndexByCardId,
					this.Index
				});
			}
			return true;
		}

		// Token: 0x06038433 RID: 230451 RVA: 0x00E3ED64 File Offset: 0x00E3CF64
		public override bool CheckGuideCondition(PhantomArenaCard card)
		{
			if (this.Card != null && card != null && this.Card != card)
			{
				return this.CheckEvolveGuideCondition(card.Data.CardId, card.Data.Index);
			}
			return this.CheckSettingGuideCondition(card.Data.CardId, card.Data.Index);
		}

		// Token: 0x06038434 RID: 230452 RVA: 0x00E3EDC0 File Offset: 0x00E3CFC0
		public override bool CheckSettingCardCondition(PhantomArenaCard card)
		{
			bool flag;
			EPhantomCardSettingFailReason ephantomCardSettingFailReason;
			card.CardLogic.CheckMonsterSettingCondition(this.Card).Deconstruct(out flag, out ephantomCardSettingFailReason);
			bool result = flag;
			EPhantomCardSettingFailReason settingFailReason = ephantomCardSettingFailReason;
			this.SettingFailReason = settingFailReason;
			return result;
		}

		// Token: 0x06038435 RID: 230453 RVA: 0x00E3EDF4 File Offset: 0x00E3CFF4
		[NullableContext(0)]
		protected UniTask<bool> OnHandleAreaByEvolve([Nullable(1)] PhantomArenaCard card)
		{
			PhantomArenaAreaMonsterProxy.<OnHandleAreaByEvolve>d__14 <OnHandleAreaByEvolve>d__;
			<OnHandleAreaByEvolve>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnHandleAreaByEvolve>d__.<>4__this = this;
			<OnHandleAreaByEvolve>d__.card = card;
			<OnHandleAreaByEvolve>d__.<>1__state = -1;
			<OnHandleAreaByEvolve>d__.<>t__builder.Start<PhantomArenaAreaMonsterProxy.<OnHandleAreaByEvolve>d__14>(ref <OnHandleAreaByEvolve>d__);
			return <OnHandleAreaByEvolve>d__.<>t__builder.Task;
		}

		// Token: 0x06038436 RID: 230454 RVA: 0x00E3EE40 File Offset: 0x00E3D040
		[NullableContext(0)]
		protected UniTask<bool> OnHandleAreaBySetCard([Nullable(1)] PhantomArenaCard card)
		{
			PhantomArenaAreaMonsterProxy.<OnHandleAreaBySetCard>d__15 <OnHandleAreaBySetCard>d__;
			<OnHandleAreaBySetCard>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnHandleAreaBySetCard>d__.<>4__this = this;
			<OnHandleAreaBySetCard>d__.card = card;
			<OnHandleAreaBySetCard>d__.<>1__state = -1;
			<OnHandleAreaBySetCard>d__.<>t__builder.Start<PhantomArenaAreaMonsterProxy.<OnHandleAreaBySetCard>d__15>(ref <OnHandleAreaBySetCard>d__);
			return <OnHandleAreaBySetCard>d__.<>t__builder.Task;
		}

		// Token: 0x06038437 RID: 230455 RVA: 0x00E3EE8C File Offset: 0x00E3D08C
		[NullableContext(0)]
		protected override UniTask<bool> OnHandleCardSetting([Nullable(1)] PhantomArenaCard card)
		{
			PhantomArenaAreaMonsterProxy.<OnHandleCardSetting>d__16 <OnHandleCardSetting>d__;
			<OnHandleCardSetting>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnHandleCardSetting>d__.<>4__this = this;
			<OnHandleCardSetting>d__.card = card;
			<OnHandleCardSetting>d__.<>1__state = -1;
			<OnHandleCardSetting>d__.<>t__builder.Start<PhantomArenaAreaMonsterProxy.<OnHandleCardSetting>d__16>(ref <OnHandleCardSetting>d__);
			return <OnHandleCardSetting>d__.<>t__builder.Task;
		}

		// Token: 0x06038438 RID: 230456 RVA: 0x00E3EED7 File Offset: 0x00E3D0D7
		protected override UUIItem GetCardRootItem()
		{
			return this.AreaItem.GetCardRootItem();
		}

		// Token: 0x06038439 RID: 230457 RVA: 0x00E3EEE4 File Offset: 0x00E3D0E4
		public override UniTask SetCard(PhantomArenaCard card)
		{
			PhantomArenaAreaMonsterProxy.<SetCard>d__18 <SetCard>d__;
			<SetCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetCard>d__.<>4__this = this;
			<SetCard>d__.card = card;
			<SetCard>d__.<>1__state = -1;
			<SetCard>d__.<>t__builder.Start<PhantomArenaAreaMonsterProxy.<SetCard>d__18>(ref <SetCard>d__);
			return <SetCard>d__.<>t__builder.Task;
		}

		// Token: 0x0603843A RID: 230458 RVA: 0x00E3EF30 File Offset: 0x00E3D130
		public UniTask CopyCard(PhantomCardData cardData)
		{
			PhantomArenaAreaMonsterProxy.<CopyCard>d__19 <CopyCard>d__;
			<CopyCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CopyCard>d__.<>4__this = this;
			<CopyCard>d__.cardData = cardData;
			<CopyCard>d__.<>1__state = -1;
			<CopyCard>d__.<>t__builder.Start<PhantomArenaAreaMonsterProxy.<CopyCard>d__19>(ref <CopyCard>d__);
			return <CopyCard>d__.<>t__builder.Task;
		}

		// Token: 0x0603843B RID: 230459 RVA: 0x00E3EF7C File Offset: 0x00E3D17C
		public void PointerClickCard(int id, EToggleState state)
		{
			if (this.UiInteract == null)
			{
				if (this.Card != null)
				{
					this.ParentArea.ParentArea.ViewProxy.ShowCardTips(this.Card.Data, true);
					this.ParentArea.ParentArea.ViewProxy.SetSelectedCardId(id, EPhantomArenaCardClickFromType.OwnFunctional);
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

		// Token: 0x0603843C RID: 230460 RVA: 0x00E3F064 File Offset: 0x00E3D264
		public void PointerEnterCard(int id)
		{
		}

		// Token: 0x0603843D RID: 230461 RVA: 0x00E3F066 File Offset: 0x00E3D266
		public void PointerDownCard(int id, ULGUIPointerEventData eventData)
		{
			this.IsCanDrag = this.IsCanDragCard(id);
			if (!this.IsCanDrag)
			{
				return;
			}
			PhantomArenaCard card = this.Card;
			if (card == null)
			{
				return;
			}
			card.RecordLastDragPos(eventData.pointerPosition);
		}

		// Token: 0x0603843E RID: 230462 RVA: 0x00E3F094 File Offset: 0x00E3D294
		private bool IsCanDragCard(int id)
		{
			return !this.IsInCardTween && !ModelBase<PhantomArenaBattleModel>.Instance.InWaitReconstructCardIdList(id) && this.ParentArea.ParentArea.IsCanDragCard(id);
		}

		// Token: 0x0603843F RID: 230463 RVA: 0x00E3F0C0 File Offset: 0x00E3D2C0
		public void PointerBeginDrag(int id, ULGUIPointerEventData eventData)
		{
			if (this.Card == null)
			{
				return;
			}
			if (!this.IsCanDrag)
			{
				return;
			}
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "开始拖动手牌", default(ReadOnlySpan<ValueTuple<string, object>>));
			PhantomArenaCard card = this.Card;
			if (card != null)
			{
				card.PlayStateSequence("SeleStart");
			}
			this.ParentArea.ParentArea.CardBeginDragByFunctional(this.Card);
			this.Card.PlaySequence("DragUpTabletoHand", false);
		}

		// Token: 0x06038440 RID: 230464 RVA: 0x00E3F13C File Offset: 0x00E3D33C
		public void PointerDragCard(int id, ULGUIPointerEventData eventData)
		{
			if (this.Card == null)
			{
				return;
			}
			if (!this.IsCanDrag)
			{
				return;
			}
			FVector pointerPosition = eventData.pointerPosition;
			this.Card.MoveCard(pointerPosition);
			this.ParentArea.ParentArea.CardDraggingByFunctional(this);
		}

		// Token: 0x06038441 RID: 230465 RVA: 0x00E3F17F File Offset: 0x00E3D37F
		public void PointerEndDrag(int id, ULGUIPointerEventData eventData)
		{
			if (this.Card == null)
			{
				return;
			}
			if (!this.IsCanDrag)
			{
				return;
			}
			this.ParentArea.ParentArea.CardEndDragByFunctional(this.Card, this.Index).Forget<bool>();
		}

		// Token: 0x06038442 RID: 230466 RVA: 0x00E3F1B4 File Offset: 0x00E3D3B4
		public bool CheckCanvasSortOrder(List<EPhantomArenaInteractTag> tagList, ISkillTriggerInfo skillTriggerInfo)
		{
			return this.Card != null && skillTriggerInfo.SelectFightIdList.Contains(this.Card.Data.FightId) && tagList.Contains(EPhantomArenaInteractTag.OwnMonster);
		}

		// Token: 0x06038443 RID: 230467 RVA: 0x00E3F1EB File Offset: 0x00E3D3EB
		public void HandleSortOrder()
		{
			if (this.Card != null)
			{
				this.Card.OverrideCanvasSortOrder(true);
				this.Card.PlayStateSequence("PointStart");
				this.IsInSkillInteract = true;
			}
		}

		// Token: 0x06038444 RID: 230468 RVA: 0x00E3F218 File Offset: 0x00E3D418
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

		// Token: 0x06038445 RID: 230469 RVA: 0x00E3F28B File Offset: 0x00E3D48B
		[NullableContext(2)]
		public void ReceiveUiInteract(ISkillInteractMainUiInteract uiInteract)
		{
			this.UiInteract = uiInteract;
		}

		// Token: 0x06038446 RID: 230470 RVA: 0x00E3F294 File Offset: 0x00E3D494
		public UniTask StartSkillInteract()
		{
			PhantomArenaAreaMonsterProxy.<StartSkillInteract>d__31 <StartSkillInteract>d__;
			<StartSkillInteract>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartSkillInteract>d__.<>4__this = this;
			<StartSkillInteract>d__.<>1__state = -1;
			<StartSkillInteract>d__.<>t__builder.Start<PhantomArenaAreaMonsterProxy.<StartSkillInteract>d__31>(ref <StartSkillInteract>d__);
			return <StartSkillInteract>d__.<>t__builder.Task;
		}

		// Token: 0x06038447 RID: 230471 RVA: 0x00E3F2D7 File Offset: 0x00E3D4D7
		public void CancelSkillInteract()
		{
			this.AreaItem.SetIncreaseActive(false).Forget();
		}

		// Token: 0x06038448 RID: 230472 RVA: 0x00E3F2EA File Offset: 0x00E3D4EA
		public void FinishSkillInteract()
		{
			this.AreaItem.SetIncreaseActive(false).Forget();
			PhantomArenaCard card = this.Card;
			if (card == null)
			{
				return;
			}
			PhantomArenaCardLogic cardLogic = card.CardLogic;
			if (cardLogic == null)
			{
				return;
			}
			cardLogic.TryFinishCurrentGuide();
		}

		// Token: 0x06038449 RID: 230473 RVA: 0x00E3F317 File Offset: 0x00E3D517
		public ISkillTriggerInfo GetData()
		{
			return ModelBase<PhantomArenaBattleModel>.Instance.BuffEffectData.CardSkillTriggerInfo;
		}

		// Token: 0x040201D0 RID: 131536
		[Nullable(2)]
		private ISkillInteractMainUiInteract UiInteract;

		// Token: 0x040201D1 RID: 131537
		private bool IsCanDrag;

		// Token: 0x040201D2 RID: 131538
		private bool IsInSkillPoint;

		// Token: 0x040201D3 RID: 131539
		public bool IsInSkillInteract;
	}
}
