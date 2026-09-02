using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033BF RID: 13247
public class RedDotRoleLevelUp : RedDotBase
{
	// Token: 0x0601B8EC RID: 112876 RVA: 0x0083B8D3 File Offset: 0x00839AD3
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B8ED RID: 112877 RVA: 0x0083B8D8 File Offset: 0x00839AD8
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int, int, int>(EEventName.RoleLevelUp, new Action<int, int, int>(this.OnRoleLevelUp));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.RoleBreakUp, new Action<int, int>(this.OnRoleBreakUp));
		Singleton<EventSystem>.Instance.Add(EEventName.CurWorldLevelChange, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ActiveRole, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8EE RID: 112878 RVA: 0x0083B974 File Offset: 0x00839B74
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int, int, int>(EEventName.RoleLevelUp, new Action<int, int, int>(this.OnRoleLevelUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.RoleBreakUp, new Action<int, int>(this.OnRoleBreakUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.CurWorldLevelChange, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.ActiveRole, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8EF RID: 112879 RVA: 0x0083BA0D File Offset: 0x00839C0D
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<RoleModel>.Instance.RedDotAttributeTabLevelUpCondition(uId);
	}

	// Token: 0x0601B8F0 RID: 112880 RVA: 0x0083BA1A File Offset: 0x00839C1A
	private void OnRoleLevelUp(int roleId, int oldLevel, int newLevel)
	{
		base.EventCheckWithUid(roleId);
	}

	// Token: 0x0601B8F1 RID: 112881 RVA: 0x0083BA23 File Offset: 0x00839C23
	private void OnRoleBreakUp(int roleId, int level)
	{
		base.EventCheckWithUid(roleId);
	}
}
