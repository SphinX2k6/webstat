using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x020021DE RID: 8670
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RealKRAnalyticsReporter : Singleton<RealKRAnalyticsReporter>
{
	// Token: 0x06010592 RID: 66962 RVA: 0x00477794 File Offset: 0x00475994
	public void Init()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnGetPlayerBasicInfo, new Action(Singleton<RealKRAnalyticsReporter>.Instance.OnGetPlayerBasicInfo));
		Singleton<EventSystem>.Instance.Add(EEventName.LogOut, new Action(Singleton<RealKRAnalyticsReporter>.Instance.LogOut));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSetLoginServerId, new Action(Singleton<RealKRAnalyticsReporter>.Instance.SwitchToLoginServerConfig));
	}

	// Token: 0x06010593 RID: 66963 RVA: 0x00477804 File Offset: 0x00475A04
	private void OnGetPlayerBasicInfo()
	{
		UKuroAnalytics.Login(ModelBase<PlayerInfoModel>.Instance.GetId().ToString(), 0);
	}

	// Token: 0x06010594 RID: 66964 RVA: 0x0047782F File Offset: 0x00475A2F
	private void LogOut()
	{
		UKuroAnalytics.Logout(0);
	}

	// Token: 0x06010595 RID: 66965 RVA: 0x00477838 File Offset: 0x00475A38
	private unsafe void SwitchToLoginServerConfig()
	{
		if (!ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
		{
			return;
		}
		if (Singleton<BaseConfigController>.Instance.GetIosAuditFirstDownloadTipWithSkip())
		{
			return;
		}
		LoginModel instance = ModelBase<LoginModel>.Instance;
		string text = (instance != null) ? instance.GetServerId() : null;
		ITDConfig itdconfig = null;
		ILoginServersData loginServerById = Singleton<BaseConfigController>.Instance.GetLoginServerById(text);
		if (((loginServerById != null) ? loginServerById.KDCfg : null) != null)
		{
			itdconfig = loginServerById.KDCfg;
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Log;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "使用LoginServer的KuroData配置";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ServerId", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AppID", itdconfig.AppID);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("URL", itdconfig.URL);
			instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		if (itdconfig != null)
		{
			string url = itdconfig.URL;
			string appID = itdconfig.AppID;
			if (UKuroAnalytics.HasInstanceInitialized(0))
			{
				bool flag = false;
				if (text != null && UKuroAnalytics.GetServerUrl(0) != url)
				{
					flag = true;
				}
				if (appID != null && UKuroAnalytics.GetAppId(0) != appID)
				{
					flag = true;
				}
				if (flag)
				{
					UKuroAnalytics.DestroyInstance(0, true);
				}
			}
			UKuroAnalytics.InitializeDefaultInsWithURL_Appid(url, appID, 1f, 1000, 10000f, true, 10f, true);
			if (this.OnCalibrateDelegate == null)
			{
				this.OnCalibrateDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKAOnTimeCalibrated>(new Action<int>(this.OnCalibrate));
			}
			UKuroAnalytics.CalibrateTime(this.OnCalibrateDelegate, 0);
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LW, "KuroData上报实例已重新创建！", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.Login, ELogAuthor.LW, "未找到 " + text + " 对应的KuroData上报配置", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06010596 RID: 66966 RVA: 0x004779EF File Offset: 0x00475BEF
	public void Report(string key, string jsonLog)
	{
		FKuroAnalyticsForCSharp.Track(key, jsonLog, 0);
	}

	// Token: 0x06010597 RID: 66967 RVA: 0x004779FC File Offset: 0x00475BFC
	private void OnCalibrate(int index)
	{
		if (!UKuroAnalytics.HasInstanceTimeCalibrated(index))
		{
			Singleton<Log>.Instance.Info(ELogModule.LogReport, ELogAuthor.LW, "KuroData上报时间校准失败，可以因为以下问题导致：1.CDNKuroData上报配置错误；2.网络原因连接不上。", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x040080E2 RID: 32994
	private readonly Stat TrackStat = Stat.Create("KRAnalyticsReporter.Track", "", "");

	// Token: 0x040080E3 RID: 32995
	[Nullable(2)]
	private FKAOnTimeCalibrated OnCalibrateDelegate;
}
