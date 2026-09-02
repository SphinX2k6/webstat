using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Model;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Movement
{
	// Token: 0x02004ACD RID: 19149
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoWorldMoveDriver : IWuWaGoTimeStopParticipant
	{
		// Token: 0x17008520 RID: 34080
		// (get) Token: 0x06031EB2 RID: 204466 RVA: 0x00C7E33F File Offset: 0x00C7C53F
		// (set) Token: 0x06031EB3 RID: 204467 RVA: 0x00C7E347 File Offset: 0x00C7C547
		public bool PausedByTimeStop { get; set; }

		// Token: 0x06031EB4 RID: 204468 RVA: 0x00C7E350 File Offset: 0x00C7C550
		public WuWaGoWorldMoveDriver(IWuWaGoWorldMoveDriverOptions options)
		{
			this.Options = options;
			this.FromWorldPosition.DeepCopy(this.Options.FromWorldPosition);
			this.ToWorldPosition.DeepCopy(this.Options.ToWorldPosition);
			this.TickIntervalMs = Math.Max(1, this.Options.TickIntervalMs.GetValueOrDefault(20));
			this.TickDeltaSeconds = (float)this.TickIntervalMs / 1000f;
			this.SettleDurationMs = Math.Max(0, this.Options.SettleDurationMs.GetValueOrDefault(60));
			this.ArriveTolerance = Math.Max(0f, this.Options.ArriveTolerance.GetValueOrDefault(5f));
			this.WorldDelta.Set(this.ToWorldPosition.X - this.FromWorldPosition.X, this.ToWorldPosition.Y - this.FromWorldPosition.Y, this.ToWorldPosition.Z - this.FromWorldPosition.Z);
			this.Distance = this.WorldDelta.Size();
			int num = Math.Max(1, this.Options.DurationMs.GetValueOrDefault(300));
			float? speed = this.Options.Speed;
			float speed2;
			if (speed != null && speed.GetValueOrDefault() != 0f)
			{
				speed = this.Options.Speed;
				float num2 = 0f;
				if (speed.GetValueOrDefault() > num2 & speed != null)
				{
					speed2 = this.Options.Speed.Value;
					goto IL_21C;
				}
			}
			speed2 = ((this.Distance <= 0.0) ? 0f : ((float)(this.Distance / (double)((float)num / 1000f))));
			IL_21C:
			this.Speed = speed2;
			float num3 = Math.Max(0f, this.Options.EarlyStopStepRatio.GetValueOrDefault(1f));
			this.OneStepLen = Math.Max(this.ArriveTolerance, this.Speed * this.TickDeltaSeconds * num3);
			double num4 = (this.Speed > 0f) ? (this.Distance / (double)this.Speed * 1000.0) : ((double)num);
			double val = (double)(this.TickIntervalMs * 2);
			int? timeoutMs = this.Options.TimeoutMs;
			this.TimeoutMs = (float)Math.Max(val, (timeoutMs != null) ? ((double)timeoutMs.GetValueOrDefault()) : (num4 * 1.5 + (double)this.SettleDurationMs));
		}

		// Token: 0x06031EB5 RID: 204469 RVA: 0x00C7E634 File Offset: 0x00C7C834
		[NullableContext(0)]
		public UniTask<bool> Run()
		{
			WuWaGoWorldMoveDriver.<Run>d__38 <Run>d__;
			<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Run>d__.<>4__this = this;
			<Run>d__.<>1__state = -1;
			<Run>d__.<>t__builder.Start<WuWaGoWorldMoveDriver.<Run>d__38>(ref <Run>d__);
			return <Run>d__.<>t__builder.Task;
		}

		// Token: 0x06031EB6 RID: 204470 RVA: 0x00C7E677 File Offset: 0x00C7C877
		public void PauseByTimeStop()
		{
			WuWaGoTimeStop.PauseTimerHandle(this.TickHandle);
			WuWaGoTimeStop.PauseTimerHandle(this.TimeoutHandle);
		}

		// Token: 0x06031EB7 RID: 204471 RVA: 0x00C7E68F File Offset: 0x00C7C88F
		public void ResumeByTimeStop()
		{
			WuWaGoTimeStop.ResumeTimerHandle(this.TickHandle);
			WuWaGoTimeStop.ResumeTimerHandle(this.TimeoutHandle);
		}

		// Token: 0x06031EB8 RID: 204472 RVA: 0x00C7E6A7 File Offset: 0x00C7C8A7
		public void CancelByTimeStop(string reason)
		{
			this.Finish(false, false);
		}

		// Token: 0x06031EB9 RID: 204473 RVA: 0x00C7E6B4 File Offset: 0x00C7C8B4
		private void CacheRuntimeTargets()
		{
			this.RuntimeTargets.Clear();
			foreach (IWuWaGoWorldMoveTarget wuWaGoWorldMoveTarget in this.Options.Targets)
			{
				if (wuWaGoWorldMoveTarget.Unit != null)
				{
					if (wuWaGoWorldMoveTarget.Unit.IsActorValid())
					{
						FVectorDouble? worldLocation = wuWaGoWorldMoveTarget.Unit.GetWorldLocation();
						if (worldLocation != null)
						{
							Vector startLocation = Vector.Create(wuWaGoWorldMoveTarget.FromWorldPosition ?? Vector.Create(worldLocation));
							Vector targetLocation = Vector.Create(wuWaGoWorldMoveTarget.ToWorldPosition ?? Vector.Create(worldLocation).Addition(this.WorldDelta, Vector.Create()));
							this.RuntimeTargets.Add(new WuWaGoWorldMoveDriver.MoveTargetRuntime
							{
								Unit = wuWaGoWorldMoveTarget.Unit,
								StartLocation = startLocation,
								TargetLocation = targetLocation
							});
						}
					}
				}
				else
				{
					AActor actor = wuWaGoWorldMoveTarget.Actor;
					if (actor != null && actor.IsValid())
					{
						this.RuntimeTargets.Add(new WuWaGoWorldMoveDriver.MoveTargetRuntime
						{
							Actor = actor,
							StartLocation = Vector.Create(wuWaGoWorldMoveTarget.FromWorldPosition ?? Vector.Create(actor.D_K2_GetActorLocation())),
							TargetLocation = Vector.Create(wuWaGoWorldMoveTarget.ToWorldPosition ?? Vector.Create(actor.D_K2_GetActorLocation()).Addition(this.WorldDelta, Vector.Create()))
						});
					}
				}
			}
		}

		// Token: 0x06031EBA RID: 204474 RVA: 0x00C7E854 File Offset: 0x00C7CA54
		private void OnTick(float delta)
		{
			Func<bool> shouldAbort = this.Options.ShouldAbort;
			if (shouldAbort != null && shouldAbort())
			{
				this.Finish(false, false);
				return;
			}
			if (!this.HasAnyValidTarget())
			{
				this.Finish(true, true);
				return;
			}
			WuWaGoWorldMoveDriver.EWorldMovePhase phase = this.Phase;
			if (phase == WuWaGoWorldMoveDriver.EWorldMovePhase.Running)
			{
				this.TickRunning();
				return;
			}
			if (phase != WuWaGoWorldMoveDriver.EWorldMovePhase.Settling)
			{
				return;
			}
			this.TickSettling();
		}

		// Token: 0x06031EBB RID: 204475 RVA: 0x00C7E8B0 File Offset: 0x00C7CAB0
		private void TickRunning()
		{
			this.RunningDirection.Set(this.ToWorldPosition.X - this.CurrentAnchor.X, this.ToWorldPosition.Y - this.CurrentAnchor.Y, this.ToWorldPosition.Z - this.CurrentAnchor.Z);
			if (this.RunningDirection.Size() <= (double)this.OneStepLen)
			{
				this.EnterSettle();
				return;
			}
			this.RunningDirection.Normalize(9.99999993922529E-09);
			this.CurrentAnchor.Set(this.CurrentAnchor.X + this.RunningDirection.X * (double)this.Speed * (double)this.TickDeltaSeconds, this.CurrentAnchor.Y + this.RunningDirection.Y * (double)this.Speed * (double)this.TickDeltaSeconds, this.CurrentAnchor.Z + this.RunningDirection.Z * (double)this.Speed * (double)this.TickDeltaSeconds);
			this.RunningAlpha = Math.Min(1.0, Vector.Dist(this.FromWorldPosition, this.CurrentAnchor) / Math.Max(this.Distance, 9.999999974752427E-07));
			this.ApplyAlpha((float)this.RunningAlpha);
			IWuWaGoWorldMoveHooks hooks = this.Options.Hooks;
			if (hooks == null)
			{
				return;
			}
			Action<Vector> onRunning = hooks.OnRunning;
			if (onRunning == null)
			{
				return;
			}
			onRunning(this.RunningDirection);
		}

		// Token: 0x06031EBC RID: 204476 RVA: 0x00C7EA29 File Offset: 0x00C7CC29
		private void EnterSettle()
		{
			this.Phase = WuWaGoWorldMoveDriver.EWorldMovePhase.Settling;
			this.SettleElapsedMs = 0;
			IWuWaGoWorldMoveHooks hooks = this.Options.Hooks;
			if (hooks == null)
			{
				return;
			}
			Action onEnterSettle = hooks.OnEnterSettle;
			if (onEnterSettle == null)
			{
				return;
			}
			onEnterSettle();
		}

		// Token: 0x06031EBD RID: 204477 RVA: 0x00C7EA58 File Offset: 0x00C7CC58
		private void TickSettling()
		{
			if (this.SettleDurationMs <= 0)
			{
				this.Finish(true, true);
				return;
			}
			this.SettleElapsedMs += this.TickIntervalMs;
			float num = Math.Min(1f, (float)this.SettleElapsedMs / (float)this.SettleDurationMs);
			double num2 = this.RunningAlpha + (1.0 - this.RunningAlpha) * (double)num;
			this.ApplyAlpha((float)num2);
			if (num >= 1f)
			{
				this.Finish(true, true);
			}
		}

		// Token: 0x06031EBE RID: 204478 RVA: 0x00C7EAD8 File Offset: 0x00C7CCD8
		private void OnTimeout(float delta)
		{
			Func<bool> shouldAbort = this.Options.ShouldAbort;
			bool flag = shouldAbort == null || !shouldAbort();
			this.Finish(flag, flag);
		}

		// Token: 0x06031EBF RID: 204479 RVA: 0x00C7EB08 File Offset: 0x00C7CD08
		private void ApplyAlpha(float alpha)
		{
			foreach (WuWaGoWorldMoveDriver.IMoveTargetRuntime moveTargetRuntime in this.RuntimeTargets)
			{
				if (moveTargetRuntime.Unit != null)
				{
					if (moveTargetRuntime.Unit.IsActorValid())
					{
						Vector.Lerp(moveTargetRuntime.StartLocation, moveTargetRuntime.TargetLocation, (double)alpha, this.InterpLocation);
						moveTargetRuntime.Unit.SetActorWorldLocation(this.InterpLocation, false);
					}
				}
				else
				{
					AActor actor = moveTargetRuntime.Actor;
					if (actor != null && actor.IsValid())
					{
						Vector.Lerp(moveTargetRuntime.StartLocation, moveTargetRuntime.TargetLocation, (double)alpha, this.InterpLocation);
						moveTargetRuntime.Actor.D_K2_SetActorLocation(this.InterpLocation.ToUeVector(false), false, ref WorldGlobal.SweepHitResult, false);
					}
				}
			}
		}

		// Token: 0x06031EC0 RID: 204480 RVA: 0x00C7EBEC File Offset: 0x00C7CDEC
		private bool HasAnyValidTarget()
		{
			return this.RuntimeTargets.Find(delegate(WuWaGoWorldMoveDriver.IMoveTargetRuntime target)
			{
				WuWaGoBaseUnit unit = target.Unit;
				if (unit == null)
				{
					AActor actor = target.Actor;
					return actor != null && actor.IsValid();
				}
				return unit.IsActorValid();
			}) != null;
		}

		// Token: 0x06031EC1 RID: 204481 RVA: 0x00C7EC1C File Offset: 0x00C7CE1C
		private void Finish(bool applyFinalAlpha = true, bool completed = true)
		{
			if (this.Resolved)
			{
				return;
			}
			this.Resolved = true;
			Action unregisterTimeStop = this.UnregisterTimeStop;
			if (unregisterTimeStop != null)
			{
				unregisterTimeStop();
			}
			this.UnregisterTimeStop = null;
			TimerHandle tickHandle = this.TickHandle;
			if (tickHandle != null && tickHandle.Valid())
			{
				TimerSystem.Instance.Remove(this.TickHandle);
			}
			TimerHandle timeoutHandle = this.TimeoutHandle;
			if (timeoutHandle != null && timeoutHandle.Valid())
			{
				TimerSystem.Instance.Remove(this.TimeoutHandle);
			}
			if (this.HasAnyValidTarget())
			{
				if (applyFinalAlpha)
				{
					this.ApplyAlpha(1f);
				}
				else
				{
					this.ApplyAlpha(0f);
				}
			}
			IWuWaGoWorldMoveHooks hooks = this.Options.Hooks;
			if (hooks != null)
			{
				Action onFinish = hooks.OnFinish;
				if (onFinish != null)
				{
					onFinish();
				}
			}
			this.Done.SetResult(completed);
		}

		// Token: 0x0401D35C RID: 119644
		private const int DEFAULT_ARRIVE_TOLERANCE = 5;

		// Token: 0x0401D35D RID: 119645
		private const int DEFAULT_DURATION_MS = 300;

		// Token: 0x0401D35E RID: 119646
		private const int DEFAULT_TICK_INTERVAL_MS = 20;

		// Token: 0x0401D35F RID: 119647
		private const int DEFAULT_SETTLE_DURATION_MS = 60;

		// Token: 0x0401D360 RID: 119648
		private const float DEFAULT_SAFE_TIMEOUT_RATIO = 1.5f;

		// Token: 0x0401D361 RID: 119649
		private const float DEFAULT_EARLY_STOP_STEP_RATIO = 1f;

		// Token: 0x0401D363 RID: 119651
		private readonly CustomPromise<bool> Done = new CustomPromise<bool>();

		// Token: 0x0401D364 RID: 119652
		private readonly List<WuWaGoWorldMoveDriver.IMoveTargetRuntime> RuntimeTargets = new List<WuWaGoWorldMoveDriver.IMoveTargetRuntime>();

		// Token: 0x0401D365 RID: 119653
		private readonly Vector FromWorldPosition = Vector.Create();

		// Token: 0x0401D366 RID: 119654
		private readonly Vector ToWorldPosition = Vector.Create();

		// Token: 0x0401D367 RID: 119655
		private readonly Vector WorldDelta = Vector.Create();

		// Token: 0x0401D368 RID: 119656
		private readonly Vector RunningDirection = Vector.Create();

		// Token: 0x0401D369 RID: 119657
		private readonly Vector CurrentAnchor = Vector.Create();

		// Token: 0x0401D36A RID: 119658
		private readonly Vector InterpLocation = Vector.Create();

		// Token: 0x0401D36B RID: 119659
		private readonly int TickIntervalMs;

		// Token: 0x0401D36C RID: 119660
		private readonly float TickDeltaSeconds;

		// Token: 0x0401D36D RID: 119661
		private readonly int SettleDurationMs;

		// Token: 0x0401D36E RID: 119662
		private readonly float ArriveTolerance;

		// Token: 0x0401D36F RID: 119663
		private readonly float OneStepLen;

		// Token: 0x0401D370 RID: 119664
		private readonly float TimeoutMs;

		// Token: 0x0401D371 RID: 119665
		private readonly float Speed;

		// Token: 0x0401D372 RID: 119666
		private readonly double Distance;

		// Token: 0x0401D373 RID: 119667
		private WuWaGoWorldMoveDriver.EWorldMovePhase Phase;

		// Token: 0x0401D374 RID: 119668
		private int SettleElapsedMs;

		// Token: 0x0401D375 RID: 119669
		private double RunningAlpha;

		// Token: 0x0401D376 RID: 119670
		[Nullable(2)]
		private TimerHandle TickHandle;

		// Token: 0x0401D377 RID: 119671
		[Nullable(2)]
		private TimerHandle TimeoutHandle;

		// Token: 0x0401D378 RID: 119672
		[Nullable(2)]
		private Action UnregisterTimeStop;

		// Token: 0x0401D379 RID: 119673
		private bool Resolved;

		// Token: 0x0401D37A RID: 119674
		private readonly IWuWaGoWorldMoveDriverOptions Options;

		// Token: 0x0200AB41 RID: 43841
		[NullableContext(0)]
		private enum EWorldMovePhase
		{
			// Token: 0x040354B1 RID: 218289
			Running,
			// Token: 0x040354B2 RID: 218290
			Settling
		}

		// Token: 0x0200AB42 RID: 43842
		private interface IMoveTargetRuntime
		{
			// Token: 0x1700A950 RID: 43344
			// (get) Token: 0x0604BAA3 RID: 309923
			[Nullable(2)]
			WuWaGoBaseUnit Unit { [NullableContext(2)] get; }

			// Token: 0x1700A951 RID: 43345
			// (get) Token: 0x0604BAA4 RID: 309924
			[Nullable(2)]
			AActor Actor { [NullableContext(2)] get; }

			// Token: 0x1700A952 RID: 43346
			// (get) Token: 0x0604BAA5 RID: 309925
			Vector StartLocation { get; }

			// Token: 0x1700A953 RID: 43347
			// (get) Token: 0x0604BAA6 RID: 309926
			Vector TargetLocation { get; }
		}

		// Token: 0x0200AB43 RID: 43843
		[Nullable(0)]
		[RequiredMember]
		private class MoveTargetRuntime : WuWaGoWorldMoveDriver.IMoveTargetRuntime
		{
			// Token: 0x1700A954 RID: 43348
			// (get) Token: 0x0604BAA7 RID: 309927 RVA: 0x014925E2 File Offset: 0x014907E2
			// (set) Token: 0x0604BAA8 RID: 309928 RVA: 0x014925EA File Offset: 0x014907EA
			[Nullable(2)]
			public WuWaGoBaseUnit Unit { [NullableContext(2)] get; [NullableContext(2)] set; }

			// Token: 0x1700A955 RID: 43349
			// (get) Token: 0x0604BAA9 RID: 309929 RVA: 0x014925F3 File Offset: 0x014907F3
			// (set) Token: 0x0604BAAA RID: 309930 RVA: 0x014925FB File Offset: 0x014907FB
			[Nullable(2)]
			public AActor Actor { [NullableContext(2)] get; [NullableContext(2)] set; }

			// Token: 0x1700A956 RID: 43350
			// (get) Token: 0x0604BAAB RID: 309931 RVA: 0x01492604 File Offset: 0x01490804
			// (set) Token: 0x0604BAAC RID: 309932 RVA: 0x0149260C File Offset: 0x0149080C
			[RequiredMember]
			public Vector StartLocation { get; set; }

			// Token: 0x1700A957 RID: 43351
			// (get) Token: 0x0604BAAD RID: 309933 RVA: 0x01492615 File Offset: 0x01490815
			// (set) Token: 0x0604BAAE RID: 309934 RVA: 0x0149261D File Offset: 0x0149081D
			[RequiredMember]
			public Vector TargetLocation { get; set; }

			// Token: 0x0604BAAF RID: 309935 RVA: 0x01492626 File Offset: 0x01490826
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public MoveTargetRuntime()
			{
			}
		}
	}
}
