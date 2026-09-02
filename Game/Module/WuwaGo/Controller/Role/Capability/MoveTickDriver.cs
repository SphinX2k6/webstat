using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Controller.Role.Capability
{
	// Token: 0x02004B03 RID: 19203
	[NullableContext(1)]
	[Nullable(0)]
	internal class MoveTickDriver : IWuWaGoTimeStopParticipant
	{
		// Token: 0x17008578 RID: 34168
		// (get) Token: 0x06032138 RID: 205112 RVA: 0x00C87E1F File Offset: 0x00C8601F
		// (set) Token: 0x06032139 RID: 205113 RVA: 0x00C87E27 File Offset: 0x00C86027
		public bool PausedByTimeStop { get; set; }

		// Token: 0x0603213A RID: 205114 RVA: 0x00C87E30 File Offset: 0x00C86030
		public MoveTickDriver(WuWaGoRole role, Vector targetLocation, float speed, float timeoutMs)
		{
			this.Role = role;
			this.TargetLocation = targetLocation;
			this.Speed = speed;
			this.TimeoutMs = timeoutMs;
			this.OneStepLen = Math.Max(5f, this.Speed * 0.02f * 1f);
		}

		// Token: 0x0603213B RID: 205115 RVA: 0x00C87EBC File Offset: 0x00C860BC
		[NullableContext(0)]
		public UniTask<bool> Run()
		{
			MoveTickDriver.<Run>d__29 <Run>d__;
			<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Run>d__.<>4__this = this;
			<Run>d__.<>1__state = -1;
			<Run>d__.<>t__builder.Start<MoveTickDriver.<Run>d__29>(ref <Run>d__);
			return <Run>d__.<>t__builder.Task;
		}

		// Token: 0x0603213C RID: 205116 RVA: 0x00C87EFF File Offset: 0x00C860FF
		public void PauseByTimeStop()
		{
			WuWaGoTimeStop.PauseTimerHandle(this.TickHandle);
			WuWaGoTimeStop.PauseTimerHandle(this.TimeoutHandle);
		}

		// Token: 0x0603213D RID: 205117 RVA: 0x00C87F17 File Offset: 0x00C86117
		public void ResumeByTimeStop()
		{
			WuWaGoTimeStop.ResumeTimerHandle(this.TickHandle);
			WuWaGoTimeStop.ResumeTimerHandle(this.TimeoutHandle);
		}

		// Token: 0x0603213E RID: 205118 RVA: 0x00C87F2F File Offset: 0x00C8612F
		public void CancelByTimeStop(string reason)
		{
			this.Finish(false);
		}

		// Token: 0x0603213F RID: 205119 RVA: 0x00C87F38 File Offset: 0x00C86138
		private void OnTick(float delta)
		{
			FVectorDouble? worldLocation = this.Role.GetWorldLocation();
			if (worldLocation == null)
			{
				this.Finish(false);
				return;
			}
			FVectorDouble value = worldLocation.Value;
			MoveTickDriver.EPhase phase = this.Phase;
			if (phase == MoveTickDriver.EPhase.Running)
			{
				this.TickRunning(value);
				return;
			}
			if (phase != MoveTickDriver.EPhase.Settling)
			{
				return;
			}
			this.TickSettling();
		}

		// Token: 0x06032140 RID: 205120 RVA: 0x00C87F88 File Offset: 0x00C86188
		private void TickRunning(FVectorDouble current)
		{
			this.TickDir.Set(this.TargetLocation.X - current.X, this.TargetLocation.Y - current.Y, 0.0);
			if (this.TickDir.Size() <= (double)this.OneStepLen)
			{
				this.EnterSettle(current);
				return;
			}
			this.TickDir.Normalize(9.99999993922529E-09);
			double num = this.TickDir.X * (double)this.Speed * 0.019999999552965164;
			double num2 = this.TickDir.Y * (double)this.Speed * 0.019999999552965164;
			this.StepTarget.Set(current.X + num, current.Y + num2, current.Z);
			this.Role.SetActorWorldLocation(this.StepTarget, false);
			this.WriteMonsterInputDirect(this.TickDir.ToUeVectorOld());
		}

		// Token: 0x06032141 RID: 205121 RVA: 0x00C88080 File Offset: 0x00C86280
		private void EnterSettle(FVectorDouble current)
		{
			this.Phase = MoveTickDriver.EPhase.Settling;
			this.SettleElapsedMs = 0f;
			this.SettleStart.Set(current.X, current.Y, current.Z);
			this.WriteMonsterInputDirect(Vector.ZeroVector);
			this.WriteMonsterMoveState(ECharMoveStateType.Stand);
		}

		// Token: 0x06032142 RID: 205122 RVA: 0x00C880D0 File Offset: 0x00C862D0
		private void TickSettling()
		{
			this.SettleElapsedMs += 20f;
			float num = Math.Min(1f, this.SettleElapsedMs / 60f);
			Vector.Lerp(this.SettleStart, this.TargetLocation, (double)num, this.SettlePos);
			this.Role.SetActorWorldLocation(this.SettlePos, false);
			if (num >= 1f)
			{
				this.Finish(true);
			}
		}

		// Token: 0x06032143 RID: 205123 RVA: 0x00C88140 File Offset: 0x00C86340
		private void OnTimeout(float delta)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.WuWaGo;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "MoveCapability：移动超时兜底，直接吸附目标格";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actor", this.Role.GetActorName());
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.Finish(true);
		}

		// Token: 0x06032144 RID: 205124 RVA: 0x00C88188 File Offset: 0x00C86388
		private void Finish(bool completed = true)
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
			if (this.Role.IsActorValid())
			{
				this.WriteMonsterInputDirect(Vector.ZeroVector);
				this.WriteMonsterMoveState(ECharMoveStateType.Stand);
			}
			this.Done.SetResult(completed);
		}

		// Token: 0x06032145 RID: 205125 RVA: 0x00C88232 File Offset: 0x00C86432
		[NullableContext(2)]
		private UAbpLogicParams GetMonsterLogicParams()
		{
			UKuroAnimInstanceChar animInstance = this.Role.GetAnimInstance();
			if (animInstance == null)
			{
				return null;
			}
			return animInstance.LogicParams;
		}

		// Token: 0x06032146 RID: 205126 RVA: 0x00C8824C File Offset: 0x00C8644C
		private void WriteMonsterInputDirect(FVector worldDir)
		{
			UAbpLogicParams monsterLogicParams = this.GetMonsterLogicParams();
			if (monsterLogicParams == null)
			{
				return;
			}
			monsterLogicParams.InputDirectRef = worldDir;
		}

		// Token: 0x06032147 RID: 205127 RVA: 0x00C8826C File Offset: 0x00C8646C
		private void WriteMonsterMoveState(ECharMoveStateType state)
		{
			UAbpLogicParams monsterLogicParams = this.GetMonsterLogicParams();
			if (monsterLogicParams == null)
			{
				return;
			}
			monsterLogicParams.CharMoveStateRef = state;
			monsterLogicParams.CharPositionStateRef = ECharPositionStateType.Ground;
		}

		// Token: 0x0401D465 RID: 119909
		private const int ARRIVE_TOLERANCE = 5;

		// Token: 0x0401D466 RID: 119910
		private const int TICK_INTERVAL_MS = 20;

		// Token: 0x0401D467 RID: 119911
		private const float TICK_DELTA_SECONDS = 0.02f;

		// Token: 0x0401D468 RID: 119912
		private const float EARLY_STOP_STEP_RATIO = 1f;

		// Token: 0x0401D469 RID: 119913
		private const int SETTLE_DURATION_MS = 60;

		// Token: 0x0401D46A RID: 119914
		private const string TIMER_NAME_TICK = "WuWaGo.MoveCapability.Tick";

		// Token: 0x0401D46B RID: 119915
		private const string TIMER_NAME_TIMEOUT = "WuWaGo.MoveCapability.Timeout";

		// Token: 0x0401D46D RID: 119917
		private readonly CustomPromise<bool> Done = new CustomPromise<bool>();

		// Token: 0x0401D46E RID: 119918
		private readonly Vector TickDir = Vector.Create();

		// Token: 0x0401D46F RID: 119919
		private readonly Vector StepTarget = Vector.Create();

		// Token: 0x0401D470 RID: 119920
		private readonly Vector SettleStart = Vector.Create();

		// Token: 0x0401D471 RID: 119921
		private readonly Vector SettlePos = Vector.Create();

		// Token: 0x0401D472 RID: 119922
		private readonly float OneStepLen;

		// Token: 0x0401D473 RID: 119923
		private MoveTickDriver.EPhase Phase;

		// Token: 0x0401D474 RID: 119924
		private float SettleElapsedMs;

		// Token: 0x0401D475 RID: 119925
		[Nullable(2)]
		private TimerHandle TickHandle;

		// Token: 0x0401D476 RID: 119926
		[Nullable(2)]
		private TimerHandle TimeoutHandle;

		// Token: 0x0401D477 RID: 119927
		[Nullable(2)]
		private Action UnregisterTimeStop;

		// Token: 0x0401D478 RID: 119928
		private bool Resolved;

		// Token: 0x0401D479 RID: 119929
		private readonly WuWaGoRole Role;

		// Token: 0x0401D47A RID: 119930
		private readonly Vector TargetLocation;

		// Token: 0x0401D47B RID: 119931
		private readonly float Speed;

		// Token: 0x0401D47C RID: 119932
		private readonly float TimeoutMs;

		// Token: 0x0200AB8F RID: 43919
		[NullableContext(0)]
		private enum EPhase
		{
			// Token: 0x04035615 RID: 218645
			Running,
			// Token: 0x04035616 RID: 218646
			Settling
		}
	}
}
