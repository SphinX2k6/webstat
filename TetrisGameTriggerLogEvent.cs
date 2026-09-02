using System;
using System.Runtime.CompilerServices;

// Token: 0x020021C1 RID: 8641
[NullableContext(1)]
[Nullable(0)]
public class TetrisGameTriggerLogEvent : PlayerCommonLogData
{
	// Token: 0x17001415 RID: 5141
	// (get) Token: 0x06010538 RID: 66872 RVA: 0x00476EF7 File Offset: 0x004750F7
	// (set) Token: 0x06010539 RID: 66873 RVA: 0x00476EFF File Offset: 0x004750FF
	public override string event_id { get; set; } = "1850";

	// Token: 0x0400806C RID: 32876
	public int i_config_id;
}
