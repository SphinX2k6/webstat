using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Google.Protobuf.Collections;

// Token: 0x020012B9 RID: 4793
[NullableContext(1)]
[Nullable(0)]
public class CumulativeShopData : ActivityBaseData
{
	// Token: 0x17000AED RID: 2797
	// (get) Token: 0x060080B8 RID: 32952 RVA: 0x00220140 File Offset: 0x0021E340
	public Dictionary<int, ConsumptiveTaskInfo> TaskDataMap { get; } = new Dictionary<int, ConsumptiveTaskInfo>();

	// Token: 0x17000AEE RID: 2798
	// (get) Token: 0x060080B9 RID: 32953 RVA: 0x00220148 File Offset: 0x0021E348
	public Dictionary<int, List<int>> TaskTabMap { get; } = new Dictionary<int, List<int>>();

	// Token: 0x060080BA RID: 32954 RVA: 0x00220150 File Offset: 0x0021E350
	protected override void PhraseEx(ActivityData data)
	{
		this.TaskDataMap.Clear();
		this.TaskTabMap.Clear();
		ConsumptiveActivityInfo consumptiveActivityInfo = data.ConsumptiveActivityInfo;
		if (this.CheckIfInOpenTime() && consumptiveActivityInfo != null)
		{
			this.TotalScore = consumptiveActivityInfo.TotalScore;
		}
		else
		{
			this.TotalScore = 0;
			ControllerBase<CumulativeShopController>.Instance.ConsumptiveActivityScoreRequest();
		}
		RepeatedField<ConsumptiveTaskInfo> repeatedField = (consumptiveActivityInfo != null) ? consumptiveActivityInfo.Tasks : null;
		if (repeatedField != null)
		{
			foreach (ConsumptiveTaskInfo consumptiveTaskInfo in repeatedField)
			{
				this.TaskDataMap[consumptiveTaskInfo.Id] = consumptiveTaskInfo;
				int taskTab = ConfigBase<CumulativeShopConfig>.Instance.GetCumulativeShopTaskConfig(consumptiveTaskInfo.Id).Value.TaskTab;
				List<int> list;
				if (!this.TaskTabMap.TryGetValue(taskTab, out list) || list == null)
				{
					list = new List<int>();
				}
				list.Add(consumptiveTaskInfo.Id);
				this.TaskTabMap[taskTab] = list;
			}
		}
		this.CurrencyId = 0;
		this.ShopId = 0;
		ConsumptiveActivity? config = ConfigConsumptiveActivityById.GetConfig(data.Id, true);
		if (config == null)
		{
			return;
		}
		this.ShopId = config.Value.ShopId;
		this.CurrencyId = config.Value.ScoreItemId;
	}

	// Token: 0x060080BB RID: 32955 RVA: 0x002202B4 File Offset: 0x0021E4B4
	public bool GetAnyTaskRedDot()
	{
		foreach (KeyValuePair<int, ConsumptiveTaskInfo> keyValuePair in this.TaskDataMap)
		{
			if (keyValuePair.Value.Reward.WaitReward > 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060080BC RID: 32956 RVA: 0x0022031C File Offset: 0x0021E51C
	public bool GetTaskTabRedDot(int tabIndex)
	{
		List<int> list;
		if (!this.TaskTabMap.TryGetValue(tabIndex, out list) || list == null)
		{
			return false;
		}
		foreach (int key in list)
		{
			ConsumptiveTaskInfo consumptiveTaskInfo;
			if (this.TaskDataMap.TryGetValue(key, out consumptiveTaskInfo) && consumptiveTaskInfo.Reward.WaitReward > 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060080BD RID: 32957 RVA: 0x002203A0 File Offset: 0x0021E5A0
	public override bool GetExDataRedPointShowState()
	{
		return this.GetAnyTaskRedDot();
	}

	// Token: 0x060080BE RID: 32958 RVA: 0x002203A8 File Offset: 0x0021E5A8
	public List<int> GetTabTaskList(int tabIndex)
	{
		List<int> list;
		if (!this.TaskTabMap.TryGetValue(tabIndex, out list) || list == null)
		{
			return new List<int>();
		}
		List<int> list2 = new List<int>(list);
		list2.Sort(delegate(int a, int b)
		{
			ConsumptiveTaskReward reward = this.TaskDataMap[a].Reward;
			ConsumptiveTaskReward reward2 = this.TaskDataMap[b].Reward;
			if (reward.WaitReward != reward2.WaitReward)
			{
				int num = (reward.WaitReward > 0) ? -1 : 1;
				int num2 = (reward2.WaitReward > 0) ? -1 : 1;
				return num - num2;
			}
			if (reward.MaxReward == 0 && reward2.MaxReward == 0)
			{
				return a - b;
			}
			int num3 = (reward.MaxReward == 0) ? -1 : ((reward.Rewarded < reward.MaxReward) ? -1 : 1);
			int num4 = (reward2.MaxReward == 0) ? -1 : ((reward2.Rewarded < reward2.MaxReward) ? -1 : 1);
			return num3 - num4;
		});
		return list2;
	}

	// Token: 0x04003D5C RID: 15708
	public int ShopId;

	// Token: 0x04003D5D RID: 15709
	public int CurrencyId;

	// Token: 0x04003D5E RID: 15710
	public int TotalScore;

	// Token: 0x04003D5F RID: 15711
	public bool ScoreRequesting;
}
