using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.Vehicle;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.World.Define;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x0200327B RID: 12923
[NullableContext(1)]
[Nullable(0)]
public class VehiclePerformComponent : BaseVehiclePerformComponent
{
	// Token: 0x170024D4 RID: 9428
	// (get) Token: 0x0601B075 RID: 110709 RVA: 0x008156E9 File Offset: 0x008138E9
	[Nullable(2)]
	public Vector ActorLocationProxy
	{
		[NullableContext(2)]
		get
		{
			VehicleActorComponent actorComp = this.ActorComp;
			if (actorComp == null)
			{
				return null;
			}
			return actorComp.ActorLocationProxy;
		}
	}

	// Token: 0x170024D5 RID: 9429
	// (get) Token: 0x0601B076 RID: 110710 RVA: 0x008156FC File Offset: 0x008138FC
	[Nullable(2)]
	public Rotator ActorRotationProxy
	{
		[NullableContext(2)]
		get
		{
			VehicleActorComponent actorComp = this.ActorComp;
			if (actorComp == null)
			{
				return null;
			}
			return actorComp.ActorRotationProxy;
		}
	}

	// Token: 0x0601B077 RID: 110711 RVA: 0x00815710 File Offset: 0x00813910
	protected override bool OnStart()
	{
		if (!base.OnStart())
		{
			return false;
		}
		this.ActorComp = base.Entity.GetComponent<VehicleActorComponent>();
		this.AnimComp = base.Entity.GetComponent<VehicleAnimationComponent>();
		this.MoveComp = base.Entity.GetComponent<VehicleMoveComponent>();
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		this.HasRoleAndCtrlByMe = false;
		VehicleActorComponent actorComp = this.ActorComp;
		TsBaseVehicle tsBaseVehicle = ((actorComp != null) ? actorComp.Owner : null) as TsBaseVehicle;
		if (tsBaseVehicle != null && tsBaseVehicle.IsValid())
		{
			tsBaseVehicle.CapsuleComponent.OnComponentHit.Add(new Action<UPrimitiveComponent, AActor, UPrimitiveComponent, FVector, FHitResult>(this.OnEnterHitCollision));
		}
		return this.InitVehicleConfig();
	}

	// Token: 0x0601B078 RID: 110712 RVA: 0x008157BD File Offset: 0x008139BD
	protected override void OnTick(float delta)
	{
		this.UpdateRotYawSpeed(delta);
		if (Singleton<Time>.Instance.Frame != this.LastImpactFrame)
		{
			VehicleActorComponent actorComp = this.ActorComp;
			if (actorComp != null && actorComp.IsMoveAutonomousProxy)
			{
				this.IsBeingImpacted = false;
			}
		}
	}

