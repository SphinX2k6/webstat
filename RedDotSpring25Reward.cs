using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033CE RID: 13262
public class RedDotSpring25Reward : RedDotBase
{
	// Token: 0x0601B93F RID: 112959 RVA: 0x0083C4E0 File Offset: 0x0083A6E0
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.Spring25DrawRewardDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.Spring25SkinRewardDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.Spring25InviteDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.Spring25ActivityParseDone, new Action(base.EventCheck));
	}

	// Token: 0x0601B940 RID: 112960 RVA: 0x0083C560 File Offset: 0x0083A760
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.Spring25DrawRewardDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.Spring25SkinRewardDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.Spring25InviteDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.Spring25ActivityParseDone, new Action(base.EventCheck));
	}

	// Token: 0x0601B941 RID: 112961 RVA: 0x0083C5DD File Offset: 0x0083A7DD
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<Spring25Model>.Instance.HasAnyRewardExternal;
	}
}
