using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003357 RID: 13143
public class RedDotMailBoxFilter : RedDotBase
{
	// Token: 0x0601B6FE RID: 112382 RVA: 0x00837B3C File Offset: 0x00835D3C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.SwitchUnfinishedFlag, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
	}

	// Token: 0x0601B6FF RID: 112383 RVA: 0x00837B76 File Offset: 0x00835D76
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SwitchUnfinishedFlag, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
	}

	// Token: 0x0601B700 RID: 112384 RVA: 0x00837BB0 File Offset: 0x00835DB0
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MailModel>.Instance.GetRedDotCouldLightOn();
	}

	// Token: 0x0601B701 RID: 112385 RVA: 0x00837BBC File Offset: 0x00835DBC
	private void OnPlayerLevelChanged(int lastLevel, int currentLevel, int currentExp, int lastExp, int addExp, int currentMaxExp, int lastMaxExp)
	{
		base.EventCheck();
	}
}
