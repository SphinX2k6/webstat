using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003360 RID: 13152
public class RedDotMoonChasingHandbook : RedDotBase
{
	// Token: 0x0601B723 RID: 112419 RVA: 0x00837EA9 File Offset: 0x008360A9
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.TrackMoonHandbookUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B724 RID: 112420 RVA: 0x00837EC7 File Offset: 0x008360C7
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TrackMoonHandbookUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B725 RID: 112421 RVA: 0x00837EE5 File Offset: 0x008360E5
	protected override bool OnCheck(int uId = 0)
	{
		ControllerBase<ActivityMoonChasingController>.Instance.RefreshActivityRedDot();
		return ModelBase<MoonChasingModel>.Instance.HasHandbookRewardRedDot();
	}
}
