using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020010E4 RID: 4324
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerUpCardsAction : GuessJokerActionBase
{
	// Token: 0x060070A6 RID: 28838 RVA: 0x001D6B72 File Offset: 0x001D4D72
	public GuessJokerUpCardsAction(int[] cardIdList, bool isUp = true)
	{
		this.CardIdList.AddRange(cardIdList);
		this.IsUp = isUp;
	}

	// Token: 0x060070A7 RID: 28839 RVA: 0x001D6B98 File Offset: 0x001D4D98
	protected override void OnStart()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
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
				list.Add(cardItemById);
			}
		}
		if (list.Count == 0)
		{
			this.Done = true;
			return;
		}
		bool[] completedFlags = new bool[list.Count];
		for (int j = 0; j < completedFlags.Length; j++)
		{
			completedFlags[j] = false;
		}
		for (int k = 0; k < list.Count; k++)
		{
			GuessJokerCardItem guessJokerCardItem = list[k];
			int index = k;
			guessJokerCardItem.CardUp(this.IsUp, delegate
			{
				completedFlags[index] = true;
				bool flag = true;
				for (int l = 0; l < completedFlags.Length; l++)
				{
					if (!completedFlags[l])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					this.Done = true;
				}
			});
		}
	}

	// Token: 0x0400362F RID: 13871
	private readonly List<int> CardIdList = new List<int>();

	// Token: 0x04003630 RID: 13872
	private readonly bool IsUp;
}
