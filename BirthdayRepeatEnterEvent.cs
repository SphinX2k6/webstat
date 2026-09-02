using System;
using System.Runtime.CompilerServices;

// Token: 0x02002198 RID: 8600
[NullableContext(1)]
[Nullable(0)]
public class BirthdayRepeatEnterEvent : PlayerCommonLogData
{
	// Token: 0x170013F0 RID: 5104
	// (get) Token: 0x060104C5 RID: 66757 RVA: 0x00476865 File Offset: 0x00474A65
	// (set) Token: 0x060104C6 RID: 66758 RVA: 0x0047686D File Offset: 0x00474A6D
	public override string event_id { get; set; } = "1063";

	// Token: 0x04007F92 RID: 32658
	public int i_item_id;

	// Token: 0x04007F93 RID: 32659
	public int i_trigger_type;

	// Token: 0x04007F94 RID: 32660
	public int bird_round_id;
}
