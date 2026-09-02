using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032F7 RID: 13047
public class RedDotAdventureDailyActivityTabDaily : RedDotBase
{
	// Token: 0x0601B554 RID: 111956 RVA: 0x0083442B File Offset: 0x0083262B
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.AdventureDailyActivityTab);
	}

	// Token: 0x0601B555 RID: 111957 RVA: 0x00834434 File Offset: 0x00832634
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.DailyActivityRefresh, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.DailyActivityStateNotify, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.DailyActivityMainTabOpened, new Action<int>(this.OnDailyActivityMainTabOpened));
		Singleton<EventSystem>.Instance.Add(EEventName.OnServerStorageInfoInited, new Action(base.EventCheck));
	}

	// Token: 0x0601B556 RID: 111958 RVA: 0x008344B4 File Offset: 0x008326B4
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.DailyActivityRefresh, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.DailyActivityStateNotify, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.DailyActivityMainTabOpened, new Action<int>(this.OnDailyActivityMainTabOpened));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnServerStorageInfoInited, new Action(base.EventCheck));
	}

	// Token: 0x0601B557 RID: 111959 RVA: 0x00834531 File Offset: 0x00832731
	private void OnDailyActivityMainTabOpened(int tab)
	{
		base.EventCheck();
	}

	// Token: 0x0601B558 RID: 111960 RVA: 0x0083453C File Offset: 0x0083273C
	protected override bool OnCheck(int uId = 0)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.AdventureGuide) || !ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.DailyActivity))
		{
			return false;
		}
		long dayEndTime = ModelBase<DailyActivityModel>.Instance.DayEndTime;
		return dayEndTime > 0L && ((long)ModelBase<DailyActivityModel>.Instance.GetFirstOpenTabTime(DailyActivityDefine.EDailyActivityMainTab.Daily).GetValueOrDefault() != dayEndTime || ModelBase<DailyActivityModel>.Instance.CheckIsRewardWaitTake());
	}
}
