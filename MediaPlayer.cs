using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020019AB RID: 6571
[NullableContext(1)]
[Nullable(0)]
public class MediaPlayer
{
	// Token: 0x0600BCD9 RID: 48345 RVA: 0x00322920 File Offset: 0x00320B20
	public MediaPlayer(UUITexture texture)
	{
		this.CgTexture = texture;
		UMediaTexture umediaTexture = this.CgTexture.GetTexture() as UMediaTexture;
		this.MediaPlayerObj = ((umediaTexture != null) ? umediaTexture.GetMediaPlayer() : null);
		if (this.MediaPlayerObj == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Video, ELogAuthor.YYZ, "[MediaPlayer] 获取MediaPlayer异常", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.MediaPlayerObj.OnMediaOpened.Add(new Action<string>(this.OnMediaOpen));
		this.MediaPlayerObj.OnEndReached.Add(new Action(this.OnVideoEnd));
		this.MediaPlayerObj.OnMediaOpenFailed.Add(new Action<string>(this.OnVideoOpenFailed));
	}

	// Token: 0x0600BCDA RID: 48346 RVA: 0x003229E0 File Offset: 0x00320BE0
	public void Clear()
	{
		this.CleanVideo();
		UMediaPlayer mediaPlayerObj = this.MediaPlayerObj;
		if (mediaPlayerObj != null)
		{
			mediaPlayerObj.OnMediaOpened.Remove(new Action<string>(this.OnMediaOpen));
		}
		UMediaPlayer mediaPlayerObj2 = this.MediaPlayerObj;
		if (mediaPlayerObj2 != null)
		{
			mediaPlayerObj2.OnEndReached.Remove(new Action(this.OnVideoEnd));
		}
		UMediaPlayer mediaPlayerObj3 = this.MediaPlayerObj;
		if (mediaPlayerObj3 != null)
		{
			mediaPlayerObj3.OnMediaOpenFailed.Remove(new Action<string>(this.OnVideoOpenFailed));
		}
		UMediaPlayer mediaPlayerObj4 = this.MediaPlayerObj;
		if (mediaPlayerObj4 != null)
		{
			mediaPlayerObj4.Close();
		}
		this.MediaPlayerObj = null;
	}

	// Token: 0x0600BCDB RID: 48347 RVA: 0x00322A71 File Offset: 0x00320C71
	private void OnMediaOpen(string _)
	{
		UMediaPlayer mediaPlayerObj = this.MediaPlayerObj;
		if (mediaPlayerObj == null)
		{
			return;
		}
		mediaPlayerObj.Play();
	}

	// Token: 0x0600BCDC RID: 48348 RVA: 0x00322A84 File Offset: 0x00320C84
	private void OnVideoEnd()
	{
		Action<string> onVideoEndCallback = this.OnVideoEndCallback;
		if (onVideoEndCallback == null)
		{
			return;
		}
		onVideoEndCallback(this.VideoName);
	}

	// Token: 0x0600BCDD RID: 48349 RVA: 0x00322A9C File Offset: 0x00320C9C
	private void OnVideoOpenFailed(string _)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Video;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "[MediaPlayer] 视频文件打开失败";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("视频名称", this.VideoName);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600BCDE RID: 48350 RVA: 0x00322AD8 File Offset: 0x00320CD8
	private void CleanVideo()
	{
		if (this.LoadHandle != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadHandle);
			this.LoadHandle = -1;
		}
		UMediaPlayer mediaPlayerObj = this.MediaPlayerObj;
		if (mediaPlayerObj == null || !mediaPlayerObj.IsPlaying())
		{
			UMediaPlayer mediaPlayerObj2 = this.MediaPlayerObj;
			if (mediaPlayerObj2 == null || !mediaPlayerObj2.IsPaused())
			{
				goto IL_59;
			}
		}
		UMediaPlayer mediaPlayerObj3 = this.MediaPlayerObj;
		if (mediaPlayerObj3 != null)
		{
			mediaPlayerObj3.Close();
		}
		IL_59:
		this.VideoName = null;
	}

