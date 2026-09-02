using System;
using System.Collections.Generic;
using CSharpScript.Game.Common.Event;

// Token: 0x020010F2 RID: 4338
public class GuessJokerPlayerDrawCardTask : GuessJokerTaskBase
{
	// Token: 0x06007100 RID: 28928 RVA: 0x001D87C6 File Offset: 0x001D69C6
	public GuessJokerPlayerDrawCardTask()
	{
		this.TaskType = EGuessJokerTaskType.Interactive;
	}

	// Token: 0x06007101 RID: 28929 RVA: 0x001D87D8 File Offset: 0x001D69D8
	protected override void OnExecute()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
		{
			base.FinishTask();
			return;
		}
		ModelBase<GuessJokerGamePlayModel>.Instance.SetNpcEnterInteractiveStage(true);
		gamePlayView.UpdateCurrentPlayer(EGuessJokerPlayerType.Me);
		gamePlayView.SetPlayerCardClickCallback(delegate(int cardId, int prevSelectedCardId, bool isSelected)
		{
			if (this.IsFinished())
			{
				Singleton<Log>.Instance.Warn(ELogModule.GuessJokerCard, ELogAuthor.LRC, "任务已完成，忽略点击", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (isSelected)
			{
				this.OnPlayerDrawCard(cardId);
				return;
			}
			this.OnPlayerChooseCard(cardId, prevSelectedCardId);
		});
		List<GuessJokerActionBase> list = new List<GuessJokerActionBase>();
		list.Add(new GuessJokerCollectCardsAction(EGuessJokerPlayerType.Ai, ECardPositionType.AiBeDrawCard));
		if (ModelBase<GuessJokerGamePlayModel>.Instance.RoundNumber >= 1)
		{
			list.Add(new GuessJokerRoundStartTipAction(EGuessJokerPlayerType.Me));
		}
		list.Add(new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
		{
			gamePlayView.ShowPlayerDrawCardTip(true, complete);
		}));
		list.Add(new GuessJokerCallbackAction(delegate()
		{
			GuessJokerPositionPanelBase positionPanel = gamePlayView.GetPositionPanel(ECardPositionType.AiBeDrawCard);
			if (positionPanel == null)
			{
				return;
			}
			positionPanel.SetCardsClickableExcept(true, 0);
		}));
		ModelBase<GuessJokerGamePlayModel>.Instance.PushActions(list.ToArray());
		if (ModelBase<GuessJokerGamePlayModel>.Instance.GetHandCardsByPlayer(EGuessJokerPlayerType.Ai).Count > 1)
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.PushPlotActions(new GuessJokerPlotAction[]
			{
				new GuessJokerPlotAction(EGuessJokerPlayerType.Ai, EGuessJokerPlotTiming.PlayerStartDrawCard, null)
			});
		}
	}

	// Token: 0x06007102 RID: 28930 RVA: 0x001D88E0 File Offset: 0x001D6AE0
	private void OnPlayerChooseCard(int cardId, int prevSelectedCardId)
	{
		if (this.HasPlayerDrawn)
		{
			Singleton<Log>.Instance.Warn(ELogModule.GuessJokerCard, ELogAuthor.LRC, "已经抽过牌，忽略选牌操作", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
		{
			return;
		}
		GuessJokerPositionPanelBase aiPanel = gamePlayView.GetPositionPanel(ECardPositionType.AiBeDrawCard);
		if (aiPanel == null)
		{
			return;
		}
		gamePlayView.SetCardChoose(cardId, true);
		List<GuessJokerActionBase> list = new List<GuessJokerActionBase>();
		list.Add(new GuessJokerCallbackAction(delegate()
		{
			aiPanel.SetCardsClickableExcept(false, 0);
		}));
		list.Add(new GuessJokerGroupAction(new GuessJokerActionBase[]
		{
			new GuessJokerNpcPerformAction(ENpcPokerChangeTimingType.BeChooseCard, cardId, (float)GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerCardUpTime.ToString())),
			new GuessJokerUpCardsAction(new int[]
			{
				cardId
			}, true),
			new GuessJokerUpCardsAction(new int[]
			{
				prevSelectedCardId
			}, false)
		}));
		list.Add(new GuessJokerCallbackAction(delegate()
		{
			aiPanel.SetCardsClickableExcept(true, 0);
		}));
		ModelBase<GuessJokerGamePlayModel>.Instance.PushActions(list.ToArray());
		if (ModelBase<GuessJokerGamePlayModel>.Instance.GetHandCardsByPlayer(EGuessJokerPlayerType.Ai).Count > 1)
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.PushPlotActions(new GuessJokerPlotAction[]
			{
				new GuessJokerPlotAction(EGuessJokerPlayerType.Ai, EGuessJokerPlotTiming.PlayerChooseCard, null)
			});
		}
	}

	// Token: 0x06007103 RID: 28931 RVA: 0x001D8A1C File Offset: 0x001D6C1C
	private void OnPlayerDrawCard(int cardId)
	{
		if (this.HasPlayerDrawn)
		{
			Singleton<Log>.Instance.Warn(ELogModule.GuessJokerCard, ELogAuthor.LRC, "已经抽过牌，忽略重复点击", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!base.CanSendRequest())
		{
			Singleton<Log>.Instance.Warn(ELogModule.GuessJokerCard, ELogAuthor.LRC, "抽卡请求进行中，忽略重复点击", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
		{
			return;
		}
		GuessJokerPositionPanelBase aiPanel = gamePlayView.GetPositionPanel(ECardPositionType.AiBeDrawCard);
		if (aiPanel == null)
		{
			return;
		}
		base.SetRequestFinished(true);
		this.HasPlayerDrawn = true;
		GuessJokerCardItem cardItemById = gamePlayView.GetCardItemById(cardId);
		if (cardItemById != null)
		{
			cardItemById.SetToggleState(true);
		}
		Action<Action> <>9__2;
		Action<Action> <>9__4;
		Action<Action> <>9__5;
		Action<Action> <>9__7;
		Action<Action> <>9__8;
		Action <>9__11;
		ControllerBase<GuessJokerController>.Instance.RequestJokerGuessDrawCard(cardId, delegate(int actualCardId)
		{
			int finalCardId = cardId;
			if (actualCardId != cardId)
			{
				aiPanel.SwapCardPositionsSilently(cardId, actualCardId);
				finalCardId = actualCardId;
			}
			GuessJokerCardData cardDataById = ModelBase<GuessJokerGamePlayModel>.Instance.GetCardDataById(finalCardId);
			bool flag = cardDataById != null && cardDataById.IsJoker();
			bool flag2 = cardDataById != null && cardDataById.IsBlank();
			GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
			if (instance != null)
			{
				instance.UpdateCardBelongPlayerType(new int[]
				{
					finalCardId
				}, new EGuessJokerPlayerType?(EGuessJokerPlayerType.Me));
			}
			EGuessJokerPlotTiming plotTiming = GuessJokerUtils.GetPlayerGetCardState(finalCardId);
			GuessJokerGamePlayModel instance2 = ModelBase<GuessJokerGamePlayModel>.Instance;
			if (instance2 != null)
			{
				instance2.SetPlayerDrawnCard(finalCardId);
			}
			aiPanel.SetCardsClickableExcept(false, finalCardId);
			gamePlayView.ClearChooseCard();
			GuessJokerCardItem cardItemById2 = gamePlayView.GetCardItemById(finalCardId);
			if (cardItemById2 != null)
			{
				cardItemById2.SetClickEnable(false);
			}
			List<GuessJokerActionBase> list = new List<GuessJokerActionBase>();
			list.Add(new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
			{
				gamePlayView.SetCardsSelect(finalCardId, complete);
			}));
			List<GuessJokerActionBase> list2 = list;
			Action<Action> callback;
			if ((callback = <>9__2) == null)
			{
				callback = (<>9__2 = delegate(Action complete)
				{
					gamePlayView.ShowPlayerDrawCardTip(false, complete);
				});
			}
			list2.Add(new GuessJokerCallbackWithCompleteAction(callback));
			list.Add(new GuessJokerGroupAction(new GuessJokerActionBase[]
			{
				new GuessJokerShowCardsAction(new int[]
				{
					finalCardId
				}, true, 0f),
				new GuessJokerNpcPerformAction(ENpcPokerChangeTimingType.BeDrawCard, finalCardId, (float)GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerNpcDrawCardWaitTime.ToString())),
				new GuessJokerMoveCardsAction(new int[]
				{
					finalCardId
				}, ECardPositionType.Middle),
				new GuessJokerCallbackAction(delegate()
				{
					GuessJokerGamePlayModel instance3 = ModelBase<GuessJokerGamePlayModel>.Instance;
					if (instance3 == null)
					{
						return;
					}
					instance3.PushPlotActions(new GuessJokerPlotAction[]
					{
						new GuessJokerPlotAction(EGuessJokerPlayerType.Me, plotTiming, null)
					});
				}),
				new GuessJokerCollectCardsAction(EGuessJokerPlayerType.Ai, ECardPositionType.AiHand)
			}));
			if (flag)
			{
				List<GuessJokerActionBase> list3 = list;
				Action<Action> callback2;
				if ((callback2 = <>9__4) == null)
				{
					callback2 = (<>9__4 = delegate(Action complete)
					{
						gamePlayView.ShowDrawSpecialTip(true, false, EGuessJokerPlayerType.Me, complete);
					});
				}
				list3.Add(new GuessJokerCallbackWithCompleteAction(callback2));
				List<GuessJokerActionBase> list4 = list;
				Action<Action> callback3;
				if ((callback3 = <>9__5) == null)
				{
					callback3 = (<>9__5 = delegate(Action complete)
					{
						gamePlayView.ShowDrawSpecialTip(false, false, EGuessJokerPlayerType.Me, complete);
					});
				}
				list4.Add(new GuessJokerCallbackWithCompleteAction(callback3));
				list.Add(new GuessJokerCallbackAction(delegate()
				{
					Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "GuessJokerDrawJoker");
				}));
			}
			else if (flag2)
			{
				List<GuessJokerActionBase> list5 = list;
				Action<Action> callback4;
				if ((callback4 = <>9__7) == null)
				{
					callback4 = (<>9__7 = delegate(Action complete)
					{
						gamePlayView.ShowDrawSpecialTip(true, true, EGuessJokerPlayerType.Me, complete);
					});
				}
				list5.Add(new GuessJokerCallbackWithCompleteAction(callback4));
				List<GuessJokerActionBase> list6 = list;
				Action<Action> callback5;
				if ((callback5 = <>9__8) == null)
				{
					callback5 = (<>9__8 = delegate(Action complete)
					{
						gamePlayView.ShowDrawSpecialTip(false, true, EGuessJokerPlayerType.Me, complete);
					});
				}
				list6.Add(new GuessJokerCallbackWithCompleteAction(callback5));
				list.Add(new GuessJokerCallbackAction(delegate()
				{
					Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "GuessJokerDrawChange");
				}));
			}
			list.Add(new GuessJokerCallbackAction(delegate()
			{
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "GuessJokerAfterDraw");
			}));
			List<GuessJokerActionBase> list7 = list;
			Action callback6;
			if ((callback6 = <>9__11) == null)
			{
				callback6 = (<>9__11 = delegate()
				{
					gamePlayView.HidePlayerButtons();
					ModelBase<GuessJokerGamePlayModel>.Instance.UpdateNpcIdleState();
					this.FinishTask();
				});
			}
			list7.Add(new GuessJokerCallbackAction(callback6));
			ModelBase<GuessJokerGamePlayModel>.Instance.PushActions(list.ToArray());
		});
	}

	// Token: 0x06007104 RID: 28932 RVA: 0x001D8B08 File Offset: 0x001D6D08
	protected override void OnComplete()
	{
		ModelBase<GuessJokerGamePlayModel>.Instance.SetNpcEnterInteractiveStage(false);
	}

	// Token: 0x04003659 RID: 13913
	private bool HasPlayerDrawn;
}
