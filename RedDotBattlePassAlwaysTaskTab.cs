using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003303 RID: 13059
public class RedDotBattlePassAlwaysTaskTab : RedDotBase
{
	// Token: 0x0601B589 RID: 112009 RVA: 0x00834BCB File Offset: 0x00832DCB
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattlePassTask);
	}

	// Token: 0x0601B58A RID: 112010 RVA: 0x00834BD4 File Offset: 0x00832DD4
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<BattlePassModel>.Instance.CheckHasTaskWaitTakeWithType(EBattlePassTaskUpdateState.Always);
	}

	// Token: 0x0601B58B RID: 112011 RVA: 0x00834BE1 File Offset: 0x00832DE1
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateBattlePassTaskEvent, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.ReceiveBattlePassTaskEvent, new Action<bool>(this.OnReceiveBattlePassTaskEvent));
	}

	// Token: 0x0601B58C RID: 112012 RVA: 0x00834C1B File Offset: 0x00832E1B
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateBattlePassTaskEvent, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.ReceiveBattlePassTaskEvent, new Action<bool>(this.OnReceiveBattlePassTaskEvent));
	}

	// Token: 0x0601B58D RID: 112013 RVA: 0x00834C55 File Offset: 0x00832E55
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B58E RID: 112014 RVA: 0x00834C58 File Offset: 0x00832E58
	private void OnReceiveBattlePassTaskEvent(bool isWeekUpdate)
	{
		base.EventCheck();
	}
}
