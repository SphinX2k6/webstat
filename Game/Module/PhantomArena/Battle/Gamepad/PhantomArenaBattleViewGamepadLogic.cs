using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Area.Functional;
using CSharpScript.Game.Module.PhantomArena.Battle.Area.Hand;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Module.PhantomArena.Battle.Opponent;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Gamepad
{
	// Token: 0x0200561A RID: 22042
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleViewGamepadLogic
	{
		// Token: 0x1700906A RID: 36970
		// (get) Token: 0x060382C0 RID: 230080 RVA: 0x00E397FE File Offset: 0x00E379FE
		public bool IsInHandCardSelectState
		{
			get
			{
				return this.SelectedCard != null && this.SelectedCard.Data.Index == -1;
			}
		}

		// Token: 0x1700906B RID: 36971
		// (get) Token: 0x060382C1 RID: 230081 RVA: 0x00E3981D File Offset: 0x00E37A1D
		public bool IsInBattleCardSelectState
		{
			get
			{
				return this.SelectedCard != null && this.SelectedCard.Data.Index != -1;
			}
		}

		// Token: 0x1700906C RID: 36972
		// (get) Token: 0x060382C2 RID: 230082 RVA: 0x00E3983F File Offset: 0x00E37A3F
		public bool IsInCardSelectState
		{
			get
			{
				return this.IsInHandCardSelectState || this.IsInBattleCardSelectState;
			}
		}

		// Token: 0x060382C3 RID: 230083 RVA: 0x00E39851 File Offset: 0x00E37A51
		public PhantomArenaBattleViewGamepadLogic(PhantomArenaBattleProxy proxy)
		{
			this.Proxy = proxy;
		}

		// Token: 0x060382C4 RID: 230084 RVA: 0x00E3986E File Offset: 0x00E37A6E
		private void ClearSelectedCard()
		{
			this.SelectedCard = null;
			this.SlotIndex = -1;
			this.HandIndex = -1;
			this.Proxy.OwnArea.FunctionalArea.ResetLastProxyIndexByGamepad();
		}

		// Token: 0x060382C5 RID: 230085 RVA: 0x00E3989C File Offset: 0x00E37A9C
		private UniTask SetSelectedCardByHand(PhantomArenaCard card, int index)
		{
			PhantomArenaBattleViewGamepadLogic.<SetSelectedCardByHand>d__14 <SetSelectedCardByHand>d__;
			<SetSelectedCardByHand>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetSelectedCardByHand>d__.<>4__this = this;
			<SetSelectedCardByHand>d__.card = card;
			<SetSelectedCardByHand>d__.index = index;
			<SetSelectedCardByHand>d__.<>1__state = -1;
			<SetSelectedCardByHand>d__.<>t__builder.Start<PhantomArenaBattleViewGamepadLogic.<SetSelectedCardByHand>d__14>(ref <SetSelectedCardByHand>d__);
			return <SetSelectedCardByHand>d__.<>t__builder.Task;
		}

		// Token: 0x060382C6 RID: 230086 RVA: 0x00E398F0 File Offset: 0x00E37AF0
		private UniTask SetSelectedCardByFunctional(PhantomArenaCard card, int index)
		{
			PhantomArenaBattleViewGamepadLogic.<SetSelectedCardByFunctional>d__15 <SetSelectedCardByFunctional>d__;
			<SetSelectedCardByFunctional>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetSelectedCardByFunctional>d__.<>4__this = this;
			<SetSelectedCardByFunctional>d__.card = card;
			<SetSelectedCardByFunctional>d__.index = index;
			<SetSelectedCardByFunctional>d__.<>1__state = -1;
			<SetSelectedCardByFunctional>d__.<>t__builder.Start<PhantomArenaBattleViewGamepadLogic.<SetSelectedCardByFunctional>d__15>(ref <SetSelectedCardByFunctional>d__);
			return <SetSelectedCardByFunctional>d__.<>t__builder.Task;
		}

		// Token: 0x060382C7 RID: 230087 RVA: 0x00E39944 File Offset: 0x00E37B44
		private UniTask ExecuteHandCardToRecycle(PhantomArenaCard card)
		{
			PhantomArenaBattleViewGamepadLogic.<ExecuteHandCardToRecycle>d__16 <ExecuteHandCardToRecycle>d__;
			<ExecuteHandCardToRecycle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteHandCardToRecycle>d__.<>4__this = this;
			<ExecuteHandCardToRecycle>d__.card = card;
			<ExecuteHandCardToRecycle>d__.<>1__state = -1;
			<ExecuteHandCardToRecycle>d__.<>t__builder.Start<PhantomArenaBattleViewGamepadLogic.<ExecuteHandCardToRecycle>d__16>(ref <ExecuteHandCardToRecycle>d__);
			return <ExecuteHandCardToRecycle>d__.<>t__builder.Task;
		}

		// Token: 0x060382C8 RID: 230088 RVA: 0x00E39990 File Offset: 0x00E37B90
		private UniTask ExecuteFunctionalCardToRecycle(PhantomArenaCard card)
		{
			PhantomArenaBattleViewGamepadLogic.<ExecuteFunctionalCardToRecycle>d__17 <ExecuteFunctionalCardToRecycle>d__;
			<ExecuteFunctionalCardToRecycle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteFunctionalCardToRecycle>d__.<>4__this = this;
			<ExecuteFunctionalCardToRecycle>d__.card = card;
			<ExecuteFunctionalCardToRecycle>d__.<>1__state = -1;
			<ExecuteFunctionalCardToRecycle>d__.<>t__builder.Start<PhantomArenaBattleViewGamepadLogic.<ExecuteFunctionalCardToRecycle>d__17>(ref <ExecuteFunctionalCardToRecycle>d__);
			return <ExecuteFunctionalCardToRecycle>d__.<>t__builder.Task;
		}

		// Token: 0x060382C9 RID: 230089 RVA: 0x00E399DB File Offset: 0x00E37BDB
		private void SetOwnBattleShowTipsCard(PhantomArenaCard card)
		{
			if (card == null)
			{
				this.CancelOwnBattleShowTipsCard();
				return;
			}
			this.OwnBattleShowTipsCard = card;
			card.SetSelectedStateByGamepad(true);
		}

		// Token: 0x060382CA RID: 230090 RVA: 0x00E399F5 File Offset: 0x00E37BF5
		private void CancelOwnBattleShowTipsCard()
		{
			if (this.OwnBattleShowTipsCard != null)
			{
				this.OwnBattleShowTipsCard.SetSelectedStateByGamepad(false);
				this.OwnBattleShowTipsCard = null;
			}
		}

		// Token: 0x060382CB RID: 230091 RVA: 0x00E39A14 File Offset: 0x00E37C14
		public void CancelSelectedCard()
		{
			if (this.SelectedCard == null)
			{
				return;
			}
			if (this.SelectedCard.Data.Index == -1)
			{
				this.Proxy.OwnArea.ResetSelectCardToHand(this.SelectedCard, this.SlotIndex).Forget();
			}
			else
			{
				this.Proxy.OwnArea.ResetSelectCardToFunctional(this.SelectedCard, this.SlotIndex).Forget();
			}
			this.ClearSelectedCard();
		}

		// Token: 0x060382CC RID: 230092 RVA: 0x00E39A87 File Offset: 0x00E37C87
		public void ResetGamepadOperation()
		{
			this.CancelSelectedCard();
			this.CancelOwnBattleShowTipsCard();
		}

		// Token: 0x060382CD RID: 230093 RVA: 0x00E39A95 File Offset: 0x00E37C95
		public void SwitchCardLayoutHoist()
		{
			this.Proxy.OwnArea.HandArea.SwitchLayoutHoist();
		}

		// Token: 0x060382CE RID: 230094 RVA: 0x00E39AAC File Offset: 0x00E37CAC
		public void TriggerRecycleCard()
		{
			if (this.SelectedCard == null)
			{
				return;
			}
			if (this.SelectedCard.Data.Index == -1)
			{
				this.ExecuteHandCardToRecycle(this.SelectedCard).Forget();
				this.ClearSelectedCard();
				return;
			}
			this.ExecuteFunctionalCardToRecycle(this.SelectedCard).Forget();
			this.ClearSelectedCard();
		}

		// Token: 0x060382CF RID: 230095 RVA: 0x00E39B04 File Offset: 0x00E37D04
		[NullableContext(0)]
		public UniTask<bool> SelectHandCard(int index)
		{
			PhantomArenaBattleViewGamepadLogic.<SelectHandCard>d__24 <SelectHandCard>d__;
			<SelectHandCard>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<SelectHandCard>d__.<>4__this = this;
			<SelectHandCard>d__.index = index;
			<SelectHandCard>d__.<>1__state = -1;
			<SelectHandCard>d__.<>t__builder.Start<PhantomArenaBattleViewGamepadLogic.<SelectHandCard>d__24>(ref <SelectHandCard>d__);
			return <SelectHandCard>d__.<>t__builder.Task;
		}

		// Token: 0x060382D0 RID: 230096 RVA: 0x00E39B50 File Offset: 0x00E37D50
		[NullableContext(0)]
		public UniTask<bool> SelectBattleCard(int index)
		{
			PhantomArenaBattleViewGamepadLogic.<SelectBattleCard>d__25 <SelectBattleCard>d__;
			<SelectBattleCard>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<SelectBattleCard>d__.<>4__this = this;
			<SelectBattleCard>d__.index = index;
			<SelectBattleCard>d__.<>1__state = -1;
			<SelectBattleCard>d__.<>t__builder.Start<PhantomArenaBattleViewGamepadLogic.<SelectBattleCard>d__25>(ref <SelectBattleCard>d__);
			return <SelectBattleCard>d__.<>t__builder.Task;
		}

		// Token: 0x060382D1 RID: 230097 RVA: 0x00E39B9C File Offset: 0x00E37D9C
		public UniTask MoveHandCardToFunctional(int index)
		{
			PhantomArenaBattleViewGamepadLogic.<MoveHandCardToFunctional>d__26 <MoveHandCardToFunctional>d__;
			<MoveHandCardToFunctional>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<MoveHandCardToFunctional>d__.<>4__this = this;
			<MoveHandCardToFunctional>d__.index = index;
			<MoveHandCardToFunctional>d__.<>1__state = -1;
			<MoveHandCardToFunctional>d__.<>t__builder.Start<PhantomArenaBattleViewGamepadLogic.<MoveHandCardToFunctional>d__26>(ref <MoveHandCardToFunctional>d__);
			return <MoveHandCardToFunctional>d__.<>t__builder.Task;
		}

		// Token: 0x060382D2 RID: 230098 RVA: 0x00E39BE8 File Offset: 0x00E37DE8
		public UniTask MoveBattleCardToFunctional(int index)
		{
			PhantomArenaBattleViewGamepadLogic.<MoveBattleCardToFunctional>d__27 <MoveBattleCardToFunctional>d__;
			<MoveBattleCardToFunctional>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<MoveBattleCardToFunctional>d__.<>4__this = this;
			<MoveBattleCardToFunctional>d__.index = index;
			<MoveBattleCardToFunctional>d__.<>1__state = -1;
			<MoveBattleCardToFunctional>d__.<>t__builder.Start<PhantomArenaBattleViewGamepadLogic.<MoveBattleCardToFunctional>d__27>(ref <MoveBattleCardToFunctional>d__);
			return <MoveBattleCardToFunctional>d__.<>t__builder.Task;
		}

		// Token: 0x060382D3 RID: 230099 RVA: 0x00E39C34 File Offset: 0x00E37E34
		[NullableContext(0)]
		public UniTask<bool> PutDownCardToFunctional()
		{
			PhantomArenaBattleViewGamepadLogic.<PutDownCardToFunctional>d__28 <PutDownCardToFunctional>d__;
			<PutDownCardToFunctional>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PutDownCardToFunctional>d__.<>4__this = this;
			<PutDownCardToFunctional>d__.<>1__state = -1;
			<PutDownCardToFunctional>d__.<>t__builder.Start<PhantomArenaBattleViewGamepadLogic.<PutDownCardToFunctional>d__28>(ref <PutDownCardToFunctional>d__);
			return <PutDownCardToFunctional>d__.<>t__builder.Task;
		}

		// Token: 0x060382D4 RID: 230100 RVA: 0x00E39C78 File Offset: 0x00E37E78
		public void SwitchHandCardTips(int index)
		{
			PhantomArenaHandCardProxy cardProxyByIndex = this.Proxy.OwnArea.HandArea.GetCardProxyByIndex(index);
			if (cardProxyByIndex == null)
			{
				return;
			}
			this.Proxy.SwitchCardTips(cardProxyByIndex.GetCard().Data);
		}

		// Token: 0x060382D5 RID: 230101 RVA: 0x00E39CB8 File Offset: 0x00E37EB8
		public void SwitchOwnBattleCardTips(int index)
		{
			PhantomArenaAreaProxyBase cardProxyByIndex = this.Proxy.OwnArea.FunctionalArea.GetCardProxyByIndex(index);
			if (cardProxyByIndex == null || cardProxyByIndex.Card == null)
			{
				return;
			}
			this.SetOwnBattleShowTipsCard(this.Proxy.SwitchCardTips(cardProxyByIndex.Card.Data) ? cardProxyByIndex.Card : null);
		}

		// Token: 0x060382D6 RID: 230102 RVA: 0x00E39D14 File Offset: 0x00E37F14
		public void SwitchOpponentBattleCardTips(int index)
		{
			OpponentFunctionAreaProxy cardProxyByIndex = this.Proxy.OpponentArea.FunctionalArea.GetCardProxyByIndex(index);
			if (cardProxyByIndex == null || cardProxyByIndex.Card == null)
			{
				return;
			}
			this.Proxy.SwitchCardTips(cardProxyByIndex.Card.Data);
		}

		// Token: 0x060382D7 RID: 230103 RVA: 0x00E39D5B File Offset: 0x00E37F5B
		public void HideCardTips()
		{
			this.Proxy.HideCardTips();
			this.CancelOwnBattleShowTipsCard();
		}

		// Token: 0x060382D8 RID: 230104 RVA: 0x00E39D70 File Offset: 0x00E37F70
		public bool IsInSkillInteractByOpponentIndex(int index)
		{
			OpponentFunctionAreaProxy cardProxyByIndex = this.Proxy.OpponentArea.FunctionalArea.GetCardProxyByIndex(index);
			return cardProxyByIndex != null && cardProxyByIndex.Card != null && cardProxyByIndex.IsInSkillInteract;
		}

		// Token: 0x060382D9 RID: 230105 RVA: 0x00E39DA8 File Offset: 0x00E37FA8
		public bool IsInSkillInteractByOwnIndex(int index)
		{
			PhantomArenaAreaProxyBase cardProxyByIndex = this.Proxy.OwnArea.FunctionalArea.GetCardProxyByIndex(index);
			return cardProxyByIndex != null && (cardProxyByIndex as PhantomArenaAreaMonsterProxy).IsInSkillInteract;
		}

		// Token: 0x0402016B RID: 131435
		public PhantomArenaCard SelectedCard;

		// Token: 0x0402016C RID: 131436
		public int SlotIndex = -1;

		// Token: 0x0402016D RID: 131437
		public int HandIndex = -1;

		// Token: 0x0402016E RID: 131438
		private bool InPutDownTween;

		// Token: 0x0402016F RID: 131439
		public PhantomArenaCard OwnBattleShowTipsCard;

		// Token: 0x04020170 RID: 131440
		protected PhantomArenaBattleProxy Proxy;
	}
}
