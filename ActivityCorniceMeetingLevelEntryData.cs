using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020012AB RID: 4779
[NullableContext(1)]
[Nullable(0)]
public class ActivityCorniceMeetingLevelEntryData
{
	// Token: 0x0600800E RID: 32782 RVA: 0x0021D1DC File Offset: 0x0021B3DC
	public ActivityCorniceMeetingLevelEntryData(CorniceLevelPlayEnrty data, int playId)
	{
		this.LevelPlayId = playId;
		this.MaxScore = data.MaxScore;
		this.RemainTime = data.RemainingTime;
		this.UnlockTime = data.UnlockTime;
		foreach (int key in data.GetRewardScoreIndexList)
		{
			this.RewardedMap[key] = true;
		}
	}

	// Token: 0x0600800F RID: 32783 RVA: 0x0021D26C File Offset: 0x0021B46C
	public bool IsUnlock()
	{
		if (this.UnlockTime != 0L)
		{
			return Singleton<TimeUtil>.Instance.GetServerTimeStamp() >= (double)this.UnlockTime;
		}
		return this.UnlockTime == 0L;
	}

	// Token: 0x06008010 RID: 32784 RVA: 0x0021D297 File Offset: 0x0021B497
	public bool IsRewarded(int score)
	{
		return this.RewardedMap.ContainsKey(score);
	}

	// Token: 0x06008011 RID: 32785 RVA: 0x0021D2A5 File Offset: 0x0021B4A5
	public bool IsAllFinished()
	{
		return this.MaxScore >= this.GetMaxScoreConfig();
	}

	// Token: 0x06008012 RID: 32786 RVA: 0x0021D2B8 File Offset: 0x0021B4B8
	public void UpdateData(CorniceLevelPlayEnrty data)
	{
		this.MaxScore = data.MaxScore;
		this.UnlockTime = data.UnlockTime;
		foreach (int key in data.GetRewardScoreIndexList)
		{
			this.RewardedMap[key] = true;
		}
	}

	// Token: 0x06008013 RID: 32787 RVA: 0x0021D324 File Offset: 0x0021B524
	public void UpdateRewarded(int score)
	{
		this.RewardedMap[score] = true;
	}

	// Token: 0x06008014 RID: 32788 RVA: 0x0021D334 File Offset: 0x0021B534
	public string GetBackgroundPath()
	{
		return ConfigBase<ActivityCorniceMeetingConfig>.Instance.GetCorniceMeetingChallengeConfig(this.LevelPlayId).Value.BackgroundTexture;
	}

	// Token: 0x06008015 RID: 32789 RVA: 0x0021D364 File Offset: 0x0021B564
	public string GetTitle()
	{
		return ConfigBase<ActivityCorniceMeetingConfig>.Instance.GetCorniceMeetingChallengeConfig(this.LevelPlayId).Value.Title;
	}

	// Token: 0x06008016 RID: 32790 RVA: 0x0021D394 File Offset: 0x0021B594
	public int GetMarkId()
	{
		return ConfigBase<ActivityCorniceMeetingConfig>.Instance.GetCorniceMeetingChallengeConfig(this.LevelPlayId).Value.MarkId;
	}

	// Token: 0x06008017 RID: 32791 RVA: 0x0021D3C4 File Offset: 0x0021B5C4
	public int GetMaxScoreConfig()
	{
		return ConfigBase<ActivityCorniceMeetingConfig>.Instance.GetCorniceMeetingChallengeConfig(this.LevelPlayId).Value.MaxScore;
	}

	// Token: 0x06008018 RID: 32792 RVA: 0x0021D3F4 File Offset: 0x0021B5F4
	public bool IsRewardAllFinished()
	{
		CorniceChallenge? corniceMeetingChallengeConfig = ConfigBase<ActivityCorniceMeetingConfig>.Instance.GetCorniceMeetingChallengeConfig(this.LevelPlayId);
		return corniceMeetingChallengeConfig != null && corniceMeetingChallengeConfig.Value.RewardListLength == this.RewardedMap.Count;
	}

	// Token: 0x06008019 RID: 32793 RVA: 0x0021D43C File Offset: 0x0021B63C
	public List<int> GetRewardList()
	{
		CorniceChallenge? corniceMeetingChallengeConfig = ConfigBase<ActivityCorniceMeetingConfig>.Instance.GetCorniceMeetingChallengeConfig(this.LevelPlayId);
		List<int> list = new List<int>();
		if (corniceMeetingChallengeConfig != null)
		{
			for (int i = 0; i < corniceMeetingChallengeConfig.Value.RewardListLength; i++)
			{
				list.Add(corniceMeetingChallengeConfig.Value.RewardList(i).Value.Item1);
			}
		}
		return list;
	}

	// Token: 0x0600801A RID: 32794 RVA: 0x0021D4AC File Offset: 0x0021B6AC
	public IntPair GetRewardPair(int index)
	{
		CorniceChallenge? corniceMeetingChallengeConfig = ConfigBase<ActivityCorniceMeetingConfig>.Instance.GetCorniceMeetingChallengeConfig(this.LevelPlayId);
		if (corniceMeetingChallengeConfig == null || index < 0 || index >= corniceMeetingChallengeConfig.Value.RewardListLength)
		{
			return default(IntPair);
		}
		return corniceMeetingChallengeConfig.Value.RewardList(index).Value;
	}

	// Token: 0x0600801B RID: 32795 RVA: 0x0021D50B File Offset: 0x0021B70B
	public bool GetRedDot()
	{
		return this.IsUnlock() && (this.GetChallengeNewLocalRedDot() || this.GetScoreRedDot());
	}

	// Token: 0x0600801C RID: 32796 RVA: 0x0021D52C File Offset: 0x0021B72C
	public bool GetScoreRedDot()
	{
		CorniceChallenge? corniceMeetingChallengeConfig = ConfigBase<ActivityCorniceMeetingConfig>.Instance.GetCorniceMeetingChallengeConfig(this.LevelPlayId);
		bool result = false;
		if (corniceMeetingChallengeConfig != null)
		{
			for (int i = 0; i < corniceMeetingChallengeConfig.Value.RewardListLength; i++)
			{
				if (this.MaxScore >= corniceMeetingChallengeConfig.Value.RewardList(i).Value.Item1 && !this.RewardedMap.ContainsKey(i))
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x0600801D RID: 32797 RVA: 0x0021D5AC File Offset: 0x0021B7AC
	public void SetChallengeLocalRedDot(bool state)
	{
		ModelBase<ActivityModel>.Instance.SaveActivityData(ControllerBase<ActivityCorniceMeetingController>.Instance.ActivityId, this.LevelPlayId, 0, 0, (state > false) ? 1 : 0);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, ControllerBase<ActivityCorniceMeetingController>.Instance.ActivityId);
	}

	// Token: 0x0600801E RID: 32798 RVA: 0x0021D5E8 File Offset: 0x0021B7E8
	public bool GetChallengeNewLocalRedDot()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(ControllerBase<ActivityCorniceMeetingController>.Instance.ActivityId, 1, this.LevelPlayId, 0, 0) == 1;
	}

	// Token: 0x04003D2C RID: 15660
	public int LevelPlayId;

	// Token: 0x04003D2D RID: 15661
	public int MaxScore;

	// Token: 0x04003D2E RID: 15662
	public int RemainTime;

	// Token: 0x04003D2F RID: 15663
	public long UnlockTime;

	// Token: 0x04003D30 RID: 15664
	public int CurrentScore;

	// Token: 0x04003D31 RID: 15665
	public Dictionary<int, bool> RewardedMap = new Dictionary<int, bool>();
}
