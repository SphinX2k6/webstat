using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001841 RID: 6209
[NullableContext(2)]
[Nullable(0)]
public class ChatHistory : IChatHistory
{
	// Token: 0x17000E79 RID: 3705
	// (get) Token: 0x0600B15F RID: 45407 RVA: 0x002F5242 File Offset: 0x002F3442
	// (set) Token: 0x0600B160 RID: 45408 RVA: 0x002F524A File Offset: 0x002F344A
	public long? UtcTime { get; set; }

	// Token: 0x17000E7A RID: 3706
	// (get) Token: 0x0600B161 RID: 45409 RVA: 0x002F5253 File Offset: 0x002F3453
	// (set) Token: 0x0600B162 RID: 45410 RVA: 0x002F525B File Offset: 0x002F345B
	public string MsgId { get; set; }

	// Token: 0x17000E7B RID: 3707
	// (get) Token: 0x0600B163 RID: 45411 RVA: 0x002F5264 File Offset: 0x002F3464
	// (set) Token: 0x0600B164 RID: 45412 RVA: 0x002F526C File Offset: 0x002F346C
	public int? SenderUid { get; set; }

	// Token: 0x17000E7C RID: 3708
	// (get) Token: 0x0600B165 RID: 45413 RVA: 0x002F5275 File Offset: 0x002F3475
	// (set) Token: 0x0600B166 RID: 45414 RVA: 0x002F527D File Offset: 0x002F347D
	public int? SenderPlayerId { get; set; }

	// Token: 0x17000E7D RID: 3709
	// (get) Token: 0x0600B167 RID: 45415 RVA: 0x002F5286 File Offset: 0x002F3486
	// (set) Token: 0x0600B168 RID: 45416 RVA: 0x002F528E File Offset: 0x002F348E
	public string SenderPlayerName { get; set; }

	// Token: 0x17000E7E RID: 3710
	// (get) Token: 0x0600B169 RID: 45417 RVA: 0x002F5297 File Offset: 0x002F3497
	// (set) Token: 0x0600B16A RID: 45418 RVA: 0x002F529F File Offset: 0x002F349F
	public int? SenderIcon { get; set; }

	// Token: 0x17000E7F RID: 3711
	// (get) Token: 0x0600B16B RID: 45419 RVA: 0x002F52A8 File Offset: 0x002F34A8
	// (set) Token: 0x0600B16C RID: 45420 RVA: 0x002F52B0 File Offset: 0x002F34B0
	[Nullable(1)]
	public string Content { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000E80 RID: 3712
	// (get) Token: 0x0600B16D RID: 45421 RVA: 0x002F52B9 File Offset: 0x002F34B9
	// (set) Token: 0x0600B16E RID: 45422 RVA: 0x002F52C1 File Offset: 0x002F34C1
	public ChatContentType ChatContentType { get; set; }

	// Token: 0x17000E81 RID: 3713
	// (get) Token: 0x0600B16F RID: 45423 RVA: 0x002F52CA File Offset: 0x002F34CA
	// (set) Token: 0x0600B170 RID: 45424 RVA: 0x002F52D2 File Offset: 0x002F34D2
	public ChatChannelNoticeType? NoticeType { get; set; }

	// Token: 0x17000E82 RID: 3714
	// (get) Token: 0x0600B171 RID: 45425 RVA: 0x002F52DB File Offset: 0x002F34DB
	// (set) Token: 0x0600B172 RID: 45426 RVA: 0x002F52E3 File Offset: 0x002F34E3
	public bool? OfflineMsg { get; set; }
}
