using System;
using System.Runtime.CompilerServices;

// Token: 0x020000A9 RID: 169
[NullableContext(1)]
[Nullable(0)]
public readonly struct EventArgs<[Nullable(2)] T1, [Nullable(2)] T2> : IEventArgs
{
	// Token: 0x06000458 RID: 1112 RVA: 0x000195EB File Offset: 0x000177EB
	public EventArgs(T1 p1, T2 p2)
	{
		this.<p1>P = p1;
		this.<p2>P = p2;
	}

	// Token: 0x06000459 RID: 1113 RVA: 0x000195FC File Offset: 0x000177FC
	public bool Invoke(Enum name, Delegate handle)
	{
		Action<T1, T2> action = handle as Action<T1, T2>;
		if (action != null)
		{
			action(this.<p1>P, this.<p2>P);
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action<T1, T2>), handle, name);
				return false;
			}
			genericEventHandler(new object[]
			{
				this.<p1>P,
				this.<p2>P
			});
		}
		return true;
	}

	// Token: 0x0600045A RID: 1114 RVA: 0x00019670 File Offset: 0x00017870
	public bool Invoke(long name, Delegate handle)
	{
		Action<T1, T2> action = handle as Action<T1, T2>;
		if (action != null)
		{
			action(this.<p1>P, this.<p2>P);
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action<T1, T2>), handle, name);
				return false;
			}
			genericEventHandler(new object[]
			{
				this.<p1>P,
				this.<p2>P
			});
		}
		return true;
	}

	// Token: 0x040003E9 RID: 1001
	[CompilerGenerated]
	private readonly T1 <p1>P;

	// Token: 0x040003EA RID: 1002
	[CompilerGenerated]
	private readonly T2 <p2>P;
}
