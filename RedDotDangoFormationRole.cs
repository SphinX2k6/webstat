using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200331D RID: 13085
public class RedDotDangoFormationRole : RedDotBase
{
	// Token: 0x0601B600 RID: 112128 RVA: 0x0083599C File Offset: 0x00833B9C
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RedDotDangoFormation);
	}

	// Token: 0x0601B601 RID: 112129 RVA: 0x008359A8 File Offset: 0x00833BA8
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B602 RID: 112130 RVA: 0x008359AB File Offset: 0x00833BAB
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshAbyssDangoRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B603 RID: 112131 RVA: 0x008359C9 File Offset: 0x00833BC9
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshAbyssDangoRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B604 RID: 112132 RVA: 0x008359E7 File Offset: 0x00833BE7
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<DangoAbyssModel>.Instance.GetDangoFormationNewRoleRedDot(uId);
	}
}
