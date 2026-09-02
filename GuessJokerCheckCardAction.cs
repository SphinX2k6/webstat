using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020010D9 RID: 4313
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerCheckCardAction : GuessJokerActionBase
{
	// Token: 0x0600707A RID: 28794 RVA: 0x001D5CFE File Offset: 0x001D3EFE
	public GuessJokerCheckCardAction(List<int> cardIdList)
	{
		this.CardIdList = cardIdList;
	}

	// Token: 0x0600707B RID: 28795 RVA: 0x001D5D10 File Offset: 0x001D3F10
	protected override void OnStart()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
		{
			this.Done = true;
			return;
		}
		List<GuessJokerCardItem> cardItemList = new List<GuessJokerCardItem>();
		for (int i = 0; i < this.CardIdList.Count; i++)
		{
			int cardId = this.CardIdList[i];
			GuessJokerCardItem cardItemById = gamePlayView.GetCardItemById(cardId);
			if (cardItemById != null)
			{
				cardItemList.Add(cardItemById);
			}
		}
		if (cardItemList.Count == 0)
		{
			this.Done = true;
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.GuessJokerCard, ELogAuthor.LRC, "check card id list: " + string.Join<int>(",", this.CardIdList), default(ReadOnlySpan<ValueTuple<string, object>>));
		int currentIndex = 0;
		Action processNext = null;
		Action <>9__3;
		processNext = delegate()
		{
			if (currentIndex >= cardItemList.Count)
			{
				this.Done = true;
				return;
			}
			GuessJokerCardItem cardItem = cardItemList[currentIndex];
			bool isLast = currentIndex == cardItemList.Count - 1;
			Action <>9__2;
			cardItem.PlayCardSequence("EvilSle", delegate
			{
				GuessJokerCardItem cardItem;
				if (isLast)
				{
					cardItem = cardItem;
					string sequenceName = "EvilPress";
					Action finishCallback;
					if ((finishCallback = <>9__2) == null)
					{
						finishCallback = (<>9__2 = delegate()
						{
							cardItem.SetChecking();
							this.Done = true;
						});
					}
					cardItem.PlayCardSequence(sequenceName, finishCallback);
					return;
				}
				GuessJokerCardItem cardItem2 = cardItem;
				string sequenceName2 = "EvilUnsle";
				Action finishCallback2;
				if ((finishCallback2 = <>9__3) == null)
				{
					finishCallback2 = (<>9__3 = delegate()
					{
						int currentIndex = currentIndex;
						currentIndex++;
						processNext();
					});
				}
				cardItem2.PlayCardSequence(sequenceName2, finishCallback2);
			});
		};
		processNext();
	}

	// Token: 0x04003619 RID: 13849
	private readonly List<int> CardIdList;
}
