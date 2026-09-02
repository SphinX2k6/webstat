using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02002852 RID: 10322
public class RedDotFavorTab : RedDotBase
{
	// Token: 0x06014791 RID: 83857 RVA: 0x005AEBCF File Offset: 0x005ACDCF
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x06014792 RID: 83858 RVA: 0x005AEBD2 File Offset: 0x005ACDD2
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.UnLockRoleFavorItem, new Action<int, int>(this.OnUnLockRoleFavorItem));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.UpdateRoleFavorData, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x06014793 RID: 83859 RVA: 0x005AEC0C File Offset: 0x005ACE0C
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.UnLockRoleFavorItem, new Action<int, int>(this.OnUnLockRoleFavorItem));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.UpdateRoleFavorData, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x06014794 RID: 83860 RVA: 0x005AEC48 File Offset: 0x005ACE48
	protected override bool OnCheck(int roleId)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		return roleDataById != null && roleDataById.GetFavorData().IsExistCanUnlockFavorItem();
	}

	// Token: 0x06014795 RID: 83861 RVA: 0x005AEC72 File Offset: 0x005ACE72
	private void OnUnLockRoleFavorItem(int roleId, int _)
	{
		base.EventCheckWithUid(roleId);
	}
}
