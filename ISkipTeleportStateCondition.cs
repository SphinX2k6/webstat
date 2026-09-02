using System;

// Token: 0x02002A75 RID: 10869
public interface ISkipTeleportStateCondition : ISkipCondition<ESkipConditionType>
{
	// Token: 0x17001C35 RID: 7221
	// (get) Token: 0x06015C54 RID: 89172
	// (set) Token: 0x06015C55 RID: 89173
	int MarkId { get; set; }

	// Token: 0x17001C36 RID: 7222
	// (get) Token: 0x06015C56 RID: 89174
	// (set) Token: 0x06015C57 RID: 89175
	ETeleportState CheckTeleportState { get; set; }
}
