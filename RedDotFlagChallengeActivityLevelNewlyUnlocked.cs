using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200332F RID: 13103
public class RedDotFlagChallengeActivityLevelNewlyUnlocked : RedDotBase
{
	// Token: 0x0601B655 RID: 112213 RVA: 0x008362E0 File Offset: 0x008344E0
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFlagChallengeLevelNewlyUnlock, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B656 RID: 112214 RVA: 0x008362FE File Offset: 0x008344FE
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnFlagChallengeLevelNewlyUnlock, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B657 RID: 112215 RVA: 0x0083631C File Offset: 0x0083451C
	protected override bool OnCheck(int uId = 0)
	{
		return false;
	}
}
