using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.DiffPatch.Data;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.DiffPatch.Update
{
	// Token: 0x02004633 RID: 17971
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class VideoResUpdate : Singleton<VideoResUpdate>
	{
		// Token: 0x1700809E RID: 32926
		// (get) Token: 0x0602EEEE RID: 192238 RVA: 0x00B1E2B6 File Offset: 0x00B1C4B6
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

		// Token: 0x1700809F RID: 32927
		// (get) Token: 0x0602EEEF RID: 192239 RVA: 0x00B1E2D1 File Offset: 0x00B1C4D1
		public Dictionary<string, VideoResourceInfo> VideoMap
		{
			get
			{
				return this.Video;
			}
		}

		// Token: 0x0602EEF0 RID: 192240 RVA: 0x00B1E2D9 File Offset: 0x00B1C4D9
		[NullableContext(2)]
		public void SetUiEvent(IDiffUpdateUiEvent uiEvent)
		{
			this.UiEvent = uiEvent;
		}

		// Token: 0x0602EEF1 RID: 192241 RVA: 0x00B1E2E2 File Offset: 0x00B1C4E2
		public void ResetNetworkTypeRecord()
		{
			this.IsAllowCellDownload = false;
			this.NetworkListener.NetworkChangeDelegate.Clear();
			this.CallbackOnNetworkTypeChange = null;
		}

		// Token: 0x0602EEF2 RID: 192242 RVA: 0x00B1E302 File Offset: 0x00B1C502
		public bool GetIsCellNetworkType()
		{
			return this.NetworkListener.GetNetworkType() == 3;
		}

		// Token: 0x0602EEF3 RID: 192243 RVA: 0x00B1E312 File Offset: 0x00B1C512
		public bool GetIsAllowCellDownload()
		{
			return this.IsAllowCellDownload;
		}

		// Token: 0x0602EEF4 RID: 192244 RVA: 0x00B1E31A File Offset: 0x00B1C51A
		public void SetCallbackOnNetworkTypeChange(Action<byte> callback)
		{
			this.NetworkListener.NetworkChangeDelegate.Clear();
			this.CallbackOnNetworkTypeChange = callback;
			this.NetworkListener.NetworkChangeDelegate.Add(this.CallbackOnNetworkTypeChange);
		}

		// Token: 0x0602EEF5 RID: 192245 RVA: 0x00B1E349 File Offset: 0x00B1C549
		public void SetIsAllowCellDownload(bool isAllowCellDownload)
		{
			this.IsAllowCellDownload = isAllowCellDownload;
		}

		// Token: 0x0602EEF6 RID: 192246 RVA: 0x00B1E352 File Offset: 0x00B1C552
		public bool GetIsSeparateVideo()
		{
			return this.IsSeparateVideoInternal;
		}

		// Token: 0x0602EEF7 RID: 192247 RVA: 0x00B1E35C File Offset: 0x00B1C55C
		public bool IsVideoClearGrayBoxHit()
		{
			if (!this.IsSeparateVideoInternal)
			{
				return false;
			}
			if (Singleton<Platform>.Instance.IsCloudGame())
			{
				Singleton<LauncherLog>.Instance.Info("云游戏不开启Mp4分包", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
			{
				Singleton<LauncherLog>.Instance.Info("分包开启, 忽略mp4灰度, 直接命中", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}
			if (UKuroStaticLibrary.IsModuleLoaded("KuroSDK") && Singleton<BaseConfigController>.Instance.GetPublicValue("UseSDK") == "1")
			{
				return Singleton<BaseConfigController>.Instance.CheckGrayBoxHitByDeviceId("ClearVideoResGrayBox", UKuroSDKManager.GetBasicInfo().DeviceId);
			}
			Singleton<LauncherLog>.Instance.Info("VideoResUpdate ClearVideoResGrayBox 灰度检查: SDK未启用，灰度命中", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}

		// Token: 0x0602EEF8 RID: 192248 RVA: 0x00B1E41C File Offset: 0x00B1C61C
		public unsafe void Init(AppPathMisc appPathMisc, bool isSeparateVideo, bool isNewUser)
		{
			this.PathMisc = appPathMisc;
			this.IsSeparateVideoInternal = isSeparateVideo;
			int deviceSaved = Singleton<LauncherStorageLib>.Instance.GetDeviceSaved<int>(ELauncherStorageDeviceKey.IsNewUserSelected, 0);
			if (isNewUser)
			{
				if (deviceSaved == 0)
				{
					Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<int>(ELauncherStorageDeviceKey.IsNewUserSelected, 1);
				}
				this.IsNewUser = isNewUser;
			}
			else if (deviceSaved == 1)
			{
				this.IsNewUser = true;
			}
			else
			{
				this.IsNewUser = false;
			}
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "VideoResInit";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isSeparateVideo", isSeparateVideo);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsNewUser", this.IsNewUser);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("isNewUserSaved", deviceSaved);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x0602EEF9 RID: 192249 RVA: 0x00B1E4F1 File Offset: 0x00B1C6F1
		public void SetVideoResSize(EVideoResSizeType sizeType, long size)
		{
			this.VideoResSizeMap[sizeType] = size;
		}

		// Token: 0x0602EEFA RID: 192250 RVA: 0x00B1E500 File Offset: 0x00B1C700
		public bool GetIsNewUser()
		{
			return this.IsNewUser;
		}

		// Token: 0x0602EEFB RID: 192251 RVA: 0x00B1E508 File Offset: 0x00B1C708
		public bool GetIsEnableVideoUpdateEntry()
		{
			return this.IsSeparateVideoInternal && this.GetIsGrayBoxHit();
		}

		// Token: 0x0602EEFC RID: 192252 RVA: 0x00B1E51A File Offset: 0x00B1C71A
		public bool GetIsGrayBoxHit()
		{
			return false;
		}

		// Token: 0x0602EEFD RID: 192253 RVA: 0x00B1E51D File Offset: 0x00B1C71D
		public long GetVideoResSize(EVideoResSizeType sizeType)
		{
			if (this.VideoResSizeMap.ContainsKey(sizeType))
			{
				return this.VideoResSizeMap[sizeType];
			}
			return 0L;
		}

		// Token: 0x0602EEFE RID: 192254 RVA: 0x00B1E53C File Offset: 0x00B1C73C
		public void SetVideoResSavedSize(EVideoResSizeType sizeType, long size)
		{
			this.VideoResSavedSizeMap[sizeType] = size;
		}

		// Token: 0x0602EEFF RID: 192255 RVA: 0x00B1E54B File Offset: 0x00B1C74B
		public long GetVideoResSavedSize(EVideoResSizeType sizeType)
		{
			if (this.VideoResSavedSizeMap.ContainsKey(sizeType))
			{
				return this.VideoResSavedSizeMap[sizeType];
			}
			return 0L;
		}

		// Token: 0x0602EF00 RID: 192256 RVA: 0x00B1E56A File Offset: 0x00B1C76A
		public void SetVideoResPak(EVideoResSizeType sizeType, List<string> paks)
		{
			this.VideoResPakMap[sizeType] = paks;
		}

		// Token: 0x0602EF01 RID: 192257 RVA: 0x00B1E57C File Offset: 0x00B1C77C
		public IReadOnlyList<string> GetVideoResPak(EVideoResSizeType sizeType)
		{
			List<string> result;
			if (this.VideoResPakMap.TryGetValue(sizeType, out result))
			{
				return result;
			}
			return Array.Empty<string>();
		}

		// Token: 0x0602EF02 RID: 192258 RVA: 0x00B1E5A0 File Offset: 0x00B1C7A0
		public void SetAllSpecialVideoResPak(EVideoResSizeType sizeType, List<string> paks)
		{
			this.AllSpVideoResPakMap[sizeType] = paks;
		}

		// Token: 0x0602EF03 RID: 192259 RVA: 0x00B1E5B0 File Offset: 0x00B1C7B0
		public IReadOnlyList<string> GetAllSpecialVideoResPak(EVideoResSizeType sizeType)
		{
			List<string> result;
			if (this.AllSpVideoResPakMap.TryGetValue(sizeType, out result))
			{
				return result;
			}
			return Array.Empty<string>();
		}

		// Token: 0x0602EF04 RID: 192260 RVA: 0x00B1E5D4 File Offset: 0x00B1C7D4
		public unsafe bool GetIsResPakDownloading(EVideoResSizeType sizeType)
		{
			List<string> list;
			if (!this.VideoResPakMap.TryGetValue(sizeType, out list))
			{
				return false;
			}
			bool result;
			if (this.VideoResPakMapDownLoadState.TryGetValue(sizeType, out result))
			{
				return result;
			}
			List<string> list2 = new List<string>();
			foreach (string text in list)
			{
				if (!text.EndsWith("2"))
				{
					list2.Add(text);
				}
			}
			bool flag = false;
			ValueTuple<List<RequireFileInfo>, long, long, List<LocalFileInfo>> valueTuple = this.AnalyzeRequireFilesByNames(list2);
			long item = valueTuple.Item2;
			long item2 = valueTuple.Item3;
			if (item != item2 && item2 > 0L)
			{
				flag = true;
			}
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "VideoDown Is VideoRes Downloading?";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ResType", sizeType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isDownloading", flag);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.VideoResPakMapDownLoadState[sizeType] = flag;
			return flag;
		}

		// Token: 0x0602EF05 RID: 192261 RVA: 0x00B1E6F4 File Offset: 0x00B1C8F4
		public void ResetResPakDownloadingState(EVideoResSizeType sizeType)
		{
			if (this.VideoResPakMapDownLoadState.ContainsKey(sizeType))
			{
				this.VideoResPakMapDownLoadState.Remove(sizeType);
			}
		}

		// Token: 0x0602EF06 RID: 192262 RVA: 0x00B1E714 File Offset: 0x00B1C914
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1,
			1
		})]
		public ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>> AnalyzeRequireFiles()
		{
			List<LocalFileInfo> list = new List<LocalFileInfo>();
			List<RequireFileInfo> list2 = new List<RequireFileInfo>();
			foreach (KeyValuePair<string, VideoResourceInfo> keyValuePair in this.Video)
			{
				ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>, long, long> valueTuple = this.AnalyzeSingle(keyValuePair.Value);
				List<LocalFileInfo> item = valueTuple.Item1;
				List<RequireFileInfo> item2 = valueTuple.Item2;
				list.AddRange(item);
				list2.AddRange(item2);
			}
			return new ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>>(list, list2);
		}

		// Token: 0x0602EF07 RID: 192263 RVA: 0x00B1E7A0 File Offset: 0x00B1C9A0
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			0
		})]
		public ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>, List<LocalFileInfo>, List<RequireFileInfo>, List<LocalFileInfo>, List<RequireFileInfo>, long, ValueTuple<long>> GetRequireFiles()
		{
			List<LocalFileInfo> list = new List<LocalFileInfo>();
			List<RequireFileInfo> list2 = new List<RequireFileInfo>();
			List<LocalFileInfo> list3 = new List<LocalFileInfo>();
			List<RequireFileInfo> list4 = new List<RequireFileInfo>();
			List<LocalFileInfo> list5 = new List<LocalFileInfo>();
			List<RequireFileInfo> list6 = new List<RequireFileInfo>();
			long num = 0L;
			long num2 = 0L;
			foreach (KeyValuePair<string, VideoResourceInfo> keyValuePair in this.Video)
			{
				ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>, long, long> valueTuple = this.AnalyzeSingle(keyValuePair.Value);
				List<LocalFileInfo> item = valueTuple.Item1;
				List<RequireFileInfo> item2 = valueTuple.Item2;
				long item3 = valueTuple.Item3;
				long item4 = valueTuple.Item4;
				list.AddRange(item);
				list2.AddRange(item2);
				num += item3;
				num2 += item4;
				if (keyValuePair.Key.EndsWith("0"))
				{
					list3.AddRange(item);
					list4.AddRange(item2);
				}
				else if (keyValuePair.Key.EndsWith("1"))
				{
					list5.AddRange(item);
					list6.AddRange(item2);
				}
				else if (keyValuePair.Key.EndsWith("2"))
				{
					list3.AddRange(item);
					list4.AddRange(item2);
					list5.AddRange(item);
					list6.AddRange(item2);
				}
			}
			return new ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>, List<LocalFileInfo>, List<RequireFileInfo>, List<LocalFileInfo>, List<RequireFileInfo>, long, ValueTuple<long>>(list, list2, list3, list4, list5, list6, num, new ValueTuple<long>(num2));
		}

		// Token: 0x0602EF08 RID: 192264 RVA: 0x00B1E904 File Offset: 0x00B1CB04
		public void CheckVideoManifestsData()
		{
			if (!UKuroLauncherLibrary.NeedHotPatch())
			{
				return;
			}
			if (this.Video.Count == 0)
			{
				this.ResolveVideoManifests();
			}
		}

		// Token: 0x0602EF09 RID: 192265 RVA: 0x00B1E924 File Offset: 0x00B1CB24
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1,
			1
		})]
		public ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>> GetPreDownloadRequireFiles()
		{
			List<LocalFileInfo> list = new List<LocalFileInfo>();
			List<RequireFileInfo> list2 = new List<RequireFileInfo>();
			foreach (KeyValuePair<string, VideoResourceInfo> keyValuePair in this.PreDownloadVideo)
			{
				ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>, long, long> valueTuple = this.AnalyzeSingle(keyValuePair.Value);
				List<LocalFileInfo> item = valueTuple.Item1;
				List<RequireFileInfo> item2 = valueTuple.Item2;
				list.AddRange(item);
				list2.AddRange(item2);
			}
			return new ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>>(list, list2);
		}

		// Token: 0x0602EF0A RID: 192266 RVA: 0x00B1E9B0 File Offset: 0x00B1CBB0
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1,
			1
		})]
		public ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>, long, long> AnalyzeSingle(VideoResourceInfo singleInfo)
		{
			List<LocalFileInfo> list = new List<LocalFileInfo>();
			List<RequireFileInfo> list2 = new List<RequireFileInfo>();
			long num = 0L;
			long num2 = 0L;
			string text = singleInfo.LocalPath + "/" + singleInfo.PakFileName;
			string remoteRoute = singleInfo.RemoteRoute + "/" + singleInfo.PakFileName;
			DestFileInfo destFileInfo = new DestFileInfo(singleInfo.PakFileName, text, singleInfo.PakSize, remoteRoute, singleInfo.PakHash);
			num += destFileInfo.ExpectSize;
			num2 += destFileInfo.GetLocalSize();
			if (!destFileInfo.IsCompleteFile())
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "VideoRes new download file";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("res", text);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				list.Add(destFileInfo);
				list2.Add(destFileInfo.GetRequireInfo());
			}
			string text2 = singleInfo.LocalPath + "/" + singleInfo.SigFileName;
			string remoteRoute2 = singleInfo.RemoteRoute + "/" + singleInfo.SigFileName;
			DestFileInfo destFileInfo2 = new DestFileInfo(singleInfo.SigFileName, text2, singleInfo.SigSize, remoteRoute2, singleInfo.SigHash);
			num += destFileInfo2.ExpectSize;
			num2 += destFileInfo2.GetLocalSize();
			if (!destFileInfo2.IsCompleteFile())
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "VideoRes new download file";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("res", text2);
				instance2.Info(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				list.Add(destFileInfo2);
				list2.Add(destFileInfo2.GetRequireInfo());
			}
			return new ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>, long, long>(list, list2, num, num2);
		}

		// Token: 0x0602EF0B RID: 192267 RVA: 0x00B1EB20 File Offset: 0x00B1CD20
		public void DeleteSingle(VideoResourceInfo singleInfo)
		{
			UKuroPakMountStatic.UnmountPak(singleInfo.LocalPath + "/" + singleInfo.PakFileName);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "delete video res dir";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dir", singleInfo.LocalPath);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (!UBlueprintPathsLibrary.DirectoryExists(singleInfo.LocalPath))
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "VideoRes delete file but dir not exist";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("dir", singleInfo.LocalPath);
				instance2.Warn(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			if (UKuroLauncherLibrary.DeleteDirectory(singleInfo.LocalPath))
			{
				LauncherLog instance3 = Singleton<LauncherLog>.Instance;
				string message3 = "delete video res dir success";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("dir", singleInfo.LocalPath);
				instance3.Info(message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return;
			}
			LauncherLog instance4 = Singleton<LauncherLog>.Instance;
			string message4 = "VideoRes delete file fail";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("dir", singleInfo.LocalPath);
			instance4.Warn(message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
		}

		// Token: 0x0602EF0C RID: 192268 RVA: 0x00B1EC04 File Offset: 0x00B1CE04
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1,
			1
		})]
		public ValueTuple<List<RequireFileInfo>, long, long, List<LocalFileInfo>> AnalyzeRequireFilesByNames(IReadOnlyList<string> videoNames)
		{
			List<LocalFileInfo> list = new List<LocalFileInfo>();
			List<RequireFileInfo> list2 = new List<RequireFileInfo>();
			long num = 0L;
			long num2 = 0L;
			foreach (string text in videoNames)
			{
				VideoResourceInfo singleInfo;
				if (!this.Video.TryGetValue(text, out singleInfo))
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "VideoRes not find remote video info ";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("res", text);
					instance.Warn(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>, long, long> valueTuple2 = this.AnalyzeSingle(singleInfo);
					List<LocalFileInfo> item = valueTuple2.Item1;
					List<RequireFileInfo> item2 = valueTuple2.Item2;
					long item3 = valueTuple2.Item3;
					long item4 = valueTuple2.Item4;
					num += item3;
					num2 += item4;
					list.AddRange(item);
					list2.AddRange(item2);
				}
			}
			return new ValueTuple<List<RequireFileInfo>, long, long, List<LocalFileInfo>>(list2, num, num2, list);
		}

		// Token: 0x0602EF0D RID: 192269 RVA: 0x00B1ECE4 File Offset: 0x00B1CEE4
		public long GetFreeSpace()
		{
			return ResPackageInfo.GetTotalAndFreeSpace(ResPackageInfo.GetResSaveDir()).Item2;
		}

		// Token: 0x0602EF0E RID: 192270 RVA: 0x00B1ECF5 File Offset: 0x00B1CEF5
		public bool IsVideoDirExists()
		{
			return UBlueprintPathsLibrary.DirectoryExists(ResPackageInfo.GetResSaveDir() + "Video/Paks");
		}

		// Token: 0x0602EF0F RID: 192271 RVA: 0x00B1ED0C File Offset: 0x00B1CF0C
		public void MountPaks()
		{
			foreach (KeyValuePair<string, VideoResourceInfo> keyValuePair in this.Video)
			{
				string text = keyValuePair.Value.LocalPath + "/" + keyValuePair.Value.PakFileName;
				if (UKuroLauncherLibrary.GetFileSize(text) == keyValuePair.Value.PakSize)
				{
					UKuroPakMountStatic.MountPak(text, 4);
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "VideoRes mount pak";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("res", keyValuePair.Value.PakSize);
					instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
		}

		// Token: 0x0602EF10 RID: 192272 RVA: 0x00B1EDCC File Offset: 0x00B1CFCC
		public void MountPaksByName(List<string> videoNames)
		{
			foreach (string text in videoNames)
			{
				VideoResourceInfo videoResourceInfo;
				if (!this.Video.TryGetValue(text, out videoResourceInfo))
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "VideoRes not find remote video info ";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("res", text);
					instance.Warn(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					string text2 = videoResourceInfo.LocalPath + "/" + videoResourceInfo.PakFileName;
					if (UKuroLauncherLibrary.GetFileSize(text2) == videoResourceInfo.PakSize)
					{
						UKuroPakMountStatic.MountPak(text2, 4);
						LauncherLog instance2 = Singleton<LauncherLog>.Instance;
						string message2 = "VideoRes mount pak";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("res", videoResourceInfo.PakSize);
						instance2.Info(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					}
				}
			}
		}

		// Token: 0x0602EF11 RID: 192273 RVA: 0x00B1EEAC File Offset: 0x00B1D0AC
		[NullableContext(0)]
		public UniTask<bool> UpdateVideoSource()
		{
			VideoResUpdate.<UpdateVideoSource>d__57 <UpdateVideoSource>d__;
			<UpdateVideoSource>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UpdateVideoSource>d__.<>4__this = this;
			<UpdateVideoSource>d__.<>1__state = -1;
			<UpdateVideoSource>d__.<>t__builder.Start<VideoResUpdate.<UpdateVideoSource>d__57>(ref <UpdateVideoSource>d__);
			return <UpdateVideoSource>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF12 RID: 192274 RVA: 0x00B1EEF0 File Offset: 0x00B1D0F0
		private UniTask RequestVideoCfg()
		{
			VideoResUpdate.<RequestVideoCfg>d__58 <RequestVideoCfg>d__;
			<RequestVideoCfg>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestVideoCfg>d__.<>4__this = this;
			<RequestVideoCfg>d__.<>1__state = -1;
			<RequestVideoCfg>d__.<>t__builder.Start<VideoResUpdate.<RequestVideoCfg>d__58>(ref <RequestVideoCfg>d__);
			return <RequestVideoCfg>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF13 RID: 192275 RVA: 0x00B1EF34 File Offset: 0x00B1D134
		[NullableContext(0)]
		private UniTask<bool> RequestVideoCfgManifest()
		{
			VideoResUpdate.<RequestVideoCfgManifest>d__59 <RequestVideoCfgManifest>d__;
			<RequestVideoCfgManifest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestVideoCfgManifest>d__.<>4__this = this;
			<RequestVideoCfgManifest>d__.<>1__state = -1;
			<RequestVideoCfgManifest>d__.<>t__builder.Start<VideoResUpdate.<RequestVideoCfgManifest>d__59>(ref <RequestVideoCfgManifest>d__);
			return <RequestVideoCfgManifest>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF14 RID: 192276 RVA: 0x00B1EF78 File Offset: 0x00B1D178
		private bool ResolveVideoManifests()
		{
			bool result = this.ResolveVideoManifestsFromPath(this.Video, Singleton<BaseConfigController>.Instance.GetMixUri(), Singleton<BaseConfigController>.Instance.GetResUri(), UKuroLauncherLibrary.GetAppVersion());
			foreach (KeyValuePair<string, VideoResourceInfo> keyValuePair in this.Video)
			{
				string key = keyValuePair.Key;
				int key2;
				if (!int.TryParse(key.Split('_', StringSplitOptions.None)[0], out key2))
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "VideoRes invalid video id";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("res", key);
					instance.Warn(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					this.VideoIdToPackName[key2] = key;
				}
			}
			return result;
		}

		// Token: 0x0602EF15 RID: 192277 RVA: 0x00B1F040 File Offset: 0x00B1D240
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<RemoteVideoConfigUpdateTime> RequestVideoCfgForPath(string mixPath)
		{
			VideoResUpdate.<RequestVideoCfgForPath>d__61 <RequestVideoCfgForPath>d__;
			<RequestVideoCfgForPath>d__.<>t__builder = AsyncUniTaskMethodBuilder<RemoteVideoConfigUpdateTime>.Create();
			<RequestVideoCfgForPath>d__.mixPath = mixPath;
			<RequestVideoCfgForPath>d__.<>1__state = -1;
			<RequestVideoCfgForPath>d__.<>t__builder.Start<VideoResUpdate.<RequestVideoCfgForPath>d__61>(ref <RequestVideoCfgForPath>d__);
			return <RequestVideoCfgForPath>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF16 RID: 192278 RVA: 0x00B1F084 File Offset: 0x00B1D284
		[return: Nullable(0)]
		public UniTask<bool> DownloadVideoCfgManifestForConfig(RemoteVideoConfigUpdateTime videoConfig, string mixUri, string appVersion)
		{
			VideoResUpdate.<DownloadVideoCfgManifestForConfig>d__62 <DownloadVideoCfgManifestForConfig>d__;
			<DownloadVideoCfgManifestForConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DownloadVideoCfgManifestForConfig>d__.<>4__this = this;
			<DownloadVideoCfgManifestForConfig>d__.videoConfig = videoConfig;
			<DownloadVideoCfgManifestForConfig>d__.mixUri = mixUri;
			<DownloadVideoCfgManifestForConfig>d__.appVersion = appVersion;
			<DownloadVideoCfgManifestForConfig>d__.<>1__state = -1;
			<DownloadVideoCfgManifestForConfig>d__.<>t__builder.Start<VideoResUpdate.<DownloadVideoCfgManifestForConfig>d__62>(ref <DownloadVideoCfgManifestForConfig>d__);
			return <DownloadVideoCfgManifestForConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF17 RID: 192279 RVA: 0x00B1F0DF File Offset: 0x00B1D2DF
		private string GetVideoManifestSavePath(string appVersion)
		{
			return ResPackageInfo.GetResSaveDir() + "Video/" + appVersion + "/VideoManifest.json";
		}

		// Token: 0x0602EF18 RID: 192280 RVA: 0x00B1F0F8 File Offset: 0x00B1D2F8
		private string GetVideoManifestDownloadPath(string mixPath, string appVersion)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 3);
			defaultInterpolatedStringHandler.AppendFormatted(mixPath);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(this.PathMisc.GetPlatform());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(appVersion);
			defaultInterpolatedStringHandler.AppendLiteral("/Video/VideoManifest.json");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602EF19 RID: 192281 RVA: 0x00B1F15C File Offset: 0x00B1D35C
		private string GetVideoLocalSavePath()
		{
			return ResPackageInfo.GetResSaveDir() + "Video/Paks";
		}

		// Token: 0x0602EF1A RID: 192282 RVA: 0x00B1F170 File Offset: 0x00B1D370
		private string GetVideoRemoteRoute(string resUri, string appVersion)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 3);
			defaultInterpolatedStringHandler.AppendFormatted(resUri);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(this.PathMisc.GetPlatform());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(appVersion);
			defaultInterpolatedStringHandler.AppendLiteral("/Video");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602EF1B RID: 192283 RVA: 0x00B1F1D4 File Offset: 0x00B1D3D4
		public bool ResolveVideoManifestsFromPath(Dictionary<string, VideoResourceInfo> outVideo, string mixUri, string resUri, string appVersion)
		{
			string videoManifestSavePath = this.GetVideoManifestSavePath(appVersion);
			string inCipher = "";
			if (!UKuroStaticLibrary.LoadFileToString(ref inCipher, videoManifestSavePath))
			{
				return false;
			}
			string text = "";
			if (!UKuroLauncherLibrary.Decrypt(inCipher, ref text))
			{
				return false;
			}
			RemoteVideoConfig remoteVideoConfig = LauncherJson.Parse<RemoteVideoConfig>(text, null);
			if (remoteVideoConfig == null)
			{
				Singleton<LauncherLog>.Instance.Error("VideoCfg is not exist.", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			string videoRemoteRoute = this.GetVideoRemoteRoute(resUri, appVersion);
			string videoLocalSavePath = this.GetVideoLocalSavePath();
			foreach (KeyValuePair<string, VideoItem> keyValuePair in remoteVideoConfig.VideoInfos.PakMap)
			{
				string key = keyValuePair.Key;
				VideoItem value = keyValuePair.Value;
				if (!(key == "__kr_map__"))
				{
					VideoResourceInfo value2 = new VideoResourceInfo(videoRemoteRoute, videoLocalSavePath + "/" + key, value.PakName, value.PakSize, value.PakHash, value.SigName, value.SigSize, value.SigHash);
					outVideo[key] = value2;
				}
			}
			return true;
		}

		// Token: 0x0602EF1C RID: 192284 RVA: 0x00B1F2FC File Offset: 0x00B1D4FC
		[return: Nullable(new byte[]
		{
			0,
			0,
			1,
			1,
			1,
			1
		})]
		public UniTask<ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>, long>> AnalyzeVideoManifests()
		{
			VideoResUpdate.<AnalyzeVideoManifests>d__68 <AnalyzeVideoManifests>d__;
			<AnalyzeVideoManifests>d__.<>t__builder = AsyncUniTaskMethodBuilder<ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>, long>>.Create();
			<AnalyzeVideoManifests>d__.<>4__this = this;
			<AnalyzeVideoManifests>d__.<>1__state = -1;
			<AnalyzeVideoManifests>d__.<>t__builder.Start<VideoResUpdate.<AnalyzeVideoManifests>d__68>(ref <AnalyzeVideoManifests>d__);
			return <AnalyzeVideoManifests>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF1D RID: 192285 RVA: 0x00B1F340 File Offset: 0x00B1D540
		public List<string> GetVideoResPakByVideoIds(IReadOnlyList<int> videoIds)
		{
			List<string> list = new List<string>();
			foreach (int key in videoIds)
			{
				string item;
				if (this.VideoIdToPackName.TryGetValue(key, out item) && !list.Contains(item))
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x0401AB60 RID: 109408
		private const int DOWNLOAD_TRY_COUNT = 3;

		// Token: 0x0401AB61 RID: 109409
		private const string CLEAR_VIDEO_RES_GRAY_BOX = "ClearVideoResGrayBox";

		// Token: 0x0401AB62 RID: 109410
		[Nullable(2)]
		private RemoteVideoConfigUpdateTime ConfigUpdateInfo;

		// Token: 0x0401AB63 RID: 109411
		private readonly Dictionary<string, VideoResourceInfo> Video = new Dictionary<string, VideoResourceInfo>();

		// Token: 0x0401AB64 RID: 109412
		private readonly Dictionary<int, string> VideoIdToPackName = new Dictionary<int, string>();

		// Token: 0x0401AB65 RID: 109413
		private readonly Dictionary<string, VideoResourceInfo> PreDownloadVideo = new Dictionary<string, VideoResourceInfo>();

		// Token: 0x0401AB66 RID: 109414
		private readonly Dictionary<EVideoResSizeType, long> VideoResSizeMap = new Dictionary<EVideoResSizeType, long>();

		// Token: 0x0401AB67 RID: 109415
		private readonly Dictionary<EVideoResSizeType, long> VideoResSavedSizeMap = new Dictionary<EVideoResSizeType, long>();

		// Token: 0x0401AB68 RID: 109416
		private readonly Dictionary<EVideoResSizeType, List<string>> VideoResPakMap = new Dictionary<EVideoResSizeType, List<string>>();

		// Token: 0x0401AB69 RID: 109417
		private readonly Dictionary<EVideoResSizeType, bool> VideoResPakMapDownLoadState = new Dictionary<EVideoResSizeType, bool>();

		// Token: 0x0401AB6A RID: 109418
		private readonly Dictionary<EVideoResSizeType, List<string>> AllSpVideoResPakMap = new Dictionary<EVideoResSizeType, List<string>>();

		// Token: 0x0401AB6B RID: 109419
		[Nullable(2)]
		private AppPathMisc PathMisc;

		// Token: 0x0401AB6C RID: 109420
		private bool IsSeparateVideoInternal;

		// Token: 0x0401AB6D RID: 109421
		private bool IsNewUser;

		// Token: 0x0401AB6E RID: 109422
		private bool IsAllowCellDownload;

		// Token: 0x0401AB6F RID: 109423
		[Nullable(2)]
		private Action<byte> CallbackOnNetworkTypeChange;

		// Token: 0x0401AB70 RID: 109424
		[Nullable(2)]
		private UKuroNetworkChange NetworkListenerInternal;

		// Token: 0x0401AB71 RID: 109425
		public bool ManifestInited;

		// Token: 0x0401AB72 RID: 109426
		[Nullable(2)]
		private IDiffUpdateUiEvent UiEvent;

		// Token: 0x0401AB73 RID: 109427
		public EVideoResSizeType VideoDownloadState = EVideoResSizeType.StartMinNeed;
	}
}
