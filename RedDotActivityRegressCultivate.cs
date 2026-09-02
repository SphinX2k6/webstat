using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032E9 RID: 13033
public class RedDotActivityRegressCultivate : RedDotBase
{
	// Token: 0x0601B51A RID: 111898 RVA: 0x00833E6F File Offset: 0x0083206F
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B51B RID: 111899 RVA: 0x00833E8D File Offset: 0x0083208D
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B51C RID: 111900 RVA: 0x00833EAB File Offset: 0x008320AB
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<ActivityRegressModel>.Instance.ActivityData.HasReachableCultivateTask();
	}
}
