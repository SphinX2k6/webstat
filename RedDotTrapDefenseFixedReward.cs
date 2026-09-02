using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x020033E7 RID: 13287
public class RedDotTrapDefenseFixedReward : RedDotBase
{
	// Token: 0x0601B9A2 RID: 113058 RVA: 0x0083D12F File Offset: 0x0083B32F
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.TrapDefense);
	}

	// Token: 0x0601B9A3 RID: 113059 RVA: 0x0083D13B File Offset: 0x0083B33B
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateTrapDefenseFixedReward, new Action(base.EventCheck));
	}

	// Token: 0x0601B9A4 RID: 113060 RVA: 0x0083D159 File Offset: 0x0083B359
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateTrapDefenseFixedReward, new Action(base.EventCheck));
	}

	// Token: 0x0601B9A5 RID: 113061 RVA: 0x0083D177 File Offset: 0x0083B377
	protected override bool OnCheck(int uId = 0)
	{
		TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
		return instance != null && instance.RewardData.RedDotFixedReward();
	}
}
