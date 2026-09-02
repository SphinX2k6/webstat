using System;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;

// Token: 0x020010DE RID: 4318
public class GuessJokerNpcPerformAction : GuessJokerActionBase
{
	// Token: 0x06007088 RID: 28808 RVA: 0x001D6230 File Offset: 0x001D4430
	public GuessJokerNpcPerformAction(ENpcPokerChangeTimingType changeTiming, int relatedCardId = 0, float duration = 0f)
	{
		this.ChangeTiming = changeTiming;
		this.RelatedCardId = relatedCardId;
		if (duration != 0f)
		{
			this.Duration = duration;
			return;
		}
		this.Duration = (float)GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerMaxPerformTime.ToString());
	}

	// Token: 0x06007089 RID: 28809 RVA: 0x001D6280 File Offset: 0x001D4480
	protected override void OnStart()
	{
		if (ModelBase<GuessJokerGamePlayModel>.Instance == null)
		{
			this.Done = true;
			return;
		}
		EPokerStateType epokerStateType = GuessJokerUtils.CalculateNpcState(this.ChangeTiming, this.RelatedCardId);
		this.State = epokerStateType;
		this.PushRelatedPlotAction();
		ModelBase<GuessJokerGamePlayModel>.Instance.SetNpcPokerState(epokerStateType);
	}

	// Token: 0x0600708A RID: 28810 RVA: 0x001D62C8 File Offset: 0x001D44C8
	private void PushRelatedPlotAction()
	{
		GuessJokerPlotAction guessJokerPlotAction = null;
		switch (this.State)
		{
		case EPokerStateType.DrawCardNormal:
			guessJokerPlotAction = new GuessJokerPlotAction(EGuessJokerPlayerType.Ai, EGuessJokerPlotTiming.AiNormalDrawCard, null);
			break;
		case EPokerStateType.DrawCardThinking:
			guessJokerPlotAction = new GuessJokerPlotAction(EGuessJokerPlayerType.Ai, EGuessJokerPlotTiming.AiThinkingDrawCard, null);
			break;
		case EPokerStateType.GetCardHappy:
			guessJokerPlotAction = new GuessJokerPlotAction(EGuessJokerPlayerType.Ai, EGuessJokerPlotTiming.GetCardHappy, null);
			break;
		case EPokerStateType.GetCardSad:
			guessJokerPlotAction = new GuessJokerPlotAction(EGuessJokerPlayerType.Ai, EGuessJokerPlotTiming.GetCardSad, null);
			break;
		}
		if (guessJokerPlotAction != null)
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.PushPlotActions(new GuessJokerPlotAction[]
			{
				guessJokerPlotAction
			});
		}
	}

	// Token: 0x0600708B RID: 28811 RVA: 0x001D635C File Offset: 0x001D455C
	private unsafe void OnGuessJokerFinishPokerPerformAction(EPokerStateType state)
	{
		if (state != this.State)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "OnGuessJokerFinishPokerPerformAction state is not match";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("notify state", state);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("this.State", this.State);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		Singleton<Log>.Instance.Warn(ELogModule.GuessJokerCard, ELogAuthor.LRC, "OnGuessJokerFinishPokerPerformAction!!", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.Done = true;
	}

	// Token: 0x0600708C RID: 28812 RVA: 0x001D63FE File Offset: 0x001D45FE
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.GuessJokerFinishPokerPerformAction, new Action<EPokerStateType>(this.OnGuessJokerFinishPokerPerformAction));
	}

	// Token: 0x0600708D RID: 28813 RVA: 0x001D641C File Offset: 0x001D461C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GuessJokerFinishPokerPerformAction, new Action<EPokerStateType>(this.OnGuessJokerFinishPokerPerformAction));
	}

	// Token: 0x04003621 RID: 13857
	private readonly ENpcPokerChangeTimingType ChangeTiming;

	// Token: 0x04003622 RID: 13858
	private readonly int RelatedCardId;

	// Token: 0x04003623 RID: 13859
	private EPokerStateType State;
}
