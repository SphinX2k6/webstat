using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.SkipInterface;

// Token: 0x020011C9 RID: 4553
[NullableContext(1)]
[Nullable(0)]
public class AvignonStageInfo
{
	// Token: 0x17000A14 RID: 2580
	// (get) Token: 0x06007808 RID: 30728 RVA: 0x001F6996 File Offset: 0x001F4B96
	// (set) Token: 0x06007809 RID: 30729 RVA: 0x001F699E File Offset: 0x001F4B9E
	public int StageId { get; private set; }

	// Token: 0x17000A15 RID: 2581
	// (get) Token: 0x0600780A RID: 30730 RVA: 0x001F69A7 File Offset: 0x001F4BA7
	// (set) Token: 0x0600780B RID: 30731 RVA: 0x001F69AF File Offset: 0x001F4BAF
	public int Index { get; private set; }

	// Token: 0x17000A16 RID: 2582
	// (get) Token: 0x0600780C RID: 30732 RVA: 0x001F69B8 File Offset: 0x001F4BB8
	public EStageState StageState
	{
		get
		{
			if (!this.IsUnlockInternal)
			{
				return EStageState.Lock;
			}
			using (Dictionary<int, AvignonTaskData>.ValueCollection.Enumerator enumerator = this.TaskMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsTaken)
					{
						return EStageState.Active;
					}
				}
			}
			return EStageState.Finished;
		}
	}

	// Token: 0x0600780D RID: 30733 RVA: 0x001F6A20 File Offset: 0x001F4C20
	public void UnlockStage()
	{
		this.IsUnlockInternal = true;
	}

	// Token: 0x17000A17 RID: 2583
	// (get) Token: 0x0600780E RID: 30734 RVA: 0x001F6A29 File Offset: 0x001F4C29
	public bool IsUnlock
	{
		get
		{
			return this.StageState > EStageState.Lock;
		}
	}

	// Token: 0x0600780F RID: 30735 RVA: 0x001F6A34 File Offset: 0x001F4C34
	public AvignonStageInfo(int StageId, int Index)
	{
		this.StageId = StageId;
		this.Index = Index;
		AvignonConfig instance = ConfigBase<AvignonConfig>.Instance;
		IReadOnlyList<AvignonTask> readOnlyList = (instance != null) ? instance.GetAvignonTaskConfigByStageId(StageId) : null;
		if (readOnlyList != null)
		{
			foreach (AvignonTask avignonTask in readOnlyList)
			{
				AvignonTaskData avignonTaskData = new AvignonTaskData(avignonTask.TaskId);
				avignonTaskData.JumpId = avignonTask.JumpId;
				avignonTaskData.TitleTextId = avignonTask.TaskName;
				avignonTaskData.RewardList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(avignonTask.TaskReward);
				avignonTaskData.ReceiveDelegate = new Action<int>(this.RequestTaskReward);
				this.TaskMap.Add(avignonTask.TaskId, avignonTaskData);
			}
		}
	}

	// Token: 0x06007810 RID: 30736 RVA: 0x001F6B10 File Offset: 0x001F4D10
	public bool HasNewStageFlag()
	{
		if (this.StageState != EStageState.Active)
		{
			return false;
		}
		int avignonActivityId = ModelBase<AvignonModel>.Instance.GetAvignonActivityId();
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(avignonActivityId, 0, this.StageId, 0, 0) == 0;
	}

	// Token: 0x06007811 RID: 30737 RVA: 0x001F6B4C File Offset: 0x001F4D4C
	public bool GetRewardState()
	{
		if (this.StageState != EStageState.Active)
		{
			return false;
		}
		using (Dictionary<int, AvignonTaskData>.ValueCollection.Enumerator enumerator = this.TaskMap.Values.GetEnumerator())
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

	// Token: 0x06007812 RID: 30738 RVA: 0x001F6BB8 File Offset: 0x001F4DB8
	public int GetTaskProgress()
	{
		int count = this.TaskMap.Count;
		int num = 0;
		using (Dictionary<int, AvignonTaskData>.ValueCollection.Enumerator enumerator = this.TaskMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsTaken)
				{
					num++;
				}
			}
		}
		return (int)Math.Ceiling((double)((float)num * 1f / (float)count) * 100.0);
	}

	// Token: 0x06007813 RID: 30739 RVA: 0x001F6C40 File Offset: 0x001F4E40
	public List<AvignonTaskData> GetTaskList()
	{
		List<AvignonTaskData> list = new List<AvignonTaskData>(this.TaskMap.Values);
		list.Sort(new Comparison<AvignonTaskData>(this.TaskSort));
		return list;
	}

	// Token: 0x06007814 RID: 30740 RVA: 0x001F6C64 File Offset: 0x001F4E64
	private int TaskSort(AvignonTaskData a, AvignonTaskData b)
	{
		if (a.Status != b.Status)
		{
			return a.Status - b.Status;
		}
		return a.TaskId - b.TaskId;
	}

	// Token: 0x06007815 RID: 30741 RVA: 0x001F6C90 File Offset: 0x001F4E90
	public string GetLockConditionText()
	{
		return LevelGeneralCommons.GetConditionGroupHintText(ConfigBase<AvignonConfig>.Instance.GetStageConfigById(this.StageId).Value.OpenConditionId) ?? "";
	}

	// Token: 0x06007816 RID: 30742 RVA: 0x001F6CCC File Offset: 0x001F4ECC
	public unsafe void UpdateTask(ActivityTask taskInfo)
	{
		AvignonTaskData avignonTaskData;
		if (this.TaskMap.TryGetValue(taskInfo.Id, out avignonTaskData))
		{
			int isFinished = avignonTaskData.IsFinished ? 1 : 0;
			avignonTaskData.Current = taskInfo.Current;
			avignonTaskData.Target = taskInfo.Target;
			avignonTaskData.Status = TaskStateResolver.TaskState[taskInfo.Status];
			bool isFinished2 = avignonTaskData.IsFinished;
			if (isFinished == 0 && isFinished2)
			{
				this.OnStageTaskInfoChange(avignonTaskData.TaskId);
				return;
			}
		}
		else
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "[AvignonActivity] 活动Task不存在";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("StageId", this.StageId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TaskId", taskInfo.Id);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x06007817 RID: 30743 RVA: 0x001F6DA7 File Offset: 0x001F4FA7
	public void SetTaskRewardGot(int taskId)
	{
		this.TaskMap[taskId].Status = EActivityTaskState.FinishedAndClaimed;
	}

	// Token: 0x06007818 RID: 30744 RVA: 0x001F6DBC File Offset: 0x001F4FBC
	private void OnStageTaskInfoChange(int taskId)
	{
		AvignonTaskData avignonTaskData = this.TaskMap[taskId];
		if (avignonTaskData.JumpId > 0)
		{
			AccessPath? accessPathConfig = ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(avignonTaskData.JumpId);
			if (accessPathConfig.Value.SkipName == 8)
			{
				int value = Convert.ToInt32(accessPathConfig.Value.Val1);
				ModelBase<MapModel>.Instance.RemoveMapMarksByConfigId(new EMarkType?(EMarkType.Entity), new int?(value));
			}
		}
	}

	// Token: 0x06007819 RID: 30745 RVA: 0x001F6E2D File Offset: 0x001F502D
	private void RequestTaskReward(int taskId)
	{
		if (taskId <= 0)
		{
			return;
		}
		ControllerBase<AvignonController>.Instance.RequestTaskReward(taskId);
	}

	// Token: 0x04003A05 RID: 14853
	public readonly Dictionary<int, AvignonTaskData> TaskMap = new Dictionary<int, AvignonTaskData>();

	// Token: 0x04003A06 RID: 14854
	private bool IsUnlockInternal;
}
