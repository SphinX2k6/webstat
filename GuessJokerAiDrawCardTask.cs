using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020010EF RID: 4335
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerAiDrawCardTask : GuessJokerTaskBase
{
	// Token: 0x060070F1 RID: 28913 RVA: 0x001D7D09 File Offset: 0x001D5F09
	public GuessJokerAiDrawCardTask(JokerGuessDrawCardAction data)
	{
		this.CardId = data.DrawCard;
		this.SkillId = data.PreSkill;
	}

	// Token: 0x060070F2 RID: 28914 RVA: 0x001D7D2C File Offset: 0x001D5F2C
	protected override void OnExecute()
	{
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		GuessJokerGamePlayView guessJokerGamePlayView = (instance != null) ? instance.GetGamePlayView() : null;
		if (guessJokerGamePlayView == null)
		{
			base.FinishTask();
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.GuessJokerCard, ELogAuthor.LRC, string.Format("【task】Ai抽牌：{0}，技能ID：{1}", this.CardId, this.SkillId), default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.SkillId == 0)
		{
			guessJokerGamePlayView.UpdateCurrentPlayer(EGuessJokerPlayerType.Ai);
		}
		List<GuessJokerActionBase> list = new List<GuessJokerActionBase>();
		foreach (GuessJokerActionBase item in this.GetDrawCardActionsBySkill())
		{
			list.Add(item);
		}
		foreach (GuessJokerActionBase item2 in this.GetDefaultGetCardActions())
		{
			list.Add(item2);
		}
		ModelBase<GuessJokerGamePlayModel>.Instance.PushActions(list.ToArray());
	}

	// Token: 0x060070F3 RID: 28915 RVA: 0x001D7E40 File Offset: 0x001D6040
	private List<GuessJokerActionBase> GetDrawCardActionsBySkill()
	{
		if (this.SkillId == 151001)
		{
			return this.GetLuhesiDrawCardActions();
		}
		if (this.SkillId == 100001 || this.SkillId == 130401)
		{
			return this.GetPlayerDrawCardActions();
		}
		return this.GetDefaultDrawCardActions();
	}

	// Token: 0x060070F4 RID: 28916 RVA: 0x001D7E80 File Offset: 0x001D6080
	private List<GuessJokerActionBase> GetDefaultDrawCardActions()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		List<GuessJokerActionBase> list = new List<GuessJokerActionBase>();
		list.Add(new GuessJokerCollectCardsAction(EGuessJokerPlayerType.Me, ECardPositionType.PlayerBeDrawCard));
		if (ModelBase<GuessJokerGamePlayModel>.Instance.RoundNumber >= 1 && this.SkillId == 0)
		{
			list.Add(new GuessJokerRoundStartTipAction(EGuessJokerPlayerType.Ai));
		}
		list.Add(new GuessJokerNpcPerformAction(ENpcPokerChangeTimingType.ChooseCard, this.CardId, 0f));
		list.Add(new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
		{
			gamePlayView.ShowAiSelectCardTip(true, complete);
		}));
		list.Add(new GuessJokerUpCardsAction(new int[]
		{
			this.CardId
		}, true));
		list.Add(new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
		{
			gamePlayView.SetCardsSelect(this.CardId, complete);
		}));
		return list;
	}

	// Token: 0x060070F5 RID: 28917 RVA: 0x001D7F40 File Offset: 0x001D6140
	private List<GuessJokerActionBase> GetPlayerDrawCardActions()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		List<GuessJokerActionBase> list = new List<GuessJokerActionBase>();
		list.Add(new GuessJokerCollectCardsAction(EGuessJokerPlayerType.Me, ECardPositionType.PlayerBeDrawCard));
		list.Add(new GuessJokerShuffleCardsAction(ECardPositionType.PlayerBeDrawCard));
		if (ModelBase<GuessJokerGamePlayModel>.Instance.RoundNumber >= 1 && this.SkillId == 0)
		{
			list.Add(new GuessJokerRoundStartTipAction(EGuessJokerPlayerType.Ai));
		}
		list.Add(new GuessJokerNpcPerformAction(ENpcPokerChangeTimingType.ChooseCard, this.CardId, 0f));
		list.Add(new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
		{
			gamePlayView.ShowAiSelectCardTip(true, complete);
		}));
		list.Add(new GuessJokerUpCardsAction(new int[]
		{
			this.CardId
		}, true));
		list.Add(new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
		{
			gamePlayView.SetCardsSelect(this.CardId, complete);
		}));
		return list;
	}

	// Token: 0x060070F6 RID: 28918 RVA: 0x001D800C File Offset: 0x001D620C
	private List<GuessJokerActionBase> GetLuhesiDrawCardActions()
	{
		int jokerCardId = ModelBase<GuessJokerGamePlayModel>.Instance.GetJokerCardId();
		GuessJokerCardData cardDataById = ModelBase<GuessJokerGamePlayModel>.Instance.GetCardDataById(jokerCardId);
		if (cardDataById != null && cardDataById.GetBelongPlayerType().GetValueOrDefault() == EGuessJokerPlayerType.Ai)
		{
			return this.GetDefaultDrawCardActions();
		}
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		return new List<GuessJokerActionBase>
		{
			new GuessJokerCollectCardsAction(EGuessJokerPlayerType.Me, ECardPositionType.PlayerBeDrawCard),
			new GuessJokerNpcPerformAction(ENpcPokerChangeTimingType.ChooseCard, this.CardId, 0f),
			new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
			{
				gamePlayView.ShowAiSelectCardTip(true, complete);
			}),
			new GuessJokerGroupAction(new GuessJokerActionBase[]
			{
				new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
				{
					gamePlayView.SetCardsSelect(jokerCardId, complete);
				}),
				new GuessJokerUpCardsAction(new int[]
				{
					jokerCardId
				}, true)
			}),
			new GuessJokerCallbackAction(delegate()
			{
				ModelBase<GuessJokerGamePlayModel>.Instance.PushPlotActions(new GuessJokerPlotAction[]
				{
					new GuessJokerPlotAction(EGuessJokerPlayerType.Ai, EGuessJokerPlotTiming.ExecuteSkill, new int?(this.SkillId))
				});
			}),
			new GuessJokerWaitAction(500f),
			new GuessJokerGroupAction(new GuessJokerActionBase[]
			{
				new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
				{
					gamePlayView.SetCardsSelect(this.CardId, complete);
				}),
				new GuessJokerUpCardsAction(new int[]
				{
					jokerCardId
				}, false),
				new GuessJokerUpCardsAction(new int[]
				{
					this.CardId
				}, true)
			})
		};
	}

	// Token: 0x060070F7 RID: 28919 RVA: 0x001D8174 File Offset: 0x001D6374
	private List<GuessJokerActionBase> GetDefaultGetCardActions()
	{
		List<GuessJokerActionBase> list = new List<GuessJokerActionBase>();
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		GuessJokerCardData cardDataById = ModelBase<GuessJokerGamePlayModel>.Instance.GetCardDataById(this.CardId);
		bool flag = cardDataById != null && cardDataById.IsJoker();
		bool flag2 = cardDataById != null && cardDataById.IsBlank();
		list.Add(new GuessJokerCallbackAction(delegate()
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.UpdateCardBelongPlayerType(new int[]
			{
				this.CardId
			}, new EGuessJokerPlayerType?(EGuessJokerPlayerType.Ai));
			GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.SetAiDrawnCard(this.CardId);
		}));
		list.Add(new GuessJokerGroupAction(new GuessJokerActionBase[]
		{
			new GuessJokerMoveCardsAction(new int[]
			{
				this.CardId
			}, ECardPositionType.Middle),
			new GuessJokerCollectCardsAction(EGuessJokerPlayerType.Me, ECardPositionType.PlayerHand),
			new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
			{
				gamePlayView.ShowAiSelectCardTip(false, complete);
			})
		}));
		if (flag)
		{
			list.Add(new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
			{
				gamePlayView.ShowDrawSpecialTip(true, false, EGuessJokerPlayerType.Ai, complete);
			}));
		}
		else if (flag2)
		{
			list.Add(new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
			{
				gamePlayView.ShowDrawSpecialTip(true, true, EGuessJokerPlayerType.Ai, complete);
			}));
		}
		list.Add(new GuessJokerNpcPerformAction(ENpcPokerChangeTimingType.DrawCard, this.CardId, (float)GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerNpcDrawCardWaitTime.ToString())));
		if (flag)
		{
			list.Add(new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
			{
				gamePlayView.ShowDrawSpecialTip(false, false, EGuessJokerPlayerType.Ai, complete);
			}));
		}
		else if (flag2)
		{
			list.Add(new GuessJokerCallbackWithCompleteAction(delegate(Action complete)
			{
				gamePlayView.ShowDrawSpecialTip(false, true, EGuessJokerPlayerType.Ai, complete);
			}));
		}
		list.Add(new GuessJokerCallbackAction(delegate()
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.UpdateNpcIdleState();
			this.FinishTask();
		}));
		return list;
	}

	// Token: 0x04003652 RID: 13906
	private readonly int CardId;

	// Token: 0x04003653 RID: 13907
	private readonly int SkillId;
}
