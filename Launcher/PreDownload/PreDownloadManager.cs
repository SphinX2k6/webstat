using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.DiffPatch.Data;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Download;
using CSharpScript.Launcher.Util;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.PreDownload
{
	// Token: 0x02004543 RID: 17731
	[NullableContext(1)]
	[Nullable(0)]
	public class PreDownloadManager : IPreDownload, IStaticVariableResetter
	{
		// Token: 0x0602EAB7 RID: 191159 RVA: 0x00B0EC78 File Offset: 0x00B0CE78
		static PreDownloadManager()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(PreDownloadManager.CreateStaticDefaultValue), new Action(PreDownloadManager.ResetStaticDefaultValue));
		}

		// Token: 0x0602EAB8 RID: 191160 RVA: 0x00B0EC97 File Offset: 0x00B0CE97
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0602EAB9 RID: 191161 RVA: 0x00B0EC99 File Offset: 0x00B0CE99
		public static void ResetStaticDefaultValue()
		{
			PreDownloadManager.PreDownload = null;
		}

		// Token: 0x0602EABA RID: 191162 RVA: 0x00B0ECA4 File Offset: 0x00B0CEA4
		public static IPreDownload Get()
		{
			if (PreDownloadManager.PreDownload == null)
			{
				string text = KuroApplication.IniPlatformNameIncludeEditor();
				if (text == "Android" || text == "IOS" || text == "OpenHarmony")
				{
					(PreDownloadManager.PreDownload = new PreDownloadManager()).Init(text).Forget();
				}
				else
				{
					PreDownloadManager.PreDownload = new NullPreDownload();
				}
			}
			return PreDownloadManager.PreDownload;
		}

		// Token: 0x0602EABB RID: 191163 RVA: 0x00B0ED0C File Offset: 0x00B0CF0C
		private PreDownloadManager()
		{
		}

		// Token: 0x0602EABC RID: 191164 RVA: 0x00B0ED40 File Offset: 0x00B0CF40
		public static string getLocalText([Nullable(2)] string textTableId, params string[] args)
		{
			if (string.IsNullOrEmpty(textTableId))
			{
				return string.Empty;
			}
			string hotPatchText = Singleton<LauncherConfigLib>.Instance.GetHotPatchText(textTableId);
			if (hotPatchText == null)
			{
				return string.Empty;
			}
			string text = hotPatchText;
			for (int i = 0; i < args.Length; i++)
			{
				string newValue = args[i];
				string oldValue = "{" + i.ToString() + "}";
				text = text.Replace(oldValue, newValue);
			}
			return text;
		}

		// Token: 0x0602EABD RID: 191165 RVA: 0x00B0EDA8 File Offset: 0x00B0CFA8
		protected UniTask Init(string platform)
		{
			PreDownloadManager.<Init>d__22 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.platform = platform;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<PreDownloadManager.<Init>d__22>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0602EABE RID: 191166 RVA: 0x00B0EDF4 File Offset: 0x00B0CFF4
		public void CheckEnabledWithTick()
		{
			Singleton<LauncherLog>.Instance.Info("PreDownloadManager add tick to check preDownload config", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (!this.IsPreDownloadEnabled())
			{
				this.AddTick();
			}
		}

		// Token: 0x0602EABF RID: 191167 RVA: 0x00B0EE27 File Offset: 0x00B0D027
		public void TryRemoveTick()
		{
			this.RemoveTick();
		}

		// Token: 0x0602EAC0 RID: 191168 RVA: 0x00B0EE30 File Offset: 0x00B0D030
		protected void AddTick()
		{
			if (this.TickMgr != null && this.TickMgr.IsValid())
			{
				return;
			}
			if (Launch.LaunchGameInstance == null || !Launch.LaunchGameInstance.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.HotPatch, ELogAuthor.LRX, "PreDownaloadManager AddTick ->Launch game instance is not valid", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.TickMgr = new UKuroTickManager(Launch.LaunchGameInstance, null, EObjectFlags.RF_NoFlags);
			this.TickDelegate = new Action<float>(this.<AddTick>g__TickCallback|25_0);
			this.Interval = 0f;
			this.TickMgr.AddTick(ETickingGroup.TG_PrePhysics, global::DelegateUtils.ToManualReleaseDelegate<FTickHandler>(this.TickDelegate), 0);
		}

		// Token: 0x0602EAC1 RID: 191169 RVA: 0x00B0EECC File Offset: 0x00B0D0CC
		protected void RemoveTick()
		{
			if (this.TickDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(this.TickDelegate);
				this.TickDelegate = null;
			}
			if (this.TickMgr != null)
			{
				this.TickMgr.RemoveTick(ETickingGroup.TG_PrePhysics);
				this.TickMgr = null;
			}
			this.Interval = 0f;
		}

		// Token: 0x0602EAC2 RID: 191170 RVA: 0x00B0EF1C File Offset: 0x00B0D11C
		protected UniTask Tick(float deltaSeconds)
		{
			PreDownloadManager.<Tick>d__27 <Tick>d__;
			<Tick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Tick>d__.<>4__this = this;
			<Tick>d__.deltaSeconds = deltaSeconds;
			<Tick>d__.<>1__state = -1;
			<Tick>d__.<>t__builder.Start<PreDownloadManager.<Tick>d__27>(ref <Tick>d__);
			return <Tick>d__.<>t__builder.Task;
		}

		// Token: 0x0602EAC3 RID: 191171 RVA: 0x00B0EF68 File Offset: 0x00B0D168
		protected UniTask CheckPreDownloadConfig()
		{
			PreDownloadManager.<CheckPreDownloadConfig>d__28 <CheckPreDownloadConfig>d__;
			<CheckPreDownloadConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckPreDownloadConfig>d__.<>4__this = this;
			<CheckPreDownloadConfig>d__.<>1__state = -1;
			<CheckPreDownloadConfig>d__.<>t__builder.Start<PreDownloadManager.<CheckPreDownloadConfig>d__28>(ref <CheckPreDownloadConfig>d__);
			return <CheckPreDownloadConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0602EAC4 RID: 191172 RVA: 0x00B0EFAB File Offset: 0x00B0D1AB
		public void AddEnabledEvent(Action cb)
		{
			if (this.HasPreDownloadConfig())
			{
				cb();
				return;
			}
			if (cb != null)
			{
				this.EnabledCbSet.Add(cb);
			}
		}

		// Token: 0x0602EAC5 RID: 191173 RVA: 0x00B0EFCC File Offset: 0x00B0D1CC
		public void RemoveEnabledEvent(Action cb)
		{
			if (cb != null)
			{
				this.EnabledCbSet.Remove(cb);
			}
		}

		// Token: 0x0602EAC6 RID: 191174 RVA: 0x00B0EFDE File Offset: 0x00B0D1DE
		public void AddCompleteEvent(Action cb)
		{
			if (cb != null)
			{
				this.CompleteCbSet.Add(cb);
			}
		}

		// Token: 0x0602EAC7 RID: 191175 RVA: 0x00B0EFF0 File Offset: 0x00B0D1F0
		public void RemoveCompleteEvent(Action cb)
		{
			if (cb != null)
			{
				this.CompleteCbSet.Remove(cb);
			}
		}

		// Token: 0x0602EAC8 RID: 191176 RVA: 0x00B0F002 File Offset: 0x00B0D202
		private bool HasPreDownloadConfig()
		{
			return this.Config != null;
		}

		// Token: 0x0602EAC9 RID: 191177 RVA: 0x00B0F00D File Offset: 0x00B0D20D
		public bool IsPreDownloadEnabled()
		{
			return this.HasPreDownloadConfig() && this.CheckedRes;
		}

		// Token: 0x0602EACA RID: 191178 RVA: 0x00B0F01F File Offset: 0x00B0D21F
		public void SetView(IPreDownloadUiEvent ui)
		{
			if (this.UiAgent != null)
			{
				this.UiAgent.SetView(ui);
			}
		}

		// Token: 0x0602EACB RID: 191179 RVA: 0x00B0F035 File Offset: 0x00B0D235
		public void ClearView()
		{
			if (this.UiAgent != null)
			{
				this.UiAgent.ClearView();
			}
		}

		// Token: 0x0602EACC RID: 191180 RVA: 0x00B0F04C File Offset: 0x00B0D24C
		protected UniTask GetPreDownloadVersionCfg()
		{
			PreDownloadManager.<GetPreDownloadVersionCfg>d__37 <GetPreDownloadVersionCfg>d__;
			<GetPreDownloadVersionCfg>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<GetPreDownloadVersionCfg>d__.<>4__this = this;
			<GetPreDownloadVersionCfg>d__.<>1__state = -1;
			<GetPreDownloadVersionCfg>d__.<>t__builder.Start<PreDownloadManager.<GetPreDownloadVersionCfg>d__37>(ref <GetPreDownloadVersionCfg>d__);
			return <GetPreDownloadVersionCfg>d__.<>t__builder.Task;
		}

		// Token: 0x0602EACD RID: 191181 RVA: 0x00B0F090 File Offset: 0x00B0D290
		protected unsafe void InitPreDownloadVersion()
		{
			if (Singleton<RemoteInfo>.Instance.PreVerConfig == null)
			{
				Singleton<LauncherLog>.Instance.Error("pre download version is not exist", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Singleton<LauncherLog>.Instance.Info("init pre download version config", default(ReadOnlySpan<ValueTuple<string, object>>));
			List<ResPackageInfo> list = new List<ResPackageInfo>();
			string packageVersion = Singleton<RemoteInfo>.Instance.PreVerConfig.PackageVersion;
			string appVersion = UKuroLauncherLibrary.GetAppVersion();
			ValueTuple<bool, VersionInfo> valueTuple = VersionInfo.TryParse(packageVersion);
			bool item = valueTuple.Item1;
			VersionInfo item2 = valueTuple.Item2;
			ValueTuple<bool, VersionInfo> valueTuple2 = VersionInfo.TryParse(appVersion);
			bool item3 = valueTuple2.Item1;
			VersionInfo item4 = valueTuple2.Item2;
			if (!item || !item3)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "app version is invalid";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("appVer", appVersion);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("nextAppVersion", packageVersion);
				instance.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			if (VersionInfo.LessThanOrEqual(item2, item4))
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "next app version is invalid";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("appVer", appVersion);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("nextAppVersion", packageVersion);
				instance2.Error(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return;
			}
			VersionItem versionItem;
			if (!Singleton<RemoteInfo>.Instance.PreVerConfig.ResVersions.TryGetValue("resource", out versionItem))
			{
				throw new Exception("预下载远程版本配置中，没有resource的信息");
			}
			string mixUri = this.Config.MixUri;
			ResPackageInfo item5 = new ResPackageInfo(mixUri, new ResourceVersionInfo(packageVersion, packageVersion, versionItem.IndexSha1), true);
			list.Add(item5);
			HashSet<string> hashSet = new HashSet<string>();
			IReadOnlyList<LaunchLangDefine> allLanguageDefines = Singleton<LauncherLanguageLib>.Instance.GetAllLanguageDefines();
			for (int i = 0; i < allLanguageDefines.Count; i++)
			{
				LaunchLangDefine launchLangDefine = allLanguageDefines[i];
				if (!hashSet.Contains(launchLangDefine.AudioCode))
				{
					VersionItem versionItem2;
					if (!Singleton<RemoteInfo>.Instance.PreVerConfig.ResVersions.TryGetValue(launchLangDefine.AudioCode, out versionItem2))
					{
						throw new Exception("预下载远程版本配置中，没有多语言" + launchLangDefine.AudioCode + "的信息");
					}
					ResPackageInfo item6 = new ResPackageInfo(mixUri, new LanguageVersionInfo(packageVersion, packageVersion, versionItem2.IndexSha1, launchLangDefine.AudioCode), true);
					hashSet.Add(launchLangDefine.AudioCode);
					list.Add(item6);
				}
			}
			foreach (KeyValuePair<string, VersionItem> keyValuePair in Singleton<RemoteInfo>.Instance.PreVerConfig.ResVersions)
			{
				string key = keyValuePair.Key;
				VersionItem value = keyValuePair.Value;
				if (key.StartsWith("Option_"))
				{
					string text = key.Replace("Option_", "");
					ResPackageInfo item7 = new ResPackageInfo(mixUri, new OptionalDownloadVersionInfo(packageVersion, packageVersion, value.IndexSha1, text), true);
					LauncherLog instance3 = Singleton<LauncherLog>.Instance;
					string message3 = "add optional download pre download ver info";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("packName", text);
					instance3.Info(message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					list.Add(item7);
				}
			}
			UrlPrefixDownload downloader = new UrlPrefixDownload();
			UpdateReportEvent reportEvent = new UpdateReportEvent("PreDownload");
			this.UiAgent = new PreDownloadUiEvent();
			this.DiffUpdater = new DiffUpdate(list, downloader, this.UiAgent, reportEvent, false, EUpdateType.PreDownload);
			ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>> valueTuple4 = Singleton<VideoPreDownload>.Instance.AnalyzePreDownloadRequireFiles();
			List<LocalFileInfo> item8 = valueTuple4.Item1;
			List<RequireFileInfo> item9 = valueTuple4.Item2;
			this.DiffUpdater.RegisterExtraRequireFiles(item8, item9);
		}

		// Token: 0x0602EACE RID: 191182 RVA: 0x00B0F40C File Offset: 0x00B0D60C
		protected UniTask CheckResource()
		{
			PreDownloadManager.<CheckResource>d__39 <CheckResource>d__;
			<CheckResource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckResource>d__.<>4__this = this;
			<CheckResource>d__.<>1__state = -1;
			<CheckResource>d__.<>t__builder.Start<PreDownloadManager.<CheckResource>d__39>(ref <CheckResource>d__);
			return <CheckResource>d__.<>t__builder.Task;
		}

		// Token: 0x0602EACF RID: 191183 RVA: 0x00B0F450 File Offset: 0x00B0D650
		protected UniTask DownloadPreResources()
		{
			PreDownloadManager.<DownloadPreResources>d__40 <DownloadPreResources>d__;
			<DownloadPreResources>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DownloadPreResources>d__.<>4__this = this;
			<DownloadPreResources>d__.<>1__state = -1;
			<DownloadPreResources>d__.<>t__builder.Start<PreDownloadManager.<DownloadPreResources>d__40>(ref <DownloadPreResources>d__);
			return <DownloadPreResources>d__.<>t__builder.Task;
		}

		// Token: 0x0602EAD0 RID: 191184 RVA: 0x00B0F493 File Offset: 0x00B0D693
		public long GetDownloadSize()
		{
			return this.TotalDownSize;
		}

		// Token: 0x0602EAD1 RID: 191185 RVA: 0x00B0F49B File Offset: 0x00B0D69B
		public long GetNeedSpace()
		{
			return this.NeedSpace;
		}

		// Token: 0x0602EAD2 RID: 191186 RVA: 0x00B0F4A4 File Offset: 0x00B0D6A4
		public void Start(EPreDownloadMode mode)
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "start pre download.";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("mode", mode);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.DownloadPreResources().Forget();
		}

		// Token: 0x0602EAD3 RID: 191187 RVA: 0x00B0F4E4 File Offset: 0x00B0D6E4
		public void Stop()
		{
			if (this.PreDownloadState == EPreDownloadState.Patching)
			{
				Singleton<LauncherLog>.Instance.Info("doing patch now.", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Singleton<LauncherLog>.Instance.Info("stop pre download.", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (this.DiffUpdater != null)
			{
				this.DiffUpdater.Stop();
			}
			this.PreDownloadState = EPreDownloadState.Stopped;
		}

		// Token: 0x0602EAD4 RID: 191188 RVA: 0x00B0F548 File Offset: 0x00B0D748
		public void Resume()
		{
			if (this.PreDownloadState == EPreDownloadState.Patching)
			{
				Singleton<LauncherLog>.Instance.Info("still doing patch now.", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Singleton<LauncherLog>.Instance.Info("resume pre download.", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (this.DiffUpdater != null)
			{
				this.DiffUpdater.Resume();
			}
			this.DownloadPreResources().Forget();
		}

		// Token: 0x0602EAD5 RID: 191189 RVA: 0x00B0F5AD File Offset: 0x00B0D7AD
		public bool IsDownloading()
		{
			return this.PreDownloadState == EPreDownloadState.Downloading;
		}

		// Token: 0x0602EAD6 RID: 191190 RVA: 0x00B0F5B8 File Offset: 0x00B0D7B8
		public bool IsComplete()
		{
			return this.PreDownloadState == EPreDownloadState.Finished;
		}

		// Token: 0x0602EAD7 RID: 191191 RVA: 0x00B0F5C3 File Offset: 0x00B0D7C3
		public EPreDownloadState GetState()
		{
			return this.PreDownloadState;
		}

		// Token: 0x0602EAD8 RID: 191192 RVA: 0x00B0F5CB File Offset: 0x00B0D7CB
		[CompilerGenerated]
		private void <AddTick>g__TickCallback|25_0(float deltaSeconds)
		{
			this.Tick(deltaSeconds).Forget();
		}

		// Token: 0x0401A812 RID: 108562
		private const int TICK_INTERVAL_S = 600;

		// Token: 0x0401A813 RID: 108563
		[Nullable(2)]
		private static IPreDownload PreDownload;

		// Token: 0x0401A814 RID: 108564
		private string Platform = "";

		// Token: 0x0401A815 RID: 108565
		private EPreDownloadState PreDownloadState;

		// Token: 0x0401A816 RID: 108566
		[Nullable(2)]
		private PreDownloadConfig Config;

		// Token: 0x0401A817 RID: 108567
		private readonly HashSet<Action> EnabledCbSet = new HashSet<Action>();

		// Token: 0x0401A818 RID: 108568
		private readonly HashSet<Action> CompleteCbSet = new HashSet<Action>();

		// Token: 0x0401A819 RID: 108569
		[Nullable(2)]
		private UKuroTickManager TickMgr;

		// Token: 0x0401A81A RID: 108570
		[Nullable(2)]
		private Action<float> TickDelegate;

		// Token: 0x0401A81B RID: 108571
		private float Interval;

		// Token: 0x0401A81C RID: 108572
		[Nullable(2)]
		private PreDownloadUiEvent UiAgent;

		// Token: 0x0401A81D RID: 108573
		private bool CheckedRes;

		// Token: 0x0401A81E RID: 108574
		[Nullable(2)]
		private DiffUpdate DiffUpdater;

		// Token: 0x0401A81F RID: 108575
		private List<RequireFileInfo> RequireFiles = new List<RequireFileInfo>();

		// Token: 0x0401A820 RID: 108576
		private long TotalDownSize;

		// Token: 0x0401A821 RID: 108577
		private long NeedSpace;
	}
}
