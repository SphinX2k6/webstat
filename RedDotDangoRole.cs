using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003320 RID: 13088
public class RedDotDangoRole : RedDotBase
{
	// Token: 0x0601B615 RID: 112149 RVA: 0x00835C95 File Offset: 0x00833E95
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RedDotDangoDevelop);
	}

	// Token: 0x0601B616 RID: 112150 RVA: 0x00835CA1 File Offset: 0x00833EA1
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B617 RID: 112151 RVA: 0x00835CA4 File Offset: 0x00833EA4
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssAddRole, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnAbyssDangoLevelUp, new Action<int, int>(this.OnEventTwoInt));
		Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssRoleInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnEventTwoInt));
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshAbyssDevelopRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B618 RID: 112152 RVA: 0x00835D40 File Offset: 0x00833F40
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssAddRole, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnAbyssDangoLevelUp, new Action<int, int>(this.OnEventTwoInt));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssRoleInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnEventTwoInt));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshAbyssDevelopRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B619 RID: 112153 RVA: 0x00835DD9 File Offset: 0x00833FD9
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<DangoAbyssModel>.Instance.GetDangoRoleRedDot(uId);
	}

	// Token: 0x0601B61A RID: 112154 RVA: 0x00835DE6 File Offset: 0x00833FE6
	private void OnEventTwoInt(int _1, int _2)
	{
		base.EventCheck();
	}
}
