using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02001846 RID: 6214
[NullableContext(1)]
[Nullable(0)]
public class ChatRoom
{
	// Token: 0x0600B1BC RID: 45500 RVA: 0x002F64E0 File Offset: 0x002F46E0
	public ChatRoom(EChatRoomType chatRoomType, int configId)
	{
		this.ChatRoomType = chatRoomType;
		this.ConfigId = configId;
		this.IsOpen = false;
		Chat? chatConfig = ConfigBase<ChatConfig>.Instance.GetChatConfig(this.ConfigId);
		if (chatConfig != null)
		{
			this.LocalSaveMsgLimit = chatConfig.Value.LocalSaveMsgLimit;
			this.ChatCd = chatConfig.Value.ChatCd;
		}
	}

	// Token: 0x0600B1BD RID: 45501 RVA: 0x002F656E File Offset: 0x002F476E
	public void Reset()
	{
		this.ChatContentList.Clear();
		this.CreateTimeStamp = -1;
		this.IsOpen = false;
	}

	// Token: 0x0600B1BE RID: 45502 RVA: 0x002F6590 File Offset: 0x002F4790
	public void Open()
	{
		if (this.IsOpen)
		{
			return;
		}
		this.CreateTimeStamp = Singleton<TimeUtil>.Instance.GetServerTime();
		this.IsOpen = true;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = " 打开聊天室";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("uniqueId", this.GetUniqueId());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600B1BF RID: 45503 RVA: 0x002F65F8 File Offset: 0x002F47F8
	public void Close()
	{
		if (!this.IsOpen)
		{
			return;
		}
		this.ChatContentList.Clear();
		this.CreateTimeStamp = -1;
		this.IsOpen = false;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = " 关闭聊天室";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("uniqueId", this.GetUniqueId());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600B1C0 RID: 45504 RVA: 0x002F665F File Offset: 0x002F485F
	public bool GetIsOpen()
	{
		return this.IsOpen;
	}

	// Token: 0x0600B1C1 RID: 45505 RVA: 0x002F6667 File Offset: 0x002F4867
	public void SetIsShowRedDot(bool bShow)
	{
		this.IsShowRedDot = bShow;
	}

	// Token: 0x0600B1C2 RID: 45506 RVA: 0x002F6670 File Offset: 0x002F4870
	public bool GetIsShowRedDot()
	{
		return this.IsShowRedDot;
	}

	// Token: 0x0600B1C3 RID: 45507 RVA: 0x002F6678 File Offset: 0x002F4878
	public int GetConfigId()
	{
		return this.ConfigId;
	}

	// Token: 0x0600B1C4 RID: 45508 RVA: 0x002F6680 File Offset: 0x002F4880
	public virtual int GetUniqueId()
	{
		return -1;
	}

	// Token: 0x0600B1C5 RID: 45509 RVA: 0x002F6683 File Offset: 0x002F4883
	public Chat? GetChatConfig()
	{
		return ConfigBase<ChatConfig>.Instance.GetChatConfig(this.ConfigId);
	}

	// Token: 0x0600B1C6 RID: 45510 RVA: 0x002F6695 File Offset: 0x002F4895
	public IReadOnlyList<ChatContentData> GetChatContentList()
	{
		return this.ChatContentList;
	}

	// Token: 0x0600B1C7 RID: 45511 RVA: 0x002F669D File Offset: 0x002F489D
	public string GetEarliestHistoryContentUniqueId()
	{
		return this.EarliestHistoryContentUniqueId;
	}

	// Token: 0x0600B1C8 RID: 45512 RVA: 0x002F66A5 File Offset: 0x002F48A5
	public Number GetCreateTimeStamp()
	{
		return this.CreateTimeStamp;
	}

	// Token: 0x0600B1C9 RID: 45513 RVA: 0x002F66AD File Offset: 0x002F48AD
	public void ClearCreateTime()
	{
		this.CreateTimeStamp = -1;
	}

	// Token: 0x0600B1CA RID: 45514 RVA: 0x002F66BC File Offset: 0x002F48BC
	public double GetLastTimeStamp()
	{
		int num = this.ChatContentList.Count - 1;
		if (num < 0)
		{
			return 0.0;
		}
		return this.ChatContentList[num].TimeStamp;
	}

	// Token: 0x0600B1CB RID: 45515 RVA: 0x002F66F8 File Offset: 0x002F48F8
	public ChatContentData AddChatContent(string contentUniqueId, int senderPlayerId, string content, ChatContentType contentType, ChatChannelNoticeType noticeType, bool isOfflineMassage, double timeStamp, double lastTimeStamp, [Nullable(2)] string senderPlayerName = null, int? senderPlayerIcon = null, [Nullable(2)] string thirdOnlineId = null, [Nullable(2)] string thirdAvoidId = null)
	{
		ChatContentData chatContentData = new ChatContentData(contentUniqueId, senderPlayerId, content, contentType, noticeType, isOfflineMassage, timeStamp, lastTimeStamp, this.ChatRoomType, senderPlayerName, senderPlayerIcon, thirdOnlineId, thirdAvoidId);
		this.ChatContentList.Add(chatContentData);
		return chatContentData;
	}

	// Token: 0x0600B1CC RID: 45516 RVA: 0x002F6734 File Offset: 0x002F4934
	[NullableContext(2)]
	public ChatContentData GetLastChatContentData(int lastIndex = 1)
	{
		int num = this.ChatContentList.Count - lastIndex;
		if (num < 0)
		{
			return null;
		}
		return this.ChatContentList[num];
	}

	// Token: 0x0600B1CD RID: 45517 RVA: 0x002F6764 File Offset: 0x002F4964
	public virtual void AddHistoryChatContent(List<IChatHistory> chatContents)
	{
		chatContents.Sort(delegate(IChatHistory a, IChatHistory b)
		{
			long? utcTime2 = a.UtcTime;
			long? utcTime3 = b.UtcTime;
			if (utcTime2 == null || utcTime3 == null)
			{
				return a.SenderUid.Value - b.SenderUid.Value;
			}
			return (int)(utcTime2.Value - utcTime3.Value);
		});
		this.EarliestHistoryContentUniqueId = chatContents[0].MsgId;
		List<ChatContentData> list = new List<ChatContentData>();
		ChatContentData chatContentData = null;
		foreach (IChatHistory chatHistory in chatContents)
		{
			int? senderUid = chatHistory.SenderUid;
			string content = chatHistory.Content;
			ChatContentType chatContentType = chatHistory.ChatContentType;
			bool? offlineMsg = chatHistory.OfflineMsg;
			string msgId = chatHistory.MsgId;
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
			ChatContentData chatContentData2 = new ChatContentData(msgId, senderUid.Value, content, chatContentType, ChatChannelNoticeType.None, offlineMsg.Value, timeStamp, lastTimeStamp, this.ChatRoomType, null, null, null, null);
			chatContentData = chatContentData2;
			list.Add(chatContentData2);
		}
		this.ChatContentList = list.Concat(this.ChatContentList).ToList<ChatContentData>();
	}

	// Token: 0x04005433 RID: 21555
	public readonly EChatRoomType ChatRoomType;

	// Token: 0x04005434 RID: 21556
	protected List<ChatContentData> ChatContentList = new List<ChatContentData>();

	// Token: 0x04005435 RID: 21557
	private Number CreateTimeStamp = -1;

	// Token: 0x04005436 RID: 21558
	private bool IsShowRedDot;

	// Token: 0x04005437 RID: 21559
	private readonly int ConfigId;

	// Token: 0x04005438 RID: 21560
	protected string EarliestHistoryContentUniqueId = "";

	// Token: 0x04005439 RID: 21561
	private bool IsOpen;

	// Token: 0x0400543A RID: 21562
	public int LocalSaveMsgLimit;

	// Token: 0x0400543B RID: 21563
	public int ChatCd;
}
