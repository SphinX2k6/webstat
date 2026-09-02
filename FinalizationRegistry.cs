using System;
using System.Runtime.CompilerServices;

// Token: 0x02000060 RID: 96
[NullableContext(1)]
[Nullable(0)]
public class FinalizationRegistry<TValue, [Nullable(2)] TParam> where TValue : class
{
	// Token: 0x0600020D RID: 525 RVA: 0x0000C49C File Offset: 0x0000A69C
	[NullableContext(2)]
	public bool Register([Nullable(1)] TValue target, TParam param, string reason, Action<TParam, string> callback)
	{
		Finalizer<TParam> finalizer;
		if (this._Registry.TryGetValue(target, out finalizer))
		{
			finalizer.Dispose();
		}
		Finalizer<TParam> value = new Finalizer<TParam>(param, reason, callback);
		this._Registry.Set(target, value);
		return true;
	}

	// Token: 0x0600020E RID: 526 RVA: 0x0000C4D8 File Offset: 0x0000A6D8
	public bool Unregister(TValue target)
	{
		Finalizer<TParam> finalizer;
		if (!this._Registry.TryGetValue(target, out finalizer))
		{
			return false;
		}
		finalizer.Dispose();
		return this._Registry.Remove(target);
	}

	// Token: 0x040001BD RID: 445
	[Nullable(new byte[]
	{
		1,
		1,
		1,
		2
	})]
	private readonly WeakMap<TValue, Finalizer<TParam>> _Registry = new WeakMap<TValue, Finalizer<TParam>>();
}
