using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D41 RID: 23873
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class FlagChallengeModel : ModelBase<FlagChallengeModel>
	{
		// Token: 0x0603C306 RID: 246534 RVA: 0x00F439F0 File Offset: 0x00F41BF0
		public void ParseActivityData(int activityId, FlagChallengeActivityInfo activityData)
		{
			FlagChallengeData flagChallengeData;
			if (!this.FlagChallengeDataMap.TryGetValue(activityId, out flagChallengeData))
			{
				flagChallengeData = new FlagChallengeData();
				flagChallengeData.ActivityId = activityId;
				this.FlagChallengeDataMap[activityId] = flagChallengeData;
			}
			flagChallengeData.ParseActivityData(activityData);
			this.UpdateTeleportData(activityData.UnlockTeleporterId);
		}

		// Token: 0x0603C307 RID: 246535 RVA: 0x00F43A3C File Offset: 0x00F41C3C
		[NullableContext(2)]
		public FlagChallengeData GetFlagChallengeData(int activityId)
		{
			FlagChallengeData result;
			this.FlagChallengeDataMap.TryGetValue(activityId, out result);
			return result;
		}

		// Token: 0x0603C308 RID: 246536 RVA: 0x00F43A5C File Offset: 0x00F41C5C
		public void UpdateTaskData(IList<ConditionTask> tasks)
		{
			foreach (ConditionTask conditionTask in tasks)
			{
				FlagChallengeData flagChallengeData = this.GetFlagChallengeData(ConfigBase<FlagChallengeConfig>.Instance.GetTaskConfig(conditionTask.Id).Value.ActivityId);
				if (flagChallengeData != null)
				{
					flagChallengeData.UpdateTaskData(conditionTask);
				}
			}
		}

		// Token: 0x0603C309 RID: 246537 RVA: 0x00F43AD0 File Offset: 0x00F41CD0
		public void UpdateLevelData(IList<FlagChallengeLevelInfo> levels)
		{
			foreach (FlagChallengeLevelInfo flagChallengeLevelInfo in levels)
			{
				FlagChallengeData flagChallengeData = this.GetFlagChallengeData(ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(flagChallengeLevelInfo.Id).Value.ActivityId);
				if (flagChallengeData != null)
				{
					flagChallengeData.UpdateLevelData(flagChallengeLevelInfo);
				}
			}
		}

		// Token: 0x0603C30A RID: 246538 RVA: 0x00F43B44 File Offset: 0x00F41D44
		public void UpdateStrongholdData(IList<FlagStrongholdInfo> strongholds)
		{
			foreach (FlagStrongholdInfo flagStrongholdInfo in strongholds)
			{
				FlagStronghold? strongholdConfig = ConfigBase<FlagChallengeConfig>.Instance.GetStrongholdConfig(flagStrongholdInfo.Id);
				FlagChallengeLevel? levelConfig = ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(strongholdConfig.Value.ChallengeLevelId);
				FlagChallengeData flagChallengeData = this.GetFlagChallengeData(levelConfig.Value.ActivityId);
				if (flagChallengeData != null)
				{
					flagChallengeData.UpdateStrongholdData(levelConfig.Value.Id, flagStrongholdInfo);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnFlagChallengeUpdateStrongholdData);
		}

		// Token: 0x0603C30B RID: 246539 RVA: 0x00F43BF4 File Offset: 0x00F41DF4
		[NullableContext(2)]
		public FlagChallengeStrongholdData GetStrongholdData(int strongholdId)
		{
			FlagStronghold? strongholdConfig = ConfigBase<FlagChallengeConfig>.Instance.GetStrongholdConfig(strongholdId);
			FlagChallengeData flagChallengeData = this.GetFlagChallengeData(ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(strongholdConfig.Value.ChallengeLevelId).Value.ActivityId);
			if (flagChallengeData == null)
			{
				return null;
			}
			return flagChallengeData.GetStrongholdData(strongholdId);
		}

		// Token: 0x0603C30C RID: 246540 RVA: 0x00F43C48 File Offset: 0x00F41E48
		public void UpdateRoleLevelData(int activityId, FlagChallengeRoleLevelInfo roleLevel)
		{
			this.GetFlagChallengeData(activityId).UpdateRoleLevelData(roleLevel);
		}

		// Token: 0x0603C30D RID: 246541 RVA: 0x00F43C57 File Offset: 0x00F41E57
		public bool CheckActivityTabRedoDotState(int activityId)
		{
			return this.HasCanReceiveTask(activityId) || this.HasNewUnlockLevel(activityId);
		}

		// Token: 0x0603C30E RID: 246542 RVA: 0x00F43C6C File Offset: 0x00F41E6C
		public bool HasCanReceiveTask(int activityId)
		{
			FlagChallengeData flagChallengeData = this.GetFlagChallengeData(activityId);
			return flagChallengeData != null && flagChallengeData.HasCanReceiveTask();
		}

		// Token: 0x0603C30F RID: 246543 RVA: 0x00F43C8C File Offset: 0x00F41E8C
		public void SaveFormationInfo(int activityId, HashSet<int> roleIdSet)
		{
			FlagChallengeData flagChallengeData = this.GetFlagChallengeData(activityId);
			if (flagChallengeData == null)
			{
				return;
			}
			flagChallengeData.SaveFormationInfo(roleIdSet);
		}

		// Token: 0x0603C310 RID: 246544 RVA: 0x00F43CA0 File Offset: 0x00F41EA0
		public bool HasNewUnlockLevel(int activityId)
		{
			FlagChallengeData flagChallengeData = this.GetFlagChallengeData(activityId);
			return flagChallengeData != null && flagChallengeData.HasLevelNewlyUnlocked();
		}

		// Token: 0x0603C311 RID: 246545 RVA: 0x00F43CC0 File Offset: 0x00F41EC0
		public EFlagChallengeLevelDiffType GetLevelDiffType(int activityId, int compareLevel, int? playerLevel = null)
		{
			int num = (playerLevel ?? this.GetFixedLevel(activityId)) - compareLevel;
			IReadOnlyList<FlagChallengeLevelDiffShow> levelDiffShowConfigList = ConfigBase<FlagChallengeConfig>.Instance.GetLevelDiffShowConfigList();
			EFlagChallengeLevelDiffType eflagChallengeLevelDiffType = EFlagChallengeLevelDiffType.Easy;
			if (levelDiffShowConfigList == null)
			{
				return eflagChallengeLevelDiffType;
			}
			foreach (FlagChallengeLevelDiffShow flagChallengeLevelDiffShow in levelDiffShowConfigList)
			{
				if (num >= flagChallengeLevelDiffShow.LevelDiffLower && num < flagChallengeLevelDiffShow.LevelDiffUpper)
				{
					eflagChallengeLevelDiffType = (EFlagChallengeLevelDiffType)flagChallengeLevelDiffShow.LevelPattern;
					if (eflagChallengeLevelDiffType > EFlagChallengeLevelDiffType.Hard)
					{
						eflagChallengeLevelDiffType = EFlagChallengeLevelDiffType.Hard;
						break;
					}
					if (eflagChallengeLevelDiffType < EFlagChallengeLevelDiffType.Easy)
					{
						eflagChallengeLevelDiffType = EFlagChallengeLevelDiffType.Easy;
						break;
					}
					break;
				}
			}
			return eflagChallengeLevelDiffType;
		}

		// Token: 0x0603C312 RID: 246546 RVA: 0x00F43D64 File Offset: 0x00F41F64
		[NullableContext(2)]
		public int GetLevelRecommendStrongholdId(int activityId, int levelId, int[] preferAreaIds = null)
		{
			FlagChallengeData flagChallengeData = this.GetFlagChallengeData(activityId);
			if (preferAreaIds != null)
			{
				foreach (int areaId in preferAreaIds)
				{
					if (!flagChallengeData.IsAreaAllBossStrongholdPass(areaId))
					{
						return this.GetAreaRecommendStrongholdId(activityId, areaId);
					}
				}
			}
			List<FlagChallengeAreaData> levelAreaDataList = flagChallengeData.GetLevelAreaDataList(levelId);
			int count = levelAreaDataList.Count;
			for (int j = 0; j < levelAreaDataList.Count; j++)
			{
				FlagChallengeAreaData flagChallengeAreaData = levelAreaDataList[j];
				if (!flagChallengeData.IsAreaAllBossStrongholdPass(flagChallengeAreaData.Id) || j == count - 1)
				{
					return this.GetAreaRecommendStrongholdId(activityId, flagChallengeAreaData.Id);
				}
			}
			return flagChallengeData.GetLevelStrongholdDataList(levelId)[0].Id;
		}

		// Token: 0x0603C313 RID: 246547 RVA: 0x00F43E10 File Offset: 0x00F42010
		public int GetAreaRecommendStrongholdId(int activityId, int areaId)
		{
			List<FlagChallengeStrongholdData> areaStrongholdDataList = this.GetFlagChallengeData(activityId).GetAreaStrongholdDataList(areaId);
			bool flag = false;
			int? num = null;
			foreach (FlagChallengeStrongholdData flagChallengeStrongholdData in areaStrongholdDataList)
			{
				if (!flagChallengeStrongholdData.IsBossStronghold())
				{
					if (!flagChallengeStrongholdData.IsPass)
					{
						if (flagChallengeStrongholdData.IsUnlocked())
						{
							return flagChallengeStrongholdData.Id;
						}
						flag = true;
					}
					else
					{
						num = new int?(flagChallengeStrongholdData.Id);
					}
				}
			}
			if (flag && num != null)
			{
				return num.Value;
			}
			foreach (FlagChallengeStrongholdData flagChallengeStrongholdData2 in areaStrongholdDataList)
			{
				if (flagChallengeStrongholdData2.IsBossStronghold())
				{
					if (!flagChallengeStrongholdData2.IsPass)
					{
						if (flagChallengeStrongholdData2.IsUnlocked())
						{
							return flagChallengeStrongholdData2.Id;
						}
					}
					else
					{
						num = new int?(flagChallengeStrongholdData2.Id);
					}
				}
			}
			if (num != null)
			{
				return num.Value;
			}
			return areaStrongholdDataList[0].Id;
		}

		// Token: 0x0603C314 RID: 246548 RVA: 0x00F43F48 File Offset: 0x00F42148
		public int? GetRecommendLevel(int activityId, bool fallbackToDefault = true)
		{
			List<FlagChallengeLevelData> levelDataList = this.GetFlagChallengeData(activityId).GetLevelDataList(false);
			FlagChallengeLevelData flagChallengeLevelData = null;
			foreach (FlagChallengeLevelData flagChallengeLevelData2 in levelDataList)
			{
				if (flagChallengeLevelData2.IsUnlocked())
				{
					return new int?(flagChallengeLevelData2.Id);
				}
				if (flagChallengeLevelData2.IsCompleted())
				{
					flagChallengeLevelData = flagChallengeLevelData2;
				}
			}
			if (fallbackToDefault)
			{
				return new int?((flagChallengeLevelData != null) ? flagChallengeLevelData.Id : levelDataList[0].Id);
			}
			return null;
		}

		// Token: 0x0603C315 RID: 246549 RVA: 0x00F43FF0 File Offset: 0x00F421F0
		public int GetFixedLevel(int activityId)
		{
			if (ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon)
			{
				return ModelBase<FlagChallengeBattleModel>.Instance.GetFixedLevel();
			}
			return this.GetFlagChallengeData(activityId).GetFixedLevel();
		}

		// Token: 0x0603C316 RID: 246550 RVA: 0x00F44015 File Offset: 0x00F42215
		public int GetFixedLevelExp(int activityId)
		{
			if (ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon)
			{
				return ModelBase<FlagChallengeBattleModel>.Instance.GetFixedLevelExp();
			}
			return this.GetFlagChallengeData(activityId).GetFixedLevelExp();
		}

		// Token: 0x0603C317 RID: 246551 RVA: 0x00F4403A File Offset: 0x00F4223A
		public int GetCalculatedLevel(int activityId)
		{
			if (ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon)
			{
				return ModelBase<FlagChallengeBattleModel>.Instance.GetCalculatedLevel();
			}
			return this.GetFlagChallengeData(activityId).GetFixedLevel();
		}

		// Token: 0x0603C318 RID: 246552 RVA: 0x00F4405F File Offset: 0x00F4225F
		public int GetCalculatedLevelExp(int activityId)
		{
			if (ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon)
			{
				return ModelBase<FlagChallengeBattleModel>.Instance.GetCalculatedLevelExp();
			}
			return this.GetFlagChallengeData(activityId).GetFixedLevelExp();
		}

		// Token: 0x0603C319 RID: 246553 RVA: 0x00F44084 File Offset: 0x00F42284
		public int GetTempLevel(int activityId)
		{
			if (ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon)
			{
				return ModelBase<FlagChallengeBattleModel>.Instance.GetTempLevel();
			}
			return this.GetFlagChallengeData(activityId).GetTempLevel();
		}

		// Token: 0x0603C31A RID: 246554 RVA: 0x00F440A9 File Offset: 0x00F422A9
		public int GetTempLevelExp(int activityId)
		{
			if (ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon)
			{
				return ModelBase<FlagChallengeBattleModel>.Instance.GetTempLevelExp();
			}
			return this.GetFlagChallengeData(activityId).GetTempLevelExp();
		}

		// Token: 0x0603C31B RID: 246555 RVA: 0x00F440CE File Offset: 0x00F422CE
		public int GetTotalLevel(int activityId)
		{
			if (ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon)
			{
				return ModelBase<FlagChallengeBattleModel>.Instance.GetTotalLevel();
			}
			return this.GetFlagChallengeData(activityId).GetTotalLevel();
		}

		// Token: 0x0603C31C RID: 246556 RVA: 0x00F440F3 File Offset: 0x00F422F3
		public int GetTotalLevelExp(int activityId)
		{
			if (ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon)
			{
				return ModelBase<FlagChallengeBattleModel>.Instance.GetTotalLevelExp();
			}
			return this.GetFlagChallengeData(activityId).GetTotalLevelExp();
		}

		// Token: 0x0603C31D RID: 246557 RVA: 0x00F44118 File Offset: 0x00F42318
		public int GetLevelExp(int activityId, int level)
		{
			Dictionary<int, int> dictionary;
			if (!this.LevelExpCache.TryGetValue(activityId, out dictionary))
			{
				dictionary = new Dictionary<int, int>();
				this.LevelExpCache[activityId] = dictionary;
			}
			int result;
			if (dictionary.TryGetValue(level, out result))
			{
				return result;
			}
			FlagChallengeRoleLevel? roleLevelConfigByActivityIdAndLevel = ConfigBase<FlagChallengeConfig>.Instance.GetRoleLevelConfigByActivityIdAndLevel(activityId, level);
			dictionary[level] = roleLevelConfigByActivityIdAndLevel.Value.Experience;
			return roleLevelConfigByActivityIdAndLevel.Value.Experience;
		}

		// Token: 0x0603C31E RID: 246558 RVA: 0x00F44188 File Offset: 0x00F42388
		public int GetMaxLevel(int activityId)
		{
			int num;
			if (!this.MaxLevelCache.TryGetValue(activityId, out num))
			{
				num = ConfigBase<FlagChallengeConfig>.Instance.GetRoleLevelConfigListByActivityId(activityId).Count - 1;
				this.MaxLevelCache[activityId] = num;
			}
			return num;
		}

		// Token: 0x0603C31F RID: 246559 RVA: 0x00F441C8 File Offset: 0x00F423C8
		public int GetMaxLevelExp(int activityId)
		{
			int experience;
			if (!this.MaxLevelExpCache.TryGetValue(activityId, out experience))
			{
				int maxLevel = this.GetMaxLevel(activityId);
				experience = ConfigBase<FlagChallengeConfig>.Instance.GetRoleLevelConfigByActivityIdAndLevel(activityId, maxLevel).Value.Experience;
				this.MaxLevelExpCache[activityId] = experience;
			}
			return experience;
		}

		// Token: 0x0603C320 RID: 246560 RVA: 0x00F44218 File Offset: 0x00F42418
		public int GetTargetLevelUpExp(int activityId, int? targetLevel = null)
		{
			int num = targetLevel ?? this.GetFixedLevel(activityId);
			int maxLevel = this.GetMaxLevel(activityId);
			if (num >= maxLevel)
			{
				num = maxLevel - 1;
			}
			int levelExp = this.GetLevelExp(activityId, num);
			int levelExp2 = this.GetLevelExp(activityId, num + 1);
			return Math.Max(0, levelExp2 - levelExp);
		}

		// Token: 0x0603C321 RID: 246561 RVA: 0x00F44270 File Offset: 0x00F42470
		public int GetTargetLevelExp(int activityId, int? targetLevel = null, int? targetLevelExp = null)
		{
			int num = targetLevel ?? this.GetFixedLevel(activityId);
			int num2 = targetLevelExp ?? this.GetFixedLevelExp(activityId);
			if (num == 1 || num == 0)
			{
				return num2;
			}
			if (num == this.GetMaxLevel(activityId))
			{
				return this.GetTargetLevelUpExp(activityId, new int?(num));
			}
			int levelExp = this.GetLevelExp(activityId, num);
			return Math.Max(0, num2 - levelExp);
		}

		// Token: 0x0603C322 RID: 246562 RVA: 0x00F442E8 File Offset: 0x00F424E8
		public float GetTargetLevelExpProgress(int activityId, int? targetLevel = null, int? targetLevelExp = null)
		{
			int num = targetLevel ?? this.GetFixedLevel(activityId);
			if (num == this.GetMaxLevel(activityId))
			{
				return 1f;
			}
			int targetLevelExp2 = this.GetTargetLevelExp(activityId, targetLevel, targetLevelExp);
			int targetLevelUpExp = this.GetTargetLevelUpExp(activityId, new int?(num));
			if (targetLevelUpExp != 0)
			{
				return (float)targetLevelExp2 / (float)targetLevelUpExp;
			}
			return 0f;
		}

		// Token: 0x0603C323 RID: 246563 RVA: 0x00F44347 File Offset: 0x00F42547
		public bool IsReachTargetLevel(int activityId, int targetLv)
		{
			return this.GetTotalLevel(activityId) >= targetLv;
		}

		// Token: 0x0603C324 RID: 246564 RVA: 0x00F44358 File Offset: 0x00F42558
		public void UpdateTeleportData(IList<int> teleportIds)
		{
			foreach (int item in teleportIds)
			{
				this.UnlockedTeleportId.Add(item);
			}
		}

		// Token: 0x0603C325 RID: 246565 RVA: 0x00F443A8 File Offset: 0x00F425A8
		public bool IsTeleportUnlock(int teleportId)
		{
			return this.UnlockedTeleportId.Contains(teleportId);
		}

		// Token: 0x0603C326 RID: 246566 RVA: 0x00F443B8 File Offset: 0x00F425B8
		public List<FlagChallengeBuffAddItemData> GetAllRoleAttrAddList(int activityId)
		{
			int totalLevel = this.GetTotalLevel(activityId);
			IReadOnlyList<FlagChallengeRoleGrowth> roleGrowthConfigListByActivityId = ConfigBase<FlagChallengeConfig>.Instance.GetRoleGrowthConfigListByActivityId(activityId);
			if (roleGrowthConfigListByActivityId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "未找到角色成长配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", activityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return new List<FlagChallengeBuffAddItemData>();
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < roleGrowthConfigListByActivityId.Count; i++)
			{
				FlagChallengeRoleGrowth flagChallengeRoleGrowth = roleGrowthConfigListByActivityId[i];
				if (totalLevel <= flagChallengeRoleGrowth.Level)
				{
					break;
				}
				FlagChallengeRoleGrowth? flagChallengeRoleGrowth2 = (i + 1 < roleGrowthConfigListByActivityId.Count) ? new FlagChallengeRoleGrowth?(roleGrowthConfigListByActivityId[i + 1]) : null;
				int num4 = (flagChallengeRoleGrowth2 != null) ? (Math.Min(totalLevel, flagChallengeRoleGrowth2.Value.Level) - flagChallengeRoleGrowth.Level) : (totalLevel - flagChallengeRoleGrowth.Level);
				num += flagChallengeRoleGrowth.LifeMaxRatio * num4;
				num2 += flagChallengeRoleGrowth.AtkRatio * num4;
				num3 += flagChallengeRoleGrowth.DefRatio * num4;
			}
			IReadOnlyList<int> allAttrAddIdList = ConfigBase<FlagChallengeConfig>.Instance.GetAllAttrAddIdList();
			List<int> list = new List<int>
			{
				num,
				num2,
				num3
			};
			List<FlagChallengeBuffAddItemData> list2 = new List<FlagChallengeBuffAddItemData>();
			for (int j = 0; j < list.Count; j++)
			{
				int num5 = list[j];
				int id = allAttrAddIdList[j];
				PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(id);
				List<FlagChallengeBuffAddItemData> list3 = list2;
				FlagChallengeBuffAddItemData flagChallengeBuffAddItemData = new FlagChallengeBuffAddItemData();
				flagChallengeBuffAddItemData.IconPath = (((propertyIndexInfo != null) ? propertyIndexInfo.GetValueOrDefault().Icon : null) ?? "");
				flagChallengeBuffAddItemData.NameKey = (((propertyIndexInfo != null) ? propertyIndexInfo.GetValueOrDefault().Name : null) ?? "");
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num5 / 100);
				defaultInterpolatedStringHandler.AppendLiteral("%");
				flagChallengeBuffAddItemData.Value = defaultInterpolatedStringHandler.ToStringAndClear();
				list3.Add(flagChallengeBuffAddItemData);
			}
			return list2;
		}

		// Token: 0x0603C327 RID: 246567 RVA: 0x00F445E0 File Offset: 0x00F427E0
		public unsafe string GetAllRoleAttrAddDesc(int activityId)
		{
			IReadOnlyList<FlagChallengeRoleGrowth> roleGrowthConfigListByActivityId = ConfigBase<FlagChallengeConfig>.Instance.GetRoleGrowthConfigListByActivityId(activityId);
			if (roleGrowthConfigListByActivityId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "未找到角色成长配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", activityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return "";
			}
			int num = this.GetTotalLevel(activityId) + 1;
			FlagChallengeRoleGrowth? flagChallengeRoleGrowth = null;
			for (int i = roleGrowthConfigListByActivityId.Count - 1; i >= 0; i--)
			{
				FlagChallengeRoleGrowth value = roleGrowthConfigListByActivityId[i];
				if (num > value.Level)
				{
					flagChallengeRoleGrowth = new FlagChallengeRoleGrowth?(value);
					break;
				}
			}
			if (flagChallengeRoleGrowth == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.FlagChallenge;
				ELogAuthor author2 = ELogAuthor.LJS;
				string message2 = "未找到角色成长等级区间";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActivityId", activityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Level", num);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return "";
			}
			int value2 = flagChallengeRoleGrowth.Value.LifeMaxRatio / 100;
			int value3 = flagChallengeRoleGrowth.Value.AtkRatio / 100;
			int value4 = flagChallengeRoleGrowth.Value.DefRatio / 100;
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Morale_32_Buff_KeepLevel", null);
			string[] array = new string[3];
			int num2 = 0;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value3);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			array[num2] = defaultInterpolatedStringHandler.ToStringAndClear();
			int num3 = 1;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			array[num3] = defaultInterpolatedStringHandler.ToStringAndClear();
			int num4 = 2;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value4);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			array[num4] = defaultInterpolatedStringHandler.ToStringAndClear();
			return StringUtils.Format(localTextNew, array);
		}

		// Token: 0x04021CBB RID: 138427
		private readonly Dictionary<int, FlagChallengeData> FlagChallengeDataMap = new Dictionary<int, FlagChallengeData>();

		// Token: 0x04021CBC RID: 138428
		private readonly Dictionary<int, Dictionary<int, int>> LevelExpCache = new Dictionary<int, Dictionary<int, int>>();

		// Token: 0x04021CBD RID: 138429
		private readonly Dictionary<int, int> MaxLevelCache = new Dictionary<int, int>();

		// Token: 0x04021CBE RID: 138430
		private readonly Dictionary<int, int> MaxLevelExpCache = new Dictionary<int, int>();

		// Token: 0x04021CBF RID: 138431
		private readonly HashSet<int> UnlockedTeleportId = new HashSet<int>();
	}
}
