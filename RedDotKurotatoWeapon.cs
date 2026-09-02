using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Kurotato.Data;

// Token: 0x020032DE RID: 13022
public class RedDotKurotatoWeapon : RedDotBase
{
	// Token: 0x0601B4EE RID: 111854 RVA: 0x00833A1B File Offset: 0x00831C1B
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshKurotatoWeaponAndPropRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B4EF RID: 111855 RVA: 0x00833A39 File Offset: 0x00831C39
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshKurotatoWeaponAndPropRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B4F0 RID: 111856 RVA: 0x00833A57 File Offset: 0x00831C57
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RedDotKurotatoWeaponAndProp);
	}

	// Token: 0x0601B4F1 RID: 111857 RVA: 0x00833A64 File Offset: 0x00831C64
	protected override bool OnCheck(int uId = 0)
	{
		KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
		return activityData != null && activityData.IsKurotatoWeaponHasRedDot();
	}
}
