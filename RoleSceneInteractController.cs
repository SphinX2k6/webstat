using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.Character.Role.Component;

// Token: 0x0200186D RID: 6253
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class RoleSceneInteractController : ControllerBase<RoleSceneInteractController>
{
	// Token: 0x0600B32D RID: 45869 RVA: 0x002FD41C File Offset: 0x002FB61C
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.EntityStaticHookMoveNotify, false, false)]
	public static void OnHookMoveNotify(Entity entity, EntityStaticHookMoveNotify notify, CombatCommon combatCommon = null)
	{
		RoleSceneInteractComponent roleSceneInteractComponent = (entity != null) ? entity.GetComponent<RoleSceneInteractComponent>() : null;
		if (roleSceneInteractComponent == null || !roleSceneInteractComponent.Valid)
		{
			BaseExploreComponent baseExploreComponent = (entity != null) ? entity.GetComponent<BaseExploreComponent>() : null;
			if (baseExploreComponent != null && baseExploreComponent.Valid)
			{
				if (notify.TargetCase == EntityStaticHookMoveNotify.TargetOneofCase.TargetPos)
				{
					baseExploreComponent.SimulateInteractingTarget = null;
					if (baseExploreComponent.SimulateInteractingTargetLocation == null)
					{
						baseExploreComponent.SimulateInteractingTargetLocation = global::Vector.Create();
					}
					baseExploreComponent.SimulateInteractingTargetLocation.X = (double)notify.TargetPos.X;
					baseExploreComponent.SimulateInteractingTargetLocation.Y = (double)notify.TargetPos.Y;
					baseExploreComponent.SimulateInteractingTargetLocation.Z = (double)notify.TargetPos.Z;
					return;
				}
				if (notify.TargetCase == EntityStaticHookMoveNotify.TargetOneofCase.TargetEntityId)
				{
					if (notify.HookMoveType == StaticHookMoveType.Pull)
					{
						MotorcycleExploreComponent motorcycleExploreComponent = (MotorcycleExploreComponent)baseExploreComponent;
						EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(notify.TargetEntityId);
						GrapplingHookPointComponent simulatePullingTarget;
						if (entity2 == null)
						{
							simulatePullingTarget = null;
						}
						else
						{
							WorldEntity entity3 = entity2.Entity;
							simulatePullingTarget = ((entity3 != null) ? entity3.GetComponent<GrapplingHookPointComponent>() : null);
						}
						motorcycleExploreComponent.SimulatePullingTarget = simulatePullingTarget;
						return;
					}
					baseExploreComponent.SimulateInteractingTargetLocation = null;
					EntityHandle entity4 = ModelBase<CreatureModel>.Instance.GetEntity(notify.TargetEntityId);
					BaseExploreComponent baseExploreComponent2 = baseExploreComponent;
					GrapplingHookPointComponent simulateInteractingTarget;
					if (entity4 == null)
					{
						simulateInteractingTarget = null;
					}
					else
					{
						WorldEntity entity5 = entity4.Entity;
						simulateInteractingTarget = ((entity5 != null) ? entity5.GetComponent<GrapplingHookPointComponent>() : null);
					}
					baseExploreComponent2.SimulateInteractingTarget = simulateInteractingTarget;
				}
			}
			return;
		}
		if (notify.TargetCase == EntityStaticHookMoveNotify.TargetOneofCase.TargetPos)
		{
			roleSceneInteractComponent.SimulateHookTargetEntity = null;
			if (roleSceneInteractComponent.SimulateHookTargetLocation == null)
			{
				roleSceneInteractComponent.SimulateHookTargetLocation = global::Vector.Create();
			}
			roleSceneInteractComponent.SimulateHookTargetLocation.X = (double)notify.TargetPos.X;
			roleSceneInteractComponent.SimulateHookTargetLocation.Y = (double)notify.TargetPos.Y;
			roleSceneInteractComponent.SimulateHookTargetLocation.Z = (double)notify.TargetPos.Z;
			return;
		}
		if (notify.TargetCase == EntityStaticHookMoveNotify.TargetOneofCase.TargetEntityId)
		{
			roleSceneInteractComponent.SimulateHookTargetLocation = null;
			EntityHandle entity6 = ModelBase<CreatureModel>.Instance.GetEntity(notify.TargetEntityId);
			roleSceneInteractComponent.SimulateHookTargetEntity = entity6;
		}
	}

	// Token: 0x0600B32E RID: 45870 RVA: 0x002FD5E4 File Offset: 0x002FB7E4
	public static void SendHookMovePush(Entity entity, GrapplingHookPointComponent targetPoint)
	{
		bool flag;
		if (entity == null)
		{
			flag = true;
		}
		else
		{
			BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
			flag = !((component != null) ? new bool?(component.IsAutonomousProxy) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return;
		}
		EntityStaticHookMovePush entityStaticHookMovePush = EntityStaticHookMovePush.Create();
		entityStaticHookMovePush.EntityId = entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
		if (targetPoint.IsMovable())
		{
			entityStaticHookMovePush.TargetEntityId = targetPoint.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
		}
		else
		{
			entityStaticHookMovePush.TargetPos = Aki.Protocol.Vector.Create();
			entityStaticHookMovePush.TargetPos.X = (float)targetPoint.HookLocation.X;
			entityStaticHookMovePush.TargetPos.Y = (float)targetPoint.HookLocation.Y;
			entityStaticHookMovePush.TargetPos.Z = (float)targetPoint.HookLocation.Z;
		}
		Singleton<CombatNet>.Instance.Send(EPushMessageId.EntityStaticHookMovePush, entity, entityStaticHookMovePush, null, null, null);
	}

	// Token: 0x0600B32F RID: 45871 RVA: 0x002FD6D8 File Offset: 0x002FB8D8
	public static void SendPullCollectionPush(Entity entity, GrapplingHookPointComponent targetPoint)
	{
		bool flag;
		if (entity == null)
		{
			flag = true;
		}
		else
		{
			BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
			flag = !((component != null) ? new bool?(component.IsAutonomousProxy) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return;
		}
		EntityStaticHookMovePush entityStaticHookMovePush = EntityStaticHookMovePush.Create();
		entityStaticHookMovePush.EntityId = entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
		entityStaticHookMovePush.HookMoveType = StaticHookMoveType.Pull;
		entityStaticHookMovePush.TargetEntityId = targetPoint.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
		Singleton<CombatNet>.Instance.Send(EPushMessageId.EntityStaticHookMovePush, entity, entityStaticHookMovePush, null, null, null);
	}
}
