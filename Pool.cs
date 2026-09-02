using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200006A RID: 106
[NullableContext(1)]
[Nullable(0)]
public class Pool<T> where T : class
{
	// Token: 0x1700004A RID: 74
	// (get) Token: 0x06000266 RID: 614 RVA: 0x0000D483 File Offset: 0x0000B683
	public int Size
	{
		get
		{
			return this.UsedSize + this.UnusedList.Count;
		}
	}

	// Token: 0x06000267 RID: 615 RVA: 0x0000D497 File Offset: 0x0000B697
	public Pool(int capacity, Func<T> creator, [Nullable(new byte[]
	{
		2,
		1
	})] Action<T> clearer = null)
	{
		this.Capacity = capacity;
		this.Creator = creator;
		this.Clearer = clearer;
	}

	// Token: 0x06000268 RID: 616 RVA: 0x0000D4CC File Offset: 0x0000B6CC
	[NullableContext(2)]
	public T Create()
	{
		if (this.Creator == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LCC, "创建器不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return default(T);
		}
		T t = this.Creator();
		if (t == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LCC, "创建器创建值为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return default(T);
		}
		this.UsedSize++;
		this.UsedSet.Add(t);
		return t;
	}

	// Token: 0x06000269 RID: 617 RVA: 0x0000D55C File Offset: 0x0000B75C
	[NullableContext(2)]
	public T Get()
	{
		if (this.UnusedList.Count <= 0)
		{
			return default(T);
		}
		T t = this.UnusedList[this.UnusedList.Count - 1];
		this.UnusedList.RemoveAt(this.UnusedList.Count - 1);
		this.UsedSize++;
		this.UsedSet.Add(t);
		return t;
	}

	// Token: 0x0600026A RID: 618 RVA: 0x0000D5D0 File Offset: 0x0000B7D0
	[NullableContext(2)]
	public bool Put(T value)
	{
		if (value == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Core;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "无效对象";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", value);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (!this.UsedSet.Remove(value))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Pool;
			ELogAuthor author2 = ELogAuthor.LCC;
			string message2 = "非池中对象";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("value", value);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		this.UsedSize--;
		if (this.Size < this.Capacity)
		{
			this.UnusedList.Add(value);
			return true;
		}
		if (this.Clearer != null)
		{
			this.Clearer(value);
		}
		return false;
	}

	// Token: 0x0600026B RID: 619 RVA: 0x0000D68C File Offset: 0x0000B88C
	public void Clear()
	{
		foreach (T obj in this.UnusedList)
		{
			if (this.Clearer != null)
			{
				this.Clearer(obj);
			}
		}
		this.UnusedList.Clear();
		this.UsedSize = 0;
		this.UsedSet.Clear();
	}

	// Token: 0x040001E0 RID: 480
	private readonly List<T> UnusedList = new List<T>();

	// Token: 0x040001E1 RID: 481
	private readonly WeakSet<T> UsedSet = new WeakSet<T>();

	// Token: 0x040001E2 RID: 482
	private int UsedSize;

	// Token: 0x040001E3 RID: 483
	private readonly int Capacity;

	// Token: 0x040001E4 RID: 484
	[Nullable(2)]
	private readonly Func<T> Creator;

	// Token: 0x040001E5 RID: 485
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private readonly Action<T> Clearer;
}
