using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02003383 RID: 13187
public class RedDotTrialRoleGroup : RedDotBase
{
	// Token: 0x0601B7CD RID: 112589 RVA: 0x0083921C File Offset: 0x0083741C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnGroupTrialRoleRedDotUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.CurWorldLevelChange, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, int, int>(EEventName.OnGroupTrialRoleChanged, new Action<int, int, int>(this.OnGroupTrialRoleChanged));
	}

	// Token: 0x0601B7CE RID: 112590 RVA: 0x00839280 File Offset: 0x00837480
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGroupTrialRoleRedDotUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.CurWorldLevelChange, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, int, int>(EEventName.OnGroupTrialRoleChanged, new Action<int, int, int>(this.OnGroupTrialRoleChanged));
	}

	// Token: 0x0601B7CF RID: 112591 RVA: 0x008392E1 File Offset: 0x008374E1
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B7D0 RID: 112592 RVA: 0x008392E4 File Offset: 0x008374E4
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B7D1 RID: 112593 RVA: 0x008392E8 File Offset: 0x008374E8
	protected override bool OnCheck(int uId = 0)
	{
		if (uId == 0 || !RoleUtils.IsTrialRole(uId))
		{
			return false;
		}
		bool trialRoleUnlockRedDotById = ModelBase<TrialRoleModel>.Instance.GetTrialRoleUnlockRedDotById(uId);
		bool upgradeRedDotById = ModelBase<TrialRoleModel>.Instance.GetUpgradeRedDotById(uId);
		return trialRoleUnlockRedDotById || upgradeRedDotById;
	}

	// Token: 0x0601B7D2 RID: 112594 RVA: 0x0083931B File Offset: 0x0083751B
	private void OnGroupTrialRoleChanged(int preRoleId, int curRoleId, int groupId)
	{
		base.EventCheck();
	}
}
