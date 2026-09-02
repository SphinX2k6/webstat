using System;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x020033A7 RID: 13223
public class RedDotVersionCheck : RedDotBase
{
	// Token: 0x0601B878 RID: 112760 RVA: 0x0083A624 File Offset: 0x00838824
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FunctionSetting);
	}

	// Token: 0x0601B879 RID: 112761 RVA: 0x0083A62D File Offset: 0x0083882D
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.VersionCheckRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B87A RID: 112762 RVA: 0x0083A667 File Offset: 0x00838867
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.VersionCheckRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B87B RID: 112763 RVA: 0x0083A6A4 File Offset: 0x008388A4
	protected override bool OnCheck(int uId = 0)
	{
		string appVersion = UKuroLauncherLibrary.GetAppVersion();
		return LocalStorage.GetPlayer<string>(ELocalStoragePlayerKey.VersionRedDotMap, null) != appVersion && ControllerBase<ParallelPackageController>.Instance.CheckParallelPackageWithCache();
	}
}
