using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Data.Parkour;
using CSharpScript.Core.Common;
using CSharpScript.Game.Define;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000E64 RID: 3684
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PublicUtil : Singleton<PublicUtil>
{
	// Token: 0x060058A1 RID: 22689 RVA: 0x00107601 File Offset: 0x00105801
	public string GetConfigPath(string file)
	{
		return UKismetSystemLibrary.GetProjectDirectory() + file;
	}

	// Token: 0x060058A2 RID: 22690 RVA: 0x00107610 File Offset: 0x00105810
	public bool IsInIpWhiteList([Nullable(new byte[]
	{
		2,
		1
	})] IReadOnlyList<string> whiteList)
	{
		if (whiteList == null)
		{
			return true;
		}
		if (whiteList.Count == 0)
		{
			return false;
		}
		TArray<string> inArr = new TArray<string>();
		UKuroStaticLibrary.GetLocalHostAddresses(ref inArr, false);
		string[] array = inArr.ToArray<string>();
		foreach (string b in whiteList)
		{
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i] == b)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060058A3 RID: 22691 RVA: 0x001076A4 File Offset: 0x001058A4
	public bool GetIfGlobalSdk()
	{
		return Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea") != "CN";
	}

	// Token: 0x060058A4 RID: 22692 RVA: 0x001076BF File Offset: 0x001058BF
	public string GetGameId()
	{
		if (this.GetIfGlobalSdk())
		{
			return "G153";
		}
		return "G152";
	}

	// Token: 0x060058A5 RID: 22693 RVA: 0x001076D4 File Offset: 0x001058D4
	[return: Nullable(2)]
	public string GetLoginNoticeUrl2(string gameId, string language, string serverId)
	{
		string noticeBaseUrl = this.GetNoticeBaseUrl();
		if (string.IsNullOrEmpty(noticeBaseUrl))
		{
			return null;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 4);
		defaultInterpolatedStringHandler.AppendFormatted(noticeBaseUrl);
		defaultInterpolatedStringHandler.AppendLiteral("/gm/loginNotice/");
		defaultInterpolatedStringHandler.AppendFormatted(gameId);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted(serverId);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted(language);
		defaultInterpolatedStringHandler.AppendLiteral(".json");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060058A6 RID: 22694 RVA: 0x00107754 File Offset: 0x00105954
	[return: Nullable(2)]
	public string GetMarqueeUrl2(string gameId, string serverId)
	{
		string noticeBaseUrl = this.GetNoticeBaseUrl();
		if (string.IsNullOrEmpty(noticeBaseUrl))
		{
			return null;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 3);
		defaultInterpolatedStringHandler.AppendFormatted(noticeBaseUrl);
		defaultInterpolatedStringHandler.AppendLiteral("/gm/scrollTextNotice/");
		defaultInterpolatedStringHandler.AppendFormatted(gameId);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted(serverId);
		defaultInterpolatedStringHandler.AppendLiteral("/notice.json");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060058A7 RID: 22695 RVA: 0x001077C0 File Offset: 0x001059C0
	[NullableContext(2)]
	public string GetLoginNoticeUrl()
	{
		string noticeBaseUrl = this.GetNoticeBaseUrl();
		if (string.IsNullOrEmpty(noticeBaseUrl))
		{
			return null;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 4);
		defaultInterpolatedStringHandler.AppendFormatted(noticeBaseUrl);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted("com.kurogame.aki.internal");
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted(UKuroLauncherLibrary.GetAppVersion());
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted("LoginNotice.json");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060058A8 RID: 22696 RVA: 0x00107840 File Offset: 0x00105A40
	[NullableContext(2)]
	public string GetMarqueeUrl()
	{
		string noticeBaseUrl = this.GetNoticeBaseUrl();
		if (string.IsNullOrEmpty(noticeBaseUrl))
		{
			return null;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 4);
		defaultInterpolatedStringHandler.AppendFormatted(noticeBaseUrl);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted("com.kurogame.aki.internal");
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted(UKuroLauncherLibrary.GetAppVersion());
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted("ScrollTextNotice.json");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060058A9 RID: 22697 RVA: 0x001078C0 File Offset: 0x00105AC0
	[NullableContext(2)]
	public string GetNoticeBaseUrl()
	{
		string noticeUrl = Singleton<BaseConfigController>.Instance.GetNoticeUrl();
		if (string.IsNullOrEmpty(noticeUrl))
		{
			if (!GlobalData.IsPlayInEditor)
			{
				string appReleaseType = KuroApplication.GetAppReleaseType();
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.PublicUtil;
				ELogAuthor author = ELogAuthor.ZJC;
				string message = "找不到cdn";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Apptype", appReleaseType);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return null;
		}
		return Singleton<CdnServerDebugConfig>.Instance.TryGetNoticeServerPrefixAddress(noticeUrl);
	}

	// Token: 0x060058AA RID: 22698 RVA: 0x00107928 File Offset: 0x00105B28
	[return: Nullable(2)]
	public string GetGARUrl(int loginType, string userId, string userName, string token, string area)
	{
		string garurl = Singleton<BaseConfigController>.Instance.GetGARUrl();
		if (string.IsNullOrEmpty(garurl))
		{
			return null;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(65, 6);
		defaultInterpolatedStringHandler.AppendFormatted(garurl);
		defaultInterpolatedStringHandler.AppendLiteral("/UserRegion/GetUserInfo?loginType=");
		defaultInterpolatedStringHandler.AppendFormatted<int>(loginType);
		defaultInterpolatedStringHandler.AppendLiteral("&userId=");
		defaultInterpolatedStringHandler.AppendFormatted(userId);
		defaultInterpolatedStringHandler.AppendLiteral("&token=");
		defaultInterpolatedStringHandler.AppendFormatted(token);
		defaultInterpolatedStringHandler.AppendLiteral("&area=");
		defaultInterpolatedStringHandler.AppendFormatted(area);
		defaultInterpolatedStringHandler.AppendLiteral("&userName=");
		defaultInterpolatedStringHandler.AppendFormatted(userName);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060058AB RID: 22699 RVA: 0x001079CC File Offset: 0x00105BCC
	[NullableContext(2)]
	public string GetXboxRegionUrl()
	{
		string garurl = Singleton<BaseConfigController>.Instance.GetGARUrl();
		if (string.IsNullOrEmpty(garurl))
		{
			return null;
		}
		return garurl + "/UserRegion/GetXboxRegion";
	}

	// Token: 0x060058AC RID: 22700 RVA: 0x001079FC File Offset: 0x00105BFC
	[NullableContext(2)]
	public string SetXboxRegionUrl()
	{
		string garurl = Singleton<BaseConfigController>.Instance.GetGARUrl();
		if (string.IsNullOrEmpty(garurl))
		{
			return null;
		}
		return garurl + "/UserRegion/SetXboxRegion";
	}

	// Token: 0x060058AD RID: 22701 RVA: 0x00107A2C File Offset: 0x00105C2C
	public string GetPublicInfo()
	{
		string stringConfig = ConfigCommonParamById.GetStringConfig("mail_question_key");
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		string value = Uri.EscapeDataString(ModelBase<FunctionModel>.Instance.GetPlayerName() ?? "");
		string serverId = ModelBase<LoginModel>.Instance.GetServerId();
		SdkLoginConfig sdkLoginConfig = ModelBase<LoginModel>.Instance.GetSdkLoginConfig();
		string text = ((sdkLoginConfig != null) ? sdkLoginConfig.Token : null) ?? "";
		string value2 = ((sdkLoginConfig != null) ? sdkLoginConfig.Uid : null) ?? "";
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		text = UKuroStaticLibrary.Base64Encode(text);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 5);
		defaultInterpolatedStringHandler.AppendFormatted<int?>(id);
		defaultInterpolatedStringHandler.AppendLiteral(";");
		defaultInterpolatedStringHandler.AppendFormatted(serverId);
		defaultInterpolatedStringHandler.AppendLiteral(";");
		defaultInterpolatedStringHandler.AppendFormatted(text);
		defaultInterpolatedStringHandler.AppendLiteral(";");
		defaultInterpolatedStringHandler.AppendFormatted<double>(serverTime);
		defaultInterpolatedStringHandler.AppendLiteral(";");
		defaultInterpolatedStringHandler.AppendFormatted(stringConfig);
		string text2 = defaultInterpolatedStringHandler.ToStringAndClear();
		text2 = UKuroStaticLibrary.HashStringWithSHA1(text2);
		string value3 = (!string.IsNullOrEmpty(this.OverridePackageId)) ? this.OverridePackageId : ControllerBase<KuroSdkController>.Instance.GetPackageId();
		string channelId = ControllerBase<KuroSdkController>.Instance.GetChannelId();
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(84, 9);
		defaultInterpolatedStringHandler.AppendLiteral("playerId=");
		defaultInterpolatedStringHandler.AppendFormatted<int?>(id);
		defaultInterpolatedStringHandler.AppendLiteral("&playerName=");
		defaultInterpolatedStringHandler.AppendFormatted(value);
		defaultInterpolatedStringHandler.AppendLiteral("&serverId=");
		defaultInterpolatedStringHandler.AppendFormatted(serverId);
		defaultInterpolatedStringHandler.AppendLiteral("&token=");
		defaultInterpolatedStringHandler.AppendFormatted(text);
		defaultInterpolatedStringHandler.AppendLiteral("&timestamp=");
		defaultInterpolatedStringHandler.AppendFormatted<double>(serverTime);
		defaultInterpolatedStringHandler.AppendLiteral("&sign=");
		defaultInterpolatedStringHandler.AppendFormatted(text2);
		defaultInterpolatedStringHandler.AppendLiteral("&playerUid=");
		defaultInterpolatedStringHandler.AppendFormatted(value2);
		defaultInterpolatedStringHandler.AppendLiteral("&pkgId=");
		defaultInterpolatedStringHandler.AppendFormatted(value3);
		defaultInterpolatedStringHandler.AppendLiteral("&channelId=");
		defaultInterpolatedStringHandler.AppendFormatted(channelId);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060058AE RID: 22702 RVA: 0x00107C30 File Offset: 0x00105E30
	[return: Nullable(2)]
	public string GetExternalUrl(string rootUrl, PublicUtil.EExternalUrlReason reason)
	{
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.PublicUtil;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "GetExternalUrl";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("rootUrl", rootUrl);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (string.IsNullOrEmpty(rootUrl) || string.IsNullOrWhiteSpace(rootUrl))
		{
			return null;
		}
		string publicInfo = this.GetPublicInfo();
		switch (reason)
		{
		case PublicUtil.EExternalUrlReason.Mail:
		{
			string channelId = ControllerBase<KuroSdkController>.Instance.GetChannelId();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 3);
			defaultInterpolatedStringHandler.AppendFormatted(rootUrl);
			defaultInterpolatedStringHandler.AppendLiteral("?");
			defaultInterpolatedStringHandler.AppendFormatted(publicInfo);
			defaultInterpolatedStringHandler.AppendLiteral("&channelId=");
			defaultInterpolatedStringHandler.AppendFormatted(channelId);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		case PublicUtil.EExternalUrlReason.InviteNewbie:
			return this.AppendPublicInfo(rootUrl, reason);
		case PublicUtil.EExternalUrlReason.GameIntroduction:
		{
			string value = (!string.IsNullOrEmpty(this.OverridePackageId)) ? this.OverridePackageId : ControllerBase<KuroSdkController>.Instance.GetPackageId();
			string channelId = ControllerBase<KuroSdkController>.Instance.GetChannelId();
			string value2 = UKuroStaticLibrary.Base64Encode(publicInfo);
			string value3 = ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk() ? "global" : "cn";
			string value4 = "game";
			string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
			string platformStr = ModelBase<KuroSdkModel>.Instance.GetPlatformStr();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(67, 8);
			defaultInterpolatedStringHandler.AppendFormatted(rootUrl);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(packageLanguage);
			defaultInterpolatedStringHandler.AppendLiteral("/?login_info=");
			defaultInterpolatedStringHandler.AppendFormatted(value2);
			defaultInterpolatedStringHandler.AppendLiteral("&packageId=");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("&channelId=");
			defaultInterpolatedStringHandler.AppendFormatted(channelId);
			defaultInterpolatedStringHandler.AppendLiteral("&svr_area=");
			defaultInterpolatedStringHandler.AppendFormatted(value3);
			defaultInterpolatedStringHandler.AppendLiteral("&entryType=");
			defaultInterpolatedStringHandler.AppendFormatted(value4);
			defaultInterpolatedStringHandler.AppendLiteral("&platform=");
			defaultInterpolatedStringHandler.AppendFormatted(platformStr);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		case PublicUtil.EExternalUrlReason.CommonH5:
			return this.AppendPublicInfo(rootUrl, reason);
		case PublicUtil.EExternalUrlReason.MailH5:
			return this.AppendPublicInfo(rootUrl, reason);
		default:
			return null;
		}
	}

	// Token: 0x060058AF RID: 22703 RVA: 0x00107E24 File Offset: 0x00106024
	private string AppendPublicInfo(string rootUrl, PublicUtil.EExternalUrlReason reason)
	{
		string publicInfo = this.GetPublicInfo();
		string value = (!string.IsNullOrEmpty(this.OverridePackageId)) ? this.OverridePackageId : ControllerBase<KuroSdkController>.Instance.GetPackageId();
		string channelId = ControllerBase<KuroSdkController>.Instance.GetChannelId();
		string platformStr = ModelBase<KuroSdkModel>.Instance.GetPlatformStr();
		string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		string value2 = UKuroStaticLibrary.Base64Encode(publicInfo);
		string value3 = ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk() ? "global" : "cn";
		string value4 = "game";
		if (reason == PublicUtil.EExternalUrlReason.MailH5)
		{
			value4 = "mail";
		}
		string value5 = rootUrl.Contains("?") ? (rootUrl + "&") : (rootUrl + "?");
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(70, 8);
		defaultInterpolatedStringHandler.AppendFormatted(value5);
		defaultInterpolatedStringHandler.AppendLiteral("login_info=");
		defaultInterpolatedStringHandler.AppendFormatted(value2);
		defaultInterpolatedStringHandler.AppendLiteral("&packageId=");
		defaultInterpolatedStringHandler.AppendFormatted(value);
		defaultInterpolatedStringHandler.AppendLiteral("&channelId=");
		defaultInterpolatedStringHandler.AppendFormatted(channelId);
		defaultInterpolatedStringHandler.AppendLiteral("&platform=");
		defaultInterpolatedStringHandler.AppendFormatted(platformStr);
		defaultInterpolatedStringHandler.AppendLiteral("&lang=");
		defaultInterpolatedStringHandler.AppendFormatted(packageLanguage);
		defaultInterpolatedStringHandler.AppendLiteral("&entryType=");
		defaultInterpolatedStringHandler.AppendFormatted(value4);
		defaultInterpolatedStringHandler.AppendLiteral("&svr_area=");
		defaultInterpolatedStringHandler.AppendFormatted(value3);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060058B0 RID: 22704 RVA: 0x00107F7C File Offset: 0x0010617C
	public string GetExtendExternalUrl(string originUrl, bool isInternal = true)
	{
		if (string.IsNullOrWhiteSpace(originUrl))
		{
			return "";
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 2);
		defaultInterpolatedStringHandler.AppendFormatted(originUrl);
		defaultInterpolatedStringHandler.AppendLiteral("&isInternalBrowser=");
		defaultInterpolatedStringHandler.AppendFormatted<int>((isInternal > false) ? 1 : 0);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060058B1 RID: 22705 RVA: 0x00107FC8 File Offset: 0x001061C8
	public string GetLocalHost()
	{
		TArray<string> tarray = new TArray<string>();
		UKuroStaticLibrary.GetLocalHostAddresses(ref tarray, false);
		string result = "127.0.0.1";
		if (tarray.Num() > 0)
		{
			result = tarray.Get(0);
		}
		for (int i = 0; i < tarray.Num(); i++)
		{
			string text = tarray.Get(i);
			if (text.StartsWith("10.0."))
			{
				result = text;
			}
		}
		return result;
	}

	// Token: 0x060058B2 RID: 22706 RVA: 0x00108023 File Offset: 0x00106223
	public string GetConfigTextByKey(string key)
	{
		if (this.UseDbConfig())
		{
			return ConfigMultiTextLang.GetLocalTextNew(key, null) ?? key;
		}
		return Singleton<MultiTextCsvModule>.Instance.GetLocalText(key) ?? key;
	}

	// Token: 0x060058B3 RID: 22707 RVA: 0x0010804C File Offset: 0x0010624C
	[NullableContext(2)]
	public string GetConfigTextByTable(ETableText type, int? id)
	{
		string configIdByTable = this.GetConfigIdByTable(type, id);
		if (this.UseDbConfig())
		{
			return ConfigMultiTextLang.GetLocalTextNew(configIdByTable, null);
		}
		return Singleton<MultiTextCsvModule>.Instance.GetLocalText(configIdByTable);
	}

	// Token: 0x060058B4 RID: 22708 RVA: 0x00108080 File Offset: 0x00106280
	[NullableContext(2)]
	public string GetConfigTextByTable(ETableText type, string id)
	{
		string configIdByTable = this.GetConfigIdByTable(type, id);
		if (this.UseDbConfig())
		{
			return ConfigMultiTextLang.GetLocalTextNew(configIdByTable, null);
		}
		return Singleton<MultiTextCsvModule>.Instance.GetLocalText(configIdByTable);
	}

	// Token: 0x060058B5 RID: 22709 RVA: 0x001080B4 File Offset: 0x001062B4
	public string GetConfigIdByTable(ETableText type, int? id)
	{
		ValueTuple<string, string> valueTuple;
		if (!MultiTextDefine.tableTextMap.TryGetValue(type, out valueTuple))
		{
			return "";
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 3);
		defaultInterpolatedStringHandler.AppendFormatted(valueTuple.Item1);
		defaultInterpolatedStringHandler.AppendFormatted<int?>(id);
		defaultInterpolatedStringHandler.AppendFormatted(valueTuple.Item2);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060058B6 RID: 22710 RVA: 0x00108108 File Offset: 0x00106308
	public string GetConfigIdByTable(ETableText type, [Nullable(2)] string id)
	{
		ValueTuple<string, string> valueTuple;
		if (!MultiTextDefine.tableTextMap.TryGetValue(type, out valueTuple))
		{
			return "";
		}
		return valueTuple.Item1 + id + valueTuple.Item2;
	}

	// Token: 0x060058B7 RID: 22711 RVA: 0x0010813C File Offset: 0x0010633C
	[return: Nullable(2)]
	public string GetFlowConfigLocalText(string key)
	{
		if (this.UseDbConfig())
		{
			return ConfigMultiTextLang.GetLocalTextNew(key, null);
		}
		return Singleton<MultiTextCsvModule>.Instance.GetLocalText(key);
	}

	// Token: 0x060058B8 RID: 22712 RVA: 0x00108159 File Offset: 0x00106359
	public void RegisterEditorLocalConfig(bool isReload = false)
	{
		if (this.UseDbConfig())
		{
			return;
		}
		Singleton<MultiTextCsvModule>.Instance.RegisterTextLocalConfig(this.GetConfigPath("../Config/Raw/Tables/k.可视化编辑/__Temp__/Csv/TidText.csv"), isReload);
	}

	// Token: 0x060058B9 RID: 22713 RVA: 0x0010817C File Offset: 0x0010637C
	public unsafe void RegisterFlowTextLocalConfig(string configName)
	{
		if (this.UseDbConfig())
		{
			return;
		}
		string text = UKismetSystemLibrary.GetProjectDirectory() + "../Config/Raw/Tables/w.文本库/剧情";
		string text2 = "文本库_" + configName + ".csv";
		TArray<string> filesRecursive = UKuroStaticLibrary.GetFilesRecursive(text, text2, true, false);
		if (filesRecursive.Num() == 0)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.MultiTextCsvModule;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "无法找到对应文本库表格";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("文本库表格名字", text2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("目录路径", text);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		Singleton<MultiTextCsvModule>.Instance.RegisterTextLocalConfig(filesRecursive.Get(0), true);
	}

	// Token: 0x060058BA RID: 22714 RVA: 0x00108230 File Offset: 0x00106430
	[return: Nullable(2)]
	public IFlowListInfo GetFlowListInfo(string flowListName)
	{
		if (this.UseDbConfig())
		{
			return null;
		}
		string text = null;
		TArray<string> filesRecursive = UKuroStaticLibrary.GetFilesRecursive(this.GetConfigPath("../Config/Raw/Tables/k.可视化编辑/j.剧情"), flowListName + ".json", true, false);
		if (filesRecursive.Num() == 0)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Level;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "[ControllerHolder.PlotController.StartPlotNetwork] 无法找到对应剧情资源";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("flowListName", flowListName);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		string filename = filesRecursive.Get(0);
		UKuroStaticLibrary.LoadFileToString(ref text, filename);
		return Json.Decode<IFlowListInfo>(text, null);
	}

	// Token: 0x060058BB RID: 22715 RVA: 0x001082B0 File Offset: 0x001064B0
	[return: Nullable(2)]
	public SParkourConfig GetParkourConfig(string inConfigId)
	{
		return DataTableUtil.GetDataTableRowFromName<SParkourConfig>(EDataTable.Parkour, inConfigId);
	}

	// Token: 0x060058BC RID: 22716 RVA: 0x001082BA File Offset: 0x001064BA
	public bool IsUseTempData()
	{
		if (!GlobalData.IsPlayInEditor && !GlobalData.IsRunWithEditorStartConfig())
		{
			return false;
		}
		if (this.IsUseTemp == null)
		{
			this.GenerateEditorDebugServerConfig();
		}
		return this.IsUseTemp.GetValueOrDefault();
	}

	// Token: 0x060058BD RID: 22717 RVA: 0x001082EA File Offset: 0x001064EA
	public bool? IsStartEditorDebugServer()
	{
		if (!GlobalData.IsPlayInEditor && !GlobalData.IsRunWithEditorStartConfig())
		{
			return new bool?(false);
		}
		if (this.IsAutoStartDebugServer == null)
		{
			this.GenerateEditorDebugServerConfig();
		}
		return this.IsAutoStartDebugServer;
	}

	// Token: 0x060058BE RID: 22718 RVA: 0x0010831C File Offset: 0x0010651C
	public int? GetGameDebugPort()
	{
		if (!GlobalData.IsPlayInEditor && !GlobalData.IsRunWithEditorStartConfig())
		{
			return null;
		}
		if (this.GameDebugport == null)
		{
			this.GenerateEditorDebugServerConfig();
		}
		return this.GameDebugport;
	}

	// Token: 0x060058BF RID: 22719 RVA: 0x0010835C File Offset: 0x0010655C
	public int? GetEditorDebugPort()
	{
		if (!GlobalData.IsPlayInEditor && !GlobalData.IsRunWithEditorStartConfig())
		{
			return null;
		}
		if (this.EditorDebugPort == null)
		{
			this.GenerateEditorDebugServerConfig();
		}
		return this.EditorDebugPort;
	}

	// Token: 0x060058C0 RID: 22720 RVA: 0x0010839C File Offset: 0x0010659C
	private void GenerateEditorDebugServerConfig()
	{
		string text = UBlueprintPathsLibrary.ProjectDir() + "../Config/Raw/Tables/k.可视化编辑/__Temp__/EditorStartConfig.json";
		if (!UBlueprintPathsLibrary.FileExists(text))
		{
			this.IsUseTemp = new bool?(false);
			return;
		}
		string text2 = "";
		if (!UKuroStaticLibrary.LoadFileToString(ref text2, text))
		{
			this.IsUseTemp = new bool?(false);
			return;
		}
		AdaptEditorSaveConfig adaptEditorSaveConfig = Json.Decode<AdaptEditorSaveConfig>(text2, null);
		if (adaptEditorSaveConfig == null)
		{
			this.IsUseTemp = new bool?(false);
			return;
		}
		this.IsUseTemp = new bool?(adaptEditorSaveConfig.UseTemp);
		this.IsAutoStartDebugServer = new bool?(adaptEditorSaveConfig.IsOpenDebugService);
		this.GameDebugport = new int?(adaptEditorSaveConfig.GameClientGmPort);
		this.EditorDebugPort = new int?(adaptEditorSaveConfig.EditorPort);
	}

	// Token: 0x060058C1 RID: 22721 RVA: 0x00108448 File Offset: 0x00106648
	[NullableContext(2)]
	public AdaptEditorConfig TestLoadEditorConfigData()
	{
		string text = UBlueprintPathsLibrary.ProjectConfigDir() + "../Saved/Editor/JsonConfig/EditorConfig.json";
		if (!UBlueprintPathsLibrary.FileExists(text))
		{
			return null;
		}
		string text2 = "";
		if (!UKuroStaticLibrary.LoadFileToString(ref text2, text))
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Temp;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "读取本地文件配置失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", text);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		AdaptEditorConfig adaptEditorConfig = Json.Decode<AdaptEditorConfig>(text2, null);
		if (adaptEditorConfig == null)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Temp, ELogAuthor.CWZ, "读取本地文件配置失败, 反序列化失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return adaptEditorConfig;
	}

	// Token: 0x060058C2 RID: 22722 RVA: 0x001084D4 File Offset: 0x001066D4
	[NullableContext(2)]
	public AdaptEditorConfig TestSaveEditorConfigData(AdaptEditorConfig data = null)
	{
		if (data == null)
		{
			return null;
		}
		string text = Json.Stringify<AdaptEditorConfig>(data, null);
		if (text == null)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Temp, ELogAuthor.CWZ, "IEditorConfig反序列化失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return data;
		}
		string fileName = UBlueprintPathsLibrary.ProjectConfigDir() + "../Saved/Editor/JsonConfig/EditorConfig.json";
		UKuroStaticLibrary.SaveStringToFile(text, fileName, false);
		return data;
	}

	// Token: 0x060058C3 RID: 22723 RVA: 0x0010852C File Offset: 0x0010672C
	public bool UseDbConfig()
	{
		return !this.IsUseTempData();
	}

	// Token: 0x060058C4 RID: 22724 RVA: 0x00108537 File Offset: 0x00106737
	public void SetIsSilentLogin(bool value)
	{
		this.IsSilentLogin = value;
	}

	// Token: 0x060058C5 RID: 22725 RVA: 0x00108540 File Offset: 0x00106740
	public bool GetIsSilentLogin()
	{
		return this.IsSilentLogin;
	}

	// Token: 0x060058C6 RID: 22726 RVA: 0x00108548 File Offset: 0x00106748
	[NullableContext(2)]
	[return: Nullable(1)]
	public Transform CreateTransformFromConfig(IVector inPos = null, IVector inRot = null, IVector inScale = null)
	{
		Transform transform = Transform.Create();
		global::Vector location = global::Vector.Create((inPos != null) ? inPos.X : 0.0, (inPos != null) ? inPos.Y : 0.0, (inPos != null) ? inPos.Z : 0.0);
		Rotator rotator = Rotator.Create((float)((inRot != null) ? inRot.Y : 0.0), (float)((inRot != null) ? inRot.Z : 0.0), (float)((inRot != null) ? inRot.X : 0.0));
		global::Vector scale3D = global::Vector.Create((inScale != null) ? inScale.X : 0.0, (inScale != null) ? inScale.Y : 0.0, (inScale != null) ? inScale.Z : 0.0);
		transform.SetLocation(location);
		transform.SetRotation(rotator.Quaternion(null));
		transform.SetScale3D(scale3D);
		return transform;
	}

	// Token: 0x060058C7 RID: 22727 RVA: 0x00108640 File Offset: 0x00106840
	public List<string> GetFiles(string folderPath, [Nullable(2)] string containerStr)
	{
		TArray<string> filesRecursive = UKuroStaticLibrary.GetFilesRecursive(folderPath, "*.*", true, false);
		int num = filesRecursive.Num();
		List<string> list = new List<string>();
		for (int i = 0; i < num; i++)
		{
			string text = filesRecursive.Get(i);
			string fileNameWithoutExtension = this.GetFileNameWithoutExtension(text);
			if (string.IsNullOrEmpty(containerStr) || fileNameWithoutExtension.StartsWith(containerStr))
			{
				list.Add(text);
			}
		}
		return list;
	}

	// Token: 0x060058C8 RID: 22728 RVA: 0x001086A2 File Offset: 0x001068A2
	public string GetFileNameWithExtension(string file)
	{
		return UBlueprintPathsLibrary.GetCleanFilename(file);
	}

	// Token: 0x060058C9 RID: 22729 RVA: 0x001086AA File Offset: 0x001068AA
	public string GetFileNameWithoutExtension(string file)
	{
		return UBlueprintPathsLibrary.GetBaseFilename(file, true);
	}

	// Token: 0x0400293B RID: 10555
	private bool? IsUseTemp;

	// Token: 0x0400293C RID: 10556
	private bool? IsAutoStartDebugServer;

	// Token: 0x0400293D RID: 10557
	private int? EditorDebugPort;

	// Token: 0x0400293E RID: 10558
	private int? GameDebugport;

	// Token: 0x0400293F RID: 10559
	private readonly MultiTextCsvModule MultiTextCsvModule = new MultiTextCsvModule();

	// Token: 0x04002940 RID: 10560
	private const string PACKAGENAME = "com.kurogame.aki.internal";

	// Token: 0x04002941 RID: 10561
	private const string LOGIN_NOTICE = "LoginNotice.json";

	// Token: 0x04002942 RID: 10562
	private const string SCROLLTEXT_NOTICE = "ScrollTextNotice.json";

	// Token: 0x04002943 RID: 10563
	private bool IsSilentLogin;

	// Token: 0x04002944 RID: 10564
	public string OverridePackageId;

	// Token: 0x02007295 RID: 29333
	[NullableContext(0)]
	public enum EExternalUrlReason
	{
		// Token: 0x04027BE2 RID: 162786
		Mail,
		// Token: 0x04027BE3 RID: 162787
		InviteNewbie,
		// Token: 0x04027BE4 RID: 162788
		GameIntroduction,
		// Token: 0x04027BE5 RID: 162789
		CommonH5,
		// Token: 0x04027BE6 RID: 162790
		MailH5
	}
}
