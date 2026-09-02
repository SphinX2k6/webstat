using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x020021DD RID: 8669
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RealThinkingAnalyticsReporter : Singleton<RealThinkingAnalyticsReporter>
{
	// Token: 0x0601058B RID: 66955 RVA: 0x004774E0 File Offset: 0x004756E0
	public void Init()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnGetPlayerBasicInfo, new Action(this.OnGetPlayerBasicInfo));
		Singleton<EventSystem>.Instance.Add(EEventName.LogOut, new Action(this.LogOut));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSetLoginServerId, new Action(this.SwitchToLoginServerConfig));
	}

	// Token: 0x0601058C RID: 66956 RVA: 0x00477544 File Offset: 0x00475744
	private void OnGetPlayerBasicInfo()
	{
		UThinkingAnalytics.Login(ModelBase<PlayerInfoModel>.Instance.GetId().ToString(), 0);
	}

	// Token: 0x0601058D RID: 66957 RVA: 0x0047756F File Offset: 0x0047576F
	private void LogOut()
	{
		UThinkingAnalytics.Logout(0);
	}

	// Token: 0x0601058E RID: 66958 RVA: 0x00477578 File Offset: 0x00475778
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
		if (((loginServerById != null) ? loginServerById.TDCfg : null) != null)
		{
			itdconfig = loginServerById.TDCfg;
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Log;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "使用LoginServer的数数配置";
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
			if (UThinkingAnalytics.HasInstanceInitialized(0))
			{
				bool flag = false;
				if (text != null && UThinkingAnalytics.GetServerUrl(0) != url)
				{
					flag = true;
				}
				if (appID != null && UThinkingAnalytics.GetAppId(0) != appID)
				{
					flag = true;
				}
				if (flag)
				{
					UThinkingAnalytics.DestroyInstance(0, true);
				}
			}
			UThinkingAnalytics.InitializeDefaultInsWithURL_Appid(url, appID, 1f, 1000, 10000f, true, 10f, true);
			if (this.OnCalibrateDelegate == null)
			{
				this.OnCalibrateDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnTimeCalibrated>(new Action<int>(this.OnCalibrate));
			}
			UThinkingAnalytics.CalibrateTime(this.OnCalibrateDelegate, 0);
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LW, "数数上报实例已重新创建！", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.Login, ELogAuthor.LW, "未找到 " + text + " 对应的数数上报配置", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601058F RID: 66959 RVA: 0x0047772F File Offset: 0x0047592F
	public void Report(string key, string jsonLog)
	{
		FThinkingAnalyticsForCSharp.Track(key, jsonLog, 0);
	}

	// Token: 0x06010590 RID: 66960 RVA: 0x0047773C File Offset: 0x0047593C
	private void OnCalibrate(int index)
	{
		if (!UThinkingAnalytics.HasInstanceTimeCalibrated(index))
		{
			Singleton<Log>.Instance.Info(ELogModule.LogReport, ELogAuthor.LW, "数数上报时间校准失败，可以因为以下问题导致：1.CDN数数上报配置错误；2.网络原因连接不上。", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x040080E0 RID: 32992
	private readonly Stat TrackStat = Stat.Create("ThinkingAnalyticsReporter.Track", "", "");

	// Token: 0x040080E1 RID: 32993
	[Nullable(2)]
	private FOnTimeCalibrated OnCalibrateDelegate;
}
