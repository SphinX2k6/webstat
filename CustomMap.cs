using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200348E RID: 13454
[NullableContext(1)]
[Nullable(0)]
public class CustomMap<[Nullable(2)] TKey, [Nullable(2)] TValue>
{
	// Token: 0x0601C623 RID: 116259 RVA: 0x008819A1 File Offset: 0x0087FBA1
	public int Size()
	{
		return this.Key2Index.Count;
	}

	// Token: 0x0601C624 RID: 116260 RVA: 0x008819B0 File Offset: 0x0087FBB0
	public void Set(TKey key, TValue value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value", "Value cannot be null");
		}
		int count;
		if (this.Key2Index.TryGetValue(key, out count))
		{
			this.List[count] = value;
			return;
		}
		count = this.Key2Index.Count;
		this.Key2Index[key] = count;
		this.List.Add(value);
		this.Index2Key[count] = key;
	}

	// Token: 0x0601C625 RID: 116261 RVA: 0x00881A28 File Offset: 0x0087FC28
	public TValue Get(TKey key)
	{
		int index;
		if (this.Key2Index.TryGetValue(key, out index))
		{
			return this.List[index];
		}
		return default(TValue);
	}

	// Token: 0x0601C626 RID: 116262 RVA: 0x00881A5C File Offset: 0x0087FC5C
	public bool TryGetValue(TKey key, [Nullable(2)] out TValue value)
	{
		int index;
		if (this.Key2Index.TryGetValue(key, out index))
		{
			value = this.List[index];
			return true;
		}
		value = default(TValue);
		return false;
	}

	// Token: 0x0601C627 RID: 116263 RVA: 0x00881A98 File Offset: 0x0087FC98
	public TValue GetByIndex(int index)
	{
		TKey key;
		if (this.Index2Key.TryGetValue(index, out key))
		{
			return this.Get(key);
		}
		return default(TValue);
	}

	// Token: 0x0601C628 RID: 116264 RVA: 0x00881AC6 File Offset: 0x0087FCC6
	public bool Contains(TKey key)
	{
		return this.Key2Index.ContainsKey(key);
	}

	// Token: 0x0601C629 RID: 116265 RVA: 0x00881AD4 File Offset: 0x0087FCD4
	public bool Remove(TKey key)
	{
		int num;
		if (!this.Key2Index.Remove(key, out num))
		{
			return false;
		}
		this.Index2Key.Remove(num);
		if (this.List.Count > 1)
		{
			int num2 = this.List.Count - 1;
			TKey tkey;
			if (this.Index2Key.Remove(num2, out tkey))
			{
				this.Key2Index[tkey] = num;
				this.Index2Key[num] = tkey;
			}
			this.List[num] = this.List[num2];
			this.List.RemoveAt(num2);
		}
		else
		{
			this.List.Clear();
		}
		return true;
	}

	// Token: 0x0601C62A RID: 116266 RVA: 0x00881B78 File Offset: 0x0087FD78
	public bool Remove(TKey key, [Nullable(2)] out TValue value)
	{
		int num;
		if (!this.Key2Index.Remove(key, out num))
		{
			value = default(TValue);
			return false;
		}
		value = this.List[num];
		this.Index2Key.Remove(num);
		if (this.List.Count > 1)
		{
			int num2 = this.List.Count - 1;
			TKey tkey;
			if (this.Index2Key.Remove(num2, out tkey))
			{
				this.Key2Index[tkey] = num;
				this.Index2Key[num] = tkey;
			}
			this.List[num] = this.List[num2];
			this.List.RemoveAt(num2);
		}
		else
		{
			this.List.Clear();
		}
		return true;
	}

	// Token: 0x0601C62B RID: 116267 RVA: 0x00881C38 File Offset: 0x0087FE38
	public bool RemoveByIndex(int index)
	{
		TKey key;
		return this.Index2Key.TryGetValue(index, out key) && this.Remove(key);
	}

	// Token: 0x0601C62C RID: 116268 RVA: 0x00881C5E File Offset: 0x0087FE5E
	public IEnumerable<TKey> Keys()
	{
		return this.Key2Index.Keys;
	}

	// Token: 0x0601C62D RID: 116269 RVA: 0x00881C6B File Offset: 0x0087FE6B
	public IReadOnlyList<TValue> GetItems()
	{
		return this.List;
	}

	// Token: 0x0601C62E RID: 116270 RVA: 0x00881C73 File Offset: 0x0087FE73
	public void Clear()
	{
		this.Key2Index.Clear();
		this.Index2Key.Clear();
		this.List.Clear();
	}

	// Token: 0x0400E458 RID: 58456
	private readonly Dictionary<TKey, int> Key2Index = new Dictionary<TKey, int>();

	// Token: 0x0400E459 RID: 58457
	private readonly List<TValue> List = new List<TValue>();

	// Token: 0x0400E45A RID: 58458
	private readonly Dictionary<int, TKey> Index2Key = new Dictionary<int, TKey>();
}
