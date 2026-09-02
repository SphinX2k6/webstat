using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.HotPatchKuroSdk;
using CSharpScript.Launcher.Platform.PlatformSdk;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Util;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.PackageUpdate
{
	// Token: 0x020045D0 RID: 17872
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PackageUpdateController : Singleton<PackageUpdateController>
	{
		// Token: 0x0602ED38 RID: 191800 RVA: 0x00B16AA4 File Offset: 0x00B14CA4
		public UniTask TryOpenPackageUpdateTipsView(HotFixManager view)
		{
			PackageUpdateController.<TryOpenPackageUpdateTipsView>d__14 <TryOpenPackageUpdateTipsView>d__;
			<TryOpenPackageUpdateTipsView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryOpenPackageUpdateTipsView>d__.<>4__this = this;
			<TryOpenPackageUpdateTipsView>d__.view = view;
			<TryOpenPackageUpdateTipsView>d__.<>1__state = -1;
			<TryOpenPackageUpdateTipsView>d__.<>t__builder.Start<PackageUpdateController.<TryOpenPackageUpdateTipsView>d__14>(ref <TryOpenPackageUpdateTipsView>d__);
			return <TryOpenPackageUpdateTipsView>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED39 RID: 191801 RVA: 0x00B16AF0 File Offset: 0x00B14CF0
		private unsafe void InitParam()
		{
			string text = "";
			if (Singleton<HotPatchKuroSdk>.Instance.CanUseSdk())
			{
				text = UKuroSDKManager.GetPackageId();
			}
			else if (Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetPackageId() != "")
			{
				text = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetPackageId();
			}
			this.CurrentPackageId = text;
			this.ExtraParam = this.GetExtraParam();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "整包配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("currentPackageId", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("exParam", this.ExtraParam);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0602ED3A RID: 191802 RVA: 0x00B16BAC File Offset: 0x00B14DAC
		private string GetExtraParam()
		{
			string packageConfigOrDefault = Singleton<BaseConfigController>.Instance.GetPackageConfigOrDefault("PatchVersion", null);
			string value = KuroApplication.IniPlatformName();
			string appVersion = UKuroLauncherLibrary.GetAppVersion();
			string publicValue = Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea");
			string value2 = Singleton<LauncherLanguageLib>.Instance.PackageLanguage ?? "";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(58, 6);
			defaultInterpolatedStringHandler.AppendLiteral("packageId=");
			defaultInterpolatedStringHandler.AppendFormatted(this.CurrentPackageId);
			defaultInterpolatedStringHandler.AppendLiteral("&platform=");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("&appVersion=");
			defaultInterpolatedStringHandler.AppendFormatted(appVersion);
			defaultInterpolatedStringHandler.AppendLiteral("&patchVersion=");
			defaultInterpolatedStringHandler.AppendFormatted(packageConfigOrDefault);
			defaultInterpolatedStringHandler.AppendLiteral("&area=");
			defaultInterpolatedStringHandler.AppendFormatted(publicValue);
			defaultInterpolatedStringHandler.AppendLiteral("&lang=");
			defaultInterpolatedStringHandler.AppendFormatted(value2);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602ED3B RID: 191803 RVA: 0x00B16C8A File Offset: 0x00B14E8A
		public void TryOpenParallelPackageUpdateUrl()
		{
			this.InitParam();
			this.HttpParallelUpdateDelegate = global::DelegateUtils.ToManualReleaseDelegate<FHttpResponseHandle>(new Action<bool, int, string>(this.OnHttpParallelCallBack));
			this.OpenParallelPackageUpdateUrl();
		}

		// Token: 0x0602ED3C RID: 191804 RVA: 0x00B16CB0 File Offset: 0x00B14EB0
		private void TryOpenUrl(IUpdateUrl prefix, string extraParam, FHttpResponseHandle httpDelegate)
		{
			string url = prefix.MainUrl + "?" + extraParam;
			TMap<string, string> defaultHeader = UKuroHttp.GetDefaultHeader();
			UKuroHttp.Get(url, defaultHeader, httpDelegate, 0f);
		}

		// Token: 0x0602ED3D RID: 191805 RVA: 0x00B16CE4 File Offset: 0x00B14EE4
		private void OnHttpDescCallBack(bool state, int code, string data)
		{
			EntryJson cdnReturnConfigInfo = Singleton<BaseConfigController>.Instance.GetCdnReturnConfigInfo();
			this.OnHttpCallBack(cdnReturnConfigInfo.PackageUpdateDescUrl, this.ExtraParam, state, code, data);
		}

		// Token: 0x0602ED3E RID: 191806 RVA: 0x00B16D14 File Offset: 0x00B14F14
		private void OnHttpUpdateCallBack(bool state, int code, string data)
		{
			EntryJson cdnReturnConfigInfo = Singleton<BaseConfigController>.Instance.GetCdnReturnConfigInfo();
			this.OnHttpCallBack(cdnReturnConfigInfo.PackageUpdateUrl, this.ExtraParam, state, code, data);
		}

		// Token: 0x0602ED3F RID: 191807 RVA: 0x00B16D44 File Offset: 0x00B14F44
		private void OnHttpParallelCallBack(bool state, int code, string data)
		{
			EntryJson cdnReturnConfigInfo = Singleton<BaseConfigController>.Instance.GetCdnReturnConfigInfo();
			this.OnHttpCallBack(cdnReturnConfigInfo.PackageUpdateUrl, this.ExtraParam, state, code, data);
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<bool, int, string>(this.OnHttpParallelCallBack));
			this.HttpParallelUpdateDelegate = null;
		}

		// Token: 0x0602ED40 RID: 191808 RVA: 0x00B16D8C File Offset: 0x00B14F8C
		private void OnHttpCallBack(IUpdateUrl prefix, string extraParam, bool state, int code, string data)
		{
			if (code != 200)
			{
				string text = prefix.SubUrl + "?" + extraParam;
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "打开链接";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("updateData!.descUrl", text);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().OpenExternalUrl(text);
				return;
			}
			string text2 = prefix.MainUrl + "?" + extraParam;
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "打开链接";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("updateData!.descUrl", text2);
			instance2.Info(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().OpenExternalUrl(text2);
		}

		// Token: 0x0602ED41 RID: 191809 RVA: 0x00B16E30 File Offset: 0x00B15030
		private void OpenParallelPackageUpdateUrl()
		{
			IUpdateUrl packageUpdateUrl = Singleton<BaseConfigController>.Instance.GetCdnReturnConfigInfo().PackageUpdateUrl;
			this.TryOpenUrl(packageUpdateUrl, this.ExtraParam, this.HttpParallelUpdateDelegate);
		}

		// Token: 0x0602ED42 RID: 191810 RVA: 0x00B16E60 File Offset: 0x00B15060
		private UniTask OnGetPackageUpdateData(HotFixManager view)
		{
			PackageUpdateController.<OnGetPackageUpdateData>d__24 <OnGetPackageUpdateData>d__;
			<OnGetPackageUpdateData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnGetPackageUpdateData>d__.<>4__this = this;
			<OnGetPackageUpdateData>d__.view = view;
			<OnGetPackageUpdateData>d__.<>1__state = -1;
			<OnGetPackageUpdateData>d__.<>t__builder.Start<PackageUpdateController.<OnGetPackageUpdateData>d__24>(ref <OnGetPackageUpdateData>d__);
			return <OnGetPackageUpdateData>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED43 RID: 191811 RVA: 0x00B16EAC File Offset: 0x00B150AC
		private bool PlayStationPackageIdListContains(string id)
		{
			for (int i = 0; i < this.PlayStationPackageIdList.Length; i++)
			{
				if (this.PlayStationPackageIdList[i] == id)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0602ED44 RID: 191812 RVA: 0x00B16EE0 File Offset: 0x00B150E0
		private UniTask CheckIfHaveNewVersionAndShowTips(HotFixManager view, bool canSelect, Action leftCallBack, Action rightCallBack, Action middleCallBack)
		{
			PackageUpdateController.<CheckIfHaveNewVersionAndShowTips>d__26 <CheckIfHaveNewVersionAndShowTips>d__;
			<CheckIfHaveNewVersionAndShowTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckIfHaveNewVersionAndShowTips>d__.view = view;
			<CheckIfHaveNewVersionAndShowTips>d__.canSelect = canSelect;
			<CheckIfHaveNewVersionAndShowTips>d__.leftCallBack = leftCallBack;
			<CheckIfHaveNewVersionAndShowTips>d__.rightCallBack = rightCallBack;
			<CheckIfHaveNewVersionAndShowTips>d__.middleCallBack = middleCallBack;
			<CheckIfHaveNewVersionAndShowTips>d__.<>1__state = -1;
			<CheckIfHaveNewVersionAndShowTips>d__.<>t__builder.Start<PackageUpdateController.<CheckIfHaveNewVersionAndShowTips>d__26>(ref <CheckIfHaveNewVersionAndShowTips>d__);
			return <CheckIfHaveNewVersionAndShowTips>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED45 RID: 191813 RVA: 0x00B16F48 File Offset: 0x00B15148
		public PackageUpdateController()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary["A1351"] = "https://apps.apple.com/cn/app/%E9%B8%A3%E6%BD%AE/id6450693428";
			dictionary["A1725"] = "https://apps.apple.com/us/app/wuthering-waves/id6475033368";
			dictionary["A1723"] = "https://play.google.com/store/apps/details?id=com.kurogame.wutheringwaves.global";
			dictionary["A1475"] = "https://apps.apple.com/cn/app/%E9%B8%A3%E6%BD%AE/id6450693428";
			dictionary["A1828"] = "https://apps.apple.com/us/app/wuthering-waves/id6475033368";
			this.PkgIdLinkMap = dictionary;
			this.PlayStationPackageIdList = new string[]
			{
				"A1768",
				"A1788",
				"A1801",
				"A1865"
			};
			base..ctor();
		}

		// Token: 0x0401AA25 RID: 109093
		private const string TAPPACKAGEID = "A1425";

		// Token: 0x0401AA26 RID: 109094
		private const string CNIOS = "A1351";

		// Token: 0x0401AA27 RID: 109095
		private const string GLOBALIOS = "A1725";

		// Token: 0x0401AA28 RID: 109096
		private const string GLOBALANDROID = "A1723";

		// Token: 0x0401AA29 RID: 109097
		private const string CNMAC = "A1475";

		// Token: 0x0401AA2A RID: 109098
		private const string GLOBALMAC = "A1828";

		// Token: 0x0401AA2B RID: 109099
		private bool TapInitState;

		// Token: 0x0401AA2C RID: 109100
		[Nullable(2)]
		private FHttpResponseHandle HttpUpdateDelegate;

		// Token: 0x0401AA2D RID: 109101
		[Nullable(2)]
		private FHttpResponseHandle HttpUpdateDescDelegate;

		// Token: 0x0401AA2E RID: 109102
		[Nullable(2)]
		private FHttpResponseHandle HttpParallelUpdateDelegate;

		// Token: 0x0401AA2F RID: 109103
		private string ExtraParam = "";

		// Token: 0x0401AA30 RID: 109104
		private string CurrentPackageId = "";

		// Token: 0x0401AA31 RID: 109105
		private readonly Dictionary<string, string> PkgIdLinkMap;

		// Token: 0x0401AA32 RID: 109106
		private readonly string[] PlayStationPackageIdList;
	}
}
