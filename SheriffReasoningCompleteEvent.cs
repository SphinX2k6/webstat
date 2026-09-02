using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020021C8 RID: 8648
[NullableContext(1)]
[Nullable(0)]
public class SheriffReasoningCompleteEvent : PlayerCommonLogData
{
	// Token: 0x1700141C RID: 5148
	// (get) Token: 0x0601054D RID: 66893 RVA: 0x00477009 File Offset: 0x00475209
	// (set) Token: 0x0601054E RID: 66894 RVA: 0x00477011 File Offset: 0x00475211
	public override string event_id { get; set; } = "1920";

	// Token: 0x0400808C RID: 32908
	public int i_quest_id;

	// Token: 0x0400808D RID: 32909
	public int i_question_id;

	// Token: 0x0400808E RID: 32910
	public int i_result_id;

	// Token: 0x0400808F RID: 32911
	[Nullable(2)]
	public List<int> o_clue_id;
}
