using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032F3 RID: 13043
public class AdventurePeriodicityTab : RedDotBase
{
	// Token: 0x0601B546 RID: 111942 RVA: 0x008342FA File Offset: 0x008324FA
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FunctionAdventure);
	}

	// Token: 0x0601B547 RID: 111943 RVA: 0x00834303 File Offset: 0x00832503
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotAdventureManualUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotAdventurePeriodicityTabUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B548 RID: 111944 RVA: 0x0083433D File Offset: 0x0083253D
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotAdventureManualUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotAdventurePeriodicityTabUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B549 RID: 111945 RVA: 0x00834377 File Offset: 0x00832577
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10023) && ModelBase<AdventureGuideModel>.Instance.CheckRedDotPeriodicityTab();
	}
}
