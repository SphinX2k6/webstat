using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Download;
using CSharpScript.Launcher.Util;
using UnrealEngine;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044C4 RID: 17604
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LanguageUpdateManager : Singleton<LanguageUpdateManager>
	{
		// Token: 0x0602E761 RID: 190305 RVA: 0x00AFF988 File Offset: 0x00AFDB88
		public void Init(UObject worldContext)
		{
			if (this.Initialized)
			{
				return;
			}
			AppPathMisc appPathMisc = new AppPathMisc();
			foreach (LaunchLangDefine launchLangDefine in Singleton<LauncherLanguageLib>.Instance.GetAllLanguageDefines())
			{
				if (!this.UpdaterMap.ContainsKey(launchLangDefine.AudioCode))
				{
					LanguageUpdater languageUpdater = new LanguageUpdater();
					languageUpdater.LanguageCode = launchLangDefine.AudioCode;
					languageUpdater.Downloader = new UrlPrefixDownload();
					languageUpdater.VersionMisc = new LanguageVersionMisc(languageUpdater.LanguageCode);
					LanguageUpdateUiEvent uiEvent = null;
					UpdateReportEvent reportEvent = new UpdateReportEvent("in-game-" + languageUpdater.LanguageCode);
					uiEvent = new LanguageUpdateUiEvent();
					languageUpdater.DiffResInfo = ResPackageInfo.GetLanguageInfo(languageUpdater.LanguageCode);
					ResPackageInfo languageInfo = ResPackageInfo.GetLanguageInfo(languageUpdater.LanguageCode);
					List<ResPackageInfo> list = new List<ResPackageInfo>
					{
						languageInfo
					};
					foreach (KeyValuePair<string, ResPackageInfo> keyValuePair in ResPackageInfo.RoleVoiceInfos)
					{
						string[] array = keyValuePair.Key.Split('_', StringSplitOptions.None);
						if (array[array.Length - 1] == languageUpdater.LanguageCode)
						{
							list.Add(keyValuePair.Value);
							languageUpdater.RoleVoiceResInfos.Add(keyValuePair.Value);
						}
					}
					languageUpdater.DiffUpdater = new DiffUpdate(list, languageUpdater.Downloader, uiEvent, reportEvent, true, EUpdateType.IndependentLang);
					this.UpdaterMap[languageUpdater.LanguageCode] = languageUpdater;
					languageUpdater.Init(worldContext, uiEvent);
					this.AllLanguageType.Add(launchLangDefine.LanguageType);
				}
			}
			this.Initialized = true;
		}

		// Token: 0x0602E762 RID: 190306 RVA: 0x00AFFB5C File Offset: 0x00AFDD5C
		public List<int> GetAllLanguageTypeForAudio()
		{
			return this.AllLanguageType;
		}

		// Token: 0x0602E763 RID: 190307 RVA: 0x00AFFB64 File Offset: 0x00AFDD64
		public List<LanguageVersionMisc> GetAllLanguagesVersionMisc()
		{
			List<LanguageVersionMisc> list = new List<LanguageVersionMisc>();
			foreach (KeyValuePair<string, LanguageUpdater> keyValuePair in this.UpdaterMap)
			{
				list.Add(keyValuePair.Value.VersionMisc);
			}
			return list;
		}

		// Token: 0x0602E764 RID: 190308 RVA: 0x00AFFBCC File Offset: 0x00AFDDCC
		public LanguageUpdater GetUpdater(string languageCode)
		{
			return this.UpdaterMap[languageCode];
		}

		// Token: 0x0602E765 RID: 190309 RVA: 0x00AFFBDC File Offset: 0x00AFDDDC
		public void StopAllDownload()
		{
			foreach (KeyValuePair<string, LanguageUpdater> keyValuePair in this.UpdaterMap)
			{
				keyValuePair.Value.Pause();
			}
		}

		// Token: 0x0401A61B RID: 108059
		private bool Initialized;

		// Token: 0x0401A61C RID: 108060
		private readonly Dictionary<string, LanguageUpdater> UpdaterMap = new Dictionary<string, LanguageUpdater>();

		// Token: 0x0401A61D RID: 108061
		private readonly List<int> AllLanguageType = new List<int>();
	}
}
