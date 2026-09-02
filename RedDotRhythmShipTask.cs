using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip;

// Token: 0x020033A8 RID: 13224
public class RedDotRhythmShipTask : RedDotBase
{
	// Token: 0x0601B87D RID: 112765 RVA: 0x0083A6DB File Offset: 0x008388DB
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmShipTaskRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B87E RID: 112766 RVA: 0x0083A6F9 File Offset: 0x008388F9
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmShipTaskRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B87F RID: 112767 RVA: 0x0083A717 File Offset: 0x00838917
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<RhythmShipModel>.Instance.GetCanTaskGetReward(0);
	}
}
