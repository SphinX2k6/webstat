using System;
using System.Runtime.CompilerServices;

// Token: 0x020010FE RID: 4350
public class GuessJokerFlipCoinStage : GuessJokerStageBase
{
	// Token: 0x06007142 RID: 28994 RVA: 0x001D9A60 File Offset: 0x001D7C60
	[NullableContext(1)]
	public GuessJokerFlipCoinStage(GuessJokerStageFsm stageFsm) : base(stageFsm)
	{
	}

	// Token: 0x06007143 RID: 28995 RVA: 0x001D9A6C File Offset: 0x001D7C6C
	protected override void OnEnter()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView != null)
		{
			gamePlayView.ShowFlipCoinEffect(true, delegate
			{
				gamePlayView.SetFlipCoinClickEnable();
			});
		}
	}
}
