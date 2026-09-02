using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02001347 RID: 4935
public class LifePointDrawChallengeRedDot : RedDotBase
{
	// Token: 0x060086DF RID: 34527 RVA: 0x00238357 File Offset: 0x00236557
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshLifePointDrawChallengeRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x060086E0 RID: 34528 RVA: 0x00238375 File Offset: 0x00236575
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshLifePointDrawChallengeRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x060086E1 RID: 34529 RVA: 0x00238393 File Offset: 0x00236593
	protected override bool OnCheck(int challengeId)
	{
		return ModelBase<LifePointDrawModel>.Instance.GetChallengeRedDotState(challengeId);
	}
}
