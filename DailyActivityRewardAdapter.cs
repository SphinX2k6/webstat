using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001A9D RID: 6813
[NullableContext(1)]
[Nullable(0)]
public class DailyActivityRewardAdapter : DailyActivityDefine.IActivityRewardPanelDataAdapter
{
	// Token: 0x17000FF9 RID: 4089
	// (get) Token: 0x0600C332 RID: 49970 RVA: 0x003370FB File Offset: 0x003352FB
	public double CurrentValue
	{
		get
		{
			return (double)ModelBase<DailyActivityModel>.Instance.ActivityValue;
		}
	}

	// Token: 0x17000FFA RID: 4090
	// (get) Token: 0x0600C333 RID: 49971 RVA: 0x00337108 File Offset: 0x00335308
	public double MaxValue
	{
		get
		{
			return (double)ModelBase<DailyActivityModel>.Instance.ActivityMaxValue;
		}
	}

	// Token: 0x17000FFB RID: 4091
	// (get) Token: 0x0600C334 RID: 49972 RVA: 0x00337115 File Offset: 0x00335315
	public IReadOnlyDictionary<int, DailyActivityDefine.IActivityGoalData> GoalMap
	{
		get
		{
			return ModelBase<DailyActivityModel>.Instance.DailyActivityGoalMap;
		}
	}

	// Token: 0x0600C335 RID: 49973 RVA: 0x00337121 File Offset: 0x00335321
	public List<int> GetCanRewardIdList()
	{
		return ModelBase<DailyActivityModel>.Instance.GetCanRewardIdList();
	}

	// Token: 0x0600C336 RID: 49974 RVA: 0x0033712D File Offset: 0x0033532D
	public void RequestReward(List<int> idList, Action onClose)
	{
		ControllerBase<DailyActivityController>.Instance.RequestDailyActivityReward(idList, onClose);
	}

	// Token: 0x0600C337 RID: 49975 RVA: 0x0033713B File Offset: 0x0033533B
	public List<TItem> GetRewardById(int id)
	{
		return ModelBase<DailyActivityModel>.Instance.GetActivityRewardById(id);
	}
}
