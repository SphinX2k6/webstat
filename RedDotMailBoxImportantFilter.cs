using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003358 RID: 13144
public class RedDotMailBoxImportantFilter : RedDotBase
{
	// Token: 0x0601B703 RID: 112387 RVA: 0x00837BCC File Offset: 0x00835DCC
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.SwitchUnfinishedFlag, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
	}

	// Token: 0x0601B704 RID: 112388 RVA: 0x00837C06 File Offset: 0x00835E06
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SwitchUnfinishedFlag, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
	}

	// Token: 0x0601B705 RID: 112389 RVA: 0x00837C40 File Offset: 0x00835E40
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MailModel>.Instance.GetRedDotImportant();
	}

	// Token: 0x0601B706 RID: 112390 RVA: 0x00837C4C File Offset: 0x00835E4C
	private void OnPlayerLevelChanged(int lastLevel, int currentLevel, int currentExp, int lastExp, int addExp, int currentMaxExp, int lastMaxExp)
	{
		base.EventCheck();
	}
}
