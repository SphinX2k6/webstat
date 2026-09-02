using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using Google.Protobuf.Collections;

// Token: 0x02001B5D RID: 7005
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ErrorCodeController : UiControllerBase<ErrorCodeController>
{
	// Token: 0x0600CACF RID: 51919 RVA: 0x00361076 File Offset: 0x0035F276
	protected override bool OnInit()
	{
		Singleton<Net>.Instance.SetExceptionHandle(new Net.TExceptionHandle(this.OpenExceptionTipView));
		return true;
	}

	// Token: 0x0600CAD0 RID: 51920 RVA: 0x0036108F File Offset: 0x0035F28F
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x0600CAD1 RID: 51921 RVA: 0x00361092 File Offset: 0x0035F292
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<MessageDecodeFailNotify>(ENotifyMessageId.MessageDecodeFailNotify, new Action<MessageDecodeFailNotify, Net.CallbackStatus>(this.OnMessageDecodeFailNotify));
		Singleton<Net>.Instance.Register<SysInfoNotify>(ENotifyMessageId.SysInfoNotify, new Action<SysInfoNotify, Net.CallbackStatus>(this.OnErrorNotify));
	}

	// Token: 0x0600CAD2 RID: 51922 RVA: 0x003610CC File Offset: 0x0035F2CC
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MessageDecodeFailNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SysInfoNotify);
	}

	// Token: 0x0600CAD3 RID: 51923 RVA: 0x003610F0 File Offset: 0x0035F2F0
	private void OnMessageDecodeFailNotify(MessageDecodeFailNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		MessageDecodeData messageDecodeData = new MessageDecodeData();
		messageDecodeData.s_channel_id = notify.ChannelId;
		messageDecodeData.i_kcp_conv = notify.Conv;
		messageDecodeData.i_error_code = (int)notify.Code;
		messageDecodeData.i_seq_no = notify.SeqNo;
		messageDecodeData.s_client_ip = Singleton<PublicUtil>.Instance.GetLocalHost();
		ValueTuple<int, int, string, string> cachedMessageData = Singleton<Net>.Instance.GetCachedMessageData(notify.SeqNo);
		messageDecodeData.i_message_id = cachedMessageData.Item1;
		messageDecodeData.i_crc = cachedMessageData.Item2;
		messageDecodeData.s_before_hexdump = cachedMessageData.Item3;
		messageDecodeData.s_after_hexdump = cachedMessageData.Item4;
		ControllerBase<LogReportController>.Instance.LogReport(messageDecodeData);
	}

	// Token: 0x0600CAD4 RID: 51924 RVA: 0x00361190 File Offset: 0x0035F390
	private void OnErrorNotify(SysInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<string> errorParams = notify.ErrorParams;
		Aki.Protocol.ErrorCode errorCode = notify.ErrorCode;
		this.OpenErrorCodeScrollingTipsView(errorCode, errorParams.ToArray<string>());
	}

	// Token: 0x0600CAD5 RID: 51925 RVA: 0x003611B8 File Offset: 0x0035F3B8
	public unsafe void OpenErrorCodeScrollingTipsView(Aki.Protocol.ErrorCode errorCode, string[] errorParams)
	{
		string textByErrorId = ConfigBase<ErrorCodeConfig>.Instance.GetTextByErrorId(errorCode);
		if (errorCode == Aki.Protocol.ErrorCode.PropRewardTips)
		{
			string s = errorParams[0];
			errorParams[0] = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexLocalName(int.Parse(s));
		}
		string text = this.ReplaceWildCard(textByErrorId, errorParams);
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(text);
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ErrorCode;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "服务器错误信息";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("error", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("errorParams", errorParams);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x0600CAD6 RID: 51926 RVA: 0x00361263 File Offset: 0x0035F463
	public void OpenErrorCodeTipView(Aki.Protocol.ErrorCode errorCode, EResponseMessageId messageId, [Nullable(new byte[]
	{
		2,
		1
	})] IReadOnlyList<string> errorParams = null, bool showToScreen = true, bool isShowErrorCode = true)
	{
		this.OpenErrorCodeTipView(errorCode, (int)messageId, errorParams, showToScreen, isShowErrorCode);
	}

	// Token: 0x0600CAD7 RID: 51927 RVA: 0x00361274 File Offset: 0x0035F474
	public unsafe void OpenErrorCodeTipView(Aki.Protocol.ErrorCode errorCode, int messageId, [Nullable(new byte[]
	{
		2,
		1
	})] IReadOnlyList<string> errorParams = null, bool showToScreen = true, bool isShowErrorCode = true)
	{
		if (errorCode == Aki.Protocol.ErrorCode.ErrorBanInteractEntity)
		{
			return;
		}
		ErrorCodeConfig instance = ConfigBase<ErrorCodeConfig>.Instance;
		string textByErrorId = instance.GetTextByErrorId(errorCode);
		string text = this.ReplaceWildCard(textByErrorId, errorParams);
		bool flag = instance.IsTipsOnly(errorCode);
		bool flag2 = Singleton<BaseConfigController>.Instance.GetPackageConfigOrDefault("Stream", null) == "mainline";
		if (showToScreen && this.IsErrorCodeOpen)
		{
			if (flag && !flag2)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType(EPromptSubViewType.FloatLinePrompt, null, null, new object[]
				{
					text
				}, null, null, null);
				return;
			}
			if (isShowErrorCode)
			{
				text = this.FormatErrorCodeInfo(messageId, errorCode, text);
			}
			this.OpenConfirmBoxByText(text);
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module = ELogModule.ErrorCode;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "服务器错误信息";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("error", text);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("errorCode", errorCode);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("errorParams", errorParams);
		instance2.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x0600CAD8 RID: 51928 RVA: 0x00361388 File Offset: 0x0035F588
	private string FormatErrorCodeInfo(int messageId, Aki.Protocol.ErrorCode errorCode, string showText)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (messageId > 0)
		{
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 3);
			defaultInterpolatedStringHandler.AppendLiteral("[");
			defaultInterpolatedStringHandler.AppendFormatted<int>(messageId);
			defaultInterpolatedStringHandler.AppendLiteral("][");
			defaultInterpolatedStringHandler.AppendFormatted<int>((int)errorCode);
			defaultInterpolatedStringHandler.AppendLiteral("]:");
			defaultInterpolatedStringHandler.AppendFormatted(showText);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 2);
		defaultInterpolatedStringHandler.AppendLiteral("[-][");
		defaultInterpolatedStringHandler.AppendFormatted<int>((int)errorCode);
		defaultInterpolatedStringHandler.AppendLiteral("]:");
		defaultInterpolatedStringHandler.AppendFormatted(showText);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600CAD9 RID: 51929 RVA: 0x00361420 File Offset: 0x0035F620
	public unsafe void LogOnlyErrorCode(Aki.Protocol.ErrorCode errorCode, [Nullable(new byte[]
	{
		2,
		1
	})] IReadOnlyList<string> errorParams = null)
	{
		string textByErrorId = ConfigBase<ErrorCodeConfig>.Instance.GetTextByErrorId(errorCode);
		string text = this.ReplaceWildCard(textByErrorId, errorParams);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
		defaultInterpolatedStringHandler.AppendLiteral("[");
		defaultInterpolatedStringHandler.AppendFormatted<int>((int)errorCode);
		defaultInterpolatedStringHandler.AppendLiteral("]:");
		defaultInterpolatedStringHandler.AppendFormatted(text);
		text = defaultInterpolatedStringHandler.ToStringAndClear();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.ErrorCode;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "服务器错误信息";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("error", text);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("errorParams", errorParams);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x0600CADA RID: 51930 RVA: 0x003614D0 File Offset: 0x0035F6D0
	private string ReplaceWildCard(string text, [Nullable(new byte[]
	{
		2,
		1
	})] IReadOnlyList<string> @params)
	{
		string text2 = text;
		if (@params != null)
		{
			for (int i = 0; i < @params.Count; i++)
			{
				string newValue = @params[i];
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
				defaultInterpolatedStringHandler.AppendLiteral("{");
				defaultInterpolatedStringHandler.AppendFormatted<int>(i);
				defaultInterpolatedStringHandler.AppendLiteral("}");
				string oldValue = defaultInterpolatedStringHandler.ToStringAndClear();
				text2 = text2.Replace(oldValue, newValue);
			}
		}
		return text2;
	}

	// Token: 0x0600CADB RID: 51931 RVA: 0x00361538 File Offset: 0x0035F738
	public void OpenLoginStatusCodeTipView(Aki.Protocol.ErrorCode errorCode)
	{
		if (this.IsErrorCodeOpen)
		{
			this.OpenErrorCodeTipView(errorCode, 0, null, true, true);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.ErrorCode;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "Http登录返回错误码";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("code", (int)errorCode);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600CADC RID: 51932 RVA: 0x00361584 File Offset: 0x0035F784
	private unsafe void OpenExceptionTipView(int rpcId, int errorCode, int messageId, object message, string errorMessage)
	{
		if (errorCode == 64)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(ConfigMultiTextLang.GetLocalTextNew("FunctionClose", null));
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ErrorCode;
			ELogAuthor author = ELogAuthor.YYZ;
			string message2 = "服务器异常: 功能关闭";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("errorCode", errorCode);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RpcId", rpcId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("msgId", messageId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("message", message);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("errorMessage", errorMessage);
			instance.Info(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			return;
		}
		if (!Singleton<Info>.Instance.IsBuildShipping)
		{
			this.OpenErrorCodeTipView((Aki.Protocol.ErrorCode)errorCode, (EResponseMessageId)messageId, null, true, true);
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.ErrorCode;
		ELogAuthor author2 = ELogAuthor.ZJC;
		string message3 = "服务器异常";
		<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray5<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("errorCode", errorCode);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("RpcId", rpcId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("msgId", messageId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("message", message);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("errorMessage", errorMessage);
		instance2.Error(module2, author2, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 5));
	}

	// Token: 0x0600CADD RID: 51933 RVA: 0x00361720 File Offset: 0x0035F920
	public void OpenConfirmBoxByTextId(string textId)
	{
		if (!this.IsErrorCodeOpen)
		{
			return;
		}
		string textById = ConfigBase<TextConfig>.Instance.GetTextById(textId);
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ErrorCodeTips);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			textById
		});
		confirmBoxDataNew.NotAddChildToTopStackView = true;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600CADE RID: 51934 RVA: 0x00361770 File Offset: 0x0035F970
	public void OpenConfirmBoxByTextIdNew(string textId)
	{
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(textId, null);
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ErrorCodeTips);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			localTextNew
		});
		confirmBoxDataNew.NotAddChildToTopStackView = true;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600CADF RID: 51935 RVA: 0x003617B0 File Offset: 0x0035F9B0
	public unsafe bool CheckErrorCode(Aki.Protocol.ErrorCode? response, EResponseMessageId msgId, bool isShowTip = true)
	{
		if (response == null)
		{
			return true;
		}
		if (response.Value != Aki.Protocol.ErrorCode.Success)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ErrorCode;
			ELogAuthor author = ELogAuthor.CX;
			string message = "CheckErrorCode";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ErrorCode", response.Value);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MsgId", msgId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (isShowTip)
			{
				this.OpenErrorCodeTipView(response.Value, msgId, null, true, true);
			}
			return true;
		}
		return false;
	}

	// Token: 0x0400610E RID: 24846
	public bool IsErrorCodeOpen = true;

	// Token: 0x0400610F RID: 24847
	public readonly Action<string> OpenConfirmBoxByText = delegate(string text)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ErrorCodeTips);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			text
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	};
}
