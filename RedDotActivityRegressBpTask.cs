using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032E7 RID: 13031
public class RedDotActivityRegressBpTask : RedDotBase
{
	// Token: 0x0601B511 RID: 111889 RVA: 0x00833D93 File Offset: 0x00831F93
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.ActivityRegressBp);
	}

	// Token: 0x0601B512 RID: 111890 RVA: 0x00833D9F File Offset: 0x00831F9F
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B513 RID: 111891 RVA: 0x00833DBD File Offset: 0x00831FBD
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B514 RID: 111892 RVA: 0x00833DDB File Offset: 0x00831FDB
	protected override bool OnCheck(int uId = 0)
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		return activityData != null && activityData.HasReachableConstantTask();
	}
}
