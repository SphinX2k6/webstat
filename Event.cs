using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

// Token: 0x020000A3 RID: 163
[NullableContext(1)]
[Nullable(0)]
public class Event<[Nullable(0)] TName, [Nullable(0)] TType> : IClear where TName : Enum where TType : Delegate
{
	// Token: 0x0600041F RID: 1055 RVA: 0x00018454 File Offset: 0x00016654
	private void AddHoldKeyValueToMapInternal<[Nullable(0)] T>(TName name, object holdKey, object objectKey, Dictionary<TName, Dictionary<object, object>> keyMap) where T : TName
	{
		Dictionary<object, object> dictionary;
		if (!keyMap.TryGetValue(name, out dictionary))
		{
			dictionary = new Dictionary<object, object>();
			keyMap[name] = dictionary;
		}
		dictionary[objectKey] = holdKey;
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x00018484 File Offset: 0x00016684
	private void RemoveHoldKeyValueFromMapInternal(TName name, object holdKey, Dictionary<TName, Dictionary<object, object>> keyMap)
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

	// Token: 0x06000421 RID: 1057 RVA: 0x000184B8 File Offset: 0x000166B8
	[return: Nullable(2)]
	private object GetHoldKeyValueOfMapInternal(TName name, object holdKey, Dictionary<TName, Dictionary<object, object>> keyMap)
	{
		Dictionary<object, object> dictionary;
		if (!keyMap.TryGetValue(name, out dictionary))
		{
			return null;
		}
		return dictionary.GetValueOrDefault(holdKey);
	}

	// Token: 0x06000422 RID: 1058 RVA: 0x000184D9 File Offset: 0x000166D9
	public void AddHoldKeyHandle<[Nullable(0)] T>(TName name, object objectKey, object handle) where T : TName
	{
		this.AddHoldKeyValueToMapInternal<T>(name, handle, objectKey, this.HoldKeyHandles);
	}

	// Token: 0x06000423 RID: 1059 RVA: 0x000184EA File Offset: 0x000166EA
	public void RemoveHoldKeyHandle(TName name, object handle)
	{
		this.RemoveHoldKeyValueFromMapInternal(name, handle, this.HoldKeyHandles);
	}

	// Token: 0x06000424 RID: 1060 RVA: 0x000184FA File Offset: 0x000166FA
	[return: Nullable(2)]
	public object GetHoldKeyByHandle(TName name, object handle)
	{
		return this.GetHoldKeyValueOfMapInternal(name, handle, this.HoldKeyHandles);
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x0001850C File Offset: 0x0001670C
	public bool Has(TName name, TType handle)
	{
		Dictionary<Delegate, EHandleType> dictionary;
		if (this.Handles.TryGetValue(name, out dictionary) && dictionary.ContainsKey(handle))
		{
			HashSet<Delegate> hashSet;
			return !this.PendingRemoveHandles.TryGetValue(name, out hashSet) || !hashSet.Contains(handle);
		}
		Dictionary<Delegate, EHandleType> dictionary2;
		return this.PendingAddHandles.TryGetValue(name, out dictionary2) && dictionary2.ContainsKey(handle);
	}

	// Token: 0x06000426 RID: 1062 RVA: 0x00018577 File Offset: 0x00016777
	public bool HasAny(TName name)
	{
		return this.Handles.ContainsKey(name) || this.PendingAddHandles.ContainsKey(name);
	}

	// Token: 0x06000427 RID: 1063 RVA: 0x00018595 File Offset: 0x00016795
	public bool Add(TName name, TType handle)
	{
		return this.AddInternal(name, handle, EHandleType.Forever);
	}

	// Token: 0x06000428 RID: 1064 RVA: 0x000185A0 File Offset: 0x000167A0
	public bool Once(TName name, TType handle)
	{
		return this.AddInternal(name, handle, EHandleType.Once);
	}

	// Token: 0x06000429 RID: 1065 RVA: 0x000185AB File Offset: 0x000167AB
	public bool Remove(TName name, TType handle)
	{
		return this.IsRegistered(name, handle) && this.RemoveInternal(name, handle);
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x000185CC File Offset: 0x000167CC
	private bool IsRegistered(TName name, Delegate handle)
	{
		Dictionary<Delegate, EHandleType> dictionary;
		Dictionary<Delegate, EHandleType> dictionary2;
		return (this.Handles.TryGetValue(name, out dictionary) && dictionary.ContainsKey(handle)) || (this.PendingAddHandlesInternal != null && this.PendingAddHandlesInternal.TryGetValue(name, out dictionary2) && dictionary2.ContainsKey(handle));
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x00018618 File Offset: 0x00016818
	public bool ClearObject()
	{
		this.Handles.Clear();
		Dictionary<TName, Dictionary<Delegate, EHandleType>> pendingAddHandlesInternal = this.PendingAddHandlesInternal;
		if (pendingAddHandlesInternal != null)
		{
			pendingAddHandlesInternal.Clear();
		}
		Dictionary<TName, HashSet<Delegate>> pendingRemoveHandlesInternal = this.PendingRemoveHandlesInternal;
		if (pendingRemoveHandlesInternal != null)
		{
			pendingRemoveHandlesInternal.Clear();
		}
		this.EmittingMaskSet.Clear();
		this.HoldKeyHandles.Clear();
		return true;
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x0001866C File Offset: 0x0001686C
	public bool ClearObject(TName name)
	{
		Dictionary<Delegate, EHandleType> dictionary;
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

	// Token: 0x0600042D RID: 1069 RVA: 0x000186D4 File Offset: 0x000168D4
	public bool Emit(TName name)
	{
		return this.EmitInternal<EventArgs>(name, default(EventArgs), default(EventArgs));
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x000186FF File Offset: 0x000168FF
	public bool Emit<[Nullable(2)] T1>(TName name, T1 p1)
	{
		return this.EmitInternal<T1>(name, new EventArgs<T1>(p1), p1);
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x00018714 File Offset: 0x00016914
	public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2>(TName name, T1 p1, T2 p2)
	{
		return this.EmitInternal<T1>(name, new EventArgs<T1, T2>(p1, p2), p1);
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x0001872A File Offset: 0x0001692A
	public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3>(TName name, T1 p1, T2 p2, T3 p3)
	{
		return this.EmitInternal<T1>(name, new EventArgs<T1, T2, T3>(p1, p2, p3), p1);
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x00018742 File Offset: 0x00016942
	public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4>(TName name, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		return this.EmitInternal<T1>(name, new EventArgs<T1, T2, T3, T4>(p1, p2, p3, p4), p1);
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x0001875C File Offset: 0x0001695C
	public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5>(TName name, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
	{
		return this.EmitInternal<T1>(name, new EventArgs<T1, T2, T3, T4, T5>(p1, p2, p3, p4, p5), p1);
	}

	// Token: 0x06000433 RID: 1075 RVA: 0x00018778 File Offset: 0x00016978
	public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5, [Nullable(2)] T6>(TName name, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
	{
		return this.EmitInternal<T1>(name, new EventArgs<T1, T2, T3, T4, T5, T6>(p1, p2, p3, p4, p5, p6), p1);
	}

	// Token: 0x06000434 RID: 1076 RVA: 0x00018798 File Offset: 0x00016998
	public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5, [Nullable(2)] T6, [Nullable(2)] T7>(TName name, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
	{
		return this.EmitInternal<T1>(name, new EventArgs<T1, T2, T3, T4, T5, T6, T7>(p1, p2, p3, p4, p5, p6, p7), p1);
	}

	// Token: 0x06000435 RID: 1077 RVA: 0x000187C4 File Offset: 0x000169C4
	private unsafe bool EmitInternal<[Nullable(2)] T1>(TName name, IEventArgs args, [Nullable(2)] T1 conditionParam)
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
		ConditionListener<T1> conditionListener = this.GetConditionListener<T1>(name);
		if (conditionListener != null && conditionParam != null)
		{
			Dictionary<Delegate, EHandleType> handlesByParam = conditionListener.GetHandlesByParam(conditionParam);
			if (handlesByParam != null)
			{
				this.ExecuteHandlesInternal<T1>(name, handlesByParam, conditionListener, args, conditionParam);
				if (handlesByParam.Count == 0)
				{
					conditionListener.DeleteHandlesByParam(conditionParam);
				}
			}
		}
		Dictionary<Delegate, EHandleType> dictionary;
		if (this.Handles.TryGetValue(name, out dictionary))
		{
			this.ExecuteHandlesInternal<T1>(name, dictionary, null, args, default(T1));
			if (dictionary.Count == 0)
			{
				this.Handles.Remove(name);
			}
		}
		this.SetEmitting(name, false);
		HashSet<Delegate> hashSet;
		if (this.PendingRemoveHandles.TryGetValue(name, out hashSet))
		{
			foreach (Delegate handle in hashSet)
			{
				this.DoRemove(name, handle);
			}
			hashSet.Clear();
			this.PendingRemoveHandles.Remove(name);
		}
		Dictionary<Delegate, EHandleType> dictionary2;
		if (this.PendingAddHandles.TryGetValue(name, out dictionary2))
		{
			foreach (KeyValuePair<Delegate, EHandleType> keyValuePair in dictionary2)
			{
				this.DoAdd(name, keyValuePair.Key, keyValuePair.Value);
			}
			dictionary2.Clear();
			this.PendingAddHandles.Remove(name);
		}
		if (conditionListener != null)
		{
			if (conditionListener.PendingRemoveHandles != null && conditionListener.PendingRemoveHandles.Count > 0)
			{
				foreach (KeyValuePair<T1, HashSet<Delegate>> keyValuePair2 in conditionListener.PendingRemoveHandles)
				{
					foreach (Delegate handle2 in keyValuePair2.Value)
					{
						this.DoRemoveWithCondition<T1>(name, keyValuePair2.Key, handle2);
					}
				}
				conditionListener.PendingRemoveHandles.Clear();
			}
			if (conditionListener.PendingAddHandles != null && conditionListener.PendingAddHandles.Count > 0)
			{
				foreach (KeyValuePair<T1, Dictionary<Delegate, EHandleType>> keyValuePair3 in conditionListener.PendingAddHandles)
				{
					foreach (KeyValuePair<Delegate, EHandleType> keyValuePair4 in keyValuePair3.Value)
					{
						this.DoAddWithCondition<T1>(name, conditionListener, keyValuePair4.Key, keyValuePair4.Value, keyValuePair3.Key);
					}
				}
				conditionListener.PendingAddHandles.Clear();
			}
			if (conditionListener.IsHandlesEmpty())
			{
				this.ConditionHandles.Remove(name);
			}
		}
		return true;
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x00018B24 File Offset: 0x00016D24
	private unsafe void ExecuteHandlesInternal<[Nullable(2)] T1>(TName name, Dictionary<Delegate, EHandleType> handles, [Nullable(new byte[]
	{
		2,
		1
	})] ConditionListener<T1> conditionListener, IEventArgs args, [Nullable(2)] T1 conditionParam)
	{
		Stat value = null;
		if (Stat.Enable && !EventConstant.NameStateMap.TryGetValue(name, out value))
		{
			EventConstant.NameStateMap[name] = value;
		}
		foreach (KeyValuePair<Delegate, EHandleType> keyValuePair in handles)
		{
			Delegate key = keyValuePair.Key;
			if (!((conditionListener != null) ? conditionListener.IsInPendingRemove(conditionParam, key) : this.CheckInPendingRemoveHandles(name, key)))
			{
				if (keyValuePair.Value == EHandleType.Once)
				{
					if (conditionListener != null)
					{
						this.RemoveWithConditionInternal<T1>(name, key, conditionParam);
					}
					else
					{
						this.RemoveInternal(name, key);
					}
				}
				Stat stat = null;
				if (Stat.Enable)
				{
					EventConstant.HandleStatMap.TryGetValue(key.Method, out stat);
				}
				try
				{
					args.Invoke(name, key);
				}
				catch (Exception ex) when (1)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Event;
					ELogAuthor author = ELogAuthor.LCC;
					string message = "事件处理方法执行异常";
					Exception error = ex;
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("name", name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
					instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
		}
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x00018CB8 File Offset: 0x00016EB8
	private bool AddInternal(TName name, TType handle, EHandleType handleType)
	{
		Event<TName, TType>.SetupHandleStat(handle);
		if (!this.IsEmitting(name))
		{
			return this.DoAdd(name, handle, handleType);
		}
		Dictionary<Delegate, EHandleType> dictionary;
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
			Dictionary<Delegate, EHandleType> dictionary2;
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
				dictionary2 = new Dictionary<Delegate, EHandleType>();
				this.PendingAddHandles[name] = dictionary2;
			}
			dictionary2[handle] = handleType;
			return true;
		}
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x00018DD4 File Offset: 0x00016FD4
	private static void SetupHandleStat(Delegate handle)
	{
		if (!Stat.Enable)
		{
			return;
		}
		MethodInfo method = handle.Method;
		if (EventConstant.HandleStatMap.ContainsKey(method))
		{
			return;
		}
		string name = method.Name;
		Stat value = null;
		string.IsNullOrEmpty(name);
		EventConstant.HandleStatMap[method] = value;
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x00018E18 File Offset: 0x00017018
	private bool DoAdd(TName name, Delegate handle, EHandleType handleType)
	{
		Dictionary<Delegate, EHandleType> dictionary;
		if (!this.Handles.TryGetValue(name, out dictionary))
		{
			dictionary = new Dictionary<Delegate, EHandleType>();
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

	// Token: 0x0600043A RID: 1082 RVA: 0x00018E8C File Offset: 0x0001708C
	private bool RemoveInternal(TName name, Delegate handle)
	{
		if (!this.IsEmitting(name))
		{
			return this.DoRemove(name, handle);
		}
		Dictionary<Delegate, EHandleType> dictionary;
		if (!this.Handles.TryGetValue(name, out dictionary) || !dictionary.ContainsKey(handle))
		{
			Dictionary<Delegate, EHandleType> dictionary2;
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

	// Token: 0x0600043B RID: 1083 RVA: 0x00018F7C File Offset: 0x0001717C
	private bool DoRemove(TName name, Delegate handle)
	{
		Dictionary<Delegate, EHandleType> dictionary;
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

	// Token: 0x0600043C RID: 1084 RVA: 0x00018FE5 File Offset: 0x000171E5
	public bool IsEmitting(TName name)
	{
		return this.EmittingMaskSet.Contains(name);
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x00018FF3 File Offset: 0x000171F3
	private void SetEmitting(TName name, bool isEmitting)
	{
		if (isEmitting)
		{
			this.EmittingMaskSet.Add(name);
			return;
		}
		this.EmittingMaskSet.Remove(name);
	}

	// Token: 0x1700008A RID: 138
	// (get) Token: 0x0600043E RID: 1086 RVA: 0x00019013 File Offset: 0x00017213
	private Dictionary<TName, Dictionary<Delegate, EHandleType>> PendingAddHandles
	{
		get
		{
			if (this.PendingAddHandlesInternal == null)
			{
				this.PendingAddHandlesInternal = new Dictionary<TName, Dictionary<Delegate, EHandleType>>();
			}
			return this.PendingAddHandlesInternal;
		}
	}

	// Token: 0x1700008B RID: 139
	// (get) Token: 0x0600043F RID: 1087 RVA: 0x0001902E File Offset: 0x0001722E
	private Dictionary<TName, HashSet<Delegate>> PendingRemoveHandles
	{
		get
		{
			if (this.PendingRemoveHandlesInternal == null)
			{
				this.PendingRemoveHandlesInternal = new Dictionary<TName, HashSet<Delegate>>();
			}
			return this.PendingRemoveHandlesInternal;
		}
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x0001904C File Offset: 0x0001724C
	private bool CheckInPendingRemoveHandles(TName name, Delegate handle)
	{
		HashSet<Delegate> valueOrDefault = this.PendingRemoveHandles.GetValueOrDefault(name);
		return valueOrDefault != null && valueOrDefault.Contains(handle);
	}

	// Token: 0x06000441 RID: 1089 RVA: 0x00019074 File Offset: 0x00017274
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public ConditionListener<T> GetConditionListener<[Nullable(2)] T>(TName name)
	{
		IConditionListener conditionListener;
		if (this.ConditionHandles.TryGetValue(name, out conditionListener))
		{
			ConditionListener<T> conditionListener2 = conditionListener as ConditionListener<T>;
			if (conditionListener2 != null)
			{
				return conditionListener2;
			}
		}
		return null;
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x000190A0 File Offset: 0x000172A0
	public bool HasWithCondition<[Nullable(2)] T1>(TName name, Delegate handle, T1 param)
	{
		ConditionListener<T1> conditionListener = this.GetConditionListener<T1>(name);
		if (conditionListener == null)
		{
			return false;
		}
		if (conditionListener.Has(param, handle))
		{
			return !conditionListener.IsInPendingRemove(param, handle);
		}
		return conditionListener.IsInPendingAdd(param, handle);
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x000190D8 File Offset: 0x000172D8
	public bool AddWithCondition<[Nullable(2)] T1>(TName name, Delegate handle, T1 conditionParam)
	{
		return this.AddWithConditionInternal<T1>(name, handle, EHandleType.Forever, conditionParam);
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x000190E4 File Offset: 0x000172E4
	public bool OnceWithCondition<[Nullable(2)] T1>(TName name, Delegate handle, T1 conditionParam)
	{
		return this.AddWithConditionInternal<T1>(name, handle, EHandleType.Once, conditionParam);
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x000190F0 File Offset: 0x000172F0
	private bool AddWithConditionInternal<[Nullable(2)] T1>(TName name, Delegate handle, EHandleType handleType, T1 param)
	{
		Event<TName, TType>.SetupHandleStat(handle);
		IConditionListener value;
		if (!this.ConditionHandles.TryGetValue(name, out value))
		{
			value = new ConditionListener<T1>();
			this.ConditionHandles[name] = value;
		}
		ConditionListener<T1> conditionListener = this.GetConditionListener<T1>(name);
		if (!this.IsEmitting(name))
		{
			return this.DoAddWithCondition<T1>(name, conditionListener, handle, handleType, param);
		}
		if (conditionListener.Has(param, handle))
		{
			bool flag = conditionListener.RemoveFromPendingMoveHandles(param, handle);
			if (!flag)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "条件事件已存在，请检查同一个事件名同一个处理函数的注册逻辑";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return flag;
		}
		bool flag2 = conditionListener.AddToPendingAddHandles(param, handle, handleType);
		if (!flag2)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Event;
			ELogAuthor author2 = ELogAuthor.YSQ;
			string message2 = "条件事件重复注册在待修改列表，请检查同一个事件名同一个处理函数的注册逻辑";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("name", name);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		return flag2;
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x000191C4 File Offset: 0x000173C4
	private bool DoAddWithCondition<[Nullable(2)] T1>(TName name, ConditionListener<T1> conditionListener, Delegate handle, EHandleType handleType, T1 param)
	{
		if (conditionListener.Has(param, handle))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Event;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "事件重复注册，请检查同一个事件名同一个处理函数的注册逻辑";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		conditionListener.Add(param, handle, handleType);
		return true;
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x00019218 File Offset: 0x00017418
	public bool RemoveWithCondition<[Nullable(2)] T1>(TName name, Delegate handle, T1 param)
	{
		ConditionListener<T1> conditionListener = this.GetConditionListener<T1>(name);
		return conditionListener != null && (conditionListener.Has(param, handle) || conditionListener.IsInPendingAdd(param, handle)) && this.RemoveWithConditionInternal<T1>(name, handle, param);
	}

	// Token: 0x06000448 RID: 1096 RVA: 0x00019250 File Offset: 0x00017450
	private bool RemoveWithConditionInternal<[Nullable(2)] T1>(TName name, Delegate handle, T1 param)
	{
		if (!this.IsEmitting(name))
		{
			return this.DoRemoveWithCondition<T1>(name, param, handle);
		}
		ConditionListener<T1> conditionListener = this.GetConditionListener<T1>(name);
		if (conditionListener == null)
		{
			return true;
		}
		if (!conditionListener.Has(param, handle))
		{
			bool flag = conditionListener.RemoveFromPendingAddHandles(param, handle);
			if (!flag)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "事件不存在，请检查同一个事件名同一个处理函数的移除逻辑";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return flag;
		}
		bool flag2 = conditionListener.AddToPendingRemoveHandles(param, handle);
		if (!flag2)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Event;
			ELogAuthor author2 = ELogAuthor.LCC;
			string message2 = "事件重复移除在待移除列表，请检查同一个事件名同一个处理函数的移除逻辑";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("name", name);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		return flag2;
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x000192F8 File Offset: 0x000174F8
	private bool DoRemoveWithCondition<[Nullable(2)] T1>(TName name, T1 param, Delegate handle)
	{
		ConditionListener<T1> conditionListener = this.GetConditionListener<T1>(name);
		if (conditionListener == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Event;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "事件不存在，请检查同一个事件名同一个处理函数的移除逻辑";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		bool flag = conditionListener.Remove(param, handle);
		if (!flag)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Event;
			ELogAuthor author2 = ELogAuthor.YSQ;
			string message2 = "事件条件不存在，请检查同一个事件名同一个处理函数的移除逻辑";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("name", name);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		return flag;
	}

	// Token: 0x040003E2 RID: 994
	private readonly Dictionary<TName, Dictionary<Delegate, EHandleType>> Handles = new Dictionary<TName, Dictionary<Delegate, EHandleType>>();

	// Token: 0x040003E3 RID: 995
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<TName, Dictionary<Delegate, EHandleType>> PendingAddHandlesInternal;

	// Token: 0x040003E4 RID: 996
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<TName, HashSet<Delegate>> PendingRemoveHandlesInternal;

	// Token: 0x040003E5 RID: 997
	private readonly HashSet<TName> EmittingMaskSet = new HashSet<TName>();

	// Token: 0x040003E6 RID: 998
	private readonly Dictionary<TName, Dictionary<object, object>> HoldKeyHandles = new Dictionary<TName, Dictionary<object, object>>();

	// Token: 0x040003E7 RID: 999
	private readonly Dictionary<TName, IConditionListener> ConditionHandles = new Dictionary<TName, IConditionListener>();
}
