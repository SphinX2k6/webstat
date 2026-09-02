using System;

// Token: 0x020010DB RID: 4315
public class GuessJokerFlipAction : GuessJokerActionBase
{
	// Token: 0x0600707F RID: 28799 RVA: 0x001D5F70 File Offset: 0x001D4170
	public GuessJokerFlipAction(int cardId, bool isShowFront)
	{
		this.CardId = cardId;
		this.IsShowFront = isShowFront;
	}

	// Token: 0x06007080 RID: 28800 RVA: 0x001D5F88 File Offset: 0x001D4188
	protected override void OnStart()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
		{
			this.Done = true;
			return;
		}
		GuessJokerCardItem cardItemById = gamePlayView.GetCardItemById(this.CardId);
		if (cardItemById != null)
		{
			cardItemById.CardFlip(this.IsShowFront, true);
		}
		this.Done = true;
	}

	// Token: 0x0400361C RID: 13852
	private readonly int CardId;

	// Token: 0x0400361D RID: 13853
	private readonly bool IsShowFront;
}
