using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Launcher.Action;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.HotPatchKuroSdk;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.PlayerInput;
using CSharpScript.Launcher.Ui.SdkView;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004519 RID: 17689
	[NullableContext(1)]
	[Nullable(0)]
	public class HotFixUiView : LaunchComponentsAction
	{
		// Token: 0x0602E98E RID: 190862 RVA: 0x00B0A644 File Offset: 0x00B08844
		public UniTask InitAsync(UObject worldContext)
		{
			HotFixUiView.<InitAsync>d__10 <InitAsync>d__;
			<InitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAsync>d__.<>4__this = this;
			<InitAsync>d__.worldContext = worldContext;
			<InitAsync>d__.<>1__state = -1;
			<InitAsync>d__.<>t__builder.Start<HotFixUiView.<InitAsync>d__10>(ref <InitAsync>d__);
			return <InitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E98F RID: 190863 RVA: 0x00B0A68F File Offset: 0x00B0888F
		public void SetProtocolViewViewState(bool state)
		{
			SdkProtocolView protocolView = this.ProtocolView;
			if (protocolView == null)
			{
				return;
			}
			protocolView.SetActive(state);
		}

		// Token: 0x0602E990 RID: 190864 RVA: 0x00B0A6A4 File Offset: 0x00B088A4
		public UniTask ShowProtocolView(SdkProtocolViewData data)
		{
			HotFixUiView.<ShowProtocolView>d__12 <ShowProtocolView>d__;
			<ShowProtocolView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowProtocolView>d__.<>4__this = this;
			<ShowProtocolView>d__.data = data;
			<ShowProtocolView>d__.<>1__state = -1;
			<ShowProtocolView>d__.<>t__builder.Start<HotFixUiView.<ShowProtocolView>d__12>(ref <ShowProtocolView>d__);
			return <ShowProtocolView>d__.<>t__builder.Task;
		}

		// Token: 0x0602E991 RID: 190865 RVA: 0x00B0A6F0 File Offset: 0x00B088F0
		protected UniTask LoadResourceAsync(UObject worldContext)
		{
			HotFixUiView.<LoadResourceAsync>d__13 <LoadResourceAsync>d__;
			<LoadResourceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadResourceAsync>d__.<>4__this = this;
			<LoadResourceAsync>d__.worldContext = worldContext;
			<LoadResourceAsync>d__.<>1__state = -1;
			<LoadResourceAsync>d__.<>t__builder.Start<HotFixUiView.<LoadResourceAsync>d__13>(ref <LoadResourceAsync>d__);
			return <LoadResourceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E992 RID: 190866 RVA: 0x00B0A73C File Offset: 0x00B0893C
		private UniTask LoadHotFixLogo()
		{
			HotFixUiView.<LoadHotFixLogo>d__14 <LoadHotFixLogo>d__;
			<LoadHotFixLogo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadHotFixLogo>d__.<>4__this = this;
			<LoadHotFixLogo>d__.<>1__state = -1;
			<LoadHotFixLogo>d__.<>t__builder.Start<HotFixUiView.<LoadHotFixLogo>d__14>(ref <LoadHotFixLogo>d__);
			return <LoadHotFixLogo>d__.<>t__builder.Task;
		}

		// Token: 0x0602E993 RID: 190867 RVA: 0x00B0A780 File Offset: 0x00B08980
		protected override void OnStart()
		{
			base.GetButton(12).OnClickCallBack.Bind(new Action(this.OnBtnNoticeClick));
			base.GetButton(18).OnClickCallBack.Bind(new Action(this.OnBtnLoginClick));
			base.GetButton(14).OnClickCallBack.Bind(new Action(this.OnBtnExitClick));
			base.GetButton(16).OnClickCallBack.Bind(new Action(this.OnBtnLogOutClick));
			this.SetLogOutButtonActive(false);
			this.SetExitButtonActive(false);
			this.SetLoginInButtonActive(false);
		}

		// Token: 0x0602E994 RID: 190868 RVA: 0x00B0A81C File Offset: 0x00B08A1C
		protected override void OnBeforeDestroy()
		{
			if (this.TickManager != null)
			{
				this.TickManager = null;
			}
			if (this.ProgressText != null)
			{
				this.ProgressText.RemoveGamepadChange();
				this.ProgressText = null;
			}
			if (this.PatchText != null)
			{
				this.PatchText = null;
			}
			if (this.SpeedText != null)
			{
				this.SpeedText = null;
			}
			if (this.ProgressBar != null)
			{
				this.ProgressBar = null;
			}
			base.GetButton(12).OnClickCallBack.Unbind();
		}

		// Token: 0x0602E995 RID: 190869 RVA: 0x00B0A891 File Offset: 0x00B08A91
		private void OnUiRootLoadCallback(AActor actor)
		{
			this.UiRoot = actor;
		}

		// Token: 0x0602E996 RID: 190870 RVA: 0x00B0A89A File Offset: 0x00B08A9A
		private void OnViewLoadCallback(AActor actor)
		{
			base.SetRootActorLaunchComponentsAction(actor);
			this.SetContainerItemActive(false);
		}

		// Token: 0x0602E997 RID: 190871 RVA: 0x00B0A8AC File Offset: 0x00B08AAC
		protected override void OnShow()
		{
			if (this.ProgressText == null)
			{
				Dictionary<string, ValueTuple<string, actionMappings>> dictionary = new Dictionary<string, ValueTuple<string, actionMappings>>();
				dictionary["DownloadContinue"] = new ValueTuple<string, actionMappings>("Ps5_Cilck_Continue", actionMappings.手柄右边下键);
				Dictionary<string, ValueTuple<string, actionMappings>> gamepadDataMap = dictionary;
				this.ProgressText = new HotFixListenDeviceSwitchText(base.GetText(4), gamepadDataMap);
				this.ProgressText.AddGamepadChange();
			}
			this.PatchText = base.GetText(8);
			this.SpeedText = base.GetText(7);
			this.ProgressBar = base.GetTexture(3);
			this.ShowAppInfoText(this.WorldContext);
			this.SetRepairButtonText("PatchClearbutton");
			this.SetRepairButtonEnable(false);
			this.SetRepairButtonCallBack(delegate
			{
				this.SetToolWindowActive(true);
			});
			HotFixManager.SetLocalText(base.GetText(13), "Notice_Btn_Text", Array.Empty<string>());
			HotFixManager.SetLocalText(base.GetText(15), "Exit_Btn_Text", Array.Empty<string>());
			HotFixManager.SetLocalText(base.GetText(17), "Exchange_Btn_Text", Array.Empty<string>());
			HotFixManager.SetLocalText(base.GetText(19), "SignIn_Btn_Text", Array.Empty<string>());
			this.SetNoticeBtnActive(!Singleton<Platform>.Instance.IsAndroidPlatform());
		}

		// Token: 0x0602E998 RID: 190872 RVA: 0x00B0A9C4 File Offset: 0x00B08BC4
		public void SetContainerItemActive(bool value)
		{
			UUIItem item = base.GetItem(0);
			if (value && value != item.IsUIActiveSelf())
			{
				this.SequencePlayer.PlaySequence("Start", null);
			}
			base.GetItem(0).SetUIActive(value);
		}

		// Token: 0x0602E999 RID: 190873 RVA: 0x00B0AA04 File Offset: 0x00B08C04
		public void UpdateProgressRate(float rate)
		{
			this.SetProgressActive(true);
			this.ProgressBar.SetFillAmount(rate);
		}

		// Token: 0x0602E99A RID: 190874 RVA: 0x00B0AA19 File Offset: 0x00B08C19
		public void SetProgressActive(bool value)
		{
			base.GetTexture(2).SetUIActive(value);
			this.ProgressBar.SetUIActive(value);
		}

		// Token: 0x0602E99B RID: 190875 RVA: 0x00B0AA34 File Offset: 0x00B08C34
		public void SetConfirmationItemActive(bool value)
		{
			base.GetElement<HotFixPopupUiView>(100).SetActive(value);
		}

		// Token: 0x0602E99C RID: 190876 RVA: 0x00B0AA44 File Offset: 0x00B08C44
		public void SetToolWindowActive(bool value)
		{
			base.GetElement<HotFixToolWindowView>(101).SetActive(value);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "SetToolWindowActive";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", value);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602E99D RID: 190877 RVA: 0x00B0AA88 File Offset: 0x00B08C88
		public void SetDownLoadActive(bool value)
		{
			base.GetElement<HotFixDownLoadView>(102).SetActive(value);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "SetDownLoadActive";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", value);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602E99E RID: 190878 RVA: 0x00B0AACC File Offset: 0x00B08CCC
		public void SetFreeSpaceTipsPopActive(bool value)
		{
			base.GetElement<HotFixDownLoadFreeSpaceTipsView>(103).SetActive(value);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "SetHotFixDownLoadFreeSpaceTipsViewActive";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", value);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602E99F RID: 190879 RVA: 0x00B0AB10 File Offset: 0x00B08D10
		[NullableContext(2)]
		private void SetClearSubPackagePopActive(bool value, Action onCloseCallBack = null)
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "HotFixDownSubPackageDownLoadMobileClearPopView";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", value);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			HotFixDownSubPackageDownLoadMobileClearPopView element = base.GetElement<HotFixDownSubPackageDownLoadMobileClearPopView>(104);
			element.SetActive(value);
			if (value && onCloseCallBack != null)
			{
				element.OnCloseCallBack = onCloseCallBack;
			}
		}

		// Token: 0x0602E9A0 RID: 190880 RVA: 0x00B0AB64 File Offset: 0x00B08D64
		private void ShowClearSubPackagePopConfirmBox(Action onConfirmBox)
		{
			Singleton<LauncherLog>.Instance.Info("ShowClearSubPackagePopConfirmBox", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.SetConfirmationItemActive(true);
			this.SetConfirmationTitle("HotFixTipsTitle");
			this.SetConfirmationContent("HotFixSubPackageClearConfirmContent", Array.Empty<string>());
			this.SetConfirmationLeftButtonActive(true);
			this.SetConfirmationLeftButtonText("HotFixCancel");
			this.SetConfirmationLeftButtonCallBack(delegate
			{
				this.SetConfirmationItemActive(false);
				this.SetClearSubPackagePopActive(true, null);
			});
			this.SetConfirmationMiddleButtonActive(false);
			this.SetConfirmationRightButtonActive(true);
			this.SetConfirmationRightButtonText("ConfirmText");
			this.SetConfirmationRightButtonCallBack(delegate
			{
				this.SetConfirmationItemActive(false);
				onConfirmBox();
			});
			this.SetConfirmationCloseButtonActive(true);
			this.SetConfirmationCloseButtonCallBack(delegate
			{
				this.SetConfirmationItemActive(false);
				this.SetClearSubPackagePopActive(true, null);
			});
		}

		// Token: 0x0602E9A1 RID: 190881 RVA: 0x00B0AC28 File Offset: 0x00B08E28
		public void SetNoticeBtnActive(bool value)
		{
			base.GetText(13).SetUIActive(value);
			base.GetButton(12).SetSelfInteractive(value);
			base.GetButton(12).RootUIComp.Get().SetUIActive(value);
		}

		// Token: 0x0602E9A2 RID: 190882 RVA: 0x00B0AC6C File Offset: 0x00B08E6C
		public void SetProgressLeftTips(string tableId, params string[] args)
		{
			this.ProgressText.SetLocalText(tableId, args);
			this.PatchText.SetText("", true);
			this.SpeedText.SetText("", true);
		}

		// Token: 0x0602E9A3 RID: 190883 RVA: 0x00B0AC9D File Offset: 0x00B08E9D
		public void SetProgressText(string tableId, params string[] args)
		{
			this.ProgressText.SetLocalText(tableId, args);
		}

		// Token: 0x0602E9A4 RID: 190884 RVA: 0x00B0ACAC File Offset: 0x00B08EAC
		public void SetPatchText(string tableId, params string[] args)
		{
			HotFixManager.SetLocalText(this.PatchText, tableId, args);
		}

		// Token: 0x0602E9A5 RID: 190885 RVA: 0x00B0ACBB File Offset: 0x00B08EBB
		public void SetSpeedText(string tableId, params string[] args)
		{
			HotFixManager.SetLocalText(this.SpeedText, tableId, args);
		}

		// Token: 0x0602E9A6 RID: 190886 RVA: 0x00B0ACCA File Offset: 0x00B08ECA
		public void SetProgressLeftActive(bool value)
		{
			this.ProgressText.SetUiActive(value);
			this.PatchText.SetUIActive(value);
			this.SpeedText.SetUIActive(value);
		}

		// Token: 0x0602E9A7 RID: 190887 RVA: 0x00B0ACF0 File Offset: 0x00B08EF0
		public void SetProgressRightTips(string tableId)
		{
			HotFixManager.SetLocalText(base.GetText(5), tableId, Array.Empty<string>());
		}

		// Token: 0x0602E9A8 RID: 190888 RVA: 0x00B0AD04 File Offset: 0x00B08F04
		public void SetProgressRightActive(bool value)
		{
			base.GetText(5).SetUIActive(value);
		}

		// Token: 0x0602E9A9 RID: 190889 RVA: 0x00B0AD13 File Offset: 0x00B08F13
		public void SetConfirmationTitle(string tableId)
		{
			base.GetElement<HotFixPopupUiView>(100).SetConfirmationTitle(tableId);
		}

		// Token: 0x0602E9AA RID: 190890 RVA: 0x00B0AD23 File Offset: 0x00B08F23
		public void SetConfirmationContent(string tableId, params string[] args)
		{
			base.GetElement<HotFixPopupUiView>(100).SetConfirmationContent(tableId, args);
		}

		// Token: 0x0602E9AB RID: 190891 RVA: 0x00B0AD34 File Offset: 0x00B08F34
		public void SetConfirmationLeftButtonCallBack(Action callback)
		{
			base.GetElement<HotFixPopupUiView>(100).SetConfirmationLeftButtonCallBack(callback);
		}

		// Token: 0x0602E9AC RID: 190892 RVA: 0x00B0AD44 File Offset: 0x00B08F44
		public void SetConfirmationRightButtonCallBack(Action callback)
		{
			base.GetElement<HotFixPopupUiView>(100).SetConfirmationRightButtonCallBack(callback);
		}

		// Token: 0x0602E9AD RID: 190893 RVA: 0x00B0AD54 File Offset: 0x00B08F54
		[NullableContext(2)]
		public void SetConfirmationLeftButtonText(string tableId)
		{
			base.GetElement<HotFixPopupUiView>(100).SetConfirmationLeftButtonText(tableId);
		}

		// Token: 0x0602E9AE RID: 190894 RVA: 0x00B0AD64 File Offset: 0x00B08F64
		[NullableContext(2)]
		public void SetConfirmationRightButtonText(string tableId)
		{
			base.GetElement<HotFixPopupUiView>(100).SetConfirmationRightButtonText(tableId);
		}

		// Token: 0x0602E9AF RID: 190895 RVA: 0x00B0AD74 File Offset: 0x00B08F74
		public void SetConfirmationLeftButtonActive(bool value)
		{
			base.GetElement<HotFixPopupUiView>(100).SetConfirmationLeftButtonActive(value);
		}

		// Token: 0x0602E9B0 RID: 190896 RVA: 0x00B0AD84 File Offset: 0x00B08F84
		public void SetConfirmationRightButtonActive(bool value)
		{
			base.GetElement<HotFixPopupUiView>(100).SetConfirmationRightButtonActive(value);
		}

		// Token: 0x0602E9B1 RID: 190897 RVA: 0x00B0AD94 File Offset: 0x00B08F94
		public void SetConfirmationMiddleButtonCallBack(Action callback)
		{
			base.GetElement<HotFixPopupUiView>(100).SetConfirmationMiddleButtonCallBack(callback);
		}

		// Token: 0x0602E9B2 RID: 190898 RVA: 0x00B0ADA4 File Offset: 0x00B08FA4
		[NullableContext(2)]
		public void SetConfirmationMiddleButtonText(string tableId)
		{
			base.GetElement<HotFixPopupUiView>(100).SetConfirmationMiddleButtonText(tableId);
		}

		// Token: 0x0602E9B3 RID: 190899 RVA: 0x00B0ADB4 File Offset: 0x00B08FB4
		public void SetConfirmationMiddleButtonActive(bool value)
		{
			base.GetElement<HotFixPopupUiView>(100).SetConfirmationMiddleButtonActive(value);
		}

		// Token: 0x0602E9B4 RID: 190900 RVA: 0x00B0ADC4 File Offset: 0x00B08FC4
		public void SetConfirmationCloseButtonCallBack(Action callback)
		{
			base.GetElement<HotFixPopupUiView>(100).SetConfirmationCloseButtonCallBack(callback);
		}

		// Token: 0x0602E9B5 RID: 190901 RVA: 0x00B0ADD4 File Offset: 0x00B08FD4
		public void SetConfirmationCloseButtonActive(bool value)
		{
			base.GetElement<HotFixPopupUiView>(100).SetConfirmationCloseButtonActive(value);
		}

		// Token: 0x0602E9B6 RID: 190902 RVA: 0x00B0ADE4 File Offset: 0x00B08FE4
		public void SetMaskButtonCallBack(Action callback)
		{
			base.GetButton(10).OnClickCallBack.Unbind();
			base.GetButton(10).OnClickCallBack.Bind(callback);
		}

		// Token: 0x0602E9B7 RID: 190903 RVA: 0x00B0AE0B File Offset: 0x00B0900B
		public void SetRepairButtonText(string tableId)
		{
			HotFixManager.SetLocalText(base.GetText(11), tableId, Array.Empty<string>());
		}

		// Token: 0x0602E9B8 RID: 190904 RVA: 0x00B0AE20 File Offset: 0x00B09020
		public void SetRepairButtonEnable(bool bEnable)
		{
			base.GetButton(9).SetSelfInteractive(bEnable);
		}

		// Token: 0x0602E9B9 RID: 190905 RVA: 0x00B0AE30 File Offset: 0x00B09030
		public void SetLoginInButtonActive(bool bEnable)
		{
			base.GetButton(18).RootUIComp.Get().SetUIActive(bEnable);
		}

		// Token: 0x0602E9BA RID: 190906 RVA: 0x00B0AE58 File Offset: 0x00B09058
		public void SetExitButtonActive(bool bEnable)
		{
			base.GetButton(14).RootUIComp.Get().SetUIActive(bEnable);
		}

		// Token: 0x0602E9BB RID: 190907 RVA: 0x00B0AE80 File Offset: 0x00B09080
		public void SetLogOutButtonActive(bool bEnable)
		{
			base.GetButton(16).RootUIComp.Get().SetUIActive(bEnable);
		}

		// Token: 0x0602E9BC RID: 190908 RVA: 0x00B0AEA8 File Offset: 0x00B090A8
		public void SetRepairButtonCallBack(Action callback)
		{
			base.GetButton(9).OnClickCallBack.Unbind();
			base.GetButton(9).OnClickCallBack.Bind(callback);
		}

		// Token: 0x0602E9BD RID: 190909 RVA: 0x00B0AED0 File Offset: 0x00B090D0
		public bool GetLoginButtonActive()
		{
			return base.GetButton(18).RootUIComp.Get().IsUIActiveSelf();
		}

		// Token: 0x0602E9BE RID: 190910 RVA: 0x00B0AEF7 File Offset: 0x00B090F7
		public void ShowAppInfoText(UObject worldContext)
		{
			base.GetText(1).SetText(UCSharpBlueprintFunctionLibrary.HasCSharpEnvironmentInitialized() ? (Singleton<BaseConfigController>.Instance.GetVersionString() + " *") : (Singleton<BaseConfigController>.Instance.GetVersionString() ?? ""), true);
		}

		// Token: 0x0602E9BF RID: 190911 RVA: 0x00B0AF38 File Offset: 0x00B09138
		public UniTask Hide()
		{
			HotFixUiView.<Hide>d__59 <Hide>d__;
			<Hide>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Hide>d__.<>4__this = this;
			<Hide>d__.<>1__state = -1;
			<Hide>d__.<>t__builder.Start<HotFixUiView.<Hide>d__59>(ref <Hide>d__);
			return <Hide>d__.<>t__builder.Task;
		}

		// Token: 0x0602E9C0 RID: 190912 RVA: 0x00B0AF7C File Offset: 0x00B0917C
		public override void Destroy()
		{
			base.Destroy();
			if (this.UiRoot != null)
			{
				ULGUIBPLibrary.DestroyActorWithHierarchy(this.UiRoot, true);
				this.UiRoot = null;
			}
			Singleton<HotPatchInputManager>.Instance.Destroy();
			Singleton<HotPatchEventSystem>.Instance.Destroy();
			if (this.WorldContext != null)
			{
				this.WorldContext = null;
			}
		}

		// Token: 0x0602E9C1 RID: 190913 RVA: 0x00B0AFCD File Offset: 0x00B091CD
		public void RefreshLoginStateOnLoginSuccess()
		{
			this.ShowSdkLogInState();
		}

		// Token: 0x0602E9C2 RID: 190914 RVA: 0x00B0AFD5 File Offset: 0x00B091D5
		public void RefreshLoginStateBeforeLogin()
		{
			this.ShowSdkLogOutState();
		}

		// Token: 0x0602E9C3 RID: 190915 RVA: 0x00B0AFDD File Offset: 0x00B091DD
		private void OnBtnNoticeClick()
		{
			HotFixManager.ShowNoticeWindowByUser();
		}

		// Token: 0x0602E9C4 RID: 190916 RVA: 0x00B0AFE4 File Offset: 0x00B091E4
		public void OnBtnLoginClick()
		{
			Singleton<LauncherLog>.Instance.Info("HotFixView OnBtnLoginClick", default(ReadOnlySpan<ValueTuple<string, object>>));
			HotFixManager.SdkLogin(new Action(this.RefreshLoginStateOnLoginSuccess), true);
		}

		// Token: 0x0602E9C5 RID: 190917 RVA: 0x00B0B01C File Offset: 0x00B0921C
		private void OnBtnExitClick()
		{
			Singleton<LauncherLog>.Instance.Info("HotFixView OnBtnExitClick", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroSDKExit;
			UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
		}

		// Token: 0x0602E9C6 RID: 190918 RVA: 0x00B0B050 File Offset: 0x00B09250
		private void OnBtnLogOutClick()
		{
			Singleton<LauncherLog>.Instance.Warn("HotFixView OnBtnLogOutClick,不应该触发", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602E9C7 RID: 190919 RVA: 0x00B0B078 File Offset: 0x00B09278
		private void ShowSdkLogOutState()
		{
			Singleton<LauncherLog>.Instance.Info("HotFixView ShowSdkLogOutState", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (LauncherSdk.canUseSdk() && !Singleton<Platform>.Instance.IsCloudGame())
			{
				this.SetLoginInButtonActive(true);
			}
			this.SetExitButtonActive(false);
			this.SetLogOutButtonActive(false);
		}

		// Token: 0x0602E9C8 RID: 190920 RVA: 0x00B0B0C8 File Offset: 0x00B092C8
		private void ShowSdkLogInState()
		{
			Singleton<LauncherLog>.Instance.Info("HotFixView ShowSdkLogInState", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.SetProgressActive(true);
			this.SetLoginInButtonActive(false);
		}

		// Token: 0x0401A792 RID: 108434
		[Nullable(2)]
		protected AActor UiRoot;

		// Token: 0x0401A793 RID: 108435
		[Nullable(2)]
		protected UObject WorldContext;

		// Token: 0x0401A794 RID: 108436
		[Nullable(2)]
		private HotFixListenDeviceSwitchText ProgressText;

		// Token: 0x0401A795 RID: 108437
		[Nullable(2)]
		private UUIText PatchText;

		// Token: 0x0401A796 RID: 108438
		[Nullable(2)]
		private UUIText SpeedText;

		// Token: 0x0401A797 RID: 108439
		[Nullable(2)]
		private UUITexture ProgressBar;

		// Token: 0x0401A798 RID: 108440
		[Nullable(2)]
		private UKuroTickManager TickManager;

		// Token: 0x0401A799 RID: 108441
		[Nullable(2)]
		private SdkProtocolView ProtocolView;

		// Token: 0x0401A79A RID: 108442
		private const string LogoName = "WutheringWave_";

		// Token: 0x0200A732 RID: 42802
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04033E33 RID: 212531
			public const int ContainerItem = 0;

			// Token: 0x04033E34 RID: 212532
			public const int VersionText = 1;

			// Token: 0x04033E35 RID: 212533
			public const int ProgressBarBg = 2;

			// Token: 0x04033E36 RID: 212534
			public const int ProgressBar = 3;

			// Token: 0x04033E37 RID: 212535
			public const int ProgressText = 4;

			// Token: 0x04033E38 RID: 212536
			public const int BottomText = 5;

			// Token: 0x04033E39 RID: 212537
			public const int Logo = 6;

			// Token: 0x04033E3A RID: 212538
			public const int SpeedText = 7;

			// Token: 0x04033E3B RID: 212539
			public const int PatchText = 8;

			// Token: 0x04033E3C RID: 212540
			public const int ButtonRepair = 9;

			// Token: 0x04033E3D RID: 212541
			public const int ButtonMask = 10;

			// Token: 0x04033E3E RID: 212542
			public const int RepairText = 11;

			// Token: 0x04033E3F RID: 212543
			public const int ButtonNotice = 12;

			// Token: 0x04033E40 RID: 212544
			public const int NoticeText = 13;

			// Token: 0x04033E41 RID: 212545
			public const int ButtonExit = 14;

			// Token: 0x04033E42 RID: 212546
			public const int ExitText = 15;

			// Token: 0x04033E43 RID: 212547
			public const int ButtonLogOut = 16;

			// Token: 0x04033E44 RID: 212548
			public const int LogOutText = 17;

			// Token: 0x04033E45 RID: 212549
			public const int ButtonLoginIn = 18;

			// Token: 0x04033E46 RID: 212550
			public const int LoginInText = 19;

			// Token: 0x04033E47 RID: 212551
			public const int PopUi = 100;

			// Token: 0x04033E48 RID: 212552
			public const int ToolPop = 101;

			// Token: 0x04033E49 RID: 212553
			public const int DownLoadPop = 102;

			// Token: 0x04033E4A RID: 212554
			public const int FreeSpaceTipsPop = 103;

			// Token: 0x04033E4B RID: 212555
			public const int ClearSubPackagePop = 104;
		}
	}
}
