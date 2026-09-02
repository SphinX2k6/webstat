using System;
using System.Runtime.CompilerServices;

// Token: 0x020000AB RID: 171
[NullableContext(1)]
[Nullable(0)]
public readonly struct EventArgs<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4> : IEventArgs
{
	// Token: 0x0600045E RID: 1118 RVA: 0x0001980B File Offset: 0x00017A0B
	public EventArgs(T1 p1, T2 p2, T3 p3, T4 p4)
	{
		this.<p1>P = p1;
		this.<p2>P = p2;
		this.<p3>P = p3;
		this.<p4>P = p4;
	}

	// Token: 0x0600045F RID: 1119 RVA: 0x0001982C File Offset: 0x00017A2C
	public bool Invoke(Enum name, Delegate handle)
	{
		Action<T1, T2, T3, T4> action = handle as Action<T1, T2, T3, T4>;
		if (action != null)
		{
			action(this.<p1>P, this.<p2>P, this.<p3>P, this.<p4>P);
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action<T1, T2, T3, T4>), handle, name);
				return false;
			}
			genericEventHandler(new object[]
			{
				this.<p1>P,
				this.<p2>P,
				this.<p3>P,
				this.<p4>P
			});
		}
		return true;
	}

	// Token: 0x06000460 RID: 1120 RVA: 0x000198C8 File Offset: 0x00017AC8
	public bool Invoke(long name, Delegate handle)
	{
		Action<T1, T2, T3, T4> action = handle as Action<T1, T2, T3, T4>;
		if (action != null)
		{
			action(this.<p1>P, this.<p2>P, this.<p3>P, this.<p4>P);
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action<T1, T2, T3, T4>), handle, name);
				return false;
			}
			genericEventHandler(new object[]
			{
				this.<p1>P,
				this.<p2>P,
				this.<p3>P,
				this.<p4>P
			});
		}
		return true;
	}

	// Token: 0x040003EE RID: 1006
	[CompilerGenerated]
	private readonly T1 <p1>P;

	// Token: 0x040003EF RID: 1007
	[CompilerGenerated]
	private readonly T2 <p2>P;

	// Token: 0x040003F0 RID: 1008
	[CompilerGenerated]
	private readonly T3 <p3>P;

	// Token: 0x040003F1 RID: 1009
	[CompilerGenerated]
	private readonly T4 <p4>P;
}
