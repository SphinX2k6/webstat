using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033C0 RID: 13248
public class RedDotRoleSkin : RedDotBase
{
	// Token: 0x0601B8F3 RID: 112883 RVA: 0x0083BA34 File Offset: 0x00839C34
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B8F4 RID: 112884 RVA: 0x0083BA37 File Offset: 0x00839C37
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSkinRedDotRefresh, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleOrnamentRedDotRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8F5 RID: 112885 RVA: 0x0083BA71 File Offset: 0x00839C71
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleSkinRedDotRefresh, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleOrnamentRedDotRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8F6 RID: 112886 RVA: 0x0083BAAC File Offset: 0x00839CAC
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<RoleSkinModel>.Instance.HasRoleSkinRedDotByRoleId(uId) || ModelBase<FlySkinModel>.Instance.CheckFlySkinHasRedDot() || ModelBase<CalabashSkinModel>.Instance.CheckCalabashSkinHasRedDotByRoleId(uId) || ModelBase<RoleOrnamentModel>.Instance.CheckNewlyAddedOrnamentHasRedDotByRoleId(uId) || ModelBase<RoleOrnamentModel>.Instance.CheckNewlyAcquiredOrnamentHasRedDotByRoleId(uId);
	}
}
