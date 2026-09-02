using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200335D RID: 13149
public class RedDotMoonChasingBranchTab : RedDotBase
{
	// Token: 0x0601B716 RID: 112406 RVA: 0x00837D61 File Offset: 0x00835F61
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.MoonChasingAllQuest);
	}

	// Token: 0x0601B717 RID: 112407 RVA: 0x00837D6D File Offset: 0x00835F6D
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MoonChasingRefreshQuestRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B718 RID: 112408 RVA: 0x00837D8B File Offset: 0x00835F8B
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MoonChasingRefreshQuestRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B719 RID: 112409 RVA: 0x00837DA9 File Offset: 0x00835FA9
	protected override bool OnCheck(int uId = 0)
	{
		ControllerBase<ActivityMoonChasingController>.Instance.RefreshActivityRedDot();
		return ModelBase<MoonChasingModel>.Instance.CheckBranchRedDot();
	}
}
