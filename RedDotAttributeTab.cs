using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033BC RID: 13244
public class RedDotAttributeTab : RedDotBase
{
	// Token: 0x0601B8DC RID: 112860 RVA: 0x0083B56C File Offset: 0x0083976C
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B8DD RID: 112861 RVA: 0x0083B570 File Offset: 0x00839770
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int, int, int>(EEventName.RoleLevelUp, new Action<int, int, int>(this.OnRoleLevelUp));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.RoleBreakUp, new Action<int, int>(this.OnRoleBreakUp));
		Singleton<EventSystem>.Instance.Add(EEventName.CurWorldLevelChange, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ActiveRole, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSkinRedDotRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8DE RID: 112862 RVA: 0x0083B628 File Offset: 0x00839828
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int, int, int>(EEventName.RoleLevelUp, new Action<int, int, int>(this.OnRoleLevelUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.RoleBreakUp, new Action<int, int>(this.OnRoleBreakUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.CurWorldLevelChange, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.ActiveRole, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleSkinRedDotRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8DF RID: 112863 RVA: 0x0083B6E0 File Offset: 0x008398E0
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<RoleModel>.Instance.RedDotAttributeTabBreakUpCondition(uId) || ModelBase<RoleSkinModel>.Instance.HasRoleSkinRedDotByRoleId(uId) || ModelBase<CalabashSkinModel>.Instance.CheckCalabashSkinHasRedDotByRoleId(uId) || ModelBase<RoleOrnamentModel>.Instance.CheckNewlyAddedOrnamentHasRedDotByRoleId(uId) || ModelBase<RoleOrnamentModel>.Instance.CheckNewlyAcquiredOrnamentHasRedDotByRoleId(uId);
	}

	// Token: 0x0601B8E0 RID: 112864 RVA: 0x0083B72E File Offset: 0x0083992E
	private void OnRoleLevelUp(int roleId, int oldLevel, int newLevel)
	{
		base.EventCheckWithUid(roleId);
	}

	// Token: 0x0601B8E1 RID: 112865 RVA: 0x0083B737 File Offset: 0x00839937
	private void OnRoleBreakUp(int roleId, int level)
	{
		base.EventCheckWithUid(roleId);
	}
}
