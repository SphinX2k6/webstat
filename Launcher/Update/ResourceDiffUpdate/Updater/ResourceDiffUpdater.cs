using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Download;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Updater
{
	// Token: 0x020044DF RID: 17631
	[NullableContext(1)]
	[Nullable(0)]
	public class ResourceDiffUpdater
	{
		// Token: 0x0602E7F9 RID: 190457 RVA: 0x00B02D90 File Offset: 0x00B00F90
		public ResourceDiffUpdater(string name, int priority, List<ResPackageInfo> resPackageInfos)
		{
			this.Name = name;
			this.Priority = priority;
			this.ResPackageInfos = resPackageInfos;
		}

		// Token: 0x0602E7FA RID: 190458 RVA: 0x00B02DD0 File Offset: 0x00B00FD0
		public UniTask Init()
		{
			ResourceDiffUpdater.<Init>d__9 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<ResourceDiffUpdater.<Init>d__9>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0602E7FB RID: 190459 RVA: 0x00B02E14 File Offset: 0x00B01014
		protected virtual void CreateDiffUpdater()
		{
			UrlPrefixDownload downloader = new UrlPrefixDownload();
			this.ViewInfoInternal = new ResourceUpdateViewAgent();
			ResourceDiffUpdateUiEvent resourceDiffUpdateUiEvent = new ResourceDiffUpdateUiEvent();
			resourceDiffUpdateUiEvent.InitEvent(this.ViewInfoInternal);
			UpdateReportEvent reportEvent = new UpdateReportEvent(this.Name);
			this.DiffUpdater = new DiffUpdate(this.ResPackageInfos, downloader, resourceDiffUpdateUiEvent, reportEvent, true, EUpdateType.IndependentLang);
		}

		// Token: 0x0602E7FC RID: 190460 RVA: 0x00B02E68 File Offset: 0x00B01068
		protected virtual UniTask AnalysisManifests()
		{
			ResourceDiffUpdater.<AnalysisManifests>d__11 <AnalysisManifests>d__;
			<AnalysisManifests>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AnalysisManifests>d__.<>4__this = this;
			<AnalysisManifests>d__.<>1__state = -1;
			<AnalysisManifests>d__.<>t__builder.Start<ResourceDiffUpdater.<AnalysisManifests>d__11>(ref <AnalysisManifests>d__);
			return <AnalysisManifests>d__.<>t__builder.Task;
		}

		// Token: 0x0602E7FD RID: 190461 RVA: 0x00B02EAC File Offset: 0x00B010AC
		public virtual void CalculateSizeInfo()
		{
			if (this.UpdateStatus == EResDownloadStatus.Downloading)
			{
				return;
			}
			ValueTuple<long, long, long, long, long> valueTuple = this.DiffUpdater.CalcNeedSizeInfo();
			long item = valueTuple.Item1;
			long item2 = valueTuple.Item2;
			long item3 = valueTuple.Item3;
			long item4 = valueTuple.Item4;
			long num = 0L;
			foreach (ResPackageInfo resPackageInfo in this.ResPackageInfos)
			{
				num += resPackageInfo.CalculateSavedSizeAndTotalSize().Item2;
			}
			if (item3 == item4)
			{
				this.UpdateStatus = EResDownloadStatus.Down;
			}
			else if (item2 < item)
			{
				this.ViewInfoInternal.NotEnoughSpace = true;
				this.UpdateStatus = EResDownloadStatus.NoSpace;
			}
			else
			{
				this.ViewInfoInternal.NotEnoughSpace = false;
				this.UpdateStatus = EResDownloadStatus.None;
			}
			this.ViewInfoInternal.UpdatePatchProgress(0L, item3, item4, 0L);
			this.ViewInfoInternal.TotalSize = num;
		}

		// Token: 0x0602E7FE RID: 190462 RVA: 0x00B02F98 File Offset: 0x00B01198
		public virtual UniTask UpdateResourceProcedure()
		{
			ResourceDiffUpdater.<UpdateResourceProcedure>d__13 <UpdateResourceProcedure>d__;
			<UpdateResourceProcedure>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateResourceProcedure>d__.<>4__this = this;
			<UpdateResourceProcedure>d__.<>1__state = -1;
			<UpdateResourceProcedure>d__.<>t__builder.Start<ResourceDiffUpdater.<UpdateResourceProcedure>d__13>(ref <UpdateResourceProcedure>d__);
			return <UpdateResourceProcedure>d__.<>t__builder.Task;
		}

		// Token: 0x0602E7FF RID: 190463 RVA: 0x00B02FDC File Offset: 0x00B011DC
		public virtual void Stop()
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "ResourceDiffUpdater Stop";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Updater", this.Name);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.UpdateStatus = EResDownloadStatus.Stop;
			if (this.DiffUpdater != null)
			{
				this.DiffUpdater.Stop();
			}
		}

		// Token: 0x0602E800 RID: 190464 RVA: 0x00B0302C File Offset: 0x00B0122C
		public virtual bool IsCompleteDownloaded()
		{
			using (List<ResPackageInfo>.Enumerator enumerator = this.ResPackageInfos.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsCompleteDownload())
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x1700803E RID: 32830
		// (get) Token: 0x0602E801 RID: 190465 RVA: 0x00B03088 File Offset: 0x00B01288
		public double SpendTime
		{
			get
			{
				return this.SpendTimeInternal;
			}
		}

		// Token: 0x0602E802 RID: 190466 RVA: 0x00B03090 File Offset: 0x00B01290
		public virtual void Clear()
		{
			this.UpdateStatus = EResDownloadStatus.Cancel;
			this.Stop();
			foreach (ResPackageInfo resPackageInfo in this.ResPackageInfos)
			{
				resPackageInfo.DeleteLocalFiles();
			}
		}

		// Token: 0x0602E803 RID: 190467 RVA: 0x00B030F0 File Offset: 0x00B012F0
		public void AddOnDownloadFinish(Action<EResDownloadStatus> callback)
		{
			this.OnDownloadFinish.Add(callback);
		}

		// Token: 0x0602E804 RID: 190468 RVA: 0x00B03100 File Offset: 0x00B01300
		public void RemoveOnDownload(Action<EResDownloadStatus> callback)
		{
			int num = this.OnDownloadFinish.IndexOf(callback);
			if (num != -1)
			{
				this.OnDownloadFinish.RemoveAt(num);
			}
		}

		// Token: 0x0602E805 RID: 190469 RVA: 0x00B0312C File Offset: 0x00B0132C
		protected unsafe void InvokeDownloadFinishCallback()
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "ResourceDiffUpdater InvokeDownloadFinishCallback";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Updater", this.Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Status", this.UpdateStatus);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			foreach (Action<EResDownloadStatus> action in this.OnDownloadFinish)
			{
				action(this.UpdateStatus);
			}
		}

		// Token: 0x1700803F RID: 32831
		// (get) Token: 0x0602E806 RID: 190470 RVA: 0x00B031E0 File Offset: 0x00B013E0
		[Nullable(2)]
		public virtual ResourceUpdateViewAgent ViewInfo
		{
			[NullableContext(2)]
			get
			{
				return this.ViewInfoInternal;
			}
		}

		// Token: 0x0401A6BC RID: 108220
		public string Name = "";

		// Token: 0x0401A6BD RID: 108221
		public int Priority;

		// Token: 0x0401A6BE RID: 108222
		public EResDownloadStatus UpdateStatus;

		// Token: 0x0401A6BF RID: 108223
		protected double SpendTimeInternal;

		// Token: 0x0401A6C0 RID: 108224
		protected List<ResPackageInfo> ResPackageInfos = new List<ResPackageInfo>();

		// Token: 0x0401A6C1 RID: 108225
		[Nullable(2)]
		protected DiffUpdate DiffUpdater;

		// Token: 0x0401A6C2 RID: 108226
		[Nullable(2)]
		protected ResourceUpdateViewAgent ViewInfoInternal;

		// Token: 0x0401A6C3 RID: 108227
		protected List<Action<EResDownloadStatus>> OnDownloadFinish = new List<Action<EResDownloadStatus>>();
	}
}
