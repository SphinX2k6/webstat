using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BossPiling;

// Token: 0x0200330D RID: 13069
public class RedDotBossPilingReward : RedDotBase
{
	// Token: 0x0601B5BE RID: 112062 RVA: 0x008351DC File Offset: 0x008333DC
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnBossPilingReward, new Action(base.EventCheck));
	}

	// Token: 0x0601B5BF RID: 112063 RVA: 0x008351FA File Offset: 0x008333FA
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBossPilingReward, new Action(base.EventCheck));
	}

	// Token: 0x0601B5C0 RID: 112064 RVA: 0x00835218 File Offset: 0x00833418
	protected override bool OnCheck(int uId = 0)
	{
		BossPilingActivityData activityData = ModelBase<BossPilingModel>.Instance.GetActivityData();
		return activityData != null && activityData.CheckTaskRedDot();
	}
}
