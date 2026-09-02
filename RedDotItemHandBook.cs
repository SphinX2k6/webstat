using System;
using System.Collections.Generic;
using CSharpScript.Game.Common.Event;

// Token: 0x02001EAA RID: 7850
public class RedDotItemHandBook : RedDotBase
{
	// Token: 0x0600E835 RID: 59445 RVA: 0x003EC868 File Offset: 0x003EAA68
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0600E836 RID: 59446 RVA: 0x003EC86B File Offset: 0x003EAA6B
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemReadRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0600E837 RID: 59447 RVA: 0x003EC889 File Offset: 0x003EAA89
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnItemReadRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0600E838 RID: 59448 RVA: 0x003EC8A8 File Offset: 0x003EAAA8
	protected override bool OnCheck(int uId = 0)
	{
		List<HandBookEntry> handBookInfoList = ModelBase<HandBookModel>.Instance.GetHandBookInfoList(EHandBookTabType.Item);
		if (handBookInfoList == null)
		{
			return false;
		}
		int count = handBookInfoList.Count;
		for (int i = 0; i < count; i++)
		{
			HandBookEntry handBookEntry = handBookInfoList[i];
			if (ConfigBase<HandBookConfig>.Instance.GetItemHandBookConfigById(handBookEntry.Id).Value.Type == uId && !handBookEntry.IsRead)
			{
				return true;
			}
		}
		return false;
	}
}
