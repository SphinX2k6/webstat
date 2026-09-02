using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003174 RID: 12660
[NullableContext(1)]
[Nullable(0)]
public class LocomotionUtils
{
	// Token: 0x0601A3CF RID: 107471 RVA: 0x007B6480 File Offset: 0x007B4680
	private static EDetectCapsuleResult DetectCapsuleSizeLocationInternal(UShapeComponent shape, UTraceCapsuleElement element, UTraceSphereElement element2, Vector start, Vector outVector)
	{
		Singleton<TraceElementCommon>.Instance.SetStartLocation(element, start);
		if (!Singleton<TraceElementCommon>.Instance.ShapeTrace(shape, element, "DetectCapsuleSizeLocation", "DetectCapsuleSizeLocation") || element.HitResult == null)
		{
			return EDetectCapsuleResult.None;
		}
		if (element.HitResult.bStartPenetrating || (double)element.HitResult.TimeArray.Get(0) <= 1E-08)
		{
			return EDetectCapsuleResult.StartPenetrate;
		}
		Singleton<TraceElementCommon>.Instance.SetEndLocation(element2, start);
		if (Singleton<TraceElementCommon>.Instance.ShapeTrace(shape, element2, "DetectCapsuleSizeLocation", "DetectCapsuleSizeLocation") && element2.HitResult != null && element2.HitResult.GetHitCount() > 0 && element2.HitResult.TimeArray.Get(0) < 0.95f)
		{
			return EDetectCapsuleResult.None;
		}
		Singleton<TraceElementCommon>.Instance.GetHitLocation(element.HitResult, 0, outVector);
		return EDetectCapsuleResult.NormalHit;
	}

