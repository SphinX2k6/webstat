using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02001731 RID: 5937
public class RedDotCommonActivityPage : RedDotBase
{
	// Token: 0x0600A597 RID: 42391 RVA: 0x002BC6FF File Offset: 0x002BA8FF
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.ActivityEntrance);
	}

	// Token: 0x0600A598 RID: 42392 RVA: 0x002BC708 File Offset: 0x002BA908
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0600A599 RID: 42393 RVA: 0x002BC70B File Offset: 0x002BA90B
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0600A59A RID: 42394 RVA: 0x002BC729 File Offset: 0x002BA929
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0600A59B RID: 42395 RVA: 0x002BC747 File Offset: 0x002BA947
	protected override bool OnCheck(int uid)
	{
		return ModelBase<ActivityModel>.Instance.GetActivityRedDotState(uid);
	}
}
