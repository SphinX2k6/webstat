using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine.Extension;

// Token: 0x02000076 RID: 118
[NullableContext(1)]
[Nullable(0)]
public class Stack<[Nullable(2)] T> : IEnumerable<T>, IEnumerable, IClearable
{
	// Token: 0x060002CC RID: 716 RVA: 0x0000F708 File Offset: 0x0000D908
	public IEnumerator<T> GetEnumerator()
	{
		return this.List.GetEnumerator();
	}

	// Token: 0x060002CD RID: 717 RVA: 0x0000F71A File Offset: 0x0000D91A
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x1700005E RID: 94
	// (get) Token: 0x060002CE RID: 718 RVA: 0x0000F722 File Offset: 0x0000D922
	public int Size
	{
		get
		{
			return this.List.Count;
		}
	}

	// Token: 0x1700005F RID: 95
	// (get) Token: 0x060002CF RID: 719 RVA: 0x0000F72F File Offset: 0x0000D92F
	public bool Empty
	{
		get
		{
			return this.Size == 0;
		}
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x0000F73A File Offset: 0x0000D93A
	public void Clear()
	{
		this.List.Clear();
	}

	// Token: 0x060002D1 RID: 721 RVA: 0x0000F747 File Offset: 0x0000D947
	public void Push(T element)
	{
		this.List.Add(element);
	}

	// Token: 0x060002D2 RID: 722 RVA: 0x0000F758 File Offset: 0x0000D958
	[NullableContext(2)]
	public T Peek()
	{
		if (this.Size <= 0)
		{
			return default(T);
		}
		return this.List[this.List.Count - 1];
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x0000F790 File Offset: 0x0000D990
	[NullableContext(2)]
	public T Pop()
	{
		if (this.List.Count == 0)
		{
			return default(T);
		}
		T result = this.List[this.List.Count - 1];
		this.List.RemoveAt(this.List.Count - 1);
		return result;
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x0000F7E4 File Offset: 0x0000D9E4
	public bool Delete(T element)
	{
		int num = this.List.IndexOf(element);
		if (num >= 0)
		{
			this.List.RemoveAt(num);
			return true;
		}
		return false;
	}

	// Token: 0x04000205 RID: 517
	private readonly List<T> List = new List<T>();
}
