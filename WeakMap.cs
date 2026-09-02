using System;
using System.Runtime;
using System.Runtime.CompilerServices;

// Token: 0x0200007A RID: 122
[NullableContext(1)]
[Nullable(0)]
public class WeakMap<TKey, [Nullable(2)] TValue> where TKey : class
{
	// Token: 0x060002EF RID: 751 RVA: 0x0000FF75 File Offset: 0x0000E175
	public WeakMap()
	{
		this.Buckets = new int[8];
		this.Entries = new WeakMap<TKey, TValue>.Entry[8];
		Array.Fill<int>(this.Buckets, -1);
	}

	// Token: 0x060002F0 RID: 752 RVA: 0x0000FFA8 File Offset: 0x0000E1A8
	protected override void Finalize()
	{
		try
		{
			for (int i = 0; i < this.Count; i++)
			{
				if (this.Entries[i].Handle.IsAllocated)
				{
					this.Entries[i].Handle.Dispose();
				}
			}
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x00010010 File Offset: 0x0000E210
	public void Set(TKey key, TValue value)
	{
		int hashCode = RuntimeHelpers.GetHashCode(key);
		for (int i = this.Buckets[hashCode & this.Buckets.Length - 1]; i >= 0; i = this.Entries[i].Next)
		{
			ref WeakMap<TKey, TValue>.Entry ptr = ref this.Entries[i];
			if (ptr.HashCode == hashCode && ptr.Handle.Target == key)
			{
				ptr.Handle.Dependent = value;
				return;
			}
		}
		int num = this.TakeSlot();
		WeakMap<TKey, TValue>.Entry[] entries = this.Entries;
		int num2 = num;
		entries[num2].HashCode = hashCode;
		entries[num2].Handle = new DependentHandle(key, value);
		int num3 = hashCode & this.Buckets.Length - 1;
		entries[num2].Next = this.Buckets[num3];
		this.Buckets[num3] = num;
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x000100E8 File Offset: 0x0000E2E8
	public bool TryGetValue(TKey key, out TValue value)
	{
		int hashCode = RuntimeHelpers.GetHashCode(key);
		for (int i = this.Buckets[hashCode & this.Buckets.Length - 1]; i >= 0; i = this.Entries[i].Next)
		{
			ref WeakMap<TKey, TValue>.Entry ptr = ref this.Entries[i];
			if (ptr.HashCode == hashCode)
			{
				ValueTuple<object, object> targetAndDependent = ptr.Handle.TargetAndDependent;
				object item = targetAndDependent.Item1;
				object item2 = targetAndDependent.Item2;
				if (item == key)
				{
					value = (TValue)((object)item2);
					return true;
				}
			}
		}
		value = default(TValue);
		return false;
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x0001017C File Offset: 0x0000E37C
	public bool Has(TKey key)
	{
		TValue tvalue;
		return this.TryGetValue(key, out tvalue);
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x00010194 File Offset: 0x0000E394
	public bool Remove(TKey key)
	{
		int hashCode = RuntimeHelpers.GetHashCode(key);
		int num = hashCode & this.Buckets.Length - 1;
		int num2 = -1;
		int next;
		for (int i = this.Buckets[num]; i >= 0; i = next)
		{
			ref WeakMap<TKey, TValue>.Entry ptr = ref this.Entries[i];
			next = ptr.Next;
			if (ptr.HashCode == hashCode && ptr.Handle.Target == key)
			{
				if (num2 < 0)
				{
					this.Buckets[num] = next;
				}
				else
				{
					this.Entries[num2].Next = next;
				}
				ptr.Handle.Dispose();
				ptr.Handle = default(DependentHandle);
				ptr.Next = this.FreeList;
				this.FreeList = i;
				this.FreeCount++;
				return true;
			}
			num2 = i;
		}
		return false;
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x0001026C File Offset: 0x0000E46C
	public void Clear()
	{
		for (int i = 0; i < this.Count; i++)
		{
			ref WeakMap<TKey, TValue>.Entry ptr = ref this.Entries[i];
			if (ptr.Handle.IsAllocated)
			{
				ptr.Handle.Dispose();
				ptr.Handle = default(DependentHandle);
			}
		}
		Array.Fill<int>(this.Buckets, -1);
		this.Count = 0;
		this.FreeList = -1;
		this.FreeCount = 0;
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x000102DC File Offset: 0x0000E4DC
	private int TakeSlot()
	{
		if (this.FreeList < 0 && this.Count >= this.Entries.Length)
		{
			this.Reindex(this.Entries.Length);
			if (this.FreeCount < this.Entries.Length / 4)
			{
				this.Reindex(this.Entries.Length * 2);
			}
		}
		if (this.FreeList >= 0)
		{
			int freeList = this.FreeList;
			this.FreeList = this.Entries[freeList].Next;
			this.FreeCount--;
			return freeList;
		}
		int count = this.Count;
		this.Count = count + 1;
		return count;
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x0001037C File Offset: 0x0000E57C
	private void Reindex(int capacity)
	{
		if (capacity != this.Entries.Length)
		{
			Array.Resize<WeakMap<TKey, TValue>.Entry>(ref this.Entries, capacity);
		}
		this.Buckets = new int[capacity];
		Array.Fill<int>(this.Buckets, -1);
		this.FreeList = -1;
		this.FreeCount = 0;
		for (int i = 0; i < this.Count; i++)
		{
			ref WeakMap<TKey, TValue>.Entry ptr = ref this.Entries[i];
			if (ptr.Handle.IsAllocated && ptr.Handle.Target != null)
			{
				int num = ptr.HashCode & capacity - 1;
				ptr.Next = this.Buckets[num];
				this.Buckets[num] = i;
			}
			else
			{
				if (ptr.Handle.IsAllocated)
				{
					ptr.Handle.Dispose();
					ptr.Handle = default(DependentHandle);
				}
				ptr.Next = this.FreeList;
				this.FreeList = i;
				this.FreeCount++;
			}
		}
	}

	// Token: 0x0400021C RID: 540
	private const int InitialCapacity = 8;

	// Token: 0x0400021D RID: 541
	private int[] Buckets;

	// Token: 0x0400021E RID: 542
	[Nullable(new byte[]
	{
		1,
		0,
		0,
		0
	})]
	private WeakMap<TKey, TValue>.Entry[] Entries;

	// Token: 0x0400021F RID: 543
	private int Count;

	// Token: 0x04000220 RID: 544
	private int FreeList = -1;

	// Token: 0x04000221 RID: 545
	private int FreeCount;

	// Token: 0x02007189 RID: 29065
	[NullableContext(0)]
	private struct Entry
	{
		// Token: 0x040278CE RID: 161998
		public DependentHandle Handle;

		// Token: 0x040278CF RID: 161999
		public int HashCode;

		// Token: 0x040278D0 RID: 162000
		public int Next;
	}
}
