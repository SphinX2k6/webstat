using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02000D10 RID: 3344
public class AiWanderInfos
{
	// Token: 0x06004329 RID: 17193 RVA: 0x0007D06B File Offset: 0x0007B26B
	public void SetOverrideBattleWanderTime(float min, float max)
	{
		this.OverrideBattleWanderTimeMin = new float?(min);
		this.OverrideBattleWanderTimeMax = new float?(max);
	}

	// Token: 0x0600432A RID: 17194 RVA: 0x0007D085 File Offset: 0x0007B285
	public AiBattleWanderGroup GetCurrentBattleWander()
	{
		return this.AiBattleWanderGroups[this.CurrentBattleWanderIndex];
	}

	// Token: 0x0600432B RID: 17195 RVA: 0x0007D098 File Offset: 0x0007B298
	public double RandomBattleWanderEndTime()
	{
		if (this.OverrideBattleWanderTimeMin != null)
		{
			float? overrideBattleWanderTimeMin = this.OverrideBattleWanderTimeMin;
			float? overrideBattleWanderTimeMax = this.OverrideBattleWanderTimeMax;
			if (overrideBattleWanderTimeMin.GetValueOrDefault() <= overrideBattleWanderTimeMax.GetValueOrDefault() & (overrideBattleWanderTimeMin != null & overrideBattleWanderTimeMax != null))
			{
				return Singleton<MathUtils>.Instance.GetRandomRange((double)this.OverrideBattleWanderTimeMin.Value, (double)this.OverrideBattleWanderTimeMax.Value);
			}
		}
		FloatRange? sumWanderTime = this.GetCurrentBattleWander().SumWanderTime;
		return Singleton<MathUtils>.Instance.GetRandomRange((double)sumWanderTime.Value.Min, (double)sumWanderTime.Value.Max);
	}

	// Token: 0x04001178 RID: 4472
	public AiWander? AiWander;

	// Token: 0x04001179 RID: 4473
	[Nullable(2)]
	public List<AiBattleWanderGroup> AiBattleWanderGroups;

	// Token: 0x0400117A RID: 4474
	public int CurrentBattleWanderIndex;

	// Token: 0x0400117B RID: 4475
	private float? OverrideBattleWanderTimeMin;

	// Token: 0x0400117C RID: 4476
	private float? OverrideBattleWanderTimeMax;

	// Token: 0x0400117D RID: 4477
	public float BattleWanderAddTime;
}
