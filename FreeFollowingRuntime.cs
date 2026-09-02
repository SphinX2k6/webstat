using System;
using System.Runtime.CompilerServices;

// Token: 0x020030E8 RID: 12520
[NullableContext(1)]
[Nullable(0)]
public class FreeFollowingRuntime
{
	// Token: 0x06019DFA RID: 105978 RVA: 0x0078FF94 File Offset: 0x0078E194
	public void Reset(CharacterActorComponent leader, bool followOnRight)
	{
		this.Initialized = true;
		this.LeaderEntityId = leader.Entity.Id;
		this.CurrentSide = (followOnRight ? EFreeFollowingSide.Right : EFreeFollowingSide.Left);
		this.ResetRuntimeState();
		this.ReferenceForward.DeepCopy(leader.ActorForwardProxy);
		Vector.VectorPlaneProject(this.ReferenceForward, leader.ActorGravityDirectProxy, this.TempVector);
		if (this.TempVector.Normalize(9.99999993922529E-09))
		{
			this.ReferenceForward.DeepCopy(this.TempVector);
		}
		else
		{
			this.ReferenceForward.DeepCopy(leader.ActorForwardProxy);
		}
		this.PredictionCenter.DeepCopy(leader.ActorLocationProxy);
		this.LastLeaderLocation.DeepCopy(leader.ActorLocationProxy);
	}

	// Token: 0x06019DFB RID: 105979 RVA: 0x00790050 File Offset: 0x0078E250
	public void Clear()
	{
		this.Initialized = false;
		this.LeaderEntityId = 0;
		this.ResetRuntimeState();
	}

	// Token: 0x06019DFC RID: 105980 RVA: 0x00790068 File Offset: 0x0078E268
	private void ResetRuntimeState()
	{
		this.State = EFreeFollowingState.Stable;
		this.FilteredLeaderSpeed = 0.0;
		this.FilteredLeaderAcceleration = 0.0;
		this.ForwardOffset = 0.0;
		this.FollowerRadius = 0.0;
		this.ActiveFollowRadius = 0.0;
		this.ActiveStartFollowingRadius = 0.0;
		this.RadialLag = 0.0;
		this.IsDistanceFollowingActive = false;
		this.IsStopRadiusAccepted = false;
		this.StopAngleError = double.NaN;
		this.IsStopAngleAccepted = false;
		this.UseWalkFollowingRules = false;
		this.MovementIntentRate = 1.0;
		this.LocalMovementActive = false;
		this.HoldForLocalMovement = false;
		this.OuterRingGateArmed = false;
		this.WalkBehindTargetPauseRemaining = 0.0;
		this.WalkBehindTargetPauseConsumed = false;
		this.TargetDistance = double.NaN;
		this.IsTargetDistanceAccepted = false;
		this.StopConfirmTime = 0.0;
		this.ReferenceForward.Reset();
		this.LastLeaderLocation.Reset();
		this.LeaderMoveDirection.Reset();
		this.WalkArrivalTarget.Reset();
		this.FilteredMovementIntentVelocity.Reset();
		this.PredictionCenter.Reset();
		this.RejoinDuration = 0.0;
		this.RecoverRate = 0.0;
		this.LastDeltaSeconds = 0.0;
		this.HadValidTargetLastFrame = false;
		this.WalkArrivalTargetValid = false;
		this.WalkArrivalHoldRemaining = 0.0;
		this.LeaderIsMoving = false;
		this.LeaderIsStand = false;
		this.FollowerSideRate = 0.0;
		this.LocalMovementConfirmTime = 0.0;
		this.FilteredMovementPathSpeed = 0.0;
		this.TimeSinceLastReversal = 1.5;
		this.LeaderCleanReversalThisFrame = false;
	}

