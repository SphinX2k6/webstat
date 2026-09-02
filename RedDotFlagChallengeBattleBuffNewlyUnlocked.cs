using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003331 RID: 13105
public class RedDotFlagChallengeBattleBuffNewlyUnlocked : RedDotBase
{
	// Token: 0x0601B65E RID: 112222 RVA: 0x00836398 File Offset: 0x00834598
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnFlagChallengeBattleBuffNewlyUnlock, new Action(base.EventCheck));
	}

	// Token: 0x0601B65F RID: 112223 RVA: 0x008363B6 File Offset: 0x008345B6
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeBattleBuffNewlyUnlock, new Action(base.EventCheck));
	}

	// Token: 0x0601B660 RID: 112224 RVA: 0x008363D4 File Offset: 0x008345D4
	protected override bool OnCheck(int uId = 0)
	{
		return false;
	}
}
