using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A71 RID: 6769
public class CommonPropTipsButtonData
{
	// Token: 0x04005AB0 RID: 23216
	[Nullable(1)]
	public string Content = "";

	// Token: 0x04005AB1 RID: 23217
	public bool NeedInteractionGroup;

	// Token: 0x04005AB2 RID: 23218
	[Nullable(2)]
	public Action<int> ClickFunction;
}
