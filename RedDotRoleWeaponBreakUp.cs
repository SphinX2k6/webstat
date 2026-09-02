using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033C2 RID: 13250
public class RedDotRoleWeaponBreakUp : RedDotBase
{
	// Token: 0x0601B8FD RID: 112893 RVA: 0x0083BBDE File Offset: 0x00839DDE
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B8FE RID: 112894 RVA: 0x0083BBE4 File Offset: 0x00839DE4
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WeaponLevelUp, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.WeaponBreakUp, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.WeaponResonanceSuccess, new Action<int, int>(this.OnWeaponResonanceSuccess));
	}

	// Token: 0x0601B8FF RID: 112895 RVA: 0x0083BC48 File Offset: 0x00839E48
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WeaponLevelUp, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.WeaponBreakUp, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.WeaponResonanceSuccess, new Action<int, int>(this.OnWeaponResonanceSuccess));
	}

	// Token: 0x0601B900 RID: 112896 RVA: 0x0083BCA9 File Offset: 0x00839EA9
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<WeaponModel>.Instance.RedDotWeaponBreachCondition(uId) || ModelBase<WeaponModel>.Instance.RedDotWeaponResonanceConditionByRole(uId) || ModelBase<WeaponSkinModel>.Instance.RedDotWeaponSkinCondition(uId);
	}

	// Token: 0x0601B901 RID: 112897 RVA: 0x0083BCD4 File Offset: 0x00839ED4
	private void OnWeaponResonanceSuccess(int roleId, int weaponId)
	{
		base.EventCheckWithUid(roleId);
	}
}
