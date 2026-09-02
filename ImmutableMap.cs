using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000064 RID: 100
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class ImmutableMap<[Nullable(2)] K, [Nullable(2)] V> : Dictionary<K, V>
{
	// Token: 0x0600023A RID: 570 RVA: 0x0000CA2B File Offset: 0x0000AC2B
	public ImmutableMap<K, V> set(K key, V value)
	{
		this.LogError("set");
		return this;
	}

	// Token: 0x0600023B RID: 571 RVA: 0x0000CA39 File Offset: 0x0000AC39
	public bool delete(K key)
	{
		this.LogError("delete");
		return false;
	}

	// Token: 0x0600023C RID: 572 RVA: 0x0000CA47 File Offset: 0x0000AC47
	public void clear()
	{
		this.LogError("clear");
	}

	// Token: 0x0600023D RID: 573 RVA: 0x0000CA54 File Offset: 0x0000AC54
	public new void Add(K key, V value)
	{
		this.LogError("set");
	}

	// Token: 0x0600023E RID: 574 RVA: 0x0000CA61 File Offset: 0x0000AC61
	public new bool TryAdd(K key, V value)
	{
		this.LogError("set");
		return false;
	}

	// Token: 0x17000041 RID: 65
	public new V this[K key]
	{
		get
		{
			return base[key];
		}
		set
		{
			this.LogError("set");
		}
	}

	// Token: 0x06000241 RID: 577 RVA: 0x0000CA85 File Offset: 0x0000AC85
	public new bool Remove(K key)
	{
		this.LogError("delete");
		return false;
	}

	// Token: 0x06000242 RID: 578 RVA: 0x0000CA93 File Offset: 0x0000AC93
	public new bool Remove(K key, out V value)
	{
		this.LogError("delete");
		value = default(V);
		return false;
	}

	// Token: 0x06000243 RID: 579 RVA: 0x0000CAA8 File Offset: 0x0000ACA8
	public new void Clear()
	{
		this.LogError("clear");
	}

	// Token: 0x06000244 RID: 580 RVA: 0x0000CAB8 File Offset: 0x0000ACB8
	private void LogError(string funcName)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Core;
		ELogAuthor author = ELogAuthor.CYK;
		string message = "ImmutableMap 不允许修改";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("函数名", funcName);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}
}
