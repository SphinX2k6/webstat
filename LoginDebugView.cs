using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Update;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001B2D RID: 6957
[NullableContext(1)]
[Nullable(0)]
public class LoginDebugView : UiViewBase
{
	// Token: 0x0600C889 RID: 51337 RVA: 0x003513E5 File Offset: 0x0034F5E5
	public LoginDebugView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C88A RID: 51338 RVA: 0x003513F8 File Offset: 0x0034F5F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 21;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITextInputComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIDropdownComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIDropdownComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITextInputComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUITextInputComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIDropdownComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIDropdownComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITextInputComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUITextInputComponent));
		this.ComponentRegisterInfos = list;
		num2 = 8;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.QuitBtnClickCallBack));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.LoginBtnClickCallBack));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.QuickLoginUseNewBtnClickCallBack));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.QuickLoginUseCurBtnClickCallBack));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action<EToggleState>(this.ToggleStateChange));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action<EToggleState>(this.CloudToggleChanged));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(11, new Action<EToggleState>(this.SkipPlotToggle));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(18, new Action<EToggleState>(this.OnClickUseCopySourceAccountToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C88B RID: 51339 RVA: 0x00351818 File Offset: 0x0034FA18
	protected override void OnStart()
	{
		this.IcmpPingCallBack = global::DelegateUtils.ToManualReleaseDelegate<FPingCallExDelegate>(new Action<string, float, int>(this.IcmpCallBack));
		this.IcmpPingCallBack.Bind(new Action<string, float, int>(this.IcmpCallBack));
		ModelBase<LoginModel>.Instance.InitConfig();
		ModelBase<LoginModel>.Instance.FixLoginFailInfo();
		ModelBase<LoginModel>.Instance.InitRecentlyAccountList();
		UUIExtendToggle extendToggle = base.GetExtendToggle(18);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		UUIItem item = base.GetItem(19);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.OrigiMapData = new TArray<FUIDropdownOptionData>();
		this.ToShowMapData = new TArray<FUIDropdownOptionData>();
		base.GetInputText(13).OnTextChange.Bind(new Action<string>(this.SearchMap));
		base.GetDropdown(3).OnSelectChange.Bind(new Action<int>(this.OnSelectServer));
		this.RefreshServerIpInputText();
		base.GetInputText(2).SetText(ModelBase<LoginModel>.Instance.GetAccount(), false);
		this.HttpLogin();
	}

	// Token: 0x0600C88C RID: 51340 RVA: 0x00351914 File Offset: 0x0034FB14
	private void OnHttpLoginInit()
	{
		this.InitServer();
		this.InitMap();
		this.InitSex();
		this.InitCloud();
		this.InitSkip();
		if (GlobalData.IsPlayInEditor && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.LoginStatusView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.LoginStatusView, null, null);
		}
		this.InitGmCountDropDown();
		this.InitRecentlyAccountDropDown();
		ModelBase<LoginModel>.Instance.SmokeTestReady = true;
	}

	// Token: 0x0600C88D RID: 51341 RVA: 0x00351980 File Offset: 0x0034FB80
	private unsafe void InitServer()
	{
		UUIDropdownComponent dropdown = base.GetDropdown(3);
		if (dropdown != null)
		{
			ULGUISpriteData_BaseObject sprite = dropdown.GetOption(0).Sprite;
			dropdown.Options.Empty(true);
			List<ServerConfig> serverInfoList = ModelBase<LoginModel>.Instance.GetServerInfoList();
			string serverIp = this.GetServerIp();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Login;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "debug 登录信息";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("serverIp", serverIp);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("serverInfoList", serverInfoList);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			bool flag = false;
			if (serverInfoList != null)
			{
				for (int i = 0; i < serverInfoList.Count; i++)
				{
					ServerConfig serverConfig = serverInfoList[i];
					dropdown.Options.Add(new FUIDropdownOptionData(serverConfig.Name, sprite, 0, ""));
					if (serverConfig.Ip == serverIp)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Login;
						ELogAuthor author2 = ELogAuthor.XXJ;
						string message2 = "设置服务器下拉列表";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Value", i);
						instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						dropdown.Value = i;
						dropdown.CaptionText.Get().UIText.SetText(serverConfig.Name, true);
						this.RefreshServerIpInputText();
						flag = true;
					}
				}
			}
			if (!flag && serverInfoList != null && serverInfoList.Count > 0)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Login;
				ELogAuthor author3 = ELogAuthor.XXJ;
				string message3 = "设置服务器下拉列表";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Value", 0);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				dropdown.Value = 0;
				ServerConfig serverConfig2 = serverInfoList[0];
				dropdown.CaptionText.Get().UIText.SetText(serverConfig2.Name, true);
			}
		}
	}

	// Token: 0x0600C88E RID: 51342 RVA: 0x00351B4C File Offset: 0x0034FD4C
	private void RefreshServerIpInputText()
	{
		string text = this.GetServerIp() ?? "";
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.LRX;
		string message = "设置服务器IP";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ServerIp", text);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		base.GetInputText(14).SetText(text, false);
	}

	// Token: 0x0600C88F RID: 51343 RVA: 0x00351BA0 File Offset: 0x0034FDA0
	private void InitMap()
	{
		UUIDropdownComponent dropdown = base.GetDropdown(4);
		if (dropdown != null)
		{
			ULGUISpriteData_BaseObject sprite = dropdown.GetOption(0).Sprite;
			dropdown.Options.Empty(true);
			List<LoginMapConfig> singleMapList = ModelBase<LoginModel>.Instance.GetSingleMapList();
			int singleMapId = ModelBase<LoginModel>.Instance.GetSingleMapId();
			int? defaultSingleMapId = ConfigBase<LoginConfig>.Instance.GetDefaultSingleMapId();
			int? num = null;
			bool flag = false;
			if (singleMapList != null)
			{
				for (int i = 0; i < singleMapList.Count; i++)
				{
					LoginMapConfig loginMapConfig = singleMapList[i];
					string text = loginMapConfig.MapId.ToString() + "-" + loginMapConfig.MapName;
					FUIDropdownOptionData value = new FUIDropdownOptionData(text, sprite, 0, "");
					this.OrigiMapData.Add(value);
					dropdown.Options.Add(value);
					if (loginMapConfig.MapId == singleMapId)
					{
						dropdown.Value = i;
						dropdown.CaptionText.Get().UIText.SetText(text, true);
						flag = true;
					}
					int mapId = loginMapConfig.MapId;
					int? num2 = defaultSingleMapId;
					if (mapId == num2.GetValueOrDefault() & num2 != null)
					{
						num = new int?(i);
					}
				}
			}
			if (!flag)
			{
				int valueOrDefault = num.GetValueOrDefault();
				if (singleMapList != null && singleMapList.Count > valueOrDefault)
				{
					dropdown.Value = valueOrDefault;
					LoginMapConfig loginMapConfig2 = singleMapList[valueOrDefault];
					string newText = loginMapConfig2.MapId.ToString() + "-" + loginMapConfig2.MapName;
					dropdown.CaptionText.Get().UIText.SetText(newText, true);
				}
			}
		}
	}

	// Token: 0x0600C890 RID: 51344 RVA: 0x00351D34 File Offset: 0x0034FF34
	private void InitSex()
	{
		if (base.GetExtendToggle(7) != null)
		{
			EToggleState state = LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.LoginSex, true) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(7).SetToggleState(state, false, false, false);
			this.ToggleStateChange(state);
		}
	}

	// Token: 0x0600C891 RID: 51345 RVA: 0x00351D70 File Offset: 0x0034FF70
	private void InitCloud()
	{
		if (base.GetExtendToggle(9) != null)
		{
			EToggleState state = EToggleState.ETT_UnChecked;
			base.GetExtendToggle(9).SetToggleState(state, false, false, false);
			this.CloudToggleChanged(state);
		}
	}

	// Token: 0x0600C892 RID: 51346 RVA: 0x00351DA4 File Offset: 0x0034FFA4
	private void InitSkip()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(11);
		if (extendToggle != null)
		{
			EToggleState state = LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.SkipPlot, false) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			extendToggle.SetToggleState(state, false, false, false);
			this.SkipPlotToggle(state);
			extendToggle.GetRootComponent().SetUIActive(false);
		}
	}

	// Token: 0x0600C893 RID: 51347 RVA: 0x00351DEC File Offset: 0x0034FFEC
	protected override void OnBeforeDestroy()
	{
		if (this.IcmpPingCallBack != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<string, float, int>(this.IcmpCallBack));
			this.IcmpPingCallBack = null;
		}
		base.GetDropdown(15).OnSelectChange.Unbind();
		ModelBase<LoginModel>.Instance.SaveRecentlyAccountList();
		ModelBase<LoginModel>.Instance.CleanConfig();
		ModelBase<LoginModel>.Instance.SetServerId(base.GetInputText(20).GetText());
	}

	// Token: 0x0600C894 RID: 51348 RVA: 0x00351E58 File Offset: 0x00350058
	private void InitRecentlyAccountDropDown()
	{
		UUIDropdownComponent dropdown = base.GetDropdown(16);
		if (dropdown == null)
		{
			return;
		}
		dropdown.CaptionText.Get().UIText.SetText("选择最近登录账号", true);
		ULGUISpriteData_BaseObject sprite = dropdown.GetOption(0).Sprite;
		dropdown.Options.Empty(true);
		List<string> recentlyAccountList = ModelBase<LoginModel>.Instance.GetRecentlyAccountList();
		if (recentlyAccountList != null)
		{
			foreach (string textOrConfigTableName in recentlyAccountList)
			{
				dropdown.Options.Add(new FUIDropdownOptionData(textOrConfigTableName, sprite, 0, ""));
			}
		}
		dropdown.OnSelectChange.Bind(new Action<int>(this.OnRecentlyAccountSelectChange));
	}

	// Token: 0x0600C895 RID: 51349 RVA: 0x00351F24 File Offset: 0x00350124
	private void InitGmCountDropDown()
	{
		UUIDropdownComponent dropdown = base.GetDropdown(15);
		if (dropdown == null)
		{
			return;
		}
		ULGUISpriteData_BaseObject sprite = dropdown.GetOption(0).Sprite;
		dropdown.Options.Empty(true);
		foreach (GmAccount gmAccount in ConfigGmAccountAll.GetConfigList(true))
		{
			dropdown.Options.Add(new FUIDropdownOptionData(gmAccount.GmName, sprite, 0, ""));
		}
		dropdown.CaptionText.Get().UIText.SetText("创建指定GM账号", true);
		dropdown.OnSelectChange.Bind(new Action<int>(this.OnGmAccountSelectChange));
	}

	// Token: 0x0600C896 RID: 51350 RVA: 0x00351FE4 File Offset: 0x003501E4
	private void CheckPakKeyAndLogin()
	{
		Singleton<PakKeyUpdate>.Instance.CheckPakKey(delegate
		{
			if (UKuroPakKeyLibrary.HasPendingEncryptedPaks() && !Singleton<BaseConfigController>.Instance.GetIosAuditFirstDownloadTipWithSkip())
			{
				Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LRA, "存在未成功挂载的Pak包！", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<LoginController>.Instance.GetAndShowStopServerNotice();
				return;
			}
			ControllerBase<LoginController>.Instance.GetHttp(true, true);
		}, null).Forget(delegate(Exception error)
		{
		}, true);
	}

	// Token: 0x0600C897 RID: 51351 RVA: 0x00352040 File Offset: 0x00350240
	private void QuitBtnClickCallBack()
	{
		ControllerBase<ReConnectController>.Instance.Logout(ELogoutReason.LoginViewQuit);
	}

	// Token: 0x0600C898 RID: 51352 RVA: 0x00352050 File Offset: 0x00350250
	private void LoginBtnClickCallBack()
	{
		if (!ModelBase<LoginModel>.Instance.IsLoginStatus(LoginDefine.ELoginStatus.Init))
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.ZJC, "正在登录中, 请勿重复操作！", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (base.GetInputText(2).Text == "")
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("LoginFailEmptyAccount", Array.Empty<object>());
			return;
		}
		this.SetLoginData();
		if (!Singleton<Platform>.Instance.IsWindowsPlatform())
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.DepthOfFieldQuality 1", null);
		}
		base.CloseMe(delegate(bool success)
		{
			if (success)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.LoginView, null, null);
			}
		});
	}

	// Token: 0x0600C899 RID: 51353 RVA: 0x003520FC File Offset: 0x003502FC
	private void QuickLoginUseCurBtnClickCallBack()
	{
		if (!ModelBase<LoginModel>.Instance.IsLoginStatus(LoginDefine.ELoginStatus.Init))
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.ZJC, "正在登录中, 请勿重复操作！", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (base.GetInputText(2).Text == "")
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("LoginFailEmptyAccount", Array.Empty<object>());
			return;
		}
		this.SetLoginData();
		if (!Singleton<Platform>.Instance.IsWindowsPlatform())
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.DepthOfFieldQuality 1", null);
		}
		ModelBase<LoginModel>.Instance.SetPlayerName("一键登录账号");
		this.CheckPakKeyAndLogin();
	}

	// Token: 0x0600C89A RID: 51354 RVA: 0x00352198 File Offset: 0x00350398
	private void QuickLoginUseNewBtnClickCallBack()
	{
		if (!ModelBase<LoginModel>.Instance.IsLoginStatus(LoginDefine.ELoginStatus.Init))
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.ZJC, "正在登录中, 请勿重复操作！", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.SetLoginData();
		if (!Singleton<Platform>.Instance.IsWindowsPlatform())
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.DepthOfFieldQuality 1", null);
		}
		string newAccount = this.GetNewAccount();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "生成账号";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ip", newAccount);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		base.GetInputText(2).SetText(newAccount, false);
		ModelBase<LoginModel>.Instance.SetAccount(newAccount);
		ModelBase<LoginModel>.Instance.SetPlayerName("一键登录账号");
		this.CheckPakKeyAndLogin();
	}

	// Token: 0x0600C89B RID: 51355 RVA: 0x0035224B File Offset: 0x0035044B
	private void ToggleStateChange(EToggleState state)
	{
		base.GetSprite(8).SetUIActive(state == EToggleState.ETT_Checked);
	}

	// Token: 0x0600C89C RID: 51356 RVA: 0x0035225D File Offset: 0x0035045D
	private void CloudToggleChanged(EToggleState state)
	{
		base.GetSprite(10).SetUIActive(state == EToggleState.ETT_Checked);
		Singleton<Platform>.Instance.IsFakeCloudGame = (state == EToggleState.ETT_Checked);
		Singleton<GameSettingsManager>.Instance.Clear();
	}

	// Token: 0x0600C89D RID: 51357 RVA: 0x00352288 File Offset: 0x00350488
	private void SkipPlotToggle(EToggleState state)
	{
		base.GetSprite(12).SetUIActive(state == EToggleState.ETT_Checked);
	}

	// Token: 0x0600C89E RID: 51358 RVA: 0x0035229C File Offset: 0x0035049C
	private void OnClickUseCopySourceAccountToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			ModelBase<LoginModel>.Instance.IsCopyAccount = true;
			UUIItem item = base.GetItem(19);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(true);
			return;
		}
		else
		{
			ModelBase<LoginModel>.Instance.IsCopyAccount = false;
			UUIItem item2 = base.GetItem(19);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0600C89F RID: 51359 RVA: 0x003522EC File Offset: 0x003504EC
	private void OnRecentlyAccountSelectChange(int index)
	{
		if (index == -1)
		{
			return;
		}
		if (!ModelBase<LoginModel>.Instance.IsLoginStatus(LoginDefine.ELoginStatus.Init))
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.ZJC, "正在登录中, 请勿重复操作！", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		List<string> recentlyAccountList = ModelBase<LoginModel>.Instance.GetRecentlyAccountList();
		base.GetInputText(2).SetText(recentlyAccountList[index], false);
		if (base.GetInputText(2).Text == "")
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("LoginFailEmptyAccount", Array.Empty<object>());
			return;
		}
		this.SetLoginData();
		this.CheckPakKeyAndLogin();
	}

	// Token: 0x0600C8A0 RID: 51360 RVA: 0x00352380 File Offset: 0x00350580
	private void OnGmAccountSelectChange(int index)
	{
		this.GmAccountIndex = index;
		if (index == -1)
		{
			return;
		}
		if (!ModelBase<LoginModel>.Instance.IsLoginStatus(LoginDefine.ELoginStatus.Init))
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.ZJC, "正在登录中, 请勿重复操作！", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LoginDebugPlayerNameView, new Action(this.OnGmAccountSetName), null);
	}

	// Token: 0x0600C8A1 RID: 51361 RVA: 0x003523E0 File Offset: 0x003505E0
	private void OnGmAccountSetName()
	{
		int gmAccountIndex = this.GmAccountIndex;
		if (gmAccountIndex < 0)
		{
			return;
		}
		string playerName = ModelBase<LoginModel>.Instance.GetPlayerName();
		IReadOnlyList<GmAccount> configList = ConfigGmAccountAll.GetConfigList(true);
		string firstName = configList[gmAccountIndex].FirstName;
		string newAccount = this.GetNewAccount();
		base.GetInputText(2).SetText(playerName + firstName + "-" + newAccount, false);
		ModelBase<SundryModel>.Instance.AccountGmId = configList[gmAccountIndex].GmOrderListId;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "创建新的GM账号";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
		string item = "index";
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(gmAccountIndex);
		ptr = new ValueTuple<string, object>(item, defaultInterpolatedStringHandler.ToStringAndClear());
		ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item2 = "配置id";
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(configList[gmAccountIndex].Id);
		ptr2 = new ValueTuple<string, object>(item2, defaultInterpolatedStringHandler.ToStringAndClear());
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (base.GetInputText(2).Text == "")
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("LoginFailEmptyAccount", Array.Empty<object>());
			return;
		}
		this.SetLoginData();
		this.CheckPakKeyAndLogin();
	}

	// Token: 0x0600C8A2 RID: 51362 RVA: 0x00352524 File Offset: 0x00350724
	private void SearchMap(string value)
	{
		string text = base.GetInputText(13).GetText();
		UUIDropdownComponent dropdown = base.GetDropdown(4);
		if (StringUtils.IsEmpty(text))
		{
			dropdown.SetOptions(this.OrigiMapData);
			return;
		}
		this.ToShowMapData.Empty(true);
		for (int i = 0; i < this.OrigiMapData.Num(); i++)
		{
			FUIDropdownOptionData fuidropdownOptionData = this.OrigiMapData.Get(i);
			if (fuidropdownOptionData.TextOrConfigTableName.Contains(text))
			{
				this.ToShowMapData.Add(fuidropdownOptionData);
			}
		}
		if (this.ToShowMapData.Num() == 0)
		{
			return;
		}
		dropdown.Options.Empty(true);
		dropdown.SetOptions(this.ToShowMapData);
	}

	// Token: 0x0600C8A3 RID: 51363 RVA: 0x003525CC File Offset: 0x003507CC
	private void OnSelectServer(int index)
	{
		if (index < 0)
		{
			return;
		}
		List<ServerConfig> serverInfoList = ModelBase<LoginModel>.Instance.GetServerInfoList();
		if (serverInfoList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Login;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "切换服务器IP失败, 服务器列表为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SelectIndex", index);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		ServerConfig serverConfig = serverInfoList[index];
		if (serverConfig != null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Login;
			ELogAuthor author2 = ELogAuthor.LRX;
			string message2 = "切换服务器IP";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ServerIp", serverConfig.Ip);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.GetInputText(14).SetText(serverConfig.Ip, false);
		}
	}

	// Token: 0x0600C8A4 RID: 51364 RVA: 0x00352664 File Offset: 0x00350864
	private string GetNewAccount()
	{
		return Singleton<PublicUtil>.Instance.GetLocalHost() + "[" + Singleton<TimeUtil>.Instance.DateFormat(DateTime.Now) + "]";
	}

	// Token: 0x0600C8A5 RID: 51365 RVA: 0x00352690 File Offset: 0x00350890
	[return: Nullable(2)]
	private LoginDebugView.IpPortInfo ParseServerIpAndPort(string str)
	{
		Match match = new Regex("(?<ip>\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3})(?::(?<port>\\d{1,5}))?").Match(str);
		if (match.Success && match.Groups["ip"].Success)
		{
			return new LoginDebugView.IpPortInfo
			{
				Ip = match.Groups["ip"].Value,
				Port = (match.Groups["port"].Success ? match.Groups["port"].Value : null)
			};
		}
		return null;
	}

	// Token: 0x0600C8A6 RID: 51366 RVA: 0x00352724 File Offset: 0x00350924
	private unsafe void SetLoginData()
	{
		UUIDropdownComponent dropdown = base.GetDropdown(4);
		int num = (dropdown != null) ? dropdown.Value : 0;
		if (num == -1)
		{
			num = 0;
		}
		FUIDropdownOptionData option = dropdown.GetOption(num);
		int num2 = -1;
		for (int i = 0; i < this.OrigiMapData.Num(); i++)
		{
			if (this.OrigiMapData.Get(i).TextOrConfigTableName == option.TextOrConfigTableName)
			{
				num2 = i;
				break;
			}
		}
		if (num2 == -1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Login;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "当前选择的地图 在初始地图数据集合里 不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("地图名称", option.TextOrConfigTableName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			num2 = 0;
		}
		if (num2 >= 0)
		{
			int? singleMapIp = ModelBase<LoginModel>.Instance.GetSingleMapIp(num2);
			if (singleMapIp != null)
			{
				ModelBase<LoginModel>.Instance.SetSingleMapId(singleMapIp.Value);
			}
		}
		UUIDropdownComponent dropdown2 = base.GetDropdown(3);
		if (dropdown2 != null)
		{
			int num3 = dropdown2.GetValue();
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Login;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "获取服务器下拉列表当前设置值";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("serverValue", num3);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			if (num3 < 0)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Login, ELogAuthor.XXJ, "服务器下拉列表当前设置值不符合预期,默认为0", default(ReadOnlySpan<ValueTuple<string, object>>));
				num3 = 0;
			}
			ServerConfig serverInfo = ModelBase<LoginModel>.Instance.GetServerInfo(num3);
			if (serverInfo != null)
			{
				ModelBase<LoginModel>.Instance.SetServerName(serverInfo.Name);
				this.SetServerIp(serverInfo.Ip, 1);
			}
			else
			{
				List<ServerConfig> serverInfoList = ModelBase<LoginModel>.Instance.GetServerInfoList();
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Login;
				ELogAuthor author3 = ELogAuthor.XXJ;
				string message3 = "获取服务器数据为空";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("serverInfoList", serverInfoList);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			}
		}
		else
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.XXJ, "服务器下拉列表节点获取不到", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		string text = base.GetInputText(14).GetText();
		if (!StringUtils.IsEmpty(text))
		{
			LoginDebugView.IpPortInfo ipPortInfo = this.ParseServerIpAndPort(text);
			if (ipPortInfo != null)
			{
				ModelBase<LoginModel>.Instance.SetServerName("手动输入IP地址服务器");
				this.SetServerIp(text, 2);
				ModelBase<LoginModel>.Instance.TrySetCustomServerPort(ipPortInfo.Port, 2);
			}
		}
		LoginDefine.ELoginSex eloginSex = (base.GetExtendToggle(7).ToggleState == EToggleState.ETT_Checked) ? LoginDefine.ELoginSex.Girl : LoginDefine.ELoginSex.Boy;
		LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.LoginSex, eloginSex == LoginDefine.ELoginSex.Girl);
		ModelBase<LoginModel>.Instance.SetPlayerSex(eloginSex);
		ModelBase<LoginModel>.Instance.SetAccount(base.GetInputText(2).Text);
		ModelBase<LoginModel>.Instance.SetSourceAccount(base.GetInputText(17).Text);
		bool value = base.GetExtendToggle(11).ToggleState == EToggleState.ETT_Checked;
		LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.SkipPlot, value);
		Log instance4 = Singleton<Log>.Instance;
		ELogModule module4 = ELogModule.Login;
		ELogAuthor author4 = ELogAuthor.ZJC;
		string message4 = "已保存登录数据";
		<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ServerIp", this.GetServerIp());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CustomServerPort", ModelBase<LoginModel>.Instance.GetCustomServerPort());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SingleId", ModelBase<LoginModel>.Instance.GetSingleMapId());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("MultiMapId", ModelBase<LoginModel>.Instance.GetMultiMapId());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("Account", ModelBase<LoginModel>.Instance.GetAccount());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("LoginSex", eloginSex);
		instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
	}

	// Token: 0x0600C8A7 RID: 51367 RVA: 0x00352A90 File Offset: 0x00350C90
	private void HttpLogin()
	{
		if (!ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			IPrivateServersData privateServers = Singleton<BaseConfigController>.Instance.GetPrivateServers();
			if (privateServers == null)
			{
				return;
			}
			ModelBase<LoginModel>.Instance.AddServerInfoByCdn();
			if (privateServers.enable)
			{
				string[] array = (from m in Regex.Matches(privateServers.serverUrl, "://.*?/")
				select m.Value).ToArray<string>();
				if (array.Length >= 0)
				{
					string text = array[0];
					UKuroStaticLibrary.IcmpPing(text.Substring(3, text.Length - 4), 5f, this.IcmpPingCallBack);
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenConfirmBoxByText("私服域名截取失败[" + privateServers.serverUrl + "]");
				return;
			}
			else
			{
				this.HttpCallBackInternal(false, null, null, false);
			}
		}
	}

	// Token: 0x0600C8A8 RID: 51368 RVA: 0x00352B6C File Offset: 0x00350D6C
	private void IcmpCallBack(string ipAddress, float time, int responseState)
	{
		if (responseState == 0)
		{
			IPrivateServersData privateServers = Singleton<BaseConfigController>.Instance.GetPrivateServers();
			if (privateServers == null)
			{
				return;
			}
			Http.Get(privateServers.serverUrl, null, new Action<bool, int, string>(this.HttpCallBack), null);
			this.TimerId = TimerSystem.Instance.Delay(delegate(float t)
			{
				this.TimerId = null;
				this.HttpCallBackInternal(false, null, null, true);
			}, (float)(Singleton<TimeUtil>.Instance.InverseMillisecond * 5), null, null, true, 1f);
			return;
		}
		else
		{
			if (responseState == 3)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenConfirmBoxByText("私服列表域名解析失败[" + ipAddress + "], 可能是本地开了VPN, 请关闭后重试");
				return;
			}
			Action<string> openConfirmBoxByText = ControllerBase<ErrorCodeController>.Instance.OpenConfirmBoxByText;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 2);
			defaultInterpolatedStringHandler.AppendLiteral("私服列表获取失败[");
			defaultInterpolatedStringHandler.AppendFormatted(ipAddress);
			defaultInterpolatedStringHandler.AppendLiteral("], EIcmpResponseStatus:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(responseState);
			openConfirmBoxByText(defaultInterpolatedStringHandler.ToStringAndClear());
			return;
		}
	}

	// Token: 0x0600C8A9 RID: 51369 RVA: 0x00352C4A File Offset: 0x00350E4A
	private void HttpCallBack(bool success, int code, string data)
	{
		this.HttpCallBackInternal(success, new int?(code), data, true);
	}

	// Token: 0x0600C8AA RID: 51370 RVA: 0x00352C5C File Offset: 0x00350E5C
	[NullableContext(2)]
	private void HttpCallBackInternal(bool success = false, int? code = null, string data = null, bool addDataTableServers = true)
	{
		if (this.TimerId != null)
		{
			TimerSystem.Instance.Remove(this.TimerId);
			this.TimerId = null;
		}
		ModelBase<LoginModel>.Instance.AddExtraServer();
		if (data != null)
		{
			ServerInfo[] array = Json.Parse<ServerInfo[]>(data, null);
			if (array != null)
			{
				ModelBase<LoginModel>.Instance.AddServerInfos(array);
			}
		}
		if (addDataTableServers)
		{
			ModelBase<LoginModel>.Instance.AddDataTableServers();
		}
		this.OnHttpLoginInit();
	}

	// Token: 0x0600C8AB RID: 51371 RVA: 0x00352CC0 File Offset: 0x00350EC0
	private void SetServerIp(string serverIp, int reason)
	{
		ModelBase<LoginModel>.Instance.SetServerIp(serverIp, reason);
		LocalStorage.SetGlobal<string>(ELocalStorageGlobalKey.LoginDebugServerIp, serverIp);
	}

	// Token: 0x0600C8AC RID: 51372 RVA: 0x00352CD8 File Offset: 0x00350ED8
	[NullableContext(2)]
	private string GetServerIp()
	{
		string global = LocalStorage.GetGlobal<string>(ELocalStorageGlobalKey.LoginDebugServerIp, "-1");
		if (global == "-1")
		{
			return ModelBase<LoginModel>.Instance.GetServerIp();
		}
		return global;
	}

	// Token: 0x0400603D RID: 24637
	[Nullable(2)]
	private TimerHandle TimerId;

	// Token: 0x0400603E RID: 24638
	private int GmAccountIndex = -1;

	// Token: 0x0400603F RID: 24639
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<FUIDropdownOptionData> OrigiMapData;

	// Token: 0x04006040 RID: 24640
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<FUIDropdownOptionData> ToShowMapData;

	// Token: 0x04006041 RID: 24641
	[Nullable(2)]
	private FPingCallExDelegate IcmpPingCallBack;

	// Token: 0x02007E17 RID: 32279
	[NullableContext(0)]
	private class ELoginChildCom
	{
		// Token: 0x0402AEFE RID: 175870
		public const int QuitBtn = 0;

		// Token: 0x0402AEFF RID: 175871
		public const int LoginBtn = 1;

		// Token: 0x0402AF00 RID: 175872
		public const int AccountTextInput = 2;

		// Token: 0x0402AF01 RID: 175873
		public const int ServerComboBox = 3;

		// Token: 0x0402AF02 RID: 175874
		public const int SingleMapComboBox = 4;

		// Token: 0x0402AF03 RID: 175875
		public const int QuickLoginUseNewBtn = 5;

		// Token: 0x0402AF04 RID: 175876
		public const int QuickLoginUseCurBtn = 6;

		// Token: 0x0402AF05 RID: 175877
		public const int SexToggle = 7;

		// Token: 0x0402AF06 RID: 175878
		public const int SexSprite = 8;

		// Token: 0x0402AF07 RID: 175879
		public const int CloudToggle = 9;

		// Token: 0x0402AF08 RID: 175880
		public const int CloudSprite = 10;

		// Token: 0x0402AF09 RID: 175881
		public const int SkipPlotToggle = 11;

		// Token: 0x0402AF0A RID: 175882
		public const int SkipPlotSprite = 12;

		// Token: 0x0402AF0B RID: 175883
		public const int SearchMapInput = 13;

		// Token: 0x0402AF0C RID: 175884
		public const int TargetIPInput = 14;

		// Token: 0x0402AF0D RID: 175885
		public const int GmAccountDropDown = 15;

		// Token: 0x0402AF0E RID: 175886
		public const int RecentlyAccountDropDown = 16;

		// Token: 0x0402AF0F RID: 175887
		public const int SourceAccountTextInput = 17;

		// Token: 0x0402AF10 RID: 175888
		public const int UseCopySourceAccountToggle = 18;

		// Token: 0x0402AF11 RID: 175889
		public const int SourceAccountToggleCheckItem = 19;

		// Token: 0x0402AF12 RID: 175890
		public const int ServerIpInput = 20;
	}

	// Token: 0x02007E18 RID: 32280
	[Nullable(0)]
	private class IpPortInfo
	{
		// Token: 0x1700A832 RID: 43058
		// (get) Token: 0x06047ECC RID: 294604 RVA: 0x01333C22 File Offset: 0x01331E22
		// (set) Token: 0x06047ECD RID: 294605 RVA: 0x01333C2A File Offset: 0x01331E2A
		public string Ip { get; set; } = "";

		// Token: 0x1700A833 RID: 43059
		// (get) Token: 0x06047ECE RID: 294606 RVA: 0x01333C33 File Offset: 0x01331E33
		// (set) Token: 0x06047ECF RID: 294607 RVA: 0x01333C3B File Offset: 0x01331E3B
		[Nullable(2)]
		public string Port { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
