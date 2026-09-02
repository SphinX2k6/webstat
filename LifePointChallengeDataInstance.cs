using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001349 RID: 4937
public class LifePointChallengeDataInstance
{
	// Token: 0x060086E8 RID: 34536 RVA: 0x002383D4 File Offset: 0x002365D4
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x060086E9 RID: 34537 RVA: 0x002383DC File Offset: 0x002365DC
	public bool GetHasGetReward()
	{
		return this.HasGetReward;
	}

	// Token: 0x060086EA RID: 34538 RVA: 0x002383E4 File Offset: 0x002365E4
	public long GetOpenTime()
	{
		return this.OpenTime / 1000L;
	}

	// Token: 0x060086EB RID: 34539 RVA: 0x002383F3 File Offset: 0x002365F3
	public int GetRewardId()
	{
		return this.RewardId;
	}

	// Token: 0x060086EC RID: 34540 RVA: 0x002383FB File Offset: 0x002365FB
	public int GetEntityConfigId()
	{
		return this.EntityConfigId;
	}

	// Token: 0x060086ED RID: 34541 RVA: 0x00238403 File Offset: 0x00236603
	public bool GetPreChallengeState()
	{
		return this.PreChallengeState;
	}

	// Token: 0x060086EE RID: 34542 RVA: 0x0023840C File Offset: 0x0023660C
	[NullableContext(1)]
	public void Phrase(LifePointChallengeData data)
	{
		this.Id = data.ChallengeId;
		this.HasGetReward = data.Rewarded;
		this.OpenTime = data.OpenTime;
		this.RewardId = data.RewardId;
		this.EntityConfigId = data.EntityConfigId;
		this.PreChallengeState = data.PreChallenged;
	}

	// Token: 0x04003FA7 RID: 16295
	private int Id;

	// Token: 0x04003FA8 RID: 16296
	private bool HasGetReward;

	// Token: 0x04003FA9 RID: 16297
	private long OpenTime;

	// Token: 0x04003FAA RID: 16298
	private int RewardId;

	// Token: 0x04003FAB RID: 16299
	private int EntityConfigId;

	// Token: 0x04003FAC RID: 16300
	private bool PreChallengeState;
}
