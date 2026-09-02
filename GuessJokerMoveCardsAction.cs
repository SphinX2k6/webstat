using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020010DD RID: 4317
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerMoveCardsAction : GuessJokerActionBase
{
	// Token: 0x06007085 RID: 28805 RVA: 0x001D60E0 File Offset: 0x001D42E0
	public GuessJokerMoveCardsAction(int[] cardIdList, ECardPositionType toPosition)
	{
		this.CardIdList.AddRange(cardIdList);
		this.TargetPosition = toPosition;
	}

	// Token: 0x06007086 RID: 28806 RVA: 0x001D6108 File Offset: 0x001D4308
	protected override void OnStart()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
		{
			this.Done = true;
			return;
		}
		if (this.CardIdList.Count == 0)
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
		List<GuessJokerCardItem> list = new List<GuessJokerCardItem>();
		for (int i = 0; i < this.CardIdList.Count; i++)
		{
			int cardId = this.CardIdList[i];
			GuessJokerCardItem cardItemById = gamePlayView.GetCardItemById(cardId);
			if (cardItemById != null)
			{
				ECardPositionType positionType = cardItemById.GetPositionType();
				if (positionType != this.TargetPosition)
				{
					GuessJokerPositionPanelBase positionPanel2 = gamePlayView.GetPositionPanel(positionType);
					if (positionPanel2 != null)
					{
						positionPanel2.RemoveCardByCardId(cardId);
					}
					list.Add(cardItemById);
				}
			}
		}
		list.Sort((GuessJokerCardItem a, GuessJokerCardItem b) => a.GetGlobalIndex() - b.GetGlobalIndex());
		positionPanel.AddCardByItemList(list);
		gamePlayView.UpdateCardItemsHierarchyIndex();
		if (positionPanel.Position == ECardPositionType.Middle)
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_springfestival_ghostcard_card_discard");
		}
		base.AnimateCardsToTarget(this.TargetPosition, positionPanel, delegate
		{
			this.Done = true;
		});
	}

	// Token: 0x0400361F RID: 13855
	private readonly List<int> CardIdList = new List<int>();

	// Token: 0x04003620 RID: 13856
	private readonly ECardPositionType TargetPosition;
}
