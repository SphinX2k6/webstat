using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200339B RID: 13211
public class RedDotPhoneMsgChatPartnerGiftIcon : RedDotBase
{
	// Token: 0x0601B842 RID: 112706 RVA: 0x00839E08 File Offset: 0x00838008
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B843 RID: 112707 RVA: 0x00839E0B File Offset: 0x0083800B
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B844 RID: 112708 RVA: 0x00839E0E File Offset: 0x0083800E
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhoneMsgSetReceived, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhoneMsgPanelOpen, new Action(base.EventCheck));
	}

	// Token: 0x0601B845 RID: 112709 RVA: 0x00839E48 File Offset: 0x00838048
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhoneMsgSetReceived, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhoneMsgPanelOpen, new Action(base.EventCheck));
	}

	// Token: 0x0601B846 RID: 112710 RVA: 0x00839E82 File Offset: 0x00838082
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PhoneMsgModel>.Instance.IsSomeOneHasUnReceivedMsg(uId);
	}
}
