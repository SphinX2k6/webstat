using System;
using Aki.Protocol;

// Token: 0x020010F6 RID: 4342
public class GuessJokerSettleTask : GuessJokerTaskBase
{
	// Token: 0x06007110 RID: 28944 RVA: 0x001D9107 File Offset: 0x001D7307
	public GuessJokerSettleTask(JokerGuessActor winner)
	{
		ModelBase<GuessJokerGamePlayModel>.Instance.SetWinner(winner);
	}

	// Token: 0x06007111 RID: 28945 RVA: 0x001D911A File Offset: 0x001D731A
	protected override void OnExecute()
	{
		ModelBase<GuessJokerGamePlayModel>.Instance.ChangeState(EGuessJokerCardStateType.SettleStage);
		base.FinishTask();
	}
}
