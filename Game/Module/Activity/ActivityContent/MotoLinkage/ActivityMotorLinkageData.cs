using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotoLinkage
{
	// Token: 0x0200670C RID: 26380
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityMotorLinkageData : ActivityBaseData
	{
		// Token: 0x06041D25 RID: 269605 RVA: 0x010E34BC File Offset: 0x010E16BC
		protected override void PhraseEx(ActivityData data)
		{
			MotorCycleIpActivityData motorCycleIpActivityData = data.MotorCycleIpActivityData;
			if (motorCycleIpActivityData == null)
			{
				return;
			}
			for (int i = 0; i < motorCycleIpActivityData.ConditionTasks.Count; i++)
			{
				ConditionTask conditionTask = motorCycleIpActivityData.ConditionTasks[i];
				global::ActivityTaskData activityTaskData = new global::ActivityTaskData();
				activityTaskData.Id = conditionTask.Id;
				activityTaskData.Current = conditionTask.Current;
				activityTaskData.Target = conditionTask.Target;
				activityTaskData.Status = this.TaskServerStatus2ClientStatus(conditionTask.Status);
				this.ActivityQuestData[conditionTask.Id] = activityTaskData;
			}
		}

		// Token: 0x06041D26 RID: 269606 RVA: 0x010E3545 File Offset: 0x010E1745
		public bool CanSubViewPlayShowView()
		{
			if (this.CanSubViewPlayShowViewInternal)
			{
				this.CanSubViewPlayShowViewInternal = false;
				return true;
			}
			return false;
		}

		// Token: 0x06041D27 RID: 269607 RVA: 0x010E3559 File Offset: 0x010E1759
		public void SetCanSubViewPlayShowView(bool value)
		{
			this.CanSubViewPlayShowViewInternal = value;
		}

		// Token: 0x06041D28 RID: 269608 RVA: 0x010E3564 File Offset: 0x010E1764
		public List<int> GetSortedQuestList(int ipId)
		{
			IEnumerable<MotorLinkageQuest> questConfigListByIpId = ConfigBase<ActivityMotorLinkageConfig>.Instance.GetQuestConfigListByIpId(ipId);
			List<List<MotorLinkageQuest>> list = new List<List<MotorLinkageQuest>>
			{
				new List<MotorLinkageQuest>(),
				new List<MotorLinkageQuest>(),
				new List<MotorLinkageQuest>()
			};
			foreach (MotorLinkageQuest item in questConfigListByIpId)
			{
				if (this.IsQuestCanReceive(item.TaskId))
				{
					list[0].Add(item);
				}
				else if (this.IsQuestRewardReceived(item.TaskId))
				{
					list[2].Add(item);
				}
				else
				{
					list[1].Add(item);
				}
			}
			List<int> list2 = new List<int>();
			foreach (List<MotorLinkageQuest> list3 in list)
			{
				list3.Sort((MotorLinkageQuest a, MotorLinkageQuest b) => a.Sort - b.Sort);
				foreach (MotorLinkageQuest motorLinkageQuest in list3)
				{
					list2.Add(motorLinkageQuest.TaskId);
				}
			}
			return list2;
		}

		// Token: 0x06041D29 RID: 269609 RVA: 0x010E36C8 File Offset: 0x010E18C8
		public List<int> GetSortedIpList()
		{
			List<MotorLinkageIp> list = new List<MotorLinkageIp>(ConfigBase<ActivityMotorLinkageConfig>.Instance.GetIpConfigAll());
			list.Sort((MotorLinkageIp a, MotorLinkageIp b) => a.Sort - b.Sort);
			List<int> list2 = new List<int>();
			foreach (MotorLinkageIp motorLinkageIp in list)
			{
				list2.Add(motorLinkageIp.Id);
			}
			return list2;
		}

		// Token: 0x06041D2A RID: 269610 RVA: 0x010E3758 File Offset: 0x010E1958
		public bool IsStickerReceived(int stickerId)
		{
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(stickerId, 0) > 0;
		}

		// Token: 0x06041D2B RID: 269611 RVA: 0x010E376C File Offset: 0x010E196C
		public int GetQuestCurrentProgress(int questId)
		{
			global::ActivityTaskData activityTaskData;
			if (!this.ActivityQuestData.TryGetValue(questId, out activityTaskData))
			{
				return 0;
			}
			return activityTaskData.Current;
		}

		// Token: 0x06041D2C RID: 269612 RVA: 0x010E3794 File Offset: 0x010E1994
		public int GetQuestTargetProgress(int questId)
		{
			global::ActivityTaskData activityTaskData;
			if (!this.ActivityQuestData.TryGetValue(questId, out activityTaskData))
			{
				return 0;
			}
			return activityTaskData.Target;
		}

		// Token: 0x06041D2D RID: 269613 RVA: 0x010E37BC File Offset: 0x010E19BC
		public bool IsQuestCanReceive(int questId)
		{
			global::ActivityTaskData activityTaskData;
			return this.ActivityQuestData.TryGetValue(questId, out activityTaskData) && activityTaskData.Status == EActivityTaskState.FinishedAndUnclaimed;
		}

		// Token: 0x06041D2E RID: 269614 RVA: 0x010E37E4 File Offset: 0x010E19E4
		public bool IsQuestRewardReceived(int questId)
		{
			global::ActivityTaskData activityTaskData;
			return this.ActivityQuestData.TryGetValue(questId, out activityTaskData) && activityTaskData.Status == EActivityTaskState.FinishedAndClaimed;
		}

		// Token: 0x06041D2F RID: 269615 RVA: 0x010E380C File Offset: 0x010E1A0C
		public void OnQuestUpdateNotify(MotorcycleTaskUpdateNotify notify)
		{
			ConditionTask task = notify.Task;
			int? num = (task != null) ? new int?(task.Id) : null;
			global::ActivityTaskData activityTaskData = null;
			if (num != null)
			{
				this.ActivityQuestData.TryGetValue(num.Value, out activityTaskData);
			}
			if (activityTaskData != null)
			{
				activityTaskData.Current = notify.Task.Current;
				activityTaskData.Target = notify.Task.Target;
				activityTaskData.Status = this.TaskServerStatus2ClientStatus(notify.Task.Status);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			}
		}

		// Token: 0x06041D30 RID: 269616 RVA: 0x010E38AC File Offset: 0x010E1AAC
		public void OnRewardReceiveNotify(int[] questIpList)
		{
			foreach (int key in questIpList)
			{
				global::ActivityTaskData activityTaskData;
				if (this.ActivityQuestData.TryGetValue(key, out activityTaskData))
				{
					activityTaskData.Status = EActivityTaskState.FinishedAndClaimed;
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06041D31 RID: 269617 RVA: 0x010E38FC File Offset: 0x010E1AFC
		public bool HasAnyRewardCanReceive()
		{
			foreach (MotorLinkageIp motorLinkageIp in ConfigBase<ActivityMotorLinkageConfig>.Instance.GetIpConfigAll())
			{
				if (this.IpHasAnyRewardCanReceive(motorLinkageIp.Id))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06041D32 RID: 269618 RVA: 0x010E395C File Offset: 0x010E1B5C
		public int GetAllIpTotalProgress()
		{
			int num = 0;
			foreach (MotorLinkageIp motorLinkageIp in ConfigBase<ActivityMotorLinkageConfig>.Instance.GetIpConfigAll())
			{
				num += this.GetIpTotalProgress(motorLinkageIp.Id);
			}
			return num;
		}

		// Token: 0x06041D33 RID: 269619 RVA: 0x010E39BC File Offset: 0x010E1BBC
		public int GetAllIpCurrentProgress()
		{
			int num = 0;
			foreach (MotorLinkageIp motorLinkageIp in ConfigBase<ActivityMotorLinkageConfig>.Instance.GetIpConfigAll())
			{
				num += this.GetIpCurrentProgress(motorLinkageIp.Id);
			}
			return num;
		}

		// Token: 0x06041D34 RID: 269620 RVA: 0x010E3A1C File Offset: 0x010E1C1C
		public bool IpHasAnyRewardCanReceive(int ipId)
		{
			foreach (MotorLinkageQuest motorLinkageQuest in ConfigBase<ActivityMotorLinkageConfig>.Instance.GetQuestConfigListByIpId(ipId))
			{
				if (this.IsQuestCanReceive(motorLinkageQuest.TaskId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06041D35 RID: 269621 RVA: 0x010E3A80 File Offset: 0x010E1C80
		public int GetIpTotalProgress(int ipId)
		{
			return ConfigBase<ActivityMotorLinkageConfig>.Instance.GetQuestConfigListByIpId(ipId).Count;
		}

		// Token: 0x06041D36 RID: 269622 RVA: 0x010E3A94 File Offset: 0x010E1C94
		public int GetIpCurrentProgress(int ipId)
		{
			IEnumerable<MotorLinkageQuest> questConfigListByIpId = ConfigBase<ActivityMotorLinkageConfig>.Instance.GetQuestConfigListByIpId(ipId);
			int num = 0;
			foreach (MotorLinkageQuest motorLinkageQuest in questConfigListByIpId)
			{
				if (this.IsQuestRewardReceived(motorLinkageQuest.TaskId))
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06041D37 RID: 269623 RVA: 0x010E3AF8 File Offset: 0x010E1CF8
		public bool IsActivityCompleted()
		{
			IReadOnlyList<MotorLinkageQuest> questConfigAll = ConfigBase<ActivityMotorLinkageConfig>.Instance.GetQuestConfigAll();
			int num = 0;
			foreach (MotorLinkageQuest motorLinkageQuest in questConfigAll)
			{
				if (this.IsQuestRewardReceived(motorLinkageQuest.TaskId))
				{
					num++;
				}
			}
			return num >= questConfigAll.Count;
		}

		// Token: 0x06041D38 RID: 269624 RVA: 0x010E3B68 File Offset: 0x010E1D68
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

		// Token: 0x06041D39 RID: 269625 RVA: 0x010E3B85 File Offset: 0x010E1D85
		public void ReadRedDot()
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 0, 0, 0, 1);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06041D3A RID: 269626 RVA: 0x010E3BB1 File Offset: 0x010E1DB1
		public bool HasSkipRedDot()
		{
			return base.IsUnLock() && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 1, 0, 0) == 0;
		}

		// Token: 0x06041D3B RID: 269627 RVA: 0x010E3BD4 File Offset: 0x010E1DD4
		public void ReadSkipRedDot()
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 1, 0, 0, 1);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06041D3C RID: 269628 RVA: 0x010E3C00 File Offset: 0x010E1E00
		public override bool GetExDataRedPointShowState()
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 0, 0, 0) == 0 || this.HasSkipRedDot() || (!this.IsActivityCompleted() && this.HasAnyRewardCanReceive());
		}

		// Token: 0x06041D3D RID: 269629 RVA: 0x010E3C39 File Offset: 0x010E1E39
		protected override bool GetExDataFinishShowState()
		{
			return this.IsActivityCompleted();
		}

		// Token: 0x04024BAC RID: 150444
		private readonly Dictionary<int, global::ActivityTaskData> ActivityQuestData = new Dictionary<int, global::ActivityTaskData>();

		// Token: 0x04024BAD RID: 150445
		private bool CanSubViewPlayShowViewInternal;
	}
}
