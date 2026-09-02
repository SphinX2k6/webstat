using System;
using System.Runtime.CompilerServices;

// Token: 0x020000AE RID: 174
[NullableContext(1)]
[Nullable(0)]
public readonly struct EventArgs<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5, [Nullable(2)] T6, [Nullable(2)] T7> : IEventArgs
{
	// Token: 0x06000467 RID: 1127 RVA: 0x00019CA3 File Offset: 0x00017EA3
	public EventArgs(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
	{
		this.<p1>P = p1;
		this.<p2>P = p2;
		this.<p3>P = p3;
		this.<p4>P = p4;
		this.<p5>P = p5;
		this.<p6>P = p6;
		this.<p7>P = p7;
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x00019CDC File Offset: 0x00017EDC
	public bool Invoke(Enum name, Delegate handle)
	{
		Action<T1, T2, T3, T4, T5, T6, T7> action = handle as Action<T1, T2, T3, T4, T5, T6, T7>;
		if (action != null)
		{
			action(this.<p1>P, this.<p2>P, this.<p3>P, this.<p4>P, this.<p5>P, this.<p6>P, this.<p7>P);
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action<T1, T2, T3, T4, T5, T6, T7>), handle, name);
				return false;
			}
			genericEventHandler(new object[]
			{
				this.<p1>P,
				this.<p2>P,
				this.<p3>P,
				this.<p4>P,
				this.<p5>P,
				this.<p6>P,
				this.<p7>P
			});
		}
		return true;
	}

	// Token: 0x06000469 RID: 1129 RVA: 0x00019DB8 File Offset: 0x00017FB8
	public bool Invoke(long name, Delegate handle)
	{
		Action<T1, T2, T3, T4, T5, T6, T7> action = handle as Action<T1, T2, T3, T4, T5, T6, T7>;
		if (action != null)
		{
			action(this.<p1>P, this.<p2>P, this.<p3>P, this.<p4>P, this.<p5>P, this.<p6>P, this.<p7>P);
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action<T1, T2, T3, T4, T5, T6, T7>), handle, name);
				return false;
			}
			genericEventHandler(new object[]
			{
				this.<p1>P,
				this.<p2>P,
				this.<p3>P,
				this.<p4>P,
				this.<p5>P,
				this.<p6>P,
				this.<p7>P
			});
		}
		return true;
	}

	// Token: 0x040003FD RID: 1021
	[CompilerGenerated]
	private readonly T1 <p1>P;

	// Token: 0x040003FE RID: 1022
	[CompilerGenerated]
	private readonly T2 <p2>P;

	// Token: 0x040003FF RID: 1023
	[CompilerGenerated]
	private readonly T3 <p3>P;

	// Token: 0x04000400 RID: 1024
	[CompilerGenerated]
	private readonly T4 <p4>P;

	// Token: 0x04000401 RID: 1025
	[CompilerGenerated]
	private readonly T5 <p5>P;

	// Token: 0x04000402 RID: 1026
	[CompilerGenerated]
	private readonly T6 <p6>P;

	// Token: 0x04000403 RID: 1027
	[CompilerGenerated]
	private readonly T7 <p7>P;
}
