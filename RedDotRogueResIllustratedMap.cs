using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PermanentRogue;

// Token: 0x020033B1 RID: 13233
public class RedDotRogueResIllustratedMap : RedDotBase
{
	// Token: 0x0601B8A9 RID: 112809 RVA: 0x0083ABE7 File Offset: 0x00838DE7
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RogueResIllustrated);
	}

	// Token: 0x0601B8AA RID: 112810 RVA: 0x0083ABF3 File Offset: 0x00838DF3
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PermanentRogueRewardUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PermanentRogueSeasonRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8AB RID: 112811 RVA: 0x0083AC2D File Offset: 0x00838E2D
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PermanentRogueRewardUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.PermanentRogueSeasonRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8AC RID: 112812 RVA: 0x0083AC67 File Offset: 0x00838E67
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<ActivityPermanentRogueModel>.Instance.GetHaveMapAward(uId);
	}
}
