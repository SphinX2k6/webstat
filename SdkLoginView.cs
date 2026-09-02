using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform.PlatformSdk;
using UnrealEngine;

// Token: 0x02002976 RID: 10614
public class SdkLoginView : UiViewBase
{
	// Token: 0x06015174 RID: 86388 RVA: 0x005D5BDC File Offset: 0x005D3DDC
	[NullableContext(1)]
	public SdkLoginView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015175 RID: 86389 RVA: 0x005D5BE8 File Offset: 0x005D3DE8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickCancelButton)),
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickCreateButton)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickLoginButton))
		};
	}

	// Token: 0x06015176 RID: 86390 RVA: 0x005D5CC4 File Offset: 0x005D3EC4
	protected override void OnAfterShow()
	{
		PlatformReportSelectLogin eventData = new PlatformReportSelectLogin();
		Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ReportToThirdParty(eventData);
	}

	// Token: 0x06015177 RID: 86391 RVA: 0x005D5CE7 File Offset: 0x005D3EE7
	private void OnClickCancelButton()
	{
		ModelBase<LoginModel>.Instance.SetSdkLoginState(LoginDefine.ESdkLoginState.Logout);
		base.CloseMe(null);
	}

	// Token: 0x06015178 RID: 86392 RVA: 0x005D5CFC File Offset: 0x005D3EFC
	private void OnClickCreateButton()
	{
		SdkPopUpViewData sdkPopUpViewData = new SdkPopUpViewData();
		sdkPopUpViewData.ViewType = ESdkPopUpViewType.Creating;
		sdkPopUpViewData.NeedMask = true;
		sdkPopUpViewData.Text = ConfigMultiTextLang.GetLocalTextNew("CreatingAccount", null);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SdkTipsMiddlePopUpView, sdkPopUpViewData, delegate(bool isSuccess, int _)
		{
			PlatformReportCreateNewAccount eventData = new PlatformReportCreateNewAccount();
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ReportToThirdParty(eventData);
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().BindAccountThenLogin(delegate(string msg, bool needReLogin, bool needSelectLoginFunction, [Nullable(2)] ILoginResponseData data)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.SdkTipsMiddlePopUpView, null);
				if (data != null)
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.SdkLoginView, null);
					ControllerBase<LoginController>.Instance.OnSdkLoginResult(data.code, data.cuid, data.username);
					return;
				}
				if (data == null && msg != "" && msg != PlatformSdkServerMsg.BadHttp.ToEnumString())
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(msg);
					return;
				}
				if (data == null)
				{
					ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SdkServerNetworkError);
					ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
				}
			}, "", "");
		});
	}

	// Token: 0x06015179 RID: 86393 RVA: 0x005D5D64 File Offset: 0x005D3F64
	private void OnClickLoginButton()
	{
		PlatformReportClickOldAccount eventData = new PlatformReportClickOldAccount();
		Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ReportToThirdParty(eventData);
		SdkMailViewData sdkMailViewData = new SdkMailViewData();
		string privacyPolicy = Singleton<PlatformSdkConfig>.Instance.GetPrivacyPolicy();
		string termsOfService = Singleton<PlatformSdkConfig>.Instance.GetTermsOfService();
		string childPolicy = Singleton<PlatformSdkConfig>.Instance.GetChildPolicy();
		if (termsOfService != null && termsOfService != "")
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("MenuConfig_114_Name", null);
			SdkProtocolData item = SdkProtocolData.Create(termsOfService, localTextNew);
			sdkMailViewData.ProtocolData.Add(item);
		}
		if (privacyPolicy != null && privacyPolicy != "")
		{
			string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew("MenuConfig_115_Name", null);
			SdkProtocolData item2 = SdkProtocolData.Create(privacyPolicy, localTextNew2);
			sdkMailViewData.ProtocolData.Add(item2);
		}
		if (childPolicy != null && childPolicy != "")
		{
			string localTextNew3 = ConfigMultiTextLang.GetLocalTextNew("MenuConfig_116_Name", null);
			SdkProtocolData item3 = SdkProtocolData.Create(childPolicy, localTextNew3);
			sdkMailViewData.ProtocolData.Add(item3);
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SdkMailView, sdkMailViewData, null);
	}

	// Token: 0x02008C7D RID: 35965
	private enum EComponent
	{
		// Token: 0x0402F4CA RID: 193738
		CancelButton,
		// Token: 0x0402F4CB RID: 193739
		CreateButton,
		// Token: 0x0402F4CC RID: 193740
		DescText,
		// Token: 0x0402F4CD RID: 193741
		VerticalLayout,
		// Token: 0x0402F4CE RID: 193742
		LoginButton
	}
}
