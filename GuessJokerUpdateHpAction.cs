using System;

// Token: 0x020010E5 RID: 4325
public class GuessJokerUpdateHpAction : GuessJokerActionBase
{
	// Token: 0x060070A8 RID: 28840 RVA: 0x001D6C97 File Offset: 0x001D4E97
	public GuessJokerUpdateHpAction(EGuessJokerPlayerType playerType, int hp)
	{
		this.PlayerType = playerType;
		this.Hp = hp;
	}

	// Token: 0x060070A9 RID: 28841 RVA: 0x001D6CB4 File Offset: 0x001D4EB4
	protected override void OnStart()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
		{
			this.Done = true;
			return;
		}
		gamePlayView.UpdateHp(this.PlayerType, delegate
		{
			this.Done = true;
		});
	}

	// Token: 0x04003631 RID: 13873
	public EGuessJokerPlayerType PlayerType = EGuessJokerPlayerType.Ai;

	// Token: 0x04003632 RID: 13874
	public int Hp;
}
