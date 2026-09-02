using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using Google.Protobuf.Collections;

// Token: 0x02001378 RID: 4984
[NullableContext(1)]
[Nullable(0)]
public class ActivityMapExploreData : ActivityBaseData
{
	// Token: 0x06008895 RID: 34965 RVA: 0x00240246 File Offset: 0x0023E446
	public override bool GetExDataRedPointShowState()
	{
		return this.IsFirstUnlockState(EActivityExploreFirstUnlockState.Set) || this.IsCanGetReward();
	}

	// Token: 0x06008896 RID: 34966 RVA: 0x0024025C File Offset: 0x0023E45C
	protected override bool GetExDataFinishShowState()
	{
		for (int i = 0; i < this.TaskList.Count; i++)
		{
			if (!this.TaskList[i].IsComplete)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06008897 RID: 34967 RVA: 0x00240298 File Offset: 0x0023E498
	public bool IsCanGetReward()
	{
		for (int i = 0; i < this.TaskList.Count; i++)
		{
			if (this.TaskList[i].IsCanGet)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06008898 RID: 34968 RVA: 0x002402D1 File Offset: 0x0023E4D1
	protected override void OnInit(ActivityData data)
	{
		ServerStorageUtil.OverrideLocalNumberToServerNumber(ELocalStoragePlayerKey.ExploreActivityFirstUnlock, EClientStorageSystemIdType.ExploreActivityFirstUnlock);
	}

	// Token: 0x06008899 RID: 34969 RVA: 0x002402E0 File Offset: 0x0023E4E0
	private EActivityExploreFirstUnlockState GetFirstUnlockState()
	{
		ServerStorageNumber serverStorageNumber = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.ExploreActivityFirstUnlock) as ServerStorageNumber;
		if (serverStorageNumber == null)
		{
			return EActivityExploreFirstUnlockState.None;
		}
		int? num = serverStorageNumber.Get();
		if (num == null)
		{
			return EActivityExploreFirstUnlockState.None;
		}
		return (EActivityExploreFirstUnlockState)num.Value;
	}

	// Token: 0x0600889A RID: 34970 RVA: 0x00240320 File Offset: 0x0023E520
	public void SetFirstUnlockState(EActivityExploreFirstUnlockState value)
	{
		ServerStorageNumber serverStorageNumber = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.ExploreActivityFirstUnlock) as ServerStorageNumber;
		if (serverStorageNumber != null)
		{
			serverStorageNumber.Set(new int?((int)value));
		}
	}

	// Token: 0x0600889B RID: 34971 RVA: 0x0024034E File Offset: 0x0023E54E
	public bool IsFirstUnlockState(EActivityExploreFirstUnlockState state)
	{
		return this.GetFirstUnlockState() == state;
	}

	// Token: 0x0600889C RID: 34972 RVA: 0x0024035C File Offset: 0x0023E55C
	protected override void PhraseEx(ActivityData data)
	{
		this.TaskList.Clear();
		ExploreActivityInfo exploreActivityInfo = data.ExploreActivityInfo;
		if (exploreActivityInfo == null)
		{
			return;
		}
		foreach (ExploreActivityTask exploreActivityTask in ConfigBase<ActivityMapExploreConfig>.Instance.GetExploreTaskList(data.Id))
		{
			DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(exploreActivityTask.DropId);
			List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
			if (dropPackage != null)
			{
				foreach (DicIntInt dicIntInt in dropPackage.Value.DropPreviewIter())
				{
					list.Add(new ValueTuple<int, int>(dicIntInt.Key, dicIntInt.Value));
				}
			}
			this.TaskList.Add(new ActivitySubMapExploreItemData
			{
				TaskId = exploreActivityTask.TaskId,
				RewardDesc = exploreActivityTask.Desc,
				RewardItemId = ((list.Count > 0) ? list[0].Item1 : this.ItemId),
				RewardItemCount = new int?((list.Count > 0) ? list[0].Item2 : 0),
				IsComplete = false,
				IsCanGet = false,
				IsRunning = true
			});
		}
		if (this.IsFirstUnlockState(EActivityExploreFirstUnlockState.None) && base.CanPreOpen())
		{
			this.SetFirstUnlockState(EActivityExploreFirstUnlockState.Set);
		}
		this.UpdateTaskState(exploreActivityInfo.ActivityTasks);
	}

	// Token: 0x0600889D RID: 34973 RVA: 0x00240510 File Offset: 0x0023E710
	public void UpdateTaskState(MapField<int, ActivityTaskState> stateMap)
	{
		if (stateMap == null)
		{
			return;
		}
		foreach (IActivitySubMapExploreItemData activitySubMapExploreItemData in this.TaskList)
		{
			ActivityTaskState activityTaskState;
			if (stateMap.TryGetValue(activitySubMapExploreItemData.TaskId, out activityTaskState))
			{
				activitySubMapExploreItemData.IsComplete = (activityTaskState == ActivityTaskState.ActivityTaskTaken);
				activitySubMapExploreItemData.IsCanGet = (activityTaskState == ActivityTaskState.ActivityTaskFinish);
				activitySubMapExploreItemData.IsRunning = (!activitySubMapExploreItemData.IsComplete && !activitySubMapExploreItemData.IsCanGet);
			}
		}
		this.SortTaskList();
		Singleton<EventSystem>.Instance.Emit(EEventName.ActivityMapExploreStateUpdate);
	}

	// Token: 0x0600889E RID: 34974 RVA: 0x002405B4 File Offset: 0x0023E7B4
	private void SortTaskList()
	{
		this.TaskList.Sort(delegate(IActivitySubMapExploreItemData a, IActivitySubMapExploreItemData b)
		{
			if (a.IsCanGet != b.IsCanGet)
			{
				if (!a.IsCanGet)
				{
					return 1;
				}
				return -1;
			}
			else
			{
				if (a.IsRunning == b.IsRunning)
				{
					return a.TaskId - b.TaskId;
				}
				if (!a.IsRunning)
				{
					return 1;
				}
				return -1;
			}
		});
	}

	// Token: 0x04004030 RID: 16432
	private readonly int ItemId = 3;

	// Token: 0x04004031 RID: 16433
	public readonly List<IActivitySubMapExploreItemData> TaskList = new List<IActivitySubMapExploreItemData>();
}