	// Token: 0x06019DFD RID: 105981 RVA: 0x0079024C File Offset: 0x0078E44C
	public void Update(double deltaSeconds, CharacterActorComponent leader, CharacterActorComponent follower, ECharMoveState? leaderMoveState, bool useWalkFollowingRules, double rejoinEnterDistance, double rejoinExitDistance, double illegalDistance, FreeFollowingParams parameters)
	{
		if (!this.Initialized || this.LeaderEntityId != leader.Entity.Id)
		{
			this.Reset(leader, parameters.FollowOnRight);
		}
		double num = Math.Max(deltaSeconds, 0.0001);
		this.LastDeltaSeconds = num;
		if (useWalkFollowingRules != this.UseWalkFollowingRules)
		{
			this.StopConfirmTime = 0.0;
		}
		this.UseWalkFollowingRules = useWalkFollowingRules;
		this.ActiveFollowRadius = (useWalkFollowingRules ? parameters.WalkFollowRadius : parameters.FollowRadius);
		this.ActiveStartFollowingRadius = (useWalkFollowingRules ? parameters.WalkStartFollowingRadius : parameters.StartFollowingRadius);
		if (!this.UseWalkFollowingRules)
		{
			this.WalkBehindTargetPauseRemaining = 0.0;
			this.WalkBehindTargetPauseConsumed = false;
			this.ResetWalkArrivalHold();
		}
		else
		{
			this.WalkBehindTargetPauseRemaining = Math.Max(0.0, this.WalkBehindTargetPauseRemaining - num);
			this.WalkArrivalHoldRemaining = Math.Max(0.0, this.WalkArrivalHoldRemaining - num);
		}
		this.TargetDistance = double.NaN;
		this.IsTargetDistanceAccepted = false;
		if (this.IsDistanceFollowingActive && !this.HadValidTargetLastFrame)
		{
			this.StopConfirmTime = 0.0;
		}
		this.HadValidTargetLastFrame = false;
		this.FollowerRadius = Math.Sqrt(Singleton<GravityUtils>.Instance.GetDistSquared2dForActor(follower, follower.ActorLocationProxy, leader.ActorLocationProxy));
		this.RadialLag = Math.Max(0.0, this.FollowerRadius - this.ActiveFollowRadius);
		this.IsStopRadiusAccepted = (this.FollowerRadius <= this.ActiveFollowRadius + 1.0);
		if (this.UseWalkFollowingRules && !this.IsStopRadiusAccepted && this.WalkBehindTargetPauseRemaining <= 0.0)
		{
			this.WalkBehindTargetPauseConsumed = false;
		}
		if (!this.UseWalkFollowingRules && !this.IsStopRadiusAccepted)
		{
			this.StopConfirmTime = 0.0;
		}
		if (!this.IsStopRadiusAccepted || this.IsDistanceFollowingActive)
		{
			this.StopAngleError = double.NaN;
			this.IsStopAngleAccepted = false;
		}
		this.UpdateLeaderMotion(num, leader, leaderMoveState, illegalDistance, parameters);
		this.HoldForLocalMovement = (this.LocalMovementActive && this.IsStopRadiusAccepted);
		this.ReferenceForward.Multiply(this.ForwardOffset, this.PredictionCenter);
		this.PredictionCenter.AdditionEqual(leader.ActorLocationProxy);
		this.UpdateDistanceFollowingState();
		bool flag = this.WalkArrivalTargetValid && this.WalkArrivalHoldRemaining > 0.0;
		bool flag2 = this.IsWalkTemporaryPauseActive();
		if (!this.HoldForLocalMovement && !flag && !flag2)
		{
			this.UpdatePhysicalSide(leader, follower);
		}
		this.UpdateFollowState(num, this.RadialLag, rejoinEnterDistance, rejoinExitDistance);
	}

	// Token: 0x06019DFE RID: 105982 RVA: 0x007904FC File Offset: 0x0078E6FC
	public void CalculateTarget(Vector output, CharacterActorComponent leader, CharacterActorComponent follower, double angleOffset, FreeFollowingParams parameters)
	{
		switch (this.State)
		{
		case EFreeFollowingState.Rejoin:
			this.CalculateRejoinTarget(output, leader, follower, angleOffset, parameters);
			return;
		case EFreeFollowingState.Recover:
			this.CalculateRejoinTarget(this.RejoinTarget, leader, follower, angleOffset, parameters);
			this.CalculateFormationTarget(this.FormationTarget, leader, angleOffset, parameters);
			this.RejoinTarget.Multiply(1.0 - this.RecoverRate, output);
			this.FormationTarget.Multiply(this.RecoverRate, this.TempVector);
			output.AdditionEqual(this.TempVector);
			return;
		}
		this.CalculateFormationTarget(output, leader, angleOffset, parameters);
	}

	// Token: 0x06019DFF RID: 105983 RVA: 0x007905A8 File Offset: 0x0078E7A8
	public double GetCandidateSideScore(Vector candidate, CharacterActorComponent leader)
	{
		candidate.Subtraction(this.PredictionCenter, this.TempVector2);
		Vector.VectorPlaneProject(this.TempVector2, leader.ActorGravityDirectProxy, this.TempVector3);
		this.GetReferenceRight(leader, this.TempVector);
		return this.TempVector3.DotProduct(this.TempVector) * (double)this.CurrentSide;
	}

	// Token: 0x06019E00 RID: 105984 RVA: 0x00790605 File Offset: 0x0078E805
	public void CopyPredictionCenter(Vector output)
	{
		output.DeepCopy(this.PredictionCenter);
	}

	// Token: 0x06019E01 RID: 105985 RVA: 0x00790613 File Offset: 0x0078E813
	public bool IsWalkTemporaryPauseActive()
	{
		return this.WalkBehindTargetPauseRemaining > 0.0;
	}

	// Token: 0x06019E02 RID: 105986 RVA: 0x00790626 File Offset: 0x0078E826
	public bool ShouldHoldPosition()
	{
		return !this.IsDistanceFollowingActive || this.IsWalkTemporaryPauseActive();
	}

