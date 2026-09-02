using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using UnrealEngine;

// Token: 0x02002E2A RID: 11818
[NullableContext(1)]
[Nullable(0)]
public class AnimLogicParamsSetter
{
	// Token: 0x0400B9A7 RID: 47527
	public bool AcceptedNewBeHit;

	// Token: 0x0400B9A8 RID: 47528
	public EHitAnim BeHitAnim;

	// Token: 0x0400B9A9 RID: 47529
	public bool EnterFk;

	// Token: 0x0400B9AA RID: 47530
	public bool DoubleHitInAir;

	// Token: 0x0400B9AB RID: 47531
	public Vector BeHitDirect = Vector.Create();

	// Token: 0x0400B9AC RID: 47532
	public Vector BeHitLocation = Vector.Create();

	// Token: 0x0400B9AD RID: 47533
	public FName BeHitSocketName = FNameUtil.EMPTY;

	// Token: 0x0400B9AE RID: 47534
	public FName BeHitBone = FNameUtil.EMPTY;

	// Token: 0x0400B9AF RID: 47535
	public ECharMoveState CharMoveState;

	// Token: 0x0400B9B0 RID: 47536
	public ECharPositionState CharPositionState;

	// Token: 0x0400B9B1 RID: 47537
	public ECharDirectionState CharCameraState = ECharDirectionState.FaceDirection;

	// Token: 0x0400B9B2 RID: 47538
	public float BattleIdleTime = --0f;

	// Token: 0x0400B9B3 RID: 47539
	public float DegMovementSlope;

	// Token: 0x0400B9B4 RID: 47540
	public Vector SightDirect = Vector.Create();

	// Token: 0x0400B9B5 RID: 47541
	public bool RagQuitState;

	// Token: 0x0400B9B6 RID: 47542
	public bool IsJump;

	// Token: 0x0400B9B7 RID: 47543
	public Vector Acceleration = Vector.Create();

	// Token: 0x0400B9B8 RID: 47544
	public bool IsMoving;

	// Token: 0x0400B9B9 RID: 47545
	public bool ForceExitStateStop;

	// Token: 0x0400B9BA RID: 47546
	public float Speed;

	// Token: 0x0400B9BB RID: 47547
	public bool EnableAdditiveTurn;

	// Token: 0x0400B9BC RID: 47548
	public Vector InputDirect = Vector.Create();

	// Token: 0x0400B9BD RID: 47549
	public bool IsFallingIntoWater;

	// Token: 0x0400B9BE RID: 47550
	public float GroundedTime = --0f;

	// Token: 0x0400B9BF RID: 47551
	public bool HasMoveInput;

	// Token: 0x0400B9C0 RID: 47552
	public CSharpScript.Game.NewWorld.Character.Common.Component.Move.SClimbInfo ClimbInfo = new CSharpScript.Game.NewWorld.Character.Common.Component.Move.SClimbInfo(null, null, null);

	// Token: 0x0400B9C1 RID: 47553
	public CSharpScript.Game.NewWorld.Character.Common.Component.Move.SClimbState ClimbState = new CSharpScript.Game.NewWorld.Character.Common.Component.Move.SClimbState(null, null, null);

	// Token: 0x0400B9C2 RID: 47554
	public float ClimbRadius;

	// Token: 0x0400B9C3 RID: 47555
	public Rotator InputRotator = Rotator.Create();

	// Token: 0x0400B9C4 RID: 47556
	public float ClimbOnWallAngle;

	// Token: 0x0400B9C5 RID: 47557
	public float SprintSwimOffset;

	// Token: 0x0400B9C6 RID: 47558
	public float SprintSwimOffsetLerpSpeed;

	// Token: 0x0400B9C7 RID: 47559
	public Vector SlideForward = Vector.Create();

	// Token: 0x0400B9C8 RID: 47560
	public bool SlideSwitchThisFrame;

	// Token: 0x0400B9C9 RID: 47561
	public bool SlideStandMode;

	// Token: 0x0400B9CA RID: 47562
	public float JumpUpRate = --0f;

	// Token: 0x0400B9CB RID: 47563
	public int SkillTarget;

	// Token: 0x0400B9CC RID: 47564
	public int HateTarget;

