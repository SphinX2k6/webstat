using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200005C RID: 92
[NullableContext(1)]
[Nullable(0)]
public class DisjointSet<[Nullable(0)] TKey> where TKey : IEquatable<TKey>
{
	// Token: 0x060001F5 RID: 501 RVA: 0x0000BCE8 File Offset: 0x00009EE8
	private TKey FindRoot(TKey key)
	{
		TKey tkey;
		if (!this.Root.TryGetValue(key, out tkey) || tkey.Equals(key))
		{
			return key;
		}
		tkey = this.FindRoot(tkey);
		this.Root[key] = tkey;
		return tkey;
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x0000BD2D File Offset: 0x00009F2D
	public void Add(TKey key)
	{
		if (!this.Root.ContainsKey(key))
		{
			this.Root[key] = key;
			this.Set[key] = new List<TKey>
			{
				key
			};
		}
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x0000BD64 File Offset: 0x00009F64
	public void Union(TKey key1, TKey key2)
	{
		if (!this.Root.ContainsKey(key1))
		{
			this.Add(key1);
		}
		if (!this.Root.ContainsKey(key2))
		{
			this.Add(key2);
		}
		TKey tkey = this.FindRoot(key1);
		TKey tkey2 = this.FindRoot(key2);
		if (!tkey.Equals(tkey2))
		{
			this.Root[tkey2] = tkey;
			List<TKey> list;
			List<TKey> collection;
			if (this.Set.TryGetValue(tkey, out list) && this.Set.TryGetValue(tkey2, out collection))
			{
				list.AddRange(collection);
				this.Set.Remove(tkey2);
			}
		}
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x0000BDFC File Offset: 0x00009FFC
	public void Delete(TKey key)
	{
		TKey key2 = this.FindRoot(key);
		List<TKey> list;
		if (!this.Set.TryGetValue(key2, out list))
		{
			return;
		}
		if (list.Count <= 2)
		{
			foreach (TKey key3 in list)
			{
				this.Root.Remove(key3);
			}
			this.Set.Remove(key2);
			return;
		}
		if (!key2.Equals(key))
		{
			list.RemoveAt(list.IndexOf(key));
			this.Root.Remove(key);
			return;
		}
		TKey tkey = list[0];
		int num = 0;
		while (num < list.Count && tkey.Equals(key))
		{
			tkey = list[num];
			num++;
		}
		list.RemoveAt(list.IndexOf(key));
		foreach (TKey key4 in list)
		{
			this.Root[key4] = tkey;
		}
		this.Root.Remove(key);
		this.Set.Remove(key2);
		this.Set[tkey] = list;
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x0000BF5C File Offset: 0x0000A15C
	public void DeleteSet(TKey key)
	{
		TKey key2 = this.FindRoot(key);
		List<TKey> list;
		if (this.Set.TryGetValue(key2, out list))
		{
			foreach (TKey key3 in list)
			{
				this.Root.Remove(key3);
			}
			this.Set.Remove(key2);
		}
	}

	// Token: 0x060001FA RID: 506 RVA: 0x0000BFD8 File Offset: 0x0000A1D8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IReadOnlyList<TKey> GetSet(TKey key)
	{
		TKey key2 = this.FindRoot(key);
		List<TKey> list;
		if (!this.Set.TryGetValue(key2, out list))
		{
			return null;
		}
		return list.AsReadOnly();
	}

	// Token: 0x060001FB RID: 507 RVA: 0x0000C005 File Offset: 0x0000A205
	public bool Has(TKey key)
	{
		return this.Root.ContainsKey(key);
	}

	// Token: 0x060001FC RID: 508 RVA: 0x0000C013 File Offset: 0x0000A213
	public void Clear()
	{
		this.Root.Clear();
		this.Set.Clear();
	}

	// Token: 0x040001B2 RID: 434
	private readonly Dictionary<TKey, TKey> Root = new Dictionary<TKey, TKey>();

	// Token: 0x040001B3 RID: 435
	private readonly Dictionary<TKey, List<TKey>> Set = new Dictionary<TKey, List<TKey>>();
}
