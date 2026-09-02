using System;
using System.Runtime.CompilerServices;

// Token: 0x0200005D RID: 93
[NullableContext(2)]
[Nullable(0)]
public class DoublyLinkedNode<T>
{
	// Token: 0x060001FE RID: 510 RVA: 0x0000C049 File Offset: 0x0000A249
	public DoublyLinkedNode(T element)
	{
		this.Element = element;
	}

	// Token: 0x040001B4 RID: 436
	public T Element;

	// Token: 0x040001B5 RID: 437
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public DoublyLinkedNode<T> Pre;

	// Token: 0x040001B6 RID: 438
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public DoublyLinkedNode<T> Next;
}
