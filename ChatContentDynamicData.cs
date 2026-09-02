using System;
using System.Runtime.CompilerServices;

// Token: 0x02001843 RID: 6211
[NullableContext(1)]
[Nullable(0)]
public class ChatContentDynamicData : IChatContentDynamicData
{
	// Token: 0x17000E85 RID: 3717
	// (get) Token: 0x0600B178 RID: 45432 RVA: 0x002F52F4 File Offset: 0x002F34F4
	// (set) Token: 0x0600B179 RID: 45433 RVA: 0x002F52FC File Offset: 0x002F34FC
	public ChatContentData ChatContentData { get; set; }

	// Token: 0x17000E86 RID: 3718
	// (get) Token: 0x0600B17A RID: 45434 RVA: 0x002F5305 File Offset: 0x002F3505
	// (set) Token: 0x0600B17B RID: 45435 RVA: 0x002F530D File Offset: 0x002F350D
	public EChatContentType Type { get; set; }
}
