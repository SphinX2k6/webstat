using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

// Token: 0x02000BAB RID: 2987
[NullableContext(1)]
[Nullable(0)]
public class NumberEvent : IStaticVariableResetter
{
	// Token: 0x0600305E RID: 12382 RVA: 0x0001A107 File Offset: 0x00018307
	static NumberEvent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(NumberEvent.CreateStaticDefaultValue), new Action(NumberEvent.ResetStaticDefaultValue));
	}

	// Token: 0x1700008E RID: 142
	// (get) Token: 0x0600305F RID: 12383 RVA: 0x0001A126 File Offset: 0x00018326
	private static Dictionary<string, Stat> NameStateMap
	{
		get
		{
			return NumberEvent._nameStateMap;
		}
	}

	// Token: 0x1700008F RID: 143
	// (get) Token: 0x06003060 RID: 12384 RVA: 0x0001A12D File Offset: 0x0001832D
	private static Dictionary<MethodInfo, Stat> HandleStatMap
	{
		get
		{
			return NumberEvent._handleStatMap;
		}
	}

	// Token: 0x06003061 RID: 12385 RVA: 0x0001A134 File Offset: 0x00018334
	private void AddHoldKeyValueToMapInternal(long name, object holdKey, object objectKey, Dictionary<long, Dictionary<object, object>> keyMap)
	{
		Dictionary<object, object> dictionary;
		if (!keyMap.TryGetValue(name, out dictionary))
		{
			dictionary = new Dictionary<object, object>();
			keyMap[name] = dictionary;
		}
		dictionary[objectKey] = holdKey;
	}

	// Token: 0x06003062 RID: 12386 RVA: 0x0001A164 File Offset: 0x00018364
	private void RemoveHoldKeyValueFromMapInternal(long name, object holdKey, Dictionary<long, Dictionary<object, object>> keyMap)
	{
		Dictionary<object, object> dictionary;
		if (!keyMap.TryGetValue(name, out dictionary))
		{
			return;
		}
		dictionary.Remove(holdKey);
		if (dictionary.Count == 0)
		{
			keyMap.Remove(name);
		}
	}

	// Token: 0x06003063 RID: 12387 RVA: 0x0001A198 File Offset: 0x00018398
	[return: Nullable(2)]
	private object GetHoldKeyValueOfMapInternal(long name, object holdKey, Dictionary<long, Dictionary<object, object>> keyMap)
	{
		Dictionary<object, object> dictionary;
		if (!keyMap.TryGetValue(name, out dictionary))
		{
			return null;
		}
		return dictionary.GetValueOrDefault(holdKey);
	}

	// Token: 0x06003064 RID: 12388 RVA: 0x0001A1B9 File Offset: 0x000183B9
	public void AddHoldKeyHandle(long name, object objectKey, object handle)
	{
		this.AddHoldKeyValueToMapInternal(name, handle, objectKey, this.HoldKeyHandles);
	}

	// Token: 0x06003065 RID: 12389 RVA: 0x0001A1CA File Offset: 0x000183CA
	public void RemoveHoldKeyHandle(long name, object handle)
	{
		this.RemoveHoldKeyValueFromMapInternal(name, handle, this.HoldKeyHandles);
	}

	// Token: 0x06003066 RID: 12390 RVA: 0x0001A1DA File Offset: 0x000183DA
	[return: Nullable(2)]
	public object GetHoldKeyByHandle(long name, object handle)
	{
		return this.GetHoldKeyValueOfMapInternal(name, handle, this.HoldKeyHandles);
	}

	// Token: 0x06003067 RID: 12391 RVA: 0x0001A1EC File Offset: 0x000183EC
	public bool Has(long name, Delegate handle)
	{
		Dictionary<Delegate, NumberEvent.EHandleType> dictionary;
		if (this.Handles.TryGetValue(name, out dictionary) && dictionary.ContainsKey(handle))
		{
			HashSet<Delegate> hashSet;
			return !this.PendingRemoveHandles.TryGetValue(name, out hashSet) || !hashSet.Contains(handle);
		}
		Dictionary<Delegate, NumberEvent.EHandleType> dictionary2;
		return this.PendingAddHandles.TryGetValue(name, out dictionary2) && dictionary2.ContainsKey(handle);
	}

	// Token: 0x06003068 RID: 12392 RVA: 0x0001A248 File Offset: 0x00018448
	public bool HasAny(long name)
	{
		return this.Handles.ContainsKey(name) || this.PendingAddHandles.ContainsKey(name);
	}

	// Token: 0x06003069 RID: 12393 RVA: 0x0001A266 File Offset: 0x00018466
	public bool Add(long name, Delegate handle)
	{
		return this.AddInternal(name, handle, NumberEvent.EHandleType.Forever);
	}

	// Token: 0x0600306A RID: 12394 RVA: 0x0001A271 File Offset: 0x00018471
	public bool Once(long name, Delegate handle)
	{
		return this.AddInternal(name, handle, NumberEvent.EHandleType.Once);
	}

	// Token: 0x0600306B RID: 12395 RVA: 0x0001A27C File Offset: 0x0001847C
	public bool Remove(long name, Delegate handle)
	{
		return this.IsRegistered(name, handle) && this.RemoveInternal(name, handle);
	}

	// Token: 0x0600306C RID: 12396 RVA: 0x0001A294 File Offset: 0x00018494
	private bool IsRegistered(long name, Delegate handle)
	{
		Dictionary<Delegate, NumberEvent.EHandleType> dictionary;
		Dictionary<Delegate, NumberEvent.EHandleType> dictionary2;
		return (this.Handles.TryGetValue(name, out dictionary) && dictionary.ContainsKey(handle)) || (this.PendingAddHandlesInternal != null && this.PendingAddHandlesInternal.TryGetValue(name, out dictionary2) && dictionary2.ContainsKey(handle));
	}

	// Token: 0x0600306D RID: 12397 RVA: 0x0001A2E0 File Offset: 0x000184E0
	public bool ClearObject(long name)
	{
		Dictionary<Delegate, NumberEvent.EHandleType> dictionary;
		if (!this.Handles.TryGetValue(name, out dictionary))
		{
			return true;
		}
		foreach (Delegate handle in dictionary.Keys)
		{
			this.RemoveInternal(name, handle);
		}
		return true;
	}

	// Token: 0x0600306E RID: 12398 RVA: 0x0001A348 File Offset: 0x00018548
	public bool Emit(long name)
	{
		return this.EmitInternal(name, default(EventArgs));
	}

	// Token: 0x0600306F RID: 12399 RVA: 0x0001A36A File Offset: 0x0001856A
	public bool Emit<[Nullable(2)] T1>(long name, T1 p1)
	{
		return this.EmitInternal(name, new EventArgs<T1>(p1));
	}

	// Token: 0x06003070 RID: 12400 RVA: 0x0001A37E File Offset: 0x0001857E
	public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2>(long name, T1 p1, T2 p2)
	{
		return this.EmitInternal(name, new EventArgs<T1, T2>(p1, p2));
	}

	// Token: 0x06003071 RID: 12401 RVA: 0x0001A393 File Offset: 0x00018593
	public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3>(long name, T1 p1, T2 p2, T3 p3)
	{
		return this.EmitInternal(name, new EventArgs<T1, T2, T3>(p1, p2, p3));
	}

	// Token: 0x06003072 RID: 12402 RVA: 0x0001A3AA File Offset: 0x000185AA
	public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4>(long name, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		return this.EmitInternal(name, new EventArgs<T1, T2, T3, T4>(p1, p2, p3, p4));
	}

	// Token: 0x06003073 RID: 12403 RVA: 0x0001A3C3 File Offset: 0x000185C3
	public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5>(long name, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
	{
		return this.EmitInternal(name, new EventArgs<T1, T2, T3, T4, T5>(p1, p2, p3, p4, p5));
	}

	// Token: 0x06003074 RID: 12404 RVA: 0x0001A3E0 File Offset: 0x000185E0
	private unsafe bool EmitInternal(long name, IEventArgs args)
	{
		if (this.IsEmitting(name))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Event;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "事件重复派发，请检查事件链是否产生循环调用";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("name", name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("emittingEventInSet", this.EmittingMaskSet);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		this.SetEmitting(name, true);
		Dictionary<Delegate, NumberEvent.EHandleType> dictionary;
		if (this.Handles.TryGetValue(name, out dictionary))
		{
			Stat value = null;
			if (Stat.Enable)
			{
				string key = name.ToString();
				if (!NumberEvent.NameStateMap.TryGetValue(key, out value))
				{
					NumberEvent.NameStateMap[key] = value;
				}
			}
			HashSet<Delegate> hashSet = null;
			foreach (KeyValuePair<Delegate, NumberEvent.EHandleType> keyValuePair in dictionary)
			{
				Delegate key2 = keyValuePair.Key;
				if (hashSet == null)
				{
					this.PendingRemoveHandles.TryGetValue(name, out hashSet);
				}
				if (hashSet == null || !hashSet.Contains(key2))
				{
					if (keyValuePair.Value == NumberEvent.EHandleType.Once)
					{
						this.RemoveInternal(name, key2);
					}
					Stat stat = null;
					if (Stat.Enable)
					{
						NumberEvent.HandleStatMap.TryGetValue(key2.Method, out stat);
					}
					try
					{
						args.Invoke(name, key2);
					}
					catch (Exception ex) when (1)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Event;
						ELogAuthor author2 = ELogAuthor.LCC;
						string message2 = "事件处理方法执行异常";
						Exception error = ex;
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("name", name);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("error", ex.Message);
						instance2.ErrorWithStack(module2, author2, message2, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					}
				}
			}
		}
		this.SetEmitting(name, false);
		HashSet<Delegate> hashSet2;
		if (this.PendingRemoveHandles.TryGetValue(name, out hashSet2))
		{
			foreach (Delegate handle in hashSet2)
			{
				this.DoRemove(name, handle);
			}
			hashSet2.Clear();
			this.PendingRemoveHandles.Remove(name);
		}
		Dictionary<Delegate, NumberEvent.EHandleType> dictionary2;
		if (this.PendingAddHandles.TryGetValue(name, out dictionary2))
		{
			foreach (KeyValuePair<Delegate, NumberEvent.EHandleType> keyValuePair2 in dictionary2)
			{
				this.DoAdd(name, keyValuePair2.Key, keyValuePair2.Value);
			}
			dictionary2.Clear();
			this.PendingAddHandles.Remove(name);
		}
		return true;
	}

	// Token: 0x06003075 RID: 12405 RVA: 0x0001A6B4 File Offset: 0x000188B4
	private bool AddInternal(long name, Delegate handle, NumberEvent.EHandleType handleType)
	{
		NumberEvent.SetupHandleStat(handle);
		if (!this.IsEmitting(name))
		{
			return this.DoAdd(name, handle, handleType);
		}
		Dictionary<Delegate, NumberEvent.EHandleType> dictionary;
		if (this.Handles.TryGetValue(name, out dictionary) && dictionary.ContainsKey(handle))
		{
			HashSet<Delegate> hashSet;
			if (!this.PendingRemoveHandles.TryGetValue(name, out hashSet) || !hashSet.Contains(handle))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.LCC;
				string message = "事件已存在，请检查同一个事件名同一个处理函数的注册逻辑";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			hashSet.Remove(handle);
			return true;
		}
		else
		{
			Dictionary<Delegate, NumberEvent.EHandleType> dictionary2;
			if (this.PendingAddHandles.TryGetValue(name, out dictionary2) && dictionary2.ContainsKey(handle))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Event;
				ELogAuthor author2 = ELogAuthor.LCC;
				string message2 = "事件重复注册在待修改列表，请检查同一个事件名同一个处理函数的注册逻辑";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("name", name);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			if (dictionary2 == null)
			{
				dictionary2 = new Dictionary<Delegate, NumberEvent.EHandleType>();
				this.PendingAddHandles[name] = dictionary2;
			}
			dictionary2[handle] = handleType;
			return true;
		}
	}

	// Token: 0x06003076 RID: 12406 RVA: 0x0001A7AC File Offset: 0x000189AC
	private static void SetupHandleStat(Delegate handle)
	{
		if (!Stat.Enable)
		{
			return;
		}
		MethodInfo method = handle.Method;
		if (NumberEvent.HandleStatMap.ContainsKey(method))
		{
			return;
		}
		string name = method.Name;
		Stat value = null;
		string.IsNullOrEmpty(name);
		NumberEvent.HandleStatMap[method] = value;
	}

	// Token: 0x06003077 RID: 12407 RVA: 0x0001A7F0 File Offset: 0x000189F0
	private bool DoAdd(long name, Delegate handle, NumberEvent.EHandleType handleType)
	{
		Dictionary<Delegate, NumberEvent.EHandleType> dictionary;
		if (!this.Handles.TryGetValue(name, out dictionary))
		{
			dictionary = new Dictionary<Delegate, NumberEvent.EHandleType>();
			this.Handles[name] = dictionary;
		}
		else if (dictionary.ContainsKey(handle))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Event;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "事件重复注册，请检查同一个事件名同一个处理函数的注册逻辑";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		dictionary[handle] = handleType;
		return true;
	}

	// Token: 0x06003078 RID: 12408 RVA: 0x0001A864 File Offset: 0x00018A64
	private bool RemoveInternal(long name, Delegate handle)
	{
		if (!this.IsEmitting(name))
		{
			return this.DoRemove(name, handle);
		}
		Dictionary<Delegate, NumberEvent.EHandleType> dictionary;
		if (!this.Handles.TryGetValue(name, out dictionary) || !dictionary.ContainsKey(handle))
		{
			Dictionary<Delegate, NumberEvent.EHandleType> dictionary2;
			if (!this.PendingAddHandles.TryGetValue(name, out dictionary2) || !dictionary2.ContainsKey(handle))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.LCC;
				string message = "事件不存在，请检查同一个事件名同一个处理函数的移除逻辑";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			dictionary2.Remove(handle);
			return true;
		}
		else
		{
			HashSet<Delegate> hashSet;
			if (this.PendingRemoveHandles.TryGetValue(name, out hashSet) && hashSet.Contains(handle))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Event;
				ELogAuthor author2 = ELogAuthor.LCC;
				string message2 = "事件重复移除在待移除列表，请检查同一个事件名同一个处理函数的移除逻辑";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("name", name);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			if (hashSet == null)
			{
				hashSet = new HashSet<Delegate>();
				this.PendingRemoveHandles[name] = hashSet;
			}
			hashSet.Add(handle);
			return true;
		}
	}

	// Token: 0x06003079 RID: 12409 RVA: 0x0001A954 File Offset: 0x00018B54
	private bool DoRemove(long name, Delegate handle)
	{
		Dictionary<Delegate, NumberEvent.EHandleType> dictionary;
		if (!this.Handles.TryGetValue(name, out dictionary) || !dictionary.Remove(handle))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Event;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "事件不存在，请检查同一个事件名同一个处理函数的移除逻辑";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (dictionary.Count == 0)
		{
			this.Handles.Remove(name);
		}
		return true;
	}

	// Token: 0x0600307A RID: 12410 RVA: 0x0001A9BD File Offset: 0x00018BBD
	public bool IsEmitting(long name)
	{
		return this.EmittingMaskSet.Contains(name);
	}

	// Token: 0x0600307B RID: 12411 RVA: 0x0001A9CB File Offset: 0x00018BCB
	private void SetEmitting(long name, bool isEmitting)
	{
		if (isEmitting)
		{
			this.EmittingMaskSet.Add(name);
			return;
		}
		this.EmittingMaskSet.Remove(name);
	}

	// Token: 0x17000090 RID: 144
	// (get) Token: 0x0600307C RID: 12412 RVA: 0x0001A9EB File Offset: 0x00018BEB
	private Dictionary<long, Dictionary<Delegate, NumberEvent.EHandleType>> PendingAddHandles
	{
		get
		{
			if (this.PendingAddHandlesInternal == null)
			{
				this.PendingAddHandlesInternal = new Dictionary<long, Dictionary<Delegate, NumberEvent.EHandleType>>();
			}
			return this.PendingAddHandlesInternal;
		}
	}

	// Token: 0x17000091 RID: 145
	// (get) Token: 0x0600307D RID: 12413 RVA: 0x0001AA06 File Offset: 0x00018C06
	private Dictionary<long, HashSet<Delegate>> PendingRemoveHandles
	{
		get
		{
			if (this.PendingRemoveHandlesInternal == null)
			{
				this.PendingRemoveHandlesInternal = new Dictionary<long, HashSet<Delegate>>();
			}
			return this.PendingRemoveHandlesInternal;
		}
	}

	// Token: 0x0600307E RID: 12414 RVA: 0x0001AA21 File Offset: 0x00018C21
	public static void CreateStaticDefaultValue()
	{
		NumberEvent._nameStateMap = new Dictionary<string, Stat>();
		NumberEvent._handleStatMap = new Dictionary<MethodInfo, Stat>();
	}

	// Token: 0x0600307F RID: 12415 RVA: 0x0001AA37 File Offset: 0x00018C37
	public static void ResetStaticDefaultValue()
	{
		NumberEvent._nameStateMap = null;
		NumberEvent._handleStatMap = null;
	}

	// Token: 0x04000407 RID: 1031
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<string, Stat> _nameStateMap;

	// Token: 0x04000408 RID: 1032
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<MethodInfo, Stat> _handleStatMap;

	// Token: 0x04000409 RID: 1033
	private readonly Dictionary<long, Dictionary<Delegate, NumberEvent.EHandleType>> Handles = new Dictionary<long, Dictionary<Delegate, NumberEvent.EHandleType>>();

	// Token: 0x0400040A RID: 1034
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<long, Dictionary<Delegate, NumberEvent.EHandleType>> PendingAddHandlesInternal;

	// Token: 0x0400040B RID: 1035
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<long, HashSet<Delegate>> PendingRemoveHandlesInternal;

	// Token: 0x0400040C RID: 1036
	private readonly HashSet<long> EmittingMaskSet = new HashSet<long>();

	// Token: 0x0400040D RID: 1037
	private readonly Dictionary<long, Dictionary<object, object>> HoldKeyHandles = new Dictionary<long, Dictionary<object, object>>();

	// Token: 0x02007194 RID: 29076
	[NullableContext(0)]
	private enum EHandleType
	{
		// Token: 0x040278EA RID: 162026
		Forever,
		// Token: 0x040278EB RID: 162027
		Once
	}
}
