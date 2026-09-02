using System;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;

// Token: 0x020032D3 RID: 13011
public class RedDotCyberPunkBoss : RedDotBase
{
	// Token: 0x0601B4B4 RID: 111796 RVA: 0x00833348 File Offset: 0x00831548
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnCyberPunkItemUnLock, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B4B5 RID: 111797 RVA: 0x00833382 File Offset: 0x00831582
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCyberPunkItemUnLock, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B4B6 RID: 111798 RVA: 0x008333BC File Offset: 0x008315BC
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.CommonActivityPage);
	}

	// Token: 0x0601B4B7 RID: 111799 RVA: 0x008333C5 File Offset: 0x008315C5
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B4B8 RID: 111800 RVA: 0x008333C8 File Offset: 0x008315C8
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B4B9 RID: 111801 RVA: 0x008333CC File Offset: 0x008315CC
	protected override bool OnCheck(int uId = 0)
	{
		CyberPunkController instance = ControllerBase<CyberPunkController>.Instance;
		CyberPunkData cyberPunkData = (instance != null) ? instance.GetCurrentActivityData() : null;
		return cyberPunkData != null && cyberPunkData.IsFunctionUnlocked(5) && !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.CyberPunkBossEntranceFirstClicked, false);
	}
}
