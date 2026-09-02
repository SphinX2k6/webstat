using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02007165 RID: 29029
[CompilerGenerated]
internal sealed class <>z__ReadOnlyArray<T> : IEnumerable, ICollection, IList, IEnumerable<!0>, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection<!0>, IList<T>
{
	// Token: 0x06046701 RID: 288513 RVA: 0x012AAA2B File Offset: 0x012A8C2B
	public <>z__ReadOnlyArray(T[] items)
	{
		this._items = items;
	}

	// Token: 0x06046702 RID: 288514 RVA: 0x012AAA3A File Offset: 0x012A8C3A
	[return: Nullable(1)]
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this._items.GetEnumerator();
	}

	// Token: 0x1700A74E RID: 42830
	// (get) Token: 0x06046703 RID: 288515 RVA: 0x012AAA47 File Offset: 0x012A8C47
	int ICollection.Count
	{
		get
		{
			return this._items.Length;
		}
	}

	// Token: 0x1700A74F RID: 42831
	// (get) Token: 0x06046704 RID: 288516 RVA: 0x012AAA51 File Offset: 0x012A8C51
	bool ICollection.IsSynchronized
	{
		get
		{
			return false;
		}
	}

	// Token: 0x1700A750 RID: 42832
	// (get) Token: 0x06046705 RID: 288517 RVA: 0x012AAA54 File Offset: 0x012A8C54
	object ICollection.SyncRoot
	{
		[return: Nullable(1)]
		get
		{
			return this;
		}
	}

	// Token: 0x06046706 RID: 288518 RVA: 0x012AAA57 File Offset: 0x012A8C57
	void ICollection.CopyTo([Nullable(1)] Array array, int index)
	{
		this._items.CopyTo(array, index);
	}

	// Token: 0x1700A751 RID: 42833
	object IList.this[int index]
	{
		[return: Nullable(2)]
		get
		{
			return this._items[index];
		}
		[param: Nullable(2)]
		set
		{
			throw new NotSupportedException();
		}
	}

	// Token: 0x1700A752 RID: 42834
	// (get) Token: 0x06046709 RID: 288521 RVA: 0x012AAA80 File Offset: 0x012A8C80
	bool IList.IsFixedSize
	{
		get
		{
			return true;
		}
	}

	// Token: 0x1700A753 RID: 42835
	// (get) Token: 0x0604670A RID: 288522 RVA: 0x012AAA83 File Offset: 0x012A8C83
	bool IList.IsReadOnly
	{
		get
		{
			return true;
		}
	}

	// Token: 0x0604670B RID: 288523 RVA: 0x012AAA86 File Offset: 0x012A8C86
	int IList.Add([Nullable(2)] object value)
	{
		throw new NotSupportedException();
	}

	// Token: 0x0604670C RID: 288524 RVA: 0x012AAA8D File Offset: 0x012A8C8D
	void IList.Clear()
	{
		throw new NotSupportedException();
	}

	// Token: 0x0604670D RID: 288525 RVA: 0x012AAA94 File Offset: 0x012A8C94
	bool IList.Contains([Nullable(2)] object value)
	{
		return this._items.Contains(value);
	}

	// Token: 0x0604670E RID: 288526 RVA: 0x012AAAA2 File Offset: 0x012A8CA2
	int IList.IndexOf([Nullable(2)] object value)
	{
		return this._items.IndexOf(value);
	}

	// Token: 0x0604670F RID: 288527 RVA: 0x012AAAB0 File Offset: 0x012A8CB0
	void IList.Insert(int index, [Nullable(2)] object value)
	{
		throw new NotSupportedException();
	}

	// Token: 0x06046710 RID: 288528 RVA: 0x012AAAB7 File Offset: 0x012A8CB7
	void IList.Remove([Nullable(2)] object value)
	{
		throw new NotSupportedException();
	}

	// Token: 0x06046711 RID: 288529 RVA: 0x012AAABE File Offset: 0x012A8CBE
	void IList.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	// Token: 0x06046712 RID: 288530 RVA: 0x012AAAC5 File Offset: 0x012A8CC5
	[return: Nullable(new byte[]
	{
		1,
		0
	})]
	IEnumerator<T> IEnumerable<!0>.GetEnumerator()
	{
		return this._items.GetEnumerator();
	}

	// Token: 0x1700A754 RID: 42836
	// (get) Token: 0x06046713 RID: 288531 RVA: 0x012AAAD2 File Offset: 0x012A8CD2
	int IReadOnlyCollection<!0>.Count
	{
		get
		{
			return this._items.Length;
		}
	}

	// Token: 0x1700A755 RID: 42837
	T IReadOnlyList<!0>.this[int index]
	{
		get
		{
			return this._items[index];
		}
	}

	// Token: 0x1700A756 RID: 42838
	// (get) Token: 0x06046715 RID: 288533 RVA: 0x012AAAEA File Offset: 0x012A8CEA
	int ICollection<!0>.Count
	{
		get
		{
			return this._items.Length;
		}
	}

	// Token: 0x1700A757 RID: 42839
	// (get) Token: 0x06046716 RID: 288534 RVA: 0x012AAAF4 File Offset: 0x012A8CF4
	bool ICollection<!0>.IsReadOnly
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06046717 RID: 288535 RVA: 0x012AAAF7 File Offset: 0x012A8CF7
	void ICollection<!0>.Add(T item)
	{
		throw new NotSupportedException();
	}

	// Token: 0x06046718 RID: 288536 RVA: 0x012AAAFE File Offset: 0x012A8CFE
	void ICollection<!0>.Clear()
	{
		throw new NotSupportedException();
	}

	// Token: 0x06046719 RID: 288537 RVA: 0x012AAB05 File Offset: 0x012A8D05
	bool ICollection<!0>.Contains(T item)
	{
		return this._items.Contains(item);
	}

	// Token: 0x0604671A RID: 288538 RVA: 0x012AAB13 File Offset: 0x012A8D13
	void ICollection<!0>.CopyTo([Nullable(new byte[]
	{
		1,
		0
	})] T[] array, int arrayIndex)
	{
		this._items.CopyTo(array, arrayIndex);
	}

	// Token: 0x0604671B RID: 288539 RVA: 0x012AAB22 File Offset: 0x012A8D22
	bool ICollection<!0>.Remove(T item)
	{
		throw new NotSupportedException();
	}

	// Token: 0x1700A758 RID: 42840
	T IList<!0>.this[int index]
	{
		get
		{
			return this._items[index];
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	// Token: 0x0604671E RID: 288542 RVA: 0x012AAB3E File Offset: 0x012A8D3E
	int IList<!0>.IndexOf(T item)
	{
		return this._items.IndexOf(item);
	}

	// Token: 0x0604671F RID: 288543 RVA: 0x012AAB4C File Offset: 0x012A8D4C
	void IList<!0>.Insert(int index, T item)
	{
		throw new NotSupportedException();
	}

	// Token: 0x06046720 RID: 288544 RVA: 0x012AAB53 File Offset: 0x012A8D53
	void IList<!0>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	// Token: 0x04027858 RID: 161880
	[CompilerGenerated]
	private readonly T[] _items;
}
