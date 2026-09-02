using System;
using System.Runtime.CompilerServices;

// Token: 0x020034DD RID: 13533
public class ScoreNode<[Nullable(1)] T> where T : class, new()
{
	// Token: 0x0400E639 RID: 58937
	[Nullable(2)]
	public T Item;

	// Token: 0x0400E63A RID: 58938
	public double Score;
}
