using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform;
using UnrealEngine;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x0200449F RID: 17567
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LauncherAudio : Singleton<LauncherAudio>
	{
		// Token: 0x0602E527 RID: 189735 RVA: 0x00ADF8A1 File Offset: 0x00ADDAA1
		public void Init()
		{
			UAkGameplayStatics.ClearSoundBanksAndMedia();
			UAkGameplayStatics.UnloadInitBank();
			UAkGameplayStatics.LoadInitBank();
			UAkGameplayStatics.ReloadAudioAssetData();
		}

		// Token: 0x0602E528 RID: 189736 RVA: 0x00ADF8B8 File Offset: 0x00ADDAB8
		public void InitIosAuditPackage()
		{
			if (this.IsInit)
			{
				return;
			}
			if (!Singleton<Platform>.Instance.IsIOSPlatform())
			{
				return;
			}
			if (!Singleton<BaseConfigController>.Instance.GetIosAuditFirstDownloadTip())
			{
				Singleton<LauncherLog>.Instance.Info("LauncherAudio 不是提审包 ~", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			UKuroAudioStatics.SetIosAuditPackage(true);
			UKuroAudioStatics.ChangeIosAudioSessionProperties();
			Singleton<LauncherResourceLib>.Instance.LoadAsync<UAkAudioEvent>("/Game/Aki/WwiseAudio/Events/pause_all_wwise_audio.pause_all_wwise_audio", delegate([Nullable(2)] UAkAudioEvent audioEvent, string path)
			{
				this.PauseAudioEvent = audioEvent;
				this.OnEventsLoaded();
			}, 0, "Launch.Audio");
			Singleton<LauncherResourceLib>.Instance.LoadAsync<UAkAudioEvent>("/Game/Aki/WwiseAudio/Events/resume_all_wwise_audio.resume_all_wwise_audio", delegate([Nullable(2)] UAkAudioEvent audioEvent, string path)
			{
				this.ResumeAudioEvent = audioEvent;
				this.OnEventsLoaded();
			}, 0, "Launch.Audio");
			this.IsInit = true;
		}

		// Token: 0x0602E529 RID: 189737 RVA: 0x00ADF958 File Offset: 0x00ADDB58
		private void OnEventsLoaded()
		{
			if (this.PauseAudioEvent != null && this.ResumeAudioEvent != null)
			{
				FKuroAudioPauseDelegate fkuroAudioPauseDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKuroAudioPauseDelegate>(new Action(this.OnAudioPause));
				UKuroAudioDelegates.SetAudioPauseDelegate(fkuroAudioPauseDelegate);
				FKuroAudioResumeDelegate fkuroAudioResumeDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKuroAudioResumeDelegate>(new Action(this.OnAudioResume));
				UKuroAudioDelegates.SetAudioResumeDelegate(fkuroAudioResumeDelegate);
			}
		}

		// Token: 0x0602E52A RID: 189738 RVA: 0x00ADF9A8 File Offset: 0x00ADDBA8
		public void Destroy()
		{
			if (!this.IsInit)
			{
				return;
			}
			if (this.PauseAudioEvent != null && this.ResumeAudioEvent != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnAudioPause));
				UKuroAudioDelegates.UnbindAudioPauseDelegate();
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnAudioResume));
				UKuroAudioDelegates.UnbindAudioResumeDelegate();
			}
			this.IsInit = false;
		}

		// Token: 0x0602E52B RID: 189739 RVA: 0x00ADFA04 File Offset: 0x00ADDC04
		private void OnAudioPause()
		{
			if (this.PauseAudioEvent != null)
			{
				if (this.IsPaused.GetValueOrDefault())
				{
					Singleton<LauncherLog>.Instance.Info("重复暂停音乐", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				Singleton<LauncherLog>.Instance.Info("暂停所有音乐", default(ReadOnlySpan<ValueTuple<string, object>>));
				UAkAudioEvent pauseAudioEvent = this.PauseAudioEvent;
				AActor actor = null;
				int callbackMask = 0;
				FOnAkPostEventCallback fonAkPostEventCallback = null;
				UAkGameplayStatics.PostEvent(pauseAudioEvent, actor, callbackMask, fonAkPostEventCallback, false, "");
				UAkGameplayStatics.RenderAudio();
				this.IsPaused = new bool?(true);
			}
		}

		// Token: 0x0602E52C RID: 189740 RVA: 0x00ADFA80 File Offset: 0x00ADDC80
		private void OnAudioResume()
		{
			if (this.ResumeAudioEvent != null)
			{
				bool? isPaused = this.IsPaused;
				bool flag = false;
				if (isPaused.GetValueOrDefault() == flag & isPaused != null)
				{
					Singleton<LauncherLog>.Instance.Info("重复恢复音乐", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				Singleton<LauncherLog>.Instance.Info("恢复所有音乐", default(ReadOnlySpan<ValueTuple<string, object>>));
				UAkAudioEvent resumeAudioEvent = this.ResumeAudioEvent;
				AActor actor = null;
				int callbackMask = 0;
				FOnAkPostEventCallback fonAkPostEventCallback = null;
				UAkGameplayStatics.PostEvent(resumeAudioEvent, actor, callbackMask, fonAkPostEventCallback, false, "");
				UAkGameplayStatics.RenderAudio();
				this.IsPaused = new bool?(false);
			}
		}

		// Token: 0x0401A4F1 RID: 107761
		private const string PAUSE_AUDIO_EVENT = "/Game/Aki/WwiseAudio/Events/pause_all_wwise_audio.pause_all_wwise_audio";

		// Token: 0x0401A4F2 RID: 107762
		private const string RESUME_AUDIO_EVENT = "/Game/Aki/WwiseAudio/Events/resume_all_wwise_audio.resume_all_wwise_audio";

		// Token: 0x0401A4F3 RID: 107763
		[Nullable(2)]
		private UAkAudioEvent PauseAudioEvent;

		// Token: 0x0401A4F4 RID: 107764
		[Nullable(2)]
		private UAkAudioEvent ResumeAudioEvent;

		// Token: 0x0401A4F5 RID: 107765
		private bool IsInit;

		// Token: 0x0401A4F6 RID: 107766
		private bool? IsPaused;
	}
}
