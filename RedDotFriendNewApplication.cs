using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003336 RID: 13110
public class RedDotFriendNewApplication : RedDotBase
{
	// Token: 0x0601B672 RID: 112242 RVA: 0x00836568 File Offset: 0x00834768
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FunctionFriend);
	}

	// Token: 0x0601B673 RID: 112243 RVA: 0x00836571 File Offset: 0x00834771
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshFriendApplicationRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateFriendViewShow, new Action(base.EventCheck));
	}

	// Token: 0x0601B674 RID: 112244 RVA: 0x008365AB File Offset: 0x008347AB
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshFriendApplicationRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateFriendViewShow, new Action(base.EventCheck));
	}

	// Token: 0x0601B675 RID: 112245 RVA: 0x008365E5 File Offset: 0x008347E5
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<FriendModel>.Instance.HasNewFriendApplication();
	}
}
