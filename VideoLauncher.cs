using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002CE7 RID: 11495
[NullableContext(2)]
[Nullable(0)]
public class VideoLauncher : IStaticVariableResetter
{
	// Token: 0x060172BF RID: 94911 RVA: 0x0066A87B File Offset: 0x00668A7B
	static VideoLauncher()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(VideoLauncher.CreateStaticDefaultValue), new Action(VideoLauncher.ResetStaticDefaultValue));
	}

	// Token: 0x060172C0 RID: 94912 RVA: 0x0066A89A File Offset: 0x00668A9A
	public static void CreateStaticDefaultValue()
	{
		VideoLauncher.CloseCallback = null;
		VideoLauncher.Param = null;
		VideoLauncher.FrameEvents = null;
	}

	// Token: 0x060172C1 RID: 94913 RVA: 0x0066A8AE File Offset: 0x00668AAE
	public static void ResetStaticDefaultValue()
	{
		VideoLauncher.CloseCallback = null;
		VideoLauncher.Param = null;
		VideoLauncher.FrameEvents = null;
	}

	// Token: 0x060172C2 RID: 94914 RVA: 0x0066A8C2 File Offset: 0x00668AC2
	private static void DoCallback()
	{
		if (VideoLauncher.CloseCallback != null)
		{
			Action closeCallback = VideoLauncher.CloseCallback;
			VideoLauncher.CloseCallback = null;
			closeCallback();
		}
	}

	// Token: 0x060172C3 RID: 94915 RVA: 0x0066A8DB File Offset: 0x00668ADB
	public static void ShowVideoCg(string videoName, Action videoCloseCb = null, IShowVideoCgConfig config = null)
	{
		if (string.IsNullOrEmpty(videoName))
		{
			if (videoCloseCb != null)
			{
				videoCloseCb();
			}
			return;
		}
		VideoLauncher.ShowVideoCgAsync(videoName, videoCloseCb, config).Forget();
	}

	// Token: 0x060172C4 RID: 94916 RVA: 0x0066A8FC File Offset: 0x00668AFC
	public static UniTask ShowVideoCgAsync([Nullable(1)] string videoName, Action videoCloseCb = null, IShowVideoCgConfig config = null)
	{
		VideoLauncher.<ShowVideoCgAsync>d__8 <ShowVideoCgAsync>d__;
		<ShowVideoCgAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowVideoCgAsync>d__.videoName = videoName;
		<ShowVideoCgAsync>d__.videoCloseCb = videoCloseCb;
		<ShowVideoCgAsync>d__.config = config;
		<ShowVideoCgAsync>d__.<>1__state = -1;
		<ShowVideoCgAsync>d__.<>t__builder.Start<VideoLauncher.<ShowVideoCgAsync>d__8>(ref <ShowVideoCgAsync>d__);
		return <ShowVideoCgAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060172C5 RID: 94917 RVA: 0x0066A94F File Offset: 0x00668B4F
	public static void CloseVideoCg(Action<bool> callback = null)
	{
		VideoLauncher.CloseCallback = null;
		Singleton<UiManager>.Instance.CloseView(EUiViewName.VideoView, callback);
	}

	// Token: 0x060172C6 RID: 94918 RVA: 0x0066A968 File Offset: 0x00668B68
	public static void SetupFrameEvent([Nullable(new byte[]
	{
		2,
		1
	})] List<IMp4FrameEvent> frameEvents)
	{
		if (frameEvents == null)
		{
			VideoLauncher.FrameEvents = null;
			return;
		}
		VideoLauncher.FrameEvents = new List<IMp4FrameEvent>();
		VideoLauncher.FrameEvents.AddRange(frameEvents);
		if (VideoLauncher.FrameEvents.Count > 0)
		{
			VideoLauncher.FrameEvents.Sort((IMp4FrameEvent a, IMp4FrameEvent b) => b.Second.CompareTo(a.Second));
		}
	}

	// Token: 0x060172C7 RID: 94919 RVA: 0x0066A9CC File Offset: 0x00668BCC
	public static void OnCheckFrameEvent(int playTime)
	{
		if (VideoLauncher.FrameEvents == null)
		{
			return;
		}
		while (VideoLauncher.FrameEvents.Count > 0)
		{
			int num = VideoLauncher.FrameEvents.Count - 1;
			IMp4FrameEvent mp4FrameEvent = VideoLauncher.FrameEvents[num];
			if (mp4FrameEvent.Second > (float)playTime * 0.001f)
			{
				break;
			}
			IMp4FrameEvent mp4FrameEvent2 = mp4FrameEvent;
			VideoLauncher.FrameEvents = VideoLauncher.FrameEvents.Take(num).ToList<IMp4FrameEvent>();
			ControllerBase<FlowController>.Instance.ExecuteSubActions(mp4FrameEvent2.EventActions, null, true);
		}
	}

	// Token: 0x0400B22E RID: 45614
	private static Action CloseCallback;

	// Token: 0x0400B22F RID: 45615
	private static IVideoParamHub Param;

	// Token: 0x0400B230 RID: 45616
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static List<IMp4FrameEvent> FrameEvents;

	// Token: 0x02008FA3 RID: 36771
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04030392 RID: 197522
		[Nullable(0)]
		public static Action <0>__DoCallback;
	}
}