	// Token: 0x06019E03 RID: 105987 RVA: 0x00790638 File Offset: 0x0078E838
	public bool TryStopAtTarget(CharacterActorComponent leader, CharacterActorComponent follower, Vector selectedTarget, double targetTolerance, FreeFollowingParams parameters)
	{
		this.HadValidTargetLastFrame = true;
		this.TargetDistance = Math.Sqrt(Singleton<GravityUtils>.Instance.GetDistSquared2dForActor(follower, follower.ActorLocationProxy, selectedTarget));
		double num = Math.Max(0.0, targetTolerance);
		this.IsTargetDistanceAccepted = (this.TargetDistance <= num);
		if (!this.IsDistanceFollowingActive)
		{
			this.StopConfirmTime = 0.0;
			return false;
		}
		if (this.UseWalkFollowingRules)
		{
			this.StopAngleError = double.NaN;
			this.IsStopAngleAccepted = false;
			if (this.TryHoldAfterWalkArrival(follower, selectedTarget, num * 2.0))
			{
				return true;
			}
			if (this.TryPauseForWalkBehindTarget(leader, follower, selectedTarget, parameters))
			{
				return true;
			}
			if (!this.IsTargetDistanceAccepted)
			{
				this.StopConfirmTime = 0.0;
				return false;
			}
			if (!this.UpdateStopConfirmation(parameters))
			{
				return false;
			}
			this.StartWalkArrivalHold(selectedTarget);
			return true;
		}
		else
		{
			if (this.LeaderIsMoving)
			{
				this.StopConfirmTime = 0.0;
				return false;
			}
			if (!this.IsStopRadiusAccepted)
			{
				this.StopConfirmTime = 0.0;
				return false;
			}
			selectedTarget.Subtraction(this.PredictionCenter, this.TempVector);
			Vector.VectorPlaneProject(this.TempVector, leader.ActorGravityDirectProxy, this.TempVector2);
			follower.ActorLocationProxy.Subtraction(leader.ActorLocationProxy, this.TempVector3);
			Vector.VectorPlaneProject(this.TempVector3, leader.ActorGravityDirectProxy, this.TempVector4);
			if (!this.TempVector2.Normalize(9.99999993922529E-09) || !this.TempVector4.Normalize(9.99999993922529E-09))
			{
				this.StopAngleError = double.NaN;
				this.IsStopAngleAccepted = false;
				this.StopConfirmTime = 0.0;
				return false;
			}
			double d = Singleton<MathUtils>.Instance.Clamp(this.TempVector2.DotProduct(this.TempVector4), -1.0, 1.0);
			this.StopAngleError = Math.Acos(d) * 57.295780181884766;
			this.IsStopAngleAccepted = (this.StopAngleError <= parameters.SideAngleTolerance);
			if (!this.IsStopAngleAccepted)
			{
				this.StopConfirmTime = 0.0;
				return false;
			}
			if (!this.UpdateStopConfirmation(parameters))
			{
				return false;
			}
			this.IsDistanceFollowingActive = false;
			this.OuterRingGateArmed = true;
			this.State = EFreeFollowingState.Stable;
			this.RejoinDuration = 0.0;
			this.RecoverRate = 0.0;
			return true;
		}
	}

	// Token: 0x06019E04 RID: 105988 RVA: 0x007908AA File Offset: 0x0078EAAA
	private bool UpdateStopConfirmation(FreeFollowingParams parameters)
	{
		this.StopConfirmTime = Math.Min(parameters.StopConfirmTime, this.StopConfirmTime + this.LastDeltaSeconds);
		return this.StopConfirmTime >= parameters.StopConfirmTime;
	}

	// Token: 0x06019E05 RID: 105989 RVA: 0x007908DB File Offset: 0x0078EADB
	private void StartWalkArrivalHold(Vector selectedTarget)
	{
		this.WalkArrivalTarget.DeepCopy(selectedTarget);
		this.WalkArrivalTargetValid = true;
		this.WalkArrivalHoldRemaining = 0.3;
		this.StopConfirmTime = 0.0;
	}

	// Token: 0x06019E06 RID: 105990 RVA: 0x00790910 File Offset: 0x0078EB10
	private bool TryHoldAfterWalkArrival(CharacterActorComponent follower, Vector selectedTarget, double targetMoveTolerance)
	{
		if (!this.WalkArrivalTargetValid)
		{
			return false;
		}
		if (Singleton<GravityUtils>.Instance.GetDistSquared2dForActor(follower, selectedTarget, this.WalkArrivalTarget) > targetMoveTolerance * targetMoveTolerance)
		{
			this.ResetWalkArrivalHold();
			return false;
		}
		this.StopConfirmTime = 0.0;
		if (this.WalkArrivalHoldRemaining > 0.0)
		{
			return true;
		}
		if (this.LeaderIsMoving)
		{
			this.ResetWalkArrivalHold();
			return false;
		}
		this.ResetWalkArrivalHold();
		this.IsDistanceFollowingActive = false;
		this.OuterRingGateArmed = true;
		this.State = EFreeFollowingState.Stable;
		this.RejoinDuration = 0.0;
		this.RecoverRate = 0.0;
		return true;
	}

	// Token: 0x06019E07 RID: 105991 RVA: 0x007909B2 File Offset: 0x0078EBB2
	private void ResetWalkArrivalHold()
	{
		this.WalkArrivalTargetValid = false;
		this.WalkArrivalHoldRemaining = 0.0;
	}

