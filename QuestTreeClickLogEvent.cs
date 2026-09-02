using System;
using System.Runtime.CompilerServices;

// Token: 0x02002191 RID: 8593
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeClickLogEvent : PlayerCommonLogData
{
	// Token: 0x170013E9 RID: 5097
	// (get) Token: 0x060104B0 RID: 66736 RVA: 0x0047675E File Offset: 0x0047495E
	// (set) Token: 0x060104B1 RID: 66737 RVA: 0x00476766 File Offset: 0x00474966
	public override string event_id { get; set; } = "1912";

	// Token: 0x04007F75 RID: 32629
	public int i_chapter_id;

	// Token: 0x04007F76 RID: 32630
	public int i_quest_id;

	// Token: 0x04007F77 RID: 32631
	public int i_quest_status;

	// Token: 0x04007F78 RID: 32632
	public int i_quest_type;
}
