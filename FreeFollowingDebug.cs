using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x020030E9 RID: 12521
[NullableContext(1)]
[Nullable(0)]
public class FreeFollowingDebug
{
	// Token: 0x06019E1A RID: 106010 RVA: 0x0079187A File Offset: 0x0078FA7A
	public void Reset(FreeFollowingRuntime runtime)
	{
		this.LastState = runtime.State;
		this.LastSide = runtime.CurrentSide;
		this.LastSummaryLogTime = 0.0;
		this.LastTargetFound = true;
	}

	// Token: 0x06019E1B RID: 106011 RVA: 0x007918AA File Offset: 0x0078FAAA
	public void RecordTargetResult(bool found, FreeFollowingRuntime runtime)
	{
		if (!found)
		{
			bool lastTargetFound = this.LastTargetFound;
		}
		this.LastTargetFound = found;
	}

	// Token: 0x06019E1C RID: 106012 RVA: 0x007918BD File Offset: 0x0078FABD
	public void LogWalkTemporaryPause(FreeFollowingRuntime runtime)
	{
	}

	// Token: 0x06019E1D RID: 106013 RVA: 0x007918BF File Offset: 0x0078FABF
	public void DrawCandidate(Vector candidate, bool valid)
	{
		FreeFollowingDebug.DrawSphere(candidate, valid ? ColorUtils.LinearWhite : ColorUtils.LinearRed);
	}

	// Token: 0x06019E1E RID: 106014 RVA: 0x007918D8 File Offset: 0x0078FAD8
	public void Draw(FreeFollowingRuntime runtime, CharacterActorComponent leader, CharacterActorComponent follower, ECharMoveState? leaderMoveState, ECharMoveState followerMoveState, double followerSpeed, FreeFollowingParams parameters, [Nullable(2)] Vector selectedTarget = null)
	{
		EFreeFollowingState state = runtime.State;
		EFreeFollowingSide currentSide = runtime.CurrentSide;
		double followerRadius = runtime.FollowerRadius;
		if (followerRadius > runtime.ActiveFollowRadius)
		{
			double activeStartFollowingRadius = runtime.ActiveStartFollowingRadius;
		}
		if (state != this.LastState)
		{
			this.LastState = state;
		}
		if (currentSide != this.LastSide)
		{
			this.LastSide = currentSide;
		}
		double now = Singleton<Time>.Instance.Now;
		if (now - this.LastSummaryLogTime >= 2000.0)
		{
			if (!double.IsNaN(runtime.TargetDistance))
			{
				runtime.TargetDistance.ToString("F1");
			}
			if (!runtime.HoldForLocalMovement)
			{
				bool localMovementActive = runtime.LocalMovementActive;
			}
			this.LastSummaryLogTime = now;
		}
		if (selectedTarget != null)
		{
			this.Target.DeepCopy(selectedTarget);
		}
		else
		{
			runtime.CalculateTarget(this.Target, leader, follower, 0.0, parameters);
		}
		FreeFollowingDebug.DrawSphere(this.Target, runtime.IsWalkTemporaryPauseActive() ? ColorUtils.LinearRed : ((runtime.IsDistanceFollowingActive && runtime.StopConfirmTime > 0.0) ? ColorUtils.LinearYellow : ColorUtils.LinearGreen));
		if (runtime.IsWalkTemporaryPauseActive())
		{
			FreeFollowingDebug.DrawLine(follower.ActorLocationProxy, this.Target, ColorUtils.LinearRed);
		}
		runtime.CopyPredictionCenter(this.CacheVector);
		FreeFollowingDebug.DrawSphere(this.CacheVector, ColorUtils.LinearCyan);
		UKismetSystemLibrary.D_DrawDebugCircle(GlobalData.World, this.CacheVector.ToUeVector(false), (float)runtime.ActiveFollowRadius, 30, new FLinearColor?(ColorUtils.LinearCyan), 0f, 2f, new FVectorDouble?(leader.ActorForwardProxy.ToUeVector(false)), new FVectorDouble?(leader.ActorRightProxy.ToUeVector(false)), true);
		FreeFollowingDebug.DrawLine(leader.ActorLocationProxy, this.CacheVector, ColorUtils.LinearCyan);
		double inB = Math.Max(100.0, runtime.ActiveFollowRadius);
		leader.ActorForwardProxy.Multiply(inB, this.CacheVector2);
		this.CacheVector2.AdditionEqual(leader.ActorLocationProxy);
		FreeFollowingDebug.DrawArrow(leader.ActorLocationProxy, this.CacheVector2, ColorUtils.LinearRed);
		runtime.ReferenceForward.Multiply(inB, this.TempVector2);
		this.TempVector2.AdditionEqual(leader.ActorLocationProxy);
		FreeFollowingDebug.DrawArrow(leader.ActorLocationProxy, this.TempVector2, ColorUtils.LinearBlue);
		if (runtime.UseWalkFollowingRules)
		{
			this.Target.Subtraction(leader.ActorLocationProxy, this.CacheVector2);
		}
		else
		{
			this.Target.Subtraction(this.CacheVector, this.CacheVector2);
		}
		Vector.VectorPlaneProject(this.CacheVector2, leader.ActorGravityDirectProxy, this.TempVector);
		if (this.TempVector.Normalize(9.99999993922529E-09))
		{
			double minDistance = runtime.UseWalkFollowingRules ? runtime.ActiveFollowRadius : 0.0;
			double maxDistance = runtime.UseWalkFollowingRules ? runtime.ActiveStartFollowingRadius : runtime.ActiveFollowRadius;
			this.DrawSectorLine(leader, this.TempVector, minDistance, maxDistance, ColorUtils.LinearGreen);
			this.TempVector.RotateAngleAxis(-parameters.SideAngleTolerance, leader.ActorUpProxy, this.TempVector2);
			this.DrawSectorLine(leader, this.TempVector2, minDistance, maxDistance, ColorUtils.LinearWhite);
			this.TempVector.RotateAngleAxis(parameters.SideAngleTolerance, leader.ActorUpProxy, this.TempVector2);
			this.DrawSectorLine(leader, this.TempVector2, minDistance, maxDistance, ColorUtils.LinearWhite);
		}
		FreeFollowingDebug.DrawCircle(leader, runtime.ActiveFollowRadius, ColorUtils.LinearGreen);
		FreeFollowingDebug.DrawCircle(leader, runtime.ActiveStartFollowingRadius, ColorUtils.LinearYellow);
	}

