using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Kurotato.Data;

// Token: 0x020032D9 RID: 13017
public class RedDotKurotatoLimitRewardBtn : RedDotBase
{
	// Token: 0x0601B4D7 RID: 111831 RVA: 0x008337E2 File Offset: 0x008319E2
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshKurotatoLimitRewardData, new Action(base.EventCheck));
	}

	// Token: 0x0601B4D8 RID: 111832 RVA: 0x00833800 File Offset: 0x00831A00
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshKurotatoLimitRewardData, new Action(base.EventCheck));
	}

	// Token: 0x0601B4D9 RID: 111833 RVA: 0x00833820 File Offset: 0x00831A20
	protected override bool OnCheck(int uId = 0)
	{
		KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
		return activityData != null && (activityData.IsLimitTimeRewardViewHasRedDot() || activityData.IsScoreRewardHasRedDot());
	}
}
