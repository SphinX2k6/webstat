using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip;

// Token: 0x020033AA RID: 13226
public class RedDotRhythmShipTimeLimitTask : RedDotBase
{
	// Token: 0x0601B886 RID: 112774 RVA: 0x0083A78A File Offset: 0x0083898A
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmShipTaskRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B887 RID: 112775 RVA: 0x0083A7A8 File Offset: 0x008389A8
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmShipTaskRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B888 RID: 112776 RVA: 0x0083A7C6 File Offset: 0x008389C6
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<RhythmShipModel>.Instance.GetCanTaskGetReward(1);
	}
}
