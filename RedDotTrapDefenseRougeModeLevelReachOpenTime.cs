using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x020033E4 RID: 13284
public class RedDotTrapDefenseRougeModeLevelReachOpenTime : RedDotBase
{
	// Token: 0x0601B993 RID: 113043 RVA: 0x0083D006 File Offset: 0x0083B206
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.TrapDefenseRougeLevel);
	}

	// Token: 0x0601B994 RID: 113044 RVA: 0x0083D012 File Offset: 0x0083B212
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateTrapDefenseRougeModeLevelReachOpenTime, new Action(base.EventCheck));
	}

	// Token: 0x0601B995 RID: 113045 RVA: 0x0083D030 File Offset: 0x0083B230
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateTrapDefenseRougeModeLevelReachOpenTime, new Action(base.EventCheck));
	}

	// Token: 0x0601B996 RID: 113046 RVA: 0x0083D04E File Offset: 0x0083B24E
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<TrapDefenseModel>.Instance.RougeModeData.RedDotLevelReachOpenTime();
	}
}
