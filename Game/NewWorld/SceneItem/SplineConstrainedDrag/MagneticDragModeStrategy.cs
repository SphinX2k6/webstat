using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Define;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.SplineConstrainedDrag
{
	// Token: 0x02004825 RID: 18469
	[NullableContext(1)]
	[Nullable(0)]
	public class MagneticDragModeStrategy : BaseDragModeStrategy
	{
		// Token: 0x1700823A RID: 33338
		// (get) Token: 0x060300F6 RID: 196854 RVA: 0x00BA5BE4 File Offset: 0x00BA3DE4
		public override EKuroSplineConstrainedDragMode Mode { get; }

		// Token: 0x060300F7 RID: 196855 RVA: 0x00BA5BEC File Offset: 0x00BA3DEC
		private void OnMagneticTick(float deltaMs)
		{
			IKuroSplineConstrainedDrag host = this.Host;
			if (host == null)
			{
				return;
			}
			USplineComponent constraintSpline = host.GetConstraintSpline();
			if (constraintSpline != null && constraintSpline.IsValid())
			{
				AActor actor = host.GetActor();
				if (actor != null && actor.IsValid())
				{
					if (!this.HasInitialScreenPos)
					{
						return;
					}
					this.TickMousePosVector.X = (double)this.CachedMouseScreenPos.X;
					this.TickMousePosVector.Y = (double)this.CachedMouseScreenPos.Y;
					this.TickMousePosVector.Z = 0.0;
					this.TickMagneticDrag(this.TickMousePosVector, deltaMs / 1000f);
					return;
				}
			}
			this.EndDrag();
		}

		// Token: 0x060300F8 RID: 196856 RVA: 0x00BA5C98 File Offset: 0x00BA3E98
		public override void OnActivate(IKuroSplineConstrainedDrag host)
		{
			base.OnActivate(host);
			USplineComponent constraintSpline = host.GetConstraintSpline();
			if (constraintSpline != null && constraintSpline.IsValid())
			{
				int requiredSize = MagneticDragModeStrategy.ResolveCoarseSampleCount(constraintSpline.GetSplineLength());
				this.EnsureSampleBufferCapacity(requiredSize);
			}
		}

		// Token: 0x060300F9 RID: 196857 RVA: 0x00BA5CD1 File Offset: 0x00BA3ED1
		public override void OnDeactivate()
		{
			base.OnDeactivate();
			this.StopTimerIfRunning();
			this.MagneticVelocity = 0f;
			this.MagneticIsSuspended = false;
			this.MagneticFallbackLogged = false;
			this.ScreenDegenerateFrames = 0;
			this.HasInitialScreenPos = false;
		}

		// Token: 0x060300FA RID: 196858 RVA: 0x00BA5D08 File Offset: 0x00BA3F08
		public override void BeginDrag()
		{
			base.BeginDrag();
			if (this.Host == null)
			{
				return;
			}
			this.MagneticVelocity = 0f;
			this.MagneticFallbackLogged = false;
			this.LastMagneticTargetDistance = this.Host.GetCurrentDistanceAlongSpline();
			this.MagneticIsSuspended = false;
			this.ScreenDegenerateFrames = 0;
			this.HasInitialScreenPos = false;
			this.CachedMouseScreenPos.Set(0f, 0f);
			this.LastActorScreenPos.Set(0f, 0f);
			USplineComponent constraintSpline = this.Host.GetConstraintSpline();
			if (constraintSpline != null && constraintSpline.IsValid())
			{
				int requiredSize = MagneticDragModeStrategy.ResolveCoarseSampleCount(constraintSpline.GetSplineLength());
				this.EnsureSampleBufferCapacity(requiredSize);
			}
			this.EnsureTimerStarted();
		}

		// Token: 0x060300FB RID: 196859 RVA: 0x00BA5DB6 File Offset: 0x00BA3FB6
		public override void SetCurrentScreenPosition(Vector screenPosition)
		{
			this.CachedMouseScreenPos.Set((float)screenPosition.X, (float)screenPosition.Y);
			this.HasInitialScreenPos = true;
			this.WakeIfSuspended();
		}

		// Token: 0x060300FC RID: 196860 RVA: 0x00BA5DDE File Offset: 0x00BA3FDE
		public override void ApplyScreenDelta(Vector screenDelta)
		{
			this.CachedMouseScreenPos.Set(this.CachedMouseScreenPos.X + (float)screenDelta.X, this.CachedMouseScreenPos.Y + (float)screenDelta.Y);
			this.HasInitialScreenPos = true;
			this.WakeIfSuspended();
		}

		// Token: 0x060300FD RID: 196861 RVA: 0x00BA5E1E File Offset: 0x00BA401E
		public override void EndDrag()
		{
			base.EndDrag();
			this.StopTimerIfRunning();
			this.MagneticVelocity = 0f;
			this.MagneticFallbackLogged = false;
			this.LastMagneticTargetDistance = 0f;
			this.MagneticIsSuspended = false;
			this.ScreenDegenerateFrames = 0;
			this.HasInitialScreenPos = false;
		}

		// Token: 0x060300FE RID: 196862 RVA: 0x00BA5E5E File Offset: 0x00BA405E
		private void StopTimerIfRunning()
		{
			if (this.MagneticTimerHandle != null)
			{
				this.MagneticTimerHandle.Remove();
				this.MagneticTimerHandle = null;
			}
		}

		// Token: 0x060300FF RID: 196863 RVA: 0x00BA5E7B File Offset: 0x00BA407B
		private void EnsureTimerStarted()
		{
			if (this.MagneticTimerHandle != null)
			{
				return;
			}
			this.MagneticTimerHandle = TimerSystem.Instance.Forever(new TTimerAction(this.OnMagneticTick), 20f, 1f, null, "MagneticDrag", true);
		}

		// Token: 0x06030100 RID: 196864 RVA: 0x00BA5EB3 File Offset: 0x00BA40B3
		private void WakeIfSuspended()
		{
			if (!this.MagneticIsSuspended)
			{
				return;
			}
			this.MagneticIsSuspended = false;
			this.EnsureTimerStarted();
		}

		// Token: 0x06030101 RID: 196865 RVA: 0x00BA5ECC File Offset: 0x00BA40CC
		public static IStepSpringResult StepSpringSimulation(float current, float target, float velocity, float stiffness, float damping, float dtSeconds, float maxStepSeconds, float convergeSpeedThreshold, float convergePosThreshold)
		{
			float num = Math.Min(dtSeconds, maxStepSeconds);
			float num2 = -stiffness * (current - target) - damping * velocity;
			float num3 = velocity + num2 * num;
			float num4 = current + num3 * num;
			bool flag = Math.Abs(num3) < convergeSpeedThreshold && Math.Abs(target - num4) < convergePosThreshold;
			return new StepSpringResult
			{
				NewPosition = (flag ? target : num4),
				NewVelocity = (flag ? 0f : num3),
				Converged = flag
			};
		}

		// Token: 0x06030102 RID: 196866 RVA: 0x00BA5F44 File Offset: 0x00BA4144
		private static int ResolveCoarseSampleCount(float splineLength)
		{
			int val = SplineConstrainedCommonDefineConstants.magneticCoarseSampleCountByQuality[Singleton<GameSettingsDeviceRender>.Instance.GameQualitySettingLevel];
			if (splineLength > 0f)
			{
				int val2 = (int)Math.Floor((double)splineLength / 0.5) + 1;
				val = Math.Min(val, val2);
			}
			val = Math.Min(val, 128);
			return Math.Max(val, 2);
		}

		// Token: 0x06030103 RID: 196867 RVA: 0x00BA5FA0 File Offset: 0x00BA41A0
		private float TickMagneticDrag(Vector currentMouseScreenPosition, float deltaTime)
		{
			IKuroSplineConstrainedDrag host = this.Host;
			if (host == null)
			{
				return 0f;
			}
			this.CachedMouseScreenPos.Set((float)currentMouseScreenPosition.X, (float)currentMouseScreenPosition.Y);
			float num = this.FindClosestSplineDistanceToScreenPos(this.CachedMouseScreenPos);
			if (num < 0f)
			{
				this.LogFallbackOnce("all-projection-failed");
				this.DebugDrawMagnetic();
				return host.GetCurrentDistanceAlongSpline();
			}
			this.LastMagneticTargetDistance = num;
			float? magneticStiffness = host.GetMagneticStiffness();
			float? magneticDamping = host.GetMagneticDamping();
			float num4;
			if (magneticStiffness != null)
			{
				float? num2 = magneticStiffness;
				float num3 = 0f;
				if (num2.GetValueOrDefault() > num3 & num2 != null)
				{
					num4 = magneticStiffness.Value;
					goto IL_A1;
				}
			}
			num4 = 50f;
			IL_A1:
			float stiffness = num4;
			float num5;
			if (magneticDamping != null)
			{
				float? num2 = magneticDamping;
				float num3 = 0f;
				if (num2.GetValueOrDefault() > num3 & num2 != null)
				{
					num5 = magneticDamping.Value;
					goto IL_D9;
				}
			}
			num5 = 10f;
			IL_D9:
			float damping = num5;
			IStepSpringResult stepSpringResult = MagneticDragModeStrategy.StepSpringSimulation(host.GetCurrentDistanceAlongSpline(), num, this.MagneticVelocity, stiffness, damping, deltaTime, 0.033333335f, 0.01f, 0.5f);
			this.MagneticVelocity = stepSpringResult.NewVelocity;
			float result = host.SetDistanceAlongSpline(stepSpringResult.NewPosition, true);
			TsCharacterController characterController = Global.CharacterController;
			AActor actor = host.GetActor();
			if (characterController != null && characterController.IsValid() && actor != null && actor.IsValid())
			{
				FVectorDouble fvectorDouble = actor.D_K2_GetActorLocation();
				FVector2D lastActorScreenPos = this.LastActorScreenPos;
				if (UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble, ref lastActorScreenPos, false))
				{
					float x = this.LastActorScreenPos.X;
					float y = this.LastActorScreenPos.Y;
					FVector2D fvector2D = lastActorScreenPos;
					float num6 = fvector2D.X - x;
					float num7 = fvector2D.Y - y;
					float num8 = num6 * num6 + num7 * num7;
					this.LastActorScreenPos.Set(fvector2D.X, fvector2D.Y);
					if (num8 < 1f)
					{
						this.ScreenDegenerateFrames++;
					}
					else
					{
						this.ScreenDegenerateFrames = 0;
					}
				}
			}
			if (stepSpringResult.Converged || this.ScreenDegenerateFrames >= 5)
			{
				this.SuspendMagneticTick();
			}
			this.DebugDrawMagnetic();
			return result;
		}

		// Token: 0x06030104 RID: 196868 RVA: 0x00BA61B0 File Offset: 0x00BA43B0
		private unsafe void EnsureSampleBufferCapacity(int requiredSize)
		{
			if (requiredSize > 128)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "EnsureSampleBufferCapacity 过大";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("requiredSize", requiredSize);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Host", this.Host);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			while (this.SampleBuffer.Count < requiredSize)
			{
				this.SampleBuffer.Add(new SampleBufferEntry
				{
					Distance = 0f,
					ScreenPos = new FVector2D(),
					Valid = false
				});
			}
		}

		// Token: 0x06030105 RID: 196869 RVA: 0x00BA6264 File Offset: 0x00BA4464
		private float FindClosestSplineDistanceToScreenPos(FVector2D mouseScreenPos)
		{
			IKuroSplineConstrainedDrag host = this.Host;
			if (host == null)
			{
				return -1f;
			}
			USplineComponent constraintSpline = host.GetConstraintSpline();
			if (constraintSpline == null || !constraintSpline.IsValid())
			{
				return -1f;
			}
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null || !characterController.IsValid())
			{
				return -1f;
			}
			float splineLength = constraintSpline.GetSplineLength();
			if (splineLength <= 0f)
			{
				return -1f;
			}
			int num = MagneticDragModeStrategy.ResolveCoarseSampleCount(splineLength);
			this.EnsureSampleBufferCapacity(num);
			int num2 = -1;
			double num3 = double.PositiveInfinity;
			for (int i = 0; i < num; i++)
			{
				SampleBufferEntry sampleBufferEntry = this.SampleBuffer[i];
				sampleBufferEntry.Distance = (float)i / (float)(num - 1) * splineLength;
				FVectorDouble fvectorDouble = constraintSpline.D_GetLocationAtDistanceAlongSpline(sampleBufferEntry.Distance, ESplineCoordinateSpace.World);
				FVector2D screenPos = sampleBufferEntry.ScreenPos;
				bool flag = UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble, ref screenPos, false);
				sampleBufferEntry.Valid = flag;
				if (flag)
				{
					sampleBufferEntry.ScreenPos = screenPos;
					double num4 = Math.Pow((double)(sampleBufferEntry.ScreenPos.X - mouseScreenPos.X), 2.0) + Math.Pow((double)(sampleBufferEntry.ScreenPos.Y - mouseScreenPos.Y), 2.0);
					if (num4 < num3)
					{
						num3 = num4;
						num2 = i;
					}
				}
			}
			if (num2 < 0)
			{
				return -1f;
			}
			float loIn = (num2 > 0) ? this.SampleBuffer[num2 - 1].Distance : 0f;
			float hiIn = (num2 < num - 1) ? this.SampleBuffer[num2 + 1].Distance : splineLength;
			return this.RefineByBisection(constraintSpline, characterController, mouseScreenPos, loIn, hiIn);
		}

		// Token: 0x06030106 RID: 196870 RVA: 0x00BA6414 File Offset: 0x00BA4614
		private float RefineByBisection(USplineComponent spline, APlayerController playerController, FVector2D mouseScreenPos, float loIn, float hiIn)
		{
			int num = 8;
			double num2 = 1.0;
			float num3 = loIn;
			float num4 = hiIn;
			for (int i = 0; i < num; i++)
			{
				float num5 = (num3 + num4) * 0.5f;
				float distance = (num3 + num5) * 0.5f;
				float distance2 = (num5 + num4) * 0.5f;
				double num6 = this.ScreenDistSqAtDistance(spline, playerController, mouseScreenPos, distance);
				double num7 = this.ScreenDistSqAtDistance(spline, playerController, mouseScreenPos, distance2);
				if (num6 < 0.0 && num7 < 0.0)
				{
					break;
				}
				if (num6 < 0.0)
				{
					num3 = num5;
				}
				else if (num7 < 0.0)
				{
					num4 = num5;
				}
				else
				{
					if (num6 < num7)
					{
						num4 = num5;
					}
					else
					{
						num3 = num5;
					}
					double num8 = this.ScreenWidthSqOnSpline(spline, playerController, num3, num4);
					if (num8 >= 0.0 && num8 < num2)
					{
						break;
					}
				}
			}
			return (num3 + num4) * 0.5f;
		}

		// Token: 0x06030107 RID: 196871 RVA: 0x00BA64FC File Offset: 0x00BA46FC
		private double ScreenDistSqAtDistance(USplineComponent spline, APlayerController playerController, FVector2D mouseScreenPos, float distance)
		{
			FVectorDouble fvectorDouble = spline.D_GetLocationAtDistanceAlongSpline(distance, ESplineCoordinateSpace.World);
			FVector2D bisectionTempScreenPos = this.BisectionTempScreenPos;
			if (!UGameplayStatics.D_ProjectWorldToScreen(playerController, fvectorDouble, ref bisectionTempScreenPos, false))
			{
				return -1.0;
			}
			this.BisectionTempScreenPos = bisectionTempScreenPos;
			return (double)FVector2D.DistSquared(this.BisectionTempScreenPos, mouseScreenPos);
		}

		// Token: 0x06030108 RID: 196872 RVA: 0x00BA6548 File Offset: 0x00BA4748
		private double ScreenWidthSqOnSpline(USplineComponent spline, APlayerController playerController, float lo, float hi)
		{
			FVectorDouble fvectorDouble = spline.D_GetLocationAtDistanceAlongSpline(lo, ESplineCoordinateSpace.World);
			FVectorDouble fvectorDouble2 = spline.D_GetLocationAtDistanceAlongSpline(hi, ESplineCoordinateSpace.World);
			FVector2D bisectionWidthScreenPosA = this.BisectionWidthScreenPosA;
			if (!UGameplayStatics.D_ProjectWorldToScreen(playerController, fvectorDouble, ref bisectionWidthScreenPosA, false))
			{
				return -1.0;
			}
			this.BisectionWidthScreenPosA = bisectionWidthScreenPosA;
			FVector2D bisectionWidthScreenPosB = this.BisectionWidthScreenPosB;
			if (!UGameplayStatics.D_ProjectWorldToScreen(playerController, fvectorDouble2, ref bisectionWidthScreenPosB, false))
			{
				return -1.0;
			}
			this.BisectionWidthScreenPosB = bisectionWidthScreenPosB;
			return (double)FVector2D.DistSquared(this.BisectionWidthScreenPosA, this.BisectionWidthScreenPosB);
		}

		// Token: 0x06030109 RID: 196873 RVA: 0x00BA65C4 File Offset: 0x00BA47C4
		private unsafe void LogFallbackOnce(string reason)
		{
			if (this.MagneticFallbackLogged)
			{
				return;
			}
			this.MagneticFallbackLogged = true;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelPlay;
			ELogAuthor author = ELogAuthor.XDW;
			string message = "[MagneticDrag] degenerate frame — algorithm returned current distance (no update)";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", reason);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "actorKey";
			IKuroSplineConstrainedDrag host = this.Host;
			ptr = new ValueTuple<string, object>(item, (host != null) ? host.GetActor() : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0603010A RID: 196874 RVA: 0x00BA6645 File Offset: 0x00BA4845
		private void SuspendMagneticTick()
		{
			this.StopTimerIfRunning();
			this.MagneticIsSuspended = true;
			this.MagneticVelocity = 0f;
			this.ScreenDegenerateFrames = 0;
		}

		// Token: 0x0603010B RID: 196875 RVA: 0x00BA6668 File Offset: 0x00BA4868
		private void DebugDrawMagnetic()
		{
			if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("SplineConstrainedDrag") <= 0)
			{
				return;
			}
			IKuroSplineConstrainedDrag host = this.Host;
			if (host == null)
			{
				return;
			}
			USplineComponent constraintSpline = host.GetConstraintSpline();
			AActor actor = host.GetActor();
			if (constraintSpline == null || !constraintSpline.IsValid() || (actor == null || !actor.IsValid()))
			{
				return;
			}
			FVectorDouble lineStart = actor.D_K2_GetActorLocation();
			FVectorDouble fvectorDouble = constraintSpline.D_GetLocationAtDistanceAlongSpline(this.LastMagneticTargetDistance, ESplineCoordinateSpace.World);
			UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, fvectorDouble, 20f, 16, new FLinearColor?(ColorUtils.LinearCyan), 0f, 0f);
			UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, lineStart, fvectorDouble, ColorUtils.LinearCyan, 0f, 0f);
		}

		// Token: 0x0401B977 RID: 113015
		private readonly List<SampleBufferEntry> SampleBuffer = new List<SampleBufferEntry>();

		// Token: 0x0401B978 RID: 113016
		private FVector2D BisectionTempScreenPos = new FVector2D();

		// Token: 0x0401B979 RID: 113017
		private FVector2D BisectionWidthScreenPosA = new FVector2D();

		// Token: 0x0401B97A RID: 113018
		private FVector2D BisectionWidthScreenPosB = new FVector2D();

		// Token: 0x0401B97B RID: 113019
		private float MagneticVelocity;

		// Token: 0x0401B97C RID: 113020
		private FVector2D CachedMouseScreenPos = new FVector2D();

		// Token: 0x0401B97D RID: 113021
		private bool HasInitialScreenPos;

		// Token: 0x0401B97E RID: 113022
		[Nullable(2)]
		private TimerHandle MagneticTimerHandle;

		// Token: 0x0401B97F RID: 113023
		private bool MagneticFallbackLogged;

		// Token: 0x0401B980 RID: 113024
		private float LastMagneticTargetDistance;

		// Token: 0x0401B981 RID: 113025
		private bool MagneticIsSuspended;

		// Token: 0x0401B982 RID: 113026
		private int ScreenDegenerateFrames;

		// Token: 0x0401B983 RID: 113027
		private FVector2D LastActorScreenPos = new FVector2D();

		// Token: 0x0401B984 RID: 113028
		private readonly Vector TickMousePosVector = Vector.Create();
	}
}
