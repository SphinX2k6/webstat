using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200183F RID: 6207
[NullableContext(1)]
[Nullable(0)]
public class ChatRowSaveInfo : IChatRowSaveInfo
{
	// Token: 0x17000E69 RID: 3689
	// (get) Token: 0x0600B13E RID: 45374 RVA: 0x002F51D4 File Offset: 0x002F33D4
	// (set) Token: 0x0600B13F RID: 45375 RVA: 0x002F51DC File Offset: 0x002F33DC
	public ChatContentType ChatContentType { get; set; }

	// Token: 0x17000E6A RID: 3690
	// (get) Token: 0x0600B140 RID: 45376 RVA: 0x002F51E5 File Offset: 0x002F33E5
	// (set) Token: 0x0600B141 RID: 45377 RVA: 0x002F51ED File Offset: 0x002F33ED
	public string Content { get; set; }

	// Token: 0x17000E6B RID: 3691
	// (get) Token: 0x0600B142 RID: 45378 RVA: 0x002F51F6 File Offset: 0x002F33F6
	// (set) Token: 0x0600B143 RID: 45379 RVA: 0x002F51FE File Offset: 0x002F33FE
	public string MsgId { get; set; }

	// Token: 0x17000E6C RID: 3692
	// (get) Token: 0x0600B144 RID: 45380 RVA: 0x002F5207 File Offset: 0x002F3407
	// (set) Token: 0x0600B145 RID: 45381 RVA: 0x002F520F File Offset: 0x002F340F
	public bool OfflineMsg { get; set; }

	// Token: 0x17000E6D RID: 3693
	// (get) Token: 0x0600B146 RID: 45382 RVA: 0x002F5218 File Offset: 0x002F3418
	// (set) Token: 0x0600B147 RID: 45383 RVA: 0x002F5220 File Offset: 0x002F3420
	public int SenderUid { get; set; }

	// Token: 0x17000E6E RID: 3694
	// (get) Token: 0x0600B148 RID: 45384 RVA: 0x002F5229 File Offset: 0x002F3429
	// (set) Token: 0x0600B149 RID: 45385 RVA: 0x002F5231 File Offset: 0x002F3431
	public long UtcTime { get; set; }
}