	// Token: 0x06019E08 RID: 105992 RVA: 0x007909CC File Offset: 0x0078EBCC
	private bool TryPauseForWalkBehindTarget(CharacterActorComponent leader, CharacterActorComponent follower, Vector selectedTarget, FreeFollowingParams parameters)
	{
		selectedTarget.Subtraction(follower.ActorLocationProxy, this.TempVector);
		Vector.VectorPlaneProject(this.TempVector, leader.ActorGravityDirectProxy, this.TempVector2);
		Vector.VectorPlaneProject(follower.ActorForwardProxy, leader.ActorGravityDirectProxy, this.TempVector3);
		if (!this.TempVector2.Normalize(9.99999993922529E-09) || !this.TempVector3.Normalize(9.99999993922529E-09))
		{
			return false;
		}
		double num = Math.Acos(Singleton<MathUtils>.Instance.Clamp(this.TempVector2.DotProduct(this.TempVector3), -1.0, 1.0)) * 57.295780181884766;
		if (!this.IsStopRadiusAccepted)
		{
			this.WalkBehindTargetPauseConsumed = false;
			return false;
		}
		if (num <= 80.0)
		{
			this.WalkBehindTargetPauseConsumed = false;
		}
		if (this.IsTargetDistanceAccepted || num < 100.0 || this.WalkBehindTargetPauseConsumed)
		{
			return false;
		}
		this.WalkBehindTargetPauseRemaining = parameters.WalkBehindTargetPauseTime;
		this.WalkBehindTargetPauseConsumed = true;
		this.StopConfirmTime = 0.0;
		return true;
	}

	// Token: 0x06019E09 RID: 105993 RVA: 0x00790AEC File Offset: 0x0078ECEC
	private void UpdateLeaderMotion(double deltaSeconds, CharacterActorComponent leader, ECharMoveState? leaderMoveState, double illegalDistance, FreeFollowingParams parameters)
	{
		double num = this.CalculateLeaderMoveDirection(leader);
		double num2 = Math.Max(0.0, Math.Max(illegalDistance, this.ActiveStartFollowingRadius * 2.0));
		bool leaderMoveDiscontinuity = num > num2;
		double num3 = num / deltaSeconds;
		this.UpdateLeaderSpeedAndAcceleration(deltaSeconds, num3, leaderMoveDiscontinuity);
		this.UpdateMovementIntent(deltaSeconds, num3, leaderMoveDiscontinuity, parameters);
		this.UpdateForwardOffset(deltaSeconds, parameters);
		this.UpdateReferenceForward(deltaSeconds, leader, leaderMoveState, num3, leaderMoveDiscontinuity, parameters);
		this.LastLeaderLocation.DeepCopy(leader.ActorLocationProxy);
	}

	// Token: 0x06019E0A RID: 105994 RVA: 0x00790B6C File Offset: 0x0078ED6C
	private void UpdateLeaderSpeedAndAcceleration(double deltaSeconds, double actualLeaderSpeed, bool leaderMoveDiscontinuity)
	{
		double num = (!leaderMoveDiscontinuity && actualLeaderSpeed >= 30.0) ? actualLeaderSpeed : 0.0;
		this.LeaderIsMoving = (num > 0.0);
		this.LeaderIsStand = !this.LeaderIsMoving;
		double filteredLeaderSpeed = this.FilteredLeaderSpeed;
		double exponentialAlpha = this.GetExponentialAlpha(deltaSeconds, 0.2);
		this.FilteredLeaderSpeed += (num - this.FilteredLeaderSpeed) * exponentialAlpha;
		double num2 = (this.FilteredLeaderSpeed - filteredLeaderSpeed) / deltaSeconds;
		double exponentialAlpha2 = this.GetExponentialAlpha(deltaSeconds, 0.12);
		this.FilteredLeaderAcceleration += (num2 - this.FilteredLeaderAcceleration) * exponentialAlpha2;
		this.FilteredLeaderAcceleration = Singleton<MathUtils>.Instance.Clamp(this.FilteredLeaderAcceleration, -1200.0, 1200.0);
	}

	// Token: 0x06019E0B RID: 105995 RVA: 0x00790C44 File Offset: 0x0078EE44
	private double CalculateLeaderMoveDirection(CharacterActorComponent leader)
	{
		leader.ActorLocationProxy.Subtraction(this.LastLeaderLocation, this.TempVector);
		Vector.VectorPlaneProject(this.TempVector, leader.ActorGravityDirectProxy, this.LeaderMoveDirection);
		double num = this.LeaderMoveDirection.Size();
		if (num > 0.0)
		{
			this.LeaderMoveDirection.MultiplyEqual(1.0 / num);
		}
		return num;
	}

