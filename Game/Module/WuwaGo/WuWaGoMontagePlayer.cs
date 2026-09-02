using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004ABA RID: 19130
	[NullableContext(1)]
	[Nullable(0)]
	internal class WuWaGoMontagePlayer : IWuWaGoTimeStopParticipant
	{
		// Token: 0x06031E0B RID: 204299 RVA: 0x00C7B4F9 File Offset: 0x00C796F9
		public WuWaGoMontagePlayer(UAnimInstance animInstance, UAnimMontage montage, EWuWaGoMontageWaitMode waitMode)
		{
		}

		// Token: 0x17008517 RID: 34071
		// (get) Token: 0x06031E0C RID: 204300 RVA: 0x00C7B521 File Offset: 0x00C79721
		// (set) Token: 0x06031E0D RID: 204301 RVA: 0x00C7B529 File Offset: 0x00C79729
		public bool PausedByTimeStop { get; set; }

		// Token: 0x06031E0E RID: 204302 RVA: 0x00C7B534 File Offset: 0x00C79734
		public UniTask Play()
		{
			WuWaGoMontagePlayer.<Play>d__12 <Play>d__;
			<Play>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Play>d__.<>4__this = this;
			<Play>d__.<>1__state = -1;
			<Play>d__.<>t__builder.Start<WuWaGoMontagePlayer.<Play>d__12>(ref <Play>d__);
			return <Play>d__.<>t__builder.Task;
		}

		// Token: 0x06031E0F RID: 204303 RVA: 0x00C7B577 File Offset: 0x00C79777
		public void PauseByTimeStop()
		{
			WuWaGoTimeStop.PauseTimerHandle(this.TimerHandle);
		}

		// Token: 0x06031E10 RID: 204304 RVA: 0x00C7B584 File Offset: 0x00C79784
		public void ResumeByTimeStop()
		{
			WuWaGoTimeStop.ResumeTimerHandle(this.TimerHandle);
		}

		// Token: 0x06031E11 RID: 204305 RVA: 0x00C7B591 File Offset: 0x00C79791
		public void CancelByTimeStop(string reason)
		{
			this.Finish();
		}

		// Token: 0x06031E12 RID: 204306 RVA: 0x00C7B599 File Offset: 0x00C79799
		private float GetMontagePlayRate()
		{
			return WuWaGoUtil.GetMontagePlayRate();
		}

		// Token: 0x06031E13 RID: 204307 RVA: 0x00C7B5A0 File Offset: 0x00C797A0
		[NullableContext(2)]
		private void OnMontageBlendingOut(UAnimMontage montage1, bool bInterrupted)
		{
			if (montage1 != this.<montage>P)
			{
				return;
			}
			this.Finish();
		}

		// Token: 0x06031E14 RID: 204308 RVA: 0x00C7B5B2 File Offset: 0x00C797B2
		[NullableContext(2)]
		private void OnMontageEnded(UAnimMontage montage1, bool bInterrupted)
		{
			if (montage1 != this.<montage>P)
			{
				return;
			}
			this.Finish();
		}

		// Token: 0x06031E15 RID: 204309 RVA: 0x00C7B5C4 File Offset: 0x00C797C4
		private void OnTimeout(float delta)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.WuWaGo;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "Montage 超时兜底触发";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("montage", this.<montage>P);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.Finish();
		}

		// Token: 0x06031E16 RID: 204310 RVA: 0x00C7B608 File Offset: 0x00C79808
		private void Finish()
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
			this.<animInstance>P.OnMontageBlendingOut.Remove(new Action<UAnimMontage, bool>(this.OnMontageBlendingOut));
			this.<animInstance>P.OnMontageEnded.Remove(new Action<UAnimMontage, bool>(this.OnMontageEnded));
			TimerHandle timerHandle = this.TimerHandle;
			if (timerHandle != null && timerHandle.Valid())
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
			}
			this.Done.SetResult(default(UniTaskVoid));
		}

		// Token: 0x0401D315 RID: 119573
		[CompilerGenerated]
		private UAnimInstance <animInstance>P = animInstance;

		// Token: 0x0401D316 RID: 119574
		[CompilerGenerated]
		private UAnimMontage <montage>P = montage;

		// Token: 0x0401D317 RID: 119575
		[CompilerGenerated]
		private EWuWaGoMontageWaitMode <waitMode>P = waitMode;

		// Token: 0x0401D319 RID: 119577
		private readonly CustomPromise<UniTaskVoid> Done = new CustomPromise<UniTaskVoid>();

		// Token: 0x0401D31A RID: 119578
		[Nullable(2)]
		private TimerHandle TimerHandle;

		// Token: 0x0401D31B RID: 119579
		[Nullable(2)]
		private Action UnregisterTimeStop;

		// Token: 0x0401D31C RID: 119580
		private bool Resolved;
	}
}
