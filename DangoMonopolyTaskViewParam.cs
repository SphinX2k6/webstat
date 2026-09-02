using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001309 RID: 4873
public class DangoMonopolyTaskViewParam
{
	// Token: 0x04003EEB RID: 16107
	public int? TaskId;

	// Token: 0x04003EEC RID: 16108
	[Nullable(1)]
	public List<IDangoMonopolyTaskTabData> TaskList = new List<IDangoMonopolyTaskTabData>();
}
