using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033C1 RID: 13249
public class RedDotResonanceTab : RedDotBase
{
	// Token: 0x0601B8F8 RID: 112888 RVA: 0x0083BB01 File Offset: 0x00839D01
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B8F9 RID: 112889 RVA: 0x0083BB04 File Offset: 0x00839D04
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateRoleResonanceDetailView, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8FA RID: 112890 RVA: 0x0083BB68 File Offset: 0x00839D68
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateRoleResonanceDetailView, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleSystemChangeRole, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8FB RID: 112891 RVA: 0x0083BBC9 File Offset: 0x00839DC9
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<RoleModel>.Instance.RedDotResonanceTabCondition(uId);
	}
}
