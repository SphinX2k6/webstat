using System;
using System.Runtime.CompilerServices;

// Token: 0x02000EC8 RID: 3784
[NullableContext(1)]
[Nullable(0)]
public class GlobalProductContentData
{
	// Token: 0x04002D09 RID: 11529
	public string local = "";

	// Token: 0x04002D0A RID: 11530
	public string coin = "";

	// Token: 0x04002D0B RID: 11531
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public GlobalProductPriceItem[] price;

	// Token: 0x04002D0C RID: 11532
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public AndroidGlobalProductContentPriceData[] PriceItem;
}
