using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200212E RID: 8494
[NullableContext(1)]
[Nullable(0)]
public class AdviceWatchLogData : PlayerCommonLogData
{
	// Token: 0x1700138A RID: 5002
	// (get) Token: 0x0601038C RID: 66444 RVA: 0x004755A1 File Offset: 0x004737A1
	// (set) Token: 0x0601038D RID: 66445 RVA: 0x004755A9 File Offset: 0x004737A9
	public override string event_id { get; set; } = "1008";

	// Token: 0x04007D90 RID: 32144
	public string l_advice_id = " ";

	// Token: 0x04007D91 RID: 32145
	public List<LogAdviceData> o_content;

	// Token: 0x04007D92 RID: 32146
	public int i_creator_id;

	// Token: 0x04007D93 RID: 32147
	public float f_pos_x;

	// Token: 0x04007D94 RID: 32148
	public float f_pos_y;

	// Token: 0x04007D95 RID: 32149
	public float f_pos_z;

	// Token: 0x04007D96 RID: 32150
	public int i_area_id;

	// Token: 0x04007D97 RID: 32151
	public int i_father_area_id;

	// Token: 0x04007D98 RID: 32152
	public int i_expression;

	// Token: 0x04007D99 RID: 32153
	public int i_motion;
}
