using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Module.PhoneMessage.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

// Token: 0x02002555 RID: 9557
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PhoneMsgController : ControllerBase<PhoneMsgController>
{
	// Token: 0x0601296D RID: 76141 RVA: 0x0051E8A0 File Offset: 0x0051CAA0
	protected override bool OnInit()
	{
		this.OnAddEvents();
		this.OnRegisterNetEvent();
		Singleton<InputManager>.Instance.RegisterOpenViewFunc(EUiViewName.PhoneMsgPanelViewBig, new Action(this.OpenPhoneMsgPanelViewBigByShortKey));
		return true;
	}

	// Token: 0x0601296E RID: 76142 RVA: 0x0051E8CA File Offset: 0x0051CACA
	protected override bool OnClear()
	{
		this.OnRemoveEvents();
		this.OnUnRegisterNetEvent();
		return true;
	}

	// Token: 0x0601296F RID: 76143 RVA: 0x0051E8DC File Offset: 0x0051CADC
	protected void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.ShowFloatTips, new Action(this.TryShowPhoneMsgTipView));
		Singleton<EventSystem>.Instance.Add(EEventName.OnNewPhoneMsgNeedShowTips, new Action(this.TryShowPhoneMsgTipView));
	}

	// Token: 0x06012970 RID: 76144 RVA: 0x0051E940 File Offset: 0x0051CB40
	protected void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShowFloatTips, new Action(this.TryShowPhoneMsgTipView));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnNewPhoneMsgNeedShowTips, new Action(this.TryShowPhoneMsgTipView));
	}

	// Token: 0x06012971 RID: 76145 RVA: 0x0051E9A1 File Offset: 0x0051CBA1
	protected void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ShortMessageUpdateNotify>(ENotifyMessageId.ShortMessageUpdateNotify, new Action<ShortMessageUpdateNotify, Net.CallbackStatus>(this.OnPhoneMsgNotify));
		Singleton<Net>.Instance.Register<ShortMessageItemUpdateNotify>(ENotifyMessageId.ShortMessageItemUpdateNotify, new Action<ShortMessageItemUpdateNotify, Net.CallbackStatus>(this.OnPhoneMsgDialogAndBgAddNotify));
	}

	// Token: 0x06012972 RID: 76146 RVA: 0x0051E9DB File Offset: 0x0051CBDB
	protected void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ShortMessageUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ShortMessageItemUpdateNotify);
	}

	// Token: 0x06012973 RID: 76147 RVA: 0x0051E9FD File Offset: 0x0051CBFD
	public void OpenPhoneMsgPanelViewBigByShortKey()
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10130))
		{
			return;
		}
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhoneMsgPanelViewBig))
		{
			this.OpenAndJumpShowTipShortMessage(EPhoneMsgOpenWay.HotKey, EPhoneMsgViewType.Big);
			return;
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.PhoneMsgPanelViewBig, null);
	}

	// Token: 0x06012974 RID: 76148 RVA: 0x0051EA3C File Offset: 0x0051CC3C
	public void OpenAndJumpShowTipShortMessage(EPhoneMsgOpenWay openWay, EPhoneMsgViewType viewType)
	{
		int currentShowingMsgIdInSmallHead = ModelBase<PhoneMsgModel>.Instance.CurrentShowingMsgIdInSmallHead;
		PhoneMsgPanelViewData param = new PhoneMsgPanelViewData
		{
			ShortMessage = null,
			NeedShowTips = false,
			OpenWay = openWay,
			ViewType = viewType
		};
		if (currentShowingMsgIdInSmallHead != 0)
		{
			ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(currentShowingMsgIdInSmallHead);
			param = new PhoneMsgPanelViewData
			{
				ShortMessage = phoneMsgConfig,
				NeedShowTips = false,
				OpenWay = openWay,
				ViewType = viewType
			};
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhoneMsgPanelViewBig, param, null);
	}

	// Token: 0x06012975 RID: 76149 RVA: 0x0051EAC0 File Offset: 0x0051CCC0
	public void QuickOpenPhoneMsgPanelViewBig(int msgId, EPhoneMsgOpenWay openWay)
	{
		ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(msgId);
		if (phoneMsgConfig == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.PhoneSystem, ELogAuthor.LZK, "短信配置不存在，msgId: " + msgId.ToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		PhoneMsgPanelViewData param = new PhoneMsgPanelViewData
		{
			ShortMessage = phoneMsgConfig,
			NeedShowTips = false,
			OpenWay = openWay,
			ViewType = EPhoneMsgViewType.Big
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhoneMsgPanelViewBig, param, null);
	}

	// Token: 0x06012976 RID: 76150 RVA: 0x0051EB41 File Offset: 0x0051CD41
	[NullableContext(1)]
	private void OnPhoneMsgNotify(ShortMessageUpdateNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		if (message != null)
		{
			ModelBase<PhoneMsgModel>.Instance.OnPhoneMsgUpdateNotify(message);
		}
	}

	// Token: 0x06012977 RID: 76151 RVA: 0x0051EB51 File Offset: 0x0051CD51
	private void TryShowPhoneMsgTipView()
	{
		if (!Singleton<UiModel>.Instance.IsInMainView)
		{
			return;
		}
		if (!this.IsPhoneMsgTipEnable)
		{
			return;
		}
		if (!ModelBase<PhoneMsgModel>.Instance.CheckIsInWhiteList())
		{
			return;
		}
		this.TopPanelCheckAndPlayPhoneSequence();
		this.OpenPhoneMsgTipView();
	}

	// Token: 0x06012978 RID: 76152 RVA: 0x0051EB84 File Offset: 0x0051CD84
	public void OpenPhoneMsgTipView()
	{
		List<int> currentToBeNotifiedMsgArray = ModelBase<PhoneMsgModel>.Instance.CurrentToBeNotifiedMsgArray;
		if (!ModelBase<PhoneMsgModel>.Instance.IsPhoneChatShowInitDone)
		{
			Singleton<Log>.Instance.Warn(ELogModule.PhoneSystem, ELogAuthor.LZK, "[仅警告，无需处理] 聊天气泡&背景未初始化完成，不能弹出短信弹窗提示，已缓存等待初始化完成后会正常弹出", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int count = currentToBeNotifiedMsgArray.Count;
		for (int i = 0; i < count; i++)
		{
			int shortMessageId = currentToBeNotifiedMsgArray[i];
			ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(shortMessageId);
			if (phoneMsgConfig != null)
			{
				switch (phoneMsgConfig.Value.TipType)
				{
				case 2:
					Singleton<Log>.Instance.Error(ELogModule.PhoneSystem, ELogAuthor.LZK, "短信弹窗提示类型B未已经弃用,请通知策划更改配置", default(ReadOnlySpan<ValueTuple<string, object>>));
					break;
				case 3:
				{
					PhoneMsgPanelViewData param = new PhoneMsgPanelViewData
					{
						ShortMessage = phoneMsgConfig,
						NeedShowTips = true,
						OpenWay = EPhoneMsgOpenWay.ForceOpen,
						ViewType = EPhoneMsgViewType.Small
					};
					Singleton<UiManager>.Instance.OpenView(EUiViewName.PhoneMsgPanelViewSmall, param, null);
					break;
				}
				case 4:
				{
					PhoneMsgPanelViewData param2 = new PhoneMsgPanelViewData
					{
						ShortMessage = phoneMsgConfig,
						NeedShowTips = false,
						OpenWay = EPhoneMsgOpenWay.ForceOpen,
						ViewType = EPhoneMsgViewType.Small
					};
					Singleton<UiManager>.Instance.OpenView(EUiViewName.PhoneMsgPanelViewSmall, param2, null);
					break;
				}
				case 5:
				{
					PhoneMsgPanelViewData param3 = new PhoneMsgPanelViewData
					{
						ShortMessage = phoneMsgConfig,
						NeedShowTips = true,
						NeedForceReadAllMsg = true,
						OpenWay = EPhoneMsgOpenWay.ForceOpen,
						ViewType = EPhoneMsgViewType.Small
					};
					Singleton<UiManager>.Instance.OpenView(EUiViewName.PhoneMsgPanelViewSmall, param3, null);
					break;
				}
				}
			}
		}
		currentToBeNotifiedMsgArray.Clear();
	}

	// Token: 0x06012979 RID: 76153 RVA: 0x0051ED13 File Offset: 0x0051CF13
	[NullableContext(1)]
	private void OnPhoneMsgDialogAndBgAddNotify(ShortMessageItemUpdateNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		if (message != null)
		{
			ModelBase<PhoneMsgModel>.Instance.OnPhoneMsgDialogAndBgAddNotify(message);
		}
	}

	// Token: 0x0601297A RID: 76154 RVA: 0x0051ED23 File Offset: 0x0051CF23
	private void OnWorldDone()
	{
		this.RequestAllMsg();
	}

	// Token: 0x0601297B RID: 76155 RVA: 0x0051ED2C File Offset: 0x0051CF2C
	public void TopPanelCheckAndPlayPhoneSequence()
	{
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.BattleView);
		if (viewByName == null)
		{
			return;
		}
		BattleViewProxy battleViewProxy = viewByName.OpenParam as BattleViewProxy;
		if (battleViewProxy == null)
		{
			return;
		}
		IPhoneMessageButtonImplement topPanelPhoneMsgButton = battleViewProxy.GetTopPanelPhoneMsgButton();
		if (topPanelPhoneMsgButton == null)
		{
			return;
		}
		if (ModelBase<PhoneMsgModel>.Instance.CurrentToBeNotifiedMsgInSmallHeadQueue.Count == 0)
		{
			return;
		}
		topPanelPhoneMsgButton.CheckAndPlayPhoneSequence();
	}

	// Token: 0x0601297C RID: 76156 RVA: 0x0051ED80 File Offset: 0x0051CF80
	public void TopPanelCheckAndPopHead(int clickId)
	{
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.BattleView);
		if (viewByName == null)
		{
			return;
		}
		BattleViewProxy battleViewProxy = viewByName.OpenParam as BattleViewProxy;
		if (battleViewProxy == null)
		{
			return;
		}
		if (battleViewProxy.GetTopPanelPhoneMsgButton() == null)
		{
			return;
		}
		List<int> currentToBeNotifiedMsgInSmallHeadQueue = ModelBase<PhoneMsgModel>.Instance.CurrentToBeNotifiedMsgInSmallHeadQueue;
		int num = currentToBeNotifiedMsgInSmallHeadQueue.IndexOf(clickId);
		if (num != -1)
		{
			currentToBeNotifiedMsgInSmallHeadQueue.RemoveAt(num);
		}
		int currentShowingMsgIdInSmallHead = ModelBase<PhoneMsgModel>.Instance.CurrentShowingMsgIdInSmallHead;
		if (clickId == currentShowingMsgIdInSmallHead)
		{
			ModelBase<PhoneMsgModel>.Instance.CurrentShowingMsgIdInSmallHead = 0;
		}
	}

	// Token: 0x0601297D RID: 76157 RVA: 0x0051EDF4 File Offset: 0x0051CFF4
	public void RequestAllMsg()
	{
		ShortMessageInfoRequest message = ShortMessageInfoRequest.Create();
		Singleton<Net>.Instance.Call<ShortMessageInfoResponse>(ERequestMessageId.ShortMessageInfoRequest, message, new Action<ShortMessageInfoResponse, Net.CallbackStatus>(this.HandleRequestAllMsgResponse), 0);
	}

	// Token: 0x0601297E RID: 76158 RVA: 0x0051EE24 File Offset: 0x0051D024
	[NullableContext(1)]
	private void HandleRequestAllMsgResponse(ShortMessageInfoResponse response, [Nullable(2)] Net.CallbackStatus _)
	{
		if (response == null)
		{
			return;
		}
		RepeatedField<ShortMessageInfo> shortMessageInfos = response.ShortMessageInfos;
		if (shortMessageInfos != null)
		{
			ModelBase<PhoneMsgModel>.Instance.InitChatShow(response.BubbleId, response.ChatBgId, new List<int>(response.BubbleIds), new List<int>(response.ChatBgIds));
			ModelBase<PhoneMsgModel>.Instance.AddMessages(shortMessageInfos.ToList<ShortMessageInfo>(), null, false, false);
		}
	}

	// Token: 0x0601297F RID: 76159 RVA: 0x0051EE88 File Offset: 0x0051D088
	public UniTask<bool> SetOneMessageAsReadAsync(int shortMessageId)
	{
		PhoneMsgController.<SetOneMessageAsReadAsync>d__19 <SetOneMessageAsReadAsync>d__;
		<SetOneMessageAsReadAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SetOneMessageAsReadAsync>d__.shortMessageId = shortMessageId;
		<SetOneMessageAsReadAsync>d__.<>1__state = -1;
		<SetOneMessageAsReadAsync>d__.<>t__builder.Start<PhoneMsgController.<SetOneMessageAsReadAsync>d__19>(ref <SetOneMessageAsReadAsync>d__);
		return <SetOneMessageAsReadAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012980 RID: 76160 RVA: 0x0051EECC File Offset: 0x0051D0CC
	public UniTask<bool> ShortMessageReplyAsync(int shortMessageId, int talkIndex, int selectId)
	{
		PhoneMsgController.<ShortMessageReplyAsync>d__20 <ShortMessageReplyAsync>d__;
		<ShortMessageReplyAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<ShortMessageReplyAsync>d__.shortMessageId = shortMessageId;
		<ShortMessageReplyAsync>d__.talkIndex = talkIndex;
		<ShortMessageReplyAsync>d__.selectId = selectId;
		<ShortMessageReplyAsync>d__.<>1__state = -1;
		<ShortMessageReplyAsync>d__.<>t__builder.Start<PhoneMsgController.<ShortMessageReplyAsync>d__20>(ref <ShortMessageReplyAsync>d__);
		return <ShortMessageReplyAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012981 RID: 76161 RVA: 0x0051EF20 File Offset: 0x0051D120
	public UniTask<bool> ShortMessageReceiveAsync(int shortMessageId)
	{
		PhoneMsgController.<ShortMessageReceiveAsync>d__21 <ShortMessageReceiveAsync>d__;
		<ShortMessageReceiveAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<ShortMessageReceiveAsync>d__.shortMessageId = shortMessageId;
		<ShortMessageReceiveAsync>d__.<>1__state = -1;
		<ShortMessageReceiveAsync>d__.<>t__builder.Start<PhoneMsgController.<ShortMessageReceiveAsync>d__21>(ref <ShortMessageReceiveAsync>d__);
		return <ShortMessageReceiveAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012982 RID: 76162 RVA: 0x0051EF64 File Offset: 0x0051D164
	public UniTask<bool> UpdateProgressOfOneMessageAsync(int shortMessageId, int readIndex, bool isFinish)
	{
		PhoneMsgController.<UpdateProgressOfOneMessageAsync>d__22 <UpdateProgressOfOneMessageAsync>d__;
		<UpdateProgressOfOneMessageAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<UpdateProgressOfOneMessageAsync>d__.shortMessageId = shortMessageId;
		<UpdateProgressOfOneMessageAsync>d__.readIndex = readIndex;
		<UpdateProgressOfOneMessageAsync>d__.isFinish = isFinish;
		<UpdateProgressOfOneMessageAsync>d__.<>1__state = -1;
		<UpdateProgressOfOneMessageAsync>d__.<>t__builder.Start<PhoneMsgController.<UpdateProgressOfOneMessageAsync>d__22>(ref <UpdateProgressOfOneMessageAsync>d__);
		return <UpdateProgressOfOneMessageAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012983 RID: 76163 RVA: 0x0051EFB8 File Offset: 0x0051D1B8
	public void SendChangeChatDialogAndBgRequest(int chatDialogId, int chatBgId)
	{
		ShortMessageShowChangeRequest shortMessageShowChangeRequest = ShortMessageShowChangeRequest.Create();
		shortMessageShowChangeRequest.BubbleId = chatDialogId;
		shortMessageShowChangeRequest.ChatBgId = chatBgId;
		Singleton<Net>.Instance.Call<ShortMessageShowChangeResponse>(ERequestMessageId.ShortMessageShowChangeRequest, shortMessageShowChangeRequest, delegate(ShortMessageShowChangeResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrCode == Aki.Protocol.ErrorCode.Success)
			{
				ModelBase<PhoneMsgModel>.Instance.CurrentUsingChatDialogId = chatDialogId;
				ModelBase<PhoneMsgModel>.Instance.CurrentUsingChatBgId = chatBgId;
				Singleton<EventSystem>.Instance.Emit(EEventName.OnPhoneMsgChatShowChange);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 15834, null, true, true);
		}, 0);
	}

	// Token: 0x06012984 RID: 76164 RVA: 0x0051F014 File Offset: 0x0051D214
	public void OpenAttachmentImgView(int attachmentId)
	{
		PhoneMessageAttachment? config = ConfigPhoneMessageAttachmentById.GetConfig(attachmentId, true);
		if (config != null && !string.IsNullOrEmpty(config.Value.AttachmentPath))
		{
			bool flag = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male;
			string text = config.Value.AttachmentPathMaleVariant;
			string type = config.Value.Type;
			if (type == EAttachmentType.Image.ToEnumString())
			{
				ModelBase<InfoDisplayModel>.Instance.SetCurrentShowAttachmentType(EAttachmentType.Image);
				if (string.IsNullOrEmpty(text))
				{
					text = config.Value.AttachmentPath;
				}
				else
				{
					text = (flag ? config.Value.AttachmentPathMaleVariant : config.Value.AttachmentPath);
				}
				ModelBase<InfoDisplayModel>.Instance.SetCurrentOpenInformationTexture(text);
			}
			else if (type == EAttachmentType.Spine.ToEnumString())
			{
				string currentShowSpineAtlasPath = "";
				string currentShowSpineDataPath = "";
				if (string.IsNullOrEmpty(text))
				{
					string[] array = config.Value.AttachmentPath.Split(',', StringSplitOptions.None);
					if (array.Length >= 2)
					{
						currentShowSpineAtlasPath = array[0];
						currentShowSpineDataPath = array[1];
					}
					ModelBase<InfoDisplayModel>.Instance.SetAnimName("idle");
				}
				else
				{
					string text2 = flag ? config.Value.AttachmentPathMaleVariant : config.Value.AttachmentPath;
					string animName = flag ? "nan" : "nv";
					string[] array2 = config.Value.AttachmentPath.Split(',', StringSplitOptions.None);
					if (array2.Length >= 2)
					{
						currentShowSpineAtlasPath = array2[0];
						currentShowSpineDataPath = array2[1];
					}
					ModelBase<InfoDisplayModel>.Instance.SetAnimName(animName);
				}
				ModelBase<InfoDisplayModel>.Instance.SetCurrentShowSpineAtlasPath(currentShowSpineAtlasPath);
				ModelBase<InfoDisplayModel>.Instance.SetCurrentShowSpineDataPath(currentShowSpineDataPath);
				ModelBase<InfoDisplayModel>.Instance.SetCurrentShowAttachmentType(EAttachmentType.Spine);
			}
			else
			{
				if (type == EAttachmentType.Mp4.ToEnumString())
				{
					ModelBase<InfoDisplayModel>.Instance.SetCurrentShowAttachmentType(EAttachmentType.Mp4);
					Singleton<Log>.Instance.Error(ELogModule.PhoneSystem, ELogAuthor.LZK, "尚未支持附件类型为 " + type + ",的放大功能。 附件Id: " + attachmentId.ToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				Singleton<Log>.Instance.Error(ELogModule.PhoneSystem, ELogAuthor.LZK, "未知的附件类型 " + type + ", 附件Id: " + attachmentId.ToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ControllerBase<InfoDisplayController>.Instance.OpenInfoDisplayAttachmentBigImgView();
		}
	}

	// Token: 0x040090F7 RID: 37111
	public bool IsPhoneMsgTipEnable = true;
}
