using System;
using System.Runtime.CompilerServices;

// Token: 0x02002154 RID: 8532
[NullableContext(1)]
[Nullable(0)]
public class OnOpenGiftPackageDetailsViewLogEvent : PlayerCommonLogData
{
	// Token: 0x170013AC RID: 5036
	// (get) Token: 0x060103F9 RID: 66553 RVA: 0x00475CB7 File Offset: 0x00473EB7
	// (set) Token: 0x060103FA RID: 66554 RVA: 0x00475CBF File Offset: 0x00473EBF
	public override string event_id { get; set; } = "1828";

	// Token: 0x04007E7C RID: 32380
	public int i_id;

	// Token: 0x04007E7D RID: 32381
	public int i_shop_id;

	// Token: 0x04007E7E RID: 32382
	public int i_tab_id;

	// Token: 0x04007E7F RID: 32383
	public int i_buy_through_third_party;
}
