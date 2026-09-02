using System;
using System.Runtime.CompilerServices;

// Token: 0x0200217A RID: 8570
[NullableContext(1)]
[Nullable(0)]
public class HoldHandEnterLogEvent : PlayerCommonLogData
{
	// Token: 0x170013D2 RID: 5074
	// (get) Token: 0x0601046B RID: 66667 RVA: 0x004763EB File Offset: 0x004745EB
	// (set) Token: 0x0601046C RID: 66668 RVA: 0x004763F3 File Offset: 0x004745F3
	public override string event_id { get; set; } = "160301";

	// Token: 0x04007F30 RID: 32560
	public string reason = "";
}
