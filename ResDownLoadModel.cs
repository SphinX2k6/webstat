using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Update;

// Token: 0x02002768 RID: 10088
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ResDownLoadModel : ModelBase<ResDownLoadModel>
{
	// Token: 0x06013E80 RID: 81536 RVA: 0x0058BEEA File Offset: 0x0058A0EA
	protected override bool OnInit()
	{
		Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.LoginPrepare).SetDownLoadStateChangeCallBack(new Action<EVideoDownloadStatus>(this.OnDownLoadStateChange));
		Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.LoginPrepare).SetDownLoadFailedCallBack(new Action<bool>(this.OnDownLoadFailed));
		return true;
	}

	// Token: 0x06013E81 RID: 81537 RVA: 0x0058BF25 File Offset: 0x0058A125
	protected override bool OnClear()
	{
		this.ResSizeType = null;
		return true;
	}

	// Token: 0x06013E82 RID: 81538 RVA: 0x0058BF34 File Offset: 0x0058A134
	public void OnDownLoadStateChange(EVideoDownloadStatus state)
	{
		if (state == EVideoDownloadStatus.Done)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ResDownLoadView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ResDownLoadView, null);
			}
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			if ((playerGender == EPlayerGender.Female && this.CurrentDownLoadVideo == 3) || (playerGender == EPlayerGender.Male && this.CurrentDownLoadVideo == 4))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DownloadCompletedTip1", Array.Empty<object>());
			}
			else if ((playerGender == EPlayerGender.Male && this.CurrentDownLoadVideo == 3) || (playerGender == EPlayerGender.Female && this.CurrentDownLoadVideo == 4))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DownloadCompletedTip2", Array.Empty<object>());
			}
			this.CurrentDownLoadVideo = -1;
		}
		else if (state == EVideoDownloadStatus.Pause)
		{
			this.CurrentDownLoadVideo = -1;
		}
		ModelBase<QuestResourceModel>.Instance.RefreshCachePrepareResourceSize();
		Singleton<EventSystem>.Instance.Emit<EVideoDownloadStatus>(EEventName.ResDownLoadStateRefresh, state);
	}

	// Token: 0x06013E83 RID: 81539 RVA: 0x0058BFFF File Offset: 0x0058A1FF
	public void OnDownLoadFailed(bool noFreeSize)
	{
		if (noFreeSize)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DownLoadTips_NotEnough", Array.Empty<object>());
		}
	}

	// Token: 0x06013E84 RID: 81540 RVA: 0x0058C018 File Offset: 0x0058A218
	public ValueTuple<float, EVideoDownloadStatus> DownLoadPercentage()
	{
		int downLoadState = (int)Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.FemalePrepare).GetDownLoadState();
		EVideoDownloadStatus downLoadState2 = Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.MalePrepare).GetDownLoadState();
		if (downLoadState == 1)
		{
			this.ResSizeType = new EVideoResSizeType?(EVideoResSizeType.FemalePrepare);
		}
		else if (downLoadState2 == EVideoDownloadStatus.Downloading)
		{
			this.ResSizeType = new EVideoResSizeType?(EVideoResSizeType.MalePrepare);
		}
		else if (this.ResSizeType == null)
		{
			if (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male)
			{
				this.ResSizeType = new EVideoResSizeType?(EVideoResSizeType.MalePrepare);
			}
			else
			{
				this.ResSizeType = new EVideoResSizeType?(EVideoResSizeType.FemalePrepare);
			}
		}
		VideoUpdater videoUpdater = Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(this.ResSizeType.Value);
		ValueTuple<long, long, long, long> downLoadProgress = videoUpdater.GetDownLoadProgress();
		if (downLoadProgress.Item3 != 0L && downLoadProgress.Item2 > 0L)
		{
			return new ValueTuple<float, EVideoDownloadStatus>((float)downLoadProgress.Item2 / (float)downLoadProgress.Item3, videoUpdater.GetDownLoadState());
		}
		float videoResSavedSize = (float)Singleton<VideoResUpdate>.Instance.GetVideoResSavedSize(this.ResSizeType.Value);
		long videoResSize = Singleton<VideoResUpdate>.Instance.GetVideoResSize(this.ResSizeType.Value);
		return new ValueTuple<float, EVideoDownloadStatus>(videoResSavedSize / (float)videoResSize, videoUpdater.GetDownLoadState());
	}

	// Token: 0x06013E85 RID: 81541 RVA: 0x0058C124 File Offset: 0x0058A324
	public bool NeedShowBattleViewButton()
	{
		ModelBase<QuestResourceModel>.Instance.CalcPrepareResource();
		return (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male && Singleton<VideoResUpdate>.Instance.GetVideoResSize(EVideoResSizeType.MalePrepare) != Singleton<VideoResUpdate>.Instance.GetVideoResSavedSize(EVideoResSizeType.MalePrepare)) || (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female && Singleton<VideoResUpdate>.Instance.GetVideoResSize(EVideoResSizeType.FemalePrepare) != Singleton<VideoResUpdate>.Instance.GetVideoResSavedSize(EVideoResSizeType.FemalePrepare)) || Singleton<VideoResUpdate>.Instance.GetIsResPakDownloading(EVideoResSizeType.MalePrepare) || Singleton<VideoResUpdate>.Instance.GetIsResPakDownloading(EVideoResSizeType.FemalePrepare) || Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.FemalePrepare).GetDownLoadState() == EVideoDownloadStatus.Downloading || Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.MalePrepare).GetDownLoadState() == EVideoDownloadStatus.Downloading;
	}

	// Token: 0x04009AE5 RID: 39653
	public int CurrentDownLoadVideo = -1;

	// Token: 0x04009AE6 RID: 39654
	private EVideoResSizeType? ResSizeType;
}
