using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Kurotato.Data;

// Token: 0x020032DD RID: 13021
public class RedDotKurotatoRole : RedDotBase
{
	// Token: 0x0601B4E9 RID: 111849 RVA: 0x0083399B File Offset: 0x00831B9B
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshKurotatoRoleRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B4EA RID: 111850 RVA: 0x008339B9 File Offset: 0x00831BB9
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshKurotatoRoleRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B4EB RID: 111851 RVA: 0x008339D8 File Offset: 0x00831BD8
	protected override ERedDotName? OnGetParentName()
	{
		return null;
	}

	// Token: 0x0601B4EC RID: 111852 RVA: 0x008339F0 File Offset: 0x00831BF0
	protected override bool OnCheck(int uId = 0)
	{
		KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
		return activityData != null && activityData.IsRoleHasRedDot();
	}
}
