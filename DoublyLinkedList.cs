using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200005E RID: 94
[NullableContext(1)]
[Nullable(0)]
public class DoublyLinkedList<[Nullable(2)] T>
{
	// Token: 0x060001FF RID: 511 RVA: 0x0000C058 File Offset: 0x0000A258
	public static DoublyLinkedList<T> From(T[] array)
	{
		int num = array.Length;
		T element = default(T);
		List<T> list = new List<T>();
		if (num > 0)
		{
			element = array[0];
			for (int i = 1; i < num; i++)
			{
				list.Add(array[i]);
			}
		}
		DoublyLinkedList<T> doublyLinkedList = new DoublyLinkedList<T>(element);
		doublyLinkedList.Length = num;
		DoublyLinkedNode<T> doublyLinkedNode = doublyLinkedList.Head;
		foreach (T element2 in list)
		{
			if (doublyLinkedNode != null)
			{
				doublyLinkedNode.Next = new DoublyLinkedNode<T>(element2);
				doublyLinkedNode.Next.Pre = doublyLinkedNode;
				doublyLinkedNode = doublyLinkedNode.Next;
			}
			else
			{
				doublyLinkedNode = null;
			}
		}
		return doublyLinkedList;
	}

	// Token: 0x1700003A RID: 58
	// (get) Token: 0x06000200 RID: 512 RVA: 0x0000C124 File Offset: 0x0000A324
	public int CountWithHead
	{
		get
		{
			return this.Length - 1;
		}
	}

	// Token: 0x06000201 RID: 513 RVA: 0x0000C130 File Offset: 0x0000A330
	[NullableContext(2)]
	public DoublyLinkedList(T element = default(T))
	{
		this.Head = new DoublyLinkedNode<T>(element);
		this.Head.Next = this.Head;
		this.Head.Pre = this.Head;
		this.Tail = this.Head;
		this.Length = 1;
	}

	// Token: 0x06000202 RID: 514 RVA: 0x0000C184 File Offset: 0x0000A384
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public DoublyLinkedNode<T> Find(Func<DoublyLinkedNode<T>, bool> cb)
	{
		DoublyLinkedNode<T> doublyLinkedNode = this.Head;
		if (doublyLinkedNode == null)
		{
			return null;
		}
		int num = 0;
		while (num < this.Length && !cb(doublyLinkedNode))
		{
			doublyLinkedNode = doublyLinkedNode.Next;
			num++;
		}
		if (num == this.Length)
		{
			return null;
		}
		return doublyLinkedNode;
	}

	// Token: 0x06000203 RID: 515 RVA: 0x0000C1CC File Offset: 0x0000A3CC
	public DoublyLinkedNode<T> Insert(T newElement, DoublyLinkedNode<T> node)
	{
		DoublyLinkedNode<T> doublyLinkedNode = new DoublyLinkedNode<T>(newElement);
		DoublyLinkedNode<T> doublyLinkedNode2 = this.Find((DoublyLinkedNode<T> n) => n == node);
		if (doublyLinkedNode2 != null)
		{
			DoublyLinkedNode<T> next = doublyLinkedNode2.Next;
			doublyLinkedNode2.Next = doublyLinkedNode;
			doublyLinkedNode.Pre = doublyLinkedNode2;
			doublyLinkedNode.Next = next;
			if (next != null)
			{
				next.Pre = doublyLinkedNode;
			}
			this.Length++;
		}
		if (doublyLinkedNode.Next == null)
		{
			this.Tail = doublyLinkedNode;
		}
		return doublyLinkedNode;
	}

	// Token: 0x06000204 RID: 516 RVA: 0x0000C248 File Offset: 0x0000A448
	public void Remove(DoublyLinkedNode<T> node)
	{
		DoublyLinkedNode<T> doublyLinkedNode = this.Find((DoublyLinkedNode<T> n) => n == node);
		if (doublyLinkedNode == null)
		{
			return;
		}
		if (this.Head == doublyLinkedNode)
		{
			this.Head = doublyLinkedNode.Next;
		}
		if (doublyLinkedNode == this.Tail)
		{
			this.Tail = ((doublyLinkedNode != null) ? doublyLinkedNode.Pre : null);
		}
		if (doublyLinkedNode.Pre != null)
		{
			doublyLinkedNode.Pre.Next = doublyLinkedNode.Next;
		}
		if (doublyLinkedNode.Next != null)
		{
			doublyLinkedNode.Next.Pre = doublyLinkedNode.Pre;
		}
		this.Length--;
	}

	// Token: 0x06000205 RID: 517 RVA: 0x0000C2EC File Offset: 0x0000A4EC
	public void RemoveThis(DoublyLinkedNode<T> node)
	{
		if (this.Head == node)
		{
			return;
		}
		if (node == this.Tail)
		{
			this.Tail = node.Pre;
		}
		if (node.Pre != null)
		{
			node.Pre.Next = node.Next;
		}
		if (node.Next != null)
		{
			node.Next.Pre = node.Pre;
		}
		this.Length--;
	}

	// Token: 0x06000206 RID: 518 RVA: 0x0000C358 File Offset: 0x0000A558
	public DoublyLinkedNode<T> AddTail(T newElement)
	{
		DoublyLinkedNode<T> doublyLinkedNode = new DoublyLinkedNode<T>(newElement);
		DoublyLinkedNode<T> head = this.Head;
		DoublyLinkedNode<T> doublyLinkedNode2 = (head != null) ? head.Pre : null;
		DoublyLinkedNode<T> doublyLinkedNode3 = (doublyLinkedNode2 != null) ? doublyLinkedNode2.Next : null;
		if (doublyLinkedNode2 != null)
		{
			doublyLinkedNode2.Next = doublyLinkedNode;
		}
		doublyLinkedNode.Pre = doublyLinkedNode2;
		doublyLinkedNode.Next = doublyLinkedNode3;
		if (doublyLinkedNode3 != null)
		{
			doublyLinkedNode3.Pre = doublyLinkedNode;
		}
		this.Length++;
		this.Tail = doublyLinkedNode;
		return doublyLinkedNode;
	}

	// Token: 0x06000207 RID: 519 RVA: 0x0000C3C4 File Offset: 0x0000A5C4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public DoublyLinkedNode<T> GetHeadNode()
	{
		return this.Head;
	}

	// Token: 0x06000208 RID: 520 RVA: 0x0000C3CC File Offset: 0x0000A5CC
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public DoublyLinkedNode<T> GetTailNode()
	{
		return this.Tail;
	}

	// Token: 0x06000209 RID: 521 RVA: 0x0000C3D4 File Offset: 0x0000A5D4
	public void RemoveAllNodeWithoutHead()
	{
		if (this.Head != null)
		{
			this.Head.Next = this.Head;
			this.Head.Pre = this.Head;
			this.Tail = this.Head;
			this.Length = 1;
		}
	}

	// Token: 0x040001B7 RID: 439
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private DoublyLinkedNode<T> Head;

	// Token: 0x040001B8 RID: 440
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private DoublyLinkedNode<T> Tail;

	// Token: 0x040001B9 RID: 441
	private int Length;
}
