using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Render;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle
{
	// Token: 0x020047B2 RID: 18354
	[NullableContext(1)]
	[Nullable(0)]
	public class MovementTrailCollisionCapability : WaterDetectedCapability
	{
		// Token: 0x0602FA2B RID: 195115 RVA: 0x00B5EFEC File Offset: 0x00B5D1EC
		[NullableContext(2)]
		public MovementTrailCollisionCapability(AActor invoker = null, AActor owner = null, UKuroTrailCollisionAsset kuroTrailCollisionAsset = null)
		{
			this.Invoker = invoker;
			this.Owner = owner;
			this.KuroTrailCollisionAsset = kuroTrailCollisionAsset;
		}

		// Token: 0x0602FA2C RID: 195116 RVA: 0x00B5F040 File Offset: 0x00B5D240
		public void ResetTrail()
		{
			this.HaveLast = false;
			this.LastPos.Reset();
			this.CurPos.Reset();
			if (this.Segments != null)
			{
				foreach (MovementTrailCollisionCapability.TrailSegment segment in this.Segments)
				{
					this.Recycle(segment);
				}
			}
			HashSet<MovementTrailCollisionCapability.TrailSegment> segments = this.Segments;
			if (segments != null)
			{
				segments.Clear();
			}
			PriorityQueue<MovementTrailCollisionCapability.TrailSegment> segmentsSpawnTimeQueue = this.SegmentsSpawnTimeQueue;
			if (segmentsSpawnTimeQueue == null)
			{
				return;
			}
			segmentsSpawnTimeQueue.Clear();
		}

		// Token: 0x0602FA2D RID: 195117 RVA: 0x00B5F0DC File Offset: 0x00B5D2DC
		public override void Activate()
		{
			UKuroTrailCollisionAsset kuroTrailCollisionAsset = this.KuroTrailCollisionAsset;
			if (kuroTrailCollisionAsset == null || !kuroTrailCollisionAsset.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision 没有配置KuroTrailCollisionAsset", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.BoxPool = new Pool<MovementTrailCollisionCapability.BoxComponentProxy>(this.KuroTrailCollisionAsset.MaxSegments, delegate()
			{
				AActor owner = this.Owner;
				if (owner != null && owner.IsValid())
				{
					UKuroTrailCollisionAsset kuroTrailCollisionAsset2 = this.KuroTrailCollisionAsset;
					if (kuroTrailCollisionAsset2 != null && kuroTrailCollisionAsset2.IsValid())
					{
						UBoxComponent uboxComponent = this.Owner.D_AddComponentByClass(UBoxComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransformDouble, false, default(FName)) as UBoxComponent;
						if (uboxComponent == null || !uboxComponent.IsValid())
						{
							return MovementTrailCollisionCapability.EmptyBoxProxy;
						}
						uboxComponent.SetHiddenInGame(true, false);
						this.ApplyCollisionSetup(uboxComponent);
						uboxComponent.K2_DetachFromComponent(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, false);
						return new MovementTrailCollisionCapability.BoxComponentProxy(uboxComponent);
					}
				}
				return MovementTrailCollisionCapability.EmptyBoxProxy;
			}, delegate(MovementTrailCollisionCapability.BoxComponentProxy boxProxy)
			{
				UBoxComponent boxComponent = boxProxy.BoxComponent;
				if (boxComponent == null || !boxComponent.IsValid())
				{
					return;
				}
				boxProxy.BoxComponent.SetCollisionEnabled(ECollisionEnabled.NoCollision);
			});
			this.Segments = new HashSet<MovementTrailCollisionCapability.TrailSegment>();
			this.SegmentsSpawnTimeQueue = new PriorityQueue<MovementTrailCollisionCapability.TrailSegment>((MovementTrailCollisionCapability.TrailSegment a, MovementTrailCollisionCapability.TrailSegment b) => (int)(a.SpawnTime - b.SpawnTime));
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.TickActive), this.KuroTrailCollisionAsset.StepInterval, 1f, null, null, true);
		}

		// Token: 0x0602FA2E RID: 195118 RVA: 0x00B5F1C3 File Offset: 0x00B5D3C3
		public override void Deactivate()
		{
			this.ResetTrail();
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			}
		}

		// Token: 0x0602FA2F RID: 195119 RVA: 0x00B5F1E4 File Offset: 0x00B5D3E4
		public override bool? ShouldTickActive()
		{
			return new bool?(this.Segments != null && this.Segments.Count > 0);
		}

		// Token: 0x0602FA30 RID: 195120 RVA: 0x00B5F204 File Offset: 0x00B5D404
		public override void TickActive(float deltaTime)
		{
			this.TrimByTTL((float)Singleton<Time>.Instance.WorldTime);
		}

		// Token: 0x0602FA31 RID: 195121 RVA: 0x00B5F218 File Offset: 0x00B5D418
		private void SpawnOrExtendSegment(Vector start, Vector end, Vector normal)
		{
			UKuroTrailCollisionAsset kuroTrailCollisionAsset = this.KuroTrailCollisionAsset;
			if (kuroTrailCollisionAsset == null || !kuroTrailCollisionAsset.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision SpawnOrExtendSegment KuroTrailCollisionAsset 无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.Segments == null || this.BoxPool == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision SpawnOrExtendSegment Segments 或BoxPool 无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (Singleton<Time>.Instance.WorldTime - this.LastTime < (double)this.KuroTrailCollisionAsset.StepInterval)
			{
				return;
			}
			this.LastTime = Singleton<Time>.Instance.WorldTime;
			if (!end.Subtraction(start, Vector.Create()).Normalize(9.99999993922529E-09))
			{
				return;
			}
			if (this.Segments.Count >= this.KuroTrailCollisionAsset.MaxSegments)
			{
				PriorityQueue<MovementTrailCollisionCapability.TrailSegment> segmentsSpawnTimeQueue = this.SegmentsSpawnTimeQueue;
				MovementTrailCollisionCapability.TrailSegment trailSegment = (segmentsSpawnTimeQueue != null) ? segmentsSpawnTimeQueue.Top : null;
				if (trailSegment != null)
				{
					this.Recycle(trailSegment);
				}
			}
			MovementTrailCollisionCapability.BoxComponentProxy boxComponentProxy = this.BoxPool.Get() ?? this.BoxPool.Create();
			bool flag;
			if (boxComponentProxy == null)
			{
				flag = true;
			}
			else
			{
				UBoxComponent boxComponent = boxComponentProxy.BoxComponent;
				flag = !((boxComponent != null) ? new bool?(boxComponent.IsValid()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				return;
			}
			this.UpdateBoxSegment(boxComponentProxy.BoxComponent, start, end, normal);
			this.SpawnSegment(boxComponentProxy, start, end);
			UKismetMaterialLibrary.SetVectorParameterValue(this.Invoker, Singleton<RenderDataManager>.Instance.GetGlobalShaderParameters(), MovementTrailCollisionCapability.iceRiderPositionName, ColorUtils.LinearBlack);
			this.LastPos.DeepCopy(this.CurPos);
		}

		// Token: 0x0602FA32 RID: 195122 RVA: 0x00B5F3A0 File Offset: 0x00B5D5A0
		private void UpdateBoxSegment(UBoxComponent box, Vector start, Vector end, Vector normal)
		{
			if (box == null || !box.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision UpdateBoxSegment Box无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			end.Subtraction(start, Singleton<MathUtils>.Instance.CommonTempVector);
			double length = Singleton<MathUtils>.Instance.CommonTempVector.Size();
			if (!Singleton<MathUtils>.Instance.CommonTempVector.Normalize(9.99999993922529E-09))
			{
				Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision UpdateBoxSegment dir 无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (!normal.Normalize(9.99999993922529E-09))
			{
				Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision UpdateBoxSegment normal 无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			start.Addition(end, Singleton<MathUtils>.Instance.CommonTempVector2);
			Singleton<MathUtils>.Instance.CommonTempVector2.MultiplyEqual(0.5);
			Vector vector = Vector.Create();
			Singleton<MathUtils>.Instance.CommonTempVector.Subtraction(normal.Multiply(Singleton<MathUtils>.Instance.CommonTempVector.DotProduct(normal), Vector.Create()), vector);
			if (!vector.Normalize(9.99999993922529E-09))
			{
				Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision UpdateBoxSegment 水面法线和移动方向平行", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Vector.CrossProduct(normal, vector, Singleton<MathUtils>.Instance.CommonTempVector);
			FRotator rot = UKismetMathLibrary.MakeRotationFromAxes(vector.ToUeVectorOld(), Singleton<MathUtils>.Instance.CommonTempVector.ToUeVectorOld(), normal.ToUeVectorOld());
			this.UpdateBoxShapeAndCollision(box, Singleton<MathUtils>.Instance.CommonTempVector2.ToUeVector(false), rot, length);
		}

		// Token: 0x0602FA33 RID: 195123 RVA: 0x00B5F540 File Offset: 0x00B5D740
		private void UpdateBoxShapeAndCollision(UBoxComponent box, FVectorDouble loc, FRotator rot, double length)
		{
			if (box != null && box.IsValid())
			{
				UKuroTrailCollisionAsset kuroTrailCollisionAsset = this.KuroTrailCollisionAsset;
				if (kuroTrailCollisionAsset != null && kuroTrailCollisionAsset.IsValid())
				{
					box.K2_DetachFromComponent(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, true);
					FHitResult fhitResult = new FHitResult();
					box.D_K2_SetWorldLocation(loc, false, ref fhitResult, false);
					box.K2_SetWorldRotation(rot, false, ref fhitResult, false);
					box.SetBoxExtent(new FVector((float)(0.5 * length + (double)this.KuroTrailCollisionAsset.PaddingAlong), this.KuroTrailCollisionAsset.HalfWidth, this.KuroTrailCollisionAsset.HalfHeight), true);
					box.SetCollisionEnabled(ECollisionEnabled.QueryOnly);
					return;
				}
			}
			Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision UpdateBoxShapeAndCollision Box或者KuroTrailCollisionAsset无效", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602FA34 RID: 195124 RVA: 0x00B5F5FC File Offset: 0x00B5D7FC
		private bool Recycle(MovementTrailCollisionCapability.TrailSegment segment)
		{
			if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("MovementTrailCollision") > 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "MovementTrailCollision Recycle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("segment", segment);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			MovementTrailCollisionCapability.BoxComponentProxy box = segment.Box;
			bool flag;
			if (box == null)
			{
				flag = false;
			}
			else
			{
				UBoxComponent boxComponent = box.BoxComponent;
				flag = ((boxComponent != null) ? new bool?(boxComponent.IsValid()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				segment.Box.BoxComponent.SetCollisionEnabled(ECollisionEnabled.NoCollision);
				Pool<MovementTrailCollisionCapability.BoxComponentProxy> boxPool = this.BoxPool;
				if (boxPool != null)
				{
					boxPool.Put(segment.Box);
				}
			}
			segment.Box = null;
			if (this.Segments == null || this.SegmentsSpawnTimeQueue == null)
			{
				return false;
			}
			bool result = this.Segments.Remove(segment) && this.SegmentsSpawnTimeQueue.Remove(segment);
			if (this.Segments.Count == 0)
			{
				UKismetMaterialLibrary.SetVectorParameterValue(this.Invoker, Singleton<RenderDataManager>.Instance.GetGlobalShaderParameters(), MovementTrailCollisionCapability.iceRiderPositionName, ColorUtils.LinearClear);
			}
			return result;
		}

		// Token: 0x0602FA35 RID: 195125 RVA: 0x00B5F704 File Offset: 0x00B5D904
		private unsafe void SpawnSegment(MovementTrailCollisionCapability.BoxComponentProxy box, Vector start, Vector end)
		{
			bool flag;
			if (box == null)
			{
				flag = true;
			}
			else
			{
				UBoxComponent boxComponent = box.BoxComponent;
				flag = !((boxComponent != null) ? new bool?(boxComponent.IsValid()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision SpawnSegment BoxComponent无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			MovementTrailCollisionCapability.TrailSegment trailSegment = new MovementTrailCollisionCapability.TrailSegment();
			trailSegment.SpawnTime = Singleton<Time>.Instance.WorldTime;
			trailSegment.Start = Vector.Create(start);
			trailSegment.End = Vector.Create(end);
			trailSegment.Box = box;
			HashSet<MovementTrailCollisionCapability.TrailSegment> segments = this.Segments;
			if (segments != null)
			{
				segments.Add(trailSegment);
			}
			PriorityQueue<MovementTrailCollisionCapability.TrailSegment> segmentsSpawnTimeQueue = this.SegmentsSpawnTimeQueue;
			if (segmentsSpawnTimeQueue != null)
			{
				segmentsSpawnTimeQueue.Push(trailSegment);
			}
			if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("MovementTrailCollision") > 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "MovementTrailCollision SpawnSegment";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("segment", trailSegment);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("segments", this.Segments);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x0602FA36 RID: 195126 RVA: 0x00B5F824 File Offset: 0x00B5DA24
		private void ApplyCollisionSetup(UBoxComponent box)
		{
			if (box != null && box.IsValid())
			{
				UKuroTrailCollisionAsset kuroTrailCollisionAsset = this.KuroTrailCollisionAsset;
				if (kuroTrailCollisionAsset != null && kuroTrailCollisionAsset.IsValid())
				{
					box.SetMobility(this.KuroTrailCollisionAsset.Mobility);
					box.SetCollisionProfileName(this.KuroTrailCollisionAsset.CollisionProfileName.Name, true);
					box.SetGenerateOverlapEvents(this.KuroTrailCollisionAsset.bGenerateOverlapEvents);
					box.bKuroOverlapNotify = this.KuroTrailCollisionAsset.bKuroOverlapNotify;
					box.bKuroPassiveCollisionUpdateOverlapsWhenEnterOverlap = this.KuroTrailCollisionAsset.bKuroPassiveCollisionUpdateOverlapsWhenEnterOverlap;
					box.bKuroPassiveCollision = this.KuroTrailCollisionAsset.bKuroPassiveCollision;
					if (this.KuroTrailCollisionAsset.bIgnoreOwner)
					{
						AActor owner = this.Owner;
						if (owner != null && owner.IsValid())
						{
							box.IgnoreActorWhenMoving(this.Owner, true);
						}
					}
					if (this.IgnoreInvoker)
					{
						AActor invoker = this.Invoker;
						if (invoker != null && invoker.IsValid())
						{
							box.IgnoreActorWhenMoving(this.Invoker, true);
						}
					}
					return;
				}
			}
			Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision ApplyCollisionSetup Box或者KuroTrailCollisionAsset无效", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602FA37 RID: 195127 RVA: 0x00B5F940 File Offset: 0x00B5DB40
		private void TrimByTTL(float nowMilliseconds)
		{
			UKuroTrailCollisionAsset kuroTrailCollisionAsset = this.KuroTrailCollisionAsset;
			if (kuroTrailCollisionAsset == null || !kuroTrailCollisionAsset.IsValid() || this.KuroTrailCollisionAsset.TTLSeconds < 0.0001f)
			{
				return;
			}
			if (this.Segments == null || this.Segments.Count <= 0)
			{
				return;
			}
			AActor invoker = this.Invoker;
			if (invoker != null && invoker.IsValid())
			{
				AActor owner = this.Owner;
				if (owner != null && owner.IsValid())
				{
					EntityHandle entityByActor = ActorUtils.GetEntityByActor(this.Invoker, true);
					if (entityByActor != null && entityByActor.Valid)
					{
						WorldEntity entity = entityByActor.Entity;
						if (entity != null && entity.Valid)
						{
							BaseActorComponent baseActorComponent = entityByActor.Entity.CheckGetComponent<BaseActorComponent>();
							if (baseActorComponent == null)
							{
								return;
							}
							Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
							FVectorDouble fvectorDouble = this.Owner.D_K2_GetActorLocation();
							commonTempVector.FromUeVector(fvectorDouble);
							Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(baseActorComponent, Singleton<MathUtils>.Instance.CommonTempVector);
							double num = 2890000.0;
							double num2 = (double)(this.KuroTrailCollisionAsset.StepDistance * this.KuroTrailCollisionAsset.StepDistance);
							List<MovementTrailCollisionCapability.TrailSegment> list = new List<MovementTrailCollisionCapability.TrailSegment>();
							foreach (MovementTrailCollisionCapability.TrailSegment trailSegment in this.Segments)
							{
								MovementTrailCollisionCapability.BoxComponentProxy box = trailSegment.Box;
								bool flag;
								if (box == null)
								{
									flag = true;
								}
								else
								{
									UBoxComponent boxComponent = box.BoxComponent;
									flag = !((boxComponent != null) ? new bool?(boxComponent.IsValid()) : null).GetValueOrDefault();
								}
								if (flag)
								{
									list.Add(trailSegment);
								}
								else
								{
									if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("MovementTrailCollision") > 0)
									{
										Log instance = Singleton<Log>.Instance;
										ELogModule module = ELogModule.Movement;
										ELogAuthor author = ELogAuthor.XDW;
										string message = "MovementTrailCollision TrimByTTL";
										ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("segment", trailSegment);
										instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
										UKismetSystemLibrary.DrawDebugBox(this.Owner, trailSegment.Box.BoxComponent.K2_GetComponentLocation(), trailSegment.Box.BoxComponent.BoxExtent, ColorUtils.LinearGreen, trailSegment.Box.BoxComponent.K2_GetComponentRotation(), 0f, 0f);
									}
									Singleton<MathUtils>.Instance.CommonTempVector2.DeepCopy(trailSegment.End);
									Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(baseActorComponent, Singleton<MathUtils>.Instance.CommonTempVector2);
									double num3 = Vector.DistSquared(Singleton<MathUtils>.Instance.CommonTempVector, Singleton<MathUtils>.Instance.CommonTempVector2);
									if (num3 > num)
									{
										list.Add(trailSegment);
									}
									else if (this.DetectingWater && !this.Invoker.bHidden && num3 < num2)
									{
										trailSegment.SpawnTime = (double)nowMilliseconds;
									}
									else if ((double)nowMilliseconds - trailSegment.SpawnTime > (double)(this.KuroTrailCollisionAsset.TTLSeconds * 1000f))
									{
										list.Add(trailSegment);
									}
								}
							}
							foreach (MovementTrailCollisionCapability.TrailSegment segment in list)
							{
								this.Recycle(segment);
							}
							return;
						}
					}
					return;
				}
			}
		}

		// Token: 0x0602FA38 RID: 195128 RVA: 0x00B5FC78 File Offset: 0x00B5DE78
		public override void OnWaterDetectedStart()
		{
			this.HaveLast = false;
			this.DetectingWater = true;
			Singleton<Log>.Instance.Info(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision OnWaterDetectedStart", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602FA39 RID: 195129 RVA: 0x00B5FCB0 File Offset: 0x00B5DEB0
		public override void OnWaterDetectedEnd()
		{
			if (!this.DetectingWater)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Movement, ELogAuthor.XDW, "检查BroadcastWaterDetectedTick逻辑，未调用Start就开始End", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.DetectingWater = false;
			Singleton<Log>.Instance.Info(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision OnWaterDetectedEnd", default(ReadOnlySpan<ValueTuple<string, object>>));
			UObject invoker = this.Invoker;
			UMaterialParameterCollection globalShaderParameters = Singleton<RenderDataManager>.Instance.GetGlobalShaderParameters();
			FName parameterName = MovementTrailCollisionCapability.iceRiderPositionName;
			FLinearColor flinearColor = (this.Segments == null || this.Segments.Count == 0) ? ColorUtils.LinearClear : ColorUtils.LinearBlack;
			UKismetMaterialLibrary.SetVectorParameterValue(invoker, globalShaderParameters, parameterName, flinearColor);
		}

		// Token: 0x0602FA3A RID: 195130 RVA: 0x00B5FD44 File Offset: 0x00B5DF44
		public unsafe void OnWaterDetectedTick(double deltaTime, Vector location, Vector normal)
		{
			if (!this.DetectingWater)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision 检查BroadcastWaterDetectedTick逻辑，未调用Start就开始Tick", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			UKuroTrailCollisionAsset kuroTrailCollisionAsset = this.KuroTrailCollisionAsset;
			if (kuroTrailCollisionAsset == null || !kuroTrailCollisionAsset.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision HandleWaterDetectedTick KuroTrailCollisionAsset无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			AActor invoker = this.Invoker;
			if (invoker == null || !invoker.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.XDW, "MovementTrailCollision HandleWaterDetectedTick Invoker无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("MovementTrailCollision") > 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "OnWaterDetectedTick";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("location", location);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("normal", normal);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			this.CurPos.DeepCopy(location);
			if (!this.HaveLast)
			{
				this.HaveLast = true;
				this.LastPos.DeepCopy(location);
				Vector inB = Vector.Create(this.Invoker.GetActorForwardVector());
				this.SpawnOrExtendSegment(this.CurPos.Subtraction(inB, Vector.Create()), this.CurPos.Addition(inB, Vector.Create()), normal);
				return;
			}
			double num = Vector.DistSquared(this.CurPos, this.LastPos);
			if (this.KuroTrailCollisionAsset.TeleportDistance > 0.0001f && num > (double)(this.KuroTrailCollisionAsset.TeleportDistance * this.KuroTrailCollisionAsset.TeleportDistance))
			{
				this.ResetTrail();
				return;
			}
			if (this.KuroTrailCollisionAsset.StepDistance > 0.0001f && num < (double)(this.KuroTrailCollisionAsset.StepDistance * this.KuroTrailCollisionAsset.StepDistance))
			{
				return;
			}
			this.SpawnOrExtendSegment(this.LastPos, this.CurPos, normal);
		}

		// Token: 0x0602FA3B RID: 195131 RVA: 0x00B5FF31 File Offset: 0x00B5E131
		public override void OnWaterDetectedTick(float deltaTime, Vector impactPoint, Vector impactNormal)
		{
			this.OnWaterDetectedTick((double)deltaTime, impactPoint, impactNormal);
		}

		// Token: 0x0401B415 RID: 111637
		private const int MAX_DISTANCE = 1700;

		// Token: 0x0401B416 RID: 111638
		private const string DEBUG_KEY = "MovementTrailCollision";

		// Token: 0x0401B417 RID: 111639
		[StaticVariableRuleIgnore]
		public static FName iceRiderPositionName = FNameUtil.GetDynamicFName("IceRiderPosition").Value;

		// Token: 0x0401B418 RID: 111640
		[Nullable(2)]
		public AActor Invoker;

		// Token: 0x0401B419 RID: 111641
		[Nullable(2)]
		public AActor Owner;

		// Token: 0x0401B41A RID: 111642
		[Nullable(2)]
		public UKuroTrailCollisionAsset KuroTrailCollisionAsset;

		// Token: 0x0401B41B RID: 111643
		public bool IgnoreInvoker = true;

		// Token: 0x0401B41C RID: 111644
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private HashSet<MovementTrailCollisionCapability.TrailSegment> Segments;

		// Token: 0x0401B41D RID: 111645
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private PriorityQueue<MovementTrailCollisionCapability.TrailSegment> SegmentsSpawnTimeQueue;

		// Token: 0x0401B41E RID: 111646
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Pool<MovementTrailCollisionCapability.BoxComponentProxy> BoxPool;

		// Token: 0x0401B41F RID: 111647
		private bool HaveLast;

		// Token: 0x0401B420 RID: 111648
		private bool DetectingWater;

		// Token: 0x0401B421 RID: 111649
		[Nullable(2)]
		private TimerHandle TimerHandle;

		// Token: 0x0401B422 RID: 111650
		private readonly Vector CurPos = Vector.Create();

		// Token: 0x0401B423 RID: 111651
		private readonly Vector LastPos = Vector.Create();

		// Token: 0x0401B424 RID: 111652
		[StaticVariableRuleIgnore]
		private static readonly MovementTrailCollisionCapability.BoxComponentProxy EmptyBoxProxy = new MovementTrailCollisionCapability.BoxComponentProxy(null);

		// Token: 0x0401B425 RID: 111653
		private double LastTime = -1.0;

		// Token: 0x0200A8A3 RID: 43171
		[NullableContext(2)]
		[Nullable(0)]
		protected class BoxComponentProxy
		{
			// Token: 0x0604AFAF RID: 307119 RVA: 0x01468F0E File Offset: 0x0146710E
			public BoxComponentProxy(UBoxComponent boxComponent = null)
			{
				this.BoxComponent = boxComponent;
			}

			// Token: 0x0403451C RID: 214300
			public UBoxComponent BoxComponent;
		}

		// Token: 0x0200A8A4 RID: 43172
		[Nullable(0)]
		protected class TrailSegment
		{
			// Token: 0x0403451D RID: 214301
			[Nullable(2)]
			public MovementTrailCollisionCapability.BoxComponentProxy Box;

			// Token: 0x0403451E RID: 214302
			public double SpawnTime;

			// Token: 0x0403451F RID: 214303
			public Vector Start = Vector.ZeroVectorProxy;

			// Token: 0x04034520 RID: 214304
			public Vector End = Vector.ZeroVectorProxy;
		}
	}
}
