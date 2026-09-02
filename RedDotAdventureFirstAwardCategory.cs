using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032FA RID: 13050
public class RedDotAdventureFirstAwardCategory : RedDotBase
{
	// Token: 0x0601B564 RID: 111972 RVA: 0x008347D2 File Offset: 0x008329D2
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RedDotSilentFirstAwardCategory, new Action<int>(this.OnRedDotSilentFirstAwardCategory));
	}

	// Token: 0x0601B565 RID: 111973 RVA: 0x008347F0 File Offset: 0x008329F0
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RedDotSilentFirstAwardCategory, new Action<int>(this.OnRedDotSilentFirstAwardCategory));
	}

	// Token: 0x0601B566 RID: 111974 RVA: 0x0083480E File Offset: 0x00832A0E
	protected override bool OnCheck(int uId = 0)
	{
		return ControllerBase<AdventureGuideController>.Instance.CheckCanGetFirstAwardByTypeId(uId);
	}

	// Token: 0x0601B567 RID: 111975 RVA: 0x0083481B File Offset: 0x00832A1B
	private void OnRedDotSilentFirstAwardCategory(int _)
	{
		base.EventCheck();
	}
}
