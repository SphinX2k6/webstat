using System;

// Token: 0x02002A74 RID: 10868
public interface ISkipQuestStateCondition : ISkipCondition<ESkipConditionType>
{
	// Token: 0x17001C33 RID: 7219
	// (get) Token: 0x06015C50 RID: 89168
	// (set) Token: 0x06015C51 RID: 89169
	int QuestId { get; set; }

	// Token: 0x17001C34 RID: 7220
	// (get) Token: 0x06015C52 RID: 89170
	// (set) Token: 0x06015C53 RID: 89171
	ESkipQuestState CheckQuestState { get; set; }
}
