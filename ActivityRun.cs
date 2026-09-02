using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001587 RID: 5511
[NullableContext(1)]
[Nullable(0)]
public class ActivityRun : ActivityBaseData
{
	// Token: 0x06009AEC RID: 39660 RVA: 0x002892B0 File Offset: 0x002874B0
	protected override void PhraseEx(ActivityData data)
	{
		this.CurrentChallenges = new List<ActivityRunData>();
		ParkourActivity parkourActivity = data.ParkourActivity;
		if (((parkourActivity != null) ? parkourActivity.Challenges : null) != null)
		{
			foreach (ParkourActivityChallenge parkourActivityChallenge in data.ParkourActivity.Challenges)
			{
				ActivityRunData activityRunData = ModelBase<ActivityRunModel>.Instance.CreateActivityRunData(data.Id, parkourActivityChallenge.ChallengeId);
				activityRunData.Phrase(parkourActivityChallenge);
				this.CurrentChallenges.Add(activityRunData);
				this.ChallengeActivityMap[(long)parkourActivityChallenge.ChallengeId] = (long)data.Id;
			}
		}
	}

	// Token: 0x06009AED RID: 39661 RVA: 0x00289360 File Offset: 0x00287560
	public long GetChallengeActivityId(long challengeId)
	{
		long result;
		if (this.ChallengeActivityMap.TryGetValue(challengeId, out result))
		{
			return result;
		}
		return 0L;
	}

	// Token: 0x06009AEE RID: 39662 RVA: 0x00289381 File Offset: 0x00287581
	public List<ActivityRunData> GetChallengeDataArray()
	{
		return this.CurrentChallenges;
	}

	// Token: 0x06009AEF RID: 39663 RVA: 0x00289389 File Offset: 0x00287589
	public void SetActivityContentIndex(int index)
	{
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, -256, base.Id, 0, index);
	}

	// Token: 0x06009AF0 RID: 39664 RVA: 0x002893A8 File Offset: 0x002875A8
	public int GetActivityContentIndex()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, -256, base.Id, 0);
	}

	// Token: 0x06009AF1 RID: 39665 RVA: 0x002893C8 File Offset: 0x002875C8
	public override bool GetExDataRedPointShowState()
	{
		int count = this.CurrentChallenges.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.CurrentChallenges[i].GetRedPoint())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06009AF2 RID: 39666 RVA: 0x00289403 File Offset: 0x00287603
	public override bool NeedSelfControlFirstRedPoint()
	{
		return false;
	}

	// Token: 0x06009AF3 RID: 39667 RVA: 0x00289408 File Offset: 0x00287608
	public bool IfAllFinish()
	{
		int count = this.CurrentChallenges.Count;
		for (int i = 0; i < count; i++)
		{
			if (!this.CurrentChallenges[i].GetIfRewardAllFinished())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x04004750 RID: 18256
	private const int ACTIVITYSELECTCACHEKEY = -256;

	// Token: 0x04004751 RID: 18257
	private readonly Dictionary<long, long> ChallengeActivityMap = new Dictionary<long, long>();

	// Token: 0x04004752 RID: 18258
	private List<ActivityRunData> CurrentChallenges = new List<ActivityRunData>();
}
