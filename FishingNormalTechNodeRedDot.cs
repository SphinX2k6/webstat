using System;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;

// Token: 0x02003327 RID: 13095
public class FishingNormalTechNodeRedDot : RedDotBase
{
	// Token: 0x0601B639 RID: 112185 RVA: 0x00836019 File Offset: 0x00834219
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FishingNormalTech);
	}

	// Token: 0x0601B63A RID: 112186 RVA: 0x00836025 File Offset: 0x00834225
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFishingTechNodeRefresh, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFishingTechNodeRedDotRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B63B RID: 112187 RVA: 0x0083605F File Offset: 0x0083425F
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnFishingTechNodeRefresh, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnFishingTechNodeRedDotRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B63C RID: 112188 RVA: 0x0083609C File Offset: 0x0083429C
	protected override bool OnCheck(int uId = 0)
	{
		FishingTech fishingTechById = ConfigBase<FishingConfig>.Instance.GetFishingTechById(uId);
		return fishingTechById.Type != 4 && fishingTechById.Type != 5 && ModelBase<FishingModel>.Instance.GetTechNodeCanLevelUp(uId);
	}
}
