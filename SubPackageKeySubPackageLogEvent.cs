using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002199 RID: 8601
[NullableContext(1)]
[Nullable(0)]
public class SubPackageKeySubPackageLogEvent : CommonLogData
{
	// Token: 0x170013F1 RID: 5105
	// (get) Token: 0x060104C8 RID: 66760 RVA: 0x00476889 File Offset: 0x00474A89
	// (set) Token: 0x060104C9 RID: 66761 RVA: 0x00476891 File Offset: 0x00474A91
	public override string event_id { get; set; } = "1705";

	// Token: 0x04007F96 RID: 32662
	public int i_download_time;

	// Token: 0x04007F97 RID: 32663
	public int i_download_status;

	// Token: 0x04007F98 RID: 32664
	public List<int> o_phantoms = new List<int>();
}
