using System;
using System.Runtime.CompilerServices;

// Token: 0x0200215C RID: 8540
[NullableContext(1)]
[Nullable(0)]
public class ShareEvent : PlayerCommonLogData
{
	// Token: 0x170013B4 RID: 5044
	// (get) Token: 0x06010411 RID: 66577 RVA: 0x00475DE2 File Offset: 0x00473FE2
	// (set) Token: 0x06010412 RID: 66578 RVA: 0x00475DEA File Offset: 0x00473FEA
	public override string event_id { get; set; } = "1053";

	// Token: 0x04007E97 RID: 32407
	public int i_share_channel;

	// Token: 0x04007E98 RID: 32408
	public int i_share_result;

	// Token: 0x04007E99 RID: 32409
	public int i_share_scene;

	// Token: 0x04007E9A RID: 32410
	public int i_extra_choose;
}
