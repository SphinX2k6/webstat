using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003359 RID: 13145
public class RedDotMailBoxUnScannedFilter : RedDotBase
{
	// Token: 0x0601B708 RID: 112392 RVA: 0x00837C5C File Offset: 0x00835E5C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.SwitchUnfinishedFlag, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
	}

	// Token: 0x0601B709 RID: 112393 RVA: 0x00837C96 File Offset: 0x00835E96
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SwitchUnfinishedFlag, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
	}

	// Token: 0x0601B70A RID: 112394 RVA: 0x00837CD0 File Offset: 0x00835ED0
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MailModel>.Instance.UnScannedRedPoint();
	}

	// Token: 0x0601B70B RID: 112395 RVA: 0x00837CDC File Offset: 0x00835EDC
	private void OnPlayerLevelChanged(int lastLevel, int currentLevel, int currentExp, int lastExp, int addExp, int currentMaxExp, int lastMaxExp)
	{
		base.EventCheck();
	}
}
