using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020012E6 RID: 4838
[NullableContext(1)]
public interface IDangoMonopolyTaskTabData
{
	// Token: 0x17000AF3 RID: 2803
	// (get) Token: 0x06008303 RID: 33539
	EDangoMonopolyTaskType TaskType { get; }

	// Token: 0x17000AF4 RID: 2804
	// (get) Token: 0x06008304 RID: 33540
	string TaskTypeName { get; }

	// Token: 0x17000AF5 RID: 2805
	// (get) Token: 0x06008305 RID: 33541
	IReadOnlyList<DangoMonopolyTaskData> TaskList { get; }

	// Token: 0x17000AF6 RID: 2806
	// (get) Token: 0x06008306 RID: 33542
	long EndTime { get; }
}
