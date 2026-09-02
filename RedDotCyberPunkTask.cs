using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;

// Token: 0x020032D5 RID: 13013
public class RedDotCyberPunkTask : RedDotBase
{
	// Token: 0x0601B4BF RID: 111807 RVA: 0x008334C2 File Offset: 0x008316C2
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCyberPunkTaskRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B4C0 RID: 111808 RVA: 0x008334FC File Offset: 0x008316FC
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCyberPunkTaskRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B4C1 RID: 111809 RVA: 0x00833536 File Offset: 0x00831736
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.CommonActivityPage);
	}

	// Token: 0x0601B4C2 RID: 111810 RVA: 0x0083353F File Offset: 0x0083173F
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B4C3 RID: 111811 RVA: 0x00833544 File Offset: 0x00831744
	protected override bool OnCheck(int uId = 0)
	{
		CyberPunkController instance = ControllerBase<CyberPunkController>.Instance;
		CyberPunkData cyberPunkData = (instance != null) ? instance.GetCurrentActivityData() : null;
		if (cyberPunkData == null)
		{
			return false;
		}
		if (uId > 0)
		{
			CyberPunkTaskData taskDataById = cyberPunkData.GetTaskDataById(uId);
			return taskDataById != null && taskDataById.IsFinished();
		}
		return cyberPunkData.GetClaimableTaskIds().Count > 0;
	}
}
