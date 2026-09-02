using System;
using System.Runtime.CompilerServices;

// Token: 0x02001E22 RID: 7714
[NullableContext(1)]
[Nullable(0)]
public class GuideTestParam
{
	// Token: 0x0600E3D0 RID: 58320 RVA: 0x003D5150 File Offset: 0x003D3350
	public void Clear()
	{
		this.ViewName = "";
		this.HookName = "";
		this.HookNameForShow = "";
		this.MarkName = "";
		this.MarkNameForShow = "";
		this.ExtraParams = Array.Empty<string>();
	}

	// Token: 0x04006D89 RID: 28041
	public string ViewName = "";

	// Token: 0x04006D8A RID: 28042
	public string HookName = "";

	// Token: 0x04006D8B RID: 28043
	public string HookNameForShow = "";

	// Token: 0x04006D8C RID: 28044
	public string MarkName = "";

	// Token: 0x04006D8D RID: 28045
	public string MarkNameForShow = "";

	// Token: 0x04006D8E RID: 28046
	public string[] ExtraParams = Array.Empty<string>();
}
