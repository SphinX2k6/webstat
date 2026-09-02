using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003300 RID: 13056
public class BabelTowerLevelRedDot : RedDotBase
{
	// Token: 0x0601B57D RID: 111997 RVA: 0x00834A78 File Offset: 0x00832C78
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.BabelTowerLevelClick, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.BabelTowerLevelRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B57E RID: 111998 RVA: 0x00834AB2 File Offset: 0x00832CB2
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.BabelTowerLevelClick, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.BabelTowerLevelRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B57F RID: 111999 RVA: 0x00834AEC File Offset: 0x00832CEC
	protected override bool OnCheck(int uId = 0)
	{
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		return babelTowerData != null && babelTowerData.GetNewLevelRedDot(uId);
	}
}
