using System;

// Token: 0x020010E6 RID: 4326
public class GuessJokerWaitAction : GuessJokerActionBase
{
	// Token: 0x060070AB RID: 28843 RVA: 0x001D6CF8 File Offset: 0x001D4EF8
	public GuessJokerWaitAction(float waitTime)
	{
		this.Duration = waitTime;
	}

	// Token: 0x060070AC RID: 28844 RVA: 0x001D6D07 File Offset: 0x001D4F07
	protected override void OnStart()
	{
	}
}
