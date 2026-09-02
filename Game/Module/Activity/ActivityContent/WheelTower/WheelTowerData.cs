using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x020061F3 RID: 25075
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerData : ActivityBaseData
	{
		// Token: 0x17009B4C RID: 39756
		// (get) Token: 0x0603F442 RID: 259138 RVA: 0x0103CB68 File Offset: 0x0103AD68
		// (set) Token: 0x0603F443 RID: 259139 RVA: 0x0103CB70 File Offset: 0x0103AD70
		public int CycleId { get; private set; } = -1;

		// Token: 0x17009B4D RID: 39757
		// (get) Token: 0x0603F444 RID: 259140 RVA: 0x0103CB79 File Offset: 0x0103AD79
		// (set) Token: 0x0603F445 RID: 259141 RVA: 0x0103CB81 File Offset: 0x0103AD81
		public double CycleBeginTime { get; private set; } = -1.0;

		// Token: 0x17009B4E RID: 39758
		// (get) Token: 0x0603F446 RID: 259142 RVA: 0x0103CB8A File Offset: 0x0103AD8A
		// (set) Token: 0x0603F447 RID: 259143 RVA: 0x0103CB92 File Offset: 0x0103AD92
		public double CycleEndTime { get; private set; } = -1.0;

		// Token: 0x17009B4F RID: 39759
		// (get) Token: 0x0603F448 RID: 259144 RVA: 0x0103CB9B File Offset: 0x0103AD9B
		// (set) Token: 0x0603F449 RID: 259145 RVA: 0x0103CBA3 File Offset: 0x0103ADA3
		public bool IsRequestedRecommendLineUp { get; private set; }

		// Token: 0x17009B50 RID: 39760
		// (get) Token: 0x0603F44A RID: 259146 RVA: 0x0103CBAC File Offset: 0x0103ADAC
		// (set) Token: 0x0603F44B RID: 259147 RVA: 0x0103CBB4 File Offset: 0x0103ADB4
		public int SeasonId { get; private set; } = 1;

		// Token: 0x17009B51 RID: 39761
		// (get) Token: 0x0603F44C RID: 259148 RVA: 0x0103CBBD File Offset: 0x0103ADBD
		// (set) Token: 0x0603F44D RID: 259149 RVA: 0x0103CBC5 File Offset: 0x0103ADC5
		public double SeasonBeginTime { get; private set; }

		// Token: 0x17009B52 RID: 39762
		// (get) Token: 0x0603F44E RID: 259150 RVA: 0x0103CBCE File Offset: 0x0103ADCE
		// (set) Token: 0x0603F44F RID: 259151 RVA: 0x0103CBD6 File Offset: 0x0103ADD6
		public double SeasonEndTime { get; private set; }

		// Token: 0x0603F450 RID: 259152 RVA: 0x0103CBE0 File Offset: 0x0103ADE0
		protected override void PhraseEx(ActivityData data)
		{
			ModelBase<WheelTowerModel>.Instance.SetActivityId(base.Id);
			NewTowerClimbingActivityData newTowerClimbingActivityData = data.NewTowerClimbingActivityData;
			if (newTowerClimbingActivityData == null)
			{
				return;
			}
			this.ParseCycleInfo(newTowerClimbingActivityData);
			this.ParseLevelRecord(newTowerClimbingActivityData.Records.ToList<NewTowerClimbingLevelRecord>());
			this.ParseEnergyInfo(newTowerClimbingActivityData.Records.ToList<NewTowerClimbingLevelRecord>());
			this.ParseTaskInfo(newTowerClimbingActivityData);
			this.ParseSeasonInfo(newTowerClimbingActivityData);
		}

		// Token: 0x0603F451 RID: 259153 RVA: 0x0103CC40 File Offset: 0x0103AE40
		private void ParseCycleInfo(NewTowerClimbingActivityData activityData)
		{
			if (this.CycleId != -1 && this.CycleId != activityData.CycleId)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.WheelTowerCycleChange);
			}
			this.CycleId = activityData.CycleId;
			this.CycleBeginTime = (double)Singleton<MathUtils>.Instance.LongToNumber(activityData.CycleBeginTime);
			this.CycleEndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(activityData.CycleCloseTime);
		}

		// Token: 0x0603F452 RID: 259154 RVA: 0x0103CCB0 File Offset: 0x0103AEB0
		private void ParseLevelRecord(List<NewTowerClimbingLevelRecord> levelRecords)
		{
			this.LevelRecordMap.Clear();
			foreach (NewTowerClimbingLevelRecord newTowerClimbingLevelRecord in levelRecords)
			{
				NewTowerLevel? levelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetLevelConfigById(newTowerClimbingLevelRecord.LevelId);
				if (levelConfigById != null)
				{
					bool key = levelConfigById.Value.Diff != 0;
					this.LevelRecordMap[key] = newTowerClimbingLevelRecord;
				}
			}
			this.UpdateLevelRecordRoleId();
		}

		// Token: 0x0603F453 RID: 259155 RVA: 0x0103CD44 File Offset: 0x0103AF44
		private void UpdateLevelRecordRoleId()
		{
			foreach (NewTowerClimbingLevelRecord newTowerClimbingLevelRecord in this.LevelRecordMap.Values)
			{
				foreach (TeamChallengeInfo teamChallengeInfo in newTowerClimbingLevelRecord.TeamChallengeInfos)
				{
					foreach (RoleSaveInfo roleSaveInfo in teamChallengeInfo.RoleSaveInfos)
					{
						roleSaveInfo.RoleId = this.CheckMainCharacterCorrect(roleSaveInfo.RoleId);
					}
				}
			}
		}

		// Token: 0x0603F454 RID: 259156 RVA: 0x0103CE10 File Offset: 0x0103B010
		private void ParseEnergyInfo(List<NewTowerClimbingLevelRecord> levelRecords)
		{
			this.EnergyInfoMap.Clear();
			foreach (NewTowerClimbingLevelRecord newTowerClimbingLevelRecord in levelRecords)
			{
				NewTowerLevel? levelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetLevelConfigById(newTowerClimbingLevelRecord.LevelId);
				if (levelConfigById != null)
				{
					bool key = levelConfigById.Value.Diff != 0;
					Dictionary<int, int> dictionary = new Dictionary<int, int>();
					foreach (KeyValuePair<int, int> keyValuePair in newTowerClimbingLevelRecord.RoleEnergyDict)
					{
						dictionary[this.CheckMainCharacterCorrect(keyValuePair.Key)] = keyValuePair.Value;
					}
					this.EnergyInfoMap[key] = this.CreateEnergyInfo(dictionary, newTowerClimbingLevelRecord.TeamChallengeInfos.ToList<TeamChallengeInfo>());
				}
			}
		}

		// Token: 0x0603F455 RID: 259157 RVA: 0x0103CF18 File Offset: 0x0103B118
		public EnergyInfo GetRoundEnergyInfo(bool endless, int round)
		{
			NewTowerClimbingLevelRecord levelRecord = this.GetLevelRecord(endless);
			Dictionary<int, int> dictionary = this.EnergyInfoMap[endless].RoleEnergyMap.ToDictionary((KeyValuePair<int, int> kv) => kv.Key, (KeyValuePair<int, int> kv) => kv.Value);
			for (int i = round; i < levelRecord.TeamChallengeInfos.Count; i++)
			{
				foreach (RoleSaveInfo roleSaveInfo in levelRecord.TeamChallengeInfos[i].RoleSaveInfos)
				{
					int num = ModelBase<WheelTowerModel>.Instance.TryGetRealRoleId(roleSaveInfo.RoleId);
					int roleCost = ModelBase<WheelTowerModel>.Instance.GetRoleCost(num);
					int num2 = dictionary[num];
					dictionary[num] = num2 + roleCost;
				}
			}
			return this.CreateEnergyInfo(dictionary, levelRecord.TeamChallengeInfos.Take(round).ToList<TeamChallengeInfo>());
		}

		// Token: 0x0603F456 RID: 259158 RVA: 0x0103D030 File Offset: 0x0103B230
		private EnergyInfo CreateEnergyInfo(Dictionary<int, int> roleEnergyDict, List<TeamChallengeInfo> teamChallengeInfos)
		{
			EnergyInfo energyInfo = new EnergyInfo();
			foreach (KeyValuePair<int, int> keyValuePair in roleEnergyDict)
			{
				energyInfo.RoleEnergyMap[keyValuePair.Key] = keyValuePair.Value;
			}
			foreach (TeamChallengeInfo teamChallengeInfo in teamChallengeInfos)
			{
				foreach (RoleSaveInfo roleSaveInfo in teamChallengeInfo.RoleSaveInfos)
				{
					int num = ModelBase<WheelTowerModel>.Instance.TryGetRealRoleId(roleSaveInfo.RoleId);
					if (roleSaveInfo.WeaponIncId != 0)
					{
						energyInfo.WeaponEnergyMap[roleSaveInfo.WeaponIncId] = num;
					}
					foreach (int num2 in roleSaveInfo.PhantomIncId)
					{
						if (num2 != 0)
						{
							energyInfo.PhantomEnergyMap[num2] = num;
						}
					}
					energyInfo.SkillBranchMap[num] = roleSaveInfo.SkillBranchId;
				}
			}
			return energyInfo;
		}

		// Token: 0x0603F457 RID: 259159 RVA: 0x0103D1A8 File Offset: 0x0103B3A8
		public int CheckMainCharacterCorrect(int roleId)
		{
			int roleId2 = ModelBase<WheelTowerModel>.Instance.TryGetRealRoleId(roleId);
			if (!ModelBase<RoleModel>.Instance.IsMainRole(roleId2))
			{
				return roleId;
			}
			int valueOrDefault = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId().GetValueOrDefault();
			if (ModelBase<WheelTowerModel>.Instance.IsTemplateRole(roleId))
			{
				return ModelBase<WheelTowerModel>.Instance.GetTemplateRoleId(valueOrDefault);
			}
			return valueOrDefault;
		}

		// Token: 0x0603F458 RID: 259160 RVA: 0x0103D200 File Offset: 0x0103B400
		private void ParseTaskInfo(NewTowerClimbingActivityData activityData)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (NewTowerClimbingLevelRecord newTowerClimbingLevelRecord in activityData.Records)
			{
				NewTowerLevel? levelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetLevelConfigById(newTowerClimbingLevelRecord.LevelId);
				if (levelConfigById != null)
				{
					int diff = levelConfigById.Value.Diff;
					IReadOnlyList<NewTowerScoreReward> rewardConfigListByLevelId = ConfigBase<WheelTowerConfig>.Instance.GetRewardConfigListByLevelId(newTowerClimbingLevelRecord.LevelId);
					if (rewardConfigListByLevelId != null)
					{
						foreach (NewTowerScoreReward newTowerScoreReward in rewardConfigListByLevelId)
						{
							dictionary[newTowerScoreReward.Id] = diff;
						}
					}
				}
			}
			this.TaskMap.Clear();
			foreach (ActivityTask task in activityData.ActivityTasks)
			{
				global::ActivityTaskData activityTaskData = new global::ActivityTaskData();
				activityTaskData.Refresh(task, null);
				int typeId;
				if (dictionary.TryGetValue(activityTaskData.Id, out typeId))
				{
					activityTaskData.TypeId = typeId;
				}
				this.TaskMap[activityTaskData.Id] = activityTaskData;
			}
		}

		// Token: 0x0603F459 RID: 259161 RVA: 0x0103D360 File Offset: 0x0103B560
		public void ParseSeasonInfo(NewTowerClimbingActivityData activityData)
		{
			this.SeasonId = activityData.SeasonId;
			this.SeasonBeginTime = (double)Singleton<MathUtils>.Instance.LongToNumber(activityData.SeasonBeginTime);
			this.SeasonEndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(activityData.SeasonCloseTime);
			this.ReceivedSeasonScoreRewards.Clear();
			this.ReceivedSeasonScoreRewards.AddRange(activityData.ScoreTasks);
			this.SeasonTaskDataMap.Clear();
			this.UpdateSeasonTaskList(activityData.SeasonTasks.ToList<ActivityTask>());
		}

		// Token: 0x0603F45A RID: 259162 RVA: 0x0103D3E0 File Offset: 0x0103B5E0
		public void UpdateSeasonTaskList(IList<ActivityTask> taskList)
		{
			foreach (ActivityTask task in taskList)
			{
				this.UpdateSeasonTask(task);
			}
		}

		// Token: 0x0603F45B RID: 259163 RVA: 0x0103D428 File Offset: 0x0103B628
		public void RemoveSeasonTaskList(IList<int> taskIds)
		{
			foreach (int key in taskIds)
			{
				this.SeasonTaskDataMap.Remove(key);
			}
		}

		// Token: 0x0603F45C RID: 259164 RVA: 0x0103D478 File Offset: 0x0103B678
		private void UpdateSeasonTask(ActivityTask task)
		{
			global::ActivityTaskData activityTaskData;
			if (!this.SeasonTaskDataMap.TryGetValue(task.Id, out activityTaskData))
			{
				activityTaskData = new global::ActivityTaskData();
			}
			activityTaskData.Refresh(task, null);
			this.SeasonTaskDataMap[task.Id] = activityTaskData;
		}

		// Token: 0x0603F45D RID: 259165 RVA: 0x0103D4BA File Offset: 0x0103B6BA
		public bool IsInCycle()
		{
			return this.CycleId > 0;
		}

		// Token: 0x0603F45E RID: 259166 RVA: 0x0103D4C8 File Offset: 0x0103B6C8
		public bool IsInCycleTime()
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return serverTime >= this.CycleBeginTime && serverTime <= this.CycleEndTime;
		}

		// Token: 0x0603F45F RID: 259167 RVA: 0x0103D4F7 File Offset: 0x0103B6F7
		public double GetCycleRemainTime()
		{
			return (double)base.EndShowTime - Singleton<Time>.Instance.ServerTimeStamp / 1000.0;
		}

		// Token: 0x0603F460 RID: 259168 RVA: 0x0103D518 File Offset: 0x0103B718
		public CommonDefine.ICountDown GetCycleCountDownData()
		{
			double num = this.GetCycleRemainTime();
			if (num <= 1.0)
			{
				num = 1.0;
			}
			CommonDefine.ETimeType value = (num >= 86400.0) ? CommonDefine.ETimeType.Day : ((num >= 3600.0) ? CommonDefine.ETimeType.Hour : CommonDefine.ETimeType.Minute);
			CommonDefine.ETimeType value2 = (num >= 86400.0) ? CommonDefine.ETimeType.Hour : ((num >= 3600.0) ? CommonDefine.ETimeType.Minute : CommonDefine.ETimeType.Second);
			return Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(value), new CommonDefine.ETimeType?(value2));
		}

		// Token: 0x0603F461 RID: 259169 RVA: 0x0103D599 File Offset: 0x0103B799
		public bool IsTowerUnlocked()
		{
			if (!base.IsUnLock())
			{
				return false;
			}
			return this.LevelRecordMap.Values.Any((NewTowerClimbingLevelRecord levelRecord) => levelRecord.IsUnlock);
		}

		// Token: 0x0603F462 RID: 259170 RVA: 0x0103D5D4 File Offset: 0x0103B7D4
		public NewTowerClimbingLevelRecord GetLevelRecord(bool isEndless)
		{
			return this.LevelRecordMap[isEndless];
		}

		// Token: 0x0603F463 RID: 259171 RVA: 0x0103D5E4 File Offset: 0x0103B7E4
		public bool IsLevelUnlocked(bool endless)
		{
			NewTowerClimbingLevelRecord newTowerClimbingLevelRecord;
			return this.LevelRecordMap.TryGetValue(endless, out newTowerClimbingLevelRecord) && newTowerClimbingLevelRecord.IsUnlock;
		}

		// Token: 0x0603F464 RID: 259172 RVA: 0x0103D609 File Offset: 0x0103B809
		public int GetHistoryBestScore(bool isEndless)
		{
			return this.GetLevelRecord(isEndless).HistoryScore;
		}

		// Token: 0x0603F465 RID: 259173 RVA: 0x0103D617 File Offset: 0x0103B817
		public int GetRoundScore(bool isEndless, int round)
		{
			TeamChallengeInfo teamChallengeInfo = this.GetLevelRecord(isEndless).TeamChallengeInfos.ElementAtOrDefault(round);
			if (teamChallengeInfo == null)
			{
				return 0;
			}
			return teamChallengeInfo.TeamScore;
		}

		// Token: 0x0603F466 RID: 259174 RVA: 0x0103D638 File Offset: 0x0103B838
		public int GetRoundTotalScore(bool isEndless, int round)
		{
			int num = 0;
			for (int i = 0; i <= round; i++)
			{
				num += this.GetRoundScore(isEndless, i);
			}
			return num;
		}

		// Token: 0x0603F467 RID: 259175 RVA: 0x0103D65F File Offset: 0x0103B85F
		public int GetTotalScore(bool isEndless)
		{
			if (this.GetLevelRecord(isEndless).TeamChallengeInfos.Count > 0)
			{
				return this.GetRoundTotalScore(isEndless, this.GetLevelRecord(isEndless).TeamChallengeInfos.Count - 1);
			}
			return 0;
		}

		// Token: 0x0603F468 RID: 259176 RVA: 0x0103D694 File Offset: 0x0103B894
		public bool IsRewardCanReceive(int rewardId)
		{
			global::ActivityTaskData activityTaskData;
			return this.TaskMap.TryGetValue(rewardId, out activityTaskData) && activityTaskData.Status == EActivityTaskState.FinishedAndUnclaimed;
		}

		// Token: 0x0603F469 RID: 259177 RVA: 0x0103D6BC File Offset: 0x0103B8BC
		public bool IsRewardCompleted(int rewardId)
		{
			global::ActivityTaskData activityTaskData;
			return this.TaskMap.TryGetValue(rewardId, out activityTaskData) && activityTaskData.Status == EActivityTaskState.FinishedAndClaimed;
		}

		// Token: 0x0603F46A RID: 259178 RVA: 0x0103D6E4 File Offset: 0x0103B8E4
		public bool HasAnyRewardCanReceive(EFilterMode filterMode = EFilterMode.All)
		{
			return this.GetCanReceiveRewardId(filterMode).Count > 0;
		}

		// Token: 0x0603F46B RID: 259179 RVA: 0x0103D6F5 File Offset: 0x0103B8F5
		public EActivityTaskState GetTaskState(int taskId)
		{
			return this.TaskMap[taskId].Status;
		}

		// Token: 0x0603F46C RID: 259180 RVA: 0x0103D708 File Offset: 0x0103B908
		public global::ActivityTaskData GetTask(int taskId)
		{
			return this.TaskMap[taskId];
		}

		// Token: 0x0603F46D RID: 259181 RVA: 0x0103D718 File Offset: 0x0103B918
		public List<global::ActivityTaskData> GetFilterTaskList(EFilterMode filterMode = EFilterMode.All)
		{
			List<global::ActivityTaskData> list = this.TaskMap.Values.ToList<global::ActivityTaskData>();
			List<global::ActivityTaskData> result;
			if (filterMode != EFilterMode.Normal)
			{
				if (filterMode != EFilterMode.Endless)
				{
					result = list;
				}
				else
				{
					result = (from task in list
					where task.TypeId != 0
					select task).ToList<global::ActivityTaskData>();
				}
			}
			else
			{
				result = (from task in list
				where task.TypeId == 0
				select task).ToList<global::ActivityTaskData>();
			}
			return result;
		}

		// Token: 0x0603F46E RID: 259182 RVA: 0x0103D7A0 File Offset: 0x0103B9A0
		public List<int> GetCanReceiveRewardId(EFilterMode filterMode = EFilterMode.All)
		{
			return (from task in this.GetFilterTaskList(filterMode)
			where task.Status == EActivityTaskState.FinishedAndUnclaimed
			select task.Id).ToList<int>();
		}

		// Token: 0x0603F46F RID: 259183 RVA: 0x0103D801 File Offset: 0x0103BA01
		public int GetCurrentRewardProgress(EFilterMode filterMode = EFilterMode.All)
		{
			return this.GetFilterTaskList(filterMode).Count((global::ActivityTaskData task) => task.Status == EActivityTaskState.FinishedAndClaimed);
		}

		// Token: 0x0603F470 RID: 259184 RVA: 0x0103D82E File Offset: 0x0103BA2E
		public int GetTotalRewardProgress(EFilterMode filterMode = EFilterMode.All)
		{
			return this.GetFilterTaskList(filterMode).Count;
		}

		// Token: 0x0603F471 RID: 259185 RVA: 0x0103D83C File Offset: 0x0103BA3C
		public void OnSeasonTaskClaim(IList<int> taskIdList)
		{
			foreach (int key in taskIdList)
			{
				global::ActivityTaskData activityTaskData;
				if (this.SeasonTaskDataMap.TryGetValue(key, out activityTaskData))
				{
					activityTaskData.Status = EActivityTaskState.FinishedAndClaimed;
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603F472 RID: 259186 RVA: 0x0103D8AC File Offset: 0x0103BAAC
		public void OnSeasonScoreClaim(IList<int> scoreIdList)
		{
			foreach (int item in scoreIdList)
			{
				if (!this.ReceivedSeasonScoreRewards.Contains(item))
				{
					this.ReceivedSeasonScoreRewards.Add(item);
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603F473 RID: 259187 RVA: 0x0103D920 File Offset: 0x0103BB20
		public List<global::ActivityTaskData> GetSeasonTaskList()
		{
			return this.SeasonTaskDataMap.Values.ToList<global::ActivityTaskData>();
		}

		// Token: 0x0603F474 RID: 259188 RVA: 0x0103D934 File Offset: 0x0103BB34
		public List<int> GetCanReceiveSeasonRewardIds()
		{
			return (from task in this.SeasonTaskDataMap.Values
			where task.Status == EActivityTaskState.FinishedAndUnclaimed
			select task.Id).ToList<int>();
		}

		// Token: 0x0603F475 RID: 259189 RVA: 0x0103D99C File Offset: 0x0103BB9C
		public List<int> GetReceivedSeasonRewardIds()
		{
			return (from task in this.SeasonTaskDataMap.Values
			where task.Status == EActivityTaskState.FinishedAndClaimed
			select task.Id).ToList<int>();
		}

		// Token: 0x0603F476 RID: 259190 RVA: 0x0103DA04 File Offset: 0x0103BC04
		public List<int> GetCanReceiveSeasonScoreRewardIds()
		{
			IReadOnlyList<NewTowerSeasonSAward> seasonScoreRewardConfigList = ConfigBase<WheelTowerConfig>.Instance.GetSeasonScoreRewardConfigList(this.SeasonId);
			if (seasonScoreRewardConfigList == null)
			{
				return new List<int>();
			}
			int seasonScoreItemId = ConfigBase<WheelTowerConfig>.Instance.GetSeasonScoreItemId(this.SeasonId);
			int curScoreNum = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(seasonScoreItemId, 0);
			return (from config in seasonScoreRewardConfigList
			where !this.ReceivedSeasonScoreRewards.Contains(config.Id) && curScoreNum >= config.Score
			select config.Id).ToList<int>();
		}

		// Token: 0x0603F477 RID: 259191 RVA: 0x0103DA96 File Offset: 0x0103BC96
		public bool IsSeasonScoreRewardReceived(int rewardId)
		{
			return this.ReceivedSeasonScoreRewards.Contains(rewardId);
		}

		// Token: 0x0603F478 RID: 259192 RVA: 0x0103DAA4 File Offset: 0x0103BCA4
		public void OnAddNewRecord(NewTowerResultNotify notify)
		{
			int levelId = notify.LevelId;
			NewTowerLevel? levelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetLevelConfigById(levelId);
			if (levelConfigById == null)
			{
				return;
			}
			bool flag = levelConfigById.Value.Diff != 0;
			NewTowerClimbingLevelRecord levelRecord = this.GetLevelRecord(flag);
			levelRecord.TeamChallengeInfos.Add(notify.TeamChallengeInfo);
			levelRecord.NextMonsterInfoPreview = notify.TeamChallengeInfo.LastMonsterInfoPreview;
			EnergyInfo energyInfo = this.EnergyInfoMap[flag];
			foreach (RoleSaveInfo roleSaveInfo in notify.TeamChallengeInfo.RoleSaveInfos)
			{
				int num = ModelBase<WheelTowerModel>.Instance.TryGetRealRoleId(roleSaveInfo.RoleId);
				int roleCost = ModelBase<WheelTowerModel>.Instance.GetRoleCost(num);
				energyInfo.RoleEnergyMap[num] = energyInfo.RoleEnergyMap[num] - roleCost;
				if (roleSaveInfo.WeaponIncId != 0)
				{
					energyInfo.WeaponEnergyMap[roleSaveInfo.WeaponIncId] = num;
				}
				foreach (int num2 in roleSaveInfo.PhantomIncId)
				{
					if (num2 != 0)
					{
						energyInfo.PhantomEnergyMap[num2] = num;
					}
				}
			}
			levelRecord.Score = notify.AfterLevelScore;
			if (levelRecord.HistoryScore < notify.AfterLevelScore)
			{
				levelRecord.HistoryScore = notify.AfterLevelScore;
			}
		}

		// Token: 0x0603F479 RID: 259193 RVA: 0x0103DC38 File Offset: 0x0103BE38
		public void OnLevelRecordUpdateNotify(NewTowerClimbingLevelRecord levelRecord)
		{
			this.ParseLevelRecord(new List<NewTowerClimbingLevelRecord>
			{
				levelRecord
			});
			this.ParseEnergyInfo(new List<NewTowerClimbingLevelRecord>
			{
				levelRecord
			});
		}

		// Token: 0x0603F47A RID: 259194 RVA: 0x0103DC60 File Offset: 0x0103BE60
		public void OnRoleEnergyUpdateNotify(IList<RecordRoleEnergy> roleEnergyRecordList)
		{
			this.UpdateLevelRecordRoleId();
			foreach (RecordRoleEnergy recordRoleEnergy in roleEnergyRecordList)
			{
				NewTowerLevel? levelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetLevelConfigById(recordRoleEnergy.LevelId);
				if (levelConfigById != null)
				{
					bool key = levelConfigById.Value.Diff != 0;
					Dictionary<int, int> roleEnergyDict = recordRoleEnergy.RoleEnergyDict.ToDictionary((KeyValuePair<int, int> kv) => kv.Key, (KeyValuePair<int, int> kv) => kv.Value);
					this.EnergyInfoMap[key] = this.CreateEnergyInfo(roleEnergyDict, this.LevelRecordMap[key].TeamChallengeInfos.ToList<TeamChallengeInfo>());
				}
			}
		}

		// Token: 0x0603F47B RID: 259195 RVA: 0x0103DD54 File Offset: 0x0103BF54
		public void OnTaskClaim(IList<int> taskIdList)
		{
			foreach (int key in taskIdList)
			{
				global::ActivityTaskData activityTaskData;
				if (this.TaskMap.TryGetValue(key, out activityTaskData))
				{
					activityTaskData.Status = EActivityTaskState.FinishedAndClaimed;
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603F47C RID: 259196 RVA: 0x0103DDC4 File Offset: 0x0103BFC4
		public void OnTaskUpdateNotify(IList<ActivityTask> activityTaskList)
		{
			foreach (ActivityTask activityTask in activityTaskList)
			{
				global::ActivityTaskData activityTaskData;
				if (this.TaskMap.TryGetValue(activityTask.Id, out activityTaskData))
				{
					activityTaskData.Refresh(activityTask, null);
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603F47D RID: 259197 RVA: 0x0103DE38 File Offset: 0x0103C038
		public bool CheckFirstOpenPage()
		{
			return !this.GetExDataFinishShowState() && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 0, this.CycleId, 0) == 0;
		}

		// Token: 0x0603F47E RID: 259198 RVA: 0x0103DE60 File Offset: 0x0103C060
		public void ReadRedDot()
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 0, this.CycleId, 0, 1);
			Singleton<EventSystem>.Instance.Emit(EEventName.RedDotAdventurePeriodicityTabUpdate);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603F47F RID: 259199 RVA: 0x0103DEAC File Offset: 0x0103C0AC
		public bool ShouldShowSeasonRewardRedDot()
		{
			return this.CheckFirstReadSeasonReward() || this.HasAnySeasonRewardCanReceive();
		}

		// Token: 0x0603F480 RID: 259200 RVA: 0x0103DEBE File Offset: 0x0103C0BE
		private bool CheckFirstReadSeasonReward()
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 2, this.SeasonId, 0) == 0;
		}

		// Token: 0x0603F481 RID: 259201 RVA: 0x0103DEDC File Offset: 0x0103C0DC
		public void RecordReadSeasonReward()
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 2, this.SeasonId, 0, 1);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603F482 RID: 259202 RVA: 0x0103DF0D File Offset: 0x0103C10D
		public bool ShouldShowRewardRedDot()
		{
			return this.CheckFirstReadReward() || this.HasAnyRewardCanReceive(EFilterMode.All);
		}

		// Token: 0x0603F483 RID: 259203 RVA: 0x0103DF20 File Offset: 0x0103C120
		private bool CheckFirstReadReward()
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 3, this.CycleId, 0) == 0;
		}

		// Token: 0x0603F484 RID: 259204 RVA: 0x0103DF3E File Offset: 0x0103C13E
		public void RecordReadReward()
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 3, this.CycleId, 0, 1);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603F485 RID: 259205 RVA: 0x0103DF6F File Offset: 0x0103C16F
		public bool HasAnyLevelRedDot()
		{
			return this.HasLevelRedDot(false) || this.HasLevelRedDot(true);
		}

		// Token: 0x0603F486 RID: 259206 RVA: 0x0103DF84 File Offset: 0x0103C184
		public bool HasLevelRedDot(bool endless)
		{
			NewTowerClimbingLevelRecord newTowerClimbingLevelRecord;
			return this.LevelRecordMap.TryGetValue(endless, out newTowerClimbingLevelRecord) && newTowerClimbingLevelRecord.IsUnlock && this.CheckFirstEnterLevel(newTowerClimbingLevelRecord.LevelId);
		}

		// Token: 0x0603F487 RID: 259207 RVA: 0x0103DFB7 File Offset: 0x0103C1B7
		private bool CheckFirstEnterLevel(int levelId)
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 1, this.CycleId, levelId) == 0;
		}

		// Token: 0x0603F488 RID: 259208 RVA: 0x0103DFD8 File Offset: 0x0103C1D8
		public void RecordEnterLevel(bool endless)
		{
			NewTowerClimbingLevelRecord newTowerClimbingLevelRecord;
			int key = this.LevelRecordMap.TryGetValue(endless, out newTowerClimbingLevelRecord) ? newTowerClimbingLevelRecord.LevelId : 0;
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 1, this.CycleId, key, 1);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603F489 RID: 259209 RVA: 0x0103E02E File Offset: 0x0103C22E
		public bool HasBossHandBookRedDot()
		{
			return this.CheckFirstOpenBossHandBook();
		}

		// Token: 0x0603F48A RID: 259210 RVA: 0x0103E036 File Offset: 0x0103C236
		private bool CheckFirstOpenBossHandBook()
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 4, this.CycleId, 0) == 0;
		}

		// Token: 0x0603F48B RID: 259211 RVA: 0x0103E054 File Offset: 0x0103C254
		public void RecordOpenBossHandBook()
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 4, this.CycleId, 0, 1);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603F48C RID: 259212 RVA: 0x0103E085 File Offset: 0x0103C285
		public bool HasAnySeasonRewardCanReceive()
		{
			return this.GetCanReceiveSeasonRewardIds().Count > 0 || this.GetCanReceiveSeasonScoreRewardIds().Count > 0;
		}

		// Token: 0x0603F48D RID: 259213 RVA: 0x0103E0A5 File Offset: 0x0103C2A5
		public override bool GetExDataRedPointShowState()
		{
			return this.IsInCycle() && (this.CheckFirstOpenPage() || this.ShouldShowSeasonRewardRedDot() || this.ShouldShowRewardRedDot() || ModelBase<WheelTowerModel>.Instance.HasUnreadSeasonMedalRedDot(this.SeasonId));
		}

		// Token: 0x0603F48E RID: 259214 RVA: 0x0103E0DC File Offset: 0x0103C2DC
		protected override bool GetExDataFinishShowState()
		{
			if (!this.IsInCycle())
			{
				return false;
			}
			bool flag = this.GetReceivedSeasonRewardIds().Count >= this.GetSeasonTaskList().Count;
			bool flag2 = this.GetCurrentRewardProgress(EFilterMode.All) >= this.GetTotalRewardProgress(EFilterMode.All);
			return flag && flag2;
		}

		// Token: 0x0603F48F RID: 259215 RVA: 0x0103E124 File Offset: 0x0103C324
		public bool GetExDataFinishShowStateExternal()
		{
			return this.GetExDataFinishShowState();
		}

		// Token: 0x0603F490 RID: 259216 RVA: 0x0103E12C File Offset: 0x0103C32C
		public void UpdateRecommendLineUp(IList<NewTowerRecommendLevel> list)
		{
			foreach (NewTowerRecommendLevel newTowerRecommendLevel in list)
			{
				if (!this.RecommendLineUpMap.ContainsKey(newTowerRecommendLevel.LevelId))
				{
					this.RecommendLineUpMap[newTowerRecommendLevel.LevelId] = new Dictionary<int, IList<NewTowerRecommendTeam>>();
				}
				this.RecommendLineUpMap[newTowerRecommendLevel.LevelId][newTowerRecommendLevel.RecommendId] = newTowerRecommendLevel.RecommendTeams;
			}
			this.IsRequestedRecommendLineUp = true;
		}

		// Token: 0x0603F491 RID: 259217 RVA: 0x0103E1C0 File Offset: 0x0103C3C0
		public IList<NewTowerRecommendTeam> GetLevelRecommendTeam(int levelId, int recommendId)
		{
			Dictionary<int, IList<NewTowerRecommendTeam>> dictionary;
			IList<NewTowerRecommendTeam> result;
			if (this.RecommendLineUpMap.TryGetValue(levelId, out dictionary) && dictionary.TryGetValue(recommendId, out result))
			{
				return result;
			}
			return new List<NewTowerRecommendTeam>();
		}

		// Token: 0x0603F492 RID: 259218 RVA: 0x0103E1F0 File Offset: 0x0103C3F0
		private List<NewTowerMedal> GetSortedMedalConfigsByGroupId(int groupId)
		{
			List<NewTowerMedal> result;
			if (this.SortedMedalConfigCache.TryGetValue(groupId, out result))
			{
				return result;
			}
			IReadOnlyList<NewTowerMedal> medalConfigListByGroupId = ConfigBase<WheelTowerConfig>.Instance.GetMedalConfigListByGroupId(groupId);
			if (medalConfigListByGroupId == null || medalConfigListByGroupId.Count == 0)
			{
				return new List<NewTowerMedal>();
			}
			List<NewTowerMedal> list = (from c in medalConfigListByGroupId
			orderby c.Target
			select c).ToList<NewTowerMedal>();
			this.SortedMedalConfigCache[groupId] = list;
			return list;
		}

		// Token: 0x0603F493 RID: 259219 RVA: 0x0103E268 File Offset: 0x0103C468
		private IWheelTowerMedalGroupData ResolveMedalGroupData(int groupId, int seasonId, int cycleId, int progress, long completeTime)
		{
			List<NewTowerMedal> sortedMedalConfigsByGroupId = this.GetSortedMedalConfigsByGroupId(groupId);
			int currentMedalId = 0;
			int nextMedalId = 0;
			int currentTarget = 0;
			bool isMaxLevel = false;
			if (sortedMedalConfigsByGroupId.Count > 0)
			{
				bool flag = false;
				foreach (NewTowerMedal newTowerMedal in sortedMedalConfigsByGroupId)
				{
					if (newTowerMedal.Target > progress)
					{
						nextMedalId = newTowerMedal.Id;
						currentTarget = newTowerMedal.Target;
						flag = true;
						break;
					}
					currentMedalId = newTowerMedal.Id;
				}
				if (!flag)
				{
					isMaxLevel = true;
					List<NewTowerMedal> list = sortedMedalConfigsByGroupId;
					currentTarget = list[list.Count - 1].Target;
				}
			}
			return new WheelTowerMedalGroupData
			{
				GroupId = groupId,
				SeasonId = seasonId,
				CycleId = cycleId,
				Progress = progress,
				CompleteTime = completeTime,
				CurrentMedalId = currentMedalId,
				NextMedalId = nextMedalId,
				CurrentTarget = currentTarget,
				IsMaxLevel = isMaxLevel
			};
		}

		// Token: 0x0603F494 RID: 259220 RVA: 0x0103E360 File Offset: 0x0103C560
		public void ParseMedalInfos([Nullable(new byte[]
		{
			2,
			1
		})] IEnumerable<NewTowerMedalInfo> infos)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (KeyValuePair<int, IWheelTowerMedalGroupData> keyValuePair in this.MedalGroupDataMap)
			{
				dictionary[keyValuePair.Key] = keyValuePair.Value.CurrentMedalId;
			}
			this.MedalGroupDataMap.Clear();
			if (infos == null)
			{
				return;
			}
			bool flag = false;
			foreach (NewTowerMedalInfo newTowerMedalInfo in infos)
			{
				IWheelTowerMedalGroupData wheelTowerMedalGroupData = this.ResolveMedalGroupData(newTowerMedalInfo.MedalGroupId, newTowerMedalInfo.SeasonId, newTowerMedalInfo.CycleId, newTowerMedalInfo.Progress, newTowerMedalInfo.CompleteTime);
				this.MedalGroupDataMap[wheelTowerMedalGroupData.GroupId] = wheelTowerMedalGroupData;
				int valueOrDefault = dictionary.GetValueOrDefault(wheelTowerMedalGroupData.GroupId, 0);
				if (wheelTowerMedalGroupData.CurrentMedalId > valueOrDefault)
				{
					flag = true;
				}
			}
			if (flag)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			}
		}

		// Token: 0x0603F495 RID: 259221 RVA: 0x0103E488 File Offset: 0x0103C688
		[NullableContext(2)]
		public IWheelTowerMedalGroupData GetMedalGroupData(int groupId)
		{
			IWheelTowerMedalGroupData result;
			if (this.MedalGroupDataMap.TryGetValue(groupId, out result))
			{
				return result;
			}
			List<NewTowerMedal> sortedMedalConfigsByGroupId = this.GetSortedMedalConfigsByGroupId(groupId);
			if (sortedMedalConfigsByGroupId.Count == 0)
			{
				return null;
			}
			NewTowerMedal newTowerMedal = sortedMedalConfigsByGroupId[0];
			return this.ResolveMedalGroupData(groupId, newTowerMedal.SeasonId, newTowerMedal.CycleId, 0, 0L);
		}

		// Token: 0x0603F496 RID: 259222 RVA: 0x0103E4D9 File Offset: 0x0103C6D9
		public List<IWheelTowerMedalGroupData> GetAllMedalGroupData()
		{
			return this.MedalGroupDataMap.Values.ToList<IWheelTowerMedalGroupData>();
		}

		// Token: 0x0402384A RID: 145482
		private readonly Dictionary<bool, NewTowerClimbingLevelRecord> LevelRecordMap = new Dictionary<bool, NewTowerClimbingLevelRecord>();

		// Token: 0x0402384B RID: 145483
		private readonly Dictionary<bool, EnergyInfo> EnergyInfoMap = new Dictionary<bool, EnergyInfo>();

		// Token: 0x0402384C RID: 145484
		private readonly Dictionary<int, global::ActivityTaskData> TaskMap = new Dictionary<int, global::ActivityTaskData>();

		// Token: 0x0402384D RID: 145485
		private readonly Dictionary<int, global::ActivityTaskData> SeasonTaskDataMap = new Dictionary<int, global::ActivityTaskData>();

		// Token: 0x0402384E RID: 145486
		private readonly Dictionary<int, Dictionary<int, IList<NewTowerRecommendTeam>>> RecommendLineUpMap = new Dictionary<int, Dictionary<int, IList<NewTowerRecommendTeam>>>();

		// Token: 0x0402384F RID: 145487
		private readonly List<int> ReceivedSeasonScoreRewards = new List<int>();

		// Token: 0x04023854 RID: 145492
		private readonly Dictionary<int, IWheelTowerMedalGroupData> MedalGroupDataMap = new Dictionary<int, IWheelTowerMedalGroupData>();

		// Token: 0x04023855 RID: 145493
		private readonly Dictionary<int, List<NewTowerMedal>> SortedMedalConfigCache = new Dictionary<int, List<NewTowerMedal>>();
	}
}
