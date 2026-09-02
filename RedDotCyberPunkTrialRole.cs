using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;

// Token: 0x020032D7 RID: 13015
public class RedDotCyberPunkTrialRole : RedDotBase
{
	// Token: 0x0601B4CB RID: 111819 RVA: 0x0083364B File Offset: 0x0083184B
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnTrialRoleDataChanged, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B4CC RID: 111820 RVA: 0x00833685 File Offset: 0x00831885
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnTrialRoleDataChanged, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B4CD RID: 111821 RVA: 0x008336BF File Offset: 0x008318BF
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.CommonActivityPage);
	}

	// Token: 0x0601B4CE RID: 111822 RVA: 0x008336C8 File Offset: 0x008318C8
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B4CF RID: 111823 RVA: 0x008336CB File Offset: 0x008318CB
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B4D0 RID: 111824 RVA: 0x008336D0 File Offset: 0x008318D0
	protected override bool OnCheck(int uId = 0)
	{
		CyberPunkController instance = ControllerBase<CyberPunkController>.Instance;
		CyberPunkData cyberPunkData = (instance != null) ? instance.GetCurrentActivityData() : null;
		if (cyberPunkData == null)
		{
			return false;
		}
		IReadOnlyList<EdgeRunnerTrial> configList = ConfigEdgeRunnerTrialByCyberPunkActivityId.GetConfigList(cyberPunkData.Id, true);
		if (configList == null || configList.Count == 0)
		{
			return false;
		}
		foreach (EdgeRunnerTrial edgeRunnerTrial in configList)
		{
			ActivityRoleTrialData activityRoleTrialData = ModelBase<ActivityModel>.Instance.GetActivityById(edgeRunnerTrial.ActivityId) as ActivityRoleTrialData;
			if (activityRoleTrialData != null && activityRoleTrialData.GetRewardStateByRoleId(edgeRunnerTrial.Id) == ERoleTrialRewardState.FinishedAndUnClaimed)
			{
				return true;
			}
		}
		return false;
	}
}
