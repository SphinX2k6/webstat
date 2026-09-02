using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Kurotato.Data;

// Token: 0x020032DB RID: 13019
public class RedDotKurotatoNormalRewardBtn : RedDotBase
{
	// Token: 0x0601B4E0 RID: 111840 RVA: 0x008338C0 File Offset: 0x00831AC0
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshKurotatoNormalRewardData, new Action(base.EventCheck));
	}

	// Token: 0x0601B4E1 RID: 111841 RVA: 0x008338DE File Offset: 0x00831ADE
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshKurotatoNormalRewardData, new Action(base.EventCheck));
	}

	// Token: 0x0601B4E2 RID: 111842 RVA: 0x008338FC File Offset: 0x00831AFC
	protected override bool OnCheck(int uId = 0)
	{
		KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
		return activityData != null && activityData.IsNormalRewardViewHasRedDot();
	}
}
