using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032F9 RID: 13049
public class RedDotAdventureFirstAward : RedDotBase
{
	// Token: 0x0601B55F RID: 111967 RVA: 0x00834766 File Offset: 0x00832966
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FunctionAdventure);
	}

	// Token: 0x0601B560 RID: 111968 RVA: 0x0083476F File Offset: 0x0083296F
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotSilentFirstAward, new Action(base.EventCheck));
	}

	// Token: 0x0601B561 RID: 111969 RVA: 0x0083478D File Offset: 0x0083298D
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotSilentFirstAward, new Action(base.EventCheck));
	}

	// Token: 0x0601B562 RID: 111970 RVA: 0x008347AB File Offset: 0x008329AB
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10023) && ControllerBase<AdventureGuideController>.Instance.CheckCanGetFirstAward();
	}
}
