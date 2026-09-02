using System;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x02003342 RID: 13122
public class RedDotFunctionPhotograph : RedDotBase
{
	// Token: 0x0601B6A4 RID: 112292 RVA: 0x00836CD8 File Offset: 0x00834ED8
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotFilter, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.LocalStorageInitPlayerId, new Action(base.EventCheck));
	}

	// Token: 0x0601B6A5 RID: 112293 RVA: 0x00836D12 File Offset: 0x00834F12
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotFilter, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.LocalStorageInitPlayerId, new Action(base.EventCheck));
	}

	// Token: 0x0601B6A6 RID: 112294 RVA: 0x00836D4C File Offset: 0x00834F4C
	protected override bool OnCheck(int uId = 0)
	{
		if (!LocalStorage.HasPlayerId())
		{
			return true;
		}
		ServerStorageUtil.OverrideLocalBooleanToServerBoolean(ELocalStoragePlayerKey.FilterRedPoint, EClientStorageSystemIdType.FilterRedPoint);
		return (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FilterRedPoint) as ServerStorageBoolean).Get().GetValueOrDefault(true);
	}
}
