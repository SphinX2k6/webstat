using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.FlagChallenge;

// Token: 0x0200332E RID: 13102
public class RedDotFlagChallengeActivityBuffNewlyUnlocked : RedDotBase
{
	// Token: 0x0601B651 RID: 112209 RVA: 0x00836275 File Offset: 0x00834475
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFlagChallengeBuffNewlyUnlock, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B652 RID: 112210 RVA: 0x00836293 File Offset: 0x00834493
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnFlagChallengeBuffNewlyUnlock, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B653 RID: 112211 RVA: 0x008362B4 File Offset: 0x008344B4
	protected override bool OnCheck(int uId = 0)
	{
		FlagChallengeData flagChallengeData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(uId);
		return flagChallengeData != null && flagChallengeData.HasBuffNewlyUnlocked();
	}
}
