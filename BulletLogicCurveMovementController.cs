using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using AkiClient.Game.Aki.Data.PathLine.PathLine_Bullet;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02002DC0 RID: 11712
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BulletLogicCurveMovementController : BulletLogicController<LogicDataSplineMovement, float>
{
	// Token: 0x060179E2 RID: 96738 RVA: 0x006927FC File Offset: 0x006909FC
	public BulletLogicCurveMovementController(LogicDataSplineMovement param, Entity bullet) : base(param, bullet)
	{
		this.MovingTimeMs = 0f;
		this.ScaleSpline = 1f;
		this.ActorComp = this.Bullet.GetComponent<BulletActorComponent>();
		this.BulletInfo = this.Bullet.GetBulletInfo();
	}

	// Token: 0x060179E3 RID: 96739 RVA: 0x0069284C File Offset: 0x00690A4C
	public override void OnInit()
	{
		Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(this.LogicController.SplineTrace.ToAssetPathName(), delegate([Nullable(2)] UClass splineTrace, string path)
		{
			this.SpawnCurve(splineTrace);
		}, 100, "js_undefined");
		this.BulletInfo.BulletDataMain.Execution.MovementReplaced = true;
	}

	// Token: 0x060179E4 RID: 96740 RVA: 0x0069289D File Offset: 0x00690A9D
	public override void OnBulletDestroy()
	{
		if (this.SplineComp != null)
		{
			Singleton<ActorSystem>.Instance.Put("BulletLogicCurveMovementController.OnBulletDestroy", this.SplineComp.GetOwner(), null);
			this.SplineComp = null;
		}
	}

	// Token: 0x060179E5 RID: 96741 RVA: 0x006928CC File Offset: 0x00690ACC
	private void SpawnCurve(UClass splineTrace)
	{
		BulletEntity bullet = this.Bullet;
		if (bullet == null || !bullet.Valid)
		{
			return;
		}
		if (this.LogicController.SplineTrace != null)
		{
			FVectorDouble? destLocation = this.GetDestLocation();
			FRotator? frotator;
			if (destLocation == null)
			{
				frotator = null;
			}
			else
			{
				FVectorDouble actorLocation = this.ActorComp.ActorLocation;
				FVectorDouble value = destLocation.Value;
				frotator = new FRotator?(UKismetMathLibrary.D_FindLookAtRotation(actorLocation, value));
			}
			FRotator? frotator2 = frotator;
			FTransformDouble transform = UKismetMathLibrary.MakeTransformDouble(this.ActorComp.ActorLocation, (destLocation != null) ? frotator2.Value : this.ActorComp.ActorRotation, Vector.OneVector);
			AActor aactor = Singleton<ActorSystem>.Instance.Get(splineTrace.ClassStackOnlyPtr, transform, null, true);
			if (!ObjectUtils.IsValid(aactor))
			{
				Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.HCW, "加载的Spline为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			BP_BasePathLineBullet_C bp_BasePathLineBullet_C = aactor as BP_BasePathLineBullet_C;
			if (bp_BasePathLineBullet_C == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.HCW, "加载的Spline不是BP_BasePathLineBullet_C类型", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.SplineComp = bp_BasePathLineBullet_C.Spline;
			int numberOfSplinePoints = this.SplineComp.GetNumberOfSplinePoints();
			FVectorDouble fvectorDouble = this.SplineComp.D_GetLocationAtSplinePoint(numberOfSplinePoints - 1, ESplineCoordinateSpace.World);
			FVectorDouble fvectorDouble2 = this.SplineComp.D_GetLocationAtSplinePoint(0, ESplineCoordinateSpace.World);
			double num = FVectorDouble.DistSquared(fvectorDouble2, fvectorDouble);
			double num2;
			if (destLocation == null)
			{
				num2 = (double)this.SplineComp.GetSplineLength();
			}
			else
			{
				FVectorDouble actorLocation = this.ActorComp.ActorLocation;
				FVectorDouble value = destLocation.Value;
				num2 = FVectorDouble.DistSquared(actorLocation, value);
			}
			double num3 = num2;
			if (destLocation != null)
			{
				this.ScaleSpline = (float)Math.Sqrt(num3 / num);
				this.SplineComp.GetOwner().D_SetActorScale3D(Vector.OneVectorDouble * (double)this.ScaleSpline);
			}
			this.Duration = this.CalculateDuration();
			this.SplineComp.Duration = this.Duration;
		}
	}

	// Token: 0x060179E6 RID: 96742 RVA: 0x00692AB8 File Offset: 0x00690CB8
	public override void BulletLogicAction(float deltaTime)
	{
		if (this.SplineComp == null)
		{
			return;
		}
		float movingTimeMs = this.MovingTimeMs;
		if (!this.BulletInfo.NeedDestroy)
		{
			FVectorDouble value = this.SplineComp.D_GetLocationAtTime(movingTimeMs, ESplineCoordinateSpace.World, true);
			this.ActorComp.SetActorLocation(value, "unknown", true);
			if (this.LogicController.IsForwardTangent)
			{
				FRotator rotationAtTime = this.SplineComp.GetRotationAtTime(movingTimeMs, ESplineCoordinateSpace.World, true);
				this.ActorComp.SetActorRotation(rotationAtTime, "unknown", true);
			}
			this.MovingTimeMs += deltaTime * this.ActorComp.TimeDilation;
		}
		if (movingTimeMs >= this.Duration)
		{
			if (ObjectUtils.SoftObjectReferenceValid<UEffectModelBase>(this.LogicController.EffectOnReach))
			{
				AActor owner = this.ActorComp.Owner;
				EffectSystem instance = Singleton<EffectSystem>.Instance;
				UObject worldContext = owner;
				FTransformDouble? ftransformDouble = new FTransformDouble?(owner.D_GetTransform());
				string path = this.LogicController.EffectOnReach.ToAssetPathName();
				string reason = "[BulletLogicCurveMovementController.BulletLogicAction]";
				Entity attacker = this.BulletInfo.Attacker;
				int id = instance.SpawnEffect(worldContext, ftransformDouble, path, reason, new EffectContext((attacker != null) ? new int?(attacker.Id) : null, null, false), EEffectType.Scene, null, null, null, false, false);
				Singleton<EffectSystem>.Instance.SetAdditionTimeScale(ETimeScaleSourceType.SelfCentered, id, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
			}
			if (this.LogicController.IsDestroyReach)
			{
				ControllerBase<BulletController>.Instance.DestroyBullet(this.Bullet.Id, this.LogicController.IsSummonOnReach, EBulletDestroyReason.Normal, false);
			}
		}
	}

	// Token: 0x060179E7 RID: 96743 RVA: 0x00692C24 File Offset: 0x00690E24
	private void InitTraceInfo()
	{
		this.LineTrace = new UTraceLineElement();
		this.LineTrace.WorldContextObject = GlobalData.World;
		this.LineTrace.bIsSingle = true;
		this.LineTrace.bIgnoreSelf = true;
		this.LineTrace.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStatic);
		this.LineTrace.DrawTime = 5f;
		Singleton<TraceElementCommon>.Instance.SetTraceColor(this.LineTrace, ColorUtils.LinearGreen);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.LineTrace, ColorUtils.LinearRed);
	}

	// Token: 0x060179E8 RID: 96744 RVA: 0x00692CB0 File Offset: 0x00690EB0
	private FVectorDouble? GetDestLocation()
	{
		Entity target = this.BulletInfo.Target;
		BaseActorComponent baseActorComponent = (target != null && target.Valid) ? this.BulletInfo.TargetActorComp : null;
		if (this.LogicController.UseTargetLocation)
		{
			return BulletUtil.GetTargetLocation(baseActorComponent, FNameUtil.NONE, this.BulletInfo);
		}
		if (this.LineTrace == null)
		{
			this.InitTraceInfo();
		}
		bool flag = baseActorComponent != null && baseActorComponent.Valid;
		FVectorDouble fvectorDouble = new FVectorDouble();
		BPL_Fight_C.获取Actor周围坐标点(flag ? baseActorComponent.Owner : this.BulletInfo.AttackerActorComp.Owner, flag ? this.LogicController.Rotate : this.LogicController.SelfRotate, 0f, flag ? this.LogicController.Length : this.LogicController.SelfLength, this.ActorComp.Owner, ref fvectorDouble);
		fvectorDouble.Z += (double)(flag ? this.LogicController.Height : this.LogicController.SelfHeight);
		this.LineTrace.SetStartLocation(fvectorDouble.X, fvectorDouble.Y, fvectorDouble.Z + 500.0);
		this.LineTrace.SetEndLocation(fvectorDouble.X, fvectorDouble.Y, fvectorDouble.Z - 500.0);
		IVector vector = fvectorDouble;
		bool flag2 = Singleton<TraceElementCommon>.Instance.LineTrace(this.LineTrace, "BulletLogicCurveMovementController_GetDestLocation");
		UKuroHitResult hitResult = this.LineTrace.HitResult;
		if (flag2 && hitResult.bBlockingHit)
		{
			Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, 0, vector);
			vector.Z += (double)(flag ? this.LogicController.Height : this.LogicController.SelfHeight);
		}
		return new FVectorDouble?((FVectorDouble)vector);
	}

	// Token: 0x060179E9 RID: 96745 RVA: 0x00692E7C File Offset: 0x0069107C
	private float CalculateDuration()
	{
		float duration = this.LogicController.Duration;
		float maxSpeed = this.LogicController.MaxSpeed;
		float minSpeed = this.LogicController.MinSpeed;
		float num = this.SplineComp.GetSplineLength() * this.ScaleSpline;
		double max = (minSpeed > 0f) ? ((double)(num / minSpeed)) : 3.402823466E+38;
		float num2 = (maxSpeed > 0f) ? (num / maxSpeed) : 0f;
		return (float)(Singleton<MathUtils>.Instance.Clamp((double)duration, (double)num2, max) * (double)Singleton<TimeUtil>.Instance.InverseMillisecond);
	}

	// Token: 0x0400B5DF RID: 46559
	private const string PROFILE_KEY = "BulletLogicCurveMovementController_GetDestLocation";

	// Token: 0x0400B5E0 RID: 46560
	private const float HEIGHT_DETECT = 500f;

	// Token: 0x0400B5E1 RID: 46561
	private const float DRAW_DURATION = 5f;

	// Token: 0x0400B5E2 RID: 46562
	[Nullable(2)]
	private USplineComponent SplineComp;

	// Token: 0x0400B5E3 RID: 46563
	private readonly BulletActorComponent ActorComp;

	// Token: 0x0400B5E4 RID: 46564
	private readonly BulletInfo BulletInfo;

	// Token: 0x0400B5E5 RID: 46565
	private float MovingTimeMs;

	// Token: 0x0400B5E6 RID: 46566
	private float ScaleSpline;

	// Token: 0x0400B5E7 RID: 46567
	private float Duration;

	// Token: 0x0400B5E8 RID: 46568
	[Nullable(2)]
	private UTraceLineElement LineTrace;
}
