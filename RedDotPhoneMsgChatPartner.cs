using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200339A RID: 13210
public class RedDotPhoneMsgChatPartner : RedDotBase
{
	// Token: 0x0601B83C RID: 112700 RVA: 0x00839D03 File Offset: 0x00837F03
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B83D RID: 112701 RVA: 0x00839D06 File Offset: 0x00837F06
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B83E RID: 112702 RVA: 0x00839D0C File Offset: 0x00837F0C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhoneMsgSetAsRead, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhoneMsgSetReceived, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhoneMsgPanelOpen, new Action(base.EventCheck));
	}

	// Token: 0x0601B83F RID: 112703 RVA: 0x00839D70 File Offset: 0x00837F70
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhoneMsgSetAsRead, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhoneMsgSetReceived, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhoneMsgPanelOpen, new Action(base.EventCheck));
	}

	// Token: 0x0601B840 RID: 112704 RVA: 0x00839DD4 File Offset: 0x00837FD4
	protected override bool OnCheck(int uId = 0)
	{
		bool flag = ModelBase<PhoneMsgModel>.Instance.IsSomeOneHasUnReadMsg(uId);
		bool flag2 = ModelBase<PhoneMsgModel>.Instance.IsSomeOneHasUnReceivedMsg(uId);
		return flag && !flag2;
	}
}
