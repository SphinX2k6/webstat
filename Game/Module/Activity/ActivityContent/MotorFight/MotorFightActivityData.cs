using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066C3 RID: 26307
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightActivityData : ActivityBaseData
	{
		// Token: 0x06041AEC RID: 269036 RVA: 0x010D8184 File Offset: 0x010D6384
		protected override void OnInit(ActivityData data)
		{
			if (data.MotorFightActivityPb == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.MotorFightActivity, ELogAuthor.CXJ, "摩托战斗活动数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.TalentTreeItemId = ConfigBase<MotorFightConfig>.Instance.GetMotorFightActivityConfig(base.Id).Value.TalentTreeItemId;
			this.InitLevelData();
			this.InitTaskData();
			this.InitMotorFightItemData();
			this.InitMotorFightTalentData();
			this.InitRoleData();
		}

		// Token: 0x06041AED RID: 269037 RVA: 0x010D8200 File Offset: 0x010D6400
		protected override void PhraseEx(ActivityData data)
		{
			MotorFightActivityPb motorFightActivityPb = data.MotorFightActivityPb;
			if (motorFightActivityPb == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.MotorFightActivity, ELogAuthor.CXJ, "摩托战斗活动数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.UpdateLevelDataList(motorFightActivityPb.MotorFightLevelPb, false);
			this.UpdateTaskData(motorFightActivityPb.Task, false);
			this.UpdateMotorFightItemDataList(motorFightActivityPb.UnlockedItem, false);
			if (motorFightActivityPb.TalentTree != null)
			{
				this.UpdateMotorFightTalentDataList(motorFightActivityPb.TalentTree.Talent, false);
			}
			this.UpdateRoleData(motorFightActivityPb.UnlockedRole, false);
		}

		// Token: 0x06041AEE RID: 269038 RVA: 0x010D8285 File Offset: 0x010D6485
		public override bool GetExDataRedPointShowState()
		{
			return base.IsUnLock() && (this.IsLevelHasRedDot() || this.IsTaskHasRedDot() || this.IsTalentTreeHasRedDot() || this.IsHandBookHasRedDot());
		}

		// Token: 0x06041AEF RID: 269039 RVA: 0x010D82B4 File Offset: 0x010D64B4
		protected override bool GetExDataFinishShowState()
		{
			using (Dictionary<int, MotorFightLevelData>.ValueCollection.Enumerator enumerator = this.LevelDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsFinished)
					{
						return false;
					}
				}
			}
			using (Dictionary<int, MotorFightTaskData>.ValueCollection.Enumerator enumerator2 = this.TaskDataMap.Values.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (!enumerator2.Current.IsFinished)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06041AF0 RID: 269040 RVA: 0x010D835C File Offset: 0x010D655C
		private void InitLevelData()
		{
			foreach (MotorFightLevel config in ConfigMotorFightLevelByActivityId.GetConfigList(base.Id, true))
			{
				MotorFightLevelData motorFightLevelData = new MotorFightLevelData(config);
				this.LevelDataMap[config.Id] = motorFightLevelData;
				while (this.LevelTreeList.Count <= motorFightLevelData.Column)
				{
					this.LevelTreeList.Add(new List<MotorFightLevelData>());
				}
				this.LevelTreeList[motorFightLevelData.Column].Add(motorFightLevelData);
			}
			using (List<List<MotorFightLevelData>>.Enumerator enumerator2 = this.LevelTreeList.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					enumerator2.Current.Sort((MotorFightLevelData a, MotorFightLevelData b) => a.Row - b.Row);
				}
			}
			foreach (MotorFightLevelData motorFightLevelData2 in this.LevelDataMap.Values)
			{
				if (motorFightLevelData2.PreLevelIds.Count > 0)
				{
					motorFightLevelData2.PreMotorFightLevelData = this.GetLevelDataById(motorFightLevelData2.PreLevelIds[0]);
				}
			}
		}

		// Token: 0x06041AF1 RID: 269041 RVA: 0x010D84C8 File Offset: 0x010D66C8
		[NullableContext(2)]
		public MotorFightLevelData GetLevelDataById(int id)
		{
			MotorFightLevelData result;
			if (this.LevelDataMap.TryGetValue(id, out result))
			{
				return result;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MotorFightActivity;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "摩托战斗关卡数据不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x06041AF2 RID: 269042 RVA: 0x010D8518 File Offset: 0x010D6718
		public void UpdateLevelDataList(IReadOnlyList<MotorFightLevelPb> levelInfoList, bool needEmit = false)
		{
			foreach (MotorFightLevelPb motorFightLevelPb in levelInfoList)
			{
				MotorFightLevelData levelDataById = this.GetLevelDataById(motorFightLevelPb.LevelId);
				if (levelDataById != null)
				{
					levelDataById.UnlockTime = motorFightLevelPb.OpenTime;
					levelDataById.BestScore = motorFightLevelPb.BestScore;
					levelDataById.IsFinished = motorFightLevelPb.Cleared;
					levelDataById.RoleId = motorFightLevelPb.LastRoleId;
				}
			}
			if (needEmit)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			}
		}

		// Token: 0x06041AF3 RID: 269043 RVA: 0x010D85B4 File Offset: 0x010D67B4
		public bool IsLevelHasRedDot()
		{
			using (Dictionary<int, MotorFightLevelData>.ValueCollection.Enumerator enumerator = this.LevelDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HasLevelRedDot)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06041AF4 RID: 269044 RVA: 0x010D8614 File Offset: 0x010D6814
		public bool IsEndlessLevelUnlock()
		{
			foreach (MotorFightLevelData motorFightLevelData in this.LevelDataMap.Values)
			{
				if (motorFightLevelData.Type == EMotorFightLevelType.Endless && motorFightLevelData.IsUnLock)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06041AF5 RID: 269045 RVA: 0x010D8680 File Offset: 0x010D6880
		public List<List<MotorFightLevelData>> GetLevelTreeList()
		{
			return this.LevelTreeList;
		}

		// Token: 0x06041AF6 RID: 269046 RVA: 0x010D8688 File Offset: 0x010D6888
		public void SetLastSavedLevelData(MotorFightLastSaveData lastSavedLevelData)
		{
			this.LastSavedLevelData = lastSavedLevelData;
		}

		// Token: 0x06041AF7 RID: 269047 RVA: 0x010D8691 File Offset: 0x010D6891
		[NullableContext(2)]
		public MotorFightLastSaveData GetLastSavedLevelData()
		{
			return this.LastSavedLevelData;
		}

		// Token: 0x06041AF8 RID: 269048 RVA: 0x010D8699 File Offset: 0x010D6899
		public bool HasLastSavedLevelData()
		{
			return this.LastSavedLevelData != null;
		}

		// Token: 0x06041AF9 RID: 269049 RVA: 0x010D86A4 File Offset: 0x010D68A4
		private void InitTaskData()
		{
			foreach (MotorFightTask config in ConfigMotorFightTaskByActivityId.GetConfigList(base.Id, true))
			{
				MotorFightTaskData motorFightTaskData = new MotorFightTaskData(config);
				this.TaskDataMap[config.Id] = motorFightTaskData;
				if (!this.TabToTaskDataListMap.ContainsKey(config.PageType))
				{
					this.TabToTaskDataListMap[config.PageType] = new List<MotorFightTaskData>();
				}
				this.TabToTaskDataListMap[config.PageType].Add(motorFightTaskData);
			}
		}

		// Token: 0x06041AFA RID: 269050 RVA: 0x010D8750 File Offset: 0x010D6950
		[NullableContext(2)]
		private MotorFightTaskData GetMotorFightTaskData(int taskId)
		{
			MotorFightTaskData result;
			if (this.TaskDataMap.TryGetValue(taskId, out result))
			{
				return result;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MotorFightActivity;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "摩托战斗任务配置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("taskId", taskId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x06041AFB RID: 269051 RVA: 0x010D87A0 File Offset: 0x010D69A0
		public void UpdateTaskData(IReadOnlyList<ConditionTask> taskList, bool needEmit = false)
		{
			foreach (ConditionTask conditionTask in taskList)
			{
				MotorFightTaskData motorFightTaskData = this.GetMotorFightTaskData(conditionTask.Id);
				motorFightTaskData.Status = TaskStateResolver.ConditionState[conditionTask.Status];
				motorFightTaskData.Current = conditionTask.Current;
				motorFightTaskData.Target = conditionTask.Target;
			}
			if (needEmit)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			}
		}

		// Token: 0x06041AFC RID: 269052 RVA: 0x010D8834 File Offset: 0x010D6A34
		public void RequestTaskReward(int tabId)
		{
			List<MotorFightTaskData> taskDataList = this.GetTaskDataList(tabId);
			List<int> list = new List<int>();
			foreach (MotorFightTaskData motorFightTaskData in taskDataList)
			{
				if (motorFightTaskData.IsUnclaimed)
				{
					list.Add(motorFightTaskData.Id);
				}
			}
			ControllerBase<MotorFightController>.Instance.RequestTaskReward(list);
		}

		// Token: 0x06041AFD RID: 269053 RVA: 0x010D88A8 File Offset: 0x010D6AA8
		public void UpdateTaskRewardStatus(List<ConditionTask> taskInfoList, bool needEmit = false)
		{
			foreach (ConditionTask conditionTask in taskInfoList)
			{
				this.GetMotorFightTaskData(conditionTask.Id).Status = TaskStateResolver.ConditionState[conditionTask.Status];
			}
			if (needEmit)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			}
		}

		// Token: 0x06041AFE RID: 269054 RVA: 0x010D892C File Offset: 0x010D6B2C
		public void GetTaskReward(List<int> taskIds)
		{
			foreach (int taskId in taskIds)
			{
				this.GetMotorFightTaskData(taskId).Status = EActivityTaskState.FinishedAndClaimed;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06041AFF RID: 269055 RVA: 0x010D8998 File Offset: 0x010D6B98
		public bool IsTaskHasRedDot()
		{
			using (Dictionary<int, MotorFightTaskData>.ValueCollection.Enumerator enumerator = this.TaskDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnclaimed)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06041B00 RID: 269056 RVA: 0x010D89F8 File Offset: 0x010D6BF8
		public bool IsTaskHasRedDotByTab(int tabId)
		{
			List<MotorFightTaskData> list;
			using (List<MotorFightTaskData>.Enumerator enumerator = (this.TabToTaskDataListMap.TryGetValue(tabId, out list) ? list : new List<MotorFightTaskData>()).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnclaimed)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06041B01 RID: 269057 RVA: 0x010D8A64 File Offset: 0x010D6C64
		public List<MotorFightTaskData> GetTaskDataList(int tabId)
		{
			List<MotorFightTaskData> list2;
			List<MotorFightTaskData> list = this.TabToTaskDataListMap.TryGetValue(tabId, out list2) ? list2 : new List<MotorFightTaskData>();
			list.Sort(new Comparison<MotorFightTaskData>(this.SortTaskData));
			return list;
		}

		// Token: 0x06041B02 RID: 269058 RVA: 0x010D8A9B File Offset: 0x010D6C9B
		private int SortTaskData(MotorFightTaskData a, MotorFightTaskData b)
		{
			if (a.Status != b.Status)
			{
				return a.Status - b.Status;
			}
			return a.Id - b.Id;
		}

		// Token: 0x06041B03 RID: 269059 RVA: 0x010D8AC6 File Offset: 0x010D6CC6
		public int GetTotalTaskNum()
		{
			return this.TaskDataMap.Count;
		}

		// Token: 0x06041B04 RID: 269060 RVA: 0x010D8AD4 File Offset: 0x010D6CD4
		public int GetFinishedTaskNum()
		{
			int num = 0;
			using (Dictionary<int, MotorFightTaskData>.ValueCollection.Enumerator enumerator = this.TaskDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsFinished)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06041B05 RID: 269061 RVA: 0x010D8B34 File Offset: 0x010D6D34
		public List<MotorFightTaskTab> GetMotorFightTaskTabList()
		{
			if (this.MotorFightTaskTabList.Count == 0)
			{
				IReadOnlyList<MotorFightTaskTab> configList = ConfigMotorFightTaskTabByActivityId.GetConfigList(base.Id, true);
				this.MotorFightTaskTabList = new List<MotorFightTaskTab>(configList);
			}
			return this.MotorFightTaskTabList;
		}

		// Token: 0x06041B06 RID: 269062 RVA: 0x010D8B70 File Offset: 0x010D6D70
		private void InitMotorFightItemData()
		{
			foreach (MotorFightItem config in ConfigMotorFightItemByActivityId.GetConfigList(base.Id, true))
			{
				if (config.IsShowInHandBook)
				{
					MotorFightItemData motorFightItemData = new MotorFightItemData(config, null);
					this.ItemDataMap[config.Id] = motorFightItemData;
					int type = config.Type;
					if (!this.TypeToItemDataMap.ContainsKey(type))
					{
						this.TypeToItemDataMap[type] = new List<MotorFightItemData>();
					}
					this.TypeToItemDataMap[type].Add(motorFightItemData);
				}
			}
		}

		// Token: 0x06041B07 RID: 269063 RVA: 0x010D8C24 File Offset: 0x010D6E24
		public void UpdateMotorFightItemDataList(IReadOnlyList<int> itemIdList, bool needEmit = false)
		{
			foreach (int itemId in itemIdList)
			{
				this.UpdateMotorFightItemData(itemId);
			}
			if (needEmit)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			}
		}

		// Token: 0x06041B08 RID: 269064 RVA: 0x010D8C88 File Offset: 0x010D6E88
		public void UpdateMotorFightItemData(int itemId)
		{
			MotorFightItemData motorFightItemData = this.GetMotorFightItemData(itemId);
			if (motorFightItemData == null)
			{
				return;
			}
			motorFightItemData.IsUnLock = true;
		}

		// Token: 0x06041B09 RID: 269065 RVA: 0x010D8CA8 File Offset: 0x010D6EA8
		[NullableContext(2)]
		public MotorFightItemData GetMotorFightItemData(int id)
		{
			MotorFightItemData result;
			if (this.ItemDataMap.TryGetValue(id, out result))
			{
				return result;
			}
			if (ConfigBase<MotorFightConfig>.Instance.GetMotorFightItemConfig(id).Value.IsShowInHandBook)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorFightActivity;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "获取MotorFightItemData失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return null;
		}

		// Token: 0x06041B0A RID: 269066 RVA: 0x010D8D14 File Offset: 0x010D6F14
		public Tuple<int, int> GetItemUnlockNum(int type)
		{
			int num = 0;
			List<MotorFightItemData> list;
			if (!this.TypeToItemDataMap.TryGetValue(type, out list))
			{
				return new Tuple<int, int>(0, 0);
			}
			using (List<MotorFightItemData>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnLock)
					{
						num++;
					}
				}
			}
			return new Tuple<int, int>(num, list.Count);
		}

		// Token: 0x06041B0B RID: 269067 RVA: 0x010D8D8C File Offset: 0x010D6F8C
		[NullableContext(0)]
		public ValueTuple<int, int> GetAllItemUnlockNum()
		{
			int num = 0;
			using (Dictionary<int, MotorFightItemData>.ValueCollection.Enumerator enumerator = this.ItemDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnLock)
					{
						num++;
					}
				}
			}
			return new ValueTuple<int, int>(num, this.ItemDataMap.Count);
		}

		// Token: 0x06041B0C RID: 269068 RVA: 0x010D8DFC File Offset: 0x010D6FFC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<MotorFightItemData> GetMotorFightItemDataListByType(int type)
		{
			List<MotorFightItemData> source;
			if (!this.TypeToItemDataMap.TryGetValue(type, out source))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorFightActivity;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "通过类型获取MotorFightItemDataList失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TypeId", type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return (from x in source
			orderby x.IsUnLock descending, x.Quality descending, x.Id
			select x).ToList<MotorFightItemData>();
		}

		// Token: 0x06041B0D RID: 269069 RVA: 0x010D8EBC File Offset: 0x010D70BC
		public bool IsHandBookHasRedDot()
		{
			using (Dictionary<int, MotorFightItemData>.ValueCollection.Enumerator enumerator = this.ItemDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HasItemRedDot)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06041B0E RID: 269070 RVA: 0x010D8F1C File Offset: 0x010D711C
		public void ReadHandBookRedDot()
		{
			foreach (MotorFightItemData motorFightItemData in this.ItemDataMap.Values)
			{
				if (motorFightItemData.HasItemRedDot)
				{
					motorFightItemData.ReadItemRedDot();
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06041B0F RID: 269071 RVA: 0x010D8F94 File Offset: 0x010D7194
		public List<MotorFightItemType> GetMotorFightItemTypeList()
		{
			if (this.MotorFightItemTypeList.Count == 0)
			{
				IReadOnlyList<MotorFightItemType> configList = ConfigMotorFightItemTypeAll.GetConfigList(true);
				this.MotorFightItemTypeList = new List<MotorFightItemType>(configList);
			}
			return this.MotorFightItemTypeList;
		}

		// Token: 0x06041B10 RID: 269072 RVA: 0x010D8FC8 File Offset: 0x010D71C8
		private void InitMotorFightTalentData()
		{
			foreach (MotorFightTalent config in ConfigMotorFightTalentByActivityId.GetConfigList(base.Id, true))
			{
				MotorFightTalentData motorFightTalentData = new MotorFightTalentData(config);
				this.TalentDataMap[config.Id] = motorFightTalentData;
				this.TalentList.Add(motorFightTalentData);
				while (this.TalentTreeList.Count <= motorFightTalentData.Column)
				{
					this.TalentTreeList.Add(new List<MotorFightTalentData>());
				}
				this.TalentTreeList[motorFightTalentData.Column].Add(motorFightTalentData);
			}
			foreach (List<MotorFightTalentData> list in this.TalentTreeList)
			{
				if (list != null)
				{
					list.Sort((MotorFightTalentData a, MotorFightTalentData b) => a.Row - b.Row);
				}
			}
			this.TalentList.Sort((MotorFightTalentData a, MotorFightTalentData b) => a.Id - b.Id);
		}

		// Token: 0x06041B11 RID: 269073 RVA: 0x010D9104 File Offset: 0x010D7304
		public void UpdateMotorFightTalentDataList(IReadOnlyList<MotorFightTalentPb> talentInfoList, bool needEmit = false)
		{
			foreach (MotorFightTalentPb motorFightTalentPb in talentInfoList)
			{
				MotorFightTalentData motorFightTalentData = this.GetMotorFightTalentData(motorFightTalentPb.Id);
				if (motorFightTalentData != null)
				{
					motorFightTalentData.IsFinishPreCondition = motorFightTalentPb.Unlock;
					motorFightTalentData.IsUnLock = motorFightTalentPb.InUse;
				}
			}
			if (needEmit)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			}
		}

		// Token: 0x06041B12 RID: 269074 RVA: 0x010D9188 File Offset: 0x010D7388
		public void UpdateMotorFightTalentData(int talentId)
		{
			MotorFightTalentData motorFightTalentData = this.GetMotorFightTalentData(talentId);
			if (motorFightTalentData == null)
			{
				return;
			}
			motorFightTalentData.IsUnLock = true;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06041B13 RID: 269075 RVA: 0x010D91C0 File Offset: 0x010D73C0
		[NullableContext(2)]
		public MotorFightTalentData GetMotorFightTalentData(int id)
		{
			MotorFightTalentData result;
			if (this.TalentDataMap.TryGetValue(id, out result))
			{
				return result;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MotorFightActivity;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "获取MotorFightTalentData失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x06041B14 RID: 269076 RVA: 0x010D920F File Offset: 0x010D740F
		public List<List<MotorFightTalentData>> GetTalentTreeList()
		{
			return this.TalentTreeList;
		}

		// Token: 0x06041B15 RID: 269077 RVA: 0x010D9218 File Offset: 0x010D7418
		public string GetTalentProgress()
		{
			int count = this.TalentDataMap.Count;
			int num = 0;
			using (Dictionary<int, MotorFightTalentData>.ValueCollection.Enumerator enumerator = this.TalentDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnLock)
					{
						num++;
					}
				}
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(count);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06041B16 RID: 269078 RVA: 0x010D92B0 File Offset: 0x010D74B0
		public int GetTalentCoinNum()
		{
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.TalentTreeItemId, 0);
		}

		// Token: 0x06041B17 RID: 269079 RVA: 0x010D92C4 File Offset: 0x010D74C4
		public unsafe bool IsPreNodeAllUnlock(MotorFightTalentData data)
		{
			Span<int> preNode = data.PreNode;
			for (int i = 0; i < preNode.Length; i++)
			{
				int id = *preNode[i];
				MotorFightTalentData motorFightTalentData = this.GetMotorFightTalentData(id);
				if (motorFightTalentData == null || !motorFightTalentData.IsUnLock)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06041B18 RID: 269080 RVA: 0x010D930F File Offset: 0x010D750F
		public bool IsTalentCanUnlock(MotorFightTalentData data)
		{
			return !data.IsUnLock && data.IsFinishPreCondition && this.IsPreNodeAllUnlock(data) && this.GetTalentCoinNum() >= data.Cost;
		}

		// Token: 0x06041B19 RID: 269081 RVA: 0x010D933C File Offset: 0x010D753C
		public bool IsTalentTreeHasRedDot()
		{
			foreach (MotorFightTalentData data in this.TalentDataMap.Values)
			{
				if (this.IsTalentCanUnlock(data))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06041B1A RID: 269082 RVA: 0x010D93A0 File Offset: 0x010D75A0
		public int GetNextCanUnlockTalentId()
		{
			int num = -1;
			foreach (MotorFightTalentData motorFightTalentData in this.TalentList)
			{
				if (num == -1 && !motorFightTalentData.IsUnLock)
				{
					num = motorFightTalentData.Id;
				}
				if (this.IsTalentCanUnlock(motorFightTalentData))
				{
					return motorFightTalentData.Id;
				}
			}
			if (num != -1)
			{
				return num;
			}
			return this.TalentList.Last<MotorFightTalentData>().Id;
		}

		// Token: 0x1700A052 RID: 41042
		// (get) Token: 0x06041B1B RID: 269083 RVA: 0x010D942C File Offset: 0x010D762C
		// (set) Token: 0x06041B1C RID: 269084 RVA: 0x010D9448 File Offset: 0x010D7648
		public int SelectedTalentNodeId
		{
			get
			{
				if (this.SelectedTalentNodeIdInternal == 0)
				{
					this.SelectedTalentNodeIdInternal = this.GetNextCanUnlockTalentId();
				}
				return this.SelectedTalentNodeIdInternal;
			}
			set
			{
				this.SelectedTalentNodeIdInternal = value;
			}
		}

		// Token: 0x06041B1D RID: 269085 RVA: 0x010D9454 File Offset: 0x010D7654
		private void InitRoleData()
		{
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			foreach (MotorFightRole config in ConfigBase<MotorFightConfig>.Instance.GetMotorFightRoleList(base.Id))
			{
				MotorFightRoleData motorFightRoleData = new MotorFightRoleData(config);
				this.RoleMap[config.Id] = motorFightRoleData;
				if (this.CheckRoleIsValid((EMotorFightRoleType)config.Type, playerGender))
				{
					this.RoleList.Add(motorFightRoleData);
				}
			}
			this.RoleList.Sort((MotorFightRoleData a, MotorFightRoleData b) => a.Id - b.Id);
		}

		// Token: 0x06041B1E RID: 269086 RVA: 0x010D9510 File Offset: 0x010D7710
		private bool CheckRoleIsValid(EMotorFightRoleType type, EPlayerGender gender)
		{
			return type == EMotorFightRoleType.Normal || (type == EMotorFightRoleType.MainRoleMale && gender == EPlayerGender.Male) || (type == EMotorFightRoleType.MainRoleFemale && gender == EPlayerGender.Female);
		}

		// Token: 0x06041B1F RID: 269087 RVA: 0x010D9528 File Offset: 0x010D7728
		[NullableContext(2)]
		public MotorFightRoleData GetMotorFightRoleData(int id)
		{
			MotorFightRoleData result;
			if (this.RoleMap.TryGetValue(id, out result))
			{
				return result;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MotorFightActivity;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "获取MotorFightRoleData失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x06041B20 RID: 269088 RVA: 0x010D9578 File Offset: 0x010D7778
		public void UpdateRoleData(IReadOnlyList<int> roleIds, bool needEmit = false)
		{
			foreach (int id in roleIds)
			{
				MotorFightRoleData motorFightRoleData = this.GetMotorFightRoleData(id);
				if (motorFightRoleData != null)
				{
					motorFightRoleData.IsUnLock = true;
				}
			}
			if (needEmit)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			}
		}

		// Token: 0x06041B21 RID: 269089 RVA: 0x010D95E4 File Offset: 0x010D77E4
		public List<MotorFightRoleData> GetMotorFightRoleList()
		{
			return this.RoleList;
		}

		// Token: 0x06041B22 RID: 269090 RVA: 0x010D95EC File Offset: 0x010D77EC
		public int GetLevelUsedRole(int levelId)
		{
			int id = this.RoleList[0].Id;
			MotorFightLevelData levelDataById = this.GetLevelDataById(levelId);
			if (levelDataById.RoleId != 0)
			{
				return levelDataById.RoleId;
			}
			int num = (levelDataById.PreLevelIds.Count > 0) ? levelDataById.PreLevelIds[0] : 0;
			if (num == 0)
			{
				return id;
			}
			MotorFightLevelData levelDataById2 = this.GetLevelDataById(num);
			if (levelDataById2.RoleId != 0)
			{
				return levelDataById2.RoleId;
			}
			return id;
		}

		// Token: 0x06041B23 RID: 269091 RVA: 0x010D9660 File Offset: 0x010D7860
		public bool IsRoleHasRedDot()
		{
			using (Dictionary<int, MotorFightRoleData>.ValueCollection.Enumerator enumerator = this.RoleMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HasRedDot)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06041B24 RID: 269092 RVA: 0x010D96C0 File Offset: 0x010D78C0
		public void UpdateFriendsRankList(IReadOnlyList<MotorFightPlayerRankingInfo> list)
		{
			this.MotorFightFriendsRankList = new List<MotorFightRankData>();
			foreach (MotorFightPlayerRankingInfo dataByServerInfo in list)
			{
				MotorFightRankData motorFightRankData = new MotorFightRankData(false);
				motorFightRankData.SetDataByServerInfo(dataByServerInfo);
				this.MotorFightFriendsRankList.Add(motorFightRankData);
			}
		}

		// Token: 0x06041B25 RID: 269093 RVA: 0x010D9728 File Offset: 0x010D7928
		[NullableContext(2)]
		public void UpdateMyRank(MotorFightPlayerRankingInfo rankInfo)
		{
			this.MyRankData.SetDataByServerInfo(rankInfo);
		}

		// Token: 0x06041B26 RID: 269094 RVA: 0x010D9738 File Offset: 0x010D7938
		private List<MotorFightRankData> GetRobotRankList()
		{
			if (this.MotorFightRobotRankList.Count == 0)
			{
				foreach (MotorFightRank dataByConfig in ConfigBase<MotorFightConfig>.Instance.GetMotorFightRobotRankList())
				{
					MotorFightRankData motorFightRankData = new MotorFightRankData(false);
					motorFightRankData.SetDataByConfig(dataByConfig);
					this.MotorFightRobotRankList.Add(motorFightRankData);
				}
			}
			return this.MotorFightRobotRankList;
		}

		// Token: 0x06041B27 RID: 269095 RVA: 0x010D97B0 File Offset: 0x010D79B0
		public List<MotorFightRankData> GetRankList()
		{
			List<MotorFightRankData> list = new List<MotorFightRankData>(this.MotorFightFriendsRankList);
			if (this.MyRankData.HasData)
			{
				list.Add(this.MyRankData);
			}
			int count = list.Count;
			foreach (MotorFightRankData motorFightRankData in this.GetRobotRankList())
			{
				if (count < motorFightRankData.DisplayThreshold)
				{
					list.Add(motorFightRankData);
				}
			}
			list.Sort((MotorFightRankData a, MotorFightRankData b) => b.Score - a.Score);
			return list;
		}

		// Token: 0x04024A8F RID: 150159
		private readonly Dictionary<int, MotorFightLevelData> LevelDataMap = new Dictionary<int, MotorFightLevelData>();

		// Token: 0x04024A90 RID: 150160
		private List<List<MotorFightLevelData>> LevelTreeList = new List<List<MotorFightLevelData>>();

		// Token: 0x04024A91 RID: 150161
		private MotorFightLastSaveData LastSavedLevelData;

		// Token: 0x04024A92 RID: 150162
		private readonly Dictionary<int, MotorFightTaskData> TaskDataMap = new Dictionary<int, MotorFightTaskData>();

		// Token: 0x04024A93 RID: 150163
		private readonly Dictionary<int, List<MotorFightTaskData>> TabToTaskDataListMap = new Dictionary<int, List<MotorFightTaskData>>();

		// Token: 0x04024A94 RID: 150164
		private List<MotorFightTaskTab> MotorFightTaskTabList = new List<MotorFightTaskTab>();

		// Token: 0x04024A95 RID: 150165
		private readonly Dictionary<int, MotorFightItemData> ItemDataMap = new Dictionary<int, MotorFightItemData>();

		// Token: 0x04024A96 RID: 150166
		private readonly Dictionary<int, List<MotorFightItemData>> TypeToItemDataMap = new Dictionary<int, List<MotorFightItemData>>();

		// Token: 0x04024A97 RID: 150167
		private List<MotorFightItemType> MotorFightItemTypeList = new List<MotorFightItemType>();

		// Token: 0x04024A98 RID: 150168
		private readonly Dictionary<int, MotorFightTalentData> TalentDataMap = new Dictionary<int, MotorFightTalentData>();

		// Token: 0x04024A99 RID: 150169
		private readonly List<MotorFightTalentData> TalentList = new List<MotorFightTalentData>();

		// Token: 0x04024A9A RID: 150170
		private List<List<MotorFightTalentData>> TalentTreeList = new List<List<MotorFightTalentData>>();

		// Token: 0x04024A9B RID: 150171
		public int TalentTreeItemId;

		// Token: 0x04024A9C RID: 150172
		private int SelectedTalentNodeIdInternal;

		// Token: 0x04024A9D RID: 150173
		private readonly Dictionary<int, MotorFightRoleData> RoleMap = new Dictionary<int, MotorFightRoleData>();

		// Token: 0x04024A9E RID: 150174
		private readonly List<MotorFightRoleData> RoleList = new List<MotorFightRoleData>();

		// Token: 0x04024A9F RID: 150175
		private List<MotorFightRankData> MotorFightFriendsRankList = new List<MotorFightRankData>();

		// Token: 0x04024AA0 RID: 150176
		private readonly List<MotorFightRankData> MotorFightRobotRankList = new List<MotorFightRankData>();

		// Token: 0x04024AA1 RID: 150177
		public readonly MotorFightRankData MyRankData = new MotorFightRankData(true);
	}
}
