using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;

// Token: 0x020012AC RID: 4780
[NullableContext(1)]
[Nullable(0)]
public class ActivityCorniceMeetingData : ActivityBaseData
{
	// Token: 0x0600801F RID: 32799 RVA: 0x0021D60C File Offset: 0x0021B80C
	protected override void PhraseEx(ActivityData data)
	{
		this.UnlockTime = data.CorniceMeetingData.QuestUnlockTime;
		foreach (KeyValuePair<int, CorniceLevelPlayEnrty> keyValuePair in data.CorniceMeetingData.CorninceDataList)
		{
			int key = keyValuePair.Key;
			CorniceLevelPlayEnrty value = keyValuePair.Value;
			if (this.CurrentSelectLevelPlayId == 0)
			{
				this.CurrentSelectLevelPlayId = key;
			}
			if (this.LevelEntryMap.ContainsKey(key))
			{
				this.LevelEntryMap[key].UpdateData(value);
			}
			else
			{
				this.LevelEntryMap[key] = new ActivityCorniceMeetingLevelEntryData(value, key);
			}
		}
		this.RefreshAllLevelEntryDataRedDot();
	}

	// Token: 0x06008020 RID: 32800 RVA: 0x0021D6C4 File Offset: 0x0021B8C4
	public List<int> GetLevelPlayIdList(bool isSort = true)
	{
		List<int> list = new List<int>(this.LevelEntryMap.Keys);
		if (isSort)
		{
			list.Sort(delegate(int a, int b)
			{
				CorniceChallenge? corniceMeetingChallengeConfig = ConfigBase<ActivityCorniceMeetingConfig>.Instance.GetCorniceMeetingChallengeConfig(a);
				CorniceChallenge? corniceMeetingChallengeConfig2 = ConfigBase<ActivityCorniceMeetingConfig>.Instance.GetCorniceMeetingChallengeConfig(b);
				if (corniceMeetingChallengeConfig == null || corniceMeetingChallengeConfig2 == null)
				{
					return 0;
				}
				return corniceMeetingChallengeConfig.Value.SortId - corniceMeetingChallengeConfig2.Value.SortId;
			});
		}
		return list;
	}

	// Token: 0x06008021 RID: 32801 RVA: 0x0021D70C File Offset: 0x0021B90C
	public void UpdateRewarded(int levelPlayId, int score)
	{
		ActivityCorniceMeetingLevelEntryData activityCorniceMeetingLevelEntryData;
		if (this.LevelEntryMap.TryGetValue(levelPlayId, out activityCorniceMeetingLevelEntryData))
		{
			activityCorniceMeetingLevelEntryData.UpdateRewarded(score);
		}
	}

	// Token: 0x06008022 RID: 32802 RVA: 0x0021D730 File Offset: 0x0021B930
	[NullableContext(2)]
	public ActivityCorniceMeetingLevelEntryData GetLevelEntryData(int levelPlayId)
	{
		ActivityCorniceMeetingLevelEntryData result;
		this.LevelEntryMap.TryGetValue(levelPlayId, out result);
		return result;
	}

	// Token: 0x06008023 RID: 32803 RVA: 0x0021D750 File Offset: 0x0021B950
	public int GetDefaultSelectLevelPlayId()
	{
		List<int> levelPlayIdList = this.GetLevelPlayIdList(true);
		this.CurrentSelectLevelPlayId = ((levelPlayIdList.Count > 0) ? levelPlayIdList[0] : 0);
		foreach (int num in levelPlayIdList)
		{
			ActivityCorniceMeetingLevelEntryData levelEntryData = this.GetLevelEntryData(num);
			if (levelEntryData != null && levelEntryData.IsUnlock() && !levelEntryData.IsRewardAllFinished())
			{
				this.CurrentSelectLevelPlayId = num;
				break;
			}
		}
		return this.CurrentSelectLevelPlayId;
	}

	// Token: 0x06008024 RID: 32804 RVA: 0x0021D7E4 File Offset: 0x0021B9E4
	public int GetSelectLevelPlayIdIndex()
	{
		return this.GetLevelPlayIdList(true).IndexOf(this.CurrentSelectLevelPlayId);
	}

	// Token: 0x06008025 RID: 32805 RVA: 0x0021D7F8 File Offset: 0x0021B9F8
	public List<TItem> GetScoreIndexPreviewItem(int levelPlayId, int score)
	{
		CorniceChallenge? corniceMeetingChallengeConfig = ConfigBase<ActivityCorniceMeetingConfig>.Instance.GetCorniceMeetingChallengeConfig(levelPlayId);
		if (corniceMeetingChallengeConfig == null)
		{
			return new List<TItem>();
		}
		IntPair? intPair = null;
		for (int i = 0; i < corniceMeetingChallengeConfig.Value.RewardListLength; i++)
		{
			IntPair value = corniceMeetingChallengeConfig.Value.RewardList(i).Value;
			if (value.Item1 == score)
			{
				intPair = new IntPair?(value);
				break;
			}
		}
		if (intPair == null)
		{
			return new List<TItem>();
		}
		int item = intPair.Value.Item2;
		List<TItem> list = new List<TItem>();
		if (item != 0)
		{
			DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(item);
			if (dropPackage != null)
			{
				for (int j = 0; j < dropPackage.Value.DropPreviewLength; j++)
				{
					DicIntInt value2 = dropPackage.Value.DropPreview(j).Value;
					TItem item2 = new TItem
					{
						ItemData = new InventoryDefine.GetItemData(value2.Key, 0),
						Count = value2.Value
					};
					list.Add(item2);
				}
			}
		}
		return list;
	}

