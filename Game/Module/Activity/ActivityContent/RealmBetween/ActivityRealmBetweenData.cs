using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006526 RID: 25894
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityRealmBetweenData : ActivityBaseData
	{
		// Token: 0x06040C2B RID: 265259 RVA: 0x0109B174 File Offset: 0x01099374
		protected override void OnInit(ActivityData data)
		{
			this.InitTravelLevelData();
			this.InitTravelAreaData();
			this.InitPhantomData();
			this.InitMotorChallengeData();
			RealmBetweenActivityInfo realmBetweenActivityInfo = data.RealmBetweenActivityInfo;
			if (realmBetweenActivityInfo == null)
			{
				return;
			}
			this.TravelLevel = realmBetweenActivityInfo.RealmBetweenLevel;
			this.LastTravelLevelInternal = realmBetweenActivityInfo.RealmBetweenLevel;
			this.LastCurrentExpCountInternal = this.GetCurrentExp();
			this.LastExpCountInternal = this.GetExpItemCount();
		}

		// Token: 0x06040C2C RID: 265260 RVA: 0x0109B1D4 File Offset: 0x010993D4
		protected override void PhraseEx(ActivityData data)
		{
			RealmBetweenActivityInfo realmBetweenActivityInfo = data.RealmBetweenActivityInfo;
			if (realmBetweenActivityInfo == null)
			{
				return;
			}
			this.RefreshRealmBetweenData(realmBetweenActivityInfo);
		}

		// Token: 0x06040C2D RID: 265261 RVA: 0x0109B1F4 File Offset: 0x010993F4
		protected void RefreshRealmBetweenData(RealmBetweenActivityInfo info)
		{
			this.TravelLevel = info.RealmBetweenLevel;
			for (int i = 0; i < info.UnLockAreas.Count; i++)
			{
				this.UnlockAreaData(info.UnLockAreas[i]);
			}
			for (int j = 0; j < info.ActivityTasks.Count; j++)
			{
				ConditionTask task = info.ActivityTasks[j];
				this.RefreshTravelTaskData(task);
			}
			this.TaskFinalRewardData.IsReceived = info.GetFullReward;
			for (int k = 0; k < info.MonsterGain.Count; k++)
			{
				this.UnlockPhantom(info.MonsterGain[k]);
			}
			for (int l = 0; l < info.SoarLevels.Count; l++)
			{
				RealmBetweenMotorcycleInfo challengeInfo = info.SoarLevels[l];
				this.RefreshMotorChallengePlayData(challengeInfo);
			}
			foreach (int playId in this.MotorChallengePlayDataMap.Keys)
			{
				this.RefreshMotorChallengeUnlockState(playId);
			}
		}

		// Token: 0x06040C2E RID: 265262 RVA: 0x0109B318 File Offset: 0x01099518
		public override bool GetExDataRedPointShowState()
		{
			return this.CanTravelLevelUp() || this.GetTaskRedDotState(true) || this.GetAllMotorItemRedDot();
		}

		// Token: 0x06040C2F RID: 265263 RVA: 0x0109B33C File Offset: 0x0109953C
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

		// Token: 0x06040C30 RID: 265264 RVA: 0x0109B410 File Offset: 0x01099610
		public bool SaveFirstCheckRedDotState(ERealmBetweenSaveFlag saveFlag, int id = 0)
		{
			if (ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, (int)saveFlag, id, 0) == 1)
			{
				return true;
			}
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, (int)saveFlag, id, 0, 1);
			this.RefreshActivityRedDotState();
			return false;
		}

		// Token: 0x06040C31 RID: 265265 RVA: 0x0109B448 File Offset: 0x01099648
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"current",
			"total"
		})]
		public ValueTuple<int, int> GetTypeProgress(ERealmBetweenSubType subType)
		{
			int num = 0;
			int item = 1;
			switch (subType)
			{
			case ERealmBetweenSubType.TravelTask:
				num = this.GetFinishedAreaTaskCount();
				item = this.AreaTaskMap.Count;
				break;
			case ERealmBetweenSubType.PhantomCollect:
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
			case ERealmBetweenSubType.MotorChallenge:
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

		// Token: 0x06040C32 RID: 265266 RVA: 0x0109B544 File Offset: 0x01099744
		public bool GetTypeRedDotState(ERealmBetweenSubType subType)
		{
			if (subType != ERealmBetweenSubType.TravelTask)
			{
				return subType == ERealmBetweenSubType.MotorChallenge && this.GetAllMotorItemRedDot();
			}
			return this.GetTaskRedDotState(false);
		}

		// Token: 0x06040C33 RID: 265267 RVA: 0x0109B560 File Offset: 0x01099760
		public bool GetTypeNewState(ERealmBetweenSubType subType)
		{
			switch (subType)
			{
			case ERealmBetweenSubType.TravelTask:
				return this.GetAllAreaNewUnlockState();
			case ERealmBetweenSubType.PhantomCollect:
				return this.GetAllPhantomNewUnlockState();
			case ERealmBetweenSubType.MotorChallenge:
				return this.RefreshAndGetAllMotorItemNewUnlock();
			}
			return false;
		}

		// Token: 0x06040C34 RID: 265268 RVA: 0x0109B592 File Offset: 0x01099792
		public void RefreshActivityRedDotState()
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06040C35 RID: 265269 RVA: 0x0109B5AC File Offset: 0x010997AC
		public RealmBetweenConfig GetActivityConfig()
		{
			return ConfigBase<ActivityRealmBetweenConfig>.Instance.GetActivityConfig(base.Id).Value;
		}

		// Token: 0x06040C36 RID: 265270 RVA: 0x0109B5D1 File Offset: 0x010997D1
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

		// Token: 0x17009E8E RID: 40590
		// (get) Token: 0x06040C37 RID: 265271 RVA: 0x0109B5F2 File Offset: 0x010997F2
		public int LastTravelLevel
		{
			get
			{
				int lastTravelLevelInternal = this.LastTravelLevelInternal;
				this.LastTravelLevelInternal = this.TravelLevel;
				return lastTravelLevelInternal;
			}
		}

		// Token: 0x17009E8F RID: 40591
		// (get) Token: 0x06040C38 RID: 265272 RVA: 0x0109B606 File Offset: 0x01099806
		public int LastCurrentExpCount
		{
			get
			{
				int lastCurrentExpCountInternal = this.LastCurrentExpCountInternal;
				this.LastCurrentExpCountInternal = this.GetCurrentExp();
				return lastCurrentExpCountInternal;
			}
		}

		// Token: 0x17009E90 RID: 40592
		// (get) Token: 0x06040C39 RID: 265273 RVA: 0x0109B61A File Offset: 0x0109981A
		public int LastExpCount
		{
			get
			{
				int lastExpCountInternal = this.LastExpCountInternal;
				this.LastExpCountInternal = this.GetExpItemCount();
				return lastExpCountInternal;
			}
		}

		// Token: 0x17009E91 RID: 40593
		// (get) Token: 0x06040C3A RID: 265274 RVA: 0x0109B630 File Offset: 0x01099830
		public int MaxTravelLevel
		{
			get
			{
				return this.GetActivityConfig().MaxLevel;
			}
		}

		// Token: 0x06040C3B RID: 265275 RVA: 0x0109B64C File Offset: 0x0109984C
		private void InitTravelLevelData()
		{
			this.TravelLevelData.Clear();
			IEnumerable<RealmBetweenLevelExp> allLevelExpConfig = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetAllLevelExpConfig(base.Id);
			int num = 0;
			foreach (RealmBetweenLevelExp realmBetweenLevelExp in allLevelExpConfig)
			{
				RealmBetweenLevelData value = new RealmBetweenLevelData
				{
					Id = realmBetweenLevelExp.Id,
					Level = realmBetweenLevelExp.Level,
					AccumulateExp = num,
					TargetExp = realmBetweenLevelExp.NeedExp
				};
				this.TravelLevelData[realmBetweenLevelExp.Level] = value;
				num += realmBetweenLevelExp.NeedExp;
			}
		}

		// Token: 0x06040C3C RID: 265276 RVA: 0x0109B6FC File Offset: 0x010998FC
		public int GetExpItemCount()
		{
			int expItemId = this.GetActivityConfig().ExpItemId;
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(expItemId, 0);
		}

		// Token: 0x06040C3D RID: 265277 RVA: 0x0109B724 File Offset: 0x01099924
		public int GetCurrentExp()
		{
			int expItemCount = this.GetExpItemCount();
			IRealmBetweenLevelData realmBetweenLevelData;
			int num = this.TravelLevelData.TryGetValue(this.TravelLevel, out realmBetweenLevelData) ? realmBetweenLevelData.AccumulateExp : 0;
			return expItemCount - num;
		}

		// Token: 0x06040C3E RID: 265278 RVA: 0x0109B758 File Offset: 0x01099958
		public int GetCurrentTargetExp()
		{
			bool flag = this.MaxTravelLevel == this.TravelLevel;
			IRealmBetweenLevelData realmBetweenLevelData = this.TravelLevelData[this.TravelLevel];
			if (!flag)
			{
				return realmBetweenLevelData.TargetExp;
			}
			return realmBetweenLevelData.AccumulateExp;
		}

		// Token: 0x06040C3F RID: 265279 RVA: 0x0109B794 File Offset: 0x01099994
		public bool CanTravelLevelUp()
		{
			if (this.MaxTravelLevel == this.TravelLevel)
			{
				return false;
			}
			int expItemCount = this.GetExpItemCount();
			IRealmBetweenLevelData realmBetweenLevelData;
			if (!this.TravelLevelData.TryGetValue(this.TravelLevel, out realmBetweenLevelData))
			{
				return false;
			}
			int num = realmBetweenLevelData.AccumulateExp + realmBetweenLevelData.TargetExp;
			return expItemCount >= num;
		}

		// Token: 0x06040C40 RID: 265280 RVA: 0x0109B7E8 File Offset: 0x010999E8
		private void InitTravelAreaData()
		{
			this.AreaDataMap.Clear();
			this.TaskFinalRewardData = new FinalTravelTaskData();
			IReadOnlyList<RealmBetweenTask> allRealmBetweenTaskConfig = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetAllRealmBetweenTaskConfig(base.Id);
			this.TaskFinalRewardData.Target = allRealmBetweenTaskConfig.Count;
			foreach (RealmBetweenArea realmBetweenArea in ConfigBase<ActivityRealmBetweenConfig>.Instance.GetAllAreaConfig(base.Id))
			{
				RealmBetweenAreaData value = new RealmBetweenAreaData(realmBetweenArea.Id);
				this.AreaDataMap[realmBetweenArea.Id] = value;
			}
		}

		// Token: 0x06040C41 RID: 265281 RVA: 0x0109B890 File Offset: 0x01099A90
		public void UnlockAreaData(int areaId)
		{
			RealmBetweenAreaData realmBetweenAreaData;
			if (!this.AreaDataMap.TryGetValue(areaId, out realmBetweenAreaData))
			{
				return;
			}
			realmBetweenAreaData.IsUnlock = true;
		}

		// Token: 0x06040C42 RID: 265282 RVA: 0x0109B8B5 File Offset: 0x01099AB5
		public void OnNewAreaUnlocked(int areaId)
		{
			this.UnlockAreaData(areaId);
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 5, areaId, 0, 0);
		}

		// Token: 0x06040C43 RID: 265283 RVA: 0x0109B8D2 File Offset: 0x01099AD2
		public List<RealmBetweenAreaData> GetAllAreaData()
		{
			List<RealmBetweenAreaData> list = new List<RealmBetweenAreaData>(this.AreaDataMap.Values);
			list.Sort(delegate(RealmBetweenAreaData a, RealmBetweenAreaData b)
			{
				RealmBetweenArea value = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetAreaConfig(a.AreaId).Value;
				RealmBetweenArea value2 = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetAreaConfig(b.AreaId).Value;
				if (value.Sort == value2.Sort)
				{
					return a.AreaId - b.AreaId;
				}
				return value.Sort - value2.Sort;
			});
			return list;
		}

		// Token: 0x06040C44 RID: 265284 RVA: 0x0109B90C File Offset: 0x01099B0C
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

		// Token: 0x06040C45 RID: 265285 RVA: 0x0109B970 File Offset: 0x01099B70
		public void RefreshTravelTaskData(ConditionTask task)
		{
			global::ActivityTaskData activityTaskData;
			if (!this.AreaTaskMap.TryGetValue(task.Id, out activityTaskData))
			{
				activityTaskData = new global::ActivityTaskData();
				RealmBetweenTask value = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetRealmBetweenTaskConfig(task.Id).Value;
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

		// Token: 0x06040C46 RID: 265286 RVA: 0x0109BA26 File Offset: 0x01099C26
		public void SetTravelTaskDataDone(int taskId)
		{
			this.AreaTaskMap[taskId].Status = EActivityTaskState.FinishedAndClaimed;
			this.TaskFinalRewardData.FinishedIdSet.Add(taskId);
		}

		// Token: 0x06040C47 RID: 265287 RVA: 0x0109BA4C File Offset: 0x01099C4C
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

		// Token: 0x06040C48 RID: 265288 RVA: 0x0109BAC0 File Offset: 0x01099CC0
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

		// Token: 0x06040C49 RID: 265289 RVA: 0x0109BB20 File Offset: 0x01099D20
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

		// Token: 0x06040C4A RID: 265290 RVA: 0x0109BBA0 File Offset: 0x01099DA0
		public bool GetAreaNewUnlockState(int areaId)
		{
			bool isUnlock = this.AreaDataMap[areaId].IsUnlock;
			bool flag = this.AreaDataMap[areaId].TravelTaskIdSet.Count > 0;
			bool flag2 = this.IsAreaTaskFinish(areaId);
			return isUnlock && !flag2 && flag && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 5, areaId, 0) == 0;
		}

		// Token: 0x06040C4B RID: 265291 RVA: 0x0109BC08 File Offset: 0x01099E08
		public bool GetAreaRewardState(int areaId)
		{
			RealmBetweenAreaData realmBetweenAreaData = this.AreaDataMap[areaId];
			if (!realmBetweenAreaData.IsUnlock)
			{
				return false;
			}
			foreach (int key in realmBetweenAreaData.TravelTaskIdSet)
			{
				if (this.AreaTaskMap[key].Status == EActivityTaskState.FinishedAndUnclaimed)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06040C4C RID: 265292 RVA: 0x0109BC88 File Offset: 0x01099E88
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

		// Token: 0x06040C4D RID: 265293 RVA: 0x0109BD10 File Offset: 0x01099F10
		private void InitPhantomData()
		{
			this.PhantomDataMap.Clear();
			foreach (RealmBetweenPhantomGain realmBetweenPhantomGain in ConfigBase<ActivityRealmBetweenConfig>.Instance.GetAllPhantomConfig(base.Id))
			{
				this.PhantomDataMap[realmBetweenPhantomGain.Id] = false;
			}
		}

		// Token: 0x06040C4E RID: 265294 RVA: 0x0109BD80 File Offset: 0x01099F80
		public void UnlockPhantom(int phantomId)
		{
			this.PhantomDataMap[phantomId] = true;
		}

		// Token: 0x06040C4F RID: 265295 RVA: 0x0109BD90 File Offset: 0x01099F90
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

		// Token: 0x06040C50 RID: 265296 RVA: 0x0109BDFC File Offset: 0x01099FFC
		public bool GetPhantomNewUnlockState(int phantomId)
		{
			int key = phantomId - 6000000;
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 4, key, 0) == 0;
		}

		// Token: 0x06040C51 RID: 265297 RVA: 0x0109BE28 File Offset: 0x0109A028
		private void InitMotorChallengeData()
		{
			this.MotorChallengeRewardDataMap.Clear();
			int num = 0;
			foreach (RealmBetweenChallenge realmBetweenChallenge in ConfigBase<ActivityRealmBetweenConfig>.Instance.GetAllMotorChallengeConfig())
			{
				global::ActivityTaskData activityTaskData = new global::ActivityTaskData();
				activityTaskData.Id = realmBetweenChallenge.Id;
				activityTaskData.Target = realmBetweenChallenge.NeedScore;
				this.MotorChallengeRewardDataMap[realmBetweenChallenge.Id] = activityTaskData;
				MotorChallengePlayData motorChallengePlayData;
				if (!this.MotorChallengePlayDataMap.TryGetValue(realmBetweenChallenge.LevelPlayId, out motorChallengePlayData))
				{
					motorChallengePlayData = new MotorChallengePlayData();
					motorChallengePlayData.TabIndex = num;
					motorChallengePlayData.PlayId = realmBetweenChallenge.LevelPlayId;
					motorChallengePlayData.NameTextId = realmBetweenChallenge.Name;
					motorChallengePlayData.CheckRedDot = new Func<int[], bool>(this.CheckMotorItemRedDot);
					motorChallengePlayData.CheckFinished = new Func<int[], bool>(this.CheckMotorItemFinished);
					motorChallengePlayData.JumpId = realmBetweenChallenge.JumpId;
					motorChallengePlayData.ClassId = realmBetweenChallenge.ClassificationId;
					this.MotorChallengePlayDataMap[realmBetweenChallenge.LevelPlayId] = motorChallengePlayData;
					num++;
				}
				motorChallengePlayData.RewardIds.Add(realmBetweenChallenge.Id);
			}
		}

		// Token: 0x06040C52 RID: 265298 RVA: 0x0109BF6C File Offset: 0x0109A16C
		public void RefreshMotorChallengePlayData(RealmBetweenMotorcycleInfo challengeInfo)
		{
			MotorChallengePlayData motorChallengePlayData;
			if (!this.MotorChallengePlayDataMap.TryGetValue(challengeInfo.MotorcyclePlayId, out motorChallengePlayData))
			{
				return;
			}
			motorChallengePlayData.IsUnlock = true;
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

		// Token: 0x06040C53 RID: 265299 RVA: 0x0109C05C File Offset: 0x0109A25C
		public void SetMotorChallengeRewardDone(int rewardId)
		{
			this.MotorChallengeRewardDataMap[rewardId].Status = EActivityTaskState.FinishedAndClaimed;
		}

		// Token: 0x06040C54 RID: 265300 RVA: 0x0109C070 File Offset: 0x0109A270
		protected void RefreshMotorChallengeUnlockState(int playId)
		{
			MotorChallengePlayData motorChallengePlayData = this.MotorChallengePlayDataMap[playId];
			RealmBetweenChallenge value = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetMotorChallengeConfig(motorChallengePlayData.RewardIds[0]).Value;
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

		// Token: 0x06040C55 RID: 265301 RVA: 0x0109C0F8 File Offset: 0x0109A2F8
		public string GetMotorPlayLockTips(int playId)
		{
			MotorChallengePlayData motorChallengePlayData = this.MotorChallengePlayDataMap[playId];
			return ConfigBase<ActivityRealmBetweenConfig>.Instance.GetMotorChallengeConfig(motorChallengePlayData.RewardIds[0]).Value.LockTips;
		}

		// Token: 0x06040C56 RID: 265302 RVA: 0x0109C138 File Offset: 0x0109A338
		public List<MotorChallengePlayData> GetAllMotorTabData()
		{
			return new List<MotorChallengePlayData>(this.MotorChallengePlayDataMap.Values);
		}

		// Token: 0x06040C57 RID: 265303 RVA: 0x0109C14C File Offset: 0x0109A34C
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

		// Token: 0x06040C58 RID: 265304 RVA: 0x0109C1C0 File Offset: 0x0109A3C0
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

		// Token: 0x06040C59 RID: 265305 RVA: 0x0109C220 File Offset: 0x0109A420
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

		// Token: 0x06040C5A RID: 265306 RVA: 0x0109C28C File Offset: 0x0109A48C
		public bool GetMotorItemNewUnlockState(int playId)
		{
			MotorChallengePlayData motorChallengePlayData = this.MotorChallengePlayDataMap[playId];
			return motorChallengePlayData.IsUnlock && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 7, motorChallengePlayData.TabIndex, 0) == 0;
		}

		// Token: 0x06040C5B RID: 265307 RVA: 0x0109C2CC File Offset: 0x0109A4CC
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

		// Token: 0x06040C5C RID: 265308 RVA: 0x0109C308 File Offset: 0x0109A508
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

		// Token: 0x040244FF RID: 148735
		public const int PHANTOM_ID_OFFSET = 6000000;

		// Token: 0x04024500 RID: 148736
		public readonly Dictionary<int, IRealmBetweenLevelData> TravelLevelData = new Dictionary<int, IRealmBetweenLevelData>();

		// Token: 0x04024501 RID: 148737
		public int TravelLevel;

		// Token: 0x04024502 RID: 148738
		private int LastTravelLevelInternal;

		// Token: 0x04024503 RID: 148739
		private int LastExpCountInternal;

		// Token: 0x04024504 RID: 148740
		private int LastCurrentExpCountInternal;

		// Token: 0x04024505 RID: 148741
		protected Dictionary<int, RealmBetweenAreaData> AreaDataMap = new Dictionary<int, RealmBetweenAreaData>();

		// Token: 0x04024506 RID: 148742
		public Dictionary<int, global::ActivityTaskData> AreaTaskMap = new Dictionary<int, global::ActivityTaskData>();

		// Token: 0x04024507 RID: 148743
		[Nullable(2)]
		public FinalTravelTaskData TaskFinalRewardData;

		// Token: 0x04024508 RID: 148744
		public Dictionary<int, bool> PhantomDataMap = new Dictionary<int, bool>();

		// Token: 0x04024509 RID: 148745
		public Dictionary<int, global::ActivityTaskData> MotorChallengeRewardDataMap = new Dictionary<int, global::ActivityTaskData>();

		// Token: 0x0402450A RID: 148746
		public Dictionary<int, MotorChallengePlayData> MotorChallengePlayDataMap = new Dictionary<int, MotorChallengePlayData>();
	}
}
