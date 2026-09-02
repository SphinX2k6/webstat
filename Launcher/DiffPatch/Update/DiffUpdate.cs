using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.DiffPatch.Data;
using CSharpScript.Launcher.Download;
using CSharpScript.Launcher.Platform;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.DiffPatch.Update
{
	// Token: 0x0200462A RID: 17962
	[NullableContext(1)]
	[Nullable(0)]
	public class DiffUpdate
	{
		// Token: 0x0602EEB4 RID: 192180 RVA: 0x00B1CC8C File Offset: 0x00B1AE8C
		public DiffUpdate(List<ResPackageInfo> resPackageInfos, UrlPrefixDownload downloader, [Nullable(2)] IDiffUpdateUiEvent uiEvent, [Nullable(2)] IDiffUpdateReportEvent reportEvent, bool forceUpdate = false, EUpdateType updateType = EUpdateType.NormalUpdate)
		{
			this.ResPackageInfos = resPackageInfos;
			this.Downloader = downloader;
			this.UiEvent = uiEvent;
			this.ReportEvent = reportEvent;
			this.ForceUpdate = forceUpdate;
			this.UpdateType = updateType;
		}

		// Token: 0x1700809B RID: 32923
		// (get) Token: 0x0602EEB5 RID: 192181 RVA: 0x00B1CCF4 File Offset: 0x00B1AEF4
		protected UKuroNetworkChange NetworkListener
		{
			get
			{
				if (this.NetworkListenerInternal == null)
				{
					this.NetworkListenerInternal = new UKuroNetworkChange();
				}
				return this.NetworkListenerInternal;
			}
		}

		// Token: 0x0602EEB6 RID: 192182 RVA: 0x00B1CD10 File Offset: 0x00B1AF10
		[return: Nullable(2)]
		private RequestFileInfo CreateManifestRequestOrNot(string filePath, string hash, string remoteRoute)
		{
			if (hash == null || hash.Length == 0)
			{
				return null;
			}
			if (UKuroLauncherLibrary.CheckFileSha1(filePath, hash))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "已下载过清单文件";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("manifest", filePath);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			if (UBlueprintPathsLibrary.FileExists(filePath))
			{
				UKuroLauncherLibrary.DeleteFile(filePath);
			}
			return new RequestFileInfo
			{
				HashString = hash,
				Size = new long?(0L),
				bUseDownloadCache = false,
				Url = (remoteRoute ?? ""),
				SavePath = filePath
			};
		}

		// Token: 0x0602EEB7 RID: 192183 RVA: 0x00B1CDA0 File Offset: 0x00B1AFA0
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public UniTask<List<RequestFileInfo>> HasContentOnRemote()
		{
			DiffUpdate.<HasContentOnRemote>d__23 <HasContentOnRemote>d__;
			<HasContentOnRemote>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<RequestFileInfo>>.Create();
			<HasContentOnRemote>d__.<>4__this = this;
			<HasContentOnRemote>d__.<>1__state = -1;
			<HasContentOnRemote>d__.<>t__builder.Start<DiffUpdate.<HasContentOnRemote>d__23>(ref <HasContentOnRemote>d__);
			return <HasContentOnRemote>d__.<>t__builder.Task;
		}

		// Token: 0x0602EEB8 RID: 192184 RVA: 0x00B1CDE4 File Offset: 0x00B1AFE4
		[NullableContext(0)]
		public UniTask<bool> DownloadManifests([Nullable(1)] List<RequestFileInfo> requests)
		{
			DiffUpdate.<DownloadManifests>d__24 <DownloadManifests>d__;
			<DownloadManifests>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DownloadManifests>d__.<>4__this = this;
			<DownloadManifests>d__.requests = requests;
			<DownloadManifests>d__.<>1__state = -1;
			<DownloadManifests>d__.<>t__builder.Start<DiffUpdate.<DownloadManifests>d__24>(ref <DownloadManifests>d__);
			return <DownloadManifests>d__.<>t__builder.Task;
		}

		// Token: 0x0602EEB9 RID: 192185 RVA: 0x00B1CE30 File Offset: 0x00B1B030
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private ValueTuple<bool, string> LoadManifest(string filePath)
		{
			string inCipher = null;
			if (!UKuroStaticLibrary.LoadFileToString(ref inCipher, filePath))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "index文件不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("file", filePath);
				instance.Warn(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return new ValueTuple<bool, string>(false, "");
			}
			string text = null;
			if (!UKuroLauncherLibrary.Decrypt(inCipher, ref text))
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "index文件内容无法解析";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("file", filePath);
				instance2.Warn(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return new ValueTuple<bool, string>(false, "");
			}
			string item = text.Trim();
			return new ValueTuple<bool, string>(true, item);
		}

		// Token: 0x0602EEBA RID: 192186 RVA: 0x00B1CEC4 File Offset: 0x00B1B0C4
		[NullableContext(0)]
		public UniTask<bool> ResolveManifests()
		{
			DiffUpdate.<ResolveManifests>d__26 <ResolveManifests>d__;
			<ResolveManifests>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ResolveManifests>d__.<>4__this = this;
			<ResolveManifests>d__.<>1__state = -1;
			<ResolveManifests>d__.<>t__builder.Start<DiffUpdate.<ResolveManifests>d__26>(ref <ResolveManifests>d__);
			return <ResolveManifests>d__.<>t__builder.Task;
		}

		// Token: 0x0602EEBB RID: 192187 RVA: 0x00B1CF08 File Offset: 0x00B1B108
		public void ForEachExpectedTargetFile(Action<string, string, long, string> visitor)
		{
			foreach (ResPackageInfo resPackageInfo in this.ResPackageInfos)
			{
				if (resPackageInfo.NeedProcessUpdate(this.ForceUpdate))
				{
					resPackageInfo.EnumerateExpectedTargetFiles(visitor);
				}
			}
		}

		// Token: 0x0602EEBC RID: 192188 RVA: 0x00B1CF6C File Offset: 0x00B1B16C
		public void ForEachExpectedExtraTargetFile(Action<string, string, long, string> visitor)
		{
			if (this.ExtraRequireFileInfo != null && this.ExtraRequireFileInfo.Count > 0)
			{
				foreach (RequireFileInfo requireFileInfo in this.ExtraRequireFileInfo)
				{
					string text = requireFileInfo.LocalPath.Replace("\\", "/");
					int num = text.LastIndexOf('/');
					string arg = text.Substring(num + 1);
					visitor(arg, requireFileInfo.Hash, requireFileInfo.Size, requireFileInfo.LocalPath);
				}
			}
		}

		// Token: 0x0602EEBD RID: 192189 RVA: 0x00B1D010 File Offset: 0x00B1B210
		[return: Nullable(new byte[]
		{
			0,
			0,
			1,
			1
		})]
		public UniTask<ValueTuple<bool, List<RequireFileInfo>, long, EUpdateMode, long, long>> AnalyzeRequireFiles(EUpdateMode updateMode = EUpdateMode.All, bool firstTimeUpdate = false, bool bIsLauncher = false)
		{
			DiffUpdate.<AnalyzeRequireFiles>d__29 <AnalyzeRequireFiles>d__;
			<AnalyzeRequireFiles>d__.<>t__builder = AsyncUniTaskMethodBuilder<ValueTuple<bool, List<RequireFileInfo>, long, EUpdateMode, long, long>>.Create();
			<AnalyzeRequireFiles>d__.<>4__this = this;
			<AnalyzeRequireFiles>d__.updateMode = updateMode;
			<AnalyzeRequireFiles>d__.firstTimeUpdate = firstTimeUpdate;
			<AnalyzeRequireFiles>d__.bIsLauncher = bIsLauncher;
			<AnalyzeRequireFiles>d__.<>1__state = -1;
			<AnalyzeRequireFiles>d__.<>t__builder.Start<DiffUpdate.<AnalyzeRequireFiles>d__29>(ref <AnalyzeRequireFiles>d__);
			return <AnalyzeRequireFiles>d__.<>t__builder.Task;
		}

		// Token: 0x0602EEBE RID: 192190 RVA: 0x00B1D06C File Offset: 0x00B1B26C
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"totalNeed",
			"savedSize",
			"extra"
		})]
		private ValueTuple<long, long, long> CalcTotalNeedAndSaved([Nullable(1)] List<LocalFileInfo> fileSpace)
		{
			long num = 0L;
			long num2 = 0L;
			long num3 = 0L;
			long num4 = 0L;
			long num5 = 0L;
			foreach (ResPackageInfo resPackageInfo in this.ResPackageInfos)
			{
				if (resPackageInfo.NeedProcessUpdate(this.ForceUpdate))
				{
					PackageSpaceModel spaceModel = resPackageInfo.SpaceModel;
					num += spaceModel.DownloadSize;
					num2 += spaceModel.SavedSize;
					long num6 = num4 + spaceModel.PatchPeak;
					if (num5 < num6)
					{
						num5 = num6;
					}
					num4 += spaceModel.PatchNetDelta;
					num3 += spaceModel.CopySize;
				}
			}
			long num7 = num4 + num3;
			long num8 = (num5 > num7) ? num5 : num7;
			if (num8 < 0L)
			{
				num8 = 0L;
			}
			long num9 = num + num8;
			long num10 = num2;
			foreach (LocalFileInfo localFileInfo in fileSpace)
			{
				num9 += localFileInfo.ExpectSize;
				num10 += localFileInfo.GetLocalSize();
			}
			return new ValueTuple<long, long, long>(num9, num10, num8);
		}

		// Token: 0x0602EEBF RID: 192191 RVA: 0x00B1D1A0 File Offset: 0x00B1B3A0
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"need",
			"localSaved",
			"extra"
		})]
		private ValueTuple<long, long, long> CalcRealtimeNeedSpace([Nullable(1)] List<RequireFileInfo> requireFiles, bool bIncludePatchExtra)
		{
			long num = 2097152L;
			long num2 = 10485760L;
			long num3 = 0L;
			long num4 = 0L;
			foreach (RequireFileInfo requireFileInfo in requireFiles)
			{
				long localSize = new DestFileInfo(requireFileInfo.LocalPath, requireFileInfo.LocalPath, requireFileInfo.Size, requireFileInfo.RemoteRoute, requireFileInfo.Hash).GetLocalSize();
				num4 += localSize;
				long num5 = requireFileInfo.Size - localSize;
				if (num5 > 0L)
				{
					num3 += num5;
				}
			}
			long num6 = 0L;
			if (bIncludePatchExtra)
			{
				num6 = this.CalcTotalNeedAndSaved(new List<LocalFileInfo>()).Item3;
				num3 += num6;
			}
			num3 += num2;
			return new ValueTuple<long, long, long>((num3 >= num) ? num3 : num, num4, num6);
		}

		// Token: 0x0602EEC0 RID: 192192 RVA: 0x00B1D27C File Offset: 0x00B1B47C
		[NullableContext(0)]
		public UniTask<bool> DownloadFiles([Nullable(1)] List<RequireFileInfo> requireFiles, long needSpace, bool bUseBgDownload = false)
		{
			DiffUpdate.<DownloadFiles>d__32 <DownloadFiles>d__;
			<DownloadFiles>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DownloadFiles>d__.<>4__this = this;
			<DownloadFiles>d__.requireFiles = requireFiles;
			<DownloadFiles>d__.needSpace = needSpace;
			<DownloadFiles>d__.bUseBgDownload = bUseBgDownload;
			<DownloadFiles>d__.<>1__state = -1;
			<DownloadFiles>d__.<>t__builder.Start<DiffUpdate.<DownloadFiles>d__32>(ref <DownloadFiles>d__);
			return <DownloadFiles>d__.<>t__builder.Task;
		}

		// Token: 0x0602EEC1 RID: 192193 RVA: 0x00B1D2D8 File Offset: 0x00B1B4D8
		[return: Nullable(new byte[]
		{
			0,
			0,
			1,
			1
		})]
		public UniTask<ValueTuple<bool, List<RequireFileInfo>, long>> ExecutePatch()
		{
			DiffUpdate.<ExecutePatch>d__33 <ExecutePatch>d__;
			<ExecutePatch>d__.<>t__builder = AsyncUniTaskMethodBuilder<ValueTuple<bool, List<RequireFileInfo>, long>>.Create();
			<ExecutePatch>d__.<>4__this = this;
			<ExecutePatch>d__.<>1__state = -1;
			<ExecutePatch>d__.<>t__builder.Start<DiffUpdate.<ExecutePatch>d__33>(ref <ExecutePatch>d__);
			return <ExecutePatch>d__.<>t__builder.Task;
		}

		// Token: 0x0602EEC2 RID: 192194 RVA: 0x00B1D31C File Offset: 0x00B1B51C
		[NullableContext(0)]
		public UniTask<bool> DownloadMissFiles([Nullable(1)] List<RequireFileInfo> requireFiles, long needSpace, bool bHasMiss, bool bUseBgDownload = false)
		{
			DiffUpdate.<DownloadMissFiles>d__34 <DownloadMissFiles>d__;
			<DownloadMissFiles>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DownloadMissFiles>d__.<>4__this = this;
			<DownloadMissFiles>d__.requireFiles = requireFiles;
			<DownloadMissFiles>d__.needSpace = needSpace;
			<DownloadMissFiles>d__.bHasMiss = bHasMiss;
			<DownloadMissFiles>d__.bUseBgDownload = bUseBgDownload;
			<DownloadMissFiles>d__.<>1__state = -1;
			<DownloadMissFiles>d__.<>t__builder.Start<DiffUpdate.<DownloadMissFiles>d__34>(ref <DownloadMissFiles>d__);
			return <DownloadMissFiles>d__.<>t__builder.Task;
		}

		// Token: 0x0602EEC3 RID: 192195 RVA: 0x00B1D380 File Offset: 0x00B1B580
		[NullableContext(0)]
		public UniTask<bool> MoveSameFiles()
		{
			DiffUpdate.<MoveSameFiles>d__35 <MoveSameFiles>d__;
			<MoveSameFiles>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<MoveSameFiles>d__.<>4__this = this;
			<MoveSameFiles>d__.<>1__state = -1;
			<MoveSameFiles>d__.<>t__builder.Start<DiffUpdate.<MoveSameFiles>d__35>(ref <MoveSameFiles>d__);
			return <MoveSameFiles>d__.<>t__builder.Task;
		}

		// Token: 0x0602EEC4 RID: 192196 RVA: 0x00B1D3C4 File Offset: 0x00B1B5C4
		public unsafe bool ProcessRecord()
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "res updated and update record.";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("forceUpdate", this.ForceUpdate);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("updateType", Enum.GetName(typeof(EUpdateType), this.UpdateType));
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			string s_step_id = "diffUpdate_update_record";
			HotPatchLog hotPatchLog = new HotPatchLog();
			hotPatchLog.s_step_id = s_step_id;
			if (this.ReportEvent != null)
			{
				this.ReportEvent.Start(hotPatchLog, null);
			}
			foreach (ResPackageInfo resPackageInfo in this.ResPackageInfos)
			{
				if (resPackageInfo.NeedProcessUpdate(this.ForceUpdate))
				{
					resPackageInfo.UpdateRecord();
					if (resPackageInfo.HadDeletion)
					{
						this.HadDiskChange = true;
					}
				}
			}
			HotPatchLog hotPatchLog2 = new HotPatchLog();
			hotPatchLog2.s_step_id = s_step_id;
			if (this.ReportEvent != null)
			{
				this.ReportEvent.End(hotPatchLog2, null);
			}
			return true;
		}

		// Token: 0x0602EEC5 RID: 192197 RVA: 0x00B1D4F8 File Offset: 0x00B1B6F8
		public bool NeedReboot()
		{
			foreach (ResPackageInfo resPackageInfo in this.ResPackageInfos)
			{
				if (resPackageInfo.NeedProcessUpdate(this.ForceUpdate) && resPackageInfo.NeedRebootModuleOrApp())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0602EEC6 RID: 192198 RVA: 0x00B1D564 File Offset: 0x00B1B764
		public bool IsHotFixOrNot()
		{
			foreach (ResPackageInfo resPackageInfo in this.ResPackageInfos)
			{
				if (resPackageInfo.NeedProcessUpdate(this.ForceUpdate) && resPackageInfo.IsHotFixOrNot())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0602EEC7 RID: 192199 RVA: 0x00B1D5D0 File Offset: 0x00B1B7D0
		public unsafe void MountFiles()
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "will mount the res files.";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("forceUpdate", this.ForceUpdate);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("updateType", Enum.GetName(typeof(EUpdateType), this.UpdateType));
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (this.UiEvent != null)
			{
				this.UiEvent.ShowInfo(false, "MountPak", false);
			}
			foreach (ResPackageInfo resPackageInfo in this.ResPackageInfos)
			{
				if (resPackageInfo.NeedProcessUpdate(this.ForceUpdate))
				{
					ValueTuple<List<string>, List<ValueTuple<string, string, int>>> mountInfos = resPackageInfo.GetMountInfos();
					List<string> item = mountInfos.Item1;
					List<ValueTuple<string, string, int>> item2 = mountInfos.Item2;
					foreach (string path in item)
					{
						UKuroPakMountStatic.UnmountPak(path);
					}
					foreach (ValueTuple<string, string, int> valueTuple in item2)
					{
						string item3 = valueTuple.Item1;
						string item4 = valueTuple.Item2;
						int item5 = valueTuple.Item3;
						UKuroPakMountStatic.MountPak(item3, item5);
						if (!Singleton<Platform>.Instance.IsCloudGame())
						{
							UKuroPakMountStatic.AddSha1Check(item3, item4);
						}
					}
				}
			}
			if (!Singleton<Platform>.Instance.IsCloudGame())
			{
				UKuroPakMountStatic.StartSha1Check();
			}
		}

		// Token: 0x0602EEC8 RID: 192200 RVA: 0x00B1D78C File Offset: 0x00B1B98C
		[NullableContext(0)]
		public unsafe ValueTuple<long, long, long, long, long> CalcNeedSizeInfo()
		{
			List<RequireFileInfo> list = new List<RequireFileInfo>();
			foreach (ResPackageInfo resPackageInfo in this.ResPackageInfos)
			{
				if (resPackageInfo.NeedProcessUpdate(this.ForceUpdate))
				{
					List<RequireFileInfo> item = resPackageInfo.AnalyzeRequireFiles(false).Item1;
					list.AddRange(item);
				}
			}
			ValueTuple<long, long, long> valueTuple = this.CalcTotalNeedAndSaved(this.ExtraFileSpace);
			long item2 = valueTuple.Item1;
			long item3 = valueTuple.Item2;
			long num = 0L;
			foreach (RequireFileInfo requireFileInfo in list)
			{
				num += requireFileInfo.Size;
			}
			foreach (RequireFileInfo requireFileInfo2 in this.ExtraRequireFileInfo)
			{
				num += requireFileInfo2.Size;
			}
			string resSaveDir = ResPackageInfo.GetResSaveDir();
			long item4 = ResPackageInfo.GetTotalAndFreeSpace(resSaveDir).Item2;
			long num2 = item2 - item3 + 10485760L;
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "calc need size info.";
			<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("path", resSaveDir);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("needSize", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("freeSize", item4);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("savedSize", item3);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("totalNeed", item2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("totalReqFileSize", num);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			return new ValueTuple<long, long, long, long, long>(num2, item4, item3, item2, num);
		}

		// Token: 0x0602EEC9 RID: 192201 RVA: 0x00B1D9A4 File Offset: 0x00B1BBA4
		public void Stop()
		{
			this.IsStopped = true;
			if (this.Downloader != null)
			{
				this.Downloader.CancelDownload();
			}
			if (this.BgDownloader != null)
			{
				this.BgDownloader.Cancel();
			}
		}

		// Token: 0x0602EECA RID: 192202 RVA: 0x00B1D9D3 File Offset: 0x00B1BBD3
		public void Resume()
		{
			this.IsStopped = false;
		}

		// Token: 0x0602EECB RID: 192203 RVA: 0x00B1D9DC File Offset: 0x00B1BBDC
		[NullableContext(0)]
		public UniTask<bool> PromptNetwork(long updateSize)
		{
			DiffUpdate.<PromptNetwork>d__43 <PromptNetwork>d__;
			<PromptNetwork>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PromptNetwork>d__.<>4__this = this;
			<PromptNetwork>d__.updateSize = updateSize;
			<PromptNetwork>d__.<>1__state = -1;
			<PromptNetwork>d__.<>t__builder.Start<DiffUpdate.<PromptNetwork>d__43>(ref <PromptNetwork>d__);
			return <PromptNetwork>d__.<>t__builder.Task;
		}

		// Token: 0x0602EECC RID: 192204 RVA: 0x00B1DA28 File Offset: 0x00B1BC28
		[NullableContext(0)]
		private UniTask<bool> ForegroundDownload([Nullable(1)] List<RequireFileInfo> requireFiles)
		{
			DiffUpdate.<ForegroundDownload>d__44 <ForegroundDownload>d__;
			<ForegroundDownload>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ForegroundDownload>d__.<>4__this = this;
			<ForegroundDownload>d__.requireFiles = requireFiles;
			<ForegroundDownload>d__.<>1__state = -1;
			<ForegroundDownload>d__.<>t__builder.Start<DiffUpdate.<ForegroundDownload>d__44>(ref <ForegroundDownload>d__);
			return <ForegroundDownload>d__.<>t__builder.Task;
		}

		// Token: 0x0602EECD RID: 192205 RVA: 0x00B1DA74 File Offset: 0x00B1BC74
		[NullableContext(0)]
		private UniTask<bool> UseBgDownload([Nullable(1)] List<RequireFileInfo> requireFiles)
		{
			DiffUpdate.<UseBgDownload>d__45 <UseBgDownload>d__;
			<UseBgDownload>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UseBgDownload>d__.<>4__this = this;
			<UseBgDownload>d__.requireFiles = requireFiles;
			<UseBgDownload>d__.<>1__state = -1;
			<UseBgDownload>d__.<>t__builder.Start<DiffUpdate.<UseBgDownload>d__45>(ref <UseBgDownload>d__);
			return <UseBgDownload>d__.<>t__builder.Task;
		}

		// Token: 0x0602EECE RID: 192206 RVA: 0x00B1DAC0 File Offset: 0x00B1BCC0
		[NullableContext(0)]
		private UniTask<bool> DownloadRestrictByNetwork([Nullable(new byte[]
		{
			1,
			0,
			1
		})] Func<bool, UniTask<IDownloadResult>> downloadFunc, [Nullable(new byte[]
		{
			1,
			1,
			0
		})] Func<string, UniTask<bool>> showFailedDialog)
		{
			DiffUpdate.<DownloadRestrictByNetwork>d__46 <DownloadRestrictByNetwork>d__;
			<DownloadRestrictByNetwork>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DownloadRestrictByNetwork>d__.<>4__this = this;
			<DownloadRestrictByNetwork>d__.downloadFunc = downloadFunc;
			<DownloadRestrictByNetwork>d__.showFailedDialog = showFailedDialog;
			<DownloadRestrictByNetwork>d__.<>1__state = -1;
			<DownloadRestrictByNetwork>d__.<>t__builder.Start<DiffUpdate.<DownloadRestrictByNetwork>d__46>(ref <DownloadRestrictByNetwork>d__);
			return <DownloadRestrictByNetwork>d__.<>t__builder.Task;
		}

		// Token: 0x0602EECF RID: 192207 RVA: 0x00B1DB14 File Offset: 0x00B1BD14
		[return: Nullable(0)]
		private UniTask<ValueTuple<int, int>> BackgroundDownload(UKuroBgPrefixDownload bgDownloader, TArray<string> prefixList, TArray<FKuroRequestDownloadInfo> requestInfos, Action<int, long> cb, bool retry = false)
		{
			DiffUpdate.<BackgroundDownload>d__47 <BackgroundDownload>d__;
			<BackgroundDownload>d__.<>t__builder = AsyncUniTaskMethodBuilder<ValueTuple<int, int>>.Create();
			<BackgroundDownload>d__.<>4__this = this;
			<BackgroundDownload>d__.bgDownloader = bgDownloader;
			<BackgroundDownload>d__.prefixList = prefixList;
			<BackgroundDownload>d__.requestInfos = requestInfos;
			<BackgroundDownload>d__.cb = cb;
			<BackgroundDownload>d__.retry = retry;
			<BackgroundDownload>d__.<>1__state = -1;
			<BackgroundDownload>d__.<>t__builder.Start<DiffUpdate.<BackgroundDownload>d__47>(ref <BackgroundDownload>d__);
			return <BackgroundDownload>d__.<>t__builder.Task;
		}

		// Token: 0x0602EED0 RID: 192208 RVA: 0x00B1DB84 File Offset: 0x00B1BD84
		[NullableContext(0)]
		protected UniTask<bool> CheckUsedPatch(long needSize, long patchDownloadSize, long allDownloadSize)
		{
			DiffUpdate.<CheckUsedPatch>d__48 <CheckUsedPatch>d__;
			<CheckUsedPatch>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CheckUsedPatch>d__.<>4__this = this;
			<CheckUsedPatch>d__.needSize = needSize;
			<CheckUsedPatch>d__.patchDownloadSize = patchDownloadSize;
			<CheckUsedPatch>d__.allDownloadSize = allDownloadSize;
			<CheckUsedPatch>d__.<>1__state = -1;
			<CheckUsedPatch>d__.<>t__builder.Start<DiffUpdate.<CheckUsedPatch>d__48>(ref <CheckUsedPatch>d__);
			return <CheckUsedPatch>d__.<>t__builder.Task;
		}

		// Token: 0x0602EED1 RID: 192209 RVA: 0x00B1DBE0 File Offset: 0x00B1BDE0
		[NullableContext(0)]
		protected UniTask<bool> DoesSavedDirHaveEnoughSpace(long needSize)
		{
			DiffUpdate.<DoesSavedDirHaveEnoughSpace>d__49 <DoesSavedDirHaveEnoughSpace>d__;
			<DoesSavedDirHaveEnoughSpace>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DoesSavedDirHaveEnoughSpace>d__.<>4__this = this;
			<DoesSavedDirHaveEnoughSpace>d__.needSize = needSize;
			<DoesSavedDirHaveEnoughSpace>d__.<>1__state = -1;
			<DoesSavedDirHaveEnoughSpace>d__.<>t__builder.Start<DiffUpdate.<DoesSavedDirHaveEnoughSpace>d__49>(ref <DoesSavedDirHaveEnoughSpace>d__);
			return <DoesSavedDirHaveEnoughSpace>d__.<>t__builder.Task;
		}

		// Token: 0x0602EED2 RID: 192210 RVA: 0x00B1DC2B File Offset: 0x00B1BE2B
		public void RegisterExtraRequireFiles(List<LocalFileInfo> extraFileSpace, List<RequireFileInfo> extraRequireFileInfo)
		{
			this.ExtraFileSpace = extraFileSpace;
			this.ExtraRequireFileInfo = extraRequireFileInfo;
		}

		// Token: 0x0602EED3 RID: 192211 RVA: 0x00B1DC3C File Offset: 0x00B1BE3C
		public int RemoveExtraRequireFiles(Func<string, bool> shouldRemove)
		{
			int count = this.ExtraRequireFileInfo.Count;
			this.ExtraRequireFileInfo.RemoveAll((RequireFileInfo it) => shouldRemove(it.LocalPath));
			this.ExtraFileSpace.RemoveAll((LocalFileInfo it) => shouldRemove(it.FilePath));
			return count - this.ExtraRequireFileInfo.Count;
		}

		// Token: 0x0602EED4 RID: 192212 RVA: 0x00B1DCA0 File Offset: 0x00B1BEA0
		public void AppendResPackageInfo(List<ResPackageInfo> resPackageInfos)
		{
			foreach (ResPackageInfo item in resPackageInfos)
			{
				if (!this.ResPackageInfos.Contains(item))
				{
					this.ResPackageInfos.Add(item);
				}
			}
		}

		// Token: 0x0602EED5 RID: 192213 RVA: 0x00B1DD04 File Offset: 0x00B1BF04
		public void AddSpaceNotEnoughHandler(Action<long, long, bool> handler)
		{
			this.SpaceNotEnoughHandlers.Add(handler);
		}

		// Token: 0x0602EED6 RID: 192214 RVA: 0x00B1DD14 File Offset: 0x00B1BF14
		public void InvokeSpaceNotEnoughHandlers(long needSize, long freeSize, bool isRetry)
		{
			foreach (Action<long, long, bool> action in this.SpaceNotEnoughHandlers)
			{
				action(needSize, freeSize, isRetry);
			}
		}

		// Token: 0x0401AB2D RID: 109357
		private bool CanceledByNetworkChange;

		// Token: 0x0401AB2E RID: 109358
		private bool UserAnsweredDialog;

		// Token: 0x0401AB2F RID: 109359
		private ENetworkType LastNetworkType = ENetworkType.None;

		// Token: 0x0401AB30 RID: 109360
		private bool IsAllowCellDownload;

		// Token: 0x0401AB31 RID: 109361
		[Nullable(2)]
		private UKuroBgPrefixDownload BgDownloader;

		// Token: 0x0401AB32 RID: 109362
		[Nullable(2)]
		private UKuroNetworkChange NetworkListenerInternal;

		// Token: 0x0401AB33 RID: 109363
		[Nullable(2)]
		private Action<bool> DialogCb;

		// Token: 0x0401AB34 RID: 109364
		private Action<byte> OnChangeNetworkType;

		// Token: 0x0401AB35 RID: 109365
		private bool IsStopped;

		// Token: 0x0401AB36 RID: 109366
		private List<LocalFileInfo> ExtraFileSpace = new List<LocalFileInfo>();

		// Token: 0x0401AB37 RID: 109367
		private List<RequireFileInfo> ExtraRequireFileInfo = new List<RequireFileInfo>();

		// Token: 0x0401AB38 RID: 109368
		private List<Action<long, long, bool>> SpaceNotEnoughHandlers = new List<Action<long, long, bool>>();

		// Token: 0x0401AB39 RID: 109369
		private readonly List<ResPackageInfo> ResPackageInfos;

		// Token: 0x0401AB3A RID: 109370
		private UrlPrefixDownload Downloader;

		// Token: 0x0401AB3B RID: 109371
		[Nullable(2)]
		private readonly IDiffUpdateUiEvent UiEvent;

		// Token: 0x0401AB3C RID: 109372
		[Nullable(2)]
		private readonly IDiffUpdateReportEvent ReportEvent;

		// Token: 0x0401AB3D RID: 109373
		private readonly bool ForceUpdate;

		// Token: 0x0401AB3E RID: 109374
		public bool HadDiskChange;

		// Token: 0x0401AB3F RID: 109375
		private readonly EUpdateType UpdateType;
	}
}
