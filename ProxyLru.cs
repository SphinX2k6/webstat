using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200006F RID: 111
[NullableContext(1)]
[Nullable(0)]
public class ProxyLru<[Nullable(2)] TK, TV> where TV : class
{
	// Token: 0x06000285 RID: 645 RVA: 0x0000DC60 File Offset: 0x0000BE60
	public ProxyLru(int capacity, Func<TK, TV> creator, [Nullable(new byte[]
	{
		2,
		1
	})] Action<TV> clearer = null, [Nullable(new byte[]
	{
		2,
		1,
		1
	})] Func<object, object, bool> checker = null)
	{
		this.Lru = new Lru<TK, TV>(capacity, creator, clearer);
		this.Checker = checker;
		this.ProxyEnable = ProxyLruConstants.ProxyLruEnable;
	}

	// Token: 0x17000051 RID: 81
	// (get) Token: 0x06000286 RID: 646 RVA: 0x0000DCB1 File Offset: 0x0000BEB1
	// (set) Token: 0x06000287 RID: 647 RVA: 0x0000DCBE File Offset: 0x0000BEBE
	public bool Enable
	{
		get
		{
			return this.Lru.Enable;
		}
		set
		{
			this.Lru.Enable = value;
		}
	}

	// Token: 0x17000052 RID: 82
	// (get) Token: 0x06000288 RID: 648 RVA: 0x0000DCCC File Offset: 0x0000BECC
	public int Size
	{
		get
		{
			return this.Lru.Size;
		}
	}

	// Token: 0x17000053 RID: 83
	// (get) Token: 0x06000289 RID: 649 RVA: 0x0000DCD9 File Offset: 0x0000BED9
	// (set) Token: 0x0600028A RID: 650 RVA: 0x0000DCE6 File Offset: 0x0000BEE6
	public int Capacity
	{
		get
		{
			return this.Lru.Capacity;
		}
		set
		{
			this.Lru.Capacity = value;
		}
	}

	// Token: 0x17000054 RID: 84
	// (get) Token: 0x0600028B RID: 651 RVA: 0x0000DCF4 File Offset: 0x0000BEF4
	public float HitRate
	{
		get
		{
			return this.Lru.HitRate;
		}
	}

	// Token: 0x17000055 RID: 85
	// (get) Token: 0x0600028C RID: 652 RVA: 0x0000DD01 File Offset: 0x0000BF01
	public float UsedAvg
	{
		get
		{
			return this.Lru.UsedAvg;
		}
	}

	// Token: 0x17000056 RID: 86
	// (get) Token: 0x0600028D RID: 653 RVA: 0x0000DD0E File Offset: 0x0000BF0E
	public float ThresholdUsedRate
	{
		get
		{
			return this.Lru.ThresholdUsedRate;
		}
	}

	// Token: 0x0600028E RID: 654 RVA: 0x0000DD1B File Offset: 0x0000BF1B
	[return: Nullable(2)]
	public TV Create(TK key)
	{
		return this.Lru.Create(key);
	}

	// Token: 0x0600028F RID: 655 RVA: 0x0000DD29 File Offset: 0x0000BF29
	[return: Nullable(2)]
	public TV Get(TK key)
	{
		return this.Lru.Get(key);
	}

	// Token: 0x06000290 RID: 656 RVA: 0x0000DD38 File Offset: 0x0000BF38
	public bool Put(TV value)
	{
		if (!this.ProxyEnable)
		{
			return this.Lru.Put(value);
		}
		IRevocableObject<TK, TV> revocableObject;
		if (!this.RevocableWeakMap.TryGetValue(value, out revocableObject))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Core;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "对象不在维护列表中";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", value);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		Dictionary<object, IRevocable<object>> dictionary;
		if (!this.ProxyToOwnRevocableMap.TryGetValue(value, out dictionary))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Core;
			ELogAuthor author2 = ELogAuthor.LCC;
			string message2 = "对象不存在所属代理表";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("value", value);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		this.ProxyToOwnRevocableMap.Remove(value);
		foreach (IRevocable<object> revocable in dictionary.Values)
		{
			this.ProxyToOwnRevocableMap.Remove(revocable.proxy);
			revocable.Revoke();
		}
		dictionary.Clear();
		revocableObject.Revoke();
		this.RevocableWeakMap.Remove(value);
		return this.Lru.Put(revocableObject.Value);
	}

	// Token: 0x06000291 RID: 657 RVA: 0x0000DE74 File Offset: 0x0000C074
	public void Clear()
	{
		this.Lru.Clear();
	}

	// Token: 0x06000292 RID: 658 RVA: 0x0000DE81 File Offset: 0x0000C081
	public int GetCount(TK key)
	{
		return this.Lru.GetCount(key);
	}

	// Token: 0x040001EA RID: 490
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private readonly Lru<TK, TV> Lru;

	// Token: 0x040001EB RID: 491
	private readonly ConditionalWeakTable<TV, IRevocableObject<TK, TV>> RevocableWeakMap = new ConditionalWeakTable<TV, IRevocableObject<TK, TV>>();

	// Token: 0x040001EC RID: 492
	private readonly ConditionalWeakTable<object, Dictionary<object, IRevocable<object>>> ProxyToOwnRevocableMap = new ConditionalWeakTable<object, Dictionary<object, IRevocable<object>>>();

	// Token: 0x040001ED RID: 493
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private readonly Func<object, object, bool> Checker;

	// Token: 0x040001EE RID: 494
	private readonly bool ProxyEnable = true;
}
