using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003348 RID: 13128
public class RedDotInfluenceReward : RedDotBase
{
	// Token: 0x0601B6B7 RID: 112311 RVA: 0x00837038 File Offset: 0x00835238
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.InfluenceReputation);
	}

	// Token: 0x0601B6B8 RID: 112312 RVA: 0x00837041 File Offset: 0x00835241
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B6B9 RID: 112313 RVA: 0x00837044 File Offset: 0x00835244
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RedDotInfluence, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B6BA RID: 112314 RVA: 0x0083707E File Offset: 0x0083527E
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RedDotInfluence, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B6BB RID: 112315 RVA: 0x008370B8 File Offset: 0x008352B8
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<InfluenceReputationModel>.Instance.RedDotInfluenceRewardCondition(uId);
	}
}