	// Token: 0x0601B079 RID: 110713 RVA: 0x008157F4 File Offset: 0x008139F4
	[NullableContext(2)]
	protected override BP_VehicleConfig_C LoadVehicleConfigAsset()
	{
		VehicleActorComponent actorComp = this.ActorComp;
		bool flag;
		if (actorComp == null)
		{
			flag = true;
		}
		else
		{
			UKuroVehicleMovementComponent vehicleMovementComponent = actorComp.Actor.VehicleMovementComponent;
			flag = !((vehicleMovementComponent != null) ? new bool?(vehicleMovementComponent.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return null;
		}
		return base.LoadVehicleConfigAsset();
	}

	// Token: 0x0601B07A RID: 110714 RVA: 0x00815848 File Offset: 0x00813A48
	public override void Enter(Entity entity, int seat, bool byChangeRole = false)
	{
		base.Enter(entity, seat, byChangeRole);
		foreach (VehiclePassengerInfo vehiclePassengerInfo in this.PassengerInfoMap.Values)
		{
			if (vehiclePassengerInfo.IsDriver && vehiclePassengerInfo.IsRolePassenger(false))
			{
				if (base.Entity.GameBudgetManagedToken != 0U)
				{
					UKuroGameBudgetAllocatorCSharpInterface.MarkActorInFighting(Singleton<GameBudgetAllocatorConfigCreator>.Instance.TsNormalEntityGroupConfig.GroupName, base.Entity.GameBudgetManagedToken, true);
					break;
				}
				break;
			}
		}
		CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
		if (component != null && component.IsRoleAndCtrlByMe)
		{
			this.AddVehicleTagListeners();
		}
	}

	// Token: 0x0601B07B RID: 110715 RVA: 0x008158FC File Offset: 0x00813AFC
	public override void Leave(Entity entity, ELeaveVehicleType type = ELeaveVehicleType.Launch, bool byChangeRole = false)
	{
		base.Leave(entity, type, byChangeRole);
		bool flag = false;
		foreach (VehiclePassengerInfo vehiclePassengerInfo in this.PassengerInfoMap.Values)
		{
			if (vehiclePassengerInfo.IsDriver && vehiclePassengerInfo.IsRolePassenger(false))
			{
				flag = true;
				break;
			}
		}
		if (!flag && base.Entity.GameBudgetManagedToken != 0U)
		{
			UKuroGameBudgetAllocatorCSharpInterface.MarkActorInFighting(Singleton<GameBudgetAllocatorConfigCreator>.Instance.TsNormalEntityGroupConfig.GroupName, base.Entity.GameBudgetManagedToken, false);
		}
		CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
		if (component != null && component.IsRoleAndCtrlByMe)
		{
			this.RemoveVehicleTagListeners();
		}
		VehicleGravityComponent component2 = base.Entity.GetComponent<VehicleGravityComponent>();
		if (component2 == null)
		{
			return;
		}
		component2.OnPassengerLeave(entity);
	}

	// Token: 0x0601B07C RID: 110716 RVA: 0x008159D0 File Offset: 0x00813BD0
	public virtual bool CheckIfCanLeave()
	{
		return true;
	}

	// Token: 0x0601B07D RID: 110717 RVA: 0x008159D3 File Offset: 0x00813BD3
	public virtual bool CheckIfCanSprint()
	{
		return true;
	}

	// Token: 0x0601B07E RID: 110718 RVA: 0x008159D6 File Offset: 0x00813BD6
	public virtual bool CheckIfCanRiderSharing()
	{
		return ModelBase<VehicleModel>.Instance.IsReadyRiderSharing && !ModelBase<VehicleModel>.Instance.IsForbidRiderSharing;
	}

	// Token: 0x0601B07F RID: 110719 RVA: 0x008159F3 File Offset: 0x00813BF3
	public virtual void AddVehicleTagListeners()
	{
	}

	// Token: 0x0601B080 RID: 110720 RVA: 0x008159F5 File Offset: 0x00813BF5
	public virtual void RemoveVehicleTagListeners()
	{
	}

	// Token: 0x0601B081 RID: 110721 RVA: 0x008159F7 File Offset: 0x00813BF7
	public void RefreshRideSharingSkillState()
	{
		Singleton<EventSystem>.Instance.Emit<bool, EInputAction>(EEventName.OnVehicleSkillEnableChanged, this.CheckIfCanRiderSharing(), EInputAction.技能1);
	}

	// Token: 0x0601B082 RID: 110722 RVA: 0x00815A14 File Offset: 0x00813C14
	protected override void EnterVehiclePerform(VehiclePassengerInfo info)
	{
		if (info.IsRolePassenger(true))
		{
			this.HasRoleAndCtrlByMe = true;
			this.IgnorePlatformCollisionToCamera(true);
		}
		if (this.IsHidePassenger && info.PassengerEntity != null)
		{
			this.SetPassengerVisible(info.PassengerEntity, false);
		}
	}

	// Token: 0x0601B083 RID: 110723 RVA: 0x00815A4A File Offset: 0x00813C4A
	protected override void LeaveVehiclePerform(VehiclePassengerInfo info)
	{
		if (info.IsRolePassenger(true))
		{
			this.HasRoleAndCtrlByMe = false;
			this.IgnorePlatformCollisionToCamera(false);
		}
		if (this.IsHidePassenger && info.PassengerEntity != null)
		{
			this.SetPassengerVisible(info.PassengerEntity, true);
		}
	}

	// Token: 0x0601B084 RID: 110724 RVA: 0x00815A80 File Offset: 0x00813C80
	private void SetPassengerVisible(Entity entity, bool visible)
	{
		BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		int id = entity.Id;
		if (visible)
		{
			Dictionary<int, int> disableActorHandleMap = this.DisableActorHandleMap;
			int? num = (disableActorHandleMap != null) ? new int?(disableActorHandleMap.GetValueOrDefault(id)) : null;
			if (num != null)
			{
				component.EnableActor(num.Value);
				this.DisableActorHandleMap.Remove(id);
				return;
			}
		}
		else
		{
			if (this.DisableActorHandleMap == null)
			{
				this.DisableActorHandleMap = new Dictionary<int, int>();
			}
			int value = component.DisableActor("SetPassengerVisible");
			this.DisableActorHandleMap[id] = value;
		}
	}

	// Token: 0x0601B085 RID: 110725 RVA: 0x00815B24 File Offset: 0x00813D24
	protected void IgnorePlatformCollisionToCamera(bool ignore)
	{
		VehicleActorComponent actorComp = this.ActorComp;
		AActor aactor = (actorComp != null) ? actorComp.Actor.PlatformActor : null;
		if (aactor == null || !aactor.IsValid())
		{
			return;
		}
		UStaticMeshComponent ustaticMeshComponent = aactor.GetComponentByClass(UStaticMeshComponent.StaticClass()) as UStaticMeshComponent;
		if (ustaticMeshComponent == null || !ustaticMeshComponent.IsValid())
		{
			return;
		}
		if (ignore)
		{
			ustaticMeshComponent.SetCollisionResponseToChannel(KuroCollisionChannel.Camera, ECollisionResponse.ECR_Ignore);
			return;
		}
		ustaticMeshComponent.SetCollisionResponseToChannel(KuroCollisionChannel.Camera, ECollisionResponse.ECR_Block);
	}

	// Token: 0x0601B086 RID: 110726 RVA: 0x00815B9F File Offset: 0x00813D9F
	[NullableContext(2)]
	protected virtual void OnEnterHitCollision(UPrimitiveComponent hitComp, AActor otherActor, UPrimitiveComponent otherComp, FVector normalImpulse, [Nullable(1)] FHitResult hitResult)
	{
		this.CacheImpact(hitResult);
		this.OnHit(hitResult);
		VehicleMoveComponent moveComp = this.MoveComp;
		if (moveComp == null)
		{
			return;
		}
		moveComp.EnableUeMovementTick("载具受到碰撞");
	}

	// Token: 0x0601B087 RID: 110727 RVA: 0x00815BC6 File Offset: 0x00813DC6
	public virtual bool CheckCanPerformHit()
	{
		return true;
	}

	// Token: 0x0601B088 RID: 110728 RVA: 0x00815BC9 File Offset: 0x00813DC9
	public virtual void OnBulletHit(HitInformation hitData, BulletInfo bulletInfo)
	{
	}

	// Token: 0x0601B089 RID: 110729 RVA: 0x00815BCB File Offset: 0x00813DCB
	public override void GetVehicleVelocity(Vector output)
	{
		if (this.ActorComp == null)
		{
			return;
		}
		output.DeepCopy(this.ActorComp.ActorVelocityProxy);
	}

	// Token: 0x0601B08A RID: 110730 RVA: 0x00815BE8 File Offset: 0x00813DE8
	public void UpdateRotYawSpeed(float delta)
	{
		float yaw = this.LastActorRotation.Yaw;
		float yaw2 = this.ActorComp.ActorRotationProxy.Yaw;
		this.ActorComp.SimulatedRotYawSpeed = Singleton<MathUtils>.Instance.WrapAngle(yaw2 - yaw) / (delta * 0.001f);
		this.LastActorRotation.DeepCopy(this.ActorComp.ActorRotationProxy);
	}

	// Token: 0x0601B08B RID: 110731 RVA: 0x00815C48 File Offset: 0x00813E48
	protected void CacheImpact(FHitResult hitResult)
	{
		VehicleActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.IsMoveAutonomousProxy)
		{
			return;
		}
		this.LastImpactFrame = Singleton<Time>.Instance.Frame;
		this.IsBeingImpacted = true;
		Vector impactedVelocity = this.ImpactedVelocity;
		FVector velocity = this.MoveComp.VehicleMovement.Velocity;
		impactedVelocity.FromUeVector(velocity);
		this.CacheImpactHitResult = hitResult;
	}

	// Token: 0x0601B08C RID: 110732 RVA: 0x00815CAC File Offset: 0x00813EAC
	public void SimulatedImpactInfo(float velocityX, float velocityY, float velocityZ, float normalX, float normalY, float normalZ)
	{
		if (this.CacheImpactHitResult == null)
		{
			this.CacheImpactHitResult = new FHitResult();
		}
		if (this.SimulatedHitNormal == null)
		{
			this.SimulatedHitNormal = new FVector?(new FVector());
		}
		this.SimulatedHitNormal.Value.Set(normalX, normalY, normalZ);
		this.CacheImpactHitResult.Normal = new FVector_NetQuantizeNormal(this.SimulatedHitNormal.Value.X, this.SimulatedHitNormal.Value.Y, this.SimulatedHitNormal.Value.Z);
		this.ImpactedVelocity.Set((double)velocityX, (double)velocityY, (double)velocityZ);
	}

	// Token: 0x0601B08D RID: 110733 RVA: 0x00815D5C File Offset: 0x00813F5C
	protected virtual void OnHit(FHitResult hitResult)
	{
		VehicleConfig configInternal = this.ConfigInternal;
		if (((configInternal != null) ? configInternal.Asset : null) != null)
		{
			Entity driver = base.Driver;
			bool flag;
			if (driver == null)
			{
				flag = true;
			}
			else
			{
				CharacterActorComponent component = driver.GetComponent<CharacterActorComponent>();
				flag = !((component != null) ? new bool?(component.IsRoleAndCtrlByMe) : null).GetValueOrDefault();
			}
			if (!flag && Singleton<Time>.Instance.NowSeconds > this.NextCameraShakeTime)
			{
				Vector tmpVector = this.TmpVector1;
				FVector velocity = this.MoveComp.VehicleMovement.Velocity;
				tmpVector.FromUeVector(velocity);
				Vector tmpVector2 = this.TmpVector2;
				FVector_NetQuantizeNormal normal = hitResult.Normal;
				tmpVector2.FromUeVector(normal);
				double num = -this.TmpVector1.DotProduct(this.TmpVector2);
				if (num < 100.0)
				{
					return;
				}
				this.ActorComp.ActorQuatProxy.UnRotateVector(this.TmpVector2, this.TmpVector1);
				double num2 = Math.Abs(this.TmpVector1.Z) * num;
				double num3 = this.TmpVector1.Size2D() * num;
				BaseTagComponent tagComp = this.TagComp;
				bool flag2;
				if (tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.第一人称"]))
				{
					if (num3 >= num2)
					{
						flag2 = (this.ChooseCameraShake(this.ConfigInternal.Asset.撞击震屏_第一人称, num3) || this.ChooseCameraShake(this.ConfigInternal.Asset.撞击震屏Z_第一人称, num2));
					}
					else
					{
						flag2 = (this.ChooseCameraShake(this.ConfigInternal.Asset.撞击震屏Z_第一人称, num2) || this.ChooseCameraShake(this.ConfigInternal.Asset.撞击震屏_第一人称, num3));
					}
				}
				else if (num3 >= num2)
				{
					flag2 = (this.ChooseCameraShake(this.ConfigInternal.Asset.撞击震屏, num3) || this.ChooseCameraShake(this.ConfigInternal.Asset.撞击震屏Z, num2));
				}
				else
				{
					flag2 = (this.ChooseCameraShake(this.ConfigInternal.Asset.撞击震屏Z, num2) || this.ChooseCameraShake(this.ConfigInternal.Asset.撞击震屏, num3));
				}
				if (flag2)
				{
					this.NextCameraShakeTime = Singleton<Time>.Instance.NowSeconds + (double)this.ConfigInternal.Asset.震屏CD;
				}
				return;
			}
		}
	}

	// Token: 0x0601B08E RID: 110734 RVA: 0x00815F88 File Offset: 0x00814188
	protected bool ChooseCameraShake([Nullable(new byte[]
	{
		2,
		1
	})] TArray<SFloatThresholdAndCameraShake> shakeConfigs, double speed)
	{
		if (shakeConfigs == null)
		{
			return false;
		}
		int num = shakeConfigs.Num();
		int i = 0;
		while (i < num)
		{
			SFloatThresholdAndCameraShake sfloatThresholdAndCameraShake = shakeConfigs.Get(i);
			if (speed < (double)sfloatThresholdAndCameraShake.Threshold)
			{
				if (sfloatThresholdAndCameraShake.CameraShakeAndForceFeedback != null)
				{
					ControllerBase<CameraController>.Instance.PlayCameraShake(sfloatThresholdAndCameraShake.CameraShakeAndForceFeedback.Get().ToWeakClass(), null, null, null, true, false, "MainCamera");
					return true;
				}
				return false;
			}
			else
			{
				i++;
			}
		}
		return false;
	}

	// Token: 0x0601B08F RID: 110735 RVA: 0x00816024 File Offset: 0x00814224
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		VehiclePerformComponent vehiclePerformComponent = (VehiclePerformComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (vehiclePerformComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (vehiclePerformComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (vehiclePerformComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (vehiclePerformComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsBeingImpacted"))
		{
			this.IsBeingImpacted = vehiclePerformComponent.IsBeingImpacted;
		}
		if (base.CanResetComponentProperty("ImpactedVelocity"))
		{
			if (vehiclePerformComponent.ImpactedVelocity == null)
			{
				this.ImpactedVelocity = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.ImpactedVelocity), "ImpactedVelocity"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CacheImpactHitResult"))
		{
			if (vehiclePerformComponent.CacheImpactHitResult == null)
			{
				this.CacheImpactHitResult = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FHitResult>(this.CacheImpactHitResult), "CacheImpactHitResult"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SimulatedHitNormal"))
		{
			this.SimulatedHitNormal = vehiclePerformComponent.SimulatedHitNormal;
		}
		if (base.CanResetComponentProperty("LastImpactFrame"))
		{
			this.LastImpactFrame = vehiclePerformComponent.LastImpactFrame;
		}
		if (base.CanResetComponentProperty("CollisionVelocity"))
		{
			if (vehiclePerformComponent.CollisionVelocity == null)
			{
				this.CollisionVelocity = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.CollisionVelocity), "CollisionVelocity"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HasRoleAndCtrlByMe"))
		{
			this.HasRoleAndCtrlByMe = vehiclePerformComponent.HasRoleAndCtrlByMe;
		}
		if (base.CanResetComponentProperty("IsHidePassenger"))
		{
			this.IsHidePassenger = vehiclePerformComponent.IsHidePassenger;
		}
		if (base.CanResetComponentProperty("LastActorRotation"))
		{
			if (vehiclePerformComponent.LastActorRotation == null)
			{
				this.LastActorRotation = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.LastActorRotation), "LastActorRotation"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("VehicleTagListeners"))
		{
			if (vehiclePerformComponent.VehicleTagListeners == null)
			{
				this.VehicleTagListeners = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<ITagTask>>(this.VehicleTagListeners), "VehicleTagListeners"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DisableActorHandleMap"))
		{
			if (vehiclePerformComponent.DisableActorHandleMap == null)
			{
				this.DisableActorHandleMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, int>>(this.DisableActorHandleMap), "DisableActorHandleMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("NextCameraShakeTime"))
		{
			this.NextCameraShakeTime = vehiclePerformComponent.NextCameraShakeTime;
		}
		return true;
	}

	// Token: 0x0400DBBE RID: 56254
	[Nullable(2)]
	public VehicleActorComponent ActorComp;

	// Token: 0x0400DBBF RID: 56255
	[Nullable(2)]
	protected VehicleAnimationComponent AnimComp;

	// Token: 0x0400DBC0 RID: 56256
	[Nullable(2)]
	protected VehicleMoveComponent MoveComp;

	// Token: 0x0400DBC1 RID: 56257
	[Nullable(2)]
	protected BaseTagComponent TagComp;

	// Token: 0x0400DBC2 RID: 56258
	public bool IsBeingImpacted;

	// Token: 0x0400DBC3 RID: 56259
	public Vector ImpactedVelocity = Vector.Create();

	// Token: 0x0400DBC4 RID: 56260
	[Nullable(2)]
	public FHitResult CacheImpactHitResult;

	// Token: 0x0400DBC5 RID: 56261
	public FVector? SimulatedHitNormal;

	// Token: 0x0400DBC6 RID: 56262
	private int LastImpactFrame;

	// Token: 0x0400DBC7 RID: 56263
	public Vector CollisionVelocity = Vector.Create();

	// Token: 0x0400DBC8 RID: 56264
	public bool HasRoleAndCtrlByMe;

	// Token: 0x0400DBC9 RID: 56265
	public bool IsHidePassenger;

	// Token: 0x0400DBCA RID: 56266
	public Rotator LastActorRotation = Rotator.Create();

	// Token: 0x0400DBCB RID: 56267
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected List<ITagTask> VehicleTagListeners;

	// Token: 0x0400DBCC RID: 56268
	[Nullable(2)]
	private Dictionary<int, int> DisableActorHandleMap;

	// Token: 0x0400DBCD RID: 56269
	private double NextCameraShakeTime;
}
