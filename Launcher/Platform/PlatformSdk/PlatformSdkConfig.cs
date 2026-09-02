using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Util;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x0200455D RID: 17757
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PlatformSdkConfig : Singleton<PlatformSdkConfig>
	{
		// Token: 0x0602EB58 RID: 191320 RVA: 0x00B110E4 File Offset: 0x00B0F2E4
		public void Initialize()
		{
			string configPath = this.GetConfigPath();
			string text = null;
			if (!UKuroStaticLibrary.LoadFileToString(ref text, configPath))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "[PlatformSdkNew]PlatformSdkConfig.Initialize failed";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", configPath);
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.IsGlobal = (Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea") != "CN");
			this.Json = LauncherJson.Parse<IConfigJson>(text, null);
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "[PlatformSdkNew]PlatformSdkConfig.Initialized";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Json", this.Json);
			instance2.Info(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.Initialized = true;
		}

		// Token: 0x0602EB59 RID: 191321 RVA: 0x00B11184 File Offset: 0x00B0F384
		private string GetApplicationReleaseType()
		{
			Dictionary<string, string> sdkEnvironment = Singleton<BaseConfigController>.Instance.GetSdkEnvironment();
			if (sdkEnvironment == null)
			{
				return "Product";
			}
			string key = KuroApplication.IniPlatformName();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "GetApplicationReleaseType";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("platformName", sdkEnvironment.GetValueOrDefault(key));
			instance.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			string text;
			if (sdkEnvironment.TryGetValue(key, out text) && !string.IsNullOrEmpty(text))
			{
				return text;
			}
			return "Product";
		}

		// Token: 0x0602EB5A RID: 191322 RVA: 0x00B111F0 File Offset: 0x00B0F3F0
		private IPlatformReleaseData GetPlatformReleaseData()
		{
			IPlatformData platformData = this.GetPlatformData();
			string applicationReleaseType = this.GetApplicationReleaseType();
			if (applicationReleaseType == "Development")
			{
				return platformData.Development ?? new IPlatformReleaseData();
			}
			if (applicationReleaseType == "Product")
			{
				return platformData.Release ?? new IPlatformReleaseData();
			}
			if (!(applicationReleaseType == "Prerelease"))
			{
				return platformData.Development ?? new IPlatformReleaseData();
			}
			return platformData.PreRelease ?? new IPlatformReleaseData();
		}

		// Token: 0x0602EB5B RID: 191323 RVA: 0x00B11274 File Offset: 0x00B0F474
		private IPlatformData GetPlatformData()
		{
			if (!this.Initialized)
			{
				this.Initialize();
			}
			if (Singleton<Platform>.Instance.Type == EPlatformType.PS5 && this.Json != null && this.Json.PS5 != null)
			{
				return this.Json.PS5;
			}
			return new IPlatformData();
		}

		// Token: 0x0602EB5C RID: 191324 RVA: 0x00B112C2 File Offset: 0x00B0F4C2
		private string GetConfigPath()
		{
			if (this.ConfigPath == null)
			{
				this.ConfigPath = UBlueprintPathsLibrary.ProjectConfigDir() + "Kuro/KuroPlatformSdkConfig.json";
			}
			return this.ConfigPath;
		}

		// Token: 0x0602EB5D RID: 191325 RVA: 0x00B112E7 File Offset: 0x00B0F4E7
		public string GetProjectId()
		{
			return this.GetPlatformData().projectId ?? "";
		}

		// Token: 0x0602EB5E RID: 191326 RVA: 0x00B112FD File Offset: 0x00B0F4FD
		public string GetProductId()
		{
			return this.GetPlatformReleaseData().productId ?? "";
		}

		// Token: 0x0602EB5F RID: 191327 RVA: 0x00B11313 File Offset: 0x00B0F513
		public string GetChannelId()
		{
			return this.GetPlatformData().channelId ?? "";
		}

		// Token: 0x0602EB60 RID: 191328 RVA: 0x00B11329 File Offset: 0x00B0F529
		public string GetPlatform()
		{
			return this.GetPlatformData().platform ?? "";
		}

		// Token: 0x0602EB61 RID: 191329 RVA: 0x00B1133F File Offset: 0x00B0F53F
		public string GetVersion()
		{
			return this.GetPlatformData().version ?? "";
		}

		// Token: 0x0602EB62 RID: 191330 RVA: 0x00B11355 File Offset: 0x00B0F555
		public string GetSdkVersion()
		{
			return this.GetPlatformData().sdkVersion ?? "";
		}

		// Token: 0x0602EB63 RID: 191331 RVA: 0x00B1136B File Offset: 0x00B0F56B
		public string GetSdkServerVersion()
		{
			return this.GetPlatformData().sdkServerVersion ?? "";
		}

		// Token: 0x0602EB64 RID: 191332 RVA: 0x00B11384 File Offset: 0x00B0F584
		private string ReplaceLanguageString(string inString)
		{
			string str = Singleton<LauncherLanguageLib>.Instance.PackageLanguage ?? "";
			return inString.Replace("language_{0}", "language_" + str);
		}

		// Token: 0x0602EB65 RID: 191333 RVA: 0x00B113BC File Offset: 0x00B0F5BC
		public string GetPrivacyPolicy()
		{
			if (this.SdkServerConfig == null)
			{
				return "";
			}
			string privacyPolicy = this.SdkServerConfig.PrivacyPolicy;
			if (this.IsGlobal && !string.IsNullOrEmpty(this.SdkServerConfig.PrivacyPolicy))
			{
				return this.ReplaceLanguageString(privacyPolicy ?? "");
			}
			return privacyPolicy ?? "";
		}

		// Token: 0x0602EB66 RID: 191334 RVA: 0x00B11418 File Offset: 0x00B0F618
		public string GetTermsOfService()
		{
			if (this.SdkServerConfig == null)
			{
				return "";
			}
			string termsOfService = this.SdkServerConfig.TermsOfService;
			if (this.IsGlobal && !string.IsNullOrEmpty(this.SdkServerConfig.TermsOfService))
			{
				return this.ReplaceLanguageString(termsOfService ?? "");
			}
			return termsOfService ?? "";
		}

		// Token: 0x0602EB67 RID: 191335 RVA: 0x00B11474 File Offset: 0x00B0F674
		public string GetChildPolicy()
		{
			if (this.SdkServerConfig == null)
			{
				return "";
			}
			string childProtocol = this.SdkServerConfig.ChildProtocol;
			if (this.IsGlobal && !string.IsNullOrEmpty(this.SdkServerConfig.ChildProtocol))
			{
				return this.ReplaceLanguageString(childProtocol ?? "");
			}
			return childProtocol ?? "";
		}

		// Token: 0x0602EB68 RID: 191336 RVA: 0x00B114D0 File Offset: 0x00B0F6D0
		public string GetServerUrl(bool spare = false)
		{
			int num = (spare > false) ? 1 : 0;
			if (this.SdkServerConfig != null && this.SdkServerConfig.ServerUrl != null)
			{
				if (this.SdkServerConfig.ServerUrl.Count > num)
				{
					return this.SdkServerConfig.ServerUrl[num];
				}
				if (this.SdkServerConfig.ServerUrl.Count > 0)
				{
					return this.SdkServerConfig.ServerUrl[0];
				}
			}
			Singleton<LauncherLog>.Instance.Error("获取服务器地址失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return "";
		}

		// Token: 0x0602EB69 RID: 191337 RVA: 0x00B11560 File Offset: 0x00B0F760
		public string GetPayUrl(bool spare = false)
		{
			int num = (spare > false) ? 1 : 0;
			if (this.SdkServerConfig != null && this.SdkServerConfig.PayUrl != null)
			{
				if (this.SdkServerConfig.PayUrl.Count > num)
				{
					return this.SdkServerConfig.PayUrl[num];
				}
				if (this.SdkServerConfig.PayUrl.Count > 0)
				{
					return this.SdkServerConfig.PayUrl[0];
				}
			}
			Singleton<LauncherLog>.Instance.Error("获取支付地址失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return "";
		}

		// Token: 0x0602EB6A RID: 191338 RVA: 0x00B115EE File Offset: 0x00B0F7EE
		public string GetClientId()
		{
			if (this.SdkServerConfig != null)
			{
				return this.SdkServerConfig.client_id ?? "";
			}
			return "";
		}

		// Token: 0x0602EB6B RID: 191339 RVA: 0x00B11612 File Offset: 0x00B0F812
		public string GetClientSecret()
		{
			if (this.SdkServerConfig != null)
			{
				return this.SdkServerConfig.client_secret ?? "";
			}
			return "";
		}

		// Token: 0x0602EB6C RID: 191340 RVA: 0x00B11636 File Offset: 0x00B0F836
		public string GetPlatformPkg()
		{
			if (this.SdkServerConfig != null)
			{
				return this.SdkServerConfig.platform_pkg ?? "";
			}
			return "";
		}

		// Token: 0x0602EB6D RID: 191341 RVA: 0x00B1165A File Offset: 0x00B0F85A
		public string GetPlatformClientId()
		{
			if (this.SdkServerConfig != null)
			{
				return this.SdkServerConfig.platform_client_id ?? "";
			}
			return "";
		}

		// Token: 0x0602EB6E RID: 191342 RVA: 0x00B1167E File Offset: 0x00B0F87E
		public string GetPlatformClientSecret()
		{
			if (this.SdkServerConfig != null)
			{
				return this.SdkServerConfig.platform_client_secret ?? "";
			}
			return "";
		}

		// Token: 0x0602EB6F RID: 191343 RVA: 0x00B116A2 File Offset: 0x00B0F8A2
		public string GetUserCenterUrl()
		{
			if (this.SdkServerConfig != null)
			{
				return this.SdkServerConfig.UserCenterUrl ?? "";
			}
			return "";
		}

		// Token: 0x0602EB70 RID: 191344 RVA: 0x00B116C6 File Offset: 0x00B0F8C6
		public string GetDataReportUrl()
		{
			if (this.SdkServerConfig != null)
			{
				return this.SdkServerConfig.DataReportUrl ?? "";
			}
			return "";
		}

		// Token: 0x0602EB71 RID: 191345 RVA: 0x00B116EA File Offset: 0x00B0F8EA
		public string GetKuroDataReportUrl()
		{
			if (this.SdkServerConfig != null)
			{
				return this.SdkServerConfig.kuro_DataReportUrl ?? "";
			}
			return "";
		}

		// Token: 0x0602EB72 RID: 191346 RVA: 0x00B1170E File Offset: 0x00B0F90E
		public string GetDataReportId()
		{
			if (this.SdkServerConfig != null)
			{
				return this.SdkServerConfig.DataReportId ?? "";
			}
			return "";
		}

		// Token: 0x0602EB73 RID: 191347 RVA: 0x00B11732 File Offset: 0x00B0F932
		public string GetCustomServiceUrl()
		{
			if (this.SdkServerConfig != null)
			{
				return this.SdkServerConfig.CustomServiceUrl ?? "";
			}
			return "";
		}

		// Token: 0x0602EB74 RID: 191348 RVA: 0x00B11758 File Offset: 0x00B0F958
		public unsafe string GetCustomerServiceUrl(string language)
		{
			CsLinkEntry csLinkEntry;
			this.CsDataMap.TryGetValue(language, out csLinkEntry);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "获取客服链接";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("data", this.CsDataMap);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("language", language);
			instance.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (csLinkEntry == null)
			{
				this.CsDataMap.TryGetValue("en", out csLinkEntry);
			}
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "获取客服链接";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("jsonLinkData.link", (csLinkEntry != null) ? csLinkEntry.link : null);
			instance2.Debug(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return ((csLinkEntry != null) ? csLinkEntry.link : null) ?? "";
		}

		// Token: 0x0602EB75 RID: 191349 RVA: 0x00B11824 File Offset: 0x00B0FA24
		private string BuildHttp(string httpPre)
		{
			string applicationReleaseType = this.GetApplicationReleaseType();
			string projectId = this.GetProjectId();
			string channelId = this.GetChannelId();
			string productId = this.GetProductId();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 5);
			defaultInterpolatedStringHandler.AppendFormatted(httpPre);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(applicationReleaseType);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(projectId);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(channelId);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(productId);
			defaultInterpolatedStringHandler.AppendLiteral("/config.json");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602EB76 RID: 191350 RVA: 0x00B118C4 File Offset: 0x00B0FAC4
		[NullableContext(0)]
		public UniTask<bool> RequestBaseData([Nullable(2)] HotFixManager view = null)
		{
			PlatformSdkConfig.<RequestBaseData>d__36 <RequestBaseData>d__;
			<RequestBaseData>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestBaseData>d__.<>4__this = this;
			<RequestBaseData>d__.view = view;
			<RequestBaseData>d__.<>1__state = -1;
			<RequestBaseData>d__.<>t__builder.Start<PlatformSdkConfig.<RequestBaseData>d__36>(ref <RequestBaseData>d__);
			return <RequestBaseData>d__.<>t__builder.Task;
		}

		// Token: 0x0602EB77 RID: 191351 RVA: 0x00B11910 File Offset: 0x00B0FB10
		public List<string> ShuffleList(List<string> list)
		{
			for (int i = list.Count - 1; i > 0; i--)
			{
				int index = this._shuffleRandom.Next(i + 1);
				string value = list[i];
				list[i] = list[index];
				list[index] = value;
			}
			return list;
		}

		// Token: 0x0602EB79 RID: 191353 RVA: 0x00B1197E File Offset: 0x00B0FB7E
		[CompilerGenerated]
		private string <RequestBaseData>g__GetHttpFunction|36_0(string httpPre)
		{
			return this.BuildHttp(httpPre);
		}

		// Token: 0x0401A8AA RID: 108714
		private readonly Dictionary<string, CsLinkEntry> CsDataMap = new Dictionary<string, CsLinkEntry>();

		// Token: 0x0401A8AB RID: 108715
		[Nullable(2)]
		private IConfigJson Json;

		// Token: 0x0401A8AC RID: 108716
		[Nullable(2)]
		private SdkPlatformConfig SdkServerConfig;

		// Token: 0x0401A8AD RID: 108717
		public bool IsGlobal;

		// Token: 0x0401A8AE RID: 108718
		[Nullable(2)]
		private string ConfigPath;

		// Token: 0x0401A8AF RID: 108719
		private bool Initialized;

		// Token: 0x0401A8B0 RID: 108720
		private readonly Random _shuffleRandom = new Random();
	}
}
