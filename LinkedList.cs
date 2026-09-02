using System;
using System.Runtime.CompilerServices;

// Token: 0x02000066 RID: 102
[NullableContext(1)]
[Nullable(0)]
public class LinkedList<[Nullable(2)] T>
{
	// Token: 0x17000042 RID: 66
	// (get) Token: 0x06000247 RID: 583 RVA: 0x0000CB02 File Offset: 0x0000AD02
	public int Count
	{
		get
		{
			return this.Length - 1;
		}
	}

	// Token: 0x17000043 RID: 67
	// (get) Token: 0x06000248 RID: 584 RVA: 0x0000CB0C File Offset: 0x0000AD0C
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public LinkedNode<T> TailNode
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return this.Tail;
		}
	}

	// Token: 0x06000249 RID: 585 RVA: 0x0000CB14 File Offset: 0x0000AD14
	public LinkedList(T element)
	{
		this.Head = new LinkedNode<T>(element);
		this.Tail = this.Head;
		this.Length = 1;
	}

	// Token: 0x0600024A RID: 586 RVA: 0x0000CB3C File Offset: 0x0000AD3C
	public LinkedNode<T> AddTail(T newElement)
	{
		LinkedNode<T> linkedNode = new LinkedNode<T>(newElement);
		this.Tail.Next = linkedNode;
		this.Tail = linkedNode;
		this.Length++;
		return linkedNode;
	}

	// Token: 0x0600024B RID: 587 RVA: 0x0000CB74 File Offset: 0x0000AD74
	public void RemoveNodesBeforeThis(LinkedNode<T> removeNode, bool includeThis)
	{
		if (removeNode == this.Head)
		{
			return;
		}
		if (this.Tail == removeNode)
		{
			if (includeThis)
			{
				this.Head.Next = null;
				this.Tail = this.Head;
				this.Length = 1;
				return;
			}
			LinkedNode<T> next = this.Head.Next;
			int num = 0;
			while (next != null && next != removeNode)
			{
				num++;
				next = next.Next;
			}
			this.Head.Next = removeNode;
			this.Length -= num;
			return;
		}
		else
		{
			LinkedNode<T> next2 = this.Head.Next;
			int num2 = 1;
			while (next2 != removeNode && next2 != null)
			{
				next2 = next2.Next;
				num2++;
			}
			if (next2 == null)
			{
				return;
			}
			if (includeThis)
			{
				this.Head.Next = removeNode.Next;
				this.Length -= num2;
				return;
			}
			this.Head.Next = removeNode;
			this.Length -= num2 - 1;
			return;
		}
	}

	// Token: 0x0600024C RID: 588 RVA: 0x0000CC5C File Offset: 0x0000AE5C
	public void RemoveNode(LinkedNode<T> removeNode)
	{
		if (removeNode == this.Head)
		{
			return;
		}
		LinkedNode<T> linkedNode = this.Head;
		while (linkedNode.Next != removeNode && linkedNode != this.Tail)
		{
			linkedNode = linkedNode.Next;
		}
		if (linkedNode.Next == removeNode)
		{
			linkedNode.Next = removeNode.Next;
			if (removeNode == this.Tail)
			{
				this.Tail = linkedNode;
			}
			this.Length--;
		}
	}

	// Token: 0x0600024D RID: 589 RVA: 0x0000CCC8 File Offset: 0x0000AEC8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public LinkedNode<T> GetHeadNextNode()
	{
		return this.Head.Next;
	}

	// Token: 0x0600024E RID: 590 RVA: 0x0000CCD5 File Offset: 0x0000AED5
	public void RemoveAllNodeWithoutHead()
	{
		this.Head.Next = null;
		this.Tail = this.Head;
		this.Length = 1;
	}

	// Token: 0x040001C8 RID: 456
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private readonly LinkedNode<T> Head;

	// Token: 0x040001C9 RID: 457
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LinkedNode<T> Tail;

	// Token: 0x040001CA RID: 458
	private int Length;
}
