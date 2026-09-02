using System;
using System.Runtime.CompilerServices;

// Token: 0x0200216D RID: 8557
[NullableContext(1)]
[Nullable(0)]
public class EnterViewWithTermsEvent : PlayerCommonLogData
{
	// Token: 0x170013C5 RID: 5061
	// (get) Token: 0x06010444 RID: 66628 RVA: 0x0047609D File Offset: 0x0047429D
	// (set) Token: 0x06010445 RID: 66629 RVA: 0x004760A5 File Offset: 0x004742A5
	public override string event_id { get; set; } = "1067";

	// Token: 0x04007ED0 RID: 32464
	public int i_scene;
}
