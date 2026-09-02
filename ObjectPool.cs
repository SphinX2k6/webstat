using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000BCD RID: 3021
[NullableContext(1)]
[Nullable(0)]
public class ObjectPool<[Nullable(0)] T> where T : ObjectBase
{
	// Token: 0x060031A6 RID: 12710 RVA: 0x0001E43C File Offset: 0x0001C63C
	public T Spawn(Func<int, int, T> ctor)
	{
		if (this.PoolInternal.Count == 0)
		{
			throw new InvalidOperationException("Pool is empty");
		}
		T result = this.PoolInternal[this.PoolInternal.Count - 1];
		this.PoolInternal.RemoveAt(this.PoolInternal.Count - 1);
		return result;
	}

	// Token: 0x060031A7 RID: 12711 RVA: 0x0001E491 File Offset: 0x0001C691
	public void DeSpawn(T obj)
	{
		this.PoolInternal.Add(obj);
	}

	// Token: 0x060031A8 RID: 12712 RVA: 0x0001E49F File Offset: 0x0001C69F
	public bool IsEmpty()
	{
		return this.PoolInternal.Count == 0;
	}

	// Token: 0x04000493 RID: 1171
	private readonly List<T> PoolInternal = new List<T>();
}
