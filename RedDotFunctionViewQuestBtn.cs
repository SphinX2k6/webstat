using System;
using System.Collections.Generic;
using CSharpScript.Game.Common.Event;

// Token: 0x020033A0 RID: 13216
public class RedDotFunctionViewQuestBtn : RedDotBase
{
	// Token: 0x0601B85A RID: 112730 RVA: 0x0083A1EF File Offset: 0x008383EF
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnQuestRedDotStateChange, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B85B RID: 112731 RVA: 0x0083A20D File Offset: 0x0083840D
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnQuestRedDotStateChange, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B85C RID: 112732 RVA: 0x0083A22C File Offset: 0x0083842C
	protected override bool OnCheck(int uId = 0)
	{
		foreach (KeyValuePair<int, bool> keyValuePair in ModelBase<QuestNewModel>.Instance.GetAllRedDotData())
		{
			int key = keyValuePair.Key;
			Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(key);
			if (quest != null && quest.CanShowInUiPanel())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601B85D RID: 112733 RVA: 0x0083A2A4 File Offset: 0x008384A4
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}
}
