using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Launcher.Platform;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FAE RID: 4014
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CloudGameManager : Singleton<CloudGameManager>
{
	// Token: 0x060066D0 RID: 26320 RVA: 0x0019E6BC File Offset: 0x0019C8BC
	public unsafe CloudGameManager()
	{
		this.DeviceMargin = "";
		this.CloudGameDpiInternal = 180;
		this.DeviceScreenWidthInternal = 1920;
		this.DeviceScreenHeightInternal = 1080;
		this.ScreenWidthInternal = 1920;
		this.ScreenHeightInternal = 1080;
		this.WaitingForDbFlagFilePath = UKismetSystemLibrary.ConvertToAbsolutePath(UKuroLauncherLibrary.GameSavedDir() + "waiting_for_db.txt");
		this.WaitingForDbSavePath = UKismetSystemLibrary.ConvertToAbsolutePath(UKuroLauncherLibrary.GameSavedDir() + "SaveDownloadDone.json");
	}

	// Token: 0x170007F8 RID: 2040
	// (get) Token: 0x060066D1 RID: 26321 RVA: 0x0019E775 File Offset: 0x0019C975
	public bool IsCloudGame
	{
		get
		{
			return Singleton<Platform>.Instance.IsCloudGame();
		}
	}

	// Token: 0x170007F9 RID: 2041
	// (get) Token: 0x060066D2 RID: 26322 RVA: 0x0019E781 File Offset: 0x0019C981
	public bool IsWebPlatform
	{
		get
		{
			return this.IsWeb;
		}
	}

	// Token: 0x170007FA RID: 2042
	// (get) Token: 0x060066D3 RID: 26323 RVA: 0x0019E789 File Offset: 0x0019C989
	public string CloudGameTraceId
	{
		get
		{
			ICloudGameUserInfo userInfo = this.UserInfo;
			return ((userInfo != null) ? userInfo.TraceId : null) ?? "";
		}
	}

	// Token: 0x170007FB RID: 2043
	// (get) Token: 0x060066D4 RID: 26324 RVA: 0x0019E7A6 File Offset: 0x0019C9A6
	// (set) Token: 0x060066D5 RID: 26325 RVA: 0x0019E7B0 File Offset: 0x0019C9B0
	public ICloudGameUserInfo CloudUserInfo
	{
		get
		{
			return this.UserInfo;
		}
		set
		{
			this.UserInfo = value;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CloudGame;
			ELogAuthor author = ELogAuthor.TL;
			string message = "设置云游戏userInfo";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("userInfo", value);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x060066D6 RID: 26326 RVA: 0x0019E7EE File Offset: 0x0019C9EE
	public ILoginInfo GetCloudGameLoginInfo()
	{
		return this.UserInfo.LoginInfo;
	}

	// Token: 0x170007FC RID: 2044
	// (get) Token: 0x060066D7 RID: 26327 RVA: 0x0019E7FB File Offset: 0x0019C9FB
	[Nullable(2)]
	public ICloudGamePadInfo CloudGamePadInfo
	{
		[NullableContext(2)]
		get
		{
			return this.CloudGamePadInfoInternal;
		}
	}

	// Token: 0x170007FD RID: 2045
	// (get) Token: 0x060066D8 RID: 26328 RVA: 0x0019E803 File Offset: 0x0019CA03
	public int CloudGameDpi
	{
		get
		{
			return this.CloudGameDpiInternal;
		}
	}

	// Token: 0x170007FE RID: 2046
	// (get) Token: 0x060066D9 RID: 26329 RVA: 0x0019E80B File Offset: 0x0019CA0B
	public int DeviceScreenWidth
	{
		get
		{
			return this.DeviceScreenWidthInternal;
		}
	}

	// Token: 0x170007FF RID: 2047
	// (get) Token: 0x060066DA RID: 26330 RVA: 0x0019E813 File Offset: 0x0019CA13
	public int DeviceScreenHeight
	{
		get
		{
			return this.DeviceScreenHeightInternal;
		}
	}

	// Token: 0x17000800 RID: 2048
	// (get) Token: 0x060066DB RID: 26331 RVA: 0x0019E81B File Offset: 0x0019CA1B
	public int ScreenWidth
	{
		get
		{
			return this.ScreenWidthInternal;
		}
	}

	// Token: 0x17000801 RID: 2049
	// (get) Token: 0x060066DC RID: 26332 RVA: 0x0019E823 File Offset: 0x0019CA23
	public int ScreenHeight
	{
		get
		{
			return this.ScreenHeightInternal;
		}
	}

	// Token: 0x060066DD RID: 26333 RVA: 0x0019E82C File Offset: 0x0019CA2C
	public void Init()
	{
		string commandLine = UKismetSystemLibrary.GetCommandLine();
		this.IsReboot = commandLine.Contains("-Reboot");
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.TL;
		string message = "云游戏初始化";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("IsReboot", this.IsReboot);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (!this.IsCloudGame)
		{
			return;
		}
		UPerfSightHelper.PostEvent(601, "1");
		UKuroCloudGameWrapper ukuroCloudGameWrapper = new UKuroCloudGameWrapper();
		this.KuroCloudGameWrapper = ukuroCloudGameWrapper;
		ukuroCloudGameWrapper.CloudGameOnReceiveDataDelegate.Bind(new Action<string>(this.OnReceiveData));
		ukuroCloudGameWrapper.CloudGameOnReceiveDataWithKeyDelegate.Bind(new Action<string, string>(this.OnReceiveDataWithKey));
		ukuroCloudGameWrapper.CloudGameOnChangeResolutionDelegate.Bind(this.OnResolutionChange);
		this.BindFunction(ECloudGameReceiveDataKey.OnGamePadDeviceChange, new TCloudGameOnReceiveDataFunction(this.OnGamePadDeviceChange));
		if (Singleton<CloudGameManagerLauncher>.Instance.IsPreLaunch)
		{
			this.BindFunction(ECloudGameReceiveDataKey.OnCloudGameLoginPreLaunch, new TCloudGameOnReceiveDataFunction(this.OnUserLoginPreLaunch));
			this.BindFunction(ECloudGameReceiveDataKey.SetIsWebPlatform, new TCloudGameOnReceiveDataFunction(this.OnSetWebPlatform));
		}
		else
		{
			this.ParseCommandLine();
			this.BindFunction(ECloudGameReceiveDataKey.OnCloudGameLogin, new TCloudGameOnReceiveDataFunction(this.OnUserLogin));
		}
		this.InitSettings();
	}

	// Token: 0x060066DE RID: 26334 RVA: 0x0019E950 File Offset: 0x0019CB50
	private void InitCloudGamePlatform(string platform)
	{
		Singleton<Platform>.Instance.CloudGamePlatform = platform;
		if (platform == "Android" || platform == "IOS")
		{
			Singleton<Info>.Instance.SwitchInputControllerType(EInputControllerType.Touch, "InitCloudGame Mobile");
		}
		else if (platform == "Mac" || platform == "Windows")
		{
			Singleton<Info>.Instance.SwitchInputControllerType(EInputControllerType.Keyboard, "InitCloudGame Desktop");
		}
		this.TryRequestGamePadDevice();
	}

	// Token: 0x060066DF RID: 26335 RVA: 0x0019E9C4 File Offset: 0x0019CBC4
	private void InitSettings()
	{
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "wp.Runtime.OverrideMultipleRuntimeGridNames Grid_Near&Grid_Middle&Grid_Middle_Far&Grid_Far&Grid_SuperFar&Grid_SSuperFar&Grid_HLOD_Small&Grid_HLOD_Middle&Grid_HLOD&Grid_HLOD_Volume_Small&Grid_HLOD_Volume_Middle&Grid_HLOD_Volume&GridRuntime_Landscape&GridRuntime_LandscapeHLOD&Grid_Water&Grid_Impostor&Grid_ExtremeFarFoliage&Grid_Foliage_Normal&Grid_ISM_Near&Grid_ISM_Middle&Grid_ISM_Far&Grid_ISM_SuperFar&Grid_Foliage_Near&Grid_Foliage_Grass&Grid_Foliage_Middle&Grid_Foliage_Far&Grid_Foliage_SuperFar&Grid_ReverseMiddle&Grid_ReverseFar&Grid_ReverseSuperFar&Grid_SSuperFarReverse&Grid_EnclosedSpaceNear&Grid_EnclosedSpaceMiddle&Grid_EnclosedSpaceFar&Grid_EnclosedSpaceSuperFar&Grid_EnclosedSpaceSSuperFar&Grid_AudioNear&Grid_AudioMiddle&Grid_AudioFar&Grid_AudioSuperFar&Grid_PcgWater&Grid_Light_Middle&Grid_Light_Far&Grid_HighResLandscape&Grid_MSuperFar&HLOD0_200m_300m&HLOD0_300m_500m&HLOD1_400m_800m&HLOD0_500m_1000m&HLOD0_500m_1500m&HLOD1_600m_1200m&HLOD1_800m_2500m&HLOD1_800m_4000m", null);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "wp.Runtime.OverrideMultipleRuntimeGridLoadingRangeValues 60&85&200&180&650&2600&100&140&170&100&190&250&440&3500&610&450&1300&274&60&83&100&150&40&80&100&100&196&260&430&860&2600&50&80&130&650&860&40&80&252&86&440&120&156&300&1300&260&430&690&860&1300&1040&2160&3460", null);
	}

	// Token: 0x060066E0 RID: 26336 RVA: 0x0019E9E8 File Offset: 0x0019CBE8
	private void OnReceiveData(string dataJson)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.TL;
		string message = "OnReceiveData:";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", dataJson);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ECloudGameReceiveDataKey key;
		if (!Enum.TryParse<ECloudGameReceiveDataKey>(dataJson, out key) || !this.FunctionLookup.ContainsKey(key))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.CloudGame;
			ELogAuthor author2 = ELogAuthor.TL;
			string message2 = "OnReceiveData: 函数未绑定";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("key", dataJson);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		this.FunctionLookup[key](dataJson);
	}

	// Token: 0x060066E1 RID: 26337 RVA: 0x0019EA74 File Offset: 0x0019CC74
	private unsafe void OnReceiveDataWithKey(string key, string data)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.TL;
		string message = "OnReceiveDataWithKey:";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", key);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("data", data);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		ECloudGameReceiveDataKey key2;
		if (!Enum.TryParse<ECloudGameReceiveDataKey>(key, out key2) || !this.FunctionLookup.ContainsKey(key2))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.CloudGame;
			ELogAuthor author2 = ELogAuthor.TL;
			string message2 = "OnReceiveDataWithKey: 函数未绑定";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("key", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("data", data);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		this.FunctionLookup[key2](data);
	}

	// Token: 0x060066E2 RID: 26338 RVA: 0x0019EB58 File Offset: 0x0019CD58
	public void BindFunction(ECloudGameReceiveDataKey key, TCloudGameOnReceiveDataFunction func)
	{
		this.FunctionLookup[key] = func;
	}

	// Token: 0x060066E3 RID: 26339 RVA: 0x0019EB67 File Offset: 0x0019CD67
	public void UnBindFunction(ECloudGameReceiveDataKey key)
	{
		this.FunctionLookup.Remove(key);
	}

	// Token: 0x060066E4 RID: 26340 RVA: 0x0019EB78 File Offset: 0x0019CD78
	public void SendData(ECloudGameSendData data)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.TL;
		string message = "SendData";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("data", data);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		UKuroCloudGameWrapper.SendDataToPipeBinary(data.ToString());
	}

	// Token: 0x060066E5 RID: 26341 RVA: 0x0019EBC8 File Offset: 0x0019CDC8
	public unsafe void SendDataByKey(ECloudGameSendData key, string data)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.TL;
		string message = "SendDataByKey";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", key);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("data", data);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		UKuroCloudGameWrapper.SendDataToPipeBinaryWithKey(key.ToString(), data);
	}

	// Token: 0x060066E6 RID: 26342 RVA: 0x0019EC43 File Offset: 0x0019CE43
	public void TryRequestGamePadDevice()
	{
		if (!this.IsCloudGame)
		{
			return;
		}
		this.SendData(ECloudGameSendData.RequestGamePadDevice);
	}

	// Token: 0x060066E7 RID: 26343 RVA: 0x0019EC58 File Offset: 0x0019CE58
	public void OnGamePadDeviceChange(string gamePadJson)
	{
		CloudGamePadInfo cloudGamePadInfo = Json.Decode<CloudGamePadInfo>(gamePadJson, null);
		if (cloudGamePadInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.CloudGame, ELogAuthor.TL, "OnGamePadDeviceChange error, gamePadInfo parse fail", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		bool flag = cloudGamePadInfo.IsConnectPad == 1;
		if (flag)
		{
			this.CloudGamePadInfoInternal = cloudGamePadInfo;
		}
		else
		{
			this.CloudGamePadInfoInternal = null;
		}
		Singleton<EventSystem>.Instance.Emit<bool, int, int>(EEventName.ControllerConnectChange, flag, cloudGamePadInfo.ProductId, cloudGamePadInfo.VendorId);
	}

	// Token: 0x060066E8 RID: 26344 RVA: 0x0019ECCC File Offset: 0x0019CECC
	public void ExitGame(string str)
	{
		string data = Json.Encode(new ExitGameInfo
		{
			Content = str
		}, null);
		this.SendDataByKey(ECloudGameSendData.ExitGame, data);
	}

	// Token: 0x060066E9 RID: 26345 RVA: 0x0019ECF8 File Offset: 0x0019CEF8
	public unsafe void ParseCommandLine()
	{
		string commandLine = UKismetSystemLibrary.GetCommandLine();
		Match match = CloudGameDefine.CloudGameDeviceRegex.Match(commandLine);
		if (match.Success)
		{
			this.DeviceMargin = match.Groups[1].Value;
		}
		Match match2 = CloudGameDefine.CloudGameDpiRegex.Match(commandLine);
		if (match2.Success)
		{
			this.CloudGameDpiInternal = int.Parse(match2.Groups[1].Value);
		}
		Match match3 = CloudGameDefine.CloudGameDeviceScreenResolution.Match(commandLine);
		if (match3.Success)
		{
			this.DeviceScreenWidthInternal = int.Parse(match3.Groups[1].Value);
			this.DeviceScreenHeightInternal = int.Parse(match3.Groups[2].Value);
		}
		Match match4 = CloudGameDefine.CloudGameScreenResolution.Match(commandLine);
		if (match4.Success)
		{
			this.ScreenWidthInternal = int.Parse(match4.Groups[1].Value);
			this.ScreenHeightInternal = int.Parse(match4.Groups[2].Value);
		}
		Match match5 = CloudGameDefine.CloudGameIsWeb.Match(commandLine);
		if (match5.Success)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CloudGame;
			ELogAuthor author = ELogAuthor.TL;
			string message = "isWebMatch";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", match5.Groups[1].Value);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (match5.Groups[1].Value != "%d")
			{
				this.IsWeb = (match5.Groups[1].Value == "1");
			}
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.CloudGame;
		ELogAuthor author2 = ELogAuthor.TL;
		string message2 = "初始化云游戏平台类型";
		<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("-CloudGame", this.IsCloudGame);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("-Device", this.DeviceMargin);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("-Dpi", this.CloudGameDpiInternal);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("-DeviceScreenWidth", this.DeviceScreenWidthInternal);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("-DeviceScreenHeight", this.DeviceScreenHeightInternal);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("-IsWeb", this.IsWeb);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
	}

	// Token: 0x060066EA RID: 26346 RVA: 0x0019EF80 File Offset: 0x0019D180
	public void OnUserLogin(string loginInfoJson)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.TL;
		string message = "OnUserLogin";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("loginInfoJson", loginInfoJson);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		CloudGameUserInfoLegacy cloudGameUserInfoLegacy = Json.Decode<CloudGameUserInfoLegacy>(loginInfoJson, null);
		if (cloudGameUserInfoLegacy == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.CloudGame, ELogAuthor.TL, "OnUserLogin error, userInfo parse fail", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		LoginInfo loginInfo = new LoginInfo
		{
			LoginCode = cloudGameUserInfoLegacy.LoginCode,
			Uid = cloudGameUserInfoLegacy.Uid,
			UserName = cloudGameUserInfoLegacy.UserName,
			Token = cloudGameUserInfoLegacy.Token
		};
		CloudGameUserInfo cloudGameUserInfo = new CloudGameUserInfo
		{
			LoginInfo = loginInfo,
			TraceId = "",
			Platform = Singleton<Platform>.Instance.CloudGamePlatform,
			Fps = 0,
			Dpi = 0,
			DeviceResolution = new ResolutionInfo
			{
				Width = 0,
				Height = 0
			},
			ScreenResolution = new ResolutionInfo
			{
				Width = 0,
				Height = 0
			},
			ServerTag = "",
			Device = ""
		};
		this.CloudUserInfo = cloudGameUserInfo;
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.CloudGame;
		ELogAuthor author2 = ELogAuthor.TL;
		string message2 = "OnUserLogin";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("CloudUserInfo", cloudGameUserInfo);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		this.InitCloudGamePlatform(Singleton<Platform>.Instance.CloudGamePlatform);
		ControllerBase<LoginController>.Instance.OnSdkLogin(this.GetCloudGameLoginInfo());
	}

	// Token: 0x060066EB RID: 26347 RVA: 0x0019F0E8 File Offset: 0x0019D2E8
	public void OnSetWebPlatform(string isWeb)
	{
		this.IsWeb = (isWeb == "1");
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.TL;
		string message = "OnSetWebPlatform";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("IsWeb", isWeb);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x060066EC RID: 26348 RVA: 0x0019F130 File Offset: 0x0019D330
	public unsafe void OnUserLoginPreLaunch(string loginInfoJson)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.TL;
		string message = "OnUserLoginPreLaunch 1";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("loginInfoJson", loginInfoJson);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (this.WaitingForUserDb == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.CloudGame, ELogAuthor.TL, "OnUserLoginPreLaunch error, not waiting", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		CloudGameUserInfo cloudGameUserInfo = Json.Decode<CloudGameUserInfo>(loginInfoJson, null);
		if (cloudGameUserInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.CloudGame, ELogAuthor.TL, "OnUserLoginPreLaunch error, userInfo parse fail", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.CloudUserInfo = cloudGameUserInfo;
		this.InitCloudGamePlatform(cloudGameUserInfo.Platform);
		this.DeviceMargin = cloudGameUserInfo.Device;
		this.CloudGameDpiInternal = cloudGameUserInfo.Dpi;
		this.DeviceScreenWidthInternal = cloudGameUserInfo.DeviceResolution.Width;
		this.DeviceScreenHeightInternal = cloudGameUserInfo.DeviceResolution.Height;
		this.ScreenWidthInternal = cloudGameUserInfo.ScreenResolution.Width;
		this.ScreenHeightInternal = cloudGameUserInfo.ScreenResolution.Height;
		UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
		gameUserSettings.SetScreenResolution(new FIntPoint(this.ScreenWidth, this.ScreenHeight));
		gameUserSettings.ApplySettings(true);
		if (this.IsRefreshLogin)
		{
			this.IsRefreshLogin = false;
			CustomPromise waitingForUserDb = this.WaitingForUserDb;
			if (waitingForUserDb != null)
			{
				waitingForUserDb.SetResult();
			}
			this.WaitingForUserDb = null;
			Singleton<Log>.Instance.Info(ELogModule.CloudGame, ELogAuthor.CWC, "OnUserLoginPreLaunch RefreshLogin Done", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (UBlueprintPathsLibrary.FileExists(this.WaitingForDbFlagFilePath))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.CloudGame;
			ELogAuthor author2 = ELogAuthor.TL;
			string message2 = "OnUserLoginPreLaunch delete file";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("WaitingForDbFlagFilePath", this.WaitingForDbFlagFilePath);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			UKuroLauncherLibrary.DeleteFile(this.WaitingForDbFlagFilePath);
		}
		ControllerBase<ResetTimeController>.GetOrCreateInstance().ResetTime();
		Singleton<LoadModeManager>.Instance.SetLoadModeByReason(ELoadMode.Loading, ELoadModeReason.GameProcedureOnStart);
		int tryTimes = 0;
		this.TimeoutTimer = TimerSystem.Instance.Forever(delegate(float _)
		{
			int tryTimes = tryTimes;
			tryTimes++;
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.CloudGame;
			ELogAuthor author3 = ELogAuthor.TL;
			string message3 = "OnUserLoginPreLaunch Wait DB replaced";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("tryTimes", tryTimes);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			bool flag = UBlueprintPathsLibrary.FileExists(this.WaitingForDbSavePath);
			if (flag || tryTimes >= 10)
			{
				if (this.TimeoutTimer != null)
				{
					TimerSystem.Instance.Remove(this.TimeoutTimer);
					this.TimeoutTimer = null;
				}
				CustomPromise waitingForUserDb2 = this.WaitingForUserDb;
				if (waitingForUserDb2 != null)
				{
					waitingForUserDb2.SetResult();
				}
				this.WaitingForUserDb = null;
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.CloudGame;
				ELogAuthor author4 = ELogAuthor.TL;
				string message4 = "OnUserLoginPreLaunch Done";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("replaced", flag);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("tryTimes", tryTimes);
				instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}, 500f, 1f, null, null, true);
	}

	// Token: 0x060066ED RID: 26349 RVA: 0x0019F330 File Offset: 0x0019D530
	private void OnWaitingForUser()
	{
		if (this.WaitingForUserDb == null)
		{
			this.WaitingForUserDb = new CustomPromise();
		}
		UKuroStaticLibrary.SaveStringToFile("OnWaitingForUser", this.WaitingForDbFlagFilePath, false);
		Singleton<LoadModeManager>.Instance.ResetLoadModeByReason(ELoadModeReason.GameProcedureOnStart);
		this.SendData(ECloudGameSendData.RequestLoginPreLaunch);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.TL;
		string message = "OnWaitingForUser save file";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("WaitingForDbFlagFilePath", this.WaitingForDbFlagFilePath);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x060066EE RID: 26350 RVA: 0x0019F3A4 File Offset: 0x0019D5A4
	public UniTask WaitForUser()
	{
		CloudGameManager.<WaitForUser>d__58 <WaitForUser>d__;
		<WaitForUser>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitForUser>d__.<>4__this = this;
		<WaitForUser>d__.<>1__state = -1;
		<WaitForUser>d__.<>t__builder.Start<CloudGameManager.<WaitForUser>d__58>(ref <WaitForUser>d__);
		return <WaitForUser>d__.<>t__builder.Task;
	}

	// Token: 0x060066EF RID: 26351 RVA: 0x0019F3E8 File Offset: 0x0019D5E8
	public void RequestRefreshLogin()
	{
		Singleton<Log>.Instance.Info(ELogModule.CloudGame, ELogAuthor.CWC, "RequestRefreshLogin", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.IsRefreshLogin = true;
		if (this.WaitingForUserDb == null)
		{
			this.WaitingForUserDb = new CustomPromise();
		}
		this.SendData(ECloudGameSendData.RequestLoginPreLaunch);
	}

	// Token: 0x060066F0 RID: 26352 RVA: 0x0019F438 File Offset: 0x0019D638
	public unsafe IReadOnlyList<float> GetCloudGameSafeZone()
	{
		if (!this.IsCloudGame)
		{
			return CloudGameDefine.DefaultDeviceMargin;
		}
		IReadOnlyList<float> readOnlyList = CloudGameDefine.DefaultDeviceMargin;
		if (CloudGameDefine.DeviceMarginMap.ContainsKey(this.DeviceMargin))
		{
			readOnlyList = CloudGameDefine.DeviceMarginMap[this.DeviceMargin];
		}
		if (readOnlyList == null || readOnlyList.Count < 4)
		{
			return CloudGameDefine.DefaultDeviceMargin;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.TL;
		string message = "设置UiSafeZone";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("left", readOnlyList[0]);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("top", readOnlyList[2]);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("right", readOnlyList[1]);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("bottom", readOnlyList[3]);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		return readOnlyList;
	}

	// Token: 0x040030FA RID: 12538
	[Nullable(2)]
	public UKuroCloudGameWrapper KuroCloudGameWrapper;

	// Token: 0x040030FB RID: 12539
	private readonly Dictionary<ECloudGameReceiveDataKey, TCloudGameOnReceiveDataFunction> FunctionLookup = new Dictionary<ECloudGameReceiveDataKey, TCloudGameOnReceiveDataFunction>();

	// Token: 0x040030FC RID: 12540
	[Nullable(2)]
	private ICloudGameUserInfo UserInfo;

	// Token: 0x040030FD RID: 12541
	[Nullable(2)]
	private ICloudGamePadInfo CloudGamePadInfoInternal;

	// Token: 0x040030FE RID: 12542
	private string DeviceMargin;

	// Token: 0x040030FF RID: 12543
	private int CloudGameDpiInternal;

	// Token: 0x04003100 RID: 12544
	private bool IsReboot;

	// Token: 0x04003101 RID: 12545
	private bool IsWeb;

	// Token: 0x04003102 RID: 12546
	[Nullable(2)]
	private CustomPromise WaitingForUserDb;

	// Token: 0x04003103 RID: 12547
	private bool IsRefreshLogin;

	// Token: 0x04003104 RID: 12548
	private readonly string WaitingForDbFlagFilePath;

	// Token: 0x04003105 RID: 12549
	private readonly string WaitingForDbSavePath;

	// Token: 0x04003106 RID: 12550
	private int DeviceScreenWidthInternal;

	// Token: 0x04003107 RID: 12551
	private int DeviceScreenHeightInternal;

	// Token: 0x04003108 RID: 12552
	private int ScreenWidthInternal;

	// Token: 0x04003109 RID: 12553
	private int ScreenHeightInternal;

	// Token: 0x0400310A RID: 12554
	[Nullable(2)]
	private TimerHandle TimeoutTimer;

	// Token: 0x0400310B RID: 12555
	private readonly Action<int, int> OnResolutionChange = delegate(int width, int height)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.TL;
		string message = "OnResolutionChange:";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("width", width);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("height", height);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		FIntPoint screenResolution = new FIntPoint(width, height);
		UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
		gameUserSettings.SetScreenResolution(screenResolution);
		gameUserSettings.ApplySettings(true);
	};
}
