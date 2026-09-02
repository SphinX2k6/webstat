using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine.Extension;

// Token: 0x0200006B RID: 107
[NullableContext(1)]
[Nullable(0)]
public class PriorityQueue<[Nullable(2)] T> : IClearable
{
	// Token: 0x0600026C RID: 620 RVA: 0x0000D70C File Offset: 0x0000B90C
	public PriorityQueue(Comparison<T> compare)
	{
		this._Compare = compare;
	}

	// Token: 0x0600026D RID: 621 RVA: 0x0000D734 File Offset: 0x0000B934
	public void Clone(PriorityQueue<T> origin)
	{
		this.Clear();
		foreach (T item in origin._Heap)
		{
			this._Heap.Add(item);
		}
		foreach (KeyValuePair<T, int> keyValuePair in origin._Hash)
		{
			this._Hash.Add(keyValuePair.Key, keyValuePair.Value);
		}
	}

	// Token: 0x1700004B RID: 75
	// (get) Token: 0x0600026E RID: 622 RVA: 0x0000D7E8 File Offset: 0x0000B9E8
	public int Size
	{
		get
		{
			return this._Heap.Count;
		}
	}

	// Token: 0x1700004C RID: 76
	// (get) Token: 0x0600026F RID: 623 RVA: 0x0000D7F5 File Offset: 0x0000B9F5
	public bool Empty
	{
		get
		{
			return this._Heap.Count == 0;
		}
	}

	// Token: 0x1700004D RID: 77
	// (get) Token: 0x06000270 RID: 624 RVA: 0x0000D808 File Offset: 0x0000BA08
	[Nullable(2)]
	public T Top
	{
		[NullableContext(2)]
		get
		{
			if (this._Heap.Count <= 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Container, ELogAuthor.LCC, "优先队列为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return default(T);
			}
			return this._Heap[0];
		}
	}

	// Token: 0x06000271 RID: 625 RVA: 0x0000D854 File Offset: 0x0000BA54
	public void Clear()
	{
		this._Heap.Clear();
		this._Hash.Clear();
	}

	// Token: 0x06000272 RID: 626 RVA: 0x0000D86C File Offset: 0x0000BA6C
	public bool Has(T item)
	{
		return this._Hash.ContainsKey(item);
	}

	// Token: 0x06000273 RID: 627 RVA: 0x0000D87C File Offset: 0x0000BA7C
	public void Push(T item)
	{
		int count = this._Heap.Count;
		this._Heap.Add(item);
		this._Hash[item] = count;
		this.Up(count);
	}

	// Token: 0x06000274 RID: 628 RVA: 0x0000D8B8 File Offset: 0x0000BAB8
	[NullableContext(2)]
	public T Pop()
	{
		if (this._Heap.Count <= 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Container, ELogAuthor.LCC, "优先队列为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return default(T);
		}
		T t = this._Heap[0];
		this._Hash.Remove(t);
		T t2 = this._Heap[this._Heap.Count - 1];
		this._Heap.RemoveAt(this._Heap.Count - 1);
		if (this._Heap.Count > 0)
		{
			this._Heap[0] = t2;
			this._Hash[t2] = 0;
			this.Down(0);
		}
		return t;
	}

	// Token: 0x06000275 RID: 629 RVA: 0x0000D974 File Offset: 0x0000BB74
	public bool Remove(T item)
	{
		int num;
		if (!this._Hash.TryGetValue(item, out num))
		{
			Singleton<Log>.Instance.Error(ELogModule.Container, ELogAuthor.LCC, "元素不在优先队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (num == this._Heap.Count - 1)
		{
			this._Heap.RemoveAt(this._Heap.Count - 1);
			this._Hash.Remove(item);
			return true;
		}
		this._Hash.Remove(item);
		T t = this._Heap[this._Heap.Count - 1];
		this._Heap.RemoveAt(this._Heap.Count - 1);
		this._Heap[num] = t;
		this._Hash[t] = num;
		this.Down(num);
		return true;
	}

	// Token: 0x06000276 RID: 630 RVA: 0x0000DA48 File Offset: 0x0000BC48
	public bool Update(T item)
	{
		int index;
		if (!this._Hash.TryGetValue(item, out index))
		{
			Singleton<Log>.Instance.Error(ELogModule.Container, ELogAuthor.LCC, "元素不在优先队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (!this.Up(index))
		{
			this.Down(index);
		}
		return true;
	}

	// Token: 0x06000277 RID: 631 RVA: 0x0000DA94 File Offset: 0x0000BC94
	public void Heapify()
	{
		for (int i = (this._Heap.Count - 2) / 2; i >= 0; i--)
		{
			this.Down(i);
		}
	}

	// Token: 0x06000278 RID: 632 RVA: 0x0000DAC4 File Offset: 0x0000BCC4
	private bool Up(int index)
	{
		bool result = false;
		int i = index;
		while (i > 0)
		{
			int num = (i - 1) / 2;
			if (this._Compare(this._Heap[i], this._Heap[num]) >= 0)
			{
				break;
			}
			this.Swap(i, num);
			i = num;
			result = true;
		}
		return result;
	}

	// Token: 0x06000279 RID: 633 RVA: 0x0000DB14 File Offset: 0x0000BD14
	private bool Down(int index)
	{
		bool result = false;
		int num = index;
		for (;;)
		{
			int num2 = 2 * num + 1;
			int num3 = 2 * num + 2;
			int num4 = num2;
			if (num3 < this._Heap.Count && this._Compare(this._Heap[num3], this._Heap[num2]) < 0)
			{
				num4 = num3;
			}
			if (num4 >= this._Heap.Count || this._Compare(this._Heap[num], this._Heap[num4]) <= 0)
			{
				break;
			}
			this.Swap(num, num4);
			num = num4;
			result = true;
		}
		return result;
	}

	// Token: 0x0600027A RID: 634 RVA: 0x0000DBB8 File Offset: 0x0000BDB8
	private void Swap(int i, int j)
	{
		T value = this._Heap[i];
		this._Heap[i] = this._Heap[j];
		this._Heap[j] = value;
		this._Hash[this._Heap[i]] = i;
		this._Hash[this._Heap[j]] = j;
	}

	// Token: 0x040001E6 RID: 486
	private readonly List<T> _Heap = new List<T>();

	// Token: 0x040001E7 RID: 487
	private readonly Dictionary<T, int> _Hash = new Dictionary<T, int>();

	// Token: 0x040001E8 RID: 488
	private readonly Comparison<T> _Compare;
}
