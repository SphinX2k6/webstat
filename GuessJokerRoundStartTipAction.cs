using System;

// Token: 0x020010E1 RID: 4321
public class GuessJokerRoundStartTipAction : GuessJokerActionBase
{
	// Token: 0x0600709F RID: 28831 RVA: 0x001D6995 File Offset: 0x001D4B95
	public GuessJokerRoundStartTipAction(EGuessJokerPlayerType playerType)
	{
		this.PlayerType = playerType;
	}

	// Token: 0x060070A0 RID: 28832 RVA: 0x001D69A4 File Offset: 0x001D4BA4
	protected override void OnStart()
	{
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		if (instance != null && instance.HasShownRoundStartTip(this.PlayerType))
		{
			this.Done = true;
			return;
		}
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
		{
			this.Done = true;
			return;
		}
		ModelBase<GuessJokerGamePlayModel>.Instance.MarkRoundStartTipShown(this.PlayerType);
		gamePlayView.ShowPlayerRoundStartTip(this.PlayerType, delegate
		{
			this.Done = true;
		});
	}

	// Token: 0x0400362B RID: 13867
	private readonly EGuessJokerPlayerType PlayerType;
}
