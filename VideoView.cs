using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.GameSettings;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002CEB RID: 11499
[NullableContext(1)]
[Nullable(0)]
public class VideoView : UiTickViewBase
{
	// Token: 0x060172CB RID: 94923 RVA: 0x0066AA74 File Offset: 0x00668C74
	public VideoView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060172CC RID: 94924 RVA: 0x0066AB04 File Offset: 0x00668D04
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
	}

	// Token: 0x060172CD RID: 94925 RVA: 0x0066ABA0 File Offset: 0x00668DA0
	protected override UniTask OnBeforeStartAsync()
	{
		VideoView.<OnBeforeStartAsync>d__43 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VideoView.<OnBeforeStartAsync>d__43>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060172CE RID: 94926 RVA: 0x0066ABE4 File Offset: 0x00668DE4
	protected override void OnStart()
	{
		base.GetButton(1).RootUIComp.Get().SetUIActive(false);
		this.SkipComp = new PlotSkipComponent(base.GetButton(1), new Action(this.OnSkipCg), null, this, null, null, null);
		this.SkipComp.AddEventListener();
		this.SkipComp.EnableSkipButton(false);
		UMediaTexture umediaTexture = this.CgTexture.GetTexture() as UMediaTexture;
		umediaTexture.AutoClear = false;
		this.MediaPlayer = ((umediaTexture != null) ? umediaTexture.GetMediaPlayer() : null);
		if (this.MediaPlayer == null)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Video, ELogAuthor.ZWY, "获取MediaPlayer异常！！", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.ClearCaptionLines();
		this.BackgroundColor = null;
		IVideoParamHub videoParamHub = this.OpenParam as IVideoParamHub;
		this.Mp4FadeOutTime = ((videoParamHub != null) ? videoParamHub.Mp4FadeOutTime : null).GetValueOrDefault() * 1000f;
		this.BlackBorderFadeOutTime = ((videoParamHub != null) ? videoParamHub.BlackBorderFadeOutTime : null).GetValueOrDefault() * 1000f;
		if (((videoParamHub != null) ? videoParamHub.Mp4BlendAnim : null) != null)
		{
			ControllerBase<PlotBlendController>.Instance.SetupInfo(videoParamHub.Mp4BlendAnim, videoParamHub.VideoDataConf.CgName);
		}
		EMovieBackgroundType? emovieBackgroundType2;
		if (ModelBase<GameModeModel>.Instance.Mp4FadeInScreenColor != null)
		{
			this.BackgroundColor = ModelBase<GameModeModel>.Instance.Mp4FadeInScreenColor;
		}
		else
		{
			EMovieBackgroundType? emovieBackgroundType;
			if (videoParamHub == null)
			{
				emovieBackgroundType = null;
			}
			else
			{
				IMovieBackgroundFadeData backgroundColor = videoParamHub.BackgroundColor;
				emovieBackgroundType = ((backgroundColor != null) ? new EMovieBackgroundType?(backgroundColor.FadeInBackgroundType) : null);
			}
			emovieBackgroundType2 = emovieBackgroundType;
			this.BackgroundColor = new EMovieBackgroundType?(emovieBackgroundType2.GetValueOrDefault(EMovieBackgroundType.Black));
		}
		FLinearColor? flinearColor = null;
		emovieBackgroundType2 = this.BackgroundColor;
		if (emovieBackgroundType2 != null)
		{
			EMovieBackgroundType valueOrDefault = emovieBackgroundType2.GetValueOrDefault();
			if (valueOrDefault == EMovieBackgroundType.White)
			{
				flinearColor = new FLinearColor?(new FLinearColor(1f, 1f, 1f, 1f));
				goto IL_229;
			}
			if (valueOrDefault != EMovieBackgroundType.Black)
			{
			}
		}
		flinearColor = new FLinearColor?(new FLinearColor(0f, 0f, 0f, 1f));
		IL_229:
		this.HasChangeColor = !umediaTexture.ClearColor.Equals(flinearColor);
		umediaTexture.ClearColor = flinearColor.Value;
		float num = Singleton<UiLayer>.Instance.UiRootItem.GetWidth() / Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
		if (ModelBase<PlotModel>.Instance.LastPlotAspect != -1f && num > 1f)
		{
			this.LastAspect = ModelBase<PlotModel>.Instance.LastPlotAspect;
			if ((double)this.LastAspect < 2.3)
			{
				this.LastAspect = num;
			}
			this.SetAspect(this.LastAspect);
		}
		this.LerpFullTime = (float)ConfigCommonParamById.GetIntConfig("VideoViewLerpFullTime").GetValueOrDefault(4000);
		this.LerpWaitTime = (float)ConfigCommonParamById.GetIntConfig("VideoViewLerpWaitTime").GetValueOrDefault(1000);
		this.CurrentQte.Clear();
		this.HasTriggerBlendOut = false;
		this.HasHandledVideoEnd = false;
		this.RemoveSeamlessEndDelayHandle();
	}

	// Token: 0x060172CF RID: 94927 RVA: 0x0066AF18 File Offset: 0x00669118
	private void SetAspect(float videoAspect)
	{
		float num = Singleton<UiLayer>.Instance.UiRootItem.GetWidth() / Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
		if (videoAspect < num)
		{
			float width = Singleton<UiLayer>.Instance.UiRootItem.GetHeight() * videoAspect;
			this.CgTexture.SetWidth(width);
			this.CgTexture.SetHeight(Singleton<UiLayer>.Instance.UiRootItem.GetHeight());
			return;
		}
		if (videoAspect > num)
		{
			float height = Singleton<UiLayer>.Instance.UiRootItem.GetWidth() / videoAspect;
			this.CgTexture.SetHeight(height);
			this.CgTexture.SetWidth(Singleton<UiLayer>.Instance.UiRootItem.GetWidth());
		}
	}

	// Token: 0x060172D0 RID: 94928 RVA: 0x0066AFC0 File Offset: 0x006691C0
	protected override UniTask OnPlayingStartSequenceAsync()
	{
		VideoView.<OnPlayingStartSequenceAsync>d__46 <OnPlayingStartSequenceAsync>d__;
		<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingStartSequenceAsync>d__.<>4__this = this;
		<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
		<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<VideoView.<OnPlayingStartSequenceAsync>d__46>(ref <OnPlayingStartSequenceAsync>d__);
		return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060172D1 RID: 94929 RVA: 0x0066B003 File Offset: 0x00669203
	protected override void OnAfterShow()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.VideoViewShow);
		Singleton<LoadModeManager>.Instance.SetLoadModeByReason(ELoadMode.ForceInGame, ELoadModeReason.VideoView);
		this.IsViewClosed = false;
		this.OnShowVideo();
	}

	// Token: 0x060172D2 RID: 94930 RVA: 0x0066B030 File Offset: 0x00669230
	private void CleanVideo()
	{
		if (this.CaptionTimerId != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.CaptionTimerId);
			this.CaptionTimerId = null;
		}
		if (this.LoadHandle != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadHandle);
			this.LoadHandle = -1;
		}
		(this.CgTexture.GetTexture() as UMediaTexture).AutoClear = true;
		this.VideoName = null;
		UMediaPlayer mediaPlayer = this.MediaPlayer;
		if (mediaPlayer != null)
		{
			mediaPlayer.OnEndReached.Remove(new Action(this.OnVideoEnd));
		}
		UMediaPlayer mediaPlayer2 = this.MediaPlayer;
		if (mediaPlayer2 != null)
		{
			mediaPlayer2.OnMediaOpened.Remove(new Action<string>(this.OnMediaOpen));
		}
		UMediaPlayer mediaPlayer3 = this.MediaPlayer;
		if (mediaPlayer3 != null)
		{
			mediaPlayer3.OnMediaOpenFailed.Remove(new Action<string>(this.OnVideoOpenFailed));
		}
		UMediaPlayer mediaPlayer4 = this.MediaPlayer;
		if (mediaPlayer4 != null)
		{
			mediaPlayer4.Close();
		}
		this.MediaPlayer = null;
		this.CaptionDataList = null;
		this.VideoPauseTime = null;
		this.RunningState = false;
		this.RemoveSeamlessEndDelayHandle();
		if (!this.IsPlayToEnd)
		{
			foreach (VideoSoundPlay videoSoundPlay in this.VideoSoundPlays)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(videoSoundPlay.Handle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(0)
				}));
			}
			this.StopAllSubtitleVoices();
		}
		this.VideoSoundPlays.Clear();
		this.PendingVideoSounds.Clear();
		this.SubtitleVoicePlays.Clear();
		Singleton<AudioSystem>.Instance.SetState("plot_video", "none", true);
		this.ClearCaptionLines();
		PlotSkipComponent skipComp = this.SkipComp;
		if (skipComp != null)
		{
			skipComp.OnClear();
		}
		PlotSkipComponent skipComp2 = this.SkipComp;
		if (skipComp2 != null)
		{
			skipComp2.RemoveEventListener();
		}
		this.SkipComp = null;
	}

	// Token: 0x060172D3 RID: 94931 RVA: 0x0066B214 File Offset: 0x00669414
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.VideoViewHide, this.IsPlayToEnd);
		foreach (CommonQteContextBase commonQteContextBase in this.CurrentQte)
		{
			ControllerBase<CommonQteController>.Instance.StopQte(commonQteContextBase.HandleId);
		}
		this.CurrentQte.Clear();
		Singleton<LoadModeManager>.Instance.ResetLoadModeByReason(ELoadModeReason.VideoView);
		this.SkipComp.EnableSkipButton(false);
		ModelBase<GameModeModel>.Instance.Mp4FadeInScreenColor = null;
		ModelBase<GameModeModel>.Instance.Mp4FadeOutScreenColor = null;
		this.BackgroundColor = null;
	}

	// Token: 0x060172D4 RID: 94932 RVA: 0x0066B2DC File Offset: 0x006694DC
	protected override void OnBeforeDestroy()
	{
		if (!this.IsViewClosed)
		{
			this.RenderSetup(false);
			this.TryExecuteBlendAnim();
		}
		this.CleanVideo();
		IVideoParamHub videoParamHub = this.OpenParam as IVideoParamHub;
		Action action = (videoParamHub != null) ? videoParamHub.VideoCloseCb : null;
		if (action == null)
		{
			return;
		}
		action();
	}

	// Token: 0x060172D5 RID: 94933 RVA: 0x0066B31C File Offset: 0x0066951C
	protected override UniTask OnPlayingCloseSequenceAsync()
	{
		VideoView.<OnPlayingCloseSequenceAsync>d__51 <OnPlayingCloseSequenceAsync>d__;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
		<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<VideoView.<OnPlayingCloseSequenceAsync>d__51>(ref <OnPlayingCloseSequenceAsync>d__);
		return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060172D6 RID: 94934 RVA: 0x0066B35F File Offset: 0x0066955F
	protected override void OnAfterDestroy()
	{
		if (this.HasTriggerBlendOut)
		{
			Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("VideoView.TriggerBlendOut");
		}
		this.ReleaseSeamlessEndTimeDilationTag();
	}

	// Token: 0x060172D7 RID: 94935 RVA: 0x0066B37E File Offset: 0x0066957E
	private void OnSkipCg()
	{
		ControllerBase<FlowController>.Instance.BackgroundFlow("UI点击跳过(VideoView)", true, false, false);
	}

	// Token: 0x060172D8 RID: 94936 RVA: 0x0066B394 File Offset: 0x00669594
	protected override void OnAddEventListener()
	{
		Singleton<Application>.Instance.AddApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasReactivatedDelegate, new Action(this.ResumeVideo));
		Singleton<Application>.Instance.AddApplicationHandler(EApplicationLifetimeDelegate.ApplicationWillDeactivateDelegate, new Action(this.PauseVideo));
		Singleton<EventSystem>.Instance.Add<IVideoParamHub>(EEventName.PlayVideo, new Action<IVideoParamHub>(this.OnPlayVideo));
		Singleton<EventSystem>.Instance.Add(EEventName.UIViewPortSizeChanged, new Action(this.OnUiViewPortSizeChanged));
	}

	// Token: 0x060172D9 RID: 94937 RVA: 0x0066B404 File Offset: 0x00669604
	private void OnPlayVideo(IVideoParamHub param)
	{
		this.OpenParam = param;
		this.OnStart();
		this.IsViewClosed = false;
		this.OnShowVideo();
	}

	// Token: 0x060172DA RID: 94938 RVA: 0x0066B420 File Offset: 0x00669620
	private void OnUiViewPortSizeChanged()
	{
		if (!this.RunningState || this.IsViewClosed || this.MediaPlayer == null || this.CgTexture == null || this.VideoName == null)
		{
			return;
		}
		this.SizeSelfAdaption();
		this.BlendOutRatio = this.CgTexture.GetWidth() / this.CgTexture.GetHeight();
	}

	// Token: 0x060172DB RID: 94939 RVA: 0x0066B47C File Offset: 0x0066967C
	private void ResumeVideo()
	{
		this.RunningState = true;
		if (this.VideoPauseTime != null)
		{
			if (Singleton<Info>.Instance.PlatformType != ESourcePlatformType.Android && Singleton<Info>.Instance.PlatformType != ESourcePlatformType.OpenHarmony && Singleton<Info>.Instance.PlatformType != ESourcePlatformType.PS5)
			{
				UMediaPlayer mediaPlayer = this.MediaPlayer;
				if (mediaPlayer != null)
				{
					mediaPlayer.Seek(this.VideoPauseTime);
				}
			}
			UMediaPlayer mediaPlayer2 = this.MediaPlayer;
			if (mediaPlayer2 != null)
			{
				mediaPlayer2.Play();
			}
			this.VideoPauseTime = null;
		}
		if (this.VideoName == null || this.VideoPauseTime == null)
		{
			return;
		}
		Singleton<global::Log>.Instance.Info(ELogModule.Audio, ELogAuthor.YJY, "[VideoView] ResumeVideo 当前只绑定返回应用，全部音频已在CPP的返回应用时处理，跳过此处的音频 Resume", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.CaptionTimerId != null && TimerSystem.GameplayTimeInstance.IsPause(this.CaptionTimerId))
		{
			TimerSystem.GameplayTimeInstance.Resume(this.CaptionTimerId);
		}
	}

	// Token: 0x060172DC RID: 94940 RVA: 0x0066B558 File Offset: 0x00669758
	private void PauseVideo()
	{
		UMediaPlayer mediaPlayer = this.MediaPlayer;
		this.VideoPauseTime = ((mediaPlayer != null) ? mediaPlayer.GetTime() : null);
		this.RunningState = false;
		if (Singleton<Info>.Instance.PlatformType != ESourcePlatformType.Android && Singleton<Info>.Instance.PlatformType != ESourcePlatformType.OpenHarmony && Singleton<Info>.Instance.PlatformType != ESourcePlatformType.PS5)
		{
			UMediaPlayer mediaPlayer2 = this.MediaPlayer;
			if (mediaPlayer2 != null)
			{
				mediaPlayer2.Pause();
			}
		}
		if (string.IsNullOrEmpty(this.VideoName) || this.VideoSoundPlays.Count == 0)
		{
			return;
		}
		Singleton<global::Log>.Instance.Info(ELogModule.Audio, ELogAuthor.YJY, "[VideoView] PauseVideo 当前只绑定切换后台，全部音频已在CPP的切换后台时处理，跳过此处的音频 Pause", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.CaptionTimerId != null && !TimerSystem.GameplayTimeInstance.IsPause(this.CaptionTimerId))
		{
			TimerSystem.GameplayTimeInstance.Pause(this.CaptionTimerId, null);
		}
	}

	// Token: 0x060172DD RID: 94941 RVA: 0x0066B624 File Offset: 0x00669824
	protected override void OnRemoveEventListener()
	{
		Singleton<Application>.Instance.RemoveApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasReactivatedDelegate, new Action(this.ResumeVideo));
		Singleton<Application>.Instance.RemoveApplicationHandler(EApplicationLifetimeDelegate.ApplicationWillDeactivateDelegate, new Action(this.PauseVideo));
		Singleton<EventSystem>.Instance.Remove<IVideoParamHub>(EEventName.PlayVideo, new Action<IVideoParamHub>(this.OnPlayVideo));
		Singleton<EventSystem>.Instance.Remove(EEventName.UIViewPortSizeChanged, new Action(this.OnUiViewPortSizeChanged));
	}

	// Token: 0x060172DE RID: 94942 RVA: 0x0066B694 File Offset: 0x00669894
	private void CloseMeInternal()
	{
		bool? remainViewWhenEnd = (this.OpenParam as IVideoParamHub).RemainViewWhenEnd;
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Video;
		ELogAuthor author = ELogAuthor.ZWY;
		string message = "开始关闭VideoView";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bRemain", remainViewWhenEnd);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (!this.HasTriggerBlendOut)
		{
			this.RenderSetup(false);
			this.TryExecuteBlendAnim();
		}
		if (this.PlayStateTimeCheckHandle != null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Video, ELogAuthor.ZWY, "MediaPlayer还在倒计时检查状态中,提前移除TimeTimer", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.PlayStateTimeCheckHandle.Remove();
			this.PlayStateTimeCheckHandle = null;
		}
		if (this.PlayStateFrameCheckHandle != null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Video, ELogAuthor.ZWY, "MediaPlayer还在倒计时检查状态中,提前移除FrameTimer", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.PlayStateFrameCheckHandle.Remove();
			this.PlayStateFrameCheckHandle = null;
		}
		if (this.PlayLerpHandle != null)
		{
			this.PlayLerpHandle.Remove();
			this.PlayLerpHandle = null;
		}
		this.SetBackgroundColorOut();
		if (!remainViewWhenEnd.GetValueOrDefault())
		{
			if (!this.IsViewClosed)
			{
				base.CloseMe(null);
			}
			this.IsViewClosed = true;
			ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.CG, null, null, null);
			return;
		}
		this.CleanVideo();
		this.ReleaseSeamlessEndTimeDilationTag();
		IVideoParamHub videoParamHub = this.OpenParam as IVideoParamHub;
		Action action = (videoParamHub != null) ? videoParamHub.VideoCloseCb : null;
		if (action == null)
		{
			return;
		}
		action();
	}

	// Token: 0x060172DF RID: 94943 RVA: 0x0066B7F0 File Offset: 0x006699F0
	private unsafe void HandleVideoEnd(string source, float? playTime = null)
	{
		if (this.HasHandledVideoEnd)
		{
			return;
		}
		this.HasHandledVideoEnd = true;
		this.IsPlayToEnd = true;
		UMediaPlayer mediaPlayer = this.MediaPlayer;
		if (mediaPlayer != null)
		{
			mediaPlayer.OnEndReached.Remove(new Action(this.OnVideoEnd));
		}
		this.CloseMeInternal();
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Video;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "视频播放结束";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("视频名称", this.VideoName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("source", source);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("playTime", playTime);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x060172E0 RID: 94944 RVA: 0x0066B8B4 File Offset: 0x00669AB4
	private void OnVideoEnd()
	{
		IVideoParamHub videoParamHub = this.OpenParam as IVideoParamHub;
		if (videoParamHub != null && videoParamHub.SeamlessEndOnTick.GetValueOrDefault())
		{
			this.DelaySeamlessEndAfterTimeDilationRelease("OnEndReachedDelayFrame");
			return;
		}
		this.HandleVideoEnd("OnEndReached", null);
	}

	// Token: 0x060172E1 RID: 94945 RVA: 0x0066B904 File Offset: 0x00669B04
	private void OnVideoOpenFailed(string _)
	{
		Singleton<global::Log>.Instance.Error(ELogModule.Video, ELogAuthor.ZWY, "视频文件打开失败,可能需要修复修复系统文件", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.CloseMeInternal();
	}

	// Token: 0x060172E2 RID: 94946 RVA: 0x0066B938 File Offset: 0x00669B38
	private void OnShowVideo()
	{
		if (this.VideoName != null)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Video, ELogAuthor.ZWY, "必须等上个视频放完才能放下一个", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.CloseMeInternal();
			return;
		}
		if (this.OpenParam == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Video;
			ELogAuthor author = ELogAuthor.ZWY;
			string message = "事件被错误触发了";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("名称", EEventName.ShowVideo);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.CloseMeInternal();
			return;
		}
		VideoData videoData = (this.OpenParam as IVideoParamHub).VideoDataConf;
		float aspect = videoData.Aspect;
		float num = Singleton<UiLayer>.Instance.UiRootItem.GetWidth() / Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
		float lastPlotAspect = ModelBase<PlotModel>.Instance.LastPlotAspect;
		int lastPlotColor = ModelBase<PlotModel>.Instance.LastPlotColor;
		int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.FlowAdaptation, true, true);
		if (num > 1f && lastPlotAspect != -1f && (double)aspect > 2.3 != (double)lastPlotAspect > 2.3 && lastPlotColor == 0)
		{
			EMovieBackgroundType? backgroundColor = this.BackgroundColor;
			EMovieBackgroundType emovieBackgroundType = EMovieBackgroundType.White;
			if ((backgroundColor.GetValueOrDefault() == emovieBackgroundType & backgroundColor != null) && currentValue != null)
			{
				this.NowAspect = aspect;
				if ((double)this.NowAspect < 2.3)
				{
					this.NowAspect = num;
				}
				this.IsLerp = true;
				this.LerpNowTime = 0f;
				this.PlayLerpHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					this.PlayLerpHandle = null;
					this.PlayVideo(videoData);
				}, this.LerpFullTime, null, null, true, 1f);
				return;
			}
		}
		this.PlayVideo(videoData);
	}

	// Token: 0x060172E3 RID: 94947 RVA: 0x0066BB00 File Offset: 0x00669D00
	private unsafe void PlayVideo(VideoData videoData)
	{
		if (ModelBase<GameModeModel>.Instance.NeedOpenBlackScreenWhenTeleportDungeon)
		{
			LevelLoadingController instance = ControllerBase<LevelLoadingController>.Instance;
			ELoadingReason reason = ELoadingReason.Common;
			ELoadingPerform perform = ELoadingPerform.CameraFade;
			string context = "PlayVideo_" + videoData.CgName;
			Action callback = null;
			object[] array = new object[6];
			array[0] = 1f;
			int num = 1;
			EMovieBackgroundType? mp4FadeOutScreenColor = ModelBase<GameModeModel>.Instance.Mp4FadeOutScreenColor;
			EMovieBackgroundType emovieBackgroundType = EMovieBackgroundType.White;
			array[num] = ((mp4FadeOutScreenColor.GetValueOrDefault() == emovieBackgroundType & mp4FadeOutScreenColor != null) ? EFadeInScreenShowType.White : EFadeInScreenShowType.Black);
			array[2] = false;
			array[3] = false;
			array[5] = true;
			instance.OpenLoading<ELoadingPerform>(reason, perform, context, callback, array);
		}
		this.RenderSetup(true);
		this.IsLerp = false;
		TTimerAction <>9__3;
		this.LoadHandle = Singleton<ResourceSystem>.Instance.LoadAsync<UMediaSource>(videoData.CgFile, delegate([Nullable(2)] UMediaSource mediaSource, string _)
		{
			this.LoadHandle = -1;
			if (mediaSource == null)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Video;
				ELogAuthor author2 = ELogAuthor.ZWY;
				string message2 = "mediaSource加载失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("配置名称", videoData.CgName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("视频路径", videoData.CgFile);
				instance3.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				this.CloseMeInternal();
				return;
			}
			this.VideoName = videoData.CgName;
			this.ClearCaptionLines();
			bool enable = !ModelBase<GameModeModel>.Instance.PlayTravelMp4 && (ModelBase<PlotModel>.Instance.IsGmCanSkip || videoData.CanSkip);
			ControllerBase<FlowController>.Instance.EnableSkip(enable);
			this.CaptionDataList = new List<VideoSubtitle>(ConfigBase<VideoConfig>.Instance.GetVideoCaptions(this.VideoName, Singleton<LanguageSystem>.Instance.PackageAudio));
			this.CaptionDataList.Sort((VideoSubtitle a, VideoSubtitle b) => b.ShowMoment.CompareTo(a.ShowMoment));
			this.QteDataList = new List<VideoQteConfig>(ConfigBase<VideoConfig>.Instance.GetVideoQte(this.VideoName, Singleton<LanguageSystem>.Instance.PackageAudio));
			this.QteDataList.Sort((VideoQteConfig a, VideoQteConfig b) => b.ShowMoment.CompareTo(a.ShowMoment));
			this.MediaPlayer.OnEndReached.Add(new Action(this.OnVideoEnd));
			this.MediaPlayer.OnMediaOpened.Add(new Action<string>(this.OnMediaOpen));
			this.MediaPlayer.OnMediaOpenFailed.Add(new Action<string>(this.OnVideoOpenFailed));
			bool flag = ModelBase<PreloadModelNew>.Instance.PlotAssetManager.HasPreloadVideo(videoData.CgFile);
			if (flag)
			{
				if (this.MediaPlayer.Play())
				{
					this.OnMediaOpen(null);
				}
				else
				{
					global::Log instance4 = Singleton<global::Log>.Instance;
					ELogModule module3 = ELogModule.Video;
					ELogAuthor author3 = ELogAuthor.ZWY;
					string message3 = "预加载的视频播放失败，等待Open回调";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("配置名称", videoData.CgName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("视频路径", videoData.CgFile);
					instance4.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
				}
			}
			else
			{
				this.MediaPlayer.PlayOnOpen = false;
				if (!this.MediaPlayer.OpenSource(mediaSource))
				{
					global::Log instance5 = Singleton<global::Log>.Instance;
					ELogModule module4 = ELogModule.Video;
					ELogAuthor author4 = ELogAuthor.ZWY;
					string message4 = "打开视频失败";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("配置名称", videoData.CgName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("视频路径", videoData.CgFile);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("hasPreload", flag);
					instance5.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 3));
					this.CloseMeInternal();
					return;
				}
			}
			Singleton<AudioSystem>.Instance.SetState("plot_video", "playing", true);
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.VideoStart, this.VideoName);
			int frameTime = Singleton<Time>.Instance.Frame;
			VideoView <>4__this = this;
			TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
			TTimerAction action;
			if ((action = <>9__3) == null)
			{
				action = (<>9__3 = delegate(float _)
				{
					TimerHandle playStateTimeCheckHandle = this.PlayStateTimeCheckHandle;
					if (playStateTimeCheckHandle != null)
					{
						playStateTimeCheckHandle.Remove();
					}
					this.PlayStateTimeCheckHandle = null;
					if (this.MediaPlayer == null)
					{
						Singleton<global::Log>.Instance.Warn(ELogModule.Video, ELogAuthor.ZWY, "MediaPlayer已经没有了", default(ReadOnlySpan<ValueTuple<string, object>>));
						return;
					}
					if (this.MediaPlayer.IsPlaying() || this.MediaPlayer.IsPaused())
					{
						if (this.PlayStateFrameCheckHandle == null)
						{
							this.SetBackgroundColorOut();
						}
						return;
					}
					if (this.PlayStateFrameCheckHandle == null)
					{
						global::Log instance6 = Singleton<global::Log>.Instance;
						ELogModule module5 = ELogModule.Video;
						ELogAuthor author5 = ELogAuthor.JYS;
						string message5 = "MediaPlayer加载了5秒超时，强制关闭CG界面";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("配置名称", videoData.CgName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("视频路径", videoData.CgFile);
						instance6.Warn(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 2));
						this.CloseMeInternal();
					}
				});
			}
			<>4__this.PlayStateTimeCheckHandle = gameplayTimeInstance.Delay(action, 5000f, null, null, true, 1f);
			this.PlayStateFrameCheckHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				if (Singleton<Time>.Instance.Frame - frameTime >= 30)
				{
					TimerHandle playStateFrameCheckHandle = this.PlayStateFrameCheckHandle;
					if (playStateFrameCheckHandle != null)
					{
						playStateFrameCheckHandle.Remove();
					}
					this.PlayStateFrameCheckHandle = null;
					if (this.MediaPlayer == null)
					{
						Singleton<global::Log>.Instance.Warn(ELogModule.Video, ELogAuthor.ZWY, "MediaPlayer已经没有了", default(ReadOnlySpan<ValueTuple<string, object>>));
						return;
					}
					if (this.MediaPlayer.IsPlaying() || this.MediaPlayer.IsPaused())
					{
						if (this.PlayStateTimeCheckHandle == null)
						{
							this.SetBackgroundColorOut();
						}
						return;
					}
					if (this.PlayStateTimeCheckHandle == null)
					{
						global::Log instance6 = Singleton<global::Log>.Instance;
						ELogModule module5 = ELogModule.Video;
						ELogAuthor author5 = ELogAuthor.JYS;
						string message5 = "MediaPlayer加载了5秒超时，强制关闭CG界面";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("配置名称", videoData.CgName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("视频路径", videoData.CgFile);
						instance6.Warn(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 2));
						this.CloseMeInternal();
					}
				}
			}, 1000f, 1f, null, null, true);
		}, 100, "js_undefined");
		if (this.LoadHandle < 0)
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Video;
			ELogAuthor author = ELogAuthor.ZWY;
			string message = "mediaSource加载失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("配置名称", videoData.CgName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("视频路径", videoData.CgFile);
			instance2.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.CloseMeInternal();
		}
	}

	// Token: 0x060172E4 RID: 94948 RVA: 0x0066BC60 File Offset: 0x00669E60
	[NullableContext(2)]
	private void OnMediaOpen(string _)
	{
		this.VideoSoundPlays.Clear();
		this.PendingVideoSounds.Clear();
		this.SubtitleVoicePlays.Clear();
		if (this.VideoName != null)
		{
			foreach (VideoSound soundConf in ConfigBase<VideoConfig>.Instance.GetVideoSounds(this.VideoName))
			{
				if (soundConf.StartMoment == 0f)
				{
					this.PlayVideoSound(soundConf);
				}
				else
				{
					this.PendingVideoSounds.Add(new PendingVideoSound(soundConf, (double)(soundConf.StartMoment * 1000f)));
				}
			}
			this.PendingVideoSounds.Sort(delegate(PendingVideoSound a, PendingVideoSound b)
			{
				if (b.StartMomentMs - a.StartMomentMs <= 0.0)
				{
					return -1;
				}
				return 1;
			});
		}
		this.SizeSelfAdaption();
		this.SourceLength = UKismetMathLibrary.GetTotalMilliseconds(this.MediaPlayer.GetDuration());
		this.BlendOutRatio = this.CgTexture.GetWidth() / this.CgTexture.GetHeight();
		this.RunningState = true;
		this.MediaPlayer.Play();
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Video;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "监听到Open回调，视频播放开始";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("视频名称", this.VideoName);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x060172E5 RID: 94949 RVA: 0x0066BDB8 File Offset: 0x00669FB8
	private void PlayVideoSound(VideoSound soundConf)
	{
		string eventName = Singleton<AudioSystem>.Instance.parseAudioEventPath(soundConf.EventPath);
		if (string.IsNullOrEmpty(eventName))
		{
			return;
		}
		int startMomentMs = (soundConf.StartMoment < 0f) ? 0 : ((int)(soundConf.StartMoment * 1000f));
		bool hasSynced = false;
		int handle = 0;
		handle = Singleton<AudioSystem>.Instance.PostEvent(eventName, null, new PostEventArgs?(new PostEventArgs
		{
			CallbackMask = new ECallbackMask?(ECallbackMask.Duration),
			CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
			{
				if (callbackType != EAkCallbackType.Duration | hasSynced)
				{
					return;
				}
				hasSynced = true;
				this.SyncVideoSoundOnce(eventName, handle, startMomentMs, ((UAkDurationCallbackInfo)callbackInfo).Duration);
			}
		}));
		if (handle == 0)
		{
			return;
		}
		int num = (soundConf.EndMoment < 0f) ? -1 : ((int)(soundConf.EndMoment * 1000f));
		this.VideoSoundPlays.Add(new VideoSoundPlay(handle, (double)num));
		this.VideoSoundPlays.Sort(delegate(VideoSoundPlay a, VideoSoundPlay b)
		{
			if (b.EndMomentMs - a.EndMomentMs <= 0.0)
			{
				return -1;
			}
			return 1;
		});
	}

	// Token: 0x060172E6 RID: 94950 RVA: 0x0066BEDC File Offset: 0x0066A0DC
	private unsafe void SyncVideoSoundOnce(string eventName, int handle, int startMomentMs, float audioDurationMs)
	{
		if (this.IsViewClosed || !this.RunningState || this.MediaPlayer == null)
		{
			return;
		}
		float totalMilliseconds = UKismetMathLibrary.GetTotalMilliseconds(this.MediaPlayer.GetTime());
		float num = totalMilliseconds - (float)startMomentMs;
		if (num < 200f)
		{
			return;
		}
		if (audioDurationMs > 0f && num >= audioDurationMs)
		{
			return;
		}
		Singleton<AudioSystem>.Instance.SeekOnEvent(eventName, (int)num, new SeekOnEventArgs?(new SeekOnEventArgs
		{
			Handle = new int?(handle)
		}));
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Video;
		ELogAuthor author = ELogAuthor.FZX;
		string message = "视频主音轨起播延迟，已Seek对齐";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("eventName", eventName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("delayMs", num);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("playTime", totalMilliseconds);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x060172E7 RID: 94951 RVA: 0x0066BFD0 File Offset: 0x0066A1D0
	private unsafe void TryPlaySubtitleVoice(VideoSubtitle caption)
	{
		if (!caption.IsPlaySubtitleVoice)
		{
			return;
		}
		PlotAudio? config = ConfigPlotAudioById.GetConfig(caption.CaptionText, true);
		if (config == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Video;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "字幕跟随语音找不到剧情语音配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("captionId", caption.CaptionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("captionText", caption.CaptionText);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		string externalSourcesMediaName = ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(config.Value);
		int handle = 0;
		handle = Singleton<AudioSystem>.Instance.PostEvent("play_external_vo_video_subtitle_level_b", null, new PostEventArgs?(new PostEventArgs
		{
			ExternalSourceName = "vo_video_subtitle_level_b",
			ExternalSourceMediaName = externalSourcesMediaName,
			CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
			CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo _)
			{
				if (callbackType == EAkCallbackType.EndOfEvent)
				{
					int num = this.SubtitleVoicePlays.IndexOf(handle);
					if (num >= 0)
					{
						this.SubtitleVoicePlays.RemoveAt(num);
					}
				}
			}
		}));
		if (handle == 0)
		{
			return;
		}
		this.SubtitleVoicePlays.Add(handle);
	}

	// Token: 0x060172E8 RID: 94952 RVA: 0x0066C0FC File Offset: 0x0066A2FC
	private void StopAllSubtitleVoices()
	{
		foreach (int handle in this.SubtitleVoicePlays)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(handle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(0)
			}));
		}
		this.SubtitleVoicePlays.Clear();
	}

	// Token: 0x060172E9 RID: 94953 RVA: 0x0066C17C File Offset: 0x0066A37C
	private void SizeSelfAdaption()
	{
		float videoTrackAspectRatio = this.MediaPlayer.GetVideoTrackAspectRatio(0, 0);
		float num = Singleton<UiLayer>.Instance.UiRootItem.GetWidth() / Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
		int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.FlowAdaptation, true, true);
		if (videoTrackAspectRatio < num)
		{
			float height = Singleton<UiLayer>.Instance.UiRootItem.GetWidth() / videoTrackAspectRatio;
			this.CgTexture.SetHeight(height);
			this.CgTexture.SetWidth(Singleton<UiLayer>.Instance.UiRootItem.GetWidth());
			if ((double)num > 2.38 && currentValue != null)
			{
				float width = Singleton<UiLayer>.Instance.UiRootItem.GetHeight() * videoTrackAspectRatio;
				this.CgTexture.SetWidth(width);
				this.CgTexture.SetHeight(Singleton<UiLayer>.Instance.UiRootItem.GetHeight());
			}
		}
		else if (videoTrackAspectRatio > num)
		{
			float width2 = Singleton<UiLayer>.Instance.UiRootItem.GetHeight() * videoTrackAspectRatio;
			this.CgTexture.SetWidth(width2);
			this.CgTexture.SetHeight(Singleton<UiLayer>.Instance.UiRootItem.GetHeight());
		}
		if ((double)videoTrackAspectRatio > 2.3 && currentValue != null)
		{
			if (videoTrackAspectRatio < num)
			{
				float width3 = Singleton<UiLayer>.Instance.UiRootItem.GetHeight() * videoTrackAspectRatio;
				this.CgTexture.SetWidth(width3);
				this.CgTexture.SetHeight(Singleton<UiLayer>.Instance.UiRootItem.GetHeight());
			}
			else if (videoTrackAspectRatio > num)
			{
				float height2 = Singleton<UiLayer>.Instance.UiRootItem.GetWidth() / videoTrackAspectRatio;
				this.CgTexture.SetHeight(height2);
				this.CgTexture.SetWidth(Singleton<UiLayer>.Instance.UiRootItem.GetWidth());
			}
		}
		ModelBase<PlotModel>.Instance.LastPlotAspect = videoTrackAspectRatio;
		if (currentValue != null)
		{
			ControllerBase<BlackScreenFadeController>.Instance.ChangeAspect(ModelBase<PlotModel>.Instance.LastPlotAspect, new bool?(true));
		}
		PlotModel instance = ModelBase<PlotModel>.Instance;
		EMovieBackgroundType? backgroundColor = this.BackgroundColor;
		EMovieBackgroundType emovieBackgroundType = EMovieBackgroundType.White;
		instance.LastPlotColor = ((!(backgroundColor.GetValueOrDefault() == emovieBackgroundType & backgroundColor != null)) ? 1 : 0);
	}

	// Token: 0x060172EA RID: 94954 RVA: 0x0066C38C File Offset: 0x0066A58C
	private void ClearCaptionLines()
	{
		for (int i = 0; i < this.CaptionLines.Length; i++)
		{
			this.CaptionLines[i] = null;
			UUIText text = base.GetText((int)this.CaptionLineComponents[i]);
			if (text != null)
			{
				text.SetUIActive(false);
			}
		}
	}

	// Token: 0x060172EB RID: 94955 RVA: 0x0066C3D0 File Offset: 0x0066A5D0
	private void ShowCaptionTick(float playTime)
	{
		for (int i = 0; i < this.CaptionLines.Length; i++)
		{
			VideoSubtitle videoSubtitle = this.CaptionLines[i];
			if (videoSubtitle != null)
			{
				float num = (float)(videoSubtitle.ShowMoment + videoSubtitle.Duration) * VideoUtils.MillisecondPerFrame;
				if (playTime > num)
				{
					this.CaptionLines[i] = null;
					base.GetText((int)this.CaptionLineComponents[i]).SetUIActive(false);
				}
			}
		}
		if (this.CaptionDataList == null || this.CaptionDataList.Count == 0)
		{
			return;
		}
		while (this.CaptionDataList.Count > 0)
		{
			VideoSubtitle videoSubtitle2 = this.CaptionDataList[this.CaptionDataList.Count - 1];
			float num2 = (float)(videoSubtitle2.ShowMoment + videoSubtitle2.Duration) * VideoUtils.MillisecondPerFrame;
			if (playTime > num2)
			{
				this.CaptionDataList.RemoveAt(this.CaptionDataList.Count - 1);
			}
			else
			{
				float num3 = (float)videoSubtitle2.ShowMoment * VideoUtils.MillisecondPerFrame;
				if (playTime < num3)
				{
					break;
				}
				int num4 = Array.IndexOf<VideoSubtitle>(this.CaptionLines, null);
				if (num4 < 0)
				{
					num4 = ((this.CaptionLines[0].ShowMoment > this.CaptionLines[1].ShowMoment) ? 1 : 0);
				}
				this.CaptionDataList.RemoveAt(this.CaptionDataList.Count - 1);
				this.CaptionLines[num4] = videoSubtitle2;
				UUIText text = base.GetText((int)this.CaptionLineComponents[num4]);
				string videoCaptionText = ConfigBase<VideoConfig>.Instance.GetVideoCaptionText(videoSubtitle2);
				text.SetUIActive(true);
				text.SetText(videoCaptionText, true);
				this.TryPlaySubtitleVoice(videoSubtitle2);
			}
		}
	}

	// Token: 0x060172EC RID: 94956 RVA: 0x0066C54C File Offset: 0x0066A74C
	private void ShowQte(float playTime)
	{
		if (this.QteDataList == null || this.QteDataList.Count == 0)
		{
			return;
		}
		while (this.QteDataList.Count > 0)
		{
			VideoQteConfig videoQteConfig = this.QteDataList[this.QteDataList.Count - 1];
			float num = (float)videoQteConfig.ShowMoment * VideoUtils.MillisecondPerFrame;
			if (playTime < num)
			{
				break;
			}
			CommonQteContextBase commonQteContextBase = ControllerBase<CommonQteController>.Instance.StartQte(videoQteConfig.QteId, new TCommonQteCallback(this.OnQteEnd), new TCommonQteCallback(this.OnQteEnd), EQteSource.CG, null);
			if (commonQteContextBase != null)
			{
				this.CurrentQte.Add(commonQteContextBase);
				float timeDilation = commonQteContextBase.Config.BaseConfig.TimeDilation;
				this.MediaPlayer.SetRate(timeDilation);
			}
			this.QteDataList.RemoveAt(this.QteDataList.Count - 1);
		}
	}

	// Token: 0x060172ED RID: 94957 RVA: 0x0066C622 File Offset: 0x0066A822
	[NullableContext(2)]
	private void OnQteEnd(CommonQteContextBase context = null)
	{
		UMediaPlayer mediaPlayer = this.MediaPlayer;
		if (mediaPlayer != null)
		{
			mediaPlayer.SetRate(1f);
		}
		if (context != null)
		{
			this.CurrentQte.Remove(context);
		}
	}

	// Token: 0x060172EE RID: 94958 RVA: 0x0066C64C File Offset: 0x0066A84C
	private void SetBackgroundColorOut()
	{
		if (ModelBase<GameModeModel>.Instance.Mp4FadeOutScreenColor != null)
		{
			this.BackgroundColor = ModelBase<GameModeModel>.Instance.Mp4FadeOutScreenColor;
		}
		else
		{
			IVideoParamHub videoParamHub = this.OpenParam as IVideoParamHub;
			EMovieBackgroundType? backgroundColor;
			if (videoParamHub == null)
			{
				backgroundColor = null;
			}
			else
			{
				IMovieBackgroundFadeData backgroundColor2 = videoParamHub.BackgroundColor;
				backgroundColor = ((backgroundColor2 != null) ? new EMovieBackgroundType?(backgroundColor2.FadeOutBackgroundType) : null);
			}
			this.BackgroundColor = backgroundColor;
		}
		FLinearColor? flinearColor = null;
		bool flag = true;
		EMovieBackgroundType? backgroundColor3 = this.BackgroundColor;
		if (backgroundColor3 != null)
		{
			EMovieBackgroundType valueOrDefault = backgroundColor3.GetValueOrDefault();
			if (valueOrDefault == EMovieBackgroundType.White)
			{
				flinearColor = new FLinearColor?(new FLinearColor(1f, 1f, 1f, 1f));
				flag = ControllerBase<LevelLoadingController>.Instance.CameraFade.SetColor(EFadeInScreenShowType.White);
				goto IL_115;
			}
			if (valueOrDefault == EMovieBackgroundType.Black)
			{
				flinearColor = new FLinearColor?(new FLinearColor(0f, 0f, 0f, 1f));
				flag = ControllerBase<LevelLoadingController>.Instance.CameraFade.SetColor(EFadeInScreenShowType.Black);
				goto IL_115;
			}
		}
		flinearColor = new FLinearColor?(new FLinearColor(0f, 0f, 0f, 1f));
		IL_115:
		if (!flag)
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Video, ELogAuthor.FZX, "[VideoView] 当前未开启黑幕界面，继承颜色失败", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		(this.CgTexture.GetTexture() as UMediaTexture).ClearColor = flinearColor.Value;
	}

	// Token: 0x060172EF RID: 94959 RVA: 0x0066C7B0 File Offset: 0x0066A9B0
	private unsafe void DelaySeamlessEndAfterTimeDilationRelease(string endSource)
	{
		if (this.HasHandledVideoEnd)
		{
			return;
		}
		this.RunningState = false;
		UMediaPlayer mediaPlayer = this.MediaPlayer;
		if (mediaPlayer != null)
		{
			mediaPlayer.OnEndReached.Remove(new Action(this.OnVideoEnd));
		}
		Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("VideoView.SeamlessEnd");
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Video;
		ELogAuthor author = ELogAuthor.FZX;
		string message = "无缝视频结束时补偿恢复时停";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("source", endSource);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("sourceLength", this.SourceLength);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.HasSeamlessReleasedTimeDilation = true;
		this.SeamlessEndDelayHandle = TimerSystem.GameplayTimeInstance.Next(delegate(float _)
		{
			this.SeamlessEndDelayHandle = null;
			this.HandleVideoEnd(endSource, new float?(0f));
		}, null, null);
	}

	// Token: 0x060172F0 RID: 94960 RVA: 0x0066C89C File Offset: 0x0066AA9C
	private void RemoveSeamlessEndDelayHandle()
	{
		if (this.SeamlessEndDelayHandle != null && TimerSystem.GameplayTimeInstance.Has(this.SeamlessEndDelayHandle))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.SeamlessEndDelayHandle);
		}
		this.SeamlessEndDelayHandle = null;
	}

	// Token: 0x060172F1 RID: 94961 RVA: 0x0066C8D0 File Offset: 0x0066AAD0
	private void ReleaseSeamlessEndTimeDilationTag()
	{
		if (!this.HasSeamlessReleasedTimeDilation)
		{
			return;
		}
		this.HasSeamlessReleasedTimeDilation = false;
		Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("VideoView.SeamlessEnd");
	}

	// Token: 0x060172F2 RID: 94962 RVA: 0x0066C8F4 File Offset: 0x0066AAF4
	protected override void OnTick(float delta)
	{
		if (this.RunningState)
		{
			float totalMilliseconds = UKismetMathLibrary.GetTotalMilliseconds(this.MediaPlayer.GetTime());
			this.ShowCaptionTick(totalMilliseconds);
			this.ShowQte(totalMilliseconds);
			while (this.PendingVideoSounds.Count > 0)
			{
				PendingVideoSound pendingVideoSound = this.PendingVideoSounds[this.PendingVideoSounds.Count - 1];
				if ((double)totalMilliseconds < pendingVideoSound.StartMomentMs)
				{
					IL_F9:
					while (this.VideoSoundPlays.Count > 0)
					{
						List<VideoSoundPlay> videoSoundPlays = this.VideoSoundPlays;
						VideoSoundPlay videoSoundPlay = videoSoundPlays[videoSoundPlays.Count - 1];
						if (videoSoundPlay.EndMomentMs < 0.0 || (double)totalMilliseconds < videoSoundPlay.EndMomentMs)
						{
							break;
						}
						Singleton<AudioSystem>.Instance.ExecuteAction(videoSoundPlay.Handle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
						{
							TransitionDuration = new int?(0)
						}));
						this.VideoSoundPlays.RemoveAt(this.VideoSoundPlays.Count - 1);
					}
					if (this.Mp4FadeOutTime > 0f && this.SourceLength - totalMilliseconds <= this.Mp4FadeOutTime)
					{
						this.TriggerBlendOut();
						base.GetRootItem().SetAlpha(Singleton<MathUtils>.Instance.GetRangePct(0f, this.Mp4FadeOutTime, this.SourceLength - totalMilliseconds));
					}
					VideoLauncher.OnCheckFrameEvent((int)totalMilliseconds);
					goto IL_15C;
				}
				this.PendingVideoSounds.RemoveAt(this.PendingVideoSounds.Count - 1);
				this.PlayVideoSound(pendingVideoSound.SoundConf);
			}
			goto IL_F9;
		}
		IL_15C:
		if (this.IsLerp)
		{
			this.LerpNowTime += delta;
			if (this.LerpNowTime > this.LerpWaitTime)
			{
				float rangePct = Singleton<MathUtils>.Instance.GetRangePct(0f, this.LerpFullTime - this.LerpWaitTime, this.LerpNowTime - this.LerpWaitTime);
				float aspect = this.LastAspect + (this.NowAspect - this.LastAspect) * rangePct;
				this.SetAspect(aspect);
			}
		}
	}

	// Token: 0x060172F3 RID: 94963 RVA: 0x0066CAD0 File Offset: 0x0066ACD0
	private void TriggerBlendOut()
	{
		if (this.HasTriggerBlendOut)
		{
			return;
		}
		this.HasTriggerBlendOut = true;
		ModelBase<PlotModel>.Instance.PlotAspectTransformView.SetAspectRatio(this.BlendOutRatio);
		Singleton<GameSettingsDeviceRender>.Instance.CancelAllPerformanceLimit();
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.VideoTriggerBlendOut, this.VideoName);
		this.RenderSetup(false);
		this.TryExecuteBlendAnim();
		ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.Common, "VideoView_TriggerBlendOut", delegate
		{
			Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("VideoView.TriggerBlendOut");
		}, new float?(0f));
	}

	// Token: 0x060172F4 RID: 94964 RVA: 0x0066CB68 File Offset: 0x0066AD68
	private void TryExecuteBlendAnim()
	{
		if (ControllerBase<PlotBlendController>.Instance.HasBlendInfo)
		{
			IVideoParamHub videoParamHub = this.OpenParam as IVideoParamHub;
			if (videoParamHub != null && videoParamHub != null)
			{
				VideoData videoDataConf = videoParamHub.VideoDataConf;
				ControllerBase<PlotBlendController>.Instance.TryExecuteBlend(videoParamHub.VideoDataConf.CgName).Forget<bool>();
			}
		}
	}

	// Token: 0x060172F5 RID: 94965 RVA: 0x0066CBB8 File Offset: 0x0066ADB8
	private void RenderSetup(bool isApply)
	{
		bool flag;
		if (Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.RayTracing, true, true) == null)
		{
			flag = false;
		}
		else
		{
			int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.RayTracing, true, true);
			int num = 0;
			flag = (currentValue.GetValueOrDefault() > num & currentValue != null);
		}
		bool flag2 = flag;
		if (isApply)
		{
			if (flag2)
			{
				GameSettingsUtils.ApplyRayTracedGI(0);
				GameSettingsUtils.ApplyRayTracedReflection(0);
				GameSettingsUtils.ApplyRayTracedShadow(0);
				return;
			}
		}
		else if (flag2)
		{
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.RayTracedGI, EGameSettingsApplyReason.AnyTime, true);
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.RayTracedReflection, EGameSettingsApplyReason.AnyTime, true);
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.RayTracedShadow, EGameSettingsApplyReason.AnyTime, true);
		}
	}

	// Token: 0x0400B23C RID: 45628
	private const string SeamlessEndTimeDilationTag = "VideoView.SeamlessEnd";

	// Token: 0x0400B23D RID: 45629
	private const string SubtitleVoiceEvent = "play_external_vo_video_subtitle_level_b";

	// Token: 0x0400B23E RID: 45630
	private const string SubtitleVoiceExternalSourceName = "vo_video_subtitle_level_b";

	// Token: 0x0400B23F RID: 45631
	private const int VIDEO_SOUND_SYNC_MIN_DELAY_MS = 200;

	// Token: 0x0400B240 RID: 45632
	[Nullable(2)]
	private UUITexture CgTexture;

	// Token: 0x0400B241 RID: 45633
	[Nullable(2)]
	private UMediaPlayer MediaPlayer;

	// Token: 0x0400B242 RID: 45634
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<VideoSubtitle> CaptionDataList;

	// Token: 0x0400B243 RID: 45635
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<VideoQteConfig> QteDataList;

	// Token: 0x0400B244 RID: 45636
	[Nullable(2)]
	private TimerHandle CaptionTimerId;

	// Token: 0x0400B245 RID: 45637
	[Nullable(2)]
	private string VideoName;

	// Token: 0x0400B246 RID: 45638
	[Nullable(2)]
	private FTimespan VideoPauseTime;

	// Token: 0x0400B247 RID: 45639
	[Nullable(2)]
	private PlotSkipComponent SkipComp;

	// Token: 0x0400B248 RID: 45640
	private int LoadHandle = -1;

	// Token: 0x0400B249 RID: 45641
	private readonly EVideoView[] CaptionLineComponents = new EVideoView[]
	{
		EVideoView.CaptionText,
		EVideoView.CaptionText2
	};

	// Token: 0x0400B24A RID: 45642
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly VideoSubtitle[] CaptionLines = new VideoSubtitle[2];

	// Token: 0x0400B24B RID: 45643
	private bool IsPlayToEnd;

	// Token: 0x0400B24C RID: 45644
	private bool RunningState;

	// Token: 0x0400B24D RID: 45645
	private bool HasHandledVideoEnd;

	// Token: 0x0400B24E RID: 45646
	private bool HasSeamlessReleasedTimeDilation;

	// Token: 0x0400B24F RID: 45647
	private List<VideoSoundPlay> VideoSoundPlays = new List<VideoSoundPlay>();

	// Token: 0x0400B250 RID: 45648
	private List<PendingVideoSound> PendingVideoSounds = new List<PendingVideoSound>();

	// Token: 0x0400B251 RID: 45649
	private readonly List<int> SubtitleVoicePlays = new List<int>();

	// Token: 0x0400B252 RID: 45650
	[Nullable(2)]
	private TimerHandle PlayStateTimeCheckHandle;

	// Token: 0x0400B253 RID: 45651
	[Nullable(2)]
	private TimerHandle PlayStateFrameCheckHandle;

	// Token: 0x0400B254 RID: 45652
	[Nullable(2)]
	private TimerHandle PlayLerpHandle;

	// Token: 0x0400B255 RID: 45653
	[Nullable(2)]
	private TimerHandle SeamlessEndDelayHandle;

	// Token: 0x0400B256 RID: 45654
	private bool IsViewClosed = true;

	// Token: 0x0400B257 RID: 45655
	private float LerpFullTime = 4000f;

	// Token: 0x0400B258 RID: 45656
	private float LerpWaitTime = 1000f;

	// Token: 0x0400B259 RID: 45657
	private float LerpNowTime;

	// Token: 0x0400B25A RID: 45658
	private bool IsLerp;

	// Token: 0x0400B25B RID: 45659
	private float NowAspect;

	// Token: 0x0400B25C RID: 45660
	private float LastAspect;

	// Token: 0x0400B25D RID: 45661
	private EMovieBackgroundType? BackgroundColor = new EMovieBackgroundType?(EMovieBackgroundType.Black);

	// Token: 0x0400B25E RID: 45662
	private readonly HashSet<CommonQteContextBase> CurrentQte = new HashSet<CommonQteContextBase>();

	// Token: 0x0400B25F RID: 45663
	private float SourceLength;

	// Token: 0x0400B260 RID: 45664
	protected float Mp4FadeOutTime;

	// Token: 0x0400B261 RID: 45665
	protected float BlackBorderFadeOutTime;

	// Token: 0x0400B262 RID: 45666
	private bool HasTriggerBlendOut;

	// Token: 0x0400B263 RID: 45667
	private float BlendOutRatio;

	// Token: 0x0400B264 RID: 45668
	private bool HasChangeColor;
}
