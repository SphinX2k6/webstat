using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D27 RID: 23847
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeData
	{
		// Token: 0x17009885 RID: 39045
		// (get) Token: 0x0603C239 RID: 246329 RVA: 0x00F40809 File Offset: 0x00F3EA09
		// (set) Token: 0x0603C23A RID: 246330 RVA: 0x00F40811 File Offset: 0x00F3EA11
		public int ActivityId
		{
			get
			{
				return this.ActivityIdIntl;
			}
			set
			{
				this.ActivityIdIntl = value;
			}
		}

		// Token: 0x0603C23B RID: 246331 RVA: 0x00F4081A File Offset: 0x00F3EA1A
		public void ParseActivityData(FlagChallengeActivityInfo activityData)
		{
			this.InitData();
			this.ParseTaskData(activityData.ConditionTasks);
			this.ParseLevelData(activityData.FlagChallengeLevelInfos);
			this.ParseStrongHoldData(activityData.FlagStrongholdInfos);
			this.ParseRoleLevelData(activityData.FlagChallengeRoleLevelInfo);
			this.PostParseActivityData();
		}

		// Token: 0x0603C23C RID: 246332 RVA: 0x00F40858 File Offset: 0x00F3EA58
		private void PostParseActivityData()
		{
			using (Dictionary<int, List<FlagChallengeStrongholdData>>.ValueCollection.Enumerator enumerator = this.Area2Strongholds.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Sort((FlagChallengeStrongholdData a, FlagChallengeStrongholdData b) => a.StrongholdConfig.Index - b.StrongholdConfig.Index);
				}
			}
		}

		// Token: 0x0603C23D RID: 246333 RVA: 0x00F408CC File Offset: 0x00F3EACC
		private void InitData()
		{
			if (this.IsInited)
			{
				return;
			}
			this.IsInited = true;
			this.InitFormationInfo();
			this.InitBuffData();
			this.InitAreaData();
			this.InitRoleLevelData();
		}

		// Token: 0x0603C23E RID: 246334 RVA: 0x00F408F6 File Offset: 0x00F3EAF6
		public int? GetMainViewSelectLevelId()
		{
			return this.MainViewSelectLevelId;
		}

		// Token: 0x0603C23F RID: 246335 RVA: 0x00F408FE File Offset: 0x00F3EAFE
		public void SetMainViewSelectLevelId(int? id)
		{
			this.MainViewSelectLevelId = id;
		}

		// Token: 0x0603C240 RID: 246336 RVA: 0x00F40908 File Offset: 0x00F3EB08
		private void ParseTaskData(IList<ConditionTask> tasks)
		{
			foreach (ConditionTask task in tasks)
			{
				this.UpdateTaskData(task);
			}
		}

		// Token: 0x0603C241 RID: 246337 RVA: 0x00F40950 File Offset: 0x00F3EB50
		public void UpdateTaskData(ConditionTask task)
		{
			this.GetOrCreateTaskData(task.Id).Refresh(task);
		}

		// Token: 0x0603C242 RID: 246338 RVA: 0x00F40964 File Offset: 0x00F3EB64
		private FlagChallengeTaskData GetOrCreateTaskData(int taskId)
		{
			FlagChallengeTaskData flagChallengeTaskData = this.GetTaskData(taskId);
			if (flagChallengeTaskData == null)
			{
				flagChallengeTaskData = new FlagChallengeTaskData(taskId);
				this.TaskDataList.Add(flagChallengeTaskData);
			}
			return flagChallengeTaskData;
		}

		// Token: 0x0603C243 RID: 246339 RVA: 0x00F40990 File Offset: 0x00F3EB90
		[NullableContext(2)]
		public FlagChallengeTaskData GetTaskData(int id)
		{
			foreach (FlagChallengeTaskData flagChallengeTaskData in this.TaskDataList)
			{
				if (flagChallengeTaskData.Id == id)
				{
					return flagChallengeTaskData;
				}
			}
			return null;
		}

		// Token: 0x0603C244 RID: 246340 RVA: 0x00F409EC File Offset: 0x00F3EBEC
		public List<FlagChallengeTaskData> GetTaskDataList()
		{
			this.TaskDataList.Sort(new Comparison<FlagChallengeTaskData>(this.SortTaskData));
			return this.TaskDataList;
		}

		// Token: 0x0603C245 RID: 246341 RVA: 0x00F40A0C File Offset: 0x00F3EC0C
		public bool HasCanReceiveTask()
		{
			using (List<FlagChallengeTaskData>.Enumerator enumerator = this.TaskDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.CanReceiveReward())
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603C246 RID: 246342 RVA: 0x00F40A68 File Offset: 0x00F3EC68
		public List<int> GetFinishedTaskIdList()
		{
			List<int> list = new List<int>();
			foreach (FlagChallengeTaskData flagChallengeTaskData in this.TaskDataList)
			{
				if (flagChallengeTaskData.CanReceiveReward() || flagChallengeTaskData.IsTaskReceived())
				{
					list.Add(flagChallengeTaskData.Id);
				}
			}
			return list;
		}

		// Token: 0x0603C247 RID: 246343 RVA: 0x00F40AD8 File Offset: 0x00F3ECD8
		public List<int> GetCanReceiveTaskIdList()
		{
			List<int> list = new List<int>();
			foreach (FlagChallengeTaskData flagChallengeTaskData in this.TaskDataList)
			{
				if (flagChallengeTaskData.CanReceiveReward())
				{
					list.Add(flagChallengeTaskData.Id);
				}
			}
			return list;
		}

		// Token: 0x0603C248 RID: 246344 RVA: 0x00F40B40 File Offset: 0x00F3ED40
		private int SortTaskData(FlagChallengeTaskData a, FlagChallengeTaskData b)
		{
			if (a.CanReceiveReward() && !b.CanReceiveReward())
			{
				return -1;
			}
			if (!a.CanReceiveReward() && b.CanReceiveReward())
			{
				return 1;
			}
			if (!a.IsTaskReceived() && b.IsTaskReceived())
			{
				return -1;
			}
			if (a.IsTaskReceived() && !b.IsTaskReceived())
			{
				return 1;
			}
			return a.Id - b.Id;
		}

		// Token: 0x0603C249 RID: 246345 RVA: 0x00F40BA4 File Offset: 0x00F3EDA4
		public string GetTaskProgressText()
		{
			List<FlagChallengeTaskData> taskDataList = this.GetTaskDataList();
			List<int> finishedTaskIdList = this.GetFinishedTaskIdList();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(finishedTaskIdList.Count);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(taskDataList.Count);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0603C24A RID: 246346 RVA: 0x00F40BF8 File Offset: 0x00F3EDF8
		public bool IsAllTaskReceived()
		{
			using (List<FlagChallengeTaskData>.Enumerator enumerator = this.GetTaskDataList().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsTaskReceived())
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0603C24B RID: 246347 RVA: 0x00F40C54 File Offset: 0x00F3EE54
		private void ParseLevelData(IList<FlagChallengeLevelInfo> levels)
		{
			foreach (FlagChallengeLevelInfo level in levels)
			{
				this.UpdateLevelData(level);
			}
			List<FlagChallengeLevelData> levelDataList = this.GetLevelDataList(false);
			for (int i = 0; i < levelDataList.Count; i++)
			{
				levelDataList[i].Index = i + 1;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnFlagChallengeUpdateLevelData);
		}

		// Token: 0x0603C24C RID: 246348 RVA: 0x00F40CD4 File Offset: 0x00F3EED4
		public void UpdateLevelData(FlagChallengeLevelInfo level)
		{
			int id = level.Id;
			FlagChallengeLevelData flagChallengeLevelData;
			if (!this.LevelDataMap.TryGetValue(id, out flagChallengeLevelData))
			{
				flagChallengeLevelData = new FlagChallengeLevelData(id);
				this.LevelDataList.Add(flagChallengeLevelData);
				this.LevelDataMap[id] = flagChallengeLevelData;
			}
			else if (flagChallengeLevelData.IsLocked() && level.State == 1)
			{
				this.SetLevelNewlyUnlocked(id, true);
			}
			flagChallengeLevelData.Refresh(level);
		}

		// Token: 0x0603C24D RID: 246349 RVA: 0x00F40D3C File Offset: 0x00F3EF3C
		[NullableContext(2)]
		public FlagChallengeLevelData GetLevelData(int id)
		{
			FlagChallengeLevelData result;
			this.LevelDataMap.TryGetValue(id, out result);
			return result;
		}

		// Token: 0x0603C24E RID: 246350 RVA: 0x00F40D5C File Offset: 0x00F3EF5C
		public List<FlagChallengeLevelData> GetLevelDataList(bool checkHiddenLevel = false)
		{
			this.LevelDataList.Sort(new Comparison<FlagChallengeLevelData>(this.SortLevelData));
			if (checkHiddenLevel)
			{
				List<FlagChallengeLevelData> list = new List<FlagChallengeLevelData>();
				for (int i = 0; i < this.LevelDataList.Count; i++)
				{
					FlagChallengeLevelData flagChallengeLevelData = this.LevelDataList[i];
					if (!flagChallengeLevelData.IsHidden())
					{
						list.Add(flagChallengeLevelData);
					}
				}
				return list;
			}
			return new List<FlagChallengeLevelData>(this.LevelDataList);
		}

		// Token: 0x0603C24F RID: 246351 RVA: 0x00F40DC8 File Offset: 0x00F3EFC8
		private int SortLevelData(FlagChallengeLevelData a, FlagChallengeLevelData b)
		{
			return a.Id - b.Id;
		}

		// Token: 0x0603C250 RID: 246352 RVA: 0x00F40DD8 File Offset: 0x00F3EFD8
		public bool IsAllLevelPassWithoutHidden()
		{
			foreach (FlagChallengeLevelData flagChallengeLevelData in this.GetLevelDataList(false))
			{
				if (!flagChallengeLevelData.IsHiddenLevel() && !flagChallengeLevelData.IsCompleted())
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603C251 RID: 246353 RVA: 0x00F40E3C File Offset: 0x00F3F03C
		public bool IsAllLevelPass()
		{
			using (List<FlagChallengeLevelData>.Enumerator enumerator = this.GetLevelDataList(false).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsCompleted())
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0603C252 RID: 246354 RVA: 0x00F40E98 File Offset: 0x00F3F098
		private void InitAreaData()
		{
			foreach (FlagChallengeArea flagChallengeArea in (ConfigBase<FlagChallengeConfig>.Instance.GetAreaConfigList() ?? new List<FlagChallengeArea>()))
			{
				int id = flagChallengeArea.Id;
				FlagChallengeAreaData flagChallengeAreaData = new FlagChallengeAreaData(id, this.ActivityId);
				int levelId = flagChallengeAreaData.GetLevelId();
				List<FlagChallengeAreaData> list;
				if (!this.Level2Areas.TryGetValue(levelId, out list))
				{
					list = new List<FlagChallengeAreaData>();
					this.Level2Areas[levelId] = list;
				}
				list.Add(flagChallengeAreaData);
				this.AreaMap[id] = flagChallengeAreaData;
			}
		}

		// Token: 0x0603C253 RID: 246355 RVA: 0x00F40F44 File Offset: 0x00F3F144
		[NullableContext(2)]
		public FlagChallengeAreaData GetAreaData(int areaId)
		{
			FlagChallengeAreaData result;
			this.AreaMap.TryGetValue(areaId, out result);
			return result;
		}

		// Token: 0x0603C254 RID: 246356 RVA: 0x00F40F64 File Offset: 0x00F3F164
		public List<FlagChallengeAreaData> GetLevelAreaDataList(int levelId)
		{
			List<FlagChallengeAreaData> list;
			this.Level2Areas.TryGetValue(levelId, out list);
			return list ?? new List<FlagChallengeAreaData>();
		}

		// Token: 0x0603C255 RID: 246357 RVA: 0x00F40F8C File Offset: 0x00F3F18C
		public bool IsAreaAllBossStrongholdPass(int areaId)
		{
			foreach (FlagChallengeStrongholdData flagChallengeStrongholdData in this.GetAreaStrongholdDataList(areaId))
			{
				if (flagChallengeStrongholdData.IsBossStronghold() && !flagChallengeStrongholdData.IsPass)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603C256 RID: 246358 RVA: 0x00F40FF0 File Offset: 0x00F3F1F0
		private void ParseStrongHoldData(IList<FlagStrongholdInfo> strongholds)
		{
			foreach (FlagStrongholdInfo flagStrongholdInfo in strongholds)
			{
				this.UpdateStrongholdData(ConfigBase<FlagChallengeConfig>.Instance.GetStrongholdConfig(flagStrongholdInfo.Id).Value.ChallengeLevelId, flagStrongholdInfo);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnFlagChallengeUpdateStrongholdData);
		}

		// Token: 0x0603C257 RID: 246359 RVA: 0x00F41068 File Offset: 0x00F3F268
		public void UpdateStrongholdData(int levelId, FlagStrongholdInfo stronghold)
		{
			int id = stronghold.Id;
			FlagChallengeStrongholdData flagChallengeStrongholdData;
			if (!this.StrongholdMap.TryGetValue(id, out flagChallengeStrongholdData))
			{
				flagChallengeStrongholdData = new FlagChallengeStrongholdData(id);
				this.StrongholdMap[id] = flagChallengeStrongholdData;
				this.MarkId2StrongholdId[flagChallengeStrongholdData.StrongholdConfig.MarkId] = id;
				List<FlagChallengeStrongholdData> list;
				if (!this.Level2Strongholds.TryGetValue(levelId, out list))
				{
					list = new List<FlagChallengeStrongholdData>();
					this.Level2Strongholds[levelId] = list;
				}
				list.Add(flagChallengeStrongholdData);
				int areaId = flagChallengeStrongholdData.StrongholdConfig.AreaId;
				List<FlagChallengeStrongholdData> list2;
				if (!this.Area2Strongholds.TryGetValue(areaId, out list2))
				{
					list2 = new List<FlagChallengeStrongholdData>();
					this.Area2Strongholds[areaId] = list2;
				}
				list2.Add(flagChallengeStrongholdData);
			}
			flagChallengeStrongholdData.Refresh(stronghold);
		}

		// Token: 0x0603C258 RID: 246360 RVA: 0x00F41124 File Offset: 0x00F3F324
		[NullableContext(2)]
		public FlagChallengeStrongholdData GetStrongholdData(int strongholdId)
		{
			FlagChallengeStrongholdData result;
			this.StrongholdMap.TryGetValue(strongholdId, out result);
			return result;
		}

		// Token: 0x0603C259 RID: 246361 RVA: 0x00F41144 File Offset: 0x00F3F344
		public List<FlagChallengeStrongholdData> GetLevelStrongholdDataList(int levelId)
		{
			List<FlagChallengeStrongholdData> list;
			this.Level2Strongholds.TryGetValue(levelId, out list);
			return list ?? new List<FlagChallengeStrongholdData>();
		}

		// Token: 0x0603C25A RID: 246362 RVA: 0x00F4116C File Offset: 0x00F3F36C
		public List<FlagChallengeStrongholdData> GetAreaStrongholdDataList(int areaId)
		{
			List<FlagChallengeStrongholdData> list;
			this.Area2Strongholds.TryGetValue(areaId, out list);
			return list ?? new List<FlagChallengeStrongholdData>();
		}

		// Token: 0x0603C25B RID: 246363 RVA: 0x00F41194 File Offset: 0x00F3F394
		[NullableContext(2)]
		public FlagChallengeStrongholdData GetStrongholdDataByMarkId(int markId)
		{
			int strongholdId;
			if (!this.MarkId2StrongholdId.TryGetValue(markId, out strongholdId))
			{
				return null;
			}
			return this.GetStrongholdData(strongholdId);
		}

		// Token: 0x0603C25C RID: 246364 RVA: 0x00F411BC File Offset: 0x00F3F3BC
		public int? GetEasierStrongholdId(int strongholdId)
		{
			FlagChallengeStrongholdData strongholdData = this.GetStrongholdData(strongholdId);
			if (strongholdData == null)
			{
				return null;
			}
			int challengeLevelId = strongholdData.StrongholdConfig.ChallengeLevelId;
			List<FlagChallengeStrongholdData> levelStrongholdDataList = this.GetLevelStrongholdDataList(challengeLevelId);
			int? result = null;
			foreach (FlagChallengeStrongholdData flagChallengeStrongholdData in levelStrongholdDataList)
			{
				if (flagChallengeStrongholdData.StrongholdConfig.MonsterLevel < strongholdData.StrongholdConfig.MonsterLevel && !flagChallengeStrongholdData.IsPass && (result == null || flagChallengeStrongholdData.StrongholdConfig.MonsterLevel < this.GetStrongholdData(result.Value).StrongholdConfig.MonsterLevel))
				{
					result = new int?(flagChallengeStrongholdData.Id);
				}
			}
			return result;
		}

		// Token: 0x0603C25D RID: 246365 RVA: 0x00F41294 File Offset: 0x00F3F494
		private void InitRoleLevelData()
		{
			this.LevelInfo = new FlagChallengeRoleLevelInfo
			{
				Level = 0,
				Exp = 0
			};
		}

		// Token: 0x0603C25E RID: 246366 RVA: 0x00F412AF File Offset: 0x00F3F4AF
		[NullableContext(2)]
		private void ParseRoleLevelData(FlagChallengeRoleLevelInfo roleLevel)
		{
			if (roleLevel == null)
			{
				return;
			}
			this.LevelInfo.Level = roleLevel.PerLevel;
			this.LevelInfo.Exp = roleLevel.PerExp;
		}

		// Token: 0x0603C25F RID: 246367 RVA: 0x00F412D8 File Offset: 0x00F3F4D8
		public void UpdateRoleLevelData(FlagChallengeRoleLevelInfo roleLevel)
		{
			int level = this.LevelInfo.Level;
			int perLevel = roleLevel.PerLevel;
			this.LevelInfo.Level = perLevel;
			this.LevelInfo.Exp = roleLevel.PerExp;
			if (level == perLevel)
			{
				return;
			}
			List<int> buffListByLevelRange = this.GetBuffListByLevelRange(level, perLevel);
			if (buffListByLevelRange != null && buffListByLevelRange.Count > 0)
			{
				this.SetBuffNewlyUnlocked(true);
				foreach (int buffId in buffListByLevelRange)
				{
					this.SetBuffNewlyUnlockedState(buffId, true);
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFlagChallengeBuffNewlyUnlock, this.ActivityId);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnFlagChallengeBattleBuffNewlyUnlock);
			}
		}

		// Token: 0x0603C260 RID: 246368 RVA: 0x00F413A0 File Offset: 0x00F3F5A0
		public int GetFixedLevel()
		{
			return this.LevelInfo.Level;
		}

		// Token: 0x0603C261 RID: 246369 RVA: 0x00F413AD File Offset: 0x00F3F5AD
		public int GetFixedLevelExp()
		{
			return this.LevelInfo.Exp;
		}

		// Token: 0x0603C262 RID: 246370 RVA: 0x00F413BA File Offset: 0x00F3F5BA
		public int GetTempLevel()
		{
			return 0;
		}

		// Token: 0x0603C263 RID: 246371 RVA: 0x00F413BD File Offset: 0x00F3F5BD
		public int GetTempLevelExp()
		{
			return 0;
		}

		// Token: 0x0603C264 RID: 246372 RVA: 0x00F413C0 File Offset: 0x00F3F5C0
		public int GetTotalLevel()
		{
			return this.LevelInfo.Level;
		}

		// Token: 0x0603C265 RID: 246373 RVA: 0x00F413CD File Offset: 0x00F3F5CD
		public int GetTotalLevelExp()
		{
			return this.LevelInfo.Exp;
		}

		// Token: 0x0603C266 RID: 246374 RVA: 0x00F413DC File Offset: 0x00F3F5DC
		private void InitFormationInfo()
		{
			HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.FlagChallengeFormationRoleIds, null);
			if (player != null)
			{
				this.FormationRoleIdSet = player;
			}
		}

		// Token: 0x0603C267 RID: 246375 RVA: 0x00F413FF File Offset: 0x00F3F5FF
		public void SaveFormationInfo(HashSet<int> roleIdSet)
		{
			this.FormationRoleIdSet = new HashSet<int>(roleIdSet);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.FlagChallengeFormationRoleIds, this.FormationRoleIdSet);
		}

		// Token: 0x0603C268 RID: 246376 RVA: 0x00F4141E File Offset: 0x00F3F61E
		public HashSet<int> GetFormationInfo()
		{
			return this.FormationRoleIdSet;
		}

		// Token: 0x0603C269 RID: 246377 RVA: 0x00F41428 File Offset: 0x00F3F628
		private void InitBuffData()
		{
			foreach (FlagChallengeRoleBuff flagChallengeRoleBuff in (ConfigBase<FlagChallengeConfig>.Instance.GetRoleBuffConfigListByActivityId(this.ActivityId) ?? new List<FlagChallengeRoleBuff>()))
			{
				int id = flagChallengeRoleBuff.Id;
				FlagChallengeBuffData flagChallengeBuffData = new FlagChallengeBuffData(id);
				this.BuffDataMap[id] = flagChallengeBuffData;
				this.BuffDataList.Add(flagChallengeBuffData);
			}
			this.BuffDataList.Sort((FlagChallengeBuffData a, FlagChallengeBuffData b) => a.Id - b.Id);
			for (int i = 1; i < this.BuffDataList.Count; i++)
			{
				FlagChallengeBuffData flagChallengeBuffData2 = this.BuffDataList[i];
				FlagChallengeBuffData flagChallengeBuffData3 = this.BuffDataList[i - 1];
				flagChallengeBuffData2.SetStartLevel(flagChallengeBuffData3.GetEndLevel() + 1);
				flagChallengeBuffData2.SetIndex(i);
			}
		}

		// Token: 0x0603C26A RID: 246378 RVA: 0x00F41524 File Offset: 0x00F3F724
		[NullableContext(2)]
		public FlagChallengeBuffData GetBuffData(int id)
		{
			FlagChallengeBuffData result;
			this.BuffDataMap.TryGetValue(id, out result);
			return result;
		}

		// Token: 0x0603C26B RID: 246379 RVA: 0x00F41541 File Offset: 0x00F3F741
		public List<FlagChallengeBuffData> GetBuffDataList()
		{
			return this.BuffDataList;
		}

		// Token: 0x0603C26C RID: 246380 RVA: 0x00F4154C File Offset: 0x00F3F74C
		public FlagChallengeBuffData GetBuffDataByLevel(int level)
		{
			FlagChallengeBuffData flagChallengeBuffData = null;
			foreach (FlagChallengeBuffData flagChallengeBuffData2 in this.BuffDataList)
			{
				if (flagChallengeBuffData2.GetStartLevel() <= level && flagChallengeBuffData2.GetEndLevel() >= level)
				{
					flagChallengeBuffData = flagChallengeBuffData2;
					break;
				}
			}
			if (flagChallengeBuffData == null)
			{
				return this.BuffDataList[this.BuffDataList.Count - 1];
			}
			return flagChallengeBuffData;
		}

		// Token: 0x0603C26D RID: 246381 RVA: 0x00F415D0 File Offset: 0x00F3F7D0
		private List<int> GetBuffListByLevelRange(int oldLevel, int newLevel)
		{
			List<int> list = new List<int>();
			foreach (FlagChallengeBuffData flagChallengeBuffData in this.BuffDataList)
			{
				if (flagChallengeBuffData.GetEndLevel() > oldLevel && flagChallengeBuffData.GetEndLevel() <= newLevel)
				{
					list.Add(flagChallengeBuffData.Id);
				}
			}
			return list;
		}

		// Token: 0x0603C26E RID: 246382 RVA: 0x00F41644 File Offset: 0x00F3F844
		public void CheckBuffStatusChange(int oldLevel, int newLevel)
		{
			List<FlagChallengeBuffActiveTipsInfo> buffActiveTipsInfoListByLv = this.GetBuffActiveTipsInfoListByLv(oldLevel, newLevel);
			if (buffActiveTipsInfoListByLv.Count <= 0)
			{
				return;
			}
			this.BuffActiveTipsList.AddRange(buffActiveTipsInfoListByLv);
			EUiViewName flagChallengeBuffActiveTips = EUiViewName.FlagChallengeBuffActiveTips;
			if (Singleton<UiManager>.Instance.IsViewOpen(flagChallengeBuffActiveTips))
			{
				return;
			}
			ControllerBase<FlagChallengeController>.Instance.OpenBuffActiveTipsView(this.ActivityId);
		}

		// Token: 0x0603C26F RID: 246383 RVA: 0x00F41694 File Offset: 0x00F3F894
		public List<FlagChallengeBuffActiveTipsInfo> GetBuffActiveTipsInfoListByLv(int oldLevel, int newLevel)
		{
			if (oldLevel >= newLevel)
			{
				return new List<FlagChallengeBuffActiveTipsInfo>();
			}
			List<FlagChallengeBuffActiveTipsInfo> list = new List<FlagChallengeBuffActiveTipsInfo>();
			foreach (FlagChallengeBuffData flagChallengeBuffData in this.GetBuffDataList())
			{
				if (oldLevel < flagChallengeBuffData.GetEndLevel())
				{
					if (newLevel < flagChallengeBuffData.GetEndLevel())
					{
						break;
					}
					list.Add(new FlagChallengeBuffActiveTipsInfo
					{
						BuffId = flagChallengeBuffData.Id,
						State = flagChallengeBuffData.GetBuffStatus()
					});
				}
			}
			return list;
		}

		// Token: 0x0603C270 RID: 246384 RVA: 0x00F41728 File Offset: 0x00F3F928
		public List<FlagChallengeBuffActiveTipsInfo> GetBuffActiveTipsList()
		{
			return this.BuffActiveTipsList;
		}

		// Token: 0x0603C271 RID: 246385 RVA: 0x00F41730 File Offset: 0x00F3F930
		public void ClearBuffActiveTipsList()
		{
			this.BuffActiveTipsList.Clear();
		}

		// Token: 0x0603C272 RID: 246386 RVA: 0x00F4173D File Offset: 0x00F3F93D
		private ServerStorageSet GetNewlyUnlockedLevelIds()
		{
			return ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FlagChallengeNewlyUnlockedLevelIds) as ServerStorageSet;
		}

		// Token: 0x0603C273 RID: 246387 RVA: 0x00F41750 File Offset: 0x00F3F950
		public bool HasLevelNewlyUnlocked()
		{
			return this.GetNewlyUnlockedLevelIds().Size() > 0;
		}

		// Token: 0x0603C274 RID: 246388 RVA: 0x00F41760 File Offset: 0x00F3F960
		public bool IsLevelNewlyUnlocked(int levelId)
		{
			return this.GetNewlyUnlockedLevelIds().Has(levelId);
		}

		// Token: 0x0603C275 RID: 246389 RVA: 0x00F41770 File Offset: 0x00F3F970
		public void SetLevelNewlyUnlocked(int levelId, bool value)
		{
			ServerStorageSet newlyUnlockedLevelIds = this.GetNewlyUnlockedLevelIds();
			if (!value)
			{
				if (!newlyUnlockedLevelIds.Has(levelId))
				{
					return;
				}
				newlyUnlockedLevelIds.Remove(levelId);
			}
			else
			{
				newlyUnlockedLevelIds.Add(levelId);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFlagChallengeLevelNewlyUnlock, levelId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFlagChallengeTaskUpdate, this.ActivityId);
		}

		// Token: 0x0603C276 RID: 246390 RVA: 0x00F417C8 File Offset: 0x00F3F9C8
		public bool HasBuffNewlyUnlocked()
		{
			return (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FlagChallengeNewlyUnlockedBuff) as ServerStorageBoolean).Get().GetValueOrDefault();
		}

		// Token: 0x0603C277 RID: 246391 RVA: 0x00F417F4 File Offset: 0x00F3F9F4
		public void SetBuffNewlyUnlocked(bool value)
		{
			ServerStorageBoolean serverStorageBoolean = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FlagChallengeNewlyUnlockedBuff) as ServerStorageBoolean;
			if (serverStorageBoolean.Get().GetValueOrDefault() == value)
			{
				return;
			}
			serverStorageBoolean.Set(new bool?(value));
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFlagChallengeBuffNewlyUnlock, this.ActivityId);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnFlagChallengeBattleBuffNewlyUnlock);
		}

		// Token: 0x0603C278 RID: 246392 RVA: 0x00F41857 File Offset: 0x00F3FA57
		public ServerStorageSet GetNewlyUnlockedBuffIds()
		{
			return ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FlagChallengeNewlyUnlockedBuffIds) as ServerStorageSet;
		}

		// Token: 0x0603C279 RID: 246393 RVA: 0x00F4186A File Offset: 0x00F3FA6A
		public bool IsBuffNewlyUnlocked(int buffId)
		{
			return this.GetNewlyUnlockedBuffIds().Has(buffId);
		}

		// Token: 0x0603C27A RID: 246394 RVA: 0x00F41878 File Offset: 0x00F3FA78
		public void SetBuffNewlyUnlockedState(int buffId, bool value)
		{
			ServerStorageSet newlyUnlockedBuffIds = this.GetNewlyUnlockedBuffIds();
			if (!value)
			{
				if (!newlyUnlockedBuffIds.Has(buffId))
				{
					return;
				}
				newlyUnlockedBuffIds.Remove(buffId);
			}
			else
			{
				newlyUnlockedBuffIds.Add(buffId);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFlagChallengeBuffNewlyUnlockHintChanged, buffId);
		}

		// Token: 0x0603C27B RID: 246395 RVA: 0x00F418BA File Offset: 0x00F3FABA
		public void ClearBuffNewlyUnlocked()
		{
			this.GetNewlyUnlockedBuffIds().Overwrite(new HashSet<int>());
		}

		// Token: 0x04021C11 RID: 138257
		private readonly List<FlagChallengeTaskData> TaskDataList = new List<FlagChallengeTaskData>();

		// Token: 0x04021C12 RID: 138258
		private readonly List<FlagChallengeLevelData> LevelDataList = new List<FlagChallengeLevelData>();

		// Token: 0x04021C13 RID: 138259
		private readonly Dictionary<int, FlagChallengeLevelData> LevelDataMap = new Dictionary<int, FlagChallengeLevelData>();

		// Token: 0x04021C14 RID: 138260
		private FlagChallengeRoleLevelInfo LevelInfo;

		// Token: 0x04021C15 RID: 138261
		private bool IsInited;

		// Token: 0x04021C16 RID: 138262
		private int ActivityIdIntl;

		// Token: 0x04021C17 RID: 138263
		private HashSet<int> FormationRoleIdSet = new HashSet<int>();

		// Token: 0x04021C18 RID: 138264
		private readonly List<FlagChallengeBuffData> BuffDataList = new List<FlagChallengeBuffData>();

		// Token: 0x04021C19 RID: 138265
		private readonly Dictionary<int, FlagChallengeBuffData> BuffDataMap = new Dictionary<int, FlagChallengeBuffData>();

		// Token: 0x04021C1A RID: 138266
		private readonly List<FlagChallengeBuffActiveTipsInfo> BuffActiveTipsList = new List<FlagChallengeBuffActiveTipsInfo>();

		// Token: 0x04021C1B RID: 138267
		private readonly Dictionary<int, List<FlagChallengeStrongholdData>> Level2Strongholds = new Dictionary<int, List<FlagChallengeStrongholdData>>();

		// Token: 0x04021C1C RID: 138268
		private readonly Dictionary<int, FlagChallengeStrongholdData> StrongholdMap = new Dictionary<int, FlagChallengeStrongholdData>();

		// Token: 0x04021C1D RID: 138269
		private readonly Dictionary<int, List<FlagChallengeAreaData>> Level2Areas = new Dictionary<int, List<FlagChallengeAreaData>>();

		// Token: 0x04021C1E RID: 138270
		private readonly Dictionary<int, FlagChallengeAreaData> AreaMap = new Dictionary<int, FlagChallengeAreaData>();

		// Token: 0x04021C1F RID: 138271
		private readonly Dictionary<int, List<FlagChallengeStrongholdData>> Area2Strongholds = new Dictionary<int, List<FlagChallengeStrongholdData>>();

		// Token: 0x04021C20 RID: 138272
		private readonly Dictionary<int, int> MarkId2StrongholdId = new Dictionary<int, int>();

		// Token: 0x04021C21 RID: 138273
		private int? MainViewSelectLevelId;
	}
}
