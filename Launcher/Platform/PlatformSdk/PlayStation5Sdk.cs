using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Util;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045C7 RID: 17863
	[NullableContext(1)]
	[Nullable(0)]
	public class PlayStation5Sdk : PlatformSdkNew
	{
		// Token: 0x0602ECA7 RID: 191655 RVA: 0x00B140A4 File Offset: 0x00B122A4
		protected override bool OnInit()
		{
			AuthCodeData authCode = this.GetAuthCode(EPlayStaionScope.Login);
			if (authCode == null)
			{
				return false;
			}
			string userId = this.GetUserId();
			this.UniversalDataSystemManager = new UniversalDataSystemManager();
			this.UniversalDataSystemManager.Initialize(userId);
			this.UniversalDataSystemManager.Start();
			this.PlayStationTrophy = new PlayStationTrophy();
			this.PlayStationTrophy.Init(this.UniversalDataSystemManager, this).Forget();
			this.AuthCodeData = authCode;
			string cacheMapElement = UKuroStaticPS5Library.GetCacheMapElement("AgreeState");
			if (cacheMapElement != null && cacheMapElement == "1")
			{
				this.CacheAgreeState = true;
			}
			PlatformReportLaunchGame eventData = new PlatformReportLaunchGame();
			this.ReportToThirdParty(eventData);
			return true;
		}

		// Token: 0x0602ECA8 RID: 191656 RVA: 0x00B14140 File Offset: 0x00B12340
		protected override void InitPlatformSdkReportData()
		{
			string productId = Singleton<PlatformSdkConfig>.Instance.GetProductId();
			string platformPkg = Singleton<PlatformSdkConfig>.Instance.GetPlatformPkg();
			string channelId = Singleton<PlatformSdkConfig>.Instance.GetChannelId();
			string channel_name = "PlayStation";
			string channel_op = "";
			string runningOnlyCode = this.GetRunningOnlyCode();
			string appVersion = UKuroLauncherLibrary.GetAppVersion();
			string sdkVersion = Singleton<PlatformSdkConfig>.Instance.GetSdkVersion();
			string playStationToken = this.GetPlayStationToken();
			string language = this.GetLanguage();
			string initTime = this.InitTime.ToString();
			string gameId = this.GetGameId();
			string thirdUnionId = this.ThirdUnionId;
			PlatformSdkReportBaseData.InitSdkBaseValue(productId, platformPkg, channelId, channel_name, channel_op, language, runningOnlyCode, appVersion, sdkVersion, playStationToken, initTime, gameId, thirdUnionId);
		}

		// Token: 0x0602ECA9 RID: 191657 RVA: 0x00B141DC File Offset: 0x00B123DC
		protected unsafe override void OnInitDataReport()
		{
			bool flag = UThinkingAnalytics.HasInstanceInitialized(this.PlatStationReportIndex);
			bool flag2 = UKuroAnalytics.HasInstanceInitialized(this.PlatStationReportIndex);
			if (flag && flag2)
			{
				this.ReportCacheReportData();
				return;
			}
			if (!flag)
			{
				string dataReportUrl = Singleton<PlatformSdkConfig>.Instance.GetDataReportUrl();
				string dataReportId = Singleton<PlatformSdkConfig>.Instance.GetDataReportId();
				string accountId = PlatformSdkReportBaseData.GetPuid().ToString();
				FCreateInstanceParam fcreateInstanceParam = new FCreateInstanceParam(this.PlatStationReportIndex, dataReportUrl, dataReportId, UThinkingAnalytics.GetMachineID(), accountId, "SdkData", "", 1000, TAMode.NORMAL, UnrealEngine.ESaveMode.None_Save, 0f, true, false, false, true, 1f, 1000, 10000f, true, 10f, true, false);
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "[PlatformSdkNew][PlayStation5Sdk] InitThinkingDataReport";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("url", dataReportUrl);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("appId", dataReportId);
				instance.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				UThinkingAnalytics.CreateSimpleInstance(fcreateInstanceParam);
			}
			if (!flag2)
			{
				string kuroDataReportUrl = Singleton<PlatformSdkConfig>.Instance.GetKuroDataReportUrl();
				string dataReportId2 = Singleton<PlatformSdkConfig>.Instance.GetDataReportId();
				string accountId2 = PlatformSdkReportBaseData.GetPuid().ToString();
				FKACreateInstanceParam fkacreateInstanceParam = new FKACreateInstanceParam(this.PlatStationReportIndex, kuroDataReportUrl, dataReportId2, UKuroAnalytics.GetMachineID(), accountId2, "SdkData", "", 1000, KAMode.NORMAL, EKASaveMode.None_Save, 0f, true, false, false, true, 1f, 1000, 10000f, true, 10f, true, false);
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "[PlatformSdkNew][PlayStation5Sdk] InitKuroDataReport";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("url", kuroDataReportUrl);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("appId", dataReportId2);
				instance2.Debug(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				UKuroAnalytics.CreateSimpleInstance(fkacreateInstanceParam);
			}
			this.ReportCacheReportData();
		}

		// Token: 0x0602ECAA RID: 191658 RVA: 0x00B143B4 File Offset: 0x00B125B4
		private void ReportCacheReportData()
		{
			if (this.CacheReportArray.Count > 0)
			{
				for (int i = 0; i < this.CacheReportArray.Count; i++)
				{
					PlatformSdkReportBaseData eventData = this.CacheReportArray[i];
					this.ReportToThirdPartyInternal(eventData);
				}
				this.CacheReportArray.Clear();
			}
		}

		// Token: 0x0602ECAB RID: 191659 RVA: 0x00B14404 File Offset: 0x00B12604
		private string GetPlayStationToken()
		{
			string idToken = this.GetIdToken(EPlayStaionScope.DeviceId);
			if (idToken == null)
			{
				return "";
			}
			IIdTokenData idTokenData = this.TryDecodeJtwToken(idToken);
			if (idTokenData == null)
			{
				return "";
			}
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew][PlayStation5Sdk] DeviceId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DeviceId", this.DeviceId);
			instance.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return idTokenData.duid;
		}

		// Token: 0x0602ECAC RID: 191660 RVA: 0x00B14464 File Offset: 0x00B12664
		[return: Nullable(2)]
		private IIdTokenData TryDecodeJtwToken(string token)
		{
			string[] array = token.Split('.', StringSplitOptions.None);
			string text = (array.Length > 1) ? array[1] : null;
			if (text == null)
			{
				return null;
			}
			string text2 = UKuroStaticLibrary.Base64Decode(text);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew][PlayStation5Sdk] TryDecodeJtwToken";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("decodedPayload", text2);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return LauncherJson.Parse<IIdTokenData>(text2, null);
		}

		// Token: 0x0602ECAD RID: 191661 RVA: 0x00B144BE File Offset: 0x00B126BE
		private void AddTickCallBack(Func<int> callback)
		{
			this.TickUpdateId++;
			this.OnTickCallBackMap[this.TickUpdateId] = callback;
			this.StartTicker();
		}

		// Token: 0x0602ECAE RID: 191662 RVA: 0x00B144E8 File Offset: 0x00B126E8
		private void StartTicker()
		{
			if (this.Ticker == null && this.TickInnerState)
			{
				this.Ticker = new UKuroTickManager(this.WorldContext, null, EObjectFlags.RF_NoFlags);
				this.TickDelegate = delegate(float delta)
				{
					this.OnTick(delta);
				};
				this.Ticker.AddTick(ETickingGroup.TG_PrePhysics, global::DelegateUtils.ToManualReleaseDelegate<FTickHandler>(this.TickDelegate), 0);
			}
		}

		// Token: 0x0602ECAF RID: 191663 RVA: 0x00B14544 File Offset: 0x00B12744
		private void OnTick(float delta)
		{
			if (this.OnTickCallBackMap.Count == 0)
			{
				return;
			}
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, Func<int>> keyValuePair in this.OnTickCallBackMap)
			{
				if (keyValuePair.Value() == -1)
				{
					list.Add(keyValuePair.Key);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				this.OnTickCallBackMap.Remove(list[i]);
			}
			if (this.OnTickCallBackMap.Count == 0)
			{
				this.RemoveTicker();
			}
		}

		// Token: 0x0602ECB0 RID: 191664 RVA: 0x00B145F8 File Offset: 0x00B127F8
		private void RemoveTicker()
		{
			if (this.Ticker != null && this.TickInnerState)
			{
				this.Ticker.ClearTick();
				this.Ticker = null;
			}
			if (this.TickDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(this.TickDelegate);
				this.TickDelegate = null;
			}
		}

		// Token: 0x0602ECB1 RID: 191665 RVA: 0x00B14638 File Offset: 0x00B12838
		protected override void InitWebComponent()
		{
			string userId = this.GetUserId();
			UKuroStaticPS5Library.InitWebApi(ref userId);
		}

		// Token: 0x0602ECB2 RID: 191666 RVA: 0x00B14654 File Offset: 0x00B12854
		protected override bool OnUnInit()
		{
			UniversalDataSystemManager universalDataSystemManager = this.UniversalDataSystemManager;
			if (universalDataSystemManager != null)
			{
				universalDataSystemManager.Stop();
			}
			return true;
		}

		// Token: 0x0602ECB3 RID: 191667 RVA: 0x00B14668 File Offset: 0x00B12868
		public override void ConnectToServer(TSDKConnectCallback callback)
		{
			PlayStation5Sdk.<>c__DisplayClass41_0 CS$<>8__locals1 = new PlayStation5Sdk.<>c__DisplayClass41_0();
			CS$<>8__locals1.callback = callback;
			string platformPkg = Singleton<PlatformSdkConfig>.Instance.GetPlatformPkg();
			Singleton<PlatformSdkServer>.Instance.Connect("&pkg=" + platformPkg, new TSDKConnectCallback(CS$<>8__locals1.<ConnectToServer>g__FinalCallBack|0));
		}

		// Token: 0x0602ECB4 RID: 191668 RVA: 0x00B146B0 File Offset: 0x00B128B0
		[NullableContext(2)]
		private unsafe AuthCodeData GetAuthCode(EPlayStaionScope scope)
		{
			string platformClientId = Singleton<PlatformSdkConfig>.Instance.GetPlatformClientId();
			string text = (scope == EPlayStaionScope.Login) ? "psn:s2s openid id_token:psn.basic_claims" : "psn:s2s openid id_token:psn.basic_claims id_token:duid";
			string text2 = "";
			int num = 0;
			int authCode = UKuroStaticPS5Library.GetAuthCode(ref platformClientId, ref text, ref text2, ref num);
			if (authCode != 0)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "[PlatformSdkNew][PlayStation5Sdk] GetAuthCode failed";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", authCode);
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "[PlatformSdkNew][PlayStation5Sdk] GetAuthCode";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("result", authCode);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("authCode", text2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("issuerId", num);
			instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			PlatformReportGetPsnAuth eventData = new PlatformReportGetPsnAuth();
			this.ReportToThirdParty(eventData);
			return new AuthCodeData(text2, num);
		}

		// Token: 0x0602ECB5 RID: 191669 RVA: 0x00B147A8 File Offset: 0x00B129A8
		[NullableContext(2)]
		public unsafe string GetIdToken(EPlayStaionScope scope)
		{
			string platformClientId = Singleton<PlatformSdkConfig>.Instance.GetPlatformClientId();
			string platformClientSecret = Singleton<PlatformSdkConfig>.Instance.GetPlatformClientSecret();
			string text = (scope == EPlayStaionScope.Login) ? "psn:s2s openid id_token:psn.basic_claims" : "psn:s2s openid id_token:psn.basic_claims id_token:duid";
			string text2 = "";
			int idToken = UKuroStaticPS5Library.GetIdToken(ref platformClientId, ref platformClientSecret, ref text, ref text2);
			if (idToken != 0)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "[PlatformSdkNew][PlayStation5Sdk] GetIdToken failed";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", idToken);
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "[PlatformSdkNew][PlayStation5Sdk] GetIdToken";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("result", idToken);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("idToken", text2);
			instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			PlatformReportPsnAccessId eventData = new PlatformReportPsnAccessId();
			this.ReportToThirdParty(eventData);
			return text2;
		}

		// Token: 0x0602ECB6 RID: 191670 RVA: 0x00B14885 File Offset: 0x00B12A85
		public override bool NeedPrivacyProtocol()
		{
			return true;
		}

		// Token: 0x0602ECB7 RID: 191671 RVA: 0x00B14888 File Offset: 0x00B12A88
		public override string GetDeviceId()
		{
			PlatformReportGetDid eventData = new PlatformReportGetDid();
			this.ReportToThirdParty(eventData);
			if (this.DeviceId == "")
			{
				string playStationToken = this.GetPlayStationToken();
				this.DeviceId = playStationToken;
				PlatformReportFirstGetDid platformReportFirstGetDid = new PlatformReportFirstGetDid();
				string projectId = Singleton<PlatformSdkConfig>.Instance.GetProjectId();
				string channelId = Singleton<PlatformSdkConfig>.Instance.GetChannelId();
				string deviceId = this.DeviceId;
				PlatformReportFirstGetDid platformReportFirstGetDid2 = platformReportFirstGetDid;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
				defaultInterpolatedStringHandler.AppendFormatted(projectId);
				defaultInterpolatedStringHandler.AppendLiteral("_");
				defaultInterpolatedStringHandler.AppendFormatted(channelId);
				defaultInterpolatedStringHandler.AppendLiteral("_");
				defaultInterpolatedStringHandler.AppendFormatted(deviceId);
				platformReportFirstGetDid2.first_check_id = defaultInterpolatedStringHandler.ToStringAndClear();
				this.ReportToThirdParty(platformReportFirstGetDid);
			}
			if (this.DeviceId == "")
			{
				Singleton<LauncherLog>.Instance.Debug("[PlatformSdkNew][PlayStation5Sdk] GetDeviceId failed, empty DeviceId", default(ReadOnlySpan<ValueTuple<string, object>>));
				return "";
			}
			PlatformReportGetDidSuccess eventData2 = new PlatformReportGetDidSuccess();
			this.ReportToThirdParty(eventData2);
			return this.DeviceId;
		}

		// Token: 0x0602ECB8 RID: 191672 RVA: 0x00B14980 File Offset: 0x00B12B80
		public override void Login(TSDKLoginCallback callback)
		{
			AuthCodeData authCode = this.GetAuthCode(EPlayStaionScope.Login);
			if (authCode == null)
			{
				Singleton<LauncherLog>.Instance.Error("[PlatformSdkNew][PlayStation5Sdk] Login failed, empty authCode", default(ReadOnlySpan<ValueTuple<string, object>>));
				callback(PlatformSdkServerMsg.PsnAuthFail.ToEnumString(), false, false, null);
				return;
			}
			string platformPkg = Singleton<PlatformSdkConfig>.Instance.GetPlatformPkg();
			string clientId = Singleton<PlatformSdkConfig>.Instance.GetClientId();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(75, 4);
			defaultInterpolatedStringHandler.AppendLiteral("&psnCode=");
			defaultInterpolatedStringHandler.AppendFormatted(authCode.AuthCode);
			defaultInterpolatedStringHandler.AppendLiteral("&psnEnvIssuerId=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(authCode.IssuerId);
			defaultInterpolatedStringHandler.AppendLiteral("&pkg=");
			defaultInterpolatedStringHandler.AppendFormatted(platformPkg);
			defaultInterpolatedStringHandler.AppendLiteral("&client_id=");
			defaultInterpolatedStringHandler.AppendFormatted(clientId);
			defaultInterpolatedStringHandler.AppendLiteral("&redirect_uri=1&response_type=code");
			string param = defaultInterpolatedStringHandler.ToStringAndClear();
			Singleton<PlatformSdkServer>.Instance.Login(param, callback);
		}

		// Token: 0x0602ECB9 RID: 191673 RVA: 0x00B14A5C File Offset: 0x00B12C5C
		public override void BindAccountThenLogin(TSDKLoginCallback callback, string mailAddress = "", string mailCode = "")
		{
			AuthCodeData authCode = this.GetAuthCode(EPlayStaionScope.Login);
			if (authCode == null)
			{
				Singleton<LauncherLog>.Instance.Error("[PlatformSdkNew][PlayStation5Sdk] BindAccountThenLogin failed, empty authCode", default(ReadOnlySpan<ValueTuple<string, object>>));
				callback(PlatformSdkServerMsg.PsnAuthFail.ToEnumString(), false, false, null);
				return;
			}
			string platformPkg = Singleton<PlatformSdkConfig>.Instance.GetPlatformPkg();
			string clientId = Singleton<PlatformSdkConfig>.Instance.GetClientId();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(75, 4);
			defaultInterpolatedStringHandler.AppendLiteral("&psnCode=");
			defaultInterpolatedStringHandler.AppendFormatted(authCode.AuthCode);
			defaultInterpolatedStringHandler.AppendLiteral("&psnEnvIssuerId=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(authCode.IssuerId);
			defaultInterpolatedStringHandler.AppendLiteral("&pkg=");
			defaultInterpolatedStringHandler.AppendFormatted(platformPkg);
			defaultInterpolatedStringHandler.AppendLiteral("&client_id=");
			defaultInterpolatedStringHandler.AppendFormatted(clientId);
			defaultInterpolatedStringHandler.AppendLiteral("&redirect_uri=1&response_type=code");
			string text = defaultInterpolatedStringHandler.ToStringAndClear();
			if (mailAddress != "" && mailCode != "")
			{
				text = string.Concat(new string[]
				{
					text,
					"&email=",
					mailAddress,
					"&emailCode=",
					mailCode
				});
			}
			Singleton<PlatformSdkServer>.Instance.BindAccountThenLogin(text, callback);
		}

		// Token: 0x0602ECBA RID: 191674 RVA: 0x00B14B7C File Offset: 0x00B12D7C
		public override void SetServerCommonParam()
		{
			string productId = Singleton<PlatformSdkConfig>.Instance.GetProductId();
			string projectId = Singleton<PlatformSdkConfig>.Instance.GetProjectId();
			string platform = Singleton<PlatformSdkConfig>.Instance.GetPlatform();
			string sdkVersion = Singleton<PlatformSdkConfig>.Instance.GetSdkVersion();
			string channelId = Singleton<PlatformSdkConfig>.Instance.GetChannelId();
			PlatformSdkServer instance = Singleton<PlatformSdkServer>.Instance;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(65, 6);
			defaultInterpolatedStringHandler.AppendLiteral("productId=");
			defaultInterpolatedStringHandler.AppendFormatted(productId);
			defaultInterpolatedStringHandler.AppendLiteral("&projectId=");
			defaultInterpolatedStringHandler.AppendFormatted(projectId);
			defaultInterpolatedStringHandler.AppendLiteral("&deviceNum=");
			defaultInterpolatedStringHandler.AppendFormatted(this.GetDeviceId());
			defaultInterpolatedStringHandler.AppendLiteral("&platform=");
			defaultInterpolatedStringHandler.AppendFormatted(platform);
			defaultInterpolatedStringHandler.AppendLiteral("&sdkVersion=");
			defaultInterpolatedStringHandler.AppendFormatted(sdkVersion);
			defaultInterpolatedStringHandler.AppendLiteral("&channelId=");
			defaultInterpolatedStringHandler.AppendFormatted(channelId);
			instance.InitCommonParam(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0602ECBB RID: 191675 RVA: 0x00B14C5A File Offset: 0x00B12E5A
		public override string GetUserId()
		{
			return UKuroStaticPS5Library.GetUserId();
		}

		// Token: 0x0602ECBC RID: 191676 RVA: 0x00B14C64 File Offset: 0x00B12E64
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<string> GetSelfAccountId()
		{
			PlayStation5Sdk.<GetSelfAccountId>d__50 <GetSelfAccountId>d__;
			<GetSelfAccountId>d__.<>t__builder = AsyncUniTaskMethodBuilder<string>.Create();
			<GetSelfAccountId>d__.<>4__this = this;
			<GetSelfAccountId>d__.<>1__state = -1;
			<GetSelfAccountId>d__.<>t__builder.Start<PlayStation5Sdk.<GetSelfAccountId>d__50>(ref <GetSelfAccountId>d__);
			return <GetSelfAccountId>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECBD RID: 191677 RVA: 0x00B14CA8 File Offset: 0x00B12EA8
		public override bool GetPrivacyAgreeState()
		{
			if (this.CacheAgreeState)
			{
				return true;
			}
			Dictionary<string, Dictionary<string, bool>> global = Singleton<LauncherStorageLib>.Instance.GetGlobal<Dictionary<string, Dictionary<string, bool>>>(ELauncherStorageGlobalKey.UserProtocolAgreeState, null);
			if (global == null)
			{
				return false;
			}
			Singleton<LauncherStorageLib>.Instance.SetGlobal<Dictionary<string, Dictionary<string, bool>>>(ELauncherStorageGlobalKey.UserProtocolAgreeState, global);
			string language = this.GetLanguage();
			Dictionary<string, bool> dictionary;
			if (!global.TryGetValue(this.GetUserId(), out dictionary))
			{
				return false;
			}
			bool flag;
			if (!dictionary.TryGetValue(language, out flag))
			{
				return false;
			}
			if (flag)
			{
				UKuroStaticPS5Library.AddCacheMapElement("AgreeState", "1");
			}
			return flag;
		}

		// Token: 0x0602ECBE RID: 191678 RVA: 0x00B14D18 File Offset: 0x00B12F18
		public override void SavePrivacyAgreeState(bool state)
		{
			PlatformReportAgreementClick eventData = new PlatformReportAgreementClick();
			this.ReportToThirdParty(eventData);
			Dictionary<string, Dictionary<string, bool>> dictionary = Singleton<LauncherStorageLib>.Instance.GetGlobal<Dictionary<string, Dictionary<string, bool>>>(ELauncherStorageGlobalKey.UserProtocolAgreeState, null);
			if (dictionary == null)
			{
				dictionary = new Dictionary<string, Dictionary<string, bool>>();
			}
			string language = this.GetLanguage();
			Dictionary<string, bool> dictionary2;
			if (!dictionary.TryGetValue(this.GetUserId(), out dictionary2))
			{
				dictionary[this.GetUserId()] = new Dictionary<string, bool>();
			}
			dictionary[this.GetUserId()][language] = state;
			Singleton<LauncherStorageLib>.Instance.SetGlobal<Dictionary<string, Dictionary<string, bool>>>(ELauncherStorageGlobalKey.UserProtocolAgreeState, dictionary);
			UKuroStaticPS5Library.AddCacheMapElement("AgreeState", "1");
		}

		// Token: 0x0602ECBF RID: 191679 RVA: 0x00B14DA0 File Offset: 0x00B12FA0
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public override UniTask<Dictionary<string, string>> GetSdkOnlineId(List<string> userIdList)
		{
			PlayStation5Sdk.<GetSdkOnlineId>d__53 <GetSdkOnlineId>d__;
			<GetSdkOnlineId>d__.<>t__builder = AsyncUniTaskMethodBuilder<Dictionary<string, string>>.Create();
			<GetSdkOnlineId>d__.<>4__this = this;
			<GetSdkOnlineId>d__.userIdList = userIdList;
			<GetSdkOnlineId>d__.<>1__state = -1;
			<GetSdkOnlineId>d__.<>t__builder.Start<PlayStation5Sdk.<GetSdkOnlineId>d__53>(ref <GetSdkOnlineId>d__);
			return <GetSdkOnlineId>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECC0 RID: 191680 RVA: 0x00B14DEC File Offset: 0x00B12FEC
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public override UniTask<Dictionary<string, bool>> GetSdkBlockingUser()
		{
			PlayStation5Sdk.<GetSdkBlockingUser>d__54 <GetSdkBlockingUser>d__;
			<GetSdkBlockingUser>d__.<>t__builder = AsyncUniTaskMethodBuilder<Dictionary<string, bool>>.Create();
			<GetSdkBlockingUser>d__.<>4__this = this;
			<GetSdkBlockingUser>d__.<>1__state = -1;
			<GetSdkBlockingUser>d__.<>t__builder.Start<PlayStation5Sdk.<GetSdkBlockingUser>d__54>(ref <GetSdkBlockingUser>d__);
			return <GetSdkBlockingUser>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECC1 RID: 191681 RVA: 0x00B14E30 File Offset: 0x00B13030
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public override UniTask<Dictionary<string, string>> GetSdkAccountId(List<string> userIdList)
		{
			PlayStation5Sdk.<GetSdkAccountId>d__55 <GetSdkAccountId>d__;
			<GetSdkAccountId>d__.<>t__builder = AsyncUniTaskMethodBuilder<Dictionary<string, string>>.Create();
			<GetSdkAccountId>d__.<>4__this = this;
			<GetSdkAccountId>d__.userIdList = userIdList;
			<GetSdkAccountId>d__.<>1__state = -1;
			<GetSdkAccountId>d__.<>t__builder.Start<PlayStation5Sdk.<GetSdkAccountId>d__55>(ref <GetSdkAccountId>d__);
			return <GetSdkAccountId>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECC2 RID: 191682 RVA: 0x00B14E7C File Offset: 0x00B1307C
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public override UniTask<string> GetSdkUserIdByAccountId(string accountId)
		{
			PlayStation5Sdk.<GetSdkUserIdByAccountId>d__56 <GetSdkUserIdByAccountId>d__;
			<GetSdkUserIdByAccountId>d__.<>t__builder = AsyncUniTaskMethodBuilder<string>.Create();
			<GetSdkUserIdByAccountId>d__.<>1__state = -1;
			<GetSdkUserIdByAccountId>d__.<>t__builder.Start<PlayStation5Sdk.<GetSdkUserIdByAccountId>d__56>(ref <GetSdkUserIdByAccountId>d__);
			return <GetSdkUserIdByAccountId>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECC3 RID: 191683 RVA: 0x00B14EB7 File Offset: 0x00B130B7
		public override void ShowPlayStationStoreIcon(int positionType)
		{
			UKuroStaticPS5Library.ShowPsStoreIcon(positionType);
		}

		// Token: 0x0602ECC4 RID: 191684 RVA: 0x00B14EC0 File Offset: 0x00B130C0
		public override void HidePlayStationStoreIcon()
		{
			UKuroStaticPS5Library.HidePsStoreIcon();
		}

		// Token: 0x0602ECC5 RID: 191685 RVA: 0x00B14EC8 File Offset: 0x00B130C8
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<IPlayStationOnlineData> GetPlayStationOnlineId(string userId)
		{
			PlayStation5Sdk.<GetPlayStationOnlineId>d__59 <GetPlayStationOnlineId>d__;
			<GetPlayStationOnlineId>d__.<>t__builder = AsyncUniTaskMethodBuilder<IPlayStationOnlineData>.Create();
			<GetPlayStationOnlineId>d__.userId = userId;
			<GetPlayStationOnlineId>d__.<>1__state = -1;
			<GetPlayStationOnlineId>d__.<>t__builder.Start<PlayStation5Sdk.<GetPlayStationOnlineId>d__59>(ref <GetPlayStationOnlineId>d__);
			return <GetPlayStationOnlineId>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECC6 RID: 191686 RVA: 0x00B14F0C File Offset: 0x00B1310C
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<IPlayStationAccountData> GetPlayStationAccountId(string userId)
		{
			PlayStation5Sdk.<GetPlayStationAccountId>d__60 <GetPlayStationAccountId>d__;
			<GetPlayStationAccountId>d__.<>t__builder = AsyncUniTaskMethodBuilder<IPlayStationAccountData>.Create();
			<GetPlayStationAccountId>d__.userId = userId;
			<GetPlayStationAccountId>d__.<>1__state = -1;
			<GetPlayStationAccountId>d__.<>t__builder.Start<PlayStation5Sdk.<GetPlayStationAccountId>d__60>(ref <GetPlayStationAccountId>d__);
			return <GetPlayStationAccountId>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECC7 RID: 191687 RVA: 0x00B14F50 File Offset: 0x00B13150
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public override UniTask<List<ISdkTrophyInfo>> GetSdkTrophyInfo(int offset = 0, int length = 0)
		{
			PlayStation5Sdk.<GetSdkTrophyInfo>d__61 <GetSdkTrophyInfo>d__;
			<GetSdkTrophyInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<ISdkTrophyInfo>>.Create();
			<GetSdkTrophyInfo>d__.<>4__this = this;
			<GetSdkTrophyInfo>d__.offset = offset;
			<GetSdkTrophyInfo>d__.length = length;
			<GetSdkTrophyInfo>d__.<>1__state = -1;
			<GetSdkTrophyInfo>d__.<>t__builder.Start<PlayStation5Sdk.<GetSdkTrophyInfo>d__61>(ref <GetSdkTrophyInfo>d__);
			return <GetSdkTrophyInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECC8 RID: 191688 RVA: 0x00B14FA4 File Offset: 0x00B131A4
		[NullableContext(0)]
		public override UniTask<bool> UnlockSdkTrophy(int trophyId)
		{
			PlayStation5Sdk.<UnlockSdkTrophy>d__62 <UnlockSdkTrophy>d__;
			<UnlockSdkTrophy>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UnlockSdkTrophy>d__.<>4__this = this;
			<UnlockSdkTrophy>d__.trophyId = trophyId;
			<UnlockSdkTrophy>d__.<>1__state = -1;
			<UnlockSdkTrophy>d__.<>t__builder.Start<PlayStation5Sdk.<UnlockSdkTrophy>d__62>(ref <UnlockSdkTrophy>d__);
			return <UnlockSdkTrophy>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECC9 RID: 191689 RVA: 0x00B14FF0 File Offset: 0x00B131F0
		[NullableContext(0)]
		public override UniTask<bool> UpdateSdkTrophyProgress(int trophyId, int progress)
		{
			PlayStation5Sdk.<UpdateSdkTrophyProgress>d__63 <UpdateSdkTrophyProgress>d__;
			<UpdateSdkTrophyProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UpdateSdkTrophyProgress>d__.<>4__this = this;
			<UpdateSdkTrophyProgress>d__.trophyId = trophyId;
			<UpdateSdkTrophyProgress>d__.progress = progress;
			<UpdateSdkTrophyProgress>d__.<>1__state = -1;
			<UpdateSdkTrophyProgress>d__.<>t__builder.Start<PlayStation5Sdk.<UpdateSdkTrophyProgress>d__63>(ref <UpdateSdkTrophyProgress>d__);
			return <UpdateSdkTrophyProgress>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECCA RID: 191690 RVA: 0x00B15043 File Offset: 0x00B13243
		public override bool NeedShowThirdPartyId()
		{
			return true;
		}

		// Token: 0x0602ECCB RID: 191691 RVA: 0x00B15046 File Offset: 0x00B13246
		public override bool SupportSwitchFriendSearchByThirdPartyId()
		{
			return true;
		}

		// Token: 0x0602ECCC RID: 191692 RVA: 0x00B15049 File Offset: 0x00B13249
		public override bool SupportSwitchFriendShowType()
		{
			return true;
		}

		// Token: 0x0602ECCD RID: 191693 RVA: 0x00B1504C File Offset: 0x00B1324C
		public override bool GetSdkFriendOnlyState()
		{
			return Singleton<LauncherStorageLib>.Instance.GetGlobal<bool>(ELauncherStorageGlobalKey.PlayStationFriendOnly, false);
		}

		// Token: 0x0602ECCE RID: 191694 RVA: 0x00B1505A File Offset: 0x00B1325A
		public override void SaveSdkFriendOnlyState(bool state)
		{
			Singleton<LauncherStorageLib>.Instance.SetGlobal<bool>(ELauncherStorageGlobalKey.PlayStationFriendOnly, state);
		}

		// Token: 0x0602ECCF RID: 191695 RVA: 0x00B15069 File Offset: 0x00B13269
		public override string GetProductId()
		{
			return Singleton<PlatformSdkConfig>.Instance.GetProductId();
		}

		// Token: 0x0602ECD0 RID: 191696 RVA: 0x00B15078 File Offset: 0x00B13278
		public override void OpenWebView(string url, [Nullable(2)] Action endCallBack = null)
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "OpenWebView";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("url", url);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			UKuroStaticPS5Library.OpenWebBrowser(ref url);
			this.AddTickCallBack(delegate
			{
				if (!this.PollWebViewClose())
				{
					return 0;
				}
				base.<OpenWebView>g__CallBack|0();
				return -1;
			});
		}

		// Token: 0x0602ECD1 RID: 191697 RVA: 0x00B150D5 File Offset: 0x00B132D5
		public override void CloseWebView()
		{
			UKuroStaticPS5Library.CloseWebBrowser();
		}

		// Token: 0x0602ECD2 RID: 191698 RVA: 0x00B150DD File Offset: 0x00B132DD
		public override bool NeedCheckPlayOnly()
		{
			return true;
		}

		// Token: 0x0602ECD3 RID: 191699 RVA: 0x00B150E0 File Offset: 0x00B132E0
		public override bool NeedShowShopIcon()
		{
			return true;
		}

		// Token: 0x0602ECD4 RID: 191700 RVA: 0x00B150E3 File Offset: 0x00B132E3
		public override void StartActivity(string activityId)
		{
			UniversalDataSystemManager universalDataSystemManager = this.UniversalDataSystemManager;
			if (universalDataSystemManager == null)
			{
				return;
			}
			universalDataSystemManager.StartActivity(activityId);
		}

		// Token: 0x0602ECD5 RID: 191701 RVA: 0x00B150F6 File Offset: 0x00B132F6
		public override void EndActivity(string activityId)
		{
			UniversalDataSystemManager universalDataSystemManager = this.UniversalDataSystemManager;
			if (universalDataSystemManager == null)
			{
				return;
			}
			universalDataSystemManager.EndActivity(activityId, EPsActivityEndActivityOutcome.Completed);
		}

		// Token: 0x0602ECD6 RID: 191702 RVA: 0x00B1510A File Offset: 0x00B1330A
		public override void ChangeActivityAvailability([Nullable(new byte[]
		{
			2,
			1
		})] TArray<string> availableActivities, [Nullable(new byte[]
		{
			2,
			1
		})] TArray<string> unavailableActivities)
		{
			UniversalDataSystemManager universalDataSystemManager = this.UniversalDataSystemManager;
			if (universalDataSystemManager == null)
			{
				return;
			}
			universalDataSystemManager.ChangeActivityAvailability(availableActivities, unavailableActivities);
		}

		// Token: 0x0602ECD7 RID: 191703 RVA: 0x00B1511E File Offset: 0x00B1331E
		public override bool PollWebViewClose()
		{
			return UKuroStaticPS5Library.PollWebBrowser();
		}

		// Token: 0x0602ECD8 RID: 191704 RVA: 0x00B15128 File Offset: 0x00B13328
		[return: Nullable(new byte[]
		{
			0,
			2,
			1
		})]
		private UniTask<TArray<FProductData>> GetPsnStoreProducts()
		{
			PlayStation5Sdk.<GetPsnStoreProducts>d__82 <GetPsnStoreProducts>d__;
			<GetPsnStoreProducts>d__.<>t__builder = AsyncUniTaskMethodBuilder<TArray<FProductData>>.Create();
			<GetPsnStoreProducts>d__.<>4__this = this;
			<GetPsnStoreProducts>d__.<>1__state = -1;
			<GetPsnStoreProducts>d__.<>t__builder.Start<PlayStation5Sdk.<GetPsnStoreProducts>d__82>(ref <GetPsnStoreProducts>d__);
			return <GetPsnStoreProducts>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECD9 RID: 191705 RVA: 0x00B1516C File Offset: 0x00B1336C
		private void GetPsnStoreProductsWithParams(int offset, int limit, TArray<FProductData> result, Action<TArray<FProductData>> callBack)
		{
			TArray<FProductData> storeProductsWithParams = UKuroStaticPS5Library.GetStoreProductsWithParams(this.LabelId, offset, limit);
			for (int i = 0; i < storeProductsWithParams.Num(); i++)
			{
				result.Add(storeProductsWithParams.Get(i));
			}
			if (storeProductsWithParams.Num() == 0 || storeProductsWithParams.Num() < limit)
			{
				callBack(result);
				return;
			}
			this.GetPsnStoreProductsWithParams(offset + limit, limit, result, callBack);
		}

		// Token: 0x0602ECDA RID: 191706 RVA: 0x00B151CC File Offset: 0x00B133CC
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public override UniTask<IQueryProductResult> QueryProductInfo(List<string> productIds)
		{
			PlayStation5Sdk.<QueryProductInfo>d__84 <QueryProductInfo>d__;
			<QueryProductInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<IQueryProductResult>.Create();
			<QueryProductInfo>d__.<>4__this = this;
			<QueryProductInfo>d__.productIds = productIds;
			<QueryProductInfo>d__.<>1__state = -1;
			<QueryProductInfo>d__.<>t__builder.Start<PlayStation5Sdk.<QueryProductInfo>d__84>(ref <QueryProductInfo>d__);
			return <QueryProductInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECDB RID: 191707 RVA: 0x00B15218 File Offset: 0x00B13418
		public override bool OpenCheckoutDialog(string productLabel, string productId, string channelGoodsId)
		{
			PlatformReportOpenPsnCheckOut platformReportOpenPsnCheckOut = new PlatformReportOpenPsnCheckOut();
			platformReportOpenPsnCheckOut.product_id = channelGoodsId;
			platformReportOpenPsnCheckOut.goodsId = productId;
			platformReportOpenPsnCheckOut.psnenvlssuer = this.AuthCodeData.IssuerId.ToString();
			this.CurrentPayChannelGoodsId = channelGoodsId;
			this.CurrentPayProductId = productId;
			this.ReportToThirdParty(platformReportOpenPsnCheckOut);
			int num = UKuroStaticPS5Library.OpenCheckoutDialog(ref productLabel);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew][PlayStation5Sdk] OpenCheckoutDialog";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ret", num);
			instance.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return num == 0;
		}

		// Token: 0x0602ECDC RID: 191708 RVA: 0x00B15298 File Offset: 0x00B13498
		public override ESdkDialogResult PollCheckoutDialogResult()
		{
			int num = UKuroStaticPS5Library.PollCheckoutDialogResult();
			if (num == -1)
			{
				return ESdkDialogResult.Waiting;
			}
			if (num != 2)
			{
				this.ReportPsnCheckoutClose();
				return ESdkDialogResult.No;
			}
			this.ReportPsnCheckoutClose();
			return ESdkDialogResult.Yes;
		}

		// Token: 0x0602ECDD RID: 191709 RVA: 0x00B152C8 File Offset: 0x00B134C8
		private void ReportPsnCheckoutClose()
		{
			this.ReportToThirdParty(new PlatformReportClosePsnCheckOut
			{
				product_id = this.CurrentPayChannelGoodsId,
				goodsId = this.CurrentPayProductId,
				psnenvlssuer = this.AuthCodeData.IssuerId.ToString()
			});
		}

		// Token: 0x0602ECDE RID: 191710 RVA: 0x00B15310 File Offset: 0x00B13510
		public override void RequestCheckoutProduct(ISdkRequestCheckoutProductParam param, TSdkCheckoutProductCallback callback, ECheckoutReason reason)
		{
			string productId = Singleton<PlatformSdkConfig>.Instance.GetProductId();
			string version = Singleton<PlatformSdkConfig>.Instance.GetVersion();
			string sdkVersion = Singleton<PlatformSdkConfig>.Instance.GetSdkVersion();
			TMap<string, string> payHeader = Singleton<PlatformSdkServer>.Instance.GeneratePayHeader(productId, version, sdkVersion);
			string channelId = Singleton<PlatformSdkConfig>.Instance.GetChannelId();
			string platformPkg = Singleton<PlatformSdkConfig>.Instance.GetPlatformPkg();
			int issuerId = this.AuthCodeData.IssuerId;
			Singleton<PlatformSdkServer>.Instance.RequestCheckoutProduct(reason, issuerId, callback, payHeader, new object[]
			{
				"productId",
				productId,
				"channelId",
				channelId,
				"dn",
				this.GetDeviceId(),
				"pkg",
				platformPkg,
				"vn",
				version,
				"svn",
				sdkVersion,
				"plat",
				4,
				"access_token",
				param.AccessToken,
				"psnEnvIssuerId",
				this.AuthCodeData.IssuerId,
				"serverId",
				param.ServerId,
				"serverName",
				param.ServerName,
				"roleId",
				param.RoleId,
				"roleName",
				param.RoleName
			});
		}

		// Token: 0x0602ECDF RID: 191711 RVA: 0x00B15468 File Offset: 0x00B13668
		public override bool NeedConfirmSdkProductInfo()
		{
			return true;
		}

		// Token: 0x0602ECE0 RID: 191712 RVA: 0x00B1546B File Offset: 0x00B1366B
		public override bool NeedShowSdkProductInfoBeforePay()
		{
			return true;
		}

		// Token: 0x0602ECE1 RID: 191713 RVA: 0x00B15470 File Offset: 0x00B13670
		public override void GetMessageBoxCurrentState(Action<ESdkMessageBoxState> callBack)
		{
			PlayStation5Sdk.<>c__DisplayClass91_0 CS$<>8__locals1 = new PlayStation5Sdk.<>c__DisplayClass91_0();
			CS$<>8__locals1.callBack = callBack;
			FPlayStationGetDialogStatusCallBack fplayStationGetDialogStatusCallBack = global::DelegateUtils.ToManualReleaseDelegate<FPlayStationGetDialogStatusCallBack>(new Action<int>(CS$<>8__locals1.<GetMessageBoxCurrentState>g__OnGetMessage|0));
			UKuroStaticPS5Library.GetMessageDialogStateAsync(fplayStationGetDialogStatusCallBack);
		}

		// Token: 0x0602ECE2 RID: 191714 RVA: 0x00B154A4 File Offset: 0x00B136A4
		[NullableContext(0)]
		public override UniTask<bool> OpenMessageBox([Nullable(1)] string accountId, ESdkMessageBoxMode dialogMode, ESdkMessageBoxType msgType)
		{
			PlayStation5Sdk.<OpenMessageBox>d__92 <OpenMessageBox>d__;
			<OpenMessageBox>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenMessageBox>d__.<>4__this = this;
			<OpenMessageBox>d__.accountId = accountId;
			<OpenMessageBox>d__.dialogMode = dialogMode;
			<OpenMessageBox>d__.msgType = msgType;
			<OpenMessageBox>d__.<>1__state = -1;
			<OpenMessageBox>d__.<>t__builder.Start<PlayStation5Sdk.<OpenMessageBox>d__92>(ref <OpenMessageBox>d__);
			return <OpenMessageBox>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECE3 RID: 191715 RVA: 0x00B15500 File Offset: 0x00B13700
		public override void GetCommunicationRestricted([Nullable(2)] string accountId, Action<ESdkCommunicationRestricted> callBack)
		{
			PlayStation5Sdk.<>c__DisplayClass93_0 CS$<>8__locals1 = new PlayStation5Sdk.<>c__DisplayClass93_0();
			CS$<>8__locals1.callBack = callBack;
			if (accountId == null)
			{
				CS$<>8__locals1.callBack(ESdkCommunicationRestricted.No);
				return;
			}
			FPlayStationGetCommunicationStatusCallBack fplayStationGetCommunicationStatusCallBack = global::DelegateUtils.ToManualReleaseDelegate<FPlayStationGetCommunicationStatusCallBack>(new Action<int, int>(CS$<>8__locals1.<GetCommunicationRestricted>g__OnCommunicationResponse|0));
			UKuroStaticPS5Library.GetCommunicationRestrictionStatusAsync(ref accountId, fplayStationGetCommunicationStatusCallBack);
		}

		// Token: 0x0602ECE4 RID: 191716 RVA: 0x00B15548 File Offset: 0x00B13748
		[NullableContext(0)]
		public override UniTask<ESdkCommunicationRestricted> GetCommunicationRestrictedAsync([Nullable(2)] string accountId)
		{
			PlayStation5Sdk.<GetCommunicationRestrictedAsync>d__94 <GetCommunicationRestrictedAsync>d__;
			<GetCommunicationRestrictedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<ESdkCommunicationRestricted>.Create();
			<GetCommunicationRestrictedAsync>d__.<>4__this = this;
			<GetCommunicationRestrictedAsync>d__.accountId = accountId;
			<GetCommunicationRestrictedAsync>d__.<>1__state = -1;
			<GetCommunicationRestrictedAsync>d__.<>t__builder.Start<PlayStation5Sdk.<GetCommunicationRestrictedAsync>d__94>(ref <GetCommunicationRestrictedAsync>d__);
			return <GetCommunicationRestrictedAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECE5 RID: 191717 RVA: 0x00B15593 File Offset: 0x00B13793
		public override bool GetIfShowDefaultPrice()
		{
			return false;
		}

		// Token: 0x0602ECE6 RID: 191718 RVA: 0x00B15598 File Offset: 0x00B13798
		public override int CheckUserPremium()
		{
			string userId = this.GetUserId();
			return UKuroStaticPS5Library.CheckUserPremium(ref userId);
		}

		// Token: 0x0602ECE7 RID: 191719 RVA: 0x00B155B4 File Offset: 0x00B137B4
		public override void NotifyPlayStationPremium(bool isPlayStationOnly)
		{
			string userId = this.GetUserId();
			UKuroStaticPS5Library.NotifyPremiumFeature(ref userId, isPlayStationOnly);
		}

		// Token: 0x0602ECE8 RID: 191720 RVA: 0x00B155D0 File Offset: 0x00B137D0
		public override void TerminateMessageBox()
		{
			UKuroStaticPS5Library.TerminateMessageDialog();
		}

		// Token: 0x0602ECE9 RID: 191721 RVA: 0x00B155D8 File Offset: 0x00B137D8
		public override string CreatePlayerSession(int joinAbleUserType, int playerId)
		{
			string text = playerId.ToString();
			return UKuroStaticPS5Library.CreatePlayerSession(joinAbleUserType, ref text);
		}

		// Token: 0x0602ECEA RID: 191722 RVA: 0x00B155F5 File Offset: 0x00B137F5
		public override void SetPlayerSessionJoinAbleUserType(int joinAbleUserType)
		{
			UKuroStaticPS5Library.SetPlayerSessionJoinableUserType(joinAbleUserType);
		}

		// Token: 0x0602ECEB RID: 191723 RVA: 0x00B155FD File Offset: 0x00B137FD
		public override void LeavePlayerSession()
		{
			UKuroStaticPS5Library.LeavePlayerSession();
		}

		// Token: 0x0602ECEC RID: 191724 RVA: 0x00B15604 File Offset: 0x00B13804
		public override void JoinPlayerSession(string playerSession)
		{
			UKuroStaticPS5Library.JoinPlayerSession(ref playerSession);
		}

		// Token: 0x0602ECED RID: 191725 RVA: 0x00B1560D File Offset: 0x00B1380D
		public override string CheckJoinSession()
		{
			return UKuroStaticPS5Library.CheckJoinSession();
		}

		// Token: 0x0602ECEE RID: 191726 RVA: 0x00B15614 File Offset: 0x00B13814
		public override string GetPlayerIdByPlayerSessionId(string playerSession)
		{
			return UKuroStaticPS5Library.GetPlayerIdByPlayerSessionId(ref playerSession);
		}

		// Token: 0x0602ECEF RID: 191727 RVA: 0x00B15620 File Offset: 0x00B13820
		public override bool IsPlatformNetworkReachable()
		{
			string userId = this.GetUserId();
			int num = 0;
			if (UKuroStaticPS5Library.SceNpGetNpReachabilityState(ref userId, ref num) != 0)
			{
				Singleton<LauncherLog>.Instance.Error("[PlatformSdkNew][PlayStation5Sdk] SceNpGetNpReachabilityState failed", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			return num == 2;
		}

		// Token: 0x0602ECF0 RID: 191728 RVA: 0x00B15660 File Offset: 0x00B13860
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public override UniTask<Dictionary<string, ESdkRelation>> GetTargetRelation(List<string> accountIdList)
		{
			PlayStation5Sdk.<GetTargetRelation>d__106 <GetTargetRelation>d__;
			<GetTargetRelation>d__.<>t__builder = AsyncUniTaskMethodBuilder<Dictionary<string, ESdkRelation>>.Create();
			<GetTargetRelation>d__.<>4__this = this;
			<GetTargetRelation>d__.accountIdList = accountIdList;
			<GetTargetRelation>d__.<>1__state = -1;
			<GetTargetRelation>d__.<>t__builder.Start<PlayStation5Sdk.<GetTargetRelation>d__106>(ref <GetTargetRelation>d__);
			return <GetTargetRelation>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECF1 RID: 191729 RVA: 0x00B156AB File Offset: 0x00B138AB
		public override bool GetIfNeedQueryProductInfoForce()
		{
			return false;
		}

		// Token: 0x0602ECF2 RID: 191730 RVA: 0x00B156B0 File Offset: 0x00B138B0
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public override UniTask<RequestEmailCodeResponse> RequestEmailCode(string emailAddress)
		{
			PlayStation5Sdk.<RequestEmailCode>d__108 <RequestEmailCode>d__;
			<RequestEmailCode>d__.<>t__builder = AsyncUniTaskMethodBuilder<RequestEmailCodeResponse>.Create();
			<RequestEmailCode>d__.emailAddress = emailAddress;
			<RequestEmailCode>d__.<>1__state = -1;
			<RequestEmailCode>d__.<>t__builder.Start<PlayStation5Sdk.<RequestEmailCode>d__108>(ref <RequestEmailCode>d__);
			return <RequestEmailCode>d__.<>t__builder.Task;
		}

		// Token: 0x0602ECF3 RID: 191731 RVA: 0x00B156F3 File Offset: 0x00B138F3
		public override bool SupportExternalWebBrowser()
		{
			return false;
		}

		// Token: 0x0602ECF4 RID: 191732 RVA: 0x00B156F8 File Offset: 0x00B138F8
		public override void OpenUserCenter(string sdkUid, [Nullable(2)] Action endCallBack = null)
		{
			PlatformReportClickAccountCenter eventData = new PlatformReportClickAccountCenter();
			this.ReportToThirdParty(eventData);
			string userCenterUrl = Singleton<PlatformSdkServer>.Instance.GetUserCenterUrl();
			string clientId = Singleton<PlatformSdkConfig>.Instance.GetClientId();
			string productId = Singleton<PlatformSdkConfig>.Instance.GetProductId();
			string projectId = Singleton<PlatformSdkConfig>.Instance.GetProjectId();
			string channelId = Singleton<PlatformSdkConfig>.Instance.GetChannelId();
			string language = this.GetLanguage();
			string platformPkg = Singleton<PlatformSdkConfig>.Instance.GetPlatformPkg();
			string currentAccessToken = this.CurrentAccessToken;
			string deviceId = this.GetDeviceId();
			string sdkVersion = Singleton<PlatformSdkConfig>.Instance.GetSdkVersion();
			string runningOnlyCode = this.GetRunningOnlyCode();
			string gameName = this.GetGameName();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(186, 13);
			defaultInterpolatedStringHandler.AppendFormatted(userCenterUrl);
			defaultInterpolatedStringHandler.AppendLiteral("?__e__=1&accessToken=");
			defaultInterpolatedStringHandler.AppendFormatted(currentAccessToken);
			defaultInterpolatedStringHandler.AppendLiteral("&response_type=code&redirect_uri=1&language=");
			defaultInterpolatedStringHandler.AppendFormatted(language);
			defaultInterpolatedStringHandler.AppendLiteral("&isSDK=1&pkg=");
			defaultInterpolatedStringHandler.AppendFormatted(platformPkg);
			defaultInterpolatedStringHandler.AppendLiteral("&userID=");
			defaultInterpolatedStringHandler.AppendFormatted(sdkUid);
			defaultInterpolatedStringHandler.AppendLiteral("&client_id=");
			defaultInterpolatedStringHandler.AppendFormatted(clientId);
			defaultInterpolatedStringHandler.AppendLiteral("&deviceNum=");
			defaultInterpolatedStringHandler.AppendFormatted(deviceId);
			defaultInterpolatedStringHandler.AppendLiteral("&gameName=");
			defaultInterpolatedStringHandler.AppendFormatted(gameName);
			defaultInterpolatedStringHandler.AppendLiteral("&channelId=");
			defaultInterpolatedStringHandler.AppendFormatted(channelId);
			defaultInterpolatedStringHandler.AppendLiteral("&productId=");
			defaultInterpolatedStringHandler.AppendFormatted(productId);
			defaultInterpolatedStringHandler.AppendLiteral("&accountType=0&projectId=");
			defaultInterpolatedStringHandler.AppendFormatted(projectId);
			defaultInterpolatedStringHandler.AppendLiteral("&sdkVersion=");
			defaultInterpolatedStringHandler.AppendFormatted(sdkVersion);
			defaultInterpolatedStringHandler.AppendLiteral("&loginId=");
			defaultInterpolatedStringHandler.AppendFormatted(runningOnlyCode);
			string text = defaultInterpolatedStringHandler.ToStringAndClear();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "打开用户中心开始";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("url", text);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.OpenWebView(text, delegate
			{
				Singleton<LauncherLog>.Instance.Info("打开用户中心结束", default(ReadOnlySpan<ValueTuple<string, object>>));
				Action endCallBack2 = endCallBack;
				if (endCallBack2 == null)
				{
					return;
				}
				endCallBack2();
			});
		}

		// Token: 0x0602ECF5 RID: 191733 RVA: 0x00B158EC File Offset: 0x00B13AEC
		public override void OpenCustomerService()
		{
			PlatformReportClickCustomerService eventData = new PlatformReportClickCustomerService();
			this.ReportToThirdParty(eventData);
			if (Singleton<PlatformSdkServer>.Instance.IsCustomerServiceEnable.GetValueOrDefault())
			{
				string customServiceUrl = Singleton<PlatformSdkConfig>.Instance.GetCustomServiceUrl();
				string channelId = Singleton<PlatformSdkConfig>.Instance.GetChannelId();
				string language = this.GetLanguage();
				string currentAccessToken = this.CurrentAccessToken;
				string gameId = this.GetGameId();
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(59, 5);
				defaultInterpolatedStringHandler.AppendFormatted(customServiceUrl);
				defaultInterpolatedStringHandler.AppendLiteral("?channel_id=");
				defaultInterpolatedStringHandler.AppendFormatted(channelId);
				defaultInterpolatedStringHandler.AppendLiteral("&language=");
				defaultInterpolatedStringHandler.AppendFormatted(language);
				defaultInterpolatedStringHandler.AppendLiteral("&game_id=");
				defaultInterpolatedStringHandler.AppendFormatted(gameId);
				defaultInterpolatedStringHandler.AppendLiteral("&token=");
				defaultInterpolatedStringHandler.AppendFormatted(currentAccessToken);
				defaultInterpolatedStringHandler.AppendLiteral("&islogin=1&source=psn");
				string text = defaultInterpolatedStringHandler.ToStringAndClear();
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "打开客服";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("url", text);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.OpenWebView(text, null);
				return;
			}
			Singleton<LauncherLog>.Instance.Info("关闭了客服", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602ECF6 RID: 191734 RVA: 0x00B15A10 File Offset: 0x00B13C10
		public unsafe override void ReportToServer(EReportRoleDataType type, ReportRoleData data)
		{
			string param = LauncherJson.Stringify<ReportRoleData>(data, null);
			string roleId = data.roleId;
			string roleName = data.roleName;
			string serverId = data.serverId;
			string serverName = data.serverName;
			PlatformSdkReportBaseData.InitSdkRoleValue(roleId, roleName, serverId, serverName);
			Singleton<PlatformSdkServer>.Instance.RequestReportData(this.CurrentAccessToken, param, delegate(int code, string msg, long timestamp)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "ReportToServer";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("code", code);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("msg", msg);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("timestamp", timestamp);
				instance.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			});
			if (type == EReportRoleDataType.Create)
			{
				PlatformReportCreateRole eventData = new PlatformReportCreateRole();
				this.ReportToThirdParty(eventData);
				return;
			}
			if (type == EReportRoleDataType.LevelUp)
			{
				PlatformReportUpgradeRole eventData2 = new PlatformReportUpgradeRole();
				this.ReportToThirdParty(eventData2);
				return;
			}
			if (type == EReportRoleDataType.Select)
			{
				this.ReportToThirdParty(new PlatformReportLoginRole
				{
					level = data.roleLevel
				});
			}
		}

		// Token: 0x0602ECF7 RID: 191735 RVA: 0x00B15ABF File Offset: 0x00B13CBF
		public override void ReportToThirdParty(PlatformSdkReportBaseData eventData)
		{
			if (!this.DataReportInitState)
			{
				this.CacheReportArray.Add(eventData);
				return;
			}
			this.ReportToThirdPartyInternal(eventData);
		}

		// Token: 0x0602ECF8 RID: 191736 RVA: 0x00B15AE0 File Offset: 0x00B13CE0
		private unsafe void ReportToThirdPartyInternal(PlatformSdkReportBaseData eventData)
		{
			if (Singleton<PlatformSdkServer>.Instance.IsReportEnable.GetValueOrDefault())
			{
				string reportEventName = eventData.GetReportEventName();
				string reportData = eventData.GetReportData();
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "ReportToThirdParty";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("eventName", reportEventName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("data", reportData);
				instance.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				FThinkingAnalyticsForCSharp.Track(reportEventName, reportData, this.PlatStationReportIndex);
				UKuroAnalytics.Track(reportEventName, reportData, this.PlatStationReportIndex);
				FKuroAnalyticsForCSharp.Track(reportEventName, reportData, this.PlatStationReportIndex);
				return;
			}
			Singleton<LauncherLog>.Instance.Debug("关闭了数数上报", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602ECF9 RID: 191737 RVA: 0x00B15BA8 File Offset: 0x00B13DA8
		public override void NotifyCurrentLanguage(string language)
		{
			PlatformReportGetGameLanguage eventData = new PlatformReportGetGameLanguage();
			this.ReportToThirdParty(eventData);
			PlatformSdkReportBaseData.ChangeLanguage(language);
			Singleton<PlatformSdkServer>.Instance.SetLanguage(language);
			this.CurrentGameLanguage = language;
		}

		// Token: 0x0602ECFA RID: 191738 RVA: 0x00B15BDA File Offset: 0x00B13DDA
		private string GetLanguage()
		{
			if (this.CurrentGameLanguage == "")
			{
				return Singleton<LauncherLanguageLib>.Instance.PackageLanguage;
			}
			return this.CurrentGameLanguage;
		}

		// Token: 0x0602ECFB RID: 191739 RVA: 0x00B15C00 File Offset: 0x00B13E00
		public override bool BlockServerArea()
		{
			if (KuroApplication.GetAppReleaseType() == "Development")
			{
				return false;
			}
			Singleton<LauncherLog>.Instance.Info("开启了锁区，注意服务器列表配置（将CDN服务器region字段修改成当前国家码可显示）", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}

		// Token: 0x0602ECFC RID: 191740 RVA: 0x00B15C39 File Offset: 0x00B13E39
		public override string GetChannelId()
		{
			return Singleton<PlatformSdkConfig>.Instance.GetChannelId();
		}

		// Token: 0x0602ECFD RID: 191741 RVA: 0x00B15C45 File Offset: 0x00B13E45
		public override string GetPackageId()
		{
			return Singleton<PlatformSdkConfig>.Instance.GetProductId();
		}

		// Token: 0x0602ECFE RID: 191742 RVA: 0x00B15C54 File Offset: 0x00B13E54
		public override string GetSdkCountry()
		{
			string userId = this.GetUserId();
			string countryCodeByUserId = UKuroStaticPS5Library.GetCountryCodeByUserId(ref userId);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "GetSdkCountry";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("countryCode", countryCodeByUserId);
			instance.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return countryCodeByUserId;
		}

		// Token: 0x0602ECFF RID: 191743 RVA: 0x00B15C94 File Offset: 0x00B13E94
		public override void Tick(double delta)
		{
			this.OnTick((float)delta);
		}

		// Token: 0x0602ED00 RID: 191744 RVA: 0x00B15C9E File Offset: 0x00B13E9E
		public override bool NeedLimitUserInfoWhenSocialLimit()
		{
			return true;
		}

		// Token: 0x0401A9E9 RID: 109033
		private const int SDKMAXBLOCKUSER = 2000;

		// Token: 0x0401A9EA RID: 109034
		private const string CACHEAGREEKEY = "AgreeState";

		// Token: 0x0401A9EB RID: 109035
		private const string AGREEVALUE = "1";

		// Token: 0x0401A9EC RID: 109036
		private const int EXIT_WAIT_TIME = 1;

		// Token: 0x0401A9ED RID: 109037
		private const int MAX_PENDING_LOG = 1000;

		// Token: 0x0401A9EE RID: 109038
		private const int SEND_HTTP_TIMEOUT = 10000;

		// Token: 0x0401A9EF RID: 109039
		private const int CALIBRATE_INTERVAL = 10;

		// Token: 0x0401A9F0 RID: 109040
		private const bool CALIBRATE_STOP_TIMER = true;

		// Token: 0x0401A9F1 RID: 109041
		[Nullable(2)]
		private UniversalDataSystemManager UniversalDataSystemManager;

		// Token: 0x0401A9F2 RID: 109042
		[Nullable(2)]
		private PlayStationTrophy PlayStationTrophy;

		// Token: 0x0401A9F3 RID: 109043
		[Nullable(2)]
		private AuthCodeData AuthCodeData;

		// Token: 0x0401A9F4 RID: 109044
		private bool CacheAgreeState;

		// Token: 0x0401A9F5 RID: 109045
		private Dictionary<string, bool> CacheBlockMap = new Dictionary<string, bool>();

		// Token: 0x0401A9F6 RID: 109046
		private long LastGetBlockTime;

		// Token: 0x0401A9F7 RID: 109047
		private readonly Dictionary<string, ESdkRelation> CacheBlockRelationMap = new Dictionary<string, ESdkRelation>();

		// Token: 0x0401A9F8 RID: 109048
		private readonly Dictionary<string, UniTaskCompletionSource<Dictionary<string, ESdkRelation>>> GetBlockRelationMissionPromiseMap = new Dictionary<string, UniTaskCompletionSource<Dictionary<string, ESdkRelation>>>();

		// Token: 0x0401A9F9 RID: 109049
		private string SelfAccountId = "";

		// Token: 0x0401A9FA RID: 109050
		[Nullable(2)]
		private UKuroTickManager Ticker;

		// Token: 0x0401A9FB RID: 109051
		[Nullable(2)]
		private Action<float> TickDelegate;

		// Token: 0x0401A9FC RID: 109052
		private readonly Dictionary<int, Func<int>> OnTickCallBackMap = new Dictionary<int, Func<int>>();

		// Token: 0x0401A9FD RID: 109053
		private int TickUpdateId;

		// Token: 0x0401A9FE RID: 109054
		private ESdkMessageBoxState CacheMessageBoxState;

		// Token: 0x0401A9FF RID: 109055
		private string DeviceId = "";

		// Token: 0x0401AA00 RID: 109056
		private readonly int PlatStationReportIndex = 50;

		// Token: 0x0401AA01 RID: 109057
		private string CurrentGameLanguage = "";

		// Token: 0x0401AA02 RID: 109058
		private List<PlatformSdkReportBaseData> CacheReportArray = new List<PlatformSdkReportBaseData>();

		// Token: 0x0401AA03 RID: 109059
		private bool FirstTimeGetBlockState;

		// Token: 0x0401AA04 RID: 109060
		private string CurrentPayChannelGoodsId = "";

		// Token: 0x0401AA05 RID: 109061
		private string CurrentPayProductId = "";

		// Token: 0x0401AA06 RID: 109062
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FProductData> PsnProducts;

		// Token: 0x0401AA07 RID: 109063
		private long LastGetStoreProductsTime;

		// Token: 0x0401AA08 RID: 109064
		private readonly int GetProductCount = 20;

		// Token: 0x0401AA09 RID: 109065
		private readonly int LabelId;
	}
}
