using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.DiffPatch.Procedure
{
	// Token: 0x02004638 RID: 17976
	public abstract class BaseDiffPatchProcedure : IDiffPatchProcedure
	{
		// Token: 0x170080A2 RID: 32930
		// (get) Token: 0x0602EF2E RID: 192302 RVA: 0x00B1F64B File Offset: 0x00B1D84B
		// (set) Token: 0x0602EF2F RID: 192303 RVA: 0x00B1F653 File Offset: 0x00B1D853
		public bool HadOldResCleaned { get; private set; }

		// Token: 0x0602EF30 RID: 192304 RVA: 0x00B1F65C File Offset: 0x00B1D85C
		[NullableContext(1)]
		public BaseDiffPatchProcedure(AppPathMisc pathMisc, HotFixManager viewMgr)
		{
			this.PathMisc = pathMisc;
			this.ViewMgr = viewMgr;
		}

		// Token: 0x0602EF31 RID: 192305 RVA: 0x00B1F698 File Offset: 0x00B1D898
		public UniTask<bool> Start()
		{
			BaseDiffPatchProcedure.<Start>d__9 <Start>d__;
			<Start>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Start>d__.<>4__this = this;
			<Start>d__.<>1__state = -1;
			<Start>d__.<>t__builder.Start<BaseDiffPatchProcedure.<Start>d__9>(ref <Start>d__);
			return <Start>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF32 RID: 192306 RVA: 0x00B1F6DC File Offset: 0x00B1D8DC
		public UniTask<bool> GetRemoteVersionConfig()
		{
			BaseDiffPatchProcedure.<GetRemoteVersionConfig>d__10 <GetRemoteVersionConfig>d__;
			<GetRemoteVersionConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<GetRemoteVersionConfig>d__.<>4__this = this;
			<GetRemoteVersionConfig>d__.<>1__state = -1;
			<GetRemoteVersionConfig>d__.<>t__builder.Start<BaseDiffPatchProcedure.<GetRemoteVersionConfig>d__10>(ref <GetRemoteVersionConfig>d__);
			return <GetRemoteVersionConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF33 RID: 192307 RVA: 0x00B1F720 File Offset: 0x00B1D920
		public bool HasPreDownloadData()
		{
			return Singleton<LauncherStorageLib>.Instance.GetDeviceSaved<string>(ELauncherStorageDeviceKey.PreDownloadRecord, "") == Singleton<RemoteInfo>.Instance.NewConfig.PackageVersion || Singleton<LauncherStorageLib>.Instance.GetDeviceSaved<string>(ELauncherStorageDeviceKey.PreDownloadState, "") != "";
		}

		// Token: 0x0602EF34 RID: 192308 RVA: 0x00B1F776 File Offset: 0x00B1D976
		public bool IsFirstTimeUpdateForPackage()
		{
			return ProcedureUtil.IsFirstTimeUpdateForPackage();
		}

		// Token: 0x0602EF35 RID: 192309 RVA: 0x00B1F780 File Offset: 0x00B1D980
		public unsafe EUpdateMode GetPatchUpdateMode()
		{
			if (!Singleton<Platform>.Instance.IsMobilePlatform())
			{
				return EUpdateMode.All;
			}
			bool flag = this.IsFirstTimeUpdateForPackage();
			if (flag)
			{
				EUpdateMode eupdateMode = Singleton<LauncherStorageLib>.Instance.GetDeviceSaved<EUpdateMode>(ELauncherStorageDeviceKey.MajorVerPatchMode, EUpdateMode.All);
				bool flag2 = this.HasPreDownloadData();
				if (flag2)
				{
					eupdateMode = EUpdateMode.Diff;
				}
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "get patch update mode";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("firstTimeUpdate", flag);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("hasPreDownloadData", flag2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("patchMode", eupdateMode);
				instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return eupdateMode;
			}
			return EUpdateMode.All;
		}

		// Token: 0x0602EF36 RID: 192310 RVA: 0x00B1F83C File Offset: 0x00B1DA3C
		public UniTask<bool> IsAppVersionChange()
		{
			BaseDiffPatchProcedure.<IsAppVersionChange>d__14 <IsAppVersionChange>d__;
			<IsAppVersionChange>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<IsAppVersionChange>d__.<>4__this = this;
			<IsAppVersionChange>d__.<>1__state = -1;
			<IsAppVersionChange>d__.<>t__builder.Start<BaseDiffPatchProcedure.<IsAppVersionChange>d__14>(ref <IsAppVersionChange>d__);
			return <IsAppVersionChange>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF37 RID: 192311 RVA: 0x00B1F880 File Offset: 0x00B1DA80
		public virtual UniTask<bool> UpdateResource(bool bUseBgDownload, [Nullable(1)] DiffUpdate update, bool bIsLauncher)
		{
			BaseDiffPatchProcedure.<UpdateResource>d__15 <UpdateResource>d__;
			<UpdateResource>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UpdateResource>d__.<>4__this = this;
			<UpdateResource>d__.update = update;
			<UpdateResource>d__.bIsLauncher = bIsLauncher;
			<UpdateResource>d__.<>1__state = -1;
			<UpdateResource>d__.<>t__builder.Start<BaseDiffPatchProcedure.<UpdateResource>d__15>(ref <UpdateResource>d__);
			return <UpdateResource>d__.<>t__builder.Task;
		}

		// Token: 0x170080A3 RID: 32931
		// (get) Token: 0x0602EF38 RID: 192312 RVA: 0x00B1F8D3 File Offset: 0x00B1DAD3
		// (set) Token: 0x0602EF39 RID: 192313 RVA: 0x00B1F8DB File Offset: 0x00B1DADB
		[Nullable(1)]
		public Func<DiffUpdate, HotFixManager, UniTask> RegistryExtraPack { [NullableContext(1)] get; [NullableContext(1)] set; } = (DiffUpdate update, HotFixManager hotFixManager) => UniTask.CompletedTask;

		// Token: 0x0602EF3A RID: 192314 RVA: 0x00B1F8E4 File Offset: 0x00B1DAE4
		public virtual void PreComplete()
		{
			RemoteInfo instance = Singleton<RemoteInfo>.Instance;
			VersionItem versionItem;
			if (instance == null)
			{
				versionItem = null;
			}
			else
			{
				RemoteVersionConfig newConfig = instance.NewConfig;
				versionItem = ((newConfig != null) ? newConfig.ResVersions.GetValueOrDefault("launcher") : null);
			}
			VersionItem versionItem2 = versionItem;
			if (versionItem2 != null)
			{
				Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<string>(ELauncherStorageDeviceKey.LauncherPatchVersion, versionItem2.Version);
			}
			RemoteInfo instance2 = Singleton<RemoteInfo>.Instance;
			VersionItem versionItem3;
			if (instance2 == null)
			{
				versionItem3 = null;
			}
			else
			{
				RemoteVersionConfig newConfig2 = instance2.NewConfig;
				versionItem3 = ((newConfig2 != null) ? newConfig2.ResVersions.GetValueOrDefault("resource") : null);
			}
			VersionItem versionItem4 = versionItem3;
			if (versionItem4 != null)
			{
				Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<string>(ELauncherStorageDeviceKey.PatchVersion, versionItem4.Version);
			}
			RemoteInfo instance3 = Singleton<RemoteInfo>.Instance;
			bool flag;
			if (instance3 == null)
			{
				flag = (null != null);
			}
			else
			{
				RemoteVersionConfig newConfig3 = instance3.NewConfig;
				flag = (((newConfig3 != null) ? newConfig3.ChangeList : null) != null);
			}
			if (flag && Singleton<RemoteInfo>.Instance.NewConfig.ChangeList.Length > 0)
			{
				Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<string>(ELauncherStorageDeviceKey.PatchP4Version, Singleton<RemoteInfo>.Instance.NewConfig.ChangeList);
			}
			if (Singleton<Platform>.Instance.IsMobilePlatform() && this.IsFirstTimeUpdateForPackage())
			{
				Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<EUpdateMode>(ELauncherStorageDeviceKey.MajorVerPatchMode, EUpdateMode.All);
			}
		}

		// Token: 0x0602EF3B RID: 192315 RVA: 0x00B1F9E0 File Offset: 0x00B1DBE0
		public UniTask<bool> Complete()
		{
			BaseDiffPatchProcedure.<Complete>d__21 <Complete>d__;
			<Complete>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Complete>d__.<>4__this = this;
			<Complete>d__.<>1__state = -1;
			<Complete>d__.<>t__builder.Start<BaseDiffPatchProcedure.<Complete>d__21>(ref <Complete>d__);
			return <Complete>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF3C RID: 192316 RVA: 0x00B1FA24 File Offset: 0x00B1DC24
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<RemoteVersionConfig> RequestRemoteConfig(List<string> prefixList, string remoteConfigUrl, Dictionary<string, RemoteVersionConfig> configMapRef)
		{
			BaseDiffPatchProcedure.<RequestRemoteConfig>d__22 <RequestRemoteConfig>d__;
			<RequestRemoteConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder<RemoteVersionConfig>.Create();
			<RequestRemoteConfig>d__.prefixList = prefixList;
			<RequestRemoteConfig>d__.remoteConfigUrl = remoteConfigUrl;
			<RequestRemoteConfig>d__.configMapRef = configMapRef;
			<RequestRemoteConfig>d__.<>1__state = -1;
			<RequestRemoteConfig>d__.<>t__builder.Start<BaseDiffPatchProcedure.<RequestRemoteConfig>d__22>(ref <RequestRemoteConfig>d__);
			return <RequestRemoteConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF3D RID: 192317 RVA: 0x00B1FA78 File Offset: 0x00B1DC78
		[NullableContext(1)]
		private ERemoteConfigResult SetRemoteConfigInfo(int lastUpdateTime, [Nullable(2)] RemoteVersionConfig newestConfig, Dictionary<string, RemoteVersionConfig> configMap, bool ignoreOutDateAndIllegal)
		{
			HotPatchLog hotPatchLog = new HotPatchLog();
			HotPatchLogResult hotPatchLogResult = new HotPatchLogResult
			{
				success = true
			};
			hotPatchLog.s_step_id = "end_download_remote_config";
			HotPatchLog hotPatchLog2 = new HotPatchLog();
			hotPatchLog2.s_step_id = "check_remote_config";
			RemoteVersionConfig remoteVersionConfig = newestConfig;
			long? num2;
			if (remoteVersionConfig != null)
			{
				long num = (long)lastUpdateTime;
				long? updateTime = remoteVersionConfig.UpdateTime;
				num2 = ((num > updateTime.GetValueOrDefault() & updateTime != null) ? new long?((long)lastUpdateTime) : remoteVersionConfig.UpdateTime);
			}
			else
			{
				num2 = new long?((long)lastUpdateTime);
			}
			long? num3 = num2;
			int num4 = 0;
			int num5 = 0;
			foreach (KeyValuePair<string, RemoteVersionConfig> keyValuePair in configMap)
			{
				string key = keyValuePair.Key;
				RemoteVersionConfig value = keyValuePair.Value;
				if (value.UpdateTime == null)
				{
					Singleton<LauncherLog>.Instance.Error("远程配置文件UpdateTime字段非法！", default(ReadOnlySpan<ValueTuple<string, object>>));
					hotPatchLog2.s_url_prefix = key;
					hotPatchLog2.s_step_result = "remote config field is illegal. field: UpdateTime";
					Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog2);
					num5++;
				}
				else
				{
					long? updateTime = value.UpdateTime;
					long? num6 = num3;
					if (updateTime.GetValueOrDefault() < num6.GetValueOrDefault() & (updateTime != null & num6 != null))
					{
						LauncherLog instance = Singleton<LauncherLog>.Instance;
						string message = "远程配置文件已过时！";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("prefix", key);
						instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						hotPatchLog2.s_url_prefix = key;
						hotPatchLog2.s_step_result = "out date";
						hotPatchLog2.i_latest_time = num3;
						hotPatchLog2.i_out_date_time = value.UpdateTime;
						Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog2);
						num4++;
					}
				}
			}
			if (remoteVersionConfig == null)
			{
				if (num4 <= 0 && num5 <= 0)
				{
					hotPatchLogResult.success = false;
					hotPatchLogResult.info = "failed, get all remote configs failed.";
					hotPatchLog.s_step_result = LauncherJson.Stringify<HotPatchLogResult>(hotPatchLogResult, null);
					Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog);
					return ERemoteConfigResult.None;
				}
				if (!ignoreOutDateAndIllegal)
				{
					if (num4 > num5)
					{
						hotPatchLogResult.success = false;
						hotPatchLogResult.info = "failed, the most of remote configs is out of date.";
						hotPatchLog.s_step_result = LauncherJson.Stringify<HotPatchLogResult>(hotPatchLogResult, null);
						Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog);
						return ERemoteConfigResult.OutDate;
					}
					hotPatchLogResult.success = false;
					hotPatchLogResult.info = "failed, the most of remote config field is illegal.";
					hotPatchLog.s_step_result = LauncherJson.Stringify<HotPatchLogResult>(hotPatchLogResult, null);
					Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog);
					return ERemoteConfigResult.FieldIllegal;
				}
				else
				{
					LauncherLog instance2 = Singleton<LauncherLog>.Instance;
					string message2 = "所有远程配置更新时间戳字段都不可用，强行设置一个远程配置";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("configCount", configMap.Count);
					instance2.Info(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					if (configMap.Count <= 0)
					{
						Singleton<LauncherLog>.Instance.Error("所有远程配置更新时间戳字段都不可用，并且没有获取到有效的配置个数。", default(ReadOnlySpan<ValueTuple<string, object>>));
						hotPatchLogResult.success = false;
						hotPatchLogResult.info = "failed, can not assign a valid remote config.";
						hotPatchLog.s_step_result = LauncherJson.Stringify<HotPatchLogResult>(hotPatchLogResult, null);
						Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog);
						return ERemoteConfigResult.None;
					}
					using (Dictionary<string, RemoteVersionConfig>.Enumerator enumerator = configMap.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							KeyValuePair<string, RemoteVersionConfig> keyValuePair2 = enumerator.Current;
							remoteVersionConfig = keyValuePair2.Value;
						}
					}
				}
			}
			hotPatchLogResult.success = true;
			hotPatchLogResult.info = "success";
			hotPatchLog.s_step_result = LauncherJson.Stringify<HotPatchLogResult>(hotPatchLogResult, null);
			Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog);
			Singleton<RemoteInfo>.Instance.NewConfig = remoteVersionConfig;
			if (!ignoreOutDateAndIllegal)
			{
				long? num6 = Singleton<RemoteInfo>.Instance.NewConfig.UpdateTime;
				long num7 = (long)lastUpdateTime;
				if (num6.GetValueOrDefault() > num7 & num6 != null)
				{
					Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<long?>(ELauncherStorageDeviceKey.RemoteVersionUpdate, Singleton<RemoteInfo>.Instance.NewConfig.UpdateTime);
				}
			}
			return ERemoteConfigResult.Success;
		}

		// Token: 0x0602EF3E RID: 192318 RVA: 0x00B1FE18 File Offset: 0x00B1E018
		private UniTask<ERemoteConfigResult> InternalGetRemoteVersionConfig(bool ignoreOutDateAndIllegal = false)
		{
			BaseDiffPatchProcedure.<InternalGetRemoteVersionConfig>d__24 <InternalGetRemoteVersionConfig>d__;
			<InternalGetRemoteVersionConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder<ERemoteConfigResult>.Create();
			<InternalGetRemoteVersionConfig>d__.<>4__this = this;
			<InternalGetRemoteVersionConfig>d__.ignoreOutDateAndIllegal = ignoreOutDateAndIllegal;
			<InternalGetRemoteVersionConfig>d__.<>1__state = -1;
			<InternalGetRemoteVersionConfig>d__.<>t__builder.Start<BaseDiffPatchProcedure.<InternalGetRemoteVersionConfig>d__24>(ref <InternalGetRemoteVersionConfig>d__);
			return <InternalGetRemoteVersionConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF3F RID: 192319 RVA: 0x00B1FE63 File Offset: 0x00B1E063
		[NullableContext(1)]
		protected virtual UniTask OnAfterResolveManifests(DiffUpdate _update)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0401AB7E RID: 109438
		private bool IsInitUrlPrefix;

		// Token: 0x0401AB7F RID: 109439
		[Nullable(2)]
		private string AppVersion;

		// Token: 0x0401AB81 RID: 109441
		[Nullable(2)]
		private readonly AppPathMisc PathMisc;

		// Token: 0x0401AB82 RID: 109442
		[Nullable(2)]
		protected readonly HotFixManager ViewMgr;
	}
}
