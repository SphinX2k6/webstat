using System;
using System.Runtime.CompilerServices;

// Token: 0x02000067 RID: 103
[NullableContext(1)]
[Nullable(0)]
internal class LruNode<[Nullable(2)] TK, TV> where TV : class
{
	// Token: 0x0600024F RID: 591 RVA: 0x0000CCF6 File Offset: 0x0000AEF6
	public LruNode(TK key, TV value)
	{
		this.Key = key;
		this.Value = value;
	}

	// Token: 0x040001CB RID: 459
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public LruNode<TK, TV> Prev;

	// Token: 0x040001CC RID: 460
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public LruNode<TK, TV> Next;

	// Token: 0x040001CD RID: 461
	public int Count;

	// Token: 0x040001CE RID: 462
	public readonly TK Key;

	// Token: 0x040001CF RID: 463
	public readonly TV Value;
}
