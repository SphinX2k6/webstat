using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PermanentRogue;

// Token: 0x020033B4 RID: 13236
public class RedDotRogueResInst : RedDotBase
{
	// Token: 0x0601B8B8 RID: 112824 RVA: 0x0083ADA6 File Offset: 0x00838FA6
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PermanentRogueSeasonRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8B9 RID: 112825 RVA: 0x0083ADC4 File Offset: 0x00838FC4
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.PermanentRogueSeasonRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8BA RID: 112826 RVA: 0x0083ADE2 File Offset: 0x00838FE2
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<ActivityPermanentRogueModel>.Instance.CheckDungeonRedDot(uId);
	}
}