	// Token: 0x0600BCDF RID: 48351 RVA: 0x00322B48 File Offset: 0x00320D48
	public unsafe void PlayVideo(string videoName, string videoPath, bool isLooping = false)
	{
		if (string.IsNullOrEmpty(videoPath))
		{
			return;
		}
		if (this.VideoName != null)
		{
			this.CleanVideo();
		}
		this.LoadHandle = Singleton<ResourceSystem>.Instance.LoadAsync<UMediaSource>(videoPath, delegate([Nullable(2)] UMediaSource mediaSource, string _)
		{
			if (mediaSource == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Video;
				ELogAuthor author2 = ELogAuthor.YYZ;
				string message2 = "[MediaPlayer] mediaSource加载失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("配置名称", videoName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("视频路径", videoPath);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return;
			}
			this.LoadHandle = -1;
			if (!this.MediaPlayerObj.OpenSource(mediaSource))
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Video;
				ELogAuthor author3 = ELogAuthor.YYZ;
				string message3 = "[MediaPlayer] 打开视频失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("配置名称", videoName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("视频路径", videoPath);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
				return;
			}
			this.MediaPlayerObj.SetLooping(isLooping);
			this.VideoName = videoName;
		}, 100, "Ui.UiVideo");
		if (this.LoadHandle < 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Video;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[MediaPlayer] mediaSource加载失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("配置名称", videoName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("视频路径", videoPath);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x0600BCE0 RID: 48352 RVA: 0x00322C28 File Offset: 0x00320E28
	public UniTask LoadVideoAndPlay(string videoName, string videoPath, bool isLooping = false)
	{
		MediaPlayer.<LoadVideoAndPlay>d__12 <LoadVideoAndPlay>d__;
		<LoadVideoAndPlay>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadVideoAndPlay>d__.<>4__this = this;
		<LoadVideoAndPlay>d__.videoName = videoName;
		<LoadVideoAndPlay>d__.videoPath = videoPath;
		<LoadVideoAndPlay>d__.isLooping = isLooping;
		<LoadVideoAndPlay>d__.<>1__state = -1;
		<LoadVideoAndPlay>d__.<>t__builder.Start<MediaPlayer.<LoadVideoAndPlay>d__12>(ref <LoadVideoAndPlay>d__);
		return <LoadVideoAndPlay>d__.<>t__builder.Task;
	}

	// Token: 0x0600BCE1 RID: 48353 RVA: 0x00322C83 File Offset: 0x00320E83
	public void StopVideo(string videoName)
	{
		if (this.VideoName != videoName)
		{
			return;
		}
		if (this.MediaPlayerObj.IsPlaying() || this.MediaPlayerObj.IsPaused())
		{
			this.MediaPlayerObj.Close();
		}
		this.VideoName = null;
	}

	// Token: 0x0600BCE2 RID: 48354 RVA: 0x00322CC0 File Offset: 0x00320EC0
	public void PauseVideo(string videoName)
	{
		if (this.VideoName != videoName)
		{
			return;
		}
		if (this.MediaPlayerObj.IsPlaying())
		{
			this.MediaPlayerObj.Pause();
		}
	}

	// Token: 0x0600BCE3 RID: 48355 RVA: 0x00322CEA File Offset: 0x00320EEA
	public void ResumeVideo(string videoName)
	{
		if (this.VideoName != videoName)
		{
			return;
		}
		if (this.MediaPlayerObj.IsPaused())
		{
			this.MediaPlayerObj.Play();
		}
	}

	// Token: 0x0600BCE4 RID: 48356 RVA: 0x00322D14 File Offset: 0x00320F14
	public void BindCallbackOnVideoEnd([Nullable(new byte[]
	{
		1,
		2
	})] Action<string> callback)
	{
		this.OnVideoEndCallback = callback;
	}

	// Token: 0x0600BCE5 RID: 48357 RVA: 0x00322D1D File Offset: 0x00320F1D
	public float GetVideoAspect(int trackIndex = 0, int formatIndex = 0)
	{
		return this.MediaPlayerObj.GetVideoTrackAspectRatio(trackIndex, formatIndex);
	}

	// Token: 0x0400594B RID: 22859
	[Nullable(2)]
	protected UUITexture CgTexture;

	// Token: 0x0400594C RID: 22860
	[Nullable(2)]
	protected UMediaPlayer MediaPlayerObj;

	// Token: 0x0400594D RID: 22861
	[Nullable(2)]
	protected string VideoName;

	// Token: 0x0400594E RID: 22862
	private int LoadHandle = -1;

	// Token: 0x0400594F RID: 22863
	[Nullable(2)]
	private Action<string> OnVideoEndCallback;
}
