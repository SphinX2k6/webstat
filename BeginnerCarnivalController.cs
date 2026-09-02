using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;

// Token: 0x02001253 RID: 4691
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BeginnerCarnivalController : ActivityControllerBase<BeginnerCarnivalController>
{
	// Token: 0x06007D03 RID: 32003 RVA: 0x0020EE16 File Offset: 0x0020D016
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06007D04 RID: 32004 RVA: 0x0020EE18 File Offset: 0x0020D018
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_NewPlayerCelebration";
	}

	// Token: 0x06007D05 RID: 32005 RVA: 0x0020EE1F File Offset: 0x0020D01F
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new BeginnerCarnivalSubView();
	}

	// Token: 0x06007D06 RID: 32006 RVA: 0x0020EE26 File Offset: 0x0020D026
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.ActivityId = data.Id;
		return new BeginnerCarnivalData();
	}

	// Token: 0x06007D07 RID: 32007 RVA: 0x0020EE39 File Offset: 0x0020D039
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06007D08 RID: 32008 RVA: 0x0020EE3C File Offset: 0x0020D03C
	public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BeginnerCarnivalUnlockTipView, null, null);
	}

	// Token: 0x06007D09 RID: 32009 RVA: 0x0020EE4F File Offset: 0x0020D04F
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<NewbieCarnivalTaskDataUpdateNotify>(ENotifyMessageId.NewbieCarnivalTaskDataUpdateNotify, new Action<NewbieCarnivalTaskDataUpdateNotify, Net.CallbackStatus>(this.NewbieCarnivalTaskDataUpdateNotify));
		Singleton<Net>.Instance.Register<NewbieCarnivalTaskJumpUpdateNotify>(ENotifyMessageId.NewbieCarnivalTaskJumpUpdateNotify, new Action<NewbieCarnivalTaskJumpUpdateNotify, Net.CallbackStatus>(this.NewbieCarnivalTaskJumpUpdateNotify));
	}

	// Token: 0x06007D0A RID: 32010 RVA: 0x0020EE89 File Offset: 0x0020D089
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewbieCarnivalTaskDataUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewbieCarnivalTaskJumpUpdateNotify);
	}

	// Token: 0x06007D0B RID: 32011 RVA: 0x0020EEAC File Offset: 0x0020D0AC
	public void NewbieCarnivalTaskDataUpdateNotify(NewbieCarnivalTaskDataUpdateNotify massage, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<ActivityTask> activityTasks = massage.ActivityTaskData.ActivityTasks;
		BeginnerCarnivalData beginnerCarnivalData = this.GetBeginnerCarnivalData();
		if (beginnerCarnivalData == null)
		{
			return;
		}
		foreach (ActivityTask activityTask in activityTasks)
		{
			NewbieCarnivalTask? newbieCarnivalTask = ConfigBase<BeginnerCarnivalConfig>.Instance.GetNewbieCarnivalTask(activityTask.Id);
			if (newbieCarnivalTask != null)
			{
				List<ActivityTask> list;
				if (!beginnerCarnivalData.TaskDataMap.TryGetValue(newbieCarnivalTask.Value.TaskType, out list) || list == null)
				{
					list = new List<ActivityTask>();
				}
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].Id == activityTask.Id)
					{
						list[i] = activityTask;
						break;
					}
				}
				beginnerCarnivalData.TaskDataMap[newbieCarnivalTask.Value.TaskType] = list;
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshBeginnerCarnivalTask, newbieCarnivalTask.Value.TaskType);
			}
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
	}

	// Token: 0x06007D0C RID: 32012 RVA: 0x0020EFE0 File Offset: 0x0020D1E0
	public void NewbieCarnivalTaskJumpUpdateNotify(NewbieCarnivalTaskJumpUpdateNotify massage, [Nullable(2)] Net.CallbackStatus status)
	{
		BeginnerCarnivalData beginnerCarnivalData = this.GetBeginnerCarnivalData();
		foreach (JumpTaskCondInfo jumpTaskCondInfo in massage.JumpTaskCondInfos)
		{
			beginnerCarnivalData.JumpTaskMap[jumpTaskCondInfo.JumpTaskId] = jumpTaskCondInfo.ConditionGroupIds.ToList<int>();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshBeginnerCarnivalTask, jumpTaskCondInfo.JumpTaskId);
		}
	}

	// Token: 0x06007D0D RID: 32013 RVA: 0x0020F060 File Offset: 0x0020D260
	public void NewbieCarnivalAwardRequest(int taskId)
	{
		NewbieCarnivalAwardRequest newbieCarnivalAwardRequest = Aki.Protocol.NewbieCarnivalAwardRequest.Create();
		newbieCarnivalAwardRequest.ActivityId = this.ActivityId;
		newbieCarnivalAwardRequest.Config = taskId;
		Singleton<Net>.Instance.Call<NewbieCarnivalAwardResponse>(ERequestMessageId.NewbieCarnivalAwardRequest, newbieCarnivalAwardRequest, delegate(NewbieCarnivalAwardResponse response, [Nullable(2)] Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19139, null, true, true);
			}
			BeginnerCarnivalData beginnerCarnivalData = this.GetBeginnerCarnivalData();
			if (beginnerCarnivalData == null)
			{
				return;
			}
			foreach (KeyValuePair<int, List<ActivityTask>> keyValuePair in beginnerCarnivalData.TaskDataMap)
			{
				int key = keyValuePair.Key;
				List<ActivityTask> value = keyValuePair.Value;
				for (int i = 0; i < value.Count; i++)
				{
					ActivityTask activityTask = value[i];
					if (activityTask.Id == taskId)
					{
						activityTask.Status = ActivityTaskState.ActivityTaskTaken;
						value[i] = activityTask;
						Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshBeginnerCarnivalTask, key);
						break;
					}
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
		}, 0);
	}

	// Token: 0x06007D0E RID: 32014 RVA: 0x0020F0BC File Offset: 0x0020D2BC
	public void NewbieCarnivalSwitchRoleRequest(int roleId)
	{
		NewbieCarnivalSwitchRoleRequest newbieCarnivalSwitchRoleRequest = Aki.Protocol.NewbieCarnivalSwitchRoleRequest.Create();
		newbieCarnivalSwitchRoleRequest.ActivityId = this.ActivityId;
		newbieCarnivalSwitchRoleRequest.RoleId = roleId;
		Singleton<Net>.Instance.Call<NewbieCarnivalSwitchRoleResponse>(ERequestMessageId.NewbieCarnivalSwitchRoleRequest, newbieCarnivalSwitchRoleRequest, delegate(NewbieCarnivalSwitchRoleResponse response, [Nullable(2)] Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22107, null, true, true);
			}
			this.GetBeginnerCarnivalData().ChoseRoleId = roleId;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshBeginnerCarnivalChoseRole);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
		}, 0);
	}

	// Token: 0x06007D0F RID: 32015 RVA: 0x0020F118 File Offset: 0x0020D318
	public BeginnerCarnivalData GetBeginnerCarnivalData()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as BeginnerCarnivalData;
	}

	// Token: 0x04003BD5 RID: 15317
	public int ActivityId;
}
