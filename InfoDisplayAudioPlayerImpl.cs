using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FF2 RID: 8178
[NullableContext(2)]
[Nullable(0)]
public class InfoDisplayAudioPlayerImpl
{
	// Token: 0x0600F6E5 RID: 63205 RVA: 0x00439954 File Offset: 0x00437B54
	[NullableContext(1)]
	public InfoDisplayAudioPlayerImpl(AActor rootActor, UUIExtendToggle togglePlay)
	{
		this.RootActor = rootActor;
		this.TogglePlay = togglePlay;
	}

	// Token: 0x0600F6E6 RID: 63206 RVA: 0x0043997C File Offset: 0x00437B7C
	public void Start()
	{
		this.InternalPlay();
	}

	// Token: 0x0600F6E7 RID: 63207 RVA: 0x00439984 File Offset: 0x00437B84
	public void Stop()
	{
		this.Release();
	}

	// Token: 0x0600F6E8 RID: 63208 RVA: 0x0043998C File Offset: 0x00437B8C
	public void Release()
	{
		this.ResetSpectrum();
		if (this.AudioDelegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EAkCallbackType, UAkCallbackInfo>(this.EndCallBack));
			this.AudioDelegate = null;
		}
	}

	// Token: 0x0600F6E9 RID: 63209 RVA: 0x004399B4 File Offset: 0x00437BB4
	[NullableContext(1)]
	public void SetSpectrumCallBack(Action<TArray<float>, float> spectrumCall)
	{
	}

	// Token: 0x0600F6EA RID: 63210 RVA: 0x004399B8 File Offset: 0x00437BB8
	[NullableContext(1)]
	public UniTask SetAudioClipPathAndLoadAudio(string audioPath)
	{
		InfoDisplayAudioPlayerImpl.<SetAudioClipPathAndLoadAudio>d__19 <SetAudioClipPathAndLoadAudio>d__;
		<SetAudioClipPathAndLoadAudio>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetAudioClipPathAndLoadAudio>d__.<>4__this = this;
		<SetAudioClipPathAndLoadAudio>d__.audioPath = audioPath;
		<SetAudioClipPathAndLoadAudio>d__.<>1__state = -1;
		<SetAudioClipPathAndLoadAudio>d__.<>t__builder.Start<InfoDisplayAudioPlayerImpl.<SetAudioClipPathAndLoadAudio>d__19>(ref <SetAudioClipPathAndLoadAudio>d__);
		return <SetAudioClipPathAndLoadAudio>d__.<>t__builder.Task;
	}

	// Token: 0x0600F6EB RID: 63211 RVA: 0x00439A03 File Offset: 0x00437C03
	public void OnClickPlayAudioBtn()
	{
		this.InternalPlay();
	}

	// Token: 0x0600F6EC RID: 63212 RVA: 0x00439A0B File Offset: 0x00437C0B
	public void OnTick(float deltaTime)
	{
		if (!this.IsPlaying())
		{
			return;
		}
		this.RefreshPlayInfo(deltaTime);
	}

	// Token: 0x0600F6ED RID: 63213 RVA: 0x00439A1D File Offset: 0x00437C1D
	public bool IsPlaying()
	{
		return this.PlayState && !this.PauseState;
	}

	// Token: 0x0600F6EE RID: 63214 RVA: 0x00439A32 File Offset: 0x00437C32
	public float GetMaxDurationInSecond()
	{
		return this.MaxDuration;
	}

	// Token: 0x0600F6EF RID: 63215 RVA: 0x00439A3A File Offset: 0x00437C3A
	public float GetCurrentRunningTimeInSecond()
	{
		return this.CurrentRunningTime / 1000f;
	}

	// Token: 0x0600F6F0 RID: 63216 RVA: 0x00439A48 File Offset: 0x00437C48
	[NullableContext(0)]
	private UniTask<bool> LoadAudio()
	{
		InfoDisplayAudioPlayerImpl.<LoadAudio>d__25 <LoadAudio>d__;
		<LoadAudio>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LoadAudio>d__.<>4__this = this;
		<LoadAudio>d__.<>1__state = -1;
		<LoadAudio>d__.<>t__builder.Start<InfoDisplayAudioPlayerImpl.<LoadAudio>d__25>(ref <LoadAudio>d__);
		return <LoadAudio>d__.<>t__builder.Task;
	}

	// Token: 0x0600F6F1 RID: 63217 RVA: 0x00439A8C File Offset: 0x00437C8C
	private void InternalPlay()
	{
		if (!this.AudioEventLoaded)
		{
			return;
		}
		if (this.PlayState)
		{
			if (this.PauseState)
			{
				this.ResumeMusic();
			}
			else
			{
				this.PauseMusic();
			}
		}
		else
		{
			if (this.AudioDelegate == null)
			{
				this.AudioDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnAkPostEventCallback>(new Action<EAkCallbackType, UAkCallbackInfo>(this.EndCallBack));
			}
			this.PlayAudio(this.AudioClipPath);
			this.PlayState = true;
			this.PauseState = false;
		}
		if (this.TogglePlay != null)
		{
			this.TogglePlay.SetToggleState(this.PauseState ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked, false, false, false);
		}
		if (this.PauseState)
		{
			if (this.OnPause != null)
			{
				this.OnPause();
				return;
			}
		}
		else if (this.OnPlay != null)
		{
			this.OnPlay();
		}
	}

	// Token: 0x0600F6F2 RID: 63218 RVA: 0x00439B50 File Offset: 0x00437D50
	private void PauseMusic()
	{
		this.PauseState = true;
		UAkAudioEvent audioEvent = Singleton<AudioController>.Instance.GetAudioEvent(this.AudioClipPath, false);
		if (audioEvent != null && this.RootActor != null)
		{
			Singleton<AudioController>.Instance.ExecuteActionOnEvent(audioEvent, EAkActionOnEventType.Pause, this.RootActor);
		}
	}

	// Token: 0x0600F6F3 RID: 63219 RVA: 0x00439B94 File Offset: 0x00437D94
	private void ResumeMusic()
	{
		this.PauseState = false;
		UAkAudioEvent audioEvent = Singleton<AudioController>.Instance.GetAudioEvent(this.AudioClipPath, false);
		if (audioEvent != null && this.RootActor != null)
		{
			Singleton<AudioController>.Instance.ExecuteActionOnEvent(audioEvent, EAkActionOnEventType.Resume, this.RootActor);
		}
	}

	// Token: 0x0600F6F4 RID: 63220 RVA: 0x00439BD8 File Offset: 0x00437DD8
	private void EndCallBack(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
	{
		if (callbackType == EAkCallbackType.EndOfEvent && this.PlayState)
		{
			if (this.RootActor != null)
			{
				Singleton<AudioController>.Instance.StopAudio(this.RootActor);
			}
			if (this.OverrideEndCallBack != null)
			{
				this.OverrideEndCallBack();
			}
			else
			{
				string audioClipPath = this.AudioClipPath;
				if (Singleton<AudioController>.Instance.GetAudioEvent(audioClipPath, false) != null)
				{
					this.PlayAudio(audioClipPath);
				}
			}
			this.CurrentRunningTime = 0f;
		}
	}

	// Token: 0x0600F6F5 RID: 63221 RVA: 0x00439C44 File Offset: 0x00437E44
	[NullableContext(1)]
	private void PlayAudio(string audioPath)
	{
		if (this.RootActor != null)
		{
			Singleton<AudioController>.Instance.PlayAudioByEventPath(audioPath, this.RootActor, new int?(this.PlayFlag), this.AudioDelegate, null, true, "");
		}
	}

	// Token: 0x0600F6F6 RID: 63222 RVA: 0x00439C8B File Offset: 0x00437E8B
	private void RefreshPlayInfo(float deltaTime)
	{
		this.CurrentRunningTime += deltaTime;
		if (this.CurrentRunningTime >= this.MaxDuration * 1000f)
		{
			this.CurrentRunningTime = this.MaxDuration * 1000f;
		}
	}

	// Token: 0x0600F6F7 RID: 63223 RVA: 0x00439CC1 File Offset: 0x00437EC1
	private void ResetSpectrum()
	{
		if (this.RootActor != null)
		{
			Singleton<AudioController>.Instance.StopAudio(this.RootActor);
		}
		this.CurrentRunningTime = 0f;
		this.PlayState = false;
		this.AudioEventLoaded = false;
	}

	// Token: 0x0400773C RID: 30524
	private const int MS_PER_SECOND = 1000;

	// Token: 0x0400773D RID: 30525
	private readonly UUIExtendToggle TogglePlay;

	// Token: 0x0400773E RID: 30526
	private readonly AActor RootActor;

	// Token: 0x0400773F RID: 30527
	private float CurrentRunningTime;

	// Token: 0x04007740 RID: 30528
	private readonly int PlayFlag = 1;

	// Token: 0x04007741 RID: 30529
	private bool PlayState;

	// Token: 0x04007742 RID: 30530
	private float MaxDuration;

	// Token: 0x04007743 RID: 30531
	[Nullable(1)]
	private string AudioClipPath = "";

	// Token: 0x04007744 RID: 30532
	private bool PauseState;

	// Token: 0x04007745 RID: 30533
	private bool AudioEventLoaded;

	// Token: 0x04007746 RID: 30534
	private FOnAkPostEventCallback AudioDelegate;

	// Token: 0x04007747 RID: 30535
	public Action OverrideEndCallBack;

	// Token: 0x04007748 RID: 30536
	public Action OnPlay;

	// Token: 0x04007749 RID: 30537
	public Action OnPause;
}
