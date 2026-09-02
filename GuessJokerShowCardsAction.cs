using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020010E2 RID: 4322
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerShowCardsAction : GuessJokerActionBase
{
	// Token: 0x060070A2 RID: 28834 RVA: 0x001D6A1C File Offset: 0x001D4C1C
	public GuessJokerShowCardsAction(int[] cardIdList, bool isShow, float duration = 0f)
	{
		this.CardIdList.AddRange(cardIdList);
		if (duration != 0f)
		{
			this.Duration = duration;
		}
		else
		{
			this.Duration = 1000f;
		}
		this.IsShow = isShow;
	}

	// Token: 0x060070A3 RID: 28835 RVA: 0x001D6A6C File Offset: 0x001D4C6C
	protected override void OnStart()
	{
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
		{
			this.Done = true;
			return;
		}
		gamePlayView.ShowCards(this.CardIdList.ToArray(), this.IsShow);
	}

	// Token: 0x0400362C RID: 13868
	private readonly List<int> CardIdList = new List<int>();

	// Token: 0x0400362D RID: 13869
	private readonly bool IsShow;
}
