using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;

// Token: 0x020032D6 RID: 13014
public class RedDotCyberPunkTaskTab : RedDotBase
{
	// Token: 0x0601B4C5 RID: 111813 RVA: 0x00833595 File Offset: 0x00831795
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCyberPunkTaskRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B4C6 RID: 111814 RVA: 0x008335CF File Offset: 0x008317CF
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCyberPunkTaskRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B4C7 RID: 111815 RVA: 0x00833609 File Offset: 0x00831809
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.CommonActivityPage);
	}

	// Token: 0x0601B4C8 RID: 111816 RVA: 0x00833612 File Offset: 0x00831812
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B4C9 RID: 111817 RVA: 0x00833618 File Offset: 0x00831818
	protected override bool OnCheck(int tabIndex)
	{
		CyberPunkController instance = ControllerBase<CyberPunkController>.Instance;
		CyberPunkData cyberPunkData = (instance != null) ? instance.GetCurrentActivityData() : null;
		return cyberPunkData != null && cyberPunkData.HasCyberPunkTaskRedDot(tabIndex);
	}
}
