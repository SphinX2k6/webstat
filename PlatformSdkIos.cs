using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000F0B RID: 3851
[NullableContext(1)]
[Nullable(0)]
public class PlatformSdkIos : PlatformSdkBase
{
	// Token: 0x06005FB9 RID: 24505 RVA: 0x0017EBE4 File Offset: 0x0017CDE4
	protected override void OnInit()
	{
		this.CurrentDid = UKuroSDKManager.GetBasicInfo().DeviceId;
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk() && UKuroLauncherLibrary.IsFirstIntoLauncher())
		{
			UKuroSDKManager.PostSplashScreenEndSuccess();
		}
		FCrashSightProxy.SetCustomData("SdkDeviceId", this.CurrentDid);
		FCrashSightProxy.SetCustomData("Sdkidfv", this.Getidfv());
		FCrashSightProxy.SetCustomData("SdkJyId", this.GetJyDid());
		FCrashSightProxy.SetCustomData("SdkChannelId", this.GetChannelId());
	}

	// Token: 0x06005FBA RID: 24506 RVA: 0x0017EC5C File Offset: 0x0017CE5C
	protected override void BindSpecialEvent()
	{
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Clear();
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Add(this.AnnounceRedPointCallBack);
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Clear();
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Add(new Action<string>(this.CustomerServiceResultCallBack));
	}

	// Token: 0x06005FBB RID: 24507 RVA: 0x0017ECB8 File Offset: 0x0017CEB8
	public void CustomerServiceResultCallBack(string result)
	{
		PlatformSdkIos.ISdkCustomerService sdkCustomerService = Json.Parse<PlatformSdkIos.ISdkCustomerService>(result, null);
		if (sdkCustomerService != null)
		{
			this.CurrentCustomerShowState = (sdkCustomerService.isredot > 0);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkCustomerRedPointRefresh);
	}

	// Token: 0x06005FBC RID: 24508 RVA: 0x0017ECF0 File Offset: 0x0017CEF0
	public override void OpenCustomerService(EKuroSdkOpenCustomerServerType fromType)
	{
		LoginModel instance = ModelBase<LoginModel>.Instance;
		PlayerInfoModel instance2 = ModelBase<PlayerInfoModel>.Instance;
		UKuroSDKManager.OpenCustomerService(Json.Stringify<OpenCustomerServiceParamIos>(new OpenCustomerServiceParamIos
		{
			islogin = ((instance.IsSdkLoggedIn() > false) ? 1 : 0),
			from = fromType,
			RoleId = this.GetCustomServerRoleId(),
			RoleName = instance2.GetAccountName(true),
			ServerId = instance.GetServerId(),
			ServerName = instance.GetServerName(),
			RoleLevel = instance2.GetPlayerLevel().GetValueOrDefault(),
			ExtendsInfo = this.GetCustomServerExtendsInfo()
		}, null));
	}

	// Token: 0x06005FBD RID: 24509 RVA: 0x0017ED80 File Offset: 0x0017CF80
	public override string GetChannelId()
	{
		return this.GetSdkParamData("channelId");
	}

	// Token: 0x06005FBE RID: 24510 RVA: 0x0017ED90 File Offset: 0x0017CF90
	public override void Share(ShareData shareData, string imagePath)
	{
		string sKuroSDKEventParameter = Json.Stringify<ShareData>(shareData, null);
		UKuroSDKStaticLibrary.Share(imagePath, sKuroSDKEventParameter);
	}

	// Token: 0x06005FBF RID: 24511 RVA: 0x0017EDAC File Offset: 0x0017CFAC
	public override void ShareTexture(ShareData shareData, string texturePath)
	{
		string sKuroSDKEventParameter = Json.Stringify<ShareData>(shareData, null);
		UKuroSDKStaticLibrary.Share(texturePath, sKuroSDKEventParameter);
	}

	// Token: 0x06005FC0 RID: 24512 RVA: 0x0017EDC8 File Offset: 0x0017CFC8
	protected override void OnGetSharePlatform(string str)
	{
		PlatformSdkIos.SharePlatform sharePlatform = Json.Parse<PlatformSdkIos.SharePlatform>(str, null);
		if (sharePlatform.KRMAINLAND_SDK_EVENT_KEY_RESULT == 0)
		{
			PlatformSdkIos.SharePlatformContent[] array = Json.Parse<PlatformSdkIos.SharePlatformContent[]>(sharePlatform.KRMAINLAND_SDK_EVENT_KEY_DATA, null);
			List<SharePlatformSt> shareResult = new List<SharePlatformSt>();
			if (array != null)
			{
				foreach (PlatformSdkIos.SharePlatformContent sharePlatformContent in array)
				{
					SharePlatformSt sharePlatformSt = new SharePlatformSt();
					sharePlatformSt.IconUrl = sharePlatformContent.iconUrl;
					sharePlatformSt.PlatformId = sharePlatformContent.platform.ToString();
					shareResult.Add(sharePlatformSt);
				}
			}
			this.GetSharePlatformCallBackList.ForEach(delegate(Action<SharePlatformSt[]> value)
			{
				value(shareResult.ToArray());
			});
			this.GetSharePlatformCallBackList = new List<Action<SharePlatformSt[]>>();
		}
		base.OnGetSharePlatform(str);
	}

	// Token: 0x06005FC1 RID: 24513 RVA: 0x0017EE84 File Offset: 0x0017D084
	public override void SetFont()
	{
		string deviceFontAsset = ModelBase<KuroSdkModel>.Instance.GetDeviceFontAsset();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "SetFont";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("fontPath", deviceFontAsset);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		UKuroSDKManager.SetFont(deviceFontAsset);
	}

	// Token: 0x06005FC2 RID: 24514 RVA: 0x0017EECC File Offset: 0x0017D0CC
	protected unsafe override void OnShareResult(int code, string jsonStr, string msg)
	{
		string text = jsonStr.Replace("\n", "").Replace(" ", "");
		PlatformSdkIos.ShareResult shareResult = Json.Parse<PlatformSdkIos.ShareResult>(text, null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "OnShareResult";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("code", code);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("platform", jsonStr);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("finalMsg", text);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("shareResult", shareResult);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		if (shareResult != null && shareResult.KRMAINLAND_SDK_EVENT_KEY_RESULT)
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnShareResult, true);
			return;
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnShareResult, false);
	}

	// Token: 0x06005FC3 RID: 24515 RVA: 0x0017EFB7 File Offset: 0x0017D1B7
	private string Getidfv()
	{
		return this.GetSdkParamData("idfv");
	}

	// Token: 0x06005FC4 RID: 24516 RVA: 0x0017EFC4 File Offset: 0x0017D1C4
	public override string GetJyDid()
	{
		return this.GetSdkParamData("jyDeviceId");
	}

	// Token: 0x06005FC5 RID: 24517 RVA: 0x0017EFD4 File Offset: 0x0017D1D4
	private string GetSdkParamData(string needParam)
	{
		if (this.SdkParamCacheMap.Count == 0)
		{
			string[] array = UKuroSDKManager.GetSdkParams("").Split(',', StringSplitOptions.None);
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				string[] array2 = array[i].Split('=', StringSplitOptions.None);
				if (array2.Length == 2)
				{
					this.SdkParamCacheMap[array2[0]] = array2[1];
				}
			}
		}
		string text = this.SdkParamCacheMap.ContainsKey(needParam) ? this.SdkParamCacheMap[needParam] : null;
		if (text != null && !StringUtils.IsEmpty(text))
		{
			return text;
		}
		return "";
	}

	// Token: 0x06005FC6 RID: 24518 RVA: 0x0017F068 File Offset: 0x0017D268
	public override void OpenExternalUrl(string url)
	{
		UKuroSDKManager.OpenDefaultWebView(url);
	}

	// Token: 0x06005FC7 RID: 24519 RVA: 0x0017F070 File Offset: 0x0017D270
	protected override int CurrentPlatformYearReviewTime()
	{
		return 3;
	}

	// Token: 0x06005FC8 RID: 24520 RVA: 0x0017F073 File Offset: 0x0017D273
	protected unsafe void KuroBindExternalLoginResult()
	{
		UKuroSDKManager.Get().ExternalLoginCallBack.Clear();
		UKuroSDKManager.Get().ExternalLoginCallBack.Add(delegate(bool result, string msg)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.KuroSdk;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "ShowExternalLoginUI";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("result", result);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("msg", msg);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (result)
			{
				this.ExternalLoginState = true;
				base.QueryExternalAchievement();
			}
			this.ExternalLoginState = result;
		});
	}

	// Token: 0x06005FC9 RID: 24521 RVA: 0x0017F09F File Offset: 0x0017D29F
	protected override void BindExternalEvent()
	{
		this.KuroBindExternalLoginResult();
		base.KuroBindExternalAchievementWriteResult();
		base.KuroBindExternalAchievementQueryResult();
	}

	// Token: 0x06005FCA RID: 24522 RVA: 0x0017F0B3 File Offset: 0x0017D2B3
	public override void UnlockSdkTrophy(string id)
	{
		this.UpdateExternalAchievementProgress(id, 100);
	}

	// Token: 0x06005FCB RID: 24523 RVA: 0x0017F0C0 File Offset: 0x0017D2C0
	public void UpdateExternalAchievementProgress(string achievementName, int progress)
	{
		if (!this.ExternalLoginState)
		{
			return;
		}
		if ((this.AchievementMap.ContainsKey(achievementName) ? this.AchievementMap[achievementName].Progress : 0) >= 100)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "UpdateExternalAchievementProgress";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("achievementName", achievementName);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		SdkAchievementContentData sdkAchievementContentData = new SdkAchievementContentData();
		sdkAchievementContentData.AchievementId = achievementName;
		sdkAchievementContentData.Progress = progress;
		UKuroSDKManager.WriteExternalAchievements(Json.Stringify<SdkAchievementData>(new SdkAchievementData
		{
			Achievements = new SdkAchievementContentData[]
			{
				sdkAchievementContentData
			}
		}, null) ?? "");
	}

	// Token: 0x04002E08 RID: 11784
	private const int MAXREVIEWTIME = 3;

	// Token: 0x04002E09 RID: 11785
	private readonly Dictionary<string, string> SdkParamCacheMap = new Dictionary<string, string>();

	// Token: 0x04002E0A RID: 11786
	public readonly Action<string> AnnounceRedPointCallBack = delegate(string result)
	{
		if (result.Contains("showRed") && (result.Contains("1") || result.Contains("YES")))
		{
			ControllerBase<KuroSdkController>.Instance.SetPostWebViewRedPointState(true);
			Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
			return;
		}
		ControllerBase<KuroSdkController>.Instance.SetPostWebViewRedPointState(false);
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
	};

	// Token: 0x02007319 RID: 29465
	public interface ISharePlatform
	{
		// Token: 0x1700A7A7 RID: 42919
		// (get) Token: 0x06046B29 RID: 289577
		// (set) Token: 0x06046B2A RID: 289578
		string KRMAINLAND_SDK_EVENT_KEY_DATA { get; set; }

		// Token: 0x1700A7A8 RID: 42920
		// (get) Token: 0x06046B2B RID: 289579
		// (set) Token: 0x06046B2C RID: 289580
		int KRMAINLAND_SDK_EVENT_KEY_RESULT { get; set; }
	}

	// Token: 0x0200731A RID: 29466
	[Nullable(0)]
	public class SharePlatform : PlatformSdkIos.ISharePlatform
	{
		// Token: 0x1700A7A9 RID: 42921
		// (get) Token: 0x06046B2D RID: 289581 RVA: 0x012C16EA File Offset: 0x012BF8EA
		// (set) Token: 0x06046B2E RID: 289582 RVA: 0x012C16F2 File Offset: 0x012BF8F2
		public string KRMAINLAND_SDK_EVENT_KEY_DATA { get; set; }

		// Token: 0x1700A7AA RID: 42922
		// (get) Token: 0x06046B2F RID: 289583 RVA: 0x012C16FB File Offset: 0x012BF8FB
		// (set) Token: 0x06046B30 RID: 289584 RVA: 0x012C1703 File Offset: 0x012BF903
		public int KRMAINLAND_SDK_EVENT_KEY_RESULT { get; set; }
	}

	// Token: 0x0200731B RID: 29467
	public interface ISharePlatformContent
	{
		// Token: 0x1700A7AB RID: 42923
		// (get) Token: 0x06046B32 RID: 289586
		// (set) Token: 0x06046B33 RID: 289587
		string iconUrl { get; set; }

		// Token: 0x1700A7AC RID: 42924
		// (get) Token: 0x06046B34 RID: 289588
		// (set) Token: 0x06046B35 RID: 289589
		string platform { get; set; }
	}

	// Token: 0x0200731C RID: 29468
	[Nullable(0)]
	public class SharePlatformContent : PlatformSdkIos.ISharePlatformContent
	{
		// Token: 0x1700A7AD RID: 42925
		// (get) Token: 0x06046B36 RID: 289590 RVA: 0x012C1714 File Offset: 0x012BF914
		// (set) Token: 0x06046B37 RID: 289591 RVA: 0x012C171C File Offset: 0x012BF91C
		public string iconUrl { get; set; }

		// Token: 0x1700A7AE RID: 42926
		// (get) Token: 0x06046B38 RID: 289592 RVA: 0x012C1725 File Offset: 0x012BF925
		// (set) Token: 0x06046B39 RID: 289593 RVA: 0x012C172D File Offset: 0x012BF92D
		public string platform { get; set; }
	}

	// Token: 0x0200731D RID: 29469
	public interface IShareResult
	{
		// Token: 0x1700A7AF RID: 42927
		// (get) Token: 0x06046B3B RID: 289595
		// (set) Token: 0x06046B3C RID: 289596
		bool KRMAINLAND_SDK_EVENT_KEY_RESULT { get; set; }

		// Token: 0x1700A7B0 RID: 42928
		// (get) Token: 0x06046B3D RID: 289597
		// (set) Token: 0x06046B3E RID: 289598
		string KRMAINLAND_SDK_EVENT_KEY_REASON { get; set; }
	}

	// Token: 0x0200731E RID: 29470
	[Nullable(0)]
	public class ShareResult : PlatformSdkIos.IShareResult
	{
		// Token: 0x1700A7B1 RID: 42929
		// (get) Token: 0x06046B3F RID: 289599 RVA: 0x012C173E File Offset: 0x012BF93E
		// (set) Token: 0x06046B40 RID: 289600 RVA: 0x012C1746 File Offset: 0x012BF946
		public bool KRMAINLAND_SDK_EVENT_KEY_RESULT { get; set; }

		// Token: 0x1700A7B2 RID: 42930
		// (get) Token: 0x06046B41 RID: 289601 RVA: 0x012C174F File Offset: 0x012BF94F
		// (set) Token: 0x06046B42 RID: 289602 RVA: 0x012C1757 File Offset: 0x012BF957
		public string KRMAINLAND_SDK_EVENT_KEY_REASON { get; set; }
	}

	// Token: 0x0200731F RID: 29471
	[NullableContext(0)]
	public class ISdkCustomerService
	{
		// Token: 0x04027ED4 RID: 163540
		[Nullable(1)]
		public string cuid;

		// Token: 0x04027ED5 RID: 163541
		public int isredot;
	}
}
