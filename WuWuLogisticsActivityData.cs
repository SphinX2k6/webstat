using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x0200170E RID: 5902
[NullableContext(1)]
[Nullable(0)]
public class WuWuLogisticsActivityData : ActivityBaseData
{
	// Token: 0x0600A415 RID: 42005 RVA: 0x002B5E94 File Offset: 0x002B4094
	protected override void PhraseEx(ActivityData data)
	{
		if (data == null)
		{
			return;
		}
		WuWuWeekActivity wuWuWeekActivity = data.WuWuWeekActivity;
		if (wuWuWeekActivity == null)
		{
			return;
		}
		if (wuWuWeekActivity.ConditionTasks != null)
		{
			foreach (ConditionTask taskInfo in wuWuWeekActivity.ConditionTasks)
			{
				this.UpdateTaskData(taskInfo, 0);
			}
		}
		if (wuWuWeekActivity.TaskPack != null)
		{
			foreach (WuWuTaskPack packInfo in wuWuWeekActivity.TaskPack)
			{
				this.UpdateTaskPackData(packInfo);
			}
		}
	}

	// Token: 0x0600A416 RID: 42006 RVA: 0x002B5F40 File Offset: 0x002B4140
	public void UpdateTaskData(ConditionTask taskInfo, int taskPackId = 0)
	{
		if (taskInfo == null)
		{
			return;
		}
		int id = taskInfo.Id;
		WuWuTaskData wuWuTaskData;
		if (!this.TaskMap.TryGetValue(id, out wuWuTaskData))
		{
			wuWuTaskData = new WuWuTaskData();
			this.TaskMap[id] = wuWuTaskData;
		}
		wuWuTaskData.TaskId = id;
		wuWuTaskData.TaskPackId = taskPackId;
		wuWuTaskData.Progress = taskInfo.Current;
		wuWuTaskData.TargetProgress = taskInfo.Target;
		wuWuTaskData.State = this.ConvertTaskState(taskInfo.Status);
	}

	// Token: 0x0600A417 RID: 42007 RVA: 0x002B5FB4 File Offset: 0x002B41B4
	private void UpdateTaskPackData(WuWuTaskPack packInfo)
	{
		if (packInfo == null)
		{
			return;
		}
		int wuWuPackageId = packInfo.WuWuPackageId;
		WuWuTaskPackData wuWuTaskPackData;
		if (!this.TaskPackMap.TryGetValue(wuWuPackageId, out wuWuTaskPackData))
		{
			wuWuTaskPackData = new WuWuTaskPackData();
			this.TaskPackMap[wuWuPackageId] = wuWuTaskPackData;
			IReadOnlyList<WuWuTaskPackage> allTaskPackage = ConfigBase<WuWuLogisticsConfig>.Instance.GetAllTaskPackage();
			if (allTaskPackage != null)
			{
				int prePackCfgId = 0;
				foreach (WuWuTaskPackage wuWuTaskPackage in allTaskPackage)
				{
					if (wuWuTaskPackage.Id == wuWuPackageId)
					{
						break;
					}
					prePackCfgId = wuWuTaskPackage.Id;
				}
				wuWuTaskPackData.PrePackCfgId = prePackCfgId;
			}
		}
		wuWuTaskPackData.TaskPackId = wuWuPackageId;
		wuWuTaskPackData.UnlockTime = packInfo.UnLockTime;
		wuWuTaskPackData.HadReward = packInfo.HadReward;
	}

	// Token: 0x0600A418 RID: 42008 RVA: 0x002B6074 File Offset: 0x002B4274
	private EWuWuTaskState ConvertTaskState(ConditionTaskState protoState)
	{
		if (protoState == ConditionTaskState.ConditionTaskFinish)
		{
			return EWuWuTaskState.Finish;
		}
		if (protoState != ConditionTaskState.ConditionTaskTaken)
		{
			return EWuWuTaskState.Running;
		}
		return EWuWuTaskState.Taken;
	}

