using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200331B RID: 13083
public class RedDotDangoDevelop : RedDotBase
{
	// Token: 0x0601B5F5 RID: 112117 RVA: 0x008357F3 File Offset: 0x008339F3
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B5F6 RID: 112118 RVA: 0x008357F8 File Offset: 0x008339F8
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssAddRole, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnAbyssDangoLevelUp, new Action<int, int>(this.OnEventTwoInt));
		Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssRoleInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnEventTwoInt));
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshAbyssDevelopRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B5F7 RID: 112119 RVA: 0x00835894 File Offset: 0x00833A94
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssAddRole, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnAbyssDangoLevelUp, new Action<int, int>(this.OnEventTwoInt));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssRoleInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnEventTwoInt));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshAbyssDevelopRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B5F8 RID: 112120 RVA: 0x0083592D File Offset: 0x00833B2D
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<DangoAbyssModel>.Instance.GetDangoDevelopRedDot();
	}

	// Token: 0x0601B5F9 RID: 112121 RVA: 0x00835939 File Offset: 0x00833B39
	private void OnEventTwoInt(int _1, int _2)
	{
		base.EventCheck();
	}
}
