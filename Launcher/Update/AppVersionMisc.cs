using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.Util;
using UnrealEngine;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044BC RID: 17596
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class AppVersionMisc
	{
		// Token: 0x0602E709 RID: 190217 RVA: 0x00AFE244 File Offset: 0x00AFC444
		public void Init(UObject worldContext)
		{
			this.PackageVersion = UKuroLauncherLibrary.GetAppVersion();
			this.SetVersions(Singleton<LauncherStorageLib>.Instance.GetDeviceSavedString(this.GetUpdateVersionKey(), this.PackageVersion), Singleton<LauncherStorageLib>.Instance.GetDeviceSavedString(this.GetSaveUpdateVersionKey(), this.PackageVersion), this.GetRemoteVersion(), this.GetRemoteSha1Map());
			List<string> list = new List<string>();
			foreach (string text in this.LocalSaveResourceVersions)
			{
				if (!(text == this.PackageVersion) || this.BasePackageNeedDownloadRes)
				{
					list.Add(text);
				}
			}
			if (this.LocalSaveResourceVersion != this.LatestVersion && this.LatestVersion != this.PackageVersion)
			{
				list.Add(this.LatestVersion);
			}
			this.UpdateVersionNodes = list;
			this.UpdatePreVersionNodes = new List<string>();
			if (this.LatestVersion == this.PackageVersion && this.BasePackageNeedDownloadRes)
			{
				this.UpdatePreVersionNodes.Add(this.PackageVersion);
			}
			if (this.LatestVersion != this.PackageVersion)
			{
				this.UpdatePreVersionNodes.Add(this.PackageVersion);
			}
			for (int i = 0; i < this.UpdateVersionNodes.Count - 1; i++)
			{
				string item = this.UpdateVersionNodes[i];
				this.UpdatePreVersionNodes.Add(item);
			}
		}

		// Token: 0x0602E70A RID: 190218 RVA: 0x00AFE3C4 File Offset: 0x00AFC5C4
		protected unsafe void SetVersions(string resVersion, string resSaveVersion, string latestVersion, Dictionary<string, string> sha1Map)
		{
			List<string> list = new List<string>(resVersion.Split(',', StringSplitOptions.None));
			string text = list[list.Count - 1];
			List<string> list2 = new List<string>(resSaveVersion.Split(',', StringSplitOptions.None));
			string text2 = list2[list2.Count - 1];
			if (string.IsNullOrEmpty(latestVersion))
			{
				Singleton<LauncherLog>.Instance.Warn("远程版本号为空，使用包体版本号做为线上最新版本号", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.LocalResourceVersions = list;
				this.LocalResourceVersion = text;
				this.LocalSaveResourceVersions = list2;
				this.LocalSaveResourceVersion = text2;
				this.LatestVersion = this.PackageVersion;
				this.HasUpdatedResource = true;
				return;
			}
			this.LatestVersion = latestVersion;
			ValueTuple<bool, VersionInfo> valueTuple = VersionInfo.TryParse(latestVersion);
			bool item = valueTuple.Item1;
			VersionInfo item2 = valueTuple.Item2;
			ValueTuple<bool, VersionInfo> valueTuple2 = VersionInfo.TryParse(text);
			bool item3 = valueTuple2.Item1;
			VersionInfo item4 = valueTuple2.Item2;
			ValueTuple<bool, VersionInfo> valueTuple3 = VersionInfo.TryParse(text2);
			bool item5 = valueTuple3.Item1;
			VersionInfo item6 = valueTuple3.Item2;
			if (!item || item2 == null || !item3 || item4 == null || !item5 || item6 == null)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "转版本号失败";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", this.GetResType());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("latestVer", latestVersion);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("localVer", text);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("localSaveVer", text2);
				instance.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				throw new Exception("转版本号失败");
			}
			bool flag = false;
			bool flag2 = false;
			this.NeedRevertVersion = false;
			if (!VersionInfo.PackageEquals(item2, item4))
			{
				text = this.PackageVersion;
				list = new List<string>
				{
					text
				};
				flag = true;
			}
			else if (item2.Patch < item4.Patch)
			{
				this.NeedRevertVersion = true;
				for (int i = item2.Patch + 1; i <= item4.Patch; i++)
				{
					HashSet<string> revertVersions = this.RevertVersions;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
					defaultInterpolatedStringHandler.AppendFormatted<int>(item2.Major);
					defaultInterpolatedStringHandler.AppendLiteral(".");
					defaultInterpolatedStringHandler.AppendFormatted<int>(item2.Minor);
					defaultInterpolatedStringHandler.AppendLiteral(".");
					defaultInterpolatedStringHandler.AppendFormatted<int>(i);
					revertVersions.Add(defaultInterpolatedStringHandler.ToStringAndClear());
				}
			}
			if (!VersionInfo.PackageEquals(item2, item4))
			{
				text2 = this.PackageVersion;
				list2 = new List<string>
				{
					text2
				};
				flag2 = true;
			}
			else if (item2.Patch < item6.Patch)
			{
				this.NeedRevertVersion = true;
				for (int j = item2.Patch + 1; j <= item6.Patch; j++)
				{
					HashSet<string> revertVersions2 = this.RevertVersions;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
					defaultInterpolatedStringHandler.AppendFormatted<int>(item2.Major);
					defaultInterpolatedStringHandler.AppendLiteral(".");
					defaultInterpolatedStringHandler.AppendFormatted<int>(item2.Minor);
					defaultInterpolatedStringHandler.AppendLiteral(".");
					defaultInterpolatedStringHandler.AppendFormatted<int>(j);
					revertVersions2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
				}
			}
			if (this.NeedRevertVersion)
			{
				this.LocalResourceVersions = new List<string>();
				foreach (string item7 in list)
				{
					if (!this.RevertVersions.Contains(item7))
					{
						this.LocalResourceVersions.Add(item7);
					}
				}
				this.LocalResourceVersion = this.LocalResourceVersions[this.LocalResourceVersions.Count - 1];
				this.LocalSaveResourceVersions = new List<string>();
				foreach (string item8 in list2)
				{
					if (!this.RevertVersions.Contains(item8))
					{
						this.LocalSaveResourceVersions.Add(item8);
					}
				}
				this.LocalSaveResourceVersion = this.LocalSaveResourceVersions[this.LocalSaveResourceVersions.Count - 1];
				if (this.LocalResourceVersion == latestVersion)
				{
					flag = true;
				}
				if (this.LocalSaveResourceVersion == latestVersion)
				{
					flag2 = true;
				}
			}
			else
			{
				this.LocalResourceVersions = list;
				this.LocalResourceVersion = text;
				this.LocalSaveResourceVersions = list2;
				this.LocalSaveResourceVersion = text2;
			}
			if (flag)
			{
				this.UpdateVersion(null, true);
			}
			if (flag2)
			{
				this.UpdateSavedVersion(null, true);
			}
			this.BasePackageNeedDownloadRes = sha1Map.ContainsKey(this.PackageVersion);
			this.IndexSha1s = new List<string>();
			foreach (string text3 in this.LocalSaveResourceVersions)
			{
				if (!(text3 == this.PackageVersion) || this.BasePackageNeedDownloadRes)
				{
					this.IndexSha1s.Add(sha1Map[text3]);
				}
			}
			if (this.LocalSaveResourceVersion != this.LatestVersion)
			{
				this.IndexSha1s.Add(sha1Map[this.LatestVersion]);
			}
			this.HasUpdatedResource = ((this.LatestVersion == this.PackageVersion) ? (!this.BasePackageNeedDownloadRes) : (this.LocalResourceVersion == this.LatestVersion));
		}

		// Token: 0x0602E70B RID: 190219 RVA: 0x00AFE90C File Offset: 0x00AFCB0C
		public bool NeedRevert()
		{
			return this.NeedRevertVersion;
		}

		// Token: 0x0602E70C RID: 190220 RVA: 0x00AFE914 File Offset: 0x00AFCB14
		public HashSet<string> GetRevertVersions()
		{
			return this.RevertVersions;
		}

		// Token: 0x0602E70D RID: 190221 RVA: 0x00AFE91C File Offset: 0x00AFCB1C
		public bool HasNewResourceVersionBaseOnPackage()
		{
			return this.PackageVersion != this.LatestVersion;
		}

		// Token: 0x0602E70E RID: 190222 RVA: 0x00AFE92F File Offset: 0x00AFCB2F
		public bool IsBasePackageSplited()
		{
			return this.BasePackageNeedDownloadRes;
		}

		// Token: 0x0602E70F RID: 190223 RVA: 0x00AFE937 File Offset: 0x00AFCB37
		public bool IsFirstUpdateResources()
		{
			if (!(this.LatestVersion == this.PackageVersion))
			{
				return this.LatestVersion != this.LocalSaveResourceVersion;
			}
			return this.BasePackageNeedDownloadRes;
		}

		// Token: 0x0602E710 RID: 190224 RVA: 0x00AFE964 File Offset: 0x00AFCB64
		public virtual bool NeedCheckAppRestart()
		{
			return true;
		}

		// Token: 0x0602E711 RID: 190225 RVA: 0x00AFE967 File Offset: 0x00AFCB67
		public bool HasUpdated()
		{
			return this.HasUpdatedResource;
		}

		// Token: 0x0602E712 RID: 190226 RVA: 0x00AFE96F File Offset: 0x00AFCB6F
		public string GetLatestVersion()
		{
			return this.LatestVersion;
		}

		// Token: 0x0602E713 RID: 190227 RVA: 0x00AFE978 File Offset: 0x00AFCB78
		public void UpdateVersion(UObject worldContext, bool bNewPackage = false)
		{
			if (bNewPackage)
			{
				string value = string.Join(",", this.LocalResourceVersions);
				Singleton<LauncherStorageLib>.Instance.SetDeviceSavedString(this.GetUpdateVersionKey(), value);
				if (UKuroLauncherLibrary.NeedRestartApp() > 0)
				{
					UKuroLauncherLibrary.SetRestartApp(1);
				}
				return;
			}
			this.LocalResourceVersion = this.LatestVersion;
			if (this.LocalResourceVersions.Count <= 0 || this.LocalResourceVersions[this.LocalResourceVersions.Count - 1] != this.LatestVersion)
			{
				this.LocalResourceVersions.Add(this.LatestVersion);
			}
			string value2 = string.Join(",", this.LocalResourceVersions);
			Singleton<LauncherStorageLib>.Instance.SetDeviceSavedString(this.GetUpdateVersionKey(), value2);
		}

		// Token: 0x0602E714 RID: 190228 RVA: 0x00AFEA30 File Offset: 0x00AFCC30
		public unsafe void UpdateSavedVersion(UObject worldContext, bool bNewPackage = false)
		{
			if (bNewPackage)
			{
				string text = string.Join(",", this.LocalSaveResourceVersions);
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "UpdateSavedVersion";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", this.GetResType());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Versions", text);
				instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				Singleton<LauncherStorageLib>.Instance.SetDeviceSavedString(this.GetSaveUpdateVersionKey(), text);
				if (UKuroLauncherLibrary.NeedRestartApp() > 0)
				{
					UKuroLauncherLibrary.SetRestartApp(1);
				}
				return;
			}
			this.LocalSaveResourceVersion = this.LatestVersion;
			if (this.LocalSaveResourceVersions.Count <= 0 || this.LocalSaveResourceVersions[this.LocalSaveResourceVersions.Count - 1] != this.LatestVersion)
			{
				this.LocalSaveResourceVersions.Add(this.LatestVersion);
			}
			string text2 = string.Join(",", this.LocalSaveResourceVersions);
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "UpdateSavedVersion";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Type", this.GetResType());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Versions", text2);
			instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			Singleton<LauncherStorageLib>.Instance.SetDeviceSavedString(this.GetSaveUpdateVersionKey(), text2);
		}

		// Token: 0x0602E715 RID: 190229 RVA: 0x00AFEB90 File Offset: 0x00AFCD90
		public virtual void ClearAllPatchVersion(UObject worldContext)
		{
			Singleton<LauncherStorageLib>.Instance.DeleteDeviceSavedString(this.GetUpdateVersionKey());
			Singleton<LauncherStorageLib>.Instance.DeleteDeviceSavedString(this.GetSaveUpdateVersionKey());
			if (this.GetResType() == EResType.Launcher.ToEnumString())
			{
				Singleton<LauncherStorageLib>.Instance.DeleteDeviceSavedString("__kr_blvr__");
			}
		}

		// Token: 0x0602E716 RID: 190230 RVA: 0x00AFEBE4 File Offset: 0x00AFCDE4
		public List<PatchFileInfo> ReadPatchFileInfoList()
		{
			AppPathMisc pathMisc = new AppPathMisc();
			return ResourceUpdate.ReadPatchInfoList(this.GetIndexSavePaths(pathMisc), this.UpdatePreVersionNodes, this, pathMisc).Item2;
		}

		// Token: 0x0602E717 RID: 190231 RVA: 0x00AFEC10 File Offset: 0x00AFCE10
		public string GetPackageVersion()
		{
			return this.PackageVersion;
		}

		// Token: 0x0602E718 RID: 190232 RVA: 0x00AFEC18 File Offset: 0x00AFCE18
		public List<string> GetIndexSha1s()
		{
			return this.IndexSha1s;
		}

		// Token: 0x0602E719 RID: 190233 RVA: 0x00AFEC20 File Offset: 0x00AFCE20
		public List<string> GetIndexSavePaths(AppPathMisc pathMisc)
		{
			List<string> list = new List<string>();
			foreach (string value in this.GetIndexFileNames())
			{
				List<string> list2 = list;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 4);
				defaultInterpolatedStringHandler.AppendFormatted(pathMisc.GetPatchSaveDir());
				defaultInterpolatedStringHandler.AppendFormatted(this.GetPackageVersion());
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted(this.GetResType());
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted(value);
				list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return list;
		}

		// Token: 0x0602E71A RID: 190234 RVA: 0x00AFECD0 File Offset: 0x00AFCED0
		public List<string> GetUpdatePreVersions()
		{
			return this.UpdatePreVersionNodes;
		}

		// Token: 0x0602E71B RID: 190235 RVA: 0x00AFECD8 File Offset: 0x00AFCED8
		public List<string> GetIndexFileNames()
		{
			List<string> list = new List<string>();
			foreach (string str in this.UpdateVersionNodes)
			{
				list.Add(this.GetIndexFilePrefix() + str + ".txt");
			}
			return list;
		}

		// Token: 0x0602E71C RID: 190236 RVA: 0x00AFED44 File Offset: 0x00AFCF44
		public string GetMountFilePath()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 3);
			defaultInterpolatedStringHandler.AppendFormatted(UKuroLauncherLibrary.GameSavedDir());
			defaultInterpolatedStringHandler.AppendLiteral("Resources/");
			defaultInterpolatedStringHandler.AppendFormatted(this.GetPackageVersion());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(this.GetMountFileName());
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602E71D RID: 190237
		protected abstract string GetMountFileName();

		// Token: 0x0602E71E RID: 190238
		public abstract string GetResType();

		// Token: 0x0602E71F RID: 190239
		protected abstract string GetUpdateVersionKey();

		// Token: 0x0602E720 RID: 190240
		protected abstract string GetSaveUpdateVersionKey();

		// Token: 0x0602E721 RID: 190241
		protected abstract string GetIndexFilePrefix();

		// Token: 0x0602E722 RID: 190242
		protected abstract string GetRemoteVersion();

		// Token: 0x0602E723 RID: 190243
		protected abstract Dictionary<string, string> GetRemoteSha1Map();

		// Token: 0x0401A5F7 RID: 108023
		protected string PackageVersion = "";

		// Token: 0x0401A5F8 RID: 108024
		protected string LocalResourceVersion = "";

		// Token: 0x0401A5F9 RID: 108025
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected List<string> LocalResourceVersions;

		// Token: 0x0401A5FA RID: 108026
		protected string LocalSaveResourceVersion = "";

		// Token: 0x0401A5FB RID: 108027
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected List<string> LocalSaveResourceVersions;

		// Token: 0x0401A5FC RID: 108028
		protected string LatestVersion = "";

		// Token: 0x0401A5FD RID: 108029
		protected bool HasUpdatedResource;

		// Token: 0x0401A5FE RID: 108030
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected List<string> IndexSha1s;

		// Token: 0x0401A5FF RID: 108031
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected List<string> UpdateVersionNodes;

		// Token: 0x0401A600 RID: 108032
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected List<string> UpdatePreVersionNodes;

		// Token: 0x0401A601 RID: 108033
		private bool BasePackageNeedDownloadRes;

		// Token: 0x0401A602 RID: 108034
		private bool NeedRevertVersion;

		// Token: 0x0401A603 RID: 108035
		private readonly HashSet<string> RevertVersions = new HashSet<string>();
	}
}
