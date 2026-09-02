using System;
using System.Runtime.CompilerServices;

// Token: 0x02001E57 RID: 7767
[NullableContext(1)]
[Nullable(0)]
public class HandBookContentItemData
{
	// Token: 0x0600E61F RID: 58911 RVA: 0x003E1E8E File Offset: 0x003E008E
	public HandBookContentItemData(string title, string desc)
	{
		this.Title = title;
		this.Desc = desc;
	}

	// Token: 0x04006EC9 RID: 28361
	public string Title;

	// Token: 0x04006ECA RID: 28362
	public string Desc;
}
