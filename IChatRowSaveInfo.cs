using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200183E RID: 6206
[NullableContext(1)]
public interface IChatRowSaveInfo
{
	// Token: 0x17000E63 RID: 3683
	// (get) Token: 0x0600B132 RID: 45362
	// (set) Token: 0x0600B133 RID: 45363
	ChatContentType ChatContentType { get; set; }

	// Token: 0x17000E64 RID: 3684
	// (get) Token: 0x0600B134 RID: 45364
	// (set) Token: 0x0600B135 RID: 45365
	string Content { get; set; }

	// Token: 0x17000E65 RID: 3685
	// (get) Token: 0x0600B136 RID: 45366
	// (set) Token: 0x0600B137 RID: 45367
	string MsgId { get; set; }

	// Token: 0x17000E66 RID: 3686
	// (get) Token: 0x0600B138 RID: 45368
	// (set) Token: 0x0600B139 RID: 45369
	bool OfflineMsg { get; set; }

	// Token: 0x17000E67 RID: 3687
	// (get) Token: 0x0600B13A RID: 45370
	// (set) Token: 0x0600B13B RID: 45371
	int SenderUid { get; set; }

	// Token: 0x17000E68 RID: 3688
	// (get) Token: 0x0600B13C RID: 45372
	// (set) Token: 0x0600B13D RID: 45373
	long UtcTime { get; set; }
}
