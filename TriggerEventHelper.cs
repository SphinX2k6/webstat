using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002FE4 RID: 12260
[NullableContext(1)]
[Nullable(0)]
public class TriggerEventHelper : IStaticVariableResetter
{
	// Token: 0x06018FC7 RID: 102343 RVA: 0x00715E71 File Offset: 0x00714071
	static TriggerEventHelper()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TriggerEventHelper.CreateStaticDefaultValue), new Action(TriggerEventHelper.ResetStaticDefaultValue));
	}

	// Token: 0x17002195 RID: 8597
	// (get) Token: 0x06018FC8 RID: 102344 RVA: 0x00715E90 File Offset: 0x00714090
	private static WeakMap<object, Dictionary<EEventName, Dictionary<Delegate, Action<EEventName, IReadOnlyList<object>>>>> ForwardListenerMapAccessor
	{
		get
		{
			return TriggerEventHelper.ForwardListenerMap;
		}
	}

	// Token: 0x06018FC9 RID: 102345 RVA: 0x00715E97 File Offset: 0x00714097
	public static void CreateStaticDefaultValue()
	{
		TriggerEventHelper.ForwardListenerMap = new WeakMap<object, Dictionary<EEventName, Dictionary<Delegate, Action<EEventName, IReadOnlyList<object>>>>>();
	}

	// Token: 0x06018FCA RID: 102346 RVA: 0x00715EA3 File Offset: 0x007140A3
	public static void ResetStaticDefaultValue()
	{
		TriggerEventHelper.ForwardListenerMap = null;
	}

	// Token: 0x06018FCB RID: 102347 RVA: 0x00715EAC File Offset: 0x007140AC
	public static void AddWithTarget(object entity, EEventName eventName, Delegate listener)
	{
		Singleton<EventSystem>.Instance.AddWithTarget(entity, eventName, listener);
		Action<EEventName, IReadOnlyList<object>> action = delegate(EEventName originalEventName, IReadOnlyList<object> args)
		{
			if (originalEventName != eventName)
			{
				return;
			}
			Delegate listener2 = listener;
			object[] array = args as object[];
			listener2.DynamicInvoke((array != null) ? array : new List<object>(args).ToArray());
		};
		Dictionary<EEventName, Dictionary<Delegate, Action<EEventName, IReadOnlyList<object>>>> dictionary;
		if (!TriggerEventHelper.ForwardListenerMapAccessor.TryGetValue(entity, out dictionary))
		{
			dictionary = new Dictionary<EEventName, Dictionary<Delegate, Action<EEventName, IReadOnlyList<object>>>>();
			TriggerEventHelper.ForwardListenerMapAccessor.Set(entity, dictionary);
		}
		Dictionary<Delegate, Action<EEventName, IReadOnlyList<object>>> dictionary2;
		if (!dictionary.TryGetValue(eventName, out dictionary2))
		{
			dictionary2 = new Dictionary<Delegate, Action<EEventName, IReadOnlyList<object>>>();
			dictionary[eventName] = dictionary2;
		}
		dictionary2[listener] = action;
		Singleton<EventSystem>.Instance.AddWithTarget<EEventName, IReadOnlyList<object>>(entity, EEventName.FollowShooterForwardEvent, action);
	}

	// Token: 0x06018FCC RID: 102348 RVA: 0x00715F54 File Offset: 0x00714154
	public static void RemoveWithTarget(object entity, EEventName eventName, Delegate listener)
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(entity, eventName, listener);
		Dictionary<EEventName, Dictionary<Delegate, Action<EEventName, IReadOnlyList<object>>>> dictionary;
		if (!TriggerEventHelper.ForwardListenerMapAccessor.TryGetValue(entity, out dictionary))
		{
			return;
		}
		Dictionary<Delegate, Action<EEventName, IReadOnlyList<object>>> dictionary2;
		if (!dictionary.TryGetValue(eventName, out dictionary2))
		{
			return;
		}
		Action<EEventName, IReadOnlyList<object>> handle;
		if (!dictionary2.TryGetValue(listener, out handle))
		{
			return;
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget<EEventName, IReadOnlyList<object>>(entity, EEventName.FollowShooterForwardEvent, handle);
		dictionary2.Remove(listener);
		if (dictionary2.Count == 0)
		{
			dictionary.Remove(eventName);
		}
		if (dictionary.Count == 0)
		{
			TriggerEventHelper.ForwardListenerMapAccessor.Remove(entity);
		}
	}

	// Token: 0x06018FCD RID: 102349 RVA: 0x00715FD2 File Offset: 0x007141D2
	public static bool HasWithTarget(object entity, EEventName eventName, Delegate listener)
	{
		return Singleton<EventSystem>.Instance.HasWithTarget(entity, eventName, listener);
	}

	// Token: 0x0400C32F RID: 49967
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1,
		1,
		1,
		1,
		1
	})]
	private static WeakMap<object, Dictionary<EEventName, Dictionary<Delegate, Action<EEventName, IReadOnlyList<object>>>>> ForwardListenerMap;
}
