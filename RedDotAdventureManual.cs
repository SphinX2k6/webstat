using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032FC RID: 13052
public class RedDotAdventureManual : RedDotBase
{
	// Token: 0x0601B56D RID: 111981 RVA: 0x0083487C File Offset: 0x00832A7C
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FunctionAdventure);
	}

	// Token: 0x0601B56E RID: 111982 RVA: 0x00834885 File Offset: 0x00832A85
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotAdventureManualUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotSilentFirstAward, new Action(base.EventCheck));
	}

	// Token: 0x0601B56F RID: 111983 RVA: 0x008348BF File Offset: 0x00832ABF
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotAdventureManualUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotSilentFirstAward, new Action(base.EventCheck));
	}

	// Token: 0x0601B570 RID: 111984 RVA: 0x008348F9 File Offset: 0x00832AF9
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10023) && ControllerBase<AdventureGuideController>.Instance.CheckCanGetTaskAward();
	}
}
