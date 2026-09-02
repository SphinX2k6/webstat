using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.SkipInterface;

// Token: 0x02001268 RID: 4712
[NullableContext(1)]
[Nullable(0)]
public class BlackCoastStageInfo
{
	// Token: 0x17000AB1 RID: 2737
	// (get) Token: 0x06007DA7 RID: 32167 RVA: 0x00212564 File Offset: 0x00210764
	public EStageState StageState
	{
		get
		{
			if (!this.IsUnlockInternal)
			{
				return EStageState.Lock;
			}
			using (Dictionary<int, BlackCoastTaskData>.ValueCollection.Enumerator enumerator = this.TaskMap.Values.GetEnumerator())
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

	// Token: 0x17000AB2 RID: 2738
	// (get) Token: 0x06007DA8 RID: 32168 RVA: 0x002125CC File Offset: 0x002107CC
	public bool IsUnlock
	{
		get
		{
			return this.StageState > EStageState.Lock;
		}
	}

	// Token: 0x17000AB3 RID: 2739
	// (get) Token: 0x06007DA9 RID: 32169 RVA: 0x002125D7 File Offset: 0x002107D7
	// (set) Token: 0x06007DAA RID: 32170 RVA: 0x002125DF File Offset: 0x002107DF
	public int StageId { get; private set; }

	// Token: 0x17000AB4 RID: 2740
	// (get) Token: 0x06007DAB RID: 32171 RVA: 0x002125E8 File Offset: 0x002107E8
	// (set) Token: 0x06007DAC RID: 32172 RVA: 0x002125F0 File Offset: 0x002107F0
	public int Index { get; private set; }

	// Token: 0x06007DAD RID: 32173 RVA: 0x002125FC File Offset: 0x002107FC
	public BlackCoastStageInfo(int stageId, int index)
	{
		this.StageId = stageId;
		this.Index = index;
		foreach (BlackCoastThemeTaskRe blackCoastThemeTaskRe in ConfigBase<ActivityBlackCoastConfig>.Instance.GetAllTaskConfigByStageId(this.StageId))
		{
			BlackCoastTaskData blackCoastTaskData = new BlackCoastTaskData(blackCoastThemeTaskRe.TaskId);
			blackCoastTaskData.JumpId = blackCoastThemeTaskRe.JumpId;
			blackCoastTaskData.SortId = blackCoastThemeTaskRe.SortId;
			blackCoastTaskData.TitleTextId = blackCoastThemeTaskRe.TaskName;
			blackCoastTaskData.RewardList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(blackCoastThemeTaskRe.DropId);
			blackCoastTaskData.ReceiveDelegate = new Action<int>(this.RequestTaskReward);
			this.TaskMap[blackCoastThemeTaskRe.TaskId] = blackCoastTaskData;
		}
	}

	// Token: 0x06007DAE RID: 32174 RVA: 0x002126DC File Offset: 0x002108DC
	public string GetVideoSource()
	{
		return ConfigBase<ActivityBlackCoastConfig>.Instance.GetStageConfig(this.StageId).Value.VideoSource;
	}

	// Token: 0x06007DAF RID: 32175 RVA: 0x0021270C File Offset: 0x0021090C
	public bool GetRewardState()
	{
		using (Dictionary<int, BlackCoastTaskData>.ValueCollection.Enumerator enumerator = this.TaskMap.Values.GetEnumerator())
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

	// Token: 0x06007DB0 RID: 32176 RVA: 0x0021276C File Offset: 0x0021096C
	public int GetTaskProgress()
	{
		int count = this.TaskMap.Count;
		int num = 0;
		using (Dictionary<int, BlackCoastTaskData>.ValueCollection.Enumerator enumerator = this.TaskMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsTaken)
				{
					num++;
				}
			}
		}
		return (int)Math.Ceiling((double)((float)num * 1f / (float)count * 100f));
	}

	// Token: 0x06007DB1 RID: 32177 RVA: 0x002127F0 File Offset: 0x002109F0
	public List<BlackCoastTaskData> GetTaskList()
	{
		return this.TaskMap.Values.OrderBy((BlackCoastTaskData task) => task, new BlackCoastStageInfo.TaskComparer()).ToList<BlackCoastTaskData>();
	}

	// Token: 0x06007DB2 RID: 32178 RVA: 0x0021282C File Offset: 0x00210A2C
	public string GetLockConditionText()
	{
		return LevelGeneralCommons.GetConditionGroupHintText(ConfigBase<ActivityBlackCoastConfig>.Instance.GetStageConfig(this.StageId).Value.OpenConditionId) ?? "";
	}

	// Token: 0x06007DB3 RID: 32179 RVA: 0x00212868 File Offset: 0x00210A68
	public unsafe void StageUpdate(BlackCoastThemeStageInfo stageInfo)
	{
		foreach (ActivityTask activityTask in stageInfo.Tasks)
		{
			BlackCoastTaskData blackCoastTaskData;
			if (this.TaskMap.TryGetValue(activityTask.Id, out blackCoastTaskData))
			{
				int isFinished = blackCoastTaskData.IsFinished ? 1 : 0;
				blackCoastTaskData.Current = activityTask.Current;
				blackCoastTaskData.Target = activityTask.Target;
				blackCoastTaskData.Status = TaskStateResolver.TaskState[activityTask.Status];
				bool isFinished2 = blackCoastTaskData.IsFinished;
				if (isFinished == 0 && isFinished2)
				{
					this.OnStageTaskInfoChange(blackCoastTaskData.TaskId);
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "[BlackCoastActivity] 活动Task不存在";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("StageId", this.StageId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TaskId", activityTask.Id);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		this.IsUnlockInternal = true;
	}

	// Token: 0x06007DB4 RID: 32180 RVA: 0x0021298C File Offset: 0x00210B8C
	public void SetTaskRewardGot(int taskId)
	{
		BlackCoastTaskData blackCoastTaskData;
		if (this.TaskMap.TryGetValue(taskId, out blackCoastTaskData))
		{
			blackCoastTaskData.Status = EActivityTaskState.FinishedAndClaimed;
		}
	}

	// Token: 0x06007DB5 RID: 32181 RVA: 0x002129B0 File Offset: 0x00210BB0
	private void OnStageTaskInfoChange(int taskId)
	{
		BlackCoastTaskData blackCoastTaskData;
		if (this.TaskMap.TryGetValue(taskId, out blackCoastTaskData) && blackCoastTaskData.JumpId > 0)
		{
			AccessPath value = ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(blackCoastTaskData.JumpId).Value;
			if (value.SkipName == 8)
			{
				int value2 = int.Parse(value.Val1);
				ModelBase<MapModel>.Instance.RemoveMapMarksByConfigId(new EMarkType?(EMarkType.Entity), new int?(value2));
			}
		}
	}

	// Token: 0x06007DB6 RID: 32182 RVA: 0x00212A1C File Offset: 0x00210C1C
	private void RequestTaskReward(int taskId)
	{
		if (taskId == 0)
		{
			return;
		}
		ControllerBase<ActivityBlackCoastController>.Instance.RequestTaskReward(this.StageId, taskId);
	}

	// Token: 0x04003C50 RID: 15440
	public readonly Dictionary<int, BlackCoastTaskData> TaskMap = new Dictionary<int, BlackCoastTaskData>();

	// Token: 0x04003C51 RID: 15441
	private bool IsUnlockInternal;

	// Token: 0x020075DB RID: 30171
	[NullableContext(0)]
	private class TaskComparer : IComparer<BlackCoastTaskData>
	{
		// Token: 0x060470C0 RID: 291008 RVA: 0x012DCDB0 File Offset: 0x012DAFB0
		[NullableContext(1)]
		public int Compare(BlackCoastTaskData a, BlackCoastTaskData b)
		{
			if (a.Status != b.Status)
			{
				return a.Status - b.Status;
			}
			if (a.SortId != b.SortId)
			{
				return a.SortId - b.SortId;
			}
			return a.TaskId - b.TaskId;
		}
	}
}
