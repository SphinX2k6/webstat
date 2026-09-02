using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032FB RID: 13051
public class RedDotAdventureFirstAwardResult : RedDotBase
{
	// Token: 0x0601B569 RID: 111977 RVA: 0x0083482B File Offset: 0x00832A2B
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RedDotSilentFirstAwardResult, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B56A RID: 111978 RVA: 0x00834849 File Offset: 0x00832A49
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RedDotSilentFirstAwardResult, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B56B RID: 111979 RVA: 0x00834867 File Offset: 0x00832A67
	protected override bool OnCheck(int uId = 0)
	{
		return ControllerBase<AdventureGuideController>.Instance.CheckCanGetFirstAwardById(uId);
	}
}
