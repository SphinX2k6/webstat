using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02007166 RID: 29030
[CompilerGenerated]
internal sealed class <>z__ReadOnlySingleElementList<T> : IEnumerable, ICollection, IList, IEnumerable<!0>, IReadOnlyCollection<!0>, IReadOnlyList<!0>, ICollection<!0>, IList<!0>
{
	// Token: 0x06046721 RID: 288545 RVA: 0x012AAB5A File Offset: 0x012A8D5A
	public <>z__ReadOnlySingleElementList(T item)
	{
		this._item = item;
	}

	// Token: 0x06046722 RID: 288546 RVA: 0x012AAB69 File Offset: 0x012A8D69
	[return: Nullable(1)]
	IEnumerator IEnumerable.GetEnumerator()
	{
		return new <>z__ReadOnlySingleElementList<T>.Enumerator(this._item);
	}

	// Token: 0x1700A759 RID: 42841
	// (get) Token: 0x06046723 RID: 288547 RVA: 0x012AAB76 File Offset: 0x012A8D76
	int ICollection.Count
	{
		get
		{
			return 1;
		}
	}

	// Token: 0x1700A75A RID: 42842
	// (get) Token: 0x06046724 RID: 288548 RVA: 0x012AAB79 File Offset: 0x012A8D79
	bool ICollection.IsSynchronized
	{
		get
		{
			return false;
		}
	}

	// Token: 0x1700A75B RID: 42843
	// (get) Token: 0x06046725 RID: 288549 RVA: 0x012AAB7C File Offset: 0x012A8D7C
	object ICollection.SyncRoot
	{
		[return: Nullable(1)]
		get
		{
			return this;
		}
	}

	// Token: 0x06046726 RID: 288550 RVA: 0x012AAB7F File Offset: 0x012A8D7F
	void ICollection.CopyTo([Nullable(1)] Array array, int index)
	{
		array.SetValue(this._item, index);
	}

	// Token: 0x1700A75C RID: 42844
	object IList.this[int index]
	{
		[return: Nullable(2)]
		get
		{
			if (index != 0)
			{
				throw new IndexOutOfRangeException();
			}
			return this._item;
		}
		[param: Nullable(2)]
		set
		{
			throw new NotSupportedException();
		}
	}

	// Token: 0x1700A75D RID: 42845
	// (get) Token: 0x06046729 RID: 288553 RVA: 0x012AABB0 File Offset: 0x012A8DB0
	bool IList.IsFixedSize
	{
		get
		{
			return true;
		}
	}

	// Token: 0x1700A75E RID: 42846
	// (get) Token: 0x0604672A RID: 288554 RVA: 0x012AABB3 File Offset: 0x012A8DB3
	bool IList.IsReadOnly
	{
		get
		{
			return true;
		}
	}

	// Token: 0x0604672B RID: 288555 RVA: 0x012AABB6 File Offset: 0x012A8DB6
	int IList.Add([Nullable(2)] object value)
	{
		throw new NotSupportedException();
	}

	// Token: 0x0604672C RID: 288556 RVA: 0x012AABBD File Offset: 0x012A8DBD
	void IList.Clear()
	{
		throw new NotSupportedException();
	}

	// Token: 0x0604672D RID: 288557 RVA: 0x012AABC4 File Offset: 0x012A8DC4
	bool IList.Contains([Nullable(2)] object value)
	{
		return EqualityComparer<T>.Default.Equals(this._item, (T)((object)value));
	}

	// Token: 0x0604672E RID: 288558 RVA: 0x012AABDC File Offset: 0x012A8DDC
	int IList.IndexOf([Nullable(2)] object value)
	{
		if (!EqualityComparer<T>.Default.Equals(this._item, (T)((object)value)))
		{
			return -1;
		}
		return 0;
	}

	// Token: 0x0604672F RID: 288559 RVA: 0x012AABF9 File Offset: 0x012A8DF9
	void IList.Insert(int index, [Nullable(2)] object value)
	{
		throw new NotSupportedException();
	}

	// Token: 0x06046730 RID: 288560 RVA: 0x012AAC00 File Offset: 0x012A8E00
	void IList.Remove([Nullable(2)] object value)
	{
		throw new NotSupportedException();
	}

	// Token: 0x06046731 RID: 288561 RVA: 0x012AAC07 File Offset: 0x012A8E07
	void IList.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	// Token: 0x06046732 RID: 288562 RVA: 0x012AAC0E File Offset: 0x012A8E0E
	[return: Nullable(new byte[]
	{
		1,
		0
	})]
	IEnumerator<T> IEnumerable<!0>.GetEnumerator()
	{
		return new <>z__ReadOnlySingleElementList<T>.Enumerator(this._item);
	}

