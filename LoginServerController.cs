using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using UnrealEngine;

// Token: 0x020020FF RID: 8447
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class LoginServerController : UiControllerBase<LoginServerController>
{
	// Token: 0x06010299 RID: 66201 RVA: 0x004708F8 File Offset: 0x0046EAF8
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, this.SaveFirstLogin);
		Singleton<EventSystem>.Instance.Add(EEventName.OnGetPlayerBasicInfo, this.OnGetBasicInfo);
		Singleton<EventSystem>.Instance.Add<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, this.SaveServerLevel);
	}

	// Token: 0x0601029A RID: 66202 RVA: 0x00470948 File Offset: 0x0046EB48
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, this.SaveFirstLogin);
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGetPlayerBasicInfo, this.OnGetBasicInfo);
		Singleton<EventSystem>.Instance.Remove<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, this.SaveServerLevel);
	}

	// Token: 0x0601029B RID: 66203 RVA: 0x00470997 File Offset: 0x0046EB97
	protected override bool OnInit()
	{
		this.IcmpPingCallBack = global::DelegateUtils.ToManualReleaseDelegate<FPingCallExDelegate>(this.IcmpCallBack);
		return true;
	}

	// Token: 0x0601029C RID: 66204 RVA: 0x004709AC File Offset: 0x0046EBAC
	public void PingAllRegion()
	{
		if (!ControllerBase<KuroSdkController>.Instance.CanUseSdk() || !ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
		{
			return;
		}
		List<ILoginServersData> loginServersByClientRegion = ModelBase<LoginServerModel>.Instance.GetLoginServersByClientRegion();
		foreach (ILoginServersData data in loginServersByClientRegion)
		{
			ModelBase<LoginServerModel>.Instance.AddRegionPingValue(data, 9999f);
		}
		foreach (ILoginServersData loginServersData in loginServersByClientRegion)
		{
			UKuroStaticLibrary.IcmpPing(loginServersData.PingUrl, 2f, this.IcmpPingCallBack);
		}
	}

	// Token: 0x0601029D RID: 66205 RVA: 0x00470A74 File Offset: 0x0046EC74
	public void TryGetServerPlayerInfo()
	{
		if (ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode())
		{
			LoginServerController.ELoginGetPlayerInfoEnum loginType = LoginServerController.ELoginGetPlayerInfoEnum.SdkMode;
			SdkLoginConfig sdkLoginConfig = ModelBase<LoginModel>.Instance.GetSdkLoginConfig();
			string userId = ((sdkLoginConfig != null) ? sdkLoginConfig.Uid : null) ?? "";
			SdkLoginConfig sdkLoginConfig2 = ModelBase<LoginModel>.Instance.GetSdkLoginConfig();
			string userName = ((sdkLoginConfig2 != null) ? sdkLoginConfig2.UserName : null) ?? "";
			SdkLoginConfig sdkLoginConfig3 = ModelBase<LoginModel>.Instance.GetSdkLoginConfig();
			this.GetLoginPlayerInfo(loginType, userId, userName, ((sdkLoginConfig3 != null) ? sdkLoginConfig3.Token : null) ?? "", ModelBase<LoginServerModel>.Instance.GetCurrentArea());
		}
	}

	// Token: 0x0601029E RID: 66206 RVA: 0x00470AFC File Offset: 0x0046ECFC
	public void GetLoginPlayerInfo(LoginServerController.ELoginGetPlayerInfoEnum loginType, string userId, string userName, string token, string area)
	{
		if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
		{
			return;
		}
		string garurl = Singleton<PublicUtil>.Instance.GetGARUrl((int)loginType, userId, userName, token, area);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "获得GetLoginPlayerInfo";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("url", garurl);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (string.IsNullOrEmpty(garurl))
		{
			Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "没有GetLoginPlayerInfo", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Http.Get(garurl, null, this.SetLoginPlayerInfoData, null);
	}

	// Token: 0x0601029F RID: 66207 RVA: 0x00470B8F File Offset: 0x0046ED8F
	protected override bool OnClear()
	{
		if (this.IcmpPingCallBack != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(this.IcmpCallBack);
			this.IcmpPingCallBack = null;
		}
		return true;
	}

	// Token: 0x04007C1C RID: 31772
	public const int ICMP_TIME_OUT = 2;

	// Token: 0x04007C1D RID: 31773
	public FPingCallExDelegate IcmpPingCallBack;

	// Token: 0x04007C1E RID: 31774
	private readonly Action SaveFirstLogin = delegate()
	{
		if (ModelBase<LoginServerModel>.Instance.CurrentSelectServerData == null)
		{
			return;
		}
		LoginServerModel instance = ModelBase<LoginServerModel>.Instance;
		SdkLoginConfig sdkLoginConfig = ModelBase<LoginModel>.Instance.GetSdkLoginConfig();
		instance.SaveFirstLogin(((sdkLoginConfig != null) ? sdkLoginConfig.Uid : null) ?? "", ModelBase<LoginServerModel>.Instance.CurrentSelectServerData);
	};

	// Token: 0x04007C1F RID: 31775
	private readonly Action OnGetBasicInfo = delegate()
	{
		if (ModelBase<LoginServerModel>.Instance.CurrentSelectServerData == null)
		{
			return;
		}
		LoginServerModel instance = ModelBase<LoginServerModel>.Instance;
		SdkLoginConfig sdkLoginConfig = ModelBase<LoginModel>.Instance.GetSdkLoginConfig();
		instance.SaveLocalRegionLevel(((sdkLoginConfig != null) ? sdkLoginConfig.Uid : null) ?? "", ModelBase<LoginServerModel>.Instance.CurrentSelectServerData.Region, ModelBase<FunctionModel>.Instance.GetPlayerLevel().Value);
	};

	// Token: 0x04007C20 RID: 31776
	private readonly Action<int, int, int, int, int, int, int> SaveServerLevel = delegate(int lastLevel, int currentLevel, int currentExp, int lastExp, int addExp, int currentMaxExp, int lastMaxExp)
	{
		if (ModelBase<LoginServerModel>.Instance.CurrentSelectServerData == null)
		{
			return;
		}
		LoginServerModel instance = ModelBase<LoginServerModel>.Instance;
		SdkLoginConfig sdkLoginConfig = ModelBase<LoginModel>.Instance.GetSdkLoginConfig();
		instance.SaveLocalRegionLevel(((sdkLoginConfig != null) ? sdkLoginConfig.Uid : null) ?? "", ModelBase<LoginServerModel>.Instance.CurrentSelectServerData.Region, currentLevel);
	};

	// Token: 0x04007C21 RID: 31777
	private readonly Action<string, float, int> IcmpCallBack = delegate(string ipAddress, float time, int responseState)
	{
		if (ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
		{
			ModelBase<LoginServerModel>.Instance.RefreshIpPing(ipAddress, time);
		}
	};

	// Token: 0x04007C22 RID: 31778
	private readonly Action<bool, int, string> SetLoginPlayerInfoData = delegate(bool success, int code, string data)
	{
		if (code != 200)
		{
			return;
		}
		LoginPlayerInfo loginPlayerInfo = Json.Parse<LoginPlayerInfo>(data, null);
		if (loginPlayerInfo == null)
		{
			return;
		}
		if (loginPlayerInfo.Code != 0)
		{
			return;
		}
		if (loginPlayerInfo.SdkLoginCode != 0)
		{
			return;
		}
		ModelBase<LoginServerModel>.Instance.SetPlayerLoginInfo(loginPlayerInfo.UserId, loginPlayerInfo);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnGetLoginPlayerInfo);
	};

	// Token: 0x02008481 RID: 33921
	[NullableContext(0)]
	public enum ELoginGetPlayerInfoEnum
	{
		// Token: 0x0402CE50 RID: 183888
		TestMode,
		// Token: 0x0402CE51 RID: 183889
		SdkMode
	}
}
