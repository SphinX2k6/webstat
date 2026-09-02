using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;

// Token: 0x02001844 RID: 6212
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ChatModel : ModelBase<ChatModel>
{
	// Token: 0x0600B17D RID: 45437 RVA: 0x002F5320 File Offset: 0x002F3520
	protected override bool OnInit()
	{
		this.ShowTimeDifferent = ConfigCommonParamById.GetIntConfig("ShowTimeDifferent").Value;
		return true;
	}

	// Token: 0x0600B17E RID: 45438 RVA: 0x002F534C File Offset: 0x002F354C
	protected override bool OnClear()
	{
		foreach (PrivateChatRoom privateChatRoom in this.PrivateChatRoomMap.Values)
		{
			privateChatRoom.Reset();
		}
		this.PrivateChatRoomMap.Clear();
		this.ChatRowDataList.Clear();
		this.MutePlayerIdList.Clear();
		this.CurrentChatRoom = null;
		this.ClearChatPlayerData();
		return true;
	}

	// Token: 0x0600B17F RID: 45439 RVA: 0x002F53D0 File Offset: 0x002F35D0
	public ChatPlayerData AddChatPlayerData(int playerId)
	{
		ChatPlayerData chatPlayerData = new ChatPlayerData(playerId);
		this.ChatPlayerDataMap[playerId] = chatPlayerData;
		return chatPlayerData;
	}

	// Token: 0x0600B180 RID: 45440 RVA: 0x002F53F4 File Offset: 0x002F35F4
	[NullableContext(2)]
	public ChatPlayerData GetChatPlayerData(int playerId)
	{
		ChatPlayerData result;
		this.ChatPlayerDataMap.TryGetValue(playerId, out result);
		return result;
	}

	// Token: 0x0600B181 RID: 45441 RVA: 0x002F5414 File Offset: 0x002F3614
	[NullableContext(2)]
	public void RefreshChatPlayerData(int playerId, int? playerIcon = null, string playerName = null, int? playerTitleId = null, int? playerTitleExParam = null)
	{
		ChatPlayerData chatPlayerData = this.GetChatPlayerData(playerId);
		if (chatPlayerData == null)
		{
			chatPlayerData = this.AddChatPlayerData(playerId);
		}
		int playerIcon2 = chatPlayerData.GetPlayerIcon();
		string playerName2 = chatPlayerData.GetPlayerName();
		PersonalModel instance = ModelBase<PersonalModel>.Instance;
		PersonalInfoData personalInfoData = instance.GetPersonalInfoData();
		if (personalInfoData != null && personalInfoData.PlayerId == playerId)
		{
			chatPlayerData.SetPlayerIcon(new int?(instance.GetHeadPhotoId()));
			chatPlayerData.SetPlayerName(personalInfoData.Name);
		}
		else
		{
			chatPlayerData.SetPlayerIcon(playerIcon);
			chatPlayerData.SetPlayerName(playerName);
			chatPlayerData.SetPlayerTitleId(playerTitleId);
			chatPlayerData.SetPlayerTitleExParam(playerTitleExParam);
		}
		int num = playerIcon2;
		int? num2 = playerIcon;
		if (!(num == num2.GetValueOrDefault() & num2 != null) || playerName2 != playerName)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnChatPlayerInfoChanged, playerId);
		}
	}

	// Token: 0x0600B182 RID: 45442 RVA: 0x002F54CD File Offset: 0x002F36CD
	public void ClearChatPlayerData()
	{
		this.ChatPlayerDataMap.Clear();
	}

	// Token: 0x0600B183 RID: 45443 RVA: 0x002F54DC File Offset: 0x002F36DC
	public void AddChatContent(ChatRoom chatRoom, string contentUniqueId, int senderPlayerId, string chatContentText, ChatContentType chatContentType, ChatChannelNoticeType noticeType, bool isOfflineMassage, double timeStamp, double lastTimeStamp, [Nullable(2)] string senderPlayerName = null, int? senderPlayerIcon = null, [Nullable(2)] string thirdOnlineId = null, [Nullable(2)] string thirdAvoidId = null)
	{
		ChatContentData p = chatRoom.AddChatContent(contentUniqueId, senderPlayerId, chatContentText, chatContentType, noticeType, isOfflineMassage, timeStamp, lastTimeStamp, senderPlayerName, senderPlayerIcon, thirdOnlineId, thirdAvoidId);
		int value = 0;
		EChatRoomType contentChatRoomType = EChatRoomType.None;
		PrivateChatRoom privateChatRoom = chatRoom as PrivateChatRoom;
		if (privateChatRoom != null)
		{
			value = privateChatRoom.GetTargetPlayerId();
			contentChatRoomType = EChatRoomType.Private;
		}
		else if (chatRoom is TeamChatRoom)
		{
			contentChatRoomType = EChatRoomType.Team;
		}
		else if (chatRoom is WorldChatRoom)
		{
			contentChatRoomType = EChatRoomType.World;
		}
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		if (!(senderPlayerId == id.GetValueOrDefault() & id != null))
		{
			this.SetChatRoomRedDot(chatRoom, true);
		}
		if (noticeType == ChatChannelNoticeType.None)
		{
			this.AddChatRowData(senderPlayerId, chatContentText, chatContentType, false, contentChatRoomType, timeStamp, new int?(value), senderPlayerName, senderPlayerIcon, true);
		}
		this.ClearAllCreateTime();
		Singleton<EventSystem>.Instance.Emit<ChatRoom, ChatContentData>(EEventName.OnAddChatContent, chatRoom, p);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshChatRedDot);
	}

	// Token: 0x0600B184 RID: 45444 RVA: 0x002F55A4 File Offset: 0x002F37A4
	private void ClearAllCreateTime()
	{
		foreach (PrivateChatRoom privateChatRoom in this.PrivateChatRoomMap.Values)
		{
			privateChatRoom.ClearCreateTime();
		}
	}

	// Token: 0x0600B185 RID: 45445 RVA: 0x002F55FC File Offset: 0x002F37FC
	public unsafe void RequestPrivateRoomLocalHistory(PrivateChatRoom chatRoom)
	{
		int uniqueId = chatRoom.GetUniqueId();
		string earliestHistoryContentUniqueId = chatRoom.GetEarliestHistoryContentUniqueId();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "===目前暂时屏蔽聊天本地缓存的请求===";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("chatUniqueId", uniqueId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("fromContentUniqueId", earliestHistoryContentUniqueId);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x0600B186 RID: 45446 RVA: 0x002F5674 File Offset: 0x002F3874
	public void AddChatRowData(int senderPlayerId, string chatContentText, ChatContentType chatContentType, bool isOfflineMassage, EChatRoomType contentChatRoomType, double timeStamp, int? targetPlayerId = null, [Nullable(2)] string senderPlayerName = null, int? senderPlayerIcon = null, bool bCheckLength = true)
	{
		this.PushChatRowData(senderPlayerId, chatContentText, chatContentType, isOfflineMassage, contentChatRoomType, timeStamp, targetPlayerId, senderPlayerName, senderPlayerIcon);
		if (bCheckLength && this.ChatRowDataList.Count > 10)
		{
			this.ShiftChatRowData();
		}
	}

	// Token: 0x0600B187 RID: 45447 RVA: 0x002F56AF File Offset: 0x002F38AF
	public void SortChatRowData()
	{
		this.ChatRowDataList.Sort((ChatRowData a, ChatRowData b) => (int)(a.TimeStamp - b.TimeStamp));
	}

	// Token: 0x0600B188 RID: 45448 RVA: 0x002F56DC File Offset: 0x002F38DC
	public void ClampChatRowDataListLength()
	{
		int count = this.ChatRowDataList.Count;
		if (count <= 10)
		{
			return;
		}
		int count2 = Math.Max(count - 10, 0);
		this.ChatRowDataList = this.ChatRowDataList.Skip(count2).ToList<ChatRowData>();
	}

	// Token: 0x0600B189 RID: 45449 RVA: 0x002F5720 File Offset: 0x002F3920
	public void DeletePrivateChat(int playerId)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "[ChatDebug]删除主界面聊天数据";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("playerId", playerId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		for (int i = 0; i < this.ChatRowDataList.Count; i++)
		{
			int? targetPlayerId = this.ChatRowDataList[i].TargetPlayerId;
			if (targetPlayerId.GetValueOrDefault() == playerId & targetPlayerId != null)
			{
				this.ChatRowDataList.RemoveAt(i);
				i--;
			}
		}
	}

	// Token: 0x0600B18A RID: 45450 RVA: 0x002F57AC File Offset: 0x002F39AC
	public void DeleteTeamChat()
	{
		Singleton<Log>.Instance.Info(ELogModule.Chat, ELogAuthor.LJQ, "[ChatDebug]删除主界面队伍聊天数据", default(ReadOnlySpan<ValueTuple<string, object>>));
		for (int i = 0; i < this.ChatRowDataList.Count; i++)
		{
			ChatRowData chatRowData = this.ChatRowDataList[i];
			if (chatRowData.ContentChatRoomType == EChatRoomType.Team || chatRowData.ContentChatRoomType == EChatRoomType.World)
			{
				this.ChatRowDataList.RemoveAt(i);
				i--;
			}
		}
	}

	// Token: 0x0600B18B RID: 45451 RVA: 0x002F581C File Offset: 0x002F3A1C
	public void SetTeamChatRowDataVisible(bool bVisible)
	{
		foreach (ChatRowData chatRowData in this.ChatRowDataList)
		{
			EChatRoomType contentChatRoomType = chatRowData.ContentChatRoomType;
			if (contentChatRoomType == EChatRoomType.Team || contentChatRoomType == EChatRoomType.World)
			{
				chatRowData.IsVisible = bVisible;
			}
		}
	}

	// Token: 0x0600B18C RID: 45452 RVA: 0x002F5880 File Offset: 0x002F3A80
	private void PushChatRowData(int senderPlayerId, string chatContentText, ChatContentType chatContentType, bool isOfflineMassage, EChatRoomType contentChatRoomType, double timeStamp, int? targetPlayerId = null, [Nullable(2)] string senderPlayerName = null, int? senderPlayerIcon = null)
	{
		OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(senderPlayerId);
		int? senderPlayerNumber = (currentTeamListById != null) ? new int?(currentTeamListById.PlayerNumber) : null;
		int chatRowDataUniqueId = this.ChatRowDataUniqueId;
		this.ChatRowDataUniqueId = chatRowDataUniqueId + 1;
		ChatRowData chatRowData = new ChatRowData(chatRowDataUniqueId, senderPlayerId, chatContentText, chatContentType, isOfflineMassage, contentChatRoomType, timeStamp, targetPlayerId, senderPlayerName, senderPlayerIcon, senderPlayerNumber);
		this.ChatRowDataList.Add(chatRowData);
		Singleton<EventSystem>.Instance.Emit<ChatRowData>(EEventName.OnPushChatRowData, chatRowData);
	}

	// Token: 0x0600B18D RID: 45453 RVA: 0x002F58FB File Offset: 0x002F3AFB
	public void ClearChatRowData()
	{
		this.ChatRowDataList.Clear();
	}

	// Token: 0x0600B18E RID: 45454 RVA: 0x002F5908 File Offset: 0x002F3B08
	public unsafe void RemoveChatRowDataByChatRoomType(params EChatRoomType[] chatRoomType)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "[ChatDebug]删除主界面聊天数据---开始";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("chatRoomType", chatRoomType);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("chatRowDataListLength", this.ChatRowDataList.Count);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		List<int> list = new List<int>();
		for (int i = 0; i < this.ChatRowDataList.Count; i++)
		{
			ChatRowData chatRowData = this.ChatRowDataList[i];
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Chat;
			ELogAuthor author2 = ELogAuthor.LJQ;
			string message2 = "[ChatDebug]删除主界面聊天数据---打印当前聊天记录";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Content", chatRowData.Content);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("TimeStamp", chatRowData.TimeStamp);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			if (chatRoomType.Contains(chatRowData.ContentChatRoomType))
			{
				list.Add(i);
			}
		}
		for (int j = list.Count - 1; j >= 0; j--)
		{
			this.ChatRowDataList.RemoveAt(list[j]);
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.Chat;
		ELogAuthor author3 = ELogAuthor.LJQ;
		string message3 = "[ChatDebug]删除主界面聊天数据---结束";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("removeIndexList", list);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("chatRowDataListLength", this.ChatRowDataList.Count);
		instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
	}

	// Token: 0x0600B18F RID: 45455 RVA: 0x002F5ABC File Offset: 0x002F3CBC
	private void ShiftChatRowData()
	{
		ChatRowData p = this.ChatRowDataList[0];
		this.ChatRowDataList.RemoveAt(0);
		Singleton<EventSystem>.Instance.Emit<ChatRowData>(EEventName.OnPopChatRowData, p);
	}

	// Token: 0x0600B190 RID: 45456 RVA: 0x002F5AF3 File Offset: 0x002F3CF3
	public IReadOnlyList<ChatRowData> GetChatRowDataList()
	{
		return this.ChatRowDataList;
	}

	// Token: 0x0600B191 RID: 45457 RVA: 0x002F5AFC File Offset: 0x002F3CFC
	public bool HasOfflineMassage()
	{
		using (List<ChatRowData>.Enumerator enumerator = this.ChatRowDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsOfflineMassage)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600B192 RID: 45458 RVA: 0x002F5B58 File Offset: 0x002F3D58
	public void AddPrivateHistoryChatContent(PrivateChatRoom chatRoom, List<ChatContentProto> chatContents)
	{
		List<IChatHistory> list = new List<IChatHistory>();
		foreach (ChatContentProto chatContentProto in chatContents)
		{
			int senderUID = chatContentProto.SenderUID;
			ChatHistory item = new ChatHistory
			{
				UtcTime = new long?(chatContentProto.UTCTime),
				MsgId = chatContentProto.MsgId,
				SenderUid = new int?(senderUID),
				Content = chatContentProto.Content,
				ChatContentType = chatContentProto.ChatContentType,
				OfflineMsg = new bool?(chatContentProto.OfflineMsg)
			};
			list.Add(item);
			FriendModel instance = ModelBase<FriendModel>.Instance;
			FriendData friendData = (instance != null) ? instance.GetFriendById(senderUID) : null;
			if (friendData != null)
			{
				this.RefreshChatPlayerData(senderUID, new int?(friendData.PlayerHeadPhoto), friendData.PlayerName, new int?(friendData.PlayerTitleId), new int?(friendData.PlayerTitleStarLevel));
			}
		}
		chatRoom.AddHistoryChatContent(list);
		chatRoom.Open();
		Singleton<EventSystem>.Instance.Emit<ChatRoom>(EEventName.OnAddHistoryChatContentCompleted, chatRoom);
	}

	// Token: 0x0600B193 RID: 45459 RVA: 0x002F5C7C File Offset: 0x002F3E7C
	public void AddTeamHistoryChatContent(TeamChatRoomBase chatRoom, List<ChannelChatMessageInfo> chatContents)
	{
		List<IChatHistory> list = new List<IChatHistory>();
		foreach (ChannelChatMessageInfo channelChatMessageInfo in chatContents)
		{
			ChatHistory item = new ChatHistory
			{
				SenderPlayerId = new int?(channelChatMessageInfo.SenderId),
				SenderPlayerName = channelChatMessageInfo.SenderName,
				UtcTime = new long?(channelChatMessageInfo.SendTime),
				SenderIcon = new int?(channelChatMessageInfo.SenderIcon),
				Content = channelChatMessageInfo.Content,
				ChatContentType = channelChatMessageInfo.ChatContentType,
				NoticeType = new ChatChannelNoticeType?(channelChatMessageInfo.NoticeType)
			};
			list.Add(item);
		}
		chatRoom.AddHistoryChatContent(list);
		chatRoom.Open();
		Singleton<EventSystem>.Instance.Emit<ChatRoom>(EEventName.OnAddHistoryChatContentCompleted, chatRoom);
	}

	// Token: 0x0600B194 RID: 45460 RVA: 0x002F5D60 File Offset: 0x002F3F60
	public void JoinChatRoom(ChatRoom chatRoom)
	{
		this.SetChatRoomRedDot(chatRoom, false);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = " 加入聊天室";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("UniqueId", chatRoom.GetUniqueId());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (chatRoom.GetIsOpen())
		{
			this.CurrentChatRoom = chatRoom;
			Singleton<EventSystem>.Instance.Emit<ChatRoom>(EEventName.OnJoinChatRoom, chatRoom);
		}
		else
		{
			PrivateChatRoom privateChatRoom = chatRoom as PrivateChatRoom;
			if (privateChatRoom != null)
			{
				if (!privateChatRoom.CanChat())
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Chat;
					ELogAuthor author2 = ELogAuthor.LJQ;
					string message2 = " 加入私人聊天室时，对应好友在黑名单或不在好友列表中，无法加入聊天室";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("UniqueId", chatRoom.GetUniqueId());
					instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return;
				}
				this.CurrentChatRoom = chatRoom;
				this.RequestOpenPrivateChatRoom(privateChatRoom);
			}
			else
			{
				this.CurrentChatRoom = chatRoom;
				this.RequestOpenChatRoom(chatRoom);
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshChatRedDot);
	}

	// Token: 0x0600B195 RID: 45461 RVA: 0x002F5E3E File Offset: 0x002F403E
	public void LeaveCurrentChatRoom()
	{
		this.CurrentChatRoom = null;
	}

	// Token: 0x0600B196 RID: 45462 RVA: 0x002F5E48 File Offset: 0x002F4048
	public void RemovePrivateChatRoom(int targetPlayerId)
	{
		PrivateChatRoom privateChatRoom = this.CurrentChatRoom as PrivateChatRoom;
		if (privateChatRoom != null && privateChatRoom.GetTargetPlayerId() == targetPlayerId)
		{
			this.LeaveCurrentChatRoom();
		}
		PrivateChatRoom privateChatRoom2 = this.GetPrivateChatRoom(targetPlayerId);
		if (privateChatRoom2 == null)
		{
			return;
		}
		privateChatRoom2.Reset();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = " 删除私人聊天室";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlayerId", targetPlayerId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.PrivateChatRoomMap.Remove(targetPlayerId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRemovePrivateChatRoom, targetPlayerId);
	}

	// Token: 0x0600B197 RID: 45463 RVA: 0x002F5ED4 File Offset: 0x002F40D4
	public void ClosePrivateChatRoom(int targetPlayerId)
	{
		PrivateChatRoom privateChatRoom = this.CurrentChatRoom as PrivateChatRoom;
		if (privateChatRoom != null && privateChatRoom.GetTargetPlayerId() == targetPlayerId)
		{
			this.CurrentChatRoom = null;
		}
		PrivateChatRoom privateChatRoom2 = this.GetPrivateChatRoom(targetPlayerId);
		if (privateChatRoom2 == null)
		{
			return;
		}
		privateChatRoom2.Close();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = " 关闭私人聊天室";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlayerId", targetPlayerId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnClosePrivateChatRoom, targetPlayerId);
	}

	// Token: 0x0600B198 RID: 45464 RVA: 0x002F5F54 File Offset: 0x002F4154
	public void RequestOpenPrivateChatRoom(PrivateChatRoom privateChatRoom)
	{
		if (privateChatRoom.GetIsOpen())
		{
			return;
		}
		int targetPlayerId = privateChatRoom.GetTargetPlayerId();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = " 请求打开私人聊天室";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlayerId", targetPlayerId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		privateChatRoom.Open();
		ControllerBase<ChatController>.Instance.PrivateChatHistoryRequest(targetPlayerId);
		this.SetChatRoomRedDot(privateChatRoom, true);
		Singleton<EventSystem>.Instance.Emit<ChatRoom>(EEventName.OnOpenChatRoom, privateChatRoom);
	}

	// Token: 0x0600B199 RID: 45465 RVA: 0x002F5FCC File Offset: 0x002F41CC
	public void RequestOpenChatRoom(ChatRoom chatRoom)
	{
		if (chatRoom.GetIsOpen())
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.Chat, ELogAuthor.LJQ, " 请求打开队伍/联机聊天室 ", default(ReadOnlySpan<ValueTuple<string, object>>));
		chatRoom.Open();
		this.SetChatRoomRedDot(chatRoom, true);
		Singleton<EventSystem>.Instance.Emit<ChatRoom>(EEventName.OnOpenChatRoom, chatRoom);
	}

	// Token: 0x0600B19A RID: 45466 RVA: 0x002F6020 File Offset: 0x002F4220
	public void SetChatRoomRedDot(ChatRoom chatRoom, bool bVisible)
	{
		if (chatRoom == null)
		{
			return;
		}
		if (chatRoom.GetIsShowRedDot() == bVisible)
		{
			return;
		}
		ChatRoom joinedChatRoom = this.GetJoinedChatRoom();
		int? num = (joinedChatRoom != null) ? new int?(joinedChatRoom.GetUniqueId()) : null;
		int uniqueId = chatRoom.GetUniqueId();
		if (num.GetValueOrDefault() == uniqueId & num != null)
		{
			return;
		}
		chatRoom.SetIsShowRedDot(bVisible);
		PrivateChatRoom privateChatRoom = chatRoom as PrivateChatRoom;
		if (privateChatRoom != null)
		{
			int targetPlayerId = privateChatRoom.GetTargetPlayerId();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRefreshChatRoomRedDot, targetPlayerId);
			return;
		}
		if (chatRoom is TeamChatRoom)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRefreshChatRoomRedDot, 2);
			return;
		}
		if (chatRoom is WorldChatRoom)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRefreshChatRoomRedDot, 3);
		}
	}

	// Token: 0x0600B19B RID: 45467 RVA: 0x002F60D6 File Offset: 0x002F42D6
	[NullableContext(2)]
	public ChatRoom GetJoinedChatRoom()
	{
		return this.CurrentChatRoom;
	}

	// Token: 0x0600B19C RID: 45468 RVA: 0x002F60E0 File Offset: 0x002F42E0
	public bool HasRedDot()
	{
		using (Dictionary<int, PrivateChatRoom>.ValueCollection.Enumerator enumerator = this.PrivateChatRoomMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetIsShowRedDot())
				{
					return true;
				}
			}
		}
		TeamChatRoom teamChatRoom = this.TeamChatRoom;
		if (teamChatRoom != null && teamChatRoom.GetIsShowRedDot())
		{
			return true;
		}
		WorldChatRoom worldChatRoom = this.WorldChatRoom;
		return worldChatRoom != null && worldChatRoom.GetIsShowRedDot();
	}

	// Token: 0x0600B19D RID: 45469 RVA: 0x002F616C File Offset: 0x002F436C
	public PrivateChatRoom TryGetPrivateChatRoom(int targetPlayerId)
	{
		PrivateChatRoom privateChatRoom = this.GetPrivateChatRoom(targetPlayerId);
		if (privateChatRoom == null)
		{
			privateChatRoom = this.NewPrivateChatRoom(targetPlayerId);
		}
		return privateChatRoom;
	}

	// Token: 0x0600B19E RID: 45470 RVA: 0x002F6190 File Offset: 0x002F4390
	public PrivateChatRoom NewPrivateChatRoom(int targetPlayerId)
	{
		PrivateChatRoom privateChatRoom = new PrivateChatRoom(targetPlayerId, 1);
		this.PrivateChatRoomMap[targetPlayerId] = privateChatRoom;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnCreatePrivateChatRoom, targetPlayerId);
		return privateChatRoom;
	}

	// Token: 0x0600B19F RID: 45471 RVA: 0x002F61C4 File Offset: 0x002F43C4
	public TeamChatRoom NewTeamChatRoom()
	{
		this.TeamChatRoom = new TeamChatRoom(2);
		return this.TeamChatRoom;
	}

	// Token: 0x0600B1A0 RID: 45472 RVA: 0x002F61D8 File Offset: 0x002F43D8
	public WorldChatRoom NewWorldChatRoom()
	{
		this.WorldChatRoom = new WorldChatRoom(2);
		return this.WorldChatRoom;
	}

	// Token: 0x0600B1A1 RID: 45473 RVA: 0x002F61EC File Offset: 0x002F43EC
	public void SelectedPrivateChatFriend(int targetPlayerId)
	{
		PrivateChatRoom privateChatRoom = this.TryGetPrivateChatRoom(targetPlayerId);
		if (!privateChatRoom.CanChat())
		{
			return;
		}
		this.JoinChatRoom(privateChatRoom);
	}

	// Token: 0x0600B1A2 RID: 45474 RVA: 0x002F6214 File Offset: 0x002F4414
	[NullableContext(2)]
	public PrivateChatRoom GetPrivateChatRoom(int targetPlayerId)
	{
		PrivateChatRoom result;
		this.PrivateChatRoomMap.TryGetValue(targetPlayerId, out result);
		return result;
	}

	// Token: 0x0600B1A3 RID: 45475 RVA: 0x002F6231 File Offset: 0x002F4431
	[NullableContext(2)]
	public TeamChatRoom GetTeamChatRoom()
	{
		return this.TeamChatRoom;
	}

	// Token: 0x0600B1A4 RID: 45476 RVA: 0x002F6239 File Offset: 0x002F4439
	[NullableContext(2)]
	public void SetTeamChatRoom(TeamChatRoom teamChatRoom)
	{
		this.TeamChatRoom = teamChatRoom;
	}

	// Token: 0x0600B1A5 RID: 45477 RVA: 0x002F6242 File Offset: 0x002F4442
	[NullableContext(2)]
	public WorldChatRoom GetWorldChatRoom()
	{
		return this.WorldChatRoom;
	}

	// Token: 0x0600B1A6 RID: 45478 RVA: 0x002F624A File Offset: 0x002F444A
	[NullableContext(2)]
	public void SetWorldChatRoom(WorldChatRoom worldChatRoom)
	{
		this.WorldChatRoom = worldChatRoom;
	}

	// Token: 0x0600B1A7 RID: 45479 RVA: 0x002F6254 File Offset: 0x002F4454
	public List<ChatRoom> GetAllSortedChatRoom()
	{
		List<ChatRoom> list = new List<ChatRoom>();
		foreach (PrivateChatRoom privateChatRoom in this.PrivateChatRoomMap.Values)
		{
			if (privateChatRoom.GetIsOpen() && privateChatRoom.CanChat())
			{
				list.Add(privateChatRoom);
			}
		}
		list.Sort(delegate(ChatRoom a, ChatRoom b)
		{
			double lastTimeStamp = a.GetLastTimeStamp();
			double lastTimeStamp2 = b.GetLastTimeStamp();
			if (lastTimeStamp == 0.0)
			{
				return -1;
			}
			if (lastTimeStamp2 == 0.0)
			{
				return 1;
			}
			if (lastTimeStamp != lastTimeStamp2)
			{
				return (int)(lastTimeStamp2 - lastTimeStamp);
			}
			return b.GetCreateTimeStamp() - a.GetCreateTimeStamp();
		});
		TeamChatRoom teamChatRoom = this.GetTeamChatRoom();
		if (teamChatRoom != null)
		{
			list.Insert(0, teamChatRoom);
			return list;
		}
		WorldChatRoom worldChatRoom = this.GetWorldChatRoom();
		if (worldChatRoom != null)
		{
			list.Insert(0, worldChatRoom);
		}
		return list;
	}

	// Token: 0x0600B1A8 RID: 45480 RVA: 0x002F6314 File Offset: 0x002F4514
	public bool IsInPrivateChatRoom(int playerId)
	{
		PrivateChatRoom privateChatRoom = this.GetPrivateChatRoom(playerId);
		return privateChatRoom != null && privateChatRoom.GetIsOpen();
	}

	// Token: 0x0600B1A9 RID: 45481 RVA: 0x002F6334 File Offset: 0x002F4534
	public void AddMutePlayer(int playerId)
	{
		this.MutePlayerIdList.Add(playerId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnAddMutePlayer, playerId);
	}

	// Token: 0x0600B1AA RID: 45482 RVA: 0x002F6354 File Offset: 0x002F4554
	public void RemoveMutePlayer(int playerId)
	{
		int num = this.MutePlayerIdList.IndexOf(playerId);
		if (num < 0)
		{
			return;
		}
		this.MutePlayerIdList.RemoveAt(num);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRemoveMutePlayer, playerId);
	}

	// Token: 0x0600B1AB RID: 45483 RVA: 0x002F6390 File Offset: 0x002F4590
	public void ClearAllMutePlayer()
	{
		this.MutePlayerIdList.Clear();
	}

	// Token: 0x0600B1AC RID: 45484 RVA: 0x002F639D File Offset: 0x002F459D
	public bool IsInMute(int playerId)
	{
		return this.MutePlayerIdList.IndexOf(playerId) >= 0;
	}

	// Token: 0x04005423 RID: 21539
	private readonly Dictionary<int, ChatPlayerData> ChatPlayerDataMap = new Dictionary<int, ChatPlayerData>();

	// Token: 0x04005424 RID: 21540
	private List<ChatRowData> ChatRowDataList = new List<ChatRowData>();

	// Token: 0x04005425 RID: 21541
	private int ChatRowDataUniqueId;

	// Token: 0x04005426 RID: 21542
	private readonly Dictionary<int, PrivateChatRoom> PrivateChatRoomMap = new Dictionary<int, PrivateChatRoom>();

	// Token: 0x04005427 RID: 21543
	[Nullable(2)]
	private TeamChatRoom TeamChatRoom;

	// Token: 0x04005428 RID: 21544
	[Nullable(2)]
	private WorldChatRoom WorldChatRoom;

	// Token: 0x04005429 RID: 21545
	[Nullable(2)]
	private ChatRoom CurrentChatRoom;

	// Token: 0x0400542A RID: 21546
	private readonly List<int> MutePlayerIdList = new List<int>();

	// Token: 0x0400542B RID: 21547
	public bool IsOpenedChatView;

	// Token: 0x0400542C RID: 21548
	public Number ShowTimeDifferent = 0;
}
