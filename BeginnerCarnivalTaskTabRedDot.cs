using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200330C RID: 13068
public class BeginnerCarnivalTaskTabRedDot : RedDotBase
{
	// Token: 0x0601B5BA RID: 112058 RVA: 0x00835172 File Offset: 0x00833372
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshBeginnerCarnivalTask, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B5BB RID: 112059 RVA: 0x00835190 File Offset: 0x00833390
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshBeginnerCarnivalTask, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B5BC RID: 112060 RVA: 0x008351B0 File Offset: 0x008333B0
	protected override bool OnCheck(int uId = 0)
	{
		BeginnerCarnivalData beginnerCarnivalData = ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData();
		return beginnerCarnivalData != null && beginnerCarnivalData.GetTabRedDotShow(uId);
	}
}
