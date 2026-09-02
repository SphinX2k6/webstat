using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020000B0 RID: 176
[NullableContext(1)]
[Nullable(0)]
public class ConditionListener<[Nullable(2)] TParamType> : IConditionListener
{
	// Token: 0x1700008C RID: 140
	// (get) Token: 0x0600046A RID: 1130 RVA: 0x00019E92 File Offset: 0x00018092
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public Dictionary<TParamType, Dictionary<Delegate, EHandleType>> PendingAddHandles
	{
		[return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		get
		{
			return this.PendingAddHandlesInternal;
		}
	}

	// Token: 0x1700008D RID: 141
	// (get) Token: 0x0600046B RID: 1131 RVA: 0x00019E9A File Offset: 0x0001809A
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public Dictionary<TParamType, HashSet<Delegate>> PendingRemoveHandles
	{
		[return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		get
		{
			return this.PendingRemoveHandlesInternal;
		}
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x00019EA2 File Offset: 0x000180A2
	public bool IsHandlesEmpty()
	{
		return this.Handles.Count == 0;
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x00019EB4 File Offset: 0x000180B4
	public bool Has(TParamType param, Delegate eventHandle)
	{
		Dictionary<Delegate, EHandleType> dictionary;
		return this.Handles.TryGetValue(param, out dictionary) && dictionary.ContainsKey(eventHandle);
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x00019EDC File Offset: 0x000180DC
	public bool IsInPendingAdd(TParamType conditionParam, Delegate handle)
	{
		Dictionary<Delegate, EHandleType> dictionary;
		return this.PendingAddHandlesInternal != null && this.PendingAddHandlesInternal.TryGetValue(conditionParam, out dictionary) && dictionary.ContainsKey(handle);
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x00019F0C File Offset: 0x0001810C
	public bool IsInPendingRemove(TParamType conditionParam, Delegate handle)
	{
		HashSet<Delegate> hashSet;
		return this.PendingRemoveHandlesInternal != null && this.PendingRemoveHandlesInternal.TryGetValue(conditionParam, out hashSet) && hashSet.Contains(handle);
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x00019F3C File Offset: 0x0001813C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<Delegate, EHandleType> GetHandlesByParam(TParamType param)
	{
		Dictionary<Delegate, EHandleType> result;
		this.Handles.TryGetValue(param, out result);
		return result;
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x00019F59 File Offset: 0x00018159
	public bool DeleteHandlesByParam(TParamType param)
	{
		return this.Handles.Remove(param);
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x00019F68 File Offset: 0x00018168
	public bool Add(TParamType param, Delegate eventHandle, EHandleType handleType)
	{
		Dictionary<Delegate, EHandleType> dictionary;
		if (!this.Handles.TryGetValue(param, out dictionary))
		{
			dictionary = new Dictionary<Delegate, EHandleType>();
			this.Handles[param] = dictionary;
		}
		if (dictionary.ContainsKey(eventHandle))
		{
			return false;
		}
		dictionary[eventHandle] = handleType;
		return true;
	}

	// Token: 0x06000473 RID: 1139 RVA: 0x00019FAC File Offset: 0x000181AC
	public bool Remove(TParamType param, Delegate eventHandle)
	{
		Dictionary<Delegate, EHandleType> dictionary;
		return this.Handles.TryGetValue(param, out dictionary) && dictionary.Remove(eventHandle);
	}

	// Token: 0x06000474 RID: 1140 RVA: 0x00019FD4 File Offset: 0x000181D4
	public bool AddToPendingAddHandles(TParamType conditionParam, Delegate handle, EHandleType handleType)
	{
		if (this.PendingAddHandlesInternal == null)
		{
			this.PendingAddHandlesInternal = new Dictionary<TParamType, Dictionary<Delegate, EHandleType>>();
		}
		Dictionary<Delegate, EHandleType> dictionary;
		if (this.PendingAddHandlesInternal.TryGetValue(conditionParam, out dictionary) && dictionary.ContainsKey(handle))
		{
			return false;
		}
		if (dictionary == null)
		{
			dictionary = new Dictionary<Delegate, EHandleType>();
			this.PendingAddHandlesInternal[conditionParam] = dictionary;
		}
		dictionary[handle] = handleType;
		return true;
	}

	// Token: 0x06000475 RID: 1141 RVA: 0x0001A030 File Offset: 0x00018230
	public bool AddToPendingRemoveHandles(TParamType conditionParam, Delegate handle)
	{
		if (this.PendingRemoveHandlesInternal == null)
		{
			this.PendingRemoveHandlesInternal = new Dictionary<TParamType, HashSet<Delegate>>();
		}
		HashSet<Delegate> hashSet;
		if (this.PendingRemoveHandlesInternal.TryGetValue(conditionParam, out hashSet) && hashSet.Contains(handle))
		{
			return false;
		}
		if (hashSet == null)
		{
			hashSet = new HashSet<Delegate>();
			this.PendingRemoveHandlesInternal[conditionParam] = hashSet;
		}
		hashSet.Add(handle);
		return true;
	}

	// Token: 0x06000476 RID: 1142 RVA: 0x0001A08C File Offset: 0x0001828C
	public bool RemoveFromPendingAddHandles(TParamType conditionParam, Delegate handle)
	{
		Dictionary<Delegate, EHandleType> dictionary;
		return this.PendingAddHandlesInternal != null && this.PendingAddHandlesInternal.TryGetValue(conditionParam, out dictionary) && dictionary.Remove(handle);
	}

	// Token: 0x06000477 RID: 1143 RVA: 0x0001A0BC File Offset: 0x000182BC
	public bool RemoveFromPendingMoveHandles(TParamType conditionParam, Delegate handle)
	{
		HashSet<Delegate> hashSet;
		return this.PendingRemoveHandlesInternal != null && this.PendingRemoveHandlesInternal.TryGetValue(conditionParam, out hashSet) && hashSet.Remove(handle);
	}

	// Token: 0x04000404 RID: 1028
	private readonly Dictionary<TParamType, Dictionary<Delegate, EHandleType>> Handles = new Dictionary<TParamType, Dictionary<Delegate, EHandleType>>();

	// Token: 0x04000405 RID: 1029
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<TParamType, Dictionary<Delegate, EHandleType>> PendingAddHandlesInternal;

	// Token: 0x04000406 RID: 1030
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<TParamType, HashSet<Delegate>> PendingRemoveHandlesInternal;
}
