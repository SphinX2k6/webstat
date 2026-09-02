using System;
using System.Runtime.CompilerServices;

// Token: 0x020000A7 RID: 167
public readonly struct EventArgs : IEventArgs
{
	// Token: 0x06000453 RID: 1107 RVA: 0x0001948C File Offset: 0x0001768C
	[NullableContext(1)]
	public bool Invoke(Enum name, Delegate handle)
	{
		Action action = handle as Action;
		if (action != null)
		{
			action();
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action), handle, name);
				return false;
			}
			genericEventHandler(Array.Empty<object>());
		}
		return true;
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x000194D8 File Offset: 0x000176D8
	[NullableContext(1)]
	public bool Invoke(long name, Delegate handle)
	{
		Action action = handle as Action;
		if (action != null)
		{
			action();
		}
		else
		{
			GenericEventHandler genericEventHandler = handle as GenericEventHandler;
			if (genericEventHandler == null)
			{
				EventArgsUtils.CastFail(typeof(Action), handle, name);
				return false;
			}
			genericEventHandler(Array.Empty<object>());
		}
		return true;
	}
}
