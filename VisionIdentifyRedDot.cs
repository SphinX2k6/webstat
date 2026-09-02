using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033ED RID: 13293
public class VisionIdentifyRedDot : RedDotBase
{
	// Token: 0x0601B9C0 RID: 113088 RVA: 0x0083D414 File Offset: 0x0083B614
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PhantomLevelUpWithId, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnVisionIdentifyWithId, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshVisionIdentifyRedPoint, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B9C1 RID: 113089 RVA: 0x0083D478 File Offset: 0x0083B678
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.PhantomLevelUpWithId, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnVisionIdentifyWithId, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshVisionIdentifyRedPoint, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B9C2 RID: 113090 RVA: 0x0083D4D9 File Offset: 0x0083B6D9
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PhantomBattleModel>.Instance.CheckVisionIdentifyRedDot(uId);
	}
}
