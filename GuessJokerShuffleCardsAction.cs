using System;

// Token: 0x020010E3 RID: 4323
public class GuessJokerShuffleCardsAction : GuessJokerActionBase
{
	// Token: 0x060070A4 RID: 28836 RVA: 0x001D6AA6 File Offset: 0x001D4CA6
	public GuessJokerShuffleCardsAction(ECardPositionType targetPosition)
	{
		this.TargetPosition = targetPosition;
	}

	// Token: 0x060070A5 RID: 28837 RVA: 0x001D6AB8 File Offset: 0x001D4CB8
	protected override void OnStart()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
		{
			this.Done = true;
			return;
		}
		GuessJokerPositionPanelBase positionPanel = gamePlayView.GetPositionPanel(this.TargetPosition);
		if (positionPanel == null || positionPanel.CardItemList.Count <= 1)
		{
			this.Done = true;
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.GuessJokerCard, ELogAuthor.LRC, "【action】开始洗牌动画：" + this.TargetPosition.ToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
		gamePlayView.ClearAllCardsChecking();
		positionPanel.ShuffleCardsWithAnimation(delegate
		{
			gamePlayView.UpdateCardItemsHierarchyIndex();
			Singleton<Log>.Instance.Info(ELogModule.GuessJokerCard, ELogAuthor.LRC, "【action】洗牌动画完成", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.Done = true;
		});
	}

	// Token: 0x0400362E RID: 13870
	private readonly ECardPositionType TargetPosition;
}
