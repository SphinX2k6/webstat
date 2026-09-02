using System;
using System.Collections.Generic;
using CSharpScript.Game.Common.Event;

// Token: 0x0200339F RID: 13215
public class RedDotBattleViewQuestBtn : RedDotBase
{
	// Token: 0x0601B855 RID: 112725 RVA: 0x0083A0AD File Offset: 0x008382AD
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnQuestRedDotStateChange, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B856 RID: 112726 RVA: 0x0083A0CB File Offset: 0x008382CB
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnQuestRedDotStateChange, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B857 RID: 112727 RVA: 0x0083A0EC File Offset: 0x008382EC
	protected override bool OnCheck(int uId = 0)
	{
		Dictionary<int, bool> allRedDotData = ModelBase<QuestNewModel>.Instance.GetAllRedDotData();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Quest;
		ELogAuthor author = ELogAuthor.YSQ;
		string message = "开始检测主界面任务红点";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("红点数据量", (allRedDotData != null) ? new int?(allRedDotData.Count) : null);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		foreach (KeyValuePair<int, bool> keyValuePair in allRedDotData)
		{
			int key = keyValuePair.Key;
			Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(key);
			if (quest != null && quest.CanShowInUiPanel())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Quest;
				ELogAuthor author2 = ELogAuthor.YSQ;
				string message2 = "主界面任务红点";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("红点任务", quest.Id);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601B858 RID: 112728 RVA: 0x0083A1E4 File Offset: 0x008383E4
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}
}
