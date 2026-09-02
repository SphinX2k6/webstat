using System;
using System.Runtime.CompilerServices;

// Token: 0x020000AC RID: 172
[NullableContext(1)]
[Nullable(0)]
public readonly struct EventArgs<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5> : IEventArgs
{
	// Token: 0x06000461 RID: 1121 RVA: 0x00019963 File Offset: 0x00017B63
	public EventArgs(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
	{
		this.<p1>P = p1;
		this.<p2>P = p2;
		this.<p3>P = p3;
		this.<p4>P = p4;
		this.<p5>P = p5;
	}

	// Token: 0x06000462 RID: 1122 RVA: 0x0001998C File Offset: 0x00017B8C
	public bool Invoke(Enum name, Delegate handle)
	{
		Action<T1, T2, T3, T4, T5> action = handle as Action<T1, T2, T3, T4, T5>;
		if (action != null)
		{
			action(this.<p1>P, this.<p2>P, this.<p3>P, this.<p4>P, this.<p5>P);
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action<T1, T2, T3, T4, T5>), handle, name);
				return false;
			}
			genericEventHandler(new object[]
			{
				this.<p1>P,
				this.<p2>P,
				this.<p3>P,
				this.<p4>P,
				this.<p5>P
			});
		}
		return true;
	}

	// Token: 0x06000463 RID: 1123 RVA: 0x00019A3C File Offset: 0x00017C3C
	public bool Invoke(long name, Delegate handle)
	{
		Action<T1, T2, T3, T4, T5> action = handle as Action<T1, T2, T3, T4, T5>;
		if (action != null)
		{
			action(this.<p1>P, this.<p2>P, this.<p3>P, this.<p4>P, this.<p5>P);
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action<T1, T2, T3, T4, T5>), handle, name);
				return false;
			}
			genericEventHandler(new object[]
			{
				this.<p1>P,
				this.<p2>P,
				this.<p3>P,
				this.<p4>P,
				this.<p5>P
			});
		}
		return true;
	}

	// Token: 0x040003F2 RID: 1010
	[CompilerGenerated]
	private readonly T1 <p1>P;

	// Token: 0x040003F3 RID: 1011
	[CompilerGenerated]
	private readonly T2 <p2>P;

	// Token: 0x040003F4 RID: 1012
	[CompilerGenerated]
	private readonly T3 <p3>P;

	// Token: 0x040003F5 RID: 1013
	[CompilerGenerated]
	private readonly T4 <p4>P;

	// Token: 0x040003F6 RID: 1014
	[CompilerGenerated]
	private readonly T5 <p5>P;
}
