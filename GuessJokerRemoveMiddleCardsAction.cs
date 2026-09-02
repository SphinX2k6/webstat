using System;

// Token: 0x020010E0 RID: 4320
public class GuessJokerRemoveMiddleCardsAction : GuessJokerActionBase
{
	// Token: 0x0600709D RID: 28829 RVA: 0x001D690F File Offset: 0x001D4B0F
	public GuessJokerRemoveMiddleCardsAction(float duration = 0f)
	{
		if (duration != 0f)
		{
			this.Duration = duration;
			return;
		}
		this.Duration = (float)GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerCardRemoveTime.ToString());
	}

	// Token: 0x0600709E RID: 28830 RVA: 0x001D6944 File Offset: 0x001D4B44
	protected override void OnStart()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
		{
			this.Done = true;
			return;
		}
		gamePlayView.RemoveCardFromMiddleArea(delegate
		{
			if (ModelBase<GuessJokerGamePlayModel>.Instance.CheckBlankCardDisable())
			{
				gamePlayView.SetBlankCardDisable();
			}
			this.Done = true;
		});
	}
}
