using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Core.Common
{
	// Token: 0x02007153 RID: 29011
	[NullableContext(1)]
	[Nullable(0)]
	public class OrderedSet<[Nullable(2)] T> : ICollection<T>, IEnumerable<!0>, IEnumerable, IReadOnlyCollection<T>
	{
		// Token: 0x1700A609 RID: 42505
		// (get) Token: 0x060463B9 RID: 287673 RVA: 0x01272017 File Offset: 0x01270217
		public int Count
		{
			get
			{
				return this._set.Count;
			}
		}

		// Token: 0x1700A60A RID: 42506
		// (get) Token: 0x060463BA RID: 287674 RVA: 0x01272024 File Offset: 0x01270224
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060463BB RID: 287675 RVA: 0x01272028 File Offset: 0x01270228
		public bool Add(T item)
		{
			if (!this._set.Add(item))
			{
				return false;
			}
			if (this._staleCount > 0 && this._list.IndexOf(item) >= 0)
			{
				this._staleCount--;
				return true;
			}
			this._list.Add(item);
			return true;
		}

		// Token: 0x060463BC RID: 287676 RVA: 0x0127207A File Offset: 0x0127027A
		void ICollection<!0>.Add(T item)
		{
			this.Add(item);
		}

		// Token: 0x060463BD RID: 287677 RVA: 0x01272084 File Offset: 0x01270284
		public bool Remove(T item)
		{
			if (!this._set.Remove(item))
			{
				return false;
			}
			if (this._enumerateDepth == 0)
			{
				this._list.Remove(item);
			}
			else
			{
				this._staleCount++;
			}
			return true;
		}

		// Token: 0x060463BE RID: 287678 RVA: 0x012720BC File Offset: 0x012702BC
		public bool Contains(T item)
		{
			return this._set.Contains(item);
		}

		// Token: 0x060463BF RID: 287679 RVA: 0x012720CA File Offset: 0x012702CA
		public void Clear()
		{
			this._list.Clear();
			this._set.Clear();
			this._staleCount = 0;
		}

		// Token: 0x060463C0 RID: 287680 RVA: 0x012720EC File Offset: 0x012702EC
		public void CopyTo(T[] array, int arrayIndex)
		{
			if (this._staleCount == 0)
			{
				this._list.CopyTo(array, arrayIndex);
				return;
			}
			foreach (T t in this._list)
			{
				if (this._set.Contains(t))
				{
					array[arrayIndex++] = t;
				}
			}
		}

		// Token: 0x060463C1 RID: 287681 RVA: 0x0127216C File Offset: 0x0127036C
		private void CompactIfNeeded()
		{
			if (this._staleCount > 0)
			{
				this._list.RemoveAll((T item) => !this._set.Contains(item));
				this._staleCount = 0;
			}
		}

		// Token: 0x060463C2 RID: 287682 RVA: 0x01272196 File Offset: 0x01270396
		[NullableContext(0)]
		public OrderedSet<T>.Enumerator GetEnumerator()
		{
			return new OrderedSet<T>.Enumerator(this);
		}

		// Token: 0x060463C3 RID: 287683 RVA: 0x0127219E File Offset: 0x0127039E
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			return new OrderedSet<T>.Enumerator(this);
		}

		// Token: 0x060463C4 RID: 287684 RVA: 0x012721AB File Offset: 0x012703AB
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new OrderedSet<T>.Enumerator(this);
		}

		// Token: 0x040275D9 RID: 161241
		private readonly List<T> _list = new List<T>();

		// Token: 0x040275DA RID: 161242
		private readonly HashSet<T> _set = new HashSet<T>();

		// Token: 0x040275DB RID: 161243
		private int _enumerateDepth;

		// Token: 0x040275DC RID: 161244
		private int _staleCount;

		// Token: 0x0200CCE7 RID: 52455
		[Nullable(0)]
		public struct Enumerator : IEnumerator<!0>, IEnumerator, IDisposable
		{
			// Token: 0x0604FC6D RID: 326765 RVA: 0x0163D9EE File Offset: 0x0163BBEE
			internal Enumerator(OrderedSet<T> owner)
			{
				this._owner = owner;
				this._index = 0;
				this._current = default(T);
				this._disposed = false;
				owner._enumerateDepth++;
			}

			// Token: 0x1700AA72 RID: 43634
			// (get) Token: 0x0604FC6E RID: 326766 RVA: 0x0163DA1F File Offset: 0x0163BC1F
			public readonly T Current
			{
				get
				{
					return this._current;
				}
			}

			// Token: 0x1700AA73 RID: 43635
			// (get) Token: 0x0604FC6F RID: 326767 RVA: 0x0163DA27 File Offset: 0x0163BC27
			[Nullable(2)]
			object IEnumerator.Current
			{
				[NullableContext(2)]
				get
				{
					return this.Current;
				}
			}

			// Token: 0x0604FC70 RID: 326768 RVA: 0x0163DA34 File Offset: 0x0163BC34
			public bool MoveNext()
			{
				List<T> list = this._owner._list;
				if (this._owner._staleCount == 0)
				{
					if (this._index < list.Count)
					{
						List<T> list2 = list;
						int index = this._index;
						this._index = index + 1;
						this._current = list2[index];
						return true;
					}
				}
				else
				{
					HashSet<T> set = this._owner._set;
					while (this._index < list.Count)
					{
						List<T> list3 = list;
						int index = this._index;
						this._index = index + 1;
						T t = list3[index];
						if (set.Contains(t))
						{
							this._current = t;
							return true;
						}
					}
				}
				this._current = default(T);
				return false;
			}

			// Token: 0x0604FC71 RID: 326769 RVA: 0x0163DADA File Offset: 0x0163BCDA
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0604FC72 RID: 326770 RVA: 0x0163DAE4 File Offset: 0x0163BCE4
			public void Dispose()
			{
				if (this._disposed || this._owner == null)
				{
					return;
				}
				this._disposed = true;
				this._owner._enumerateDepth--;
				if (this._owner._enumerateDepth == 0)
				{
					this._owner.CompactIfNeeded();
				}
			}

			// Token: 0x0403ED51 RID: 257361
			private readonly OrderedSet<T> _owner;

			// Token: 0x0403ED52 RID: 257362
			private int _index;

			// Token: 0x0403ED53 RID: 257363
			[Nullable(2)]
			private T _current;

			// Token: 0x0403ED54 RID: 257364
			private bool _disposed;
		}
	}
}
