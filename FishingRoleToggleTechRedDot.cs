using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;

// Token: 0x02003329 RID: 13097
public class FishingRoleToggleTechRedDot : RedDotBase
{
	// Token: 0x0601B642 RID: 112194 RVA: 0x00836167 File Offset: 0x00834367
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FishingRoleTech);
	}

	// Token: 0x0601B643 RID: 112195 RVA: 0x00836173 File Offset: 0x00834373
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<EFishingTechNodeType>(EEventName.OnFishingRoleTechRefresh, new Action<EFishingTechNodeType>(this.OnFishingRoleTechRefresh));
	}

	// Token: 0x0601B644 RID: 112196 RVA: 0x00836191 File Offset: 0x00834391
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<EFishingTechNodeType>(EEventName.OnFishingRoleTechRefresh, new Action<EFishingTechNodeType>(this.OnFishingRoleTechRefresh));
	}

	// Token: 0x0601B645 RID: 112197 RVA: 0x008361AF File Offset: 0x008343AF
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<FishingModel>.Instance.GetRoleTechNodeCanLevelUp((EFishingTechNodeType)uId);
	}

	// Token: 0x0601B646 RID: 112198 RVA: 0x008361BC File Offset: 0x008343BC
	private void OnFishingRoleTechRefresh(EFishingTechNodeType type)
	{
		base.EventCheckWithUid((int)type);
	}
}
