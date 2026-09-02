using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032FD RID: 13053
public class RedDotAdventureNewSoundAreaGeneral : RedDotBase
{
	// Token: 0x0601B572 RID: 111986 RVA: 0x00834920 File Offset: 0x00832B20
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.AdventureNewSoundAreaTab);
	}

	// Token: 0x0601B573 RID: 111987 RVA: 0x00834929 File Offset: 0x00832B29
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.CrossDay, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotNewSoundAreaTabUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B574 RID: 111988 RVA: 0x00834963 File Offset: 0x00832B63
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.CrossDay, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotNewSoundAreaTabUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B575 RID: 111989 RVA: 0x0083499D File Offset: 0x00832B9D
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10023) && ModelBase<AdventureGuideModel>.Instance.CheckRedDotAdventureNewSoundAreaTab();
	}
}
