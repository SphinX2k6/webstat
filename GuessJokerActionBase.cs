using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020010D6 RID: 4310
public abstract class GuessJokerActionBase
{
	// Token: 0x0600706A RID: 28778 RVA: 0x001D5AED File Offset: 0x001D3CED
	public GuessJokerActionBase()
	{
		this.ActionId = GuessJokerActionBase.SelfIncrementId++;
	}

	// Token: 0x0600706B RID: 28779 RVA: 0x001D5B08 File Offset: 0x001D3D08
	public void Start()
	{
		this.Done = false;
		this.Elapsed = 0f;
		this.OnAddEventListener();
		this.OnStart();
	}

	// Token: 0x0600706C RID: 28780 RVA: 0x001D5B28 File Offset: 0x001D3D28
	public void Tick(float delta)
	{
		if (this.Done)
		{
			return;
		}
		this.OnTick(delta);
		if (this.Duration <= 0f)
		{
			return;
		}
		this.Elapsed += delta;
		if (this.Elapsed >= this.Duration)
		{
			this.Done = true;
		}
	}

	// Token: 0x0600706D RID: 28781 RVA: 0x001D5B76 File Offset: 0x001D3D76
	public void Finish()
	{
		this.OnFinish();
		this.OnRemoveEventListener();
	}

	// Token: 0x0600706E RID: 28782 RVA: 0x001D5B84 File Offset: 0x001D3D84
	public bool IsDone()
	{
		return this.Done;
	}

	// Token: 0x0600706F RID: 28783 RVA: 0x001D5B8C File Offset: 0x001D3D8C
	protected virtual void OnAddEventListener()
	{
	}

	// Token: 0x06007070 RID: 28784 RVA: 0x001D5B8E File Offset: 0x001D3D8E
	protected virtual void OnRemoveEventListener()
	{
	}

	// Token: 0x06007071 RID: 28785 RVA: 0x001D5B90 File Offset: 0x001D3D90
	protected virtual void OnStart()
	{
	}

	// Token: 0x06007072 RID: 28786 RVA: 0x001D5B92 File Offset: 0x001D3D92
	protected virtual void OnTick(float delta)
	{
	}

	// Token: 0x06007073 RID: 28787 RVA: 0x001D5B94 File Offset: 0x001D3D94
	protected virtual void OnFinish()
	{
	}

	// Token: 0x06007074 RID: 28788 RVA: 0x001D5B98 File Offset: 0x001D3D98
	[NullableContext(1)]
	protected void AnimateCardsToTarget(ECardPositionType targetPosition, [Nullable(2)] GuessJokerPositionPanelBase targetPanel, Action onComplete)
	{
		if (targetPanel == null)
		{
			onComplete();
			return;
		}
		List<GuessJokerCardItem> cardItemList = targetPanel.CardItemList;
		if (cardItemList.Count == 0)
		{
			onComplete();
			return;
		}
		ICardLayoutInfo[] array = GuessJokerUtils.CalculateCardLayoutInfo(cardItemList.Count, targetPosition);
		bool[] completedFlags = new bool[cardItemList.Count];
		for (int i = 0; i < cardItemList.Count; i++)
		{
			completedFlags[i] = false;
		}
		for (int j = 0; j < cardItemList.Count; j++)
		{
			int capturedIndex = j;
			GuessJokerCardItem guessJokerCardItem = cardItemList[j];
			ICardLayoutInfo cardLayoutInfo = array[j];
			Vector2D targetPosition2 = new Vector2D((double)cardLayoutInfo.X, (double)cardLayoutInfo.Y);
			guessJokerCardItem.SetAlpha(cardLayoutInfo.Alpha);
			guessJokerCardItem.SmoothMoveTo(targetPosition2, delegate
			{
				completedFlags[capturedIndex] = true;
				bool flag = true;
				for (int k = 0; k < completedFlags.Length; k++)
				{
					if (!completedFlags[k])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					onComplete();
				}
			}, new float?(cardLayoutInfo.Scale), new float?(cardLayoutInfo.Rotation), -1f);
		}
	}

	// Token: 0x04003612 RID: 13842
	public readonly int ActionId;

	// Token: 0x04003613 RID: 13843
	[StaticVariableRuleIgnore]
	private static int SelfIncrementId = 0;

	// Token: 0x04003614 RID: 13844
	protected bool Done;

	// Token: 0x04003615 RID: 13845
	private float Elapsed;

	// Token: 0x04003616 RID: 13846
	protected float Duration;
}
