using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003306 RID: 13062
public class RedDotBattlePassReward : RedDotBase
{
	// Token: 0x0601B59E RID: 112030 RVA: 0x00834DB4 File Offset: 0x00832FB4
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattlePass);
	}

	// Token: 0x0601B59F RID: 112031 RVA: 0x00834DBD File Offset: 0x00832FBD
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<BattlePassModel>.Instance.CheckHasRewardWaitTake();
	}

	// Token: 0x0601B5A0 RID: 112032 RVA: 0x00834DCC File Offset: 0x00832FCC
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int?>(EEventName.GetBattlePassRewardEvent, new Action<int?>(this.OnGetBattlePassRewardEvent));
		Singleton<EventSystem>.Instance.Add(EEventName.ReceiveBattlePassDataEvent, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnBattlePassLevelUpEvent, new Action(base.EventCheck));
	}

	// Token: 0x0601B5A1 RID: 112033 RVA: 0x00834E30 File Offset: 0x00833030
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int?>(EEventName.GetBattlePassRewardEvent, new Action<int?>(this.OnGetBattlePassRewardEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.ReceiveBattlePassDataEvent, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBattlePassLevelUpEvent, new Action(base.EventCheck));
	}

	// Token: 0x0601B5A2 RID: 112034 RVA: 0x00834E91 File Offset: 0x00833091
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B5A3 RID: 112035 RVA: 0x00834E94 File Offset: 0x00833094
	private void OnGetBattlePassRewardEvent(int? gridIndex)
	{
		base.EventCheck();
	}
}
