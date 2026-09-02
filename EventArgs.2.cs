using System;
using System.Runtime.CompilerServices;

// Token: 0x020000A8 RID: 168
[NullableContext(1)]
[Nullable(0)]
public readonly struct EventArgs<[Nullable(2)] T1> : IEventArgs
{
	// Token: 0x06000455 RID: 1109 RVA: 0x00019522 File Offset: 0x00017722
	public EventArgs(T1 p1)
	{
		this.<p1>P = p1;
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x0001952C File Offset: 0x0001772C
	public bool Invoke(Enum name, Delegate handle)
	{
		Action<T1> action = handle as Action<T1>;
		if (action != null)
		{
			action(this.<p1>P);
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action<T1>), handle, name);
				return false;
			}
			genericEventHandler(new object[]
			{
				this.<p1>P
			});
		}
		return true;
	}

	// Token: 0x06000457 RID: 1111 RVA: 0x0001958C File Offset: 0x0001778C
	public bool Invoke(long name, Delegate handle)
	{
		Action<T1> action = handle as Action<T1>;
		if (action != null)
		{
			action(this.<p1>P);
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action<T1>), handle, name);
				return false;
			}
			genericEventHandler(new object[]
			{
				this.<p1>P
			});
		}
		return true;
	}

	// Token: 0x040003E8 RID: 1000
	[CompilerGenerated]
	private readonly T1 <p1>P;
}
