using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002E24 RID: 11812
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class CharacterController : ControllerBase<CharacterController>
{
	// Token: 0x1700205D RID: 8285
	// (get) Token: 0x06017E43 RID: 97859 RVA: 0x006B186C File Offset: 0x006AFA6C
	protected override bool IsTickEvenPausedInternal
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06017E44 RID: 97860 RVA: 0x006B186F File Offset: 0x006AFA6F
	protected override bool OnInit()
	{
		this.LastDate = new DateTime?(DateTime.Now);
		return true;
	}

	// Token: 0x06017E45 RID: 97861 RVA: 0x006B1882 File Offset: 0x006AFA82
	protected override void OnTick(float deltaTime)
	{
		if (!this.IsQueueEmpty())
		{
			this.ConsumeQueue();
		}
		if (Singleton<Net>.Instance.IsFinishLogin())
		{
			this.TestMessage();
		}
	}

	// Token: 0x06017E46 RID: 97862 RVA: 0x006B18A8 File Offset: 0x006AFAA8
	private UniTask TestMessage()
	{
		CharacterController.<TestMessage>d__6 <TestMessage>d__;
		<TestMessage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TestMessage>d__.<>4__this = this;
		<TestMessage>d__.<>1__state = -1;
		<TestMessage>d__.<>t__builder.Start<CharacterController.<TestMessage>d__6>(ref <TestMessage>d__);
		return <TestMessage>d__.<>t__builder.Task;
	}

	// Token: 0x06017E47 RID: 97863 RVA: 0x006B18EB File Offset: 0x006AFAEB
	private bool IsQueueEmpty()
	{
		return this.IsEmpty();
	}

	// Token: 0x06017E48 RID: 97864 RVA: 0x006B18F3 File Offset: 0x006AFAF3
	private void ConsumeQueue()
	{
		this.AwakeEntity();
	}

	// Token: 0x06017E49 RID: 97865 RVA: 0x006B18FB File Offset: 0x006AFAFB
	public bool InitData<[Nullable(0)] T>(EntityHandle handle, T entity, [Nullable(2)] IEntityArgs args = null) where T : Entity
	{
		if (!Singleton<EntitySystem>.Instance.InitData<T>(entity, args))
		{
			ModelBase<CharacterModel>.Instance.ClearHandle(handle);
			return false;
		}
		return true;
	}

	// Token: 0x06017E4A RID: 97866 RVA: 0x006B1919 File Offset: 0x006AFB19
	public bool Respawn<[Nullable(0)] T>(EntityHandle handle, T entity, int priority = 0, [Nullable(2)] IEntityArgs args = null) where T : Entity
	{
		if (!Singleton<EntitySystem>.Instance.Respawn<T>(entity, true, priority, args))
		{
			ModelBase<CharacterModel>.Instance.ClearHandle(handle);
			return false;
		}
		return true;
	}

	// Token: 0x06017E4B RID: 97867 RVA: 0x006B193C File Offset: 0x006AFB3C
	public unsafe void AddEntityToAwakeQueue(EntityHandle handle, Action<bool> callback)
	{
		CharacterController.<>c__DisplayClass11_0 CS$<>8__locals1 = new CharacterController.<>c__DisplayClass11_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.handle = handle;
		CS$<>8__locals1.callback = callback;
		if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[实体生命周期:创建实体] 进入唤醒队列";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", CS$<>8__locals1.handle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CreatureDataId", CS$<>8__locals1.handle.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PbDataId", CS$<>8__locals1.handle.PbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Priority", CS$<>8__locals1.handle.Priority);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		CS$<>8__locals1.initSuccess = false;
		ModelBase<CharacterModel>.Instance.PushAwakeHandler(CS$<>8__locals1.handle, new Func<bool>(CS$<>8__locals1.<AddEntityToAwakeQueue>g__initHandle|0), new Func<bool>(CS$<>8__locals1.<AddEntityToAwakeQueue>g__startHandle|1));
	}

	// Token: 0x06017E4C RID: 97868 RVA: 0x006B1A60 File Offset: 0x006AFC60
	public unsafe bool InitEntity(EntityHandle handle)
	{
		if (!handle.Valid)
		{
			return false;
		}
		Entity entity = handle.Entity;
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (component.GetRemoveState())
		{
			return false;
		}
		if (!Singleton<EntitySystem>.Instance.Init(entity))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[实体生命周期:创建实体] 实体执行Init失败，创建实体失败。";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", handle.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", handle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PbDataId", component.GetPbDataId());
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			Singleton<EventSystem>.Instance.Emit<long>(EEventName.CreateEntityFail, handle.CreatureDataId);
			return false;
		}
		if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "[实体生命周期:创建实体] 实体执行Init成功";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CreatureDataId", handle.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("EntityId", handle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("PbDataId", component.GetPbDataId());
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
		return true;
	}

	// Token: 0x06017E4D RID: 97869 RVA: 0x006B1BD8 File Offset: 0x006AFDD8
	public unsafe bool StartEntity(EntityHandle handle)
	{
		if (!handle.Valid)
		{
			return false;
		}
		CreatureDataComponent component = handle.Entity.GetComponent<CreatureDataComponent>();
		if (component.GetRemoveState())
		{
			return false;
		}
		Entity entity = handle.Entity;
		if (!Singleton<EntitySystem>.Instance.Start(entity))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[实体生命周期:创建实体] 实体执行Start失败，创建实体失败。";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", handle.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", handle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PbDataId", component.GetPbDataId());
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			Singleton<EventSystem>.Instance.Emit<long>(EEventName.CreateEntityFail, handle.CreatureDataId);
			return false;
		}
		if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "[实体生命周期:创建实体] 实体执行Start成功";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CreatureDataId", handle.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("EntityId", handle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("PbDataId", component.GetPbDataId());
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
		return true;
	}

	// Token: 0x06017E4E RID: 97870 RVA: 0x006B1D54 File Offset: 0x006AFF54
	public void ActivateEntity(EntityHandle handle)
	{
		if (!handle.Valid)
		{
			return;
		}
		Entity entity = handle.Entity;
		Singleton<EntitySystem>.Instance.Activate(entity);
		entity.SetTimeDilation(Singleton<Time>.Instance.TimeDilation);
	}

	// Token: 0x06017E4F RID: 97871 RVA: 0x006B1D8C File Offset: 0x006AFF8C
	[NullableContext(2)]
	public bool Destroy(EntityHandle handle)
	{
		if (handle == null || !handle.Valid)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "Destroy的entity无效，可能的原因有:1、创建失败 2、实体重复销毁";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", (handle != null) ? new int?(handle.Id) : null);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		ModelBase<CharacterModel>.Instance.ClearHandle(handle);
		WorldEntity entity = handle.Entity;
		handle.Entity = null;
		ModelBase<CharacterModel>.Instance.EntityPool.RemoveExternal(entity);
		return Singleton<EntitySystem>.Instance.Destroy<WorldEntity>(entity);
	}

	// Token: 0x06017E50 RID: 97872 RVA: 0x006B1E24 File Offset: 0x006B0024
	[NullableContext(2)]
	public bool DestroyToLru(EntityHandle handle)
	{
		if (handle == null || !handle.Valid)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "Destroy的entity无效，可能的原因有:1、创建失败 2、实体重复销毁";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", (handle != null) ? new int?(handle.Id) : null);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		Entity entity = handle.Entity;
		if (!handle.IsInit)
		{
			return this.Destroy(handle);
		}
		ModelBase<CharacterModel>.Instance.ClearHandle(handle);
		WorldEntity worldEntity = handle.Entity;
		handle.Entity = null;
		if (!Singleton<EntitySystem>.Instance.DeSpawn<Entity>(entity))
		{
			ModelBase<CharacterModel>.Instance.EntityPool.RemoveExternal(worldEntity);
			return false;
		}
		TTimerAction <>9__1;
		TimerSystem.Instance.Next(delegate(float _)
		{
			TimerSystemInstance instance2 = TimerSystem.Instance;
			TTimerAction action;
			if ((action = <>9__1) == null)
			{
				action = (<>9__1 = delegate(float _)
				{
					ModelBase<CharacterModel>.Instance.EntityPool.Put(worldEntity);
				});
			}
			instance2.Next(action, null, null);
		}, null, null);
		return true;
	}

	// Token: 0x06017E51 RID: 97873 RVA: 0x006B1F04 File Offset: 0x006B0104
	[return: Nullable(2)]
	public EntityHandle CreateEntity(BigInteger componentsKey, CreateEntityData createData)
	{
		WorldEntity entity = ModelBase<CharacterModel>.Instance.EntityPool.Create(componentsKey);
		if (!Singleton<EntitySystem>.Instance.CreateExternal<WorldEntity>(entity, createData.Priority, new EntityArgs<CreateEntityData>(createData)))
		{
			return null;
		}
		return ModelBase<CharacterModel>.Instance.CreateHandle(entity);
	}

	// Token: 0x06017E52 RID: 97874 RVA: 0x006B1F50 File Offset: 0x006B0150
	[NullableContext(2)]
	public EntityHandle SpawnEntity(BigInteger componentsKey)
	{
		WorldEntity worldEntity = ModelBase<CharacterModel>.Instance.EntityPool.Get(componentsKey);
		if (worldEntity == null)
		{
			return null;
		}
		if (!Singleton<ObjectSystem>.Instance.CreateExternal<WorldEntity>(worldEntity))
		{
			return null;
		}
		return ModelBase<CharacterModel>.Instance.CreateHandle(worldEntity);
	}

	// Token: 0x06017E53 RID: 97875 RVA: 0x006B1F90 File Offset: 0x006B0190
	[NullableContext(2)]
	public CharacterActorComponent GetCharacterActorComponent(Entity entity)
	{
		if (entity == null || !entity.Valid)
		{
			return null;
		}
		CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
		if (!component.Valid || component.Actor == null)
		{
			return null;
		}
		return component;
	}

	// Token: 0x06017E54 RID: 97876 RVA: 0x006B1FCC File Offset: 0x006B01CC
	[NullableContext(2)]
	public CharacterActorComponent GetCharacterActorComponentById(int id)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		if (entity == null || !entity.Valid)
		{
			return null;
		}
		CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
		if (component == null || !component.Valid)
		{
			return null;
		}
		return component;
	}

	// Token: 0x06017E55 RID: 97877 RVA: 0x006B2014 File Offset: 0x006B0214
	[NullableContext(2)]
	public TsBaseCharacter GetCharacter(Entity entity)
	{
		if (entity == null || !entity.Valid)
		{
			return null;
		}
		CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
		if (component != null && component.Valid && component.Actor != null)
		{
			return component.Actor;
		}
		return null;
	}

	// Token: 0x06017E56 RID: 97878 RVA: 0x006B2058 File Offset: 0x006B0258
	[NullableContext(2)]
	public AActor GetActor(EntityHandle entity)
	{
		if (entity == null || !entity.Valid)
		{
			return null;
		}
		BaseActorComponent actorComponent = this.GetActorComponent(entity);
		if (actorComponent != null)
		{
			return actorComponent.Owner;
		}
		return null;
	}

	// Token: 0x06017E57 RID: 97879 RVA: 0x006B208C File Offset: 0x006B028C
	[return: Nullable(2)]
	public AActor GetActorByEntity(Entity entity)
	{
		if (entity == null || !entity.Valid)
		{
			return null;
		}
		BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
		if (component != null)
		{
			return component.Owner;
		}
		return null;
	}

	// Token: 0x06017E58 RID: 97880 RVA: 0x006B20C0 File Offset: 0x006B02C0
	[return: Nullable(2)]
	public BaseActorComponent GetActorComponent(EntityHandle handle)
	{
		BaseActorComponent component = handle.Entity.GetComponent<SceneItemActorComponent>();
		if (component == null)
		{
			component = handle.Entity.GetComponent<BaseCharacterComponent>();
		}
		if (component == null)
		{
			component = handle.Entity.GetComponent<VehicleActorComponent>();
		}
		return component;
	}

	// Token: 0x06017E59 RID: 97881 RVA: 0x006B20F8 File Offset: 0x006B02F8
	[return: Nullable(2)]
	public TsBaseCharacter GetTsBaseCharacterByEntity(EntityHandle handle)
	{
		CharacterActorComponent component = handle.Entity.GetComponent<CharacterActorComponent>();
		if (component == null)
		{
			return null;
		}
		return component.Actor;
	}

	// Token: 0x06017E5A RID: 97882 RVA: 0x006B2110 File Offset: 0x006B0310
	[return: Nullable(2)]
	public TsBaseCharacter GetUeTsBaseCharacterByEntity(Entity entity)
	{
		CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
		if (component != null)
		{
			return component.Actor;
		}
		return null;
	}

	// Token: 0x06017E5B RID: 97883 RVA: 0x006B212F File Offset: 0x006B032F
	public Entity GetEntityByUeTsBaseCharacter(TsBaseCharacter @char)
	{
		return @char.CharacterActorComponent.Entity;
	}

	// Token: 0x06017E5C RID: 97884 RVA: 0x006B213C File Offset: 0x006B033C
	public void SetTimeDilation(float timeDilation)
	{
		CreatureModel instance = ModelBase<CreatureModel>.Instance;
		foreach (EntityHandle entityHandle in instance.GetAllEntities())
		{
			if (entityHandle.IsInit)
			{
				entityHandle.Entity.SetTimeDilation(timeDilation);
			}
		}
		foreach (EntityHandle entityHandle2 in instance.DelayRemoveContainer.GetAllEntities())
		{
			if (entityHandle2.IsInit)
			{
				entityHandle2.Entity.SetTimeDilation(timeDilation);
			}
		}
	}

	// Token: 0x06017E5D RID: 97885 RVA: 0x006B21EC File Offset: 0x006B03EC
	private bool IsEmpty()
	{
		return this.StartItem == null && ModelBase<CharacterModel>.Instance.AwakeQueue.Size == 0;
	}

	// Token: 0x06017E5E RID: 97886 RVA: 0x006B2210 File Offset: 0x006B0410
	private void AwakeEntity()
	{
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		if (this.StartItem != null)
		{
			Func<bool> item = this.StartItem.Value.Item3;
			this.StartItem = null;
			if (item())
			{
				return;
			}
		}
		if (instance.AwakeQueue.Size > 0)
		{
			ValueTuple<EntityHandle, Func<bool>, Func<bool>>? startItem = null;
			do
			{
				ValueTuple<EntityHandle, Func<bool>, Func<bool>>? valueTuple;
				startItem = (valueTuple = instance.PopAwakeHandler());
				if (valueTuple == null)
				{
					return;
				}
			}
			while (!startItem.Value.Item2());
			this.StartItem = startItem;
			return;
		}
	}

	// Token: 0x06017E5F RID: 97887 RVA: 0x006B229C File Offset: 0x006B049C
	[NullableContext(2)]
	public void SortItem(EntityHandle handle)
	{
		if (handle == null || !handle.Valid)
		{
			return;
		}
		if ((handle.Entity.Flag & EExecutedFlag.Init) != EExecutedFlag.None)
		{
			return;
		}
		if (handle.Entity.GetComponent<CreatureDataComponent>().GetRemoveState())
		{
			return;
		}
		ModelBase<CharacterModel>.Instance.SortItem(handle);
	}

	// Token: 0x06017E60 RID: 97888 RVA: 0x006B22EC File Offset: 0x006B04EC
	protected override bool OnChangeMode()
	{
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			foreach (EntityHandle entityHandle in ModelBase<CreatureModel>.Instance.GetAllEntities())
			{
				CharacterAiComponent component = entityHandle.Entity.GetComponent<CharacterAiComponent>();
				if (component != null)
				{
					component.SwitchControl(true);
				}
			}
		}
		return true;
	}

	// Token: 0x06017E61 RID: 97889 RVA: 0x006B2358 File Offset: 0x006B0558
	public void EnterSelfCenteredMode(ESelfCenteredMode mode, float timeDilation, float duration = -1f)
	{
		ModelBase<CharacterModel>.Instance.EnterSelfCenteredMode(mode, timeDilation, duration);
	}

	// Token: 0x06017E62 RID: 97890 RVA: 0x006B2367 File Offset: 0x006B0567
	public void ExitSelfCenteredMode(ESelfCenteredMode mode)
	{
		ModelBase<CharacterModel>.Instance.ExitSelfCenteredMode(mode);
	}

	// Token: 0x06017E63 RID: 97891 RVA: 0x006B2374 File Offset: 0x006B0574
	public void ExitSkillSelfCenteredMode()
	{
		ModelBase<CharacterModel>.Instance.ExitSkillSelfCenteredMode();
	}

	// Token: 0x06017E64 RID: 97892 RVA: 0x006B2380 File Offset: 0x006B0580
	public void ExitAllSelfCenteredMode()
	{
		ModelBase<CharacterModel>.Instance.ExitAllSelfCenteredMode();
	}

	// Token: 0x06017E65 RID: 97893 RVA: 0x006B238C File Offset: 0x006B058C
	public bool IsSelfCenteredModeEnabled(ESelfCenteredMode mode)
	{
		return ModelBase<CharacterModel>.Instance.IsSelfCenteredModeEnabled(mode);
	}

	// Token: 0x0400B96C RID: 47468
	[Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})]
	private ValueTuple<EntityHandle, Func<bool>, Func<bool>>? StartItem;

	// Token: 0x0400B96D RID: 47469
	private DateTime? LastDate;
}
