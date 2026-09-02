using System;

// Token: 0x02003043 RID: 12355
public class CharacterHitOptimize
{
	// Token: 0x06019505 RID: 103685 RVA: 0x00749E4C File Offset: 0x0074804C
	public bool IsInCooling()
	{
		return Singleton<Time>.Instance.WorldTime - this.LastHitTime < 1000.0;
	}

	// Token: 0x06019506 RID: 103686 RVA: 0x00749E6A File Offset: 0x0074806A
	public void UpdateLastHitTime()
	{
		this.LastHitTime = Singleton<Time>.Instance.WorldTime;
	}

	// Token: 0x0400C7F1 RID: 51185
	private const float COOLDOWN_TIME_MS = 1000f;

	// Token: 0x0400C7F2 RID: 51186
	private double LastHitTime;
}