	// Token: 0x0600A419 RID: 42009 RVA: 0x002B6088 File Offset: 0x002B4288
	[NullableContext(2)]
	public WuWuTaskData GetTaskById(int taskId)
	{
		WuWuTaskData result;
		if (!this.TaskMap.TryGetValue(taskId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600A41A RID: 42010 RVA: 0x002B60A8 File Offset: 0x002B42A8
	[NullableContext(2)]
	public WuWuTaskPackData GetTaskPackById(int taskPackId)
	{
		WuWuTaskPackData result;
		if (!this.TaskPackMap.TryGetValue(taskPackId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600A41B RID: 42011 RVA: 0x002B60C8 File Offset: 0x002B42C8
	public bool HasRewardToClaim()
	{
		foreach (WuWuTaskData wuWuTaskData in this.TaskMap.Values)
		{
			if (this.IsPackUnlocked(wuWuTaskData.TaskPackId) && wuWuTaskData.CanReceiveReward)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600A41C RID: 42012 RVA: 0x002B6138 File Offset: 0x002B4338
	public int GetCompletedPackCount()
	{
		int num = 0;
		foreach (WuWuTaskPackData wuWuTaskPackData in this.TaskPackMap.Values)
		{
			if (this.TargetPackIsFullyRewarded(wuWuTaskPackData.TaskPackId))
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x0600A41D RID: 42013 RVA: 0x002B61A0 File Offset: 0x002B43A0
	public int GetTotalTaskCount()
	{
		return this.TaskMap.Count;
	}

	// Token: 0x0600A41E RID: 42014 RVA: 0x002B61AD File Offset: 0x002B43AD
	public int GetTotalTaskPackCount()
	{
		return this.TaskPackMap.Count;
	}

	// Token: 0x0600A41F RID: 42015 RVA: 0x002B61BC File Offset: 0x002B43BC
	public bool TargetPackIsAllCompleted(int packId)
	{
		IReadOnlyList<WuWuWeekTask> weekTaskByWrapId = ConfigBase<WuWuLogisticsConfig>.Instance.GetWeekTaskByWrapId(packId);
		if (weekTaskByWrapId == null)
		{
			return false;
		}
		foreach (WuWuWeekTask wuWuWeekTask in weekTaskByWrapId)
		{
			WuWuTaskData taskById = this.GetTaskById(wuWuWeekTask.Id);
			if (taskById == null)
			{
				return false;
			}
			if (!taskById.IsCompleted)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600A420 RID: 42016 RVA: 0x002B6238 File Offset: 0x002B4438
	public bool TargetPackIsAllRewarded(int packId)
	{
		IReadOnlyList<WuWuWeekTask> weekTaskByWrapId = ConfigBase<WuWuLogisticsConfig>.Instance.GetWeekTaskByWrapId(packId);
		if (weekTaskByWrapId == null)
		{
			return false;
		}
		foreach (WuWuWeekTask wuWuWeekTask in weekTaskByWrapId)
		{
			WuWuTaskData taskById = this.GetTaskById(wuWuWeekTask.Id);
			if (taskById == null)
			{
				return false;
			}
			if (!taskById.IsRewarded)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600A421 RID: 42017 RVA: 0x002B62B4 File Offset: 0x002B44B4
	public bool TargetPackIsFullyRewarded(int packId)
	{
		WuWuTaskPackData taskPackById = this.GetTaskPackById(packId);
		return taskPackById != null && this.TargetPackIsAllRewarded(packId) && taskPackById.HadReward;
	}

	// Token: 0x0600A422 RID: 42018 RVA: 0x002B62E0 File Offset: 0x002B44E0
	public bool TargetPackChildTaskHasReceiveReward(int packId)
	{
		IReadOnlyList<WuWuWeekTask> weekTaskByWrapId = ConfigBase<WuWuLogisticsConfig>.Instance.GetWeekTaskByWrapId(packId);
		if (weekTaskByWrapId == null)
		{
			return false;
		}
		foreach (WuWuWeekTask wuWuWeekTask in weekTaskByWrapId)
		{
			WuWuTaskData taskById = this.GetTaskById(wuWuWeekTask.Id);
			if (taskById == null)
			{
				return false;
			}
			if (taskById.CanReceiveReward)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600A423 RID: 42019 RVA: 0x002B635C File Offset: 0x002B455C
	public bool TargetPackHasReceiveReward(int packId)
	{
		WuWuTaskPackData taskPackById = this.GetTaskPackById(packId);
		return taskPackById != null && !taskPackById.HadReward && this.TargetPackIsAllCompleted(packId);
	}

	// Token: 0x0600A424 RID: 42020 RVA: 0x002B6388 File Offset: 0x002B4588
	public bool IsPackUnlocked(int packId)
	{
		WuWuTaskPackData taskPackById = this.GetTaskPackById(packId);
		return taskPackById != null && taskPackById.IsUnlock && (taskPackById.PrePackCfgId == 0 || (taskPackById.PrePackCfgId > 0 && this.TargetPackIsAllCompleted(taskPackById.PrePackCfgId)));
	}

	// Token: 0x0600A425 RID: 42021 RVA: 0x002B63CC File Offset: 0x002B45CC
	public int GetDefaultOpenPackCfgId()
	{
		IReadOnlyList<WuWuTaskPackage> allTaskPackage = ConfigBase<WuWuLogisticsConfig>.Instance.GetAllTaskPackage();
		if (allTaskPackage == null || allTaskPackage.Count == 0)
		{
			return 0;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		foreach (WuWuTaskPackage wuWuTaskPackage in allTaskPackage)
		{
			num2 = ((num2 == 0) ? wuWuTaskPackage.Id : num2);
			bool flag = true;
			if (this.IsPackUnlocked(wuWuTaskPackage.Id))
			{
				IReadOnlyList<WuWuWeekTask> weekTaskByWrapId = ConfigBase<WuWuLogisticsConfig>.Instance.GetWeekTaskByWrapId(wuWuTaskPackage.Id);
				if (weekTaskByWrapId != null)
				{
					foreach (WuWuWeekTask wuWuWeekTask in weekTaskByWrapId)
					{
						WuWuTaskData taskById = this.GetTaskById(wuWuWeekTask.Id);
						if (taskById == null || !taskById.IsCompleted)
						{
							num3 = ((num3 == 0) ? wuWuTaskPackage.Id : num3);
							flag = false;
						}
						else if (taskById.CanReceiveReward)
						{
							num = ((num == 0) ? wuWuTaskPackage.Id : num);
						}
					}
				}
				WuWuTaskPackData taskPackById = this.GetTaskPackById(wuWuTaskPackage.Id);
				if (flag && (taskPackById == null || !taskPackById.HadReward))
				{
					return wuWuTaskPackage.Id;
				}
			}
			else
			{
				num4 = ((num4 == 0) ? wuWuTaskPackage.Id : num4);
			}
		}
		if (num > 0)
		{
			return num;
		}
		if (num3 > 0)
		{
			return num3;
		}
		if (num4 > 0)
		{
			return num4;
		}
		return num2;
	}

	// Token: 0x0600A426 RID: 42022 RVA: 0x002B6560 File Offset: 0x002B4760
	public override bool GetExDataRedPointShowState()
	{
		IReadOnlyList<WuWuTaskPackage> allTaskPackage = ConfigBase<WuWuLogisticsConfig>.Instance.GetAllTaskPackage();
		if (allTaskPackage == null)
		{
			return false;
		}
		ServerStorageMapMap serverStorageMapMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.Activity) as ServerStorageMapMap;
		foreach (WuWuTaskPackage wuWuTaskPackage in allTaskPackage)
		{
			bool flag = this.IsPackUnlocked(wuWuTaskPackage.Id);
			WuWuTaskPackData taskPackById = this.GetTaskPackById(wuWuTaskPackage.Id);
			if (flag && taskPackById != null)
			{
				if (serverStorageMapMap.Get(base.Id, wuWuTaskPackage.Id) == null)
				{
					return true;
				}
				if (this.TargetPackHasReceiveReward(wuWuTaskPackage.Id))
				{
					return true;
				}
				if (this.TargetPackChildTaskHasReceiveReward(wuWuTaskPackage.Id))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600A427 RID: 42023 RVA: 0x002B6634 File Offset: 0x002B4834
	public bool HasFirstUnlockPack()
	{
		IReadOnlyList<WuWuTaskPackage> allTaskPackage = ConfigBase<WuWuLogisticsConfig>.Instance.GetAllTaskPackage();
		if (allTaskPackage == null)
		{
			return false;
		}
		ServerStorageMapMap serverStorageMapMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.Activity) as ServerStorageMapMap;
		foreach (WuWuTaskPackage wuWuTaskPackage in allTaskPackage)
		{
			if (serverStorageMapMap.Get(base.Id, wuWuTaskPackage.Id) == null && this.IsPackUnlocked(wuWuTaskPackage.Id))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600A428 RID: 42024 RVA: 0x002B66CC File Offset: 0x002B48CC
	public void SetFirstUnlockPack()
	{
		IReadOnlyList<WuWuTaskPackage> allTaskPackage = ConfigBase<WuWuLogisticsConfig>.Instance.GetAllTaskPackage();
		if (allTaskPackage == null)
		{
			return;
		}
		ServerStorageMapMap serverStorageMapMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.Activity) as ServerStorageMapMap;
		foreach (WuWuTaskPackage wuWuTaskPackage in allTaskPackage)
		{
			if (serverStorageMapMap.Get(base.Id, wuWuTaskPackage.Id) == null && this.IsPackUnlocked(wuWuTaskPackage.Id))
			{
				serverStorageMapMap.Set(base.Id, wuWuTaskPackage.Id, wuWuTaskPackage.Id);
			}
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x0600A429 RID: 42025 RVA: 0x002B678C File Offset: 0x002B498C
	[NullableContext(2)]
	public List<int> GetTargetPackCanReceiveTaskIds(int packId)
	{
		IReadOnlyList<WuWuWeekTask> weekTaskByWrapId = ConfigBase<WuWuLogisticsConfig>.Instance.GetWeekTaskByWrapId(packId);
		if (weekTaskByWrapId != null)
		{
			List<int> list = new List<int>();
			foreach (WuWuWeekTask wuWuWeekTask in weekTaskByWrapId)
			{
				WuWuTaskData taskById = this.GetTaskById(wuWuWeekTask.Id);
				if (taskById != null && taskById.CanReceiveReward)
				{
					list.Add(wuWuWeekTask.Id);
				}
			}
			return list;
		}
		return null;
	}

	// Token: 0x0600A42A RID: 42026 RVA: 0x002B6810 File Offset: 0x002B4A10
	protected override bool GetExDataFinishShowState()
	{
		if (this.TaskMap.Count == 0)
		{
			return false;
		}
		IReadOnlyList<WuWuTaskPackage> allTaskPackage = ConfigBase<WuWuLogisticsConfig>.Instance.GetAllTaskPackage();
		if (allTaskPackage == null)
		{
			return false;
		}
		foreach (WuWuTaskPackage wuWuTaskPackage in allTaskPackage)
		{
			if (!this.TargetPackIsFullyRewarded(wuWuTaskPackage.Id))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x04004DDD RID: 19933
	private readonly Dictionary<int, WuWuTaskData> TaskMap = new Dictionary<int, WuWuTaskData>();

	// Token: 0x04004DDE RID: 19934
	private readonly Dictionary<int, WuWuTaskPackData> TaskPackMap = new Dictionary<int, WuWuTaskPackData>();
}
