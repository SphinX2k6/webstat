using System;
using System.Runtime.CompilerServices;

// Token: 0x02000078 RID: 120
[NullableContext(1)]
[Nullable(0)]
public class TrimLruNode<[Nullable(2)] TK, TV> where TV : class
{
	// Token: 0x060002DF RID: 735 RVA: 0x0000FA20 File Offset: 0x0000DC20
	public TrimLruNode(TK key, TV value, int size)
	{
		this.Key = key;
		this.Value = value;
		this.Size = size;
	}

	// Token: 0x04000209 RID: 521
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public TrimLruNode<TK, TV> Prev;

	// Token: 0x0400020A RID: 522
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public TrimLruNode<TK, TV> Next;

	// Token: 0x0400020B RID: 523
	public int Count;

	// Token: 0x0400020C RID: 524
	public readonly TK Key;

	// Token: 0x0400020D RID: 525
	public readonly TV Value;

	// Token: 0x0400020E RID: 526
	public readonly int Size;
}
