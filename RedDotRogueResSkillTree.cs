using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PermanentRogue;

// Token: 0x020033B6 RID: 13238
public class RedDotRogueResSkillTree : RedDotBase
{
	// Token: 0x0601B8C0 RID: 112832 RVA: 0x0083AE48 File Offset: 0x00839048
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PermanentRogueSeasonRedDotUpdate, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PermanentRogueSkillCurrencyRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8C1 RID: 112833 RVA: 0x0083AE82 File Offset: 0x00839082
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.PermanentRogueSeasonRedDotUpdate, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.PermanentRogueSkillCurrencyRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8C2 RID: 112834 RVA: 0x0083AEBC File Offset: 0x008390BC
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<ActivityPermanentRogueModel>.Instance.CheckSkillTreeRedDot(uId);
	}
}
