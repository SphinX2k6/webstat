using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FilterDefine;

// Token: 0x02001901 RID: 6401
[NullableContext(1)]
public interface IFilterStorageData
{
	// Token: 0x17000EFA RID: 3834
	// (get) Token: 0x0600B7B5 RID: 47029
	// (set) Token: 0x0600B7B6 RID: 47030
	int ConfigId { get; set; }

	// Token: 0x17000EFB RID: 3835
	// (get) Token: 0x0600B7B7 RID: 47031
	// (set) Token: 0x0600B7B8 RID: 47032
	Dictionary<FilterDefine.EFilterType, List<int>> SelectRuleMap { get; set; }
}
