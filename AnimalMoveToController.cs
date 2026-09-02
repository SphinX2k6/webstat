using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02002E18 RID: 11800
[NullableContext(1)]
[Nullable(0)]
public class AnimalMoveToController
{
	// Token: 0x06017DFD RID: 97789 RVA: 0x006AFE08 File Offset: 0x006AE008
	public AnimalMoveToController(Entity entity)
	{
		this.ActorComp = entity.GetComponent<CharacterActorComponent>();
		if (UKuroStaticLibrary.IsObjectClassByName(this.ActorComp.Owner, Singleton<CharacterNameDefines>.Instance.BP_BASEANIMAL))
		{
			BP_BaseAnimal_C bp_BaseAnimal_C = this.ActorComp.Owner as BP_BaseAnimal_C;
			this.AngularVelocityCurve = ((bp_BaseAnimal_C != null) ? bp_BaseAnimal_C.TurnSpeedCurve : null);
		}
		else
		{
			this.AngularVelocityCurve = null;
		}
		this.StateComp = entity.GetComponent<BaseUnifiedStateComponent>();
		this.MoveComp = entity.GetComponent<CharacterMoveComponent>();
		this.MaxAccelerationConfigCache = this.MoveComp.CharacterMovement.MaxAcceleration;
	}

	// Token: 0x06017DFE RID: 97790 RVA: 0x006AFEA7 File Offset: 0x006AE0A7
	public void Init(ECharMoveState moveState, bool rootMotion)
	{
		this.MoveState = moveState;
		this.StateComp.SetMoveState(moveState);
		this.RootMotion = rootMotion;
		this.IsInited = true;
	}

	// Token: 0x06017DFF RID: 97791 RVA: 0x006AFECC File Offset: 0x006AE0CC
	public void Start(Vector targetLocation, bool isNavigation, float turnSpeed, double distanceErrorThreshold = 100.0)
	{
		if (!this.IsInited)
		{
			return;
		}
		this.NavigationOn = isNavigation;
		this.RobustTurnSpeed = turnSpeed;
		this.DistanceErrorThreshold = distanceErrorThreshold;
		this.ForceStop = false;
		if (this.MoveState == ECharMoveState.NormalSwim && !this.RootMotion)
		{
			this.MoveComp.CharacterMovement.MaxAcceleration = this.MaxAccelerationConfigCache;
		}
		if (this.MovePath != null)
		{
			this.MovePath.Clear();
		}
		else
		{
			this.MovePath = new List<Vector>();
		}
		if (!this.NavigationOn)
		{
			Vector vector = Vector.Create();
			vector.DeepCopy(targetLocation);
			this.MovePath.Add(vector);
			this.CurrentMoveIndex = 0;
			return;
		}
		if (!AiControllerLibrary.NavigationFindPath(this.ActorComp.Owner.GetWorld(), this.ActorComp.ActorLocation, targetLocation.ToUeVector(false), this.MovePath, null, null))
		{
			Vector vector2 = Vector.Create();
			vector2.DeepCopy(targetLocation);
			this.MovePath.Add(vector2);
			this.CurrentMoveIndex = 0;
			return;
		}
		this.CurrentMoveIndex = 1;
	}

	// Token: 0x06017E00 RID: 97792 RVA: 0x006AFFDC File Offset: 0x006AE1DC
	public EAnimalMoveToState Update(float delta)
	{
		if (this.ForceStop)
		{
			return EAnimalMoveToState.Failure;
		}
		Vector vector = this.MovePath[this.CurrentMoveIndex];
		if (vector.ContainsNaN())
		{
			return EAnimalMoveToState.Failure;
		}
		vector.Subtraction(this.ActorComp.ActorLocationProxy, this.CacheVector);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.CacheVector);
		if (this.CacheVector.Size() < this.DistanceErrorThreshold)
		{
			if (this.CurrentMoveIndex == this.MovePath.Count - 1)
			{
				return EAnimalMoveToState.Success;
			}
			this.CurrentMoveIndex++;
			return EAnimalMoveToState.Running;
		}
		else
		{
			this.CacheVector.Normalize(9.99999993922529E-09);
			if (vector.ContainsNaN())
			{
				return EAnimalMoveToState.Failure;
			}
			this.ExecuteInputMoveLogic(this.CacheVector);
			return EAnimalMoveToState.Running;
		}
	}

	// Token: 0x06017E01 RID: 97793 RVA: 0x006B00A4 File Offset: 0x006AE2A4
	public void Stop()
	{
		this.ForceStop = true;
	}

	// Token: 0x06017E02 RID: 97794 RVA: 0x006B00B0 File Offset: 0x006AE2B0
	public void Finish()
	{
		if (this.MoveState == ECharMoveState.NormalSwim && !this.RootMotion)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.ClearInput(false, true);
			}
			this.MoveComp.CharacterMovement.MaxAcceleration = this.MaxAccelerationConfigCache;
		}
		this.IsInited = false;
	}

	// Token: 0x06017E03 RID: 97795 RVA: 0x006B0100 File Offset: 0x006AE300
	private void ExecuteInputMoveLogic(Vector direction)
	{
		this.ActorComp.SetInputDirect(direction, false);
		float turnSpeed = this.RobustTurnSpeed;
		if (this.AngularVelocityCurve != null)
		{
			double num = Singleton<MathUtils>.Instance.GetAngleByVectorDot(this.ActorComp.ActorForwardProxy, direction) * 0.01745329238474369;
			float floatValue = this.AngularVelocityCurve.GetFloatValue((float)num);
			turnSpeed = Singleton<MathUtils>.Instance.Lerp(this.RobustTurnSpeed, 360f, floatValue);
		}
		AiControllerLibrary.TurnToDirect(this.ActorComp, direction, turnSpeed, false, 0f);
	}

	// Token: 0x0400B934 RID: 47412
	private const int DISTANCE_ERROR_THRESHOLD = 100;

	// Token: 0x0400B935 RID: 47413
	private const float MAX_TURN_SPEED = 360f;

	// Token: 0x0400B936 RID: 47414
	private readonly CharacterActorComponent ActorComp;

	// Token: 0x0400B937 RID: 47415
	private readonly BaseUnifiedStateComponent StateComp;

	// Token: 0x0400B938 RID: 47416
	private readonly CharacterMoveComponent MoveComp;

	// Token: 0x0400B939 RID: 47417
	[Nullable(2)]
	private readonly UCurveFloat AngularVelocityCurve;

	// Token: 0x0400B93A RID: 47418
	private ECharMoveState MoveState;

	// Token: 0x0400B93B RID: 47419
	private bool RootMotion;

	// Token: 0x0400B93C RID: 47420
	private bool NavigationOn;

	// Token: 0x0400B93D RID: 47421
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<Vector> MovePath;

	// Token: 0x0400B93E RID: 47422
	private int CurrentMoveIndex;

	// Token: 0x0400B93F RID: 47423
	private float RobustTurnSpeed;

	// Token: 0x0400B940 RID: 47424
	private bool IsInited;

	// Token: 0x0400B941 RID: 47425
	private bool ForceStop;

	// Token: 0x0400B942 RID: 47426
	private readonly Vector CacheVector = Vector.Create();

	// Token: 0x0400B943 RID: 47427
	private double DistanceErrorThreshold;

	// Token: 0x0400B944 RID: 47428
	private readonly float MaxAccelerationConfigCache;
}
