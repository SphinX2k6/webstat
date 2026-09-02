using System;
using System.Runtime.CompilerServices;

// Token: 0x020000AD RID: 173
[NullableContext(1)]
[Nullable(0)]
public readonly struct EventArgs<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5, [Nullable(2)] T6> : IEventArgs
{
	// Token: 0x06000464 RID: 1124 RVA: 0x00019AEB File Offset: 0x00017CEB
	public EventArgs(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
	{
		this.<p1>P = p1;
		this.<p2>P = p2;
		this.<p3>P = p3;
		this.<p4>P = p4;
		this.<p5>P = p5;
		this.<p6>P = p6;
	}

	// Token: 0x06000465 RID: 1125 RVA: 0x00019B1C File Offset: 0x00017D1C
	public bool Invoke(Enum name, Delegate handle)
	{
		Action<T1, T2, T3, T4, T5, T6> action = handle as Action<T1, T2, T3, T4, T5, T6>;
		if (action != null)
		{
			action(this.<p1>P, this.<p2>P, this.<p3>P, this.<p4>P, this.<p5>P, this.<p6>P);
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action<T1, T2, T3, T4, T5, T6>), handle, name);
				return false;
			}
			genericEventHandler(new object[]
			{
				this.<p1>P,
				this.<p2>P,
				this.<p3>P,
				this.<p4>P,
				this.<p5>P,
				this.<p6>P
			});
		}
		return true;
	}

	// Token: 0x06000466 RID: 1126 RVA: 0x00019BE0 File Offset: 0x00017DE0
	public bool Invoke(long name, Delegate handle)
	{
		Action<T1, T2, T3, T4, T5, T6> action = handle as Action<T1, T2, T3, T4, T5, T6>;
		if (action != null)
		{
			action(this.<p1>P, this.<p2>P, this.<p3>P, this.<p4>P, this.<p5>P, this.<p6>P);
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action<T1, T2, T3, T4, T5, T6>), handle, name);
				return false;
			}
			genericEventHandler(new object[]
			{
				this.<p1>P,
				this.<p2>P,
				this.<p3>P,
				this.<p4>P,
				this.<p5>P,
				this.<p6>P
			});
		}
		return true;
	}

	// Token: 0x040003F7 RID: 1015
	[CompilerGenerated]
	private readonly T1 <p1>P;

	// Token: 0x040003F8 RID: 1016
	[CompilerGenerated]
	private readonly T2 <p2>P;

	// Token: 0x040003F9 RID: 1017
	[CompilerGenerated]
	private readonly T3 <p3>P;

	// Token: 0x040003FA RID: 1018
	[CompilerGenerated]
	private readonly T4 <p4>P;

	// Token: 0x040003FB RID: 1019
	[CompilerGenerated]
	private readonly T5 <p5>P;

	// Token: 0x040003FC RID: 1020
	[CompilerGenerated]
	private readonly T6 <p6>P;
}
