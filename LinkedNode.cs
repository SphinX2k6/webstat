using System;
using System.Runtime.CompilerServices;

// Token: 0x02000065 RID: 101
[NullableContext(2)]
[Nullable(0)]
public class LinkedNode<T>
{
	// Token: 0x06000246 RID: 582 RVA: 0x0000CAF3 File Offset: 0x0000ACF3
	[NullableContext(1)]
	public LinkedNode(T element)
	{
		this.Element = element;
	}

	// Token: 0x040001C6 RID: 454
	public T Element;

	// Token: 0x040001C7 RID: 455
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public LinkedNode<T> Next;
}
