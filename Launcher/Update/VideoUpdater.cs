using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.Data;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Download;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update.ResourceDiffUpdate.Updater;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044D1 RID: 17617
	[NullableContext(2)]
	[Nullable(0)]
	public class VideoUpdater
	{
		// Token: 0x0602E7A0 RID: 190368 RVA: 0x00B0146B File Offset: 0x00AFF66B
		public void Init(VideoUpdateUiEvent uiEvent)
		{
			this.UpdateView = new ResourceUpdateViewAgent();
			if (uiEvent != null)
			{
				uiEvent.InitEvent(this.UpdateView);
			}
		}

		// Token: 0x0602E7A1 RID: 190369 RVA: 0x00B01488 File Offset: 0x00AFF688
		[NullableContext(0)]
		public UniTask<bool> Update(EVideoResSizeType videoResSizeType, [Nullable(1)] IResourceUpdateView updateViewImplement)
		{
			VideoUpdater.<Update>d__14 <Update>d__;
			<Update>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Update>d__.<>4__this = this;
			<Update>d__.videoResSizeType = videoResSizeType;
			<Update>d__.updateViewImplement = updateViewImplement;
			<Update>d__.<>1__state = -1;
			<Update>d__.<>t__builder.Start<VideoUpdater.<Update>d__14>(ref <Update>d__);
			return <Update>d__.<>t__builder.Task;
		}

		// Token: 0x0602E7A2 RID: 190370 RVA: 0x00B014DC File Offset: 0x00AFF6DC
		[NullableContext(1)]
		public void SetCustomDownloadList(List<string> toDoList)
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "设置自定义视频资源下载列表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("toDoList", toDoList);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.ToDoList = toDoList;
		}

		// Token: 0x0602E7A3 RID: 190371 RVA: 0x00B01514 File Offset: 0x00AFF714
		[NullableContext(0)]
		public ValueTuple<bool, long> DoesSavedDirHaveEnoughSpace()
		{
			ValueTuple<List<RequireFileInfo>, long, long, List<LocalFileInfo>> valueTuple = Singleton<VideoResUpdate>.Instance.AnalyzeRequireFilesByNames(this.ToDoList);
			long item = valueTuple.Item2;
			long item2 = valueTuple.Item3;
			if (Singleton<VideoResUpdate>.Instance.GetFreeSpace() + 10485760L < item - item2)
			{
				Singleton<LauncherLog>.Instance.Warn("下载空间不足", default(ReadOnlySpan<ValueTuple<string, object>>));
				return new ValueTuple<bool, long>(false, item - item2);
			}
			return new ValueTuple<bool, long>(true, 0L);
		}

		// Token: 0x0602E7A4 RID: 190372 RVA: 0x00B0157E File Offset: 0x00AFF77E
		public EVideoDownloadStatus GetDownLoadState()
		{
			return this.Status;
		}

		// Token: 0x0602E7A5 RID: 190373 RVA: 0x00B01586 File Offset: 0x00AFF786
		public void SetDownLoadStateChangeCallBack(Action<EVideoDownloadStatus> callback)
		{
			this.OnUpdateStateChange = callback;
		}

		// Token: 0x0602E7A6 RID: 190374 RVA: 0x00B0158F File Offset: 0x00AFF78F
		public void SetDownLoadFailedCallBack(Action<bool> callback)
		{
			this.OnDownloadFailed = callback;
		}

		// Token: 0x0602E7A7 RID: 190375 RVA: 0x00B01598 File Offset: 0x00AFF798
		public void SetDownloadFinishCallBack(Action<EVideoResSizeType> callback)
		{
			this.OnDownloadFinish = callback;
		}

		// Token: 0x0602E7A8 RID: 190376 RVA: 0x00B015A4 File Offset: 0x00AFF7A4
		[NullableContext(0)]
		public ValueTuple<long, long, long, long> GetDownLoadProgress()
		{
			return new ValueTuple<long, long, long, long>(this.UpdateView.ReceiveSize + this.AllSize, this.UpdateView.CurProgress + this.AllSize - this.UpdateView.TotalProgress, this.AllSize, this.UpdateView.DownloadSpeed);
		}

		// Token: 0x0602E7A9 RID: 190377 RVA: 0x00B015F7 File Offset: 0x00AFF7F7
		[NullableContext(0)]
		public ValueTuple<double, double, double, bool> GetReportLogData()
		{
			return new ValueTuple<double, double, double, bool>((double)this.UpdateView.DownloadSpeedMax / 1048576.0, this.DownloadSizeMB, this.SpendTime, this.UpdateView.HasShowNotEnoughSpace);
		}

		// Token: 0x0602E7AA RID: 190378 RVA: 0x00B0162B File Offset: 0x00AFF82B
		public void ResetDownLoadProgress()
		{
			this.AllSize = 0L;
			this.UpdateView.ReceiveSize = 0L;
			this.UpdateView.CurProgress = 0L;
			this.UpdateView.TotalProgress = 0L;
			this.UpdateView.DownloadSpeed = 0L;
		}

		// Token: 0x0602E7AB RID: 190379 RVA: 0x00B01669 File Offset: 0x00AFF869
		public void SetDownLoadProgress(long curProgress, long totalProgress)
		{
			this.UpdateView.CurProgress = curProgress;
			this.UpdateView.TotalProgress = totalProgress;
			this.AllSize = totalProgress;
		}

		// Token: 0x0602E7AC RID: 190380 RVA: 0x00B0168A File Offset: 0x00AFF88A
		public void ResetDownLoadState()
		{
			this.Status = EVideoDownloadStatus.None;
			this.ResetDownLoadProgress();
		}

		// Token: 0x0602E7AD RID: 190381 RVA: 0x00B0169C File Offset: 0x00AFF89C
		public void Pause()
		{
			Singleton<LauncherLog>.Instance.Info("VideoDown Pause", default(ReadOnlySpan<ValueTuple<string, object>>));
			DiffUpdate diffUpdater = this.DiffUpdater;
			if (diffUpdater != null)
			{
				diffUpdater.Stop();
			}
			this.Status = EVideoDownloadStatus.Pause;
			if (this.OnUpdateStateChange != null)
			{
				this.OnUpdateStateChange(this.Status);
			}
		}

		// Token: 0x0602E7AE RID: 190382 RVA: 0x00B016F4 File Offset: 0x00AFF8F4
		public void CancelDownload()
		{
			Singleton<LauncherLog>.Instance.Info("Cancel Video Downloading.", default(ReadOnlySpan<ValueTuple<string, object>>));
			DiffUpdate diffUpdater = this.DiffUpdater;
			if (diffUpdater != null)
			{
				diffUpdater.Stop();
			}
			IReadOnlyList<string> readOnlyList;
			if (this.TodoResSizeType == EVideoResSizeType.Custom)
			{
				readOnlyList = this.ToDoList;
			}
			else
			{
				readOnlyList = Singleton<VideoResUpdate>.Instance.GetAllSpecialVideoResPak(this.TodoResSizeType);
			}
			string str = ResPackageInfo.GetResSaveDir() + "Video/Paks/";
			foreach (string str2 in readOnlyList)
			{
				string text = str + str2;
				if (UBlueprintPathsLibrary.DirectoryExists(text))
				{
					UKuroLauncherLibrary.DeleteDirectory(text);
				}
			}
			this.ResetDownLoadProgress();
			this.TodoResSizeType = EVideoResSizeType.NoSize;
			this.Status = EVideoDownloadStatus.None;
			if (this.OnUpdateStateChange != null)
			{
				this.OnUpdateStateChange(this.Status);
			}
		}

		// Token: 0x0602E7AF RID: 190383 RVA: 0x00B017DC File Offset: 0x00AFF9DC
		public unsafe void UpdateDeviceSave(EVideoResSizeType videoResSizeType)
		{
			if (this.Status == EVideoDownloadStatus.Done)
			{
				int deviceSaved = Singleton<LauncherStorageLib>.Instance.GetDeviceSaved<int>(ELauncherStorageDeviceKey.UserSelectedVideoUpdate, 0);
				EVideoResSizeType evideoResSizeType = (EVideoResSizeType)deviceSaved;
				if (deviceSaved == 2 && videoResSizeType == EVideoResSizeType.FemalePrepare)
				{
					evideoResSizeType = EVideoResSizeType.FemalePrepare;
				}
				else if (deviceSaved == 2 && videoResSizeType == EVideoResSizeType.MalePrepare)
				{
					evideoResSizeType = EVideoResSizeType.MalePrepare;
				}
				else if (deviceSaved == 4 && videoResSizeType == EVideoResSizeType.FemalePrepare)
				{
					evideoResSizeType = EVideoResSizeType.StartMaxNeed;
				}
				else if (deviceSaved == 3 && videoResSizeType == EVideoResSizeType.MalePrepare)
				{
					evideoResSizeType = EVideoResSizeType.StartMaxNeed;
				}
				else
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "视频下载类型和设备存储类型没有变化";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("userSelectedDownload", deviceSaved);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("videoResSizeType", videoResSizeType);
					instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "保存新下载类型";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("userSelectedDownload", deviceSaved);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("newUserSelectedDownload", evideoResSizeType);
				instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<int>(ELauncherStorageDeviceKey.UserSelectedVideoUpdate, (int)evideoResSizeType);
			}
		}

		// Token: 0x0401A677 RID: 108151
		private EVideoDownloadStatus Status;

		// Token: 0x0401A678 RID: 108152
		private Action<EVideoDownloadStatus> OnUpdateStateChange;

		// Token: 0x0401A679 RID: 108153
		private Action<bool> OnDownloadFailed;

		// Token: 0x0401A67A RID: 108154
		private Action<EVideoResSizeType> OnDownloadFinish;

		// Token: 0x0401A67B RID: 108155
		public UrlPrefixDownload Downloader;

		// Token: 0x0401A67C RID: 108156
		public DiffUpdate DiffUpdater;

		// Token: 0x0401A67D RID: 108157
		public ResPackageInfo DiffResInfo;

		// Token: 0x0401A67E RID: 108158
		public ResourceUpdateViewAgent UpdateView;

		// Token: 0x0401A67F RID: 108159
		[Nullable(1)]
		public List<string> ToDoList = new List<string>();

		// Token: 0x0401A680 RID: 108160
		public EVideoResSizeType TodoResSizeType;

		// Token: 0x0401A681 RID: 108161
		private long AllSize;

		// Token: 0x0401A682 RID: 108162
		private double DownloadSizeMB;

		// Token: 0x0401A683 RID: 108163
		private double SpendTime;
	}
}
