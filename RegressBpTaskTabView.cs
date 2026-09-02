using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001539 RID: 5433
[NullableContext(1)]
[Nullable(0)]
public class RegressBpTaskTabView : UiTabViewBase, IRegressBpTabView
{
	// Token: 0x06009853 RID: 38995 RVA: 0x0027E2B1 File Offset: 0x0027C4B1
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06009854 RID: 38996 RVA: 0x0027E2EC File Offset: 0x0027C4EC
	protected override UniTask OnBeforeStartAsync()
	{
		RegressBpTaskTabView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RegressBpTaskTabView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009855 RID: 38997 RVA: 0x0027E32F File Offset: 0x0027C52F
	public void OnClickBtnClaimAll()
	{
		ControllerBase<ActivityRegressController>.Instance.RequestClaimAllTaskReward();
	}

	// Token: 0x06009856 RID: 38998 RVA: 0x0027E33B File Offset: 0x0027C53B
	public void RefreshBtnClaimVisible(UUIItem uiItem)
	{
		uiItem.SetUIActive(ModelBase<ActivityRegressModel>.Instance.ActivityData.HasReachableConstantTask());
	}

	// Token: 0x06009857 RID: 38999 RVA: 0x0027E352 File Offset: 0x0027C552
	protected override void OnBeforeShow()
	{
		this.RefreshView(true);
	}

	// Token: 0x06009858 RID: 39000 RVA: 0x0027E35C File Offset: 0x0027C55C
	public void RefreshView(bool playAnim = false)
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		if (this.TaskScrollView == null || activityData == null)
		{
			return;
		}
		List<RegressQuest> list = new List<RegressQuest>();
		ERegressTaskType[] array = new ERegressTaskType[]
		{
			ERegressTaskType.Constant,
			ERegressTaskType.Daily,
			ERegressTaskType.Once
		};
		for (int i = 0; i < array.Length; i++)
		{
			List<RegressQuest> regressTaskListByType = activityData.GetRegressTaskListByType(array[i]);
			if (regressTaskListByType != null && regressTaskListByType.Count > 0)
			{
				for (int j = 0; j < regressTaskListByType.Count; j++)
				{
					list.Add(regressTaskListByType[j]);
				}
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		this.SortTask(list);
		this.TaskScrollView.RefreshByData(list, false, null, playAnim);
	}

	// Token: 0x06009859 RID: 39001 RVA: 0x0027E400 File Offset: 0x0027C600
	private RegressBpTaskItem OnCreateTaskItem()
	{
		return new RegressBpTaskItem();
	}

	// Token: 0x0600985A RID: 39002 RVA: 0x0027E407 File Offset: 0x0027C607
	private void SortTask(List<RegressQuest> taskList)
	{
		taskList.Sort(delegate(RegressQuest a, RegressQuest b)
		{
			ERegressRewardState taskRewardState = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTaskRewardState(a.Id);
			ERegressRewardState taskRewardState2 = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTaskRewardState(b.Id);
			if (taskRewardState != taskRewardState2)
			{
				return RegressBpTaskTabView.RegressTaskRewardStateSortRecord[taskRewardState] - RegressBpTaskTabView.RegressTaskRewardStateSortRecord[taskRewardState2];
			}
			ERegressTaskType taskType = (ERegressTaskType)a.TaskType;
			ERegressTaskType taskType2 = (ERegressTaskType)b.TaskType;
			if (taskType != taskType2)
			{
				return RegressBpTaskTabView.RegressTaskTypeSortRecord[taskType] - RegressBpTaskTabView.RegressTaskTypeSortRecord[taskType2];
			}
			return a.Id - b.Id;
		});
	}

	// Token: 0x0400468A RID: 18058
	private static readonly Dictionary<ERegressTaskType, int> RegressTaskTypeSortRecord = new Dictionary<ERegressTaskType, int>
	{
		{
			ERegressTaskType.Constant,
			1
		},
		{
			ERegressTaskType.Daily,
			0
		},
		{
			ERegressTaskType.Cultivate,
			2
		},
		{
			ERegressTaskType.Once,
			3
		}
	};

	// Token: 0x0400468B RID: 18059
	private static readonly Dictionary<ERegressRewardState, int> RegressTaskRewardStateSortRecord = new Dictionary<ERegressRewardState, int>
	{
		{
			ERegressRewardState.UnReach,
			1
		},
		{
			ERegressRewardState.Reached,
			0
		},
		{
			ERegressRewardState.Claim,
			2
		}
	};

	// Token: 0x0400468C RID: 18060
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<RegressBpTaskItem, RegressQuest> TaskScrollView;

	// Token: 0x020078EE RID: 30958
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029901 RID: 170241
		public const int MissionScroll = 0;

		// Token: 0x04029902 RID: 170242
		public const int Item = 1;
	}
}