	// Token: 0x0601A3D0 RID: 107472 RVA: 0x007B6550 File Offset: 0x007B4750
	public static EResultForExitClimb FindSpaceForExitClimb(CharacterActorComponent actorComp, float halfHeight, float radius, float minRadius, Vector outVector)
	{
		UCapsuleComponent capsuleComponent = actorComp.Actor.CapsuleComponent;
		if (capsuleComponent == null)
		{
			return EResultForExitClimb.NoHit;
		}
		UTraceCapsuleElement capsuleTrace = ModelBase<TraceElementModel>.Instance.GetCapsuleTrace();
		capsuleTrace.WorldContextObject = actorComp.Actor;
		capsuleTrace.Radius = radius;
		capsuleTrace.HalfHeight = halfHeight;
		actorComp.ActorUpProxy.Multiply(1.0, LocomotionUtils.TmpVector);
		LocomotionUtils.TmpVector.AdditionEqual(actorComp.ActorLocationProxy);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(capsuleTrace, LocomotionUtils.TmpVector);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(capsuleTrace, actorComp.ActorLocationProxy);
		capsuleTrace.ActorsToIgnore.Empty(true);
		if (!Singleton<TraceElementCommon>.Instance.ShapeTrace(capsuleComponent, capsuleTrace, "DetectCapsuleSizeLocation", "DetectCapsuleSizeLocation") || capsuleTrace.HitResult == null)
		{
			return EResultForExitClimb.NoHit;
		}
		if (!capsuleTrace.HitResult.bStartPenetrating && (double)capsuleTrace.HitResult.TimeArray.Get(0) > 1E-08)
		{
			Singleton<TraceElementCommon>.Instance.GetHitLocation(capsuleTrace.HitResult, 0, outVector);
			return EResultForExitClimb.Safety;
		}
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = actorComp.Actor;
		actorTrace.Radius = minRadius;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, actorComp.ActorLocationProxy);
		actorComp.ActorUpProxy.Multiply((double)(halfHeight / 2f), LocomotionUtils.TmpVector2);
		actorComp.ActorLocationProxy.Addition(LocomotionUtils.TmpVector2, LocomotionUtils.TmpVector);
		EDetectCapsuleResult edetectCapsuleResult = LocomotionUtils.DetectCapsuleSizeLocationInternal(capsuleComponent, capsuleTrace, actorTrace, LocomotionUtils.TmpVector, outVector);
		if (edetectCapsuleResult == EDetectCapsuleResult.NormalHit)
		{
			return EResultForExitClimb.Safety;
		}
		if (edetectCapsuleResult == EDetectCapsuleResult.StartPenetrate)
		{
			LocomotionUtils.TmpVector.AdditionEqual(LocomotionUtils.TmpVector2);
			if (LocomotionUtils.DetectCapsuleSizeLocationInternal(capsuleComponent, capsuleTrace, actorTrace, LocomotionUtils.TmpVector, outVector) == EDetectCapsuleResult.NormalHit)
			{
				return EResultForExitClimb.Safety;
			}
		}
		actorComp.ActorForwardProxy.Multiply((double)(-(double)radius), LocomotionUtils.TmpVector2);
		actorComp.ActorLocationProxy.Addition(LocomotionUtils.TmpVector2, LocomotionUtils.TmpVector);
		edetectCapsuleResult = LocomotionUtils.DetectCapsuleSizeLocationInternal(capsuleComponent, capsuleTrace, actorTrace, LocomotionUtils.TmpVector, outVector);
		if (edetectCapsuleResult == EDetectCapsuleResult.NormalHit)
		{
			return EResultForExitClimb.Safety;
		}
		if (edetectCapsuleResult == EDetectCapsuleResult.StartPenetrate)
		{
			LocomotionUtils.TmpVector.AdditionEqual(LocomotionUtils.TmpVector2);
			if (LocomotionUtils.DetectCapsuleSizeLocationInternal(capsuleComponent, capsuleTrace, actorTrace, LocomotionUtils.TmpVector, outVector) == EDetectCapsuleResult.NormalHit)
			{
				return EResultForExitClimb.Safety;
			}
		}
		actorComp.ActorUpProxy.Multiply((double)halfHeight, LocomotionUtils.TmpVector);
		LocomotionUtils.TmpVector2.AdditionEqual(LocomotionUtils.TmpVector);
		actorComp.ActorLocationProxy.Addition(LocomotionUtils.TmpVector2, LocomotionUtils.TmpVector);
		edetectCapsuleResult = LocomotionUtils.DetectCapsuleSizeLocationInternal(capsuleComponent, capsuleTrace, actorTrace, LocomotionUtils.TmpVector, outVector);
		if (edetectCapsuleResult == EDetectCapsuleResult.NormalHit)
		{
			return EResultForExitClimb.Safety;
		}
		if (edetectCapsuleResult == EDetectCapsuleResult.StartPenetrate)
		{
			LocomotionUtils.TmpVector.AdditionEqual(LocomotionUtils.TmpVector2);
			if (LocomotionUtils.DetectCapsuleSizeLocationInternal(capsuleComponent, capsuleTrace, actorTrace, LocomotionUtils.TmpVector, outVector) == EDetectCapsuleResult.NormalHit)
			{
				return EResultForExitClimb.Safety;
			}
		}
		return EResultForExitClimb.NoSafety;
	}

	// Token: 0x0601A3D1 RID: 107473 RVA: 0x007B67C8 File Offset: 0x007B49C8
	public static bool FindSpaceForSafety(CharacterActorComponent actorComp, float halfHeight, float radius, Vector outVector)
	{
		UCapsuleComponent capsuleComponent = actorComp.Actor.CapsuleComponent;
		if (capsuleComponent == null)
		{
			return false;
		}
		UTraceCapsuleElement capsuleTrace = ModelBase<TraceElementModel>.Instance.GetCapsuleTrace();
		capsuleTrace.WorldContextObject = actorComp.Actor;
		capsuleTrace.Radius = radius;
		capsuleTrace.HalfHeight = halfHeight;
		Singleton<TraceElementCommon>.Instance.SetEndLocation(capsuleTrace, actorComp.ActorLocationProxy);
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = actorComp.Actor;
		actorTrace.Radius = 1f;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, actorComp.ActorLocationProxy);
		foreach (Vector inV in new Vector[]
		{
			Vector.Create(0.0, 0.0, (double)(halfHeight / 2f)),
			Vector.Create((double)(radius * 4f), 0.0, (double)(halfHeight / 2f)),
			Vector.Create((double)(-(double)radius * 4f), 0.0, (double)(halfHeight / 2f)),
			Vector.Create(0.0, (double)(radius * 4f), (double)(halfHeight / 2f)),
			Vector.Create(0.0, (double)(-(double)radius * 4f), (double)(halfHeight / 2f)),
			Vector.Create((double)(LocomotionUtils.SinCos45 * radius * 4f), (double)(LocomotionUtils.SinCos45 * radius * 4f), (double)(halfHeight / 2f)),
			Vector.Create((double)(-(double)LocomotionUtils.SinCos45 * radius * 4f), (double)(LocomotionUtils.SinCos45 * radius * 4f), (double)(halfHeight / 2f)),
			Vector.Create((double)(LocomotionUtils.SinCos45 * radius * 4f), (double)(-(double)LocomotionUtils.SinCos45 * radius * 4f), (double)(halfHeight / 2f)),
			Vector.Create((double)(-(double)LocomotionUtils.SinCos45 * radius * 4f), (double)(-(double)LocomotionUtils.SinCos45 * radius * 4f), (double)(halfHeight / 2f))
		})
		{
			actorComp.ActorQuatProxy.RotateVector(inV, LocomotionUtils.TmpVector2);
			actorComp.ActorLocationProxy.Addition(LocomotionUtils.TmpVector2, LocomotionUtils.TmpVector);
			EDetectCapsuleResult edetectCapsuleResult = LocomotionUtils.DetectCapsuleSizeLocationInternal(capsuleComponent, capsuleTrace, actorTrace, LocomotionUtils.TmpVector, outVector);
			if (edetectCapsuleResult == EDetectCapsuleResult.NormalHit)
			{
				return true;
			}
			if (edetectCapsuleResult == EDetectCapsuleResult.StartPenetrate)
			{
				LocomotionUtils.TmpVector.AdditionEqual(LocomotionUtils.TmpVector2);
				if (LocomotionUtils.DetectCapsuleSizeLocationInternal(capsuleComponent, capsuleTrace, actorTrace, LocomotionUtils.TmpVector, outVector) == EDetectCapsuleResult.NormalHit)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0400D340 RID: 54080
	private const string PROFILE_KEY = "DetectCapsuleSizeLocation";

	// Token: 0x0400D341 RID: 54081
	private const float HIT_TIME_THREHOLD = 0.95f;

	// Token: 0x0400D342 RID: 54082
	[StaticVariableRuleIgnore]
	private static readonly float SinCos45 = (float)Math.Cos(0.7853981633974483);

	// Token: 0x0400D343 RID: 54083
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector = Vector.Create();

	// Token: 0x0400D344 RID: 54084
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector2 = Vector.Create();
}
