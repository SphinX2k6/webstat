using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.Download;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044CD RID: 17613
	[NullableContext(1)]
	[Nullable(0)]
	public class ResourceUpdate
	{
		// Token: 0x0602E780 RID: 190336 RVA: 0x00B0025C File Offset: 0x00AFE45C
		[NullableContext(2)]
		public ResourceUpdate(UObject worldContext = null, UrlPrefixDownload downloader = null, AppVersionMisc versionMisc = null, AppPathMisc pathMisc = null, bool updateIndexOnly = false)
		{
			this.WorldContext = worldContext;
			this.DownloadProxy = downloader;
			this.VersionMisc = versionMisc;
			this.PathMisc = pathMisc;
			this.UpdateIndexOnly = updateIndexOnly;
			this.ResType = this.VersionMisc.GetResType();
		}

		// Token: 0x0602E781 RID: 190337 RVA: 0x00B002B0 File Offset: 0x00AFE4B0
		public void ResetWorldContext(UObject worldContext)
		{
			this.WorldContext = worldContext;
		}

		// Token: 0x0602E782 RID: 190338 RVA: 0x00B002BC File Offset: 0x00AFE4BC
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public unsafe static ValueTuple<bool, List<PatchFileInfo>> ReadPatchInfoList(List<string> indexPaths, List<string> versions, AppVersionMisc versionMisc, AppPathMisc pathMisc)
		{
			List<PatchFileInfo> list = new List<PatchFileInfo>();
			if (indexPaths == null || versions == null || indexPaths.Count != versions.Count)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "index列表参数，或versions列表参数不匹配";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("indexPathsLength", (indexPaths != null) ? new int?(indexPaths.Count) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("versionsLength", (versions != null) ? new int?(versions.Count) : null);
				instance.Warn(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return new ValueTuple<bool, List<PatchFileInfo>>(false, list);
			}
			for (int i = 0; i < indexPaths.Count; i++)
			{
				string text = indexPaths[i];
				string text2 = versions[i];
				string inCipher = null;
				if (!UKuroStaticLibrary.LoadFileToString(ref inCipher, text))
				{
					LauncherLog instance2 = Singleton<LauncherLog>.Instance;
					string message2 = "index文件不存在";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("file", text);
					instance2.Warn(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return new ValueTuple<bool, List<PatchFileInfo>>(false, list);
				}
				string text3 = null;
				if (!UKuroLauncherLibrary.Decrypt(inCipher, ref text3))
				{
					LauncherLog instance3 = Singleton<LauncherLog>.Instance;
					string message3 = "index文件内容无法解析";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("file", text);
					instance3.Warn(message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return new ValueTuple<bool, List<PatchFileInfo>>(false, list);
				}
				string text4 = (text3 ?? "").Trim();
				if (!string.IsNullOrEmpty(text4))
				{
					JsonDocument jsonDocument;
					try
					{
						jsonDocument = JsonDocument.Parse(text4, default(JsonDocumentOptions));
					}
					catch
					{
						goto IL_42C;
					}
					using (jsonDocument)
					{
						JsonElement jsonElement;
						if (!jsonDocument.RootElement.TryGetProperty(text2, out jsonElement))
						{
							LauncherLog instance4 = Singleton<LauncherLog>.Instance;
							string message4 = "index文件内容取不到版本信息";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("file", text);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("version", text2);
							instance4.Warn(message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
							return new ValueTuple<bool, List<PatchFileInfo>>(false, list);
						}
						foreach (JsonElement jsonElement2 in jsonElement.EnumerateArray())
						{
							string text5 = jsonElement2.GetString() ?? "";
							if (!string.IsNullOrEmpty(text5))
							{
								string[] array = text5.Split(',', StringSplitOptions.None);
								if (array.Length >= 12)
								{
									PatchFileInfo patchFileInfo = new PatchFileInfo();
									patchFileInfo.Name = ((array[0].Length >= 4) ? array[0].Substring(0, array[0].Length - 4) : array[0]);
									patchFileInfo.NeedRestart = (array[1] == "1");
									patchFileInfo.MountType = int.Parse(array[2]);
									string packageVersion = versionMisc.GetPackageVersion();
									string resUri = Singleton<BaseConfigController>.Instance.GetResUri();
									PatchFileInfo patchFileInfo2 = patchFileInfo;
									DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
									defaultInterpolatedStringHandler.AppendFormatted(resUri);
									defaultInterpolatedStringHandler.AppendLiteral("/");
									defaultInterpolatedStringHandler.AppendFormatted(pathMisc.GetPlatform());
									defaultInterpolatedStringHandler.AppendLiteral("/");
									defaultInterpolatedStringHandler.AppendFormatted(patchFileInfo.Name);
									patchFileInfo2.FileUrl = defaultInterpolatedStringHandler.ToStringAndClear();
									PatchFileInfo patchFileInfo3 = patchFileInfo;
									defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 4);
									defaultInterpolatedStringHandler.AppendFormatted(pathMisc.GetPatchSaveDir());
									defaultInterpolatedStringHandler.AppendFormatted(packageVersion);
									defaultInterpolatedStringHandler.AppendLiteral("/");
									defaultInterpolatedStringHandler.AppendFormatted(versionMisc.GetResType());
									defaultInterpolatedStringHandler.AppendLiteral("/");
									defaultInterpolatedStringHandler.AppendFormatted(patchFileInfo.Name);
									patchFileInfo3.SavePath = defaultInterpolatedStringHandler.ToStringAndClear();
									patchFileInfo.PakSize = new long?(long.Parse(array[4]));
									patchFileInfo.PakSha1 = array[5];
									patchFileInfo.MountOrder = int.Parse(array[3]);
									patchFileInfo.UtocSize = new long?(long.Parse(array[6]));
									patchFileInfo.UtocSha1 = array[7];
									patchFileInfo.UcasSize = new long?(long.Parse(array[8]));
									patchFileInfo.UcasSha1 = array[9];
									patchFileInfo.SigSize = new long?(long.Parse(array[10]));
									patchFileInfo.SigSha1 = array[11];
									list.Add(patchFileInfo);
								}
							}
						}
					}
				}
				IL_42C:;
			}
			return new ValueTuple<bool, List<PatchFileInfo>>(true, list);
		}

		// Token: 0x0602E783 RID: 190339 RVA: 0x00B00760 File Offset: 0x00AFE960
		private Dictionary<string, PatchFileInfo> ReadMountFileInfo()
		{
			Dictionary<string, PatchFileInfo> dictionary = new Dictionary<string, PatchFileInfo>();
			string mountFilePath = this.VersionMisc.GetMountFilePath();
			if (!UBlueprintPathsLibrary.FileExists(mountFilePath))
			{
				return dictionary;
			}
			TArray<string> tarray = UKuroStaticLibrary.LoadFileToStringArray(mountFilePath);
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				string[] array = tarray.Get(i).Split(',', StringSplitOptions.None);
				if (array.Length >= 9)
				{
					PatchFileInfo patchFileInfo = new PatchFileInfo();
					patchFileInfo.Name = ((array[1] == this.VersionMisc.GetResType()) ? array[0] : (array[0] + "_" + array[1]));
					patchFileInfo.PakSha1 = array[4];
					patchFileInfo.SigSha1 = array[5];
					patchFileInfo.UtocSha1 = array[6];
					patchFileInfo.UcasSha1 = array[7];
					patchFileInfo.MountOrder = int.Parse(array[8]);
					dictionary[patchFileInfo.Name] = patchFileInfo;
				}
			}
			return dictionary;
		}

		// Token: 0x0602E784 RID: 190340 RVA: 0x00B00854 File Offset: 0x00AFEA54
		private void SaveMountFile()
		{
			string text = "";
			for (int i = 0; i < this.PakList.Count; i++)
			{
				PatchFileInfo patchFileInfo = this.PakList[i];
				string str = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 9);
				defaultInterpolatedStringHandler.AppendFormatted(patchFileInfo.Name);
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted(this.VersionMisc.GetResType());
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted(patchFileInfo.NeedRestart ? "1" : "0");
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted<int>(patchFileInfo.MountType);
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted(patchFileInfo.PakSha1);
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted(patchFileInfo.SigSha1);
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted(patchFileInfo.UtocSha1);
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted(patchFileInfo.UcasSha1);
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted<int>(patchFileInfo.MountOrder);
				defaultInterpolatedStringHandler.AppendLiteral("\n");
				text = str + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			UKuroStaticLibrary.SaveStringToFile(text, this.VersionMisc.GetMountFilePath(), false);
		}

		// Token: 0x0602E785 RID: 190341 RVA: 0x00B009B0 File Offset: 0x00AFEBB0
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private ValueTuple<long, string> GetPatchFileInfo(PatchFileInfo info, EResFile fileType)
		{
			switch (fileType)
			{
			case EResFile.PAK:
				return new ValueTuple<long, string>(info.PakSize.GetValueOrDefault(), info.PakSha1);
			case EResFile.SIG:
				return new ValueTuple<long, string>(info.SigSize.GetValueOrDefault(), info.SigSha1);
			case EResFile.UTOC:
				return new ValueTuple<long, string>(info.UtocSize.GetValueOrDefault(), info.UtocSha1);
			case EResFile.UCAS:
				return new ValueTuple<long, string>(info.UcasSize.GetValueOrDefault(), info.UcasSha1);
			default:
				return new ValueTuple<long, string>(0L, "");
			}
		}

		// Token: 0x0602E786 RID: 190342 RVA: 0x00B00A40 File Offset: 0x00AFEC40
		private long CheckFileNeedUpdate(PatchFileInfo info, List<RequestFileInfo> requestList, Dictionary<string, DownloadViewInfo> viewInfoList, EResFile fileType)
		{
			ValueTuple<long, string> patchFileInfo = this.GetPatchFileInfo(info, fileType);
			long item = patchFileInfo.Item1;
			string item2 = patchFileInfo.Item2;
			if (item <= 0L)
			{
				return 0L;
			}
			long num = 0L;
			string str = fileType.ToEnumString();
			string text = info.SavePath + str;
			string text2 = info.SavePath + str + ".download";
			HotPatchLog hotPatchLog = new HotPatchLog();
			hotPatchLog.s_step_id = "HotPatchCheckResHash";
			HotPatchCheckResHashLogInfo hotPatchCheckResHashLogInfo = new HotPatchCheckResHashLogInfo
			{
				FileName = text
			};
			HotPatchLogResult value = new HotPatchLogResult
			{
				success = false,
				info = hotPatchCheckResHashLogInfo
			};
			bool flag = true;
			bool flag2 = true;
			if (UKuroLauncherLibrary.GetFileSize(text) == item)
			{
				if (flag || UKuroLauncherLibrary.CheckFileSha1(text, item2))
				{
					flag2 = false;
				}
				else
				{
					hotPatchCheckResHashLogInfo.Infos.Add("file size equal and sha1 different.");
				}
			}
			long num2 = UKuroLauncherLibrary.GetFileSize(text2);
			if (flag2)
			{
				if (UBlueprintPathsLibrary.FileExists(text))
				{
					UKuroLauncherLibrary.DeleteFile(text);
				}
				if (num2 > item)
				{
					UKuroLauncherLibrary.DeleteFile(text2);
					num2 = 0L;
				}
				else if (num2 == item)
				{
					if (UKuroLauncherLibrary.CheckFileSha1(text2, item2))
					{
						if (UKuroLauncherLibrary.MoveFile(text, text2))
						{
							flag2 = false;
						}
					}
					else
					{
						UKuroLauncherLibrary.DeleteFile(text2);
						num2 = 0L;
					}
				}
			}
			if (flag2)
			{
				num2 = ((num2 >= 0L) ? num2 : 0L);
				this.NeedSpace += item - num2;
				RequestFileInfo requestFileInfo = new RequestFileInfo();
				requestFileInfo.FileName = info.Name + str;
				requestFileInfo.Url = info.FileUrl + str;
				requestFileInfo.SavePath = text;
				requestFileInfo.HashString = item2;
				requestFileInfo.Size = new long?(item);
				requestFileInfo.bUseDownloadCache = true;
				num += item;
				requestList.Add(requestFileInfo);
				DownloadViewInfo downloadViewInfo = new DownloadViewInfo();
				downloadViewInfo.Name = requestFileInfo.FileName;
				downloadViewInfo.Size = requestFileInfo.Size;
				downloadViewInfo.SavedSize = new long?(0L);
				viewInfoList[downloadViewInfo.Name] = downloadViewInfo;
			}
			if (hotPatchCheckResHashLogInfo.Infos.Count > 0)
			{
				hotPatchLog.s_step_result = LauncherJson.Stringify<HotPatchLogResult>(value, null);
				Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog);
			}
			return num;
		}

		// Token: 0x0602E787 RID: 190343 RVA: 0x00B00C54 File Offset: 0x00AFEE54
		private long CheckFilesNeedUpdate(PatchFileInfo info, List<RequestFileInfo> requestList, Dictionary<string, DownloadViewInfo> viewInfoList)
		{
			long num = 0L;
			num += this.CheckFileNeedUpdate(info, requestList, viewInfoList, EResFile.PAK);
			num += this.CheckFileNeedUpdate(info, requestList, viewInfoList, EResFile.UTOC);
			num += this.CheckFileNeedUpdate(info, requestList, viewInfoList, EResFile.UCAS);
			num += this.CheckFileNeedUpdate(info, requestList, viewInfoList, EResFile.SIG);
			if (!this.ShouldRestart && num > 0L)
			{
				this.ShouldRestart = info.NeedRestart;
			}
			return num;
		}

		// Token: 0x0602E788 RID: 190344 RVA: 0x00B00CB4 File Offset: 0x00AFEEB4
		public unsafe bool CheckResourceVersion()
		{
			bool flag = this.VersionMisc.HasNewResourceVersionBaseOnPackage();
			bool flag2 = this.VersionMisc.IsBasePackageSplited();
			HotPatchLog hotPatchLog = new HotPatchLog();
			hotPatchLog.s_step_id = "check_resource_version";
			hotPatchLog.s_update_type = this.ResType;
			if (!flag && !flag2)
			{
				if (!this.VersionMisc.HasUpdated())
				{
					this.VersionMisc.UpdateVersion(this.WorldContext, false);
				}
				if (this.VersionMisc.IsFirstUpdateResources())
				{
					this.VersionMisc.UpdateSavedVersion(this.WorldContext, false);
				}
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "原始包版本，直接可进入游戏";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", this.ResType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PackageVersion", this.VersionMisc.GetPackageVersion());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("LatestVersion", this.VersionMisc.GetLatestVersion());
				instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				Dictionary<string, object> value = new Dictionary<string, object>
				{
					{
						"PackageVersion",
						this.VersionMisc.GetPackageVersion()
					},
					{
						"LatestVersion",
						this.VersionMisc.GetLatestVersion()
					},
					{
						"NeedUpdate",
						false
					},
					{
						"BasePackageSplited",
						flag2
					}
				};
				hotPatchLog.s_step_result = LauncherJson.Stringify<Dictionary<string, object>>(value, null);
				Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog);
			}
			Dictionary<string, object> value2 = new Dictionary<string, object>
			{
				{
					"PackageVersion",
					this.VersionMisc.GetPackageVersion()
				},
				{
					"LatestVersion",
					this.VersionMisc.GetLatestVersion()
				},
				{
					"NeedUpdate",
					true
				},
				{
					"BasePackageSplited",
					flag2
				}
			};
			hotPatchLog.s_step_result = LauncherJson.Stringify<Dictionary<string, object>>(value2, null);
			Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog);
			return flag || flag2;
		}

		// Token: 0x0602E789 RID: 190345 RVA: 0x00B00E9C File Offset: 0x00AFF09C
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<IDownloadResult> DownloadIndexFile()
		{
			ResourceUpdate.<DownloadIndexFile>d__24 <DownloadIndexFile>d__;
			<DownloadIndexFile>d__.<>t__builder = AsyncUniTaskMethodBuilder<IDownloadResult>.Create();
			<DownloadIndexFile>d__.<>4__this = this;
			<DownloadIndexFile>d__.<>1__state = -1;
			<DownloadIndexFile>d__.<>t__builder.Start<ResourceUpdate.<DownloadIndexFile>d__24>(ref <DownloadIndexFile>d__);
			return <DownloadIndexFile>d__.<>t__builder.Task;
		}

		// Token: 0x0602E78A RID: 190346 RVA: 0x00B00EE0 File Offset: 0x00AFF0E0
		public bool ResolveIndexFile()
		{
			if (this.UpdateIndexOnly)
			{
				return true;
			}
			List<string> indexSavePaths = this.VersionMisc.GetIndexSavePaths(this.PathMisc);
			List<string> updatePreVersions = this.VersionMisc.GetUpdatePreVersions();
			ValueTuple<bool, List<PatchFileInfo>> valueTuple = ResourceUpdate.ReadPatchInfoList(indexSavePaths, updatePreVersions, this.VersionMisc, this.PathMisc);
			bool item = valueTuple.Item1;
			this.PakList = valueTuple.Item2;
			HotPatchLog hotPatchLog = new HotPatchLog();
			hotPatchLog.s_step_id = "resolve_index";
			hotPatchLog.s_update_type = this.ResType;
			hotPatchLog.s_step_result = (item ? "success" : "failed");
			Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog);
			return item;
		}

		// Token: 0x0602E78B RID: 190347 RVA: 0x00B00F7C File Offset: 0x00AFF17C
		[NullableContext(0)]
		public UniTask<bool> CheckResourceFiles([Nullable(2)] Func<float, UniTask> progressCb = null)
		{
			ResourceUpdate.<CheckResourceFiles>d__26 <CheckResourceFiles>d__;
			<CheckResourceFiles>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CheckResourceFiles>d__.<>4__this = this;
			<CheckResourceFiles>d__.progressCb = progressCb;
			<CheckResourceFiles>d__.<>1__state = -1;
			<CheckResourceFiles>d__.<>t__builder.Start<ResourceUpdate.<CheckResourceFiles>d__26>(ref <CheckResourceFiles>d__);
			return <CheckResourceFiles>d__.<>t__builder.Task;
		}

		// Token: 0x0602E78C RID: 190348 RVA: 0x00B00FC8 File Offset: 0x00AFF1C8
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<IDownloadResult> DownloadResourceFiles([Nullable(new byte[]
		{
			2,
			1
		})] Action<string, long, long, long> progressCb = null, Action<long, long, long, long> viewCb = null)
		{
			ResourceUpdate.<DownloadResourceFiles>d__27 <DownloadResourceFiles>d__;
			<DownloadResourceFiles>d__.<>t__builder = AsyncUniTaskMethodBuilder<IDownloadResult>.Create();
			<DownloadResourceFiles>d__.<>4__this = this;
			<DownloadResourceFiles>d__.progressCb = progressCb;
			<DownloadResourceFiles>d__.viewCb = viewCb;
			<DownloadResourceFiles>d__.<>1__state = -1;
			<DownloadResourceFiles>d__.<>t__builder.Start<ResourceUpdate.<DownloadResourceFiles>d__27>(ref <DownloadResourceFiles>d__);
			return <DownloadResourceFiles>d__.<>t__builder.Task;
		}

		// Token: 0x0602E78D RID: 190349 RVA: 0x00B0101C File Offset: 0x00AFF21C
		public unsafe bool CheckNeedRestartApp()
		{
			this.NeedReMount = (this.RequestList.Count > 0);
			this.RestartType = new ERestartType?(ERestartType.None);
			if (this.VersionMisc.IsFirstUpdateResources())
			{
				this.VersionMisc.UpdateSavedVersion(this.WorldContext, false);
				this.RestartType = new ERestartType?(ERestartType.HotFixComplete);
			}
			else
			{
				this.RestartType = new ERestartType?(ERestartType.RepairComplete);
			}
			Singleton<LauncherLog>.Instance.Info("检测是否需要重启", default(ReadOnlySpan<ValueTuple<string, object>>));
			bool flag = UKuroLauncherLibrary.NeedRestartApp() > 0 || this.ShouldRestart || !UKuroLauncherLibrary.IsFirstIntoLauncher();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "开始检测下载的pak是否需要重启";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LastSetNeedRestart", UKuroLauncherLibrary.NeedRestartApp());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("bNeedRestart", this.ShouldRestart);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("firstIntoLauncher", UKuroLauncherLibrary.IsFirstIntoLauncher());
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (flag)
			{
				Singleton<LauncherLog>.Instance.Info("检测到下载的资源需要重启！", default(ReadOnlySpan<ValueTuple<string, object>>));
				UKuroLauncherLibrary.SetRestartApp((byte)this.RestartType.Value);
			}
			Singleton<LauncherLog>.Instance.Info("完成检测是否需要重启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}

		// Token: 0x0602E78E RID: 190350 RVA: 0x00B0117C File Offset: 0x00AFF37C
		public IRevertVersionInfo GetRevertInfo()
		{
			bool flag = this.VersionMisc.NeedRevert();
			HashSet<string> revertVersions = this.VersionMisc.GetRevertVersions();
			HashSet<string> hashSet = new HashSet<string>();
			HashSet<string> hashSet2 = new HashSet<string>();
			IRevertVersionInfo result = new RevertVersionInfo
			{
				NeedRevert = flag,
				Paks = hashSet,
				Files = hashSet2
			};
			if (!flag)
			{
				return result;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted(this.PathMisc.GetPatchSaveDir());
			defaultInterpolatedStringHandler.AppendFormatted(this.VersionMisc.GetPackageVersion());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(this.VersionMisc.GetResType());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			string text = defaultInterpolatedStringHandler.ToStringAndClear();
			TArray<string> files = UKuroStaticLibrary.GetFiles(text, "*");
			int num = files.Num();
			for (int i = 0; i < num; i++)
			{
				string text2 = files.Get(i);
				string text3 = text2.ToLowerInvariant();
				string text4 = text3.EndsWith(".download") ? text3.Substring(0, text3.LastIndexOf('.')) : text3;
				if (text4.EndsWith(".txt"))
				{
					int num2 = text4.LastIndexOf('.');
					int num3 = text4.LastIndexOf('_');
					string item = text4.Substring(num3 + 1, num2 - num3 - 1);
					if (revertVersions.Contains(item))
					{
						hashSet2.Add(text + text2);
					}
				}
				else if (text4.EndsWith(EResFile.PAK.ToEnumString()) || text4.EndsWith(EResFile.SIG.ToEnumString()) || text4.EndsWith(EResFile.UTOC.ToEnumString()) || text4.EndsWith(EResFile.UCAS.ToEnumString()))
				{
					int num4 = text4.LastIndexOf('-');
					int num5 = text4.LastIndexOf('-', num4 - 1);
					string item2 = text4.Substring(num5 + 1, num4 - num5 - 1);
					if (revertVersions.Contains(item2))
					{
						string item3 = text + text2;
						hashSet2.Add(item3);
						if (text4.EndsWith(EResFile.PAK.ToEnumString()))
						{
							hashSet.Add(item3);
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0602E78F RID: 190351 RVA: 0x00B01392 File Offset: 0x00AFF592
		public long GetUpdateSize()
		{
			return this.UpdateSize;
		}

		// Token: 0x0602E790 RID: 190352 RVA: 0x00B0139A File Offset: 0x00AFF59A
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<PatchFileInfo> GetPakList()
		{
			return this.PakList;
		}

		// Token: 0x0602E791 RID: 190353 RVA: 0x00B013A2 File Offset: 0x00AFF5A2
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, DownloadViewInfo> GetViewInfoList()
		{
			return this.ViewInfoList;
		}

		// Token: 0x0602E792 RID: 190354 RVA: 0x00B013AA File Offset: 0x00AFF5AA
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<RequestFileInfo> GetRequestList()
		{
			return this.RequestList;
		}

		// Token: 0x0602E793 RID: 190355 RVA: 0x00B013B2 File Offset: 0x00AFF5B2
		public bool GetNeedRemount()
		{
			return this.NeedReMount;
		}

		// Token: 0x0602E794 RID: 190356 RVA: 0x00B013BA File Offset: 0x00AFF5BA
		public bool GetNeedRestart()
		{
			return UKuroLauncherLibrary.NeedRestartApp() > 0;
		}

		// Token: 0x0602E795 RID: 190357 RVA: 0x00B013C4 File Offset: 0x00AFF5C4
		public string GetResType()
		{
			return this.ResType;
		}

		// Token: 0x0602E796 RID: 190358 RVA: 0x00B013CC File Offset: 0x00AFF5CC
		public long GetNeedSpace()
		{
			return this.NeedSpace;
		}

		// Token: 0x0401A65F RID: 108127
		private const float HUNDRED_PERCENT = 1f;

		// Token: 0x0401A660 RID: 108128
		private readonly UrlPrefixDownload DownloadProxy;

		// Token: 0x0401A661 RID: 108129
		private readonly string ResType = "";

		// Token: 0x0401A662 RID: 108130
		private readonly AppVersionMisc VersionMisc;

		// Token: 0x0401A663 RID: 108131
		private readonly AppPathMisc PathMisc;

		// Token: 0x0401A664 RID: 108132
		private bool ShouldRestart;

		// Token: 0x0401A665 RID: 108133
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<PatchFileInfo> PakList;

		// Token: 0x0401A666 RID: 108134
		private UObject WorldContext;

		// Token: 0x0401A667 RID: 108135
		private bool NeedReMount;

		// Token: 0x0401A668 RID: 108136
		private ERestartType? RestartType;

		// Token: 0x0401A669 RID: 108137
		private readonly bool UpdateIndexOnly;

		// Token: 0x0401A66A RID: 108138
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<RequestFileInfo> RequestList;

		// Token: 0x0401A66B RID: 108139
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<string, DownloadViewInfo> ViewInfoList;

		// Token: 0x0401A66C RID: 108140
		private long UpdateSize;

		// Token: 0x0401A66D RID: 108141
		private long NeedSpace;
	}
}
