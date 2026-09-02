using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001A9E RID: 6814
[NullableContext(1)]
[Nullable(0)]
public class WeeklyActivityRewardAdapter : DailyActivityDefine.IActivityRewardPanelDataAdapter
{
	// Token: 0x17000FFC RID: 4092
	// (get) Token: 0x0600C339 RID: 49977 RVA: 0x00337150 File Offset: 0x00335350
	public double CurrentValue
	{
		get
		{
			return (double)ModelBase<WeeklyChallengeModel>.Instance.WeeklyCurrentScore;
		}
	}

	// Token: 0x17000FFD RID: 4093
	// (get) Token: 0x0600C33A RID: 49978 RVA: 0x0033715D File Offset: 0x0033535D
	public double MaxValue
	{
		get
		{
			return (double)ModelBase<WeeklyChallengeModel>.Instance.WeeklyMaxScore;
		}
	}

	// Token: 0x17000FFE RID: 4094
	// (get) Token: 0x0600C33B RID: 49979 RVA: 0x0033716A File Offset: 0x0033536A
	public IReadOnlyDictionary<int, DailyActivityDefine.IActivityGoalData> GoalMap
	{
		get
		{
			return ModelBase<WeeklyChallengeModel>.Instance.WeeklyGoalMap;
		}
	}

	// Token: 0x0600C33C RID: 49980 RVA: 0x00337176 File Offset: 0x00335376
	public List<int> GetCanRewardIdList()
	{
		return ModelBase<WeeklyChallengeModel>.Instance.GetCanRewardIdList();
	}

	// Token: 0x0600C33D RID: 49981 RVA: 0x00337182 File Offset: 0x00335382
	public void RequestReward(List<int> idList, Action onClose)
	{
		ControllerBase<WeeklyChallengeController>.Instance.RequestWeeklyFrameworkScoreReward(idList);
		onClose();
	}

	// Token: 0x0600C33E RID: 49982 RVA: 0x00337195 File Offset: 0x00335395
	public List<TItem> GetRewardById(int id)
	{
		return ModelBase<WeeklyChallengeModel>.Instance.GetRewardById(id);
	}
}
