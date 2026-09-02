using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000070 RID: 112
[NullableContext(1)]
[Nullable(0)]
public class ProxyLruMap<[Nullable(2)] TC, [Nullable(2)] TK, TV> : IEnumerable<TC>, IEnumerable where TV : class
{
	// Token: 0x06000293 RID: 659 RVA: 0x0000DE8F File Offset: 0x0000C08F
	public ProxyLruMap([Nullable(new byte[]
	{
		2,
		1
	})] Action<TC> callback = null)
	{
		this.Callback = callback;
	}

	// Token: 0x06000294 RID: 660 RVA: 0x0000DEAC File Offset: 0x0000C0AC
	public void Add(TC category, int capacity, Func<TK, TV> creator, [Nullable(new byte[]
	{
		2,
		1
	})] Action<TV> clearer = null)
	{
		if (this.Table.ContainsKey(category))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Core;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "池中已存在该种类";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("category", category);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.Table[category] = new ProxyLru<TK, TV>(capacity, creator, clearer, null);
	}

	// Token: 0x06000295 RID: 661 RVA: 0x0000DF08 File Offset: 0x0000C108
	public void Remove(TC category)
	{
		ProxyLru<TK, TV> category2 = this.GetCategory(category);
		if (category2 == null)
		{
			return;
		}
		this.Table.Remove(category);
		category2.Clear();
		if (this.Callback != null)
		{
			this.Callback(category);
		}
	}

	// Token: 0x06000296 RID: 662 RVA: 0x0000DF48 File Offset: 0x0000C148
	[return: Nullable(2)]
	public TV Create(TC category, TK key)
	{
		ProxyLru<TK, TV> category2 = this.GetCategory(category);
		if (category2 == null)
		{
			return default(TV);
		}
		return category2.Create(key);
	}

	// Token: 0x06000297 RID: 663 RVA: 0x0000DF70 File Offset: 0x0000C170
	[return: Nullable(2)]
	public TV Get(TC category, TK key)
	{
		ProxyLru<TK, TV> category2 = this.GetCategory(category);
		if (category2 == null)
		{
			return default(TV);
		}
		return category2.Get(key);
	}

	// Token: 0x06000298 RID: 664 RVA: 0x0000DF98 File Offset: 0x0000C198
	public void Put(TC category, TV value)
	{
		ProxyLru<TK, TV> category2 = this.GetCategory(category);
		if (category2 != null && category2.Put(value) && this.Callback != null)
		{
			this.Callback(category);
		}
	}

	// Token: 0x06000299 RID: 665 RVA: 0x0000DFD0 File Offset: 0x0000C1D0
	public bool GetEnable(TC category)
	{
		ProxyLru<TK, TV> category2 = this.GetCategory(category);
		return category2 != null && category2.Enable;
	}

	// Token: 0x0600029A RID: 666 RVA: 0x0000DFF0 File Offset: 0x0000C1F0
	public void SetEnable(TC category, bool value)
	{
		ProxyLru<TK, TV> category2 = this.GetCategory(category);
		if (category2 != null)
		{
			category2.Enable = value;
		}
	}

	// Token: 0x0600029B RID: 667 RVA: 0x0000E010 File Offset: 0x0000C210
	public int GetSize(TC category)
	{
		ProxyLru<TK, TV> category2 = this.GetCategory(category);
		if (category2 == null)
		{
			return 0;
		}
		return category2.Size;
	}

	// Token: 0x0600029C RID: 668 RVA: 0x0000E030 File Offset: 0x0000C230
	public int GetCapacity(TC category)
	{
		ProxyLru<TK, TV> category2 = this.GetCategory(category);
		if (category2 == null)
		{
			return 0;
		}
		return category2.Capacity;
	}

	// Token: 0x0600029D RID: 669 RVA: 0x0000E050 File Offset: 0x0000C250
	public void SetCapacity(TC category, int value)
	{
		ProxyLru<TK, TV> category2 = this.GetCategory(category);
		if (category2 != null)
		{
			category2.Capacity = value;
		}
	}

	// Token: 0x0600029E RID: 670 RVA: 0x0000E070 File Offset: 0x0000C270
	public float GetHitRate(TC category)
	{
		ProxyLru<TK, TV> category2 = this.GetCategory(category);
		if (category2 == null)
		{
			return 0f;
		}
		return category2.HitRate;
	}

	// Token: 0x0600029F RID: 671 RVA: 0x0000E094 File Offset: 0x0000C294
	public float GetUsedAvg(TC category)
	{
		ProxyLru<TK, TV> category2 = this.GetCategory(category);
		if (category2 == null)
		{
			return 0f;
		}
		return category2.UsedAvg;
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x0000E0B8 File Offset: 0x0000C2B8
	public float GetThresholdUsedRate(TC category)
	{
		ProxyLru<TK, TV> category2 = this.GetCategory(category);
		if (category2 == null)
		{
			return 0f;
		}
		return category2.ThresholdUsedRate;
	}

	// Token: 0x060002A1 RID: 673 RVA: 0x0000E0DC File Offset: 0x0000C2DC
	public IEnumerator<TC> GetEnumerator()
	{
		return this.Table.Keys.GetEnumerator();
	}

	// Token: 0x060002A2 RID: 674 RVA: 0x0000E0F3 File Offset: 0x0000C2F3
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x060002A3 RID: 675 RVA: 0x0000E0FC File Offset: 0x0000C2FC
	[return: Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private ProxyLru<TK, TV> GetCategory(TC category)
	{
		ProxyLru<TK, TV> result;
		if (!this.Table.TryGetValue(category, out result))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Core;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "池中不存在该种类";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("category", category);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return result;
	}

	// Token: 0x040001EF RID: 495
	private readonly Dictionary<TC, ProxyLru<TK, TV>> Table = new Dictionary<TC, ProxyLru<TK, TV>>();

	// Token: 0x040001F0 RID: 496
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private readonly Action<TC> Callback;
}
