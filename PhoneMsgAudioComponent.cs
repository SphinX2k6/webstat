using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.PlotView.PlotComponent;
using UnrealEngine;

// Token: 0x02002554 RID: 9556
[NullableContext(1)]
[Nullable(0)]
public class PhoneMsgAudioComponent
{
	// Token: 0x06012963 RID: 76131 RVA: 0x0051E5C9 File Offset: 0x0051C7C9
	public void Init(PlotTextAudioComponentContext context)
	{
		this.OnAudioStartDelegate = context.OnAudioStartDelegate;
		this.OnAudioEndDelegate = context.OnAudioEndDelegate;
		this.OnAudioLoadTimeoutDelegate = context.OnAudioLoadTimeoutDelegate;
	}

	// Token: 0x06012964 RID: 76132 RVA: 0x0051E5F0 File Offset: 0x0051C7F0
	public bool TryPlayPhoneMessageVoice(ITalkItem talkItem)
	{
		if (this.IsPlaying || this.IsLoading)
		{
			return false;
		}
		PlotAudio? plotAudio = talkItem.PlayVoice.GetValueOrDefault() ? ConfigPlotAudioById.GetConfig(talkItem.TidTalk, true) : null;
		if (plotAudio == null)
		{
			return false;
		}
		string externalSourcesMediaName = ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(plotAudio.Value);
		this.IsLoading = true;
		int id = this.UniqueId;
		AActor target = null;
		this.PlotPlayEventResult = Singleton<AudioSystem>.Instance.PostEvent("play_vo_external_phone_message", target, new PostEventArgs?(new PostEventArgs
		{
			ExternalSourceName = "external_vo_phone_message",
			ExternalSourceMediaName = externalSourcesMediaName,
			CallbackMask = new ECallbackMask?((ECallbackMask)9),
			CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
			{
				this.OnAudioPlayCallback(id, callbackType, callbackInfo);
			}
		}));
		this.AddAudioLoadTimeoutTimer();
		return true;
	}

	// Token: 0x06012965 RID: 76133 RVA: 0x0051E6DC File Offset: 0x0051C8DC
	public void StopAudio()
	{
		this.RemoveAudioLoadTimeoutTimer();
		this.UniqueId++;
		Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
		{
			TransitionDuration = new int?(0)
		}));
		this.PlotPlayEventResult = 0;
		this.IsPlaying = false;
		this.IsLoading = false;
	}

	// Token: 0x06012966 RID: 76134 RVA: 0x0051E740 File Offset: 0x0051C940
	private void AddAudioLoadTimeoutTimer()
	{
		if (this.AudioLoadTimeoutTimer != null)
		{
			return;
		}
		if (this.IsLoading)
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.LZK, "[PlotAudioComponent] 正在加载音频，无法添加音频加载超时定时器", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.IsPlaying)
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.LZK, "[PlotAudioComponent] 正在播放音频，无法添加音频加载超时定时器", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.AudioLoadTimeoutTimer = TimerSystem.GameplayTimeInstance.Delay(new TTimerAction(this.OnAudioLoadTimeout), 3f, null, null, true, 1f);
	}

	// Token: 0x06012967 RID: 76135 RVA: 0x0051E7C9 File Offset: 0x0051C9C9
	private void RemoveAudioLoadTimeoutTimer()
	{
		if (this.AudioLoadTimeoutTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.AudioLoadTimeoutTimer);
			this.AudioLoadTimeoutTimer = null;
		}
	}

	// Token: 0x06012968 RID: 76136 RVA: 0x0051E7EC File Offset: 0x0051C9EC
	private void OnAudioLoadTimeout(float delta)
	{
		Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.LZK, "[PlotAudioComponent] 音频加载超时", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.StopAudio();
		Action onAudioLoadTimeoutDelegate = this.OnAudioLoadTimeoutDelegate;
		if (onAudioLoadTimeoutDelegate == null)
		{
			return;
		}
		onAudioLoadTimeoutDelegate();
	}

	// Token: 0x06012969 RID: 76137 RVA: 0x0051E82B File Offset: 0x0051CA2B
	[NullableContext(2)]
	private void OnAudioPlayCallback(int id, EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
	{
		if (id != this.UniqueId)
		{
			return;
		}
		if (callbackType == EAkCallbackType.EndOfEvent)
		{
			this.OnAudioEnd();
			return;
		}
		if (callbackType == EAkCallbackType.Duration)
		{
			this.OnAudioStart();
		}
	}

	// Token: 0x0601296A RID: 76138 RVA: 0x0051E84B File Offset: 0x0051CA4B
	private void OnAudioStart()
	{
		this.IsLoading = false;
		this.IsPlaying = true;
		this.RemoveAudioLoadTimeoutTimer();
		Action onAudioStartDelegate = this.OnAudioStartDelegate;
		if (onAudioStartDelegate == null)
		{
			return;
		}
		onAudioStartDelegate();
	}

	// Token: 0x0601296B RID: 76139 RVA: 0x0051E871 File Offset: 0x0051CA71
	private void OnAudioEnd()
	{
		this.IsPlaying = false;
		this.UniqueId++;
		Action onAudioEndDelegate = this.OnAudioEndDelegate;
		if (onAudioEndDelegate == null)
		{
			return;
		}
		onAudioEndDelegate();
	}

	// Token: 0x040090EA RID: 37098
	private const float MAX_LOAD_AUDIO_TIME = 3f;

	// Token: 0x040090EB RID: 37099
	public const string PLOT_PHONE_MESSAGE_AUDIO_EVENT = "play_vo_external_phone_message";

	// Token: 0x040090EC RID: 37100
	public const string PLOT_PHONE_MESSAGE_EXTERNAL_SOURCE_NAME = "external_vo_phone_message";

	// Token: 0x040090ED RID: 37101
	public const string PLOT_SILENCE_AUDIO_EVENT = "play_external_silence";

	// Token: 0x040090EE RID: 37102
	public const string PLOT_SILENCE_EXTERNAL_SOURCE_NAME = "external_silence";

	// Token: 0x040090EF RID: 37103
	private int UniqueId;

	// Token: 0x040090F0 RID: 37104
	private int PlotPlayEventResult;

	// Token: 0x040090F1 RID: 37105
	private bool IsPlaying;

	// Token: 0x040090F2 RID: 37106
	private bool IsLoading;

	// Token: 0x040090F3 RID: 37107
	[Nullable(2)]
	private TimerHandle AudioLoadTimeoutTimer;

	// Token: 0x040090F4 RID: 37108
	[Nullable(2)]
	private Action OnAudioStartDelegate;

	// Token: 0x040090F5 RID: 37109
	[Nullable(2)]
	private Action OnAudioEndDelegate;

	// Token: 0x040090F6 RID: 37110
	[Nullable(2)]
	private Action OnAudioLoadTimeoutDelegate;
}
