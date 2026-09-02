using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.MailBind;

// Token: 0x0200333C RID: 13116
public class RedDotFunctionMailBind : RedDotBase
{
	// Token: 0x0601B68B RID: 112267 RVA: 0x00836991 File Offset: 0x00834B91
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattleViewMenu);
	}

	// Token: 0x0601B68C RID: 112268 RVA: 0x0083699C File Offset: 0x00834B9C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnMailBindInfoNotify, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnMailBindInfoResponse, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnMailBindResponse, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnMailBindRewardResponse, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshMailBindRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B68D RID: 112269 RVA: 0x00836A38 File Offset: 0x00834C38
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMailBindInfoNotify, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMailBindInfoResponse, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMailBindResponse, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMailBindRewardResponse, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshMailBindRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B68E RID: 112270 RVA: 0x00836AD4 File Offset: 0x00834CD4
	protected override bool OnCheck(int uId = 0)
	{
		MailBindModel instance = ModelBase<MailBindModel>.Instance;
		return instance.CheckGlobalMailBindOpen() && instance.CheckMailBindRedDot();
	}
}
