using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032FF RID: 13055
public class BabelTowerDifficultyRedDot : RedDotBase
{
	// Token: 0x0601B579 RID: 111993 RVA: 0x008349D5 File Offset: 0x00832BD5
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.BabelTowerDifficultyLevelClick, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.BabelTowerDifficultyRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B57A RID: 111994 RVA: 0x00834A0F File Offset: 0x00832C0F
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.BabelTowerDifficultyLevelClick, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.BabelTowerDifficultyRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B57B RID: 111995 RVA: 0x00834A4C File Offset: 0x00832C4C
	protected override bool OnCheck(int uId = 0)
	{
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		return babelTowerData != null && babelTowerData.GetDifficultyNewLevelRedDot(uId);
	}
}
