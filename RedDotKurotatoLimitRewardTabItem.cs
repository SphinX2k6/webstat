using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Kurotato.Data;

// Token: 0x020032DA RID: 13018
public class RedDotKurotatoLimitRewardTabItem : RedDotBase
{
	// Token: 0x0601B4DB RID: 111835 RVA: 0x00833855 File Offset: 0x00831A55
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B4DC RID: 111836 RVA: 0x00833858 File Offset: 0x00831A58
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshKurotatoLimitRewardData, new Action(base.EventCheck));
	}

	// Token: 0x0601B4DD RID: 111837 RVA: 0x00833876 File Offset: 0x00831A76
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshKurotatoLimitRewardData, new Action(base.EventCheck));
	}

	// Token: 0x0601B4DE RID: 111838 RVA: 0x00833894 File Offset: 0x00831A94
	protected override bool OnCheck(int uId = 0)
	{
		KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
		return activityData != null && activityData.IsLimitedTimeTaskTabHasAnyClaimable(uId);
	}
}
