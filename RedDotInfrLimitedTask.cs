using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Infrastructure;

// Token: 0x0200334B RID: 13131
public class RedDotInfrLimitedTask : RedDotBase
{
	// Token: 0x0601B6C3 RID: 112323 RVA: 0x00837169 File Offset: 0x00835369
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.Infrastructure);
	}

	// Token: 0x0601B6C4 RID: 112324 RVA: 0x00837175 File Offset: 0x00835375
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.InfrastructureActivityTaskDataUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B6C5 RID: 112325 RVA: 0x00837193 File Offset: 0x00835393
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.InfrastructureActivityTaskDataUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B6C6 RID: 112326 RVA: 0x008371B1 File Offset: 0x008353B1
	protected override bool OnCheck(int uId = 0)
	{
		InfrastructureActivityData activityData = ModelBase<InfrastructureModel>.Instance.GetActivityData();
		return activityData != null && activityData.GetLimitedTaskReadDot();
	}
}
