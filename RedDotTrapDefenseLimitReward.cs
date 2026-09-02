using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x020033E8 RID: 13288
public class RedDotTrapDefenseLimitReward : RedDotBase
{
	// Token: 0x0601B9A7 RID: 113063 RVA: 0x0083D196 File Offset: 0x0083B396
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.TrapDefense);
	}

	// Token: 0x0601B9A8 RID: 113064 RVA: 0x0083D1A2 File Offset: 0x0083B3A2
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateTrapDefenseLimitReward, new Action(base.EventCheck));
	}

	// Token: 0x0601B9A9 RID: 113065 RVA: 0x0083D1C0 File Offset: 0x0083B3C0
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateTrapDefenseLimitReward, new Action(base.EventCheck));
	}

	// Token: 0x0601B9AA RID: 113066 RVA: 0x0083D1DE File Offset: 0x0083B3DE
	protected override bool OnCheck(int uId = 0)
	{
		TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
		return instance != null && instance.RewardData.RedDotLimitReward();
	}
}
