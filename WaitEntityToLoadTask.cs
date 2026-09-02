using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020034A8 RID: 13480
[NullableContext(1)]
[Nullable(0)]
public class WaitEntityToLoadTask : IStaticVariableResetter
{
	// Token: 0x0601C6D8 RID: 116440 RVA: 0x00885307 File Offset: 0x00883507
	static WaitEntityToLoadTask()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(WaitEntityToLoadTask.CreateStaticDefaultValue), new Action(WaitEntityToLoadTask.ResetStaticDefaultValue));
	}

	// Token: 0x0601C6D9 RID: 116441 RVA: 0x00885328 File Offset: 0x00883528
	public WaitEntityToLoadTask([Nullable(new byte[]
	{
		1,
		2,
		1
	})] Func<EntityHandle, Action<ELoadResultType>, ELoadResultType> loadEntityCallback, Action<EntityHandle, Action<ELoadResultType>> addEntityToAwake)
	{
		this.LoadEntityCallback = loadEntityCallback;
		this.AddEntityToAwake = addEntityToAwake;
	}

	// Token: 0x0601C6DA RID: 116442 RVA: 0x008853A9 File Offset: 0x008835A9
	public void OnInit()
	{
		this.RegisterEvents();
		this.InLoadingEntityCount = 0L;
	}

	// Token: 0x0601C6DB RID: 116443 RVA: 0x008853B9 File Offset: 0x008835B9
	public void OnClear()
	{
		this.UnregisterEvents();
		this.QueuedAwakeEntities.Clear();
		if (this.DelayTickTimerId != null)
		{
			TimerSystem.Instance.Remove(this.DelayTickTimerId);
			this.DelayTickTimerId = null;
		}
		this.FilterChain.Cleanup();
	}

	// Token: 0x0601C6DC RID: 116444 RVA: 0x008853F8 File Offset: 0x008835F8
	private void RegisterEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.EntityToLoadFilterCreated, new Action<EntityToLoadFilter>(this.OnEntityToLoadFilterCreated));
		Singleton<EventSystem>.Instance.Add(EEventName.EntityToLoadFilterDestroyed, new Action<EntityToLoadFilter>(this.OnEntityToLoadFilterDestroyed));
		Singleton<EventSystem>.Instance.Add<IEntityToLoadParam>(EEventName.EntityToLoadParamUpdated, new Action<IEntityToLoadParam>(this.DelayInvoke));
	}

	// Token: 0x0601C6DD RID: 116445 RVA: 0x0088545C File Offset: 0x0088365C
	private void UnregisterEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.EntityToLoadFilterCreated, new Action<EntityToLoadFilter>(this.OnEntityToLoadFilterCreated));
		Singleton<EventSystem>.Instance.Remove(EEventName.EntityToLoadFilterDestroyed, new Action<EntityToLoadFilter>(this.OnEntityToLoadFilterDestroyed));
		Singleton<EventSystem>.Instance.Remove(EEventName.EntityToLoadParamUpdated, new <>f__AnonymousDelegate12<IEntityToLoadParam>(this.DelayInvoke));
	}

	// Token: 0x0601C6DE RID: 116446 RVA: 0x008854BD File Offset: 0x008836BD
	private void OnEntityToLoadFilterCreated(EntityToLoadFilter filter)
	{
		this.FilterChain.AddFilter(filter);
		this.DelayInvoke(null);
	}

	// Token: 0x0601C6DF RID: 116447 RVA: 0x008854D2 File Offset: 0x008836D2
	private void OnEntityToLoadFilterDestroyed(EntityToLoadFilter filter)
	{
		this.FilterChain.RemoveFilter(filter);
		this.DelayInvoke(null);
	}

	// Token: 0x0601C6E0 RID: 116448 RVA: 0x008854E8 File Offset: 0x008836E8
	private static EntityHandleCallbackPair GetOrCreatePair(EntityHandle handle, [Nullable(2)] Action<ELoadResultType> callback, long creatureDataId, int pbDataId)
	{
		EntityHandleCallbackPair entityHandleCallbackPair = WaitEntityToLoadTask.EntityHandleCallbackPairPool.Get();
		if (entityHandleCallbackPair == null)
		{
			entityHandleCallbackPair = WaitEntityToLoadTask.EntityHandleCallbackPairPool.Create();
		}
		entityHandleCallbackPair.Handle = handle;
		entityHandleCallbackPair.CreatureDataId = creatureDataId;
		entityHandleCallbackPair.PbDataId = pbDataId;
		entityHandleCallbackPair.Priority = (float)handle.Priority;
		entityHandleCallbackPair.AngleRatio = 0f;
		entityHandleCallbackPair.Order = 0;
		entityHandleCallbackPair.AddCallback(callback);
		EntityHandleCallbackPair entityHandleCallbackPair2 = entityHandleCallbackPair;
		int version = entityHandleCallbackPair2.Version;
		entityHandleCallbackPair2.Version = version + 1;
		return entityHandleCallbackPair;
	}

	// Token: 0x0601C6E1 RID: 116449 RVA: 0x0088555C File Offset: 0x0088375C
	[return: Nullable(2)]
	private EntityHandleCallbackPair FindEntity(EntityHandle handle)
	{
		EntityHandleCallbackPair entityHandleCallbackPair = null;
		EntityHandleCallbackPair entityHandleCallbackPair2;
		if (this.QueuedAwakeEntities.TryGetValue(handle, out entityHandleCallbackPair2))
		{
			entityHandleCallbackPair = entityHandleCallbackPair2;
		}
		EntityHandleCallbackPair entityHandleCallbackPair3;
		if (entityHandleCallbackPair == null && this.FilterChain.QueuedEntitiesLookup.TryGetValue(handle, out entityHandleCallbackPair3))
		{
			entityHandleCallbackPair = entityHandleCallbackPair3;
		}
		return entityHandleCallbackPair;
	}

	// Token: 0x0601C6E2 RID: 116450 RVA: 0x00885598 File Offset: 0x00883798
	private static bool ShouldPreloadEntity(EntityHandle handle)
	{
		CreatureDataComponent component = handle.Entity.GetComponent<CreatureDataComponent>();
		if (PreloadSetting.UseNewPreload && component.GetPreloadFinished())
		{
			return false;
		}
		EEntityType entityType = component.GetEntityType();
		if (entityType == EEntityType.Custom || entityType == EEntityType.PlayerEntity)
		{
			if (entityType == EEntityType.PlayerEntity)
			{
				handle.Priority = ResourceSystem.EResourceLoadPriority.Max;
			}
			return false;
		}
		return true;
	}

	// Token: 0x0601C6E3 RID: 116451 RVA: 0x008855E4 File Offset: 0x008837E4
	public unsafe void QueueToInvoke(EntityHandle handle, [Nullable(2)] Action<ELoadResultType> callback, long creatureDataId, int pbDataId)
	{
		EntityHandleCallbackPair entityHandleCallbackPair = this.FindEntity(handle);
		if (entityHandleCallbackPair != null)
		{
			entityHandleCallbackPair.AddCallback(callback);
			return;
		}
		entityHandleCallbackPair = WaitEntityToLoadTask.GetOrCreatePair(handle, callback, creatureDataId, pbDataId);
		if (!WaitEntityToLoadTask.ShouldPreloadEntity(handle))
		{
			if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Preload;
				ELogAuthor author = ELogAuthor.XY;
				string message = "预加载实体:不需要预加载，直接唤醒";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", handle.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CreatureDataId", entityHandleCallbackPair.CreatureDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PbDataId", entityHandleCallbackPair.PbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Priority", entityHandleCallbackPair.Priority);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("Order", entityHandleCallbackPair.Order);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("Version", entityHandleCallbackPair.Version);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			}
			this.PushToAwake(entityHandleCallbackPair);
			return;
		}
		this.FilterChain.AddPair(entityHandleCallbackPair);
		this.DelayInvoke(null);
	}

	// Token: 0x0601C6E4 RID: 116452 RVA: 0x00885733 File Offset: 0x00883933
	public void DelayInvoke(IEntityToLoadParam _ = null)
	{
		if (this.DelayTickTimerId == null && this.FilterChain.QueuedHeap.Size > 0)
		{
			this.DelayTickTimerId = TimerSystem.Instance.Next(delegate(float _)
			{
				this.DelayTickTimerId = null;
				this.ValidateToInvoke();
			}, null, null);
		}
	}

	// Token: 0x0601C6E5 RID: 116453 RVA: 0x0088576E File Offset: 0x0088396E
	public void Flush()
	{
		if (this.DelayTickTimerId != null)
		{
			TimerSystem.Instance.Remove(this.DelayTickTimerId);
			this.DelayTickTimerId = null;
		}
		while (!this.FilterChain.QueuedHeap.Empty)
		{
			this.InvokeTop();
		}
	}

	// Token: 0x0601C6E6 RID: 116454 RVA: 0x008857AC File Offset: 0x008839AC
	public unsafe void RemoveEntity(EntityHandle entityHandle)
	{
		EntityHandleCallbackPair entityHandleCallbackPair = this.FindEntity(entityHandle);
		if (entityHandleCallbackPair == null)
		{
			return;
		}
		this.FilterChain.RemovePair(entityHandleCallbackPair);
		this.InvokeAwakeCallback(entityHandleCallbackPair, ELoadResultType.Destroy);
		if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Preload;
			ELogAuthor author = ELogAuthor.XY;
			string message = "预加载实体:移除加载队列";
			<>y__InlineArray9<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray9<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RemoveType", "Outside");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", entityHandle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("CreatureDataId", entityHandleCallbackPair.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("PbDataId", entityHandleCallbackPair.PbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("AngleRatio", entityHandleCallbackPair.AngleRatio);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("Priority", entityHandleCallbackPair.Priority);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("Order", entityHandleCallbackPair.Order);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("Version", entityHandleCallbackPair.Version);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 8) = new ValueTuple<string, object>("Remain", this.FilterChain.QueuedHeap.Size);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 9));
		}
	}

	// Token: 0x0601C6E7 RID: 116455 RVA: 0x00885944 File Offset: 0x00883B44
	private unsafe void InvokeAwakeCallback(EntityHandleCallbackPair pair, ELoadResultType result)
	{
		if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Preload;
			ELogAuthor author = ELogAuthor.XY;
			string message = "预加载实体:执行加载回调";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", pair.Handle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CreatureDataId", pair.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PbDataId", pair.PbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Priority", pair.Priority);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("Order", pair.Order);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("Version", pair.Version);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("Result", result);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
		}
		this.QueuedAwakeEntities.Remove(pair.Handle);
		pair.InvokeCallbacks(result);
		pair.ClearCallbacks();
		WaitEntityToLoadTask.EntityHandleCallbackPairPool.Put(pair);
	}

	// Token: 0x0601C6E8 RID: 116456 RVA: 0x00885A9C File Offset: 0x00883C9C
	private void ValidateToAwake(EntityHandleCallbackPair pair, ELoadResultType result, long? version = null)
	{
		long pairVersion = version ?? ((long)pair.Version);
		if (!this.QueuedAwakeEntities.ContainsKey(pair.Handle) || pairVersion != (long)pair.Version)
		{
			return;
		}
		if (result2 == ELoadResultType.Done || result2 == ELoadResultType.Fail)
		{
			this.AddEntityToAwake(pair.Handle, delegate(ELoadResultType result)
			{
				if (!this.QueuedAwakeEntities.ContainsKey(pair.Handle) || pairVersion != (long)pair.Version)
				{
					return;
				}
				this.InvokeAwakeCallback(pair, result);
			});
			return;
		}
		this.InvokeAwakeCallback(pair, result2);
	}

	// Token: 0x0601C6E9 RID: 116457 RVA: 0x00885B48 File Offset: 0x00883D48
	private void PushToAwake(EntityHandleCallbackPair pair)
	{
		this.QueuedAwakeEntities[pair.Handle] = pair;
		this.ValidateToAwake(pair, ELoadResultType.Done, null);
	}

	// Token: 0x0601C6EA RID: 116458 RVA: 0x00885B78 File Offset: 0x00883D78
	private void Invoke(EntityHandleCallbackPair pair)
	{
		WaitEntityToLoadTask.<>c__DisplayClass28_0 CS$<>8__locals1 = new WaitEntityToLoadTask.<>c__DisplayClass28_0();
		CS$<>8__locals1.pair = pair;
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.loadDone = false;
		CS$<>8__locals1.timeoutCheckTimerId = null;
		CS$<>8__locals1.isTimeout = false;
		CS$<>8__locals1.pairVersion = CS$<>8__locals1.pair.Version;
		this.InLoadingEntityCount += 1L;
		this.QueuedAwakeEntities[CS$<>8__locals1.pair.Handle] = CS$<>8__locals1.pair;
		ELoadResultType eloadResultType = this.LoadEntityCallback(CS$<>8__locals1.pair.Handle, new Action<ELoadResultType>(CS$<>8__locals1.<Invoke>g__callback|2));
		if (eloadResultType != ELoadResultType.Loading)
		{
			CS$<>8__locals1.<Invoke>g__callback|2(eloadResultType);
			return;
		}
		CS$<>8__locals1.<Invoke>g__beginTimeoutCheck|1();
	}

	// Token: 0x0601C6EB RID: 116459 RVA: 0x00885C20 File Offset: 0x00883E20
	private bool HasEntityForLoading()
	{
		return this.FilterChain.QueuedHeap.Size > 0 && this.InLoadingEntityCount < this.FilterChain.EntityToLoadParam.MaxLoadingCount && this.CurrentEntityFrameInterval >= this.FilterChain.EntityToLoadParam.LoadingInterval;
	}

	// Token: 0x0601C6EC RID: 116460 RVA: 0x00885C78 File Offset: 0x00883E78
	private unsafe void InvokeTop()
	{
		EntityHandleCallbackPair entityHandleCallbackPair = this.FilterChain.PopTopPair();
		if (entityHandleCallbackPair != null)
		{
			if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Preload;
				ELogAuthor author = ELogAuthor.XY;
				string message = "预加载实体:移除加载队列";
				<>y__InlineArray9<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray9<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RemoveType", "InvokeTop");
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", entityHandleCallbackPair.Handle.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("CreatureDataId", entityHandleCallbackPair.CreatureDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("PbDataId", entityHandleCallbackPair.PbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("AngleRatio", entityHandleCallbackPair.AngleRatio);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("Priority", entityHandleCallbackPair.Priority);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("Order", entityHandleCallbackPair.Order);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("Version", entityHandleCallbackPair.Version);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 8) = new ValueTuple<string, object>("Remain", this.FilterChain.QueuedHeap.Size);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 9));
			}
			this.Invoke(entityHandleCallbackPair);
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.Preload, ELogAuthor.XDW, "预加载实体:调用InvokeTop之前需要确保优先队列不为空", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601C6ED RID: 116461 RVA: 0x00885E2C File Offset: 0x0088402C
	private void StartUpdateFrameInterval()
	{
		int frame = Singleton<Time>.Instance.Frame;
		if ((long)frame > this.CachedFrame)
		{
			this.CurrentEntityFrameInterval += (long)frame - this.CachedFrame;
			this.CachedFrame = (long)frame;
		}
	}

	// Token: 0x0601C6EE RID: 116462 RVA: 0x00885E6C File Offset: 0x0088406C
	private void EndUpdateFrameInternal()
	{
		if (this.FilterChain.QueuedHeap.Size == 0 || this.InLoadingEntityCount >= this.FilterChain.EntityToLoadParam.MaxLoadingCount || this.CurrentEntityFrameInterval >= this.FilterChain.EntityToLoadParam.LoadingInterval)
		{
			this.CurrentEntityFrameInterval = 0L;
		}
	}

	// Token: 0x0601C6EF RID: 116463 RVA: 0x00885EC4 File Offset: 0x008840C4
	private void ValidateToInvoke()
	{
		this.StartUpdateFrameInterval();
		while (this.HasEntityForLoading())
		{
			this.Sort();
			this.InvokeTop();
		}
		this.EndUpdateFrameInternal();
		if (this.FilterChain.QueuedHeap.Size > 0 && this.InLoadingEntityCount < this.FilterChain.EntityToLoadParam.MaxLoadingCount)
		{
			this.DelayInvoke(null);
		}
	}

	// Token: 0x0601C6F0 RID: 116464 RVA: 0x00885F25 File Offset: 0x00884125
	private void Sort()
	{
		if ((long)this.FilterChain.QueuedHeap.Size > this.FilterChain.EntityToLoadParam.MaxLoadingCount - this.InLoadingEntityCount)
		{
			this.FilterChain.UpdatePriority(this.GetPlayerVelocity());
		}
	}

	// Token: 0x0601C6F1 RID: 116465 RVA: 0x00885F62 File Offset: 0x00884162
	private global::Vector GetPlayerVelocity()
	{
		if (WaitEntityToLoadTask.GetPlayerVelocityOverride != null)
		{
			return WaitEntityToLoadTask.GetPlayerVelocityOverride();
		}
		return global::Vector.ZeroVectorProxy;
	}

	// Token: 0x0601C6F2 RID: 116466 RVA: 0x00885F7B File Offset: 0x0088417B
	public static void CreateStaticDefaultValue()
	{
		WaitEntityToLoadTask.EntityHandleCallbackPairPool = new Pool<EntityHandleCallbackPair>(200, () => new EntityHandleCallbackPair(), null);
	}

	// Token: 0x0601C6F3 RID: 116467 RVA: 0x00885FAC File Offset: 0x008841AC
	public static void ResetStaticDefaultValue()
	{
		WaitEntityToLoadTask.GetPlayerVelocityOverride = null;
		WaitEntityToLoadTask.EntityHandleCallbackPairPool = null;
	}

	// Token: 0x0400E4C0 RID: 58560
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Func<global::Vector> GetPlayerVelocityOverride;

	// Token: 0x0400E4C1 RID: 58561
	[Nullable(new byte[]
	{
		1,
		2,
		1
	})]
	private readonly Func<EntityHandle, Action<ELoadResultType>, ELoadResultType> LoadEntityCallback = ([Nullable(2)] EntityHandle _, Action<ELoadResultType> _) => ELoadResultType.None;

	// Token: 0x0400E4C2 RID: 58562
	private readonly Action<EntityHandle, Action<ELoadResultType>> AddEntityToAwake = delegate(EntityHandle _, Action<ELoadResultType> _)
	{
	};

	// Token: 0x0400E4C3 RID: 58563
	private static Pool<EntityHandleCallbackPair> EntityHandleCallbackPairPool;

	// Token: 0x0400E4C4 RID: 58564
	private readonly Dictionary<EntityHandle, EntityHandleCallbackPair> QueuedAwakeEntities = new Dictionary<EntityHandle, EntityHandleCallbackPair>();

	// Token: 0x0400E4C5 RID: 58565
	private readonly EntityToLoadFilterChain FilterChain = EntityToLoadFilterChain.Create();

	// Token: 0x0400E4C6 RID: 58566
	private long InLoadingEntityCount;

	// Token: 0x0400E4C7 RID: 58567
	private long CurrentEntityFrameInterval;

	// Token: 0x0400E4C8 RID: 58568
	[Nullable(2)]
	private TimerHandle DelayTickTimerId;

	// Token: 0x0400E4C9 RID: 58569
	private long CachedFrame;
}
