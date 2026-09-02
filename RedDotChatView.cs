using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003314 RID: 13076
public class RedDotChatView : RedDotBase
{
	// Token: 0x0601B5D9 RID: 112089 RVA: 0x00835550 File Offset: 0x00833750
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<ChatModel>.Instance.HasRedDot();
	}

	// Token: 0x0601B5DA RID: 112090 RVA: 0x0083555C File Offset: 0x0083375C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshChatRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRemoveFriend, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B5DB RID: 112091 RVA: 0x00835596 File Offset: 0x00833796
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshChatRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRemoveFriend, new Action<int>(base.EventCheckWithUid));
	}
}
