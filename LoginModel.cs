using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.Server.Struct;
using AkiClient.Game.Aki.UI.Module.Loading.View;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform.PlatformSdk;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020020FE RID: 8446
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class LoginModel : ModelBase<LoginModel>
{
	// Token: 0x17001363 RID: 4963
	// (get) Token: 0x0601020F RID: 66063 RVA: 0x0046EFF6 File Offset: 0x0046D1F6
	public bool IsNewAccount
	{
		get
		{
			return this.IsNewAccountInternal;
		}
	}

	// Token: 0x17001364 RID: 4964
	// (get) Token: 0x06010210 RID: 66064 RVA: 0x0046EFFE File Offset: 0x0046D1FE
	// (set) Token: 0x06010211 RID: 66065 RVA: 0x0046F007 File Offset: 0x0046D207
	private int LoginFailCount
	{
		get
		{
			return LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.LoginFailCount, 0);
		}
		set
		{
			LocalStorage.SetGlobal<int>(ELocalStorageGlobalKey.LoginFailCount, value);
		}
	}

	// Token: 0x17001365 RID: 4965
	// (get) Token: 0x06010212 RID: 66066 RVA: 0x0046F011 File Offset: 0x0046D211
	// (set) Token: 0x06010213 RID: 66067 RVA: 0x0046F022 File Offset: 0x0046D222
	private double NextLoginTime
	{
		get
		{
			return LocalStorage.GetGlobal<double>(ELocalStorageGlobalKey.NextLoginTime, 0.0);
		}
		set
		{
			LocalStorage.SetGlobal<double>(ELocalStorageGlobalKey.NextLoginTime, value);
		}
	}

	// Token: 0x17001366 RID: 4966
	// (get) Token: 0x06010214 RID: 66068 RVA: 0x0046F02C File Offset: 0x0046D22C
	// (set) Token: 0x06010215 RID: 66069 RVA: 0x0046F03D File Offset: 0x0046D23D
	private double ResetLoginFailCountTime
	{
		get
		{
			return LocalStorage.GetGlobal<double>(ELocalStorageGlobalKey.ResetLoginFailCountTime, 0.0);
		}
		set
		{
			LocalStorage.SetGlobal<double>(ELocalStorageGlobalKey.ResetLoginFailCountTime, value);
		}
	}

	// Token: 0x06010216 RID: 66070 RVA: 0x0046F047 File Offset: 0x0046D247
	public void ClearDetectionCache()
	{
		this.ConnectFamily = 0;
		this.UdpPort = 0;
		this.ResolvedIp = "";
		this.PingResults = "";
	}

	// Token: 0x17001367 RID: 4967
	// (get) Token: 0x06010217 RID: 66071 RVA: 0x0046F06D File Offset: 0x0046D26D
	// (set) Token: 0x06010218 RID: 66072 RVA: 0x0046F075 File Offset: 0x0046D275
	public int PublicJsonVersion
	{
		get
		{
			return this.PublicJsonVersionInternal;
		}
		set
		{
			this.PublicJsonVersionInternal = value;
		}
	}

	// Token: 0x17001368 RID: 4968
	// (get) Token: 0x06010219 RID: 66073 RVA: 0x0046F07E File Offset: 0x0046D27E
	// (set) Token: 0x0601021A RID: 66074 RVA: 0x0046F086 File Offset: 0x0046D286
	public int PublicMiscVersion
	{
		get
		{
			return this.PublicMiscVersionInternal;
		}
		set
		{
			this.PublicMiscVersionInternal = value;
		}
	}

	// Token: 0x17001369 RID: 4969
	// (get) Token: 0x0601021B RID: 66075 RVA: 0x0046F08F File Offset: 0x0046D28F
	// (set) Token: 0x0601021C RID: 66076 RVA: 0x0046F097 File Offset: 0x0046D297
	public int PublicUniverseEditorVersion
	{
		get
		{
			return this.PublicUniverseEditorVersionInternal;
		}
		set
		{
			this.PublicUniverseEditorVersionInternal = value;
		}
	}

	// Token: 0x1700136A RID: 4970
	// (get) Token: 0x0601021D RID: 66077 RVA: 0x0046F0A0 File Offset: 0x0046D2A0
	// (set) Token: 0x0601021E RID: 66078 RVA: 0x0046F0A8 File Offset: 0x0046D2A8
	public string LauncherVersion
	{
		get
		{
			return this.LauncherVersionInternal;
		}
		set
		{
			this.LauncherVersionInternal = value;
		}
	}

	// Token: 0x1700136B RID: 4971
	// (get) Token: 0x0601021F RID: 66079 RVA: 0x0046F0B1 File Offset: 0x0046D2B1
	// (set) Token: 0x06010220 RID: 66080 RVA: 0x0046F0B9 File Offset: 0x0046D2B9
	public string ResourceVersion
	{
		get
		{
			return this.ResourceVersionInternal;
		}
		set
		{
			this.ResourceVersionInternal = value;
		}
	}

	// Token: 0x1700136C RID: 4972
	// (get) Token: 0x06010221 RID: 66081 RVA: 0x0046F0C2 File Offset: 0x0046D2C2
	// (set) Token: 0x06010222 RID: 66082 RVA: 0x0046F0CA File Offset: 0x0046D2CA
	public TimerHandle VerifyConfigVersionHandle
	{
		get
		{
			return this.VerifyVersionHandleInternal;
		}
		set
		{
			this.VerifyVersionHandleInternal = value;
		}
	}

	// Token: 0x06010223 RID: 66083 RVA: 0x0046F0D4 File Offset: 0x0046D2D4
	protected override bool OnInit()
	{
		this.BornMode = EBornMode.PlayLocationDefaultPlayerStart;
		this.BornLocation = Aki.Protocol.Vector.Create();
		this.LoginStatus = LoginDefine.ELoginStatus.Init;
		this.SdkLoginState = LoginDefine.ESdkLoginState.Logout;
		this.CpuInfoInternal = UKuroStaticLibrary.GetDeviceCPU();
		this.DeviceInfoInternal = UKuroRenderingRuntimeBPPluginBPLibrary.GetRHIDeviceName();
		this.DriverDateInternal = UKuroRenderingRuntimeBPPluginBPLibrary.GetRHIDriverDate();
		if (this.DriverDateInternal == null || this.DriverDateInternal.Length == 0)
		{
			this.DriverDateInternal = "Unknown";
		}
		this.HealthTipTime = (double)ConfigCommonParamById.GetIntConfig("HealthTipTime").GetValueOrDefault();
		return true;
	}

	// Token: 0x06010224 RID: 66084 RVA: 0x0046F15C File Offset: 0x0046D35C
	protected override bool OnClear()
	{
		this.LoginStatus = LoginDefine.ELoginStatus.Init;
		this.SdkLoginState = LoginDefine.ESdkLoginState.Logout;
		this.SingleMapList = new List<LoginMapConfig>();
		this.MultiMapList = new List<LoginMapConfig>();
		this.ServerInfoList = new List<ServerConfig>();
		this.ServerDataList = new List<ServerData>();
		this.LoginStatus = LoginDefine.ELoginStatus.Init;
		this.AutoOpenLoginView = false;
		this.PlayerName = string.Empty;
		this.PlayerSex = null;
		this.HasCharacter = false;
		this.LastFailStatus = null;
		this.PublicJsonVersionInternal = 0;
		this.PublicMiscVersionInternal = 0;
		this.PublicUniverseEditorVersionInternal = 0;
		this.LauncherVersionInternal = null;
		this.ResourceVersionInternal = null;
		this.CpuInfoInternal = null;
		this.DeviceInfoInternal = null;
		this.DriverDateInternal = null;
		this.RpcInc = 0;
		this.HttpRpcMap.Clear();
		return true;
	}

	// Token: 0x06010225 RID: 66085 RVA: 0x0046F228 File Offset: 0x0046D428
	public void InitConfig()
	{
		if (this.SingleMapList == null || this.MultiMapList == null || this.ServerInfoList == null)
		{
			this.SingleMapList = new List<LoginMapConfig>();
			this.MultiMapList = new List<LoginMapConfig>();
			this.ServerInfoList = new List<ServerConfig>();
			this.ServerDataList = new List<ServerData>();
			IReadOnlyList<InstanceDungeon> allInstanceDungeon = ConfigBase<LoginConfig>.Instance.GetAllInstanceDungeon();
			if (allInstanceDungeon != null)
			{
				foreach (InstanceDungeon instanceDungeon in allInstanceDungeon)
				{
					string text = ConfigBase<LoginConfig>.Instance.GetInstanceDungeonNameById(instanceDungeon.MapName);
					if (text == null)
					{
						text = string.Empty;
					}
					this.SingleMapList.Add(new LoginMapConfig(instanceDungeon.Id, text));
				}
			}
		}
	}

	// Token: 0x06010226 RID: 66086 RVA: 0x0046F2F4 File Offset: 0x0046D4F4
	public void AddServerInfoByCdn()
	{
		if (this.ServerInfoList == null)
		{
			return;
		}
		List<ILoginServersData> loginServersByClientRegion = ModelBase<LoginServerModel>.Instance.GetLoginServersByClientRegion();
		if (loginServersByClientRegion == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Login, ELogAuthor.XXJ, "拿不到CDN返回的服务器数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (loginServersByClientRegion.Count <= 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.XXJ, "CDN的服务器数据列表为空", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		foreach (ILoginServersData loginServersData in loginServersByClientRegion)
		{
			ServerConfig serverConfig = new ServerConfig(loginServersData.ip, "5500", loginServersData.name, 0);
			this.ServerInfoList.Add(serverConfig);
			this.ServerDataList.Add(new ServerData(serverConfig));
		}
	}

	// Token: 0x06010227 RID: 66087 RVA: 0x0046F3CC File Offset: 0x0046D5CC
	public void AddExtraServer()
	{
		TArray<string> tarray = UKuroStaticLibrary.LoadFileToStringArray(UBlueprintPathsLibrary.ProjectConfigDir() + "/ServerConfig.json");
		if (tarray.Num() <= 0)
		{
			return;
		}
		for (int i = 0; i < tarray.Num(); i++)
		{
			ServerConfig item = Json.Parse<ServerConfig>(tarray.Get(i), null);
			this.ServerInfoList.Add(item);
		}
	}

	// Token: 0x06010228 RID: 66088 RVA: 0x0046F424 File Offset: 0x0046D624
	[NullableContext(1)]
	public void AddServerInfos(ServerInfo[] serverInfoArray)
	{
		if (this.ServerInfoList == null)
		{
			return;
		}
		bool isPlayInEditor = Singleton<Info>.Instance.IsPlayInEditor;
		foreach (ServerInfo serverInfo in serverInfoArray)
		{
			if ((isPlayInEditor && serverInfo.editor != null) || (!isPlayInEditor && serverInfo.package != null))
			{
				this.ServerInfoList.Add(new ServerConfig(serverInfo.address, "5500", serverInfo.description, serverInfo.order.GetValueOrDefault()));
			}
		}
	}

	// Token: 0x06010229 RID: 66089 RVA: 0x0046F4A8 File Offset: 0x0046D6A8
	public void AddDataTableServers()
	{
		if (this.ServerInfoList == null)
		{
			return;
		}
		if (GlobalData.World != null)
		{
			foreach (SServerInfo sserverInfo in DataTableUtil.GetDataTableAllRow<SServerInfo>(EDataTable.ServerInfo))
			{
				this.ServerInfoList.Add(new ServerConfig(sserverInfo.IP, sserverInfo.Port, sserverInfo.Name, sserverInfo.Order));
			}
		}
	}

	// Token: 0x0601022A RID: 66090 RVA: 0x0046F530 File Offset: 0x0046D730
	public void CleanConfig()
	{
		this.SingleMapList = null;
		this.MultiMapList = null;
		this.ServerInfoList = null;
		this.SdkLoginConfig = null;
		this.ServerDataList = null;
	}

	// Token: 0x0601022B RID: 66091 RVA: 0x0046F555 File Offset: 0x0046D755
	public void SetCreatePlayerTime(double time)
	{
		this.CreatePlayerTime = time;
	}

	// Token: 0x0601022C RID: 66092 RVA: 0x0046F55E File Offset: 0x0046D75E
	public double GetCreatePlayerTime()
	{
		return this.CreatePlayerTime;
	}

	// Token: 0x0601022D RID: 66093 RVA: 0x0046F566 File Offset: 0x0046D766
	public void SetCreatePlayerId(int id)
	{
		this.CreatePlayerId = id;
	}

	// Token: 0x0601022E RID: 66094 RVA: 0x0046F56F File Offset: 0x0046D76F
	public int GetCreatePlayerId()
	{
		return this.CreatePlayerId;
	}

	// Token: 0x0601022F RID: 66095 RVA: 0x0046F577 File Offset: 0x0046D777
	public string GetServerIp()
	{
		return this.ServerIp;
	}

	// Token: 0x06010230 RID: 66096 RVA: 0x0046F57F File Offset: 0x0046D77F
	public string GetSourcePlayerAccount()
	{
		return this.SourceAccount;
	}

	// Token: 0x06010231 RID: 66097 RVA: 0x0046F588 File Offset: 0x0046D788
	[NullableContext(1)]
	public unsafe void SetServerIp(string serverIp, int reason)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "保存服务器IP";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("serverIp", serverIp);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", reason);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.ServerIp = serverIp;
	}

	// Token: 0x06010232 RID: 66098 RVA: 0x0046F5F4 File Offset: 0x0046D7F4
	public unsafe void TrySetCustomServerPort(string port, int reason)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "自定义服务器Port";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("port", port);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", reason);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.ServerCustomPort = port;
	}

	// Token: 0x06010233 RID: 66099 RVA: 0x0046F660 File Offset: 0x0046D860
	[NullableContext(1)]
	public string TryGetRealServerPort()
	{
		string customServerPort = this.GetCustomServerPort();
		if (customServerPort != null)
		{
			this.ServerCustomPort = null;
			return customServerPort;
		}
		return this.GetServerPort();
	}

	// Token: 0x06010234 RID: 66100 RVA: 0x0046F686 File Offset: 0x0046D886
	public string GetCustomServerPort()
	{
		return this.ServerCustomPort;
	}

	// Token: 0x06010235 RID: 66101 RVA: 0x0046F690 File Offset: 0x0046D890
	[NullableContext(1)]
	public string GetServerPort()
	{
		string result = "5500";
		string[] array = UKismetSystemLibrary.GetCommandLine().Split(' ', StringSplitOptions.None);
		int num = Array.IndexOf<string>(array, "-LocalGameServerStartPort");
		if (num == -1)
		{
			return result;
		}
		if (num + 1 >= array.Length)
		{
			return result;
		}
		int num2;
		if (!int.TryParse(array[num + 1], out num2))
		{
			return result;
		}
		return (num2 + 1).ToString();
	}

	// Token: 0x06010236 RID: 66102 RVA: 0x0046F6E9 File Offset: 0x0046D8E9
	public string GetServerName()
	{
		return this.ServerName;
	}

	// Token: 0x06010237 RID: 66103 RVA: 0x0046F6F4 File Offset: 0x0046D8F4
	[NullableContext(1)]
	public void SetServerName(string serverName)
	{
		this.ServerName = serverName;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "当前选择服务器Name";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("serverId", serverName);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06010238 RID: 66104 RVA: 0x0046F72F File Offset: 0x0046D92F
	public string GetServerId()
	{
		return this.ServerId;
	}

	// Token: 0x06010239 RID: 66105 RVA: 0x0046F738 File Offset: 0x0046D938
	[NullableContext(1)]
	public void SetServerId(string serverId)
	{
		this.ServerId = serverId;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSetLoginServerId);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "当前选择服务器Id";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("serverId", serverId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601023A RID: 66106 RVA: 0x0046F784 File Offset: 0x0046D984
	public int GetSingleMapId()
	{
		int global = LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.SingleMapId, -1);
		if (global != -1)
		{
			return global;
		}
		return 0;
	}

	// Token: 0x0601023B RID: 66107 RVA: 0x0046F7A0 File Offset: 0x0046D9A0
	public void SetSingleMapId(int singleMapId)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "保存单人副本id";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("singleMapId", singleMapId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		LocalStorage.SetGlobal<int>(ELocalStorageGlobalKey.SingleMapId, singleMapId);
	}

	// Token: 0x0601023C RID: 66108 RVA: 0x0046F7E0 File Offset: 0x0046D9E0
	public int GetMultiMapId()
	{
		int global = LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.MultiMapId, -1);
		if (global != -1)
		{
			return global;
		}
		return 0;
	}

	// Token: 0x0601023D RID: 66109 RVA: 0x0046F7FC File Offset: 0x0046D9FC
	public void SetMultiMapId(int multiMapId)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "保存多人副本id";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("multiMapId", multiMapId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		LocalStorage.SetGlobal<int>(ELocalStorageGlobalKey.MultiMapId, multiMapId);
	}

	// Token: 0x0601023E RID: 66110 RVA: 0x0046F83C File Offset: 0x0046DA3C
	[NullableContext(1)]
	public string GetAccount()
	{
		return LocalStorage.GetGlobal<string>(ELocalStorageGlobalKey.Account, string.Empty) ?? string.Empty;
	}

	// Token: 0x0601023F RID: 66111 RVA: 0x0046F853 File Offset: 0x0046DA53
	[NullableContext(1)]
	public void SetAccount(string account)
	{
		LocalStorage.SetGlobal<string>(ELocalStorageGlobalKey.Account, account);
		this.AddRecentlyAccount(account);
		Singleton<ThirdPartySdkManager>.Instance.SetUserInfo(account);
	}

	// Token: 0x06010240 RID: 66112 RVA: 0x0046F870 File Offset: 0x0046DA70
	[NullableContext(1)]
	public void SetSourceAccount(string account)
	{
		this.SourceAccount = account;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "设置复制账号";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("目标账号:", account);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06010241 RID: 66113 RVA: 0x0046F8AA File Offset: 0x0046DAAA
	public bool GetSelectBoxActive()
	{
		return LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.SelectBoxActive, true);
	}

	// Token: 0x06010242 RID: 66114 RVA: 0x0046F8B3 File Offset: 0x0046DAB3
	public void SetSelectBoxActive(bool selectBoxActive)
	{
		LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.SelectBoxActive, selectBoxActive);
	}

	// Token: 0x06010243 RID: 66115 RVA: 0x0046F8BD File Offset: 0x0046DABD
	public bool GetAutoOpenLoginView()
	{
		return this.AutoOpenLoginView;
	}

	// Token: 0x06010244 RID: 66116 RVA: 0x0046F8C5 File Offset: 0x0046DAC5
	public void SetAutoOpenLoginView(bool ret)
	{
		this.AutoOpenLoginView = ret;
	}

	// Token: 0x06010245 RID: 66117 RVA: 0x0046F8CE File Offset: 0x0046DACE
	public LoginDefine.ELoginStatus GetLoginStatus()
	{
		return this.LoginStatus;
	}

	// Token: 0x06010246 RID: 66118 RVA: 0x0046F8D6 File Offset: 0x0046DAD6
	public LoginDefine.ELoginStatus? GetLastFailStatus()
	{
		return this.LastFailStatus;
	}

	// Token: 0x06010247 RID: 66119 RVA: 0x0046F8E0 File Offset: 0x0046DAE0
	public unsafe void SetLoginStatus(LoginDefine.ELoginStatus loginStatus, bool userLogout = false)
	{
		if (loginStatus == this.LoginStatus)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "LoginProcedure-登录状态变化";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Before", this.LoginStatus.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("After", loginStatus.ToString());
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (this.LoginStatus != LoginDefine.ELoginStatus.Init && loginStatus == LoginDefine.ELoginStatus.Init)
		{
			Singleton<Log>.Instance.Error(ELogModule.Login, ELogAuthor.LRA, "LoginProcedure-登录失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<Heartbeat>.Instance.StopHeartBeat(HeartbeatDefine.EStopHeartbeat.LoginStatusInit);
			this.LastFailStatus = new LoginDefine.ELoginStatus?(this.LoginStatus);
		}
		else
		{
			this.LastFailStatus = null;
		}
		this.LoginStatus = loginStatus;
		Singleton<EventSystem>.Instance.Emit(EEventName.LoginStatusChange);
	}

	// Token: 0x06010248 RID: 66120 RVA: 0x0046F9CA File Offset: 0x0046DBCA
	public bool IsLoginStatus(LoginDefine.ELoginStatus loginStatus)
	{
		return this.LoginStatus == loginStatus;
	}

	// Token: 0x06010249 RID: 66121 RVA: 0x0046F9D5 File Offset: 0x0046DBD5
	public void SetSdkLoginState(LoginDefine.ESdkLoginState state)
	{
		this.SdkLoginState = state;
		if (state == LoginDefine.ESdkLoginState.Logout)
		{
			if (this.SdkLoginConfig != null)
			{
				this.SetSdkLoginConfig(string.Empty, string.Empty, string.Empty);
			}
			this.ThirdGameAutoLoginId = "-1";
		}
	}

	// Token: 0x0601024A RID: 66122 RVA: 0x0046FA09 File Offset: 0x0046DC09
	[NullableContext(1)]
	public void SetSdkLoginInfo(string loginCode, string uid, string username)
	{
		if (this.SdkLoginInfo == null)
		{
			this.SdkLoginInfo = new SdkLoginInfo();
		}
		this.SdkLoginInfo.LoginCode = loginCode;
		this.SdkLoginInfo.Uid = uid;
		this.SdkLoginInfo.UserName = username;
	}

	// Token: 0x0601024B RID: 66123 RVA: 0x0046FA42 File Offset: 0x0046DC42
	public SdkLoginInfo GetSdkLoginInfo()
	{
		return this.SdkLoginInfo;
	}

	// Token: 0x0601024C RID: 66124 RVA: 0x0046FA4A File Offset: 0x0046DC4A
	public bool IsSdkLoggedIn()
	{
		return this.SdkLoginState == LoginDefine.ESdkLoginState.Login;
	}

	// Token: 0x0601024D RID: 66125 RVA: 0x0046FA55 File Offset: 0x0046DC55
	public bool IsSdkLoggingIn()
	{
		return this.SdkLoginState == LoginDefine.ESdkLoginState.LoggingIn;
	}

	// Token: 0x0601024E RID: 66126 RVA: 0x0046FA60 File Offset: 0x0046DC60
	public bool IsSdkLogout()
	{
		return this.SdkLoginState == LoginDefine.ESdkLoginState.Logout;
	}

	// Token: 0x0601024F RID: 66127 RVA: 0x0046FA6B File Offset: 0x0046DC6B
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<LoginMapConfig> GetSingleMapList()
	{
		return this.SingleMapList;
	}

	// Token: 0x06010250 RID: 66128 RVA: 0x0046FA74 File Offset: 0x0046DC74
	public int? GetSingleMapIp(int index)
	{
		if (this.SingleMapList != null && index < this.SingleMapList.Count)
		{
			return new int?(this.SingleMapList[index].MapId);
		}
		return null;
	}

	// Token: 0x06010251 RID: 66129 RVA: 0x0046FAB8 File Offset: 0x0046DCB8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<ServerConfig> GetServerInfoList()
	{
		if (this.ServerInfoList != null)
		{
			this.ServerInfoList = (from x in this.ServerInfoList
			orderby x.Order
			select x).ToList<ServerConfig>();
		}
		return this.ServerInfoList;
	}

	// Token: 0x06010252 RID: 66130 RVA: 0x0046FB08 File Offset: 0x0046DD08
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<ServerData> GetServerDataList()
	{
		return this.ServerDataList;
	}

	// Token: 0x06010253 RID: 66131 RVA: 0x0046FB10 File Offset: 0x0046DD10
	public ServerConfig GetServerInfo(int index)
	{
		if (this.ServerInfoList != null && index < this.ServerInfoList.Count)
		{
			return this.ServerInfoList[index];
		}
		return null;
	}

	// Token: 0x06010254 RID: 66132 RVA: 0x0046FB36 File Offset: 0x0046DD36
	public bool HasReconnectInfo()
	{
		return this.ReconnectInfo != null;
	}

	// Token: 0x06010255 RID: 66133 RVA: 0x0046FB41 File Offset: 0x0046DD41
	[NullableContext(1)]
	public void SetReconnectInfo(string token, string host, int port)
	{
		this.ReconnectInfo = new ReconnectInfo(token, host, port);
	}

	// Token: 0x06010256 RID: 66134 RVA: 0x0046FB51 File Offset: 0x0046DD51
	[NullableContext(1)]
	public void SetReconnectToken(string token)
	{
		if (this.ReconnectInfo != null)
		{
			this.ReconnectInfo.Token = token;
		}
	}

	// Token: 0x06010257 RID: 66135 RVA: 0x0046FB67 File Offset: 0x0046DD67
	public string GetReconnectToken()
	{
		if (this.ReconnectInfo == null)
		{
			return null;
		}
		return this.ReconnectInfo.Token;
	}

	// Token: 0x06010258 RID: 66136 RVA: 0x0046FB7E File Offset: 0x0046DD7E
	public string GetReconnectHost()
	{
		if (this.ReconnectInfo == null)
		{
			return null;
		}
		return this.ReconnectInfo.Host;
	}

	// Token: 0x06010259 RID: 66137 RVA: 0x0046FB98 File Offset: 0x0046DD98
	public int? GetReconnectPort()
	{
		if (this.ReconnectInfo == null)
		{
			return null;
		}
		return new int?(this.ReconnectInfo.Port);
	}

	// Token: 0x0601025A RID: 66138 RVA: 0x0046FBC7 File Offset: 0x0046DDC7
	public string GetPlayerName()
	{
		return this.PlayerName;
	}

	// Token: 0x0601025B RID: 66139 RVA: 0x0046FBCF File Offset: 0x0046DDCF
	[NullableContext(1)]
	public void SetPlayerName(string playerName)
	{
		this.PlayerName = playerName;
	}

	// Token: 0x0601025C RID: 66140 RVA: 0x0046FBD8 File Offset: 0x0046DDD8
	public int? GetPlayerSex()
	{
		if (this.PlayerSex == null)
		{
			return null;
		}
		return new int?((int)this.PlayerSex.Value);
	}

	// Token: 0x0601025D RID: 66141 RVA: 0x0046FC0C File Offset: 0x0046DE0C
	public void SetPlayerSex(LoginDefine.ELoginSex playerSex)
	{
		this.PlayerSex = new LoginDefine.ELoginSex?(playerSex);
	}

	// Token: 0x0601025E RID: 66142 RVA: 0x0046FC1C File Offset: 0x0046DE1C
	public bool IsPlayerSexValid(int? playerSex)
	{
		int? num = playerSex;
		if (playerSex == null)
		{
			num = ((this.PlayerSex != null) ? new int?((int)this.PlayerSex.Value) : null);
		}
		if (num.GetValueOrDefault() != 1)
		{
			int? num2 = num;
			int num3 = 0;
			if (!(num2.GetValueOrDefault() == num3 & num2 != null))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0601025F RID: 66143 RVA: 0x0046FC82 File Offset: 0x0046DE82
	public bool GetHasCharacter()
	{
		return this.HasCharacter;
	}

	// Token: 0x06010260 RID: 66144 RVA: 0x0046FC8A File Offset: 0x0046DE8A
	public void SetHasCharacter(bool hasCharacter)
	{
		this.HasCharacter = hasCharacter;
	}

	// Token: 0x06010261 RID: 66145 RVA: 0x0046FC93 File Offset: 0x0046DE93
	public void SetIsNewAccount(bool isNewAccount)
	{
		this.IsNewAccountInternal = isNewAccount;
	}

	// Token: 0x06010262 RID: 66146 RVA: 0x0046FC9C File Offset: 0x0046DE9C
	public void CleanCreateData()
	{
		this.HasCharacter = false;
		this.PlayerName = string.Empty;
		this.PlayerSex = null;
	}

	// Token: 0x06010263 RID: 66147 RVA: 0x0046FCBC File Offset: 0x0046DEBC
	[NullableContext(1)]
	public int SetRpcHttp(Action callback, int timeoutMs)
	{
		LoginModel.<>c__DisplayClass151_0 CS$<>8__locals1 = new LoginModel.<>c__DisplayClass151_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.callback = callback;
		LoginModel.<>c__DisplayClass151_0 CS$<>8__locals2 = CS$<>8__locals1;
		int num = this.RpcInc + 1;
		this.RpcInc = num;
		CS$<>8__locals2.rpcId = num;
		TimerHandle value = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			if (CS$<>8__locals1.<>4__this.IsLoginStatus(LoginDefine.ELoginStatus.LoginHttp))
			{
				CS$<>8__locals1.<>4__this.HttpRpcMap.Remove(CS$<>8__locals1.rpcId);
				CS$<>8__locals1.callback();
			}
		}, (float)timeoutMs, null, null, true, 1f);
		this.HttpRpcMap[CS$<>8__locals1.rpcId] = value;
		return CS$<>8__locals1.rpcId;
	}

	// Token: 0x06010264 RID: 66148 RVA: 0x0046FD30 File Offset: 0x0046DF30
	public bool CleanRpcHttp(int rpcId)
	{
		TimerHandle handle;
		if (this.HttpRpcMap.TryGetValue(rpcId, out handle))
		{
			TimerSystem.GameplayTimeInstance.Remove(handle);
			this.HttpRpcMap.Remove(rpcId);
			return true;
		}
		return false;
	}

	// Token: 0x06010265 RID: 66149 RVA: 0x0046FD6C File Offset: 0x0046DF6C
	public void AddLoginFailCount()
	{
		if (this.LoginFailCount == 0)
		{
			int? loginFailResetTime = ConfigBase<LoginConfig>.Instance.GetLoginFailResetTime();
			this.SetResetLoginFailCountTime(((loginFailResetTime != null) ? new double?((double)loginFailResetTime.GetValueOrDefault()) : null).Value, true);
		}
		this.SetLoginFailCount(this.LoginFailCount + 1, true);
		double? num = new double?((double)ConfigBase<LoginConfig>.Instance.GetLoginFailParam(this.LoginFailCount));
		this.SetNextLoginTime(num.Value, true);
	}

	// Token: 0x06010266 RID: 66150 RVA: 0x0046FDF4 File Offset: 0x0046DFF4
	public bool IsThisTimeCanLogin()
	{
		double num = (double)DateTimeOffset.Now.ToUnixTimeMilliseconds() * 0.001;
		if (this.LoginFailCount > 0)
		{
			int? loginFailResetTime = ConfigBase<LoginConfig>.Instance.GetLoginFailResetTime();
			double? num2 = (loginFailResetTime != null) ? new double?((double)loginFailResetTime.GetValueOrDefault()) : null;
			if (num >= this.ResetLoginFailCountTime + num2.Value)
			{
				this.CleanLoginFailCount(LoginDefine.ECleanFailCountWay.RefreshTime);
				return true;
			}
		}
		double? num3 = new double?(this.NextLoginTime + (double)ConfigBase<LoginConfig>.Instance.GetLoginFailParam(this.LoginFailCount));
		if (num >= num3.Value)
		{
			return true;
		}
		DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)(num3.Value * 1000.0)).DateTime;
		return false;
	}

	// Token: 0x06010267 RID: 66151 RVA: 0x0046FEBD File Offset: 0x0046E0BD
	public void CleanLoginFailCount(LoginDefine.ECleanFailCountWay way)
	{
		this.SetLoginFailCount(0, false);
		this.SetNextLoginTime(0.0, false);
		this.SetResetLoginFailCountTime(0.0, false);
	}

	// Token: 0x06010268 RID: 66152 RVA: 0x0046FEE7 File Offset: 0x0046E0E7
	public void SetLoginFailCount(int count, bool isLog = true)
	{
		this.LoginFailCount = count;
	}

	// Token: 0x06010269 RID: 66153 RVA: 0x0046FEF4 File Offset: 0x0046E0F4
	private void SetNextLoginTime(double addTime, bool isLog = true)
	{
		this.NextLoginTime = (double)DateTimeOffset.Now.ToUnixTimeMilliseconds() * 0.001;
		if (isLog)
		{
			DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)((this.NextLoginTime + addTime) * 1000.0)).DateTime;
		}
	}

	// Token: 0x0601026A RID: 66154 RVA: 0x0046FF44 File Offset: 0x0046E144
	private void SetResetLoginFailCountTime(double addTime, bool isLog = true)
	{
		this.ResetLoginFailCountTime = (double)DateTimeOffset.Now.ToUnixTimeMilliseconds() * 0.001;
		if (isLog)
		{
			DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)((this.ResetLoginFailCountTime + addTime) * 1000.0)).DateTime;
		}
	}

	// Token: 0x0601026B RID: 66155 RVA: 0x0046FF94 File Offset: 0x0046E194
	public void FixLoginFailInfo()
	{
		double num = (double)DateTimeOffset.Now.ToUnixTimeMilliseconds() * 0.001;
		if (this.ResetLoginFailCountTime > num)
		{
			int? loginFailResetTime = ConfigBase<LoginConfig>.Instance.GetLoginFailResetTime();
			this.SetResetLoginFailCountTime(((loginFailResetTime != null) ? new double?((double)loginFailResetTime.GetValueOrDefault()) : null).Value, true);
		}
		if (this.NextLoginTime > num)
		{
			double? num2 = new double?((double)ConfigBase<LoginConfig>.Instance.GetLoginFailParam(this.LoginFailCount));
			this.SetNextLoginTime(num2.Value, true);
		}
	}

	// Token: 0x0601026C RID: 66156 RVA: 0x00470030 File Offset: 0x0046E230
	[NullableContext(1)]
	public unsafe void SetSdkLoginConfig(string uId, string userName, string token)
	{
		this.SdkLoginConfig = new SdkLoginConfig(uId, userName, token);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "设置SDK登录配置";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("uId", uId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("userName", userName);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x0601026D RID: 66157 RVA: 0x004700A0 File Offset: 0x0046E2A0
	public bool CheckLoginToGameServerSdkConfigIfSame()
	{
		if (this.SdkLoginConfig != null && this.LoginToGameServerSdkLoginConfig != null)
		{
			if (this.SdkLoginConfig.Uid != this.LoginToGameServerSdkLoginConfig.Uid || this.SdkLoginConfig.UserName != this.LoginToGameServerSdkLoginConfig.UserName || this.SdkLoginConfig.Token != this.LoginToGameServerSdkLoginConfig.Token)
			{
				this.SdkAccountChangeNeedExitFlag = true;
			}
			else
			{
				this.SdkAccountChangeNeedExitFlag = false;
			}
		}
		return this.SdkAccountChangeNeedExitFlag;
	}

	// Token: 0x0601026E RID: 66158 RVA: 0x0047012C File Offset: 0x0046E32C
	public unsafe void CacheCurrentSdkLoginConfig()
	{
		if (this.SdkLoginConfig != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Login;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "缓存当前登录服务器SDK登录配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("uId", this.SdkLoginConfig.Uid);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("userName", this.SdkLoginConfig.UserName);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.LoginToGameServerSdkLoginConfig = new SdkLoginConfig(this.SdkLoginConfig.Uid, this.SdkLoginConfig.UserName, this.SdkLoginConfig.Token);
			return;
		}
		this.LoginToGameServerSdkLoginConfig = null;
	}

	// Token: 0x0601026F RID: 66159 RVA: 0x004701DF File Offset: 0x0046E3DF
	public SdkLoginConfig GetSdkLoginConfig()
	{
		return this.SdkLoginConfig;
	}

	// Token: 0x06010270 RID: 66160 RVA: 0x004701E7 File Offset: 0x0046E3E7
	[NullableContext(1)]
	public string GetLoginUid()
	{
		if (!ControllerBase<KuroSdkController>.Instance.CanUseSdk() && !Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return this.GetAccount();
		}
		if (this.SdkLoginConfig == null)
		{
			return string.Empty;
		}
		return this.SdkLoginConfig.Uid;
	}

	// Token: 0x06010271 RID: 66161 RVA: 0x00470221 File Offset: 0x0046E421
	[NullableContext(1)]
	public string GetLoginUserName()
	{
		if (this.SdkLoginConfig == null)
		{
			return string.Empty;
		}
		return this.SdkLoginConfig.UserName;
	}

	// Token: 0x06010272 RID: 66162 RVA: 0x0047023C File Offset: 0x0046E43C
	[NullableContext(1)]
	public string GetLoginUserNameWithUriEncode()
	{
		if (this.SdkLoginConfig == null)
		{
			return string.Empty;
		}
		return this.SdkLoginConfig.GetLoginUserNameWithUriEncode();
	}

	// Token: 0x06010273 RID: 66163 RVA: 0x00470257 File Offset: 0x0046E457
	[NullableContext(1)]
	public string GetLoginToken()
	{
		if (this.SdkLoginConfig == null)
		{
			return string.Empty;
		}
		return this.SdkLoginConfig.Token;
	}

	// Token: 0x1700136D RID: 4973
	// (get) Token: 0x06010274 RID: 66164 RVA: 0x00470272 File Offset: 0x0046E472
	// (set) Token: 0x06010275 RID: 66165 RVA: 0x0047027A File Offset: 0x0046E47A
	public LogoutNotify LogoutNotify
	{
		get
		{
			return this.LogoutNotifyInternal;
		}
		set
		{
			this.LogoutNotifyInternal = value;
		}
	}

	// Token: 0x06010276 RID: 66166 RVA: 0x00470283 File Offset: 0x0046E483
	public void SetTodayFirstTimeLogin(bool ret)
	{
		this.IfFirstTimeLogin = ret;
	}

	// Token: 0x06010277 RID: 66167 RVA: 0x0047028C File Offset: 0x0046E48C
	public bool GetTodayFirstTimeLogin()
	{
		return this.IfFirstTimeLogin;
	}

	// Token: 0x06010278 RID: 66168 RVA: 0x00470294 File Offset: 0x0046E494
	public double GetLastLoginTime()
	{
		return LocalStorage.GetPlayer<double>(ELocalStoragePlayerKey.LoginTime, 0.0);
	}

	// Token: 0x06010279 RID: 66169 RVA: 0x004702A6 File Offset: 0x0046E4A6
	public void SetLastLoginTime(double time)
	{
		LocalStorage.SetPlayer<double>(ELocalStoragePlayerKey.LoginTime, time);
	}

	// Token: 0x0601027A RID: 66170 RVA: 0x004702B4 File Offset: 0x0046E4B4
	[NullableContext(1)]
	public void AddRecentlyAccount(string name)
	{
		if (StringUtils.IsEmpty(name))
		{
			return;
		}
		if (this.RecentlyAccountList == null)
		{
			this.RecentlyAccountList = new List<string>();
		}
		while (this.RecentlyAccountList.Count >= this.MaxRecentlyAccountNumber)
		{
			this.RecentlyAccountList.RemoveAt(0);
		}
		int num = -1;
		for (int i = 0; i < this.RecentlyAccountList.Count; i++)
		{
			if (this.RecentlyAccountList[i] == name)
			{
				num = i;
				break;
			}
		}
		if (num != -1)
		{
			this.RecentlyAccountList.RemoveAt(num);
		}
		this.RecentlyAccountList.Add(name);
	}

	// Token: 0x0601027B RID: 66171 RVA: 0x0047034A File Offset: 0x0046E54A
	public void InitRecentlyAccountList()
	{
		this.RecentlyAccountList = LocalStorage.GetGlobal<List<string>>(ELocalStorageGlobalKey.RecentlyAccountList, null);
		if (this.RecentlyAccountList == null)
		{
			this.RecentlyAccountList = new List<string>();
		}
	}

	// Token: 0x0601027C RID: 66172 RVA: 0x0047036D File Offset: 0x0046E56D
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> GetRecentlyAccountList()
	{
		return this.RecentlyAccountList;
	}

	// Token: 0x0601027D RID: 66173 RVA: 0x00470375 File Offset: 0x0046E575
	public void SaveRecentlyAccountList()
	{
		if (this.RecentlyAccountList != null)
		{
			LocalStorage.SetGlobal<List<string>>(ELocalStorageGlobalKey.RecentlyAccountList, this.RecentlyAccountList);
		}
	}

	// Token: 0x1700136E RID: 4974
	// (get) Token: 0x0601027E RID: 66174 RVA: 0x0047038D File Offset: 0x0046E58D
	// (set) Token: 0x0601027F RID: 66175 RVA: 0x00470395 File Offset: 0x0046E595
	public string LoginTraceId
	{
		get
		{
			return this.LoginTraceIdInternal;
		}
		set
		{
			this.LoginTraceIdInternal = value;
			Singleton<NetInfo>.Instance.LoginTraceId = value;
		}
	}

	// Token: 0x06010280 RID: 66176 RVA: 0x004703A9 File Offset: 0x0046E5A9
	public void CreateLoginPromise()
	{
		this.LoginPromiseInternal = new CustomPromise();
	}

	// Token: 0x06010281 RID: 66177 RVA: 0x004703B6 File Offset: 0x0046E5B6
	public void FinishLoginPromise()
	{
		CustomPromise loginPromiseInternal = this.LoginPromiseInternal;
		if (loginPromiseInternal == null)
		{
			return;
		}
		loginPromiseInternal.SetResult();
	}

	// Token: 0x06010282 RID: 66178 RVA: 0x004703C8 File Offset: 0x0046E5C8
	public UniTask WaitLoginPromise()
	{
		LoginModel.<WaitLoginPromise>d__189 <WaitLoginPromise>d__;
		<WaitLoginPromise>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitLoginPromise>d__.<>4__this = this;
		<WaitLoginPromise>d__.<>1__state = -1;
		<WaitLoginPromise>d__.<>t__builder.Start<LoginModel.<WaitLoginPromise>d__189>(ref <WaitLoginPromise>d__);
		return <WaitLoginPromise>d__.<>t__builder.Task;
	}

	// Token: 0x06010283 RID: 66179 RVA: 0x0047040B File Offset: 0x0046E60B
	public bool HasLoginPromise()
	{
		return this.LoginPromiseInternal != null;
	}

	// Token: 0x06010284 RID: 66180 RVA: 0x00470416 File Offset: 0x0046E616
	public void CreateAutoLoginPromise()
	{
		this.AutoLoginPromiseInternal = new CustomPromise<bool>();
	}

	// Token: 0x06010285 RID: 66181 RVA: 0x00470423 File Offset: 0x0046E623
	public void ClearAutoLoginPromise()
	{
		this.AutoLoginPromiseInternal = null;
	}

	// Token: 0x06010286 RID: 66182 RVA: 0x0047042C File Offset: 0x0046E62C
	public void FinishAutoLoginPromise(bool value)
	{
		this.AutoLoginPromiseInternal.SetResult(value);
	}

	// Token: 0x06010287 RID: 66183 RVA: 0x0047043C File Offset: 0x0046E63C
	[NullableContext(0)]
	public UniTask<bool?> WaitAutoLoginPromise()
	{
		LoginModel.<WaitAutoLoginPromise>d__195 <WaitAutoLoginPromise>d__;
		<WaitAutoLoginPromise>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool?>.Create();
		<WaitAutoLoginPromise>d__.<>4__this = this;
		<WaitAutoLoginPromise>d__.<>1__state = -1;
		<WaitAutoLoginPromise>d__.<>t__builder.Start<LoginModel.<WaitAutoLoginPromise>d__195>(ref <WaitAutoLoginPromise>d__);
		return <WaitAutoLoginPromise>d__.<>t__builder.Task;
	}

	// Token: 0x06010288 RID: 66184 RVA: 0x0047047F File Offset: 0x0046E67F
	public bool HasAutoLoginPromise()
	{
		return this.AutoLoginPromiseInternal != null;
	}

	// Token: 0x1700136F RID: 4975
	// (get) Token: 0x06010289 RID: 66185 RVA: 0x0047048A File Offset: 0x0046E68A
	// (set) Token: 0x0601028A RID: 66186 RVA: 0x00470492 File Offset: 0x0046E692
	public TimerHandle AutoLoginTimerId
	{
		get
		{
			return this.AutoLoginTimerIdInternal;
		}
		set
		{
			this.AutoLoginTimerIdInternal = value;
		}
	}

	// Token: 0x0601028B RID: 66187 RVA: 0x0047049B File Offset: 0x0046E69B
	public void ClearAutoLoginTimerId()
	{
		if (this.AutoLoginTimerId != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.AutoLoginTimerId);
			this.AutoLoginTimerId = null;
		}
	}

	// Token: 0x0601028C RID: 66188 RVA: 0x004704C0 File Offset: 0x0046E6C0
	[NullableContext(1)]
	public string GetWaterMarkPath()
	{
		string text = UKuroLauncherLibrary.GameSavedDir() + "Logs/TmpData";
		if (Singleton<Info>.Instance.IsPs5Platform())
		{
			return text.ToLower();
		}
		return text;
	}

	// Token: 0x0601028D RID: 66189 RVA: 0x004704F1 File Offset: 0x0046E6F1
	public string CpuInfo()
	{
		return this.CpuInfoInternal;
	}

	// Token: 0x0601028E RID: 66190 RVA: 0x004704F9 File Offset: 0x0046E6F9
	public string DeviceInfo()
	{
		return this.DeviceInfoInternal;
	}

	// Token: 0x0601028F RID: 66191 RVA: 0x00470501 File Offset: 0x0046E701
	public string DriverDate()
	{
		return this.DriverDateInternal;
	}

	// Token: 0x06010290 RID: 66192 RVA: 0x00470509 File Offset: 0x0046E709
	public bool HasBackToGameData()
	{
		return this.BackToGameData != null || UKuroVariableFunctionLibrary.HasStringValue("back_to_game");
	}

	// Token: 0x06010291 RID: 66193 RVA: 0x00470520 File Offset: 0x0046E720
	[NullableContext(1)]
	public unsafe bool SaveKuroVariableStringValue(string key, string jsonData)
	{
		if (!UKuroVariableFunctionLibrary.SetStringValue(key, jsonData))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Login;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "[BackToGame] SetStringValue失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("jsonData", jsonData);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		return true;
	}

	// Token: 0x06010292 RID: 66194 RVA: 0x0047058C File Offset: 0x0046E78C
	[NullableContext(1)]
	public bool SaveKuroVariableObject(string key, [Nullable(2)] UObject @object)
	{
		if (@object == null || !@object.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Login;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "[BackToGame] SaveKuroVariableObject Object无效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (!UKuroVariableFunctionLibrary.SetObject(key, @object))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Login;
			ELogAuthor author2 = ELogAuthor.YZY;
			string message2 = "[BackToGame] SetObject失败";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("key", key);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		return true;
	}

	// Token: 0x06010293 RID: 66195 RVA: 0x00470600 File Offset: 0x0046E800
	[NullableContext(1)]
	public unsafe bool SaveBackToGameData(BackToGameData data, bool reset = false)
	{
		string text = Json.Stringify<BackToGameData>(data, null);
		if (reset)
		{
			if (UKuroVariableFunctionLibrary.HasStringValue("back_to_game"))
			{
				UKuroVariableFunctionLibrary.RemoveStringValue("back_to_game");
			}
			if (UKuroVariableFunctionLibrary.HasObject("loading_widget"))
			{
				UKuroVariableFunctionLibrary.RemoveObject("loading_widget");
			}
		}
		if (data.LoadingWidget != null && data.LoadingWidget.IsValid() && !this.SaveKuroVariableObject("loading_widget", data.LoadingWidget))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Login;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[BackToGame] SetObject重复设置参数";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("backToGame", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("key", "loading_widget");
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (!this.SaveKuroVariableStringValue("back_to_game", text))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Login;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "[BackToGame] SetStringValue重复设置参数";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("backToGame", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("key", "back_to_game");
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return false;
		}
		this.BackToGameData = data;
		return true;
	}

	// Token: 0x06010294 RID: 66196 RVA: 0x00470734 File Offset: 0x0046E934
	public bool RemoveBackToGameData()
	{
		if (this.BackToGameData == null)
		{
			return true;
		}
		UKuroVariableFunctionLibrary.RemoveObject("loading_widget");
		if (!UKuroVariableFunctionLibrary.RemoveStringValue("back_to_game"))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Login;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[BackToGame] RemoveStringValue失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", "back_to_game");
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.BackToGameData = null;
		this.TryBackToGameFailCount = 0;
		Singleton<AudioSystem>.Instance.SetState("reconnect_auto_login", "not_in_auto_login", true);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.FEstimation.Enable 1", null);
		return true;
	}

	// Token: 0x06010295 RID: 66197 RVA: 0x004707C4 File Offset: 0x0046E9C4
	public BackToGameData GetBackToGameData()
	{
		if (this.BackToGameData != null)
		{
			return this.BackToGameData;
		}
		string text = string.Empty;
		string text2 = text;
		if (!UKuroVariableFunctionLibrary.GetStringValue("back_to_game", ref text2))
		{
			return null;
		}
		text = text2;
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		BackToGameData backToGameData = Json.Parse<BackToGameData>(text, null);
		UObject uobject = null;
		if (UKuroVariableFunctionLibrary.GetObject("loading_widget", ref uobject))
		{
			backToGameData.LoadingWidget = (uobject as WBP_UILoading_C);
		}
		this.BackToGameData = backToGameData;
		return this.BackToGameData;
	}

	// Token: 0x06010296 RID: 66198 RVA: 0x00470835 File Offset: 0x0046EA35
	public int BackToGameFailCount()
	{
		return this.TryBackToGameFailCount;
	}

	// Token: 0x06010297 RID: 66199 RVA: 0x0047083D File Offset: 0x0046EA3D
	public bool CheckBackToGameFailCount()
	{
		this.TryBackToGameFailCount++;
		return this.TryBackToGameFailCount <= this.TryBackToGameMaxCount;
	}

	// Token: 0x04007BD6 RID: 31702
	[Nullable(1)]
	private const string LOADING_WIDGET_KEY = "loading_widget";

	// Token: 0x04007BD7 RID: 31703
	[Nullable(1)]
	private const string BACK_TO_GAME_KEY = "back_to_game";

	// Token: 0x04007BD8 RID: 31704
	[Nullable(1)]
	public const string STREAM = "Stream";

	// Token: 0x04007BD9 RID: 31705
	[Nullable(1)]
	public const string STREAM_MAINLINE = "mainline";

	// Token: 0x04007BDA RID: 31706
	[Nullable(1)]
	public const string DEFAULT_SERVER_IP = "127.0.0.1";

	// Token: 0x04007BDB RID: 31707
	public EBornMode BornMode = EBornMode.PlayLocationDefaultPlayerStart;

	// Token: 0x04007BDC RID: 31708
	public Aki.Protocol.Vector BornLocation;

	// Token: 0x04007BDD RID: 31709
	[Nullable(1)]
	public string Platform = string.Empty;

	// Token: 0x04007BDE RID: 31710
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<LoginMapConfig> SingleMapList;

	// Token: 0x04007BDF RID: 31711
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<LoginMapConfig> MultiMapList;

	// Token: 0x04007BE0 RID: 31712
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ServerConfig> ServerInfoList;

	// Token: 0x04007BE1 RID: 31713
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ServerData> ServerDataList;

	// Token: 0x04007BE2 RID: 31714
	private string ServerCustomPort;

	// Token: 0x04007BE3 RID: 31715
	private LoginDefine.ELoginStatus LoginStatus;

	// Token: 0x04007BE4 RID: 31716
	private LoginDefine.ELoginStatus? LastFailStatus;

	// Token: 0x04007BE5 RID: 31717
	private bool AutoOpenLoginView;

	// Token: 0x04007BE6 RID: 31718
	private ReconnectInfo ReconnectInfo;

	// Token: 0x04007BE7 RID: 31719
	[Nullable(1)]
	private string PlayerName = string.Empty;

	// Token: 0x04007BE8 RID: 31720
	private LoginDefine.ELoginSex? PlayerSex;

	// Token: 0x04007BE9 RID: 31721
	private bool HasCharacter;

	// Token: 0x04007BEA RID: 31722
	private bool IsNewAccountInternal;

	// Token: 0x04007BEB RID: 31723
	public bool SmokeTestReady;

	// Token: 0x04007BEC RID: 31724
	[Nullable(1)]
	public string CurrentIdStr = string.Empty;

	// Token: 0x04007BED RID: 31725
	public bool SdkAccountChangeNeedExitFlag;

	// Token: 0x04007BEE RID: 31726
	[Nullable(1)]
	public string ThirdGameAutoLoginId = "-1";

	// Token: 0x04007BEF RID: 31727
	private int RpcInc;

	// Token: 0x04007BF0 RID: 31728
	[Nullable(1)]
	private readonly Dictionary<int, TimerHandle> HttpRpcMap = new Dictionary<int, TimerHandle>();

	// Token: 0x04007BF1 RID: 31729
	private SdkLoginConfig SdkLoginConfig;

	// Token: 0x04007BF2 RID: 31730
	private SdkLoginConfig LoginToGameServerSdkLoginConfig;

	// Token: 0x04007BF3 RID: 31731
	private bool IfFirstTimeLogin;

	// Token: 0x04007BF4 RID: 31732
	private double CreatePlayerTime;

	// Token: 0x04007BF5 RID: 31733
	private int CreatePlayerId;

	// Token: 0x04007BF6 RID: 31734
	private string ServerIp;

	// Token: 0x04007BF7 RID: 31735
	private string ServerName;

	// Token: 0x04007BF8 RID: 31736
	private string ServerId = "0";

	// Token: 0x04007BF9 RID: 31737
	private SdkLoginInfo SdkLoginInfo;

	// Token: 0x04007BFA RID: 31738
	[Nullable(1)]
	public string SdkAccessToken = string.Empty;

	// Token: 0x04007BFB RID: 31739
	public int SdkAccessTokenRunTime;

	// Token: 0x04007BFC RID: 31740
	public bool SdkAccessTokenCountingState;

	// Token: 0x04007BFD RID: 31741
	private LoginDefine.ESdkLoginState SdkLoginState;

	// Token: 0x04007BFE RID: 31742
	public LoginNotice LoginNotice;

	// Token: 0x04007BFF RID: 31743
	private int PublicJsonVersionInternal;

	// Token: 0x04007C00 RID: 31744
	private string SourceAccount;

	// Token: 0x04007C01 RID: 31745
	public bool IsCopyAccount;

	// Token: 0x04007C02 RID: 31746
	public double LoginTimeStamp;

	// Token: 0x04007C03 RID: 31747
	public double HealthTipTime;

	// Token: 0x04007C04 RID: 31748
	[Nullable(1)]
	public string SelectedUdpHost = "";

	// Token: 0x04007C05 RID: 31749
	public bool UdpHostPickByDetection;

	// Token: 0x04007C06 RID: 31750
	public int ConnectFamily;

	// Token: 0x04007C07 RID: 31751
	public int UdpPort;

	// Token: 0x04007C08 RID: 31752
	[Nullable(1)]
	public string ResolvedIp = "";

	// Token: 0x04007C09 RID: 31753
	[Nullable(1)]
	public string PingResults = "";

	// Token: 0x04007C0A RID: 31754
	private int PublicMiscVersionInternal;

	// Token: 0x04007C0B RID: 31755
	private int PublicUniverseEditorVersionInternal;

	// Token: 0x04007C0C RID: 31756
	private string LauncherVersionInternal;

	// Token: 0x04007C0D RID: 31757
	private string ResourceVersionInternal;

	// Token: 0x04007C0E RID: 31758
	private TimerHandle VerifyVersionHandleInternal;

	// Token: 0x04007C0F RID: 31759
	private LogoutNotify LogoutNotifyInternal;

	// Token: 0x04007C10 RID: 31760
	private readonly int MaxRecentlyAccountNumber = 10;

	// Token: 0x04007C11 RID: 31761
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<string> RecentlyAccountList;

	// Token: 0x04007C12 RID: 31762
	private string LoginTraceIdInternal;

	// Token: 0x04007C13 RID: 31763
	private CustomPromise LoginPromiseInternal;

	// Token: 0x04007C14 RID: 31764
	private CustomPromise<bool> AutoLoginPromiseInternal;

	// Token: 0x04007C15 RID: 31765
	public TimerHandle AutoLoginTimerIdInternal;

	// Token: 0x04007C16 RID: 31766
	private string CpuInfoInternal;

	// Token: 0x04007C17 RID: 31767
	private string DeviceInfoInternal;

	// Token: 0x04007C18 RID: 31768
	private string DriverDateInternal;

	// Token: 0x04007C19 RID: 31769
	private BackToGameData BackToGameData;

	// Token: 0x04007C1A RID: 31770
	private int TryBackToGameFailCount;

	// Token: 0x04007C1B RID: 31771
	public readonly int TryBackToGameMaxCount = 5;
}
