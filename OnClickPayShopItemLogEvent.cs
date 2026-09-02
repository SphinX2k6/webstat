using System;
using System.Runtime.CompilerServices;

// Token: 0x02002155 RID: 8533
[NullableContext(1)]
[Nullable(0)]
public class OnClickPayShopItemLogEvent : PlayerCommonLogData
{
	// Token: 0x170013AD RID: 5037
	// (get) Token: 0x060103FC RID: 66556 RVA: 0x00475CDB File Offset: 0x00473EDB
	// (set) Token: 0x060103FD RID: 66557 RVA: 0x00475CE3 File Offset: 0x00473EE3
	public override string event_id { get; set; } = "1829";

	// Token: 0x04007E81 RID: 32385
	public int i_id;

	// Token: 0x04007E82 RID: 32386
	public int i_shop_id;

	// Token: 0x04007E83 RID: 32387
	public int i_tab_id;
}
