using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002E0B RID: 11787
[NullableContext(1)]
[Nullable(0)]
public class SimplePool<[Nullable(2)] T>
{
	// Token: 0x06017D27 RID: 97575 RVA: 0x006A4FA8 File Offset: 0x006A31A8
	[NullableContext(2)]
	public T Get()
	{
		if (this.UnusedList.Count <= 0)
		{
			return default(T);
		}
		T result = this.UnusedList[this.UnusedList.Count - 1];
		this.UnusedList.RemoveAt(this.UnusedList.Count - 1);
		return result;
	}

	// Token: 0x06017D28 RID: 97576 RVA: 0x006A5000 File Offset: 0x006A3200
	public void PreloadAdd(T target)
	{
		if (target == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Pool;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "无效对象";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("target", target);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.UnusedList.Add(target);
	}

	// Token: 0x06017D29 RID: 97577 RVA: 0x006A5050 File Offset: 0x006A3250
	public void Release(T target)
	{
		if (target == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Pool;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "无效对象";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("target", target);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.UnusedList.Add(target);
	}

	// Token: 0x06017D2A RID: 97578 RVA: 0x006A509D File Offset: 0x006A329D
	public void Clear()
	{
		this.UnusedList.Clear();
	}

	// Token: 0x0400B8DC RID: 47324
	private readonly List<T> UnusedList = new List<T>();
}
