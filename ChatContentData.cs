using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001837 RID: 6199
[NullableContext(2)]
[Nullable(0)]
public class ChatContentData
{
	// Token: 0x0600B0FB RID: 45307 RVA: 0x002F3CF4 File Offset: 0x002F1EF4
	public ChatContentData([Nullable(1)] string contentUniqueId, int senderPlayerId, [Nullable(1)] string content, ChatContentType contentType, ChatChannelNoticeType noticeType, bool isOfflineMassage, double timeStamp, double lastTimeStamp, EChatRoomType chatRoomType, string senderPlayerName = null, int? senderPlayerIcon = null, string thirdOnlineId = null, string thirdAvoidId = null)
	{
		this.ContentUniqueId = contentUniqueId;
		this.SenderPlayerId = senderPlayerId;
		this.Content = content;
		this.ContentType = contentType;
		this.NoticeType = noticeType;
		this.IsOfflineMassage = isOfflineMassage;
		this.TimeStamp = timeStamp;
		this.LastTimeStamp = lastTimeStamp;
		this.ChatRoomType = chatRoomType;
		this.SenderPlayerName = senderPlayerName;
		this.SenderPlayerIcon = senderPlayerIcon;
		this.ThirdOnlineId = thirdOnlineId;
		this.ThirdAvoidId = thirdAvoidId;
	}

	// Token: 0x0600B0FC RID: 45308 RVA: 0x002F3D6C File Offset: 0x002F1F6C
	public bool IsOwnSend()
	{
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int senderPlayerId = this.SenderPlayerId;
		return id.GetValueOrDefault() == senderPlayerId & id != null;
	}

	// Token: 0x040053E8 RID: 21480
	[Nullable(1)]
	public readonly string ContentUniqueId;

	// Token: 0x040053E9 RID: 21481
	public readonly int SenderPlayerId;

	// Token: 0x040053EA RID: 21482
	public int? SenderPlayerIcon;

	// Token: 0x040053EB RID: 21483
	public string SenderPlayerName;

	// Token: 0x040053EC RID: 21484
	[Nullable(1)]
	public readonly string Content;

	// Token: 0x040053ED RID: 21485
	public readonly ChatContentType ContentType;

	// Token: 0x040053EE RID: 21486
	public readonly ChatChannelNoticeType NoticeType;

	// Token: 0x040053EF RID: 21487
	public readonly bool IsOfflineMassage;

	// Token: 0x040053F0 RID: 21488
	public double TimeStamp;

	// Token: 0x040053F1 RID: 21489
	public double LastTimeStamp;

	// Token: 0x040053F2 RID: 21490
	public readonly EChatRoomType ChatRoomType;

	// Token: 0x040053F3 RID: 21491
	public readonly string ThirdOnlineId;

	// Token: 0x040053F4 RID: 21492
	public readonly string ThirdAvoidId;
}
