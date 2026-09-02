using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200184A RID: 6218
public class TeamChatRoomBase : ChatRoom
{
	// Token: 0x0600B1DB RID: 45531 RVA: 0x002F6A2D File Offset: 0x002F4C2D
	public TeamChatRoomBase(EChatRoomType chatRoomType, int configId) : base(chatRoomType, configId)
	{
	}

	// Token: 0x0600B1DC RID: 45532 RVA: 0x002F6A38 File Offset: 0x002F4C38
	[NullableContext(1)]
	public override void AddHistoryChatContent(List<IChatHistory> chatContents)
	{
		this.EarliestHistoryContentUniqueId = "";
		List<ChatContentData> list = new List<ChatContentData>();
		ChatContentData chatContentData = null;
		foreach (IChatHistory chatHistory in chatContents)
		{
			int? senderPlayerId = chatHistory.SenderPlayerId;
			string content = chatHistory.Content;
			ChatContentType chatContentType = chatHistory.ChatContentType;
			ChatChannelNoticeType? noticeType = chatHistory.NoticeType;
			bool isOfflineMassage = true;
			string contentUniqueId = "";
			long? utcTime = chatHistory.UtcTime;
			double timeStamp;
			if (utcTime != null)
			{
				timeStamp = (double)utcTime.Value;
			}
			else
			{
				timeStamp = Singleton<TimeUtil>.Instance.GetServerTime();
			}
			double lastTimeStamp = 0.0;
			if (chatContentData != null)
			{
				lastTimeStamp = chatContentData.TimeStamp;
			}
			int? num = null;
			string senderPlayerName = chatHistory.SenderPlayerName;
			num = chatHistory.SenderIcon;
			ChatContentData chatContentData2 = new ChatContentData(contentUniqueId, senderPlayerId.Value, content, chatContentType, noticeType.Value, isOfflineMassage, timeStamp, lastTimeStamp, this.ChatRoomType, senderPlayerName, new int?(num.Value), null, null);
			chatContentData = chatContentData2;
			list.Add(chatContentData2);
		}
		this.ChatContentList = list.Concat(this.ChatContentList).ToList<ChatContentData>();
	}
}
