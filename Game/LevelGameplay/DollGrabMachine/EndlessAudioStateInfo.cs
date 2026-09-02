using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006ED6 RID: 28374
	[NullableContext(2)]
	[Nullable(0)]
	public class EndlessAudioStateInfo
	{
		// Token: 0x06044C00 RID: 281600 RVA: 0x011DE4F8 File Offset: 0x011DC6F8
		[NullableContext(1)]
		public EndlessAudioStateInfo(float duration, IDollGrabStageAudioState audioState)
		{
			this.Duration = duration;
			this.AudioState = audioState;
		}

		// Token: 0x06044C01 RID: 281601 RVA: 0x011DE510 File Offset: 0x011DC710
		public void StartAudio()
		{
			if (this.Duration != 0f)
			{
				this.AudioTimerHandle = TimerSystem.Instance.Delay(delegate(float _)
				{
					Singleton<AudioSystem>.Instance.SetState(this.AudioState.Group, this.AudioState.State, true);
					this.AudioTimerHandle = null;
				}, this.Duration * 1000f, null, null, true, 1f);
				return;
			}
			Singleton<AudioSystem>.Instance.SetState(this.AudioState.Group, this.AudioState.State, true);
		}

		// Token: 0x06044C02 RID: 281602 RVA: 0x011DE57C File Offset: 0x011DC77C
		public void StopAudio()
		{
			if (this.AudioTimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.AudioTimerHandle);
				this.AudioTimerHandle = null;
			}
		}

		// Token: 0x06044C03 RID: 281603 RVA: 0x011DE59E File Offset: 0x011DC79E
		public void PauseAudio()
		{
			if (this.AudioTimerHandle != null)
			{
				TimerSystem.Instance.Pause(this.AudioTimerHandle, null);
			}
		}

		// Token: 0x06044C04 RID: 281604 RVA: 0x011DE5BA File Offset: 0x011DC7BA
		public void ResumeAudio()
		{
			if (this.AudioTimerHandle != null)
			{
				TimerSystem.Instance.Resume(this.AudioTimerHandle);
			}
		}

		// Token: 0x040264B2 RID: 156850
		public float Duration;

		// Token: 0x040264B3 RID: 156851
		public IDollGrabStageAudioState AudioState;

		// Token: 0x040264B4 RID: 156852
		public TimerHandle AudioTimerHandle;
	}
}
