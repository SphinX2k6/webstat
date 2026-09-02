using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001840 RID: 6208
[NullableContext(2)]
public interface IChatHistory
{
	// Token: 0x17000E6F RID: 3695
	// (get) Token: 0x0600B14B RID: 45387
	// (set) Token: 0x0600B14C RID: 45388
	long? UtcTime { get; set; }

	// Token: 0x17000E70 RID: 3696
	// (get) Token: 0x0600B14D RID: 45389
	// (set) Token: 0x0600B14E RID: 45390
	string MsgId { get; set; }

	// Token: 0x17000E71 RID: 3697
	// (get) Token: 0x0600B14F RID: 45391
	// (set) Token: 0x0600B150 RID: 45392
	int? SenderUid { get; set; }

	// Token: 0x17000E72 RID: 3698
	// (get) Token: 0x0600B151 RID: 45393
	// (set) Token: 0x0600B152 RID: 45394
	int? SenderPlayerId { get; set; }

	// Token: 0x17000E73 RID: 3699
	// (get) Token: 0x0600B153 RID: 45395
	// (set) Token: 0x0600B154 RID: 45396
	string SenderPlayerName { get; set; }

	// Token: 0x17000E74 RID: 3700
	// (get) Token: 0x0600B155 RID: 45397
	// (set) Token: 0x0600B156 RID: 45398
	int? SenderIcon { get; set; }

	// Token: 0x17000E75 RID: 3701
	// (get) Token: 0x0600B157 RID: 45399
	// (set) Token: 0x0600B158 RID: 45400
	[Nullable(1)]
	string Content { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000E76 RID: 3702
	// (get) Token: 0x0600B159 RID: 45401
	// (set) Token: 0x0600B15A RID: 45402
	ChatContentType ChatContentType { get; set; }

	// Token: 0x17000E77 RID: 3703
	// (get) Token: 0x0600B15B RID: 45403
	// (set) Token: 0x0600B15C RID: 45404
	ChatChannelNoticeType? NoticeType { get; set; }

	// Token: 0x17000E78 RID: 3704
	// (get) Token: 0x0600B15D RID: 45405
	// (set) Token: 0x0600B15E RID: 45406
	bool? OfflineMsg { get; set; }
}
