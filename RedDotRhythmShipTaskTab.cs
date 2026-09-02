using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip;

// Token: 0x020033A9 RID: 13225
public class RedDotRhythmShipTaskTab : RedDotBase
{
	// Token: 0x0601B881 RID: 112769 RVA: 0x0083A72C File Offset: 0x0083892C
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RhythmShipTask);
	}

	// Token: 0x0601B882 RID: 112770 RVA: 0x0083A738 File Offset: 0x00838938
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRhythmShipTaskTabRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B883 RID: 112771 RVA: 0x0083A756 File Offset: 0x00838956
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRhythmShipTaskTabRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B884 RID: 112772 RVA: 0x0083A774 File Offset: 0x00838974
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<RhythmShipModel>.Instance.GetCanTaskTabGetReward(uId, 0);
	}
}
