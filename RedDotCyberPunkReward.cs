using System;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;

// Token: 0x020032D4 RID: 13012
public class RedDotCyberPunkReward : RedDotBase
{
	// Token: 0x0601B4BB RID: 111803 RVA: 0x00833411 File Offset: 0x00831611
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCyberPunkTaskRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B4BC RID: 111804 RVA: 0x0083344B File Offset: 0x0083164B
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCyberPunkTaskRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B4BD RID: 111805 RVA: 0x00833488 File Offset: 0x00831688
	protected override bool OnCheck(int uId = 0)
	{
		CyberPunkController instance = ControllerBase<CyberPunkController>.Instance;
		CyberPunkData cyberPunkData = (instance != null) ? instance.GetCurrentActivityData() : null;
		return cyberPunkData != null && cyberPunkData.GetCyberPunkTaskSliderData().Status == ConditionTaskState.ConditionTaskFinish;
	}
}
