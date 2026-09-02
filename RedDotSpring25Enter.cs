using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033D0 RID: 13264
public class RedDotSpring25Enter : RedDotBase
{
	// Token: 0x0601B947 RID: 112967 RVA: 0x0083C67C File Offset: 0x0083A87C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.Spring25DrawRewardDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.Spring25SkinRewardDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.Spring25InviteDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.Spring25ActivityParseDone, new Action(base.EventCheck));
	}

	// Token: 0x0601B948 RID: 112968 RVA: 0x0083C6FC File Offset: 0x0083A8FC
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.Spring25DrawRewardDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.Spring25SkinRewardDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.Spring25InviteDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.Spring25ActivityParseDone, new Action(base.EventCheck));
	}

	// Token: 0x0601B949 RID: 112969 RVA: 0x0083C779 File Offset: 0x0083A979
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<Spring25Model>.Instance.HasRedDot;
	}
}
