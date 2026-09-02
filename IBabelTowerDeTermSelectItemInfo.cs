using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020011EE RID: 4590
[NullableContext(1)]
public interface IBabelTowerDeTermSelectItemInfo
{
	// Token: 0x17000A4F RID: 2639
	// (get) Token: 0x06007976 RID: 31094
	// (set) Token: 0x06007977 RID: 31095
	bool IsNecessary { get; set; }

	// Token: 0x17000A50 RID: 2640
	// (get) Token: 0x06007978 RID: 31096
	// (set) Token: 0x06007979 RID: 31097
	List<int> AllDeTerm { get; set; }

	// Token: 0x17000A51 RID: 2641
	// (get) Token: 0x0600797A RID: 31098
	// (set) Token: 0x0600797B RID: 31099
	List<int> DailyDeTerm { get; set; }

	// Token: 0x17000A52 RID: 2642
	// (get) Token: 0x0600797C RID: 31100
	// (set) Token: 0x0600797D RID: 31101
	Action<int> OnChangeSelectDeTerm { get; set; }
}
