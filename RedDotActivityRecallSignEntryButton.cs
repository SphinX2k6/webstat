using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032E2 RID: 13026
public class RedDotActivityRecallSignEntryButton : RedDotBase
{
	// Token: 0x0601B4FF RID: 111871 RVA: 0x00833B77 File Offset: 0x00831D77
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B500 RID: 111872 RVA: 0x00833B95 File Offset: 0x00831D95
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B501 RID: 111873 RVA: 0x00833BB3 File Offset: 0x00831DB3
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<ActivityRegressModel>.Instance.HasSignRewardCanClaimed();
	}
}
