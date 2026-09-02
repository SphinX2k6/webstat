using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001847 RID: 6215
[NullableContext(1)]
[Nullable(0)]
public class ChatRowData
{
	// Token: 0x0600B1CE RID: 45518 RVA: 0x002F68B4 File Offset: 0x002F4AB4
	public ChatRowData(Number uniqueId, int senderPlayerId, string content, ChatContentType contentType, bool isOfflineMassage, EChatRoomType contentChatRoomType, double timeStamp, int? targetPlayerId = null, [Nullable(2)] string senderPlayerName = null, int? senderPlayerIcon = null, int? senderPlayerNumber = null)
	{
		this.UniqueId = uniqueId;
		this.SenderPlayerId = senderPlayerId;
		this.Content = content;
		this.ContentType = contentType;
		this.IsOfflineMassage = isOfflineMassage;
		this.TargetPlayerId = targetPlayerId;
		this.ContentChatRoomType = contentChatRoomType;
		this.TimeStamp = timeStamp;
		this.SenderPlayerName = senderPlayerName;
		this.SenderPlayerIcon = senderPlayerIcon;
		this.SenderPlayerNumber = senderPlayerNumber;
	}

	// Token: 0x0400543C RID: 21564
	public readonly Number UniqueId = 0;

	// Token: 0x0400543D RID: 21565
	public readonly int SenderPlayerId;

	// Token: 0x0400543E RID: 21566
	public int? SenderPlayerIcon;

	// Token: 0x0400543F RID: 21567
	[Nullable(2)]
	public string SenderPlayerName;

	// Token: 0x04005440 RID: 21568
	public readonly int? SenderPlayerNumber;

	// Token: 0x04005441 RID: 21569
	public readonly int? TargetPlayerId;

	// Token: 0x04005442 RID: 21570
	public readonly string Content = "";

	// Token: 0x04005443 RID: 21571
	public readonly ChatContentType ContentType;

	// Token: 0x04005444 RID: 21572
	public readonly EChatRoomType ContentChatRoomType;

	// Token: 0x04005445 RID: 21573
	public readonly bool IsOfflineMassage;

	// Token: 0x04005446 RID: 21574
	public readonly double TimeStamp;

	// Token: 0x04005447 RID: 21575
	public bool IsVisible = true;
}
