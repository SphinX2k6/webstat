using System;
using System.Runtime.CompilerServices;

// Token: 0x02001493 RID: 5267
public class PinballChapterData
{
	// Token: 0x0400442D RID: 17453
	public int ChapterId;

	// Token: 0x0400442E RID: 17454
	public int PreChapterId;

	// Token: 0x0400442F RID: 17455
	public int UnlockTime;

	// Token: 0x04004430 RID: 17456
	[Nullable(1)]
	public int[] LevelIds = Array.Empty<int>();
}
