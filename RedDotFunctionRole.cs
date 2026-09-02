using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003343 RID: 13123
public class RedDotFunctionRole : RedDotBase
{
	// Token: 0x0601B6A8 RID: 112296 RVA: 0x00836D93 File Offset: 0x00834F93
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattleViewResonanceButton);
	}

	// Token: 0x0601B6A9 RID: 112297 RVA: 0x00836D9C File Offset: 0x00834F9C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleChangeEnd, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateRoleResonanceDetailView, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MainViewRoleButtonRefreshByRoleSkin, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MainViewRoleButtonRefreshByRoleOrnament, new Action(base.EventCheck));
	}

	// Token: 0x0601B6AA RID: 112298 RVA: 0x00836E38 File Offset: 0x00835038
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleChangeEnd, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateRoleResonanceDetailView, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MainViewRoleButtonRefreshByRoleSkin, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MainViewRoleButtonRefreshByRoleOrnament, new Action(base.EventCheck));
	}

	// Token: 0x0601B6AB RID: 112299 RVA: 0x00836ED1 File Offset: 0x008350D1
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<RoleModel>.Instance.RedDotCondition();
	}
}
