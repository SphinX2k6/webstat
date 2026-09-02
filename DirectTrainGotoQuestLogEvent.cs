using System;
using System.Runtime.CompilerServices;

// Token: 0x020021D7 RID: 8663
[NullableContext(1)]
[Nullable(0)]
public class DirectTrainGotoQuestLogEvent : PlayerCommonLogData
{
	// Token: 0x17001428 RID: 5160
	// (get) Token: 0x06010574 RID: 66932 RVA: 0x00477251 File Offset: 0x00475451
	// (set) Token: 0x06010575 RID: 66933 RVA: 0x00477259 File Offset: 0x00475459
	public override string event_id { get; set; } = "1113";

	// Token: 0x040080CC RID: 32972
	public int i_activity_id;

	// Token: 0x040080CD RID: 32973
	public int i_id;

	// Token: 0x040080CE RID: 32974
	public int i_quest_id;

	// Token: 0x040080CF RID: 32975
	public int i_if_finish;
}
