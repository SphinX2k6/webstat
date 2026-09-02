using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033BB RID: 13243
public class RedDotRoleSystemRoleList : RedDotBase
{
	// Token: 0x0601B8D5 RID: 112853 RVA: 0x0083B176 File Offset: 0x00839376
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B8D6 RID: 112854 RVA: 0x0083B17C File Offset: 0x0083937C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int, int, int>(EEventName.RoleLevelUp, new Action<int, int, int>(this.OnEventThreeInt));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.RoleBreakUp, new Action<int, int>(this.OnEventTwoInt));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateRoleResonanceDetailView, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotRefreshPhantomEquip, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RedDotRoleChange, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUnLockPhantom, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RedDotCreateRole, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemDeleteRole, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add(EEventName.PhantomEquip, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSkinRedDotRefresh, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.WeaponResonanceSuccess, new Action<int, int>(this.OnEventTwoInt));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleOrnamentRedDotRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8D7 RID: 112855 RVA: 0x0083B314 File Offset: 0x00839514
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int, int, int>(EEventName.RoleLevelUp, new Action<int, int, int>(this.OnEventThreeInt));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.RoleBreakUp, new Action<int, int>(this.OnEventTwoInt));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateRoleResonanceDetailView, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotRefreshPhantomEquip, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RedDotRoleChange, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUnLockPhantom, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RedDotCreateRole, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleSystemChangeRole, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleSystemDeleteRole, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove(EEventName.PhantomEquip, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleSkinRedDotRefresh, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.WeaponResonanceSuccess, new Action<int, int>(this.OnEventTwoInt));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleOrnamentRedDotRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8D8 RID: 112856 RVA: 0x0083B4AC File Offset: 0x008396AC
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<RoleModel>.Instance.GetRoleInstanceById(uId) != null && (ModelBase<RoleSkinModel>.Instance.HasRoleSkinRedDotByRoleId(uId) || ModelBase<RoleOrnamentModel>.Instance.CheckNewlyAcquiredOrnamentHasRedDotByRoleId(uId) || ModelBase<RoleModel>.Instance.RedDotResonanceTabCondition(uId) || (ModelBase<EditFormationModel>.Instance.IsRoleInCurrentFormation(uId) && (ModelBase<RoleModel>.Instance.RedDotAttributeTabBreakUpCondition(uId) || ModelBase<WeaponModel>.Instance.RedDotWeaponBreachCondition(uId) || ModelBase<WeaponModel>.Instance.RedDotWeaponResonanceConditionByRole(uId) || ModelBase<VisionRecommendModel>.Instance.CheckVisionOneKeyEquipRedDot(uId) || ModelBase<CalabashSkinModel>.Instance.CheckCalabashSkinHasRedDotByRoleId(uId))));
	}

	// Token: 0x0601B8D9 RID: 112857 RVA: 0x0083B552 File Offset: 0x00839752
	private void OnEventThreeInt(int configId, int exp, int level)
	{
		base.EventCheckWithUid(configId);
	}

	// Token: 0x0601B8DA RID: 112858 RVA: 0x0083B55B File Offset: 0x0083975B
	private void OnEventTwoInt(int roleId, int level)
	{
		base.EventCheckWithUid(roleId);
	}
}
