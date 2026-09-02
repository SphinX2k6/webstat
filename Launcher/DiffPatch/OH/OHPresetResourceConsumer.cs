using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.DiffPatch.OH
{
	// Token: 0x0200463F RID: 17983
	[NullableContext(1)]
	[Nullable(0)]
	public class OHPresetResourceConsumer
	{
		// Token: 0x0602EF53 RID: 192339 RVA: 0x00B2024C File Offset: 0x00B1E44C
		public OHPresetResourceConsumer()
		{
			this.OhSystemManagedDownloadDir = "/data/storage/el2/base/haps/entry/cache/asset_acceleration/";
			this.OhNearbyDir = "/data/storage/el2/base/files/com.huawei.hms.gameservice.nearby.transfer/receive/UE4Game/Client/Client/Saved/Resources/";
		}

		// Token: 0x0602EF54 RID: 192340 RVA: 0x00B2026A File Offset: 0x00B1E46A
		public bool IsSysMgEnabled()
		{
			return this.OhSystemManagedDownloadDir.Length > 0 && UBlueprintPathsLibrary.DirectoryExists(this.OhSystemManagedDownloadDir);
		}

		// Token: 0x0602EF55 RID: 192341 RVA: 0x00B20287 File Offset: 0x00B1E487
		public bool IsNearbyEnabled()
		{
			return this.OhNearbyDir.Length > 0 && UBlueprintPathsLibrary.DirectoryExists(this.OhNearbyDir);
		}

		// Token: 0x0602EF56 RID: 192342 RVA: 0x00B202A4 File Offset: 0x00B1E4A4
		public UniTask ConsumeAfterManifest(DiffUpdate update, [Nullable(2)] HotFixManager viewMgr, bool bIsLauncher = false)
		{
			OHPresetResourceConsumer.<ConsumeAfterManifest>d__5 <ConsumeAfterManifest>d__;
			<ConsumeAfterManifest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ConsumeAfterManifest>d__.<>4__this = this;
			<ConsumeAfterManifest>d__.update = update;
			<ConsumeAfterManifest>d__.viewMgr = viewMgr;
			<ConsumeAfterManifest>d__.bIsLauncher = bIsLauncher;
			<ConsumeAfterManifest>d__.<>1__state = -1;
			<ConsumeAfterManifest>d__.<>t__builder.Start<OHPresetResourceConsumer.<ConsumeAfterManifest>d__5>(ref <ConsumeAfterManifest>d__);
			return <ConsumeAfterManifest>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF57 RID: 192343 RVA: 0x00B202FF File Offset: 0x00B1E4FF
		private void DeletePresetFile(string path)
		{
			if (UBlueprintPathsLibrary.FileExists(path))
			{
				UKuroLauncherLibrary.DeleteFile(path);
			}
		}

		// Token: 0x0602EF58 RID: 192344 RVA: 0x00B20310 File Offset: 0x00B1E510
		public void Cleanup()
		{
			Singleton<LauncherLog>.Instance.Info("OH clean up preset resources.", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKuroLauncherLibrary.DeleteDirectory(this.OhSystemManagedDownloadDir);
			UKuroLauncherLibrary.DeleteDirectory(this.OhNearbyDir);
		}

		// Token: 0x0602EF59 RID: 192345 RVA: 0x00B20350 File Offset: 0x00B1E550
		private unsafe void Report(int moved, int missed, long totalMoved)
		{
			HotPatchLog hotPatchLog = new HotPatchLog();
			hotPatchLog.s_step_id = "oh_preset_consume";
			hotPatchLog.i_download_state = moved.ToString();
			HotPatchLogResult value = new HotPatchLogResult
			{
				success = true,
				info = new OHConsumeLogInfo
				{
					moved = moved,
					missed = missed,
					totalMoved = totalMoved
				}
			};
			hotPatchLog.s_step_result = LauncherJson.Stringify<HotPatchLogResult>(value, null);
			Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "OH preset consume done";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("moved", moved);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("missed", missed);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("totalMoved", totalMoved.ToString());
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x0602EF5A RID: 192346 RVA: 0x00B20438 File Offset: 0x00B1E638
		private void DirIterator(string dir, Dictionary<string, HashSet<string>> result)
		{
			TArray<string> filesRecursive = UKuroStaticLibrary.GetFilesRecursive(dir, "*", true, false);
			if (filesRecursive != null && filesRecursive.Num() > 0)
			{
				string value = dir.EndsWith('/') ? dir : (dir + "/");
				int num = filesRecursive.Num();
				for (int i = 0; i < num; i++)
				{
					string text = filesRecursive.Get(i).Replace("\\", "/");
					int num2 = text.LastIndexOf('/');
					string key = text.StartsWith(value) ? text.Substring(num2 + 1) : text;
					HashSet<string> hashSet = result.GetValueOrDefault(key);
					if (hashSet == null)
					{
						hashSet = new HashSet<string>();
						result.Add(key, hashSet);
					}
					hashSet.Add(text);
				}
			}
		}

		// Token: 0x0602EF5B RID: 192347 RVA: 0x00B204F8 File Offset: 0x00B1E6F8
		private Dictionary<string, HashSet<string>> EnumeratePresetFiles()
		{
			Dictionary<string, HashSet<string>> result = new Dictionary<string, HashSet<string>>();
			this.DirIterator(this.OhSystemManagedDownloadDir, result);
			this.DirIterator(this.OhNearbyDir, result);
			return result;
		}

		// Token: 0x0602EF5C RID: 192348 RVA: 0x00B20528 File Offset: 0x00B1E728
		private Dictionary<string, IWantedTarget> BuildWantedFromVideos()
		{
			Dictionary<string, IWantedTarget> dictionary = new Dictionary<string, IWantedTarget>();
			foreach (VideoResourceInfo videoResourceInfo in Singleton<VideoResUpdate>.Instance.VideoMap.Values)
			{
				dictionary[videoResourceInfo.PakFileName] = new IWantedTarget
				{
					Hash = videoResourceInfo.PakHash,
					DestPath = videoResourceInfo.LocalPath + "/" + videoResourceInfo.PakFileName,
					Size = videoResourceInfo.PakSize
				};
				dictionary[videoResourceInfo.SigFileName] = new IWantedTarget
				{
					Hash = videoResourceInfo.SigHash,
					DestPath = videoResourceInfo.LocalPath + "/" + videoResourceInfo.SigFileName,
					Size = videoResourceInfo.SigSize
				};
			}
			return dictionary;
		}

		// Token: 0x0401AB92 RID: 109458
		private readonly string OhSystemManagedDownloadDir;

		// Token: 0x0401AB93 RID: 109459
		private readonly string OhNearbyDir;
	}
}
