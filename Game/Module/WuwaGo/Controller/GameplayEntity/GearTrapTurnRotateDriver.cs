using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B0F RID: 19215
	[NullableContext(1)]
	[Nullable(0)]
	internal class GearTrapTurnRotateDriver
	{
		// Token: 0x060321D5 RID: 205269 RVA: 0x00C8A89C File Offset: 0x00C88A9C
		public GearTrapTurnRotateDriver(WuWaGoGameplayEntityBase entity, Rotator startRotator, Rotator targetRotator, int durationMs, int tickIntervalMs)
		{
			this.Entity = entity;
			this.DurationMs = durationMs;
			this.TickIntervalMs = tickIntervalMs;
			this.StartRotator.DeepCopy(startRotator);
			this.TargetRotator.DeepCopy(targetRotator);
		}

		// Token: 0x060321D6 RID: 205270 RVA: 0x00C8A90C File Offset: 0x00C88B0C
		public UniTask Run()
		{
			GearTrapTurnRotateDriver.<Run>d__12 <Run>d__;
			<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Run>d__.<>4__this = this;
			<Run>d__.<>1__state = -1;
			<Run>d__.<>t__builder.Start<GearTrapTurnRotateDriver.<Run>d__12>(ref <Run>d__);
			return <Run>d__.<>t__builder.Task;
		}

		// Token: 0x060321D7 RID: 205271 RVA: 0x00C8A950 File Offset: 0x00C88B50
		private void OnTick()
		{
			if (!this.Entity.IsActorValid())
			{
				this.Finish();
				return;
			}
			this.ElapsedMs += this.TickIntervalMs;
			float num = Math.Min(1f, (float)this.ElapsedMs / (float)this.DurationMs);
			Rotator.Lerp(this.StartRotator, this.TargetRotator, num, this.CurrentRotator);
			this.ApplyRotator(this.CurrentRotator);
			if (num >= 1f)
			{
				this.Finish();
			}
		}

		// Token: 0x060321D8 RID: 205272 RVA: 0x00C8A9D0 File Offset: 0x00C88BD0
		private void OnTimeout()
		{
			this.Finish();
		}

		// Token: 0x060321D9 RID: 205273 RVA: 0x00C8A9D8 File Offset: 0x00C88BD8
		private void ApplyRotator(Rotator rotator)
		{
			if (!this.Entity.IsActorValid())
			{
				return;
			}
			this.Entity.SetActorWorldRotation(rotator);
		}

		// Token: 0x060321DA RID: 205274 RVA: 0x00C8A9F4 File Offset: 0x00C88BF4
		private void Finish()
		{
			if (this.Resolved)
			{
				return;
			}
			if (this.Entity.IsActorValid())
			{
				this.ApplyRotator(this.TargetRotator);
			}
			this.Cancel();
		}

		// Token: 0x060321DB RID: 205275 RVA: 0x00C8AA20 File Offset: 0x00C88C20
		public void Cancel()
		{
			if (this.Resolved)
			{
				return;
			}
			this.Resolved = true;
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
			this.Done.SetResult(default(UniTaskVoid));
		}

		// Token: 0x0401D4B3 RID: 119987
		private readonly CustomPromise<UniTaskVoid> Done = new CustomPromise<UniTaskVoid>();

		// Token: 0x0401D4B4 RID: 119988
		private readonly Rotator StartRotator = Rotator.Create();

		// Token: 0x0401D4B5 RID: 119989
		private readonly Rotator TargetRotator = Rotator.Create();

		// Token: 0x0401D4B6 RID: 119990
		private readonly Rotator CurrentRotator = Rotator.Create();

		// Token: 0x0401D4B7 RID: 119991
		[Nullable(2)]
		private TimerHandle TickHandle;

		// Token: 0x0401D4B8 RID: 119992
		[Nullable(2)]
		private TimerHandle TimeoutHandle;

		// Token: 0x0401D4B9 RID: 119993
		private int ElapsedMs;

		// Token: 0x0401D4BA RID: 119994
		private bool Resolved;

		// Token: 0x0401D4BB RID: 119995
		private readonly WuWaGoGameplayEntityBase Entity;

		// Token: 0x0401D4BC RID: 119996
		private readonly int DurationMs;

		// Token: 0x0401D4BD RID: 119997
		private readonly int TickIntervalMs;
	}
}
