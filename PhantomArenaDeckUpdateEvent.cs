using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena;

// Token: 0x0200216B RID: 8555
[NullableContext(1)]
[Nullable(0)]
public class PhantomArenaDeckUpdateEvent : PlayerCommonLogData
{
	// Token: 0x170013C3 RID: 5059
	// (get) Token: 0x0601043E RID: 66622 RVA: 0x00476034 File Offset: 0x00474234
	// (set) Token: 0x0601043F RID: 66623 RVA: 0x0047603C File Offset: 0x0047423C
	public override string event_id { get; set; } = "1703";

	// Token: 0x04007EC5 RID: 32453
	public int i_activity_id;

	// Token: 0x04007EC6 RID: 32454
	public int i_deck_order;

	// Token: 0x04007EC7 RID: 32455
	public string s_deck_name = "";

	// Token: 0x04007EC8 RID: 32456
	public int i_operation;

	// Token: 0x04007EC9 RID: 32457
	public PhantomArenaReportCardInfo[] o_deck_info = Array.Empty<PhantomArenaReportCardInfo>();

	// Token: 0x04007ECA RID: 32458
	public string o_build_click = "";

	// Token: 0x04007ECB RID: 32459
	public int i_build_id;

	// Token: 0x04007ECC RID: 32460
	public int i_deck_status;

	// Token: 0x04007ECD RID: 32461
	public int i_special_effect;
}
