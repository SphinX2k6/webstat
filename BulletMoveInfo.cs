using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002E0A RID: 11786
[NullableContext(1)]
[Nullable(0)]
public class BulletMoveInfo : IStaticVariableResetter
{
	// Token: 0x06017D22 RID: 97570 RVA: 0x006A4D04 File Offset: 0x006A2F04
	static BulletMoveInfo()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BulletMoveInfo.CreateStaticDefaultValue), new Action(BulletMoveInfo.ResetStaticDefaultValue));
	}

	// Token: 0x06017D23 RID: 97571 RVA: 0x006A4D40 File Offset: 0x006A2F40
	public void Clear()
	{
		this.SocketTransform.Reset();
		this.BulletSpeedDir.Reset();
		this.UpdateDirVector.Reset();
		this.BulletSpeedRatio = 0f;
		this.BulletSpeed = 0f;
		this.GravityMoveRotator.Reset();
		this.GravityMoveForward.Reset();
		this.BulletSpeedZ = 0f;
		this.BulletSpeed2D = 0f;
		this.Gravity = 0f;
		this.BeginSpeedRotator.Reset();
		this.TraceRotator.Reset();
		this.RoundCenterLastLocation.Reset();
		this.RoundCenter.Reset();
		this.RoundOnceAxis.Reset();
		this.IsOnBaseMovement = false;
		this.LastBaseMovementSpeed.Reset();
		this.Gravity = 0f;
		this.FollowBoneBulletRotator.Reset();
		this.BaseAdditiveAccelerate.Reset();
		this.AdditiveAccelerate.Reset();
		this.AdditiveAccelerateCurve = null;
		this.V0.Reset();
		this.MinFollowHeight = 0.0;
		this.SpeedFollowTarget = 0.0;
		this.FollowTargetBottom = true;
		this.ObstaclesOffset.Reset();
		this.LastFramePosition.Reset();
		BulletTraceElementPool.RecycleTraceLineElement(this.AimedLineTraceElement);
		this.AimedLineTraceElement = null;
		this.ActorRotateParabola = false;
		this.AroundAngle = 0f;
	}

	// Token: 0x06017D24 RID: 97572 RVA: 0x006A4EA1 File Offset: 0x006A30A1
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x06017D25 RID: 97573 RVA: 0x006A4EA3 File Offset: 0x006A30A3
	public static void ResetStaticDefaultValue()
	{
		BulletMoveInfo.StickGroundLineTrace = null;
		BulletMoveInfo.StickWaterLineTrace = null;
		BulletMoveInfo.StickWaterSphereTrace = null;
	}

	// Token: 0x0400B8B9 RID: 47289
	public Transform SocketTransform = Transform.Create();

	// Token: 0x0400B8BA RID: 47290
	public Vector BulletSpeedDir = Vector.Create();

	// Token: 0x0400B8BB RID: 47291
	public Vector UpdateDirVector = Vector.Create();

	// Token: 0x0400B8BC RID: 47292
	public float BulletSpeedRatio;

	// Token: 0x0400B8BD RID: 47293
	public float BulletSpeed;

	// Token: 0x0400B8BE RID: 47294
	public Rotator GravityMoveRotator = Rotator.Create();

	// Token: 0x0400B8BF RID: 47295
	public Vector GravityMoveForward = Vector.Create();

	// Token: 0x0400B8C0 RID: 47296
	public float BulletSpeedZ;

	// Token: 0x0400B8C1 RID: 47297
	public float BulletSpeed2D;

	// Token: 0x0400B8C2 RID: 47298
	public float Gravity;

	// Token: 0x0400B8C3 RID: 47299
	public Rotator BeginSpeedRotator = Rotator.Create();

	// Token: 0x0400B8C4 RID: 47300
	public Rotator TraceRotator = Rotator.Create();

	// Token: 0x0400B8C5 RID: 47301
	public Vector RoundCenterLastLocation = Vector.Create();

	// Token: 0x0400B8C6 RID: 47302
	public Vector RoundCenter = Vector.Create();

	// Token: 0x0400B8C7 RID: 47303
	public Vector RoundOnceAxis = Vector.Create();

	// Token: 0x0400B8C8 RID: 47304
	public bool IsOnBaseMovement;

	// Token: 0x0400B8C9 RID: 47305
	public Vector LastBaseMovementSpeed = Vector.Create();

	// Token: 0x0400B8CA RID: 47306
	public Rotator FollowBoneBulletRotator = Rotator.Create();

	// Token: 0x0400B8CB RID: 47307
	public Vector BaseAdditiveAccelerate = Vector.Create();

	// Token: 0x0400B8CC RID: 47308
	public Vector AdditiveAccelerate = Vector.Create();

	// Token: 0x0400B8CD RID: 47309
	[Nullable(2)]
	public UCurveVector AdditiveAccelerateCurve;

	// Token: 0x0400B8CE RID: 47310
	public Vector V0 = Vector.Create();

	// Token: 0x0400B8CF RID: 47311
	public double MinFollowHeight;

	// Token: 0x0400B8D0 RID: 47312
	public double SpeedFollowTarget = 1.0;

	// Token: 0x0400B8D1 RID: 47313
	public bool FollowTargetBottom = true;

	// Token: 0x0400B8D2 RID: 47314
	public Vector LocationFollowTarget = Vector.Create();

	// Token: 0x0400B8D3 RID: 47315
	public Vector ObstaclesOffset = Vector.Create();

	// Token: 0x0400B8D4 RID: 47316
	public Vector LastFramePosition = Vector.Create();

	// Token: 0x0400B8D5 RID: 47317
	[StaticVariableRuleIgnore]
	public static readonly Transform TempTransform1 = Transform.Create();

	// Token: 0x0400B8D6 RID: 47318
	[Nullable(2)]
	public UTraceLineElement AimedLineTraceElement;

	// Token: 0x0400B8D7 RID: 47319
	[Nullable(2)]
	public static UTraceLineElement StickGroundLineTrace = null;

	// Token: 0x0400B8D8 RID: 47320
	[Nullable(2)]
	public static UTraceLineElement StickWaterLineTrace = null;

	// Token: 0x0400B8D9 RID: 47321
	[Nullable(2)]
	public static UTraceSphereElement StickWaterSphereTrace = null;

	// Token: 0x0400B8DA RID: 47322
	public bool ActorRotateParabola;

	// Token: 0x0400B8DB RID: 47323
	public float AroundAngle;
}
