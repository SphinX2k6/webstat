using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x0200158C RID: 5516
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ActivityRunModel : ModelBase<ActivityRunModel>
{
	// Token: 0x06009B32 RID: 39730 RVA: 0x0028A2B8 File Offset: 0x002884B8
	public void OnReceiveMessageData(ParkourChallengeResponse data)
	{
		if (data.Challenges != null)
		{
			foreach (ParkourChallenge parkourChallenge in data.Challenges)
			{
				this.GetActivityRunData(parkourChallenge.ChallengeId).Phrase(parkourChallenge);
			}
		}
		if (data.OpenIds != null)
		{
			foreach (int id in data.OpenIds)
			{
				this.GetActivityRunData(id).SetIsOpen(true);
			}
		}
	}

	// Token: 0x06009B33 RID: 39731 RVA: 0x0028A364 File Offset: 0x00288564
	public void OnReceiveChallengeOpenNotify(ParkourChallengeOpenNotify message)
	{
		ActivityRunData activityRunData = this.GetActivityRunData(message.ChallengeId);
		activityRunData.SetIsOpen(message.IsOpen);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityRunData.GetActivityId());
	}

	// Token: 0x06009B34 RID: 39732 RVA: 0x0028A3A0 File Offset: 0x002885A0
	public void OnGetChallengeReward(int challengeId, int scoreIndex)
	{
		ActivityRunData activityRunData = this.GetActivityRunData(challengeId);
		activityRunData.OnGetScoreReward(scoreIndex);
		int scoreIndexScore = activityRunData.GetScoreIndexScore(scoreIndex);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnGetRunActivityReward, scoreIndexScore);
	}

	// Token: 0x06009B35 RID: 39733 RVA: 0x0028A3D4 File Offset: 0x002885D4
	public int[] GetOpenChallengeIds()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, ActivityRunData> keyValuePair in this.ActivityMap)
		{
			if (keyValuePair.Value.GetIsShow())
			{
				list.Add(keyValuePair.Key);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06009B36 RID: 39734 RVA: 0x0028A448 File Offset: 0x00288648
	public int[] GetChallengeIds()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, ActivityRunData> keyValuePair in this.ActivityMap)
		{
			list.Add(keyValuePair.Key);
		}
		return list.ToArray();
	}

	// Token: 0x06009B37 RID: 39735 RVA: 0x0028A4B0 File Offset: 0x002886B0
	public ActivityRunData GetActivityRunData(int id)
	{
		ActivityRunData result;
		if (this.ActivityMap.TryGetValue(id, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06009B38 RID: 39736 RVA: 0x0028A4D0 File Offset: 0x002886D0
	public ActivityRunData CreateActivityRunData(int activityId, int id)
	{
		ActivityRunData activityRunData;
		if (!this.ActivityMap.TryGetValue(id, out activityRunData))
		{
			activityRunData = new ActivityRunData(activityId);
			this.ActivityMap[id] = activityRunData;
		}
		return activityRunData;
	}

	// Token: 0x06009B39 RID: 39737 RVA: 0x0028A504 File Offset: 0x00288704
	public int GetDefaultOpenUiChallengeIndex(ActivityBaseData baseData)
	{
		ActivityRun activityRun = baseData as ActivityRun;
		if (activityRun == null)
		{
			return 0;
		}
		List<ActivityRunData> challengeDataArray = activityRun.GetChallengeDataArray();
		if (activityRun.IfAllFinish())
		{
			this.StartViewSelectIndex = challengeDataArray.Count - 1;
			return challengeDataArray.Count - 1;
		}
		return activityRun.GetActivityContentIndex();
	}

	// Token: 0x06009B3A RID: 39738 RVA: 0x0028A549 File Offset: 0x00288749
	public void SetStartViewSelectIndex(int index)
	{
		this.StartViewSelectIndex = index;
	}

	// Token: 0x06009B3B RID: 39739 RVA: 0x0028A552 File Offset: 0x00288752
	public int GetStartViewSelectIndex()
	{
		return this.StartViewSelectIndex;
	}

	// Token: 0x06009B3C RID: 39740 RVA: 0x0028A55C File Offset: 0x0028875C
	public ActivityRunData GetChallengeDataByMarkId(int markId)
	{
		int[] challengeIds = this.GetChallengeIds();
		int num = challengeIds.Length;
		if (num == 0)
		{
			return null;
		}
		int num2 = -1;
		for (int i = 0; i < num; i++)
		{
			ActivityRunData activityRunData = this.GetActivityRunData(challengeIds[i]);
			if (activityRunData != null && activityRunData.GetMarkId() == (long)markId)
			{
				num2 = i;
			}
		}
		if (num2 == -1)
		{
			num2 = 0;
		}
		return this.GetActivityRunData(challengeIds[num2]);
	}

	// Token: 0x0400476C RID: 18284
	public int CurrentSelectChallengeId;

	// Token: 0x0400476D RID: 18285
	private int StartViewSelectIndex;

	// Token: 0x0400476E RID: 18286
	private readonly Dictionary<int, ActivityRunData> ActivityMap = new Dictionary<int, ActivityRunData>();
}
