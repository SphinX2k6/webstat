using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x02002761 RID: 10081
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ReportController : UiControllerBase<ReportController>
{
	// Token: 0x06013E56 RID: 81494 RVA: 0x0058B4AC File Offset: 0x005896AC
	public static void ReportPlayerRequest(ReportPersonInfo targetPlayerInfo, int reportReason, string reportMessage, [Nullable(2)] ReportChatInfo reportChatInfo = null)
	{
		ReportPlayerRequest reportPlayerRequest = Aki.Protocol.ReportPlayerRequest.Create();
		reportPlayerRequest.TargetPlayerId = targetPlayerInfo.GetPlayerId();
		reportPlayerRequest.ReportReason = reportReason;
		reportPlayerRequest.ReportMessage = reportMessage;
		reportPlayerRequest.ReportSource = (int)targetPlayerInfo.GetSourceType();
		if (reportChatInfo != null)
		{
			reportPlayerRequest.ChatInfo = reportChatInfo;
		}
		else
		{
			ReportChatInfo reportChatInfo2 = ReportChatInfo.Create();
			reportChatInfo2.ChatMessage = string.Empty;
			reportPlayerRequest.ChatInfo = reportChatInfo2;
		}
		ReportTargetInfo reportTargetInfo = ReportTargetInfo.Create();
		reportTargetInfo.Name = targetPlayerInfo.GetName();
		reportTargetInfo.Signature = targetPlayerInfo.GetSignature();
		reportPlayerRequest.TargetInfo = reportTargetInfo;
		Singleton<Net>.Instance.Call<ReportPlayerResponse>(ERequestMessageId.ReportPlayerRequest, reportPlayerRequest, delegate(ReportPlayerResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27368, null, true, true);
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ReportSuccess", Array.Empty<object>());
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ReportView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ReportView, null);
			}
		}, 0);
	}

	// Token: 0x06013E57 RID: 81495 RVA: 0x0058B560 File Offset: 0x00589760
	public void OpenReportView(IPlayerData friendData, EReportSourceType sourceType)
	{
		ReportPersonInfo param = new ReportPersonInfo(friendData.PlayerId, friendData.PlayerName, friendData.Signature, sourceType);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ReportView, param, null);
	}
}
