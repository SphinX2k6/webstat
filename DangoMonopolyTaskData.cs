using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.SkipInterface;

// Token: 0x02001306 RID: 4870
[NullableContext(1)]
[Nullable(0)]
public class DangoMonopolyTaskData : IStaticVariableResetter
{
	// Token: 0x0600846D RID: 33901 RVA: 0x0022F212 File Offset: 0x0022D412
	static DangoMonopolyTaskData()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(global::DangoMonopolyTaskData.CreateStaticDefaultValue), new Action(global::DangoMonopolyTaskData.ResetStaticDefaultValue));
	}

	// Token: 0x0600846E RID: 33902 RVA: 0x0022F231 File Offset: 0x0022D431
	public static void CreateStaticDefaultValue()
	{
		global::DangoMonopolyTaskData.RecycleList = new List<global::DangoMonopolyTaskData>();
	}

	// Token: 0x0600846F RID: 33903 RVA: 0x0022F23D File Offset: 0x0022D43D
	public static void ResetStaticDefaultValue()
	{
		global::DangoMonopolyTaskData.RecycleList = null;
	}

	// Token: 0x06008470 RID: 33904 RVA: 0x0022F248 File Offset: 0x0022D448
	public static global::DangoMonopolyTaskData Create(DangoMonopolyTask config)
	{
		if (global::DangoMonopolyTaskData.RecycleList != null && global::DangoMonopolyTaskData.RecycleList.Count > 0)
		{
			global::DangoMonopolyTaskData dangoMonopolyTaskData = global::DangoMonopolyTaskData.RecycleList[0];
			global::DangoMonopolyTaskData.RecycleList.RemoveAt(0);
			dangoMonopolyTaskData.Init(config);
			return dangoMonopolyTaskData;
		}
		global::DangoMonopolyTaskData dangoMonopolyTaskData2 = new global::DangoMonopolyTaskData(config.TaskId);
		dangoMonopolyTaskData2.Init(config);
		return dangoMonopolyTaskData2;
	}

	// Token: 0x06008471 RID: 33905 RVA: 0x0022F29A File Offset: 0x0022D49A
	public void Recycle()
	{
		if (global::DangoMonopolyTaskData.RecycleList != null)
		{
			global::DangoMonopolyTaskData.RecycleList.Add(this);
		}
	}

	// Token: 0x06008472 RID: 33906 RVA: 0x0022F2AE File Offset: 0x0022D4AE
	private DangoMonopolyTaskData(int id)
	{
		this.Id = id;
	}

	// Token: 0x06008473 RID: 33907 RVA: 0x0022F2C8 File Offset: 0x0022D4C8
	private void Init(DangoMonopolyTask config)
	{
		this.Id = config.TaskId;
		this.TaskType = (EDangoMonopolyTaskType)config.TaskType;
		this.TaskDesc = config.Desc;
		this.RewardItemId = config.ItemId;
		this.RewardItemCount = config.ItemNum;
		this.Sort = config.Sort;
		this.Source = config.Source;
	}

	// Token: 0x06008474 RID: 33908 RVA: 0x0022F330 File Offset: 0x0022D530
	public void ProtoUpdateData(Aki.Protocol.DangoMonopolyTaskData data)
	{
		this.TaskState = data.State;
		this.Progress = data.Progress;
		this.TotalProgress = data.Target;
	}

	// Token: 0x06008475 RID: 33909 RVA: 0x0022F356 File Offset: 0x0022D556
	public int GetTaskStateSort()
	{
		if (this.TaskState == DangoMonopolyTaskState.Completed)
		{
			return 0;
		}
		if (this.TaskState == DangoMonopolyTaskState.NotCompleted)
		{
			return 1;
		}
		return 2;
	}

	// Token: 0x06008476 RID: 33910 RVA: 0x0022F36E File Offset: 0x0022D56E
	public int GetSortResult(global::DangoMonopolyTaskData other)
	{
		if (this.TaskState != other.TaskState)
		{
			return this.GetTaskStateSort() - other.GetTaskStateSort();
		}
		return this.Sort - other.Sort;
	}

	// Token: 0x06008477 RID: 33911 RVA: 0x0022F399 File Offset: 0x0022D599
	public void JumpSource()
	{
		if (this.Source == 0)
		{
			return;
		}
		SkipTaskManager.RunByConfigId(this.Source, null);
	}

	// Token: 0x06008478 RID: 33912 RVA: 0x0022F3B0 File Offset: 0x0022D5B0
	public bool IsCanReceive()
	{
		return this.TaskState == DangoMonopolyTaskState.Completed;
	}

	// Token: 0x06008479 RID: 33913 RVA: 0x0022F3BE File Offset: 0x0022D5BE
	public void SetEndTime(long endTime)
	{
		this.EndTime = endTime;
	}

	// Token: 0x0600847A RID: 33914 RVA: 0x0022F3C7 File Offset: 0x0022D5C7
	public void LogInfo()
	{
	}

	// Token: 0x04003ED4 RID: 16084
	public int Id;

	// Token: 0x04003ED5 RID: 16085
	public EDangoMonopolyTaskType TaskType;

	// Token: 0x04003ED6 RID: 16086
	public string TaskDesc = "";

	// Token: 0x04003ED7 RID: 16087
	public int RewardItemId;

	// Token: 0x04003ED8 RID: 16088
	public int RewardItemCount;

	// Token: 0x04003ED9 RID: 16089
	public DangoMonopolyTaskState TaskState;

	// Token: 0x04003EDA RID: 16090
	public long EndTime;

	// Token: 0x04003EDB RID: 16091
	public int Progress;

	// Token: 0x04003EDC RID: 16092
	public int TotalProgress;

	// Token: 0x04003EDD RID: 16093
	public int Sort;

	// Token: 0x04003EDE RID: 16094
	public int Source;

	// Token: 0x04003EDF RID: 16095
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<global::DangoMonopolyTaskData> RecycleList;
}
