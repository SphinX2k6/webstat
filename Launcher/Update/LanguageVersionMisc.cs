using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Util;
using UnrealEngine;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044BF RID: 17599
	[NullableContext(1)]
	[Nullable(0)]
	public class LanguageVersionMisc : AppVersionMisc
	{
		// Token: 0x0602E735 RID: 190261 RVA: 0x00AFEE7B File Offset: 0x00AFD07B
		public LanguageVersionMisc(string languageCode)
		{
			this.LanguageCode = languageCode;
		}

		// Token: 0x0602E736 RID: 190262 RVA: 0x00AFEE95 File Offset: 0x00AFD095
		protected override string GetUpdateVersionKey()
		{
			return "LanguageVersion_" + this.LanguageCode;
		}

		// Token: 0x0602E737 RID: 190263 RVA: 0x00AFEEA7 File Offset: 0x00AFD0A7
		protected override string GetSaveUpdateVersionKey()
		{
			return "SavedLanguageVersion_" + this.LanguageCode;
		}

		// Token: 0x0602E738 RID: 190264 RVA: 0x00AFEEB9 File Offset: 0x00AFD0B9
		protected override string GetIndexFilePrefix()
		{
			return "PatchList_" + this.LanguageCode + "_";
		}

		// Token: 0x0602E739 RID: 190265 RVA: 0x00AFEED0 File Offset: 0x00AFD0D0
		protected override string GetMountFileName()
		{
			return "Resource_" + this.LanguageCode + "_Mount.txt";
		}

		// Token: 0x0602E73A RID: 190266 RVA: 0x00AFEEE7 File Offset: 0x00AFD0E7
		public override string GetResType()
		{
			return EResType.Resource.ToEnumString() + "_" + this.LanguageCode;
		}

		// Token: 0x0602E73B RID: 190267 RVA: 0x00AFEF00 File Offset: 0x00AFD100
		protected override string GetRemoteVersion()
		{
			if (!this.IsSetLangVersion)
			{
				RemoteConfig config = Singleton<RemoteInfo>.Instance.Config;
				if (((config != null) ? config.Versions : null) != null)
				{
					foreach (VersionItem versionItem in Singleton<RemoteInfo>.Instance.Config.Versions)
					{
						if (versionItem.Name == this.LanguageCode)
						{
							this.LangVersion = versionItem;
							break;
						}
					}
				}
				this.IsSetLangVersion = true;
			}
			VersionItem langVersion = this.LangVersion;
			if (langVersion == null)
			{
				return null;
			}
			return langVersion.Version;
		}

		// Token: 0x0602E73C RID: 190268 RVA: 0x00AFEFAC File Offset: 0x00AFD1AC
		protected override Dictionary<string, string> GetRemoteSha1Map()
		{
			if (!this.IsSetLangVersion)
			{
				RemoteConfig config = Singleton<RemoteInfo>.Instance.Config;
				if (((config != null) ? config.Versions : null) != null)
				{
					foreach (VersionItem versionItem in Singleton<RemoteInfo>.Instance.Config.Versions)
					{
						if (versionItem.Name == this.LanguageCode)
						{
							this.LangVersion = versionItem;
							break;
						}
					}
				}
				this.IsSetLangVersion = true;
			}
			VersionItem langVersion = this.LangVersion;
			if (langVersion == null)
			{
				return null;
			}
			return langVersion.IndexSha1;
		}

		// Token: 0x0602E73D RID: 190269 RVA: 0x00AFF058 File Offset: 0x00AFD258
		public override void ClearAllPatchVersion(UObject worldContext)
		{
			base.ClearAllPatchVersion(worldContext);
			Singleton<LauncherStorageLib>.Instance.DeleteDeviceSavedString(this.GetUseLanguageSaveKey());
		}

		// Token: 0x0602E73E RID: 190270 RVA: 0x00AFF072 File Offset: 0x00AFD272
		public bool HasMountFile()
		{
			return UBlueprintPathsLibrary.FileExists(base.GetMountFilePath());
		}

		// Token: 0x0602E73F RID: 190271 RVA: 0x00AFF080 File Offset: 0x00AFD280
		[NullableContext(0)]
		public ValueTuple<long, long> CalculateLocalSize()
		{
			List<PatchFileInfo> list = base.ReadPatchFileInfoList();
			long num = 0L;
			long num2 = 0L;
			foreach (PatchFileInfo patchFileInfo in list)
			{
				num2 += patchFileInfo.PakSize.GetValueOrDefault();
				num2 += patchFileInfo.SigSize.GetValueOrDefault();
				num2 += patchFileInfo.UtocSize.GetValueOrDefault();
				num2 += patchFileInfo.UcasSize.GetValueOrDefault();
				if (UBlueprintPathsLibrary.FileExists(patchFileInfo.SavePath + EResFile.PAK.ToEnumString()))
				{
					num += patchFileInfo.PakSize.GetValueOrDefault();
				}
				else
				{
					string text = patchFileInfo.SavePath + EResFile.PAK.ToEnumString() + ".download";
					if (UBlueprintPathsLibrary.FileExists(text))
					{
						num += UKuroLauncherLibrary.GetFileSize(text);
					}
				}
				if (UBlueprintPathsLibrary.FileExists(patchFileInfo.SavePath + EResFile.SIG.ToEnumString()))
				{
					num += patchFileInfo.SigSize.GetValueOrDefault();
				}
				else
				{
					string text2 = patchFileInfo.SavePath + EResFile.SIG.ToEnumString() + ".download";
					if (UBlueprintPathsLibrary.FileExists(text2))
					{
						num += UKuroLauncherLibrary.GetFileSize(text2);
					}
				}
				if (UBlueprintPathsLibrary.FileExists(patchFileInfo.SavePath + EResFile.UTOC.ToEnumString()))
				{
					num += patchFileInfo.UtocSize.GetValueOrDefault();
				}
				else
				{
					string text3 = patchFileInfo.SavePath + EResFile.UTOC.ToEnumString() + ".download";
					if (UBlueprintPathsLibrary.FileExists(text3))
					{
						num += UKuroLauncherLibrary.GetFileSize(text3);
					}
				}
				if (UBlueprintPathsLibrary.FileExists(patchFileInfo.SavePath + EResFile.UCAS.ToEnumString()))
				{
					num += patchFileInfo.UcasSize.GetValueOrDefault();
				}
				else
				{
					string text4 = patchFileInfo.SavePath + EResFile.UCAS.ToEnumString() + ".download";
					if (UBlueprintPathsLibrary.FileExists(text4))
					{
						num += UKuroLauncherLibrary.GetFileSize(text4);
					}
				}
			}
			return new ValueTuple<long, long>(num, num2);
		}

		// Token: 0x0602E740 RID: 190272 RVA: 0x00AFF270 File Offset: 0x00AFD470
		public bool NeedUpdate()
		{
			if (Singleton<Platform>.Instance.IsCloudGame())
			{
				return true;
			}
			if (this.LanguageCode == Singleton<LauncherLanguageLib>.Instance.PackageLanguage)
			{
				return true;
			}
			string text = (Singleton<LauncherStorageLib>.Instance.GetDeviceSavedString(this.GetUseLanguageSaveKey(), "") ?? "").Trim();
			return (text != null && text.Length > 0) || (base.HasNewResourceVersionBaseOnPackage() && !base.IsFirstUpdateResources());
		}

		// Token: 0x0602E741 RID: 190273 RVA: 0x00AFF2E9 File Offset: 0x00AFD4E9
		public override bool NeedCheckAppRestart()
		{
			return false;
		}

		// Token: 0x0602E742 RID: 190274 RVA: 0x00AFF2EC File Offset: 0x00AFD4EC
		public void DeleteSavedVersion(UObject worldContext)
		{
			Singleton<LauncherStorageLib>.Instance.SetDeviceSavedString(this.GetSaveUpdateVersionKey(), this.PackageVersion);
			Singleton<LauncherStorageLib>.Instance.DeleteDeviceSavedString(this.GetUseLanguageSaveKey());
		}

		// Token: 0x0602E743 RID: 190275 RVA: 0x00AFF316 File Offset: 0x00AFD516
		private string GetUseLanguageSaveKey()
		{
			return "UseLanguage_" + this.LanguageCode;
		}

		// Token: 0x0602E744 RID: 190276 RVA: 0x00AFF328 File Offset: 0x00AFD528
		public void SetUseLanguagePackage()
		{
			Singleton<LauncherStorageLib>.Instance.SetDeviceSavedString(this.GetUseLanguageSaveKey(), "1");
		}

		// Token: 0x0401A604 RID: 108036
		public string LanguageCode = "";

		// Token: 0x0401A605 RID: 108037
		[Nullable(2)]
		private VersionItem LangVersion;

		// Token: 0x0401A606 RID: 108038
		private bool IsSetLangVersion;
	}
}
