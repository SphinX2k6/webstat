using System;
using System.Collections.Generic;
using CSharpScript.Game.Common.Event;

// Token: 0x02001EAB RID: 7851
public class RedDotPhantomHandBook : RedDotBase
{
	// Token: 0x0600E83A RID: 59450 RVA: 0x003EC919 File Offset: 0x003EAB19
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomReadRedDotUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0600E83B RID: 59451 RVA: 0x003EC953 File Offset: 0x003EAB53
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomReadRedDotUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0600E83C RID: 59452 RVA: 0x003EC990 File Offset: 0x003EAB90
	protected override bool OnCheck(int uId = 0)
	{
		List<HandBookEntry> handBookInfoList = ModelBase<HandBookModel>.Instance.GetHandBookInfoList(EHandBookTabType.Phantom);
		if (handBookInfoList == null)
		{
			return false;
		}
		int count = handBookInfoList.Count;
		for (int i = 0; i < count; i++)
		{
			if (!handBookInfoList[i].IsRead)
			{
				return true;
			}
		}
		return false;
	}
}
