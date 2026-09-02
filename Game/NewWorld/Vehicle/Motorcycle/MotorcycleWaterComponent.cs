using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle
{
	// Token: 0x020047AF RID: 18351
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleWaterComponent : EntityComponent, IComponentDependency
	{
		// Token: 0x170081C2 RID: 33218
		// (get) Token: 0x0602FA09 RID: 195081 RVA: 0x00B5DE7D File Offset: 0x00B5C07D
		public static Type[] Dependencies
		{
			get
			{
				return new Type[]
				{
					typeof(VehicleActorComponent),
					typeof(VehicleMoveComponent)
				};
			}
		}

		// Token: 0x170081C3 RID: 33219
		// (get) Token: 0x0602FA0A RID: 195082 RVA: 0x00B5DE9F File Offset: 0x00B5C09F
		// (set) Token: 0x0602FA0B RID: 195083 RVA: 0x00B5DEA8 File Offset: 0x00B5C0A8
		protected bool Immersion
		{
			get
			{
				return this.ImmersionInternal;
			}
			set
			{
				if (this.ImmersionInternal == value)
				{
					return;
				}
				this.ImmersionInternal = value;
				if (value)
				{
					BaseTagComponent tagComp = this.TagComp;
					if (tagComp == null)
					{
						return;
					}
					tagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.车体浸水"]));
					return;
				}
				else
				{
					BaseTagComponent tagComp2 = this.TagComp;
					if (tagComp2 == null)
					{
						return;
					}
					tagComp2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.车体浸水"]));
					return;
				}
			}
		}

		// Token: 0x170081C4 RID: 33220
		// (get) Token: 0x0602FA0C RID: 195084 RVA: 0x00B5DF13 File Offset: 0x00B5C113
		// (set) Token: 0x0602FA0D RID: 195085 RVA: 0x00B5DF1C File Offset: 0x00B5C11C
		public bool InSwimArea
		{
			get
			{
				return this.InSwimAreaInternal;
			}
			protected set
			{
				if (this.InSwimAreaInternal == value)
				{
					return;
				}
				this.InSwimAreaInternal = value;
				Singleton<EventSystem>.Instance.EmitWithTarget<bool>(base.Entity, EEventName.MotorcycleWaterAreaChange, value);
				if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("MotorWater") > 0)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Motor;
					ELogAuthor author = ELogAuthor.XDW;
					string message = "MotorcycleWaterComponent.MotorcycleWaterAreaChange";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InArea", value);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
		}

		// Token: 0x0602FA0E RID: 195086 RVA: 0x00B5DF94 File Offset: 0x00B5C194
		private void RefreshSwimAreaHeight()
		{
			if (this.MoveComp != null && !this.MoveComp.IsStandardGravity)
			{
				this.InSwimArea = true;
				this.SwimAreaHeightAboveActor = 500.0;
				return;
			}
			float num = 0f;
			UObject owner = this.ActorComp.Owner;
			FVectorDouble actorLocation = this.ActorComp.ActorLocation;
			this.InSwimArea = UNavigationSystemV1.D_NavigationGetWaterSurface(owner, actorLocation, this.WaterAreaDetectExtent, ref num, this.ActorComp.Owner, null, 150f);
			if (this.InSwimArea)
			{
				double num2 = (double)num;
				this.SwimAreaHeightAboveActor = num2 - this.ActorComp.ActorLocationProxy.Z + 100.0;
				return;
			}
			this.SwimAreaHeightAboveActor = 0.0;
		}

		// Token: 0x0602FA0F RID: 195087 RVA: 0x00B5E054 File Offset: 0x00B5C254
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<VehicleActorComponent>();
			this.MoveComp = base.Entity.GetComponent<VehicleMoveComponent>();
			this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
			this.TraceWaterCapability = new MotorcycleTraceWaterCapability(this.ActorComp);
			this.TraceWaterCapability.Activate();
			Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenEntered));
			Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenLeaved, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenLeaved));
			return true;
		}

		// Token: 0x0602FA10 RID: 195088 RVA: 0x00B5E0F8 File Offset: 0x00B5C2F8
		protected override bool OnEnd()
		{
			this.ActorComp = null;
			this.MoveComp = null;
			this.TagComp = null;
			MotorcycleTraceWaterCapability traceWaterCapability = this.TraceWaterCapability;
			if (traceWaterCapability != null)
			{
				traceWaterCapability.Deactivate();
			}
			this.TraceWaterCapability = null;
			Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenEntered));
			Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenLeaved, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenLeaved));
			return true;
		}

		// Token: 0x0602FA11 RID: 195089 RVA: 0x00B5E178 File Offset: 0x00B5C378
		protected override void OnTick(float delta)
		{
			VehicleActorComponent actorComp = this.ActorComp;
			if (this.LastPosition.Equals(actorComp.ActorLocationProxy, 1.0))
			{
				return;
			}
			this.LastPosition.DeepCopy(actorComp.ActorLocationProxy);
			this.RefreshSwimAreaHeight();
			if (!this.InSwimArea || this.TraceWaterCapability == null)
			{
				this.Immersion = false;
				return;
			}
			VehicleMoveComponent moveComp = this.MoveComp;
			TEnumAsByte<ECollisionResponse>? tenumAsByte;
			if (moveComp == null)
			{
				tenumAsByte = null;
			}
			else
			{
				UKuroVehicleMovementComponent vehicleMovement = moveComp.VehicleMovement;
				if (vehicleMovement == null)
				{
					tenumAsByte = null;
				}
				else
				{
					UPrimitiveComponent updatedPrimitive = vehicleMovement.UpdatedPrimitive;
					tenumAsByte = ((updatedPrimitive != null) ? new TEnumAsByte<ECollisionResponse>?(updatedPrimitive.GetCollisionResponseToChannel(KuroCollisionChannel.KuroWater)) : null);
				}
			}
			if (tenumAsByte == ECollisionResponse.ECR_Block)
			{
				this.Immersion = false;
				return;
			}
			TraceWaterResult traceWaterResult = this.TraceWaterCapability.TraceWater(this.SwimAreaHeightAboveActor, this.IMMERSION_DEPTH);
			if (!traceWaterResult.FoundWater)
			{
				this.Immersion = false;
				return;
			}
			if (this.TraceWaterCapability.CeilingCheck((double)traceWaterResult.MinWaterHeight))
			{
				this.Immersion = false;
				return;
			}
			if ((double)traceWaterResult.MinWaterHeight > this.LEAVE_MOTOR_DEPTH)
			{
				if (this.NextSendLeaveTime <= Singleton<Time>.Instance.Now)
				{
					this.NextSendLeaveTime = Singleton<Time>.Instance.Now + this.SEND_LEAVE_PERIOD;
					BaseVehiclePerformComponent component = base.Entity.GetComponent<BaseVehiclePerformComponent>();
					if (component != null)
					{
						component.TryLeaveAllAtOnce(ELeaveVehicleType.StandUp, "MotorWater");
					}
					ControllerBase<CreatureController>.Instance.SetEntityEnable(base.Entity, false, "MotorWater", true);
					this.Immersion = false;
					return;
				}
			}
			else
			{
				if ((double)traceWaterResult.MinWaterHeight > this.IMMERSION_DEPTH)
				{
					this.Immersion = true;
					return;
				}
				this.Immersion = false;
			}
		}

		// Token: 0x0602FA12 RID: 195090 RVA: 0x00B5E329 File Offset: 0x00B5C529
		private void OnVehicleBeenEntered(VehiclePassengerInfo info, bool byChangeRole)
		{
			if (this.DisableHandle != null)
			{
				base.Enable(new int?(this.DisableHandle.Value), this.WATER_COMP_DISABLE_REASON);
			}
			this.DisableHandle = null;
			this.RefreshSwimAreaHeight();
		}

		// Token: 0x0602FA13 RID: 195091 RVA: 0x00B5E367 File Offset: 0x00B5C567
		private void OnVehicleBeenLeaved(VehiclePassengerInfo info, bool byChangeRole)
		{
			this.InSwimArea = false;
			this.Immersion = false;
			this.DisableHandle = new int?(base.Disable(this.WATER_COMP_DISABLE_REASON));
		}

		// Token: 0x0602FA14 RID: 195092 RVA: 0x00B5E390 File Offset: 0x00B5C590
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			MotorcycleWaterComponent motorcycleWaterComponent = (MotorcycleWaterComponent)componentTemplate;
			if (base.CanResetComponentProperty("TraceWaterCapability"))
			{
				if (motorcycleWaterComponent.TraceWaterCapability == null)
				{
					this.TraceWaterCapability = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MotorcycleTraceWaterCapability>(this.TraceWaterCapability), "TraceWaterCapability"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (motorcycleWaterComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (motorcycleWaterComponent.MoveComp == null)
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
				if (motorcycleWaterComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("InSwimAreaInternal"))
			{
				this.InSwimAreaInternal = motorcycleWaterComponent.InSwimAreaInternal;
			}
			if (base.CanResetComponentProperty("SwimAreaHeightAboveActor"))
			{
				this.SwimAreaHeightAboveActor = motorcycleWaterComponent.SwimAreaHeightAboveActor;
			}
			if (base.CanResetComponentProperty("NextSendLeaveTime"))
			{
				this.NextSendLeaveTime = motorcycleWaterComponent.NextSendLeaveTime;
			}
			if (base.CanResetComponentProperty("LastPosition") && motorcycleWaterComponent.LastPosition != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.LastPosition), "LastPosition"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("DisableHandle"))
			{
				this.DisableHandle = motorcycleWaterComponent.DisableHandle;
			}
			if (base.CanResetComponentProperty("ImmersionInternal"))
			{
				this.ImmersionInternal = motorcycleWaterComponent.ImmersionInternal;
			}
			return true;
		}

		// Token: 0x0401B3FB RID: 111611
		private readonly FVectorDouble WaterAreaDetectExtent = new FVectorDouble(500.0, 500.0, 5000.0);

		// Token: 0x0401B3FC RID: 111612
		private readonly double IMMERSION_DEPTH = -5.0;

		// Token: 0x0401B3FD RID: 111613
		private readonly double LEAVE_MOTOR_DEPTH = 85.0;

		// Token: 0x0401B3FE RID: 111614
		private readonly double SEND_LEAVE_PERIOD = 1000.0;

		// Token: 0x0401B3FF RID: 111615
		private readonly string WATER_COMP_DISABLE_REASON = "OnVehicleBeenEntered";

		// Token: 0x0401B400 RID: 111616
		[Nullable(2)]
		public MotorcycleTraceWaterCapability TraceWaterCapability;

		// Token: 0x0401B401 RID: 111617
		[Nullable(2)]
		protected VehicleActorComponent ActorComp;

		// Token: 0x0401B402 RID: 111618
		[Nullable(2)]
		protected VehicleMoveComponent MoveComp;

		// Token: 0x0401B403 RID: 111619
		[Nullable(2)]
		protected BaseTagComponent TagComp;

		// Token: 0x0401B404 RID: 111620
		private bool InSwimAreaInternal;

		// Token: 0x0401B405 RID: 111621
		private double SwimAreaHeightAboveActor;

		// Token: 0x0401B406 RID: 111622
		private double NextSendLeaveTime;

		// Token: 0x0401B407 RID: 111623
		private readonly Vector LastPosition = Vector.Create();

		// Token: 0x0401B408 RID: 111624
		private int? DisableHandle;

		// Token: 0x0401B409 RID: 111625
		private bool ImmersionInternal;
	}
}
