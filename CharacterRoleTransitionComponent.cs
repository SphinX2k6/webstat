using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game;
using UnrealEngine;

// Token: 0x02003062 RID: 12386
[NullableContext(2)]
[Nullable(0)]
public class CharacterRoleTransitionComponent : EntityComponent
{
	// Token: 0x06019755 RID: 104277 RVA: 0x0075C091 File Offset: 0x0075A291
	protected override bool OnStart()
	{
		this.CheckLeftTime = 1000.0;
		this.ActorComp = base.Entity.CheckGetComponent<CharacterActorComponent>();
		return true;
	}

	// Token: 0x06019756 RID: 104278 RVA: 0x0075C0B4 File Offset: 0x0075A2B4
	protected override void OnTick(float delta)
	{
		if (!this.OpenChangeRoleState)
		{
			return;
		}
		this.CheckLeftTime -= (double)delta;
		if (this.CheckLeftTime > 0.0)
		{
			return;
		}
		this.CheckLeftTime = 1000.0;
		if (Global.BaseCharacter == null)
		{
			return;
		}
		FVectorDouble actorLocation = Global.BaseCharacter.CharacterActorComponent.ActorLocation;
		FVectorDouble actorLocation2 = this.ActorComp.ActorLocation;
		double num = global::Vector.DistSquared(global::Vector.Create(actorLocation), global::Vector.Create(actorLocation2));
		this.IsInControlArea = (num < this.ControlDistance * this.ControlDistance);
		if (this.ActorComp.IsAutonomousProxy)
		{
			if (this.IsInControlArea)
			{
				return;
			}
			Entity entity = this.ChooseController();
			if (entity == null || !entity.Valid)
			{
				return;
			}
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			this.ChangeControlRole(entity.Id, component.GetPlayerId());
			return;
		}
		else
		{
			if (!this.IsInControlArea)
			{
				return;
			}
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			this.ChangeControlRole(base.Entity.Id, playerId);
			return;
		}
	}

	// Token: 0x06019757 RID: 104279 RVA: 0x0075C1C0 File Offset: 0x0075A3C0
	private Entity ChooseController()
	{
		foreach (EntityHandle entityHandle in ModelBase<CreatureModel>.Instance.GetAllEntities())
		{
			if (entityHandle != null && entityHandle.IsInit && entityHandle.Entity.GetComponent<CreatureDataComponent>().GetEntityType() == EEntityType.Player)
			{
				CharacterActorComponent characterActorComponentById = ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(entityHandle.Id);
				if (characterActorComponentById != null && characterActorComponentById.Actor != Global.BaseCharacter && characterActorComponentById != this.ActorComp)
				{
					FVectorDouble actorLocation = this.ActorComp.ActorLocation;
					FVectorDouble actorLocation2 = characterActorComponentById.ActorLocation;
					if (UKismetMathLibrary.D_Vector_DistanceSquared(actorLocation, actorLocation2) < this.ControlDistance * this.ControlDistance)
					{
						return entityHandle.Entity;
					}
				}
			}
		}
		return null;
	}

	// Token: 0x06019758 RID: 104280 RVA: 0x0075C294 File Offset: 0x0075A494
	private void ChangeControlRole(int entityId, int playerId)
	{
		ControllerBase<CreatureController>.Instance.ChangeEntityRoleRequest(entityId, playerId);
	}

	// Token: 0x06019759 RID: 104281 RVA: 0x0075C2A4 File Offset: 0x0075A4A4
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterRoleTransitionComponent characterRoleTransitionComponent = (CharacterRoleTransitionComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterRoleTransitionComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsInControlArea"))
		{
			this.IsInControlArea = characterRoleTransitionComponent.IsInControlArea;
		}
		if (base.CanResetComponentProperty("CheckLeftTime"))
		{
			this.CheckLeftTime = characterRoleTransitionComponent.CheckLeftTime;
		}
		return true;
	}

	// Token: 0x0400C9AD RID: 51629
	private const int CHECK_CHANGE_ROLE_TIME = 1000;

	// Token: 0x0400C9AE RID: 51630
	private CharacterActorComponent ActorComp;

	// Token: 0x0400C9AF RID: 51631
	private readonly double ControlDistance = 800.0;

	// Token: 0x0400C9B0 RID: 51632
	private bool IsInControlArea;

	// Token: 0x0400C9B1 RID: 51633
	private double CheckLeftTime;

	// Token: 0x0400C9B2 RID: 51634
	private readonly bool OpenChangeRoleState;
}
