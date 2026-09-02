using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001102 RID: 4354
public class GuessJokerSettleStage : GuessJokerStageBase
{
	// Token: 0x06007155 RID: 29013 RVA: 0x001D9F3F File Offset: 0x001D813F
	[NullableContext(1)]
	public GuessJokerSettleStage(GuessJokerStageFsm stageFsm) : base(stageFsm)
	{
	}

	// Token: 0x06007156 RID: 29014 RVA: 0x001D9F48 File Offset: 0x001D8148
	protected override void OnEnter()
	{
		bool flag = ModelBase<GuessJokerGamePlayModel>.Instance.GetWinner() == EGuessJokerPlayerType.Ai;
		EGuessJokerPlotTiming timing = flag ? EGuessJokerPlotTiming.Win : EGuessJokerPlotTiming.Lose;
		EUiViewName name = flag ? EUiViewName.GuessJokerSettleFailView : EUiViewName.GuessJokerSettleWinView;
		Singleton<UiManager>.Instance.OpenView(name, null, delegate(bool _, int _)
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.PushPlotActions(new GuessJokerPlotAction[]
			{
				new GuessJokerPlotAction(EGuessJokerPlayerType.Ai, timing, null)
			});
		});
		ModelBase<GuessJokerGamePlayModel>.Instance.SettleGameClear();
	}
}
