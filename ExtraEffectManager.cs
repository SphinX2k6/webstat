using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002F30 RID: 12080
[NullableContext(1)]
[Nullable(0)]
public class ExtraEffectManager
{
	// Token: 0x06018B9F RID: 101279 RVA: 0x006FC2A5 File Offset: 0x006FA4A5
	public ExtraEffectManager(BaseBuffComponent buffComponent)
	{
		this.BuffComponent = buffComponent;
	}

	// Token: 0x06018BA0 RID: 101280 RVA: 0x006FC2D8 File Offset: 0x006FA4D8
	public unsafe void OnBuffAdded(ActiveBuffInternal buff)
	{
		if (!this.CheckBuffEffectExistence(buff))
		{
			return;
		}
		if (((buff != null) ? buff.Config : null) == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			BaseBuffComponent buffComponent = this.BuffComponent;
			Entity entity = (buffComponent != null) ? buffComponent.Entity : null;
			string message = "正在添加的buff额外效果未加载对应的buffRef";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", (buff != null) ? new long?(buff.Id) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", (buff != null) ? new int?(buff.Handle) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("持有者", (buff != null) ? buff.GetOwnerDebugName() : null);
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		if (buff.IsActive())
		{
			this.CreateBuffEffects(buff);
		}
	}

	// Token: 0x06018BA1 RID: 101281 RVA: 0x006FC3D0 File Offset: 0x006FA5D0
	public void OnBuffRemoved(ActiveBuffInternal buff, bool isPrematureRemoval)
	{
		int handle = buff.Handle;
		if (!this.CheckBuffEffectExistence(buff))
		{
			return;
		}
		if (buff.IsActive())
		{
			this.RemoveBuffEffects(handle, isPrematureRemoval);
		}
	}

	// Token: 0x06018BA2 RID: 101282 RVA: 0x006FC400 File Offset: 0x006FA600
	public void OnStackIncreased(ActiveBuffInternal buff, int newCount, int oldCount, long? instigatorId)
	{
		if (!this.CheckBuffEffectExistence(buff))
		{
			return;
		}
		foreach (BuffEffect buffEffect in this.GetEffectsByHandle(buff.Handle))
		{
			buffEffect.OnStackIncreased(newCount, oldCount, instigatorId);
		}
	}

	// Token: 0x06018BA3 RID: 101283 RVA: 0x006FC460 File Offset: 0x006FA660
	public void OnStackDecreased(ActiveBuffInternal buff, int newCount, int oldCount, bool bPremature)
	{
		if (!this.CheckBuffEffectExistence(buff))
		{
			return;
		}
		foreach (BuffEffect buffEffect in this.GetEffectsByHandle(buff.Handle))
		{
			buffEffect.OnStackDecreased(newCount, oldCount, bPremature);
		}
	}

	// Token: 0x06018BA4 RID: 101284 RVA: 0x006FC4C0 File Offset: 0x006FA6C0
	public void OnBuffStackOverflow(ActiveBuffInternal buff, int oldStack, int newStack, int stackLimitMax)
	{
		foreach (ExtraEffectParameters extraEffectParameters in buff.Config.EffectInfos)
		{
			BuffExecution executionEffect = extraEffectParameters.ExecutionEffect;
			if (executionEffect != null)
			{
				executionEffect.OnBuffStackOverflow(buff, oldStack, newStack, stackLimitMax);
			}
		}
		if (!this.CheckBuffEffectExistence(buff))
		{
			return;
		}
		foreach (BuffEffect buffEffect in this.GetEffectsByHandle(buff.Handle))
		{
			buffEffect.OnBuffStackOverflow(buff, oldStack, newStack, stackLimitMax);
		}
	}

	// Token: 0x06018BA5 RID: 101285 RVA: 0x006FC574 File Offset: 0x006FA774
	public void OnBuffInhibitedChanged(ActiveBuffInternal buff, bool isInhibited)
	{
		int handle = buff.Handle;
		if (!this.CheckBuffEffectExistence(buff))
		{
			return;
		}
		if (!isInhibited)
		{
			this.CreateBuffEffects(buff);
			return;
		}
		this.RemoveBuffEffects(handle, true);
	}

	// Token: 0x06018BA6 RID: 101286 RVA: 0x006FC5A8 File Offset: 0x006FA7A8
	private unsafe bool CheckBuffEffectExistence(ActiveBuffInternal buff)
	{
		BuffDefinition buffDefinition = (buff != null) ? buff.Config : null;
		if (buffDefinition == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			BaseBuffComponent buffComponent = this.BuffComponent;
			Entity entity = (buffComponent != null) ? buffComponent.Entity : null;
			string message = "处理buff额外效果逻辑时找不到对应的buffRef";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", (buff != null) ? new long?(buff.Id) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handleId", (buff != null) ? new int?(buff.Handle) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("持有者", (buff != null) ? buff.GetOwnerDebugName() : null);
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		return buffDefinition.HasBuffEffect;
	}

	// Token: 0x06018BA7 RID: 101287 RVA: 0x006FC694 File Offset: 0x006FA894
	private unsafe void CreateBuffEffects(ActiveBuffInternal buff)
	{
		int handle = buff.Handle;
		long id = buff.Id;
		if (this.ActivatedHandles.Contains(handle))
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			BaseBuffComponent buffComponent = this.BuffComponent;
			Entity entity = (buffComponent != null) ? buffComponent.Entity : null;
			string message = "重复创建Buff额外效果";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", handle);
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		CharacterBuffComponent instigatorBuffComponent = buff.GetInstigatorBuffComponent();
		this.ActivatedHandles.Add(handle);
		List<ValueTuple<ExtraEffectParameters, RequireAndLimits>> list = new List<ValueTuple<ExtraEffectParameters, RequireAndLimits>>();
		if (buff.Config.EffectInfos != null)
		{
			foreach (ExtraEffectParameters extraEffectParameters in buff.Config.EffectInfos)
			{
				list.Add(new ValueTuple<ExtraEffectParameters, RequireAndLimits>(extraEffectParameters, ExtraEffectLibrary.BuffExtraEffectLibrary.ResolveRequireAndLimits(id, extraEffectParameters, buff.Level)));
			}
		}
		BaseBuffComponent buffComponent2 = this.BuffComponent;
		if (list == null || (buffComponent2 == null || !buffComponent2.Valid))
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			ExtraEffectParameters item = list[i].Item1;
			RequireAndLimits item2 = list[i].Item2;
			Type buffEffectClass = ExtraEffectDefine.GetBuffEffectClass(item.ExtraEffectId);
			if (buffEffectClass != null)
			{
				BuffEffect buffEffect = BuffEffect.Create(buffEffectClass, handle, i, item2, this.BuffComponent, instigatorBuffComponent, item);
				this.Add(buffEffect);
				buffEffect.OnCreated();
			}
		}
	}

	// Token: 0x06018BA8 RID: 101288 RVA: 0x006FC844 File Offset: 0x006FAA44
	private unsafe void RemoveBuffEffects(int handleId, bool isPrematureRemoval)
	{
		if (!this.ActivatedHandles.Contains(handleId))
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			BaseBuffComponent buffComponent = this.BuffComponent;
			Entity entity = (buffComponent != null) ? buffComponent.Entity : null;
			string message = "尝试移除不存在的buff额外效果实例";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("handleId", handleId);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "entity";
			BaseBuffComponent buffComponent2 = this.BuffComponent;
			int? num;
			if (buffComponent2 == null)
			{
				num = null;
			}
			else
			{
				Entity entity2 = buffComponent2.Entity;
				num = ((entity2 != null) ? new int?(entity2.Id) : null);
			}
			ptr = new ValueTuple<string, object>(item, num);
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.ActivatedHandles.Remove(handleId);
		IEnumerable<BuffEffect> effectsByHandle = this.GetEffectsByHandle(handleId);
		foreach (BuffEffect buffEffect in effectsByHandle)
		{
			buffEffect.OnRemoved(isPrematureRemoval);
		}
		foreach (BuffEffect effect in effectsByHandle)
		{
			this.RemoveFromTypeIndex(effect);
		}
		this.EffectHolder.Remove(handleId);
	}

	// Token: 0x06018BA9 RID: 101289 RVA: 0x006FC994 File Offset: 0x006FAB94
	private void Add(BuffEffect effect)
	{
		int activeHandleId = effect.ActiveHandleId;
		if (activeHandleId < 0)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			BaseBuffComponent buffComponent = this.BuffComponent;
			Entity entity = (buffComponent != null) ? buffComponent.Entity : null;
			string message = "invalid handleId when trying to add effect in holder.";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("handle", activeHandleId);
			instance.Warn(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (!this.EffectHolder.ContainsKey(activeHandleId))
		{
			this.EffectHolder[activeHandleId] = new List<BuffEffect>();
		}
		List<BuffEffect> list = this.EffectHolder[activeHandleId];
		using (List<BuffEffect>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == effect)
				{
					CombatLog instance2 = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Buff;
					BaseBuffComponent buffComponent2 = this.BuffComponent;
					Entity entity2 = (buffComponent2 != null) ? buffComponent2.Entity : null;
					string message2 = "duplicated handle when trying to add ExtraEffect.";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("handle", activeHandleId);
					instance2.Warn(flag2, entity2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return;
				}
			}
		}
		list.Add(effect);
		this.AddToTypeIndex(effect);
	}

	// Token: 0x06018BAA RID: 101290 RVA: 0x006FCA9C File Offset: 0x006FAC9C
	private void AddToTypeIndex(BuffEffect effect)
	{
		Type type = effect.GetType();
		List<BuffEffect> list;
		if (!this.EffectsByType.TryGetValue(type, out list))
		{
			list = new List<BuffEffect>();
			this.EffectsByType[type] = list;
		}
		list.Add(effect);
	}

	// Token: 0x06018BAB RID: 101291 RVA: 0x006FCADC File Offset: 0x006FACDC
	private void RemoveFromTypeIndex(BuffEffect effect)
	{
		List<BuffEffect> list;
		if (this.EffectsByType.TryGetValue(effect.GetType(), out list))
		{
			list.Remove(effect);
		}
	}

	// Token: 0x06018BAC RID: 101292 RVA: 0x006FCB06 File Offset: 0x006FAD06
	public void Clear()
	{
		this.EffectHolder.Clear();
		this.EffectsByType.Clear();
		this.ActivatedHandles.Clear();
	}

	// Token: 0x06018BAD RID: 101293 RVA: 0x006FCB29 File Offset: 0x006FAD29
	public IEnumerable<T> FilterById<[Nullable(0)] T>(EExtraEffectId effectId, [Nullable(new byte[]
	{
		2,
		1
	})] Func<T, bool> filterFunction = null) where T : BuffEffect
	{
		ExtraEffectManager.<FilterById>d__18<T> <FilterById>d__ = new ExtraEffectManager.<FilterById>d__18<T>(-2);
		<FilterById>d__.<>4__this = this;
		<FilterById>d__.<>3__effectId = effectId;
		<FilterById>d__.<>3__filterFunction = filterFunction;
		return <FilterById>d__;
	}

	// Token: 0x06018BAE RID: 101294 RVA: 0x006FCB47 File Offset: 0x006FAD47
	public IEnumerable<T> FilterById<[Nullable(0)] T>(EExtraEffectId[] effectIds, [Nullable(new byte[]
	{
		2,
		1
	})] Func<T, bool> filterFunction = null) where T : BuffEffect
	{
		ExtraEffectManager.<FilterById>d__19<T> <FilterById>d__ = new ExtraEffectManager.<FilterById>d__19<T>(-2);
		<FilterById>d__.<>4__this = this;
		<FilterById>d__.<>3__effectIds = effectIds;
		<FilterById>d__.<>3__filterFunction = filterFunction;
		return <FilterById>d__;
	}

	// Token: 0x06018BAF RID: 101295 RVA: 0x006FCB68 File Offset: 0x006FAD68
	public bool HasAnyById(EExtraEffectId[] effectIds)
	{
		if (this.EffectsByType.Count == 0)
		{
			return false;
		}
		foreach (KeyValuePair<Type, List<BuffEffect>> keyValuePair in this.EffectsByType)
		{
			if (keyValuePair.Value.Count > 0 && ExtraEffectManager.MatchAnyId(keyValuePair.Key, effectIds))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06018BB0 RID: 101296 RVA: 0x006FCBE8 File Offset: 0x006FADE8
	public void CollectById<[Nullable(0)] T>(EExtraEffectId[] effectIds, List<T> results) where T : BuffEffect
	{
		foreach (KeyValuePair<Type, List<BuffEffect>> keyValuePair in this.EffectsByType)
		{
			if (keyValuePair.Value.Count != 0 && ExtraEffectManager.MatchAnyId(keyValuePair.Key, effectIds))
			{
				foreach (BuffEffect buffEffect in keyValuePair.Value)
				{
					results.Add((T)((object)buffEffect));
				}
			}
		}
	}

	// Token: 0x06018BB1 RID: 101297 RVA: 0x006FCC9C File Offset: 0x006FAE9C
	private static bool MatchAnyId(Type effectType, EExtraEffectId[] effectIds)
	{
		for (int i = 0; i < effectIds.Length; i++)
		{
			Type buffEffectClass = ExtraEffectDefine.GetBuffEffectClass(effectIds[i]);
			if (buffEffectClass != null && buffEffectClass.IsAssignableFrom(effectType))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06018BB2 RID: 101298 RVA: 0x006FCCD8 File Offset: 0x006FAED8
	[NullableContext(0)]
	[return: Nullable(2)]
	public T FilterFirstById<T>(EExtraEffectId effectId, [Nullable(new byte[]
	{
		2,
		1
	})] Func<T, bool> filterFunction = null) where T : BuffEffect
	{
		Type buffEffectClass = ExtraEffectDefine.GetBuffEffectClass(effectId);
		if (buffEffectClass == null)
		{
			return default(T);
		}
		foreach (KeyValuePair<Type, List<BuffEffect>> keyValuePair in this.EffectsByType)
		{
			if (keyValuePair.Value.Count != 0 && buffEffectClass.IsAssignableFrom(keyValuePair.Key))
			{
				foreach (BuffEffect buffEffect in keyValuePair.Value)
				{
					T t = (T)((object)buffEffect);
					if (filterFunction == null || filterFunction(t))
					{
						return t;
					}
				}
			}
		}
		return default(T);
	}

	// Token: 0x06018BB3 RID: 101299 RVA: 0x006FCDBC File Offset: 0x006FAFBC
	[return: Nullable(2)]
	public T FilterFirstById<[Nullable(0)] T>(EExtraEffectId[] effectIds, [Nullable(new byte[]
	{
		2,
		1
	})] Func<T, bool> filterFunction = null) where T : BuffEffect
	{
		foreach (KeyValuePair<Type, List<BuffEffect>> keyValuePair in this.EffectsByType)
		{
			if (keyValuePair.Value.Count != 0 && ExtraEffectManager.MatchAnyId(keyValuePair.Key, effectIds))
			{
				foreach (BuffEffect buffEffect in keyValuePair.Value)
				{
					T t = (T)((object)buffEffect);
					if (filterFunction == null || filterFunction(t))
					{
						return t;
					}
				}
			}
		}
		return default(T);
	}

	// Token: 0x06018BB4 RID: 101300 RVA: 0x006FCE84 File Offset: 0x006FB084
	public IEnumerable<BuffEffect> GetAllEffects()
	{
		ExtraEffectManager.<GetAllEffects>d__25 <GetAllEffects>d__ = new ExtraEffectManager.<GetAllEffects>d__25(-2);
		<GetAllEffects>d__.<>4__this = this;
		return <GetAllEffects>d__;
	}

	// Token: 0x06018BB5 RID: 101301 RVA: 0x006FCE94 File Offset: 0x006FB094
	public IEnumerable<BuffEffect> GetEffectsByHandle(int handleId)
	{
		List<BuffEffect> result;
		if (this.EffectHolder.TryGetValue(handleId, out result))
		{
			return result;
		}
		return Array.Empty<BuffEffect>();
	}

	// Token: 0x0400C09C RID: 49308
	public Dictionary<int, List<BuffEffect>> EffectHolder = new Dictionary<int, List<BuffEffect>>();

	// Token: 0x0400C09D RID: 49309
	private readonly Dictionary<Type, List<BuffEffect>> EffectsByType = new Dictionary<Type, List<BuffEffect>>();

	// Token: 0x0400C09E RID: 49310
	protected readonly BaseBuffComponent BuffComponent;

	// Token: 0x0400C09F RID: 49311
	public HashSet<int> ActivatedHandles = new HashSet<int>();
}
