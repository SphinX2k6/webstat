using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200335A RID: 13146
public class RedDotMapAreaBoxReward : RedDotBase
{
	// Token: 0x0601B70D RID: 112397 RVA: 0x00837CEC File Offset: 0x00835EEC
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.MapAreaExplore);
	}

	// Token: 0x0601B70E RID: 112398 RVA: 0x00837CF5 File Offset: 0x00835EF5
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateMapAreaBoxReward, new Action(base.EventCheck));
	}

	// Token: 0x0601B70F RID: 112399 RVA: 0x00837D13 File Offset: 0x00835F13
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateMapAreaBoxReward, new Action(base.EventCheck));
	}

	// Token: 0x0601B710 RID: 112400 RVA: 0x00837D31 File Offset: 0x00835F31
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<ExploreProgressModel>.Instance.GetIsRedDotAreaRewardBox;
	}
}
