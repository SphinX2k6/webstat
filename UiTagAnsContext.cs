using System;
using System.Runtime.CompilerServices;

// Token: 0x02002C7A RID: 11386
public class UiTagAnsContext : UiAnsContextBase
{
	// Token: 0x17001E01 RID: 7681
	// (get) Token: 0x06016D7B RID: 93563 RVA: 0x00656633 File Offset: 0x00654833
	public int TagId { get; }

	// Token: 0x06016D7C RID: 93564 RVA: 0x0065663B File Offset: 0x0065483B
	public UiTagAnsContext(int tagId)
	{
		this.TagId = tagId;
	}

	// Token: 0x06016D7D RID: 93565 RVA: 0x0065664C File Offset: 0x0065484C
	[NullableContext(1)]
	public override bool IsEqual(UiAnsContextBase inAnsContext)
	{
		UiTagAnsContext uiTagAnsContext = inAnsContext as UiTagAnsContext;
		return uiTagAnsContext != null && this.TagId == uiTagAnsContext.TagId;
	}
}
