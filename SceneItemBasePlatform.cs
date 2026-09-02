using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

// Token: 0x02003219 RID: 12825
[NullableContext(1)]
[Nullable(0)]
public class SceneItemBasePlatform : BasePlatform
{
	// Token: 0x0601AA68 RID: 109160 RVA: 0x007ECBEC File Offset: 0x007EADEC
	public SceneItemBasePlatform(EntityHandle entityHandle) : base(entityHandle)
	{
		this.IsDeltaBaseSpeedNeedZ = true;
		EntityHandle entityHandle2 = this.EntityHandle;
		SceneItemActorComponent sceneItemActorComponent = (entityHandle2 != null) ? entityHandle2.Entity.GetComponent<SceneItemActorComponent>() : null;
		SceneInteractionActor sceneInteractionActor = ((sceneItemActorComponent != null) ? sceneItemActorComponent.GetInteractionMainActor() : null) as SceneInteractionActor;
		if (sceneInteractionActor != null)
		{
			AActor attachParentActor = sceneInteractionActor.GetAttachParentActor();
			if (attachParentActor == null)
			{
				return;
			}
			AActor aactor = null;
			if (sceneInteractionActor.CollisionActors != null && sceneInteractionActor.CollisionActors.Num() > 0)
			{
				TArray<AActor> collisionActors = sceneInteractionActor.CollisionActors;
				aactor = ((collisionActors != null) ? collisionActors.Get(0) : null);
			}
			if (aactor == null)
			{
				aactor = attachParentActor;
			}
			FVector fvector = default(FVector);
			FVector fvector2 = default(FVector);
			aactor.GetActorBounds(true, ref fvector, ref fvector2, true);
			float num = Math.Max(fvector2.X, Math.Max(fvector2.Y, fvector2.Z));
			num += 50f;
			this.LeaveSphereRadiusSq = (double)(num * num);
		}
		object obj;
		if (sceneItemActorComponent == null)
		{
			obj = null;
		}
		else
		{
			CreatureDataComponent creatureData = sceneItemActorComponent.CreatureData;
			obj = ((creatureData != null) ? creatureData.GetPbEntityInitData() : null);
		}
		object obj2 = obj;
		Dictionary<EConfigComponent, IComponentBase> dictionary = (obj2 != null) ? obj2.ComponentsData : null;
		if (dictionary != null)
		{
			VehicleComponent component = TdUtils.GetComponent<VehicleComponent>(dictionary, EConfigComponent.VehicleComponent);
			if (((component != null) ? component.VehicleFeatures : null) != null)
			{
				this.NeedAttach = true;
				foreach (IVehicleFeature vehicleFeature in component.VehicleFeatures)
				{
					IMovablePlatformVehicleFeature movablePlatformVehicleFeature = vehicleFeature as IMovablePlatformVehicleFeature;
					if (movablePlatformVehicleFeature != null)
					{
						using (List<int>.Enumerator enumerator2 = movablePlatformVehicleFeature.PlayerAttachTags.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								int item = enumerator2.Current;
								this.PlatformTags.Add(item);
							}
							break;
						}
					}
				}
			}
		}
	}

	// Token: 0x0601AA69 RID: 109161 RVA: 0x007ECDCC File Offset: 0x007EAFCC
	public override FTransformDouble? GetTransform()
	{
		EntityHandle entityHandle = this.EntityHandle;
		if (entityHandle == null)
		{
			return null;
		}
		return new FTransformDouble?(entityHandle.Entity.GetComponent<BaseActorComponent>().ActorTransform);
	}

	// Token: 0x0601AA6A RID: 109162 RVA: 0x007ECE04 File Offset: 0x007EB004
	public override bool CheckLeave(Entity entity, Vector location)
	{
		EntityHandle entityHandle = this.EntityHandle;
		if (entityHandle == null || !entityHandle.Valid)
		{
			return true;
		}
		SceneItemActorComponent component = this.EntityHandle.Entity.GetComponent<SceneItemActorComponent>();
		UCharacterMovementComponent ucharacterMovementComponent;
		if (entity == null)
		{
			ucharacterMovementComponent = null;
		}
		else
		{
			CharacterMoveComponent component2 = entity.GetComponent<CharacterMoveComponent>();
			ucharacterMovementComponent = ((component2 != null) ? component2.CharacterMovement : null);
		}
		UCharacterMovementComponent ucharacterMovementComponent2 = ucharacterMovementComponent;
		bool flag = false;
		if (this.NeedAttach)
		{
			AActor aactor = (component != null) ? component.GetMainCollisionActor() : null;
			if (aactor != null && ucharacterMovementComponent2 != null)
			{
				FVectorDouble fvectorDouble = default(FVectorDouble);
				FVector fvector = default(FVector);
				aactor.D_GetActorBounds(false, ref fvectorDouble, ref fvector, false);
				Vector vector = Vector.Create();
				vector.FromUeVector(fvectorDouble);
				Vector vector2 = Vector.Create();
				vector2.FromUeVector(fvector);
				vector2.Z += (double)ucharacterMovementComponent2.GetMaxJumpHeight();
				flag = this.IsPointInsideBox(location, vector2, vector);
			}
		}
		else
		{
			this.CacheLocation.DeepCopy(component.ActorLocationProxy);
			flag = (Vector.DistSquared(location, this.CacheLocation) < this.LeaveSphereRadiusSq);
		}
		if (!flag)
		{
			BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			if (this.PlatformTags.Count > 0)
			{
				foreach (int value in this.PlatformTags)
				{
					if (baseTagComponent != null)
					{
						baseTagComponent.RemoveTag(new int?(value));
					}
				}
				base.RequestEnterOrLeave(false);
			}
			if (this.NeedAttach)
			{
				CharacterDriveVehicleComponent characterDriveVehicleComponent = (entity != null) ? entity.GetComponent<CharacterDriveVehicleComponent>() : null;
				if (characterDriveVehicleComponent != null)
				{
					characterDriveVehicleComponent.IsAttachToMoveSceneItem = false;
				}
				if (characterDriveVehicleComponent == null || !characterDriveVehicleComponent.IsOnVehicle)
				{
					BaseMoveComponent baseMoveComponent = (entity != null) ? entity.GetComponent<BaseMoveComponent>() : null;
					if (baseMoveComponent != null)
					{
						baseMoveComponent.NeedRootMotionWhenAttached = false;
					}
					if (entity != null)
					{
						CharacterActorComponent component3 = entity.GetComponent<CharacterActorComponent>();
						if (component3 != null)
						{
							AActor owner = component3.Owner;
							if (owner != null)
							{
								owner.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
							}
						}
					}
					if (ucharacterMovementComponent2 != null)
					{
						ucharacterMovementComponent2.bKuroStopUpdateBasedMovement = false;
					}
				}
				Singleton<EventSystem>.Instance.EmitWithTarget<Entity, bool>(this.EntityHandle.Entity, EEventName.OnChangeBasedPlatform, entity, false);
			}
			WorldEntity entity2 = this.EntityHandle.Entity;
			CSharpScript.Game.NewWorld.Common.Component.RoadNetworkNavigationComponent roadNetworkNavigationComponent = (entity2 != null) ? entity2.GetComponent<CSharpScript.Game.NewWorld.Common.Component.RoadNetworkNavigationComponent>() : null;
			if (roadNetworkNavigationComponent != null)
			{
				roadNetworkNavigationComponent.OnCharacterLeave(entity.Id);
			}
			return true;
		}
		return false;
	}

	// Token: 0x0601AA6B RID: 109163 RVA: 0x007ED044 File Offset: 0x007EB244
	private bool IsPointInsideBox(Vector point, Vector bounds, Vector origin)
	{
		return point.X >= origin.X - bounds.X && point.X <= origin.X + bounds.X && point.Y >= origin.Y - bounds.Y && point.Y <= origin.Y + bounds.Y && point.Z >= origin.Z - bounds.Z && point.Z <= origin.Z + bounds.Z;
	}

	// Token: 0x0601AA6C RID: 109164 RVA: 0x007ED0D4 File Offset: 0x007EB2D4
	public override void OnCharacterEnter(Entity entity, UCharacterMovementComponent characterMovement)
	{
		if (!this.EntityHandle.Valid)
		{
			return;
		}
		SceneItemActorComponent component = this.EntityHandle.Entity.GetComponent<SceneItemActorComponent>();
		TsBaseCharacter tsBaseCharacter = ((characterMovement != null) ? characterMovement.GetOwner() : null) as TsBaseCharacter;
		Entity entity2 = (tsBaseCharacter != null) ? tsBaseCharacter.GetEntityNoBlueprint() : null;
		BaseTagComponent baseTagComponent = (entity2 != null) ? entity2.GetComponent<BaseTagComponent>() : null;
		if (this.PlatformTags.Count > 0)
		{
			foreach (int value in this.PlatformTags)
			{
				if (baseTagComponent != null)
				{
					baseTagComponent.AddTag(new int?(value));
				}
			}
			base.RequestEnterOrLeave(true);
		}
		if (this.NeedAttach)
		{
			BaseMoveComponent baseMoveComponent = (entity2 != null) ? entity2.GetComponent<BaseMoveComponent>() : null;
			if (baseMoveComponent != null)
			{
				baseMoveComponent.NeedRootMotionWhenAttached = true;
			}
			CharacterDriveVehicleComponent characterDriveVehicleComponent = (entity2 != null) ? entity2.GetComponent<CharacterDriveVehicleComponent>() : null;
			if (characterDriveVehicleComponent != null)
			{
				characterDriveVehicleComponent.IsAttachToMoveSceneItem = true;
			}
			if (entity2 != null)
			{
				CharacterActorComponent component2 = entity2.GetComponent<CharacterActorComponent>();
				if (component2 != null)
				{
					AActor owner = component2.Owner;
					if (owner != null)
					{
						owner.K2_AttachToActor((component != null) ? component.Owner : null, FName.NAME_None, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, true, true);
					}
				}
			}
			characterMovement.bKuroStopUpdateBasedMovement = true;
			Singleton<EventSystem>.Instance.EmitWithTarget<Entity, bool>(this.EntityHandle.Entity, EEventName.OnChangeBasedPlatform, entity, true);
		}
		EntityHandle entityHandle = this.EntityHandle;
		CSharpScript.Game.NewWorld.Common.Component.RoadNetworkNavigationComponent roadNetworkNavigationComponent;
		if (entityHandle == null)
		{
			roadNetworkNavigationComponent = null;
		}
		else
		{
			WorldEntity entity3 = entityHandle.Entity;
			roadNetworkNavigationComponent = ((entity3 != null) ? entity3.GetComponent<CSharpScript.Game.NewWorld.Common.Component.RoadNetworkNavigationComponent>() : null);
		}
		CSharpScript.Game.NewWorld.Common.Component.RoadNetworkNavigationComponent roadNetworkNavigationComponent2 = roadNetworkNavigationComponent;
		if (roadNetworkNavigationComponent2 != null)
		{
			roadNetworkNavigationComponent2.OnCharacterStandOn(entity.Id);
		}
	}

	// Token: 0x0400D7D2 RID: 55250
	public double LeaveSphereRadiusSq;

	// Token: 0x0400D7D3 RID: 55251
	protected readonly Vector CacheLocation = Vector.Create();

	// Token: 0x0400D7D4 RID: 55252
	private readonly List<int> PlatformTags = new List<int>();

	// Token: 0x0400D7D5 RID: 55253
	private readonly bool NeedAttach;
}
