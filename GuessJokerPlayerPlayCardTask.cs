using System;
using System.Collections.Generic;
using System.Linq;

// Token: 0x020010F3 RID: 4339
public class GuessJokerPlayerPlayCardTask : GuessJokerTaskBase
{
	// Token: 0x06007105 RID: 28933 RVA: 0x001D8B15 File Offset: 0x001D6D15
	public GuessJokerPlayerPlayCardTask()
	{
		this.TaskType = EGuessJokerTaskType.Interactive;
	}

	// Token: 0x06007106 RID: 28934 RVA: 0x001D8B24 File Offset: 0x001D6D24
	protected override void OnExecute()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
		{
			base.FinishTask();
			return;
		}
		ModelBase<GuessJokerGamePlayModel>.Instance.SetNpcEnterInteractiveStage(true);
		Singleton<Log>.Instance.Info(ELogModule.GuessJokerCard, ELogAuthor.LRC, "【task】玩家出牌", default(ReadOnlySpan<ValueTuple<string, object>>));
		List<IPlayCardInfo> playerPlayCardIdList = ModelBase<GuessJokerGamePlayModel>.Instance.GetPlayerPlayCardIdList();
		List<int> playCardList = new List<int>();
		int normalCardPairCount = 0;
		for (int i = 0; i < playerPlayCardIdList.Count; i++)
		{
			IPlayCardInfo playCardInfo = playerPlayCardIdList[i];
			for (int j = 0; j < playCardInfo.CardIdList.Length; j++)
			{
				playCardList.Add(playCardInfo.CardIdList[j]);
			}
			int normalCardPairCount2 = normalCardPairCount;
			normalCardPairCount = normalCardPairCount2 + 1;
		}
		if (normalCardPairCount == 0)
		{
			if (ModelBase<GuessJokerGamePlayModel>.Instance.RoundNumber != 0 || ModelBase<GuessJokerGamePlayModel>.Instance.ShowInitialNoPairTip)
			{
				ControllerBase<GuessJokerController>.Instance.OpenGuessJokerFloatTipsView("GuessJoker_Player_NoPlayCard", null);
			}
			ModelBase<GuessJokerGamePlayModel>.Instance.PushActions(new <>z__ReadOnlyArray<GuessJokerActionBase>(new GuessJokerActionBase[]
			{
				new GuessJokerCollectCardsAction(EGuessJokerPlayerType.Me, ECardPositionType.PlayerHand),
				new GuessJokerCallbackAction(delegate()
				{
					this.SetRequestFinished(true);
					ControllerBase<GuessJokerController>.Instance.RequestJokerGuessPlayCard(Array.Empty<int>(), new Action(this.FinishWithShuffleCheck));
				})
			}));
			return;
		}
		Action<Action> <>9__5;
		Action <>9__6;
		gamePlayView.SetPlayerPlayCardInteractiveCallback(delegate(int[] selectedPlayCardList)
		{
			if (!this.CanSendRequest())
			{
				Singleton<Log>.Instance.Warn(ELogModule.GuessJokerCard, ELogAuthor.LRC, "出牌请求进行中，忽略重复点击", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.SetRequestFinished(true);
			ControllerBase<GuessJokerController>.Instance.RequestJokerGuessPlayCard(selectedPlayCardList, delegate
			{
				if (selectedPlayCardList.Length == 0)
				{
					ControllerBase<GuessJokerController>.Instance.OpenGuessJokerFloatTipsView("GuessJoker_Player_GiveUpPlayCard", null);
				}
				ModelBase<GuessJokerGamePlayModel>.Instance.UpdateCardBelongPlayerType(selectedPlayCardList.ToArray<int>(), null);
				bool flag = ModelBase<GuessJokerGamePlayModel>.Instance.GetHandCardsByPlayer(EGuessJokerPlayerType.Me).Count == 0;
				List<GuessJokerActionBase> list2 = new List<GuessJokerActionBase>();
				list2.Add(new GuessJokerGroupAction(new GuessJokerActionBase[]
				{
					new GuessJokerMoveCardsAction(selectedPlayCardList, ECardPositionType.Middle),
					new GuessJokerCollectCardsAction(EGuessJokerPlayerType.Me, ECardPositionType.PlayerHand)
				}));
				if (flag)
				{
					List<GuessJokerActionBase> list3 = list2;
					Action<Action> callback;
					if ((callback = <>9__5) == null)
					{
						callback = (<>9__5 = delegate(Action complete)
						{
							gamePlayView.ShowWinLoseReasonTip(EGuessJokerPlayerType.Me, "GuessJoker_PlayAllCardsTipText", true, delegate
							{
								complete();
								this.FinishTask();
							});
						});
					}
					list3.Add(new GuessJokerCallbackWithCompleteAction(callback));
				}
				else
				{
					list2.Add(new GuessJokerRemoveMiddleCardsAction(0f));
					List<GuessJokerActionBase> list4 = list2;
					Action callback2;
					if ((callback2 = <>9__6) == null)
					{
						callback2 = (<>9__6 = delegate()
						{
							gamePlayView.SetPositionPanelCardsDark(ECardPositionType.PlayerHand, false, null);
							ModelBase<GuessJokerGamePlayModel>.Instance.UpdateNpcIdleState();
							gamePlayView.SetPlayerCardClickCallback(null);
							this.FinishWithShuffleCheck();
						});
					}
					list4.Add(new GuessJokerCallbackAction(callback2));
				}
				ModelBase<GuessJokerGamePlayModel>.Instance.PushActions(list2.ToArray());
			});
		});
		bool roundNumber = ModelBase<GuessJokerGamePlayModel>.Instance.RoundNumber != 0;
		List<GuessJokerActionBase> list = new List<GuessJokerActionBase>();
		if (!roundNumber)
		{
			gamePlayView.UpdateCurrentPlayer(EGuessJokerPlayerType.Me);
			list.Add(new GuessJokerRoundStartTipAction(EGuessJokerPlayerType.Me));
		}
		list.Add(new GuessJokerCollectCardsAction(EGuessJokerPlayerType.Me, ECardPositionType.PlayerPlay));
		list.Add(new GuessJokerCallbackAction(delegate()
		{
			gamePlayView.SetPositionPanelCardsDark(ECardPositionType.PlayerPlay, true, playCardList.ToArray());
		}));
		list.Add(new GuessJokerUpCardsAction(playCardList.ToArray(), true));
		list.Add(new GuessJokerCallbackAction(delegate()
		{
			gamePlayView.ShowPlayerButtons(normalCardPairCount);
		}));
		ModelBase<GuessJokerGamePlayModel>.Instance.PushActions(list.ToArray());
	}

	// Token: 0x06007107 RID: 28935 RVA: 0x001D8D0C File Offset: 0x001D6F0C
	private void FinishWithShuffleCheck()
	{
		if (ModelBase<GuessJokerGamePlayModel>.Instance.HasPlayerNewCardInHand())
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.PushActions(new GuessJokerActionBase[]
			{
				new GuessJokerShuffleCardsAction(ECardPositionType.PlayerHand),
				new GuessJokerCallbackAction(delegate()
				{
					ModelBase<GuessJokerGamePlayModel>.Instance.ClearPlayerDrawnCard();
					base.FinishTask();
				})
			});
			return;
		}
		ModelBase<GuessJokerGamePlayModel>.Instance.ClearPlayerDrawnCard();
		base.FinishTask();
	}

	// Token: 0x06007108 RID: 28936 RVA: 0x001D8D63 File Offset: 0x001D6F63
	protected override void OnComplete()
	{
		ModelBase<GuessJokerGamePlayModel>.Instance.SetNpcEnterInteractiveStage(false);
	}
}
