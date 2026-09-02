using System;
using System.Runtime.CompilerServices;

// Token: 0x02002966 RID: 10598
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ScoreModel : ModelBase<ScoreModel>
{
	// Token: 0x06015136 RID: 86326 RVA: 0x005D53CD File Offset: 0x005D35CD
	public int GetCurrentScore()
	{
		return this.CurrentScore;
	}

	// Token: 0x06015137 RID: 86327 RVA: 0x005D53D5 File Offset: 0x005D35D5
	public int GetTargetScore()
	{
		return this.TargetScore;
	}

	// Token: 0x06015138 RID: 86328 RVA: 0x005D53DD File Offset: 0x005D35DD
	public void SetCurrentScore(int score)
	{
		this.CurrentScore = score;
	}

	// Token: 0x06015139 RID: 86329 RVA: 0x005D53E6 File Offset: 0x005D35E6
	public void SetTargetScore(int score)
	{
		this.TargetScore = score;
	}

	// Token: 0x0601513A RID: 86330 RVA: 0x005D53EF File Offset: 0x005D35EF
	public void SetScore(int currentScore, int targetScore)
	{
		this.CurrentScore = currentScore;
		this.TargetScore = targetScore;
	}

	// Token: 0x0601513B RID: 86331 RVA: 0x005D53FF File Offset: 0x005D35FF
	public void Reset()
	{
		this.CurrentScore = 0;
		this.TargetScore = 0;
	}

	// Token: 0x0400A24D RID: 41549
	private int CurrentScore;

	// Token: 0x0400A24E RID: 41550
	private int TargetScore;
}
