using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Infrastructure;

// Token: 0x02003349 RID: 13129
public class RedDotInfrArchive : RedDotBase
{
	// Token: 0x0601B6BD RID: 112317 RVA: 0x008370CD File Offset: 0x008352CD
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.Infrastructure);
	}

	// Token: 0x0601B6BE RID: 112318 RVA: 0x008370D9 File Offset: 0x008352D9
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.InfrastructureArchiveTaskUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.InfrastructurePhoneTaskUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B6BF RID: 112319 RVA: 0x00837113 File Offset: 0x00835313
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.InfrastructureArchiveTaskUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.InfrastructurePhoneTaskUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B6C0 RID: 112320 RVA: 0x0083714D File Offset: 0x0083534D
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<InfrastructureModel>.Instance.GetArchiveRedDot();
	}
}
