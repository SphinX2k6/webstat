using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003304 RID: 13060
public class RedDotBattlePassDayTaskTab : RedDotBase
{
	// Token: 0x0601B590 RID: 112016 RVA: 0x00834C68 File Offset: 0x00832E68
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattlePassTask);
	}

	// Token: 0x0601B591 RID: 112017 RVA: 0x00834C71 File Offset: 0x00832E71
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<BattlePassModel>.Instance.CheckHasTaskWaitTakeWithType(EBattlePassTaskUpdateState.EveryDay);
	}

	// Token: 0x0601B592 RID: 112018 RVA: 0x00834C7E File Offset: 0x00832E7E
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateBattlePassTaskEvent, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.ReceiveBattlePassTaskEvent, new Action<bool>(this.OnReceiveBattlePassTaskEvent));
	}

	// Token: 0x0601B593 RID: 112019 RVA: 0x00834CB8 File Offset: 0x00832EB8
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateBattlePassTaskEvent, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.ReceiveBattlePassTaskEvent, new Action<bool>(this.OnReceiveBattlePassTaskEvent));
	}

	// Token: 0x0601B594 RID: 112020 RVA: 0x00834CF2 File Offset: 0x00832EF2
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B595 RID: 112021 RVA: 0x00834CF5 File Offset: 0x00832EF5
	private void OnReceiveBattlePassTaskEvent(bool isWeekUpdate)
	{
		base.EventCheck();
	}
}
