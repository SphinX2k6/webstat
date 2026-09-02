using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002256 RID: 8790
public class MarqueeDataEx
{
	// Token: 0x0400827A RID: 33402
	public int id;

	// Token: 0x0400827B RID: 33403
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<MarqueeContent> contents;

	// Token: 0x0400827C RID: 33404
	public int timeInterval;

	// Token: 0x0400827D RID: 33405
	public int times;

	// Token: 0x0400827E RID: 33406
	public double startTimeMs;

	// Token: 0x0400827F RID: 33407
	public double endTimeMs;

	// Token: 0x04008280 RID: 33408
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> whiteList;

	// Token: 0x04008281 RID: 33409
	[Nullable(2)]
	public List<int> platform;

	// Token: 0x04008282 RID: 33410
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> channel;
}
