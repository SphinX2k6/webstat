using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PermanentRogue;

// Token: 0x020033B2 RID: 13234
public class RedDotRogueResIllustratedNormal : RedDotBase
{
	// Token: 0x0601B8AE RID: 112814 RVA: 0x0083AC7C File Offset: 0x00838E7C
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RogueResIllustrated);
	}

	// Token: 0x0601B8AF RID: 112815 RVA: 0x0083AC88 File Offset: 0x00838E88
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PermanentRogueRewardUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PermanentRogueSeasonRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8B0 RID: 112816 RVA: 0x0083ACC2 File Offset: 0x00838EC2
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PermanentRogueRewardUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.PermanentRogueSeasonRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8B1 RID: 112817 RVA: 0x0083ACFC File Offset: 0x00838EFC
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<ActivityPermanentRogueModel>.Instance.GetHaveNormalAward(uId);
	}
}
