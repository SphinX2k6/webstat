using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003458 RID: 13400
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class EntityToLoadFilterChain : FilterChain<EntityHandle>
{
	// Token: 0x1700265C RID: 9820
	// (get) Token: 0x0601C1A9 RID: 115113 RVA: 0x00862381 File Offset: 0x00860581
	public EntityToLoadParam EntityToLoadParam { get; } = new EntityToLoadParam();

	// Token: 0x1700265D RID: 9821
	// (get) Token: 0x0601C1AA RID: 115114 RVA: 0x00862389 File Offset: 0x00860589
	public PriorityQueue<EntityHandleCallbackPair> QueuedHeap
	{
		get
		{
			return this.QueuedHeapInternal;
		}
	}

	// Token: 0x1700265E RID: 9822
	// (get) Token: 0x0601C1AB RID: 115115 RVA: 0x00862391 File Offset: 0x00860591
	public IReadOnlyDictionary<EntityHandle, EntityHandleCallbackPair> QueuedEntitiesLookup
	{
		get
		{
			return this.QueuedEntitiesLookupInternal;
		}
	}

	// Token: 0x0601C1AC RID: 115116 RVA: 0x0086239C File Offset: 0x0086059C
	public EntityToLoadFilterChain()
	{
		this.QueuedHeapInternal = new PriorityQueue<EntityHandleCallbackPair>(delegate(EntityHandleCallbackPair a, EntityHandleCallbackPair b)
		{
			if (Math.Abs(a.Priority - b.Priority) < 0.0001f)
			{
				return a.Order.CompareTo(b.Order);
			}
			return a.Priority.CompareTo(b.Priority);
		});
	}

	// Token: 0x0601C1AD RID: 115117 RVA: 0x0086245A File Offset: 0x0086065A
	public static EntityToLoadFilterChain Create()
	{
		EntityToLoadFilterChain entityToLoadFilterChain = new EntityToLoadFilterChain();
		entityToLoadFilterChain.Init();
		return entityToLoadFilterChain;
	}

	// Token: 0x0601C1AE RID: 115118 RVA: 0x00862467 File Offset: 0x00860667
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Add<IEntityToLoadParam>(EEventName.EntityToLoadParamUpdated, new Action<IEntityToLoadParam>(this.OnEntityToLoadParamUpdated));
		return true;
	}

	// Token: 0x0601C1AF RID: 115119 RVA: 0x00862486 File Offset: 0x00860686
	protected override bool OnCleanup()
	{
		this.QueuedHeapInternal.Clear();
		this.QueuedEntitiesPriorityDirty.Clear();
		this.QueuedEntitiesLookupInternal.Clear();
		Singleton<EventSystem>.Instance.Remove<IEntityToLoadParam>(EEventName.EntityToLoadParamUpdated, new Action<IEntityToLoadParam>(this.OnEntityToLoadParamUpdated));
		return true;
	}

	// Token: 0x0601C1B0 RID: 115120 RVA: 0x008624C8 File Offset: 0x008606C8
	private unsafe void OnEntityToLoadParamUpdated(object param)
	{
		EntityToLoadParam entityToLoadParam = param as EntityToLoadParam;
		if (entityToLoadParam == null)
		{
			return;
		}
		if (entityToLoadParam.MaxLoadingCount < this.EntityToLoadParam.MaxLoadingCount)
		{
			this.EntityToLoadParam.MaxLoadingCount = entityToLoadParam.MaxLoadingCount;
			this.EntityToLoadParam.MaxLoadingDebugName = entityToLoadParam.MaxLoadingDebugName;
			if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Preload;
				ELogAuthor author = ELogAuthor.XY;
				string message = "预加载实体:更新最大加载数量";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MaxLoadingCount", entityToLoadParam.MaxLoadingCount);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DebugName", entityToLoadParam.MaxLoadingDebugName);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		if (entityToLoadParam.LoadingInterval > this.EntityToLoadParam.LoadingInterval)
		{
			this.EntityToLoadParam.LoadingInterval = entityToLoadParam.LoadingInterval;
			this.EntityToLoadParam.LoadingIntervalDebugName = entityToLoadParam.LoadingIntervalDebugName;
			if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Preload;
				ELogAuthor author2 = ELogAuthor.XY;
				string message2 = "预加载实体:更新帧间隔";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("FrameInterval", entityToLoadParam.LoadingInterval);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("DebugName", entityToLoadParam.LoadingIntervalDebugName);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			}
		}
	}

	// Token: 0x0601C1B1 RID: 115121 RVA: 0x0086262C File Offset: 0x0086082C
	private void RefreshEntityToLoadParam()
	{
		foreach (Filter<EntityHandle> filter in base.GetAllFilters())
		{
			this.OnEntityToLoadParamUpdated(filter as EntityToLoadFilter);
		}
	}

	// Token: 0x0601C1B2 RID: 115122 RVA: 0x00862660 File Offset: 0x00860860
	private void UpdateOrder(EntityHandleCallbackPair pair)
	{
		if (this.QueuedHeapInternal.Size == 0)
		{
			this.QueueOrder = 0;
		}
		int queueOrder = this.QueueOrder;
		this.QueueOrder = queueOrder + 1;
		pair.Order = queueOrder;
	}

	// Token: 0x0601C1B3 RID: 115123 RVA: 0x00862698 File Offset: 0x00860898
	private void UpdateEntityPriority(EntityHandleCallbackPair pair)
	{
		EntityHandle handle = pair.Handle;
		CreatureDataComponent creatureDataComponent;
		if (handle == null)
		{
			creatureDataComponent = null;
		}
		else
		{
			WorldEntity entity = handle.Entity;
			creatureDataComponent = ((entity != null) ? entity.GetComponent<CreatureDataComponent>() : null);
		}
		CreatureDataComponent creatureDataComponent2 = creatureDataComponent;
		if (creatureDataComponent2 == null)
		{
			return;
		}
		FVectorDouble location = creatureDataComponent2.GetLocation();
		Singleton<MathUtils>.Instance.CommonTempVector.DeepCopy(location);
		double num = Vector.DistSquared(Singleton<MathUtils>.Instance.CommonTempVector, this.CachedCharacterLocation);
		this.CachedCharacterLocation.Subtraction(Singleton<MathUtils>.Instance.CommonTempVector, this.TempEntityForward);
		float num2 = (float)((this.TempEntityForward.Normalize(9.99999993922529E-09) ? Vector.DotProduct(this.TempEntityForward, this.CharacterVelocityForward) : -1.0) * 0.5 + 0.5);
		pair.AngleRatio = num2;
		pair.Priority = (float)(num * (double)num2);
	}

	// Token: 0x0601C1B4 RID: 115124 RVA: 0x0086276C File Offset: 0x0086096C
	protected override void OnPassedTargetModified(EntityHandle target, bool isAdd)
	{
		if (!this.QueuedEntitiesLookupInternal.ContainsKey(target))
		{
			return;
		}
		EntityHandleCallbackPair item = this.QueuedEntitiesLookupInternal[target];
		if (isAdd)
		{
			this.QueuedHeapInternal.Push(item);
			return;
		}
		this.QueuedHeapInternal.Remove(item);
	}

	// Token: 0x0601C1B5 RID: 115125 RVA: 0x008627B2 File Offset: 0x008609B2
	public override void AddFilter(Filter<EntityHandle> filter)
	{
		base.AddFilter(filter);
		this.OnEntityToLoadParamUpdated(filter);
	}

	// Token: 0x0601C1B6 RID: 115126 RVA: 0x008627C2 File Offset: 0x008609C2
	public override bool RemoveFilter(Filter<EntityHandle> filter)
	{
		this.RefreshEntityToLoadParam();
		return base.RemoveFilter(filter);
	}

	// Token: 0x0601C1B7 RID: 115127 RVA: 0x008627D4 File Offset: 0x008609D4
	public unsafe void AddPair(EntityHandleCallbackPair pair)
	{
		this.UpdateOrder(pair);
		this.QueuedEntitiesLookupInternal[pair.Handle] = pair;
		this.QueuedEntitiesPriorityDirty.Add(pair.Handle);
		base.AddTarget(pair.Handle, EFilterType.Top);
		if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Preload;
			ELogAuthor author = ELogAuthor.XY;
			string message = "预加载实体:进入加载队列";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", pair.Handle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CreatureDataId", pair.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PbDataId", pair.PbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Priority", pair.Priority);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("Order", pair.Order);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("Version", pair.Version);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("Remain", this.QueuedHeapInternal.Size);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
		}
	}

	// Token: 0x0601C1B8 RID: 115128 RVA: 0x00862943 File Offset: 0x00860B43
	public void RemovePair(EntityHandleCallbackPair pair)
	{
		if (this.QueuedEntitiesLookupInternal.Remove(pair.Handle))
		{
			this.QueuedHeapInternal.Remove(pair);
			base.RemoveTarget(pair.Handle);
		}
	}

	// Token: 0x0601C1B9 RID: 115129 RVA: 0x00862974 File Offset: 0x00860B74
	[NullableContext(2)]
	public EntityHandleCallbackPair PopTopPair()
	{
		if (this.QueuedHeapInternal.Size > 0)
		{
			EntityHandleCallbackPair entityHandleCallbackPair = this.QueuedHeapInternal.Pop();
			if (this.QueuedEntitiesLookupInternal.Remove(entityHandleCallbackPair.Handle))
			{
				base.RemoveTarget(entityHandleCallbackPair.Handle);
			}
			return entityHandleCallbackPair;
		}
		return null;
	}

	// Token: 0x0601C1BA RID: 115130 RVA: 0x008629C0 File Offset: 0x00860BC0
	public void UpdatePriority(Vector playerVelocity)
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		CharacterActorComponent characterActorComponent;
		if (getCurrentEntity == null)
		{
			characterActorComponent = null;
		}
		else
		{
			WorldEntity entity = getCurrentEntity.Entity;
			characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
		}
		CharacterActorComponent characterActorComponent2 = characterActorComponent;
		if (characterActorComponent2 == null)
		{
			return;
		}
		if (!Vector.PointsAreSame(this.CachedCharacterLocation, characterActorComponent2.ActorLocationProxy) || !Vector.PointsAreSame(this.CachedCharacterForward, characterActorComponent2.ActorForwardProxy))
		{
			this.CachedCharacterLocation.DeepCopy(characterActorComponent2.ActorLocationProxy);
			this.CachedCharacterForward.DeepCopy(characterActorComponent2.ActorForwardProxy);
			this.CachedCharacterForward.AdditionEqual(playerVelocity).GetSafeNormal(this.CharacterVelocityForward, 9.99999993922529E-09);
			this.QueuedEntitiesPriorityDirty.Clear();
			foreach (EntityHandleCallbackPair pair in this.QueuedEntitiesLookupInternal.Values)
			{
				this.UpdateEntityPriority(pair);
			}
			this.QueuedHeapInternal.Heapify();
			return;
		}
		if (this.QueuedEntitiesPriorityDirty.Count > 0)
		{
			foreach (EntityHandle key in this.QueuedEntitiesPriorityDirty)
			{
				EntityHandleCallbackPair pair2;
				if (this.QueuedEntitiesLookupInternal.TryGetValue(key, out pair2))
				{
					this.UpdateEntityPriority(pair2);
				}
			}
			this.QueuedEntitiesPriorityDirty.Clear();
			this.QueuedHeapInternal.Heapify();
		}
	}

	// Token: 0x0400E2F3 RID: 58099
	private readonly PriorityQueue<EntityHandleCallbackPair> QueuedHeapInternal;

	// Token: 0x0400E2F4 RID: 58100
	private readonly Dictionary<EntityHandle, EntityHandleCallbackPair> QueuedEntitiesLookupInternal = new Dictionary<EntityHandle, EntityHandleCallbackPair>();

	// Token: 0x0400E2F5 RID: 58101
	private readonly List<EntityHandle> QueuedEntitiesPriorityDirty = new List<EntityHandle>();

	// Token: 0x0400E2F6 RID: 58102
	private readonly Vector CachedCharacterLocation = Vector.Create();

	// Token: 0x0400E2F7 RID: 58103
	private readonly Vector CachedCharacterForward = Vector.Create();

	// Token: 0x0400E2F8 RID: 58104
	private readonly Vector CharacterVelocityForward = Vector.Create();

	// Token: 0x0400E2F9 RID: 58105
	private readonly Vector TempEntityForward = Vector.Create();

	// Token: 0x0400E2FA RID: 58106
	private readonly Stat UpdatePriorityStat = Stat.Create("WaitEntityToLoadTask.UpdatePriority", "", "");

	// Token: 0x0400E2FB RID: 58107
	private readonly Stat RefreshEntityToLoadParamStat = Stat.Create("EntityToLoadFilterChain.RefreshEntityToLoadParamStat", "", "");

	// Token: 0x0400E2FC RID: 58108
	private int QueueOrder;
}
