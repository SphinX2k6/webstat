using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;

// Token: 0x020011E1 RID: 4577
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerData : ActivityBaseData
{
	// Token: 0x06007901 RID: 30977 RVA: 0x001FBAD4 File Offset: 0x001F9CD4
	protected override void PhraseEx(ActivityData data)
	{
		this.HardLevelDataMap.Clear();
		this.NormalLevelDataMap.Clear();
		this.RoleLockData.Clear();
		this.UpdateLevelInfosAndNotify(data.BabelActivityInfo.BabelActivityLevelInfos);
		this.NormalQuest.Clear();
		foreach (ActivityTask activityTask in data.BabelActivityInfo.ActivityTasks)
		{
			this.NormalQuest[activityTask.Id] = activityTask;
		}
		this.DailyQuest.Clear();
		foreach (ActivityTask activityTask2 in data.BabelActivityInfo.DailyActivityTask)
		{
			this.DailyQuest[activityTask2.Id] = activityTask2;
		}
		this.BuffUnlock.Clear();
		foreach (BabelActivityBuffInfo babelActivityBuffInfo in data.BabelActivityInfo.BabelActivityBuffInfos)
		{
			this.BuffUnlock[babelActivityBuffInfo.BabelBuffId] = babelActivityBuffInfo.DifficultUnlock;
		}
		this.DeTermUnlock.Clear();
		foreach (BabelActivityDeTermInfo babelActivityDeTermInfo in data.BabelActivityInfo.BabelActivityDeTermInfos)
		{
			this.DeTermUnlock[babelActivityDeTermInfo.DeTermId] = babelActivityDeTermInfo.DifficultUnlock;
		}
		this.CurrentItemCount = data.BabelActivityInfo.ActivityItemNum;
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BabelTowerQuestView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.BabelTowerQuestView, null);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06007902 RID: 30978 RVA: 0x001FBCD0 File Offset: 0x001F9ED0
	public void UpdateLevelInfosAndNotify(IEnumerable<BabelActivityLevelInfo> levelInfos)
	{
		HashSet<EBabelTowerDifficulty> hashSet = new HashSet<EBabelTowerDifficulty>();
		foreach (BabelActivityLevelInfo babelActivityLevelInfo in levelInfos)
		{
			if (ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(babelActivityLevelInfo.LevelsId).IsDifficult)
			{
				this.HardLevelDataMap[babelActivityLevelInfo.LevelsId] = babelActivityLevelInfo;
				hashSet.Add(EBabelTowerDifficulty.Hard);
			}
			else
			{
				this.NormalLevelDataMap[babelActivityLevelInfo.LevelsId] = babelActivityLevelInfo;
				hashSet.Add(EBabelTowerDifficulty.Normal);
			}
			this.RoleLockData[babelActivityLevelInfo.LevelsId] = new List<int>(babelActivityLevelInfo.LimitWeaponTypes);
		}
		this.UpdateAllLevelRoleIds();
		foreach (BabelActivityLevelInfo babelActivityLevelInfo2 in levelInfos)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.BabelTowerLevelRedDotUpdate, babelActivityLevelInfo2.LevelsId);
		}
		foreach (EBabelTowerDifficulty p in hashSet)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.BabelTowerDifficultyRedDotUpdate, (int)p);
		}
	}

	// Token: 0x06007903 RID: 30979 RVA: 0x001FBE1C File Offset: 0x001FA01C
	public void UpdateAllLevelRoleIds()
	{
		foreach (KeyValuePair<int, BabelActivityLevelInfo> keyValuePair in this.NormalLevelDataMap)
		{
			this.<UpdateAllLevelRoleIds>g__FixList|12_0(keyValuePair.Value.RoleSelection);
			this.<UpdateAllLevelRoleIds>g__FixList|12_0(keyValuePair.Value.MaxPassRoleSelection);
		}
		foreach (KeyValuePair<int, BabelActivityLevelInfo> keyValuePair2 in this.HardLevelDataMap)
		{
			this.<UpdateAllLevelRoleIds>g__FixList|12_0(keyValuePair2.Value.RoleSelection);
			this.<UpdateAllLevelRoleIds>g__FixList|12_0(keyValuePair2.Value.MaxPassRoleSelection);
		}
	}

	// Token: 0x06007904 RID: 30980 RVA: 0x001FBEEC File Offset: 0x001FA0EC
	public int CheckMainCharacterCorrect(int roleId)
	{
		if (roleId <= 0)
		{
			return roleId;
		}
		RoleModel instance = ModelBase<RoleModel>.Instance;
		if (roleId < 100000)
		{
			if (!instance.IsMainRole(roleId))
			{
				return roleId;
			}
			return instance.GetCurSelectMainRoleId().GetValueOrDefault(roleId);
		}
		else
		{
			TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(roleId);
			int num = (trialRoleConfig != null) ? trialRoleConfig.GetValueOrDefault().ParentId : 0;
			if (num <= 0 || !instance.IsMainRole(num))
			{
				return roleId;
			}
			TrialRoleInfo? trialRoleConfigByGroupId = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfigByGroupId(trialRoleConfig.Value.GroupId);
			if (trialRoleConfigByGroupId == null)
			{
				return 0;
			}
			return trialRoleConfigByGroupId.GetValueOrDefault().Id;
		}
	}

	// Token: 0x06007905 RID: 30981 RVA: 0x001FBF98 File Offset: 0x001FA198
	[NullableContext(2)]
	public string GetNextLevelOpenTimeText()
	{
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		foreach (KeyValuePair<int, BabelActivityLevelInfo> keyValuePair in this.NormalLevelDataMap)
		{
			long num = Singleton<MathUtils>.Instance.LongToNumber(keyValuePair.Value.UnlockTime);
			if (serverTimeStamp < (double)num)
			{
				return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat((double)((long)(((double)num - serverTimeStamp) * Singleton<TimeUtil>.Instance.Millisecond))).CountDownText;
			}
		}
		foreach (KeyValuePair<int, BabelActivityLevelInfo> keyValuePair2 in this.HardLevelDataMap)
		{
			long num2 = Singleton<MathUtils>.Instance.LongToNumber(keyValuePair2.Value.UnlockTime);
			if (serverTimeStamp < (double)num2)
			{
				return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat((double)((long)(((double)num2 - serverTimeStamp) * Singleton<TimeUtil>.Instance.Millisecond))).CountDownText;
			}
		}
		return null;
	}

	// Token: 0x06007906 RID: 30982 RVA: 0x001FC0B8 File Offset: 0x001FA2B8
	public string GetNormalLevelPassText()
	{
		int num = 0;
		foreach (KeyValuePair<int, BabelActivityLevelInfo> keyValuePair in this.NormalLevelDataMap)
		{
			if (keyValuePair.Value.IsFinished)
			{
				num++;
			}
		}
		return num.ToString() + "/" + this.NormalLevelDataMap.Count.ToString();
	}

	// Token: 0x06007907 RID: 30983 RVA: 0x001FC13C File Offset: 0x001FA33C
	public string GetHardLevelStarText()
	{
		int num = 0;
		foreach (KeyValuePair<int, BabelActivityLevelInfo> keyValuePair in this.HardLevelDataMap)
		{
			num += keyValuePair.Value.PassStar;
		}
		return num.ToString() ?? "";
	}

	// Token: 0x06007908 RID: 30984 RVA: 0x001FC1AC File Offset: 0x001FA3AC
	public bool GetBuffIsLock(int buffId)
	{
		bool flag;
		return !this.BuffUnlock.TryGetValue(buffId, out flag) || !flag;
	}

	// Token: 0x06007909 RID: 30985 RVA: 0x001FC1D0 File Offset: 0x001FA3D0
	public int GetBuffIsUse(int buffId)
	{
		foreach (KeyValuePair<int, BabelActivityLevelInfo> keyValuePair in this.HardLevelDataMap)
		{
			if (keyValuePair.Value.MaxPassBuffSelection != null && keyValuePair.Value.MaxPassBuffSelection.Contains(buffId))
			{
				return keyValuePair.Key;
			}
		}
		return -1;
	}

	// Token: 0x0600790A RID: 30986 RVA: 0x001FC24C File Offset: 0x001FA44C
	public bool GetDeTermIsLock(int deTerm)
	{
		bool flag;
		return !this.DeTermUnlock.TryGetValue(deTerm, out flag) || !flag;
	}

	// Token: 0x0600790B RID: 30987 RVA: 0x001FC270 File Offset: 0x001FA470
	public bool GetDeTermIsUse(int levelId, int deTerm)
	{
		BabelActivityLevelInfo babelActivityLevelInfo = null;
		BabelActivityLevelInfo babelActivityLevelInfo2;
		BabelActivityLevelInfo babelActivityLevelInfo3;
		if (this.NormalLevelDataMap.TryGetValue(levelId, out babelActivityLevelInfo2))
		{
			babelActivityLevelInfo = babelActivityLevelInfo2;
		}
		else if (this.HardLevelDataMap.TryGetValue(levelId, out babelActivityLevelInfo3))
		{
			babelActivityLevelInfo = babelActivityLevelInfo3;
		}
		return babelActivityLevelInfo != null && babelActivityLevelInfo.BabelDeTermId.Contains(deTerm);
	}

	// Token: 0x0600790C RID: 30988 RVA: 0x001FC2B8 File Offset: 0x001FA4B8
	[NullableContext(2)]
	public BabelActivityLevelInfo GetLevelInfo(int levelId)
	{
		BabelActivityLevelInfo result;
		if (this.NormalLevelDataMap.TryGetValue(levelId, out result))
		{
			return result;
		}
		BabelActivityLevelInfo result2;
		if (this.HardLevelDataMap.TryGetValue(levelId, out result2))
		{
			return result2;
		}
		return null;
	}

	// Token: 0x0600790D RID: 30989 RVA: 0x001FC2EC File Offset: 0x001FA4EC
	public bool GetQuestAnyRedDot()
	{
		foreach (KeyValuePair<int, ActivityTask> keyValuePair in this.DailyQuest)
		{
			if (keyValuePair.Value.Status == ActivityTaskState.ActivityTaskFinish)
			{
				return true;
			}
		}
		foreach (KeyValuePair<int, ActivityTask> keyValuePair2 in this.NormalQuest)
		{
			if (keyValuePair2.Value.Status == ActivityTaskState.ActivityTaskFinish)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600790E RID: 30990 RVA: 0x001FC39C File Offset: 0x001FA59C
	public bool GetDifficultyNewLevelRedDot(int difficulty)
	{
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		foreach (KeyValuePair<int, BabelActivityLevelInfo> keyValuePair in ((difficulty == 0) ? this.NormalLevelDataMap : this.HardLevelDataMap))
		{
			if ((double)Singleton<MathUtils>.Instance.LongToNumber(keyValuePair.Value.UnlockTime) <= serverTimeStamp)
			{
				Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.BabelTowerNewLevelHasClick, null);
				bool flag;
				if (player == null || !player.TryGetValue(keyValuePair.Key, out flag) || !flag)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600790F RID: 30991 RVA: 0x001FC444 File Offset: 0x001FA644
	public bool GetNewLevelRedDot(int levelId)
	{
		BabelActivityLevelInfo babelActivityLevelInfo;
		if (!(ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(levelId).IsDifficult ? this.HardLevelDataMap : this.NormalLevelDataMap).TryGetValue(levelId, out babelActivityLevelInfo))
		{
			return false;
		}
		if (Singleton<TimeUtil>.Instance.GetServerTimeStamp() < (double)Singleton<MathUtils>.Instance.LongToNumber(babelActivityLevelInfo.UnlockTime))
		{
			return false;
		}
		Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.BabelTowerNewLevelHasClick, null);
		bool flag;
		return player == null || !player.TryGetValue(levelId, out flag) || !flag;
	}

	// Token: 0x06007910 RID: 30992 RVA: 0x001FC4BC File Offset: 0x001FA6BC
	public int GetNewLevel()
	{
		long num = 0L;
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		int result = 0;
		foreach (KeyValuePair<int, BabelActivityLevelInfo> keyValuePair in this.NormalLevelDataMap)
		{
			long num2 = Singleton<MathUtils>.Instance.LongToNumber(keyValuePair.Value.UnlockTime);
			if ((double)num2 <= serverTimeStamp && num < num2)
			{
				result = keyValuePair.Key;
				num = num2;
			}
		}
		foreach (KeyValuePair<int, BabelActivityLevelInfo> keyValuePair2 in this.HardLevelDataMap)
		{
			long num3 = Singleton<MathUtils>.Instance.LongToNumber(keyValuePair2.Value.UnlockTime);
			if ((double)num3 <= serverTimeStamp && num < num3)
			{
				result = keyValuePair2.Key;
				num = num3;
			}
		}
		return result;
	}

	// Token: 0x06007911 RID: 30993 RVA: 0x001FC5B4 File Offset: 0x001FA7B4
	public bool GetQuestTabRedDot(int tabIndex)
	{
		foreach (KeyValuePair<int, ActivityTask> keyValuePair in this.NormalQuest)
		{
			BabelTowerTask babelTowerNormalQuest = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerNormalQuest(keyValuePair.Key);
			BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(babelTowerNormalQuest.LevelId);
			if (babelTowerLevelConfig.IsDifficult && tabIndex == 1)
			{
				if (keyValuePair.Value.Status == ActivityTaskState.ActivityTaskFinish)
				{
					return true;
				}
			}
			else if (!babelTowerLevelConfig.IsDifficult && tabIndex == 0 && keyValuePair.Value.Status == ActivityTaskState.ActivityTaskFinish)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06007912 RID: 30994 RVA: 0x001FC66C File Offset: 0x001FA86C
	public List<int> GetDailyDeTerm()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, ActivityTask> keyValuePair in this.DailyQuest)
		{
			if (keyValuePair.Value.Status == ActivityTaskState.ActivityTaskRunning)
			{
				int[] showDeTermArray = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDailyQuest(keyValuePair.Key).GetShowDeTermArray();
				if (showDeTermArray != null)
				{
					list.AddRange(showDeTermArray);
				}
			}
		}
		return list;
	}

	// Token: 0x06007913 RID: 30995 RVA: 0x001FC6F4 File Offset: 0x001FA8F4
	public List<int> GetDailyLevel()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, ActivityTask> keyValuePair in this.DailyQuest)
		{
			if (keyValuePair.Value.Status == ActivityTaskState.ActivityTaskRunning)
			{
				list.Add(ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDailyQuest(keyValuePair.Key).JumpToLevelId);
			}
		}
		return list;
	}

	// Token: 0x06007914 RID: 30996 RVA: 0x001FC774 File Offset: 0x001FA974
	public override bool GetExDataRedPointShowState()
	{
		return this.GetQuestAnyRedDot() || this.GetDifficultyNewLevelRedDot(0) || this.GetDifficultyNewLevelRedDot(1);
	}

	// Token: 0x06007915 RID: 30997 RVA: 0x001FC790 File Offset: 0x001FA990
	protected override bool GetExDataFinishShowState()
	{
		if (this.NormalQuest.Count <= 0 && this.DailyQuest.Count <= 0)
		{
			return false;
		}
		using (Dictionary<int, ActivityTask>.ValueCollection.Enumerator enumerator = this.NormalQuest.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status != ActivityTaskState.ActivityTaskTaken)
				{
					return false;
				}
			}
		}
		using (Dictionary<int, ActivityTask>.ValueCollection.Enumerator enumerator = this.DailyQuest.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status != ActivityTaskState.ActivityTaskTaken)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06007916 RID: 30998 RVA: 0x001FC858 File Offset: 0x001FAA58
	[NullableContext(0)]
	[return: TupleElementNames(new string[]
	{
		"Finished",
		"Total"
	})]
	public ValueTuple<int, int> GetNormalQuestCount()
	{
		int num = 0;
		foreach (KeyValuePair<int, ActivityTask> keyValuePair in this.NormalQuest)
		{
			if (keyValuePair.Value.Status == ActivityTaskState.ActivityTaskTaken)
			{
				num++;
			}
		}
		return new ValueTuple<int, int>(num, this.NormalQuest.Count);
	}

	// Token: 0x06007917 RID: 30999 RVA: 0x001FC8CC File Offset: 0x001FAACC
	public List<int> GetFinishedTaskIds()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, ActivityTask> keyValuePair in this.NormalQuest)
		{
			if (keyValuePair.Value.Status == ActivityTaskState.ActivityTaskFinish)
			{
				list.Add(keyValuePair.Key);
			}
		}
		return list;
	}

	// Token: 0x06007918 RID: 31000 RVA: 0x001FC93C File Offset: 0x001FAB3C
	public void SetRawFriendData(List<PublicBabelTowerInfo> data)
	{
		this.RawFriendData = data;
	}

	// Token: 0x06007919 RID: 31001 RVA: 0x001FC945 File Offset: 0x001FAB45
	public List<PublicBabelTowerInfo> GetRawFriendData()
	{
		return this.RawFriendData;
	}

	// Token: 0x0600791A RID: 31002 RVA: 0x001FC94D File Offset: 0x001FAB4D
	[NullableContext(2)]
	public void SetRawSelfData(PublicBabelTowerInfo data)
	{
		this.RawSelfData = data;
	}

	// Token: 0x0600791B RID: 31003 RVA: 0x001FC956 File Offset: 0x001FAB56
	[NullableContext(2)]
	public PublicBabelTowerInfo GetRawSelfData()
	{
		return this.RawSelfData;
	}

	// Token: 0x0600791C RID: 31004 RVA: 0x001FC95E File Offset: 0x001FAB5E
	public bool GetSelfShowName()
	{
		PublicBabelTowerInfo rawSelfData = this.RawSelfData;
		return rawSelfData == null || rawSelfData.ShowName;
	}

	// Token: 0x0600791D RID: 31005 RVA: 0x001FC971 File Offset: 0x001FAB71
	public void SetSelfShowName(bool showName)
	{
		if (this.RawSelfData != null)
		{
			this.RawSelfData.ShowName = showName;
		}
	}

	// Token: 0x0600791E RID: 31006 RVA: 0x001FC988 File Offset: 0x001FAB88
	public List<int> GetAllRankLevelIds()
	{
		List<int> list = new List<int>
		{
			-1
		};
		foreach (BabelTowerLevel babelTowerLevel in ConfigBase<BabelTowerConfig>.Instance.GetAllBabelTowerDifficultLevel(base.Id))
		{
			list.Add(babelTowerLevel.Id);
		}
		list.Sort((int a, int b) => a - b);
		return list;
	}

	// Token: 0x0600791F RID: 31007 RVA: 0x001FCA18 File Offset: 0x001FAC18
	public int GetLevelPassTime(int levelId)
	{
		PublicBabelTowerInfo rawSelfData = this.RawSelfData;
		if (((rawSelfData != null) ? rawSelfData.ChallengeInfo : null) == null)
		{
			return 0;
		}
		PublicBabelTowerChallengeInfo publicBabelTowerChallengeInfo = rawSelfData.ChallengeInfo.FirstOrDefault((PublicBabelTowerChallengeInfo c) => c.ChallengeId == levelId);
		if (publicBabelTowerChallengeInfo == null)
		{
			return 0;
		}
		return publicBabelTowerChallengeInfo.UseTime;
	}

	// Token: 0x06007920 RID: 31008 RVA: 0x001FCA6B File Offset: 0x001FAC6B
	public void ClearMyRankData()
	{
		this.RawSelfData = null;
	}

	// Token: 0x06007921 RID: 31009 RVA: 0x001FCA74 File Offset: 0x001FAC74
	public void SaveOldRankData(int levelId, int levelRank, int totalRank)
	{
		this.OldLevelRankMap[levelId] = levelRank;
		this.OldTotalRank = totalRank;
	}

	// Token: 0x06007922 RID: 31010 RVA: 0x001FCA8C File Offset: 0x001FAC8C
	public void CacheAllOldRanks()
	{
		foreach (int num in this.HardLevelDataMap.Keys)
		{
			this.OldLevelRankMap[num] = this.CalcMyRankFromRawData(true, num);
		}
		this.OldTotalRank = this.CalcMyRankFromRawData(false, -1);
	}

	// Token: 0x06007923 RID: 31011 RVA: 0x001FCB00 File Offset: 0x001FAD00
	public int GetOldLevelRank(int levelId)
	{
		int result;
		if (!this.OldLevelRankMap.TryGetValue(levelId, out result))
		{
			return -1;
		}
		return result;
	}

	// Token: 0x06007924 RID: 31012 RVA: 0x001FCB20 File Offset: 0x001FAD20
	public int GetOldTotalRank()
	{
		return this.OldTotalRank;
	}

	// Token: 0x06007925 RID: 31013 RVA: 0x001FCB28 File Offset: 0x001FAD28
	public int CalcMyRankFromRawData(bool isLevelRank, int levelId)
	{
		BabelTowerData.<>c__DisplayClass48_0 CS$<>8__locals1 = new BabelTowerData.<>c__DisplayClass48_0();
		CS$<>8__locals1.isLevelRank = isLevelRank;
		CS$<>8__locals1.levelId = levelId;
		if (this.RawSelfData == null)
		{
			return -1;
		}
		ValueTuple<int, int> valueTuple = CS$<>8__locals1.<CalcMyRankFromRawData>g__GetScore|0(this.RawSelfData);
		if (valueTuple.Item2 <= 0)
		{
			return -1;
		}
		int playerId = this.RawSelfData.PlayerId;
		int num = 0;
		foreach (PublicBabelTowerInfo publicBabelTowerInfo in this.RawFriendData)
		{
			ValueTuple<int, int> valueTuple2 = CS$<>8__locals1.<CalcMyRankFromRawData>g__GetScore|0(publicBabelTowerInfo);
			if (valueTuple2.Item2 > 0)
			{
				bool flag;
				if (valueTuple2.Item1 != valueTuple.Item1)
				{
					flag = (valueTuple2.Item1 > valueTuple.Item1);
				}
				else if (valueTuple2.Item2 != valueTuple.Item2)
				{
					flag = (valueTuple2.Item2 < valueTuple.Item2);
				}
				else
				{
					flag = (publicBabelTowerInfo.PlayerId < playerId);
				}
				if (flag)
				{
					num++;
				}
			}
		}
		return num + 1;
	}

	// Token: 0x06007926 RID: 31014 RVA: 0x001FCC2C File Offset: 0x001FAE2C
	public int GetSelfHeadId()
	{
		return ModelBase<PersonalModel>.Instance.GetHeadPhotoId();
	}

	// Token: 0x06007927 RID: 31015 RVA: 0x001FCC38 File Offset: 0x001FAE38
	[NullableContext(0)]
	[return: TupleElementNames(new string[]
	{
		"TitleId",
		"TitleStarLevel"
	})]
	public ValueTuple<int, int> GetSelfTitleInfo()
	{
		PersonalModel instance = ModelBase<PersonalModel>.Instance;
		int dressedPlayerTitleId = instance.GetDressedPlayerTitleId();
		if (dressedPlayerTitleId > 0)
		{
			return new ValueTuple<int, int>(dressedPlayerTitleId, instance.GetDressedPlayerTitleLevel());
		}
		PublicBabelTowerInfo rawSelfData = this.RawSelfData;
		int item = (rawSelfData != null) ? rawSelfData.TitleId : 0;
		PublicBabelTowerInfo rawSelfData2 = this.RawSelfData;
		return new ValueTuple<int, int>(item, (rawSelfData2 != null) ? rawSelfData2.TitleExtraParam : 0);
	}

	// Token: 0x06007929 RID: 31017 RVA: 0x001FCD04 File Offset: 0x001FAF04
	[NullableContext(2)]
	[CompilerGenerated]
	private void <UpdateAllLevelRoleIds>g__FixList|12_0(RepeatedField<int> list)
	{
		if (list == null)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			list[i] = this.CheckMainCharacterCorrect(list[i]);
		}
	}

	// Token: 0x04003A46 RID: 14918
	private readonly Dictionary<int, int> OldLevelRankMap = new Dictionary<int, int>();

	// Token: 0x04003A47 RID: 14919
	private int OldTotalRank;

	// Token: 0x04003A48 RID: 14920
	public Dictionary<int, BabelActivityLevelInfo> NormalLevelDataMap = new Dictionary<int, BabelActivityLevelInfo>();

	// Token: 0x04003A49 RID: 14921
	public Dictionary<int, BabelActivityLevelInfo> HardLevelDataMap = new Dictionary<int, BabelActivityLevelInfo>();

	// Token: 0x04003A4A RID: 14922
	public Dictionary<int, ActivityTask> NormalQuest = new Dictionary<int, ActivityTask>();

	// Token: 0x04003A4B RID: 14923
	public Dictionary<int, ActivityTask> DailyQuest = new Dictionary<int, ActivityTask>();

	// Token: 0x04003A4C RID: 14924
	public Dictionary<int, bool> BuffUnlock = new Dictionary<int, bool>();

	// Token: 0x04003A4D RID: 14925
	public Dictionary<int, bool> DeTermUnlock = new Dictionary<int, bool>();

	// Token: 0x04003A4E RID: 14926
	public Dictionary<int, List<int>> RoleLockData = new Dictionary<int, List<int>>();

	// Token: 0x04003A4F RID: 14927
	public int CurrentItemCount;

	// Token: 0x04003A50 RID: 14928
	private List<PublicBabelTowerInfo> RawFriendData = new List<PublicBabelTowerInfo>();

	// Token: 0x04003A51 RID: 14929
	[Nullable(2)]
	private PublicBabelTowerInfo RawSelfData;
}
