using System;
using System.Runtime.CompilerServices;

// Token: 0x02003455 RID: 13397
[NullableContext(1)]
public interface IEntityToLoadParam
{
	// Token: 0x1700264F RID: 9807
	// (get) Token: 0x0601C18E RID: 115086
	// (set) Token: 0x0601C18F RID: 115087
	long MaxLoadingCount { get; set; }

	// Token: 0x17002650 RID: 9808
	// (get) Token: 0x0601C190 RID: 115088
	// (set) Token: 0x0601C191 RID: 115089
	long LoadingInterval { get; set; }

	// Token: 0x17002651 RID: 9809
	// (get) Token: 0x0601C192 RID: 115090
	string MaxLoadingDebugName { get; }

	// Token: 0x17002652 RID: 9810
	// (get) Token: 0x0601C193 RID: 115091
	string LoadingIntervalDebugName { get; }
}
