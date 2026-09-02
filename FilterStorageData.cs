using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FilterDefine;

// Token: 0x02001902 RID: 6402
[NullableContext(1)]
[Nullable(0)]
public class FilterStorageData : IFilterStorageData
{
	// Token: 0x17000EFC RID: 3836
	// (get) Token: 0x0600B7B9 RID: 47033 RVA: 0x0030DC78 File Offset: 0x0030BE78
	// (set) Token: 0x0600B7BA RID: 47034 RVA: 0x0030DC80 File Offset: 0x0030BE80
	public int ConfigId { get; set; }

	// Token: 0x17000EFD RID: 3837
	// (get) Token: 0x0600B7BB RID: 47035 RVA: 0x0030DC89 File Offset: 0x0030BE89
	// (set) Token: 0x0600B7BC RID: 47036 RVA: 0x0030DC91 File Offset: 0x0030BE91
	public Dictionary<FilterDefine.EFilterType, List<int>> SelectRuleMap { get; set; }
}
