using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x020011C8 RID: 4552
[NullableContext(1)]
[Nullable(0)]
public class AvignonProtocolData : ActivityBaseData
{
	// Token: 0x060077FA RID: 30714 RVA: 0x001F65FF File Offset: 0x001F47FF
	protected override void OnInit(ActivityData data)
	{
		this.InitStages();
	}

	// Token: 0x060077FB RID: 30715 RVA: 0x001F6608 File Offset: 0x001F4808
	private void InitStages()
	{
		this.Stages.Clear();
		IReadOnlyList<AvignonStage> stageConfigAll = ConfigBase<AvignonConfig>.Instance.GetStageConfigAll();
		for (int i = 0; i < stageConfigAll.Count; i++)
		{
			AvignonStage avignonStage = stageConfigAll[i];
			AvignonStageInfo value = new AvignonStageInfo(avignonStage.Id, i);
			this.Stages[avignonStage.Id] = value;
		}
	}

	// Token: 0x060077FC RID: 30716 RVA: 0x001F6668 File Offset: 0x001F4868
	protected override void PhraseEx(ActivityData data)
	{
		AvignonActivityInfo avignonActivityInfo = data.AvignonActivityInfo;
		if (avignonActivityInfo == null)
		{
			return;
		}
		foreach (ActivityTask taskInfo in avignonActivityInfo.ActivityTaskDatas.ActivityTasks)
		{
			this.UpdateTask(taskInfo);
		}
		foreach (int stageId in avignonActivityInfo.UnLockStepId)
		{
			this.UnlockStage(stageId);
		}
	}

	// Token: 0x060077FD RID: 30717 RVA: 0x001F6704 File Offset: 0x001F4904
	public void UpdateTask(ActivityTask taskInfo)
	{
		if (taskInfo == null || taskInfo.Id == 0)
		{
			return;
		}
		int stageIdByTaskId = this.GetStageIdByTaskId(taskInfo.Id);
		AvignonStageInfo avignonStageInfo;
		if (this.Stages.TryGetValue(stageIdByTaskId, out avignonStageInfo))
		{
			avignonStageInfo.UpdateTask(taskInfo);
		}
	}

	// Token: 0x060077FE RID: 30718 RVA: 0x001F6744 File Offset: 0x001F4944
	public void UnlockStage(int stageId)
	{
		AvignonStageInfo avignonStageInfo;
		if (this.Stages.TryGetValue(stageId, out avignonStageInfo))
		{
			avignonStageInfo.UnlockStage();
		}
	}

	// Token: 0x060077FF RID: 30719 RVA: 0x001F6768 File Offset: 0x001F4968
	public bool IsAllStagesUnlock()
	{
		using (Dictionary<int, AvignonStageInfo>.ValueCollection.Enumerator enumerator = this.Stages.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.IsUnlock)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06007800 RID: 30720 RVA: 0x001F67C8 File Offset: 0x001F49C8
	public bool HasStageRewardRedDot()
	{
		using (Dictionary<int, AvignonStageInfo>.ValueCollection.Enumerator enumerator = this.Stages.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetRewardState())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06007801 RID: 30721 RVA: 0x001F6828 File Offset: 0x001F4A28
	public override bool GetExDataRedPointShowState()
	{
		bool flag = ModelBase<AvignonModel>.Instance.CheckRedDot();
		return this.HasStageRewardRedDot() || flag;
	}

	// Token: 0x06007802 RID: 30722 RVA: 0x001F6848 File Offset: 0x001F4A48
	public AvignonStageInfo GetStageInfo(int stageId)
	{
		AvignonStageInfo result;
		if (this.Stages.TryGetValue(stageId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06007803 RID: 30723 RVA: 0x001F6868 File Offset: 0x001F4A68
	public int[] GetAllStagesId()
	{
		List<int> list = new List<int>(this.Stages.Keys);
		list.Sort((int a, int b) => a - b);
		return list.ToArray();
	}

	// Token: 0x06007804 RID: 30724 RVA: 0x001F68A4 File Offset: 0x001F4AA4
	public int? GetCurrentLockQuestId()
	{
		foreach (AvignonStageInfo avignonStageInfo in this.Stages.Values)
		{
			if (!avignonStageInfo.IsUnlock)
			{
				return new int?(ConfigBase<AvignonConfig>.Instance.GetStageConfigById(avignonStageInfo.StageId).Value.QuestionId);
			}
		}
		return null;
	}

	// Token: 0x06007805 RID: 30725 RVA: 0x001F6934 File Offset: 0x001F4B34
	private int GetStageIdByTaskId(int taskId)
	{
		return ConfigBase<AvignonConfig>.Instance.GetAvignonTaskConfigByTaskId(taskId).Value.Step;
	}

	// Token: 0x06007806 RID: 30726 RVA: 0x001F695C File Offset: 0x001F4B5C
	public void TaskRewardGot(int taskId)
	{
		int stageIdByTaskId = this.GetStageIdByTaskId(taskId);
		this.Stages[stageIdByTaskId].SetTaskRewardGot(taskId);
	}

	// Token: 0x04003A04 RID: 14852
	private readonly Dictionary<int, AvignonStageInfo> Stages = new Dictionary<int, AvignonStageInfo>();
}