	// Token: 0x0400B9CD RID: 47565
	public double LastActiveSkillTime;

	// Token: 0x0400B9CE RID: 47566
	public int SitDownDirect = -1;

	// Token: 0x0400B9CF RID: 47567
	public int StandUpDirect = -1;

	// Token: 0x0400B9D0 RID: 47568
	public int SitDownType;

	// Token: 0x0400B9D1 RID: 47569
	public bool SitDown;

	// Token: 0x0400B9D2 RID: 47570
	public bool IsInPerformingPlot;

	// Token: 0x0400B9D3 RID: 47571
	public bool IsInSequence;

	// Token: 0x0400B9D4 RID: 47572
	public bool IsInSplineMove;

	// Token: 0x0400B9D5 RID: 47573
	public bool IsInUiCamera;

	// Token: 0x0400B9D6 RID: 47574
	public Vector2D LookAt = Vector2D.Create();

	// Token: 0x0400B9D7 RID: 47575
	public bool EnableBlendSpaceLookAt;

	// Token: 0x0400B9D8 RID: 47576
	public SightLockMode CameraMode;

	// Token: 0x0400B9D9 RID: 47577
	public bool IsDriver;

	// Token: 0x0400B9DA RID: 47578
	public bool IsOnVehicle;

	// Token: 0x0400B9DB RID: 47579
	public bool IsOnVehicleWithOther;

	// Token: 0x0400B9DC RID: 47580
	public bool IsLeavingVehicle;

	// Token: 0x0400B9DD RID: 47581
	public int VehicleType;

	// Token: 0x0400B9DE RID: 47582
	public bool EnableLowerBlend;

	// Token: 0x0400B9DF RID: 47583
	public bool EnableLeftArmBlend;

	// Token: 0x0400B9E0 RID: 47584
	public bool EnableRightArmBlend;

	// Token: 0x0400B9E1 RID: 47585
	public bool IsHoldingHands;

	// Token: 0x0400B9E2 RID: 47586
	public bool IsBeHoldingHands;

	// Token: 0x0400B9E3 RID: 47587
	public bool IsHoldingHandsReachable;

	// Token: 0x0400B9E4 RID: 47588
	public bool IsAcceptingInvitation;

	// Token: 0x0400B9E5 RID: 47589
	public IkTarget LeftHandIkTarget = new IkTarget(null, null, null);

	// Token: 0x0400B9E6 RID: 47590
	public IkTarget RightHandIkTarget = new IkTarget(null, null, null);

	// Token: 0x0400B9E7 RID: 47591
	public bool IgnoreMontageBlinkCurve;

	// Token: 0x0400B9E8 RID: 47592
	public bool DisableBlink;

	// Token: 0x0400B9E9 RID: 47593
	public bool DisableHumanIk;

	// Token: 0x0400B9EA RID: 47594
	public bool IsRegionMoveMode;

	// Token: 0x0400B9EB RID: 47595
	public Vector FloatingLocalDirection = Vector.Create();

	// Token: 0x0400B9EC RID: 47596
	public float FloatingMoveMix;

	// Token: 0x0400B9ED RID: 47597
	public Vector HookTargetLocation = Vector.Create();

	// Token: 0x0400B9EE RID: 47598
	public bool IsVehicleImpact;

	// Token: 0x0400B9EF RID: 47599
	public float VehicleCollisionAngle;

	// Token: 0x0400B9F0 RID: 47600
	public float VehicleCollisionStrength;

	// Token: 0x0400B9F1 RID: 47601
	public float YawInPassengerCoordinate;

	// Token: 0x0400B9F2 RID: 47602
	public Vector VehicleVelocity = Vector.Create();

	// Token: 0x0400B9F3 RID: 47603
	public bool IsRailSlideMove;

	// Token: 0x0400B9F4 RID: 47604
	public bool IsAirRailSlideMove;

	// Token: 0x0400B9F5 RID: 47605
	public ERailSlideJumpType RailSlideJumpType;

	// Token: 0x0400B9F6 RID: 47606
	public bool UseLandAnimation;

	// Token: 0x0400B9F7 RID: 47607
	public ERailSlideAnimType RailSlideAnimType;
}
