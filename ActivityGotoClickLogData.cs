using System;
using System.Runtime.CompilerServices;

// Token: 0x020021D9 RID: 8665
[NullableContext(1)]
[Nullable(0)]
public class ActivityGotoClickLogData : PlayerCommonLogData
{
	// Token: 0x1700142A RID: 5162
	// (get) Token: 0x0601057A RID: 66938 RVA: 0x00477299 File Offset: 0x00475499
	// (set) Token: 0x0601057B RID: 66939 RVA: 0x004772A1 File Offset: 0x004754A1
	public override string event_id { get; set; } = "1938";

	// Token: 0x040080D3 RID: 32979
	public int i_activity_id;

	// Token: 0x040080D4 RID: 32980
	public int i_type;

	// Token: 0x040080D5 RID: 32981
	public int i_scene;
}
