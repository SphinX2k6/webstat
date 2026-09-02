using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Module.ResManager;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Platform.PlatformSdk;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002108 RID: 8456
[NullableContext(1)]
[Nullable(0)]
public class LoginOfficialView : UiTickViewBase
{
	// Token: 0x060102DC RID: 66268 RVA: 0x0047239C File Offset: 0x0047059C
	public LoginOfficialView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060102DD RID: 66269 RVA: 0x004724D8 File Offset: 0x004706D8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 27;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 14;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.LoginBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.LogoutBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, this.RepairBtnClick);
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.LoginBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.ShowAgeTipBtnClickCallBack));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.AgreeAgreement));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, this.UserButtonClick);
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, this.SecretButtonClick);
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(8, this.ChildPrivacyButtonClick);
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(11, this.OnClickNoticeBtn);
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(12, this.OnExitGameClick);
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(14, this.OnClickServerBtn);
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(20, new Action(this.OnClickQRCodeLoginBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(27, new Action(this.OnClickMenuBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060102DE RID: 66270 RVA: 0x00472A70 File Offset: 0x00470C70
	protected override UniTask OnBeforeStartAsync()
	{
		LoginOfficialView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LoginOfficialView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060102DF RID: 66271 RVA: 0x00472AB4 File Offset: 0x00470CB4
	protected override void OnStart()
	{
		ControllerBase<ResourceManagerController>.Instance.ChangeHttpTickFrequency();
		ControllerBase<LoginController>.Instance.LogLoginProcessLink(LoginDefine.ELoginStatus.LoginViewOpen, Aki.Protocol.ErrorCode.Success);
		ModelBase<LoginModel>.Instance.FixLoginFailInfo();
		base.GetButton(14).RootUIComp.Get().SetUIActive(false);
		this.RefreshLoginState(false);
		this.InitAgreement();
		this.InitLoginText();
		bool uiactive = Singleton<Info>.Instance.IsPcOrGamepadPlatform();
		base.GetButton(12).RootUIComp.Get().SetUIActive(uiactive);
		base.GetItem(13).SetUIActive(false);
		this.RefreshPostViewRedPoint();
		this.RefreshAgeBtn();
		this.RefreshChildBtn();
		this.RefreshCopyRightItem();
		this.RefreshVersionText();
		this.RefreshLogo();
		this.RefreshExitButton();
		this.RefreshAccountButton(false);
		this.RefreshQRCodeLoginBtn(false);
		this.RefreshDownLoadState();
		PreDownloadButtonItemA preDownloadItem = this.PreDownloadItem;
		if (preDownloadItem != null)
		{
			preDownloadItem.Refresh(false);
		}
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.LoginOfficialStatusView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.LoginOfficialStatusView, null, null);
		}
		this.RefreshMenuBtnState();
	}

	// Token: 0x060102E0 RID: 66272 RVA: 0x00472BBB File Offset: 0x00470DBB
	protected override void OnBeforeDestroy()
	{
		ControllerBase<ResourceManagerController>.Instance.RestoreHttpTickFrequency();
	}

	// Token: 0x060102E1 RID: 66273 RVA: 0x00472BC8 File Offset: 0x00470DC8
	private void RefreshExitButton()
	{
		if (Singleton<CloudGameManager>.Instance.IsCloudGame)
		{
			base.GetButton(12).RootUIComp.Get().SetUIActive(false);
			return;
		}
		if (!ControllerBase<LoginController>.Instance.IsSdkLoginMode())
		{
			base.GetButton(12).RootUIComp.Get().SetUIActive(true);
			return;
		}
		string value = Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn ? Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetProductId() : UKuroSDKManager.GetPackageId();
		bool uiactive = !ConfigBase<LoginConfig>.Instance.GetLoginViewNoExitButtonPackageIdList().Contains(value);
		base.GetButton(12).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x060102E2 RID: 66274 RVA: 0x00472C78 File Offset: 0x00470E78
	private void RefreshAccountButton(bool sdkLoginState = false)
	{
		if (Singleton<CloudGameManager>.Instance.IsCloudGame)
		{
			base.GetButton(1).RootUIComp.Get().SetUIActive(false);
			return;
		}
		if (!ControllerBase<LoginController>.Instance.IsSdkLoginMode())
		{
			base.GetButton(1).RootUIComp.Get().SetUIActive(true);
			return;
		}
		string value = Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn ? Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetProductId() : UKuroSDKManager.GetPackageId();
		string[] loginViewNoAccountButtonPackageIdList = ConfigBase<LoginConfig>.Instance.GetLoginViewNoAccountButtonPackageIdList();
		bool uiactive = sdkLoginState && !loginViewNoAccountButtonPackageIdList.Contains(value);
		base.GetButton(1).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x060102E3 RID: 66275 RVA: 0x00472D2C File Offset: 0x00470F2C
	protected void RefreshQRCodeLoginBtn(bool sdkLoginState = false)
	{
		if (Singleton<CloudGameManager>.Instance.IsCloudGame)
		{
			base.GetButton(20).RootUIComp.Get().SetUIActive(false);
			return;
		}
		if (!ControllerBase<LoginController>.Instance.IsSdkLoginMode())
		{
			base.GetButton(20).RootUIComp.Get().SetUIActive(false);
			return;
		}
		bool flag = Singleton<Info>.Instance.IsMobilePlatform();
		bool ifGlobalSdk = ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk();
		bool ifCanQRCodeLogin = ControllerBase<KuroSdkController>.Instance.GetIfCanQRCodeLogin();
		bool uiactive = sdkLoginState && flag && !ifGlobalSdk && ifCanQRCodeLogin;
		base.GetButton(20).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x060102E4 RID: 66276 RVA: 0x00472DD8 File Offset: 0x00470FD8
	protected void OnClickQRCodeLoginBtn()
	{
		if (!ControllerBase<KuroSdkController>.Instance.GetIfCanQRCodeLogin())
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.TL, "扫码登录未开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ControllerBase<KuroSdkController>.Instance.DoQRCodeLogin();
	}

	// Token: 0x060102E5 RID: 66277 RVA: 0x00472E18 File Offset: 0x00471018
	private void OnClickMenuBtn()
	{
		if (!this.IsLoginStableState())
		{
			return;
		}
		if (this.IsMenuViewOpenRequested)
		{
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.MenuViewPopView))
		{
			return;
		}
		this.IsMenuViewOpenRequested = true;
		MenuViewOpenParam param = new MenuViewOpenParam
		{
			OpenScene = new EMenuViewOpenScene?(EMenuViewOpenScene.Login)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MenuViewPopView, param, delegate(bool _, int __)
		{
			this.IsMenuViewOpenRequested = false;
		});
	}

	// Token: 0x060102E6 RID: 66278 RVA: 0x00472E80 File Offset: 0x00471080
	private bool IsLoginStableState()
	{
		LoginModel instance = ModelBase<LoginModel>.Instance;
		bool flag = this.IsSdkLoginInFlight || this.IsBindRegionPending || this.IsPostSdkLoginPending || this.IsCharacterLoginInFlight || this.NeedTickDownLoad;
		bool flag2 = instance == null || !instance.IsLoginStatus(LoginDefine.ELoginStatus.Init) || instance.IsSdkLoggingIn();
		return !flag && !flag2;
	}

	// Token: 0x060102E7 RID: 66279 RVA: 0x00472EDC File Offset: 0x004710DC
	private void RefreshMenuBtnState()
	{
		UUIButtonComponent button = base.GetButton(27);
		if (button == null)
		{
			return;
		}
		bool flag = this.IsLoginStableState();
		this.MenuBtnEnableApplied = flag;
		button.SetSelfInteractive(flag);
		button.RootUIComp.Get().SetAlpha(flag ? 1f : 0.5f);
	}

	// Token: 0x060102E8 RID: 66280 RVA: 0x00472F2D File Offset: 0x0047112D
	private void InitAgreement()
	{
		this.IsAgree = true;
		base.GetExtendToggle(5).SetToggleState(this.IsAgree ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060102E9 RID: 66281 RVA: 0x00472F52 File Offset: 0x00471152
	private void InitLoginText()
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(10), "ClickEnterGame", Array.Empty<object>());
	}

	// Token: 0x060102EA RID: 66282 RVA: 0x00472F70 File Offset: 0x00471170
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.LoginRequestResult, new Action<bool>(this.CreateCharacterResult));
		Singleton<EventSystem>.Instance.Add(EEventName.SdkPostWebViewRedPointRefresh, new Action(this.OnSdkPostWebViewRedPointRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.SdkLoginResult, new Action(this.OnSdkLoginResult));
		Singleton<EventSystem>.Instance.Add(EEventName.OnGetLoginPlayerInfo, this.OnGetLoginPlayerInfo);
		Singleton<EventSystem>.Instance.Add(EEventName.OnConfirmServerItem, new Action(this.OnConfirmServerItem));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		Singleton<EventSystem>.Instance.Add(EEventName.PlayStationJoinSessionEvent, new Action(this.PlayStationJoinSessionEvent));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPreDownloadAvailableUpdate, new Action(this.OnPreDownloadUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshSubPackageDownLoadByPriority, new Action(this.OnRefreshSubPackageDownLoadByPriority));
	}

	// Token: 0x060102EB RID: 66283 RVA: 0x00473064 File Offset: 0x00471264
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.LoginRequestResult, new Action<bool>(this.CreateCharacterResult));
		Singleton<EventSystem>.Instance.Remove(EEventName.SdkPostWebViewRedPointRefresh, new Action(this.OnSdkPostWebViewRedPointRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.SdkLoginResult, new Action(this.OnSdkLoginResult));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGetLoginPlayerInfo, this.OnGetLoginPlayerInfo);
		Singleton<EventSystem>.Instance.Remove(EEventName.OnConfirmServerItem, new Action(this.OnConfirmServerItem));
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		Singleton<EventSystem>.Instance.Remove(EEventName.PlayStationJoinSessionEvent, new Action(this.PlayStationJoinSessionEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPreDownloadAvailableUpdate, new Action(this.OnPreDownloadUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshSubPackageDownLoadByPriority, new Action(this.OnRefreshSubPackageDownLoadByPriority));
	}

	// Token: 0x060102EC RID: 66284 RVA: 0x00473158 File Offset: 0x00471358
	protected override void OnBeforeShow()
	{
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.TL, "LoginProcedure-SdkLogin-界面打开检测sdk状态设置表现", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.OnSdkLoginResult();
		}
	}

	// Token: 0x060102ED RID: 66285 RVA: 0x00473194 File Offset: 0x00471394
	protected override void OnAfterShow()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			this.IsSdkLoginInFlight = true;
		}
		this.OnAfterShowStartSdkLogin().Forget();
		if (Singleton<CloudGameManager>.Instance.IsCloudGame)
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.TL, "LoginProcedure-SdkLoginNew-云游戏登录", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (Singleton<CloudGameManagerLauncher>.Instance.IsPreLaunch)
			{
				this.IsSdkLoginInFlight = true;
				ControllerBase<LoginController>.Instance.OnSdkLogin(Singleton<CloudGameManager>.Instance.GetCloudGameLoginInfo());
				this.TryLogin(false).Forget();
			}
		}
		PreDownloadButtonItemA preDownloadItem = this.PreDownloadItem;
		if (preDownloadItem != null)
		{
			preDownloadItem.RefreshDot();
		}
		this.RefreshMenuBtnState();
	}

	// Token: 0x060102EE RID: 66286 RVA: 0x00473234 File Offset: 0x00471434
	private UniTask OnAfterShowStartSdkLogin()
	{
		LoginOfficialView.<OnAfterShowStartSdkLogin>d__29 <OnAfterShowStartSdkLogin>d__;
		<OnAfterShowStartSdkLogin>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnAfterShowStartSdkLogin>d__.<>4__this = this;
		<OnAfterShowStartSdkLogin>d__.<>1__state = -1;
		<OnAfterShowStartSdkLogin>d__.<>t__builder.Start<LoginOfficialView.<OnAfterShowStartSdkLogin>d__29>(ref <OnAfterShowStartSdkLogin>d__);
		return <OnAfterShowStartSdkLogin>d__.<>t__builder.Task;
	}

	// Token: 0x060102EF RID: 66287 RVA: 0x00473278 File Offset: 0x00471478
	[NullableContext(0)]
	private UniTask<bool> BindAccountWithRegion()
	{
		LoginOfficialView.<BindAccountWithRegion>d__30 <BindAccountWithRegion>d__;
		<BindAccountWithRegion>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<BindAccountWithRegion>d__.<>1__state = -1;
		<BindAccountWithRegion>d__.<>t__builder.Start<LoginOfficialView.<BindAccountWithRegion>d__30>(ref <BindAccountWithRegion>d__);
		return <BindAccountWithRegion>d__.<>t__builder.Task;
	}

	// Token: 0x060102F0 RID: 66288 RVA: 0x004732B3 File Offset: 0x004714B3
	private void LoginBtnClick()
	{
		if (this.IsMenuViewOpenRequested)
		{
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.MenuViewPopView))
		{
			return;
		}
		this.TryLogin(true).Forget();
	}

	// Token: 0x060102F1 RID: 66289 RVA: 0x004732DC File Offset: 0x004714DC
	private UniTask TryLogin(bool isFromClick)
	{
		LoginOfficialView.<TryLogin>d__32 <TryLogin>d__;
		<TryLogin>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TryLogin>d__.<>4__this = this;
		<TryLogin>d__.isFromClick = isFromClick;
		<TryLogin>d__.<>1__state = -1;
		<TryLogin>d__.<>t__builder.Start<LoginOfficialView.<TryLogin>d__32>(ref <TryLogin>d__);
		return <TryLogin>d__.<>t__builder.Task;
	}

	// Token: 0x060102F2 RID: 66290 RVA: 0x00473328 File Offset: 0x00471528
	private void LogoutBtnClick()
	{
		if (!ModelBase<LoginModel>.Instance.IsLoginStatus(LoginDefine.ELoginStatus.Init))
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.ZJC, "正在登录中, 无法退出！", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.LogoutAccount);
		confirmBoxDataNew.FunctionMap[2] = new Action(this.LogoutAccount);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		Singleton<KuroSdkReport>.Instance.Report(new SdkReportChangeAccount(null));
	}

	// Token: 0x060102F3 RID: 66291 RVA: 0x0047339A File Offset: 0x0047159A
	private void OnSdkPostWebViewRedPointRefresh()
	{
		this.RefreshPostViewRedPoint();
	}

	// Token: 0x060102F4 RID: 66292 RVA: 0x004733A4 File Offset: 0x004715A4
	private void CreateCharacterResult(bool result)
	{
		this.IsCharacterLoginInFlight = false;
		if (!result)
		{
			this.RefreshMenuBtnState();
			return;
		}
		base.CloseMe(null);
		int? playerSex = ModelBase<LoginModel>.Instance.GetPlayerSex();
		if (playerSex == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Login, ELogAuthor.XXJ, "性别获取为空,账号走的直接登录,性别设置异常", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ModelBase<LoginModel>.Instance.CreateLoginPromise();
		IReadOnlyList<int> initialRoles = ConfigBase<CreateCharacterConfig>.Instance.GetInitialRoles();
		Singleton<UiLoginSceneManager>.Instance.PlayRoleMontage(initialRoles[playerSex.Value], EPerformanceRoleState.CreateRole_Login);
		Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.XXJ, "登录请求成功", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<UiLoginSceneManager>.Instance.LoadSequenceAsync(this.GetLoginSequenceName((LoginDefine.ELoginSex)playerSex.Value), delegate
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.XXJ, "登录请求成功,进入游戏", default(ReadOnlySpan<ValueTuple<string, object>>));
			ModelBase<LoginModel>.Instance.FinishLoginPromise();
			ControllerBase<BlackScreenController>.Instance.AddBlackScreen("None", "LoginFinish", "Black");
		}, false, null);
	}

	// Token: 0x060102F5 RID: 66293 RVA: 0x0047347C File Offset: 0x0047167C
	private void OnSdkLoginResult()
	{
		if (ControllerBase<KuroSdkController>.Instance.CheckIfSingleServerAfterSelect() && !ModelBase<LoginServerModel>.Instance.GetIfSetOnlyRegion())
		{
			return;
		}
		this.IsSdkLoginInFlight = false;
		if (ModelBase<LoginModel>.Instance.IsSdkLoggedIn())
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.TL, "LoginProcedure-SdkLogin-登录成功", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.RefreshLoginState(true);
			if (!Singleton<Platform>.Instance.IsWindowsPlatform())
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.DepthOfFieldQuality 1", null);
			}
			this.OnSdkLoginFinish();
			if (ControllerBase<KuroSdkController>.Instance.CanUseSdk() && !this.IfAutoShowLoginServerView())
			{
				this.OnSdkLoginSuccess().ContinueWith(delegate()
				{
					if (Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit() && !ModelBase<SubPackageDownLoadModel>.Instance.IsKeyPackageDownLoadingFinish())
					{
						Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LJQ, "SdkLogin登录成功-需要下载核心包，自动开始下载", default(ReadOnlySpan<ValueTuple<string, object>>));
						ControllerBase<SubPackageController>.Instance.AutoDownLoadKeySubPackage();
						this.RefreshDownLoadState();
						return;
					}
					this.AfterDownLoad();
				}).Forget();
			}
			else
			{
				this.AfterDownLoad();
			}
		}
		else
		{
			this.RefreshLoginState(false);
			if (Singleton<Info>.Instance.IsPs5Platform())
			{
				ModelBase<LoginModel>.Instance.ThirdGameAutoLoginId = "-1";
			}
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.TL, "LoginProcedure-SdkLogin-登录失败, 重新打开SDK登录界面", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.RefreshMenuBtnState();
	}

	// Token: 0x060102F6 RID: 66294 RVA: 0x00473578 File Offset: 0x00471778
	private UniTask OnSdkLoginSuccess()
	{
		LoginOfficialView.<OnSdkLoginSuccess>d__44 <OnSdkLoginSuccess>d__;
		<OnSdkLoginSuccess>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnSdkLoginSuccess>d__.<>4__this = this;
		<OnSdkLoginSuccess>d__.<>1__state = -1;
		<OnSdkLoginSuccess>d__.<>t__builder.Start<LoginOfficialView.<OnSdkLoginSuccess>d__44>(ref <OnSdkLoginSuccess>d__);
		return <OnSdkLoginSuccess>d__.<>t__builder.Task;
	}

	// Token: 0x060102F7 RID: 66295 RVA: 0x004735BC File Offset: 0x004717BC
	private void OnSdkLoginFinish()
	{
		if (base.IsShow)
		{
			this.UiViewSequence.PlaySequence("Show", false, null);
		}
		ControllerBase<KuroSdkController>.Instance.ShowExternalLogin();
		if (ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode())
		{
			LoginServerModel instance = ModelBase<LoginServerModel>.Instance;
			SdkLoginConfig sdkLoginConfig = ModelBase<LoginModel>.Instance.GetSdkLoginConfig();
			instance.InitSuggestData(((sdkLoginConfig != null) ? sdkLoginConfig.Uid : null) ?? "", delegate(ILoginServersData data)
			{
				ModelBase<LoginModel>.Instance.SetServerName(data.name);
				ModelBase<LoginModel>.Instance.SetServerId(data.id);
			});
			if (this.IfAutoShowLoginServerView())
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.LoginServerView, null, null);
				ModelBase<LoginModel>.Instance.ThirdGameAutoLoginId = "-1";
			}
			base.GetButton(14).RootUIComp.Get().SetUIActive(true);
			this.RefreshServerName();
		}
		else
		{
			base.GetButton(14).RootUIComp.Get().SetUIActive(false);
		}
		if (ModelBase<LoginModel>.Instance.ThirdGameAutoLoginId != "-1")
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LJQ, "PS5 PlaySession 直接启动 - 模拟点击登录按钮2", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.TryLogin(false).Forget();
		}
	}

	// Token: 0x060102F8 RID: 66296 RVA: 0x004736F0 File Offset: 0x004718F0
	private void AfterDownLoad()
	{
		Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LJQ, "SdkLogin登录成功-最后刷新登录成功表现", default(ReadOnlySpan<ValueTuple<string, object>>));
		base.GetItem(22).SetUIActive(false);
		base.GetItem(18).SetUIActive(true);
		base.GetButton(4).RootUIComp.Get().SetUIActive(!ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode());
		base.GetButton(0).RootUIComp.Get().SetUIActive(true);
		base.GetButton(2).SetSelfInteractive(true);
		base.GetButton(1).SetSelfInteractive(true);
		base.GetButton(27).SetSelfInteractive(true);
		base.GetButton(2).RootUIComp.Get().SetAlpha(1f);
		base.GetButton(1).RootUIComp.Get().SetAlpha(1f);
		base.GetButton(27).RootUIComp.Get().SetAlpha(1f);
		base.GetButton(14).RootUIComp.Get().SetUIActive(ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode());
		this.RefreshMenuBtnState();
	}

	// Token: 0x060102F9 RID: 66297 RVA: 0x00473824 File Offset: 0x00471A24
	private void DisableDownLoadAbout()
	{
		Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LJQ, "LoginOfficialView-DisableDownLoadAbout", default(ReadOnlySpan<ValueTuple<string, object>>));
		base.GetItem(18).SetUIActive(false);
		base.GetButton(0).RootUIComp.Get().SetUIActive(false);
		base.GetButton(2).SetSelfInteractive(false);
		base.GetButton(1).SetSelfInteractive(false);
		base.GetButton(27).SetSelfInteractive(false);
		base.GetButton(14).RootUIComp.Get().SetUIActive(false);
		this.RefreshMenuBtnState();
	}

	// Token: 0x060102FA RID: 66298 RVA: 0x004738C0 File Offset: 0x00471AC0
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.MenuViewPopView)
		{
			this.IsMenuViewOpenRequested = false;
			return;
		}
		if (viewName != EUiViewName.LoginServerView)
		{
			return;
		}
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			this.DisableDownLoadAbout();
			this.OnSdkLoginSuccess().ContinueWith(delegate()
			{
				if (Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit() && !ModelBase<SubPackageDownLoadModel>.Instance.IsKeyPackageDownLoadingFinish())
				{
					Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LJQ, "SdkLogin-选服后 -需要下载核心包，自动开始下载", default(ReadOnlySpan<ValueTuple<string, object>>));
					ControllerBase<SubPackageController>.Instance.AutoDownLoadKeySubPackage();
					this.RefreshDownLoadState();
					return;
				}
				this.AfterDownLoad();
			}).Forget();
			return;
		}
		this.AfterDownLoad();
	}

	// Token: 0x060102FB RID: 66299 RVA: 0x00473925 File Offset: 0x00471B25
	private void OnRefreshSubPackageDownLoadByPriority()
	{
		this.RefreshDownLoadState();
	}

	// Token: 0x060102FC RID: 66300 RVA: 0x00473930 File Offset: 0x00471B30
	protected virtual void RefreshDownLoadState()
	{
		if (!Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
		{
			return;
		}
		bool flag = !ModelBase<SubPackageDownLoadModel>.Instance.IsKeyPackageDownLoadingFinish();
		this.NeedTickDownLoad = (flag && this.CurLoginState);
		base.GetItem(22).SetUIActive(this.NeedTickDownLoad);
		base.GetItem(18).SetUIActive(!this.NeedTickDownLoad);
		base.GetButton(0).RootUIComp.Get().SetUIActive(!this.NeedTickDownLoad);
		base.GetButton(4).RootUIComp.Get().SetUIActive(!ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode() && !this.NeedTickDownLoad);
		base.GetButton(2).SetSelfInteractive(!this.NeedTickDownLoad);
		base.GetButton(1).SetSelfInteractive(!this.NeedTickDownLoad);
		base.GetButton(27).SetSelfInteractive(!this.NeedTickDownLoad);
		if (this.NeedTickDownLoad)
		{
			base.GetButton(2).RootUIComp.Get().SetAlpha(0.5f);
			base.GetButton(1).RootUIComp.Get().SetAlpha(0.5f);
			base.GetButton(27).RootUIComp.Get().SetAlpha(0.5f);
		}
		base.GetButton(14).RootUIComp.Get().SetUIActive(ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode() && !this.NeedTickDownLoad);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "SdkLogin-刷新下载状态";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("NeedTickDownLoad", this.NeedTickDownLoad);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (!this.NeedTickDownLoad)
		{
			this.AfterDownLoad();
		}
		this.RefreshMenuBtnState();
	}

	// Token: 0x060102FD RID: 66301 RVA: 0x00473B00 File Offset: 0x00471D00
	protected override void OnTick(float delta)
	{
		if (this.IsLoginStableState() != this.MenuBtnEnableApplied)
		{
			this.RefreshMenuBtnState();
		}
		if (!this.NeedTickDownLoad)
		{
			return;
		}
		float num = (float)ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageCurrentHaveDownLoadSpace(1);
		float num2 = (float)ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageCurrentTotalSpace(1);
		float num3 = (num2 > 0f) ? (num / num2) : 0f;
		base.GetSprite(23).SetFillAmount(num3);
		base.GetText(25).SetText(ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadSpeed()) + "/s", true);
		base.GetText(26).SetText(ModelBase<SubPackageDownLoadModel>.Instance.GetKeyPackageDownLoadingFileName(), true);
		base.GetText(24).SetText(((int)(num3 * 100f)).ToString() + "%", true);
	}

	// Token: 0x060102FE RID: 66302 RVA: 0x00473BD1 File Offset: 0x00471DD1
	private void OnConfirmServerItem()
	{
		this.RefreshServerName();
	}

	// Token: 0x060102FF RID: 66303 RVA: 0x00473BDC File Offset: 0x00471DDC
	private void PlayStationJoinSessionEvent()
	{
		Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LJQ, "PS5 PlaySession 直接启动 - 模拟点击登录按钮 事件触发", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.TryLogin(false).Forget();
	}

	// Token: 0x06010300 RID: 66304 RVA: 0x00473C10 File Offset: 0x00471E10
	private bool IfAutoShowLoginServerView()
	{
		LoginServerModel instance = ModelBase<LoginServerModel>.Instance;
		LoginModel instance2 = ModelBase<LoginModel>.Instance;
		if (ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode())
		{
			LoginServerModel loginServerModel = instance;
			SdkLoginConfig sdkLoginConfig = instance2.GetSdkLoginConfig();
			if (loginServerModel.IsFirstLogin(((sdkLoginConfig != null) ? sdkLoginConfig.Uid : null) ?? ""))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010301 RID: 66305 RVA: 0x00473C5B File Offset: 0x00471E5B
	protected string GetLoginSequenceName(LoginDefine.ELoginSex sex)
	{
		if (sex != LoginDefine.ELoginSex.Boy)
		{
			return "LevelSequence_LoginFemale";
		}
		return "LevelSequence_LoginMale";
	}

	// Token: 0x06010302 RID: 66306 RVA: 0x00473C6C File Offset: 0x00471E6C
	private void LogoutAccount()
	{
		Singleton<ThirdPartySdkManager>.Instance.Logout();
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			this.RefreshLoginState(false);
			this.UiViewSequence.PlaySequence("Show", false, null);
			Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(false, "");
			ControllerBase<KuroSdkController>.Instance.PostKuroSdkEvent(EKuroSdkEventKey.KUROSDKLOGOUT);
			return;
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.LoginView, delegate(bool success)
		{
			if (success)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.LoginDebugView, null, null);
			}
		});
	}

	// Token: 0x06010303 RID: 66307 RVA: 0x00473CFA File Offset: 0x00471EFA
	private void AgreeAgreement(EToggleState state)
	{
		this.IsAgree = (state == EToggleState.ETT_Checked);
	}

	// Token: 0x06010304 RID: 66308 RVA: 0x00473D08 File Offset: 0x00471F08
	private void RefreshChildBtn()
	{
		base.GetButton(8).RootUIComp.Get().SetUIActive(!ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode());
	}

	// Token: 0x06010305 RID: 66309 RVA: 0x00473D3C File Offset: 0x00471F3C
	private void RefreshAgeBtn()
	{
		base.GetButton(4).RootUIComp.Get().SetUIActive(!ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode());
	}

	// Token: 0x06010306 RID: 66310 RVA: 0x00473D6F File Offset: 0x00471F6F
	private void RefreshCopyRightItem()
	{
		base.GetItem(16).SetUIActive(!ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode());
	}

	// Token: 0x06010307 RID: 66311 RVA: 0x00473D8B File Offset: 0x00471F8B
	private void RefreshVersionText()
	{
		base.GetText(9).SetText(UCSharpBlueprintFunctionLibrary.HasCSharpEnvironmentInitialized() ? (Singleton<BaseConfigController>.Instance.GetVersionString() + " *") : (Singleton<BaseConfigController>.Instance.GetVersionString() ?? ""), true);
	}

	// Token: 0x06010308 RID: 66312 RVA: 0x00473DCC File Offset: 0x00471FCC
	private void RefreshLogo()
	{
		string logoPathByLanguage = ConfigBase<UiResourceConfig>.Instance.GetLogoPathByLanguage("LoginLogo");
		base.SetTextureByPath(logoPathByLanguage, base.GetTexture(17), null, null);
	}

	// Token: 0x06010309 RID: 66313 RVA: 0x00473E04 File Offset: 0x00472004
	private void RefreshServerName()
	{
		string currentSelectServerName = ModelBase<LoginServerModel>.Instance.GetCurrentSelectServerName();
		base.GetText(15).SetText(currentSelectServerName, true);
	}

	// Token: 0x0601030A RID: 66314 RVA: 0x00473E2B File Offset: 0x0047202B
	private void RefreshPostViewRedPoint()
	{
	}

	// Token: 0x0601030B RID: 66315 RVA: 0x00473E30 File Offset: 0x00472030
	private void RefreshNoticeItemState()
	{
		base.GetButton(11).RootUIComp.Get().SetUIActive(ControllerBase<LoginController>.Instance.IsSdkLoginMode() && ModelBase<LoginModel>.Instance.IsSdkLoggedIn());
	}

	// Token: 0x0601030C RID: 66316 RVA: 0x00473E70 File Offset: 0x00472070
	private void RefreshLoginState(bool value)
	{
		UUIButtonComponent button = base.GetButton(2);
		UUIButtonComponent button2 = base.GetButton(3);
		bool flag = Singleton<BaseConfigController>.Instance.GetIosAuditFirstDownloadTip() || Singleton<BaseConfigController>.Instance.GetIosAuditFirstDownloadTipWithSkip();
		if (ControllerBase<LoginController>.Instance.IsSdkLoginMode())
		{
			button.RootUIComp.Get().SetUIActive(value && !Singleton<CloudGameManager>.Instance.IsCloudGame && !flag);
			button2.RootUIComp.Get().SetUIActive(!value);
			if (!value)
			{
				base.GetItem(18).SetUIActive(value);
			}
		}
		else
		{
			button.RootUIComp.Get().SetUIActive(!Singleton<CloudGameManager>.Instance.IsCloudGame && !flag);
			button2.RootUIComp.Get().SetUIActive(false);
		}
		if (!value && ControllerBase<LoginController>.Instance.IsGlobalSdkLoginMode())
		{
			base.GetButton(14).RootUIComp.Get().SetUIActive(false);
		}
		this.RefreshAccountButton(value);
		this.RefreshQRCodeLoginBtn(value);
		this.RefreshNoticeItemState();
		PreDownloadButtonItemA preDownloadItem = this.PreDownloadItem;
		if (preDownloadItem != null)
		{
			preDownloadItem.Refresh(value);
		}
		this.CurLoginState = value;
		this.RefreshMenuBtnState();
	}

	// Token: 0x0601030D RID: 66317 RVA: 0x00473F9D File Offset: 0x0047219D
	private void ShowAgeTipBtnClickCallBack()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LoginAgeTipView, LoginAgeTipView.ELoginShowType.AgeTip, null);
		Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(true, "");
	}

	// Token: 0x0601030E RID: 66318 RVA: 0x00473FC5 File Offset: 0x004721C5
	private void OnPreDownloadUpdate()
	{
		PreDownloadButtonItemA preDownloadItem = this.PreDownloadItem;
		if (preDownloadItem == null)
		{
			return;
		}
		preDownloadItem.Refresh(this.CurLoginState);
	}

	// Token: 0x04007C46 RID: 31814
	private bool IsAgree;

	// Token: 0x04007C47 RID: 31815
	private PreDownloadButtonItemA PreDownloadItem;

	// Token: 0x04007C48 RID: 31816
	private bool CurLoginState;

	// Token: 0x04007C49 RID: 31817
	private bool NeedTickDownLoad;

	// Token: 0x04007C4A RID: 31818
	private bool IsSdkLoginInFlight;

	// Token: 0x04007C4B RID: 31819
	private bool IsBindRegionPending;

	// Token: 0x04007C4C RID: 31820
	private bool IsPostSdkLoginPending;

	// Token: 0x04007C4D RID: 31821
	private bool IsCharacterLoginInFlight;

	// Token: 0x04007C4E RID: 31822
	private bool IsMenuViewOpenRequested;

	// Token: 0x04007C4F RID: 31823
	private bool MenuBtnEnableApplied;

	// Token: 0x04007C50 RID: 31824
	private readonly Action RepairBtnClick = delegate()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ToolWindowView, null, null);
	};

	// Token: 0x04007C51 RID: 31825
	private readonly Action UserButtonClick = delegate()
	{
		bool flag = false;
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			SdkAgreementLinkData[] agreement = ControllerBase<KuroSdkController>.Instance.GetAgreement();
			for (int i = 0; i < agreement.Length; i++)
			{
				if (agreement[i].link.Contains("agreement_public"))
				{
					string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("UserTitle"), null);
					ControllerBase<KuroSdkController>.Instance.SdkOpenUrlWnd(localTextNew, agreement[i].link, true, false, true);
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.XXJ, "打开用户协议", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.OpenView(EUiViewName.LoginAgeTipView, LoginAgeTipView.ELoginShowType.UserAgreement, null);
			Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(true, "");
		}
	};

	// Token: 0x04007C52 RID: 31826
	private readonly Action SecretButtonClick = delegate()
	{
		bool flag = false;
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			SdkAgreementLinkData[] agreement = ControllerBase<KuroSdkController>.Instance.GetAgreement();
			for (int i = 0; i < agreement.Length; i++)
			{
				if (agreement[i].link.Contains("personal_privacy"))
				{
					string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("PrivacyTitle"), null);
					ControllerBase<KuroSdkController>.Instance.SdkOpenUrlWnd(localTextNew, agreement[i].link, true, false, true);
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.XXJ, "打开隐私政策", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.OpenView(EUiViewName.LoginAgeTipView, LoginAgeTipView.ELoginShowType.PrivacyAgreement, null);
			Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(true, "");
		}
	};

	// Token: 0x04007C53 RID: 31827
	private readonly Action ChildPrivacyButtonClick = delegate()
	{
		bool flag = false;
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			SdkAgreementLinkData[] agreement = ControllerBase<KuroSdkController>.Instance.GetAgreement();
			for (int i = 0; i < agreement.Length; i++)
			{
				if (agreement[i].link.Contains("child_privacy"))
				{
					string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("ChildPrivacyTitle"), null);
					ControllerBase<KuroSdkController>.Instance.SdkOpenUrlWnd(localTextNew, agreement[i].link, true, false, true);
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.XXJ, "打开儿童隐私政策", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.OpenView(EUiViewName.LoginAgeTipView, LoginAgeTipView.ELoginShowType.ChildPrivacyAgreement, null);
			Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(true, "");
		}
	};

	// Token: 0x04007C54 RID: 31828
	private readonly Action OnClickNoticeBtn = delegate()
	{
		ControllerBase<KuroSdkController>.Instance.OpenNotice(EOpenNoticeStage.BeforeLogin);
	};

	// Token: 0x04007C55 RID: 31829
	private readonly Action OnExitGameClick = delegate()
	{
		ControllerBase<ConfirmBoxController>.Instance.ShowExitGameConfirmBox();
	};

	// Token: 0x04007C56 RID: 31830
	private readonly Action OnClickServerBtn = delegate()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LoginServerView, null, null);
	};

	// Token: 0x04007C57 RID: 31831
	private readonly Action OnGetLoginPlayerInfo = delegate()
	{
	};

	// Token: 0x02008491 RID: 33937
	[NullableContext(0)]
	private enum ELoginOfficialChildCom
	{
		// Token: 0x0402CE8A RID: 183946
		FullLoginBtn,
		// Token: 0x0402CE8B RID: 183947
		LogoutBtn,
		// Token: 0x0402CE8C RID: 183948
		RepairBtn,
		// Token: 0x0402CE8D RID: 183949
		LoginBtn,
		// Token: 0x0402CE8E RID: 183950
		AgeTipButton,
		// Token: 0x0402CE8F RID: 183951
		LockExtendToggle,
		// Token: 0x0402CE90 RID: 183952
		UserButton,
		// Token: 0x0402CE91 RID: 183953
		SecretButton,
		// Token: 0x0402CE92 RID: 183954
		ChildPrivacyButton,
		// Token: 0x0402CE93 RID: 183955
		VersionText,
		// Token: 0x0402CE94 RID: 183956
		LoginText,
		// Token: 0x0402CE95 RID: 183957
		NoticeBtn,
		// Token: 0x0402CE96 RID: 183958
		ExitGameButton,
		// Token: 0x0402CE97 RID: 183959
		NoticeRedPoint,
		// Token: 0x0402CE98 RID: 183960
		ServerBtn,
		// Token: 0x0402CE99 RID: 183961
		ServerName,
		// Token: 0x0402CE9A RID: 183962
		CopyRightItem,
		// Token: 0x0402CE9B RID: 183963
		LoginLogo,
		// Token: 0x0402CE9C RID: 183964
		EnterGameItem,
		// Token: 0x0402CE9D RID: 183965
		MobilePreDownloadBtn,
		// Token: 0x0402CE9E RID: 183966
		QRCodeLoginBtn,
		// Token: 0x0402CE9F RID: 183967
		DownLoadBtn,
		// Token: 0x0402CEA0 RID: 183968
		DownLoadItem,
		// Token: 0x0402CEA1 RID: 183969
		DownLoadBarSprite,
		// Token: 0x0402CEA2 RID: 183970
		DownLoadProgressText,
		// Token: 0x0402CEA3 RID: 183971
		DownLoadSpeedText,
		// Token: 0x0402CEA4 RID: 183972
		PatchText,
		// Token: 0x0402CEA5 RID: 183973
		MenuBtn
	}
}
