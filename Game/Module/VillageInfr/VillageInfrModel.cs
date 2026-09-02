using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C39 RID: 19513
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class VillageInfrModel : ModelBase<VillageInfrModel>
	{
		// Token: 0x06032DCC RID: 208332 RVA: 0x00CBD4F5 File Offset: 0x00CBB6F5
		public void SetData(InfrV2Pb data)
		{
			this.SetAllTreeData(data.TreeInfo);
			this.SetVillageData(data.FireInfo);
			this.SetTaskData(data.ConditionTasks);
			this.SetScoreRewardData(data.RewardScoreIds);
			this.SetAllTreeFinishConditionData(data.TreeFinishCond);
		}

		// Token: 0x06032DCD RID: 208333 RVA: 0x00CBD534 File Offset: 0x00CBB734
		[NullableContext(2)]
		public IVillageInfrTreeData GetTreeData(int treeId)
		{
			IVillageInfrTreeData result;
			if (this.TreeDataMap.TryGetValue(treeId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06032DCE RID: 208334 RVA: 0x00CBD554 File Offset: 0x00CBB754
		public List<IVillageInfrTreeData> GetAllTreeData()
		{
			return new List<IVillageInfrTreeData>(this.TreeDataMap.Values);
		}

		// Token: 0x06032DCF RID: 208335 RVA: 0x00CBD568 File Offset: 0x00CBB768
		public void SetAllTreeData(InfrV2TreePb data)
		{
			this.TreeDataMap.Clear();
			foreach (InfrV2OneTree infrV2OneTree in data.Trees)
			{
				this.TreeDataMap.Add(infrV2OneTree.TreeId, new VillageInfrTreeData
				{
					Id = infrV2OneTree.TreeId,
					Status = infrV2OneTree.Status,
					CompleteTime = infrV2OneTree.CompleteTime
				});
			}
			this.TraceTreeId = data.ManualTraceTree;
			Singleton<EventSystem>.Instance.Emit(EEventName.VillageInfrTreeDataUpdate);
		}

		// Token: 0x06032DD0 RID: 208336 RVA: 0x00CBD610 File Offset: 0x00CBB810
		public void SetTreeData(InfrV2OneTree treeData)
		{
			this.TreeDataMap[treeData.TreeId] = new VillageInfrTreeData
			{
				Id = treeData.TreeId,
				Status = treeData.Status,
				CompleteTime = treeData.CompleteTime
			};
			Singleton<EventSystem>.Instance.Emit(EEventName.VillageInfrTreeDataUpdate);
		}

		// Token: 0x06032DD1 RID: 208337 RVA: 0x00CBD667 File Offset: 0x00CBB867
		public void SetTraceTreeId(int treeId)
		{
			this.TraceTreeId = treeId;
			Singleton<EventSystem>.Instance.Emit(EEventName.VillageInfrTreeDataUpdate);
		}

		// Token: 0x06032DD2 RID: 208338 RVA: 0x00CBD680 File Offset: 0x00CBB880
		public int GetTraceTreeId()
		{
			return this.TraceTreeId;
		}

		// Token: 0x06032DD3 RID: 208339 RVA: 0x00CBD688 File Offset: 0x00CBB888
		public long GetVillageExp()
		{
			return this.VillageExpInner;
		}

		// Token: 0x06032DD4 RID: 208340 RVA: 0x00CBD690 File Offset: 0x00CBB890
		public int GetVillageLevel()
		{
			return this.VillageLevelInner;
		}

		// Token: 0x06032DD5 RID: 208341 RVA: 0x00CBD698 File Offset: 0x00CBB898
		public long GetVillageLevelReachTime()
		{
			return this.VillageLevelReachTimeInner;
		}

		// Token: 0x06032DD6 RID: 208342 RVA: 0x00CBD6A0 File Offset: 0x00CBB8A0
		public InfrV2StatusPb GetVillageStatus()
		{
			return this.VillageStatusInner;
		}

		// Token: 0x06032DD7 RID: 208343 RVA: 0x00CBD6A8 File Offset: 0x00CBB8A8
		public void SetVillageData(InfrV2FirePb data)
		{
			this.VillageExpInner = data.FireExp;
			this.VillageLevelInner = data.FireLevel;
			this.VillageLevelReachTimeInner = data.FireLevelReachTime;
			this.VillageStatusInner = data.FireStatus;
			Singleton<EventSystem>.Instance.Emit(EEventName.VillageInfrVillageDataUpdate);
		}

		// Token: 0x06032DD8 RID: 208344 RVA: 0x00CBD6F5 File Offset: 0x00CBB8F5
		public void SetActivityData(VillageInfrActivityData activityData)
		{
			this.ActivityData = activityData;
		}

		// Token: 0x06032DD9 RID: 208345 RVA: 0x00CBD700 File Offset: 0x00CBB900
		[NullableContext(2)]
		public VillageInfrActivityData GetActivityData()
		{
			if (this.ActivityData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.VillageInfr, ELogAuthor.LYX, "VillageInfrActivityData is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return this.ActivityData;
		}

		// Token: 0x06032DDA RID: 208346 RVA: 0x00CBD73C File Offset: 0x00CBB93C
		public void SetTaskData(IList<ConditionTask> activityTasks)
		{
			this.TaskDataMap.Clear();
			foreach (ConditionTask conditionTask in activityTasks)
			{
				VillageInfrLimitTaskData villageInfrLimitTaskData = new VillageInfrLimitTaskData(conditionTask.Id);
				this.TaskDataMap.Add(conditionTask.Id, villageInfrLimitTaskData);
				villageInfrLimitTaskData.UpdateData(conditionTask);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.VillageInfrActivityTaskDataUpdate);
		}

		// Token: 0x06032DDB RID: 208347 RVA: 0x00CBD7C0 File Offset: 0x00CBB9C0
		public void SetTaskReceive(List<int> taskIdList)
		{
			foreach (int key in taskIdList)
			{
				VillageInfrLimitTaskData villageInfrLimitTaskData;
				if (this.TaskDataMap.TryGetValue(key, out villageInfrLimitTaskData))
				{
					villageInfrLimitTaskData.Status = ConditionTaskState.ConditionTaskTaken;
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.VillageInfrActivityTaskDataUpdate);
		}

		// Token: 0x06032DDC RID: 208348 RVA: 0x00CBD830 File Offset: 0x00CBBA30
		public void SetScoreRewardData(IList<int> scoreRewardIds)
		{
			this.ReceivedScoreRewardId.Clear();
			foreach (int item in scoreRewardIds)
			{
				this.ReceivedScoreRewardId.Add(item);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.VillageInfrScoreRewardDataUpdate);
		}

		// Token: 0x06032DDD RID: 208349 RVA: 0x00CBD89C File Offset: 0x00CBBA9C
		public void AddScoreRewardData(List<int> scoreRewardIds)
		{
			foreach (int item in scoreRewardIds)
			{
				this.ReceivedScoreRewardId.Add(item);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.VillageInfrScoreRewardDataUpdate);
		}

		// Token: 0x06032DDE RID: 208350 RVA: 0x00CBD900 File Offset: 0x00CBBB00
		public void SetAllTreeFinishConditionData(IList<int> data)
		{
			this.TreeFinishConditions = new List<int>(data);
			Singleton<EventSystem>.Instance.Emit(EEventName.VillageInfrTreeFinishCondDataUpdate);
		}

		// Token: 0x06032DDF RID: 208351 RVA: 0x00CBD91E File Offset: 0x00CBBB1E
		public bool IsScoreRewardReceived(int id)
		{
			return this.ReceivedScoreRewardId.Contains(id);
		}

		// Token: 0x06032DE0 RID: 208352 RVA: 0x00CBD92C File Offset: 0x00CBBB2C
		public void UpdateActivityTask(ConditionTask data)
		{
			VillageInfrLimitTaskData villageInfrLimitTaskData;
			if (!this.TaskDataMap.TryGetValue(data.Id, out villageInfrLimitTaskData))
			{
				villageInfrLimitTaskData = new VillageInfrLimitTaskData(data.Id);
			}
			villageInfrLimitTaskData.UpdateData(data);
			this.TaskDataMap[data.Id] = villageInfrLimitTaskData;
			Singleton<EventSystem>.Instance.Emit(EEventName.VillageInfrActivityTaskDataUpdate);
		}

		// Token: 0x06032DE1 RID: 208353 RVA: 0x00CBD984 File Offset: 0x00CBBB84
		public List<VillageInfrLimitTaskData> GetActivityTaskDataList()
		{
			List<VillageInfrLimitTaskData> list = new List<VillageInfrLimitTaskData>(this.TaskDataMap.Values);
			list.Sort(delegate(VillageInfrLimitTaskData a, VillageInfrLimitTaskData b)
			{
				if (a.Status != b.Status)
				{
					return this.GetStatusPriority(a.Status) - this.GetStatusPriority(b.Status);
				}
				return a.ConfigId - b.ConfigId;
			});
			for (int i = 0; i < list.Count; i++)
			{
				list[i].Index = i + 1;
			}
			return list;
		}

		// Token: 0x06032DE2 RID: 208354 RVA: 0x00CBD9D5 File Offset: 0x00CBBBD5
		private int GetStatusPriority(ConditionTaskState status)
		{
			switch (status)
			{
			case ConditionTaskState.ConditionTaskRunning:
				return 2;
			case ConditionTaskState.ConditionTaskFinish:
				return 1;
			case ConditionTaskState.ConditionTaskTaken:
				return 3;
			default:
				return 0;
			}
		}

		// Token: 0x06032DE3 RID: 208355 RVA: 0x00CBD9F4 File Offset: 0x00CBBBF4
		public bool GetTaskRedDot()
		{
			using (Dictionary<int, VillageInfrLimitTaskData>.ValueCollection.Enumerator enumerator = this.TaskDataMap.Values.GetEnumerator())
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

		// Token: 0x06032DE4 RID: 208356 RVA: 0x00CBDA54 File Offset: 0x00CBBC54
		public bool GetTreeIsUnlock(int treeId)
		{
			IVillageInfrTreeData villageInfrTreeData;
			return this.TreeDataMap.TryGetValue(treeId, out villageInfrTreeData) && villageInfrTreeData.Status > InfrV2StatusPb.InfrV2StatusLock;
		}

		// Token: 0x06032DE5 RID: 208357 RVA: 0x00CBDA7C File Offset: 0x00CBBC7C
		public bool GetTreeIsComplete(int treeId)
		{
			IVillageInfrTreeData villageInfrTreeData;
			return this.TreeDataMap.TryGetValue(treeId, out villageInfrTreeData) && villageInfrTreeData.Status == InfrV2StatusPb.InfrV2StatusComplete;
		}

		// Token: 0x06032DE6 RID: 208358 RVA: 0x00CBDAA4 File Offset: 0x00CBBCA4
		public bool GetCanVillageLevelUp()
		{
			int infrMaxLevel = ConfigBase<VillageInfrConfig>.Instance.GetInfrMaxLevel();
			if (this.VillageLevelInner == 0 || this.VillageLevelInner >= infrMaxLevel)
			{
				return false;
			}
			Dictionary<int, int>.Enumerator enumerator = ConfigBase<VillageInfrConfig>.Instance.GetInfrLevel(this.VillageLevelInner).Value.Requirement().GetEnumerator();
			enumerator.MoveNext();
			KeyValuePair<int, int> keyValuePair = enumerator.Current;
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key, 0) >= value;
		}

		// Token: 0x06032DE7 RID: 208359 RVA: 0x00CBDB2C File Offset: 0x00CBBD2C
		public bool HasTreeCanLevelUp()
		{
			foreach (IVillageInfrTreeData villageInfrTreeData in this.TreeDataMap.Values)
			{
				if (this.GetCanTreeLevelUp(villageInfrTreeData.Id))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06032DE8 RID: 208360 RVA: 0x00CBDB94 File Offset: 0x00CBBD94
		public bool GetCanTreeLevelUp(int treeId)
		{
			IVillageInfrTreeData villageInfrTreeData;
			if (!this.TreeDataMap.TryGetValue(treeId, out villageInfrTreeData) || villageInfrTreeData.Status != InfrV2StatusPb.InfrV2StatusProgress)
			{
				return false;
			}
			Dictionary<int, int>.Enumerator enumerator = ConfigBase<VillageInfrConfig>.Instance.GetInfrTreeBuild(treeId).Value.Requirement().GetEnumerator();
			enumerator.MoveNext();
			KeyValuePair<int, int> keyValuePair = enumerator.Current;
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key, 0) >= value;
		}

		// Token: 0x06032DE9 RID: 208361 RVA: 0x00CBDC14 File Offset: 0x00CBBE14
		public List<int> GetCanReceiveScoreRewardIds()
		{
			int rewardScore = this.GetRewardScore();
			List<int> list = new List<int>();
			foreach (InfrV2ScoreReward infrV2ScoreReward in ConfigBase<VillageInfrConfig>.Instance.GetScoreReward())
			{
				if (infrV2ScoreReward.Score <= rewardScore && !this.IsScoreRewardReceived(infrV2ScoreReward.Id))
				{
					list.Add(infrV2ScoreReward.Id);
				}
			}
			return list;
		}

		// Token: 0x06032DEA RID: 208362 RVA: 0x00CBDC94 File Offset: 0x00CBBE94
		public bool HasScoreReward()
		{
			return this.GetCanReceiveScoreRewardIds().Count > 0;
		}

		// Token: 0x06032DEB RID: 208363 RVA: 0x00CBDCA4 File Offset: 0x00CBBEA4
		public int GetRewardScore()
		{
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(ConfigCommonParamById.GetIntConfig("InfrV2ScoreItem").Value, 0);
		}

		// Token: 0x06032DEC RID: 208364 RVA: 0x00CBDCD0 File Offset: 0x00CBBED0
		public bool CanShowNewTip(int itemId, int count)
		{
			int? treeIdByItemId = ConfigBase<VillageInfrConfig>.Instance.GetTreeIdByItemId(itemId);
			if (treeIdByItemId == null)
			{
				return false;
			}
			Dictionary<int, int>.Enumerator enumerator = ConfigBase<VillageInfrConfig>.Instance.GetInfrTreeBuild(treeIdByItemId.Value).Value.Requirement().GetEnumerator();
			enumerator.MoveNext();
			KeyValuePair<int, int> keyValuePair = enumerator.Current;
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key, 0);
			return itemCountByConfigId >= value && itemCountByConfigId - count < value;
		}

		// Token: 0x06032DED RID: 208365 RVA: 0x00CBDD5C File Offset: 0x00CBBF5C
		public List<int> GetTreeFinishConditions()
		{
			return this.TreeFinishConditions;
		}

		// Token: 0x0401D997 RID: 121239
		private readonly Dictionary<int, IVillageInfrTreeData> TreeDataMap = new Dictionary<int, IVillageInfrTreeData>();

		// Token: 0x0401D998 RID: 121240
		private readonly Dictionary<int, VillageInfrLimitTaskData> TaskDataMap = new Dictionary<int, VillageInfrLimitTaskData>();

		// Token: 0x0401D999 RID: 121241
		private int TraceTreeId;

		// Token: 0x0401D99A RID: 121242
		private readonly HashSet<int> ReceivedScoreRewardId = new HashSet<int>();

		// Token: 0x0401D99B RID: 121243
		private long VillageExpInner;

		// Token: 0x0401D99C RID: 121244
		private int VillageLevelInner;

		// Token: 0x0401D99D RID: 121245
		private long VillageLevelReachTimeInner;

		// Token: 0x0401D99E RID: 121246
		private InfrV2StatusPb VillageStatusInner;

		// Token: 0x0401D99F RID: 121247
		[Nullable(2)]
		private VillageInfrActivityData ActivityData;

		// Token: 0x0401D9A0 RID: 121248
		private List<int> TreeFinishConditions = new List<int>();
	}
}
