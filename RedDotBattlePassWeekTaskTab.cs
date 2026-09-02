using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003308 RID: 13064
public class RedDotBattlePassWeekTaskTab : RedDotBase
{
	// Token: 0x0601B5A7 RID: 112039 RVA: 0x00834EB5 File Offset: 0x008330B5
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattlePassTask);
	}

	// Token: 0x0601B5A8 RID: 112040 RVA: 0x00834EBE File Offset: 0x008330BE
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<BattlePassModel>.Instance.CheckHasTaskWaitTakeWithType(EBattlePassTaskUpdateState.EveryWeek);
	}

	// Token: 0x0601B5A9 RID: 112041 RVA: 0x00834ECB File Offset: 0x008330CB
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateBattlePassTaskEvent, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.ReceiveBattlePassTaskEvent, new Action<bool>(this.OnReceiveBattlePassTaskEvent));
	}

	// Token: 0x0601B5AA RID: 112042 RVA: 0x00834F05 File Offset: 0x00833105
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateBattlePassTaskEvent, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.ReceiveBattlePassTaskEvent, new Action<bool>(this.OnReceiveBattlePassTaskEvent));
	}

	// Token: 0x0601B5AB RID: 112043 RVA: 0x00834F3F File Offset: 0x0083313F
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B5AC RID: 112044 RVA: 0x00834F42 File Offset: 0x00833142
	private void OnReceiveBattlePassTaskEvent(bool isWeekUpdate)
	{
		base.EventCheck();
	}
}
