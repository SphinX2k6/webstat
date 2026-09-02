using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.Gameplay.RollBlock;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.Render;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.RollBlock.ItemLogic
{
	// Token: 0x02006B29 RID: 27433
	[NullableContext(1)]
	[Nullable(0)]
	public class RbLightBeamItemLogic : RbItemLogicBase
	{
		// Token: 0x06043C7C RID: 277628 RVA: 0x0118236C File Offset: 0x0118056C
		public RbLightBeamItemLogic(RbItemComponent owner) : base(owner)
		{
		}

		// Token: 0x06043C7D RID: 277629 RVA: 0x011823F8 File Offset: 0x011805F8
		public override void Start([Nullable(new byte[]
		{
			0,
			1,
			1
		})] OneOf<RbBreakableObstaclePbType, RbLaserEmitterPbType> info)
		{
			this.OriginLocation = new FVectorDouble?(this.Owner.ActorTransform.GetLocation());
			this.RangeComp = this.Owner.Entity.GetComponent<RangeComponent>();
			RbLaserEmitterPbType asT = info.AsT2;
			this.UpdatePoints(asT.LaserPoints);
			if (this.RelativePoints.Num() > 1)
			{
				this.UpdateRange();
				this.UpdateEffectByTrace();
			}
			this.StartOverlap();
			Singleton<EventSystem>.Instance.AddWithTarget(this.Owner.Entity, EEventName.OnSceneItemLockPropChange, new Action<bool>(this.OnSceneItemLockPropChange));
		}

		// Token: 0x06043C7E RID: 277630 RVA: 0x01182498 File Offset: 0x01180698
		public override void End()
		{
			this.StopAllEffect();
			this.RelativePoints.Empty(true);
			this.AbsolutePoints.Empty(true);
			this.TraceElement = null;
			this.StopOverlap();
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.Owner.Entity, EEventName.OnSceneItemLockPropChange, new Action<bool>(this.OnSceneItemLockPropChange));
		}

		// Token: 0x06043C7F RID: 277631 RVA: 0x011824F7 File Offset: 0x011806F7
		public override void OnStateChange(int stateId)
		{
			if (stateId == GameplayTagDefine.EGameplayTagId["关卡.Common.状态.销毁"])
			{
				this.StopAllEffect();
				this.StopOverlap();
				this.RelativePoints.Empty(true);
				this.AbsolutePoints.Empty(true);
				this.TraceElement = null;
			}
		}

		// Token: 0x06043C80 RID: 277632 RVA: 0x01182538 File Offset: 0x01180738
		public override void OnRbItemUpdate([Nullable(new byte[]
		{
			0,
			1,
			1
		})] OneOf<RbBreakableObstaclePbType, RbLaserEmitterPbType> info)
		{
			RbLaserEmitterPbType asT = info.AsT2;
			bool flag = this.UpdatePoints(asT.LaserPoints);
			this.IgnoreOverlap = true;
			if (this.RelativePoints.Num() > 1)
			{
				if (flag)
				{
					this.UpdateRange();
				}
				this.UpdateEffectByTrace();
				this.UpdateStartEffect();
			}
			this.IgnoreOverlap = false;
		}

		// Token: 0x06043C81 RID: 277633 RVA: 0x0118258C File Offset: 0x0118078C
		private bool UpdatePoints(IList<Aki.Protocol.Vector> points)
		{
			if (points.Count > 0)
			{
				global::Vector vector = global::Vector.Create(points[0]);
				global::Vector vector2 = global::Vector.Create(points[points.Count - 1]);
				if (this.AbsolutePoints.Num() > 0)
				{
					global::Vector inB = global::Vector.Create(this.AbsoluteOriginPoint.Get(0));
					global::Vector inB2 = global::Vector.Create(this.AbsoluteOriginPoint.Get(this.AbsoluteOriginPoint.Num() - 1));
					if (vector.Equals(inB, 9.999999747378752E-05) && vector2.Equals(inB2, 9.999999747378752E-05))
					{
						return false;
					}
				}
				this.RelativePoints.Empty(true);
				this.AbsolutePoints.Empty(true);
				this.AbsoluteOriginPoint.Empty(true);
				this.RelativePoints.Add(new FVectorDouble(vector.X - this.OriginLocation.Value.X, vector.Y - this.OriginLocation.Value.Y, vector.Z - this.OriginLocation.Value.Z));
				FVectorDouble value = new FVectorDouble(vector.X, vector.Y, vector.Z);
				this.AbsolutePoints.Add(value);
				this.AbsoluteOriginPoint.Add(value);
				if (!vector.Equals(vector2, 9.999999747378752E-05))
				{
					this.RelativePoints.Add(new FVectorDouble(vector2.X - this.OriginLocation.Value.X, vector2.Y - this.OriginLocation.Value.Y, vector2.Z - this.OriginLocation.Value.Z));
					FVectorDouble value2 = new FVectorDouble(vector2.X, vector2.Y, vector2.Z);
					this.AbsolutePoints.Add(value2);
					this.AbsoluteOriginPoint.Add(value2);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06043C82 RID: 277634 RVA: 0x01182780 File Offset: 0x01180980
		private void UpdateEffectByTrace()
		{
			this.ExecuteTrace();
			FVectorDouble fvectorDouble = this.AbsolutePoints.Get(this.AbsolutePoints.Num() - 1);
			if (this.ImpactPoint.Equals(fvectorDouble, 9.999999747378752E-05) && this.EffectHandle != null)
			{
				return;
			}
			this.AbsolutePoints.Set(this.AbsolutePoints.Num() - 1, this.ImpactPoint);
			TArray<FVectorDouble> relativePoints = this.RelativePoints;
			int index = this.RelativePoints.Num() - 1;
			fvectorDouble = this.OriginLocation.Value;
			FVectorDouble fvectorDouble2 = this.ImpactPoint - fvectorDouble;
			relativePoints.Set(index, fvectorDouble2);
			this.UpdateLightBeam();
		}

		// Token: 0x06043C83 RID: 277635 RVA: 0x0118282C File Offset: 0x01180A2C
		private void UpdateRange()
		{
			FVectorDouble fvectorDouble = this.AbsolutePoints.Get(0);
			FVectorDouble fvectorDouble2 = this.AbsolutePoints.Get(this.AbsolutePoints.Num() - 1);
			global::Vector centerOfPoints = Singleton<MathUtils>.Instance.GetCenterOfPoints(new global::Vector[]
			{
				global::Vector.Create(fvectorDouble),
				global::Vector.Create(fvectorDouble2)
			});
			FTransformDouble actorTransform = this.Owner.ActorComp.ActorTransform;
			FVectorDouble fvectorDouble3 = centerOfPoints.ToUeVector(false);
			FVectorDouble location = actorTransform.InverseTransformPosition(fvectorDouble3);
			fvectorDouble3 = fvectorDouble - fvectorDouble2;
			double num = fvectorDouble3.Size();
			this.BoxExtent.X = num * 0.5;
			this.RangeComp.UpdateBoxRange(location, this.BoxExtent.ToUeVector(false));
		}

		// Token: 0x06043C84 RID: 277636 RVA: 0x011828F4 File Offset: 0x01180AF4
		private void ExecuteTrace()
		{
			this.InitTraceElement(this.AbsoluteOriginPoint.Get(0), this.AbsoluteOriginPoint.Get(this.AbsoluteOriginPoint.Num() - 1));
			Singleton<TraceElementCommon>.Instance.BoxTrace(this.TraceElement, "[RbLightBeamItemLogic.UpdateLightBeam]");
			UKuroHitResult hitResult = this.TraceElement.HitResult;
			if (hitResult != null && hitResult.bBlockingHit && hitResult.Actors.Get(0).IsValid(false, false))
			{
				this.ImpactPoint.X = (double)hitResult.ImpactPointX_Array.Get(0);
				this.ImpactPoint.Y = (double)hitResult.ImpactPointY_Array.Get(0);
				this.ImpactPoint.Z = (double)hitResult.ImpactPointZ_Array.Get(0);
				return;
			}
			int index = this.AbsoluteOriginPoint.Num() - 1;
			this.ImpactPoint.X = this.AbsoluteOriginPoint.Get(index).X;
			this.ImpactPoint.Y = this.AbsoluteOriginPoint.Get(index).Y;
			this.ImpactPoint.Z = this.AbsoluteOriginPoint.Get(index).Z;
		}

		// Token: 0x06043C85 RID: 277637 RVA: 0x01182A1C File Offset: 0x01180C1C
		private void UpdateStartEffect()
		{
			if (this.StartEffectHandle != null)
			{
				return;
			}
			if (this.RelativePoints.Num() == 0)
			{
				return;
			}
			BP_RollBlockGameplaySetting_C gameplaySetting = ControllerBase<RollBlockController>.Instance.GameplaySetting;
			string text = (gameplaySetting != null) ? gameplaySetting.LightBeamStartEffect.ToAssetPathName() : null;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			FTransformDouble value = new FTransformDouble();
			FVectorDouble fvectorDouble = this.AbsolutePoints.Get(0);
			FVectorDouble fvectorDouble2 = this.AbsolutePoints.Get(this.AbsolutePoints.Num() - 1);
			global::Vector vector = global::Vector.Create(fvectorDouble2 - fvectorDouble);
			vector.Normalize(9.99999993922529E-09);
			float inYaw = (float)Singleton<MathUtils>.Instance.GetAngleByVectorDot(global::Vector.LeftVectorProxy, vector);
			FRotator frotator = new FRotator(0f, inYaw, 0f);
			FVectorDouble fvectorDouble3 = vector.ToUeVector(false);
			FVectorDouble fvectorDouble4 = fvectorDouble3 * 50.0;
			FVectorDouble fvectorDouble5 = fvectorDouble + fvectorDouble4;
			value.SetTranslation(fvectorDouble5);
			FQuat fquat = frotator.Quaternion();
			value.SetRotation(fquat);
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(value);
			int num = instance.SpawnEffect(world, ftransformDouble, text, "[RbLightBeamItemLogic] HitEffect]", new EffectContext(new int?(this.Owner.Entity.Id), null, false), EEffectType.Scene, null, null, null, false, false);
			OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(num);
			AActor owner = this.Owner.ActorComp.Owner;
			FName? fname = null;
			effectActor.K2_AttachToActor(owner, fname, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false);
			this.StartEffectHandle = new int?(num);
		}

		// Token: 0x06043C86 RID: 277638 RVA: 0x01182BA4 File Offset: 0x01180DA4
		private unsafe void UpdateLightBeam()
		{
			this.StopBeamEffect();
			TArray<FVectorDouble> relativePoints = this.RelativePoints;
			if (relativePoints != null && relativePoints.Num() == 0)
			{
				return;
			}
			BP_RollBlockGameplaySetting_C gameplaySetting = ControllerBase<RollBlockController>.Instance.GameplaySetting;
			string text = (gameplaySetting != null) ? gameplaySetting.LightBeamEffect.ToAssetPathName() : null;
			global::Vector location = this.Location;
			FVectorDouble fvectorDouble = this.OriginLocation.Value;
			location.FromUeVector(fvectorDouble);
			if (!string.IsNullOrEmpty(text))
			{
				IGuideEffectSpline guideEffectSpline = GameSplineUtils.GenerateGuideEffect(this.Location, this.RelativePoints, text);
				if (guideEffectSpline == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RollBlock;
					ELogAuthor author = ELogAuthor.FJH;
					string message = "[RbLightBeamItemLogic] GenerateGuideEffect failed";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", this.Owner.CreatureDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EffectPath", text);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				this.EffectHandle = new int?(guideEffectSpline.EffectHandle);
				USplineComponent splineComp = guideEffectSpline.SplineComp;
				if (splineComp != null)
				{
					int numberOfSplinePoints = splineComp.GetNumberOfSplinePoints();
					for (int i = 0; i < numberOfSplinePoints; i++)
					{
						splineComp.SetSplinePointType(i, ESplinePointType.Linear, false);
					}
					splineComp.UpdateSpline();
				}
			}
			FVectorDouble fvectorDouble2 = this.AbsoluteOriginPoint.Get(this.AbsoluteOriginPoint.Num() - 1);
			FVectorDouble fvectorDouble3 = this.AbsolutePoints.Get(this.AbsolutePoints.Num() - 1);
			FTransformDouble value = new FTransformDouble();
			string text2;
			if (fvectorDouble2.Equals(fvectorDouble3, 9.999999747378752E-05))
			{
				BP_RollBlockGameplaySetting_C gameplaySetting2 = ControllerBase<RollBlockController>.Instance.GameplaySetting;
				text2 = ((gameplaySetting2 != null) ? gameplaySetting2.LightBeamHitWallEffect.ToAssetPathName() : null);
				FVectorDouble fvectorDouble4 = this.AbsolutePoints.Get(0);
				global::Vector vector = global::Vector.Create(fvectorDouble4 - fvectorDouble3);
				vector.Normalize(9.99999993922529E-09);
				float inYaw = (float)Singleton<MathUtils>.Instance.GetAngleByVectorDot(global::Vector.RightVectorProxy, vector);
				FRotator frotator = new FRotator(0f, inYaw, 0f);
				FQuat fquat = frotator.Quaternion();
				value.SetRotation(fquat);
			}
			else
			{
				BP_RollBlockGameplaySetting_C gameplaySetting3 = ControllerBase<RollBlockController>.Instance.GameplaySetting;
				text2 = ((gameplaySetting3 != null) ? gameplaySetting3.LightBeamHitEffect.ToAssetPathName() : null);
			}
			if (!string.IsNullOrEmpty(text2))
			{
				fvectorDouble = this.AbsolutePoints.Get(this.AbsolutePoints.Num() - 1);
				value.SetTranslation(fvectorDouble);
				EffectSystem instance2 = Singleton<EffectSystem>.Instance;
				UObject world = GlobalData.World;
				FTransformDouble? ftransformDouble = new FTransformDouble?(value);
				int num = instance2.SpawnEffect(world, ftransformDouble, text2, "[RbLightBeamItemLogic] HitEffect]", new EffectContext(new int?(this.Owner.Entity.Id), null, false), EEffectType.Scene, null, null, null, false, false);
				OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(num);
				AActor owner = this.Owner.ActorComp.Owner;
				FName? fname = null;
				effectActor.K2_AttachToActor(owner, fname, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false);
				this.HitEffectHandle = new int?(num);
			}
		}

		// Token: 0x06043C87 RID: 277639 RVA: 0x01182E80 File Offset: 0x01181080
		private void InitTraceElement(FVectorDouble traceStartPoint, FVectorDouble traceEndPoint)
		{
			if (this.TraceElement == null)
			{
				this.TraceElement = new UTraceBoxElement();
				this.TraceElement.bIgnoreSelf = true;
				this.TraceElement.bIsSingle = true;
				this.TraceElement.ActorsToIgnore.Empty(true);
				TArray<AActor> sceneInteractionAllActorsInLevel = SceneInteractionManager.Get().GetSceneInteractionAllActorsInLevel(this.Owner.ActorComp.GetSceneInteractionLevelHandleId());
				for (int i = 0; i < sceneInteractionAllActorsInLevel.Num(); i++)
				{
					this.TraceElement.ActorsToIgnore.Add(sceneInteractionAllActorsInLevel.Get(i));
				}
				this.TraceElement.SetBoxHalfSize(5f, 5f, 5f);
				TArray<TEnumAsByte<EObjectTypeQuery>> tarray = new TArray<TEnumAsByte<EObjectTypeQuery>>();
				tarray.Add(KuroObjectTypeQuery.WorldStatic);
				tarray.Add(KuroObjectTypeQuery.WorldDynamic);
				this.TraceElement.SetObjectTypesQuery(ref tarray);
				this.TraceElement.WorldContextObject = this.Owner.ActorComp.Owner;
			}
			this.TraceElement.SetStartLocation(traceStartPoint.X, traceStartPoint.Y, traceStartPoint.Z);
			this.TraceElement.SetEndLocation(traceEndPoint.X, traceEndPoint.Y, traceEndPoint.Z);
		}

		// Token: 0x06043C88 RID: 277640 RVA: 0x01182FB4 File Offset: 0x011811B4
		private void OnActorOverlapCallback(bool isEnter, AActor actor)
		{
			if (this.IgnoreOverlap)
			{
				return;
			}
			EntityHandle entityHandle = this.ExtractEntity(actor);
			if (entityHandle != null && entityHandle.Id == this.Owner.Entity.Id)
			{
				return;
			}
			this.UpdateEffectByTrace();
		}

		// Token: 0x06043C89 RID: 277641 RVA: 0x01182FF4 File Offset: 0x011811F4
		[NullableContext(2)]
		private EntityHandle ExtractEntity(AActor actor)
		{
			if (actor == null || !actor.IsValid())
			{
				return null;
			}
			return ModelBase<CreatureModel>.Instance.GetEntityByChildActor(actor);
		}

		// Token: 0x06043C8A RID: 277642 RVA: 0x0118300E File Offset: 0x0118120E
		private void OnSceneItemLockPropChange(bool isLock)
		{
			if (isLock)
			{
				this.StopAllEffect();
				this.RelativePoints.Empty(true);
				this.AbsolutePoints.Empty(true);
				this.StopOverlap();
				return;
			}
			this.UpdateEffectByTrace();
			this.StartOverlap();
		}

		// Token: 0x06043C8B RID: 277643 RVA: 0x01183044 File Offset: 0x01181244
		private void StartOverlap()
		{
			if (!Singleton<EventSystem>.Instance.HasWithTarget(this.Owner.Entity, EEventName.OnActorInOutRangeLocal, new Action<bool, AActor>(this.OnActorOverlapCallback)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(this.Owner.Entity, EEventName.OnActorInOutRangeLocal, new Action<bool, AActor>(this.OnActorOverlapCallback));
			}
		}

		// Token: 0x06043C8C RID: 277644 RVA: 0x011830A0 File Offset: 0x011812A0
		private void StopOverlap()
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget(this.Owner.Entity, EEventName.OnActorInOutRangeLocal, new Action<bool, AActor>(this.OnActorOverlapCallback)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.Owner.Entity, EEventName.OnActorInOutRangeLocal, new Action<bool, AActor>(this.OnActorOverlapCallback));
			}
		}

		// Token: 0x06043C8D RID: 277645 RVA: 0x011830FC File Offset: 0x011812FC
		private void StopAllEffect()
		{
			this.StopBeamEffect();
			if (this.StartEffectHandle != null)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.StartEffectHandle.Value, "RbLightBeamItemLogic StopAllEffect", true, null);
				this.StartEffectHandle = null;
			}
		}

		// Token: 0x06043C8E RID: 277646 RVA: 0x01183150 File Offset: 0x01181350
		private void StopBeamEffect()
		{
			if (this.EffectHandle != null)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.EffectHandle.Value, "RbLightBeamItemLogic StopBeamEffect", true, null);
				this.EffectHandle = null;
			}
			if (this.HitEffectHandle != null)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.HitEffectHandle.Value, "RbLightBeamItemLogic StopBeamEffect", true, null);
				this.HitEffectHandle = null;
			}
		}

		// Token: 0x04025E85 RID: 155269
		private const int LIGHT_BEAM_BOX_EXTENT_WIDTH = 5;

		// Token: 0x04025E86 RID: 155270
		private const int LIGHT_BEAM_BOX_EXTENT_HEIGHT = 5;

		// Token: 0x04025E87 RID: 155271
		private FVectorDouble? OriginLocation;

		// Token: 0x04025E88 RID: 155272
		private int? EffectHandle;

		// Token: 0x04025E89 RID: 155273
		private int? HitEffectHandle;

		// Token: 0x04025E8A RID: 155274
		private int? StartEffectHandle;

		// Token: 0x04025E8B RID: 155275
		private readonly TArray<FVectorDouble> RelativePoints = new TArray<FVectorDouble>();

		// Token: 0x04025E8C RID: 155276
		private readonly global::Vector Location = global::Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x04025E8D RID: 155277
		[Nullable(2)]
		private UTraceBoxElement TraceElement;

		// Token: 0x04025E8E RID: 155278
		[Nullable(2)]
		private RangeComponent RangeComp;

		// Token: 0x04025E8F RID: 155279
		private readonly global::Vector BoxExtent = global::Vector.Create(0.0, 5.0, 5.0);

		// Token: 0x04025E90 RID: 155280
		private readonly TArray<FVectorDouble> AbsolutePoints = new TArray<FVectorDouble>();

		// Token: 0x04025E91 RID: 155281
		private readonly TArray<FVectorDouble> AbsoluteOriginPoint = new TArray<FVectorDouble>();

		// Token: 0x04025E92 RID: 155282
		private FVectorDouble ImpactPoint = new FVectorDouble();

		// Token: 0x04025E93 RID: 155283
		private bool IgnoreOverlap;
	}
}
