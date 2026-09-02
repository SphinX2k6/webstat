using System;
using System.Runtime.CompilerServices;

// Token: 0x020011BA RID: 4538
public class ArtemisQteGameInfo
{
	// Token: 0x0600775E RID: 30558 RVA: 0x001F3BCD File Offset: 0x001F1DCD
	public void CreateRingInfo(EArrowDirection arrowDirection)
	{
		this.RingInfo = new ArtemisQteRingInfo(arrowDirection);
	}

	// Token: 0x0600775F RID: 30559 RVA: 0x001F3BDB File Offset: 0x001F1DDB
	[NullableContext(1)]
	public ArtemisQteRingInfo GetRingInfo()
	{
		return this.RingInfo;
	}

	// Token: 0x06007760 RID: 30560 RVA: 0x001F3BE3 File Offset: 0x001F1DE3
	public void Clear()
	{
		ArtemisQteRingInfo ringInfo = this.RingInfo;
		if (ringInfo != null)
		{
			ringInfo.Clear();
		}
		this.RingInfo = null;
		this.GameStage = EArtemisQteStage.None;
		this.CurrentScore = 0;
		this.CurrentRound = 0;
		this.MaxRound = 0;
	}

	// Token: 0x06007761 RID: 30561 RVA: 0x001F3C19 File Offset: 0x001F1E19
	public void SetGameStage(EArtemisQteStage stage)
	{
		this.GameStage = stage;
	}

	// Token: 0x06007762 RID: 30562 RVA: 0x001F3C22 File Offset: 0x001F1E22
	public EArtemisQteStage GetGameStage()
	{
		return this.GameStage;
	}

	// Token: 0x06007763 RID: 30563 RVA: 0x001F3C2A File Offset: 0x001F1E2A
	public bool IsGamePause()
	{
		return this.GameStage != EArtemisQteStage.OnGoing;
	}

	// Token: 0x06007764 RID: 30564 RVA: 0x001F3C38 File Offset: 0x001F1E38
	public bool IsGameEnd()
	{
		return this.GameStage >= EArtemisQteStage.End;
	}

	// Token: 0x040039BE RID: 14782
	[Nullable(2)]
	private ArtemisQteRingInfo RingInfo;

	// Token: 0x040039BF RID: 14783
	private EArtemisQteStage GameStage;

	// Token: 0x040039C0 RID: 14784
	public int CurrentScore;

	// Token: 0x040039C1 RID: 14785
	public int CurrentRound;

	// Token: 0x040039C2 RID: 14786
	public int MaxRound;

	// Token: 0x040039C3 RID: 14787
	public float CursorSpeed;

	// Token: 0x040039C4 RID: 14788
	public float RingSpeed;

	// Token: 0x040039C5 RID: 14789
	public float PerfectAppearRate;
}
