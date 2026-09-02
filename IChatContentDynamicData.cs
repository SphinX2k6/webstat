using System;
using System.Runtime.CompilerServices;

// Token: 0x02001842 RID: 6210
[NullableContext(1)]
public interface IChatContentDynamicData
{
	// Token: 0x17000E83 RID: 3715
	// (get) Token: 0x0600B174 RID: 45428
	// (set) Token: 0x0600B175 RID: 45429
	ChatContentData ChatContentData { get; set; }

	// Token: 0x17000E84 RID: 3716
	// (get) Token: 0x0600B176 RID: 45430
	// (set) Token: 0x0600B177 RID: 45431
	EChatContentType Type { get; set; }
}
