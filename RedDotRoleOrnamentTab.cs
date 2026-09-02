using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033C6 RID: 13254
public class RedDotRoleOrnamentTab : RedDotBase
{
	// Token: 0x0601B911 RID: 112913 RVA: 0x0083BDA9 File Offset: 0x00839FA9
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleOrnamentRedDotRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B912 RID: 112914 RVA: 0x0083BDC7 File Offset: 0x00839FC7
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleOrnamentRedDotRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B913 RID: 112915 RVA: 0x0083BDE5 File Offset: 0x00839FE5
	protected override bool OnCheck(int roleId = 0)
	{
		return ModelBase<RoleOrnamentModel>.Instance.CheckNewlyAddedOrnamentHasRedDotByRoleId(roleId) || ModelBase<RoleOrnamentModel>.Instance.CheckNewlyAcquiredOrnamentHasRedDotByRoleId(roleId);
	}
}
