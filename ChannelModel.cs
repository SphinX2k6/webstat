using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Launcher.Platform.PlatformSdk;
using UnrealEngine;

// Token: 0x02001835 RID: 6197
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ChannelModel : ModelBase<ChannelModel>
{
	// Token: 0x0600B0E0 RID: 45280 RVA: 0x002F3360 File Offset: 0x002F1560
	protected override bool OnInit()
	{
		this.OpenShareChannel = new List<EChannelShare>();
		this.OpenKuroStreetId = new List<EChannelKuroStreet>();
		this.OpenAccountSetting = new List<EChannelAccountSetting>();
		this.SharedActionTypeMap = new List<int>();
		Singleton<EventSystem>.Instance.Add(EEventName.SdkInitDone, new Action(this.ResetOpenFunc));
		return true;
	}

	// Token: 0x0600B0E1 RID: 45281 RVA: 0x002F33B3 File Offset: 0x002F15B3
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SdkInitDone, new Action(this.ResetOpenFunc));
		return true;
	}

	// Token: 0x0600B0E2 RID: 45282 RVA: 0x002F33D0 File Offset: 0x002F15D0
	private unsafe void ResetOpenFunc()
	{
		this.OpenShareChannel = new List<EChannelShare>();
		this.OpenKuroStreetId = new List<EChannelKuroStreet>();
		this.OpenAccountSetting = new List<EChannelAccountSetting>();
		this.IsCustomerServiceOpen = false;
		if (!ControllerBase<LoginController>.Instance.IsSdkLoginMode())
		{
			Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.JT, "不可使用SDK", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		bool ifGlobalSdk = ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk();
		string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		int num = int.Parse(ControllerBase<KuroSdkController>.Instance.GetChannelId());
		string sdkPackageId = ModelBase<KuroSdkModel>.Instance.GetSdkPackageId();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.JT;
		string message = "当前包体信息";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("是否海外", ifGlobalSdk);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("当前语言码", packageLanguage);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("当前渠道", num);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		FeatureRestrictionTemplate templateForPioneerClient = FeatureRestrictionTemplate.TemplateForPioneerClient;
		if (Singleton<Info>.Instance.IsMobilePlatform())
		{
			IReadOnlyList<SharePlatform> configList = ConfigSharePlatformAll.GetConfigList((!ifGlobalSdk) ? 1 : 0, true);
			if (configList != null)
			{
				foreach (SharePlatform config in configList)
				{
					if (this.CheckLanguage(packageLanguage, config.ToLanguageEnumerable()) && this.CheckChannel(num, config.ToChannelEnumerable()) && this.CheckPackageId(sdkPackageId, config.ToPackageIdEnumerable()) && !templateForPioneerClient.Check())
					{
						this.OpenShareChannel.Add((EChannelShare)config.Id);
					}
				}
			}
		}
		this.OpenShareChannel.Sort(delegate(EChannelShare a, EChannelShare b)
		{
			SharePlatform? config5 = ConfigSharePlatformById.GetConfig((int)a, true);
			SharePlatform? config6 = ConfigSharePlatformById.GetConfig((int)b, true);
			if (config5 != null && config6 != null && config5.Value.Sort != config6.Value.Sort)
			{
				return config5.Value.Sort - config6.Value.Sort;
			}
			return a - b;
		});
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.KuroSdk;
		ELogAuthor author2 = ELogAuthor.YZY;
		string message2 = "开启分享渠道id ";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("OpenShareChannel", this.OpenShareChannel);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		foreach (Community config2 in ConfigCommunityAll.GetConfigList((!ifGlobalSdk) ? 1 : 0, true))
		{
			if (this.CheckLanguage(packageLanguage, config2.ToLanguageEnumerable()) && this.CheckChannel(num, config2.ToChannelEnumerable()) && this.CheckPackageId(sdkPackageId, config2.ToPackageIdEnumerable()) && !templateForPioneerClient.Check())
			{
				this.OpenKuroStreetId.Add((EChannelKuroStreet)config2.Id);
			}
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.KuroSdk;
		ELogAuthor author3 = ELogAuthor.YZY;
		string message3 = "开启库街区id ";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("OpenKuroStreetId", this.OpenKuroStreetId);
		instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		foreach (SetAccount config3 in ConfigSetAccountAll.GetConfigList((!ifGlobalSdk) ? 1 : 0, true))
		{
			if (this.CheckLanguage(packageLanguage, config3.ToLanguageEnumerable()) && this.CheckChannel(num, config3.ToChannelEnumerable()) && this.CheckPackageId(sdkPackageId, config3.ToPackageIdEnumerable()) && (!templateForPioneerClient.Check() || (config3.Id != 1 && config3.Id != 9)))
			{
				this.OpenAccountSetting.Add((EChannelAccountSetting)config3.Id);
			}
		}
		Log instance4 = Singleton<Log>.Instance;
		ELogModule module4 = ELogModule.KuroSdk;
		ELogAuthor author4 = ELogAuthor.YZY;
		string message4 = "开启账号中心id ";
		ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("OpenAccountSetting", this.OpenAccountSetting);
		instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
		foreach (CustomerService config4 in ConfigCustomerServiceAll.GetConfigList((!ifGlobalSdk) ? 1 : 0, true))
		{
			if (this.CheckLanguage(packageLanguage, config4.ToLanguageEnumerable()) && this.CheckChannel(num, config4.ToChannelEnumerable()) && this.CheckPackageId(sdkPackageId, config4.ToPackageIdEnumerable()))
			{
				this.IsCustomerServiceOpen = true;
			}
		}
		Log instance5 = Singleton<Log>.Instance;
		ELogModule module5 = ELogModule.KuroSdk;
		ELogAuthor author5 = ELogAuthor.XXJ;
		string message5 = "客服开启";
		ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("state", this.IsCustomerServiceOpen);
		instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
		Singleton<EventSystem>.Instance.Emit(EEventName.ChannelReset);
	}

	// Token: 0x0600B0E3 RID: 45283 RVA: 0x002F3810 File Offset: 0x002F1A10
	private bool CheckLanguage(string checkLanguage, IEnumerable<string> checkIter)
	{
		foreach (string a in checkIter)
		{
			if (a == "all")
			{
				return true;
			}
			if (a == checkLanguage)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600B0E4 RID: 45284 RVA: 0x002F3874 File Offset: 0x002F1A74
	private bool CheckChannel(int checkChannel, IEnumerable<int> checkIter)
	{
		foreach (int num in checkIter)
		{
			if (num == 0)
			{
				return true;
			}
			if (num == checkChannel)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600B0E5 RID: 45285 RVA: 0x002F38C8 File Offset: 0x002F1AC8
	private bool CheckPackageId([Nullable(2)] string checkPackageId, IEnumerable<string> packageIdIter)
	{
		if (checkPackageId == null)
		{
			return false;
		}
		foreach (string a in packageIdIter)
		{
			if (a == "all")
			{
				return true;
			}
			if (a == checkPackageId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600B0E6 RID: 45286 RVA: 0x002F3930 File Offset: 0x002F1B30
	public bool CheckShareChannelOpen(EChannelShare type)
	{
		this.TryResetOpenMap();
		return this.OpenShareChannel.Contains(type);
	}

	// Token: 0x0600B0E7 RID: 45287 RVA: 0x002F3944 File Offset: 0x002F1B44
	public bool CheckKuroStreetOpen()
	{
		this.TryResetOpenMap();
		return this.OpenKuroStreetId.Count > 0;
	}

	// Token: 0x0600B0E8 RID: 45288 RVA: 0x002F395A File Offset: 0x002F1B5A
	public bool CheckAccountSettingOpen(EChannelAccountSetting type)
	{
		this.TryResetOpenMap();
		return this.OpenAccountSetting.Contains(type);
	}

	// Token: 0x0600B0E9 RID: 45289 RVA: 0x002F3970 File Offset: 0x002F1B70
	public bool CheckCustomerServiceOpen()
	{
		this.TryResetOpenMap();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "客服是否开启";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("IsCustomerServiceOpen", this.IsCustomerServiceOpen);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return this.IsCustomerServiceOpen;
	}

	// Token: 0x0600B0EA RID: 45290 RVA: 0x002F39BC File Offset: 0x002F1BBC
	public void OpenKuroStreet()
	{
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android)
		{
			UKuroStaticAndroidLibrary.OpenAppWithUrl("kjq://kuro/home?gameId=3", "https://www.kurobbs.com/download.html");
			return;
		}
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
		{
			UKuroStaticiOSLibrary.OpenAppWithUrl("kjq://kuro/home?gameId=3", "itms-apps://itunes.apple.com/app/id/1659339393");
			return;
		}
		if (this.OpenKuroStreetId.Count > 0)
		{
			Community? community;
			this.OpenAddress((ConfigCommunityById.GetConfig((int)this.OpenKuroStreetId[0], true) != null) ? community.GetValueOrDefault().Adress : null);
		}
	}

	// Token: 0x0600B0EB RID: 45291 RVA: 0x002F3A45 File Offset: 0x002F1C45
	private void TryResetOpenMap()
	{
		if (this.OpenAccountSetting.Count == 0)
		{
			this.ResetOpenFunc();
		}
	}

	// Token: 0x0600B0EC RID: 45292 RVA: 0x002F3A5C File Offset: 0x002F1C5C
	public void ProcessAccountSetting(EChannelAccountSetting type)
	{
		if (type == EChannelAccountSetting.UserCenter || type == EChannelAccountSetting.UserCenterGlobal)
		{
			ControllerBase<KuroSdkController>.Instance.PostKuroSdkEvent(EKuroSdkEventKey.KuroOpenUserCenter);
			return;
		}
		if (type == EChannelAccountSetting.SDKPrivacy)
		{
			ControllerBase<KuroSdkController>.Instance.PostKuroSdkEvent(EKuroSdkEventKey.KuroShowAgreement);
			ControllerBase<KuroSdkController>.Instance.PostKuroSdkEvent(EKuroSdkEventKey.KuroOpenPrivacyClauseWnd);
			return;
		}
		SetAccount? setAccount;
		string url = (ConfigSetAccountById.GetConfig((int)type, true) != null) ? setAccount.GetValueOrDefault().Adress : null;
		bool flag = Singleton<Info>.Instance.PlatformType == ESourcePlatformType.PS4 || Singleton<Info>.Instance.PlatformType == ESourcePlatformType.PS5;
		if (type == EChannelAccountSetting.UserAgreement || type == EChannelAccountSetting.Privacy || type == EChannelAccountSetting.ChildPrivacy || type == EChannelAccountSetting.UserAgreementGlobal || type == EChannelAccountSetting.PrivacyGlobal)
		{
			Singleton<KuroSdkReport>.Instance.Report(new SdkReportOpenPrivacy(null));
		}
		if (flag)
		{
			if (type == EChannelAccountSetting.Privacy || type == EChannelAccountSetting.PrivacyGlobal)
			{
				url = Singleton<PlatformSdkConfig>.Instance.GetPrivacyPolicy();
			}
			else if (type == EChannelAccountSetting.UserAgreementGlobal || type == EChannelAccountSetting.UserAgreement)
			{
				url = Singleton<PlatformSdkConfig>.Instance.GetTermsOfService();
			}
			else if (type == EChannelAccountSetting.ChildPrivacy)
			{
				url = Singleton<PlatformSdkConfig>.Instance.GetChildPolicy();
			}
		}
		this.OpenAddress(url);
	}

	// Token: 0x0600B0ED RID: 45293 RVA: 0x002F3B43 File Offset: 0x002F1D43
	public List<EChannelShare> GetOpenedShareIds()
	{
		this.TryResetOpenMap();
		return this.OpenShareChannel;
	}

	// Token: 0x0600B0EE RID: 45294 RVA: 0x002F3B54 File Offset: 0x002F1D54
	public bool CouldGetShareReward(EShareActionId id)
	{
		ShareReward? config = ConfigShareRewardById.GetConfig((int)id, true);
		if (config == null || config.Value.RewardLength == 0)
		{
			return false;
		}
		int? num = (config != null) ? new int?(config.GetValueOrDefault().ShareType) : null;
		return this.OpenShareChannel.Count > 0 && num != null && !this.SharedActionTypeMap.Contains(num.Value);
	}

	// Token: 0x0600B0EF RID: 45295 RVA: 0x002F3BDC File Offset: 0x002F1DDC
	public void MarkActionShared(EShareActionId id)
	{
		ShareReward? shareReward;
		int? num = (ConfigShareRewardById.GetConfig((int)id, true) != null) ? new int?(shareReward.GetValueOrDefault().ShareType) : null;
		if (num != null)
		{
			this.SharedActionTypeMap.Add(num.Value);
		}
	}

	// Token: 0x0600B0F0 RID: 45296 RVA: 0x002F3C38 File Offset: 0x002F1E38
	[NullableContext(2)]
	private void OpenAddress(string url)
	{
		if (url != null)
		{
			string url2 = url.Replace("{0}", Singleton<LanguageSystem>.Instance.PackageLanguage);
			ControllerBase<KuroSdkController>.Instance.OpenExternalUrl(url2);
		}
	}

	// Token: 0x0600B0F1 RID: 45297 RVA: 0x002F3C69 File Offset: 0x002F1E69
	public void GmOpenShareId(EChannelShare id)
	{
		if (this.OpenAccountSetting.Count == 0)
		{
			this.OpenAccountSetting.Add(EChannelAccountSetting.ThirdParty);
		}
		List<EChannelShare> openShareChannel = this.OpenShareChannel;
		if (openShareChannel == null)
		{
			return;
		}
		openShareChannel.Add(id);
	}

	// Token: 0x040053DF RID: 21471
	[Nullable(2)]
	private List<EChannelShare> OpenShareChannel;

	// Token: 0x040053E0 RID: 21472
	[Nullable(2)]
	private List<EChannelKuroStreet> OpenKuroStreetId;

	// Token: 0x040053E1 RID: 21473
	[Nullable(2)]
	private List<EChannelAccountSetting> OpenAccountSetting;

	// Token: 0x040053E2 RID: 21474
	[Nullable(2)]
	private List<int> SharedActionTypeMap;

	// Token: 0x040053E3 RID: 21475
	private bool IsCustomerServiceOpen;

	// Token: 0x040053E4 RID: 21476
	public EShareActionId SharingActionId = EShareActionId.Photo;

	// Token: 0x040053E5 RID: 21477
	public int SharingConfigId;

	// Token: 0x040053E6 RID: 21478
	public EShareReportExtraType ShareReportExtraType;

	// Token: 0x040053E7 RID: 21479
	public string GameIntroductionUrl = "";
}
