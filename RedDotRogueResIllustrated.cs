using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PermanentRogue;

// Token: 0x020033B0 RID: 13232
public class RedDotRogueResIllustrated : RedDotBase
{
	// Token: 0x0601B8A5 RID: 112805 RVA: 0x0083AB97 File Offset: 0x00838D97
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PermanentRogueRewardUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B8A6 RID: 112806 RVA: 0x0083ABB5 File Offset: 0x00838DB5
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PermanentRogueRewardUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B8A7 RID: 112807 RVA: 0x0083ABD3 File Offset: 0x00838DD3
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<ActivityPermanentRogueModel>.Instance.CheckIllustratedRedDot();
	}
}
