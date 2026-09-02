using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform.PlatformSdk;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002977 RID: 10615
[NullableContext(1)]
[Nullable(0)]
public class SdkMailView : UiTickViewBase
{
	// Token: 0x0601517A RID: 86394 RVA: 0x005D5E5F File Offset: 0x005D405F
	public SdkMailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601517B RID: 86395 RVA: 0x005D5E80 File Offset: 0x005D4080
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITextInputComponent)),
			new ValueTuple<int, Type>(2, typeof(UUITextInputComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickCancelButton)),
			new ValueTuple<int, Delegate>(9, new Action(this.OnClickConfirmButton)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickProtocolButton1)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickProtocolButton2)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickProtocolButton3)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickSendCodeButton)),
			new ValueTuple<int, Delegate>(7, new Action<EToggleState>(this.OnToggleClick))
		};
	}

	// Token: 0x0601517C RID: 86396 RVA: 0x005D6088 File Offset: 0x005D4288
	protected override void OnStart()
	{
		this.ViewData = (this.OpenParam as SdkMailViewData);
		this.ProtocolButtonArray = new List<UUIButtonComponent>
		{
			base.GetButton(3),
			base.GetButton(4),
			base.GetButton(5)
		};
		this.ProtocolTextArray = new List<UUIText>
		{
			base.GetText(10),
			base.GetText(11),
			base.GetText(12)
		};
		this.RefreshSendCodeButton();
		this.RefreshProtocolItems();
		PlatformReportLoginWindow eventData = new PlatformReportLoginWindow();
		Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ReportToThirdParty(eventData);
		this.RefreshConfirmButtonState();
		UUITextInputComponent inputText = base.GetInputText(1);
		if (inputText != null)
		{
			inputText.OnTextChange.Bind(new Action<string>(this.OnInputTextChange));
		}
		UUITextInputComponent inputText2 = base.GetInputText(2);
		if (inputText2 != null)
		{
			inputText2.OnTextChange.Bind(new Action<string>(this.OnInputTextChange));
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(7);
		if (extendToggle != null)
		{
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
		}
	}

	// Token: 0x0601517D RID: 86397 RVA: 0x005D619B File Offset: 0x005D439B
	private void OnToggleStateChange(EToggleState state)
	{
		this.RefreshConfirmButtonState();
	}

	// Token: 0x0601517E RID: 86398 RVA: 0x005D61A3 File Offset: 0x005D43A3
	private void OnInputTextChange(string _)
	{
		this.RefreshConfirmButtonState();
	}

	// Token: 0x0601517F RID: 86399 RVA: 0x005D61AC File Offset: 0x005D43AC
	private void OnToggleClick(EToggleState _)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(7);
		if (extendToggle == null)
		{
			return;
		}
		if (extendToggle.GetToggleState() == EToggleState.ETT_Checked)
		{
			PlatformReportClickProtocol eventData = new PlatformReportClickProtocol();
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ReportToThirdParty(eventData);
		}
	}

	// Token: 0x06015180 RID: 86400 RVA: 0x005D61E4 File Offset: 0x005D43E4
	private void OnClickSendCodeButton()
	{
		if (Singleton<TimeUtil>.Instance.GetServerTime() - this.SendCodeTime < 60.0)
		{
			return;
		}
		UUITextInputComponent inputText = base.GetInputText(1);
		if (inputText == null)
		{
			return;
		}
		string text = inputText.GetText();
		if (!new Regex("^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$").IsMatch(text))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PSN_Tip_MailNotValid", Array.Empty<object>());
			return;
		}
		this.SendCodeToSdkServer(text);
	}

	// Token: 0x06015181 RID: 86401 RVA: 0x005D6250 File Offset: 0x005D4450
	private void RefreshConfirmButtonState()
	{
		UUITextInputComponent inputText = base.GetInputText(1);
		UUITextInputComponent inputText2 = base.GetInputText(2);
		UUIExtendToggle extendToggle = base.GetExtendToggle(7);
		if (inputText == null || inputText2 == null || extendToggle == null)
		{
			return;
		}
		string text = inputText.GetText();
		string text2 = inputText2.GetText();
		EToggleState toggleState = extendToggle.GetToggleState();
		if (text.Length > 0 && text2.Length > 0 && toggleState == EToggleState.ETT_Checked)
		{
			UUIButtonComponent button = base.GetButton(9);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(true);
			return;
		}
		else
		{
			UUIButtonComponent button2 = base.GetButton(9);
			if (button2 == null)
			{
				return;
			}
			button2.SetSelfInteractive(false);
			return;
		}
	}

	// Token: 0x06015182 RID: 86402 RVA: 0x005D62D4 File Offset: 0x005D44D4
	private UniTask SendCodeToSdkServer(string mailAddress)
	{
		SdkMailView.<SendCodeToSdkServer>d__13 <SendCodeToSdkServer>d__;
		<SendCodeToSdkServer>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SendCodeToSdkServer>d__.<>4__this = this;
		<SendCodeToSdkServer>d__.mailAddress = mailAddress;
		<SendCodeToSdkServer>d__.<>1__state = -1;
		<SendCodeToSdkServer>d__.<>t__builder.Start<SdkMailView.<SendCodeToSdkServer>d__13>(ref <SendCodeToSdkServer>d__);
		return <SendCodeToSdkServer>d__.<>t__builder.Task;
	}

	// Token: 0x06015183 RID: 86403 RVA: 0x005D6320 File Offset: 0x005D4520
	private void RefreshProtocolItems()
	{
		for (int i = 0; i < this.ProtocolButtonArray.Count; i++)
		{
			UUIItem uuiitem = this.ProtocolButtonArray[i].RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(false);
			}
			this.ProtocolTextArray[i].SetUIActive(false);
		}
		if (this.ViewData != null)
		{
			for (int j = 0; j < this.ProtocolButtonArray.Count; j++)
			{
				if (j < this.ViewData.ProtocolData.Count)
				{
					UUIItem uuiitem2 = this.ProtocolButtonArray[j].RootUIComp.Get();
					if (uuiitem2 != null)
					{
						uuiitem2.SetUIActive(true);
					}
					this.ProtocolTextArray[j].SetUIActive(true);
					this.ProtocolTextArray[j].SetText(this.ViewData.ProtocolData[j].Title, true);
				}
				else
				{
					UUIItem uuiitem3 = this.ProtocolButtonArray[j].RootUIComp.Get();
					if (uuiitem3 != null)
					{
						uuiitem3.SetUIActive(false);
					}
					this.ProtocolTextArray[j].SetUIActive(false);
				}
			}
		}
	}

	// Token: 0x06015184 RID: 86404 RVA: 0x005D644C File Offset: 0x005D464C
	private void OnClickCancelButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x06015185 RID: 86405 RVA: 0x005D6458 File Offset: 0x005D4658
	private void OnClickConfirmButton()
	{
		UUITextInputComponent inputText = base.GetInputText(1);
		if (inputText == null)
		{
			return;
		}
		string mailAddress = inputText.GetText();
		if (!new Regex("^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$").IsMatch(mailAddress))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PSN_Tip_MailNotValid", Array.Empty<object>());
			return;
		}
		UUITextInputComponent inputText2 = base.GetInputText(2);
		if (inputText2 == null)
		{
			return;
		}
		string code = inputText2.GetText();
		if (code.Length != 6)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PSN_Tip_MailCodeError", Array.Empty<object>());
			return;
		}
		SdkLoadPopUpViewData param = SdkLoadPopUpViewData.Create(5, "Sdk_Bind_Mail_Loading");
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SdkLoadPopUpView, param, delegate(bool isSuccess, int _)
		{
			PlatformReportClickLogin eventData = new PlatformReportClickLogin();
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ReportToThirdParty(eventData);
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().BindAccountThenLogin(delegate(string msg, bool needReLogin, bool needSelectLoginFunction, [Nullable(2)] ILoginResponseData data)
			{
				if (data != null)
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.SdkMailView, null);
					Singleton<UiManager>.Instance.CloseView(EUiViewName.SdkLoginView, null);
					ControllerBase<LoginController>.Instance.OnSdkLoginResult(data.code, data.cuid, data.username);
				}
				else if (data == null && msg != "" && msg != PlatformSdkServerMsg.BadHttp.ToEnumString())
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(msg);
				}
				else if (data == null)
				{
					ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SdkServerNetworkError);
					ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
				}
				Singleton<UiManager>.Instance.CloseView(EUiViewName.SdkLoadPopUpView, null);
			}, mailAddress, code);
		});
	}

	// Token: 0x06015186 RID: 86406 RVA: 0x005D6514 File Offset: 0x005D4714
	private void OnClickProtocolButton1()
	{
		if (this.ViewData != null && this.ViewData.ProtocolData.Count > 0)
		{
			ControllerBase<KuroSdkController>.Instance.SdkOpenUrlWnd("", this.ViewData.ProtocolData[0].Url, true, true, true);
		}
	}

	// Token: 0x06015187 RID: 86407 RVA: 0x005D6564 File Offset: 0x005D4764
	private void OnClickProtocolButton2()
	{
		if (this.ViewData != null && this.ViewData.ProtocolData.Count > 1)
		{
			ControllerBase<KuroSdkController>.Instance.SdkOpenUrlWnd("", this.ViewData.ProtocolData[1].Url, true, true, true);
		}
	}

	// Token: 0x06015188 RID: 86408 RVA: 0x005D65B4 File Offset: 0x005D47B4
	private void OnClickProtocolButton3()
	{
		if (this.ViewData != null && this.ViewData.ProtocolData.Count > 2)
		{
			ControllerBase<KuroSdkController>.Instance.SdkOpenUrlWnd("", this.ViewData.ProtocolData[2].Url, true, true, true);
		}
	}

	// Token: 0x06015189 RID: 86409 RVA: 0x005D6604 File Offset: 0x005D4804
	private void RefreshSendCodeButton()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		UUITextInputComponent inputText = base.GetInputText(1);
		if (inputText == null)
		{
			return;
		}
		string text = inputText.GetText();
		if (serverTime - this.SendCodeTime < 60.0 || text.Length == 0)
		{
			UUIButtonComponent button = base.GetButton(8);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(false);
			return;
		}
		else
		{
			UUIButtonComponent button2 = base.GetButton(8);
			if (button2 == null)
			{
				return;
			}
			button2.SetSelfInteractive(true);
			return;
		}
	}

	// Token: 0x0601518A RID: 86410 RVA: 0x005D6670 File Offset: 0x005D4870
	private void RefreshCountDownText()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		int num = (int)(60.0 - (serverTime - this.SendCodeTime));
		UUIText text = base.GetText(13);
		if (text == null)
		{
			return;
		}
		if (num <= 0)
		{
			text.ShowTextNew("Send_MailCode");
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Send_MailCode_Cd", new <>z__ReadOnlySingleElementList<object>(num.ToString()));
	}

	// Token: 0x0601518B RID: 86411 RVA: 0x005D66D5 File Offset: 0x005D48D5
	protected override void OnTick(float delta)
	{
		this.RefreshSendCodeButton();
		this.RefreshCountDownText();
	}

	// Token: 0x0400A272 RID: 41586
	private double SendCodeTime;

	// Token: 0x0400A273 RID: 41587
	private List<UUIButtonComponent> ProtocolButtonArray = new List<UUIButtonComponent>();

	// Token: 0x0400A274 RID: 41588
	private List<UUIText> ProtocolTextArray = new List<UUIText>();

	// Token: 0x0400A275 RID: 41589
	[Nullable(2)]
	private SdkMailViewData ViewData;

	// Token: 0x02008C7F RID: 35967
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F4D3 RID: 193747
		BackButton,
		// Token: 0x0402F4D4 RID: 193748
		AccountInput,
		// Token: 0x0402F4D5 RID: 193749
		CodeInput,
		// Token: 0x0402F4D6 RID: 193750
		ProtocolButton1,
		// Token: 0x0402F4D7 RID: 193751
		ProtocolButton2,
		// Token: 0x0402F4D8 RID: 193752
		ProtocolButton3,
		// Token: 0x0402F4D9 RID: 193753
		ExtendToggleParent,
		// Token: 0x0402F4DA RID: 193754
		AgreeToggle,
		// Token: 0x0402F4DB RID: 193755
		SendCodeButton,
		// Token: 0x0402F4DC RID: 193756
		ConfirmButton,
		// Token: 0x0402F4DD RID: 193757
		ProtocolText1,
		// Token: 0x0402F4DE RID: 193758
		ProtocolText2,
		// Token: 0x0402F4DF RID: 193759
		ProtocolText3,
		// Token: 0x0402F4E0 RID: 193760
		ConfirmBoxText
	}
}
