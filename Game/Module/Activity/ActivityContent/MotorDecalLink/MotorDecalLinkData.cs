using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink
{
	// Token: 0x020066F9 RID: 26361
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorDecalLinkData : ActivityBaseData
	{
		// Token: 0x06041CC0 RID: 269504 RVA: 0x010E11E0 File Offset: 0x010DF3E0
		public MotorDecalLinkData(int activityId)
		{
			foreach (MotorDecalIp motorDecalIp in ConfigBase<MotorDecalLinkConfig>.Instance.GetIpConfigListByActivityId(activityId))
			{
				foreach (MotorDecalQuest motorDecalQuest in ConfigBase<MotorDecalLinkConfig>.Instance.GetTaskConfigListByIpId(motorDecalIp.Id))
				{
					if (!this.ActivityQuestData.ContainsKey(motorDecalQuest.TaskId))
					{
						global::ActivityTaskData activityTaskData = new global::ActivityTaskData();
						activityTaskData.Id = motorDecalQuest.TaskId;
						this.ActivityQuestData[motorDecalQuest.TaskId] = activityTaskData;
					}
				}
			}
		}

		// Token: 0x06041CC1 RID: 269505 RVA: 0x010E12C4 File Offset: 0x010DF4C4
		protected unsafe override void PhraseEx(ActivityData data)
		{
			this.MainViewModel.InitFromActivityDataIfNot(this);
			MotorDecalActivityData motorDecalActivityData = (data != null) ? data.MotorDecalActivityData : null;
			if (motorDecalActivityData == null)
			{
				MotorDecalLinkUtil.Debug("活动协议未推送活动信息", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			string message = "活动协议推送活动信息";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", base.Id);
			MotorDecalLinkUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.HasFirstRead = (ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 1, 0, 0) == 1);
			RepeatedField<ConditionTask> conditionTasks = motorDecalActivityData.ConditionTasks;
			for (int i = 0; i < conditionTasks.Count; i++)
			{
				ConditionTask conditionTask = conditionTasks[i];
				global::ActivityTaskData activityTaskData;
				if (this.ActivityQuestData.TryGetValue(conditionTask.Id, out activityTaskData))
				{
					activityTaskData.Refresh(conditionTask, null);
					activityTaskData.Status = this.TaskServerStatus2ClientStatus(conditionTask.Status);
				}
			}
			this.MainViewModel.RefreshIpTaskStates(this.ActivityQuestData);
			this.MainViewModel.HasFirstRead = this.HasFirstRead;
			this.MainViewModel.HasRewardCanReceive = this.HasAnyRewardCanReceive();
			string message2 = "活动已读状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", base.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("HasFirstRead", this.HasFirstRead);
			MotorDecalLinkUtil.Debug(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, base.Id);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06041CC2 RID: 269506 RVA: 0x010E1460 File Offset: 0x010DF660
		public void OnRewardReceiveByTaskIds(IReadOnlyList<int> taskIds)
		{
			string message = "领奖成功";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("taskIds", taskIds);
			MotorDecalLinkUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			foreach (int key in taskIds)
			{
				global::ActivityTaskData activityTaskData;
				if (this.ActivityQuestData.TryGetValue(key, out activityTaskData))
				{
					activityTaskData.Status = EActivityTaskState.FinishedAndClaimed;
				}
			}
			this.MainViewModel.RefreshIpTaskStates(this.ActivityQuestData);
			this.MainViewModel.HasRewardCanReceive = this.HasAnyRewardCanReceive();
		}

		// Token: 0x06041CC3 RID: 269507 RVA: 0x010E14F8 File Offset: 0x010DF6F8
		public bool ContainsTaskId(int taskId)
		{
			return this.ActivityQuestData.ContainsKey(taskId);
		}

		// Token: 0x06041CC4 RID: 269508 RVA: 0x010E1508 File Offset: 0x010DF708
		public unsafe void OnTaskUpdateNotify(MotorDecalUpdateNotify notify)
		{
			ConditionTask task = notify.Task;
			if (task == null)
			{
				return;
			}
			int id = task.Id;
			global::ActivityTaskData activityTaskData;
			if (!this.ActivityQuestData.TryGetValue(id, out activityTaskData))
			{
				return;
			}
			string message = "OnTaskUpdateNotify";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("taskId", id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("taskData", activityTaskData);
			MotorDecalLinkUtil.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			activityTaskData.Id = task.Id;
			activityTaskData.Current = task.Current;
			activityTaskData.Target = task.Target;
			activityTaskData.Status = this.TaskServerStatus2ClientStatus(task.Status);
			this.MainViewModel.RefreshIpTaskStates(this.ActivityQuestData);
			this.MainViewModel.HasRewardCanReceive = this.HasAnyRewardCanReceive();
		}

		// Token: 0x06041CC5 RID: 269509 RVA: 0x010E15DF File Offset: 0x010DF7DF
		private EActivityTaskState TaskServerStatus2ClientStatus(ConditionTaskState serverStatus)
		{
			switch (serverStatus)
			{
			case ConditionTaskState.ConditionTaskRunning:
				return EActivityTaskState.Active;
			case ConditionTaskState.ConditionTaskFinish:
				return EActivityTaskState.FinishedAndUnclaimed;
			case ConditionTaskState.ConditionTaskTaken:
				return EActivityTaskState.FinishedAndClaimed;
			default:
				return EActivityTaskState.Active;
			}
		}

		// Token: 0x06041CC6 RID: 269510 RVA: 0x010E15FC File Offset: 0x010DF7FC
		public bool HasAnyRewardCanReceive()
		{
			foreach (KeyValuePair<int, global::ActivityTaskData> keyValuePair in this.ActivityQuestData)
			{
				if (keyValuePair.Value.Status == EActivityTaskState.FinishedAndUnclaimed)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06041CC7 RID: 269511 RVA: 0x010E1660 File Offset: 0x010DF860
		public override bool GetExDataRedPointShowState()
		{
			return !this.GetExDataFinishShowState() && (this.HasAnyRewardCanReceive() || !this.HasFirstRead);
		}

		// Token: 0x06041CC8 RID: 269512 RVA: 0x010E1680 File Offset: 0x010DF880
		protected override bool GetExDataFinishShowState()
		{
			foreach (KeyValuePair<int, global::ActivityTaskData> keyValuePair in this.ActivityQuestData)
			{
				if (keyValuePair.Value.Status != EActivityTaskState.FinishedAndClaimed)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06041CC9 RID: 269513 RVA: 0x010E16E4 File Offset: 0x010DF8E4
		public void SetHasFirstRead()
		{
			string message = "设置活动已读";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", base.Id);
			MotorDecalLinkUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 1, 0, 0, 1);
			this.HasFirstRead = true;
			this.MainViewModel.HasFirstRead = true;
		}

		// Token: 0x04024B42 RID: 150338
		private readonly Dictionary<int, global::ActivityTaskData> ActivityQuestData = new Dictionary<int, global::ActivityTaskData>();

		// Token: 0x04024B43 RID: 150339
		public readonly MotorDecalLinkMainViewModel MainViewModel = new MotorDecalLinkMainViewModel();

		// Token: 0x04024B44 RID: 150340
		private bool HasFirstRead;
	}
}
