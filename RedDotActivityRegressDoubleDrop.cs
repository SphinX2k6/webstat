using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032EB RID: 13035
public class RedDotActivityRegressDoubleDrop : RedDotBase
{
	// Token: 0x0601B522 RID: 111906 RVA: 0x00833F1F File Offset: 0x0083211F
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B523 RID: 111907 RVA: 0x00833F3D File Offset: 0x0083213D
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B524 RID: 111908 RVA: 0x00833F5B File Offset: 0x0083215B
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<ActivityRegressModel>.Instance.ActivityData.CheckDoubleDropRedDot();
	}
}
