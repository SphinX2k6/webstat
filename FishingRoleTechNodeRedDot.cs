using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;

// Token: 0x02003328 RID: 13096
public class FishingRoleTechNodeRedDot : RedDotBase
{
	// Token: 0x0601B63E RID: 112190 RVA: 0x008360DE File Offset: 0x008342DE
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFishingTechNodeRefresh, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFishingTechNodeRedDotRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B63F RID: 112191 RVA: 0x00836118 File Offset: 0x00834318
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnFishingTechNodeRefresh, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnFishingTechNodeRedDotRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B640 RID: 112192 RVA: 0x00836152 File Offset: 0x00834352
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<FishingModel>.Instance.GetTechNodeCanLevelUp(uId);
	}
}
