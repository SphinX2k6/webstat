using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AB7 RID: 19127
	internal class WuWaGoTimeStopWait : IWuWaGoTimeStopParticipant
	{
		// Token: 0x06031DD3 RID: 204243 RVA: 0x00C7A5A3 File Offset: 0x00C787A3
		public WuWaGoTimeStopWait(int durationMs)
		{
		}

		// Token: 0x17008515 RID: 34069
		// (get) Token: 0x06031DD4 RID: 204244 RVA: 0x00C7A5BD File Offset: 0x00C787BD
		// (set) Token: 0x06031DD5 RID: 204245 RVA: 0x00C7A5C5 File Offset: 0x00C787C5
		public bool PausedByTimeStop { get; set; }

		// Token: 0x06031DD6 RID: 204246 RVA: 0x00C7A5D0 File Offset: 0x00C787D0
		public UniTask<EWuWaGoTimeStopWaitResult> Run()
		{
			WuWaGoTimeStopWait.<Run>d__10 <Run>d__;
			<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder<EWuWaGoTimeStopWaitResult>.Create();
			<Run>d__.<>4__this = this;
			<Run>d__.<>1__state = -1;
			<Run>d__.<>t__builder.Start<WuWaGoTimeStopWait.<Run>d__10>(ref <Run>d__);
			return <Run>d__.<>t__builder.Task;
		}

		// Token: 0x06031DD7 RID: 204247 RVA: 0x00C7A613 File Offset: 0x00C78813
		public void PauseByTimeStop()
		{
			WuWaGoTimeStop.PauseTimerHandle(this.TimerHandle);
		}

		// Token: 0x06031DD8 RID: 204248 RVA: 0x00C7A620 File Offset: 0x00C78820
		public void ResumeByTimeStop()
		{
			WuWaGoTimeStop.ResumeTimerHandle(this.TimerHandle);
		}

		// Token: 0x06031DD9 RID: 204249 RVA: 0x00C7A62D File Offset: 0x00C7882D
		[NullableContext(1)]
		public void CancelByTimeStop(string reason)
		{
			this.Finish(EWuWaGoTimeStopWaitResult.Canceled);
		}

		// Token: 0x06031DDA RID: 204250 RVA: 0x00C7A636 File Offset: 0x00C78836
		private void OnCompleted(float delta)
		{
			this.Finish(EWuWaGoTimeStopWaitResult.Completed);
		}

		// Token: 0x06031DDB RID: 204251 RVA: 0x00C7A640 File Offset: 0x00C78840
		private void Finish(EWuWaGoTimeStopWaitResult result)
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
			TimerHandle timerHandle = this.TimerHandle;
			if (timerHandle != null && timerHandle.Valid())
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
			}
			this.Done.SetResult(result);
		}

		// Token: 0x0401D309 RID: 119561
		[CompilerGenerated]
		private int <durationMs>P = durationMs;

		// Token: 0x0401D30B RID: 119563
		[Nullable(1)]
		private readonly CustomPromise<EWuWaGoTimeStopWaitResult> Done = new CustomPromise<EWuWaGoTimeStopWaitResult>();

		// Token: 0x0401D30C RID: 119564
		[Nullable(2)]
		private TimerHandle TimerHandle;

		// Token: 0x0401D30D RID: 119565
		[Nullable(2)]
		private Action UnregisterTimeStop;

		// Token: 0x0401D30E RID: 119566
		private bool Resolved;
	}
}
