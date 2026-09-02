using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200183C RID: 6204
[NullableContext(1)]
public interface IChatRoomSaveInfo
{
	// Token: 0x17000E61 RID: 3681
	// (get) Token: 0x0600B12D RID: 45357
	// (set) Token: 0x0600B12E RID: 45358
	List<IChatRowSaveInfo> ChatRows { get; set; }
}
