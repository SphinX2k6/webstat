using System;
using System.Runtime.CompilerServices;

// Token: 0x0200215D RID: 8541
[NullableContext(1)]
[Nullable(0)]
public class SdkStartReview : PlayerCommonLogData
{
	// Token: 0x170013B5 RID: 5045
	// (get) Token: 0x06010414 RID: 66580 RVA: 0x00475E06 File Offset: 0x00474006
	// (set) Token: 0x06010415 RID: 66581 RVA: 0x00475E0E File Offset: 0x0047400E
	public override string event_id { get; set; } = "1044";

	// Token: 0x04007E9C RID: 32412
	public string s_channel = "";

	// Token: 0x04007E9D RID: 32413
	public int i_id;
}
