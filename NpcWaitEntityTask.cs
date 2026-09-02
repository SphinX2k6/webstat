using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020031C9 RID: 12745
[NullableContext(1)]
[Nullable(0)]
internal class NpcWaitEntityTask
{
	// Token: 0x0601A6B1 RID: 108209 RVA: 0x007CAFBC File Offset: 0x007C91BC
	public NpcWaitEntityTask(Entity npcEntity, int pbDataId)
	{
		this.NpcEntity = npcEntity;
		this.PbDataIdToWait = pbDataId;
	}

	// Token: 0x0601A6B2 RID: 108210 RVA: 0x007CAFD4 File Offset: 0x007C91D4
	public void Start()
	{
		if (this.Phase != ETaskPhase.None)
		{
			return;
		}
		if (this.WaitEntityTaskHandle != null)
		{
			return;
		}
		this.Phase = ETaskPhase.InProgress;
		this.WaitEntityTaskHandle = WaitEntityTask.CreateWithPbDataId("NpcWaitEntityTask.Start", this.PbDataIdToWait, new Action<bool?>(this.OnEntityAdd), 30000, false, true);
	}

	// Token: 0x0601A6B3 RID: 108211 RVA: 0x007CB024 File Offset: 0x007C9224
	public void Stop()
	{
		if (this.Phase != ETaskPhase.Succeeded)
		{
			if (this.Phase == ETaskPhase.InProgress)
			{
				this.Cancel();
			}
			return;
		}
		CreatureModel instance = ModelBase<CreatureModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetEntityByPbDataId(this.PbDataIdToWait) : null;
		if (entityHandle == null || !entityHandle.Valid)
		{
			return;
		}
		this.TryReset(entityHandle.Entity);
	}

	// Token: 0x0601A6B4 RID: 108212 RVA: 0x007CB080 File Offset: 0x007C9280
	public void Cancel()
	{
		if (this.WaitEntityTaskHandle != null)
		{
			this.WaitEntityTaskHandle.Cancel();
			return;
		}
		CreatureModel instance = ModelBase<CreatureModel>.Instance;
		WorldEntity worldEntity;
		if (instance == null)
		{
			worldEntity = null;
		}
		else
		{
			EntityHandle entityByPbDataId = instance.GetEntityByPbDataId(this.PbDataIdToWait);
			worldEntity = ((entityByPbDataId != null) ? entityByPbDataId.Entity : null);
		}
		WorldEntity worldEntity2 = worldEntity;
		if (worldEntity2 == null || !worldEntity2.Valid)
		{
			return;
		}
		if (worldEntity2.GetComponent<CreatureDataComponent>().GetEntityType() == EEntityType.SceneItem && Singleton<EventSystem>.Instance.HasWithTarget(worldEntity2, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneItemLoadComplete)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(worldEntity2, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneItemLoadComplete));
		}
	}

	// Token: 0x0601A6B5 RID: 108213 RVA: 0x007CB120 File Offset: 0x007C9320
	protected void Finish()
	{
		this.Phase = ETaskPhase.Succeeded;
	}

	// Token: 0x0601A6B6 RID: 108214 RVA: 0x007CB12C File Offset: 0x007C932C
	protected void OnEntityAdd(bool? result)
	{
		this.WaitEntityTaskHandle = null;
		if (!result.GetValueOrDefault())
		{
			this.Phase = ETaskPhase.Failed;
			return;
		}
		CreatureModel instance = ModelBase<CreatureModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetEntityByPbDataId(this.PbDataIdToWait) : null;
		if (entityHandle == null || !entityHandle.Valid)
		{
			this.Phase = ETaskPhase.Failed;
			return;
		}
		this.TryExecute(entityHandle.Entity);
	}

	// Token: 0x0601A6B7 RID: 108215 RVA: 0x007CB190 File Offset: 0x007C9390
	protected void TryExecute(Entity entity)
	{
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			this.Phase = ETaskPhase.Failed;
			return;
		}
		EEntityType entityType = component.GetEntityType();
		if (entityType == EEntityType.SceneItem)
		{
			this.TryExecuteWithSceneItemActor(entity);
			return;
		}
		if (entityType != EEntityType.Vehicle)
		{
			this.Phase = ETaskPhase.Failed;
			return;
		}
		this.Execute(entity);
	}

	// Token: 0x0601A6B8 RID: 108216 RVA: 0x007CB1D8 File Offset: 0x007C93D8
	protected void TryExecuteWithSceneItemActor(Entity entity)
	{
		SceneItemActorComponent component = entity.GetComponent<SceneItemActorComponent>();
		if (component == null || !component.GetIsSceneInteractionLoadCompleted())
		{
			Singleton<EventSystem>.Instance.AddWithTarget(entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneItemLoadComplete));
			return;
		}
		this.Execute(entity);
	}

	// Token: 0x0601A6B9 RID: 108217 RVA: 0x007CB218 File Offset: 0x007C9418
	protected void OnSceneItemLoadComplete()
	{
		CreatureModel instance = ModelBase<CreatureModel>.Instance;
		WorldEntity worldEntity = (instance != null) ? instance.GetEntityByPbDataId(this.PbDataIdToWait).Entity : null;
		Singleton<EventSystem>.Instance.RemoveWithTarget(worldEntity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneItemLoadComplete));
		this.Execute(worldEntity);
	}

	// Token: 0x0601A6BA RID: 108218 RVA: 0x007CB266 File Offset: 0x007C9466
	protected void TryReset(Entity entity)
	{
		if (entity.GetComponent<CreatureDataComponent>() == null)
		{
			return;
		}
		this.Reset(entity);
	}

	// Token: 0x0601A6BB RID: 108219 RVA: 0x007CB278 File Offset: 0x007C9478
	protected virtual void Reset(Entity entity)
	{
		SceneItemActorComponent component = entity.GetComponent<SceneItemActorComponent>();
		if (component != null)
		{
			component.GetIsSceneInteractionLoadCompleted();
		}
	}

	// Token: 0x0601A6BC RID: 108220 RVA: 0x007CB28D File Offset: 0x007C948D
	protected virtual void Execute(Entity entity)
	{
		this.Finish();
	}

	// Token: 0x0400D54C RID: 54604
	[Nullable(2)]
	public Entity NpcEntity;

	// Token: 0x0400D54D RID: 54605
	public int PbDataIdToWait;

	// Token: 0x0400D54E RID: 54606
	public EEntityType? EntityType;

	// Token: 0x0400D54F RID: 54607
	[Nullable(2)]
	public WaitEntityTask WaitEntityTaskHandle;

	// Token: 0x0400D550 RID: 54608
	public ETaskPhase Phase;
}
