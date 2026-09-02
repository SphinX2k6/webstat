using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020010F0 RID: 4336
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerAiPlayCardTask : GuessJokerTaskBase
{
	// Token: 0x060070F8 RID: 28920 RVA: 0x001D82DC File Offset: 0x001D64DC
	public GuessJokerAiPlayCardTask(JokerGuessPlayCardAction data)
	{
		if (data.PlayCard != null)
		{
			foreach (int item in data.PlayCard.CardIds)
			{
				this.CardIdList.Add(item);
			}
		}
	}

	// Token: 0x060070F9 RID: 28921 RVA: 0x001D834C File Offset: 0x001D654C
	protected override void OnExecute()
	{
		int roundNumber = ModelBase<GuessJokerGamePlayModel>.Instance.RoundNumber;
		if (this.CardIdList.Count == 0)
		{
			if (roundNumber != 0 || ModelBase<GuessJokerGamePlayModel>.Instance.ShowInitialNoPairTip)
			{
				ControllerBase<GuessJokerController>.Instance.OpenGuessJokerFloatTipsView("GuessJoker_Ai_NoPlayCard", null);
			}
			this.FinishWithShuffleCheck();
			return;
		}
		GuessJokerGamePlayView gameplayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		Singleton<Log>.Instance.Info(ELogModule.GuessJokerCard, ELogAuthor.LRC, string.Format("Ai出牌：{0}", string.Join<int>(",", this.CardIdList)), default(ReadOnlySpan<ValueTuple<string, object>>));
		List<GuessJokerActionBase> list = new List<GuessJokerActionBase>();
		if (roundNumber == 0)
		{
			gameplayView.UpdateCurrentPlayer(EGuessJokerPlayerType.Ai);
			list.Add(new GuessJokerRoundStartTipAction(EGuessJokerPlayerType.Ai));
		}
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		if (instance != null)
		{
			instance.UpdateCardBelongPlayerType(this.CardIdList.ToArray(), null);
		}
		bool flag = ModelBase<GuessJokerGamePlayModel>.Instance.GetHandCardsByPlayer(EGuessJokerPlayerType.Ai).Count == 0;
		list.Add(new GuessJokerCallbackAction(delegate()
		{
			gameplayView.SetPositionPanelCardsDark(ECardPositionType.PlayerHand, true, null);
		}));
		list.Add(new GuessJokerShowCardsAction(this.CardIdList.ToArray(), true, 0f));
		list.Add(new GuessJokerCallbackAction(delegate()
		{
		}));
		list.Add(new GuessJokerGroupAction(new GuessJokerActionBase[]
		{
			new GuessJokerMoveCardsAction(this.CardIdList.ToArray(), ECardPositionType.Middle),
			new GuessJokerCollectCardsAction(EGuessJokerPlayerType.Ai, ECardPositionType.AiHand)
		}));
		if (flag)
		{
			list.Add(new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
			{
				gameplayView.ShowWinLoseReasonTip(EGuessJokerPlayerType.Ai, "GuessJoker_PlayAllCardsTipText", true, delegate
				{
					complete();
					this.FinishTask();
				});
			}));
		}
		else
		{
			list.Add(new GuessJokerRemoveMiddleCardsAction(0f));
			list.Add(new GuessJokerCallbackAction(delegate()
			{
				gameplayView.SetPositionPanelCardsDark(ECardPositionType.PlayerHand, false, null);
			}));
			list.Add(new GuessJokerCallbackAction(delegate()
			{
				ModelBase<GuessJokerGamePlayModel>.Instance.UpdateNpcIdleState();
				this.FinishWithShuffleCheck();
			}));
		}
		ModelBase<GuessJokerGamePlayModel>.Instance.PushActions(list.ToArray());
	}

	// Token: 0x060070FA RID: 28922 RVA: 0x001D853C File Offset: 0x001D673C
	private void FinishWithShuffleCheck()
	{
		if (ModelBase<GuessJokerGamePlayModel>.Instance.HasAiNewCardInHand())
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.PushActions(new GuessJokerActionBase[]
			{
				new GuessJokerCollectCardsAction(EGuessJokerPlayerType.Ai, ECardPositionType.AiHand),
				new GuessJokerShuffleCardsAction(ECardPositionType.AiHand),
				new GuessJokerCallbackAction(delegate()
				{
					ModelBase<GuessJokerGamePlayModel>.Instance.ClearAiDrawnCard();
					base.FinishTask();
				})
			});
			return;
		}
		ModelBase<GuessJokerGamePlayModel>.Instance.ClearAiDrawnCard();
		base.FinishTask();
	}

	// Token: 0x04003654 RID: 13908
	public List<int> CardIdList = new List<int>();
}
