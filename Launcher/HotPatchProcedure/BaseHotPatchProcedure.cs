using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.HotPatchProcedure
{
	// Token: 0x020045FD RID: 17917
	public abstract class BaseHotPatchProcedure : IHotPatchProcedure
	{
		// Token: 0x0602EDF5 RID: 191989 RVA: 0x00B1971B File Offset: 0x00B1791B
		[NullableContext(1)]
		public BaseHotPatchProcedure(AppPathMisc pathMisc, HotFixManager viewMgr)
		{
			this.PathMisc = pathMisc;
			this.ViewMgr = viewMgr;
		}

		// Token: 0x0602EDF6 RID: 191990 RVA: 0x00B19734 File Offset: 0x00B17934
		public virtual UniTask<bool> Start()
		{
			BaseHotPatchProcedure.<Start>d__5 <Start>d__;
			<Start>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Start>d__.<>4__this = this;
			<Start>d__.<>1__state = -1;
			<Start>d__.<>t__builder.Start<BaseHotPatchProcedure.<Start>d__5>(ref <Start>d__);
			return <Start>d__.<>t__builder.Task;
		}

		// Token: 0x0602EDF7 RID: 191991 RVA: 0x00B19778 File Offset: 0x00B17978
		public UniTask<bool> GetRemoteVersionConfig()
		{
			BaseHotPatchProcedure.<GetRemoteVersionConfig>d__6 <GetRemoteVersionConfig>d__;
			<GetRemoteVersionConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<GetRemoteVersionConfig>d__.<>4__this = this;
			<GetRemoteVersionConfig>d__.<>1__state = -1;
			<GetRemoteVersionConfig>d__.<>t__builder.Start<BaseHotPatchProcedure.<GetRemoteVersionConfig>d__6>(ref <GetRemoteVersionConfig>d__);
			return <GetRemoteVersionConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0602EDF8 RID: 191992 RVA: 0x00B197BC File Offset: 0x00B179BC
		public UniTask<bool> IsAppVersionChange()
		{
			BaseHotPatchProcedure.<IsAppVersionChange>d__7 <IsAppVersionChange>d__;
			<IsAppVersionChange>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<IsAppVersionChange>d__.<>4__this = this;
			<IsAppVersionChange>d__.<>1__state = -1;
			<IsAppVersionChange>d__.<>t__builder.Start<BaseHotPatchProcedure.<IsAppVersionChange>d__7>(ref <IsAppVersionChange>d__);
			return <IsAppVersionChange>d__.<>t__builder.Task;
		}

		// Token: 0x0602EDF9 RID: 191993 RVA: 0x00B19800 File Offset: 0x00B17A00
		public virtual UniTask<bool> UpdateResource(bool bUseBgDownload, [Nullable(1)] params ResourceUpdate[] updates)
		{
			BaseHotPatchProcedure.<UpdateResource>d__8 <UpdateResource>d__;
			<UpdateResource>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UpdateResource>d__.<>4__this = this;
			<UpdateResource>d__.bUseBgDownload = bUseBgDownload;
			<UpdateResource>d__.updates = updates;
			<UpdateResource>d__.<>1__state = -1;
			<UpdateResource>d__.<>t__builder.Start<BaseHotPatchProcedure.<UpdateResource>d__8>(ref <UpdateResource>d__);
			return <UpdateResource>d__.<>t__builder.Task;
		}

		// Token: 0x0602EDFA RID: 191994 RVA: 0x00B19854 File Offset: 0x00B17A54
		protected virtual UniTask<bool> CheckResourceVersion([Nullable(1)] ResourceUpdate update)
		{
			BaseHotPatchProcedure.<CheckResourceVersion>d__9 <CheckResourceVersion>d__;
			<CheckResourceVersion>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CheckResourceVersion>d__.<>4__this = this;
			<CheckResourceVersion>d__.update = update;
			<CheckResourceVersion>d__.<>1__state = -1;
			<CheckResourceVersion>d__.<>t__builder.Start<BaseHotPatchProcedure.<CheckResourceVersion>d__9>(ref <CheckResourceVersion>d__);
			return <CheckResourceVersion>d__.<>t__builder.Task;
		}

		// Token: 0x0602EDFB RID: 191995 RVA: 0x00B198A0 File Offset: 0x00B17AA0
		protected UniTask<bool> DownloadIndexFile([Nullable(1)] ResourceUpdate update)
		{
			BaseHotPatchProcedure.<DownloadIndexFile>d__10 <DownloadIndexFile>d__;
			<DownloadIndexFile>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DownloadIndexFile>d__.<>4__this = this;
			<DownloadIndexFile>d__.update = update;
			<DownloadIndexFile>d__.<>1__state = -1;
			<DownloadIndexFile>d__.<>t__builder.Start<BaseHotPatchProcedure.<DownloadIndexFile>d__10>(ref <DownloadIndexFile>d__);
			return <DownloadIndexFile>d__.<>t__builder.Task;
		}

		// Token: 0x0602EDFC RID: 191996 RVA: 0x00B198EC File Offset: 0x00B17AEC
		protected UniTask<bool> ResolveIndexFile([Nullable(1)] ResourceUpdate update)
		{
			BaseHotPatchProcedure.<ResolveIndexFile>d__11 <ResolveIndexFile>d__;
			<ResolveIndexFile>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ResolveIndexFile>d__.<>4__this = this;
			<ResolveIndexFile>d__.update = update;
			<ResolveIndexFile>d__.<>1__state = -1;
			<ResolveIndexFile>d__.<>t__builder.Start<BaseHotPatchProcedure.<ResolveIndexFile>d__11>(ref <ResolveIndexFile>d__);
			return <ResolveIndexFile>d__.<>t__builder.Task;
		}

		// Token: 0x0602EDFD RID: 191997 RVA: 0x00B19938 File Offset: 0x00B17B38
		protected UniTask<bool> CheckResourceFiles([Nullable(1)] ResourceUpdate update)
		{
			BaseHotPatchProcedure.<CheckResourceFiles>d__12 <CheckResourceFiles>d__;
			<CheckResourceFiles>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CheckResourceFiles>d__.<>4__this = this;
			<CheckResourceFiles>d__.update = update;
			<CheckResourceFiles>d__.<>1__state = -1;
			<CheckResourceFiles>d__.<>t__builder.Start<BaseHotPatchProcedure.<CheckResourceFiles>d__12>(ref <CheckResourceFiles>d__);
			return <CheckResourceFiles>d__.<>t__builder.Task;
		}

		// Token: 0x0602EDFE RID: 191998 RVA: 0x00B19984 File Offset: 0x00B17B84
		protected UniTask<bool> DoesSavedDirHaveEnoughSpace(long needSize)
		{
			BaseHotPatchProcedure.<DoesSavedDirHaveEnoughSpace>d__13 <DoesSavedDirHaveEnoughSpace>d__;
			<DoesSavedDirHaveEnoughSpace>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DoesSavedDirHaveEnoughSpace>d__.<>4__this = this;
			<DoesSavedDirHaveEnoughSpace>d__.needSize = needSize;
			<DoesSavedDirHaveEnoughSpace>d__.<>1__state = -1;
			<DoesSavedDirHaveEnoughSpace>d__.<>t__builder.Start<BaseHotPatchProcedure.<DoesSavedDirHaveEnoughSpace>d__13>(ref <DoesSavedDirHaveEnoughSpace>d__);
			return <DoesSavedDirHaveEnoughSpace>d__.<>t__builder.Task;
		}

		// Token: 0x0602EDFF RID: 191999 RVA: 0x00B199D0 File Offset: 0x00B17BD0
		protected virtual UniTask<bool> DownloadFiles(bool bUseBgDownload, [Nullable(1)] params ResourceUpdate[] updates)
		{
			BaseHotPatchProcedure.<DownloadFiles>d__14 <DownloadFiles>d__;
			<DownloadFiles>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DownloadFiles>d__.<>4__this = this;
			<DownloadFiles>d__.updates = updates;
			<DownloadFiles>d__.<>1__state = -1;
			<DownloadFiles>d__.<>t__builder.Start<BaseHotPatchProcedure.<DownloadFiles>d__14>(ref <DownloadFiles>d__);
			return <DownloadFiles>d__.<>t__builder.Task;
		}

		// Token: 0x0602EE00 RID: 192000 RVA: 0x00B19A1C File Offset: 0x00B17C1C
		protected UniTask<bool> CheckNeedRestartApp([Nullable(1)] ResourceUpdate update)
		{
			BaseHotPatchProcedure.<CheckNeedRestartApp>d__15 <CheckNeedRestartApp>d__;
			<CheckNeedRestartApp>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CheckNeedRestartApp>d__.<>4__this = this;
			<CheckNeedRestartApp>d__.update = update;
			<CheckNeedRestartApp>d__.<>1__state = -1;
			<CheckNeedRestartApp>d__.<>t__builder.Start<BaseHotPatchProcedure.<CheckNeedRestartApp>d__15>(ref <CheckNeedRestartApp>d__);
			return <CheckNeedRestartApp>d__.<>t__builder.Task;
		}

		// Token: 0x0602EE01 RID: 192001 RVA: 0x00B19A68 File Offset: 0x00B17C68
		[NullableContext(1)]
		public bool NeedRestart(params ResourceUpdate[] updates)
		{
			for (int i = 0; i < updates.Length; i++)
			{
				if (updates[i].GetNeedRestart())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0602EE02 RID: 192002 RVA: 0x00B19A94 File Offset: 0x00B17C94
		public UniTask<bool> MountPak([Nullable(1)] params ResourceUpdate[] updates)
		{
			BaseHotPatchProcedure.<MountPak>d__17 <MountPak>d__;
			<MountPak>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<MountPak>d__.<>4__this = this;
			<MountPak>d__.updates = updates;
			<MountPak>d__.<>1__state = -1;
			<MountPak>d__.<>t__builder.Start<BaseHotPatchProcedure.<MountPak>d__17>(ref <MountPak>d__);
			return <MountPak>d__.<>t__builder.Task;
		}

		// Token: 0x0602EE03 RID: 192003 RVA: 0x00B19AE0 File Offset: 0x00B17CE0
		public virtual void PreComplete()
		{
			RemoteConfig config = Singleton<RemoteInfo>.Instance.Config;
			if (((config != null) ? config.LauncherVersion : null) != null)
			{
				Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<string>(ELauncherStorageDeviceKey.LauncherPatchVersion, Singleton<RemoteInfo>.Instance.Config.LauncherVersion);
			}
			RemoteConfig config2 = Singleton<RemoteInfo>.Instance.Config;
			if (((config2 != null) ? config2.ResourceVersion : null) != null)
			{
				Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<string>(ELauncherStorageDeviceKey.PatchVersion, Singleton<RemoteInfo>.Instance.Config.ResourceVersion);
			}
			RemoteConfig config3 = Singleton<RemoteInfo>.Instance.Config;
			if (((config3 != null) ? config3.ChangeList : null) != null && Singleton<RemoteInfo>.Instance.Config.ChangeList.Length > 0)
			{
				Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<string>(ELauncherStorageDeviceKey.PatchP4Version, Singleton<RemoteInfo>.Instance.Config.ChangeList);
			}
		}

		// Token: 0x0602EE04 RID: 192004 RVA: 0x00B19BA0 File Offset: 0x00B17DA0
		public virtual UniTask<bool> Complete()
		{
			BaseHotPatchProcedure.<Complete>d__19 <Complete>d__;
			<Complete>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Complete>d__.<>4__this = this;
			<Complete>d__.<>1__state = -1;
			<Complete>d__.<>t__builder.Start<BaseHotPatchProcedure.<Complete>d__19>(ref <Complete>d__);
			return <Complete>d__.<>t__builder.Task;
		}

		// Token: 0x0602EE05 RID: 192005 RVA: 0x00B19BE4 File Offset: 0x00B17DE4
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<RemoteConfig> RequestRemoteConfig(List<string> prefixList, string remoteConfigUrl, Dictionary<string, RemoteConfig> configMapRef)
		{
			BaseHotPatchProcedure.<RequestRemoteConfig>d__20 <RequestRemoteConfig>d__;
			<RequestRemoteConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder<RemoteConfig>.Create();
			<RequestRemoteConfig>d__.prefixList = prefixList;
			<RequestRemoteConfig>d__.remoteConfigUrl = remoteConfigUrl;
			<RequestRemoteConfig>d__.configMapRef = configMapRef;
			<RequestRemoteConfig>d__.<>1__state = -1;
			<RequestRemoteConfig>d__.<>t__builder.Start<BaseHotPatchProcedure.<RequestRemoteConfig>d__20>(ref <RequestRemoteConfig>d__);
			return <RequestRemoteConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0602EE06 RID: 192006 RVA: 0x00B19C38 File Offset: 0x00B17E38
		[NullableContext(1)]
		private ERemoteConfigResult SetRemoteConfigInfo(long lastUpdateTime, [Nullable(2)] RemoteConfig newestConfig, Dictionary<string, RemoteConfig> configMap, bool ignoreOutDateAndIllegal)
		{
			HotPatchLog hotPatchLog = new HotPatchLog();
			HotPatchLogResult hotPatchLogResult = new HotPatchLogResult
			{
				success = true
			};
			hotPatchLog.s_step_id = "end_download_remote_config";
			HotPatchLog hotPatchLog2 = new HotPatchLog();
			hotPatchLog2.s_step_id = "check_remote_config";
			RemoteConfig remoteConfig = newestConfig;
			long? num;
			if (remoteConfig != null)
			{
				long? updateTime = remoteConfig.UpdateTime;
				num = ((lastUpdateTime > updateTime.GetValueOrDefault() & updateTime != null) ? new long?(lastUpdateTime) : remoteConfig.UpdateTime);
			}
			else
			{
				num = new long?(lastUpdateTime);
			}
			long? num2 = num;
			int num3 = 0;
			int num4 = 0;
			foreach (KeyValuePair<string, RemoteConfig> keyValuePair in configMap)
			{
				string key = keyValuePair.Key;
				RemoteConfig value = keyValuePair.Value;
				if (value.UpdateTime == null)
				{
					Singleton<LauncherLog>.Instance.Error("远程配置文件UpdateTime字段非法！", default(ReadOnlySpan<ValueTuple<string, object>>));
					hotPatchLog2.s_url_prefix = key;
					hotPatchLog2.s_step_result = "remote config field is illegal. field: UpdateTime";
					Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog2);
					num4++;
				}
				else
				{
					long? updateTime = value.UpdateTime;
					long? num5 = num2;
					if (updateTime.GetValueOrDefault() < num5.GetValueOrDefault() & (updateTime != null & num5 != null))
					{
						LauncherLog instance = Singleton<LauncherLog>.Instance;
						string message = "远程配置文件已过时！";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("prefix", key);
						instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						hotPatchLog2.s_url_prefix = key;
						hotPatchLog2.s_step_result = "out date";
						hotPatchLog2.i_latest_time = num2;
						hotPatchLog2.i_out_date_time = value.UpdateTime;
						Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog2);
						num3++;
					}
				}
			}
			if (remoteConfig == null)
			{
				if (num3 <= 0 && num4 <= 0)
				{
					hotPatchLogResult.success = false;
					hotPatchLogResult.info = "failed, get all remote configs failed.";
					hotPatchLog.s_step_result = LauncherJson.Stringify<HotPatchLogResult>(hotPatchLogResult, null);
					Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog);
					return ERemoteConfigResult.None;
				}
				if (!ignoreOutDateAndIllegal)
				{
					if (num3 > num4)
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
					using (Dictionary<string, RemoteConfig>.Enumerator enumerator = configMap.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							KeyValuePair<string, RemoteConfig> keyValuePair2 = enumerator.Current;
							remoteConfig = keyValuePair2.Value;
						}
					}
				}
			}
			hotPatchLogResult.success = true;
			hotPatchLogResult.info = "success";
			hotPatchLog.s_step_result = LauncherJson.Stringify<HotPatchLogResult>(hotPatchLogResult, null);
			Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog);
			Singleton<RemoteInfo>.Instance.Config = remoteConfig;
			if (!ignoreOutDateAndIllegal)
			{
				long? num5 = Singleton<RemoteInfo>.Instance.Config.UpdateTime;
				if (num5.GetValueOrDefault() > lastUpdateTime & num5 != null)
				{
					Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<long?>(ELauncherStorageDeviceKey.RemoteVersionUpdate, Singleton<RemoteInfo>.Instance.Config.UpdateTime);
				}
			}
			return ERemoteConfigResult.Success;
		}

		// Token: 0x0602EE07 RID: 192007 RVA: 0x00B19FD4 File Offset: 0x00B181D4
		private UniTask<ERemoteConfigResult> InternalGetRemoteVersionConfig(bool ignoreOutDateAndIllegal = false)
		{
			BaseHotPatchProcedure.<InternalGetRemoteVersionConfig>d__22 <InternalGetRemoteVersionConfig>d__;
			<InternalGetRemoteVersionConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder<ERemoteConfigResult>.Create();
			<InternalGetRemoteVersionConfig>d__.<>4__this = this;
			<InternalGetRemoteVersionConfig>d__.ignoreOutDateAndIllegal = ignoreOutDateAndIllegal;
			<InternalGetRemoteVersionConfig>d__.<>1__state = -1;
			<InternalGetRemoteVersionConfig>d__.<>t__builder.Start<BaseHotPatchProcedure.<InternalGetRemoteVersionConfig>d__22>(ref <InternalGetRemoteVersionConfig>d__);
			return <InternalGetRemoteVersionConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0401AABB RID: 109243
		private bool IsInitUrlPrefix;

		// Token: 0x0401AABC RID: 109244
		[Nullable(2)]
		private string AppVersion;

		// Token: 0x0401AABD RID: 109245
		[Nullable(2)]
		private readonly AppPathMisc PathMisc;

		// Token: 0x0401AABE RID: 109246
		[Nullable(2)]
		protected readonly HotFixManager ViewMgr;
	}
}
