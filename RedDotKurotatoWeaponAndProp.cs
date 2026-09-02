using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Kurotato.Data;

// Token: 0x020032DF RID: 13023
public class RedDotKurotatoWeaponAndProp : RedDotBase
{
	// Token: 0x0601B4F3 RID: 111859 RVA: 0x00833A8F File Offset: 0x00831C8F
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshKurotatoWeaponAndPropRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B4F4 RID: 111860 RVA: 0x00833AAD File Offset: 0x00831CAD
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshKurotatoWeaponAndPropRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B4F5 RID: 111861 RVA: 0x00833ACC File Offset: 0x00831CCC
	protected override ERedDotName? OnGetParentName()
	{
		return null;
	}

	// Token: 0x0601B4F6 RID: 111862 RVA: 0x00833AE4 File Offset: 0x00831CE4
	protected override bool OnCheck(int uId = 0)
	{
		KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
		return activityData != null && (activityData.IsKurotatoItemHasRedDot() || activityData.IsKurotatoWeaponHasRedDot());
	}
}
