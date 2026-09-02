using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045BF RID: 17855
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PlatformSdkServer : Singleton<PlatformSdkServer>
	{
		// Token: 0x0602EC87 RID: 191623 RVA: 0x00B13114 File Offset: 0x00B11314
		public void SetLanguage(string lang)
		{
			this.Language = lang;
		}

		// Token: 0x17008077 RID: 32887
		// (get) Token: 0x0602EC88 RID: 191624 RVA: 0x00B1311D File Offset: 0x00B1131D
		public bool IsConnected
		{
			get
			{
				return this.ConnectData != null;
			}
		}

		// Token: 0x17008078 RID: 32888
		// (get) Token: 0x0602EC89 RID: 191625 RVA: 0x00B13128 File Offset: 0x00B11328
		public bool? IsReportEnable
		{
			get
			{
				IConnectResponseData connectData = this.ConnectData;
				if (connectData == null)
				{
					return null;
				}
				ClientSwitch clientSwitch = connectData.clientSwitch;
				if (clientSwitch == null)
				{
					return null;
				}
				return new bool?(clientSwitch.td);
			}
		}

		// Token: 0x17008079 RID: 32889
		// (get) Token: 0x0602EC8A RID: 191626 RVA: 0x00B13168 File Offset: 0x00B11368
		public bool? IsCustomerServiceEnable
		{
			get
			{
				IConnectResponseData connectData = this.ConnectData;
				if (connectData == null)
				{
					return null;
				}
				ClientSwitch clientSwitch = connectData.clientSwitch;
				if (clientSwitch == null)
				{
					return null;
				}
				return new bool?(clientSwitch.sobot);
			}
		}

		// Token: 0x1700807A RID: 32890
		// (get) Token: 0x0602EC8B RID: 191627 RVA: 0x00B131A8 File Offset: 0x00B113A8
		public bool? IsPsnLoginEnable
		{
			get
			{
				IConnectResponseData connectData = this.ConnectData;
				bool value;
				if (connectData == null)
				{
					value = false;
				}
				else
				{
					ThirdLogin thirdLogin = connectData.thirdLogin;
					int? num;
					if (thirdLogin == null)
					{
						num = null;
					}
					else
					{
						LoginElement psnLogin = thirdLogin.psnLogin;
						num = ((psnLogin != null) ? new int?(psnLogin.enabled) : null);
					}
					int? num2 = num;
					value = (num2.GetValueOrDefault() == 1);
				}
				return new bool?(value);
			}
		}

		// Token: 0x1700807B RID: 32891
		// (get) Token: 0x0602EC8C RID: 191628 RVA: 0x00B13204 File Offset: 0x00B11404
		public bool? IsPsnEmailLoginEnable
		{
			get
			{
				IConnectResponseData connectData = this.ConnectData;
				bool value;
				if (connectData == null)
				{
					value = false;
				}
				else
				{
					ThirdLogin thirdLogin = connectData.thirdLogin;
					int? num;
					if (thirdLogin == null)
					{
						num = null;
					}
					else
					{
						LoginElement psnEmailLogin = thirdLogin.psnEmailLogin;
						num = ((psnEmailLogin != null) ? new int?(psnEmailLogin.enabled) : null);
					}
					int? num2 = num;
					value = (num2.GetValueOrDefault() == 1);
				}
				return new bool?(value);
			}
		}

		// Token: 0x0602EC8D RID: 191629 RVA: 0x00B13260 File Offset: 0x00B11460
		[NullableContext(2)]
		public string GetUserCenterUrl()
		{
			IConnectResponseData connectData = this.ConnectData;
			if (connectData == null)
			{
				return null;
			}
			ClientUrl clientUrl = connectData.clientUrl;
			if (clientUrl == null)
			{
				return null;
			}
			return clientUrl.accCenterUrl;
		}

		// Token: 0x0602EC8E RID: 191630 RVA: 0x00B1327E File Offset: 0x00B1147E
		public void Initialize()
		{
		}

		// Token: 0x0602EC8F RID: 191631 RVA: 0x00B13280 File Offset: 0x00B11480
		public void InitCommonParam(string commonParam)
		{
			this.CommonParam = commonParam;
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]PlatformSdkServer.InitCommonParam";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CommonParam", this.CommonParam);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602EC90 RID: 191632 RVA: 0x00B132BC File Offset: 0x00B114BC
		public TMap<string, string> GenerateCommonHeader()
		{
			return new TMap<string, string>
			{
				{
					"Kr-Ver",
					Singleton<PlatformSdkConfig>.Instance.GetSdkServerVersion()
				},
				{
					"Content-Type",
					"application/x-www-form-urlencoded"
				},
				{
					"Accept-Language",
					this.Language
				}
			};
		}

		// Token: 0x0602EC91 RID: 191633 RVA: 0x00B132FC File Offset: 0x00B114FC
		public TMap<string, string> GeneratePayHeader(string productId, string version, string sdkVersion)
		{
			return new TMap<string, string>
			{
				{
					"Content-Type",
					"application/x-www-form-urlencoded"
				},
				{
					"kuro_gid",
					Singleton<PlatformSdkConfig>.Instance.GetProjectId()
				},
				{
					"kuro_app_id",
					productId
				},
				{
					"kuro_version",
					version
				},
				{
					"kuro_sdk_version",
					sdkVersion
				},
				{
					"kuro_lang",
					this.Language
				}
			};
		}

		// Token: 0x0602EC92 RID: 191634 RVA: 0x00B13368 File Offset: 0x00B11568
		public void SwitchUrl()
		{
			this.IsUseSpareUrl = !this.IsUseSpareUrl;
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]PlatformSdkServer.SwitchUrl";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("this.IsUseSpareUrl", this.IsUseSpareUrl);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602EC93 RID: 191635 RVA: 0x00B133B1 File Offset: 0x00B115B1
		private bool CheckHttpSuccess(bool success, int httpCode)
		{
			return success && httpCode == 200;
		}

		// Token: 0x0602EC94 RID: 191636 RVA: 0x00B133C0 File Offset: 0x00B115C0
		private bool CheckHttpHasResult(string data)
		{
			return data.Length != 0 && !(data == "{}") && !(data == "[]");
		}

		// Token: 0x0602EC95 RID: 191637 RVA: 0x00B133E8 File Offset: 0x00B115E8
		public unsafe void Connect(string param, TSDKConnectCallback callback)
		{
			PlatformSdkServer.<>c__DisplayClass25_0 CS$<>8__locals1 = new PlatformSdkServer.<>c__DisplayClass25_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			string text = Singleton<PlatformSdkConfig>.Instance.GetServerUrl(this.IsUseSpareUrl) + "/v2/sys/conf.lg";
			string text2 = this.CommonParam + param;
			TMap<string, string> item = this.GenerateCommonHeader();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]PlatformSdkServer.Connect";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("url", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("header", item);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("params", text2);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			UKuroHttp.Post(text, item, text2, global::DelegateUtils.ToManualReleaseDelegate<FHttpResponseHandle>(new Action<bool, int, string>(CS$<>8__locals1.<Connect>g__ResponseCallBack|0)), 10f);
		}

		// Token: 0x0602EC96 RID: 191638 RVA: 0x00B134C0 File Offset: 0x00B116C0
		private unsafe void LoginWithSpecifyUrl(string specifyUrl, string param, TSDKLoginCallback callback)
		{
			PlatformSdkServer.<>c__DisplayClass26_0 CS$<>8__locals1 = new PlatformSdkServer.<>c__DisplayClass26_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			CS$<>8__locals1.specifyUrl = specifyUrl;
			if (!this.IsConnected)
			{
				Singleton<LauncherLog>.Instance.Error("[PlatformSdkNew]PlatformSdkServer.Login failed, not connect to server", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.IsLogining)
			{
				Singleton<LauncherLog>.Instance.Error("[PlatformSdkNew]PlatformSdkServer.Login duplicate call", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.IsLogining = true;
			string text = Singleton<PlatformSdkConfig>.Instance.GetServerUrl(this.IsUseSpareUrl) + CS$<>8__locals1.specifyUrl;
			string text2 = this.CommonParam + param;
			TMap<string, string> item = this.GenerateCommonHeader();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]PlatformSdkServer.Login";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("url", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("header", item);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("params", text2);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			PlatformReportLogin eventData = new PlatformReportLogin();
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ReportToThirdParty(eventData);
			UKuroHttp.Post(text, item, text2, global::DelegateUtils.ToManualReleaseDelegate<FHttpResponseHandle>(new Action<bool, int, string>(CS$<>8__locals1.<LoginWithSpecifyUrl>g__ResponseCallBack|0)), 10f);
		}

		// Token: 0x0602EC97 RID: 191639 RVA: 0x00B13601 File Offset: 0x00B11801
		public void Login(string param, TSDKLoginCallback callback)
		{
			this.LoginWithSpecifyUrl("/v2/login/third/psn.lg", param, callback);
		}

		// Token: 0x0602EC98 RID: 191640 RVA: 0x00B13610 File Offset: 0x00B11810
		public void BindAccountThenLogin(string param, TSDKLoginCallback callback)
		{
			this.LoginWithSpecifyUrl("/v2/login/third/psnBind.lg", param, callback);
		}

		// Token: 0x0602EC99 RID: 191641 RVA: 0x00B13620 File Offset: 0x00B11820
		public unsafe void GetAccessToken(string loginCode, TSDKGetAccessTokenCallback callback)
		{
			PlatformSdkServer.<>c__DisplayClass29_0 CS$<>8__locals1 = new PlatformSdkServer.<>c__DisplayClass29_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			string clientId = Singleton<PlatformSdkConfig>.Instance.GetClientId();
			string clientSecret = Singleton<PlatformSdkConfig>.Instance.GetClientSecret();
			string commonParam = this.CommonParam;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(77, 3);
			defaultInterpolatedStringHandler.AppendLiteral("&code=");
			defaultInterpolatedStringHandler.AppendFormatted(loginCode);
			defaultInterpolatedStringHandler.AppendLiteral("&client_id=");
			defaultInterpolatedStringHandler.AppendFormatted(clientId);
			defaultInterpolatedStringHandler.AppendLiteral("&client_secret=");
			defaultInterpolatedStringHandler.AppendFormatted(clientSecret);
			defaultInterpolatedStringHandler.AppendLiteral("&grant_type=authorization_code&redirect_uri=1");
			string text = commonParam + defaultInterpolatedStringHandler.ToStringAndClear();
			string text2 = Singleton<PlatformSdkConfig>.Instance.GetServerUrl(this.IsUseSpareUrl) + "/v2/auth/getToken.lg";
			TMap<string, string> item = this.GenerateCommonHeader();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]PlatformSdkServer.GetAccessToken";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("url", text2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("header", item);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("params", text);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			UKuroHttp.Post(text2, item, text, global::DelegateUtils.ToManualReleaseDelegate<FHttpResponseHandle>(new Action<bool, int, string>(CS$<>8__locals1.<GetAccessToken>g__ResponseCallBack|0)), 10f);
		}

		// Token: 0x0602EC9A RID: 191642 RVA: 0x00B1376C File Offset: 0x00B1196C
		public unsafe void GetSdkRelation(string param, TSDKQuerySdkBlockCallBack callBack)
		{
			PlatformSdkServer.<>c__DisplayClass30_0 CS$<>8__locals1 = new PlatformSdkServer.<>c__DisplayClass30_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callBack = callBack;
			string text = this.CommonParam + param;
			string text2 = Singleton<PlatformSdkConfig>.Instance.GetServerUrl(this.IsUseSpareUrl) + "/v2/psn/block/states.lg";
			TMap<string, string> item = this.GenerateCommonHeader();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]PlatformSdkServer.GetSdkRelation";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("url", text2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("header", item);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("params", text);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			UKuroHttp.Post(text2, item, text, global::DelegateUtils.ToManualReleaseDelegate<FHttpResponseHandle>(new Action<bool, int, string>(CS$<>8__locals1.<GetSdkRelation>g__ResponseCallBack|0)), 10f);
		}

		// Token: 0x0602EC9B RID: 191643 RVA: 0x00B13844 File Offset: 0x00B11A44
		public unsafe void RenewAccessToken(string access_token, TSDKRenewAccessTokenCallback callback)
		{
			PlatformSdkServer.<>c__DisplayClass31_0 CS$<>8__locals1 = new PlatformSdkServer.<>c__DisplayClass31_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			string text = this.CommonParam + "&access_token=" + access_token;
			string text2 = Singleton<PlatformSdkConfig>.Instance.GetServerUrl(this.IsUseSpareUrl) + "/v2/heartbeat/tokenCheck.lg";
			TMap<string, string> item = this.GenerateCommonHeader();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]PlatformSdkServer.RenewAccessToken";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("url", text2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("header", item);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("params", text);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			PlatformReportSdkKeepAlive eventData = new PlatformReportSdkKeepAlive();
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ReportToThirdParty(eventData);
			UKuroHttp.Post(text2, item, text, global::DelegateUtils.ToManualReleaseDelegate<FHttpResponseHandle>(new Action<bool, int, string>(CS$<>8__locals1.<RenewAccessToken>g__ResponseCallBack|0)), 10f);
		}

		// Token: 0x0602EC9C RID: 191644 RVA: 0x00B13938 File Offset: 0x00B11B38
		public unsafe void RequestEmailAddressCode(string param, TSdkRequestEmailCodeCallback callBack)
		{
			PlatformSdkServer.<>c__DisplayClass32_0 CS$<>8__locals1 = new PlatformSdkServer.<>c__DisplayClass32_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callBack = callBack;
			string text = this.CommonParam + param;
			string text2 = Singleton<PlatformSdkConfig>.Instance.GetServerUrl(this.IsUseSpareUrl) + "/v2/email/psnLogin/send.lg";
			TMap<string, string> item = this.GenerateCommonHeader();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]PlatformSdkServer.RequestEmailAddressCode";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("url", text2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("header", item);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("params", text);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			PlatformReportClickSendCode eventData = new PlatformReportClickSendCode();
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ReportToThirdParty(eventData);
			UKuroHttp.Post(text2, item, text, global::DelegateUtils.ToManualReleaseDelegate<FHttpResponseHandle>(new Action<bool, int, string>(CS$<>8__locals1.<RequestEmailAddressCode>g__ResponseCallBack|0)), 10f);
		}

		// Token: 0x0602EC9D RID: 191645 RVA: 0x00B13A28 File Offset: 0x00B11C28
		public unsafe void QueryStoreProducts(TMap<string, string> payHeader, TSDKQueryGoodsCallback callback, params object[] keyValPairs)
		{
			PlatformSdkServer.<>c__DisplayClass33_0 CS$<>8__locals1 = new PlatformSdkServer.<>c__DisplayClass33_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			string text = Singleton<PlatformSdkConfig>.Instance.GetPayUrl(this.IsUseSpareUrl) + "/api/v1/prop/query.lg";
			string text2 = SdkServerEncodeHelper.MarkData(keyValPairs);
			string text3 = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
			string clientId = Singleton<PlatformSdkConfig>.Instance.GetClientId();
			string projectId = Singleton<PlatformSdkConfig>.Instance.GetProjectId();
			string value = SdkServerEncodeHelper.MarkSign(clientId, new string[]
			{
				"pcode",
				projectId,
				"data",
				text2,
				"timestamp",
				text3
			});
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 4);
			defaultInterpolatedStringHandler.AppendLiteral("pcode=");
			defaultInterpolatedStringHandler.AppendFormatted(projectId);
			defaultInterpolatedStringHandler.AppendLiteral("&data=");
			defaultInterpolatedStringHandler.AppendFormatted(Uri.EscapeDataString(text2));
			defaultInterpolatedStringHandler.AppendLiteral("&sign=");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("&timestamp=");
			defaultInterpolatedStringHandler.AppendFormatted(text3);
			string text4 = defaultInterpolatedStringHandler.ToStringAndClear();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]PlatformSdkServer.QueryStoreProducts";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("url", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("url", payHeader);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("params", text4);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("rawData", keyValPairs);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			UKuroHttp.Post(text, payHeader, text4, global::DelegateUtils.ToManualReleaseDelegate<FHttpResponseHandle>(new Action<bool, int, string>(CS$<>8__locals1.<QueryStoreProducts>g__ResponseCallBack|0)), 10f);
		}

		// Token: 0x0602EC9E RID: 191646 RVA: 0x00B13BD8 File Offset: 0x00B11DD8
		[return: Nullable(new byte[]
		{
			0,
			0,
			1,
			2,
			1
		})]
		public UniTask<ValueTuple<string, bool, List<IQueryGoodsResponseData>>> QueryStoreProductsAsync(TMap<string, string> payHeader, params object[] keyValPairs)
		{
			PlatformSdkServer.<QueryStoreProductsAsync>d__34 <QueryStoreProductsAsync>d__;
			<QueryStoreProductsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<ValueTuple<string, bool, List<IQueryGoodsResponseData>>>.Create();
			<QueryStoreProductsAsync>d__.<>4__this = this;
			<QueryStoreProductsAsync>d__.payHeader = payHeader;
			<QueryStoreProductsAsync>d__.keyValPairs = keyValPairs;
			<QueryStoreProductsAsync>d__.<>1__state = -1;
			<QueryStoreProductsAsync>d__.<>t__builder.Start<PlatformSdkServer.<QueryStoreProductsAsync>d__34>(ref <QueryStoreProductsAsync>d__);
			return <QueryStoreProductsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602EC9F RID: 191647 RVA: 0x00B13C2C File Offset: 0x00B11E2C
		public unsafe void RequestCheckoutProduct(ECheckoutReason reason, int env, TSdkCheckoutProductCallback callback, TMap<string, string> payHeader, params object[] keyValPairs)
		{
			PlatformSdkServer.<>c__DisplayClass35_0 CS$<>8__locals1 = new PlatformSdkServer.<>c__DisplayClass35_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			CS$<>8__locals1.reason = reason;
			CS$<>8__locals1.env = env;
			string text = Singleton<PlatformSdkConfig>.Instance.GetPayUrl(this.IsUseSpareUrl) + "/api/v1/callback/psn";
			string text2 = SdkServerEncodeHelper.MarkData(keyValPairs);
			string text3 = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
			string clientId = Singleton<PlatformSdkConfig>.Instance.GetClientId();
			string projectId = Singleton<PlatformSdkConfig>.Instance.GetProjectId();
			string value = SdkServerEncodeHelper.MarkSign(clientId, new string[]
			{
				"pcode",
				projectId,
				"data",
				text2,
				"timestamp",
				text3
			});
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 4);
			defaultInterpolatedStringHandler.AppendLiteral("pcode=");
			defaultInterpolatedStringHandler.AppendFormatted(projectId);
			defaultInterpolatedStringHandler.AppendLiteral("&data=");
			defaultInterpolatedStringHandler.AppendFormatted(Uri.EscapeDataString(text2));
			defaultInterpolatedStringHandler.AppendLiteral("&sign=");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("&timestamp=");
			defaultInterpolatedStringHandler.AppendFormatted(text3);
			string text4 = defaultInterpolatedStringHandler.ToStringAndClear();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]PlatformSdkServer.RequestCheckoutProduct";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("url", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("productKey", clientId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("payHeader", payHeader);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("params", text4);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("rawData", keyValPairs);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			PlatformReportUploadPsnBill platformReportUploadPsnBill = new PlatformReportUploadPsnBill();
			platformReportUploadPsnBill.psn_scene = this.GetReportScene(CS$<>8__locals1.reason);
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ReportToThirdParty(platformReportUploadPsnBill);
			UKuroHttp.Post(text, payHeader, text4, global::DelegateUtils.ToManualReleaseDelegate<FHttpResponseHandle>(new Action<bool, int, string>(CS$<>8__locals1.<RequestCheckoutProduct>g__ResponseCallBack|0)), 10f);
		}

		// Token: 0x0602ECA0 RID: 191648 RVA: 0x00B13E34 File Offset: 0x00B12034
		private string GetReportScene(ECheckoutReason scene)
		{
			string result = "";
			if (scene == ECheckoutReason.Login)
			{
				result = "2";
			}
			else if (scene == ECheckoutReason.AfterPay)
			{
				result = "1";
			}
			else if (scene == ECheckoutReason.StopGame)
			{
				result = "3";
			}
			return result;
		}

		// Token: 0x0602ECA1 RID: 191649 RVA: 0x00B13E6C File Offset: 0x00B1206C
		public unsafe void RequestReportData(string accessToken, string param, TSdkReportCallBack callBack)
		{
			PlatformSdkServer.<>c__DisplayClass37_0 CS$<>8__locals1 = new PlatformSdkServer.<>c__DisplayClass37_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callBack = callBack;
			string specifyChar = "JRps7QAydqSkYFN-T4wnBDhKLr8H3.u69mG2WjPgOxco0avZE5IUflMVbtzeX1iC";
			string text = UKuroStaticLibrary.Base64EncodeWithSpecifyCharWithConvertToUTF8(param, specifyChar);
			text = text.Replace("=", "");
			string text2 = "rOLe" + param + "jar";
			string text3 = UKuroStaticLibrary.Md5HashUTF8String(text2).ToUpper();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]PlatformSdkServer.RequestReportData";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("param", param);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("r_role", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("signUpper", text3);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("trySignStr", text2);
			instance.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 3);
			defaultInterpolatedStringHandler.AppendLiteral("&access_token=");
			defaultInterpolatedStringHandler.AppendFormatted(accessToken);
			defaultInterpolatedStringHandler.AppendLiteral("&r_role=");
			defaultInterpolatedStringHandler.AppendFormatted(text);
			defaultInterpolatedStringHandler.AppendLiteral("&r_sign=");
			defaultInterpolatedStringHandler.AppendFormatted(text3);
			string str = defaultInterpolatedStringHandler.ToStringAndClear();
			string text4 = this.CommonParam + str;
			string text5 = Singleton<PlatformSdkConfig>.Instance.GetServerUrl(this.IsUseSpareUrl) + "/v2/user/game/role.lg";
			TMap<string, string> item = this.GenerateCommonHeader();
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "[PlatformSdkNew]PlatformSdkServer.RequestReportData";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("url", text5);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("header", item);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("params", text4);
			instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			UKuroHttp.Post(text5, item, text4, global::DelegateUtils.ToManualReleaseDelegate<FHttpResponseHandle>(new Action<bool, int, string>(CS$<>8__locals1.<RequestReportData>g__ResponseCallBack|0)), 10f);
		}

		// Token: 0x0401A9C5 RID: 108997
		private const int HttpTimeout = 10;

		// Token: 0x0401A9C6 RID: 108998
		private bool IsUseSpareUrl;

		// Token: 0x0401A9C7 RID: 108999
		private string Language = "en";

		// Token: 0x0401A9C8 RID: 109000
		private string CommonParam = "";

		// Token: 0x0401A9C9 RID: 109001
		[Nullable(2)]
		private IConnectResponseData ConnectData;

		// Token: 0x0401A9CA RID: 109002
		private bool IsLogining;
	}
}
