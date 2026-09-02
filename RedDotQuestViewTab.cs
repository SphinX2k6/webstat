using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Common.Event;

// Token: 0x020033A2 RID: 13218
public class RedDotQuestViewTab : RedDotBase
{
	// Token: 0x0601B863 RID: 112739 RVA: 0x0083A314 File Offset: 0x00838514
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnQuestRedDotStateChange, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B864 RID: 112740 RVA: 0x0083A332 File Offset: 0x00838532
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnQuestRedDotStateChange, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B865 RID: 112741 RVA: 0x0083A350 File Offset: 0x00838550
	protected unsafe override bool OnCheck(int uId = 0)
	{
		foreach (QuestType questType in ConfigBase<QuestNewConfig>.Instance.GetQuesTypesByMainType(uId))
		{
			List<global::Quest> questsByType = ModelBase<QuestNewModel>.Instance.GetQuestsByType(questType.Id);
			if (questsByType != null)
			{
				foreach (global::Quest quest in questsByType)
				{
					if (quest.CanShowInUiPanel() && ModelBase<QuestNewModel>.Instance.CheckQuestRedDotDataState(quest.Id).GetValueOrDefault())
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Quest;
						ELogAuthor author = ELogAuthor.YSQ;
						string message = "RedDotQuestViewTab：任务红点显示";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("mainTypeId", uId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("questId", quest.Id);
						instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x0601B866 RID: 112742 RVA: 0x0083A48C File Offset: 0x0083868C
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B867 RID: 112743 RVA: 0x0083A48F File Offset: 0x0083868F
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}
}
