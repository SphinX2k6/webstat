using System;
using System.Runtime.CompilerServices;

// Token: 0x020010FD RID: 4349
public class GuessJokerDealCardStage : GuessJokerStageBase
{
	// Token: 0x06007140 RID: 28992 RVA: 0x001D9A14 File Offset: 0x001D7C14
	[NullableContext(1)]
	public GuessJokerDealCardStage(GuessJokerStageFsm stageFsm) : base(stageFsm)
	{
	}

	// Token: 0x06007141 RID: 28993 RVA: 0x001D9A20 File Offset: 0x001D7C20
	protected override void OnEnter()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView != null)
		{
			gamePlayView.DealCards(delegate
			{
				GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
				if (instance != null && instance.IsExit)
				{
					return;
				}
				ModelBase<GuessJokerGamePlayModel>.Instance.ChangeState(EGuessJokerCardStateType.FlipCoin);
			});
		}
	}
}