	// Token: 0x06008026 RID: 32806 RVA: 0x0021D930 File Offset: 0x0021BB30
	public ECorniceMeetingRewardState GetRewardState(int levelPlayId, int index)
	{
		ActivityCorniceMeetingLevelEntryData levelEntryData = this.GetLevelEntryData(levelPlayId);
		if (levelEntryData == null)
		{
			return ECorniceMeetingRewardState.Unfinished;
		}
		if (levelEntryData.IsRewarded(index))
		{
			return ECorniceMeetingRewardState.Rewarded;
		}
		IntPair rewardPair = levelEntryData.GetRewardPair(index);
		if (levelEntryData.MaxScore < rewardPair.Item1)
		{
			return ECorniceMeetingRewardState.Unfinished;
		}
		return ECorniceMeetingRewardState.Finished;
	}

	// Token: 0x06008027 RID: 32807 RVA: 0x0021D970 File Offset: 0x0021BB70
	public bool IsUnlockTailQuest()
	{
		if (base.Id != 102400001)
		{
			return false;
		}
		bool flag = true;
		foreach (int levelPlayId in this.GetLevelPlayIdList(true))
		{
			ActivityCorniceMeetingLevelEntryData levelEntryData = this.GetLevelEntryData(levelPlayId);
			if (levelEntryData != null && levelEntryData.MaxScore == 0)
			{
				flag = false;
				break;
			}
		}
		if (this.UnlockTime == 0L)
		{
			return flag;
		}
		return Singleton<TimeUtil>.Instance.GetServerTimeStamp() >= (double)this.UnlockTime && flag;
	}

	// Token: 0x06008028 RID: 32808 RVA: 0x0021DA08 File Offset: 0x0021BC08
	public bool GetIsShow(int levelPlayId)
	{
		ActivityCorniceMeetingLevelEntryData levelEntryData = this.GetLevelEntryData(levelPlayId);
		return levelEntryData != null && levelEntryData.IsUnlock() && this.CheckIfInShowTime() && base.GetPreGuideQuestFinishState();
	}

	// Token: 0x06008029 RID: 32809 RVA: 0x0021DA3C File Offset: 0x0021BC3C
	public override bool CheckIfInShowTime()
	{
		if (base.BeginOpenTime == 0L && base.EndOpenTime == 0L)
		{
			return true;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		return serverTime >= (double)base.BeginOpenTime && serverTime <= (double)base.EndOpenTime;
	}

	// Token: 0x0600802A RID: 32810 RVA: 0x0021DA80 File Offset: 0x0021BC80
	public override bool GetExDataRedPointShowState()
	{
		if (base.GetPreGuideQuestFinishState())
		{
			using (List<int>.Enumerator enumerator = this.GetLevelPlayIdList(true).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int levelPlayId = enumerator.Current;
					ActivityCorniceMeetingLevelEntryData levelEntryData = this.GetLevelEntryData(levelPlayId);
					if (levelEntryData != null && levelEntryData.GetRedDot())
					{
						return true;
					}
				}
				return false;
			}
		}
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, base.GetUnFinishPreGuideQuestId(), 0, 0) == 0;
	}

	// Token: 0x0600802B RID: 32811 RVA: 0x0021DB10 File Offset: 0x0021BD10
	public void SavePreQuestRedDot(int preQuestId)
	{
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, preQuestId, 0, 0, 1);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x0600802C RID: 32812 RVA: 0x0021DB3C File Offset: 0x0021BD3C
	public void RefreshAllLevelEntryDataRedDot()
	{
		foreach (int p in this.GetLevelPlayIdList(true))
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCorniceMeetingRedDot, p);
		}
	}

	// Token: 0x17000AE0 RID: 2784
	// (get) Token: 0x0600802D RID: 32813 RVA: 0x0021DB9C File Offset: 0x0021BD9C
	public bool NeedTailQuest
	{
		get
		{
			return base.Id == 102400001;
		}
	}

	// Token: 0x17000AE1 RID: 2785
	// (get) Token: 0x0600802E RID: 32814 RVA: 0x0021DBAB File Offset: 0x0021BDAB
	public string TaskTitleTextId
	{
		get
		{
			if (base.Id != 102400001)
			{
				return "ActivityCorniceMeetingPointNeed_02";
			}
			return "ActivityCorniceMeetingPointNeed";
		}
	}

	// Token: 0x0600802F RID: 32815 RVA: 0x0021DBC8 File Offset: 0x0021BDC8
	protected override bool GetExDataFinishShowState()
	{
		foreach (int levelPlayId in this.GetLevelPlayIdList(true))
		{
			ActivityCorniceMeetingLevelEntryData levelEntryData = this.GetLevelEntryData(levelPlayId);
			if (levelEntryData == null)
			{
				return false;
			}
			List<int> rewardList = levelEntryData.GetRewardList();
			for (int i = 0; i < rewardList.Count; i++)
			{
				if (this.GetRewardState(levelPlayId, i) != ECorniceMeetingRewardState.Rewarded)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x04003D32 RID: 15666
	private const int FIRST_VERSION_ACTIVITY_ID = 102400001;

	// Token: 0x04003D33 RID: 15667
	public Dictionary<int, ActivityCorniceMeetingLevelEntryData> LevelEntryMap = new Dictionary<int, ActivityCorniceMeetingLevelEntryData>();

	// Token: 0x04003D34 RID: 15668
	public int CurrentSelectLevelPlayId;

	// Token: 0x04003D35 RID: 15669
	public long UnlockTime;
}
