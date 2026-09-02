using System;
using System.Runtime.CompilerServices;

// Token: 0x02002188 RID: 8584
[NullableContext(1)]
[Nullable(0)]
public class UiInteractChatLogEvent : PlayerCommonLogData
{
	// Token: 0x170013E0 RID: 5088
	// (get) Token: 0x06010495 RID: 66709 RVA: 0x00476604 File Offset: 0x00474804
	// (set) Token: 0x06010496 RID: 66710 RVA: 0x0047660C File Offset: 0x0047480C
	public override string event_id { get; set; } = "1809";

	// Token: 0x04007F57 RID: 32599
	public int i_old_count;

	// Token: 0x04007F58 RID: 32600
	public int i_new_count;

	// Token: 0x04007F59 RID: 32601
	public int i_inst_id;

	// Token: 0x04007F5A RID: 32602
	public double i_cost_time;

	// Token: 0x04007F5B RID: 32603
	public long i_skill_id;
}