	// Token: 0x06019E0C RID: 105996 RVA: 0x00790CB0 File Offset: 0x0078EEB0
	private void UpdateForwardOffset(double deltaSeconds, FreeFollowingParams parameters)
	{
		double num = this.LocalMovementActive ? 0.0 : Math.Max(0.0, this.FilteredLeaderSpeed + this.FilteredLeaderAcceleration * 0.18);
		double num2 = Singleton<MathUtils>.Instance.Clamp(num / parameters.FullForwardOffsetSpeed, 0.0, 1.0);
		double num3 = num2 * num2 * (3.0 - 2.0 * num2);
		double num4 = parameters.MaxForwardOffset * num3;
		double exponentialAlpha = this.GetExponentialAlpha(deltaSeconds, 0.25);
		this.ForwardOffset += (num4 - this.ForwardOffset) * exponentialAlpha;
	}

	// Token: 0x06019E0D RID: 105997 RVA: 0x00790D68 File Offset: 0x0078EF68
	private void UpdateReferenceForward(double deltaSeconds, CharacterActorComponent leader, ECharMoveState? leaderMoveState, double directionUpdateSpeed, bool leaderMoveDiscontinuity, FreeFollowingParams parameters)
	{
		if (this.LeaderCleanReversalThisFrame && !this.LocalMovementActive)
		{
			this.ReferenceForward.DeepCopy(this.LeaderMoveDirection);
			this.StopConfirmTime = 0.0;
			return;
		}
		Vector vector = this.LeaderMoveDirection;
		double num = directionUpdateSpeed;
		if (this.UseWalkFollowingRules)
		{
			num = this.FilteredMovementIntentVelocity.Size();
			if (num >= 30.0)
			{
				this.FilteredMovementIntentVelocity.Multiply(1.0 / num, this.TempVector3);
				vector = this.TempVector3;
			}
		}
		if (this.LeaderIsMoving && !this.LocalMovementActive && !leaderMoveDiscontinuity && num >= 30.0)
		{
			double num2 = (double)Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityForActor(leader, this.ReferenceForward, vector);
			if (Math.Abs(num2) >= 135.0)
			{
				this.ReferenceForward.DeepCopy(vector);
				this.StopConfirmTime = 0.0;
				return;
			}
			if (this.UseWalkFollowingRules)
			{
				double num3 = 180.0 * deltaSeconds;
				double angleDeg = Singleton<MathUtils>.Instance.Clamp(num2, -num3, num3);
				this.ReferenceForward.RotateAngleAxis(angleDeg, leader.ActorUpProxy, this.TempVector2);
				if (this.TempVector2.Normalize(9.99999993922529E-09))
				{
					this.ReferenceForward.DeepCopy(this.TempVector2);
					return;
				}
			}
			else if (Math.Abs(num2) > 3.0)
			{
				double smoothingTimeSeconds = (leaderMoveState.GetValueOrDefault() == ECharMoveState.Sprint) ? parameters.SprintReferenceDirectionSmoothingTime : parameters.RunReferenceDirectionSmoothingTime;
				double exponentialAlpha = this.GetExponentialAlpha(deltaSeconds, smoothingTimeSeconds);
				Vector.Lerp(this.ReferenceForward, vector, exponentialAlpha, this.TempVector2);
				if (this.TempVector2.Normalize(9.99999993922529E-09))
				{
					this.ReferenceForward.DeepCopy(this.TempVector2);
					return;
				}
				this.ReferenceForward.DeepCopy(vector);
			}
		}
	}

	// Token: 0x06019E0E RID: 105998 RVA: 0x00790F48 File Offset: 0x0078F148
	private void UpdateMovementIntent(double deltaSeconds, double directionUpdateSpeed, bool leaderMoveDiscontinuity, FreeFollowingParams parameters)
	{
		this.LeaderCleanReversalThisFrame = false;
		if (!this.LeaderIsMoving || leaderMoveDiscontinuity)
		{
			this.ResetMovementIntent();
			return;
		}
		this.TimeSinceLastReversal = Math.Min(1.5, this.TimeSinceLastReversal + deltaSeconds);
		double num = this.FilteredMovementIntentVelocity.Size();
		if (directionUpdateSpeed >= 60.0 && num >= 60.0 && this.FilteredMovementIntentVelocity.DotProduct(this.LeaderMoveDirection) / num <= -0.7071067811865476)
		{
			if (this.TimeSinceLastReversal >= 1.5)
			{
				this.LeaderCleanReversalThisFrame = true;
				this.LeaderMoveDirection.Multiply(directionUpdateSpeed, this.FilteredMovementIntentVelocity);
				this.FilteredMovementPathSpeed = directionUpdateSpeed;
				this.MovementIntentRate = 1.0;
				this.LocalMovementConfirmTime = 0.0;
			}
			this.TimeSinceLastReversal = 0.0;
		}
		double exponentialAlpha = this.GetExponentialAlpha(deltaSeconds, parameters.MovementIntentSmoothingTime);
		this.LeaderMoveDirection.Multiply(directionUpdateSpeed, this.TempVector3);
		this.FilteredMovementIntentVelocity.MultiplyEqual(1.0 - exponentialAlpha);
		this.TempVector3.MultiplyEqual(exponentialAlpha);
		this.FilteredMovementIntentVelocity.AdditionEqual(this.TempVector3);
		this.FilteredMovementPathSpeed += (directionUpdateSpeed - this.FilteredMovementPathSpeed) * exponentialAlpha;
		if (this.FilteredMovementPathSpeed < 30.0)
		{
			this.MovementIntentRate = 1.0;
			this.LocalMovementActive = false;
			this.HoldForLocalMovement = false;
			this.LocalMovementConfirmTime = 0.0;
			return;
		}
		this.MovementIntentRate = Singleton<MathUtils>.Instance.Clamp(this.FilteredMovementIntentVelocity.Size() / this.FilteredMovementPathSpeed, 0.0, 1.0);
		if (!parameters.EnableLocalMovementHold)
		{
			this.LocalMovementActive = false;
			this.HoldForLocalMovement = false;
			this.LocalMovementConfirmTime = 0.0;
			return;
		}
		if (!(this.LocalMovementActive ? (this.MovementIntentRate >= 0.7) : (this.MovementIntentRate <= parameters.LocalMovementEnterRate)))
		{
			this.LocalMovementConfirmTime = 0.0;
			return;
		}
		double num2 = this.LocalMovementActive ? 0.2 : parameters.LocalMovementEnterConfirmTime;
		this.LocalMovementConfirmTime = Math.Min(num2, this.LocalMovementConfirmTime + deltaSeconds);
		if (this.LocalMovementConfirmTime >= num2)
		{
			this.LocalMovementActive = !this.LocalMovementActive;
			this.LocalMovementConfirmTime = 0.0;
			this.StopConfirmTime = 0.0;
		}
	}

