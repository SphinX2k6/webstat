using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Common.Proxy;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Launcher.Platform.PlatformSdk;
using CSharpScript.Launcher.Util;
using UnrealEngine;

// Token: 0x02000044 RID: 68
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class LanguageSystem : Singleton<global::LanguageSystem>, ILanguageSystemProxy
{
	// Token: 0x06000107 RID: 263 RVA: 0x00007704 File Offset: 0x00005904
	protected override bool OnInit()
	{
		foreach (global::LanguageDefine languageDefine in this.languageList)
		{
			this.languageTypeMap[languageDefine.LanguageType] = languageDefine;
			this.languageCodeMap[languageDefine.LanguageCode] = languageDefine;
		}
		return true;
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x06000108 RID: 264 RVA: 0x00007778 File Offset: 0x00005978
	// (set) Token: 0x06000109 RID: 265 RVA: 0x00007780 File Offset: 0x00005980
	public bool GmShowLanguageKey { get; set; }

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x0600010A RID: 266 RVA: 0x00007789 File Offset: 0x00005989
	// (set) Token: 0x0600010B RID: 267 RVA: 0x00007791 File Offset: 0x00005991
	public string GmReplaceTextContent { get; set; }

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x0600010C RID: 268 RVA: 0x0000779A File Offset: 0x0000599A
	// (set) Token: 0x0600010D RID: 269 RVA: 0x000077B8 File Offset: 0x000059B8
	public string PackageLanguage
	{
		get
		{
			if (string.IsNullOrEmpty(this.PackageLanguageInternal))
			{
				return "zh-Hans";
			}
			return this.PackageLanguageInternal;
		}
		set
		{
			string packageLanguageInternal = this.PackageLanguageInternal;
			this.PackageLanguageInternal = value;
			UKuroVariableFunctionLibrary.RemoveStringValue("PackageLanguage");
			UKuroVariableFunctionLibrary.SetStringValue("PackageLanguage", value);
			ULGUIFontData.SetAllFontCurrentCulture(this.languageCultureMap.GetValueOrDefault(value, Culture.zh_Hans));
			if (!Singleton<Info>.Instance.IsPlayInEditor)
			{
				UKismetInternationalizationLibrary.SetCurrentCulture(value, true);
			}
			if (value != packageLanguageInternal)
			{
				UUIText.OnTsLanguageChange();
				global::LanguageDefine valueOrDefault = this.languageCodeMap.GetValueOrDefault(value);
				UUILangTexture.NotifyLanguageChange((valueOrDefault != null) ? ((ELangTextureLanguageType)valueOrDefault.LanguageType) : ELangTextureLanguageType.En);
			}
			if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
			{
				Singleton<PlatformSdkServer>.Instance.SetLanguage(value);
			}
			Singleton<LauncherLanguageLib>.Instance.SetPackageLanguage(value);
		}
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x0600010E RID: 270 RVA: 0x00007860 File Offset: 0x00005A60
	public string PackageAudio
	{
		get
		{
			if (string.IsNullOrEmpty(this.PackageLanguageInternal))
			{
				return "zh";
			}
			return this.PackageAudioInternal;
		}
	}

	// Token: 0x0600010F RID: 271 RVA: 0x0000787C File Offset: 0x00005A7C
	public unsafe void SetPackageAudio(string audioCode, UObject worldContext)
	{
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.GameSettings;
		ELogAuthor author = ELogAuthor.WZ;
		string message = "开始设置音频语种，对应【SetCurrentAudioCultureAsync】";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Code", audioCode);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.PackageAudioInternal = audioCode;
		Action<bool> callback = null;
		callback = delegate(bool success)
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Config;
			ELogAuthor author2 = ELogAuthor.MZJ;
			string message2 = "SetCurrentAudioCultureAsync";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Success", success);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Code", audioCode);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (callback != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(callback);
			}
			if (success)
			{
				Singleton<AudioSystem>.Instance.SetState("language", audioCode, true);
			}
		};
		string audioCode2 = audioCode;
		FOnSetCurrentAudioCultureCallback fonSetCurrentAudioCultureCallback = global::DelegateUtils.ToManualReleaseDelegate<FOnSetCurrentAudioCultureCallback>(callback);
		UAkGameplayStatics.SetCurrentAudioCultureAsync(audioCode2, fonSetCurrentAudioCultureCallback);
	}

	// Token: 0x06000110 RID: 272 RVA: 0x00007903 File Offset: 0x00005B03
	private string GetDefaultCulture(string currentCulture)
	{
		if (currentCulture.Contains("zh"))
		{
			return "zh-Hans";
		}
		return "en";
	}

	// Token: 0x06000111 RID: 273 RVA: 0x00007920 File Offset: 0x00005B20
	public unsafe void FirstTimeSetLanguage(UObject worldContext)
	{
		string defaultLanguage = UKismetSystemLibrary.GetDefaultLanguage();
		TArray<string> tarray = new TArray<string>();
		foreach (string value in CommonDefine.AVAILABLE_LANGUAGES)
		{
			tarray.Add(value);
		}
		string defaultCulture = this.GetDefaultCulture(defaultLanguage);
		string text = UKismetInternationalizationLibrary.GetSuitableCulture(tarray, defaultLanguage, defaultCulture);
		Aki.Config.LanguageDefine? config = ConfigLanguageDefineByLanguageCode.GetConfig(text, true);
		bool flag = config != null && config.GetValueOrDefault().IsShow;
		text = (flag ? text : this.GetDefaultCulture(text));
		if (!flag)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "当前语种表格配置不允许生效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("targetLanguage", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("currentCulture", defaultLanguage);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module2 = ELogModule.Config;
		ELogAuthor author2 = ELogAuthor.MZJ;
		string message2 = "第一次设置语言";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("设备默认语言", defaultLanguage);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("查找不到时匹配默认语言", defaultCulture);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("最合适语言", text);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		global::LanguageDefine languageDefine = this.languageCodeMap.ContainsKey(text) ? this.languageCodeMap[text] : null;
		if (languageDefine == null)
		{
			global::Log instance3 = Singleton<global::Log>.Instance;
			ELogModule module3 = ELogModule.Config;
			ELogAuthor author3 = ELogAuthor.MZJ;
			string message3 = "设置系统找不到配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("语种识别码", text);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.PackageLanguage = "en";
			return;
		}
		global::Log instance4 = Singleton<global::Log>.Instance;
		ELogModule module4 = ELogModule.Config;
		ELogAuthor author4 = ELogAuthor.MZJ;
		string message4 = "FirstTimeSetLanguage";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Text", languageDefine.LanguageCode);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Audio", languageDefine.AudioCode);
		instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
		this.PackageLanguage = languageDefine.LanguageCode;
	}

	// Token: 0x06000112 RID: 274 RVA: 0x00007B29 File Offset: 0x00005D29
	public List<global::LanguageDefine> GetAllLanguageDefines()
	{
		return this.languageList;
	}

	// Token: 0x06000113 RID: 275 RVA: 0x00007B31 File Offset: 0x00005D31
	public global::LanguageDefine GetLanguageDefineByType(int type)
	{
		return this.languageTypeMap[type];
	}

	// Token: 0x06000114 RID: 276 RVA: 0x00007B3F File Offset: 0x00005D3F
	public global::LanguageDefine GetLanguageDefineByCode(string code)
	{
		return this.languageCodeMap[code];
	}

	// Token: 0x06000115 RID: 277 RVA: 0x00007B4D File Offset: 0x00005D4D
	public string GetCultureOrDefault([Nullable(2)] string culture)
	{
		if (!string.IsNullOrEmpty(culture))
		{
			return culture;
		}
		return this.PackageLanguage;
	}

	// Token: 0x06000116 RID: 278 RVA: 0x00007B5F File Offset: 0x00005D5F
	public ESpeechType GetSpeechTypeByLanguageType(ELanguageType languageType)
	{
		return this.languageSpeechMapping[languageType];
	}

	// Token: 0x06000117 RID: 279 RVA: 0x00007B70 File Offset: 0x00005D70
	public int GetLanguageTypeByAudioCode(string audioCode)
	{
		foreach (global::LanguageDefine languageDefine in this.languageList)
		{
			if (languageDefine.AudioCode == audioCode)
			{
				return languageDefine.LanguageType;
			}
		}
		return 0;
	}

	// Token: 0x06000118 RID: 280 RVA: 0x00007BD8 File Offset: 0x00005DD8
	public LanguageSystem()
	{
		Dictionary<ELanguageType, ESpeechType> dictionary = new Dictionary<ELanguageType, ESpeechType>();
		dictionary[ELanguageType.Zh] = ESpeechType.Zh;
		dictionary[ELanguageType.En] = ESpeechType.En;
		dictionary[ELanguageType.Ja] = ESpeechType.Ja;
		dictionary[ELanguageType.Ko] = ESpeechType.Ko;
		dictionary[ELanguageType.Ru] = ESpeechType.En;
		dictionary[ELanguageType.Zht] = ESpeechType.Zh;
		dictionary[ELanguageType.De] = ESpeechType.En;
		dictionary[ELanguageType.Es] = ESpeechType.En;
		dictionary[ELanguageType.Pt] = ESpeechType.En;
		dictionary[ELanguageType.Id] = ESpeechType.En;
		dictionary[ELanguageType.Fr] = ESpeechType.En;
		dictionary[ELanguageType.Vi] = ESpeechType.En;
		dictionary[ELanguageType.Th] = ESpeechType.En;
		this.languageSpeechMapping = dictionary;
		this.languageList = new List<global::LanguageDefine>
		{
			new global::LanguageDefine(0, "zh-Hans", "zh"),
			new global::LanguageDefine(1, "en", "en"),
			new global::LanguageDefine(2, "ja", "ja"),
			new global::LanguageDefine(3, "ko", "ko"),
			new global::LanguageDefine(4, "ru", "en"),
			new global::LanguageDefine(5, "zh-Hant", "zh"),
			new global::LanguageDefine(6, "de", "en"),
			new global::LanguageDefine(7, "es", "en"),
			new global::LanguageDefine(8, "pt", "en"),
			new global::LanguageDefine(9, "id", "en"),
			new global::LanguageDefine(10, "fr", "en"),
			new global::LanguageDefine(11, "vi", "en"),
			new global::LanguageDefine(12, "th", "en")
		};
		Dictionary<string, Culture> dictionary2 = new Dictionary<string, Culture>();
		dictionary2["zh-Hans"] = Culture.zh_Hans;
		dictionary2["en"] = Culture.en;
		dictionary2["ja"] = Culture.ja;
		dictionary2["ko"] = Culture.ko;
		dictionary2["ru"] = Culture.ru;
		dictionary2["zh-Hant"] = Culture.zh_Hant;
		dictionary2["de"] = Culture.de;
		dictionary2["es"] = Culture.es;
		dictionary2["pt"] = Culture.pt;
		dictionary2["id"] = Culture.id;
		dictionary2["fr"] = Culture.fr;
		dictionary2["vi"] = Culture.vi;
		dictionary2["th"] = Culture.th;
		this.languageCultureMap = dictionary2;
		this.languageTypeMap = new Dictionary<int, global::LanguageDefine>();
		this.languageCodeMap = new Dictionary<string, global::LanguageDefine>();
		this.GmReplaceTextContent = "";
		base..ctor();
	}

	// Token: 0x0400010B RID: 267
	public readonly Dictionary<ELanguageType, ESpeechType> languageSpeechMapping;

	// Token: 0x0400010C RID: 268
	private readonly List<global::LanguageDefine> languageList;

	// Token: 0x0400010D RID: 269
	public readonly Dictionary<string, Culture> languageCultureMap;

	// Token: 0x0400010E RID: 270
	private readonly Dictionary<int, global::LanguageDefine> languageTypeMap;

	// Token: 0x0400010F RID: 271
	private readonly Dictionary<string, global::LanguageDefine> languageCodeMap;

	// Token: 0x04000112 RID: 274
	private string PackageLanguageInternal;

	// Token: 0x04000113 RID: 275
	private string PackageAudioInternal;
}
