using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001857 RID: 6231
[NullableContext(1)]
[Nullable(0)]
public class ChatView : UiTickViewBase
{
	// Token: 0x0600B231 RID: 45617 RVA: 0x002F8C58 File Offset: 0x002F6E58
	public ChatView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600B232 RID: 45618 RVA: 0x002F8C90 File Offset: 0x002F6E90
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITextInputComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIDynScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 7;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickAddPrivateChatButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickExpressionButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickQuickChatButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickSendButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickFriendDetailButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickCloseButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(16, new Action(this.OnClickCloseButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B233 RID: 45619 RVA: 0x002F9156 File Offset: 0x002F7356
	protected override void OnBeforeCreate()
	{
		UiInteractLogReport.RecordChatOpen();
	}

	// Token: 0x0600B234 RID: 45620 RVA: 0x002F9160 File Offset: 0x002F7360
	protected override UniTask OnBeforeStartAsync()
	{
		ChatView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ChatView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B235 RID: 45621 RVA: 0x002F91A3 File Offset: 0x002F73A3
	private ChatContentItem CreateNodeGrid(IChatContentDynamicData data, UUIItem uiItem, int index)
	{
		return new ChatContentItem();
	}

	// Token: 0x0600B236 RID: 45622 RVA: 0x002F91AC File Offset: 0x002F73AC
	protected override void OnStart()
	{
		this.IsInTouch = Singleton<Info>.Instance.IsInTouch();
		this.ChatInputMaxNum = ConfigCommonParamById.GetIntConfig("chat_character").Value;
		base.GetInputText(2).MaxInput = (uint)this.ChatInputMaxNum;
		base.GetItem(10).SetUIActive(false);
		AUIBaseActor gridActor = base.GetItem(10).GetOwner() as AUIBaseActor;
		this.ChatRoomItemLoopScrollView = new LoopScrollView<ChatRoomItem, ChatRoom>(base.GetLoopScrollViewComponent(15), gridActor, new Func<ChatRoomItem>(this.OnGridProxyCreate), false);
		ChatModel instance = ModelBase<ChatModel>.Instance;
		List<ChatRoom> allSortedChatRoom = instance.GetAllSortedChatRoom();
		this.RefreshChatRoomItem(allSortedChatRoom);
		ChatRoom chatRoom = instance.GetJoinedChatRoom();
		if (chatRoom == null)
		{
			chatRoom = this.JoinFirstChatRoom(allSortedChatRoom);
		}
		if (chatRoom is PrivateChatRoom)
		{
			this.RefreshPrivateChatRoom((PrivateChatRoom)chatRoom);
		}
		else if (chatRoom != null)
		{
			this.RefreshTeamChatRoom(chatRoom);
		}
		this.SetHasChat(chatRoom != null);
		this.TryActivateRefreshPlayInfoTimeDown();
		this.RefreshTextInputDefaultText();
		this.AddEvents();
		this.RefreshBlurItem();
	}

	// Token: 0x0600B237 RID: 45623 RVA: 0x002F929C File Offset: 0x002F749C
	private void RefreshBlurItem()
	{
		bool flag = Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView);
		UUIItem item = base.GetItem(23);
		UUIItem item2 = base.GetItem(24);
		if (flag)
		{
			item.SetUIActive(true);
			item2.SetUIActive(false);
			return;
		}
		item.SetUIActive(false);
		item2.SetUIActive(true);
	}

	// Token: 0x0600B238 RID: 45624 RVA: 0x002F92EC File Offset: 0x002F74EC
	protected override void OnBeforeDestroy()
	{
		this.ClearChatContent();
		this.RemoveRefreshPlayInfoTimeDown();
		ModelBase<ChatModel>.Instance.LeaveCurrentChatRoom();
		this.RemoveEvents();
		LoopScrollView<ChatRoomItem, ChatRoom> chatRoomItemLoopScrollView = this.ChatRoomItemLoopScrollView;
		if (chatRoomItemLoopScrollView != null)
		{
			chatRoomItemLoopScrollView.ClearGridProxies();
		}
		this.ChatRoomItemLoopScrollView = null;
		this.CurrentChatRoomList.Clear();
		this.IsTryScroll = false;
	}

	// Token: 0x0600B239 RID: 45625 RVA: 0x002F933F File Offset: 0x002F753F
	protected override void OnAfterDestroy()
	{
		UiInteractLogReport.RecordChatClose();
	}

	// Token: 0x0600B23A RID: 45626 RVA: 0x002F9346 File Offset: 0x002F7546
	protected override void OnTick(float delta)
	{
		bool isTryScroll = this.IsTryScroll;
	}

	// Token: 0x0600B23B RID: 45627 RVA: 0x002F9350 File Offset: 0x002F7550
	private void AddEvents()
	{
		UUITextInputComponent inputText = base.GetInputText(2);
		inputText.OnTextChange.Bind(new Action<string>(this.OnChatInputChanged));
		inputText.OnTextSubmit.Bind(new Action<string>(this.OnChatInputSubmit));
		inputText.OnInputActivateDelegate.Bind(new Action<bool>(this.OnInputActivate));
		inputText.OnCheckTextInputDelegate.Bind(new Func<string, bool>(this.OnCheckTextInput));
		inputText.OnTextClip.Bind(new Action<string>(this.OnCheckTextClip));
		base.GetUIDynScrollViewComponent(11).OnScrollValueChange.Bind(new Action<FVector2D>(this.OnChatScrollValueChange));
		ControllerBase<InputDistributeController>.Instance.BindAction("激活聊天", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputChat));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnCreatePrivateChatRoom, new Action<int>(this.OnCreatePrivateChatRoom));
		Singleton<EventSystem>.Instance.Add<ChatRoom>(EEventName.OnJoinChatRoom, new Action<ChatRoom>(this.OnJoinChatRoom));
		Singleton<EventSystem>.Instance.Add<ChatRoom, ChatContentData>(EEventName.OnAddChatContent, new Action<ChatRoom, ChatContentData>(this.OnAddChatContent));
		Singleton<EventSystem>.Instance.Add<ChatRoom>(EEventName.OnAddHistoryChatContentCompleted, new Action<ChatRoom>(this.OnAddHistoryChatContentCompleted));
		Singleton<EventSystem>.Instance.Add<ChatRoom>(EEventName.OnOpenChatRoom, new Action<ChatRoom>(this.OnOpenChatRoom));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRemovePrivateChatRoom, new Action<int>(this.OnRemoveOrClosePrivateChatRoom));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnClosePrivateChatRoom, new Action<int>(this.OnRemoveOrClosePrivateChatRoom));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnSelectExpression, new Action<int>(this.OnSelectExpression));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SearchPlayerInfo, new Action<int>(this.OnRefreshPrivateFriendInfo));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAddMutePlayer, new Action<int>(this.OnRefreshMutePlayer));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRemoveMutePlayer, new Action<int>(this.OnRefreshMutePlayer));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnChatPlayerInfoChanged, new Action<int>(this.OnChatPlayerInfoChanged));
		Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
	}

	// Token: 0x0600B23C RID: 45628 RVA: 0x002F957C File Offset: 0x002F777C
	private void RemoveEvents()
	{
		UUITextInputComponent inputText = base.GetInputText(2);
		inputText.OnTextChange.Unbind();
		inputText.OnTextSubmit.Unbind();
		inputText.OnInputActivateDelegate.Unbind();
		inputText.OnCheckTextInputDelegate.Unbind();
		inputText.OnTextClip.Unbind();
		base.GetUIDynScrollViewComponent(11).OnScrollValueChange.Unbind();
		ControllerBase<InputDistributeController>.Instance.UnBindAction("激活聊天", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputChat));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCreatePrivateChatRoom, new Action<int>(this.OnCreatePrivateChatRoom));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnJoinChatRoom, new Action<ChatRoom>(this.OnJoinChatRoom));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddChatContent, new Action<ChatRoom, ChatContentData>(this.OnAddChatContent));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddHistoryChatContentCompleted, new Action<ChatRoom>(this.OnAddHistoryChatContentCompleted));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnOpenChatRoom, new Action<ChatRoom>(this.OnOpenChatRoom));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemovePrivateChatRoom, new Action<int>(this.OnRemoveOrClosePrivateChatRoom));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClosePrivateChatRoom, new Action<int>(this.OnRemoveOrClosePrivateChatRoom));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectExpression, new Action<int>(this.OnSelectExpression));
		Singleton<EventSystem>.Instance.Remove(EEventName.SearchPlayerInfo, new Action<int>(this.OnRefreshPrivateFriendInfo));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddMutePlayer, new Action<int>(this.OnRefreshMutePlayer));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveMutePlayer, new Action<int>(this.OnRefreshMutePlayer));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChatPlayerInfoChanged, new Action<int>(this.OnChatPlayerInfoChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
	}

	// Token: 0x0600B23D RID: 45629 RVA: 0x002F975F File Offset: 0x002F795F
	private ChatRoomItem OnGridProxyCreate()
	{
		return this.NewPrivateChatFriendItem();
	}

	// Token: 0x0600B23E RID: 45630 RVA: 0x002F9767 File Offset: 0x002F7967
	private void OnChatInputChanged(string content)
	{
	}

	// Token: 0x0600B23F RID: 45631 RVA: 0x002F976C File Offset: 0x002F796C
	private void OnChatInputSubmit(string content)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "当聊天文本提交时";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("content", content);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.PrivateChatRequest(content, ChatContentType.Text);
	}

	// Token: 0x0600B240 RID: 45632 RVA: 0x002F97AA File Offset: 0x002F79AA
	private void OnInputActivate(bool state)
	{
	}

	// Token: 0x0600B241 RID: 45633 RVA: 0x002F97AC File Offset: 0x002F79AC
	private bool OnCheckTextInput(string inString)
	{
		return true;
	}

	// Token: 0x0600B242 RID: 45634 RVA: 0x002F97AF File Offset: 0x002F79AF
	private void OnCheckTextClip(string str)
	{
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ReachInputMaxNum", new object[]
		{
			this.ChatInputMaxNum
		});
	}

	// Token: 0x0600B243 RID: 45635 RVA: 0x002F97D4 File Offset: 0x002F79D4
	private void OnChatScrollValueChange(FVector2D inVector)
	{
		if (inVector.Y >= 0f)
		{
			this.CanRequestHistory = true;
			return;
		}
		if (!this.CanRequestHistory)
		{
			return;
		}
		if (ControllerBase<ChatController>.Instance.IsInRequestHistory)
		{
			return;
		}
		this.CanRequestHistory = false;
		ChatModel instance = ModelBase<ChatModel>.Instance;
		ChatRoom joinedChatRoom = instance.GetJoinedChatRoom();
		if (!(joinedChatRoom is PrivateChatRoom))
		{
			return;
		}
		instance.RequestPrivateRoomLocalHistory(joinedChatRoom as PrivateChatRoom);
	}

	// Token: 0x0600B244 RID: 45636 RVA: 0x002F9835 File Offset: 0x002F7A35
	private void OnCreatePrivateChatRoom(int targetPlayerId)
	{
	}

	// Token: 0x0600B245 RID: 45637 RVA: 0x002F9838 File Offset: 0x002F7A38
	private void OnInputChat(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
	{
		if (!this.HasChat)
		{
			return;
		}
		if (actionType != InputDistributeDefine.EActionType.Press)
		{
			return;
		}
		UUITextInputComponent inputText = base.GetInputText(2);
		if (!inputText.IsInputActive())
		{
			inputText.ActivateInputText();
		}
	}

	// Token: 0x0600B246 RID: 45638 RVA: 0x002F9868 File Offset: 0x002F7A68
	private void OnOpenChatRoom(ChatRoom chatRoom)
	{
		List<ChatRoom> allSortedChatRoom = ModelBase<ChatModel>.Instance.GetAllSortedChatRoom();
		this.RefreshChatRoomItem(allSortedChatRoom);
		ChatRoom joinedChatRoom = ModelBase<ChatModel>.Instance.GetJoinedChatRoom();
		if (joinedChatRoom == null)
		{
			return;
		}
		this.SelectChatRoom(joinedChatRoom, allSortedChatRoom);
		if (joinedChatRoom.GetUniqueId() != chatRoom.GetUniqueId())
		{
			return;
		}
		if (joinedChatRoom is PrivateChatRoom)
		{
			this.RefreshPrivateChatRoom((PrivateChatRoom)joinedChatRoom);
		}
		else
		{
			this.RefreshTeamChatRoom(joinedChatRoom);
		}
		this.SetHasChat(true);
	}

	// Token: 0x0600B247 RID: 45639 RVA: 0x002F98D4 File Offset: 0x002F7AD4
	private void OnAddChatContent(ChatRoom chatRoom, ChatContentData chatContentData)
	{
		ChatModel instance = ModelBase<ChatModel>.Instance;
		ChatRoom joinedChatRoom = instance.GetJoinedChatRoom();
		if (joinedChatRoom != null)
		{
			int uniqueId = joinedChatRoom.GetUniqueId();
			int uniqueId2 = chatRoom.GetUniqueId();
			List<ChatRoom> allSortedChatRoom = instance.GetAllSortedChatRoom();
			this.RefreshChatRoomItem(allSortedChatRoom);
			this.SelectChatRoom(joinedChatRoom, allSortedChatRoom);
			if (uniqueId == uniqueId2)
			{
				this.CheckIfBlockThenAddChatContent(chatContentData).Forget();
			}
		}
	}

	// Token: 0x0600B248 RID: 45640 RVA: 0x002F9924 File Offset: 0x002F7B24
	private UniTask CheckIfBlockThenAddChatContent(ChatContentData chatContentData)
	{
		ChatView.<CheckIfBlockThenAddChatContent>d__37 <CheckIfBlockThenAddChatContent>d__;
		<CheckIfBlockThenAddChatContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckIfBlockThenAddChatContent>d__.<>4__this = this;
		<CheckIfBlockThenAddChatContent>d__.chatContentData = chatContentData;
		<CheckIfBlockThenAddChatContent>d__.<>1__state = -1;
		<CheckIfBlockThenAddChatContent>d__.<>t__builder.Start<ChatView.<CheckIfBlockThenAddChatContent>d__37>(ref <CheckIfBlockThenAddChatContent>d__);
		return <CheckIfBlockThenAddChatContent>d__.<>t__builder.Task;
	}

	// Token: 0x0600B249 RID: 45641 RVA: 0x002F9970 File Offset: 0x002F7B70
	private void OnJoinChatRoom(ChatRoom chatRoom)
	{
		if (ModelBase<ChatModel>.Instance.GetJoinedChatRoom().GetUniqueId() != chatRoom.GetUniqueId())
		{
			return;
		}
		List<ChatRoom> allSortedChatRoom = ModelBase<ChatModel>.Instance.GetAllSortedChatRoom();
		if (chatRoom is PrivateChatRoom)
		{
			this.RefreshPrivateChatRoom((PrivateChatRoom)chatRoom);
			this.SelectChatRoom(chatRoom, allSortedChatRoom);
		}
		else if (chatRoom is TeamChatRoom || chatRoom is WorldChatRoom)
		{
			this.RefreshTeamChatRoom(chatRoom);
			this.SelectChatRoom(chatRoom, allSortedChatRoom);
		}
		this.SetHasChat(true);
	}

	// Token: 0x0600B24A RID: 45642 RVA: 0x002F99E4 File Offset: 0x002F7BE4
	private void OnAddHistoryChatContentCompleted(ChatRoom chatRoom)
	{
		if (!(chatRoom is PrivateChatRoom))
		{
			return;
		}
		this.IsTryScroll = false;
		ChatRoom joinedChatRoom = ModelBase<ChatModel>.Instance.GetJoinedChatRoom();
		if (joinedChatRoom == null)
		{
			List<ChatRoom> allSortedChatRoom = ModelBase<ChatModel>.Instance.GetAllSortedChatRoom();
			this.RefreshChatRoomItem(allSortedChatRoom);
			this.JoinPrivateChatRoom((PrivateChatRoom)chatRoom);
			return;
		}
		if (joinedChatRoom.GetUniqueId() != chatRoom.GetUniqueId())
		{
			return;
		}
		this.RefreshChatContent(joinedChatRoom).Forget();
		this.SetHasChat(true);
	}

	// Token: 0x0600B24B RID: 45643 RVA: 0x002F9A50 File Offset: 0x002F7C50
	private void OnRemoveOrClosePrivateChatRoom(int targetPlayerId)
	{
		List<ChatRoom> allSortedChatRoom = ModelBase<ChatModel>.Instance.GetAllSortedChatRoom();
		this.RefreshChatRoomItem(allSortedChatRoom);
		ChatRoom chatRoom = this.JoinFirstChatRoom(allSortedChatRoom);
		if (chatRoom == null)
		{
			this.SetHasChat(false);
			return;
		}
		PrivateChatRoom privateChatRoom = chatRoom as PrivateChatRoom;
		if (privateChatRoom != null)
		{
			this.RefreshPrivateChatRoom(privateChatRoom);
			return;
		}
		this.RefreshTeamChatRoom(chatRoom);
	}

	// Token: 0x0600B24C RID: 45644 RVA: 0x002F9A9C File Offset: 0x002F7C9C
	private void OnSelectExpression(int expressionId)
	{
		ChatRoom joinedChatRoom = ModelBase<ChatModel>.Instance.GetJoinedChatRoom();
		if (joinedChatRoom == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Chat, ELogAuthor.LJQ, "当前没有加入任何一个聊天室", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (joinedChatRoom is PrivateChatRoom)
		{
			int targetPlayerId = ((PrivateChatRoom)joinedChatRoom).GetTargetPlayerId();
			if (targetPlayerId == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Chat;
				ELogAuthor author = ELogAuthor.LJQ;
				string message = "私聊对象玩家Id不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("targetPlayerId", targetPlayerId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
		}
		this.PrivateChatRequest(expressionId.ToString(), ChatContentType.Emoji);
	}

	// Token: 0x0600B24D RID: 45645 RVA: 0x002F9B2A File Offset: 0x002F7D2A
	private void OnClickAddPrivateChatButton()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SelectedFriendChatView, null, null);
	}

	// Token: 0x0600B24E RID: 45646 RVA: 0x002F9B3D File Offset: 0x002F7D3D
	private void OnClickExpressionButton()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ChatExpressionView, null, null);
	}

	// Token: 0x0600B24F RID: 45647 RVA: 0x002F9B50 File Offset: 0x002F7D50
	private void OnClickQuickChatButton()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuickChatView, null, null);
	}

	// Token: 0x0600B250 RID: 45648 RVA: 0x002F9B64 File Offset: 0x002F7D64
	private void OnClickSendButton()
	{
		string text = base.GetInputText(2).GetText();
		this.PrivateChatRequest(text, ChatContentType.Text);
	}

	// Token: 0x0600B251 RID: 45649 RVA: 0x002F9B88 File Offset: 0x002F7D88
	private void OnClickFriendDetailButton()
	{
		ChatRoom joinedChatRoom = ModelBase<ChatModel>.Instance.GetJoinedChatRoom();
		if (joinedChatRoom == null)
		{
			return;
		}
		if (!(base.GetButton(8).GetOwner().GetComponentByClass(UUIItem.StaticClass()) is UUIItem))
		{
			return;
		}
		if (joinedChatRoom is PrivateChatRoom)
		{
			int playerId = ((PrivateChatRoom)joinedChatRoom).GetTargetPlayerId();
			ControllerBase<FriendController>.Instance.RequestPlayerCurrentDeactivationState(playerId, delegate(bool deactivation)
			{
				if (deactivation)
				{
					string localTextNew = ConfigMultiTextLang.GetLocalTextNew("PlayerDeleteSelf", null);
					ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.FloatLinePrompt, null, null, new string[]
					{
						localTextNew
					}, null, null, null, null, null, false, null);
					return;
				}
				Singleton<UiManager>.Instance.OpenView(EUiViewName.ChatOption, playerId, null);
			});
		}
	}

	// Token: 0x0600B252 RID: 45650 RVA: 0x002F9C02 File Offset: 0x002F7E02
	private void OnClickCloseButton()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ChatView, null);
	}

	// Token: 0x0600B253 RID: 45651 RVA: 0x002F9C14 File Offset: 0x002F7E14
	private void RefreshTextInputDefaultText()
	{
		UUIText text = base.GetText(18);
		if (!Singleton<InputSettingsManager>.Instance.GetActionKeyDisplayData(this.InputKeyDisplayDataRef, "激活聊天"))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PrefabTextItem_1493640674_Text", Array.Empty<object>());
			return;
		}
		string[] displayKeyNameList = this.InputKeyDisplayDataRef.GetDisplayKeyNameList(0);
		if (displayKeyNameList == null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PrefabTextItem_1493640674_Text", Array.Empty<object>());
			return;
		}
		string text2 = "";
		foreach (string keyName in displayKeyNameList)
		{
			string keyIconPath = Singleton<InputSettings>.Instance.GetKeyIconPath(keyName);
			text2 = text2 + "<texture=" + keyIconPath + ">";
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "SendChatText", new <>z__ReadOnlySingleElementList<object>(text2));
	}

	// Token: 0x0600B254 RID: 45652 RVA: 0x002F9CD4 File Offset: 0x002F7ED4
	private void PrivateChatRequest(string text, ChatContentType chatContentType)
	{
		if (StringUtils.IsEmpty(text))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InputChatContent", Array.Empty<object>());
			return;
		}
		if (text.Length > this.ChatInputMaxNum)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ReachInputMaxNum", new object[]
			{
				this.ChatInputMaxNum
			});
			return;
		}
		ChatRoom joinedChatRoom = ModelBase<ChatModel>.Instance.GetJoinedChatRoom();
		if (joinedChatRoom == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Chat, ELogAuthor.LJQ, "当前没有加入任何一个聊天室", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		double lastTimeStamp = joinedChatRoom.GetLastTimeStamp();
		if (Singleton<TimeUtil>.Instance.GetServerTime() - lastTimeStamp < (double)(joinedChatRoom.ChatCd / Singleton<TimeUtil>.Instance.InverseMillisecond))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ChatCdText", Array.Empty<object>());
			return;
		}
		if (joinedChatRoom is PrivateChatRoom)
		{
			int targetPlayerId = ((PrivateChatRoom)joinedChatRoom).GetTargetPlayerId();
			if (targetPlayerId == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Chat;
				ELogAuthor author = ELogAuthor.LJQ;
				string message = "私聊对象玩家Id不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("targetPlayerId", targetPlayerId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (ModelBase<FriendModel>.Instance.HasBlockedPlayer(targetPlayerId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ChatRefuseText", Array.Empty<object>());
				return;
			}
			ControllerBase<ChatController>.Instance.PrivateChatRequest(chatContentType, text, targetPlayerId);
		}
		else if (joinedChatRoom is TeamChatRoom)
		{
			ControllerBase<ChatController>.Instance.ChannelChatRequest(chatContentType, text, SubChatChannelType.MatchTeam);
		}
		else if (joinedChatRoom is WorldChatRoom)
		{
			ControllerBase<ChatController>.Instance.ChannelChatRequest(chatContentType, text, SubChatChannelType.WorldTeam);
		}
		base.GetInputText(2).SetText("", false);
	}

	// Token: 0x0600B255 RID: 45653 RVA: 0x002F9E54 File Offset: 0x002F8054
	private void SetHasChat(bool bHasChat)
	{
		UUIItem item = base.GetItem(12);
		UUIItem item2 = base.GetItem(13);
		item.SetUIActive(bHasChat);
		item2.SetUIActive(!bHasChat);
		this.HasChat = bHasChat;
	}

	// Token: 0x0600B256 RID: 45654 RVA: 0x002F9E89 File Offset: 0x002F8089
	private void SetFriendDetailButtonVisible(bool bVisible)
	{
		AUIBaseActor auibaseActor = base.GetButton(8).GetOwner() as AUIBaseActor;
		if (auibaseActor == null)
		{
			return;
		}
		UUIItem uiitem = auibaseActor.GetUIItem();
		if (uiitem == null)
		{
			return;
		}
		uiitem.SetUIActive(bVisible);
	}

	// Token: 0x0600B257 RID: 45655 RVA: 0x002F9EB4 File Offset: 0x002F80B4
	private void RefreshPrivateChatRoom(PrivateChatRoom privateChatRoom)
	{
		if (privateChatRoom == null)
		{
			return;
		}
		if (!privateChatRoom.CanChat())
		{
			return;
		}
		List<ChatRoom> allSortedChatRoom = ModelBase<ChatModel>.Instance.GetAllSortedChatRoom();
		this.RefreshIsOnline(privateChatRoom, true);
		this.RefreshPlayerName(privateChatRoom, false);
		this.RefreshThirdPartyItem(privateChatRoom);
		this.RefreshPcItem(privateChatRoom, false);
		this.SelectChatRoom(privateChatRoom, allSortedChatRoom);
		this.RefreshChatContent(privateChatRoom).Forget();
		this.SetFriendDetailButtonVisible(true);
		this.SetHasChat(true);
	}

	// Token: 0x0600B258 RID: 45656 RVA: 0x002F9F1C File Offset: 0x002F811C
	private void RefreshTeamChatRoom(ChatRoom chatRoom)
	{
		if (chatRoom == null)
		{
			return;
		}
		List<ChatRoom> allSortedChatRoom = ModelBase<ChatModel>.Instance.GetAllSortedChatRoom();
		this.SelectChatRoom(chatRoom, allSortedChatRoom);
		this.RefreshChatContent(chatRoom).Forget();
		this.RefreshThirdPartyItem(null);
		this.RefreshPcItem(null, true);
		this.RefreshIsOnline(null, false);
		this.RefreshPlayerName(null, true);
		this.SetFriendDetailButtonVisible(false);
		this.SetHasChat(true);
	}

	// Token: 0x0600B259 RID: 45657 RVA: 0x002F9F7C File Offset: 0x002F817C
	private UniTask RefreshChatContent(ChatRoom chatRoom)
	{
		ChatView.<RefreshChatContent>d__54 <RefreshChatContent>d__;
		<RefreshChatContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshChatContent>d__.<>4__this = this;
		<RefreshChatContent>d__.chatRoom = chatRoom;
		<RefreshChatContent>d__.<>1__state = -1;
		<RefreshChatContent>d__.<>t__builder.Start<ChatView.<RefreshChatContent>d__54>(ref <RefreshChatContent>d__);
		return <RefreshChatContent>d__.<>t__builder.Task;
	}

	// Token: 0x0600B25A RID: 45658 RVA: 0x002F9FC8 File Offset: 0x002F81C8
	private void AddChatContents(List<ChatContentData> chatContentList)
	{
		if (chatContentList.Count <= 0)
		{
			this.AddChatContent(new List<ChatContentData>(), new bool?(false));
			return;
		}
		this.AddChatContent(chatContentList, new bool?(false));
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			DynamicScrollView<ChatContentItem, ChatContentDynamicItem, IChatContentDynamicData> chatLoopScrollView = this.ChatLoopScrollView;
			if (chatLoopScrollView == null)
			{
				return;
			}
			chatLoopScrollView.ScrollToItemIndex(chatContentList.Count - 1, true, false);
		}, 500f, null, null, true, 1f);
	}

	// Token: 0x0600B25B RID: 45659 RVA: 0x002FA040 File Offset: 0x002F8240
	private void AddChatContent(List<ChatContentData> chatContentDataList, bool? selectLastItem = false)
	{
		List<IChatContentDynamicData> dataList = new List<IChatContentDynamicData>();
		foreach (ChatContentData chatContentData in chatContentDataList)
		{
			if (chatContentData.NoticeType == ChatChannelNoticeType.EnterTeam || chatContentData.NoticeType == ChatChannelNoticeType.ExitTeam)
			{
				ChatContentDynamicData item = new ChatContentDynamicData
				{
					ChatContentData = chatContentData,
					Type = EChatContentType.Tips
				};
				dataList.Add(item);
			}
			else if (chatContentData.IsOwnSend())
			{
				ChatContentDynamicData item2 = new ChatContentDynamicData
				{
					ChatContentData = chatContentData,
					Type = EChatContentType.Right
				};
				dataList.Add(item2);
			}
			else
			{
				ChatContentDynamicData item3 = new ChatContentDynamicData
				{
					ChatContentData = chatContentData,
					Type = EChatContentType.Left
				};
				dataList.Add(item3);
			}
		}
		this.ChatContentDataList = chatContentDataList;
		DynamicScrollView<ChatContentItem, ChatContentDynamicItem, IChatContentDynamicData> chatLoopScrollView = this.ChatLoopScrollView;
		if (chatLoopScrollView != null)
		{
			chatLoopScrollView.RefreshByData(dataList.ToArray(), true, true);
		}
		bool? flag = selectLastItem;
		bool flag2 = false;
		if ((flag.GetValueOrDefault() == flag2 & flag != null) || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		DynamicScrollView<ChatContentItem, ChatContentDynamicItem, IChatContentDynamicData> chatLoopScrollView2 = this.ChatLoopScrollView;
		if (chatLoopScrollView2 == null)
		{
			return;
		}
		Action <>9__2;
		Action <>9__1;
		chatLoopScrollView2.BindLateUpdate(delegate(float _)
		{
			DynamicScrollView<ChatContentItem, ChatContentDynamicItem, IChatContentDynamicData> chatLoopScrollView3 = this.ChatLoopScrollView;
			if (chatLoopScrollView3 != null && !chatLoopScrollView3.CheckIfAllRefreshFinished())
			{
				return;
			}
			DynamicScrollView<ChatContentItem, ChatContentDynamicItem, IChatContentDynamicData> chatLoopScrollView4 = this.ChatLoopScrollView;
			if (chatLoopScrollView4 != null)
			{
				UniTask task = chatLoopScrollView4.ScrollToItemIndex(dataList.Count - 1, true, false);
				Action continuationFunction;
				if ((continuationFunction = <>9__1) == null)
				{
					continuationFunction = (<>9__1 = delegate()
					{
						UniTask task2 = GameUtils.WaitFrame();
						Action continuationFunction2;
						if ((continuationFunction2 = <>9__2) == null)
						{
							continuationFunction2 = (<>9__2 = delegate()
							{
								if (this.GetInputText(2).IsInputActive())
								{
									return;
								}
								DynamicScrollView<ChatContentItem, ChatContentDynamicItem, IChatContentDynamicData> chatLoopScrollView6 = this.ChatLoopScrollView;
								foreach (ChatContentItem chatContentItem in ((chatLoopScrollView6 != null) ? chatLoopScrollView6.GetScrollItemItems() : null) ?? Array.Empty<ChatContentItem>())
								{
									if (chatContentItem.Data.ChatContentData.TimeStamp == dataList[dataList.Count - 1].ChatContentData.TimeStamp)
									{
										ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(chatContentItem.GetInteractItem(), true, true, false);
										return;
									}
								}
							});
						}
						task2.ContinueWith(continuationFunction2);
					});
				}
				task.ContinueWith(continuationFunction);
			}
			DynamicScrollView<ChatContentItem, ChatContentDynamicItem, IChatContentDynamicData> chatLoopScrollView5 = this.ChatLoopScrollView;
			if (chatLoopScrollView5 == null)
			{
				return;
			}
			chatLoopScrollView5.UnBindLateUpdate();
		});
	}

	// Token: 0x0600B25C RID: 45660 RVA: 0x002FA190 File Offset: 0x002F8390
	private void ClearChatContent()
	{
		foreach (ChatContentBase chatContentBase in this.ChatContentList)
		{
			chatContentBase.Destroy(null);
		}
		this.ChatContentList.Clear();
	}

	// Token: 0x0600B25D RID: 45661 RVA: 0x002FA1EC File Offset: 0x002F83EC
	private void SelectChatRoom(ChatRoom selectPrivateChatRoom, List<ChatRoom> chatRoomList)
	{
		if (selectPrivateChatRoom == null)
		{
			return;
		}
		int num = chatRoomList.IndexOf(selectPrivateChatRoom);
		if (num < 0)
		{
			return;
		}
		this.ChatRoomItemLoopScrollView.SelectGridProxy(num, false);
	}

	// Token: 0x0600B25E RID: 45662 RVA: 0x002FA218 File Offset: 0x002F8418
	[NullableContext(2)]
	private void RefreshIsOnline(PrivateChatRoom privateChatRoom, bool isShow = true)
	{
		UUIItem item = base.GetItem(5);
		UUIItem item2 = base.GetItem(17);
		if (!isShow)
		{
			item.SetUIActive(false);
			item2.SetUIActive(false);
			return;
		}
		item.SetUIActive(false);
		item2.SetUIActive(false);
		if (privateChatRoom == null)
		{
			return;
		}
		int num = this.CurrentChatRoomList.IndexOf(privateChatRoom);
		if (num < 0)
		{
			return;
		}
		ChatRoomItem chatRoomItem = this.ChatRoomItemLoopScrollView.UnsafeGetGridProxy(num, false);
		if (chatRoomItem == null)
		{
			return;
		}
		chatRoomItem.RefreshIsOnline(privateChatRoom);
	}

	// Token: 0x0600B25F RID: 45663 RVA: 0x002FA284 File Offset: 0x002F8484
	[NullableContext(2)]
	private void RefreshPlayerName(PrivateChatRoom privateChatRoom, bool showTitle = false)
	{
		UUIText text = base.GetText(7);
		UUIText text2 = base.GetText(6);
		if (showTitle)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "CurrentTeam", Array.Empty<object>());
			text.SetColor(ChatDefine.playerRealNameColor);
			text2.SetUIActive(false);
			return;
		}
		string playerName = privateChatRoom.GetPlayerName();
		string playerRemarks = privateChatRoom.GetPlayerRemarks();
		text2.SetUIActive(false);
		if (!string.IsNullOrEmpty(playerRemarks))
		{
			text.SetText(playerRemarks, true);
			if (text != null)
			{
				text.SetColor(ChatDefine.playerMarkNameColor);
				return;
			}
		}
		else
		{
			text.SetText(playerName, true);
			text.SetColor(ChatDefine.playerRealNameColor);
		}
	}

	// Token: 0x0600B260 RID: 45664 RVA: 0x002FA314 File Offset: 0x002F8514
	private void TryActivateRefreshPlayInfoTimeDown()
	{
		this.RemoveRefreshPlayInfoTimeDown();
		ChatRoom joinedChatRoom = ModelBase<ChatModel>.Instance.GetJoinedChatRoom();
		if (joinedChatRoom == null)
		{
			return;
		}
		if (!(joinedChatRoom is PrivateChatRoom))
		{
			return;
		}
		this.RefreshPlayInfoTimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnRefreshPlayInfoTimeDown), 10000f, 1f, null, null, true);
	}

	// Token: 0x0600B261 RID: 45665 RVA: 0x002FA368 File Offset: 0x002F8568
	private void RemoveRefreshPlayInfoTimeDown()
	{
		if (!TimerSystem.GameplayTimeInstance.Has(this.RefreshPlayInfoTimerId))
		{
			return;
		}
		TimerSystem.GameplayTimeInstance.Remove(this.RefreshPlayInfoTimerId);
		this.RefreshPlayInfoTimerId = null;
	}

	// Token: 0x0600B262 RID: 45666 RVA: 0x002FA398 File Offset: 0x002F8598
	private void OnRefreshPlayInfoTimeDown(float delta)
	{
		ChatRoom joinedChatRoom = ModelBase<ChatModel>.Instance.GetJoinedChatRoom();
		if (joinedChatRoom == null)
		{
			return;
		}
		PrivateChatRoom privateChatRoom = joinedChatRoom as PrivateChatRoom;
		if (privateChatRoom == null)
		{
			return;
		}
		int targetPlayerId = privateChatRoom.GetTargetPlayerId();
		ModelBase<FriendModel>.Instance.ClearFriendSearchResults();
		ControllerBase<FriendController>.Instance.RequestSearchPlayerBasicInfo(targetPlayerId, true);
	}

	// Token: 0x0600B263 RID: 45667 RVA: 0x002FA3DC File Offset: 0x002F85DC
	private void OnRefreshPrivateFriendInfo(int playerId)
	{
		PrivateChatRoom privateChatRoom = ModelBase<ChatModel>.Instance.GetPrivateChatRoom(playerId);
		if (privateChatRoom == null)
		{
			return;
		}
		this.RefreshIsOnline(privateChatRoom, true);
		this.RefreshPlayerName(privateChatRoom, false);
	}

	// Token: 0x0600B264 RID: 45668 RVA: 0x002FA40C File Offset: 0x002F860C
	private void OnRefreshMutePlayer(int playerId)
	{
		PrivateChatRoom privateChatRoom = ModelBase<ChatModel>.Instance.GetPrivateChatRoom(playerId);
		if (privateChatRoom == null)
		{
			return;
		}
		int num = this.CurrentChatRoomList.IndexOf(privateChatRoom);
		if (num < 0)
		{
			return;
		}
		ChatRoomItem chatRoomItem = this.ChatRoomItemLoopScrollView.UnsafeGetGridProxy(num, false);
		if (chatRoomItem == null)
		{
			return;
		}
		chatRoomItem.RefreshMuteItem();
	}

	// Token: 0x0600B265 RID: 45669 RVA: 0x002FA454 File Offset: 0x002F8654
	private void OnChatPlayerInfoChanged(int playerId)
	{
		PrivateChatRoom privateChatRoom = ModelBase<ChatModel>.Instance.GetPrivateChatRoom(playerId);
		if (privateChatRoom == null)
		{
			return;
		}
		int num = this.CurrentChatRoomList.IndexOf(privateChatRoom);
		if (num < 0)
		{
			return;
		}
		ChatRoomItem chatRoomItem = this.ChatRoomItemLoopScrollView.UnsafeGetGridProxy(num, false);
		if (chatRoomItem == null)
		{
			return;
		}
		chatRoomItem.RefreshPlayerTexture();
	}

	// Token: 0x0600B266 RID: 45670 RVA: 0x002FA49A File Offset: 0x002F869A
	private void InputControllerChange(EInputControllerType last, EInputControllerType now)
	{
		if (this.IsInTouch && !Singleton<Info>.Instance.IsInTouch())
		{
			base.CloseMe(null);
			return;
		}
		this.IsInTouch = Singleton<Info>.Instance.IsInTouch();
		this.RefreshTextInputDefaultText();
	}

	// Token: 0x0600B267 RID: 45671 RVA: 0x002FA4CE File Offset: 0x002F86CE
	private void RefreshChatRoomItem(List<ChatRoom> chatRoomList)
	{
		this.CurrentChatRoomList = chatRoomList;
		LoopScrollView<ChatRoomItem, ChatRoom> chatRoomItemLoopScrollView = this.ChatRoomItemLoopScrollView;
		if (chatRoomItemLoopScrollView == null)
		{
			return;
		}
		chatRoomItemLoopScrollView.RefreshByData(chatRoomList, false, null, false);
	}

	// Token: 0x0600B268 RID: 45672 RVA: 0x002FA4EB File Offset: 0x002F86EB
	private ChatRoomItem NewPrivateChatFriendItem()
	{
		ChatRoomItem chatRoomItem = new ChatRoomItem();
		chatRoomItem.BindOnClicked(new Action<EChatRoomType, int>(this.OnChatRoomClicked));
		return chatRoomItem;
	}

	// Token: 0x0600B269 RID: 45673 RVA: 0x002FA504 File Offset: 0x002F8704
	private void OnChatRoomClicked(EChatRoomType chatType, int targetPlayerId)
	{
		ChatModel instance = ModelBase<ChatModel>.Instance;
		ChatRoom chatRoom = null;
		switch (chatType)
		{
		case EChatRoomType.Private:
			if (ModelBase<FriendModel>.Instance.GetFriendById(targetPlayerId) == null)
			{
				return;
			}
			chatRoom = instance.GetPrivateChatRoom(targetPlayerId);
			if (chatRoom is PrivateChatRoom)
			{
				this.JoinPrivateChatRoom((PrivateChatRoom)chatRoom);
			}
			break;
		case EChatRoomType.Team:
			chatRoom = instance.GetTeamChatRoom();
			this.JoinTeamChatRoom();
			break;
		case EChatRoomType.World:
			chatRoom = instance.GetWorldChatRoom();
			this.JoinWorldChatRoom();
			break;
		}
		if (chatRoom != null)
		{
			this.SelectChatRoom(chatRoom, this.CurrentChatRoomList);
		}
	}

	// Token: 0x0600B26A RID: 45674 RVA: 0x002FA588 File Offset: 0x002F8788
	private void JoinPrivateChatRoom(PrivateChatRoom privateChatRoom)
	{
		ChatModel instance = ModelBase<ChatModel>.Instance;
		int targetPlayerId = privateChatRoom.GetTargetPlayerId();
		if (targetPlayerId == 0)
		{
			return;
		}
		if (!privateChatRoom.CanChat())
		{
			return;
		}
		PrivateChatRoom privateChatRoom2 = instance.GetJoinedChatRoom() as PrivateChatRoom;
		if (privateChatRoom2 != null && privateChatRoom2.GetTargetPlayerId() == targetPlayerId)
		{
			return;
		}
		instance.JoinChatRoom(privateChatRoom);
	}

	// Token: 0x0600B26B RID: 45675 RVA: 0x002FA5D0 File Offset: 0x002F87D0
	private void JoinTeamChatRoom()
	{
		ChatModel instance = ModelBase<ChatModel>.Instance;
		TeamChatRoom teamChatRoom = instance.GetTeamChatRoom();
		if (teamChatRoom != null)
		{
			instance.JoinChatRoom(teamChatRoom);
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.Chat, ELogAuthor.LJQ, "加入队伍聊天室失败，聊天室未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600B26C RID: 45676 RVA: 0x002FA614 File Offset: 0x002F8814
	private void JoinWorldChatRoom()
	{
		ChatModel instance = ModelBase<ChatModel>.Instance;
		WorldChatRoom worldChatRoom = instance.GetWorldChatRoom();
		if (worldChatRoom != null)
		{
			instance.JoinChatRoom(worldChatRoom);
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.Chat, ELogAuthor.LJQ, "加入世界聊天室失败，聊天室未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600B26D RID: 45677 RVA: 0x002FA658 File Offset: 0x002F8858
	[return: Nullable(2)]
	private ChatRoom JoinFirstChatRoom(List<ChatRoom> chatRoomList)
	{
		foreach (ChatRoom chatRoom in chatRoomList)
		{
			PrivateChatRoom privateChatRoom = chatRoom as PrivateChatRoom;
			if (privateChatRoom != null)
			{
				if (privateChatRoom.CanChat())
				{
					this.JoinPrivateChatRoom(privateChatRoom);
					return chatRoom;
				}
			}
			else
			{
				if (chatRoom is TeamChatRoom)
				{
					this.JoinTeamChatRoom();
					return chatRoom;
				}
				if (chatRoom is WorldChatRoom)
				{
					this.JoinWorldChatRoom();
					return chatRoom;
				}
			}
		}
		return null;
	}

	// Token: 0x0600B26E RID: 45678 RVA: 0x002FA6E4 File Offset: 0x002F88E4
	[NullableContext(2)]
	private void RefreshThirdPartyItem(PrivateChatRoom privateChatRoom)
	{
		if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
		{
			bool flag = privateChatRoom != null && !string.IsNullOrEmpty((privateChatRoom != null) ? privateChatRoom.GetThirdPartyUserId() : null);
			UUITexture texture = base.GetTexture(21);
			if (texture != null)
			{
				texture.SetUIActive(flag);
			}
			string thirdPartyLogoTexturePath = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyLogoTexturePath(ELogoSize.Medium);
			base.SetTextureByPath(thirdPartyLogoTexturePath, base.GetTexture(21), null, null);
			if (flag && privateChatRoom != null)
			{
				UUIText text = base.GetText(22);
				if (text != null)
				{
					text.SetText(privateChatRoom.GetThirdPartyOnlineId(), true);
				}
				UUIText text2 = base.GetText(22);
				if (text2 != null)
				{
					text2.SetUIActive(true);
				}
				string thirdPartyTextColor = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyTextColor(EConsoleColorSet.Set1);
				UUIText text3 = base.GetText(22);
				if (text3 == null)
				{
					return;
				}
				text3.SetColor(FColor.FromHex(thirdPartyTextColor));
				return;
			}
			else
			{
				UUIText text4 = base.GetText(22);
				if (text4 == null)
				{
					return;
				}
				text4.SetUIActive(false);
				return;
			}
		}
		else
		{
			UUITexture texture2 = base.GetTexture(21);
			if (texture2 != null)
			{
				texture2.SetUIActive(false);
			}
			UUIText text5 = base.GetText(22);
			if (text5 == null)
			{
				return;
			}
			text5.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0600B26F RID: 45679 RVA: 0x002FA7E8 File Offset: 0x002F89E8
	[NullableContext(2)]
	private void RefreshPcItem(PrivateChatRoom privateChatRoom, bool ifTeamRoom = false)
	{
		if (ifTeamRoom)
		{
			UUIItem item = base.GetItem(25);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
		{
			bool flag = privateChatRoom != null && !string.IsNullOrEmpty((privateChatRoom != null) ? privateChatRoom.GetThirdPartyUserId() : null);
			UUIItem item2 = base.GetItem(25);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!flag);
			return;
		}
		else
		{
			UUIItem item3 = base.GetItem(25);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0600B270 RID: 45680 RVA: 0x002FA85D File Offset: 0x002F8A5D
	protected override void OnBeforeShow()
	{
		Singleton<GameSettingsDeviceRender>.Instance.TemporaryDisableFrameGeneration("ChatView");
	}

	// Token: 0x0600B271 RID: 45681 RVA: 0x002FA86E File Offset: 0x002F8A6E
	protected override void OnAfterHide()
	{
		Singleton<GameSettingsDeviceRender>.Instance.CancelTemporaryDisableFrameGeneration("ChatView");
	}

	// Token: 0x04005469 RID: 21609
	private List<ChatContentData> ChatContentDataList = new List<ChatContentData>();

	// Token: 0x0400546A RID: 21610
	private readonly List<ChatContentBase> ChatContentList = new List<ChatContentBase>();

	// Token: 0x0400546B RID: 21611
	private bool CanRequestHistory;

	// Token: 0x0400546C RID: 21612
	[Nullable(2)]
	private TimerHandle RefreshPlayInfoTimerId;

	// Token: 0x0400546D RID: 21613
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<ChatRoomItem, ChatRoom> ChatRoomItemLoopScrollView;

	// Token: 0x0400546E RID: 21614
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private DynamicScrollView<ChatContentItem, ChatContentDynamicItem, IChatContentDynamicData> ChatLoopScrollView;

	// Token: 0x0400546F RID: 21615
	[Nullable(2)]
	private ChatContentDynamicItem ChatBaseItem;

	// Token: 0x04005470 RID: 21616
	private List<ChatRoom> CurrentChatRoomList = new List<ChatRoom>();

	// Token: 0x04005471 RID: 21617
	public int ChatInputMaxNum;

	// Token: 0x04005472 RID: 21618
	private bool HasChat;

	// Token: 0x04005473 RID: 21619
	private bool IsTryScroll;

	// Token: 0x04005474 RID: 21620
	private readonly InputKeyDisplayData InputKeyDisplayDataRef = new InputKeyDisplayData();

	// Token: 0x04005475 RID: 21621
	private bool IsInTouch;

	// Token: 0x02007BF7 RID: 31735
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A5AB RID: 173483
		public const int AddPrivateChatButton = 0;

		// Token: 0x0402A5AC RID: 173484
		public const int ExpressionButton = 1;

		// Token: 0x0402A5AD RID: 173485
		public const int ChatInputText = 2;

		// Token: 0x0402A5AE RID: 173486
		public const int QuickChatButton = 3;

		// Token: 0x0402A5AF RID: 173487
		public const int SendButton = 4;

		// Token: 0x0402A5B0 RID: 173488
		public const int OnlineState = 5;

		// Token: 0x0402A5B1 RID: 173489
		public const int FriendRemarks = 6;

		// Token: 0x0402A5B2 RID: 173490
		public const int FriendNameText = 7;

		// Token: 0x0402A5B3 RID: 173491
		public const int FriendDetailButton = 8;

		// Token: 0x0402A5B4 RID: 173492
		public const int CloseButton = 9;

		// Token: 0x0402A5B5 RID: 173493
		public const int ChatFriendSourceItem = 10;

		// Token: 0x0402A5B6 RID: 173494
		public const int ChatScrollView = 11;

		// Token: 0x0402A5B7 RID: 173495
		public const int ChatItem = 12;

		// Token: 0x0402A5B8 RID: 173496
		public const int NoneItem = 13;

		// Token: 0x0402A5B9 RID: 173497
		public const int ChatScrollContent = 14;

		// Token: 0x0402A5BA RID: 173498
		public const int ChatRoomItemLoopScrollView = 15;

		// Token: 0x0402A5BB RID: 173499
		public const int MastButton = 16;

		// Token: 0x0402A5BC RID: 173500
		public const int OfflineState = 17;

		// Token: 0x0402A5BD RID: 173501
		public const int TextInputDefaultText = 18;

		// Token: 0x0402A5BE RID: 173502
		public const int InputItem = 19;

		// Token: 0x0402A5BF RID: 173503
		public const int MuteItem = 20;

		// Token: 0x0402A5C0 RID: 173504
		public const int ThirdPartyTexture = 21;

		// Token: 0x0402A5C1 RID: 173505
		public const int ThirdPartyText = 22;

		// Token: 0x0402A5C2 RID: 173506
		public const int FullBlur = 23;

		// Token: 0x0402A5C3 RID: 173507
		public const int PartialBlur = 24;

		// Token: 0x0402A5C4 RID: 173508
		public const int PcItem = 25;

		// Token: 0x0402A5C5 RID: 173509
		public const int ChatScrollItem = 26;
	}
}
