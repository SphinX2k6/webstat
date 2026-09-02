using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LineCross
{
	// Token: 0x0200676D RID: 26477
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class LineCrossModel : ModelBase<LineCrossModel>
	{
		// Token: 0x06041FFE RID: 270334 RVA: 0x010EF0D4 File Offset: 0x010ED2D4
		public string GetProgressByActivityId(int activityId, string formatString)
		{
			LineCrossActivityData lineCrossActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LineCrossActivityData;
			if (lineCrossActivityData != null)
			{
				int finishChallengeNumber = lineCrossActivityData.GetFinishChallengeNumber();
				int challengeNumber = lineCrossActivityData.GetChallengeNumber();
				return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(formatString, null) ?? "", new string[]
				{
					finishChallengeNumber.ToString(),
					challengeNumber.ToString()
				});
			}
			return "";
		}

		// Token: 0x06041FFF RID: 270335 RVA: 0x010EF138 File Offset: 0x010ED338
		public bool GetGroupUnlockState(int activityId, int groupId)
		{
			LineCrossActivityData lineCrossActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LineCrossActivityData;
			return lineCrossActivityData != null && lineCrossActivityData.GetGroupState(groupId) != ELineCrossGroupState.Lock;
		}

		// Token: 0x06042000 RID: 270336 RVA: 0x010EF168 File Offset: 0x010ED368
		public string GetGroupRewardProgress(int activityId, int groupId)
		{
			LineCrossActivityData lineCrossActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LineCrossActivityData;
			if (lineCrossActivityData != null)
			{
				int groupRewardProgress = lineCrossActivityData.GetGroupRewardProgress(groupId);
				int groupChallengeNumber = lineCrossActivityData.GetGroupChallengeNumber(groupId);
				return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("LineCrossProgress", null) ?? "", new string[]
				{
					groupRewardProgress.ToString(),
					groupChallengeNumber.ToString()
				});
			}
			return "";
		}

		// Token: 0x06042001 RID: 270337 RVA: 0x010EF1D4 File Offset: 0x010ED3D4
		public string GetLockDescription(int activityId, int groupId)
		{
			long groupUnlockTime = this.GetGroupUnlockTime(activityId, groupId);
			CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat((double)groupUnlockTime - Singleton<TimeUtil>.Instance.GetServerTime());
			return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("LineCrossLock", null) ?? "", new string[]
			{
				((remainTimeDataFormat != null) ? remainTimeDataFormat.CountDownText : null) ?? ""
			});
		}

		// Token: 0x06042002 RID: 270338 RVA: 0x010EF23C File Offset: 0x010ED43C
		public long GetGroupUnlockTime(int activityId, int groupId)
		{
			LineCrossActivityData lineCrossActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LineCrossActivityData;
			if (lineCrossActivityData != null)
			{
				return lineCrossActivityData.GetGroupUnlockTime(groupId);
			}
			return 0L;
		}

		// Token: 0x06042003 RID: 270339 RVA: 0x010EF268 File Offset: 0x010ED468
		public int[] GetShowGroupList(int activityId)
		{
			LineCrossActivityData lineCrossActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LineCrossActivityData;
			if (lineCrossActivityData != null)
			{
				return lineCrossActivityData.GetShowGroupList();
			}
			return Array.Empty<int>();
		}

		// Token: 0x06042004 RID: 270340 RVA: 0x010EF298 File Offset: 0x010ED498
		public bool GetGroupRewardState(int activityId, int groupId)
		{
			LineCrossActivityData lineCrossActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LineCrossActivityData;
			return lineCrossActivityData != null && lineCrossActivityData.GetGroupHasGetReward(groupId);
		}

		// Token: 0x06042005 RID: 270341 RVA: 0x010EF2C4 File Offset: 0x010ED4C4
		public bool GetIfHiddenGroup(int activityId, int groupId)
		{
			LineCrossActivityData lineCrossActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LineCrossActivityData;
			return lineCrossActivityData != null && lineCrossActivityData.GetIfHiddenGroup(groupId);
		}

		// Token: 0x06042006 RID: 270342 RVA: 0x010EF2F0 File Offset: 0x010ED4F0
		public bool GetGroupIfShow(int activityId, int groupId)
		{
			LineCrossActivityData lineCrossActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LineCrossActivityData;
			return lineCrossActivityData != null && lineCrossActivityData.IfGroupShow(groupId);
		}

		// Token: 0x06042007 RID: 270343 RVA: 0x010EF31C File Offset: 0x010ED51C
		public bool GetChallengeRequireFinishState(int activityId, int challengeId)
		{
			LineCrossActivityData lineCrossActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LineCrossActivityData;
			return lineCrossActivityData != null && lineCrossActivityData.GetChallengeRequireFinishState(challengeId);
		}

		// Token: 0x06042008 RID: 270344 RVA: 0x010EF348 File Offset: 0x010ED548
		public ELineCrossGroupState GetGroupState(int activityId, int groupId)
		{
			LineCrossActivityData lineCrossActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LineCrossActivityData;
			if (lineCrossActivityData != null)
			{
				return lineCrossActivityData.GetGroupState(groupId);
			}
			return ELineCrossGroupState.Normal;
		}

		// Token: 0x06042009 RID: 270345 RVA: 0x010EF374 File Offset: 0x010ED574
		public bool GetGroupRedDotState(int groupId)
		{
			LineCrossGroup? lineCrossGroupByGroupId = ConfigBase<LineCrossConfig>.Instance.GetLineCrossGroupByGroupId(groupId);
			if (lineCrossGroupByGroupId == null)
			{
				return false;
			}
			for (int i = 0; i < lineCrossGroupByGroupId.Value.ChallengeListLength; i++)
			{
				int challengeId = lineCrossGroupByGroupId.Value.ChallengeList(i);
				if (this.GetChallengeRedDotState(challengeId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0604200A RID: 270346 RVA: 0x010EF3D0 File Offset: 0x010ED5D0
		public bool GetChallengeFinishState(int activityId, int challengeId)
		{
			LineCrossActivityData lineCrossActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LineCrossActivityData;
			return lineCrossActivityData != null && lineCrossActivityData.GetChallengeIfGetReward(challengeId);
		}

		// Token: 0x0604200B RID: 270347 RVA: 0x010EF3FC File Offset: 0x010ED5FC
		public void SaveChallengeRedDotState(int activityId, int challengeId)
		{
			List<ActivityBaseData> currentShowingActivities = ModelBase<ActivityModel>.Instance.GetCurrentShowingActivities();
			LineCrossActivityData lineCrossActivityData = null;
			foreach (ActivityBaseData activityBaseData in currentShowingActivities)
			{
				if (activityBaseData.Type == ActivityType.LineCross)
				{
					LineCrossActivityData lineCrossActivityData2 = activityBaseData as LineCrossActivityData;
					if (lineCrossActivityData2 != null && lineCrossActivityData2.CheckIfHaveChallenge(challengeId))
					{
						lineCrossActivityData = lineCrossActivityData2;
						break;
					}
				}
			}
			if (lineCrossActivityData == null)
			{
				return;
			}
			ModelBase<ActivityModel>.Instance.SaveActivityData(activityId, challengeId, 0, 0, 1);
		}

		// Token: 0x0604200C RID: 270348 RVA: 0x010EF484 File Offset: 0x010ED684
		public bool GetChallengeRedDotState(int challengeId)
		{
			List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.LineCross);
			LineCrossActivityData lineCrossActivityData = null;
			if (currentActivitiesByType.Count > 0)
			{
				lineCrossActivityData = (currentActivitiesByType[0] as LineCrossActivityData);
			}
			if (lineCrossActivityData == null)
			{
				return false;
			}
			int activityCacheData = ModelBase<ActivityModel>.Instance.GetActivityCacheData(lineCrossActivityData.Id, 0, challengeId, 0, 0);
			int groupId = ConfigBase<LineCrossConfig>.Instance.GetLineCrossChallengeById(challengeId).Value.GroupId;
			bool challengeRequireFinishState = this.GetChallengeRequireFinishState(lineCrossActivityData.Id, challengeId);
			bool ifHiddenGroup = this.GetIfHiddenGroup(lineCrossActivityData.Id, groupId);
			bool groupIfShow = this.GetGroupIfShow(lineCrossActivityData.Id, groupId);
			return (!ifHiddenGroup || groupIfShow) && (activityCacheData == 0 && lineCrossActivityData.GetGroupIfOverUnlockTime(groupId) && challengeRequireFinishState);
		}

		// Token: 0x04024CF8 RID: 150776
		public bool CurrentChallengeFinishState;
	}
}
