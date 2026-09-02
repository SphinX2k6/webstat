using System;

// Token: 0x02002A7A RID: 10874
public class QuestStateConditionImpl : ISkipQuestStateCondition, ISkipCondition<ESkipConditionType>
{
	// Token: 0x17001C39 RID: 7225
	// (get) Token: 0x06015C65 RID: 89189 RVA: 0x0060A8AC File Offset: 0x00608AAC
	// (set) Token: 0x06015C66 RID: 89190 RVA: 0x0060A8B4 File Offset: 0x00608AB4
	public ESkipConditionType ConditionType { get; set; }

	// Token: 0x17001C3A RID: 7226
	// (get) Token: 0x06015C67 RID: 89191 RVA: 0x0060A8BD File Offset: 0x00608ABD
	// (set) Token: 0x06015C68 RID: 89192 RVA: 0x0060A8C5 File Offset: 0x00608AC5
	public int QuestId { get; set; }

	// Token: 0x17001C3B RID: 7227
	// (get) Token: 0x06015C69 RID: 89193 RVA: 0x0060A8CE File Offset: 0x00608ACE
	// (set) Token: 0x06015C6A RID: 89194 RVA: 0x0060A8D6 File Offset: 0x00608AD6
	public ESkipQuestState CheckQuestState { get; set; }
}
