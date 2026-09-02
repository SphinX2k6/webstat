using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x0200134F RID: 4943
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class LifePointDrawModel : ModelBase<LifePointDrawModel>
{
	// Token: 0x06008728 RID: 34600 RVA: 0x00239870 File Offset: 0x00237A70
	public string GetProgressByActivityId(int activityId, string formatString)
	{
		LifePointDrawActivityData lifePointDrawActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LifePointDrawActivityData;
		if (lifePointDrawActivityData != null)
		{
			int finishChallengeNumber = lifePointDrawActivityData.GetFinishChallengeNumber();
			int challengeNumber = lifePointDrawActivityData.GetChallengeNumber();
			return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(formatString, null) ?? "", new string[]
			{
				finishChallengeNumber.ToString(),
				challengeNumber.ToString()
			});
		}
		return "";
	}

	// Token: 0x06008729 RID: 34601 RVA: 0x002398D4 File Offset: 0x00237AD4
	public bool GetGroupUnlockState(int activityId, int groupId)
	{
		LifePointDrawActivityData lifePointDrawActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LifePointDrawActivityData;
		return lifePointDrawActivityData != null && lifePointDrawActivityData.GetGroupIfOverUnlockTime(groupId);
	}

	// Token: 0x0600872A RID: 34602 RVA: 0x00239900 File Offset: 0x00237B00
	public long GetGroupUnlockTime(int activityId, int groupId)
	{
		LifePointDrawActivityData lifePointDrawActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LifePointDrawActivityData;
		if (lifePointDrawActivityData != null)
		{
			return lifePointDrawActivityData.GetGroupUnlockTime(groupId);
		}
		return 0L;
	}

	// Token: 0x0600872B RID: 34603 RVA: 0x0023992C File Offset: 0x00237B2C
	public bool GetGroupRewardState(int activityId, int groupId)
	{
		LifePointDrawActivityData lifePointDrawActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LifePointDrawActivityData;
		return lifePointDrawActivityData != null && lifePointDrawActivityData.GetGroupHasGetReward(groupId);
	}

	// Token: 0x0600872C RID: 34604 RVA: 0x00239958 File Offset: 0x00237B58
	public string GetGroupRewardProgress(int activityId, int groupId)
	{
		LifePointDrawActivityData lifePointDrawActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LifePointDrawActivityData;
		if (lifePointDrawActivityData != null)
		{
			int groupRewardProgress = lifePointDrawActivityData.GetGroupRewardProgress(groupId);
			int groupChallengeNumber = lifePointDrawActivityData.GetGroupChallengeNumber(groupId);
			return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Colorful_Challenge_Progress", null) ?? "", new string[]
			{
				groupRewardProgress.ToString(),
				groupChallengeNumber.ToString()
			});
		}
		return "";
	}

	// Token: 0x0600872D RID: 34605 RVA: 0x002399C4 File Offset: 0x00237BC4
	public bool GetGroupRedDotState(int groupId)
	{
		LifePointGroup? lifePointGroupByGroupId = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointGroupByGroupId(groupId);
		if (lifePointGroupByGroupId == null)
		{
			return false;
		}
		for (int i = 0; i < lifePointGroupByGroupId.Value.ChallengeListLength; i++)
		{
			int challengeId = lifePointGroupByGroupId.Value.ChallengeList(i);
			if (this.GetChallengeRedDotState(challengeId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600872E RID: 34606 RVA: 0x00239A20 File Offset: 0x00237C20
	public bool GetChallengeFinishState(int activityId, int challengeId)
	{
		LifePointDrawActivityData lifePointDrawActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LifePointDrawActivityData;
		return lifePointDrawActivityData != null && lifePointDrawActivityData.GetChallengeIfGetReward(challengeId);
	}

	// Token: 0x0600872F RID: 34607 RVA: 0x00239A4C File Offset: 0x00237C4C
	public bool GetChallengeRequireFinishState(int activityId, int challengeId)
	{
		LifePointDrawActivityData lifePointDrawActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LifePointDrawActivityData;
		return lifePointDrawActivityData != null && lifePointDrawActivityData.GetChallengeRequireFinishState(challengeId);
	}

	// Token: 0x06008730 RID: 34608 RVA: 0x00239A78 File Offset: 0x00237C78
	public bool GetChallengeRedDotState(int challengeId)
	{
		List<ActivityBaseData> currentShowingActivities = ModelBase<ActivityModel>.Instance.GetCurrentShowingActivities();
		LifePointDrawActivityData lifePointDrawActivityData = null;
		foreach (ActivityBaseData activityBaseData in currentShowingActivities)
		{
			if (activityBaseData.Type == ActivityType.LifePointChallenge)
			{
				LifePointDrawActivityData lifePointDrawActivityData2 = activityBaseData as LifePointDrawActivityData;
				if (lifePointDrawActivityData2.CheckIfHaveChallenge(challengeId))
				{
					lifePointDrawActivityData = lifePointDrawActivityData2;
					break;
				}
			}
		}
		if (lifePointDrawActivityData == null)
		{
			return false;
		}
		bool activityCacheData = ModelBase<ActivityModel>.Instance.GetActivityCacheData(lifePointDrawActivityData.Id, 0, challengeId, 0, 0) != 0;
		int groupId = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointChallengeById(challengeId).Value.GroupId;
		bool challengeRequireFinishState = this.GetChallengeRequireFinishState(lifePointDrawActivityData.Id, challengeId);
		return !activityCacheData && lifePointDrawActivityData.GetGroupIfOverUnlockTime(groupId) && challengeRequireFinishState;
	}

	// Token: 0x06008731 RID: 34609 RVA: 0x00239B44 File Offset: 0x00237D44
	public void SaveChallengeRedDotState(int activityId, int challengeId)
	{
		List<ActivityBaseData> currentShowingActivities = ModelBase<ActivityModel>.Instance.GetCurrentShowingActivities();
		LifePointDrawActivityData lifePointDrawActivityData = null;
		foreach (ActivityBaseData activityBaseData in currentShowingActivities)
		{
			if (activityBaseData.Type == ActivityType.LifePointChallenge)
			{
				LifePointDrawActivityData lifePointDrawActivityData2 = activityBaseData as LifePointDrawActivityData;
				if (lifePointDrawActivityData2.CheckIfHaveChallenge(challengeId))
				{
					lifePointDrawActivityData = lifePointDrawActivityData2;
					break;
				}
			}
		}
		if (lifePointDrawActivityData == null)
		{
			return;
		}
		ModelBase<ActivityModel>.Instance.SaveActivityData(activityId, challengeId, 0, 0, 1);
	}

	// Token: 0x04003FBA RID: 16314
	public bool CurrentChallengeFinishState;
}
