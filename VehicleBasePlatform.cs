using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game;
using UnrealEngine;

// Token: 0x0200321A RID: 12826
[NullableContext(1)]
[Nullable(0)]
public class VehicleBasePlatform : BasePlatform
{
	// Token: 0x0601AA6D RID: 109165 RVA: 0x007ED258 File Offset: 0x007EB458
	public VehicleBasePlatform(EntityHandle entityHandle) : base(entityHandle)
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

	// Token: 0x0601AA6E RID: 109166 RVA: 0x007ED440 File Offset: 0x007EB640
	public override void TransformFromRelativeSpace(FVectorDouble inPosition, FRotator inRotation, ref FVectorDouble outPosition, ref FRotator outRotation)
	{
		EntityHandle entityHandle = this.EntityHandle;
		((entityHandle != null) ? entityHandle.Entity.GetComponent<VehicleActorComponent>() : null).SkeletalMesh.D_TransformFromBoneSpace(this.BoneName ?? FName.NAME_None, inPosition, inRotation, ref outPosition, ref outRotation);
	}

	// Token: 0x0601AA6F RID: 109167 RVA: 0x007ED494 File Offset: 0x007EB694
	public override void TransformToRelativeSpace(FVectorDouble inPosition, FRotator inRotation, ref FVectorDouble outPosition, ref FRotator outRotation)
	{
		EntityHandle entityHandle = this.EntityHandle;
		((entityHandle != null) ? entityHandle.Entity.GetComponent<VehicleActorComponent>() : null).SkeletalMesh.D_TransformToBoneSpace(this.BoneName ?? FName.NAME_None, inPosition, inRotation, ref outPosition, ref outRotation);
	}

	// Token: 0x0601AA70 RID: 109168 RVA: 0x007ED4E8 File Offset: 0x007EB6E8
	public override FTransformDouble? GetTransform()
	{
		EntityHandle entityHandle = this.EntityHandle;
		if (entityHandle == null)
		{
			return null;
		}
		return new FTransformDouble?(entityHandle.Entity.GetComponent<BaseActorComponent>().ActorTransform);
	}

	// Token: 0x0601AA71 RID: 109169 RVA: 0x007ED520 File Offset: 0x007EB720
	public override bool CheckLeave(Entity entity, Vector location)
	{
		EntityHandle entityHandle = this.EntityHandle;
		if (entityHandle == null || !entityHandle.Valid)
		{
			return true;
		}
		VehicleActorComponent component = this.EntityHandle.Entity.GetComponent<VehicleActorComponent>();
		this.CacheLocation.DeepCopy(component.ActorLocationProxy);
		if (Vector.DistSquared(location, this.CacheLocation) > this.LeaveSphereRadiusSq)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			Entity entity2 = (baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null;
			BaseTagComponent baseTagComponent = (entity2 != null) ? entity2.GetComponent<BaseTagComponent>() : null;
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
			return true;
		}
		return false;
	}

	// Token: 0x0601AA72 RID: 109170 RVA: 0x007ED604 File Offset: 0x007EB804
	public override void OnCharacterEnter(Entity entity, UCharacterMovementComponent characterMovement)
	{
		if (!this.EntityHandle.Valid)
		{
			return;
		}
		UeSkeletalTickManageComponent component = this.EntityHandle.Entity.GetComponent<UeSkeletalTickManageComponent>();
		if (component != null)
		{
			component.SetTakeOverTick(true);
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		Entity entity2 = (baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null;
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
	}

	// Token: 0x0400D7D6 RID: 55254
	public double LeaveSphereRadiusSq;

	// Token: 0x0400D7D7 RID: 55255
	public FName? BoneName = new FName?(new FName("Bone_Prop001"));

	// Token: 0x0400D7D8 RID: 55256
	protected readonly Vector CacheLocation = Vector.Create();

	// Token: 0x0400D7D9 RID: 55257
	private readonly List<int> PlatformTags = new List<int>();
}
