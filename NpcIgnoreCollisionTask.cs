using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020031CA RID: 12746
[NullableContext(1)]
[Nullable(0)]
internal class NpcIgnoreCollisionTask : NpcWaitEntityTask
{
	// Token: 0x0601A6BD RID: 108221 RVA: 0x007CB295 File Offset: 0x007C9495
	public NpcIgnoreCollisionTask(Entity npcEntity, int pbDataId) : base(npcEntity, pbDataId)
	{
	}

	// Token: 0x0601A6BE RID: 108222 RVA: 0x007CB29F File Offset: 0x007C949F
	protected override void Reset(Entity entity)
	{
		SceneItemActorComponent component = entity.GetComponent<SceneItemActorComponent>();
		if (component == null || !component.GetIsSceneInteractionLoadCompleted())
		{
			return;
		}
		this.IgnoreSceneItemCollision(entity, false);
	}

	// Token: 0x0601A6BF RID: 108223 RVA: 0x007CB2C1 File Offset: 0x007C94C1
	protected override void Execute(Entity entity)
	{
		this.IgnoreSceneItemCollision(entity, true);
		base.Finish();
	}

	// Token: 0x0601A6C0 RID: 108224 RVA: 0x007CB2D4 File Offset: 0x007C94D4
	private void IgnoreSceneItemCollision(Entity entity, bool shouldIgnore)
	{
		SceneItemActorComponent component = entity.GetComponent<SceneItemActorComponent>();
		Entity npcEntity = this.NpcEntity;
		BaseCharacterComponent baseCharacterComponent = (npcEntity != null) ? npcEntity.GetComponent<BaseCharacterComponent>() : null;
		if (component == null || baseCharacterComponent == null)
		{
			this.Phase = ETaskPhase.Failed;
			return;
		}
		AActor interactCollisionActor = component.GetInteractCollisionActor();
		if (interactCollisionActor == null || !interactCollisionActor.IsValid())
		{
			this.Phase = ETaskPhase.Failed;
			return;
		}
		baseCharacterComponent.Actor.IgnoreActorWhenMoving(interactCollisionActor, shouldIgnore, true);
	}
}
