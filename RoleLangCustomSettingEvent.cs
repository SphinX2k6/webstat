using System;
using System.Runtime.CompilerServices;

// Token: 0x020021CD RID: 8653
[NullableContext(1)]
[Nullable(0)]
public class RoleLangCustomSettingEvent : PlayerCommonLogData
{
	// Token: 0x17001421 RID: 5153
	// (get) Token: 0x0601055C RID: 66908 RVA: 0x004770BD File Offset: 0x004752BD
	// (set) Token: 0x0601055D RID: 66909 RVA: 0x004770C5 File Offset: 0x004752C5
	public override string event_id { get; set; } = "1927";

	// Token: 0x0400809A RID: 32922
	public int i_language;

	// Token: 0x0400809B RID: 32923
	public int i_cover;

	// Token: 0x0400809C RID: 32924
	public int i_way;
}
