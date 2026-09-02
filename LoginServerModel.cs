using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform.PlatformSdk;
using CSharpScript.Launcher.Server;
using UnrealEngine;

// Token: 0x02002105 RID: 8453
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class LoginServerModel : ModelBase<LoginServerModel>
{
	// Token: 0x060102A7 RID: 66215 RVA: 0x00470D00 File Offset: 0x0046EF00
	public string GetCurrentSelectPayServerName()
	{
		string text = Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea");
		if (text != "CN" && this.CurrentSelectServerData != null)
		{
			text = this.CurrentSelectServerData.Region;
		}
		else
		{
			text = "Default";
		}
		if (StringUtils.IsEmpty(text))
		{
			text = "Default";
		}
		return text;
	}

	// Token: 0x060102A8 RID: 66216 RVA: 0x00470D58 File Offset: 0x0046EF58
	public string GetCurrentSelectServerIp()
	{
		if (!ControllerBase<KuroSdkController>.Instance.CanUseSdk() && !Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return ModelBase<LoginModel>.Instance.GetServerIp() ?? string.Empty;
		}
		if (ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode())
		{
			if (this.CurrentSelectServerData == null)
			{
				return string.Empty;
			}
			return this.CurrentSelectServerData.ip;
		}
		else
		{
			List<ILoginServersData> loginServersByClientRegion = this.GetLoginServersByClientRegion();
			if (loginServersByClientRegion != null && loginServersByClientRegion.Count > 0)
			{
				return loginServersByClientRegion[0].ip;
			}
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.YZY, "当前没有服务器，请检查CDN配置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return string.Empty;
		}
	}

	// Token: 0x060102A9 RID: 66217 RVA: 0x00470DF8 File Offset: 0x0046EFF8
	public string GetCurrentSelectServerRegion()
	{
		if (ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode())
		{
			if (this.CurrentSelectServerData == null)
			{
				return string.Empty;
			}
			return this.CurrentSelectServerData.Region;
		}
		else
		{
			List<ILoginServersData> loginServersByClientRegion = this.GetLoginServersByClientRegion();
			if (loginServersByClientRegion != null && loginServersByClientRegion.Count > 0)
			{
				return loginServersByClientRegion[0].Region;
			}
			return string.Empty;
		}
	}

	// Token: 0x060102AA RID: 66218 RVA: 0x00470E50 File Offset: 0x0046F050
	public List<string> GetCurrentServerLoginUrl()
	{
		if (ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode())
		{
			if (this.CurrentSelectServerData == null)
			{
				return new List<string>();
			}
			return this.CurrentSelectServerData.LoginUrl;
		}
		else
		{
			List<ILoginServersData> loginServersByClientRegion = this.GetLoginServersByClientRegion();
			if (loginServersByClientRegion != null && loginServersByClientRegion.Count > 0)
			{
				return loginServersByClientRegion[0].LoginUrl;
			}
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LRA, "当前没有服务器，请检查CDN配置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<string>();
		}
	}

	// Token: 0x060102AB RID: 66219 RVA: 0x00470EC4 File Offset: 0x0046F0C4
	public string GetCurrentServerLoginUrlByIndex(int index)
	{
		List<string> currentServerLoginUrl = this.GetCurrentServerLoginUrl();
		if (currentServerLoginUrl == null || currentServerLoginUrl.Count <= 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LRA, "没有可选的LoginUrl", default(ReadOnlySpan<ValueTuple<string, object>>));
			return string.Empty;
		}
		if (index >= currentServerLoginUrl.Count)
		{
			return currentServerLoginUrl[0];
		}
		return currentServerLoginUrl[index];
	}

	// Token: 0x060102AC RID: 66220 RVA: 0x00470F20 File Offset: 0x0046F120
	public string GetCurrentSelectServerName()
	{
		if (ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode())
		{
			if (this.CurrentSelectServerData == null)
			{
				return string.Empty;
			}
			return this.CurrentSelectServerData.name;
		}
		else
		{
			List<ILoginServersData> loginServersByClientRegion = this.GetLoginServersByClientRegion();
			if (loginServersByClientRegion != null && loginServersByClientRegion.Count > 0)
			{
				return loginServersByClientRegion[0].name;
			}
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.YZY, "当前没有服务器，请检查CDN配置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return string.Empty;
		}
	}

	// Token: 0x060102AD RID: 66221 RVA: 0x00470F94 File Offset: 0x0046F194
	public string GetCurrentLoginServerId()
	{
		if (!ControllerBase<KuroSdkController>.Instance.CanUseSdk() && !Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return ModelBase<LoginModel>.Instance.GetServerId() ?? string.Empty;
		}
		if (ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode())
		{
			if (this.CurrentSelectServerData == null)
			{
				return "0";
			}
			return this.CurrentSelectServerData.id;
		}
		else
		{
			List<ILoginServersData> loginServersByClientRegion = this.GetLoginServersByClientRegion();
			if (loginServersByClientRegion != null && loginServersByClientRegion.Count > 0)
			{
				return loginServersByClientRegion[0].id;
			}
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.YZY, "当前没有服务器，请检查CDN配置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return "0";
		}
	}

	// Token: 0x060102AE RID: 66222 RVA: 0x00471034 File Offset: 0x0046F234
	public List<ILoginServersData> GetLoginServersByClientRegion()
	{
		if (this.LoginServerData != null)
		{
			return this.LoginServerData;
		}
		List<ILoginServersData> list = Singleton<BaseConfigController>.Instance.GetLoginServers() ?? new List<ILoginServersData>();
		List<ILoginServersData> list2 = new List<ILoginServersData>();
		foreach (ILoginServersData loginServersData in list)
		{
			if (this.OnlyRegion != string.Empty)
			{
				if (loginServersData.Region == this.OnlyRegion)
				{
					list2.Add(loginServersData);
				}
			}
			else
			{
				list2.Add(loginServersData);
			}
		}
		if (Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().BlockServerArea())
		{
			this.LoginServerData = new List<ILoginServersData>();
			string sdkCountry = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetSdkCountry();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Login;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "锁区";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("currentCountryCode", sdkCountry);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			foreach (ILoginServersData loginServersData2 in list2)
			{
				if (!string.IsNullOrEmpty(loginServersData2.Region))
				{
					ServerLimit? serverLimitConfig = ConfigBase<LoginConfig>.Instance.GetServerLimitConfig(loginServersData2.Region);
					if (serverLimitConfig != null && !string.IsNullOrEmpty(sdkCountry) && serverLimitConfig.Value.CountryCodes.Contains(sdkCountry))
					{
						this.LoginServerData.Add(loginServersData2);
					}
				}
			}
			if (this.LoginServerData.Count == 0)
			{
				foreach (ILoginServersData loginServersData3 in list2)
				{
					if (loginServersData3.Region == "SEA")
					{
						this.LoginServerData.Add(loginServersData3);
						break;
					}
				}
			}
			return this.LoginServerData;
		}
		this.LoginServerData = list2;
		return this.LoginServerData;
	}

	// Token: 0x060102AF RID: 66223 RVA: 0x0047123C File Offset: 0x0046F43C
	public void SelectCurrentSelectServerByServerId(string serverIp, string serverId)
	{
		ModelBase<LoginModel>.Instance.SetServerIp(serverIp, 1);
		List<ILoginServersData> loginServersByClientRegion = this.GetLoginServersByClientRegion();
		if (loginServersByClientRegion != null && loginServersByClientRegion.Count > 0)
		{
			foreach (ILoginServersData loginServersData in loginServersByClientRegion)
			{
				if (loginServersData.id == serverId)
				{
					this.CurrentSelectServerData = loginServersData;
					break;
				}
			}
		}
		ModelBase<LoginModel>.Instance.SetServerId(serverId);
		ModelBase<LoginModel>.Instance.SetServerName((this.CurrentSelectServerData != null) ? this.CurrentSelectServerData.name : string.Empty);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "选择服务器";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("serverId", serverId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x060102B0 RID: 66224 RVA: 0x00471310 File Offset: 0x0046F510
	public bool IsFirstLogin(string sdkUid)
	{
		Dictionary<string, RegionAndIpSt> global = LocalStorage.GetGlobal<Dictionary<string, RegionAndIpSt>>(ELocalStorageGlobalKey.SdkLastTimeLoginData, null);
		return global == null || !global.ContainsKey(sdkUid);
	}

	// Token: 0x060102B1 RID: 66225 RVA: 0x00471338 File Offset: 0x0046F538
	[return: Nullable(2)]
	public RegionAndIpSt LastTimeLoginData(string sdkUid)
	{
		Dictionary<string, RegionAndIpSt> global = LocalStorage.GetGlobal<Dictionary<string, RegionAndIpSt>>(ELocalStorageGlobalKey.SdkLastTimeLoginData, null);
		if (global != null && global.ContainsKey(sdkUid))
		{
			return global.GetValueOrDefault(sdkUid);
		}
		return null;
	}

	// Token: 0x060102B2 RID: 66226 RVA: 0x00471364 File Offset: 0x0046F564
	public void SaveFirstLogin(string sdkUid, ILoginServersData data)
	{
		Dictionary<string, RegionAndIpSt> global = LocalStorage.GetGlobal<Dictionary<string, RegionAndIpSt>>(ELocalStorageGlobalKey.SdkLastTimeLoginData, null);
		Dictionary<string, RegionAndIpSt> dictionary = new Dictionary<string, RegionAndIpSt>();
		if (global != null)
		{
			foreach (KeyValuePair<string, RegionAndIpSt> keyValuePair in global)
			{
				dictionary[keyValuePair.Key] = keyValuePair.Value;
			}
		}
		RegionAndIpSt regionAndIpSt = new RegionAndIpSt();
		regionAndIpSt.Phrase(data.Region, data.ip);
		dictionary[sdkUid] = regionAndIpSt;
		LocalStorage.SetGlobal<Dictionary<string, RegionAndIpSt>>(ELocalStorageGlobalKey.SdkLastTimeLoginData, dictionary);
	}

	// Token: 0x060102B3 RID: 66227 RVA: 0x004713FC File Offset: 0x0046F5FC
	public void AddRegionPingValue(ILoginServersData data, float ping)
	{
		this.RegionPingMap[data] = ping;
	}

	// Token: 0x060102B4 RID: 66228 RVA: 0x0047140C File Offset: 0x0046F60C
	public void RefreshIpPing(string ipAddress, float time)
	{
		List<ILoginServersData> list = new List<ILoginServersData>(this.RegionPingMap.Keys);
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (list[i].PingUrl == ipAddress)
			{
				this.RegionPingMap[list[i]] = time * 1000f;
			}
		}
	}

	// Token: 0x060102B5 RID: 66229 RVA: 0x0047146C File Offset: 0x0046F66C
	[return: Nullable(2)]
	public global::LoginPlayerInfo GetPlayerLoginInfo(string sdkUid)
	{
		global::LoginPlayerInfo result;
		if (this.CurrentLoginPlayerInfoMap.TryGetValue(sdkUid, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x060102B6 RID: 66230 RVA: 0x0047148C File Offset: 0x0046F68C
	public void SetPlayerLoginInfo(string sdkUid, global::LoginPlayerInfo data)
	{
		this.CurrentLoginPlayerInfoMap[sdkUid] = data;
	}

	// Token: 0x060102B7 RID: 66231 RVA: 0x0047149C File Offset: 0x0046F69C
	[return: Nullable(2)]
	private ILoginServersData FindRegionServerData(RegionAndIpSt data)
	{
		List<ILoginServersData> list = new List<ILoginServersData>(this.RegionPingMap.Keys);
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (list[i].Region == data.Region)
			{
				return list[i];
			}
		}
		return null;
	}

	// Token: 0x060102B8 RID: 66232 RVA: 0x004714F0 File Offset: 0x0046F6F0
	public void InitSuggestData(string sdkUid, [Nullable(new byte[]
	{
		1,
		2
	})] Action<ILoginServersData> callBack)
	{
		if (Singleton<LauncherServer>.Instance.CacheSuggestLoginServerData.GetValueOrDefault(sdkUid) != null)
		{
			ILoginServersData valueOrDefault = Singleton<LauncherServer>.Instance.CacheSuggestLoginServerData.GetValueOrDefault(sdkUid);
			if (this.OnlyRegion == string.Empty || ((valueOrDefault != null) ? valueOrDefault.Region : null) == this.OnlyRegion)
			{
				this.CurrentSelectServerData = valueOrDefault;
				callBack(valueOrDefault);
				Singleton<LauncherServer>.Instance.CacheSuggestLoginServerData.Remove(sdkUid);
				this.OnBeginSuggestServerData = this.CurrentSelectServerData;
				return;
			}
			Singleton<LauncherServer>.Instance.CacheSuggestLoginServerData.Remove(sdkUid);
		}
		this.CurrentSelectServerData = null;
		if (this.OnlyRegion != string.Empty)
		{
			List<ILoginServersData> loginServersByClientRegion = this.GetLoginServersByClientRegion();
			if (loginServersByClientRegion != null && loginServersByClientRegion.Count > 0)
			{
				this.OnBeginSuggestServerData = loginServersByClientRegion[0];
				this.CurrentSelectServerData = loginServersByClientRegion[0];
			}
			if (callBack != null)
			{
				callBack(this.CurrentSelectServerData);
			}
			return;
		}
		RegionAndIpSt suggestServerData = this.GetSuggestServerData(sdkUid);
		this.CurrentSelectServerData = this.FindRegionServerData(suggestServerData);
		this.OnBeginSuggestServerData = this.CurrentSelectServerData;
		if (this.OnBeginSuggestServerData == null)
		{
			List<ILoginServersData> loginServersByClientRegion2 = this.GetLoginServersByClientRegion();
			if (loginServersByClientRegion2 != null && loginServersByClientRegion2.Count > 0)
			{
				this.OnBeginSuggestServerData = loginServersByClientRegion2[0];
				this.CurrentSelectServerData = loginServersByClientRegion2[0];
			}
		}
		if (callBack != null)
		{
			callBack(this.CurrentSelectServerData);
		}
	}

	// Token: 0x060102B9 RID: 66233 RVA: 0x00471644 File Offset: 0x0046F844
	private RegionAndIpSt GetSuggestServerData(string sdkUid)
	{
		List<ILoginServersData> list = new List<ILoginServersData>(this.RegionPingMap.Keys);
		int count = list.Count;
		global::LoginPlayerInfo playerLoginInfo = this.GetPlayerLoginInfo(sdkUid);
		if (playerLoginInfo != null)
		{
			string text = string.Empty;
			if (playerLoginInfo.UserInfos != null && playerLoginInfo.UserInfos.Count > 0)
			{
				int lastOnlineTime = playerLoginInfo.UserInfos[0].LastOnlineTime;
				text = playerLoginInfo.UserInfos[0].Region;
				int count2 = playerLoginInfo.UserInfos.Count;
				for (int i = 0; i < count2; i++)
				{
					if (playerLoginInfo.UserInfos[i].LastOnlineTime > lastOnlineTime)
					{
						text = playerLoginInfo.UserInfos[i].Region;
						lastOnlineTime = playerLoginInfo.UserInfos[i].LastOnlineTime;
					}
				}
			}
			if (text != string.Empty)
			{
				ILoginServersData loginServersData = this.FindRegionData(text);
				if (loginServersData != null)
				{
					RegionAndIpSt regionAndIpSt = new RegionAndIpSt();
					regionAndIpSt.Phrase(loginServersData.Region, loginServersData.ip);
					return regionAndIpSt;
				}
			}
			string recommendRegion = playerLoginInfo.RecommendRegion;
			int j = 0;
			while (j < count)
			{
				if (list[j].Region == recommendRegion)
				{
					if (this.CheckIfAllServerPingHigh())
					{
						RegionAndIpSt regionAndIpSt2 = new RegionAndIpSt();
						regionAndIpSt2.Phrase(list[j].Region, list[j].ip);
						return regionAndIpSt2;
					}
					float num = this.RegionPingMap[list[j]];
					if (num != 0f && num > 100f)
					{
						return this.GetPingMiniData("America");
					}
					RegionAndIpSt regionAndIpSt3 = new RegionAndIpSt();
					regionAndIpSt3.Phrase(list[j].Region, list[j].ip);
					return regionAndIpSt3;
				}
				else
				{
					j++;
				}
			}
			return this.GetPingMiniData("America");
		}
		RegionAndIpSt regionAndIpSt4 = this.LastTimeLoginData(sdkUid);
		if (regionAndIpSt4 != null)
		{
			return regionAndIpSt4;
		}
		return this.GetPingMiniData("America");
	}

	// Token: 0x060102BA RID: 66234 RVA: 0x00471830 File Offset: 0x0046FA30
	[return: Nullable(2)]
	private ILoginServersData FindRegionData(string region)
	{
		List<ILoginServersData> list = new List<ILoginServersData>(this.RegionPingMap.Keys);
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (list[i].Region == region)
			{
				return list[i];
			}
		}
		return null;
	}

	// Token: 0x060102BB RID: 66235 RVA: 0x00471880 File Offset: 0x0046FA80
	private bool CheckIfAllServerPingHigh()
	{
		List<ILoginServersData> list = new List<ILoginServersData>(this.RegionPingMap.Keys);
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			float num = this.RegionPingMap[list[i]];
			if (num != 0f && num < 100f)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060102BC RID: 66236 RVA: 0x004718D8 File Offset: 0x0046FAD8
	private RegionAndIpSt GetPingMiniData(string defaultServerRegion)
	{
		List<ILoginServersData> list = new List<ILoginServersData>(this.RegionPingMap.Keys);
		int count = list.Count;
		float num = 9999f;
		string ip = string.Empty;
		RegionAndIpSt regionAndIpSt = new RegionAndIpSt();
		for (int i = 0; i < count; i++)
		{
			if (num > this.RegionPingMap[list[i]])
			{
				num = this.RegionPingMap[list[i]];
				regionAndIpSt.Phrase(list[i].Region, list[i].ip);
			}
			if (list[i].Region == defaultServerRegion)
			{
				ip = list[i].ip;
			}
		}
		if (StringUtils.IsEmpty(regionAndIpSt.Ip))
		{
			regionAndIpSt.Phrase(defaultServerRegion, ip);
		}
		return regionAndIpSt;
	}

	// Token: 0x060102BD RID: 66237 RVA: 0x004719A8 File Offset: 0x0046FBA8
	public int GetLoginLevel(string sdkUid, string region)
	{
		global::LoginPlayerInfo playerLoginInfo = this.GetPlayerLoginInfo(sdkUid);
		if (playerLoginInfo != null)
		{
			int num = (playerLoginInfo.UserInfos != null) ? playerLoginInfo.UserInfos.Count : 0;
			for (int i = 0; i < num; i++)
			{
				if (playerLoginInfo.UserInfos[i] != null && playerLoginInfo.UserInfos[i].Region == region)
				{
					return playerLoginInfo.UserInfos[i].Level;
				}
			}
			return 0;
		}
		return this.GetLocalRegionLevel(sdkUid, region);
	}

	// Token: 0x060102BE RID: 66238 RVA: 0x00471A28 File Offset: 0x0046FC28
	private int GetLocalRegionLevel(string sdkUid, string region)
	{
		Dictionary<string, LocalPlayerIpLevelData[]> global = LocalStorage.GetGlobal<Dictionary<string, LocalPlayerIpLevelData[]>>(ELocalStorageGlobalKey.SdkLevelData, null);
		if (global != null && global.ContainsKey(sdkUid))
		{
			LocalPlayerIpLevelData[] valueOrDefault = global.GetValueOrDefault(sdkUid);
			int num = valueOrDefault.Length;
			for (int i = 0; i < num; i++)
			{
				if (valueOrDefault[i].Region == region)
				{
					return valueOrDefault[i].Level;
				}
			}
			return 0;
		}
		return 0;
	}

	// Token: 0x060102BF RID: 66239 RVA: 0x00471A80 File Offset: 0x0046FC80
	public string GetCurrentArea()
	{
		string[] array = UKuroStaticLibrary.GetCultureRegion().Split('-', StringSplitOptions.None);
		int num = array.Length;
		if (num <= 1)
		{
			return "US";
		}
		if (!(array[num - 1] == string.Empty))
		{
			return array[num - 1];
		}
		return "US";
	}

	// Token: 0x060102C0 RID: 66240 RVA: 0x00471AC8 File Offset: 0x0046FCC8
	public void SaveLocalRegionLevel(string sdkUid, string region, int level)
	{
		Dictionary<string, LocalPlayerIpLevelData[]> global = LocalStorage.GetGlobal<Dictionary<string, LocalPlayerIpLevelData[]>>(ELocalStorageGlobalKey.SdkLevelData, null);
		Dictionary<string, LocalPlayerIpLevelData[]> dictionary = new Dictionary<string, LocalPlayerIpLevelData[]>();
		if (global != null)
		{
			foreach (KeyValuePair<string, LocalPlayerIpLevelData[]> keyValuePair in global)
			{
				dictionary[keyValuePair.Key] = keyValuePair.Value;
			}
		}
		LocalPlayerIpLevelData[] array;
		if (!dictionary.TryGetValue(sdkUid, out array))
		{
			array = new LocalPlayerIpLevelData[0];
		}
		int num = array.Length;
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			if (array[i].Region == region)
			{
				array[i].Level = level;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			array = new List<LocalPlayerIpLevelData>(array)
			{
				new LocalPlayerIpLevelData
				{
					Region = region,
					Level = level
				}
			}.ToArray();
		}
		dictionary[sdkUid] = array;
		LocalStorage.SetGlobal<Dictionary<string, LocalPlayerIpLevelData[]>>(ELocalStorageGlobalKey.SdkLevelData, dictionary);
	}

	// Token: 0x060102C1 RID: 66241 RVA: 0x00471BC0 File Offset: 0x0046FDC0
	public void SetOnlyRegion(string region)
	{
		this.OnlyRegion = region;
		this.LoginServerData = null;
		this.TrySetRegionState = true;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "GetOnlyRegionInfo";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("region", region);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x060102C2 RID: 66242 RVA: 0x00471C09 File Offset: 0x0046FE09
	public bool GetIfSetOnlyRegion()
	{
		return this.TrySetRegionState;
	}

	// Token: 0x04007C31 RID: 31793
	private const string DEFAULTSERVERREGION = "America";

	// Token: 0x04007C32 RID: 31794
	private const string SEASERVER = "SEA";

	// Token: 0x04007C33 RID: 31795
	private const string CNSERVERNAME = "Default";

	// Token: 0x04007C34 RID: 31796
	public const int DEFAULTPING = 9999;

	// Token: 0x04007C35 RID: 31797
	private readonly Dictionary<string, global::LoginPlayerInfo> CurrentLoginPlayerInfoMap = new Dictionary<string, global::LoginPlayerInfo>();

	// Token: 0x04007C36 RID: 31798
	private readonly Dictionary<ILoginServersData, float> RegionPingMap = new Dictionary<ILoginServersData, float>();

	// Token: 0x04007C37 RID: 31799
	[Nullable(2)]
	public ILoginServersData OnBeginSuggestServerData;

	// Token: 0x04007C38 RID: 31800
	[Nullable(2)]
	public ILoginServersData CurrentSelectServerData;

	// Token: 0x04007C39 RID: 31801
	[Nullable(2)]
	public ILoginServersData CurrentUiSelectSeverData;

	// Token: 0x04007C3A RID: 31802
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ILoginServersData> LoginServerData;

	// Token: 0x04007C3B RID: 31803
	public string OnlyRegion = string.Empty;

	// Token: 0x04007C3C RID: 31804
	private bool TrySetRegionState;
}
