using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;
using UnrealEngine;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044A4 RID: 17572
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LauncherLanguageLib : Singleton<LauncherLanguageLib>
	{
		// Token: 0x0602E545 RID: 189765 RVA: 0x00AE03E8 File Offset: 0x00ADE5E8
		protected override bool OnInit()
		{
			foreach (LaunchLangDefine launchLangDefine in this.LanguageList)
			{
				this.LanguageTypeMap[launchLangDefine.LanguageType] = launchLangDefine;
				this.LanguageCodeMap[launchLangDefine.LanguageCode] = launchLangDefine;
			}
			return true;
		}

		// Token: 0x17007FC1 RID: 32705
		// (get) Token: 0x0602E546 RID: 189766 RVA: 0x00AE045C File Offset: 0x00ADE65C
		// (set) Token: 0x0602E547 RID: 189767 RVA: 0x00AE0464 File Offset: 0x00ADE664
		[Nullable(2)]
		public string PackageLanguage
		{
			[NullableContext(2)]
			get
			{
				return this.PackageLanguageInternal;
			}
			[NullableContext(2)]
			private set
			{
				this.PackageLanguageInternal = value;
				ULGUIFontData.SetAllFontCurrentCulture(this.LanguageCultureMap[value]);
			}
		}

		// Token: 0x0602E548 RID: 189768 RVA: 0x00AE047E File Offset: 0x00ADE67E
		public string GetDefaultCulture(string currentCulture)
		{
			if (currentCulture.Contains("zh"))
			{
				return "zh-Hans";
			}
			return "en";
		}

		// Token: 0x0602E549 RID: 189769 RVA: 0x00AE0498 File Offset: 0x00ADE698
		private Dictionary<int, TValue> ObjToMap<[Nullable(0)] TKey, [Nullable(0)] TValue>(Dictionary<string, object> obj) where TKey : IConvertible where TValue : IConvertible
		{
			Dictionary<int, TValue> dictionary = new Dictionary<int, TValue>();
			foreach (KeyValuePair<string, object> keyValuePair in obj)
			{
				int key;
				if (int.TryParse(keyValuePair.Key, out key))
				{
					dictionary[key] = (TValue)((object)keyValuePair.Value);
				}
			}
			return dictionary;
		}

		// Token: 0x0602E54A RID: 189770 RVA: 0x00AE050C File Offset: 0x00ADE70C
		[NullableContext(2)]
		private Dictionary<int, double> LoadPlayMenuInfo()
		{
			int? global = Singleton<LauncherStorageLib>.Instance.GetGlobal<int?>(ELauncherStorageGlobalKey.TextLanguage, null);
			int? global2 = Singleton<LauncherStorageLib>.Instance.GetGlobal<int?>(ELauncherStorageGlobalKey.VoiceLanguage, null);
			if (global != null && global2 != null)
			{
				Dictionary<int, double> dictionary = new Dictionary<int, double>();
				dictionary[51] = (double)global.Value;
				dictionary[52] = (double)global2.Value;
				return dictionary;
			}
			Dictionary<int, double> global3 = Singleton<LauncherStorageLib>.Instance.GetGlobal<Dictionary<int, double>>(ELauncherStorageGlobalKey.MenuData, null);
			if (global3 == null)
			{
				string global4 = Singleton<LauncherStorageLib>.Instance.GetGlobal<string>(ELauncherStorageGlobalKey.PlayMenuInfo, string.Empty);
				if (!string.IsNullOrEmpty(global4))
				{
					return this.ObjToMap<int, double>(LauncherJson.Parse<Dictionary<string, object>>(global4, null));
				}
			}
			if (global3 != null)
			{
				Dictionary<int, double> dictionary2 = new Dictionary<int, double>();
				foreach (KeyValuePair<int, double> keyValuePair in global3)
				{
					dictionary2[keyValuePair.Key] = (double)((int)keyValuePair.Value);
				}
				return dictionary2;
			}
			return null;
		}

		// Token: 0x0602E54B RID: 189771 RVA: 0x00AE061C File Offset: 0x00ADE81C
		public unsafe void Initialize(bool bIsPlayerInEditor)
		{
			if (this.IsInit)
			{
				return;
			}
			this.IsInit = true;
			Dictionary<int, double> dictionary = this.LoadPlayMenuInfo();
			bool flag = dictionary != null;
			if (flag || bIsPlayerInEditor || UKuroLauncherLibrary.GetAppInternalUseType() == "Publication")
			{
				Dictionary<int, double> dictionary2;
				if (flag)
				{
					dictionary2 = dictionary;
				}
				else
				{
					dictionary2 = new Dictionary<int, double>();
					LauncherMenuConfig menuConfigByFunctionId = Singleton<LauncherConfigLib>.Instance.GetMenuConfigByFunctionId(51);
					dictionary2[51] = (double)((menuConfigByFunctionId != null) ? menuConfigByFunctionId.OptionsDefault : 0);
					LauncherMenuConfig menuConfigByFunctionId2 = Singleton<LauncherConfigLib>.Instance.GetMenuConfigByFunctionId(52);
					dictionary2[52] = (double)((menuConfigByFunctionId2 != null) ? menuConfigByFunctionId2.OptionsDefault : 0);
				}
				double num = dictionary2[51];
				LaunchLangDefine languageDefineByType = this.GetLanguageDefineByType((int)num);
				this.PackageLanguage = ((languageDefineByType != null) ? languageDefineByType.LanguageCode : "en");
				double num2 = dictionary2[52];
				LaunchLangDefine languageDefineByType2 = this.GetLanguageDefineByType((int)num2);
				this.PackageAudioLanguage = ((languageDefineByType2 != null) ? languageDefineByType2.AudioCode : "en");
				return;
			}
			string text = UKismetSystemLibrary.GetDefaultLanguage().ToString();
			string defaultCulture = this.GetDefaultCulture(text);
			TArray<string> tarray = new TArray<string>();
			for (int i = 0; i < this.AVAILABLE_LANGUAGES.Length; i++)
			{
				tarray.Add(this.AVAILABLE_LANGUAGES[i]);
			}
			string text2 = UKismetInternationalizationLibrary.GetSuitableCulture(tarray, text, defaultCulture).ToString();
			bool flag2 = Singleton<LauncherConfigLib>.Instance.IsLanguageValid(text2);
			text2 = (flag2 ? text2 : this.GetDefaultCulture(text2));
			if (!flag2)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "当前语种表格配置不允许生效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("targetLanguage", text2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("currentCulture", text);
				instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "从本地获取语言配置失败，使用平台的配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("targetLanguage", text2);
			instance2.Warn(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			LaunchLangDefine languageDefineByCode = this.GetLanguageDefineByCode(text2);
			if (languageDefineByCode == null)
			{
				this.PackageLanguage = "en";
				this.PackageAudioLanguage = "zh";
				return;
			}
			this.PackageLanguage = languageDefineByCode.LanguageCode;
			this.PackageAudioLanguage = languageDefineByCode.AudioCode;
		}

		// Token: 0x0602E54C RID: 189772 RVA: 0x00AE0842 File Offset: 0x00ADEA42
		[NullableContext(2)]
		public string GetPackageLanguage()
		{
			return this.PackageLanguageInternal;
		}

		// Token: 0x0602E54D RID: 189773 RVA: 0x00AE084A File Offset: 0x00ADEA4A
		public void SetPackageLanguage(string language)
		{
			this.PackageLanguageInternal = language;
		}

		// Token: 0x0602E54E RID: 189774 RVA: 0x00AE0853 File Offset: 0x00ADEA53
		[NullableContext(2)]
		public string GetPackageAudioLanguage()
		{
			return this.PackageAudioLanguage;
		}

		// Token: 0x0602E54F RID: 189775 RVA: 0x00AE085B File Offset: 0x00ADEA5B
		public IReadOnlyList<LaunchLangDefine> GetAllLanguageDefines()
		{
			return this.LanguageList;
		}

		// Token: 0x0602E550 RID: 189776 RVA: 0x00AE0864 File Offset: 0x00ADEA64
		[NullableContext(2)]
		public LaunchLangDefine GetLanguageDefineByType(int type)
		{
			LaunchLangDefine result;
			if (!this.LanguageTypeMap.TryGetValue(type, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0602E551 RID: 189777 RVA: 0x00AE0884 File Offset: 0x00ADEA84
		[return: Nullable(2)]
		public LaunchLangDefine GetLanguageDefineByCode(string code)
		{
			LaunchLangDefine result;
			if (!this.LanguageCodeMap.TryGetValue(code, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0602E552 RID: 189778 RVA: 0x00AE08A4 File Offset: 0x00ADEAA4
		public List<string> GetUsedAudioCodes()
		{
			HashSet<string> hashSet = new HashSet<string>();
			string packageAudioLanguage = this.GetPackageAudioLanguage();
			if (packageAudioLanguage != null)
			{
				hashSet.Add(packageAudioLanguage);
			}
			HashSet<string> hashSet2 = new HashSet<string>();
			foreach (LaunchLangDefine launchLangDefine in this.LanguageList)
			{
				if (!hashSet2.Contains(launchLangDefine.AudioCode))
				{
					hashSet2.Add(launchLangDefine.AudioCode);
					string key = "UseLanguage_" + launchLangDefine.AudioCode;
					string deviceSavedString = Singleton<LauncherStorageLib>.Instance.GetDeviceSavedString(key, "");
					if (!string.IsNullOrEmpty(deviceSavedString) && deviceSavedString.Trim().Length > 0)
					{
						hashSet.Add(launchLangDefine.AudioCode);
					}
				}
			}
			List<string> list = new List<string>(hashSet);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "GetUsedAudioCodes";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("usedAudioCodes", string.Join(",", list));
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return list;
		}

		// Token: 0x0602E553 RID: 189779 RVA: 0x00AE09B0 File Offset: 0x00ADEBB0
		public LauncherLanguageLib()
		{
			Dictionary<string, Culture> dictionary = new Dictionary<string, Culture>();
			dictionary["zh-Hans"] = Culture.zh_Hans;
			dictionary["en"] = Culture.en;
			dictionary["ja"] = Culture.ja;
			dictionary["ko"] = Culture.ko;
			dictionary["ru"] = Culture.ru;
			dictionary["zh-Hant"] = Culture.zh_Hant;
			dictionary["de"] = Culture.de;
			dictionary["es"] = Culture.es;
			dictionary["pt"] = Culture.pt;
			dictionary["id"] = Culture.id;
			dictionary["fr"] = Culture.fr;
			dictionary["vi"] = Culture.vi;
			dictionary["th"] = Culture.th;
			this.LanguageCultureMap = dictionary;
			this.LanguageTypeMap = new Dictionary<int, LaunchLangDefine>();
			this.LanguageCodeMap = new Dictionary<string, LaunchLangDefine>();
			base..ctor();
		}

		// Token: 0x0401A504 RID: 107780
		private const int TEXTLANGUAGE = 51;

		// Token: 0x0401A505 RID: 107781
		private const int VOICELANGUAGE = 52;

		// Token: 0x0401A506 RID: 107782
		private const string CHS = "zh-Hans";

		// Token: 0x0401A507 RID: 107783
		private const string CHT = "zh-Hant";

		// Token: 0x0401A508 RID: 107784
		private const string CHINESE_ISO639_1 = "zh";

		// Token: 0x0401A509 RID: 107785
		public const string ENGLISH_ISO639_1 = "en";

		// Token: 0x0401A50A RID: 107786
		private const string JAPANESE_ISO639_1 = "ja";

		// Token: 0x0401A50B RID: 107787
		public const string KOREAN_ISO639_1 = "ko";

		// Token: 0x0401A50C RID: 107788
		private const string RUSSIA_ISO639_1 = "ru";

		// Token: 0x0401A50D RID: 107789
		private const string GERMANY_ISO639_1 = "de";

		// Token: 0x0401A50E RID: 107790
		private const string SPAIN_ISO639_1 = "es";

		// Token: 0x0401A50F RID: 107791
		private const string PORTUGAL_ISO639_1 = "pt";

		// Token: 0x0401A510 RID: 107792
		private const string INDONESIA_ISO639_1 = "id";

		// Token: 0x0401A511 RID: 107793
		private const string FRANCE_ISO639_1 = "fr";

		// Token: 0x0401A512 RID: 107794
		private const string VIETNAM_ISO639_1 = "vi";

		// Token: 0x0401A513 RID: 107795
		private const string THAILAND_ISO639_1 = "th";

		// Token: 0x0401A514 RID: 107796
		private readonly string[] AVAILABLE_LANGUAGES = new string[]
		{
			"zh-Hans",
			"en",
			"ja",
			"ko",
			"ru",
			"zh-Hant",
			"de",
			"es",
			"pt",
			"id",
			"fr",
			"vi",
			"th"
		};

		// Token: 0x0401A515 RID: 107797
		private const string CHS_AUDIO = "zh";

		// Token: 0x0401A516 RID: 107798
		private const string PUBLICATION_TYPE = "Publication";

		// Token: 0x0401A517 RID: 107799
		private readonly List<LaunchLangDefine> LanguageList = new List<LaunchLangDefine>
		{
			new LaunchLangDefine(0, "zh-Hans", "zh"),
			new LaunchLangDefine(1, "en", "en"),
			new LaunchLangDefine(2, "ja", "ja"),
			new LaunchLangDefine(3, "ko", "ko"),
			new LaunchLangDefine(4, "ru", "en"),
			new LaunchLangDefine(5, "zh-Hant", "zh"),
			new LaunchLangDefine(6, "de", "en"),
			new LaunchLangDefine(7, "es", "en"),
			new LaunchLangDefine(8, "pt", "en"),
			new LaunchLangDefine(9, "id", "en"),
			new LaunchLangDefine(10, "fr", "en"),
			new LaunchLangDefine(11, "vi", "en"),
			new LaunchLangDefine(12, "th", "en")
		};

		// Token: 0x0401A518 RID: 107800
		public readonly Dictionary<string, Culture> LanguageCultureMap;

		// Token: 0x0401A519 RID: 107801
		private readonly Dictionary<int, LaunchLangDefine> LanguageTypeMap;

		// Token: 0x0401A51A RID: 107802
		private readonly Dictionary<string, LaunchLangDefine> LanguageCodeMap;

		// Token: 0x0401A51B RID: 107803
		[Nullable(2)]
		private string PackageLanguageInternal;

		// Token: 0x0401A51C RID: 107804
		[Nullable(2)]
		private string PackageAudioLanguage;

		// Token: 0x0401A51D RID: 107805
		private bool IsInit;
	}
}
