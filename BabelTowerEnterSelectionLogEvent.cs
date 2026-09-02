using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020021D3 RID: 8659
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerEnterSelectionLogEvent : PlayerCommonLogData
{
	// Token: 0x17001425 RID: 5157
	// (get) Token: 0x0601056A RID: 66922 RVA: 0x00477173 File Offset: 0x00475373
	// (set) Token: 0x0601056B RID: 66923 RVA: 0x0047717B File Offset: 0x0047537B
	public override string event_id { get; set; } = "1933";

	// Token: 0x040080B4 RID: 32948
	public string s_trace_id = "";

	// Token: 0x040080B5 RID: 32949
	public string s_battle_id = "";

	// Token: 0x040080B6 RID: 32950
	public bool s_buff_selection;

	// Token: 0x040080B7 RID: 32951
	public string s_debuff_selection = "";

	// Token: 0x040080B8 RID: 32952
	public List<BuffSelectionData> o_buff_selection = new List<BuffSelectionData>();

	// Token: 0x040080B9 RID: 32953
	public List<DeBuffSelectionData> o_debuff_selection = new List<DeBuffSelectionData>();
}
