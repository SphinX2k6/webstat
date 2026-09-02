using System;
using System.Runtime.CompilerServices;

// Token: 0x02002A79 RID: 10873
public class QuestStateConditionChecker : ISkipConditionChecker
{
	// Token: 0x06015C62 RID: 89186 RVA: 0x0060A843 File Offset: 0x00608A43
	[NullableContext(1)]
	public ISkipCondition<ESkipConditionType> Parse(int[] @params)
	{
		return new QuestStateConditionImpl
		{
			ConditionType = ESkipConditionType.QuestState,
			QuestId = @params[0],
			CheckQuestState = (ESkipQuestState)@params[1]
		};
	}

	// Token: 0x06015C63 RID: 89187 RVA: 0x0060A864 File Offset: 0x00608A64
	[NullableContext(1)]
	public bool Check(int[] @params)
	{
		QuestStateConditionImpl questStateConditionImpl = this.Parse(@params) as QuestStateConditionImpl;
		if (questStateConditionImpl == null)
		{
			return false;
		}
		int questId = questStateConditionImpl.QuestId;
		bool checkQuestState = questStateConditionImpl.CheckQuestState != ESkipQuestState.Uncompleted;
		bool flag = ModelBase<QuestNewModel>.Instance.CheckQuestFinished(questId);
		if (!checkQuestState)
		{
			return !flag;
		}
		return flag;
	}
}
