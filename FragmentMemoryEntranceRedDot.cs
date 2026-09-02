using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003333 RID: 13107
public class FragmentMemoryEntranceRedDot : RedDotBase
{
	// Token: 0x0601B666 RID: 112230 RVA: 0x00836448 File Offset: 0x00834648
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.FragmentRewardEntranceRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B667 RID: 112231 RVA: 0x00836466 File Offset: 0x00834666
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.FragmentRewardEntranceRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B668 RID: 112232 RVA: 0x00836484 File Offset: 0x00834684
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<FragmentMemoryModel>.Instance.GetRedDotState();
	}
}
