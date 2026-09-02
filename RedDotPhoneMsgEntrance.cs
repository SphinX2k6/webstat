using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200339C RID: 13212
public class RedDotPhoneMsgEntrance : RedDotBase
{
	// Token: 0x0601B848 RID: 112712 RVA: 0x00839E98 File Offset: 0x00838098
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhoneMsgSetAsRead, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhoneMsgSetReceived, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhoneMsgAdd, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhoneHaveMsgToRemove, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhoneMsgPanelOpen, new Action(base.EventCheck));
	}

	// Token: 0x0601B849 RID: 112713 RVA: 0x00839F34 File Offset: 0x00838134
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhoneMsgSetAsRead, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhoneMsgSetReceived, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhoneMsgAdd, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhoneHaveMsgToRemove, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhoneMsgPanelOpen, new Action(base.EventCheck));
	}

	// Token: 0x0601B84A RID: 112714 RVA: 0x00839FCD File Offset: 0x008381CD
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B84B RID: 112715 RVA: 0x00839FD0 File Offset: 0x008381D0
	protected override bool OnCheck(int uId = 0)
	{
		bool flag = ModelBase<PhoneMsgModel>.Instance.IsHasPhoneMsgUnReview();
		bool flag2 = ModelBase<PhoneMsgModel>.Instance.IsHasUnReceivedMsg();
		return flag || flag2;
	}
}
