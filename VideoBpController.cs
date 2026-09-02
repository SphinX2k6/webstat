using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Sequence.Seq_BP.BPSeqDissolve;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002CDD RID: 11485
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class VideoBpController : ControllerBase<VideoBpController>
{
	// Token: 0x06017259 RID: 94809 RVA: 0x00669E25 File Offset: 0x00668025
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0601725A RID: 94810 RVA: 0x00669E28 File Offset: 0x00668028
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x0601725B RID: 94811 RVA: 0x00669E2B File Offset: 0x0066802B
	[NullableContext(2)]
	private BP_MediaDissolveManagea_C SpawnOrGetBp()
	{
		return ModelBase<VideoBpModel>.Instance.SpawnOrGetVideoBp();
	}

	// Token: 0x0601725C RID: 94812 RVA: 0x00669E37 File Offset: 0x00668037
	public void RemoveBp()
	{
		ModelBase<VideoBpModel>.Instance.RemoveOnVideoEnd();
	}

	// Token: 0x0601725D RID: 94813 RVA: 0x00669E43 File Offset: 0x00668043
	public void RemovePreload()
	{
		ModelBase<VideoBpModel>.Instance.RemovePreload();
	}

	// Token: 0x0601725E RID: 94814 RVA: 0x00669E50 File Offset: 0x00668050
	public UniTask PreloadMp4s(List<string> mp4s)
	{
		VideoBpController.<PreloadMp4s>d__5 <PreloadMp4s>d__;
		<PreloadMp4s>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PreloadMp4s>d__.<>4__this = this;
		<PreloadMp4s>d__.mp4s = mp4s;
		<PreloadMp4s>d__.<>1__state = -1;
		<PreloadMp4s>d__.<>t__builder.Start<VideoBpController.<PreloadMp4s>d__5>(ref <PreloadMp4s>d__);
		return <PreloadMp4s>d__.<>t__builder.Task;
	}

	// Token: 0x0601725F RID: 94815 RVA: 0x00669E9C File Offset: 0x0066809C
	private UniTask PreloadMp4Internal(string id)
	{
		VideoBpController.<PreloadMp4Internal>d__6 <PreloadMp4Internal>d__;
		<PreloadMp4Internal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PreloadMp4Internal>d__.id = id;
		<PreloadMp4Internal>d__.<>1__state = -1;
		<PreloadMp4Internal>d__.<>t__builder.Start<VideoBpController.<PreloadMp4Internal>d__6>(ref <PreloadMp4Internal>d__);
		return <PreloadMp4Internal>d__.<>t__builder.Task;
	}

	// Token: 0x06017260 RID: 94816 RVA: 0x00669EE0 File Offset: 0x006680E0
	public unsafe bool PlayEffect(IPlayDissolveEffect inParams)
	{
		BP_MediaDissolveManagea_C bp = this.SpawnOrGetBp();
		if (bp == null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Preload, ELogAuthor.JYS, "[VideoBp]生成VideoBp蓝图失败", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		VideoData? videoData = ConfigBase<VideoConfig>.Instance.GetVideoData(inParams.Path);
		if (videoData == null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Preload, ELogAuthor.JYS, "[VideoBp]获取VideoData失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		UMediaSource fromPreloadMap = ModelBase<VideoBpModel>.Instance.GetFromPreloadMap(videoData.Value.CgName);
		if (fromPreloadMap != null)
		{
			bp.PlayEffect(videoData.Value.CgFile, new FVector2D(inParams.ScreenPos.X.GetValueOrDefault(), inParams.ScreenPos.Y.GetValueOrDefault()), inParams.Scale.GetValueOrDefault(1f), inParams.FadeInTime.GetValueOrDefault(1f), inParams.FadeOutTime.GetValueOrDefault(1f), fromPreloadMap, inParams.IsFullScreenMask.GetValueOrDefault());
			return true;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<UMediaSource>(videoData.Value.CgFile, delegate([Nullable(2)] UMediaSource loadedMediaSource, string _)
		{
			if (loadedMediaSource == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Video;
				ELogAuthor author = ELogAuthor.JYS;
				string message = "VideoBpController mediaSource加载失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("配置名称", videoData.Value.CgName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("视频路径", videoData.Value.CgFile);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			bp.PlayEffect(videoData.Value.CgFile, new FVector2D(inParams.ScreenPos.X.GetValueOrDefault(), inParams.ScreenPos.Y.GetValueOrDefault()), inParams.Scale.GetValueOrDefault(1f), inParams.FadeInTime.GetValueOrDefault(1f), inParams.FadeOutTime.GetValueOrDefault(1f), loadedMediaSource, inParams.IsFullScreenMask.GetValueOrDefault());
		}, ResourceSystem.EResourceLoadPriority.Ui, "js_undefined");
		return true;
	}
}
