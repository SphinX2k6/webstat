using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02001BA3 RID: 7075
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class FeedbackRewardModel : ModelBase<FeedbackRewardModel>
{
	// Token: 0x0600CDC5 RID: 52677 RVA: 0x0036CFFC File Offset: 0x0036B1FC
	protected override bool OnInit()
	{
		foreach (GivebackScoreReward givebackScoreReward in (ConfigBase<FeedbackRewardConfig>.Instance.GetGivebackScoreRewardAll() ?? new List<GivebackScoreReward>()))
		{
			this.FeedbackRewardStateMap.Add(givebackScoreReward.Id, EFeedbackRewardState.UnFinish);
		}
		foreach (GivebackTask givebackTask in (ConfigBase<FeedbackRewardConfig>.Instance.GetGivebackTaskAll() ?? new List<GivebackTask>()))
		{
			this.FeedbackTaskMap.Add(givebackTask.TaskId, 0);
		}
		this.MaxShowScore = ConfigCommonParamById.GetIntConfig("FeedbackRewardMaxScore").GetValueOrDefault();
		return true;
	}

	// Token: 0x0600CDC6 RID: 52678 RVA: 0x0036D0D4 File Offset: 0x0036B2D4
	public List<int> GetAllRewardList()
	{
		return new List<int>(this.FeedbackRewardStateMap.Keys);
	}

	// Token: 0x0600CDC7 RID: 52679 RVA: 0x0036D0E8 File Offset: 0x0036B2E8
	public EFeedbackRewardState GetFeedbackRewardState(int id)
	{
		EFeedbackRewardState result;
		if (this.FeedbackRewardStateMap.TryGetValue(id, out result))
		{
			return result;
		}
		return EFeedbackRewardState.UnFinish;
	}

	// Token: 0x0600CDC8 RID: 52680 RVA: 0x0036D108 File Offset: 0x0036B308
	public int GetFeedbackTaskCurrentPoint(int id)
	{
		int result;
		if (this.FeedbackTaskMap.TryGetValue(id, out result))
		{
			return result;
		}
		return 0;
	}

	// Token: 0x0600CDC9 RID: 52681 RVA: 0x0036D128 File Offset: 0x0036B328
	public List<int> GetFeedbackTaskList()
	{
		return new List<int>(this.FeedbackTaskMap.Keys);
	}

	// Token: 0x0600CDCA RID: 52682 RVA: 0x0036D13C File Offset: 0x0036B33C
	public List<int> GetFeedbackRewardCanClaim()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, EFeedbackRewardState> keyValuePair in this.FeedbackRewardStateMap)
		{
			if (keyValuePair.Value == EFeedbackRewardState.Finish)
			{
				list.Add(keyValuePair.Key);
			}
		}
		return list;
	}

	// Token: 0x0600CDCB RID: 52683 RVA: 0x0036D1A8 File Offset: 0x0036B3A8
	public void RefreshFeedBackRewardMapState(int[] haveGetRewardIds)
	{
		foreach (KeyValuePair<int, EFeedbackRewardState> keyValuePair in this.FeedbackRewardStateMap)
		{
			int key = keyValuePair.Key;
			if (new List<int>(haveGetRewardIds).Contains(key))
			{
				this.FeedbackRewardStateMap[key] = EFeedbackRewardState.Claimed;
			}
			else if (ConfigBase<FeedbackRewardConfig>.Instance.GetGivebackScoreRewardById(key).Value.Target <= this.CurrentPointCount)
			{
				this.FeedbackRewardStateMap[key] = EFeedbackRewardState.Finish;
			}
		}
	}

	// Token: 0x0600CDCC RID: 52684 RVA: 0x0036D24C File Offset: 0x0036B44C
	public void RefreshFeedBackTask(GivebackTaskPb[] tasks)
	{
		foreach (GivebackTaskPb givebackTaskPb in tasks)
		{
			if (this.FeedbackTaskMap.ContainsKey(givebackTaskPb.Id))
			{
				this.FeedbackTaskMap[givebackTaskPb.Id] = givebackTaskPb.Score;
			}
			else
			{
				this.FeedbackTaskMap.Add(givebackTaskPb.Id, givebackTaskPb.Score);
			}
		}
	}

	// Token: 0x0600CDCD RID: 52685 RVA: 0x0036D2B0 File Offset: 0x0036B4B0
	public List<int> GetCanFinishRewardId()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, EFeedbackRewardState> keyValuePair in this.FeedbackRewardStateMap)
		{
			if (keyValuePair.Value == EFeedbackRewardState.Finish)
			{
				list.Add(keyValuePair.Key);
			}
		}
		return list;
	}

	// Token: 0x0600CDCE RID: 52686 RVA: 0x0036D31C File Offset: 0x0036B51C
	public bool CheckRedDot()
	{
		foreach (KeyValuePair<int, EFeedbackRewardState> keyValuePair in this.FeedbackRewardStateMap)
		{
			if (keyValuePair.Value == EFeedbackRewardState.Finish)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600CDCF RID: 52687 RVA: 0x0036D37C File Offset: 0x0036B57C
	public int GetMaxFinishRewardId()
	{
		int num = 0;
		foreach (KeyValuePair<int, EFeedbackRewardState> keyValuePair in this.FeedbackRewardStateMap)
		{
			if (keyValuePair.Value == EFeedbackRewardState.Finish && num < keyValuePair.Key)
			{
				num = keyValuePair.Key;
			}
		}
		return num;
	}

	// Token: 0x0600CDD0 RID: 52688 RVA: 0x0036D3E8 File Offset: 0x0036B5E8
	public List<int> GetCanClaimRewardIds()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, EFeedbackRewardState> keyValuePair in this.FeedbackRewardStateMap)
		{
			if (keyValuePair.Value == EFeedbackRewardState.Finish)
			{
				list.Add(keyValuePair.Key);
			}
		}
		return list;
	}

	// Token: 0x04006242 RID: 25154
	private readonly Dictionary<int, EFeedbackRewardState> FeedbackRewardStateMap = new Dictionary<int, EFeedbackRewardState>();

	// Token: 0x04006243 RID: 25155
	private readonly Dictionary<int, int> FeedbackTaskMap = new Dictionary<int, int>();

	// Token: 0x04006244 RID: 25156
	public int MaxShowScore;

	// Token: 0x04006245 RID: 25157
	public int CurrentPointCount;

	// Token: 0x04006246 RID: 25158
	public int CurrentLoginDayCount;
}
