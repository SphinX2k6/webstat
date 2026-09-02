using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001956 RID: 6486
[NullableContext(2)]
public interface ISortStorageData
{
	// Token: 0x17000F19 RID: 3865
	// (get) Token: 0x0600B9FF RID: 47615
	// (set) Token: 0x0600BA00 RID: 47616
	int ConfigId { get; set; }

	// Token: 0x17000F1A RID: 3866
	// (get) Token: 0x0600BA01 RID: 47617
	// (set) Token: 0x0600BA02 RID: 47618
	int? SelectBaseSort { get; set; }

	// Token: 0x17000F1B RID: 3867
	// (get) Token: 0x0600BA03 RID: 47619
	// (set) Token: 0x0600BA04 RID: 47620
	List<int> SelectAttributeSort { get; set; }

	// Token: 0x17000F1C RID: 3868
	// (get) Token: 0x0600BA05 RID: 47621
	// (set) Token: 0x0600BA06 RID: 47622
	bool IsAscending { get; set; }
}
