using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003399 RID: 13209
public class RedDotPhoneMsgChatItem : RedDotBase
{
	// Token: 0x0601B837 RID: 112695 RVA: 0x00839C74 File Offset: 0x00837E74
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B838 RID: 112696 RVA: 0x00839C77 File Offset: 0x00837E77
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhoneMsgSetAsRead, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhoneMsgPanelOpen, new Action(base.EventCheck));
	}

	// Token: 0x0601B839 RID: 112697 RVA: 0x00839CB1 File Offset: 0x00837EB1
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhoneMsgSetAsRead, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhoneMsgPanelOpen, new Action(base.EventCheck));
	}

	// Token: 0x0601B83A RID: 112698 RVA: 0x00839CEB File Offset: 0x00837EEB
	protected override bool OnCheck(int uId = 0)
	{
		return !ModelBase<PhoneMsgModel>.Instance.IsShortMsgRead(uId);
	}
}
