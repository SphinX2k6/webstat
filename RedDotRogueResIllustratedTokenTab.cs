using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PermanentRogue;

// Token: 0x020033B3 RID: 13235
public class RedDotRogueResIllustratedTokenTab : RedDotBase
{
	// Token: 0x0601B8B3 RID: 112819 RVA: 0x0083AD11 File Offset: 0x00838F11
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RogueResIllustrated);
	}

	// Token: 0x0601B8B4 RID: 112820 RVA: 0x0083AD1D File Offset: 0x00838F1D
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PermanentRogueRewardUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PermanentRogueSeasonRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8B5 RID: 112821 RVA: 0x0083AD57 File Offset: 0x00838F57
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PermanentRogueRewardUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.PermanentRogueSeasonRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8B6 RID: 112822 RVA: 0x0083AD91 File Offset: 0x00838F91
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<ActivityPermanentRogueModel>.Instance.GetHaveTokenAward(uId);
	}
}
