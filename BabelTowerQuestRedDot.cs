using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003301 RID: 13057
public class BabelTowerQuestRedDot : RedDotBase
{
	// Token: 0x0601B581 RID: 112001 RVA: 0x00834B18 File Offset: 0x00832D18
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BabelTowerRefreshQuestState, new Action(base.EventCheck));
	}

	// Token: 0x0601B582 RID: 112002 RVA: 0x00834B36 File Offset: 0x00832D36
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.BabelTowerRefreshQuestState, new Action(base.EventCheck));
	}

	// Token: 0x0601B583 RID: 112003 RVA: 0x00834B54 File Offset: 0x00832D54
	protected override bool OnCheck(int uId = 0)
	{
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		return babelTowerData != null && babelTowerData.GetQuestAnyRedDot();
	}
}
