using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiNavigation;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Platform.PlatformSdk;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000EEA RID: 3818
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class KuroSdkModel : ModelBase<KuroSdkModel>
{
	// Token: 0x06005E25 RID: 24101 RVA: 0x00178534 File Offset: 0x00176734
	public KuroSdkModel()
	{
		this.ReportedInitState = false;
		this.QueryProductInfoMap = new Dictionary<string, QueryProductSt>();
		this.SdkTrophyInfoMap = new Dictionary<string, ISdkTrophyInfo>();
		this.CanUseSdk = false;
		this.CurrentPayItemName = "";
		this.SdkGetFocusState = false;
		this.SdkBlockUserMap = new Dictionary<string, bool>();
		this.GetSdkBlockUserState = false;
		this.PlayStationPlayOnlyState = false;
		this.CurrentProgressActivityIndex = -1;
		this.CurrentPayingOrderId = "";
		this.NeedOpenReviewState = false;
		this.ReviewDelay = 0;
		this.CurrentReviewId = 0;
		this.NeedReviewConfirmBox = false;
		this.NoticeRedDotState = false;
		this.NoticeSign = "1";
	}

	// Token: 0x06005E26 RID: 24102 RVA: 0x001785F8 File Offset: 0x001767F8
	protected override bool OnInit()
	{
		this.CanUseSdk = (UKuroStaticLibrary.IsModuleLoaded("KuroSDK") && Singleton<BaseConfigController>.Instance.GetPublicValue("UseSDK") == "1");
		Singleton<KuroSdkReport>.Instance.Init();
		this.InitSdkTrophyInfo();
		this.InitProgressActivityList();
		return true;
	}

	// Token: 0x06005E27 RID: 24103 RVA: 0x0017864B File Offset: 0x0017684B
	public void OnGetSdkBlockUserMap(Dictionary<string, bool> blockUserMap)
	{
		this.SdkBlockUserMap = blockUserMap;
		this.GetSdkBlockUserState = true;
	}

	// Token: 0x06005E28 RID: 24104 RVA: 0x0017865C File Offset: 0x0017685C
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public UniTask<Dictionary<string, bool>> GetSdkBlockUserMap()
	{
		KuroSdkModel.<GetSdkBlockUserMap>d__38 <GetSdkBlockUserMap>d__;
		<GetSdkBlockUserMap>d__.<>t__builder = AsyncUniTaskMethodBuilder<Dictionary<string, bool>>.Create();
		<GetSdkBlockUserMap>d__.<>4__this = this;
		<GetSdkBlockUserMap>d__.<>1__state = -1;
		<GetSdkBlockUserMap>d__.<>t__builder.Start<KuroSdkModel.<GetSdkBlockUserMap>d__38>(ref <GetSdkBlockUserMap>d__);
		return <GetSdkBlockUserMap>d__.<>t__builder.Task;
	}

	// Token: 0x06005E29 RID: 24105 RVA: 0x001786A0 File Offset: 0x001768A0
	private UniTask InitSdkTrophyInfo()
	{
		KuroSdkModel.<InitSdkTrophyInfo>d__39 <InitSdkTrophyInfo>d__;
		<InitSdkTrophyInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSdkTrophyInfo>d__.<>4__this = this;
		<InitSdkTrophyInfo>d__.<>1__state = -1;
		<InitSdkTrophyInfo>d__.<>t__builder.Start<KuroSdkModel.<InitSdkTrophyInfo>d__39>(ref <InitSdkTrophyInfo>d__);
		return <InitSdkTrophyInfo>d__.<>t__builder.Task;
	}

	// Token: 0x06005E2A RID: 24106 RVA: 0x001786E3 File Offset: 0x001768E3
	public Dictionary<string, ISdkTrophyInfo> GetSdkTrophyInfo()
	{
		return this.SdkTrophyInfoMap;
	}

	// Token: 0x06005E2B RID: 24107 RVA: 0x001786EC File Offset: 0x001768EC
	public void InitProgressActivityList()
	{
		IReadOnlyList<PlayStationActivityConfig> configList = ConfigPlayStationActivityConfigAll.GetConfigList(true);
		if (configList == null || configList.Count == 0)
		{
			return;
		}
		int count = configList.Count;
		this.ProgressActivityList = new PlayStationActivityConfig[count];
		for (int i = 0; i < count; i++)
		{
			this.ProgressActivityList[i] = configList[i];
		}
	}

	// Token: 0x06005E2C RID: 24108 RVA: 0x00178740 File Offset: 0x00176940
	public void UpdateActivityProgress(int currentFinishQuestId = 0)
	{
		bool flag = false;
		int nextProgressActivityQuestId = this.GetNextProgressActivityQuestId();
		if (currentFinishQuestId == 0 || (currentFinishQuestId != 0 && currentFinishQuestId == nextProgressActivityQuestId))
		{
			flag = true;
		}
		bool flag2 = false;
		if (flag)
		{
			int currentProgressActivityIndex = this.CurrentProgressActivityIndex;
			flag2 = this.UpdateDynamicActivityProgress(currentProgressActivityIndex);
		}
		bool flag3 = this.UpdateStaticActivityProgress();
		if (flag2 || flag3)
		{
			this.UpdateActivityAvailability();
		}
	}

	// Token: 0x06005E2D RID: 24109 RVA: 0x0017878C File Offset: 0x0017698C
	private bool UpdateStaticActivityProgress()
	{
		IReadOnlyList<PlayStationStaticActivity> configList = ConfigPlayStationStaticActivityAll.GetConfigList(true);
		if (configList == null || configList.Count == 0)
		{
			return false;
		}
		bool result = false;
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
		foreach (PlayStationStaticActivity playStationStaticActivity in configList)
		{
			if (instance.CheckQuestFinished(playStationStaticActivity.QuestId) && !this.CurrentOpeningStaticActivityList.Contains(playStationStaticActivity.ActivityStringId))
			{
				platformSdk.StartActivity(playStationStaticActivity.ActivityStringId);
				if (!this.CurrentOpeningStaticActivityList.Contains(playStationStaticActivity.ActivityStringId))
				{
					this.CurrentOpeningStaticActivityList.Add(playStationStaticActivity.ActivityStringId);
					result = true;
				}
			}
		}
		return result;
	}

	// Token: 0x06005E2E RID: 24110 RVA: 0x00178854 File Offset: 0x00176A54
	private bool UpdateDynamicActivityProgress(int oldCurrentProgressActivityIndex)
	{
		if (this.ProgressActivityList == null)
		{
			return false;
		}
		int num = this.ProgressActivityList.Length;
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
		int num2 = this.CurrentProgressActivityIndex;
		for (int i = num2 + 1; i < num; i++)
		{
			PlayStationActivityConfig playStationActivityConfig = this.ProgressActivityList[num2];
			PlayStationActivityConfig playStationActivityConfig2 = this.ProgressActivityList[i];
			if (playStationActivityConfig2.QuestId != 0 && !instance.CheckQuestFinished(playStationActivityConfig2.QuestId))
			{
				break;
			}
			platformSdk.EndActivity(playStationActivityConfig.ActivityStringId);
			platformSdk.StartActivity(playStationActivityConfig2.ActivityStringId);
			this.CurrentProgressActivityIndex = i;
			num2++;
		}
		return oldCurrentProgressActivityIndex != this.CurrentProgressActivityIndex;
	}

	// Token: 0x06005E2F RID: 24111 RVA: 0x00178908 File Offset: 0x00176B08
	public void UpdateActivityAvailability()
	{
		if (this.ProgressActivityList == null || this.CurrentProgressActivityIndex < 0 || this.CurrentProgressActivityIndex >= this.ProgressActivityList.Length)
		{
			return;
		}
		TArray<string> tarray = new TArray<string>();
		TArray<string> tarray2 = new TArray<string>();
		for (int i = 0; i < this.ProgressActivityList.Length; i++)
		{
			if (i == this.CurrentProgressActivityIndex)
			{
				tarray.Add(this.ProgressActivityList[i].ActivityStringId);
			}
			else
			{
				string activityStringId = this.ProgressActivityList[i].ActivityStringId;
				if (!this.CurrentOpeningStaticActivityList.Contains(activityStringId))
				{
					tarray2.Add(activityStringId);
				}
			}
		}
		foreach (string value in this.CurrentOpeningStaticActivityList)
		{
			if (!tarray.Contains(value))
			{
				tarray.Add(value);
			}
		}
		Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ChangeActivityAvailability(tarray, tarray2);
	}

	// Token: 0x06005E30 RID: 24112 RVA: 0x00178A04 File Offset: 0x00176C04
	public int GetNextProgressActivityQuestId()
	{
		if (this.ProgressActivityList == null || this.CurrentProgressActivityIndex < 0 || this.CurrentProgressActivityIndex + 1 >= this.ProgressActivityList.Length)
		{
			return -1;
		}
		return this.ProgressActivityList[this.CurrentProgressActivityIndex + 1].QuestId;
	}

	// Token: 0x06005E31 RID: 24113 RVA: 0x00178A44 File Offset: 0x00176C44
	public void OnQueryProductInfo([Nullable(new byte[]
	{
		2,
		1
	})] QueryProductSt[] data)
	{
		if (data != null)
		{
			foreach (QueryProductSt queryProductSt in data)
			{
				if (queryProductSt.GoodId != null)
				{
					this.QueryProductInfoMap[queryProductSt.GoodId] = queryProductSt;
				}
			}
		}
		CustomPromise<bool> queryPromise = this.QueryPromise;
		if (queryPromise != null)
		{
			queryPromise.SetResult(true);
		}
		this.QueryPromise = null;
	}

	// Token: 0x06005E32 RID: 24114 RVA: 0x00178A9C File Offset: 0x00176C9C
	public string GetQueryProductCurrency(string payId)
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return "";
		}
		Pay? payConf = ConfigBase<PayItemConfig>.Instance.GetPayConf(int.Parse(payId));
		QueryProductSt queryProductSt;
		if (payConf != null && this.QueryProductInfoMap.TryGetValue(payConf.Value.ProductId, out queryProductSt) && !string.IsNullOrEmpty(queryProductSt.Currency))
		{
			return queryProductSt.Currency;
		}
		return "";
	}

	// Token: 0x06005E33 RID: 24115 RVA: 0x00178B0C File Offset: 0x00176D0C
	public float GetQueryProductPrice(string payId)
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Pay? pay;
			string text = (ConfigBase<PayItemConfig>.Instance.GetPayConf(int.Parse(payId)) != null) ? pay.GetValueOrDefault().ProductId : null;
			DisplayProductInfo productInfoByGoodsId = ModelBase<PayItemModel>.Instance.GetProductInfoByGoodsId(text ?? "");
			float result;
			if (productInfoByGoodsId != null && productInfoByGoodsId.Price != null && float.TryParse(productInfoByGoodsId.Price, out result))
			{
				return result;
			}
			return 0f;
		}
		else
		{
			Pay? payConf = ConfigBase<PayItemConfig>.Instance.GetPayConf(int.Parse(payId));
			QueryProductSt queryProductSt;
			if (payConf != null && this.QueryProductInfoMap.TryGetValue(payConf.Value.ProductId, out queryProductSt) && queryProductSt.Price != null)
			{
				return queryProductSt.Price.Value;
			}
			return 0f;
		}
	}

	// Token: 0x06005E34 RID: 24116 RVA: 0x00178BE4 File Offset: 0x00176DE4
	[return: Nullable(2)]
	public string GetQueryProductShowPrice(string payId)
	{
		if (!Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Pay? payConf = ConfigBase<PayItemConfig>.Instance.GetPayConf(int.Parse(payId));
			QueryProductSt queryProductSt;
			if (payConf != null && this.QueryProductInfoMap.TryGetValue(payConf.Value.ProductId, out queryProductSt) && !string.IsNullOrEmpty(queryProductSt.Currency) && queryProductSt.Price != null)
			{
				float? price = queryProductSt.Price;
				float num = 0f;
				if (!(price.GetValueOrDefault() == num & price != null))
				{
					string currency = queryProductSt.Currency;
					price = queryProductSt.Price;
					return currency + price.ToString();
				}
			}
			return null;
		}
		Pay? pay;
		string goodsId = (ConfigBase<PayItemConfig>.Instance.GetPayConf(int.Parse(payId)) != null) ? pay.GetValueOrDefault().ProductId : null;
		DisplayProductInfo productInfoByGoodsId = ModelBase<PayItemModel>.Instance.GetProductInfoByGoodsId(goodsId);
		if (productInfoByGoodsId != null)
		{
			return productInfoByGoodsId.Price;
		}
		if (!Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetIfShowDefaultPrice())
		{
			return " ";
		}
		return null;
	}

	// Token: 0x06005E35 RID: 24117 RVA: 0x00178CF4 File Offset: 0x00176EF4
	[return: Nullable(2)]
	public string GetQueryProductName(string payId)
	{
		Pay? payConf = ConfigBase<PayItemConfig>.Instance.GetPayConf(int.Parse(payId));
		QueryProductSt queryProductSt;
		if (payConf != null && this.QueryProductInfoMap.TryGetValue(payConf.Value.ProductId, out queryProductSt))
		{
			return queryProductSt.Name;
		}
		return null;
	}

	// Token: 0x06005E36 RID: 24118 RVA: 0x00178D44 File Offset: 0x00176F44
	[return: Nullable(2)]
	public string GetQueryProductDesc(string payId)
	{
		Pay? payConf = ConfigBase<PayItemConfig>.Instance.GetPayConf(int.Parse(payId));
		QueryProductSt queryProductSt;
		if (payConf != null && this.QueryProductInfoMap.TryGetValue(payConf.Value.ProductId, out queryProductSt))
		{
			return queryProductSt.Desc;
		}
		return null;
	}

	// Token: 0x06005E37 RID: 24119 RVA: 0x00178D91 File Offset: 0x00176F91
	[NullableContext(2)]
	public FBasicInfo GetBasicInfo()
	{
		if (!this.CanUseSdk)
		{
			return null;
		}
		FBasicInfo baseInfo = this.BaseInfo;
		if (baseInfo != null && baseInfo.bIsValid)
		{
			return this.BaseInfo;
		}
		this.BaseInfo = UKuroSDKManager.GetBasicInfo();
		return this.BaseInfo;
	}

	// Token: 0x06005E38 RID: 24120 RVA: 0x00178DCC File Offset: 0x00176FCC
	public string GetDeviceFontAsset()
	{
		string fontAsset = this.GetFontAsset();
		return this.GetFontPlatformName(fontAsset);
	}

	// Token: 0x06005E39 RID: 24121 RVA: 0x00178DE8 File Offset: 0x00176FE8
	public string GetFontAsset()
	{
		string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		if (packageLanguage != null)
		{
			int length = packageLanguage.Length;
			if (length == 2)
			{
				switch (packageLanguage[1])
				{
				case 'a':
					if (packageLanguage == "ja")
					{
						return "MotoyaAporoStdW5.otf";
					}
					break;
				case 'd':
					if (packageLanguage == "id")
					{
						return "LaguSansBold.otf";
					}
					break;
				case 'e':
					if (packageLanguage == "de")
					{
						return "LaguSansBold.otf";
					}
					break;
				case 'h':
					if (packageLanguage == "th")
					{
						return "Kanit-Medium.ttf";
					}
					break;
				case 'i':
					if (packageLanguage == "vi")
					{
						return "LaguSansBold.otf";
					}
					break;
				case 'n':
					if (packageLanguage == "en")
					{
						return "LaguSansBold.otf";
					}
					break;
				case 'o':
					if (packageLanguage == "ko")
					{
						return "SUITE-Bold.otf";
					}
					break;
				case 'r':
					if (packageLanguage == "fr")
					{
						return "LaguSansBold.otf";
					}
					break;
				case 's':
					if (packageLanguage == "es")
					{
						return "LaguSansBold.otf";
					}
					break;
				case 't':
					if (packageLanguage == "pt")
					{
						return "LaguSansBold.otf";
					}
					break;
				case 'u':
					if (packageLanguage == "ru")
					{
						return "LaguSansBold.otf";
					}
					break;
				}
			}
		}
		return "H7GBKHeavy.TTF";
	}

	// Token: 0x06005E3A RID: 24122 RVA: 0x00178F88 File Offset: 0x00177188
	private string GetFontPlatformName(string source)
	{
		if (!Singleton<Platform>.Instance.IsIOSPlatform() && !Singleton<Platform>.Instance.IsMacPlatform())
		{
			return source;
		}
		if (source == "LaguSansBold.otf")
		{
			return "LaguSans-Bold.otf";
		}
		if (source == "H7GBKHeavy.TTF")
		{
			return "ARFangXinShuH7GBK-Heavy.TTF";
		}
		if (source == "MotoyaAporoStdW5.otf")
		{
			return "MotoyaAporoStd-W5.otf";
		}
		if (source == "SUITE-Bold.otf")
		{
			return "SUITE-Bold.otf";
		}
		if (source == "Kanit-Medium.ttf")
		{
			return "Kanit-Medium.ttf";
		}
		return source;
	}

	// Token: 0x06005E3B RID: 24123 RVA: 0x00179010 File Offset: 0x00177210
	public string GetCurrentFontName()
	{
		string fontAsset = this.GetFontAsset();
		if (fontAsset == "LaguSansBold.otf")
		{
			return "Lagu Sans";
		}
		if (fontAsset == "H7GBKHeavy.TTF")
		{
			return "文鼎方新书H7GBK_H";
		}
		if (fontAsset == "MotoyaAporoStdW5.otf")
		{
			return "Motoya Aporo Std W5";
		}
		if (fontAsset == "SUITE-Bold.otf")
		{
			return "SUITE";
		}
		if (!(fontAsset == "Kanit-Medium.ttf"))
		{
			return "文鼎方新书H7GBK_H";
		}
		return "Kanit Medium";
	}

	// Token: 0x06005E3C RID: 24124 RVA: 0x0017908C File Offset: 0x0017728C
	public void OnSdkFocusChange(bool sdkGetFocusState)
	{
		this.SdkGetFocusState = sdkGetFocusState;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "OnSdkFocusChange";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", sdkGetFocusState);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (this.SdkGetFocusState)
		{
			UiNavigationGlobalData.AddBlockListenerFocusTag("SdkFocus");
		}
		else
		{
			UiNavigationGlobalData.DeleteBlockListenerFocusTag("SdkFocus");
		}
		ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnSdkFocusStateChange, this.SdkGetFocusState);
	}

	// Token: 0x06005E3D RID: 24125 RVA: 0x0017910A File Offset: 0x0017730A
	public bool GetSdkFocusState()
	{
		return this.SdkGetFocusState;
	}

	// Token: 0x06005E3E RID: 24126 RVA: 0x00179112 File Offset: 0x00177312
	public void SetPlayStationPlayOnlyState(bool state)
	{
		this.PlayStationPlayOnlyState = state;
		ControllerBase<KuroSdkController>.Instance.SetPlayOnly(state);
		Singleton<EventSystem>.Instance.Emit<EFunction>(EEventName.RefreshMenuSetting, EFunction.PlayStationOnly);
	}

	// Token: 0x06005E3F RID: 24127 RVA: 0x0017913B File Offset: 0x0017733B
	public void SetXboxPlayOnlyState(bool state)
	{
		this.XboxPlayOnlyState = state;
		ControllerBase<KuroSdkController>.Instance.SetPlayOnly(state);
		Singleton<EventSystem>.Instance.Emit<EFunction>(EEventName.RefreshMenuSetting, EFunction.XboxOnly);
	}

	// Token: 0x06005E40 RID: 24128 RVA: 0x00179164 File Offset: 0x00177364
	[NullableContext(2)]
	public string GetSdkPackageId()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetProductId();
		}
		return ControllerBase<KuroSdkController>.Instance.GetPackageId();
	}

	// Token: 0x06005E41 RID: 24129 RVA: 0x0017918C File Offset: 0x0017738C
	[NullableContext(2)]
	public void SetEntryPointData(PostWebViewEntryPointData data)
	{
		this.EntryPointData = data;
	}

	// Token: 0x06005E42 RID: 24130 RVA: 0x00179195 File Offset: 0x00177395
	[NullableContext(2)]
	public PostWebViewEntryPointData GetEntryPointData()
	{
		return this.EntryPointData;
	}

	// Token: 0x06005E43 RID: 24131 RVA: 0x0017919D File Offset: 0x0017739D
	[NullableContext(2)]
	public void SetIntroductionData(IntroductionData data)
	{
		this.IntroductionData = data;
		this.RefreshIntroductionRedDotState();
	}

	// Token: 0x06005E44 RID: 24132 RVA: 0x001791AC File Offset: 0x001773AC
	[NullableContext(2)]
	public IntroductionData GetIntroductionData()
	{
		return this.IntroductionData;
	}

	// Token: 0x06005E45 RID: 24133 RVA: 0x001791B4 File Offset: 0x001773B4
	private void RefreshIntroductionRedDotState()
	{
		string s = (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.IntroductionVersion) as ServerStorageString).Get() ?? "";
		long num = 0L;
		long.TryParse(s, out num);
		if (this.IntroductionData != null && this.IntroductionData.version != num)
		{
			this.IntroductionNoticeState = true;
		}
		else
		{
			this.IntroductionNoticeState = false;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkIntroductionRedPointRefresh);
	}

	// Token: 0x06005E46 RID: 24134 RVA: 0x00179224 File Offset: 0x00177424
	public void SaveCurrentClickIntroductionVersion()
	{
		(ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.IntroductionVersion) as ServerStorageString).Set((this.IntroductionData != null) ? this.IntroductionData.version.ToString() : "");
		this.IntroductionNoticeState = false;
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkIntroductionRedPointRefresh);
	}

	// Token: 0x06005E47 RID: 24135 RVA: 0x0017927D File Offset: 0x0017747D
	public int GetNoticePlatformId()
	{
		if (Singleton<Platform>.Instance.IsAndroidPlatform())
		{
			return 2;
		}
		if (Singleton<Platform>.Instance.IsIOSPlatform())
		{
			return 3;
		}
		if (Singleton<Platform>.Instance.IsPs5Platform())
		{
			return 4;
		}
		if (Singleton<Platform>.Instance.IsMacPlatform())
		{
			return 5;
		}
		return 1;
	}

	// Token: 0x06005E48 RID: 24136 RVA: 0x001792B8 File Offset: 0x001774B8
	public NoticeContentData[] FilterCurrentNeedShowNoticeContent(NoticeData source, string roleId)
	{
		List<NoticeContentData> list = new List<NoticeContentData>();
		string channelId = ControllerBase<KuroSdkController>.Instance.GetChannelId();
		NoticeContentData[] game = source.game;
		NoticeContentData[] activity = source.activity;
		List<NoticeContentData> list2 = new List<NoticeContentData>();
		list2.AddRange(game);
		list2.AddRange(activity);
		int noticePlatformId = this.GetNoticePlatformId();
		foreach (NoticeContentData noticeContentData in list2)
		{
			bool flag = roleId != "0";
			if (this.CheckNoticeContentInValidTime(noticeContentData) && this.CheckNoticeContentInWhiteList(noticeContentData, roleId) && (noticeContentData.permanent != 0 || flag) && this.CheckNoticeContentInChannel(noticeContentData, channelId) && this.CheckNoticeContentInPlatform(noticeContentData, noticePlatformId))
			{
				list.Add(noticeContentData);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06005E49 RID: 24137 RVA: 0x00179390 File Offset: 0x00177590
	private bool CheckNoticeContentInValidTime(NoticeContentData data)
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double num = data.startTimeMs / 1000.0;
		double num2 = data.endTimeMs / 1000.0;
		return serverTime >= num && serverTime <= num2;
	}

	// Token: 0x06005E4A RID: 24138 RVA: 0x001793D8 File Offset: 0x001775D8
	private bool CheckNoticeContentInWhiteList(NoticeContentData data, string roleId)
	{
		bool result = true;
		if (data.whiteList.Length != 0)
		{
			int[] whiteList = data.whiteList;
			for (int i = 0; i < whiteList.Length; i++)
			{
				if (whiteList[i] == int.Parse(roleId))
				{
					return true;
				}
			}
			result = false;
		}
		return result;
	}

	// Token: 0x06005E4B RID: 24139 RVA: 0x00179418 File Offset: 0x00177618
	private bool CheckNoticeContentInChannel(NoticeContentData data, string channelId)
	{
		bool result = true;
		if (data.channel.Length != 0)
		{
			string[] channel = data.channel;
			for (int i = 0; i < channel.Length; i++)
			{
				if (channel[i] == channelId)
				{
					return true;
				}
			}
			result = false;
		}
		return result;
	}

	// Token: 0x06005E4C RID: 24140 RVA: 0x00179458 File Offset: 0x00177658
	private bool CheckNoticeContentInPlatform(NoticeContentData data, int platformId)
	{
		bool result = true;
		if (data.platform.Length != 0)
		{
			int[] platform = data.platform;
			for (int i = 0; i < platform.Length; i++)
			{
				if (platform[i] == platformId)
				{
					return true;
				}
			}
			result = false;
		}
		return result;
	}

	// Token: 0x06005E4D RID: 24141 RVA: 0x00179490 File Offset: 0x00177690
	public string GetNoticeContentUrl(int currentIndex)
	{
		if (ModelBase<KuroSdkModel>.Instance.GetEntryPointData() == null)
		{
			return "";
		}
		PostWebViewEntryPointData entryPointData = ModelBase<KuroSdkModel>.Instance.GetEntryPointData();
		if (currentIndex >= entryPointData.contentUrl.Length)
		{
			return entryPointData.contentUrl[currentIndex - 1];
		}
		return entryPointData.contentUrl[currentIndex];
	}

	// Token: 0x06005E4E RID: 24142 RVA: 0x001794D8 File Offset: 0x001776D8
	public string GetQueryNoticeReadStateUrl(int currentIndex = 0)
	{
		if (ModelBase<KuroSdkModel>.Instance.GetEntryPointData() == null)
		{
			return "";
		}
		string apiUrl = this.GetApiUrl(currentIndex);
		string value = (ModelBase<PlayerInfoModel>.Instance.GetId() == null) ? "0" : ModelBase<PlayerInfoModel>.Instance.GetId().ToString();
		string noticeSign = ModelBase<KuroSdkModel>.Instance.NoticeSign;
		string currentLoginServerId = ModelBase<LoginServerModel>.Instance.GetCurrentLoginServerId();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 4);
		defaultInterpolatedStringHandler.AppendFormatted(apiUrl);
		defaultInterpolatedStringHandler.AppendLiteral("/notice/read-ids/list?uid=");
		defaultInterpolatedStringHandler.AppendFormatted(value);
		defaultInterpolatedStringHandler.AppendLiteral("&sign=");
		defaultInterpolatedStringHandler.AppendFormatted(noticeSign);
		defaultInterpolatedStringHandler.AppendLiteral("&serverId=");
		defaultInterpolatedStringHandler.AppendFormatted(currentLoginServerId);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005E4F RID: 24143 RVA: 0x001795A0 File Offset: 0x001777A0
	public string GetEntryPointUrl()
	{
		string currentLoginServerId = ModelBase<LoginServerModel>.Instance.GetCurrentLoginServerId();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 3);
		defaultInterpolatedStringHandler.AppendFormatted(Singleton<PublicUtil>.Instance.GetNoticeBaseUrl());
		defaultInterpolatedStringHandler.AppendLiteral("/gamenotice/");
		defaultInterpolatedStringHandler.AppendFormatted(Singleton<PublicUtil>.Instance.GetGameId());
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted(currentLoginServerId);
		defaultInterpolatedStringHandler.AppendLiteral("/entrypoint.json");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005E50 RID: 24144 RVA: 0x00179618 File Offset: 0x00177818
	private string GetNoticePreUrl(int currentIndex = 0)
	{
		if (ModelBase<KuroSdkModel>.Instance.GetEntryPointData() == null)
		{
			return "";
		}
		PostWebViewEntryPointData entryPointData = ModelBase<KuroSdkModel>.Instance.GetEntryPointData();
		if (currentIndex >= entryPointData.h5AppUrl.Length)
		{
			return entryPointData.h5AppUrl[currentIndex - 1];
		}
		return entryPointData.h5AppUrl[currentIndex];
	}

	// Token: 0x06005E51 RID: 24145 RVA: 0x00179660 File Offset: 0x00177860
	public string GetPlatformStr()
	{
		if (Singleton<Platform>.Instance.IsAndroidPlatform())
		{
			return "Android";
		}
		if (Singleton<Platform>.Instance.IsIOSPlatform())
		{
			return "iOS";
		}
		if (Singleton<Platform>.Instance.IsMacPlatform())
		{
			return "Mac";
		}
		if (Singleton<Platform>.Instance.IsPs5Platform())
		{
			return "PS5";
		}
		if (Singleton<Platform>.Instance.IsXSXPlatform())
		{
			return "XSX";
		}
		if (Singleton<Platform>.Instance.IsWinGDKPlatform())
		{
			return "WinGDK";
		}
		if (Singleton<Platform>.Instance.IsOpenHarmonyPlatform())
		{
			return "OpenHarmony";
		}
		return "PC";
	}

	// Token: 0x06005E52 RID: 24146 RVA: 0x001796F0 File Offset: 0x001778F0
	public string GetNoticeUrl(int currentIndex = 0, EOpenNoticeStage stage = EOpenNoticeStage.Normal)
	{
		string noticePreUrl = this.GetNoticePreUrl(currentIndex);
		string currentLoginServerId = ModelBase<LoginServerModel>.Instance.GetCurrentLoginServerId();
		string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		string deviceDid = ControllerBase<KuroSdkController>.Instance.GetDeviceDid();
		PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
		string value = ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk() ? "global" : "cn";
		string gameId = Singleton<PublicUtil>.Instance.GetGameId();
		string channelId = ControllerBase<KuroSdkController>.Instance.GetChannelId();
		string platformStr = this.GetPlatformStr();
		string noticeSign = ModelBase<KuroSdkModel>.Instance.NoticeSign;
		string value2 = UKuroStaticLibrary.Base64Encode(Singleton<PublicUtil>.Instance.GetPublicInfo());
		string value3;
		string value4;
		if (stage == EOpenNoticeStage.BeforeLogin)
		{
			value3 = "before_login";
			value4 = "1000000000";
		}
		else
		{
			SdkLoginInfo sdkLoginInfo = ModelBase<LoginModel>.Instance.GetSdkLoginInfo();
			value3 = (((sdkLoginInfo != null) ? sdkLoginInfo.Uid : null) ?? "");
			value4 = ((instance.GetId() == null) ? "0" : instance.GetId().ToString());
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(96, 12);
		defaultInterpolatedStringHandler.AppendFormatted(noticePreUrl);
		defaultInterpolatedStringHandler.AppendLiteral("?server_id=");
		defaultInterpolatedStringHandler.AppendFormatted(currentLoginServerId);
		defaultInterpolatedStringHandler.AppendLiteral("&lang=");
		defaultInterpolatedStringHandler.AppendFormatted(packageLanguage);
		defaultInterpolatedStringHandler.AppendLiteral("&did=");
		defaultInterpolatedStringHandler.AppendFormatted(deviceDid);
		defaultInterpolatedStringHandler.AppendLiteral("&role_id=");
		defaultInterpolatedStringHandler.AppendFormatted(value4);
		defaultInterpolatedStringHandler.AppendLiteral("&svr_area=");
		defaultInterpolatedStringHandler.AppendFormatted(value);
		defaultInterpolatedStringHandler.AppendLiteral("&game_id=");
		defaultInterpolatedStringHandler.AppendFormatted(gameId);
		defaultInterpolatedStringHandler.AppendLiteral("&channel=");
		defaultInterpolatedStringHandler.AppendFormatted(channelId);
		defaultInterpolatedStringHandler.AppendLiteral("&platform=");
		defaultInterpolatedStringHandler.AppendFormatted(platformStr);
		defaultInterpolatedStringHandler.AppendLiteral("&user_id=");
		defaultInterpolatedStringHandler.AppendFormatted(value3);
		defaultInterpolatedStringHandler.AppendLiteral("&sign=");
		defaultInterpolatedStringHandler.AppendFormatted(noticeSign);
		defaultInterpolatedStringHandler.AppendLiteral("&login_info=");
		defaultInterpolatedStringHandler.AppendFormatted(value2);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005E53 RID: 24147 RVA: 0x001798E8 File Offset: 0x00177AE8
	public string GetQueryNoticeRedDotStateUrl(int currentIndex = 0)
	{
		if (ModelBase<KuroSdkModel>.Instance.GetEntryPointData() == null)
		{
			return "";
		}
		string apiUrl = this.GetApiUrl(currentIndex);
		string currentLoginServerId = ModelBase<LoginServerModel>.Instance.GetCurrentLoginServerId();
		string value = (ModelBase<PlayerInfoModel>.Instance.GetId() == null) ? "0" : ModelBase<PlayerInfoModel>.Instance.GetId().ToString();
		string noticeSign = ModelBase<KuroSdkModel>.Instance.NoticeSign;
		string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		string channelId = ControllerBase<KuroSdkController>.Instance.GetChannelId();
		string platformStr = this.GetPlatformStr();
		string gameId = Singleton<PublicUtil>.Instance.GetGameId();
		string value2 = ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk() ? "global" : "cn";
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(86, 9);
		defaultInterpolatedStringHandler.AppendFormatted(apiUrl);
		defaultInterpolatedStringHandler.AppendLiteral("/notice/red-dot/get?uid=");
		defaultInterpolatedStringHandler.AppendFormatted(value);
		defaultInterpolatedStringHandler.AppendLiteral("&sign=");
		defaultInterpolatedStringHandler.AppendFormatted(noticeSign);
		defaultInterpolatedStringHandler.AppendLiteral("&serverId=");
		defaultInterpolatedStringHandler.AppendFormatted(currentLoginServerId);
		defaultInterpolatedStringHandler.AppendLiteral("&language=");
		defaultInterpolatedStringHandler.AppendFormatted(packageLanguage);
		defaultInterpolatedStringHandler.AppendLiteral("&channel=");
		defaultInterpolatedStringHandler.AppendFormatted(channelId);
		defaultInterpolatedStringHandler.AppendLiteral("&platform=");
		defaultInterpolatedStringHandler.AppendFormatted(platformStr);
		defaultInterpolatedStringHandler.AppendLiteral("&gameId=");
		defaultInterpolatedStringHandler.AppendFormatted(gameId);
		defaultInterpolatedStringHandler.AppendLiteral("&svrArea=");
		defaultInterpolatedStringHandler.AppendFormatted(value2);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005E54 RID: 24148 RVA: 0x00179A60 File Offset: 0x00177C60
	private string GetApiUrl(int currentIndex = 0)
	{
		PostWebViewEntryPointData entryPointData = ModelBase<KuroSdkModel>.Instance.GetEntryPointData();
		if (entryPointData == null)
		{
			return "";
		}
		if (entryPointData.apiUrls != null && entryPointData.apiUrls.Length != 0)
		{
			int num = (currentIndex < entryPointData.apiUrls.Length) ? currentIndex : (entryPointData.apiUrls.Length - 1);
			return entryPointData.apiUrls[num];
		}
		return entryPointData.apiUrl;
	}

	// Token: 0x06005E55 RID: 24149 RVA: 0x00179ABC File Offset: 0x00177CBC
	public string GetIntroductionVersionUrl()
	{
		string text = "";
		if (this.GmIntroductionLink != "")
		{
			text = this.GmIntroductionLink;
		}
		if (text == "")
		{
			if (ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
			{
				text = ConfigBase<CommonConfig>.Instance.GetGuideOverseaLinkUrl();
			}
			else
			{
				text = ConfigBase<CommonConfig>.Instance.GetGuideMainlandLinkUrl();
			}
		}
		return text + "/introduction/redot.json";
	}

	// Token: 0x06005E56 RID: 24150 RVA: 0x00179B24 File Offset: 0x00177D24
	public void OnMatchTeamNotify(MatchTeamInfo matchTeamInfo)
	{
		foreach (MatchPlayerInfo matchPlayerInfo in matchTeamInfo.PlayerInfos)
		{
			if (!string.IsNullOrEmpty(matchPlayerInfo.XboxOnlineId))
			{
				this.RefreshPlayerChatPermission(matchPlayerInfo.PlayerId, matchPlayerInfo.XboxOnlineId);
			}
		}
	}

	// Token: 0x06005E57 RID: 24151 RVA: 0x00179B8C File Offset: 0x00177D8C
	public void RefreshPlayerChatPermissionByPlayerDetails(PlayerDetails playerDetails)
	{
		if (!string.IsNullOrEmpty(playerDetails.XboxUserId))
		{
			this.RefreshPlayerChatPermission(playerDetails.PlayerId, playerDetails.XboxUserId);
		}
	}

	// Token: 0x06005E58 RID: 24152 RVA: 0x00179BB0 File Offset: 0x00177DB0
	public void RefreshPlayerChatPermission(int playerId, string userId)
	{
		ControllerBase<KuroSdkController>.Instance.CheckPermission(userId, ESdkPermission.CommunicateUsingText, delegate(bool result)
		{
			this.PlayerChatPermissionMap[playerId] = result;
		});
	}

	// Token: 0x06005E59 RID: 24153 RVA: 0x00179BE9 File Offset: 0x00177DE9
	public bool GetPlayerChatPermission(int playerId)
	{
		return this.PlayerChatPermissionMap.GetValueOrDefault(playerId, true);
	}

	// Token: 0x06005E5A RID: 24154 RVA: 0x00179BF8 File Offset: 0x00177DF8
	public EXboxMultiplayerActivityJoinRestriction GetRoomRestriction()
	{
		EPlayStationJoinAble gameJoinTypeToPlayStationJoinType = ModelBase<OnlineModel>.Instance.GetGameJoinTypeToPlayStationJoinType();
		EXboxMultiplayerActivityJoinRestriction result;
		if (gameJoinTypeToPlayStationJoinType == EPlayStationJoinAble.Anyone)
		{
			result = EXboxMultiplayerActivityJoinRestriction.Activity_Public;
		}
		else if (gameJoinTypeToPlayStationJoinType == EPlayStationJoinAble.Friends)
		{
			result = EXboxMultiplayerActivityJoinRestriction.Activity_Followed;
		}
		else if (gameJoinTypeToPlayStationJoinType == EPlayStationJoinAble.NoOne)
		{
			result = EXboxMultiplayerActivityJoinRestriction.Activity_InviteOnly;
		}
		else
		{
			result = EXboxMultiplayerActivityJoinRestriction.Activity_Followed;
		}
		return result;
	}

	// Token: 0x04002D7E RID: 11646
	private const string LAGUSANSBOLD = "LaguSansBold.otf";

	// Token: 0x04002D7F RID: 11647
	private const string MOTOYTA = "MotoyaAporoStdW5.otf";

	// Token: 0x04002D80 RID: 11648
	private const string SUITEBOLD = "SUITE-Bold.otf";

	// Token: 0x04002D81 RID: 11649
	private const string H7GBKHEAVY = "H7GBKHeavy.TTF";

	// Token: 0x04002D82 RID: 11650
	private const string KANIT = "Kanit-Medium.ttf";

	// Token: 0x04002D83 RID: 11651
	private const string DEFAULTEMPTY = " ";

	// Token: 0x04002D84 RID: 11652
	public bool ReportedInitState;

	// Token: 0x04002D85 RID: 11653
	[Nullable(2)]
	private FBasicInfo BaseInfo;

	// Token: 0x04002D86 RID: 11654
	private readonly Dictionary<string, QueryProductSt> QueryProductInfoMap;

	// Token: 0x04002D87 RID: 11655
	private Dictionary<string, ISdkTrophyInfo> SdkTrophyInfoMap;

	// Token: 0x04002D88 RID: 11656
	public bool CanUseSdk;

	// Token: 0x04002D89 RID: 11657
	public string CurrentPayItemName;

	// Token: 0x04002D8A RID: 11658
	public bool SdkGetFocusState;

	// Token: 0x04002D8B RID: 11659
	public Dictionary<string, bool> SdkBlockUserMap;

	// Token: 0x04002D8C RID: 11660
	private bool GetSdkBlockUserState;

	// Token: 0x04002D8D RID: 11661
	public bool PlayStationPlayOnlyState;

	// Token: 0x04002D8E RID: 11662
	public bool XboxPlayOnlyState;

	// Token: 0x04002D8F RID: 11663
	[Nullable(2)]
	public string UserId;

	// Token: 0x04002D90 RID: 11664
	[Nullable(2)]
	public string OnlineId;

	// Token: 0x04002D91 RID: 11665
	private int CurrentProgressActivityIndex;

	// Token: 0x04002D92 RID: 11666
	[Nullable(2)]
	private PlayStationActivityConfig[] ProgressActivityList;

	// Token: 0x04002D93 RID: 11667
	[Nullable(2)]
	public string AccountId;

	// Token: 0x04002D94 RID: 11668
	public string CurrentPayingOrderId;

	// Token: 0x04002D95 RID: 11669
	public bool NeedOpenReviewState;

	// Token: 0x04002D96 RID: 11670
	public int ReviewDelay;

	// Token: 0x04002D97 RID: 11671
	public int CurrentReviewId;

	// Token: 0x04002D98 RID: 11672
	public bool NeedReviewConfirmBox;

	// Token: 0x04002D99 RID: 11673
	[Nullable(2)]
	public CustomPromise<bool> QueryPromise;

	// Token: 0x04002D9A RID: 11674
	[Nullable(2)]
	private PostWebViewEntryPointData EntryPointData;

	// Token: 0x04002D9B RID: 11675
	[Nullable(2)]
	private IntroductionData IntroductionData;

	// Token: 0x04002D9C RID: 11676
	public bool NoticeRedDotState;

	// Token: 0x04002D9D RID: 11677
	public string NoticeSign;

	// Token: 0x04002D9E RID: 11678
	public string GmIntroductionLink = "";

	// Token: 0x04002D9F RID: 11679
	public bool IntroductionNoticeState;

	// Token: 0x04002DA0 RID: 11680
	private readonly List<string> CurrentOpeningStaticActivityList = new List<string>();

	// Token: 0x04002DA1 RID: 11681
	private readonly Dictionary<int, bool> PlayerChatPermissionMap = new Dictionary<int, bool>();
}
