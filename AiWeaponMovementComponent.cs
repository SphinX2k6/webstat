using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game;
using CSharpScript.Game.Module.AiInteraction.AiWeapon;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x0200324A RID: 12874
[NullableContext(2)]
[Nullable(0)]
public class AiWeaponMovementComponent : EntityComponent
{
	// Token: 0x0601ACCA RID: 109770 RVA: 0x007FD300 File Offset: 0x007FB500
	protected override bool OnInitData(IEntityArgs args = null)
	{
		this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
		this.ItemMass = 0.01;
		WeaponComponent component = TdUtils.GetComponent<WeaponComponent>(this.CreatureDataComp.GetPbEntityInitData().ComponentsData, EConfigComponent.WeaponComponent);
		if (component != null)
		{
			int weaponId = component.WeaponId;
			SAiWeaponSocket staticWeaponConfig = ModelBase<AiWeaponModel>.Instance.GetStaticWeaponConfig(component.WeaponId);
			this.ItemMass = (double)staticWeaponConfig.Mass;
		}
		this.EnableMovement = new bool?(true);
		this.ItemMovementState = EItemMovementState.Born;
		return true;
	}

	// Token: 0x0601ACCB RID: 109771 RVA: 0x007FD381 File Offset: 0x007FB581
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
		return true;
	}

	// Token: 0x0601ACCC RID: 109772 RVA: 0x007FD395 File Offset: 0x007FB595
	protected override void OnTick(float delta)
	{
		if (this.EnableMovement == null || !this.EnableMovement.Value)
		{
			return;
		}
		this.UpdateMovement((double)delta);
	}

	// Token: 0x0601ACCD RID: 109773 RVA: 0x007FD3BC File Offset: 0x007FB5BC
	public void UpdateMovement(double delta)
	{
		this.ActorComp.SetActorLocation(this.ActorComp.StaticMesh.D_K2_GetComponentLocation(), "unknown", true);
		switch (this.ItemMovementState)
		{
		case EItemMovementState.Born:
			this.UpdateItemBorn(delta);
			return;
		case EItemMovementState.Fall:
			this.UpdateItemFall(delta);
			return;
		case EItemMovementState.Stay:
			this.UpdateItemStay(delta);
			return;
		default:
			return;
		}
	}

	// Token: 0x0601ACCE RID: 109774 RVA: 0x007FD41C File Offset: 0x007FB61C
	public void UpdateItemBorn(double delta)
	{
		global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
		if (this.CreatureDataComp.GetInitLinearVelocity() != null)
		{
			commonTempVector.FromConfigVector(this.CreatureDataComp.GetInitLinearVelocity());
		}
		else
		{
			commonTempVector.FromConfigVector(global::Vector.ZeroVector);
		}
		if (commonTempVector.IsNearlyZero(9.999999747378752E-05))
		{
			this.ItemMovementState = EItemMovementState.Stay;
			return;
		}
		this.InitPhysics();
		this.ItemMovementState = EItemMovementState.Fall;
	}

	// Token: 0x0601ACCF RID: 109775 RVA: 0x007FD48C File Offset: 0x007FB68C
	public void UpdateItemFall(double delta)
	{
		if (!this.CheckDropOutOfRange() && !this.CheckDropAtGround() && !this.CheckDropAtWater())
		{
			return;
		}
		this.ItemMovementState = EItemMovementState.Stay;
		this.DisablePhysics();
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			SceneItemMovementSyncComponent component = base.Entity.GetComponent<SceneItemMovementSyncComponent>();
			if (component == null)
			{
				return;
			}
			component.CollectSampleAndSend(true);
		}
	}

	// Token: 0x0601ACD0 RID: 109776 RVA: 0x007FD4E1 File Offset: 0x007FB6E1
	public void UpdateItemStay(double delta)
	{
		this.EnableMovement = new bool?(false);
	}

	// Token: 0x0601ACD1 RID: 109777 RVA: 0x007FD4F0 File Offset: 0x007FB6F0
	private void InitPhysics()
	{
		UStaticMeshComponent staticMesh = this.ActorComp.StaticMesh;
		staticMesh.SetCollisionProfileName(AiWeaponMovementComponent.COLLISION_PROFILE_NAME, true);
		staticMesh.SetCollisionEnabled(ECollisionEnabled.PhysicsOnly);
		staticMesh.SetSimulatePhysics(true);
		if (this.ItemMass >= 0.0)
		{
			staticMesh.SetMassOverrideInKg(FNameUtil.NONE, (float)this.ItemMass, true);
		}
		staticMesh.SetEnableGravity(true);
		staticMesh.SetConstraintMode(EDOFMode.None);
		staticMesh.SetUseCCD(true, default(FName));
		global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
		if (this.CreatureDataComp.GetInitLinearVelocity() != null)
		{
			commonTempVector.FromConfigVector(this.CreatureDataComp.GetInitLinearVelocity());
		}
		else
		{
			commonTempVector.FromConfigVector(global::Vector.ZeroVector);
		}
		if (commonTempVector.SizeSquared2D() <= 4.0)
		{
			global::Vector vector = global::Vector.Create();
			commonTempVector.GetSignVector(vector);
			vector.MultiplyEqual(Math.Sqrt(5.0));
			vector.Z = 0.0;
			commonTempVector.AdditionEqual(vector);
		}
		staticMesh.SetPhysicsLinearVelocity(commonTempVector.ToUeVectorOld(), false, default(FName));
	}

	// Token: 0x0601ACD2 RID: 109778 RVA: 0x007FD600 File Offset: 0x007FB800
	private void DisablePhysics()
	{
		UStaticMeshComponent staticMesh = this.ActorComp.StaticMesh;
		staticMesh.SetCollisionEnabled(ECollisionEnabled.NoCollision);
		staticMesh.SetSimulatePhysics(false);
		staticMesh.SetEnableGravity(false);
		staticMesh.SetPhysicsLinearVelocity(global::Vector.ZeroVector, false, default(FName));
		staticMesh.SetPhysicsAngularVelocity(global::Vector.ZeroVector, false, default(FName));
		staticMesh.SetConstraintMode(EDOFMode.Default);
		staticMesh.SetUseCCD(false, default(FName));
	}

	// Token: 0x0601ACD3 RID: 109779 RVA: 0x007FD670 File Offset: 0x007FB870
	private void InitWaterTrace()
	{
		if (this.TraceElement == null)
		{
			this.TraceElement = new UTraceLineElement();
		}
		this.TraceElement.WorldContextObject = GlobalData.World;
		this.TraceElement.bIsSingle = true;
		this.TraceElement.bIgnoreSelf = true;
		this.TraceElement.SetTraceTypeQuery(KuroTraceTypeQuery.Water);
		this.TraceElement.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
		this.TraceElement.DrawTime = 5f;
		Singleton<TraceElementCommon>.Instance.SetTraceColor(this.TraceElement, ColorUtils.LinearGreen);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.TraceElement, ColorUtils.LinearRed);
	}

	// Token: 0x0601ACD4 RID: 109780 RVA: 0x007FD710 File Offset: 0x007FB910
	private bool TraceHitWater(double zOffset)
	{
		this.InitWaterTrace();
		global::Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
		this.TraceElement.SetStartLocation(actorLocationProxy.X, actorLocationProxy.Y, actorLocationProxy.Z);
		this.TraceElement.SetEndLocation(actorLocationProxy.X, actorLocationProxy.Y, actorLocationProxy.Z + zOffset);
		bool result;
		if (Singleton<TraceElementCommon>.Instance.LineTrace(this.TraceElement, "AiWeaponMovementComponent.TraceHitWater"))
		{
			UKuroHitResult hitResult = this.TraceElement.HitResult;
			result = (hitResult != null && hitResult.bBlockingHit);
		}
		else
		{
			result = false;
		}
		this.TraceElement.ClearCacheData(false);
		return result;
	}

	// Token: 0x0601ACD5 RID: 109781 RVA: 0x007FD7A8 File Offset: 0x007FB9A8
	private bool CheckDropOutOfRange()
	{
		if (this.ActorComp.StaticMesh.GetComponentVelocity().Z > 0f)
		{
			return false;
		}
		Aki.Protocol.Vector initLocation = this.CreatureDataComp.GetInitLocation();
		if (Math.Abs((initLocation != null) ? (this.ActorComp.ActorLocationProxy.Z - (double)initLocation.Z) : 0.0) > 10000.0)
		{
			return true;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		FVectorDouble? fvectorDouble = (baseCharacter != null) ? new FVectorDouble?(baseCharacter.CharacterActorComponent.ActorLocation) : null;
		return Math.Abs((fvectorDouble != null) ? (this.ActorComp.ActorLocationProxy.Z - fvectorDouble.Value.Z) : 0.0) > 10000.0;
	}

	// Token: 0x0601ACD6 RID: 109782 RVA: 0x007FD880 File Offset: 0x007FBA80
	private bool CheckDropAtGround()
	{
		FVector componentVelocity = this.ActorComp.StaticMesh.GetComponentVelocity();
		return componentVelocity.Z <= 0f && (double)Math.Abs(componentVelocity.Z) <= 2.0 && (double)componentVelocity.SizeSquared2D() <= 4.0;
	}

	// Token: 0x0601ACD7 RID: 109783 RVA: 0x007FD8D8 File Offset: 0x007FBAD8
	private bool CheckDropAtWater()
	{
		return this.ActorComp.StaticMesh.GetComponentVelocity().Z <= 0f && this.TraceHitWater(-5.0);
	}

	// Token: 0x0601ACD8 RID: 109784 RVA: 0x007FD90C File Offset: 0x007FBB0C
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		AiWeaponMovementComponent aiWeaponMovementComponent = (AiWeaponMovementComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (aiWeaponMovementComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CreatureDataComp"))
		{
			if (aiWeaponMovementComponent.CreatureDataComp == null)
			{
				this.CreatureDataComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("EnableMovement"))
		{
			this.EnableMovement = aiWeaponMovementComponent.EnableMovement;
		}
		if (base.CanResetComponentProperty("ItemMovementState"))
		{
			this.ItemMovementState = aiWeaponMovementComponent.ItemMovementState;
		}
		if (base.CanResetComponentProperty("ItemMass"))
		{
			this.ItemMass = aiWeaponMovementComponent.ItemMass;
		}
		if (base.CanResetComponentProperty("TraceElement"))
		{
			if (aiWeaponMovementComponent.TraceElement == null)
			{
				this.TraceElement = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceLineElement>(this.TraceElement), "TraceElement"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400D957 RID: 55639
	private static readonly FName COLLISION_PROFILE_NAME = new FName("DropItem");

	// Token: 0x0400D958 RID: 55640
	private const double GROUND_MAX_XY_VEL_SQUARED = 4.0;

	// Token: 0x0400D959 RID: 55641
	private const double GROUND_MAX_Z_VEL = 2.0;

	// Token: 0x0400D95A RID: 55642
	private const double MAX_DROP_HEIGHT = 10000.0;

	// Token: 0x0400D95B RID: 55643
	private const double ON_WATER_MAX_DIST = 5.0;

	// Token: 0x0400D95C RID: 55644
	private SceneItemActorComponent ActorComp;

	// Token: 0x0400D95D RID: 55645
	private CreatureDataComponent CreatureDataComp;

	// Token: 0x0400D95E RID: 55646
	public bool? EnableMovement;

	// Token: 0x0400D95F RID: 55647
	private EItemMovementState ItemMovementState = EItemMovementState.Fall;

	// Token: 0x0400D960 RID: 55648
	private double ItemMass;

	// Token: 0x0400D961 RID: 55649
	private UTraceLineElement TraceElement;
}
