using System;
using System.Collections.Generic;

// Token: 0x020010DA RID: 4314
public class GuessJokerCollectCardsAction : GuessJokerActionBase
{
	// Token: 0x0600707C RID: 28796 RVA: 0x001D5DFD File Offset: 0x001D3FFD
	public GuessJokerCollectCardsAction(EGuessJokerPlayerType playerType, ECardPositionType targetPosition)
	{
		this.PlayerType = playerType;
		this.TargetPosition = targetPosition;
	}

	// Token: 0x0600707D RID: 28797 RVA: 0x001D5E14 File Offset: 0x001D4014
	protected override void OnStart()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
		{
			this.Done = true;
			return;
		}
		GuessJokerPositionPanelBase positionPanel = gamePlayView.GetPositionPanel(this.TargetPosition);
		if (positionPanel == null)
		{
			this.Done = true;
			return;
		}
		List<GuessJokerCardData> allCardsByPlayer = ModelBase<GuessJokerGamePlayModel>.Instance.GetAllCardsByPlayer(this.PlayerType);
		if (allCardsByPlayer.Count == 0)
		{
			this.Done = true;
			return;
		}
		List<GuessJokerCardItem> list = new List<GuessJokerCardItem>();
		for (int i = 0; i < allCardsByPlayer.Count; i++)
		{
			int id = allCardsByPlayer[i].Id;
			GuessJokerCardItem cardItemById = gamePlayView.GetCardItemById(id);
			if (cardItemById != null)
			{
				ECardPositionType positionType = cardItemById.GetPositionType();
				if (positionType != this.TargetPosition)
				{
					GuessJokerPositionPanelBase positionPanel2 = gamePlayView.GetPositionPanel(positionType);
					if (positionPanel2 != null)
					{
						positionPanel2.RemoveCardByCardId(id);
					}
					list.Add(cardItemById);
				}
			}
		}
		list.Sort((GuessJokerCardItem a, GuessJokerCardItem b) => a.GetGlobalIndex() - b.GetGlobalIndex());
		positionPanel.AddCardByItemList(list);
		gamePlayView.UpdateCardItemsHierarchyIndex();
		for (int j = 0; j < list.Count; j++)
		{
			GuessJokerCardItem guessJokerCardItem = list[j];
			GuessJokerCardData data = guessJokerCardItem.Data;
			guessJokerCardItem.CardFlip(data.GetBelongPlayerType().GetValueOrDefault() != EGuessJokerPlayerType.Ai, true);
		}
		base.AnimateCardsToTarget(this.TargetPosition, positionPanel, delegate
		{
			this.Done = true;
		});
	}

	// Token: 0x0400361A RID: 13850
	private readonly EGuessJokerPlayerType PlayerType;

	// Token: 0x0400361B RID: 13851
	private readonly ECardPositionType TargetPosition;
}
