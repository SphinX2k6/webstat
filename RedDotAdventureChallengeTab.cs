using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032F5 RID: 13045
public class RedDotAdventureChallengeTab : RedDotBase
{
	// Token: 0x0601B54D RID: 111949 RVA: 0x008343AE File Offset: 0x008325AE
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FunctionAdventure);
	}

	// Token: 0x0601B54E RID: 111950 RVA: 0x008343B7 File Offset: 0x008325B7
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotAdventureChallengeTabUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B54F RID: 111951 RVA: 0x008343D5 File Offset: 0x008325D5
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotAdventureChallengeTabUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B550 RID: 111952 RVA: 0x008343F3 File Offset: 0x008325F3
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10023) && ModelBase<AdventureGuideModel>.Instance.CheckRedDotChallengeTab();
	}
}