	// Token: 0x06019E0F RID: 105999 RVA: 0x007911E0 File Offset: 0x0078F3E0
	private void ResetMovementIntent()
	{
		this.FilteredMovementIntentVelocity.Reset();
		this.FilteredMovementPathSpeed = 0.0;
		this.MovementIntentRate = 1.0;
		this.LocalMovementActive = false;
		this.HoldForLocalMovement = false;
		this.LocalMovementConfirmTime = 0.0;
		this.TimeSinceLastReversal = 1.5;
	}

	// Token: 0x06019E10 RID: 106000 RVA: 0x00791244 File Offset: 0x0078F444
	private void UpdateDistanceFollowingState()
	{
		if (this.HoldForLocalMovement)
		{
			this.ResetWalkArrivalHold();
			this.OuterRingGateArmed = true;
			this.IsDistanceFollowingActive = false;
			this.StopConfirmTime = 0.0;
			this.State = EFreeFollowingState.Stable;
			return;
		}
		if (this.LeaderIsStand)
		{
			this.OuterRingGateArmed = true;
		}
		if (this.IsDistanceFollowingActive)
		{
			return;
		}
		if (this.FollowerRadius > this.ActiveStartFollowingRadius + 1.0)
		{
			this.OuterRingGateArmed = false;
		}
		else if (this.OuterRingGateArmed)
		{
			this.State = EFreeFollowingState.Stable;
			return;
		}
		this.IsDistanceFollowingActive = true;
		this.StopConfirmTime = 0.0;
		this.State = EFreeFollowingState.FormationFollow;
	}

	// Token: 0x06019E11 RID: 106001 RVA: 0x007912EC File Offset: 0x0078F4EC
	private void UpdateFollowState(double deltaSeconds, double radialLag, double rejoinEnterDistance, double rejoinExitDistance)
	{
		if (!this.IsDistanceFollowingActive)
		{
			this.State = EFreeFollowingState.Stable;
			return;
		}
		if (this.UseWalkFollowingRules)
		{
			this.State = EFreeFollowingState.FormationFollow;
			this.RejoinDuration = 0.0;
			this.RecoverRate = 0.0;
			return;
		}
		double num = Math.Max(rejoinEnterDistance, rejoinExitDistance);
		double num2 = Math.Min(rejoinEnterDistance, rejoinExitDistance);
		if (radialLag > num)
		{
			if (this.State != EFreeFollowingState.Rejoin)
			{
				this.State = EFreeFollowingState.Rejoin;
				this.RejoinDuration = 0.0;
				this.RecoverRate = 0.0;
			}
			this.RejoinDuration += deltaSeconds;
			return;
		}
		if (this.State == EFreeFollowingState.Rejoin)
		{
			this.RejoinDuration += deltaSeconds;
			if (radialLag <= num2 && this.RejoinDuration >= 0.3)
			{
				this.State = EFreeFollowingState.Recover;
				this.RecoverRate = 0.0;
			}
			return;
		}
		if (this.State == EFreeFollowingState.Recover)
		{
			this.RecoverRate = Math.Min(1.0, this.RecoverRate + deltaSeconds / 0.4);
			if (this.RecoverRate >= 1.0)
			{
				this.State = EFreeFollowingState.FormationFollow;
			}
			return;
		}
		if (this.State == EFreeFollowingState.Stable)
		{
			this.State = EFreeFollowingState.FormationFollow;
		}
	}

