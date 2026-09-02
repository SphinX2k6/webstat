using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200009F RID: 159
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class EntitySystem : Singleton<EntitySystem>
{
	// Token: 0x06000406 RID: 1030 RVA: 0x00017F81 File Offset: 0x00016181
	public bool Initialize()
	{
		this.TickEntityManger.Clear();
		this.AfterTickEntityManger.Clear();
		return true;
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x00017F9A File Offset: 0x0001619A
	[NullableContext(2)]
	public void SetEntityDestroyHandle(TEntityDestroyHandle handle)
	{
		Singleton<EntitySystem>.Instance.DestroyHandle = handle;
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x00017FA8 File Offset: 0x000161A8
	[NullableContext(2)]
	public T Create<[Nullable(0)] T>(int priority = 0, IEntityArgs args = null) where T : Entity
	{
		T t = Singleton<ObjectSystem>.Instance.Create<T>();
		if (!t.Create(args))
		{
			Singleton<ObjectSystem>.Instance.Destroy(t);
			return default(T);
		}
		if (t.TickComponentManager.NeedTick)
		{
			this.TickEntityManger.Add(t, priority);
		}
		if (t.TickComponentManager.NeedAfterTick)
		{
			this.AfterTickEntityManger.Add(t, priority);
		}
		return t;
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x00018034 File Offset: 0x00016234
	public bool CreateExternal<[Nullable(0)] T>(T entity, int priority = 0, [Nullable(2)] IEntityArgs args = null) where T : Entity
	{
		if (!Singleton<ObjectSystem>.Instance.CreateExternal<T>(entity))
		{
			return false;
		}
		if (!entity.Create(args))
		{
			Singleton<ObjectSystem>.Instance.Destroy(entity);
			return false;
		}
		if (entity.TickComponentManager.NeedTick)
		{
			this.TickEntityManger.Add(entity, priority);
		}
		if (entity.TickComponentManager.NeedAfterTick)
		{
			this.AfterTickEntityManger.Add(entity, priority);
		}
		return true;
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x000180BC File Offset: 0x000162BC
	public bool Respawn<[Nullable(0)] T>(T entity, bool createExternal = false, int priority = 0, [Nullable(2)] IEntityArgs args = null) where T : Entity
	{
		if (!createExternal && !Singleton<ObjectSystem>.Instance.CreateExternal<T>(entity))
		{
			return false;
		}
		if (!entity.Respawn(args))
		{
			return false;
		}
		if (entity.TickComponentManager.NeedTick)
		{
			this.TickEntityManger.Add(entity, priority);
		}
		if (entity.TickComponentManager.NeedAfterTick)
		{
			this.AfterTickEntityManger.Add(entity, priority);
		}
		return true;
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x00018135 File Offset: 0x00016335
	public bool InitData<[Nullable(0)] T>(T entity, [Nullable(2)] IEntityArgs args = null) where T : Entity
	{
		return entity.InitData(args);
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x00018143 File Offset: 0x00016343
	public bool Init(Entity entity)
	{
		if (!entity.Init())
		{
			Singleton<ObjectSystem>.Instance.Destroy(entity);
			return false;
		}
		return true;
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x0001815C File Offset: 0x0001635C
	public bool Start(Entity entity)
	{
		if (!entity.Start())
		{
			Singleton<ObjectSystem>.Instance.Destroy(entity);
			return false;
		}
		return true;
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x00018175 File Offset: 0x00016375
	public void Activate(Entity entity)
	{
		entity.Activate();
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x0001817D File Offset: 0x0001637D
	public void PostActive(Entity entity)
	{
		entity.PostActivate();
	}

	// Token: 0x06000410 RID: 1040 RVA: 0x00018188 File Offset: 0x00016388
	public bool Destroy<[Nullable(0)] T>(T entity) where T : Entity
	{
		if (!Singleton<ObjectSystem>.Instance.Destroy(entity))
		{
			return false;
		}
		if (GameBudgetInterfaceController.IsOpen)
		{
			entity.UnregisterFromGameBudgetController();
		}
		if (entity.TickComponentManager.NeedTick)
		{
			this.TickEntityManger.Delete(entity.Id);
		}
		if (entity.TickComponentManager.NeedAfterTick)
		{
			this.AfterTickEntityManger.Delete(entity.Id);
		}
		if (!entity.End() || !entity.Clear())
		{
			return false;
		}
		TEntityDestroyHandle destroyHandle = this.DestroyHandle;
		if (destroyHandle != null)
		{
			destroyHandle(entity);
		}
		return true;
	}

	// Token: 0x06000411 RID: 1041 RVA: 0x00018240 File Offset: 0x00016440
	public bool DeSpawn<[Nullable(0)] T>(T entity) where T : Entity
	{
		if (!Singleton<ObjectSystem>.Instance.Destroy(entity))
		{
			return false;
		}
		if (GameBudgetInterfaceController.IsOpen)
		{
			entity.UnregisterFromGameBudgetController();
		}
		if (entity.TickComponentManager.NeedTick)
		{
			this.TickEntityManger.Delete(entity.Id);
		}
		if (entity.TickComponentManager.NeedAfterTick)
		{
			this.AfterTickEntityManger.Delete(entity.Id);
		}
		return entity.End() && entity.Clear();
	}

	// Token: 0x06000412 RID: 1042 RVA: 0x000182E0 File Offset: 0x000164E0
	[NullableContext(2)]
	public Entity Get(int id)
	{
		List<ObjectBase> objects = Singleton<ObjectSystem>.Instance.Objects;
		int num = (int)((uint)id >> 16);
		Entity entity = (num >= objects.Count) ? null : (objects[num] as Entity);
		if (entity == null)
		{
			return null;
		}
		if (entity.Id != id)
		{
			return null;
		}
		return entity;
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x00018328 File Offset: 0x00016528
	[NullableContext(0)]
	[return: Nullable(2)]
	public T Get<T>(int id) where T : Entity
	{
		List<ObjectBase> objects = Singleton<ObjectSystem>.Instance.Objects;
		int num = (int)((uint)id >> 16);
		Entity entity = (num >= objects.Count) ? null : (objects[num] as Entity);
		if (entity == null)
		{
			return default(T);
		}
		if (entity.Id != id)
		{
			return default(T);
		}
		return entity as T;
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x0001838C File Offset: 0x0001658C
	[NullableContext(0)]
	[return: Nullable(2)]
	public T GetComponent<T>(int id) where T : EntityComponent
	{
		Entity entity = this.Get<Entity>(id);
		if (entity == null)
		{
			return default(T);
		}
		return entity.GetComponent<T>();
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x000183B3 File Offset: 0x000165B3
	public void ForceTick(float delta)
	{
		this.TickEntityManger.ForceTick(delta);
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x000183C1 File Offset: 0x000165C1
	public void Tick(float delta)
	{
		this.TickEntityManger.Tick(delta);
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x000183CF File Offset: 0x000165CF
	public void ForceAfterTick(float delta)
	{
		this.TickEntityManger.ForceAfterTick(delta);
	}

	// Token: 0x06000418 RID: 1048 RVA: 0x000183DD File Offset: 0x000165DD
	public void AfterTick(float delta)
	{
		this.AfterTickEntityManger.AfterTick(delta);
	}

	// Token: 0x040003DA RID: 986
	private readonly TickEntityManager TickEntityManger = new TickEntityManager();

	// Token: 0x040003DB RID: 987
	private readonly TickEntityManager AfterTickEntityManger = new TickEntityManager();

	// Token: 0x040003DC RID: 988
	[Nullable(2)]
	private TEntityDestroyHandle DestroyHandle;
}
