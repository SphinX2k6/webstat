using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x02006484 RID: 25732
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityRoadBookData : ActivityBaseData
	{
		// Token: 0x060408D6 RID: 264406 RVA: 0x0108BD7C File Offset: 0x01089F7C
		protected override void OnInit(ActivityData data)
		{
			this.InitTravelLevelData();
			this.InitTravelAreaData();
			this.InitPhantomData();
			this.InitMotorChallengeData();
			RoadBookActivityInfo roadBookActivityInfo = data.RoadBookActivityInfo;
			if (roadBookActivityInfo == null)
			{
				return;
			}
			this.TravelLevel = roadBookActivityInfo.RoadBookLevel;
			this.LastTravelLevelInternal = roadBookActivityInfo.RoadBookLevel;
			this.LastCurrentExpCountInternal = this.GetCurrentExp();
			this.LastExpCountInternal = this.GetExpItemCount();
		}

		// Token: 0x060408D7 RID: 264407 RVA: 0x0108BDDC File Offset: 0x01089FDC
		protected override void PhraseEx(ActivityData data)
		{
			RoadBookActivityInfo roadBookActivityInfo = data.RoadBookActivityInfo;
			if (roadBookActivityInfo == null)
			{
				return;
			}
			this.RefreshRoadBookData(roadBookActivityInfo);
		}

		// Token: 0x060408D8 RID: 264408 RVA: 0x0108BDFC File Offset: 0x01089FFC
		protected void RefreshRoadBookData(RoadBookActivityInfo roadBookInfo)
		{
			this.TravelLevel = roadBookInfo.RoadBookLevel;
			for (int i = 0; i < roadBookInfo.UnLockAreas.Count; i++)
			{
				this.UnlockAreaData(roadBookInfo.UnLockAreas[i]);
			}
			for (int j = 0; j < roadBookInfo.ActivityTasks.Count; j++)
			{
				ConditionTask task = roadBookInfo.ActivityTasks[j];
				this.RefreshTravelTaskData(task);
			}
			this.TaskFinalRewardData.IsReceived = roadBookInfo.GetFullReward;
			for (int k = 0; k < roadBookInfo.MonsterGain.Count; k++)
			{
				this.UnlockPhantom(roadBookInfo.MonsterGain[k]);
			}
			for (int l = 0; l < roadBookInfo.SoarLevels.Count; l++)
			{
				RoadBookMotorcycleInfo challengeInfo = roadBookInfo.SoarLevels[l];
				this.RefreshMotorChallengePlayData(challengeInfo);
			}
		}

		// Token: 0x060408D9 RID: 264409 RVA: 0x0108BED1 File Offset: 0x0108A0D1
		public override bool GetExDataRedPointShowState()
		{
			return this.CanTravelLevelUp() || this.GetTaskRedDotState(true) || this.GetAllMotorItemRedDot();
		}

		// Token: 0x060408DA RID: 264410 RVA: 0x0108BEF4 File Offset: 0x0108A0F4
		protected override bool GetExDataFinishShowState()
		{
			if (this.MaxTravelLevel != this.TravelLevel)
			{
				return false;
			}
			if (this.TaskFinalRewardData != null && !this.TaskFinalRewardData.IsReceived)
			{
				return false;
			}
			using (Dictionary<int, global::ActivityTaskData>.ValueCollection.Enumerator enumerator = this.AreaTaskMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status != EActivityTaskState.FinishedAndClaimed)
					{
						return false;
					}
				}
			}
			using (Dictionary<int, global::ActivityTaskData>.ValueCollection.Enumerator enumerator = this.MotorChallengeRewardDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status != EActivityTaskState.FinishedAndClaimed)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060408DB RID: 264411 RVA: 0x0108BFC8 File Offset: 0x0108A1C8
		public bool SaveFirstCheckRedDotState(ERoadBookSaveFlag saveFlag, int id = 0)
		{
			if (ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, (int)saveFlag, id, 0) == 1)
			{
				return true;
			}
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, (int)saveFlag, id, 0, 1);
			this.RefreshActivityRedDotState();
			return false;
		}

		// Token: 0x060408DC RID: 264412 RVA: 0x0108C000 File Offset: 0x0108A200
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"current",
			"total"
		})]
		public ValueTuple<int, int> GetTypeProgress(ERoadBookSubType subType)
		{
			int num = 0;
			int item = 1;
			switch (subType)
			{
			case ERoadBookSubType.TravelTask:
				num = this.GetFinishedAreaTaskCount();
				item = this.AreaTaskMap.Count;
				break;
			case ERoadBookSubType.PhantomCollect:
				using (Dictionary<int, bool>.ValueCollection.Enumerator enumerator = this.PhantomDataMap.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current)
						{
							num++;
						}
					}
				}
				item = this.PhantomDataMap.Count;
				break;
			case ERoadBookSubType.MotorChallenge:
				using (Dictionary<int, global::ActivityTaskData>.ValueCollection.Enumerator enumerator2 = this.MotorChallengeRewardDataMap.Values.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.Status == EActivityTaskState.FinishedAndClaimed)
						{
							num++;
						}
					}
				}
				item = this.MotorChallengeRewardDataMap.Count;
				break;
			}
			return new ValueTuple<int, int>(num, item);
		}

		// Token: 0x060408DD RID: 264413 RVA: 0x0108C0FC File Offset: 0x0108A2FC
		public bool GetTypeRedDotState(ERoadBookSubType subType)
		{
			if (subType != ERoadBookSubType.TravelTask)
			{
				return subType == ERoadBookSubType.MotorChallenge && this.GetAllMotorItemRedDot();
			}
			return this.GetTaskRedDotState(false);
		}

		// Token: 0x060408DE RID: 264414 RVA: 0x0108C118 File Offset: 0x0108A318
		public bool GetTypeNewState(ERoadBookSubType subType)
		{
			switch (subType)
			{
			case ERoadBookSubType.TravelTask:
				return this.GetAllAreaNewUnlockState();
			case ERoadBookSubType.PhantomCollect:
				return this.GetAllPhantomNewUnlockState();
			case ERoadBookSubType.MotorChallenge:
				return this.RefreshAndGetAllMotorItemNewUnlock();
			}
			return false;
		}

		// Token: 0x060408DF RID: 264415 RVA: 0x0108C14A File Offset: 0x0108A34A
		public void RefreshActivityRedDotState()
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x060408E0 RID: 264416 RVA: 0x0108C164 File Offset: 0x0108A364
		public RoadBookConfig GetActivityConfig()
		{
			return ConfigBase<ActivityRoadBookConfig>.Instance.GetActivityConfig(base.Id).Value;
		}

		// Token: 0x060408E1 RID: 264417 RVA: 0x0108C189 File Offset: 0x0108A389
		private Comparison<global::ActivityTaskData> SortTaskData()
		{
			return delegate(global::ActivityTaskData a, global::ActivityTaskData b)
			{
				if (a.Status == b.Status)
				{
					return a.Id - b.Id;
				}
				return a.Status - b.Status;
			};
		}

		// Token: 0x17009E50 RID: 40528
		// (get) Token: 0x060408E2 RID: 264418 RVA: 0x0108C1AA File Offset: 0x0108A3AA
		public int LastTravelLevel
		{
			get
			{
				int lastTravelLevelInternal = this.LastTravelLevelInternal;
				this.LastTravelLevelInternal = this.TravelLevel;
				return lastTravelLevelInternal;
			}
		}

		// Token: 0x17009E51 RID: 40529
		// (get) Token: 0x060408E3 RID: 264419 RVA: 0x0108C1BE File Offset: 0x0108A3BE
		public int LastCurrentExpCount
		{
			get
			{
				int lastCurrentExpCountInternal = this.LastCurrentExpCountInternal;
				this.LastCurrentExpCountInternal = this.GetCurrentExp();
				return lastCurrentExpCountInternal;
			}
		}

		// Token: 0x17009E52 RID: 40530
		// (get) Token: 0x060408E4 RID: 264420 RVA: 0x0108C1D2 File Offset: 0x0108A3D2
		public int LastExpCount
		{
			get
			{
				int lastExpCountInternal = this.LastExpCountInternal;
				this.LastExpCountInternal = this.GetExpItemCount();
				return lastExpCountInternal;
			}
		}

		// Token: 0x17009E53 RID: 40531
		// (get) Token: 0x060408E5 RID: 264421 RVA: 0x0108C1E8 File Offset: 0x0108A3E8
		public int MaxTravelLevel
		{
			get
			{
				return this.GetActivityConfig().MaxLevel;
			}
		}

		// Token: 0x060408E6 RID: 264422 RVA: 0x0108C204 File Offset: 0x0108A404
		private void InitTravelLevelData()
		{
			this.TravelLevelData.Clear();
			IEnumerable<RoadBookLevelExp> allLevelExpConfig = ConfigBase<ActivityRoadBookConfig>.Instance.GetAllLevelExpConfig(base.Id);
			int num = 0;
			foreach (RoadBookLevelExp roadBookLevelExp in allLevelExpConfig)
			{
				RoadBookLevelData value = new RoadBookLevelData
				{
					Id = roadBookLevelExp.Id,
					Level = roadBookLevelExp.Level,
					AccumulateExp = num,
					TargetExp = roadBookLevelExp.NeedExp
				};
				this.TravelLevelData[roadBookLevelExp.Level] = value;
				num += roadBookLevelExp.NeedExp;
			}
		}

		// Token: 0x060408E7 RID: 264423 RVA: 0x0108C2B4 File Offset: 0x0108A4B4
		public int GetExpItemCount()
		{
			int expItemId = this.GetActivityConfig().ExpItemId;
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(expItemId, 0);
		}

		// Token: 0x060408E8 RID: 264424 RVA: 0x0108C2DC File Offset: 0x0108A4DC
		public int GetCurrentExp()
		{
			int expItemCount = this.GetExpItemCount();
			int accumulateExp = this.TravelLevelData[this.TravelLevel].AccumulateExp;
			return expItemCount - accumulateExp;
		}

		// Token: 0x060408E9 RID: 264425 RVA: 0x0108C308 File Offset: 0x0108A508
		public int GetCurrentTargetExp()
		{
			bool flag = this.MaxTravelLevel == this.TravelLevel;
			IRoadBookLevelData roadBookLevelData = this.TravelLevelData[this.TravelLevel];
			if (!flag)
			{
				return roadBookLevelData.TargetExp;
			}
			return roadBookLevelData.AccumulateExp;
		}

		// Token: 0x060408EA RID: 264426 RVA: 0x0108C344 File Offset: 0x0108A544
		public bool CanTravelLevelUp()
		{
			if (this.MaxTravelLevel == this.TravelLevel)
			{
				return false;
			}
			int expItemCount = this.GetExpItemCount();
			IRoadBookLevelData roadBookLevelData = this.TravelLevelData[this.TravelLevel];
			int num = roadBookLevelData.AccumulateExp + roadBookLevelData.TargetExp;
			return expItemCount >= num;
		}

		// Token: 0x060408EB RID: 264427 RVA: 0x0108C390 File Offset: 0x0108A590
		private void InitTravelAreaData()
		{
			this.AreaDataMap.Clear();
			this.TaskFinalRewardData = new FinalTravelTaskData();
			IReadOnlyList<RoadBookTask> allRoadBookTaskConfig = ConfigBase<ActivityRoadBookConfig>.Instance.GetAllRoadBookTaskConfig(base.Id);
			this.TaskFinalRewardData.Target = allRoadBookTaskConfig.Count;
			foreach (RoadBookArea roadBookArea in ConfigBase<ActivityRoadBookConfig>.Instance.GetAllAreaConfig(base.Id))
			{
				RoadBookAreaData value = new RoadBookAreaData(roadBookArea.Id);
				this.AreaDataMap[roadBookArea.Id] = value;
			}
		}

		// Token: 0x060408EC RID: 264428 RVA: 0x0108C438 File Offset: 0x0108A638
		public void UnlockAreaData(int areaId)
		{
			RoadBookAreaData roadBookAreaData;
			if (!this.AreaDataMap.TryGetValue(areaId, out roadBookAreaData))
			{
				return;
			}
			roadBookAreaData.IsUnlock = true;
		}

		// Token: 0x060408ED RID: 264429 RVA: 0x0108C45D File Offset: 0x0108A65D
		public List<RoadBookAreaData> GetAllAreaData()
		{
			List<RoadBookAreaData> list = new List<RoadBookAreaData>(this.AreaDataMap.Values);
			list.Sort(delegate(RoadBookAreaData a, RoadBookAreaData b)
			{
				RoadBookArea value = ConfigBase<ActivityRoadBookConfig>.Instance.GetAreaConfig(a.AreaId).Value;
				RoadBookArea value2 = ConfigBase<ActivityRoadBookConfig>.Instance.GetAreaConfig(b.AreaId).Value;
				if (value.Sort == value2.Sort)
				{
					return a.AreaId - b.AreaId;
				}
				return value.Sort - value2.Sort;
			});
			return list;
		}

		// Token: 0x060408EE RID: 264430 RVA: 0x0108C494 File Offset: 0x0108A694
		public bool GetAllAreaNewUnlockState()
		{
			foreach (int areaId in this.AreaDataMap.Keys)
			{
				if (this.GetAreaNewUnlockState(areaId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060408EF RID: 264431 RVA: 0x0108C4F8 File Offset: 0x0108A6F8
		public void RefreshTravelTaskData(ConditionTask task)
		{
			global::ActivityTaskData activityTaskData;
			if (!this.AreaTaskMap.TryGetValue(task.Id, out activityTaskData))
			{
				activityTaskData = new global::ActivityTaskData();
				RoadBookTask value = ConfigBase<ActivityRoadBookConfig>.Instance.GetRoadBookTaskConfig(task.Id).Value;
				this.AreaDataMap[value.AreaId].TravelTaskIdSet.Add(task.Id);
				this.AreaTaskMap[task.Id] = activityTaskData;
			}
			activityTaskData.Refresh(task, delegate(bool isChanged, EActivityTaskState former, EActivityTaskState after)
			{
				if (!isChanged)
				{
					return;
				}
				if (after == EActivityTaskState.FinishedAndClaimed)
				{
					this.TaskFinalRewardData.FinishedIdSet.Add(task.Id);
				}
			});
		}

		// Token: 0x060408F0 RID: 264432 RVA: 0x0108C5AE File Offset: 0x0108A7AE
		public void SetTravelTaskDataDone(int taskId)
		{
			this.AreaTaskMap[taskId].Status = EActivityTaskState.FinishedAndClaimed;
			this.TaskFinalRewardData.FinishedIdSet.Add(taskId);
		}

		// Token: 0x060408F1 RID: 264433 RVA: 0x0108C5D4 File Offset: 0x0108A7D4
		public bool IsAreaTaskFinish(int areaId)
		{
			foreach (int key in this.AreaDataMap[areaId].TravelTaskIdSet)
			{
				if (this.AreaTaskMap[key].Status != EActivityTaskState.FinishedAndClaimed)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060408F2 RID: 264434 RVA: 0x0108C648 File Offset: 0x0108A848
		public int GetFinishedAreaTaskCount()
		{
			int num = 0;
			using (Dictionary<int, global::ActivityTaskData>.ValueCollection.Enumerator enumerator = this.AreaTaskMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == EActivityTaskState.FinishedAndClaimed)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x060408F3 RID: 264435 RVA: 0x0108C6A8 File Offset: 0x0108A8A8
		public List<global::ActivityTaskData> GetAreaTaskDataList(int areaId)
		{
			List<global::ActivityTaskData> list = new List<global::ActivityTaskData>();
			foreach (int key in this.AreaDataMap[areaId].TravelTaskIdSet)
			{
				global::ActivityTaskData item = this.AreaTaskMap[key];
				list.Add(item);
			}
			list.Sort(this.SortTaskData());
			return list;
		}

		// Token: 0x060408F4 RID: 264436 RVA: 0x0108C728 File Offset: 0x0108A928
		public bool GetAreaNewUnlockState(int areaId)
		{
			bool isUnlock = this.AreaDataMap[areaId].IsUnlock;
			bool flag = this.AreaDataMap[areaId].TravelTaskIdSet.Count > 0;
			bool flag2 = this.IsAreaTaskFinish(areaId);
			return isUnlock && !flag2 && flag && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 5, areaId, 0) == 0;
		}

		// Token: 0x060408F5 RID: 264437 RVA: 0x0108C790 File Offset: 0x0108A990
		public bool GetAreaRewardState(int areaId)
		{
			RoadBookAreaData roadBookAreaData = this.AreaDataMap[areaId];
			if (!roadBookAreaData.IsUnlock)
			{
				return false;
			}
			foreach (int key in roadBookAreaData.TravelTaskIdSet)
			{
				if (this.AreaTaskMap[key].Status == EActivityTaskState.FinishedAndUnclaimed)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060408F6 RID: 264438 RVA: 0x0108C810 File Offset: 0x0108AA10
		public bool GetTaskRedDotState(bool checkAreaUnlock = false)
		{
			if (this.TaskFinalRewardData != null && this.TaskFinalRewardData.CanReceive())
			{
				return true;
			}
			foreach (int areaId in this.AreaDataMap.Keys)
			{
				if (checkAreaUnlock && this.GetAreaNewUnlockState(areaId))
				{
					return true;
				}
				if (this.GetAreaRewardState(areaId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060408F7 RID: 264439 RVA: 0x0108C898 File Offset: 0x0108AA98
		private void InitPhantomData()
		{
			this.PhantomDataMap.Clear();
			foreach (RoadBookPhantomGain roadBookPhantomGain in ConfigBase<ActivityRoadBookConfig>.Instance.GetAllPhantomConfig(base.Id))
			{
				this.PhantomDataMap[roadBookPhantomGain.Id] = false;
			}
		}

		// Token: 0x060408F8 RID: 264440 RVA: 0x0108C908 File Offset: 0x0108AB08
		public void UnlockPhantom(int phantomId)
		{
			this.PhantomDataMap[phantomId] = true;
		}

		// Token: 0x060408F9 RID: 264441 RVA: 0x0108C918 File Offset: 0x0108AB18
		public bool GetAllPhantomNewUnlockState()
		{
			foreach (KeyValuePair<int, bool> keyValuePair in this.PhantomDataMap)
			{
				if (keyValuePair.Value && this.GetPhantomNewUnlockState(keyValuePair.Key))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060408FA RID: 264442 RVA: 0x0108C984 File Offset: 0x0108AB84
		public bool GetPhantomNewUnlockState(int phantomId)
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 4, phantomId, 0) == 0;
		}

		// Token: 0x060408FB RID: 264443 RVA: 0x0108C9A0 File Offset: 0x0108ABA0
		private void InitMotorChallengeData()
		{
			this.MotorChallengeRewardDataMap.Clear();
			int num = 0;
			foreach (MotorcycleChallenge motorcycleChallenge in ConfigBase<ActivityRoadBookConfig>.Instance.GetAllMotorChallengeConfig())
			{
				global::ActivityTaskData activityTaskData = new global::ActivityTaskData();
				activityTaskData.Id = motorcycleChallenge.Id;
				activityTaskData.Target = motorcycleChallenge.NeedScore;
				this.MotorChallengeRewardDataMap[motorcycleChallenge.Id] = activityTaskData;
				MotorChallengePlayData motorChallengePlayData;
				if (!this.MotorChallengePlayDataMap.TryGetValue(motorcycleChallenge.LevelPlayId, out motorChallengePlayData))
				{
					motorChallengePlayData = new MotorChallengePlayData();
					motorChallengePlayData.TabIndex = num;
					motorChallengePlayData.PlayId = motorcycleChallenge.LevelPlayId;
					motorChallengePlayData.NameTextId = motorcycleChallenge.Name;
					motorChallengePlayData.CheckRedDot = new Func<int[], bool>(this.CheckMotorItemRedDot);
					motorChallengePlayData.CheckFinished = new Func<int[], bool>(this.CheckMotorItemFinished);
					motorChallengePlayData.JumpId = motorcycleChallenge.JumpId;
					motorChallengePlayData.ClassId = motorcycleChallenge.ClassificationId;
					this.MotorChallengePlayDataMap[motorcycleChallenge.LevelPlayId] = motorChallengePlayData;
					num++;
				}
				motorChallengePlayData.RewardIds.Add(motorcycleChallenge.Id);
			}
		}

		// Token: 0x060408FC RID: 264444 RVA: 0x0108CAE4 File Offset: 0x0108ACE4
		public void RefreshMotorChallengePlayData(RoadBookMotorcycleInfo challengeInfo)
		{
			MotorChallengePlayData motorChallengePlayData;
			if (!this.MotorChallengePlayDataMap.TryGetValue(challengeInfo.MotorcyclePlayId, out motorChallengePlayData))
			{
				return;
			}
			motorChallengePlayData.HighestPoint = challengeInfo.HistorySoarScore;
			foreach (int num in motorChallengePlayData.RewardIds)
			{
				global::ActivityTaskData activityTaskData = this.MotorChallengeRewardDataMap[num];
				activityTaskData.Current = motorChallengePlayData.HighestPoint;
				bool flag = false;
				for (int i = 0; i < challengeInfo.ReceiveIds.Count; i++)
				{
					if (challengeInfo.ReceiveIds[i] == num)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					activityTaskData.Status = EActivityTaskState.FinishedAndClaimed;
				}
				else if (activityTaskData.Current >= activityTaskData.Target)
				{
					activityTaskData.Status = EActivityTaskState.FinishedAndUnclaimed;
				}
				else
				{
					activityTaskData.Status = EActivityTaskState.Active;
				}
			}
		}

		// Token: 0x060408FD RID: 264445 RVA: 0x0108CBCC File Offset: 0x0108ADCC
		public void SetMotorChallengeRewardDone(int rewardId)
		{
			this.MotorChallengeRewardDataMap[rewardId].Status = EActivityTaskState.FinishedAndClaimed;
		}

		// Token: 0x060408FE RID: 264446 RVA: 0x0108CBE0 File Offset: 0x0108ADE0
		protected void RefreshMotorChallengeUnlockState(int playId)
		{
			MotorChallengePlayData motorChallengePlayData = this.MotorChallengePlayDataMap[playId];
			MotorcycleChallenge value = ConfigBase<ActivityRoadBookConfig>.Instance.GetMotorChallengeConfig(motorChallengePlayData.RewardIds[0]).Value;
			motorChallengePlayData.IsNew = false;
			if (this.TravelLevel < value.UnlockTravelLevel)
			{
				return;
			}
			if (value.UnlockQuestId != 0)
			{
				bool isUnlock = ModelBase<QuestNewModel>.Instance.CheckQuestFinished(value.UnlockQuestId);
				motorChallengePlayData.IsUnlock = isUnlock;
			}
			else
			{
				motorChallengePlayData.IsUnlock = true;
			}
			motorChallengePlayData.IsNew = this.GetMotorItemNewUnlockState(playId);
		}

		// Token: 0x060408FF RID: 264447 RVA: 0x0108CC68 File Offset: 0x0108AE68
		public string GetMotorPlayLockTips(int playId)
		{
			MotorChallengePlayData motorChallengePlayData = this.MotorChallengePlayDataMap[playId];
			return ConfigBase<ActivityRoadBookConfig>.Instance.GetMotorChallengeConfig(motorChallengePlayData.RewardIds[0]).Value.LockTips;
		}

		// Token: 0x06040900 RID: 264448 RVA: 0x0108CCA8 File Offset: 0x0108AEA8
		public List<MotorChallengePlayData> GetAllMotorTabData()
		{
			return new List<MotorChallengePlayData>(this.MotorChallengePlayDataMap.Values);
		}

		// Token: 0x06040901 RID: 264449 RVA: 0x0108CCBC File Offset: 0x0108AEBC
		public List<global::ActivityTaskData> GetMotorItemDataList(List<int> ids)
		{
			List<global::ActivityTaskData> list = new List<global::ActivityTaskData>();
			foreach (int key in ids)
			{
				global::ActivityTaskData item;
				if (this.MotorChallengeRewardDataMap.TryGetValue(key, out item))
				{
					list.Add(item);
				}
			}
			list.Sort(this.SortTaskData());
			return list;
		}

		// Token: 0x06040902 RID: 264450 RVA: 0x0108CD30 File Offset: 0x0108AF30
		protected bool GetAllMotorItemRedDot()
		{
			using (Dictionary<int, global::ActivityTaskData>.ValueCollection.Enumerator enumerator = this.MotorChallengeRewardDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == EActivityTaskState.FinishedAndUnclaimed)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06040903 RID: 264451 RVA: 0x0108CD90 File Offset: 0x0108AF90
		protected bool RefreshAndGetAllMotorItemNewUnlock()
		{
			bool flag = false;
			foreach (int playId in this.MotorChallengePlayDataMap.Keys)
			{
				this.RefreshMotorChallengeUnlockState(playId);
				if (!flag && this.GetMotorItemNewUnlockState(playId))
				{
					flag = true;
				}
			}
			return flag;
		}

		// Token: 0x06040904 RID: 264452 RVA: 0x0108CDFC File Offset: 0x0108AFFC
		public bool GetMotorItemNewUnlockState(int playId)
		{
			MotorChallengePlayData motorChallengePlayData = this.MotorChallengePlayDataMap[playId];
			return motorChallengePlayData.IsUnlock && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 7, motorChallengePlayData.TabIndex, 0) == 0;
		}

		// Token: 0x06040905 RID: 264453 RVA: 0x0108CE3C File Offset: 0x0108B03C
		protected bool CheckMotorItemRedDot(int[] ids)
		{
			foreach (int key in ids)
			{
				global::ActivityTaskData activityTaskData;
				if (this.MotorChallengeRewardDataMap.TryGetValue(key, out activityTaskData) && activityTaskData.Status == EActivityTaskState.FinishedAndUnclaimed)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06040906 RID: 264454 RVA: 0x0108CE78 File Offset: 0x0108B078
		protected bool CheckMotorItemFinished(int[] ids)
		{
			foreach (int key in ids)
			{
				global::ActivityTaskData activityTaskData;
				if (this.MotorChallengeRewardDataMap.TryGetValue(key, out activityTaskData) && activityTaskData.Status != EActivityTaskState.FinishedAndClaimed)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x040241FB RID: 147963
		public readonly Dictionary<int, IRoadBookLevelData> TravelLevelData = new Dictionary<int, IRoadBookLevelData>();

		// Token: 0x040241FC RID: 147964
		public int TravelLevel;

		// Token: 0x040241FD RID: 147965
		private int LastTravelLevelInternal;

		// Token: 0x040241FE RID: 147966
		private int LastExpCountInternal;

		// Token: 0x040241FF RID: 147967
		private int LastCurrentExpCountInternal;

		// Token: 0x04024200 RID: 147968
		protected Dictionary<int, RoadBookAreaData> AreaDataMap = new Dictionary<int, RoadBookAreaData>();

		// Token: 0x04024201 RID: 147969
		public Dictionary<int, global::ActivityTaskData> AreaTaskMap = new Dictionary<int, global::ActivityTaskData>();

		// Token: 0x04024202 RID: 147970
		[Nullable(2)]
		public FinalTravelTaskData TaskFinalRewardData;

		// Token: 0x04024203 RID: 147971
		public Dictionary<int, bool> PhantomDataMap = new Dictionary<int, bool>();

		// Token: 0x04024204 RID: 147972
		public Dictionary<int, global::ActivityTaskData> MotorChallengeRewardDataMap = new Dictionary<int, global::ActivityTaskData>();

		// Token: 0x04024205 RID: 147973
		public Dictionary<int, MotorChallengePlayData> MotorChallengePlayDataMap = new Dictionary<int, MotorChallengePlayData>();
	}
}
