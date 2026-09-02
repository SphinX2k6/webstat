using System;
using System.Runtime.CompilerServices;

// Token: 0x0200216E RID: 8558
[NullableContext(1)]
[Nullable(0)]
public class ClickTermExplanationEvent : PlayerCommonLogData
{
	// Token: 0x170013C6 RID: 5062
	// (get) Token: 0x06010447 RID: 66631 RVA: 0x004760C1 File Offset: 0x004742C1
	// (set) Token: 0x06010448 RID: 66632 RVA: 0x004760C9 File Offset: 0x004742C9
	public override string event_id { get; set; } = "1068";

	// Token: 0x04007ED2 RID: 32466
	public int i_scene;
}
