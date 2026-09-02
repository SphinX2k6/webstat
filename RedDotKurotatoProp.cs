using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Kurotato.Data;

// Token: 0x020032DC RID: 13020
public class RedDotKurotatoProp : RedDotBase
{
	// Token: 0x0601B4E4 RID: 111844 RVA: 0x00833927 File Offset: 0x00831B27
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshKurotatoWeaponAndPropRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B4E5 RID: 111845 RVA: 0x00833945 File Offset: 0x00831B45
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshKurotatoWeaponAndPropRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B4E6 RID: 111846 RVA: 0x00833963 File Offset: 0x00831B63
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RedDotKurotatoWeaponAndProp);
	}

	// Token: 0x0601B4E7 RID: 111847 RVA: 0x00833970 File Offset: 0x00831B70
	protected override bool OnCheck(int uId = 0)
	{
		KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
		return activityData != null && activityData.IsKurotatoItemHasRedDot();
	}
}
