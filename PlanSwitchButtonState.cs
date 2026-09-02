using System;
using System.Runtime.CompilerServices;

// Token: 0x020027FD RID: 10237
[NullableContext(1)]
[Nullable(0)]
public class PlanSwitchButtonState : IPlanSwitchButtonState
{
	// Token: 0x170019FF RID: 6655
	// (get) Token: 0x06014364 RID: 82788 RVA: 0x005A0D90 File Offset: 0x0059EF90
	// (set) Token: 0x06014365 RID: 82789 RVA: 0x005A0D98 File Offset: 0x0059EF98
	public bool IsShow { get; set; }

	// Token: 0x17001A00 RID: 6656
	// (get) Token: 0x06014366 RID: 82790 RVA: 0x005A0DA1 File Offset: 0x0059EFA1
	// (set) Token: 0x06014367 RID: 82791 RVA: 0x005A0DA9 File Offset: 0x0059EFA9
	public string Text { get; set; } = string.Empty;

	// Token: 0x17001A01 RID: 6657
	// (get) Token: 0x06014368 RID: 82792 RVA: 0x005A0DB2 File Offset: 0x0059EFB2
	// (set) Token: 0x06014369 RID: 82793 RVA: 0x005A0DBA File Offset: 0x0059EFBA
	public bool IsHighlight { get; set; }
}
