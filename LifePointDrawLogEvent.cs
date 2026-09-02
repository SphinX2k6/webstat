using System;
using System.Runtime.CompilerServices;

// Token: 0x02002174 RID: 8564
[NullableContext(1)]
[Nullable(0)]
public class LifePointDrawLogEvent : PlayerCommonLogData
{
	// Token: 0x170013CC RID: 5068
	// (get) Token: 0x06010459 RID: 66649 RVA: 0x004761A4 File Offset: 0x004743A4
	// (set) Token: 0x0601045A RID: 66650 RVA: 0x004761AC File Offset: 0x004743AC
	public override string event_id { get; set; } = "1704";

	// Token: 0x04007EE6 RID: 32486
	public int i_config_id;

	// Token: 0x04007EE7 RID: 32487
	public int i_group_entity_id;

	// Token: 0x04007EE8 RID: 32488
	public string s_type_name = "";

	// Token: 0x04007EE9 RID: 32489
	public int i_result;

	// Token: 0x04007EEA RID: 32490
	public int i_try_count;
}