	// Token: 0x06019E12 RID: 106002 RVA: 0x00791424 File Offset: 0x0078F624
	private void CalculateFormationTarget(Vector output, CharacterActorComponent leader, double angleOffset, FreeFollowingParams parameters)
	{
		this.CalculateFormationDirection(this.TempVector2, leader, angleOffset, parameters);
		this.BuildTargetFromDirection(output, leader, this.TempVector2);
	}

	// Token: 0x06019E13 RID: 106003 RVA: 0x00791444 File Offset: 0x0078F644
	private void CalculateFormationDirection(Vector output, CharacterActorComponent leader, double angleOffset, FreeFollowingParams parameters)
	{
		this.ReferenceForward.RotateAngleAxis(angleOffset, leader.ActorUpProxy, output);
		if (!output.Normalize(9.99999993922529E-09))
		{
			output.DeepCopy(this.ReferenceForward);
		}
		leader.ActorUpProxy.CrossProduct(output, this.TempVector4);
		if (!this.TempVector4.Normalize(9.99999993922529E-09))
		{
			this.TempVector4.DeepCopy(leader.ActorRightProxy);
		}
		double num = parameters.OffsetAngle * 0.01745329238474369;
		output.MultiplyEqual(Math.Sin(num));
		this.TempVector4.MultiplyEqual(Math.Cos(num) * (double)this.CurrentSide);
		output.AdditionEqual(this.TempVector4);
		output.Normalize(9.99999993922529E-09);
	}

	// Token: 0x06019E14 RID: 106004 RVA: 0x00791510 File Offset: 0x0078F710
	private void CalculateRejoinTarget(Vector output, CharacterActorComponent leader, CharacterActorComponent follower, double angleOffset, FreeFollowingParams parameters)
	{
		follower.ActorLocationProxy.Subtraction(this.PredictionCenter, this.TempVector2);
		Vector.VectorPlaneProject(this.TempVector2, leader.ActorGravityDirectProxy, this.TempVector);
		this.TempVector2.DeepCopy(this.TempVector);
		this.GetReferenceRight(leader, this.TempVector3);
		if (!this.TempVector2.Normalize(9.99999993922529E-09) || this.TempVector2.DotProduct(this.TempVector3) * (double)this.CurrentSide <= 0.01)
		{
			this.CalculateFormationTarget(output, leader, angleOffset, parameters);
			return;
		}
		if (this.TempVector2.DotProduct(this.ReferenceForward) < 0.0)
		{
			this.TempVector3.Multiply((double)this.CurrentSide, this.TempVector2);
		}
		this.TempVector2.RotateAngleAxis(angleOffset, leader.ActorUpProxy, this.TempVector4);
		this.BuildTargetFromDirection(output, leader, this.TempVector4);
	}

	// Token: 0x06019E15 RID: 106005 RVA: 0x0079160D File Offset: 0x0078F80D
	private void BuildTargetFromDirection(Vector output, CharacterActorComponent leader, Vector direction)
	{
		direction.Multiply(this.ActiveFollowRadius, output);
		output.AdditionEqual(this.PredictionCenter);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(leader, output, (double)(-(double)leader.ScaledHalfHeight));
	}

	// Token: 0x06019E16 RID: 106006 RVA: 0x00791640 File Offset: 0x0078F840
	private void UpdatePhysicalSide(CharacterActorComponent leader, CharacterActorComponent follower)
	{
		follower.ActorLocationProxy.Subtraction(this.PredictionCenter, this.TempVector2);
		Vector.VectorPlaneProject(this.TempVector2, leader.ActorGravityDirectProxy, this.TempVector3);
		if (!this.TempVector3.Normalize(9.99999993922529E-09))
		{
			this.FollowerSideRate = 0.0;
			return;
		}
		this.GetReferenceRight(leader, this.TempVector);
		this.FollowerSideRate = Singleton<MathUtils>.Instance.Clamp(this.TempVector3.DotProduct(this.TempVector), -1.0, 1.0);
		EFreeFollowingSide efreeFollowingSide = (this.FollowerSideRate > 0.0) ? EFreeFollowingSide.Right : EFreeFollowingSide.Left;
		double num = this.UseWalkFollowingRules ? 0.052335956242943835 : 0.25881904510252074;
		if (efreeFollowingSide == this.CurrentSide || Math.Abs(this.FollowerSideRate) < num)
		{
			return;
		}
		this.CurrentSide = efreeFollowingSide;
		this.StopConfirmTime = 0.0;
	}

	// Token: 0x06019E17 RID: 106007 RVA: 0x00791743 File Offset: 0x0078F943
	private void GetReferenceRight(CharacterActorComponent leader, Vector output)
	{
		leader.ActorUpProxy.CrossProduct(this.ReferenceForward, output);
		if (!output.Normalize(9.99999993922529E-09))
		{
			output.DeepCopy(leader.ActorRightProxy);
		}
	}

	// Token: 0x06019E18 RID: 106008 RVA: 0x00791774 File Offset: 0x0078F974
	private double GetExponentialAlpha(double deltaSeconds, double smoothingTimeSeconds)
	{
		if (smoothingTimeSeconds > 0.0)
		{
			return 1.0 - Math.Exp(-deltaSeconds / smoothingTimeSeconds);
		}
		return 1.0;
	}

