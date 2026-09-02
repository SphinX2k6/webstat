using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Vehicle.Motor.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Capability
{
	// Token: 0x0200498D RID: 18829
	[NullableContext(2)]
	[Nullable(0)]
	public class FreezeWaterRenderCapability : WaterDetectedCapability
	{
		// Token: 0x170083E3 RID: 33763
		// (get) Token: 0x0603130B RID: 201483 RVA: 0x00C3F558 File Offset: 0x00C3D758
		public AActor Actor
		{
			get
			{
				return this.ActorInternal;
			}
		}

		// Token: 0x0603130C RID: 201484 RVA: 0x00C3F560 File Offset: 0x00C3D760
		[NullableContext(1)]
		public FreezeWaterRenderCapability(AActor Invoker, UKuroTrailCollisionAsset KuroTrailCollisionAsset)
		{
			this.Invoker = Invoker;
			this.KuroTrailCollisionAsset = KuroTrailCollisionAsset;
			AActor invoker = this.Invoker;
			if (invoker == null || !invoker.IsValid())
			{
				return;
			}
			this.ActorInternal = Singleton<ActorSystem>.Instance.Spawn(AActor.StaticClass(), this.Invoker.D_GetTransform(), this.Invoker);
			AActor actorInternal = this.ActorInternal;
			if (actorInternal == null || !actorInternal.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("MotorcycleFreezeWaterComponent.CreateFreezeWaterDependency fail", this.ActorInternal, null);
				return;
			}
			this.ActorInternal.D_AddComponentByClass(USceneComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransformDouble, false, default(FName));
		}

		// Token: 0x0603130D RID: 201485 RVA: 0x00C3F619 File Offset: 0x00C3D819
		public override void Activate()
		{
			this.AddWaterInteractionComponent();
		}

		// Token: 0x0603130E RID: 201486 RVA: 0x00C3F622 File Offset: 0x00C3D822
		public override void Deactivate()
		{
			AActor actorInternal = this.ActorInternal;
			if (actorInternal == null || !actorInternal.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("MotorcycleFreezeWaterComponent.OnEnd", this.ActorInternal, null);
			}
			this.ActorInternal = null;
		}

		// Token: 0x0603130F RID: 201487 RVA: 0x00C3F659 File Offset: 0x00C3D859
		public override void OnWaterDetectedStart()
		{
			this.DetectingWater = true;
		}

		// Token: 0x06031310 RID: 201488 RVA: 0x00C3F662 File Offset: 0x00C3D862
		public override void OnWaterDetectedEnd()
		{
			this.DetectingWater = false;
		}

		// Token: 0x06031311 RID: 201489 RVA: 0x00C3F66C File Offset: 0x00C3D86C
		[NullableContext(1)]
		public override void OnWaterDetectedTick(float deltaTime, Vector impactPoint, Vector impactNormal)
		{
			if (!this.DetectingWater)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Movement, ELogAuthor.XDW, "FreezeWaterRenderCapability 检查BroadcastWaterDetectedTick逻辑, 未调用Start就开始Tick", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			FHitResult fhitResult = new FHitResult();
			AActor actorInternal = this.ActorInternal;
			if (actorInternal == null)
			{
				return;
			}
			actorInternal.D_K2_SetActorLocation(impactPoint.ToUeVector(false), false, ref fhitResult, false);
		}

		// Token: 0x06031312 RID: 201490 RVA: 0x00C3F6C0 File Offset: 0x00C3D8C0
		private BP_KuroMotorcycleFreezeWaterComponent_C AddWaterInteractionComponent()
		{
			AActor actorInternal = this.ActorInternal;
			if (actorInternal == null || !actorInternal.IsValid())
			{
				return null;
			}
			AActor invoker = this.Invoker;
			if (invoker == null || !invoker.IsValid())
			{
				return null;
			}
			BP_KuroMotorcycleFreezeWaterComponent_C bp_KuroMotorcycleFreezeWaterComponent_C = this.ActorInternal.D_AddComponentByClass(BP_KuroMotorcycleFreezeWaterComponent_C.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransformDouble, true, default(FName)) as BP_KuroMotorcycleFreezeWaterComponent_C;
			if (bp_KuroMotorcycleFreezeWaterComponent_C == null || !bp_KuroMotorcycleFreezeWaterComponent_C.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Motor, ELogAuthor.XDW, "MotorcycleFreezeWaterComponent.AddWaterInteractionComponent: materialComp is invalid", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			bp_KuroMotorcycleFreezeWaterComponent_C.Invoker = this.Invoker;
			this.ActorInternal.FinishAddComponent(bp_KuroMotorcycleFreezeWaterComponent_C, false, Singleton<MathUtils>.Instance.DefaultTransform);
			bp_KuroMotorcycleFreezeWaterComponent_C.SetRelativeScale3D(new FVector(40.96f));
			return bp_KuroMotorcycleFreezeWaterComponent_C;
		}

		// Token: 0x06031313 RID: 201491 RVA: 0x00C3F798 File Offset: 0x00C3D998
		public static UKuroEnviInteractionComponent CheckKuroWaterDetectedInterface(AActor actor)
		{
			if (actor == null || !actor.IsValid())
			{
				return null;
			}
			UKuroEnviInteractionComponent ukuroEnviInteractionComponent = actor.GetComponentByClass(UKuroEnviInteractionComponent.StaticClass()) as UKuroEnviInteractionComponent;
			if (ukuroEnviInteractionComponent == null || !ukuroEnviInteractionComponent.IsValid())
			{
				return null;
			}
			if (ukuroEnviInteractionComponent == null)
			{
				return null;
			}
			return ukuroEnviInteractionComponent;
		}

		// Token: 0x0401C4EC RID: 115948
		private const float ICE_MESH_SCALE = 40.96f;

		// Token: 0x0401C4ED RID: 115949
		private AActor ActorInternal;

		// Token: 0x0401C4EE RID: 115950
		private bool DetectingWater;

		// Token: 0x0401C4EF RID: 115951
		[Nullable(1)]
		private readonly AActor Invoker;

		// Token: 0x0401C4F0 RID: 115952
		public UKuroTrailCollisionAsset KuroTrailCollisionAsset;
	}
}
