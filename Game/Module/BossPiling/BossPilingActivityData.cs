using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EDE RID: 24286
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingActivityData : ActivityBaseData
	{
		// Token: 0x0603D056 RID: 249942 RVA: 0x00F7FBAC File Offset: 0x00F7DDAC
		protected override void OnInit(ActivityData data)
		{
			BossPilingActivityInfo bossPilingActivityInfo = data.BossPilingActivityInfo;
			if (bossPilingActivityInfo == null)
			{
				return;
			}
			this.UpdateTaskData(bossPilingActivityInfo.ConditionTasks.ToArray<ConditionTask>());
			this.UpdateLevelData(bossPilingActivityInfo.BossPilingLevelInfos.ToArray<BossPilingLevelInfo>());
			if (ControllerBase<BossPilingController>.Instance.CacheBuffMap != null)
			{
				this.CurLevelId = ControllerBase<BossPilingController>.Instance.CacheLevelId;
				ControllerBase<BossPilingController>.Instance.CacheLevelId = 0;
				this.CurBuffMap = ControllerBase<BossPilingController>.Instance.CacheBuffMap;
				ControllerBase<BossPilingController>.Instance.CacheBuffMap = null;
			}
		}

		// Token: 0x0603D057 RID: 249943 RVA: 0x00F7FC28 File Offset: 0x00F7DE28
		protected override void PhraseEx(ActivityData data)
		{
			BossPilingActivityInfo bossPilingActivityInfo = data.BossPilingActivityInfo;
			if (bossPilingActivityInfo == null)
			{
				return;
			}
			this.UpdateTaskData(bossPilingActivityInfo.ConditionTasks.ToArray<ConditionTask>());
			this.UpdateLevelData(bossPilingActivityInfo.BossPilingLevelInfos.ToArray<BossPilingLevelInfo>());
		}

		// Token: 0x170099F1 RID: 39409
		// (get) Token: 0x0603D058 RID: 249944 RVA: 0x00F7FC62 File Offset: 0x00F7DE62
		public override bool RedPointShowState
		{
			get
			{
				return this.CheckIfInShowTime() && (base.GetIfFirstOpen() || this.CheckTaskRedDot() || this.CheckLevelRedDot());
			}
		}

		// Token: 0x0603D059 RID: 249945 RVA: 0x00F7FC88 File Offset: 0x00F7DE88
		protected override bool GetExDataFinishShowState()
		{
			foreach (KeyValuePair<int, BossPilingTaskInfo> keyValuePair in this.TaskMap)
			{
				int num;
				BossPilingTaskInfo bossPilingTaskInfo;
				keyValuePair.Deconstruct(out num, out bossPilingTaskInfo);
				if (bossPilingTaskInfo.Status != ConditionTaskState.ConditionTaskTaken)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603D05A RID: 249946 RVA: 0x00F7FCF4 File Offset: 0x00F7DEF4
		public void UpdateTaskData(ConditionTask[] tasks)
		{
			foreach (ConditionTask conditionTask in tasks)
			{
				if (this.TaskMap.ContainsKey(conditionTask.Id))
				{
					BossPilingTaskInfo bossPilingTaskInfo = this.TaskMap[conditionTask.Id];
					bossPilingTaskInfo.Current = conditionTask.Current;
					bossPilingTaskInfo.Target = conditionTask.Target;
					bossPilingTaskInfo.Status = conditionTask.Status;
				}
				else
				{
					BossPilingTaskInfo bossPilingTaskInfo2 = new BossPilingTaskInfo
					{
						Id = conditionTask.Id,
						Current = conditionTask.Current,
						Target = conditionTask.Target,
						Status = conditionTask.Status
					};
					this.TaskMap[conditionTask.Id] = bossPilingTaskInfo2;
					int belongLevel = ConfigBase<BossPilingConfig>.Instance.GetTaskInfo(conditionTask.Id).Value.BelongLevel;
					if (!this.TaskLevelGroup.ContainsKey(belongLevel))
					{
						this.TaskLevelGroup[belongLevel] = new HashSet<BossPilingTaskInfo>();
					}
					this.TaskLevelGroup[belongLevel].Add(bossPilingTaskInfo2);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnBossPilingReward);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603D05B RID: 249947 RVA: 0x00F7FE2E File Offset: 0x00F7E02E
		public List<BossPilingTaskInfo> GetBaseTaskGroupByLevel(int levelId)
		{
			return new List<BossPilingTaskInfo>(this.TaskLevelGroup.GetValueOrDefault(levelId) ?? new HashSet<BossPilingTaskInfo>());
		}

		// Token: 0x0603D05C RID: 249948 RVA: 0x00F7FE4C File Offset: 0x00F7E04C
		public List<ActivityRewardData> GetTaskGroupByLevel(int levelId)
		{
			List<BossPilingTaskInfo> list = new List<BossPilingTaskInfo>(this.TaskLevelGroup.GetValueOrDefault(levelId) ?? new HashSet<BossPilingTaskInfo>());
			list.Sort(new Comparison<BossPilingTaskInfo>(this.TaskGroupSort));
			List<ActivityRewardData> list2 = new List<ActivityRewardData>();
			Action <>9__0;
			foreach (BossPilingTaskInfo bossPilingTaskInfo in list)
			{
				BossPilingTask value = ConfigBase<BossPilingConfig>.Instance.GetTaskInfo(bossPilingTaskInfo.Id).Value;
				List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(value.DropId);
				BossPilingLevelInfo levelInfo = this.GetLevelInfo(value.BelongLevel);
				ActivityRewardData activityRewardData = new ActivityRewardData();
				activityRewardData.Id = new int?(bossPilingTaskInfo.Id);
				activityRewardData.NameText = "";
				activityRewardData.NameTextId = "BossPilingActivity_Reward08";
				activityRewardData.RewardList = dropPackagePreviewItemList.ToArray();
				activityRewardData.NameTextArgs = new string[]
				{
					Math.Min(value.RewardCount, levelInfo.BossHp).ToString(),
					value.RewardCount.ToString()
				};
				activityRewardData.RewardState = BossPilingDefine.BossPilingTaskStateToRewardStateResolver[bossPilingTaskInfo.Status];
				activityRewardData.RewardButtonTextId = BossPilingDefine.BossPilingTaskStateToRewardText[bossPilingTaskInfo.Status];
				activityRewardData.RewardButtonRedDot = new bool?(bossPilingTaskInfo.Status == ConditionTaskState.ConditionTaskFinish);
				ActivityRewardData activityRewardData2 = activityRewardData;
				Action clickFunction;
				if ((clickFunction = <>9__0) == null)
				{
					clickFunction = (<>9__0 = delegate()
					{
						ControllerBase<BossPilingController>.Instance.RequestBossPilingReward(levelId);
					});
				}
				activityRewardData2.ClickFunction = clickFunction;
				ActivityRewardData item = activityRewardData;
				list2.Add(item);
			}
			return list2;
		}

		// Token: 0x0603D05D RID: 249949 RVA: 0x00F8001C File Offset: 0x00F7E21C
		public List<int> GetTaskTabList()
		{
			List<int> list = new List<int>(this.TaskLevelGroup.Keys);
			list.Sort((int a, int b) => a - b);
			return list;
		}

		// Token: 0x0603D05E RID: 249950 RVA: 0x00F80054 File Offset: 0x00F7E254
		private int TaskGroupSort(BossPilingTaskInfo a, BossPilingTaskInfo b)
		{
			if (a.Status == b.Status)
			{
				return a.Id - b.Id;
			}
			int num = (a.Status == ConditionTaskState.ConditionTaskTaken) ? 2 : ((a.Status != ConditionTaskState.ConditionTaskFinish) ? 1 : 0);
			int num2 = (b.Status == ConditionTaskState.ConditionTaskTaken) ? 2 : ((b.Status != ConditionTaskState.ConditionTaskFinish) ? 1 : 0);
			return num - num2;
		}

		// Token: 0x0603D05F RID: 249951 RVA: 0x00F800B0 File Offset: 0x00F7E2B0
		public bool CheckLevelTaskRedDot(int levelId)
		{
			HashSet<BossPilingTaskInfo> valueOrDefault = this.TaskLevelGroup.GetValueOrDefault(levelId);
			if (valueOrDefault == null)
			{
				return false;
			}
			using (HashSet<BossPilingTaskInfo>.Enumerator enumerator = valueOrDefault.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == ConditionTaskState.ConditionTaskFinish)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603D060 RID: 249952 RVA: 0x00F80118 File Offset: 0x00F7E318
		public List<int> GetTaskNumState()
		{
			int num = 0;
			foreach (KeyValuePair<int, BossPilingTaskInfo> keyValuePair in this.TaskMap)
			{
				int num2;
				BossPilingTaskInfo bossPilingTaskInfo;
				keyValuePair.Deconstruct(out num2, out bossPilingTaskInfo);
				BossPilingTaskInfo bossPilingTaskInfo2 = bossPilingTaskInfo;
				num += ((bossPilingTaskInfo2.Status == ConditionTaskState.ConditionTaskTaken) ? 1 : 0);
			}
			return new List<int>
			{
				num,
				this.TaskMap.Count
			};
		}

		// Token: 0x0603D061 RID: 249953 RVA: 0x00F801A0 File Offset: 0x00F7E3A0
		public bool CheckTaskRedDot()
		{
			foreach (KeyValuePair<int, BossPilingTaskInfo> keyValuePair in this.TaskMap)
			{
				int num;
				BossPilingTaskInfo bossPilingTaskInfo;
				keyValuePair.Deconstruct(out num, out bossPilingTaskInfo);
				if (bossPilingTaskInfo.Status == ConditionTaskState.ConditionTaskFinish)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603D062 RID: 249954 RVA: 0x00F8020C File Offset: 0x00F7E40C
		public void UpdateLevelData(BossPilingLevelInfo[] levels)
		{
			foreach (BossPilingLevelInfo bossPilingLevelInfo in levels)
			{
				if (this.LevelMap.ContainsKey(bossPilingLevelInfo.Id))
				{
					BossPilingLevelInfo bossPilingLevelInfo2 = this.LevelMap[bossPilingLevelInfo.Id];
					bossPilingLevelInfo2.BossHp = bossPilingLevelInfo.BossHpNum;
					bossPilingLevelInfo2.UnlockTime = this.GetUnlockTime(bossPilingLevelInfo.UnlockTime);
					bossPilingLevelInfo2.SelectedRoleIds.Clear();
					bossPilingLevelInfo2.SelectedRoleIds.AddRange(bossPilingLevelInfo.SelectRoleIds);
					bossPilingLevelInfo2.SelectedTagBranchIds.Clear();
					bossPilingLevelInfo2.SelectedTagBranchIds.AddRange(bossPilingLevelInfo.SkillBranchId);
					bossPilingLevelInfo2.IsUnlock = this.CheckTimeIsUnlock(bossPilingLevelInfo2.UnlockTime);
				}
				else
				{
					BossPilingLevelInfo value = new BossPilingLevelInfo
					{
						Id = bossPilingLevelInfo.Id,
						BossHp = bossPilingLevelInfo.BossHpNum,
						UnlockTime = this.GetUnlockTime(bossPilingLevelInfo.UnlockTime),
						SelectedRoleIds = bossPilingLevelInfo.SelectRoleIds.ToList<int>(),
						SelectedTagBranchIds = bossPilingLevelInfo.SkillBranchId.ToList<int>(),
						IsUnlock = this.CheckTimeIsUnlock(this.GetUnlockTime(bossPilingLevelInfo.UnlockTime))
					};
					this.LevelMap[bossPilingLevelInfo.Id] = value;
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603D063 RID: 249955 RVA: 0x00F80356 File Offset: 0x00F7E556
		public List<BossPilingLevelInfo> GetAllLevelInfo()
		{
			List<BossPilingLevelInfo> list = new List<BossPilingLevelInfo>(this.LevelMap.Values);
			list.Sort((BossPilingLevelInfo a, BossPilingLevelInfo b) => a.Id - b.Id);
			return list;
		}

		// Token: 0x0603D064 RID: 249956 RVA: 0x00F80390 File Offset: 0x00F7E590
		public List<int> GetStarAchievement(int level)
		{
			BossPilingLevels? levelInfo = ConfigBase<BossPilingConfig>.Instance.GetLevelInfo(level);
			BossPilingLevelInfo valueOrDefault = this.LevelMap.GetValueOrDefault(level);
			if (levelInfo == null || valueOrDefault == null)
			{
				return new List<int>
				{
					0,
					0
				};
			}
			int num = 0;
			using (IEnumerator<int> enumerator = levelInfo.Value.AchievementIter().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current <= valueOrDefault.BossHp)
					{
						num++;
					}
				}
			}
			return new List<int>
			{
				num,
				levelInfo.Value.Achievement().Length
			};
		}

		// Token: 0x0603D065 RID: 249957 RVA: 0x00F8044C File Offset: 0x00F7E64C
		public void RefreshUnlockState()
		{
			foreach (KeyValuePair<int, BossPilingLevelInfo> keyValuePair in this.LevelMap)
			{
				int num;
				BossPilingLevelInfo bossPilingLevelInfo;
				keyValuePair.Deconstruct(out num, out bossPilingLevelInfo);
				BossPilingLevelInfo bossPilingLevelInfo2 = bossPilingLevelInfo;
				bossPilingLevelInfo2.IsUnlock = this.CheckTimeIsUnlock(bossPilingLevelInfo2.UnlockTime);
			}
		}

		// Token: 0x0603D066 RID: 249958 RVA: 0x00F804B8 File Offset: 0x00F7E6B8
		public int GetFirstSelectLevel()
		{
			int num = 0;
			foreach (KeyValuePair<int, BossPilingLevelInfo> keyValuePair in this.LevelMap)
			{
				int num2;
				BossPilingLevelInfo bossPilingLevelInfo;
				keyValuePair.Deconstruct(out num2, out bossPilingLevelInfo);
				int num3 = num2;
				if (bossPilingLevelInfo.IsUnlock)
				{
					List<int> starAchievement = this.GetStarAchievement(num3);
					int num4 = starAchievement[0];
					int num5 = starAchievement[1];
					if (num4 < num5 && (num == 0 || num > num3))
					{
						num = num3;
					}
				}
			}
			if (num == 0)
			{
				foreach (KeyValuePair<int, BossPilingLevelInfo> keyValuePair in this.LevelMap)
				{
					int num2;
					BossPilingLevelInfo bossPilingLevelInfo;
					keyValuePair.Deconstruct(out num2, out bossPilingLevelInfo);
					int num6 = num2;
					if (bossPilingLevelInfo.IsUnlock)
					{
						num = num6;
						break;
					}
				}
			}
			return num;
		}

		// Token: 0x0603D067 RID: 249959 RVA: 0x00F805A0 File Offset: 0x00F7E7A0
		public BossPilingLevelInfo GetLevelInfo(int id)
		{
			return this.LevelMap[id];
		}

		// Token: 0x0603D068 RID: 249960 RVA: 0x00F805AE File Offset: 0x00F7E7AE
		private int GetUnlockTime(long time)
		{
			return (int)((double)time * Singleton<TimeUtil>.Instance.Millisecond);
		}

		// Token: 0x0603D069 RID: 249961 RVA: 0x00F805BE File Offset: 0x00F7E7BE
		private bool CheckTimeIsUnlock(int time)
		{
			return (double)time <= Singleton<TimeUtil>.Instance.GetServerTime();
		}

		// Token: 0x0603D06A RID: 249962 RVA: 0x00F805D1 File Offset: 0x00F7E7D1
		public void ClearDungeonInfo()
		{
			this.CurLevelId = 0;
			this.CurBuffMap.Clear();
			ModelBase<BossPilingModel>.Instance.InstKeyBuffList.Clear();
		}

		// Token: 0x0603D06B RID: 249963 RVA: 0x00F805F4 File Offset: 0x00F7E7F4
		public void InitDungeon(int levelId, Dictionary<int, int> buffInfo)
		{
			this.CurLevelId = levelId;
			this.CurBuffMap.Clear();
			ModelBase<BossPilingModel>.Instance.InstKeyBuffList.Clear();
			foreach (int key in buffInfo.Keys)
			{
				int value = buffInfo[key];
				this.CurBuffMap[key] = value;
			}
		}

		// Token: 0x0603D06C RID: 249964 RVA: 0x00F80678 File Offset: 0x00F7E878
		public void UpdateDungeonBuff(Dictionary<int, int> buffInfo)
		{
			foreach (int num in buffInfo.Keys)
			{
				int num2 = buffInfo[num];
				int oldValue;
				this.CurBuffMap.TryGetValue(num, out oldValue);
				BossPilingNewBuffInfo param = new BossPilingNewBuffInfo
				{
					BuffId = num,
					OldValue = oldValue,
					NewValue = num2,
					NeedAccelerate = (buffInfo.Count > 1)
				};
				ModelBase<BossPilingModel>.Instance.InstBuffAcquireCount++;
				Singleton<UiManager>.Instance.OpenView(EUiViewName.BossPilingNewBuffTipsView, param, null);
				this.CurBuffMap[num] = num2;
			}
		}

		// Token: 0x0603D06D RID: 249965 RVA: 0x00F8073C File Offset: 0x00F7E93C
		public Dictionary<int, int> GetDungeonBuff()
		{
			return this.CurBuffMap;
		}

		// Token: 0x0603D06E RID: 249966 RVA: 0x00F80744 File Offset: 0x00F7E944
		public bool CheckLevelRedDot()
		{
			if (!base.GetPreGuideQuestFinishState())
			{
				return base.IsUnLock() && !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.BossPilingQuestClicked, false);
			}
			foreach (KeyValuePair<int, BossPilingLevelInfo> keyValuePair in this.LevelMap)
			{
				int num;
				BossPilingLevelInfo bossPilingLevelInfo;
				keyValuePair.Deconstruct(out num, out bossPilingLevelInfo);
				int levelId = num;
				if (this.CheckLevelRedDotById(levelId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603D06F RID: 249967 RVA: 0x00F807D0 File Offset: 0x00F7E9D0
		public bool CheckLevelRedDotById(int levelId)
		{
			BossPilingLevelInfo bossPilingLevelInfo;
			this.LevelMap.TryGetValue(levelId, out bossPilingLevelInfo);
			return bossPilingLevelInfo != null && bossPilingLevelInfo.BossHp <= 0 && bossPilingLevelInfo.IsUnlock && !(LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.BossPilingLevelNew, null) ?? new HashSet<int>()).Contains(levelId);
		}

		// Token: 0x0603D070 RID: 249968 RVA: 0x00F80820 File Offset: 0x00F7EA20
		public void ClearLevelRedDotById(int levelId)
		{
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.BossPilingLevelNew, null) ?? new HashSet<int>();
			hashSet.Add(levelId);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.BossPilingLevelNew, hashSet);
		}

		// Token: 0x0603D071 RID: 249969 RVA: 0x00F80858 File Offset: 0x00F7EA58
		public void ClearLevelRedDot()
		{
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.BossPilingLevelNew, null) ?? new HashSet<int>();
			foreach (KeyValuePair<int, BossPilingLevelInfo> keyValuePair in this.LevelMap)
			{
				int num;
				BossPilingLevelInfo bossPilingLevelInfo;
				keyValuePair.Deconstruct(out num, out bossPilingLevelInfo);
				int item = num;
				if (bossPilingLevelInfo.IsUnlock)
				{
					hashSet.Add(item);
				}
			}
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.BossPilingLevelNew, hashSet);
		}

		// Token: 0x040223DE RID: 140254
		protected Dictionary<int, BossPilingTaskInfo> TaskMap = new Dictionary<int, BossPilingTaskInfo>();

		// Token: 0x040223DF RID: 140255
		protected Dictionary<int, HashSet<BossPilingTaskInfo>> TaskLevelGroup = new Dictionary<int, HashSet<BossPilingTaskInfo>>();

		// Token: 0x040223E0 RID: 140256
		protected Dictionary<int, BossPilingLevelInfo> LevelMap = new Dictionary<int, BossPilingLevelInfo>();

		// Token: 0x040223E1 RID: 140257
		protected int CurLevelId;

		// Token: 0x040223E2 RID: 140258
		protected Dictionary<int, int> CurBuffMap = new Dictionary<int, int>();
	}
}
