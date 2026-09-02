using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.FlagChallenge;

// Token: 0x0200332D RID: 13101
public class RedDotFlagChallengeActivityBuffItemNewlyUnlocked : RedDotBase
{
	// Token: 0x0601B64D RID: 112205 RVA: 0x008361FD File Offset: 0x008343FD
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFlagChallengeBuffNewlyUnlockHintChanged, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B64E RID: 112206 RVA: 0x0083621B File Offset: 0x0083441B
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnFlagChallengeBuffNewlyUnlockHintChanged, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B64F RID: 112207 RVA: 0x0083623C File Offset: 0x0083443C
	protected override bool OnCheck(int uId = 0)
	{
		if (uId == 0)
		{
			return false;
		}
		int buffActivityId = FlagChallengeUtils.GetBuffActivityId(uId);
		FlagChallengeData flagChallengeData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(buffActivityId);
		return flagChallengeData != null && flagChallengeData.IsBuffNewlyUnlocked(uId);
	}
}
