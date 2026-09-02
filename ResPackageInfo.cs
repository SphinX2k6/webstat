using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.DiffPatch.Data;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Util;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020034E1 RID: 13537
[NullableContext(1)]
[Nullable(0)]
public class ResPackageInfo : IStaticVariableResetter
{
	// Token: 0x0601C982 RID: 117122 RVA: 0x0089218E File Offset: 0x0089038E
	static ResPackageInfo()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ResPackageInfo.CreateStaticDefaultValue), new Action(ResPackageInfo.ResetStaticDefaultValue));
	}

	// Token: 0x0601C983 RID: 117123 RVA: 0x008921AD File Offset: 0x008903AD
	public static void CreateStaticDefaultValue()
	{
		ResPackageInfo.PathMisc = null;
		ResPackageInfo.Launcher = null;
		ResPackageInfo.Resource = null;
		ResPackageInfo.Languages = new Dictionary<string, ResPackageInfo>();
		ResPackageInfo.OptionalDownLoad = new Dictionary<string, ResPackageInfo>();
		ResPackageInfo.AggregatedManifest = null;
		ResPackageInfo.RoleVoices = new Dictionary<string, ResPackageInfo>();
	}

	// Token: 0x0601C984 RID: 117124 RVA: 0x008921E5 File Offset: 0x008903E5
	public static void ResetStaticDefaultValue()
	{
		ResPackageInfo.Languages = null;
		ResPackageInfo.PathMisc = null;
		ResPackageInfo.Launcher = null;
		ResPackageInfo.Resource = null;
		ResPackageInfo.OptionalDownLoad = null;
		ResPackageInfo.AggregatedManifest = null;
		ResPackageInfo.RoleVoices = null;
	}

	// Token: 0x0601C985 RID: 117125 RVA: 0x00892214 File Offset: 0x00890414
	public static void Init(AppPathMisc pathMisc)
	{
		Singleton<LauncherLog>.Instance.Info("init all res versions.", default(ReadOnlySpan<ValueTuple<string, object>>));
		ResPackageInfo.PathMisc = pathMisc;
		string appVersion = UKuroLauncherLibrary.GetAppVersion();
		VersionItem versionItem;
		if (!Singleton<RemoteInfo>.Instance.NewConfig.ResVersions.TryGetValue("launcher", out versionItem))
		{
			throw new Exception("远程版本配置中，没有launcher的信息");
		}
		string resUri = Singleton<BaseConfigController>.Instance.GetResUri();
		ResPackageInfo.Launcher = new ResPackageInfo(resUri, new LauncherVersionInfo(appVersion, versionItem.Version, versionItem.IndexSha1), false);
		VersionItem versionItem2;
		if (!Singleton<RemoteInfo>.Instance.NewConfig.ResVersions.TryGetValue("resource", out versionItem2))
		{
			throw new Exception("远程版本配置中，没有resource的信息");
		}
		ResPackageInfo.Resource = new ResPackageInfo(resUri, new ResourceVersionInfo(appVersion, versionItem2.Version, versionItem2.IndexSha1), false);
		foreach (LaunchLangDefine launchLangDefine in Singleton<LauncherLanguageLib>.Instance.GetAllLanguageDefines())
		{
			if (!ResPackageInfo.Languages.ContainsKey(launchLangDefine.AudioCode))
			{
				VersionItem versionItem3;
				if (!Singleton<RemoteInfo>.Instance.NewConfig.ResVersions.TryGetValue(launchLangDefine.AudioCode, out versionItem3))
				{
					throw new Exception("远程版本配置中，没有多语言" + launchLangDefine.AudioCode + "的信息");
				}
				ResPackageInfo value = new ResPackageInfo(resUri, new LanguageVersionInfo(appVersion, versionItem3.Version, versionItem3.IndexSha1, launchLangDefine.AudioCode), false);
				ResPackageInfo.Languages[launchLangDefine.AudioCode] = value;
			}
		}
		foreach (KeyValuePair<string, VersionItem> keyValuePair in Singleton<RemoteInfo>.Instance.NewConfig.ResVersions)
		{
			if (keyValuePair.Key.StartsWith("Option_"))
			{
				string text = keyValuePair.Key.Replace("Option_", "");
				ResPackageInfo value2 = new ResPackageInfo(resUri, new OptionalDownloadVersionInfo(appVersion, keyValuePair.Value.Version, keyValuePair.Value.IndexSha1, text), false);
				ResPackageInfo.OptionalDownLoad[text] = value2;
			}
		}
		ResPackageInfo.AggregatedManifest = null;
		VersionItem versionItem4;
		if (Singleton<RemoteInfo>.Instance.NewConfig.ResVersions.TryGetValue("ManifestAggregated", out versionItem4))
		{
			ResPackageInfo.AggregatedManifest = new ResPackageInfo(resUri, new AggregatedManifestVersionInfo(appVersion, versionItem4.Version, versionItem4.IndexSha1), false);
		}
	}

	// Token: 0x170026E2 RID: 9954
	// (get) Token: 0x0601C986 RID: 117126 RVA: 0x00892498 File Offset: 0x00890698
	public static ResPackageInfo LauncherInfo
	{
		get
		{
			return ResPackageInfo.Launcher;
		}
	}

	// Token: 0x170026E3 RID: 9955
	// (get) Token: 0x0601C987 RID: 117127 RVA: 0x0089249F File Offset: 0x0089069F
	public static ResPackageInfo ResourceInfo
	{
		get
		{
			return ResPackageInfo.Resource;
		}
	}

	// Token: 0x170026E4 RID: 9956
	// (get) Token: 0x0601C988 RID: 117128 RVA: 0x008924A6 File Offset: 0x008906A6
	public static Dictionary<string, ResPackageInfo> OptionalDownLoadInfo
	{
		get
		{
			return ResPackageInfo.OptionalDownLoad;
		}
	}

	// Token: 0x170026E5 RID: 9957
	// (get) Token: 0x0601C989 RID: 117129 RVA: 0x008924AD File Offset: 0x008906AD
	[Nullable(2)]
	public static ResPackageInfo AggregatedManifestInfo
	{
		[NullableContext(2)]
		get
		{
			return ResPackageInfo.AggregatedManifest;
		}
	}

	// Token: 0x170026E6 RID: 9958
	// (get) Token: 0x0601C98A RID: 117130 RVA: 0x008924B4 File Offset: 0x008906B4
	public static Dictionary<string, ResPackageInfo> RoleVoiceInfos
	{
		get
		{
			return ResPackageInfo.RoleVoices;
		}
	}

	// Token: 0x0601C98B RID: 117131 RVA: 0x008924BB File Offset: 0x008906BB
	public static List<ResPackageInfo> GetAllRoleVoiceInfos()
	{
		return new List<ResPackageInfo>(ResPackageInfo.RoleVoices.Values);
	}

	// Token: 0x0601C98C RID: 117132 RVA: 0x008924CC File Offset: 0x008906CC
	[return: Nullable(2)]
	public static ResPackageInfo GetRoleVoiceInfo(string packKey)
	{
		ResPackageInfo result;
		ResPackageInfo.RoleVoices.TryGetValue(packKey, out result);
		return result;
	}

	// Token: 0x0601C98D RID: 117133 RVA: 0x008924E8 File Offset: 0x008906E8
	public static void BuildAggregatedItems(string combinedText, [Nullable(2)] string revertCombinedText = null)
	{
		if (ResPackageInfo.AggregatedManifest == null)
		{
			return;
		}
		Dictionary<string, PatchManifestJson> entries = LauncherJson.Parse<Dictionary<string, PatchManifestJson>>(combinedText, null);
		Dictionary<string, PatchManifestJson> revertEntries = (revertCombinedText != null) ? LauncherJson.Parse<Dictionary<string, PatchManifestJson>>(revertCombinedText, null) : null;
		ResPackageInfo.BuildRoleVoiceItems(entries, revertEntries);
	}

	// Token: 0x0601C98E RID: 117134 RVA: 0x00892518 File Offset: 0x00890718
	private static void BuildRoleVoiceItems(Dictionary<string, PatchManifestJson> entries, [Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, PatchManifestJson> revertEntries = null)
	{
		ResPackageInfo.RoleVoices.Clear();
		string appVersion = UKuroLauncherLibrary.GetAppVersion();
		string resUri = Singleton<BaseConfigController>.Instance.GetResUri();
		string latestVersion = ResPackageInfo.AggregatedManifest.ResourceVersionInfo.LatestVersion;
		string manifestHash = ResPackageInfo.AggregatedManifest.ResourceVersionInfo.ManifestHash;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (!string.IsNullOrEmpty(manifestHash))
		{
			dictionary[latestVersion] = manifestHash;
		}
		foreach (string text in entries.Keys)
		{
			if (text.StartsWith("role_lang_"))
			{
				ResPackageInfo resPackageInfo = new ResPackageInfo(resUri, new RoleVoiceItemVersionInfo(appVersion, latestVersion, dictionary, text), false);
				PatchManifestJson patchManifestJson = null;
				if (revertEntries != null && !revertEntries.TryGetValue(text, out patchManifestJson))
				{
					patchManifestJson = new PatchManifestJson();
					patchManifestJson.DiffPatch = new PatchManifest();
				}
				resPackageInfo.SetManifest(entries[text], patchManifestJson);
				resPackageInfo.CollectAllFiles();
				ResPackageInfo.RoleVoices[text] = resPackageInfo;
			}
		}
		LauncherLog instance = Singleton<LauncherLog>.Instance;
		string message = "BuildRoleVoiceItems done.";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("count", ResPackageInfo.RoleVoices.Count);
		instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601C98F RID: 117135 RVA: 0x00892658 File Offset: 0x00890858
	public void SetPathMisc(AppPathMisc pathMisc)
	{
		if (ResPackageInfo.PathMisc == null)
		{
			ResPackageInfo.PathMisc = pathMisc;
		}
	}

	// Token: 0x0601C990 RID: 117136 RVA: 0x00892668 File Offset: 0x00890868
	public static ResPackageInfo GetLanguageInfo(string lang)
	{
		ResPackageInfo result;
		ResPackageInfo.Languages.TryGetValue(lang, out result);
		return result;
	}

	// Token: 0x0601C991 RID: 117137 RVA: 0x00892684 File Offset: 0x00890884
	public static List<ResPackageInfo> GetLanguageInfos(string[] langArr)
	{
		List<ResPackageInfo> list = new List<ResPackageInfo>();
		foreach (string key in langArr)
		{
			ResPackageInfo item;
			if (ResPackageInfo.Languages.TryGetValue(key, out item))
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x0601C992 RID: 117138 RVA: 0x008926C4 File Offset: 0x008908C4
	public static List<ResPackageInfo> GetAllLanguageInfos()
	{
		List<ResPackageInfo> list = new List<ResPackageInfo>();
		foreach (ResPackageInfo item in ResPackageInfo.Languages.Values)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0601C993 RID: 117139 RVA: 0x00892724 File Offset: 0x00890924
	public static List<ResPackageInfo> GetAllOptionalDownLoadInfo()
	{
		List<ResPackageInfo> list = new List<ResPackageInfo>();
		foreach (ResPackageInfo item in ResPackageInfo.OptionalDownLoad.Values)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0601C994 RID: 117140 RVA: 0x00892784 File Offset: 0x00890984
	public static string GetResSaveDir()
	{
		return ResPackageInfo.PathMisc.GetPatchSaveDir();
	}

	// Token: 0x0601C995 RID: 117141 RVA: 0x00892790 File Offset: 0x00890990
	[NullableContext(0)]
	public static ValueTuple<long, long> GetTotalAndFreeSpace([Nullable(1)] string dirPath)
	{
		return ResPackageInfo.PathMisc.GetTotalAndFreeSpace(dirPath);
	}

	// Token: 0x0601C996 RID: 117142 RVA: 0x008927A0 File Offset: 0x008909A0
	public ResPackageInfo(string ResUri, ResVersionInfo VersionInfo, bool IsPreDownload = false)
	{
		this.VersionInfo = VersionInfo;
		this.ResUri = ResUri;
		this.IsPreDownload = IsPreDownload;
		this.VersionInfo.Init();
		this.LatestVersion = this.VersionInfo.LatestVersion;
		this.HotFixOrRepair = (this.LatestVersion != this.VersionInfo.RecordVersion);
	}

	// Token: 0x0601C997 RID: 117143 RVA: 0x00892863 File Offset: 0x00890A63
	public bool NeedProcessUpdate(bool bForceUpdate)
	{
		if (bForceUpdate)
		{
			return this.VersionInfo.HasContentOnRemote();
		}
		return this.VersionInfo.HasContentOnRemote() && !this.VersionInfo.SkipUpdate();
	}

	// Token: 0x0601C998 RID: 117144 RVA: 0x00892891 File Offset: 0x00890A91
	public bool MustRevertVersion()
	{
		return this.VersionInfo.NeedRevertVersion;
	}

	// Token: 0x0601C999 RID: 117145 RVA: 0x0089289E File Offset: 0x00890A9E
	public bool NeedRebootModuleOrApp()
	{
		return this.NeedReboot;
	}

	// Token: 0x0601C99A RID: 117146 RVA: 0x008928A6 File Offset: 0x00890AA6
	public void SetBasePatchOperate(PatchParams patchOp)
	{
		this.PatchOpParams.Add(patchOp);
	}

	// Token: 0x0601C99B RID: 117147 RVA: 0x008928B4 File Offset: 0x00890AB4
	public bool IsHotFixOrNot()
	{
		return this.HotFixOrRepair;
	}

	// Token: 0x0601C99C RID: 117148 RVA: 0x008928BC File Offset: 0x00890ABC
	public string GetRemoteManifestRoute()
	{
		if (this.LatestVersion != this.VersionInfo.LatestVersion)
		{
			this.ResetCache();
		}
		if (!string.IsNullOrWhiteSpace(this.ManifestRoute))
		{
			return this.ManifestRoute;
		}
		this.ManifestRoute = ResPackageInfo.PathMisc.GetManifestRoute(this.ResUri, this.VersionInfo.LatestVersion, this.VersionInfo.GetManifestFileName());
		return this.ManifestRoute;
	}

	// Token: 0x0601C99D RID: 117149 RVA: 0x0089292D File Offset: 0x00890B2D
	public void SetRemoteManifestRoute(string route)
	{
		this.ManifestRoute = route;
	}

	// Token: 0x0601C99E RID: 117150 RVA: 0x00892936 File Offset: 0x00890B36
	public string GetRemoteRevertManifestRoute()
	{
		return ResPackageInfo.PathMisc.GetManifestRoute(this.ResUri, this.VersionInfo.RecordVersion, this.VersionInfo.GetManifestFileName());
	}

	// Token: 0x0601C99F RID: 117151 RVA: 0x00892960 File Offset: 0x00890B60
	public string GetManifestSavePath()
	{
		if (this.LatestVersion != this.VersionInfo.LatestVersion)
		{
			this.ResetCache();
		}
		if (!string.IsNullOrWhiteSpace(this.ManifestSavePath))
		{
			return this.ManifestSavePath;
		}
		this.ManifestSavePath = ResPackageInfo.PathMisc.GetManifestPath(this.VersionInfo.GetPackageVersion(), this.VersionInfo.LatestVersion, this.VersionInfo.GetManifestFileName());
		return this.ManifestSavePath;
	}

	// Token: 0x0601C9A0 RID: 117152 RVA: 0x008929D6 File Offset: 0x00890BD6
	public void SetManifestSavePath(string manifestPath)
	{
		this.ManifestSavePath = manifestPath;
	}

	// Token: 0x0601C9A1 RID: 117153 RVA: 0x008929DF File Offset: 0x00890BDF
	public string GetRevertManifestPath()
	{
		return ResPackageInfo.PathMisc.GetManifestPath(this.VersionInfo.GetPackageVersion(), this.VersionInfo.RecordVersion, this.VersionInfo.GetManifestFileName());
	}

	// Token: 0x0601C9A2 RID: 117154 RVA: 0x00892A0C File Offset: 0x00890C0C
	public string GetManifestHash()
	{
		return this.VersionInfo.ManifestHash;
	}

	// Token: 0x0601C9A3 RID: 117155 RVA: 0x00892A19 File Offset: 0x00890C19
	public string GetRevertManifestHash()
	{
		return this.VersionInfo.RevertManifestHash;
	}

	// Token: 0x0601C9A4 RID: 117156 RVA: 0x00892A26 File Offset: 0x00890C26
	public bool IsAggregatedManifest()
	{
		return this.VersionInfo is AggregatedManifestVersionInfo;
	}

	// Token: 0x0601C9A5 RID: 117157 RVA: 0x00892A36 File Offset: 0x00890C36
	public void SetManifest(PatchManifestJson patchManifest, PatchManifestJson revertManifest)
	{
		this.Manifest = patchManifest;
		this.RevertManifest = revertManifest;
	}

	// Token: 0x0601C9A6 RID: 117158 RVA: 0x00892A48 File Offset: 0x00890C48
	public void EnumerateExpectedTargetFiles(Action<string, string, long, string> visitor)
	{
		if (this.Manifest == null || this.Manifest.DiffPatch == null)
		{
			return;
		}
		string packageVersion = this.VersionInfo.GetPackageVersion();
		string resType = this.VersionInfo.GetResType();
		string latestVersion = this.VersionInfo.LatestVersion;
		List<ResFileInfo> baseFiles = this.Manifest.DiffPatch.BaseFiles;
		if (baseFiles != null)
		{
			foreach (ResFileInfo resFileInfo in baseFiles)
			{
				if (!string.IsNullOrWhiteSpace(resFileInfo.Hash))
				{
					visitor(resFileInfo.Name, resFileInfo.Hash, resFileInfo.Size, ResPackageInfo.PathMisc.GetResFilePath(packageVersion, "Base", resType, resFileInfo.Name));
				}
			}
		}
		List<ResFileInfo> patchFiles = this.Manifest.DiffPatch.PatchFiles;
		if (patchFiles != null)
		{
			foreach (ResFileInfo resFileInfo2 in patchFiles)
			{
				if (!string.IsNullOrWhiteSpace(resFileInfo2.Hash))
				{
					visitor(resFileInfo2.Name, resFileInfo2.Hash, resFileInfo2.Size, ResPackageInfo.PathMisc.GetResFilePath(packageVersion, latestVersion, resType, resFileInfo2.Name));
				}
			}
		}
	}

	// Token: 0x0601C9A7 RID: 117159 RVA: 0x00892BAC File Offset: 0x00890DAC
	public unsafe virtual void UpdateRecord()
	{
		LauncherLog instance = Singleton<LauncherLog>.Instance;
		string message = "update manifest and record.";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("res", this.VersionInfo.GetResType());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("preDownload", this.IsPreDownload);
		instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (this.VersionInfo.NeedRecordMount())
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string text = "::Mount::\n";
			List<ValueTuple<string, string>> list = new List<ValueTuple<string, string>>();
			foreach (string text2 in this.LatestPakPairs.Keys)
			{
				int num = text2.LastIndexOf('/');
				string item = (num >= 0) ? text2.Substring(num) : text2;
				if (num < 0)
				{
					LauncherLog instance2 = Singleton<LauncherLog>.Instance;
					string message2 = "SaveManifest: key has no '/', fallback to full key.";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", text2);
					instance2.Error(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					list.Add(new ValueTuple<string, string>(item, text2));
				}
			}
			list.Sort(delegate([Nullable(new byte[]
			{
				0,
				1,
				1
			})] ValueTuple<string, string> a, [Nullable(new byte[]
			{
				0,
				1,
				1
			})] ValueTuple<string, string> b)
			{
				if (a.Item1.CompareTo(b.Item1) < 0)
				{
					return -1;
				}
				if (a.Item1.CompareTo(b.Item1) > 0)
				{
					return 1;
				}
				return 0;
			});
			foreach (ValueTuple<string, string> valueTuple2 in list)
			{
				string item2 = valueTuple2.Item2;
				PakFilePair pakFilePair;
				if (this.LatestPakPairs.TryGetValue(item2, out pakFilePair))
				{
					string str = text;
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 4);
					defaultInterpolatedStringHandler.AppendFormatted(item2);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted<int>(pakFilePair.MountOrder);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted(pakFilePair.Pak.GetHash());
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted((pakFilePair.Sig != null) ? pakFilePair.Sig.GetHash() : "");
					defaultInterpolatedStringHandler.AppendLiteral(",,\n");
					text = str + defaultInterpolatedStringHandler.ToStringAndClear();
					if (pakFilePair.Pak.IsRestartRequiredAfterHotPatchChunk)
					{
						dictionary[item2] = pakFilePair.Pak.GetHash() + "," + ((pakFilePair.Sig != null) ? pakFilePair.Sig.GetHash() : "") + ",,";
					}
				}
			}
			text += "::Del::\n";
			foreach (PakFilePair pakFilePair2 in this.OldPakPairs.Values)
			{
				if (pakFilePair2.Pak != null)
				{
					text = text + pakFilePair2.Pak.FilePath + "\n";
				}
				if (pakFilePair2.Sig != null)
				{
					text = text + pakFilePair2.Sig.FilePath + "\n";
				}
			}
			string mountManifestPath = ResPackageInfo.PathMisc.GetMountManifestPath(this.VersionInfo.GetPackageVersion(), this.VersionInfo.GetMountFileName());
			if (dictionary.Count > 0)
			{
				if (!UBlueprintPathsLibrary.FileExists(mountManifestPath))
				{
					this.NeedReboot = true;
					LauncherLog instance3 = Singleton<LauncherLog>.Instance;
					string message3 = "need reboot because mount manifest is not exist.";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("res", this.VersionInfo.GetResType());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("preDownload", this.IsPreDownload);
					instance3.Info(message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
				else
				{
					Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
					TArray<string> tarray = UKuroStaticLibrary.LoadFileToStringArray(mountManifestPath);
					int num2 = tarray.Num();
					for (int i = 0; i < num2; i++)
					{
						string text3 = tarray.Get(i);
						string[] array = text3.Split(',', StringSplitOptions.None);
						dictionary2[array[0].Trim()] = text3;
					}
					foreach (KeyValuePair<string, string> keyValuePair in dictionary)
					{
						string key = keyValuePair.Key;
						string value = keyValuePair.Value;
						string text4;
						if (!dictionary2.TryGetValue(key, out text4) || text4 == null || !text4.Contains(value))
						{
							this.NeedReboot = true;
							LauncherLog instance4 = Singleton<LauncherLog>.Instance;
							string message4 = "need reboot because mount manifest need update.";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("res", this.VersionInfo.GetResType());
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("preDownload", this.IsPreDownload);
							instance4.Info(message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
							break;
						}
					}
				}
			}
			UKuroStaticLibrary.SaveStringToFile(text, mountManifestPath, false);
		}
		this.VersionInfo.UpdateVersionRecord();
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 3);
		defaultInterpolatedStringHandler.AppendFormatted(UKuroLauncherLibrary.GameSavedDir());
		defaultInterpolatedStringHandler.AppendLiteral("Resources/");
		defaultInterpolatedStringHandler.AppendFormatted(this.VersionInfo.GetPackageVersion());
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted(this.VersionInfo.GetResType());
		defaultInterpolatedStringHandler.AppendLiteral("/");
		string text5 = defaultInterpolatedStringHandler.ToStringAndClear();
		TArray<string> directories = UKuroStaticLibrary.GetDirectories(text5);
		int num3 = directories.Num();
		for (int j = 0; j < num3; j++)
		{
			string text6 = directories.Get(j);
			if (!string.Equals(text6, "Base", StringComparison.OrdinalIgnoreCase) && !(text6 == this.VersionInfo.LatestVersion))
			{
				UKuroLauncherLibrary.DeleteDirectory(text5 + text6);
				this.HadDeletion = true;
			}
		}
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 3);
		defaultInterpolatedStringHandler.AppendFormatted(UKuroLauncherLibrary.GameSavedDir());
		defaultInterpolatedStringHandler.AppendLiteral("Resources/");
		defaultInterpolatedStringHandler.AppendFormatted(this.VersionInfo.GetPackageVersion());
		defaultInterpolatedStringHandler.AppendLiteral("/Diff/");
		defaultInterpolatedStringHandler.AppendFormatted(this.VersionInfo.GetResType());
		string text7 = defaultInterpolatedStringHandler.ToStringAndClear();
		if (UBlueprintPathsLibrary.DirectoryExists(text7))
		{
			UKuroLauncherLibrary.DeleteDirectory(text7);
			this.HadDeletion = true;
		}
	}

	// Token: 0x0601C9A8 RID: 117160 RVA: 0x0089322C File Offset: 0x0089142C
	public bool SkipLangUpdateButMountFileModify()
	{
		if (this.VersionInfo.SkipUpdate())
		{
			string mountManifestPath = ResPackageInfo.PathMisc.GetMountManifestPath(this.VersionInfo.GetPackageVersion(), this.VersionInfo.GetMountFileName());
			if (UBlueprintPathsLibrary.FileExists(mountManifestPath))
			{
				UKuroLauncherLibrary.DeleteFile(mountManifestPath);
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601C9A9 RID: 117161 RVA: 0x00893279 File Offset: 0x00891479
	public void ClearRecord()
	{
		this.VersionInfo.ClearVersionRecord();
	}

	// Token: 0x0601C9AA RID: 117162 RVA: 0x00893288 File Offset: 0x00891488
	public virtual void CollectAllFiles()
	{
		this.LatestPakPairs.Clear();
		this.CollectAllFilesByVersion(ResPackageInfo.PathMisc.GetResFileDir(this.VersionInfo.GetPackageVersion(), "Base", this.VersionInfo.GetResType()), "Base", this.VersionInfo.GetPackageVersion(), this.Manifest.DiffPatch.BaseFiles);
		this.CollectAllFilesByVersion(ResPackageInfo.PathMisc.GetResFileDir(this.VersionInfo.GetPackageVersion(), this.VersionInfo.LatestVersion, this.VersionInfo.GetResType()), this.VersionInfo.LatestVersion, this.VersionInfo.LatestVersion, this.Manifest.DiffPatch.PatchFiles);
		int num = 0;
		string a = KuroApplication.IniPlatformNameIncludeEditor();
		foreach (KeyValuePair<string, PakFilePair> keyValuePair in this.LatestPakPairs)
		{
			string key = keyValuePair.Key;
			PakFilePair value = keyValuePair.Value;
			if (value.Pak == null)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "manifest miss pak file info.";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("file", key);
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				num++;
			}
			if (!(a == "PS4") && !(a == "PS5") && !(a == "XSX") && value.Sig == null)
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "manifest miss sig file info.";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("file", key);
				instance2.Error(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				num++;
			}
		}
		if (num > 0)
		{
			throw new Exception("manifest miss file info. count:" + num.ToString());
		}
	}

	// Token: 0x0601C9AB RID: 117163 RVA: 0x00893448 File Offset: 0x00891648
	[return: TupleElementNames(new string[]
	{
		"requireFiles",
		"localSavedSize",
		"totalDownloadSize",
		"totalNeedSpace",
		"totalDownloadAndPatch",
		"allResSize",
		"allFileExpectSize",
		"allFileSavedSize",
		"allFileCount",
		null,
		null
	})]
	[return: Nullable(new byte[]
	{
		0,
		1,
		1,
		0
	})]
	public unsafe virtual ValueTuple<List<RequireFileInfo>, long, long, long, long, long, long, ValueTuple<long, int>> AnalyzeRequireFiles(bool bForceDownload = false)
	{
		if (this.IsAggregatedManifest())
		{
			this.SpaceModel.Reset();
			return new ValueTuple<List<RequireFileInfo>, long, long, long, long, long, long, ValueTuple<long, int>>(new List<RequireFileInfo>(), 0L, 0L, 0L, 0L, 0L, 0L, new ValueTuple<long, int>(0L, 0));
		}
		if (this.Manifest == null || this.Manifest.DiffPatch == null)
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "AnalyzeRequireFiles skipped: Manifest not loaded yet.";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("res", this.VersionInfo.GetResType());
			instance.Warn(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.SpaceModel.Reset();
			return new ValueTuple<List<RequireFileInfo>, long, long, long, long, long, long, ValueTuple<long, int>>(new List<RequireFileInfo>(), 0L, 0L, 0L, 0L, 0L, 0L, new ValueTuple<long, int>(0L, 0));
		}
		LauncherLog instance2 = Singleton<LauncherLog>.Instance;
		string message2 = "analyze res files.";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("forceDownload", bForceDownload);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("preDownload", this.IsPreDownload);
		instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.DownloadList.Clear();
		this.PatchOpParams.Clear();
		this.PreAnalyzeClear();
		this.AnalyzePatch(this.Manifest.DiffPatch.BaseDiffMap, this.VersionInfo.RecordPackageVersion, this.VersionInfo.GetPackageVersion(), true, bForceDownload, false);
		this.AnalyzePatch(this.MustRevertVersion() ? this.RevertManifest.DiffPatch.RevertMap : this.Manifest.DiffPatch.CurDiffMap, this.VersionInfo.RecordVersion, this.VersionInfo.LatestVersion, false, bForceDownload, this.MustRevertVersion());
		this.PostAnalyzeClear();
		ValueTuple<List<RequireFileInfo>, long, long, long, long, long, long, ValueTuple<long, int>> valueTuple2 = this.AnalyzeSpaceInfo();
		List<RequireFileInfo> item = valueTuple2.Item1;
		long item2 = valueTuple2.Item2;
		long item3 = valueTuple2.Item3;
		long item4 = valueTuple2.Item4;
		long item5 = valueTuple2.Item5;
		long item6 = valueTuple2.Item6;
		long item7 = valueTuple2.Item7;
		long item8 = valueTuple2.Rest.Item1;
		int item9 = valueTuple2.Rest.Item2;
		return new ValueTuple<List<RequireFileInfo>, long, long, long, long, long, long, ValueTuple<long, int>>(item, item2, item3, item4, item5, item6, item7, new ValueTuple<long, int>(item8, item9));
	}

	// Token: 0x0601C9AC RID: 117164 RVA: 0x0089365B File Offset: 0x0089185B
	public virtual bool NeedPatch()
	{
		return this.PatchOpParams.Count > 0;
	}

	// Token: 0x0601C9AD RID: 117165 RVA: 0x0089366C File Offset: 0x0089186C
	public long PatchTotalSize()
	{
		long num = 0L;
		foreach (PatchParams patchParams in this.PatchOpParams)
		{
			num += patchParams.NewRefSize;
		}
		return num;
	}

	// Token: 0x0601C9AE RID: 117166 RVA: 0x008936C8 File Offset: 0x008918C8
	[return: Nullable(new byte[]
	{
		0,
		0,
		1,
		1
	})]
	public UniTask<ValueTuple<bool, EKuroPatchResult, List<LocalFileInfo>>> ExecutePatch(Action<long> cb)
	{
		ResPackageInfo.<ExecutePatch>d__74 <ExecutePatch>d__;
		<ExecutePatch>d__.<>t__builder = AsyncUniTaskMethodBuilder<ValueTuple<bool, EKuroPatchResult, List<LocalFileInfo>>>.Create();
		<ExecutePatch>d__.<>4__this = this;
		<ExecutePatch>d__.cb = cb;
		<ExecutePatch>d__.<>1__state = -1;
		<ExecutePatch>d__.<>t__builder.Start<ResPackageInfo.<ExecutePatch>d__74>(ref <ExecutePatch>d__);
		return <ExecutePatch>d__.<>t__builder.Task;
	}

	// Token: 0x0601C9AF RID: 117167 RVA: 0x00893714 File Offset: 0x00891914
	public bool MoveFiles()
	{
		LauncherLog instance = Singleton<LauncherLog>.Instance;
		string message = "move file after patch.";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("preDownload", this.IsPreDownload);
		instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		foreach (MoveParams moveParams in this.MoveOpParams)
		{
			if (UBlueprintPathsLibrary.FileExists(moveParams.OldFile.FilePath))
			{
				if (!moveParams.OldFile.IsRestartRequiredAfterHotPatchChunk)
				{
					if (moveParams.OldFile.FilePath.EndsWith(EResFile.PAK.ToEnumString()))
					{
						UKuroPakMountStatic.UnmountPak(moveParams.OldFile.FilePath);
					}
					if (!UKuroLauncherLibrary.MoveFile(moveParams.NewFile.FilePath, moveParams.OldFile.FilePath))
					{
						return false;
					}
				}
				else if (!UKuroLauncherLibrary.CopyFile(moveParams.NewFile.FilePath, moveParams.OldFile.FilePath))
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0601C9B0 RID: 117168 RVA: 0x00893820 File Offset: 0x00891A20
	[return: Nullable(new byte[]
	{
		0,
		1,
		1,
		1,
		0,
		1,
		1
	})]
	public virtual ValueTuple<List<string>, List<ValueTuple<string, string, int>>> GetMountInfos()
	{
		List<string> list = new List<string>();
		List<ValueTuple<string, string, int>> list2 = new List<ValueTuple<string, string, int>>();
		foreach (PakFilePair pakFilePair in this.OldPakPairs.Values)
		{
			if (pakFilePair.Pak != null)
			{
				list.Add(pakFilePair.Pak.FilePath);
			}
		}
		foreach (PakFilePair pakFilePair2 in this.LatestPakPairs.Values)
		{
			if (pakFilePair2.Pak != null)
			{
				ValueTuple<string, string, int> item = new ValueTuple<string, string, int>(pakFilePair2.Pak.FilePath, pakFilePair2.Pak.GetHash(), pakFilePair2.MountOrder);
				list2.Add(item);
			}
		}
		return new ValueTuple<List<string>, List<ValueTuple<string, string, int>>>(list, list2);
	}

	// Token: 0x0601C9B1 RID: 117169 RVA: 0x00893918 File Offset: 0x00891B18
	public unsafe void DeleteLocalFiles()
	{
		LauncherLog instance = Singleton<LauncherLog>.Instance;
		string message = "delete lang res.";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("res", this.VersionInfo.GetResType());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("preDownload", this.IsPreDownload);
		instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		string mountManifestPath = ResPackageInfo.PathMisc.GetMountManifestPath(this.VersionInfo.GetPackageVersion(), this.VersionInfo.GetMountFileName());
		if (UBlueprintPathsLibrary.FileExists(mountManifestPath))
		{
			UKuroLauncherLibrary.DeleteFile(mountManifestPath);
		}
		foreach (PakFilePair pakFilePair in this.LatestPakPairs.Values)
		{
			if (pakFilePair.Pak != null)
			{
				UKuroPakMountStatic.UnmountPak(pakFilePair.Pak.FilePath);
				pakFilePair.Pak.DeleteAll();
			}
			if (pakFilePair.Sig != null)
			{
				pakFilePair.Sig.DeleteAll();
			}
		}
		this.ClearRecord();
	}

	// Token: 0x0601C9B2 RID: 117170 RVA: 0x00893A38 File Offset: 0x00891C38
	[NullableContext(0)]
	public unsafe virtual ValueTuple<long, long> CalculateSavedSizeAndTotalSize()
	{
		LauncherLog instance = Singleton<LauncherLog>.Instance;
		string message = "calculate all size of lang res.";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("res", this.VersionInfo.GetResType());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("preDownload", this.IsPreDownload);
		instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (this.LatestPakPairs.Count <= 0)
		{
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "first time to calculate all size of lang res.";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("preDownload", this.IsPreDownload);
			instance2.Info(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (this.Manifest == null)
			{
				string manifestSavePath = this.GetManifestSavePath();
				string inCipher = null;
				if (!UKuroStaticLibrary.LoadFileToString(ref inCipher, manifestSavePath))
				{
					LauncherLog instance3 = Singleton<LauncherLog>.Instance;
					string message3 = "清单文件不存在";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("file", manifestSavePath);
					instance3.Warn(message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return new ValueTuple<long, long>(0L, 1L);
				}
				string text = null;
				if (!UKuroLauncherLibrary.Decrypt(inCipher, ref text))
				{
					LauncherLog instance4 = Singleton<LauncherLog>.Instance;
					string message4 = "清单文件内容无法解析";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("file", manifestSavePath);
					instance4.Warn(message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					return new ValueTuple<long, long>(0L, 1L);
				}
				string text2 = text.Trim();
				if (string.IsNullOrWhiteSpace(text2))
				{
					LauncherLog instance5 = Singleton<LauncherLog>.Instance;
					string message5 = "清单文件内容为空";
					ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("file", manifestSavePath);
					instance5.Warn(message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
					return new ValueTuple<long, long>(0L, 1L);
				}
				this.Manifest = LauncherJson.Parse<PatchManifestJson>(text2, null);
			}
			this.CollectAllFiles();
		}
		long num = 0L;
		long num2 = 0L;
		foreach (PakFilePair pakFilePair in this.LatestPakPairs.Values)
		{
			if (pakFilePair.Pak != null)
			{
				num2 += pakFilePair.Pak.ExpectSize;
				num += pakFilePair.Pak.GetLocalSize();
			}
			if (pakFilePair.Sig != null)
			{
				num2 += pakFilePair.Sig.ExpectSize;
				num += pakFilePair.Sig.GetLocalSize();
			}
		}
		return new ValueTuple<long, long>(num, num2);
	}

	// Token: 0x0601C9B3 RID: 117171 RVA: 0x00893C68 File Offset: 0x00891E68
	public virtual bool IsCompleteUpdate()
	{
		return this.VersionInfo.LatestVersion == this.VersionInfo.RecordVersion;
	}

	// Token: 0x0601C9B4 RID: 117172 RVA: 0x00893C88 File Offset: 0x00891E88
	public virtual bool IsCompleteDownload()
	{
		if (!this.IsCompleteUpdate())
		{
			return false;
		}
		ValueTuple<long, long> valueTuple = this.CalculateSavedSizeAndTotalSize();
		long item = valueTuple.Item1;
		long item2 = valueTuple.Item2;
		return item >= item2;
	}

	// Token: 0x170026E7 RID: 9959
	// (get) Token: 0x0601C9B5 RID: 117173 RVA: 0x00893CB9 File Offset: 0x00891EB9
	public ResVersionInfo ResourceVersionInfo
	{
		get
		{
			return this.VersionInfo;
		}
	}

	// Token: 0x0601C9B6 RID: 117174 RVA: 0x00893CC4 File Offset: 0x00891EC4
	private void PreAnalyzeClear()
	{
		if (!this.IsPreDownload)
		{
			if (this.HasPreAnalyzeClear)
			{
				return;
			}
			if (this.VersionInfo.GetResType() == EResType.Launcher.ToEnumString())
			{
				return;
			}
			if (string.IsNullOrWhiteSpace(this.VersionInfo.RecordVersion))
			{
				return;
			}
			LauncherFileLib.ClearOldPackageResDir(this.VersionInfo.RecordPackageVersion);
			if (LauncherFileLib.HadDeletion)
			{
				this.HadDeletion = true;
			}
			HashSet<string> hashSet = new HashSet<string>();
			hashSet.Add("Base");
			hashSet.Add(this.VersionInfo.RecordVersion);
			hashSet.Add(this.VersionInfo.LatestVersion);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 3);
			defaultInterpolatedStringHandler.AppendFormatted(UKuroLauncherLibrary.GameSavedDir());
			defaultInterpolatedStringHandler.AppendLiteral("Resources/");
			defaultInterpolatedStringHandler.AppendFormatted(this.VersionInfo.GetPackageVersion());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(this.VersionInfo.GetResType());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			LauncherFileLib.ClearResDirs(defaultInterpolatedStringHandler.ToStringAndClear(), hashSet);
			if (LauncherFileLib.HadDeletion)
			{
				this.HadDeletion = true;
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 3);
			defaultInterpolatedStringHandler.AppendFormatted(UKuroLauncherLibrary.GameSavedDir());
			defaultInterpolatedStringHandler.AppendLiteral("Resources/");
			defaultInterpolatedStringHandler.AppendFormatted(this.VersionInfo.GetPackageVersion());
			defaultInterpolatedStringHandler.AppendLiteral("/Diff/");
			defaultInterpolatedStringHandler.AppendFormatted(this.VersionInfo.GetResType());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			LauncherFileLib.ClearResDirs(defaultInterpolatedStringHandler.ToStringAndClear(), hashSet);
			if (LauncherFileLib.HadDeletion)
			{
				this.HadDeletion = true;
			}
			this.HasPreAnalyzeClear = true;
		}
	}

	// Token: 0x0601C9B7 RID: 117175 RVA: 0x00893E60 File Offset: 0x00892060
	private void PostAnalyzeClear()
	{
		if (!this.IsPreDownload)
		{
			foreach (PakFilePair pakFilePair in this.OldPakPairs.Values)
			{
				string text = (pakFilePair.Pak != null) ? pakFilePair.Pak.FilePath : ((pakFilePair.Sig != null) ? pakFilePair.Sig.FilePath : "");
				if (text != null && !(text == ""))
				{
					if (!text.EndsWith(EResFile.PAK.ToEnumString()))
					{
						int num = text.LastIndexOf('.');
						if (num <= 0)
						{
							LauncherLog instance = Singleton<LauncherLog>.Instance;
							string message = "UnmountPak: tmpPath has no extension, fallback to append.";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tmpPath", text);
							instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
							continue;
						}
						text = text.Substring(0, num) + EResFile.PAK.ToEnumString();
					}
					UKuroPakMountStatic.UnmountPak(text);
					if (pakFilePair.Pak != null)
					{
						pakFilePair.Pak.DeleteAll();
					}
					if (pakFilePair.Sig != null)
					{
						pakFilePair.Sig.DeleteAll();
					}
				}
			}
			this.OldPakPairs.Clear();
		}
	}

	// Token: 0x0601C9B8 RID: 117176 RVA: 0x00893F98 File Offset: 0x00892198
	[return: TupleElementNames(new string[]
	{
		"requireFiles",
		"localSavedSize",
		"totalDownloadSize",
		"totalNeedSpace",
		"totalDownloadAndPatch",
		"allResSize",
		"allFileExpectSize",
		"allFileSavedSize",
		"allFileCount",
		null,
		null
	})]
	[return: Nullable(new byte[]
	{
		0,
		1,
		1,
		0
	})]
	private ValueTuple<List<RequireFileInfo>, long, long, long, long, long, long, ValueTuple<long, int>> AnalyzeSpaceInfo()
	{
		List<RequireFileInfo> list = new List<RequireFileInfo>();
		long num = 0L;
		long num2 = 0L;
		long num3 = 0L;
		long num4 = 0L;
		long num5 = 0L;
		long num6 = 0L;
		long num7 = 0L;
		int num8 = 0;
		foreach (PatchParams patchParams in this.PatchOpParams)
		{
			num += patchParams.DiffFile.ExpectSize;
			num2 += patchParams.DiffFile.GetLocalSize();
			num6 += patchParams.DiffFile.ExpectSize;
			num7 += patchParams.DiffFile.GetLocalSize();
			if (!patchParams.DiffFile.IsCompleteFile())
			{
				list.Add(patchParams.DiffFile.GetRequireInfo());
			}
			num8++;
			num4 += patchParams.CopySize;
			long num9 = 0L;
			foreach (LocalFileInfo localFileInfo in patchParams.AllDestFiles.Values)
			{
				num9 += localFileInfo.GetSelfSize();
			}
			long num10 = patchParams.NewRefSize - num9;
			num5 += num10;
			if (num3 < num5)
			{
				num3 = num5;
			}
			num5 -= patchParams.DiffFile.ExpectSize;
			foreach (LocalFileInfo localFileInfo2 in patchParams.OldModify)
			{
				num5 -= localFileInfo2.GetSelfSize();
			}
		}
		foreach (LocalFileInfo localFileInfo3 in this.DownloadList)
		{
			num += localFileInfo3.ExpectSize;
			num2 += localFileInfo3.GetLocalSize();
			list.Add(localFileInfo3.GetRequireInfo());
		}
		long num11;
		if (num5 >= 0L)
		{
			num11 = num4;
		}
		else
		{
			long num12 = num4 + num5;
			num11 = ((num12 >= 0L) ? num12 : 0L);
		}
		long item = num + num3 + num11;
		long item2 = num - num2 + num3 + num11;
		this.SpaceModel.DownloadSize = num;
		this.SpaceModel.SavedSize = num2;
		this.SpaceModel.PatchPeak = num3;
		this.SpaceModel.PatchNetDelta = num5;
		this.SpaceModel.CopySize = num4;
		long num13 = 0L;
		foreach (PakFilePair pakFilePair in this.LatestPakPairs.Values)
		{
			num13 += pakFilePair.Pak.ExpectSize;
			num6 += pakFilePair.Pak.ExpectSize;
			num7 += pakFilePair.Pak.GetLocalSize();
			num8++;
			if (pakFilePair.Sig != null)
			{
				num13 += pakFilePair.Sig.ExpectSize;
				num6 += pakFilePair.Sig.ExpectSize;
				num7 += pakFilePair.Sig.GetLocalSize();
				num8++;
			}
		}
		return new ValueTuple<List<RequireFileInfo>, long, long, long, long, long, long, ValueTuple<long, int>>(list, num2, num, item2, item, num13, num6, new ValueTuple<long, int>(num7, num8));
	}

	// Token: 0x0601C9B9 RID: 117177 RVA: 0x00894338 File Offset: 0x00892538
	private void AddToPakPairs(string key, LocalFileInfo info, Dictionary<string, PakFilePair> pakMap, int order = 0)
	{
		PakFilePair pakFilePair;
		if (!pakMap.TryGetValue(key, out pakFilePair))
		{
			pakFilePair = new PakFilePair();
			pakFilePair.MountOrder = order;
			pakMap[key] = pakFilePair;
		}
		if (info.FilePath.EndsWith(EResFile.PAK.ToEnumString()))
		{
			pakFilePair.Pak = info;
		}
		if (info.FilePath.EndsWith(EResFile.SIG.ToEnumString()))
		{
			pakFilePair.Sig = info;
		}
		if (info.FilePath.EndsWith(EResFile.UTOC.ToEnumString()))
		{
			pakFilePair.Utoc = info;
		}
		if (info.FilePath.EndsWith(EResFile.UCAS.ToEnumString()))
		{
			pakFilePair.Ucas = info;
		}
	}

	// Token: 0x0601C9BA RID: 117178 RVA: 0x008943D0 File Offset: 0x008925D0
	private unsafe string GetNewPakPairKey(string dirName, string fileName)
	{
		int num = fileName.LastIndexOf('.');
		if (num <= 0)
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "GetNewPakPairKey: fileName has no extension, fallback to full name.";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("dirName", dirName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("fileName", fileName);
			instance.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return "";
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
		defaultInterpolatedStringHandler.AppendFormatted(this.VersionInfo.GetResType());
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted(dirName);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted(fileName.Substring(0, num));
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0601C9BB RID: 117179 RVA: 0x00894490 File Offset: 0x00892690
	private void CollectAllFilesByVersion(string dir, string localVerDirName, string ver, List<ResFileInfo> files)
	{
		int order = (localVerDirName == "Base") ? 4 : this.VersionInfo.GetMountOrder();
		foreach (ResFileInfo resFileInfo in files)
		{
			DestFileInfo info = new DestFileInfo(resFileInfo.Name, dir + resFileInfo.Name, resFileInfo.Size, ResPackageInfo.PathMisc.GetResFileRoute(this.ResUri, ver, resFileInfo.Name), resFileInfo.Hash);
			string newPakPairKey = this.GetNewPakPairKey(localVerDirName, resFileInfo.Name);
			this.AddToPakPairs(newPakPairKey, info, this.LatestPakPairs, order);
		}
	}

	// Token: 0x0601C9BC RID: 117180 RVA: 0x00894550 File Offset: 0x00892750
	[return: Nullable(2)]
	private LocalFileInfo GetFileInfoFromNewPakPairs(string dirName, string fileName)
	{
		string newPakPairKey = this.GetNewPakPairKey(dirName, fileName);
		PakFilePair pakFilePair;
		if (this.LatestPakPairs.TryGetValue(newPakPairKey, out pakFilePair))
		{
			if (fileName.EndsWith(EResFile.PAK.ToEnumString()))
			{
				return pakFilePair.Pak;
			}
			if (fileName.EndsWith(EResFile.SIG.ToEnumString()))
			{
				return pakFilePair.Sig;
			}
			if (fileName.EndsWith(EResFile.UTOC.ToEnumString()))
			{
				return pakFilePair.Utoc;
			}
			if (fileName.EndsWith(EResFile.UCAS.ToEnumString()))
			{
				return pakFilePair.Ucas;
			}
		}
		LauncherLog instance = Singleton<LauncherLog>.Instance;
		string message = "manifest miss patch file!";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("file", fileName);
		instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0601C9BD RID: 117181 RVA: 0x008945F0 File Offset: 0x008927F0
	[return: Nullable(2)]
	private LocalFileInfo ToDelOldFile(string fileName, string filePath)
	{
		LocalFileInfo localFileInfo = new LocalFileInfo(fileName, filePath, 0L);
		if (ChunkTool.IsRestartRequiredAfterHotPatchChunk(filePath))
		{
			return localFileInfo;
		}
		if (this.IsPreDownload)
		{
			return localFileInfo;
		}
		int num = fileName.LastIndexOf('.');
		if (num <= 0)
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "ToDelOldFile: fileName has no extension, fallback to full name.";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("fileName", fileName);
			instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		string key = fileName.Substring(0, num);
		this.AddToPakPairs(key, localFileInfo, this.OldPakPairs, 0);
		return localFileInfo;
	}

	// Token: 0x0601C9BE RID: 117182 RVA: 0x00894668 File Offset: 0x00892868
	private void DeleteOldDir(string oldDir, bool isBase)
	{
		if (!isBase)
		{
			TArray<string> files = UKuroStaticLibrary.GetFiles(oldDir, "");
			int num = files.Num();
			for (int i = 0; i < num; i++)
			{
				string text = files.Get(i);
				string filePath = oldDir + text;
				this.ToDelOldFile(text, filePath);
			}
			return;
		}
		if (this.IsPreDownload)
		{
			return;
		}
		if (UBlueprintPathsLibrary.DirectoryExists(oldDir))
		{
			UKuroLauncherLibrary.DeleteDirectory(oldDir);
		}
	}

	// Token: 0x0601C9BF RID: 117183 RVA: 0x008946CC File Offset: 0x008928CC
	private void CollectPakDownloadFiles(PakFilePair pakPair)
	{
		if (pakPair.Pak.GetSelfSize() != pakPair.Pak.ExpectSize)
		{
			pakPair.Pak.DeleteSelf();
			this.DownloadList.Add(pakPair.Pak);
		}
		if (pakPair.Sig != null && pakPair.Sig.GetSelfSize() != pakPair.Sig.ExpectSize)
		{
			pakPair.Sig.DeleteSelf();
			this.DownloadList.Add(pakPair.Sig);
		}
	}

	// Token: 0x0601C9C0 RID: 117184 RVA: 0x0089474C File Offset: 0x0089294C
	private void CollectDownloadFiles(bool isBase)
	{
		if (isBase)
		{
			using (Dictionary<string, PakFilePair>.Enumerator enumerator = this.LatestPakPairs.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, PakFilePair> keyValuePair = enumerator.Current;
					string key = keyValuePair.Key;
					PakFilePair value = keyValuePair.Value;
					if (key.Contains("/Base/"))
					{
						this.CollectPakDownloadFiles(value);
					}
				}
				return;
			}
		}
		foreach (KeyValuePair<string, PakFilePair> keyValuePair2 in this.LatestPakPairs)
		{
			string key2 = keyValuePair2.Key;
			PakFilePair value2 = keyValuePair2.Value;
			if (!key2.Contains("/Base/"))
			{
				this.CollectPakDownloadFiles(value2);
			}
		}
	}

	// Token: 0x0601C9C1 RID: 117185 RVA: 0x0089481C File Offset: 0x00892A1C
	private void ClearDiffAndCollectDownload(PatchInfo patch, string oldDir, string newDir, bool isBase)
	{
		string text = isBase ? this.VersionInfo.GetPackageVersion() : this.VersionInfo.LatestVersion;
		string dirName = isBase ? "Base" : text;
		if (patch.DiffFile != null && patch.DiffFile.Size > 0L)
		{
			LauncherFileLib.RemoveDownloadFile(ResPackageInfo.PathMisc.GetDiffFilePath(this.VersionInfo.GetPackageVersion(), isBase ? "Base" : text, this.VersionInfo.GetResType(), patch.DiffFile.Name));
		}
		foreach (string fileName in patch.NewFiles)
		{
			LocalFileInfo fileInfoFromNewPakPairs = this.GetFileInfoFromNewPakPairs(dirName, fileName);
			if (fileInfoFromNewPakPairs != null && !fileInfoFromNewPakPairs.IsCompleteFile())
			{
				fileInfoFromNewPakPairs.DeleteSelf();
				this.DownloadList.Add(fileInfoFromNewPakPairs);
			}
		}
		foreach (string text2 in patch.ModFiles)
		{
			if (!this.IsPreDownload)
			{
				if (isBase)
				{
					LauncherFileLib.RemoveDownloadFile(oldDir + text2);
				}
				else
				{
					this.ToDelOldFile(text2, oldDir + text2);
				}
			}
			LocalFileInfo fileInfoFromNewPakPairs2 = this.GetFileInfoFromNewPakPairs(dirName, text2);
			if (fileInfoFromNewPakPairs2 != null && !fileInfoFromNewPakPairs2.IsCompleteFile())
			{
				fileInfoFromNewPakPairs2.DeleteSelf();
				this.DownloadList.Add(fileInfoFromNewPakPairs2);
			}
		}
		if (!this.IsPreDownload)
		{
			foreach (string text3 in patch.DelFiles)
			{
				if (isBase)
				{
					LauncherFileLib.RemoveDownloadFile(oldDir + text3);
				}
				else
				{
					this.ToDelOldFile(text3, oldDir + text3);
				}
			}
			foreach (IdenticalPair identicalPair in patch.SameFiles)
			{
				LocalFileInfo fileInfoFromNewPakPairs3 = this.GetFileInfoFromNewPakPairs(dirName, identicalPair.DestFile);
				if (fileInfoFromNewPakPairs3 != null)
				{
					string text4 = oldDir + identicalPair.SrcFile;
					LocalFileInfo localFileInfo = new LocalFileInfo(identicalPair.SrcFile, text4, fileInfoFromNewPakPairs3.ExpectSize);
					if (isBase)
					{
						if (fileInfoFromNewPakPairs3.IsCompleteFile())
						{
							localFileInfo.DeleteAll();
						}
						else if (UBlueprintPathsLibrary.FileExists(text4))
						{
							UKuroLauncherLibrary.MoveFile(newDir + identicalPair.DestFile, text4);
						}
						else if (!fileInfoFromNewPakPairs3.IsCompleteFile())
						{
							fileInfoFromNewPakPairs3.DeleteSelf();
							this.DownloadList.Add(fileInfoFromNewPakPairs3);
						}
					}
					else if (fileInfoFromNewPakPairs3.IsCompleteFile())
					{
						if (!localFileInfo.IsRestartRequiredAfterHotPatchChunk)
						{
							int num = identicalPair.SrcFile.LastIndexOf('.');
							string key;
							if (num <= 0)
							{
								LauncherLog instance = Singleton<LauncherLog>.Instance;
								string message = "AnalyzePatch: SrcFile has no extension, fallback to full name.";
								ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("srcFile", identicalPair.SrcFile);
								instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
								key = identicalPair.SrcFile;
							}
							else
							{
								key = identicalPair.SrcFile.Substring(0, num);
							}
							this.AddToPakPairs(key, localFileInfo, this.OldPakPairs, 0);
						}
					}
					else if (localFileInfo.IsCompleteFile())
					{
						this.MoveOpParams.Add(new MoveParams(localFileInfo, fileInfoFromNewPakPairs3));
					}
					else if (!fileInfoFromNewPakPairs3.IsCompleteFile())
					{
						fileInfoFromNewPakPairs3.DeleteSelf();
						this.DownloadList.Add(fileInfoFromNewPakPairs3);
					}
				}
			}
		}
	}

	// Token: 0x0601C9C2 RID: 117186 RVA: 0x00894BE0 File Offset: 0x00892DE0
	private unsafe void AnalyzePatch(Dictionary<string, List<PatchInfo>> remotePatchMap, string oldVersion, string latestVersion, bool bIsBase, bool bForceDownload = false, bool bRevert = false)
	{
		bool flag = oldVersion == latestVersion;
		LauncherLog instance = Singleton<LauncherLog>.Instance;
		string message = "begin analyze and print the info";
		<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("bIsBase", bIsBase);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("oldVersion", oldVersion);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("latestVersion", latestVersion);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("isSameVer", flag);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("bForceDownload", bForceDownload);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("bIsPreDownload", this.IsPreDownload);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("map", remotePatchMap);
		instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
		if (flag)
		{
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "collect all files if local is miss";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("res", this.VersionInfo.GetResType());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("preDownload", this.IsPreDownload);
			instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			this.CollectDownloadFiles(bIsBase);
			return;
		}
		string resFileDir = ResPackageInfo.PathMisc.GetResFileDir(this.VersionInfo.GetPackageVersion(), bIsBase ? "Base" : latestVersion, this.VersionInfo.GetResType());
		string resFileDir2 = ResPackageInfo.PathMisc.GetResFileDir(bIsBase ? oldVersion : this.VersionInfo.GetPackageVersion(), bIsBase ? "Base" : oldVersion, this.VersionInfo.GetResType());
		List<PatchInfo> list;
		if (!remotePatchMap.TryGetValue(oldVersion, out list))
		{
			list = new List<PatchInfo>();
		}
		bool flag2 = list.Count <= 0 || bForceDownload;
		LauncherLog instance3 = Singleton<LauncherLog>.Instance;
		string message3 = "1st. use bin patch or not?";
		<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray5<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("useDiff", !flag2);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("diffCount", list.Count);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("forceDownload", bForceDownload);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("res", this.VersionInfo.GetResType());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 4) = new ValueTuple<string, object>("preDownload", this.IsPreDownload);
		instance3.Info(message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 5));
		if (!flag2)
		{
			foreach (PatchInfo patchInfo in list)
			{
				bool group = patchInfo.Group;
				if (patchInfo.Group)
				{
					int num = 0;
					Dictionary<string, LocalFileInfo> dictionary = new Dictionary<string, LocalFileInfo>();
					List<LocalFileInfo> list2 = new List<LocalFileInfo>();
					if (UBlueprintPathsLibrary.DirectoryExists(resFileDir2))
					{
						foreach (string text in patchInfo.ModFiles)
						{
							LocalFileInfo fileInfoFromNewPakPairs = this.GetFileInfoFromNewPakPairs(bIsBase ? "Base" : latestVersion, text);
							if (fileInfoFromNewPakPairs != null)
							{
								dictionary[text] = fileInfoFromNewPakPairs;
								string filePath = resFileDir2 + text;
								LocalFileInfo localFileInfo = new LocalFileInfo(text, filePath, 0L);
								if (localFileInfo.IsCompleteFile())
								{
									num++;
									if (!localFileInfo.IsRestartRequiredAfterHotPatchChunk)
									{
										list2.Add(localFileInfo);
									}
								}
							}
						}
					}
					bool flag3 = num > 0;
					LauncherLog instance4 = Singleton<LauncherLog>.Instance;
					string message4 = "2nd. use bin patch or not in each group?";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("useDiff", flag3);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("group", patchInfo.GroupName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("res", this.VersionInfo.GetResType());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3) = new ValueTuple<string, object>("preDownload", this.IsPreDownload);
					instance4.Info(message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 4));
					if (!flag3)
					{
						LauncherLog instance5 = Singleton<LauncherLog>.Instance;
						string message5 = "cant use diff, clear diff and collect miss files.";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("res", this.VersionInfo.GetResType());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("preDownload", this.IsPreDownload);
						instance5.Info(message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 2));
						this.ClearDiffAndCollectDownload(patchInfo, resFileDir2, resFileDir, bIsBase);
					}
					else
					{
						foreach (string text2 in patchInfo.NewFiles)
						{
							LocalFileInfo fileInfoFromNewPakPairs2 = this.GetFileInfoFromNewPakPairs(bIsBase ? "Base" : latestVersion, text2);
							if (fileInfoFromNewPakPairs2 != null)
							{
								dictionary[text2] = fileInfoFromNewPakPairs2;
							}
						}
						long num2 = 0L;
						if (!this.IsPreDownload)
						{
							foreach (string text3 in patchInfo.DelFiles)
							{
								string filePath2 = resFileDir2 + text3;
								this.ToDelOldFile(text3, filePath2);
							}
							foreach (IdenticalPair identicalPair in patchInfo.SameFiles)
							{
								LocalFileInfo fileInfoFromNewPakPairs3 = this.GetFileInfoFromNewPakPairs(bIsBase ? "Base" : latestVersion, identicalPair.DestFile);
								if (fileInfoFromNewPakPairs3 != null)
								{
									string text4 = resFileDir2 + identicalPair.SrcFile;
									LocalFileInfo localFileInfo2 = new LocalFileInfo(identicalPair.SrcFile, text4, fileInfoFromNewPakPairs3.ExpectSize);
									if (fileInfoFromNewPakPairs3.IsCompleteFile())
									{
										localFileInfo2.DeleteAll();
									}
									else if (localFileInfo2.IsCompleteFile())
									{
										this.MoveOpParams.Add(new MoveParams(localFileInfo2, fileInfoFromNewPakPairs3));
										if (ChunkTool.IsRestartRequiredAfterHotPatchChunk(text4))
										{
											num2 += fileInfoFromNewPakPairs3.ExpectSize;
										}
									}
									else
									{
										localFileInfo2.DeleteAll();
										fileInfoFromNewPakPairs3.DeleteSelf();
										this.DownloadList.Add(fileInfoFromNewPakPairs3);
									}
								}
							}
						}
						if (patchInfo.DiffFile != null && patchInfo.DiffFile.Size > 0L)
						{
							string diffFilePath = ResPackageInfo.PathMisc.GetDiffFilePath(this.VersionInfo.GetPackageVersion(), bIsBase ? "Base" : latestVersion, this.VersionInfo.GetResType(), patchInfo.DiffFile.Name);
							string resFileRoute = ResPackageInfo.PathMisc.GetResFileRoute(this.ResUri, bRevert ? oldVersion : latestVersion, patchInfo.DiffFile.Name);
							DestFileInfo destFileInfo = new DestFileInfo(patchInfo.DiffFile.Name, diffFilePath, patchInfo.DiffFile.Size, resFileRoute, patchInfo.DiffFile.Hash);
							long num3 = 0L;
							List<LocalFileInfo> list3 = new List<LocalFileInfo>();
							foreach (LocalFileInfo localFileInfo3 in dictionary.Values)
							{
								if (!localFileInfo3.IsCompleteFile())
								{
									num3 += localFileInfo3.ExpectSize;
									list3.Add(localFileInfo3);
								}
							}
							if (!destFileInfo.IsCompleteFile() && num3 <= patchInfo.DiffFile.Size)
							{
								foreach (LocalFileInfo item in list3)
								{
									this.DownloadList.Add(item);
								}
								if (this.IsPreDownload)
								{
									continue;
								}
								using (List<LocalFileInfo>.Enumerator enumerator5 = list2.GetEnumerator())
								{
									while (enumerator5.MoveNext())
									{
										LocalFileInfo localFileInfo4 = enumerator5.Current;
										if (!localFileInfo4.IsRestartRequiredAfterHotPatchChunk && UBlueprintPathsLibrary.FileExists(localFileInfo4.FilePath))
										{
											UKuroLauncherLibrary.DeleteFile(localFileInfo4.FilePath);
										}
									}
									continue;
								}
							}
							this.PatchOpParams.Add(new PatchParams(destFileInfo, resFileDir2, resFileDir, list2, dictionary, num2, patchInfo.NewRefSize));
						}
						else
						{
							foreach (LocalFileInfo item2 in dictionary.Values)
							{
								this.DownloadList.Add(item2);
							}
						}
					}
				}
			}
			return;
		}
		if (list.Count <= 0)
		{
			LauncherLog instance6 = Singleton<LauncherLog>.Instance;
			string message6 = "there is no diff info at remote. clear old dir and collect all new files.";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray6 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 0) = new ValueTuple<string, object>("res", this.VersionInfo.GetResType());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 1) = new ValueTuple<string, object>("preDownload", this.IsPreDownload);
			instance6.Info(message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray6, 2));
			this.DeleteOldDir(resFileDir2, bIsBase);
			this.CollectDownloadFiles(bIsBase);
			return;
		}
		LauncherLog instance7 = Singleton<LauncherLog>.Instance;
		string message7 = "force download, clear diff and collect miss files.";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray7 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray7, 0) = new ValueTuple<string, object>("res", this.VersionInfo.GetResType());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray7, 1) = new ValueTuple<string, object>("preDownload", this.IsPreDownload);
		instance7.Info(message7, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray7, 2));
		foreach (PatchInfo patch in list)
		{
			this.ClearDiffAndCollectDownload(patch, resFileDir2, resFileDir, bIsBase);
		}
	}

	// Token: 0x0601C9C3 RID: 117187 RVA: 0x00895664 File Offset: 0x00893864
	private void ResetCache()
	{
		this.LatestVersion = this.VersionInfo.LatestVersion;
		this.ManifestRoute = "";
		this.ManifestSavePath = "";
	}

	// Token: 0x0400E652 RID: 58962
	private static AppPathMisc PathMisc;

	// Token: 0x0400E653 RID: 58963
	private static ResPackageInfo Launcher;

	// Token: 0x0400E654 RID: 58964
	private static ResPackageInfo Resource;

	// Token: 0x0400E655 RID: 58965
	private static Dictionary<string, ResPackageInfo> Languages;

	// Token: 0x0400E656 RID: 58966
	private static Dictionary<string, ResPackageInfo> OptionalDownLoad;

	// Token: 0x0400E657 RID: 58967
	[Nullable(2)]
	private static ResPackageInfo AggregatedManifest;

	// Token: 0x0400E658 RID: 58968
	private static Dictionary<string, ResPackageInfo> RoleVoices;

	// Token: 0x0400E659 RID: 58969
	private string LatestVersion = "";

	// Token: 0x0400E65A RID: 58970
	private string ManifestRoute = "";

	// Token: 0x0400E65B RID: 58971
	private string ManifestSavePath = "";

	// Token: 0x0400E65C RID: 58972
	private PatchManifestJson Manifest;

	// Token: 0x0400E65D RID: 58973
	private PatchManifestJson RevertManifest;

	// Token: 0x0400E65E RID: 58974
	private bool NeedReboot;

	// Token: 0x0400E65F RID: 58975
	public bool HadDeletion;

	// Token: 0x0400E660 RID: 58976
	private readonly bool HotFixOrRepair;

	// Token: 0x0400E661 RID: 58977
	private readonly List<LocalFileInfo> DownloadList = new List<LocalFileInfo>();

	// Token: 0x0400E662 RID: 58978
	private readonly Dictionary<string, PakFilePair> LatestPakPairs = new Dictionary<string, PakFilePair>();

	// Token: 0x0400E663 RID: 58979
	private readonly Dictionary<string, PakFilePair> OldPakPairs = new Dictionary<string, PakFilePair>();

	// Token: 0x0400E664 RID: 58980
	private readonly List<PatchParams> PatchOpParams = new List<PatchParams>();

	// Token: 0x0400E665 RID: 58981
	private readonly List<MoveParams> MoveOpParams = new List<MoveParams>();

	// Token: 0x0400E666 RID: 58982
	private bool HasPreAnalyzeClear;

	// Token: 0x0400E667 RID: 58983
	public readonly PackageSpaceModel SpaceModel = new PackageSpaceModel();

	// Token: 0x0400E668 RID: 58984
	private readonly string ResUri;

	// Token: 0x0400E669 RID: 58985
	private readonly ResVersionInfo VersionInfo;

	// Token: 0x0400E66A RID: 58986
	private readonly bool IsPreDownload;
}
