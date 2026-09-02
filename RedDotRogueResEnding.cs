using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PermanentRogue;

// Token: 0x020033AF RID: 13231
public class RedDotRogueResEnding : RedDotBase
{
	// Token: 0x0601B8A1 RID: 112801 RVA: 0x0083AB46 File Offset: 0x00838D46
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PermanentRogueSeasonRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8A2 RID: 112802 RVA: 0x0083AB64 File Offset: 0x00838D64
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.PermanentRogueSeasonRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8A3 RID: 112803 RVA: 0x0083AB82 File Offset: 0x00838D82
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<ActivityPermanentRogueModel>.Instance.CheckEndingAwardRedDot(uId);
	}
}