	// Token: 0x0400CF49 RID: 53065
	private readonly Vector TempVector = Vector.Create();

	// Token: 0x0400CF4A RID: 53066
	private readonly Vector TempVector2 = Vector.Create();

	// Token: 0x0400CF4B RID: 53067
	private readonly Vector TempVector3 = Vector.Create();

	// Token: 0x0400CF4C RID: 53068
	private readonly Vector TempVector4 = Vector.Create();

	// Token: 0x0400CF4D RID: 53069
	private bool Initialized;

	// Token: 0x0400CF4E RID: 53070
	private int LeaderEntityId;

	// Token: 0x0400CF4F RID: 53071
	public double FollowerRadius;

	// Token: 0x0400CF50 RID: 53072
	public double ActiveFollowRadius;

	// Token: 0x0400CF51 RID: 53073
	public double ActiveStartFollowingRadius;

	// Token: 0x0400CF52 RID: 53074
	public bool IsStopRadiusAccepted;

	// Token: 0x0400CF53 RID: 53075
	public bool UseWalkFollowingRules;

	// Token: 0x0400CF54 RID: 53076
	public double StopAngleError = double.NaN;

	// Token: 0x0400CF55 RID: 53077
	public bool IsStopAngleAccepted;

	// Token: 0x0400CF56 RID: 53078
	public double TargetDistance = double.NaN;

	// Token: 0x0400CF57 RID: 53079
	public bool IsTargetDistanceAccepted;

	// Token: 0x0400CF58 RID: 53080
	public double StopConfirmTime;

	// Token: 0x0400CF59 RID: 53081
	private double LastDeltaSeconds;

	// Token: 0x0400CF5A RID: 53082
	private bool HadValidTargetLastFrame;

	// Token: 0x0400CF5B RID: 53083
	private readonly Vector WalkArrivalTarget = Vector.Create();

	// Token: 0x0400CF5C RID: 53084
	private bool WalkArrivalTargetValid;

	// Token: 0x0400CF5D RID: 53085
	private double WalkArrivalHoldRemaining;

	// Token: 0x0400CF5E RID: 53086
	public double WalkBehindTargetPauseRemaining;

	// Token: 0x0400CF5F RID: 53087
	public bool WalkBehindTargetPauseConsumed;

	// Token: 0x0400CF60 RID: 53088
	public readonly Vector ReferenceForward = Vector.Create();

	// Token: 0x0400CF61 RID: 53089
	private readonly Vector LastLeaderLocation = Vector.Create();

	// Token: 0x0400CF62 RID: 53090
	private readonly Vector LeaderMoveDirection = Vector.Create();

	// Token: 0x0400CF63 RID: 53091
	private readonly Vector PredictionCenter = Vector.Create();

	// Token: 0x0400CF64 RID: 53092
	public double FilteredLeaderSpeed;

	// Token: 0x0400CF65 RID: 53093
	private double FilteredLeaderAcceleration;

	// Token: 0x0400CF66 RID: 53094
	public double ForwardOffset;

	// Token: 0x0400CF67 RID: 53095
	public bool LeaderIsMoving;

	// Token: 0x0400CF68 RID: 53096
	public bool LeaderIsStand;

	// Token: 0x0400CF69 RID: 53097
	private readonly Vector FilteredMovementIntentVelocity = Vector.Create();

	// Token: 0x0400CF6A RID: 53098
	public double MovementIntentRate = 1.0;

	// Token: 0x0400CF6B RID: 53099
	public bool LocalMovementActive;

	// Token: 0x0400CF6C RID: 53100
	public bool HoldForLocalMovement;

	// Token: 0x0400CF6D RID: 53101
	private double LocalMovementConfirmTime;

	// Token: 0x0400CF6E RID: 53102
	private double FilteredMovementPathSpeed;

	// Token: 0x0400CF6F RID: 53103
	private double TimeSinceLastReversal = 1.5;

	// Token: 0x0400CF70 RID: 53104
	private bool LeaderCleanReversalThisFrame;

	// Token: 0x0400CF71 RID: 53105
	public EFreeFollowingState State;

	// Token: 0x0400CF72 RID: 53106
	private double RadialLag;

	// Token: 0x0400CF73 RID: 53107
	public bool IsDistanceFollowingActive;

	// Token: 0x0400CF74 RID: 53108
	public bool OuterRingGateArmed;

	// Token: 0x0400CF75 RID: 53109
	private double RejoinDuration;

	// Token: 0x0400CF76 RID: 53110
	private double RecoverRate;

	// Token: 0x0400CF77 RID: 53111
	private readonly Vector FormationTarget = Vector.Create();

	// Token: 0x0400CF78 RID: 53112
	private readonly Vector RejoinTarget = Vector.Create();

	// Token: 0x0400CF79 RID: 53113
	public EFreeFollowingSide CurrentSide = EFreeFollowingSide.Right;

	// Token: 0x0400CF7A RID: 53114
	public double FollowerSideRate;
}
