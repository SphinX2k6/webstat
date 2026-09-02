using System;
using System.Runtime.CompilerServices;

// Token: 0x02002192 RID: 8594
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeJumpLogEvent : PlayerCommonLogData
{
	// Token: 0x170013EA RID: 5098
	// (get) Token: 0x060104B3 RID: 66739 RVA: 0x00476782 File Offset: 0x00474982
	// (set) Token: 0x060104B4 RID: 66740 RVA: 0x0047678A File Offset: 0x0047498A
	public override string event_id { get; set; } = "1918";

	// Token: 0x04007F7A RID: 32634
	public int i_chapter_id;

	// Token: 0x04007F7B RID: 32635
	public int i_quest_id;

	// Token: 0x04007F7C RID: 32636
	public int i_quest_status;

	// Token: 0x04007F7D RID: 32637
	public int i_quest_type;

	// Token: 0x04007F7E RID: 32638
	public int i_motion;
}
