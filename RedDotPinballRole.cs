using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032E0 RID: 13024
public class RedDotPinballRole : RedDotBase
{
	// Token: 0x0601B4F8 RID: 111864 RVA: 0x00833B19 File Offset: 0x00831D19
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshPinballRoleRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B4F9 RID: 111865 RVA: 0x00833B37 File Offset: 0x00831D37
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshPinballRoleRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B4FA RID: 111866 RVA: 0x00833B55 File Offset: 0x00831D55
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RedDotPinballRoleFunction);
	}

	// Token: 0x0601B4FB RID: 111867 RVA: 0x00833B61 File Offset: 0x00831D61
	protected override bool OnCheck(int uId = 0)
	{
		return false;
	}
}
