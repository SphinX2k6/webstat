using System;
using System.Runtime.CompilerServices;

// Token: 0x0200212D RID: 8493
[NullableContext(1)]
[Nullable(0)]
public class QuestDiscoverLogData : PlayerCommonLogData
{
	// Token: 0x17001389 RID: 5001
	// (get) Token: 0x06010389 RID: 66441 RVA: 0x0047557D File Offset: 0x0047377D
	// (set) Token: 0x0601038A RID: 66442 RVA: 0x00475585 File Offset: 0x00473785
	public override string event_id { get; set; } = "1007";

	// Token: 0x04007D87 RID: 32135
	public int i_quest_id;

	// Token: 0x04007D88 RID: 32136
	public int i_quest_type;

	// Token: 0x04007D89 RID: 32137
	public int i_icon_distance;

	// Token: 0x04007D8A RID: 32138
	public int i_area_id;

	// Token: 0x04007D8B RID: 32139
	public int i_father_area_id;

	// Token: 0x04007D8C RID: 32140
	public float f_pos_x;

	// Token: 0x04007D8D RID: 32141
	public float f_pos_y;

	// Token: 0x04007D8E RID: 32142
	public float f_pos_z;
}
