using System;
using System.Runtime.CompilerServices;

// Token: 0x020000AA RID: 170
[NullableContext(1)]
[Nullable(0)]
public readonly struct EventArgs<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3> : IEventArgs
{
	// Token: 0x0600045B RID: 1115 RVA: 0x000196E3 File Offset: 0x000178E3
	public EventArgs(T1 p1, T2 p2, T3 p3)
	{
		this.<p1>P = p1;
		this.<p2>P = p2;
		this.<p3>P = p3;
	}

	// Token: 0x0600045C RID: 1116 RVA: 0x000196FC File Offset: 0x000178FC
	public bool Invoke(Enum name, Delegate handle)
	{
		Action<T1, T2, T3> action = handle as Action<T1, T2, T3>;
		if (action != null)
		{
			action(this.<p1>P, this.<p2>P, this.<p3>P);
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action<T1, T2, T3>), handle, name);
				return false;
			}
			genericEventHandler(new object[]
			{
				this.<p1>P,
				this.<p2>P,
				this.<p3>P
			});
		}
		return true;
	}

	// Token: 0x0600045D RID: 1117 RVA: 0x00019784 File Offset: 0x00017984
	public bool Invoke(long name, Delegate handle)
	{
		Action<T1, T2, T3> action = handle as Action<T1, T2, T3>;
		if (action != null)
		{
			action(this.<p1>P, this.<p2>P, this.<p3>P);
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action<T1, T2, T3>), handle, name);
				return false;
			}
			genericEventHandler(new object[]
			{
				this.<p1>P,
				this.<p2>P,
				this.<p3>P
			});
		}
		return true;
	}

	// Token: 0x040003EB RID: 1003
	[CompilerGenerated]
	private readonly T1 <p1>P;

	// Token: 0x040003EC RID: 1004
	[CompilerGenerated]
	private readonly T2 <p2>P;

	// Token: 0x040003ED RID: 1005
	[CompilerGenerated]
	private readonly T3 <p3>P;
}
