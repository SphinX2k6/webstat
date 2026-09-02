using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.PackageUpdate;
using UnrealEngine;

// Token: 0x0200236A RID: 9066
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ParallelPackageController : ControllerBase<ParallelPackageController>
{
	// Token: 0x0601158D RID: 71053 RVA: 0x004C7476 File Offset: 0x004C5676
	protected override bool OnInit()
	{
		this.InitParallelPackageConfig();
		return true;
	}

	// Token: 0x0601158E RID: 71054 RVA: 0x004C747F File Offset: 0x004C567F
	public void TestParallelPackage()
	{
		this.GmTest = true;
		Singleton<BaseConfigController>.Instance.GetCdnReturnConfigInfo().ParallelPackageDescUrl = new IUpdateUrl
		{
			MainUrl = "https://gm-test.aki-game.com/force_update/OptionalUpdate.json",
			SubUrl = "https://gm-test.aki-game.com/force_update/OptionalUpdate.json"
		};
		this.InitParallelPackageConfig();
	}

	// Token: 0x0601158F RID: 71055 RVA: 0x004C74B8 File Offset: 0x004C56B8
	private void InitParallelPackageConfig()
	{
		string appParallel = UKuroLauncherLibrary.GetAppParallel();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "InitParallelPackageConfig";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("parallelName", appParallel);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.GetParallelPackageConfig(false, new Action<bool, string>(this.OnInitParallelPackageConfig));
	}

	// Token: 0x06011590 RID: 71056 RVA: 0x004C7508 File Offset: 0x004C5708
	private void HttpGetInfo(string url, Action<bool, int, string> callBack, int currentTryCount = 0)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "InitParallelPackageConfig";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("url", url);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Http.Get(url, null, delegate(bool success, int code, string data)
		{
			if (!success || code != 200)
			{
				callBack(false, code, data);
				return;
			}
			callBack(true, code, data);
		}, null);
	}

	// Token: 0x06011591 RID: 71057 RVA: 0x004C7568 File Offset: 0x004C5768
	private void GetParallelPackageConfig(bool switchUrl, Action<bool, string> onGetConfig)
	{
		string url = "";
		EntryJson cdnReturnConfigInfo = Singleton<BaseConfigController>.Instance.GetCdnReturnConfigInfo();
		if (cdnReturnConfigInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.KuroSdk, ELogAuthor.LRX, "CDN return config info is null!!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		url = ((cdnReturnConfigInfo.ParallelPackageDescUrl != null) ? (switchUrl ? cdnReturnConfigInfo.ParallelPackageDescUrl.MainUrl : cdnReturnConfigInfo.ParallelPackageDescUrl.SubUrl) : "");
		this.HttpGetInfo(url, delegate(bool state, int code, string data)
		{
			if (state)
			{
				onGetConfig(state, data);
				return;
			}
			if (switchUrl)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.KuroSdk;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "InitParallelPackageConfig";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Failed to get parallel package config", url);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				onGetConfig(state, data);
				return;
			}
			this.GetParallelPackageConfig(true, onGetConfig);
		}, 0);
	}

	// Token: 0x06011592 RID: 71058 RVA: 0x004C7614 File Offset: 0x004C5814
	private void OnInitParallelPackageConfig(bool state, string data)
	{
		if (!state)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.KuroSdk;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "InitParallelPackageConfig fail";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(data, Singleton<BaseConfigController>.Instance.GetCdnReturnConfigInfo().ParallelPackageDescUrl);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.Config = Json.Parse<ParallelPackageConfig>(data, null);
	}

	// Token: 0x06011593 RID: 71059 RVA: 0x004C7664 File Offset: 0x004C5864
	private string GetCacheParallelPackageVersion()
	{
		string global = LocalStorage.GetGlobal<string>(ELocalStorageGlobalKey.ParallelPackageVersion, null);
		if (global == null)
		{
			return "";
		}
		return global;
	}

	// Token: 0x06011594 RID: 71060 RVA: 0x004C7688 File Offset: 0x004C5888
	public bool CheckParallelPackageWithCache()
	{
		if (this.GmTest)
		{
			return true;
		}
		if (this.CurrentLoginShowState)
		{
			return false;
		}
		string cacheParallelPackageVersion = this.GetCacheParallelPackageVersion();
		return !(this.GetCurrentPlatformParallelPackageVersionText() == cacheParallelPackageVersion) && this.CheckParallelPackage();
	}

	// Token: 0x06011595 RID: 71061 RVA: 0x004C76C8 File Offset: 0x004C58C8
	public bool CheckParallelPackage()
	{
		if (!Singleton<Info>.Instance.IsMobilePlatform() || this.Config == null)
		{
			return false;
		}
		ParallelPackageUrlConfig currentPlatformParallelPackageVersion = this.GetCurrentPlatformParallelPackageVersion();
		if (currentPlatformParallelPackageVersion == null)
		{
			return false;
		}
		string parentVersion = currentPlatformParallelPackageVersion.parentVersion;
		string childVersion = currentPlatformParallelPackageVersion.childVersion;
		string appVersion = UKuroLauncherLibrary.GetAppVersion();
		float num;
		float num2;
		return !(this.GetSplitAppVersion(parentVersion) != this.GetSplitAppVersion(appVersion)) && float.TryParse(childVersion, out num) && float.TryParse(UKuroLauncherLibrary.GetAppChangeList(), out num2) && num > num2;
	}

	// Token: 0x06011596 RID: 71062 RVA: 0x004C7744 File Offset: 0x004C5944
	private string GetSplitAppVersion(string version)
	{
		string[] array = version.Split('.', StringSplitOptions.None);
		if (array.Length < 2)
		{
			return version;
		}
		return array[0] + "." + array[1];
	}

	// Token: 0x06011597 RID: 71063 RVA: 0x004C7774 File Offset: 0x004C5974
	private string GetPackageUpdateContentByLanguageCode(string languageCode)
	{
		Dictionary<string, ParallelPackageLanguageContent> languageConfig = this.Config.languageConfig;
		if (languageConfig == null)
		{
			return "";
		}
		ParallelPackageLanguageContent parallelPackageLanguageContent;
		if (!languageConfig.TryGetValue(languageCode, out parallelPackageLanguageContent))
		{
			return "";
		}
		return parallelPackageLanguageContent.content;
	}

	// Token: 0x06011598 RID: 71064 RVA: 0x004C77B0 File Offset: 0x004C59B0
	private string GetPackageUpdateTitleByLanguageCode(string languageCode)
	{
		Dictionary<string, ParallelPackageLanguageContent> languageConfig = this.Config.languageConfig;
		if (languageConfig == null)
		{
			return "";
		}
		ParallelPackageLanguageContent parallelPackageLanguageContent;
		if (!languageConfig.TryGetValue(languageCode, out parallelPackageLanguageContent))
		{
			return "";
		}
		return parallelPackageLanguageContent.title;
	}

	// Token: 0x06011599 RID: 71065 RVA: 0x004C77EC File Offset: 0x004C59EC
	private string GetCurrentPlatformParallelPackageVersionText()
	{
		ParallelPackageUrlConfig currentPlatformParallelPackageVersion = this.GetCurrentPlatformParallelPackageVersion();
		if (currentPlatformParallelPackageVersion == null)
		{
			return "";
		}
		return currentPlatformParallelPackageVersion.parentVersion + "_" + currentPlatformParallelPackageVersion.childVersion;
	}

	// Token: 0x0601159A RID: 71066 RVA: 0x004C7820 File Offset: 0x004C5A20
	[NullableContext(2)]
	private ParallelPackageUrlConfig GetCurrentPlatformParallelPackageVersion()
	{
		if (this.Config == null || this.Config.version == 0)
		{
			return null;
		}
		string b = Singleton<PublicUtil>.Instance.OverridePackageId ?? ControllerBase<KuroSdkController>.Instance.GetPackageId();
		if (this.Config.packageConfig == null)
		{
			return null;
		}
		int count = this.Config.packageConfig.Count;
		for (int i = 0; i < count; i++)
		{
			ParallelPackageUrlConfig parallelPackageUrlConfig = this.Config.packageConfig[i];
			if (parallelPackageUrlConfig.packageId == b)
			{
				return parallelPackageUrlConfig;
			}
		}
		return null;
	}

	// Token: 0x0601159B RID: 71067 RVA: 0x004C78AC File Offset: 0x004C5AAC
	public void TryShowParallelPackageUpdateConfirmBox(ParallelPackageDownloadBoxShowReason reason)
	{
		if (!this.CheckParallelPackageWithCache())
		{
			return;
		}
		this.CurrentLoginShowState = true;
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ParallelPackageUpdate);
		string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		string text = this.GetPackageUpdateTitleByLanguageCode(packageLanguage);
		string text2 = this.GetPackageUpdateContentByLanguageCode(packageLanguage);
		if (text == "")
		{
			text = (ConfigMultiTextLang.GetLocalTextNew("ParallelPackageUpdateDefaultTitle", null) ?? "");
		}
		if (text2 == "")
		{
			text2 = (ConfigMultiTextLang.GetLocalTextNew("ParallelPackageUpdateDefaultDesc", null) ?? "");
		}
		confirmBoxDataNew.SetTitle(text);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			text2
		});
		confirmBoxDataNew.HasToggle = true;
		confirmBoxDataNew.ToggleTextKey = "ParallelPackageVersionTip";
		bool toggleState = false;
		confirmBoxDataNew.SetToggleFunction(delegate(bool isSelectOn)
		{
			toggleState = isSelectOn;
		});
		confirmBoxDataNew.CanExecuteCloseFunc = ((int selectedIndex) => selectedIndex != 2);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			Singleton<PackageUpdateController>.Instance.TryOpenParallelPackageUpdateUrl();
			int i_type = (reason == ParallelPackageDownloadBoxShowReason.Auto) ? 1 : 3;
			ParallelDownloadConfirmBoxOperation parallelDownloadConfirmBoxOperation = new ParallelDownloadConfirmBoxOperation();
			parallelDownloadConfirmBoxOperation.i_type = i_type;
			ControllerBase<LogReportController>.Instance.LogReport(parallelDownloadConfirmBoxOperation);
		});
		confirmBoxDataNew.FunctionMap.Add(1, delegate
		{
			ParallelDownloadConfirmBoxOperation parallelDownloadConfirmBoxOperation = new ParallelDownloadConfirmBoxOperation();
			parallelDownloadConfirmBoxOperation.i_type = 2;
			ControllerBase<LogReportController>.Instance.LogReport(parallelDownloadConfirmBoxOperation);
		});
		confirmBoxDataNew.SetCloseFunction(delegate
		{
			if (toggleState)
			{
				string currentPlatformParallelPackageVersionText = this.GetCurrentPlatformParallelPackageVersionText();
				LocalStorage.SetGlobal<string>(ELocalStorageGlobalKey.ParallelPackageVersion, currentPlatformParallelPackageVersionText);
			}
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		if (reason == ParallelPackageDownloadBoxShowReason.Auto)
		{
			AutoShowParallelDownloadConfirmBox logData = new AutoShowParallelDownloadConfirmBox();
			ControllerBase<LogReportController>.Instance.LogReport(logData);
		}
	}

	// Token: 0x04008857 RID: 34903
	public bool GmTest;

	// Token: 0x04008858 RID: 34904
	[Nullable(2)]
	private ParallelPackageConfig Config;

	// Token: 0x04008859 RID: 34905
	private bool CurrentLoginShowState;
}
