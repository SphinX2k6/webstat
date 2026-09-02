using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033BD RID: 13245
public class RedDotRoleBreakUp : RedDotBase
{
	// Token: 0x0601B8E3 RID: 112867 RVA: 0x0083B748 File Offset: 0x00839948
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B8E4 RID: 112868 RVA: 0x0083B74C File Offset: 0x0083994C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int, int, int>(EEventName.RoleLevelUp, new Action<int, int, int>(this.OnRoleLevelUp));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.RoleBreakUp, new Action<int, int>(this.OnRoleBreakUp));
		Singleton<EventSystem>.Instance.Add(EEventName.CurWorldLevelChange, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ActiveRole, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8E5 RID: 112869 RVA: 0x0083B7E8 File Offset: 0x008399E8
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int, int, int>(EEventName.RoleLevelUp, new Action<int, int, int>(this.OnRoleLevelUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.RoleBreakUp, new Action<int, int>(this.OnRoleBreakUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.CurWorldLevelChange, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.ActiveRole, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8E6 RID: 112870 RVA: 0x0083B881 File Offset: 0x00839A81
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<RoleModel>.Instance.RedDotAttributeTabBreakUpCondition(uId);
	}

	// Token: 0x0601B8E7 RID: 112871 RVA: 0x0083B88E File Offset: 0x00839A8E
	private void OnRoleLevelUp(int roleId, int oldLevel, int newLevel)
	{
		base.EventCheckWithUid(roleId);
	}

	// Token: 0x0601B8E8 RID: 112872 RVA: 0x0083B897 File Offset: 0x00839A97
	private void OnRoleBreakUp(int roleId, int level)
	{
		base.EventCheckWithUid(roleId);
	}
}
