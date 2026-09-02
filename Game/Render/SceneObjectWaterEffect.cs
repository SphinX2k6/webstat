using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.WaterInteraction;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200478E RID: 18318
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneObjectWaterEffect
	{
		// Token: 0x0602F890 RID: 194704 RVA: 0x00B523D4 File Offset: 0x00B505D4
		private void InitTraceInfo()
		{
			UTraceSphereElement utraceSphereElement = new UTraceSphereElement();
			utraceSphereElement.WorldContextObject = GlobalData.World;
			utraceSphereElement.bIsSingle = false;
			utraceSphereElement.bIgnoreSelf = true;
			utraceSphereElement.Radius = this.Radius;
			utraceSphereElement.SetTraceTypeQuery(KuroTraceTypeQuery.Water);
			if (Singleton<EffectGlobal>.Instance.SceneObjectWaterEffectShowDebugTrace)
			{
				utraceSphereElement.DrawTime = 5f;
				Singleton<TraceElementCommon>.Instance.SetTraceColor(utraceSphereElement, ColorUtils.LinearGreen);
				Singleton<TraceElementCommon>.Instance.SetTraceHitColor(utraceSphereElement, ColorUtils.LinearRed);
				utraceSphereElement.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
			}
			else
			{
				utraceSphereElement.SetDrawDebugTrace(EDrawDebugTrace.None);
			}
			this.SphereTrace = utraceSphereElement;
		}

		// Token: 0x0602F891 RID: 194705 RVA: 0x00B52468 File Offset: 0x00B50668
		public void Start(SWaterEffectObject config, USceneComponent actorToAttach)
		{
			if (config == null || actorToAttach == null)
			{
				return;
			}
			this.Config = config;
			this.ActorToAttach = actorToAttach;
			this.Radius = this.Config.Radius;
			FTransformDouble value = UKismetMathLibrary.Conv_TransformToTransformDouble(this.Config.Transform);
			this.Transform = new FTransformDouble?(value);
			this.Effect = this.Config.Effect.ToAssetPathName();
			this.TriggerOnce = this.Config.TriggerOnce;
			this.EnableSurfaceEffect = this.Config.EnableSurfaceEffect;
			this.TimeAfterSurfaceEffectStop = this.Config.TimeAfterSurfaceEffectStop;
			if (!this.TriggerOnce && this.EnableSurfaceEffect)
			{
				this.WaterSurfaceEffect = this.Config.WaterSurfaceEffect.ToAssetPathName();
			}
			this.TempUeVector = new FVector?(new FVector());
			this.TempVector = Vector.Create();
			this.TempVector1 = Vector.Create();
			this.TempPosition = Vector.Create();
			this.LastPosition = Vector.Create();
			this.IsReady = true;
			this.InitTraceInfo();
			Singleton<Log>.Instance.Info(ELogModule.RenderEffect, ELogAuthor.LSY, "SceneObjectWaterEffect Start", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602F892 RID: 194706 RVA: 0x00B52594 File Offset: 0x00B50794
		protected void GetActorLocation()
		{
			Vector tempVector = this.TempVector;
			FVectorDouble fvectorDouble = this.ActorToAttach.D_K2_GetComponentLocation();
			tempVector.FromUeVector(fvectorDouble);
		}

		// Token: 0x0602F893 RID: 194707 RVA: 0x00B525BA File Offset: 0x00B507BA
		public void AfterRegistered()
		{
			if (!this.IsReady)
			{
				return;
			}
			this.WasHitWater = false;
			this.GetActorLocation();
			this.LastPosition.DeepCopy(this.TempVector);
			this.IsEnabled = true;
		}

		// Token: 0x0602F894 RID: 194708 RVA: 0x00B525EA File Offset: 0x00B507EA
		public void BeforeUnregistered()
		{
			if (!this.IsEnabled)
			{
				return;
			}
			this.StopEffect();
			this.IsEnabled = false;
		}

		// Token: 0x0602F895 RID: 194709 RVA: 0x00B52604 File Offset: 0x00B50804
		public void Update(float deltaSeconds)
		{
			if (this.IsEnabled)
			{
				USceneComponent actorToAttach = this.ActorToAttach;
				if (actorToAttach != null && actorToAttach.IsValid())
				{
					bool flag = false;
					this.GetActorLocation();
					UTraceSphereElement sphereTrace = this.SphereTrace;
					Singleton<TraceElementCommon>.Instance.SetStartLocation(sphereTrace, this.LastPosition);
					Singleton<TraceElementCommon>.Instance.SetEndLocation(sphereTrace, this.TempVector);
					bool flag2 = Singleton<TraceElementCommon>.Instance.SphereTrace(sphereTrace, "SceneObjectWaterEffect_Update");
					UKuroHitResult hitResult = sphereTrace.HitResult;
					if (flag2 && hitResult != null)
					{
						UKuroHitResult ukuroHitResult = hitResult;
						if (ukuroHitResult.bBlockingHit)
						{
							int hitCount = ukuroHitResult.GetHitCount();
							for (int i = 0; i < hitCount; i++)
							{
								FName collisionProfileName = UKuroCollisionLibrary.GetCollisionProfileName(ukuroHitResult.Components.Get(i), i);
								if (RenderConfig.WaterCollisionProfileName == collisionProfileName)
								{
									this.WaterHeight = (double)ukuroHitResult.ImpactPointZ_Array.Get(i);
									this.TempPosition.DeepCopy(this.TempVector);
									this.TempPosition.Z = this.WaterHeight;
									flag = true;
									break;
								}
							}
						}
					}
					if (flag != this.WasHitWater)
					{
						this.SpawnFallEffect(this.Effect, this.TempPosition);
						if (this.TriggerOnce)
						{
							this.StopEffect();
							this.IsEnabled = false;
						}
					}
					if (this.EnableSurfaceEffect && flag && this.WasHitWater)
					{
						if (!Singleton<EffectSystem>.Instance.IsValid(this.SurfaceHandle))
						{
							this.SpawnEffect(this.WaterSurfaceEffect);
						}
						if (Singleton<EffectSystem>.Instance.IsValid(this.SurfaceHandle))
						{
							this.TempVector.Subtraction(this.LastPosition, this.TempVector1);
							float time = (float)(this.TempVector1.Size() / (double)deltaSeconds);
							Singleton<EffectSystem>.Instance.HandleSeekToTime(this.SurfaceHandle, time, false, false);
							FHitResult fhitResult = new FHitResult();
							OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.SurfaceHandle);
							FVectorDouble fvectorDouble = this.TempPosition.ToUeVector(false);
							effectActor.D_K2_SetActorLocation(fvectorDouble, false, ref fhitResult, true);
						}
					}
					else if (this.SurfaceHandle != 0)
					{
						this.StopEffect();
					}
					this.WasHitWater = flag;
					this.LastPosition.DeepCopy(this.TempVector);
					return;
				}
			}
		}

		// Token: 0x0602F896 RID: 194710 RVA: 0x00B5281C File Offset: 0x00B50A1C
		public void StopEffect()
		{
			if (Singleton<EffectSystem>.Instance.IsValid(this.SurfaceHandle))
			{
				Singleton<EffectSystem>.Instance.HandleSeekToTime(this.SurfaceHandle, 0f, false, false);
				Singleton<EffectSystem>.Instance.SetHandleLifeCycle(this.SurfaceHandle, this.TimeAfterSurfaceEffectStop);
			}
			this.SurfaceHandle = 0;
		}

		// Token: 0x0602F897 RID: 194711 RVA: 0x00B52870 File Offset: 0x00B50A70
		[NullableContext(1)]
		protected void SpawnEffect(string effectDataPath)
		{
			if (string.IsNullOrEmpty(effectDataPath))
			{
				return;
			}
			this.StopEffect();
			this.SurfaceHandle = Singleton<EffectSystem>.Instance.SpawnEffect(GlobalData.World, this.Transform, effectDataPath, "[SceneObjectWaterEffect.SpawnEffect]", null, EEffectType.Scene, delegate(int handle)
			{
				Singleton<EffectSystem>.Instance.FreezeHandle(handle, true, false);
				Singleton<EffectSystem>.Instance.SetHandleLifeCycle(this.SurfaceHandle, 10f);
			}, null, null, false, false);
		}

		// Token: 0x0602F898 RID: 194712 RVA: 0x00B528C0 File Offset: 0x00B50AC0
		[NullableContext(1)]
		protected void SpawnFallEffect(string effectDataPath, Vector location)
		{
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FVectorDouble fvectorDouble = location.ToUeVector(false);
			FTransformDouble? ftransformDouble = new FTransformDouble?(new FTransformDouble(ref fvectorDouble));
			this.Handle = instance.SpawnUnloopedEffect(world, ftransformDouble, effectDataPath, "[SceneObjectWaterEffect.SpawnFallEffect]", null, EEffectType.Scene, null, null, null, false, false);
		}

		// Token: 0x0401B2F2 RID: 111346
		[Nullable(1)]
		private const string PROFILE_KEY = "SceneObjectWaterEffect_Update";

		// Token: 0x0401B2F3 RID: 111347
		public SWaterEffectObject Config;

		// Token: 0x0401B2F4 RID: 111348
		public USceneComponent ActorToAttach;

		// Token: 0x0401B2F5 RID: 111349
		public bool IsReady;

		// Token: 0x0401B2F6 RID: 111350
		protected float Radius;

		// Token: 0x0401B2F7 RID: 111351
		protected FTransformDouble? Transform;

		// Token: 0x0401B2F8 RID: 111352
		[Nullable(1)]
		protected string Effect = "";

		// Token: 0x0401B2F9 RID: 111353
		protected bool TriggerOnce;

		// Token: 0x0401B2FA RID: 111354
		protected bool EnableSurfaceEffect;

		// Token: 0x0401B2FB RID: 111355
		[Nullable(1)]
		protected string WaterSurfaceEffect = "";

		// Token: 0x0401B2FC RID: 111356
		protected float TimeAfterSurfaceEffectStop;

		// Token: 0x0401B2FD RID: 111357
		private UTraceSphereElement SphereTrace;

		// Token: 0x0401B2FE RID: 111358
		protected int Handle;

		// Token: 0x0401B2FF RID: 111359
		protected int SurfaceHandle;

		// Token: 0x0401B300 RID: 111360
		protected bool WasHitWater;

		// Token: 0x0401B301 RID: 111361
		protected Vector LastPosition;

		// Token: 0x0401B302 RID: 111362
		protected double WaterHeight;

		// Token: 0x0401B303 RID: 111363
		protected FVector? TempUeVector;

		// Token: 0x0401B304 RID: 111364
		protected Vector TempVector;

		// Token: 0x0401B305 RID: 111365
		protected Vector TempVector1;

		// Token: 0x0401B306 RID: 111366
		protected Vector TempPosition;

		// Token: 0x0401B307 RID: 111367
		public bool IsEnabled;
	}
}