	// Token: 0x06019E1F RID: 106015 RVA: 0x00791C5C File Offset: 0x0078FE5C
	private void DrawSectorLine(CharacterActorComponent leader, Vector direction, double minDistance, double maxDistance, FLinearColor color)
	{
		direction.Multiply(minDistance, this.CacheVector);
		this.CacheVector.AdditionEqual(leader.ActorLocationProxy);
		direction.Multiply(maxDistance, this.CacheVector2);
		this.CacheVector2.AdditionEqual(leader.ActorLocationProxy);
		FreeFollowingDebug.DrawLine(this.CacheVector, this.CacheVector2, color);
	}

	// Token: 0x06019E20 RID: 106016 RVA: 0x00791CBD File Offset: 0x0078FEBD
	private static void DrawSphere(Vector point, FLinearColor color)
	{
		UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, point.ToUeVector(false), 20f, 10, new FLinearColor?(color), 0f, 0f);
	}

	// Token: 0x06019E21 RID: 106017 RVA: 0x00791CE7 File Offset: 0x0078FEE7
	private static void DrawLine(Vector from, Vector to, FLinearColor color)
	{
		UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, from.ToUeVector(false), to.ToUeVector(false), color, 0f, 0f);
	}

	// Token: 0x06019E22 RID: 106018 RVA: 0x00791D0C File Offset: 0x0078FF0C
	private static void DrawArrow(Vector from, Vector to, FLinearColor color)
	{
		UKismetSystemLibrary.D_DrawDebugArrow(GlobalData.World, from.ToUeVector(false), to.ToUeVector(false), 30f, color, 0f, 2f);
	}

	// Token: 0x06019E23 RID: 106019 RVA: 0x00791D38 File Offset: 0x0078FF38
	private static void DrawCircle(CharacterActorComponent leader, double radius, FLinearColor color)
	{
		UKismetSystemLibrary.D_DrawDebugCircle(GlobalData.World, leader.ActorLocationProxy.ToUeVector(false), (float)radius, 30, new FLinearColor?(color), 0f, 2f, new FVectorDouble?(leader.ActorForwardProxy.ToUeVector(false)), new FVectorDouble?(leader.ActorRightProxy.ToUeVector(false)), true);
	}

	// Token: 0x0400CF7B RID: 53115
	private readonly Vector Target = Vector.Create();

	// Token: 0x0400CF7C RID: 53116
	private readonly Vector CacheVector = Vector.Create();

	// Token: 0x0400CF7D RID: 53117
	private readonly Vector CacheVector2 = Vector.Create();

	// Token: 0x0400CF7E RID: 53118
	private readonly Vector TempVector = Vector.Create();

	// Token: 0x0400CF7F RID: 53119
	private readonly Vector TempVector2 = Vector.Create();

	// Token: 0x0400CF80 RID: 53120
	private EFreeFollowingState LastState;

	// Token: 0x0400CF81 RID: 53121
	private EFreeFollowingSide LastSide = EFreeFollowingSide.Right;

	// Token: 0x0400CF82 RID: 53122
	private double LastSummaryLogTime;

	// Token: 0x0400CF83 RID: 53123
	private bool LastTargetFound = true;
}
