using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200183D RID: 6205
[NullableContext(1)]
[Nullable(0)]
public class ChatRoomSaveInfo : IChatRoomSaveInfo
{
	// Token: 0x17000E62 RID: 3682
	// (get) Token: 0x0600B12F RID: 45359 RVA: 0x002F51BB File Offset: 0x002F33BB
	// (set) Token: 0x0600B130 RID: 45360 RVA: 0x002F51C3 File Offset: 0x002F33C3
	public List<IChatRowSaveInfo> ChatRows { get; set; }
}
