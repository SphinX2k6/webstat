using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.MailBind;

// Token: 0x0200333A RID: 13114
public class RedDotFunctionKuroStreet : RedDotBase
{
	// Token: 0x0601B681 RID: 112257 RVA: 0x0083673D File Offset: 0x0083493D
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattleViewMenu);
	}

	// Token: 0x0601B682 RID: 112258 RVA: 0x00836748 File Offset: 0x00834948
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnMailBindInfoNotify, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnMailBindInfoResponse, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnMailBindResponse, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnMailBindRewardResponse, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshMailBindRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B683 RID: 112259 RVA: 0x008367E4 File Offset: 0x008349E4
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMailBindInfoNotify, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMailBindInfoResponse, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMailBindResponse, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMailBindRewardResponse, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshMailBindRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B684 RID: 112260 RVA: 0x00836880 File Offset: 0x00834A80
	protected override bool OnCheck(int uId = 0)
	{
		MailBindModel instance = ModelBase<MailBindModel>.Instance;
		return ControllerBase<ChannelController>.Instance.CheckKuroStreetOpen() && instance.CheckMailBindRedDot();
	}
}