	// Token: 0x1700A75F RID: 42847
	// (get) Token: 0x06046733 RID: 288563 RVA: 0x012AAC1B File Offset: 0x012A8E1B
	int IReadOnlyCollection<!0>.Count
	{
		get
		{
			return 1;
		}
	}

	// Token: 0x1700A760 RID: 42848
	T IReadOnlyList<!0>.this[int index]
	{
		get
		{
			if (index != 0)
			{
				throw new IndexOutOfRangeException();
			}
			return this._item;
		}
	}

	// Token: 0x1700A761 RID: 42849
	// (get) Token: 0x06046735 RID: 288565 RVA: 0x012AAC2F File Offset: 0x012A8E2F
	int ICollection<!0>.Count
	{
		get
		{
			return 1;
		}
	}

	// Token: 0x1700A762 RID: 42850
	// (get) Token: 0x06046736 RID: 288566 RVA: 0x012AAC32 File Offset: 0x012A8E32
	bool ICollection<!0>.IsReadOnly
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06046737 RID: 288567 RVA: 0x012AAC35 File Offset: 0x012A8E35
	void ICollection<!0>.Add(T item)
	{
		throw new NotSupportedException();
	}

	// Token: 0x06046738 RID: 288568 RVA: 0x012AAC3C File Offset: 0x012A8E3C
	void ICollection<!0>.Clear()
	{
		throw new NotSupportedException();
	}

	// Token: 0x06046739 RID: 288569 RVA: 0x012AAC43 File Offset: 0x012A8E43
	bool ICollection<!0>.Contains(T item)
	{
		return EqualityComparer<T>.Default.Equals(this._item, item);
	}

	// Token: 0x0604673A RID: 288570 RVA: 0x012AAC56 File Offset: 0x012A8E56
	void ICollection<!0>.CopyTo([Nullable(new byte[]
	{
		1,
		0
	})] T[] array, int arrayIndex)
	{
		array[arrayIndex] = this._item;
	}

	// Token: 0x0604673B RID: 288571 RVA: 0x012AAC65 File Offset: 0x012A8E65
	bool ICollection<!0>.Remove(T item)
	{
		throw new NotSupportedException();
	}

	// Token: 0x1700A763 RID: 42851
	T IList<!0>.this[int index]
	{
		get
		{
			if (index != 0)
			{
				throw new IndexOutOfRangeException();
			}
			return this._item;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	// Token: 0x0604673E RID: 288574 RVA: 0x012AAC84 File Offset: 0x012A8E84
	int IList<!0>.IndexOf(T item)
	{
		if (!EqualityComparer<T>.Default.Equals(this._item, item))
		{
			return -1;
		}
		return 0;
	}

	// Token: 0x0604673F RID: 288575 RVA: 0x012AAC9C File Offset: 0x012A8E9C
	void IList<!0>.Insert(int index, T item)
	{
		throw new NotSupportedException();
	}

	// Token: 0x06046740 RID: 288576 RVA: 0x012AACA3 File Offset: 0x012A8EA3
	void IList<!0>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	// Token: 0x04027859 RID: 161881
	[CompilerGenerated]
	private readonly T _item;

	// Token: 0x0200CDAF RID: 52655
	private sealed class Enumerator : IDisposable, IEnumerator, IEnumerator<!0>
	{
		// Token: 0x060506AE RID: 329390 RVA: 0x01648A5F File Offset: 0x01646C5F
		public Enumerator(T item)
		{
			this.System.Collections.Generic.IEnumerator<T>.Current = item;
		}

		// Token: 0x1700AA74 RID: 43636
		// (get) Token: 0x060506AF RID: 329391 RVA: 0x01648A6E File Offset: 0x01646C6E
		object IEnumerator.Current
		{
			get
			{
				return this._item;
			}
		}

		// Token: 0x1700AA75 RID: 43637
		// (get) Token: 0x060506B0 RID: 329392 RVA: 0x01648A7B File Offset: 0x01646C7B
		T IEnumerator<!0>.Current
		{
			get
			{
				return this._item;
			}
		}

		// Token: 0x060506B1 RID: 329393 RVA: 0x01648A84 File Offset: 0x01646C84
		bool IEnumerator.MoveNext()
		{
			return !this._moveNextCalled && (this._moveNextCalled = true);
		}

		// Token: 0x060506B2 RID: 329394 RVA: 0x01648AA5 File Offset: 0x01646CA5
		void IEnumerator.Reset()
		{
			this._moveNextCalled = false;
		}

		// Token: 0x060506B3 RID: 329395 RVA: 0x01648AAE File Offset: 0x01646CAE
		void IDisposable.Dispose()
		{
		}

		// Token: 0x0403F6EA RID: 259818
		[CompilerGenerated]
		private readonly T _item;

		// Token: 0x0403F6EB RID: 259819
		[CompilerGenerated]
		private bool _moveNextCalled;
	}
}
