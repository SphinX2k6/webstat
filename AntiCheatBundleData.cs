using System;
using System.Runtime.CompilerServices;

// Token: 0x02001798 RID: 6040
[NullableContext(1)]
[Nullable(0)]
public class AntiCheatBundleData : PlayerCommonLogData
{
	// Token: 0x17000DE4 RID: 3556
	// (get) Token: 0x0600AA94 RID: 43668 RVA: 0x002D9128 File Offset: 0x002D7328
	// (set) Token: 0x0600AA95 RID: 43669 RVA: 0x002D9130 File Offset: 0x002D7330
	public override string event_id { get; set; } = "8";

	// Token: 0x04005026 RID: 20518
	public string s_bundle_id = "";

	// Token: 0x04005027 RID: 20519
	public string s_version = "";
}
