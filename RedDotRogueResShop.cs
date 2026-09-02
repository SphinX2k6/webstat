using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PermanentRogue;

// Token: 0x020033B5 RID: 13237
public class RedDotRogueResShop : RedDotBase
{
	// Token: 0x0601B8BC RID: 112828 RVA: 0x0083ADF7 File Offset: 0x00838FF7
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PermanentRogueSeasonRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8BD RID: 112829 RVA: 0x0083AE15 File Offset: 0x00839015
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.PermanentRogueSeasonRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B8BE RID: 112830 RVA: 0x0083AE33 File Offset: 0x00839033
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<ActivityPermanentRogueModel>.Instance.CheckShopRedDot(uId);
	}
}
